//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求全体設定
// プログラム概要   : 請求全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三橋 弘憲
// 作 成 日  2005/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : enokida
// 修 正 日  2005/09/09  修正内容 : ログイン情報取得対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : enokida
// 修 正 日  2005/09/17  修正内容 : Message部品対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 谷藤　範幸
// 修 正 日  2005/10/19  修正内容 : UI子画面Hide時のOwner.Activate処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 秋山　亮介
// 修 正 日  2006/06/01  修正内容 : 前受金算定区分を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 段上 知子
// 修 正 日  2006/12/13  修正内容 : 
// 1.SF版を流用し携帯版を作成
// 2.未使用項目を固定値へ変更(マイナス諸費用残高調整区分・前受金算定区分を削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/13  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/09  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  13142       作成担当 : 工藤　恵優
// 修 正 日  2009/04/08  修正内容 : 初期状態で拠点ガイド入力を行うと全社共通になってしまう
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/14  修正内容 : Mantis【13176】全社共通のみ処理対象締日を入力可に変更
//----------------------------------------------------------------------------//
// 管理番号 10704766-00  作成担当：王飛3
// 修 正 日 2011/09/07   修正内容：連番909 拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//                       拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正してください。
// ---------------------------------------------------------------------------//

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
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 請求全体設定クラス
	/// </summary>
	/// <remarks>
	/// <br>note	   : 請求関連の設定を行います。
	///					 IMasterMaintenanceSingleTypeを実装しています。</br>              
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2005.08.01</br>
	/// <br>Update Note: 2005.09.09 23003 enokida</br>
	/// <br>           : ログイン情報取得対応</br>	
	/// <br>Update Note: 2005.09.17 23003 enokida</br>
	/// <br>           : Message部品対応</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   : ・UI子画面Hide時のOwner.Activate処理追加</br>
	/// <br>Update Note: 2006.06.01 23001 秋山　亮介</br>
    /// <br>                        1.前受金算定区分を追加</br>
    /// <br>Update Note: 2006.12.13 22022 段上 知子</br>
    /// <br>					    1.SF版を流用し携帯版を作成</br>
    /// <br>					    2.未使用項目を固定値へ変更(マイナス諸費用残高調整区分・前受金算定区分を削除)</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/13</br>	
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2009/04/08 30434 工藤 恵優　バグ修正</br>
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// </remarks>
    public class SFUKK09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer timer1;
        private Infragistics.Win.Misc.UltraLabel AllowanceProcCd_Title_Label;
        private Broadleaf.Library.Windows.Forms.TComboEditor AllowanceProcCd_tComboEditor;
        private TComboEditor DepositSlipMntCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DepositSlipMntCd_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay12_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay11_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay8_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay9_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay10_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay7_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay6_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay5_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay4_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay12_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay11_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay8_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay9_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay10_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay7_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay6_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay5_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay4_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay1_Title_Label;
        private DataSet Bind_DataSet;
        private TNedit CustomerTotalDay1_tEdit;
        private TNedit CustomerTotalDay4_tEdit;
        private TNedit CustomerTotalDay5_tEdit;
        private TNedit CustomerTotalDay12_tEdit;
        private TNedit CustomerTotalDay11_tEdit;
        private TNedit CustomerTotalDay9_tEdit;
        private TNedit CustomerTotalDay8_tEdit;
        private TNedit CustomerTotalDay6_tEdit;
        private TNedit CustomerTotalDay7_tEdit;
        private TNedit CustomerTotalDay3_tEdit;
        private TNedit CustomerTotalDay2_tEdit;
        private TNedit CustomerTotalDay10_tEdit;
        private TNedit SupplierTotalDay1_tEdit;
        private TNedit SupplierTotalDay12_tEdit;
        private TNedit SupplierTotalDay11_tEdit;
        private TNedit SupplierTotalDay10_tEdit;
        private TNedit SupplierTotalDay9_tEdit;
        private TNedit SupplierTotalDay8_tEdit;
        private TNedit SupplierTotalDay7_tEdit;
        private TNedit SupplierTotalDay6_tEdit;
        private TNedit SupplierTotalDay5_tEdit;
        private TNedit SupplierTotalDay4_tEdit;
        private TNedit SupplierTotalDay3_tEdit;
        private TNedit SupplierTotalDay2_tEdit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel CollectPlnDiv_Title_Label;
        private TComboEditor CollectPlnDiv_tComboEditor;
		private System.ComponentModel.IContainer components;

		# endregion

		# region Constructor
		/// <summary>
		/// SFUKK09100UAコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>note	   : 請求全体設定クラス、請求全体設定アクセスクラスを生成します。
		///					 フレーム画面の印刷ボタン非表示設定を行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public SFUKK09100UA()
		{
			InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値
            this._canClose = false;	                       // 閉じる機能（デフォルトtrue固定）
            this._canDelete = true;		                   // 削除機能
            this._canLogicalDeleteDataExtraction = true;   // 論理削除データ表示機能
            this._canNew = true;		                   // 新規作成機能
            this._canPrint = false;	                       // 印刷機能
            this._canSpecificationSearch = false;	       // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	       // 列サイズ自動調整機能

			// 2005.09.09 enokida ADD ログイン情報取得対応 >>>>>>>>>>>>>>>>> START
			//　企業コードを取得する
			this._enterPriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.09 enokida ADD ログイン情報取得対応 <<<<<<<<<<<<<<<<< END

            // autoliaSetクラス
            this._billAllSt = new BillAllSt();

            // 初期化
            this._dataIndex = -1;
            this._billAllStAcs = new BillAllStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._billAllStTable = new Hashtable();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // ADD 2008/09/16 不具合対応[5257] ---------->>>>>
            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.AllowanceProcCd_tComboEditor
            );
            // ADD 2008/09/16 不具合対応[5257] ----------<<<<<
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09100UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.AllowanceProcCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AllowanceProcCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DepositSlipMntCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DepositSlipMntCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay4_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay5_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay6_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay12_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay11_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay8_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay9_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay10_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay7_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.SupplierTotalDay12_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay11_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay8_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay9_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay10_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay7_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay6_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay5_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay4_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.CustomerTotalDay1_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay2_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay3_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay7_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay6_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay8_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay9_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay11_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay12_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay5_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay4_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay10_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay1_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay2_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay3_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay4_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay5_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay6_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay7_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay8_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay9_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay10_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay11_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay12_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.CollectPlnDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CollectPlnDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceProcCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipMntCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay7_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay11_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay12_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay7_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay11_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay12_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectPlnDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(180, 366);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 32;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(306, 366);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 33;
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 420);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(469, 23);
            this.ultraStatusBar1.TabIndex = 10;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // AllowanceProcCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AllowanceProcCd_tComboEditor.ActiveAppearance = appearance5;
            this.AllowanceProcCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AllowanceProcCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AllowanceProcCd_tComboEditor.ItemAppearance = appearance6;
            this.AllowanceProcCd_tComboEditor.Location = new System.Drawing.Point(195, 84);
            this.AllowanceProcCd_tComboEditor.Name = "AllowanceProcCd_tComboEditor";
            this.AllowanceProcCd_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.AllowanceProcCd_tComboEditor.TabIndex = 3;
            // 
            // AllowanceProcCd_Title_Label
            // 
            this.AllowanceProcCd_Title_Label.Location = new System.Drawing.Point(21, 87);
            this.AllowanceProcCd_Title_Label.Name = "AllowanceProcCd_Title_Label";
            this.AllowanceProcCd_Title_Label.Size = new System.Drawing.Size(125, 14);
            this.AllowanceProcCd_Title_Label.TabIndex = 7;
            this.AllowanceProcCd_Title_Label.Text = "引当処理区分";
            // 
            // Mode_Label
            // 
            appearance22.ForeColor = System.Drawing.Color.White;
            appearance22.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance22;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance23.TextHAlignAsString = "Center";
            appearance23.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance23;
            this.Mode_Label.Location = new System.Drawing.Point(336, 2);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DepositSlipMntCd_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositSlipMntCd_tComboEditor.ActiveAppearance = appearance7;
            this.DepositSlipMntCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DepositSlipMntCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositSlipMntCd_tComboEditor.ItemAppearance = appearance8;
            this.DepositSlipMntCd_tComboEditor.Location = new System.Drawing.Point(195, 114);
            this.DepositSlipMntCd_tComboEditor.Name = "DepositSlipMntCd_tComboEditor";
            this.DepositSlipMntCd_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.DepositSlipMntCd_tComboEditor.TabIndex = 4;
            // 
            // DepositSlipMntCd_Title_Label
            // 
            this.DepositSlipMntCd_Title_Label.Location = new System.Drawing.Point(21, 114);
            this.DepositSlipMntCd_Title_Label.Name = "DepositSlipMntCd_Title_Label";
            this.DepositSlipMntCd_Title_Label.Size = new System.Drawing.Size(140, 14);
            this.DepositSlipMntCd_Title_Label.TabIndex = 8;
            this.DepositSlipMntCd_Title_Label.Text = "入金伝票修正区分";
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(251, 32);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 163;
            this.SectionNm_Label.Text = "※ゼロで共通設定になります";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance83;
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance84;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(64, 32);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCodeAllowZero_Leave);
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
            this.SectionNm_tEdit.Location = new System.Drawing.Point(130, 32);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(99, 32);
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
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(21, 32);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(60, 23);
            this.SectionCode_Title_Label.TabIndex = 161;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 63);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(435, 3);
            this.ultraLabel17.TabIndex = 164;
            // 
            // CustomerTotalDay_Title_Label
            // 
            this.CustomerTotalDay_Title_Label.Location = new System.Drawing.Point(20, 186);
            this.CustomerTotalDay_Title_Label.Name = "CustomerTotalDay_Title_Label";
            this.CustomerTotalDay_Title_Label.Size = new System.Drawing.Size(191, 17);
            this.CustomerTotalDay_Title_Label.TabIndex = 165;
            this.CustomerTotalDay_Title_Label.Text = "処理対象締日（得意先）";
            // 
            // CustomerTotalDay1_Title_Label
            // 
            appearance108.BackColor = System.Drawing.SystemColors.Highlight;
            appearance108.ForeColor = System.Drawing.Color.White;
            appearance108.TextHAlignAsString = "Center";
            appearance108.TextVAlignAsString = "Middle";
            this.CustomerTotalDay1_Title_Label.Appearance = appearance108;
            this.CustomerTotalDay1_Title_Label.Location = new System.Drawing.Point(20, 209);
            this.CustomerTotalDay1_Title_Label.Name = "CustomerTotalDay1_Title_Label";
            this.CustomerTotalDay1_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay1_Title_Label.TabIndex = 166;
            this.CustomerTotalDay1_Title_Label.Text = "1";
            // 
            // CustomerTotalDay4_Title_Label
            // 
            appearance107.BackColor = System.Drawing.SystemColors.Highlight;
            appearance107.ForeColor = System.Drawing.Color.White;
            appearance107.TextHAlignAsString = "Center";
            appearance107.TextVAlignAsString = "Middle";
            this.CustomerTotalDay4_Title_Label.Appearance = appearance107;
            this.CustomerTotalDay4_Title_Label.Location = new System.Drawing.Point(125, 209);
            this.CustomerTotalDay4_Title_Label.Name = "CustomerTotalDay4_Title_Label";
            this.CustomerTotalDay4_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay4_Title_Label.TabIndex = 167;
            this.CustomerTotalDay4_Title_Label.Text = "4";
            // 
            // CustomerTotalDay3_Title_Label
            // 
            appearance106.BackColor = System.Drawing.SystemColors.Highlight;
            appearance106.ForeColor = System.Drawing.Color.White;
            appearance106.TextHAlignAsString = "Center";
            appearance106.TextVAlignAsString = "Middle";
            this.CustomerTotalDay3_Title_Label.Appearance = appearance106;
            this.CustomerTotalDay3_Title_Label.Location = new System.Drawing.Point(90, 209);
            this.CustomerTotalDay3_Title_Label.Name = "CustomerTotalDay3_Title_Label";
            this.CustomerTotalDay3_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay3_Title_Label.TabIndex = 168;
            this.CustomerTotalDay3_Title_Label.Text = "3";
            // 
            // CustomerTotalDay2_Title_Label
            // 
            appearance105.BackColor = System.Drawing.SystemColors.Highlight;
            appearance105.ForeColor = System.Drawing.Color.White;
            appearance105.TextHAlignAsString = "Center";
            appearance105.TextVAlignAsString = "Middle";
            this.CustomerTotalDay2_Title_Label.Appearance = appearance105;
            this.CustomerTotalDay2_Title_Label.Location = new System.Drawing.Point(55, 209);
            this.CustomerTotalDay2_Title_Label.Name = "CustomerTotalDay2_Title_Label";
            this.CustomerTotalDay2_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay2_Title_Label.TabIndex = 169;
            this.CustomerTotalDay2_Title_Label.Text = "2";
            // 
            // CustomerTotalDay5_Title_Label
            // 
            appearance104.BackColor = System.Drawing.SystemColors.Highlight;
            appearance104.ForeColor = System.Drawing.Color.White;
            appearance104.TextHAlignAsString = "Center";
            appearance104.TextVAlignAsString = "Middle";
            this.CustomerTotalDay5_Title_Label.Appearance = appearance104;
            this.CustomerTotalDay5_Title_Label.Location = new System.Drawing.Point(160, 209);
            this.CustomerTotalDay5_Title_Label.Name = "CustomerTotalDay5_Title_Label";
            this.CustomerTotalDay5_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay5_Title_Label.TabIndex = 170;
            this.CustomerTotalDay5_Title_Label.Text = "5";
            // 
            // CustomerTotalDay6_Title_Label
            // 
            appearance103.BackColor = System.Drawing.SystemColors.Highlight;
            appearance103.ForeColor = System.Drawing.Color.White;
            appearance103.TextHAlignAsString = "Center";
            appearance103.TextVAlignAsString = "Middle";
            this.CustomerTotalDay6_Title_Label.Appearance = appearance103;
            this.CustomerTotalDay6_Title_Label.Location = new System.Drawing.Point(195, 209);
            this.CustomerTotalDay6_Title_Label.Name = "CustomerTotalDay6_Title_Label";
            this.CustomerTotalDay6_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay6_Title_Label.TabIndex = 171;
            this.CustomerTotalDay6_Title_Label.Text = "6";
            // 
            // CustomerTotalDay12_Title_Label
            // 
            appearance97.BackColor = System.Drawing.SystemColors.Highlight;
            appearance97.ForeColor = System.Drawing.Color.White;
            appearance97.TextHAlignAsString = "Center";
            appearance97.TextVAlignAsString = "Middle";
            this.CustomerTotalDay12_Title_Label.Appearance = appearance97;
            this.CustomerTotalDay12_Title_Label.Location = new System.Drawing.Point(405, 209);
            this.CustomerTotalDay12_Title_Label.Name = "CustomerTotalDay12_Title_Label";
            this.CustomerTotalDay12_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay12_Title_Label.TabIndex = 177;
            this.CustomerTotalDay12_Title_Label.Text = "12";
            // 
            // CustomerTotalDay11_Title_Label
            // 
            appearance98.BackColor = System.Drawing.SystemColors.Highlight;
            appearance98.ForeColor = System.Drawing.Color.White;
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.CustomerTotalDay11_Title_Label.Appearance = appearance98;
            this.CustomerTotalDay11_Title_Label.Location = new System.Drawing.Point(370, 209);
            this.CustomerTotalDay11_Title_Label.Name = "CustomerTotalDay11_Title_Label";
            this.CustomerTotalDay11_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay11_Title_Label.TabIndex = 176;
            this.CustomerTotalDay11_Title_Label.Text = "11";
            // 
            // CustomerTotalDay8_Title_Label
            // 
            appearance99.BackColor = System.Drawing.SystemColors.Highlight;
            appearance99.ForeColor = System.Drawing.Color.White;
            appearance99.TextHAlignAsString = "Center";
            appearance99.TextVAlignAsString = "Middle";
            this.CustomerTotalDay8_Title_Label.Appearance = appearance99;
            this.CustomerTotalDay8_Title_Label.Location = new System.Drawing.Point(265, 209);
            this.CustomerTotalDay8_Title_Label.Name = "CustomerTotalDay8_Title_Label";
            this.CustomerTotalDay8_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay8_Title_Label.TabIndex = 175;
            this.CustomerTotalDay8_Title_Label.Text = "8";
            // 
            // CustomerTotalDay9_Title_Label
            // 
            appearance100.BackColor = System.Drawing.SystemColors.Highlight;
            appearance100.ForeColor = System.Drawing.Color.White;
            appearance100.TextHAlignAsString = "Center";
            appearance100.TextVAlignAsString = "Middle";
            this.CustomerTotalDay9_Title_Label.Appearance = appearance100;
            this.CustomerTotalDay9_Title_Label.Location = new System.Drawing.Point(300, 209);
            this.CustomerTotalDay9_Title_Label.Name = "CustomerTotalDay9_Title_Label";
            this.CustomerTotalDay9_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay9_Title_Label.TabIndex = 174;
            this.CustomerTotalDay9_Title_Label.Text = "9";
            // 
            // CustomerTotalDay10_Title_Label
            // 
            appearance101.BackColor = System.Drawing.SystemColors.Highlight;
            appearance101.ForeColor = System.Drawing.Color.White;
            appearance101.TextHAlignAsString = "Center";
            appearance101.TextVAlignAsString = "Middle";
            this.CustomerTotalDay10_Title_Label.Appearance = appearance101;
            this.CustomerTotalDay10_Title_Label.Location = new System.Drawing.Point(335, 209);
            this.CustomerTotalDay10_Title_Label.Name = "CustomerTotalDay10_Title_Label";
            this.CustomerTotalDay10_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay10_Title_Label.TabIndex = 173;
            this.CustomerTotalDay10_Title_Label.Text = "10";
            // 
            // CustomerTotalDay7_Title_Label
            // 
            appearance102.BackColor = System.Drawing.SystemColors.Highlight;
            appearance102.ForeColor = System.Drawing.Color.White;
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.CustomerTotalDay7_Title_Label.Appearance = appearance102;
            this.CustomerTotalDay7_Title_Label.Location = new System.Drawing.Point(230, 209);
            this.CustomerTotalDay7_Title_Label.Name = "CustomerTotalDay7_Title_Label";
            this.CustomerTotalDay7_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay7_Title_Label.TabIndex = 172;
            this.CustomerTotalDay7_Title_Label.Text = "7";
            // 
            // SupplierTotalDay_Title_Label
            // 
            this.SupplierTotalDay_Title_Label.Location = new System.Drawing.Point(21, 273);
            this.SupplierTotalDay_Title_Label.Name = "SupplierTotalDay_Title_Label";
            this.SupplierTotalDay_Title_Label.Size = new System.Drawing.Size(191, 17);
            this.SupplierTotalDay_Title_Label.TabIndex = 190;
            this.SupplierTotalDay_Title_Label.Text = "処理対象締日（仕入先）";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(21, 366);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 30;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(54, 366);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 31;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // SupplierTotalDay12_Title_Label
            // 
            appearance69.BackColor = System.Drawing.SystemColors.Highlight;
            appearance69.ForeColor = System.Drawing.Color.White;
            appearance69.TextHAlignAsString = "Center";
            appearance69.TextVAlignAsString = "Middle";
            this.SupplierTotalDay12_Title_Label.Appearance = appearance69;
            this.SupplierTotalDay12_Title_Label.Location = new System.Drawing.Point(405, 295);
            this.SupplierTotalDay12_Title_Label.Name = "SupplierTotalDay12_Title_Label";
            this.SupplierTotalDay12_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay12_Title_Label.TabIndex = 228;
            this.SupplierTotalDay12_Title_Label.Text = "12";
            // 
            // SupplierTotalDay11_Title_Label
            // 
            appearance70.BackColor = System.Drawing.SystemColors.Highlight;
            appearance70.ForeColor = System.Drawing.Color.White;
            appearance70.TextHAlignAsString = "Center";
            appearance70.TextVAlignAsString = "Middle";
            this.SupplierTotalDay11_Title_Label.Appearance = appearance70;
            this.SupplierTotalDay11_Title_Label.Location = new System.Drawing.Point(370, 295);
            this.SupplierTotalDay11_Title_Label.Name = "SupplierTotalDay11_Title_Label";
            this.SupplierTotalDay11_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay11_Title_Label.TabIndex = 227;
            this.SupplierTotalDay11_Title_Label.Text = "11";
            // 
            // SupplierTotalDay8_Title_Label
            // 
            appearance71.BackColor = System.Drawing.SystemColors.Highlight;
            appearance71.ForeColor = System.Drawing.Color.White;
            appearance71.TextHAlignAsString = "Center";
            appearance71.TextVAlignAsString = "Middle";
            this.SupplierTotalDay8_Title_Label.Appearance = appearance71;
            this.SupplierTotalDay8_Title_Label.Location = new System.Drawing.Point(265, 295);
            this.SupplierTotalDay8_Title_Label.Name = "SupplierTotalDay8_Title_Label";
            this.SupplierTotalDay8_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay8_Title_Label.TabIndex = 226;
            this.SupplierTotalDay8_Title_Label.Text = "8";
            // 
            // SupplierTotalDay9_Title_Label
            // 
            appearance72.BackColor = System.Drawing.SystemColors.Highlight;
            appearance72.ForeColor = System.Drawing.Color.White;
            appearance72.TextHAlignAsString = "Center";
            appearance72.TextVAlignAsString = "Middle";
            this.SupplierTotalDay9_Title_Label.Appearance = appearance72;
            this.SupplierTotalDay9_Title_Label.Location = new System.Drawing.Point(300, 295);
            this.SupplierTotalDay9_Title_Label.Name = "SupplierTotalDay9_Title_Label";
            this.SupplierTotalDay9_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay9_Title_Label.TabIndex = 225;
            this.SupplierTotalDay9_Title_Label.Text = "9";
            // 
            // SupplierTotalDay10_Title_Label
            // 
            appearance73.BackColor = System.Drawing.SystemColors.Highlight;
            appearance73.ForeColor = System.Drawing.Color.White;
            appearance73.TextHAlignAsString = "Center";
            appearance73.TextVAlignAsString = "Middle";
            this.SupplierTotalDay10_Title_Label.Appearance = appearance73;
            this.SupplierTotalDay10_Title_Label.Location = new System.Drawing.Point(335, 295);
            this.SupplierTotalDay10_Title_Label.Name = "SupplierTotalDay10_Title_Label";
            this.SupplierTotalDay10_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay10_Title_Label.TabIndex = 224;
            this.SupplierTotalDay10_Title_Label.Text = "10";
            // 
            // SupplierTotalDay7_Title_Label
            // 
            appearance74.BackColor = System.Drawing.SystemColors.Highlight;
            appearance74.ForeColor = System.Drawing.Color.White;
            appearance74.TextHAlignAsString = "Center";
            appearance74.TextVAlignAsString = "Middle";
            this.SupplierTotalDay7_Title_Label.Appearance = appearance74;
            this.SupplierTotalDay7_Title_Label.Location = new System.Drawing.Point(230, 295);
            this.SupplierTotalDay7_Title_Label.Name = "SupplierTotalDay7_Title_Label";
            this.SupplierTotalDay7_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay7_Title_Label.TabIndex = 223;
            this.SupplierTotalDay7_Title_Label.Text = "7";
            // 
            // SupplierTotalDay6_Title_Label
            // 
            appearance75.BackColor = System.Drawing.SystemColors.Highlight;
            appearance75.ForeColor = System.Drawing.Color.White;
            appearance75.TextHAlignAsString = "Center";
            appearance75.TextVAlignAsString = "Middle";
            this.SupplierTotalDay6_Title_Label.Appearance = appearance75;
            this.SupplierTotalDay6_Title_Label.Location = new System.Drawing.Point(195, 295);
            this.SupplierTotalDay6_Title_Label.Name = "SupplierTotalDay6_Title_Label";
            this.SupplierTotalDay6_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay6_Title_Label.TabIndex = 222;
            this.SupplierTotalDay6_Title_Label.Text = "6";
            // 
            // SupplierTotalDay5_Title_Label
            // 
            appearance76.BackColor = System.Drawing.SystemColors.Highlight;
            appearance76.ForeColor = System.Drawing.Color.White;
            appearance76.TextHAlignAsString = "Center";
            appearance76.TextVAlignAsString = "Middle";
            this.SupplierTotalDay5_Title_Label.Appearance = appearance76;
            this.SupplierTotalDay5_Title_Label.Location = new System.Drawing.Point(160, 295);
            this.SupplierTotalDay5_Title_Label.Name = "SupplierTotalDay5_Title_Label";
            this.SupplierTotalDay5_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay5_Title_Label.TabIndex = 221;
            this.SupplierTotalDay5_Title_Label.Text = "5";
            // 
            // SupplierTotalDay2_Title_Label
            // 
            appearance77.BackColor = System.Drawing.SystemColors.Highlight;
            appearance77.ForeColor = System.Drawing.Color.White;
            appearance77.TextHAlignAsString = "Center";
            appearance77.TextVAlignAsString = "Middle";
            this.SupplierTotalDay2_Title_Label.Appearance = appearance77;
            this.SupplierTotalDay2_Title_Label.Location = new System.Drawing.Point(55, 295);
            this.SupplierTotalDay2_Title_Label.Name = "SupplierTotalDay2_Title_Label";
            this.SupplierTotalDay2_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay2_Title_Label.TabIndex = 220;
            this.SupplierTotalDay2_Title_Label.Text = "2";
            // 
            // SupplierTotalDay3_Title_Label
            // 
            appearance80.BackColor = System.Drawing.SystemColors.Highlight;
            appearance80.ForeColor = System.Drawing.Color.White;
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.SupplierTotalDay3_Title_Label.Appearance = appearance80;
            this.SupplierTotalDay3_Title_Label.Location = new System.Drawing.Point(90, 295);
            this.SupplierTotalDay3_Title_Label.Name = "SupplierTotalDay3_Title_Label";
            this.SupplierTotalDay3_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay3_Title_Label.TabIndex = 219;
            this.SupplierTotalDay3_Title_Label.Text = "3";
            // 
            // SupplierTotalDay4_Title_Label
            // 
            appearance81.BackColor = System.Drawing.SystemColors.Highlight;
            appearance81.ForeColor = System.Drawing.Color.White;
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.SupplierTotalDay4_Title_Label.Appearance = appearance81;
            this.SupplierTotalDay4_Title_Label.Location = new System.Drawing.Point(125, 295);
            this.SupplierTotalDay4_Title_Label.Name = "SupplierTotalDay4_Title_Label";
            this.SupplierTotalDay4_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay4_Title_Label.TabIndex = 218;
            this.SupplierTotalDay4_Title_Label.Text = "4";
            // 
            // SupplierTotalDay1_Title_Label
            // 
            appearance82.BackColor = System.Drawing.SystemColors.Highlight;
            appearance82.ForeColor = System.Drawing.Color.White;
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.SupplierTotalDay1_Title_Label.Appearance = appearance82;
            this.SupplierTotalDay1_Title_Label.Location = new System.Drawing.Point(20, 295);
            this.SupplierTotalDay1_Title_Label.Name = "SupplierTotalDay1_Title_Label";
            this.SupplierTotalDay1_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay1_Title_Label.TabIndex = 217;
            this.SupplierTotalDay1_Title_Label.Text = "1";
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // CustomerTotalDay1_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay1_tEdit.ActiveAppearance = appearance12;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.CustomerTotalDay1_tEdit.Appearance = appearance13;
            this.CustomerTotalDay1_tEdit.AutoSelect = true;
            this.CustomerTotalDay1_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay1_tEdit.DataText = "";
            this.CustomerTotalDay1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay1_tEdit.Location = new System.Drawing.Point(20, 239);
            this.CustomerTotalDay1_tEdit.MaxLength = 2;
            this.CustomerTotalDay1_tEdit.Name = "CustomerTotalDay1_tEdit";
            this.CustomerTotalDay1_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay1_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay1_tEdit.TabIndex = 6;
            // 
            // CustomerTotalDay2_tEdit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay2_tEdit.ActiveAppearance = appearance26;
            appearance27.TextHAlignAsString = "Right";
            appearance27.TextVAlignAsString = "Middle";
            this.CustomerTotalDay2_tEdit.Appearance = appearance27;
            this.CustomerTotalDay2_tEdit.AutoSelect = true;
            this.CustomerTotalDay2_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay2_tEdit.DataText = "";
            this.CustomerTotalDay2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay2_tEdit.Location = new System.Drawing.Point(55, 239);
            this.CustomerTotalDay2_tEdit.MaxLength = 2;
            this.CustomerTotalDay2_tEdit.Name = "CustomerTotalDay2_tEdit";
            this.CustomerTotalDay2_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay2_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay2_tEdit.TabIndex = 7;
            // 
            // CustomerTotalDay3_tEdit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay3_tEdit.ActiveAppearance = appearance28;
            appearance29.TextHAlignAsString = "Right";
            appearance29.TextVAlignAsString = "Middle";
            this.CustomerTotalDay3_tEdit.Appearance = appearance29;
            this.CustomerTotalDay3_tEdit.AutoSelect = true;
            this.CustomerTotalDay3_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay3_tEdit.DataText = "";
            this.CustomerTotalDay3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay3_tEdit.Location = new System.Drawing.Point(90, 239);
            this.CustomerTotalDay3_tEdit.MaxLength = 2;
            this.CustomerTotalDay3_tEdit.Name = "CustomerTotalDay3_tEdit";
            this.CustomerTotalDay3_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay3_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay3_tEdit.TabIndex = 8;
            // 
            // CustomerTotalDay7_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay7_tEdit.ActiveAppearance = appearance35;
            appearance36.TextHAlignAsString = "Right";
            appearance36.TextVAlignAsString = "Middle";
            this.CustomerTotalDay7_tEdit.Appearance = appearance36;
            this.CustomerTotalDay7_tEdit.AutoSelect = true;
            this.CustomerTotalDay7_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay7_tEdit.DataText = "";
            this.CustomerTotalDay7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay7_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay7_tEdit.Location = new System.Drawing.Point(230, 239);
            this.CustomerTotalDay7_tEdit.MaxLength = 2;
            this.CustomerTotalDay7_tEdit.Name = "CustomerTotalDay7_tEdit";
            this.CustomerTotalDay7_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay7_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay7_tEdit.TabIndex = 12;
            // 
            // CustomerTotalDay6_tEdit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay6_tEdit.ActiveAppearance = appearance33;
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.CustomerTotalDay6_tEdit.Appearance = appearance34;
            this.CustomerTotalDay6_tEdit.AutoSelect = true;
            this.CustomerTotalDay6_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay6_tEdit.DataText = "";
            this.CustomerTotalDay6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay6_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay6_tEdit.Location = new System.Drawing.Point(195, 239);
            this.CustomerTotalDay6_tEdit.MaxLength = 2;
            this.CustomerTotalDay6_tEdit.Name = "CustomerTotalDay6_tEdit";
            this.CustomerTotalDay6_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay6_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay6_tEdit.TabIndex = 11;
            // 
            // CustomerTotalDay8_tEdit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay8_tEdit.ActiveAppearance = appearance37;
            appearance38.TextHAlignAsString = "Right";
            appearance38.TextVAlignAsString = "Middle";
            this.CustomerTotalDay8_tEdit.Appearance = appearance38;
            this.CustomerTotalDay8_tEdit.AutoSelect = true;
            this.CustomerTotalDay8_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay8_tEdit.DataText = "";
            this.CustomerTotalDay8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay8_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay8_tEdit.Location = new System.Drawing.Point(265, 239);
            this.CustomerTotalDay8_tEdit.MaxLength = 2;
            this.CustomerTotalDay8_tEdit.Name = "CustomerTotalDay8_tEdit";
            this.CustomerTotalDay8_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay8_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay8_tEdit.TabIndex = 13;
            // 
            // CustomerTotalDay9_tEdit
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay9_tEdit.ActiveAppearance = appearance39;
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.CustomerTotalDay9_tEdit.Appearance = appearance40;
            this.CustomerTotalDay9_tEdit.AutoSelect = true;
            this.CustomerTotalDay9_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay9_tEdit.DataText = "";
            this.CustomerTotalDay9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay9_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay9_tEdit.Location = new System.Drawing.Point(300, 239);
            this.CustomerTotalDay9_tEdit.MaxLength = 2;
            this.CustomerTotalDay9_tEdit.Name = "CustomerTotalDay9_tEdit";
            this.CustomerTotalDay9_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay9_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay9_tEdit.TabIndex = 14;
            // 
            // CustomerTotalDay11_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay11_tEdit.ActiveAppearance = appearance10;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.CustomerTotalDay11_tEdit.Appearance = appearance11;
            this.CustomerTotalDay11_tEdit.AutoSelect = true;
            this.CustomerTotalDay11_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay11_tEdit.DataText = "";
            this.CustomerTotalDay11_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay11_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay11_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay11_tEdit.Location = new System.Drawing.Point(370, 239);
            this.CustomerTotalDay11_tEdit.MaxLength = 2;
            this.CustomerTotalDay11_tEdit.Name = "CustomerTotalDay11_tEdit";
            this.CustomerTotalDay11_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay11_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay11_tEdit.TabIndex = 16;
            // 
            // CustomerTotalDay12_tEdit
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay12_tEdit.ActiveAppearance = appearance41;
            appearance42.TextHAlignAsString = "Right";
            appearance42.TextVAlignAsString = "Middle";
            this.CustomerTotalDay12_tEdit.Appearance = appearance42;
            this.CustomerTotalDay12_tEdit.AutoSelect = true;
            this.CustomerTotalDay12_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay12_tEdit.DataText = "";
            this.CustomerTotalDay12_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay12_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay12_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay12_tEdit.Location = new System.Drawing.Point(405, 239);
            this.CustomerTotalDay12_tEdit.MaxLength = 2;
            this.CustomerTotalDay12_tEdit.Name = "CustomerTotalDay12_tEdit";
            this.CustomerTotalDay12_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay12_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay12_tEdit.TabIndex = 17;
            // 
            // CustomerTotalDay5_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay5_tEdit.ActiveAppearance = appearance31;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.CustomerTotalDay5_tEdit.Appearance = appearance32;
            this.CustomerTotalDay5_tEdit.AutoSelect = true;
            this.CustomerTotalDay5_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay5_tEdit.DataText = "";
            this.CustomerTotalDay5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay5_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay5_tEdit.Location = new System.Drawing.Point(160, 239);
            this.CustomerTotalDay5_tEdit.MaxLength = 2;
            this.CustomerTotalDay5_tEdit.Name = "CustomerTotalDay5_tEdit";
            this.CustomerTotalDay5_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay5_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay5_tEdit.TabIndex = 10;
            // 
            // CustomerTotalDay4_tEdit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay4_tEdit.ActiveAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            appearance25.TextVAlignAsString = "Middle";
            this.CustomerTotalDay4_tEdit.Appearance = appearance25;
            this.CustomerTotalDay4_tEdit.AutoSelect = true;
            this.CustomerTotalDay4_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay4_tEdit.DataText = "";
            this.CustomerTotalDay4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay4_tEdit.Location = new System.Drawing.Point(125, 239);
            this.CustomerTotalDay4_tEdit.MaxLength = 2;
            this.CustomerTotalDay4_tEdit.Name = "CustomerTotalDay4_tEdit";
            this.CustomerTotalDay4_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay4_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay4_tEdit.TabIndex = 9;
            // 
            // CustomerTotalDay10_tEdit
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay10_tEdit.ActiveAppearance = appearance43;
            appearance44.TextHAlignAsString = "Right";
            appearance44.TextVAlignAsString = "Middle";
            this.CustomerTotalDay10_tEdit.Appearance = appearance44;
            this.CustomerTotalDay10_tEdit.AutoSelect = true;
            this.CustomerTotalDay10_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay10_tEdit.DataText = "";
            this.CustomerTotalDay10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay10_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay10_tEdit.Location = new System.Drawing.Point(335, 239);
            this.CustomerTotalDay10_tEdit.MaxLength = 2;
            this.CustomerTotalDay10_tEdit.Name = "CustomerTotalDay10_tEdit";
            this.CustomerTotalDay10_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay10_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay10_tEdit.TabIndex = 15;
            // 
            // SupplierTotalDay1_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay1_tEdit.ActiveAppearance = appearance14;
            appearance96.TextHAlignAsString = "Right";
            appearance96.TextVAlignAsString = "Middle";
            this.SupplierTotalDay1_tEdit.Appearance = appearance96;
            this.SupplierTotalDay1_tEdit.AutoSelect = true;
            this.SupplierTotalDay1_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay1_tEdit.DataText = "";
            this.SupplierTotalDay1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay1_tEdit.Location = new System.Drawing.Point(20, 325);
            this.SupplierTotalDay1_tEdit.MaxLength = 2;
            this.SupplierTotalDay1_tEdit.Name = "SupplierTotalDay1_tEdit";
            this.SupplierTotalDay1_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay1_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay1_tEdit.TabIndex = 18;
            // 
            // SupplierTotalDay2_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay2_tEdit.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.SupplierTotalDay2_tEdit.Appearance = appearance16;
            this.SupplierTotalDay2_tEdit.AutoSelect = true;
            this.SupplierTotalDay2_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay2_tEdit.DataText = "";
            this.SupplierTotalDay2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay2_tEdit.Location = new System.Drawing.Point(55, 325);
            this.SupplierTotalDay2_tEdit.MaxLength = 2;
            this.SupplierTotalDay2_tEdit.Name = "SupplierTotalDay2_tEdit";
            this.SupplierTotalDay2_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay2_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay2_tEdit.TabIndex = 19;
            // 
            // SupplierTotalDay3_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay3_tEdit.ActiveAppearance = appearance17;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.SupplierTotalDay3_tEdit.Appearance = appearance18;
            this.SupplierTotalDay3_tEdit.AutoSelect = true;
            this.SupplierTotalDay3_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay3_tEdit.DataText = "";
            this.SupplierTotalDay3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay3_tEdit.Location = new System.Drawing.Point(90, 325);
            this.SupplierTotalDay3_tEdit.MaxLength = 2;
            this.SupplierTotalDay3_tEdit.Name = "SupplierTotalDay3_tEdit";
            this.SupplierTotalDay3_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay3_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay3_tEdit.TabIndex = 20;
            // 
            // SupplierTotalDay4_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay4_tEdit.ActiveAppearance = appearance19;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.SupplierTotalDay4_tEdit.Appearance = appearance20;
            this.SupplierTotalDay4_tEdit.AutoSelect = true;
            this.SupplierTotalDay4_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay4_tEdit.DataText = "";
            this.SupplierTotalDay4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay4_tEdit.Location = new System.Drawing.Point(125, 325);
            this.SupplierTotalDay4_tEdit.MaxLength = 2;
            this.SupplierTotalDay4_tEdit.Name = "SupplierTotalDay4_tEdit";
            this.SupplierTotalDay4_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay4_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay4_tEdit.TabIndex = 21;
            // 
            // SupplierTotalDay5_tEdit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay5_tEdit.ActiveAppearance = appearance21;
            appearance45.TextHAlignAsString = "Right";
            appearance45.TextVAlignAsString = "Middle";
            this.SupplierTotalDay5_tEdit.Appearance = appearance45;
            this.SupplierTotalDay5_tEdit.AutoSelect = true;
            this.SupplierTotalDay5_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay5_tEdit.DataText = "";
            this.SupplierTotalDay5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay5_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay5_tEdit.Location = new System.Drawing.Point(160, 325);
            this.SupplierTotalDay5_tEdit.MaxLength = 2;
            this.SupplierTotalDay5_tEdit.Name = "SupplierTotalDay5_tEdit";
            this.SupplierTotalDay5_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay5_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay5_tEdit.TabIndex = 22;
            // 
            // SupplierTotalDay6_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay6_tEdit.ActiveAppearance = appearance46;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.SupplierTotalDay6_tEdit.Appearance = appearance85;
            this.SupplierTotalDay6_tEdit.AutoSelect = true;
            this.SupplierTotalDay6_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay6_tEdit.DataText = "";
            this.SupplierTotalDay6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay6_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay6_tEdit.Location = new System.Drawing.Point(195, 325);
            this.SupplierTotalDay6_tEdit.MaxLength = 2;
            this.SupplierTotalDay6_tEdit.Name = "SupplierTotalDay6_tEdit";
            this.SupplierTotalDay6_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay6_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay6_tEdit.TabIndex = 23;
            // 
            // SupplierTotalDay7_tEdit
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay7_tEdit.ActiveAppearance = appearance86;
            appearance87.TextHAlignAsString = "Right";
            appearance87.TextVAlignAsString = "Middle";
            this.SupplierTotalDay7_tEdit.Appearance = appearance87;
            this.SupplierTotalDay7_tEdit.AutoSelect = true;
            this.SupplierTotalDay7_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay7_tEdit.DataText = "";
            this.SupplierTotalDay7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay7_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay7_tEdit.Location = new System.Drawing.Point(230, 325);
            this.SupplierTotalDay7_tEdit.MaxLength = 2;
            this.SupplierTotalDay7_tEdit.Name = "SupplierTotalDay7_tEdit";
            this.SupplierTotalDay7_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay7_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay7_tEdit.TabIndex = 24;
            // 
            // SupplierTotalDay8_tEdit
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay8_tEdit.ActiveAppearance = appearance88;
            appearance89.TextHAlignAsString = "Right";
            appearance89.TextVAlignAsString = "Middle";
            this.SupplierTotalDay8_tEdit.Appearance = appearance89;
            this.SupplierTotalDay8_tEdit.AutoSelect = true;
            this.SupplierTotalDay8_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay8_tEdit.DataText = "";
            this.SupplierTotalDay8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay8_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay8_tEdit.Location = new System.Drawing.Point(265, 325);
            this.SupplierTotalDay8_tEdit.MaxLength = 2;
            this.SupplierTotalDay8_tEdit.Name = "SupplierTotalDay8_tEdit";
            this.SupplierTotalDay8_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay8_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay8_tEdit.TabIndex = 25;
            // 
            // SupplierTotalDay9_tEdit
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay9_tEdit.ActiveAppearance = appearance90;
            appearance91.TextHAlignAsString = "Right";
            appearance91.TextVAlignAsString = "Middle";
            this.SupplierTotalDay9_tEdit.Appearance = appearance91;
            this.SupplierTotalDay9_tEdit.AutoSelect = true;
            this.SupplierTotalDay9_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay9_tEdit.DataText = "";
            this.SupplierTotalDay9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay9_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay9_tEdit.Location = new System.Drawing.Point(300, 325);
            this.SupplierTotalDay9_tEdit.MaxLength = 2;
            this.SupplierTotalDay9_tEdit.Name = "SupplierTotalDay9_tEdit";
            this.SupplierTotalDay9_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay9_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay9_tEdit.TabIndex = 26;
            // 
            // SupplierTotalDay10_tEdit
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay10_tEdit.ActiveAppearance = appearance92;
            appearance93.TextHAlignAsString = "Right";
            appearance93.TextVAlignAsString = "Middle";
            this.SupplierTotalDay10_tEdit.Appearance = appearance93;
            this.SupplierTotalDay10_tEdit.AutoSelect = true;
            this.SupplierTotalDay10_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay10_tEdit.DataText = "";
            this.SupplierTotalDay10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay10_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay10_tEdit.Location = new System.Drawing.Point(335, 325);
            this.SupplierTotalDay10_tEdit.MaxLength = 2;
            this.SupplierTotalDay10_tEdit.Name = "SupplierTotalDay10_tEdit";
            this.SupplierTotalDay10_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay10_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay10_tEdit.TabIndex = 27;
            // 
            // SupplierTotalDay11_tEdit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay11_tEdit.ActiveAppearance = appearance94;
            appearance95.TextHAlignAsString = "Right";
            appearance95.TextVAlignAsString = "Middle";
            this.SupplierTotalDay11_tEdit.Appearance = appearance95;
            this.SupplierTotalDay11_tEdit.AutoSelect = true;
            this.SupplierTotalDay11_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay11_tEdit.DataText = "";
            this.SupplierTotalDay11_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay11_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay11_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay11_tEdit.Location = new System.Drawing.Point(370, 325);
            this.SupplierTotalDay11_tEdit.MaxLength = 2;
            this.SupplierTotalDay11_tEdit.Name = "SupplierTotalDay11_tEdit";
            this.SupplierTotalDay11_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay11_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay11_tEdit.TabIndex = 28;
            // 
            // SupplierTotalDay12_tEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay12_tEdit.ActiveAppearance = appearance78;
            appearance79.TextHAlignAsString = "Right";
            appearance79.TextVAlignAsString = "Middle";
            this.SupplierTotalDay12_tEdit.Appearance = appearance79;
            this.SupplierTotalDay12_tEdit.AutoSelect = true;
            this.SupplierTotalDay12_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay12_tEdit.DataText = "";
            this.SupplierTotalDay12_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay12_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay12_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay12_tEdit.Location = new System.Drawing.Point(405, 325);
            this.SupplierTotalDay12_tEdit.MaxLength = 2;
            this.SupplierTotalDay12_tEdit.Name = "SupplierTotalDay12_tEdit";
            this.SupplierTotalDay12_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay12_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay12_tEdit.TabIndex = 29;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // CollectPlnDiv_Title_Label
            // 
            this.CollectPlnDiv_Title_Label.Location = new System.Drawing.Point(21, 144);
            this.CollectPlnDiv_Title_Label.Name = "CollectPlnDiv_Title_Label";
            this.CollectPlnDiv_Title_Label.Size = new System.Drawing.Size(100, 23);
            this.CollectPlnDiv_Title_Label.TabIndex = 229;
            this.CollectPlnDiv_Title_Label.Text = "回収予定区分";
            // 
            // CollectPlnDiv_tComboEditor
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectPlnDiv_tComboEditor.ActiveAppearance = appearance3;
            this.CollectPlnDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CollectPlnDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectPlnDiv_tComboEditor.ItemAppearance = appearance4;
            this.CollectPlnDiv_tComboEditor.Location = new System.Drawing.Point(195, 144);
            this.CollectPlnDiv_tComboEditor.Name = "CollectPlnDiv_tComboEditor";
            this.CollectPlnDiv_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.CollectPlnDiv_tComboEditor.TabIndex = 5;
            // 
            // SFUKK09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(469, 443);
            this.Controls.Add(this.CollectPlnDiv_tComboEditor);
            this.Controls.Add(this.CollectPlnDiv_Title_Label);
            this.Controls.Add(this.SupplierTotalDay12_tEdit);
            this.Controls.Add(this.SupplierTotalDay11_tEdit);
            this.Controls.Add(this.SupplierTotalDay10_tEdit);
            this.Controls.Add(this.SupplierTotalDay9_tEdit);
            this.Controls.Add(this.SupplierTotalDay8_tEdit);
            this.Controls.Add(this.SupplierTotalDay7_tEdit);
            this.Controls.Add(this.SupplierTotalDay6_tEdit);
            this.Controls.Add(this.SupplierTotalDay5_tEdit);
            this.Controls.Add(this.SupplierTotalDay4_tEdit);
            this.Controls.Add(this.SupplierTotalDay3_tEdit);
            this.Controls.Add(this.SupplierTotalDay2_tEdit);
            this.Controls.Add(this.SupplierTotalDay1_tEdit);
            this.Controls.Add(this.CustomerTotalDay10_tEdit);
            this.Controls.Add(this.CustomerTotalDay4_tEdit);
            this.Controls.Add(this.CustomerTotalDay5_tEdit);
            this.Controls.Add(this.CustomerTotalDay12_tEdit);
            this.Controls.Add(this.CustomerTotalDay11_tEdit);
            this.Controls.Add(this.CustomerTotalDay9_tEdit);
            this.Controls.Add(this.CustomerTotalDay8_tEdit);
            this.Controls.Add(this.CustomerTotalDay6_tEdit);
            this.Controls.Add(this.CustomerTotalDay7_tEdit);
            this.Controls.Add(this.CustomerTotalDay3_tEdit);
            this.Controls.Add(this.CustomerTotalDay2_tEdit);
            this.Controls.Add(this.CustomerTotalDay1_tEdit);
            this.Controls.Add(this.SupplierTotalDay12_Title_Label);
            this.Controls.Add(this.SupplierTotalDay11_Title_Label);
            this.Controls.Add(this.SupplierTotalDay8_Title_Label);
            this.Controls.Add(this.SupplierTotalDay9_Title_Label);
            this.Controls.Add(this.SupplierTotalDay10_Title_Label);
            this.Controls.Add(this.SupplierTotalDay7_Title_Label);
            this.Controls.Add(this.SupplierTotalDay6_Title_Label);
            this.Controls.Add(this.SupplierTotalDay5_Title_Label);
            this.Controls.Add(this.SupplierTotalDay2_Title_Label);
            this.Controls.Add(this.SupplierTotalDay3_Title_Label);
            this.Controls.Add(this.SupplierTotalDay4_Title_Label);
            this.Controls.Add(this.SupplierTotalDay1_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SupplierTotalDay_Title_Label);
            this.Controls.Add(this.CustomerTotalDay12_Title_Label);
            this.Controls.Add(this.CustomerTotalDay11_Title_Label);
            this.Controls.Add(this.CustomerTotalDay8_Title_Label);
            this.Controls.Add(this.CustomerTotalDay9_Title_Label);
            this.Controls.Add(this.CustomerTotalDay10_Title_Label);
            this.Controls.Add(this.CustomerTotalDay7_Title_Label);
            this.Controls.Add(this.CustomerTotalDay6_Title_Label);
            this.Controls.Add(this.CustomerTotalDay5_Title_Label);
            this.Controls.Add(this.CustomerTotalDay2_Title_Label);
            this.Controls.Add(this.CustomerTotalDay3_Title_Label);
            this.Controls.Add(this.CustomerTotalDay4_Title_Label);
            this.Controls.Add(this.CustomerTotalDay1_Title_Label);
            this.Controls.Add(this.CustomerTotalDay_Title_Label);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.DepositSlipMntCd_tComboEditor);
            this.Controls.Add(this.DepositSlipMntCd_Title_Label);
            this.Controls.Add(this.AllowanceProcCd_tComboEditor);
            this.Controls.Add(this.AllowanceProcCd_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09100UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "請求全体設定";
            this.Load += new System.EventHandler(this.SFUKK09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09100UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceProcCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipMntCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay7_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay11_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay12_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay7_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay11_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay12_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectPlnDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
           --- DEL 2008/06/13 --------------------------------<<<<< */

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members

		private BillAllSt _billAllSt;
        private BillAllStAcs _billAllStAcs;
		private string _enterPriseCode;

		// プロパティ用
		private bool _canPrint;
        // --- ADD 2008/06/13 -------------------------------->>>>>
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        private SecInfoAcs _secInfoAcs;  // 拠点マスタアクセスクラス

        // 未設定時に使用
        private const string UNREGISTER = "";

        private int _logicalDeleteMode;				// モード
        // --- ADD 2008/06/13 --------------------------------<<<<< 
        private bool isError = false; // ADD 2011/09/07

		/// <summary>
		/// 終了プロパティ
		/// </summary>
		/// <remarks>
		/// アセンブリを終了するか、しないかを取得又はセットします。
		/// </remarks>
		private bool _canClose;

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // --- ADD 2008/06/13 -------------------------------->>>>>
        private Hashtable _billAllStTable;	 // 請求全体設定テーブル

        private const string GUID_TITLE = "GUID";
        private const string BILLALLST_TABLE = "BILLALLST"; // テーブル名

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE       = "削除日";
        // DEL 2008/10/09 不具合対応[6444] ---------->>>>>
        //private const string SECTIONCODE_TITLE = "コード";        
        //private const string SECTIONNAME_TITLE = "拠点名称";
        // DEL 2008/10/09 不具合対応[6444] ----------<<<<<
        // ADD 2008/10/09 不具合対応[6444] ---------->>>>>
        private const string SECTIONCODE_TITLE = "拠点コード";   
        private const string SECTIONNAME_TITLE = "拠点名";
        // ADD 2008/10/09 不具合対応[6444] ----------<<<<<

        private const string CUSTOMERTOTALDAY01_TITLE = "処理対象締日１（得意先）";
        private const string CUSTOMERTOTALDAY02_TITLE = "処理対象締日２（得意先）";
        private const string CUSTOMERTOTALDAY03_TITLE = "処理対象締日３（得意先）";
        private const string CUSTOMERTOTALDAY04_TITLE = "処理対象締日４（得意先）";
        private const string CUSTOMERTOTALDAY05_TITLE = "処理対象締日５（得意先）";
        private const string CUSTOMERTOTALDAY06_TITLE = "処理対象締日６（得意先）";
        private const string CUSTOMERTOTALDAY07_TITLE = "処理対象締日７（得意先）";
        private const string CUSTOMERTOTALDAY08_TITLE = "処理対象締日８（得意先）";
        private const string CUSTOMERTOTALDAY09_TITLE = "処理対象締日９（得意先）";
        private const string CUSTOMERTOTALDAY10_TITLE = "処理対象締日１０（得意先）";
        private const string CUSTOMERTOTALDAY11_TITLE = "処理対象締日１１（得意先）";
        private const string CUSTOMERTOTALDAY12_TITLE = "処理対象締日１２（得意先）";

        private const string SUPPLIERTOTALDAY01_TITLE = "処理対象締日１（仕入先）";
        private const string SUPPLIERTOTALDAY02_TITLE = "処理対象締日２（仕入先）";
        private const string SUPPLIERTOTALDAY03_TITLE = "処理対象締日３（仕入先）";
        private const string SUPPLIERTOTALDAY04_TITLE = "処理対象締日４（仕入先）";
        private const string SUPPLIERTOTALDAY05_TITLE = "処理対象締日５（仕入先）";
        private const string SUPPLIERTOTALDAY06_TITLE = "処理対象締日６（仕入先）";
        private const string SUPPLIERTOTALDAY07_TITLE = "処理対象締日７（仕入先）";
        private const string SUPPLIERTOTALDAY08_TITLE = "処理対象締日８（仕入先）";
        private const string SUPPLIERTOTALDAY09_TITLE = "処理対象締日９（仕入先）";
        private const string SUPPLIERTOTALDAY10_TITLE = "処理対象締日１０（仕入先）";
        private const string SUPPLIERTOTALDAY11_TITLE = "処理対象締日１１（仕入先）";
        private const string SUPPLIERTOTALDAY12_TITLE = "処理対象締日１２（仕入先）";

        private const string TOTALDAY_NGMSG_BETWEEN     = "1から順に間が空かないように設定して下さい。";
        private const string TOTALDAY_NGMSG_REPEAT      = "日付が重複しないように設定して下さい。";
        private const string TOTALDAY_NGMSG_DAYS        = "1～31の範囲で指定して下さい。";
        private const string TOTALDAY_NGMSG_SMALL       = "左側の設定値よりも大きい値を設定して下さい。";
        // --- ADD 2008/06/13 --------------------------------<<<<< 

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		private const string HTML_HEADER_TITLE    = "設定項目";
		private const string HTML_HEADER_VALUE    = "設定値";
	    private const string HTML_UNREGISTER      = "";
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
        // 編集モード
		private const string INSERT_MODE          = "新規モード";
		private const string UPDATE_MODE          = "更新モード";
		private const string DELETE_MODE          = "削除モード";

        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //// 消費税端数処理区分
        //private const string MINUSVARCSTBL_NON    = "調整しない";
        //private const string MINUSVARCSTBL_1CUT   = "諸費用がマイナス時に諸費用残を０にする";
        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

        // 引当処理区分
		private const string ALLOWANCEPROC_OK     = "両方";
		private const string ALLOWANCEPROC_NG     = "必須";
		private const string ALLOWANCEPROC_REFER  = "不可";

        // 入金伝票修正区分
		private const string DEPOSITSLIP_NONREFER = "修正可";
		private const string DEPOSITSLIP_REFER    = "修正不可";

        //回収予定区分
        private const string COLLECTPLNDIV_DIV = "区分";
        private const string COLLECTPLNDIV_DAY  = "日付";



        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//        // 前受金算定区分
//        private const string BFRMONCALC_ALL       = "預り金入力分のみ前受金とする";
//        private const string BFRMONCALC_DIVIDE    = "通常入金を今回入金と前受金に振り分ける";
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

		// 変更有無判定用
	    //private BillAllSt chkBillAllSet;
        private BillAllSt _billAllStClone;

		//2005.09.17 enokida ADD MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
		string pgId = "SFUKK09100U";
        string pgNm = "請求全体設定";
		//string obj = "BillAllStAcs";  // DEL 2008/06/16
		//2005.09.17 enokida ADD MessageBox対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

        // ADD 2008/09/16 不具合対応[5257] ---------->>>>>
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
        // ADD 2008/09/16 不具合対応[5257] ----------<<<<<

		#endregion

		# region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09100UA());
		}
		# endregion

		# region Properties
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

        // --- ADD 2008/06/13 -------------------------------->>>>>
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

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }
        // --- ADD 2008/06/13 --------------------------------<<<<< 

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
		/// <br>Note	   :（未実装）</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = BILLALLST_TABLE;
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
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchBillAllSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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

            // 引当処理区分
            appearanceTable.Add(AllowanceProcCd_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 入金伝票修正区分
            appearanceTable.Add(DepositSlipMntCd_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            //回収予定区分
            appearanceTable.Add(CollectPlnDiv_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 得意先締日１
            appearanceTable.Add(CUSTOMERTOTALDAY01_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日２
            appearanceTable.Add(CUSTOMERTOTALDAY02_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日３
            appearanceTable.Add(CUSTOMERTOTALDAY03_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日４
            appearanceTable.Add(CUSTOMERTOTALDAY04_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日５
            appearanceTable.Add(CUSTOMERTOTALDAY05_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日６
            appearanceTable.Add(CUSTOMERTOTALDAY06_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日７
            appearanceTable.Add(CUSTOMERTOTALDAY07_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日８
            appearanceTable.Add(CUSTOMERTOTALDAY08_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日９
            appearanceTable.Add(CUSTOMERTOTALDAY09_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日１０
            appearanceTable.Add(CUSTOMERTOTALDAY10_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日１１
            appearanceTable.Add(CUSTOMERTOTALDAY11_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 得意先締日１２
            appearanceTable.Add(CUSTOMERTOTALDAY12_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日１
            appearanceTable.Add(SUPPLIERTOTALDAY01_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日２
            appearanceTable.Add(SUPPLIERTOTALDAY02_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日３
            appearanceTable.Add(SUPPLIERTOTALDAY03_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日４
            appearanceTable.Add(SUPPLIERTOTALDAY04_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日５
            appearanceTable.Add(SUPPLIERTOTALDAY05_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日６
            appearanceTable.Add(SUPPLIERTOTALDAY06_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日７
            appearanceTable.Add(SUPPLIERTOTALDAY07_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日８
            appearanceTable.Add(SUPPLIERTOTALDAY08_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日９
            appearanceTable.Add(SUPPLIERTOTALDAY09_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日１０
            appearanceTable.Add(SUPPLIERTOTALDAY10_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日１１
            appearanceTable.Add(SUPPLIERTOTALDAY11_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // 仕入先締日１２
            appearanceTable.Add(SUPPLIERTOTALDAY12_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>
		///	HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note	   : ビュー用のＨＴＭＬコードを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

            // tHtmlGenerate部品の引数を生成する
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            string[,] array = new string[3, 2];
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            string [,] array = new string[5,2];
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
// 2006.06.01 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//string [,] array = new string[4,2];
// 2006.06.01 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
			this.tHtmlGenerate1.Coltypes = new int[2];
			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
			
			array[0,0] = HTML_HEADER_TITLE;                              //「設定項目」
			array[0,1] = HTML_HEADER_VALUE;                              //「設定値」
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			array[1,0] = this.AllowanceProcCd_Title_Label.Text;          // 引当処理区分
            array[2,0] = this.DepositSlipMntCd_Title_Label.Text;         // 入金伝票修正区分
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            array[1,0] = this.MinusVarCstBlAdjstCd_Title_Label.Text;     // マイナス諸費用残高調整区分
//            array[2,0] = this.AllowanceProcCd_Title_Label.Text;          // 引当処理区分
//            array[3,0] = this.DepositSlipMntCd_Title_Label.Text;         // 入金伝票修正区分
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            array[4,0] = this.BfRmonCalcDivCd_Title_Label.Text;          // 前受金算定区分
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

            int status = this._billAllStAcs.Read(out this._billAllSt, this._enterPriseCode);
			if (status == 0)
            {
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				switch(this._billAllSt.AllowanceProcCd)
				{	
					case 0:
						array[1,1] = ALLOWANCEPROC_OK;        //"両方"
						break;
					case 1:
						array[1,1] = ALLOWANCEPROC_NG;        //"必須"
						break;
					case 2:
						array[1,1] = ALLOWANCEPROC_REFER;     //"不可"
						break;
					default:
						array[1,1] = HTML_UNREGISTER;
						break;
				}
                switch(this._billAllSt.DepositSlipMntCd)
				{
					case 0:
						array[2,1] = DEPOSITSLIP_NONREFER;    //"修正可"
						break;
					case 1:
						array[2,1] = DEPOSITSLIP_REFER;       //"修正不可"
						break;
					default:
						array[2,1] = HTML_UNREGISTER;
						break;
                }
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                switch(billAllSet.MinusVarCstBlAdjstCd)
//                {
//                    case 0:
//                        array[1,1] = MINUSVARCSTBL_NON;       // "調整しない"
//                        break;
//                    case 1:
//                        array[1,1] = MINUSVARCSTBL_1CUT;      //"諸費用残がﾏｲﾅｽ時に諸費用残を0にする"
//                        break;
//                    default:
//                        array[1,1] = HTML_UNREGISTER;
//                        break;

//                }
//                switch(billAllSet.AllowanceProcCd)
//                {	
//                    case 0:
//                        array[2,1] = ALLOWANCEPROC_OK;        //"両方"
//                        break;
//                    case 1:
//                        array[2,1] = ALLOWANCEPROC_NG;        //"必須"
//                        break;
//                    case 2:
//                        array[2,1] = ALLOWANCEPROC_REFER;     //"不可"
//                        break;
//                    default:
//                        array[2,1] = HTML_UNREGISTER;
//                        break;
//                }
//                switch(billAllSet.DepositSlipMntCd)
//                {
//                    case 0:
//                        array[3,1] = DEPOSITSLIP_NONREFER;    //"修正可"
//                        break;
//                    case 1:
//                        array[3,1] = DEPOSITSLIP_REFER;       //"修正不可"
//                        break;
//                    default:
//                        array[3,1] = HTML_UNREGISTER;
//                        break;
//                }
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                switch( billAllSet.BfRmonCalcDivCd ) {
//                    case 0:
//                    {
//                        array[ 4, 1 ] = BFRMONCALC_ALL;     // 預り金は全て前受金とする
//                        break;
//                    }
//                    case 1:
//                    {
//                        array[ 4, 1 ] = BFRMONCALC_DIVIDE;  // 自動的に今回入金と前受金に振り分ける
//                        break;
//                    }
//                    default:
//                    {
//                        array[ 4, 1 ] = HTML_UNREGISTER;
//                        break;
//                    }
//                }
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}
			else
			{
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				array[1,1] = HTML_UNREGISTER;
                array[2,1] = HTML_UNREGISTER;
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                array[1,1] = HTML_UNREGISTER;
//                array[2,1] = HTML_UNREGISTER;
//                array[3,1] = HTML_UNREGISTER;
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                array[ 4, 1 ] = HTML_UNREGISTER;
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}

			// データの２次元配列のみを指定して、プロパティを使用してグリッド表示する
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);
			return outCode;
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */
        # endregion

        # region private Methods

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable billAllStTable = new DataTable(BILLALLST_TABLE);
            billAllStTable.Columns.Add(DELETE_DATE, typeof(string));

            billAllStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            billAllStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));
            billAllStTable.Columns.Add(AllowanceProcCd_Title_Label.Text, typeof(string));   // 引当処理区分
            billAllStTable.Columns.Add(DepositSlipMntCd_Title_Label.Text, typeof(string));  // 入金伝票修正区分
            billAllStTable.Columns.Add(CollectPlnDiv_Title_Label.Text, typeof(string));  // 回収予定区分

            billAllStTable.Columns.Add(CUSTOMERTOTALDAY01_TITLE, typeof(string));   // 得意先締日１
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY02_TITLE, typeof(string));   // 得意先締日２
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY03_TITLE, typeof(string));   // 得意先締日３
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY04_TITLE, typeof(string));   // 得意先締日４
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY05_TITLE, typeof(string));   // 得意先締日５
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY06_TITLE, typeof(string));   // 得意先締日６
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY07_TITLE, typeof(string));   // 得意先締日７
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY08_TITLE, typeof(string));   // 得意先締日８
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY09_TITLE, typeof(string));   // 得意先締日９
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY10_TITLE, typeof(string));   // 得意先締日１０
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY11_TITLE, typeof(string));   // 得意先締日１１
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY12_TITLE, typeof(string));   // 得意先締日１２

            billAllStTable.Columns.Add(SUPPLIERTOTALDAY01_TITLE, typeof(string));   // 仕入先締日１
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY02_TITLE, typeof(string));   // 仕入先締日２
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY03_TITLE, typeof(string));   // 仕入先締日３
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY04_TITLE, typeof(string));   // 仕入先締日４
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY05_TITLE, typeof(string));   // 仕入先締日５
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY06_TITLE, typeof(string));   // 仕入先締日６
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY07_TITLE, typeof(string));   // 仕入先締日７
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY08_TITLE, typeof(string));   // 仕入先締日８
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY09_TITLE, typeof(string));   // 仕入先締日９
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY10_TITLE, typeof(string));   // 仕入先締日１０
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY11_TITLE, typeof(string));   // 仕入先締日１１
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY12_TITLE, typeof(string));   // 仕入先締日１２

            billAllStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(billAllStTable);
        }

        /// <summary>
		///	画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note	　 : 画面の初期設定を行います(ｺﾝﾎﾞﾎﾞｯｸｽに固定値ADD)</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
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

            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            ////マイナス諸費用残高調整区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Clear();                    
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Add(0,MINUSVARCSTBL_NON);    //調整しない
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Add(1,MINUSVARCSTBL_1CUT);   //諸費用残がﾏｲﾅｽ時に諸費用残を0にする

            //MinusVarCstBlAdjstCd_tComboEditor.MaxDropDownItems = MinusVarCstBlAdjstCd_tComboEditor.Items.Count;
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			
			//引当処理区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
			AllowanceProcCd_tComboEditor.Items.Clear();
			AllowanceProcCd_tComboEditor.Items.Add(0,ALLOWANCEPROC_OK);          //両方
			AllowanceProcCd_tComboEditor.Items.Add(1,ALLOWANCEPROC_NG);          //必須
			AllowanceProcCd_tComboEditor.Items.Add(2,ALLOWANCEPROC_REFER);       //不可
			AllowanceProcCd_tComboEditor.MaxDropDownItems = AllowanceProcCd_tComboEditor.Items.Count;
			
			//入金伝票修正区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
			DepositSlipMntCd_tComboEditor.Items.Clear();
			DepositSlipMntCd_tComboEditor.Items.Add(0,DEPOSITSLIP_NONREFER);     //修正可
			DepositSlipMntCd_tComboEditor.Items.Add(1,DEPOSITSLIP_REFER);        //修正不可
			DepositSlipMntCd_tComboEditor.MaxDropDownItems = DepositSlipMntCd_tComboEditor.Items.Count;

            //回収予定区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            CollectPlnDiv_tComboEditor.Items.Clear();
            CollectPlnDiv_tComboEditor.Items.Add(0, COLLECTPLNDIV_DIV);     //区分
            CollectPlnDiv_tComboEditor.Items.Add(1, COLLECTPLNDIV_DAY);        //日付
            CollectPlnDiv_tComboEditor.MaxDropDownItems = CollectPlnDiv_tComboEditor.Items.Count;

            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            this.BfRmonCalcDivCd_tComboEditor.Items.Clear();
//            this.BfRmonCalcDivCd_tComboEditor.Items.Add( 0, BFRMONCALC_ALL );    // 預り金は全て前受金とする
//            this.BfRmonCalcDivCd_tComboEditor.Items.Add( 1, BFRMONCALC_DIVIDE ); // 自動的に今回入金と前受金に振り分ける
//            this.BfRmonCalcDivCd_tComboEditor.MaxDropDownItems = this.BfRmonCalcDivCd_tComboEditor.Items.Count;
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		}
	
		/// <summary>
		///	画面情報⇒請求全体設定設定クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面情報から請求全体設定クラスにデータを
		///					 格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
        private void ScreenToBillAllSt(ref BillAllSt billAllSt)
		{
            if (billAllSt == null)
            {
                billAllSt = new BillAllSt();
            }

            billAllSt.EnterpriseCode = this._enterPriseCode;			                 // 企業コード
            billAllSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.Trim();     // 拠点コード
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                billAllSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<

            billAllSt.AllowanceProcCd  = (int)this.AllowanceProcCd_tComboEditor.Value;   // 引当処理区分
            billAllSt.DepositSlipMntCd = (int)this.DepositSlipMntCd_tComboEditor.Value;  // 入金伝票修正区分
            billAllSt.CollectPlnDiv = (int)this.CollectPlnDiv_tComboEditor.Value;  　　　// 回収予定区分
            
            // 得意先締日１
            if(this.CustomerTotalDay1_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay1 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay1 = Int32.Parse(this.CustomerTotalDay1_tEdit.DataText);    
            }

            // 得意先締日２
            if (this.CustomerTotalDay2_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay2 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay2 = Int32.Parse(this.CustomerTotalDay2_tEdit.DataText);    
            }

            // 得意先締日３
            if (this.CustomerTotalDay3_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay3 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay3 = Int32.Parse(this.CustomerTotalDay3_tEdit.DataText);    
            }

            // 得意先締日４
            if (this.CustomerTotalDay4_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay4 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay4 = Int32.Parse(this.CustomerTotalDay4_tEdit.DataText);    
            }

            // 得意先締日５
            if (this.CustomerTotalDay5_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay5 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay5 = Int32.Parse(this.CustomerTotalDay5_tEdit.DataText);    
            }

            // 得意先締日６
            if (this.CustomerTotalDay6_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay6 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay6 = Int32.Parse(this.CustomerTotalDay6_tEdit.DataText);    
            }

            // 得意先締日７
            if (this.CustomerTotalDay7_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay7 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay7 = Int32.Parse(this.CustomerTotalDay7_tEdit.DataText);   
            }

            // 得意先締日８
            if (this.CustomerTotalDay8_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay8 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay8 = Int32.Parse(this.CustomerTotalDay8_tEdit.DataText);    
            }

            // 得意先締日９
            if (this.CustomerTotalDay9_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay9 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay9 = Int32.Parse(this.CustomerTotalDay9_tEdit.DataText);    
            }

            // 得意先締日１０
            if (this.CustomerTotalDay10_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay10 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay10 = Int32.Parse(this.CustomerTotalDay10_tEdit.DataText);  
            }

            // 得意先締日１１
            if (this.CustomerTotalDay11_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay11 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay11 = Int32.Parse(this.CustomerTotalDay11_tEdit.DataText);  
            }

            // 得意先締日１２
            if (this.CustomerTotalDay12_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay12 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay12 = Int32.Parse(this.CustomerTotalDay12_tEdit.DataText);  
            }

            // 仕入先締日１
            if (this.SupplierTotalDay1_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay1 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay1 = Int32.Parse(this.SupplierTotalDay1_tEdit.DataText);    
            }

            // 仕入先締日２
            if (this.SupplierTotalDay2_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay2 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay2 = Int32.Parse(this.SupplierTotalDay2_tEdit.DataText);    
            }

            // 仕入先締日３
            if (this.SupplierTotalDay3_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay3 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay3 = Int32.Parse(this.SupplierTotalDay3_tEdit.DataText);    
            }

            // 仕入先締日４
            if (this.SupplierTotalDay4_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay4 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay4 = Int32.Parse(this.SupplierTotalDay4_tEdit.DataText);    
            }

            // 仕入先締日５
            if (this.SupplierTotalDay5_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay5 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay5 = Int32.Parse(this.SupplierTotalDay5_tEdit.DataText);    
            }

            // 仕入先締日６
            if (this.SupplierTotalDay6_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay6 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay6 = Int32.Parse(this.SupplierTotalDay6_tEdit.DataText);    
            }

            // 仕入先締日７
            if (this.SupplierTotalDay7_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay7 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay7 = Int32.Parse(this.SupplierTotalDay7_tEdit.DataText);    
            }

            // 仕入先締日８
            if (this.SupplierTotalDay8_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay8 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay8 = Int32.Parse(this.SupplierTotalDay8_tEdit.DataText);    
            }

            // 仕入先締日９
            if (this.SupplierTotalDay9_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay9 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay9 = Int32.Parse(this.SupplierTotalDay9_tEdit.DataText);    
            }

            // 仕入先締日１０
            if (this.SupplierTotalDay10_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay10 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay10 = Int32.Parse(this.SupplierTotalDay10_tEdit.DataText);  
            }

            // 仕入先締日１１
            if (this.SupplierTotalDay11_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay11 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay11 = Int32.Parse(this.SupplierTotalDay11_tEdit.DataText);  
            }

            // 仕入先締日１２
            if (this.SupplierTotalDay12_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay12 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay12 = Int32.Parse(this.SupplierTotalDay12_tEdit.DataText);  
            }

		}

		/// <summary>
		///	請求全体設定画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 請求全体設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
        private void BillAllStToScreen(BillAllSt billAllSt)
		{
            this.tEdit_SectionCodeAllowZero2.Value = billAllSt.SectionCode;  // 拠点コード
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == billAllSt.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/10 不具合対応[6445] ---------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("00"))
            {
                this.SectionNm_tEdit.Text = "全社共通";
            }
            // ADD 2008/10/10 不具合対応[6445] ----------<<<<<

            this.AllowanceProcCd_tComboEditor.Value = billAllSt.AllowanceProcCd;               // 引当処理区分
            this.DepositSlipMntCd_tComboEditor.Value = billAllSt.DepositSlipMntCd;             // 入金伝票修正区分
            this.CollectPlnDiv_tComboEditor.Value = billAllSt.CollectPlnDiv;        　　　　   // 回収予定区分
            this.CustomerTotalDay1_tEdit.DataText = billAllSt.CustomerTotalDay1.ToString();    // 得意先締日１
            this.CustomerTotalDay2_tEdit.DataText = billAllSt.CustomerTotalDay2.ToString();    // 得意先締日２
            this.CustomerTotalDay3_tEdit.DataText = billAllSt.CustomerTotalDay3.ToString();    // 得意先締日３
            this.CustomerTotalDay4_tEdit.DataText = billAllSt.CustomerTotalDay4.ToString();    // 得意先締日４
            this.CustomerTotalDay5_tEdit.DataText = billAllSt.CustomerTotalDay5.ToString();    // 得意先締日５
            this.CustomerTotalDay6_tEdit.DataText = billAllSt.CustomerTotalDay6.ToString();    // 得意先締日６
            this.CustomerTotalDay7_tEdit.DataText = billAllSt.CustomerTotalDay7.ToString();    // 得意先締日７
            this.CustomerTotalDay8_tEdit.DataText = billAllSt.CustomerTotalDay8.ToString();    // 得意先締日８
            this.CustomerTotalDay9_tEdit.DataText = billAllSt.CustomerTotalDay9.ToString();    // 得意先締日９
            this.CustomerTotalDay10_tEdit.DataText = billAllSt.CustomerTotalDay10.ToString();  // 得意先締日１０
            this.CustomerTotalDay11_tEdit.DataText = billAllSt.CustomerTotalDay11.ToString();  // 得意先締日１１
            this.CustomerTotalDay12_tEdit.DataText = billAllSt.CustomerTotalDay12.ToString();  // 得意先締日１２
            this.SupplierTotalDay1_tEdit.DataText = billAllSt.SupplierTotalDay1.ToString();    // 仕入先締日１
            this.SupplierTotalDay2_tEdit.DataText = billAllSt.SupplierTotalDay2.ToString();    // 仕入先締日２
            this.SupplierTotalDay3_tEdit.DataText = billAllSt.SupplierTotalDay3.ToString();    // 仕入先締日３
            this.SupplierTotalDay4_tEdit.DataText = billAllSt.SupplierTotalDay4.ToString();    // 仕入先締日４
            this.SupplierTotalDay5_tEdit.DataText = billAllSt.SupplierTotalDay5.ToString();    // 仕入先締日５
            this.SupplierTotalDay6_tEdit.DataText = billAllSt.SupplierTotalDay6.ToString();    // 仕入先締日６
            this.SupplierTotalDay7_tEdit.DataText = billAllSt.SupplierTotalDay7.ToString();    // 仕入先締日７
            this.SupplierTotalDay8_tEdit.DataText = billAllSt.SupplierTotalDay8.ToString();    // 仕入先締日８
            this.SupplierTotalDay9_tEdit.DataText = billAllSt.SupplierTotalDay9.ToString();    // 仕入先締日９
            this.SupplierTotalDay10_tEdit.DataText = billAllSt.SupplierTotalDay10.ToString();  // 仕入先締日１０
            this.SupplierTotalDay11_tEdit.DataText = billAllSt.SupplierTotalDay11.ToString();  // 仕入先締日１１
            this.SupplierTotalDay12_tEdit.DataText = billAllSt.SupplierTotalDay12.ToString();  // 仕入先締日１２
		}
		
		/// <summary>
		///	請求全体設定画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面情報を初期化します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void ScreenClear()
        {
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //this.MinusVarCstBlAdjstCd_tComboEditor.Value = 0;
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			this.AllowanceProcCd_tComboEditor.SelectedIndex = 0;
			this.DepositSlipMntCd_tComboEditor.SelectedIndex = 0;
            this.CollectPlnDiv_tComboEditor.SelectedIndex = 0;


            // --- ADD 2008/06/13 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();     // 拠点コード
            this.SectionNm_tEdit.Clear();                // 拠点ガイド名称

            this.CustomerTotalDay1_tEdit.Clear();        // 得意先締日１
            this.CustomerTotalDay2_tEdit.Clear();        // 得意先締日２
            this.CustomerTotalDay3_tEdit.Clear();        // 得意先締日３
            this.CustomerTotalDay4_tEdit.Clear();        // 得意先締日４
            this.CustomerTotalDay5_tEdit.Clear();        // 得意先締日５
            this.CustomerTotalDay6_tEdit.Clear();        // 得意先締日６
            this.CustomerTotalDay7_tEdit.Clear();        // 得意先締日７
            this.CustomerTotalDay8_tEdit.Clear();        // 得意先締日８
            this.CustomerTotalDay9_tEdit.Clear();        // 得意先締日９
            this.CustomerTotalDay10_tEdit.Clear();       // 得意先締日１０
            this.CustomerTotalDay11_tEdit.Clear();       // 得意先締日１１
            this.CustomerTotalDay12_tEdit.Clear();       // 得意先締日１２

            this.SupplierTotalDay1_tEdit.Clear();        // 仕入先締日１
            this.SupplierTotalDay2_tEdit.Clear();        // 仕入先締日２
            this.SupplierTotalDay3_tEdit.Clear();        // 仕入先締日３
            this.SupplierTotalDay4_tEdit.Clear();        // 仕入先締日４
            this.SupplierTotalDay5_tEdit.Clear();        // 仕入先締日５
            this.SupplierTotalDay6_tEdit.Clear();        // 仕入先締日６
            this.SupplierTotalDay7_tEdit.Clear();        // 仕入先締日７
            this.SupplierTotalDay8_tEdit.Clear();        // 仕入先締日８
            this.SupplierTotalDay9_tEdit.Clear();        // 仕入先締日９
            this.SupplierTotalDay10_tEdit.Clear();       // 仕入先締日１０
            this.SupplierTotalDay11_tEdit.Clear();       // 仕入先締日１１
            this.SupplierTotalDay12_tEdit.Clear();       // 仕入先締日１２
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            /* --- DEL 2008/06/13 -------------------------------->>>>>
            int status = this._billAllStAcs.Read(out this._billAllSt, this._enterPriseCode);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;
				// 全体初期表示設定クラス画面展開処理
				billAllSetToScreen();

                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                AllowanceProcCd_tComboEditor.Focus();
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //MinusVarCstBlAdjstCd_tComboEditor.Focus();
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}
			else
			{
				Mode_Label.Text = INSERT_MODE;
			}   
			//画面に表示した情報を一旦データクラスにセット
			ScreenTobillAllSet();
			//読み出したデータのクローン作成
            this._billAllStClone = this._billAllSt.Clone();

			return;
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                BillAllSt newBillAllSt = new BillAllSt();

                // 請求全体設定オブジェクトを画面に展開
                BillAllStToScreen(newBillAllSt);

                // クローン作成
                this._billAllStClone = newBillAllSt.Clone();
                ScreenToBillAllSt(ref this._billAllStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                BillAllSt billAllSt = (BillAllSt)this._billAllStTable[guid];

                // 請求全体設定オブジェクトを画面に展開
                BillAllStToScreen(billAllSt);

                if (billAllSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._billAllStClone = billAllSt.Clone();
                    ScreenToBillAllSt(ref this._billAllStClone);
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
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}
    
		/// <summary>
		/// データ保存処理処理
		/// </summary>
		/// <returns>保存結果（true:OK／false:エラー在り）</returns>
		/// <remarks>
		/// <br>Note       : データの登録更新処理を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
		private bool DataSaveProc()
		{
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    pgId, 						        // アセンブリＩＤまたはクラスＩＤ
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

            BillAllSt billAllSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();
            }
            ScreenToBillAllSt(ref billAllSt);

            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // 拠点コードが存在していない場合、登録しない。
            if (!SectionUtil.ExistsCode(billAllSt.SectionCode))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0'); // 2011/09/07 
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
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<
            // ----- ADD 2011/09/08 ---------->>>>>
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
            // ----- ADD 2011/09/08 ----------<<<<<

            int status = this._billAllStAcs.Write(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            pgId, 							// アセンブリＩＤまたはクラスＩＤ
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
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
                            pgNm, 					            // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._billAllStAcs,			        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
		}
    
        /// <summary>
        /// 請求全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();

            // 請求全体設定が存在していない
            if (billAllSt == null)
            {
                return -1;
            }

            // ADD 2008/09/17 不具合対応[5288] ---------->>>>>
            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(billAllSt))
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
            // ADD 2008/09/17 不具合対応[5288] ----------<<<<<

            status = this._billAllStAcs.LogicalDelete(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
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
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
                            pgNm, 				                // プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._billAllStAcs,			        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/17 不具合対応[5288] ---------->>>>>
        /// <summary>
        /// 全社設定か判定します。
        /// </summary>
        /// <param name="billAllSt">請求全体設定</param>
        /// <returns><c>true</c> :全社設定である。<br/><c>false</c>:全社設定ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5288]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/17</br>
        /// </remarks>
        private static bool IsAllSection(BillAllSt billAllSt)
        {
            return SectionUtil.IsAllSection(billAllSt.SectionCode);
        }
        // ADD 2008/09/17 不具合対応[5288] ----------<<<<<

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int SearchBillAllSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList billAllSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._billAllStAcs.SearchAll(out billAllSts, this._enterPriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (BillAllSt billAllSt in billAllSts)
                        {
                            if (this._billAllStTable.ContainsKey(billAllSt.FileHeaderGuid) == false)
                            {
                                BillAllStToDataSet(billAllSt.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
                            pgNm, 			                    // プログラム名称
                            "SearchBillAllSt", 			        // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._billAllStAcs, 		     	// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = billAllSts.Count;

            return status;
        }

        /// <summary>
        /// 請求全体設定オブジェクト展開処理
        /// </summary>
        /// <param name="billAllSt">請求全体設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 請求全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void BillAllStToDataSet(BillAllSt billAllSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[BILLALLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (billAllSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DELETE_DATE] = billAllSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONCODE_TITLE] = billAllSt.SectionCode.TrimEnd();
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == billAllSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            
            // ADD 2008/10/09 不具合対応[6445] ---------->>>>>
            if (billAllSt.SectionCode.Trim().Equals("00"))
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }
            // ADD 2008/10/09 不具合対応[6445] ----------<<<<<

            // 引当処理区分
            switch (billAllSt.AllowanceProcCd)
            {
                case 0:
                    wrkstr = ALLOWANCEPROC_OK;          // 両方
                    break;
                case 1:
                    wrkstr = ALLOWANCEPROC_NG;          // 必須
                    break;
                case 2:
                    wrkstr = ALLOWANCEPROC_REFER;       // 不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][AllowanceProcCd_Title_Label.Text] = wrkstr;

            // 入金伝票修正区分
            switch (billAllSt.DepositSlipMntCd)
            {
                case 0:
                    wrkstr = DEPOSITSLIP_NONREFER;       // 修正可
                    break;
                case 1:
                    wrkstr = DEPOSITSLIP_REFER;          // 修正不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DepositSlipMntCd_Title_Label.Text] = wrkstr;


            // 回収予定区分
            switch (billAllSt.CollectPlnDiv)
            {
                case 0:
                    wrkstr = COLLECTPLNDIV_DIV;       // 区分
                    break;
                case 1:
                    wrkstr = COLLECTPLNDIV_DAY;          // 日付
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CollectPlnDiv_Title_Label.Text] = wrkstr;



            // 得意先締日１
            if (0 == billAllSt.CustomerTotalDay1)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY01_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY01_TITLE] = billAllSt.CustomerTotalDay1;
            }

            // 得意先締日２
            if (0 == billAllSt.CustomerTotalDay2)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY02_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY02_TITLE] = billAllSt.CustomerTotalDay2;
            }

            // 得意先締日３
            if (0 == billAllSt.CustomerTotalDay3)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY03_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY03_TITLE] = billAllSt.CustomerTotalDay3;
            }

            // 得意先締日４
            if (0 == billAllSt.CustomerTotalDay4)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY04_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY04_TITLE] = billAllSt.CustomerTotalDay4;
            }

            // 得意先締日５
            if (0 == billAllSt.CustomerTotalDay5)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY05_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY05_TITLE] = billAllSt.CustomerTotalDay5;
            }

            // 得意先締日６
            if (0 == billAllSt.CustomerTotalDay6)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY06_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY06_TITLE] = billAllSt.CustomerTotalDay6;
            }

            // 得意先締日７
            if (0 == billAllSt.CustomerTotalDay7)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY07_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY07_TITLE] = billAllSt.CustomerTotalDay7;
            }

            // 得意先締日８
            if (0 == billAllSt.CustomerTotalDay8)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY08_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY08_TITLE] = billAllSt.CustomerTotalDay8;
            }

            // 得意先締日９
            if (0 == billAllSt.CustomerTotalDay9)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY09_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY09_TITLE] = billAllSt.CustomerTotalDay9;
            }

            // 得意先締日１０
            if (0 == billAllSt.CustomerTotalDay10)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY10_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY10_TITLE] = billAllSt.CustomerTotalDay10;
            }

            // 得意先締日１１
            if (0 == billAllSt.CustomerTotalDay11)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY11_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY11_TITLE] = billAllSt.CustomerTotalDay11;
            }

            // 得意先締日１２
            if (0 == billAllSt.CustomerTotalDay12)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY12_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY12_TITLE] = billAllSt.CustomerTotalDay12;
            }

            // 仕入先締日１
            if (0 == billAllSt.SupplierTotalDay1)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY01_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY01_TITLE] = billAllSt.SupplierTotalDay1;
            }

            // 仕入先締日２
            if (0 == billAllSt.SupplierTotalDay2)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY02_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY02_TITLE] = billAllSt.SupplierTotalDay2;
            }

            // 仕入先締日３
            if (0 == billAllSt.SupplierTotalDay3)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY03_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY03_TITLE] = billAllSt.SupplierTotalDay3;
            }

            // 仕入先締日４
            if (0 == billAllSt.SupplierTotalDay4)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY04_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY04_TITLE] = billAllSt.SupplierTotalDay4;
            }

            // 仕入先締日５
            if (0 == billAllSt.SupplierTotalDay5)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY05_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY05_TITLE] = billAllSt.SupplierTotalDay5;
            }

            // 仕入先締日６
            if (0 == billAllSt.SupplierTotalDay6)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY06_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY06_TITLE] = billAllSt.SupplierTotalDay6;
            }

            // 仕入先締日７
            if (0 == billAllSt.SupplierTotalDay7)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY07_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY07_TITLE] = billAllSt.SupplierTotalDay7;
            }

            // 仕入先締日８
            if (0 == billAllSt.SupplierTotalDay8)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY08_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY08_TITLE] = billAllSt.SupplierTotalDay8;
            }

            // 仕入先締日９
            if (0 == billAllSt.SupplierTotalDay9)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY09_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY09_TITLE] = billAllSt.SupplierTotalDay9;
            }

            // 仕入先締日１０
            if (0 == billAllSt.SupplierTotalDay10)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY10_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY10_TITLE] = billAllSt.SupplierTotalDay10;
            }

            // 仕入先締日１１
            if (0 == billAllSt.SupplierTotalDay11)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY11_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY11_TITLE] = billAllSt.SupplierTotalDay11;
            }

            // 仕入先締日１２
            if (0 == billAllSt.SupplierTotalDay12)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY12_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY12_TITLE] = billAllSt.SupplierTotalDay12;
            }

            // GUID
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][GUID_TITLE] = billAllSt.FileHeaderGuid;

            if (this._billAllStTable.ContainsKey(billAllSt.FileHeaderGuid) == true)
            {
                this._billAllStTable.Remove(billAllSt.FileHeaderGuid);
            }
            this._billAllStTable.Add(billAllSt.FileHeaderGuid, billAllSt);

        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
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
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
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
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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
            this._indexBuf = -2;  // ADD 2008/06/04

            // 比較用クローンクリア
            this._billAllStClone = null;
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
        /// 請求全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = (BillAllSt)this._billAllStTable[guid];

            // 請求全体設定が存在していない
            if (billAllSt == null)
            {
                return -1;
            }

            // ADD 2008/09/17 不具合対応[5288] ---------->>>>>
            // 拠点コードが全社設定の場合、削除不可
            if (IsAllSection(billAllSt))
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
            // ADD 2008/09/17 不具合対応[5288] ----------<<<<<

            status = this._billAllStAcs.Delete(billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._billAllStTable.Remove((Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex].Delete();
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
                            pgId, 					         	// アセンブリＩＤまたはクラスＩＤ
                            pgNm, 				             	// プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._billAllStAcs,			        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 請求全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定オブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();

            // 請求全体設定が存在していない
            if (billAllSt == null)
            {
                return -1;
            }

            status = this._billAllStAcs.Revival(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
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
                            pgId, 						        // アセンブリＩＤまたはクラスＩＤ
                            pgNm, 					            // プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._billAllStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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

                        // 初期フォーカスをセット
                        this.AllowanceProcCd_tComboEditor.Focus();

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
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;              // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;          // ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                // 拠点ガイド名称
            this.AllowanceProcCd_tComboEditor.Enabled = enabled;   // 引当処理区分
            this.DepositSlipMntCd_tComboEditor.Enabled = enabled;  // 入金伝票修正区分
            this.CollectPlnDiv_tComboEditor.Enabled = enabled; 　  // 回収予定区分
            // DEL 2009/04/14 ------>>>
            //this.CustomerTotalDay1_tEdit.Enabled = enabled;        // 得意先締日１
            //this.CustomerTotalDay2_tEdit.Enabled = enabled;        // 得意先締日２
            //this.CustomerTotalDay3_tEdit.Enabled = enabled;        // 得意先締日３ 
            //this.CustomerTotalDay4_tEdit.Enabled = enabled;        // 得意先締日４ 
            //this.CustomerTotalDay5_tEdit.Enabled = enabled;        // 得意先締日５ 
            //this.CustomerTotalDay6_tEdit.Enabled = enabled;        // 得意先締日６ 
            //this.CustomerTotalDay7_tEdit.Enabled = enabled;        // 得意先締日７ 
            //this.CustomerTotalDay8_tEdit.Enabled = enabled;        // 得意先締日８ 
            //this.CustomerTotalDay9_tEdit.Enabled = enabled;        // 得意先締日９ 
            //this.CustomerTotalDay10_tEdit.Enabled = enabled;       // 得意先締日１０ 
            //this.CustomerTotalDay11_tEdit.Enabled = enabled;       // 得意先締日１１ 
            //this.CustomerTotalDay12_tEdit.Enabled = enabled;       // 得意先締日１２ 
            //this.SupplierTotalDay1_tEdit.Enabled = enabled;        // 仕入先締日１
            //this.SupplierTotalDay2_tEdit.Enabled = enabled;        // 仕入先締日２
            //this.SupplierTotalDay3_tEdit.Enabled = enabled;        // 仕入先締日３
            //this.SupplierTotalDay4_tEdit.Enabled = enabled;        // 仕入先締日４
            //this.SupplierTotalDay5_tEdit.Enabled = enabled;        // 仕入先締日５
            //this.SupplierTotalDay6_tEdit.Enabled = enabled;        // 仕入先締日６
            //this.SupplierTotalDay7_tEdit.Enabled = enabled;        // 仕入先締日７
            //this.SupplierTotalDay8_tEdit.Enabled = enabled;        // 仕入先締日８
            //this.SupplierTotalDay9_tEdit.Enabled = enabled;        // 仕入先締日９
            //this.SupplierTotalDay10_tEdit.Enabled = enabled;       // 仕入先締日１０
            //this.SupplierTotalDay11_tEdit.Enabled = enabled;       // 仕入先締日１１
            //this.SupplierTotalDay12_tEdit.Enabled = enabled;       // 仕入先締日１２
            // DEL 2009/04/14 ------<<<
            // ADD 2009/04/14 ------>>>
            if ((tEdit_SectionCodeAllowZero2.Text.TrimEnd() != string.Empty) && 
                (tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0') == "00"))
            {
                // 全社共通の場合
                this.CustomerTotalDay1_tEdit.Enabled = enabled;         // 得意先締日１
                this.CustomerTotalDay2_tEdit.Enabled = enabled;         // 得意先締日２
                this.CustomerTotalDay3_tEdit.Enabled = enabled;         // 得意先締日３ 
                this.CustomerTotalDay4_tEdit.Enabled = enabled;         // 得意先締日４ 
                this.CustomerTotalDay5_tEdit.Enabled = enabled;         // 得意先締日５ 
                this.CustomerTotalDay6_tEdit.Enabled = enabled;         // 得意先締日６ 
                this.CustomerTotalDay7_tEdit.Enabled = enabled;         // 得意先締日７ 
                this.CustomerTotalDay8_tEdit.Enabled = enabled;         // 得意先締日８ 
                this.CustomerTotalDay9_tEdit.Enabled = enabled;         // 得意先締日９ 
                this.CustomerTotalDay10_tEdit.Enabled = enabled;        // 得意先締日１０ 
                this.CustomerTotalDay11_tEdit.Enabled = enabled;        // 得意先締日１１ 
                this.CustomerTotalDay12_tEdit.Enabled = enabled;        // 得意先締日１２ 
                this.SupplierTotalDay1_tEdit.Enabled = enabled;         // 仕入先締日１
                this.SupplierTotalDay2_tEdit.Enabled = enabled;         // 仕入先締日２
                this.SupplierTotalDay3_tEdit.Enabled = enabled;         // 仕入先締日３
                this.SupplierTotalDay4_tEdit.Enabled = enabled;         // 仕入先締日４
                this.SupplierTotalDay5_tEdit.Enabled = enabled;         // 仕入先締日５
                this.SupplierTotalDay6_tEdit.Enabled = enabled;         // 仕入先締日６
                this.SupplierTotalDay7_tEdit.Enabled = enabled;         // 仕入先締日７
                this.SupplierTotalDay8_tEdit.Enabled = enabled;         // 仕入先締日８
                this.SupplierTotalDay9_tEdit.Enabled = enabled;         // 仕入先締日９
                this.SupplierTotalDay10_tEdit.Enabled = enabled;        // 仕入先締日１０
                this.SupplierTotalDay11_tEdit.Enabled = enabled;        // 仕入先締日１１
                this.SupplierTotalDay12_tEdit.Enabled = enabled;        // 仕入先締日１２
            }
            else
            {
                // 全社共通以外は、入力不可
                this.CustomerTotalDay1_tEdit.Enabled = false;           // 得意先締日１
                this.CustomerTotalDay2_tEdit.Enabled = false;           // 得意先締日２
                this.CustomerTotalDay3_tEdit.Enabled = false;           // 得意先締日３ 
                this.CustomerTotalDay4_tEdit.Enabled = false;           // 得意先締日４ 
                this.CustomerTotalDay5_tEdit.Enabled = false;           // 得意先締日５ 
                this.CustomerTotalDay6_tEdit.Enabled = false;           // 得意先締日６ 
                this.CustomerTotalDay7_tEdit.Enabled = false;           // 得意先締日７ 
                this.CustomerTotalDay8_tEdit.Enabled = false;           // 得意先締日８ 
                this.CustomerTotalDay9_tEdit.Enabled = false;           // 得意先締日９ 
                this.CustomerTotalDay10_tEdit.Enabled = false;          // 得意先締日１０ 
                this.CustomerTotalDay11_tEdit.Enabled = false;          // 得意先締日１１ 
                this.CustomerTotalDay12_tEdit.Enabled = false;          // 得意先締日１２ 
                this.SupplierTotalDay1_tEdit.Enabled = false;           // 仕入先締日１
                this.SupplierTotalDay2_tEdit.Enabled = false;           // 仕入先締日２
                this.SupplierTotalDay3_tEdit.Enabled = false;           // 仕入先締日３
                this.SupplierTotalDay4_tEdit.Enabled = false;           // 仕入先締日４
                this.SupplierTotalDay5_tEdit.Enabled = false;           // 仕入先締日５
                this.SupplierTotalDay6_tEdit.Enabled = false;           // 仕入先締日６
                this.SupplierTotalDay7_tEdit.Enabled = false;           // 仕入先締日７
                this.SupplierTotalDay8_tEdit.Enabled = false;           // 仕入先締日８
                this.SupplierTotalDay9_tEdit.Enabled = false;           // 仕入先締日９
                this.SupplierTotalDay10_tEdit.Enabled = false;          // 仕入先締日１０
                this.SupplierTotalDay11_tEdit.Enabled = false;          // 仕入先締日１１
                this.SupplierTotalDay12_tEdit.Enabled = false;          // 仕入先締日１２
            }
            // ADD 2009/04/14 ------<<<
            
            // ちらつき防止の為
            this.Enabled = true;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            int i;
            ArrayList days = new ArrayList();
            bool spaceFlg = false;
            bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false; 

                return result;
            }

            Broadleaf.Library.Windows.Forms.TEdit[] customerTotalDay_tEdit = new TEdit[12];
            customerTotalDay_tEdit[0] = CustomerTotalDay1_tEdit;
            customerTotalDay_tEdit[1] = CustomerTotalDay2_tEdit;
            customerTotalDay_tEdit[2] = CustomerTotalDay3_tEdit;
            customerTotalDay_tEdit[3] = CustomerTotalDay4_tEdit;
            customerTotalDay_tEdit[4] = CustomerTotalDay5_tEdit;
            customerTotalDay_tEdit[5] = CustomerTotalDay6_tEdit;
            customerTotalDay_tEdit[6] = CustomerTotalDay7_tEdit;
            customerTotalDay_tEdit[7] = CustomerTotalDay8_tEdit;
            customerTotalDay_tEdit[8] = CustomerTotalDay9_tEdit;
            customerTotalDay_tEdit[9] = CustomerTotalDay10_tEdit;
            customerTotalDay_tEdit[10] = CustomerTotalDay11_tEdit;
            customerTotalDay_tEdit[11] = CustomerTotalDay12_tEdit;

            // 処理対象締日（得意先）チェック
            for (i = 0;i < 12 ;i++)
            {
                if (customerTotalDay_tEdit[i].DataText == "")
                {
                    if (spaceFlg != true)
                    {
                        spaceFlg = true;
                        control = customerTotalDay_tEdit[i];
                    }
                }
                else
                {
                    if (spaceFlg == true)
                    {
                        // 間があいている場合
                        message = TOTALDAY_NGMSG_BETWEEN;
                        result = false;

                        return result;
                    }

                    if (Int32.Parse(customerTotalDay_tEdit[i].DataText) > 31)
                    {
                        // 1～31の範囲外の場合
                        message = TOTALDAY_NGMSG_DAYS;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if ((i != 0) && (Int32.Parse(customerTotalDay_tEdit[i - 1].DataText) > Int32.Parse(customerTotalDay_tEdit[i].DataText)))
                    {
                        // 左側の項目よりも値が小さい場合
                        message = TOTALDAY_NGMSG_SMALL;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if (days.IndexOf(customerTotalDay_tEdit[i].DataText) >= 0)
                    {
                        // 重複している場合
                        message = TOTALDAY_NGMSG_REPEAT;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }
                    else
                    {
                        days.Add(customerTotalDay_tEdit[i].DataText);
                    }
                }
            }

            days.Clear();
            spaceFlg = false;

            Broadleaf.Library.Windows.Forms.TEdit[] supplierTotalDay_tEdit = new TEdit[12];
            supplierTotalDay_tEdit[0] = SupplierTotalDay1_tEdit;
            supplierTotalDay_tEdit[1] = SupplierTotalDay2_tEdit;
            supplierTotalDay_tEdit[2] = SupplierTotalDay3_tEdit;
            supplierTotalDay_tEdit[3] = SupplierTotalDay4_tEdit;
            supplierTotalDay_tEdit[4] = SupplierTotalDay5_tEdit;
            supplierTotalDay_tEdit[5] = SupplierTotalDay6_tEdit;
            supplierTotalDay_tEdit[6] = SupplierTotalDay7_tEdit;
            supplierTotalDay_tEdit[7] = SupplierTotalDay8_tEdit;
            supplierTotalDay_tEdit[8] = SupplierTotalDay9_tEdit;
            supplierTotalDay_tEdit[9] = SupplierTotalDay10_tEdit;
            supplierTotalDay_tEdit[10] = SupplierTotalDay11_tEdit;
            supplierTotalDay_tEdit[11] = SupplierTotalDay12_tEdit;

            // 処理対象締日（仕入先）チェック
            for (i = 0; i < 12; i++)
            {
                if (supplierTotalDay_tEdit[i].DataText == "")
                {
                    if(spaceFlg != true)
                    {
                        spaceFlg = true;
                        control = supplierTotalDay_tEdit[i];
                    }
                }
                else
                {
                    if (spaceFlg == true)
                    {
                        message = TOTALDAY_NGMSG_BETWEEN;
                        result = false;

                        return result;
                    }

                    if (Int32.Parse(supplierTotalDay_tEdit[i].DataText) > 31)
                    {
                        // 1～31の範囲外の場合
                        message = TOTALDAY_NGMSG_DAYS;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if ((i != 0) && (Int32.Parse(supplierTotalDay_tEdit[i - 1].DataText) > Int32.Parse(supplierTotalDay_tEdit[i].DataText))) 
                    {
                        // 左側の項目よりも値が小さい場合
                        message = TOTALDAY_NGMSG_SMALL;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if (days.IndexOf(supplierTotalDay_tEdit[i].DataText) >= 0)
                    {
                        message = TOTALDAY_NGMSG_REPEAT;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }
                    else
                    {
                        days.Add(supplierTotalDay_tEdit[i].DataText);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (sectionCode.Trim().PadLeft(2, '0') == "00")
                    sectionName = "全社共通";
                // --- ADD 2011/09/07 --------------------------------<<<<<
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
		///	Form.Load イベント(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // --- ADD 2008/06/13 -------------------------------->>>>>
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/06/13 --------------------------------<<<<< 

			// 画面初期設定処理
			ScreenInitialSetting();

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();  // ADD 2008/09/16 不具合対応[5257]
		}
		
		/// <summary>
		///	Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : 保存ボタンコントロールがクリックされたときに
		///					 発生します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            /* --- DEL 2008/06/13 -------------------------------->>>>>
            //保存処理
            if (!DataSaveProc()) 
            {return;}

            DialogResult dialogResult = DialogResult.OK;

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }
		
            this.DialogResult = dialogResult;
            this._billAllStClone = null;

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
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            if (!DataSaveProc())
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

                BillAllSt newBillAllSt = new BillAllSt();

                // 請求全体設定オブジェクトを画面に展開
                BillAllStToScreen(newBillAllSt);

                // クローン作成
                this._billAllStClone = newBillAllSt.Clone();
                ScreenToBillAllSt(ref this._billAllStClone);

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
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}

		/// <summary>
		///	Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : 閉じるボタンコントロールがクリックされたときに
		///					 発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                BillAllSt compareBillAllSt = new BillAllSt();
                compareBillAllSt = this._billAllStClone.Clone();
                ScreenToBillAllSt(ref compareBillAllSt);

                // 最初に取得した画面情報と比較
                if (!(this._billAllStClone.Equals(compareBillAllSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        pgId, 						        // アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	// 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!DataSaveProc())
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
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
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
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                
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
		}

		/// <summary>
		///	Form.Closing イベント(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note	   : フォームを閉じる前に、ユーザーがフォームを閉じ
		///					 ようとしたときに発生します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            //this._billAllStClone = null;  // DEL 2008/06/13

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

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
		/// Control.VisibleChanged イベント(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_VisibleChanged(object sender, System.EventArgs e)
		{    
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// メインフレームアクティブ化
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}

            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ちらつき防止の為
            this.Enabled = false;

			timer1.Enabled = true;

			ScreenClear();		
		}
      
		/// <summary>
		/// Timer.Tick イベント(timer1_Tick)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。
		///                  この処理は、システムが提供するスレッド プール
		///	                 スレッドで実行されます。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
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
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            int status = secInfoSetAcs.ExecuteGuid(this._enterPriseCode, false, out secInfoSet);
            if (status != 0)
            {
                ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 不具合対応[6226]
                return;
            }

            // 取得データ表示
            this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
            this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if (this._dataIndex < 0)
            {
                if (ModeChangeProc())
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    ((Control)sender).Focus();
                }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }
		# endregion

        /// <summary>
        /// 完全削除ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                pgId, 						        // アセンブリＩＤまたはクラスＩＤ
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
        /// 復活ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/13</br>
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
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                if (this.SectionNm_tEdit.Text == "")
                {
                    TMsgDisp.Show(
                        this, 								 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,  // エラーレベル
                        "DCKHN09210U", 						 // アセンブリＩＤまたはクラスＩＤ
                        "指定した拠点コードは存在しません。",// 表示するメッセージ
                        0, 									 // ステータス値
                        MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero2.Text = "";
                    this.tEdit_SectionCodeAllowZero2.Focus();
                    this.tEdit_SectionCodeAllowZero2.Select();
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<
            }
            else
            {
                // 拠点コード名称クリア
                this.SectionNm_tEdit.Text = "";
            }

            // ADD 2008/10/10 不具合対応[6445] ---------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("00") ||
                this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("0"))    // DEL 2009/04/10 不具合対応[13142] 削除した条件→ || this.SectionNm_tEdit.Text.Equals(""))
            {
                this.SectionNm_tEdit.Text = "全社共通";
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');// ADD 2011/09/07
            }
            // ADD 2008/10/10 不具合対応[6445] ----------<<<<<
        }

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// tArrowKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
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
        }

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
            tEdit_SectionCodeAllowZero2.Text = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            SectionNm_tEdit.Text = GetSectionName(tEdit_SectionCodeAllowZero2.Text);
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの請求全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            // ADD 2009/04/08 不具合対応[13142]：初期状態で拠点ガイド入力を行うと全社共通になってしまう ---------->>>>>
            if (sectionCd.Equals("00") && string.IsNullOrEmpty(SectionGuideController.GetPreviousText()))
            {
                sectionCd = string.Empty;
            }
            // ADD 2009/04/08 不具合対応[13142]：初期状態で拠点ガイド入力を行うと全社共通になってしまう ----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          pgId,						            // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの請求全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの請求全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        pgId,                                   // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true;
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
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
	}
}
