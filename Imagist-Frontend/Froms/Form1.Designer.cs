namespace Imagist_Frontend
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //uploadPanel1=new Controls.UploadPanel();
            SuspendLayout();
            // 
            // uploadPanel1
            // 
            uploadPanel1.AutoSize=true;
            uploadPanel1.BackColor=Color.FromArgb(24, 24, 24);
            uploadPanel1.Dock=DockStyle.Fill;
            uploadPanel1.Location=new Point(0, 0);
            uploadPanel1.Name="uploadPanel1";
            uploadPanel1.Size=new Size(1600, 900);
            uploadPanel1.TabIndex=0;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(9F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=SystemColors.MenuText;
            ClientSize=new Size(1600, 900);
            Controls.Add(uploadPanel1);
            Name="Form1";
            Text="Form1";
            Load+=Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.UploadPanel uploadPanel1;
    }
}