//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入確認表
// プログラム概要   : 仕入確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 飯谷 耕平
// 作 成 日  2007/05/22  修正内容 : キャリアの一覧を、キャリア表示順位アクセスクラスから読むように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/07/16  修正内容 : データ項目の追加/修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13159(仕入日の任意項目化)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 障害対応12394,12396,12401
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 魯志明
// 修 正 日  2010/08/16  修正内容 : 障害改良対応8月　キーボード操作の改良を行う。
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : cheq
// 修 正 日  2012/12/26  修正内容 : 2013/03/13配信分、Redmine#34098 
//                                  罫線印字制御の追加と出力順制御の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/27  修正内容 : 2013/03/13配信分、Redmine#34098 
//                                  罫線印字制御の追加と出力順制御の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本 利明
// 修 正 日  2013/03/05  修正内容 : Tab･Enterキーでのフォーカス制御を修正
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 尹安
// 修 正 日  2020/02/27  修正内容 : 軽減税率対応
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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/07 不具合対応[5639]
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinEditors; // ADD 2010/08/16
using Infragistics.Win.Misc; // ADD 2010/08/16
// --- ADD START 3H 尹安 2020/02/27---------->>>>>
using System.IO;
using System.Text.RegularExpressions;
// --- ADD END 3H 尹安 2020/02/27----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 帳票・チャート印刷条件フォームクラス
    /// </summary>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・キャリアの一覧を、キャリア表示順位アクセスクラスから読むように修正</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・データ項目の追加/修正</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応13159(仕入日の任意項目化)</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応12394,12396,12401</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/14</br>
    /// <br>Update Note : 2012/12/26 cheq</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加と出力順制御の対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2013/02/27 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加と出力順制御の対応</br>
    /// -----------------------------------------------------------------------------------
    public class MAKON02240UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer,
		//IPrintConditionInpTypeChart
        IPrintConditionInpTypeGuidExecuter      // F5：ガイドの表示非表示 // ADD 2010/08/16
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel MAKON02240UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private TDateEdit StockDateEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit StockDateStRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TNedit tNedit_SupplierCd_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TComboEditor tComboEditor_DebitNoteDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor tComboEditor_SupplierSlipCd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private TNedit AcceptAnOrderNoEd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private TNedit AcceptAnOrderNoSt_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private TEdit tEdit_StockAgentCode_Ed;
        private TEdit tEdit_StockAgentCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private ToolTip toolTip1;
		private TDateEdit InputDayEdRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private TDateEdit InputDayStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private TEdit PartySaleSlipNumEd_tEdit;
		private TEdit PartySaleSlipNumSt_tEdit;
		private UiSetControl uiSetControl1;
        private TComboEditor tComboEditor_PrintType;
        private TComboEditor tComboEditor_NewPage;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeEd_GuidBtn;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeSt_GuidBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TComboEditor tComboEditor_StockOrderDivCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private TComboEditor tComboEditor_OutputDesignated;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private TNedit tNedit_SalesAreaCode_St;
        private TNedit tNedit_SalesAreaCode_Ed;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_PrintDailyFooter;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private System.ComponentModel.IContainer components;

        private object _preComboEditorValue = null;
        private TComboEditor _preCtrlName = null;    //ADD 2008/08/16
        private UiMemInput uiMemInput1;
        private TComboEditor tComboEditor_LinePrintDiv;
        private UltraLabel LinePrintDiv_Label;
        private TComboEditor tComboEditor_TaxPrintDiv;
        private UltraLabel ultraLabel20;    //ADD 2008/08/16
        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<
        // --- ADD START 3H 尹安 2020/02/27---------->>>>>
        // XML名称
        private const string ctPrintXmlFileName = "TaxRate_UserSetting.XML";
        // --- ADD END 3H 尹安 2020/02/27----------<<<<<
		#endregion
		
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region constructer
        /// <remarks>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34098 罫線印字制御の追加対応</br>
        /// <br></br>
        /// </remarks>
		public MAKON02240UA()
		{
			InitializeComponent();

			this._enterpriseCode   = LoginInfoAcquisition.EnterpriseCode;
            this._carrierDspList = new ArrayList();
            this._carrierList = new SortedList();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker    = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // インスタンス生成
            this._employeeAcs = new EmployeeAcs();
            this._lGoodsGanreAcs = new LGoodsGanreAcs();
            this._mGoodsGanreAcs = new MGoodsGanreAcs();
            //this._cellphoneModelAcs = new CellphoneModelAcs();

			//日付取得部品
			this._dateGet = DateGetAcs.GetInstance();
            //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>> 
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tComboEditor_LinePrintDiv); // 罫線印字

            uiMemInput1.TargetControls = ctrlList;
            //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<

        }
		#endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		#region Dispose        
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
        /// <remarks>
        /// <br>Update Note : 2013/02/27 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加と出力順制御の対応</br>
        /// </remarks>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_TaxPrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_LinePrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.LinePrintDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_PrintDailyFooter = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_NewPage = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.StockDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.StockDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tComboEditor_StockOrderDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_OutputDesignated = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesAreaCodeEd_GuidBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesAreaCodeSt_GuidBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartySaleSlipNumEd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.PartySaleSlipNumSt_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_StockAgentCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_StockAgentCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.AcceptAnOrderNoEd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.AcceptAnOrderNoSt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_DebitNoteDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAKON02240UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LinePrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPage)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockOrderDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputDesignated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumEd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumSt_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoEd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoSt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            this.MAKON02240UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_TaxPrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel20);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_LinePrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.LinePrintDiv_Label);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_PrintDailyFooter);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel19);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_NewPage);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.StockDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.StockDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(712, 158);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // tComboEditor_TaxPrintDiv
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ActiveAppearance = appearance68;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.Appearance = appearance22;
            this.tComboEditor_TaxPrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ItemAppearance = appearance69;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0:印字する";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1:印字しない";
            this.tComboEditor_TaxPrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_TaxPrintDiv.LimitToList = true;
            this.tComboEditor_TaxPrintDiv.Location = new System.Drawing.Point(168, 128);
            this.tComboEditor_TaxPrintDiv.Name = "tComboEditor_TaxPrintDiv";
            this.tComboEditor_TaxPrintDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_TaxPrintDiv.TabIndex = 72;
            // 
            // ultraLabel20
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance8;
            this.ultraLabel20.Location = new System.Drawing.Point(24, 128);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel20.TabIndex = 73;
            this.ultraLabel20.Text = "税別内訳印字";
            // 
            // tComboEditor_LinePrintDiv
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_LinePrintDiv.Appearance = appearance90;
            this.tComboEditor_LinePrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ItemAppearance = appearance91;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "0:印字する";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "1:印字しない";
            this.tComboEditor_LinePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.tComboEditor_LinePrintDiv.LimitToList = true;
            this.tComboEditor_LinePrintDiv.Location = new System.Drawing.Point(168, 68);
            this.tComboEditor_LinePrintDiv.Name = "tComboEditor_LinePrintDiv";
            this.tComboEditor_LinePrintDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_LinePrintDiv.TabIndex = 4;
            // 
            // LinePrintDiv_Label
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.LinePrintDiv_Label.Appearance = appearance92;
            this.LinePrintDiv_Label.Location = new System.Drawing.Point(24, 68);
            this.LinePrintDiv_Label.Name = "LinePrintDiv_Label";
            this.LinePrintDiv_Label.Size = new System.Drawing.Size(122, 23);
            this.LinePrintDiv_Label.TabIndex = 71;
            this.LinePrintDiv_Label.Text = "罫線印字";
            // 
            // ultraOptionSet_PrintDailyFooter
            // 
            this.ultraOptionSet_PrintDailyFooter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "しない";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "する";
            this.ultraOptionSet_PrintDailyFooter.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.ultraOptionSet_PrintDailyFooter.Location = new System.Drawing.Point(433, 72);
            this.ultraOptionSet_PrintDailyFooter.Name = "ultraOptionSet_PrintDailyFooter";
            this.ultraOptionSet_PrintDailyFooter.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_PrintDailyFooter.TabIndex = 5;
            this.ultraOptionSet_PrintDailyFooter.Text = "しない";
            this.ultraOptionSet_PrintDailyFooter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraOptionSet_PrintDailyFooter_KeyDown);
            // 
            // ultraLabel19
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance85;
            this.ultraLabel19.Location = new System.Drawing.Point(356, 69);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel19.TabIndex = 65;
            this.ultraLabel19.Text = "日計印字";
            // 
            // tComboEditor_NewPage
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPage.ActiveAppearance = appearance43;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPage.Appearance = appearance30;
            this.tComboEditor_NewPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPage.ItemAppearance = appearance44;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "0:拠点";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "1:仕入先";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "2:しない";
            this.tComboEditor_NewPage.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.tComboEditor_NewPage.LimitToList = true;
            this.tComboEditor_NewPage.Location = new System.Drawing.Point(168, 98);
            this.tComboEditor_NewPage.Name = "tComboEditor_NewPage";
            this.tComboEditor_NewPage.Size = new System.Drawing.Size(116, 24);
            this.tComboEditor_NewPage.TabIndex = 6;
            // 
            // ultraLabel6
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance5;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 98);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel6.TabIndex = 62;
            this.ultraLabel6.Text = "改頁";
            // 
            // InputDayEdRF_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEdRF_tDateEdit.ActiveEditAppearance = appearance1;
            this.InputDayEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEdRF_tDateEdit.CalendarDisp = true;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.EditAppearance = appearance2;
            this.InputDayEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.LabelAppearance = appearance3;
            this.InputDayEdRF_tDateEdit.Location = new System.Drawing.Point(387, 38);
            this.InputDayEdRF_tDateEdit.Name = "InputDayEdRF_tDateEdit";
            this.InputDayEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEdRF_tDateEdit.TabIndex = 3;
            this.InputDayEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel4
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance6;
            this.ultraLabel4.Location = new System.Drawing.Point(356, 38);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel4.TabIndex = 37;
            this.ultraLabel4.Text = "～";
            // 
            // StockDateEdRF_tDateEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockDateEdRF_tDateEdit.ActiveEditAppearance = appearance7;
            this.StockDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.StockDateEdRF_tDateEdit.CalendarDisp = true;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.StockDateEdRF_tDateEdit.EditAppearance = appearance84;
            this.StockDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.StockDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.StockDateEdRF_tDateEdit.LabelAppearance = appearance9;
            this.StockDateEdRF_tDateEdit.Location = new System.Drawing.Point(387, 8);
            this.StockDateEdRF_tDateEdit.Name = "StockDateEdRF_tDateEdit";
            this.StockDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.StockDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.StockDateEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.StockDateEdRF_tDateEdit.TabIndex = 1;
            this.StockDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance10;
            this.ultraLabel10.Location = new System.Drawing.Point(356, 8);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // InputDayStRF_tDateEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayStRF_tDateEdit.ActiveEditAppearance = appearance11;
            this.InputDayStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayStRF_tDateEdit.CalendarDisp = true;
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.EditAppearance = appearance12;
            this.InputDayStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.LabelAppearance = appearance13;
            this.InputDayStRF_tDateEdit.Location = new System.Drawing.Point(168, 38);
            this.InputDayStRF_tDateEdit.Name = "InputDayStRF_tDateEdit";
            this.InputDayStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayStRF_tDateEdit.TabIndex = 2;
            this.InputDayStRF_tDateEdit.TabStop = true;
            // 
            // StockDateStRF_tDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockDateStRF_tDateEdit.ActiveEditAppearance = appearance14;
            this.StockDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.StockDateStRF_tDateEdit.CalendarDisp = true;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.StockDateStRF_tDateEdit.EditAppearance = appearance15;
            this.StockDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.StockDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.StockDateStRF_tDateEdit.LabelAppearance = appearance16;
            this.StockDateStRF_tDateEdit.Location = new System.Drawing.Point(168, 8);
            this.StockDateStRF_tDateEdit.Name = "StockDateStRF_tDateEdit";
            this.StockDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.StockDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.StockDateStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.StockDateStRF_tDateEdit.TabIndex = 0;
            this.StockDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel9
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance17;
            this.ultraLabel9.Location = new System.Drawing.Point(24, 38);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel9.TabIndex = 36;
            this.ultraLabel9.Text = "入力日";
            // 
            // ultraLabel8
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance18;
            this.ultraLabel8.Location = new System.Drawing.Point(24, 8);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "仕入日";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 241);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(712, 33);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance19;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance31;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance20;
            valueListItem10.DataValue = ((short)(5));
            valueListItem10.DisplayText = "0:仕入先→仕入日→仕入SEQ番号";
            valueListItem11.DataValue = ((short)(6));
            valueListItem11.DisplayText = "1:仕入先→入力日→仕入SEQ番号";
            valueListItem12.DataValue = ((short)(1));
            valueListItem12.DisplayText = "2:仕入先→仕入日→伝票番号";
            valueListItem13.DataValue = ((short)(3));
            valueListItem13.DisplayText = "3:仕入先→入力日→伝票番号";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13});
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(168, 4);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 5;
            // 
            // ultraLabel5
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance21;
            this.ultraLabel5.Location = new System.Drawing.Point(24, 3);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 4;
            this.ultraLabel5.Text = "出力順";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_StockOrderDivCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel18);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_OutputDesignated);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel17);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeEd_GuidBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeSt_GuidBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_PrintType);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.PartySaleSlipNumEd_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.PartySaleSlipNumSt_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AcceptAnOrderNoEd_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AcceptAnOrderNoSt_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel26);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_DebitNoteDiv);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_SupplierSlipCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 311);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(712, 305);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance86.TextHAlignAsString = "Left";
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance86;
            appearance76.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance76;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(321, 34);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 9;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 12;
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance50;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(168, 34);
            this.tNedit_SalesAreaCode_St.MaxLength = 9;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 10;
            // 
            // tComboEditor_StockOrderDivCd
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_StockOrderDivCd.ActiveAppearance = appearance61;
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_StockOrderDivCd.Appearance = appearance83;
            this.tComboEditor_StockOrderDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_StockOrderDivCd.ItemAppearance = appearance62;
            valueListItem14.DataValue = -1;
            valueListItem14.DisplayText = "0:全て";
            valueListItem15.DataValue = 1;
            valueListItem15.DisplayText = "1:在庫";
            valueListItem16.DataValue = 0;
            valueListItem16.DisplayText = "2:取寄";
            this.tComboEditor_StockOrderDivCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.tComboEditor_StockOrderDivCd.LimitToList = true;
            this.tComboEditor_StockOrderDivCd.Location = new System.Drawing.Point(168, 273);
            this.tComboEditor_StockOrderDivCd.Name = "tComboEditor_StockOrderDivCd";
            this.tComboEditor_StockOrderDivCd.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_StockOrderDivCd.TabIndex = 26;
            // 
            // ultraLabel18
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance4;
            this.ultraLabel18.Location = new System.Drawing.Point(24, 273);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel18.TabIndex = 70;
            this.ultraLabel18.Text = "在庫取寄指定";
            // 
            // tComboEditor_OutputDesignated
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputDesignated.ActiveAppearance = appearance71;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_OutputDesignated.Appearance = appearance82;
            this.tComboEditor_OutputDesignated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputDesignated.ItemAppearance = appearance72;
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "0:全て";
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "1:仕入入力";
            valueListItem19.DataValue = 2;
            valueListItem19.DisplayText = "2:UOE分";
            valueListItem20.DataValue = 3;
            valueListItem20.DisplayText = "3:同時入力分";
            valueListItem21.DataValue = 4;
            valueListItem21.DisplayText = "4:UOEアンマッチ";
            this.tComboEditor_OutputDesignated.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20,
            valueListItem21});
            this.tComboEditor_OutputDesignated.LimitToList = true;
            this.tComboEditor_OutputDesignated.Location = new System.Drawing.Point(168, 243);
            this.tComboEditor_OutputDesignated.Name = "tComboEditor_OutputDesignated";
            this.tComboEditor_OutputDesignated.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_OutputDesignated.TabIndex = 25;
            // 
            // ultraLabel17
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance73;
            this.ultraLabel17.Location = new System.Drawing.Point(23, 243);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel17.TabIndex = 68;
            this.ultraLabel17.Text = "出力指定";
            // 
            // SalesAreaCodeEd_GuidBtn
            // 
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeEd_GuidBtn.Appearance = appearance26;
            this.SalesAreaCodeEd_GuidBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeEd_GuidBtn.Location = new System.Drawing.Point(411, 33);
            this.SalesAreaCodeEd_GuidBtn.Name = "SalesAreaCodeEd_GuidBtn";
            this.SalesAreaCodeEd_GuidBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeEd_GuidBtn.TabIndex = 13;
            this.SalesAreaCodeEd_GuidBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesAreaCodeEd_GuidBtn, "地区ガイド");
            this.SalesAreaCodeEd_GuidBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeEd_GuidBtn.Click += new System.EventHandler(this.SalesAreaCodeEd_GuidBtn_Click);
            // 
            // SalesAreaCodeSt_GuidBtn
            // 
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeSt_GuidBtn.Appearance = appearance27;
            this.SalesAreaCodeSt_GuidBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeSt_GuidBtn.Location = new System.Drawing.Point(258, 33);
            this.SalesAreaCodeSt_GuidBtn.Name = "SalesAreaCodeSt_GuidBtn";
            this.SalesAreaCodeSt_GuidBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeSt_GuidBtn.TabIndex = 11;
            this.SalesAreaCodeSt_GuidBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesAreaCodeSt_GuidBtn, "地区ガイド");
            this.SalesAreaCodeSt_GuidBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeSt_GuidBtn.Click += new System.EventHandler(this.SalesAreaCodeSt_GuidBtn_Click);
            // 
            // ultraLabel7
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance32;
            this.ultraLabel7.Location = new System.Drawing.Point(292, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel7.TabIndex = 67;
            this.ultraLabel7.Text = "～";
            // 
            // ultraLabel16
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance39;
            this.ultraLabel16.Location = new System.Drawing.Point(24, 33);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel16.TabIndex = 66;
            this.ultraLabel16.Text = "地区";
            // 
            // tComboEditor_PrintType
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ActiveAppearance = appearance74;
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PrintType.Appearance = appearance81;
            this.tComboEditor_PrintType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ItemAppearance = appearance75;
            valueListItem22.DataValue = 0;
            valueListItem22.DisplayText = "0:通常";
            valueListItem23.DataValue = 1;
            valueListItem23.DisplayText = "1:訂正";
            valueListItem24.DataValue = 2;
            valueListItem24.DisplayText = "2:削除";
            valueListItem25.DataValue = 3;
            valueListItem25.DisplayText = "3:訂正＋削除";
            this.tComboEditor_PrintType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem22,
            valueListItem23,
            valueListItem24,
            valueListItem25});
            this.tComboEditor_PrintType.LimitToList = true;
            this.tComboEditor_PrintType.Location = new System.Drawing.Point(168, 213);
            this.tComboEditor_PrintType.Name = "tComboEditor_PrintType";
            this.tComboEditor_PrintType.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_PrintType.TabIndex = 24;
            // 
            // PartySaleSlipNumEd_tEdit
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartySaleSlipNumEd_tEdit.ActiveAppearance = appearance87;
            this.PartySaleSlipNumEd_tEdit.AutoSelect = true;
            this.PartySaleSlipNumEd_tEdit.DataText = "";
            this.PartySaleSlipNumEd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartySaleSlipNumEd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PartySaleSlipNumEd_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PartySaleSlipNumEd_tEdit.Location = new System.Drawing.Point(321, 124);
            this.PartySaleSlipNumEd_tEdit.MaxLength = 19;
            this.PartySaleSlipNumEd_tEdit.Name = "PartySaleSlipNumEd_tEdit";
            this.PartySaleSlipNumEd_tEdit.Size = new System.Drawing.Size(82, 24);
            this.PartySaleSlipNumEd_tEdit.TabIndex = 21;
            // 
            // ultraLabel2
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance70;
            this.ultraLabel2.Location = new System.Drawing.Point(23, 213);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "発行タイプ";
            // 
            // PartySaleSlipNumSt_tEdit
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartySaleSlipNumSt_tEdit.ActiveAppearance = appearance23;
            this.PartySaleSlipNumSt_tEdit.AutoSelect = true;
            this.PartySaleSlipNumSt_tEdit.DataText = "";
            this.PartySaleSlipNumSt_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartySaleSlipNumSt_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PartySaleSlipNumSt_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PartySaleSlipNumSt_tEdit.Location = new System.Drawing.Point(168, 124);
            this.PartySaleSlipNumSt_tEdit.MaxLength = 19;
            this.PartySaleSlipNumSt_tEdit.Name = "PartySaleSlipNumSt_tEdit";
            this.PartySaleSlipNumSt_tEdit.Size = new System.Drawing.Size(82, 24);
            this.PartySaleSlipNumSt_tEdit.TabIndex = 20;
            // 
            // ultraLabel14
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance24;
            this.ultraLabel14.Location = new System.Drawing.Point(292, 124);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel14.TabIndex = 60;
            this.ultraLabel14.Text = "～";
            // 
            // ultraLabel15
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance25;
            this.ultraLabel15.Location = new System.Drawing.Point(24, 124);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel15.TabIndex = 59;
            this.ultraLabel15.Text = "伝票番号";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance63.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance63;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(411, 3);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 9;
            this.SalesEmployeeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance64.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance64;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(258, 3);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 7;
            this.SalesEmployeeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance28;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(411, 63);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 17;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "仕入先検索");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance29.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance29;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(258, 64);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 15;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "仕入先検索");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_StockAgentCode_Ed
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_Ed.ActiveAppearance = appearance65;
            this.tEdit_StockAgentCode_Ed.AutoSelect = true;
            this.tEdit_StockAgentCode_Ed.DataText = "";
            this.tEdit_StockAgentCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_Ed.Location = new System.Drawing.Point(321, 3);
            this.tEdit_StockAgentCode_Ed.MaxLength = 9;
            this.tEdit_StockAgentCode_Ed.Name = "tEdit_StockAgentCode_Ed";
            this.tEdit_StockAgentCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_Ed.TabIndex = 8;
            // 
            // tEdit_StockAgentCode_St
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_St.ActiveAppearance = appearance66;
            this.tEdit_StockAgentCode_St.AutoSelect = true;
            this.tEdit_StockAgentCode_St.DataText = "";
            this.tEdit_StockAgentCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_St.Location = new System.Drawing.Point(168, 3);
            this.tEdit_StockAgentCode_St.MaxLength = 9;
            this.tEdit_StockAgentCode_St.Name = "tEdit_StockAgentCode_St";
            this.tEdit_StockAgentCode_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_St.TabIndex = 6;
            // 
            // ultraLabel25
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance67;
            this.ultraLabel25.Location = new System.Drawing.Point(292, 3);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 56;
            this.ultraLabel25.Text = "～";
            // 
            // AcceptAnOrderNoEd_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlignAsString = "Left";
            this.AcceptAnOrderNoEd_tNedit.ActiveAppearance = appearance33;
            appearance34.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoEd_tNedit.Appearance = appearance34;
            this.AcceptAnOrderNoEd_tNedit.AutoSelect = true;
            this.AcceptAnOrderNoEd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AcceptAnOrderNoEd_tNedit.DataText = "";
            this.AcceptAnOrderNoEd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AcceptAnOrderNoEd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.AcceptAnOrderNoEd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AcceptAnOrderNoEd_tNedit.Location = new System.Drawing.Point(321, 94);
            this.AcceptAnOrderNoEd_tNedit.MaxLength = 9;
            this.AcceptAnOrderNoEd_tNedit.Name = "AcceptAnOrderNoEd_tNedit";
            this.AcceptAnOrderNoEd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.AcceptAnOrderNoEd_tNedit.Size = new System.Drawing.Size(82, 24);
            this.AcceptAnOrderNoEd_tNedit.TabIndex = 19;
            // 
            // ultraLabel27
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance35;
            this.ultraLabel27.Location = new System.Drawing.Point(292, 94);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 53;
            this.ultraLabel27.Text = "～";
            // 
            // AcceptAnOrderNoSt_tNedit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoSt_tNedit.ActiveAppearance = appearance36;
            appearance37.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoSt_tNedit.Appearance = appearance37;
            this.AcceptAnOrderNoSt_tNedit.AutoSelect = true;
            this.AcceptAnOrderNoSt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AcceptAnOrderNoSt_tNedit.DataText = "";
            this.AcceptAnOrderNoSt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AcceptAnOrderNoSt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.AcceptAnOrderNoSt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AcceptAnOrderNoSt_tNedit.Location = new System.Drawing.Point(168, 94);
            this.AcceptAnOrderNoSt_tNedit.MaxLength = 9;
            this.AcceptAnOrderNoSt_tNedit.Name = "AcceptAnOrderNoSt_tNedit";
            this.AcceptAnOrderNoSt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.AcceptAnOrderNoSt_tNedit.Size = new System.Drawing.Size(82, 24);
            this.AcceptAnOrderNoSt_tNedit.TabIndex = 18;
            // 
            // ultraLabel28
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance38;
            this.ultraLabel28.Location = new System.Drawing.Point(24, 94);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel28.TabIndex = 51;
            this.ultraLabel28.Text = "仕入SEQ番号";
            // 
            // ultraLabel26
            // 
            appearance88.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance88;
            this.ultraLabel26.Location = new System.Drawing.Point(24, 3);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel26.TabIndex = 47;
            this.ultraLabel26.Text = "担当者";
            // 
            // tComboEditor_DebitNoteDiv
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ActiveAppearance = appearance40;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DebitNoteDiv.Appearance = appearance80;
            this.tComboEditor_DebitNoteDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ItemAppearance = appearance41;
            valueListItem26.DataValue = ((short)(0));
            valueListItem26.DisplayText = "0:全て";
            valueListItem27.DataValue = ((short)(1));
            valueListItem27.DisplayText = "1:黒伝";
            valueListItem28.DataValue = ((short)(2));
            valueListItem28.DisplayText = "2:赤伝";
            valueListItem29.DataValue = "3";
            valueListItem29.DisplayText = "3:元黒";
            this.tComboEditor_DebitNoteDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem26,
            valueListItem27,
            valueListItem28,
            valueListItem29});
            this.tComboEditor_DebitNoteDiv.LimitToList = true;
            this.tComboEditor_DebitNoteDiv.Location = new System.Drawing.Point(168, 183);
            this.tComboEditor_DebitNoteDiv.Name = "tComboEditor_DebitNoteDiv";
            this.tComboEditor_DebitNoteDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_DebitNoteDiv.TabIndex = 23;
            this.tComboEditor_DebitNoteDiv.Text = "元黒";
            // 
            // ultraLabel13
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance42;
            this.ultraLabel13.Location = new System.Drawing.Point(23, 183);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel13.TabIndex = 23;
            this.ultraLabel13.Text = "赤伝区分";
            // 
            // tComboEditor_SupplierSlipCd
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ActiveAppearance = appearance59;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierSlipCd.Appearance = appearance79;
            this.tComboEditor_SupplierSlipCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ItemAppearance = appearance60;
            valueListItem30.DataValue = ((short)(0));
            valueListItem30.DisplayText = "0:全て";
            valueListItem31.DataValue = ((short)(10));
            valueListItem31.DisplayText = "1:仕入";
            valueListItem32.DataValue = ((short)(20));
            valueListItem32.DisplayText = "2:返品";
            this.tComboEditor_SupplierSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem30,
            valueListItem31,
            valueListItem32});
            this.tComboEditor_SupplierSlipCd.LimitToList = true;
            this.tComboEditor_SupplierSlipCd.Location = new System.Drawing.Point(168, 154);
            this.tComboEditor_SupplierSlipCd.Name = "tComboEditor_SupplierSlipCd";
            this.tComboEditor_SupplierSlipCd.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_SupplierSlipCd.TabIndex = 22;
            // 
            // ultraLabel12
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance45;
            this.ultraLabel12.Location = new System.Drawing.Point(23, 154);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel12.TabIndex = 21;
            this.ultraLabel12.Text = "伝票区分";
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance46;
            appearance47.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance47;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(321, 64);
            this.tNedit_SupplierCd_Ed.MaxLength = 9;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 16;
            // 
            // ultraLabel11
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance48;
            this.ultraLabel11.Location = new System.Drawing.Point(292, 64);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 19;
            this.ultraLabel11.Text = "～";
            // 
            // tNedit_SupplierCd_St
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance77;
            appearance78.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance78;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(168, 64);
            this.tNedit_SupplierCd_St.MaxLength = 9;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_St.TabIndex = 14;
            // 
            // ultraLabel3
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance51;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 64);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 17;
            this.ultraLabel3.Text = "仕入先";
            // 
            // MAKON02240UA_Fill_Panel
            // 
            this.MAKON02240UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAKON02240UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAKON02240UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAKON02240UA_Fill_Panel.Name = "MAKON02240UA_Fill_Panel";
            this.MAKON02240UA_Fill_Panel.Size = new System.Drawing.Size(750, 639);
            this.MAKON02240UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(750, 639);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance52.FontData.Name = "ＭＳ ゴシック";
            appearance52.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance52;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance53;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 160;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance54;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 35;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　ソート順";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance55;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 307;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance56.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance56;
            appearance57.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance57;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(3, 3);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(748, 624);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing_1);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance58.FontData.SizeInPoints = 20F;
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance58;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 639);
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
            this.tArrowKeyControl1.AlwaysEvent = true;
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
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAKON02240UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 639);
            this.Controls.Add(this.MAKON02240UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAKON02240UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入確認表";
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LinePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPage)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockOrderDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputDesignated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumEd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumSt_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoEd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoSt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            this.MAKON02240UA_Fill_Panel.ResumeLayout(false);
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

		//private bool _baseOption                     = false;
        
		private bool _printButtonEnabled = true;
		private bool _extraButtonEnabled = false;
		private bool _pdfButtonEnabled = true;
		private bool _printButtonVisibled = true;
		private bool _extraButtonVisibled = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// 計上拠点選択表示取得

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = false;
		private bool _chartButtonEnabled = false;

        private string _StockConfDataTable;

		private Employee _loginWorker = null;
		// 自拠点コード
		private string _ownSectionCode = "";
		// 請求設定拠点コード
		//private string _balanceSectionCode = "";

        private ExtrInfo_MAKON02247E _chartStockconfListCndtn = null;

        // 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private static SupplierAcs _supplierAcs;
        private static UserGuideAcs _userGuideAcs;
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        // ガイド系アクセスクラス
        EmployeeAcs _employeeAcs;
        LGoodsGanreAcs _lGoodsGanreAcs;
        MGoodsGanreAcs _mGoodsGanreAcs;
