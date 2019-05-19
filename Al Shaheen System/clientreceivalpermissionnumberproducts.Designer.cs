namespace Al_Shaheen_System
{
    partial class clientreceivalpermissionnumberproducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.finished_product_properties_grid_view = new System.Windows.Forms.DataGridView();
            this.dismissed_containers_grid_view = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_items_per_container_text_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.total_number_of_items_of_selected_containers = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.no_of_selected_containers_text_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.add_new_product_with_quantity_btn = new System.Windows.Forms.Button();
            this.return_to_opened_recival_permission_order_btn = new System.Windows.Forms.Button();
            this.f1_combo_box = new System.Windows.Forms.ComboBox();
            this.f1_label = new System.Windows.Forms.Label();
            this.remove_product_with_quantity_btn = new System.Windows.Forms.Button();
            this.product_type_combo_box = new System.Windows.Forms.ComboBox();
            this.f4_combo_box = new System.Windows.Forms.ComboBox();
            this.f4_label = new System.Windows.Forms.Label();
            this.f3_combo_box = new System.Windows.Forms.ComboBox();
            this.f3_label = new System.Windows.Forms.Label();
            this.f2_combo_box = new System.Windows.Forms.ComboBox();
            this.f2_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.client_text_box = new System.Windows.Forms.TextBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.get_client_data_btn = new System.Windows.Forms.Button();
            this.container_name_text_box = new System.Windows.Forms.TextBox();
            this.c_box_1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.finished_product_properties_grid_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dismissed_containers_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(379, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "إضافة أصناف لإذن الإستلام ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "نوع المنتج";
            // 
            // finished_product_properties_grid_view
            // 
            this.finished_product_properties_grid_view.AllowUserToAddRows = false;
            this.finished_product_properties_grid_view.AllowUserToDeleteRows = false;
            this.finished_product_properties_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.finished_product_properties_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.finished_product_properties_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.finished_product_properties_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.finished_product_properties_grid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.finished_product_properties_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.finished_product_properties_grid_view.Location = new System.Drawing.Point(27, 169);
            this.finished_product_properties_grid_view.MultiSelect = false;
            this.finished_product_properties_grid_view.Name = "finished_product_properties_grid_view";
            this.finished_product_properties_grid_view.ReadOnly = true;
            this.finished_product_properties_grid_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.finished_product_properties_grid_view.ShowEditingIcon = false;
            this.finished_product_properties_grid_view.Size = new System.Drawing.Size(996, 194);
            this.finished_product_properties_grid_view.TabIndex = 5;
            this.finished_product_properties_grid_view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.finished_product_properties_grid_view_CellContentClick);
            this.finished_product_properties_grid_view.SelectionChanged += new System.EventHandler(this.finished_product_properties_grid_view_SelectionChanged);
            // 
            // dismissed_containers_grid_view
            // 
            this.dismissed_containers_grid_view.AllowUserToAddRows = false;
            this.dismissed_containers_grid_view.AllowUserToDeleteRows = false;
            this.dismissed_containers_grid_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dismissed_containers_grid_view.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dismissed_containers_grid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dismissed_containers_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dismissed_containers_grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dismissed_containers_grid_view.DefaultCellStyle = dataGridViewCellStyle4;
            this.dismissed_containers_grid_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dismissed_containers_grid_view.Location = new System.Drawing.Point(27, 493);
            this.dismissed_containers_grid_view.Name = "dismissed_containers_grid_view";
            this.dismissed_containers_grid_view.ReadOnly = true;
            this.dismissed_containers_grid_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dismissed_containers_grid_view.Size = new System.Drawing.Size(997, 216);
            this.dismissed_containers_grid_view.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "نوع المنتج";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "إسم  العميل";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "البيان";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "التعبئة";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "عدد التعبئة";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "الكمية بالتعبئة";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "إجمالى الكمية";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // no_items_per_container_text_box
            // 
            this.no_items_per_container_text_box.Enabled = false;
            this.no_items_per_container_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_items_per_container_text_box.Location = new System.Drawing.Point(142, 413);
            this.no_items_per_container_text_box.Name = "no_items_per_container_text_box";
            this.no_items_per_container_text_box.Size = new System.Drawing.Size(294, 30);
            this.no_items_per_container_text_box.TabIndex = 8;
            this.no_items_per_container_text_box.TextChanged += new System.EventHandler(this.no_items_per_container_text_box_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "الكمية / التعبئة";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "التعبئة";
            // 
            // total_number_of_items_of_selected_containers
            // 
            this.total_number_of_items_of_selected_containers.Enabled = false;
            this.total_number_of_items_of_selected_containers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_number_of_items_of_selected_containers.Location = new System.Drawing.Point(744, 416);
            this.total_number_of_items_of_selected_containers.Name = "total_number_of_items_of_selected_containers";
            this.total_number_of_items_of_selected_containers.Size = new System.Drawing.Size(279, 30);
            this.total_number_of_items_of_selected_containers.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(637, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "إجمالى الكمية";
            // 
            // no_of_selected_containers_text_box
            // 
            this.no_of_selected_containers_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_of_selected_containers_text_box.Location = new System.Drawing.Point(745, 380);
            this.no_of_selected_containers_text_box.Name = "no_of_selected_containers_text_box";
            this.no_of_selected_containers_text_box.Size = new System.Drawing.Size(279, 30);
            this.no_of_selected_containers_text_box.TabIndex = 14;
            this.no_of_selected_containers_text_box.TextChanged += new System.EventHandler(this.no_of_selected_containers_text_box_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(638, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "عدد التعبئة";
            // 
            // add_new_product_with_quantity_btn
            // 
            this.add_new_product_with_quantity_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_new_product_with_quantity_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_product_with_quantity_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new_product_with_quantity_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_new_product_with_quantity_btn.Location = new System.Drawing.Point(25, 450);
            this.add_new_product_with_quantity_btn.Name = "add_new_product_with_quantity_btn";
            this.add_new_product_with_quantity_btn.Size = new System.Drawing.Size(159, 37);
            this.add_new_product_with_quantity_btn.TabIndex = 15;
            this.add_new_product_with_quantity_btn.Text = "صرف";
            this.add_new_product_with_quantity_btn.UseVisualStyleBackColor = false;
            this.add_new_product_with_quantity_btn.Click += new System.EventHandler(this.add_new_product_with_quantity_btn_Click);
            // 
            // return_to_opened_recival_permission_order_btn
            // 
            this.return_to_opened_recival_permission_order_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.return_to_opened_recival_permission_order_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.return_to_opened_recival_permission_order_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_to_opened_recival_permission_order_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.return_to_opened_recival_permission_order_btn.Location = new System.Drawing.Point(27, 715);
            this.return_to_opened_recival_permission_order_btn.Name = "return_to_opened_recival_permission_order_btn";
            this.return_to_opened_recival_permission_order_btn.Size = new System.Drawing.Size(157, 36);
            this.return_to_opened_recival_permission_order_btn.TabIndex = 16;
            this.return_to_opened_recival_permission_order_btn.Text = "إضافة لإذن الإستلام";
            this.return_to_opened_recival_permission_order_btn.UseVisualStyleBackColor = false;
            this.return_to_opened_recival_permission_order_btn.Click += new System.EventHandler(this.return_to_opened_recival_permission_order_btn_Click);
            // 
            // f1_combo_box
            // 
            this.f1_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1_combo_box.FormattingEnabled = true;
            this.f1_combo_box.Location = new System.Drawing.Point(516, 95);
            this.f1_combo_box.Name = "f1_combo_box";
            this.f1_combo_box.Size = new System.Drawing.Size(184, 33);
            this.f1_combo_box.TabIndex = 17;
            // 
            // f1_label
            // 
            this.f1_label.AutoSize = true;
            this.f1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1_label.Location = new System.Drawing.Point(418, 95);
            this.f1_label.Name = "f1_label";
            this.f1_label.Size = new System.Drawing.Size(35, 25);
            this.f1_label.TabIndex = 3;
            this.f1_label.Text = "F1";
            // 
            // remove_product_with_quantity_btn
            // 
            this.remove_product_with_quantity_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.remove_product_with_quantity_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove_product_with_quantity_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_product_with_quantity_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.remove_product_with_quantity_btn.Location = new System.Drawing.Point(869, 450);
            this.remove_product_with_quantity_btn.Name = "remove_product_with_quantity_btn";
            this.remove_product_with_quantity_btn.Size = new System.Drawing.Size(155, 37);
            this.remove_product_with_quantity_btn.TabIndex = 19;
            this.remove_product_with_quantity_btn.Text = "مسح";
            this.remove_product_with_quantity_btn.UseVisualStyleBackColor = false;
            // 
            // product_type_combo_box
            // 
            this.product_type_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_type_combo_box.FormattingEnabled = true;
            this.product_type_combo_box.Items.AddRange(new object[] {
            "علب",
            "قاع",
            "RLT",
            "إيزى أوبن",
            "بيل أوف",
            "تويست أوف",
            "غطاء بلاستيك",
            "طبة بلاستيك "});
            this.product_type_combo_box.Location = new System.Drawing.Point(607, 56);
            this.product_type_combo_box.Name = "product_type_combo_box";
            this.product_type_combo_box.Size = new System.Drawing.Size(210, 33);
            this.product_type_combo_box.TabIndex = 20;
            this.product_type_combo_box.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // f4_combo_box
            // 
            this.f4_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f4_combo_box.FormattingEnabled = true;
            this.f4_combo_box.Location = new System.Drawing.Point(823, 131);
            this.f4_combo_box.Name = "f4_combo_box";
            this.f4_combo_box.Size = new System.Drawing.Size(200, 33);
            this.f4_combo_box.TabIndex = 22;
            // 
            // f4_label
            // 
            this.f4_label.AutoSize = true;
            this.f4_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f4_label.Location = new System.Drawing.Point(718, 134);
            this.f4_label.Name = "f4_label";
            this.f4_label.Size = new System.Drawing.Size(35, 25);
            this.f4_label.TabIndex = 21;
            this.f4_label.Text = "F1";
            // 
            // f3_combo_box
            // 
            this.f3_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f3_combo_box.FormattingEnabled = true;
            this.f3_combo_box.Location = new System.Drawing.Point(516, 131);
            this.f3_combo_box.Name = "f3_combo_box";
            this.f3_combo_box.Size = new System.Drawing.Size(184, 33);
            this.f3_combo_box.TabIndex = 24;
            // 
            // f3_label
            // 
            this.f3_label.AutoSize = true;
            this.f3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f3_label.Location = new System.Drawing.Point(418, 134);
            this.f3_label.Name = "f3_label";
            this.f3_label.Size = new System.Drawing.Size(35, 25);
            this.f3_label.TabIndex = 23;
            this.f3_label.Text = "F1";
            // 
            // f2_combo_box
            // 
            this.f2_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f2_combo_box.FormattingEnabled = true;
            this.f2_combo_box.Location = new System.Drawing.Point(823, 95);
            this.f2_combo_box.Name = "f2_combo_box";
            this.f2_combo_box.Size = new System.Drawing.Size(200, 33);
            this.f2_combo_box.TabIndex = 26;
            // 
            // f2_label
            // 
            this.f2_label.AutoSize = true;
            this.f2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f2_label.Location = new System.Drawing.Point(718, 98);
            this.f2_label.Name = "f2_label";
            this.f2_label.Size = new System.Drawing.Size(35, 25);
            this.f2_label.TabIndex = 25;
            this.f2_label.Text = "F1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "إسم العميل";
            // 
            // client_text_box
            // 
            this.client_text_box.Enabled = false;
            this.client_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_text_box.Location = new System.Drawing.Point(135, 67);
            this.client_text_box.Name = "client_text_box";
            this.client_text_box.Size = new System.Drawing.Size(277, 30);
            this.client_text_box.TabIndex = 28;
            this.client_text_box.TextChanged += new System.EventHandler(this.client_text_box_TextChanged);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.close_btn.Location = new System.Drawing.Point(869, 715);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(155, 36);
            this.close_btn.TabIndex = 29;
            this.close_btn.Text = "إلغاء";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // get_client_data_btn
            // 
            this.get_client_data_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.get_client_data_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.get_client_data_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.get_client_data_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.get_client_data_btn.Location = new System.Drawing.Point(27, 126);
            this.get_client_data_btn.Name = "get_client_data_btn";
            this.get_client_data_btn.Size = new System.Drawing.Size(200, 37);
            this.get_client_data_btn.TabIndex = 30;
            this.get_client_data_btn.Text = "الكميات الحالية";
            this.get_client_data_btn.UseVisualStyleBackColor = false;
            this.get_client_data_btn.Click += new System.EventHandler(this.get_client_data_btn_Click);
            // 
            // container_name_text_box
            // 
            this.container_name_text_box.Enabled = false;
            this.container_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.container_name_text_box.Location = new System.Drawing.Point(142, 378);
            this.container_name_text_box.Name = "container_name_text_box";
            this.container_name_text_box.Size = new System.Drawing.Size(294, 30);
            this.container_name_text_box.TabIndex = 31;
            // 
            // c_box_1
            // 
            this.c_box_1.AutoSize = true;
            this.c_box_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_box_1.Location = new System.Drawing.Point(845, 58);
            this.c_box_1.Name = "c_box_1";
            this.c_box_1.Size = new System.Drawing.Size(126, 29);
            this.c_box_1.TabIndex = 32;
            this.c_box_1.Text = "checkbox1";
            this.c_box_1.UseVisualStyleBackColor = true;
            // 
            // clientreceivalpermissionnumberproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1045, 762);
            this.Controls.Add(this.c_box_1);
            this.Controls.Add(this.container_name_text_box);
            this.Controls.Add(this.get_client_data_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.client_text_box);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.f2_combo_box);
            this.Controls.Add(this.f2_label);
            this.Controls.Add(this.f3_combo_box);
            this.Controls.Add(this.f3_label);
            this.Controls.Add(this.f4_combo_box);
            this.Controls.Add(this.f4_label);
            this.Controls.Add(this.product_type_combo_box);
            this.Controls.Add(this.remove_product_with_quantity_btn);
            this.Controls.Add(this.f1_combo_box);
            this.Controls.Add(this.return_to_opened_recival_permission_order_btn);
            this.Controls.Add(this.add_new_product_with_quantity_btn);
            this.Controls.Add(this.no_of_selected_containers_text_box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.total_number_of_items_of_selected_containers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.no_items_per_container_text_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dismissed_containers_grid_view);
            this.Controls.Add(this.finished_product_properties_grid_view);
            this.Controls.Add(this.f1_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "clientreceivalpermissionnumberproducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة إصناف لإذن الإستلام";
            this.Load += new System.EventHandler(this.clientreceivalpermissionnumberproducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.finished_product_properties_grid_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dismissed_containers_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView finished_product_properties_grid_view;
        private System.Windows.Forms.DataGridView dismissed_containers_grid_view;
        private System.Windows.Forms.TextBox no_items_per_container_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox total_number_of_items_of_selected_containers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox no_of_selected_containers_text_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button add_new_product_with_quantity_btn;
        private System.Windows.Forms.Button return_to_opened_recival_permission_order_btn;
        private System.Windows.Forms.ComboBox f1_combo_box;
        private System.Windows.Forms.Label f1_label;
        private System.Windows.Forms.Button remove_product_with_quantity_btn;
        private System.Windows.Forms.ComboBox product_type_combo_box;
        private System.Windows.Forms.ComboBox f4_combo_box;
        private System.Windows.Forms.Label f4_label;
        private System.Windows.Forms.ComboBox f3_combo_box;
        private System.Windows.Forms.Label f3_label;
        private System.Windows.Forms.ComboBox f2_combo_box;
        private System.Windows.Forms.Label f2_label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox client_text_box;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button get_client_data_btn;
        private System.Windows.Forms.TextBox container_name_text_box;
        private System.Windows.Forms.CheckBox c_box_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}