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
using System.Windows.Shapes;
using WearShopX.db;
using Modul;

namespace WearShopX.Windows
{
    public partial class EditWindow : Window
    {
        Item wareItem;
        public EditWindow()
        {
            InitializeComponent();
        }

        public void InfoOfItem(Item selectedItem)
        {
            this.wareItem = selectedItem;
            TextId.Text = wareItem.id.ToString();
            TextName.Text = wareItem.name.ToString();
            TextPrice.Text = wareItem.price.ToString();
            TextSize.Text = wareItem.size.ToString();
            TextCategory.Text = wareItem.category.ToString();
        }

        private void WriteChanges(object sender, RoutedEventArgs e)
        {
            var db = WearShopDBEntities4.GetContext();
            var items = db.Warehouse.Where(app => app.id == wareItem.id);

            foreach (var item in items)
            {
                item.id = int.Parse(TextId.Text);
                item.name = TextName.Text;
                item.price = int.Parse(TextPrice.Text);
                item.size = int.Parse(TextSize.Text);
                item.category = TextCategory.Text;
            }
            db.SaveChanges();
            this.Close();
        }
    }
}
