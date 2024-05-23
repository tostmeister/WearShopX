using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WearShopX.db;
using Modul; 

namespace WearShopX.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        int checkPrice;

        public OrderWindow()
        {
            InitializeComponent();
            ChangeItemSource();
        }

        private void ChangeItemSource()
        {
            var items = from c in WearShopDBEntities4.GetContext().CardItems
                        select new Cartitem
                        {
                            id = c.id,
                            name = c.name,
                            price = (int)c.price,
                            size = (int)c.size,
                            quantity = (int)c.quantity,
                        };

            var itemsList = new ObservableCollection<object>(items.ToList());
            foreach (Cartitem item in itemsList) 
            {
                checkPrice =+ (int)item.price;
            }
            finallyPrice.Text = checkPrice.ToString();
            lvOrder.ItemsSource = itemsList;
        }



        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            var db = WearShopDBEntities4.GetContext();
            var items = db.CardItems;

            foreach (var item in items)
            {
                db.CardItems.Remove(item);
            }
            db.SaveChanges();
            MessageBox.Show($"Заказ оформлен. Спасибо, {tbName.Text}!");
            DialogResult = true;
        }
    }
}
