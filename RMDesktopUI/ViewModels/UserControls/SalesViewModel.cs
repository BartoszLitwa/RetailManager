using Caliburn.Micro;
using System.ComponentModel;

namespace RMDesktopUI.ViewModels.UserControls
{
    public class SalesViewModel : Screen
    {
        #region BindingList
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        #endregion

        private int _itemQuantity;

        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        #region Calculations
        public string SubTotal
        {
            get
            {
                // TODO - Replace with calculation
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                // TODO - Replace with calculation
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                // TODO - Replace with calculation
                return "$0.00";
            }
        } 
        #endregion

        #region Buttons
        public bool CanAddToCart
        {
            get
            {
                // Make sure there is an item

                return true;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromoCart
        {
            get
            {
                // Make sure something is selected

                return true;
            }
        }

        public void RemoveFromoCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                // Make sure something is in cart

                return true;
            }
        }

        public void CheckOut()
        {

        } 
        #endregion
    }
}
