using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppEF_MVVM_promUa.DbLayer;
using WpfAppEF_MVVM_promUa.Utils;

namespace WpfAppEF_MVVM_promUa.Models
{
    class ProductViewModel : INotifyPropertyChanged, IDisposable
    {
        private PromuaDb db = new PromuaDb();
        private ObservableCollection<Product> _products;
        private bool _readOnlyProducts;
        private CustomCommand _editProduct;
        private CustomCommand _cancelEditProduct;
        public ProductViewModel()
        {
            _products = new ObservableCollection<Product>(db.Products.ToList());
            _readOnlyProducts = true;
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                if(_products != value)
                {
                    _products = value;
                    OnPropertyChanged("Products");
                }
            }
        }
        public bool ReadOnlyProducts
        {
            get { return _readOnlyProducts; }
            set
            {
                if(_readOnlyProducts != value)
                {
                    _readOnlyProducts = value;
                    OnPropertyChanged("ReadOnlyProducts");
                }
            }
        }
        public CustomCommand EditProduct
        {
            get
            {
                return _editProduct ?? (_editProduct = new CustomCommand(obj=>
                {
                    if (ReadOnlyProducts == false)
                    {
                        ReadOnlyProducts = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        ReadOnlyProducts = false;
                    }
                },                    
                obj=>
                {
                    return db.Products.Count() > 0;
                }));
            }           
        }

        public CustomCommand CancelEditProduct
        {
            get
            {
                return _cancelEditProduct ?? (_cancelEditProduct = new CustomCommand(
                obj=>
                {
                    if(db!= null)
                    {
                        db.Dispose();
                        db = new PromuaDb();
                        Products = new ObservableCollection<Product>(db.Products.ToList());
                        ReadOnlyProducts = true;
                    }
                },
                obj=>
                {
                    return !ReadOnlyProducts;
                }));
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
