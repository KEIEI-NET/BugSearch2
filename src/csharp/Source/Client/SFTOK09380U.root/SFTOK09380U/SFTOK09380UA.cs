# region ※using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;   // 2008.09.04 追加
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Infragistics.Win.UltraWinTabControl;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller.Facade;          // ADD 2008/10/10 不具合対応[6442] 
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 従業員情報入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 従業員情報設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer	: 980076 妻鳥　謙一郎</br>
	/// <br>Date		: 2004.03.19</br>
	/// <br>Update Note	: 2005.11.15  23006 高橋 明子</br>
	/// <br>			  ・参照型コンボボックス「削除済」表示対応</br>
	/// <br>Update Note	: 2005.11.16 23002 上野　耕平</br>
	/// <br>			  ・参照されている従業員の削除防止</br>
	/// <br>Update Note	: 2005.11.17 22011 柏原　頼人</br>
	/// <br>			  ・参照されている従業員の削除防止の対応をコメントアウト</br>
	/// <br>Update Note	: 2006.06.20 23001 秋山　亮介</br>
	/// <br>              1.レバレート原価類のDDの変更対応</br>
	/// <br>Update Note	: 2006.06.29 22033 三崎  貴史</br>
	/// <br>              ・拠点OPの判定を修正</br>
	/// <br>Update Note	: 2006.09.05 22033 三崎  貴史</br>
	/// <br>              ・フレームグリッドの列順を修正</br>
	/// <br>              ・ソースを少し整理</br>
    /// <br>Update Note	: 2006.12.11 20031 古賀　小百合</br>
    /// <br>              ・SFからMobile用に項目変更（削除のみ）</br>
    /// <br>Update Note	: 2007.04.02 20031 古賀　小百合</br>
    /// <br>              ・「抽出方法設定」ボタンを有効から無効に変更(携帯仕様)</br>
    /// <br>Update Note : 2007.05.22 20008 伊藤　豊</br>
    /// <br>              ・取得項目に「権限レベル１」「権限レベル２」を追加</br>
    /// <br>Update Note	: 2007.07.17 20031 古賀　小百合</br>
    /// <br>              ・「所属拠点」の背景色を青色に変更</br>
    /// <br>Update Note : 2007.08.14 980035 金沢 貞義</br>
    /// <br>              1.従業員詳細マスタの追加</br>
    /// <br>Update Note : 2008.06.04 30414 忍　幸史</br>
    /// <br>              ・「所属課」「所属部署変更日」「旧所属拠点」「旧所属部門」「旧所属課」削除</br>
    /// <br>Update Note : 2008.09.04 30434 工藤　恵優</br>
    /// <br>              ・「職種」コンボ、「雇用形態」コンボの項目設定の変更</br>
    /// <br>UpdateNote : 2008/10/06 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/10/10 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/11/04 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/11/10 30009 渋谷 大輔　UOE略称区分追加</br>
    /// <br>UpdateNote   : 2008/11/12 30009 渋谷 大輔　パスワードチェック処理のバグ修正</br>
    /// <br>UpdateNote   : 2008/11/14 30009 渋谷 大輔　バグ修正[7905]</br>
    /// <br>UpdateNote   : 2009/02/13 30414 忍 幸史　バグ修正[11419]</br>
    /// <br>UpdateNote   : 2009.03.02 20056 對馬 大輔　メール項目追加</br>
    /// <br>UpdateNote   : 2009.03.17 30414 忍 幸史　画面制御追加(ユーザー管理者フラグ)[11347]</br>
    /// <br>Update Note : 2010/02/18 30517 夏野 駿希</br>
    /// <br>              ・felica対応・デモ用にfelicaオプションチェック（_optFeliCaAcs）にはtrueをセットしています</br>
	/// <br>Update Note : 2012.05.29 30182 立谷　亮介</br>
	/// <br>              ・「売上伝票入力起動枚数」「得意先電子元帳起動枚数」項目追加</br>
    /// <br>Update Note: 2013/05/21 huangt </br>
    /// <br>管理番号   : 10902175-00 6月18日配信分（障害以外）</br>
    /// <br>           : Redmine#35765 従業員マスタ 起動枚数のエラーチェックの追加</br>
	/// </remarks>
	public class SFTOK09380UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ※Private Members (Component)

		private Infragistics.Win.Misc.UltraLabel Sex_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Birthday_Title_Label;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TComboEditor Sex_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_EmployeeCode;
		private Infragistics.Win.Misc.UltraLabel EmployeeCode_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Name_tEdit;
		private Infragistics.Win.Misc.UltraLabel Name_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Kana_tEdit;
		private Infragistics.Win.Misc.UltraLabel Kana_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit ShortName_tEdit;
		private Infragistics.Win.Misc.UltraLabel ShortName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel RetirementDtTm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel EnterCompanyDtTm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PortableTelNo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTelNo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BelongSelectionCode_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit LoginPassword_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit LoginId_tEdit;
		private Infragistics.Win.Misc.UltraLabel LoginPassword_Title_Label;
		private Infragistics.Win.Misc.UltraLabel LoginId_Title_Label;
		private Infragistics.Win.Misc.UltraLabel LoginPasswordAgain_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit LoginPasswordAgain_tEdit;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl MainTabControl;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 EnterCompanyDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 RetirementDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PortableTelNo_tEdit;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl GeneralTabPageControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SecurityTabPageControl;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 Birthday_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
		private Infragistics.Win.Misc.UltraLabel UserAdminFlag_uLabel;
		private Infragistics.Win.Misc.UltraLabel UserAdminName_uLabel;
        private Infragistics.Win.Misc.UltraLabel JobType_ultraLabel;
        private TComboEditor JobType_tComboEditor;
        private TComboEditor EmploymentForm_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EmploymentForm_ultraLabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl DetailsTabPageControl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private TEdit tEdit_SectionName;
        private TEdit tEdit_SectionCode;
        private TNedit EmployAnalysCode6_tNedit;
        private TNedit EmployAnalysCode5_tNedit;
        private TNedit EmployAnalysCode4_tNedit;
        private TNedit EmployAnalysCode3_tNedit;
        private TNedit EmployAnalysCode2_tNedit;
        private TNedit EmployAnalysCode1_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraButton BelongSubSectionGuide_ultraButton;
        private TEdit BelongSubSectionName_tEdit;
        private Infragistics.Win.Misc.UltraLabel BelongSubSectionTitle_Label;
        private Infragistics.Win.Misc.UltraLabel UOESnmDivTitle_Label;
        private TEdit UOESnmDiv_tEdit;
        private TEdit MailAddress2_tEdit;
        private TEdit MailAddress1_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel FeliCaInfo_Title_uLabel;
        private Infragistics.Win.Misc.UltraLabel FeliCaInfo_uLabel;
        private Infragistics.Win.Misc.UltraButton FeliCaMngGuide_uButton;
        private Infragistics.Win.Misc.UltraButton FeliCaMngDelete_uButton;
		private TNedit CustLedgerBootCnt_tNedit;
		private TNedit SalSlipInpBootCnt_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ■Constructor
		/// <summary>
		/// 従業員情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 従業員情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public SFTOK09380UA()
		{
			InitializeComponent();

            // 2010/02/18 Add felicaオプションチェック >>>
            //this._optFeliCaAcs = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0);
            this._optFeliCaAcs = true;
            // 2010/02/18 Add <<<

            // データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// デフォルト:true固定
			this._defaultAutoFillToColumn = false;
            // 2007.04.02  S.Koga  amend -----------------------------------------------------------------------
			//this._canSpecificationSearch = true;
            this._canSpecificationSearch = false;
            // -------------------------------------------------------------------------------------------------
            // 2007.08.14 追加 >>>>>>>>>>
            this._canSpecificationSearch = false;
            // 2007.08.14 追加 <<<<<<<<<<

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs(1);
			this._employeeAcs = new EmployeeAcs();
            //this._userGuideAcs = new UserGuideAcs();    // DEL 2008/11/04 不具合対応[7289]
			this._prevEmployee = null;
			this._nextData = false;
			this._totalCount = 0;
			this._employeeTable = new Hashtable();

            this.AuthorityLevel1Table = new Hashtable();
            this.AuthorityLevel2Table = new Hashtable();

            this._employeeDtl = new EmployeeDtl();      // 2007.08.14 追加
            this._companyInfAcs = new CompanyInfAcs();  // 2008.01.16 追加

            this._subSectionAcs = new SubSectionAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            
            //_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;

			// 拠点OPの判定
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>>
            // メニュー簡易起動オプションの判定
            this._opMenuSimpleStart = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_MenuSimpleStart) > 0);
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

            // 2007.09.04 削除および追加 >>>>>>>>>>
            //// 権限レベル１の設定
            //this.AuthorityLevel1Table.Clear();
            //this.AuthorityLevel1Table.Add("100", "本部");
            //this.AuthorityLevel1Table.Add("80", "店長");
            //this.AuthorityLevel1Table.Add("70", "店頭販売員(正社員)");
            //this.AuthorityLevel1Table.Add("60", "店頭販売員(アルバイト)");
            //this.AuthorityLevel1Table.Add("40", "バックヤード担当者");
            //this.AuthorityLevel1Table.Add("20", "事務(正社員)");
            //this.AuthorityLevel1Table.Add("10", "事務(アルバイト)");
            //this.AuthorityLevel1Table.Add("0", "");

            //// 権限レベル２の設定
            //this.AuthorityLevel2Table.Clear();
            //this.AuthorityLevel2Table.Add("50", "正社員");
            //this.AuthorityLevel2Table.Add("10", "アルバイト");
            //this.AuthorityLevel2Table.Add("0", "");

            using (AuthorityLevelLcDBAgent authorityLevelDB = new AuthorityLevelLcDBAgent())
            {
                // 権限レベル１の設定
                this.AuthorityLevel1Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow jobTypeRow in authorityLevelDB.JobTypeTbl)
                {
                    this.AuthorityLevel1Table.Add(jobTypeRow.AuthorityLevelCd.ToString(), jobTypeRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel1Table.ContainsKey(NULL_JOBTYPE_CODE.ToString()))
                {
                    this.AuthorityLevel1Table.Add(NULL_JOBTYPE_CODE.ToString(), NULL_JOBTYPE_NAME);
                }

                // 権限レベル２の設定
                this.AuthorityLevel2Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow employmentFormRow in authorityLevelDB.EmploymentFormTbl)
                {
                    this.AuthorityLevel2Table.Add(employmentFormRow.AuthorityLevelCd.ToString(), employmentFormRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel2Table.ContainsKey(NULL_EMPLOYMENTFORM_CODE.ToString()))
                {
                    this.AuthorityLevel2Table.Add(NULL_EMPLOYMENTFORM_CODE.ToString(), NULL_EMPLOYMENTFORM_NAME);
                }
            }
            // 2007.09.04 削除および追加 <<<<<<<<<<

            // ADD 2008/10/10 不具合対応[6442] ---------->>>>>
            // 年だけの区分リスト
            _yearOnlyList = new List<emDateFormat>();
            _yearOnlyList.AddRange(new emDateFormat[] { emDateFormat.df2Y, emDateFormat.df4Y, emDateFormat.dfG2Y });
            // 年月だけの区分リスト
            _monthOnlyList = new List<emDateFormat>();
            _monthOnlyList.AddRange(new emDateFormat[] { emDateFormat.df2M, emDateFormat.df2Y2M, emDateFormat.df4Y2M, emDateFormat.dfG2Y2M });
            // ADD 2008/10/10 不具合対応[6442] ----------<<<<<
		}
		# endregion

		# region ※Dispose
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

		#region ※Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("部門ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
			Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFTOK09380UA));
			this.GeneralTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.CustLedgerBootCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.SalSlipInpBootCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.MailAddress2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.MailAddress1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.UOESnmDiv_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.UOESnmDivTitle_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EmployAnalysCode6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
			this.BelongSubSectionGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
			this.BelongSubSectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.BelongSubSectionTitle_Label = new Infragistics.Win.Misc.UltraLabel();
			this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
			this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.EmploymentForm_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.EmploymentForm_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.JobType_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.JobType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.Birthday_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.PortableTelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.CompanyTelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
			this.BelongSelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.RetirementDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.RetirementDtTm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EnterCompanyDtTm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EnterCompanyDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.Sex_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.Kana_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ShortName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.Name_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Kana_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.ShortName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Birthday_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Sex_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Name_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EmployeeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.PortableTelNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.CompanyTelNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.SecurityTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.FeliCaMngDelete_uButton = new Infragistics.Win.Misc.UltraButton();
			this.FeliCaMngGuide_uButton = new Infragistics.Win.Misc.UltraButton();
			this.FeliCaInfo_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.FeliCaInfo_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.UserAdminName_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.UserAdminFlag_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.LoginPasswordAgain_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginPasswordAgain_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.LoginPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginPassword_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.LoginId_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.DetailsTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.Bind_DataSet = new System.Data.DataSet();
			this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
			this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
			this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
			this.MainTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
			this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
			this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
			this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
			this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
			this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.GeneralTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustLedgerBootCnt_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SalSlipInpBootCnt_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress2_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress1_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UOESnmDiv_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode6_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode5_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode4_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode3_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode2_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode1_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BelongSubSectionName_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmploymentForm_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.JobType_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PortableTelNo_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Sex_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Kana_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ShortName_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
			this.SecurityTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LoginPasswordAgain_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginPassword_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginId_tEdit)).BeginInit();
			this.DetailsTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).BeginInit();
			this.MainTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// GeneralTabPageControl
			// 
			this.GeneralTabPageControl.Controls.Add(this.CustLedgerBootCnt_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.SalSlipInpBootCnt_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel12);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel13);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel3);
			this.GeneralTabPageControl.Controls.Add(this.MailAddress2_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.MailAddress1_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel1);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel2);
			this.GeneralTabPageControl.Controls.Add(this.UOESnmDiv_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.UOESnmDivTitle_Label);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode6_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode5_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode4_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode3_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode2_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode1_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel9);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel10);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel11);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel8);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel7);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel6);
			this.GeneralTabPageControl.Controls.Add(this.tNedit_SubSectionCode);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionGuide_ultraButton);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionName_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionTitle_Label);
			this.GeneralTabPageControl.Controls.Add(this.SectionGuide_Button);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_SectionName);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_SectionCode);
			this.GeneralTabPageControl.Controls.Add(this.EmploymentForm_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.EmploymentForm_ultraLabel);
			this.GeneralTabPageControl.Controls.Add(this.JobType_ultraLabel);
			this.GeneralTabPageControl.Controls.Add(this.JobType_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.Birthday_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.PortableTelNo_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.CompanyTelNo_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel17);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel15);
			this.GeneralTabPageControl.Controls.Add(this.BelongSelectionCode_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.RetirementDate_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.RetirementDtTm_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EnterCompanyDtTm_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EnterCompanyDate_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.Sex_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.Kana_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ShortName_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.Name_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_EmployeeCode);
			this.GeneralTabPageControl.Controls.Add(this.Guid_Label);
			this.GeneralTabPageControl.Controls.Add(this.Kana_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.ShortName_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Birthday_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Sex_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Name_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EmployeeCode_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.PortableTelNo_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.CompanyTelNo_Title_Label);
			this.GeneralTabPageControl.Location = new System.Drawing.Point(1, 21);
			this.GeneralTabPageControl.Name = "GeneralTabPageControl";
			this.GeneralTabPageControl.Size = new System.Drawing.Size(778, 553);
			// 
			// CustLedgerBootCnt_tNedit
			// 
			appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustLedgerBootCnt_tNedit.ActiveAppearance = appearance62;
			appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance63.ForeColorDisabled = System.Drawing.Color.Black;
			appearance63.TextHAlignAsString = "Right";
			this.CustLedgerBootCnt_tNedit.Appearance = appearance63;
			this.CustLedgerBootCnt_tNedit.AutoSelect = true;
			this.CustLedgerBootCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.CustLedgerBootCnt_tNedit.DataText = "";
			this.CustLedgerBootCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CustLedgerBootCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.CustLedgerBootCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.CustLedgerBootCnt_tNedit.Location = new System.Drawing.Point(491, 515);
			this.CustLedgerBootCnt_tNedit.MaxLength = 1;
			this.CustLedgerBootCnt_tNedit.Name = "CustLedgerBootCnt_tNedit";
			this.CustLedgerBootCnt_tNedit.NullText = "0";
			this.CustLedgerBootCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.CustLedgerBootCnt_tNedit.Size = new System.Drawing.Size(51, 24);
			this.CustLedgerBootCnt_tNedit.TabIndex = 149;
			// 
			// SalSlipInpBootCnt_tNedit
			// 
			appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SalSlipInpBootCnt_tNedit.ActiveAppearance = appearance68;
			appearance69.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance69.ForeColorDisabled = System.Drawing.Color.Black;
			appearance69.TextHAlignAsString = "Right";
			this.SalSlipInpBootCnt_tNedit.Appearance = appearance69;
			this.SalSlipInpBootCnt_tNedit.AutoSelect = true;
			this.SalSlipInpBootCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.SalSlipInpBootCnt_tNedit.DataText = "";
			this.SalSlipInpBootCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.SalSlipInpBootCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.SalSlipInpBootCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.SalSlipInpBootCnt_tNedit.Location = new System.Drawing.Point(206, 515);
			this.SalSlipInpBootCnt_tNedit.MaxLength = 1;
			this.SalSlipInpBootCnt_tNedit.Name = "SalSlipInpBootCnt_tNedit";
			this.SalSlipInpBootCnt_tNedit.NullText = "0";
			this.SalSlipInpBootCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.SalSlipInpBootCnt_tNedit.Size = new System.Drawing.Size(51, 24);
			this.SalSlipInpBootCnt_tNedit.TabIndex = 148;
			// 
			// ultraLabel12
			// 
			appearance97.TextVAlignAsString = "Middle";
			this.ultraLabel12.Appearance = appearance97;
			this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel12.Location = new System.Drawing.Point(305, 519);
			this.ultraLabel12.Name = "ultraLabel12";
			this.ultraLabel12.Size = new System.Drawing.Size(180, 17);
			this.ultraLabel12.TabIndex = 151;
			this.ultraLabel12.Text = "得意先電子元帳起動枚数";
			// 
			// ultraLabel13
			// 
			appearance100.TextVAlignAsString = "Middle";
			this.ultraLabel13.Appearance = appearance100;
			this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel13.Location = new System.Drawing.Point(20, 519);
			this.ultraLabel13.Name = "ultraLabel13";
			this.ultraLabel13.Size = new System.Drawing.Size(180, 17);
			this.ultraLabel13.TabIndex = 150;
			this.ultraLabel13.Text = "売上伝票入力起動枚数";
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel3.Location = new System.Drawing.Point(20, 503);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel3.TabIndex = 147;
			// 
			// MailAddress2_tEdit
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MailAddress2_tEdit.ActiveAppearance = appearance2;
			appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance3.ForeColorDisabled = System.Drawing.Color.Black;
			this.MailAddress2_tEdit.Appearance = appearance3;
			this.MailAddress2_tEdit.AutoSelect = true;
			this.MailAddress2_tEdit.DataText = "";
			this.MailAddress2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MailAddress2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.MailAddress2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MailAddress2_tEdit.Location = new System.Drawing.Point(145, 220);
			this.MailAddress2_tEdit.MaxLength = 64;
			this.MailAddress2_tEdit.Name = "MailAddress2_tEdit";
			this.MailAddress2_tEdit.Size = new System.Drawing.Size(252, 24);
			this.MailAddress2_tEdit.TabIndex = 7;
			// 
			// MailAddress1_tEdit
			// 
			appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MailAddress1_tEdit.ActiveAppearance = appearance85;
			appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance86.ForeColorDisabled = System.Drawing.Color.Black;
			this.MailAddress1_tEdit.Appearance = appearance86;
			this.MailAddress1_tEdit.AutoSelect = true;
			this.MailAddress1_tEdit.DataText = "";
			this.MailAddress1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MailAddress1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.MailAddress1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MailAddress1_tEdit.Location = new System.Drawing.Point(145, 190);
			this.MailAddress1_tEdit.MaxLength = 64;
			this.MailAddress1_tEdit.Name = "MailAddress1_tEdit";
			this.MailAddress1_tEdit.Size = new System.Drawing.Size(252, 24);
			this.MailAddress1_tEdit.TabIndex = 6;
			// 
			// ultraLabel1
			// 
			appearance141.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance141;
			this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel1.Location = new System.Drawing.Point(20, 220);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(120, 24);
			this.ultraLabel1.TabIndex = 146;
			this.ultraLabel1.Text = "　　　　／携帯";
			// 
			// ultraLabel2
			// 
			appearance142.TextVAlignAsString = "Middle";
			this.ultraLabel2.Appearance = appearance142;
			this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel2.Location = new System.Drawing.Point(20, 190);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(120, 24);
			this.ultraLabel2.TabIndex = 145;
			this.ultraLabel2.Text = "メール　／会社";
			// 
			// UOESnmDiv_tEdit
			// 
			appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UOESnmDiv_tEdit.ActiveAppearance = appearance83;
			appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance84.ForeColorDisabled = System.Drawing.Color.Black;
			this.UOESnmDiv_tEdit.Appearance = appearance84;
			this.UOESnmDiv_tEdit.AutoSelect = true;
			this.UOESnmDiv_tEdit.DataText = "";
			this.UOESnmDiv_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.UOESnmDiv_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
			this.UOESnmDiv_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.UOESnmDiv_tEdit.Location = new System.Drawing.Point(145, 317);
			this.UOESnmDiv_tEdit.MaxLength = 1;
			this.UOESnmDiv_tEdit.Name = "UOESnmDiv_tEdit";
			this.UOESnmDiv_tEdit.Size = new System.Drawing.Size(20, 24);
			this.UOESnmDiv_tEdit.TabIndex = 12;
			// 
			// UOESnmDivTitle_Label
			// 
			appearance104.TextVAlignAsString = "Middle";
			this.UOESnmDivTitle_Label.Appearance = appearance104;
			this.UOESnmDivTitle_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.UOESnmDivTitle_Label.Location = new System.Drawing.Point(20, 317);
			this.UOESnmDivTitle_Label.Name = "UOESnmDivTitle_Label";
			this.UOESnmDivTitle_Label.Size = new System.Drawing.Size(120, 24);
			this.UOESnmDivTitle_Label.TabIndex = 142;
			this.UOESnmDivTitle_Label.Text = "UOE略称区分";
			// 
			// EmployAnalysCode6_tNedit
			// 
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode6_tNedit.ActiveAppearance = appearance12;
			appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance13.ForeColorDisabled = System.Drawing.Color.Black;
			appearance13.TextHAlignAsString = "Right";
			this.EmployAnalysCode6_tNedit.Appearance = appearance13;
			this.EmployAnalysCode6_tNedit.AutoSelect = true;
			this.EmployAnalysCode6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode6_tNedit.DataText = "";
			this.EmployAnalysCode6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode6_tNedit.Location = new System.Drawing.Point(491, 470);
			this.EmployAnalysCode6_tNedit.MaxLength = 3;
			this.EmployAnalysCode6_tNedit.Name = "EmployAnalysCode6_tNedit";
			this.EmployAnalysCode6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode6_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode6_tNedit.TabIndex = 24;
			// 
			// EmployAnalysCode5_tNedit
			// 
			appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode5_tNedit.ActiveAppearance = appearance64;
			appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance65.ForeColorDisabled = System.Drawing.Color.Black;
			appearance65.TextHAlignAsString = "Right";
			this.EmployAnalysCode5_tNedit.Appearance = appearance65;
			this.EmployAnalysCode5_tNedit.AutoSelect = true;
			this.EmployAnalysCode5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode5_tNedit.DataText = "";
			this.EmployAnalysCode5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode5_tNedit.Location = new System.Drawing.Point(491, 440);
			this.EmployAnalysCode5_tNedit.MaxLength = 3;
			this.EmployAnalysCode5_tNedit.Name = "EmployAnalysCode5_tNedit";
			this.EmployAnalysCode5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode5_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode5_tNedit.TabIndex = 23;
			// 
			// EmployAnalysCode4_tNedit
			// 
			appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode4_tNedit.ActiveAppearance = appearance66;
			appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance67.ForeColorDisabled = System.Drawing.Color.Black;
			appearance67.TextHAlignAsString = "Right";
			this.EmployAnalysCode4_tNedit.Appearance = appearance67;
			this.EmployAnalysCode4_tNedit.AutoSelect = true;
			this.EmployAnalysCode4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode4_tNedit.DataText = "";
			this.EmployAnalysCode4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode4_tNedit.Location = new System.Drawing.Point(491, 410);
			this.EmployAnalysCode4_tNedit.MaxLength = 3;
			this.EmployAnalysCode4_tNedit.Name = "EmployAnalysCode4_tNedit";
			this.EmployAnalysCode4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode4_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode4_tNedit.TabIndex = 22;
			// 
			// EmployAnalysCode3_tNedit
			// 
			appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode3_tNedit.ActiveAppearance = appearance14;
			appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance15.ForeColorDisabled = System.Drawing.Color.Black;
			appearance15.TextHAlignAsString = "Right";
			this.EmployAnalysCode3_tNedit.Appearance = appearance15;
			this.EmployAnalysCode3_tNedit.AutoSelect = true;
			this.EmployAnalysCode3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode3_tNedit.DataText = "";
			this.EmployAnalysCode3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode3_tNedit.Location = new System.Drawing.Point(206, 470);
			this.EmployAnalysCode3_tNedit.MaxLength = 3;
			this.EmployAnalysCode3_tNedit.Name = "EmployAnalysCode3_tNedit";
			this.EmployAnalysCode3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode3_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode3_tNedit.TabIndex = 21;
			// 
			// EmployAnalysCode2_tNedit
			// 
			appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode2_tNedit.ActiveAppearance = appearance70;
			appearance71.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance71.ForeColorDisabled = System.Drawing.Color.Black;
			appearance71.TextHAlignAsString = "Right";
			this.EmployAnalysCode2_tNedit.Appearance = appearance71;
			this.EmployAnalysCode2_tNedit.AutoSelect = true;
			this.EmployAnalysCode2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode2_tNedit.DataText = "";
			this.EmployAnalysCode2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode2_tNedit.Location = new System.Drawing.Point(206, 440);
			this.EmployAnalysCode2_tNedit.MaxLength = 3;
			this.EmployAnalysCode2_tNedit.Name = "EmployAnalysCode2_tNedit";
			this.EmployAnalysCode2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode2_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode2_tNedit.TabIndex = 20;
			// 
			// EmployAnalysCode1_tNedit
			// 
			appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode1_tNedit.ActiveAppearance = appearance72;
			appearance73.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance73.ForeColorDisabled = System.Drawing.Color.Black;
			appearance73.TextHAlignAsString = "Right";
			this.EmployAnalysCode1_tNedit.Appearance = appearance73;
			this.EmployAnalysCode1_tNedit.AutoSelect = true;
			this.EmployAnalysCode1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode1_tNedit.DataText = "";
			this.EmployAnalysCode1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode1_tNedit.Location = new System.Drawing.Point(206, 410);
			this.EmployAnalysCode1_tNedit.MaxLength = 3;
			this.EmployAnalysCode1_tNedit.Name = "EmployAnalysCode1_tNedit";
			this.EmployAnalysCode1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode1_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode1_tNedit.TabIndex = 19;
			// 
			// ultraLabel9
			// 
			appearance16.TextVAlignAsString = "Middle";
			this.ultraLabel9.Appearance = appearance16;
			this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel9.Location = new System.Drawing.Point(305, 470);
			this.ultraLabel9.Name = "ultraLabel9";
			this.ultraLabel9.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel9.TabIndex = 141;
			this.ultraLabel9.Text = "従業員分析コード６";
			// 
			// ultraLabel10
			// 
			appearance98.TextVAlignAsString = "Middle";
			this.ultraLabel10.Appearance = appearance98;
			this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel10.Location = new System.Drawing.Point(305, 440);
			this.ultraLabel10.Name = "ultraLabel10";
			this.ultraLabel10.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel10.TabIndex = 139;
			this.ultraLabel10.Text = "従業員分析コード５";
			// 
			// ultraLabel11
			// 
			appearance99.TextVAlignAsString = "Middle";
			this.ultraLabel11.Appearance = appearance99;
			this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel11.Location = new System.Drawing.Point(305, 410);
			this.ultraLabel11.Name = "ultraLabel11";
			this.ultraLabel11.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel11.TabIndex = 137;
			this.ultraLabel11.Text = "従業員分析コード４";
			// 
			// ultraLabel8
			// 
			appearance17.TextVAlignAsString = "Middle";
			this.ultraLabel8.Appearance = appearance17;
			this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel8.Location = new System.Drawing.Point(20, 470);
			this.ultraLabel8.Name = "ultraLabel8";
			this.ultraLabel8.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel8.TabIndex = 135;
			this.ultraLabel8.Text = "従業員分析コード３";
			// 
			// ultraLabel7
			// 
			appearance101.TextVAlignAsString = "Middle";
			this.ultraLabel7.Appearance = appearance101;
			this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel7.Location = new System.Drawing.Point(20, 440);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel7.TabIndex = 133;
			this.ultraLabel7.Text = "従業員分析コード２";
			// 
			// ultraLabel6
			// 
			appearance102.TextVAlignAsString = "Middle";
			this.ultraLabel6.Appearance = appearance102;
			this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel6.Location = new System.Drawing.Point(20, 410);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel6.TabIndex = 131;
			this.ultraLabel6.Text = "従業員分析コード１";
			// 
			// tNedit_SubSectionCode
			// 
			appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tNedit_SubSectionCode.ActiveAppearance = appearance76;
			appearance77.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance77.ForeColorDisabled = System.Drawing.Color.Black;
			appearance77.TextHAlignAsString = "Right";
			this.tNedit_SubSectionCode.Appearance = appearance77;
			this.tNedit_SubSectionCode.AutoSelect = true;
			this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
			this.tNedit_SubSectionCode.DataText = "";
			this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tNedit_SubSectionCode.Location = new System.Drawing.Point(145, 287);
			this.tNedit_SubSectionCode.MaxLength = 2;
			this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
			this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.tNedit_SubSectionCode.Size = new System.Drawing.Size(35, 24);
			this.tNedit_SubSectionCode.TabIndex = 10;
			// 
			// BelongSubSectionGuide_ultraButton
			// 
			this.BelongSubSectionGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSubSectionGuide_ultraButton.Location = new System.Drawing.Point(528, 287);
			this.BelongSubSectionGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
			this.BelongSubSectionGuide_ultraButton.Name = "BelongSubSectionGuide_ultraButton";
			this.BelongSubSectionGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
			this.BelongSubSectionGuide_ultraButton.TabIndex = 11;
			ultraToolTipInfo1.ToolTipText = "部門ガイド";
			this.ultraToolTipManager1.SetUltraToolTip(this.BelongSubSectionGuide_ultraButton, ultraToolTipInfo1);
			this.BelongSubSectionGuide_ultraButton.Click += new System.EventHandler(this.BelongSubSectionGuide_ultraButton_Click);
			// 
			// BelongSubSectionName_tEdit
			// 
			this.BelongSubSectionName_tEdit.ActiveAppearance = appearance58;
			appearance59.ForeColorDisabled = System.Drawing.Color.Black;
			this.BelongSubSectionName_tEdit.Appearance = appearance59;
			this.BelongSubSectionName_tEdit.AutoSelect = true;
			this.BelongSubSectionName_tEdit.DataText = "";
			this.BelongSubSectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.BelongSubSectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.BelongSubSectionName_tEdit.Location = new System.Drawing.Point(185, 287);
			this.BelongSubSectionName_tEdit.MaxLength = 20;
			this.BelongSubSectionName_tEdit.Name = "BelongSubSectionName_tEdit";
			this.BelongSubSectionName_tEdit.ReadOnly = true;
			this.BelongSubSectionName_tEdit.Size = new System.Drawing.Size(337, 24);
			this.BelongSubSectionName_tEdit.TabIndex = 129;
			// 
			// BelongSubSectionTitle_Label
			// 
			appearance1.TextVAlignAsString = "Middle";
			this.BelongSubSectionTitle_Label.Appearance = appearance1;
			this.BelongSubSectionTitle_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSubSectionTitle_Label.Location = new System.Drawing.Point(20, 287);
			this.BelongSubSectionTitle_Label.Name = "BelongSubSectionTitle_Label";
			this.BelongSubSectionTitle_Label.Size = new System.Drawing.Size(120, 24);
			this.BelongSubSectionTitle_Label.TabIndex = 127;
			this.BelongSubSectionTitle_Label.Text = "所属部門";
			// 
			// SectionGuide_Button
			// 
			this.SectionGuide_Button.BackColorInternal = System.Drawing.Color.Transparent;
			this.SectionGuide_Button.Location = new System.Drawing.Point(370, 256);
			this.SectionGuide_Button.Margin = new System.Windows.Forms.Padding(4);
			this.SectionGuide_Button.Name = "SectionGuide_Button";
			this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
			this.SectionGuide_Button.TabIndex = 9;
			ultraToolTipInfo2.ToolTipText = "拠点ガイド";
			this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo2);
			this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
			// 
			// tEdit_SectionName
			// 
			this.tEdit_SectionName.ActiveAppearance = appearance18;
			appearance21.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_SectionName.Appearance = appearance21;
			this.tEdit_SectionName.AutoSelect = true;
			this.tEdit_SectionName.DataText = "";
			this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.tEdit_SectionName.Location = new System.Drawing.Point(185, 256);
			this.tEdit_SectionName.MaxLength = 10;
			this.tEdit_SectionName.Name = "tEdit_SectionName";
			this.tEdit_SectionName.ReadOnly = true;
			this.tEdit_SectionName.Size = new System.Drawing.Size(179, 24);
			this.tEdit_SectionName.TabIndex = 126;
			// 
			// tEdit_SectionCode
			// 
			appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tEdit_SectionCode.ActiveAppearance = appearance22;
			this.tEdit_SectionCode.AllowDrop = true;
			appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance23.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_SectionCode.Appearance = appearance23;
			this.tEdit_SectionCode.AutoSelect = true;
			this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.tEdit_SectionCode.DataText = "";
			this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, false, true));
			this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tEdit_SectionCode.Location = new System.Drawing.Point(145, 256);
			this.tEdit_SectionCode.MaxLength = 9;
			this.tEdit_SectionCode.Name = "tEdit_SectionCode";
			this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
			this.tEdit_SectionCode.TabIndex = 8;
			// 
			// EmploymentForm_tComboEditor
			// 
			appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmploymentForm_tComboEditor.ActiveAppearance = appearance24;
			appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance28.ForeColorDisabled = System.Drawing.Color.Black;
			this.EmploymentForm_tComboEditor.Appearance = appearance28;
			this.EmploymentForm_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.EmploymentForm_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.EmploymentForm_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmploymentForm_tComboEditor.ItemAppearance = appearance29;
			this.EmploymentForm_tComboEditor.Location = new System.Drawing.Point(536, 361);
			this.EmploymentForm_tComboEditor.Name = "EmploymentForm_tComboEditor";
			this.EmploymentForm_tComboEditor.Size = new System.Drawing.Size(202, 24);
			this.EmploymentForm_tComboEditor.TabIndex = 18;
			// 
			// EmploymentForm_ultraLabel
			// 
			appearance30.TextVAlignAsString = "Middle";
			this.EmploymentForm_ultraLabel.Appearance = appearance30;
			this.EmploymentForm_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.EmploymentForm_ultraLabel.Location = new System.Drawing.Point(410, 361);
			this.EmploymentForm_ultraLabel.Name = "EmploymentForm_ultraLabel";
			this.EmploymentForm_ultraLabel.Size = new System.Drawing.Size(120, 24);
			this.EmploymentForm_ultraLabel.TabIndex = 124;
			this.EmploymentForm_ultraLabel.Text = "ロール（権限）";
			// 
			// JobType_ultraLabel
			// 
			appearance31.TextVAlignAsString = "Middle";
			this.JobType_ultraLabel.Appearance = appearance31;
			this.JobType_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.JobType_ultraLabel.Location = new System.Drawing.Point(20, 361);
			this.JobType_ultraLabel.Name = "JobType_ultraLabel";
			this.JobType_ultraLabel.Size = new System.Drawing.Size(120, 24);
			this.JobType_ultraLabel.TabIndex = 123;
			this.JobType_ultraLabel.Text = "ロール（業務）";
			// 
			// JobType_tComboEditor
			// 
			appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.JobType_tComboEditor.ActiveAppearance = appearance44;
			appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance45.ForeColorDisabled = System.Drawing.Color.Black;
			this.JobType_tComboEditor.Appearance = appearance45;
			this.JobType_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.JobType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.JobType_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.JobType_tComboEditor.ItemAppearance = appearance79;
			this.JobType_tComboEditor.Location = new System.Drawing.Point(145, 361);
			this.JobType_tComboEditor.Name = "JobType_tComboEditor";
			this.JobType_tComboEditor.Size = new System.Drawing.Size(202, 24);
			this.JobType_tComboEditor.TabIndex = 17;
			// 
			// Birthday_tDateEdit
			// 
			appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance80.TextHAlignAsString = "Right";
			appearance80.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.ActiveEditAppearance = appearance80;
			this.Birthday_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.Birthday_tDateEdit.CalendarDisp = true;
			this.Birthday_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance81.ForeColorDisabled = System.Drawing.Color.Black;
			appearance81.TextHAlignAsString = "Right";
			appearance81.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.EditAppearance = appearance81;
			this.Birthday_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.Birthday_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			appearance82.ForeColorDisabled = System.Drawing.Color.Black;
			appearance82.TextHAlignAsString = "Left";
			appearance82.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.LabelAppearance = appearance82;
			this.Birthday_tDateEdit.Location = new System.Drawing.Point(536, 160);
			this.Birthday_tDateEdit.Name = "Birthday_tDateEdit";
			this.Birthday_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.Birthday_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.Birthday_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.Birthday_tDateEdit.TabIndex = 14;
			this.Birthday_tDateEdit.TabStop = true;
			// 
			// PortableTelNo_tEdit
			// 
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PortableTelNo_tEdit.ActiveAppearance = appearance4;
			appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance5.ForeColorDisabled = System.Drawing.Color.Black;
			this.PortableTelNo_tEdit.Appearance = appearance5;
			this.PortableTelNo_tEdit.AutoSelect = true;
			this.PortableTelNo_tEdit.DataText = "";
			this.PortableTelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.PortableTelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.PortableTelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.PortableTelNo_tEdit.Location = new System.Drawing.Point(145, 160);
			this.PortableTelNo_tEdit.MaxLength = 16;
			this.PortableTelNo_tEdit.Name = "PortableTelNo_tEdit";
			this.PortableTelNo_tEdit.Size = new System.Drawing.Size(136, 24);
			this.PortableTelNo_tEdit.TabIndex = 5;
			// 
			// CompanyTelNo_tEdit
			// 
			appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CompanyTelNo_tEdit.ActiveAppearance = appearance6;
			appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance7.ForeColorDisabled = System.Drawing.Color.Black;
			this.CompanyTelNo_tEdit.Appearance = appearance7;
			this.CompanyTelNo_tEdit.AutoSelect = true;
			this.CompanyTelNo_tEdit.DataText = "";
			this.CompanyTelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CompanyTelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.CompanyTelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.CompanyTelNo_tEdit.Location = new System.Drawing.Point(145, 130);
			this.CompanyTelNo_tEdit.MaxLength = 16;
			this.CompanyTelNo_tEdit.Name = "CompanyTelNo_tEdit";
			this.CompanyTelNo_tEdit.Size = new System.Drawing.Size(136, 24);
			this.CompanyTelNo_tEdit.TabIndex = 4;
			// 
			// ultraLabel17
			// 
			this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel17.Location = new System.Drawing.Point(20, 396);
			this.ultraLabel17.Name = "ultraLabel17";
			this.ultraLabel17.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel17.TabIndex = 121;
			// 
			// ultraLabel15
			// 
			this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel15.Location = new System.Drawing.Point(20, 349);
			this.ultraLabel15.Name = "ultraLabel15";
			this.ultraLabel15.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel15.TabIndex = 119;
			// 
			// BelongSelectionCode_Title_Label
			// 
			appearance87.TextVAlignAsString = "Middle";
			this.BelongSelectionCode_Title_Label.Appearance = appearance87;
			this.BelongSelectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSelectionCode_Title_Label.Location = new System.Drawing.Point(20, 256);
			this.BelongSelectionCode_Title_Label.Name = "BelongSelectionCode_Title_Label";
			this.BelongSelectionCode_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.BelongSelectionCode_Title_Label.TabIndex = 116;
			this.BelongSelectionCode_Title_Label.Text = "所属拠点";
			// 
			// RetirementDate_tDateEdit
			// 
			appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance88.TextHAlignAsString = "Right";
			appearance88.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.ActiveEditAppearance = appearance88;
			this.RetirementDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.RetirementDate_tDateEdit.CalendarDisp = true;
			this.RetirementDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance89.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance89.ForeColorDisabled = System.Drawing.Color.Black;
			appearance89.TextHAlignAsString = "Right";
			appearance89.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.EditAppearance = appearance89;
			this.RetirementDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.RetirementDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RetirementDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance90.ForeColorDisabled = System.Drawing.Color.Black;
			appearance90.TextHAlignAsString = "Left";
			appearance90.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.LabelAppearance = appearance90;
			this.RetirementDate_tDateEdit.Location = new System.Drawing.Point(536, 220);
			this.RetirementDate_tDateEdit.Name = "RetirementDate_tDateEdit";
			this.RetirementDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.RetirementDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.RetirementDate_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.RetirementDate_tDateEdit.TabIndex = 16;
			this.RetirementDate_tDateEdit.TabStop = true;
			// 
			// RetirementDtTm_Title_Label
			// 
			this.RetirementDtTm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.RetirementDtTm_Title_Label.Location = new System.Drawing.Point(411, 220);
			this.RetirementDtTm_Title_Label.Name = "RetirementDtTm_Title_Label";
			this.RetirementDtTm_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.RetirementDtTm_Title_Label.TabIndex = 86;
			this.RetirementDtTm_Title_Label.Text = "退職日";
			// 
			// EnterCompanyDtTm_Title_Label
			// 
			appearance91.TextVAlignAsString = "Middle";
			this.EnterCompanyDtTm_Title_Label.Appearance = appearance91;
			this.EnterCompanyDtTm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.EnterCompanyDtTm_Title_Label.Location = new System.Drawing.Point(411, 190);
			this.EnterCompanyDtTm_Title_Label.Name = "EnterCompanyDtTm_Title_Label";
			this.EnterCompanyDtTm_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.EnterCompanyDtTm_Title_Label.TabIndex = 85;
			this.EnterCompanyDtTm_Title_Label.Text = "入社日";
			// 
			// EnterCompanyDate_tDateEdit
			// 
			appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance92.TextHAlignAsString = "Right";
			appearance92.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.ActiveEditAppearance = appearance92;
			this.EnterCompanyDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.EnterCompanyDate_tDateEdit.CalendarDisp = true;
			this.EnterCompanyDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance93.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance93.ForeColorDisabled = System.Drawing.Color.Black;
			appearance93.TextHAlignAsString = "Right";
			appearance93.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.EditAppearance = appearance93;
			this.EnterCompanyDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.EnterCompanyDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EnterCompanyDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance94.ForeColorDisabled = System.Drawing.Color.Black;
			appearance94.TextHAlignAsString = "Left";
			appearance94.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.LabelAppearance = appearance94;
			this.EnterCompanyDate_tDateEdit.Location = new System.Drawing.Point(536, 190);
			this.EnterCompanyDate_tDateEdit.Name = "EnterCompanyDate_tDateEdit";
			this.EnterCompanyDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.EnterCompanyDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.EnterCompanyDate_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.EnterCompanyDate_tDateEdit.TabIndex = 15;
			this.EnterCompanyDate_tDateEdit.TabStop = true;
			// 
			// Sex_tComboEditor
			// 
			appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Sex_tComboEditor.ActiveAppearance = appearance103;
			appearance125.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance125.ForeColorDisabled = System.Drawing.Color.Black;
			this.Sex_tComboEditor.Appearance = appearance125;
			this.Sex_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.Sex_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Sex_tComboEditor.ItemAppearance = appearance126;
			this.Sex_tComboEditor.Location = new System.Drawing.Point(536, 130);
			this.Sex_tComboEditor.Name = "Sex_tComboEditor";
			this.Sex_tComboEditor.Size = new System.Drawing.Size(100, 24);
			this.Sex_tComboEditor.TabIndex = 13;
			// 
			// Kana_tEdit
			// 
			appearance127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Kana_tEdit.ActiveAppearance = appearance127;
			appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance128.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance128.ForeColorDisabled = System.Drawing.Color.Black;
			this.Kana_tEdit.Appearance = appearance128;
			this.Kana_tEdit.AutoSelect = true;
			this.Kana_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.Kana_tEdit.DataText = "";
			this.Kana_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.Kana_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
			this.Kana_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.Kana_tEdit.Location = new System.Drawing.Point(145, 70);
			this.Kana_tEdit.MaxLength = 30;
			this.Kana_tEdit.Name = "Kana_tEdit";
			this.Kana_tEdit.Size = new System.Drawing.Size(252, 24);
			this.Kana_tEdit.TabIndex = 2;
			this.Kana_tEdit.ValueChanged += new System.EventHandler(this.Kana_tEdit_ValueChanged);
			// 
			// ShortName_tEdit
			// 
			appearance129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ShortName_tEdit.ActiveAppearance = appearance129;
			appearance130.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance130.ForeColorDisabled = System.Drawing.Color.Black;
			this.ShortName_tEdit.Appearance = appearance130;
			this.ShortName_tEdit.AutoSelect = true;
			this.ShortName_tEdit.DataText = "";
			this.ShortName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.ShortName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.ShortName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.ShortName_tEdit.Location = new System.Drawing.Point(145, 100);
			this.ShortName_tEdit.MaxLength = 5;
			this.ShortName_tEdit.Name = "ShortName_tEdit";
			this.ShortName_tEdit.Size = new System.Drawing.Size(97, 24);
			this.ShortName_tEdit.TabIndex = 3;
			// 
			// Name_tEdit
			// 
			appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Name_tEdit.ActiveAppearance = appearance131;
			appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance132.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance132.ForeColorDisabled = System.Drawing.Color.Black;
			this.Name_tEdit.Appearance = appearance132;
			this.Name_tEdit.AutoSelect = true;
			this.Name_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.Name_tEdit.DataText = "";
			this.Name_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.Name_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.Name_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.Name_tEdit.Location = new System.Drawing.Point(145, 40);
			this.Name_tEdit.MaxLength = 30;
			this.Name_tEdit.Name = "Name_tEdit";
			this.Name_tEdit.Size = new System.Drawing.Size(484, 24);
			this.Name_tEdit.TabIndex = 1;
			this.Name_tEdit.ValueChanged += new System.EventHandler(this.Name_tEdit_ValueChanged);
			// 
			// tEdit_EmployeeCode
			// 
			appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tEdit_EmployeeCode.ActiveAppearance = appearance133;
			appearance134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance134.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance134.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_EmployeeCode.Appearance = appearance134;
			this.tEdit_EmployeeCode.AutoSelect = true;
			this.tEdit_EmployeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.tEdit_EmployeeCode.DataText = "1234";
			this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, false, true));
			this.tEdit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tEdit_EmployeeCode.Location = new System.Drawing.Point(145, 10);
			this.tEdit_EmployeeCode.MaxLength = 9;
			this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
			this.tEdit_EmployeeCode.Size = new System.Drawing.Size(43, 24);
			this.tEdit_EmployeeCode.TabIndex = 0;
			this.tEdit_EmployeeCode.Text = "1234";
			// 
			// Guid_Label
			// 
			this.Guid_Label.Location = new System.Drawing.Point(280, 10);
			this.Guid_Label.Name = "Guid_Label";
			this.Guid_Label.Size = new System.Drawing.Size(240, 25);
			this.Guid_Label.TabIndex = 45;
			this.Guid_Label.Visible = false;
			// 
			// Kana_Title_Label
			// 
			appearance135.TextVAlignAsString = "Middle";
			this.Kana_Title_Label.Appearance = appearance135;
			this.Kana_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Kana_Title_Label.Location = new System.Drawing.Point(20, 70);
			this.Kana_Title_Label.Name = "Kana_Title_Label";
			this.Kana_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Kana_Title_Label.TabIndex = 31;
			this.Kana_Title_Label.Text = "担当者名(ｶﾅ)";
			// 
			// ShortName_Title_Label
			// 
			appearance136.TextVAlignAsString = "Middle";
			this.ShortName_Title_Label.Appearance = appearance136;
			this.ShortName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.ShortName_Title_Label.Location = new System.Drawing.Point(20, 100);
			this.ShortName_Title_Label.Name = "ShortName_Title_Label";
			this.ShortName_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.ShortName_Title_Label.TabIndex = 60;
			this.ShortName_Title_Label.Text = "担当者略称";
			// 
			// Birthday_Title_Label
			// 
			appearance137.TextVAlignAsString = "Middle";
			this.Birthday_Title_Label.Appearance = appearance137;
			this.Birthday_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Birthday_Title_Label.Location = new System.Drawing.Point(411, 160);
			this.Birthday_Title_Label.Name = "Birthday_Title_Label";
			this.Birthday_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Birthday_Title_Label.TabIndex = 14;
			this.Birthday_Title_Label.Text = "生年月日";
			// 
			// Sex_Title_Label
			// 
			appearance138.TextVAlignAsString = "Middle";
			this.Sex_Title_Label.Appearance = appearance138;
			this.Sex_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Sex_Title_Label.Location = new System.Drawing.Point(411, 130);
			this.Sex_Title_Label.Name = "Sex_Title_Label";
			this.Sex_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Sex_Title_Label.TabIndex = 12;
			this.Sex_Title_Label.Text = "性別";
			// 
			// Name_Title_Label
			// 
			appearance139.TextVAlignAsString = "Middle";
			this.Name_Title_Label.Appearance = appearance139;
			this.Name_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Name_Title_Label.Location = new System.Drawing.Point(20, 40);
			this.Name_Title_Label.Name = "Name_Title_Label";
			this.Name_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Name_Title_Label.TabIndex = 5;
			this.Name_Title_Label.Text = "担当者名";
			// 
			// EmployeeCode_Title_Label
			// 
			appearance140.TextVAlignAsString = "Middle";
			this.EmployeeCode_Title_Label.Appearance = appearance140;
			this.EmployeeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.EmployeeCode_Title_Label.Location = new System.Drawing.Point(20, 10);
			this.EmployeeCode_Title_Label.Name = "EmployeeCode_Title_Label";
			this.EmployeeCode_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.EmployeeCode_Title_Label.TabIndex = 3;
			this.EmployeeCode_Title_Label.Text = "担当者コード";
			// 
			// PortableTelNo_Title_Label
			// 
			appearance8.TextVAlignAsString = "Middle";
			this.PortableTelNo_Title_Label.Appearance = appearance8;
			this.PortableTelNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.PortableTelNo_Title_Label.Location = new System.Drawing.Point(20, 160);
			this.PortableTelNo_Title_Label.Name = "PortableTelNo_Title_Label";
			this.PortableTelNo_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.PortableTelNo_Title_Label.TabIndex = 67;
			this.PortableTelNo_Title_Label.Text = "　　　　／携帯";
			// 
			// CompanyTelNo_Title_Label
			// 
			appearance9.TextVAlignAsString = "Middle";
			this.CompanyTelNo_Title_Label.Appearance = appearance9;
			this.CompanyTelNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.CompanyTelNo_Title_Label.Location = new System.Drawing.Point(20, 130);
			this.CompanyTelNo_Title_Label.Name = "CompanyTelNo_Title_Label";
			this.CompanyTelNo_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.CompanyTelNo_Title_Label.TabIndex = 61;
			this.CompanyTelNo_Title_Label.Text = "電話番号／会社";
			// 
			// SecurityTabPageControl
			// 
			this.SecurityTabPageControl.Controls.Add(this.FeliCaMngDelete_uButton);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaMngGuide_uButton);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaInfo_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaInfo_Title_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.UserAdminName_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.UserAdminFlag_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.LoginPasswordAgain_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginPasswordAgain_Title_Label);
			this.SecurityTabPageControl.Controls.Add(this.LoginPassword_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginId_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginPassword_Title_Label);
			this.SecurityTabPageControl.Controls.Add(this.LoginId_Title_Label);
			this.SecurityTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
			this.SecurityTabPageControl.Name = "SecurityTabPageControl";
			this.SecurityTabPageControl.Size = new System.Drawing.Size(778, 553);
			// 
			// FeliCaMngDelete_uButton
			// 
			this.FeliCaMngDelete_uButton.Location = new System.Drawing.Point(433, 95);
			this.FeliCaMngDelete_uButton.Name = "FeliCaMngDelete_uButton";
			this.FeliCaMngDelete_uButton.Size = new System.Drawing.Size(83, 25);
			this.FeliCaMngDelete_uButton.TabIndex = 97;
			this.FeliCaMngDelete_uButton.Text = "クリア";
			this.FeliCaMngDelete_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.FeliCaMngDelete_uButton.Click += new System.EventHandler(this.FeliCaMngDelete_uButton_Click);
			// 
			// FeliCaMngGuide_uButton
			// 
			this.FeliCaMngGuide_uButton.Location = new System.Drawing.Point(402, 95);
			this.FeliCaMngGuide_uButton.Name = "FeliCaMngGuide_uButton";
			this.FeliCaMngGuide_uButton.Size = new System.Drawing.Size(25, 25);
			this.FeliCaMngGuide_uButton.TabIndex = 96;
			this.FeliCaMngGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.FeliCaMngGuide_uButton.Click += new System.EventHandler(this.FeliCaMngGuide_uButton_Click);
			// 
			// FeliCaInfo_uLabel
			// 
			appearance105.BackColor = System.Drawing.SystemColors.Control;
			appearance105.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			appearance105.TextVAlignAsString = "Middle";
			this.FeliCaInfo_uLabel.Appearance = appearance105;
			this.FeliCaInfo_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.FeliCaInfo_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.FeliCaInfo_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FeliCaInfo_uLabel.Location = new System.Drawing.Point(188, 96);
			this.FeliCaInfo_uLabel.Name = "FeliCaInfo_uLabel";
			this.FeliCaInfo_uLabel.Size = new System.Drawing.Size(208, 23);
			this.FeliCaInfo_uLabel.TabIndex = 95;
			// 
			// FeliCaInfo_Title_uLabel
			// 
			appearance106.TextVAlignAsString = "Middle";
			this.FeliCaInfo_Title_uLabel.Appearance = appearance106;
			this.FeliCaInfo_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.FeliCaInfo_Title_uLabel.Location = new System.Drawing.Point(15, 96);
			this.FeliCaInfo_Title_uLabel.Name = "FeliCaInfo_Title_uLabel";
			this.FeliCaInfo_Title_uLabel.Size = new System.Drawing.Size(169, 24);
			this.FeliCaInfo_Title_uLabel.TabIndex = 94;
			this.FeliCaInfo_Title_uLabel.Text = "フェリカカードID";
			// 
			// UserAdminName_uLabel
			// 
			appearance11.BackColor = System.Drawing.SystemColors.Control;
			appearance11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			appearance11.TextVAlignAsString = "Middle";
			this.UserAdminName_uLabel.Appearance = appearance11;
			this.UserAdminName_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.UserAdminName_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.UserAdminName_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.UserAdminName_uLabel.Location = new System.Drawing.Point(188, 127);
			this.UserAdminName_uLabel.Name = "UserAdminName_uLabel";
			this.UserAdminName_uLabel.Size = new System.Drawing.Size(208, 23);
			this.UserAdminName_uLabel.TabIndex = 93;
			// 
			// UserAdminFlag_uLabel
			// 
			appearance10.TextVAlignAsString = "Middle";
			this.UserAdminFlag_uLabel.Appearance = appearance10;
			this.UserAdminFlag_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.UserAdminFlag_uLabel.Location = new System.Drawing.Point(15, 127);
			this.UserAdminFlag_uLabel.Name = "UserAdminFlag_uLabel";
			this.UserAdminFlag_uLabel.Size = new System.Drawing.Size(169, 24);
			this.UserAdminFlag_uLabel.TabIndex = 92;
			this.UserAdminFlag_uLabel.Text = "ユーザー管理者フラグ";
			// 
			// LoginPasswordAgain_tEdit
			// 
			appearance107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginPasswordAgain_tEdit.ActiveAppearance = appearance107;
			appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance108.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance108.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginPasswordAgain_tEdit.Appearance = appearance108;
			this.LoginPasswordAgain_tEdit.AutoSelect = true;
			this.LoginPasswordAgain_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginPasswordAgain_tEdit.DataText = "";
			this.LoginPasswordAgain_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginPasswordAgain_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginPasswordAgain_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginPasswordAgain_tEdit.Location = new System.Drawing.Point(188, 65);
			this.LoginPasswordAgain_tEdit.MaxLength = 24;
			this.LoginPasswordAgain_tEdit.Name = "LoginPasswordAgain_tEdit";
			this.LoginPasswordAgain_tEdit.PasswordChar = '*';
			this.LoginPasswordAgain_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginPasswordAgain_tEdit.TabIndex = 2;
			// 
			// LoginPasswordAgain_Title_Label
			// 
			appearance109.TextVAlignAsString = "Middle";
			this.LoginPasswordAgain_Title_Label.Appearance = appearance109;
			this.LoginPasswordAgain_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginPasswordAgain_Title_Label.Location = new System.Drawing.Point(15, 65);
			this.LoginPasswordAgain_Title_Label.Name = "LoginPasswordAgain_Title_Label";
			this.LoginPasswordAgain_Title_Label.Size = new System.Drawing.Size(145, 24);
			this.LoginPasswordAgain_Title_Label.TabIndex = 91;
			this.LoginPasswordAgain_Title_Label.Text = "パスワード確認";
			// 
			// LoginPassword_tEdit
			// 
			appearance110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginPassword_tEdit.ActiveAppearance = appearance110;
			appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance111.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance111.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginPassword_tEdit.Appearance = appearance111;
			this.LoginPassword_tEdit.AutoSelect = true;
			this.LoginPassword_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginPassword_tEdit.DataText = "";
			this.LoginPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginPassword_tEdit.Location = new System.Drawing.Point(188, 40);
			this.LoginPassword_tEdit.MaxLength = 24;
			this.LoginPassword_tEdit.Name = "LoginPassword_tEdit";
			this.LoginPassword_tEdit.PasswordChar = '*';
			this.LoginPassword_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginPassword_tEdit.TabIndex = 1;
			this.LoginPassword_tEdit.Leave += new System.EventHandler(this.LoginPassword_tEdit_Leave);
			// 
			// LoginId_tEdit
			// 
			appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginId_tEdit.ActiveAppearance = appearance112;
			appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance113.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance113.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginId_tEdit.Appearance = appearance113;
			this.LoginId_tEdit.AutoSelect = true;
			this.LoginId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginId_tEdit.DataText = "";
			this.LoginId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginId_tEdit.Location = new System.Drawing.Point(188, 10);
			this.LoginId_tEdit.MaxLength = 24;
			this.LoginId_tEdit.Name = "LoginId_tEdit";
			this.LoginId_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginId_tEdit.TabIndex = 0;
			// 
			// LoginPassword_Title_Label
			// 
			appearance114.TextVAlignAsString = "Middle";
			this.LoginPassword_Title_Label.Appearance = appearance114;
			this.LoginPassword_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginPassword_Title_Label.Location = new System.Drawing.Point(15, 40);
			this.LoginPassword_Title_Label.Name = "LoginPassword_Title_Label";
			this.LoginPassword_Title_Label.Size = new System.Drawing.Size(150, 24);
			this.LoginPassword_Title_Label.TabIndex = 87;
			this.LoginPassword_Title_Label.Text = "ログインパスワード";
			// 
			// LoginId_Title_Label
			// 
			appearance115.TextVAlignAsString = "Middle";
			this.LoginId_Title_Label.Appearance = appearance115;
			this.LoginId_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginId_Title_Label.Location = new System.Drawing.Point(15, 10);
			this.LoginId_Title_Label.Name = "LoginId_Title_Label";
			this.LoginId_Title_Label.Size = new System.Drawing.Size(160, 24);
			this.LoginId_Title_Label.TabIndex = 85;
			this.LoginId_Title_Label.Text = "ログインID";
			// 
			// DetailsTabPageControl
			// 
			this.DetailsTabPageControl.Controls.Add(this.ultraLabel5);
			this.DetailsTabPageControl.Controls.Add(this.ultraLabel4);
			this.DetailsTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
			this.DetailsTabPageControl.Name = "DetailsTabPageControl";
			this.DetailsTabPageControl.Size = new System.Drawing.Size(778, 427);
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel5.Location = new System.Drawing.Point(17, 171);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel5.TabIndex = 41;
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel4.Location = new System.Drawing.Point(17, 44);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel4.TabIndex = 40;
			// 
			// Ok_Button
			// 
			this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Ok_Button.Location = new System.Drawing.Point(534, 589);
			this.Ok_Button.Name = "Ok_Button";
			this.Ok_Button.Size = new System.Drawing.Size(125, 34);
			this.Ok_Button.TabIndex = 18;
			this.Ok_Button.Text = "保存(&S)";
			this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 630);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(792, 23);
			this.ultraStatusBar1.TabIndex = 46;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// Bind_DataSet
			// 
			this.Bind_DataSet.DataSetName = "NewDataSet";
			this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
			// 
			// Mode_Label
			// 
			appearance116.ForeColor = System.Drawing.Color.White;
			appearance116.TextHAlignAsString = "Center";
			appearance116.TextVAlignAsString = "Middle";
			this.Mode_Label.Appearance = appearance116;
			this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
			this.Mode_Label.Location = new System.Drawing.Point(685, 1);
			this.Mode_Label.Name = "Mode_Label";
			this.Mode_Label.Size = new System.Drawing.Size(100, 23);
			this.Mode_Label.TabIndex = 58;
			this.Mode_Label.Text = "更新モード";
			// 
			// Delete_Button
			// 
			this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Delete_Button.Location = new System.Drawing.Point(411, 589);
			this.Delete_Button.Name = "Delete_Button";
			this.Delete_Button.Size = new System.Drawing.Size(125, 34);
			this.Delete_Button.TabIndex = 17;
			this.Delete_Button.Text = "完全削除(&D)";
			this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
			// 
			// Revive_Button
			// 
			this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Revive_Button.Location = new System.Drawing.Point(535, 589);
			this.Revive_Button.Name = "Revive_Button";
			this.Revive_Button.Size = new System.Drawing.Size(125, 34);
			this.Revive_Button.TabIndex = 18;
			this.Revive_Button.Text = "復活(&R)";
			this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Cancel_Button.Location = new System.Drawing.Point(660, 589);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
			this.Cancel_Button.TabIndex = 19;
			this.Cancel_Button.Text = "閉じる(&X)";
			this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// MainTabControl
			// 
			appearance117.BackColor = System.Drawing.Color.White;
			appearance117.BackColor2 = System.Drawing.Color.LightPink;
			appearance117.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.MainTabControl.ActiveTabAppearance = appearance117;
			appearance118.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance118.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance118.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.MainTabControl.Appearance = appearance118;
			this.MainTabControl.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.MainTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
			this.MainTabControl.Controls.Add(this.GeneralTabPageControl);
			this.MainTabControl.Controls.Add(this.SecurityTabPageControl);
			this.MainTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
			this.MainTabControl.Location = new System.Drawing.Point(5, 5);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
			this.MainTabControl.Size = new System.Drawing.Size(780, 575);
			this.MainTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
			appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.MainTabControl.TabHeaderAreaAppearance = appearance60;
			this.MainTabControl.TabIndex = 0;
			this.MainTabControl.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowFixed;
			appearance119.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance119.BackColor2 = System.Drawing.Color.LightPink;
			ultraTab1.ActiveAppearance = appearance119;
			appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			appearance120.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraTab1.ClientAreaAppearance = appearance120;
			ultraTab1.FixedWidth = 60;
			ultraTab1.Key = "GeneralTab";
			ultraTab1.TabPage = this.GeneralTabPageControl;
			ultraTab1.Text = "全般";
			appearance123.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance123.BackColor2 = System.Drawing.Color.LightPink;
			ultraTab3.ActiveAppearance = appearance123;
			appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			appearance124.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraTab3.ClientAreaAppearance = appearance124;
			ultraTab3.FixedWidth = 120;
			ultraTab3.Key = "SecurityTab";
			ultraTab3.TabPage = this.SecurityTabPageControl;
			ultraTab3.Text = "セキュリティ";
			this.MainTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab3});
			this.MainTabControl.TabsPerRow = 2;
			this.MainTabControl.TabStop = false;
			this.MainTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.MainTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
			this.MainTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.MainTabControl_SelectedTabChanged);
			// 
			// ultraTabSharedControlsPage1
			// 
			this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
			this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
			this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(778, 553);
			// 
			// Initial_Timer
			// 
			this.Initial_Timer.Interval = 1;
			this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
			// 
			// tImeControl1
			// 
			this.tImeControl1.InControl = this.Name_tEdit;
			this.tImeControl1.OutControl = this.Kana_tEdit;
			this.tImeControl1.OwnerForm = this;
			this.tImeControl1.PutLength = 30;
			// 
			// uiSetControl1
			// 
			this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
			this.uiSetControl1.OwnerForm = this;
			// 
			// ultraToolTipManager1
			// 
			this.ultraToolTipManager1.ContainingControl = this;
			this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
			// 
			// SFTOK09380UA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(792, 653);
			this.Controls.Add(this.ultraStatusBar1);
			this.Controls.Add(this.Mode_Label);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.Revive_Button);
			this.Controls.Add(this.Delete_Button);
			this.Controls.Add(this.Ok_Button);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SFTOK09380UA";
			this.Text = "従業員設定";
			this.Load += new System.EventHandler(this.SFTOK09380UA_Load);
			this.VisibleChanged += new System.EventHandler(this.SFTOK09380UA_VisibleChanged);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SFTOK09380UA_Closing);
			this.GeneralTabPageControl.ResumeLayout(false);
			this.GeneralTabPageControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustLedgerBootCnt_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SalSlipInpBootCnt_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress2_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress1_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UOESnmDiv_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode6_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode5_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode4_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode3_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode2_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode1_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BelongSubSectionName_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmploymentForm_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.JobType_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PortableTelNo_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Sex_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Kana_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ShortName_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
			this.SecurityTabPageControl.ResumeLayout(false);
			this.SecurityTabPageControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LoginPasswordAgain_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginPassword_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginId_tEdit)).EndInit();
			this.DetailsTabPageControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).EndInit();
			this.MainTabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{
				this._canClose = value;
			}
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
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

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn;
			}
		}
		# endregion

		# region ▼Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = EMPLOYEE_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList employees = null;
            ArrayList employeesDtl = null;  // 2007.08.14 追加

			if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
                // 2007.08.14 修正 >>>>>>>>>>
                //status = this._employeeAcs.SearchAll(
				//			out employees,
			    //			this._enterpriseCode);
                status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            this._enterpriseCode);
                // 2007.08.14 修正 <<<<<<<<<<

				this._totalCount = employees.Count;
			}
			else
			{
                // 2007.08.14 修正 >>>>>>>>>>
                //status = this._employeeAcs.SearchAll(
				//			out employees,
				//			out this._totalCount,
				//			out this._nextData,
				//			this._enterpriseCode,
				//			readCount,
				//			this._prevEmployee);
                status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            out this._totalCount,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevEmployee,
                            this._employeeDtl);
                // 2007.08.14 修正 <<<<<<<<<<
            }

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    List<FeliCaMngWork> felicaMngLs = null;
                    if (_optFeliCaAcs)
                    {
                        if (_optFeliCaAcs)
                        {
                            _employeeAcs.SearchStaticMemory_FeliCa(out felicaMngLs);
                        }
                    }
                    // 2010/02/18 Add <<<

                    ReadSecInfoSet();

                    ArrayList employeeList = new ArrayList();

                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                    // データビュー表示制御
                    switch (LoginInfoAcquisition.Employee.UserAdminFlag)
                    {
                        // ユーザー管理者フラグ = 1,2 のデータは表示しない
                        case 0:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag != 1) && (employee.UserAdminFlag != 2))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        // ユーザー管理者フラグ = 0,1 のデータを表示する
                        case 1:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag == 0) || (employee.UserAdminFlag == 1))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        // ユーザー管理者フラグ = 1,2 のデータを表示する
                        case 2:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag == 1) || (employee.UserAdminFlag == 2))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<
                    
					// 最終の従業員オブジェクトを退避する
                    // --- CHG 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                    //this._prevEmployee = ((Employee)employees[employees.Count - 1]).Clone();
                    this._prevEmployee = ((Employee)employeeList[employeeList.Count - 1]).Clone();
                    // --- CHG 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<

					int index = 0;
                    // --- CHG 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                    //foreach (Employee employee in employees)
                    foreach (Employee employee in employeeList)
                    // --- CHG 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<
                    {
						if (this._employeeTable.ContainsKey(employee.FileHeaderGuid) == false)
						{
							EmployeeToDataSet(employee.Clone(), index);
                            // 2010/02/18 Add >>>
                            if (_optFeliCaAcs)
                            {
                                if (felicaMngLs != null)
                                {
                                    FeliCaMngWork felicaMng;
                                    felicaMng = felicaMngLs.Find(delegate(FeliCaMngWork itm)
                                    {
                                        return (itm.EmployeeCode == employee.EmployeeCode);
                                    });
                                    FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                                }

                            }
                            // 2010/02/18 Add <<<
							++index;
						}
					}

                    // 2007.08.14 追加 >>>>>>>>>>
                    this._employeeDtlData = employeesDtl;
                    // 2007.08.14 追加 <<<<<<<<<<

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(
						this,								  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
						ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
						this.Text,							  // プログラム名称
						"Search",							  // 処理名称
						TMsgDisp.OPE_GET,					  // オペレーション
						ERR_READ_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._employeeAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

					break;
				}
			}

			totalCount = this._totalCount;

			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList employees = null;
            ArrayList employeesDtl = null;  // 2007.08.14 追加

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

            // 2007.08.14 修正 >>>>>>>>>>
            //int status = this._employeeAcs.SearchAll(
			//				out employees,
			//				out dummy,
			//				out this._nextData,
			//				this._enterpriseCode,
			//				readCount,
			//				this._prevEmployee);
            int status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            out dummy,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevEmployee,
                            this._employeeDtl);
            // 2007.08.14 修正 <<<<<<<<<<

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    List<FeliCaMngWork> felicaMngLs = null;
                    if (_optFeliCaAcs)
                    {
                        _employeeAcs.SearchStaticMemory_FeliCa(out felicaMngLs);
                    }
                    // 2010/02/18 Add <<<

                    // 最終の従業員クラスを退避する
					this._prevEmployee = ((Employee)employees[employees.Count - 1]).Clone();

					int index = 0;
					foreach (Employee employee in employees)
					{
						if (this._employeeTable.ContainsKey(employee.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count;
							EmployeeToDataSet(employee.Clone(), index);
                            // 2010/02/18 Add >>>
                            if (_optFeliCaAcs)
                            {
                                if (felicaMngLs != null)
                                {
                                    FeliCaMngWork felicaMng;
                                    felicaMng = felicaMngLs.Find(delegate(FeliCaMngWork itm)
                                    {
                                        return (itm.EmployeeCode == employee.EmployeeCode);
                                    });

                                    if (felicaMng != null)
                                        FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                                }

                            }
                            // 2010/02/18 Add <<<
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
					TMsgDisp.Show(
						this,								  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
						ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
						this.Text,							  // プログラム名称
						"SearchNext",						  // 処理名称
						TMsgDisp.OPE_GET,					  // オペレーション
						ERR_READ_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._employeeAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

					break;
				}
			}

			return status;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			Employee employee = ((Employee)this._employeeTable[guid]).Clone();
            EmployeeDtl employeeDtl = null;
            if (employee != null)
            {
                employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
            }

            // 2007.08.14 修正 >>>>>>>>>>
            //int status = this._employeeAcs.LogicalDelete(ref employee);
            int status = this._employeeAcs.LogicalDelete(ref employee, ref employeeDtl);
            // 2007.08.14 修正 <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngWork felicaMng = null;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (_optFeliCaAcs)
                {
                    string idm = string.Empty;
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                    _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                    if (felicaMng != null)
                        status = _employeeAcs.LogicalDelete_FeliCa(ref felicaMng);
                }
            }
            // 2010/02/18 Add <<<

            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                        FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                    // 2010/02/18 Add <<<
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._employeeAcs);
					return status;
				}

				//// 2005.11.16 ADD UENO///////////////////////////////////////////////////////////////
				case -2:
				{
					//主作業設定で使用中
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"このレコードは主作業設定で使用されているため削除できません",
						status,
						MessageBoxButtons.OK);
					this.Hide();

					return status;
				}
				//// 2005.11.16 END UENO///////////////////////////////////////////////////////////////

				default:
				{
					TMsgDisp.Show(
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"Delete",							// 処理名称
						TMsgDisp.OPE_HIDE,					// オペレーション
						ERR_RDEL_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						this._employeeAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// データセット展開処理
			EmployeeToDataSet(employee.Clone(), this._dataIndex);
            ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 追加

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			appearanceTable.Add(SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(KANA_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(SHORTNAME_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(SEXNAME_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(BIRTHDAY_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(COMPANYTELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(PORTABLETELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //appearanceTable.Add(POSTNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            ////appearanceTable.Add(FRONTMECHANAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(INOUTSIDECOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));            
            //appearanceTable.Add(BUSINESSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            //appearanceTable.Add(GELAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(CILAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(BPLAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(BRLAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));

            // DEL 2008/10/10 不具合対応[6440] ---------->>>>>
            //appearanceTable.Add(JOBTYPE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(EMPLOYMENTFORM_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/10/10 不具合対応[6440] ----------<<<<
            // ADD 2008/10/10 不具合対応[6440] ---------->>>>>
            appearanceTable.Add(JOBTYPE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYMENTFORM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ADD 2008/10/10 不具合対応[6440] ----------<<<<<
            
			appearanceTable.Add(ENTERCOMPANYDATE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(RETIREMENTDATE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LOGINID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {   //フェリカアクセスサービスオプション導入なら
                appearanceTable.Add(FELICAIDM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(FELICAIDMSTATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(FELICAMNGKIND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            // 2010/02/18 Add <<<

			return appearanceTable;
		}

        /// <summary>
        /// 自社情報読み込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 自社情報の取得を行う。</br>
        /// <br>Programmer  : 980035 金沢 貞義</br>
        /// <br>Date        : 2008.01.16</br>
        /// </remarks>
        public void GetCompanyInf()
        {
            // 自社情報読み込み
            int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._secMngDiv = this._companyInf.SecMngDiv;
            }
        }
        # endregion

		# endregion

		#region ■Private Menbers
		private EmployeeAcs _employeeAcs;
		private Employee _prevEmployee;
		private SecInfoAcs _secInfoAcs;
        //private UserGuideAcs _userGuideAcs;     // DEL 2008/11/04 不具合対応[7289]
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _employeeTable;
		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private Employee _employeeClone;
		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection = false;
        private int _secMngDiv;                 // 2008.01.16 追加

        // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>> 
        // メニュー簡易起動オプション
        private bool _opMenuSimpleStart = false;
        // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // 権限レベル１データ
        private Hashtable AuthorityLevel1Table;
        // 権限レベル２データ
        private Hashtable AuthorityLevel2Table;

        private ArrayList _employeeDtlData;     // 2007.08.14 追加
        private EmployeeDtl _employeeDtl;       // 2007.08.14 追加
        private EmployeeDtl _employeeDtlClone;  // 2007.08.14 追加

        // 自社情報アクセスクラス
        private CompanyInfAcs _companyInfAcs;   // 2008.01.16 追加
        private CompanyInf _companyInf;         // 2008.01.16 追加

        private SecInfoSetAcs _secInfoSetAcs;
        private SubSectionAcs _subSectionAcs;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, SubSection> _subSectionDic;

        // ADD 2008/10/10 不具合対応[6442] ---------->>>>>
        /// <summary>年だけの区分リスト</summary>
        List<emDateFormat> _yearOnlyList;
        /// <summary>年月だけの区分リスト</summary>
        List<emDateFormat> _monthOnlyList;
        // ADD 2008/10/10 不具合対応[6442] ----------<<<<<

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

        // 2010/02/18 Add >>>
        private bool _optFeliCaAcs = false;
        // 2010/02/18 Add <<<
        # endregion

		# region ■Consts
		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE = "削除日";
		private const string SECTIONNAME_TITLE = "所属拠点";
		private const string CODE_TITLE = "担当者コード";
		private const string NAME_TITLE = "担当者名";
        // DEL 2008/10/09 不具合対応[6441] ↓
        //private const string KANA_TITLE = "担当者カナ";
        private const string KANA_TITLE = "担当者(ｶﾅ)"; // ADD 2008/10/09 不具合対応[6441]
		private const string SHORTNAME_TITLE = "担当者略称";
		private const string SEXNAME_TITLE = "性別";
		private const string BIRTHDAY_TITLE = "生年月日";
		private const string COMPANYTELNO_TITLE = "電話番号(会社)";
		private const string PORTABLETELNO_TITLE = "電話番号(携帯)";
        //private const string POSTNAME_TITLE = "役職";           // DEL 2008/11/04 不具合対応[7289]
        //private const string FRONTMECHANAME_TITLE = "受付・メカ";
        // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
        //private const string INOUTSIDECOMPANYNAME_TITLE = "社内・社外";
        //private const string BUSINESSNAME_TITLE = "業務";
        // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
        //private const string GELAVORRATECOST_TITLE = "レバレート原価(一般)";
        //private const string CILAVORRATECOST_TITLE = "レバレート原価(車検)";
        //private const string BRLAVORRATECOST_TITLE = "レバレート原価(鈑金)";
        //private const string BPLAVORRATECOST_TITLE = "レバレート原価(塗装)";
        // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
        //private const string JOBTYPE_TITLE = "職種";
        //private const string EMPLOYMENTFORM_TITLE = "雇用形態";
        // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
        // ADD 2008/11/04 不具合対応[7289] ---------->>>>>
        private const string JOBTYPE_TITLE = "ロール（業務）";
        private const string EMPLOYMENTFORM_TITLE = "ロール（権限）";
        // ADD 2008/11/04 不具合対応[7289] ----------<<<<<
        // 2007.09.04 追加 >>>>>>>>>>
        private const int       NULL_JOBTYPE_CODE = 0;
        private const string    NULL_JOBTYPE_NAME = "";        
        private const int       NULL_EMPLOYMENTFORM_CODE = 0;
        private const string    NULL_EMPLOYMENTFORM_NAME = "";
        // 2007.09.04 追加 <<<<<<<<<<

		private const string ENTERCOMPANYDATE_TITLE = "入社日";
		private const string RETIREMENTDATE_TITLE = "退職日";
		private const string LOGINID_TITLE = "ログインID";
		private const string GUID_TITLE = "GUID";
		private const string EMPLOYEE_TABLE = "EMPLOYEE";
		
		// Format定義
        //private const string MONEY_FORMAT = "###,###,##0円";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// コントロール名称
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";
        //private const string TAB3_NAME = "DetailsTab";  // 2007.08.14 追加
		// Message関連定義
		private const string ASSEMBLY_ID	= "SFTOK09380U";
		private const string PG_NM			= "自賠責保険会社登録修正";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
        private const string ERR_DPR_MSG2 = "このフェリカIDは既に使用されています。";   // 2010/02/18 Add
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		private const string SDC_RDEL_MSG	= "マスタから削除されています";

        // 2010/02/18 Add >>>
        private const string FELICAIDM_TITLE = "FeliCaIDm";
        private const string FELICAIDMSTATE_TITLE = "フェリカ情報";
        private const string FELICAMNGKIND_TITLE = "FeliCa管理種別";
        // 2010/02/18 Add <<<

        #endregion
    
		# region ※Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFTOK09380UA());
		}
		# endregion

		#region ■IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ■Private Methods
        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>追加</summary>
            Insert = 1,
            /// <summary>修正</summary>
            Update = 2,
            /// <summary>論理削除</summary>
            LogicalDelete = 3,
            /// <summary>完全削除</summary>
            Delete = 4,
            /// <summary>復活</summary>
            Revive = 5,
        }

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateMasterMaintenanceOperationAuthority("SFTOK09380U", this);
                }
                return _operationAuthority;
            }
        }

		/// <summary>
		/// 従業員オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 従業員クラスをデータセットに格納します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void EmployeeToDataSet(Employee employee, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].NewRow();
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count - 1;
			}

			if (employee.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][DELETE_DATE] = employee.UpdateDateTimeJpInFormal;
			}
													   
			// 所属拠点
            this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SECTIONNAME_TITLE] = GetSectionName(employee.BelongSectionCode);
			// 従業員コード
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][CODE_TITLE] = employee.EmployeeCode;
			// 名称
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][NAME_TITLE] = employee.Name;
			// カナ
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][KANA_TITLE] = employee.Kana;
			// 短縮名称
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SHORTNAME_TITLE] = employee.ShortName;
			// 性別名称
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SEXNAME_TITLE] = employee.SexName;
			// 生年月日
			if (employee.Birthday == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BIRTHDAY_TITLE] = DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BIRTHDAY_TITLE] = employee.BirthdayJpFormal;
			}
			// 電話番号（会社）
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][COMPANYTELNO_TITLE] = employee.CompanyTelNo;
			// 電話番号（携帯）
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][PORTABLETELNO_TITLE] = employee.PortableTelNo;
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
			// 役職名称
            //string wkString;
            //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
            //// ADD 2008/10/10 不具合対応[6440] ---------->>>>>
            //if (wkString.Equals("未登録"))
            //{
            //    wkString = "";
            //}
            //// ADD 2008/10/10 不具合対応[6440] ----------<<<<<            
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][POSTNAME_TITLE] = wkString;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
			// 受付・メカ名称
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][FRONTMECHANAME_TITLE] = employee.FrontMechaName;
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //// 社内・社外名称
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][INOUTSIDECOMPANYNAME_TITLE] = employee.InOutsideCompanyName;
            
            //// 業務名称
            //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
            //// ADD 2008/10/10 不具合対応[6440] ---------->>>>>
            //if (wkString.Equals("未登録"))
            //{
            //    wkString = "";
            //}
            //// ADD 2008/10/10 不具合対応[6440] ----------<<<<<
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BUSINESSNAME_TITLE] = wkString;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
			// レバレート原価（一般）
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][GELAVORRATECOST_TITLE] = employee.LvrRtCstGeneral;
			// レバレート原価（車検）
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][CILAVORRATECOST_TITLE] = employee.LvrRtCstCarInspect;
			// レバレート原価（鈑金）
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BRLAVORRATECOST_TITLE] = employee.LvrRtCstBodyRepair;
			// レバレート原価（塗装）
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BPLAVORRATECOST_TITLE] = employee.LvrRtCstBodyPaint;

            // 2007.09.04 修正 >>>>>>>>>>
            // 職種
            if (this.AuthorityLevel1Table.ContainsKey(employee.AuthorityLevel1.ToString()))
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = this.AuthorityLevel1Table[employee.AuthorityLevel1.ToString()].ToString();
                //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = employee.AuthorityLevel1;
            }
            else
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = this.AuthorityLevel1Table[NULL_JOBTYPE_CODE.ToString()].ToString();
            }

            // 雇用形態
            if (this.AuthorityLevel2Table.ContainsKey(employee.AuthorityLevel2.ToString()))
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = this.AuthorityLevel2Table[employee.AuthorityLevel2.ToString()].ToString();
                //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = employee.AuthorityLevel2;
            }
            else
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = this.AuthorityLevel2Table[NULL_EMPLOYMENTFORM_CODE.ToString()].ToString();
            }
            // 2007.09.04 修正 <<<<<<<<<<

			// 入社日
			if (employee.EnterCompanyDate == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][ENTERCOMPANYDATE_TITLE]= DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][ENTERCOMPANYDATE_TITLE]= employee.EnterCompanyDateJpFormal;
			}
			// 退社日
			if (employee.RetirementDate == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][RETIREMENTDATE_TITLE]  = DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][RETIREMENTDATE_TITLE]  = employee.RetirementDateJpFormal;
			}
			// ログインID
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][LOGINID_TITLE]	= employee.LoginId;
			// GUID
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][GUID_TITLE] = employee.FileHeaderGuid;

			if (this._employeeTable.ContainsKey(employee.FileHeaderGuid))
			{
				this._employeeTable.Remove(employee.FileHeaderGuid);
			}
			this._employeeTable.Add(employee.FileHeaderGuid, employee);
        }

        // 2010/02/18 Add >>>
        /// <summary>
        /// FeliCa管理オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="felicaMng">フェリカ管理ワーク</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <remarks>
        /// <br>Note       : フェリカ管理クラスをデータセットに格納します。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngToDataSet(FeliCaMngWork felicaMng, string employeeCode)
        {
            // フェリカアクセスサービスオプション未導入なら終了
            if (!_optFeliCaAcs) return;

            // から行を取得する
            DataRow[] dataRows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(CODE_TITLE + " = '" + employeeCode + "'");
            if ((dataRows == null) || (dataRows.Length == 0)) return;
            DataRow dataRow = dataRows[0];

            if (felicaMng == null)
            {
                dataRow[FELICAIDMSTATE_TITLE] = string.Empty;
                dataRow[FELICAIDM_TITLE] = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
            {
                dataRow[FELICAIDMSTATE_TITLE] = string.Empty;
                dataRow[FELICAIDM_TITLE] = string.Empty;
            }
            else
            {
                dataRow[FELICAIDMSTATE_TITLE] = "登録済";
                dataRow[FELICAIDM_TITLE] = felicaMng.FeliCaIDm;
            }
            dataRow[FELICAMNGKIND_TITLE] = felicaMng.FeliCaMngKind;
        }
        // 2010/02/18 Add <<<

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable employeeTable = new DataTable(EMPLOYEE_TABLE);

			// Addを行う順番が、列の表示順位となります。
			employeeTable.Columns.Add(DELETE_DATE,				  typeof(string));
			employeeTable.Columns.Add(SECTIONNAME_TITLE,		  typeof(string));
			employeeTable.Columns.Add(CODE_TITLE,				  typeof(string));
			employeeTable.Columns.Add(NAME_TITLE,				  typeof(string));
			employeeTable.Columns.Add(KANA_TITLE,				  typeof(string));
			employeeTable.Columns.Add(SHORTNAME_TITLE,			  typeof(string));
			employeeTable.Columns.Add(SEXNAME_TITLE,			  typeof(string));
			employeeTable.Columns.Add(BIRTHDAY_TITLE,			  typeof(string));
			employeeTable.Columns.Add(COMPANYTELNO_TITLE,		  typeof(string));
			employeeTable.Columns.Add(PORTABLETELNO_TITLE,		  typeof(string));
            //employeeTable.Columns.Add(FRONTMECHANAME_TITLE,		  typeof(string));
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //employeeTable.Columns.Add(INOUTSIDECOMPANYNAME_TITLE, typeof(string));            
            //employeeTable.Columns.Add(POSTNAME_TITLE,			  typeof(string));
            //employeeTable.Columns.Add(BUSINESSNAME_TITLE,		  typeof(string));
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            //employeeTable.Columns.Add(GELAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(CILAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(BPLAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(BRLAVORRATECOST_TITLE,	  typeof(long));

            employeeTable.Columns.Add(JOBTYPE_TITLE,              typeof(string));
            employeeTable.Columns.Add(EMPLOYMENTFORM_TITLE,       typeof(string));

			employeeTable.Columns.Add(ENTERCOMPANYDATE_TITLE,     typeof(string));
			employeeTable.Columns.Add(RETIREMENTDATE_TITLE,		  typeof(string));
			employeeTable.Columns.Add(LOGINID_TITLE,			  typeof(string));
			employeeTable.Columns.Add(GUID_TITLE,				  typeof(Guid));

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                employeeTable.Columns.Add(FELICAIDMSTATE_TITLE,   typeof(string));
                employeeTable.Columns[FELICAIDMSTATE_TITLE].DefaultValue = string.Empty;
                employeeTable.Columns.Add(FELICAIDM_TITLE,        typeof(string));
                employeeTable.Columns.Add(FELICAMNGKIND_TITLE,    typeof(Int32));
            }
            // 2010/02/18 Add <<<

			this.Bind_DataSet.Tables.Add(employeeTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.Sex_tComboEditor.Items.Clear();
			this.Sex_tComboEditor.Items.Add(0,"男");									
			this.Sex_tComboEditor.Items.Add(1,"女");									
			this.Sex_tComboEditor.Items.Add(2,"不明");

            //this.PostCode_tComboEditor.Items.Clear();       // DEL 2008/11/04 不具合対応[7289]

            //this.FrontMechaCode_tComboEditor.Items.Clear();
            //this.FrontMechaCode_tComboEditor.Items.Add(0,"受付");						
            //this.FrontMechaCode_tComboEditor.Items.Add(1,"メカ");						
            //this.FrontMechaCode_tComboEditor.Items.Add(2,"営業");						

            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Items.Clear();
            //this.InOutsideCompanyCode_tComboEditor.Items.Add(0,"社内");
            //this.InOutsideCompanyCode_tComboEditor.Items.Add(1,"社外");

            //this.BusinessCode_tComboEditor.Items.Clear();
			// DEL 2008/11/04 不具合対応[7289] ----------<<<<<

			#region // -- Del 2012.05.29 30182 R.Tachiya --
			//// 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			////this.Ok_Button.Location = new System.Drawing.Point(535, 494);
			////this.Cancel_Button.Location = new System.Drawing.Point(660, 494);
			////this.Delete_Button.Location = new System.Drawing.Point(410, 494);
			////this.Revive_Button.Location = new System.Drawing.Point(535, 494);
			//this.Ok_Button.Location = new System.Drawing.Point(535, 562);
			//this.Cancel_Button.Location = new System.Drawing.Point(660, 562);
			//this.Delete_Button.Location = new System.Drawing.Point(410, 562);
			//this.Revive_Button.Location = new System.Drawing.Point(535, 562);
			//// 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			#endregion

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.Ok_Button.Location = new System.Drawing.Point(535, 589);
			this.Cancel_Button.Location = new System.Drawing.Point(660, 589);
			this.Delete_Button.Location = new System.Drawing.Point(410, 589);
			this.Revive_Button.Location = new System.Drawing.Point(535, 589);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			// 権限レベル１(職種)コンボエディター
            this.JobType_tComboEditor.Items.Clear();
            foreach (DictionaryEntry de in AuthorityLevel1Table)
            {
                if (Int32.Parse(de.Key.ToString()) != 0)
                {
                    this.JobType_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //this.JobType_tComboEditor.Items.Add(80, "店長");
            //this.JobType_tComboEditor.Items.Add(70, "店頭販売員(正社員)");
            //this.JobType_tComboEditor.Items.Add(60, "店頭販売員(アルバイト)");
            //this.JobType_tComboEditor.Items.Add(40, "バックヤード担当者");
            //this.JobType_tComboEditor.Items.Add(20, "事務(正社員)");
            //this.JobType_tComboEditor.Items.Add(10, "事務(アルバイト)");


            // 権限レベル２(雇用形態)コンボエディター
            this.EmploymentForm_tComboEditor.Items.Clear();
            foreach (DictionaryEntry de in AuthorityLevel2Table)
            {
                if (Int32.Parse(de.Key.ToString()) != 0)
                {
                    this.EmploymentForm_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            
            //this.EmploymentForm_tComboEditor.Items.Add(50, "正社員");
            //this.EmploymentForm_tComboEditor.Items.Add(10, "アルバイト");

            // 2008.01.16 追加 >>>>>>>>>>
            // 部署管理
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this._secMngDiv != 2)
            {
                this.BelongMinSectionTitle_Label.Visible = false;
                this.BelongMinSectionCode_tNedit.Visible = false;
                this.BelongMinSectionName_tEdit.Visible = false;
                this.BelongMinSectionGuide_ultraButton.Visible = false;

                this.OldBelongMinSecTitle_Label.Visible = false;
                this.OldBelongMinSecCd_tNedit.Visible = false;
                this.OldBelongMinSecNm_tEdit.Visible = false;
                this.OldBelongMinSecGd_ultraButton.Visible = false;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (this._secMngDiv == 0)
            {
                this.BelongSubSectionTitle_Label.Visible = false;
                this.tNedit_SubSectionCode.Visible = false;
                this.BelongSubSectionName_tEdit.Visible = false;
                this.BelongSubSectionGuide_ultraButton.Visible = false;

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.OldBelongSubSecTitle_Label.Visible = false;
                this.OldBelongSubSecCd_tNedit.Visible = false;
                this.OldBelongSubSecNm_tEdit.Visible = false;
                this.OldBelongSubSecGd_ultraButton.Visible = false;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            }
            // 2008.01.16 追加 <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngDelete_uButton.Visible = _optFeliCaAcs;
            FeliCaMngGuide_uButton.Visible = _optFeliCaAcs;
            FeliCaInfo_Title_uLabel.Visible = _optFeliCaAcs;
            FeliCaInfo_uLabel.Visible = _optFeliCaAcs;
            // 2010/02/18 Add <<<
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			this.tEdit_EmployeeCode.Text = "";							
			this.Name_tEdit.Text = "";						
			this.ShortName_tEdit.Text = "";						
			this.Kana_tEdit.Text = "";								
			this.Sex_tComboEditor.Value = 0;						
			this.Birthday_tDateEdit.Clear();								
			this.CompanyTelNo_tEdit.Clear();
            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Clear();
            this.MailAddress2_tEdit.Clear();
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            this.PortableTelNo_tEdit.Clear();
			this.EnterCompanyDate_tDateEdit.Clear();
			this.RetirementDate_tDateEdit.Clear();
            //this.FrontMechaCode_tComboEditor.SelectedIndex = 0;
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.SelectedIndex = 0;
            //this.PostCode_tComboEditor.SelectedIndex = 0;
            //this.BusinessCode_tComboEditor.SelectedIndex = 0;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;  // 2008/06/04 削除
            //this.LvrRtCstGeneral_tNedit.Clear();
            //this.LvrRtCstCarInspect_tNedit.Clear();
            //this.LvrRtCstBodyRepair_tNedit.Clear();
            //this.LvrRtCstBodyPaint_tNedit.Clear();

            // --- CHG 2008/10/02 --------------------------------------------------------------------->>>>>
            //this.JobType_tComboEditor.SelectedIndex = 6;
            //this.EmploymentForm_tComboEditor.SelectedIndex = 0;
            this.JobType_tComboEditor.SelectedIndex = -1;
            this.EmploymentForm_tComboEditor.SelectedIndex = -1;
            // --- CHG 2008/10/02 ---------------------------------------------------------------------<<<<<

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.Clear();
			this.CustLedgerBootCnt_tNedit.Clear();
			// -- Add St 2012.05.29 30182 R.Tachiya --

			this.UserAdminName_uLabel.Text = "";

			this.LoginId_tEdit.Clear();
			this.LoginPassword_tEdit.Clear();
			this.LoginPasswordAgain_tEdit.Clear();

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                this.FeliCaInfo_uLabel.Text = string.Empty;
                this.FeliCaInfo_uLabel.Tag = null;
            }
            // 2010/02/18 Add <<<

            ScreenClearSub();   // 2007.08.14 追加
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// 画面クリアサブ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細画面をクリアします。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void ScreenClearSub()
        {
            this.tNedit_SubSectionCode.Clear();
            this.BelongSubSectionName_tEdit.Clear();
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionCode_tNedit.Clear();
            this.BelongMinSectionName_tEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this.EmployAnalysCode1_tNedit.Clear();
            this.EmployAnalysCode2_tNedit.Clear();
            this.EmployAnalysCode3_tNedit.Clear();
            this.EmployAnalysCode4_tNedit.Clear();
            this.EmployAnalysCode5_tNedit.Clear();
            this.EmployAnalysCode6_tNedit.Clear();

            this.UOESnmDiv_tEdit.Clear();      //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.OldBelongSectionCd_tEdit.Clear();
            this.OldBelongSectionNm_tEdit.Clear();
            this.OldBelongSubSecCd_tNedit.Clear();
            this.OldBelongSubSecNm_tEdit.Clear();
            this.OldBelongMinSecCd_tNedit.Clear();
            this.OldBelongMinSecNm_tEdit.Clear();
            this.SectionChgDate_tDateEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }
        // 2007.08.14 追加 <<<<<<<<<<

        /// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>> 
            // メニュー簡易起動オプション無しの場合
            if (!this._opMenuSimpleStart)
            {
                // 得意先電子元帳起動枚数項目は非表示
                this.ultraLabel12.Visible = false;
                this.CustLedgerBootCnt_tNedit.Visible = false;
                // 売上伝票入力起動枚数項目は非表示
                this.ultraLabel13.Visible = false;
                this.SalSlipInpBootCnt_tNedit.Visible = false;
            }
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

			if (this.DataIndex < 0)
			{
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				// ボタン設定
				this.Ok_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;

				// 画面入力許可制御処理
				ScreenInputPermissionControl(true);

                // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                MainTabControl.Tabs[1].Visible = true;
                // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<
                
                // 拠点オプション無しの場合
				if (!this._optSection)
				{
					// 所属拠点設定を無効にする
                    // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                    //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;
                    //this.BelongSelectionCode_tComboEditor.Enabled = false;
                    this.tEdit_SectionCode.Clear();
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                }
				
				Employee employee = new Employee();
                EmployeeDtl employeeDtl = new EmployeeDtl();
                _employeeDtl = new EmployeeDtl();
                //クローン作成
				this._employeeClone = employee.Clone(); 
				DispToEmployee(ref this._employeeClone);
                this._employeeDtlClone = employeeDtl.Clone();
                DispToEmployeeDtl(ref this._employeeDtlClone);

				// 従業員コード入力可
				this.tEdit_EmployeeCode.Enabled = true;

				// フォーカス設定
				this.tEdit_EmployeeCode.Focus();

                // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
                //this.PostCode_tComboEditor.NullText     = "";
                //this.BusinessCode_tComboEditor.NullText = "";
                // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				Employee employee = (Employee)this._employeeTable[guid];
                EmployeeDtl employeeDtl = null; 
                if (employee != null)
                {
                    employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
				}

				if (employee.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(true);

                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                    switch (LoginInfoAcquisition.Employee.UserAdminFlag)
                    {
                        case 0:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                JobType_tComboEditor.Enabled = false;
                                EmploymentForm_tComboEditor.Enabled = false;
                                break;
                            }
                        case 1:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                if (employee.UserAdminFlag == 0)
                                {
                                    JobType_tComboEditor.Enabled = true;
                                    EmploymentForm_tComboEditor.Enabled = true;
                                }
                                else
                                {
                                    JobType_tComboEditor.Enabled = false;
                                    EmploymentForm_tComboEditor.Enabled = false;
                                }
                                break;
                            }
                        case 2:
                            {
                                MainTabControl.Tabs[0].Visible = false;
                                break;
                            }
                        default:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                JobType_tComboEditor.Enabled = true;
                                EmploymentForm_tComboEditor.Enabled = true;
                                break;
                            }
                    }
                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<

					// 画面展開処理
					EmployeeToScreen(employee);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
                    // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
                    //string wkString;
                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
                    //employee.PostName = wkString;
                                        
                    //// 役職区分
                    //if (employee.PostName == "未登録")
                    //{
                    //    this.PostCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.PostName == "")
                    //{
                    //    this.PostCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.PostCode_tComboEditor.NullText = "削除済";
                    //}

                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
                    //employee.BusinessName = wkString;

                    //// 業務区分
                    //if (employee.BusinessName == "未登録")
                    //{
                    //    this.BusinessCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.BusinessName == "")
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "削除済";
                    //}
                    // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END

					//クローン作成
					this._employeeClone = employee.Clone(); 
					DispToEmployee(ref this._employeeClone);
                    if (employeeDtl != null)
                    {
                        this._employeeDtlClone = employeeDtl.Clone();
                        DispToEmployeeDtl(ref this._employeeDtlClone);
                    }
                    else
                    {
                        this._employeeDtlClone = new EmployeeDtl();
                        DispToEmployeeDtl(ref this._employeeDtlClone);
                    }
                    //_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
                                                   
					// 更新モードの場合は、従業員コードのみ入力不可とする
					this.tEdit_EmployeeCode.Enabled = false;

					// 拠点オプション無し
					if (!this._optSection)
					{
                        // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                        //this.BelongSelectionCode_tComboEditor.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                    }

                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        FeliCaMngWork felicaMng;
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                        {
                            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
                            {
                                this.FeliCaInfo_uLabel.Text = string.Empty;
                                this.FeliCaInfo_uLabel.Tag = null;
                            }
                            else
                            {
                                this.FeliCaInfo_uLabel.Text = "登録済";
                                this.FeliCaInfo_uLabel.Tag = felicaMng.FeliCaIDm;
                            }
                        }
                        else
                        {
                            this.FeliCaInfo_uLabel.Text = string.Empty;
                            this.FeliCaInfo_uLabel.Tag = null;
                        }
                    }
                    // 2010/02/18 Add <<<

					// フォーカス設定
                    this.Name_tEdit.Focus();
					this.Name_tEdit.SelectAll();
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(false);

                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------>>>>>
                    MainTabControl.Tabs[1].Visible = true;
                    // --- ADD 2009/03/17 障害ID:11347対応------------------------------------------------------<<<<<

					// 画面展開処理
					EmployeeToScreen(employee);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
                    // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
                    //string wkString;
                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
                    //employee.PostName = wkString;

                    //// 役職区分
                    //if (employee.PostName == "未登録")
                    //{
                    //    this.PostCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.PostName == "")
                    //{
                    //    this.PostCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.PostCode_tComboEditor.NullText = "削除済";
                    //}

                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
                    //employee.BusinessName = wkString;

                    //// 業務区分
                    //if (employee.BusinessName == "未登録")
                    //{
                    //    this.BusinessCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.BusinessName == "")
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "削除済";
                    //}

                    // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END

                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        FeliCaMngWork felicaMng;
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                        {
                            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
                            {
                                this.FeliCaInfo_uLabel.Text = string.Empty;
                                this.FeliCaInfo_uLabel.Tag = null;
                            }
                            else
                            {
                                this.FeliCaInfo_uLabel.Text = "登録済";
                                this.FeliCaInfo_uLabel.Tag = felicaMng.FeliCaIDm;
                            }
                        }
                        else
                        {
                            this.FeliCaInfo_uLabel.Text = string.Empty;
                            this.FeliCaInfo_uLabel.Tag = null;
                        }
                    }
                    // 2010/02/18 Add <<<

					// フォーカス設定
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //// --- 拠点オプションに沿った所属拠点コンボボックスのセット --- //
            //this.BelongSelectionCode_tComboEditor.Items.Clear();						
			
            ////拠点オプション無し
            //if (!this._optSection)
            //{
            //    if (this.Mode_Label.Text == INSERT_MODE)
            //    {
            //        this.BelongSelectionCode_tComboEditor.Items.Add(this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd(), this._secInfoAcs.SecInfoSet.SectionGuideNm);
            //    }
            //    else
            //    {
            //        foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //        {
            //            this.BelongSelectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //    {
            //        this.BelongSelectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            //    }
            //}

            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            //拠点オプション無し
            if (!this._optSection)
            {
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    this.tEdit_SectionCode.DataText = this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd();
                    this.tEdit_SectionName.DataText = this._secInfoAcs.SecInfoSet.SectionGuideNm.Trim();
                }
            }
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<

			// --- リアルタイムに更新されるよう且つ、リモートが発生しないようStaticから取得 --- //
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //// 役職区分をセット
            //ArrayList retList = null;
            //this.PostCode_tComboEditor.Items.Clear();
            //int status = GetUserGdInfo(out retList, (int)UserGdGuideDivCodeAcsData.PostCode);
            //if (status == 0)
            //{
            //    // 空白をセット
            //    this.PostCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (UserGdBd userGdBd in retList)
            //    {
            //        if (userGdBd.LogicalDeleteCode == 0)
            //        {
            //            this.PostCode_tComboEditor.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);
            //        }
            //    }
            //}

            //// 業務区分をセット
            //retList = null;
            //this.BusinessCode_tComboEditor.Items.Clear();
            //status = GetUserGdInfo(out retList, (int)UserGdGuideDivCodeAcsData.BusinessCode);
            //if (status == 0)
            //{
            //    // 空白をセット
            //    this.BusinessCode_tComboEditor.Items.Add(0, " ");

            //    foreach (UserGdBd userGdBd in retList)
            //    {
            //        if (userGdBd.LogicalDeleteCode == 0)
            //        {
            //            this.BusinessCode_tComboEditor.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);	
            //        }
            //    }
            //}
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<

			this.tEdit_EmployeeCode.Enabled = enabled;
			this.Name_tEdit.Enabled = enabled;
			this.ShortName_tEdit.Enabled = enabled;
			this.Kana_tEdit.Enabled = enabled;
			this.Sex_tComboEditor.Enabled = enabled;
			this.Birthday_tDateEdit.Enabled = enabled;
			this.CompanyTelNo_tEdit.Enabled = enabled;
			this.PortableTelNo_tEdit.Enabled = enabled;
            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Enabled = enabled;
            this.MailAddress2_tEdit.Enabled = enabled;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            this.EnterCompanyDate_tDateEdit.Enabled = enabled;
			this.RetirementDate_tDateEdit.Enabled = enabled;
            //this.FrontMechaCode_tComboEditor.Enabled = enabled;
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Enabled = enabled;
            //this.PostCode_tComboEditor.Enabled = enabled;
            //this.BusinessCode_tComboEditor.Enabled = enabled;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            //this.LvrRtCstGeneral_tNedit.Enabled = enabled;
            //this.LvrRtCstCarInspect_tNedit.Enabled = enabled;
            //this.LvrRtCstBodyRepair_tNedit.Enabled = enabled;
            //this.LvrRtCstBodyPaint_tNedit.Enabled = enabled;
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //this.BelongSelectionCode_tComboEditor.Enabled = enabled;
            this.tEdit_SectionCode.Enabled = enabled;
            this.SectionGuide_Button.Enabled = enabled;
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<

            this.JobType_tComboEditor.Enabled = enabled;
            this.EmploymentForm_tComboEditor.Enabled = enabled;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.Enabled = enabled;
			this.CustLedgerBootCnt_tNedit.Enabled = enabled;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			this.LoginId_tEdit.Enabled = enabled;
			this.LoginPassword_tEdit.Enabled = enabled;
			this.LoginPasswordAgain_tEdit.Enabled = enabled;

            // 2007.08.14 追加 >>>>>>>>>>
            this.tNedit_SubSectionCode.Enabled = enabled;
            //this.BelongMinSectionCode_tNedit.Enabled = enabled;  // DEL 2008/06/04
            this.EmployAnalysCode1_tNedit.Enabled = enabled;
            this.EmployAnalysCode2_tNedit.Enabled = enabled;
            this.EmployAnalysCode3_tNedit.Enabled = enabled;
            this.EmployAnalysCode4_tNedit.Enabled = enabled;
            this.EmployAnalysCode5_tNedit.Enabled = enabled;
            this.EmployAnalysCode6_tNedit.Enabled = enabled;
            this.UOESnmDiv_tEdit.Enabled = enabled;     //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.OldBelongSectionCd_tEdit.Enabled = enabled;
            this.OldBelongSubSecCd_tNedit.Enabled = enabled;
            this.OldBelongMinSecCd_tNedit.Enabled = enabled;
            this.SectionChgDate_tDateEdit.Enabled = enabled;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            this.BelongSubSectionGuide_ultraButton.Enabled = enabled;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionGuide_ultraButton.Enabled = enabled;
            this.OldBelongSectionGd_ultraButton.Enabled = enabled;
            this.OldBelongSubSecGd_ultraButton.Enabled = enabled;
            this.OldBelongMinSecGd_ultraButton.Enabled = enabled;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // 2007.08.14 追加 <<<<<<<<<<

            // 2010/02/18 Add >>>
            this.FeliCaMngGuide_uButton.Enabled = enabled;
            this.FeliCaMngDelete_uButton.Enabled = enabled;
            // 2010/02/18 Add <<<
		}

		/// <summary>
		/// 従業員クラス画面展開処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 従業員オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void EmployeeToScreen(Employee employee)
		{
			this.Guid_Label.Text = employee.FileHeaderGuid.ToString();
			this.tEdit_EmployeeCode.Text = employee.EmployeeCode;
			this.Name_tEdit.Text = employee.Name;
			this.ShortName_tEdit.Text = employee.ShortName;
			this.Kana_tEdit.Text = employee.Kana;
			this.Sex_tComboEditor.Value = employee.SexCode;
            //this.PostCode_tComboEditor.Value = employee.PostCode;           // DEL 2008/11/04 不具合対応[7289]
            //this.FrontMechaCode_tComboEditor.Value = employee.FrontMechaCode;
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Value = employee.InOutsideCompanyCode;
            //this.BusinessCode_tComboEditor.Value = employee.BusinessCode;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            //this.LvrRtCstGeneral_tNedit.SetValue(employee.LvrRtCstGeneral);
            //this.LvrRtCstCarInspect_tNedit.SetValue(employee.LvrRtCstCarInspect);
            //this.LvrRtCstBodyRepair_tNedit.SetValue(employee.LvrRtCstBodyRepair);
            //this.LvrRtCstBodyPaint_tNedit.SetValue(employee.LvrRtCstBodyPaint);
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //this.BelongSelectionCode_tComboEditor.Value = employee.BelongSectionCode.TrimEnd();
            this.tEdit_SectionCode.DataText = employee.BelongSectionCode.Trim();
            this.tEdit_SectionName.DataText = GetSectionName(employee.BelongSectionCode.Trim());
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
            this.CompanyTelNo_tEdit.Text = employee.CompanyTelNo;
			this.PortableTelNo_tEdit.Text = employee.PortableTelNo;

			if (employee.Birthday != DateTime.MinValue)
			{
				this.Birthday_tDateEdit.SetDateTime(employee.Birthday);
			}
			else
			{
				this.Birthday_tDateEdit.Clear();
			}
			if (employee.EnterCompanyDate != DateTime.MinValue)
			{
				this.EnterCompanyDate_tDateEdit.SetDateTime(employee.EnterCompanyDate);
			}
			else
			{
				this.EnterCompanyDate_tDateEdit.Clear();
			}
			if (employee.RetirementDate != DateTime.MinValue)
			{
				this.RetirementDate_tDateEdit.SetDateTime(employee.RetirementDate);
			}
			else
			{
				RetirementDate_tDateEdit.Clear();
			}

			this.LoginId_tEdit.Text = employee.LoginId;
			this.LoginPassword_tEdit.Text = employee.LoginPassword;
			this.LoginPasswordAgain_tEdit.Text = employee.LoginPassword;
			this.UserAdminName_uLabel.Text = employee.UserAdminName;

            this.JobType_tComboEditor.Value = employee.AuthorityLevel1;
            this.EmploymentForm_tComboEditor.Value = employee.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.SetInt(employee.SalSlipInpBootCnt);
			this.CustLedgerBootCnt_tNedit.SetInt(employee.CustLedgerBootCnt);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

            // 2007.08.14 追加 >>>>>>>>>>
            EmployeeDtl employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
            if (employeeDtl != null)
            {
                this.tNedit_SubSectionCode.SetInt(employeeDtl.BelongSubSectionCode);
                this.BelongSubSectionName_tEdit.Text = GetSubSectionName(employeeDtl.BelongSubSectionCode);
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.BelongMinSectionCode_tNedit.SetInt(employeeDtl.BelongMinSectionCode);
                this.BelongMinSectionName_tEdit.Text = employeeDtl.BelongMinSectionName;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                this.EmployAnalysCode1_tNedit.SetInt(employeeDtl.EmployAnalysCode1);
                this.EmployAnalysCode2_tNedit.SetInt(employeeDtl.EmployAnalysCode2);
                this.EmployAnalysCode3_tNedit.SetInt(employeeDtl.EmployAnalysCode3);
                this.EmployAnalysCode4_tNedit.SetInt(employeeDtl.EmployAnalysCode4);
                this.EmployAnalysCode5_tNedit.SetInt(employeeDtl.EmployAnalysCode5);
                this.EmployAnalysCode6_tNedit.SetInt(employeeDtl.EmployAnalysCode6);

                this.UOESnmDiv_tEdit.Text = employeeDtl.UOESnmDiv;   //2008.11.10 add
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.OldBelongSectionCd_tEdit.DataText = employeeDtl.OldBelongSectionCd;
                this.OldBelongSectionNm_tEdit.DataText = employeeDtl.OldBelongSectionNm;
                this.OldBelongSubSecCd_tNedit.SetInt(employeeDtl.OldBelongSubSecCd);
                this.OldBelongSubSecNm_tEdit.DataText  = employeeDtl.OldBelongSubSecNm;
                this.OldBelongMinSecCd_tNedit.SetInt(employeeDtl.OldBelongMinSecCd);
                this.OldBelongMinSecNm_tEdit.DataText  = employeeDtl.OldBelongMinSecNm;

                if (DateTime.Parse(employeeDtl.SectionChgDate.ToString()) != DateTime.MinValue)
                {
                    this.SectionChgDate_tDateEdit.SetDateTime(DateTime.Parse(employeeDtl.SectionChgDate.ToString()));
                }
                else
                {
                    this.SectionChgDate_tDateEdit.Clear();
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                _employeeDtl = employeeDtl;
            }
            else
            {
                ScreenClearSub();
                _employeeDtl = new EmployeeDtl();
            }
            // 2007.08.14 追加 <<<<<<<<<<

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Text = _employeeDtl.MailAddress1;
            this.MailAddress2_tEdit.Text = _employeeDtl.MailAddress2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
		/// 従業員詳細クラス画面展開処理
		/// </summary>
        /// <param name="employeeCode">従業員詳細オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 従業員詳細オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 980035 金沢  貞義</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
        private EmployeeDtl EmployeeDtlToScreen(String employeeCode)
        {
            if (_employeeDtlData.Count > 0)
            {
                foreach (EmployeeDtl employeeDtl in _employeeDtlData)
                {
                    if (employeeDtl.EmployeeCode.Trim() == employeeCode.Trim())
                    {
                        return employeeDtl;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 従業員詳細クラス画面展開処理
        /// </summary>
        /// <param name="employeeDtl">従業員詳細オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面のデータを従業員詳細オブジェクトに展開します。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void ScreenToEmployeeDtl(EmployeeDtl employeeDtl)
        {
            if (_employeeDtlData.Count > 0)
            {
                ArrayList wkList = new ArrayList();
                wkList = _employeeDtlData;
                EmployeeDtl _wkEmployeeDtl;

                for (int i = 0; i < _employeeDtlData.Count; i++)
                {
                    _wkEmployeeDtl = wkList[i] as EmployeeDtl;
                    if (_wkEmployeeDtl.EmployeeCode.Trim() == employeeDtl.EmployeeCode.Trim())
                    {
                        wkList[i] = employeeDtl;
                        _employeeDtlData = wkList;
                        return;
                    }
                }
            }

            _employeeDtlData.Add(employeeDtl);
        }

        /// <summary>
        /// 従業員詳細クラス画面展開処理
        /// </summary>
        /// <param name="employeeDtl">従業員詳細オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面のデータを従業員詳細オブジェクトから削除します。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void EmployeeDtlDelete(EmployeeDtl employeeDtl)
        {
            if (_employeeDtlData.Count > 0)
            {
                ArrayList wkList = new ArrayList();
                wkList = _employeeDtlData;
                EmployeeDtl _wkEmployeeDtl;

                for (int i = 0; i < _employeeDtlData.Count; i++)
                {
                    _wkEmployeeDtl = wkList[i] as EmployeeDtl;
                    if (_wkEmployeeDtl.EmployeeCode.Trim() == employeeDtl.EmployeeCode.Trim())
                    {
                        wkList.RemoveAt(i);
                        _employeeDtlData = wkList;
                        return;
                    }
                }
            }
        }
        // 2007.08.14 追加 <<<<<<<<<<

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
		/// 画面情報従業員クラス格納処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から従業員オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
 		private void DispToEmployee(ref Employee employee)
		{
			if (employee == null)
			{
				// 新規の場合
				employee = new Employee();
			}

			employee.EnterpriseCode			= this._enterpriseCode;
			employee.EmployeeCode			= this.tEdit_EmployeeCode.Text;
			employee.Name					= this.Name_tEdit.Text;
			employee.Kana					= this.Kana_tEdit.Text;
			employee.ShortName				= this.ShortName_tEdit.Text;
			employee.SexCode				= ValueToInt(this.Sex_tComboEditor.Value);
			employee.SexName				= this.Sex_tComboEditor.SelectedItem.ToString();
			employee.Birthday				= this.Birthday_tDateEdit.GetDateTime();
			employee.CompanyTelNo			= this.CompanyTelNo_tEdit.Text;
			employee.PortableTelNo			= this.PortableTelNo_tEdit.Text;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI DELETE START
//			employee.PostCode				= ValueToInt(this.PostCode_tComboEditor.Value);
//			employee.BusinessCode			= ValueToInt(this.BusinessCode_tComboEditor.Value);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI DELETE END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            //if (this.PostCode_tComboEditor.SelectedItem != null)
            //{
            //    employee.PostCode = ValueToInt(this.PostCode_tComboEditor.Value);
            //}

            //if (this.BusinessCode_tComboEditor.SelectedItem != null)
            //{
            //    employee.BusinessCode = ValueToInt(this.BusinessCode_tComboEditor.Value);
            //}
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END
            employee.PostCode = 0;      // ADD 2008/11/04 不具合対応[7289] 項目削除により初期値を設定
            employee.BusinessCode = 0;  // ADD 2008/11/04 不具合対応[7289] 項目削除により初期値を設定

            //employee.FrontMechaCode			= ValueToInt(this.FrontMechaCode_tComboEditor.Value);
            //employee.InOutsideCompanyCode = ValueToInt(this.InOutsideCompanyCode_tComboEditor.Value);     // DEL 2008/11/04 不具合対応[7289]
            employee.InOutsideCompanyCode = 0;  // ADD 2008/11/04 不具合対応[7289] 項目削除により初期値を設定
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            //    employee.BelongSectionCode		= this.BelongSelectionCode_tComboEditor.Value.ToString();
            employee.BelongSectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            employee.BelongSectionName = GetSectionName(employee.BelongSectionCode);
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
            employee.CompanyTelNo = this.CompanyTelNo_tEdit.Text;
			employee.PortableTelNo			= this.PortableTelNo_tEdit.Text;
            //employee.LvrRtCstGeneral		= this.LvrRtCstGeneral_tNedit.GetInt();
            //employee.LvrRtCstCarInspect		= this.LvrRtCstCarInspect_tNedit.GetInt();
            //employee.LvrRtCstBodyRepair		= this.LvrRtCstBodyRepair_tNedit.GetInt();
            //employee.LvrRtCstBodyPaint		= this.LvrRtCstBodyPaint_tNedit.GetInt();
			employee.LoginId				= this.LoginId_tEdit.Text;
			employee.LoginPassword			= this.LoginPassword_tEdit.Text;
			employee.EnterCompanyDate		= this.EnterCompanyDate_tDateEdit.GetDateTime();
			employee.RetirementDate			= this.RetirementDate_tDateEdit.GetDateTime();

            if (this.JobType_tComboEditor.SelectedItem != null)
            {
                employee.AuthorityLevel1 = ValueToInt(this.JobType_tComboEditor.Value);
            }

            if (this.EmploymentForm_tComboEditor.SelectedItem != null)
            {
                employee.AuthorityLevel2 = ValueToInt(this.EmploymentForm_tComboEditor.Value);
            }

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employee.SalSlipInpBootCnt = ValueToInt(this.SalSlipInpBootCnt_tNedit.Value);
			employee.CustLedgerBootCnt = ValueToInt(this.CustLedgerBootCnt_tNedit.Value);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// 画面情報従業員詳細クラス格納処理
        /// </summary>
        /// <param name="employeeDtl">従業員詳細オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から従業員詳細オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void DispToEmployeeDtl(ref EmployeeDtl employeeDtl)
        {
            if (employeeDtl == null)
            {
                // 新規の場合
                employeeDtl = new EmployeeDtl();
            }

            if (_employeeDtl != null)
            {
                employeeDtl.CreateDateTime    = _employeeDtl.CreateDateTime;
                employeeDtl.UpdateDateTime    = _employeeDtl.UpdateDateTime;
                employeeDtl.EnterpriseCode    = _employeeDtl.EnterpriseCode;
                employeeDtl.FileHeaderGuid    = _employeeDtl.FileHeaderGuid;
                employeeDtl.UpdEmployeeCode   = _employeeDtl.UpdEmployeeCode;
                employeeDtl.UpdAssemblyId1    = _employeeDtl.UpdAssemblyId1;
                employeeDtl.UpdAssemblyId2    = _employeeDtl.UpdAssemblyId2;
                employeeDtl.LogicalDeleteCode = _employeeDtl.LogicalDeleteCode;
            }

            employeeDtl.EnterpriseCode = this._enterpriseCode;
            employeeDtl.EmployeeCode = this.tEdit_EmployeeCode.Text;

            employeeDtl.BelongSubSectionCode = this.tNedit_SubSectionCode.GetInt();
            employeeDtl.BelongSubSectionName = this.BelongSubSectionName_tEdit.Text;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            employeeDtl.BelongMinSectionCode = this.BelongMinSectionCode_tNedit.GetInt();
            employeeDtl.BelongMinSectionName = this.BelongMinSectionName_tEdit.Text;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            employeeDtl.EmployAnalysCode1 = this.EmployAnalysCode1_tNedit.GetInt();
            employeeDtl.EmployAnalysCode2 = this.EmployAnalysCode2_tNedit.GetInt();
            employeeDtl.EmployAnalysCode3 = this.EmployAnalysCode3_tNedit.GetInt();
            employeeDtl.EmployAnalysCode4 = this.EmployAnalysCode4_tNedit.GetInt();
            employeeDtl.EmployAnalysCode5 = this.EmployAnalysCode5_tNedit.GetInt();
            employeeDtl.EmployAnalysCode6 = this.EmployAnalysCode6_tNedit.GetInt();

            employeeDtl.UOESnmDiv = this.UOESnmDiv_tEdit.Text;   //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            employeeDtl.OldBelongSectionCd = this.OldBelongSectionCd_tEdit.DataText;
            employeeDtl.OldBelongSectionNm = this.OldBelongSectionNm_tEdit.DataText;
            employeeDtl.OldBelongSubSecCd  = this.OldBelongSubSecCd_tNedit.GetInt();
            employeeDtl.OldBelongSubSecNm  = this.OldBelongSubSecNm_tEdit.DataText;
            employeeDtl.OldBelongMinSecCd  = this.OldBelongMinSecCd_tNedit.GetInt();
            employeeDtl.OldBelongMinSecNm  = this.OldBelongMinSecNm_tEdit.DataText;

            employeeDtl.SectionChgDate = this.SectionChgDate_tDateEdit.GetDateTime().Date;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtl.MailAddress1 = this.MailAddress1_tEdit.Text.Trim();
            employeeDtl.MailAddress2 = this.MailAddress2_tEdit.Text.Trim();
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        }
        // 2007.08.14 追加 <<<<<<<<<<

        // 2010/02/18 Add >>>
        /// <summary>
        /// 画面情報FeliCa管理クラス格納処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からフェリカ管理オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private void DispToFeliCaMng(ref FeliCaMngWork feliCaMng)
        {
            if (feliCaMng == null)
            {
                // 新規の場合
                feliCaMng = new FeliCaMngWork();
            }

            feliCaMng.EnterpriseCode = this._enterpriseCode;
            feliCaMng.FeliCaMngKind = 1;
            if (this.FeliCaInfo_uLabel.Tag != null)
                feliCaMng.FeliCaIDm = (string)this.FeliCaInfo_uLabel.Tag;
            else
                feliCaMng.FeliCaIDm = string.Empty;
            //feliCaMng.EmployeeCode = this.EmployeeCode_tEdit.Text;
            feliCaMng.EmployeeCode = this.tEdit_EmployeeCode.Text;
        }
        // 2010/02/18 Add <<<

        #region DEL 2008/06/04 Partsman用に変更
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <param name="selectedTab">コンテナのＴａｂ</param>
		/// <param name="loginID">ログインID</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, ref Infragistics.Win.UltraWinTabControl.UltraTab selectedTab, string loginID)
		{
			bool result = true;

			// --- ログインIDの重複チェック --- //

			// ログインIDが同じRow
			string filter = LOGINID_TITLE + " = '" + this.LoginId_tEdit.Text + "'";
			DataRow[] rows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter);

			if (this.tEdit_EmployeeCode.Text.Trim() == "")
			{
				// 従業員コード
				control = this.tEdit_EmployeeCode;
				message = this.EmployeeCode_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.
         * .Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.Name_tEdit.Text.Trim() == "")
			{
				// 従業員氏名
				control = this.Name_tEdit;
				message = this.Name_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.Kana_tEdit.Text.Trim() == "")
			{
				// カナ
				control = this.Kana_tEdit;
				message = this.Kana_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.LoginId_tEdit.Text.Trim() == "")
			{
				// ログインＩＤ
				control = this.LoginId_tEdit;
				message = this.LoginId_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPassword_tEdit.Text.Trim() == "")
			{
				// ログインパスワード
				control = this.LoginPassword_tEdit;
				message = this.LoginPassword_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPasswordAgain_tEdit.Text.Trim() == "")
			{
				// 確認用ログインパスワード
				control = this.LoginPasswordAgain_tEdit;
				message = this.LoginPasswordAgain_Title_Label.Text + "を入力して下さい。";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPassword_tEdit.Text.Trim() != this.LoginPasswordAgain_tEdit.Text.Trim())
			{
				// パスワード違い
				control = this.LoginPasswordAgain_tEdit;
				message = "パスワードが違います。";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.Birthday_tDateEdit.CheckInputData() != null)
			{
				// 生年月日
				control = this.Birthday_tDateEdit;
				message = "入力された日付が不正です。";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.EnterCompanyDate_tDateEdit.CheckInputData() != null)
			{
				// 入社日
				control = this.EnterCompanyDate_tDateEdit;
				message = "入力された日付が不正です。";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.RetirementDate_tDateEdit.CheckInputData() != null)
			{
				// 退社日
				control = this.RetirementDate_tDateEdit;
				message = "入力された日付が不正です。";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
            else if (this.BelongSelectionCode_tComboEditor.Value == null)
            {
                // 所属拠点
                control = this.BelongSelectionCode_tComboEditor;
                message = this.BelongSelectionCode_Title_Label.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.JobType_tComboEditor.Value == null)
            {
                // 職種
                control = this.JobType_tComboEditor;
                message = this.JobType_ultraLabel.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.EmploymentForm_tComboEditor.Value == null)
            {
                // 雇用形態
                control = this.EmploymentForm_tComboEditor;
                message = this.EmploymentForm_ultraLabel.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.tNedit_SubSectionCode.DataText.Trim() != "")
            {
                // 部門コード
                if (GetSubSectionName(this.tNedit_SubSectionCode.GetInt()) == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    control = this.tNedit_SubSectionCode;
                    message = "マスタに登録されていません。";
                    selectedTab = this.MainTabControl.Tabs[TAB3_NAME];
                    result = false;
                }
            }
            else if ((rows.Length != 0) &&
                (this.Mode_Label.Text == INSERT_MODE))
            {
                // ログインＩＤ重複（新規時）
                control = this.LoginId_tEdit;
                message = "その" + this.LoginId_Title_Label.Text + "は既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                result = false;
            }
            else if ((rows.Length != 0) &&
                (this.Mode_Label.Text == UPDATE_MODE) &&
                (this.LoginId_tEdit.Text != loginID))
            {
                // ログインＩＤ重複（更新時）
                control = this.LoginId_tEdit;
                message = "その" + this.LoginId_Title_Label.Text + "は既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                result = false;
            }

			return result;
		}
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman用に変更

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="selectedTab">コンテナのＴａｂ</param>
        /// <param name="loginID">ログインID</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        // 2010/02/18 >>>
        //private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, string loginID)
        private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, string loginID, string feliCaIdm)
        // 2010/02/18 <<<
        {
            // --- ログインIDの重複チェック --- //

            // ログインIDが同じRow
            string filter = LOGINID_TITLE + " = '" + this.LoginId_tEdit.Text + "'";
            DataRow[] rows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter);

            // 2010/02/18 Add >>>
            DataRow[] rows2 = null;
            if (_optFeliCaAcs)
            {
                if (!string.IsNullOrEmpty(feliCaIdm))
                {
                    string filter2 = FELICAIDM_TITLE + " = '" + feliCaIdm + "'";
                    rows2 = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter2);
                }
            }
            // 2010/02/18 Add <<<

            if (this.tEdit_EmployeeCode.Text.Trim() == "")
            {
                // 従業員コード
                control = this.tEdit_EmployeeCode;
                message = this.EmployeeCode_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.Name_tEdit.Text.Trim() == "")
            {
                // 従業員氏名
                control = this.Name_tEdit;
                message = this.Name_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.Kana_tEdit.Text.Trim() == "")
            {
                // カナ
                control = this.Kana_tEdit;
                message = this.Kana_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ADD 2008/10/10 不具合対応[6442] ---------->>>>>
            if (DateEditNoInputCheck(this.Birthday_tDateEdit))
            {
                // 生年月日
                control = this.Birthday_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (DateEditNoInputCheck(this.EnterCompanyDate_tDateEdit))
            {
                // 入社日
                control = this.EnterCompanyDate_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (DateEditNoInputCheck(this.RetirementDate_tDateEdit))
            {
                // 退社日
                control = this.RetirementDate_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ADD 2008/10/10 不具合対応[6442] ----------<<<<<
            if (this.Birthday_tDateEdit.CheckInputData() != null)
            {
                // 生年月日
                control = this.Birthday_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.EnterCompanyDate_tDateEdit.CheckInputData() != null)
            {
                // 入社日
                control = this.EnterCompanyDate_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.RetirementDate_tDateEdit.CheckInputData() != null)
            {
                // 退社日
                control = this.RetirementDate_tDateEdit;
                message = "入力された日付が不正です。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.JobType_tComboEditor.Value == null)
            {
                // 職種
                control = this.JobType_tComboEditor;
                message = this.JobType_ultraLabel.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.EmploymentForm_tComboEditor.Value == null)
            {
                // 雇用形態
                control = this.EmploymentForm_tComboEditor;
                message = this.EmploymentForm_ultraLabel.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                // 所属拠点
                control = this.tEdit_SectionCode;
                message = this.BelongSelectionCode_Title_Label.Text + "を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.tEdit_SectionCode.DataText.Trim() != "")
            {
                if (GetSectionName(this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0')) == "")
                {
                    this.tEdit_SectionName.Clear();
                    control = this.tEdit_SectionCode;
                    message = "マスタに登録されていません。";
                    selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                    return (false);
                }
            }

            // ----- ADD huangt 2013/05/21 Redmine#35765 ---------- >>>>> 
            // 売上伝票入力起動枚数制御
            if (this.SalSlipInpBootCnt_tNedit.GetInt() > 5)
            {
                control = this.SalSlipInpBootCnt_tNedit;
                message = "売上伝票入力起動枚数は５枚以下を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // 得意先電子元帳起動枚数制御
            if (this.CustLedgerBootCnt_tNedit.GetInt() > 5)
            {
                control = this.CustLedgerBootCnt_tNedit;
                message = "得意先電子元帳起動枚数は５枚以下を設定して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ----- ADD huangt 2013/05/21 Redmine#35765 ---------- <<<<<

            if (this.tNedit_SubSectionCode.DataText.Trim() != "")
            {
                // 部門コード
                if (GetSubSectionName(this.tNedit_SubSectionCode.GetInt()) == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    control = this.tNedit_SubSectionCode;
                    message = "マスタに登録されていません。";
                    //selectedTab = this.MainTabControl.Tabs[TAB3_NAME];
                    return (false);
                }
            }
            if (this.LoginId_tEdit.Text.Trim() == "")
            {
                // ログインＩＤ
                control = this.LoginId_tEdit;
                message = this.LoginId_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if (this.LoginPassword_tEdit.Text.Trim() == "")
            {
                // ログインパスワード
                control = this.LoginPassword_tEdit;
                message = this.LoginPassword_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }

            //2008.11.12 add ログインパスワード桁数チェック処理を追加 ----------------------------->>
            if (this.LoginPassword_tEdit.Text.Trim().Length < 4)
            {
                // ログインパスワード
                control = this.LoginPassword_tEdit;
                message = this.LoginPassword_Title_Label.Text + "は４桁以上の値を入力して下さい";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            //2008.11.12 add -------------------------------------------------------------------<<
            
            if (this.LoginPasswordAgain_tEdit.Text.Trim() == "")
            {
                // 確認用ログインパスワード
                control = this.LoginPasswordAgain_tEdit;
                message = this.LoginPasswordAgain_Title_Label.Text + "を入力して下さい。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if (this.LoginPassword_tEdit.Text.Trim() != this.LoginPasswordAgain_tEdit.Text.Trim())
            {
                // パスワード違い
                control = this.LoginPasswordAgain_tEdit;
                message = "パスワードが違います。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((rows.Length != 0) &&
                (this.Mode_Label.Text == INSERT_MODE))
            {
                // ログインＩＤ重複（新規時）
                control = this.LoginId_tEdit;
                message = "その" + this.LoginId_Title_Label.Text + "は既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((rows.Length != 0) &&
                (this.Mode_Label.Text == UPDATE_MODE) &&
                (this.LoginId_tEdit.Text != loginID))
            {
                // ログインＩＤ重複（更新時）
                control = this.LoginId_tEdit;
                message = "その" + this.LoginId_Title_Label.Text + "は既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }

            // 2010/02/18 Add >>>
            if ((_optFeliCaAcs) && (rows2 != null) && (rows2.Length != 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                // felicaidm重複（新規時）
                control = this.FeliCaMngGuide_uButton;
                message = "この" + this.FeliCaInfo_Title_uLabel.Text + "は「コード：" + ((string)rows2[0][CODE_TITLE]).TrimEnd() + "」「名称：" + ((string)rows2[0][NAME_TITLE]).TrimEnd() + "」のデータで既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((_optFeliCaAcs) && (rows2 != null) && (rows2.Length != 0) && (this.Mode_Label.Text == UPDATE_MODE) && (this.tEdit_EmployeeCode.Text != (string)rows2[0][CODE_TITLE]))
            {
                // felicaidm重複（更新時）
                control = this.FeliCaMngGuide_uButton;
                message = "この" + this.FeliCaInfo_Title_uLabel.Text + "は「コード：" + ((string)rows2[0][CODE_TITLE]).TrimEnd() + "」「名称：" + ((string)rows2[0][NAME_TITLE]).TrimEnd() + "」のデータで既に登録されています。";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            // 2010/02/18 Add <<<

            return (true);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
        ///// <summary>
        ///// ユーザーガイドオブジェクト取得処理
        ///// </summary>
        ///// <param name="retList">ユーザーガイドオブジェクトLIST</param>
        ///// <param name="guideDivCode">ガイド区分コード</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : ユーザーガイドから指定ガイド区分のオブジェクトを取得します。</br>
        ///// <br>Programmer : 22033 三崎  貴史</br>
        ///// <br>Date       : 2005.09.20</br>
        ///// </remarks>
        //private int GetUserGdInfo(out ArrayList retList, int guideDivCode)
        //{
        //    retList = new ArrayList();
        //    ArrayList userGdBdList = new ArrayList();
        //    int status = 0;
        //    status = this._userGuideAcs.SearchGuideBufStaticMemory(out userGdBdList, this._enterpriseCode, guideDivCode);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                foreach (UserGdBd userGdBd in userGdBdList)
        //                {
        //                    if (userGdBd.UserGuideDivCd == guideDivCode)
        //                    {
        //                        retList.Add(userGdBd);
        //                    }
        //                }

        //                break;
        //            }
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            {
        //                break;
        //            }
        //        // ---DEL 2008/10/06 不具合対応[6265] ------------------------------------------->>>>>
            
        //        //    default:
        //        //    {
        //        //        TMsgDisp.Show( 
        //        //            this,								  // 親ウィンドウフォーム
        //        //            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
        //        //            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
        //        //            this.Text,							  // プログラム名称
        //        //            "GetUserGdInfo",					  // 処理名称
        //        //            TMsgDisp.OPE_GET,					  // オペレーション
        //        //            ERR_READ_MSG,						  // 表示するメッセージ 
        //        //            status,								  // ステータス値
        //        //            this._employeeAcs,					  // エラーが発生したオブジェクト
        //        //            MessageBoxButtons.OK,				  // 表示するボタン
        //        //            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

        //        //        break;
        //        //    }
        //        // ---DEL 2008/10/06 不具合対応[6265] -------------------------------------------<<<<<
        //    }
            
            
        //    return status;
        //}
        // DEL 2008/11/04 不具合対応[7289] ----------<<<<<

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 22033  三崎 貴史</br>
		/// <br>Date       : 2005.09.21</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_800_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_801_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
		}

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 部門名称取得処理
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns>部門名称</returns>
        /// <remarks>
        /// <br>Note       : 部門名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSubSectionName(int subSectionCode)
        {
            string subSectionName = "";

            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                subSectionName = this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }

            return subSectionName;
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        private void SetControlSize()
        {
            this.Name_tEdit.Size = new Size(496, 24);
            this.Kana_tEdit.Size = new Size(252, 24);
            this.tEdit_SectionCode.Size = new Size(36, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<


        // ADD 2008/10/10 不具合対応[6442] ---------->>>>>
        /// <summary>
        /// 日付Edit 未入力チェック
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool DateEditNoInputCheck(TDateEdit2 targetDateEdit)
        {
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            if (_yearOnlyList.Contains(targetDateEdit.DateFormat))
            {
                // 年のみ
                if (yy == 0) return true;
            }
            else if (_monthOnlyList.Contains(targetDateEdit.DateFormat))
            {
                if (yy == 0 && mm == 0) return true;
            }
            else
            {
                // すべて未入力は可
                if (yy == 0 && mm == 0 && dd == 0) return false;
            }

            if (yy < 1900)
            {
                return true;
            }
            // 年月日別入力チェック
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                return true;
            }
            // 単純日付妥当性チェック
            else if (TDateTime.IsAvailableDate(targetDateEdit.GetDateTime()) == false)
            {
                return true;
            }

            return false;
        }
        // ADD 2008/10/10 不具合対応[6442] ----------<<<<<

		# endregion

		#region ■Control Events
		/// <summary>
		/// Form.Load イベント(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ガイドボタンのアイコン設定
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BelongSubSectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 2010/02/18 Add >>>
            this.FeliCaMngGuide_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.FeliCaMngDelete_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
            // 2010/02/18 Add <<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongSectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongSubSecGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongMinSecGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 自社情報取得
            this.GetCompanyInf();   // 2008.01.16 追加

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

            MainTabControl.Tabs[0].Visible = true;
            MainTabControl.Tabs[1].Visible = true;

			MainTabControl.SelectedTab = MainTabControl.Tabs[0];

            ScreenClear();

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// データインデックスを初期化する
				this.DataIndex = -1;

				// 画面クリア処理
				ScreenClear();

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				//拠点オプション無し
				if (!this._optSection)
				{
                    // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                    //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;
                    //this.BelongSelectionCode_tComboEditor.Enabled = false;
                    this.tEdit_SectionCode.Clear();
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCode.Enabled = false;
                    this.tEdit_SectionName.Enabled = false;
                    // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                }

				// クローンを再度取得する
				Employee employee = new Employee();
                EmployeeDtl employeeDtl = new EmployeeDtl();
				
				//クローン作成
				this._employeeClone = employee.Clone(); 
				DispToEmployee(ref this._employeeClone);
                this._employeeDtlClone = employeeDtl.Clone();
                DispToEmployeeDtl(ref this._employeeDtlClone);

				this.MainTabControl.Tabs["GeneralTab"].Selected = true;
				this.tEdit_EmployeeCode.Focus();
			}
			else
			{
				if (UnDisplaying != null)
				{
					MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
					UnDisplaying(this, me);
				}

				this.DialogResult = DialogResult.OK;

				this._indexBuf = -2;

				if (CanClose == true)
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
		/// 従業員情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報登録を行います。</br>
		/// <br>Programmer : 22033　三崎  貴史</br>
		/// <br>Date       : 2005.05.20</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;
			string loginID = "";
			Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];

			Employee employee = null;
            EmployeeDtl employeeDtl = null; // 2007.08.14 追加

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				employee = ((Employee)this._employeeTable[guid]).Clone();
			}

			// ログインID重複チェック用変数セット
			if (employee != null)
			{
				loginID = employee.LoginId;
			}

            // 2010/02/18 >>>
            //if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID))
            if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID, (string)this.FeliCaInfo_uLabel.Tag))
            // 2010/02/18 <<<
            {
				TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

				this.MainTabControl.SelectedTab = selectedTab;
				control.Focus();
				return false;
			}

			this.DispToEmployee(ref employee);
            this.DispToEmployeeDtl(ref employeeDtl);    // 2007.08.14 追加

            // 2007.08.14 修正 >>>>>>>>>>
            //int status = this._employeeAcs.Write(ref employee);
            int status = this._employeeAcs.Write(ref employee, ref employeeDtl);
            // 2007.08.14 修正 <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngWork felicaMngwk = null;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // FeliCa情報の書き込み
                if (!_optFeliCaAcs) return true;

                string idm = string.Empty;
                if (this.DataIndex >= 0)
                {
                    // キャッシュから取得
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                    _employeeAcs.ReadStaticMemory_FeliCa(out felicaMngwk, idm, 1);
                }
                // 画面情報としてIDmが登録済
                if (this.FeliCaInfo_uLabel.Tag != null)
                {
                    // 既に登録済IDmがある
                    if (!string.IsNullOrEmpty(idm))
                    {
                        // IDm変更(Delete → Insert)
                        if (felicaMngwk != null)
                            status = this._employeeAcs.Delete_FeliCa(felicaMngwk);
                        felicaMngwk = new FeliCaMngWork();
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        // 画面情報上書き
                        this.DispToFeliCaMng(ref felicaMngwk);
                        // DB書込み
                        status = _employeeAcs.Write_Felica(ref felicaMngwk);
                        // IDm重複時
                        if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                ERR_DPR_MSG2,						// 表示するメッセージ 
                                status,								// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン

                            this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                            this.FeliCaMngGuide_uButton.Focus();
                            return false;
                        }
                    }
                }
                else
                {
                    // 登録済みがクリアされた場合データを削除する
                    if (!string.IsNullOrEmpty(idm))
                    {
                        status = _employeeAcs.Delete_FeliCa(felicaMngwk);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            felicaMngwk = null;
                        }
                    }
                }
            }
            // 2010/02/18 Add <<<

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    // DataSet更新
                    FeliCaMngToDataSet(felicaMngwk, employee.EmployeeCode);
                    // 2010/02/18 Add <<<
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						ERR_DPR_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

					this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB1_NAME];
					this.tEdit_EmployeeCode.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._employeeAcs);

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"SaveProc",							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						ERR_UPDT_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						this._employeeAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
			}

			// DataSet展開処理
			EmployeeToDataSet(employee, this.DataIndex);
            ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 追加
			
			return true;
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//保存確認
				Employee compareEmployee = new Employee();
				compareEmployee = this._employeeClone.Clone();
                EmployeeDtl compareEmployeeDtl = new EmployeeDtl();     // 2007.08.14 追加
                compareEmployeeDtl = this._employeeDtlClone.Clone();    // 2007.08.14 追加
                //現在の画面情報を取得する
				DispToEmployee(ref compareEmployee);
                DispToEmployeeDtl(ref compareEmployeeDtl);  // 2007.08.14 追加

                // 2010/02/18 Add >>>
                string idm = string.Empty;
                if ((_optFeliCaAcs) && (this.DataIndex >= 0))
                {
                    // キャッシュから取得
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                }
                // 2010/02/18 Add <<<

                //最初に取得した画面情報と比較
                // 2007.08.14 修正 >>>>>>>>>>
                //if (!(this._employeeClone.Equals(compareEmployee)))
                // 2010/02/18 >>>
                //if (!(this._employeeClone.Equals(compareEmployee)) || !(this._employeeDtlClone.EqualsDtl(compareEmployeeDtl)))
                if ((!(this._employeeClone.Equals(compareEmployee)) || !(this._employeeDtlClone.EqualsDtl(compareEmployeeDtl)))
                    || ((idm != (string)FeliCaInfo_uLabel.Tag) && ((string)FeliCaInfo_uLabel.Tag != null))
                    || ((_optFeliCaAcs) && (idm != (string)FeliCaInfo_uLabel.Tag) && (!string.IsNullOrEmpty(idm))))
                // 2010/02/18 <<<
                // 2007.08.14 修正 <<<<<<<<<<
                {
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						"",									// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNoCancel);		// 表示するボタン

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
							// 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_EmployeeCode.Focus();
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

			this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        ASSEMBLY_ID,
                        "操作権限の制限により、本機能は使用できません。",
                        0,
                        MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


                if (result == DialogResult.OK)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
                    Employee employee = ((Employee)this._employeeTable[guid]).Clone();
                    EmployeeDtl employeeDtl = null;
                    if (employee != null)
                    {
                        employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
                    }

                    // 2007.08.14 修正 >>>>>>>>>>
                    //int status = this._employeeAcs.Delete(employee);
                    int status = this._employeeAcs.Delete(employee, employeeDtl);
                    // 2007.08.14 修正 <<<<<<<<<<

                    // 2010/02/18 Add >>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (_optFeliCaAcs)
                        {
                            FeliCaMngWork felicaMng;
                            string idm = string.Empty;
                            if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                                idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                            _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                            if (felicaMng != null)
                                status = _employeeAcs.Delete_FeliCa(felicaMng);
                        }
                    }
                    // 2010/02/18 Add <<<

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this.DataIndex].Delete();
                                this._employeeTable.Remove(employee.FileHeaderGuid);

                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            {
                                ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._employeeAcs);

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                this.DialogResult = DialogResult.Cancel;
                                this._indexBuf = -2;

                                if (CanClose == true)
                                {
                                    this.Close();
                                }
                                else
                                {
                                    this.Hide();
                                }

                                return;
                            }
                        default:
                            {
                                TMsgDisp.Show(
                                    this,								  // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                                    this.Text,							  // プログラム名称
                                    "Delete_Button_Click",				  // 処理名称
                                    TMsgDisp.OPE_DELETE,				  // オペレーション
                                    ERR_RDEL_MSG,						  // 表示するメッセージ 
                                    status,								  // ステータス値
                                    this._employeeAcs,					  // エラーが発生したオブジェクト
                                    MessageBoxButtons.OK,				  // 表示するボタン
                                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                this.DialogResult = DialogResult.Cancel;
                                this._indexBuf = -2;

                                if (CanClose == true)
                                {
                                    this.Close();
                                }
                                else
                                {
                                    this.Hide();
                                }

                                return;
                            }
                    }
                    EmployeeDtlDelete(employeeDtl); // 2007.08.14 追加
                }
                else
                {
                    this.Delete_Button.Focus();
                    return;
                }
            }

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
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
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            if (MyOpeCtrl.Disabled((int)OperationCode.Revive))
            {
                TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        ASSEMBLY_ID,
                        "操作権限の制限により、本機能は使用できません。",
                        0,
                        MessageBoxButtons.OK);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
                Employee employee = ((Employee)_employeeTable[guid]).Clone();
                EmployeeDtl employeeDtl = null;
                if (employee != null)
                {
                    employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
                }

                // 2007.08.14 追加 >>>>>>>>>>
                //int status = this._employeeAcs.Revival(ref employee);
                int status = this._employeeAcs.Revival(ref employee, ref employeeDtl);
                // 2007.08.14 追加 <<<<<<<<<<

                // 2010/02/18 Add >>>
                FeliCaMngWork felicaMng = null;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                            status = _employeeAcs.Revival_FeliCa(ref felicaMng);
                    }
                }
                // 2010/02/18 Add <<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._employeeAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                                this.Text,							  // プログラム名称
                                "Revive_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_UPDATE,				  // オペレーション
                                ERR_RVV_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._employeeAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                }

                // DataSet展開処理
                EmployeeToDataSet(employee, this.DataIndex);
                ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 追加

                // 2010/02/18 Add >>>
                if (_optFeliCaAcs)
                    FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                // 2010/02/18 Add <<<

            }

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;

            // マスタ読込処理
            ReadSecInfoSet();
            ReadSubSection();

            // 画面再構築処理
			ScreenReconstruction();
		}

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// TRetKeyControl.ChangeFocus イベント イベント(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォーカスが遷移する際に発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // 2007.08.14 追加 >>>>>>>>>>
            if (this._employeeDtl == null) return;
            //int status;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 現時点での従業員詳細クラスの情報を退避する
            EmployeeDtl employeesDtlWork = this._employeeDtl;
            EmployeeDtl employeesDtlBuff = this._employeeDtl;

            switch (e.PrevCtrl.Name)
            {
                #region < 部門 >
                // 部門 ============================================ //
                case "BelongSubSectionCode_tNedit":
                    {
                        if (this._employeeDtlClone.BelongSubSectionCode.CompareTo(this.BelongSubSectionCode_tNedit.GetInt()) != 0)
                        {
                            string belongSectionCode = "";
                            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
                                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
                            if (belongSectionCode == "")
                            {
                                this.BelongSubSectionCode_tNedit.Clear();
                                this.BelongSubSectionName_tEdit.Clear();
                                break;
                            }

                            // 数値のみが入力されているか？
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.BelongSubSectionCode_tNedit.DataText))
                            {
                                SubSection subSection = new SubSection();
                                SubSectionAcs subSectionAcs = new SubSectionAcs();

                                int status = subSectionAcs.Read(out subSection, this._enterpriseCode, belongSectionCode, this.BelongSubSectionCode_tNedit.GetInt());

                                #region < 画面表示処理 >
                                if (status == 0)
                                {
                                    #region -- 取得データ展開 --
                                    // 取得データ表示
                                    this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.BelongSubSectionCode_tNedit.Clear();
                                    this.BelongSubSectionName_tEdit.Clear();

                                    this.BelongMinSectionCode_tNedit.Clear();
                                    this.BelongMinSectionName_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongSubSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // コードがクリアされた場合は、名称もクリア
                                this.BelongSubSectionCode_tNedit.Clear();
                                this.BelongSubSectionName_tEdit.Clear();

                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                            }

                            #region < 編集前データ保持 >
                            // 編集された情報を編集前データとして保持
                            this._employeeDtlClone.BelongSubSectionCode = this.BelongSubSectionCode_tNedit.GetInt();
                            this._employeeDtlClone.BelongSubSectionName = this.BelongSubSectionName_tEdit.DataText;
                            #endregion
                        }

                        break;
                    }
                #endregion

                #region < 課 >
                // 課 ============================================ //
                case "BelongMinSectionCode_tNedit":
                    {
                        if (this._employeeDtlClone.BelongMinSectionCode.CompareTo(this.BelongMinSectionCode_tNedit.GetInt()) != 0)
                        {
                            string belongSectionCode = "";
                            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
                                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
                            if (belongSectionCode == "")
                            {
                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                                break;
                            }

                            // 数値のみが入力されているか？
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.BelongMinSectionCode_tNedit.DataText))
                            {
                                MinSection minSection = new MinSection();
                                MinSectionAcs minSectionAcs = new MinSectionAcs();

                                int status = minSectionAcs.Read(out minSection, this._enterpriseCode, belongSectionCode, this.BelongSubSectionCode_tNedit.GetInt(), this.BelongMinSectionCode_tNedit.GetInt());

                                #region < 画面表示処理 >
                                if (status == 0)
                                {
                                    #region -- 取得データ展開 --
                                    // 取得データ表示
                                    this.BelongMinSectionName_tEdit.DataText = minSection.MinSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.BelongMinSectionCode_tNedit.Clear();
                                    this.BelongMinSectionName_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongMinSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // コードがクリアされた場合は、名称もクリア
                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                            }

                            #region < 編集前データ保持 >
                            // 編集された情報を編集前データとして保持
                            this._employeeDtlClone.BelongMinSectionCode = this.BelongMinSectionCode_tNedit.GetInt();
                            this._employeeDtlClone.BelongMinSectionName = this.BelongMinSectionName_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion
                #region < 旧拠点 >
                // 旧拠点 ============================================ //
                case "OldBelongSectionCd_tEdit":
                    {
                        if (this._employeeDtlClone.OldBelongSectionCd.CompareTo(this.OldBelongSectionCd_tEdit.DataText) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() != "")
                            {
                                SecInfoSet secInfoSet;
                                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

                                int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);

                                #region < 画面表示処理 >

                                if (status == 0)
                                {
                                    #region -- 取得データ展開 --
                                    // 取得データ表示
                                    // 拠点情報画面表示
                                    this.OldBelongSectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;
                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();

                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongSectionCd_tEdit.Clear();
                                    this.OldBelongSectionNm_tEdit.Clear();
                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                this.OldBelongSectionCd_tEdit.Clear();
                                this.OldBelongSectionNm_tEdit.Clear();
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < 編集前データ保持 >
                            // 編集された情報を編集前データとして保持
                            this._employeeDtlClone.OldBelongSectionCd = this.OldBelongSectionCd_tEdit.DataText;
                            this._employeeDtlClone.OldBelongSectionNm = this.OldBelongSectionNm_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion

                #region < 旧部門 >
                // 旧部門 ============================================ //
                case "OldBelongSubSecCd_tNedit":
                    {
                        if (this._employeeDtlClone.OldBelongSubSecCd.CompareTo(this.OldBelongSubSecCd_tNedit.GetInt()) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
                            {
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                break;
                            }

                            // 数値のみが入力されているか？
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.OldBelongSubSecCd_tNedit.DataText))
                            {
                                SubSection subSection = new SubSection();
                                SubSectionAcs subSectionAcs = new SubSectionAcs();

                                int status = subSectionAcs.Read(out subSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText, this.OldBelongSubSecCd_tNedit.GetInt());

                                #region < 画面表示処理 >
                                if (status == 0)
                                {
                                    #region -- 取得データ展開 --
                                    // 取得データ表示
                                    this.OldBelongSubSecNm_tEdit.DataText = subSection.SubSectionName;
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();

                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.OldBelongSubSecCd_tNedit.DataText.Trim() == "")
                            {
                                // コードがクリアされた場合は、名称もクリア
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < 編集前データ保持 >
                            // 編集された情報を編集前データとして保持
                            this._employeeDtlClone.OldBelongSubSecCd = this.OldBelongSubSecCd_tNedit.GetInt();
                            this._employeeDtlClone.OldBelongSubSecNm = this.OldBelongSubSecNm_tEdit.DataText;
                            #endregion
                        }

                        break;
                    }
                #endregion

                #region < 旧課 >
                // 旧課 ============================================ //
                case "OldBelongMinSecCd_tNedit":
                    {
                        if (this._employeeDtlClone.OldBelongMinSecCd.CompareTo(this.OldBelongMinSecCd_tNedit.GetInt()) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
                            {
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                                break;
                            }

                            // 数値のみが入力されているか？
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.OldBelongMinSecCd_tNedit.DataText))
                            {
                                MinSection minSection = new MinSection();
                                MinSectionAcs minSectionAcs = new MinSectionAcs();

                                int status = minSectionAcs.Read(out minSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText, this.OldBelongSubSecCd_tNedit.GetInt(), this.OldBelongMinSecCd_tNedit.GetInt());

                                #region < 画面表示処理 >
                                if (status == 0)
                                {
                                    #region -- 取得データ展開 --
                                    // 取得データ表示
                                    this.OldBelongMinSecNm_tEdit.DataText = minSection.MinSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongMinSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // コードがクリアされた場合は、名称もクリア
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < 編集前データ保持 >
                            // 編集された情報を編集前データとして保持
                            this._employeeDtlClone.OldBelongMinSecCd = this.OldBelongMinSecCd_tNedit.GetInt();
                            this._employeeDtlClone.OldBelongMinSecNm = this.OldBelongMinSecNm_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
		/// <summary>
		/// TEdit.ValueChanged イベント イベント(Name_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 名称を変更した際に発生します。</br>
		/// <br>Programmer  : 22024 寺坂　誉志</br>
		/// <br>Date        : 2005.06.13</br>
		/// </remarks>
		private void Name_tEdit_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.Name_tEdit.DataText.Equals(""))
			{
				this.Kana_tEdit.Clear();
			}
		}
		
		/// <summary>
		/// UltraTabControl.SelectedTabChanged イベント イベント(MainTabControl)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: SelectedTabが変更された後に発生します。</br>
		/// <br>Programmer  : 22024 寺坂　誉志</br>
		/// <br>Date        : 2005.06.21</br>
		/// </remarks>
		private void MainTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB1_NAME])
			{
				if (this.Mode_Label.Text == INSERT_MODE)
				{
					this.tEdit_EmployeeCode.Focus();
					this.tEdit_EmployeeCode.SelectAll();
				}
				else if (this.Mode_Label.Text == UPDATE_MODE)
				{
					this.Name_tEdit.Focus();
					this.Name_tEdit.SelectAll();
				}
				else
				{
					this.Delete_Button.Focus();
				}
			}
			else if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB2_NAME])
			{
				if ((this.Mode_Label.Text == INSERT_MODE) ||
					(this.Mode_Label.Text == UPDATE_MODE))
				{
					this.LoginId_tEdit.Focus();
					this.LoginId_tEdit.SelectAll();
				}
				else
				{
					this.Delete_Button.Focus();
				}
			}
            //// 2007.08.14 追加 >>>>>>>>>>
            //else if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB3_NAME])
            //{
            //    if ((this.Mode_Label.Text == INSERT_MODE) ||
            //        (this.Mode_Label.Text == UPDATE_MODE))
            //    {
            //        this.tNedit_SubSectionCode.Focus();
            //        this.tNedit_SubSectionCode.SelectAll();
            //    }
            //    else
            //    {
            //        this.Delete_Button.Focus();
            //    }
            //}
            //// 2007.08.14 追加 <<<<<<<<<<
        }
		# endregion

        # region ガイドボタンイベント
        #region DEL 2008/06/04 Partsman用に変更
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 所属部門コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void BelongSubSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            string belongSectionCode;
            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            {
                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
            }
            else
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSectionAcs subSectionAcs = new SubSectionAcs();
                SubSection subSection = new SubSection();

                int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, belongSectionCode);
                if (status != 0) return;

                // 取得データ表示
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman用に変更

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 所属部門コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void BelongSubSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSection subSection;

                int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
                if (status != 0) return;

                // 取得データ表示
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;

                //this.EmployAnalysCode1_tNedit.Focus();  // ADD 2008/10/09 不具合対応[6439]  // DEL 2008/11/04 不具合対応[7289]
                //this.Sex_tComboEditor.Focus();      // ADD 2008/11/04 不具合対応[7289]
                this.UOESnmDiv_tEdit.Focus();      // ADD 2008.11.14 不具合対応[7905]
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            if (e.PrevCtrl.Name == "tEdit_SectionCode")
            {
                // 拠点コードが未入力の場合
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    this.tEdit_SectionName.Clear();
                    return;
                }

                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                // 拠点名称取得
                this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                if (e.ShiftKey == true)
                {
                    return;
                }

                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (this.tEdit_SectionName.DataText.Trim() != "")
                    {
                        // --- CHG 2009/02/13 障害ID:11419対応------------------------------------------------------>>>>>
                        //e.NextCtrl = this.Ok_Button;        // DEL 2008/11/04 不具合対応[7289]
                        //e.NextCtrl = this.tNedit_SubSectionCode;        // ADD 2008/11/04 不具合対応[7289]
                        if (this.tNedit_SubSectionCode.Visible == true)
                        {
                            e.NextCtrl = this.tNedit_SubSectionCode;
                        }
                        else
                        {
                            e.NextCtrl = UOESnmDiv_tEdit;
                        }
                        // --- CHG 2009/02/13 障害ID:11419対応------------------------------------------------------<<<<<
                    }
                }
            }
            else if (e.PrevCtrl.Name == "tNedit_SubSectionCode")
            {
                // 所属部門コードが未入力の場合
                if (this.tNedit_SubSectionCode.DataText.Trim() == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    return;
                }

                // 所属部門コード取得
                int subSectionCode = this.tNedit_SubSectionCode.GetInt();

                // 所属部門名称
                this.BelongSubSectionName_tEdit.DataText = GetSubSectionName(subSectionCode);

                if (e.ShiftKey == true)
                {
                    return;
                }

                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (this.BelongSubSectionName_tEdit.DataText.Trim() != "")
                    {
                        //e.NextCtrl = this.EmployAnalysCode1_tNedit;     // DEL 2008/11/04 不具合対応[7289]
                        //e.NextCtrl = this.Sex_tComboEditor;     // ADD 2008/11/04 不具合対応[7289]
                        e.NextCtrl = this.UOESnmDiv_tEdit;     // ADD 2008.11.10 UOE略称区分追加
                    }
                }
            }
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            else if (e.PrevCtrl.Name == "tEdit_EmployeeCode")
            {
                // 担当者コード
                if (this._dataIndex < 0)
                {
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_EmployeeCode;
                    }
                }
            }
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void Kana_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = (TEdit)sender;

            // 半角に変換

            // 2008/11/06 modify [7412] start
            // 入力文字数を取得します
            int textLength = tEdit.Text.Replace("\r\n", "").Length;

            // 入力バイト数を取得します
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(tEdit.Text.Replace("\r\n", ""));

            // ２バイト文字があったときのみ変換
            if (textLength != textByte)
            {
                tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
            }
            // 2008/11/06 modify [7412] end
            
        }

        /// <summary>
        /// Button_Click イベント(従業員ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;

            try
            {
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 従業員コード
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // 従業員名
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.Ok_Button.Focus(); // ADD 2008/10/09 不具合対応[6439]  // DEL 2008/11/04 不具合対応[7289]
                    this.tNedit_SubSectionCode.Focus(); // ADD 2008/11/04 不具合対応[7289]
                }
            }
            catch
            {
            }
        }

        // 2010/02/18 Add >>>
        /// <summary>
        /// FeliCaガイドボタンクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: FeliCaガイドボタンクリック時のイベントです。</br>
        /// <br>Programmer  : 30517 夏野 駿希</br>
        /// <br>Date        : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngGuide_uButton_Click(object sender, EventArgs e)
        {
            UInt64 feliCaIdm = 0;
            SFCMN03505CE feliCaGuide = new SFCMN03505CE();      // FeliCa情報入力フォーム
            DialogResult dialogRet;

            feliCaGuide.Text = "フェリカカードID登録";

            // フェリカ情報入力フォーム起動
            dialogRet = feliCaGuide.ShowFeliCaReadForm(ref feliCaIdm, this);
            if (dialogRet == DialogResult.OK)
            {
                if (!feliCaIdm.Equals(0))
                {
                    // カード情報読み取り成功
                    this.FeliCaInfo_uLabel.Text = "登録済";
                    this.FeliCaInfo_uLabel.Tag = TStrUtils.PadCharRight(feliCaIdm.ToString(), 20);
                }
            }
        }

        /// <summary>
        /// FeliCaカード情報削除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: FeliCa情報削除ボタンクリイク時のイベントです。</br>
        /// <br>Programmer  : 30517 夏野 駿希</br>
        /// <br>Date        : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngDelete_uButton_Click(object sender, EventArgs e)
        {
            // FeliCaの画面情報をクリア
            this.FeliCaInfo_uLabel.Text = string.Empty;
            this.FeliCaInfo_uLabel.Tag = null;
        }
        // 2010/02/18 Add <<<



        /// <summary>
        /// 拠点情報設定マスタ読込処理
        /// </summary>
        private void ReadSecInfoSet()
        {
            try
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 部門マスタ読込処理
        /// </summary>
        private void ReadSubSection()
        {
            try
            {
                this._subSectionDic = new Dictionary<int, SubSection>();

                ArrayList retList;

                int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                        }
                    }
                }
            }
            catch
            {
                this._subSectionDic = new Dictionary<int, SubSection>();
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 担当者コード
            string employeeCode = tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsEmployeeCode = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[i][CODE_TITLE];
                if (employeeCode.Equals(dsEmployeeCode.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの従業員設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 担当者コードのクリア
                        tEdit_EmployeeCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの従業員設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
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
                                // 担当者コードのクリア
                                tEdit_EmployeeCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        /// <summary>
        /// パスワード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginPassword_tEdit_Leave(object sender, EventArgs e)
        {
            /*2008.11.12 del ScreenDataCheckメソッドにチェック処理を移動 --------------------------->>
            // 2008/11/06 add [7366] start
            if (this.LoginPassword_tEdit.Text.Trim().Length < 4)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ASSEMBLY_ID, this.Text,
                    "Password", TMsgDisp.OPE_GET, "４桁以上の値を入力して下さい", // 表示するメッセージ 
                    0, this.LoginPassword_tEdit,
                    MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                this.LoginPassword_tEdit.Clear();
                this.LoginPassword_tEdit.Focus();
            }
            // 2008/11/06 add [7366] end
              2008.11.12 del -------------------------------------------------------------------<<*/ 
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 所属課コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void BelongMinSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            string belongSectionCode;
            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            {
                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
            }
            else
            {
                return;
            }

            MinSectionAcs minSectionAcs = new MinSectionAcs();
            MinSection minSection = new MinSection();

            int status = minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, belongSectionCode);
            if (status != 0) return;

            
            // 取得データ表示
            this.BelongMinSectionCode_tNedit.SetInt(minSection.MinSectionCode);
            this.BelongMinSectionName_tEdit.DataText = minSection.MinSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 旧所属拠点コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void OldBelongSectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status != 0) return;

            
            // 取得データ表示
            this.OldBelongSectionCd_tEdit.DataText = secInfoSet.SectionCode;
            this.OldBelongSectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;
            
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 旧所属部門コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void OldBelongSubSecGd_ultraButton_Click(object sender, EventArgs e)
        {
            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
            {
                return;
            }

            SubSectionAcs subSectionAcs = new SubSectionAcs();
            SubSection subSection = new SubSection();

            int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);
            if (status != 0) return;

            // 取得データ表示
            this.OldBelongSubSecCd_tNedit.SetInt(subSection.SubSectionCode);
            this.OldBelongSubSecNm_tEdit.DataText = subSection.SubSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 旧所属課コードガイドボタンイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void OldBelongMinSecGd_ultraButton_Click(object sender, EventArgs e)
        {
            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
            {
                return;
            }

            MinSectionAcs minSectionAcs = new MinSectionAcs();
            MinSection minSection = new MinSection();

            int status = minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);
            if (status != 0) return;

            // 取得データ表示
            this.OldBelongMinSecCd_tNedit.SetInt(minSection.MinSectionCode);
            this.OldBelongMinSecNm_tEdit.DataText = minSection.MinSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion
    }

	# region 従業員情報印刷範囲クラス
	/// <summary>
	/// 従業員情報印刷範囲クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員情報印刷範囲のクラスです。</br>
	/// <br>Programmer : 20054 田島  学</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// </remarks>
	public class sendEmployeeData
	{
		/// <summary>
		/// 従業員情報印刷範囲クラスデータセット処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のデータセットです。</br>
		/// <br>Programmer : 20054 田島  学</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public DataSet dataSet;

		/// <summary>
		/// 従業員情報ハッシュテーブル
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のハッシュテーブルです。</br>
		/// <br>Programmer : 20054 田島  学</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

	# region 従業員情報印刷抽出条件クラス
	/// <summary>
	/// 従業員情報印刷抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員情報印刷抽出条件のクラスです。</br>
	/// <br>Programmer : 20054 田島  学</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
		/// 開始従業員コード
		/// </summary>
		public string StartEmployeeCode;
		/// <summary>
		/// 終了従業員コード
		/// </summary>
		public string EndEmployeeCode;
		/// <summary>
		/// 開始従業員名称
		/// </summary>
		public string StartEmployeeName;
		/// <summary>
		/// 終了従業員名称
		/// </summary>
		public string EndEmployeeName;
		/// <summary>
		/// 開始拠点コード
		/// </summary>
		public string StartSectionCode;
		/// <summary>
		/// 開始拠点コード
		/// </summary>
		public string EndSectionCode;
		/// <summary>
		/// 開始拠点名称
		/// </summary>
		public string StartSectionName;
		/// <summary>
		/// 開始拠点名称
		/// </summary>
		public string EndSectionName;
	}
	# endregion
}
