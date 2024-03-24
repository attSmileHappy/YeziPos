using System;
using System.Windows.Forms;

namespace YeziPos
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            this.KeyPress += LoginForm_KeyPress;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("로그인 성공!");
                MainForm mainForm = new MainForm(this);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 실패. 사용자 이름 또는 비밀번호를 확인하세요.");
            }

        }
        // LoginForm 클래스에 KeyPress 이벤트 핸들러 추가
        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // 엔터 키를 누르면 로그인 버튼의 클릭 이벤트를 발생시킴
                button1.PerformClick();
            }
        }
    }
}
