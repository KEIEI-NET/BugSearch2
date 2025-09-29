namespace Broadleaf.Windows.Forms.Other
{
    partial class PrtManageForm
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
            this.stsPrtManage = new System.Windows.Forms.StatusStrip();
            this.lblEditMode = new System.Windows.Forms.Label();
            this.lblPrinterMngNo = new System.Windows.Forms.Label();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.lblPrinterPort = new System.Windows.Forms.Label();
            this.lblPrinterKind = new System.Windows.Forms.Label();
            this.txtPrinterMngNo = new System.Windows.Forms.TextBox();
            this.cboPrinterName = new System.Windows.Forms.ComboBox();
            this.txtPrinterPort = new System.Windows.Forms.TextBox();
            this.cboPrinterKind = new System.Windows.Forms.ComboBox();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnRevive = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblGUID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stsPrtManage
            // 
            this.stsPrtManage.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stsPrtManage.Location = new System.Drawing.Point(0, 245);
            this.stsPrtManage.Name = "stsPrtManage";
            this.stsPrtManage.Size = new System.Drawing.Size(652, 22);
            this.stsPrtManage.TabIndex = 0;
            this.stsPrtManage.Text = "statusStrip1";
            // 
            // lblEditMode
            // 
            this.lblEditMode.AutoSize = true;
            this.lblEditMode.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblEditMode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEditMode.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEditMode.Location = new System.Drawing.Point(540, 5);
            this.lblEditMode.Name = "lblEditMode";
            this.lblEditMode.Size = new System.Drawing.Size(87, 15);
            this.lblEditMode.TabIndex = 1;
            this.lblEditMode.Text = "○○モード";
            // 
            // lblPrinterMngNo
            // 
            this.lblPrinterMngNo.AutoSize = true;
            this.lblPrinterMngNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrinterMngNo.Location = new System.Drawing.Point(15, 50);
            this.lblPrinterMngNo.Name = "lblPrinterMngNo";
            this.lblPrinterMngNo.Size = new System.Drawing.Size(119, 15);
            this.lblPrinterMngNo.TabIndex = 2;
            this.lblPrinterMngNo.Text = "プリンタ管理No";
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrinterName.Location = new System.Drawing.Point(15, 85);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(87, 15);
            this.lblPrinterName.TabIndex = 3;
            this.lblPrinterName.Text = "プリンタ名";
            // 
            // lblPrinterPort
            // 
            this.lblPrinterPort.AutoSize = true;
            this.lblPrinterPort.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrinterPort.Location = new System.Drawing.Point(15, 120);
            this.lblPrinterPort.Name = "lblPrinterPort";
            this.lblPrinterPort.Size = new System.Drawing.Size(103, 15);
            this.lblPrinterPort.TabIndex = 4;
            this.lblPrinterPort.Text = "プリンタパス";
            // 
            // lblPrinterKind
            // 
            this.lblPrinterKind.AutoSize = true;
            this.lblPrinterKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrinterKind.Location = new System.Drawing.Point(15, 155);
            this.lblPrinterKind.Name = "lblPrinterKind";
            this.lblPrinterKind.Size = new System.Drawing.Size(103, 15);
            this.lblPrinterKind.TabIndex = 5;
            this.lblPrinterKind.Text = "プリンタ種別";
            // 
            // txtPrinterMngNo
            // 
            this.txtPrinterMngNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.txtPrinterMngNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPrinterMngNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPrinterMngNo.Location = new System.Drawing.Point(140, 50);
            this.txtPrinterMngNo.Name = "txtPrinterMngNo";
            this.txtPrinterMngNo.Size = new System.Drawing.Size(100, 22);
            this.txtPrinterMngNo.TabIndex = 6;
            this.txtPrinterMngNo.Leave += new System.EventHandler(this.txtPrinterMngNo_Leave);
            // 
            // cboPrinterName
            // 
            this.cboPrinterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.cboPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cboPrinterName.FormattingEnabled = true;
            this.cboPrinterName.Location = new System.Drawing.Point(140, 80);
            this.cboPrinterName.Name = "cboPrinterName";
            this.cboPrinterName.Size = new System.Drawing.Size(480, 23);
            this.cboPrinterName.TabIndex = 7;
            this.cboPrinterName.SelectedValueChanged += new System.EventHandler(this.cboPrinterName_ValueChanged);
            // 
            // txtPrinterPort
            // 
            this.txtPrinterPort.BackColor = System.Drawing.Color.LightGray;
            this.txtPrinterPort.Enabled = false;
            this.txtPrinterPort.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPrinterPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPrinterPort.Location = new System.Drawing.Point(140, 120);
            this.txtPrinterPort.Name = "txtPrinterPort";
            this.txtPrinterPort.Size = new System.Drawing.Size(469, 22);
            this.txtPrinterPort.TabIndex = 8;
            // 
            // cboPrinterKind
            // 
            this.cboPrinterKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.cboPrinterKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cboPrinterKind.FormattingEnabled = true;
            this.cboPrinterKind.Location = new System.Drawing.Point(140, 155);
            this.cboPrinterKind.Name = "cboPrinterKind";
            this.cboPrinterKind.Size = new System.Drawing.Size(175, 23);
            this.cboPrinterKind.TabIndex = 9;
            // 
            // btnDestroy
            // 
            this.btnDestroy.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDestroy.Location = new System.Drawing.Point(140, 200);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(125, 34);
            this.btnDestroy.TabIndex = 10;
            this.btnDestroy.Text = "完全削除(&D)";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // btnRevive
            // 
            this.btnRevive.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRevive.Location = new System.Drawing.Point(265, 200);
            this.btnRevive.Name = "btnRevive";
            this.btnRevive.Size = new System.Drawing.Size(125, 34);
            this.btnRevive.TabIndex = 11;
            this.btnRevive.Text = "復活(&R)";
            this.btnRevive.UseVisualStyleBackColor = true;
            this.btnRevive.Click += new System.EventHandler(this.btnRevive_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(390, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 34);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(515, 200);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 34);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "閉じる(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblGUID
            // 
            this.lblGUID.AutoSize = true;
            this.lblGUID.Location = new System.Drawing.Point(246, 53);
            this.lblGUID.Name = "lblGUID";
            this.lblGUID.Size = new System.Drawing.Size(32, 12);
            this.lblGUID.TabIndex = 14;
            this.lblGUID.Text = "GUID";
            this.lblGUID.Visible = false;
            // 
            // PrtManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(652, 267);
            this.Controls.Add(this.lblGUID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRevive);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.cboPrinterKind);
            this.Controls.Add(this.txtPrinterPort);
            this.Controls.Add(this.cboPrinterName);
            this.Controls.Add(this.txtPrinterMngNo);
            this.Controls.Add(this.lblPrinterKind);
            this.Controls.Add(this.lblPrinterPort);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.lblPrinterMngNo);
            this.Controls.Add(this.lblEditMode);
            this.Controls.Add(this.stsPrtManage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PrtManageForm";
            this.Text = "プリンタ設定";
            this.Load += new System.EventHandler(this.PrtManageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsPrtManage;
        private System.Windows.Forms.Label lblEditMode;
        private System.Windows.Forms.Label lblPrinterMngNo;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.Label lblPrinterPort;
        private System.Windows.Forms.Label lblPrinterKind;
        private System.Windows.Forms.TextBox txtPrinterMngNo;
        private System.Windows.Forms.ComboBox cboPrinterName;
        private System.Windows.Forms.TextBox txtPrinterPort;
        private System.Windows.Forms.ComboBox cboPrinterKind;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnRevive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblGUID;
    }
}