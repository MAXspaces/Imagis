using Guna.UI2.WinForms;
using Imagist_Library.Apis.AlbumApi;
using System.Text.Json;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Connectivity.Albumn;
using Imagist_Library.Connectivity.Photo;
using Flurl.Http;
using Imagist_Frontend.Controls;
using Imagist_Library.Connectivity.Account;

namespace Imagist_Frontend.Froms
{
    public partial class MainForm : Form
    {
        //connectivity 客户端连接服务
        private AlbumClient albumClient;
        private PhotoClient PhotoClient;
        private readonly AuthenticationManager _authentication;

        //self attribute自身属性
        private Guna2Button selectedButton;

        //control控件
        private Guna2Button AddAlbumButton;

        //private List<AlbumDto> albums;
        private AlbumDto nowSelectedAlbum;
        private Guna2Button nowSelectdAlbumButton;
        private List<Guna2Button> albumsButtons;
        private bool albumnListOpen;

        public MainForm(AlbumClient albumClient, PhotoClient photoClient, AuthenticationManager authentication)
        {
            //连接服务依赖注入
            this.albumClient = albumClient;
            this.PhotoClient = photoClient;
            _authentication = authentication;

            //组件初始化
            InitializeComponent();
            HideOptionButtonPanel();
            ClosePhotoSelect();
            pictureViewer.Visible =false;
            imagePanel.PictureViewer = pictureViewer;
            uploadpanel.photoClient = photoClient;
            uploadpanel.albumClient = albumClient;

            //uploadComponnet

            ResizeEnd += MainForm_ResizeEnd;

            UploadButton.CheckedChanged +=UploadButton_CheckedChanged;
            TrashButton.CheckedChanged +=TrashButton_CheckedChanged;

            //组件数据加载
            //InitialDataLoading();

        }

        public void InitialDataLoading()
        {
            LoadAlbumn();
            AllPhotoButton.Checked =true;
            selectedButton = AllPhotoButton;
            LoadAllPhotos();
            //加载用户信息
            UserNameTextBox.Text = _authentication.Username;
            if (_authentication.userProfile is not null)
                UserProfilePictureBox.Load(_authentication.userProfile);
        }


        private void MainForm_ResizeEnd(object? sender, EventArgs e)
        {
            imagePanel.ImagePanel_Resize();
        }

        private void SideBarButtonClicked(object sender, EventArgs e)
        {
            //sideBar控制逻辑
            if (selectedButton == sender)
                return;
            selectedButton.Checked = false;
            selectedButton = sender as Guna2Button;
            (sender as Guna2Button).Checked = true;
        }

        private void AllPhotoButton_Click(object sender, EventArgs e)
        {
            //sideBar控制逻辑
            SideBarButtonClicked(sender, e);
            //状态栏控制
            HideOptionButtonPanel();
            SetTitleText("全部照片", "您当前上传的所有照片");

            //MainViewPanel.Visible = true;

            LoadAllPhotos();
        }
        private void UploadButton_Click(object sender, EventArgs e)
        {
            SideBarButtonClicked(sender, e);
            HideOptionButtonPanel();
        }

        private void UploadButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (UploadButton.Checked)
            {
                MainViewPanel.Visible = false;
                uploadpanel.Visible = true;
                uploadpanel.LoadAlbum();
            }
            else
            {
                MainViewPanel.Visible = true;
                uploadpanel.Visible = false;
            }
        }

