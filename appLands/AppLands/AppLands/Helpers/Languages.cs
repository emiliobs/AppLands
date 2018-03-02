namespace AppLands.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AppLands.Interfaces;
    using AppLands.Resources;
    using Xamarin.Forms;

    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get => Resource.Accept;
        }

        public static string EmailValidate
        {
            get => Resource.EmailValidate;
        }

        public static string Error
        {
            get => Resource.Error;
        }

        public static string EmailPlaceHolder
        {
            get => Resource.EmailPlaceHolder;
        }

        public static string Rememberme
        {
            get => Resource.Rememberme;
        }

    }
}
