namespace WebTester
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
            if (disposing && ( components != null ))
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
            this.txt_EnterpriseCode = new System.Windows.Forms.TextBox();
            this.txt_Employee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Acnt = new System.Windows.Forms.TextBox();
            this.btn_ExchangeAcntId = new System.Windows.Forms.Button();
            this.btn_SearchRelatedSmplInqInf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_EnterpriseCode
            // 
            this.txt_EnterpriseCode.Location = new System.Drawing.Point(94, 14);
            this.txt_EnterpriseCode.Name = "txt_EnterpriseCode";
            this.txt_EnterpriseCode.Size = new System.Drawing.Size(262, 19);
            this.txt_EnterpriseCode.TabIndex = 0;
            this.txt_EnterpriseCode.Text = "010115084202000";
            // 
            // txt_Employee
            // 
            this.txt_Employee.Location = new System.Drawing.Point(94, 39);
            this.txt_Employee.Name = "txt_Employee";
            this.txt_Employee.Size = new System.Drawing.Size(262, 19);
            this.txt_Employee.TabIndex = 1;
            this.txt_Employee.Text = "0001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "従業員コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "アカウント";
            // 
            // txt_Acnt
            // 
            this.txt_Acnt.Location = new System.Drawing.Point(94, 64);
            this.txt_Acnt.Name = "txt_Acnt";
            this.txt_Acnt.Size = new System.Drawing.Size(262, 19);
            this.txt_Acnt.TabIndex = 5;
            this.txt_Acnt.Text = "sfscmtest";
            // 
            // btn_ExchangeAcntId
            // 
            this.btn_ExchangeAcntId.Location = new System.Drawing.Point(14, 89);
            this.btn_ExchangeAcntId.Name = "btn_ExchangeAcntId";
            this.btn_ExchangeAcntId.Size = new System.Drawing.Size(185, 23);
            this.btn_ExchangeAcntId.TabIndex = 6;
            this.btn_ExchangeAcntId.Text = "ExchangeAcntId";
            this.btn_ExchangeAcntId.UseVisualStyleBackColor = true;
            this.btn_ExchangeAcntId.Click += new System.EventHandler(this.btn_ExchangeAcntId_Click);
            // 
            // btn_SearchRelatedSmplInqInf
            // 
            this.btn_SearchRelatedSmplInqInf.Location = new System.Drawing.Point(205, 89);
            this.btn_SearchRelatedSmplInqInf.Name = "btn_SearchRelatedSmplInqInf";
            this.btn_SearchRelatedSmplInqInf.Size = new System.Drawing.Size(185, 23);
            this.btn_SearchRelatedSmplInqInf.TabIndex = 7;
            this.btn_SearchRelatedSmplInqInf.Text = "SearchRelatedSmplInqInf";
            this.btn_SearchRelatedSmplInqInf.UseVisualStyleBackColor = true;
            this.btn_SearchRelatedSmplInqInf.Click += new System.EventHandler(this.btn_SearchRelatedSmplInqInf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 263);
            this.Controls.Add(this.btn_SearchRelatedSmplInqInf);
            this.Controls.Add(this.btn_ExchangeAcntId);
            this.Controls.Add(this.txt_Acnt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Employee);
            this.Controls.Add(this.txt_EnterpriseCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_EnterpriseCode;
        private System.Windows.Forms.TextBox txt_Employee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Acnt;
        private System.Windows.Forms.Button btn_ExchangeAcntId;
        private System.Windows.Forms.Button btn_SearchRelatedSmplInqInf;
    }
}

