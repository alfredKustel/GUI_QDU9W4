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
            set
            {
                if (value != null)
                {
                    selectedChef = new Chef()
                    {
                        Name = value.Name,
                        ID = value.ID
                    };
                    OnPropertyChanged();
                    (DeleteChefCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Restaurant selectedRestaurant;

        public Restaurant SelectedRestaurant
        {
            get { return selectedRestaurant; }
            set
            {
                if (value != null)
                {
                    selectedRestaurant = new Restaurant()
                    {
                        Name = value.Name,
                        ID = value.ID
                    };
                    OnPropertyChanged();
                    (DeleteRestaurantCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Receipt selectedReceipt;

        public Receipt SelectedReceipt
        {
            get { return selectedReceipt; }
            set
            {
                if (value != null)
                {
                    selectedReceipt = new Receipt()
                    {
                        Name = value.Name,
                        ID = value.ID
                    };
                    OnPropertyChanged();
                    (DeleteReceiptCommand as RelayCommand).NotifyCanExecuteChanged();
                }
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

        public static RestService rest;
        public MainWindowViewModel()
        {
            rest = new RestService("http://localhost:49326/", "restaurant");

            Chefs = new RestCollection<Chef>("http://localhost:49326/", "chef");
            List<Chef> SushiSeiChefs = rest.Get<Chef>("stat/SushiSeiChefs");
            List<Chef> FreshChefsFromPinoccio = rest.Get<Chef>("stat/FreshChefsFromPinoccio");
            List<Chef> HeadChefOfPeep =rest.Get<Chef>("stat/HeadChefOfPeep");

            Restaurants = new RestCollection<Restaurant>("http://localhost:49326/", "restaurant");

            Receipts = new RestCollection<Receipt>("http://localhost:49326/", "receipt");
            List<Receipt> PeepReceipts = rest.Get<Receipt>("stat/PeepReceipts");
            List<Receipt> FrancoDeMilanReceipts = rest.Get<Receipt>("stat/FrancoDeMilanReceipts");


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

                SushiSeiChefsCommand = new RelayCommand(() =>
                {
                    var vm  = new ListWindow(SushiSeiChefs);
                    vm.Show();
                });

                FreshChefsFromPinoccioCommand = new RelayCommand(() =>
                {

                    var vm = new ListWindow(FreshChefsFromPinoccio);
                    vm.Show();
                });

                HeadChefOfPeepCommand = new RelayCommand(() =>
                {

                    var vm = new ListWindow(HeadChefOfPeep);
                    vm.Show();
                });


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

                FrancoDeMilanReceiptsCommand = new RelayCommand(() =>
                {

                    var vm = new ListReceiptWindow(FrancoDeMilanReceipts);
                    vm.Show();
                });

                PeepReceiptsCommand = new RelayCommand(() =>
                {

                    var vm = new ListReceiptWindow(PeepReceipts);
                    vm.Show();
                });
            }
        }
    }
}
