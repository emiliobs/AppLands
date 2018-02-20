using System;
using System.Collections.Generic;
using System.Text;

namespace AppLands.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }

        #endregion

        #region Contructor

        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }

        #endregion
    }
}
