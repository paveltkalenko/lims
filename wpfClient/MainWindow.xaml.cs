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
namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string APP_PATH = "http://localhost:55010";
        public MainWindow()
        {
            InitializeComponent();
            List<User> usersList = new List<User>
            {
                new User{Usrnam="test",Fullname="fullname_Test", Dept="NoDept"}
            };
            usersGrid.ItemsSource = usersList;
            ClientWebApi webApi = new ClientWebApi((x) => Console.WriteLine(x));
            var users = webApi.GetUsers();
            /*
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Usrnam}\t{u.Fullname}\t{u.Dept}");
            }
            */
            usersGrid.ItemsSource = users;
            //using (var client = new HttpClient)

        }
    }
}
