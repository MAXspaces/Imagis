namespace Imagist_Frontend.Controls
{
    partial class UploadColumn
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components=new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            UploadedImage=new Guna.UI2.WinForms.Guna2PictureBox();
            FileNameLabel=new Label();
            StatusLabel=new Label();
            guna2Elipse1=new Guna.UI2.WinForms.Guna2Elipse(components);
            ((System.ComponentModel.ISupportInitialize)UploadedImage).BeginInit();
            SuspendLayout();
            // 
            // UploadedImage
            // 
            UploadedImage.Anchor=AnchorStyles.Top;
            UploadedImage.BorderRadius=10;
            UploadedImage.CustomizableEdges=customizableEdges1;
            UploadedImage.ImageRotate=0F;
            UploadedImage.Location=new Point(15, 6);
            UploadedImage.Name="UploadedImage";
            UploadedImage.ShadowDecoration.CustomizableEdges=customizableEdges2;
            UploadedImage.Size=new Size(59, 43);
            UploadedImage.SizeMode=PictureBoxSizeMode.Zoom;
            UploadedImage.TabIndex=0;
            UploadedImage.TabStop=false;
            // 
            // FileNameLabel
            // 
            FileNameLabel.Anchor=AnchorStyles.Top;
            FileNameLabel.AutoSize=true;
            FileNameLabel.BackColor=Color.Transparent;
            FileNameLabel.Font=new Font("苹方 常规", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FileNameLabel.ForeColor=Color.FromArgb(222, 222, 222);
            FileNameLabel.Location=new Point(98, 14);
            FileNameLabel.MaximumSize=new Size(140, 28);
            FileNameLabel.Name="FileNameLabel";
            FileNameLabel.Size=new Size(121, 28);
            FileNameLabel.TabIndex=15;
            FileNameLabel.Text="ImageName";
            FileNameLabel.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor=AnchorStyles.Top;
            StatusLabel.AutoSize=true;
            StatusLabel.BackColor=Color.Transparent;
            StatusLabel.Font=new Font("苹方 常规", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StatusLabel.ForeColor=Color.FromArgb(222, 222, 222);
            StatusLabel.Location=new Point(255, 16);
            StatusLabel.Name="StatusLabel";
            StatusLabel.Size=new Size(105, 28);
            StatusLabel.TabIndex=16;
            StatusLabel.Text="Uploading";
            StatusLabel.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius=10;
            guna2Elipse1.TargetControl=this;
            // 
            // UploadColumn
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(60, 60, 60);
            Controls.Add(StatusLabel);
            Controls.Add(FileNameLabel);
            Controls.Add(UploadedImage);
            Name="UploadColumn";
            Size=new Size(476, 67);
            ((System.ComponentModel.ISupportInitialize)UploadedImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Guna.UI2.WinForms.Guna2PictureBox UploadedImage;
        public Label FileNameLabel;
        public Label StatusLabel;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
