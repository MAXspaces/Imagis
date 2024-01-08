using Imagist_Library.Apis.PhotoApi;

namespace Imagist_Frontend.Controls
{
    partial class picturePreviewBox
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1=new Guna.UI2.WinForms.Guna2PictureBox();
            checkbox=new Guna.UI2.WinForms.Guna2CustomCheckBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor=Color.Transparent;
            guna2PictureBox1.CustomizableEdges=customizableEdges1;
            guna2PictureBox1.Dock=DockStyle.Fill;
            guna2PictureBox1.ImageRotate=0F;
            guna2PictureBox1.Location=new Point(0, 0);
            guna2PictureBox1.Name="guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges=customizableEdges2;
            guna2PictureBox1.Size=new Size(785, 443);
            guna2PictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex=0;
            guna2PictureBox1.TabStop=false;
            guna2PictureBox1.Click+=guna2PictureBox1_Click;
            // 
            // checkbox
            // 
            checkbox.Anchor=AnchorStyles.Top|AnchorStyles.Right;
            checkbox.Animated=true;
            checkbox.CheckedState.BorderColor=Color.FromArgb(94, 148, 255);
            checkbox.CheckedState.BorderRadius=2;
            checkbox.CheckedState.BorderThickness=0;
            checkbox.CheckedState.FillColor=Color.FromArgb(94, 148, 255);
            checkbox.CustomizableEdges=customizableEdges3;
            checkbox.Location=new Point(747, 14);
            checkbox.Name="checkbox";
            checkbox.ShadowDecoration.CustomizableEdges=customizableEdges4;
            checkbox.Size=new Size(25, 25);
            checkbox.TabIndex=3;
            checkbox.Text="guna2CustomCheckBox1";
            checkbox.UncheckedState.BorderColor=Color.FromArgb(125, 137, 149);
            checkbox.UncheckedState.BorderRadius=2;
            checkbox.UncheckedState.BorderThickness=0;
            checkbox.UncheckedState.FillColor=Color.FromArgb(125, 137, 149);
            checkbox.Visible=false;
            // 
            // picturePreviewBox
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            Controls.Add(checkbox);
            Controls.Add(guna2PictureBox1);
            Margin=new Padding(0);
            Name="picturePreviewBox";
            Size=new Size(785, 443);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public Guna.UI2.WinForms.Guna2CustomCheckBox checkbox;
        public Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
