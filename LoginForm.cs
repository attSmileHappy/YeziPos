using System;
using System.Windows.Forms;

namespace YeziPos
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // 여기에 실제 로그인 처리를 구현하십시오.
            // 예를 들어, 사용자 이름과 비밀번호를 데이터베이스와 비교하여 인증합니다.
            // 임시로 'admin'/'password'를 사용하여 로그인하도록 하겠습니다.
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("로그인 성공!");
                // 로그인에 성공했을 때 다음 작업을 수행하도록 처리합니다.
                // 예를 들어, 메인 POS 창을 열거나 필요한 기능을 수행합니다.
                // 이 예제에서는 로그인 창을 숨기고 메인 POS 폼을 엽니다.
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); // 현재 로그인 폼을 숨깁니다.
            }
            else
            {
                MessageBox.Show("로그인 실패. 사용자 이름 또는 비밀번호를 확인하세요.");
            }
        }

      
    }
}
