using CodingDojo4DataLib;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_CD3.ViewModel
{
    public class StockEntryVM : ViewModelBase
    {
        private StockEntry StockEntry { get; set; }

        private string name;
        private Group category;
        private double salesPrice;
        private double purchasePrice;
        private int onStock;

        public string Name
        {
            get { return StockEntry.SoftwarePackage.Name; }
            set { StockEntry.SoftwarePackage.Name = value; RaisePropertyChanged(); }
        }        
        public Group Category
        {
            get { return StockEntry.SoftwarePackage.Category; }
            set { StockEntry.SoftwarePackage.Category = value; RaisePropertyChanged(); }
        }
        public double SalesPrice
        {
            get { return StockEntry.SoftwarePackage.SalesPrice; }
            set { StockEntry.SoftwarePackage.SalesPrice = value; RaisePropertyChanged(); }
        }
        public double PurchasePrice
        {
            get { return StockEntry.SoftwarePackage.PurchasePrice; }
            set { StockEntry.SoftwarePackage.PurchasePrice = value; RaisePropertyChanged(); }
        }
        public int OnStock
        {
            get { return StockEntry.Amount; }
            set { StockEntry.Amount = value; RaisePropertyChanged(); }
        }

        public StockEntryVM() { }

        public StockEntryVM(string name, Group category, double salesPrice, double purchasePrice, int onStock)
        {
            this.name = name;
            this.category = category;
            this.salesPrice = salesPrice;
            this.purchasePrice = purchasePrice;
            this.onStock = onStock;
        }

        public StockEntryVM(StockEntry item)
        {
            this.StockEntry = item;
        }
    }
}
