//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上確認表
// プログラム概要   : 売上確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 飯谷 耕平
// 作 成 日  2007/05/14  修正内容 : 商品区分コード、商品区分グループコードの型・桁変更に伴う修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 飯谷 耕平
// 修 正 日  2007/06/01  修正内容 : キャリアの一覧を、キャリア表示順位アクセスクラスから読むように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 矢田 敬吾
// 修 正 日  2007/11/08  修正内容 : 出荷日付を入力日付に変更、商品コードを入力者コードに変更
//                                  出力単位を削除、キャリア、売上形式、販売形態を削除、商品区分グループ、商品区分を削除
//                                  出力順を変更・追加、粗利チェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/07/07  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13161
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応10247,11302,10743,11402
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/12  修正内容 : 障害対応13453
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/02/22  修正内容 : 障害対応15018
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/06/08  修正内容 : 指定条件のみ印刷項目の粗利率の入力可能桁数を99.9⇒999.99へ変更（デザインのみ修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :       魯志明
// 修 正 日  2010/08/16  修正内容 : 障害改良対応8月　キーボード操作の改良を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/29  修正内容 : 障害対応Redmine#8182
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2012/01/30  修正内容 : 障害対応Redmine#28202
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張曼
// 修 正 日  2012/11/06  修正内容 : 10801804-00、12月12日配信分、Redmine#33216 PM.NS障害一覧No.1587の対応
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2013/01/04  修正内容 : 2013/03/13配信分　Redmine#34098
//                                  罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 王君
// 修 正 日  2013/02/27  修正内容 : 2013/03/13配信分　Redmine#34098
//                                  罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号 10900690-00  作成担当 : cheq
// 修 正 日  2013/03/11  修正内容 : 2013/03/26配信分　Redmine#34987
//                                  フォーカス遷移の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10970681-00 作成担当：陳健
// 修正日    K2014/02/06 修正内容：前橋京和商会個別 売上確認表改良対応
// ---------------------------------------------------------------------------//
// 管理番号  10970681-00 作成担当：陳健
// 修正日    2014/02/21  修正内容：Redmine#42039 OperationCode 3->90;4->91
// ---------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当：3H 尹安
// 修正日    2020/02/27  修正内容：軽減税率対応
// ---------------------------------------------------------------------------//

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
using Broadleaf.Application.Controller.Util;    // ADD 2008/04/01 不具合対応[12909]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinEditors;　 // ADD 2010/08/16
using Infragistics.Win.Misc; 　　　　　　　// ADD 2010/08/16
using Broadleaf.Application.Controller.Facade;  // ADD 陳健 K2014/02/06
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
    /// <br>UpdateNote	: ・商品区分コード、商品区分グループコードの型・桁変更に伴う修正</br>
    /// <br>            　  （Int32 3桁 → string 5桁）</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・キャリアの一覧を、キャリア表示順位アクセスクラスから読むように修正</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・出荷日付を入力日付に変更、商品コードを入力者コードに変更</br>
    /// <br>            : ・出力単位を削除、キャリア、売上形式、販売形態を削除、商品区分グループ、商品区分を削除</br>
    /// <br>            : ・出力順を変更・追加、粗利チェックを追加</br>
    /// <br>Programmer	: 矢田 敬吾</br>
    /// <br>Date		: 2007.11.08</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・PM.NS対応</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.07.07</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応13161</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応10247,11302,10743,11402</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/13</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応15018</br>
    /// <br>Programmer	: 30434 工藤 恵優</br>
    /// <br>Date		: 2010/02/22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応Redmine#28202</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2012/01/30</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: 10801804-00、12月12日配信分、Redmine#33216 PM.NS障害一覧No.1587の対応</br>
    /// <br>Programmer	: 張曼</br>
    /// <br>Date		: 2012/11/06</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2013/01/04 田建委</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2013/02/27 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2013/03/11 cheq</br>
    /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
    /// <br>              Redmine#34987 フォーカス遷移の追加対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : K2014/02/06 陳健</br>
    /// <br>管理番号    : 10970681-00 </br>
    /// <br>              前橋京和商会個別 売上確認表改良対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2020/02/27 3H 尹安</br>
    /// <br>管理番号    : 11570208-00 </br>
    /// <br>              軽減税率対応</br>
    /// -----------------------------------------------------------------------------------
    public class MAHNB02340UA : System.Windows.Forms.Form,
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
		private System.Windows.Forms.Panel MAHNB02340UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_CostOut;
        private TDateEdit SalesDateEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit SalesDateStRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TDateEdit SerchSlipDataEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TDateEdit SerchSlipDataStRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TNedit tNedit_CustomerCode_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_CustomerCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TComboEditor tComboEditor_DebitNoteDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor tComboEditor_SalesSlipCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private TEdit tEdit_SalesInputCode_Ed;
        private TEdit tEdit_SalesInputCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private TEdit tEdit_EmployeeCode_Ed;
        private TEdit tEdit_EmployeeCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesInputCodeEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesInputCodeSt_GuideBtn;
        private ToolTip toolTip1;
        // ↓ 2007.11.08 keigo Yata Add ////////////////////////////////////
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private TNedit GrossMarginSt_Nedit;
        private TNedit GrossMargin2Ed_Nedit;
        private TNedit GrossMargin3Ed_Nedit;
        private TEdit GrossMargin1Mark_tEdit;
        private TEdit GrossMargin2Mark_tEdit;
        private TEdit GrossMargin3Mark_tEdit;
        private TEdit GrossMargin4Mark_tEdit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor tComboEditor_NewPageType;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton BusinessTypeCodeEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton BusinessTypeCodeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Infragistics.Win.Misc.UltraButton SupplierCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SupplierCdSt_GuideBtn;
        private TComboEditor tComboEditor_SalesOrderDivCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private TComboEditor tComboEditor_LogicalDeleteCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private TNedit tNedit_SupplierCd_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor_ZeroUdrGrsProfitPrint;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor_ZeroGrsProfitPrint;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor_ZeroCostPrint;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor_ZeroSalesPrint;
        private TNedit tNedit_BusinessTypeCode_Ed;
        private TNedit tNedit_BusinessTypeCode_St;
        private TNedit tNedit_SalesAreaCode_Ed;
        private TNedit tNedit_SalesAreaCode_St;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor_GrsProfitRatePrint;
        private TComboEditor tComboEditor_GrsProfitRatePrintDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel36;
        private TNedit GrsProfitRatePrintVal_tNedit;
        private TNedit tNedit_SupplierSlipNo_St;
        private TNedit tNedit_SupplierSlipNo_Ed;
        private TNedit GrsProfitCheckLower_tNedit;
        private TNedit GrsProfitCheckBest_tNedit;
        private TNedit GrsProfitCheckUpper_tNedit;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_PrintDailyFooter;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private object _preComboEditorValue = null; 
        // ↑ 2007.11.08 keigo Yata Add //////////////////////////////////// 
        private TComboEditor _preCtrlName = null;  　　　//ADD 2008/08/16

        private SalesConfInputInitData _salesConfInputInitData;//ADD BY凌小青 on 2011/11/29 for Redmine#8182 

		private System.ComponentModel.IContainer components;
        private UiMemInput uiMemInput1;//ADD BY凌小青 on 2011/11/29 for Redmine#8182
        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
        private UltraOptionSet ultraOptionSet_ConsClear;
        private UltraLabel ultraLabel38;
        private TComboEditor tComboEditor_DateDiv;
        private UltraLabel ultraLabel39;
        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
        //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
        private TComboEditor tComboEditor_LinePrintDiv;
        private UltraLabel LineMaSqOfCh_Label;
        private UltraLabel ultraLabel40;
        private TComboEditor tComboEditor_TaxPrintDiv;
        //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
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
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2013/01/04 田建委</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2020/02/27 3H 尹安</br>
        /// <br>管理番号    : 11570208-00 軽減税率対応</br>
        /// </remarks>
		public MAHNB02340UA()
		{
			InitializeComponent();
			this._enterpriseCode   = LoginInfoAcquisition.EnterpriseCode;
            _salesConfInputInitData = new SalesConfInputInitData();//ADD BY凌小青 on 2011/11/29 for Redmine#8182 

            // ↓ 2007.11.08 keigo Yata Delete ////////////////////////////////////
            //this._carrierList = new SortedList();
            //this._carrierDspList = new ArrayList();
            //this._salesFormalList = new SortedList();
            //this._salesFormList = new SortedList();
            // ↑ 2007.11.08 keigo Yata Delete ////////////////////////////////////

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker    = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // インスタンス生成
            this._employeeAcs = new EmployeeAcs();

            // 2008.07.04 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
            this._supplierAcs = new SupplierAcs();
            this._userGuideAcs = new UserGuideAcs();
            // 2008.07.04 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END


            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();

            // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////
            //this._lGoodsGanreAcs = new LGoodsGanreAcs();
            //this._mGoodsGanreAcs = new MGoodsGanreAcs();
            //this._cellphoneModelAcs = new CellphoneModelAcs();
            // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////

            //---------ADD BY凌小青 on 2011/11/29 for Redmine#8182 ----------->>>>>>>>>
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tComboEditor_NewPageType);
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字区分
            ctrlList.Add(this.tComboEditor_TaxPrintDiv);
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<< 
            ctrlList.Add(this.ultraOptionSet_CostOut);
            ctrlList.Add(this.ultraOptionSet_PrintDailyFooter);
            ctrlList.Add(this.PrintOder_tComboEditor);
            ctrlList.Add(this.tEdit_SalesInputCode_St);
            ctrlList.Add(this.tEdit_SalesInputCode_Ed);
            ctrlList.Add(this.tEdit_EmployeeCode_St);
            ctrlList.Add(this.tEdit_EmployeeCode_Ed);
            ctrlList.Add(this.tNedit_SalesAreaCode_St);
            ctrlList.Add(this.tNedit_SalesAreaCode_Ed);
            ctrlList.Add(this.tNedit_BusinessTypeCode_St);
            ctrlList.Add(this.tNedit_BusinessTypeCode_Ed);
            ctrlList.Add(this.tNedit_CustomerCode_St);
            ctrlList.Add(this.tNedit_CustomerCode_Ed);
            ctrlList.Add(this.tNedit_SupplierCd_St);
            ctrlList.Add(this.tNedit_SupplierCd_Ed);
            ctrlList.Add(this.tNedit_SupplierSlipNo_St);
            ctrlList.Add(this.tNedit_SupplierSlipNo_Ed);
            ctrlList.Add(this.tComboEditor_SalesSlipCd);
            ctrlList.Add(this.tComboEditor_DebitNoteDiv);
            ctrlList.Add(this.tComboEditor_LogicalDeleteCode);
            ctrlList.Add(this.tComboEditor_SalesOrderDivCd);
            //----- DEL 2012/01/30 田建委 Redmine#28202 -------->>>>>
            //ctrlList.Add(this.GrossMarginSt_Nedit);
            //ctrlList.Add(this.GrossMargin1Mark_tEdit);
            //ctrlList.Add(this.GrossMargin2Ed_Nedit);
            //ctrlList.Add(this.GrossMargin2Mark_tEdit);
            //ctrlList.Add(this.GrossMargin3Ed_Nedit);
            //ctrlList.Add(this.GrossMargin3Mark_tEdit);
            //ctrlList.Add(this.GrsProfitCheckUpper_tNedit);
            //ctrlList.Add(this.GrossMargin4Mark_tEdit);
            //----- DEL 2012/01/30 田建委 Redmine#28202 --------<<<<<
            ctrlList.Add(this.tComboEditor_GrsProfitRatePrintDiv);

            //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
            ctrlList.Add(this.ultraOptionSet_ConsClear);
            ctrlList.Add(this.tComboEditor_DateDiv);
            //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<

            //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
            ctrlList.Add(this.tComboEditor_LinePrintDiv); // 罫線印字
            //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<

            this.uiMemInput1.TargetControls = ctrlList;
            //---------ADD BY凌小青 on 2011/11/29 for Redmine#8182 -----------<<<<<<<<<


        }
		#endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		#region Dispose     
        /// <summary>
        /// 破棄
        /// </summary>
        /// <param name="disposing"></param>
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
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem33 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem34 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem35 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem36 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem37 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem38 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem39 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem40 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem41 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_TaxPrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_LinePrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.LineMaSqOfCh_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_DateDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_ConsClear = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_PrintDailyFooter = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.SerchSlipDataEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.SerchSlipDataStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_CostOut = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tComboEditor_NewPageType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.tComboEditor_GrsProfitRatePrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.GrsProfitRatePrintVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraCheckEditor_GrsProfitRatePrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraCheckEditor_ZeroGrsProfitPrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraCheckEditor_ZeroCostPrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraCheckEditor_ZeroSalesPrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMargin4Mark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GrossMargin3Mark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMargin3Ed_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMargin2Mark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.GrsProfitCheckUpper_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckBest_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckLower_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrossMargin2Ed_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrossMargin1Mark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginSt_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesAreaCodeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesInputCodeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesAreaCodeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesInputCodeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.BusinessTypeCodeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.BusinessTypeCodeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SupplierCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SupplierCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesInputCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesInputCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SalesOrderDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_DebitNoteDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_LogicalDeleteCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SalesSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierSlipNo_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BusinessTypeCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BusinessTypeCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SupplierSlipNo_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAHNB02340UA_Fill_Panel = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DateDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_ConsClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GrsProfitRatePrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitRatePrintVal_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin4Mark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin3Mark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin3Ed_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin2Mark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin2Ed_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin1Mark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginSt_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesOrderDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LogicalDeleteCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.MAHNB02340UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_TaxPrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_LinePrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.LineMaSqOfCh_Label);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_DateDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel39);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_ConsClear);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel38);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_PrintDailyFooter);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel37);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SerchSlipDataEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SerchSlipDataStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_CostOut);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_NewPageType);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel40);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(695, 162);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // tComboEditor_TaxPrintDiv
            // 
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ActiveAppearance = appearance132;
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.Appearance = appearance133;
            this.tComboEditor_TaxPrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ItemAppearance = appearance134;
            valueListItem1.DataValue = ((short)(0));
            valueListItem1.DisplayText = "0:印字する";
            valueListItem2.DataValue = ((short)(1));
            valueListItem2.DisplayText = "1:印字しない";
            this.tComboEditor_TaxPrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_TaxPrintDiv.LimitToList = true;
            this.tComboEditor_TaxPrintDiv.Location = new System.Drawing.Point(129, 133);
            this.tComboEditor_TaxPrintDiv.Name = "tComboEditor_TaxPrintDiv";
            this.tComboEditor_TaxPrintDiv.Size = new System.Drawing.Size(155, 24);
            this.tComboEditor_TaxPrintDiv.TabIndex = 7;
            // 
            // tComboEditor_LinePrintDiv
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ActiveAppearance = appearance68;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_LinePrintDiv.Appearance = appearance22;
            this.tComboEditor_LinePrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ItemAppearance = appearance69;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "0:印字する";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "1:印字しない";
            this.tComboEditor_LinePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.tComboEditor_LinePrintDiv.LimitToList = true;
            this.tComboEditor_LinePrintDiv.Location = new System.Drawing.Point(129, 78);
            this.tComboEditor_LinePrintDiv.Name = "tComboEditor_LinePrintDiv";
            this.tComboEditor_LinePrintDiv.Size = new System.Drawing.Size(155, 24);
            this.tComboEditor_LinePrintDiv.TabIndex = 5;
            // 
            // LineMaSqOfCh_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.LineMaSqOfCh_Label.Appearance = appearance8;
            this.LineMaSqOfCh_Label.Location = new System.Drawing.Point(16, 77);
            this.LineMaSqOfCh_Label.Name = "LineMaSqOfCh_Label";
            this.LineMaSqOfCh_Label.Size = new System.Drawing.Size(107, 23);
            this.LineMaSqOfCh_Label.TabIndex = 94;
            this.LineMaSqOfCh_Label.Text = "罫線印字";
            // 
            // tComboEditor_DateDiv
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DateDiv.ActiveAppearance = appearance135;
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DateDiv.Appearance = appearance136;
            this.tComboEditor_DateDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DateDiv.ItemAppearance = appearance137;
            valueListItem5.DataValue = ((short)(0));
            valueListItem5.DisplayText = "0:売上日";
            valueListItem6.DataValue = ((short)(1));
            valueListItem6.DisplayText = "1:入力日";
            valueListItem7.DataValue = ((short)(2));
            valueListItem7.DisplayText = "2:売上日＆入力日";
            this.tComboEditor_DateDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.tComboEditor_DateDiv.LimitToList = true;
            this.tComboEditor_DateDiv.Location = new System.Drawing.Point(129, 2);
            this.tComboEditor_DateDiv.Name = "tComboEditor_DateDiv";
            this.tComboEditor_DateDiv.Size = new System.Drawing.Size(155, 24);
            this.tComboEditor_DateDiv.TabIndex = 0;
            this.tComboEditor_DateDiv.ValueChanged += new System.EventHandler(this.tComboEditor_DateDiv_ValueChanged);
            // 
            // ultraLabel39
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance17;
            this.ultraLabel39.Location = new System.Drawing.Point(16, 2);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel39.TabIndex = 36;
            this.ultraLabel39.Text = "日付指定";
            // 
            // ultraOptionSet_ConsClear
            // 
            this.ultraOptionSet_ConsClear.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_ConsClear.CheckedIndex = 0;
            valueListItem8.DataValue = "0";
            valueListItem8.DisplayText = "しない";
            valueListItem9.DataValue = "1";
            valueListItem9.DisplayText = "する";
            this.ultraOptionSet_ConsClear.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.ultraOptionSet_ConsClear.Location = new System.Drawing.Point(439, 118);
            this.ultraOptionSet_ConsClear.Name = "ultraOptionSet_ConsClear";
            this.ultraOptionSet_ConsClear.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_ConsClear.TabIndex = 10;
            this.ultraOptionSet_ConsClear.Text = "しない";
            this.ultraOptionSet_ConsClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraOptionSet_ConsClear_KeyDown);
            // 
            // ultraLabel38
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance18;
            this.ultraLabel38.Location = new System.Drawing.Point(311, 118);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(130, 23);
            this.ultraLabel38.TabIndex = 35;
            this.ultraLabel38.Text = "出力後条件クリア";
            // 
            // ultraOptionSet_PrintDailyFooter
            // 
            this.ultraOptionSet_PrintDailyFooter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;
            valueListItem10.DataValue = "0";
            valueListItem10.DisplayText = "しない";
            valueListItem11.DataValue = "1";
            valueListItem11.DisplayText = "する";
            this.ultraOptionSet_PrintDailyFooter.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.ultraOptionSet_PrintDailyFooter.Location = new System.Drawing.Point(439, 100);
            this.ultraOptionSet_PrintDailyFooter.Name = "ultraOptionSet_PrintDailyFooter";
            this.ultraOptionSet_PrintDailyFooter.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_PrintDailyFooter.TabIndex = 9;
            this.ultraOptionSet_PrintDailyFooter.Text = "しない";
            this.ultraOptionSet_PrintDailyFooter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraOptionSet_PrintDailyFooter_KeyDown);
            // 
            // ultraLabel37
            // 
            appearance130.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance130;
            this.ultraLabel37.Location = new System.Drawing.Point(311, 99);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel37.TabIndex = 34;
            this.ultraLabel37.Text = "日計印字";
            // 
            // SerchSlipDataEdRF_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SerchSlipDataEdRF_tDateEdit.ActiveEditAppearance = appearance1;
            this.SerchSlipDataEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SerchSlipDataEdRF_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.SerchSlipDataEdRF_tDateEdit.EditAppearance = appearance2;
            this.SerchSlipDataEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SerchSlipDataEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.SerchSlipDataEdRF_tDateEdit.LabelAppearance = appearance3;
            this.SerchSlipDataEdRF_tDateEdit.Location = new System.Drawing.Point(348, 52);
            this.SerchSlipDataEdRF_tDateEdit.Name = "SerchSlipDataEdRF_tDateEdit";
            this.SerchSlipDataEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SerchSlipDataEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SerchSlipDataEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SerchSlipDataEdRF_tDateEdit.TabIndex = 4;
            this.SerchSlipDataEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel6
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance4;
            this.ultraLabel6.Location = new System.Drawing.Point(317, 27);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "～";
            // 
            // SerchSlipDataStRF_tDateEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SerchSlipDataStRF_tDateEdit.ActiveEditAppearance = appearance5;
            this.SerchSlipDataStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SerchSlipDataStRF_tDateEdit.CalendarDisp = true;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.SerchSlipDataStRF_tDateEdit.EditAppearance = appearance6;
            this.SerchSlipDataStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SerchSlipDataStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.SerchSlipDataStRF_tDateEdit.LabelAppearance = appearance7;
            this.SerchSlipDataStRF_tDateEdit.Location = new System.Drawing.Point(129, 52);
            this.SerchSlipDataStRF_tDateEdit.Name = "SerchSlipDataStRF_tDateEdit";
            this.SerchSlipDataStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SerchSlipDataStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SerchSlipDataStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SerchSlipDataStRF_tDateEdit.TabIndex = 3;
            this.SerchSlipDataStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel21
            // 
            appearance139.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance139;
            this.ultraLabel21.Location = new System.Drawing.Point(16, 104);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel21.TabIndex = 30;
            this.ultraLabel21.Text = "改頁";
            // 
            // ultraLabel7
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance9;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 52);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel7.TabIndex = 30;
            this.ultraLabel7.Text = "入力日";
            // 
            // ultraOptionSet_CostOut
            // 
            this.ultraOptionSet_CostOut.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_CostOut.CheckedIndex = 0;
            valueListItem12.DataValue = "0";
            valueListItem12.DisplayText = "なし";
            valueListItem13.DataValue = "1";
            valueListItem13.DisplayText = "あり";
            this.ultraOptionSet_CostOut.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem12,
            valueListItem13});
            this.ultraOptionSet_CostOut.Location = new System.Drawing.Point(439, 82);
            this.ultraOptionSet_CostOut.Name = "ultraOptionSet_CostOut";
            this.ultraOptionSet_CostOut.Size = new System.Drawing.Size(112, 20);
            this.ultraOptionSet_CostOut.TabIndex = 8;
            this.ultraOptionSet_CostOut.Text = "なし";
            this.ultraOptionSet_CostOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraOptionSet_CostOut_KeyDown);
            // 
            // ultraLabel10
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance13;
            this.ultraLabel10.Location = new System.Drawing.Point(317, 52);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // ultraLabel4
            // 
            appearance129.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance129;
            this.ultraLabel4.Location = new System.Drawing.Point(311, 79);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "原価・粗利出力";
            // 
            // SalesDateEdRF_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateEdRF_tDateEdit.ActiveEditAppearance = appearance10;
            this.SalesDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateEdRF_tDateEdit.CalendarDisp = true;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.EditAppearance = appearance11;
            this.SalesDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.LabelAppearance = appearance12;
            this.SalesDateEdRF_tDateEdit.Location = new System.Drawing.Point(348, 27);
            this.SalesDateEdRF_tDateEdit.Name = "SalesDateEdRF_tDateEdit";
            this.SalesDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateEdRF_tDateEdit.TabIndex = 2;
            this.SalesDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel8
            // 
            appearance131.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance131;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 27);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "売上日";
            // 
            // SalesDateStRF_tDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateStRF_tDateEdit.ActiveEditAppearance = appearance14;
            this.SalesDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateStRF_tDateEdit.CalendarDisp = true;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.EditAppearance = appearance15;
            this.SalesDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.LabelAppearance = appearance16;
            this.SalesDateStRF_tDateEdit.Location = new System.Drawing.Point(129, 27);
            this.SalesDateStRF_tDateEdit.Name = "SalesDateStRF_tDateEdit";
            this.SalesDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateStRF_tDateEdit.TabIndex = 1;
            this.SalesDateStRF_tDateEdit.TabStop = true;
            // 
            // tComboEditor_NewPageType
            // 
            appearance140.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ActiveAppearance = appearance140;
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPageType.Appearance = appearance141;
            this.tComboEditor_NewPageType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ItemAppearance = appearance142;
            valueListItem14.DataValue = ((short)(0));
            valueListItem14.DisplayText = "0:拠点";
            valueListItem15.DataValue = ((short)(1));
            valueListItem15.DisplayText = "1:小計";
            valueListItem16.DataValue = ((short)(2));
            valueListItem16.DisplayText = "2:しない";
            this.tComboEditor_NewPageType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.tComboEditor_NewPageType.LimitToList = true;
            this.tComboEditor_NewPageType.Location = new System.Drawing.Point(129, 106);
            this.tComboEditor_NewPageType.Name = "tComboEditor_NewPageType";
            this.tComboEditor_NewPageType.Size = new System.Drawing.Size(112, 24);
            this.tComboEditor_NewPageType.TabIndex = 6;
            // 
            // ultraLabel40
            // 
            appearance138.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance138;
            this.ultraLabel40.Location = new System.Drawing.Point(16, 133);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(109, 23);
            this.ultraLabel40.TabIndex = 96;
            this.ultraLabel40.Text = "税別内訳印字";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 245);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(695, 27);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance19;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance23;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance20;
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "0:売上日+伝票番号";
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "1:得意先+売上日+伝票番号";
            valueListItem19.DataValue = 2;
            valueListItem19.DisplayText = "2:入力日+伝票番号";
            valueListItem20.DataValue = 3;
            valueListItem20.DisplayText = "3:得意先+入力日+伝票番号";
            valueListItem21.DataValue = 4;
            valueListItem21.DisplayText = "4:担当者+伝票番号";
            valueListItem22.DataValue = 5;
            valueListItem22.DisplayText = "5:地区+伝票番号";
            valueListItem23.DataValue = 6;
            valueListItem23.DisplayText = "6:業種+伝票番号";
            valueListItem24.DataValue = 7;
            valueListItem24.DisplayText = "7:伝票番号";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20,
            valueListItem21,
            valueListItem22,
            valueListItem23,
            valueListItem24});
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(129, 1);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 11;
            // 
            // ultraLabel5
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance21;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 0);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel5.TabIndex = 4;
            this.ultraLabel5.Text = "出力順";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraExpandableGroupBox1);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel20);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel19);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel18);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin4Mark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin3Mark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel17);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin3Ed_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin2Mark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckUpper_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckBest_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckLower_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin2Ed_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMargin1Mark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginSt_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesInputCodeEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesInputCodeSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCodeEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCodeSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel31);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel30);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel26);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_SalesInputCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_SalesInputCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel29);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel23);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel22);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel24);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_SalesOrderDivCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_DebitNoteDiv);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel35);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_LogicalDeleteCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_SalesSlipCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel34);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierSlipNo_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel33);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierSlipNo_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel32);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 309);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(695, 326);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(268, 159);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(424, 1);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(268, 159);
            this.ultraExpandableGroupBox1.TabIndex = 52;
            this.ultraExpandableGroupBox1.Text = "指定条件のみ印刷";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_GrsProfitRatePrintDiv);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel36);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.GrsProfitRatePrintVal_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraCheckEditor_GrsProfitRatePrint);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraCheckEditor_ZeroUdrGrsProfitPrint);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraCheckEditor_ZeroGrsProfitPrint);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraCheckEditor_ZeroCostPrint);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraCheckEditor_ZeroSalesPrint);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(262, 137);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // tComboEditor_GrsProfitRatePrintDiv
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GrsProfitRatePrintDiv.ActiveAppearance = appearance100;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GrsProfitRatePrintDiv.ItemAppearance = appearance101;
            valueListItem25.DataValue = ((short)(0));
            valueListItem25.DisplayText = "0:以下";
            valueListItem26.DataValue = ((short)(1));
            valueListItem26.DisplayText = "1:以上";
            this.tComboEditor_GrsProfitRatePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem25,
            valueListItem26});
            this.tComboEditor_GrsProfitRatePrintDiv.LimitToList = true;
            this.tComboEditor_GrsProfitRatePrintDiv.Location = new System.Drawing.Point(163, 109);
            this.tComboEditor_GrsProfitRatePrintDiv.Name = "tComboEditor_GrsProfitRatePrintDiv";
            this.tComboEditor_GrsProfitRatePrintDiv.Size = new System.Drawing.Size(79, 24);
            this.tComboEditor_GrsProfitRatePrintDiv.TabIndex = 7;
            // 
            // ultraLabel36
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel36.Appearance = appearance64;
            this.ultraLabel36.Location = new System.Drawing.Point(135, 110);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel36.TabIndex = 44;
            this.ultraLabel36.Text = "％";
            // 
            // GrsProfitRatePrintVal_tNedit
            // 
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance116.TextHAlignAsString = "Right";
            this.GrsProfitRatePrintVal_tNedit.ActiveAppearance = appearance116;
            appearance117.TextHAlignAsString = "Right";
            this.GrsProfitRatePrintVal_tNedit.Appearance = appearance117;
            this.GrsProfitRatePrintVal_tNedit.AutoSelect = true;
            this.GrsProfitRatePrintVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitRatePrintVal_tNedit.DataText = "";
            this.GrsProfitRatePrintVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitRatePrintVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitRatePrintVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitRatePrintVal_tNedit.Location = new System.Drawing.Point(74, 109);
            this.GrsProfitRatePrintVal_tNedit.MaxLength = 6;
            this.GrsProfitRatePrintVal_tNedit.Name = "GrsProfitRatePrintVal_tNedit";
            this.GrsProfitRatePrintVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitRatePrintVal_tNedit.Size = new System.Drawing.Size(59, 24);
            this.GrsProfitRatePrintVal_tNedit.TabIndex = 6;
            this.GrsProfitRatePrintVal_tNedit.Leave += new System.EventHandler(this.GrsProfitRatePrintVal_tNedit_Leave);
            // 
            // ultraCheckEditor_GrsProfitRatePrint
            // 
            this.ultraCheckEditor_GrsProfitRatePrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ultraCheckEditor_GrsProfitRatePrint.Location = new System.Drawing.Point(16, 109);
            this.ultraCheckEditor_GrsProfitRatePrint.Name = "ultraCheckEditor_GrsProfitRatePrint";
            this.ultraCheckEditor_GrsProfitRatePrint.Size = new System.Drawing.Size(243, 23);
            this.ultraCheckEditor_GrsProfitRatePrint.TabIndex = 5;
            this.ultraCheckEditor_GrsProfitRatePrint.Text = "粗利率";
            // 
            // ultraCheckEditor_ZeroUdrGrsProfitPrint
            // 
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Location = new System.Drawing.Point(16, 84);
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Name = "ultraCheckEditor_ZeroUdrGrsProfitPrint";
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Size = new System.Drawing.Size(243, 23);
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.TabIndex = 4;
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Text = "粗利ゼロ以下";
            // 
            // ultraCheckEditor_ZeroGrsProfitPrint
            // 
            this.ultraCheckEditor_ZeroGrsProfitPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ultraCheckEditor_ZeroGrsProfitPrint.Location = new System.Drawing.Point(16, 59);
            this.ultraCheckEditor_ZeroGrsProfitPrint.Name = "ultraCheckEditor_ZeroGrsProfitPrint";
            this.ultraCheckEditor_ZeroGrsProfitPrint.Size = new System.Drawing.Size(243, 23);
            this.ultraCheckEditor_ZeroGrsProfitPrint.TabIndex = 3;
            this.ultraCheckEditor_ZeroGrsProfitPrint.Text = "粗利ゼロ";
            // 
            // ultraCheckEditor_ZeroCostPrint
            // 
            this.ultraCheckEditor_ZeroCostPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ultraCheckEditor_ZeroCostPrint.Location = new System.Drawing.Point(16, 34);
            this.ultraCheckEditor_ZeroCostPrint.Name = "ultraCheckEditor_ZeroCostPrint";
            this.ultraCheckEditor_ZeroCostPrint.Size = new System.Drawing.Size(243, 23);
            this.ultraCheckEditor_ZeroCostPrint.TabIndex = 2;
            this.ultraCheckEditor_ZeroCostPrint.Text = "原価ゼロ";
            // 
            // ultraCheckEditor_ZeroSalesPrint
            // 
            this.ultraCheckEditor_ZeroSalesPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ultraCheckEditor_ZeroSalesPrint.Location = new System.Drawing.Point(16, 9);
            this.ultraCheckEditor_ZeroSalesPrint.Name = "ultraCheckEditor_ZeroSalesPrint";
            this.ultraCheckEditor_ZeroSalesPrint.Size = new System.Drawing.Size(243, 23);
            this.ultraCheckEditor_ZeroSalesPrint.TabIndex = 1;
            this.ultraCheckEditor_ZeroSalesPrint.Text = "売価ゼロ";
            // 
            // ultraLabel20
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance28;
            this.ultraLabel20.Location = new System.Drawing.Point(353, 276);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel20.TabIndex = 59;
            this.ultraLabel20.Text = "％";
            // 
            // ultraLabel19
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance29;
            this.ultraLabel19.Location = new System.Drawing.Point(194, 276);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel19.TabIndex = 58;
            this.ultraLabel19.Text = "％";
            // 
            // ultraLabel18
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance30;
            this.ultraLabel18.Location = new System.Drawing.Point(194, 251);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel18.TabIndex = 57;
            this.ultraLabel18.Text = "％";
            // 
            // GrossMargin4Mark_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMargin4Mark_tEdit.ActiveAppearance = appearance31;
            this.GrossMargin4Mark_tEdit.AutoSelect = true;
            this.GrossMargin4Mark_tEdit.DataText = "";
            this.GrossMargin4Mark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin4Mark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMargin4Mark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMargin4Mark_tEdit.Location = new System.Drawing.Point(378, 301);
            this.GrossMargin4Mark_tEdit.MaxLength = 2;
            this.GrossMargin4Mark_tEdit.Name = "GrossMargin4Mark_tEdit";
            this.GrossMargin4Mark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin4Mark_tEdit.TabIndex = 51;
            // 
            // GrossMargin3Mark_tEdit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMargin3Mark_tEdit.ActiveAppearance = appearance32;
            this.GrossMargin3Mark_tEdit.AutoSelect = true;
            this.GrossMargin3Mark_tEdit.DataText = "";
            this.GrossMargin3Mark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin3Mark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMargin3Mark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMargin3Mark_tEdit.Location = new System.Drawing.Point(378, 276);
            this.GrossMargin3Mark_tEdit.MaxLength = 2;
            this.GrossMargin3Mark_tEdit.Name = "GrossMargin3Mark_tEdit";
            this.GrossMargin3Mark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin3Mark_tEdit.TabIndex = 49;
            // 
            // ultraLabel17
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance33;
            this.ultraLabel17.Location = new System.Drawing.Point(194, 301);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel17.TabIndex = 40;
            this.ultraLabel17.Text = "％以上";
            // 
            // GrossMargin3Ed_Nedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.TextHAlignAsString = "Left";
            this.GrossMargin3Ed_Nedit.ActiveAppearance = appearance34;
            appearance35.TextHAlignAsString = "Right";
            this.GrossMargin3Ed_Nedit.Appearance = appearance35;
            this.GrossMargin3Ed_Nedit.AutoSelect = true;
            this.GrossMargin3Ed_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMargin3Ed_Nedit.DataText = "";
            this.GrossMargin3Ed_Nedit.Enabled = false;
            this.GrossMargin3Ed_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin3Ed_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMargin3Ed_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMargin3Ed_Nedit.Location = new System.Drawing.Point(298, 276);
            this.GrossMargin3Ed_Nedit.MaxLength = 5;
            this.GrossMargin3Ed_Nedit.Name = "GrossMargin3Ed_Nedit";
            this.GrossMargin3Ed_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMargin3Ed_Nedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrossMargin3Ed_Nedit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin3Ed_Nedit.TabIndex = 48;
            // 
            // ultraLabel16
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance36;
            this.ultraLabel16.Location = new System.Drawing.Point(267, 276);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel16.TabIndex = 36;
            this.ultraLabel16.Text = "～";
            // 
            // GrossMargin2Mark_tEdit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMargin2Mark_tEdit.ActiveAppearance = appearance37;
            this.GrossMargin2Mark_tEdit.AutoSelect = true;
            this.GrossMargin2Mark_tEdit.DataText = "";
            this.GrossMargin2Mark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin2Mark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMargin2Mark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMargin2Mark_tEdit.Location = new System.Drawing.Point(378, 251);
            this.GrossMargin2Mark_tEdit.MaxLength = 2;
            this.GrossMargin2Mark_tEdit.Name = "GrossMargin2Mark_tEdit";
            this.GrossMargin2Mark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin2Mark_tEdit.TabIndex = 46;
            // 
            // ultraLabel15
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance38;
            this.ultraLabel15.Location = new System.Drawing.Point(353, 251);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(28, 23);
            this.ultraLabel15.TabIndex = 33;
            this.ultraLabel15.Text = "％";
            // 
            // ultraLabel14
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance39;
            this.ultraLabel14.Location = new System.Drawing.Point(267, 251);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel14.TabIndex = 31;
            this.ultraLabel14.Text = "～";
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
            this.GrsProfitCheckUpper_tNedit.Location = new System.Drawing.Point(129, 301);
            this.GrsProfitCheckUpper_tNedit.MaxLength = 4;
            this.GrsProfitCheckUpper_tNedit.Name = "GrsProfitCheckUpper_tNedit";
            this.GrsProfitCheckUpper_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckUpper_tNedit.Size = new System.Drawing.Size(51, 24);
            this.GrsProfitCheckUpper_tNedit.TabIndex = 50;
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
            this.GrsProfitCheckBest_tNedit.Location = new System.Drawing.Point(129, 276);
            this.GrsProfitCheckBest_tNedit.MaxLength = 4;
            this.GrsProfitCheckBest_tNedit.Name = "GrsProfitCheckBest_tNedit";
            this.GrsProfitCheckBest_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckBest_tNedit.Size = new System.Drawing.Size(51, 24);
            this.GrsProfitCheckBest_tNedit.TabIndex = 47;
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
            this.GrsProfitCheckLower_tNedit.Location = new System.Drawing.Point(129, 251);
            this.GrsProfitCheckLower_tNedit.MaxLength = 4;
            this.GrsProfitCheckLower_tNedit.Name = "GrsProfitCheckLower_tNedit";
            this.GrsProfitCheckLower_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckLower_tNedit.Size = new System.Drawing.Size(51, 24);
            this.GrsProfitCheckLower_tNedit.TabIndex = 44;
            this.GrsProfitCheckLower_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckLower_tNedit_ValueChanged);
            this.GrsProfitCheckLower_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckLower_tNedit_Leave);
            // 
            // GrossMargin2Ed_Nedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.TextHAlignAsString = "Left";
            this.GrossMargin2Ed_Nedit.ActiveAppearance = appearance26;
            appearance27.TextHAlignAsString = "Right";
            this.GrossMargin2Ed_Nedit.Appearance = appearance27;
            this.GrossMargin2Ed_Nedit.AutoSelect = true;
            this.GrossMargin2Ed_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMargin2Ed_Nedit.DataText = "";
            this.GrossMargin2Ed_Nedit.Enabled = false;
            this.GrossMargin2Ed_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin2Ed_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMargin2Ed_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMargin2Ed_Nedit.Location = new System.Drawing.Point(298, 251);
            this.GrossMargin2Ed_Nedit.MaxLength = 5;
            this.GrossMargin2Ed_Nedit.Name = "GrossMargin2Ed_Nedit";
            this.GrossMargin2Ed_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMargin2Ed_Nedit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin2Ed_Nedit.TabIndex = 45;
            // 
            // GrossMargin1Mark_tEdit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMargin1Mark_tEdit.ActiveAppearance = appearance42;
            this.GrossMargin1Mark_tEdit.AutoSelect = true;
            this.GrossMargin1Mark_tEdit.DataText = "";
            this.GrossMargin1Mark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMargin1Mark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMargin1Mark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMargin1Mark_tEdit.Location = new System.Drawing.Point(378, 226);
            this.GrossMargin1Mark_tEdit.MaxLength = 2;
            this.GrossMargin1Mark_tEdit.Name = "GrossMargin1Mark_tEdit";
            this.GrossMargin1Mark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMargin1Mark_tEdit.TabIndex = 43;
            this.GrossMargin1Mark_tEdit.UseWaitCursor = true;
            // 
            // ultraLabel9
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance43;
            this.ultraLabel9.Location = new System.Drawing.Point(194, 226);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel9.TabIndex = 28;
            this.ultraLabel9.Text = "％未満";
            // 
            // GrossMarginSt_Nedit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextHAlignAsString = "Left";
            this.GrossMarginSt_Nedit.ActiveAppearance = appearance44;
            appearance45.TextHAlignAsString = "Right";
            this.GrossMarginSt_Nedit.Appearance = appearance45;
            this.GrossMarginSt_Nedit.AutoSelect = true;
            this.GrossMarginSt_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginSt_Nedit.DataText = "";
            this.GrossMarginSt_Nedit.Enabled = false;
            this.GrossMarginSt_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginSt_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginSt_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginSt_Nedit.Location = new System.Drawing.Point(129, 226);
            this.GrossMarginSt_Nedit.MaxLength = 5;
            this.GrossMarginSt_Nedit.Name = "GrossMarginSt_Nedit";
            this.GrossMarginSt_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginSt_Nedit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginSt_Nedit.TabIndex = 42;
            // 
            // ultraLabel2
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance46;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 226);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel2.TabIndex = 26;
            this.ultraLabel2.Text = "粗利チェック";
            // 
            // SalesAreaCodeEd_GuideBtn
            // 
            appearance49.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeEd_GuideBtn.Appearance = appearance49;
            this.SalesAreaCodeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeEd_GuideBtn.Location = new System.Drawing.Point(393, 51);
            this.SalesAreaCodeEd_GuideBtn.Name = "SalesAreaCodeEd_GuideBtn";
            this.SalesAreaCodeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeEd_GuideBtn.TabIndex = 23;
            this.SalesAreaCodeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeEd_GuideBtn.Click += new System.EventHandler(this.SalesAreaCodeEd_GuideBtn_Click);
            // 
            // SalesInputCodeEd_GuideBtn
            // 
            appearance86.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesInputCodeEd_GuideBtn.Appearance = appearance86;
            this.SalesInputCodeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesInputCodeEd_GuideBtn.Location = new System.Drawing.Point(393, 1);
            this.SalesInputCodeEd_GuideBtn.Name = "SalesInputCodeEd_GuideBtn";
            this.SalesInputCodeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesInputCodeEd_GuideBtn.TabIndex = 15;
            this.toolTip1.SetToolTip(this.SalesInputCodeEd_GuideBtn, "従業員ガイド");
            this.SalesInputCodeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesInputCodeEd_GuideBtn.Click += new System.EventHandler(this.SalesInputCodeEd_GuideBtn_Click);
            // 
            // SalesAreaCodeSt_GuideBtn
            // 
            appearance50.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeSt_GuideBtn.Appearance = appearance50;
            this.SalesAreaCodeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeSt_GuideBtn.Location = new System.Drawing.Point(219, 51);
            this.SalesAreaCodeSt_GuideBtn.Name = "SalesAreaCodeSt_GuideBtn";
            this.SalesAreaCodeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeSt_GuideBtn.TabIndex = 21;
            this.SalesAreaCodeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeSt_GuideBtn.Click += new System.EventHandler(this.SalesAreaCodeSt_GuideBtn_Click);
            // 
            // SalesInputCodeSt_GuideBtn
            // 
            appearance87.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesInputCodeSt_GuideBtn.Appearance = appearance87;
            this.SalesInputCodeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesInputCodeSt_GuideBtn.Location = new System.Drawing.Point(219, 1);
            this.SalesInputCodeSt_GuideBtn.Name = "SalesInputCodeSt_GuideBtn";
            this.SalesInputCodeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesInputCodeSt_GuideBtn.TabIndex = 13;
            this.toolTip1.SetToolTip(this.SalesInputCodeSt_GuideBtn, "従業員ガイド");
            this.SalesInputCodeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesInputCodeSt_GuideBtn.Click += new System.EventHandler(this.SalesInputCodeSt_GuideBtn_Click);
            // 
            // BusinessTypeCodeEd_GuideBtn
            // 
            appearance51.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCodeEd_GuideBtn.Appearance = appearance51;
            this.BusinessTypeCodeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCodeEd_GuideBtn.Location = new System.Drawing.Point(393, 76);
            this.BusinessTypeCodeEd_GuideBtn.Name = "BusinessTypeCodeEd_GuideBtn";
            this.BusinessTypeCodeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCodeEd_GuideBtn.TabIndex = 27;
            this.BusinessTypeCodeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCodeEd_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCodeEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance88.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance88;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(393, 26);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 19;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // BusinessTypeCodeSt_GuideBtn
            // 
            appearance52.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCodeSt_GuideBtn.Appearance = appearance52;
            this.BusinessTypeCodeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCodeSt_GuideBtn.Location = new System.Drawing.Point(219, 76);
            this.BusinessTypeCodeSt_GuideBtn.Name = "BusinessTypeCodeSt_GuideBtn";
            this.BusinessTypeCodeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCodeSt_GuideBtn.TabIndex = 25;
            this.BusinessTypeCodeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCodeSt_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCodeSt_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance89.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance89;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(219, 26);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 17;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "従業員ガイド");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // SupplierCdEd_GuideBtn
            // 
            appearance53.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SupplierCdEd_GuideBtn.Appearance = appearance53;
            this.SupplierCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SupplierCdEd_GuideBtn.Location = new System.Drawing.Point(393, 126);
            this.SupplierCdEd_GuideBtn.Name = "SupplierCdEd_GuideBtn";
            this.SupplierCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SupplierCdEd_GuideBtn.TabIndex = 35;
            this.SupplierCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SupplierCdEd_GuideBtn.Click += new System.EventHandler(this.SupplierCdEd_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance98.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance98;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(393, 101);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 31;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "得意先検索");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // SupplierCdSt_GuideBtn
            // 
            appearance54.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SupplierCdSt_GuideBtn.Appearance = appearance54;
            this.SupplierCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SupplierCdSt_GuideBtn.Location = new System.Drawing.Point(219, 126);
            this.SupplierCdSt_GuideBtn.Name = "SupplierCdSt_GuideBtn";
            this.SupplierCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SupplierCdSt_GuideBtn.TabIndex = 33;
            this.SupplierCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SupplierCdSt_GuideBtn.Click += new System.EventHandler(this.SupplierCdSt_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance99.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance99;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(219, 101);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 29;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "得意先検索");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_Ed
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_Ed.ActiveAppearance = appearance90;
            this.tEdit_EmployeeCode_Ed.AutoSelect = true;
            this.tEdit_EmployeeCode_Ed.DataText = "";
            this.tEdit_EmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_EmployeeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_Ed.Location = new System.Drawing.Point(303, 26);
            this.tEdit_EmployeeCode_Ed.MaxLength = 4;
            this.tEdit_EmployeeCode_Ed.Name = "tEdit_EmployeeCode_Ed";
            this.tEdit_EmployeeCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tEdit_EmployeeCode_Ed.TabIndex = 18;
            // 
            // tEdit_EmployeeCode_St
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_St.ActiveAppearance = appearance91;
            this.tEdit_EmployeeCode_St.AutoSelect = true;
            this.tEdit_EmployeeCode_St.DataText = "";
            this.tEdit_EmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_EmployeeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_St.Location = new System.Drawing.Point(129, 26);
            this.tEdit_EmployeeCode_St.MaxLength = 4;
            this.tEdit_EmployeeCode_St.Name = "tEdit_EmployeeCode_St";
            this.tEdit_EmployeeCode_St.Size = new System.Drawing.Size(51, 24);
            this.tEdit_EmployeeCode_St.TabIndex = 16;
            // 
            // ultraLabel31
            // 
            appearance57.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance57;
            this.ultraLabel31.Location = new System.Drawing.Point(267, 76);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel31.TabIndex = 56;
            this.ultraLabel31.Text = "～";
            // 
            // ultraLabel25
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance92;
            this.ultraLabel25.Location = new System.Drawing.Point(267, 26);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 56;
            this.ultraLabel25.Text = "～";
            // 
            // ultraLabel27
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance58;
            this.ultraLabel27.Location = new System.Drawing.Point(267, 151);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 53;
            this.ultraLabel27.Text = "～";
            // 
            // ultraLabel28
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance59;
            this.ultraLabel28.Location = new System.Drawing.Point(16, 151);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel28.TabIndex = 51;
            this.ultraLabel28.Text = "伝票番号";
            // 
            // ultraLabel30
            // 
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance60;
            this.ultraLabel30.Location = new System.Drawing.Point(16, 76);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel30.TabIndex = 47;
            this.ultraLabel30.Text = "業種";
            // 
            // ultraLabel26
            // 
            appearance93.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance93;
            this.ultraLabel26.Location = new System.Drawing.Point(16, 26);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel26.TabIndex = 47;
            this.ultraLabel26.Text = "担当者";
            // 
            // tEdit_SalesInputCode_Ed
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode_Ed.ActiveAppearance = appearance94;
            this.tEdit_SalesInputCode_Ed.AutoSelect = true;
            this.tEdit_SalesInputCode_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SalesInputCode_Ed.DataText = "";
            this.tEdit_SalesInputCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SalesInputCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SalesInputCode_Ed.Location = new System.Drawing.Point(303, 1);
            this.tEdit_SalesInputCode_Ed.MaxLength = 4;
            this.tEdit_SalesInputCode_Ed.Name = "tEdit_SalesInputCode_Ed";
            this.tEdit_SalesInputCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tEdit_SalesInputCode_Ed.TabIndex = 14;
            // 
            // tEdit_SalesInputCode_St
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode_St.ActiveAppearance = appearance95;
            this.tEdit_SalesInputCode_St.AutoSelect = true;
            this.tEdit_SalesInputCode_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SalesInputCode_St.DataText = "";
            this.tEdit_SalesInputCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SalesInputCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SalesInputCode_St.Location = new System.Drawing.Point(129, 1);
            this.tEdit_SalesInputCode_St.MaxLength = 4;
            this.tEdit_SalesInputCode_St.Name = "tEdit_SalesInputCode_St";
            this.tEdit_SalesInputCode_St.Size = new System.Drawing.Size(51, 24);
            this.tEdit_SalesInputCode_St.TabIndex = 12;
            // 
            // ultraLabel29
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance63;
            this.ultraLabel29.Location = new System.Drawing.Point(267, 51);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel29.TabIndex = 45;
            this.ultraLabel29.Text = "～";
            // 
            // ultraLabel23
            // 
            appearance96.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance96;
            this.ultraLabel23.Location = new System.Drawing.Point(267, 1);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel23.TabIndex = 45;
            this.ultraLabel23.Text = "～";
            // 
            // ultraLabel22
            // 
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance122;
            this.ultraLabel22.Location = new System.Drawing.Point(16, 51);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel22.TabIndex = 44;
            this.ultraLabel22.Text = "地区";
            // 
            // ultraLabel24
            // 
            appearance97.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance97;
            this.ultraLabel24.Location = new System.Drawing.Point(16, 1);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel24.TabIndex = 44;
            this.ultraLabel24.Text = "発行者";
            // 
            // tComboEditor_SalesOrderDivCd
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesOrderDivCd.ActiveAppearance = appearance65;
            appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesOrderDivCd.Appearance = appearance128;
            this.tComboEditor_SalesOrderDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesOrderDivCd.ItemAppearance = appearance66;
            valueListItem27.DataValue = ((short)(0));
            valueListItem27.DisplayText = "0:全て";
            valueListItem28.DataValue = ((short)(1));
            valueListItem28.DisplayText = "1:在庫";
            valueListItem29.DataValue = ((short)(2));
            valueListItem29.DisplayText = "2:取寄";
            valueListItem30.DataValue = "3";
            valueListItem30.DisplayText = "3:UOE";
            this.tComboEditor_SalesOrderDivCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem27,
            valueListItem28,
            valueListItem29,
            valueListItem30});
            this.tComboEditor_SalesOrderDivCd.LimitToList = true;
            this.tComboEditor_SalesOrderDivCd.Location = new System.Drawing.Point(378, 201);
            this.tComboEditor_SalesOrderDivCd.Name = "tComboEditor_SalesOrderDivCd";
            this.tComboEditor_SalesOrderDivCd.Size = new System.Drawing.Size(125, 24);
            this.tComboEditor_SalesOrderDivCd.TabIndex = 41;
            // 
            // tComboEditor_DebitNoteDiv
            // 
            appearance123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ActiveAppearance = appearance123;
            appearance121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DebitNoteDiv.Appearance = appearance121;
            this.tComboEditor_DebitNoteDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ItemAppearance = appearance124;
            valueListItem31.DataValue = ((short)(0));
            valueListItem31.DisplayText = "0:全て";
            valueListItem32.DataValue = ((short)(1));
            valueListItem32.DisplayText = "1:黒伝";
            valueListItem33.DataValue = ((short)(2));
            valueListItem33.DisplayText = "2:赤伝";
            valueListItem34.DataValue = "3";
            valueListItem34.DisplayText = "3:元黒";
            this.tComboEditor_DebitNoteDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem31,
            valueListItem32,
            valueListItem33,
            valueListItem34});
            this.tComboEditor_DebitNoteDiv.LimitToList = true;
            this.tComboEditor_DebitNoteDiv.Location = new System.Drawing.Point(378, 176);
            this.tComboEditor_DebitNoteDiv.Name = "tComboEditor_DebitNoteDiv";
            this.tComboEditor_DebitNoteDiv.Size = new System.Drawing.Size(125, 24);
            this.tComboEditor_DebitNoteDiv.TabIndex = 39;
            // 
            // ultraLabel35
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel35.Appearance = appearance67;
            this.ultraLabel35.Location = new System.Drawing.Point(281, 201);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel35.TabIndex = 23;
            this.ultraLabel35.Text = "出力指定";
            // 
            // ultraLabel13
            // 
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance102;
            this.ultraLabel13.Location = new System.Drawing.Point(281, 176);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel13.TabIndex = 23;
            this.ultraLabel13.Text = "赤伝区分";
            // 
            // tComboEditor_LogicalDeleteCode
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LogicalDeleteCode.ActiveAppearance = appearance84;
            appearance127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_LogicalDeleteCode.Appearance = appearance127;
            this.tComboEditor_LogicalDeleteCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LogicalDeleteCode.ItemAppearance = appearance85;
            valueListItem35.DataValue = ((short)(0));
            valueListItem35.DisplayText = "0:通常";
            valueListItem36.DataValue = ((short)(1));
            valueListItem36.DisplayText = "1:訂正";
            valueListItem37.DataValue = ((short)(2));
            valueListItem37.DisplayText = "2:削除";
            valueListItem38.DataValue = ((short)(3));
            valueListItem38.DisplayText = "3:訂正＋削除";
            this.tComboEditor_LogicalDeleteCode.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem35,
            valueListItem36,
            valueListItem37,
            valueListItem38});
            this.tComboEditor_LogicalDeleteCode.LimitToList = true;
            this.tComboEditor_LogicalDeleteCode.Location = new System.Drawing.Point(129, 201);
            this.tComboEditor_LogicalDeleteCode.Name = "tComboEditor_LogicalDeleteCode";
            this.tComboEditor_LogicalDeleteCode.Size = new System.Drawing.Size(125, 24);
            this.tComboEditor_LogicalDeleteCode.TabIndex = 40;
            // 
            // tComboEditor_SalesSlipCd
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ActiveAppearance = appearance103;
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesSlipCd.Appearance = appearance120;
            this.tComboEditor_SalesSlipCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ItemAppearance = appearance104;
            valueListItem39.DataValue = ((short)(0));
            valueListItem39.DisplayText = "0:全て";
            valueListItem40.DataValue = ((short)(1));
            valueListItem40.DisplayText = "1:売上";
            valueListItem41.DataValue = ((short)(2));
            valueListItem41.DisplayText = "2:返品";
            this.tComboEditor_SalesSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem39,
            valueListItem40,
            valueListItem41});
            this.tComboEditor_SalesSlipCd.LimitToList = true;
            this.tComboEditor_SalesSlipCd.Location = new System.Drawing.Point(129, 176);
            this.tComboEditor_SalesSlipCd.Name = "tComboEditor_SalesSlipCd";
            this.tComboEditor_SalesSlipCd.Size = new System.Drawing.Size(125, 24);
            this.tComboEditor_SalesSlipCd.TabIndex = 38;
            // 
            // ultraLabel34
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance70;
            this.ultraLabel34.Location = new System.Drawing.Point(16, 201);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel34.TabIndex = 21;
            this.ultraLabel34.Text = "発行タイプ";
            // 
            // ultraLabel12
            // 
            appearance105.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance105;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 176);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel12.TabIndex = 21;
            this.ultraLabel12.Text = "伝票区分";
            // 
            // tNedit_SupplierSlipNo_Ed
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance71.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_Ed.ActiveAppearance = appearance71;
            appearance72.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_Ed.Appearance = appearance72;
            this.tNedit_SupplierSlipNo_Ed.AutoSelect = true;
            this.tNedit_SupplierSlipNo_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_Ed.DataText = "";
            this.tNedit_SupplierSlipNo_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierSlipNo_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_Ed.Location = new System.Drawing.Point(303, 151);
            this.tNedit_SupplierSlipNo_Ed.MaxLength = 9;
            this.tNedit_SupplierSlipNo_Ed.Name = "tNedit_SupplierSlipNo_Ed";
            this.tNedit_SupplierSlipNo_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierSlipNo_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierSlipNo_Ed.TabIndex = 37;
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance61.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance61;
            appearance62.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance62;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(303, 126);
            this.tNedit_SupplierCd_Ed.MaxLength = 6;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 34;
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance106.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance106;
            appearance107.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance107;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(303, 101);
            this.tNedit_CustomerCode_Ed.MaxLength = 9;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 30;
            // 
            // ultraLabel33
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance73;
            this.ultraLabel33.Location = new System.Drawing.Point(267, 126);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel33.TabIndex = 19;
            this.ultraLabel33.Text = "～";
            // 
            // ultraLabel11
            // 
            appearance108.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance108;
            this.ultraLabel11.Location = new System.Drawing.Point(267, 101);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 19;
            this.ultraLabel11.Text = "～";
            // 
            // tNedit_BusinessTypeCode_Ed
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.Appearance = appearance75;
            this.tNedit_BusinessTypeCode_Ed.AutoSelect = true;
            this.tNedit_BusinessTypeCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_Ed.DataText = "";
            this.tNedit_BusinessTypeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_Ed.Location = new System.Drawing.Point(303, 76);
            this.tNedit_BusinessTypeCode_Ed.MaxLength = 4;
            this.tNedit_BusinessTypeCode_Ed.Name = "tNedit_BusinessTypeCode_Ed";
            this.tNedit_BusinessTypeCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BusinessTypeCode_Ed.TabIndex = 26;
            // 
            // tNedit_BusinessTypeCode_St
            // 
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance125.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.ActiveAppearance = appearance125;
            appearance126.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.Appearance = appearance126;
            this.tNedit_BusinessTypeCode_St.AutoSelect = true;
            this.tNedit_BusinessTypeCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_St.DataText = "";
            this.tNedit_BusinessTypeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_St.Location = new System.Drawing.Point(129, 76);
            this.tNedit_BusinessTypeCode_St.MaxLength = 4;
            this.tNedit_BusinessTypeCode_St.Name = "tNedit_BusinessTypeCode_St";
            this.tNedit_BusinessTypeCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BusinessTypeCode_St.TabIndex = 24;
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance112.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance112;
            appearance113.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance113;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(303, 51);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 4;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 22;
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance114.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance114;
            appearance115.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance115;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(129, 51);
            this.tNedit_SalesAreaCode_St.MaxLength = 4;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 20;
            // 
            // tNedit_SupplierSlipNo_St
            // 
            appearance118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance118.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_St.ActiveAppearance = appearance118;
            appearance119.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_St.Appearance = appearance119;
            this.tNedit_SupplierSlipNo_St.AutoSelect = true;
            this.tNedit_SupplierSlipNo_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_St.DataText = "";
            this.tNedit_SupplierSlipNo_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierSlipNo_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_St.Location = new System.Drawing.Point(129, 151);
            this.tNedit_SupplierSlipNo_St.MaxLength = 9;
            this.tNedit_SupplierSlipNo_St.Name = "tNedit_SupplierSlipNo_St";
            this.tNedit_SupplierSlipNo_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierSlipNo_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierSlipNo_St.TabIndex = 36;
            // 
            // tNedit_SupplierCd_St
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance55;
            appearance56.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance56;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(129, 126);
            this.tNedit_SupplierCd_St.MaxLength = 6;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd_St.TabIndex = 32;
            // 
            // tNedit_CustomerCode_St
            // 
            appearance109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance109.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance109;
            appearance110.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance110;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(129, 101);
            this.tNedit_CustomerCode_St.MaxLength = 9;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_St.TabIndex = 28;
            // 
            // ultraLabel32
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance76;
            this.ultraLabel32.Location = new System.Drawing.Point(16, 126);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel32.TabIndex = 17;
            this.ultraLabel32.Text = "仕入先";
            // 
            // ultraLabel3
            // 
            appearance111.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance111;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 101);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel3.TabIndex = 17;
            this.ultraLabel3.Text = "得意先";
            // 
            // MAHNB02340UA_Fill_Panel
            // 
            this.MAHNB02340UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAHNB02340UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAHNB02340UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAHNB02340UA_Fill_Panel.Name = "MAHNB02340UA_Fill_Panel";
            this.MAHNB02340UA_Fill_Panel.Size = new System.Drawing.Size(733, 640);
            this.MAHNB02340UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(733, 640);
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
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance78;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 164;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance79;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 29;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　ソート順";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance80;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 328;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance81.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance81.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance81;
            appearance82.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance82;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(3, 3);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(731, 643);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.Leave += new System.EventHandler(this.Main_ultraExplorerBar_Leave);
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance83.FontData.SizeInPoints = 20F;
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance83;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(733, 640);
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
            // MAHNB02340UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(733, 640);
            this.Controls.Add(this.MAHNB02340UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAHNB02340UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MAHNB02340U_Load);
            this.Activated += new System.EventHandler(this.MAHNB02340U_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LinePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DateDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_ConsClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GrsProfitRatePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitRatePrintVal_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin4Mark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin3Mark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin3Ed_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin2Mark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin2Ed_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMargin1Mark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginSt_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesOrderDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LogicalDeleteCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.MAHNB02340UA_Fill_Panel.ResumeLayout(false);
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

        // 売上全体設定マスタ
        private SalesTtlStAcs _salesTtlStAcs;
        private SalesTtlSt _salesTtlSt;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

		private bool _chartButtonVisibled = false;
		private bool _chartButtonEnabled = false;
        // ADD 陳健 K2014/02/06-------------------------->>>>>
        // OperationCode削除指定区分(削除)の操作権限
        private bool _deleteFlag = false;
        // OperationCode削除指定区分(訂正＋削除)の操作権限
        private bool _deleteUpdateFlag = false;
        // ADD 陳健 K2014/02/06--------------------------<<<<<

        private string _SalesConfDataTable;

		private Employee _loginWorker                = null;

		// 自拠点コード
		private string _ownSectionCode               = "";

		// 請求設定拠点コード
		//private string _balanceSectionCode           = "";

        private ExtrInfo_MAHNB02347E _chartSaleconfListCndtn = null;

        // 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;

        // ガイド系アクセスクラス
        EmployeeAcs    _employeeAcs;

        // 2008.07.04 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
        SupplierAcs _supplierAcs;
        UserGuideAcs _userGuideAcs;
        // 2008.07.04 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END

        // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////
        //LGoodsGanreAcs _lGoodsGanreAcs;
        //MGoodsGanreAcs _mGoodsGanreAcs;
        //CellphoneModelAcs _cellphoneModelAcs;
        // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////

        private SaleConfAcs _saleConfListAcs = null;  // 売上確認表アクセスクラス

        private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// 拠点オプション有無
        private bool _isMainOfficeFunc;	// 本社機能有無

        // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////
        //SortedList _carrierList;
        //ArrayList _carrierDspList;
        //SortedList _salesFormalList;
        //SortedList _salesFormList;
        // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////
        
		// エクスプローラバー拡大基準高さ 
		private Form _topForm = null;
        //private bool _explorerBarExpanding = false;

		// 商品チャート抽出クラスメンバ
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_MAHNB02347E _saleConfListCndtnWork = new ExtrInfo_MAHNB02347E();		//条件クラス(前回条件保持用)
        private ExtrInfo_MAHNB02347E _chartSaleConfListCndtn = new ExtrInfo_MAHNB02347E();		//条件クラス(チャート引渡し用)
        private DataSet _printBuffDataSet = null;
        
        

        // ADD 2009/04/01 不具合対応[12909]：スペースキーでの項目選択機能を実装 ---------->>>>>
        #region ラジオボタンのスペースキー制御

        /// <summary>原価・粗利出力ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _costOutRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 原価・粗利出力ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>原価・粗利出力ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper CostOutRadioKeyPressHelper
        {
            get { return _costOutRadioKeyPressHelper; }
        }

        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent; // ADD 2010/08/16


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
        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
        /// <summary>出力後条件クリアラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _consClearRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 出力後条件クリアラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>出力後条件クリアラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper ConsClearRadioKeyPressHelper
        {
            get { return _consClearRadioKeyPressHelper; }
        }
        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
        #endregion  // ラジオボタンのスペースキー制御
        // ADD 2009/04/01 不具合対応[12909]：スペースキーでの項目選択機能を実装 ----------<<<<<

		#endregion
        
		// ===================================================================================== //
		// プライベート定数
		// ===================================================================================== //
		#region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_CustomerConditionGroup  = "CustomerConditionGroup";
        private const string ct_ExBarGroupNm_PrintOderGroup          = "PrintOderGroup";
        private const string ct_ExBarGroupNm_ExtraConditionCodeGroup = "ExtraConditionCodeGroup";


		private const string THIS_ASSEMBLYID                         = "MAHNB02340U";	
		private const string PDF_PRINT_KEY                           = "3ee0af24-56ae-435d-b294-298a93dfd243";
		private const string PDF_PRINT_NAME                          = "売上確認表";  // MOD MANTIS[15018]対応 "売上順位表"→"売上確認表"

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
            ExtrInfo_MAHNB02347E saleConfListCndtnWork = new ExtrInfo_MAHNB02347E();
            this.SetExtraInfoFromScreen(ref saleConfListCndtnWork);
		            
			// 抽出条件の設定
            printInfo.jyoken = saleConfListCndtnWork;

            // チャート用条件設定
            //_chartSaleOrderListCndtn = this._saleOrderListCndtnWork; 

            // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////
            // 印刷帳票設定
            //if(saleConfListCndtnWork.IsDetails == false)
            //{
            //    printInfo.PrintPaperSetCd = 1;
            //}
            //else
            //{
            //    printInfo.PrintPaperSetCd = 0;
            //}
            
            // ----------
            // 抽出中画面インスタンス作成
            //Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            //pd.Title = "抽出中";
            //pd.Message = "現在、データ抽出中です。";

            //int status = 0;

            //try
            //{
            //    pd.Show();
            //    status = this.SearchData(saleConfListCndtnWork);
            //}
            //finally
            //{
            //    pd.Close();
            //    printInfo.status = status;
            //}
            //// ----------

            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            //{
            //    this._printBuffDataSet = null;
            //    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

            //    return status;
            //}
            // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////

            this._saleConfListCndtnWork = saleConfListCndtnWork;

            //printInfo.rdData = this._printBuffDataSet;

			printDialog.PrintInfo = printInfo;
		        
			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
            else if (dialogResult != DialogResult.Cancel)
            {
                //[出力後条件クリア]の設定値は「する」の場合
                if (this.ultraOptionSet_ConsClear.CheckedIndex == 1)
                {
                    ClearCondtion();//出力後初期画面設定
                }
            }
            //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
		
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
            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, evt);
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
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //return status;

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            ExtrInfo_MAHNB02347E extraInfo = new ExtrInfo_MAHNB02347E();     // 抽出条件クラス

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

        /// <summary>
        /// チャートデータの抽出チェック
        /// </summary>
        /// <returns></returns>
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
          System.Windows.Forms.Application.Run(new MAHNB02340UA());
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
        /// <br>Update Note: 2013/01/04 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2020/02/27 3H 尹安</br>
        /// <br>管理番号    : 11570208-00 軽減税率対応</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
            int preSelectedIndex = this.tComboEditor_DateDiv.SelectedIndex;
            if (preSelectedIndex > 0)
            {
                this.tComboEditor_DateDiv.SelectedIndex = preSelectedIndex;
            }
            else
            {
                this.tComboEditor_DateDiv.SelectedIndex = 0;
            }
            //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<

            //int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now); //   DEL 2012/11/06 張曼 Redmine#33216

            // 日付範囲
            //this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            //this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            //this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
            //this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);

            // 2008.07.17 30413 犬飼 売上日に現在日付を設定 >>>>>>START
            //this.SerchSlipDataStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            //this.SerchSlipDataEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

            //this.SerchSlipDataStRF_tDateEdit.SetLongDate(nowLongDate);
            //this.SerchSlipDataEdRF_tDateEdit.SetLongDate(nowLongDate);

            //---DEL 2012/11/06 張曼 Redmine#33216----->>>>>
            //this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            //this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            //this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
            //this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
            //---DEL 2012/11/06 張曼 Redmine#33216-----<<<<<

            // 2008.07.17 30413 犬飼 売上日に現在日付を設定 <<<<<<END
            
            this.PrintOder_tComboEditor.Value = 0;

            this.tComboEditor_SalesSlipCd.SelectedIndex = 0;
            this.tComboEditor_DebitNoteDiv.SelectedIndex = 0;

            // 2008.07.07 30413 犬飼 追加コンボボックスの初期値を設定 >>>>>>START
            this.tComboEditor_NewPageType.Value = 0;
            this.tComboEditor_LogicalDeleteCode.Value = 0;
            this.tComboEditor_SalesOrderDivCd.Value = 0;
            // 2008.07.07 30413 犬飼 追加コンボボックスの初期値を設定 <<<<<<END
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字コンボボックスの初期値を設定
            this.tComboEditor_TaxPrintDiv.Value = 1;
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<< 

            //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
            // 罫線印字
            this.tComboEditor_LinePrintDiv.Value = 0;
            //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<

            // 2008.09.18 30413 犬飼 粗利率の初期値を不動小数で設定 >>>>>>START
            // 粗利チェックの初期値(売上全体設定マスタから読み込む)
            //粗利率の下限値
            //this.GrsProfitCheckLower_tNedit.Text = this._salesTtlSt.GrsProfitCheckLower.ToString();
            this.GrsProfitCheckLower_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckLower);

            //粗利率の適正値
            //this.GrsProfitCheckBest_tNedit.Text = this._salesTtlSt.GrsProfitCheckBest.ToString();
            this.GrsProfitCheckBest_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckBest);

            //粗利率の上限値
            //this.GrsProfitCheckUpper_tNedit.Text = this._salesTtlSt.GrsProfitCheckUpper.ToString();
            this.GrsProfitCheckUpper_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckUpper);
            // 2008.09.18 30413 犬飼 粗利率の初期値を不動小数で設定 <<<<<<END
            
            //粗利マーク(下限値未満の記号)
            this.GrossMargin1Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkLowSign.Trim();

            //粗利マーク(適正値から下限値までの記号)
            this.GrossMargin2Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkBestSign.Trim();

            //粗利マーク(上限値から適正値までの記号)
            this.GrossMargin3Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkUprSign.Trim();

            //粗利マーク(粗利チェックの上限値オーバーの記号)
            this.GrossMargin4Mark_tEdit.Text = this._salesTtlSt.GrsProfitChkMaxSign.Trim();

            // 2008.09.17 30413 犬飼 指定条件のみ印刷の粗利率の初期値設定 >>>>>>START
            this.GrsProfitRatePrintVal_tNedit.SetValue(0.0);
            this.tComboEditor_GrsProfitRatePrintDiv.Value = 0;
            // 2008.09.17 30413 犬飼 指定条件のみ印刷の粗利率の初期値設定 <<<<<<END
            
            // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////
            // キャリア
            //this.checkedListBox_Carrier.Items.Clear();
            //this.checkedListBox_Carrier.Items.Add("全て");

            //for (int i = 0; i < this._carrierDspList.Count; i++)
            //{
            //    this.checkedListBox_Carrier.Items.Add(this._carrierDspList[i]);
            //}
            //this.checkedListBox_Carrier.SetItemChecked(0, true);

            // 売上形式
            //this.checkedListBox_SalesFormal.Items.Clear();
            //this.checkedListBox_SalesFormal.Items.Add("全て");
            //for (int i = 0; i < this._salesFormalList.Count; i++)
            //{
            //    this.checkedListBox_SalesFormal.Items.Add(this._salesFormalList.GetByIndex(i));
            //}
            //this.checkedListBox_SalesFormal.SetItemChecked(0, true);

            // 販売形態
            //this.checkedListBox_SalesFormCode.Items.Clear();
            //this.checkedListBox_SalesFormCode.Items.Add("全て");
            //for (int i = 0; i < this._salesFormList.Count; i++)
            //{
            //    this.checkedListBox_SalesFormCode.Items.Add(this._salesFormList.GetByIndex(i));
            //}
            //this.checkedListBox_SalesFormCode.SetItemChecked(0, true);
            // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////

            // ガイドボタンイメージ設定
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////
            //LargeGoodsGanreCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //LargeGoodsGanreCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;                     
            //LargeGoodsGanreCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //LargeGoodsGanreCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;           
            //MediumGoodsGanreCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //MediumGoodsGanreCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //MediumGoodsGanreCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //MediumGoodsGanreCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //CellphoneModelCodeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //CellphoneModelCodeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //CellphoneModelCodeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //CellphoneModelCodeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////

            SalesInputCodeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesInputCodeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesInputCodeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesInputCodeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            // 2008.07.07 30413 追加ガイドボタンのイメージを設定 >>>>>>START
            SalesAreaCodeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesAreaCodeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            BusinessTypeCodeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            BusinessTypeCodeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            BusinessTypeCodeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            BusinessTypeCodeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SupplierCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SupplierCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SupplierCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SupplierCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            // 2008.07.07 30413 追加ガイドボタンのイメージを設定 <<<<<<END
        }

        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
        /// <summary>
        /// 出力後初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期画面設定を行います。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/11/06</br>
        /// </remarks>         
        private void ClearCondtion()
        {
            this.Initial_Timer.Enabled = false;

            // 画面初期表示
            this.ultraOptionSet_CostOut.CheckedIndex = 0;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;

            this.InitialScreenSetting();
            //発行者
            this.tEdit_SalesInputCode_St.Text = null;
            this.tEdit_SalesInputCode_Ed.Text = null;
            //担当者
            this.tEdit_EmployeeCode_St.Text = null;
            this.tEdit_EmployeeCode_Ed.Text = null;
            //地区
            this.tNedit_SalesAreaCode_St.Text = null;
            this.tNedit_SalesAreaCode_Ed.Text = null;
            //業種
            this.tNedit_BusinessTypeCode_St.Text = null;
            this.tNedit_BusinessTypeCode_Ed.Text = null;
            //得意先
            this.tNedit_CustomerCode_St.Text = null;
            this.tNedit_CustomerCode_Ed.Text = null;
            //仕入先
            this.tNedit_SupplierCd_St.Text = null;
            this.tNedit_SupplierCd_Ed.Text = null;
            //伝票番号
            this.tNedit_SupplierSlipNo_St.Text = null;
            this.tNedit_SupplierSlipNo_Ed.Text = null;

            // メインフレームにツールバー設定通知
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            this.ultraCheckEditor_ZeroCostPrint.Checked = false;
            this.ultraCheckEditor_ZeroSalesPrint.Checked = false;
            this.ultraCheckEditor_ZeroGrsProfitPrint.Checked = false;
            this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Checked = false;
            this.ultraCheckEditor_GrsProfitRatePrint.Checked = false;
            showDateTypeByDateDiv(this.tComboEditor_DateDiv.SelectedIndex);
        }

        /// <summary>
        /// 売上日と入力日の入力制御
        /// </summary>
        /// <remarks>
        /// <br>Note       : 日付指定の条件により、売上日と入力日の入力制御を行います。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/11/06</br>
        /// </remarks> 
        private void showDateTypeByDateDiv(int index)
        {
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            switch (index)
            {

                case 0:
                    {
                        this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SalesDateStRF_tDateEdit.Enabled = true;
                        this.SalesDateEdRF_tDateEdit.Enabled = true;
                        this.SerchSlipDataStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataStRF_tDateEdit.Clear();
                        this.SerchSlipDataEdRF_tDateEdit.Clear();
                        this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                        this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                        break;
                    }
                case 1:
                    {
                        this.SerchSlipDataStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataStRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SerchSlipDataEdRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                        this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                        this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateStRF_tDateEdit.Clear();
                        this.SalesDateEdRF_tDateEdit.Clear();
                        this.SalesDateStRF_tDateEdit.Enabled = false;
                        this.SalesDateEdRF_tDateEdit.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
                        this.SalesDateStRF_tDateEdit.Enabled = true;
                        this.SalesDateEdRF_tDateEdit.Enabled = true;
                        this.SerchSlipDataStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
                        this.SerchSlipDataStRF_tDateEdit.Clear();
                        this.SerchSlipDataEdRF_tDateEdit.Clear();
                        this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                        this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                        break;
                    }
            }
        }

        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<

        // --- 2010/08/16 ---------->>>>>
        #region ◎ F5：ガイドの実行
        /// <summary>
        /// F5：ガイドの実行
        /// </summary>
        /// <returns></returns>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tEdit_SalesInputCode_St.Focused)
            {
                SalesInputCodeSt_GuideBtn_Click(SalesInputCodeSt_GuideBtn, e);
                this.tEdit_SalesInputCode_St.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SalesInputCode_St.Name, this.tEdit_SalesInputCode_St.Text);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                SalesInputCodeEd_GuideBtn_Click(SalesInputCodeEd_GuideBtn, e);
                this.tEdit_SalesInputCode_Ed.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SalesInputCode_Ed.Name, this.tEdit_SalesInputCode_Ed.Text);
            }
            else if (this.tEdit_EmployeeCode_St.Focused)
            {
                SalesEmployeeCdSt_GuideBtn_Click(SalesEmployeeCdSt_GuideBtn, e);
                this.tEdit_EmployeeCode_St.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_EmployeeCode_St.Name, this.tEdit_EmployeeCode_St.Text);
            }
            else if (this.tEdit_EmployeeCode_Ed.Focused) 
            {
                SalesEmployeeCdEd_GuideBtn_Click(SalesEmployeeCdEd_GuideBtn, e);
                this.tEdit_EmployeeCode_Ed.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_EmployeeCode_Ed.Name, this.tEdit_EmployeeCode_Ed.Text);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused) 
            {
                SalesAreaCodeSt_GuideBtn_Click(SalesAreaCodeSt_GuideBtn, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                SalesAreaCodeEd_GuideBtn_Click(SalesAreaCodeEd_GuideBtn, e);
            }
            else if (this.tNedit_BusinessTypeCode_St.Focused)
            {
                BusinessTypeCodeSt_GuideBtn_Click(BusinessTypeCodeSt_GuideBtn, e);
            }
            else if (this.tNedit_BusinessTypeCode_Ed.Focused) 
            {
                BusinessTypeCodeEd_GuideBtn_Click(BusinessTypeCodeEd_GuideBtn, e);
            }
            else if (this.tNedit_CustomerCode_St.Focused) 
            {             
                CustomerCdSt_GuideBtn_Click(CustomerCdSt_GuideBtn, e);
            }                               
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                CustomerCdEd_GuideBtn_Click(CustomerCdEd_GuideBtn, e);
            }
            else if (this.tNedit_SupplierCd_St.Focused)
            {
                SupplierCdSt_GuideBtn_Click(SupplierCdSt_GuideBtn, e);
            }
            else if (this.tNedit_SupplierCd_Ed.Focused)
            {
                SupplierCdEd_GuideBtn_Click(SupplierCdEd_GuideBtn, e);
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

            // 売上日（開始・終了）
            if ((this.SalesDateStRF_tDateEdit.LongDate != 0) ||
                (this.SalesDateEdRF_tDateEdit.LongDate != 0))
            {
                if (CallCheckDateRange_SalesDays(out cdrResult, ref SalesDateStRF_tDateEdit, ref SalesDateEdRF_tDateEdit) == false)
                {
                    switch (cdrResult)
                    {
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        //    {
                        //        message = "開始日を入力して下さい";
                        //        errControl = this.SalesDateStRF_tDateEdit;
                        //    }
                        //    break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                message = "開始日の入力が不正です";
                                errControl = this.SalesDateStRF_tDateEdit;
                            }
                            break;
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        //    {
                        //        message = "終了日を入力して下さい";
                        //        errControl = this.SalesDateEdRF_tDateEdit;
                        //    }
                        //    break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                message = "終了日の入力が不正です";
                                errControl = this.SalesDateEdRF_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                //message = "日付の範囲指定に誤りがあります";
                                message = "売上日の範囲指定に誤りがあります";
                                errControl = this.SalesDateStRF_tDateEdit;
                            }
                            break;
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        //    {
                        //        //message = "日付は３ヶ月の範囲で入力して下さい";
                        //        message = "売上日は３ヶ月の範囲で入力して下さい";
                        //        errControl = this.SalesDateStRF_tDateEdit;
                        //    }
                        //    break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                    }
                    return result;
                }
            }
            // --- DEL 2009/04/07 -------------------------------->>>>>
            //// 2008.09.18 30413 犬飼 売上日に必須チェックを追加 >>>>>>START
            //else
            //{
            //    // 開始日と終了日の両方未入力
            //    message = "開始日と終了日を入力して下さい";
            //    errControl = this.SalesDateStRF_tDateEdit;
            //    return result;
            //}
            //// 2008.09.18 30413 犬飼 売上日に必須チェックを追加 <<<<<<END
            // --- DEL 2009/04/07 --------------------------------<<<<<
            
            //if ((this.SalesDateStRF_tDateEdit.LongDate != 0) ||
            //    (this.SalesDateEdRF_tDateEdit.LongDate != 0))
            //{
            //    // 売上日(開始)
            //    if (!InputDateEditCheack(this.SalesDateStRF_tDateEdit))
            //    {
            //        message = "売上日の指定に誤りがあります";
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;
            //    }

            //    // 売上日(終了)
            //    if (!InputDateEditCheack(this.SalesDateEdRF_tDateEdit))
            //    {
            //        message = "売上日の指定に誤りがあります";
            //        errControl = this.SalesDateEdRF_tDateEdit;
            //        return result;
            //    }

            //    // 売上日範囲チェック
            //    if ((this.SalesDateStRF_tDateEdit.GetLongDate()) > (this.SalesDateEdRF_tDateEdit.GetLongDate()))
            //    {
            //        message = "売上日の範囲に誤りがあります";
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;
            //    }

            //}
            

            // ↓ 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////
            //if ((this.ShipmentDayStRF_tDateEdit.LongDate != 0) ||
            //    (this.ShipmentDayEdRF_tDateEdit.LongDate != 0))
            //{
            //    // 出荷日付(開始)
            //    if (!InputDateEditCheack(this.ShipmentDayStRF_tDateEdit))
            //    {
            //        message = "出荷日付の指定に誤りがあります";
            //        errControl = this.ShipmentDayStRF_tDateEdit;
            //        return result;
            //    }

            //    // 出荷日付(終了)
            //    if (!InputDateEditCheack(this.ShipmentDayEdRF_tDateEdit))
            //    {
            //        message = "出荷日付の指定に誤りがあります";
            //        errControl = this.ShipmentDayEdRF_tDateEdit;
            //        return result;
            //    }

            //    // 出荷日付範囲チェック
            //    if ((this.ShipmentDayStRF_tDateEdit.GetLongDate()) > (this.ShipmentDayEdRF_tDateEdit.GetLongDate()))
            //    {
            //        message = "出荷日付の範囲に誤りがあります";
            //        errControl = this.ShipmentDayStRF_tDateEdit;
            //        return result;
            //    }
            //}
            // ↑ 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////


            // ↓ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////
            //if ((this.SerchSlipDataStRF_tDateEdit.LongDate != 0) ||
            //    (this.SerchSlipDataEdRF_tDateEdit.LongDate != 0))
            //{
            //    // 入力日(開始)
            //    if (!InputDateEditCheack(this.SerchSlipDataStRF_tDateEdit))
            //    {
            //        message = "入力日の指定に誤りがあります";
            //        errControl = this.SerchSlipDataStRF_tDateEdit;
            //        return result;
            //    }

            //    // 入力日(終了)
            //    if (!InputDateEditCheack(this.SerchSlipDataEdRF_tDateEdit))
            //    {
            //        message = "入力日の指定に誤りがあります";
            //        errControl = this.SerchSlipDataEdRF_tDateEdit;
            //        return result;
            //    }

            //    // 入力日範囲チェック
            //    if ((this.SerchSlipDataStRF_tDateEdit.GetLongDate()) > (this.SerchSlipDataEdRF_tDateEdit.GetLongDate()))
            //    {
            //        message = "入力日の範囲に誤りがあります";
            //        errControl = this.SerchSlipDataStRF_tDateEdit;
            //        return result;
            //    }
            //}
            // ↑ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////

            // 2008.12.12 30413 犬飼 チェック処理を修正 >>>>>>START
            // 2008.09.18 30413 犬飼 入力日を任意入力チェックに変更 >>>>>>START
            // 入力日（開始・終了）
            //if ((this.SerchSlipDataStRF_tDateEdit.LongDate != 0) ||
            //    (this.SerchSlipDataEdRF_tDateEdit.LongDate != 0))
            //{

                if (CallCheckDateRange_InputDays(out cdrResult, ref SerchSlipDataStRF_tDateEdit, ref SerchSlipDataEdRF_tDateEdit) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                //message = "開始日を入力して下さい";
                                //errControl = this.SerchSlipDataStRF_tDateEdit;
                                result = true;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                message = "開始日の入力が不正です";
                                errControl = this.SerchSlipDataStRF_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                //message = "終了日を入力して下さい";
                                //errControl = this.SerchSlipDataEdRF_tDateEdit;
                                result = true;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                message = "終了日の入力が不正です";
                                errControl = this.SerchSlipDataEdRF_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                //message = "日付の範囲指定に誤りがあります";
                                message = "入力日の範囲指定に誤りがあります";
                                errControl = this.SerchSlipDataStRF_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                //message = "日付は１ヶ月の範囲で入力して下さい";
                                //errControl = this.SerchSlipDataStRF_tDateEdit;
                                result = true;
                            }
                            break;
                    }
                    //return result;
                }
                else
                {
                    result = true;
                }

            //}
            //else
            //{
            //    result = true;
            //}

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
            // 2008.09.18 30413 犬飼 入力日を任意入力チェックに変更 <<<<<<END
            // 2008.12.12 30413 犬飼 チェック処理を修正 <<<<<<END

            // 2008.12.12 30413 犬飼 チェック処理の順序を修正 >>>>>>START
            //// 得意先コード範囲チェック
            //if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
            //    (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            //{
            //    message = "得意先コードの範囲に誤りがあります";
            //    errControl = this.tNedit_CustomerCode_Ed;
            //    return result;
            //}
            // 2008.12.12 30413 犬飼 チェック処理の順序を修正 <<<<<<END
            
            // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////
            // 商品区分グループ範囲チェック
            //if ((this.LargeGoodsGanreCdEd_tEdit.Text != "") &&
            //    (this.LargeGoodsGanreCdSt_tEdit.Text.CompareTo(this.LargeGoodsGanreCdEd_tEdit.Text) > 0))
            //{
            //    message = "商品区分グループの範囲に誤りがあります";
            //    errControl = this.LargeGoodsGanreCdSt_tEdit;
            //    return result;
            //}

            // 商品区分範囲チェック
            //if ((this.MediumGoodsGanreCdEd_tEdit.Text != "") &&
            //    (this.MediumGoodsGanreCdSt_tEdit.Text.CompareTo(this.MediumGoodsGanreCdEd_tEdit.Text) > 0))
            //{
            //    message = "商品区分の範囲に誤りがあります";
            //    errControl = this.MediumGoodsGanreCdSt_tEdit;
            //    return result;
            //}

            // 機種コード範囲チェック
            //if ((this.CellphoneModelCodeEd_tEdit.Text != "") &&
            //    (this.CellphoneModelCodeSt_tEdit.Text.CompareTo(this.CellphoneModelCodeEd_tEdit.Text) > 0))
            //{
            //    message = "機種コードの範囲に誤りがあります";
            //    errControl = this.CellphoneModelCodeSt_tEdit;
            //    return result;
            //}
            // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////

            // ↓ 2007.11.08 Keigo Yata Change ///////////////////////////////////////////////////////////////////////
            // 商品コード範囲チェック
            //if ((this.GoodsCodeEd_tEdit.Text != "") &&
            //    (this.GoodsCodeSt_tEdit.Text.CompareTo(this.GoodsCodeEd_tEdit.Text) > 0))
            //{
            //    message = "商品コードの範囲に誤りがあります";
            //    errControl = this.GoodsCodeSt_tEdit;
            //    return result;
            //}
            // ↑ 2007.11.08 Keigo Yata Change //////////////////////////////////////////////////////////////////////

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // XMLの税率情報チェック
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

            // 2008.12.12 30413 犬飼 チェック処理の順序を修正 >>>>>>START
            // ↓ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////
            // 入力者コード範囲チェック
            if ((this.tEdit_SalesInputCode_Ed.Text != "") &&
                //(this.tEdit_SalesInputCode_St.Text.CompareTo(this.tEdit_SalesInputCode_Ed.Text) > 0))
                (this.tEdit_SalesInputCode_St.Text.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_SalesInputCode_Ed.Text.TrimEnd().PadLeft(4, '0')) > 0))
            {
                //message = "入力者コードの範囲に誤りがあります";
                message = "発行者の範囲に誤りがあります";
                errControl = this.tEdit_SalesInputCode_St;
                return result;
            }
            // ↑ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////

            // 担当者コード範囲チェック
            if ((this.tEdit_EmployeeCode_Ed.Text != "") &&
                //(this.tEdit_EmployeeCode_St.Text.CompareTo(this.tEdit_EmployeeCode_Ed.Text) > 0))
                (this.tEdit_EmployeeCode_St.Text.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_EmployeeCode_Ed.Text.TrimEnd().PadLeft(4, '0')) > 0))
            {
                //message = "担当者コードの範囲に誤りがあります";
                message = "担当者の範囲に誤りがあります";
                errControl = this.tEdit_EmployeeCode_St;
                return result;
            }

            // 地区範囲チェック
            if ((this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt()) > (this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                message = "地区の範囲に誤りがあります";
                errControl = this.tNedit_SalesAreaCode_St;
                return result;
            }

            // 業種範囲チェック
            if ((this.tNedit_BusinessTypeCode_Ed.GetInt() != 0) &&
                (this.tNedit_BusinessTypeCode_St.GetInt()) > (this.tNedit_BusinessTypeCode_Ed.GetInt()))
            {
                message = "業種の範囲に誤りがあります";
                errControl = this.tNedit_BusinessTypeCode_St;
                return result;
            }

            // 得意先コード範囲チェック
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                //message = "得意先コードの範囲に誤りがあります";
                message = "得意先の範囲に誤りがあります";
                //errControl = this.tNedit_CustomerCode_Ed;
                errControl = this.tNedit_CustomerCode_St;
                return result;
            }

            // 仕入先範囲チェック
            if ((this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                (this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
            {
                message = "仕入先の範囲に誤りがあります";
                errControl = this.tNedit_SupplierCd_St;
                return result;
            }
            // 2008.12.12 30413 犬飼 チェック処理の順序を修正 <<<<<<END

            // 伝票番号範囲チェック
            if ((this.tNedit_SupplierSlipNo_Ed.Text != "") &&
                (this.tNedit_SupplierSlipNo_St.Text.CompareTo(this.tNedit_SupplierSlipNo_Ed.Text) > 0))
            {
                message = "伝票番号の範囲に誤りがあります";
                errControl = this.tNedit_SupplierSlipNo_St;
                return result;
            }
            
            // ↓ 2008.01.30 Keigo Yata Add /////////////////////////////////////////////////////////////////////

            // 粗利チェックの入力範囲 空白だとエラー表示
            if (this.GrsProfitCheckLower_tNedit.Text == "")
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // 2008.10.02 30413 犬飼 粗利チェックの適正と上限のチェックを変更 >>>>>>START
            //if (this.GrsProfitCheckBest_tNedit.Text == "")
            if ((this.GrsProfitCheckBest_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckBest_tNedit.Text) == 0.0))
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            //if (this.GrsProfitCheckUpper_tNedit.Text == "")
            if ((this.GrsProfitCheckUpper_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckUpper_tNedit.Text) == 0.0))
            {
                message = "粗利率を入力してください";
                errControl = this.GrsProfitCheckUpper_tNedit;
                return result;
            }            

            ////粗利チェックの入力範囲(％) 100.0％を超えるとエラー表示
            //if ((double.Parse(this.GrsProfitCheckLower_tEdit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckLower_tEdit.Text) > 100.0))
            //{
            //    message = "粗利チェックの範囲に誤りがあります";
            //    errControl = this.GrsProfitCheckLower_tEdit;
            //    return result;
            //}

            //if (double.Parse(this.GrsProfitCheckBest_tEdit.Text) > 100.0)
            //{
            //    message = "粗利チェックの範囲に誤りがあります";
            //    errControl = this.GrsProfitCheckBest_tEdit;
            //    return result;
            //}

            //if (double.Parse(this.GrsProfitCheckUpper_tEdit.Text) > 100.0)
            //{
            //    message = "粗利チェックの範囲に誤りがあります";
            //    errControl = this.GrsProfitCheckUpper_tEdit;
            //    return result;
            //}
            
            // 2008.10.02 30413 犬飼 粗利チェックの範囲が同数値の場合エラーとする >>>>>>START
            // 適正値より下限が大きいとエラー表示
            //if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) > 0.0))
            if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) >= 0))
            {
                message = "粗利チェックの範囲に誤りがあります";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // 上限より適正値が大きいとエラー表示
            //if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) > 0.0))
            if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) >= 0))
            {
                message = "粗利チェックの範囲に誤りがあります";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }
            

            // ↑ 2008.01.30 Keigo Yata Add ////////////////////////////////////////////////////////////////////


            // ↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////
            // キャリア選択内容チェック
            //if (this.checkedListBox_Carrier.CheckedItems.Count == 0)
            //{
            //    message = "対象キャリアは必ず一つ以上選択してください";
            //    errControl = this.checkedListBox_Carrier;
            //    return result;
            //}
 
            // 売上形式選択内容チェック
            //if (this.checkedListBox_SalesFormal.CheckedItems.Count == 0)
            //{
            //    message = "対象売上形式は必ず一つ以上選択してください";
            //    errControl = this.checkedListBox_SalesFormal;
            //    return result;
            //}

            // 販売形態選択内容チェック
            //if (this.checkedListBox_SalesFormCode.CheckedItems.Count == 0)
            //{
            //    message = "対象販売形態は必ず一つ以上選択してください";
            //    errControl = this.checkedListBox_SalesFormCode;
            //    return result;
            //}
            // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////

            // 2008.09.01 30413 犬飼 粗利率のチェックを追加 >>>>>>START
            if (this.ultraCheckEditor_GrsProfitRatePrint.Checked)
            {
                if ((this.GrsProfitRatePrintVal_tNedit.Text == "") || (this.GrsProfitRatePrintVal_tNedit.GetValue() == 0.00))
                {
                    // 粗利率印字値チェック
                    message = "指定条件のみ印刷の粗利率を入力してください";
                    errControl = this.GrsProfitRatePrintVal_tNedit;
                    return result;
                }
                if (this.tComboEditor_GrsProfitRatePrintDiv.SelectedIndex == -1)
                {
                    // 粗利率印字区分チェック
                    message = "指定条件のみ印刷の粗利率印字区分を入力してください";
                    errControl = this.tComboEditor_GrsProfitRatePrintDiv;
                    return result;
                }
            }
            // 2008.09.01 30413 犬飼 粗利率のチェックを追加 <<<<<<END            

            return true;    
        }

        /// <summary>
        /// 日付範囲チェック呼び出し(売上日)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange_SalesDays(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 >>>>>>START
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false); // DEL 2009/04/07
            // 2008.08.01 30413 犬飼 範囲を３ケ月に変更 <<<<<<END

            // --- ADD 2009/04/07 -------------------------------->>>>>
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, true);

            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

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
		/// 
		/// </summary>
        /// <param name="extraInfo"></param>
		/// <returns></returns>
        private int SearchData(ExtrInfo_MAHNB02347E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件が変わっているならリモーティング
            if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
            {
                try
                {
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
        /// <br>Update Note: 2013/01/04 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note: 2020/02/27 3H 尹安</br>
        /// <br>管理番号   : 11570208-00 軽減税率対応</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(ref ExtrInfo_MAHNB02347E extraInfo)
        {
            // 企業コード
            extraInfo.EnterpriseCode = this._enterpriseCode;
            // 選択拠点
            // 拠点オプションありのとき
            if (IsOptSection)
            {
                ArrayList secList = new ArrayList();
                // 全社選択かどうか
                if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("00")))
                {
                    extraInfo.ResultsAddUpSecList = new string[1];
                    extraInfo.ResultsAddUpSecList[0] = "00";
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

            // 売上日付(開始)        
            extraInfo.SalesDateSt = this.SalesDateStRF_tDateEdit.GetLongDate();
            // 売上日付(終了)        
            extraInfo.SalesDateEd = this.SalesDateEdRF_tDateEdit.GetLongDate();
           
            // ↓ 2007.11.08 Keigo Yata Change ////////////////////////////////////////////////////////////////////
            //// 出荷日付(開始)        
            //extraInfo.ShipmentDaySt = this.ShipmentDayStRF_tDateEdit.GetLongDate();
            //// 出荷日付(終了)        
            //extraInfo.ShipmentDayEd = this.ShipmentDayEdRF_tDateEdit.GetLongDate();
            // ↑ 2007.11.08 Keigo Yata Change ///////////////////////////////////////////////////////////////////

            // ↓ 2007.11.08 keigo Yata Add //////////////////////////////////////////////////////////////////////
            // 入力日付(開始)        
            extraInfo.SearchSlipDateSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
            // 入力日付(終了)        
            extraInfo.SearchSlipDateEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            // ↑ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////

            // 拠点種別
            //extraInfo.SectionKind = this._selectedAddUpCd;
            // 選択システムコード
            //extraInfo.DataInputSystemCodeList = (int[])new ArrayList(this._selectedhSystemTable.Values).ToArray(typeof(int));

            // 2008.07.07 30413 犬飼 改頁 >>>>>>START
            extraInfo.NewPageType = Convert.ToInt32(this.tComboEditor_NewPageType.SelectedItem.DataValue);
            // 2008.07.07 30413 犬飼 改頁 <<<<<<END

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字区分
            extraInfo.TaxPrintDiv = Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue);

            // XMLの税率情報取得
            if (Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue) == 0)
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

            // 原価・粗利出力
            extraInfo.CostOut = Convert.ToInt32(this.ultraOptionSet_CostOut.CheckedIndex);

            // --- ADD 2009/04/13 -------------------------------->>>>>
            extraInfo.PrintDailyFooter = Convert.ToInt32(this.ultraOptionSet_PrintDailyFooter.CheckedIndex);
            // --- ADD 2009/04/13 --------------------------------<<<<<

            //↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////
            //明細単位
            //if (Convert.ToInt32(this.ultraOptionSet_RowDetailMode.CheckedIndex) == 1)
            //{
            //    extraInfo.IsDetails = false;
            //}
            //else
            //{
            //    extraInfo.IsDetails = true;
            //}
            // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////

            // 出力順
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

            //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
            //罫線印字
            extraInfo.LinePrintDiv = (int)this.tComboEditor_LinePrintDiv.Value;
            //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<

            // 2008.07.07 30413 犬飼 取得箇所の変更 >>>>>>START
            // 得意先(開始)
            //extraInfo.CustomerCodeSt = this.CustomerCodeStRF_Nedit.GetInt();
            //// 得意先(終了)
            //extraInfo.CustomerCodeEd = this.CustomerCodeEdRF_Nedit.GetInt();

            //// 伝票区分
            //extraInfo.SalesSlipCd = Convert.ToInt32(this.tComboEditor_SalesSlipCd.SelectedItem.DataValue) - 1;
            //// 赤伝区分
            //extraInfo.DebitNoteDiv = Convert.ToInt32(this.tComboEditor_DebitNoteDiv.SelectedItem.DataValue) - 1;
            // 2008.07.07 30413 犬飼 取得箇所の変更 <<<<<<END
            
            // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 売上形式(1つ以上選択されている前提)
            //int[] ix = new int[this.checkedListBox_SalesFormal.CheckedItems.Count];
            //string[] strList = new string[this.checkedListBox_SalesFormal.CheckedItems.Count];
            //if (this.checkedListBox_SalesFormal.Items.IndexOf(this.checkedListBox_SalesFormal.CheckedItems[0]) == 0)
            //{
            //    // 「全て」の場合
            //    ix[0] = 0;
            //    strList[0] = (string)this.checkedListBox_SalesFormal.CheckedItems[0];
            //}
            //else
            //{
            //    for (int i = 0; i < this.checkedListBox_SalesFormal.CheckedItems.Count; i++)
            //    {
            //        ix[i] = (int)this._salesFormalList.GetKey(this._salesFormalList.IndexOfValue(this.checkedListBox_SalesFormal.CheckedItems[i]));
            //        strList[i] = (string)this.checkedListBox_SalesFormal.CheckedItems[i];
            //    }
            //}
            //extraInfo.SalesFormal = ix;
            //extraInfo.SalesFormalList = strList;

            // 商品区分グループ(開始)
            //extraInfo.LargeGoodsGanreCdSt = this.LargeGoodsGanreCdSt_tEdit.Text;
            // 商品区分グループ(終了)
            //extraInfo.LargeGoodsGanreCdEd = this.LargeGoodsGanreCdEd_tEdit.Text;

            // 商品区分(開始)
            //extraInfo.MediumGoodsGanreCdSt = this.MediumGoodsGanreCdSt_tEdit.Text;
            // 商品区分(終了)
            //extraInfo.MediumGoodsGanreCdEd = this.MediumGoodsGanreCdEd_tEdit.Text;

            // 機種コード(開始)
            //extraInfo.CellphoneModelCodeSt = this.CellphoneModelCodeSt_tEdit.Text;
            // 機種コード(終了)
            //extraInfo.CellphoneModelCodeEd = this.CellphoneModelCodeEd_tEdit.Text;
            // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            // ↓ 2007.11.08 Keigo Yata Change ///////////////////////////////
            // 商品コード(開始)
            //extraInfo.GoodsCodeSt = this.GoodsCodeSt_tEdit.Text;
            // 商品コード(終了)
            //extraInfo.GoodsCodeEd = this.GoodsCodeEd_tEdit.Text;
            // ↑ 2007.11.08 Keigo Yata Change //////////////////////////////

            // 2008.10.02 30413 犬飼 0埋め対応 >>>>>>START
            //// ↓ 2007.11.08 Keigo Yata Add /////////////////////////////////
            //// 発行者コード(開始)
            //extraInfo.SalesInputCodeSt = this.tEdit_SalesInputCode_St.Text;
            //// 発行者コード(終了)
            //extraInfo.SalesInputCodeEd = this.tEdit_SalesInputCode_Ed.Text;
            //// ↑ 2007.11.08 Keigo Yata Add /////////////////////////////////
            // 発行者コード(開始)
            if (this.tEdit_SalesInputCode_St.Text.Trim() == "")
            {
                extraInfo.SalesInputCodeSt = "";
            }
            else
            {
                extraInfo.SalesInputCodeSt = this.tEdit_SalesInputCode_St.Text.Trim().PadLeft(4, '0');
            }
            // 発行者コード(終了)
            if (this.tEdit_SalesInputCode_Ed.Text.Trim() == "")
            {
                extraInfo.SalesInputCodeEd = "";
            }
            else
            {
                extraInfo.SalesInputCodeEd = this.tEdit_SalesInputCode_Ed.Text.Trim().PadLeft(4, '0');
            }

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

            // 2008.07.07 30413 犬飼 追加項目 >>>>>>START
            // 地区(開始)
            extraInfo.SalesAreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();
            // 地区(終了)
            extraInfo.SalesAreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

            // 業種(開始)
            extraInfo.BusinessTypeCodeSt = this.tNedit_BusinessTypeCode_St.GetInt();
            // 業種(終了)
            extraInfo.BusinessTypeCodeEd = this.tNedit_BusinessTypeCode_Ed.GetInt();
            // 2008.07.07 30413 犬飼 追加項目 <<<<<<END

            // 2008.07.07 30413 犬飼 取得箇所の変更 >>>>>>START
            // 得意先(開始)
            extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            // 得意先(終了)
            extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.07.07 30413 犬飼 取得箇所の変更 <<<<<<END

            // 2008.07.07 30413 犬飼 追加項目 >>>>>>START
            // 仕入先(開始)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
            // 仕入先(終了)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            // 2008.07.07 30413 犬飼 追加項目 <<<<<<END

            // 2008.07.07 30413 犬飼 取得箇所の変更 >>>>>>START
            // 伝票番号(開始)
            extraInfo.SalesSlipNumSt = this.tNedit_SupplierSlipNo_St.Text;
            // 伝票番号(終了)
            extraInfo.SalesSlipNumEd = this.tNedit_SupplierSlipNo_Ed.Text;

            // 伝票区分
            extraInfo.SalesSlipCd = Convert.ToInt32(this.tComboEditor_SalesSlipCd.SelectedItem.DataValue) - 1;
            
            // 赤伝区分
            extraInfo.DebitNoteDiv = Convert.ToInt32(this.tComboEditor_DebitNoteDiv.SelectedItem.DataValue) - 1;
            // 2008.07.07 30413 犬飼 取得箇所の変更 <<<<<<END

            // 2008.07.07 30413 犬飼 追加項目 >>>>>>START
            // 発行タイプ
            int value = Convert.ToInt32(this.tComboEditor_LogicalDeleteCode.SelectedItem.DataValue);
            // ADD 陳健 K2014/02/06 ------------------------->>>>>
            if (!this._deleteFlag && this._deleteUpdateFlag)
            {
                if (value == 2) value = 3;
            }
            // ADD 陳健 K2014/02/06 -------------------------<<<<<
            switch (value)
            {
                case 0:
                    {
                        extraInfo.SalesSlipUpdateCd = -1;
                        extraInfo.LogicalDeleteCode = 0;
                        break;
                    }
                case 1:
                    {
                        extraInfo.SalesSlipUpdateCd = 1;
                        extraInfo.LogicalDeleteCode = 0;
                        break;
                    }
                case 2:
                    {
                        extraInfo.SalesSlipUpdateCd = -1;
                        extraInfo.LogicalDeleteCode = 1;
                        break;
                    }
                case 3:
                    {
                        // TODO 相反する項目
                        extraInfo.SalesSlipUpdateCd = 1;
                        extraInfo.LogicalDeleteCode = 1;
                        break;
                    }
            }

            // 出力指定
            value = Convert.ToInt32(this.tComboEditor_SalesOrderDivCd.SelectedItem.DataValue);
            //extraInfo.SalesOrderDivCd = Convert.ToInt32(this.tComboEditor_SalesOrderDivCd.SelectedItem.DataValue) - 1;
            switch (value)
            {
                case 0:
                    {
                        extraInfo.SalesOrderDivCd = -1;
                        extraInfo.WayToOrder = -1;
                        break;
                    }
                case 1:
                    {
                        extraInfo.SalesOrderDivCd = 1;
                        extraInfo.WayToOrder = -1;
                        break;
                    }
                case 2:
                    {
                        extraInfo.SalesOrderDivCd = 0;
                        extraInfo.WayToOrder = -1;
                        break;
                    }
                case 3:
                    {
                        extraInfo.SalesOrderDivCd = -1;
                        extraInfo.WayToOrder = 2;
                        break;
                    }
            }
            // 2008.07.07 30413 犬飼 追加項目 <<<<<<END
            
            // ↓ 2007.11.08 Keigo Yata Add /////////////////////////////////
            
            //粗利チェック下限
            extraInfo.GrsProfitCheckLower = double.Parse(this.GrsProfitCheckLower_tNedit.Text);

            //粗利チェック2
            extraInfo.GrossMarginSt = this.GrossMarginSt_Nedit.GetValue();

            //粗利チェック3
            extraInfo.GrossMargin2Ed = this.GrossMargin2Ed_Nedit.GetValue();

            //粗利チェック4
            extraInfo.GrossMargin3Ed = this.GrossMargin3Ed_Nedit.GetValue();
            
            //粗利チェック適正
            extraInfo.GrsProfitCheckBest = double.Parse(this.GrsProfitCheckBest_tNedit.Text);

            //粗利チェック上限
            extraInfo.GrsProfitCheckUpper = double.Parse(this.GrsProfitCheckUpper_tNedit.Text);

            //粗利チェック1(マーク)
            extraInfo.GrossMargin1Mark = this.GrossMargin1Mark_tEdit.Text;

            //粗利チェック2(マーク)
            extraInfo.GrossMargin2Mark = this.GrossMargin2Mark_tEdit.Text;

            //粗利チェック3(マーク)
            extraInfo.GrossMargin3Mark = this.GrossMargin3Mark_tEdit.Text;

            //粗利チェック4(マーク)
            extraInfo.GrossMargin4Mark = this.GrossMargin4Mark_tEdit.Text;

            // ↑ 2007.11.08 Keigo Yata Add /////////////////////////////////

            // ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // キャリア(1つ以上選択されている前提)
            //ix = new int[this.checkedListBox_Carrier.CheckedItems.Count];
            //strList = new string[this.checkedListBox_Carrier.CheckedItems.Count];
            //if (this.checkedListBox_Carrier.Items.IndexOf(this.checkedListBox_Carrier.CheckedItems[0]) == 0)
            //{
            //    // 「全て」の場合
            //    ix[0] = 0;
            //    strList[0] = (string)this.checkedListBox_Carrier.CheckedItems[0];
            //}
            //else
            //{
            //    for (int i = 0; i < this.checkedListBox_Carrier.CheckedItems.Count; i++)
            //    {
            //        ix[i] = (int)this._carrierList.GetKey(this._carrierList.IndexOfValue(this.checkedListBox_Carrier.CheckedItems[i]));
            //        strList[i] = (string)this.checkedListBox_Carrier.CheckedItems[i];
            //    }
            //}

            //extraInfo.CarrierCodeList = ix;
            //extraInfo.CarrierNameList = strList

            // 販売形態(1つ以上選択されている前提)
            //ix = new int[this.checkedListBox_SalesFormCode.CheckedItems.Count];
            //strList = new string[this.checkedListBox_SalesFormCode.CheckedItems.Count];
            //if (this.checkedListBox_SalesFormCode.Items.IndexOf(this.checkedListBox_SalesFormCode.CheckedItems[0]) == 0)
            //{
            //    // 「全て」の場合
            //    ix[0] = 0;
            //    strList[0] = (string)this.checkedListBox_SalesFormCode.CheckedItems[0];
            //}
            //else
            //{
            //    for (int i = 0; i < this.checkedListBox_SalesFormCode.CheckedItems.Count; i++)
            //    {
            //        ix[i] = (int)this._salesFormList.GetKey(this._salesFormList.IndexOfValue(this.checkedListBox_SalesFormCode.CheckedItems[i]));
            //        strList[i] = (string)this.checkedListBox_SalesFormCode.CheckedItems[i];
            //    }
            //}

            //extraInfo.SalesFormCodeList = ix;
            //extraInfo.SalesFormList = strList;
            // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////////////////////////////////////////////

            // 2008.07.07 30413 犬飼 追加項目 >>>>>>START
            // 指定条件のみ印刷
            // 売価ゼロ
            if (this.ultraCheckEditor_ZeroSalesPrint.Checked)
            {
                extraInfo.ZeroSalesPrint = 1;
            }
            else
            {
                extraInfo.ZeroSalesPrint = 0;
            }
            // 原価ゼロ
            if (this.ultraCheckEditor_ZeroCostPrint.Checked)
            {
                extraInfo.ZeroCostPrint = 1;
            }
            else
            {
                extraInfo.ZeroCostPrint = 0;
            }
            // 粗利ゼロ
            if (this.ultraCheckEditor_ZeroGrsProfitPrint.Checked)
            {
                extraInfo.ZeroGrsProfitPrint = 1;
            }
            else
            {
                extraInfo.ZeroGrsProfitPrint = 0;
            }
            // 粗利ゼロ以下
            if (this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Checked)
            {
                extraInfo.ZeroUdrGrsProfitPrint = 1;
            }
            else
            {
                extraInfo.ZeroUdrGrsProfitPrint = 0;
            }
            // 粗利率
            if (this.ultraCheckEditor_GrsProfitRatePrint.Checked)
            {
                extraInfo.GrsProfitRatePrint = 1;
                extraInfo.GrsProfitRatePrintVal = this.GrsProfitRatePrintVal_tNedit.GetValue();
                extraInfo.GrsProfitRatePrintDiv = Convert.ToInt32(this.tComboEditor_GrsProfitRatePrintDiv.SelectedItem.DataValue);
            }
            else
            {
                extraInfo.GrsProfitRatePrint = 0;
            }
            // 2008.07.07 30413 犬飼 追加項目 <<<<<<END            
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            _SalesConfDataTable = Broadleaf.Application.UIData.MAHNB02349EA.CT_SalesConfDataTable;
        }

        // ↓ 2007.11.08 Delete /////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// キャリアリスト取得処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: </br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2006.09.08</br>
        ///// </remarks>
        //private void GetCarrierList()
        //{
        //    // キャリアマスタ読込
        //    // ----- iitani c ---------- start 2007.05.22
        //    //CarrierAcs carrierAcs = new CarrierAcs();
        //    //ArrayList retList = new ArrayList();
        //    //int status = carrierAcs.Search(out retList, this._enterpriseCode);
        //    //foreach (CarrierU carrierU in retList)
        //    //{
        //    //    this._carrierList.Add(carrierU.CarrierCode, carrierU.CarrierName);
        //    //}
        //    CarrierOdrAcs carrierOdrAcs = new CarrierOdrAcs();
        //    List<Carrier> retList = new List<Carrier>();
        //    int status = carrierOdrAcs.SearchLocalDB(out retList, this._enterpriseCode, this._ownSectionCode);

        //    foreach (Carrier carrier in retList)
        //    {
        //        this._carrierList.Add(carrier.CarrierCode, carrier.CarrierName);
        //        this._carrierDspList.Add(carrier.CarrierName);
        //    }
        //    // ----- iitani c ---------- start 2007.05.22
        //}

        ///// <summary>
        ///// 売上形式リスト取得処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: </br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2006.09.08</br>
        ///// </remarks>
        //private void GetSalesFormalList()
        //{
        //    //// 売上形式固定値取得
        //    this._salesFormalList.Add(10, SalesFormalStAcs.SALESFORMAL_10);
        //    this._salesFormalList.Add(11, SalesFormalStAcs.SALESFORMAL_11);
        //    this._salesFormalList.Add(20, SalesFormalStAcs.SALESFORMAL_20);
        //}

        ///// <summary>
        ///// 販売形態取得処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: </br>
        ///// <br>Programmer	: 980023 飯谷 耕平</br>
        ///// <br>Date		: 2007.05.24</br>
        ///// </remarks>
        //private void GetSalseFormList()
        //{
        //    // 販売形態マスタ読込
        //    SalesFormAcs salesFormAcs = new SalesFormAcs();
        //    ArrayList retList = new ArrayList();
        //    SalesForm salesForm = new SalesForm();
        //    int totalCount = 0;
        //    bool nextData = true;

        //    int status = salesFormAcs.Search(out retList, out totalCount, out nextData, this._enterpriseCode, 0, salesForm);
        //    foreach (SalesForm retSalesForm in retList)
        //    {
        //        this._salesFormList.Add(retSalesForm.SalesFormCode, retSalesForm.SalesFormName);
        //    }
        //}
        // ↑ 2007.11.08 Delete /////////////////////////////////////////////////////////////////////////////


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
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void MAHNB02340U_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._saleConfListAcs = new SaleConfAcs();

            // 最上位フォーム取得
		    this.GetTopForm();

            // 拠点オプション有無を取得する
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 本社/拠点情報を取得する
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
            ParentToolbarGuideSettingEvent(true); // ADD 2010/08/16

            // ↓ 2007.11.08 Keigo Yata Delete /////////////////////
            // キャリアリスト取得
            //this.GetCarrierList();

            // 売上形式リスト取得
            //this.GetSalesFormalList();

            // 販売形態リスト取得
            //this.GetSalseFormList();
            // ↑ 2007.11.08 Keigo Yata Delete /////////////////////

            // 売上全体設定マスタから粗利率と粗利マークを取得する
            
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._salesTtlSt = new SalesTtlSt();
            int status = 0;
            ArrayList retList = null;

            // 2008.07.07 30413 犬飼 拠点コード"0"のレコードを取得 >>>>>>START
            //EnterpriseCodeがマスタを呼ぶときのKeyになっている。
            //this._salesTtlStAcs.Read(out this._salesTtlSt, LoginInfoAcquisition.EnterpriseCode);
            status = this._salesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (SalesTtlSt wkSalesTtlSt in retList)
                {
                    // 2008.11.18 30413 犬飼 自拠点の情報を優先して検索する >>>>>>START
                    if (wkSalesTtlSt.SectionCode.Trim().Equals(this._ownSectionCode.TrimEnd()))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                        break;
                    }
                    // 2008.11.18 30413 犬飼 自拠点の情報を優先して検索する <<<<<<END
                    
                    if (wkSalesTtlSt.SectionCode.Trim().Equals("00"))
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                    }
                }
            }
            // 2008.07.07 30413 犬飼 拠点コード"0"のレコードを取得 <<<<<<END
            

		    this.Initial_Timer.Enabled = true;

            // ADD 2009/04/01 不具合対応[12909]：スペースキーでの項目選択機能を実装 ---------->>>>>
            #region ラジオボタンのスペースキー制御

            CostOutRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_CostOut);
            CostOutRadioKeyPressHelper.StartSpaceKeyControl();

            // --- ADD 2009/04/14 -------------------------------->>>>>
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_PrintDailyFooter);
            PrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/04/14 --------------------------------<<<<<

            //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
            ConsClearRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_ConsClear);
            ConsClearRadioKeyPressHelper.StartSpaceKeyControl();
            //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<

            #endregion  // ラジオボタンのスペースキー制御
            // ADD 2009/04/01 不具合対応[12909]：スペースキーでの項目選択機能を実装 ----------<<<<<
            // ADD K2014/02/06 陳健 ----------------------->>>>>
            this.adjustComboxVisual();
            // ADD K2014/02/06 陳健 -----------------------<<<<<
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
        private void MAHNB02340U_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }

        // ↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// キャリアチェックボックスリスト選択項目変更時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_Carrier_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (e.Index == 0)
        //    {
        //        if (this.checkedListBox_Carrier.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」が選択された場合、「全て」以外の選択を解除
        //            for (int i = 1; i < checkedListBox_Carrier.Items.Count; i++)
        //            {
        //                this.checkedListBox_Carrier.SetItemChecked(i, false);
        //            }
        //        }
        //        else
        //        {
        //            if (this.checkedListBox_Carrier.CheckedItems.Count == 0)
        //            {
        //                // 選択項目が全て解除された場合、「全て」を選択状態にする
        //                this.checkedListBox_Carrier.SetItemChecked(0, true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (this.checkedListBox_Carrier.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
        //            this.checkedListBox_Carrier.SetItemChecked(0, false);
        //        }
        //    }
        //}
        
        ///// <summary>
        ///// 売上形式チェックボックスリスト選択項目変更時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormal_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (e.Index == 0)
        //    {
        //        if (this.checkedListBox_SalesFormal.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」が選択された場合、「全て」以外の選択を解除
        //            for (int i = 1; i < checkedListBox_SalesFormal.Items.Count; i++)
        //            {
        //                this.checkedListBox_SalesFormal.SetItemChecked(i, false);
        //            }
        //        }
        //        else
        //        {
        //            if (this.checkedListBox_SalesFormal.CheckedItems.Count == 0)
        //            {
        //                // 選択項目が全て解除された場合、「全て」を選択状態にする
        //                this.checkedListBox_SalesFormal.SetItemChecked(0, true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (this.checkedListBox_SalesFormal.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
        //            this.checkedListBox_SalesFormal.SetItemChecked(0, false);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 販売形態チェックボックスリスト選択項目変更時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormCode_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (e.Index == 0)
        //    {
        //        if (this.checkedListBox_SalesFormCode.GetItemChecked(0) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」が選択された場合、「全て」以外の選択を解除
        //            for (int i = 1; i < checkedListBox_SalesFormCode.Items.Count; i++)
        //            {
        //                this.checkedListBox_SalesFormCode.SetItemChecked(i, false);
        //            }
        //        }
        //        else
        //        {
        //            if (this.checkedListBox_SalesFormCode.CheckedItems.Count == 0)
        //            {
        //                // 選択項目が全て解除された場合、「全て」を選択状態にする
        //                this.checkedListBox_SalesFormCode.SetItemChecked(0, true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (this.checkedListBox_SalesFormCode.GetItemChecked(e.Index) == false) // これから選択されようとしているので値は逆
        //        {
        //            // 「全て」以外が選択状態にされた場合は、「全て」の選択状態を解除
        //            this.checkedListBox_SalesFormCode.SetItemChecked(0, false);
        //        }
        //    }

        //}
        // ↑ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note : 2013/01/04 田建委</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2013/03/11 cheq</br>
        /// <br>管理番号    : 10900690-00 2013/03/26配信分</br>
        /// <br>              Redmine#34987 フォーカス遷移の追加対応</br>
        /// <br>Update Note : 2020/02/27 3H 尹安</br>
        /// <br>管理番号    : 11570208-00　軽減税率対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {         

            // --- ADD 2010/08/16------->>>>>
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tComboEditor_NewPageType":
                    case "PrintOder_tComboEditor":
                    case "tComboEditor_SalesSlipCd":
                    case "tComboEditor_DebitNoteDiv":
                    case "tComboEditor_LogicalDeleteCode":
                    case "tComboEditor_SalesOrderDivCd":
                    case "tComboEditor_GrsProfitRatePrintDiv":
                    case "tComboEditor_DateDiv": // ADD 2012/11/06 張曼 Redmine#33216
                    case "tComboEditor_LinePrintDiv": // ADD 2013/01/04 田建委 Redmine#34098
                    case "tComboEditor_TaxPrintDiv":  // ADD 3H 尹安 2020/02/27
                        this._preCtrlName = (TComboEditor)e.PrevCtrl;     
                        this.setTComboEditorByName(e.PrevCtrl.Name);
                        this.SupplierCdEd_GuideBtn.Focus();               
                        this._preCtrlName.Focus();                       
                        break;

                }
            }
            if (e.NextCtrl != null && (e.NextCtrl is TComboEditor))
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }
            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            // --- ADD 2010/08/16-----<<<<<

            
            // 2008.09.24 30413 犬飼 入力支援の削除 >>>>>>START
            //// 入力支援 ============================================ //
            //// 売上日
            //if ((e.PrevCtrl == this.SalesDateStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.SalesDateEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.SalesDateStRF_tDateEdit, this.SalesDateEdRF_tDateEdit);
            //}

            //// 入力日
            //if ((e.PrevCtrl == this.SerchSlipDataStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.SerchSlipDataEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.SerchSlipDataStRF_tDateEdit, this.SerchSlipDataEdRF_tDateEdit);
            //}

            //// 得意先コード
            //if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            //{
            //    AutoSetEndValue(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed);
            //}

            //// ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////
            //// 商品区分グループ
            ////if (e.PrevCtrl == this.LargeGoodsGanreCdSt_tEdit)
            ////{
            ////    AutoSetEndValue(this.LargeGoodsGanreCdSt_tEdit, this.LargeGoodsGanreCdEd_tEdit);
            ////}
            
            //// 商品区分
            ////if (e.PrevCtrl == this.MediumGoodsGanreCdSt_tEdit)
            ////{
            ////    AutoSetEndValue(this.MediumGoodsGanreCdSt_tEdit, this.MediumGoodsGanreCdEd_tEdit);
            ////}
            
            //// 機種コード
            ////if (e.PrevCtrl == this.CellphoneModelCodeSt_tEdit)
            ////{
            ////    AutoSetEndValue(this.CellphoneModelCodeSt_tEdit, this.CellphoneModelCodeEd_tEdit);
            ////}
            //// ↑ 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////

            //// ↓ 2007.11.08 Keigo Yata Change //////////////////////////////////////////////////////////////
            //// 商品コード
            ////if (e.PrevCtrl == this.GoodsCodeSt_tEdit)
            ////{
            ////    AutoSetEndValue(this.GoodsCodeSt_tEdit, this.GoodsCodeEd_tEdit);
            ////}
            //// ↑ 2007.11.08 Keigo Yata Change //////////////////////////////////////////////////////////////

            //// ↓ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////
            //// 発行者コード
            //if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
            //{
            //    AutoSetEndValue(this.tEdit_SalesInputCode_St, this.tEdit_SalesInputCode_Ed);
            //}
            //// ↑ 2007.11.08 Keigo Yata Add //////////////////////////////////////////////////////////////

            //// 担当コード
            //if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            //{
            //    AutoSetEndValue(this.tEdit_EmployeeCode_St, this.tEdit_EmployeeCode_Ed);
            //}

            //// 伝票番号
            //if (e.PrevCtrl == this.tNedit_SupplierSlipNo_St)
            //{
            //    AutoSetEndValue(this.tNedit_SupplierSlipNo_St, this.tNedit_SupplierSlipNo_Ed);
            //}

            //// 2008.07.29 30413 犬飼 地区、業種、仕入先の入力支援を追加 >>>>>>START
            //// 地区
            //if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
            //{
            //    AutoSetEndValue(this.tNedit_SalesAreaCode_St, this.tNedit_SalesAreaCode_Ed);
            //}

            //// 業種
            //if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
            //{
            //    AutoSetEndValue(this.tNedit_BusinessTypeCode_St, this.tNedit_BusinessTypeCode_Ed);
            //}

            //// 仕入先
            //if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            //{
            //    AutoSetEndValue(this.tNedit_SupplierCd_St, this.tNedit_SupplierCd_Ed);
            //}
            //// 2008.07.29 30413 犬飼 地区、業種、仕入先の入力支援を追加 <<<<<<END
            // 2008.09.24 30413 犬飼 入力支援の削除 <<<<<<END
            
            // 2008.09.17 30413 犬飼 ガイドボタン遷移制御 >>>>>>START
            if (!e.ShiftKey)
            {
               
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                {
                    if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // 発行者(開始)→発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了) → 担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }

                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→業種(開始)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        // 業種(開始)→業種(終了)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→伝票番号(開始)
                        e.NextCtrl = this.tNedit_SupplierSlipNo_St;
                    }
                    //---ADD 2010/08/16---------->>>>>>
                    else if (e.PrevCtrl == this.tNedit_SupplierSlipNo_Ed)
                    {
                        // 伝票番号(終了)→伝票区分
                        e.NextCtrl = this.tComboEditor_SalesSlipCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SalesSlipCd)
                    {
                        // 伝票区分→ 赤伝区分
                        e.NextCtrl = this.tComboEditor_DebitNoteDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_DebitNoteDiv)
                    {
                        //  赤伝区分→ 発行タイプ
                        e.NextCtrl = this.tComboEditor_LogicalDeleteCode;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LogicalDeleteCode)
                    {
                        //  発行タイプ → 出力指定
                        e.NextCtrl = this.tComboEditor_SalesOrderDivCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SalesOrderDivCd)
                    {
                        //出力指定  →  (未満)粗利率
                        e.NextCtrl = this.GrossMargin1Mark_tEdit;
                    }
                    else if (e.PrevCtrl == this.GrossMargin1Mark_tEdit)
                    {
                        //(未満)粗利率 → 0.0%
                        e.NextCtrl = this.GrsProfitCheckLower_tNedit;
                    }
                    else if (e.PrevCtrl == this.GrsProfitCheckLower_tNedit)
                    {
                        //0.0% → %
                        e.NextCtrl = this.GrossMargin2Mark_tEdit;
                    }
                    else if (e.PrevCtrl == this.GrossMargin2Mark_tEdit)
                    {
                        // % → 0.0% 
                        e.NextCtrl = this.GrsProfitCheckBest_tNedit;
                    }
                    else if (e.PrevCtrl == this.GrsProfitCheckBest_tNedit)
                    {
                        //0.0% → %
                        e.NextCtrl = this.GrossMargin3Mark_tEdit;
                    }
                    else if (e.PrevCtrl == this.GrossMargin3Mark_tEdit)
                    {
                        // % → %以上
                        e.NextCtrl = this.GrsProfitCheckUpper_tNedit;
                    }
                    else if (e.PrevCtrl == this.GrsProfitCheckUpper_tNedit)
                    {
                        //%以上 → 
                        e.NextCtrl = this.GrossMargin4Mark_tEdit;
                    }
                    else if (e.PrevCtrl == this.GrossMargin4Mark_tEdit)
                    {
                        //    → 売価ゼロ
                        e.NextCtrl = this.ultraCheckEditor_ZeroSalesPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroSalesPrint)
                    {
                        // 売価ゼロ → 原価ゼロ
                        e.NextCtrl = this.ultraCheckEditor_ZeroCostPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroCostPrint)
                    {
                        //原価ゼロ → 粗利ゼロ
                        e.NextCtrl = this.ultraCheckEditor_ZeroGrsProfitPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroGrsProfitPrint)
                    {
                        //粗利ゼロ → 粗利ゼロ以下
                        e.NextCtrl = this.ultraCheckEditor_ZeroUdrGrsProfitPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroUdrGrsProfitPrint)
                    {
                        // 粗利ゼロ以下 → 粗利率
                        e.NextCtrl = this.GrsProfitRatePrintVal_tNedit;
                        //e.NextCtrl = this.ultraCheckEditor_GrsProfitRatePrint;
                    }
                    else if (e.PrevCtrl == this.GrsProfitRatePrintVal_tNedit) 
                    {
                         // 粗利率 → %
                        e.NextCtrl = this.tComboEditor_GrsProfitRatePrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_GrsProfitRatePrintDiv)
                    {
                        // --- ADD 2010/08/26 ---------->>>>>
                        if (this.ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }
                        // --- ADD 2010/08/26 ----------<<<<<
                        e.NextCtrl = null;
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_DateDiv)
                    {
                        if (this.SalesDateStRF_tDateEdit.Enabled)
                        {   // 日付指定 → 売上日
                            e.NextCtrl = this.SalesDateStRF_tDateEdit;
                        }
                        else
                        {
                            // 日付指定 → 入力日
                            e.NextCtrl = this.SerchSlipDataStRF_tDateEdit;
                        }
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                    else if (e.PrevCtrl == this.SalesDateStRF_tDateEdit)
                    {
                        // 売上日 → ～
                        e.NextCtrl = this.SalesDateEdRF_tDateEdit;
                    }
                    
                    else if (e.PrevCtrl == this.SalesDateEdRF_tDateEdit)
                    {
                        //　売上日　→ 　入力日
                        //e.NextCtrl = this.SerchSlipDataStRF_tDateEdit;  // DEL 2012/11/06 張曼 Redmine#33216

                        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                        if (this.SerchSlipDataStRF_tDateEdit.Enabled)
                        {
                            //　売上日　→ 　入力日
                            e.NextCtrl = this.SerchSlipDataStRF_tDateEdit;
                        }
                        else
                        {
                            /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                            // 売上日 →　改頁
                            e.NextCtrl = this.tComboEditor_NewPageType;
                            ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                            //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                            // 売上日 →　罫線印字
                            e.NextCtrl = this.tComboEditor_LinePrintDiv;
                            //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                        }
                        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                    }
                    
                    else if (e.PrevCtrl == this.SerchSlipDataStRF_tDateEdit)
                    {
                        // 入力日　→  ～
                        e.NextCtrl = this.SerchSlipDataEdRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.SerchSlipDataEdRF_tDateEdit)
                    {
                        /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                        // ～ →　改頁
                        e.NextCtrl = this.tComboEditor_NewPageType;
                        ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                        //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                        // 入力日　→ 罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    }
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    {
                        //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
                        // 改頁　 →　罫線印字
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
                        ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                        /*----- DEL 2013/01/04 田建委 Redmine#34098 ----->>>>>
                        // 改頁　 →　原価・粗利出力
                        e.NextCtrl = this.ultraOptionSet_CostOut;
                        this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());
                        ----- DEL 2013/01/04 田建委 Redmine#34098 -----<<<<<*/
                    //} // DEL cheq 2013/03/11 Redmine#34987
                    //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                        // 罫線印字　 →　原価・粗利出力
                        e.NextCtrl = this.ultraOptionSet_CostOut;
                        this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());
                         ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                        //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                        // 罫線印字　 →　改頁
                        e.NextCtrl = this.tComboEditor_NewPageType;
                        //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    }
                    //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
                    // --- DEL START 3H 尹安 2020/02/27 ----->>>>>
                    ////----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    //{
                    //    //改頁 → 原価・粗利出力
                    //    e.NextCtrl = this.ultraOptionSet_CostOut;
                    //    this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());
                    //}
                    // --- DEL END 3H 尹安 2020/02/27 -----<<<<< 
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    {
                        //改頁 → 税別内訳印字
                        e.NextCtrl = this.tComboEditor_TaxPrintDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                    {
                        //税別内訳印字 → 原価・粗利出力
                        e.NextCtrl = this.ultraOptionSet_CostOut;
                        this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<< 
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    else if (e.PrevCtrl == this.ultraOptionSet_CostOut)
                    {                           
                        //原価・粗利出力 → 日計印字
                        e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                        this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                    else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                    {                 
                        //日計印字 → 出力後条件クリア
                        e.NextCtrl = this.ultraOptionSet_ConsClear;
                        this.ultraOptionSet_ConsClear.FocusedIndex = int.Parse(this.ultraOptionSet_ConsClear.CheckedItem.DataValue.ToString());
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                    //else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)//DEL 2012/11/06 張曼 Redmine#33216
                    else if (e.PrevCtrl == this.ultraOptionSet_ConsClear)//ADD 2012/11/06 張曼 Redmine#33216
                    {
                        // 出力後条件クリア → 出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // 出力順 → 発行者
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_GrsProfitRatePrintDiv)
                    {
      
                        if (e.Key == Keys.Enter)
                        {
                            SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
                            SFCMN06002C printInfo = new SFCMN06002C();     // 印刷情報パラメータ

                            // 企業コード
                            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            printInfo.kidopgid = THIS_ASSEMBLYID;             // 起動ＰＧＩＤ
                            printInfo.key = PDF_PRINT_KEY;               // PDF履歴管理用KEY情報

                            // 画面→抽出条件クラス
                            ExtrInfo_MAHNB02347E saleConfListCndtnWork = new ExtrInfo_MAHNB02347E();
                            this.SetExtraInfoFromScreen(ref saleConfListCndtnWork);

                            // 抽出条件の設定
                            printInfo.jyoken = saleConfListCndtnWork;

                            this._saleConfListCndtnWork = saleConfListCndtnWork;

                            printDialog.PrintInfo = printInfo;

                            // 帳票選択ガイド
                            DialogResult dialogResult = printDialog.ShowDialog();

                            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                            {
                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                // Leftキー 押下
                }
                else if (e.Key == Keys.Left)
                {
                    if (e.PrevCtrl == this.tComboEditor_GrsProfitRatePrintDiv)
                    {
                        //  % → 粗利率
                        e.NextCtrl = this.GrsProfitRatePrintVal_tNedit;
                    }
                    else if (e.PrevCtrl == this.GrsProfitRatePrintVal_tNedit)
                    {
                        // 粗利率  →  粗利ゼロ以下
                        e.NextCtrl = ultraCheckEditor_ZeroUdrGrsProfitPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroUdrGrsProfitPrint)
                    {
                        // 粗利ゼロ以下  → 粗利ゼロ
                        e.NextCtrl = ultraCheckEditor_ZeroGrsProfitPrint;
                    }
                    else if (e.PrevCtrl == this.ultraCheckEditor_ZeroGrsProfitPrint)
                    {
                        // 粗利ゼロ → 原価ゼロ
                        e.NextCtrl = ultraCheckEditor_ZeroCostPrint;
                    }
                    else if (e.PrevCtrl == ultraCheckEditor_ZeroCostPrint) 
                    {
                        // 原価ゼロ → 売価ゼロ
                        e.NextCtrl = ultraCheckEditor_ZeroSalesPrint;
                    }
                    else if (e.PrevCtrl == ultraCheckEditor_ZeroSalesPrint)
                    {
                        // 売価ゼロ  →  
                        e.NextCtrl = GrossMargin4Mark_tEdit;
                    }
                    else if (e.PrevCtrl == GrossMargin4Mark_tEdit)
                    {
                        //   →  ％以上
                        e.NextCtrl = GrsProfitCheckUpper_tNedit;
                    }
                    else if (e.PrevCtrl == GrsProfitCheckUpper_tNedit)
                    {
                        //  ％以上 → %(終了)
                        e.NextCtrl = GrossMargin3Mark_tEdit;
                    }
                    else if (e.PrevCtrl == GrossMargin3Mark_tEdit)
                    {
                        //  %(終了) → %(開始)
                        e.NextCtrl = GrsProfitCheckBest_tNedit;
                    }
                    else if (e.PrevCtrl == GrsProfitCheckBest_tNedit)
                    {
                        //  %(開始) → %(終了)
                        e.NextCtrl = GrossMargin2Mark_tEdit;
                    }
                    else if (e.PrevCtrl == this.GrossMargin2Mark_tEdit) 
                    {
                        //  %(終了) → %(開始)
                        e.NextCtrl = GrsProfitCheckLower_tNedit;
                    }
                    else if (e.PrevCtrl == GrsProfitCheckLower_tNedit) 
                    {
                        // %(開始) → 
                        e.NextCtrl = GrossMargin1Mark_tEdit;
                    }
                    else if (e.PrevCtrl == GrossMargin1Mark_tEdit)
                    {
                        // ％未満 → 出力指定
                        e.NextCtrl = tComboEditor_SalesOrderDivCd;
                    }
                    else if (e.PrevCtrl == tComboEditor_SalesOrderDivCd) 
                    {
                        // 出力指定 →  発行タイプ
                        e.NextCtrl = tComboEditor_LogicalDeleteCode;
                    }
                    else if (e.PrevCtrl == tComboEditor_LogicalDeleteCode)
                    {
                        // 発行タイプ → 赤伝区分
                        e.NextCtrl = tComboEditor_DebitNoteDiv;
                    }
                    else if (e.PrevCtrl == tComboEditor_DebitNoteDiv) 
                    {
                        // 赤伝区分  → 伝票区分
                        e.NextCtrl = tComboEditor_SalesSlipCd;
                    }
                    else if (e.PrevCtrl == tComboEditor_SalesSlipCd)
                    {
                        // 伝票区分  → 伝票番号(終了)
                        e.NextCtrl = tNedit_SupplierSlipNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierSlipNo_Ed)
                    {
                        // 伝票番号(終了) → 伝票番号(開始)
                        e.NextCtrl = this.tNedit_SupplierSlipNo_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierSlipNo_St)
                    {
                        // 伝票番号(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了) → 仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始) → 得意先（終了）
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先（終了）→ 得意先（開始）
                        e.NextCtrl = tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先（終了）→ 業種（終了）
                        e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種（終了）  → 業種（開始）
                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        // 業種（開始）  →  地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)    →   地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)   →  担当者（終了）
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者（終了）→  担当者（開始）
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者（開始）→ 発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了) → 発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        // 発行者(開始)  → 出力順
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // 出力順  → 出力後条件クリア
                        e.NextCtrl = this.ultraOptionSet_ConsClear;
                        this.ultraOptionSet_ConsClear.FocusedIndex = int.Parse(this.ultraOptionSet_ConsClear.CheckedItem.DataValue.ToString());
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                    //else if (e.PrevCtrl == this.PrintOder_tComboEditor)//DEL 2012/11/06 張曼 Redmine#33216
                    else if (e.PrevCtrl == this.ultraOptionSet_ConsClear)//ADD 2012/11/06 張曼 Redmine#33216
                    {
                        // 出力後条件クリア  →  日計印字
                        e.NextCtrl = ultraOptionSet_PrintDailyFooter;
                        this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                               
                    }
                    else if (e.PrevCtrl == ultraOptionSet_PrintDailyFooter)
                    {
                        // 日計印字  → 原価・粗利出力
                        e.NextCtrl = ultraOptionSet_CostOut;
                        this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());
                                  
                    }
                    else if (e.PrevCtrl == this.ultraOptionSet_CostOut)
                    {
                        /*----- DEL 2013/01/04 田建委 Redmine#34098 ----->>>>>
                        //  原価・粗利出力  →  改頁
                        e.NextCtrl = tComboEditor_NewPageType;
                        ----- DEL 2013/01/04 田建委 Redmine#34098 ----->>>>>*/
                        /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                        //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
                        //  原価・粗利出力  →  罫線印字
                        e.NextCtrl = tComboEditor_LinePrintDiv;
                        //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
                        ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                        // --- DEL START 3H 尹安 2020/02/27 ----->>>>>
                        ////----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                        ////  原価・粗利出力  →  改頁
                        //e.NextCtrl = tComboEditor_NewPageType;
                        ////----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                        // --- DEL END 3H 尹安 2020/02/27 -----<<<<<
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        //  原価・粗利出力  →  税別内訳印字
                        e.NextCtrl = tComboEditor_TaxPrintDiv;
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                    {
                        //  税別内訳印字  →  改頁
                        e.NextCtrl = tComboEditor_NewPageType;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        //  罫線印字  →  改頁
                        e.NextCtrl = tComboEditor_NewPageType;
                    }
                    //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
                    ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    {
                        //  改頁  →  罫線印字
                        e.NextCtrl = tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<

                    //else if (e.PrevCtrl == this.tComboEditor_NewPageType) // DEL cheq 2013/03/11 Redmine#34987
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv) // ADD cheq 2013/03/11 Redmine#34987
                    {
                        // 改頁  →  入力日(終了)
                        //e.NextCtrl = SerchSlipDataEdRF_tDateEdit.Controls[3]; // DEL 2012/11/06 張曼 Redmine#33216
                       
                        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                        if (this.SerchSlipDataEdRF_tDateEdit.Enabled)
                        {
                            // 改頁  →  入力日(終了)  // DEL cheq cheq 2013/03/11 Redmine#34987
                            // 罫線印字  →  入力日(終了) // ADD cheq 2013/03/11 Redmine#34987
                            e.NextCtrl = SerchSlipDataEdRF_tDateEdit.Controls[3];
                        }
                        else
                        {
                            // 改頁 → 売上日(終了) // DEL cheq cheq 2013/03/11 Redmine#34987
                            // 罫線印字  →  売上日(終了) // ADD cheq 2013/03/11 Redmine#34987
                            e.NextCtrl = SalesDateEdRF_tDateEdit.Controls[3];
                        }
                        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                        
                    }
                    
                    else if (e.PrevCtrl == this.SerchSlipDataEdRF_tDateEdit)
                    {
                        // 入力日(終了) → 入力日(開始)
                        e.NextCtrl = SerchSlipDataStRF_tDateEdit;
                    }
                    
                    else if (e.PrevCtrl == this.SerchSlipDataStRF_tDateEdit)
                    {
                        // 入力日(開始) → 売上日(終了)
                        //e.NextCtrl = SalesDateEdRF_tDateEdit.Controls[3]; // DEL 2012/11/06 張曼 Redmine#33216

                        //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                        if (this.SalesDateEdRF_tDateEdit.Enabled)
                        {
                            // 入力日(開始) → 売上日(終了)
                            e.NextCtrl = SalesDateEdRF_tDateEdit.Controls[3];
                        }
                        else
                        {
                            // 入力日(開始) → 日付指定
                            e.NextCtrl = this.tComboEditor_DateDiv;
                        }
                        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                    }
                    
                    else if (e.PrevCtrl == this.SalesDateEdRF_tDateEdit)
                    {
                        // 売上日(終了) →  売上日(開始)
                        e.NextCtrl = SalesDateStRF_tDateEdit;
                    }
                   
                    else if (e.PrevCtrl == this.SalesDateStRF_tDateEdit)
                    {
                        // 売上日(開始) →   %
                        // e.NextCtrl = null;   //DEL 2012/11/06 張曼 Redmine#33216

                        // 売上日(開始) →   日付指定
                        e.NextCtrl = this.tComboEditor_DateDiv;   //ADD 2012/11/06 張曼 Redmine#33216
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_DateDiv)
                    {
                        // 日付指定 →   %
                        e.NextCtrl = null;
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                }
            }
                // ADD 2010/08/16------<<<<<<
            
            else
            {
                // SHIFTキー押下
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierSlipNo_St)
                    {
                        // 伝票番号(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→業種(終了)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        // 業種(終了)→業種(開始)
                        e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                    }                     
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        // 業種(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→発行者(終了)
                        e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        // 発行者(終了)→発行者(開始)
                        e.NextCtrl = this.tEdit_SalesInputCode_St;
                    }
                    //----- ADD 2013/01/04 田建委 Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // 出力順  → 出力後条件クリア
                        e.NextCtrl = this.ultraOptionSet_ConsClear;
                        this.ultraOptionSet_ConsClear.FocusedIndex = int.Parse(this.ultraOptionSet_ConsClear.CheckedItem.DataValue.ToString());
                    }
                    else if (e.PrevCtrl == this.ultraOptionSet_CostOut)
                    {
                        /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                        //  原価・粗利出力  →  罫線印字
                        e.NextCtrl = tComboEditor_LinePrintDiv;
                        ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                        // --- DEL START 3H 尹安 2020/02/27 ----->>>>>
                        ////----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                        ////  原価・粗利出力  →  改頁
                        //e.NextCtrl = tComboEditor_NewPageType;
                        ////----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                        // --- DEL END 3H 尹安 2020/02/27 -----<<<<<
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        //  原価・粗利出力  →  税別内訳印字
                        e.NextCtrl = tComboEditor_TaxPrintDiv;
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                    {
                        //  税別内訳印字  →  改頁
                        e.NextCtrl = tComboEditor_NewPageType;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    /*----- DEL 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        //  罫線印字  →  改頁
                        e.NextCtrl = tComboEditor_NewPageType;
                    }
                     ----- DEL 2013/03/11 cheq Redmine#34987 -----<<<<<*/
                    //----- ADD 2013/03/11 cheq Redmine#34987 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_NewPageType)
                    {
                        //  改頁  →  罫線印字
                        e.NextCtrl = tComboEditor_LinePrintDiv;
                    }
                    //----- ADD 2013/03/11 cheq Redmine#34987 -----<<<<<
                    //----- ADD 2013/01/04 田建委 Redmine#34098 -----<<<<<
                    else if (e.PrevCtrl == this.SalesDateStRF_tDateEdit)
                    {
                        // 売上日(開始)→売上日(開始)
                        // e.NextCtrl = null;   // DEL 2012/11/06 張曼 Redmine#33216

                        // 売上日(開始)→日付指定
                        e.NextCtrl = this.tComboEditor_DateDiv;// ADD 2012/11/06 張曼 Redmine#33216
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_DateDiv)
                    {
                        // 日付指定→日付指定
                        e.NextCtrl = null;
                    }
                    //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<
                }
            } 
            // 2008.09.17 30413 犬飼 ガイドボタン遷移制御 <<<<<<END

            // --- 2010/08/16 ---------->>>>>
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_SalesInputCode_St":
                    case "tEdit_SalesInputCode_Ed":
                    case "tEdit_EmployeeCode_St":
                    case "tEdit_EmployeeCode_Ed":
                    case "tNedit_SalesAreaCode_St":
                    case "tNedit_SalesAreaCode_Ed":
                    case "tNedit_BusinessTypeCode_St":
                    case "tNedit_BusinessTypeCode_Ed":
                    case "tNedit_CustomerCode_St":
                    case "tNedit_CustomerCode_Ed":
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
            // --- 2010/08/16 ----------<<<<<
}

        // ↓ 2007.11.08 Keigo Yata Delete 
        ///// <summary>
        ///// キャリアチェックボックスリスト キーダウン処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_Carrier_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        // 末尾のItemの場合
        //        if (checkedListBox_Carrier.SelectedIndex == checkedListBox_Carrier.Items.Count - 1)
        //        {
        //            e.Handled = true;
        //            // 開始商品区分グループにフォーカス移動
        //            LargeGoodsGanreCdSt_tEdit.Focus();
        //        }
        //    }

        //    if (e.KeyCode == Keys.Up)
        //    {
        //        // 先頭のItemの場合
        //        if (checkedListBox_Carrier.SelectedIndex == 0)
        //        {
        //            e.Handled = true;
        //            // 伝票区分にフォーカス移動
        //            tComboEditor_SalesSlipCd.Focus();
        //        }
        //    }
        //}

        ///// <summary>
        ///// <summary>
        ///// キャリアチェックボックスリスト 離脱時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_Carrier_Leave(object sender, EventArgs e)
        //{
        //    checkedListBox_Carrier.ClearSelected();
        //}

        ///// <summary>
        ///// 売上形式チェックボックスリスト キーダウン処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormal_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        // 末尾のItemの場合
        //        if (checkedListBox_SalesFormal.SelectedIndex == checkedListBox_SalesFormal.Items.Count - 1)
        //        {
        //            e.Handled = true;
        //            // 開始商品区分にフォーカス移動
        //            MediumGoodsGanreCdSt_tEdit.Focus();
        //        }
        //    }

        //    if (e.KeyCode == Keys.Up)
        //    {
        //        // 先頭のItemの場合
        //        if (checkedListBox_SalesFormal.SelectedIndex == 0)
        //        {
        //            e.Handled = true;
        //            // 赤伝区分にフォーカス移動
        //            tComboEditor_DebitNoteDiv.Focus();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 売上形式チェックボックスリスト 離脱時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormal_Leave(object sender, EventArgs e)
        //{
        //    checkedListBox_SalesFormal.ClearSelected();
        //}

        ///// <summary>
        ///// 販売形態チェックボックスリスト キーダウン処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        // 末尾のItemの場合
        //        if (checkedListBox_SalesFormCode.SelectedIndex == checkedListBox_SalesFormCode.Items.Count - 1)
        //        {
        //            e.Handled = true;
        //            // 開始販売形態にフォーカス移動
        //            LargeGoodsGanreCdSt_tEdit.Focus();
        //        }
        //    }

        //    if (e.KeyCode == Keys.Up)
        //    {
        //        // 先頭のItemの場合
        //        if (checkedListBox_SalesFormCode.SelectedIndex == 0)
        //        {
        //            e.Handled = true;
        //            // 伝票区分にフォーカス移動
        //            tComboEditor_SalesSlipCd.Focus();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 販売形態チェックボックスリスト 離脱時処理
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        //private void checkedListBox_SalesFormCode_Leave(object sender, EventArgs e)
        //{
        //    checkedListBox_SalesFormCode.ClearSelected();
        //}
        // ↑ 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////////

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

            // 2008.07.29 30413 犬飼 初期フォーカスを売上日に変更 >>>>>>START
            // 初期フォーカス設定
            //this.SerchSlipDataStRF_tDateEdit.Focus(); // DEL 2012/11/06 張曼 Redmine#33216
            //this.SalesDateStRF_tDateEdit.Focus();
            // 2008.07.29 30413 犬飼 初期フォーカスを売上日に変更 <<<<<<END
            this.tComboEditor_DateDiv.Focus(); // ADD 2012/11/06 張曼 Redmine#33216
    	    // メインフレームにツールバー設定通知
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
            //--------ADD BY凌小青 on 2011/11/29 for Redmine#8182 -------->>>>>>>>>>>>>
            this.uiMemInput1.ReadMemInput();
            this._salesConfInputInitData.Deserialize();
            //----- DEL 2012/01/30 田建委 Redmine#28202 ----------------------------->>>>>
            //this.GrsProfitCheckLower_tNedit.Text = this._salesConfInputInitData.GrsProfitCheckLower;
            //this.GrsProfitCheckBest_tNedit.Text = this._salesConfInputInitData.GrsProfitCheckBest;
            //this.GrsProfitCheckUpper_tNedit.Text = this._salesConfInputInitData.GrsProfitCheckUpper;
            //----- DEL 2012/01/30 田建委 Redmine#28202 -----------------------------<<<<<
            this.GrsProfitRatePrintVal_tNedit.Text = this._salesConfInputInitData.GrsProfitRatePrintVal;
            if (this._salesConfInputInitData.ZeroCostPrint == 0)
            {
                this.ultraCheckEditor_ZeroCostPrint.Checked = false;
            }
            else
            {
                this.ultraCheckEditor_ZeroCostPrint.Checked = true;
            }
            if (this._salesConfInputInitData.ZeroSalesPrint == 0)
            {
                this.ultraCheckEditor_ZeroSalesPrint.Checked = false;
            }
            else
            {
                this.ultraCheckEditor_ZeroSalesPrint.Checked = true;
            }
            if (this._salesConfInputInitData.ZeroGrsProfitPrint == 0)
            {
                this.ultraCheckEditor_ZeroGrsProfitPrint.Checked = false;
            }
            else
            {
                this.ultraCheckEditor_ZeroGrsProfitPrint.Checked = true;
            }
            if (this._salesConfInputInitData.ZeroUdrGrsProfitPrint == 0)
            {
                this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Checked = false;
            }
            else
            {
                this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Checked = true;
            }
            if (this._salesConfInputInitData.GrsProfitRatePrint == 0)
            {
                this.ultraCheckEditor_GrsProfitRatePrint.Checked = false;
            }
            else
            {
                this.ultraCheckEditor_GrsProfitRatePrint.Checked = true;
            }
                //--------ADD BY凌小青 on 2011/11/29 for Redmine#8182 --------<<<<<<<<<<<<<<
            showDateTypeByDateDiv(this.tComboEditor_DateDiv.SelectedIndex);// ADD 2012/11/06 張曼 Redmine#33216 
	    }

    	        
        ///// <summary>
        ///// Control.GroupCollapsingイベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        ///// <remarks>
        ///// <br>Note        : エクスプローラバーのグループを展開される際に発生します。</br>
        ///// <br>Programmer  : 18012 Y.Sasaki</br>
        ///// <br>Date        : 2005.09.14</br>
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

	    #endregion



	    #region IPrintConditionInpTypeChart メンバ


	    #endregion

	    #region IPrintConditionInpTypeSelectedSection メンバ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="checkState"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDefaultState"></param>
        /// <returns></returns>
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
        /// <param name="SelectAddUpCd"></param>
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
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.07.04 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.04 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                ParentToolbarGuideSettingEvent(true);
            }
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }
        #endregion

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.07.04 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.04 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                ParentToolbarGuideSettingEvent(true);
            }
            // 2008.10.02 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
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

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
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

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// 商品区分グループコード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void LargeGoodsGanreCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    LGoodsGanre lGoodsGanre = new LGoodsGanre();
        //    status = _lGoodsGanreAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out lGoodsGanre);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.LargeGoodsGanreCdSt_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //    }
        //}
        
        ///// <summary>
        ///// 商品区分グループコード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void LargeGoodsGanreCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    LGoodsGanre lGoodsGanre = new LGoodsGanre();
        //    status = _lGoodsGanreAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out lGoodsGanre);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.LargeGoodsGanreCdEd_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //    }
        //}

        ///// <summary>
        ///// 商品区分コード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void MediumGoodsGanreCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    MGoodsGanre mGoodsGanre = new MGoodsGanre();
        //    status = _mGoodsGanreAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, "", out mGoodsGanre,0);
        //
        //
        // 項目に展開
        //if (status == 0)
        //{
        //    this.MediumGoodsGanreCdSt_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //}
        //    
        //}

        ///// <summary>
        ///// 商品区分コード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void MediumGoodsGanreCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    MGoodsGanre mGoodsGanre = new MGoodsGanre();
        //    status = _mGoodsGanreAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, "", out mGoodsGanre,0);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.MediumGoodsGanreCdEd_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //    }
        //}

        ///// <summary>
        ///// 機種コード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void CellphoneModelCodeSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    CellphoneModel cellphoneModel = new CellphoneModel();
        //    status = _cellphoneModelAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, 0, out cellphoneModel);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.CellphoneModelCodeSt_tEdit.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //    }
        //}

        ///// <summary>
        ///// 機種コード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void CellphoneModelCodeEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // ガイド起動
        //    CellphoneModel cellphoneModel = new CellphoneModel();
        //    status = _cellphoneModelAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, 0, out cellphoneModel);

        //    // 項目に展開
        //    if (status == 0)
        //    {
        //        this.CellphoneModelCodeEd_tEdit.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //    }
        //}
        // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////////////////////

        // ↓ 2007.11.08 Keigo Yata Change ////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// 商品コード(開始)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void GoodsCodeSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

        //    if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //    {
        //        // 商品コード設定処理
        //        //this.GoodsCodeSt_tEdit.Text = goodsUnitData.GoodsCode;
        //    }
        //}

        ///// <summary>
        ///// 商品コード(終了)ガイド起動ボタン起動イベント
        ///// </summary>
        //private void GoodsCodeEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

        //    if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //    {
        //        // 商品コード設定処理
        //        //this.GoodsCodeEd_tEdit.Text = goodsUnitData.GoodsCode;
        //    }
        //}
        // ↑ 2007.11.08 Keigo Yata Change ////////////////////////////////////////////////////////////////////////////////
       
        // ↓ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 発行者コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        /// 
        private void SalesInputCodeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            //GoodsUnitData goodsUnitData;
            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

            //if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            //{
            //    // 入力者コード設定処理
            //    //this.GoodsCodeSt_tEdit.Text = goodsUnitData.GoodsCode;
            //}

            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// 発行者コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void SalesInputCodeEd_GuideBtn_Click(object sender, EventArgs e)
        {
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

        //    if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //    {
        //        // 入力者コード設定処理
        //        //this.GoodsCodeEd_tEdit.Text = goodsUnitData.GoodsCode;
        //    }

            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }

        }

        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>PrintSettingGroup
        /// <br>Programmer	: 矢田 敬吾</br>
        /// <br>Date		: 2008.1.10</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region ◎ GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 矢田 敬吾</br>
        /// <br>Date		: 2008.1.10</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_CustomerConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ExtraConditionCodeGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        #endregion
       

        // 粗利チェックの下限、最適、上限とコントロールの連動を定義
        private void GrsProfitCheckLower_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMarginSt_Nedit.Text = this.GrsProfitCheckLower_tNedit.Text;
        }

        private void GrsProfitCheckBest_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin2Ed_Nedit.Text = this.GrsProfitCheckBest_tNedit.Text;
        }

        private void GrsProfitCheckUpper_tNedit_ValueChanged(object sender, EventArgs e)
        {
            this.GrossMargin3Ed_Nedit.Text = this.GrsProfitCheckUpper_tNedit.Text;
        }

        // ↑ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Control.Click イベント(SupplierCdSt_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.04</br>
        /// </remarks>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// Control.Click イベント(SupplierCdEd_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 仕入先（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.04</br>
        /// </remarks>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(false);  // ADD 2010/08/16
            }
        }

        /// <summary>
        /// Control.Click イベント(SalesAreaCodeSt_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 地区（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.07</br>
        /// </remarks>
        private void SalesAreaCodeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// Control.Click イベント(SalesAreaCodeEd_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 地区（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.07</br>
        /// </remarks>
        private void SalesAreaCodeEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// Control.Click イベント(BusinessTypeCodeSt_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 業種（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.07</br>
        /// </remarks>
        private void BusinessTypeCodeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// Control.Click イベント(BusinessTypeCodeEd_GuideBtn)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 業種（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.07</br>
        /// </remarks>
        private void BusinessTypeCodeEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);

                // 2008.10.02 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.02 30413 犬飼 フォーカス制御を追加 <<<<<<END
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// Control.Leave イベント(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 粗利チェックの下限値からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.02</br>
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
        /// <br>Date       : 2008.10.02</br>
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
        /// <br>Date       : 2008.10.02</br>
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

        /// <summary>
        /// Control.Leave イベント(GrsProfitRatePrintVal_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 指定条件の粗利率からフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.02</br>
        /// </remarks>
        private void GrsProfitRatePrintVal_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // 空の場合は、初期値を設定
                tNedit.Text = "0.0";
            }
        }
        //---ADD 2010/08/16---------->>>>>
        /// <summary>
        /// コードからの選択を可能へ変更する
        /// </summary>
        /// <param name="name"></param>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
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
        /// ultraOptionSet_CostOut_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2020/02/27 3H 尹安</br>
        /// <br>管理番号    : 11570208-00 軽減税率対応</br>
        private void ultraOptionSet_CostOut_KeyDown(object sender, KeyEventArgs e)
        {
            this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
            switch(e.KeyCode)
            {
                case Keys.Left:
                    {
                        // this.tComboEditor_NewPageType.Focus();  // DEL 3H 尹安 2020/02/27
                        this.tComboEditor_TaxPrintDiv.Focus();     // ADD 3H 尹安 2020/02/27
                        break;
                    }
                case Keys.Right:
                    {
                        
                        this.ultraOptionSet_PrintDailyFooter.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// ultraOptionSet_PrintDailyFooter_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2013/01/04 田建委</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// </remarks>
        private void ultraOptionSet_PrintDailyFooter_KeyDown(object sender, KeyEventArgs e)
        {
            //this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString());//DEL 2012/11/06 張曼 Redmine#33216
            //this.ultraOptionSet_ConsClear.FocusedIndex = int.Parse(this.ultraOptionSet_ConsClear.CheckedItem.DataValue.ToString());//ADD 2012/11/06 張曼 Redmine#33216 // DEL 2013/01/04 田建委 Redmine#34098
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        this.ultraOptionSet_CostOut.FocusedIndex = int.Parse(this.ultraOptionSet_CostOut.CheckedItem.DataValue.ToString()); // ADD 2013/01/04 田建委 Redmine#34098
                        this.ultraOptionSet_CostOut.Focus();
                        break;
                    }
                case Keys.Right:
                    {
                        this.ultraOptionSet_ConsClear.FocusedIndex = int.Parse(this.ultraOptionSet_ConsClear.CheckedItem.DataValue.ToString()); // ADD 2013/01/04 田建委 Redmine#34098
                        //this.PrintOder_tComboEditor.Focus();//DEL 2012/11/06 張曼 Redmine#33216
                        this.ultraOptionSet_ConsClear.Focus();//ADD 2012/11/06 張曼 Redmine#33216
                        break;
                    }
                default:
                    break;
            }
        }

        // //---ADD 2012/11/06 張曼 Redmine#33216----->>>>>
        /// <summary>
        /// ultraOptionSet_ConsClear_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraOptionSet_ConsClear_KeyDown(object sender, KeyEventArgs e)
        {
            this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {

                        this.ultraOptionSet_PrintDailyFooter.Focus();
                        break;
                    }
                case Keys.Right:
                    {
                        this.PrintOder_tComboEditor.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Main_ultraExplorerBar_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DateDiv_ValueChanged(object sender, EventArgs e)
        {
            showDateTypeByDateDiv(this.tComboEditor_DateDiv.SelectedIndex);
        }


        //---ADD 2012/11/06 張曼 Redmine#33216-----<<<<<

        // ADD 陳健 K2014/02/06 ----------------------------------------->>>>>
        /// <summary>
        /// コントロールのVISUAL
        /// </summary>
        private bool adjustComboxVisual()
        {
            Infragistics.Win.ValueListItem valueListItem97 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem98 = new Infragistics.Win.ValueListItem();
            OperationAuthorityImpl _operationLimition = new OperationAuthorityImpl(EntityUtil.CategoryCode.Report, "MAHNB02340U", this._loginWorker);
            // 売上確認表操作権限レコードがないの場合
            if (_operationLimition.ProgramName == _operationLimition.ProgramId)
            {
                return false;
            }
            // OperationCode削除指定区分(削除)の操作権限
            //this._deleteFlag = _operationLimition.Enabled(3);         // DEL 陳健 2014/02/21
            this._deleteFlag = _operationLimition.Enabled(90);          // ADD 陳健 2014/02/21
            // OperationCode削除指定区分(訂正＋削除)の操作権限
            //this._deleteUpdateFlag = _operationLimition.Enabled(4);   // DEL 陳健 2014/02/21
            this._deleteUpdateFlag = _operationLimition.Enabled(91);    // ADD 陳健 2014/02/21

            this.tComboEditor_LogicalDeleteCode.Items.Clear();
            valueListItem97.DataValue = ((short)(0));
            valueListItem97.DisplayText = "0:通常";
            valueListItem98.DataValue = ((short)(1));
            valueListItem98.DisplayText = "1:訂正";
            this.tComboEditor_LogicalDeleteCode.Items.AddRange(new Infragistics.Win.ValueListItem[] { valueListItem97, valueListItem98 });
            // OperationCode削除指定区分(削除)の操作権限がある
            if (this._deleteFlag)
            {
                Infragistics.Win.ValueListItem valueListItem99 = new Infragistics.Win.ValueListItem();
                valueListItem99.DataValue = ((short)(2));
                valueListItem99.DisplayText = "2:削除";
                this.tComboEditor_LogicalDeleteCode.Items.AddRange(new Infragistics.Win.ValueListItem[] { valueListItem99 });

            }
            // OperationCode削除指定区分(訂正＋削除)の操作権限がある
            if (this._deleteUpdateFlag)
            {
                Infragistics.Win.ValueListItem valueListItem99 = new Infragistics.Win.ValueListItem();
                valueListItem99.DataValue = this.tComboEditor_LogicalDeleteCode.Items.Count;
                valueListItem99.DisplayText = this.tComboEditor_LogicalDeleteCode.Items.Count.ToString() + ":訂正＋削除";
                this.tComboEditor_LogicalDeleteCode.Items.AddRange(new Infragistics.Win.ValueListItem[] { valueListItem99 });

            }

            return false;
        }
        // ADD 陳健 K2014/02/06 -----------------------------------------<<<<<
        //---------ADD BY凌小青 on 2011/11/29 for Redmine#8182 ----------->>>>>>>>>
        /// <summary>
        /// Main_ultraExplorerBar_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ultraExplorerBar_Leave(object sender, EventArgs e)
        {
            //----- DEL 2012/01/30 田建委 Redmine#28202 ----------------------------->>>>>
            //this._salesConfInputInitData.GrsProfitCheckLower =GrsProfitCheckLower_tNedit.Text.ToString();
            //this._salesConfInputInitData.GrsProfitCheckBest = GrsProfitCheckBest_tNedit.Text.ToString();
            //this._salesConfInputInitData.GrsProfitCheckUpper = GrsProfitCheckUpper_tNedit.Text.ToString();
            //----- DEL 2012/01/30 田建委 Redmine#28202 -----------------------------<<<<<
            this._salesConfInputInitData.GrsProfitRatePrintVal = GrsProfitRatePrintVal_tNedit.Text.ToString();
            Dictionary<string, int> checkEditorValues = new Dictionary<string, int>();
            if (this.ultraCheckEditor_ZeroSalesPrint.Checked)
            {
                this._salesConfInputInitData.ZeroSalesPrint = 1;
            }
            else
            {
                this._salesConfInputInitData.ZeroSalesPrint = 0;
            }
            if (this.ultraCheckEditor_ZeroCostPrint.Checked)
            {
                this._salesConfInputInitData.ZeroCostPrint = 1;
            }
            else
            {
                this._salesConfInputInitData.ZeroCostPrint = 0;
            }
            if (this.ultraCheckEditor_ZeroGrsProfitPrint.Checked)
            {
                this._salesConfInputInitData.ZeroGrsProfitPrint = 1;
            }
            else
            {
                this._salesConfInputInitData.ZeroGrsProfitPrint = 0;
            }
            if (this.ultraCheckEditor_ZeroUdrGrsProfitPrint.Checked)
            {
                this._salesConfInputInitData.ZeroUdrGrsProfitPrint = 1;
            }
            else
            {
                this._salesConfInputInitData.ZeroUdrGrsProfitPrint = 0;
            }
            if (this.ultraCheckEditor_GrsProfitRatePrint.Checked)
            {
                this._salesConfInputInitData.GrsProfitRatePrint = 1;
            }
            else
            {
                this._salesConfInputInitData.GrsProfitRatePrint = 0;
            }
            this._salesConfInputInitData.Serialize();
        }
        //---------ADD BY凌小青 on 2011/11/29 for Redmine#8182 -----------<<<<<<<<<<<<

        //---ADD 2010/08/10----------<<<<<

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
        #endregion

        # region「デシリアライズ処理」
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
