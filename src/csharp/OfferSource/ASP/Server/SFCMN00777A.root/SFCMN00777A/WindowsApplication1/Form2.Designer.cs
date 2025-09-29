namespace WindowsApplication1
{
    partial class Form2
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.ProdustCodeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.McastofferDivCdcombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateGroup1Text = new System.Windows.Forms.TextBox();
            this.UpdateGroup2Text = new System.Windows.Forms.TextBox();
            this.UpdateGroup3Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EnterpriseCodeText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StandardDateText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OpenDtTmDivCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MulticastVerText = new System.Windows.Forms.TextBox();
            this.MulticastConsNoText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MulticastSubCodeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.EdMulticastVerText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.StMulticastVerText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ChangeContents3Text = new System.Windows.Forms.TextBox();
            this.ChangeContents2Text = new System.Windows.Forms.TextBox();
            this.ChangeContents1Text = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.MulticastProgramNameText = new System.Windows.Forms.TextBox();
            this.MulticastSystemDivCdcombo = new System.Windows.Forms.ComboBox();
            this.maxCountText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(12, 473);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 21;
            this.dataGridView3.Size = new System.Drawing.Size(992, 216);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(854, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 29);
            this.button4.TabIndex = 50;
            this.button4.Text = "Search ChangGidnc";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ProdustCodeText
            // 
            this.ProdustCodeText.Location = new System.Drawing.Point(113, 34);
            this.ProdustCodeText.Name = "ProdustCodeText";
            this.ProdustCodeText.Size = new System.Drawing.Size(85, 19);
            this.ProdustCodeText.TabIndex = 2;
            this.ProdustCodeText.Text = "SuperFrontman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "パッケージ区分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "配信提供区分";
            // 
            // McastofferDivCdcombo
            // 
            this.McastofferDivCdcombo.FormattingEnabled = true;
            this.McastofferDivCdcombo.Items.AddRange(new object[] {
            "マージ",
            "標準",
            "個別"});
            this.McastofferDivCdcombo.Location = new System.Drawing.Point(112, 58);
            this.McastofferDivCdcombo.Name = "McastofferDivCdcombo";
            this.McastofferDivCdcombo.Size = new System.Drawing.Size(87, 20);
            this.McastofferDivCdcombo.TabIndex = 3;
            this.McastofferDivCdcombo.Text = "標準";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "更新グループコード";
            // 
            // UpdateGroup1Text
            // 
            this.UpdateGroup1Text.Location = new System.Drawing.Point(113, 82);
            this.UpdateGroup1Text.Name = "UpdateGroup1Text";
            this.UpdateGroup1Text.Size = new System.Drawing.Size(31, 19);
            this.UpdateGroup1Text.TabIndex = 4;
            // 
            // UpdateGroup2Text
            // 
            this.UpdateGroup2Text.Location = new System.Drawing.Point(150, 82);
            this.UpdateGroup2Text.Name = "UpdateGroup2Text";
            this.UpdateGroup2Text.Size = new System.Drawing.Size(31, 19);
            this.UpdateGroup2Text.TabIndex = 5;
            // 
            // UpdateGroup3Text
            // 
            this.UpdateGroup3Text.Location = new System.Drawing.Point(187, 82);
            this.UpdateGroup3Text.Name = "UpdateGroup3Text";
            this.UpdateGroup3Text.Size = new System.Drawing.Size(31, 19);
            this.UpdateGroup3Text.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "企業コード";
            // 
            // EnterpriseCodeText
            // 
            this.EnterpriseCodeText.Location = new System.Drawing.Point(114, 106);
            this.EnterpriseCodeText.Name = "EnterpriseCodeText";
            this.EnterpriseCodeText.Size = new System.Drawing.Size(124, 19);
            this.EnterpriseCodeText.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "基準日";
            // 
            // StandardDateText
            // 
            this.StandardDateText.Location = new System.Drawing.Point(114, 129);
            this.StandardDateText.Name = "StandardDateText";
            this.StandardDateText.Size = new System.Drawing.Size(85, 19);
            this.StandardDateText.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "公開日時区分";
            // 
            // OpenDtTmDivCombo
            // 
            this.OpenDtTmDivCombo.FormattingEnabled = true;
            this.OpenDtTmDivCombo.Items.AddRange(new object[] {
            "",
            "全て",
            "サポート公開日時",
            "ユーザー公開日時"});
            this.OpenDtTmDivCombo.Location = new System.Drawing.Point(114, 153);
            this.OpenDtTmDivCombo.Name = "OpenDtTmDivCombo";
            this.OpenDtTmDivCombo.Size = new System.Drawing.Size(85, 20);
            this.OpenDtTmDivCombo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "配信バージョン";
            // 
            // MulticastVerText
            // 
            this.MulticastVerText.Location = new System.Drawing.Point(114, 178);
            this.MulticastVerText.Name = "MulticastVerText";
            this.MulticastVerText.Size = new System.Drawing.Size(85, 19);
            this.MulticastVerText.TabIndex = 10;
            // 
            // MulticastConsNoText
            // 
            this.MulticastConsNoText.Location = new System.Drawing.Point(114, 200);
            this.MulticastConsNoText.Name = "MulticastConsNoText";
            this.MulticastConsNoText.Size = new System.Drawing.Size(85, 19);
            this.MulticastConsNoText.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "配信連番";
            // 
            // MulticastSubCodeText
            // 
            this.MulticastSubCodeText.Location = new System.Drawing.Point(113, 222);
            this.MulticastSubCodeText.Name = "MulticastSubCodeText";
            this.MulticastSubCodeText.Size = new System.Drawing.Size(85, 19);
            this.MulticastSubCodeText.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "配信サブコード";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(680, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "配信日開始";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(852, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "配信日終了";
            // 
            // EdMulticastVerText
            // 
            this.EdMulticastVerText.Location = new System.Drawing.Point(375, 33);
            this.EdMulticastVerText.Name = "EdMulticastVerText";
            this.EdMulticastVerText.Size = new System.Drawing.Size(85, 19);
            this.EdMulticastVerText.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 12);
            this.label12.TabIndex = 35;
            this.label12.Text = "配信バージョン終了";
            // 
            // StMulticastVerText
            // 
            this.StMulticastVerText.Location = new System.Drawing.Point(375, 11);
            this.StMulticastVerText.Name = "StMulticastVerText";
            this.StMulticastVerText.Size = new System.Drawing.Size(85, 19);
            this.StMulticastVerText.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(270, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "配信バージョン開始";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 12);
            this.label14.TabIndex = 37;
            this.label14.Text = "配信システム区分";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(270, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "変更内容";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 251);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(992, 216);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.TabStop = false;
            // 
            // ChangeContents3Text
            // 
            this.ChangeContents3Text.Location = new System.Drawing.Point(375, 126);
            this.ChangeContents3Text.Name = "ChangeContents3Text";
            this.ChangeContents3Text.Size = new System.Drawing.Size(138, 19);
            this.ChangeContents3Text.TabIndex = 18;
            // 
            // ChangeContents2Text
            // 
            this.ChangeContents2Text.Location = new System.Drawing.Point(375, 103);
            this.ChangeContents2Text.Name = "ChangeContents2Text";
            this.ChangeContents2Text.Size = new System.Drawing.Size(138, 19);
            this.ChangeContents2Text.TabIndex = 17;
            // 
            // ChangeContents1Text
            // 
            this.ChangeContents1Text.Location = new System.Drawing.Point(375, 80);
            this.ChangeContents1Text.Name = "ChangeContents1Text";
            this.ChangeContents1Text.Size = new System.Drawing.Size(138, 19);
            this.ChangeContents1Text.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(270, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 12);
            this.label16.TabIndex = 43;
            this.label16.Text = "配信PG名称";
            // 
            // MulticastProgramNameText
            // 
            this.MulticastProgramNameText.Location = new System.Drawing.Point(375, 149);
            this.MulticastProgramNameText.Name = "MulticastProgramNameText";
            this.MulticastProgramNameText.Size = new System.Drawing.Size(138, 19);
            this.MulticastProgramNameText.TabIndex = 19;
            // 
            // MulticastSystemDivCdcombo
            // 
            this.MulticastSystemDivCdcombo.FormattingEnabled = true;
            this.MulticastSystemDivCdcombo.Items.AddRange(new object[] {
            "",
            "全て",
            "共通",
            "整備",
            "鈑金",
            "車販"});
            this.MulticastSystemDivCdcombo.Location = new System.Drawing.Point(375, 56);
            this.MulticastSystemDivCdcombo.Name = "MulticastSystemDivCdcombo";
            this.MulticastSystemDivCdcombo.Size = new System.Drawing.Size(85, 20);
            this.MulticastSystemDivCdcombo.TabIndex = 15;
            // 
            // maxCountText
            // 
            this.maxCountText.Location = new System.Drawing.Point(428, 222);
            this.maxCountText.Name = "maxCountText";
            this.maxCountText.Size = new System.Drawing.Size(85, 19);
            this.maxCountText.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(367, 225);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 46;
            this.label17.Text = "最大件数";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(682, 37);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 48;
            this.monthCalendar1.TabStop = false;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(854, 37);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 49;
            this.monthCalendar2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(751, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 16);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(923, 9);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 16);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "共通",
            "プログラム配信",
            "サーバーメンテナンス",
            "印字位置リリース"});
            this.comboBox1.Location = new System.Drawing.Point(113, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "共通";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 53;
            this.label18.Text = "案内区分";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(375, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 19);
            this.textBox1.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(270, 178);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 54;
            this.label19.Text = "地域";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(682, 217);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 55;
            this.checkBox3.Text = "全件抽出";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 701);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.maxCountText);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.MulticastSystemDivCdcombo);
            this.Controls.Add(this.MulticastProgramNameText);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ChangeContents3Text);
            this.Controls.Add(this.ChangeContents2Text);
            this.Controls.Add(this.ChangeContents1Text);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.EdMulticastVerText);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.StMulticastVerText);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MulticastSubCodeText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.MulticastConsNoText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MulticastVerText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.OpenDtTmDivCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.StandardDateText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EnterpriseCodeText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpdateGroup3Text);
            this.Controls.Add(this.UpdateGroup2Text);
            this.Controls.Add(this.UpdateGroup1Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.McastofferDivCdcombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProdustCodeText);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Windows
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox ProdustCodeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox McastofferDivCdcombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UpdateGroup1Text;
        private System.Windows.Forms.TextBox UpdateGroup2Text;
        private System.Windows.Forms.TextBox UpdateGroup3Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EnterpriseCodeText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StandardDateText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox OpenDtTmDivCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MulticastVerText;
        private System.Windows.Forms.TextBox MulticastConsNoText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox MulticastSubCodeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox EdMulticastVerText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox StMulticastVerText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox ChangeContents3Text;
        private System.Windows.Forms.TextBox ChangeContents2Text;
        private System.Windows.Forms.TextBox ChangeContents1Text;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox MulticastProgramNameText;
        private System.Windows.Forms.ComboBox MulticastSystemDivCdcombo;
        private System.Windows.Forms.TextBox maxCountText;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox checkBox3;

    }
}