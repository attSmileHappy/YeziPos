namespace YeziPos.Controls
{
    partial class MenuControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMenuName = new System.Windows.Forms.Label();
            this.lblMenuPrice = new System.Windows.Forms.Label();
            this.pbMenuImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuName.Location = new System.Drawing.Point(3, 114);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(44, 12);
            this.lblMenuName.TabIndex = 0;
            this.lblMenuName.Text = "label1";
            // 
            // lblMenuPrice
            // 
            this.lblMenuPrice.AutoSize = true;
            this.lblMenuPrice.Location = new System.Drawing.Point(3, 138);
            this.lblMenuPrice.Name = "lblMenuPrice";
            this.lblMenuPrice.Size = new System.Drawing.Size(38, 12);
            this.lblMenuPrice.TabIndex = 1;
            this.lblMenuPrice.Text = "label1";
            // 
            // pbMenuImage
            // 
            this.pbMenuImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbMenuImage.Location = new System.Drawing.Point(0, 0);
            this.pbMenuImage.Name = "pbMenuImage";
            this.pbMenuImage.Size = new System.Drawing.Size(150, 111);
            this.pbMenuImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuImage.TabIndex = 2;
            this.pbMenuImage.TabStop = false;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.pbMenuImage);
            this.Controls.Add(this.lblMenuPrice);
            this.Controls.Add(this.lblMenuName);
            this.Name = "MenuControl";
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.Label lblMenuPrice;
        private System.Windows.Forms.PictureBox pbMenuImage;
    }
}
