

namespace AppLands.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using AppLands.Models;
    public class MainViewModel
    {
        #region Properties

        public List<Lands> LandsList { get; set; }

        #endregion

        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }       
        public LandViewModel Land { get; set; }


        #endregion

        #region Contructor

        public MainViewModel()
        {
            //patrón singleton
            instance = this;

            this.Login = new LoginViewModel();
            
        }

        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return  new MainViewModel();
            }

            return instance;
        }

        #endregion
    }
}