        private void TrashButton_Click(object sender, EventArgs e)
        {
            SideBarButtonClicked(sender, e);
            HideOptionButtonPanel();
        }
        private void TrashButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (TrashButton.Checked)
            {
                LoadDeletedPhoto();
                TitleTextBox.Text = "照片回收站";
                DescriptionTextbox.Text = "展示您最近删除的照片";
            }
            else
            {
                TrashPageClosePhotoSelect();
            }
        }
        //加载被删除的照片
        private void LoadDeletedPhoto()
        {
            imagePanel.ClearAllPhotos();
            imagePanel.AddPhotos(PhotoClient.GetDeletedPhotos().Data ?? new List<PhotoDto>());
        }

        private void AlbumButton_Click(object sender, EventArgs e)
        {
            if (!albumnListOpen)
                foreach (var button in albumsButtons)
                {
                    button.Visible = true;
                    button.Enabled = true;

                    AddAlbumButton.Visible = true;
                    AddAlbumButton.Enabled = true;
                }
            else
                foreach (var button in albumsButtons)
                {
                    button.Visible = false;
                    button.Enabled = false;

                    AddAlbumButton.Visible = false;
                    AddAlbumButton.Enabled = false;
                }
            albumnListOpen = !albumnListOpen;
        }

        private async void SelectAlbum(AlbumDto album)
        {
            nowSelectedAlbum = album;
            //重新加载照片
            var response = albumClient.GetAlbumPhotos(album.AlbumId);
            //TODO判断是否成功
            imagePanel.ClearAllPhotos();
            imagePanel.AddPhotos(response.Data??new List<PhotoDto>());

        }
        private async void LoadAllPhotos()
        {
            var response = PhotoClient.GetAllPhotos();
            //TODO判断是否成功
            imagePanel.ClearAllPhotos();
            imagePanel.AddPhotos(response.Data??new List<PhotoDto>());

        }

        //加载相册
        private void LoadAlbumn()
        {
            albumnListOpen = false;
            albumsButtons = new List<Guna2Button>();

            var getAlbumResponse = albumClient.GetUserAlbum();
            Console.WriteLine(JsonSerializer.Serialize(getAlbumResponse));
            var albums = getAlbumResponse.Data;

            //新增相册按钮
            AddAlbumButton = GetAlbumnButton("新建相册");
            AddAlbumButton.Visible = false;
            AddAlbumButton.Enabled = false;
            AddAlbumButton.Dock = DockStyle.Top;
            AddAlbumButton.HoverState.FillColor = Color.FromArgb(255, 34, 197, 34);
            AddAlbumButton.HoverState.ForeColor = Color.FromArgb(255, 222, 222, 222);
            AddAlbumButton.Location = new Point(AlbumButton.Location.X, AlbumButton.Location.Y + 50);
            AddAlbumButton.Click +=AddAlbumButton_Click;
            AlbumPanel.Controls.Add(AddAlbumButton);
            var i = 0;
            for (i = 0; i < albums.Count; i++)
            {
                var ab = GetAlbumnButton(albums[i].AlbumName);
                ab.Dock = DockStyle.Top;
                //初始化时album不可见
                ab.Visible = false;
                ab.Enabled = false;
                //使用button的tag记录albumn信息
                ab.Tag = albums[i];
                //ab.button事件
                ab.Click +=(sender, e) =>
                {
                    SideBarButtonClicked(sender, e);

                    //选择按钮代表的album
                    SelectAlbum((AlbumDto)ab.Tag);
                    nowSelectdAlbumButton = (Guna2Button)sender;

                    //状态栏设置
                    ShowOptionButtonPanel();
                    SetTitleText(((AlbumDto)ab.Tag).AlbumName, ((AlbumDto)ab.Tag).AlbumDescription);
                };
                AlbumPanel.Controls.Add(ab);
                albumsButtons.Add(ab);
            }
        }

        //创建新的相册
        private void AddAlbumButton_Click(object? sender, EventArgs e)
        {
            //直接新建一个默认参数的相册让用户自己设定参数
            var newAlbumn = new AlbumDto()
            {
                AlbumName = "新的相册",
                AlbumDescription = "这是一个全新的相册"
            };
            var request = new CreateAlbumRequest()
            {
                AlbumName = newAlbumn.AlbumName,
                AlbumDescription = newAlbumn.AlbumDescription,
            };

            var response = albumClient.CreateAlbum(request);
            if (!response.IsSuccess)
            {
                //TODO:异常处理
                return;
            }
            newAlbumn.AlbumId = response.Data;

            var ab = GetAlbumnButton(newAlbumn.AlbumName);
            ab.Location = new Point(AlbumButton.Location.X, AlbumButton.Location.Y + 50 * (albumsButtons.Count + 2));

            ab.Visible = true;
            ab.Enabled = true;
            //使用button的tag记录albumn信息
            ab.Tag = newAlbumn;
            //ab.button事件
            ab.Click +=(sender, e) =>
            {
                SideBarButtonClicked(sender, e);

                //选择按钮代表的album
                SelectAlbum((AlbumDto)ab.Tag);
                nowSelectdAlbumButton = (Guna2Button)sender;

                //状态栏设置
                ShowOptionButtonPanel();
                SetTitleText(((AlbumDto)ab.Tag).AlbumName, ((AlbumDto)ab.Tag).AlbumDescription);
            };
            albumsButtons.Add(ab);
            AlbumPanel.Controls.Add(ab);
        }

        private Guna2Button GetAlbumnButton(string text)
        {

            //get button settings
            #region 获取按钮设置
            Guna2Button selectAlbumnButton = new Guna2Button();
            selectAlbumnButton.Animated = AlbumButton.Animated;
            selectAlbumnButton.FillColor = AlbumButton.FillColor;
            selectAlbumnButton.BorderRadius = AlbumButton.BorderRadius;
            selectAlbumnButton.CustomizableEdges = AlbumButton.CustomizableEdges;
            selectAlbumnButton.DialogResult = AlbumButton.DialogResult;
            selectAlbumnButton.DisabledState.BorderColor = AlbumButton.DisabledState.BorderColor;
            selectAlbumnButton.DisabledState.CustomBorderColor = AlbumButton.DisabledState.CustomBorderColor;
            selectAlbumnButton.DisabledState.FillColor = AlbumButton.DisabledState.FillColor;
            selectAlbumnButton.DisabledState.ForeColor = AlbumButton.DisabledState.ForeColor;
            selectAlbumnButton.Font = AlbumButton.Font;
            selectAlbumnButton.ForeColor = AlbumButton.DisabledState.ForeColor;
            selectAlbumnButton.HoverState.FillColor = AlbumButton.HoverState.FillColor;
            selectAlbumnButton.ShadowDecoration = AlbumButton.ShadowDecoration;
            selectAlbumnButton.Size = AlbumButton.Size;
            selectAlbumnButton.TabIndex = AlbumButton.TabIndex;
            selectAlbumnButton.Location  =AlbumButton.Location;
            selectAlbumnButton.BackColor = AlbumButton.BackColor;

            selectAlbumnButton.TextAlign =  AlbumButton.TextAlign;
            selectAlbumnButton.TextOffset = new Point(AlbumButton.TextOffset.X+10, 0);
            #endregion

            selectAlbumnButton.Text = text;
            //selectAlbumnButton.Location = localtion;
            selectAlbumnButton.Name= text;

            return selectAlbumnButton;
        }

        //title显示信息设置
        private void SetTitleText(string title, string description)
        {
            TitleTextBox.Text = title;
            DescriptionTextbox.Text = description;
        }

        private void HideOptionButtonPanel()
        {
            //同时需要关闭修改状态
            var editOpen = TitleTextBox.ReadOnly;
            if (editOpen)
            {
                TitleTextBox.ReadOnly = true;
                DescriptionTextbox.ReadOnly = true;
            }
            OptionButtonPanel.Visible = false;
        }
        private void ShowOptionButtonPanel()
        {
            OptionButtonPanel.Visible = true;
        }

        private void AlbumnEditButton_Click(object sender, EventArgs e)
        {
            var editOpen = !TitleTextBox.ReadOnly;
            if (editOpen)//已经在编辑，所以要保存 
            {
                //保存修改
                nowSelectedAlbum.AlbumName = TitleTextBox.Text;
                nowSelectedAlbum.AlbumDescription =DescriptionTextbox.Text;
                var response = albumClient.EditAlbum(nowSelectedAlbum);
                //TODO显示通知

                //关闭编辑状态
                AlbumnEditButton.Text ="修改相册";
                TitleTextBox.ReadOnly = true;
                TitleTextBox.BorderThickness = 0;
                DescriptionTextbox.ReadOnly = true;
                DescriptionTextbox.BorderThickness = 0;

                //手动更新相册状态
                var ab = albumsButtons.FirstOrDefault(buttton => ((AlbumDto)buttton.Tag).AlbumId == nowSelectedAlbum.AlbumId);
                ab.Text = nowSelectedAlbum.AlbumName;
            }
            else//未在编辑，打开编辑 
            {
                AlbumnEditButton.Text ="保存修改";
                TitleTextBox.ReadOnly = false;
                TitleTextBox.BorderThickness = 2;
                DescriptionTextbox.ReadOnly = false;
                DescriptionTextbox.BorderThickness= 2;
            }
        }

        private void AlbumnDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult AF = MessageBox.Show("是否确定删除相册？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (AF == DialogResult.OK)
            {
                //删除该albumn
                var response = albumClient.DeleteAlbum(nowSelectedAlbum.AlbumId);
                if (!response.IsSuccess)
                {
                    Console.WriteLine(response.Msg);
                    //TODO: 通知提示
                    return;
                }
                albumsButtons.Remove(nowSelectdAlbumButton);
                AlbumPanel.Controls.Remove(nowSelectdAlbumButton);
            }

        }

        private void selectPhotoActiveButton_Click(object sender, EventArgs e)
        {
            if (TrashButton.Checked)
            //在回收站页面
            //照片选择项用于永久删除和恢复
            {
                if (!selectPhotoActiveButton.Checked)
                {
                    TrashPageOpenPhotoSelct();
                }
                else
                {
                    TrashPageClosePhotoSelect();
                }
            }
            //在普通页面
            //照片选择项用于删除和下载
            else
            {
                if (!selectPhotoActiveButton.Checked)
                {
                    OpenPhotoSelect();
                }
                else
                {
                    ClosePhotoSelect();
                }
            }

        }
        //打开找选择选项
        private void OpenPhotoSelect()
        {
            selectPhotoActiveButton.Checked = true;
            selectPhotoActiveButton.Text = "完成";
            imagePanel.pictureBoxes.ForEach(pb => pb.checkbox.Visible = true);

            DeletePhotoButton.Visible = true;
            DownloadButton.Visible = true;
        }
        //关闭照片选择选项
        private void ClosePhotoSelect()
        {
            selectPhotoActiveButton.Checked = false;
            selectPhotoActiveButton.Text = "选择";
            imagePanel.pictureBoxes.ForEach(pb =>
            {
                pb.checkbox.Visible = false;
                pb.checkbox.Checked = false;
            });

            DeletePhotoButton.Visible = false;
            DownloadButton.Visible = false;
        }

        private void TrashPageOpenPhotoSelct()
        {
            selectPhotoActiveButton.Checked = true;
            selectPhotoActiveButton.Text = "完成";
            imagePanel.pictureBoxes.ForEach(pb => pb.checkbox.Visible = true);

            PemanentDeleteButton.Visible = true;
            restoreButton.Visible = true;
        }
        private void TrashPageClosePhotoSelect()
        {
            selectPhotoActiveButton.Checked = false;
            selectPhotoActiveButton.Text = "选择";
            imagePanel.pictureBoxes.ForEach(pb =>
            {
                pb.checkbox.Visible = false;
                pb.checkbox.Checked = false;
            });

            PemanentDeleteButton.Visible = false;
            restoreButton.Visible = false;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择照片保存位置";
            if (!(dialog.ShowDialog() == DialogResult.OK))
                return;

            string saveDir = dialog.SelectedPath;
            if (string.IsNullOrEmpty(saveDir))
                return; ;

            var photoUrls = new List<string>();
            imagePanel.pictureBoxes.ForEach(pb =>
            {
                if (pb.checkbox.Checked)
                {
                    photoUrls.Add(pb.PhotoData.Url);
                }
            });
            ClosePhotoSelect();
            photoUrls.ForEach(url =>
            {
                Console.WriteLine(url);
                url.DownloadFileAsync(saveDir);
            });
        }

        private void DeletePhotoButton_Click(object sender, EventArgs e)
        {
            DialogResult AF = MessageBox.Show("是否确定删除照片？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (AF == DialogResult.OK)
            {
                imagePanel.pictureBoxes.ForEach(pb =>
                {
                    if (pb.checkbox.Checked)
                    {
                        PhotoClient.DeletePhoto(pb.PhotoData.PhotoId);
                        pb.Dispose();
                    }
                });
            }


            ClosePhotoSelect();
        }

        private void PemanentDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult AF = MessageBox.Show("是否确定永久删除照片？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (AF == DialogResult.OK)
            {
                imagePanel.pictureBoxes.ForEach(pb =>
                {
                    if (pb.checkbox.Checked)
                    {
                        PhotoClient.PermanentDeletePhoto(pb.PhotoData.PhotoId);
                        pb.Dispose();
                    }
                });
            }
            ClosePhotoSelect();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            imagePanel.pictureBoxes.ForEach(pb =>
            {
                if (pb.checkbox.Checked)
                {
                    PhotoClient.RestorePhoto(pb.PhotoData.PhotoId);
                    pb.Dispose();
                }
            });
            ClosePhotoSelect();
        }
    }
}
