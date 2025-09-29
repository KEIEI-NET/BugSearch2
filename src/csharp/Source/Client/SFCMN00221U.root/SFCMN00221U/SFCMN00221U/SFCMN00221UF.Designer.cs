using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class SFCMN00221UF
	{
		private System.Windows.Forms.Splitter splitter1;
		internal System.Windows.Forms.Panel panel_Main;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Top;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_TopRecord;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
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

		#region コンポーネント デザイナ デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.uExplorerBar_TopRecord = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.uExplorerBar_Top = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.panel_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_TopRecord)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Top)).BeginInit();
			this.SuspendLayout();
			// 
			// panel_Main
			// 
			this.panel_Main.Controls.Add(this.uExplorerBar_TopRecord);
			this.panel_Main.Controls.Add(this.splitter1);
			this.panel_Main.Controls.Add(this.uExplorerBar_Top);
			this.panel_Main.Location = new System.Drawing.Point(4, 9);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(359, 628);
			this.panel_Main.TabIndex = 2;
			// 
			// uExplorerBar_TopRecord
			// 
			this.uExplorerBar_TopRecord.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uExplorerBar_TopRecord.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance1.FontData.Name = "ＭＳ ゴシック";
			appearance1.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.Appearance = appearance1;
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.UnderlineAsString = "True";
			appearance2.ForeColor = System.Drawing.Color.Blue;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance2;
			ultraExplorerBarGroup1.ItemSettings.Height = 25;
			ultraExplorerBarGroup1.ItemSettings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup1.ItemSettings.HotTrackStyle = Infragistics.Win.UltraWinExplorerBar.ItemHotTrackStyle.HighlightText;
			ultraExplorerBarGroup1.Key = "CustomerRecord";
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance3;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance4.FontData.BoldAsString = "False";
			appearance4.FontData.Name = "ＭＳ ゴシック";
			appearance4.FontData.SizeInPoints = 12F;
			appearance4.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance4;
			ultraExplorerBarGroup1.Settings.ItemAreaOuterMargins.Top = 10;
			ultraExplorerBarGroup1.Text = "最近使用した得意先";
			appearance5.FontData.Name = "ＭＳ ゴシック";
			appearance5.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup2.ItemSettings.AppearancesSmall.Appearance = appearance5;
			appearance6.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance6.FontData.UnderlineAsString = "True";
			appearance6.ForeColor = System.Drawing.Color.Blue;
			ultraExplorerBarGroup2.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance6;
			ultraExplorerBarGroup2.ItemSettings.Height = 25;
			ultraExplorerBarGroup2.ItemSettings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup2.ItemSettings.HotTrackStyle = Infragistics.Win.UltraWinExplorerBar.ItemHotTrackStyle.HighlightText;
			ultraExplorerBarGroup2.Key = "StockSlipRecord";
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(225)))));
			appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance7;
			appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance8.FontData.BoldAsString = "False";
			appearance8.FontData.Name = "ＭＳ ゴシック";
			appearance8.FontData.SizeInPoints = 12F;
			appearance8.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup2.Settings.AppearancesSmall.HeaderAppearance = appearance8;
			ultraExplorerBarGroup2.Settings.ItemAreaOuterMargins.Top = 10;
			ultraExplorerBarGroup2.Text = "最近使用した仕入伝票";
			this.uExplorerBar_TopRecord.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
			this.uExplorerBar_TopRecord.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_TopRecord.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_TopRecord.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_TopRecord.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_TopRecord.ItemSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_TopRecord.Location = new System.Drawing.Point(0, 379);
			this.uExplorerBar_TopRecord.Name = "uExplorerBar_TopRecord";
			this.uExplorerBar_TopRecord.ShowDefaultContextMenu = false;
			this.uExplorerBar_TopRecord.Size = new System.Drawing.Size(359, 249);
			this.uExplorerBar_TopRecord.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_TopRecord.TabIndex = 5;
			this.uExplorerBar_TopRecord.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			this.uExplorerBar_TopRecord.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.uExplorerBar_TopRecord_MouseEnterElement);
			this.uExplorerBar_TopRecord.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uExplorerBar_TopRecord_ItemClick);
			this.uExplorerBar_TopRecord.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.uExplorerBar_TopRecord_MouseLeaveElement);
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Control;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 376);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(359, 3);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// uExplorerBar_Top
			// 
			this.uExplorerBar_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.uExplorerBar_Top.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance9.FontData.Name = "ＭＳ ゴシック";
			appearance9.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup3.ItemSettings.AppearancesSmall.Appearance = appearance9;
			appearance10.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance10.FontData.UnderlineAsString = "True";
			appearance10.ForeColor = System.Drawing.Color.Blue;
			ultraExplorerBarGroup3.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance10;
			ultraExplorerBarGroup3.ItemSettings.Height = 22;
			ultraExplorerBarGroup3.ItemSettings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup3.ItemSettings.HotTrackStyle = Infragistics.Win.UltraWinExplorerBar.ItemHotTrackStyle.HighlightText;
			ultraExplorerBarGroup3.ItemSettings.Indent = 5;
			ultraExplorerBarGroup3.ItemSettings.MaxLines = 2;
			ultraExplorerBarGroup3.Key = "TopNavigator";
			appearance11.BackColor = System.Drawing.Color.White;
			appearance11.BackColor2 = System.Drawing.Color.White;
			appearance11.FontData.Name = "ＭＳ ゴシック";
			ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance11;
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance12.FontData.BoldAsString = "False";
			appearance12.FontData.Name = "ＭＳ ゴシック";
			appearance12.FontData.SizeInPoints = 12F;
			appearance12.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup3.Settings.AppearancesSmall.HeaderAppearance = appearance12;
			ultraExplorerBarGroup3.Settings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup3.Text = "ナビゲーター";
			this.uExplorerBar_Top.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup3});
			this.uExplorerBar_Top.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_Top.Location = new System.Drawing.Point(0, 0);
			this.uExplorerBar_Top.Name = "uExplorerBar_Top";
			this.uExplorerBar_Top.ShowDefaultContextMenu = false;
			this.uExplorerBar_Top.Size = new System.Drawing.Size(359, 376);
			this.uExplorerBar_Top.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_Top.TabIndex = 4;
			this.uExplorerBar_Top.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			this.uExplorerBar_Top.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uExplorerBar_Top_ItemClick);
			// 
			// SFCMN00221UF
			// 
			this.Controls.Add(this.panel_Main);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "SFCMN00221UF";
			this.Size = new System.Drawing.Size(383, 646);
			this.panel_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_TopRecord)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Top)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	}
}
