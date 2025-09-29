//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動の設定フォームです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2010/06/10  修正内容 : 移動伝票の[発行する]オプションの初期値を設定
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 障害改良対応(4月)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2011/05/20  修正内容 : Redmine#21636
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2011/05/21  修正内容 : Redmine#21684
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/09  修正内容 : 仕掛一覧 №2358　入庫前数・入庫後数を追加
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Data;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫移動入力画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫移動入力画面用のユーザー設定フォームクラスです。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.12.05</br>
	/// <br>Update Note: 2008/07/14 30414 忍 幸史</br>
    /// <br>           : Partsman用に変更</br>
	/// <br>2006.04.18 men Visual Studio 2005 対応</br>
    /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
    /// </remarks>
	public class StockMoveInputSetUp : System.Windows.Forms.Form
	{
		# region Components
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl_Setup;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Panel panel5;
        internal UltraGrid uGrid_DetailControl;
        private Panel Panel1;
        private Infragistics.Win.Misc.UltraButton uButton_DetailFocusUndo;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Panel panel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TLine tLine1;
        private Infragistics.Win.Misc.UltraLabel ulblPrintSlip;
        internal Infragistics.Win.UltraWinEditors.UltraOptionSet uoptPrintSlip;
		private System.ComponentModel.IContainer components;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 在庫移動入力画面用ユーザー設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫移動入力画面用ユーザー設定クラスの初期処理を行います。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.12.05</br>
		/// <br></br>
		/// </remarks>
        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
        //public StockMoveInputSetUp(List<string> functionModeList)
        // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
        //public StockMoveInputSetUp(ArrayList userSettingList)
        // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
		public StockMoveInputSetUp(
            ArrayList userSettingList,
            MAZAI04120UA inputForm
        )
        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        {
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockMoveInputConstructionAcs = new StockMoveInputConstructionAcs();

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._controlScreenSkin = new ControlScreenSkin();

            this._userSettingList = userSettingList;

            this._stockMoveInputAcs = StockMoveInputAcs.GetInstance();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
			this.FunctionMode_TComboEditor.Value = this._stockMoveInputConstructionAcs.FunctionMode;

            // リストvalue生成
            for (int index = 0; index < functionModeList.Count; index++)
			{
                this.FunctionMode_TComboEditor.Items.Add( index, functionModeList[index] );
			}
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            _inputForm = inputForm;
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
        }
		# endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		// ===================================================================================== //
		// Windows フォーム デザイナで生成されたコード
		// ===================================================================================== //
		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMoveInputSetUp));
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.uGrid_DetailControl = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.uButton_DetailFocusUndo = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uoptPrintSlip = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ulblPrintSlip = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uTabControl_Setup = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DetailControl)).BeginInit();
            this.Panel1.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uoptPrintSlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).BeginInit();
            this.uTabControl_Setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.panel5);
            this.ultraTabPageControl2.Controls.Add(this.Panel1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(403, 333);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.uGrid_DetailControl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(403, 311);
            this.panel5.TabIndex = 25;
            // 
            // uGrid_DetailControl
            // 
            appearance41.BackColor = System.Drawing.Color.White;
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_DetailControl.DisplayLayout.Appearance = appearance41;
            this.uGrid_DetailControl.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_DetailControl.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_DetailControl.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_DetailControl.DisplayLayout.MaxRowScrollRegions = 1;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            this.uGrid_DetailControl.DisplayLayout.Override.ActiveCellAppearance = appearance42;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_DetailControl.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_DetailControl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.uGrid_DetailControl.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.ForeColor = System.Drawing.Color.White;
            appearance43.ForeColorDisabled = System.Drawing.Color.White;
            appearance43.TextHAlignAsString = "Center";
            appearance43.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_DetailControl.DisplayLayout.Override.RowAlternateAppearance = appearance44;
            appearance45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance45.TextVAlignAsString = "Middle";
            this.uGrid_DetailControl.DisplayLayout.Override.RowAppearance = appearance45;
            this.uGrid_DetailControl.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_DetailControl.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance46.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance46.ForeColor = System.Drawing.Color.White;
            this.uGrid_DetailControl.DisplayLayout.Override.RowSelectorAppearance = appearance46;
            this.uGrid_DetailControl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_DetailControl.DisplayLayout.Override.RowSelectorWidth = 20;
            this.uGrid_DetailControl.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance47.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance47.ForeColor = System.Drawing.Color.Black;
            this.uGrid_DetailControl.DisplayLayout.Override.SelectedRowAppearance = appearance47;
            this.uGrid_DetailControl.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGrid_DetailControl.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_DetailControl.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_DetailControl.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DetailControl.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DetailControl.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DetailControl.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_DetailControl.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_DetailControl.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_DetailControl.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_DetailControl.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_DetailControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.uGrid_DetailControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_DetailControl.Location = new System.Drawing.Point(0, 0);
            this.uGrid_DetailControl.Name = "uGrid_DetailControl";
            this.uGrid_DetailControl.Size = new System.Drawing.Size(363, 311);
            this.uGrid_DetailControl.TabIndex = 24;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.uButton_DetailFocusUndo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 311);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(403, 22);
            this.Panel1.TabIndex = 24;
            // 
            // uButton_DetailFocusUndo
            // 
            this.uButton_DetailFocusUndo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_DetailFocusUndo.Location = new System.Drawing.Point(296, 0);
            this.uButton_DetailFocusUndo.Name = "uButton_DetailFocusUndo";
            this.uButton_DetailFocusUndo.Size = new System.Drawing.Size(107, 22);
            this.uButton_DetailFocusUndo.TabIndex = 3;
            this.uButton_DetailFocusUndo.Text = "初期設定に戻す";
            this.uButton_DetailFocusUndo.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_DetailFocusUndo.Click += new System.EventHandler(this.uButton_DetailFocusUndo_Click);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panel2);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(403, 333);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.uoptPrintSlip);
            this.panel2.Controls.Add(this.ulblPrintSlip);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Controls.Add(this.tLine1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 333);
            this.panel2.TabIndex = 0;
            // 
            // uoptPrintSlip
            // 
            this.uoptPrintSlip.BackColor = System.Drawing.Color.Transparent;
            this.uoptPrintSlip.BackColorInternal = System.Drawing.Color.Transparent;
            this.uoptPrintSlip.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uoptPrintSlip.CheckedIndex = 0;
            appearance7.TextHAlignAsString = "Left";
            this.uoptPrintSlip.ItemAppearance = appearance7;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "発行する";
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "発行しない";
            this.uoptPrintSlip.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.uoptPrintSlip.ItemSpacingVertical = 5;
            this.uoptPrintSlip.Location = new System.Drawing.Point(96, 36);
            this.uoptPrintSlip.Name = "uoptPrintSlip";
            this.uoptPrintSlip.Size = new System.Drawing.Size(291, 22);
            this.uoptPrintSlip.TabIndex = 36;
            this.uoptPrintSlip.Text = "発行する";
            // 
            // ulblPrintSlip
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ulblPrintSlip.Appearance = appearance21;
            this.ulblPrintSlip.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulblPrintSlip.Location = new System.Drawing.Point(14, 36);
            this.ulblPrintSlip.Name = "ulblPrintSlip";
            this.ulblPrintSlip.Size = new System.Drawing.Size(76, 24);
            this.ulblPrintSlip.TabIndex = 34;
            this.ulblPrintSlip.Text = "移動伝票";
            // 
            // ultraLabel1
            // 
            appearance6.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel1.Appearance = appearance6;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(67, 14);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "初期表示";
            // 
            // tLine1
            // 
            this.tLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Silver;
            this.tLine1.Location = new System.Drawing.Point(83, 20);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(304, 10);
            this.tLine1.TabIndex = 3;
            this.tLine1.Text = "tLine1";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(318, 384);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 26);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "キャンセル";
            // 
            // Ok_Button
            // 
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.Location = new System.Drawing.Point(216, 384);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(96, 26);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "ＯＫ";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // uTabControl_Setup
            // 
            this.uTabControl_Setup.Controls.Add(this.ultraTabSharedControlsPage1);
            this.uTabControl_Setup.Controls.Add(this.ultraTabPageControl2);
            this.uTabControl_Setup.Controls.Add(this.ultraTabPageControl1);
            this.uTabControl_Setup.Location = new System.Drawing.Point(10, 12);
            this.uTabControl_Setup.Name = "uTabControl_Setup";
            this.uTabControl_Setup.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.uTabControl_Setup.Size = new System.Drawing.Size(407, 360);
            this.uTabControl_Setup.TabIndex = 7;
            ultraTab3.Key = "DetailInputControl";
            ultraTab3.TabPage = this.ultraTabPageControl2;
            ultraTab3.Text = "明細項目制御";
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            ultraTab1.ActiveAppearance = appearance1;
            ultraTab1.Key = "FormInputControl";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "入力制御";
            this.uTabControl_Setup.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab1});
            this.uTabControl_Setup.TabStop = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(403, 333);
            // 
            // StockMoveInputSetUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(429, 419);
            this.Controls.Add(this.uTabControl_Setup);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockMoveInputSetUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ユーザー設定";
            this.Load += new System.EventHandler(this.CustomerInputSetUp_Load);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DetailControl)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uoptPrintSlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).EndInit();
            this.uTabControl_Setup.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private const string COLUMNROWNO = "ColumnRowNo";
        private const string COLUMNCAPTIONKEY = "ColumnCaptionKey";
        private const string COLUMNCAPTIONNAME = "ColumnCaptionName";
        private const string COLUMNVISIBLE = "ColumnVisible";
        private const string COLUMNVISIBLEALLOW = "ColumnVisibleAllow";
        private const string COLUMNVISIBLEPOSITION = "ColumnVisiblePosition";
        private const string COLUMNMOVEALLOW = "ColumnMoveAllow";

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private StockMoveInputConstructionAcs _stockMoveInputConstructionAcs = null;

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        private ControlScreenSkin _controlScreenSkin;

        private ArrayList _userSettingList = new ArrayList();

        private StockMoveInputAcs _stockMoveInputAcs;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
        
        # endregion

        public ArrayList UserSettingList
        {
            get
            {
                return _userSettingList;
            }
        }

        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
        /// <summary>在庫移動入力の入力フォーム</summary>
        private readonly MAZAI04120UA _inputForm;
        /// <summary>在庫移動入力の入力フォームを取得します。</summary>
        private MAZAI04120UA InputForm { get { return _inputForm; } }
        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

		// ===================================================================================== //
		// 各種コンポーネントイベント処理郡
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 22018 鈴木 正臣</br>
		/// <br>Date        : 2007.12.05</br>
		/// </remarks>
		private void CustomerInputSetUp_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッド設定
            SetGrid(this._userSettingList);
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
			this.FunctionMode_TComboEditor.Value = this._stockMoveInputConstructionAcs.FunctionMode;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            // FIXME:入力制御の取込
            UserCustomSetting userCustomSetting = StockMoveInputInitDataAcs.LoadUserCustomSetting();
            {
                this.uoptPrintSlip.CheckedIndex = userCustomSetting.PrintsSlip ? 0 : 1;
            }
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
        }

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22018 鈴木 正臣</br>
		/// <br>Date        : 2007.12.05</br>
        /// <br>Update Note : 2011/05/21 朱俊成 Redmine#21684 伝票区分を変更する時、移動伝票区分の制御を変更します</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._stockMoveInputConstructionAcs.FunctionMode = (int)this.FunctionMode_TComboEditor.Value;
            this._stockMoveInputConstructionAcs.Serialize();
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // 画面情報取得
            ScreenToArrayVisible();

            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            // FIXME:入力制御の設定を保存
            UserCustomSetting userCustomSetting = new UserCustomSetting();
            {
                int selectedValue = (int)this.uoptPrintSlip.Value;
                userCustomSetting.PrintsSlip = (selectedValue > 0);
            }
            StockMoveInputInitDataAcs.SaveUserCustomSetting(userCustomSetting);

            InputForm.UpdatePrintOutOption();   // 在庫移動入力の入力フォームを更新
            // ----- ADD 2011/05/21 朱俊成 ------------------->>>>>
            // 在庫確定なし、伝票区分が入庫伝票時、移動伝票区分が「発行しない」を設定
            if (this.InputForm != null)
            {
                EventArgs ex = new EventArgs();
                this.InputForm.SlipDiv_tComboEditor_ValueChanged(this, ex);
            }
            // ----- ADD 2011/05/21 朱俊成 -------------------<<<<<
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

            this.DialogResult = DialogResult.OK;
        }
		# endregion

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>

        /// <summary>
        /// グリッド設定処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : グリッドの設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void SetGrid(ArrayList userSettingList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMNROWNO, typeof(Int32));
            dataTable.Columns.Add(COLUMNCAPTIONKEY, typeof(String));
            dataTable.Columns.Add(COLUMNCAPTIONNAME, typeof(String));
            dataTable.Columns.Add(COLUMNVISIBLE, typeof(Boolean));
            dataTable.Columns.Add(COLUMNVISIBLEALLOW, typeof(Boolean));
            dataTable.Columns.Add(COLUMNVISIBLEPOSITION, typeof(Int32));
            dataTable.Columns.Add(COLUMNMOVEALLOW, typeof(Boolean));

            ArrayList captionKeyList = new ArrayList();
            captionKeyList = (ArrayList)userSettingList[0];

            ArrayList captionNameList = new ArrayList();
            captionNameList = (ArrayList)userSettingList[1];

            ArrayList visibleList = new ArrayList();
            visibleList = (ArrayList)userSettingList[2];

            ArrayList visibleAllowList = new ArrayList();
            visibleAllowList = (ArrayList)userSettingList[3];

            ArrayList visiblePositionList = new ArrayList();
            visiblePositionList = (ArrayList)userSettingList[4];

            ArrayList moveAllowList = new ArrayList();
            moveAllowList = (ArrayList)userSettingList[5];

            DataRow dataRow;

            for (int index = 0; index < captionKeyList.Count; index++)
            {
                dataRow = dataTable.NewRow();
                dataRow[COLUMNROWNO] = index + 1;
                dataRow[COLUMNCAPTIONKEY] = captionKeyList[index];
                dataRow[COLUMNCAPTIONNAME] = captionNameList[index];
                dataRow[COLUMNVISIBLE] = visibleList[index];
                dataRow[COLUMNVISIBLEALLOW] = visibleAllowList[index];
                dataRow[COLUMNVISIBLEPOSITION] = visiblePositionList[index];
                dataRow[COLUMNMOVEALLOW] = moveAllowList[index];
                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_DetailControl.DataSource = dataTable;


            ColumnsCollection Columns = this.uGrid_DetailControl.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            this.uGrid_DetailControl.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // №
            Columns[COLUMNROWNO].Header.Fixed = true;
            Columns[COLUMNROWNO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            Columns[COLUMNROWNO].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[COLUMNROWNO].CellAppearance.BackColor2 = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[COLUMNROWNO].CellAppearance.BackGradientStyle = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[COLUMNROWNO].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            Columns[COLUMNROWNO].CellAppearance.ForeColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[COLUMNROWNO].CellAppearance.ForeColorDisabled = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[COLUMNROWNO].Hidden = false;
            Columns[COLUMNROWNO].Width = 25;
            Columns[COLUMNROWNO].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[COLUMNROWNO].CellActivation = Activation.Disabled;
            Columns[COLUMNROWNO].CellAppearance.TextHAlign = HAlign.Right;
            Columns[COLUMNROWNO].CellAppearance.BackColor = this.uGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[COLUMNROWNO].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNROWNO].Header.Caption = "No."; ;

            // 項目名
            Columns[COLUMNCAPTIONNAME].Header.Fixed = true;
            Columns[COLUMNCAPTIONNAME].Hidden = false;
            Columns[COLUMNCAPTIONNAME].Width = 100;
            Columns[COLUMNCAPTIONNAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[COLUMNCAPTIONNAME].CellActivation = Activation.NoEdit;
            Columns[COLUMNCAPTIONNAME].CellAppearance.TextHAlign = HAlign.Left;
            Columns[COLUMNCAPTIONNAME].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNCAPTIONNAME].Header.Caption = "項目";

            // 表示有無
            Columns[COLUMNVISIBLE].Header.Fixed = true;
            Columns[COLUMNVISIBLE].Hidden = false;
            Columns[COLUMNVISIBLE].Width = 40;
            Columns[COLUMNVISIBLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[COLUMNVISIBLE].Header.VisiblePosition = visiblePosition++;
            Columns[COLUMNVISIBLE].Header.Caption = "表示";

            Columns[COLUMNCAPTIONKEY].Hidden = true;
            Columns[COLUMNVISIBLEALLOW].Hidden = true;
            Columns[COLUMNVISIBLEPOSITION].Hidden = true;
            Columns[COLUMNMOVEALLOW].Hidden = true;

            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                bool visibleAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEALLOW].Value;

                if (visibleAllow == false)
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Activation = Activation.Disabled;
                }
                else
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Activation = Activation.AllowEdit;
                }
            }
        }

        /// <summary>
        /// ユーザー設定情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 画面からユーザー設定情報を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void ScreenToArrayVisible()
        {
            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                string captionKey = (string)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNCAPTIONKEY].Value;
                string captionName = (string)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNCAPTIONNAME].Value;
                bool visible = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value;
                bool visibleAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEALLOW].Value;
                int visiblePosition = (int)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                bool moveAllow = (bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNMOVEALLOW].Value;

                captionKeyList.Add(captionKey);
                captionNameList.Add(captionName);
                visibleList.Add(!visible);
                visibleAllowList.Add(visibleAllow);
                visiblePositionList.Add(visiblePosition);
                moveAllowList.Add(moveAllow);
            }

            this._userSettingList = new ArrayList();
            this._userSettingList.Add(captionKeyList);
            this._userSettingList.Add(captionNameList);
            this._userSettingList.Add(visibleList);
            this._userSettingList.Add(visibleAllowList);
            this._userSettingList.Add(visiblePositionList);
            this._userSettingList.Add(moveAllowList);
        }

        /// <summary>
        /// 初期ユーザー設定情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 初期ユーザー設定情報を作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// <br>Update Note : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// </remarks>
        private ArrayList CreateInitialSettingList()
        {
            ArrayList initialSettingList = new ArrayList();
            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            StockMoveInputDataSet.StockMoveDataTable tbl = this._stockMoveInputAcs.StockMoveDataTable;

            captionKeyList.Add(tbl.GoodsNoColumn.ColumnName);
            captionKeyList.Add(tbl.GoodsNameColumn.ColumnName);
            captionKeyList.Add(tbl.GoodsMakerCdColumn.ColumnName);
            captionKeyList.Add(tbl.MakerGuideButtonColumn.ColumnName);
            captionKeyList.Add(tbl.BLGoodsCodeColumn.ColumnName);
            captionKeyList.Add(tbl.BLCodeGuideButtonColumn.ColumnName);
            //---ADD 2011/04/11----------------------------------->>>>>
            captionKeyList.Add(tbl.SupplierCdColumn.ColumnName);
            captionKeyList.Add(tbl.SupplierCdGuideButtonColumn.ColumnName);
            //---ADD 2011/04/11-----------------------------------<<<<<
            captionKeyList.Add(tbl.MovingSupliStockColumn.ColumnName);
            captionKeyList.Add(tbl.StockUnitPriceFlColumn.ColumnName);
            captionKeyList.Add(tbl.ListPriceFlViewColumn.ColumnName);
            //captionKeyList.Add(tbl.BfSectionGuideNmColumn.ColumnName);
            //captionKeyList.Add(tbl.BfEnterWarehNameColumn.ColumnName);
            captionKeyList.Add(tbl.BfShelfNoColumn.ColumnName);
            captionKeyList.Add(tbl.AfShelfNoColumn.ColumnName);
            captionKeyList.Add(tbl.BfBeforeMoveCountColumn.ColumnName);
            captionKeyList.Add(tbl.BfAfterMoveCountColumn.ColumnName);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            captionKeyList.Add(tbl.AfBeforeMoveCountColumn.ColumnName);
            captionKeyList.Add(tbl.AfAfterMoveCountColumn.ColumnName);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            captionNameList.Add(tbl.GoodsNoColumn.Caption);
            captionNameList.Add(tbl.GoodsNameColumn.Caption);
            captionNameList.Add(tbl.GoodsMakerCdColumn.Caption);
            captionNameList.Add("メーカーガイドボタン");
            captionNameList.Add(tbl.BLGoodsCodeColumn.Caption);
            captionNameList.Add("BLコードガイドボタン");
            //---ADD 2011/04/11----------------------------------->>>>>
            captionNameList.Add(tbl.SupplierCdColumn.Caption);
            //captionNameList.Add("仕入先コードガイドボタン");//DEL 2011/05/20
            captionNameList.Add("仕入先ガイドボタン"); //ADD 2011/05/20
            //---ADD 2011/04/11-----------------------------------<<<<<
            captionNameList.Add(tbl.MovingSupliStockColumn.Caption);
            captionNameList.Add(tbl.StockUnitPriceFlColumn.Caption);
            captionNameList.Add(tbl.ListPriceFlViewColumn.Caption);
            //captionNameList.Add(tbl.BfSectionGuideNmColumn.Caption);
            //captionNameList.Add(tbl.BfEnterWarehNameColumn.Caption);
            captionNameList.Add(tbl.BfShelfNoColumn.Caption);
            captionNameList.Add(tbl.AfShelfNoColumn.Caption);
            captionNameList.Add(tbl.BfBeforeMoveCountColumn.Caption);
            captionNameList.Add(tbl.BfAfterMoveCountColumn.Caption);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            captionNameList.Add(tbl.AfBeforeMoveCountColumn.Caption);
            captionNameList.Add(tbl.AfAfterMoveCountColumn.Caption);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            // --- UPD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            ////for (int index = 0; index < 14; index++)// DEL 2011/04/11
            //for (int index = 0; index < 16; index++) // ADD 2011/04/11
            for (int index = 0; index < 18; index++)
            // --- UPD 2014/04/09 T.Miyamoto ------------------------------<<<<<
            {
                visibleList.Add(true);
            }

            visibleAllowList.Add(false);
            visibleAllowList.Add(false);
            visibleAllowList.Add(false);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            //---ADD 2011/04/11----------------------------------->>>>>
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            //---ADD 2011/04/11-----------------------------------<<<<<
            visibleAllowList.Add(false);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            //visibleAllowList.Add(true);
            //visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            visibleAllowList.Add(true);
            visibleAllowList.Add(true);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>

            visiblePositionList = (ArrayList)this._userSettingList[4];

            moveAllowList.Add(false);
            moveAllowList.Add(false);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            //---ADD 2011/04/11----------------------------------->>>>>
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            //---ADD 2011/04/11-----------------------------------<<<<<
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            //moveAllowList.Add(true);
            //moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            moveAllowList.Add(true);
            moveAllowList.Add(true);
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>

            initialSettingList.Add(captionKeyList);
            initialSettingList.Add(captionNameList);
            initialSettingList.Add(visibleList);
            initialSettingList.Add(visibleAllowList);
            initialSettingList.Add(visiblePositionList);
            initialSettingList.Add(moveAllowList);
            return initialSettingList;
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 初期値に戻すボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void uButton_DetailFocusUndo_Click(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < this.uGrid_DetailControl.Rows.Count; rowIndex++)
            {
                if ((Boolean)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value != true)
                {
                    this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNVISIBLE].Value = true;
                }
            }

            // 初期データ作成
            ArrayList initialSettingList = CreateInitialSettingList();

            SetGrid(initialSettingList);

            this.uGrid_DetailControl.UpdateData();

            this.uGrid_DetailControl.Rows[0].Activate();
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : ▲ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void uButton_UpDetailItem_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow == null)
            {
                return;
            }

            int activeRowIndex = this.uGrid_DetailControl.ActiveRow.Index;

            this.uGrid_DetailControl.BeginUpdate();

            try
            {
                // 表示位置変更可能チェック
                if (CheckVisiblePositionChange(activeRowIndex, 0) != true)
                {
                    return;
                }

                // 行番号変更
                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNROWNO].Value = activeRowIndex;
                this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNROWNO].Value = activeRowIndex + 1;

                int visiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                int afterVisiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNVISIBLEPOSITION].Value;

                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value = afterVisiblePosition;
                this.uGrid_DetailControl.Rows[activeRowIndex - 1].Cells[COLUMNVISIBLEPOSITION].Value = visiblePosition;

                // 行移動
                this.uGrid_DetailControl.Rows.Move(this.uGrid_DetailControl.ActiveRow, activeRowIndex - 1);
            }
            finally
            {
                this.uGrid_DetailControl.EndUpdate();
            }
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : ▼ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void uButton_DownDetailItem_Click(object sender, EventArgs e)
        {
            if (this.uGrid_DetailControl.ActiveRow == null)
            {
                return;
            }

            int activeRowIndex = this.uGrid_DetailControl.ActiveRow.Index;

            this.uGrid_DetailControl.BeginUpdate();
            
            try
            {
                // 表示位置変更可能チェック
                if (CheckVisiblePositionChange(activeRowIndex, 1) != true)
                {
                    return;
                }

                // 行番号変更
                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNROWNO].Value = activeRowIndex + 2;
                this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNROWNO].Value = activeRowIndex + 1;

                int visiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value;
                int afterVisiblePosition = (int)this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNVISIBLEPOSITION].Value;

                this.uGrid_DetailControl.Rows[activeRowIndex].Cells[COLUMNVISIBLEPOSITION].Value = afterVisiblePosition;
                this.uGrid_DetailControl.Rows[activeRowIndex + 1].Cells[COLUMNVISIBLEPOSITION].Value = visiblePosition;

                // 行移動
                this.uGrid_DetailControl.Rows.Move(this.uGrid_DetailControl.ActiveRow, activeRowIndex + 1);
            }
            finally
            {
                this.uGrid_DetailControl.EndUpdate();
            }
        }

        /// <summary>
        /// 表示位置変更可能チェック
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="upDownMode">UpDownモード(0:Up  1:Down)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 表示位置を変更できるかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/14</br>
        /// </remarks>
        private bool CheckVisiblePositionChange(int rowIndex, int upDownMode)
        {
            if ((bool)this.uGrid_DetailControl.Rows[rowIndex].Cells[COLUMNMOVEALLOW].Value == false)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "変更できない項目です。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                return (false);
            }

            if (upDownMode == 0)
            {
                if (rowIndex <= 2)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "移動出来ません。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                    return (false);
                }
            }
            else
            {
                if (rowIndex == this.uGrid_DetailControl.Rows.Count - 1)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "移動出来ません。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                    return (false);
                }
            }

            return (true);
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
    }
}
