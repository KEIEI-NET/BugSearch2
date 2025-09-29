using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class SFCMN00221UA
	{
		private System.Windows.Forms.Timer timer_Initial;
		private System.Windows.Forms.Panel panel_Main;
		private System.Windows.Forms.Panel panel_Frame;
		private System.Windows.Forms.Panel panel7;
		private Infragistics.Win.Misc.UltraButton uButton_Before;
		private Infragistics.Win.Misc.UltraButton uButton_Next;
		private Infragistics.Win.Misc.UltraButton uButton_Home;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			this.timer_Initial = new System.Windows.Forms.Timer(this.components);
			this.panel_Main = new System.Windows.Forms.Panel();
			this.panel_Frame = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.uButton_Before = new Infragistics.Win.Misc.UltraButton();
			this.uButton_Next = new Infragistics.Win.Misc.UltraButton();
			this.uButton_Home = new Infragistics.Win.Misc.UltraButton();
			this.panel_Main.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer_Initial
			// 
			this.timer_Initial.Interval = 1;
			this.timer_Initial.Tick += new System.EventHandler(this.timer_Initial_Tick);
			// 
			// panel_Main
			// 
			this.panel_Main.Controls.Add(this.panel_Frame);
			this.panel_Main.Controls.Add(this.panel7);
			this.panel_Main.Location = new System.Drawing.Point(5, 5);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(208, 628);
			this.panel_Main.TabIndex = 3;
			// 
			// panel_Frame
			// 
			this.panel_Frame.BackColor = System.Drawing.Color.White;
			this.panel_Frame.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Frame.Location = new System.Drawing.Point(0, 28);
			this.panel_Frame.Name = "panel_Frame";
			this.panel_Frame.Size = new System.Drawing.Size(208, 600);
			this.panel_Frame.TabIndex = 1;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.panel7.Controls.Add(this.uButton_Before);
			this.panel7.Controls.Add(this.uButton_Next);
			this.panel7.Controls.Add(this.uButton_Home);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(208, 28);
			this.panel7.TabIndex = 0;
			// 
			// uButton_Before
			// 
			appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.uButton_Before.Appearance = appearance1;
			this.uButton_Before.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupSoftBorderless;
			this.uButton_Before.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uButton_Before.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_Before.Location = new System.Drawing.Point(4, 1);
			this.uButton_Before.Name = "uButton_Before";
			this.uButton_Before.Size = new System.Drawing.Size(28, 26);
            this.uButton_Before.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.uButton_Before.TabIndex = 4;
			this.uButton_Before.TabStop = false;
			this.uButton_Before.Click += new System.EventHandler(this.uButton_Before_Click);
			// 
			// uButton_Next
			// 
			appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.uButton_Next.Appearance = appearance2;
			this.uButton_Next.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupSoftBorderless;
			this.uButton_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uButton_Next.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_Next.Location = new System.Drawing.Point(32, 1);
			this.uButton_Next.Name = "uButton_Next";
			this.uButton_Next.Size = new System.Drawing.Size(28, 26);
            this.uButton_Next.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.uButton_Next.TabIndex = 5;
			this.uButton_Next.TabStop = false;
			this.uButton_Next.Click += new System.EventHandler(this.uButton_Next_Click);
			// 
			// uButton_Home
			// 
			appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.uButton_Home.Appearance = appearance3;
			this.uButton_Home.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupSoftBorderless;
			this.uButton_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uButton_Home.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_Home.Location = new System.Drawing.Point(60, 1);
			this.uButton_Home.Name = "uButton_Home";
			this.uButton_Home.Size = new System.Drawing.Size(28, 26);
            this.uButton_Home.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.uButton_Home.TabIndex = 6;
			this.uButton_Home.TabStop = false;
			this.uButton_Home.Click += new System.EventHandler(this.uButton_Home_Click);
			// 
			// SFCMN00221UA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(322, 646);
			this.Controls.Add(this.panel_Main);
			this.Name = "SFCMN00221UA";
			this.Load += new System.EventHandler(this.SFCMN00221UA_Load);
			this.panel_Main.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
