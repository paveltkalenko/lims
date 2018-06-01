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

namespace wpfClient
{
    /// <summary>
    /// Логика взаимодействия для LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window, IDisposable
    {
        public Action worker { get; set; }
        public Task task { get; set; }
        public LoadWindow(Action worker)
        {
            InitializeComponent();
            this.worker = worker ?? throw new ArgumentNullException();
            task = Task.Factory.StartNew(worker);
        }
        public LoadWindow(Task task)
        {
            InitializeComponent();
            this.task = task ?? throw new ArgumentNullException();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          task.ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
