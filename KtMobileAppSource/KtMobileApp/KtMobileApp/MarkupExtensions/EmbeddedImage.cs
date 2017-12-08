using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KtMobileApp.MarkupExtensions
{
    public class EmbeddedImage : IMarkupExtension
    {
        public string this[string resourceKey]
        {
            set
            {
                ResourceId = resourceKey;
            }
        }


        public string ResourceId
        {
            get;
            set;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceId)) return null;
            return ImageSource.FromResource(ResourceId);
        }
    }
}
