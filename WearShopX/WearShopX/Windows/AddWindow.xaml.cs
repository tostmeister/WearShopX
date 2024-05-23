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

namespace WearShopX.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void WriteChanges(object sender, RoutedEventArgs e)
        {
            var db = WearShopDBEntities4.GetContext();

            Warehouse wareItem = new Warehouse()
            {
                id = int.Parse(TextId.Text),
                name = TextName.Text,
                price = int.Parse(TextPrice.Text),
                size = int.Parse(TextSize.Text),
                category = TextCategory.Text,
            };
           
            db.Warehouse.Add(wareItem);
            db.SaveChanges();
            this.Close();
        }
    }
}

