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

        public RestCollection<Restaurant> Restaurants { get; set; }

        public RestCollection<Receipt> Receipts { get; set; }

        private Chef selectedChef;

        public Chef SelectedChef
        {
            get { return selectedChef; }
            set {
                SetProperty(ref selectedChef, value);
                (DeleteChefCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Restaurant selectedRestaurant;

        public Restaurant SelectedRestaurant
        {
            get { return selectedRestaurant; }
            set
            {
                SetProperty(ref selectedRestaurant, value);
                (DeleteRestaurantCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Receipt selectedReceipt;

        public Receipt SelectedReceipt
        {
            get { return selectedReceipt; }
            set
            {
                SetProperty(ref selectedReceipt, value);
                (DeleteRestaurantCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand SushiSeiChefsCommand { get; set; }
        public ICommand FreshChefsFromPinoccioCommand { get; set; }
        public ICommand HeadChefOfPeepCommand { get; set; }


        public ICommand CreateRestaurantCommand { get; set; }
        public ICommand DeleteRestaurantCommand { get; set; }
        public ICommand UpdateRestaurantCommand { get; set; }
        public ICommand UnderstaffedRestaurantCommand { get; set; }

        public ICommand CreateReceiptCommand { get; set; }
        public ICommand DeleteReceiptCommand { get; set; }
        public ICommand UpdateReceiptCommand { get; set; }
        public ICommand FrancoDeMilanReceiptsCommand { get; set; }
        public ICommand PeepReceiptsCommand { get; set; }

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

            Chefs = new RestCollection<Chef>("http://localhost:49326/", "chef");
            Restaurants = new RestCollection<Restaurant>("http://localhost:49326/", "restaurant");
            Receipts = new RestCollection<Receipt>("http://localhost:49326/", "receipt");

            if (!IsInDesignMode)
            {
                //Chefs
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



                //Restaurants
                CreateRestaurantCommand = new RelayCommand(() =>
                {
                    Restaurants.Add(new Restaurant()
                    {
                        Name = SelectedRestaurant.Name
                    });
                });


                UpdateRestaurantCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Restaurants.Update(SelectedRestaurant);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteRestaurantCommand = new RelayCommand(() =>
                {
                    Restaurants.Delete(SelectedRestaurant.ID);
                },
                () =>
                {
                    return SelectedRestaurant != null;
                });
                SelectedRestaurant = new Restaurant();

                //Receipts

                CreateReceiptCommand = new RelayCommand(() =>
                {
                    Receipts.Add(new Receipt()
                    {
                        Name = SelectedReceipt.Name
                    });
                });


                UpdateReceiptCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Receipts.Update(SelectedReceipt);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteReceiptCommand = new RelayCommand(() =>
                {
                    Receipts.Delete(SelectedReceipt.ID);
                },
                () =>
                {
                    return SelectedReceipt != null;
                });
                SelectedReceipt = new Receipt();
            }
        }
    }
}
