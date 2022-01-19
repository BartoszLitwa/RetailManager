using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Models
{
    public class CartItemModel : PropertyChangedBase
    {
        public ProductModel Product { get; set; }
        private int _quantityInCart;

        public int QuantityInCart
        {
            get => _quantityInCart;
            set
            {
                _quantityInCart = value;
                NotifyOfPropertyChange(() => QuantityInCart);
                NotifyOfPropertyChange(() => DisplayText);
            }
        }

        public string DisplayText => $"{QuantityInCart} - {Product.ProductName}";
    }
}
