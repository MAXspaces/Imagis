using Imagist_Library.Apis.PhotoApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imagist_Frontend.Controls
{
    public partial class picturePreviewBox : UserControl
    {
        public PictureViewer pictureViewer;
        //图片元数据
        public PhotoDto PhotoData;
        //外面第一层父控件宽度
        public Size OuterControlSize { get; set; }

        public picturePreviewBox()
        {
            InitializeComponent();
        }
        public void AutoFit()
        {
            var fitWidth = this.Size.Width;
            var fitHeight = fitWidth * PhotoData.MetaData.ImageHeight / PhotoData.MetaData.ImageWidth;
            var fitSize = new Size(fitWidth, fitHeight);
            this.Size = fitSize;
            guna2PictureBox1.Size = fitSize;
        }

        public void LoadPhoto(PhotoDto photoDto)
        {
            PhotoData= photoDto;
            //调整自适应尺寸
            AutoFit();
            //pictureBox异步加载图片
            //TODO:加载小尺寸图片
            guna2PictureBox1.LoadAsync(photoDto.ThumbnailObjectUrl is null ? photoDto.Url : photoDto.ThumbnailObjectUrl);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (checkbox.Visible)
            {
                checkbox.Checked = !checkbox.Checked;
            }
            else
            {
                pictureViewer.Visible = true;
                pictureViewer.LoadPhoto(PhotoData);
                //TODO:打开照片查看
            }
        }
    }
}
