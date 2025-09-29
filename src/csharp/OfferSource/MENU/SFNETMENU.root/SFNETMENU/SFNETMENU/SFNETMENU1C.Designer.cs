namespace Broadleaf.Windows.Forms
{
    partial class SFNETMENU1CF
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param rKeyName="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFNETMENU1CF ) );
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Image = new System.Windows.Forms.Label();
            this.comboBox_Image = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point( 93, 77 );
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size( 84, 23 );
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "設定(&S)";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler( this.button_Save_Click );
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point( 181, 77 );
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size( 84, 23 );
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "キャンセル(&C)";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler( this.button_Cancel_Click );
            // 
            // label_Image
            // 
            this.label_Image.AutoSize = true;
            this.label_Image.Location = new System.Drawing.Point( 12, 17 );
            this.label_Image.Name = "label_Image";
            this.label_Image.Size = new System.Drawing.Size( 77, 12 );
            this.label_Image.TabIndex = 2;
            this.label_Image.Text = "メニューイメージ";
            // 
            // comboBox_Image
            // 
            this.comboBox_Image.FormattingEnabled = true;
            this.comboBox_Image.Location = new System.Drawing.Point( 25, 38 );
            this.comboBox_Image.Name = "comboBox_Image";
            this.comboBox_Image.Size = new System.Drawing.Size( 240, 20 );
            this.comboBox_Image.TabIndex = 3;
            // 
            // SFNETMENU1CF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size( 292, 112 );
            this.Controls.Add( this.comboBox_Image );
            this.Controls.Add( this.label_Image );
            this.Controls.Add( this.button_Cancel );
            this.Controls.Add( this.button_Save );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.MaximizeBox = false;
            this.Name = "SFNETMENU1CF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "メニュー設定";
            this.Load += new System.EventHandler( this.SFNETMENU1C_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Image;
        private System.Windows.Forms.ComboBox comboBox_Image;
    }
}