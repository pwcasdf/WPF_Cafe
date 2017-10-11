using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace CafeProgram
{
    public class ItemData
    {
        public string Name { get; set; }
        public string Menu { get; set; }
        public string Qty { get; set; }
        public int Value { get; set; }

        public ItemData(string name, string menu, string qty, int value)
        {
            Name = name;
            Menu = menu;
            Qty = qty;
            Value = value;
        }
    }

    public partial class MainWindow : Window
    {
        List<ItemData> data;

        public MainWindow()
        {
            this.InitializeComponent();
            
            string versionInfo = System.IO.File.ReadAllText("./1.dll");
            versionTextBox.Text = versionInfo;
            
            data = new List<ItemData>();
            data.Add(new ItemData("menu1_Button", "Americano", "x1", 3000));
            data.Add(new ItemData("menu2_Button", "Cafe Mocha", "x1", 3500));
            data.Add(new ItemData("menu3_Button", "Cappuccino", "x1", 3500));
            data.Add(new ItemData("menu4_Button", "Caramel Macchiato", "x1", 3500));
            data.Add(new ItemData("menu5_Button", "Espresso", "x1", 3000));
            data.Add(new ItemData("menu6_Button", "Flat White", "x1", 3500));
            data.Add(new ItemData("menu7_Button", "Green Tea Latte", "x1", 4000));
            data.Add(new ItemData("menu8_Button", "Java Chip", "x1", 4000));
            data.Add(new ItemData("menu9_Button", "Cafe Latte", "x1", 4000));
        }

        private void calc_sum()
        {
            int sum = 0;

            foreach (object value in listViewMoney.Items)
            {
                int val1 = int.Parse(value.ToString());
                sum += val1;
            }
            total_Textbox.Text = sum.ToString();
        }

        private void SetData(string name)
        {
            foreach (ItemData item in data)
            {
                if (item.Name == name)
                {
                    listView.Items.Add(item.Menu);
                    listViewQty.Items.Add(item.Qty);
                    listViewMoney.Items.Add(item.Value);
                    calc_sum();
                }
            }
        }

        private void exit_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pay_Clicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void menu_Clicked(object sender, RoutedEventArgs e)
        {
            SetData((string)((Button)sender).Name);
        }
    }
}
