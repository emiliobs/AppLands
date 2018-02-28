

using System.Linq;

namespace AppLands.ViewModels
{

    using System.Collections.ObjectModel;
    using Xamarin.Forms.Internals;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using  Models;
   
    public class LandViewModel : BaseViewModel
    {

        #region Atribbutes

        private ObservableCollection<Border> borders;
        private Border code;

        #endregion

        #region Properties

        public ObservableCollection<Border> Borders
        {
            get => this.borders;
            set
            {
                if (this.borders != value) this.SetValue(ref this.borders, value);
            }    
        } 

        public Lands Land
        {
            get;
            set;
        }

        public Border Code
        {
            get => this.code;

            set
            {
                if (this.code != value) this.SetValue(ref this.code, value);
                {
                    
                }
            }
        }

        #endregion

        #region Constructor
        public LandViewModel(Lands land)
        {
            this.Land = land;
            this.LoadBorders();
        }

        #endregion

        #region Methods

        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();

            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.FirstOrDefault(l => l.Alpha3Code == border);

                if (land != null)
                {
                                 this.Borders.Add(new Border()
                                 {
                                     Code = land.Alpha3Code,
                                    Name = land.Name,
                                 });
                }
            }
        }

        #endregion
    }
}
