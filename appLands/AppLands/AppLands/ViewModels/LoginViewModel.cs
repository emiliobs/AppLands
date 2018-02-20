

using AppLands.Views;

namespace AppLands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using System.Windows.Input;
    public class LoginViewModel : BaseViewModel
    {
        #region Atributtes

        //private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private string email;

        #endregion

        #region Properties

        public string Email
        {
            get => this.email;
            set
            {
                if (this.email != value) SetValue(ref email, value);

            }
        }

        public string Password
        {
            get => this.password;

            set
            {
                if (password != value) SetValue(ref password, value);
            }
        }

        public bool IsRunning
        {
            get => this.isRunning;
            set
            {
                if (this.isRunning != value) SetValue(ref isRunning, value);
            }

        }

        public bool IsRemember
        {
            set;
            get;
        }

        public bool IsEnabled
        {
            set
            {
                if (isEnabled != value) SetValue(ref isEnabled, value);

            }
            get => isEnabled;
        }

        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;

            this.Email = "barrera_emilio@hotmail.com";
            this.Password = "Eabs123.";
        }
        #endregion

        #region Commamds

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }



        #endregion


        #region Methods

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Email.",
                    "Accept");

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Password.",
                    "Accept");

                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;


            if (this.Email != "barrera_emilio@hotmail.com" || this.Password != "Eabs123.")
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Email or Password incorrect.!",
                     "Accept");

                this.Password = string.Empty;

                return;
            }

            //await Application.Current.MainPage.DisplayAlert("OK", "Fuck yeahh", "Accept");
            
            //clear text:
            this.Email = string.Empty;
            this.Password = string.Empty;


            MainViewModel.GetInstance().Lands = new LandsViewModel();
            //apilo las view para nevegar entre paginas:
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            this.IsRunning = false;
            this.IsEnabled = true;
        }

        #endregion

        #region Events
        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion
    }
}
