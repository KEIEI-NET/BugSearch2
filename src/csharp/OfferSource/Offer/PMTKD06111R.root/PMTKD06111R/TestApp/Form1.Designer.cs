namespace RemoteTestApplication
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CategoryModel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.ModelSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EngineSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ModelPlateSearch = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(997, 507);
            this.dataGridView1.TabIndex = 10;
            // 
            // CategoryModel
            // 
            this.CategoryModel.Location = new System.Drawing.Point(393, 109);
            this.CategoryModel.Name = "CategoryModel";
            this.CategoryModel.Size = new System.Drawing.Size(111, 24);
            this.CategoryModel.TabIndex = 10;
            this.CategoryModel.Text = "類別検索";
            this.CategoryModel.UseVisualStyleBackColor = true;
            this.CategoryModel.Click += new System.EventHandler(this.CategoryModel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox1, "メーカーコードを入力して下さい。");
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(197, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox2, "車種コードを入力して下さい。");
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(302, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox3, "車種サブコードを入力して下さい。");
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(499, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox4, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "車両型式";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(606, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(104, 19);
            this.textBox5.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox5, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(92, 69);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(104, 19);
            this.textBox6.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox6, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(271, 70);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(104, 19);
            this.textBox7.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textBox7, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(501, 68);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(42, 19);
            this.textBox8.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBox8, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(559, 68);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(43, 19);
            this.textBox9.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textBox9, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(622, 68);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(43, 19);
            this.textBox10.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBox10, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // ModelSearch
            // 
            this.ModelSearch.Location = new System.Drawing.Point(510, 109);
            this.ModelSearch.Name = "ModelSearch";
            this.ModelSearch.Size = new System.Drawing.Size(111, 24);
            this.ModelSearch.TabIndex = 11;
            this.ModelSearch.Text = "型式検索";
            this.ModelSearch.UseVisualStyleBackColor = true;
            this.ModelSearch.Click += new System.EventHandler(this.ModelSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(873, 109);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(136, 24);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "× 検索条件消去";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(864, 25);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(17, 12);
            this.lblMsg.TabIndex = 13;
            this.lblMsg.Text = "   ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "類別/型式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "エンジン";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "プレート";
            // 
            // EngineSearch
            // 
            this.EngineSearch.Location = new System.Drawing.Point(744, 109);
            this.EngineSearch.Name = "EngineSearch";
            this.EngineSearch.Size = new System.Drawing.Size(111, 24);
            this.EngineSearch.TabIndex = 12;
            this.EngineSearch.Text = "エンジン検索";
            this.EngineSearch.UseVisualStyleBackColor = true;
            this.EngineSearch.Click += new System.EventHandler(this.EngineSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(433, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "車種コード";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "ExhaustGasSign";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(197, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "SeriesModel";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(302, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 12);
            this.label13.TabIndex = 35;
            this.label13.Text = "CategorySignModel";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(606, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 37;
            this.label14.Text = "CategoryNo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(499, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "ModelDesignationNo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(95, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 12);
            this.label16.TabIndex = 38;
            this.label16.Text = "EngineModelNm";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(622, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 12);
            this.label17.TabIndex = 41;
            this.label17.Text = "ModelSubCode";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(559, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 12);
            this.label18.TabIndex = 40;
            this.label18.Text = "ModelCode";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(499, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 12);
            this.label19.TabIndex = 39;
            this.label19.Text = "MakerCode";
            // 
            // ModelPlateSearch
            // 
            this.ModelPlateSearch.Location = new System.Drawing.Point(627, 109);
            this.ModelPlateSearch.Name = "ModelPlateSearch";
            this.ModelPlateSearch.Size = new System.Drawing.Size(111, 24);
            this.ModelPlateSearch.TabIndex = 42;
            this.ModelPlateSearch.Text = "ﾓﾃﾞﾙﾌﾟﾚｰﾄ検索";
            this.ModelPlateSearch.UseVisualStyleBackColor = true;
            this.ModelPlateSearch.Click += new System.EventHandler(this.ModelPlateSearch_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 117);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 43;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "車種情報";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(138, 117);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 44;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "型式情報";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "検索結果";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.ModelPlateSearch);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.EngineSearch);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ModelSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CategoryModel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "型式検索テスト";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CategoryModel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ModelSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblMsg;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button EngineSearch;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button ModelPlateSearch;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
    }
}

