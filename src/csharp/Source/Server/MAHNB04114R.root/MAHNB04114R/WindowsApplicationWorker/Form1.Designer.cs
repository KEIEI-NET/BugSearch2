namespace WindowsApplicationWorker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param_csal name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param_csal>
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.enterpriseCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salesSlipCd = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.accRecDivCd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.sectionCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.salesDateSt = new System.Windows.Forms.TextBox();
            this.salesDateEd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.searchSlipDateEd = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.searchSlipDateSt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.frontEmployeeCd = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.salesEmployeeCd = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.claimCode = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.customerCode = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.goodsMakerCd = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.goodsNo = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.TopN = new System.Windows.Forms.TextBox();
            this.acptAnOdrStatus = new System.Windows.Forms.TextBox();
            this.salesInputCode = new System.Windows.Forms.TextBox();
            this.salesSlipNumSt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.LogicalMode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PartySaleSlipNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.salesSlipNumEd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ShipmentDayEd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ShipmentDaySt = new System.Windows.Forms.TextBox();
            this.EstimateDivide = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 202;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(790, 231);
            this.dataGridView1.TabIndex = 300;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 204;
            this.button2.Text = "TopSearch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 201;
            this.button3.Text = "Count";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // enterpriseCode
            // 
            this.enterpriseCode.Location = new System.Drawing.Point(112, 5);
            this.enterpriseCode.Name = "enterpriseCode";
            this.enterpriseCode.Size = new System.Drawing.Size(121, 19);
            this.enterpriseCode.TabIndex = 4;
            this.enterpriseCode.Text = "0101150842020000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "売上伝票区分";
            // 
            // salesSlipCd
            // 
            this.salesSlipCd.Location = new System.Drawing.Point(112, 27);
            this.salesSlipCd.Name = "salesSlipCd";
            this.salesSlipCd.Size = new System.Drawing.Size(121, 19);
            this.salesSlipCd.TabIndex = 5;
            this.salesSlipCd.Text = "0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel1.Text = "status";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel2.Text = "message";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(487, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 10);
            this.label5.TabIndex = 23;
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(570, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "data found.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "受注ステータス";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "売掛区分";
            // 
            // accRecDivCd
            // 
            this.accRecDivCd.Location = new System.Drawing.Point(112, 69);
            this.accRecDivCd.Name = "accRecDivCd";
            this.accRecDivCd.Size = new System.Drawing.Size(121, 19);
            this.accRecDivCd.TabIndex = 7;
            this.accRecDivCd.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "売上伝票番号";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(487, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 12);
            this.label15.TabIndex = 40;
            this.label15.Text = "拠点コード";
            // 
            // sectionCode
            // 
            this.sectionCode.Location = new System.Drawing.Point(587, 6);
            this.sectionCode.Name = "sectionCode";
            this.sectionCode.Size = new System.Drawing.Size(106, 19);
            this.sectionCode.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 115);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 42;
            this.label16.Text = "売上日付";
            // 
            // salesDateSt
            // 
            this.salesDateSt.Location = new System.Drawing.Point(112, 112);
            this.salesDateSt.Name = "salesDateSt";
            this.salesDateSt.Size = new System.Drawing.Size(106, 19);
            this.salesDateSt.TabIndex = 100;
            this.salesDateSt.Text = "0";
            // 
            // salesDateEd
            // 
            this.salesDateEd.Location = new System.Drawing.Point(244, 113);
            this.salesDateEd.Name = "salesDateEd";
            this.salesDateEd.Size = new System.Drawing.Size(106, 19);
            this.salesDateEd.TabIndex = 101;
            this.salesDateEd.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(221, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 44;
            this.label17.Text = "～";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(221, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 48;
            this.label18.Text = "～";
            // 
            // searchSlipDateEd
            // 
            this.searchSlipDateEd.Location = new System.Drawing.Point(244, 135);
            this.searchSlipDateEd.Name = "searchSlipDateEd";
            this.searchSlipDateEd.Size = new System.Drawing.Size(106, 19);
            this.searchSlipDateEd.TabIndex = 103;
            this.searchSlipDateEd.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 137);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 46;
            this.label19.Text = "伝票検索日付";
            // 
            // searchSlipDateSt
            // 
            this.searchSlipDateSt.Location = new System.Drawing.Point(112, 134);
            this.searchSlipDateSt.Name = "searchSlipDateSt";
            this.searchSlipDateSt.Size = new System.Drawing.Size(106, 19);
            this.searchSlipDateSt.TabIndex = 102;
            this.searchSlipDateSt.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(255, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 12);
            this.label20.TabIndex = 50;
            this.label20.Text = "受付従業員コード";
            // 
            // frontEmployeeCd
            // 
            this.frontEmployeeCd.Location = new System.Drawing.Point(358, 6);
            this.frontEmployeeCd.Name = "frontEmployeeCd";
            this.frontEmployeeCd.Size = new System.Drawing.Size(106, 19);
            this.frontEmployeeCd.TabIndex = 14;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(255, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 12);
            this.label21.TabIndex = 52;
            this.label21.Text = "販売従業員コード";
            // 
            // salesEmployeeCd
            // 
            this.salesEmployeeCd.Location = new System.Drawing.Point(358, 27);
            this.salesEmployeeCd.Name = "salesEmployeeCd";
            this.salesEmployeeCd.Size = new System.Drawing.Size(106, 19);
            this.salesEmployeeCd.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(255, 93);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 12);
            this.label22.TabIndex = 54;
            this.label22.Text = "請求先コード";
            // 
            // claimCode
            // 
            this.claimCode.Location = new System.Drawing.Point(358, 92);
            this.claimCode.Name = "claimCode";
            this.claimCode.Size = new System.Drawing.Size(106, 19);
            this.claimCode.TabIndex = 19;
            this.claimCode.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(255, 72);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 12);
            this.label26.TabIndex = 62;
            this.label26.Text = "得意先コード";
            // 
            // customerCode
            // 
            this.customerCode.Location = new System.Drawing.Point(358, 69);
            this.customerCode.Name = "customerCode";
            this.customerCode.Size = new System.Drawing.Size(106, 19);
            this.customerCode.TabIndex = 20;
            this.customerCode.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(487, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(93, 12);
            this.label31.TabIndex = 76;
            this.label31.Text = "商品メーカーコード";
            // 
            // goodsMakerCd
            // 
            this.goodsMakerCd.Location = new System.Drawing.Point(587, 27);
            this.goodsMakerCd.Name = "goodsMakerCd";
            this.goodsMakerCd.Size = new System.Drawing.Size(106, 19);
            this.goodsMakerCd.TabIndex = 26;
            this.goodsMakerCd.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(487, 51);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 78;
            this.label32.Text = "商品番号";
            // 
            // goodsNo
            // 
            this.goodsNo.Location = new System.Drawing.Point(587, 48);
            this.goodsNo.Name = "goodsNo";
            this.goodsNo.Size = new System.Drawing.Size(106, 19);
            this.goodsNo.TabIndex = 27;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(714, 295);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(78, 12);
            this.label42.TabIndex = 98;
            this.label42.Text = "rows selected.";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(631, 295);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 10);
            this.label43.TabIndex = 97;
            this.label43.Text = "0";
            this.label43.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TopN
            // 
            this.TopN.Location = new System.Drawing.Point(254, 290);
            this.TopN.Name = "TopN";
            this.TopN.Size = new System.Drawing.Size(49, 19);
            this.TopN.TabIndex = 203;
            // 
            // acptAnOdrStatus
            // 
            this.acptAnOdrStatus.Location = new System.Drawing.Point(112, 48);
            this.acptAnOdrStatus.Name = "acptAnOdrStatus";
            this.acptAnOdrStatus.Size = new System.Drawing.Size(121, 19);
            this.acptAnOdrStatus.TabIndex = 301;
            this.acptAnOdrStatus.Text = "30";
            // 
            // salesInputCode
            // 
            this.salesInputCode.Location = new System.Drawing.Point(358, 48);
            this.salesInputCode.Name = "salesInputCode";
            this.salesInputCode.Size = new System.Drawing.Size(106, 19);
            this.salesInputCode.TabIndex = 304;
            // 
            // salesSlipNumSt
            // 
            this.salesSlipNumSt.Location = new System.Drawing.Point(112, 191);
            this.salesSlipNumSt.Name = "salesSlipNumSt";
            this.salesSlipNumSt.Size = new System.Drawing.Size(121, 19);
            this.salesSlipNumSt.TabIndex = 305;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 12);
            this.label8.TabIndex = 307;
            this.label8.Text = "売上入力者コード";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 308;
            this.button4.Text = "DetailSearch";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // LogicalMode
            // 
            this.LogicalMode.Location = new System.Drawing.Point(112, 169);
            this.LogicalMode.Name = "LogicalMode";
            this.LogicalMode.Size = new System.Drawing.Size(121, 19);
            this.LogicalMode.TabIndex = 309;
            this.LogicalMode.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 310;
            this.label4.Text = "論理削除区分";
            // 
            // PartySaleSlipNum
            // 
            this.PartySaleSlipNum.Location = new System.Drawing.Point(112, 215);
            this.PartySaleSlipNum.Name = "PartySaleSlipNum";
            this.PartySaleSlipNum.Size = new System.Drawing.Size(121, 19);
            this.PartySaleSlipNum.TabIndex = 312;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 311;
            this.label10.Text = "相手先伝票番号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 313;
            this.label11.Text = "～";
            // 
            // salesSlipNumEd
            // 
            this.salesSlipNumEd.Location = new System.Drawing.Point(265, 191);
            this.salesSlipNumEd.Name = "salesSlipNumEd";
            this.salesSlipNumEd.Size = new System.Drawing.Size(121, 19);
            this.salesSlipNumEd.TabIndex = 314;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 316;
            this.label12.Text = "～";
            // 
            // ShipmentDayEd
            // 
            this.ShipmentDayEd.Location = new System.Drawing.Point(588, 113);
            this.ShipmentDayEd.Name = "ShipmentDayEd";
            this.ShipmentDayEd.Size = new System.Drawing.Size(106, 19);
            this.ShipmentDayEd.TabIndex = 318;
            this.ShipmentDayEd.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(356, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 315;
            this.label13.Text = "出荷日付";
            // 
            // ShipmentDaySt
            // 
            this.ShipmentDaySt.Location = new System.Drawing.Point(456, 112);
            this.ShipmentDaySt.Name = "ShipmentDaySt";
            this.ShipmentDaySt.Size = new System.Drawing.Size(106, 19);
            this.ShipmentDaySt.TabIndex = 317;
            this.ShipmentDaySt.Text = "0";
            // 
            // EstimateDivide
            // 
            this.EstimateDivide.Location = new System.Drawing.Point(456, 135);
            this.EstimateDivide.Name = "EstimateDivide";
            this.EstimateDivide.Size = new System.Drawing.Size(106, 19);
            this.EstimateDivide.TabIndex = 319;
            this.EstimateDivide.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(356, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 320;
            this.label14.Text = "見積区分";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.EstimateDivide);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ShipmentDayEd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ShipmentDaySt);
            this.Controls.Add(this.salesSlipNumEd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PartySaleSlipNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogicalMode);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.salesSlipNumSt);
            this.Controls.Add(this.salesInputCode);
            this.Controls.Add(this.acptAnOdrStatus);
            this.Controls.Add(this.TopN);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.goodsNo);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.goodsMakerCd);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.customerCode);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.claimCode);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.salesEmployeeCd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.frontEmployeeCd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.searchSlipDateEd);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.searchSlipDateSt);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.salesDateEd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.salesDateSt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.sectionCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.accRecDivCd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salesSlipCd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterpriseCode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox enterpriseCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox salesSlipCd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox accRecDivCd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox sectionCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox salesDateSt;
        private System.Windows.Forms.TextBox salesDateEd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox searchSlipDateEd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox searchSlipDateSt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox frontEmployeeCd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox salesEmployeeCd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox claimCode;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox customerCode;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox goodsMakerCd;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox goodsNo;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox TopN;
        private System.Windows.Forms.TextBox acptAnOdrStatus;
        private System.Windows.Forms.TextBox salesInputCode;
        private System.Windows.Forms.TextBox salesSlipNumSt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox LogicalMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PartySaleSlipNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox salesSlipNumEd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ShipmentDayEd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ShipmentDaySt;
        private System.Windows.Forms.TextBox EstimateDivide;
        private System.Windows.Forms.Label label14;
    }
}

