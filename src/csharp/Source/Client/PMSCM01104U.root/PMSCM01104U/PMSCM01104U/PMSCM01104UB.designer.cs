using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
	partial class CommonProcessingFormEntity
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonProcessingFormEntity));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cancel_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.backGround_panel = new System.Windows.Forms.Panel();
            this.statusInfo_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.backGround_panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_ultraButton
            // 
            this.cancel_ultraButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancel_ultraButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_ultraButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.cancel_ultraButton.Location = new System.Drawing.Point(121, 61);
            this.cancel_ultraButton.Name = "cancel_ultraButton";
            this.cancel_ultraButton.Size = new System.Drawing.Size(100, 25);
            this.cancel_ultraButton.TabIndex = 2;
            this.cancel_ultraButton.Text = "キャンセル";
            this.cancel_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.cancel_ultraButton.Visible = false;
            // 
            // backGround_panel
            // 
            this.backGround_panel.Controls.Add(this.statusInfo_ultraLabel);
            this.backGround_panel.Controls.Add(this.pictureBox1);
            this.backGround_panel.Controls.Add(this.cancel_ultraButton);
            this.backGround_panel.Controls.Add(this.ultraLabel1);
            this.backGround_panel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.backGround_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backGround_panel.Location = new System.Drawing.Point(0, 0);
            this.backGround_panel.Name = "backGround_panel";
            this.backGround_panel.Size = new System.Drawing.Size(330, 58);
            this.backGround_panel.TabIndex = 5;
            // 
            // statusInfo_ultraLabel
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 150 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.Blue;
            appearance1.TextHAlignAsString = "Center";
            this.statusInfo_ultraLabel.Appearance = appearance1;
            this.statusInfo_ultraLabel.BackColorInternal = System.Drawing.Color.White;
            this.statusInfo_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.statusInfo_ultraLabel.Location = new System.Drawing.Point(39, 12);
            this.statusInfo_ultraLabel.Name = "statusInfo_ultraLabel";
            this.statusInfo_ultraLabel.Size = new System.Drawing.Size(252, 20);
            this.statusInfo_ultraLabel.TabIndex = 8;
            this.statusInfo_ultraLabel.Text = "現在、データ抽出中です";
            this.statusInfo_ultraLabel.WrapText = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.pictureBox1.Image = ( (System.Drawing.Image)( resources.GetObject("pictureBox1.Image") ) );
            this.pictureBox1.Location = new System.Drawing.Point(28, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ultraLabel1
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(330, 58);
            this.ultraLabel1.TabIndex = 6;
            // 
            // CommonProcessingFormEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.CancelButton = this.cancel_ultraButton;
            this.ClientSize = new System.Drawing.Size(330, 58);
            this.ControlBox = false;
            this.Controls.Add(this.backGround_panel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommonProcessingFormEntity";
            this.Opacity = 0.85;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "抽出中";
            this.Load += new System.EventHandler(this.CommonProcessingFormEntity_Load);
            this.backGround_panel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        public Infragistics.Win.Misc.UltraButton cancel_ultraButton;
        public Infragistics.Win.Misc.UltraLabel statusInfo_ultraLabel;
        public PictureBox pictureBox1;
        public Infragistics.Win.Misc.UltraLabel ultraLabel1;
        public Panel backGround_panel;

	}

}