using EDVC1J_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static EDVC1J_HFT_2022232.WpfClient.Restcollection;

namespace EDVC1J_HFT_2022232.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Chef> Chefs { get; set; }

        private Chef selectedChef;

        public Chef SelectedChef
        {
            get { return selectedChef; }
            set {
                SetProperty(ref selectedChef, value);
                (DeleteChefCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateChefCommand { get; set; }
        public ICommand DeleteChefCommand { get; set; }
        public ICommand UpdateChefCommand { get; set; }

        public MainWindowViewModel()
        {
            Chefs = new RestCollection<Chef>("http://localhost:49326", "chef");

            CreateChefCommand = new RelayCommand(() =>
           {
               Chefs.Add(new Chef()
               {
                   Name = "ASDASD"
               });
           });
            DeleteChefCommand = new RelayCommand(() =>
            {
                Chefs.Delete(SelectedChef.ID);
            },
            () =>
            {
                return SelectedChef != null;
            });

        }
    }
}
