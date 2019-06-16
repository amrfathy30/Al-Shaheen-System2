namespace Al_Shaheen_System
{
    partial class allproductionrequirementsforms
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "بالتة"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "العدد : 23", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("كرتونة", "item_XL_23973024_34908429.jpg");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allproductionrequirementsforms));
            this.listView1 = new System.Windows.Forms.ListView();
            this.production_requirements_icons = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.LargeImageList = this.production_requirements_icons;
            this.listView1.Location = new System.Drawing.Point(12, 123);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeftLayout = true;
            this.listView1.Size = new System.Drawing.Size(754, 567);
            this.listView1.SmallImageList = this.production_requirements_icons;
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(344, 100);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // production_requirements_icons
            // 
            this.production_requirements_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("production_requirements_icons.ImageStream")));
            this.production_requirements_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.production_requirements_icons.Images.SetKeyName(0, "pallets_icons.jpg");
            this.production_requirements_icons.Images.SetKeyName(1, "item_XL_23973024_34908429.jpg");
            this.production_requirements_icons.Images.SetKeyName(2, "image_22.jpg");
            this.production_requirements_icons.Images.SetKeyName(3, "stretch_wrap_big.jpg");
            this.production_requirements_icons.Images.SetKeyName(4, "corrugated_sheets.jpg");
            this.production_requirements_icons.Images.SetKeyName(5, "Webp.net-resizeimage (1).jpg");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = " مستلزمات الانتاج ";
            // 
            // allproductionrequirementsforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 739);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "allproductionrequirementsforms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جميع مستلزمات الانتاج ";
            this.Load += new System.EventHandler(this.allproductionrequirementsforms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList production_requirements_icons;
        private System.Windows.Forms.Label label1;
    }
}