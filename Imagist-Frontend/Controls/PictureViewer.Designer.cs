namespace Imagist_Frontend.Controls
{
    partial class PictureViewer
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picture=new Guna.UI2.WinForms.Guna2PictureBox();
            metaDataPanel=new FlowLayoutPanel();
            closeButton=new Guna.UI2.WinForms.Guna2Button();
            guna2Button1=new Guna.UI2.WinForms.Guna2Button();
            guna2Elipse1=new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Elipse2=new Guna.UI2.WinForms.Guna2Elipse(components);
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.CustomizableEdges=customizableEdges1;
            picture.Dock=DockStyle.Fill;
            picture.ImageRotate=0F;
            picture.Location=new Point(0, 0);
            picture.Name="picture";
            picture.ShadowDecoration.CustomizableEdges=customizableEdges2;
            picture.Size=new Size(797, 819);
            picture.SizeMode=PictureBoxSizeMode.Zoom;
            picture.TabIndex=0;
            picture.TabStop=false;
            // 
            // metaDataPanel
            // 
            metaDataPanel.Dock=DockStyle.Right;
            metaDataPanel.Location=new Point(797, 0);
            metaDataPanel.Name="metaDataPanel";
            metaDataPanel.Size=new Size(369, 819);
            metaDataPanel.TabIndex=11;
            // 
            // closeButton
            // 
            closeButton.Animated=true;
            closeButton.BackColor=Color.Transparent;
            closeButton.BorderRadius=10;
            closeButton.CustomizableEdges=customizableEdges3;
            closeButton.DialogResult=DialogResult.OK;
            closeButton.DisabledState.BorderColor=Color.DarkGray;
            closeButton.DisabledState.CustomBorderColor=Color.DarkGray;
            closeButton.DisabledState.FillColor=Color.FromArgb(169, 169, 169);
            closeButton.DisabledState.ForeColor=Color.FromArgb(141, 141, 141);
            closeButton.FillColor=Color.FromArgb(30, 30, 30);
            closeButton.Font=new Font("苹方 中等", 12F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.ForeColor=Color.FromArgb(222, 222, 222);
            closeButton.HoverState.FillColor=Color.FromArgb(55, 55, 55);
            closeButton.Location=new Point(5, 7);
            closeButton.Name="closeButton";
            closeButton.ShadowDecoration.CustomizableEdges=customizableEdges4;
            closeButton.Size=new Size(58, 44);
            closeButton.TabIndex=10;
            closeButton.Text="X";
            closeButton.TextOffset=new Point(5, 0);
            closeButton.Click+=closeButton_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated=true;
            guna2Button1.BackColor=Color.Transparent;
            guna2Button1.BorderRadius=10;
            guna2Button1.CustomizableEdges=customizableEdges5;
            guna2Button1.DialogResult=DialogResult.OK;
            guna2Button1.DisabledState.BorderColor=Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor=Color.DarkGray;
            guna2Button1.DisabledState.FillColor=Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor=Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor=Color.FromArgb(30, 30, 30);
            guna2Button1.Font=new Font("苹方 中等", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor=Color.FromArgb(222, 222, 222);
            guna2Button1.HoverState.FillColor=Color.FromArgb(55, 55, 55);
            guna2Button1.Location=new Point(69, 7);
            guna2Button1.Name="guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges=customizableEdges6;
            guna2Button1.Size=new Size(58, 44);
            guna2Button1.TabIndex=12;
            guna2Button1.Text="i";
            guna2Button1.TextOffset=new Point(5, 0);
            guna2Button1.Click+=guna2Button1_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius=10;
            guna2Elipse1.TargetControl=guna2Button1;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.BorderRadius=10;
            guna2Elipse2.TargetControl=closeButton;
            // 
            // PictureViewer
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(10, 10, 10);
            Controls.Add(guna2Button1);
            Controls.Add(closeButton);
            Controls.Add(picture);
            Controls.Add(metaDataPanel);
            Name="PictureViewer";
            Size=new Size(1166, 819);
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picture;
        private Guna.UI2.WinForms.Guna2Button closeButton;
        private FlowLayoutPanel metaDataPanel;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}
