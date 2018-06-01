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
using ClientAppLibrary;
using Application.Services.ViewModels;
using Domain.Model.Entities;
using System.Diagnostics;
namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        private User user;
        private ClientWebApi webApi;
        public UsersWindow()
        {
            InitializeComponent();
            webApi = new ClientWebApi((x) => Debug.WriteLine(x));

            
        }

        private void usersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListOfUsers u = ((sender as DataGrid).SelectedItem as ListOfUsers);
            Task<User> t1;
            t1 = webApi.GetUserAsync(u.Usrnam);
            using (LoadWindow lw = new LoadWindow(t1))
            {
                lw.Owner = this;
                lw.ShowDialog();
            }
            user = t1.GetAwaiter().GetResult();
            gridUserDescription.DataContext = user;
            //tbJobDescription.Text = user.JobDescription;
        }

        private void tbJobDescription_TargetUpdated(object sender, DataTransferEventArgs e)
        {
           // MessageBox.Show("tbJobDescription_TargetUpdated");
        }

        private void tbJobDescription_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            //при изменении текст бокса
            // MessageBox.Show(" tbJobDescription_SourceUpdated");
            /*
            Debug.WriteLine("job_sourceUpdated" + user.JobDescription);
            Debug.WriteLine("--"+e.OriginalSource);
            Debug.WriteLine("--" + e.Source);
            Debug.WriteLine("--" + e.TargetObject);
            */
        }

        private void gridUserDescription_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Task t1;
            t1 = webApi.UpdateUserAsync(user);
            using (LoadWindow lw = new LoadWindow(t1))
            {
                lw.Owner = this;
                lw.ShowDialog();
            }
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<ListOfUsers>> t = webApi.GetUsersAsync();
            using (LoadWindow lw = new LoadWindow(t))
            {
                lw.Owner = this;
                lw.ShowDialog();
            }
            var users = t.GetAwaiter().GetResult();
            usersGrid.ItemsSource = users;

        }
    }
}
