

using System;
using AppLands.Helpers;
using AppLands.Services;
using AppLands.Views;

namespace AppLands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using System.Windows.Input;
    public class LoginViewModel : BaseViewModel
    {

        #region Services

        private ApiService apiService;

        #endregion

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

            this.apiService = new ApiService();

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
                    Languages.Error,
                    Languages.EmailValidate,
                    Languages.Accept);

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    "You must enter a Password.",
                    Languages.Accept);

                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;


            var conecction = await this.apiService.CheckConnection();

            if (!conecction.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error, 
                    conecction.Message, 
                    Languages.Accept);

                return;
            }

             //here take del apiservice gettoken:
            var token = await this.apiService.GetToken("http://landsapi1.azurewebsites.net", this.Email, this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error,
                    "Something was wrong, please try again later.",
                    Languages.Accept);

                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(Languages.Error, 
                    token.ErrorDescription, 
                    Languages.Accept);

                this.Password = String.Empty;
                
                return;
            }

            //apuntador a la mainviewmodel:
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            this.IsRunning = false;
            this.IsEnabled = true;

            //aqui pregunto que me de el toquen para saber que si es usted:



            //if (this.Email != "barrera_emilio@hotmail.com" || this.Password != "Eabs123.")
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //         "Error",
            //         "Email or Password incorrect.!",
            //         "Accept");

            //    this.Password = string.Empty;

            //    return;
            //}

            //await Application.Current.MainPage.DisplayAlert("OK", "Fuck yeahh", "Accept");
            
            //clear text:
            this.Email = string.Empty;
            this.Password = string.Empty;   

            //MainViewModel.GetInstance().Lands = new LandsViewModel();
            mainViewModel.Lands = new LandsViewModel();
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
