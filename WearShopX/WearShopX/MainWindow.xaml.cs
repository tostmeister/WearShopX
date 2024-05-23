using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WearShopX.db;
using WearShopX.Windows;
using Modul;
using static System.Net.Mime.MediaTypeNames;

namespace WearShopX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Item item;
        public MainWindow()
        {
            InitializeComponent();
            ChangeItemSource();
        }

        private void ChangeItemSource() 
        {
            var items = from c in WearShopDBEntities4.GetContext().Items
                        select new Item
                        {
                            id = c.id,
                            name = c.name,
                            price = (int)c.price,
                            size = (int)c.size,
                            category = c.category
                        };

            var itemsList = new ObservableCollection<object>(items.ToList());
            lvItems.ItemsSource = itemsList;

        }

        public void InfoOfItem(Item selectedItem)
        {
            this.item = selectedItem;
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (lvItems.SelectedItem == null)
            {
                MessageBox.Show("Для начала нужно выбрать заявку!");
            }

            else 
            {
                InfoOfItem((Item)lvItems.SelectedItem);
                var db = WearShopDBEntities4.GetContext();
                var items = db.Items.Where(app => app.id == item.id);

                foreach (var item in items)
                {
                    CardItems card = new CardItems()
                    {
                        id = item.id,
                        name = item.name,
                        price = item.price,
                        size = item.size,
                        quantity = 1
                    };
                    lvCart.Items.Add(card);
                    db.CardItems.Add(card);
                }
                db.SaveChanges();
            }
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new OrderWindow();
            order.ShowDialog();
        }

        private void btnWarehouse_Click(object sender, RoutedEventArgs e)
        {
            var warehouse = new WarehouseWindow();
            warehouse.ShowDialog();
        }
    }
}
