using EDVC1J_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public ICommand CreateChefCommand { get; set; }
        public ICommand DeleteChefCommand { get; set; }
        public ICommand UpdateChefCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {

            Chefs = new RestCollection<Chef>("http://localhost:49326", "chef");

            if (!IsInDesignMode)
            {
                CreateChefCommand = new RelayCommand(() =>
                {
                    Chefs.Add(new Chef()
                    {
                        Name = SelectedChef.Name
                    });
                });


                UpdateChefCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Chefs.Update(SelectedChef);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteChefCommand = new RelayCommand(() =>
                {
                    Chefs.Delete(SelectedChef.ID);
                },
                () =>
                {
                    return SelectedChef != null;
                });
                SelectedChef = new Chef();

            }
        }
    }
}
