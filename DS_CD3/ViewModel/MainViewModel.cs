using CodingDojo4DataLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DS_CD3.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public SampleManager manager = new SampleManager();

        public ObservableCollection<StockEntryVM> items = new ObservableCollection<StockEntryVM>();
        public ObservableCollection<StockEntryVM> filteredItems = new ObservableCollection<StockEntryVM>();
        public StockEntryVM selectedItem;
        /* //Currency Conversion
        public List<string> currencies = new List<string>();
        public string selectedCurrency;
        */
        public string filter = "allValues";
        public RelayCommand BtnDeleteClicked { get; set; }
        public RelayCommand BtnFilterClicked { get; set; }

        public ObservableCollection<StockEntryVM> Items
        {
            get { return items; }
            set { items = value; }
        }     

        public ObservableCollection<StockEntryVM> FilteredItems
        {
            get { return filteredItems; }
            set { filteredItems = value; RaisePropertyChanged(); }
        }

        public StockEntryVM SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        /*
        public List<string> Currencies
        {
            get { return currencies; }
            set { currencies = value; RaisePropertyChanged(); }
        }

        public string SelectedCurrency
        {
            get { return selectedCurrency; }
            set { selectedCurrency = value; RaisePropertyChanged(); }
        }
        */

        public string Filter
        {
            get { return filter; }
            set { filter = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            LoadData();
            filter = "allValues"; //Set default filter
            FilterData();
            /*
            currencies.Add("EUR");
            currencies.Add("USD");
            currencies.Add("GBP");
            */

            BtnDeleteClicked = new RelayCommand(() => items.Remove(selectedItem), () => { return selectedItem != null; });
            BtnFilterClicked = new RelayCommand(FilterData);
        }

        private void LoadData()
        {
            foreach (var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryVM(item)); 
            }
        }

        private void FilterData()
        {
            FilteredItems.Clear();
            foreach (var item in Items)
            {
                if (item.Name.Contains(filter) || filter.Equals("allValues"))
                {
                    FilteredItems.Add(item);
                }
            }
        }
    }
}