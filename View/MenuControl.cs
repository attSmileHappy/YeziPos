using System;
using System.Drawing;
using System.Windows.Forms;

namespace YeziPos.Controls
{
    public partial class MenuControl : UserControl
    {
        public string MenuName
        {
            get { return lblMenuName.Text; }
            set { lblMenuName.Text = value; }
        }

        public decimal MenuPrice
        {
            get { return decimal.Parse(lblMenuPrice.Text.Replace("$", "")); }
            set { lblMenuPrice.Text = $"${value:F2}"; }
        }

        public Image MenuImage
        {
            get { return pbMenuImage.Image; }
            set { pbMenuImage.Image = value; }
        }

        public MenuControl()
        {
            InitializeComponent();
        }
    }
}
