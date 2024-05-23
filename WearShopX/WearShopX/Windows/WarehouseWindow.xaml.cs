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
    /// Логика взаимодействия для WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        public WarehouseWindow()
        {
            InitializeComponent();
            ChangeItemSource();
        }

        private void ChangeItemSource()
        {
            var items = from c in WearShopDBEntities4.GetContext().Warehouse
                        select new Item
                        {
                            id = c.id, 
                            name = c.name, 
                            price = (int)c.price, 
                            size = (int)c.size, 
                            category =  c.category 
                        };

            var itemsList = new ObservableCollection<object>(items.ToList());
            dtWareHouse.ItemsSource = itemsList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            this.Close();
            addWindow.Show();
            ChangeItemSource();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtWareHouse.SelectedItem == null)
            {
                MessageBox.Show("Для начала нужно выбрать заявку!");
            }

            else
            {
                Item selecteditem = (Item)dtWareHouse.SelectedItem;
                var db = WearShopDBEntities4.GetContext();
                var items = db.Warehouse.Where(item => item.id == selecteditem.id);

                foreach (var item in items)
                {
                    db.Warehouse.Remove(item);
                }

                db.SaveChanges();
            }
            ChangeItemSource();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtWareHouse.SelectedItem == null)
            {
                MessageBox.Show("Для начала нужно выбрать заявку!");
            }

            else
            {
                EditWindow editWindow = new EditWindow();
                this.Close();
                editWindow.Show();
                editWindow.InfoOfItem((Item)dtWareHouse.SelectedItem);
                ChangeItemSource();
            }
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            if (dtWareHouse.SelectedItem == null)
            {
                MessageBox.Show("Для начала нужно выбрать заявку!");
            }

            else
            {
                Item selecteditem = (Item)dtWareHouse.SelectedItem;
                var db = WearShopDBEntities4.GetContext();
                var wareitems = db.Warehouse.Where(i => i.id == selecteditem.id);

                Items item = new Items() 
                {
                    id = selecteditem.id,
                    name = selecteditem.name,
                    price = selecteditem.price,
                    size = selecteditem.size,
                    category = selecteditem.category,
                };
                
                db.Items.Add(item);

                foreach (var i in wareitems)
                {
                    db.Warehouse.Remove(i);
                }

                db.SaveChanges();
            }
            ChangeItemSource();
        }
    }
}
