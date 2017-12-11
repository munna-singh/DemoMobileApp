using KtMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KtMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Itineraries : ContentPage
	{
        ItinerariesViewModel viewModel;

        public Itineraries ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new ItinerariesViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ItineraryDailyBreakDown.Count == 0)
                viewModel.LoadItineraryCommand.Execute(null);
        }
    }
}