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
using Application.Services.ViewModels;
using Domain.Model.Entities;
using ClientAppLibrary;
namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            MakeNewTabItem("Пользователи", "UsersPage.xaml", "UsersTabItem");
            /*UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
            */
        }

        private void MakeNewTabItem(string Name, string Page, string TabItemName)
        {
            //Проверить на наличии вкладки содержащие TabItemName если существует обновить
            var ExistItem = from TabItem ti in TabControl.Items
                            where ti.Name == TabItemName
                            select ti;

            if (ExistItem.Count() > 0)
            {
                ExistItem.First().IsSelected = true;
                return;
            }


            TextBlock tb = new TextBlock() { Text = Name };
            Button bt = new Button() { Content = "X" };
            WrapPanel wp = new WrapPanel();
            wp.Children.Add(tb);
            wp.Children.Add(bt);
            Frame frame = new Frame();
            frame.NavigationService.Navigate(new Uri(Page, UriKind.Relative));
            TabItem tbItem = new TabItem() { Header = wp, Content = frame, Name = TabItemName };
            TabControl.Items.Add(tbItem);
            //    TabControl.Items.Re
            bt.Click += (s, e) => TabControl.Items.Remove(tbItem);
            tbItem.IsSelected = true;

        }



    }
}
