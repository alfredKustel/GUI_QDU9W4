using EDVC1J_HFT_2022232.Models;
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
using static EDVC1J_HFT_2022232.WpfClient.Restcollection;

namespace EDVC1J_HFT_2022232.WpfClient
{
    /// <summary>
    /// Interaction logic for ListReceiptWindow.xaml
    /// </summary>
    public partial class ListReceiptWindow : Window
    {
        public ListReceiptWindow(RestCollection<Receipt> items)
        {
            InitializeComponent();
            var vm = new ListViewWindowModel(items);
            vm.Setup(items);
            this.DataContext = vm;
        }
    }
}
