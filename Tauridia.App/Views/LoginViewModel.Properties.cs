using System.Runtime.Serialization;
using System.Security;
using ReactiveUI;

namespace Tauridia.App.Views
{
    public partial class LoginViewModel
    {
        private string userName;
        [DataMember]
        public string UserName { get => userName; set => this.RaiseAndSetIfChanged(ref userName, value); }

        private string password;

        [DataMember]
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }
    }
}
