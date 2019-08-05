﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoadMoreUG
{
    public class LoadMoreViewModel
    {
        internal string[] Names = new string[]
        {"Apple", "Banana", "Papaya", "Lime", "Pomegranate", "Orange",  "Watermelon", "Apricot", "Grapes", "Cherry", "Custard Apple", "Dragon", "Pear", "Mango", "Lemon", "Guava", "Jackfruit", "Kiwi", "Peaches", "Pineapple", "Strawberry", "Raspberry"};

        internal string[] Weights = new string[]
        {"500 gm","850 gm","500 gm","500 gm","400 gm","500 gm","950 gm","900 gm","500 gm","500 gm","500 gm","950 gm","500 gm","500 gm","500 gm","500 gm","500 gm","500 gm","500 gm","750 gm","500 gm","500 gm"};

        internal double[] Prices = new double[]
        {2.47,1.40,1.48,2.28,10.47,1.00,3.98,14.99,1.50,7.48,26.20,22.66,1.47,7.10,7.40,6.00,7.27,7.33,9.99,2.00,13.99,16.99};

        public ObservableCollection<Product> Products { get; set; }
        public Command<object> LoadMoreItemsCommand { get; set; }

        public LoadMoreViewModel()
        {
            Products = new ObservableCollection<Product>();
            AddProducts(0, 10);
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
        }

        private async void LoadMoreItems(object obj)
        {
            var listview = obj as Syncfusion.ListView.XForms.SfListView;
            listview.IsBusy = true;            
            await Task.Delay(2500);
            AddProducts(11, 21);
            listview.IsBusy = false;
        }

        private void AddProducts(int value, int count)
        {
            Random rand= new Random();
            for (int i = value; i < count; i++)
            {
                var name = Names[rand.Next(1,22)];
                var p = new Product()
                {
                    Name = name,
                    Weight = Weights[i],
                    Price = Prices[i],
                    Image = ImageSource.FromResource("ListViewLoadMore.LoadMore." + name.Replace(" ", string.Empty) + ".jpg")
                };

                Products.Add(p);
            }
        }
    }
}
