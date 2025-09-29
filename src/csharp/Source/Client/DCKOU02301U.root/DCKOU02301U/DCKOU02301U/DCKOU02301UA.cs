//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷確認表
// プログラム概要   : 入荷確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢　貞義
// 作 成 日  2007/10/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馬淵 愛
// 修 正 日  2008/01/28  修正内容 : 日付制御部品の組込
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/25  修正内容 : 仕様変更に伴う変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/26  修正内容 : バグ修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13160(出荷日の任意化)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398（再修正。ラジオボタンの遷移補助を追加）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/26  修正内容 : 不具合対応[13590]　伝票区分「入荷」を「仕入」に変更(コントロールのItemを修正)
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/15 不具合対応[9659]

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 帳票・チャート印刷条件フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note	   : 帳票・チャート印刷条件フォームクラスです。</br>
	/// <br>Programmer : 980035 金沢　貞義</br>
	/// <br>Date	   : 2007.10.19</br>
	/// -----------------------------------------------------------------------------------------------------
	/// <br>UpdateNote	: 仕様変更に伴う変更。</br>
	///	<br>			　入力日付の追加、作表区分移動（出力条件→抽出条件）、出力順の追加、赤伝区分追加</br>
	/// <br>Programmer	: 30191 馬淵 愛</br>
	/// <br>Date		: 2008.01.28</br>
	/// -----------------------------------------------------------------------------------------------------
	/// <br>UpdateNote	: 共通修正。</br>
	///	<br>			　日付制御部品の組込</br>
	/// <br>Programmer	: 30191 馬淵 愛</br>
	/// <br>Date		: 2008.02.19</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: 仕様変更に伴う変更。</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008/06/25</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: バグ修正。</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/09/26</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応13160(出荷日の任意化)</br>
    /// <br>Programmer	: 上野 俊治</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応9803、11150、11153、12398</br>
    /// <br>Programmer	: 上野 俊治</br>
    /// <br>Date		: 2009/04/08</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応9803、11150、11153、12398（再修正。ラジオボタンの遷移補助を追加）</br>
    /// <br>Programmer	: 上野 俊治</br>
    /// <br>Date		: 2009/04/14</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: 不具合対応[13590]　伝票区分「入荷」を「仕入」に変更(コントロールのItemを修正)</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2009/06/26</br>
    /// </remarks>
	public class DCKOU02301UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel MAHNB02020UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
		private TComboEditor PrintOder_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
		private TDateEdit InputDayEd_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private TDateEdit InputDaySt_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel Date_Title_Label;
		private TNedit tNedit_SupplierCd_Ed;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private TComboEditor SlipDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
		private Infragistics.Win.Misc.UltraLabel ultraLabel28;
		private TEdit tEdit_StockAgentCode_Ed;
		private TEdit tEdit_StockAgentCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton StockAgentCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton StockAgentCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private ToolTip toolTip1;
		private TDateEdit ArrivalGoodsDayEd_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private TDateEdit ArrivalGoodsDaySt_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private TComboEditor DebitN_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private TComboEditor MakeShowDiv_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private TNedit SupplierSlipNoEd_Nedit;
		private TNedit SupplierSlipNoSt_Nedit;
		private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet PrindDailyFooter_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor NewPageType_tComboEditor;
        private TEdit tEdit_PartySalesSlipNum_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TEdit tEdit_PartySalesSlipNum_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private System.ComponentModel.IContainer components;
		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region constructer
        /// <summary>
        /// 入荷一覧表UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷一覧表UIクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// <br></br>
        /// </remarks>
        public DCKOU02301UA()
		{
			InitializeComponent();

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._salesFormalList = new SortedList();
			this._salesSlipKindList = new SortedList();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

			//日付チェック部品のインスタンスを生成
			this._dateGetAcs = DateGetAcs.GetInstance();

		}
		#endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		#region Dispose
        /// <summary>
        /// 破棄
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
		#endregion

		// ===================================================================================== //
		// Windowsフォームデザイナで生成されたコード
		// ===================================================================================== //
		#region Windows フォーム デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrindDailyFooter_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.NewPageType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ArrivalGoodsDayEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ArrivalGoodsDaySt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDaySt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Date_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_PartySalesSlipNum_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PartySalesSlipNum_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierSlipNoEd_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierSlipNoSt_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MakeShowDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.DebitN_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.StockAgentCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.StockAgentCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_StockAgentCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.SlipDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAHNB02020UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrindDailyFooter_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoEd_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoSt_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitN_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            this.MAHNB02020UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.PrindDailyFooter_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel37);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.NewPageType_tComboEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ArrivalGoodsDayEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ArrivalGoodsDaySt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDaySt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.Date_Title_Label);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(714, 104);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // PrindDailyFooter_ultraOptionSet
            // 
            this.PrindDailyFooter_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.PrindDailyFooter_ultraOptionSet.CheckedIndex = 0;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "しない";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "する";
            this.PrindDailyFooter_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.PrindDailyFooter_ultraOptionSet.Location = new System.Drawing.Point(443, 74);
            this.PrindDailyFooter_ultraOptionSet.Name = "PrindDailyFooter_ultraOptionSet";
            this.PrindDailyFooter_ultraOptionSet.Size = new System.Drawing.Size(130, 20);
            this.PrindDailyFooter_ultraOptionSet.TabIndex = 38;
            this.PrindDailyFooter_ultraOptionSet.Text = "しない";
            // 
            // ultraLabel37
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance18;
            this.ultraLabel37.Location = new System.Drawing.Point(366, 71);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel37.TabIndex = 39;
            this.ultraLabel37.Text = "日計印字";
            // 
            // ultraLabel21
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance8;
            this.ultraLabel21.Location = new System.Drawing.Point(24, 69);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel21.TabIndex = 37;
            this.ultraLabel21.Text = "改頁";
            // 
            // NewPageType_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ActiveAppearance = appearance68;
            this.NewPageType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ItemAppearance = appearance69;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "拠点";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "仕入先";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "しない";
            this.NewPageType_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.NewPageType_tComboEditor.LimitToList = true;
            this.NewPageType_tComboEditor.Location = new System.Drawing.Point(178, 70);
            this.NewPageType_tComboEditor.Name = "NewPageType_tComboEditor";
            this.NewPageType_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.NewPageType_tComboEditor.TabIndex = 36;
            // 
            // ArrivalGoodsDayEd_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ArrivalGoodsDayEd_tDateEdit.ActiveEditAppearance = appearance1;
            this.ArrivalGoodsDayEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ArrivalGoodsDayEd_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDayEd_tDateEdit.EditAppearance = appearance2;
            this.ArrivalGoodsDayEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ArrivalGoodsDayEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDayEd_tDateEdit.LabelAppearance = appearance3;
            this.ArrivalGoodsDayEd_tDateEdit.Location = new System.Drawing.Point(397, 9);
            this.ArrivalGoodsDayEd_tDateEdit.Name = "ArrivalGoodsDayEd_tDateEdit";
            this.ArrivalGoodsDayEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ArrivalGoodsDayEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ArrivalGoodsDayEd_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ArrivalGoodsDayEd_tDateEdit.TabIndex = 1;
            this.ArrivalGoodsDayEd_tDateEdit.TabStop = true;
            // 
            // ultraLabel7
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance4;
            this.ultraLabel7.Location = new System.Drawing.Point(366, 9);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel7.TabIndex = 5;
            this.ultraLabel7.Text = "～";
            // 
            // ArrivalGoodsDaySt_tDateEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ArrivalGoodsDaySt_tDateEdit.ActiveEditAppearance = appearance5;
            this.ArrivalGoodsDaySt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ArrivalGoodsDaySt_tDateEdit.CalendarDisp = true;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDaySt_tDateEdit.EditAppearance = appearance6;
            this.ArrivalGoodsDaySt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ArrivalGoodsDaySt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDaySt_tDateEdit.LabelAppearance = appearance7;
            this.ArrivalGoodsDaySt_tDateEdit.Location = new System.Drawing.Point(178, 9);
            this.ArrivalGoodsDaySt_tDateEdit.Name = "ArrivalGoodsDaySt_tDateEdit";
            this.ArrivalGoodsDaySt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ArrivalGoodsDaySt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ArrivalGoodsDaySt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ArrivalGoodsDaySt_tDateEdit.TabIndex = 0;
            this.ArrivalGoodsDaySt_tDateEdit.TabStop = true;
            // 
            // ultraLabel15
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance33;
            this.ultraLabel15.Location = new System.Drawing.Point(24, 9);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel15.TabIndex = 0;
            this.ultraLabel15.Text = "入荷日";
            // 
            // InputDayEd_tDateEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEd_tDateEdit.ActiveEditAppearance = appearance9;
            this.InputDayEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEd_tDateEdit.CalendarDisp = true;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.EditAppearance = appearance10;
            this.InputDayEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.LabelAppearance = appearance11;
            this.InputDayEd_tDateEdit.Location = new System.Drawing.Point(397, 40);
            this.InputDayEd_tDateEdit.Name = "InputDayEd_tDateEdit";
            this.InputDayEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEd_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEd_tDateEdit.TabIndex = 3;
            this.InputDayEd_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance12;
            this.ultraLabel10.Location = new System.Drawing.Point(366, 40);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // InputDaySt_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDaySt_tDateEdit.ActiveEditAppearance = appearance13;
            this.InputDaySt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDaySt_tDateEdit.CalendarDisp = true;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.EditAppearance = appearance14;
            this.InputDaySt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDaySt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.LabelAppearance = appearance15;
            this.InputDaySt_tDateEdit.Location = new System.Drawing.Point(178, 40);
            this.InputDaySt_tDateEdit.Name = "InputDaySt_tDateEdit";
            this.InputDaySt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDaySt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDaySt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDaySt_tDateEdit.TabIndex = 2;
            this.InputDaySt_tDateEdit.TabStop = true;
            // 
            // Date_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.Date_Title_Label.Appearance = appearance16;
            this.Date_Title_Label.Location = new System.Drawing.Point(24, 40);
            this.Date_Title_Label.Name = "Date_Title_Label";
            this.Date_Title_Label.Size = new System.Drawing.Size(140, 23);
            this.Date_Title_Label.TabIndex = 6;
            this.Date_Title_Label.Text = "入力日";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 187);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(714, 38);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance17;
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance36;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "仕入先→入荷日→仕入SEQ番号";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "入荷日→仕入先→仕入SEQ番号";
            valueListItem8.DataValue = 2;
            valueListItem8.DisplayText = "担当者→仕入先→入荷日→仕入SEQ番号";
            valueListItem9.DataValue = 3;
            valueListItem9.DisplayText = "入荷日→仕入SEQ番号";
            valueListItem10.DataValue = 4;
            valueListItem10.DisplayText = "仕入SEQ番号";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(178, 7);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 40;
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(24, 7);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 0;
            this.ultraLabel5.Text = "出力順";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_PartySalesSlipNum_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_PartySalesSlipNum_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierSlipNoEd_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierSlipNoSt_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.MakeShowDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.DebitN_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.StockAgentCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.StockAgentCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SlipDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 262);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(714, 195);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tEdit_PartySalesSlipNum_Ed
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum_Ed.ActiveAppearance = appearance41;
            this.tEdit_PartySalesSlipNum_Ed.AutoSelect = true;
            this.tEdit_PartySalesSlipNum_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_PartySalesSlipNum_Ed.DataText = "";
            this.tEdit_PartySalesSlipNum_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_PartySalesSlipNum_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PartySalesSlipNum_Ed.Location = new System.Drawing.Point(390, 99);
            this.tEdit_PartySalesSlipNum_Ed.MaxLength = 9;
            this.tEdit_PartySalesSlipNum_Ed.Name = "tEdit_PartySalesSlipNum_Ed";
            this.tEdit_PartySalesSlipNum_Ed.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySalesSlipNum_Ed.TabIndex = 155;
            // 
            // ultraLabel8
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance43;
            this.ultraLabel8.Location = new System.Drawing.Point(355, 101);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel8.TabIndex = 157;
            this.ultraLabel8.Text = "～";
            // 
            // tEdit_PartySalesSlipNum_St
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum_St.ActiveAppearance = appearance32;
            this.tEdit_PartySalesSlipNum_St.AutoSelect = true;
            this.tEdit_PartySalesSlipNum_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_PartySalesSlipNum_St.DataText = "";
            this.tEdit_PartySalesSlipNum_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_PartySalesSlipNum_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PartySalesSlipNum_St.Location = new System.Drawing.Point(178, 100);
            this.tEdit_PartySalesSlipNum_St.MaxLength = 9;
            this.tEdit_PartySalesSlipNum_St.Name = "tEdit_PartySalesSlipNum_St";
            this.tEdit_PartySalesSlipNum_St.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySalesSlipNum_St.TabIndex = 154;
            // 
            // ultraLabel2
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance59;
            this.ultraLabel2.Location = new System.Drawing.Point(24, 100);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel2.TabIndex = 156;
            this.ultraLabel2.Text = "伝票番号";
            // 
            // SupplierSlipNoEd_Nedit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.SupplierSlipNoEd_Nedit.ActiveAppearance = appearance20;
            appearance21.TextHAlignAsString = "Right";
            this.SupplierSlipNoEd_Nedit.Appearance = appearance21;
            this.SupplierSlipNoEd_Nedit.AutoSelect = true;
            this.SupplierSlipNoEd_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierSlipNoEd_Nedit.DataText = "";
            this.SupplierSlipNoEd_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierSlipNoEd_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SupplierSlipNoEd_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierSlipNoEd_Nedit.Location = new System.Drawing.Point(390, 70);
            this.SupplierSlipNoEd_Nedit.MaxLength = 9;
            this.SupplierSlipNoEd_Nedit.Name = "SupplierSlipNoEd_Nedit";
            this.SupplierSlipNoEd_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SupplierSlipNoEd_Nedit.Size = new System.Drawing.Size(82, 24);
            this.SupplierSlipNoEd_Nedit.TabIndex = 120;
            // 
            // SupplierSlipNoSt_Nedit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.SupplierSlipNoSt_Nedit.ActiveAppearance = appearance22;
            appearance23.TextHAlignAsString = "Right";
            this.SupplierSlipNoSt_Nedit.Appearance = appearance23;
            this.SupplierSlipNoSt_Nedit.AutoSelect = true;
            this.SupplierSlipNoSt_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierSlipNoSt_Nedit.DataText = "";
            this.SupplierSlipNoSt_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierSlipNoSt_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SupplierSlipNoSt_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierSlipNoSt_Nedit.Location = new System.Drawing.Point(178, 70);
            this.SupplierSlipNoSt_Nedit.MaxLength = 9;
            this.SupplierSlipNoSt_Nedit.Name = "SupplierSlipNoSt_Nedit";
            this.SupplierSlipNoSt_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SupplierSlipNoSt_Nedit.Size = new System.Drawing.Size(82, 24);
            this.SupplierSlipNoSt_Nedit.TabIndex = 110;
            // 
            // MakeShowDiv_tComboEditor
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ActiveAppearance = appearance24;
            this.MakeShowDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ItemAppearance = appearance25;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "全て";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "入荷計上";
            this.MakeShowDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12});
            this.MakeShowDiv_tComboEditor.LimitToList = true;
            this.MakeShowDiv_tComboEditor.Location = new System.Drawing.Point(178, 160);
            this.MakeShowDiv_tComboEditor.Name = "MakeShowDiv_tComboEditor";
            this.MakeShowDiv_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.MakeShowDiv_tComboEditor.TabIndex = 150;
            // 
            // ultraLabel6
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance26;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 160);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel6.TabIndex = 26;
            this.ultraLabel6.Text = "発行タイプ";
            // 
            // DebitN_tComboEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DebitN_tComboEditor.ActiveAppearance = appearance27;
            this.DebitN_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DebitN_tComboEditor.ItemAppearance = appearance28;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "黒伝";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "赤伝";
            valueListItem15.DataValue = 2;
            valueListItem15.DisplayText = "元黒";
            valueListItem16.DataValue = 3;
            valueListItem16.DisplayText = "全て";
            this.DebitN_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.DebitN_tComboEditor.LimitToList = true;
            this.DebitN_tComboEditor.Location = new System.Drawing.Point(599, 160);
            this.DebitN_tComboEditor.Name = "DebitN_tComboEditor";
            this.DebitN_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.DebitN_tComboEditor.TabIndex = 140;
            this.DebitN_tComboEditor.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance29;
            this.ultraLabel4.Location = new System.Drawing.Point(453, 160);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel4.TabIndex = 24;
            this.ultraLabel4.Text = "赤伝区分";
            this.ultraLabel4.Visible = false;
            // 
            // StockAgentCdEd_GuideBtn
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.StockAgentCdEd_GuideBtn.Appearance = appearance30;
            this.StockAgentCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.StockAgentCdEd_GuideBtn.Location = new System.Drawing.Point(480, 40);
            this.StockAgentCdEd_GuideBtn.Name = "StockAgentCdEd_GuideBtn";
            this.StockAgentCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.StockAgentCdEd_GuideBtn.TabIndex = 85;
            this.StockAgentCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.StockAgentCdEd_GuideBtn, "従業員ガイド");
            this.StockAgentCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.StockAgentCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // StockAgentCdSt_GuideBtn
            // 
            appearance31.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.StockAgentCdSt_GuideBtn.Appearance = appearance31;
            this.StockAgentCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.StockAgentCdSt_GuideBtn.Location = new System.Drawing.Point(268, 40);
            this.StockAgentCdSt_GuideBtn.Name = "StockAgentCdSt_GuideBtn";
            this.StockAgentCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.StockAgentCdSt_GuideBtn.TabIndex = 75;
            this.StockAgentCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.StockAgentCdSt_GuideBtn, "従業員ガイド");
            this.StockAgentCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.StockAgentCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance34;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(480, 10);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 65;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "仕入先検索");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance35;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(268, 10);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 55;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "仕入先検索");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // ultraLabel9
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance39;
            this.ultraLabel9.Location = new System.Drawing.Point(24, 40);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(138, 23);
            this.ultraLabel9.TabIndex = 12;
            this.ultraLabel9.Text = "担当者";
            // 
            // tEdit_StockAgentCode_Ed
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_Ed.ActiveAppearance = appearance40;
            this.tEdit_StockAgentCode_Ed.AutoSelect = true;
            this.tEdit_StockAgentCode_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_StockAgentCode_Ed.DataText = "";
            this.tEdit_StockAgentCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_Ed.Location = new System.Drawing.Point(390, 40);
            this.tEdit_StockAgentCode_Ed.MaxLength = 9;
            this.tEdit_StockAgentCode_Ed.Name = "tEdit_StockAgentCode_Ed";
            this.tEdit_StockAgentCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_Ed.TabIndex = 80;
            // 
            // tEdit_StockAgentCode_St
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_St.ActiveAppearance = appearance37;
            this.tEdit_StockAgentCode_St.AutoSelect = true;
            this.tEdit_StockAgentCode_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_StockAgentCode_St.DataText = "";
            this.tEdit_StockAgentCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_St.Location = new System.Drawing.Point(178, 40);
            this.tEdit_StockAgentCode_St.MaxLength = 9;
            this.tEdit_StockAgentCode_St.Name = "tEdit_StockAgentCode_St";
            this.tEdit_StockAgentCode_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_St.TabIndex = 70;
            // 
            // ultraLabel25
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance42;
            this.ultraLabel25.Location = new System.Drawing.Point(355, 41);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 76;
            this.ultraLabel25.Text = "～";
            // 
            // ultraLabel27
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance38;
            this.ultraLabel27.Location = new System.Drawing.Point(355, 71);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 115;
            this.ultraLabel27.Text = "～";
            // 
            // ultraLabel28
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance44;
            this.ultraLabel28.Location = new System.Drawing.Point(24, 70);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel28.TabIndex = 18;
            this.ultraLabel28.Text = "仕入SEQ番号";
            // 
            // SlipDiv_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ActiveAppearance = appearance46;
            this.SlipDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ItemAppearance = appearance47;
            valueListItem17.DataValue = 2;
            valueListItem17.DisplayText = "全て";
            valueListItem18.DataValue = 0;
            valueListItem18.DisplayText = "仕入";
            valueListItem19.DataValue = 1;
            valueListItem19.DisplayText = "返品";
            this.SlipDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18,
            valueListItem19});
            this.SlipDiv_tComboEditor.LimitToList = true;
            this.SlipDiv_tComboEditor.Location = new System.Drawing.Point(178, 130);
            this.SlipDiv_tComboEditor.Name = "SlipDiv_tComboEditor";
            this.SlipDiv_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.SlipDiv_tComboEditor.TabIndex = 130;
            // 
            // ultraLabel12
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance48;
            this.ultraLabel12.Location = new System.Drawing.Point(24, 130);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel12.TabIndex = 22;
            this.ultraLabel12.Text = "伝票区分";
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance50;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(390, 10);
            this.tNedit_SupplierCd_Ed.MaxLength = 9;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 60;
            // 
            // ultraLabel11
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance51;
            this.ultraLabel11.Location = new System.Drawing.Point(355, 11);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 56;
            this.ultraLabel11.Text = "～";
            // 
            // tNedit_SupplierCd_St
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance52;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance53;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(178, 10);
            this.tNedit_SupplierCd_St.MaxLength = 9;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_St.TabIndex = 50;
            // 
            // ultraLabel3
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance54;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "仕入先";
            // 
            // MAHNB02020UA_Fill_Panel
            // 
            this.MAHNB02020UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAHNB02020UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAHNB02020UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAHNB02020UA_Fill_Panel.Name = "MAHNB02020UA_Fill_Panel";
            this.MAHNB02020UA_Fill_Panel.Size = new System.Drawing.Size(750, 677);
            this.MAHNB02020UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(750, 677);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance55.FontData.Name = "ＭＳ ゴシック";
            appearance55.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance55;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance56;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 106;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance57;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 40;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　ソート順";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance58;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 197;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance45.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance45;
            appearance60.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance60;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(750, 677);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance61.FontData.SizeInPoints = 20F;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance61;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 560);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCKOU02301UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 677);
            this.Controls.Add(this.MAHNB02020UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCKOU02301UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrindDailyFooter_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoEd_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoSt_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitN_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            this.MAHNB02020UA_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).EndInit();
            this.Main_ultraExplorerBar.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region private member
		private string _enterpriseCode = "";

		private bool _printButtonEnabled = true;
		private bool _extraButtonEnabled = false;
		private bool _pdfButtonEnabled = true;
		private bool _printButtonVisibled = true;
		private bool _extraButtonVisibled = false;
		private bool _pdfButtonVisibled = true;
		private bool _visibledSelectAddUpCd = false;	// 計上拠点選択表示取得

		private int _selectedAddUpCd;

		private string _SalesTableDataTable;

		private Employee _loginWorker = null;

		// 自拠点コード
		private string _ownSectionCode = "";

		private ExtrInfo_DCKOU02304E _chartExtrInfo_DCKOU02304E = null;

		// 拠点アクセスクラス
		private static SecInfoAcs _secInfoAcs;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        private static SupplierAcs _supplierAcs;
        private static EmployeeAcs _employeeAcs;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

		//日付取得部品
		DateGetAcs _dateGetAcs;

		// 売上確認表アクセスクラス
		private DCKOU02306A _salesTableListAcs = null;

		private Hashtable _selectedhSectinTable = new Hashtable();
		// 拠点オプション有無
		private bool _isOptSection;
		// 本社機能有無
		private bool _isMainOfficeFunc;

		SortedList _salesFormalList;
		SortedList _salesSlipKindList;

		// エクスプローラバー拡大基準高さ
		private Form _topForm = null;
		//private bool _explorerBarExpanding = false;  // DEL 2008/06/25

		private ExtrInfo_DCKOU02304E _extrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();		//条件クラス(前回条件保持用)
		private ExtrInfo_DCKOU02304E _chart_ExtrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();		//条件クラス(チャート引渡し用)
		private DataSet _printBuffDataSet = null;

        // ADD 2009/01/15 不具合対応[9659]---------->>>>>
        /// <summary>範囲指定ガイドのフォーカス制御オブジェクトのリスト</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();
        /// <summary>
        /// 範囲指定ガイドのフォーカス制御オブジェクトのリストを取得します。
        /// </summary>
        /// <value>範囲指定ガイドのフォーカス制御オブジェクトのリスト</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }
        // ADD 2009/01/15 不具合対応[9659]----------<<<<<

        // --- ADD 2009/04/14 -------------------------------->>>>>
        /// <summary>日計印字ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 日計印字ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>日計印字ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PrintDailyFooterRadioKeyPressHelper
        {
            get { return _printDailyFooterRadioKeyPressHelper; }
        }
        // --- ADD 2009/04/14 --------------------------------<<<<<

		#endregion

		// ===================================================================================== //
		// プライベート定数
		// ===================================================================================== //
		#region private constant
		private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

		private const string THIS_ASSEMBLYID = "DCKOU02301U";
		private const string PDF_PRINT_KEY = "D086E2FA-69C3-4886-98FA-06DF7F43ACAE";
		//private const string PDF_PRINT_NAME = "入荷一覧表";  // DEL 2008/06/25
        private const string PDF_PRINT_NAME = "入荷確認表";  // ADD 2008/06/25

		private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

		// エクスプローラーバーの表示状態を決定するための基準となるトップフォームの高さ
		private const int CT_TOPFORM_BASE_HEIGHT = 768;
		#endregion

		// ===================================================================================== //
		// IPrintConditionInpType メンバ
		// ===================================================================================== //
		#region IPrintConditionInpType メンバ
		/// <summary>
		/// 印刷ボタン有効無効プロパティ
		/// </summary>
		public bool CanPrint
		{
			get
			{
				return _printButtonEnabled;
			}
		}

		/// <summary>
		/// 抽出ボタン有効無効プロパティ
		/// </summary>
		public bool CanExtract
		{
			get
			{
				return _extraButtonEnabled;
			}
		}

		/// <summary>
		/// PDFボタン有効無効プロパティ
		/// </summary>
		public bool CanPdf
		{
			get
			{
				return _pdfButtonEnabled;
			}
		}

		/// <summary>
		/// 印刷ボタン表示プロパティ
		/// </summary>
		public bool VisibledPrintButton
		{
			get
			{
				return _printButtonVisibled;
			}
		}

		/// <summary>
		/// 抽出ボタン表示プロパティ
		/// </summary>
		public bool VisibledExtractButton
		{
			get
			{
				return _extraButtonVisibled;
			}
		}

		/// <summary>
		/// PDFボタン表示プロパティ
		/// </summary>
		public bool VisibledPdfButton
		{
			get
			{
				return _pdfButtonVisibled;
			}
		}

		// ===================================================================================== //
		// IPrintConditionInpTypeCondition メンバ
		// ===================================================================================== //
		/// <summary>
		/// チャート用抽出条件設定
		/// </summary>
		public object ObjExtract
		{
			get
			{
				return _chartExtrInfo_DCKOU02304E;
			}
		}

		/// <summary>
		/// ツールバー表示制御イベント
		/// </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;


		/// <summary>
		/// Control.Showのオーバーロード
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面表示を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 印刷処理を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public int Print(ref object parameter)
		{

			SFCMN06001U printDialog = new SFCMN06001U();			// 帳票選択ガイド
			SFCMN06002C printInfo = parameter as SFCMN06002C;	  // 印刷情報パラメータ

			// 企業コード
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			printInfo.kidopgid = THIS_ASSEMBLYID;			  // 起動ＰＧＩＤ
			printInfo.key = PDF_PRINT_KEY;				 // PDF履歴管理用KEY情報

			// 画面→抽出条件クラス
			ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();
			this.SetExtraInfoFromScreen(out extrInfo_DCKOU02304E);

			// 抽出条件の設定
			printInfo.jyoken = extrInfo_DCKOU02304E;
			// チャート用条件設定

			// 一時コメントアウト****************************START
			//// 印刷帳票設定
			//if (extrInfo_DCKOU02304E.IsDetails == false)
			//{
			//	  printInfo.PrintPaperSetCd = 1;
			//}
			//else
			//{
			//	  printInfo.PrintPaperSetCd = 0;
			//}
			//***********************************************END
			printInfo.PrintPaperSetCd = 0;

			// データ抽出
			//int status = this.SearchData(extrInfo_DCKOU02304E);
			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

			//	  return status;
			//}

			printInfo.rdData = this._printBuffDataSet;
			printDialog.PrintInfo = printInfo;

			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			parameter = (Object)printInfo;

			return printInfo.status;
		}

		/// <summary>
		/// 印刷前チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 印刷前のチェック処理を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;

			// 画面の範囲指定項目の入力補助処理を追加
			this.ScreenInputAssist();

			// 画面入力条件チェック
			bool result = this.ScreenInputCheack(out message, ref errControl);
			if (!result)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				if (errControl != null) errControl.Focus();
			}
			return result;
		}

		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 抽出処理を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
			//int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			//return status;

			//int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
			int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;

            //ShipmentListCndtn extraInfo = new ShipmentListCndtn();	   // 抽出条件クラス

			//this.SetExtraInfoFromScreen(ref extraInfo);

			// データ抽出
			//status = this.SearchData(extraInfo);
			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//}
			//else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "データの抽出でエラーが発生しました", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//}
			return status;
		}
		#endregion

		// ===================================================================================== //
		// IPrintConditionInpTypePdfCareer メンバ
		// ===================================================================================== //
		#region IPrintConditionInpTypePdfCareer メンバ
		/// <summary>帳票KEYプロパティ</summary>
		/// <remarks>帳票の出力履歴取得用のKEY値を取得します。</remarks>
		public string PrintKey
		{
			get
			{
				return PDF_PRINT_KEY;
			}
		}

		/// <summary>帳票名プロパティ</summary>
		/// <remarks>帳票名を取得します。</remarks>
		public string PrintName
		{
			get
			{
				return PDF_PRINT_NAME;
			}
		}
		#endregion

        // ===================================================================================== //
		// メイン
		// ===================================================================================== //
		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.Run(new DCKOU02301UA());
		}
		#endregion

		// ===================================================================================== //
		// 内部使用関数
		// ===================================================================================== //
		#region private methods
		/// <summary>
		/// 初期画面設定
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 初期画面設定を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void InitialScreenSetting()
		{
            #region < 日付範囲 >
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
			//入力日
			this.InputDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.InputDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			this.InputDaySt_tDateEdit.SetLongDate(nowLongDate);
			this.InputDayEd_tDateEdit.SetLongDate(nowLongDate);
               --- DEL 2008/06/25 --------------------------------<<<<< */

			//入荷日
			this.ArrivalGoodsDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.ArrivalGoodsDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            // --- ADD 2008/06/25 -------------------------------->>>>>
			this.ArrivalGoodsDaySt_tDateEdit.SetLongDate(nowLongDate);
			this.ArrivalGoodsDayEd_tDateEdit.SetLongDate(nowLongDate);
            // --- ADD 2008/06/25 --------------------------------<<<<< 

			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < 改頁 >
            this.NewPageType_tComboEditor.Value = 0; // 拠点
            #endregion

            #region < 日計印字 >
            this.PrindDailyFooter_ultraOptionSet.Value = 0; // しない
            #endregion
            // --- ADD 2009/04/08 --------------------------------<<<<<

			#region < 出力順設定 >
			this.PrintOder_tComboEditor.Value = 0;
			#endregion

			#region < 伝票区分 >
			this.SlipDiv_tComboEditor.Value = 2;
			#endregion

			#region < 赤伝区分 >
			this.DebitN_tComboEditor.Value = 0;
			#endregion


			#region < 作表区分 >
            /* --- DEL 2008/09/26 「全て」をデフォルトとする為 -------------------------------------->>>>>
			//2008.01.28 A.Mabuchi START//////////////////////////////////////////////////////////////////
			//this.MakeShowDiv_ultraOptionSet.CheckedIndex = 0;
			this.MakeShowDiv_tComboEditor.Value = 1;
			//2008.01.28 A.Mabuchi END////////////////////////////////////////////////////////////////////
               --- DEL 2008/09/26 ------------------------------------------------------------------->>>>> */
            // --- ADD 2008/09/26 ------------------------------------------------------------------->>>>>
            this.MakeShowDiv_tComboEditor.Value = 0;    // 「全て」
            // --- ADD 2008/09/26 -------------------------------------------------------------------<<<<<
            #endregion

            #region < 初期値設定 >
            // 仕入先コード初期値設定
			//this.CustomerCodeSt_Nedit.SetInt(0);
			//this.CustomerCodeEd_Nedit.SetInt(999999999);
			#endregion
            

			#region < ガイドボタンのアイコン設定 >
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			StockInputCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockInputCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			StockInputCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockInputCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
               --- DEL 2008/06/25 --------------------------------<<<<< */
			StockAgentCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockAgentCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			StockAgentCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockAgentCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            #endregion

            // --- ADD 2008/09/26 ------------------------------->>>>>
            // 非表示 →画面ロード時に一瞬見える為、プロパティを直接Falseにしておく
                // 「赤伝区分」タイトル
                // 「赤伝区分」コンボボックス
            // 必須色
            //this.ArrivalGoodsDaySt_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // 入荷日From // DEL 2009/04/07
            //this.ArrivalGoodsDayEd_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // 入荷日To // DEL 2009/04/07
            this.NewPageType_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 改頁 // ADD 2009/04/08
            this.PrintOder_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 出力順
            this.SlipDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);             // 伝票区分
            this.MakeShowDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 作表区分
            // --- ADD 2008/09/26 -------------------------------<<<<<

        }

		/// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="control">チェック対象コントロール</param>
		/// <returns>true:チェックOK,false:チェックNG</returns>
		/// <remarks>
		/// <br>Note: 共通部品による日付の入力チェックを行います。</br>
		/// </remarks>
		private bool CheckDate(TDateEdit control)
		{
			Enum _checkD = this._dateGetAcs.CheckDate(ref control);

			string str_cD = _checkD.ToString();

			if (str_cD == "ErrorOfNoInput" || str_cD == "ErrorOfInvalid")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// 日付範囲チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note: 共通部品による日付範囲のチェックを行います。</br>
		/// </remarks>
		private bool CheckPeriod(DateTime startDate, DateTime endDate, int i)
		{
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 1, DateGetAcs.YmdType.YearMonthDay, startDate, endDate);

			string str_cP = _checkP.ToString();

			if (i == 1)
			{
				if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
				{
					return false;
				}
				else
				{
					return true;
				}

			}
			else
			{	//入荷日付は範囲が1ヶ月を超えてもエラーにしない
				if (str_cP == "ErrorOfReverse")
				{
					return false;
				}
				else
				{
					return true;
				}
			}

		}
		
		/// <summary>
		/// 画面入力チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private bool ScreenInputCheack(out string message, ref Control errControl)
		{
			message = "";
			bool result = false;
			errControl = null;

            #region
			//< 売上日付(開始) >
            //if (!InputDateEditCheack(this.SalesDateSt_tDateEdit))
			//{
			//	message = "売上日付の指定に誤りがあります";
			//	errControl = this.SalesDateSt_tDateEdit;
			//	return result;
            //}
            
            //< 売上日付(終了) >
            //if (!InputDateEditCheack(this.SalesDateEd_tDateEdit))
			//{
			//	message = "売上日付の指定に誤りがあります";
			//	errControl = this.SalesDateEd_tDateEdit;
			//	return result;
			//}
            #endregion

            // DEL 2009/01/15 不具合対応[9658] ---------->>>>>
            #region 削除コード
            //// --- ADD 2008/06/25 -------------------------------->>>>>
            //int checkDateRange;

            //checkDateRange = (int)this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref this.ArrivalGoodsDaySt_tDateEdit, ref this.ArrivalGoodsDayEd_tDateEdit, false);

            //switch (checkDateRange)
            //{
            //    case (int)DateGetAcs.CheckDateRangeResult.OK:

            //        break;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:

            //        message = "入荷日は3ヶ月の範囲内で入力してください";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfReverse:

            //        message = "入荷日の範囲に誤りがあります";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:

            //        message = "入荷日の指定に誤りがあります";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:

            //        message = "入荷日の指定に誤りがあります";
            //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:

            //        // ありえない。

            //        break;  
            //}
            //// --- ADD 2008/06/25 --------------------------------<<<<<
            #endregion
            // DEL 2009/01/15 不具合対応[9658] ----------<<<<<

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region 削除コード
            ////入荷日は何か入力されていた時だけチェック
            //if (ArrivalGoodsDaySt_tDateEdit.GetLongDate() != 0 || ArrivalGoodsDayEd_tDateEdit.GetLongDate() != 0)  // DEL 2008/06/25
            //{
            //    // 入荷日(開始)
            //    if (!CheckDate(this.ArrivalGoodsDaySt_tDateEdit))
            //    {
            //        message = "入荷日の指定に誤りがあります";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;
            //    }

            //    // 入荷日(終了)
            //    if (!CheckDate(this.ArrivalGoodsDayEd_tDateEdit))
            //    {
            //        message = "入荷日の指定に誤りがあります";
            //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
            //        return result;
            //    }

            //    DateTime dt_ShipmentDaySt = DateTime.ParseExact(this.ArrivalGoodsDaySt_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
            //    DateTime dt_ShipmentDayEd = DateTime.ParseExact(this.ArrivalGoodsDayEd_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            //    // 入荷日範囲チェック
            //    if (!CheckPeriod(dt_ShipmentDaySt, dt_ShipmentDayEd, 2))
            //    {
            //        message = "入荷日の範囲に誤りがあります";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;
            //    }
            //}
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            // ADD 2009/01/15 不具合対応[9658] ※仕入確認表より移植 ---------->>>>>
            // エラー条件メッセージ
            const string MSG_INPUT_ERROR        = "の入力が不正です";
            //const string MSG_NO_INPUT           = "を入力して下さい"; // DEL 2009/04/07
            const string MSG_RANGE_ERROR        = "の範囲指定に誤りがあります";
            //const string MSG_RANGE_OVER_ERROR   = "は３ヶ月の範囲内で入力して下さい"; // DEL 2009/04/07

            DateGetAcs.CheckDateRangeResult cdrResult;

            // 入荷日（開始～終了）
            //if (!CallCheckDateRange(
            //    out cdrResult,
            //    ref this.ArrivalGoodsDaySt_tDateEdit,
            //    ref this.ArrivalGoodsDayEd_tDateEdit,
            //    false,
            //    3
            //)) // DEL 2009/04/07
            if (!CallCheckDateRange(
                out cdrResult,
                ref this.ArrivalGoodsDaySt_tDateEdit,
                ref this.ArrivalGoodsDayEd_tDateEdit,
                true,
                0
            )) // ADD 2009/04/07
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        message = string.Format("開始入荷日{0}", MSG_NO_INPUT);
                    //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始入荷日{0}", MSG_INPUT_ERROR);
                            errControl = this.ArrivalGoodsDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        message = string.Format("終了入荷日{0}", MSG_NO_INPUT);
                    //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了入荷日{0}", MSG_INPUT_ERROR);
                            errControl = this.ArrivalGoodsDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("入荷日{0}", MSG_RANGE_ERROR);
                            errControl = this.ArrivalGoodsDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("入荷日{0}", MSG_RANGE_OVER_ERROR);
                    //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                result = false;
                return result;
            }
            // ADD 2009/01/15 不具合対応[9658] ※仕入確認表より移植 ----------<<<<<

            // DEL 2009/01/15 不具合対応[9658] ---------->>>>>
            #region 削除コード
            //// --- ADD 2008/06/25 -------------------------------->>>>>
            ////入力日は何か入力されていた時だけチェック
            //if (InputDaySt_tDateEdit.GetLongDate() != 0 || InputDayEd_tDateEdit.GetLongDate() != 0)  
            //{
            //    checkDateRange = (int)this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref this.InputDaySt_tDateEdit, ref this.InputDayEd_tDateEdit, false);

            //    switch (checkDateRange)
            //    {
            //        case (int)DateGetAcs.CheckDateRangeResult.OK:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:

            //            // 範囲チェックはエラーにしない

            //            break;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfReverse:

            //            message = "入力日の範囲に誤りがあります";
            //            errControl = this.InputDaySt_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:

            //            message = "入力日の指定に誤りがあります";
            //            errControl = this.InputDaySt_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:

            //            message = "入力日の指定に誤りがあります";
            //            errControl = this.InputDayEd_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:

            //            // ありえない。

            //            break;
            //    }
            //}
            //// --- ADD 2008/06/25 --------------------------------<<<<<
            #endregion
            // DEL 2009/01/15 不具合対応[9658] ----------<<<<<

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region 削除コード
            //// 入力日(開始)
            //if (!CheckDate(this.InputDaySt_tDateEdit))
            //{
            //    message = "入力日の指定に誤りがあります";
            //    errControl = this.InputDaySt_tDateEdit;
            //    return result;
            //}

            //// 入力日(終了)
            //if (!CheckDate(this.InputDayEd_tDateEdit))
            //{
            //    message = "入力日の指定に誤りがあります";
            //    errControl = this.InputDayEd_tDateEdit;
            //    return result;
            //}

            //DateTime dt_InputDaySt = DateTime.ParseExact(this.InputDaySt_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
            //DateTime dt_InputDayEd = DateTime.ParseExact(this.InputDayEd_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            //// 入力日範囲チェック
            //if (!CheckPeriod(dt_InputDaySt, dt_InputDayEd, 1))
            //{
            //    message = "入力日は1ヶ月の範囲内で入力してください";
            //    errControl = this.InputDaySt_tDateEdit;
            //    return result;
            //}
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            // ADD 2009/01/15 不具合対応[9657] ※仕入確認表より移植 ---------->>>>>
            // 入力日（開始～終了）
            if (!CallCheckInputDateRange(
                out cdrResult,
                ref this.InputDaySt_tDateEdit,
                ref this.InputDayEd_tDateEdit,
                true,
                3
            ))
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    return true;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始入力日{0}", MSG_INPUT_ERROR);
                            errControl = this.InputDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    return true;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了入力日{0}", MSG_INPUT_ERROR);
                            errControl = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("入力日{0}", MSG_RANGE_ERROR);
                            errControl = this.InputDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("入力日{0}", MSG_RANGE_OVER_ERROR);
                    //        errControl = this.InputDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                result = false;
                return result;
            }
            // ADD 2009/01/15 不具合対応[9657] ※仕入確認表より移植 ----------<<<<<

            #region < 仕入先コード範囲チェック >
            if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                if ((this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
			    {
				    message = "仕入先の範囲に誤りがあります";
				    errControl = this.tNedit_SupplierCd_St;
				    return result;
                }
            }

            #endregion

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region 削除コード
            //#region < 入力従業員コード範囲チェック >
            //if (this.StockInputCdSt_tEdit.DataText.CompareTo(this.StockInputCdEd_tEdit.DataText) > 0 )
            //{
            //    message = "入力者の範囲に誤りがあります";
            //    errControl = this.StockInputCdSt_tEdit;
            //    return result;
            //}
            //#endregion
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            #region < 担当者コード範囲チェック >
            if ((this.tEdit_StockAgentCode_St.DataText.Trim() != "") && (this.tEdit_StockAgentCode_Ed.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                //if (this.tEdit_StockAgentCode_St.DataText.CompareTo(this.tEdit_StockAgentCode_Ed.DataText) > 0)             // DEL 2008/06/25
                if (Int32.Parse(this.tEdit_StockAgentCode_St.DataText) > Int32.Parse(this.tEdit_StockAgentCode_Ed.DataText))  // ADD 2008/06/25
                {
                    message = "担当者の範囲に誤りがあります";
                    errControl = this.tEdit_StockAgentCode_St;
                    return result;
                }
            }
            #endregion

            #region < 伝票番号範囲チェック >
            //// 伝票番号範囲チェック
            //if ((this.AcceptAnOrderNoSt_tNedit.GetInt()) > (this.AcceptAnOrderNoEd_tNedit.GetInt()))
            //{
            //    message = "伝票番号の範囲に誤りがあります";
            //    errControl = this.AcceptAnOrderNoSt_tNedit;
            //    return result;
            //}
            // 仕入伝票番号範囲チェック
            if ((this.SupplierSlipNoSt_Nedit.DataText.Trim() != "") && (this.SupplierSlipNoEd_Nedit.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                if (this.SupplierSlipNoSt_Nedit.DataText.CompareTo(this.SupplierSlipNoEd_Nedit.DataText) > 0)
                {
                    //message = "伝票番号の範囲に誤りがあります"; // DEL 2009/04/08
                    message = "仕入SEQ番号の範囲に誤りがあります"; // ADD 2009/04/08
                    errControl = this.SupplierSlipNoSt_Nedit;
                    return result;
                }
                if ((this.SupplierSlipNoSt_Nedit.GetInt()) > (this.SupplierSlipNoEd_Nedit.GetInt()))
                {
                    //message = "伝票番号の範囲に誤りがあります"; // DEL 2009/04/08
                    message = "仕入SEQ番号の範囲に誤りがあります"; // ADD 2009/04/08
                    errControl = this.SupplierSlipNoSt_Nedit;
                    return result;
                }
            }

            #endregion

            return true;
		}

        // ADD 2009/01/15 不具合対応[9658] ---------->>>>>
        // HACK:2009/01/15
        /// <summary>
        /// 入荷日チェック処理呼び出し
        /// </summary>
        /// <remarks>
        /// 仕入確認表より移植
        /// </remarks>
        /// <param name="cdrResult"></param>
        /// <param name="startTDateEdit"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit startTDateEdit,
            ref TDateEdit endTDateEdit,
            bool mode,
            int range
        )
        {
            cdrResult = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                range,
                ref startTDateEdit,
                ref endTDateEdit,
                mode,
                false
            );
            if (startTDateEdit.Name.Equals("InputDaySt_tDateEdit"))
            {
                if (cdrResult.Equals(DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver))
                {
                    cdrResult = DateGetAcs.CheckDateRangeResult.OK;
                }
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // 入荷日を任意にするため、未入力はOKにする
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            return cdrResult.Equals(DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2009/01/15 不具合対応[9658] ----------<<<<<

        // ADD 2008/01/15 不具合対応[9657] ---------->>>>>
        /// <summary>
        /// 入力日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <remarks>
        /// 仕入確認表より移植
        /// </remarks>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="startTDateEdit">入力日（開始）</param>
        /// <param name="tde_Ed_AddUpADate">入力日（終了）</param>
        /// <param name="mode">モード</param>
        /// <param name="range">範囲</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit startTDateEdit,
            ref TDateEdit endTDateEdit,
            bool mode,
            int range
        )
        {
            cdrResult = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                0,
                ref startTDateEdit,
                ref endTDateEdit,
                true
            );

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // 入力日を任意にするため、未入力はOKにする
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2008/01/15 不具合対応[9657] ----------<<<<<

		/// <summary>
		/// 画面入力補助処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面の範囲指定の入力補助を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void ScreenInputAssist()
        {
            /* --- DEL 2008/09/26 コピーを行わない為 --------------------------------------------->>>>>
            #region < 入力日付 >
            if (this.InputDaySt_tDateEdit.LongDate != 0 && this.InputDayEd_tDateEdit.LongDate == 0)
			{
				this.InputDayEd_tDateEdit.SetLongDate(this.InputDaySt_tDateEdit.LongDate);
            }
            #endregion
               --- DEL 2008/09/26 ----------------------------------------------------------------<<<<< */

            // DEL 2009/01/15 不具合対応[9658] ---------->>>>>
            //#region < 入荷日付 >
            //if (this.ArrivalGoodsDaySt_tDateEdit.LongDate != 0 && this.ArrivalGoodsDayEd_tDateEdit.LongDate == 0)
            //{
            //    this.ArrivalGoodsDayEd_tDateEdit.SetLongDate(this.ArrivalGoodsDaySt_tDateEdit.LongDate);
            //}
            //#endregion
            // DEL 2009/01/15 不具合対応[9658] ----------<<<<<

            #region < 伝票番号 >
            // 伝票番号
            //if (this.SalesSlipNumSt_tEdit.DataText != "" && this.SalesSlipNumEd_tEdit.DataText == "")
            //{
            //    this.SalesSlipNumEd_tEdit.DataText = this.SalesSlipNumSt_tEdit.DataText;
            //}
            #endregion

            #region < 仕入先コード >
            //if (this.CustomerCodeSt_Nedit.DataText != "" && this.CustomerCodeEd_Nedit.DataText == "")
			//{
			//	this.CustomerCodeEd_Nedit.DataText = this.CustomerCodeSt_Nedit.DataText;
            //}
			//if (this.CustomerCodeSt_Nedit.GetInt() == 0)
			//{
			//    this.CustomerCodeSt_Nedit.SetInt(0);
			//}
			//if (this.CustomerCodeEd_Nedit.GetInt() == 0)
			//{
			//    this.CustomerCodeEd_Nedit.SetInt(999999999);
			//}
            #endregion

            #region < 入力従業員コード >
            //if (this.SalesInputCodeSt_tEdit.DataText != "" && this.SalesInputCodeEd_tEdit.DataText == "")
			//{
			//	this.SalesInputCodeEd_tEdit.DataText = this.SalesInputCodeSt_tEdit.DataText;
            //}
            #endregion

            #region < 担当者コード >
            //if (this.SalesEmployeeCdSt_tEdit.DataText != "" && this.SalesEmployeeCdEd_tEdit.DataText == "")
			//{
			//	this.SalesEmployeeCdEd_tEdit.DataText = this.SalesEmployeeCdSt_tEdit.DataText;
            //}
            #endregion
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="extraInfo"></param>
		/// <returns></returns>
		private int SearchData(ExtrInfo_DCKOU02304E extraInfo)
		{
			string message;
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// 抽出条件が変わっているならリモーティング
			if (this._printBuffDataSet == null || this._extrInfo_DCKOU02304E == null || !this._extrInfo_DCKOU02304E.Equals(extraInfo))
			{
				try
				{
					status = this._salesTableListAcs.Search(extraInfo, out message, 0);
					if (status == 0)
					{
						this._printBuffDataSet = this._salesTableListAcs._printDataSet;
					}
				}
				catch (Exception ex)
				{
					TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
						MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				}
				finally
				{
					// 戻り値を設定。異常の場合はメッセージを表示
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							this._extrInfo_DCKOU02304E = extraInfo.Clone();

							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
							status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
							break;
						default:
							status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
							break;
					}
				}
			}
			else
			{
				if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_SalesTableDataTable].Rows.Count == 0)
					status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				else
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

			return status;


		}

		/// <summary>
		/// 抽出条件設定処理(画面→抽出条件)
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面→抽出条件へ設定します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void SetExtraInfoFromScreen(out ExtrInfo_DCKOU02304E extraInfo)
		{
			extraInfo = new ExtrInfo_DCKOU02304E();

            #region < 企業コード >
            extraInfo.EnterpriseCode = this._enterpriseCode;
            #endregion

            #region < 選択拠点 >
            // 拠点オプションありのとき
			if (IsOptSection)
			{
				ArrayList secList = new ArrayList();
				// 全社選択かどうか
				if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
				{
					
					//AクラスSearchParaSet()で“全社の場合”のif文に入るための条件
					extraInfo.SectionCodes = new string[1];
					extraInfo.SectionCodes[0] = "0";
				
				}
				else
				{
					foreach (DictionaryEntry dicEntry in this._selectedhSectinTable)
					{
						if ((CheckState)dicEntry.Value == CheckState.Checked)
						{
							secList.Add(dicEntry.Key);
						}
					}
					extraInfo.SectionCodes = (string[])secList.ToArray(typeof(string));
                }
			}
			// 拠点オプションなしの時
			else
			{
				extraInfo.SectionCodes = new string[0];
				extraInfo.SectionCodes[0] = "0";
			}
            #endregion

            #region < 入荷日付 >
            // 入荷日付(開始)
			extraInfo.ArrivalGoodsDaySt = this.ArrivalGoodsDaySt_tDateEdit.GetLongDate();
			// 入荷日付(終了)
			extraInfo.ArrivalGoodsDayEd = this.ArrivalGoodsDayEd_tDateEdit.GetLongDate();
            #endregion

			#region < 入力日付 >
			// 入力日付(開始)
			extraInfo.InputDaySt = this.InputDaySt_tDateEdit.GetLongDate();
			// 入力日付(終了)
			extraInfo.InputDayEd = this.InputDayEd_tDateEdit.GetLongDate();

			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < 改頁 >
            extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageType_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < 日計印字 >
            extraInfo.PrintDailyFooter = Convert.ToInt32(this.PrindDailyFooter_ultraOptionSet.CheckedItem.DataValue);
            #endregion

            // --- ADD 2009/04/08 --------------------------------<<<<<

			#region < 出力順 >
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < 仕入先 >
            /* --- DEL 2008/06/25 -------------------------------->>>>>
            // 仕入先(開始)
			extraInfo.CustomerCodeSt = this.CustomerCodeSt_Nedit.GetInt();
			// 仕入先(終了)
			extraInfo.CustomerCodeEd = this.CustomerCodeEd_Nedit.GetInt();
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            // 仕入先(開始)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
            // 仕入先(終了)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- ADD 2008/06/25 --------------------------------<<<<< 
            #endregion

			#region < 入力者･担当者 >
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// 入力従業員コード(開始)
			extraInfo.StockInputCodeSt = this.StockInputCdSt_tEdit.Text;
			// 入力従業員コード(終了)
			extraInfo.StockInputCodeEd = this.StockInputCdEd_tEdit.Text;
               --- DEL 2008/06/25 --------------------------------<<<<< */
            /* --- DEL 2008/09/26 担当者からフォーカス移動せずPDFボタン押下時、担当者がゼロ詰めされない為 --->>>>>
			// 担当者コード(開始)
			extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            // 担当者コード(終了)
            extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;
               --- DEL 2008/09/26 ---------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/09/26 --------------------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(this.tEdit_StockAgentCode_St.Text))
            {
                extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            }
            else
            {
                extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text.PadLeft(4, '0');
            }
            if (string.IsNullOrEmpty(this.tEdit_StockAgentCode_Ed.Text))
            {
                extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;
            }
            else
            {
                extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text.PadLeft(4,'0');
            }
            // --- ADD 2008/09/26 ---------------------------------------------------------------------------<<<<<

			#endregion
			
			#region < 伝票番号 >
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.31 T-Kidate START
			//// 伝票番号(開始)
			//extraInfo.AcceptAnOrderNoSt = this.AcceptAnOrderNoSt_tNedit.GetInt();
			//// 伝票番号(終了)
			//extraInfo.AcceptAnOrderNoEd = this.AcceptAnOrderNoEd_tNedit.GetInt();
			// 仕入伝票番号(開始)
            extraInfo.SupplierSlipNoSt = this.SupplierSlipNoSt_Nedit.GetInt();
            // 仕入伝票番号(終了)
            extraInfo.SupplierSlipNoEd = this.SupplierSlipNoEd_Nedit.GetInt();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.31 T-Kidate END
			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < 相手先伝票番号 >
            extraInfo.PartySalesSlipNumSt = this.tEdit_PartySalesSlipNum_St.DataText;
            extraInfo.PartySalesSlipNumEd = this.tEdit_PartySalesSlipNum_Ed.DataText;
            #endregion
            // --- ADD 2009/04/08 --------------------------------<<<<<
			
			#region < 伝票区分 >
            // 伝票区分
			extraInfo.SlipDiv = Convert.ToInt32(this.SlipDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.SlipDivName = this.SlipDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

            /* --- DEL 2008/09/26 赤伝区分削除の為 -------------------------------------------------------->>>>>
			#region < 赤伝区分 >
			// 赤伝区分
			extraInfo.DebitNoteDiv = Convert.ToInt32(this.DebitN_tComboEditor.SelectedItem.DataValue);
			extraInfo.DebitNoteDivName = this.DebitN_tComboEditor.SelectedItem.DisplayText;
			#endregion
               --- DEL 2008/09/26 -------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/09/26 ------------------------------------------------------------------------->>>>>
            extraInfo.DebitNoteDiv = 3;                     // 「全て」固定
            extraInfo.DebitNoteDivName = string.Empty;
            // --- ADD 2008/09/26 -------------------------------------------------------------------------<<<<<

            #region < 作表区分 >
            extraInfo.MakeShowDiv = Convert.ToInt32(this.MakeShowDiv_tComboEditor.SelectedItem.DataValue);
			extraInfo.MakeShowDivName = MakeShowDiv_tComboEditor.SelectedItem.DisplayText;
			#endregion

		}

		/// <summary>
		/// 起動モード毎データテーブル設定
		/// </summary>
		private void SettingDataTable()
		{
			_SalesTableDataTable = Broadleaf.Application.UIData.DCKOU02305EA.ct_Tbl_ArrivalDtl;
		}

		/// <summary>
		/// 最上位フォーム取得
		/// </summary>
		/// <remarks>
		/// <br>Note		: </br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.10.19</br>
        /// </remarks>
		private void GetTopForm()
		{
			// 最上位の親コントロールを取得する
			Control parent = this.Parent;

			while (parent != null)
			{
				if (parent.Parent == null) break;

				parent = parent.Parent;
			}

			if (parent != null)
			{
				if (parent is Form)
				{
					this._topForm = (Form)parent;
					this._topForm.SizeChanged += new EventHandler(TopForm_SizeChanged);
				}
			}
		}

		/// <summary>
		/// トップフォームサイズ変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TopForm_SizeChanged(object sender, EventArgs e)
		{
			this.AdjustExplorerBarExpand();
		}

		/// <summary>
		/// エクスプローラーバー展開状態調整
		/// </summary>
		private void AdjustExplorerBarExpand()
		{
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if (this._topForm == null) return;

			if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
			{
				// トップフォームの高さが基準値より高い場合
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
			else
			{
				// トップフォームの高さが基準値より低い場合
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
               --- DEL 2008/06/25 --------------------------------<<<<< */
		}

		/// <summary>
		/// エラーメッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">エラーステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">初期フォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note	   : エラーメッセージを表示します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
		}

		/// <summary>
		/// 終了項目値自動設定処理(TDateEdit)
		/// </summary>
		/// <param name="startDate">開始日付項目TDateEdit</param>
		/// <param name="endDate">終了日付項目TDateEdit</param>
		private void AutoSetEndValue(TDateEdit startDate, TDateEdit endDate)
		{
			if (endDate.LongDate == 0)
			{
				endDate.SetLongDate(startDate.LongDate);
			}
		}

		/// <summary>
		/// 終了項目値自動設定処理(TEdit)
		/// </summary>
		/// <param name="startEdit">開始文字列項目TEdit</param>
		/// <param name="endEdit">終了文字列項目TEdit</param>
		private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
		{
			if (endEdit.Text == "")
			{
				endEdit.Text = startEdit.Text;
			}
		}

		/// <summary>
		/// 終了項目値自動設定処理(TNedit)
		/// </summary>
		/// <param name="startNedit">開始数値項目TEdit</param>
		/// <param name="endNedit">終了数値項目TEdit</param>
		private void AutoSetEndValue(TNedit startNedit, TNedit endNedit)
		{
			if ((endNedit.GetInt() == 0) &&
				(startNedit.GetInt() != 0))
			{
				endNedit.SetInt(startNedit.GetInt());
			}
		}

		#endregion

        #region internal methods
        /// <summary>
		/// 拠点制御アクセスクラスインスタンス化処理
		/// </summary>
		internal void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ログイン担当拠点情報の取得
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

		/// <summary>
		/// 本社機能／拠点機能チェック処理
		/// </summary>
		/// <returns>true:本社機能 false:拠点機能</returns>
		public bool GetMainOfficeFunc()
		{
			bool isMainOfficeFunc = false;

			// 拠点制御アクセスクラスインスタンス化処理
			this.CreateSecInfoAcs();

			// ログイン担当拠点情報の取得
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet != null)
			{
				// 本社機能か？
				if (secInfoSet.MainOfficeFuncFlag == 1)
				{
					isMainOfficeFunc = true;
				}
			}
			else
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}

			return isMainOfficeFunc;
        }
        #endregion

        // ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region Control Event
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note		: 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.10.19</br>
        /// </remarks>
		private void SFUKK01390UA_Load(object sender, System.EventArgs e)
		{
			this.SettingDataTable();
			this._salesTableListAcs = new DCKOU02306A();

			// 最上位フォーム取得
			this.GetTopForm();

			// 拠点オプション有無を取得する
			this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

			// 本社/拠点情報を取得する
			this._isMainOfficeFunc = this.GetMainOfficeFunc();

            // ADD 2009/01/15 不具合対応[9659]---------->>>>>
            // 仕入先：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.CustomerCdSt_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));
            // 仕入先：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_Ed,
                this.CustomerCdEd_GuideBtn,
                this.tEdit_StockAgentCode_St
            ));

            // 担当者：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_St,
                this.StockAgentCdSt_GuideBtn,
                this.tEdit_StockAgentCode_Ed
            ));
            // 担当者：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_Ed,
                this.StockAgentCdEd_GuideBtn,
                this.SupplierSlipNoSt_Nedit
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            // ADD 2009/01/15 不具合対応[9659]----------<<<<<

            // --- ADD 2009/04/14 -------------------------------->>>>>
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.PrindDailyFooter_ultraOptionSet);
            PrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/04/14 --------------------------------<<<<<

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// 画面アクティブイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note	   : 元帳メイン画面がアクティブになったときのイベント処理です。</br>
		/// <br>Programer  : 18012　Y.Sasaki</br>
		/// <br>Date	   : 2005.09.12</br>
		/// </remarks>
		private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
		{
			ParentToolbarSettingEvent(this);
		}

		/// <summary>
		/// tArrowKey ＆ tRetKey イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note	   : コントロールでキーが押されてフォーカス移動したときのイベント処理です。</br>
		/// <br>Programer  : 30005　木建　翼</br>
		/// <br>Date	   : 2007.04.03</br>
		/// </remarks>
		private void tKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// 入力支援 ============================================ //
            /* --- DEL 2008/09/26 終了へのコピーを行わない為 --------------------------------------->>>>>
			// 入力日
			if ((e.PrevCtrl == this.InputDaySt_tDateEdit) ||
				(e.PrevCtrl == this.InputDayEd_tDateEdit))
			{
				AutoSetEndValue(this.InputDaySt_tDateEdit, this.InputDayEd_tDateEdit);
			}
               --- DEL 2008/09/26 ------------------------------------------------------------------<<<<< */
            // 売上伝票番号
            //if ((e.PrevCtrl == this.SalesSlipNumSt_tEdit) ||
            //    (e.PrevCtrl == this.SalesSlipNumEd_tEdit))
            //{
            //    AutoSetEndValue(this.SalesSlipNumSt_tEdit, this.SalesSlipNumEd_tEdit);
            //}

			// 仕入先コード
			//if ((e.PrevCtrl == this.CustomerCodeSt_Nedit) ||
			//	(e.PrevCtrl == this.CustomerCodeEd_Nedit))
			//{
			//	AutoSetEndValue(this.CustomerCodeSt_Nedit, this.CustomerCodeEd_Nedit);
			//}
            
			//2008.02.01 A.Mabuchi START-----------------------------------------------------------------
			//if ((e.PrevCtrl == this.CustomerCodeSt_Nedit) && (this.CustomerCodeSt_Nedit.GetInt() == 0))
			//{
			//    this.CustomerCodeSt_Nedit.SetInt(0);
			//}
			//if ((e.PrevCtrl == this.CustomerCodeEd_Nedit) && (this.CustomerCodeEd_Nedit.GetInt() == 0))
			//{
			//    this.CustomerCodeEd_Nedit.SetInt(999999999);
			//}
			//2008.02.01 A.Mabuchi START-----------------------------------------------------------------

            // 入力従業員コード
			//if ((e.PrevCtrl == this.SalesInputCodeSt_tEdit) ||
			//	(e.PrevCtrl == this.SalesInputCodeEd_tEdit))
			//{
			//	AutoSetEndValue(this.SalesInputCodeSt_tEdit, this.SalesInputCodeEd_tEdit);
			//}

			// 担当者コード
			//if ((e.PrevCtrl == this.SalesEmployeeCdSt_tEdit) ||
			//	(e.PrevCtrl == this.SalesEmployeeCdEd_tEdit))
			//{
			//	AutoSetEndValue(this.SalesEmployeeCdSt_tEdit, this.SalesEmployeeCdEd_tEdit);
			//}

            // --- ADD 2008/09/26 ------------------------------------------------------------------>>>>>
            if (e.ShiftKey)
            {
                return;
            }
            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
            {
                // 仕入先From
                if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tNedit_SupplierCd_St.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text) == false))
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    return;
                }
                // 仕入先To
                if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tNedit_SupplierCd_Ed.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text) == false))
                    {
                        e.NextCtrl = this.tEdit_StockAgentCode_St;
                    }
                    return;
                }
                // 担当者From
                if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tEdit_StockAgentCode_St.Text != "0") && (string.IsNullOrEmpty(this.tEdit_StockAgentCode_St.Text) == false))
                    {
                        e.NextCtrl = this.tEdit_StockAgentCode_Ed;
                    }
                    return;
                }
                // 担当者To
                if (e.PrevCtrl == this.tEdit_StockAgentCode_Ed)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tEdit_StockAgentCode_Ed.Text != "0") && (string.IsNullOrEmpty(this.tEdit_StockAgentCode_Ed.Text) == false))
                    {
                        e.NextCtrl = this.SupplierSlipNoSt_Nedit;
                    }
                    return;
                }
            }
            // --- ADD 2008/09/26 ------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// 初期タイマーイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note		: 初期処理を行います。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.10.19</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// 画面初期表示
			this.InitialScreenSetting();

			// 初期フォーカス設定
			//this.InputDaySt_tDateEdit.Focus();  // DEL 2008/06/25
            this.ArrivalGoodsDaySt_tDateEdit.Focus();  // ADD 2008/06/25

			// メインフレームにツールバー設定通知
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

		///// <summary>
		///// Control.GroupCollapsingイベント
		///// </summary>
		///// <param name="sender">イベントオブジェクト</param>
		///// <param name="e">イベント引数</param>
		///// <remarks>
		///// <br>Note		: エクスプローラバーのグループを展開される際に発生します。</br>
		///// <br>Programmer  : 980035 金沢　貞義</br>
		///// <br>Date	    : 2007.10.19</br>
		///// </remarks>
		//private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		//{
		//    if (this._explorerBarExpanding) return;

		//    this._explorerBarExpanding = true;

		//    try
		//    {
		//        if (!e.Group.Key.Equals(EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
		//        {
		//            e.Cancel = true;
		//        }
		//    }
		//    finally
		//    {
		//        this._explorerBarExpanding = false;
		//    }
		//}

		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
		/// <br>Programmer	: 馬淵 愛</br>
		/// <br>Date		: 2008.01.31</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "PrintOderGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup"))
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}

		/// <summary>
		/// GroupExpanding Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
		/// <br>Programmer	: 馬淵 愛</br>
		/// <br>Date		: 2008.01.31</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "PrintOderGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup"))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}
		}

        // ---DEL 2009/06/26 不具合対応[13590]　コンパイルエラーとなり、未使用の為、削除 ------------------------->>>>>
        ///// <summary>
        ///// 仕入先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">仕入先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した仕入先コード(開始)を画面に表示する
        //        this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "仕入先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}

        ///// <summary>
        ///// 仕入先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">仕入先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した仕入先コード(終了)を画面に表示する
        //        this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "仕入先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}
        // ---DEL 2009/06/26 不具合対応[13590]　コンパイルエラーとなり、未使用の為、削除 -------------------------<<<<<

		#region ■ガイド起動イベント
		/// <summary>
		/// 仕入先コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
		private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            /* --- DEL 2008/06/25 -------------------------------->>>>>
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_St.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 不具合対応[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/06/25 --------------------------------<<<<< 
		}

		/// <summary>
		/// 仕入先コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
			customerSearchForm.ShowDialog(this);
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_Ed.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 不具合対応[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/06/25 --------------------------------<<<<< 
		}

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>
        /// 入力従業員コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
		private void SalesInputCodeSt_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;
			// インスタンス生成
			EmployeeAcs _employeeAcs = new EmployeeAcs();

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.StockInputCdSt_tEdit.DataText = employee.EmployeeCode.TrimEnd();
			}
		}

		/// <summary>
        /// 入力従業員コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void SalesInputCodeEd_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;
			// インスタンス生成
			EmployeeAcs _employeeAcs = new EmployeeAcs();

			// ガイド起動
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// 項目に展開
			if (status == 0)
			{
				this.StockInputCdEd_tEdit.DataText = employee.EmployeeCode.TrimEnd();
			}

		}
           --- DEL 2008/06/25 --------------------------------<<<<< */
        
        /// <summary>
		/// 担当者コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
		private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_employeeAcs == null)
                {
                    // インスタンス生成
                    _employeeAcs = new EmployeeAcs();
                }

                // ガイド起動
                Employee employee;
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // 項目に展開
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_St.DataText = employee.EmployeeCode.TrimEnd();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 不具合対応[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}

		/// <summary>
		/// 担当者コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_employeeAcs == null)
                {
                    // インスタンス生成
                    _employeeAcs = new EmployeeAcs();
                }

                // ガイド起動
                Employee employee;
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // 項目に展開
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 不具合対応[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		#endregion

		#endregion

        // ===================================================================================== //
        // IPrintConditionInpTypeSelectedSection メンバ
        // ===================================================================================== //
		#region IPrintConditionInpTypeSelectedSection メンバ

        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkState">コントロール状態</param>
        /// <remarks>
        /// <br>Note	   : 拠点を選択処理を行ないます。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void CheckedSection(string sectionCode, CheckState checkState)
		{
			// 拠点を選択した時
			if (checkState == CheckState.Checked)
			{
				// 全社が選択された時
				if (sectionCode == "0")
				{
					// 選択選択リストをクリア
					this._selectedhSectinTable.Clear();
				}

				// リストに拠点が追加されていない時、拠点の状態を追加
				if (this._selectedhSectinTable.ContainsKey(sectionCode) == false)
				{
					this._selectedhSectinTable.Add(sectionCode, checkState);
				}
			}
			// 拠点の選択を解除した時
			else if (checkState == CheckState.Unchecked)
			{
				// 選択拠点リストから削除
				if (this._selectedhSectinTable.ContainsKey(sectionCode))
				{
					this._selectedhSectinTable.Remove(sectionCode);
				}
			}
		}

		/// <summary>
		/// 初期選択拠点設定処理
		/// </summary>
        /// <param name="sectionCodeLst"></param>
		/// <remarks>
		/// <br>Note	   : 選択されている拠点を設定します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void InitSelectSection(string[] sectionCodeLst)
		{
			if (sectionCodeLst.Length == 0)
			{
				return;
			}

			this._selectedhSectinTable.Clear();
			for (int ix = 0; ix < sectionCodeLst.Length; ix++)
			{
				// 選択拠点を追加
				this._selectedhSectinTable.Add(sectionCodeLst[ix], CheckState.Checked);
			}
		}

        /// <summary>
        /// 拠点表示取得処理
        /// </summary>
        /// <param name="isDefaultState"></param>
        /// <remarks>
        /// <br>Note	   : 選択されている拠点を設定します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public bool InitVisibleCheckSection(bool isDefaultState)
		{
			return isDefaultState;
		}

		/// <summary>
		/// 計上拠点選択表示取得プロパティ
		/// </summary>
		public bool VisibledSelectAddUpCd
		{
			get
			{
				return _visibledSelectAddUpCd;
			}
		}

		/// <summary>
		/// 拠点オプション取得プロパティ
        /// </summary>
		/// <remarks>
		/// <br>Note	   : 拠点オプション取得プロパティ</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public bool IsOptSection
		{
			get { return _isOptSection; }
			set { _isOptSection = value; }
		}

		/// <summary>
		/// 本社機能取得プロパティ
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 本社機能取得プロパティ</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public bool IsMainOfficeFunc
		{
			get { return _isMainOfficeFunc; }
			set { _isMainOfficeFunc = value; }
		}

		/// <summary>
		/// 計上拠点選択処理
		/// </summary>
        /// <param name="SelectAddUpCd"></param>
		/// <remarks>
		/// <br>Note	   : 計上拠点選択処理</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void SelectedAddUpCd(int SelectAddUpCd)
		{
			// 現在のチェックされている計上拠点情報を渡す。
			this._selectedAddUpCd = SelectAddUpCd;
		}

		/// <summary>
		/// 初期選択計上拠点設定処理
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note	   : 選択されている計上拠点を設定します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void InitSelectAddUpCd(int addUpCd)
		{
			this._selectedAddUpCd = addUpCd;
			return;
		}

		#endregion



	}
}
