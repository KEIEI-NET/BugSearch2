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
using Broadleaf.Application.Controller.Util; // ADD 2008/12/18 [9352]

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 帳票・チャート印刷条件フォームクラス
    /// </summary>
    /// <br>UpdateNote  : 2008/12/18 30462 行澤仁美　バグ修正</br>
    /// <br>              2009/01/30       照田貴志　不具合対応[9828][9841]</br>
    /// <br>              2009/02/23       上野俊治　不具合対応[11812]</br>
    /// <br>              2009/02/24       上野俊治　不具合対応[11809]</br>
    /// <br>              2009/03/05       照田貴志　不具合対応[12187]</br>
    public class DCTOK02090UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer,
        //IPrintConditionInpTypeChart, // DEL 2009/02/23
        IPrintConditionInpTypeCondition /* なくても動くようだったら削除可*/

	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel DCTOK02090UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private ToolTip toolTip1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_SalesEmp;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T2;
		private TNedit tNedit_CustomerCode_Ed;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Customer;
		private TNedit tNedit_CustomerCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private TComboEditor tComboEditor_PrintType;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_TotalWay;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_MoneyUnit;
		private TDateEdit ItdedDateEdRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private TDateEdit ItdedDateStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel28;
		private Infragistics.Win.Misc.UltraLabel ultraLabel29;
		private Infragistics.Win.Misc.UltraLabel ultraLabel30;
		private Infragistics.Win.Misc.UltraLabel ultraLabel31;
		private Infragistics.Win.Misc.UltraLabel ultraLabel32;
		private Infragistics.Win.Misc.UltraLabel ultraLabel33;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.Misc.UltraLabel ultraLabel27;
		private Infragistics.Win.Misc.UltraButton BusinessTypeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton BusinessTypeCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Business;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T4;
		private Infragistics.Win.Misc.UltraButton AreaCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton AreaCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Area;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T3;
		private TNedit TmTotalCostLow_Nedit;
		private TNedit TmTotalCostHigh_Nedit;
		private TNedit TyGrsMarginLow_Nedit;
		private TNedit TyGrsMarginHigh_Nedit;
		private TNedit TmGrsMarginLow_Nedit;
		private TNedit TmGrsMarginHigh_Nedit;
		private TNedit TyTotalCostLow_Nedit;
		private TNedit TyTotalCostHigh_Nedit;
		private TNedit tNedit_AreaCd_St;
		private TNedit tNedit_AreaCd_Ed;
		private TNedit tNedit_SalesEmployeeCd_Ed;
		private TNedit tNedit_SalesEmployeeCd_St;
		private TNedit tNedit_BusinessTypeCode_Ed;
		private TNedit tNedit_BusinessTypeCode_St;
		private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private TComboEditor tComboEditor_IssueType;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TNedit tNedit_BLGoodsCode_Ed;
        private TNedit tNedit_BLGoodsCode_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_BLGoodsCodeGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_BLGoodsCodeGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_BLGoodsCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T5;
        private TNedit tNedit_BLGloupCode_Ed;
        private TNedit tNedit_BLGloupCode_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_DetailGoodsGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_DetailGoodsGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_BLGloupCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T6;
        private TNedit tNedit_GoodsLGroup_Ed;
        private TNedit tNedit_GoodsLGroup_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_GoodsLGroupGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_GoodsLGroupGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_GoodsLGroup;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T7;
        private TNedit tNedit_GoodsMGroup_Ed;
        private TNedit tNedit_GoodsMGroup_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_MediumGoodsGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_MediumGoodsGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_GoodsMGroup;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T8;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkBox_NewPage2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkBox_NewPage;
		private System.ComponentModel.IContainer components;
		#endregion
		
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region constructer

		/// <summary>
		/// 前年対比表UIクラス
		/// </summary>
		public DCTOK02090UA()
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

			//自社情報の取得
			this._companyInfAcs = new CompanyInfAcs();

			_companyInf = new CompanyInf();
			int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);

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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.checkBox_NewPage2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.checkBox_NewPage = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.TyGrsMarginLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyGrsMarginHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmGrsMarginLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmGrsMarginHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyTotalCostLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyTotalCostHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmTotalCostHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmTotalCostLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_TotalWay = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_MoneyUnit = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ItdedDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_IssueType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tNedit_GoodsMGroup_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMGroup_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_MediumGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_MediumGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_GoodsMGroup = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T8 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsLGroup_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsLGroup_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_GoodsLGroupGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_GoodsLGroupGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_GoodsLGroup = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T7 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGloupCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BLGloupCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_DetailGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_DetailGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_BLGloupCode = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T6 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BLGoodsCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_BLGoodsCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_BLGoodsCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_BLGoodsCode = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T5 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BusinessTypeCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BusinessTypeCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesEmployeeCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesEmployeeCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AreaCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AreaCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BusinessTypeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.BusinessTypeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_Business = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T4 = new Infragistics.Win.Misc.UltraLabel();
            this.AreaCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.AreaCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_Area = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T3 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_SalesEmp = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLbK_Customer = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel_T1 = new Infragistics.Win.Misc.UltraLabel();
            this.DCTOK02090UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_TotalWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_MoneyUnit)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_IssueType)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.DCTOK02090UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.checkBox_NewPage2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.checkBox_NewPage);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyGrsMarginLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyGrsMarginHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmGrsMarginLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmGrsMarginHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyTotalCostLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyTotalCostHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmTotalCostHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmTotalCostLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel29);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel30);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel31);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel32);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel33);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_PrintType);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_TotalWay);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_MoneyUnit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ItdedDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ItdedDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(695, 226);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // checkBox_NewPage2
            // 
            this.checkBox_NewPage2.Location = new System.Drawing.Point(313, 91);
            this.checkBox_NewPage2.Name = "checkBox_NewPage2";
            this.checkBox_NewPage2.Size = new System.Drawing.Size(176, 18);
            this.checkBox_NewPage2.TabIndex = 7;
            this.checkBox_NewPage2.Text = "担当者毎で改頁";
            this.checkBox_NewPage2.CheckedChanged += new System.EventHandler(this.checkBox_NewPage2_CheckedChanged);
            // 
            // checkBox_NewPage
            // 
            this.checkBox_NewPage.Location = new System.Drawing.Point(166, 91);
            this.checkBox_NewPage.Name = "checkBox_NewPage";
            this.checkBox_NewPage.Size = new System.Drawing.Size(141, 18);
            this.checkBox_NewPage.TabIndex = 6;
            this.checkBox_NewPage.Text = "拠点毎で改頁";
            // 
            // TyGrsMarginLow_Nedit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.TextHAlignAsString = "Right";
            this.TyGrsMarginLow_Nedit.ActiveAppearance = appearance1;
            appearance2.TextHAlignAsString = "Right";
            this.TyGrsMarginLow_Nedit.Appearance = appearance2;
            this.TyGrsMarginLow_Nedit.AutoSelect = true;
            this.TyGrsMarginLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyGrsMarginLow_Nedit.DataText = "";
            this.TyGrsMarginLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyGrsMarginLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyGrsMarginLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TyGrsMarginLow_Nedit.Location = new System.Drawing.Point(313, 198);
            this.TyGrsMarginLow_Nedit.MaxLength = 7;
            this.TyGrsMarginLow_Nedit.Name = "TyGrsMarginLow_Nedit";
            this.TyGrsMarginLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyGrsMarginLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyGrsMarginLow_Nedit.TabIndex = 15;
            // 
            // TyGrsMarginHigh_Nedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.TextHAlignAsString = "Right";
            this.TyGrsMarginHigh_Nedit.ActiveAppearance = appearance3;
            appearance4.TextHAlignAsString = "Right";
            this.TyGrsMarginHigh_Nedit.Appearance = appearance4;
            this.TyGrsMarginHigh_Nedit.AutoSelect = true;
            this.TyGrsMarginHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyGrsMarginHigh_Nedit.DataText = "";
            this.TyGrsMarginHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyGrsMarginHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyGrsMarginHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TyGrsMarginHigh_Nedit.Location = new System.Drawing.Point(166, 198);
            this.TyGrsMarginHigh_Nedit.MaxLength = 7;
            this.TyGrsMarginHigh_Nedit.Name = "TyGrsMarginHigh_Nedit";
            this.TyGrsMarginHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyGrsMarginHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyGrsMarginHigh_Nedit.TabIndex = 14;
            // 
            // TmGrsMarginLow_Nedit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.TmGrsMarginLow_Nedit.ActiveAppearance = appearance5;
            appearance6.TextHAlignAsString = "Right";
            this.TmGrsMarginLow_Nedit.Appearance = appearance6;
            this.TmGrsMarginLow_Nedit.AutoSelect = true;
            this.TmGrsMarginLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmGrsMarginLow_Nedit.DataText = "";
            this.TmGrsMarginLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmGrsMarginLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmGrsMarginLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmGrsMarginLow_Nedit.Location = new System.Drawing.Point(313, 171);
            this.TmGrsMarginLow_Nedit.MaxLength = 7;
            this.TmGrsMarginLow_Nedit.Name = "TmGrsMarginLow_Nedit";
            this.TmGrsMarginLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmGrsMarginLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmGrsMarginLow_Nedit.TabIndex = 13;
            // 
            // TmGrsMarginHigh_Nedit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.TmGrsMarginHigh_Nedit.ActiveAppearance = appearance7;
            appearance8.TextHAlignAsString = "Right";
            this.TmGrsMarginHigh_Nedit.Appearance = appearance8;
            this.TmGrsMarginHigh_Nedit.AutoSelect = true;
            this.TmGrsMarginHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmGrsMarginHigh_Nedit.DataText = "";
            this.TmGrsMarginHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmGrsMarginHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmGrsMarginHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TmGrsMarginHigh_Nedit.Location = new System.Drawing.Point(166, 171);
            this.TmGrsMarginHigh_Nedit.MaxLength = 7;
            this.TmGrsMarginHigh_Nedit.Name = "TmGrsMarginHigh_Nedit";
            this.TmGrsMarginHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmGrsMarginHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmGrsMarginHigh_Nedit.TabIndex = 12;
            // 
            // TyTotalCostLow_Nedit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.TyTotalCostLow_Nedit.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Right";
            this.TyTotalCostLow_Nedit.Appearance = appearance10;
            this.TyTotalCostLow_Nedit.AutoSelect = true;
            this.TyTotalCostLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyTotalCostLow_Nedit.DataText = "";
            this.TyTotalCostLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyTotalCostLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyTotalCostLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TyTotalCostLow_Nedit.Location = new System.Drawing.Point(313, 144);
            this.TyTotalCostLow_Nedit.MaxLength = 7;
            this.TyTotalCostLow_Nedit.Name = "TyTotalCostLow_Nedit";
            this.TyTotalCostLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyTotalCostLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyTotalCostLow_Nedit.TabIndex = 11;
            // 
            // TyTotalCostHigh_Nedit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.TyTotalCostHigh_Nedit.ActiveAppearance = appearance11;
            appearance12.TextHAlignAsString = "Right";
            this.TyTotalCostHigh_Nedit.Appearance = appearance12;
            this.TyTotalCostHigh_Nedit.AutoSelect = true;
            this.TyTotalCostHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyTotalCostHigh_Nedit.DataText = "";
            this.TyTotalCostHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyTotalCostHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyTotalCostHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TyTotalCostHigh_Nedit.Location = new System.Drawing.Point(166, 144);
            this.TyTotalCostHigh_Nedit.MaxLength = 7;
            this.TyTotalCostHigh_Nedit.Name = "TyTotalCostHigh_Nedit";
            this.TyTotalCostHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyTotalCostHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyTotalCostHigh_Nedit.TabIndex = 10;
            // 
            // TmTotalCostHigh_Nedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.TmTotalCostHigh_Nedit.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            this.TmTotalCostHigh_Nedit.Appearance = appearance14;
            this.TmTotalCostHigh_Nedit.AutoSelect = true;
            this.TmTotalCostHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmTotalCostHigh_Nedit.DataText = "";
            this.TmTotalCostHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmTotalCostHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmTotalCostHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmTotalCostHigh_Nedit.Location = new System.Drawing.Point(166, 117);
            this.TmTotalCostHigh_Nedit.MaxLength = 7;
            this.TmTotalCostHigh_Nedit.Name = "TmTotalCostHigh_Nedit";
            this.TmTotalCostHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmTotalCostHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmTotalCostHigh_Nedit.TabIndex = 8;
            // 
            // TmTotalCostLow_Nedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            this.TmTotalCostLow_Nedit.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            this.TmTotalCostLow_Nedit.Appearance = appearance16;
            this.TmTotalCostLow_Nedit.AutoSelect = true;
            this.TmTotalCostLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmTotalCostLow_Nedit.DataText = "";
            this.TmTotalCostLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmTotalCostLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmTotalCostLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmTotalCostLow_Nedit.Location = new System.Drawing.Point(313, 117);
            this.TmTotalCostLow_Nedit.MaxLength = 7;
            this.TmTotalCostLow_Nedit.Name = "TmTotalCostLow_Nedit";
            this.TmTotalCostLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmTotalCostLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmTotalCostLow_Nedit.TabIndex = 9;
            // 
            // ultraLabel28
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance17;
            this.ultraLabel28.Location = new System.Drawing.Point(387, 199);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel28.TabIndex = 63;
            this.ultraLabel28.Text = "％以下";
            // 
            // ultraLabel29
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance18;
            this.ultraLabel29.Location = new System.Drawing.Point(240, 198);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel29.TabIndex = 61;
            this.ultraLabel29.Text = "％以上";
            // 
            // ultraLabel30
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance19;
            this.ultraLabel30.Location = new System.Drawing.Point(14, 198);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel30.TabIndex = 59;
            this.ultraLabel30.Text = "当年粗利";
            // 
            // ultraLabel31
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance20;
            this.ultraLabel31.Location = new System.Drawing.Point(387, 172);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel31.TabIndex = 58;
            this.ultraLabel31.Text = "％以下";
            // 
            // ultraLabel32
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance21;
            this.ultraLabel32.Location = new System.Drawing.Point(240, 171);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel32.TabIndex = 56;
            this.ultraLabel32.Text = "％以上";
            // 
            // ultraLabel33
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance22;
            this.ultraLabel33.Location = new System.Drawing.Point(14, 171);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel33.TabIndex = 54;
            this.ultraLabel33.Text = "当月粗利";
            // 
            // ultraLabel14
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance23;
            this.ultraLabel14.Location = new System.Drawing.Point(387, 145);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel14.TabIndex = 53;
            this.ultraLabel14.Text = "％以下";
            // 
            // ultraLabel16
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance24;
            this.ultraLabel16.Location = new System.Drawing.Point(240, 144);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel16.TabIndex = 51;
            this.ultraLabel16.Text = "％以上";
            // 
            // ultraLabel27
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance25;
            this.ultraLabel27.Location = new System.Drawing.Point(14, 144);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel27.TabIndex = 49;
            this.ultraLabel27.Text = "当年純売上";
            // 
            // ultraLabel13
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance26;
            this.ultraLabel13.Location = new System.Drawing.Point(387, 118);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel13.TabIndex = 48;
            this.ultraLabel13.Text = "％以下";
            // 
            // ultraLabel12
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance27;
            this.ultraLabel12.Location = new System.Drawing.Point(240, 117);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel12.TabIndex = 46;
            this.ultraLabel12.Text = "％以上";
            // 
            // ultraLabel9
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance28;
            this.ultraLabel9.Location = new System.Drawing.Point(14, 117);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel9.TabIndex = 44;
            this.ultraLabel9.Text = "当月純売上";
            // 
            // ultraLabel7
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance29;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 88);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(76, 23);
            this.ultraLabel7.TabIndex = 42;
            this.ultraLabel7.Text = "改頁";
            // 
            // tComboEditor_PrintType
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ActiveAppearance = appearance33;
            this.tComboEditor_PrintType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ItemAppearance = appearance35;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "売上";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "粗利";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "売上＆粗利";
            this.tComboEditor_PrintType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.tComboEditor_PrintType.LimitToList = true;
            this.tComboEditor_PrintType.Location = new System.Drawing.Point(512, 61);
            this.tComboEditor_PrintType.Name = "tComboEditor_PrintType";
            this.tComboEditor_PrintType.Size = new System.Drawing.Size(112, 24);
            this.tComboEditor_PrintType.TabIndex = 5;
            this.tComboEditor_PrintType.Text = "売上＆粗利";
            // 
            // ultraLabel15
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance84;
            this.ultraLabel15.Location = new System.Drawing.Point(386, 62);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel15.TabIndex = 37;
            this.ultraLabel15.Text = "印刷タイプ";
            // 
            // ultraOptionSet_TotalWay
            // 
            this.ultraOptionSet_TotalWay.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_TotalWay.CheckedIndex = 1;
            valueListItem4.DataValue = true;
            valueListItem4.DisplayText = "全社";
            valueListItem5.DataValue = false;
            valueListItem5.DisplayText = "拠点毎";
            this.ultraOptionSet_TotalWay.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.ultraOptionSet_TotalWay.Location = new System.Drawing.Point(165, 5);
            this.ultraOptionSet_TotalWay.Name = "ultraOptionSet_TotalWay";
            this.ultraOptionSet_TotalWay.Size = new System.Drawing.Size(150, 23);
            this.ultraOptionSet_TotalWay.TabIndex = 1;
            this.ultraOptionSet_TotalWay.Text = "拠点毎";
            this.ultraOptionSet_TotalWay.ValueChanged += new System.EventHandler(this.ultraOptionSet_TotalWay_ValueChanged);
            // 
            // ultraLabel2
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance34;
            this.ultraLabel2.Location = new System.Drawing.Point(15, 4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(76, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "集計方法";
            // 
            // ultraOptionSet_MoneyUnit
            // 
            this.ultraOptionSet_MoneyUnit.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_MoneyUnit.CheckedIndex = 0;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "円";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "千円";
            this.ultraOptionSet_MoneyUnit.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.ultraOptionSet_MoneyUnit.Location = new System.Drawing.Point(167, 62);
            this.ultraOptionSet_MoneyUnit.Name = "ultraOptionSet_MoneyUnit";
            this.ultraOptionSet_MoneyUnit.Size = new System.Drawing.Size(112, 23);
            this.ultraOptionSet_MoneyUnit.TabIndex = 4;
            this.ultraOptionSet_MoneyUnit.Text = "円";
            // 
            // ItdedDateEdRF_tDateEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ItdedDateEdRF_tDateEdit.ActiveEditAppearance = appearance36;
            this.ItdedDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ItdedDateEdRF_tDateEdit.CalendarDisp = true;
            this.ItdedDateEdRF_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.ItdedDateEdRF_tDateEdit.EditAppearance = appearance37;
            this.ItdedDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ItdedDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance38.TextHAlignAsString = "Left";
            appearance38.TextVAlignAsString = "Middle";
            this.ItdedDateEdRF_tDateEdit.LabelAppearance = appearance38;
            this.ItdedDateEdRF_tDateEdit.Location = new System.Drawing.Point(341, 32);
            this.ItdedDateEdRF_tDateEdit.Name = "ItdedDateEdRF_tDateEdit";
            this.ItdedDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ItdedDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ItdedDateEdRF_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.ItdedDateEdRF_tDateEdit.TabIndex = 3;
            this.ItdedDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance39;
            this.ultraLabel10.Location = new System.Drawing.Point(308, 32);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // ItdedDateStRF_tDateEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ItdedDateStRF_tDateEdit.ActiveEditAppearance = appearance40;
            this.ItdedDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ItdedDateStRF_tDateEdit.CalendarDisp = true;
            this.ItdedDateStRF_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.TextHAlignAsString = "Left";
            appearance41.TextVAlignAsString = "Middle";
            this.ItdedDateStRF_tDateEdit.EditAppearance = appearance41;
            this.ItdedDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ItdedDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.ItdedDateStRF_tDateEdit.LabelAppearance = appearance42;
            this.ItdedDateStRF_tDateEdit.Location = new System.Drawing.Point(167, 32);
            this.ItdedDateStRF_tDateEdit.Name = "ItdedDateStRF_tDateEdit";
            this.ItdedDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ItdedDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ItdedDateStRF_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.ItdedDateStRF_tDateEdit.TabIndex = 2;
            this.ItdedDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel8
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance43;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "対象年月";
            // 
            // ultraLabel4
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance44;
            this.ultraLabel4.Location = new System.Drawing.Point(15, 61);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "金額単位";
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.tComboEditor_IssueType);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(18, 309);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(695, 40);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            // 
            // tComboEditor_IssueType
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_IssueType.ActiveAppearance = appearance30;
            this.tComboEditor_IssueType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_IssueType.ItemAppearance = appearance31;
            this.tComboEditor_IssueType.LimitToList = true;
            this.tComboEditor_IssueType.Location = new System.Drawing.Point(166, 7);
            this.tComboEditor_IssueType.Name = "tComboEditor_IssueType";
            this.tComboEditor_IssueType.Size = new System.Drawing.Size(199, 24);
            this.tComboEditor_IssueType.TabIndex = 16;
            this.tComboEditor_IssueType.UseAppStyling = false;
            this.tComboEditor_IssueType.ValueChanged += new System.EventHandler(this.tComboEditor_IssueType_ValueChanged);
            // 
            // ultraLabel3
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance32;
            this.ultraLabel3.Location = new System.Drawing.Point(14, 8);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 39;
            this.ultraLabel3.Text = "発行タイプ";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsMGroup_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsMGroup_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_MediumGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_MediumGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_GoodsMGroup);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T8);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsLGroup_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsLGroup_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_GoodsLGroupGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_GoodsLGroupGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_GoodsLGroup);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T7);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGloupCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGloupCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_DetailGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_DetailGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_BLGloupCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T6);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGoodsCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGoodsCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_BLGoodsCodeGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_BLGoodsCodeGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_BLGoodsCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T5);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesEmployeeCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesEmployeeCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_AreaCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_AreaCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Business);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T4);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AreaCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AreaCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Area);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T3);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_SalesEmp);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Customer);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T1);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 386);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(695, 214);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tNedit_GoodsMGroup_Ed
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance85.TextHAlignAsString = "Left";
            this.tNedit_GoodsMGroup_Ed.ActiveAppearance = appearance85;
            appearance86.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup_Ed.Appearance = appearance86;
            this.tNedit_GoodsMGroup_Ed.AutoSelect = true;
            this.tNedit_GoodsMGroup_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup_Ed.DataText = "";
            this.tNedit_GoodsMGroup_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(320, 189);
            this.tNedit_GoodsMGroup_Ed.MaxLength = 4;
            this.tNedit_GoodsMGroup_Ed.Name = "tNedit_GoodsMGroup_Ed";
            this.tNedit_GoodsMGroup_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsMGroup_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMGroup_Ed.TabIndex = 27;
            // 
            // tNedit_GoodsMGroup_St
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance87.TextHAlignAsString = "Left";
            this.tNedit_GoodsMGroup_St.ActiveAppearance = appearance87;
            appearance88.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup_St.Appearance = appearance88;
            this.tNedit_GoodsMGroup_St.AutoSelect = true;
            this.tNedit_GoodsMGroup_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup_St.DataText = "";
            this.tNedit_GoodsMGroup_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(166, 189);
            this.tNedit_GoodsMGroup_St.MaxLength = 4;
            this.tNedit_GoodsMGroup_St.Name = "tNedit_GoodsMGroup_St";
            this.tNedit_GoodsMGroup_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsMGroup_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMGroup_St.TabIndex = 25;
            // 
            // ub_Ed_MediumGoodsGuide
            // 
            appearance89.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_MediumGoodsGuide.Appearance = appearance89;
            this.ub_Ed_MediumGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_MediumGoodsGuide.Location = new System.Drawing.Point(367, 189);
            this.ub_Ed_MediumGoodsGuide.Name = "ub_Ed_MediumGoodsGuide";
            this.ub_Ed_MediumGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_MediumGoodsGuide.TabIndex = 28;
            this.ub_Ed_MediumGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_MediumGoodsGuide, "商品中分類ガイド");
            this.ub_Ed_MediumGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_MediumGoodsGuide.Click += new System.EventHandler(this.ub_Ed_MediumGoodsGuide_Click);
            // 
            // ub_St_MediumGoodsGuide
            // 
            appearance90.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_MediumGoodsGuide.Appearance = appearance90;
            this.ub_St_MediumGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_MediumGoodsGuide.Location = new System.Drawing.Point(213, 189);
            this.ub_St_MediumGoodsGuide.Name = "ub_St_MediumGoodsGuide";
            this.ub_St_MediumGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_MediumGoodsGuide.TabIndex = 26;
            this.ub_St_MediumGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_MediumGoodsGuide, "商品中分類ガイド");
            this.ub_St_MediumGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_MediumGoodsGuide.Click += new System.EventHandler(this.ub_St_MediumGoodsGuide_Click);
            // 
            // ultraLbK_GoodsMGroup
            // 
            appearance91.TextVAlignAsString = "Middle";
            this.ultraLbK_GoodsMGroup.Appearance = appearance91;
            this.ultraLbK_GoodsMGroup.Location = new System.Drawing.Point(288, 190);
            this.ultraLbK_GoodsMGroup.Name = "ultraLbK_GoodsMGroup";
            this.ultraLbK_GoodsMGroup.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_GoodsMGroup.TabIndex = 115;
            this.ultraLbK_GoodsMGroup.Text = "～";
            // 
            // ultraLabel_T8
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.ultraLabel_T8.Appearance = appearance92;
            this.ultraLabel_T8.Location = new System.Drawing.Point(16, 189);
            this.ultraLabel_T8.Name = "ultraLabel_T8";
            this.ultraLabel_T8.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T8.TabIndex = 114;
            this.ultraLabel_T8.Text = "商品中分類";
            // 
            // tNedit_GoodsLGroup_Ed
            // 
            appearance109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance109.TextHAlignAsString = "Left";
            this.tNedit_GoodsLGroup_Ed.ActiveAppearance = appearance109;
            appearance110.TextHAlignAsString = "Right";
            this.tNedit_GoodsLGroup_Ed.Appearance = appearance110;
            this.tNedit_GoodsLGroup_Ed.AutoSelect = true;
            this.tNedit_GoodsLGroup_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsLGroup_Ed.DataText = "";
            this.tNedit_GoodsLGroup_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsLGroup_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsLGroup_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsLGroup_Ed.Location = new System.Drawing.Point(320, 164);
            this.tNedit_GoodsLGroup_Ed.MaxLength = 4;
            this.tNedit_GoodsLGroup_Ed.Name = "tNedit_GoodsLGroup_Ed";
            this.tNedit_GoodsLGroup_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsLGroup_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsLGroup_Ed.TabIndex = 23;
            // 
            // tNedit_GoodsLGroup_St
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Left";
            this.tNedit_GoodsLGroup_St.ActiveAppearance = appearance111;
            appearance112.TextHAlignAsString = "Right";
            this.tNedit_GoodsLGroup_St.Appearance = appearance112;
            this.tNedit_GoodsLGroup_St.AutoSelect = true;
            this.tNedit_GoodsLGroup_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsLGroup_St.DataText = "";
            this.tNedit_GoodsLGroup_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsLGroup_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsLGroup_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsLGroup_St.Location = new System.Drawing.Point(166, 164);
            this.tNedit_GoodsLGroup_St.MaxLength = 4;
            this.tNedit_GoodsLGroup_St.Name = "tNedit_GoodsLGroup_St";
            this.tNedit_GoodsLGroup_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsLGroup_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsLGroup_St.TabIndex = 21;
            // 
            // ub_Ed_GoodsLGroupGuide
            // 
            appearance113.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_GoodsLGroupGuide.Appearance = appearance113;
            this.ub_Ed_GoodsLGroupGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_GoodsLGroupGuide.Location = new System.Drawing.Point(367, 164);
            this.ub_Ed_GoodsLGroupGuide.Name = "ub_Ed_GoodsLGroupGuide";
            this.ub_Ed_GoodsLGroupGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_GoodsLGroupGuide.TabIndex = 24;
            this.ub_Ed_GoodsLGroupGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_GoodsLGroupGuide, "商品大分類ガイド");
            this.ub_Ed_GoodsLGroupGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_GoodsLGroupGuide.Click += new System.EventHandler(this.ub_Ed_GoodsLGroupGuide_Click);
            // 
            // ub_St_GoodsLGroupGuide
            // 
            appearance114.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_GoodsLGroupGuide.Appearance = appearance114;
            this.ub_St_GoodsLGroupGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_GoodsLGroupGuide.Location = new System.Drawing.Point(213, 164);
            this.ub_St_GoodsLGroupGuide.Name = "ub_St_GoodsLGroupGuide";
            this.ub_St_GoodsLGroupGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_GoodsLGroupGuide.TabIndex = 22;
            this.ub_St_GoodsLGroupGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_GoodsLGroupGuide, "商品大分類ガイド");
            this.ub_St_GoodsLGroupGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_GoodsLGroupGuide.Click += new System.EventHandler(this.ub_St_GoodsLGroupGuide_Click);
            // 
            // ultraLbK_GoodsLGroup
            // 
            appearance115.TextVAlignAsString = "Middle";
            this.ultraLbK_GoodsLGroup.Appearance = appearance115;
            this.ultraLbK_GoodsLGroup.Location = new System.Drawing.Point(288, 165);
            this.ultraLbK_GoodsLGroup.Name = "ultraLbK_GoodsLGroup";
            this.ultraLbK_GoodsLGroup.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_GoodsLGroup.TabIndex = 109;
            this.ultraLbK_GoodsLGroup.Text = "～";
            // 
            // ultraLabel_T7
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.ultraLabel_T7.Appearance = appearance116;
            this.ultraLabel_T7.Location = new System.Drawing.Point(16, 164);
            this.ultraLabel_T7.Name = "ultraLabel_T7";
            this.ultraLabel_T7.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T7.TabIndex = 108;
            this.ultraLabel_T7.Text = "商品大分類";
            // 
            // tNedit_BLGloupCode_Ed
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance45.TextHAlignAsString = "Left";
            this.tNedit_BLGloupCode_Ed.ActiveAppearance = appearance45;
            appearance46.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode_Ed.Appearance = appearance46;
            this.tNedit_BLGloupCode_Ed.AutoSelect = true;
            this.tNedit_BLGloupCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode_Ed.DataText = "";
            this.tNedit_BLGloupCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGloupCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGloupCode_Ed.Location = new System.Drawing.Point(320, 139);
            this.tNedit_BLGloupCode_Ed.MaxLength = 5;
            this.tNedit_BLGloupCode_Ed.Name = "tNedit_BLGloupCode_Ed";
            this.tNedit_BLGloupCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGloupCode_Ed.TabIndex = 31;
            // 
            // tNedit_BLGloupCode_St
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.TextHAlignAsString = "Left";
            this.tNedit_BLGloupCode_St.ActiveAppearance = appearance47;
            appearance48.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode_St.Appearance = appearance48;
            this.tNedit_BLGloupCode_St.AutoSelect = true;
            this.tNedit_BLGloupCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode_St.DataText = "";
            this.tNedit_BLGloupCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGloupCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGloupCode_St.Location = new System.Drawing.Point(166, 139);
            this.tNedit_BLGloupCode_St.MaxLength = 5;
            this.tNedit_BLGloupCode_St.Name = "tNedit_BLGloupCode_St";
            this.tNedit_BLGloupCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGloupCode_St.TabIndex = 29;
            // 
            // ub_Ed_DetailGoodsGuide
            // 
            appearance57.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_DetailGoodsGuide.Appearance = appearance57;
            this.ub_Ed_DetailGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_DetailGoodsGuide.Location = new System.Drawing.Point(375, 139);
            this.ub_Ed_DetailGoodsGuide.Name = "ub_Ed_DetailGoodsGuide";
            this.ub_Ed_DetailGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_DetailGoodsGuide.TabIndex = 32;
            this.ub_Ed_DetailGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_DetailGoodsGuide, "グループコードガイド");
            this.ub_Ed_DetailGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_DetailGoodsGuide.Click += new System.EventHandler(this.ub_Ed_DetailGoodsGuide_Click);
            // 
            // ub_St_DetailGoodsGuide
            // 
            appearance58.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_DetailGoodsGuide.Appearance = appearance58;
            this.ub_St_DetailGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_DetailGoodsGuide.Location = new System.Drawing.Point(221, 139);
            this.ub_St_DetailGoodsGuide.Name = "ub_St_DetailGoodsGuide";
            this.ub_St_DetailGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_DetailGoodsGuide.TabIndex = 30;
            this.ub_St_DetailGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_DetailGoodsGuide, "グループコードガイド");
            this.ub_St_DetailGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_DetailGoodsGuide.Click += new System.EventHandler(this.ub_St_DetailGoodsGuide_Click);
            // 
            // ultraLbK_BLGloupCode
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLbK_BLGloupCode.Appearance = appearance59;
            this.ultraLbK_BLGloupCode.Location = new System.Drawing.Point(288, 140);
            this.ultraLbK_BLGloupCode.Name = "ultraLbK_BLGloupCode";
            this.ultraLbK_BLGloupCode.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_BLGloupCode.TabIndex = 103;
            this.ultraLbK_BLGloupCode.Text = "～";
            // 
            // ultraLabel_T6
            // 
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel_T6.Appearance = appearance60;
            this.ultraLabel_T6.Location = new System.Drawing.Point(16, 139);
            this.ultraLabel_T6.Name = "ultraLabel_T6";
            this.ultraLabel_T6.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T6.TabIndex = 102;
            this.ultraLabel_T6.Text = "グループコード";
            // 
            // tNedit_BLGoodsCode_Ed
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance95.TextHAlignAsString = "Left";
            this.tNedit_BLGoodsCode_Ed.ActiveAppearance = appearance95;
            appearance96.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode_Ed.Appearance = appearance96;
            this.tNedit_BLGoodsCode_Ed.AutoSelect = true;
            this.tNedit_BLGoodsCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode_Ed.DataText = "";
            this.tNedit_BLGoodsCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(320, 114);
            this.tNedit_BLGoodsCode_Ed.MaxLength = 5;
            this.tNedit_BLGoodsCode_Ed.Name = "tNedit_BLGoodsCode_Ed";
            this.tNedit_BLGoodsCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode_Ed.TabIndex = 19;
            // 
            // tNedit_BLGoodsCode_St
            // 
            this.tNedit_BLGoodsCode_St.AcceptsTab = true;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance93.TextHAlignAsString = "Left";
            this.tNedit_BLGoodsCode_St.ActiveAppearance = appearance93;
            appearance94.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode_St.Appearance = appearance94;
            this.tNedit_BLGoodsCode_St.AutoSelect = true;
            this.tNedit_BLGoodsCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode_St.DataText = "";
            this.tNedit_BLGoodsCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(166, 114);
            this.tNedit_BLGoodsCode_St.MaxLength = 5;
            this.tNedit_BLGoodsCode_St.Name = "tNedit_BLGoodsCode_St";
            this.tNedit_BLGoodsCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode_St.TabIndex = 17;
            // 
            // ub_Ed_BLGoodsCodeGuide
            // 
            appearance97.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_BLGoodsCodeGuide.Appearance = appearance97;
            this.ub_Ed_BLGoodsCodeGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_BLGoodsCodeGuide.Location = new System.Drawing.Point(375, 114);
            this.ub_Ed_BLGoodsCodeGuide.Name = "ub_Ed_BLGoodsCodeGuide";
            this.ub_Ed_BLGoodsCodeGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_BLGoodsCodeGuide.TabIndex = 20;
            this.ub_Ed_BLGoodsCodeGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_BLGoodsCodeGuide, "ＢＬコードガイド");
            this.ub_Ed_BLGoodsCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_BLGoodsCodeGuide.Click += new System.EventHandler(this.ub_Ed_BLGoodsCodeGuide_Click);
            // 
            // ub_St_BLGoodsCodeGuide
            // 
            appearance98.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_BLGoodsCodeGuide.Appearance = appearance98;
            this.ub_St_BLGoodsCodeGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_BLGoodsCodeGuide.Location = new System.Drawing.Point(221, 114);
            this.ub_St_BLGoodsCodeGuide.Name = "ub_St_BLGoodsCodeGuide";
            this.ub_St_BLGoodsCodeGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_BLGoodsCodeGuide.TabIndex = 18;
            this.ub_St_BLGoodsCodeGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_BLGoodsCodeGuide, "ＢＬコードガイド");
            this.ub_St_BLGoodsCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_BLGoodsCodeGuide.Click += new System.EventHandler(this.ub_St_BLGoodsCodeGuide_Click);
            // 
            // ultraLbK_BLGoodsCode
            // 
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLbK_BLGoodsCode.Appearance = appearance99;
            this.ultraLbK_BLGoodsCode.Location = new System.Drawing.Point(288, 115);
            this.ultraLbK_BLGoodsCode.Name = "ultraLbK_BLGoodsCode";
            this.ultraLbK_BLGoodsCode.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_BLGoodsCode.TabIndex = 97;
            this.ultraLbK_BLGoodsCode.Text = "～";
            // 
            // ultraLabel_T5
            // 
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel_T5.Appearance = appearance100;
            this.ultraLabel_T5.Location = new System.Drawing.Point(16, 114);
            this.ultraLabel_T5.Name = "ultraLabel_T5";
            this.ultraLabel_T5.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T5.TabIndex = 96;
            this.ultraLabel_T5.Text = "ＢＬコード";
            // 
            // tNedit_BusinessTypeCode_Ed
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance101.TextHAlignAsString = "Left";
            this.tNedit_BusinessTypeCode_Ed.ActiveAppearance = appearance101;
            appearance102.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.Appearance = appearance102;
            this.tNedit_BusinessTypeCode_Ed.AutoSelect = true;
            this.tNedit_BusinessTypeCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_Ed.DataText = "";
            this.tNedit_BusinessTypeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_Ed.Location = new System.Drawing.Point(320, 88);
            this.tNedit_BusinessTypeCode_Ed.MaxLength = 4;
            this.tNedit_BusinessTypeCode_Ed.Name = "tNedit_BusinessTypeCode_Ed";
            this.tNedit_BusinessTypeCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BusinessTypeCode_Ed.TabIndex = 15;
            // 
            // tNedit_BusinessTypeCode_St
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance103.TextHAlignAsString = "Left";
            this.tNedit_BusinessTypeCode_St.ActiveAppearance = appearance103;
            appearance104.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.Appearance = appearance104;
            this.tNedit_BusinessTypeCode_St.AutoSelect = true;
            this.tNedit_BusinessTypeCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_St.DataText = "";
            this.tNedit_BusinessTypeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_St.Location = new System.Drawing.Point(166, 88);
            this.tNedit_BusinessTypeCode_St.MaxLength = 4;
            this.tNedit_BusinessTypeCode_St.Name = "tNedit_BusinessTypeCode_St";
            this.tNedit_BusinessTypeCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BusinessTypeCode_St.TabIndex = 13;
            // 
            // tNedit_SalesEmployeeCd_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SalesEmployeeCd_Ed.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SalesEmployeeCd_Ed.Appearance = appearance50;
            this.tNedit_SalesEmployeeCd_Ed.AutoSelect = true;
            this.tNedit_SalesEmployeeCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesEmployeeCd_Ed.DataText = "";
            this.tNedit_SalesEmployeeCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesEmployeeCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesEmployeeCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesEmployeeCd_Ed.Location = new System.Drawing.Point(320, 32);
            this.tNedit_SalesEmployeeCd_Ed.MaxLength = 4;
            this.tNedit_SalesEmployeeCd_Ed.Name = "tNedit_SalesEmployeeCd_Ed";
            this.tNedit_SalesEmployeeCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesEmployeeCd_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesEmployeeCd_Ed.TabIndex = 7;
            // 
            // tNedit_SalesEmployeeCd_St
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance51.TextHAlignAsString = "Left";
            this.tNedit_SalesEmployeeCd_St.ActiveAppearance = appearance51;
            appearance52.TextHAlignAsString = "Right";
            this.tNedit_SalesEmployeeCd_St.Appearance = appearance52;
            this.tNedit_SalesEmployeeCd_St.AutoSelect = true;
            this.tNedit_SalesEmployeeCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesEmployeeCd_St.DataText = "";
            this.tNedit_SalesEmployeeCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesEmployeeCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesEmployeeCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesEmployeeCd_St.Location = new System.Drawing.Point(166, 32);
            this.tNedit_SalesEmployeeCd_St.MaxLength = 4;
            this.tNedit_SalesEmployeeCd_St.Name = "tNedit_SalesEmployeeCd_St";
            this.tNedit_SalesEmployeeCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesEmployeeCd_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesEmployeeCd_St.TabIndex = 5;
            // 
            // tNedit_AreaCd_Ed
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.TextHAlignAsString = "Left";
            this.tNedit_AreaCd_Ed.ActiveAppearance = appearance53;
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_AreaCd_Ed.Appearance = appearance54;
            this.tNedit_AreaCd_Ed.AutoSelect = true;
            this.tNedit_AreaCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AreaCd_Ed.DataText = "";
            this.tNedit_AreaCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AreaCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AreaCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_AreaCd_Ed.Location = new System.Drawing.Point(320, 60);
            this.tNedit_AreaCd_Ed.MaxLength = 4;
            this.tNedit_AreaCd_Ed.Name = "tNedit_AreaCd_Ed";
            this.tNedit_AreaCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AreaCd_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_AreaCd_Ed.TabIndex = 11;
            // 
            // tNedit_AreaCd_St
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.TextHAlignAsString = "Left";
            this.tNedit_AreaCd_St.ActiveAppearance = appearance55;
            appearance56.TextHAlignAsString = "Right";
            this.tNedit_AreaCd_St.Appearance = appearance56;
            this.tNedit_AreaCd_St.AutoSelect = true;
            this.tNedit_AreaCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AreaCd_St.DataText = "";
            this.tNedit_AreaCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AreaCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AreaCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_AreaCd_St.Location = new System.Drawing.Point(166, 60);
            this.tNedit_AreaCd_St.MaxLength = 4;
            this.tNedit_AreaCd_St.Name = "tNedit_AreaCd_St";
            this.tNedit_AreaCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AreaCd_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_AreaCd_St.TabIndex = 9;
            // 
            // BusinessTypeCdEd_GuideBtn
            // 
            appearance105.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCdEd_GuideBtn.Appearance = appearance105;
            this.BusinessTypeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCdEd_GuideBtn.Location = new System.Drawing.Point(367, 88);
            this.BusinessTypeCdEd_GuideBtn.Name = "BusinessTypeCdEd_GuideBtn";
            this.BusinessTypeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCdEd_GuideBtn.TabIndex = 16;
            this.BusinessTypeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.BusinessTypeCdEd_GuideBtn, "業種ガイド");
            this.BusinessTypeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCdEd_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCdEd_GuideBtn_Click);
            // 
            // BusinessTypeCdSt_GuideBtn
            // 
            appearance106.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCdSt_GuideBtn.Appearance = appearance106;
            this.BusinessTypeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCdSt_GuideBtn.Location = new System.Drawing.Point(213, 88);
            this.BusinessTypeCdSt_GuideBtn.Name = "BusinessTypeCdSt_GuideBtn";
            this.BusinessTypeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCdSt_GuideBtn.TabIndex = 14;
            this.BusinessTypeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.BusinessTypeCdSt_GuideBtn, "業種ガイド");
            this.BusinessTypeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCdSt_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCdSt_GuideBtn_Click);
            // 
            // ultraLbK_Business
            // 
            appearance107.TextVAlignAsString = "Middle";
            this.ultraLbK_Business.Appearance = appearance107;
            this.ultraLbK_Business.Location = new System.Drawing.Point(288, 89);
            this.ultraLbK_Business.Name = "ultraLbK_Business";
            this.ultraLbK_Business.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Business.TabIndex = 74;
            this.ultraLbK_Business.Text = "～";
            // 
            // ultraLabel_T4
            // 
            appearance108.TextVAlignAsString = "Middle";
            this.ultraLabel_T4.Appearance = appearance108;
            this.ultraLabel_T4.Location = new System.Drawing.Point(16, 88);
            this.ultraLabel_T4.Name = "ultraLabel_T4";
            this.ultraLabel_T4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T4.TabIndex = 71;
            this.ultraLabel_T4.Text = "業種";
            // 
            // AreaCdEd_GuideBtn
            // 
            appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.AreaCdEd_GuideBtn.Appearance = appearance61;
            this.AreaCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.AreaCdEd_GuideBtn.Location = new System.Drawing.Point(367, 60);
            this.AreaCdEd_GuideBtn.Name = "AreaCdEd_GuideBtn";
            this.AreaCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.AreaCdEd_GuideBtn.TabIndex = 12;
            this.AreaCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.AreaCdEd_GuideBtn, "地区ガイド");
            this.AreaCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AreaCdEd_GuideBtn.Click += new System.EventHandler(this.AreaCdEd_GuideBtn_Click);
            // 
            // AreaCdSt_GuideBtn
            // 
            appearance62.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.AreaCdSt_GuideBtn.Appearance = appearance62;
            this.AreaCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.AreaCdSt_GuideBtn.Location = new System.Drawing.Point(213, 60);
            this.AreaCdSt_GuideBtn.Name = "AreaCdSt_GuideBtn";
            this.AreaCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.AreaCdSt_GuideBtn.TabIndex = 10;
            this.AreaCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.AreaCdSt_GuideBtn, "地区ガイド");
            this.AreaCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AreaCdSt_GuideBtn.Click += new System.EventHandler(this.AreaCdSt_GuideBtn_Click);
            // 
            // ultraLbK_Area
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLbK_Area.Appearance = appearance63;
            this.ultraLbK_Area.Location = new System.Drawing.Point(288, 61);
            this.ultraLbK_Area.Name = "ultraLbK_Area";
            this.ultraLbK_Area.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Area.TabIndex = 68;
            this.ultraLbK_Area.Text = "～";
            // 
            // ultraLabel_T3
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel_T3.Appearance = appearance64;
            this.ultraLabel_T3.Location = new System.Drawing.Point(16, 60);
            this.ultraLabel_T3.Name = "ultraLabel_T3";
            this.ultraLabel_T3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T3.TabIndex = 66;
            this.ultraLabel_T3.Text = "地区";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance65.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance65;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(367, 32);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 8;
            this.SalesEmployeeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "担当者ガイド");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance66.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance66;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(213, 32);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 6;
            this.SalesEmployeeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "担当者ガイド");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance67.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance67;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(400, 3);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 4;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "得意先検索");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance68.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance68;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 2;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "得意先検索");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // ultraLbK_SalesEmp
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.ultraLbK_SalesEmp.Appearance = appearance69;
            this.ultraLbK_SalesEmp.Location = new System.Drawing.Point(288, 32);
            this.ultraLbK_SalesEmp.Name = "ultraLbK_SalesEmp";
            this.ultraLbK_SalesEmp.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_SalesEmp.TabIndex = 56;
            this.ultraLbK_SalesEmp.Text = "～";
            // 
            // ultraLabel_T2
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel_T2.Appearance = appearance70;
            this.ultraLabel_T2.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel_T2.Name = "ultraLabel_T2";
            this.ultraLabel_T2.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T2.TabIndex = 47;
            this.ultraLabel_T2.Text = "担当者";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance71.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance71;
            appearance72.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance72;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(320, 4);
            this.tNedit_CustomerCode_Ed.MaxLength = 8;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 3;
            // 
            // ultraLbK_Customer
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLbK_Customer.Appearance = appearance73;
            this.ultraLbK_Customer.Location = new System.Drawing.Point(288, 4);
            this.ultraLbK_Customer.Name = "ultraLbK_Customer";
            this.ultraLbK_Customer.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Customer.TabIndex = 19;
            this.ultraLbK_Customer.Text = "～";
            // 
            // tNedit_CustomerCode_St
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance75;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(166, 4);
            this.tNedit_CustomerCode_St.MaxLength = 8;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_St.TabIndex = 1;
            // 
            // ultraLabel_T1
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel_T1.Appearance = appearance76;
            this.ultraLabel_T1.Location = new System.Drawing.Point(16, 4);
            this.ultraLabel_T1.Name = "ultraLabel_T1";
            this.ultraLabel_T1.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T1.TabIndex = 17;
            this.ultraLabel_T1.Text = "得意先";
            // 
            // DCTOK02090UA_Fill_Panel
            // 
            this.DCTOK02090UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.DCTOK02090UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCTOK02090UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.DCTOK02090UA_Fill_Panel.Name = "DCTOK02090UA_Fill_Panel";
            this.DCTOK02090UA_Fill_Panel.Size = new System.Drawing.Size(733, 617);
            this.DCTOK02090UA_Fill_Panel.TabIndex = 0;
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
            appearance77.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance77.FontData.Name = "ＭＳ ゴシック";
            appearance77.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance77;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance78;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 228;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup2.Key = "IssueTypeGroup";
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance83;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 42;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　発行タイプ";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance79;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 216;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance80.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance80.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance80;
            appearance81.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance81;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(2, 3);
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
            appearance82.FontData.SizeInPoints = 20F;
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance82;
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
            // DCTOK02090UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(733, 617);
            this.Controls.Add(this.DCTOK02090UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCTOK02090UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_TotalWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_MoneyUnit)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            this.ultraExplorerBarContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_IssueType)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.DCTOK02090UA_Fill_Panel.ResumeLayout(false);
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
     
		private bool _printButtonEnabled             = true;
		private bool _extraButtonEnabled             = false;
		private bool _pdfButtonEnabled               = true;
		private bool _printButtonVisibled            = true;
		private bool _extraButtonVisibled            = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// 計上拠点選択表示取得

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = true;	//true:チャート出力ボタン表示　false:非表示
		private bool _chartButtonEnabled = true;	//同上
        
        private string _PrevYearCpDataTable;

		private Employee _loginWorker                = null;
		// 自拠点コード
		private string _ownSectionCode               = "";

        private ExtrInfo_DCTOK02093E _chartSaleconfListCndtn = null;

        // 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;

        //TODO ガイド系アクセスクラス
        EmployeeAcs    _employeeAcs;
        UserGuideAcs _userGuideAcs = null;

        // BLコード
        GoodsAcs _goodsAcs;

        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
        BLGroupUAcs _bLGroupUAcs;

        // 商品中分類
        GoodsGroupUAcs _goodsGroupUAcs;

		//自社情報アクセスクラス
		CompanyInfAcs _companyInfAcs;
		CompanyInf _companyInf;

		//日付取得部品
		DateGetAcs _dateGetAcs;

		private PrevYearComparison _prevYearComparison = null;  // 前年対比表アクセスクラス

        private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// 拠点オプション有無
        private bool _isMainOfficeFunc;	// 本社機能有無

		
		// エクスプローラバー拡大基準高さ 
		private Form _topForm = null;


		// 商品チャート抽出クラスメンバ
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_DCTOK02093E _saleConfListCndtnWork = new ExtrInfo_DCTOK02093E();		//条件クラス(前回条件保持用)
		private ExtrInfo_DCTOK02093E _DCTOK02093E = new ExtrInfo_DCTOK02093E();		//条件クラス(チャート引渡し用)
        private DataSet _printBuffDataSet = null;

		// 起動帳票パラメータを入れる変数
		private int _listTypePara;

		// 帳票名称
		private string _printName = "";
		// 帳票キー
		private string _printKey = "";
        
        // 得意先ガイド結果OK
        private bool _customerGuideOK;

        // --- ADD 2008/12/18 [9352] -------------------------------->>>>>
        /// <summary>実績なし印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _ultraOptionSet_TotalWayDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _ultraOptionSet_MoneyUnitDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 集計方法ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>集計方法ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper TotalWayDivRadioKeyPressHelper
        {
            get { return _ultraOptionSet_TotalWayDivRadioKeyPressHelper; }
        }

        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金額単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MoneyUnitDivRadioKeyPressHelper
        {
            get { return _ultraOptionSet_MoneyUnitDivRadioKeyPressHelper; }
        }
        // --- ADD 2008/12/18 [9352] --------------------------------<<<<<
		#endregion
        
		// ===================================================================================== //
		// プライベート定数
		// ===================================================================================== //
		#region private constant

		// アセンブリID
		private const string THIS_ASSEMBLYID = "DCTOK02090U";
		// キー情報
        private const string PRINT_KEY00 = "bedb27bc-b923-476e-8e60-037a5fe9d65a";
        private const string PRINT_KEY01 = "bedb27bc-b923-476e-8e60-037a5fe9d65a";
        private const string PRINT_KEY02 = "8a95f2fe-08bc-43c5-9fcd-b86705b7f949";
        private const string PRINT_KEY03 = "0d64c5d9-0c55-4dba-888c-2961a2b0360d";
        private const string PRINT_KEY04 = "28b33c72-e681-4947-be69-a87998b8ff7b";
        private const string PRINT_KEY05 = "1cbd7a94-d31b-444c-a8b8-a02aee768277";
        private const string PRINT_KEY06 = "089f30d1-c1d4-4616-a83e-e04e336b68d6";

        private const string PRINT_NAME00 = "前年対比表（得意先別）";
        private const string PRINT_NAME01 = "前年対比表（担当者別）";
        private const string PRINT_NAME02 = "前年対比表（受注者別）";
        private const string PRINT_NAME03 = "前年対比表（地区別）";
        private const string PRINT_NAME04 = "前年対比表（業種別）";
        private const string PRINT_NAME05 = "前年対比表（ｸﾞﾙｰﾌﾟｺｰﾄﾞ別）";
        private const string PRINT_NAME06 = "前年対比表（ＢＬｺｰﾄﾞ別）";

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
        {	//フレームから渡ってくる抽出条件
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public void Show(object parameter)
		{
			// 起動パラメータの取得
            this._listTypePara = Convert.ToInt32( parameter );

			#region		起動モード毎の切替
            // 発行タイプのクリア
            this.tComboEditor_IssueType.Items.Clear();
            switch (_listTypePara)
            {
                case 0: // 得意先別
                    this._printName = PRINT_NAME00;
                    this._printKey = PRINT_KEY00;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "得意先別");
                    this.tComboEditor_IssueType.Items.Add(1, "拠点別");
                    this.tComboEditor_IssueType.Items.Add(2, "得意先別拠点別");
                    this.tComboEditor_IssueType.Items.Add(3, "管理拠点別");
                    this.tComboEditor_IssueType.Items.Add(4, "請求先別");
                    break;
                case 1: // 担当者別
                    this._printName = PRINT_NAME01;
                    this._printKey = PRINT_KEY01;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "担当者別");
                    this.tComboEditor_IssueType.Items.Add(1, "得意先別");
                    this.tComboEditor_IssueType.Items.Add(2, "担当者別拠点別");
                    this.tComboEditor_IssueType.Items.Add(3, "管理拠点別");
                    break;
                case 2: // 受注者別
                    this._printName = PRINT_NAME02;
                    this._printKey = PRINT_KEY02;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "受注者別");
                    this.tComboEditor_IssueType.Items.Add(1, "得意先別");
                    this.tComboEditor_IssueType.Items.Add(2, "受注者別拠点別");
                    this.tComboEditor_IssueType.Items.Add(3, "管理拠点別");
                    break;
                case 3: // 地区別
                    this._printName = PRINT_NAME03;
                    this._printKey = PRINT_KEY03;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "地区別");
                    this.tComboEditor_IssueType.Items.Add(1, "得意先別");
                    this.tComboEditor_IssueType.Items.Add(2, "地区別拠点別");
                    this.tComboEditor_IssueType.Items.Add(3, "管理拠点別");
                    break;
                case 4: // 業種別
                    this._printName = PRINT_NAME04;
                    this._printKey = PRINT_KEY04;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "業種別");
                    this.tComboEditor_IssueType.Items.Add(1, "得意先別");
                    this.tComboEditor_IssueType.Items.Add(2, "業種別拠点別");
                    this.tComboEditor_IssueType.Items.Add(3, "管理拠点別");
                    break;
                case 5: // グループコード別
                    this._printName = PRINT_NAME05;
                    this._printKey = PRINT_KEY05;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "グループコード別");
                    this.tComboEditor_IssueType.Items.Add(1, "商品中分類別");
                    this.tComboEditor_IssueType.Items.Add(2, "商品大分類別");
                    break;
                case 6: // ＢＬコード別
                    this._printName = PRINT_NAME06;
                    this._printKey = PRINT_KEY06;

                    // 発行タイプ設定
                    this.tComboEditor_IssueType.Items.Add(0, "ＢＬコード別");
                    this.tComboEditor_IssueType.Items.Add(1, "ＢＬコード別得意先別");
                    this.tComboEditor_IssueType.Items.Add(2, "ＢＬコード別担当者別");
                    break;
            }
            // 発行タイプの初期値
            this.tComboEditor_IssueType.Value = 0;

            this.ultraExplorerBarContainerControl1.Height = 123;
            // 表示コントロール制御処理
            SetControl();
			#endregion

			this.Show();
        }
		
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public int Print(ref object parameter)
		{
		            
			SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // 印刷情報パラメータ
		
			// 企業コード
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // 起動ＰＧＩＤ
			printInfo.key			 = this._printKey;              // PDF履歴管理用KEY情報

			// 画面→抽出条件クラス
            ExtrInfo_DCTOK02093E _extrInfo_DCTOK02093E = new ExtrInfo_DCTOK02093E();
            this.SetExtraInfoFromScreen(ref _extrInfo_DCTOK02093E);
		            
			// 抽出条件の設定
            printInfo.jyoken = _extrInfo_DCTOK02093E;
            
			// 印刷帳票設定		※Uクラスは一つで出力する帳票を分けるプログラムの場合必要
			//（画面が持っているparameterをprintInfoに渡す。printInfo：印刷情報を持つ）
            printInfo.PrintPaperSetCd = this._listTypePara;
                        
            this._saleConfListCndtnWork = _extrInfo_DCTOK02093E;

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
		/// <br>Note       : 印刷前のチェック処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Note       : 抽出処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public int Extract(ref object parameter)
		{
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            if (parameter.ToString().Equals("0"))   // チャートの場合のみ、データ検索を行う
            {

                ExtrInfo_DCTOK02093E extraInfo = new ExtrInfo_DCTOK02093E();     // 抽出条件クラス

                this.SetExtraInfoFromScreen(ref extraInfo);

                int i = _DCTOK02093E.ListType;

                //TODO チャート用条件設定
                _chartSaleconfListCndtn = extraInfo;

                int h = extraInfo.ListType;

                int j = _DCTOK02093E.ListType;

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
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
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
		/// チャートデータの抽出チェック
		/// </summary>
		public bool CheckBefore()
        {
            // チャートデータの抽出チェックを行います。
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
				int i = _DCTOK02093E.ListType;

				string message;
				Control errControl = null;

				// 画面入力条件チェック
				bool result = this.ChartInputCheack(out message, ref errControl);
				if (result == false)
				{
					TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
					if (errControl != null) errControl.Focus();

					chartExtractMemberList = null;

					return 9;
				}

                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();

					//チャートクラスに渡る箇所
					//複数のグラフを表示する
					AgentOrderChart chartExtrac1 = new AgentOrderChart(0, this._listTypePara);
					this._iChartExtractList.Add(chartExtrac1);


					AgentOrderChart chartExtrac2 = new AgentOrderChart(1, this._listTypePara);
					this._iChartExtractList.Add(chartExtrac2);

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
          System.Windows.Forms.Application.Run(new DCTOK02090UA());
        }
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private methods 
        /// <summary>
        /// 初期画面設定
        /// </summary>
        private void InitialScreenSetting()
        {
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);


            // 日付範囲
                // 日次
			this.ItdedDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M;
			this.ItdedDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M;
			this.ItdedDateStRF_tDateEdit.SetLongDate(this._companyInf.CompanyBiginDate);
            //this.ItdedDateEdRF_tDateEdit.SetLongDate(nowLongDate);                                                    //DEL 2009/03/05 不具合対応[12187]
            this.ItdedDateEdRF_tDateEdit.SetDateTime(this.ItdedDateStRF_tDateEdit.GetDateTime().AddMonths(11));         //ADD 2009/03/05 不具合対応[12187]

            			
			//印刷タイプ
            this.tComboEditor_PrintType.SelectedIndex = 0;

            // ガイドボタンイメージ設定
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			AreaCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			AreaCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			AreaCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			AreaCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			BusinessTypeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			BusinessTypeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			BusinessTypeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			BusinessTypeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            ub_St_BLGoodsCodeGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_BLGoodsCodeGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_BLGoodsCodeGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_BLGoodsCodeGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_DetailGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_DetailGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_DetailGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_DetailGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_GoodsLGroupGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_GoodsLGroupGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_GoodsLGroupGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_GoodsLGroupGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_MediumGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_MediumGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_MediumGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_MediumGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            
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
			Enum _checkD = this._dateGetAcs.CheckDate(ref control, false);

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
		/// 同一年度チェック処理（自社締め）
		/// </summary>
        /// <param name="startYearMonth"></param>
        /// <param name="endYearMonth"></param>
		/// <returns>true:チェックOK,false:チェックNG</returns>
		/// <remarks>
		/// <br>Note: 共通部品による同一年度（自社締め）のチェックを行います。</br>
		/// </remarks>
		private bool CheckMonthsOnYear(DateTime startYearMonth, DateTime endYearMonth)
		{
			bool _checkMOY = this._dateGetAcs.CheckMonthsOnYear(startYearMonth, endYearMonth);

			return _checkMOY;

		}

		/// <summary>
		/// 日付範囲チェック処理
		/// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="msg"></param>
		/// <returns>true:チェックOK,false:チェックNG</returns>
		/// <remarks>
		/// <br>Note: 共通部品による日付範囲のチェックを行います。</br>
		/// </remarks>
        //private bool CheckPeriod(DateTime startDate, DateTime endDate) // DEL 2009/02/24
        private bool CheckPeriod(DateTime startDate, DateTime endDate, out string msg) // ADD 2009/02/24
		{
            msg = string.Empty; // ADD 2009/02/24
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 12, DateGetAcs.YmdType.YearMonth, startDate, endDate);

			string str_cP = _checkP.ToString();

            // --- ADD 2009/02/24 -------------------------------->>>>>
            if (str_cP == "ErrorOfReverse")
            {
                msg = "対象年月の範囲に誤りがあります";
            }
            else if (str_cP == "ErrorOfRangeOver")
            {
                msg = "対象年月の範囲は12ヶ月以内にして下さい";
            }
            // --- ADD 2009/02/24 --------------------------------<<<<<

			if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
        /// 画面入力チェック処理
        /// </summary>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

		//出力条件
			// 対象年月(開始)
			if (!CheckDate(this.ItdedDateStRF_tDateEdit))
			{
				message = "対象年月の指定に誤りがあります";
				errControl = this.ItdedDateStRF_tDateEdit;
				return result;
			}

			// 対象年月(終了)
			if (!CheckDate(this.ItdedDateEdRF_tDateEdit))
			{
				message = "対象年月の指定に誤りがあります";
				errControl = this.ItdedDateEdRF_tDateEdit;
				return result;
			}

			DateTime dt_st_SalesDate = DateTime.ParseExact(this.ItdedDateStRF_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
			DateTime dt_ed_SalesDate = DateTime.ParseExact(this.ItdedDateEdRF_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            // --- DEL 2009/02/24 -------------------------------->>>>>
            //// 対象年月 同一年度チェック処理（自社締め）
            //if (!CheckMonthsOnYear(dt_st_SalesDate, dt_ed_SalesDate))
            //{
            //    message = "対象年月の範囲は同一年度内の12ヶ月にして下さい";
            //    errControl = this.ItdedDateEdRF_tDateEdit;
            //    return result;
            //}
            // --- DEL 2009/02/24 --------------------------------<<<<<

			// 計上日付範囲チェック
            //if (!CheckPeriod(dt_st_SalesDate, dt_ed_SalesDate)) // DEL 2009/02/24
            if (!CheckPeriod(dt_st_SalesDate, dt_ed_SalesDate, out message)) // ADD 2009/02/24
			{
                //message = "対象年月の範囲に誤りがあります"; // DEL 2009/02/24
				errControl = this.ItdedDateStRF_tDateEdit;
				return result;
			}

            // ADD 2008/12/18 不具合対応[9353] ---------->>>>>
            if (this.TmTotalCostHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmTotalCostLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmTotalCostHigh_Nedit.GetInt() > this.TmTotalCostLow_Nedit.GetInt())
            {
                message = "当月純売上の範囲に誤りがあります";
                errControl = this.TmTotalCostHigh_Nedit;
                return result;
            }

            if (this.TyTotalCostHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyTotalCostLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyTotalCostHigh_Nedit.GetInt() > this.TyTotalCostLow_Nedit.GetInt())
            {
                message = "当年純売上の範囲に誤りがあります";
                errControl = this.TyTotalCostHigh_Nedit;
                return result;
            }

            if (this.TmGrsMarginHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmGrsMarginLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmGrsMarginHigh_Nedit.GetInt() > this.TmGrsMarginLow_Nedit.GetInt())
            {
                message = "当月粗利の範囲に誤りがあります";
                errControl = this.TmGrsMarginHigh_Nedit;
                return result;
            }

            if (this.TyGrsMarginHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyGrsMarginLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyGrsMarginHigh_Nedit.GetInt() > this.TyGrsMarginLow_Nedit.GetInt())
            {
                message = "当年粗利の範囲に誤りがあります";
                errControl = this.TyGrsMarginHigh_Nedit;
                return result;
            }
            // ADD 2008/12/18 不具合対応[9353] ----------<<<<<

		//抽出条件
            // 得意先コード範囲チェック
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                message = "得意先の範囲に誤りがあります";
                errControl = this.tNedit_CustomerCode_Ed;
                return result;
            }

			// 担当者コード範囲チェック
			if ((this.tNedit_SalesEmployeeCd_Ed.Text != "") &&
                (this.tNedit_SalesEmployeeCd_St.Text.Trim().PadLeft(4, '0').CompareTo(this.tNedit_SalesEmployeeCd_Ed.Text.Trim().PadLeft(4, '0')) > 0))
			{
				message = "担当者の範囲に誤りがあります";
				errControl = this.tNedit_SalesEmployeeCd_St;
				return result;
			}

			// 地区コード範囲チェック
			if ((this.tNedit_AreaCd_Ed.Text != "") &&
                (this.tNedit_AreaCd_St.Text.Trim().PadLeft(4, '0').CompareTo(this.tNedit_AreaCd_Ed.Text.Trim().PadLeft(4, '0')) > 0))
			{
				message = "地区の範囲に誤りがあります";
				errControl = this.tNedit_AreaCd_St;
				return result;
			}

			// 業種コード範囲チェック
			if ((this.tNedit_BusinessTypeCode_Ed.Text != "") &&
				(this.tNedit_BusinessTypeCode_St.Text.CompareTo(this.tNedit_BusinessTypeCode_Ed.Text) > 0))
			{
				message = "業種の範囲に誤りがあります";
				errControl = this.tNedit_BusinessTypeCode_St;
				return result;
			}

            // BLコード範囲チェック
            if ((this.tNedit_BLGoodsCode_Ed.Text != "") &&
                (this.tNedit_BLGoodsCode_St.Text.CompareTo(this.tNedit_BLGoodsCode_Ed.Text) > 0))
            {
                message = "ＢＬコードの範囲に誤りがあります";
                errControl = this.tNedit_BLGoodsCode_St;
                return result;
            }

            // 商品大分類範囲チェック
            if ((this.tNedit_GoodsLGroup_Ed.Text != "") &&
                (this.tNedit_GoodsLGroup_St.Text.CompareTo(this.tNedit_GoodsLGroup_Ed.Text) > 0))
            {
                message = "商品大分類の範囲に誤りがあります";
                errControl = this.tNedit_GoodsLGroup_St;
                return result;
            }

            // 商品中分類範囲チェック
            if ((this.tNedit_GoodsMGroup_Ed.Text != "") &&
                (this.tNedit_GoodsMGroup_St.Text.CompareTo(this.tNedit_GoodsMGroup_Ed.Text) > 0))
            {
                message = "商品中分類の範囲に誤りがあります";
                errControl = this.tNedit_GoodsMGroup_St;
                return result;
            }

            // グループコード範囲チェック
            if ((this.tNedit_BLGloupCode_Ed.Text != "") &&
                (this.tNedit_BLGloupCode_St.Text.CompareTo(this.tNedit_BLGloupCode_Ed.Text) > 0))
            {
                message = "グループコードの範囲に誤りがあります";
                errControl = this.tNedit_BLGloupCode_St;
                return result;
            }
            return true;    
        }

		/// <summary>
		/// チャート用画面入力チェック処理
		/// </summary>
		private bool ChartInputCheack(out string message, ref Control errControl)
		{
			message = "";
			bool result = false;
			errControl = null;
                        
            // 拠点内容チェック
            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
            {
                message = "グラフ出力の場合、拠点は対象が1つになるよう絞ってください";
                return result;
            }
			return true;
		}

        /// <summary>
        /// データ抽出
        /// </summary>
        /// <param name="extraInfo">抽出条件クラス</param>
        /// <returns></returns>
        private int SearchData(ExtrInfo_DCTOK02093E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件が変わっているならリモーティング
            if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
            {
                try
                {
                    status = this._prevYearComparison.Search(extraInfo, out message, 0);
                    if (status == 0)
                    {
                        this._printBuffDataSet = this._prevYearComparison._printDataSet;
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
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count == 0)
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;


        }

#if false
		private bool InputDateEditCheack(TDateEdit control)
		{
			int yy = control.GetDateYear();
			int mm = control.GetDateMonth();

			if ((DateTime.MinValue.Year > yy) || (yy > DateTime.MaxValue.Year))
			{
            return false;
        }

		if ((DateTime.MinValue.Month > mm) || (mm > DateTime.MaxValue.Month))
		{
            return false;
        }

        return true;
    }
#endif

#if false
		private bool InputDateEditCheack(TDateEdit control)
        {

			// 日付を数値型で取得
			int date = control.GetLongDate();	//GetLongDate：年月日の形で日付を取得する
			int yy   = date / 10000;  
			int mm   = date / 100 % 100;
			int dd   = date % 100;  

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;
            	
            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
			  // 年・月・日表示時
			case emDateFormat.dfG2Y2M2D:
			case emDateFormat.df4Y2M2D :
			case emDateFormat.df2Y2M2D :
			  if (yy == 0 || mm == 0 || dd == 0) return false;
			  break;
              // 年・月    表示時
            case emDateFormat.dfG2Y2M  :
            case emDateFormat.df4Y2M   :
            case emDateFormat.df2Y2M   :
              if (yy == 0 || mm == 0) return false;
              break;
              // 年        表示時
            case emDateFormat.dfG2Y    :
            case emDateFormat.df4Y     :
            case emDateFormat.df2Y     :
              if (yy == 0) return false;
              break;
			  // 月・日　　表示時
			case emDateFormat.df2M2D   :
			  if (mm == 0 || dd == 0) return false;
			  break;
               月        表示時
            case emDateFormat.df2M     :
              if (mm == 0) return false;
              break;
			  // 日        表示時
			case emDateFormat.df2D     :
			  if (dd == 0) return false;
			  break;
            }
   
            07.11.30↓年月日の妥当性チェック。月日の妥当性チェックのやり方が分からないので仮コメントアウト  
            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD",date);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

			return true;           
        }
#endif

		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面→抽出条件へ設定します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void SetExtraInfoFromScreen(ref ExtrInfo_DCTOK02093E extraInfo)
        {
            // 企業コード
            extraInfo.EnterpriseCode = this._enterpriseCode;
            // 選択拠点
            // 拠点オプションありのとき
			if (IsOptSection)
			{
				ArrayList secList = new ArrayList();
				ArrayList secNameList = new ArrayList();
				SortedList secInfoList = new SortedList();

				// 全社選択かどうか
				if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
				{
					extraInfo.SecCodeList = null;	//全社
				}
				else
				{
					foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
					{
						secInfoList.Add(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm.Trim());
					}

					foreach (DictionaryEntry dicEntry in this._selectedhSectinTable)
					{
						if ((CheckState)dicEntry.Value == CheckState.Checked)
						{
							secList.Add(dicEntry.Key);
							secNameList.Add(secInfoList[dicEntry.Key]);
						}
					}
					extraInfo.SecCodeList = (string[])secList.ToArray(typeof(string));

				}
			}
			// 拠点オプションなしの時
			else
			{
				extraInfo.SecCodeList = null;	//全社

			}

			// 集計方法
            if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                extraInfo.TotalWay = 0;
            }
            else
            {
                extraInfo.TotalWay = 1;
            }

			// 対象年月(開始)	yyyymmdd形式で取得した対象年月をyyyymmに削って抽出条件に渡す
			string st_AddUpYearMonth = Convert.ToString(this.ItdedDateStRF_tDateEdit.GetLongDate());
			st_AddUpYearMonth = st_AddUpYearMonth.Remove(6, 2);						// 6 文字目の後から 2 文字を削除する
			extraInfo.St_AddUpYearMonth = Convert.ToInt32(st_AddUpYearMonth);
			
			// 対象年月(終了)        
			string ed_AddUpYearMonth = Convert.ToString(this.ItdedDateEdRF_tDateEdit.GetLongDate());
			ed_AddUpYearMonth = ed_AddUpYearMonth.Remove(6, 2);// 6 文字目の後から 2 文字を削除する
			extraInfo.Ed_AddUpYearMonth = Convert.ToInt32(ed_AddUpYearMonth);

			// 金額単位
			extraInfo.MoneyUnit = (int)this.ultraOptionSet_MoneyUnit.CheckedItem.DataValue;

			// 印刷タイプ
			extraInfo.PrintType =(int)this.tComboEditor_PrintType.SelectedItem.DataValue;

			// 改頁
			if (this.checkBox_NewPage.Checked)
			{
				extraInfo.NewPage = true;
			}
			else
			{
				extraInfo.NewPage = false;
			}

            // 改頁2
            if (this.checkBox_NewPage2.Checked)
            {
                extraInfo.NewPage2 = true;
            }
            else
            {
                extraInfo.NewPage2 = false;
            }
            // ---ADD 2009/01/30 不具合対応[9841] ---------------------------->>>>>
            if (this.checkBox_NewPage.Visible == false)
            {
                extraInfo.NewPage = false;
            }
            if (this.checkBox_NewPage2.Visible == false)
            {
                extraInfo.NewPage2 = false;
            }
            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------<<<<<

			// 出力方法（帳票タイプ）
			extraInfo.ListType = this._listTypePara;

			//当月純売上
            if (TmTotalCostHigh_Nedit.Value == null)
            {
                extraInfo.St_MonthSalesRatio = -99999;
                extraInfo.St_MonthSalesRatio_ck = false;
            }
            else
            {
                extraInfo.St_MonthSalesRatio = TmTotalCostHigh_Nedit.GetInt();
                extraInfo.St_MonthSalesRatio_ck = true;
            }
            if (TmTotalCostLow_Nedit.Value == null)
            {
                extraInfo.Ed_MonthSalesRatio = 99999;
                extraInfo.Ed_MonthSalesRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_MonthSalesRatio = TmTotalCostLow_Nedit.GetInt();
                extraInfo.Ed_MonthSalesRatio_ck = true;
            }
			//当年純売上
            if (TyTotalCostHigh_Nedit.Value == null)
            {
                extraInfo.St_YearSalesRatio = -99999;
                extraInfo.St_YearSalesRatio_ck = false;
            }
            else
            {
                extraInfo.St_YearSalesRatio = TyTotalCostHigh_Nedit.GetInt();
                extraInfo.St_YearSalesRatio_ck = true;
            }
            if (TyTotalCostLow_Nedit.Value == null)
            {
                extraInfo.Ed_YearSalesRatio = 99999;
                extraInfo.Ed_YearSalesRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_YearSalesRatio = TyTotalCostLow_Nedit.GetInt();
                extraInfo.Ed_YearSalesRatio_ck = true;
            }
			//当月粗利
            if (TmGrsMarginHigh_Nedit.Value == null)
            {
                extraInfo.St_MonthGrossRatio = -99999;
                extraInfo.St_MonthGrossRatio_ck = false;
            }
            else
            {
                extraInfo.St_MonthGrossRatio = TmGrsMarginHigh_Nedit.GetInt();
                extraInfo.St_MonthGrossRatio_ck = true;
            }
            if (TmGrsMarginLow_Nedit.Value == null)
            {
                extraInfo.Ed_MonthGrossRatio = 99999;
                extraInfo.Ed_MonthGrossRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_MonthGrossRatio = TmGrsMarginLow_Nedit.GetInt();
                extraInfo.Ed_MonthGrossRatio_ck = true;
            }
			//当年粗利
            if (TyGrsMarginHigh_Nedit.Value == null)
            {
                extraInfo.St_YearGrossRatio = -99999;
                extraInfo.St_YearGrossRatio_ck = false;
            }
            else
            {
                extraInfo.St_YearGrossRatio = TyGrsMarginHigh_Nedit.GetInt();
                extraInfo.St_YearGrossRatio_ck = true;
            }
            if (TyGrsMarginLow_Nedit.Value == null)
            {
                extraInfo.Ed_YearGrossRatio = 99999;
                extraInfo.Ed_YearGrossRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_YearGrossRatio = TyGrsMarginLow_Nedit.GetInt();
                extraInfo.Ed_YearGrossRatio_ck = true;
            }

			// 得意先(開始)
            extraInfo.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
            // 得意先(終了)
            extraInfo.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

			// 担当者コード(開始)
			extraInfo.St_EmployeeCode = this.tNedit_SalesEmployeeCd_St.Text;
			// 担当者コード(終了)
			extraInfo.Ed_EmployeeCode = this.tNedit_SalesEmployeeCd_Ed.Text;

			// 地区コード(開始)
			extraInfo.St_SalesAreaCode = this.tNedit_AreaCd_St.GetInt();
			// 地区コード(終了)
			extraInfo.Ed_SalesAreaCode = this.tNedit_AreaCd_Ed.GetInt();

			// 業種コード(開始)
			extraInfo.St_BusinessTypeCode = this.tNedit_BusinessTypeCode_St.GetInt();
			// 業種コード(終了)
			extraInfo.Ed_BusinessTypeCode = this.tNedit_BusinessTypeCode_Ed.GetInt();

            // BLコード（開始）
            extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
            // BLコード（終了）
            extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();

            // 商品大分類コード（開始）
            extraInfo.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
            // 商品大分類コード（終了）
            extraInfo.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();

            // 商品中分類コード（開始）
            extraInfo.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
            // 商品中分類コード（終了）
            extraInfo.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();

            // グループコード（開始）
            extraInfo.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
            // グループコード（終了）
            extraInfo.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
            
            // 発行タイプ
            extraInfo.IssueType = (int)this.tComboEditor_IssueType.SelectedItem.DataValue;
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            _PrevYearCpDataTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
        }

        /// <summary>
        /// 最上位フォーム取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
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
		    if (this._topForm == null) return;

		    if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
		    {
			    // トップフォームの高さが基準値より高い場合
                //this._explorerBarExpanding = true;
			    try
			    {
                    //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
			    }
			    finally
			    {
                    //this._explorerBarExpanding = false;
			    }
		    }
		    else
		    {
			    // トップフォームの高さが基準値より低い場合
                //this._explorerBarExpanding = true;
			    try
			    {
                    //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
			    }
			    finally
			    {
                    //this._explorerBarExpanding = false;
			    }
		    }
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
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
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
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void SFUKK01390UA_Load(object sender, System.EventArgs e)
        {

            this.SettingDataTable();

			this._prevYearComparison = new PrevYearComparison();

            // 最上位フォーム取得
		    this.GetTopForm();

            // 拠点オプション有無を取得する
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 本社/拠点情報を取得する
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

		    this.Initial_Timer.Enabled = true;

            // --- ADD 2008/12/18 [9352] -------------------------------->>>>>
            TotalWayDivRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_TotalWay);
            TotalWayDivRadioKeyPressHelper.StartSpaceKeyControl();

            MoneyUnitDivRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_MoneyUnit);
            MoneyUnitDivRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2008/12/18 [9352] --------------------------------<<<<<
        }

        /// <summary>
        /// 画面アクティブイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 元帳メイン画面がアクティブになったときのイベント処理です。</br>
        /// <br>Programer  : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
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
        }

        /// <summary>
        /// 初期タイマーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 初期処理を行います。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面初期表示
            this.InitialScreenSetting();
        
            // 初期フォーカス設定
            this.ItdedDateStRF_tDateEdit.Focus();

    	    // メインフレームにツールバー設定通知
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
	    }
		    	        
		
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
		/// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.11.25</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup") ||
                (e.Group.Key == "IssueTypeGroup"))
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.11.25</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup") ||
                (e.Group.Key == "IssueTypeGroup"))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}
		}

        /// <summary>
        /// 集計方法の切り替え時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraOptionSet_TotalWay_ValueChanged(object sender, EventArgs e)
        {
            bool bl_ck = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    if ((int)this.tComboEditor_IssueType.Value == 1)
                    {
                        bl_ck = true;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        bl_ck = true;
                    }       
                    break;
                case 5:
                    // 条件なし
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (this.ultraOptionSet_TotalWay.CheckedItem != null)
            {
                if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue ||
                    bl_ck)
                {
                    if (this._listTypePara == 0 &&
                        (int)this.tComboEditor_IssueType.Value == 2)
                    {
                        this.checkBox_NewPage.Checked = true;
                        this.checkBox_NewPage.Enabled = true;
                    }
                    else
                    {
                        if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                        {
                            bl_Checked = false;
                        }
                        this.checkBox_NewPage.Checked = bl_Checked;
                        this.checkBox_NewPage.Enabled = false;
                    }
                }
                else
                {
                    this.checkBox_NewPage.Checked = true;
                    this.checkBox_NewPage.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 発行タイプ切り替え時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_IssueType_ValueChanged(object sender, EventArgs e)
        {
            bool bl_ck = false;
            bool bl_ck2 = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        this.checkBox_NewPage.Text = "得意先毎で改頁";
                    }
                    else
                    {
                        this.checkBox_NewPage.Text = "拠点毎で改頁";
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1)
                    {
                        bl_ck = true;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 0 ||
                        (int)this.tComboEditor_IssueType.Value == 3)
                    {
                        bl_ck2 = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        bl_ck = true;
                    }      
                    break;
                case 5:
                    // 条件なし
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 0)
                    {
                        bl_ck2 = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (bl_ck ||
               (bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                if (this._listTypePara == 0 &&
                    (int)this.tComboEditor_IssueType.Value == 2)
                {
                    this.checkBox_NewPage.Checked = true;
                    this.checkBox_NewPage.Enabled = true;
                }
                else
                {
                    if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                    {
                        bl_Checked = false;
                    }
                    this.checkBox_NewPage.Checked = bl_Checked;
                    this.checkBox_NewPage.Enabled = false;
                }

            }
            else
            {
                this.checkBox_NewPage.Checked = true;
                this.checkBox_NewPage.Enabled = true;
            }

            if (bl_ck2)
            {
                this.checkBox_NewPage2.Checked = false;
                this.checkBox_NewPage2.Enabled = false;
            }
            else
            {
                this.checkBox_NewPage2.Checked = true;
                this.checkBox_NewPage2.Enabled = true;
            }
        }


        /// <summary>
        /// 改頁条件２切り替え時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_NewPage2_CheckedChanged(object sender, EventArgs e)
        {
            // ---ADD 2009/01/30 不具合対応[9828] ---------------------------->>>>>
            // 前年対比表(担当者別)、前年対比表(受注者別)
            // 前年対比表(地区別)、前年対比表(業種別)
            if ((this._listTypePara == 1) || (this._listTypePara == 2) ||
                (this._listTypePara == 3) || (this._listTypePara == 4))
            {
                // 発行タイプが「○○別拠点別」の場合
                if ((int)this.tComboEditor_IssueType.Value == 2)
                {
                    this.checkBox_NewPage.Checked = false;
                    this.checkBox_NewPage.Enabled = false;
                    return;
                }
            }
            // ---ADD 2009/01/30 不具合対応[9828] ----------------------------<<<<<

            bool bl_ck = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    // 改頁２不使用
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
                case 5:
                    // 改頁２不使用
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (bl_ck ||
               (bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                {
                    bl_Checked = false;
                }
                this.checkBox_NewPage.Checked = bl_Checked;
                this.checkBox_NewPage.Enabled = false;
            }
            else
            {
                this.checkBox_NewPage.Checked = true;
                this.checkBox_NewPage.Enabled = true;
            }
        }
	    #endregion
        
	    #region IPrintConditionInpTypeChart メンバ


	    #endregion

	    #region IPrintConditionInpTypeSelectedSection メンバ

		/// <summary>
		/// 『出力対象拠点』の動作処理
		/// </summary>
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
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
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
        /// <br>Note       : 拠点オプション取得プロパティ</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
        /// <br>Note       : 本社機能取得プロパティ</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
        /// <br>Note       : 計上拠点選択処理</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
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
        /// <br>Note       : 選択されている計上拠点を設定します</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
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
                _customerGuideOK = true;
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
                _customerGuideOK = true;
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

            _customerGuideOK = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
        }
        

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                switch (this._listTypePara)
                {
                    case 0: // 得意先別
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                    case 1: // 担当者別
                    case 2: // 受注者別
                    case 6: // ＢＬコード別
                        this.tNedit_SalesEmployeeCd_St.Focus();
                        break;
                    case 3: // 地区別
                        this.tNedit_AreaCd_St.Focus();
                        break;
                    case 4: // 業種別
                        this.tNedit_BusinessTypeCode_St.Focus();
                        break;
                    case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                        break;
                }
            }
        }

        /// <summary>
        /// 担当者コード(開始)ガイド起動ボタン起動イベント
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
                this.tNedit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                this.tNedit_SalesEmployeeCd_Ed.Focus();
            }
        }

        /// <summary>
		/// 担当者コード(終了)ガイド起動ボタン起動イベント
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
                this.tNedit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                switch (this._listTypePara)
                {
                    case 0: // 得意先別
                    case 3: // 地区別
                    case 4: // 業種別
                    case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                        break;
                    case 1: // 担当者別
                    case 2: // 受注者別
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                    case 6: // ＢＬコード別
                        this.tNedit_BLGoodsCode_St.Focus();
                        break;                   
                }
            }
        }

		/// <summary>
        /// 地区別コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
		private void AreaCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
				tNedit_AreaCd_St.SetInt(userGdBd.GuideCode);
                this.tNedit_AreaCd_Ed.Focus();
			}
		}

		/// <summary>
		/// 地区コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
		private void AreaCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
				tNedit_AreaCd_Ed.SetInt(userGdBd.GuideCode);
                switch (this._listTypePara)
                {
                    case 0: // 得意先別
                    case 1: // 担当者別
                    case 2: // 受注者別
                    case 4: // 業種別
                    case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                    case 6: // ＢＬコード別
                        break;
                    case 3: // 地区別
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                }
			}
		}


		/// <summary>
		/// 業種コード(開始)ガイド起動ボタン起動イベント
		/// </summary>
		private void BusinessTypeCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            if (status == 0)
            {
				tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                this.tNedit_BusinessTypeCode_Ed.Focus();
			}
		}

		/// <summary>
		/// 業種コード(終了)ガイド起動ボタン起動イベント
		/// </summary>
		private void BusinessTypeCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            if (status == 0)
            {
				tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
                switch (this._listTypePara)
                {
                    case 0: // 得意先別
                    case 1: // 担当者別
                    case 2: // 受注者別
                    case 3: // 地区別
                    case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                    case 6: // ＢＬコード別
                        break;
                    case 4: // 業種別
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                }
			}
		}

        /// <summary>
        /// BLコード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            if (status != 0) return;

            tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
            this.tNedit_BLGoodsCode_Ed.Focus();
        }

        /// <summary>
        /// BLコード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            if (status != 0) return;

            tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
            switch (this._listTypePara)
            {
                case 0: // 得意先別
                case 1: // 担当者別
                case 2: // 受注者別
                case 3: // 地区別
                case 4: // 業種別
                case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                    break;
                case 6: // ＢＬコード別
                    this.ultraOptionSet_TotalWay.Focus();
                    break;
            }
        }
        
        /// <summary>
        /// グループコード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            tNedit_BLGloupCode_St.SetInt(bLGroupU.BLGroupCode);
            this.tNedit_BLGloupCode_Ed.Focus();
        }

        /// <summary>
        /// グループコード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            tNedit_BLGloupCode_Ed.SetInt(bLGroupU.BLGroupCode);
            switch (this._listTypePara)
            {
                case 0: // 得意先別
                case 1: // 担当者別
                case 2: // 受注者別
                case 3: // 地区別
                case 4: // 業種別
                case 6: // ＢＬコード別
                    break;
                case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                    this.ultraOptionSet_TotalWay.Focus();
                    break;
            }
        }

        /// <summary>
        /// 商品大分類(開始)ガイド起動ボタン起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
        }

        /// <summary>
        /// 商品大分類(終了)ガイド起動ボタン起動イベント       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsMGroup_St.Focus();
            }
        }

        /// <summary>
        /// 商品中分類(開始)ガイド起動ボタン起動イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            tNedit_GoodsMGroup_St.SetInt(goodsGroupU.GoodsMGroup);
            this.tNedit_GoodsMGroup_Ed.Focus();
        }

        /// <summary>
        /// 商品中分類(終了)ガイド起動ボタン起動イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_MediumGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            tNedit_GoodsMGroup_Ed.SetInt(goodsGroupU.GoodsMGroup);
            this.tNedit_BLGloupCode_St.Focus();
        }

		#endregion

        #region 使用コントロールの設定
        private void SetControl()
        {
            switch (this._listTypePara)
            {
                case 0: // 得意先別
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = false;
                    break;
                case 1: // 担当者別
                case 2: // 受注者別
                    CustomerInput_Ok();
                    SalesEmployeeInput_Ok();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;

                    if (this._listTypePara == 1)
                    {
                        this.ultraLabel_T2.Text = "担当者";
                        this.checkBox_NewPage2.Text = "担当者毎で改頁";
                    }
                    else
                    {
                        this.ultraLabel_T2.Text = "受注者";
                        this.checkBox_NewPage2.Text = "受注者毎で改頁";
                    }
                    break;
                case 3: // 地区別
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Ok();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "地区毎で改頁";

                    AreaMove();
                    break;
                case 4: // 業種別
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Ok();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "業種毎で改頁";

                    BusinessTypeMove();
                    break;
                case 5: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                    CustomerInput_Forbidden();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCodeInput_Ok();
                    this.checkBox_NewPage2.Visible = false;

                    BLGloupCodeMove();
                    break;
                case 6: // ＢＬコード別
                    CustomerInput_Ok();
                    SalesEmployeeInput_Ok();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Ok();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "ＢＬコード毎で改頁";

                    BLGoodsCodeMove();
                    this.ultraLabel_T2.Text = "担当者";
                    break;
            }
        }
        #endregion

        #region		コントロールの入力可・不可
        //得意先
		private void CustomerInput_Ok()			//入力可
		{
			this.tNedit_CustomerCode_St.Visible = true;
			this.tNedit_CustomerCode_Ed.Visible = true;
			this.CustomerCdSt_GuideBtn.Visible = true;
			this.CustomerCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Customer.Visible = true;
			this.ultraLabel_T1.Visible = true;
		}
		private void CustomerInput_Forbidden()	//入力不可
		{
			this.tNedit_CustomerCode_St.Visible = false;
			this.tNedit_CustomerCode_Ed.Visible = false;
			this.CustomerCdSt_GuideBtn.Visible = false;
			this.CustomerCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Customer.Visible = false;
			this.ultraLabel_T1.Visible = false;
		}

	    //担当者
		private void SalesEmployeeInput_Ok()
		{
			this.tNedit_SalesEmployeeCd_St.Visible = true;
			this.tNedit_SalesEmployeeCd_Ed.Visible = true;
			this.SalesEmployeeCdSt_GuideBtn.Visible = true;
			this.SalesEmployeeCdEd_GuideBtn.Visible = true;
			this.ultraLbK_SalesEmp.Visible = true;
			this.ultraLabel_T2.Visible = true;
		}
		private void SalesEmployeeInput_Forbidden()
		{
			this.tNedit_SalesEmployeeCd_St.Visible = false;
			this.tNedit_SalesEmployeeCd_Ed.Visible = false;
			this.SalesEmployeeCdSt_GuideBtn.Visible = false;
			this.SalesEmployeeCdEd_GuideBtn.Visible = false;
			this.ultraLbK_SalesEmp.Visible = false;
			this.ultraLabel_T2.Visible = false;
		}

	    //地区
		private void AreaInput_Ok()
		{
			this.tNedit_AreaCd_St.Visible = true;
			this.tNedit_AreaCd_Ed.Visible = true;
			this.AreaCdSt_GuideBtn.Visible = true;
			this.AreaCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Area.Visible = true;
			this.ultraLabel_T3.Visible = true;
		}
		private void AreaInput_Forbidden()
		{
			this.tNedit_AreaCd_St.Visible = false;
			this.tNedit_AreaCd_Ed.Visible = false;
			this.AreaCdSt_GuideBtn.Visible = false;
			this.AreaCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Area.Visible = false;
			this.ultraLabel_T3.Visible = false;
		}

	    //業種
		private void BusinessTypeInput_Ok()
		{
			this.tNedit_BusinessTypeCode_St.Visible = true;
			this.tNedit_BusinessTypeCode_Ed.Visible = true;
			this.BusinessTypeCdSt_GuideBtn.Visible = true;
			this.BusinessTypeCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Business.Visible = true;
			this.ultraLabel_T4.Visible = true;
		}
		private void BusinessTypeInput_Forbidden()
		{
			this.tNedit_BusinessTypeCode_St.Visible = false;
			this.tNedit_BusinessTypeCode_Ed.Visible = false;
			this.BusinessTypeCdSt_GuideBtn.Visible = false;
			this.BusinessTypeCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Business.Visible = false;
			this.ultraLabel_T4.Visible = false;
		}

        //ＢＬコード
        private void BLGoodsCodeInput_Ok()
		{
            this.tNedit_BLGoodsCode_St.Visible = true;
            this.tNedit_BLGoodsCode_Ed.Visible = true;
            this.ub_St_BLGoodsCodeGuide.Visible = true;
            this.ub_Ed_BLGoodsCodeGuide.Visible = true;
            this.ultraLbK_BLGoodsCode.Visible = true;
            this.ultraLabel_T5.Visible = true;
        }
        private void BLGoodsCodeInput_Forbidden()
        {
            this.tNedit_BLGoodsCode_St.Visible = false;
            this.tNedit_BLGoodsCode_Ed.Visible = false;
            this.ub_St_BLGoodsCodeGuide.Visible = false;
            this.ub_Ed_BLGoodsCodeGuide.Visible = false;
            this.ultraLbK_BLGoodsCode.Visible = false;
            this.ultraLabel_T5.Visible = false;
        }

        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
        private void BLGloupCodeInput_Ok()
        {
            this.tNedit_BLGloupCode_St.Visible = true;
            this.tNedit_BLGloupCode_Ed.Visible = true;
            this.ub_St_DetailGoodsGuide.Visible = true;
            this.ub_Ed_DetailGoodsGuide.Visible = true;
            this.ultraLbK_BLGloupCode.Visible = true;
            this.ultraLabel_T6.Visible = true;

            this.tNedit_GoodsLGroup_St.Visible = true;
            this.tNedit_GoodsLGroup_Ed.Visible = true;
            this.ub_St_GoodsLGroupGuide.Visible = true;
            this.ub_Ed_GoodsLGroupGuide.Visible = true;
            this.ultraLbK_GoodsLGroup.Visible = true;
            this.ultraLabel_T7.Visible = true;

            this.tNedit_GoodsMGroup_St.Visible = true;
            this.tNedit_GoodsMGroup_Ed.Visible = true;
            this.ub_St_MediumGoodsGuide.Visible = true;
            this.ub_Ed_MediumGoodsGuide.Visible = true;
            this.ultraLbK_GoodsMGroup.Visible = true;
            this.ultraLabel_T8.Visible = true;
        }
        private void BLGloupCode_Forbidden()
        {
            this.tNedit_BLGloupCode_St.Visible = false;
            this.tNedit_BLGloupCode_Ed.Visible = false;
            this.ub_St_DetailGoodsGuide.Visible = false;
            this.ub_Ed_DetailGoodsGuide.Visible = false;
            this.ultraLbK_BLGloupCode.Visible = false;
            this.ultraLabel_T6.Visible = false;

            this.tNedit_GoodsLGroup_St.Visible = false;
            this.tNedit_GoodsLGroup_Ed.Visible = false;
            this.ub_St_GoodsLGroupGuide.Visible = false;
            this.ub_Ed_GoodsLGroupGuide.Visible = false;
            this.ultraLbK_GoodsLGroup.Visible = false;
            this.ultraLabel_T7.Visible = false;

            this.tNedit_GoodsMGroup_St.Visible = false;
            this.tNedit_GoodsMGroup_Ed.Visible = false;
            this.ub_St_MediumGoodsGuide.Visible = false;
            this.ub_Ed_MediumGoodsGuide.Visible = false;
            this.ultraLbK_GoodsMGroup.Visible = false;
            this.ultraLabel_T8.Visible = false;
        }

        #endregion

		#region コントロールの位置移動

		//  担当者別の時：得意先の位置へ
		private void SalesEmployeeMove()
		{
			ultraLabel_T2.Top = ultraLabel_T1.Top;
			tNedit_SalesEmployeeCd_St.Top = tNedit_CustomerCode_St.Top;
			tNedit_SalesEmployeeCd_Ed.Top = tNedit_CustomerCode_Ed.Top;
			SalesEmployeeCdSt_GuideBtn.Top = CustomerCdSt_GuideBtn.Top;
			SalesEmployeeCdEd_GuideBtn.Top = CustomerCdEd_GuideBtn.Top;
			ultraLbK_SalesEmp.Top = ultraLbK_Customer.Top;
		}
		//	地区別の時：担当者の位置へ
		private void AreaMove()
		{
			ultraLabel_T3.Top = ultraLabel_T2.Top;
			tNedit_AreaCd_St.Top = tNedit_SalesEmployeeCd_St.Top;
			tNedit_AreaCd_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
			AreaCdSt_GuideBtn.Top = SalesEmployeeCdSt_GuideBtn.Top;
			AreaCdEd_GuideBtn.Top = SalesEmployeeCdEd_GuideBtn.Top;
			ultraLbK_Area.Top = ultraLbK_SalesEmp.Top;
		}
		//	業種別の時：担当者の位置へ
		private void BusinessTypeMove()
		{
			ultraLabel_T4.Top = ultraLabel_T2.Top;
			tNedit_BusinessTypeCode_St.Top = tNedit_SalesEmployeeCd_St.Top;
			tNedit_BusinessTypeCode_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
			BusinessTypeCdSt_GuideBtn.Top = SalesEmployeeCdSt_GuideBtn.Top;
			BusinessTypeCdEd_GuideBtn.Top = SalesEmployeeCdEd_GuideBtn.Top;
			ultraLbK_Business.Top = ultraLbK_SalesEmp.Top;
		}
        //	ＢＬコード別の時：地区の位置へ
        private void BLGoodsCodeMove()
        {
            ultraLabel_T5.Top = ultraLabel_T3.Top;
            tNedit_BLGoodsCode_St.Top = tNedit_AreaCd_St.Top;
            tNedit_BLGoodsCode_Ed.Top = tNedit_AreaCd_Ed.Top;
            ub_St_BLGoodsCodeGuide.Top = AreaCdSt_GuideBtn.Top;
            ub_Ed_BLGoodsCodeGuide.Top = AreaCdEd_GuideBtn.Top;
            ultraLbK_BLGoodsCode.Top = ultraLbK_Area.Top;
        }
        //	グループ別の時：大分類→得意先の位置へ
        //                  中分類→担当者の位置へ
        //  　　　　　　　　ｸﾞﾙｰﾌﾟｺｰﾄﾞ→地区の位置へ
        private void BLGloupCodeMove()
        {
            ultraLabel_T7.Top = ultraLabel_T1.Top;
            tNedit_GoodsLGroup_St.Top = tNedit_CustomerCode_St.Top;
            tNedit_GoodsLGroup_Ed.Top = tNedit_CustomerCode_Ed.Top;
            ub_St_GoodsLGroupGuide.Top = CustomerCdSt_GuideBtn.Top;
            ub_Ed_GoodsLGroupGuide.Top = CustomerCdEd_GuideBtn.Top;
            ultraLbK_GoodsLGroup.Top = ultraLbK_Customer.Top;

            ultraLabel_T8.Top = ultraLabel_T2.Top;
            tNedit_GoodsMGroup_St.Top = tNedit_SalesEmployeeCd_St.Top;
            tNedit_GoodsMGroup_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
            ub_St_MediumGoodsGuide.Top = SalesEmployeeCdSt_GuideBtn.Top;
            ub_Ed_MediumGoodsGuide.Top = SalesEmployeeCdEd_GuideBtn.Top;
            ultraLbK_GoodsMGroup.Top = ultraLbK_SalesEmp.Top;

            ultraLabel_T6.Top = ultraLabel_T3.Top;
            tNedit_BLGloupCode_St.Top = tNedit_AreaCd_St.Top;
            tNedit_BLGloupCode_Ed.Top = tNedit_AreaCd_Ed.Top;
            ub_St_DetailGoodsGuide.Top = AreaCdSt_GuideBtn.Top;
            ub_Ed_DetailGoodsGuide.Top = AreaCdEd_GuideBtn.Top;
            ultraLbK_BLGloupCode.Top = ultraLbK_Area.Top;
        }

		#endregion
	}
}
