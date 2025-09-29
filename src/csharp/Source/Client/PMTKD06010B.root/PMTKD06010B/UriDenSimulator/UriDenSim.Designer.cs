namespace UriDenSimulator
{
    partial class UriDenSim
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kind");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Value");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Kind");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Value");
            this.txtMakerCd = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtModelSubCd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRui2 = new System.Windows.Forms.TextBox();
            this.txtRui1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEngine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNensiki = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKatasiki = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSyadai = new System.Windows.Forms.TextBox();
            this.tDateEdit_FirstEntryDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtSyamei = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gridColor = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.gridTrim = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.gridSoubi = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSoubi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMakerCd
            // 
            this.txtMakerCd.Location = new System.Drawing.Point(437, 16);
            this.txtMakerCd.Name = "txtMakerCd";
            this.txtMakerCd.Size = new System.Drawing.Size(33, 19);
            this.txtMakerCd.TabIndex = 5;
            this.txtMakerCd.Leave += new System.EventHandler(this.txtMakerCd_Leave);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(476, 16);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(43, 19);
            this.txtModel.TabIndex = 6;
            this.txtModel.Leave += new System.EventHandler(this.txtModel_Leave);
            // 
            // txtModelSubCd
            // 
            this.txtModelSubCd.Location = new System.Drawing.Point(525, 16);
            this.txtModelSubCd.Name = "txtModelSubCd";
            this.txtModelSubCd.Size = new System.Drawing.Size(43, 19);
            this.txtModelSubCd.TabIndex = 7;
            this.txtModelSubCd.Leave += new System.EventHandler(this.txtModelSubCd_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "車種";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "類別";
            // 
            // txtRui2
            // 
            this.txtRui2.Location = new System.Drawing.Point(126, 45);
            this.txtRui2.Name = "txtRui2";
            this.txtRui2.Size = new System.Drawing.Size(64, 19);
            this.txtRui2.TabIndex = 2;
            this.txtRui2.Leave += new System.EventHandler(this.txtRui2_Leave);
            // 
            // txtRui1
            // 
            this.txtRui1.Location = new System.Drawing.Point(54, 45);
            this.txtRui1.Name = "txtRui1";
            this.txtRui1.Size = new System.Drawing.Size(64, 19);
            this.txtRui1.TabIndex = 1;
            this.txtRui1.Leave += new System.EventHandler(this.txtRui1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "エンジン型式";
            // 
            // txtEngine
            // 
            this.txtEngine.Location = new System.Drawing.Point(272, 45);
            this.txtEngine.Name = "txtEngine";
            this.txtEngine.Size = new System.Drawing.Size(89, 19);
            this.txtEngine.TabIndex = 3;
            this.txtEngine.Leave += new System.EventHandler(this.txtEngine_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "年式";
            // 
            // txtNensiki
            // 
            this.txtNensiki.Location = new System.Drawing.Point(566, 45);
            this.txtNensiki.Name = "txtNensiki";
            this.txtNensiki.Size = new System.Drawing.Size(114, 19);
            this.txtNensiki.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "カラー";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(728, 45);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(91, 19);
            this.textBox5.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(686, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "トリム";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(728, 80);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(91, 19);
            this.textBox6.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "型式";
            // 
            // txtKatasiki
            // 
            this.txtKatasiki.Location = new System.Drawing.Point(54, 76);
            this.txtKatasiki.Name = "txtKatasiki";
            this.txtKatasiki.Size = new System.Drawing.Size(307, 19);
            this.txtKatasiki.TabIndex = 4;
            this.txtKatasiki.Leave += new System.EventHandler(this.txtKatasiki_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "車台番号";
            // 
            // txtSyadai
            // 
            this.txtSyadai.Location = new System.Drawing.Point(436, 77);
            this.txtSyadai.Name = "txtSyadai";
            this.txtSyadai.Size = new System.Drawing.Size(193, 19);
            this.txtSyadai.TabIndex = 40;
            // 
            // tDateEdit_FirstEntryDate
            // 
            appearance168.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_FirstEntryDate.ActiveEditAppearance = appearance168;
            this.tDateEdit_FirstEntryDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_FirstEntryDate.CalendarDisp = true;
            this.tDateEdit_FirstEntryDate.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance132.TextHAlignAsString = "Left";
            appearance132.TextVAlignAsString = "Middle";
            this.tDateEdit_FirstEntryDate.EditAppearance = appearance132;
            this.tDateEdit_FirstEntryDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_FirstEntryDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance133.TextHAlignAsString = "Left";
            appearance133.TextVAlignAsString = "Bottom";
            this.tDateEdit_FirstEntryDate.LabelAppearance = appearance133;
            this.tDateEdit_FirstEntryDate.Location = new System.Drawing.Point(437, 43);
            this.tDateEdit_FirstEntryDate.Name = "tDateEdit_FirstEntryDate";
            this.tDateEdit_FirstEntryDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_FirstEntryDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_FirstEntryDate.Size = new System.Drawing.Size(118, 21);
            this.tDateEdit_FirstEntryDate.TabIndex = 11;
            this.tDateEdit_FirstEntryDate.TabStop = true;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;            
            this.ultraGrid1.Location = new System.Drawing.Point(10, 124);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(808, 77);
            this.ultraGrid1.TabIndex = 42;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // txtSyamei
            // 
            this.txtSyamei.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSyamei.Location = new System.Drawing.Point(574, 16);
            this.txtSyamei.Name = "txtSyamei";
            this.txtSyamei.ReadOnly = true;
            this.txtSyamei.Size = new System.Drawing.Size(201, 19);
            this.txtSyamei.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "プレート";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(272, 20);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(89, 19);
            this.txtPlate.TabIndex = 0;
            this.txtPlate.Leave += new System.EventHandler(this.txtPlate_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 12);
            this.label10.TabIndex = 47;
            this.label10.Text = "カラー";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(281, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 12);
            this.label11.TabIndex = 48;
            this.label11.Text = "トリム";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(539, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 49;
            this.label12.Text = "装備";
            // 
            // gridColor
            // 
            this.gridColor.Location = new System.Drawing.Point(10, 219);
            this.gridColor.Name = "gridColor";
            this.gridColor.Size = new System.Drawing.Size(260, 437);
            this.gridColor.TabIndex = 50;
            // 
            // gridTrim
            // 
            this.gridTrim.Location = new System.Drawing.Point(276, 219);
            this.gridTrim.Name = "gridTrim";
            this.gridTrim.Size = new System.Drawing.Size(260, 437);
            this.gridTrim.TabIndex = 51;
            // 
            // gridSoubi
            // 
            this.gridSoubi.DataSource = this.ultraDataSource1;
            ultraGridColumn1.Header.Caption = "装備名称";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "装備有無";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 114;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.gridSoubi.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridSoubi.Location = new System.Drawing.Point(542, 219);
            this.gridSoubi.Name = "gridSoubi";
            this.gridSoubi.Size = new System.Drawing.Size(260, 437);
            this.gridSoubi.TabIndex = 52;
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2});
            // 
            // UriDenSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 668);
            this.Controls.Add(this.gridSoubi);
            this.Controls.Add(this.gridTrim);
            this.Controls.Add(this.gridColor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.txtSyamei);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSyadai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKatasiki);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNensiki);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEngine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRui2);
            this.Controls.Add(this.txtRui1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModelSubCd);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMakerCd);
            this.Controls.Add(this.tDateEdit_FirstEntryDate);
            this.Name = "UriDenSim";
            this.Text = "売伝";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSoubi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMakerCd;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtModelSubCd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRui2;
        private System.Windows.Forms.TextBox txtRui1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEngine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNensiki;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKatasiki;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSyadai;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_FirstEntryDate;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.TextBox txtSyamei;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridColor;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridTrim;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridSoubi;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
    }
}

