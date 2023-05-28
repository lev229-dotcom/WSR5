using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSR5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListTours.ItemsSource = Data.TradeEntities.Product.ToList();
            var manufateries = Data.TradeEntities.Product.ToList();
            var testst = new List<string>();

            testst.Add("Все производители");
            testst.AddRange(manufateries.Select(i => i.ProductManufacturer).Distinct());

            Manufacture.ItemsSource = testst;
        }

        private void ListTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var test = (ListTours.SelectedItem as Product);
        }

        private void Manufacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var test = Manufacture.SelectedItem as string;

            if (test != "Все производители") 
            {
                ListTours.ItemsSource = Data.TradeEntities.Product.Where(i => i.ProductManufacturer == test).ToList();
            }
            else
                ListTours.ItemsSource = Data.TradeEntities.Product.ToList();

            var product = new Product()
            {
                ProductArticleNumber = test,
                ProductManufacturer = test,
                ProductName = test,
                ProductDescription = test,
                ProductCategory = test,
                ProductCost = 1,
                ProductDiscountAmount = 1,
                ProductQuantityInStock = 1,
                ProductStatus = "bn"
            };
            Data.TradeEntities.Product.Add(product);
            Data.TradeEntities.SaveChanges();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                File.Copy(openFileDialog.FileName, "C:\\Users\\leox5\\source\\repos\\WSR5\\WSR5\\Resources\\TEST.png");
            }
            
        }
    }
}
