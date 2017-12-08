using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KtMobileApp.Models
{
    public static class Extensions
    {
        // Extend ObservableCollection<T> Class
        public static void AddRange<T>(this ObservableCollection<T> o, T[] items)
        {
            foreach (var item in items)
            {
                o.Add(item);
            }
        }
    }
}
