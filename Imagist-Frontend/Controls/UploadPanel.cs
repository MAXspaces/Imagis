using ExCSS;
using Imagist_Library.Connectivity.Albumn;
using Imagist_Library.Connectivity.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Hosting;

namespace Imagist_Frontend.Controls
{
    public partial class UploadPanel : UserControl
    {
        public PhotoClient photoClient;
        public AlbumClient albumClient;
        public UploadPanel()
        {
            InitializeComponent();
            this.DragDrop +=UploadPanel_DragDrop;
            this.DragEnter += UploadPanel_DragEnter;
            //LoadAlbum();
        }
        public void LoadAlbum()
        {

            var response = albumClient.GetUserAlbum();
            Console.WriteLine(response.Msg);
            if (!response.IsSuccess)
                return;
            var albums = response.Data;
            AlbumComboBox.DataSource = albums;
            AlbumComboBox.ValueMember = "AlbumId";
            AlbumComboBox.DisplayMember = "AlbumName";


        }
        private async void UploadPhotos(string[] fileNames, long albumId)
        {
            foreach (var fileName in fileNames)
            {
                //校验路径
                UploadColumn statusColumn = new UploadColumn();
                statusColumn.UploadedImage.Load(fileName);
                statusColumn.FileNameLabel.Text = Path.GetFileName(fileName);
                statusColumn.StatusLabel.Text = "上传中";

                InfrmationPanel.Controls.Add(statusColumn);
                //UploadPhotoAsync(statusColumn, albumId, fileName);
                this.Invoke(new MethodInvoker(delegate { UploadPhotoAsync(statusColumn, albumId, fileName);}) );

            }
        }

        private delegate void PUploadPhotoAsync(UploadColumn statusColumn, long albumId, string fileName);
        //异步上传
        private async void UploadPhotoAsync(UploadColumn statusColumn, long albumId, string fileName)
        {
            try
            {
                var reaponse = await photoClient.UploadPhoto(albumId, fileName);
                if (reaponse.IsSuccess)
                {
                    statusColumn.StatusLabel.Text = "上传成功";
                }

            }
            catch (Exception ex)
            {
                statusColumn.StatusLabel.Text = "上传失败";
            }

        }
        

        private void UploadPanel_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;  //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        private void UploadPanel_DragDrop(object? sender, DragEventArgs e)
        {
            String[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            var albumnId = long.Parse(AlbumComboBox.SelectedValue.ToString());
            UploadPhotos(fileNames, albumnId);
        }

        private void SelectToUploadButton_Click(object sender, EventArgs e)
        {
            //打开对话框选择多个文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择上传的图片";
            dialog.Filter = PictureFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("开始上传");
                string[] fileNames = dialog.FileNames;
                var albumnId = long.Parse(AlbumComboBox.SelectedValue.ToString());
                UploadPhotos(fileNames, albumnId);
            }

        }

        #region
        private string PictureFilter =
        "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff;*.heic|"+
        "Windows Bitmap(*.bmp)|*.bmp|"+
        "Windows Icon(*.ico)|*.ico|"+
        "Graphics Interchange Format (*.gif)|(*.gif)|"+
        "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|"+
        "Portable Network Graphics (*.png)|*.png|"+
        "Tag Image File Format (*.tif)|*.tif;*.tiff";
        #endregion

    }

}
