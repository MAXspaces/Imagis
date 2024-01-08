namespace Imagist_Frontend.Controls
{
    partial class UploadPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadPanel));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            SelectToUploadButton=new Guna.UI2.WinForms.Guna2GradientButton();
            pictureBox1=new PictureBox();
            TopSapcePanel=new Panel();
            panel1=new Panel();
            label1=new Label();
            AlbumComboBox=new Guna.UI2.WinForms.Guna2ComboBox();
            label2=new Label();
            pictureBox2=new PictureBox();
            InfrmationPanel=new FlowLayoutPanel();
            label3=new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            TopSapcePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // SelectToUploadButton
            // 
            SelectToUploadButton.Anchor=AnchorStyles.Top;
            SelectToUploadButton.Animated=true;
            SelectToUploadButton.BorderRadius=10;
            SelectToUploadButton.CustomizableEdges=customizableEdges1;
            SelectToUploadButton.DisabledState.BorderColor=Color.DarkGray;
            SelectToUploadButton.DisabledState.CustomBorderColor=Color.DarkGray;
            SelectToUploadButton.DisabledState.FillColor=Color.FromArgb(169, 169, 169);
            SelectToUploadButton.DisabledState.FillColor2=Color.FromArgb(169, 169, 169);
            SelectToUploadButton.DisabledState.ForeColor=Color.FromArgb(141, 141, 141);
            SelectToUploadButton.FillColor=Color.FromArgb(59, 130, 246);
            SelectToUploadButton.FillColor2=Color.FromArgb(74, 222, 128);
            SelectToUploadButton.Font=new Font("苹方 中等", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point);
            SelectToUploadButton.ForeColor=Color.White;
            SelectToUploadButton.Location=new Point(291, 579);
            SelectToUploadButton.MaximumSize=new Size(400, 66);
            SelectToUploadButton.Name="SelectToUploadButton";
            SelectToUploadButton.ShadowDecoration.CustomizableEdges=customizableEdges2;
            SelectToUploadButton.Size=new Size(358, 66);
            SelectToUploadButton.TabIndex=9;
            SelectToUploadButton.Text="选择文件上传";
            SelectToUploadButton.Click+=SelectToUploadButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor=AnchorStyles.Top;
            pictureBox1.Image=(Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location=new Point(43, 449);
            pictureBox1.Margin=new Padding(3, 13, 3, 3);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(221, 196);
            pictureBox1.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex=10;
            pictureBox1.TabStop=false;
            // 
            // TopSapcePanel
            // 
            TopSapcePanel.Controls.Add(panel1);
            TopSapcePanel.Dock=DockStyle.Top;
            TopSapcePanel.Location=new Point(0, 0);
            TopSapcePanel.Name="TopSapcePanel";
            TopSapcePanel.Size=new Size(1237, 61);
            TopSapcePanel.TabIndex=11;
            // 
            // panel1
            // 
            panel1.Dock=DockStyle.Top;
            panel1.Location=new Point(0, 0);
            panel1.Name="panel1";
            panel1.Size=new Size(1237, 61);
            panel1.TabIndex=12;
            // 
            // label1
            // 
            label1.Anchor=AnchorStyles.Top;
            label1.AutoSize=true;
            label1.BackColor=Color.Transparent;
            label1.Font=new Font("苹方 常规", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor=Color.FromArgb(222, 222, 222);
            label1.Location=new Point(291, 449);
            label1.Name="label1";
            label1.Size=new Size(358, 42);
            label1.TabIndex=12;
            label1.Text="拖动照片到该页面以上传 ";
            // 
            // AlbumComboBox
            // 
            AlbumComboBox.Anchor=AnchorStyles.Top;
            AlbumComboBox.BackColor=Color.Transparent;
            AlbumComboBox.BorderRadius=10;
            AlbumComboBox.BorderThickness=0;
            AlbumComboBox.CustomizableEdges=customizableEdges3;
            AlbumComboBox.DrawMode=DrawMode.OwnerDrawFixed;
            AlbumComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            AlbumComboBox.FillColor=Color.FromArgb(50, 50, 50);
            AlbumComboBox.FocusedColor=Color.FromArgb(94, 148, 255);
            AlbumComboBox.FocusedState.BorderColor=Color.FromArgb(94, 148, 255);
            AlbumComboBox.Font=new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AlbumComboBox.ForeColor=SystemColors.ActiveBorder;
            AlbumComboBox.ItemHeight=30;
            AlbumComboBox.ItemsAppearance.BackColor=Color.FromArgb(80, 80, 80);
            AlbumComboBox.ItemsAppearance.Font=new Font("苹方 常规", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            AlbumComboBox.ItemsAppearance.ForeColor=Color.FromArgb(222, 222, 222);
            AlbumComboBox.ItemsAppearance.SelectedBackColor=Color.FromArgb(60, 60, 60);
            AlbumComboBox.Location=new Point(291, 306);
            AlbumComboBox.Name="AlbumComboBox";
            AlbumComboBox.ShadowDecoration.CustomizableEdges=customizableEdges4;
            AlbumComboBox.Size=new Size(358, 36);
            AlbumComboBox.TabIndex=13;
            // 
            // label2
            // 
            label2.Anchor=AnchorStyles.Top;
            label2.AutoSize=true;
            label2.BackColor=Color.Transparent;
            label2.Font=new Font("苹方 常规", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor=Color.FromArgb(222, 222, 222);
            label2.Location=new Point(291, 212);
            label2.Name="label2";
            label2.Size=new Size(198, 42);
            label2.TabIndex=14;
            label2.Text="上传至相册：";
            label2.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor=AnchorStyles.Top;
            pictureBox2.Image=(Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location=new Point(43, 212);
            pictureBox2.Margin=new Padding(3, 13, 3, 3);
            pictureBox2.Name="pictureBox2";
            pictureBox2.Size=new Size(221, 196);
            pictureBox2.SizeMode=PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex=15;
            pictureBox2.TabStop=false;
            // 
            // InfrmationPanel
            // 
            InfrmationPanel.Anchor=AnchorStyles.Top;
            InfrmationPanel.AutoScroll=true;
            InfrmationPanel.Location=new Point(689, 96);
            InfrmationPanel.Name="InfrmationPanel";
            InfrmationPanel.Size=new Size(535, 728);
            InfrmationPanel.TabIndex=16;
            // 
            // label3
            // 
            label3.Anchor=AnchorStyles.Top;
            label3.AutoSize=true;
            label3.BackColor=Color.Transparent;
            label3.Font=new Font("苹方 常规", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor=Color.FromArgb(222, 222, 222);
            label3.Location=new Point(441, 517);
            label3.Name="label3";
            label3.Size=new Size(48, 42);
            label3.TabIndex=17;
            label3.Text="或";
            // 
            // UploadPanel
            // 
            AllowDrop=true;
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(24, 24, 24);
            Controls.Add(label3);
            Controls.Add(InfrmationPanel);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(AlbumComboBox);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(SelectToUploadButton);
            Controls.Add(TopSapcePanel);
            Name="UploadPanel";
            Size=new Size(1237, 842);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            TopSapcePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton SelectToUploadButton;
        private PictureBox pictureBox1;
        private Panel TopSapcePanel;
        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox AlbumComboBox;
        private Label label2;
        private PictureBox pictureBox2;
        private FlowLayoutPanel InfrmationPanel;
        private Label label3;
    }
}
