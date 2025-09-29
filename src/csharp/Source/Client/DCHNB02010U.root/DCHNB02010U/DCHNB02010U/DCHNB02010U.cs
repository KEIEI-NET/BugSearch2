//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 受注貸出確認表
// プログラム概要   : 受注確認表、貸出確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馬淵　愛
// 作 成 日  2008/01/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/07/24  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/11/17  修正内容 : 粗利項目の入力値が同じ場合、入力チェックでエラー
//                                  自拠点の売上全体設定がなければ00拠点を取得するよう修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/11/18  修正内容 : 2008.11.17の修正に誤りがあったため修正
//                                  自拠点の売上設定マスタ情報取得時、論理削除チェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/30  修正内容 : 障害対応10230、10231、12395、12397
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/06  修正内容 : 障害対応13094
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13094(再修正)
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
using Broadleaf.Application.Controller.Util; // ADD 2009/03/30

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 受注貸出確認表ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 受注貸出確認表ＵＩクラス</br>
	/// <br>Programmer : 30191 馬淵　愛</br>
	/// <br>Date	   : 2008.01.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: PM.NS対応</br>
    /// <br>Programmer	: 犬飼</br>
    /// <br>Date		: 2008.07.24</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2008.11.17</br>
    /// <br>              ・粗利項目の入力値が同じ場合、入力チェックでエラー</br>
    /// <br>              ・自拠点の売上全体設定がなければ00拠点を取得するよう修正</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2008.11.18</br>
    /// <br>              ・2008.11.17の修正に誤りがあったため修正</br>
    /// <br>              ・自拠点の売上設定マスタ情報取得時、論理削除チェックを追加</br>
    /// <br>Update Note : 2009/03/30 30452 上野 俊治</br>
    /// <br>              ・障害対応10230、10231、12395、12397</br>
    /// <br>Update Note : 2009/04/06 30452 上野 俊治</br>
    /// <br>              ・障害対応13094</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>              ・障害対応13094(再修正)</br>
    /// <br></br>
	/// </remarks>  
    public class DCHNB02010UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel DCHNB02010UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private TDateEdit SalesDateEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit SalesDateStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TDateEdit InputDayEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TDateEdit InputDayStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TNedit tNedit_CustomerCode_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_CustomerCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private TEdit tEdit_EmployeeCode_Ed;
        private TEdit tEdit_EmployeeCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private TEdit GrossMarginMaxMark_tEdit;
		private TEdit GrossMarginUprMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private TNedit GrossMarginUpper2_Nedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private TEdit GrossMarginBestMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private TNedit GrossMarginBest2_Nedit;
		private TEdit GrossMarginLowMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private TNedit GrossMarginLow2_Nedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor tComboEditor_NewPageType;
        private TNedit GrsProfitCheckUpper_tNedit;
        private TNedit GrsProfitCheckBest_tNedit;
        private TNedit GrsProfitCheckLower_tNedit;
        private TComboEditor tComboEditor_PublicationType;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_PrintDailyFooter;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_CostOut;
		private System.ComponentModel.IContainer components;
		#endregion
		
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region constructer
		/// <summary>
		/// 受注貸出確認表ＵＩクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注貸出確認表ＵＩクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 30191 馬淵　愛</br>
		/// <br>Date	   : 2008.01.23</br>
		/// <br></br>
		/// </remarks>  
		public DCHNB02010UA()
		{
			InitializeComponent();

			this._enterpriseCode   = LoginInfoAcquisition.EnterpriseCode;

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker    = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // インスタンス生成
            this._employeeAcs = new EmployeeAcs();
            this._lGoodsGanreAcs = new LGoodsGanreAcs();
            this._mGoodsGanreAcs = new MGoodsGanreAcs();

			//日付チェック部品のインスタンスを生成
			this._dateGetAcs = DateGetAcs.GetInstance();
        }
		#endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		#region Dispose        
		/// <summary>
		/// Dispose
		/// </summary>
		protected override void Dispose(bool disposing)
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
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.ultraOptionSet_PrintDailyFooter = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraOptionSet_CostOut = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_NewPageType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.InputDayEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_PublicationType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.GrsProfitCheckUpper_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckBest_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckLower_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginMaxMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GrossMarginUprMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginUpper2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginBestMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginBest2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrossMarginLowMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginLow2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.DCHNB02010UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PublicationType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMaxMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUprMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUpper2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBestMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBest2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLowMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLow2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.DCHNB02010UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_PrintDailyFooter);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_CostOut);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_NewPageType);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(695, 127);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // ultraOptionSet_PrintDailyFooter
            // 
            this.ultraOptionSet_PrintDailyFooter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;
            valueListItem1.DataValue = "0";
            valueListItem1.DisplayText = "しない";
            valueListItem2.DataValue = "1";
            valueListItem2.DisplayText = "する";
            this.ultraOptionSet_PrintDailyFooter.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ultraOptionSet_PrintDailyFooter.Location = new System.Drawing.Point(465, 91);
            this.ultraOptionSet_PrintDailyFooter.Name = "ultraOptionSet_PrintDailyFooter";
            this.ultraOptionSet_PrintDailyFooter.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_PrintDailyFooter.TabIndex = 7;
            this.ultraOptionSet_PrintDailyFooter.Text = "しない";
            // 
            // ultraOptionSet_CostOut
            // 
            this.ultraOptionSet_CostOut.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_CostOut.CheckedIndex = 0;
            valueListItem3.DataValue = "0";
            valueListItem3.DisplayText = "なし";
            valueListItem4.DataValue = "1";
            valueListItem4.DisplayText = "あり";
            this.ultraOptionSet_CostOut.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.ultraOptionSet_CostOut.Location = new System.Drawing.Point(465, 67);
            this.ultraOptionSet_CostOut.Name = "ultraOptionSet_CostOut";
            this.ultraOptionSet_CostOut.Size = new System.Drawing.Size(112, 20);
            this.ultraOptionSet_CostOut.TabIndex = 6;
            this.ultraOptionSet_CostOut.Text = "なし";
            // 
            // ultraLabel12
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance8;
            this.ultraLabel12.Location = new System.Drawing.Point(337, 88);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel12.TabIndex = 37;
            this.ultraLabel12.Text = "日計印字";
            // 
            // ultraLabel4
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance67;
            this.ultraLabel4.Location = new System.Drawing.Point(337, 64);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 36;
            this.ultraLabel4.Text = "原価・粗利出力";
            // 
            // ultraLabel21
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance23;
            this.ultraLabel21.Location = new System.Drawing.Point(15, 62);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel21.TabIndex = 35;
            this.ultraLabel21.Text = "改頁";
            // 
            // tComboEditor_NewPageType
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ActiveAppearance = appearance68;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPageType.Appearance = appearance21;
            this.tComboEditor_NewPageType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPageType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ItemAppearance = appearance69;
            valueListItem5.DataValue = ((short)(0));
            valueListItem5.DisplayText = "拠点";
            valueListItem6.DataValue = ((short)(1));
            valueListItem6.DisplayText = "小計";
            valueListItem7.DataValue = ((short)(2));
            valueListItem7.DisplayText = "しない";
            this.tComboEditor_NewPageType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.tComboEditor_NewPageType.LimitToList = true;
            this.tComboEditor_NewPageType.Location = new System.Drawing.Point(150, 63);
            this.tComboEditor_NewPageType.Name = "tComboEditor_NewPageType";
            this.tComboEditor_NewPageType.Size = new System.Drawing.Size(112, 24);
            this.tComboEditor_NewPageType.TabIndex = 5;
            // 
            // InputDayEdRF_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEdRF_tDateEdit.ActiveEditAppearance = appearance1;
            this.InputDayEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEdRF_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.EditAppearance = appearance2;
            this.InputDayEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.LabelAppearance = appearance3;
            this.InputDayEdRF_tDateEdit.Location = new System.Drawing.Point(368, 33);
            this.InputDayEdRF_tDateEdit.Name = "InputDayEdRF_tDateEdit";
            this.InputDayEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEdRF_tDateEdit.TabIndex = 4;
            this.InputDayEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel6
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance4;
            this.ultraLabel6.Location = new System.Drawing.Point(337, 33);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "～";
            // 
            // InputDayStRF_tDateEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayStRF_tDateEdit.ActiveEditAppearance = appearance5;
            this.InputDayStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayStRF_tDateEdit.CalendarDisp = true;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.EditAppearance = appearance6;
            this.InputDayStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.LabelAppearance = appearance7;
            this.InputDayStRF_tDateEdit.Location = new System.Drawing.Point(150, 33);
            this.InputDayStRF_tDateEdit.Name = "InputDayStRF_tDateEdit";
            this.InputDayStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayStRF_tDateEdit.TabIndex = 3;
            this.InputDayStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel7
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance66;
            this.ultraLabel7.Location = new System.Drawing.Point(15, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(128, 23);
            this.ultraLabel7.TabIndex = 30;
            this.ultraLabel7.Text = "入力日";
            // 
            // SalesDateEdRF_tDateEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateEdRF_tDateEdit.ActiveEditAppearance = appearance9;
            this.SalesDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateEdRF_tDateEdit.CalendarDisp = true;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.EditAppearance = appearance10;
            this.SalesDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.LabelAppearance = appearance11;
            this.SalesDateEdRF_tDateEdit.Location = new System.Drawing.Point(368, 3);
            this.SalesDateEdRF_tDateEdit.Name = "SalesDateEdRF_tDateEdit";
            this.SalesDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateEdRF_tDateEdit.TabIndex = 2;
            this.SalesDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance12;
            this.ultraLabel10.Location = new System.Drawing.Point(337, 3);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // SalesDateStRF_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateStRF_tDateEdit.ActiveEditAppearance = appearance13;
            this.SalesDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateStRF_tDateEdit.CalendarDisp = true;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.EditAppearance = appearance14;
            this.SalesDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.LabelAppearance = appearance15;
            this.SalesDateStRF_tDateEdit.Location = new System.Drawing.Point(150, 3);
            this.SalesDateStRF_tDateEdit.Name = "SalesDateStRF_tDateEdit";
            this.SalesDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateStRF_tDateEdit.TabIndex = 1;
            this.SalesDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel8
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance16;
            this.ultraLabel8.Location = new System.Drawing.Point(15, 3);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(128, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "日付";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 210);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(695, 31);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance17;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance22;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance18;
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(150, 4);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 7;
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 3);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 3;
            this.ultraLabel5.Text = "出力順";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_PublicationType);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel34);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckUpper_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckBest_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckLower_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel20);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel19);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel18);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginMaxMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginUprMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel17);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginUpper2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginBestMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginBest2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginLowMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginLow2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel26);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 278);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(695, 215);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tComboEditor_PublicationType
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PublicationType.ActiveAppearance = appearance84;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PublicationType.Appearance = appearance20;
            this.tComboEditor_PublicationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PublicationType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PublicationType.ItemAppearance = appearance85;
            this.tComboEditor_PublicationType.LimitToList = true;
            this.tComboEditor_PublicationType.Location = new System.Drawing.Point(150, 61);
            this.tComboEditor_PublicationType.Name = "tComboEditor_PublicationType";
            this.tComboEditor_PublicationType.Size = new System.Drawing.Size(131, 24);
            this.tComboEditor_PublicationType.TabIndex = 30;
            // 
            // ultraLabel34
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance70;
            this.ultraLabel34.Location = new System.Drawing.Point(15, 61);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(127, 23);
            this.ultraLabel34.TabIndex = 79;
            this.ultraLabel34.Text = "発行タイプ";
            // 
            // GrsProfitCheckUpper_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.GrsProfitCheckUpper_tNedit.ActiveAppearance = appearance40;
            appearance41.TextHAlignAsString = "Right";
            this.GrsProfitCheckUpper_tNedit.Appearance = appearance41;
            this.GrsProfitCheckUpper_tNedit.AutoSelect = true;
            this.GrsProfitCheckUpper_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckUpper_tNedit.DataText = "";
            this.GrsProfitCheckUpper_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckUpper_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckUpper_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckUpper_tNedit.Location = new System.Drawing.Point(150, 177);
            this.GrsProfitCheckUpper_tNedit.MaxLength = 4;
            this.GrsProfitCheckUpper_tNedit.Name = "GrsProfitCheckUpper_tNedit";
            this.GrsProfitCheckUpper_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckUpper_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckUpper_tNedit.TabIndex = 70;
            this.GrsProfitCheckUpper_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckUpper_tNedit_ValueChanged);
            this.GrsProfitCheckUpper_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckUpper_tNedit_Leave);
            // 
            // GrsProfitCheckBest_tNedit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.TextHAlignAsString = "Right";
            this.GrsProfitCheckBest_tNedit.ActiveAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            this.GrsProfitCheckBest_tNedit.Appearance = appearance25;
            this.GrsProfitCheckBest_tNedit.AutoSelect = true;
            this.GrsProfitCheckBest_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckBest_tNedit.DataText = "";
            this.GrsProfitCheckBest_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckBest_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckBest_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckBest_tNedit.Location = new System.Drawing.Point(150, 148);
            this.GrsProfitCheckBest_tNedit.MaxLength = 4;
            this.GrsProfitCheckBest_tNedit.Name = "GrsProfitCheckBest_tNedit";
            this.GrsProfitCheckBest_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckBest_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckBest_tNedit.TabIndex = 60;
            this.GrsProfitCheckBest_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckBest_tNedit_ValueChanged);
            this.GrsProfitCheckBest_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckBest_tNedit_Leave);
            // 
            // GrsProfitCheckLower_tNedit
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.TextHAlignAsString = "Right";
            this.GrsProfitCheckLower_tNedit.ActiveAppearance = appearance47;
            appearance48.TextHAlignAsString = "Right";
            this.GrsProfitCheckLower_tNedit.Appearance = appearance48;
            this.GrsProfitCheckLower_tNedit.AutoSelect = true;
            this.GrsProfitCheckLower_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckLower_tNedit.DataText = "";
            this.GrsProfitCheckLower_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckLower_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckLower_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckLower_tNedit.Location = new System.Drawing.Point(150, 119);
            this.GrsProfitCheckLower_tNedit.MaxLength = 4;
            this.GrsProfitCheckLower_tNedit.Name = "GrsProfitCheckLower_tNedit";
            this.GrsProfitCheckLower_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckLower_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckLower_tNedit.TabIndex = 50;
            this.GrsProfitCheckLower_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckLower_tNedit_ValueChanged);
            this.GrsProfitCheckLower_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckLower_tNedit_Leave);
            // 
            // ultraLabel20
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance26;
            this.ultraLabel20.Location = new System.Drawing.Point(373, 148);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel20.TabIndex = 78;
            this.ultraLabel20.Text = "％";
            // 
            // ultraLabel19
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance27;
            this.ultraLabel19.Location = new System.Drawing.Point(217, 148);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel19.TabIndex = 77;
            this.ultraLabel19.Text = "％";
            // 
            // ultraLabel18
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance28;
            this.ultraLabel18.Location = new System.Drawing.Point(217, 119);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel18.TabIndex = 76;
            this.ultraLabel18.Text = "％";
            // 
            // GrossMarginMaxMark_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginMaxMark_tEdit.ActiveAppearance = appearance29;
            this.GrossMarginMaxMark_tEdit.AutoSelect = true;
            this.GrossMarginMaxMark_tEdit.DataText = "";
            this.GrossMarginMaxMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginMaxMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginMaxMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginMaxMark_tEdit.Location = new System.Drawing.Point(413, 177);
            this.GrossMarginMaxMark_tEdit.MaxLength = 2;
            this.GrossMarginMaxMark_tEdit.Name = "GrossMarginMaxMark_tEdit";
            this.GrossMarginMaxMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginMaxMark_tEdit.TabIndex = 71;
            // 
            // GrossMarginUprMark_tEdit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginUprMark_tEdit.ActiveAppearance = appearance30;
            this.GrossMarginUprMark_tEdit.AutoSelect = true;
            this.GrossMarginUprMark_tEdit.DataText = "";
            this.GrossMarginUprMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginUprMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginUprMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginUprMark_tEdit.Location = new System.Drawing.Point(413, 148);
            this.GrossMarginUprMark_tEdit.MaxLength = 2;
            this.GrossMarginUprMark_tEdit.Name = "GrossMarginUprMark_tEdit";
            this.GrossMarginUprMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginUprMark_tEdit.TabIndex = 62;
            // 
            // ultraLabel17
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance31;
            this.ultraLabel17.Location = new System.Drawing.Point(217, 177);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel17.TabIndex = 74;
            this.ultraLabel17.Text = "％以上";
            // 
            // GrossMarginUpper2_Nedit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.TextHAlignAsString = "Left";
            this.GrossMarginUpper2_Nedit.ActiveAppearance = appearance32;
            appearance33.TextHAlignAsString = "Right";
            this.GrossMarginUpper2_Nedit.Appearance = appearance33;
            this.GrossMarginUpper2_Nedit.AutoSelect = true;
            this.GrossMarginUpper2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginUpper2_Nedit.DataText = "";
            this.GrossMarginUpper2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginUpper2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginUpper2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginUpper2_Nedit.Location = new System.Drawing.Point(306, 148);
            this.GrossMarginUpper2_Nedit.MaxLength = 4;
            this.GrossMarginUpper2_Nedit.Name = "GrossMarginUpper2_Nedit";
            this.GrossMarginUpper2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginUpper2_Nedit.ReadOnly = true;
            this.GrossMarginUpper2_Nedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrossMarginUpper2_Nedit.Size = new System.Drawing.Size(44, 24);
            this.GrossMarginUpper2_Nedit.TabIndex = 61;
            // 
            // ultraLabel16
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance34;
            this.ultraLabel16.Location = new System.Drawing.Point(260, 148);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel16.TabIndex = 70;
            this.ultraLabel16.Text = "～";
            // 
            // GrossMarginBestMark_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginBestMark_tEdit.ActiveAppearance = appearance35;
            this.GrossMarginBestMark_tEdit.AutoSelect = true;
            this.GrossMarginBestMark_tEdit.DataText = "";
            this.GrossMarginBestMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginBestMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginBestMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginBestMark_tEdit.Location = new System.Drawing.Point(413, 119);
            this.GrossMarginBestMark_tEdit.MaxLength = 2;
            this.GrossMarginBestMark_tEdit.Name = "GrossMarginBestMark_tEdit";
            this.GrossMarginBestMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginBestMark_tEdit.TabIndex = 52;
            // 
            // ultraLabel15
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance36;
            this.ultraLabel15.Location = new System.Drawing.Point(373, 119);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel15.TabIndex = 67;
            this.ultraLabel15.Text = "％";
            // 
            // ultraLabel14
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance37;
            this.ultraLabel14.Location = new System.Drawing.Point(260, 119);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel14.TabIndex = 65;
            this.ultraLabel14.Text = "～";
            // 
            // GrossMarginBest2_Nedit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.TextHAlignAsString = "Left";
            this.GrossMarginBest2_Nedit.ActiveAppearance = appearance38;
            appearance39.TextHAlignAsString = "Right";
            this.GrossMarginBest2_Nedit.Appearance = appearance39;
            this.GrossMarginBest2_Nedit.AutoSelect = true;
            this.GrossMarginBest2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginBest2_Nedit.DataText = "";
            this.GrossMarginBest2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginBest2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginBest2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginBest2_Nedit.Location = new System.Drawing.Point(306, 119);
            this.GrossMarginBest2_Nedit.MaxLength = 4;
            this.GrossMarginBest2_Nedit.Name = "GrossMarginBest2_Nedit";
            this.GrossMarginBest2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginBest2_Nedit.ReadOnly = true;
            this.GrossMarginBest2_Nedit.Size = new System.Drawing.Size(44, 24);
            this.GrossMarginBest2_Nedit.TabIndex = 51;
            // 
            // GrossMarginLowMark_tEdit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginLowMark_tEdit.ActiveAppearance = appearance72;
            this.GrossMarginLowMark_tEdit.AutoSelect = true;
            this.GrossMarginLowMark_tEdit.DataText = "";
            this.GrossMarginLowMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginLowMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginLowMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginLowMark_tEdit.Location = new System.Drawing.Point(413, 90);
            this.GrossMarginLowMark_tEdit.MaxLength = 2;
            this.GrossMarginLowMark_tEdit.Name = "GrossMarginLowMark_tEdit";
            this.GrossMarginLowMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginLowMark_tEdit.TabIndex = 41;
            this.GrossMarginLowMark_tEdit.UseWaitCursor = true;
            // 
            // ultraLabel9
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance73;
            this.ultraLabel9.Location = new System.Drawing.Point(217, 90);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel9.TabIndex = 62;
            this.ultraLabel9.Text = "％未満";
            // 
            // GrossMarginLow2_Nedit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.TextHAlignAsString = "Left";
            this.GrossMarginLow2_Nedit.ActiveAppearance = appearance42;
            appearance43.TextHAlignAsString = "Right";
            this.GrossMarginLow2_Nedit.Appearance = appearance43;
            this.GrossMarginLow2_Nedit.AutoSelect = true;
            this.GrossMarginLow2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginLow2_Nedit.DataText = "";
            this.GrossMarginLow2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginLow2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginLow2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginLow2_Nedit.Location = new System.Drawing.Point(150, 90);
            this.GrossMarginLow2_Nedit.MaxLength = 6;
            this.GrossMarginLow2_Nedit.Name = "GrossMarginLow2_Nedit";
            this.GrossMarginLow2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginLow2_Nedit.ReadOnly = true;
            this.GrossMarginLow2_Nedit.Size = new System.Drawing.Size(43, 24);
            this.GrossMarginLow2_Nedit.TabIndex = 40;
            this.GrossMarginLow2_Nedit.TabStop = false;
            // 
            // ultraLabel2
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance44;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 90);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(123, 23);
            this.ultraLabel2.TabIndex = 60;
            this.ultraLabel2.Text = "粗利チェック";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance45.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance45;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(398, 3);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 26);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 13;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance46.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance46;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(240, 3);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 26);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 11;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance74.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance74;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(398, 32);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 23;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "得意先検索");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance75.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance75;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(240, 32);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 21;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "得意先検索");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_Ed.ActiveAppearance = appearance49;
            this.tEdit_EmployeeCode_Ed.AutoSelect = true;
            this.tEdit_EmployeeCode_Ed.DataText = "";
            this.tEdit_EmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_EmployeeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_Ed.Location = new System.Drawing.Point(308, 3);
            this.tEdit_EmployeeCode_Ed.MaxLength = 4;
            this.tEdit_EmployeeCode_Ed.Name = "tEdit_EmployeeCode_Ed";
            this.tEdit_EmployeeCode_Ed.Size = new System.Drawing.Size(59, 24);
            this.tEdit_EmployeeCode_Ed.TabIndex = 12;
            // 
            // tEdit_EmployeeCode_St
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_St.ActiveAppearance = appearance50;
            this.tEdit_EmployeeCode_St.AutoSelect = true;
            this.tEdit_EmployeeCode_St.DataText = "";
            this.tEdit_EmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_EmployeeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_St.Location = new System.Drawing.Point(150, 3);
            this.tEdit_EmployeeCode_St.MaxLength = 4;
            this.tEdit_EmployeeCode_St.Name = "tEdit_EmployeeCode_St";
            this.tEdit_EmployeeCode_St.Size = new System.Drawing.Size(59, 24);
            this.tEdit_EmployeeCode_St.TabIndex = 10;
            // 
            // ultraLabel25
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance51;
            this.ultraLabel25.Location = new System.Drawing.Point(274, 3);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 24);
            this.ultraLabel25.TabIndex = 56;
            this.ultraLabel25.Text = "～";
            // 
            // ultraLabel26
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance52;
            this.ultraLabel26.Location = new System.Drawing.Point(15, 3);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(122, 24);
            this.ultraLabel26.TabIndex = 47;
            this.ultraLabel26.Text = "担当者";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance53;
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance54;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(308, 32);
            this.tNedit_CustomerCode_Ed.MaxLength = 9;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 22;
            // 
            // ultraLabel11
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance55;
            this.ultraLabel11.Location = new System.Drawing.Point(277, 32);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 19;
            this.ultraLabel11.Text = "～";
            // 
            // tNedit_CustomerCode_St
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance56;
            appearance57.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance57;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(150, 32);
            this.tNedit_CustomerCode_St.MaxLength = 9;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode_St.TabIndex = 20;
            // 
            // ultraLabel3
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance58;
            this.ultraLabel3.Location = new System.Drawing.Point(15, 32);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 17;
            this.ultraLabel3.Text = "得意先";
            // 
            // DCHNB02010UA_Fill_Panel
            // 
            this.DCHNB02010UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.DCHNB02010UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCHNB02010UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.DCHNB02010UA_Fill_Panel.Name = "DCHNB02010UA_Fill_Panel";
            this.DCHNB02010UA_Fill_Panel.Size = new System.Drawing.Size(733, 617);
            this.DCHNB02010UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(733, 617);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance59.FontData.Name = "ＭＳ ゴシック";
            appearance59.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance59;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance60;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 129;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance61;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 33;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　ソート順";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance62;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 217;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance63.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance63.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance63;
            appearance64.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance64;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(3, 3);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(731, 611);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance65.FontData.SizeInPoints = 20F;
            appearance65.TextHAlignAsString = "Center";
            appearance65.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance65;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(733, 617);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
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
            // DCHNB02010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(733, 617);
            this.Controls.Add(this.DCHNB02010UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCHNB02010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DCHNB02010UA_Load);
            this.Activated += new System.EventHandler(this.DCHNB02010UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PublicationType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMaxMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUprMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUpper2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBestMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBest2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLowMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLow2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.DCHNB02010UA_Fill_Panel.ResumeLayout(false);
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
		private string _enterpriseCode              = "";

		//private bool _baseOption                     = false;
        
		private bool _printButtonEnabled             = true;
		private bool _extraButtonEnabled             = false;
		private bool _pdfButtonEnabled               = true;
		private bool _printButtonVisibled            = true;
		private bool _extraButtonVisibled            = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// 計上拠点選択表示取得

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = false;
		private bool _chartButtonEnabled = false;

        private string _SalesConfDataTable;

		private Employee _loginWorker                = null;
		// 自拠点コード
		private string _ownSectionCode               = "";
		// 請求設定拠点コード
		//private string _balanceSectionCode           = "";

        private ExtrInfo_DCHNB02013E _chartSaleconfListCndtn = null;

        // 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;

        // ガイド系アクセスクラス
        EmployeeAcs    _employeeAcs;
        LGoodsGanreAcs _lGoodsGanreAcs;
        MGoodsGanreAcs _mGoodsGanreAcs;

		private SaleConfAcs _saleConfListAcs = null;  // 受注貸出確認表アクセスクラス

		//売上全体設定マスタ抽出条件
		private SalesTtlSt _salesTtlSt;
		//売上全体設定マスタアクセスクラス
		private SalesTtlStAcs _salesTtlStAcs;

        //日付取得部品
		DateGetAcs _dateGetAcs;
		
		private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// 拠点オプション有無
        private bool _isMainOfficeFunc;	// 本社機能有無

		// エクスプローラバー拡大基準高さ 
		private Form _topForm = null;
        // 2008.07.24 30413 犬飼 未使用プロパティの削除 >>>>>>START
        //private bool _explorerBarExpanding = false;
        // 2008.07.24 30413 犬飼 未使用プロパティの削除 <<<<<<END
        

		// 商品チャート抽出クラスメンバ
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_DCHNB02013E _saleConfListCndtnWork = new ExtrInfo_DCHNB02013E();		//条件クラス(前回条件保持用)
        private ExtrInfo_DCHNB02013E _chartSaleConfListCndtn = new ExtrInfo_DCHNB02013E();		//条件クラス(チャート引渡し用)
        private DataSet _printBuffDataSet = null;

		//起動帳票モードを入れる変数
		private int _selPrintMode;

		// 帳票名称
		private string _printName = "";
		// 帳票キー
		private string _printKey = "";

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>原価・粗利出力ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_CostOutRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>日計印字ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _uos_PrindDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 原価・粗利出力ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>原価・粗利出力ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_CostOutRadioKeyPressHelper
        {
            get { return _uos_CostOutRadioKeyPressHelper; }
        }

        /// <summary>
        /// 日計印字ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>日計印字ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper Uos_PrindDailyFooterRadioKeyPressHelper
        {
            get { return _uos_PrindDailyFooterRadioKeyPressHelper; }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

		#endregion
        
		// ===================================================================================== //
		// プライベート定数
		// ===================================================================================== //
		#region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

		// クラスID
		private const string CT_CLASSID								 = "DCHNB02010UA";
		// プログラムID
		private const string THIS_ASSEMBLYID                         = "DCHNB02010U";	
		// キー情報
		private const string PRINT_KEY01							 = "e1dc02c5-b6c1-4764-b121-d152c2737fe3";
		private const string PRINT_KEY02							 = "c0b28f80-d5ec-4131-ae0d-cf12cfe7cc44";

		private const string PRINT_NAME_01							 = "受注確認表";
        // 2008.07.24 30413 犬飼 出荷→貸出に変更 >>>>>>START
        //private const string PRINT_NAME_02							 = "出荷確認表";
        private const string PRINT_NAME_02 = "貸出確認表";
        // 2008.07.24 30413 犬飼 出荷→貸出に変更 <<<<<<END
		
		//日付名称
		private const string CTDATENAMEPATERN01 = "受注日";
        // 2008.07.24 30413 犬飼 出荷→貸出に変更 >>>>>>START
        //private const string CTDATENAMEPATERN02 = "出荷日付";
        private const string CTDATENAMEPATERN02 = "貸出日";
        // 2008.07.24 30413 犬飼 出荷→貸出に変更 <<<<<<END

        // 2008.07.24 30413 犬飼 発行タイプの追加 >>>>>>START
        private const string PUBLICATION_TYPE0 = "受注";
        private const string PUBLICATION_TYPE1 = "受注計上済";
        private const string PUBLICATION_TYPE2 = "貸出";
        private const string PUBLICATION_TYPE3 = "貸出計上済";
        // 2008.07.24 30413 犬飼 発行タイプの追加 <<<<<<END
        
            
		//出力順
        // 2008.07.24 30413 犬飼 ソート順の変更 >>>>>>START
        //private const string CHANGEPAGEDIV1_01 = "受注日＋伝票番号＋行番号";
        //private const string CHANGEPAGEDIV1_02 = "出荷日＋伝票番号＋行番号";
        private const string CHANGEPAGEDIV1_01 = "受注日＋伝票番号";
        private const string CHANGEPAGEDIV1_02 = "貸出日＋伝票番号";
        // 2008.07.24 30413 犬飼 ソート順の変更 <<<<<<END
        private const string CHANGEPAGEDIV2 = "伝票番号";
		private const string CHANGEPAGEDIV3 = "得意先＋伝票番号";
		private const string CHANGEPAGEDIV4 = "担当者＋伝票番号";

		
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
                return _chartSaleconfListCndtn;
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
		/// <br>Note       : 画面表示を行います。</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this._selPrintMode = 0;

			//起動モードを取得します（20：受注表、40:貸出表）
			this._selPrintMode = Int32.Parse(parameter.ToString());

			switch (this._selPrintMode)
			{
				case 20:
					{
						this._printName = PRINT_NAME_01;
						this._printKey = PRINT_KEY01;
						this.ultraLabel8.Text = CTDATENAMEPATERN01;

						break;
					}
				case 40:
					{
						this._printName = PRINT_NAME_02;
						this._printKey = PRINT_KEY02;
						this.ultraLabel8.Text = CTDATENAMEPATERN02;

						break;
					}
			}

            this.Show();
			
        }
		
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。</br>
		/// </remarks>
		public int Print(ref object parameter)
		{
		            
			SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // 印刷情報パラメータ
		
			// 企業コード
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // 起動ＰＧＩＤ
			printInfo.key			 = this._printKey;              // PDF履歴管理用KEY情報

			//起動モード別に設定コードをセット
			switch (this._selPrintMode)
			{
				//受注確認表
				case 20:
					{
						printInfo.PrintPaperSetCd = 20;
						break;
					}
				//貸出確認表
				case 40:
					{
						printInfo.PrintPaperSetCd = 40;
						break;
					}

			}

			// 画面→抽出条件クラス
            ExtrInfo_DCHNB02013E saleConfListCndtnWork = new ExtrInfo_DCHNB02013E();
			int status = this.SetExtraInfoFromScreen(ref saleConfListCndtnWork);
			if (status != 0)
			{
				return -1;
			}
			// 抽出条件の設定
            printInfo.jyoken = saleConfListCndtnWork;

			// //印刷帳票設定
			//if(saleConfListCndtnWork.IsDetails == false)
			//{
			//    printInfo.PrintPaperSetCd = 1;
			//}
			//else
			//{
			//    printInfo.PrintPaperSetCd = 0;
			//}

#if false
            // ----------
            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "抽出中";
            pd.Message = "現在、データ抽出中です。";

            status = 0;

            try
            {
                pd.Show();
                status = this.SearchData(saleConfListCndtnWork);
            }
            finally
            {
                pd.Close();
                printInfo.status = status;
            }
            // ----------

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._printBuffDataSet = null;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                return status;
            }

            this._saleConfListCndtnWork = saleConfListCndtnWork;

			printInfo.rdData = this._printBuffDataSet;
#endif
			this._saleConfListCndtnWork = saleConfListCndtnWork;

			printDialog.PrintInfo = printInfo;
		        
			// 帳票選択ガイド（出力設定ダイアログ）
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
		/// <br>印刷前のチェック処理を行います。</br>
		/// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;
		            
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
		///  抽出処理を行います。
		/// </remarks>
		public int Extract(ref object parameter)
		{
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //return status;

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            ExtrInfo_DCHNB02013E extraInfo = new ExtrInfo_DCHNB02013E();     // 抽出条件クラス

            this.SetExtraInfoFromScreen(ref extraInfo);

            // データ抽出
            status = this.SearchData(extraInfo);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._printBuffDataSet = null;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                this._printBuffDataSet = null;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "データの抽出でエラーが発生しました", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
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
				return this._printKey;
			}
		}

		/// <summary>帳票名プロパティ</summary>
		/// <remarks>帳票名を取得します。</remarks>
		public string PrintName
		{
			get
			{
				return this._printName;
			}
		}
		#endregion

		// ===================================================================================== //
		// IPrintConditionInpTypeChart メンバ
		// ===================================================================================== //
        #region IPrintConditionInpTypeChart メンバ
        /// <summary>
        /// チャートボタンEnabled制御
        /// </summary>
        public bool CanChart
        {
            get { return this._chartButtonEnabled; }
        }

        /// <summary>
        /// チャートボタン表示制御
        /// </summary>
        public bool VisibledChartButton
        {
            get { return this._chartButtonVisibled; }
        }

		/// <summary>
		/// Dispose
		/// </summary>
		public bool CheckBefore()
        {
            // TODO チャートデータの抽出チェックを行います。
            return true;
        }

        /// <summary>
        /// チャート抽出クラスメンバ取得
        /// </summary>
        /// <param name="chartExtractMemberList"></param>
        /// <returns></returns>
        public int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList)
        {
            try
            {
                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();
                }

                chartExtractMemberList = this._iChartExtractList;
            }
            finally
            {
            }

            return 0;
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
          System.Windows.Forms.Application.Run(new DCHNB02010UA());
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
        /// <br>Note       : 初期画面設定を行います。</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            // 日付範囲
            // 受注日・貸出日
            this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			//this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
			//this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 犬飼 受注・貸出日にシステム日付を設定 >>>>>>START
            this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
            this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 犬飼 受注・貸出日にシステム日付を設定 <<<<<<END

			// 入力日付
			this.InputDayStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.InputDayEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            // 2008.07.24 30413 犬飼 入力日は未設定に変更 >>>>>>START
            //this.InputDayStRF_tDateEdit.SetLongDate(nowLongDate);
            //this.InputDayEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 犬飼 入力日は未設定に変更 <<<<<<END

            // 2008.07.24 30413 犬飼 発行タイプの初期値設定 >>>>>>START
            // 発行タイプ
            this.tComboEditor_PublicationType.SelectedIndex = 0;
            // 2008.07.24 30413 犬飼 発行タイプの初期値設定 <<<<<<END

            // 2008.07.24 30413 犬飼 改頁の初期値設定 >>>>>>START
            // 改頁
            this.tComboEditor_NewPageType.Value = 0;
            // 2008.07.24 30413 犬飼 改頁の初期値設定 <<<<<<END
            

			this.PrintOder_tComboEditor.Value = 0;

            
            // ガイドボタンイメージ設定
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
                     
            SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
        }


        /// <summary>
        /// 拠点選択コンポボックス設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報をコンポボックスに設定します。</br>
        /// </remarks>
        private void SettingSectionCombList()
        {
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
		/// <param name="startDate">チェック対象コントロール</param>
		/// <param name="endDate">チェック対象コントロール</param>
		/// <returns>true:チェックOK,false:チェックNG</returns>
		/// <remarks>
		/// <br>Note: 共通部品による日付範囲のチェックを行います。</br>
		/// </remarks>
		private bool CheckPeriod(DateTime startDate, DateTime endDate, int s)
		{
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 1, DateGetAcs.YmdType.YearMonthDay, startDate, endDate);

			string str_cP = _checkP.ToString();

			bool r = false;

			switch (s)
			{
				case 1:
					if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
					{
						r = false;
					}
					else
					{
						r = true;
					}
					break;

				case 240:
					//受注・貸出日付は範囲無し
					if (str_cP == "ErrorOfReverse" )
					{
						r = false;
					}
					else
					{
						r = true;
					}
					break;
			}

			return r;
		}

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// </remarks>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            // 2008.07.24 30413 犬飼 受注・貸出日と入力日のチェックを変更 >>>>>>START
            DateGetAcs.CheckDateRangeResult cdrResult;

            // 受注・貸出日（開始・終了）のチェック
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //if ((this.SalesDateStRF_tDateEdit.LongDate != 0) ||
            //    (this.SalesDateEdRF_tDateEdit.LongDate != 0))
            //{
            // --- DEL 2009/04/06 --------------------------------<<<<<
            if (CallCheckDateRange_SalesDays(out cdrResult, ref SalesDateStRF_tDateEdit, ref SalesDateEdRF_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            //message = "開始日を入力して下さい"; // DEL 2009/04/06
                            //errControl = this.SalesDateStRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "開始日の入力が不正です";
                            errControl = this.SalesDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            //message = "終了日を入力して下さい"; // DEL 2009/04/06
                            //errControl = this.SalesDateEdRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "終了日の入力が不正です";
                            errControl = this.SalesDateEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = "日付の範囲指定に誤りがあります";
                            errControl = this.SalesDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //message = "日付は３ヶ月の範囲で入力して下さい"; // DEL 2009/04/06
                            //errControl = this.SalesDateStRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;

                }
                //return result; // DEL 2009/04/07
            }
            // --- ADD 2009/04/07 -------------------------------->>>>>
            else
            {
                result = true;
            }

            if (!result)
            {
                // 受注・貸出日チェックエラー
                return result;
            }
            else
            {
                // 受注・貸出日チェックOK
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //}
            //// 2008.09.18 30413 犬飼 売上日に必須チェックを追加 >>>>>>START
            //else
            //{
            //    // 開始日と終了日の両方未入力
            //    message = "開始日と終了日を入力して下さい";
            //    errControl = this.SalesDateStRF_tDateEdit;
            //    return result;
            //}
            // --- DEL 2009/04/06 --------------------------------<<<<<
            // 2008.09.18 30413 犬飼 売上日に必須チェックを追加 <<<<<<END

            // 2009.01.06 30413 犬飼 入力日チェックを修正 >>>>>>START
            // 入力日（開始・終了）
            //if ((this.InputDayStRF_tDateEdit.LongDate != 0) ||
            //    (this.InputDayEdRF_tDateEdit.LongDate != 0))
            //{

            if (CallCheckDateRange_InputDays(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            //message = "開始日を入力して下さい";
                            //errControl = this.InputDayStRF_tDateEdit;
                            result = true;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "開始日の入力が不正です";
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            //message = "終了日を入力して下さい";
                            //errControl = this.InputDayEdRF_tDateEdit;
                            result = true;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "終了日の入力が不正です";
                            errControl = this.InputDayEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = "日付の範囲指定に誤りがあります";
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //message = "日付は３ヶ月の範囲で入力して下さい";
                            //errControl = this.InputDayStRF_tDateEdit;
                            result = true;
                        }
                        break;
                }
                return result;
            }

        //}
            else
            {
                result = true;
            }

            if (!result)
            {
                // 入力日チェックエラー
                return result;
            }
            else
            {
                // 入力日チェックOK
                result = false;
            }
            // 2009.01.06 30413 犬飼 入力日チェックを修正 <<<<<<END            
            // 2008.07.24 30413 犬飼 受注・貸出日と入力日のチェックを変更 <<<<<<END

            // 2008.07.24 30413 犬飼 既存の入力日と受注・貸出日のチェックを削除 >>>>>>START
            //// 入力日付(終了)
            //if (!CheckDate(this.InputDayEdRF_tDateEdit))
            //{
            //    message = "入力日付の指定に誤りがあります";
            //    errControl = this.InputDayEdRF_tDateEdit;
            //    return result;
            //}

            //DateTime _dtInputDaySt = DateTime.ParseExact(this.InputDayStRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);
            //DateTime _dtInputDayEd = DateTime.ParseExact(this.InputDayEdRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);

            //// 入力日付範囲チェック
            //if (!CheckPeriod(_dtInputDaySt, _dtInputDayEd, 1))
            //{
            //    message = "入力日付は1ヶ月の範囲内で入力してください";
            //    errControl = this.InputDayStRF_tDateEdit;
            //    return result;
            //}

            //// 受注日（出荷日）は何か入力されていたらチェック
            //if (this.SalesDateStRF_tDateEdit.GetLongDate() != 0 || this.SalesDateEdRF_tDateEdit.GetLongDate() != 0)
            //{
            //    // 受注日（出荷日）(開始)
            //    if (!CheckDate(this.SalesDateStRF_tDateEdit))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "受注日付の指定に誤りがあります";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "出荷日付の指定に誤りがあります";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;

            //    }

            //    // 受注日（出荷日）(終了)
            //    if (!CheckDate(this.SalesDateEdRF_tDateEdit))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "受注日付の指定に誤りがあります";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "出荷日付の指定に誤りがあります";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateEdRF_tDateEdit;
            //        return result;
            //    }

            //    DateTime _dtSalesDateSt = DateTime.ParseExact(this.SalesDateStRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);
            //    DateTime _dtSalesDateEd = DateTime.ParseExact(this.SalesDateEdRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);

            //    // 受注日（出荷日）範囲チェック
            //    if (!CheckPeriod(_dtSalesDateSt, _dtSalesDateEd, 240))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "受注日付の範囲に誤りがあります";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "出荷日付の範囲に誤りがあります";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;
            //    }
            //}
            //    // 入力日付(開始)
            //    if (!CheckDate(this.InputDayStRF_tDateEdit))
            //    {
            //        message = "入力日付の指定に誤りがあります";
            //        errControl = this.InputDayStRF_tDateEdit;
            //        return result;
            //    }
            // 2008.07.24 30413 犬飼 既存の入力日と受注・貸出日のチェックを削除 <<<<<<END

            // 2008.07.24 30413 犬飼 担当者のチェック順位を変更 >>>>>>START
            // 担当者コード範囲チェック
            if ((this.tEdit_EmployeeCode_Ed.Text != "") &&
                (this.tEdit_EmployeeCode_St.Text.CompareTo(this.tEdit_EmployeeCode_Ed.Text) > 0))
            {
                message = "担当者の範囲に誤りがあります";
                errControl = this.tEdit_EmployeeCode_St;
                return result;
            }
            // 2008.07.24 30413 犬飼 担当者のチェック順位を変更 <<<<<<END

            // 得意先コード範囲チェック
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                // 2008.07.24 30413 犬飼 エラーメッセージを変更 >>>>>>START
                //message = "得意先コードの範囲に誤りがあります";
                message = "得意先の範囲に誤りがあります";
                // 2008.07.24 30413 犬飼 エラーメッセージを変更 <<<<<<END
                errControl = this.tNedit_CustomerCode_Ed;
                return result;
            }

            #region 粗利範囲チェック
            // 粗利チェックの入力範囲 空白だとエラー表示
            if (this.GrsProfitCheckLower_tNedit.Text == "")
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            //if (this.GrsProfitCheckBest_tNedit.Text == "") // DEL 2008/11/18
            if ((this.GrsProfitCheckBest_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckBest_tNedit.Text) == 0.0)) // ADD 2008/11/18
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            //if (this.GrsProfitCheckUpper_tNedit.Text == "")  // DEL 2008/11/18
            if ((this.GrsProfitCheckUpper_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckUpper_tNedit.Text) == 0.0)) // ADD 2008/11/18
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckUpper_tNedit;
                return result;
            }


            // 適正値より下限が大きいとエラー表示
            //if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) > 0.0)) // DEL 2008/11/17
            if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) >= 0.0)) // ADD 2008/11/17
            {
                message = "粗利チェックの範囲に誤りがあります";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // 上限より適正値が大きいとエラー表示
            //if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) > 0.0)) // DEL 2008/11/17
            if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) >= 0.0)) // ADD 2008/11/17
            {
                message = "粗利チェックの範囲に誤りがあります";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            #endregion

            // 2008.07.24 30413 犬飼 担当者のチェック順位を変更 >>>>>>START
            //// 担当者コード範囲チェック
            //if ((this.SalesEmployeeCdEd_tEdit.Text != "") &&
            //    (this.SalesEmployeeCdSt_tEdit.Text.CompareTo(this.SalesEmployeeCdEd_tEdit.Text) > 0))
            //{
            //    message = "担当者コードの範囲に誤りがあります";
            //    errControl = this.SalesEmployeeCdSt_tEdit;
            //    return result;
            //}
            // 2008.07.24 30413 犬飼 担当者のチェック順位を変更 <<<<<<END

            return true;

        }

        /// <summary>
        /// 日付範囲チェック呼び出し(受注・貸出日)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange_SalesDays(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //// 2008.08.01 30413 犬飼 範囲を３ケ月に変更 >>>>>>START
            ////cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false);
            //// 2008.08.01 30413 犬飼 範囲を３ケ月に変更 <<<<<<END
            // --- DEL 2009/04/06 --------------------------------<<<<<
            // --- ADD 2009/04/06 -------------------------------->>>>>
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, true);
            // --- ADD 2009/04/06 --------------------------------<<<<<

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 日付範囲チェック呼び出し(入力日)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange_InputDays(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // 2009.01.06 30413 犬飼 日付チェックを修正 >>>>>>START
            // 2008.08.01 30413 犬飼 範囲チェック無しに変更 >>>>>>START
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref startDate, ref endDate, false, false);
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, true);
            // 2008.08.01 30413 犬飼 範囲チェック無しに変更 <<<<<<END
            // 2009.01.06 30413 犬飼 日付チェックを修正 <<<<<<END
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
		/// SearchData
		/// </summary>
		/// <param name="extraInfo"></param>
		/// <returns></returns>
        private int SearchData(ExtrInfo_DCHNB02013E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件が変わっているならリモーティング
            if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
            {
                try
				{	//伝票/明細形式判定関連
					status = this._saleConfListAcs.Search(extraInfo, out message, 0);
					if (status == 0)
					{
						this._printBuffDataSet = this._saleConfListAcs._printDataSet;
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
                            this._saleConfListCndtnWork = extraInfo.Clone();

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            //this._printBuffDataSet = new DataSet();
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
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count == 0)
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
        ///  画面→抽出条件へ設定します。
        /// </remarks>
        public int SetExtraInfoFromScreen(ref ExtrInfo_DCHNB02013E extraInfo)
        {
			int status = 0;
			
			if (extraInfo == null)
            {
                extraInfo = new ExtrInfo_DCHNB02013E();
            }

            try
            {
                //起動モードパラメータ
                extraInfo.AcptAnOdrStatus = this._selPrintMode;

                // 企業コード
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // 選択拠点
                // 拠点オプションありのとき
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // 全社選択かどうか
                    if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
                    {
                        extraInfo.ResultsAddUpSecList = new string[1];
                        extraInfo.ResultsAddUpSecList[0] = "0";
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
                        extraInfo.ResultsAddUpSecList = (string[])secList.ToArray(typeof(string));
                    }
                }
                // 拠点オプションなしの時
                else
                {
                    extraInfo.ResultsAddUpSecList = new string[0];
                }

                // 受注日or貸出日の(開始) ・(終了)   
                switch (this._selPrintMode)
                {
                    case 20:	//受注日
                        {
                            extraInfo.SalesDateSt = this.SalesDateStRF_tDateEdit.GetLongDate();
                            extraInfo.SalesDateEd = this.SalesDateEdRF_tDateEdit.GetLongDate();
                            break;
                        }
                    case 40:	//貸出日
                        {
                            extraInfo.ShipmentDaySt = this.SalesDateStRF_tDateEdit.GetLongDate();
                            extraInfo.ShipmentDayEd = this.SalesDateEdRF_tDateEdit.GetLongDate();
                            break;
                        }
                }

                // 入力日付(開始)        
                extraInfo.SearchSlipDateSt = this.InputDayStRF_tDateEdit.GetLongDate();
                // 入力日付(終了)        
                extraInfo.SearchSlipDateEd = this.InputDayEdRF_tDateEdit.GetLongDate();

                // 2008.07.24 30413 犬飼 発行タイプと改頁を追加 >>>>>>START
                // 発行タイプ
                extraInfo.PublicationType = Convert.ToInt32(this.tComboEditor_PublicationType.SelectedItem.DataValue);

                // 改頁
                extraInfo.NewPageType = Convert.ToInt32(this.tComboEditor_NewPageType.SelectedItem.DataValue);
                // 2008.07.24 30413 犬飼 発行タイプと改頁を追加 <<<<<<END

                // --- ADD 2009/03/30 -------------------------------->>>>>
                // 原価・粗利出力
                extraInfo.CostOut = Convert.ToInt32(this.ultraOptionSet_CostOut.CheckedItem.DataValue);

                // 日計印字
                extraInfo.PrintDailyFooter = Convert.ToInt32(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue);
                // --- ADD 2009/03/30 --------------------------------<<<<<
                
                //出力順
                extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

                // 得意先(開始)
                extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // 得意先(終了)
                extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();

                //粗利チェック(下限)
                extraInfo.GrsProfitCheckLower = Convert.ToDouble(this.GrsProfitCheckLower_tNedit.Text);
                //粗利チェック(適正)
                extraInfo.GrsProfitCheckBest = Convert.ToDouble(this.GrsProfitCheckBest_tNedit.Text);
                //粗利チェック(上限)
                extraInfo.GrsProfitCheckUpper = Convert.ToDouble(this.GrsProfitCheckUpper_tNedit.Text);

                //粗利チェック2
                extraInfo.GrossMarginLow2 = this.GrossMarginLow2_Nedit.GetInt();

                //粗利チェック3
                extraInfo.GrossMarginBest2 = this.GrossMarginBest2_Nedit.GetInt();

                //粗利チェック4
                extraInfo.GrossMarginUpper2 = this.GrossMarginUpper2_Nedit.GetInt();

                //粗利チェックマーク1(下限)
                extraInfo.GrossMargin1Mark = this.GrossMarginLowMark_tEdit.Text;
                //粗利チェックマーク2(下限)～（適正）
                extraInfo.GrossMargin2Mark = this.GrossMarginBestMark_tEdit.Text;
                //粗利チェックマーク3(適正)～（上限）
                extraInfo.GrossMargin3Mark = this.GrossMarginUprMark_tEdit.Text;
                //粗利チェックマーク4(上限)
                extraInfo.GrossMargin4Mark = this.GrossMarginMaxMark_tEdit.Text;

                // 2008.10.09 30413 犬飼 0詰め対応 >>>>>>START
                //// 担当コード(開始)
                //extraInfo.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.Text;
                //// 担当コード(終了)
                //extraInfo.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.Text;
                // 担当コード(開始)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.SalesEmployeeCdSt = "";
                }
                else
                {
                    extraInfo.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // 担当コード(終了)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.SalesEmployeeCdEd = "";
                }
                else
                {
                    extraInfo.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
                // 2008.10.09 30413 犬飼 0詰め対応 <<<<<<END
            }
            catch (Exception)
            {
                status = -1;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "抽出条件の取得に失敗しました。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;
        }

        /// <summary>
        /// データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            _SalesConfDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_OrderConfDataTable;
        }

		/// <summary>
        /// 最上位フォーム取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
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
            // 2008.07.24 30413 犬飼 未使用メソッドの削除 >>>>>>START
            //this.AdjustExplorerBarExpand();
            // 2008.07.24 30413 犬飼 未使用メソッドの削除 <<<<<<END
        }

        // 2008.07.24 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region エクスプローラーバー展開状態調整
        ///// <summary>
        ///// エクスプローラーバー展開状態調整
        ///// </summary>
        //private void AdjustExplorerBarExpand()
        //{
        //    if (this._topForm == null) return;

        //    if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
        //    {
        //        // トップフォームの高さが基準値より高い場合
        //        this._explorerBarExpanding = true;
        //        try
        //        {
        //            //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
        //        }
        //        finally
        //        {
        //            this._explorerBarExpanding = false;
        //        }
        //    }
        //    else
        //    {
        //        // トップフォームの高さが基準値より低い場合
        //        this._explorerBarExpanding = true;
        //        try
        //        {
        //            //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
        //        }
        //        finally
        //        {
        //            this._explorerBarExpanding = false;
        //        }
        //    }
        //}
        #endregion
        // 2008.07.24 30413 犬飼 未使用メソッドの削除 <<<<<<END
            
	    /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
          return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

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

        /// <summary>
        /// 終了項目値自動設定処理(TComboEditor)
        /// </summary>
		/// <param name="startComboEditor">開始数値項目TEdit</param>
		/// <param name="endComboEditor">終了数値項目TEdit</param>
        private void AutoSetEndValue(TComboEditor startComboEditor, TComboEditor endComboEditor)
        {
            endComboEditor.SelectedIndex = startComboEditor.SelectedIndex;
        }

            
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
        /// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
        /// </remarks>
        private void DCHNB02010UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._saleConfListAcs = new SaleConfAcs();

            // 最上位フォーム取得
		    this.GetTopForm();

            // 拠点オプション有無を取得する
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 本社/拠点情報を取得する
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

			this.Initial_Timer.Enabled = true;

            // 2008.07.24 30413 犬飼 発行タイプの追加 >>>>>>START
            // コンボボックスに発行タイプを設定
            switch (this._selPrintMode)
            {
                case 20:
                    {	// 受注確認表
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrder, PUBLICATION_TYPE0);        // 受注
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrderAddUp, PUBLICATION_TYPE1);   // 受注計上済
                        break;
                    }
                case 40:
                    {	// 貸出確認表
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.Loan, PUBLICATION_TYPE2);                 // 貸出
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.LoanAddUp, PUBLICATION_TYPE3);            // 貸出計上済
                        break;
                    }
            }
            // 2008.07.24 30413 犬飼 発行タイプの追加 <<<<<<END
            
			//コンボボックスにソート順を設定
			switch (this._selPrintMode)
			{
				case 20:	
					{	//受注日＋伝票番号＋行番号
						Infragistics.Win.ValueListItem listItem0_1 = new Infragistics.Win.ValueListItem();
						listItem0_1.DataValue = 0;
						listItem0_1.DisplayText = CHANGEPAGEDIV1_01;
						this.PrintOder_tComboEditor.Items.Add(listItem0_1);
						break;
					}
				case 40:	
					{	//貸出日＋伝票番号＋行番号
						Infragistics.Win.ValueListItem listItem0_2 = new Infragistics.Win.ValueListItem();
						listItem0_2.DataValue = 0;
						listItem0_2.DisplayText = CHANGEPAGEDIV1_02;
						this.PrintOder_tComboEditor.Items.Add(listItem0_2);
						break;
					}
			}
			//伝票番号
			Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
			listItem1.DataValue = 1;
			listItem1.DisplayText = CHANGEPAGEDIV2;
			//得意先＋伝票番号
			Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
			listItem2.DataValue = 2;
			listItem2.DisplayText = CHANGEPAGEDIV3;
			//担当者＋伝票番号
			Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
			listItem3.DataValue = 3;
			listItem3.DisplayText = CHANGEPAGEDIV4;

			this.PrintOder_tComboEditor.Items.Add(listItem1);
			this.PrintOder_tComboEditor.Items.Add(listItem2);
			this.PrintOder_tComboEditor.Items.Add(listItem3);

			//TODO 売上全体設定マスタから粗利率とマークを取得、入力欄に表示
			this._salesTtlStAcs = new SalesTtlStAcs();
			this._salesTtlSt = new SalesTtlSt();

            // 2008.07.24 30413 犬飼 拠点コード"0"のレコードを取得 >>>>>>START
            //this._salesTtlStAcs.Read(out this._salesTtlSt, LoginInfoAcquisition.EnterpriseCode); //EnterpriseCodeがマスタを呼ぶときのKeyになっている。
            int status = 0;
            ArrayList retList = null;

            status = this._salesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                // --- DEL 2008/11/17 -------------------------------->>>>>
                //foreach (SalesTtlSt wkSalesTtlSt in retList)
                //{
                //    if (wkSalesTtlSt.SectionCode.Trim().Equals("00"))
                //    {
                //        this._salesTtlSt = wkSalesTtlSt.Clone();
                //    }
                //}
                // --- DEL 2008/11/17 --------------------------------<<<<<
                // --- ADD 2008/11/17 -------------------------------->>>>>
                bool hitOwnSection = false;

                foreach (SalesTtlSt wkSalesTtlSt in retList)
                {
                    if (wkSalesTtlSt.SectionCode.Trim().Equals(this._ownSectionCode.Trim())
                        && wkSalesTtlSt.LogicalDeleteCode == 0)
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                        hitOwnSection = true;
                    }
                }

                // 自拠点で見つからない場合は00拠点の設定を取得
                if (!hitOwnSection)
                {
                    foreach (SalesTtlSt wkSalesTtlSt in retList)
                    {
                        if (wkSalesTtlSt.SectionCode.Trim().Equals("00"))
                        {
                            this._salesTtlSt = wkSalesTtlSt.Clone();
                        }
                    }
                }
                // --- ADD 2008/11/17 --------------------------------<<<<<
            }
            // 2008.07.24 30413 犬飼 拠点コード"0"のレコードを取得 <<<<<<END

            // 2008.09.18 30413 犬飼 粗利率の初期値を不動小数で設定 >>>>>>START
            //粗利チェックの下限値（％で入力）　XX.X％　以上
            //this.GrsProfitCheckLower_tNedit.Text = this._salesTtlSt.GrsProfitCheckLower.ToString();
            //this.GrossMarginLow2_Nedit.Text = this._salesTtlSt.GrsProfitCheckLower.ToString();
            this.GrsProfitCheckLower_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckLower);

			//粗利チェックの適正値（％で入力）　XX.X％　以上
            //this.GrsProfitCheckBest_tNedit.Text = this._salesTtlSt.GrsProfitCheckBest.ToString();
            //this.GrossMarginUpper2_Nedit.Text = this._salesTtlSt.GrsProfitCheckBest.ToString();
            this.GrsProfitCheckBest_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckBest);

			//粗利チェックの上限値（％で入力）　XX.X％　以上
            //this.GrsProfitCheckUpper_tNedit.Text = this._salesTtlSt.GrsProfitCheckUpper.ToString();
            //this.GrossMarginUpper2_Nedit.Text = this._salesTtlSt.GrsProfitCheckUpper.ToString();
            this.GrsProfitCheckUpper_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckUpper);
            // 2008.09.18 30413 犬飼 粗利率の初期値を不動小数で設定 <<<<<<END
            
			//粗利チェックの下限値未満の記号
			this.GrossMarginLowMark_tEdit.Text = this._salesTtlSt.GrsProfitChkLowSign;
			//粗利チェックの適正値から下限値までの記号
			this.GrossMarginBestMark_tEdit.Text = this._salesTtlSt.GrsProfitChkBestSign;
			//粗利チェックの上限値から適正値までの記号
			this.GrossMarginUprMark_tEdit.Text = this._salesTtlSt.GrsProfitChkUprSign;
			//粗利チェックの上限値オーバーの記号
			this.GrossMarginMaxMark_tEdit.Text = this._salesTtlSt.GrsProfitChkMaxSign;

            // --- ADD 2009/03/30 -------------------------------->>>>>
            Uos_CostOutRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_CostOut);
            Uos_CostOutRadioKeyPressHelper.StartSpaceKeyControl();

            Uos_PrindDailyFooterRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_PrintDailyFooter);
            Uos_PrindDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/03/30 --------------------------------<<<<<
        }

        /// <summary>
        /// 画面アクティブイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 元帳メイン画面がアクティブになったときのイベント処理です。</br>
        /// </remarks>
        private void DCHNB02010UA_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }

      

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 2008.09.24 30413 犬飼 入力支援の削除 >>>>>>START
            //// 入力支援 ============================================ //
            //// 売上日
            //if ((e.PrevCtrl == this.SalesDateStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.SalesDateEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.SalesDateStRF_tDateEdit, this.SalesDateEdRF_tDateEdit);
            //}

            //// 入荷日
            //if ((e.PrevCtrl == this.InputDayStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.InputDayEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.InputDayStRF_tDateEdit, this.InputDayEdRF_tDateEdit);
            //}

            //// 得意先コード
            //if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            //{
            //    AutoSetEndValue(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed);
            //}

            //// 担当コード
            //if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            //{
            //    AutoSetEndValue(this.tEdit_EmployeeCode_St, this.tEdit_EmployeeCode_Ed);
            //}
            // 2008.09.24 30413 犬飼 入力支援の削除 <<<<<<END
            
            // 2008.09.18 30413 犬飼 ガイドボタン遷移制御 >>>>>>START
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        //// 得意先(終了)→粗利設定下限値
                        //e.NextCtrl = this.GrossMarginLowMark_tEdit; // DEL 2009/03/30
                        // 得意先(終了)→発行タイプ
                        e.NextCtrl = this.tComboEditor_PublicationType; // ADD 2009/03/30

                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    //if (e.PrevCtrl == this.GrossMarginLowMark_tEdit) // DEL 2009/03/30
                    if (e.PrevCtrl == this.tComboEditor_PublicationType) // ADD 2009/03/30
                    {
                        //// 粗利設定下限値→得意先(終了)
                        // 発行タイプ→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }                    
                }
            }
            // 2008.09.18 30413 犬飼 ガイドボタン遷移制御 <<<<<<END

        }



        
        /// <summary>
        /// 初期タイマーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 初期処理を行います。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面初期表示
            this.InitialScreenSetting();
        
            // 初期フォーカス設定
            this.SalesDateStRF_tDateEdit.Focus();

    	    // メインフレームにツールバー設定通知
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
	    }

    	        
		///// <summary>
		///// Control.GroupCollapsingイベント
		///// </summary>
		///// <param name="sender">イベントオブジェクト</param>
		///// <param name="e">イベント引数</param>
		///// <remarks>
		///// <br>Note        : エクスプローラバーのグループを展開される際に発生します。</br>
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
		/// <br>Date		: 2008.01.07</br>
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
		/// <br>Date		: 2008.01.07</br>
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



	    #endregion

	    #region IPrintConditionInpTypeSelectedSection メンバ

		/// <summary>
		/// CheckedSection Event
		/// </summary>
		/// <param name="sectionCode">対象オブジェクト</param>
		/// <param name="checkState">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 出力対象拠点が選択された時に発生する。</br>
		/// <br>Programmer	: 馬淵 愛</br>
		/// <br>Date		: 2008.01.07</br>
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
        /// <br>Note       : 選択されている拠点を設定します</br>
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
		/// InitVisibleCheckSection
		/// </summary>
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
        ///  拠点オプション取得プロパティ
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
        ///  本社機能取得プロパティ
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
        ///  計上拠点選択処理
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
        ///  選択されている計上拠点を設定します
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            this._selectedAddUpCd = addUpCd;
            return;
        }


        #endregion


        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(開始)を画面に表示する
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(終了)を画面に表示する
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }


        #region ■ガイド起動イベント
        /// <summary>
        /// 得意先コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.07.24 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.24 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }
        #endregion

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.07.24 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.24 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.09 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }

        /// <summary>
        /// 受付従業員コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.09 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.09 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 受付従業員コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.09 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.09 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

		//テキストボックスへの粗利率の入力を連動させる
        private void GrsProfitCheckLower_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginLow2_Nedit.Text = this.GrsProfitCheckLower_tNedit.Text;
		}

		private void GrsProfitCheckBest_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginBest2_Nedit.Text = this.GrsProfitCheckBest_tNedit.Text;
		}

		private void GrsProfitCheckUpper_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginUpper2_Nedit.Text = this.GrsProfitCheckUpper_tNedit.Text;
		}

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの下限値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの適正値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの上限値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }
       
    }
}
