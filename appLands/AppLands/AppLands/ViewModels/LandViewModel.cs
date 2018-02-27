 namespace AppLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using  Models;
                 

    public class LandViewModel
    {

        #region Properties

        public Lands Land
        {
            get;
            set;
        }

        #endregion

        #region Constructor
        public LandViewModel(Lands land)
        {
            this.Land = land;
        } 
        #endregion
    }
}
