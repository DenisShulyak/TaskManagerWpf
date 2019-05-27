using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TaskManagerWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
          public  Process[] processes = Process.GetProcesses();
        public MainWindow()
        {
            InitializeComponent();

           

            itemsDataGrid.ItemsSource = new List<Process>(processes);
            
        }

        private void removeProcessButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = itemsDataGrid.SelectedIndex;

                var processesByName = Process.GetProcessesByName(processes[index].ProcessName);
                foreach (var process in processesByName)
                {
                    process.Kill();
                }
                itemsDataGrid.ItemsSource = null;
                itemsDataGrid.ItemsSource = new List<Process>(processes);
            }
            catch
            {
                MessageBox.Show("Нельзя снять задачу с данного процесса!");
            }

        }
    }
}
