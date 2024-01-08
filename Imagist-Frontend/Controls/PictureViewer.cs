using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Imagist_Frontend.Controls
{
    public partial class PictureViewer : UserControl
    {
        private PhotoDto photoData;
        public PictureViewer()
        {
            //photoData = new PhotoDto();
            InitializeComponent();
            picture.LoadCompleted += (send, e) =>
            {
                // previewPicture.Visible = false;
            };
        }
        public void LoadPhoto(PhotoDto data)
        {
            //清除数据
            metaDataPanel.Controls.Clear();

            photoData = data;
            metaDataPanel.Visible = false;
            //previewPicture.Visible = true;
            //previewPicture.Load(data.ThumbnailObjectUrl);
            Type type = typeof(PhotoMetaData);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                photoInfomationColumn c = new photoInfomationColumn();

                var name = property.Name;
                var prop = property.GetValue(data.MetaData);
                if (prop is null)
                    continue;
                var value = prop.ToString();
                if (string.IsNullOrEmpty(value))
                    continue;
                c.dataLabel.Text = name;
                c.dataValue.Text =value;
                metaDataPanel.Controls.Add(c);
            }
            LoadPhoto(data.ThumbnailObjectUrl);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            picture.Image = null;
            picture.Refresh();

        }

        private async void LoadPhoto(string url)
        {
            picture.Load(url);
        }

        //显示照片信息
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            metaDataPanel.Visible = !metaDataPanel.Visible;
        }
    }
}
