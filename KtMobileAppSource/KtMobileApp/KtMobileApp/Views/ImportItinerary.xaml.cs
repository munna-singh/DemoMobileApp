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
	public partial class ImportItinerary : ContentPage
	{
        ImportItineraryViewModel viewModel;
        public ImportItinerary ()
		{
			InitializeComponent ();

            viewModel = new ImportItineraryViewModel(Navigation);
            viewModel.ImageSourceCloseFormPath = "KtMobileApp.Assets.Images.Close_48_48.png";
            viewModel.ImportStatusIconPath = "KtMobileApp.Assets.Images.StatusDone_128_128.png";
            viewModel.ImportFailedIconPath = "KtMobileApp.Assets.Images.Status_Failed_128_128.png";
            BindingContext = viewModel;
        }
	}
}