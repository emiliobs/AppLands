﻿

using Xamarin.Forms;

namespace AppLands.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using AppLands.Models;
    using AppLands.Services;
    using Xamarin.Forms.Internals;

    public class LandsViewModel  : BaseViewModel
    {
        #region Services

        private readonly ApiService apiService;

        #endregion

        #region Attributes

        private ObservableCollection<Lands> lands;

        #endregion

        #region Properties

        public ObservableCollection<Lands> Lands
        {
            get => lands;
            set
            {
                if (lands != value) SetValue(ref lands, value);
               
            }
        }

        #endregion

        #region Constructor

        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoandLands();
            
        }

        #endregion

        #region Methods

        private async void LoandLands()
        {
            var response = await this.apiService.GetList<Lands>(
                "http://restcountries.eu"
                , "/rest"
                , "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                return;
            }

            //casteos elel resultado que llega de la api con una list:
            var list = (List<Lands>)response.Result;

            //aqui ya lotengo en memoria en una lista obserbablecollection:
            this.Lands = new ObservableCollection<Lands>(list);
        }

        #endregion
    }
}
