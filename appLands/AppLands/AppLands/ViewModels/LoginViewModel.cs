
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppLands.Annotations;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AppLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Atributtes

        //private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region Properties

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get => this.password;

            set
            {
                if (this.password != value)
                {
                    this.password = value;

                   OnPropertyChanged(this.Password);
                }

               
            }
        }

        public bool IsRunning
        {
            get => this.isRunning;
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;

                    OnPropertyChanged(this.IsRunning.ToString());
                }
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
                if (isEnabled != value)
                {
                    isEnabled = value;

                    OnPropertyChanged(this.IsEnabled.ToString());
                }
            }
            get => isEnabled;
        }

        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;
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

            await Application.Current.MainPage.DisplayAlert("OK", "Fuck yeahh", "Accept");
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
