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
            viewModel.ImageSourceCloseFormPath = "KtMobileApp.Assets.Images.Close_32_32.png";
            viewModel.ImportStatusIconPath = "KtMobileApp.Assets.Images.StatusDone_128_128.png";
            BindingContext = viewModel;
        }
	}
}