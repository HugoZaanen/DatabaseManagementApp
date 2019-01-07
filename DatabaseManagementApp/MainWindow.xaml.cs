using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DatabaseManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var query = from p in db.Products
                        select p;

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var query = from p in db.Products
                        select p.ProductCategory;

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var query = from p in db.Products
                        orderby p.ListPrice descending
                        select p;
            
            var results = query.Take(20).ToList();
                      
            dg.ItemsSource = results;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = null;
            var db = new AdventureWorksEntities();

            var query = from p in db.Products
                        select new
                        {
                            p.ProductID,
                            p.Name,
                            p.Color,
                            p.ListPrice,
                            CategoryName = p.ProductCategory.Name
                        };

            MessageBox.Show(query.ToString());

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var nieuwe = new ProductCategory();
            nieuwe.Name = "The game";
            nieuwe.ModifiedDate = DateTime.Now;
            nieuwe.rowguid = Guid.NewGuid();

            db.ProductCategories.Add(nieuwe);

            //stuur de wijsingingen naar de DB toe
            db.SaveChanges();
        }
    }
}
