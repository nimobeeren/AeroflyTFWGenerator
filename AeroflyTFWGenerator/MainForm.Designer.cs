namespace AeroflyTFWGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMetadataFile = new System.Windows.Forms.TextBox();
            this.btnMetadataBrowse = new System.Windows.Forms.Button();
            this.listImages = new System.Windows.Forms.ListView();
            this.btnImagesAdd = new System.Windows.Forms.Button();
            this.btnImagesRemove = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.openMetadata = new System.Windows.Forms.OpenFileDialog();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSV metadata file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image files";
            // 
            // txtMetadataFile
            // 
            this.txtMetadataFile.Location = new System.Drawing.Point(12, 64);
            this.txtMetadataFile.Name = "txtMetadataFile";
            this.txtMetadataFile.Size = new System.Drawing.Size(274, 20);
            this.txtMetadataFile.TabIndex = 2;
            // 
            // btnMetadataBrowse
            // 
            this.btnMetadataBrowse.Location = new System.Drawing.Point(292, 62);
            this.btnMetadataBrowse.Name = "btnMetadataBrowse";
            this.btnMetadataBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnMetadataBrowse.TabIndex = 3;
            this.btnMetadataBrowse.Text = "Browse";
            this.btnMetadataBrowse.UseVisualStyleBackColor = true;
            this.btnMetadataBrowse.Click += new System.EventHandler(this.btnMetadataBrowse_Click);
            // 
            // listImages
            // 
            this.listImages.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listImages.Location = new System.Drawing.Point(12, 103);
            this.listImages.Name = "listImages";
            this.listImages.ShowItemToolTips = true;
            this.listImages.Size = new System.Drawing.Size(355, 97);
            this.listImages.TabIndex = 4;
            this.listImages.UseCompatibleStateImageBehavior = false;
            this.listImages.View = System.Windows.Forms.View.List;
            this.listImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listImages_KeyUp);
            // 
            // btnImagesAdd
            // 
            this.btnImagesAdd.Location = new System.Drawing.Point(12, 206);
            this.btnImagesAdd.Name = "btnImagesAdd";
            this.btnImagesAdd.Size = new System.Drawing.Size(75, 23);
            this.btnImagesAdd.TabIndex = 5;
            this.btnImagesAdd.Text = "Add";
            this.btnImagesAdd.UseVisualStyleBackColor = true;
            this.btnImagesAdd.Click += new System.EventHandler(this.btnImagesAdd_Click);
            // 
            // btnImagesRemove
            // 
            this.btnImagesRemove.Location = new System.Drawing.Point(93, 206);
            this.btnImagesRemove.Name = "btnImagesRemove";
            this.btnImagesRemove.Size = new System.Drawing.Size(75, 23);
            this.btnImagesRemove.TabIndex = 6;
            this.btnImagesRemove.Text = "Remove";
            this.btnImagesRemove.UseVisualStyleBackColor = true;
            this.btnImagesRemove.Click += new System.EventHandler(this.btnImagesRemove_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 235);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(355, 46);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // openMetadata
            // 
            this.openMetadata.DefaultExt = "csv";
            this.openMetadata.Filter = "Metadata|*.csv|All files|*.*";
            // 
            // openImage
            // 
            this.openImage.DefaultExt = "tif";
            this.openImage.Filter = "Image files|*.tif|All files|*.*";
            this.openImage.Multiselect = true;
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(292, 23);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 10;
            this.btnOutputBrowse.Text = "Browse";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(12, 25);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(274, 20);
            this.txtOutputDir.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output directory";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 295);
            this.Controls.Add(this.btnOutputBrowse);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnImagesRemove);
            this.Controls.Add(this.btnImagesAdd);
            this.Controls.Add(this.listImages);
            this.Controls.Add(this.btnMetadataBrowse);
            this.Controls.Add(this.txtMetadataFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aerofly TFW Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMetadataFile;
        private System.Windows.Forms.Button btnMetadataBrowse;
        private System.Windows.Forms.ListView listImages;
        private System.Windows.Forms.Button btnImagesAdd;
        private System.Windows.Forms.Button btnImagesRemove;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.OpenFileDialog openMetadata;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label3;
    }
}

