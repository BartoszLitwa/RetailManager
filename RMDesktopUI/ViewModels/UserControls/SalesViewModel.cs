using Caliburn.Micro;
using RMDesktopUI.Library.Api.Interface;
using RMDesktopUI.Library.Helpers;
using RMDesktopUI.Library.Models;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels.UserControls
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndpoint;
        private IConfigHelper _configHelper;
        private double taxRate;

        public SalesViewModel(IProductEndpoint productEndpoint, IConfigHelper configHelper)
        {
            _productEndpoint = productEndpoint;
            _configHelper = configHelper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProductsAndCartAsync();
        }

        public async Task LoadProductsAndCartAsync()
        {
            var productList = await _productEndpoint.GetAllAsync();
            Products = new BindingList<ProductModel>(productList);

            Cart = new BindingList<CartItemModel>();

            taxRate = _configHelper.GetTaxRate();
        }

        #region BindingList
        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<CartItemModel> _cart;

        public BindingList<CartItemModel> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        #endregion

        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private ProductModel productModel;

        public ProductModel SelectedProduct
        {
            get => productModel;
            set
            {
                productModel = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        #region Calculations
        public string SubTotal
        {
            get
            {
                NotifyOfPropertyChange(() => Tax);
                NotifyOfPropertyChange(() => Total);
                return CalculateSubTotal().ToString("C");
            }
        }

        private double CalculateSubTotal()
        {
            double subTotal = 0;

            subTotal = Cart
                .Sum(x => x.Product.RetailPrice * x.QuantityInCart);

            return subTotal;
        }

        private double CalculateTax()
        {
            double taxAmount = 0;

            taxAmount = Cart
                .Where(x => x.Product.TaxId != 0)
                .Sum(x => x.Product.RetailPrice * x.QuantityInCart * (taxRate / 100));

            return taxAmount;
        }

        public string Tax => CalculateTax().ToString("C");

        public string Total => (CalculateSubTotal() + CalculateTax()).ToString("C");
        #endregion

        #region Buttons
        public bool CanAddToCart => ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity;

        public void AddToCart()
        {
            if (Cart.FirstOrDefault(x => x.Product == SelectedProduct) is CartItemModel item)
            {
                item.QuantityInCart += ItemQuantity;
            }
            else
            {
                item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };

                Cart.Add(item);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;

            NotifyOfPropertyChange(() => SubTotal);
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
            NotifyOfPropertyChange(() => SubTotal);
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
