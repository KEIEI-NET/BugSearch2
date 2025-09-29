namespace Broadleaf.Windows.Forms
{
    partial class McastPrintPointInfoEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(McastPrintPointInfoEditor));
            this.ProductCode_Title_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.McastGidncCntntsCd_comboBox = new System.Windows.Forms.ComboBox();
            this.McastGidncCntntsCd_label = new System.Windows.Forms.Label();
            this.ProductCode_textBox = new System.Windows.Forms.TextBox();
            this.MulticastConsNo_Title_label = new System.Windows.Forms.Label();
            this.MulticastConsNo_textBox = new System.Windows.Forms.TextBox();
            this.MulticastDate_Title_label = new System.Windows.Forms.Label();
            this.MulticastDate_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Area_label = new System.Windows.Forms.Label();
            this.Area_textBox = new System.Windows.Forms.TextBox();
            this.SupportOpenTime_Title_label = new System.Windows.Forms.Label();
            this.CustomerOpenTime_Title_label = new System.Windows.Forms.Label();
            this.ProgramChgDivCd_Title_label = new System.Windows.Forms.Label();
            this.MulticastSystemDivCd_Title_label = new System.Windows.Forms.Label();
            this.Guidance_label = new System.Windows.Forms.Label();
            this.SupportOpenTime_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.CustomerOpenTime_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ProgramChgDivCd_comboBox = new System.Windows.Forms.ComboBox();
            this.MulticastSystemDivCd_comboBox = new System.Windows.Forms.ComboBox();
            this.Guidance_textBox = new System.Windows.Forms.TextBox();
            this.ChangeContents_textBox = new System.Windows.Forms.TextBox();
            this.ChangeContents_groupBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Main_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.Update_label = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Save_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Cancel_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Initial_timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.ChangeContents_groupBox.SuspendLayout();
            this.Main_toolStripContainer.ContentPanel.SuspendLayout();
            this.Main_toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.Main_toolStripContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductCode_Title_label
            // 
            this.ProductCode_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCode_Title_label.AutoSize = true;
            this.ProductCode_Title_label.Location = new System.Drawing.Point(3, 31);
            this.ProductCode_Title_label.Name = "ProductCode_Title_label";
            this.ProductCode_Title_label.Size = new System.Drawing.Size(89, 12);
            this.ProductCode_Title_label.TabIndex = 0;
            this.ProductCode_Title_label.Text = "パッケージ区分";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.McastGidncCntntsCd_comboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.McastGidncCntntsCd_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProductCode_textBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProductCode_Title_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MulticastConsNo_Title_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.MulticastConsNo_textBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.MulticastDate_Title_label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.MulticastDate_maskedTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Area_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Area_textBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.SupportOpenTime_Title_label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CustomerOpenTime_Title_label, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProgramChgDivCd_Title_label, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.MulticastSystemDivCd_Title_label, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Guidance_label, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.SupportOpenTime_maskedTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CustomerOpenTime_maskedTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProgramChgDivCd_comboBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.MulticastSystemDivCd_comboBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Guidance_textBox, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(668, 127);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // McastGidncCntntsCd_comboBox
            // 
            this.McastGidncCntntsCd_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.McastGidncCntntsCd_comboBox.Enabled = false;
            this.McastGidncCntntsCd_comboBox.FormattingEnabled = true;
            this.McastGidncCntntsCd_comboBox.Location = new System.Drawing.Point(123, 3);
            this.McastGidncCntntsCd_comboBox.Name = "McastGidncCntntsCd_comboBox";
            this.McastGidncCntntsCd_comboBox.Size = new System.Drawing.Size(182, 20);
            this.McastGidncCntntsCd_comboBox.TabIndex = 0;
            // 
            // McastGidncCntntsCd_label
            // 
            this.McastGidncCntntsCd_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.McastGidncCntntsCd_label.AutoSize = true;
            this.McastGidncCntntsCd_label.Location = new System.Drawing.Point(3, 6);
            this.McastGidncCntntsCd_label.Name = "McastGidncCntntsCd_label";
            this.McastGidncCntntsCd_label.Size = new System.Drawing.Size(53, 12);
            this.McastGidncCntntsCd_label.TabIndex = 3;
            this.McastGidncCntntsCd_label.Text = "案内区分";
            // 
            // ProductCode_textBox
            // 
            this.ProductCode_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCode_textBox.Enabled = false;
            this.ProductCode_textBox.Location = new System.Drawing.Point(123, 28);
            this.ProductCode_textBox.MaxLength = 32;
            this.ProductCode_textBox.Name = "ProductCode_textBox";
            this.ProductCode_textBox.Size = new System.Drawing.Size(188, 19);
            this.ProductCode_textBox.TabIndex = 1;
            this.ProductCode_textBox.Text = "12345678901234567890123456789012";
            // 
            // MulticastConsNo_Title_label
            // 
            this.MulticastConsNo_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastConsNo_Title_label.AutoSize = true;
            this.MulticastConsNo_Title_label.Location = new System.Drawing.Point(3, 56);
            this.MulticastConsNo_Title_label.Name = "MulticastConsNo_Title_label";
            this.MulticastConsNo_Title_label.Size = new System.Drawing.Size(29, 12);
            this.MulticastConsNo_Title_label.TabIndex = 10;
            this.MulticastConsNo_Title_label.Text = "連番";
            // 
            // MulticastConsNo_textBox
            // 
            this.MulticastConsNo_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastConsNo_textBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MulticastConsNo_textBox.Location = new System.Drawing.Point(123, 53);
            this.MulticastConsNo_textBox.MaxLength = 4;
            this.MulticastConsNo_textBox.Name = "MulticastConsNo_textBox";
            this.MulticastConsNo_textBox.Size = new System.Drawing.Size(35, 19);
            this.MulticastConsNo_textBox.TabIndex = 2;
            this.MulticastConsNo_textBox.Text = "1234";
            // 
            // MulticastDate_Title_label
            // 
            this.MulticastDate_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastDate_Title_label.AutoSize = true;
            this.MulticastDate_Title_label.Location = new System.Drawing.Point(3, 81);
            this.MulticastDate_Title_label.Name = "MulticastDate_Title_label";
            this.MulticastDate_Title_label.Size = new System.Drawing.Size(65, 12);
            this.MulticastDate_Title_label.TabIndex = 12;
            this.MulticastDate_Title_label.Text = "リリース日";
            // 
            // MulticastDate_maskedTextBox
            // 
            this.MulticastDate_maskedTextBox.AsciiOnly = true;
            this.MulticastDate_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MulticastDate_maskedTextBox.Location = new System.Drawing.Point(123, 78);
            this.MulticastDate_maskedTextBox.Mask = "0000年90月90日";
            this.MulticastDate_maskedTextBox.Name = "MulticastDate_maskedTextBox";
            this.MulticastDate_maskedTextBox.Size = new System.Drawing.Size(93, 19);
            this.MulticastDate_maskedTextBox.TabIndex = 3;
            this.MulticastDate_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // Area_label
            // 
            this.Area_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Area_label.AutoSize = true;
            this.Area_label.Location = new System.Drawing.Point(3, 107);
            this.Area_label.Name = "Area_label";
            this.Area_label.Size = new System.Drawing.Size(89, 12);
            this.Area_label.TabIndex = 23;
            this.Area_label.Text = "地域(都道府県)";
            // 
            // Area_textBox
            // 
            this.Area_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Area_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Area_textBox.Location = new System.Drawing.Point(123, 104);
            this.Area_textBox.MaxLength = 4;
            this.Area_textBox.Name = "Area_textBox";
            this.Area_textBox.Size = new System.Drawing.Size(67, 19);
            this.Area_textBox.TabIndex = 4;
            this.Area_textBox.Text = "１２３４";
            // 
            // SupportOpenTime_Title_label
            // 
            this.SupportOpenTime_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SupportOpenTime_Title_label.AutoSize = true;
            this.SupportOpenTime_Title_label.Location = new System.Drawing.Point(337, 6);
            this.SupportOpenTime_Title_label.Name = "SupportOpenTime_Title_label";
            this.SupportOpenTime_Title_label.Size = new System.Drawing.Size(101, 12);
            this.SupportOpenTime_Title_label.TabIndex = 14;
            this.SupportOpenTime_Title_label.Text = "サポート公開日時";
            // 
            // CustomerOpenTime_Title_label
            // 
            this.CustomerOpenTime_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CustomerOpenTime_Title_label.AutoSize = true;
            this.CustomerOpenTime_Title_label.Location = new System.Drawing.Point(337, 31);
            this.CustomerOpenTime_Title_label.Name = "CustomerOpenTime_Title_label";
            this.CustomerOpenTime_Title_label.Size = new System.Drawing.Size(101, 12);
            this.CustomerOpenTime_Title_label.TabIndex = 16;
            this.CustomerOpenTime_Title_label.Text = "ユーザー公開日時";
            // 
            // ProgramChgDivCd_Title_label
            // 
            this.ProgramChgDivCd_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProgramChgDivCd_Title_label.AutoSize = true;
            this.ProgramChgDivCd_Title_label.Location = new System.Drawing.Point(337, 56);
            this.ProgramChgDivCd_Title_label.Name = "ProgramChgDivCd_Title_label";
            this.ProgramChgDivCd_Title_label.Size = new System.Drawing.Size(89, 12);
            this.ProgramChgDivCd_Title_label.TabIndex = 18;
            this.ProgramChgDivCd_Title_label.Text = "新規・改良区分";
            // 
            // MulticastSystemDivCd_Title_label
            // 
            this.MulticastSystemDivCd_Title_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MulticastSystemDivCd_Title_label.AutoSize = true;
            this.MulticastSystemDivCd_Title_label.Location = new System.Drawing.Point(337, 81);
            this.MulticastSystemDivCd_Title_label.Name = "MulticastSystemDivCd_Title_label";
            this.MulticastSystemDivCd_Title_label.Size = new System.Drawing.Size(101, 12);
            this.MulticastSystemDivCd_Title_label.TabIndex = 20;
            this.MulticastSystemDivCd_Title_label.Text = "配信システム区分";
            // 
            // Guidance_label
            // 
            this.Guidance_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Guidance_label.AutoSize = true;
            this.Guidance_label.Location = new System.Drawing.Point(337, 107);
            this.Guidance_label.Name = "Guidance_label";
            this.Guidance_label.Size = new System.Drawing.Size(53, 12);
            this.Guidance_label.TabIndex = 22;
            this.Guidance_label.Text = "帳票名称";
            // 
            // SupportOpenTime_maskedTextBox
            // 
            this.SupportOpenTime_maskedTextBox.AsciiOnly = true;
            this.SupportOpenTime_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SupportOpenTime_maskedTextBox.Location = new System.Drawing.Point(457, 3);
            this.SupportOpenTime_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.SupportOpenTime_maskedTextBox.Name = "SupportOpenTime_maskedTextBox";
            this.SupportOpenTime_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.SupportOpenTime_maskedTextBox.TabIndex = 5;
            this.SupportOpenTime_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // CustomerOpenTime_maskedTextBox
            // 
            this.CustomerOpenTime_maskedTextBox.AsciiOnly = true;
            this.CustomerOpenTime_maskedTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CustomerOpenTime_maskedTextBox.Location = new System.Drawing.Point(457, 28);
            this.CustomerOpenTime_maskedTextBox.Mask = "0000年90月90日 90時90分";
            this.CustomerOpenTime_maskedTextBox.Name = "CustomerOpenTime_maskedTextBox";
            this.CustomerOpenTime_maskedTextBox.Size = new System.Drawing.Size(149, 19);
            this.CustomerOpenTime_maskedTextBox.TabIndex = 6;
            this.CustomerOpenTime_maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ProgramChgDivCd_comboBox
            // 
            this.ProgramChgDivCd_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProgramChgDivCd_comboBox.FormattingEnabled = true;
            this.ProgramChgDivCd_comboBox.Location = new System.Drawing.Point(457, 53);
            this.ProgramChgDivCd_comboBox.Name = "ProgramChgDivCd_comboBox";
            this.ProgramChgDivCd_comboBox.Size = new System.Drawing.Size(105, 20);
            this.ProgramChgDivCd_comboBox.TabIndex = 7;
            // 
            // MulticastSystemDivCd_comboBox
            // 
            this.MulticastSystemDivCd_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MulticastSystemDivCd_comboBox.FormattingEnabled = true;
            this.MulticastSystemDivCd_comboBox.Location = new System.Drawing.Point(457, 78);
            this.MulticastSystemDivCd_comboBox.Name = "MulticastSystemDivCd_comboBox";
            this.MulticastSystemDivCd_comboBox.Size = new System.Drawing.Size(105, 20);
            this.MulticastSystemDivCd_comboBox.TabIndex = 8;
            // 
            // Guidance_textBox
            // 
            this.Guidance_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Guidance_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Guidance_textBox.Location = new System.Drawing.Point(457, 104);
            this.Guidance_textBox.MaxLength = 60;
            this.Guidance_textBox.Name = "Guidance_textBox";
            this.Guidance_textBox.Size = new System.Drawing.Size(188, 19);
            this.Guidance_textBox.TabIndex = 9;
            this.Guidance_textBox.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
                "2345678901234567890";
            // 
            // ChangeContents_textBox
            // 
            this.ChangeContents_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ChangeContents_textBox.Location = new System.Drawing.Point(8, 20);
            this.ChangeContents_textBox.Multiline = true;
            this.ChangeContents_textBox.Name = "ChangeContents_textBox";
            this.ChangeContents_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChangeContents_textBox.Size = new System.Drawing.Size(652, 152);
            this.ChangeContents_textBox.TabIndex = 0;
            // 
            // ChangeContents_groupBox
            // 
            this.ChangeContents_groupBox.Controls.Add(this.ChangeContents_textBox);
            this.ChangeContents_groupBox.Location = new System.Drawing.Point(5, 172);
            this.ChangeContents_groupBox.Name = "ChangeContents_groupBox";
            this.ChangeContents_groupBox.Size = new System.Drawing.Size(668, 180);
            this.ChangeContents_groupBox.TabIndex = 1;
            this.ChangeContents_groupBox.TabStop = false;
            this.ChangeContents_groupBox.Text = "印字位置情報";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(678, 22);
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
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.Main_toolStripContainer.ContentPanel.Controls.Add(this.ChangeContents_groupBox);
            this.Main_toolStripContainer.ContentPanel.Size = new System.Drawing.Size(678, 357);
            this.Main_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.Main_toolStripContainer.Name = "Main_toolStripContainer";
            this.Main_toolStripContainer.Size = new System.Drawing.Size(678, 382);
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
            this.Update_label.Location = new System.Drawing.Point(550, 5);
            this.Update_label.Name = "Update_label";
            this.Update_label.Size = new System.Drawing.Size(120, 20);
            this.Update_label.TabIndex = 4;
            this.Update_label.Text = "新規モード";
            this.Update_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // McastPrintPointInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 404);
            this.Controls.Add(this.Main_toolStripContainer);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "McastPrintPointInfoEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "印字位置リリース情報編集";
            this.Load += new System.EventHandler(this.MulticastInfoEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.MulticastInfoEditor_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MulticastInfoEditor_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ChangeContents_groupBox.ResumeLayout(false);
            this.ChangeContents_groupBox.PerformLayout();
            this.Main_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.Main_toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.Main_toolStripContainer.TopToolStripPanel.PerformLayout();
            this.Main_toolStripContainer.ResumeLayout(false);
            this.Main_toolStripContainer.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label ProductCode_Title_label;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label MulticastConsNo_Title_label;
		private System.Windows.Forms.Label MulticastDate_Title_label;
		private System.Windows.Forms.Label SupportOpenTime_Title_label;
		private System.Windows.Forms.Label CustomerOpenTime_Title_label;
		private System.Windows.Forms.TextBox Guidance_textBox;
        private System.Windows.Forms.TextBox MulticastConsNo_textBox;
		private System.Windows.Forms.TextBox ProductCode_textBox;
		private System.Windows.Forms.Label Guidance_label;
		private System.Windows.Forms.Label MulticastSystemDivCd_Title_label;
		private System.Windows.Forms.Label ProgramChgDivCd_Title_label;
		private System.Windows.Forms.TextBox ChangeContents_textBox;
		private System.Windows.Forms.GroupBox ChangeContents_groupBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer Main_toolStripContainer;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton Save_toolStripButton;
		private System.Windows.Forms.ToolStripButton Cancel_toolStripButton;
		private System.Windows.Forms.ComboBox MulticastSystemDivCd_comboBox;
        private System.Windows.Forms.ComboBox ProgramChgDivCd_comboBox;
		private System.Windows.Forms.MaskedTextBox CustomerOpenTime_maskedTextBox;
		private System.Windows.Forms.MaskedTextBox SupportOpenTime_maskedTextBox;
        private System.Windows.Forms.MaskedTextBox MulticastDate_maskedTextBox;
        private System.Windows.Forms.Timer Initial_timer;
        private System.Windows.Forms.ComboBox McastGidncCntntsCd_comboBox;
        private System.Windows.Forms.Label McastGidncCntntsCd_label;
        private System.Windows.Forms.TextBox Area_textBox;
        private System.Windows.Forms.Label Area_label;
        private System.Windows.Forms.Label Update_label;
	}
}