//        CellphoneModelAcs _cellphoneModelAcs;

        private StockConfAcs _stockConfListAcs = null;  // 売上確認表アクセスクラス

        private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// 拠点オプション有無
        private bool _isMainOfficeFunc;	// 本社機能有無

        SortedList _carrierList;
        ArrayList _carrierDspList;
        
		// エクスプローラバー拡大基準高さ 
		private Form _topForm = null;
		private bool _explorerBarExpanding = false;

		//日付取得部品
		private DateGetAcs _dateGet; 

		// 商品チャート抽出クラスメンバ
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_MAKON02247E _stockConfListCndtnWork = new ExtrInfo_MAKON02247E();		//条件クラス(前回条件保持用)
        private ExtrInfo_MAKON02247E _chartStockConfListCndtn = new ExtrInfo_MAKON02247E();		//条件クラス(チャート引渡し用)
        private DataSet _printBuffDataSet = null;

        // ADD 2008/10/07 不具合対応[5639]---------->>>>>
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
        // ADD 2008/10/07 不具合対応[5639]----------<<<<<

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

		private const string THIS_ASSEMBLYID                         = "MAKON02240U";	
		private const string PDF_PRINT_KEY                           = "3ee0af24-56ae-435d-b294-298a93dfd243";
		private const string PDF_PRINT_NAME = "仕入確認表";

        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

		// エクスプローラーバーの表示状態を決定するための基準となるトップフォームの高さ
		private const int CT_TOPFORM_BASE_HEIGHT = 768;

        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent; // ADD 2010/08/16

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup = "CustomerConditionGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";
		private const string ct_ExBarGroupNm_PrintConditionGroup = "ExtraConditionCodeGroup";	// 抽出条件

		//エラー条件メッセージ
		const string ct_InputError = "の入力が不正です";
		const string ct_NoInput = "を入力して下さい";
		const string ct_RangeError = "の範囲指定に誤りがあります";
		//const string ct_RangeOverError = "は１ヶ月の範囲内で入力して下さい";  // DEL 2008/07/16
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力して下さい";    // ADD 2008/07/16

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
                return _chartStockconfListCndtn;
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public void Show(object parameter)
		{
            this.Show();
        }
		
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public int Print(ref object parameter)
		{

		            
			SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // 印刷情報パラメータ
		
			// 企業コード
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // 起動ＰＧＩＤ
			printInfo.key            = PDF_PRINT_KEY;               // PDF履歴管理用KEY情報

			// 画面→抽出条件クラス
            ExtrInfo_MAKON02247E stockConfListCndtnWork = new ExtrInfo_MAKON02247E();
            this.SetExtraInfoFromScreen(ref stockConfListCndtnWork);
		            
			// 抽出条件の設定
            printInfo.jyoken = stockConfListCndtnWork;

#if False
			// チャート用条件設定
            //_chartStockOrderListCndtn = this._stockConfListCndtnWork; 

			// データ抽出
            // ----------
            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "抽出中";
            pd.Message = "現在、データ抽出中です。";

            int status = 0;

            try
            {
                pd.Show();
                status = this.SearchData(stockConfListCndtnWork);
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

            this._stockConfListCndtnWork = stockConfListCndtnWork;


			printInfo.rdData = this._printBuffDataSet;
#endif

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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, e);
            // --- ADD 2010/08/26 ----------<<<<<
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.19</br>
		/// </remarks>
		public int Extract(ref object parameter)
		{
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            ExtrInfo_MAKON02247E extraInfo = new ExtrInfo_MAKON02247E();     // 抽出条件クラス

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
          System.Windows.Forms.Application.Run(new MAKON02240UA());
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note: 2020/02/27 3H 尹安</br>
        /// <br>管理番号   : 11570208-00 軽減税率対応</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            // 日付初期値
			DateTime staratDate;
			DateTime endDate;
			this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

			this.StockDateStRF_tDateEdit.SetDateTime(DateTime.MinValue);
			this.StockDateEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //this.InputDayStRF_tDateEdit.SetDateTime(staratDate);
            //this.InputDayEdRF_tDateEdit.SetDateTime(endDate);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this.StockDateStRF_tDateEdit.SetDateTime(staratDate);
            this.StockDateEdRF_tDateEdit.SetDateTime(endDate);
            // --- ADD 2008/07/16 --------------------------------<<<<<

            //this.PrintOder_tComboEditor.SelectedIndex = 0;  // DEL 2008/07/16
            this.PrintOder_tComboEditor.SelectedIndex = 3;    // ADD 2008/07/16

            this.tComboEditor_SupplierSlipCd.SelectedIndex = 0;
            this.tComboEditor_DebitNoteDiv.SelectedIndex = 0;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this.tComboEditor_NewPage.SelectedIndex = 0;           // 改頁
            this.tComboEditor_PrintType.SelectedIndex = 0;         // 発行タイプ
            this.tComboEditor_OutputDesignated.SelectedIndex = 0;  // 出力指定
            this.tComboEditor_StockOrderDivCd.SelectedIndex = 0;   // 在取指定
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字コンボボックスの初期値を設定
            this.tComboEditor_TaxPrintDiv.Value = 1;
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

            // ガイドボタンイメージ設定
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            SalesAreaCodeSt_GuidBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeSt_GuidBtn.Appearance.Image = Size16_Index.STAR1;
            SalesAreaCodeEd_GuidBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeEd_GuidBtn.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            // --- ADD cheq 2012/12/26 Redmine#34098---------->>>>>
            // 罫線印字
            this.tComboEditor_LinePrintDiv.Value = 0;
            uiMemInput1.ReadMemInput();
            // --- ADD cheq 2012/12/26 Redmine#34098----------<<<<<
        }

        // --- 2010/08/16 ---------->>>>>
        #region ◎ F5：ガイドの実行
        /// <summary>
        /// F5：ガイドの実行
        /// </summary>
        /// <returns></returns>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tEdit_StockAgentCode_St.Focused)
            {
                SalesEmployeeCdSt_GuideBtn_Click(SalesEmployeeCdSt_GuideBtn, e);
                this.tEdit_StockAgentCode_St.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_StockAgentCode_St.Name, this.tEdit_StockAgentCode_St.Text);
            }
            else if (this.tEdit_StockAgentCode_Ed.Focused)
            {
                SalesEmployeeCdEd_GuideBtn_Click(SalesEmployeeCdEd_GuideBtn, e);
                this.tEdit_StockAgentCode_Ed.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_StockAgentCode_Ed.Name, this.tEdit_StockAgentCode_Ed.Text);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused) 
            {
                SalesAreaCodeSt_GuidBtn_Click(SalesAreaCodeSt_GuidBtn, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                SalesAreaCodeEd_GuidBtn_Click(SalesAreaCodeEd_GuidBtn, e);
            }
            else if (this.tNedit_SupplierCd_St.Focused) 
            {
                CustomerCdSt_GuideBtn_Click(CustomerCdSt_GuideBtn, e);
            }
            else if (this.tNedit_SupplierCd_Ed.Focused) 
            {
                CustomerCdEd_GuideBtn_Click(CustomerCdEd_GuideBtn, e);
            };
        }
        #endregion
        // --- 2010/08/16 ----------<<<<<


        /// <summary>
        /// 拠点選択コンポボックス設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報をコンポボックスに設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void SettingSectionCombList()
        {
        }


		/// <summary>
		/// 日付チェック処理呼び出し
		/// </summary>
		/// <param name="cdrResult"></param>
		/// <param name="tde_St_OrderDataCreateDate"></param>
		/// <param name="tde_Ed_OrderDataCreateDate"></param>
		/// <returns></returns>
		//private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode)
		private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int range)
        {
			//cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);

            //if (mode == false)  // DEL 2008/07/16
            // 入力日範囲チェック？
            if (tde_St_OrderDataCreateDate.Name == "InputDayStRF_tDateEdit")  // ADD 2008/07/16
			{
				if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver)
				{
					cdrResult = DateGetAcs.CheckDateRangeResult.OK;
				}
			}

			return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
		}

        // ADD 2008/10/23 不具合対応[6521]---------->>>>>
        /// <summary>
        /// 入力日付チェック処理呼び出し(範囲チェックなし、未入力OK)
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="tde_St_AddUpADate">入力日（開始）</param>
        /// <param name="tde_Ed_AddUpADate">入力日（終了）</param>
        /// <param name="mode">モード</param>
        /// <param name="range">範囲</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit tde_St_AddUpADate,
            ref TDateEdit tde_Ed_AddUpADate,
            bool mode,
            int range
        )
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2008/10/23 不具合対応[6521]----------<<<<<

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

			DateGetAcs.CheckDateRangeResult cdrResult;

			// 仕入日付（開始～終了）
			//if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, true) == false)  // DEL 2008/07/16
            //if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, false, 3) == false)   // ADD 2008/07/16 // DEL 2009/04/07
            if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, true, 0) == false)   // ADD 2009/04/07
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //{
                        //    message = string.Format("開始仕入日{0}", ct_NoInput);
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        //return true; // ADD 2009/04/07 // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始仕入日{0}", ct_InputError);
                            errControl = this.StockDateStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //{
                        //    message = string.Format("終了仕入日{0}", ct_NoInput);
                        //    errControl = this.StockDateEdRF_tDateEdit;
                        //}
                        //break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        //return true; // ADD 2009/04/07 // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了仕入日{0}", ct_InputError);
                            errControl = this.StockDateEdRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("仕入日{0}", ct_RangeError);
                            errControl = this.StockDateStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    // --- ADD 2008/07/16 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("仕入日{0}", ct_RangeOverError);
                    //        errControl = this.StockDateStRF_tDateEdit;
                    //    }
                    //    break;
                    //// --- ADD 2008/07/16 --------------------------------<<<<<
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                //result = false; // DEL 2009/04/07
                //return result; // DEL 2009/04/07
            }
            else
            {
                result = true;
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            if (!result)
            {
                return result;
            }
            else
            {
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // XMLの税率情報取得
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                if (errMsg != string.Empty)
                {
                    message = errMsg;
                    errControl = this.tComboEditor_TaxPrintDiv;
                    return result;
                }
            }
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
			// 入力日付（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false) == false)  // DEL 2008/07/16
            // DEL 2008/10/14 不具合対応[6521]↓
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 1) == false)     // ADD 2008/07/16
            // DEL 2008/10/23 不具合対応[6521]↓
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 3) == false)   // ADD 2008/10/16 不具合対応[6521]
            if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 3) == false)   // ADD 2008/10/23 不具合対応[6521]
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        // DEL 2008/10/23 不具合対応[6521]---------->>>>>
                        //{
                        //    message = string.Format("開始入力日{0}", ct_NoInput);
                        //    errControl = this.InputDayStRF_tDateEdit;
                        //}
                        //break;
                        // DEL 2008/10/23 不具合対応[6521]----------<<<<<
                        //return true;    // ADD 2008/10/23 不具合対応[6521] // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始入力日{0}", ct_InputError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        // DEL 2008/10/23 不具合対応[6521]---------->>>>>
                        //{
                        //    message = string.Format("終了入力日{0}", ct_NoInput);
                        //    errControl = this.InputDayEdRF_tDateEdit;
                        //}
                        //break;
                        // DEL 2008/10/23 不具合対応[6521]----------<<<<<
                        //return true;    // ADD 2008/10/23 不具合対応[6521] // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了入力日{0}", ct_InputError);
                            errControl = this.InputDayEdRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("入力日{0}", ct_RangeError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            message = string.Format("入力日{0}", ct_RangeOverError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                }
                //result = false; // DEL 2009/04/07
                //return result; // DEL 2009/04/07
            }
            else
            {
                result = true;
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            if (!result)
            {
                return result;
            }
            else
            {
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            // 担当者コード範囲チェック
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if ((this.tEdit_StockAgentCode_Ed.Text != "") &&
            //    (this.tEdit_StockAgentCode_St.Text.CompareTo(this.tEdit_StockAgentCode_Ed.Text) > 0))
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            if ((this.tEdit_StockAgentCode_St.Text != "") && (this.tEdit_StockAgentCode_Ed.Text != ""))
            {
                if (Int32.Parse(this.tEdit_StockAgentCode_St.Text) > Int32.Parse(this.tEdit_StockAgentCode_Ed.Text)) 
                {
                    message = "担当者の範囲に誤りがあります";
                    errControl = this.tEdit_StockAgentCode_Ed;
                    return result;
                }
            }

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 地区チェック
            if ((this.tNedit_SalesAreaCode_St.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt()) > (this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                message = "地区の範囲に誤りがあります";
                errControl = this.tNedit_SalesAreaCode_Ed;
                return result;
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // 仕入先コード範囲チェック
            if ((this.tNedit_SupplierCd_St.GetInt() != 0) &&
				(this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                (this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
            {
                message = "仕入先の範囲に誤りがあります";
                errControl = this.tNedit_SupplierCd_Ed;
                return result;
            }

            // 仕入SEQ番号範囲チェック
            if ((this.AcceptAnOrderNoSt_tNedit.GetInt() !=0) &&
				(this.AcceptAnOrderNoEd_tNedit.GetInt() != 0) &&
                (this.AcceptAnOrderNoSt_tNedit.GetInt()) > (this.AcceptAnOrderNoEd_tNedit.GetInt()))
            {
                message = "仕入SEQ番号の範囲に誤りがあります";
				errControl = this.AcceptAnOrderNoEd_tNedit;
                return result;
            }

			// 伝票番号範囲チェック
			if ((this.PartySaleSlipNumEd_tEdit.Text != "") &&
                (this.PartySaleSlipNumSt_tEdit.Text.CompareTo(this.PartySaleSlipNumEd_tEdit.Text) > 0))
			{
				message = "伝票番号の範囲に誤りがあります";
				errControl = this.PartySaleSlipNumSt_tEdit;
				return result;
			}

            return true;        
        }


        /// <summary>
		/// 
		/// </summary>
		/// <param name="goodsCndtn"></param>
		/// <returns></returns>
        private int SearchData(ExtrInfo_MAKON02247E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件が変わっているならリモーティング
            if (this._printBuffDataSet == null || this._stockConfListCndtnWork == null || !this._stockConfListCndtnWork.Equals(extraInfo))
            {
                try
                {
                    status = this._stockConfListAcs.Search(extraInfo, out message, 0);
                    if (status == 0)
                    {
                        this._printBuffDataSet = this._stockConfListAcs._printDataSet;
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
                            this._stockConfListCndtnWork = extraInfo.Clone();

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
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_StockConfDataTable].Rows.Count == 0)
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;


        }

        
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
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
              // 月        表示時
            case emDateFormat.df2M     :
              if (mm == 0) return false;
              break;
              // 日        表示時
            case emDateFormat.df2D     :
              if (dd == 0) return false;
              break;
            }
                 
            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD",date);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
            
        }
            
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面→抽出条件へ設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note: 2020/02/27 3H 尹安</br>
        /// <br>管理番号   : 11570208-00 軽減税率対応</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(ref ExtrInfo_MAKON02247E extraInfo)
        {
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
					extraInfo.StockSectionCd = new string[1];
					extraInfo.StockSectionCd[0] = "0";
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
					extraInfo.StockSectionCd = (string[])secList.ToArray(typeof(string));
                }
            }
            // 拠点オプションなしの時
            else
            {
				extraInfo.StockSectionCd = new string[0];
            }

            // 伝票日付(開始)        
            extraInfo.StockDateSt = this.StockDateStRF_tDateEdit.GetLongDate();
			// 伝票日付(終了)        
            extraInfo.StockDateEd = this.StockDateEdRF_tDateEdit.GetLongDate();
            // 入荷日付(開始)        
            extraInfo.ArrivalGoodsDaySt = 0;
			// 入荷日付(終了)        
            extraInfo.ArrivalGoodsDayEd = 0;
			// 入力日付(開始)        
			extraInfo.InputDaySt = this.InputDayStRF_tDateEdit.GetLongDate();
			// 入力日付(終了)        
			extraInfo.InputDayEd = this.InputDayEdRF_tDateEdit.GetLongDate();
            // 発行タイプ
			//extraInfo.PrintType = Convert.ToInt32(this.ultraOptionSet_RowDetailMode.CheckedIndex);  // DEL 2008/07/16
            extraInfo.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.SelectedIndex);         // ADD 2008/07/16
            // 出力順
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// 得意先(開始)
            //extraInfo.CustomerCodeSt = this.tNedit_SupplierCd_St.GetInt();
            //// 得意先(終了)
            //extraInfo.CustomerCodeEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 仕入先(開始)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();

            // 仕入先(終了)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // 伝票区分
            extraInfo.SupplierSlipCd = Convert.ToInt32(this.tComboEditor_SupplierSlipCd.SelectedItem.DataValue);
            // 赤伝区分
            extraInfo.DebitNoteDiv = Convert.ToInt32(this.tComboEditor_DebitNoteDiv.SelectedItem.DataValue) - 1;

            // 担当コード(開始)
            extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            // 担当コード(終了)
            extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;

            // 伝票番号(開始)
            extraInfo.SupplierSlipNoSt = this.AcceptAnOrderNoSt_tNedit.GetInt();
            // 伝票番号(終了)
            extraInfo.SupplierSlipNoEd = this.AcceptAnOrderNoEd_tNedit.GetInt();

			// 相手先伝票番号(開始)
			extraInfo.PartySaleSlipNumSt = this.PartySaleSlipNumSt_tEdit.Text;
			// 相手先伝票番号(終了)
			extraInfo.PartySaleSlipNumEd = this.PartySaleSlipNumEd_tEdit.Text;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 地区(開始)
            extraInfo.SalesAreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();

            // 地区(終了)
            extraInfo.SalesAreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

            // 出力指定
            extraInfo.OutputDesignated = (Int32)this.tComboEditor_OutputDesignated.SelectedItem.DataValue;

            // 在取指定
            extraInfo.StockOrderDivCd = (int)this.tComboEditor_StockOrderDivCd.SelectedItem.DataValue;

            // 改頁区分
            extraInfo.NewPageKind = (int)this.tComboEditor_NewPage.SelectedItem.DataValue;  
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字区分
            extraInfo.TaxPrintDiv = Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue);
            // XMLの税率情報取得
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                // 税率1
                extraInfo.TaxRate1 = taxRatePrintInfo.TaxRate1;
                // 税率2
                extraInfo.TaxRate2 = taxRatePrintInfo.TaxRate2;
            }
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

            //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>> 
            // 罫線印字
            extraInfo.LinePrintDiv = (int)this.tComboEditor_LinePrintDiv.SelectedItem.DataValue;
            //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
            // 日計印字
            extraInfo.PrintDailyFooter = (int)this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue; // ADD 2009/04/14
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            _StockConfDataTable = Broadleaf.Application.UIData.MAKON02249EA.CT_StockConfDataTable;
        }

        /// <summary>
        /// キャリアリスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2006.09.08</br>
        /// </remarks>
        //private void GetCarrierList()
        //{
#if False
			// キャリアマスタ読込
            // ----- iitani c ---------- start 2007.05.22
            //CarrierAcs carrierAcs = new CarrierAcs();
            //ArrayList retList = new ArrayList();
            //int status = carrierAcs.Search(out retList, this._enterpriseCode);
            //foreach (CarrierU carrierU in retList)
            //{
            //    this._carrierList.Add(carrierU.CarrierCode, carrierU.CarrierName);
            //}
            CarrierOdrAcs carrierOdrAcs = new CarrierOdrAcs();
            List<Carrier> retList = new List<Carrier>();
            int status = carrierOdrAcs.SearchLocalDB(out retList, this._enterpriseCode, this._ownSectionCode);

            foreach (Carrier carrier in retList)
            {
                this._carrierList.Add(carrier.CarrierCode, carrier.CarrierName);
                this._carrierDspList.Add(carrier.CarrierName);
            }
            // ----- iitani c ---------- start 2007.05.22
#endif
        //}

        /// <summary>
        /// 最上位フォーム取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2006.09.08</br>
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.30</br>
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
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void SFUKK01390UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._stockConfListAcs = new StockConfAcs();

            // 最上位フォーム取得
		    this.GetTopForm();

            // 拠点オプション有無を取得する
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 本社/拠点情報を取得する
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
            ParentToolbarGuideSettingEvent(true); // ADD 2010/08/16

            // キャリアリスト取得
            //this.GetCarrierList();

            // --- ADD 2009/04/14 -------------------------------->>>>>
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_PrintDailyFooter);
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
        /// <br>Note       : 元帳メイン画面がアクティブになったときのイベント処理です。</br>
        /// <br>Programer  : 18012　Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
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
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2020/02/27 3H 尹安</br>
        /// <br>管理番号    : 11570208-00 軽減税率対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

            // --- ADD 2010/08/16 --- >>>>>
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tComboEditor_NewPage":
                    case "PrintOder_tComboEditor":
                    case "tComboEditor_SupplierSlipCd":
                    case "tComboEditor_DebitNoteDiv":
                    case "tComboEditor_PrintType":
                    case "tComboEditor_OutputDesignated":
                    case "tComboEditor_StockOrderDivCd":
                    case "tComboEditor_LinePrintDiv": // ADD cheq 2012/12/26 Redmine#34098
                    case "tComboEditor_TaxPrintDiv":  // ADD 3H 尹安 2020/02/27
                        this._preCtrlName = (TComboEditor)e.PrevCtrl;
                        this.setTComboEditorByName(e.PrevCtrl.Name);
                        this.CustomerCdSt_GuideBtn.Focus();
                        this._preCtrlName.Focus();
                        break; ;

                }
            }
            if (e.NextCtrl != null && (e.NextCtrl is TComboEditor))
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }

            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            // --- ADD 2010/08/16 --- <<<<<

            // 入力支援 ============================================ //
            // 仕入日
            if ((e.PrevCtrl == this.StockDateStRF_tDateEdit) ||
                (e.PrevCtrl == this.StockDateEdRF_tDateEdit))
            {
                //AutoSetEndValue(this.StockDateStRF_tDateEdit, this.StockDateEdRF_tDateEdit);
            }

            // ADD 2008/10/07 不具合対応[5639]---------->>>>>
            // 出力順から担当者へ遷移
            if (e.PrevCtrl == this.PrintOder_tComboEditor)
            {
                // 2009.01.09 30413 犬飼 Shift+TABでも担当者に遷移するのを修正 >>>>>>START
                //e.NextCtrl = this.tEdit_StockAgentCode_St;
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tEdit_StockAgentCode_St;
                }
                // 2009.01.09 30413 犬飼 Shift+TABでも担当者に遷移するのを修正 <<<<<<END
            }
            // ADD 2008/10/07 不具合対応[5639]----------<<<<<

            // 仕入先コード
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                //AutoSetEndValue(this.CustomerCodeStRF_Nedit, this.CustomerCodeEdRF_Nedit);
            }

            // 担当コード
            if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
            {
                //AutoSetEndValue(this.StockAgentCodeSt_tEdit, this.StockAgentCodeEd_tEdit);
            }

            // 伝票番号
            if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
            {
                //AutoSetEndValue(this.AcceptAnOrderNoSt_tNedit, this.AcceptAnOrderNoEd_tNedit);
            }
            //  ---ADD 2010/08/12----------<<<<<<<

            // ADD 2010/08/16   ----  >>>>>>>
            if (e.Key == Keys.Left)
            {
                if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                {
                    // 在庫取寄指定 → 出力指定
                    e.NextCtrl = this.tComboEditor_OutputDesignated;
                }
                else if (e.PrevCtrl == tComboEditor_OutputDesignated)
                {
                    // 出力指定     →  発行タイプ
                    e.NextCtrl = this.tComboEditor_PrintType;
                }
                else if (e.PrevCtrl == tComboEditor_PrintType)
                {
                    // 発行タイプ   → 赤伝区分
                    e.NextCtrl = this.tComboEditor_DebitNoteDiv;
                }
                else if (e.PrevCtrl == this.tComboEditor_DebitNoteDiv)
                {
                    // 赤伝区分   →  伝票区分
                    e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                }
                else if (e.PrevCtrl == this.tComboEditor_SupplierSlipCd)
                {
                    //  伝票区分  →  伝票番号(終了)
                    e.NextCtrl = this.PartySaleSlipNumEd_tEdit;
                }
                else if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                {
                    //  伝票番号(終了)  →  伝票番号(開始)
                    e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                }
                else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                {
                    //  伝票番号(開始)  → 仕入SEQ番号(終了)
                    e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                }
                else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                {
                    //  仕入SEQ番号(終了)  →  仕入SEQ番号(開始)
                    e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                }
                else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                {
                    //  仕入SEQ番号(開始)  → 仕入先 (終了)
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
                else if (e.PrevCtrl == tNedit_SupplierCd_Ed)
                {
                    // 仕入先 (終了)   →  仕入先 (開始) 
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // 仕入先 (開始)  →  地区(終了) 
                    e.NextCtrl = tNedit_SalesAreaCode_Ed;
                }
                else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                {
                    //  地区(終了) →  地区(開始) 
                    e.NextCtrl = tNedit_SalesAreaCode_St;
                }
                else if (e.PrevCtrl == tNedit_SalesAreaCode_St)
                {
                    //  地区(開始)  →  担当者(終了)
                    e.NextCtrl = tEdit_StockAgentCode_Ed;
                }
                else if (e.PrevCtrl == tEdit_StockAgentCode_Ed)
                {
                    // 担当者(終了) → 担当者(開始)
                    e.NextCtrl = tEdit_StockAgentCode_St;
                }
                else if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                {
                    // 担当者(開始) → 出力順
                    e.NextCtrl = PrintOder_tComboEditor;
                }
                /*----- DEL 2012/12/26 cheq Redmine#34098 ----->>>>> 
                else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                {
                    // 出力順 →日計印字
                    e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                }
                ----- DEL 2012/12/26 cheq Redmine#34098 -----<<<<<*/
                //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>                
                else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                {
                    // --- DEL START 3H 尹安 2020/02/27 ----->>>>>            
                    //    // 出力順 →罫線印字
                    //    e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    // --- DEL END 3H 尹安 2020/02/27 -----<<<<<
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 出力順 → 税別内訳印字
                    e.NextCtrl = this.tComboEditor_TaxPrintDiv;
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                {
                    // 税別内訳印字 → 改頁
                    e.NextCtrl = this.tComboEditor_NewPage;
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                {
                    // 罫線印字 →日計印字
                    e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                }
                //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
                else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                {
                    // 日計印字 → 改頁
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());        
                    e.NextCtrl = this.tComboEditor_NewPage;
                }
                else if (e.PrevCtrl == this.tComboEditor_NewPage)
                {
                    // 改頁 → 入力日(終了)
                    e.NextCtrl = this.InputDayEdRF_tDateEdit.Controls[3];
                }
                else if (e.PrevCtrl == this.InputDayEdRF_tDateEdit)
                {
                    // 入力日(終了) → 入力日(開始)
                    e.NextCtrl = this.InputDayStRF_tDateEdit;
                }
                else if (e.PrevCtrl == this.InputDayStRF_tDateEdit)
                {
                    // 入力日(開始) → 仕入日(終了)
                    e.NextCtrl = this.StockDateEdRF_tDateEdit.Controls[3];
                }
                else if (e.PrevCtrl == this.StockDateEdRF_tDateEdit)
                {
                    // 仕入日(終了) → 仕入日(開始)
                    e.NextCtrl = this.StockDateStRF_tDateEdit;
                }
                else if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                {
                    // 仕入日(開始)  → 仕入日(開始)
                     e.NextCtrl = null;
                }
            }
            if (!e.ShiftKey)
            {
                if ((e.Key == Keys.Right) || (e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                    {
                        // 仕入日(開始)　→　仕入日(終了)
                        e.NextCtrl = this.StockDateEdRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.StockDateEdRF_tDateEdit)
                    {
                        // 仕入日(終了) →　入力日(開始)
                        e.NextCtrl = this.InputDayStRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.InputDayStRF_tDateEdit)
                    {
                        // 入力日(開始) → 入力日(終了)
                        e.NextCtrl = this.InputDayEdRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.InputDayEdRF_tDateEdit)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// 入力日(終了)  →  改頁 
                        //e.NextCtrl = this.tComboEditor_NewPage;
                        // 入力日(終了)  →  罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_NewPage)
                    {
                        // --- DEL START 3H 尹安 2020/02/27 ----->>>>>
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        ////// 改頁  →   日計印字
                        ////e.NextCtrl = ultraOptionSet_PrintDailyFooter;
                        //// 改頁  →   出力順
                        //e.NextCtrl = this.PrintOder_tComboEditor;
                        //// UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                        //this.ultraOptionSet_PrintDailyFooter.FocusedIndex = this.ultraOptionSet_PrintDailyFooter.CheckedIndex;
                        // --- DEL END 3H 尹安 2020/02/27 -----<<<<<
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 改頁  →   税別内訳印字
                        e.NextCtrl = this.tComboEditor_TaxPrintDiv;
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                    {
                        // 税別内訳印字  →   出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    /*----- DEL 2012/12/26 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                    {
                        // 日計印字  → 出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    ----- DEL 2012/12/26 cheq Redmine#34098 -----<<<<<*/
                    //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// 日計印字  → 罫線印字
                        //e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        // 日計印字  → 改頁
                        e.NextCtrl = this.tComboEditor_NewPage;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// 罫線印字  → 出力順
                        //e.NextCtrl = this.PrintOder_tComboEditor;
                        // 罫線印字  → 日計印字
                        e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // 出力順  → 担当者(開始)
                        e.NextCtrl = this.tEdit_StockAgentCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                    {
                        // 担当者(開始) → 担当者(終了)
                        e.NextCtrl = this.tEdit_StockAgentCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_StockAgentCode_Ed)
                    {
                        // 担当者(終了) → 地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始) → 地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了) → 仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始) → 仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了) → 仕入SEQ番号(開始)
                        e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                    {
                        // 仕入SEQ番号(開始) → 仕入SEQ番号(終了)
                        e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                    {
                        // 仕入SEQ番号(終了) → 伝票番号(開始)
                        e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                    {
                        // 伝票番号(開始) → 伝票番号(終了)
                        e.NextCtrl = this.PartySaleSlipNumEd_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                    {
                        // 伝票番号(終了) → 伝票区分
                        e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SupplierSlipCd)
                    {
                        // 伝票区分  →  赤伝区分
                        e.NextCtrl = this.tComboEditor_DebitNoteDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_DebitNoteDiv)
                    {
                        // 赤伝区分  →  発行タイプ
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 発行タイプ → 出力指定
                        e.NextCtrl = this.tComboEditor_OutputDesignated;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDesignated)
                    {
                        // 出力指定   → 在庫取寄指定
                        e.NextCtrl = this.tComboEditor_StockOrderDivCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                    {
                        // 在庫取寄指定 → 仕入日(開始)
                        e.NextCtrl = this.StockDateStRF_tDateEdit;
                    }
                    if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                    {
                        // --- ADD 2010/08/26 ---------->>>>>
                        if (this.ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }
                        // --- ADD 2010/08/26 ----------<<<<<
                        e.NextCtrl = null;
                    }
                }

                if (e.NextCtrl != null)
                {
                    switch (e.NextCtrl.Name)
                    {
                        case "tEdit_StockAgentCode_St":
                        case "tEdit_StockAgentCode_Ed":
                        case "tNedit_SalesAreaCode_St":
                        case "tNedit_SalesAreaCode_Ed":
                        case "tNedit_SupplierCd_St":
                        case "tNedit_SupplierCd_Ed":
                            {
                                ParentToolbarGuideSettingEvent(true);
                                break;
                            }
                        default:
                            {
                                if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                    || e.NextCtrl is TDateEdit || e.NextCtrl is UltraOptionSet || e.NextCtrl is UltraButton)
                                {
                                    ParentToolbarGuideSettingEvent(false);
                                }
                                break;
                            }
                    }
                }
                
            }
            else
            {
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                    {
                        e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                    {
                        e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                    {
                        e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_St;                   
                    }
                    else if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                    {
                        e.NextCtrl = null;
                    }
                }
            }
            // --- 2010/08/16 ----------<<<<<
        }

        /// <summary>
        /// 初期タイマーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 初期処理を行います。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面初期表示
            this.InitialScreenSetting();
        
            // 初期フォーカス設定
			//this.InputDayStRF_tDateEdit.Focus();  // DEL 2008/07/16
            this.StockDateStRF_tDateEdit.Focus();   // ADD 2008/07/16

    	    // メインフレームにツールバー設定通知
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);

            // ADD 2008/10/07 不具合対応[5639]---------->>>>>
            // 範囲指定ガイドのフォーカス制御オブジェクトの設定
            // 担当者：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_St,
                this.SalesEmployeeCdSt_GuideBtn,
                this.tEdit_StockAgentCode_Ed
            ));
            // 担当者：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_Ed,
                this.SalesEmployeeCdEd_GuideBtn,
                this.tNedit_SalesAreaCode_St
            ));

            // 地区：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SalesAreaCode_St,
                this.SalesAreaCodeSt_GuidBtn,
                this.tNedit_SalesAreaCode_Ed
            ));
            // 地区：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SalesAreaCode_Ed,
                this.SalesAreaCodeEd_GuidBtn,
                this.tNedit_SupplierCd_St
            ));

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
                this.AcceptAnOrderNoSt_tNedit
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            // ADD 2008/10/07 不具合対応[5639]----------<<<<<
	    }

    	        
        /// <summary>
        /// Control.GroupCollapsingイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : エクスプローラバーのグループを展開される際に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.14</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
		    if (this._explorerBarExpanding) return;

		    this._explorerBarExpanding = true;

		    try
		    {
                if (!e.Group.Key.Equals(EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
			    {
				    e.Cancel = true;
			    }
		    }
		    finally
		    {
			    this._explorerBarExpanding = false;
		    }
        }

	    #endregion


	    #region IPrintConditionInpTypeChart メンバ


	    #endregion

	    #region IPrintConditionInpTypeSelectedSection メンバ

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
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note       : 選択されている拠点を設定します</br>
        /// <br>Programmer : 22021　谷藤　範幸</br>
        /// <br>Date       : 2006.02.14</br>
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
        /// <param name="IsOptSection"></param>
        /// <remarks>
        /// <br>Note       : 拠点オプション取得プロパティ</br>
        /// <br>Programmer : 22021 谷藤　範幸</br>
        /// <br>Date       : 2006.03.22</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary>
        /// 本社機能取得プロパティ
        /// </summary>
        /// <param name="IsMainOfficeFunc"></param>
        /// <remarks>
        /// <br>Note       : 本社機能取得プロパティ</br>
        /// <br>Programmer : 22021 谷藤　範幸</br>
        /// <br>Date       : 2006.03.22</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary>
        /// 計上拠点選択処理
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note       : 計上拠点選択処理</br>
        /// <br>Programmer : 22021 谷藤　範幸</br>
        /// <br>Date       : 2006.01.19</br>
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
        /// <br>Programmer : 22021　谷藤　範幸</br>
        /// <br>Date       : 2006.02.14</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            this._selectedAddUpCd = addUpCd;
            return;
        }


        #endregion
        
        #region [--- DEL 2008/12/02 G.Miyatsu ---]
        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した得意先コード(開始)を画面に表示する
        //        this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した得意先は既に削除されています。",
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
        //            "得意先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}

        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 取得した得意先コード(終了)を画面に表示する
        //        this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した得意先は既に削除されています。",
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
        //            "得意先情報の取得に失敗しました。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}
        # endregion

        #region ■ガイド起動イベント
        /// <summary>
        /// 得意先コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
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
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;            
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 
        }
        #endregion

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
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
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(false);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 
        }

        /// <summary>
        /// 受付従業員コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド起動
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // 項目に展開
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 受付従業員コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド起動
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // 項目に展開
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		private void Main_ultraExplorerBar_GroupCollapsing_1(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}

		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}

        /// <summary>
        /// 地区(開始)ガイドボタン クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 地区(販売エリア)ガイドを起動します。 </br>
        /// <br>Programmer  : 30415 柴田 倫幸</br>
        /// <br>Date        : 2008/07/16</br>
        /// </remarks>
        private void SalesAreaCodeSt_GuidBtn_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_userGuideAcs == null)
                {
                    _userGuideAcs = new UserGuideAcs();
                }

                // ユーザーガイド起動
                if (_userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 21) == 0)
                {
                    // DELL 2008/10/02 不具合対応[5638]↓
                    //this.tNedit_SalesAreaCode_St.Text = userGdBd.GuideCode.ToString();
                    this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);    // ADD 2008/10/02 不具合対応[5638]
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                   
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// 地区(終了)ガイドボタン クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 地区(販売エリア)ガイドを起動します。 </br>
        /// <br>Programmer  : 30415 柴田 倫幸</br>
        /// <br>Date        : 2008/07/16</br>
        /// </remarks>
        private void SalesAreaCodeEd_GuidBtn_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_userGuideAcs == null)
                {
                    _userGuideAcs = new UserGuideAcs();
                }

                // ユーザーガイド起動
                if (_userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 21) == 0)
                {
                    // DELL 2008/10/02 不具合対応[5638]↓
                    //this.tNedit_SalesAreaCode_Ed.Text = userGdBd.GuideCode.ToString();
                    this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);    // ADD 2008/10/02 不具合対応[5638]
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //---ADD 2010/08/16---------->>>>>
        /// <summary>
        /// コードからの選択を可能へ変更する
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 出力順制御の対応</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            switch (control.Name)
            {
                // 出力順
                case "PrintOder_tComboEditor":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:仕入先→仕入日→仕入SEQ番号":
                                control.Value = 5;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:仕入先→入力日→仕入SEQ番号":
                                control.Value = 6;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:仕入先→仕入日→伝票番号":
                                control.Value = 1;
                                inputErrorFlg = false;
                                break;
                            case "3":
                            //case "3:仕入先→入力日→仕入SEQ番号": // DEL cheq 2012/12/26 Redmine#34098
                            case "3:仕入先→入力日→伝票番号": // ADD cheq 2012/12/26 Redmine#34098
                                control.Value = 3;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                // 伝票区分
                case "tComboEditor_SupplierSlipCd":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:全て":
                                control.Value = 0;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:仕入":
                                control.Value = 10;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:返品":
                                control.Value = 20;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                // 在庫取寄指定
                case "tComboEditor_StockOrderDivCd":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:全て":
                                control.Value = -1;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:在庫":
                                control.Value = 1;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:取寄":
                                control.Value = 0;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                default:
                    {
                        foreach (Infragistics.Win.ValueListItem item in control.Items)
                        {
                            if (item.DataValue == control.Value)
                            {
                                inputErrorFlg = false;
                                break;
                            }
                        }
                    }
                    break;
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }

        //---ADD 2010/08/16----------<<<<<
        /// <summary>
        /// ultraOptionSet_PrintDailyFooter_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private void ultraOptionSet_PrintDailyFooter_KeyDown(object sender, KeyEventArgs e)
        {
            this.ultraOptionSet_PrintDailyFooter.FocusedIndex = this.ultraOptionSet_PrintDailyFooter.CheckedIndex;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        this.tComboEditor_NewPage.Focus();
                        break;
                    }
                case Keys.Right:
                    {
                        //this.PrintOder_tComboEditor.Focus(); // DEL cheq 2012/12/26 Redmine#34098
                        this.tComboEditor_LinePrintDiv.Focus(); // ADD cheq 2012/12/26 Redmine#34098

                        break;
                    }
                default:
                    break;
            }
        }

        //---ADD 2010/08/16----------<<<<<
        // --- ADD START 3H 尹安 2020/02/27---------->>>>>
        # region [印刷用税率情報XML]
        /// <summary>
        /// 印刷用税率情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>印刷用税率設定情報税率１</summary>
            private string _taxRate1;
            /// <summary>印刷用税率設定情報税率２</summary>
            private string _taxRate2;

            /// <summary>印刷用税率設定情報税率１</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>印刷用税率設定情報税率２</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }
        # endregion
        # region[デシリアライズ処理]
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <returns>デシリアライズ結果</returns>
        /// <remarks> 
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // 印刷用税率情報XMLファイル存在の判断
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName));
                    // 税率設定情報税率１
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // 税率設定情報税率２
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // 税率未設定の場合、
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // 同じ税率値の場合
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // 数字以外の場合、
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // 税率値はマイナスの場合
                        (dTaxRate1 < 0) || (dTaxRate2 < 0) ||
                        // 税率値は10以上の場合
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "税率設定情報が正しく設定されていません。";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "税率設定情報が正しく設定されていません。";
                    return status;
                }
            }
            else
            {
                errmsg = "税率設定情報ファイル(" + ctPrintXmlFileName + ")が存在しません。";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL; ;
        }
        # endregion        
        // --- ADD END 3H 尹安 2020/02/27----------<<<<<
    }
}
