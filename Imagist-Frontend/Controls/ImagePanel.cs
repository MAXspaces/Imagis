using Guna.UI2.WinForms;
using Imagist_Library.Apis.AlbumApi;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Connectivity.Albumn;
using System.Windows.Forms;

namespace Imagist_Frontend.Controls
{
    public partial class ImagePanel : UserControl
    {
        private List<FlowLayoutPanel> ImageFlowCols;
        private List<PhotoDto> photos;
        public PictureViewer PictureViewer;
        public List<picturePreviewBox> pictureBoxes { get; set; }

        //outerComponent外部组件

        public ImagePanel()
        {
            InitializeComponent();
            ImageFlowCols = new List<FlowLayoutPanel>() { ImageFlowCol1, ImageFlowCol2, ImageFlowCol3, ImageFlowCol4 };
            pictureBoxes = new List<picturePreviewBox>();
            photos = new List<PhotoDto>();
            testBlocks();
        }

        public void ImagePanel_Resize()
        {
            foreach (var imageFlowCol in ImageFlowCols)
            {
                foreach (var item in imageFlowCol.Controls)
                {
                    if (item is picturePreviewBox control)
                    {
                        control.Size = new Size(ImageFlowCol1.Size.Width, 0);
                        control.AutoFit();
                    }
                }
            }
        }

        //重置相册
        public void ClearAllPhotos()
        {
            photos.Clear();
            pictureBoxes.Clear();
            foreach (var imageFlowCol in ImageFlowCols)
            {
                imageFlowCol.Controls.Clear();
            }
        }
        //相册添加照片
        public async void AddPhotos(List<PhotoDto> newPhotos)
        {
            var padding = new Padding(6, 6, 6, 6);
            var i = 0;
            foreach (var photo in newPhotos)
            {
                var column = ImageFlowCols[i++];
                i %= ImageFlowCols.Count;
                var pictureBox = new picturePreviewBox();

                pictureBox.Margin = padding;
                pictureBox.OuterControlSize = ImageFlowCol1.Size;
                pictureBox.LoadPhoto(photo);
                pictureBox.Dock = DockStyle.Top;

                //添加照片查看器引用用于打开照片
                pictureBox.pictureViewer = PictureViewer;
                column.Controls.Add(pictureBox);
                column.SetFlowBreak(pictureBox, true);

                pictureBoxes.Add(pictureBox);
            }
            ImagePanel_Resize();
            //从长度最短的column中添加，确保长度均衡

        }

    }
}
