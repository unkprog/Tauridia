using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Unicode;
using System.Threading.Tasks;
using Tauridia.Core.Models.Project;
using Utf8Json;
using Utf8Json.AspNetCoreMvcFormatter;
using Utf8Json.Resolvers;

namespace Tauridia.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            services.AddControllers().AddMvcOptions(option =>
            {
                option.OutputFormatters.Clear();
                option.OutputFormatters.Add(new JsonOutputFormatter123(StandardResolver.Default));
                option.InputFormatters.Clear();
                option.InputFormatters.Add(new JsonInputFormatter123());
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public class JsonOutputFormatter123 : IOutputFormatter //, IApiResponseTypeMetadataProvider
    {
        const string ContentType = "application/json";
        static readonly string[] SupportedContentTypes = new[] { ContentType };

        readonly IJsonFormatterResolver resolver;

        public JsonOutputFormatter123()
            : this(null)
        {

        }
        public JsonOutputFormatter123(IJsonFormatterResolver resolver)
        {
            this.resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        //public IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
        //{
        //    return SupportedContentTypes;
        //}

        public bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return true;
        }

        public Task WriteAsync(OutputFormatterWriteContext context)
        {
            context.HttpContext.Response.ContentType = ContentType;

            // when 'object' use the concrete type(object.GetType())
            if (context.ObjectType == typeof(object))
            {
                return JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body, context.Object, resolver);
            }
            else
            {
                return JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType, context.HttpContext.Response.Body, context.Object, resolver);
            }
        }
    }

    public class JsonInputFormatter123 : IInputFormatter // , IApiRequestFormatMetadataProvider
    {
        const string ContentType = "application/json";
        static readonly string[] SupportedContentTypes = new[] { ContentType };

        readonly IJsonFormatterResolver resolver;

        public JsonInputFormatter123()
            : this(null)
        {

        }

        public JsonInputFormatter123(IJsonFormatterResolver resolver)
        {
            this.resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        //public IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
        //{
        //    return SupportedContentTypes;
        //}

        public bool CanRead(InputFormatterContext context)
        {
            return true;
        }

        public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;

            //byte[] ss = new byte[request.Body.Length + 10];
            //request.Body.Read(ss, 0, (int)request.Body.Length);
            //string sss = System.Text.UTF8Encoding.UTF8.GetString(ss);
            var reader = new StreamReader(request.Body);
            //reader.BaseStream.Seek(0, SeekOrigin.Begin);
            var rawMessage = reader.ReadToEnd();
            //var result0 = JsonSerializer.NonGeneric.Deserialize(typeof(Project), rawMessage);
            var result = JsonSerializer.NonGeneric.Deserialize(context.ModelType, rawMessage, resolver);
            //var result = JsonSerializer.NonGeneric.Deserialize(context.ModelType, new StreamReader(request.Body).BaseStream, resolver);
            return InputFormatterResult.SuccessAsync(result);
        }
    }
}
