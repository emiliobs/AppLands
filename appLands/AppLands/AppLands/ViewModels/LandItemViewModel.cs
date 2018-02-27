
using System.Windows.Input;
using AppLands.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AppLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AppLands.Models;

    public class LandItemViewModel : Lands
    {
        #region Commands

        public ICommand SelectLandCommand
        {
            get => new RelayCommand(SelectLand);



        }
        #endregion

        #region Methods

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);

            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
        }

        #endregion
    }
}
