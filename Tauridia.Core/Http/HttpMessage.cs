namespace Tauridia.Core.Http
{
    public class HttpMessage<T>
    {
        public int Result { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
