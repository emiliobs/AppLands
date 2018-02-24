

using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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

        private bool isRefreshing;
        private bool refreshCommand;

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

        public bool IsRefreshing
        {
            get => this.isRefreshing;

            set
            {

                if (isRefreshing != value) SetValue(ref isRefreshing, value);
                
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

        #region Commands

        public ICommand RefreshCommand
        {
            get => new RelayCommand(LoandLands);
        }

        #endregion

        #region Methods

        private async void LoandLands()
        {
            //aqui refeesco la lista: 
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");

                //aqui desapilo la navegacion entre paginas:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var response = await this.apiService.GetList<Lands>(
                "http://restcountries.eu"
                , "/rest"
                , "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                //aqui desapilo la navegacion entre paginas:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            //casteos elel resultado que llega de la api con una list:
            var list = (List<Lands>)response.Result;

            //aqui ya lotengo en memoria en una lista obserbablecollection:
            this.Lands = new ObservableCollection<Lands>(list);

            this.IsRefreshing = false;
        }

        #endregion

       
    }
}
