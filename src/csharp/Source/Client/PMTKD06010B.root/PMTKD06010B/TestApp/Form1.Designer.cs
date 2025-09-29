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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMakerCd = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtModelSubCd = new System.Windows.Forms.TextBox();
            this.txtKatasiki = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtRui1 = new System.Windows.Forms.TextBox();
            this.txtRui2 = new System.Windows.Forms.TextBox();
            this.txtEngine = new System.Windows.Forms.TextBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.rdoKatasiki = new System.Windows.Forms.RadioButton();
            this.rdoRuibetu = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoEngine = new System.Windows.Forms.RadioButton();
            this.rdoPlate = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(739, 242);
            this.dataGridView1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(651, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "車両検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMakerCd
            // 
            this.txtMakerCd.Location = new System.Drawing.Point(344, 15);
            this.txtMakerCd.Name = "txtMakerCd";
            this.txtMakerCd.Size = new System.Drawing.Size(64, 19);
            this.txtMakerCd.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtMakerCd, "メーカーコードを入力して下さい。");
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(416, 15);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(64, 19);
            this.txtModel.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtModel, "車種コードを入力して下さい。");
            // 
            // txtModelSubCd
            // 
            this.txtModelSubCd.Location = new System.Drawing.Point(488, 15);
            this.txtModelSubCd.Name = "txtModelSubCd";
            this.txtModelSubCd.Size = new System.Drawing.Size(64, 19);
            this.txtModelSubCd.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtModelSubCd, "車種サブコードを入力して下さい。");
            // 
            // txtKatasiki
            // 
            this.txtKatasiki.Location = new System.Drawing.Point(64, 15);
            this.txtKatasiki.Name = "txtKatasiki";
            this.txtKatasiki.Size = new System.Drawing.Size(212, 19);
            this.txtKatasiki.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtKatasiki, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "①\' 車種検索結果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "②\' 型式検索結果";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(16, 370);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(740, 305);
            this.dataGridView2.TabIndex = 14;
            // 
            // txtRui1
            // 
            this.txtRui1.Location = new System.Drawing.Point(64, 47);
            this.txtRui1.Name = "txtRui1";
            this.txtRui1.Size = new System.Drawing.Size(64, 19);
            this.txtRui1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtRui1, "型式指定番号を入力して下さい。");
            // 
            // txtRui2
            // 
            this.txtRui2.Location = new System.Drawing.Point(136, 47);
            this.txtRui2.Name = "txtRui2";
            this.txtRui2.Size = new System.Drawing.Size(48, 19);
            this.txtRui2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtRui2, "類別区分番号を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // txtEngine
            // 
            this.txtEngine.Location = new System.Drawing.Point(271, 47);
            this.txtEngine.Name = "txtEngine";
            this.txtEngine.Size = new System.Drawing.Size(104, 19);
            this.txtEngine.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtEngine, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(458, 48);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(104, 19);
            this.txtPlate.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtPlate, "車両型式を入力して下さい。\r\n※フル型式・シリーズ型式は問いません。");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(651, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "検索条件消去";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rdoKatasiki
            // 
            this.rdoKatasiki.AutoSize = true;
            this.rdoKatasiki.Checked = true;
            this.rdoKatasiki.Location = new System.Drawing.Point(16, 16);
            this.rdoKatasiki.Name = "rdoKatasiki";
            this.rdoKatasiki.Size = new System.Drawing.Size(47, 16);
            this.rdoKatasiki.TabIndex = 0;
            this.rdoKatasiki.TabStop = true;
            this.rdoKatasiki.Text = "型式";
            this.rdoKatasiki.UseVisualStyleBackColor = true;
            // 
            // rdoRuibetu
            // 
            this.rdoRuibetu.AutoSize = true;
            this.rdoRuibetu.Location = new System.Drawing.Point(16, 48);
            this.rdoRuibetu.Name = "rdoRuibetu";
            this.rdoRuibetu.Size = new System.Drawing.Size(47, 16);
            this.rdoRuibetu.TabIndex = 2;
            this.rdoRuibetu.Text = "類別";
            this.rdoRuibetu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 16;
            // 
            // rdoEngine
            // 
            this.rdoEngine.AutoSize = true;
            this.rdoEngine.Location = new System.Drawing.Point(207, 48);
            this.rdoEngine.Name = "rdoEngine";
            this.rdoEngine.Size = new System.Drawing.Size(60, 16);
            this.rdoEngine.TabIndex = 19;
            this.rdoEngine.Text = "エンジン";
            this.rdoEngine.UseVisualStyleBackColor = true;
            // 
            // rdoPlate
            // 
            this.rdoPlate.AutoSize = true;
            this.rdoPlate.Location = new System.Drawing.Point(393, 48);
            this.rdoPlate.Name = "rdoPlate";
            this.rdoPlate.Size = new System.Drawing.Size(59, 16);
            this.rdoPlate.TabIndex = 21;
            this.rdoPlate.Text = "プレート";
            this.rdoPlate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "車種";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 690);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoPlate);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.rdoEngine);
            this.Controls.Add(this.txtEngine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoRuibetu);
            this.Controls.Add(this.rdoKatasiki);
            this.Controls.Add(this.txtRui2);
            this.Controls.Add(this.txtRui1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKatasiki);
            this.Controls.Add(this.txtModelSubCd);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMakerCd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "TestApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMakerCd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtModelSubCd;
        private System.Windows.Forms.TextBox txtKatasiki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtRui1;
        private System.Windows.Forms.TextBox txtRui2;
        private System.Windows.Forms.RadioButton rdoKatasiki;
        private System.Windows.Forms.RadioButton rdoRuibetu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEngine;
        private System.Windows.Forms.RadioButton rdoEngine;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.RadioButton rdoPlate;
        private System.Windows.Forms.Label label1;
    }
}

