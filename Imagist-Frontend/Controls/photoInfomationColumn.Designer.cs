namespace Imagist_Frontend.Controls
{
    partial class photoInfomationColumn
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
            dataLabel=new Guna.UI2.WinForms.Guna2TextBox();
            dataValue=new Label();
            SuspendLayout();
            // 
            // dataLabel
            // 
            dataLabel.AutoSize=true;
            dataLabel.BorderRadius=10;
            dataLabel.BorderThickness=0;
            dataLabel.CustomizableEdges=customizableEdges1;
            dataLabel.DefaultText="ISO";
            dataLabel.DisabledState.BorderColor=Color.FromArgb(208, 208, 208);
            dataLabel.DisabledState.FillColor=Color.FromArgb(226, 226, 226);
            dataLabel.DisabledState.ForeColor=Color.FromArgb(138, 138, 138);
            dataLabel.DisabledState.PlaceholderForeColor=Color.FromArgb(138, 138, 138);
            dataLabel.FillColor=SystemColors.WindowFrame;
            dataLabel.FocusedState.BorderColor=Color.FromArgb(94, 148, 255);
            dataLabel.Font=new Font("苹方 中等", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataLabel.ForeColor=Color.FromArgb(222, 222, 222);
            dataLabel.HoverState.BorderColor=Color.FromArgb(94, 148, 255);
            dataLabel.Location=new Point(0, 0);
            dataLabel.Margin=new Padding(3, 5, 3, 5);
            dataLabel.Name="dataLabel";
            dataLabel.PasswordChar='\0';
            dataLabel.PlaceholderText="";
            dataLabel.ReadOnly=true;
            dataLabel.SelectedText="";
            dataLabel.ShadowDecoration.CustomizableEdges=customizableEdges2;
            dataLabel.Size=new Size(159, 35);
            dataLabel.TabIndex=0;
            dataLabel.TextAlign=HorizontalAlignment.Center;
            // 
            // dataValue
            // 
            dataValue.AutoSize=true;
            dataValue.Font=new Font("苹方 中等", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            dataValue.ForeColor=Color.FromArgb(222, 222, 222);
            dataValue.Location=new Point(165, 6);
            dataValue.Margin=new Padding(3, 3, 3, 0);
            dataValue.Name="dataValue";
            dataValue.Size=new Size(78, 25);
            dataValue.TabIndex=1;
            dataValue.Text="190223";
            // 
            // photoInfomationColumn
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(15, 15, 15);
            Controls.Add(dataValue);
            Controls.Add(dataLabel);
            Name="photoInfomationColumn";
            Size=new Size(353, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox dataLabel;
        public Label dataValue;
    }
}
