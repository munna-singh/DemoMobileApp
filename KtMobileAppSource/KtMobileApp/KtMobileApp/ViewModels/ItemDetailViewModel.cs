using System;
using System.Globalization;
using KtMobileApp.Models;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        private string _CompleteDescription;
        public string CompleteDescription
        {
            get { return _CompleteDescription; }
            set
            {
                _CompleteDescription = value;
                OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            CompleteDescription = @"<html><body> <h2>Hello Friends</h2> <br> Hello Friends : <ul><li>Item-1</li><li>Item-2</li><li>Item-3</li></ul> <br>Hello Friends Hello Friends Hello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello Friends Hello Friends   Hello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello FriendsHello Friends </html></body>";
        }
    }

    public class HtmlSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var html = new HtmlWebViewSource();

            if (value != null)
            {
                html.Html = value.ToString();
            }

            return html;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
