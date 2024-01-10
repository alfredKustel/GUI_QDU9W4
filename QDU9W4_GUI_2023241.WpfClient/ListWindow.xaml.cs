
using QDU9W4_GUI_2023241.Models;
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


namespace QDU9W4_GUI_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListWindow(List<Chef> items)
        {
            InitializeComponent();
            var vm = new ListViewWindowModel(items);
            vm.Setup(items);
            this.DataContext = vm;

        }

        
       
    }
}
