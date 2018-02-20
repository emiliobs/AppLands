 
namespace AppLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    public class LoginViewModel
    {
        #region Atributtes

        #endregion

        #region Properties

        public string Email { get; }

        public string Password
        {
            get;
        }

        public bool IsRunning
        {
            get;
        }

        public bool IsRemember
        {
            get;
        }

        #endregion

        #region Commamds
        public ICommand LoginCommand { get; }
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRemember = true;
        }
        #endregion

        #region Methods

        #endregion
    }
}
