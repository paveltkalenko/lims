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
using Domain.Model.Entities;
using ClientAppLibrary;
using Application.Services.ViewModels;
using System.Diagnostics;
namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            webApi = new ClientWebApi((x) => Debug.WriteLine(x));
        }

        private User user;
        private ClientWebApi webApi;


        private void usersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DataGrid).SelectedIndex == -1) return;
            ListOfUsers u = ((sender as DataGrid).SelectedItem as ListOfUsers);
            Task<User> t1;
            t1 = webApi.GetUserAsync(u.Usrnam);
            using (LoadWindow lw = new LoadWindow(t1))
            {
                lw.Owner = Window.GetWindow(this);
                lw.ShowDialog();
            }
            user = t1.GetAwaiter().GetResult();
            gridUserDescription.DataContext = user;
        }

        private void tbJobDescription_TargetUpdated(object sender, DataTransferEventArgs e)
        {
        }

        private void tbJobDescription_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void gridUserDescription_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Task t1;
            t1 = webApi.UpdateUserAsync(user);
            using (LoadWindow lw = new LoadWindow(t1))
            {
                lw.Owner = Window.GetWindow(this);
                lw.ShowDialog();
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<ListOfUsers>> t = webApi.GetUsersAsync();
            using (LoadWindow lw = new LoadWindow(t))
            {
                lw.Owner = Window.GetWindow(this);
                lw.ShowDialog();
            }
            var users = t.GetAwaiter().GetResult();
            usersGrid.ItemsSource = users;
            
         //   MessageBox.Show("Load");
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        //    MessageBox.Show("UnLoad");
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserCreate uc = new UserCreate();
            uc.ShowDialog();
           
        }
    }
}
