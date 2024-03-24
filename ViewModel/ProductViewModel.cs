using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeziPos.Models;

namespace YeziPos.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private List<Product> products;
        private decimal totalPrice;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductViewModel()
        {
            // 예시로 맥도날드의 6개 상품을 초기화합니다.
            Products = new List<Product>
        {
            new Product { Name = "맥크리스피 토마토", Price = 9900 },
            new Product { Name = "맥스파이시", Price = 6900 },
            new Product { Name = "더블 쿼터파운더", Price = 5900 },
            new Product { Name = "쿼터파운더", Price = 4900 },
            new Product { Name = "빅맥", Price = 7900 },
            new Product { Name = "맥크리스피 디럭스", Price = 8900 }
        };
        }

        public void CalculateTotalPrice(List<Product> selectedProducts)
        {
            TotalPrice = selectedProducts.Sum(p => p.Price);
        }
    }
}
