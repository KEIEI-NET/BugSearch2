//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 受発注全体設定
// プログラム概要   : 受発注管理全体設定の設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 日色 馨
// 作 成 日  2007/12/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 96012 日色 馨
// 修 正 日  2007/12/21  修正内容 : HTMLの受発注計上時相手区分の項目名間違い修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 修 正 日  2008/06/06  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/09  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/06  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/19  修正内容 : 不具合対応[13578]
//----------------------------------------------------------------------------//
// 管理番号 10704766-00  作成担当：王飛3
// 修 正 日  2011/07/28  修正内容：連番909　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//                       拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正してください。
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 不具合対応による共通仕様の展開
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 不具合対応による共通仕様の展開
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	///	受発注管理全体設定クラス
	/// </summary>
	/// <remarks> 
	/// <br>note		: 受発注管理全体設定の設定を行います。
	///					  IMasterMaintenanceSingleTypeを実装しています。</br>              
	/// <br>Programer	: 日色 馨</br>                            
	/// <br>Date        : 2007.12.14</br>                              
    /// <br>Update Note : 2007.12.21 96012 日色 馨</br>
    /// <br> 			  HTMLの受発注計上時相手区分の項目名間違い修正</br>
    /// <br>Programmer :  30415 柴田 倫幸</br>
    /// <br>Date       :  2008/06/06</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>             : 2008/11/06       照田 貴志　バグ修正</br>
    /// <br>             : 2009/06/19       照田 貴志　不具合対応[13578]</br>
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// </remarks>
    public class DCKHN09230UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraLabel FaxOrderDiv_Title;
        private TComboEditor FaxOrderDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AcpOdrrSlipPrtDiv_Title;
        private TComboEditor AcpOdrrSlipPrtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstmCountReflectDiv_Title;
        private TComboEditor EstmCountReflectDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private DataSet Bind_DataSet;
        private UiSetControl uiSetControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// DCKHN09230UAコンストラクタ
		/// </summary>
		/// <remarks> 
		/// <br>note			:	受発注管理全体設定クラス、受発注管理全体設定アクセスクラスを生成します。
		///							フレーム画面の印刷ボタン非表示設定を行います。</br>
		/// <br>Programer		:	日色 馨</br>                            
        /// <br>Date			:	2007.12.14</br>                              
		/// </remarks>
		public DCKHN09230UA()
		{
			InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値
            this._canClose = false;	                      // 閉じる機能（デフォルトtrue固定）
            this._canDelete = true;		                  // 削除機能
            this._canLogicalDeleteDataExtraction = true;  // 論理削除データ表示機能
            this._canNew = true;		                  // 新規作成機能
            this._canPrint = false;	                      // 印刷機能
            this._canSpecificationSearch = false;	      // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	      // 列サイズ自動調整機能

			//　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 初期化
            this._dataIndex = -1;
            this._acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._acptAnOdrTtlStTable = new Hashtable();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // ADD 2008/09/16 不具合対応[5308] ---------->>>>>
            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.EstmCountReflectDiv_tComboEditor
            );
            // ADD 2008/09/16 不具合対応[5308] ----------<<<<<
		}
		# endregion

		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09230UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.EstmCountReflectDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.EstmCountReflectDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AcpOdrrSlipPrtDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.AcpOdrrSlipPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.FaxOrderDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.FaxOrderDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EstmCountReflectDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxOrderDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(364, 216);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 11;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(489, 216);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 12;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 268);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(630, 23);
            this.ultraStatusBar1.TabIndex = 25;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Mode_Label
            // 
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance25;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance26;
            this.Mode_Label.Location = new System.Drawing.Point(499, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 18;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // EstmCountReflectDiv_Title
            // 
            this.EstmCountReflectDiv_Title.Location = new System.Drawing.Point(12, 115);
            this.EstmCountReflectDiv_Title.Name = "EstmCountReflectDiv_Title";
            this.EstmCountReflectDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.EstmCountReflectDiv_Title.TabIndex = 31;
            this.EstmCountReflectDiv_Title.Text = "見積数反映区分";
            // 
            // EstmCountReflectDiv_tComboEditor
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmCountReflectDiv_tComboEditor.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstmCountReflectDiv_tComboEditor.Appearance = appearance17;
            this.EstmCountReflectDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EstmCountReflectDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstmCountReflectDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmCountReflectDiv_tComboEditor.ItemAppearance = appearance18;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "出荷数";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "受注数";
            this.EstmCountReflectDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.EstmCountReflectDiv_tComboEditor.Location = new System.Drawing.Point(180, 112);
            this.EstmCountReflectDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstmCountReflectDiv_tComboEditor.Name = "EstmCountReflectDiv_tComboEditor";
            this.EstmCountReflectDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.EstmCountReflectDiv_tComboEditor.TabIndex = 4;
            // 
            // AcpOdrrSlipPrtDiv_Title
            // 
            this.AcpOdrrSlipPrtDiv_Title.Location = new System.Drawing.Point(12, 145);
            this.AcpOdrrSlipPrtDiv_Title.Name = "AcpOdrrSlipPrtDiv_Title";
            this.AcpOdrrSlipPrtDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.AcpOdrrSlipPrtDiv_Title.TabIndex = 33;
            this.AcpOdrrSlipPrtDiv_Title.Text = "受注伝票発行区分";
            // 
            // AcpOdrrSlipPrtDiv_tComboEditor
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Appearance = appearance14;
            this.AcpOdrrSlipPrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AcpOdrrSlipPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.ItemAppearance = appearance15;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "しない";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "する";
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.AcpOdrrSlipPrtDiv_tComboEditor.Location = new System.Drawing.Point(180, 142);
            this.AcpOdrrSlipPrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Name = "AcpOdrrSlipPrtDiv_tComboEditor";
            this.AcpOdrrSlipPrtDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.AcpOdrrSlipPrtDiv_tComboEditor.TabIndex = 5;
            // 
            // FaxOrderDiv_Title
            // 
            this.FaxOrderDiv_Title.Location = new System.Drawing.Point(12, 175);
            this.FaxOrderDiv_Title.Name = "FaxOrderDiv_Title";
            this.FaxOrderDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.FaxOrderDiv_Title.TabIndex = 37;
            this.FaxOrderDiv_Title.Text = "ＦＡＸ発注区分";
            // 
            // FaxOrderDiv_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxOrderDiv_tComboEditor.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.FaxOrderDiv_tComboEditor.Appearance = appearance8;
            this.FaxOrderDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.FaxOrderDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FaxOrderDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxOrderDiv_tComboEditor.ItemAppearance = appearance9;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "しない";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "する";
            this.FaxOrderDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.FaxOrderDiv_tComboEditor.Location = new System.Drawing.Point(180, 172);
            this.FaxOrderDiv_tComboEditor.MaxDropDownItems = 18;
            this.FaxOrderDiv_tComboEditor.Name = "FaxOrderDiv_tComboEditor";
            this.FaxOrderDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.FaxOrderDiv_tComboEditor.TabIndex = 7;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(114, 216);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 9;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(239, 216);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 10;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(301, 50);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 68;
            this.SectionNm_Label.Text = "※ゼロで共通設定になります";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(114, 50);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCode_Leave);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(180, 50);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(149, 50);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(12, 51);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 64;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 93);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(603, 3);
            this.ultraLabel17.TabIndex = 69;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCKHN09230UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(630, 291);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.FaxOrderDiv_Title);
            this.Controls.Add(this.FaxOrderDiv_tComboEditor);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_Title);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_tComboEditor);
            this.Controls.Add(this.EstmCountReflectDiv_Title);
            this.Controls.Add(this.EstmCountReflectDiv_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09230UA";
            this.Text = "受発注管理全体設定";
            this.Load += new System.EventHandler(this.DCKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.EstmCountReflectDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxOrderDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		//public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;  // DEL 2008/06/06

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members
        /* --- DEL 2008/06/06 -------------------------------->>>>>
		private AcptAnOdrTtlSt acptAnOdrTtlSt;
		private AcptAnOdrTtlStAcs acptAnOdrTtlStAcs;
		private string _enterpriseCode;
           --- DEL 2008/06/06 --------------------------------<<<<< */

        private AcptAnOdrTtlStAcs _acptAnOdrTtlStAcs;	// 受発注管理全体設定アクセスクラス
        private SecInfoAcs _secInfoAcs;                 // 拠点マスタアクセスクラス
        private string _enterpriseCode;					// 企業コード
        private int _logicalDeleteMode;					// モード
        private Hashtable _acptAnOdrTtlStTable;			// 受発注管理全体設定テーブル

		//比較用clone
		private AcptAnOdrTtlSt _acptAnOdrTtlStClone;

		// プロパティ用
		/// <summary>
		/// 終了プロパティ
		/// </summary>
		/// <remarks>
		/// アセンブリを終了するか、しないかを取得又はセットします。
		/// </remarks>

        // --- ADD 2008/06/06 -------------------------------->>>>>
        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // プロパティ用
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool isError = false; // ADD 2011/09/07

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        private const string GUID_TITLE = "GUID";
        private const string ACPTANODRTTLST_TABLE = "ACPTANODRTTLST"; // テーブル名

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE = "削除日";
        private const string SECTIONCODE_TITLE = "コード";
        // DEL 2008/10/09 不具合対応[6469] ↓
        //private const string SECTIONNAME_TITLE = "拠点名称";
        private const string SECTIONNAME_TITLE = "拠点名";    // ADD 2008/10/09 不具合対応[6469]
        private const string ESTMCOUNTREFLECTDIV_TITLE = "見積数反映区分";
        private const string ACPODRRSLIPPRTDIV_TITLE = "受注伝票発行区分";
        private const string FAXORDERDIV_TITLE = "ＦＡＸ発注区分";

        // 見積数反映区分
        // ---DEL 2009/06/19 不具合対応[13578] -------------------------->>>>>
        //// 2009.03.18 30413 犬飼 出荷数を貸出数に変更 >>>>>>START
        ////private const string ESTMCOUNTREFLECTDIV_FORWARD = "出荷数";
        //private const string ESTMCOUNTREFLECTDIV_FORWARD = "貸出数";
        //// 2009.03.18 30413 犬飼 出荷数を貸出数に変更 <<<<<<END
        // ---DEL 2009/06/19 不具合対応[13578] --------------------------<<<<<
        private const string ESTMCOUNTREFLECTDIV_FORWARD = "出荷数";        //ADD 2009/06/19 不具合対応[13578]
        private const string ESTMCOUNTREFLECTDIV_RECEIVE = "受注数";

        // 受注伝票発行区分
        private const string ACPODRRSLIPPRTDIV_NO = "しない";
        private const string ACPODRRSLIPPRTDIV_YES = "する";

        // ＦＡＸ発注区分
        private const string FAXORDERDIV_NO = "しない";
        private const string FAXORDERDIV_YES = "する";

        // 未設定時に使用
        private const string UNREGISTER = "";
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";
        private const string HTML_ILLEGALVALUE = "該当無し";
           --- DEL 2008/06/06 --------------------------------<<<<< */
        
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // ADD 2008/09/16 不具合対応[5308] ---------->>>>>
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/16 不具合対応[5308] ----------<<<<<

#endregion

        # region Main
/// <summary>
/// アプリケーションのメイン エントリ ポイントです。
/// </summary>
[STAThread]
static void Main() 
{
    System.Windows.Forms.Application.Run(new DCKHN09230UA());
}
# endregion

        # region Properties
// --- ADD 2008/06/06 -------------------------------->>>>>
/// <summary>論理削除データ抽出可能設定プロパティ</summary>
/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
public bool CanLogicalDeleteDataExtraction
{
    get
    {
        return this._canLogicalDeleteDataExtraction;
    }
}

/// <summary>新規作成可能設定プロパティ</summary>
/// <value>新規作成が可能かどうかの設定を取得します。</value>
public bool CanNew
{
    get
    {
        return this._canNew;
    }
}

/// <summary>削除可能設定プロパティ</summary>
/// <value>削除が可能かどうかの設定を取得します。</value>
public bool CanDelete
{
    get
    {
        return this._canDelete;
    }
}

/// <summary>件数指定抽出可能設定プロパティ</summary>
/// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
public bool CanSpecificationSearch
{
    get
    {
        return this._canSpecificationSearch;
    }
}

/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
public bool DefaultAutoFillToColumn
{
    get
    {
        return this._defaultAutoFillToColumn;
    }
}

/// <summary>データセットの選択データインデックスプロパティ</summary>
/// <value>データセットの選択データインデックスを取得または設定します。</value>
public int DataIndex
{
    get
    {
        return this._dataIndex;
    }
    set
    {
        this._dataIndex = value;
    }
}
// --- ADD 2008/06/06 --------------------------------<<<<< 

/// <summary>
/// 印刷プロパティ
/// </summary>
/// <remarks>
/// 印刷可能かどうかの設定を取得します。（false固定）
/// </remarks>
public bool CanPrint
{
    get{ return _canPrint; }
}

/// <summary>
/// 画面クローズプロパティ
/// </summary>
/// <remarks>
/// 画面クローズを許可するかどうかの設定を取得または設定します。
/// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
/// </remarks>
public bool CanClose
{
    get{ return _canClose; }
    set{ _canClose = value; }
}
# endregion

        # region Public Methods
/// <summary>
///	印刷処理
/// </summary>
/// <returns>ステータス</returns>
/// <remarks>
/// <br>Note			:	（未実装）</br>
/// <br>Programmer		:	日色 馨</br>
/// <br>Date			:	2007.12.14</br>
/// </remarks>
public int Print()
{
    // 印刷用アセンブリをロードする（未実装）
    return 0;
}

/* --- DEL 2008/06/06 -------------------------------->>>>>
/// <summary>
///	HTMLコード取得処理
/// </summary>
/// <returns>HTMLコード</returns>
/// <remarks>
/// <br>Note		: ビュー用のＨＴＭＬコードを取得します。</br>
/// <br>Programmer	: 日色 馨</br>
/// <br>Date		: 2007.12.14</br>
/// <br>Update Note : 2007.12.21 96012 日色 馨</br>
/// <br> 			  HTMLの受発注計上時相手区分の項目名間違い修正</br>
/// </remarks>
public string GetHtmlCode()
{
    string outCode = "";
    // tHtmlGenerate部品の引数を生成する
    string[,] array = new string[9, 2];
    this.tHtmlGenerate1.Coltypes = new int[2];
    this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
    this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
    array[0, 0] = HTML_HEADER_TITLE; //「設定項目」
    array[0, 1] = HTML_HEADER_VALUE; //「設定値」
    array[1, 0] = this.OrderNumberCompo_Title.Text;		// 発注番号構成
    array[3, 0] = this.EstmCountReflectDiv_Title.Text;  // 見積数反映区分
    array[4, 0] = this.AcpOdrrSlipPrtDiv_Title.Text;    // 受注伝票発行区分
    array[6, 0] = this.FaxOrderDiv_Title.Text;          // ＦＡＸ発注区分
    array[7, 0] = this.DotKulOrderDiv_Title.Text;       // ドットクル発注区分
    int status = this.acptAnOdrTtlStAcs.Read(out this.acptAnOdrTtlSt, this._enterpriseCode);
    if (status == 0)
    {
        array[1, 1] = HTML_ILLEGALVALUE;
        array[2, 1] = HTML_ILLEGALVALUE;
        array[3, 1] = HTML_ILLEGALVALUE;
        array[4, 1] = HTML_ILLEGALVALUE;
        array[5, 1] = HTML_ILLEGALVALUE;
        array[6, 1] = HTML_ILLEGALVALUE;
        array[7, 1] = HTML_ILLEGALVALUE;
        array[8, 1] = HTML_ILLEGALVALUE;
        for (int iPos = 0; iPos < OrderNumberCompo_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.OrderNumberCompo.CompareTo(OrderNumberCompo_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[1, 1] = OrderNumberCompo_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < EstmCountReflectDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.EstmCountReflectDiv.CompareTo(EstmCountReflectDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[3, 1] = EstmCountReflectDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < AcpOdrrSlipPrtDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.AcpOdrrSlipPrtDiv.CompareTo(AcpOdrrSlipPrtDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[4, 1] = AcpOdrrSlipPrtDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
       for (int iPos = 0; iPos < FaxOrderDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.FaxOrderDiv.CompareTo(FaxOrderDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[6, 1] = FaxOrderDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < DotKulOrderDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.DotKulOrderDiv.CompareTo(DotKulOrderDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[7, 1] = DotKulOrderDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
    }
    else
    {
        array[1, 1] = HTML_UNREGISTER;
        array[2, 1] = HTML_UNREGISTER;
        array[3, 1] = HTML_UNREGISTER;
        array[4, 1] = HTML_UNREGISTER;
        array[5, 1] = HTML_UNREGISTER;
        array[6, 1] = HTML_UNREGISTER;
        array[7, 1] = HTML_UNREGISTER;
        array[8, 1] = HTML_UNREGISTER;
    }
    this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);
    return outCode;
}
   --- DEL 2008/06/06 --------------------------------<<<<< */

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = ACPTANODRTTLST_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchAcptAnOdrTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE,
                new GridColAppearance(MGridColDispType.DeletionDataBoth,
                ContentAlignment.MiddleLeft, "", Color.Red));

            // 拠点コード
            appearanceTable.Add(SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点名称
            appearanceTable.Add(SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));


            // 見積数反映区分
            appearanceTable.Add(ESTMCOUNTREFLECTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 受注伝票発行区分
            appearanceTable.Add(ACPODRRSLIPPRTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ＦＡＸ発注区分
            appearanceTable.Add(FAXORDERDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        # endregion

		# region private Methods
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable acptAnOdrTtlStTable = new DataTable(ACPTANODRTTLST_TABLE);
            acptAnOdrTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            acptAnOdrTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(ESTMCOUNTREFLECTDIV_TITLE , typeof(string));
            acptAnOdrTtlStTable.Columns.Add(ACPODRRSLIPPRTDIV_TITLE  , typeof(string));
            acptAnOdrTtlStTable.Columns.Add(FAXORDERDIV_TITLE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(acptAnOdrTtlStTable);
        }

		/// <summary>
		///	画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // ボタン配置
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

           // 見積数反映区分
            this.EstmCountReflectDiv_tComboEditor.Items.Clear();
            this.EstmCountReflectDiv_tComboEditor.Items.Add(0, ESTMCOUNTREFLECTDIV_FORWARD);
            this.EstmCountReflectDiv_tComboEditor.Items.Add(1, ESTMCOUNTREFLECTDIV_RECEIVE);
            this.EstmCountReflectDiv_tComboEditor.MaxDropDownItems = this.EstmCountReflectDiv_tComboEditor.Items.Count;

            // 受注伝票発行区分
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Clear();
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Add(0, ACPODRRSLIPPRTDIV_NO);
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Add(1, ACPODRRSLIPPRTDIV_YES);
            this.AcpOdrrSlipPrtDiv_tComboEditor.MaxDropDownItems = this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Count;

            // ＦＡＸ発注区分
            this.FaxOrderDiv_tComboEditor.Items.Clear();
            this.FaxOrderDiv_tComboEditor.Items.Add(0, FAXORDERDIV_NO);
            this.FaxOrderDiv_tComboEditor.Items.Add(1, FAXORDERDIV_YES);
            this.FaxOrderDiv_tComboEditor.MaxDropDownItems = this.FaxOrderDiv_tComboEditor.Items.Count;

		}

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchAcptAnOdrTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList acptAnOdrTtlSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._acptAnOdrTtlStAcs.SearchAll(out acptAnOdrTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlSts)
                        {
                            if (this._acptAnOdrTtlStTable.ContainsKey(acptAnOdrTtlSt.FileHeaderGuid) == false)
                            {
                                AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "見積初期値設定", 					// プログラム名称
                            "SearchAcptAnOdrTtlSt", 			// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = acptAnOdrTtlSts.Count;

            return status;
        }

        /// <summary>
        /// 受発注管理全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();

            // 受発注管理全体設定が存在していない
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5286] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(acptAnOdrTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_HIDE, 				                        // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/16 不具合対応[5286] ----------<<<<<

            status = this._acptAnOdrTtlStAcs.LogicalDelete(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "見積初期値設定", 					// プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/16 不具合対応[5286] ---------->>>>>
        /// <summary>
        /// 全社設定か判定します。
        /// </summary>
        /// <param name="acptAnOdrTtlSt">受発注管理全体設定</param>
        /// <returns><c>true</c> :全社設定である。<br/><c>false</c>:全社設定ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5286]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private static bool IsAllSection(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            return SectionUtil.IsAllSection(acptAnOdrTtlSt.SectionCode);
        }
        // ADD 2008/09/16 不具合対応[5286] ----------<<<<<

		/// <summary>
		///	画面情報－受発注管理全体設定クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	画面情報から受発注管理全体設定クラスにデータを
		///							格納します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void ScreenToAcptAnOdrTtlSt(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
		{
			if (acptAnOdrTtlSt == null)
			{
				// 新規の場合
				acptAnOdrTtlSt = new AcptAnOdrTtlSt();
			}
			//ヘッダ部
			acptAnOdrTtlSt.EnterpriseCode = this._enterpriseCode;
			//明細部(範囲外は-1を設定)
            //this.acptAnOdrTtlSt.OrderNumberCompo = (this.OrderNumberCompo_tComboEditor.Value == null) ? -1 : (Int32)this.OrderNumberCompo_tComboEditor.Value;  // DEL 2008/06/06
            acptAnOdrTtlSt.EstmCountReflectDiv = (this.EstmCountReflectDiv_tComboEditor.Value == null) ? -1 : (Int32)this.EstmCountReflectDiv_tComboEditor.Value;
            acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = (this.AcpOdrrSlipPrtDiv_tComboEditor.Value == null) ? -1 : (Int32)this.AcpOdrrSlipPrtDiv_tComboEditor.Value;
            acptAnOdrTtlSt.FaxOrderDiv = (this.FaxOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.FaxOrderDiv_tComboEditor.Value;
            //acptAnOdrTtlSt.DotKulOrderDiv = (this.DotKulOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.DotKulOrderDiv_tComboEditor.Value;  // DEL 2008/06/06

            acptAnOdrTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;  // ADD 2008/06/06
        }

        /// <summary>
        /// 受発注管理全体設定オブジェクト展開処理
		/// </summary>
        /// <param name="estimateDefSet">受発注管理全体設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : 受発注管理全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void AcptAnOdrTtlStToDataSet(AcptAnOdrTtlSt acptAnOdrTtlSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (acptAnOdrTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][DELETE_DATE] = acptAnOdrTtlSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = acptAnOdrTtlSt.SectionCode;
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == acptAnOdrTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            // --- ADD 2008/11/06 ----------------------------------------------------------------------------->>>>>
            // 拠点"00"時、"全社共通"を表示
            if ((string.IsNullOrEmpty(acptAnOdrTtlSt.SectionCode) == false) && (acptAnOdrTtlSt.SectionCode.Trim() == "00"))
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }
            // --- ADD 2008/11/06 -----------------------------------------------------------------------------<<<<<

            // 見積数反映区分
            switch (acptAnOdrTtlSt.EstmCountReflectDiv)
            {
                case 0:
                    wrkstr = ESTMCOUNTREFLECTDIV_FORWARD;          // 出荷数
                    break;
                case 1:
                    wrkstr = ESTMCOUNTREFLECTDIV_RECEIVE;          // 受注数
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][ESTMCOUNTREFLECTDIV_TITLE ] = wrkstr;

            // 受注伝票発行区分
            switch (acptAnOdrTtlSt.AcpOdrrSlipPrtDiv)
            {
                case 0:
                    wrkstr = ACPODRRSLIPPRTDIV_NO;          // しない
                    break;
                case 1:
                    wrkstr = ACPODRRSLIPPRTDIV_YES;         // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][ACPODRRSLIPPRTDIV_TITLE] = wrkstr;
 
    
            // ＦＡＸ発注区分
            switch (acptAnOdrTtlSt.FaxOrderDiv)
            {
                case 0:
                    wrkstr = FAXORDERDIV_NO;         // しない
                    break;
                case 1:
                    wrkstr = FAXORDERDIV_YES;        // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][FAXORDERDIV_TITLE] = wrkstr;
     

            // GUID
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][GUID_TITLE] = acptAnOdrTtlSt.FileHeaderGuid;

            if (this._acptAnOdrTtlStTable.ContainsKey(acptAnOdrTtlSt.FileHeaderGuid) == true)
            {
                this._acptAnOdrTtlStTable.Remove(acptAnOdrTtlSt.FileHeaderGuid);
            }
            this._acptAnOdrTtlStTable.Add(acptAnOdrTtlSt.FileHeaderGuid, acptAnOdrTtlSt);
        }

		/// <summary>
		///	画面情報－受発注管理全体設定クラス格納処理(保存確認メッセージ用)
		/// </summary>
		/// <param name="acptAnOdrTtlSt">受発注管理全体設定クラス</param>
		/// <remarks>
		/// <br>Note			:	画面情報から受発注管理全体設定クラスにデータを
		///							格納します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void DispToAcptAnOdrTtlSt(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            if (acptAnOdrTtlSt == null)
            {
                // 新規の場合
                acptAnOdrTtlSt = new AcptAnOdrTtlSt();
            }

            //ヘッダ部
            acptAnOdrTtlSt.EnterpriseCode = this._enterpriseCode;

            //明細部(範囲外は-1を設定)
            //acptAnOdrTtlSt.OrderNumberCompo = (this.OrderNumberCompo_tComboEditor.Value == null) ? -1 : (Int32)this.OrderNumberCompo_tComboEditor.Value;   // DEL 2008/06/06

            // 見積数反映区分
            acptAnOdrTtlSt.EstmCountReflectDiv = (this.EstmCountReflectDiv_tComboEditor.Value == null) ? -1 : (Int32)this.EstmCountReflectDiv_tComboEditor.Value;
            
            // 受注伝票発行区分
            acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = (this.AcpOdrrSlipPrtDiv_tComboEditor.Value == null) ? -1 : (Int32)this.AcpOdrrSlipPrtDiv_tComboEditor.Value;
            
            // FAX発行区分
            acptAnOdrTtlSt.FaxOrderDiv = (this.FaxOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.FaxOrderDiv_tComboEditor.Value;
            
            //acptAnOdrTtlSt.DotKulOrderDiv = (this.DotKulOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.DotKulOrderDiv_tComboEditor.Value;  // DEL 2008/06/06

            // 拠点コード
            acptAnOdrTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd();  // ADD 2008/06/06
            // ADD 2008/09/17 不具合対応[5310] ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                acptAnOdrTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/17 不具合対応[5310] ----------<<<<<
        }

        /// <summary>
		///	画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	受発注管理全体設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void AcptAnOdrTtlStToScreen(AcptAnOdrTtlSt acptAnOdrTtlSt)
		{
            //this.OrderNumberCompo_tComboEditor.Value = acptAnOdrTtlSt.OrderNumberCompo;     // DEL 2008/06/06
            this.EstmCountReflectDiv_tComboEditor.Value = acptAnOdrTtlSt.EstmCountReflectDiv;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Value = acptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
            this.FaxOrderDiv_tComboEditor.Value = acptAnOdrTtlSt.FaxOrderDiv;
            //this.DotKulOrderDiv_tComboEditor.Value = acptAnOdrTtlSt.DotKulOrderDiv;         // DEL 2008/06/06

            this.tEdit_SectionCodeAllowZero2.Value = acptAnOdrTtlSt.SectionCode.TrimEnd();                // ADD 2008/06/06
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == acptAnOdrTtlSt.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }

            // --- ADD 2008/11/06 ----------------------------------->>>>>
            // コードが00で名称取得できていない場合、"全社共通"をセット
            if ((this.tEdit_SectionCodeAllowZero2.Text == "00") &&
                (string.IsNullOrEmpty(this.SectionNm_tEdit.Text) == true))
            {
                this.SectionNm_tEdit.Value = "全社共通";
            }
            // --- ADD 2008/11/06 -----------------------------------<<<<<
        }

		/// <summary>
		///	受発注管理全体設定画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	受発注管理全体設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
		private void ScreenClear()
		{
            //this.OrderNumberCompo_tComboEditor.Clear();   // DEL 2008/06/06
            this.EstmCountReflectDiv_tComboEditor.Clear();
            this.AcpOdrrSlipPrtDiv_tComboEditor.Clear();
            this.FaxOrderDiv_tComboEditor.Clear();
            //this.DotKulOrderDiv_tComboEditor.Clear();     // DEL 2008/06/06

            // --- ADD 2008/06/06 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();            // 拠点コード
            this.SectionNm_tEdit.Clear();            // 拠点ガイド名称
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理）
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
		///			画面チェック処理
		/// </summary>
		/// <param name="control">コントロール</param>
		/// <param name="checkMessage">メッセージ</param>
		/// <returns>true:正常　false:異常</returns>
		/// <remarks>
		/// <br>Note		:	画面入力データのチェック結果を返却します。</br>
		/// <br>Programer	:	日色 馨</br>
        /// <br>Date		:	2007.12.14</br>
		/// </remarks>
		private bool CheckInputData(ref Control control,ref string checkMessage)
		{
            // --- ADD 2008/06/06 -------------------------------->>>>>
            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                checkMessage = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                return false;
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
            //// --- ADD 2011/09/07 -------------------------------->>>>>
            //if (this.tEdit_SectionCodeAllowZero2.TextLength == 1)
            //{
            //    checkMessage = SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND;
            //    return false;
            //}
            //// --- ADD 2011/09/07 --------------------------------<<<<<
            return true;
		}
		
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
		/// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        this.Hide();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        this.Hide();
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this._logicalDeleteMode)
            {
                case -1:
                    {
                        // 新規モード
                        this.Mode_Label.Text = INSERT_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 初期フォーカスをセット
                        this.tEdit_SectionCodeAllowZero2.Focus();

                        // 拠点コードのコメント表示
                        SectionNm_Label.Visible = true;

                        break;
                    }
                case 1:
                    {
                        // 削除モード
                        this.Mode_Label.Text = DELETE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false);

                        // 初期フォーカスをセット
                        this.Delete_Button.Focus();

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        break;
                    }
                default:
                    {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 拠点関係のコントロールを使用不可にする
                        tEdit_SectionCodeAllowZero2.Enabled = false;
                        SectionGd_ultraButton.Enabled = false;
                        SectionNm_tEdit.Enabled = false;

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;


                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;                     // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;               // ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                     // 拠点ガイド名称
            this.EstmCountReflectDiv_tComboEditor.Enabled = enabled;    // 見積数反映区分
            this.AcpOdrrSlipPrtDiv_tComboEditor.Enabled = enabled;      // 受注伝票発行区分
            this.FaxOrderDiv_tComboEditor.Enabled = enabled;            // ＦＡＸ発注区分

            // ちらつき防止の為
            this.Enabled = true;
        }

        /// <summary>
        /// 受発注管理全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定ブジェクトの完全削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = (AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid];

            // 受発注管理全体設定が存在していない
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5286] ---------->>>>>
            // 拠点コードが全社設定の場合、削除不可
            if (IsAllSection(acptAnOdrTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_DELETE, 				                    // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/16 不具合対応[5286] ----------<<<<<

            status = this._acptAnOdrTtlStAcs.Delete(acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._acptAnOdrTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "受発注管理全体設定", 				// プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        ///　保存処理(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
        /// </remarks>
        private bool SaveProc()
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            bool result = false;

            Control control = null;
            string checkMessage = "";
            bool ret = true;
            //画面データ入力チェック処理
            ret = CheckInputData(ref control, ref checkMessage);
            if (ret == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                    checkMessage, 						// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                return result;
            }
            AcptAnOdrTtlSt acptAnOdrTtlSt = null;
            // 画面から受発注管理全体設定表示クラスにデータをセットします。
            //ScreenToAcptAnOdrTtlSt();
            DispToAcptAnOdrTtlSt(ref acptAnOdrTtlSt);
            // 受発注管理全体設定登録
            int status = this._acptAnOdrTtlStAcs.Write(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "DCKHN09230U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCode.Focus();
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "受発注管理全体設定", 				// プログラム名称
                            "SaveAcptAnOdrTtlSt", 				// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return result;
                    }
            }
            DialogResult dialogResult = DialogResult.OK;
            Mode_Label.Text = UPDATE_MODE;
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.Cancel;
            this._acptAnOdrTtlStClone = null;
            this.DialogResult = dialogResult;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            result = true;
            return result;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!CheckInputData(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return result;
            }

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            AcptAnOdrTtlSt acptAnOdrTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();
            }
            DispToAcptAnOdrTtlSt(ref acptAnOdrTtlSt);

            // ADD 2008/09/16 不具合対応[5311] ---------->>>>>
            // 拠点コードが存在していない場合、登録しない。
            //if (!SectionUtil.ExistsCode(acptAnOdrTtlSt.SectionCode))// DEL 2011/09/07
            if (!SectionUtil.ExistsCode(acptAnOdrTtlSt.SectionCode) || acptAnOdrTtlSt.SectionCode == "0")//ADD 2011/09/07
            {
                TMsgDisp.Show(
                    this, 								                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 		                                        // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 					// 処理名称
                    TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                    SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // 表示するメッセージ
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                    // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return false;
            }
            // ADD 2008/09/16 不具合対応[5311] ----------<<<<<

            int status = this._acptAnOdrTtlStAcs.Write(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "DCKHN09230U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCodeAllowZero2.Focus();
                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "受発注管理全体設定", 			    // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            // acptAnOdrTtlStクラス
            this.acptAnOdrTtlSt = new AcptAnOdrTtlSt();
            int status = acptAnOdrTtlStAcs.Read(out this.acptAnOdrTtlSt, this._enterpriseCode);
            if (status == 0 || status == 9)
            {
                if (this.acptAnOdrTtlSt != null)
                {
                    Mode_Label.Text = UPDATE_MODE;
                    // 全体初期表示設定クラス画面展開処理
                    acptAnOdrTtlStToScreen();
                    // 初期フォーカスセット
                    this.OrderNumberCompo_tComboEditor.Focus();
                    //クローン作成
                    this._acptAnOdrTtlStClone = this.acptAnOdrTtlSt.Clone();
                    //画面情報を比較用クローンにコピーする　　　　　   
                    DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
                }
            }
            else
            {
                // サーチ
                TMsgDisp.Show(
                    this, 									// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
                    "DCKHN09230U", 							// アセンブリＩＤまたはクラスＩＤ
                    "受発注管理全体設定", 						// プログラム名称
                    "ScreenReconstruction", 				// 処理名称
                    TMsgDisp.OPE_READ, 						// オペレーション
                    "受発注管理全体設定の読み込みに失敗しました。", // 表示するメッセージ
                    status, 								// ステータス値
                    this.acptAnOdrTtlStAcs, 					// エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 					// 表示するボタン
                    MessageBoxDefaultButton.Button1);		// 初期表示ボタン
            }
               --- DEL 2008/06/06 --------------------------------<<<<< */

            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                AcptAnOdrTtlSt newAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                // 見積初期値設定オブジェクトを画面に展開
                AcptAnOdrTtlStToScreen(newAcptAnOdrTtlSt);

                // クローン作成
                this._acptAnOdrTtlStClone = newAcptAnOdrTtlSt.Clone();
                DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                AcptAnOdrTtlSt acptAnOdrTtlSt = (AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid];

                // 見積初期値設定オブジェクトを画面に展開
                AcptAnOdrTtlStToScreen(acptAnOdrTtlSt);

                if (acptAnOdrTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._acptAnOdrTtlStClone = acptAnOdrTtlSt.Clone();
                    DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
                }
                else
                {
                    // 削除モード
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this._indexBuf = this._dataIndex;

            ScreenInputPermissionControl();
        }

        /// <summary>
        /// 受発注管理全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定オブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();

            // 受発注管理全体設定が存在していない
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            status = this._acptAnOdrTtlStAcs.Revival(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                            "受発注管理全体設定", 				// プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._acptAnOdrTtlStAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }

                // --- ADD 2008/11/06 ---------------------------------------------------------->>>>>
                if ((sectionCode == "00") && (string.IsNullOrEmpty(sectionName) == true))
                {
                    sectionName = "全社共通";
                }
                // --- ADD 2008/11/06 ----------------------------------------------------------<<<<<
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        # endregion

		# region Control Events
		/// <summary>
		///	Form.Load イベント(DCKHN09230UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer		:	日色 馨</br>
		/// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void DCKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // --- ADD 2008/06/06 -------------------------------->>>>>
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; // ADD 2008/06/06
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // 画面初期設定処理
            ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();  // ADD 2008/09/16 不具合対応[5308]
        }

        /// <summary>
		///	Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	保存ボタンコントロールがクリックされたときに
		///							発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            if (!SaveProc())
            {			// 登録
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();

                // 新規モード
                this._logicalDeleteMode = -1;

                AcptAnOdrTtlSt newAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                // 受発注管理全体設定オブジェクトを画面に展開
                AcptAnOdrTtlStToScreen(newAcptAnOdrTtlSt);

                // クローン作成
                this._acptAnOdrTtlStClone = newAcptAnOdrTtlSt.Clone();
                DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);

                // _GridIndexバッファ保持
                this._indexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndexバッファ初期化（メインフレーム最小化対応）
                this._indexBuf = -2;

                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
		}

		/// <summary>
		///	Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	閉じるボタンコントロールがクリックされたときに
		///							発生します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //保存確認
            AcptAnOdrTtlSt compareAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
            if (this.acptAnOdrTtlSt != null)
            {
                compareAcptAnOdrTtlSt = this.acptAnOdrTtlSt.Clone();
                //現在の画面情報を取得する
                DispToAcptAnOdrTtlSt(ref compareAcptAnOdrTtlSt);
                //最初に取得した画面情報と比較
                if ((this._acptAnOdrTtlStClone == null)
                || (!(this._acptAnOdrTtlStClone.Equals(compareAcptAnOdrTtlSt))))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する 
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "DCKHN09230U", 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	// 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SaveAcptAnOdrTtlSt();
                                return;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
            }
            DialogResult dialogResult = DialogResult.Cancel;
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.Cancel;
            this._acptAnOdrTtlStClone = null;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                AcptAnOdrTtlSt compareAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                compareAcptAnOdrTtlSt = this._acptAnOdrTtlStClone.Clone();
                DispToAcptAnOdrTtlSt(ref compareAcptAnOdrTtlSt);

                // 最初に取得した画面情報と比較
                if (!(this._acptAnOdrTtlStClone.Equals(compareAcptAnOdrTtlSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "DCKHN09230", 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

		/// <summary>
		///	Form.Closing イベント(DCKHN09230UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
		///							ようとしたときに発生します。</br>
		/// <br>Programmer		:	日色 馨</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
		private void DCKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//this._acptAnOdrTtlStClone = null;  // DEL 2008/06/06

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;  // ADD 2008/06/06

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/// <summary>
		///				画面ＶｉｓｉｂｌｅＣｈａｎｇイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void DCKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();
                return;
            }

            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ちらつき防止の為
            this.Enabled = false;

            Initial_Timer.Enabled = true;
            ScreenClear();
        }

		/// <summary>
		/// 改行キー制御処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":
                    {
                        // 拠点コード
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
        }

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 不具合対応[6226]
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "DCKHN09230", 						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel, 		// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');//ADD 2011/09/07
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // 拠点コード名称クリア
                this.SectionNm_tEdit.Text = "";
            }

            // --- ADD 2008/11/06 ------------------------------------------------->>>>>
            //if ((this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') == "00") &&//DEL 2011/09/07
            if ((this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') == "00") && this.tEdit_SectionCodeAllowZero2.Text != "" && //ADD 2011/09/07
                (string.IsNullOrEmpty(this.SectionNm_tEdit.Text) == true))
            {
                this.SectionNm_tEdit.Value = "全社共通";
            }
 

        }

        # endregion

        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {


            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09230U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの受発注全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09230U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの受発注全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの受発注全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "DCKHN09230U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/07
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}
