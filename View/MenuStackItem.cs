using System;
using System.Windows.Forms;

namespace YeziPos.View
{
    public partial class MenuStackItem : UserControl
    {
        public string MenuName { get; }
        public decimal MenuPrice { get; }
        public int Quantity { get; private set; }

        public event EventHandler AddButtonClicked;
        public event EventHandler RemoveButtonClicked;
        public MenuStackItem(string menuName, decimal menuPrice)
        {
            InitializeComponent();

            MenuName = menuName;
            MenuPrice = menuPrice;
            Quantity = 1;

            // Remove existing event handlers before adding new ones
            button1.Click -= button1_Click;
            button2.Click -= button2_Click;

            // Subscribe to button click events
            button1.Click += button1_Click;
            button2.Click += button2_Click;

            UpdateLabels();
        }


        private void UpdateLabels()
        {
            label1.Text = MenuName;
            label2.Text = $"{MenuPrice}";
            label3.Text = $"{Quantity}";
        }

        public void IncreaseQuantity()
        {
            Quantity += 1;
            UpdateLabels();
        }

        public void DecreaseQuantity()
        {
            if (Quantity > 0)
            {
                Quantity--;
                UpdateLabels();
                // 수량이 0이 되었을 때 해당 MenuStackItem을 부모 패널에서 삭제
                if (Quantity == 0)
                {
                    // 부모 패널에서 해당 MenuStackItem 삭제
                    var parentPanel = this.Parent;
                    if (parentPanel != null)
                    {
                        parentPanel.Controls.Remove(this);
                        Dispose(); // 메모리에서 제거
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DecreaseQuantity(); // Remove 버튼 클릭 시 수량 감소
            RemoveButtonClicked?.Invoke(this, EventArgs.Empty); // 수량 감소 후 이벤트 발생
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncreaseQuantity(); // 수량 증가
            AddButtonClicked?.Invoke(this, EventArgs.Empty); // 이벤트 발생
        }
    }
}
