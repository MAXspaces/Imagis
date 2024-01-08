using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Photo;
using static System.Net.WebRequestMethods;

namespace Imagist_Frontend.Controls
{
    partial class ImagePanel
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
            ImageColumnLayoutPanel=new TableLayoutPanel();
            ImageFlowCol3=new FlowLayoutPanel();
            ImageFlowCol2=new FlowLayoutPanel();
            ImageFlowCol4=new FlowLayoutPanel();
            ImageFlowCol1=new FlowLayoutPanel();
            guna2PictureBox1=new Guna.UI2.WinForms.Guna2PictureBox();
            OuterPanel=new Panel();
            ImageColumnLayoutPanel.SuspendLayout();
            ImageFlowCol1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            OuterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ImageColumnLayoutPanel
            // 
            ImageColumnLayoutPanel.AutoScroll=true;
            ImageColumnLayoutPanel.AutoSize=true;
            ImageColumnLayoutPanel.ColumnCount=4;
            ImageColumnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.Controls.Add(ImageFlowCol3, 0, 0);
            ImageColumnLayoutPanel.Controls.Add(ImageFlowCol2, 0, 0);
            ImageColumnLayoutPanel.Controls.Add(ImageFlowCol4, 1, 0);
            ImageColumnLayoutPanel.Controls.Add(ImageFlowCol1, 0, 0);
            ImageColumnLayoutPanel.Dock=DockStyle.Top;
            ImageColumnLayoutPanel.Location=new Point(0, 0);
            ImageColumnLayoutPanel.Name="ImageColumnLayoutPanel";
            ImageColumnLayoutPanel.RowCount=1;
            ImageColumnLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ImageColumnLayoutPanel.Size=new Size(1564, 112);
            ImageColumnLayoutPanel.TabIndex=0;
            // 
            // ImageFlowCol3
            // 
            ImageFlowCol3.AutoSize=true;
            ImageFlowCol3.Dock=DockStyle.Fill;
            ImageFlowCol3.Location=new Point(785, 3);
            ImageFlowCol3.Name="ImageFlowCol3";
            ImageFlowCol3.Size=new Size(385, 106);
            ImageFlowCol3.TabIndex=4;
            // 
            // ImageFlowCol2
            // 
            ImageFlowCol2.AutoSize=true;
            ImageFlowCol2.Dock=DockStyle.Fill;
            ImageFlowCol2.Location=new Point(394, 3);
            ImageFlowCol2.Name="ImageFlowCol2";
            ImageFlowCol2.Size=new Size(385, 106);
            ImageFlowCol2.TabIndex=3;
            // 
            // ImageFlowCol4
            // 
            ImageFlowCol4.AutoSize=true;
            ImageFlowCol4.BackColor=Color.Transparent;
            ImageFlowCol4.Dock=DockStyle.Fill;
            ImageFlowCol4.Location=new Point(1176, 3);
            ImageFlowCol4.Name="ImageFlowCol4";
            ImageFlowCol4.Size=new Size(385, 106);
            ImageFlowCol4.TabIndex=1;
            // 
            // ImageFlowCol1
            // 
            ImageFlowCol1.AutoSize=true;
            ImageFlowCol1.Controls.Add(guna2PictureBox1);
            ImageFlowCol1.Dock=DockStyle.Fill;
            ImageFlowCol1.Location=new Point(3, 3);
            ImageFlowCol1.Name="ImageFlowCol1";
            ImageFlowCol1.Size=new Size(385, 106);
            ImageFlowCol1.TabIndex=0;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges=customizableEdges1;
            guna2PictureBox1.Dock=DockStyle.Top;
            guna2PictureBox1.Image=Properties.Resources.屏幕截图_2024_01_03_105723;
            guna2PictureBox1.ImageRotate=0F;
            guna2PictureBox1.Location=new Point(3, 3);
            guna2PictureBox1.Name="guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges=customizableEdges2;
            guna2PictureBox1.Size=new Size(0, 100);
            guna2PictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex=1;
            guna2PictureBox1.TabStop=false;
            // 
            // OuterPanel
            // 
            OuterPanel.AutoScroll=true;
            OuterPanel.AutoSize=true;
            OuterPanel.Controls.Add(ImageColumnLayoutPanel);
            OuterPanel.Dock=DockStyle.Fill;
            OuterPanel.Location=new Point(0, 0);
            OuterPanel.Name="OuterPanel";
            OuterPanel.Size=new Size(1564, 803);
            OuterPanel.TabIndex=1;
            // 
            // ImagePanel
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            AutoSize=true;
            Controls.Add(OuterPanel);
            Name="ImagePanel";
            Size=new Size(1564, 803);
            ImageColumnLayoutPanel.ResumeLayout(false);
            ImageColumnLayoutPanel.PerformLayout();
            ImageFlowCol1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            OuterPanel.ResumeLayout(false);
            OuterPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel ImageColumnLayoutPanel;
        private FlowLayoutPanel ImageFlowCol1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        protected FlowLayoutPanel ImageFlowCol4;

