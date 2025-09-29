namespace Broadleaf.Windows.Forms
{
    partial class McastMainteInfoEditor
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(McastMainteInfoEditor));
            this.ProductCode_Title_label = new System.Windows.Forms.Label();
            this.McastGidnceMainteCd_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ServerMainteEdTime_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ServerMainteStTime_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ServerMainteEdTime_Title_label = new System.Windows.Forms.Label();
            this.ServerMainteStTime_Title_label = new System.Windows.Forms.Label();
            this.ServerMainteEdScdl_Title_label = new System.Windows.Forms.Label();
            this.McastGidncCntntsCd_comboBox = new System.Windows.Forms.ComboBox();
            this.McastGidncCntntsCd_label = new System.Windows.Forms.Label();
            this.ProductCode_textBox = new System.Windows.Forms.TextBox();
            this.MulticastConsNo_label = new System.Windows.Forms.Label();
            this.MulticastConsNo_textBox = new System.Windows.Forms.TextBox();
            this.McastGidnceMainteCd_comboBox = new System.Windows.Forms.ComboBox();
            this.ServerMainteStScdl_Title_label = new System.Windows.Forms.Label();
            this.ServerMainteStScdl_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ServerMainteEdScdl_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Main_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.Update_label = new System.Windows.Forms.Label();
            this.ServerMainteGidnc_groupBox = new System.Windows.Forms.GroupBox();
            this.ServerMainteGidnc_textBox = new System.Windows.Forms.TextBox();
            this.ServerMainteCntnts_groupBox = new System.Windows.Forms.GroupBox();
            this.ServerMainteCntnts_textBox = new System.Windows.Forms.TextBox();
            this.AnothersheetFileName_groupBox = new System.Windows.Forms.GroupBox();
            this.CopyAnothersheetFile_checkBox = new System.Windows.Forms.CheckBox();
            this.AnothersheetFileName_listView = new System.Windows.Forms.ListView();
            this.FileName_columnHeader = new System.Windows.Forms.ColumnHeader();
            this.FileFrom_columnHeader = new System.Windows.Forms.ColumnHeader();
            this.Anothersheet_imageList = new System.Windows.Forms.ImageList(this.components);
            this.DelAnothersheetFileName_button = new System.Windows.Forms.Button();
            this.AddAnothersheetFileName_button = new System.Windows.Forms.Button();
            this.CreateGuid_button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Save_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Cancel_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Initial_timer = new System.Windows.Forms.Timer(this.components);
            this.Anothersheet_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.Main_toolStripContainer.ContentPanel.SuspendLayout();
            this.Main_toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.Main_toolStripContainer.SuspendLayout();
            this.ServerMainteGidnc_groupBox.SuspendLayout();
            this.ServerMainteCntnts_groupBox.SuspendLayout();
            this.AnothersheetFileName_groupBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductCode_Title_label
            // 
            this.ProductCode_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCode_Title_label.AutoSize = true;
            this.ProductCode_Title_label.Location = new System.Drawing.Point(3, 28);
            this.ProductCode_Title_label.Name = "ProductCode_Title_label";
            this.ProductCode_Title_label.Size = new System.Drawing.Size(89, 12);
            this.ProductCode_Title_label.TabIndex = 0;
            this.ProductCode_Title_label.Text = "パッケージ区分";
            // 
            // McastGidnceMainteCd_label
            // 
            this.McastGidnceMainteCd_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.McastGidnceMainteCd_label.AutoSize = true;
            this.McastGidnceMainteCd_label.Location = new System.Drawing.Point(3, 75);
            this.McastGidnceMainteCd_label.Name = "McastGidnceMainteCd_label";
            this.McastGidnceMainteCd_label.Size = new System.Drawing.Size(101, 12);
            this.McastGidnceMainteCd_label.TabIndex = 2;
            this.McastGidnceMainteCd_label.Text = "メンテナンス区分";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteEdTime_maskedTextBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteStTime_maskedTextBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteEdTime_Title_label, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteStTime_Title_label, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteEdScdl_Title_label, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.McastGidncCntntsCd_comboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.McastGidncCntntsCd_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProductCode_textBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProductCode_Title_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MulticastConsNo_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.MulticastConsNo_textBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.McastGidnceMainteCd_comboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.McastGidnceMainteCd_label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteStScdl_Title_label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteStScdl_maskedTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ServerMainteEdScdl_maskedTextBox, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 93);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ServerMainteEdTime_maskedTextBox
            // 
            this.ServerMainteEdTime_maskedTextBox.AsciiOnly = true;
            this.ServerMainteEdTime_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ServerMainteEdTime_maskedTextBox.Location = new System.Drawing.Point(533, 72);
            this.ServerMainteEdTime_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.ServerMainteEdTime_maskedTextBox.Name = "ServerMainteEdTime_maskedTextBox";
            this.ServerMainteEdTime_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.ServerMainteEdTime_maskedTextBox.TabIndex = 7;
            this.ServerMainteEdTime_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ServerMainteStTime_maskedTextBox
            // 
            this.ServerMainteStTime_maskedTextBox.AsciiOnly = true;
            this.ServerMainteStTime_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ServerMainteStTime_maskedTextBox.Location = new System.Drawing.Point(533, 49);
            this.ServerMainteStTime_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.ServerMainteStTime_maskedTextBox.Name = "ServerMainteStTime_maskedTextBox";
            this.ServerMainteStTime_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.ServerMainteStTime_maskedTextBox.TabIndex = 6;
            this.ServerMainteStTime_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ServerMainteEdTime_Title_label
            // 
            this.ServerMainteEdTime_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServerMainteEdTime_Title_label.AutoSize = true;
            this.ServerMainteEdTime_Title_label.Location = new System.Drawing.Point(373, 75);
            this.ServerMainteEdTime_Title_label.Name = "ServerMainteEdTime_Title_label";
            this.ServerMainteEdTime_Title_label.Size = new System.Drawing.Size(125, 12);
            this.ServerMainteEdTime_Title_label.TabIndex = 13;
            this.ServerMainteEdTime_Title_label.Text = "メンテナンス終了日時";
            // 
            // ServerMainteStTime_Title_label
            // 
            this.ServerMainteStTime_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServerMainteStTime_Title_label.AutoSize = true;
            this.ServerMainteStTime_Title_label.Location = new System.Drawing.Point(373, 51);
            this.ServerMainteStTime_Title_label.Name = "ServerMainteStTime_Title_label";
            this.ServerMainteStTime_Title_label.Size = new System.Drawing.Size(125, 12);
            this.ServerMainteStTime_Title_label.TabIndex = 11;
            this.ServerMainteStTime_Title_label.Text = "メンテナンス開始日時";
            // 
            // ServerMainteEdScdl_Title_label
            // 
            this.ServerMainteEdScdl_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServerMainteEdScdl_Title_label.AutoSize = true;
            this.ServerMainteEdScdl_Title_label.Location = new System.Drawing.Point(373, 28);
            this.ServerMainteEdScdl_Title_label.Name = "ServerMainteEdScdl_Title_label";
            this.ServerMainteEdScdl_Title_label.Size = new System.Drawing.Size(149, 12);
            this.ServerMainteEdScdl_Title_label.TabIndex = 9;
            this.ServerMainteEdScdl_Title_label.Text = "メンテナンス終了予定日時";
            // 
            // McastGidncCntntsCd_comboBox
            // 
            this.McastGidncCntntsCd_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.McastGidncCntntsCd_comboBox.Enabled = false;
            this.McastGidncCntntsCd_comboBox.FormattingEnabled = true;
            this.McastGidncCntntsCd_comboBox.Location = new System.Drawing.Point(163, 3);
            this.McastGidncCntntsCd_comboBox.Name = "McastGidncCntntsCd_comboBox";
            this.McastGidncCntntsCd_comboBox.Size = new System.Drawing.Size(182, 20);
            this.McastGidncCntntsCd_comboBox.TabIndex = 0;
            // 
            // McastGidncCntntsCd_label
            // 
            this.McastGidncCntntsCd_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.McastGidncCntntsCd_label.AutoSize = true;
            this.McastGidncCntntsCd_label.Location = new System.Drawing.Point(3, 5);
            this.McastGidncCntntsCd_label.Name = "McastGidncCntntsCd_label";
            this.McastGidncCntntsCd_label.Size = new System.Drawing.Size(53, 12);
            this.McastGidncCntntsCd_label.TabIndex = 3;
            this.McastGidncCntntsCd_label.Text = "案内区分";
            // 
            // ProductCode_textBox
            // 
            this.ProductCode_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCode_textBox.Enabled = false;
            this.ProductCode_textBox.Location = new System.Drawing.Point(163, 26);
            this.ProductCode_textBox.MaxLength = 32;
            this.ProductCode_textBox.Name = "ProductCode_textBox";
            this.ProductCode_textBox.Size = new System.Drawing.Size(188, 19);
            this.ProductCode_textBox.TabIndex = 1;
            this.ProductCode_textBox.Text = "12345678901234567890123456789012";
            // 
            // MulticastConsNo_label
            // 
            this.MulticastConsNo_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastConsNo_label.AutoSize = true;
            this.MulticastConsNo_label.Location = new System.Drawing.Point(3, 51);
            this.MulticastConsNo_label.Name = "MulticastConsNo_label";
            this.MulticastConsNo_label.Size = new System.Drawing.Size(101, 12);
            this.MulticastConsNo_label.TabIndex = 10;
            this.MulticastConsNo_label.Text = "メンテナンス連番";
            // 
            // MulticastConsNo_textBox
            // 
            this.MulticastConsNo_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastConsNo_textBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MulticastConsNo_textBox.Location = new System.Drawing.Point(163, 49);
            this.MulticastConsNo_textBox.MaxLength = 4;
            this.MulticastConsNo_textBox.Name = "MulticastConsNo_textBox";
            this.MulticastConsNo_textBox.Size = new System.Drawing.Size(59, 19);
            this.MulticastConsNo_textBox.TabIndex = 2;
            this.MulticastConsNo_textBox.Text = "1234";
            // 
            // McastGidnceMainteCd_comboBox
            // 
            this.McastGidnceMainteCd_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.McastGidnceMainteCd_comboBox.FormattingEnabled = true;
            this.McastGidnceMainteCd_comboBox.Location = new System.Drawing.Point(163, 72);
            this.McastGidnceMainteCd_comboBox.Name = "McastGidnceMainteCd_comboBox";
            this.McastGidnceMainteCd_comboBox.Size = new System.Drawing.Size(185, 20);
            this.McastGidnceMainteCd_comboBox.TabIndex = 3;
            // 
            // ServerMainteStScdl_Title_label
            // 
            this.ServerMainteStScdl_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServerMainteStScdl_Title_label.AutoSize = true;
            this.ServerMainteStScdl_Title_label.Location = new System.Drawing.Point(373, 5);
            this.ServerMainteStScdl_Title_label.Name = "ServerMainteStScdl_Title_label";
            this.ServerMainteStScdl_Title_label.Size = new System.Drawing.Size(149, 12);
            this.ServerMainteStScdl_Title_label.TabIndex = 7;
            this.ServerMainteStScdl_Title_label.Text = "メンテナンス開始予定日時";
            // 
            // ServerMainteStScdl_maskedTextBox
            // 
            this.ServerMainteStScdl_maskedTextBox.AsciiOnly = true;
            this.ServerMainteStScdl_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ServerMainteStScdl_maskedTextBox.Location = new System.Drawing.Point(533, 3);
            this.ServerMainteStScdl_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.ServerMainteStScdl_maskedTextBox.Name = "ServerMainteStScdl_maskedTextBox";
            this.ServerMainteStScdl_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.ServerMainteStScdl_maskedTextBox.TabIndex = 4;
            this.ServerMainteStScdl_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ServerMainteEdScdl_maskedTextBox
            // 
            this.ServerMainteEdScdl_maskedTextBox.AsciiOnly = true;
            this.ServerMainteEdScdl_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ServerMainteEdScdl_maskedTextBox.Location = new System.Drawing.Point(533, 26);
            this.ServerMainteEdScdl_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.ServerMainteEdScdl_maskedTextBox.Name = "ServerMainteEdScdl_maskedTextBox";
            this.ServerMainteEdScdl_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.ServerMainteEdScdl_maskedTextBox.TabIndex = 5;
            this.ServerMainteEdScdl_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(749, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Main_toolStripContainer
            // 
            // 
            // Main_toolStripContainer.ContentPanel
            // 
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.Update_label);
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.ServerMainteGidnc_groupBox);
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.ServerMainteCntnts_groupBox);
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.AnothersheetFileName_groupBox);
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.Main_toolStripContainer.ContentPanel.Size = new System.Drawing.Size(749, 498);
            this.Main_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.Main_toolStripContainer.Name = "Main_toolStripContainer";
            this.Main_toolStripContainer.Size = new System.Drawing.Size(749, 523);
            this.Main_toolStripContainer.TabIndex = 0;
            this.Main_toolStripContainer.Text = "toolStripContainer1";
            // 
            // Main_toolStripContainer.TopToolStripPanel
            // 
            this.Main_toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // Update_label
            // 
            this.Update_label.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Update_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.Update_label.ForeColor = System.Drawing.Color.White;
            this.Update_label.Location = new System.Drawing.Point(621, 5);
            this.Update_label.Name = "Update_label";
            this.Update_label.Size = new System.Drawing.Size(120, 20);
            this.Update_label.TabIndex = 5;
            this.Update_label.Text = "新規モード";
            this.Update_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerMainteGidnc_groupBox
            // 
            this.ServerMainteGidnc_groupBox.Controls.Add(this.ServerMainteGidnc_textBox);
            this.ServerMainteGidnc_groupBox.Location = new System.Drawing.Point(376, 130);
            this.ServerMainteGidnc_groupBox.Name = "ServerMainteGidnc_groupBox";
            this.ServerMainteGidnc_groupBox.Size = new System.Drawing.Size(368, 180);
            this.ServerMainteGidnc_groupBox.TabIndex = 2;
            this.ServerMainteGidnc_groupBox.TabStop = false;
            this.ServerMainteGidnc_groupBox.Text = "メンテナンス案内文";
            // 
            // ServerMainteGidnc_textBox
            // 
            this.ServerMainteGidnc_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ServerMainteGidnc_textBox.Location = new System.Drawing.Point(8, 20);
            this.ServerMainteGidnc_textBox.Multiline = true;
            this.ServerMainteGidnc_textBox.Name = "ServerMainteGidnc_textBox";
            this.ServerMainteGidnc_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ServerMainteGidnc_textBox.Size = new System.Drawing.Size(352, 144);
            this.ServerMainteGidnc_textBox.TabIndex = 0;
            // 
            // ServerMainteCntnts_groupBox
            // 
            this.ServerMainteCntnts_groupBox.Controls.Add(this.ServerMainteCntnts_textBox);
            this.ServerMainteCntnts_groupBox.Location = new System.Drawing.Point(4, 130);
            this.ServerMainteCntnts_groupBox.Name = "ServerMainteCntnts_groupBox";
            this.ServerMainteCntnts_groupBox.Size = new System.Drawing.Size(368, 180);
            this.ServerMainteCntnts_groupBox.TabIndex = 1;
            this.ServerMainteCntnts_groupBox.TabStop = false;
            this.ServerMainteCntnts_groupBox.Text = "メンテナンス内容";
            // 
            // ServerMainteCntnts_textBox
            // 
            this.ServerMainteCntnts_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ServerMainteCntnts_textBox.Location = new System.Drawing.Point(8, 20);
            this.ServerMainteCntnts_textBox.MaxLength = 60;
            this.ServerMainteCntnts_textBox.Multiline = true;
            this.ServerMainteCntnts_textBox.Name = "ServerMainteCntnts_textBox";
            this.ServerMainteCntnts_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ServerMainteCntnts_textBox.Size = new System.Drawing.Size(352, 144);
            this.ServerMainteCntnts_textBox.TabIndex = 0;
            // 
            // AnothersheetFileName_groupBox
            // 
            this.AnothersheetFileName_groupBox.Controls.Add(this.CopyAnothersheetFile_checkBox);
            this.AnothersheetFileName_groupBox.Controls.Add(this.AnothersheetFileName_listView);
            this.AnothersheetFileName_groupBox.Controls.Add(this.DelAnothersheetFileName_button);
            this.AnothersheetFileName_groupBox.Controls.Add(this.AddAnothersheetFileName_button);
            this.AnothersheetFileName_groupBox.Controls.Add(this.CreateGuid_button);
            this.AnothersheetFileName_groupBox.Location = new System.Drawing.Point(4, 314);
            this.AnothersheetFileName_groupBox.Name = "AnothersheetFileName_groupBox";
            this.AnothersheetFileName_groupBox.Size = new System.Drawing.Size(740, 180);
            this.AnothersheetFileName_groupBox.TabIndex = 3;
            this.AnothersheetFileName_groupBox.TabStop = false;
            this.AnothersheetFileName_groupBox.Text = "別紙ファイル";
            // 
            // CopyAnothersheetFile_checkBox
            // 
            this.CopyAnothersheetFile_checkBox.AutoSize = true;
            this.CopyAnothersheetFile_checkBox.Checked = true;
            this.CopyAnothersheetFile_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CopyAnothersheetFile_checkBox.Location = new System.Drawing.Point(504, 24);
            this.CopyAnothersheetFile_checkBox.Name = "CopyAnothersheetFile_checkBox";
            this.CopyAnothersheetFile_checkBox.Size = new System.Drawing.Size(228, 16);
            this.CopyAnothersheetFile_checkBox.TabIndex = 3;
            this.CopyAnothersheetFile_checkBox.Text = "新規追加分別紙ファイルをコピーする";
            this.CopyAnothersheetFile_checkBox.UseVisualStyleBackColor = true;
            this.CopyAnothersheetFile_checkBox.Visible = false;
            // 
            // AnothersheetFileName_listView
            // 
            this.AnothersheetFileName_listView.AllowDrop = true;
            this.AnothersheetFileName_listView.AutoArrange = false;
            this.AnothersheetFileName_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName_columnHeader,
            this.FileFrom_columnHeader});
            this.AnothersheetFileName_listView.FullRowSelect = true;
            this.AnothersheetFileName_listView.GridLines = true;
            this.AnothersheetFileName_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AnothersheetFileName_listView.HideSelection = false;
            this.AnothersheetFileName_listView.LabelEdit = true;
            this.AnothersheetFileName_listView.LabelWrap = false;
            this.AnothersheetFileName_listView.Location = new System.Drawing.Point(8, 48);
            this.AnothersheetFileName_listView.MultiSelect = false;
            this.AnothersheetFileName_listView.Name = "AnothersheetFileName_listView";
            this.AnothersheetFileName_listView.ShowGroups = false;
            this.AnothersheetFileName_listView.Size = new System.Drawing.Size(724, 124);
            this.AnothersheetFileName_listView.StateImageList = this.Anothersheet_imageList;
            this.AnothersheetFileName_listView.TabIndex = 4;
            this.AnothersheetFileName_listView.UseCompatibleStateImageBehavior = false;
            this.AnothersheetFileName_listView.View = System.Windows.Forms.View.Details;
            this.AnothersheetFileName_listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AnothersheetFileName_listView_AfterLabelEdit);
            this.AnothersheetFileName_listView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AnothersheetFileName_listView_BeforeLabelEdit);
            // 
            // FileName_columnHeader
            // 
            this.FileName_columnHeader.Text = "ファイル名";
            this.FileName_columnHeader.Width = 380;
            // 
            // FileFrom_columnHeader
            // 
            this.FileFrom_columnHeader.Text = "元ファイル";
            this.FileFrom_columnHeader.Width = 256;
            // 
            // Anothersheet_imageList
            // 
            this.Anothersheet_imageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject("Anothersheet_imageList.ImageStream") ) );
            this.Anothersheet_imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.Anothersheet_imageList.Images.SetKeyName(0, "Circle");
            this.Anothersheet_imageList.Images.SetKeyName(1, "Cross");
            this.Anothersheet_imageList.Images.SetKeyName(2, "Plus");
            // 
            // DelAnothersheetFileName_button
            // 
            this.DelAnothersheetFileName_button.Location = new System.Drawing.Point(136, 20);
            this.DelAnothersheetFileName_button.Name = "DelAnothersheetFileName_button";
            this.DelAnothersheetFileName_button.Size = new System.Drawing.Size(64, 24);
            this.DelAnothersheetFileName_button.TabIndex = 2;
            this.DelAnothersheetFileName_button.Text = "削除";
            this.DelAnothersheetFileName_button.UseVisualStyleBackColor = true;
            this.DelAnothersheetFileName_button.Click += new System.EventHandler(this.DelAnothersheetFileName_button_Click);
            // 
            // AddAnothersheetFileName_button
            // 
            this.AddAnothersheetFileName_button.Location = new System.Drawing.Point(8, 20);
            this.AddAnothersheetFileName_button.Name = "AddAnothersheetFileName_button";
            this.AddAnothersheetFileName_button.Size = new System.Drawing.Size(64, 24);
            this.AddAnothersheetFileName_button.TabIndex = 0;
            this.AddAnothersheetFileName_button.Text = "追加";
            this.AddAnothersheetFileName_button.UseVisualStyleBackColor = true;
            this.AddAnothersheetFileName_button.Click += new System.EventHandler(this.AddAnothersheetFileName_button_Click);
            // 
            // CreateGuid_button
            // 
            this.CreateGuid_button.Location = new System.Drawing.Point(72, 20);
            this.CreateGuid_button.Name = "CreateGuid_button";
            this.CreateGuid_button.Size = new System.Drawing.Size(64, 24);
            this.CreateGuid_button.TabIndex = 1;
            this.CreateGuid_button.Text = "GUID生成";
            this.CreateGuid_button.UseVisualStyleBackColor = true;
            this.CreateGuid_button.Click += new System.EventHandler(this.CreateGuid_button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save_toolStripButton,
            this.Cancel_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(138, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // Save_toolStripButton
            // 
            this.Save_toolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject("Save_toolStripButton.Image") ) );
            this.Save_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_toolStripButton.Name = "Save_toolStripButton";
            this.Save_toolStripButton.Size = new System.Drawing.Size(64, 22);
            this.Save_toolStripButton.Text = "保存(&S)";
            this.Save_toolStripButton.Click += new System.EventHandler(this.Save_toolStripButton_Click);
            // 
            // Cancel_toolStripButton
            // 
            this.Cancel_toolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject("Cancel_toolStripButton.Image") ) );
            this.Cancel_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancel_toolStripButton.Name = "Cancel_toolStripButton";
            this.Cancel_toolStripButton.Size = new System.Drawing.Size(62, 22);
            this.Cancel_toolStripButton.Text = "戻る(&C)";
            this.Cancel_toolStripButton.Click += new System.EventHandler(this.Cancel_toolStripButton_Click);
            // 
            // Initial_timer
            // 
            this.Initial_timer.Interval = 1;
            this.Initial_timer.Tick += new System.EventHandler(this.Initial_timer_Tick);
            // 
            // Anothersheet_openFileDialog
            // 
            this.Anothersheet_openFileDialog.Filter = "PDFファイル|*.pdf|すべてのファイル|*.*";
            this.Anothersheet_openFileDialog.RestoreDirectory = true;
            this.Anothersheet_openFileDialog.Title = "別紙ファイルを開く";
            // 
            // McastMainteInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 545);
            this.Controls.Add(this.Main_toolStripContainer);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "McastMainteInfoEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "サーバーメンテナンス情報編集";
            this.Load += new System.EventHandler(this.MulticastInfoEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.MulticastInfoEditor_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MulticastInfoEditor_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Main_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.Main_toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.Main_toolStripContainer.TopToolStripPanel.PerformLayout();
            this.Main_toolStripContainer.ResumeLayout(false);
            this.Main_toolStripContainer.PerformLayout();
            this.ServerMainteGidnc_groupBox.ResumeLayout(false);
            this.ServerMainteGidnc_groupBox.PerformLayout();
            this.ServerMainteCntnts_groupBox.ResumeLayout(false);
            this.ServerMainteCntnts_groupBox.PerformLayout();
            this.AnothersheetFileName_groupBox.ResumeLayout(false);
            this.AnothersheetFileName_groupBox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ProductCode_Title_label;
        private System.Windows.Forms.Label McastGidnceMainteCd_label;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label MulticastConsNo_label;
        private System.Windows.Forms.TextBox MulticastConsNo_textBox;
        private System.Windows.Forms.TextBox ProductCode_textBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripContainer Main_toolStripContainer;
		private System.Windows.Forms.GroupBox AnothersheetFileName_groupBox;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton Save_toolStripButton;
        private System.Windows.Forms.ToolStripButton Cancel_toolStripButton;
		private System.Windows.Forms.ComboBox McastGidnceMainteCd_comboBox;
		private System.Windows.Forms.MaskedTextBox ServerMainteEdScdl_maskedTextBox;
        private System.Windows.Forms.MaskedTextBox ServerMainteStScdl_maskedTextBox;
		private System.Windows.Forms.Button DelAnothersheetFileName_button;
		private System.Windows.Forms.Button AddAnothersheetFileName_button;
		private System.Windows.Forms.Button CreateGuid_button;
		private System.Windows.Forms.Timer Initial_timer;
		private System.Windows.Forms.ListView AnothersheetFileName_listView;
		private System.Windows.Forms.ColumnHeader FileName_columnHeader;
		private System.Windows.Forms.ColumnHeader FileFrom_columnHeader;
		private System.Windows.Forms.OpenFileDialog Anothersheet_openFileDialog;
		private System.Windows.Forms.ImageList Anothersheet_imageList;
        private System.Windows.Forms.CheckBox CopyAnothersheetFile_checkBox;
        private System.Windows.Forms.ComboBox McastGidncCntntsCd_comboBox;
        private System.Windows.Forms.Label McastGidncCntntsCd_label;
        private System.Windows.Forms.Label ServerMainteEdTime_Title_label;
        private System.Windows.Forms.Label ServerMainteStTime_Title_label;
        private System.Windows.Forms.Label ServerMainteEdScdl_Title_label;
        private System.Windows.Forms.Label ServerMainteStScdl_Title_label;
        private System.Windows.Forms.MaskedTextBox ServerMainteEdTime_maskedTextBox;
        private System.Windows.Forms.MaskedTextBox ServerMainteStTime_maskedTextBox;
        private System.Windows.Forms.GroupBox ServerMainteGidnc_groupBox;
        private System.Windows.Forms.TextBox ServerMainteGidnc_textBox;
        private System.Windows.Forms.GroupBox ServerMainteCntnts_groupBox;
        private System.Windows.Forms.TextBox ServerMainteCntnts_textBox;
        private System.Windows.Forms.Label Update_label;
	}
}