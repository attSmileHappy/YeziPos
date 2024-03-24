using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YeziPos.Controls;
using YeziPos.ViewModel;
using YeziPos.View;

namespace YeziPos
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        private ProductViewModel viewModel;
        private decimal totalPrice = 0;
        private int totalQuantity;

        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();

            this.loginForm = loginForm;

            tabControl1.TabPages[0].Text = "버거";
            tabControl1.TabPages[1].Text = "사이드&디저트";

            viewModel = new ProductViewModel();
            InitializeUI();
            this.FormClosed += MainForm_FormClosed;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close(); // MainForm이 닫힐 때 LoginForm도 함께 닫음
            Application.Exit();
        }
        private void InitializeUI()
        {
            foreach (var product in viewModel.Products)
            {
                MenuControl menuControl = new MenuControl();
                // 메뉴 정보 설정
                menuControl.MenuName = product.Name;
                menuControl.MenuPrice = product.Price;
                menuControl.MenuImage = GetMenuImage(product.Name); // 메뉴 이미지 설정

                // MenuControl 클릭 이벤트 핸들러 추가
                menuControl.Click += menuControl_Click;

                flowLayoutPanel.Controls.Add(menuControl);
            }
        }

        private void menuControl_Click(object sender, EventArgs e)
        {
            MenuControl selectedMenu = sender as MenuControl;

            // 선택된 메뉴가 없으면 리턴
            if (selectedMenu == null)
                return;

            // Vstack에 메뉴를 추가
            AddMenuToVstack(selectedMenu.MenuName, selectedMenu.MenuPrice);
        }

        private void AddMenuToVstack(string menuName, decimal menuPrice)
        {
            // 동일한 메뉴가 이미 Vstack에 있는지 확인
            bool menuAlreadyAdded = false;
            foreach (Control control in vStackPanel.Controls)
            {
                if (control is MenuStackItem menuStackItem && menuStackItem.MenuName == menuName)
                {
                    // 동일한 메뉴가 이미 추가된 경우 수량을 증가시킴
                    menuStackItem.IncreaseQuantity(); // 수량 증가 메서드 호출
                    menuAlreadyAdded = true;
                    break;
                }
            }

            // 동일한 메뉴가 추가되지 않은 경우 새로운 메뉴 아이템을 생성하여 Vstack에 추가
            if (!menuAlreadyAdded)
            {
                MenuStackItem newMenuItem = new MenuStackItem(menuName, menuPrice);
                newMenuItem.AddButtonClicked += NewMenuItem_AddButtonClicked;
                newMenuItem.RemoveButtonClicked += NewMenuItem_RemoveButtonClicked;
                vStackPanel.Controls.Add(newMenuItem);
                // 총 가격 업데이트
                totalPrice += menuPrice;
                UpdateTotalPriceLabel();
                UpdateTotalQuantity();
            }
        }
        private void UpdateTotalPriceLabel()
        {
            labelTotalPrice.Text = $"총 가격: ${totalPrice:F2}"; // 총 가격 표시
        }

        private void UpdateTotalQuantity()
        {
            totalQuantity = 0; // 총 수량 초기화
            foreach (Control control in vStackPanel.Controls)
            {
                if (control is MenuStackItem menuStackItem)
                {
                    totalQuantity += menuStackItem.Quantity; // 총 수량 계산
                }
            }
            labelTotalQuantity.Text = $"총 수량: {totalQuantity}"; // 총 수량 표시
        }
        private void NewMenuItem_AddButtonClicked(object sender, EventArgs e)
        {
            // Add 버튼 클릭 시 총 수량을 1 증가시킴
            totalQuantity++;
            // 총 수량과 총 가격 업데이트
            UpdateTotalQuantity();
            UpdateTotalPrice();
        }

        private void NewMenuItem_RemoveButtonClicked(object sender, EventArgs e)
        {
            // Remove 버튼 클릭 시 총 수량을 1 감소시킴
            totalQuantity--;
            // 총 수량과 총 가격 업데이트
            UpdateTotalQuantity();
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            totalPrice = 0; // 총 가격 초기화
            foreach (Control control in vStackPanel.Controls)
            {
                if (control is MenuStackItem menuStackItem)
                {
                    totalPrice += menuStackItem.Quantity * menuStackItem.MenuPrice; // 각 메뉴의 가격과 수량을 곱하여 총 가격 계산
                }
            }
            // 총 가격 표시 업데이트
            UpdateTotalPriceLabel();
        }

        private Image GetMenuImage(string menuName)
        {
            try
            {
                // 리소스에서 이미지 로드
                string resourceName = $"{menuName.Replace(" ", "_")}";
                Image image = (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                return image;
            }
            catch (Exception ex)
            {
                // 예외 발생 시 적절한 오류 처리를 수행합니다.
                MessageBox.Show("이미지 로드 중 오류 발생: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
