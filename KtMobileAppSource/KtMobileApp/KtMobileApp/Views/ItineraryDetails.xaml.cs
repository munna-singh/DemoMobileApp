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
	public partial class ItineraryDetails : ContentPage
	{
        ItineraryDetailsViewModel viewModel;

        public ItineraryDetails()
		{
            InitializeComponent();
            /*NavigationPage.SetHasNavigationBar(*/
            BindingContext = viewModel = new ItineraryDetailsViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ItineraryDailyBreakDown.Count == 0)
                viewModel.LoadItineraryCommand.Execute(null);
        }
    }
}