        /// <summary>
        /// 测试代码
        /// </summary>
        public void testBlocks()
        {
            var url1 = "https://images.unsplash.com/photo-1682686580950-960d1d513532?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxfHx8ZW58MHx8fHx8";
            var photoDto1 = new PhotoDto()
            {
                Url = url1,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 600,
                    ImageHeight = 900,
                },
            };
            var url2 = "https://images.unsplash.com/photo-1702165642972-88c68edd8a62?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxNHx8fGVufDB8fHx8fA%3D%3D";
            var photoDto2 = new PhotoDto()
            {
                Url = url2,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 600,
                    ImageHeight = 902,
                },
            };
            var url3 = "https://images.unsplash.com/photo-1704256824249-093354974c62?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxNXx8fGVufDB8fHx8fA%3D%3D";
            var photoDto3 = new PhotoDto()
            {
                Url = url3,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 600,
                    ImageHeight = 450,
                },
            };
            var url4 = "https://images.unsplash.com/photo-1682685797208-c741d58c2eff?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwyN3x8fGVufDB8fHx8fA%3D%3D";
            var photoDto4 = new PhotoDto()
            {
                Url = url4,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 1124,
                    ImageHeight = 900,
                },
            };
            var url5 = "https://images.unsplash.com/photo-1704344272781-060dcbcd35cc?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw1MHx8fGVufDB8fHx8fA%3D%3D";
            var photoDto5 = new PhotoDto()
            {
                Url = url5,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 600,
                    ImageHeight = 400,
                },
            };
            var url6 = "https://images.unsplash.com/photo-1682687220363-35e4621ed990?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHw1N3x8fGVufDB8fHx8fA%3D%3D";
            var photoDto6 = new PhotoDto()
            {
                Url = url6,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 900,
                    ImageHeight = 1124,
                },
            };
            var url7 = "https://images.unsplash.com/photo-1656778669500-7afe7f78c3d0?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw4N3x8fGVufDB8fHx8fA%3D%3D";
            var photoDto7 = new PhotoDto()
            {
                Url = url7,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 597,
                    ImageHeight = 896,
                },
            };
            var url8 = "https://images.unsplash.com/photo-1703958514300-5510d6eb3c2d?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5Mnx8fGVufDB8fHx8fA%3D%3D";
            var photoDto8 = new PhotoDto()
            {
                Url = url8,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 600,
                    ImageHeight = 800,
                },
            };
            var url9 = "https://plus.unsplash.com/premium_photo-1703775439859-02ac42d6e322?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5M3x8fGVufDB8fHx8fA%3D%3D";
            var photoDto9 = new PhotoDto()
            {
                Url = url9,
                MetaData = new PhotoMetaData()
                {
                    ImageWidth = 597,
                    ImageHeight = 896,
                },
            };
            var pad = new Padding(6, 6, 6, 6);
            var pictureList = new List<PhotoDto>()
            {
                photoDto1, photoDto2, photoDto3, photoDto4, photoDto5, photoDto6, photoDto7, photoDto8, photoDto9
            };
            AddPhotos(pictureList);
            // var picturePreviewBox1 = new picturePreviewBox();
            // picturePreviewBox1.Margin = pad;
            // picturePreviewBox1.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox1.LoadPhoto(photoDto1);
            // picturePreviewBox1.Dock = DockStyle.Top;
            // ImageFlowCol1.Controls.Add(picturePreviewBox1);
            //
            // var picturePreviewBox2 = new picturePreviewBox();
            // picturePreviewBox2.Margin = pad;
            // picturePreviewBox2.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox2.LoadPhoto(photoDto2);
            // picturePreviewBox2.Dock = DockStyle.Top;
            // ImageFlowCol1.Controls.Add(picturePreviewBox2);
            //
            // var picturePreviewBox3 = new picturePreviewBox();
            // picturePreviewBox3.Margin = pad;
            // picturePreviewBox3.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox3.LoadPhoto(photoDto3);
            // picturePreviewBox3.Dock = DockStyle.Top;
            // ImageFlowCol2.Controls.Add(picturePreviewBox3);
            //
            // var picturePreviewBox4 = new picturePreviewBox();
            // picturePreviewBox4.Margin = pad;
            // picturePreviewBox4.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox4.LoadPhoto(photoDto4);
            // picturePreviewBox4.Dock = DockStyle.Top;
            // ImageFlowCol2.Controls.Add(picturePreviewBox4);
            //
            // var picturePreviewBox5 = new picturePreviewBox();
            // picturePreviewBox5.Margin = pad;
            // picturePreviewBox5.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox5.LoadPhoto(photoDto5);
            // picturePreviewBox5.Dock = DockStyle.Top;
            // ImageFlowCol2.Controls.Add(picturePreviewBox5);
            //
            // var picturePreviewBox6 = new picturePreviewBox();
            // picturePreviewBox6.Margin = pad;
            // picturePreviewBox6.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox6.LoadPhoto(photoDto6);
            // picturePreviewBox6.Dock = DockStyle.Top;
            // ImageFlowCol3.Controls.Add(picturePreviewBox6);
            //
            // var picturePreviewBox7 = new picturePreviewBox();
            // picturePreviewBox7.Margin = pad;
            // picturePreviewBox7.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox7.LoadPhoto(photoDto7);
            // picturePreviewBox7.Dock = DockStyle.Top;
            // ImageFlowCol3.Controls.Add(picturePreviewBox7);
            //
            // var picturePreviewBox8 = new picturePreviewBox();
            // picturePreviewBox8.Margin = pad;
            // picturePreviewBox8.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox8.LoadPhoto(photoDto8);
            // picturePreviewBox8.Dock = DockStyle.Top;
            // ImageFlowCol3.Controls.Add(picturePreviewBox8);
            //
            // var picturePreviewBox9 = new picturePreviewBox();
            // picturePreviewBox9.Margin = pad;
            // picturePreviewBox9.OuterControlSize = ImageFlowCol1.Size;
            // picturePreviewBox9.LoadPhoto(photoDto9);
            // picturePreviewBox8.Dock = DockStyle.Top;
            // ImageFlowCol2.Controls.Add(picturePreviewBox9);
        }

        private Panel OuterPanel;
        protected FlowLayoutPanel ImageFlowCol2;
        protected FlowLayoutPanel ImageFlowCol3;
    }
}
