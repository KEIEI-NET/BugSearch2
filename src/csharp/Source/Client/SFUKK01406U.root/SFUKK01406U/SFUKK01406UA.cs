//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金伝票入力（売上指定型）
// プログラム概要   : 入金伝票入力（売上指定型）の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : amami
// 作 成 日  2005/08/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/01/30  修正内容 : MA.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/01/31  修正内容 : 画面スキン変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/03/27  修正内容 : 販売従業員マスタのガイドを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/05/14  修正内容 : 請求売上データのパラメータにサービス伝票区分、売掛区分、自動入金区分を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/05/30  修正内容 : 
// 1. 入力されたクレジット会社コードに該当するクレジット会社がなかったらメッセージを表示するように修正
// 2. 支払入力と同じように保存時の入金日をクリアしないで表示するように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/07/30  修正内容 : 保存時にクレジット会社コードのチェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 修 正 日  2007/10/09  修正内容 : DC.NS用にレイアウトの変更を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/06/26  修正内容 : Partsman用にレイアウトの変更を行う
//----------------------------------------------------------------------------//
// 管理番号  12908       作成担当 : 工藤　恵優
// 修 正 日  2009/04/14  修正内容 : スペースキーでの項目選択機能を実装
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/24  修正内容 : MANTIS【13577】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/26  修正内容 : MANTIS【13344】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 修 正 日  2010/07/01  修正内容 : ①未入金一覧表の印刷機能を追加。(ボタン"btnNoDepSalList"追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 修 正 日  2010/08/18  修正内容 : 締次ロック対応。（メッセージ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/12/20  修正内容 : PM.NS障害改良対応(12月分)
//                                : ①売上指定型の選択合計入金額の修正
//                                : ②引当情報表示の改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2011/01/21  修正内容 : Redmine#18653の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2012/09/21  修正内容 : 2012/10/17配信分 Redmine#32415
//                                  発行者の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 董桂鈺
// 修 正 日  2013/01/09  修正内容 : 2013/03/13配信分 Redmine#33921対応
//                                  ①、データを保存後、摘要をクリアすることの追加
//　　　　　　　　　　　　　　　　　②、新規の場合に、期日、摘要、手数料、選択合計入金額の設定処理の追加
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : 2013/03/13配信分 Redmine#33741
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/06  修正内容 : 2013/03/13配信分 Redmine#33741
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 董桂鈺
// 修 正 日  2013/02/17  修正内容 : 2013/03/13配信分 Redmine#33921対応
//                                  入金の摘要欄に半角カタカナを入力できるように修正
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/25  修正内容 : 2013/03/13配信分 Redmine#33741
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉軍
// 修 正 日  2013/07/18  修正内容 : 配信なし分 Redmine#35133　既存障害№1の対応
//                                  手数料プラス・マイナスチェック処理を削除
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/05/28  修正内容 : ㈱カト―個別対応  
//                                  ①入金入力（売上指定型）で売上伝票を複数選択し、保存したとき、
//                                    入金伝票が売上伝票それぞれに作成されるように変更を行います。
//                                  ②入金日がガイドではなく、画面（明細）に表示できるようにします。
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/06/18 修正内容 : RedMine#42902  
//                                  ①入金伝票入力登録後、クリアされない項目が存在する。
//                                    登録完了後は新規ボタン押下時と同じ動作にします
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/07/04 修正内容 : RedMine#42902  
//                                  入金伝票入力（売上指定型）に伝票削除機能追加
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  K2014/07/08 修正内容 : RedMine#42902の⑨
//                                  既存障害の対応
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : songg
// 修 正 日  K2014/07/08 修正内容 : RedMine#42902の⑪
//                                  デフォルトでいいえにフォーカスがない
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  2014/07/09  修正内容 : RedMine#42902の⑬
//                                  既存障害の対応
//                                  「-」のみで他の項目に移動しようとすると以下のエラーが発生する。
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  2014/07/10  修正内容 : RedMine#42902の⑩
//                                  既存障害の対応
//                                  「一括引当」ボタンの押下について
//                                  RedMine#42902の⑭
//                                  得意先ガイドを使用してコードを入力・検索すると「引当日」、「金種」が表示されない。
//----------------------------------------------------------------------------//
// 管理番号  11001635-00 作成担当 : zhujw
// 修 正 日  2014/07/10  修正内容 : RedMine#42902の⑩_2
//                                  既存障害の対応
//                                  「一括引当」ボタンの押下について
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/04/14 不具合対応[12908]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Collections.Specialized;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金伝票入力（売上指定型）ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金伝票入力（売上指定型）ＵＩの機能を実装します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.30 T.Kimura MA.NS用に変更</br>
    /// <br>                                   1. 得意先区分の削除</br>
    /// <br>                                   2. システム導入区分の削除</br>
    /// <br>                                   3. 納車予定日を計上日に変更</br>
    /// <br>             2007.01.31 T.Kimura   4. 画面スキン変更対応</br>
    /// <br>             2007.03.27 T.Kimura   5. 販売従業員マスタのガイドを修正</br>
    /// <br>             2007.05.14 T.Kimura   6. 請求売上データのパラメータにサービス伝票区分、売掛区分、自動入金区分を追加</br>
    /// <br>             2007.05.30 18322 T.Kimura 次の点を修正</br>
    /// <br>                   1. 入力されたクレジット会社コードに該当するクレジット会社がなかったらメッセージを表示するように修正</br>
    /// <br>                   2. 支払入力と同じように保存時の入金日をクリアしないで表示するように変更</br>
    /// <br>             2007.07.30 T.Kimura 1. 保存時にクレジット会社コードのチェックを追加</br>
    /// <br>             2007.08.01 T.Kimura 1. 月次締め日チェックを追加</br>
    /// <br>             2007.10.09 疋田 勇人 DC.NS用にレイアウトの変更を行う</br>
    /// <br>             2008/06/26 忍 幸史 Partsman用にレイアウトの変更を行う</br>
    /// <br>             2009/04/14 工藤 恵優 スペースキーでの項目選択機能を実装</br>
    /// <br>             2010/07/01 22018 鈴木 正臣</br>
    /// <br>                   1. 未入金一覧表の印刷機能を追加。(ボタン"btnNoDepSalList"追加)</br>
    /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)
    /// <br>              ①売上指定型の選択合計入金額の修正</br>
    /// <br>              ②引当情報表示の改良</br>
    /// <br>Update Note : 2011/01/21 yangmj Redmine#18653の修正
    /// <br>Update Note : 2012/09/21 田建委</br>
    /// <br>管理番号    : 2012/10/17配信分</br>
    /// <br>              Redmine#32415 発行者の追加対応</br>
    /// <br>Update Note : 2013/01/09 董桂鈺</br>
    /// <br>管理番号    : 10806793-00  2013/03/13配信分</br>
    /// <br>              Redmine#33921  ①、データを保存後、摘要をクリアすることの追加</br>
    /// <br>                             ②、新規の場合に、期日、摘要、手数料、選択合計入金額の設定処理の追加</br>
    /// <br>Update Note : 2012/12/24 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の追加対応</br>
    /// <br>Update Note : 2013/02/06 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の追加対応</br>
    /// <br>Update Note : 2013/02/17 董桂鈺</br>
    /// <br>管理番号    : 10806793-00  2013/03/13配信分</br>
    /// <br>              Redmine#33921  入金の摘要欄に半角カタカナを入力できるように修正</br>
    /// <br>Update Note : 2013/02/25 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の追加対応</br>
    /// <br>Update Note : 2013/07/18 呉軍</br>
    /// <br>管理番号    : 配信なし分</br>
    /// <br>              Redmine#35133 既存障害№1の対応</br>
    /// <br></br>
	/// </remarks>
	public class SFUKK01406UA : System.Windows.Forms.Form, IDepositInputMDIChild
    {
        #region Enum
        // 2007.10.09 hikita add start -------------------------------->>
        /// <summary>
        /// 金額種別区分
        /// </summary>
        private enum MnyKindDiv
        {
            // 現金　
            Cash = 101,
            // 振込
            Remittance = 102,
            // 手形
            Bill = 105,
            // 相殺
            Offset = 106,
            // 小切手
            Check = 107,
            // 先付小切手
            ACheck = 108,
            // その他
            Others = 119,
            // 手数料
            Fee = 110,
            // 値引
            Discount = 111,
        }
        // 2007.10.09 hikita add end -----------------------------------<<
        #endregion

        # region Private Members (Component)
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Panel panel_Heder;
		private System.Windows.Forms.Panel panel_Search;
		private System.Windows.Forms.Panel panel_Nyu;
		private System.Windows.Forms.Panel panel_Goukei;
        private Infragistics.Win.Misc.UltraLabel ultraLabel58;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
		private Broadleaf.Library.Windows.Forms.TShape tShape2;
		private Broadleaf.Library.Windows.Forms.TLine tLine12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Broadleaf.Library.Windows.Forms.TLine tLine10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private System.Windows.Forms.Panel SFUKK01406UA_Fill_Panel;
        private System.Windows.Forms.Panel panel_SFUKK01406UA;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet opsAlwcDmdSalesCall;
        private Broadleaf.Library.Windows.Forms.TComboEditor cmbMoneyKind;
        private Broadleaf.Library.Windows.Forms.TDateEdit edtDepositDate;
		private Broadleaf.Library.Windows.Forms.TEdit edtCustomerName;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
		private Infragistics.Win.Misc.UltraLabel labSalesTotal;
        private Infragistics.Win.Misc.UltraLabel labSalesAllowanceTotal;
        private Infragistics.Win.Misc.UltraButton btnCustomerGuid;
		private Infragistics.Win.Misc.UltraLabel labDmdSalesList;
		private Broadleaf.Library.Windows.Forms.TLine tLine11;
		private Infragistics.Win.Misc.UltraLabel labDepositTotal;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraButton btnAllAwl;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panel_Left;
		private System.Windows.Forms.Panel panel_Right;
		private Infragistics.Win.UltraWinGrid.UltraGrid grdDmdSalesList;
        private System.Windows.Forms.Panel panel1;
        private Broadleaf.Library.Windows.Forms.TShape tShape8;
        private System.Windows.Forms.Panel panel3;
		private Infragistics.Win.Misc.UltraButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
		private System.Windows.Forms.Splitter splitter1;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesSlipNum;
		private Broadleaf.Library.Windows.Forms.TDateEdit detSearchSlipDateEnd;
		private Broadleaf.Library.Windows.Forms.TDateEdit detSearchSlipDateStart;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTip;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipGrid;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private TDateEdit dateDraftPayTimeLimit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TNedit edtFeeDeposit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar stbDmdSalesList;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ckdSalesAutoColumnSize;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ckdDetailDmdSalesList;
        private TComboEditor cmbFontSize;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TEdit edtOutline;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private TNedit tNedit_SelectedDepositTotal;
        private Infragistics.Win.Misc.UltraButton btnNoDepSalList;
        private TEdit tEdit_SalesInputName;
        private Infragistics.Win.Misc.UltraButton uButton_SalesInputCode;
        private TEdit tEdit_EmployeeCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesInputCodeTitle;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 入金伝票入力（売上指定型）ＵＩクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.08.20</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
		/// </remarks>
		public SFUKK01406UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// 入金引当表示クラス
			this.sfukk01415UA = new SFUKK01415UA();

			// 入金伝票入力設定データ系アクセスクラス
			this.depositRelDataAcs = new DepositRelDataAcs();

			// 入金伝票入力画面(受注指定型)アクセスクラス
			this.inputDepositSalesTypeAcs = new InputDepositSalesTypeAcs();

            // ↓ 20070519 18322 d AA会場は使用しないので削除(SFTOK09242A or SFTOK01180U)
			//// 得意先テーブルアクセスクラス
			//this.customerAcs = null;
            // ↑ 20070519 18322 

            // ↓ 20070219 18322 c MA.NS用に変更
			//// 得意先ガイドクラス
			//this.customerSearchGuide = null;

            // 得意先情報アクセスクラス    
		    this._customerInfoAcs = new CustomerInfoAcs();
            // ↑ 20070219 18322 c

            this._employeeAcs = new EmployeeAcs(); // ADD 2012/09/21 田建委 redmine#32415

            // 拠点アクセスクラス
            this._secInfoAcs = new SecInfoAcs();  // 2007.10.09 add                          

            // 2007.10.09 hikita del start -------------------------------------->>
            //// クレジット会社テーブルアクセスクラス
            //this.creditCmpAcs = null;           
            //// 従業員テーブルアクセスクラス       
            //this.employeeAcs = null;            
            // 2007.10.09 hikita del end ----------------------------------------<<

            // 2007.10.09 hikita add start --------------------------------------->>
            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();    
            // 2007.10.09 hikita add end -----------------------------------------<<

            // グリッド設定制御クラスインスタンス化
			this._gridStateController = new GridStateController();

            // ↓ 20070519 18322 d 今のところ使用しないので削除
			//// 領収書印刷クラス
			//this.sfukk01502UA = null;
            // ↑ 20070519 18322 d

			// 受注引当グリッド選択行
			this.selectedDmdSalesRow = null;

			// 更新完了フラグ
			this.updateComplete = false;

			// 企業コード
			this.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this.claimCode = 0;

			// ログイン担当者
			this.employee = LoginInfoAcquisition.Employee;

			// 選択拠点
			this.selectSectionCode = "";

			// 画面状態保持クラス
			this._displayStatus = null;

			// 新規ボタン プロパティ用
			this._buttonNew = false;

			// 保存ボタン プロパティ用
			this._buttonSave = false;

            this._btnRenewal = true;
		
			// 削除ボタン プロパティ用
			this._buttonDelete = false;
		
			// 赤伝ボタン プロパティ用
			this._buttonAka = false;

			// 領収書発行ボタン プロパティ用
			this._buttonReceiptPrint = false;

            // 伝票呼出ボタン プロパティ用
            this._buttonReadSlip = false; // ADD 王君 2012/12/24 Redmine#33741

            // --- ADD m.suzuki 2010/07/01 ---------->>>>>
            // 未入金一覧表ボタン
            this.btnNoDepSalList.Visible = false; // 初期状態はfalseにしておく
            // --- ADD m.suzuki 2010/07/01 ----------<<<<<

            // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>
            if (inputDepositSalesTypeAcs.KaToOption())
            {
                // 締日算出モジュール
                this._totalDayCalculator = TotalDayCalculator.GetInstance();

                // 入金更新アクセスクラス
                this._depsitMainAcs = new DepsitMainAcs();
            }
            // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<
            // ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ---->>>>>
            this._subflag = false;
            // ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ----<<<<<
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
		/// <br>Update Note: 2013/02/17 董桂鈺 </br>
		/// <br>管理番号   : 10806793-00  2013/03/13配信分</br>
		/// <br>             Redmine#33921  入金の摘要欄に半角カタカナを入力できるように修正</br>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("発行者ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01406UA));
            this.cmbFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ckdSalesAutoColumnSize = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ckdDetailDmdSalesList = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.SFUKK01406UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel_SFUKK01406UA = new System.Windows.Forms.Panel();
            this.grdDmdSalesList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Nyu = new System.Windows.Forms.Panel();
            this.edtOutline = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SelectedDepositTotal = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.edtFeeDeposit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.dateDraftPayTimeLimit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMoneyKind = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.edtDepositDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tShape2 = new Broadleaf.Library.Windows.Forms.TShape();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_Search = new System.Windows.Forms.Panel();
            this.tEdit_SalesSlipNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.opsAlwcDmdSalesCall = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCustomerGuid = new Infragistics.Win.Misc.UltraButton();
            this.detSearchSlipDateEnd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.detSearchSlipDateStart = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.edtCustomerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape8 = new Broadleaf.Library.Windows.Forms.TShape();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNoDepSalList = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Goukei = new System.Windows.Forms.Panel();
            this.tLine11 = new Broadleaf.Library.Windows.Forms.TLine();
            this.labDepositTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.btnAllAwl = new Infragistics.Win.Misc.UltraButton();
            this.labDmdSalesList = new Infragistics.Win.Misc.UltraLabel();
            this.tLine10 = new Broadleaf.Library.Windows.Forms.TLine();
            this.labSalesTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine12 = new Broadleaf.Library.Windows.Forms.TLine();
            this.labSalesAllowanceTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.panel_Heder = new System.Windows.Forms.Panel();
            this.stbDmdSalesList = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraToolTipGrid = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tEdit_SalesInputName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SalesInputCode = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_SalesInputCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFontSize)).BeginInit();
            this.SFUKK01406UA_Fill_Panel.SuspendLayout();
            this.panel_SFUKK01406UA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDmdSalesList)).BeginInit();
            this.panel_Nyu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOutline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SelectedDepositTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFeeDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneyKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            this.panel_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsAlwcDmdSalesCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape8)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel_Goukei.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine12)).BeginInit();
            this.stbDmdSalesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFontSize
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.cmbFontSize.ActiveAppearance = appearance1;
            appearance2.TextHAlignAsString = "Right";
            this.cmbFontSize.Appearance = appearance2;
            this.cmbFontSize.AutoSize = false;
            this.cmbFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFontSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.TextHAlignAsString = "Right";
            this.cmbFontSize.ItemAppearance = appearance3;
            valueListItem1.DataValue = 6;
            valueListItem1.DisplayText = "6";
            valueListItem2.DataValue = 8;
            valueListItem2.DisplayText = "8";
            valueListItem3.DataValue = 9;
            valueListItem3.DisplayText = "9";
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "10";
            valueListItem5.DataValue = 11;
            valueListItem5.DisplayText = "11";
            valueListItem6.DataValue = 12;
            valueListItem6.DisplayText = "12";
            valueListItem7.DataValue = 14;
            valueListItem7.DisplayText = "14";
            this.cmbFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.cmbFontSize.Location = new System.Drawing.Point(76, 3);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(40, 23);
            this.cmbFontSize.TabIndex = 27;
            this.cmbFontSize.ValueChanged += new System.EventHandler(this.cmbFontSize_ValueChanged);
            // 
            // ckdSalesAutoColumnSize
            // 
            appearance9.FontData.Name = "ＭＳ ゴシック";
            appearance9.FontData.SizeInPoints = 9F;
            this.ckdSalesAutoColumnSize.Appearance = appearance9;
            this.ckdSalesAutoColumnSize.BackColor = System.Drawing.Color.Transparent;
            this.ckdSalesAutoColumnSize.BackColorInternal = System.Drawing.Color.Transparent;
            this.ckdSalesAutoColumnSize.Location = new System.Drawing.Point(126, 3);
            this.ckdSalesAutoColumnSize.Name = "ckdSalesAutoColumnSize";
            this.ckdSalesAutoColumnSize.Size = new System.Drawing.Size(160, 23);
            this.ckdSalesAutoColumnSize.TabIndex = 28;
            this.ckdSalesAutoColumnSize.Text = "列サイズの自動調整";
            this.ckdSalesAutoColumnSize.CheckedChanged += new System.EventHandler(this.ckdSalesAutoColumnSize_CheckedChanged);
            // 
            // ckdDetailDmdSalesList
            // 
            appearance10.FontData.Name = "ＭＳ ゴシック";
            appearance10.FontData.SizeInPoints = 9F;
            this.ckdDetailDmdSalesList.Appearance = appearance10;
            this.ckdDetailDmdSalesList.BackColor = System.Drawing.Color.Transparent;
            this.ckdDetailDmdSalesList.BackColorInternal = System.Drawing.Color.Transparent;
            this.ckdDetailDmdSalesList.Location = new System.Drawing.Point(301, 3);
            this.ckdDetailDmdSalesList.Name = "ckdDetailDmdSalesList";
            this.ckdDetailDmdSalesList.Size = new System.Drawing.Size(90, 23);
            this.ckdDetailDmdSalesList.TabIndex = 29;
            this.ckdDetailDmdSalesList.Text = "詳細表示";
            this.ckdDetailDmdSalesList.CheckedChanged += new System.EventHandler(this.ckdDetailDmdSalesList_CheckedChanged);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // SFUKK01406UA_Fill_Panel
            // 
            this.SFUKK01406UA_Fill_Panel.Controls.Add(this.panel_SFUKK01406UA);
            this.SFUKK01406UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFUKK01406UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFUKK01406UA_Fill_Panel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SFUKK01406UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.SFUKK01406UA_Fill_Panel.Name = "SFUKK01406UA_Fill_Panel";
            this.SFUKK01406UA_Fill_Panel.Size = new System.Drawing.Size(992, 658);
            this.SFUKK01406UA_Fill_Panel.TabIndex = 0;
            // 
            // panel_SFUKK01406UA
            // 
            this.panel_SFUKK01406UA.Controls.Add(this.grdDmdSalesList);
            this.panel_SFUKK01406UA.Controls.Add(this.panel1);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Nyu);
            this.panel_SFUKK01406UA.Controls.Add(this.splitter1);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Search);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Right);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Left);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Goukei);
            this.panel_SFUKK01406UA.Controls.Add(this.panel_Heder);
            this.panel_SFUKK01406UA.Controls.Add(this.stbDmdSalesList);
            this.panel_SFUKK01406UA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_SFUKK01406UA.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_SFUKK01406UA.Location = new System.Drawing.Point(0, 0);
            this.panel_SFUKK01406UA.Name = "panel_SFUKK01406UA";
            this.panel_SFUKK01406UA.Size = new System.Drawing.Size(992, 658);
            this.panel_SFUKK01406UA.TabIndex = 22;
            // 
            // grdDmdSalesList
            // 
            this.grdDmdSalesList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDmdSalesList.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdDmdSalesList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdDmdSalesList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdDmdSalesList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdDmdSalesList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdDmdSalesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDmdSalesList.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.grdDmdSalesList.Location = new System.Drawing.Point(5, 262);
            this.grdDmdSalesList.Name = "grdDmdSalesList";
            this.grdDmdSalesList.Size = new System.Drawing.Size(982, 323);
            this.grdDmdSalesList.TabIndex = 24;
            this.grdDmdSalesList.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDmdSalesList_ClickCellButton);
            this.grdDmdSalesList.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.grdDmdSalesList_BeforeEnterEditMode);
            this.grdDmdSalesList.AfterExitEditMode += new System.EventHandler(this.grdDmdSalesList_AfterExitEditMode);
            this.grdDmdSalesList.Click += new System.EventHandler(this.grdDmdSalesList_Click);
            this.grdDmdSalesList.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDmdSalesList_InitializeLayout);
            this.grdDmdSalesList.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.grdDmdSalesList_MouseLeaveElement);
            this.grdDmdSalesList.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.grdDmdSalesList_BeforeExitEditMode);
            this.grdDmdSalesList.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.grdDmdSalesList_AfterRowFilterChanged);
            this.grdDmdSalesList.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.grdDmdSalesList_BeforeCellDeactivate);
            this.grdDmdSalesList.AfterRowActivate += new System.EventHandler(this.grdDmdSalesList_AfterRowActivate);
            this.grdDmdSalesList.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdDmdSalesList_InitializeRow);
            this.grdDmdSalesList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdDmdSalesList_KeyPress);
            this.grdDmdSalesList.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDmdSalesList_CellChange);
            this.grdDmdSalesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDmdSalesList_KeyDown);
            this.grdDmdSalesList.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.grdDmdSalesList_BeforeRowDeactivate);
            this.grdDmdSalesList.AfterCellActivate += new System.EventHandler(this.grdDmdSalesList_AfterCellActivate);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(5, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 5);
            this.panel1.TabIndex = 9;
            // 
            // panel_Nyu
            // 
            this.panel_Nyu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel_Nyu.Controls.Add(this.tEdit_SalesInputName);
            this.panel_Nyu.Controls.Add(this.uButton_SalesInputCode);
            this.panel_Nyu.Controls.Add(this.tEdit_EmployeeCode);
            this.panel_Nyu.Controls.Add(this.uLabel_SalesInputCodeTitle);
            this.panel_Nyu.Controls.Add(this.edtOutline);
            this.panel_Nyu.Controls.Add(this.ultraLabel17);
            this.panel_Nyu.Controls.Add(this.tNedit_SelectedDepositTotal);
            this.panel_Nyu.Controls.Add(this.ultraLabel16);
            this.panel_Nyu.Controls.Add(this.edtFeeDeposit);
            this.panel_Nyu.Controls.Add(this.ultraLabel8);
            this.panel_Nyu.Controls.Add(this.dateDraftPayTimeLimit);
            this.panel_Nyu.Controls.Add(this.ultraLabel14);
            this.panel_Nyu.Controls.Add(this.cmbMoneyKind);
            this.panel_Nyu.Controls.Add(this.ultraLabel12);
            this.panel_Nyu.Controls.Add(this.ultraLabel10);
            this.panel_Nyu.Controls.Add(this.edtDepositDate);
            this.panel_Nyu.Controls.Add(this.tShape2);
            this.panel_Nyu.Controls.Add(this.panel2);
            this.panel_Nyu.Controls.Add(this.tShape1);
            this.panel_Nyu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Nyu.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.panel_Nyu.Location = new System.Drawing.Point(5, 117);
            this.panel_Nyu.Name = "panel_Nyu";
            this.panel_Nyu.Size = new System.Drawing.Size(982, 140);
            this.panel_Nyu.TabIndex = 10;
            // 
            // edtOutline
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtOutline.ActiveAppearance = appearance87;
            appearance142.ForeColorDisabled = System.Drawing.Color.Black;
            this.edtOutline.Appearance = appearance142;
            this.edtOutline.AutoSelect = true;
            this.edtOutline.DataText = "";
            this.edtOutline.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            //this.edtOutline.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));// DEL 董桂鈺 2013/02/17 for Redmine#33921
            // --- ADD 董桂鈺 2013/02/17 for Redmine#33921 --->>>>>>
            //入金の摘要欄に半角カタカナを入力できるように修正
            this.edtOutline.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            // --- ADD 董桂鈺 2013/02/17 for Redmine#33921 ---<<<<<<
            this.edtOutline.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.edtOutline.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtOutline.Location = new System.Drawing.Point(425, 39);
            this.edtOutline.MaxLength = 40;
            this.edtOutline.Name = "edtOutline";
            this.edtOutline.Size = new System.Drawing.Size(547, 24);
            this.edtOutline.TabIndex = 23;
            // 
            // ultraLabel17
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance72;
            this.ultraLabel17.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel17.Location = new System.Drawing.Point(345, 39);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel17.TabIndex = 903;
            this.ultraLabel17.Text = "摘要";
            // 
            // tNedit_SelectedDepositTotal
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.tNedit_SelectedDepositTotal.ActiveAppearance = appearance13;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance61.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextHAlignAsString = "Right";
            this.tNedit_SelectedDepositTotal.Appearance = appearance61;
            this.tNedit_SelectedDepositTotal.AutoSelect = true;
            this.tNedit_SelectedDepositTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tNedit_SelectedDepositTotal.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SelectedDepositTotal.DataText = "";
            this.tNedit_SelectedDepositTotal.Enabled = false;
            this.tNedit_SelectedDepositTotal.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SelectedDepositTotal.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SelectedDepositTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_SelectedDepositTotal.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SelectedDepositTotal.Location = new System.Drawing.Point(761, 73);
            this.tNedit_SelectedDepositTotal.MaxLength = 14;
            this.tNedit_SelectedDepositTotal.Name = "tNedit_SelectedDepositTotal";
            this.tNedit_SelectedDepositTotal.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SelectedDepositTotal.Size = new System.Drawing.Size(129, 24);
            this.tNedit_SelectedDepositTotal.TabIndex = 14;
            this.tNedit_SelectedDepositTotal.TabStop = false;
            // 
            // ultraLabel16
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance53;
            this.ultraLabel16.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel16.Location = new System.Drawing.Point(617, 73);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(138, 24);
            this.ultraLabel16.TabIndex = 901;
            this.ultraLabel16.Text = "選択合計入金額";
            // 
            // edtFeeDeposit
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance73.TextHAlignAsString = "Right";
            this.edtFeeDeposit.ActiveAppearance = appearance73;
            appearance74.ForeColor = System.Drawing.Color.Black;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            appearance74.TextHAlignAsString = "Right";
            this.edtFeeDeposit.Appearance = appearance74;
            this.edtFeeDeposit.AutoSelect = true;
            this.edtFeeDeposit.CalcSize = new System.Drawing.Size(172, 200);
            this.edtFeeDeposit.DataText = "";
            this.edtFeeDeposit.Enabled = false;
            this.edtFeeDeposit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtFeeDeposit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.edtFeeDeposit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.edtFeeDeposit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.edtFeeDeposit.Location = new System.Drawing.Point(425, 73);
            this.edtFeeDeposit.MaxLength = 13;
            this.edtFeeDeposit.Name = "edtFeeDeposit";
            this.edtFeeDeposit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.edtFeeDeposit.Size = new System.Drawing.Size(129, 24);
            this.edtFeeDeposit.TabIndex = 13;
            this.edtFeeDeposit.Leave += new System.EventHandler(this.edtFeeDeposit_Leave);
            // 
            // ultraLabel8
            // 
            appearance75.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance75;
            this.ultraLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(345, 73);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel8.TabIndex = 900;
            this.ultraLabel8.Text = "手数料";
            // 
            // dateDraftPayTimeLimit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.dateDraftPayTimeLimit.ActiveEditAppearance = appearance14;
            this.dateDraftPayTimeLimit.BackColor = System.Drawing.Color.Transparent;
            this.dateDraftPayTimeLimit.CalendarDisp = true;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.dateDraftPayTimeLimit.EditAppearance = appearance15;
            this.dateDraftPayTimeLimit.Enabled = false;
            this.dateDraftPayTimeLimit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.dateDraftPayTimeLimit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.dateDraftPayTimeLimit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.dateDraftPayTimeLimit.LabelAppearance = appearance16;
            this.dateDraftPayTimeLimit.Location = new System.Drawing.Point(102, 107);
            this.dateDraftPayTimeLimit.Name = "dateDraftPayTimeLimit";
            this.dateDraftPayTimeLimit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.dateDraftPayTimeLimit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.dateDraftPayTimeLimit.Size = new System.Drawing.Size(172, 24);
            this.dateDraftPayTimeLimit.TabIndex = 22;
            this.dateDraftPayTimeLimit.TabStop = true;
            // 
            // ultraLabel14
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance59;
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel14.Location = new System.Drawing.Point(5, 107);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(104, 24);
            this.ultraLabel14.TabIndex = 900;
            this.ultraLabel14.Text = "期日";
            // 
            // cmbMoneyKind
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.cmbMoneyKind.ActiveAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.cmbMoneyKind.Appearance = appearance28;
            this.cmbMoneyKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.cmbMoneyKind.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbMoneyKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.cmbMoneyKind.ItemAppearance = appearance62;
            this.cmbMoneyKind.Location = new System.Drawing.Point(102, 73);
            this.cmbMoneyKind.Name = "cmbMoneyKind";
            this.cmbMoneyKind.Size = new System.Drawing.Size(200, 24);
            this.cmbMoneyKind.TabIndex = 12;
            this.cmbMoneyKind.ValueChanged += new System.EventHandler(this.cmbMoneyKind_ValueChanged);
            // 
            // ultraLabel12
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance52;
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(5, 73);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel12.TabIndex = 900;
            this.ultraLabel12.Text = "入金金種";
            // 
            // ultraLabel10
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance51;
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(5, 39);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(80, 24);
            this.ultraLabel10.TabIndex = 900;
            this.ultraLabel10.Text = "入金日";
            // 
            // edtDepositDate
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtDepositDate.ActiveEditAppearance = appearance29;
            this.edtDepositDate.BackColor = System.Drawing.Color.Transparent;
            this.edtDepositDate.CalendarDisp = true;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.TextHAlignAsString = "Left";
            appearance30.TextVAlignAsString = "Middle";
            this.edtDepositDate.EditAppearance = appearance30;
            this.edtDepositDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.edtDepositDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtDepositDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance31.TextHAlignAsString = "Left";
            appearance31.TextVAlignAsString = "Middle";
            this.edtDepositDate.LabelAppearance = appearance31;
            this.edtDepositDate.Location = new System.Drawing.Point(102, 39);
            this.edtDepositDate.Name = "edtDepositDate";
            this.edtDepositDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.edtDepositDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.edtDepositDate.Size = new System.Drawing.Size(172, 24);
            this.edtDepositDate.TabIndex = 11;
            this.edtDepositDate.TabStop = true;
            // 
            // tShape2
            // 
            this.tShape2.BackColor = System.Drawing.Color.Transparent;
            this.tShape2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tShape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tShape2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tShape2.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape2.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape2.Location = new System.Drawing.Point(0, 29);
            this.tShape2.Name = "tShape2";
            this.tShape2.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape2.Size = new System.Drawing.Size(982, 111);
            this.tShape2.TabIndex = 167;
            this.tShape2.Text = "tShape2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ultraLabel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 29);
            this.panel2.TabIndex = 217;
            // 
            // ultraLabel11
            // 
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance141.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance141.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance141.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance141.FontData.BoldAsString = "True";
            appearance141.ForeColor = System.Drawing.Color.Black;
            appearance141.TextHAlignAsString = "Center";
            appearance141.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance141;
            this.ultraLabel11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel11.Location = new System.Drawing.Point(0, 1);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(340, 24);
            this.ultraLabel11.TabIndex = 902;
            this.ultraLabel11.Text = "入金伝票入力";
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.Transparent;
            this.tShape1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tShape1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(0, 0);
            this.tShape1.Name = "tShape1";
            this.tShape1.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape1.Size = new System.Drawing.Size(982, 140);
            this.tShape1.TabIndex = 167;
            this.tShape1.Text = "tShape2";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 112);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(982, 5);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            this.splitter1.MouseLeave += new System.EventHandler(this.splitter1_MouseLeave);
            this.splitter1.MouseEnter += new System.EventHandler(this.splitter1_MouseEnter);
            // 
            // panel_Search
            // 
            this.panel_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel_Search.Controls.Add(this.tEdit_SalesSlipNum);
            this.panel_Search.Controls.Add(this.opsAlwcDmdSalesCall);
            this.panel_Search.Controls.Add(this.ultraLabel21);
            this.panel_Search.Controls.Add(this.btnCustomerGuid);
            this.panel_Search.Controls.Add(this.detSearchSlipDateEnd);
            this.panel_Search.Controls.Add(this.ultraLabel5);
            this.panel_Search.Controls.Add(this.detSearchSlipDateStart);
            this.panel_Search.Controls.Add(this.ultraLabel3);
            this.panel_Search.Controls.Add(this.ultraLabel2);
            this.panel_Search.Controls.Add(this.edtCustomerName);
            this.panel_Search.Controls.Add(this.tNedit_CustomerCode);
            this.panel_Search.Controls.Add(this.ultraLabel58);
            this.panel_Search.Controls.Add(this.tShape8);
            this.panel_Search.Controls.Add(this.panel3);
            this.panel_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.panel_Search.Location = new System.Drawing.Point(5, 5);
            this.panel_Search.Name = "panel_Search";
            this.panel_Search.Size = new System.Drawing.Size(982, 107);
            this.panel_Search.TabIndex = 0;
            // 
            // tEdit_SalesSlipNum
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.TextHAlignAsString = "Right";
            this.tEdit_SalesSlipNum.ActiveAppearance = appearance32;
            appearance33.BackColor = System.Drawing.Color.White;
            this.tEdit_SalesSlipNum.Appearance = appearance33;
            this.tEdit_SalesSlipNum.AutoSelect = true;
            this.tEdit_SalesSlipNum.BackColor = System.Drawing.Color.White;
            this.tEdit_SalesSlipNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SalesSlipNum.DataText = "";
            this.tEdit_SalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SalesSlipNum.Location = new System.Drawing.Point(585, 39);
            this.tEdit_SalesSlipNum.MaxLength = 9;
            this.tEdit_SalesSlipNum.Name = "tEdit_SalesSlipNum";
            this.tEdit_SalesSlipNum.Size = new System.Drawing.Size( 82, 24 );
            this.tEdit_SalesSlipNum.TabIndex = 4;
            this.tEdit_SalesSlipNum.Leave += new System.EventHandler(this.tEdit_SalesSlipNum_Leave);
            // 
            // opsAlwcDmdSalesCall
            // 
            appearance60.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.opsAlwcDmdSalesCall.Appearance = appearance60;
            this.opsAlwcDmdSalesCall.BackColor = System.Drawing.SystemColors.Window;
            this.opsAlwcDmdSalesCall.BackColorInternal = System.Drawing.SystemColors.Window;
            this.opsAlwcDmdSalesCall.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.opsAlwcDmdSalesCall.ItemOrigin = new System.Drawing.Point(5, 2);
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "表示する";
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "表示しない";
            this.opsAlwcDmdSalesCall.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.opsAlwcDmdSalesCall.ItemSpacingVertical = 2;
            this.opsAlwcDmdSalesCall.Location = new System.Drawing.Point(773, 39);
            this.opsAlwcDmdSalesCall.Name = "opsAlwcDmdSalesCall";
            this.opsAlwcDmdSalesCall.Size = new System.Drawing.Size(205, 24);
            this.opsAlwcDmdSalesCall.TabIndex = 5;
            this.opsAlwcDmdSalesCall.TextIndentation = 5;
            // 
            // ultraLabel21
            // 
            appearance50.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance50;
            this.ultraLabel21.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(761, 73);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(18, 24);
            this.ultraLabel21.TabIndex = 900;
            this.ultraLabel21.Text = "～";
            // 
            // btnCustomerGuid
            // 
            this.btnCustomerGuid.Location = new System.Drawing.Point(151, 39);
            this.btnCustomerGuid.Name = "btnCustomerGuid";
            this.btnCustomerGuid.Size = new System.Drawing.Size(24, 24);
            this.btnCustomerGuid.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "得意先ガイド";
            this.ultraToolTip.SetUltraToolTip(this.btnCustomerGuid, ultraToolTipInfo1);
            this.btnCustomerGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnCustomerGuid.Click += new System.EventHandler(this.btnCustomerGuid_Click);
            // 
            // detSearchSlipDateEnd
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.detSearchSlipDateEnd.ActiveEditAppearance = appearance34;
            this.detSearchSlipDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.detSearchSlipDateEnd.CalendarDisp = true;
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.detSearchSlipDateEnd.EditAppearance = appearance35;
            this.detSearchSlipDateEnd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detSearchSlipDateEnd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detSearchSlipDateEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance36.TextHAlignAsString = "Left";
            appearance36.TextVAlignAsString = "Middle";
            this.detSearchSlipDateEnd.LabelAppearance = appearance36;
            this.detSearchSlipDateEnd.Location = new System.Drawing.Point(785, 73);
            this.detSearchSlipDateEnd.Name = "detSearchSlipDateEnd";
            this.detSearchSlipDateEnd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detSearchSlipDateEnd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detSearchSlipDateEnd.Size = new System.Drawing.Size(172, 24);
            this.detSearchSlipDateEnd.TabIndex = 7;
            this.detSearchSlipDateEnd.TabStop = true;
            // 
            // ultraLabel5
            // 
            appearance49.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance49;
            this.ultraLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(510, 73);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(68, 24);
            this.ultraLabel5.TabIndex = 900;
            this.ultraLabel5.Text = "売上日";
            // 
            // detSearchSlipDateStart
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.detSearchSlipDateStart.ActiveEditAppearance = appearance37;
            this.detSearchSlipDateStart.BackColor = System.Drawing.Color.Transparent;
            this.detSearchSlipDateStart.CalendarDisp = true;
            appearance38.TextHAlignAsString = "Left";
            appearance38.TextVAlignAsString = "Middle";
            this.detSearchSlipDateStart.EditAppearance = appearance38;
            this.detSearchSlipDateStart.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detSearchSlipDateStart.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detSearchSlipDateStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance39.TextHAlignAsString = "Left";
            appearance39.TextVAlignAsString = "Middle";
            this.detSearchSlipDateStart.LabelAppearance = appearance39;
            this.detSearchSlipDateStart.Location = new System.Drawing.Point(582, 73);
            this.detSearchSlipDateStart.Name = "detSearchSlipDateStart";
            this.detSearchSlipDateStart.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detSearchSlipDateStart.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detSearchSlipDateStart.Size = new System.Drawing.Size(172, 24);
            this.detSearchSlipDateStart.TabIndex = 6;
            this.detSearchSlipDateStart.TabStop = true;
            // 
            // ultraLabel3
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance47;
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(510, 39);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(68, 24);
            this.ultraLabel3.TabIndex = 900;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // ultraLabel2
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance48;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(684, 39);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(81, 24);
            this.ultraLabel2.TabIndex = 900;
            this.ultraLabel2.Text = "引当済表示";
            // 
            // edtCustomerName
            // 
            this.edtCustomerName.ActiveAppearance = appearance11;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.edtCustomerName.Appearance = appearance17;
            this.edtCustomerName.AutoSelect = true;
            this.edtCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.edtCustomerName.DataText = "";
            this.edtCustomerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtCustomerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtCustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.edtCustomerName.Location = new System.Drawing.Point(178, 39);
            this.edtCustomerName.MaxLength = 12;
            this.edtCustomerName.Name = "edtCustomerName";
            this.edtCustomerName.ReadOnly = true;
            this.edtCustomerName.Size = new System.Drawing.Size(315, 24);
            this.edtCustomerName.TabIndex = 3;
            this.edtCustomerName.TabStop = false;
            // 
            // tNedit_CustomerCode
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.ActiveAppearance = appearance42;
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.Appearance = appearance71;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(74, 39);
            this.tNedit_CustomerCode.MaxLength = 9;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode.TabIndex = 1;
            this.tNedit_CustomerCode.Enter += new System.EventHandler(this.edtCustomerCode_Enter);
            // 
            // ultraLabel58
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel58.Appearance = appearance12;
            this.ultraLabel58.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(5, 39);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(52, 24);
            this.ultraLabel58.TabIndex = 900;
            this.ultraLabel58.Text = "得意先";
            // 
            // tShape8
            // 
            this.tShape8.BackColor = System.Drawing.Color.Transparent;
            this.tShape8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tShape8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tShape8.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape8.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape8.Location = new System.Drawing.Point(0, 29);
            this.tShape8.Name = "tShape8";
            this.tShape8.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape8.Size = new System.Drawing.Size(982, 78);
            this.tShape8.TabIndex = 165;
            this.tShape8.Text = "tShape1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNoDepSalList);
            this.panel3.Controls.Add(this.ultraLabel42);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 29);
            this.panel3.TabIndex = 8;
            // 
            // btnNoDepSalList
            // 
            this.btnNoDepSalList.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.btnNoDepSalList.Location = new System.Drawing.Point(456, 0);
            this.btnNoDepSalList.Name = "btnNoDepSalList";
            this.btnNoDepSalList.Size = new System.Drawing.Size(104, 25);
            this.btnNoDepSalList.TabIndex = 902;
            this.btnNoDepSalList.Text = "未入金一覧";
            this.btnNoDepSalList.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnNoDepSalList.Click += new System.EventHandler(this.btnNoDepSalList_Click);
            // 
            // ultraLabel42
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance43.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance43.FontData.BoldAsString = "True";
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Center";
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance43;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(0, 1);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(340, 24);
            this.ultraLabel42.TabIndex = 901;
            this.ultraLabel42.Text = "売上伝票 検索条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(352, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 25);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "検 索";
            this.btnSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel_Right
            // 
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Right.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_Right.Location = new System.Drawing.Point(987, 5);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(5, 580);
            this.panel_Right.TabIndex = 7;
            // 
            // panel_Left
            // 
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_Left.Location = new System.Drawing.Point(0, 5);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(5, 580);
            this.panel_Left.TabIndex = 6;
            // 
            // panel_Goukei
            // 
            this.panel_Goukei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel_Goukei.Controls.Add(this.tLine11);
            this.panel_Goukei.Controls.Add(this.labDepositTotal);
            this.panel_Goukei.Controls.Add(this.ultraLabel15);
            this.panel_Goukei.Controls.Add(this.btnAllAwl);
            this.panel_Goukei.Controls.Add(this.labDmdSalesList);
            this.panel_Goukei.Controls.Add(this.tLine10);
            this.panel_Goukei.Controls.Add(this.labSalesTotal);
            this.panel_Goukei.Controls.Add(this.ultraLabel13);
            this.panel_Goukei.Controls.Add(this.tLine12);
            this.panel_Goukei.Controls.Add(this.labSalesAllowanceTotal);
            this.panel_Goukei.Controls.Add(this.ultraLabel40);
            this.panel_Goukei.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Goukei.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.panel_Goukei.Location = new System.Drawing.Point(0, 585);
            this.panel_Goukei.Name = "panel_Goukei";
            this.panel_Goukei.Size = new System.Drawing.Size(992, 45);
            this.panel_Goukei.TabIndex = 25;
            // 
            // tLine11
            // 
            this.tLine11.BackColor = System.Drawing.Color.Transparent;
            this.tLine11.Location = new System.Drawing.Point(752, 42);
            this.tLine11.Name = "tLine11";
            this.tLine11.Size = new System.Drawing.Size(232, 8);
            this.tLine11.TabIndex = 203;
            this.tLine11.Text = "tLine11";
            // 
            // labDepositTotal
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.labDepositTotal.Appearance = appearance70;
            this.labDepositTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labDepositTotal.Location = new System.Drawing.Point(848, 18);
            this.labDepositTotal.Name = "labDepositTotal";
            this.labDepositTotal.Size = new System.Drawing.Size(136, 24);
            this.labDepositTotal.TabIndex = 900;
            // 
            // ultraLabel15
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance67;
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(760, 18);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel15.TabIndex = 900;
            this.ultraLabel15.Text = "入金合計";
            // 
            // btnAllAwl
            // 
            this.btnAllAwl.Location = new System.Drawing.Point(632, 19);
            this.btnAllAwl.Name = "btnAllAwl";
            this.btnAllAwl.Size = new System.Drawing.Size(104, 25);
            this.btnAllAwl.TabIndex = 26;
            this.btnAllAwl.Text = "一括引当";
            this.btnAllAwl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnAllAwl.Click += new System.EventHandler(this.btnAllAwl_Click);
            // 
            // labDmdSalesList
            // 
            this.labDmdSalesList.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labDmdSalesList.Location = new System.Drawing.Point(8, 0);
            this.labDmdSalesList.Name = "labDmdSalesList";
            this.labDmdSalesList.Size = new System.Drawing.Size(976, 16);
            this.labDmdSalesList.TabIndex = 900;
            // 
            // tLine10
            // 
            this.tLine10.BackColor = System.Drawing.Color.Transparent;
            this.tLine10.Location = new System.Drawing.Point(124, 42);
            this.tLine10.Name = "tLine10";
            this.tLine10.Size = new System.Drawing.Size(216, 8);
            this.tLine10.TabIndex = 192;
            this.tLine10.Text = "tLine10";
            // 
            // labSalesTotal
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.labSalesTotal.Appearance = appearance68;
            this.labSalesTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labSalesTotal.Location = new System.Drawing.Point(204, 18);
            this.labSalesTotal.Name = "labSalesTotal";
            this.labSalesTotal.Size = new System.Drawing.Size(136, 24);
            this.labSalesTotal.TabIndex = 900;
            // 
            // ultraLabel13
            // 
            appearance65.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance65;
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(132, 18);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel13.TabIndex = 900;
            this.ultraLabel13.Text = "売上合計";
            // 
            // tLine12
            // 
            this.tLine12.BackColor = System.Drawing.Color.Transparent;
            this.tLine12.Location = new System.Drawing.Point(356, 42);
            this.tLine12.Name = "tLine12";
            this.tLine12.Size = new System.Drawing.Size(264, 8);
            this.tLine12.TabIndex = 189;
            this.tLine12.Text = "tLine12";
            // 
            // labSalesAllowanceTotal
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.labSalesAllowanceTotal.Appearance = appearance69;
            this.labSalesAllowanceTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labSalesAllowanceTotal.Location = new System.Drawing.Point(484, 18);
            this.labSalesAllowanceTotal.Name = "labSalesAllowanceTotal";
            this.labSalesAllowanceTotal.Size = new System.Drawing.Size(136, 24);
            this.labSalesAllowanceTotal.TabIndex = 900;
            // 
            // ultraLabel40
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance66;
            this.ultraLabel40.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel40.Location = new System.Drawing.Point(364, 18);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(121, 24);
            this.ultraLabel40.TabIndex = 900;
            this.ultraLabel40.Text = "売上引当残合計";
            // 
            // panel_Heder
            // 
            this.panel_Heder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Heder.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_Heder.Location = new System.Drawing.Point(0, 0);
            this.panel_Heder.Name = "panel_Heder";
            this.panel_Heder.Size = new System.Drawing.Size(992, 5);
            this.panel_Heder.TabIndex = 5;
            // 
            // stbDmdSalesList
            // 
            this.stbDmdSalesList.Controls.Add(this.cmbFontSize);
            this.stbDmdSalesList.Controls.Add(this.ckdSalesAutoColumnSize);
            this.stbDmdSalesList.Controls.Add(this.ckdDetailDmdSalesList);
            this.stbDmdSalesList.Location = new System.Drawing.Point(0, 630);
            this.stbDmdSalesList.Name = "stbDmdSalesList";
            appearance44.FontData.Name = "ＭＳ ゴシック";
            appearance44.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance44;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel1.Width = 72;
            appearance45.FontData.Name = "ＭＳ ゴシック";
            appearance45.FontData.SizeInPoints = 9F;
            ultraStatusPanel2.Appearance = appearance45;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.cmbFontSize;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 40;
            appearance46.FontData.Name = "ＭＳ ゴシック";
            appearance46.FontData.SizeInPoints = 9F;
            ultraStatusPanel3.Appearance = appearance46;
            ultraStatusPanel3.Key = "line1";
            ultraStatusPanel3.Width = 1;
            appearance4.FontData.Name = "ＭＳ ゴシック";
            appearance4.FontData.SizeInPoints = 9F;
            ultraStatusPanel4.Appearance = appearance4;
            ultraStatusPanel4.Control = this.ckdSalesAutoColumnSize;
            ultraStatusPanel4.Key = "AutoCol";
            ultraStatusPanel4.Padding = new System.Drawing.Size(5, 0);
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 170;
            appearance5.FontData.Name = "ＭＳ ゴシック";
            appearance5.FontData.SizeInPoints = 9F;
            ultraStatusPanel5.Appearance = appearance5;
            ultraStatusPanel5.Key = "line2";
            ultraStatusPanel5.Width = 1;
            appearance6.FontData.Name = "ＭＳ ゴシック";
            appearance6.FontData.SizeInPoints = 9F;
            ultraStatusPanel6.Appearance = appearance6;
            ultraStatusPanel6.Control = this.ckdDetailDmdSalesList;
            ultraStatusPanel6.Key = "Detail";
            ultraStatusPanel6.Padding = new System.Drawing.Size(5, 0);
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            appearance7.FontData.Name = "ＭＳ ゴシック";
            appearance7.FontData.SizeInPoints = 9F;
            ultraStatusPanel7.Appearance = appearance7;
            ultraStatusPanel7.Key = "line3";
            ultraStatusPanel7.Width = 1;
            appearance8.FontData.Name = "ＭＳ ゴシック";
            appearance8.FontData.SizeInPoints = 9F;
            ultraStatusPanel8.Appearance = appearance8;
            ultraStatusPanel8.Key = "SeparateCost";
            ultraStatusPanel8.Padding = new System.Drawing.Size(5, 0);
            ultraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel8.Width = 125;
            this.stbDmdSalesList.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8});
            this.stbDmdSalesList.Size = new System.Drawing.Size(992, 28);
            this.stbDmdSalesList.TabIndex = 900;
            this.stbDmdSalesList.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ultraToolTip
            // 
            this.ultraToolTip.ContainingControl = this;
            this.ultraToolTip.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ultraToolTipGrid
            // 
            this.ultraToolTipGrid.ContainingControl = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tEdit_SalesInputName
            // 
            this.tEdit_SalesInputName.ActiveAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tEdit_SalesInputName.Appearance = appearance41;
            this.tEdit_SalesInputName.AutoSelect = true;
            this.tEdit_SalesInputName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tEdit_SalesInputName.DataText = "";
            this.tEdit_SalesInputName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SalesInputName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.tEdit_SalesInputName.Location = new System.Drawing.Point(479, 107);
            this.tEdit_SalesInputName.MaxLength = 12;
            this.tEdit_SalesInputName.Name = "tEdit_SalesInputName";
            this.tEdit_SalesInputName.ReadOnly = true;
            this.tEdit_SalesInputName.Size = new System.Drawing.Size(175, 24);
            this.tEdit_SalesInputName.TabIndex = 25;
            this.tEdit_SalesInputName.TabStop = false;
            // 
            // uButton_SalesInputCode
            // 
            appearance187.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance187.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesInputCode.Appearance = appearance187;
            this.uButton_SalesInputCode.Location = new System.Drawing.Point(656, 107);
            this.uButton_SalesInputCode.Name = "uButton_SalesInputCode";
            this.uButton_SalesInputCode.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesInputCode.TabIndex = 26;
            ultraToolTipInfo2.ToolTipText = "発行者ガイド";
            this.ultraToolTip.SetUltraToolTip(this.uButton_SalesInputCode, ultraToolTipInfo2);
            this.uButton_SalesInputCode.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesInputCode.Click += new System.EventHandler(this.uButton_SalesInputCode_Click);
            // 
            // tEdit_EmployeeCode
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode.ActiveAppearance = appearance105;
            this.tEdit_EmployeeCode.AutoSelect = true;
            this.tEdit_EmployeeCode.DataText = "";
            this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_EmployeeCode.Location = new System.Drawing.Point(425, 107);
            this.tEdit_EmployeeCode.MaxLength = 4;
            this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_EmployeeCode.TabIndex = 24;
            // 
            // uLabel_SalesInputCodeTitle
            // 
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            appearance106.TextVAlignAsString = "Middle";
            this.uLabel_SalesInputCodeTitle.Appearance = appearance106;
            this.uLabel_SalesInputCodeTitle.Location = new System.Drawing.Point(345, 107);
            this.uLabel_SalesInputCodeTitle.Name = "uLabel_SalesInputCodeTitle";
            this.uLabel_SalesInputCodeTitle.Size = new System.Drawing.Size(52, 24);
            this.uLabel_SalesInputCodeTitle.TabIndex = 1346;
            this.uLabel_SalesInputCodeTitle.Text = "発行者";
            // 
            // SFUKK01406UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(992, 658);
            this.Controls.Add(this.SFUKK01406UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK01406UA";
            this.Text = "入金伝票入力(売上指定型)";
            this.Load += new System.EventHandler(this.SFUKK01406UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFontSize)).EndInit();
            this.SFUKK01406UA_Fill_Panel.ResumeLayout(false);
            this.panel_SFUKK01406UA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDmdSalesList)).EndInit();
            this.panel_Nyu.ResumeLayout(false);
            this.panel_Nyu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOutline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SelectedDepositTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFeeDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneyKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            this.panel_Search.ResumeLayout(false);
            this.panel_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsAlwcDmdSalesCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape8)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel_Goukei.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tLine11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine12)).EndInit();
            this.stbDmdSalesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public bool RenewalButton
        {
            get { return _btnRenewal; }
        }

        public void RenewalProc()
        {
            TMsgDisp.Show(this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          "最新情報を取得しました。",
                          0,
                          MessageBoxButtons.OK);
        }

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// 伝票呼出
        /// </summary>
        /// <br>Note       : 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        public void ReadSlipProc()
        {
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<

		# region Public Delegate Event
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。
		///        　　　    (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public event ParentToolbarDepositSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// 選択拠点取得イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public event GetDepositSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

        /// <summary>
        /// 計上拠点取得イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : メインにて取得した計上拠点名称をフレームに渡す</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        public event HandOverDepositAddUpSecNameEventHandler HandOverAddUpSecNameEvent;
		# endregion

		# region Private const Menbers
		/// <summary>画面状態保持ＸＭＬファイル</summary>
		private const string ctDisplayInfoFileNm = "\\SFUKK01406UA_State.dat";

		/// <summary>グリッド設定ファイル</summary>
		private const string ctGridInfoFileNm = "SFUKK01406UA.dat";

        // ↓ 20070130 18322 a MA.NS用に変更
        /// <summary>番号管理No（受注番号）</summary>
        private const Int32 ctNoCodeAcceptAnOrderNo = 5;
        /// <summary>番号管理No（売上伝票番号）</summary>
        private const Int32 ctNoCodeSalesSlipNum    = 1200;
        // ↑ 20070130 18322 a
		# endregion

		# region Private Menbers
		/// <summary>入金引当表示クラス</summary>
		private SFUKK01415UA sfukk01415UA;

		/// <summary>入金伝票入力設定データ系アクセスクラス</summary>
		private DepositRelDataAcs depositRelDataAcs;

		/// <summary>入金伝票入力画面(受注指定型)アクセスクラス</summary>
		private InputDepositSalesTypeAcs inputDepositSalesTypeAcs;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;  //2007.10.09 add

        // ↓ 20070519 18322 d AA会場は使用しないので削除(SFTOK09242A or SFTOK01180U)
		///// <summary>得意先テーブルアクセスクラス</summary>
		//private CustomerInfoSetAcs customerAcs;
        // ↑ 20070519 18322 d

        // ↓ 20070219 18322 c MA.NS用に変更
		///// <summary>得意先ガイドクラス</summary>
		//private CustomerSearchGuide customerSearchGuide;

		/// <summary>得意先情報クラス</summary>
   		private CustomerInfoAcs _customerInfoAcs;
        // ↑ 20070219 18322 c

        // 2007.10.09 hikita del start -------------------------------------------------------->>
        ///// <summary>クレジット会社テーブルアクセスクラス</summary>
        //private CreditCmpAcs creditCmpAcs;  // (SFMIT09182A.DLL)
        ///// <summary>従業員テーブルアクセスクラス</summary>
        //private EmployeeAcs employeeAcs;
        // 2007.10.09 hikita  del end ---------------------------------------------------------<<

        // 2007.10.09 hikita add start --------------------------------------------------------->>
        private UserGuideAcs _userGuideAcs;
        // 2007.10.09 hikita add end -----------------------------------------------------------<<

        // ↓ 20070519 18322 d 今のところ使用しないので削除
		///// <summary>領収書印刷クラス</summary>
		//private SFUKK01502UA sfukk01502UA;
        // ↑ 20070519 18322 d

		/// <summary>グリッド設定制御クラス</summary>
		private GridStateController _gridStateController;

		/// <summary>受注引当グリッド選択行</summary>
		private DataRow selectedDmdSalesRow;

		/// <summary>更新完了フラグ</summary>
		private bool updateComplete;

		/// <summary>企業コード</summary>
		private string enterpriseCode;

		/// <summary>ログイン担当者</summary>
		private Employee employee;

        /// <summary>請求先コード</summary>
        private int claimCode;

		/// <summary>選択拠点</summary>
		private string selectSectionCode;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>得意先名称取得スレッド</summary>
		private Thread customerNamePrcThread;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // 2007.10.09 hikita del start -------------------------------------------------------->>
        ///// <summary>クレジット会社名称(受注検索欄)取得スレッド</summary>
        //private Thread creditCompanyNamePrcThread;
        ///// <summary>販売従業員名称取得スレッド</summary>
        //private Thread salesEmployeeNamePrcThread;
        ///// <summary>クレジット会社名称(入金伝票入力欄)取得スレッド</summary>
        //private Thread creditCompanyName2PrcThread;
        // 2007.10.09 hikita  del end ---------------------------------------------------------<<

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.09 hikita add start -------------------------------------------------------->>
        /// <summary>銀行名称取得スレッド</summary>
        private Thread bankNamePrcThread;
        // 2007.10.09 hikita add end ----------------------------------------------------------<<
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>画面状態保持クラス</summary>
		private SFUKK01406UA_DisplayInfo _displayStatus;

		/// <summary>新規ボタン プロパティ用</summary>
		private bool _buttonNew;

		/// <summary>保存ボタン プロパティ用</summary>
		private bool _buttonSave;
		
		/// <summary>削除ボタン プロパティ用</summary>
		private bool _buttonDelete;
		
		/// <summary>赤伝ボタン プロパティ用</summary>
		private bool _buttonAka;

        private bool _btnRenewal;

        // ↓ 20070131 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070131 18322 a

		/// <summary>領収書発行ボタン プロパティ用</summary>
		private bool _buttonReceiptPrint;

        /// <summary>伝票呼出ボタン プロパティ用</summary>
        private bool _buttonReadSlip; //ADD 王君 2012/12/24 Redmine#33741

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>得意先コード(前回値)</summary>
        private Int32 _prevCustomerCode = 0;

        ///// <summary>銀行コード(前回値)</summary>
        //private Int32 _prevBankCode = 0;

        /// <summary>得意先ガイド選択フラグ</summary>
        private bool _cusotmerGuideSelected;

        /// <summary>入金消込区分</summary>
        private int _depoDelCode;

        // 得意先コード
        private int _customerCode;

        private bool _searchFlg;

        // 消費税転嫁方式(0:伝票単位 1:明細単位 2:請求親 3:請求子 9:非課税)
        private int _consTaxLayMethod;
        private int _consTaxLayCustomerCode;
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ----- ADD 2012/09/21 田建委 redmine#32415 ----------->>>>>
        /// <summary>発行者コード</summary>
        private string _swSalesInputCode = string.Empty;
        /// <summary>発行者名</summary>
        private string _swSalesInputName = string.Empty;
        /// <summary>SFTOK09382A)従業員</summary>
        private EmployeeAcs _employeeAcs;
        // ----- ADD 2012/09/21 田建委 redmine#32415 -----------<<<<<

        // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>

        /// <summary>入金更新アクセスクラス</summary>
        private DepsitMainAcs _depsitMainAcs;
        /// <summary>前回月次締日</summary>
        private DateTime _lastMonthlyAddUpDay;
        /// <summary>前回締日</summary>
        private DateTime _lastAddUpDay;
        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;
        // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<
        // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ---->>>>>
        /// <summary>一括引当フラグ</summary>
        private bool _subflag = false;
        // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ----<<<<<
        // ADD 2009/04/14 不具合対応[12908]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>引当済表示ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _alwcDmdSalesCallRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 引当済表示ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>引当済表示ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper AlwcDmdSalesCallRadioKeyPressHelper
        {
            get { return _alwcDmdSalesCallRadioKeyPressHelper; }
        }
        // ADD 2009/04/14 不具合対応[12908]：スペースキーでの項目選択機能を実装 ----------<<<<<

        // --- ADD m.suzuki 2010/07/01 ---------->>>>>
        /// <summary>
        /// 操作権限の制御オブジェクト
        /// </summary>
        private IOperationAuthority _operationAuthorityForNoDepSalList;
        /// <summary>
        /// 操作権限の制御オブジェクト（未入金一覧表）
        /// </summary>
        private IOperationAuthority MyOpeCtrlForNoDepSalList
        {
            get
            {
                if ( _operationAuthorityForNoDepSalList == null )
                {
                    _operationAuthorityForNoDepSalList = new OperationAuthorityImpl( Broadleaf.Application.Controller.Util.EntityUtil.CategoryCode.Report, "PMKAU02000U", this );
                }
                return _operationAuthorityForNoDepSalList;
            }
        }
        // --- ADD m.suzuki 2010/07/01 ----------<<<<<
        # endregion

		# region Public Property
		/// <summary>新規ボタン プロパティ</summary>
		public bool NewButton
		{
			get{return _buttonNew;}
		}

		/// <summary>保存ボタン プロパティ</summary>
		public bool SaveButton
		{
			get{return _buttonSave;}
		}
		
		/// <summary>削除ボタン プロパティ</summary>
		public bool DeleteButton
		{
			get{return _buttonDelete;}
		}
		
		/// <summary>赤伝ボタン プロパティ</summary>
		public bool AkaButton
		{
			get{return _buttonAka;}
		}

		/// <summary>領収書発行ボタン プロパティ</summary>
		public bool ReceiptPrintButton
		{
			get { return _buttonReceiptPrint; }

		}

        // ---- ADD 王君 2012/12/24 Redmine#33741 ----->>>>> 
        /// <summary>伝票呼出ボタン プロパティ</summary>
        public bool ReadSlipButton
        {
            get { return _buttonReadSlip; }
        }
        // ---- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
		# endregion
		
		# region public Methods
		/// <summary>
		/// 起動前処理
		/// </summary>
		/// <param name="parameter">起動モードパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ＭＤＩ子画面が起動する時に親から呼ばれます。</br>
		/// <br>    　　　    (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();

			// タイマー起動
			timer1.Enabled = true;
		}

		/// <summary>
		/// 表示通知処理
		/// </summary>
		/// <param name="mode">起動モード 0:得意先コード指定, 1:受注番号指定</param>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <returns>処理結果 0:OK, ≠0:NG</returns>
		/// <remarks>
		/// <br>Note        : ＭＤＩ親画面から表示指示を行った場合に発生するイベント</br>
		/// <br>    　　　    (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int ShowData(int mode, object[] parameter)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			// 対応モード以外は処理を抜ける
			if ((mode != 0) && (mode != 1))
			{
				return st;
			}

			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return 0;
			}

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 新規入力準備処理
				this.NewInputStandby();

				// データ検索前の画面設定処理
				this.SearchBeforeDisplySetting();

                int customerCode = (int)parameter[0];

                this.tNedit_CustomerCode.SetInt(customerCode);

                // 管理拠点コード取得(得意先マスタ)
                CustomerInfo customerInfo;
                int status = GetCustomerInfo(out customerInfo, customerCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先略称取得
                    this.edtCustomerName.DataText = customerInfo.CustomerSnm.Trim();

                    bool bStatus = CheckClaimCode(customerInfo);
                    if (!bStatus)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              "請求先に変更しました。",
                                              0,
                                              MessageBoxButtons.OK);

                        // 得意先コード
                        this._customerCode = customerInfo.CustomerCode;

                        status = ChangeCustomerCode(customerInfo.ClaimCode);
                        if (status != 0)
                        {
                            this.tNedit_CustomerCode.Focus();
                            return (-1);
                        }

                    }
                    else
                    {
                        if (customerInfo.DepoDelCode == 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "得意先マスタの入金消込区分が設定されていません。",
                                          0,
                                          MessageBoxButtons.OK);

                            this.tNedit_CustomerCode.Clear();
                            this.edtCustomerName.Clear();

                            this.tNedit_CustomerCode.Focus();
                            return (-1);
                        }

                        if (this._consTaxLayCustomerCode != customerInfo.CustomerCode)
                        {
                            if ((customerInfo.ConsTaxLayMethod == 2) || (customerInfo.ConsTaxLayMethod == 3))
                            {
                                DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                                 this.Name,
                                                                 "指定得意先は請求時課税のユーザーです。" + "\r\n" + "売上引当を行うと消費税が合わなくなりますが、よろしいですか？",
                                                                 0,
                                                                 MessageBoxButtons.YesNo);

                                if (res == DialogResult.No)
                                {
                                    this.tNedit_CustomerCode.Clear();
                                    this.edtCustomerName.Clear();

                                    this.tNedit_CustomerCode.Focus();
                                    this._consTaxLayCustomerCode = 0;
                                    return (-1);
                                }

                                this._consTaxLayCustomerCode = customerInfo.CustomerCode;
                            }
                        }

                        // 請求先コード
                        this.claimCode = customerInfo.ClaimCode;

                        // 消費税転嫁方式
                        this._consTaxLayMethod = customerInfo.ConsTaxLayMethod;
                    }

                    // 得意先コード
                    this._customerCode = customerCode;

                    this._searchFlg = true;
                    this._prevCustomerCode = this.claimCode;
                }

				// 請求売上情報取得用パラメータ 作成処理
				InputDepositSalesTypeAcs.SearchSalesParameter searchSalesParameter = this.SetSalesParameter();

				switch (mode)
				{
					case 0 :		// --- 得意先コード指定 --- //

						// パラメータ取得
                        // ↓ 20070514 18322 c MA.NS用に変更
						//searchSalesParameter.AlwcDmdSalesCall		= 0;					// 引当済請求売上伝票呼出区分

						searchSalesParameter.AlwcSalesSlipCall		= 0;					// 引当済請求売上伝票呼出区分
                        // ↑ 20070514 18322 c

						searchSalesParameter.SearchSlipDateStart	= 0;					// 伝票日付 開始
						searchSalesParameter.CustomerCode			= (int)parameter[0];	// 得意先コード
                        searchSalesParameter.ClaimCode              = this.claimCode;       // 請求先コード
						break;

					case 1 :		// --- 受注番号指定 --- //

						// パラメータ取得
                        // ↓ 20070514 18322 c MA.NS用に変更
						//searchSalesParameter.AlwcDmdSalesCall		= 0;					// 引当済請求売上伝票呼出区分

						searchSalesParameter.AlwcSalesSlipCall		= 0;					// 引当済請求売上伝票呼出区分
                        // ↑ 20070514 18322 c
						searchSalesParameter.SearchSlipDateStart	= 0;					// 伝票日付 開始
						searchSalesParameter.CustomerCode			= (int)parameter[0];	// 得意先コード
                        searchSalesParameter.ClaimCode              = this.claimCode; ;     // 請求先コード 
                        searchSalesParameter.SalesSlipNum		    = (string)parameter[1];	// 売上番号
						break;
				}
				
                // ↓ 20070514 18322 a
                // サービス伝票区分(0:OFF,1:ON)
                searchSalesParameter.ServiceSlipCd = 0;
                // 売掛区分(0:売掛なし,1:売掛)
                searchSalesParameter.AccRecDivCd = -1;
                // 自動入金区分(0:通常入金,1:自動入金)
                searchSalesParameter.AutoDepositCd = -1;
                // ↑ 20070514 18322 a

				// 請求売上情報取得処理
				string message;
				st = inputDepositSalesTypeAcs.SearchDmdSales(searchSalesParameter, this._consTaxLayMethod, out message);

				// データ検索後の画面設定処理
				this.SearchAfterDisplySetting(st, searchSalesParameter);

				// 合計欄計算処理
				this.SetSalesTotal();

                for (int index = 0; index < this.grdDmdSalesList.Rows.Count; index++)
                {
                    CellsCollection cells = this.grdDmdSalesList.Rows[index].Cells;

                    // 赤伝の場合
                    if ((cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value != DBNull.Value) &&
                        (Convert.ToInt32(cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value) == 1))
                    {
                        for (int colIndex = 0; colIndex < cells.Count; colIndex++)
                        {
                            this.grdDmdSalesList.Rows[index].Appearance.ForeColor = Color.Red;
                            this.grdDmdSalesList.Rows[index].Appearance.ForeColorDisabled = Color.Red;
                        }
                        continue;
                    }

                    // 返品の場合
                    if ((cells[InputDepositSalesTypeAcs.ctSalesKind].Value != DBNull.Value) &&
                        (Convert.ToString(cells[InputDepositSalesTypeAcs.ctSalesKind].Value) == "返品"))
                    {
                        for (int colIndex = 0; colIndex < cells.Count; colIndex++)
                        {
                            this.grdDmdSalesList.Rows[index].Appearance.ForeColor = Color.Red;
                            this.grdDmdSalesList.Rows[index].Appearance.ForeColorDisabled = Color.Red;
                        }
                        continue;
                    }
                }

				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					// 請求売上が存在しなかった時
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, message, 0, MessageBoxButtons.OK);
                    // ↓ 20070130 18322 c MA.NS用に変更
					//cbxCorporateDiv1.Focus();

                    tNedit_CustomerCode.Focus();
                    // ↑ 20070130 18322 c

					// 受注引当一覧の行を非アクティブとする
					grdDmdSalesList.ActiveRow = null;
				}
				else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    // ↓ 20070130 18322 d MA.NS用に変更
					//// エラー発生
					//TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "受注伝票の読込処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);

					// エラー発生
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "売上伝票の読込処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    // ↑ 20070130 18322 d
				}
				else
				{
					// 受注引当一覧の１行目をアクティブとする
					grdDmdSalesList.Rows[0].Activate();

					edtDepositDate.Focus();
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return st;
		}

		/// <summary>
		/// タブ変更前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK</param>
		/// <param return="int">0≠NG</param>
		/// <returns>処理結果 0:OK, ≠0:NG</returns>
		/// <remarks>
		/// <br>Note       : タブ変更が行われる前に、変更を許可するかの判断を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{
			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return 1;
			}

            // ＸＭＬデータの保存処理
            this.SaveStateXmlData();
            
            return 0;
		}
		
		/// <summary>
		/// 拠点変更前通知処理
		/// </summary>
		/// <param return="int">0＝OK</param>
		/// <param return="int">0≠NG 拠点変更不可</param>
		/// <remarks>
		/// <br>Note       : 拠点変更時、変更を許可するかの判断を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return -1;
			}

			return 0;
		}

		/// <summary>
		/// 拠点変更後通知処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 拠点変更後の処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void AfterSectionChange()
		{
			// 選択拠点を取得
			if (GetSelectSectionCodeEvent != null) selectSectionCode = GetSelectSectionCodeEvent(this);

			// 入金伝票入力初期設定処理
			this.InputDepositInitialSetting();

			// 受注一覧初期設定処理
			this.DmdSalesListInitialSetting();

			tNedit_CustomerCode.Focus();
		}

		/// <summary>
		/// 終了前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <returns>処理結果 0:OK, ≠0:NG</returns>
		/// <remarks>
		/// <br>Note       : 終了する前に、変更を許可するかの判断を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return 1;
			}

            // ＸＭＬデータの保存処理
            this.SaveStateXmlData();
            
            return 0;
		}

		/// <summary>
		/// 新規処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新規入力処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void NewDepositProc()
		{
			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return;
			}

			// 新規入力準備処理
			this.NewInputStandby();
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 保存処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// <br>Update Note: 2013/01/09 董桂鈺 </br>
		/// <br>管理番号   : 10806793-00  2013/03/13配信分</br>
		/// <br>             Redmine#33921  データを保存後、摘要をクリアすることの追加</br>　
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
		/// </remarks>
		public void SaveDepositProc()
		{
			// 入金伝票保存処理
			if (this.SaveDeposit() == 0)
			{
				// 更新完了フラグ
				this.updateComplete = true;

				// 保存ボタン非アクティブ
				this._buttonSave	= false;

                this._btnRenewal = true;

				// 領収書発行ボタン プロパティ用
				this._buttonReceiptPrint = true;

                //伝票呼出ボタン プロパティ用
                this._buttonReadSlip = false;// ADD 王君 2012/12/24 Redmine#33741

				// 親にツールバー状態通知
				if (ParentToolbarSettingEvent != null) ParentToolbarSettingEvent(this);

				// 一括引当ボタン非アクティブ
				btnAllAwl.Enabled = false;

				// --- ADD 董桂鈺　2013/01/09  for Redmine#33921 ---->>>>>>>>>>>
				//摘要のクリア処理
				this.edtOutline.Text = string.Empty;
				// --- ADD 董桂鈺　2013/01/09  for Redmine#33921 ----<<<<<<<<<<<
                btnSearch_Click(this.btnSearch, new EventArgs());

                this.tNedit_CustomerCode.Focus();

                // --- ADD zhujw K2014/06/18 RedMine#42902 入金伝票入力登録後、クリアされない項目が存在する ------->>>>>
                if (this.inputDepositSalesTypeAcs.KaToOption())
                {
                    // 新規入力準備処理
                    this.NewInputStandby();
                }
                // --- ADD zhujw K2014/06/18 RedMine#42902 入金伝票入力登録後、クリアされない項目が存在する -------<<<<<
			}
		}

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 削除処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void DeleteDepositProc()
		{
            // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>
            // 入金伝票削除処理
            this.DeleteDeposit();
            // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 赤伝入力処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void AkaDepositProc()
		{
		}

		/// <summary>
		/// 領収書発行処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 領収書発行処理を行います。
		///                  (IDepositInputMDIChildインターフェースの実装)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void ReceiptPrintProc()
		{
			// 領収書発行処理
			this.ReceiptPrint();
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// メイン検索ボタン
			btnSearch.ImageList = imageList16;
			btnSearch.Appearance.Image = Size16_Index.SEARCH;
            // --- ADD m.suzuki 2010/07/01 ---------->>>>>
            // 未入金一覧表ボタン
            if ( CheckNoDepSalListEnabled() )
            {
                btnNoDepSalList.Visible = true;
                btnNoDepSalList.ImageList = imageList16;
                btnNoDepSalList.Appearance.Image = Size16_Index.PRINT;
            }
            else
            {
                btnNoDepSalList.Visible = false;
            }
            // --- ADD m.suzuki 2010/07/01 ----------<<<<<

            // ↓ 20070130 18322 d MA.NS用に変更
			//// AA会場ガイドボタン
			//btnCustomerAAGuid.ImageList = imageList16;
			//btnCustomerAAGuid.Appearance.Image = Size16_Index.STAR1;
            // ↑ 20070130 18322 d

			// 得意先ガイドボタン
			btnCustomerGuid.ImageList = imageList16;
			btnCustomerGuid.Appearance.Image = Size16_Index.STAR1;

            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            uButton_SalesInputCode.ImageList = imageList16;
            uButton_SalesInputCode.Appearance.Image = Size16_Index.STAR1;

            // 発行者初期化
            this.tEdit_EmployeeCode.Text = this.employee.EmployeeCode.Trim();
            this.tEdit_SalesInputName.Text = this.employee.Name.Trim();
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<

			// クレジット会社ガイド(受注検索欄)ボタン
            // 2007.10.09 hikita del start --------------------------------->>
            //btnCreditCompanyGuid.ImageList = imageList16;
            //btnCreditCompanyGuid.Appearance.Image = Size16_Index.STAR1;
            //// 従業員ガイドボタン
            //btnSalesEmployeeGuid.ImageList = imageList16;
            //btnSalesEmployeeGuid.Appearance.Image = Size16_Index.STAR1;
            ////クレジット会社ガイド(入金伝票入力欄)ボタン
            //btnCreditCompanyGuid2.ImageList = imageList16;
            //btnCreditCompanyGuid2.Appearance.Image = Size16_Index.STAR1;
            // 2007.10.09 hikita del end -----------------------------------<<

            //// 2007.10.09 hikita add start --------------------------------->>
            //// 銀行ガイドボタン
            //btnBankGuid.ImageList = imageList16;
            //btnBankGuid.Appearance.Image = Size16_Index.STAR1;
            //// 2007.10.09 hikita add end -----------------------------------<<

			// 一括引当ボタン
			btnAllAwl.ImageList = imageList16;
			btnAllAwl.Appearance.Image = Size16_Index.PACKAGEINPUT;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 諸費用別入金オプション判定
			if (depositRelDataAcs.OptSeparateCost == true)
			{
				// 受注引当グリッド諸費用別入金処理
				stbDmdSalesList.Panels["SeparateCost"].Visible = true;
				stbDmdSalesList.Panels["line3"].Visible = true;
			}
			else
			{
				// 受注引当グリッド諸費用別入金処理
				stbDmdSalesList.Panels["SeparateCost"].Visible = false;
				stbDmdSalesList.Panels["line3"].Visible = false;
			}
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 新規入力準備処理
			this.NewInputStandby();
		}

		/// <summary>
		/// 入金金種リスト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金金種リストの設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void MoneyKindSetting()
		{
			// 入金金種リストを設定
			cmbMoneyKind.Items.Clear();
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //for (int ix = 0; ix < depositRelDataAcs.SlMoneyKindCode.Count; ix++)
            //{
            //    cmbMoneyKind.Items.Add(depositRelDataAcs.SlMoneyKindCode.GetKey(ix), (string)depositRelDataAcs.SlMoneyKindCode.GetByIndex(ix));
            //}
            //// デフォルト金種をセット
            //cmbMoneyKind.Value = depositRelDataAcs.InitSelMoneyKindCd;
            foreach (int key in depositRelDataAcs.DicMoneyKindCode.Keys)
            {
                cmbMoneyKind.Items.Add(key, depositRelDataAcs.DicMoneyKindCode[key]);
            }
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// ＸＭＬデータの読込処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態保持用のＸＭＬの読込処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void LoadStateXmlData()
		{
			try
			{
				// グリッド設定ロード
				this._gridStateController.LoadGridState(ctGridInfoFileNm);

				// 画面状態保持クラスデシリアライズ
				this._displayStatus = null;
				if (UserSettingController.ExistUserSetting(ConstantManagement_ClientDirectory.UISettings_GridInfo + ctDisplayInfoFileNm))
				{
					this._displayStatus = UserSettingController.ByteDeserializeUserSetting<SFUKK01406UA_DisplayInfo>(ConstantManagement_ClientDirectory.UISettings_GridInfo + ctDisplayInfoFileNm);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// ＸＭＬデータの保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態保持用のＸＭＬの保存処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SaveStateXmlData()
		{
			try
			{
				// グリッド設定制御クラスにグリッド情報を展開
				this._gridStateController.GetGridStateFromGrid(ref grdDmdSalesList);

				// グリッド設定をファイルに保存
				this._gridStateController.SaveGridState(ctGridInfoFileNm);

				// 画面状態保持クラスへ画面状態セット処理
				this.SetDisplayStatus(ref this._displayStatus);

				// 画面状態保持クラスシリアライズ
				UserSettingController.ByteSerializeUserSetting(this._displayStatus, ConstantManagement_ClientDirectory.UISettings_GridInfo + ctDisplayInfoFileNm);
			}
			catch
			{
			}
		}

		/// <summary>
		/// 画面状態保持クラス画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態保持クラスの内容を展開します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void GetDisplayStatus(ref SFUKK01406UA_DisplayInfo displayStatus)
		{
			// 未インスタンス化の時（エラー時）新規扱いにする。
			if (displayStatus == null)
			{
				displayStatus = new SFUKK01406UA_DisplayInfo();

				// 詳細表示
				displayStatus.DetailDmdSalesList = 0;

                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
				// 諸費用別入金オプション判定
				if (depositRelDataAcs.OptSeparateCost == true)
				{
					// 受注一覧 諸費用別引当
					displayStatus.SeparateCost = 1;
				}
				else
				{
					// 受注一覧 諸費用別引当
					displayStatus.SeparateCost = 0;
				}
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            }

			// 詳細表示
			if (displayStatus.DetailDmdSalesList == 0)
			{
				ckdDetailDmdSalesList.Checked = false;
			}
			else
			{
				ckdDetailDmdSalesList.Checked = true;
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 諸費用別引当
			if (displayStatus.SeparateCost == 0)
			{
				ckdSeparateCost.Checked = false;
			}
			else
			{
				ckdSeparateCost.Checked = true;
			}
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// 画面状態保持クラスへ画面状態セット処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態保持クラスへ画面状態をセットします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetDisplayStatus(ref SFUKK01406UA_DisplayInfo displayStatus)
		{
			// 受注一覧 詳細表示
			if (ckdDetailDmdSalesList.Checked == false)
			{
				displayStatus.DetailDmdSalesList = 0;
			}
			else
			{
				displayStatus.DetailDmdSalesList = 1;
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 受注一覧 諸費用別引当
			if (ckdSeparateCost.Checked == false)
			{
				displayStatus.SeparateCost = 0;
			}
			else
			{
				displayStatus.SeparateCost = 1;
			}
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// 新規入力準備処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の新規入力準備処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void NewInputStandby()
		{
			// 条件入力初期設定処理
			this.ConditionInitialSetting();

			// 入金伝票入力初期設定処理
			this.InputDepositInitialSetting();

			// 受注一覧初期設定処理
			this.DmdSalesListInitialSetting();

			tNedit_CustomerCode.Focus();

            this._searchFlg = false;

            // データ検索後の画面設定処理
            this.SearchAfterDisplySetting(-1, null);
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 条件入力初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 条件入力欄の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private void ConditionInitialSetting()
        {
            // 得意先コード
            tNedit_CustomerCode.Text = "";
            edtCustomerName.Text = "";
            this._prevCustomerCode = 0;
            this._customerCode = 0;

            // 引当済入金伝票呼出区分
            opsAlwcDmdSalesCall.Value = depositRelDataAcs.AlwcDepositCall;

            // 伝票番号
            tEdit_SalesSlipNum.Text = "";

            // システムチェックボックスの表示位置
            SortedList itemLocationList = new SortedList();
            itemLocationList.Add(0, new Point(759, 62));
            itemLocationList.Add(1, new Point(823, 62));
            itemLocationList.Add(2, new Point(887, 62));

            // 伝票日付
            if (depositRelDataAcs.DepositCallMonths == 0)
            {
                detSearchSlipDateStart.SetLongDate(0);
            }
            else
            {
                detSearchSlipDateStart.SetLongDate(TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow().AddMonths(depositRelDataAcs.DepositCallMonths * -1)));
            }
            detSearchSlipDateEnd.Clear();
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 条件入力初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 条件入力欄の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void ConditionInitialSetting()
		{

            // ↓ 20070130 18322 c MA.NS用に変更
			//// 得意先区分設定
			//cbxCorporateDiv1.Checked = true;
			//cbxCorporateDiv2.Checked = true;
            // ↑ 20070130 18322 c

			// 得意先コード
			tNedit_CustomerCode.Text = "";
			edtCustomerName.Text = "";

            // 2007.10.09 hikita del start ----------------------------------->>
            //// クレジット区分設定
            //cbxCreditOrLoan1.Checked = true; 
            //cbxCreditOrLoan2.Checked = true;
            //cbxCreditOrLoan3.Checked = true;
            //// クレジットコード
            //edtCreditCompanyCode.Text = "";
            //edtCreditCompanyName.Text = "";
            //// 従業員コード
            //edtSalesEmployee.Text = "";
            //edtSalesEmployeeName.Text = "";
            // 2007.10.09 hikita del end -------------------------------------<<

			// 引当済入金伝票呼出区分
			opsAlwcDmdSalesCall.Value = depositRelDataAcs.AlwcDepositCall;

			// 伝票番号
			tEdit_SalesSlipNum.Text = "";

			// 受注ステータス
            //cbxAcptAnOdrStartus1.Checked = true;
            //cbxAcptAnOdrStartus2.Checked = true;
            //cbxAcptAnOdrStartus3.Checked = true;

			// システムチェックボックスの表示位置
			SortedList itemLocationList = new SortedList();
			itemLocationList.Add(0, new Point(759, 62));
			itemLocationList.Add(1, new Point(823, 62));
			itemLocationList.Add(2, new Point(887, 62));

            // ↓ 20070130 18322 d MA.NS用に変更
            #region SF システム導入チェック（全てコメントアウト）
            //// SFシステム導入チェック
			//cbxDataInputSystem1.Checked		= false;
			//cbxDataInputSystem1.Visible		= false;
			//if (depositRelDataAcs.IntroducedSystemSF == true)
			//{
			//	if (itemLocationList.GetByIndex(0) is Point)
			//	{
			//		cbxDataInputSystem1.Location	= (Point)itemLocationList.GetByIndex(0);
			//		cbxDataInputSystem1.Checked		= true;
			//		cbxDataInputSystem1.Visible		= true;
			//		itemLocationList.RemoveAt(0);
			//	}
			//}
			//
			//// BKシステム導入チェック
			//cbxDataInputSystem2.Checked		= false;
			//cbxDataInputSystem2.Visible		= false;
			//if (depositRelDataAcs.IntroducedSystemBK == true)
			//{
			//	if (itemLocationList.GetByIndex(0) is Point)
			//	{
			//		cbxDataInputSystem2.Location	= (Point)itemLocationList.GetByIndex(0);
			//		cbxDataInputSystem2.Checked		= true;
			//		cbxDataInputSystem2.Visible		= true;
			//		itemLocationList.RemoveAt(0);
			//	}
			//}
			//
			//// CSシステム導入チェック
			//cbxDataInputSystem3.Checked		= false;
			//cbxDataInputSystem3.Visible		= false;
			//if (depositRelDataAcs.IntroducedSystemCS == true)
			//{
			//	if (itemLocationList.GetByIndex(0) is Point)
			//	{
			//		cbxDataInputSystem3.Location	= (Point)itemLocationList.GetByIndex(0);
			//		cbxDataInputSystem3.Checked		= true;
			//		cbxDataInputSystem3.Visible		= true;
			//		itemLocationList.RemoveAt(0);
			//	}
			//}
			//
			//// 導入システム数により表示切替
			//switch (depositRelDataAcs.IntroducedSystemCount)
			//{
			//	case 0 :
			//	case 1 :
			//		cbxDataInputSystem1.Visible		= false;
			//		cbxDataInputSystem2.Visible		= false;
			//		cbxDataInputSystem3.Visible		= false;
			//		linSystem.Width					= 0;
			//		break;
			//	case 2:
			//		linSystem.Width					= 128;
			//		break;
			//	case 3:
			//		linSystem.Width					= 200;
			//		break;
			//}
            #endregion
            // ↑ 20070130 18322 c

            // 2007.10.09 hikita del start ------------------------------------>>
            //// 受注日
            // detAcceptAnOrderDateStart.Clear();
			// detAcceptAnOrderDateEnd.Clear();
            // 2007.10.09 hikita del end --------------------------------------<<

			// 伝票日付
			if (depositRelDataAcs.DepositCallMonths == 0)
			{
				detSearchSlipDateStart.SetLongDate(0);
			}
			else
			{
				detSearchSlipDateStart.SetLongDate(TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow().AddMonths(depositRelDataAcs.DepositCallMonths * -1)));
			}
			detSearchSlipDateEnd.Clear();

            // 2007.10.09 hikita del start ------------------------------------>>
            //// 計上日
            // detAddUpADateStart.Clear();
			// detAddUpADateEnd.Clear();
            // 2007.10.09 hikita del end --------------------------------------<<
		}
		   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 入金伝票入力設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金伝票入力欄の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// <br>Update Note: 2013/01/09 董桂鈺 </br>
		/// <br>管理番号   : 10806793-00  2013/03/13配信分</br>
		/// <br>             Redmine#33921 新規の場合に、期日、摘要の設定処理の追加</br>
		/// </remarks>
		private void InputDepositInitialSetting()
		{
			// 入金日
			edtDepositDate.SetLongDate(TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow()));

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 預り金区分
			opsDepositDiv.CheckedIndex = 0;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 入金金種リスト設定処理
			this.MoneyKindSetting();

            // 2007.10.09 hikita del start ------------------------------>>
            //// クレジット区分
            //cmbCreditOrLoanCd.Value = 0;  
            //// クレジットコード
            //edtCreditCompanyCode2.Text = "";
            //edtCreditCompanyName2.Text = "";
            // 2007.10.09 hikita del end --------------------------------<<

            // 2007.10.09 hikita add start ------------------------------>>
            //// 銀行コード
            //tNedit_BankCode.Clear();
            //teditBankName.Text = "";

            //// 振出日
            //dateDraftDrawingDate.Clear();

            //// 手形番号
            //tEdit_DraftNo.Text = "";

            //// 手形種類
            //cmbDraftKind.Items.Clear();
            ////cmbDraftKind.Items.Add(0, " ");
            //cmbDraftKind.Items.Add(1, "約束");
            //cmbDraftKind.Items.Add(2, "為替");

            //// 手形区分
            //cmbDraftDivide.Items.Clear();
            ////cmbDraftDivide.Items.Add(0, " ");
            //cmbDraftDivide.Items.Add(1, "自振");
            //cmbDraftDivide.Items.Add(2, "廻し");

            // 手形支払期日
            dateDraftPayTimeLimit.Clear();
            // 2007.10.09 hikita add end --------------------------------<<

            // ---- ADD 董桂鈺　2013/01/09 for Redmine#33921 ---------->>>>>>>>>>>>>
            this.edtOutline.Text = string.Empty;//摘要のクリア処理
            this.dateDraftPayTimeLimit.Enabled = false;//期日の入力不可設定
            // ---- ADD 董桂鈺　2013/01/09  for Redmine#33921 ----------<<<<<<<<<<<<

			// 入金合計額
			labDepositTotal.Text = "0";
		}
	
		/// <summary>
		/// 受注一覧初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注一覧の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// <br>Update Note: 2013/01/09 董桂鈺 </br>
		/// <br>管理番号   : 10806793-00  2013/03/13配信分</br>
		/// <br>             Redmine#33921 新規の場合に手数料、選択合計入金額の設定処理の追加</br>           
		/// </remarks>
		private void DmdSalesListInitialSetting()
		{
			// 請求売上情報DataSet初期化処理
			grdDmdSalesList.ActiveCell = null;
			grdDmdSalesList.ActiveRow = null;
			inputDepositSalesTypeAcs.ClearDmdSalesInfo();
			// ---- ADD 董桂鈺　2013/01/09 for Redmine#33921 ---------->>>>>>>>>>>>>
			this.edtFeeDeposit.Text = string.Empty;//手数料のクリア処理
			this.edtFeeDeposit.Enabled = false;//手数料の入力不可設定
			this.tNedit_SelectedDepositTotal.Text = string.Empty;//選択合計入金額のクリア処理
			// ---- ADD 董桂鈺　2013/01/09  for Redmine#33921 ----------<<<<<<<<<<<<
			// 売上合計
			labSalesTotal.Text = "0";

			// 売上引当合計
			labSalesAllowanceTotal.Text = "0";

			// メッセージ欄
			labDmdSalesList.Text = "";
		}

		/// <summary>
		/// 受注引当グリッドデータビューバインド処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドにデータビューをバインドします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2006.07.21</br>
		/// </remarks>
		private void BindingDsDmdSalesView()
		{
            // ↓ 20071030 18322 c MA.NS用に変更
			//// ソート設定
			//inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].DefaultView.Sort = InputDepositSalesTypeAcs.ctSlipNo + " ASC";

			// ソート設定
			inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[
                    InputDepositSalesTypeAcs.ctDmdSalesDataTable].DefaultView.Sort 
                                = InputDepositSalesTypeAcs.ctSalesSlipNum + " ASC";
            // ↑ 20071030 18322 c

			// 受注引当グリッドにViewをバインドする
			grdDmdSalesList.DataSource = inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].DefaultView;
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 受注引当グリッド表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドの表示設定を行います。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>             引当情報表示の改良</br>
		/// </remarks>
		private void SettingDmdSalesGrid()
		{
			string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatZero = "#,##0;-#,##0"; // ADD 2010/12/20

			// --- 受注引当グリッド --- //
			ColumnsCollection columns = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Columns;

			// チェックセル
			columns[InputDepositSalesTypeAcs.ctAlwCheck].Header.Caption = "";
			columns[InputDepositSalesTypeAcs.ctAlwCheck].Width = 20;

			// 引当額 共通 (入金引当マスタ)
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Header.Caption = "引当額";
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].CellAppearance.TextHAlign = HAlign.Right;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].CellAppearance.TextVAlign = VAlign.Middle;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Width = 100;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Format = moneyFormat;
            // --- ADD 2010/12/20  ----------<<<<<
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].MaxLength = 12;

			// 引当残 共通 (請求売上マスタ)
			columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Header.Caption = "引当残";
			columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellAppearance.TextHAlign = HAlign.Right;
			columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Width = 100;
            // --- ADD 2010/12/20 ---------->>>>>
			//columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Format = moneyFormat;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Format = moneyFormatZero;
            // --- ADD 2010/12/20  ----------<<<<<

			// 引当済 共通 (請求売上マスタ)
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Header.Caption = "引当済";
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellAppearance.TextHAlign = HAlign.Right;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Width = 100;
			columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Format = moneyFormat;

			// 赤伝区分
			columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Header.Caption = "赤黒種類";
			columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Width = 100;

            // --- ADD 2010/12/20 ---------->>>>>
            // 引当
            columns[InputDepositSalesTypeAcs.ctAllowDiv].Header.Caption = "引当";
            columns[InputDepositSalesTypeAcs.ctAllowDiv].CellAppearance.TextHAlign = HAlign.Center;
            columns[InputDepositSalesTypeAcs.ctAllowDiv].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctAllowDiv].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctAllowDiv].Width = 50;


            // 売上伝票番号
            columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].Header.Caption = "売上伝票番号";
            columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].CellAppearance.TextHAlign = HAlign.Center;
            columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].Width = 50;
            // --- ADD 2010/12/20  ----------<<<<<

			// 売上伝票番号
			columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Header.Caption = "売上伝票番号";
			columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellAppearance.TextHAlign = HAlign.Right;
			columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Width = 80;
            // ↑ 20070130 18322 c

			// 伝票日付
			columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Header.Caption = "売上日付";
			columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Width = 80;

			// 得意先名称
			columns[InputDepositSalesTypeAcs.ctCustomerName].Header.Caption = "得意先名";
			columns[InputDepositSalesTypeAcs.ctCustomerName].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctCustomerName].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctCustomerName].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctCustomerName].Width = 150;

			// 受注ステータス
			columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Header.Caption = "受注ステータス";
			columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellActivation = Activation.Disabled;			// 受注ステータス
			columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Width = 100;

			// 種別
			columns[InputDepositSalesTypeAcs.ctSalesKind].Header.Caption = "種別";
			columns[InputDepositSalesTypeAcs.ctSalesKind].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctSalesKind].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesKind].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctSalesKind].Width = 50;

			// 伝票備考
			columns[InputDepositSalesTypeAcs.ctSlipNote].Header.Caption = "伝票備考";
			columns[InputDepositSalesTypeAcs.ctSlipNote].CellAppearance.TextHAlign = HAlign.Left;
			columns[InputDepositSalesTypeAcs.ctSlipNote].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSlipNote].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctSlipNote].Width = 150;

            // 請求合計額(売上額)
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Header.Caption = "伝票合計";
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellAppearance.TextHAlign = HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Width = 100;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Format = moneyFormat;

			// 最終締次更新日
			columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Header.Caption = "最終請求締次更新日";
			columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellAppearance.TextHAlign = HAlign.Right;
			columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Width = 100;

            // 前回月次締め日
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].Header.Caption = "最終月次締次更新日";
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellAppearance.TextHAlign = HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].Width = 100;
            
			// 締状態
			columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption = "締";
			columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellAppearance.TextHAlign = HAlign.Center;
			columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellActivation = Activation.Disabled;
			columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Width = 20;

			// 入金内訳
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Header.Caption = "入金内訳";
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.ImageHAlign = HAlign.Center;
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.ImageVAlign = VAlign.Middle;
			columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Width = 80;

            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
            if (this.inputDepositSalesTypeAcs.KaToOption())
            {
                // 引当日
                columns[InputDepositSalesTypeAcs.ctDepositDate].Header.Caption = "引当日";
                columns[InputDepositSalesTypeAcs.ctDepositDate].CellAppearance.TextHAlign = HAlign.Right;
                columns[InputDepositSalesTypeAcs.ctDepositDate].CellAppearance.TextVAlign = VAlign.Middle;
                columns[InputDepositSalesTypeAcs.ctDepositDate].CellActivation = Activation.Disabled;
                columns[InputDepositSalesTypeAcs.ctDepositDate].Width = 100;

                // 担当者
                columns[InputDepositSalesTypeAcs.ctDepositAgentCode].Header.Caption = "担当者";
                columns[InputDepositSalesTypeAcs.ctDepositAgentCode].CellAppearance.TextHAlign = HAlign.Left;
                columns[InputDepositSalesTypeAcs.ctDepositAgentCode].CellAppearance.TextVAlign = VAlign.Middle;
                columns[InputDepositSalesTypeAcs.ctDepositAgentCode].CellActivation = Activation.Disabled;
                columns[InputDepositSalesTypeAcs.ctDepositAgentCode].Width = 150;

                // 金種
                columns[InputDepositSalesTypeAcs.ctDepositKindName].Header.Caption = "金種";
                columns[InputDepositSalesTypeAcs.ctDepositKindName].CellAppearance.TextHAlign = HAlign.Left;
                columns[InputDepositSalesTypeAcs.ctDepositKindName].CellAppearance.TextVAlign = VAlign.Middle;
                columns[InputDepositSalesTypeAcs.ctDepositKindName].CellActivation = Activation.Disabled;
                columns[InputDepositSalesTypeAcs.ctDepositKindName].Width = 100;
            }
            // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

            // 請求先コード
            columns[InputDepositSalesTypeAcs.ctClaimCode].Header.Caption = "請求先コード";
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctClaimCode].Width = 100;

            // 請求先名称
            columns[InputDepositSalesTypeAcs.ctClaimName].Header.Caption = "請求先名";
            columns[InputDepositSalesTypeAcs.ctClaimName].CellAppearance.TextHAlign = HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctClaimName].CellAppearance.TextVAlign = VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctClaimName].CellActivation = Activation.Disabled;
            columns[InputDepositSalesTypeAcs.ctClaimName].Width = 150;

			// 受注引当グリッドを展開する (１行もデータが無くてもタイトルを表示する為)
			grdDmdSalesList.Rows.ExpandAll(true);

			// グリッド設定情報取得
			GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref grdDmdSalesList);

			if (gridStateInfo != null)
			{
				// グリッドに設定セット
				this._gridStateController.SetGridStateToGrid(ref grdDmdSalesList);
				// フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
				cmbFontSize.Tag = false;
				cmbFontSize.Value = (int)gridStateInfo.FontSize;
				cmbFontSize.Tag = true;
				// 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
				ckdSalesAutoColumnSize.Tag = false;
				ckdSalesAutoColumnSize.Checked = gridStateInfo.AutoFit;
				ckdSalesAutoColumnSize.Tag = true;
			}
			else
			{
				// フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
				cmbFontSize.Tag = false;
				cmbFontSize.Value = 11;
				cmbFontSize.Tag = true;
				// 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
				ckdSalesAutoColumnSize.Tag = false;
				ckdSalesAutoColumnSize.Checked = false;
				ckdSalesAutoColumnSize.Tag = true;
			}
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受注引当グリッド表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受注引当グリッドの表示設定を行います。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void SettingDmdSalesGrid()
        {
            string moneyFormat = "#,##0;-#,##0;''";

            // --- 受注引当グリッド --- //
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Columns;

            // チェックセル
            columns[InputDepositSalesTypeAcs.ctAlwCheck].Header.Caption = "";
            columns[InputDepositSalesTypeAcs.ctAlwCheck].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[InputDepositSalesTypeAcs.ctAlwCheck].Width = 20;

            // ↓ 20070125 18322 c MA.NS用に変更
            #region SF 受注・諸費用は使用しないので削除
            //// 引当額 受注 (入金引当マスタ)
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Header.Caption = "引当額(受)";
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Format = moneyFormat;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].MaxLength = 12;
            //
            //// 引当残 受注 (請求売上マスタ)
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Header.Caption = "引当残(受)";
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Format = moneyFormat;
            //
            //// 引当済 受注 (請求売上マスタ)
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].Header.Caption = "引当済(受)";
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].Format = moneyFormat;
            //
            //// 引当額 諸費用 (入金引当マスタ)
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Header.Caption = "引当額(諸)";
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Format = moneyFormat;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].MaxLength = 12;
            //
            //// 引当残 諸費用 (請求売上マスタ)
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Header.Caption = "引当残(諸)";
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Format = moneyFormat;
            //
            //// 引当済 諸費用 (請求売上マスタ)
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].Header.Caption = "引当済(諸)";
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].Format = moneyFormat;
            #endregion
            // ↑ 20070125 18322 c

            // 引当額 共通 (入金引当マスタ)
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Header.Caption = "引当額";
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Width = 100;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Format = moneyFormat;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].MaxLength = 12;

            // 引当残 共通 (請求売上マスタ)
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Header.Caption = "引当残";
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Width = 100;
            columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Format = moneyFormat;

            // 引当済 共通 (請求売上マスタ)
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Header.Caption = "引当済";
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Width = 100;
            columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Format = moneyFormat;

            // 赤伝区分
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Header.Caption = "赤黒種類";
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Width = 100;

            // 受注番号
            // 2007.10.09 hikita del start ----------------------------------------------------------------->>
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Header.Caption = "受注番号";
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Width = 80;
            // 2007.10.09 hikita del end -------------------------------------------------------------------<<

            // ↓ 20070130 18322 c MA.NS用に変更
            //// 伝票番号
            //columns[InputDepositSalesTypeAcs.ctSlipNo].Header.Caption = "伝票番号";
            //columns[InputDepositSalesTypeAcs.ctSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctSlipNo].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctSlipNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctSlipNo].Width = 80;

            // 売上伝票番号
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Header.Caption = "売上伝票番号";
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Width = 80;
            // ↑ 20070130 18322 c

            // 伝票日付
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Header.Caption = "伝票日付";
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Width = 80;

            // ↓ 20070525 18322 a
            // ＰＯＳレシート番号
            // 2007.10.09 hikita del start ------------------------------------------------------------------------>>
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].Header.Caption = "ＰＯＳレシート番号";
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].Format = "#########";
            //columns[InputDepositSalesTypeAcs.ctPosReceiptNo].Width = 80;
            //// レジ処理日
            //columns[InputDepositSalesTypeAcs.ctRegiProcDate].Header.Caption = "ＰＯＳ処理日";
            //columns[InputDepositSalesTypeAcs.ctRegiProcDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctRegiProcDate].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctRegiProcDate].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctRegiProcDate].Width = 80;
            // ↑ 20070525 18322 a
            // 2007.10.09 hikita del end --------------------------------------------------------------------------<<

            // 得意先コード
            columns[InputDepositSalesTypeAcs.ctCustomerCode].Header.Caption = "得意先コード";
            columns[InputDepositSalesTypeAcs.ctCustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctCustomerCode].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctCustomerCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctCustomerCode].Width = 100;

            // 得意先名称
            columns[InputDepositSalesTypeAcs.ctCustomerName].Header.Caption = "得意先名称";
            columns[InputDepositSalesTypeAcs.ctCustomerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctCustomerName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctCustomerName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctCustomerName].Width = 150;

            // ↓ 20070130 18322 d MA.NS用に変更
            //// システム
            //columns[InputDepositSalesTypeAcs.ctDataInputSystem].Header.Caption = "システム";
            //columns[InputDepositSalesTypeAcs.ctDataInputSystem].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //columns[InputDepositSalesTypeAcs.ctDataInputSystem].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctDataInputSystem].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// システム
            //columns[InputDepositSalesTypeAcs.ctDataInputSystem].Width = 100;
            // ↑ 20071030 18322 d

            // 受注ステータス
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Header.Caption = "受注ステータス";
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// 受注ステータス
            columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Width = 100;

            // 種別
            columns[InputDepositSalesTypeAcs.ctSalesKind].Header.Caption = "種別";
            columns[InputDepositSalesTypeAcs.ctSalesKind].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctSalesKind].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesKind].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSalesKind].Width = 50;

            // 売上名称
            columns[InputDepositSalesTypeAcs.ctSlipNote].Header.Caption = "売上名称";
            columns[InputDepositSalesTypeAcs.ctSlipNote].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctSlipNote].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSlipNote].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSlipNote].Width = 150;

            // ↓ 20070125 18322 c MA.NS用に変更
            #region SF 登録番号・受注売上・諸費用・受注合計は使用しないので削除
            //// 登録番号
            //columns[InputDepositSalesTypeAcs.ctNumberPlate].Header.Caption = "登録番号";
            //columns[InputDepositSalesTypeAcs.ctNumberPlate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //columns[InputDepositSalesTypeAcs.ctNumberPlate].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctNumberPlate].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctNumberPlate].Width = 150;
            //
            //// 受注売上額
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Header.Caption = "売上計";
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Format = moneyFormat;
            //
            //// 諸費用額
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Header.Caption = "諸費用計";
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Format = moneyFormat;
            //
            //// 受注合計額
            //columns[InputDepositSalesTypeAcs.ctTotalSales].Header.Caption = "受注合計";
            //columns[InputDepositSalesTypeAcs.ctTotalSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctTotalSales].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctTotalSales].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctTotalSales].Width = 100;
            //columns[InputDepositSalesTypeAcs.ctTotalSales].Format = moneyFormat;
            #endregion

            // 請求合計額(売上額)
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Header.Caption = "伝票合計";
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Width = 100;
            columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Format = moneyFormat;
            // ↑ 20070125 18322 c

            // 最終締次更新日
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Header.Caption = "最終請求締次更新日";
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Width = 100;

            // 前回月次締め日
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].Header.Caption = "最終月次締次更新日";
            //columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].Width = 100;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].Header.Caption = "最終月次締次更新日";
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctLastMonthlyDateDisp].Width = 100;
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // 締状態
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption = "締";
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Width = 20;

            // 入金内訳
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Header.Caption = "入金内訳";
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Width = 80;

            // 請求先コード
            columns[InputDepositSalesTypeAcs.ctClaimCode].Header.Caption = "請求先コード";
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctClaimCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctClaimCode].Width = 100;

            // 請求先名称
            columns[InputDepositSalesTypeAcs.ctClaimName].Header.Caption = "請求先名称";
            columns[InputDepositSalesTypeAcs.ctClaimName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[InputDepositSalesTypeAcs.ctClaimName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            columns[InputDepositSalesTypeAcs.ctClaimName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[InputDepositSalesTypeAcs.ctClaimName].Width = 150;



            // 受注引当グリッドを展開する (１行もデータが無くてもタイトルを表示する為)
            grdDmdSalesList.Rows.ExpandAll(true);

            // グリッド設定情報取得
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref grdDmdSalesList);

            if (gridStateInfo != null)
            {
                // グリッドに設定セット
                this._gridStateController.SetGridStateToGrid(ref grdDmdSalesList);
                // フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
                cmbFontSize.Tag = false;
                cmbFontSize.Value = (int)gridStateInfo.FontSize;
                cmbFontSize.Tag = true;
                // 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
                ckdSalesAutoColumnSize.Tag = false;
                ckdSalesAutoColumnSize.Checked = gridStateInfo.AutoFit;
                ckdSalesAutoColumnSize.Tag = true;
            }
            else
            {
                // フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
                cmbFontSize.Tag = false;
                cmbFontSize.Value = 11;
                cmbFontSize.Tag = true;
                // 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
                ckdSalesAutoColumnSize.Tag = false;
                ckdSalesAutoColumnSize.Checked = false;
                ckdSalesAutoColumnSize.Tag = true;
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 受注引当グリッド初期設定処理処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドの初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void InitializeDmdSalesList()
		{
			// 列幅をオートに設定
			//grdDmdSalesList.DisplayLayout.AutoFitColumns = true;

			// 行選択設定 行選択無しモード(アクティブのみ)
			grdDmdSalesList.DisplayLayout.Override.SelectTypeRow = SelectType.None;
			grdDmdSalesList.DisplayLayout.Override.SelectTypeCell = SelectType.None;
			grdDmdSalesList.DisplayLayout.Override.SelectTypeCol = SelectType.None;

			// グリッド全体の外観設定
            // ↓ 20070131 18322 d MA.NS用に変更
			//grdDmdSalesList.DisplayLayout.Appearance.BackColor = Color.White;
			//grdDmdSalesList.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
			//grdDmdSalesList.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // ↑ 20070131 18322 d

			// 行選択モードの設定
			//			grdDmdSalesList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;

			// 行の外観設定
			grdDmdSalesList.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

			// 1行おきの外観設定
			grdDmdSalesList.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// 選択行の外観設定
			grdDmdSalesList.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grdDmdSalesList.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grdDmdSalesList.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;

			// アクティブ行の外観設定
			grdDmdSalesList.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grdDmdSalesList.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grdDmdSalesList.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

			// アクティブセルの外観設定
			grdDmdSalesList.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(251, 230, 148);

			// ヘッダーの外観設定
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Left;
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
			grdDmdSalesList.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

			// 行セレクターの外観設定
			grdDmdSalesList.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grdDmdSalesList.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grdDmdSalesList.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

			// 行フィルターの設定
//			grdDmdSalesList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
//			grdDmdSalesList.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
//			grdDmdSalesList.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;

			// 垂直方向のスクロールスタイル
			grdDmdSalesList.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

			// 階層マーク表示設定
			grdDmdSalesList.DisplayLayout.ViewStyle = ViewStyle.SingleBand;

			// 複数画面表示(スプリッター)の表示設定
			grdDmdSalesList.DisplayLayout.MaxRowScrollRegions = 1;

			// スクロールバー最終行制御
			grdDmdSalesList.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

			// ヘッダークリックアクション設定
			grdDmdSalesList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

			// 行セレクターを非表示
			//			grdDmdSalesList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

			// 「固定列」プッシュピンアイコンを消す
			grdDmdSalesList.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受注引当グリッド表示列変更処理
        /// </summary>
        /// <param name="checkDetail">詳細表示 有無</param>
        /// <remarks>
        /// <br>Note       : 受注引当グリッドの表示列を変更します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private void ColumnViewSettingDmdSalesList(bool checkDetail)
        {
            UltraGridBand bdDmdSales = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            // 詳細表示の時
            if (checkDetail == true)
            {
                // 表示
                // 引当済 共通 (請求売上マスタ)
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden = false;
                // 入金内訳
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden = false;
                // 締フラグ
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden = false;

                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
                if (this.inputDepositSalesTypeAcs.KaToOption())
                {
                    // 入金内訳
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden = true;

                    // 引当日
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositDate].Hidden = false;

                    // 担当者
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAgentCode].Hidden = false;

                    // 金種
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositKindName].Hidden = false;
                }
                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<
            }
            else
            {
                // 非表示
                // 引当済 共通 (請求売上マスタ)
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden = true;
                // 入金内訳
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden = true;
                // 締フラグ
                bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden = true;

                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
                if (this.inputDepositSalesTypeAcs.KaToOption())
                {
                    // 引当日
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositDate].Hidden = true;

                    // 担当者
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAgentCode].Hidden = true;

                    // 金種
                    bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositKindName].Hidden = true;
                }
                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<
            }

            // 変更前引当済(請求売上マスタ)
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctBfDepositAllowance_Sales].Hidden = true;

            // 引当額 共通 (入金引当額)
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Hidden = false;
            // 引当残 共通 (請求売上マスタ)
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Hidden = false;
            // 変更前引当残(請求売上マスタ)
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctBfDepositAlwcBlnce_Sales].Hidden = true;
            // 伝票合計
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Hidden = false;

            // 常に非表示
            // 請求売上赤伝区分
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteDiv].Hidden = true;
            // 請求売上赤伝名称
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Hidden = true;
            // 伝票日付
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchSlipDate].Hidden = true;
            // 売上日
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAddUpADate].Hidden = true;
            // 受注ステータス
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Hidden = true;
            // 受注ステータス名
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatusNm].Hidden = true;
            // 最終締次更新日
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Hidden = true;
            // 前回月次締め日
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].Hidden = true;
            // 請求売上クラス
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchClaimSales].Hidden = true;
            // 新規作成入金更新パラメータクラス
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctUpdateDepositParameter].Hidden = true;

            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctClaimCode].Hidden = true;

            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctClaimName].Hidden = true;

            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAccRecDivCd].Hidden = true;

            // 自身のDataRow
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDmdSalesDataRow].Hidden = true;

            //-----ADD 2010/12/20 ----->>>>>
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepSaleSlipNum].Hidden = true;
            //-----ADD 2010/12/20 -----<<<<<
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 受注引当グリッド表示列変更処理
		/// </summary>
		/// <param name="checkDetail">詳細表示 有無</param>
		/// <param name="checkSeparateCost">諸費用別入金 有無</param>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドの表示列を変更します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void ColumnViewSettingDmdSalesList(bool checkDetail, bool checkSeparateCost)
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand bdDmdSales = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            // ↓ 20070125 18322 c MA.NS用に変更
            #region 諸費用別入金は使用しないので削除
            //// 諸費用別入金
			//if (checkSeparateCost == true)
			//{
			//	// 諸費用別入金 有無
			//	if (depositRelDataAcs.OptSeparateCost == true)
			//	{
			//		// 表示
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Hidden			= false;	// 引当額 受注 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Hidden		= false;	// 引当残 受注 (請求売上マスタ)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Hidden			= false;	// 引当額 諸費用 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Hidden	= false;	// 引当残 諸費用 (請求売上マスタ)
			//		// 非表示
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Hidden			= true;		// 引当額 共通 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Hidden		= true;		// 引当残 共通 (請求売上マスタ)
			//	}
			//	else
			//	{
			//		// 表示
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Hidden			= false;	// 引当額 共通 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Hidden		= false;	// 引当残 共通 (請求売上マスタ)
			//		// 非表示
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Hidden			= true;		// 引当額 受注 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Hidden		= true;		// 引当残 受注 (請求売上マスタ)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Hidden			= true;		// 引当額 諸費用 (入金引当額)
			//		bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Hidden	= true;		// 引当残 諸費用 (請求売上マスタ)
			//	}
			//}
			//else
			//{
			//	// 表示
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Hidden			= false;	// 引当額 共通 (入金引当額)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Hidden		= false;	// 引当残 共通 (請求売上マスタ)
			//	// 非表示
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Hidden			= true;		// 引当額 受注 (入金引当額)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepoAlwcBlnce_Sales].Hidden		= true;		// 引当残 受注 (請求売上マスタ)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw].Hidden			= true;		// 引当額 諸費用 (入金引当額)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwcBlnce_Sales].Hidden	= true;		// 引当残 諸費用 (請求売上マスタ)
			//
			//}
			//
			//// 詳細表示の時
			//if (checkDetail == true)
			//{
			//	// 表示
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Hidden			= false;		// 受注番号
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden	= false;		// 引当済 共通 (請求売上マスタ)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Hidden		= false;		// 受注売上額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Hidden			= false;		// 諸費用額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctTotalSales].Hidden				= false;		// 受注合計額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden				= false;		// 入金内訳
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden			= false;		// 締フラグ
			//}
			//else
			//{
			//	// 非表示
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Hidden			= true;			// 受注番号
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden	= true;			// 引当済 共通 (請求売上マスタ)
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Hidden		= true;			// 受注売上額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Hidden			= true;			// 諸費用額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctTotalSales].Hidden				= true;			// 受注合計額
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden				= true;			// 入金内訳
			//	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden			= true;			// 締フラグ
			//}
			//
			//// 常に非表示
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteDiv].Hidden					= true;			// 請求売上赤伝区分
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Hidden					= true;			// 請求売上赤伝名称
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchSlipDate].Hidden				= true;			// 伝票日付
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAddUpADate].Hidden					= true;			// 売上日
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Sales].Hidden		= true;			// 引当済 受注 (請求売上マスタ)
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Sales].Hidden			= true;			// 引当済 諸費用 (請求売上マスタ)
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDataInputSystem].Hidden				= true;			// システム
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Hidden				= true;			// 受注ステータス
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Hidden				= true;			// 最終締次更新日
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchDmdSalesCustomer].Hidden		= true;			// 請求売上クラス
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctUpdateDepositParameter].Hidden		= true;			// 新規作成入金更新パラメータクラス
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDmdSalesDataRow].Hidden				= true;			// 自身のDataRow
            #endregion

			// 詳細表示の時
			if (checkDetail == true)
			{
				// 表示
		        // 引当済 共通 (請求売上マスタ)
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden	= false;
                // 入金内訳
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden				= false;
		        // 締フラグ
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden			= false;
			}
			else
			{
				// 非表示
			    // 引当済 共通 (請求売上マスタ)
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Sales].Hidden	= true;
			    // 入金内訳
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwBtn].Hidden				= true;
			    // 締フラグ
				bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Hidden			= true;
			}

	        // 引当額 共通 (入金引当額)
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Hidden			= false;
	        // 引当残 共通 (請求売上マスタ)
	    	bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Hidden		= false;
            // 伝票合計
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Hidden = false;

			// 常に非表示
			// 請求売上赤伝区分
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteDiv].Hidden				= true;
			// 請求売上赤伝名称
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Hidden				= true;
            // 伝票日付
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchSlipDate].Hidden			= true;
            // 売上日
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAddUpADate].Hidden				= true;
			// 受注番号
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Hidden			= true; // 2007.10.09 hikita del
			// 受注ステータス
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Hidden			= true;
			// 受注ステータス名
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAcptAnOdrStatusNm].Hidden			= true;
			// 最終締次更新日
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctLastTotalAddUpDt].Hidden			= true;
            // 前回月次締め日
            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctLastMonthlyDate].Hidden = true;  // 2007.10.09 hikita del
			// 請求売上クラス
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctSearchClaimSales].Hidden       	= true;
			// 新規作成入金更新パラメータクラス
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctUpdateDepositParameter].Hidden	= true;

            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctClaimCode].Hidden = true;

            bdDmdSales.Columns[InputDepositSalesTypeAcs.ctClaimName].Hidden = true;

            // ↓ 20070525 18322 a
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctAccRecDivCd   ].Hidden	= true;    // 売掛区分(0:売掛なし,1:売掛)
			//bdDmdSales.Columns[InputDepositSalesTypeAcs.ctCashRegisterNo].Hidden	= true;    //レジ番号
            // ↑ 20070525 18322 a

			// 自身のDataRow
			bdDmdSales.Columns[InputDepositSalesTypeAcs.ctDmdSalesDataRow].Hidden			= true;
            // ↑ 20070125 18322 c
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 受注引当グリッド表示列サイズ変更処理
		/// </summary>
		/// <param name="parameter">列サイズ自動調整 有無</param>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドの表示列サイズを変更します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SalesGridColumnSizeChange(object parameter)
		{
			if (!(parameter is bool)) return;

			bool check = (bool)parameter;

			// グリッド列幅のオート設定
			if (check == true)
			{
				this.grdDmdSalesList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
				return;
			}
			else
			{
				this.grdDmdSalesList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
			}

			// 列幅の調整
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.grdDmdSalesList.BeginUpdate();

				foreach (UltraGridColumn resizeColumn in grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Columns)
				{
					if (!resizeColumn.Hidden)
					{
						bool flag = false;

						// 列幅変更しようとしている列の中に値が何かあるのなら、列幅は自動で設定する
						for (int ix = 0; ix < grdDmdSalesList.Rows.Count; ix++)
						{
							if (grdDmdSalesList.Rows[ix].Cells[resizeColumn].Text.Trim() != "")
							{
								flag = true;
								break;
							}
						}

						if (flag == true) resizeColumn.PerformAutoResize(PerformAutoSizeType.VisibleRows);
					}
				}
			}
			finally
			{
				this.grdDmdSalesList.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 入金内容の変更状況チェック処理
		/// </summary>
		/// <returns>処理ステータス 0:処理続行,1:処理キャンセル</returns>
		/// <remarks>
		/// <br>Note       : 変更されているかチェックを行い、更新確認を促します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int CheckUpdateData()
		{
			// 入金更新用クラス取得処理
			InputDepositSalesTypeAcs.UpdateDepositParameter updateDepositParameter = GetUpdateDepositParameter();
			DataRow[] drDmdSalesList;

			// 更新対象データの取得/不正チェック処理
			string message;
			int st = inputDepositSalesTypeAcs.CheackUpdateDate(updateDepositParameter, out drDmdSalesList, out message);
			if (st != 1)
			{
				// 変更中の時
				DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "現在、編集中のデータが存在します。" + "\r\n\r\n" + "登録してもよろしいですか？", 0, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);
				switch(res)
				{
					case DialogResult.Yes:

						// 入金伝票保存処理
						if (this.SaveDeposit() != 0)
						{
							return 1;
						}

						break;
					
					case DialogResult.No:
					
						break;

					case DialogResult.Cancel:
						
						return 1;
				}
			}

			return 0;
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 検索前データチェック処理
        /// </summary>
        /// <param name="control">エラーコントロール</param>
        /// <returns>チェック結果  True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note       : 検索前データチェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private bool CheackDataBeforeSearch(out Control control)
        {
            control = null;

            int startDate;
            int endDate;

            // 得意先コード
            if (this.tNedit_CustomerCode.GetInt() == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "得意先コードが未入力です。", 0, MessageBoxButtons.OK);
                control = this.tNedit_CustomerCode;
                this._prevCustomerCode = 0;
                return false;
            }

            int customerCode = this.tNedit_CustomerCode.GetInt();
            CustomerInfo customerInfo;
            if (GetCustomerInfo(out customerInfo, customerCode) != 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "マスタに登録されていません。", 0, MessageBoxButtons.OK);
                control = this.tNedit_CustomerCode;
                this._prevCustomerCode = 0;
                return false;
            }

            // 伝票日付（開始）
            startDate = detSearchSlipDateStart.GetLongDate();
            endDate = detSearchSlipDateEnd.GetLongDate();
            if ((startDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)) == false))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付（開始）の日付が不正です。", 0, MessageBoxButtons.OK);
                control = detSearchSlipDateStart;
                return false;
            }

            // 伝票日付（終了）
            if ((endDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)) == false))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付（終了）の日付が不正です。", 0, MessageBoxButtons.OK);
                control = detSearchSlipDateEnd;
                return false;
            }

            // 伝票日付 範囲
            if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付の範囲指定が不正です。", 0, MessageBoxButtons.OK);
                control = detSearchSlipDateEnd;
                return false;
            }

            return true;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 検索前データチェック処理
		/// </summary>
		/// <param name="control">エラーコントロール</param>
		/// <returns>チェック結果  True:OK, False:NG</returns>
		/// <remarks>
		/// <br>Note       : 検索前データチェックを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private bool CheackDataBeforeSearch(out Control control)
		{
			control = null;

			int startDate;
			int endDate;

            // ↓ 20070130 18322 d MA.NS用に変更
			//// 得意先
			//if ((cbxCorporateDiv1.Checked == false) && (cbxCorporateDiv2.Checked == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "得意先種類にチェックを入れて下さい。", 0, MessageBoxButtons.OK);
			//	control = cbxCorporateDiv1;
			//	return false;
			//}
            // ↑ 20070130 18322 d

            // 2007.10.09 hikita del start --------------------------------------------------------------------------------------->>
			// クレジット区分
			//if ((cbxCreditOrLoan1.Checked == false) && (cbxCreditOrLoan2.Checked == false) && (cbxCreditOrLoan3.Checked == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "クレジット区分にチェックを入れて下さい。", 0, MessageBoxButtons.OK);
			//	control = cbxCreditOrLoan1;
			//	return false;
			//}
            
			// 受注日（開始）
			//startDate = detAcceptAnOrderDateStart.GetLongDate();
			//endDate = detAcceptAnOrderDateEnd.GetLongDate();
			//if ((startDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)) == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "受注日（開始）の日付が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAcceptAnOrderDateStart;
			//	return false;
			//}

			// 受注日（終了）
			//if ((endDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)) == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "受注日（終了）の日付が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAcceptAnOrderDateEnd;
			//	return false;
			//}

			// 受注日 範囲
			//if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "受注日の範囲指定が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAcceptAnOrderDateEnd;
			//	return false;
			//}
            // 2007.10.09 hikita del end -----------------------------------------------------------------------------------------<<

			// 伝票日付（開始）
			startDate = detSearchSlipDateStart.GetLongDate();
			endDate = detSearchSlipDateEnd.GetLongDate();
			if ((startDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)) == false))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付（開始）の日付が不正です。", 0, MessageBoxButtons.OK);
				control = detSearchSlipDateStart;
				return false;
			}

			// 伝票日付（終了）
			if ((endDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)) == false))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付（終了）の日付が不正です。", 0, MessageBoxButtons.OK);
				control = detSearchSlipDateEnd;
				return false;
			}

			// 伝票日付 範囲
			if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票日付の範囲指定が不正です。", 0, MessageBoxButtons.OK);
				control = detSearchSlipDateEnd;
				return false;
			}

            // 2007.10.09 hikita del start --------------------------------------------------------------------------------------->>
			// 計上日（開始）
			//startDate = detAddUpADateStart.GetLongDate();
			//endDate = detAddUpADateEnd.GetLongDate();
			//if ((startDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)) == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "計上日（開始）の日付が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAddUpADateStart;
			//	return false;
			//}
			// 計上日（終了）
			//if ((endDate != 0) && (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)) == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "計上日（終了）の日付が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAddUpADateEnd;
			//	return false;
			//}
			// 計上日 範囲
			//if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "計上日の範囲指定が不正です。", 0, MessageBoxButtons.OK);
			//	control = detAddUpADateEnd;
			//	return false;
			//}
            // 2007.10.09 hikita del end -----------------------------------------------------------------------------------------<<

			// 伝票種別(受注ステータス)
            //if ((cbxAcptAnOdrStartus1.Checked == false) && (cbxAcptAnOdrStartus2.Checked == false) && (cbxAcptAnOdrStartus3.Checked == false))
            //{
            //    // ↓ 20070221 18322 c MA.NS用に変更
            //    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票種別(受注ステータス)にチェックを入れて下さい。", 0, MessageBoxButtons.OK);

            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票種別にチェックを入れて下さい。", 0, MessageBoxButtons.OK);
            //    // ↑ 20070221 18322 c
            //    control = cbxAcptAnOdrStartus1;
            //    return false;
            //}

            // ↓ 20070130 18322 d MA.NS用に変更
			//// 伝票種別(システム種別)
			//if ((cbxDataInputSystem1.Checked == false) && (cbxDataInputSystem2.Checked == false) && (cbxDataInputSystem3.Checked == false))
			//{
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "伝票種別(システム種別)にチェックを入れて下さい。", 0, MessageBoxButtons.OK);
			//	control = cbxDataInputSystem1;
			//	return false;
			//}
            // ↑ 20070130 18322 d

			return true;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// データ検索前の画面設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データ検索前に画面の初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SearchBeforeDisplySetting()
		{
			// 合計欄をクリア
			labSalesTotal.Text = "0";
			labSalesAllowanceTotal.Text = "0";
			labDepositTotal.Text = "0";
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 請求売上情報取得用パラメータ 作成処理
		/// </summary>
		/// <returns>請求売上情報取得用パラメータ クラス</returns>
		/// <remarks>
		/// <br>Note       : 請求売上情報取得用パラメータの生成を行います。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/06/26</br>
		/// </remarks>
		private InputDepositSalesTypeAcs.SearchSalesParameter SetSalesParameter()
		{
			InputDepositSalesTypeAcs.SearchSalesParameter param = new InputDepositSalesTypeAcs.SearchSalesParameter();

			DateTime dt	= TDateTime.GetSFDateNow();

			// 企業コード
			param.EnterpriseCode = enterpriseCode;

            // 計上拠点
			param.DemandAddUpSecCd = selectSectionCode;

            int[] intArray = new int[1];
            intArray[0] = 30;
            param.AcptAnOdrStatus = intArray;

            // 請求先コード
            param.ClaimCode = this.claimCode;

            // 得意先コード
            param.CustomerCode = this._customerCode;

            // 売上伝票番号
            param.SalesSlipNum = tEdit_SalesSlipNum.Text;

            // 引当済請求売上伝票呼出区分
            param.AlwcSalesSlipCall = (int)opsAlwcDmdSalesCall.Value;
            
            // DEL 2009/06/24 ------>>>
            //// 伝票日付 開始
            //param.SearchSlipDateStart = detSearchSlipDateStart.GetLongDate();

            //// 伝票日付 終了
            //param.SearchSlipDateEnd = detSearchSlipDateEnd.GetLongDate();
            // DEL 2009/06/24 ------<<<

            // ADD 2009/06/24 ------>>>
            // 売上日(計上日)　開始
            param.AddUpADateStart = detSearchSlipDateStart.GetLongDate();
            // 売上日(計上日)　終了
            param.AddUpADateEnd = detSearchSlipDateEnd.GetLongDate();
            // ADD 2009/06/24 ------<<<
            
            // サービス伝票区分(0:OFF, 1:ON)
            param.ServiceSlipCd = 0;

            // 売掛区分(0:売掛なし,1:売掛)
            param.AccRecDivCd = -1;

            // 自動入金区分(0:通常入金,1:自動入金)
            param.AutoDepositCd = -1;

            return param;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 請求売上情報取得用パラメータ 作成処理
        /// </summary>
        /// <returns>請求売上情報取得用パラメータ クラス</returns>
        /// <remarks>
        /// <br>Note       : 請求売上情報取得用パラメータの生成を行います。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private InputDepositSalesTypeAcs.SearchSalesParameter SetSalesParameter()
        {
            InputDepositSalesTypeAcs.SearchSalesParameter param = new InputDepositSalesTypeAcs.SearchSalesParameter();

            DateTime dt = TDateTime.GetSFDateNow();

            // 企業コード
            param.EnterpriseCode = enterpriseCode;

            // ↓ 20070125 18322 c MA.NS用に変更
            #region SF コメントアウト
            //// 計上拠点
            //param.AddUpSecCod = selectSectionCode;
            //
            //// AA抽出区分
            //if (cbxCorporateDiv1.Checked == true)
            //{
            //	if (cbxCorporateDiv2.Checked == true)
            //	{
            //		param.AutoAuctionDiv = 0;
            //	}
            //	else
            //	{
            //		param.AutoAuctionDiv = 2;
            //	}
            //}
            //else
            //{
            //	if (cbxCorporateDiv2.Checked == true)
            //	{
            //		param.AutoAuctionDiv = 1;
            //	}
            //	else
            //	{
            //		param.AutoAuctionDiv = 0;
            //	}
            //}
            //
            //// 得意先コード
            //param.CustomerCode = edtCustomerCode.GetInt();
            //
            //// クレジット区分
            //param.CreditOrLoanCd = new int[0];
            //if (cbxCreditOrLoan1.Checked == true)
            //{
            //	param.CreditOrLoanCd.CopyTo( param.CreditOrLoanCd = new int[param.CreditOrLoanCd.Length+1], 0 );
            //	param.CreditOrLoanCd[param.CreditOrLoanCd.Length-1] = 0;
            //}
            //if (cbxCreditOrLoan2.Checked == true)
            //{
            //	param.CreditOrLoanCd.CopyTo( param.CreditOrLoanCd = new int[param.CreditOrLoanCd.Length+1], 0 );
            //	param.CreditOrLoanCd[param.CreditOrLoanCd.Length-1] = 1;
            //}
            //if (cbxCreditOrLoan3.Checked == true)
            //{
            //	param.CreditOrLoanCd.CopyTo( param.CreditOrLoanCd = new int[param.CreditOrLoanCd.Length+1], 0 );
            //	param.CreditOrLoanCd[param.CreditOrLoanCd.Length-1] = 2;
            //}
            //
            //// クレジット会社コード
            //param.CreditCompanyCode = edtCreditCompanyCode.Text;
            //
            //// 販売従業員コード
            //param.SalesEmployeeCd = edtSalesEmployee.Text;
            //
            //// 引当済請求売上伝票呼出区分
            //param.AlwcDmdSalesCall = opsAlwcDmdSalesCall.CheckedIndex;
            //
            //// 伝票番号
            //param.SlipNo = edtSearchSlipNo.Text;
            //
            //// 受注日 開始
            //param.AcceptAnOrderDateStart = detAcceptAnOrderDateStart.GetLongDate();
            //
            //// 受注日 終了
            //param.AcceptAnOrderDateEnd = detAcceptAnOrderDateEnd.GetLongDate();
            //
            //// 伝票日付 開始
            //param.SearchSlipDateStart = detSearchSlipDateStart.GetLongDate();
            //
            //// 伝票日付 終了
            //param.SearchSlipDateEnd = detSearchSlipDateEnd.GetLongDate();
            //
            //// 納車予定日 開始
            //param.CarDeliExpectedDateStart = detCarDeliExpectedDateStart.GetLongDate();
            //
            //// 納車予定日 終了
            //param.CarDeliExpectedDateEnd = detCarDeliExpectedDateEnd.GetLongDate();
            //
            //// 受注ステータス
            //param.AcptAnOdrStatus = new int[0];
            //if (cbxAcptAnOdrStartus1.Checked == true)
            //{
            //	param.AcptAnOdrStatus.CopyTo( param.AcptAnOdrStatus = new int[param.AcptAnOdrStatus.Length+1], 0 );
            //	param.AcptAnOdrStatus[param.AcptAnOdrStatus.Length-1] = 10;
            //}
            //if (cbxAcptAnOdrStartus2.Checked == true)
            //{
            //	param.AcptAnOdrStatus.CopyTo( param.AcptAnOdrStatus = new int[param.AcptAnOdrStatus.Length+1], 0 );
            //	param.AcptAnOdrStatus[param.AcptAnOdrStatus.Length-1] = 20;
            //}
            //if (cbxAcptAnOdrStartus3.Checked == true)
            //{
            //	param.AcptAnOdrStatus.CopyTo( param.AcptAnOdrStatus = new int[param.AcptAnOdrStatus.Length+1], 0 );
            //	param.AcptAnOdrStatus[param.AcptAnOdrStatus.Length-1] = 30;
            //}
            //
            //// データ入力システム
            //param.DataInputSystem = new int[0];
            //param.DataInputSystem.CopyTo( param.DataInputSystem = new int[param.DataInputSystem.Length+1], 0 );
            //param.DataInputSystem[param.DataInputSystem.Length-1] = 0;
            //if (cbxDataInputSystem1.Checked == true)
            //{
            //	param.DataInputSystem.CopyTo( param.DataInputSystem = new int[param.DataInputSystem.Length+1], 0 );
            //	param.DataInputSystem[param.DataInputSystem.Length-1] = 1;
            //}
            //if (cbxDataInputSystem2.Checked == true)
            //{
            //	param.DataInputSystem.CopyTo( param.DataInputSystem = new int[param.DataInputSystem.Length+1], 0 );
            //	param.DataInputSystem[param.DataInputSystem.Length-1] = 2;
            //}
            //if (cbxDataInputSystem3.Checked == true)
            //{
            //	param.DataInputSystem.CopyTo( param.DataInputSystem = new int[param.DataInputSystem.Length+1], 0 );
            //	param.DataInputSystem[param.DataInputSystem.Length-1] = 3;
            //}
            #endregion
            // 計上拠点
            param.DemandAddUpSecCd = selectSectionCode;

            // 請求先コード
            param.ClaimCode = this.claimCode;

            // 得意先コード
            param.CustomerCode = tNedit_CustomerCode.GetInt();

            // 販売従業員コード
            //param.SalesEmployeeCd = edtSalesEmployee.Text;  // 2007.10.09 hikita del

            // 売上伝票番号
            param.SalesSlipNum = tEdit_SalesSlipNum.Text;

            // 引当済請求売上伝票呼出区分
            param.AlwcSalesSlipCall = (int)opsAlwcDmdSalesCall.Value;

            // 受注番号
            //param.AcceptAnOrderNo = 0;

            // 伝票種別
            //Int32[] arrAcptAnOdrStatus = new Int32[3];
            //int index = 0;
            //if (cbxAcptAnOdrStartus1.Checked)
            //{
            //    // "30:売上"がON
            //    arrAcptAnOdrStatus[index] = 30;
            //    index += 1;
            //}
            //if (cbxAcptAnOdrStartus2.Checked)
            //{
            //    // "40:売切"がON
            //    arrAcptAnOdrStatus[index] = 40;
            //    index += 1;
            //}
            //if (cbxAcptAnOdrStartus3.Checked)
            //{
            //    // "55:委託計上"がON
            //    arrAcptAnOdrStatus[index] = 55;
            //    index += 1;
            //}
            //param.AcptAnOdrStatus = arrAcptAnOdrStatus;

            // 伝票日付 開始
            param.SearchSlipDateStart = detSearchSlipDateStart.GetLongDate();

            // 伝票日付 終了
            param.SearchSlipDateEnd = detSearchSlipDateEnd.GetLongDate();

            // 受注日（開始）
            // 2007.10.09 hikita del start -------------------------------------------->>
            //param.AcpAnOrderDateStart = detAcceptAnOrderDateStart.GetLongDate();
            // 受注日（終了）
            //param.AcpAnOrderDateEnd = detAcceptAnOrderDateEnd.GetLongDate();
            // 計上日（開始）
            //param.AddUpADateStart = detAddUpADateStart.GetLongDate(); 
            // 計上日（終了）
            //param.AddUpADateEnd = detAddUpADateEnd.GetLongDate(); 
            // 2007.10.09 hikita del end ----------------------------------------------<<

            // SFUKK01404A.GetDepositAlwInfoも参照して下さい。

            // サービス伝票区分(0:OFF, 1:ON)
            param.ServiceSlipCd = 0;

            // 売掛区分(0:売掛なし,1:売掛)
            param.AccRecDivCd = -1;

            // 自動入金区分(0:通常入金,1:自動入金)
            param.AutoDepositCd = -1;
            // ↑ 20070125 18322 c

            return param;
        }

        /// <summary>
		/// 合計欄計算処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 合計欄を計算し表示します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetSalesTotal()
		{
			Int64 totalSales = 0;
			Int64 totalAlwcBlnce = 0;
			Int64 totalDeposit = 0;

			foreach (UltraGridRow dr in grdDmdSalesList.Rows)
			{
				if (dr.IsFilteredOut == false)
				{
                    // ↓ 20070125 18322 c MA.NS用に変更
					//// 売上額を合算する
					//totalSales += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctTotalSales].Value);

                    // 伝票合計を合算する
                    totalSales += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Value);
                    // ↑ 20070125 18322 c

					// 引当残 共通 (請求売上マスタ) を合算する
					totalAlwcBlnce += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value);

					// 引当額 共通 (入金引当額) を合算する
					totalDeposit += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value);
				}
			}

			// 売上額合計を表示
			labSalesTotal.Text = totalSales.ToString("###,###,##0");

			// 売上引当残高合計を表示
			labSalesAllowanceTotal.Text = totalAlwcBlnce.ToString("###,###,##0");

			// 入金合計を表示
            labDepositTotal.Text = totalDeposit.ToString("###,###,##0");
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
        /// 合計欄計算処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 合計欄を計算し表示します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private void SetSalesTotal()
        {
            Int64 totalSales = 0;
            Int64 totalAlwcBlnce = 0;
            Int64 totalDeposit = 0;

            foreach (UltraGridRow dr in grdDmdSalesList.Rows)
            {
                if (dr.IsFilteredOut == false)
                {
                    // 伝票合計を合算する
                    if (dr.Cells[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Value == DBNull.Value)
                    {
                        totalSales += 0;
                    }
                    else
                    {
                        totalSales += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Value);
                    }

                    // 引当残 を合算する
                    if (dr.Cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value == DBNull.Value)
                    {
                        totalAlwcBlnce += 0;
                    }
                    else
                    {
                        totalAlwcBlnce += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value);
                    }

                    // 引当額 を合算する
                    if (dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value == DBNull.Value)
                    {
                        totalDeposit += 0;
                    }
                    else
                    {
                        totalDeposit += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value);
                    }
                }
            }

            // 手数料
            Int64 feeDeposit = this.edtFeeDeposit.GetInt();

            // 売上額合計を表示
            labSalesTotal.Text = totalSales.ToString("###,###,##0");

            // 売上引当残高合計を表示
            labSalesAllowanceTotal.Text = totalAlwcBlnce.ToString("###,###,##0");

            // 入金合計を表示
            labDepositTotal.Text = (totalDeposit - feeDeposit).ToString("###,###,##0");

            if (totalDeposit == 0)
            {
                this.edtFeeDeposit.Clear();
                this.edtFeeDeposit.Enabled = false;
            }
            else
            {
                this.edtFeeDeposit.Enabled = true;
            }

            // 選択合計入金額を表示
            // --- UPD 2010/12/20 ----------------------------------------->>>>>
            //this.tNedit_SelectedDepositTotal.DataText = (totalDeposit + feeDeposit).ToString("###,###,##0");
            this.tNedit_SelectedDepositTotal.DataText = totalDeposit.ToString("###,###,##0");
            // --- UPD 2010/12/20 -----------------------------------------<<<<<
        }

        /// <summary>
        /// 引当額合計取得処理
        /// </summary>
        /// <returns>引当額合計</returns>
        /// <remarks>
        /// <br>Note       : 引当額の合計を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private Int64 GetAlwTotal()
        {
            Int64 totalDeposit = 0;

            foreach (UltraGridRow dr in grdDmdSalesList.Rows)
            {
                if (dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value is System.DBNull) dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value = 0; // ADD BY zhujw 2014/07/08 FOR RedMine#42902の⑨ 既存障害の対応                // 売上伝票が赤だった場合
                // 売上伝票が赤だった場合
                if ((Int32)dr.Cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value == 1)
                {
                    continue;
                }

                if (dr.IsFilteredOut == false)
                {
                    // --------------- DEL BY zhujw 2014/07/08 FOR RedMine#42902の⑨ 既存障害の対応 ---------- >>>>>
                    //if (dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value is System.DBNull) dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value = 0; // ADD BY zhujw 2014/07/08 FOR RedMine#42902の⑨ 既存障害の対応                    // --------------- DEL BY zhujw 2014/07/08 FOR RedMine#42902の⑨ 既存障害の対応 ---------- <<<<<                    // 引当額 共通 (入金引当額) を合算する
                    totalDeposit += Convert.ToInt64(dr.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Value);
                }
            }

            return totalDeposit;
        }

		/// <summary>
		/// データ検索後の画面設定処理
		/// </summary>
		/// <param name="searchDataStatus">データ検索ステータス</param>
		/// <param name="searchSalesParameter">請求売上情報取得用パラメータ</param>
		/// <remarks>
		/// <br>Note       : データ検索の結果に合わせた画面内容の表示を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
		/// </remarks>
		private void SearchAfterDisplySetting(int searchDataStatus, InputDepositSalesTypeAcs.SearchSalesParameter searchSalesParameter)
		{
			if (searchDataStatus == 0)
			{
				this._buttonNew				= true;
				this._buttonSave			= true;
                this._btnRenewal = true;
				this._buttonDelete			= false;
				this._buttonAka				= false;
				this._buttonReceiptPrint	= false;
                this._buttonReadSlip        = false;// ADD 王君 2012/12/24 Redmine#33741
                // ↓ 20070131 18322 d 売上データにクレジット情報はないので削除
                #region SF クレジット関連を入金欄へ反映する（全てコメントアウト）
                //// クレジット関連を入金欄へ反映する
				//edtCreditCompanyCode2.Text = "";
				//edtCreditCompanyName2.Text = "";
                //
				//if (searchSalesParameter.CreditOrLoanCd.Length == 1)
				//{
				//	switch (searchSalesParameter.CreditOrLoanCd[0])
				//	{
				//		case 0 :
				//			// クレジット/ローン区分
				//			cmbCreditOrLoanCd.Value = 0;
				//			// クレジット会社コード
				//			edtCreditCompanyCode2.Text = edtCreditCompanyCode.Text;
				//			// クレジット会社名称
				//			edtCreditCompanyName2.Text = edtCreditCompanyName.Text;
				//			break;
				//		case 1 :
				//			// クレジット/ローン区分
				//			cmbCreditOrLoanCd.Value = 1;
				//			// クレジット会社コード
				//			edtCreditCompanyCode2.Text = edtCreditCompanyCode.Text;
				//			// クレジット会社名称
				//			edtCreditCompanyName2.Text = edtCreditCompanyName.Text;
				//			break;
				//		case 2 :
				//			// クレジット/ローン区分
				//			cmbCreditOrLoanCd.Value = 2;
				//			// クレジット会社コード
				//			edtCreditCompanyCode2.Text = edtCreditCompanyCode.Text;
				//			// クレジット会社名称
				//			edtCreditCompanyName2.Text = edtCreditCompanyName.Text;
				//			break;
				//	}
                //}
                #endregion
                // ↑ 20070131 18322 d

                // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>
                if (this.inputDepositSalesTypeAcs.KaToOption())
                {
                    this._buttonDelete = true;
                }
                // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<
			}
			else
			{
				this._buttonNew				= false;
				this._buttonSave			= false;
                this._btnRenewal = true;
				this._buttonDelete			= false;
				this._buttonAka				= false;
				this._buttonReceiptPrint	= false;
                this._buttonReadSlip        = false; // ADD 王君 2012/12/24 Redmine#33741
			}

			// 親にツールバー状態通知
			if (ParentToolbarSettingEvent != null) ParentToolbarSettingEvent(this);

			// 更新完了フラグ
			this.updateComplete = false;

			// 一括引当ボタンアクティブ
			btnAllAwl.Enabled = true;
		}

		/// <summary>
		/// 受注伝票変更前画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 受注伝票が変更される時の画面初期化。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DisplyClearToDmdSalesChange()
		{
			// 受注引当グリッド選択行消去処理
			labDmdSalesList.Text = "";
			selectedDmdSalesRow = null;
		}

		/// <summary>
		/// 修正付加請求売上データ判断処理
		/// </summary>
		/// <param name="dr">請求売上データセットSelectDataRow</param>
		/// <returns>0x00000000:修正可能, 0x0000000f:預り金で受注締済, 0x000000f0:請求売上(赤), 0x00000f00:請求売上(相殺済み黒), 0x0000f000:前回締日以前の入金日</returns>
		/// <remarks>
		/// <br>Note       : 修正付加の請求売上データかどうかのチェックを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private uint IsLockDmdSalesData(DataRow dr)
		{
			uint retVal = 0x00000000;

            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
			// 締済み入金の時
            //if (((int)opsDepositDiv.Value == 1) && (dr[InputDepositSalesTypeAcs.ctSalesClosedFlg].ToString() != ""))
            //{
            //    retVal = retVal | 0x0000000f;
            //}
            if (dr[InputDepositSalesTypeAcs.ctSalesClosedFlg].ToString() != "")
            {
                retVal = retVal | 0x0000000f;
            }
            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<

            if (dr[InputDepositSalesTypeAcs.ctDebitNoteDiv] == DBNull.Value)
            {
                return retVal;
            }

            // 請求売上(赤)の時
			if (Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctDebitNoteDiv]) == 1)
			{
				retVal = retVal | 0x000000f0;
			}

			// 請求売上(黒)の時
			if (Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctDebitNoteDiv]) == 2)
			{
				retVal = retVal | 0x00000f00;
			}

			// 前回締日より過去の入金日の時
			if (edtDepositDate.GetLongDate() <= Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctLastTotalAddUpDt]))
			{
				retVal = retVal | 0x0000f000;
			}

            // 2007.10.09 hikita del start ---------------------------------------------------------------------->>
            // ↓ 20070801 18322 a
			//if (edtDepositDate.GetLongDate() <= Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctLastMonthlyDate]))
			//{
			//	retVal = retVal | 0x0000f000;
			//}
            // ↑ 20070801 18322 a
            
            // ↓ 20070525 18322 a
            // POS入力で売掛区分が"0:売掛なし"の時
            //if ((Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctPosReceiptNo]) > 0) &&
            //    (Convert.ToInt32(dr[InputDepositSalesTypeAcs.ctAccRecDivCd]) == 0)   )
            //{
			//	retVal = retVal | 0x000f0000;
			//}
            // ↑ 20070525 18322 a
            // 2007.10.09 hikita del end ------------------------------------------------------------------------<<

			return retVal;
		}

		/// <summary>
		/// 入金伝票保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金伝票の保存処理を行います。</br>
		/// <returns>処理結果 0:正常更新, 1:保存前不正データチェックエラー, 2:その他エラー</returns>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SaveDeposit()
		{
			// 受注一覧の引当内容を反映させるため
			grdDmdSalesList.ActiveCell = null;

			// 保存前データチェック処理
			DataRow[] drDmdSalesList;
			InputDepositSalesTypeAcs.UpdateDepositParameter updateDepositParameter;
			Control control;
			switch (this.CheackDataBeforeSave(out updateDepositParameter, out drDmdSalesList, out control))
			{
				case -1 :			// --- エラー --- //
					
					if (control != null)
					{
						control.Focus();
					}

					// 受注一覧行カラー設定処理
					DmdSalesListRowColorSetting(drDmdSalesList, Color.LightSalmon);

					return 1;

				case 1  :			// --- 警告 --- //

					if (control != null)
					{
						control.Focus();
					}

					// 受注一覧行カラー設定処理
					DmdSalesListRowColorSetting(drDmdSalesList, Color.LightSteelBlue);

					return 1;

				default :			// --- 正常 --- //

					// 受注一覧行カラー設定処理
					DmdSalesListRowColorSetting(null, Color.Empty);
					
					break;
			}

			try
			{
				this.Cursor = Cursors.WaitCursor;

                // 保存前の入金日を退避
                DateTime dtDepositDate = this.edtDepositDate.GetDateTime();

				// 入金データ保存処理
                // --- DEL zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
                //string message;
                //int st = inputDepositSalesTypeAcs.SaveDepositData(updateDepositParameter, drDmdSalesList, out message);
                // --- DEL zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
                string message = string.Empty;
                int st = 0;
                // 手数料入力無し場合
                if (string.IsNullOrEmpty(edtFeeDeposit.Text) && this.inputDepositSalesTypeAcs.KaToOption())
                {
                    for (int i = 0; i < drDmdSalesList.Length; i++)
                    {
                        DataRow[] dataRow = new DataRow[1];
                        dataRow[0] = drDmdSalesList[i];
                        st = inputDepositSalesTypeAcs.SaveDepositData(updateDepositParameter, dataRow, out message);
                    }
                }
                else
                // 手数料入力有る場合
                {
                    st = inputDepositSalesTypeAcs.SaveDepositData(updateDepositParameter, drDmdSalesList, out message);
                }
                // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            // エラー発生
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金番号を別端末が採番しています。しばらくお待ちになって再度実行してください。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                            return 1;
                        }
                    // 企業ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                            //TMsgDisp.Show(this,
                            //            emErrorLevel.ERR_LEVEL_STOPDISP,
                            //            this.Name,
                            //            "保存に失敗しました。" + "\r\n"
                            //            + "\r\n" +
                            //            "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                            //            "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                            //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                            //            st,
                            //            MessageBoxButtons.OK);
                            TMsgDisp.Show( this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "処理が込み合っているため中断しました。" + "\r\n" +
                                "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                                st,
                                MessageBoxButtons.OK );
                            // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                            return (st);
                        }
                    // 拠点ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    // --- ADD m.suzuki 2010/08/18 ---------->>>>>
                    // 締次ロック(伝票側)タイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT:
                    // --- ADD m.suzuki 2010/08/18 ----------<<<<<
                        {
                            // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                            //TMsgDisp.Show(this,
                            //            emErrorLevel.ERR_LEVEL_STOPDISP,
                            //            this.Name,
                            //            "保存に失敗しました。" + "\r\n"
                            //            + "\r\n" +
                            //            "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                            //            "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                            //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                            //            st,
                            //            MessageBoxButtons.OK);
                            TMsgDisp.Show( this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "処理が込み合っているため中断しました。" + "\r\n" +
                                "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                                st,
                                MessageBoxButtons.OK );
                            // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                            return (st);
                        }
                    // 倉庫ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                            //TMsgDisp.Show(this,
                            //            emErrorLevel.ERR_LEVEL_STOPDISP,
                            //            this.Name,
                            //            "保存に失敗しました。" + "\r\n"
                            //            + "\r\n" +
                            //            "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                            //            "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                            //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                            //            st,
                            //            MessageBoxButtons.OK);
                            TMsgDisp.Show( this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "処理が込み合っているため中断しました。" + "\r\n" +
                                "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                                st,
                                MessageBoxButtons.OK );
                            // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                            return (st);
                        }
                    // --- ADD m.suzuki 2010/08/18 ---------->>>>>
                    // 締次ロック(集計側)タイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show( this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "対象の期間を集計処理中のため中断しました。" + "\r\n" +
                                "入金日を変更して、再度処理を実行して下さい。" + "\r\n",
                                st,
                                MessageBoxButtons.OK );
                            return (st);
                        }
                    // --- ADD m.suzuki 2010/08/18 ----------<<<<<
                    default:
                        {
                            // エラー発生
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "入金伝票の保存処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                            return 2;
                        }
                }

                // ↓ 20070220 18322 a MA.NS用に変更
				// 請求売上情報を全件ループ
				foreach (UltraGridRow rw in this.grdDmdSalesList.Rows)
				{
					if ((bool)rw.Cells[InputDepositSalesTypeAcs.ctAlwCheck].Value)
					{
                        // 引当チェックが入っている場合

                        // 引当額 共通 (入金引当額) 最大額取得処理
                        DataRow  dr = rw.Cells[InputDepositSalesTypeAcs.ctDmdSalesDataRow].Value as DataRow;
                        if (dr != null)
                        {
                            // 保存したので入力された入金引当額をクリア
                            dr[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = 0;
                        }

                        rw.Cells[InputDepositSalesTypeAcs.ctAlwCheck].Value = false;
                        //rw.Cells[InputDepositSalesTypeAcs.ctAlwCheck].Column.CellActivation = Activation.NoEdit;
                    }
                }
                
				// 合計欄計算処理
				this.SetSalesTotal();
                // ↑ 20070220 18322 a

                // 退避した入金日を元に戻す。
                this.edtDepositDate.SetDateTime(dtDepositDate);

				// 保存確認ダイアログ表示
				SaveCompletionDialog dialog = new SaveCompletionDialog();
				dialog.ShowDialog(2);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return 0;
		}
		
		/// <summary>
		/// 保存前データチェック処理
		/// </summary>
		/// <param name="updateDepositParameter">入金更新用クラス</param>
		/// <param name="drDmdSalesList">更新/エラー/警告対象請求情報DataRow</param>
		/// <param name="control">エラーコントロール</param>
		/// <returns>チェック結果  0:正常, -1:エラー, 1:警告</returns>
		/// <remarks>
		/// <br>Note       : 入金内容の保存前データチェックを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note: 2013/07/18 呉軍</br>
        /// <br>管理番号   : 配信日なし</br>
        /// <br>             Redmine#35133既存障害№1の対応</br>
		/// </remarks>
		private int CheackDataBeforeSave(out InputDepositSalesTypeAcs.UpdateDepositParameter updateDepositParameter, out DataRow[] drDmdSalesList, out Control control)
		{
			drDmdSalesList = null;
			updateDepositParameter = null;
			control = null;

            if (this._searchFlg)
            {
                if (this.tNedit_CustomerCode.GetInt() != this._prevCustomerCode)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "得意先コードが変更されています。", 0, MessageBoxButtons.OK);
                    control = this.tNedit_CustomerCode;

                    // 新規入力準備処理
                    this.NewInputStandby();

                    return -1;
                }
            }

			// 未来入金日チェック
			if (edtDepositDate.GetLongDate() > TDateTime.GetSFDateNow("YYYYMMDD"))
			{
				DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "未来日付での入金ですが、よろしいですか？", 0, MessageBoxButtons.OKCancel);
				if (res == DialogResult.Cancel)
				{
					control = edtDepositDate;
					return -1;
				}
			}

			// 入金日チェック
			if (edtDepositDate.GetLongDate() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日を入力して下さい。", 0, MessageBoxButtons.OK);
				control = edtDepositDate;
				return -1;
			}
			if (TDateTime.IsAvailableDate(edtDepositDate.GetDateTime()) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日の日付が不正です。", 0, MessageBoxButtons.OK);
				control = edtDepositDate;
				return -1;
			}

			// 入金金種チェック
			if (cmbMoneyKind.SelectedIndex == -1)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金金種を選択して下さい。", 0, MessageBoxButtons.OK);
				control = cmbMoneyKind;
				return -1;
			}

            if (((int)depositRelDataAcs.HtMoneyKindDiv[(int)cmbMoneyKind.Value] == 105) ||
                ((int)depositRelDataAcs.HtMoneyKindDiv[(int)cmbMoneyKind.Value] == 107))
            {
                // 期日
                if (dateDraftPayTimeLimit.GetLongDate() == 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "期日を入力して下さい。", 0, MessageBoxButtons.OK);
                    control = dateDraftPayTimeLimit;
                    return -1;
                }
                if (TDateTime.IsAvailableDate(dateDraftPayTimeLimit.GetDateTime()) == false)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "期日の日付が不正です。", 0, MessageBoxButtons.OK);
                    control = dateDraftPayTimeLimit;
                    return -1;
                }
            }

            // 引当額合計を取得
            Int64 depositAlwTotal = GetAlwTotal();

            // 手数料を取得
            Int64 feeDeposit = this.edtFeeDeposit.GetInt();

            if (depositAlwTotal >= 0)
            {
                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- >>>>>
                //if (feeDeposit < 0)
                //{
                //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手数料の値が不正です。", 0, MessageBoxButtons.OK);
                //    control = this.edtFeeDeposit;
                //    return -1;
                //}
                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- <<<<<
                if (depositAlwTotal < feeDeposit)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手数料の値が不正です。", 0, MessageBoxButtons.OK);
                    control = this.edtFeeDeposit;
                    return -1;
                }
            }
            else
            {
                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- >>>>>
                //if (feeDeposit > 0)
                //{
                //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手数料の値が不正です。", 0, MessageBoxButtons.OK);
                //    control = this.edtFeeDeposit;
                //    return -1;
                //}
                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- <<<<<
                if (depositAlwTotal > feeDeposit)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手数料の値が不正です。", 0, MessageBoxButtons.OK);
                    control = this.edtFeeDeposit;
                    return -1;
                }
            }

            // 2007.10.09 hikita del start ---------------------------------------------------------->>
            //if (this.cmbCreditOrLoanCd.Enabled)
            //{
                // クレジット・ローン区分が入力可のとき、クレジット会社入力チェック
            //    if (this.edtCreditCompanyName2.Text.Trim() == "")
            //    {
    	    //		TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "クレジット会社を入力して下さい。", 0, MessageBoxButtons.OK);
            //        if (this.btnCreditCompanyGuid2.Enabled)
            //        {
                        // クレジット会社コード
    		//		    control = this.edtCreditCompanyCode2;
            //        }
            //        else
            //        {
                        // クレジット・ローン区分
    		//		    control = this.cmbCreditOrLoanCd;
            //        }
			//	    return -1;
            //    }
            //}
            // 2007.10.09 hikita del end ------------------------------------------------------------<<

			// 入金更新用クラス取得処理
			updateDepositParameter = GetUpdateDepositParameter();

			string message;

			// 更新対象データの取得/不正チェック処理
			if (inputDepositSalesTypeAcs.CheackUpdateDate(updateDepositParameter, out drDmdSalesList, out message) != 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, message, 0, MessageBoxButtons.OK);
				control = grdDmdSalesList;
				return -1;
			}

			// 更新対象データ更新前確認メッセージ処理
			StringCollection messages;
			ArrayList drDmdSalesQuestionList;
			if (inputDepositSalesTypeAcs.CheckUpdateDepositQuestion(updateDepositParameter, out drDmdSalesQuestionList, out messages) != 0)
			{
				for (int ix = 0; ix < messages.Count; ix++)
				{
					DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, messages[ix], 0, MessageBoxButtons.OKCancel);
					if (res == DialogResult.Cancel)
					{
						drDmdSalesList = (DataRow[])drDmdSalesQuestionList[ix];
						return 1;
					}
				}
			}

			return 0;
		}

		/// <summary>
		/// 入金更新用クラス取得処理
		/// </summary>
		/// <returns>入金更新用クラス</returns>
		/// <remarks>
		/// <br>Note       : 入金更新用情報の取得を行います。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// <br>Update Note: 2012/09/21 田建委</br>
        /// <br>管理番号   : 2012/10/17配信分</br>
        /// <br>             Redmine#32415 発行者の追加対応</br>
		/// </remarks>
		private InputDepositSalesTypeAcs.UpdateDepositParameter GetUpdateDepositParameter()
		{
			// 入金更新用クラスセット
			InputDepositSalesTypeAcs.UpdateDepositParameter updateDepositParameter = new InputDepositSalesTypeAcs.UpdateDepositParameter();
			
			updateDepositParameter.EnterpriseCode = enterpriseCode;

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //updateDepositParameter.LoginSectionCode = this.employee.BelongSectionCode;
            updateDepositParameter.InputDepositSecCd = this.employee.BelongSectionCode;
            updateDepositParameter.UpdateSecCode = this.employee.BelongSectionCode;
            //updateDepositParameter.AddSectionCode = selectSectionCode;
            updateDepositParameter.AddUpSecCode = selectSectionCode;
            //updateDepositParameter.EmployeeCd = employee.EmployeeCode;
            updateDepositParameter.DepositAgentCode = employee.EmployeeCode;
            // ↓ 20070131 18322 c MA.NS用に変更
            //updateDepositParameter.EmployeeName = employee.Name;
            updateDepositParameter.DepositAgentNm = employee.Name;
            // ↑ 20070131 18322 c
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
			updateDepositParameter.DepositDate = edtDepositDate.GetLongDate();

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			updateDepositParameter.DepositCd = (int)opsDepositDiv.Value;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //if (cmbMoneyKind.Value is int)
            //{
            //    updateDepositParameter.DepositKindCode = (int)cmbMoneyKind.Value;
            //}
            //else
            //{
            //    updateDepositParameter.DepositKindCode = 0;
            //}
            if (cmbMoneyKind.Value is int)
            {
                updateDepositParameter.MoneyKindCode = (int)cmbMoneyKind.Value;
            }
            else
            {
                updateDepositParameter.MoneyKindCode = 0;
            }
            updateDepositParameter.MoenyKindName = cmbMoneyKind.Text;
            updateDepositParameter.ValidityTerm = this.dateDraftPayTimeLimit.GetLongDate();
            updateDepositParameter.FeeDeposit = this.edtFeeDeposit.GetInt();
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // 2007.10.09 hikita del start ------------------------------------------------------------>>
			// updateDepositParameter.CreditOrLoanCd = (Int16)cmbCreditOrLoanCd.Value;      
			// updateDepositParameter.CreditCompanyCode = (string)edtCreditCompanyCode2.Value;
            // 2007.10.09 hikita del end --------------------------------------------------------------<<

            // 2007.10.09 hikita add start ------------------------------------------------------------>>
            //// 銀行コード
            //updateDepositParameter.BankCode = this.tNedit_BankCode.GetInt();
            //// 銀行名称
            //updateDepositParameter.BankName = teditBankName.Text;
            //// 手形種類
            //updateDepositParameter.DraftKind = Convert.ToInt32(cmbDraftKind.Value); 
            //// 手形種類名称
            //updateDepositParameter.DraftKindName = cmbDraftKind.Text;
            //// 手形区分
            //updateDepositParameter.DraftDivide = Convert.ToInt32(cmbDraftDivide.Value);
            //// 手形区分名称
            //updateDepositParameter.DraftDivideName = cmbDraftDivide.Text;
            //// 手形番号
            //updateDepositParameter.DraftNo = tEdit_DraftNo.Text;
            // 摘要
            updateDepositParameter.Outline = this.edtOutline.DataText.Trim();
            // 2007.10.09 hikita add end --------------------------------------------------------------<<

            // --- ADD m.suzuki 2010/08/18 ---------->>>>>
            // 請求先コード（締日取得に使用する）
            updateDepositParameter.ClaimCode = this.claimCode;
            // --- ADD m.suzuki 2010/08/18 ----------<<<<<

            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            updateDepositParameter.DepositInputAgentCd = tEdit_EmployeeCode.DataText;   // 発行者コード
            updateDepositParameter.DepositInputAgentNm = tEdit_SalesInputName.DataText; // 発行者名
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<

   			return updateDepositParameter;
		}

		/// <summary>
		/// 領収書発行処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金伝票の領収書発行処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void ReceiptPrint()
		{
			// 引当額 共通 (入金引当額) がセットされていれば取得する
			if ((Int64)selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] <= 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金金額が0円以上の伝票を選択して下さい。", 0, MessageBoxButtons.OK);
				return;
			}

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 領収書データ作成処理
				Receipt receipt = inputDepositSalesTypeAcs.SetReceiptFromDepositDataRow(enterpriseCode, this.employee.BelongSectionCode, selectedDmdSalesRow);

                // ↓ 20070519 18322 d 今のところ使用しないので削除
				//// 領収書発行呼出
				//if (sfukk01502UA == null) sfukk01502UA = new SFUKK01502UA();
				//sfukk01502UA.ShowReceiptPrintDialogFromDeposit(this, receipt);
                // ↑ 20070519 18322 d
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 受注一覧行カラー設定処理
		/// </summary>
		/// <param name="drDmdSalesList">エラー行リスト</param>
		/// <param name="cl">行色</param>
		/// <remarks>
		/// <br>Note       : 受注一覧行のカラー設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DmdSalesListRowColorSetting(DataRow[] drDmdSalesList, Color cl)
		{
			if (drDmdSalesList == null)
			{
				// 正常時は全行デフォルトカラーにする
				foreach (UltraGridRow rw in grdDmdSalesList.Rows)
				{
					rw.Appearance.BackColor = Color.Empty;
				}
			} 
			else
			{
				// エラー時は対象行に色をつける
				foreach (DataRow dr in drDmdSalesList)
				{
					foreach (UltraGridRow rw in grdDmdSalesList.Rows)
					{
						// if (rw.Cells[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Text == dr[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].ToString())  // 2007.10.09 hikita del
                        if (rw.Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Text == dr[InputDepositSalesTypeAcs.ctSalesSlipNum].ToString())  // 2007.10.09 hikita add
						{
							rw.Appearance.BackColor = cl;
						}
					}
				}
			}
        }

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 得意先名称セット処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称を設定します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void SetCustomerName(string customerName, int paraClaimCode)
        {
            edtCustomerName.Text = customerName;
            this.claimCode = paraClaimCode;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start ------------------------------------>>
        ///// <summary>
        ///// クレジット会社名称(受注検索欄)セット処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : クレジット会社名称(受注検索欄)を設定します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        //private void SetCreditCompanyName(string creditCompanyName)
		//{
		//	 edtCreditCompanyName.Text = creditCompanyName;   
		//}
        ///// <summary>
        ///// 販売担当者名称セット処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 販売担当者名称を設定します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        //private void SetSalesEmployeeName(string salesEmployeeName)
		//{
		//	edtSalesEmployeeName.Text = salesEmployeeName;
		//}
        ///// <summary>
        ///// クレジット会社名称(入金伝票入力欄)セット処理
        ///// </summary>
        ///// <param name="creditCompanyCode">情報取得用パラメータ クレジット会社コード</param>
        ///// <param name="creditCompanyName">クレジット会社名称</param>
        ///// <remarks>
        ///// <br>Note       : クレジット会社名称を設定します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        // private void SetCreditCompanyName2(string creditCompanyCode, string creditCompanyName)
		// {
			// コード無しの時はクリア
		//	if (creditCompanyCode.Equals(""))
		//	{
        //        if (edtCreditCompanyCode2.Text != "")
        //        {
        //            if (this.InvokeRequired)
        //            {
        //                this.Invoke(new GetCreditCompanyNamePrc2.Callback(this.SetCreditCompanyName2), new object[]{creditCompanyCode, creditCompanyName});
        //            }
        //            else
        //            {
        //				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
        //                              this.Name, 
		//						      "該当するクレジット会社が\r\n見つかりませんでした。",
        //                              0,
        //                              MessageBoxButtons.OK);
        //            }
        //        }
		//		edtCreditCompanyCode2.Text = "";
		//		edtCreditCompanyName2.Text = "";
		//		return;
		//	}
			// クレジット会社コードが同一の時
		//	if (edtCreditCompanyCode2.Text.Equals(creditCompanyCode))
		//	{
		//		edtCreditCompanyName2.Text = creditCompanyName;
		//	}
		//}
        // 2007.10.09 hikita del end ------------------------------------------------------------<<
        #endregion 2007.10.09 hikita del

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.09 hikita add start ---------------------------------------------------------->>
        /// <summary>
        /// 銀行名称セット処理
        /// </summary>
        /// <param name="bankCode">情報取得用パラメータ 銀行コード</param>
        /// <param name="bankName">銀行名称</param>
        /// <remarks>
        /// <br>Note       : 銀行名称を設定します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        private void SetBankName(int bankCode, string bankName)
        {
            // コード無しの時はクリア
            if (bankCode.Equals(""))
            {
                if (!tNedit_BankCode.DataText.Equals("0"))
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new GetBankNamePrc.Callback(this.SetBankName), new object[] { bankCode, bankName });
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "該当する銀行が\r\n見つかりませんでした。",
                                      0,
                                      MessageBoxButtons.OK);
                    }
                }
                tNedit_BankCode.Text = "";
                teditBankName.Text = "";
                return;
            }
            // 銀行コードが同一の時
            if (tNedit_BankCode.Text.Equals(bankCode))
            {
                teditBankName.Text = bankName;
            }
        }
        // 2007.10.09 hikita add end ------------------------------------------------------------<<

        /// <summary>
		/// 得意先名称取得スレッド開始処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : スレッドを開始します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void CustomerNamePrcThreadStart()
		{
			// スレッドが実行中だったら処理を中断させる
			if ((customerNamePrcThread != null) && (customerNamePrcThread.ThreadState == ThreadState.Running))
			{
				customerNamePrcThread.Abort();
			}

			// オブジェクトの作成
			GetCustomerNamePrc getCustomerNamePrc = new GetCustomerNamePrc(enterpriseCode, tNedit_CustomerCode.GetInt(), new GetCustomerNamePrc.Callback(this.SetCustomerName));

			// Threadオブジェクトを作成する
			customerNamePrcThread = new Thread(new System.Threading.ThreadStart(getCustomerNamePrc.Main));

			// スレッドを開始する
			customerNamePrcThread.Start();
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start ---------------------------------------------------------->>
        ///// <summary>
        ///// クレジット会社名称(受注検索欄)取得スレッド開始処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : スレッドを開始します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        //private void CreditCompanyNamePrcThreadStart()
		//{
			// スレッドが実行中だったら処理を中断させる
		//	if ((creditCompanyNamePrcThread != null) && (creditCompanyNamePrcThread.ThreadState == ThreadState.Running))
		//	{
		//		creditCompanyNamePrcThread.Abort();
		//	}
			// オブジェクトの作成
		//	GetCreditCompanyNamePrc getCreditCompanyNamePrc = new GetCreditCompanyNamePrc(enterpriseCode, edtCreditCompanyCode.DataText, new GetCreditCompanyNamePrc.Callback(this.SetCreditCompanyName));
			// Threadオブジェクトを作成する
		//	creditCompanyNamePrcThread = new Thread(new System.Threading.ThreadStart(getCreditCompanyNamePrc.Main));
			// スレッドを開始する
		//	creditCompanyNamePrcThread.Start();
		//}
        ///// <summary>
        ///// 販売従業員取得スレッド開始処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : スレッドを開始します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
		//private void SalesEmployeeNamePrcThreadStart()
		//{
			// スレッドが実行中だったら処理を中断させる
		//	if ((salesEmployeeNamePrcThread != null) && (salesEmployeeNamePrcThread.ThreadState == ThreadState.Running))
		//	{
		//		salesEmployeeNamePrcThread.Abort();
		//	}

			// オブジェクトの作成
		//	GetEmployeeNamePrc getEmployeeNamePrc = new GetEmployeeNamePrc(enterpriseCode, edtSalesEmployee.DataText, 2, new GetEmployeeNamePrc.Callback(this.SetSalesEmployeeName));

			// Threadオブジェクトを作成する
		//	salesEmployeeNamePrcThread = new Thread(new System.Threading.ThreadStart(getEmployeeNamePrc.Main));

			// スレッドを開始する
		//	salesEmployeeNamePrcThread.Start();
		//}
        ///// <summary>
        ///// クレジット会社名称(入金伝票入力欄)取得スレッド開始処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : スレッドを開始します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
  		//private void CreditCompanyName2PrcThreadStart()
		//{
			// スレッドが実行中だったら処理を中断させる
		//	if ((creditCompanyName2PrcThread != null) && (creditCompanyName2PrcThread.ThreadState == ThreadState.Running))
		//	{
		//		creditCompanyName2PrcThread.Abort();
		//	}

			// オブジェクトの作成
		//	GetCreditCompanyNamePrc2 getCreditCompanyNamePrc = new GetCreditCompanyNamePrc2(enterpriseCode, edtCreditCompanyCode2.DataText, new GetCreditCompanyNamePrc2.Callback(this.SetCreditCompanyName2));

			// Threadオブジェクトを作成する
		//	creditCompanyName2PrcThread = new Thread(new System.Threading.ThreadStart(getCreditCompanyNamePrc.Main));

			// スレッドを開始する
		//	creditCompanyName2PrcThread.Start();
		//}
        // 2007.10.09 hikita del end -------------------------------------------------------------------------------<<
        #endregion 2007.10.09 hikita del

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.09 hikita add start ----------------------------------------------------------------------------->>
        /// <summary>
        /// 銀行名称取得スレッド開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : スレッドを開始します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        private void BankNamePrcThreadStart()
        {
            // スレッドが実行中だったら処理を中断させる
            if ((bankNamePrcThread != null) && (bankNamePrcThread.ThreadState == ThreadState.Running))
        	{
                bankNamePrcThread.Abort();
        	}

            // オブジェクトの作成
            GetBankNamePrc getBankNamePrc = new GetBankNamePrc(enterpriseCode, tNedit_BankCode.GetInt(), new GetBankNamePrc.Callback(this.SetBankName));

            // Threadオブジェクトを作成する
            bankNamePrcThread = new Thread(new System.Threading.ThreadStart(getBankNamePrc.Main));

            // スレッドを開始する
            bankNamePrcThread.Start();
        }
        // 2007.10.09 hikita add end -------------------------------------------------------------------------------<<
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 引当チェック変更処理
		/// </summary>
		/// <param name="cell">対象セル</param>
		/// <remarks>
		/// <br>Note　　　  : 引当額の再計算を行います。 </br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		private void ChangeAlwcCheck(UltraGridCell cell)
		{
			if (cell.Text == "True")		// --- チェックONの時 --- //
			{
                // 伝票合計取得
                Int64 salesTotalExc = Convert.ToInt64(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctSalesTotalTaxExc]);

                // 引当済金額取得
                Int64 depositAllowanceSales = Convert.ToInt64(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales]);

                // 引当残金額取得
                Int64 depositAlwcBlnceSales = Convert.ToInt64(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales]);

                if (depositAllowanceSales == 0)
                {
                    // 未引当の場合
                    // 引当額設定
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = salesTotalExc;

                    // 引当残設定(伝票合計－引当額)
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                    // 引当済設定
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = salesTotalExc;
                }
                else
                {
                    // 引当済の場合
                    // 引当額設定
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = depositAlwcBlnceSales;

                    // 引当残
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                    // 引当済
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = salesTotalExc;
                }

                this.grdDmdSalesList.Rows[cell.Row.Index].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activation = Activation.AllowEdit;

                this.grdDmdSalesList.Rows[cell.Row.Index].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
                this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
            }
			else							// --- チェックOFFの時 --- //
			{
                // 変更前引当残取得
                Int64 bfDepositAlwBlnce_Sales = Convert.ToInt64(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctBfDepositAlwcBlnce_Sales]);

                // 変更前引当済取得
                Int64 bfDepositAllowance_Sales = Convert.ToInt64(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctBfDepositAllowance_Sales]);

                // 引当額設定
                selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = 0;

                // 引当残設定(伝票合計－引当額)
                selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = bfDepositAlwBlnce_Sales;

                // 引当済設定
                selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = bfDepositAllowance_Sales;

                this.grdDmdSalesList.Rows[cell.Row.Index].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activation = Activation.Disabled;
            }

            //// 引当額 共通 (入金引当額) 列が表示されている時
            //if (cell.Row.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Column.Hidden == false)
            //{
            //    // 引当額 共通 (入金引当額) 列をアクティブにする
            //    cell.Row.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
            //}

            // 合計欄計算処理
            SetSalesTotal();
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 引当チェック変更処理
        /// </summary>
        /// <param name="cell">対象セル</param>
        /// <remarks>
        /// <br>Note　　　  : 引当額の再計算を行います。 </br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void ChangeAlwcCheck(UltraGridCell cell)
        {
            Int64 difference;

            if (cell.Text == "True")		// --- チェックONの時 --- //
            {
                // ↓ 20070125 18322 c MA.NS用に変更
                #region SF 引当額・入金引当情報更新処理（全てコメントアウト）
                //// 諸費用別入金判定
                //if (depositRelDataAcs.OptSeparateCost == true)			// --- 諸費用別入金 有り --- //
                //{
                //	// 引当額 受注 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxAcpOdrDepositAlwc(selectedDmdSalesRow);
                //    
                //	// 入金引当情報 受注 変更処理
                //	inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //    
                //	// 引当額 諸費用 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxCostDepositAlwc(selectedDmdSalesRow);
                //    
                //	// 入金引当情報 諸費用 変更処理
                //	inputDepositSalesTypeAcs.UpdateCostDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //
                //	// 引当額 共通 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(selectedDmdSalesRow);
                //
                //	// 入金引当情報 共通 変更処理
                //	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //}
                //else													// --- 諸費用別入金 無し --- //
                //{
                //	// 諸費用別入金無しの時は、共通の項目をベースに計算し、受注に反映させる
                //	// ※このやり方でないと、諸費用別入金オプションの途中削除がうまくいかないはず
                //
                //	// 引当額 共通 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(selectedDmdSalesRow);
                //
                //	// 入金引当情報 共通 変更処理
                //	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //
                //	// 入金引当情報 受注 変更処理
                //	inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //}
                #endregion


                // 引当額 共通 (入金引当額) 最大額取得処理
                difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(selectedDmdSalesRow);

                // 入金引当情報 共通 変更処理
                //inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, false, false);
                // ↑ 20070125 18322 c
            }
            else							// --- チェックOFFの時 --- //
            {
                // ↓ 20070125 18322 c MA.NS用に変更
                //// 引当額 受注 (入金引当額) クリア額処理
                //difference = inputDepositSalesTypeAcs.GetClearAcpOdrDepositAlwc(selectedDmdSalesRow);
                //
                //// 入金引当情報 受注 変更処理
                //inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                //
                //// 引当額 諸費用 (入金引当額) クリア額処理
                //difference = inputDepositSalesTypeAcs.GetClearCostDepositAlwc(selectedDmdSalesRow);
                //
                //// 入金引当情報 諸費用 変更処理
                //inputDepositSalesTypeAcs.UpdateCostDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                // ↑ 20070125 18322 c

                // 引当額 共通 (入金引当額) クリア額処理
                difference = inputDepositSalesTypeAcs.GetClearDepositAlwc(selectedDmdSalesRow);

                // 入金引当情報 共通 変更処理
                //inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
                inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, false, false, true);
            }


            // 引当額 共通 (入金引当額) 列が表示されている時
            if (cell.Row.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Column.Hidden == false)
            {
                // 引当額 共通 (入金引当額) 列をアクティブにする
                cell.Row.Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
            }
            // ↓ 20070125 18322 c MA.NS用に変更
            //// 引当額 受注 (入金引当額) 列が表示されている時
            //else if (cell.Row.Cells[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Column.Hidden == false)
            //{
            //	// 引当額 受注 (入金引当額) 列をアクティブにする
            //	cell.Row.Cells[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw].Activate();
            //}
            // ↑ 20070125 18322 c

            // 合計欄計算処理
            this.SetSalesTotal();
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // ↓ 20070130 18322 d MA.NS用に変更
        #region SF 選択中システム/伝票種別取得処理（全てコメントアウト）
        ///// <summary>
		///// 選択中システム/伝票種別取得処理
		///// </summary>
		///// <param name="lstDataInputSystem">システム</param>
		///// <param name="lstSlipKindCode">伝票種別</param>
		///// <remarks>
		///// <br>Note       : 選択中の受注検索用システム/伝票種別の内容を取得します。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//private void GetSelectSystemSlipKind(out int[] lstDataInputSystem, out int[] lstSlipKindCode)
		//{
		//	ArrayList alDataInputSystem = new ArrayList();
		//	ArrayList alSlipKindCode = new ArrayList();
		//
		//	// 整備
		//	if (cbxDataInputSystem1.Checked)
		//	{
		//		// 見積
		//		if (cbxAcptAnOdrStartus1.Checked)
		//		{
		//			alDataInputSystem.Add(1);
		//			alSlipKindCode.Add(10);
		//		}
		//		// 指示/納品
		//		if ((cbxAcptAnOdrStartus2.Checked) || (cbxAcptAnOdrStartus3.Checked))
		//		{
		//			alDataInputSystem.Add(1);
		//			alSlipKindCode.Add(20);
		//		}
		//	}
		//
		//	// 鈑金
		//	if (cbxDataInputSystem2.Checked)
		//	{
		//		// 見積
		//		if (cbxAcptAnOdrStartus1.Checked)
		//		{
		//			alDataInputSystem.Add(2);
		//			alSlipKindCode.Add(10);
		//		}
		//		// 指示/納品
		//		if ((cbxAcptAnOdrStartus2.Checked) || (cbxAcptAnOdrStartus3.Checked))
		//		{
		//			alDataInputSystem.Add(2);
		//			alSlipKindCode.Add(20);
		//		}
		//	}
		//
		//	// 車販
		//	if (cbxDataInputSystem3.Checked)
		//	{
		//		// 見積
		//		if (cbxAcptAnOdrStartus1.Checked)
		//		{
		//			alDataInputSystem.Add(3);
		//			alSlipKindCode.Add(10);
		//		}
		//		// 指示/納品
		//		if ((cbxAcptAnOdrStartus2.Checked) || (cbxAcptAnOdrStartus3.Checked))
		//		{
		//			alDataInputSystem.Add(3);
		//			alSlipKindCode.Add(20);
		//		}
		//	}
		//
		//	lstDataInputSystem = alDataInputSystem.ToArray(typeof(Int32)) as Int32[];
		//	lstSlipKindCode = alSlipKindCode.ToArray(typeof(Int32)) as Int32[];
        //}
        #endregion
        // ↑ 20070130 18322 d

		/// <summary>
		/// TEditプロパティー変換処理
		/// </summary>
		/// <param name="tEdit">変換対象コントロール</param>
		/// <remarks>
		/// <br>Note       : プロパティーの設定内容を変換します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void TEditChangeEdit(Broadleaf.Library.Windows.Forms.TEdit tEdit)
		{
			// 部品にて設定値が取得出来なかった場合に備えて初期設定しておく
			tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

			if (NumberControl.NoTypeMngList == null) return;

            // ↓ 20070130 18322 c MA.NS用に変更
            #region SF 選択中システム/伝票種別取得処理（全てコメントアウト）
            //// 選択中システム/伝票種別取得処理
			//int[] lstDataInputSystem;
			//int[] lstSlipKindCode;
			//this.GetSelectSystemSlipKind(out lstDataInputSystem, out lstSlipKindCode);
            //
			//// システム/伝票種別が選択されていない場合は以下の処理を実行しない
			//if ((lstDataInputSystem.Length == 0) || (lstSlipKindCode.Length == 0)) return;
            //
			//// 各システム伝票番号番号コード取得処理
			//int[] noCodeArray = ConstantManagement_SF_AP.GetSlipNoNoCode(lstDataInputSystem, lstSlipKindCode);
            //
            //if (noCodeArray.Length == 0) return;
            #endregion

            int noCodeArray = ctNoCodeSalesSlipNum;
            //↑ 20070130 18322 c

			NumberControl numberControl = new NumberControl();

			// MaxLengthプロパティ設定
			Int32 maxLength = numberControl.GetLength(noCodeArray);
			Int32 inputType = numberControl.GetInputType(noCodeArray);

			if (maxLength > 0) 
			{
				
				if (inputType == 0)		// 数値の場合
				{
					tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, maxLength, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
				}
				else					// 文字の場合
				{
					tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, maxLength, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
				}
			}

			// TextHAlignプロパティ設定
			Int32 posi = numberControl.GetDispPosition(noCodeArray);

			if (posi == 0)
			{
				tEdit.NormalAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			}
			else
			{
				tEdit.NormalAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			}

		}

		/// <summary>
		/// オブジェクト→数値変換処理
		/// </summary>
		/// <param name="obj">元の値</param>
		/// <param name="def">変換エラー時初期値</param>
		/// <returns>変換後の値</returns>
		/// <remarks>
		/// <br>Note       : オブジェクトから数字への変換処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private Int64 StrToIntDef(object obj, Int64 def)
		{
			try
			{
				return Convert.ToInt64(obj);
			}
			catch(System.Exception)
			{
				return def;
			}
		}
		# endregion

		# region Control Events
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込む時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SFUKK01406UA_Load(object sender, System.EventArgs e)
		{
			// ＸＭＬデータの読込処理
			this.LoadStateXmlData();

			// 選択拠点を取得
			if (GetSelectSectionCodeEvent != null) selectSectionCode = GetSelectSectionCodeEvent(this);

			// 親にツールバー状態通知
			if (ParentToolbarSettingEvent != null) ParentToolbarSettingEvent(this);

            // ↓ 20070131 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this.sfukk01415UA);
            // ↑ 20070131 18322 a

			// 入金伝票入力画面(受注指定型)アクセスクラス 初期化処理
			inputDepositSalesTypeAcs.Initialize();

			// 画面初期設定処理
			this.ScreenInitialSetting();

			// 請求売上情報 DataSet Table 作成処理
			inputDepositSalesTypeAcs.CreateDmdSalesDataTable();

			// 受注引当グリッドデータビューバインド処理
			this.BindingDsDmdSalesView();

			// 受注引当グリッド表示設定処理
			this.SettingDmdSalesGrid();

			// 画面状態保持クラス画面展開処理
			this.GetDisplayStatus(ref this._displayStatus);

			// 受注引当グリッド表示列変更処理
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //this.ColumnViewSettingDmdSalesList(this.ckdDetailDmdSalesList.Checked, this.ckdSeparateCost.Checked);
            this.ColumnViewSettingDmdSalesList(this.ckdDetailDmdSalesList.Checked);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // ADD 2009/04/14 不具合対応[12908]：スペースキーでの項目選択機能を実装 ---------->>>>>
            AlwcDmdSalesCallRadioKeyPressHelper.ControlList.Add(this.opsAlwcDmdSalesCall);
            AlwcDmdSalesCallRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/04/14 不具合対応[12908]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }

		/// <summary>
		/// 受注引当グリッドフォントサイズ値変更イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : 受注引当グリッドフォントサイズを変更した時に発動します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
            if (cmbFontSize.Value == null)
            {
                return;
            }

			// フォントサイズセット
			grdDmdSalesList.DisplayLayout.Appearance.FontData.SizeInPoints = (Int32)cmbFontSize.SelectedItem.DataValue;

			if ((cmbFontSize.Tag is bool) && ((bool)cmbFontSize.Tag == true))
			{
				// 受注引当グリッド列サイズ変更スレッドスタート
				Thread salesGridColumnSizeChangeThread = new Thread(new ParameterizedThreadStart(SalesGridColumnSizeChange));

				salesGridColumnSizeChangeThread.Start((object)this.ckdSalesAutoColumnSize.Checked);
			}
		}

		/// <summary>
		/// 受注引当グリッド列オートサイズチェックボックス押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 列のサイズを自動調整するチェックエディタコントロールのChecked
		///					　プロパティが変更されるときに発生します。
		///					　グリッド列のAutoResizeメソッドを実行します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void ckdSalesAutoColumnSize_CheckedChanged(object sender, EventArgs e)
		{
			if ((cmbFontSize.Tag is bool) && ((bool)cmbFontSize.Tag == true))
			{
				// 受注引当グリッド列サイズ変更スレッドスタート
				Thread salesGridColumnSizeChangeThread = new Thread(new ParameterizedThreadStart(SalesGridColumnSizeChange));

				salesGridColumnSizeChangeThread.Start((object)this.ckdSalesAutoColumnSize.Checked);
			}
		}

		/// <summary>
		/// 受注引当グリッド詳細表示チェックボックス押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 詳細表示チェックボックスをクリックした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void ckdDetailDmdSalesList_CheckedChanged(object sender, System.EventArgs e)
		{
			// 受注引当グリッド表示列変更処理
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //this.ColumnViewSettingDmdSalesList(this.ckdDetailDmdSalesList.Checked, this.ckdSeparateCost.Checked);
            this.ColumnViewSettingDmdSalesList(this.ckdDetailDmdSalesList.Checked);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        #region DEL 2008/06/26 使用していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 受注引当グリッド諸費用別入金チェックボックス押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 詳細表示チェックボックスをクリックした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void ckdSeparateCost_CheckedChanged(object sender, EventArgs e)
		{
			// 受注引当グリッド表示列変更処理
			this.ColumnViewSettingDmdSalesList(this.ckdDetailDmdSalesList.Checked, this.ckdSeparateCost.Checked);
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 使用していないのでコメントアウト

        /// <summary>
		/// 検索ボタン押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 検索ボタンをクリックした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS保守依頼５次改良対応</br>
        /// <br>              引当残＝0の明細は、チェックボックスをグレーアウトし、チェック不可とする</br>
		/// </remarks>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			// 入金内容の変更状況チェック処理
			if ((this.updateComplete == false) && (this.CheckUpdateData() != 0))
			{
				return;
			}

			// 検索前データチェック処理
			Control control;
			if (this.CheackDataBeforeSearch(out control) == false)
			{
				if (control != null)
				{
					control.Focus();
				}
				return;
			}
			
			try
			{
				this.Cursor = Cursors.WaitCursor;

				// データ検索前の画面設定処理
				this.SearchBeforeDisplySetting();

				// 請求売上情報取得用パラメータ 作成処理
				InputDepositSalesTypeAcs.SearchSalesParameter searchSalesParameter = this.SetSalesParameter();

				// 請求売上情報取得処理
				string message;
				int st = inputDepositSalesTypeAcs.SearchDmdSales(searchSalesParameter, this._consTaxLayMethod, out message);

				// データ検索後の画面設定処理
				this.SearchAfterDisplySetting(st, searchSalesParameter);

                this._prevCustomerCode = this.tNedit_CustomerCode.GetInt();

                this._searchFlg = true;

				// 合計欄計算処理
				this.SetSalesTotal();

                for (int index = 0; index < this.grdDmdSalesList.Rows.Count; index++)
                {
                    CellsCollection cells = this.grdDmdSalesList.Rows[index].Cells;

                    // --- ADD 2010/12/20 ---------->>>>>
                    // 引当残＝0の明細場合,チェックボックスはチェック不可とする
                    if ((Int64)cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value == 0
                        && (!string.IsNullOrEmpty((string)cells[InputDepositSalesTypeAcs.ctDepSaleSlipNum].Value)))
                    {
                        cells[InputDepositSalesTypeAcs.ctAlwCheck].Activation = Activation.Disabled;
                    }
                    // --- ADD 2010/12/20  ----------<<<<<

                    // 赤伝の場合
                    if ((cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value != DBNull.Value) &&
                        (Convert.ToInt32(cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value) == 1))
                    {
                        this.grdDmdSalesList.Rows[index].Appearance.ForeColor = Color.Red;
                        this.grdDmdSalesList.Rows[index].Appearance.ForeColorDisabled = Color.Red;
                        continue;
                    }

                    // 返品の場合
                    if ((cells[InputDepositSalesTypeAcs.ctSalesKind].Value != DBNull.Value) &&
                        (Convert.ToString(cells[InputDepositSalesTypeAcs.ctSalesKind].Value) == "返品"))
                    {
                        this.grdDmdSalesList.Rows[index].Appearance.ForeColor = Color.Red;
                        this.grdDmdSalesList.Rows[index].Appearance.ForeColorDisabled = Color.Red;
                        continue;
                    }
                }

				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					// 請求売上が存在しなかった時
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, message, 0, MessageBoxButtons.OK);
                    // ↓ 20070130 18322 c MA.NS用に変更
					//cbxCorporateDiv1.Focus();

                    tNedit_CustomerCode.Focus(); 
                    // ↑ 20070130 18322 c

					// 受注引当一覧の行を非アクティブとする
					grdDmdSalesList.ActiveRow = null;
				}
				else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    // ↓ 20070130 18322 c MA.NS用に変更
					//// エラー発生
					//TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "受注伝票の読込処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    
					// エラー発生
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "売上伝票の読込処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    // ↑ 20071030 18322 c
				}
				else
				{
                    for (int index = 0; index < this.grdDmdSalesList.Rows.Count; index++)
                    {
                        this.grdDmdSalesList.Rows[index].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activation = Activation.Disabled;
                    }

                    // 受注引当一覧の１行目をアクティブとする
                    grdDmdSalesList.Rows[0].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Activate();
                    grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);

					edtDepositDate.Focus();
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
        }

        #region DEL 2008/06/26 仕様していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// AA会場ガイドボタン クリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : AA会場ガイドを起動します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void btnCustomerAAGuid_Click(object sender, EventArgs e)
		{
			//Customer customer;

			try
			{
				this.Cursor = Cursors.WaitCursor;

                // ↓ 20070519 18322 d AA会場は使用しないので削除(SFTOK09242A or SFTOK01180U)
				//// AA会場検索
				//if (customerAcs == null) customerAcs = new CustomerInfoSetAcs();
				//if (customerAcs.ExecuteGuid(enterpriseCode, out customer) == 0)
				//{
				//	edtCustomerCode.SetInt(customer.CustomerCode);
				//	edtCustomerName.Text = customer.Name + " " + customer.Name2;
				//}
                // ↑ 20070519 18322 d
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 仕様していないのでコメントアウト

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 得意先ガイドボタン クリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 得意先ガイドを起動します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void btnCustomerGuid_Click(object sender, System.EventArgs e)
		{
            // ↓ 20070219 18322 c MA.NS用に変更
            #region  SF 得意先・車両検索(全てコメントアウト)
            //CustomerCarSearchAcsRet customerCarSearchAcsRet = new CustomerCarSearchAcsRet();
		    //
			//try
			//{
			//	this.Cursor = Cursors.WaitCursor;
            //
			//	// 得意先ガイド
			//	if (customerSearchGuide == null) customerSearchGuide = new CustomerSearchGuide();
			//	if (customerSearchGuide.CustomerSearchGuideShow(enterpriseCode, ref customerCarSearchAcsRet) == DialogResult.OK)
			//	{
			//		edtCustomerCode.SetInt(customerCarSearchAcsRet.CustomerCode);
			//		edtCustomerName.Text = customerCarSearchAcsRet.Name + " " + customerCarSearchAcsRet.Name2;
			//	}
			//}
			//finally
			//{
			//	this.Cursor = Cursors.Default;
            //}
            #endregion
                                                                            
            // SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_ACCEPT_WHOLE_SALE, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);  // 2007.10.09 hikita del
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);         // 2007.10.09 hikita add
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // ↑ 20070219 18322 c
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
            // ↓ 20070523 18322 c
			//CustSuppli custSuppli;
            //
			//int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);

			int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            // ↑ 20070523 18322 c
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (customerInfo == null)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
						status,
						MessageBoxButtons.OK);

					return;
				}
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
			
			// 得意先コード・得意先名称設定
			edtCustomerCode.SetInt(customerSearchRet.CustomerCode);
            edtCustomerName.Text = customerSearchRet.Name + " " + customerSearchRet.Name2;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start -------------------------------------------->>
        ///// <summary>
        ///// 販売従業員ガイドボタン クリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : 販売従業員ガイドを起動します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void btnSalesEmployeeGuid_Click(object sender, System.EventArgs e)
		//{
		//	Employee employee;

		//	try
		//	{
		//		this.Cursor = Cursors.WaitCursor;

				// 従業員ガイド起動
		//		if (employeeAcs == null) employeeAcs = new EmployeeAcs();

                // ↓ 20070317 18322 c MA.NS用に変更
                //// 営業の従業員ガイド表示
				//if (employeeAcs.ExecuteGuid((enterpriseCode, true, 2, out employee) == 0)
				//{

                // 営業の従業員ガイド表示
		//		if (employeeAcs.ExecuteGuid(enterpriseCode, true, out employee) == 0)
		//		{
                // ↑ 20070317 18322 c
		//			edtSalesEmployee.Text = employee.EmployeeCode;
		//			edtSalesEmployeeName.Text = employee.Name;
		//		}
		//	}
		//	finally
		//	{
		//		this.Cursor = Cursors.Default;
		//	}
		//}
        ///// <summary>
        ///// クレジット会社ガイド(入金伝票入力欄)ボタン クリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : クレジット会社ガイドを起動します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void btnCreditCompanyGuid2_Click(object sender, System.EventArgs e)
		//{
		//	CreditCmp creditCmp;

		//	try
		//	{
		//		this.Cursor = Cursors.WaitCursor;

				// クレジット会社ガイド起動
		//		if (creditCmpAcs == null) creditCmpAcs = new CreditCmpAcs();
		//		if (creditCmpAcs.ExecuteGuid(enterpriseCode, selectSectionCode, out creditCmp) == 0)
		//		{
		//			edtCreditCompanyCode2.Text = creditCmp.CreditCompanyCode;
		//			edtCreditCompanyName2.Text = creditCmp.CreditCompanyName;
		//		}
		//	}
		//	finally
		//	{
		//		this.Cursor = Cursors.Default;
		//	}
		//}
        // 2007.10.09 hikita del end -----------------------------------------------<<
        #endregion 2007.10.09 hikita del

        // 2007.10.09 hikita add start --------------------------------------------->>
        /// <summary>
        /// 銀行ガイドボタン クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 銀行ガイドを起動します。 </br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.10.09</br>
        /// </remarks>
        private void btnBankGuid_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ユーザーガイド起動

                if (_userGuideAcs.ExecuteGuid(enterpriseCode, out userGdHd, out userGdBd, 46) == 0)
                {
                    //if (userGdBd.GuideCode != this._prevBankCode)
                    //{
                    //    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //    //this.tNedit_BankCode.Text = userGdBd.GuideCode.ToString();
                    //    //this.teditBankName.Text = userGdBd.GuideName;
                    //    //this._prevBankCode = userGdBd.GuideCode;
                    //    //this.tNedit_BankCode.SetInt(userGdBd.GuideCode);
                    //    //this.teditBankName.DataText = userGdBd.GuideName.Trim();
                    //    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                    //}

                    //// フォーカス設定
                    //if (this.dateDraftDrawingDate.Enabled == true)
                    //{
                    //    this.dateDraftDrawingDate.Focus();
                    //}
                    //else
                    //{
                    //    this.btnSearch.Focus();
                    //}
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // 2007.10.09 hikita add end -----------------------------------------------<<

		/// <summary>
		/// 得意先コード Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 得意先コードにカーソルが入った時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void edtCustomerCode_Enter(object sender, EventArgs e)
		{
			// Enter時の内容を保持
			tNedit_CustomerCode.Tag =  tNedit_CustomerCode.GetInt();
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 得意先コード Leaveイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 得意先コードからカーソルが抜けた時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void tNedit_CustomerCode_Leave(object sender, System.EventArgs e)
		{
			// Enter時と内容が違う時
			if (!tNedit_CustomerCode.Tag.Equals(tNedit_CustomerCode.GetInt()))
			{
				edtCustomerName.DataText =  "";

				// 未入力ではない時
                if (tNedit_CustomerCode.GetInt() != 0)
                {
                    // 2007.10.09 add start -------------------------------------->>
                    // 管理拠点コード取得(得意先マスタ)
                    CustomerInfo customerInfo;
                    string sectionNm = string.Empty;

                    int status = this._customerInfoAcs.ReadDBData(this.enterpriseCode, this.tNedit_CustomerCode.GetInt(), true, out customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 請求計上拠点の取得
                        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                        //SecInfoSet secInfoSet;
                        //_secInfoAcs.GetSecInfo(customerInfo.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out secInfoSet);
                        //if (secInfoSet != null)
                        //{
                        //    this.selectSectionCode = secInfoSet.SectionCode;
                        //    sectionNm = secInfoSet.SectionGuideNm;
                        //}
                        foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
                        {
                            if (secInfoSet.SectionCode.Trim() == customerInfo.MngSectionCode.Trim())
                            {
                                this.selectSectionCode = secInfoSet.SectionCode;
                                sectionNm = secInfoSet.SectionGuideNm.Trim();
                            }
                        }
                        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                    }

                    // 拠点名称をフレームに渡す
                    if (HandOverAddUpSecNameEvent != null) HandOverAddUpSecNameEvent(this, sectionNm);
                    // 2007.10.09 add end -----------------------------------------<<

                    // 得意先取得スレッド開始処理
                    CustomerNamePrcThreadStart();
                }
                // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
                else
                {
                    this.edtCustomerName.Clear();
                }
                // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start ------------------------------------------------->>
        ///// <summary>
        ///// クレジット会社コード(受注検索欄) Enterイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : クレジット会社コード(受注検索欄)にカーソルが入った時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void edtCreditCompanyCode_Enter(object sender, System.EventArgs e)
		//{
			// Enter時の内容を保持
		//	edtCreditCompanyCode.Tag =  edtCreditCompanyCode.DataText;
		//}
        ///// <summary>
        ///// クレジット会社コード(受注検索欄) Leaveイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : クレジット会社コード(受注検索欄)からカーソルが抜けた時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
   		//private void edtCreditCompanyCode_Leave(object sender, System.EventArgs e)
		//{
			// Enter時と内容が違う時
		//	if (!edtCreditCompanyCode.Tag.Equals(edtCreditCompanyCode.DataText))
		//	{
		//		edtCreditCompanyName.DataText = "";
				// 未入力ではない時
		//		if (!edtCreditCompanyCode.DataText.Equals(""))
		//		{
					// クレジット会社名称(受注検索欄)取得スレッド開始処理
		//			CreditCompanyNamePrcThreadStart();
		//		}
		//	}
		//}
        ///// <summary>
        ///// 販売従業員コード Enterイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : 販売従業員コードにカーソルが入った時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void edtSalesEmployee_Enter(object sender, System.EventArgs e)
		//{
			// Enter時の内容を保持
		//	edtSalesEmployee.Tag =  edtSalesEmployee.DataText;
		//}
        ///// <summary>
        ///// 販売従業員コード Leaveイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : 販売従業員コードからカーソルが抜けた時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void edtSalesEmployee_Leave(object sender, System.EventArgs e)
		//{
			// Enter時と内容が違う時
		//	if (!edtSalesEmployee.Tag.Equals(edtSalesEmployee.DataText))
		//	{
		//		edtSalesEmployeeName.DataText = "";
				// 未入力ではない時
		//		if (!edtSalesEmployee.DataText.Equals(""))
		//		{
					// 販売従業員取得スレッド開始処理
		//			SalesEmployeeNamePrcThreadStart();
		//		}
		//	}
		//}
        ///// <summary>
        ///// クレジット会社コード(入金伝票入力欄) Enterイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : クレジット会社コード(入金伝票入力欄)にカーソルが入った時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        //private void edtCreditCompanyCode2_Enter(object sender, System.EventArgs e)
		//{
			// Enter時の内容を保持
		//	edtCreditCompanyCode2.Tag =  edtCreditCompanyCode2.DataText;
		//}
        ///// <summary>
        ///// クレジット会社コード(入金伝票入力欄) Leaveイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : クレジット会社コード(入金伝票入力欄)からカーソルが抜けた時に発生します。 </br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
		//private void edtCreditCompanyCode2_Leave(object sender, System.EventArgs e)
		//{
			// Enter時と内容が違う時
		//	if (!edtCreditCompanyCode2.Tag.Equals(edtCreditCompanyCode2.DataText))
		//	{
		//		edtCreditCompanyName2.DataText = "";
				// 未入力ではない時
		//		if (!edtCreditCompanyCode2.DataText.Equals(""))
		//		{
					// クレジット会社名称(入金伝票入力欄)取得スレッド開始処理
		//			CreditCompanyName2PrcThreadStart();
		//		}
		//	}
		//}
        // 2007.10.09 hikita del end ----------------------------------------------<<
        #endregion 2007.10.09 hikita del

        // 2007.10.09 hikita add start -------------------------------------------->>
        /// <summary>
        /// 銀行コード Enterイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 銀行コードにカーソルが入った時に発生します。 </br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.10.09</br>
        /// </remarks>
        private void editBankCode_Enter(object sender, EventArgs e)
        {
            //// Enter時の内容を保持
            //tNedit_BankCode.Tag = tNedit_BankCode.DataText;
        }

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 銀行コード Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 銀行コード(入金伝票入力欄)からカーソルが抜けた時に発生します。 </br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.10.09</br>
        /// </remarks>
        private void editBankCode_Leave(object sender, EventArgs e)
        {
            // Enter時と内容が違う時
            if (!tNedit_BankCode.Tag.Equals(tNedit_BankCode.DataText))
            {
                tNedit_BankCode.DataText = "";
                // 未入力ではない時
                if (!tNedit_BankCode.DataText.Equals(""))
                {
                    // 銀行名称取得スレッド開始処理
                    BankNamePrcThreadStart();
                }
                // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
                else
                {
                    this.teditBankName.Clear();
                }
                // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            }
        }
        // 2007.10.09 hikita add end -----------------------------------------------<<
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 金種区分変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 内容が変更された時に発生します。</br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		private void cmbMoneyKind_ValueChanged(object sender, EventArgs e)
		{
			if (cmbMoneyKind.Value is int)
			{
				// 入金金種区分
				int kindDivCode = (int)depositRelDataAcs.HtMoneyKindDiv[(int)cmbMoneyKind.Value];
                switch (kindDivCode)
                {
                    // 小切手
                    case (int)MnyKindDiv.Check:                     
                        {
                            //this.tNedit_BankCode.Clear();
                            //this.teditBankName.Clear();
                            //this.dateDraftDrawingDate.Clear();
                            //this.tEdit_DraftNo.Clear();
                            //this.cmbDraftKind.Clear();
                            //this.cmbDraftDivide.Clear();   

                            this.dateDraftPayTimeLimit.Enabled = true;

                            //this.tNedit_BankCode.Enabled = false;
                            //this.btnBankGuid.Enabled = false;
                            //this.dateDraftDrawingDate.Enabled = false;
                            //this.tEdit_DraftNo.Enabled = false;
                            //this.cmbDraftKind.Enabled = false;
                            //this.cmbDraftDivide.Enabled = false;

                            break;
                        }
                    // 手形
                    case (int)MnyKindDiv.Bill:           
                        {
                            //this.tNedit_BankCode.Enabled = true;
                            //this.btnBankGuid.Enabled = true;
                            //this.dateDraftDrawingDate.Enabled = true;
                            //this.tEdit_DraftNo.Enabled = true;
                            //this.cmbDraftKind.Enabled = true;
                            //this.cmbDraftDivide.Enabled = true;
                            this.dateDraftPayTimeLimit.Enabled = true;
                            break;
                        }
                    default:
                        {
                            //this.tNedit_BankCode.Clear();
                            //this.teditBankName.Clear();
                            //this.dateDraftDrawingDate.Clear();
                            //this.tEdit_DraftNo.Clear();                    
                            //this.cmbDraftKind.Clear();                      
                            //this.cmbDraftDivide.Clear();                   
                            this.dateDraftPayTimeLimit.Clear();   
         
                            //this.tNedit_BankCode.Enabled = false;
                            //this.btnBankGuid.Enabled = false;
                            //this.dateDraftDrawingDate.Enabled = false;
                            //this.tEdit_DraftNo.Enabled = false;
                            //this.cmbDraftKind.Enabled = false;
                            //this.cmbDraftDivide.Enabled = false;
                            this.dateDraftPayTimeLimit.Enabled = false;
                            break;
                        }
                }

			}
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 金種区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 内容が変更された時に発生します。</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void cmbMoneyKind_ValueChanged(object sender, EventArgs e)
        {
            if (cmbMoneyKind.Value is int)
            {
                // 入金金種区分
                int kindDivCode = (int)depositRelDataAcs.HtMoneyKindDiv[(int)cmbMoneyKind.Value];

                // クレジット/ローンの時
                // 2007.10.09 hikita del start ----------------------------------->>
                //if ((kindDivCode == 103) || (kindDivCode == 104))
                //{
                //	cmbCreditOrLoanCd.Enabled = true;
                //}
                //else
                //{
                //	cmbCreditOrLoanCd.Value = 0;
                //	cmbCreditOrLoanCd.Enabled = false;
                //}
                // 2007.10.09 hikita del end -------------------------------------<<

                // 2007.10.09 hikita add start ----------------------------------->>
                // 入力制御
                switch (kindDivCode)
                {
                    case (int)MnyKindDiv.Check:          // 小切手           
                        {
                            this.tNedit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;
                            this.dateDraftDrawingDate.ReadOnly = false;
                            this.dateDraftDrawingDate.Enabled = true;
                            break;
                        }
                    case (int)MnyKindDiv.Remittance:     // 振込
                        {
                            this.tNedit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;
                            break;
                        }
                    case (int)MnyKindDiv.Bill:           // 手形
                    case (int)MnyKindDiv.ACheck:         // 先付小切手
                        {
                            this.tNedit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;
                            this.dateDraftDrawingDate.ReadOnly = false;
                            this.dateDraftDrawingDate.Enabled = true;
                            this.tEdit_DraftNo.Enabled = true;                 // 手形番号
                            this.cmbDraftKind.ReadOnly = false;             // 手形種類
                            this.cmbDraftKind.Enabled = true;
                            this.cmbDraftDivide.ReadOnly = false;           // 手形区分
                            this.cmbDraftDivide.Enabled = true;
                            this.dateDraftPayTimeLimit.ReadOnly = false;    // 支払期日
                            this.dateDraftPayTimeLimit.Enabled = true;
                            break;
                        }
                    default:
                        {
                            this.tNedit_BankCode.Clear();
                            this.dateDraftDrawingDate.Clear();
                            this.tEdit_DraftNo.Clear();                        // 手形番号
                            this.cmbDraftKind.Clear();                      // 手形種類
                            this.cmbDraftDivide.Clear();                    // 手形区分
                            this.dateDraftPayTimeLimit.Clear();             // 支払期日
                            this.tNedit_BankCode.Enabled = false;
                            this.btnBankGuid.Enabled = false;
                            this.dateDraftDrawingDate.ReadOnly = true;
                            this.dateDraftPayTimeLimit.ReadOnly = true;
                            this.dateDraftDrawingDate.Enabled = false;
                            this.dateDraftPayTimeLimit.Enabled = false;
                            this.tEdit_DraftNo.Enabled = false;
                            this.dateDraftPayTimeLimit.Enabled = false;
                            this.cmbDraftKind.Enabled = false;
                            this.cmbDraftDivide.Enabled = false;
                            break;
                        }
                }
                // 2007.10.09 hikita add end -------------------------------------<<
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start ------------------------------------------------->>
        ///// <summary>
        ///// クレジット/ローン区分変更イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントデータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : 内容が変更された時に発生します。</br>
        ///// <br>Programmer  : 97036 amami</br>
        ///// <br>Date        : 2005.07.21</br>
        ///// </remarks>
        // private void cmbCreditOrLoanCd_ValueChanged(object sender, System.EventArgs e)
		// {
		//	if ((Int16)cmbCreditOrLoanCd.Value == 0)
		//	{
		//		edtCreditCompanyCode2.ReadOnly = true;
		//		btnCreditCompanyGuid2.Enabled = false;
		//		edtCreditCompanyCode2.Text = "";
		//		edtCreditCompanyName2.Text = "";
		//	}
		//	else
		//	{
		//		edtCreditCompanyCode2.ReadOnly = false;
		//		btnCreditCompanyGuid2.Enabled = true;
		//	}
		//}
        // 2007.10.09 hikita del end ---------------------------------------------------<<
        #endregion 2007.10.09 hikita del

        #region DEL 2008/06/26 使用していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 預り金区分変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 内容が変更された時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void opsDepositDiv_ValueChanged(object sender, System.EventArgs e)
		{
			// セルのアクティブ状態を再セットして、イベントを発生させる
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = grdDmdSalesList.ActiveCell;
			if (cell != null)
			{
				grdDmdSalesList.ActiveCell = null;
				grdDmdSalesList.ActiveCell = cell.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck];
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 使用していないのでコメントアウト

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 受注引当グリッドセルアクティブ イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 引当て可/不可の状態変更を行います。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_AfterCellActivate(object sender, EventArgs e)
		{
			UltraGridCell cl = grdDmdSalesList.ActiveCell;
			
			UltraGridBand bd = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

			try
			{
                // ↓ 20070125 18322 c MA.NS用に変更
				//// 引当チェックボックス列の時 or 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
				//if ((cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctAlwCheck]) || 
				//	(cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw]) ||
				//	(cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw]) ||
				//	(cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw]))

				// 引当チェックボックス列の時 or 引当額 共通 (入金引当額) 列の時
				if ((cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctAlwCheck]) || 
					(cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw]))
                // ↑ 20070125 18322 c
				{

					// 更新完了フラグ
					if (this.updateComplete == true)
					{
						// 編集不可
                        //cl.Column.CellActivation = Activation.Disabled;
						return;
					}

                    // ↓ 20070525 18322 a
					// 修正付加請求売上データ判断処理 POS入力の売掛以外の時
					if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000f0000) == 0x000f0000)
                    {
						// 編集不可
						selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
						this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        //cl.Column.CellActivation = Activation.Disabled;

						labDmdSalesList.Text = "POS売上入力で作成された売上伝票の為、売掛以外の入金は行えません。";
						return;
                    }
                    // ↑ 20070525 18322 a

					// 修正付加請求売上データ判断処理 締済の時
					if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x0000000f) == 0x0000000f)
					{
						// 編集不可
						selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
						this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        //cl.Column.CellActivation = Activation.Disabled;
                        // ↓ 20071030 18322 c MA.NS用に変更
						//labDmdSalesList.Text = "受注伝票が締まっている為、預り金の入金は行えません。";

						labDmdSalesList.Text = "売上伝票が締まっている為、預り金の入金は行えません。";
                        // ↑ 20071030 18322 c
						return;
					}
					
					// 修正付加請求売上データ判断処理 請求売上(赤)の時
					if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000000f0) == 0x000000f0)
					{
						// 編集不可
						selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
						this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        //cl.Column.CellActivation = Activation.Disabled;
                        // ↓ 20070130 18322 c MA.NS用に変更
                        //labDmdSalesList.Text = "受注伝票が赤伝の為、入金は行えません。";

                        labDmdSalesList.Text = "売上伝票が赤伝の為、入金は行えません。";
                        // ↑ 20070130 18322 c
						return;
					}
					
					// 修正付加請求売上データ判断処理 請求売上(相殺済み黒)の時
					if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x00000f00) == 0x00000f00)
					{
						// 編集不可
						selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
						this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        //cl.Column.CellActivation = Activation.Disabled;
                        // ↓ 20070130 18322 c MA.NS用に変更
						//labDmdSalesList.Text = "選択受注伝票では赤伝が発行されている為、入金は行えません。";

						labDmdSalesList.Text = "選択売上伝票では赤伝が発行されている為、入金は行えません。";
                        // ↑ 20070130 18322 c
						return;
					}

					// 修正付加請求売上データ判断処理 前回締日より過去の入金日の時
					if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x0000f000) == 0x0000f000)
					{
						// 編集不可
						selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
						this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        //cl.Column.CellActivation = Activation.Disabled;
						labDmdSalesList.Text = "入金日が得意先の前回締日より過去になっている為、入金は行えません。";
						return;
					}

					// 引当チェックボックス列の時
					if (cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctAlwCheck])
					{
						// 編集可能
                        //cl.Column.CellActivation = Activation.AllowEdit;
					}
					// 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
					else
					{
						// 引当チェックボックスがTrueの時
						if (cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck].Text == "True")
						{
							// 編集可能
                            //cl.Column.CellActivation = Activation.AllowEdit;
						}
						else
						{
							// 編集不可
                            //cl.Column.CellActivation = Activation.Disabled;
						}
					}
				}
			}
			finally
			{
				// 入力可能セルの時は編集モードにする
				grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受注引当グリッドセルアクティブ イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDmdSalesList_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGridCell cl = grdDmdSalesList.ActiveCell;
            UltraGridBand bd = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            try
            {
                // 引当チェックボックス列の時 or 引当額 共通 (入金引当額) 列の時
                if ((cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctAlwCheck]) ||
                    (cl.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw]))
                {
                    // 更新完了フラグ
                    if (this.updateComplete == true)
                    {
                        return;
                    }

                    // 修正付加請求売上データ判断処理 POS入力の売掛以外の時
                    if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000f0000) == 0x000f0000)
                    {
                        // 編集不可
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
                        this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        labDmdSalesList.Text = "POS売上入力で作成された売上伝票の為、売掛以外の入金は行えません。";
                        return;
                    }

                    // --- DEL 2009/03/19 障害ID:12623対応------------------------------------------------------>>>>>
                    //// 修正付加請求売上データ判断処理 締済の時
                    //if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x0000000f) == 0x0000000f)
                    //{
                    //    // 編集不可
                    //    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
                    //    this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                    //    labDmdSalesList.Text = "売上伝票が締まっている為、入金は行えません。";
                    //    return;
                    //}
                    // --- DEL 2009/03/19 障害ID:12623対応------------------------------------------------------<<<<<

                    //// 修正付加請求売上データ判断処理 請求売上(赤)の時
                    //if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000000f0) == 0x000000f0)
                    //{
                    //    // 編集不可
                    //    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
                    //    this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                    //    labDmdSalesList.Text = "売上伝票が赤伝の為、入金は行えません。";
                    //    return;
                    //}

                    //// 修正付加請求売上データ判断処理 請求売上(相殺済み黒)の時
                    //if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x00000f00) == 0x00000f00)
                    //{
                    //    // 編集不可
                    //    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
                    //    this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                    //    labDmdSalesList.Text = "選択売上伝票では赤伝が発行されている為、入金は行えません。";
                    //    return;
                    //}

                    // 修正付加請求売上データ判断処理 前回締日より過去の入金日の時
                    if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x0000f000) == 0x0000f000)
                    {
                        // 編集不可
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctAlwCheck] = "false";
                        this.ChangeAlwcCheck(cl.Row.Cells[InputDepositSalesTypeAcs.ctAlwCheck]);
                        labDmdSalesList.Text = "入金日が得意先の前回締日より過去になっている為、入金は行えません。";
                        return;
                    }
                }
            }
            finally
            {
                // 入力可能セルの時は編集モードにする
                grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 受注引当グリッド行アクティブ イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : アクティブ行が変更された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_AfterRowActivate(object sender, EventArgs e)
		{
			// 受注引当グリッド選択行取得処理
			selectedDmdSalesRow = grdDmdSalesList.ActiveRow.Cells[InputDepositSalesTypeAcs.ctDmdSalesDataRow].Value as DataRow;
		}

		/// <summary>
		/// 受注引当グリッド行フィルター適用後 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 行フィルターが適用された直後に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
		{
			// 合計欄計算処理
			this.SetSalesTotal();
		}

		/// <summary>
		/// 受注引当グリッドセル非アクティブ イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_BeforeCellDeactivate(object sender, CancelEventArgs e)
		{
			labDmdSalesList.Text = "";
		}

		/// <summary>
		/// 受注引当グリッドエディットモード開始前 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 編集モードになる前に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// IMEモードOFF
			grdDmdSalesList.ImeMode = ImeMode.Disable;

			UltraGridBand bd = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            // ↓ 20070125 18322 c MA.NS用に変更
			//// 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
			//if ((grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw]) ||
			//	(grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw]) ||
			//	(grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw]))
			//{

			// 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
			if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw])
			{
            // ↑ 20070125 18322 c
				// 現在(変更前)の 引当額 共通 (入金引当額) を取得する
                //grdDmdSalesList.ActiveCell.Tag = Convert.ToInt64(grdDmdSalesList.ActiveCell.Value);
			}
        }

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 受注引当グリッドエディットモード終了前 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 編集モードが終わる前に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand bd = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            // ↓ 20070125 18322 c MA.NS用に変更
			//// 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
			//if ((grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw]) ||
			//	(grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw]) ||
			//	(grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw]))
			//{

			// 引当額 受注 (入金引当額) or 引当額 諸費用 (入金引当額) or 引当額 共通 (入金引当額) 列の時
			if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw])
			{
            // ↑ 20070125 18322 c
				// 変更前の引当額を取得する
				Int64 depositAllowance_Alw = this.StrToIntDef(grdDmdSalesList.ActiveCell.Tag, 0);

				// 変更後の引当額を取得する
				Int64 depositAllowance_Alw_Aft = this.StrToIntDef(grdDmdSalesList.ActiveCell.Text, 0);
				
				// 不正な数値が入力された場合はセルに再セットする
				if (depositAllowance_Alw_Aft == 0)
					grdDmdSalesList.ActiveCell.Value = 0;

				// 変更差額を取得する
				Int64 difference = depositAllowance_Alw_Aft - depositAllowance_Alw;

				// 金額が変更された時には再計算を行う
				if (difference != 0)
				{
                    // ↓ 20070125 18322 c MA.NS用に変更
                    #region SF 引当額 受注・諸費用（入金引当額）はMA.NSでは使用しない為、削除
                    //// 引当額 受注 (入金引当額) 列の時
					//if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctAcpOdrDepositAlwc_Alw])
					//{
					//	// 入金引当情報 受注 変更処理
					//	inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, false, true, true);
					//
					//	// 入金引当情報 共通 変更処理
					//	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
					//}
					//// 引当額 諸費用 (入金引当額) 列の時
					//else if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctVarCostDepoAlwc_Alw])
					//{
					//	// 入金引当情報 諸費用 変更処理
					//	inputDepositSalesTypeAcs.UpdateCostDepositAlwc(difference, ref selectedDmdSalesRow, false, true, true);
					//
					//	// 入金引当情報 共通 変更処理
					//	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
					//}
					//// 引当額 共通 (入金引当額) 列の時
					//else if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw])
					//{
					//	// 入金引当情報 共通 変更処理
					//	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, false, true, true);
					//
					//	// 諸費用別入金オプション判定
					//	if (depositRelDataAcs.OptSeparateCost == true)
					//	{
					//		if (difference >= 0)		// --- 差額が＋の時は 諸費用先引き --- //
					//		{							// ※諸費用を引き、余り額は受注より全て引く
					//			// 入金引当情報 諸費用 変更処理
					//			difference = inputDepositSalesTypeAcs.ZeroUpdateCostDepositAlwc(difference, ref selectedDmdSalesRow);
					//
					//			// 入金引当情報 受注 変更処理
					//			inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
					//		} 
					//		else						// --- 差額が－の時は 受注先引き --- //
					//		{							// ※受注→諸費用と引き、余り額は受注より全て引く
					//			// 入金引当情報 受注 変更処理
					//			difference = inputDepositSalesTypeAcs.ZeroUpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow);
					//
					//			// 入金引当情報 諸費用 変更処理
					//			difference = inputDepositSalesTypeAcs.ZeroUpdateCostDepositAlwc(difference, ref selectedDmdSalesRow);
					//
					//			// 入金引当情報 受注 変更処理
					//			inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
					//		}
					//	}
					//	else
					//	{
					//		// 入金引当情報 受注 変更処理
					//		inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref selectedDmdSalesRow, true, true, true);
					//	}
                    //}
                    #endregion

                    // 引当額 共通 (入金引当額) 列の時
					if (grdDmdSalesList.ActiveCell.Column == bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw])
					{
						// 入金引当情報 共通 変更処理
						//inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, false, true, true);
                        inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref selectedDmdSalesRow, false, true, false);
					}
                    // ↑ 20070125 18322 c
				}

				grdDmdSalesList.ActiveRow.Refresh();
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受注引当グリッドエディットモード終了前 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 編集モードが終わる前に発生します。 </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private void grdDmdSalesList_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            UltraGridBand bd = grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable];

            // 引当列ではない時
            if (grdDmdSalesList.ActiveCell.Column != bd.Columns[InputDepositSalesTypeAcs.ctDepositAllowance_Alw])
            {
                return;
            }

            // 変更前引当済金額を取得
            Int64 bfDepositAllowanceSales = StrToIntDef(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctBfDepositAllowance_Sales].ToString(), 0);

            // 変更前引当残金額を取得
            Int64 bfDepositAlwBlnce = StrToIntDef(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctBfDepositAlwcBlnce_Sales].ToString(), 0);

            // 売上伝票金額を取得
            Int64 salesTotalTaxExc = StrToIntDef(selectedDmdSalesRow[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].ToString(), 0);

            // 引当額を取得
            Int64 depositAllowance = StrToIntDef(grdDmdSalesList.ActiveCell.Text, 0);

            // ADD BY zhujw 2014/07/09 FOR RedMine#42902の⑬ 「-」のみで他の項目に移動しようとすると以下のエラーが発生する。 ---->>>>>
            Int64 num = 0;
            if (!Int64.TryParse(grdDmdSalesList.ActiveCell.Text, out num)) grdDmdSalesList.ActiveCell.Value=0;
            // ADD BY zhujw 2014/07/09 FOR RedMine#42902の⑬ 「-」のみで他の項目に移動しようとすると以下のエラーが発生する。 ----<<<<<

            Int64 maxValue;
            if (bfDepositAllowanceSales == 0)
            {
                // 未引当の場合
                maxValue = salesTotalTaxExc;
            }
            else
            {
                // 引当済金額がある場合
                maxValue = bfDepositAlwBlnce;
            }

            //-----------------------
            // 売上伝票金額がプラス
            //-----------------------
            if (salesTotalTaxExc >= 0)
            {
                //-----------------------
                // 引当額がプラス
                //-----------------------
                if (depositAllowance >= 0)
                {
                    // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ---->>>>>
                    if (_subflag)
                    {
                        if (maxValue < 0)
                        {
                            // 引当額
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = maxValue;
                            grdDmdSalesList.ActiveCell.Value = maxValue;
                            // 引当残
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                            // 引当済
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = salesTotalTaxExc;
                        }
                        else
                        {
                            // 引当額
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = maxValue;
                            //grdDmdSalesList.ActiveCell.Value = salesTotalTaxExc;// DEL BY zhujw 2014/07/10 FOR RedMine#42902の⑩_2 「一括引当」ボタンの押下について 
                            grdDmdSalesList.ActiveCell.Value = maxValue;// ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩_2 「一括引当」ボタンの押下について 

                            // 引当残
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                            // 引当済
                            selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = maxValue + bfDepositAllowanceSales;
                        }
                    }
                    else
                    // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ----<<<<<
                    //-----------------------
                    // 引当額 > 伝票金額
                    //-----------------------
                    if (depositAllowance > maxValue)
                    {
                        // 引当額
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = maxValue;
                        grdDmdSalesList.ActiveCell.Value = salesTotalTaxExc;

                        // 引当残
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                        // 引当済
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = maxValue + bfDepositAllowanceSales;
                    }
                    else
                    {
                        // 引当残
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = salesTotalTaxExc - depositAllowance - bfDepositAllowanceSales;

                        // 引当済
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = depositAllowance + bfDepositAllowanceSales;
                    }
                }
                //-----------------------
                // 引当額がマイナス
                //-----------------------
                else
                {
                    // 引当残
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = salesTotalTaxExc - depositAllowance - bfDepositAllowanceSales;

                    // 引当済
                    selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = depositAllowance + bfDepositAllowanceSales;
                }
            }
            //-----------------------
            // 売上伝票金額がマイナス
            //-----------------------
            else
            {
                //-----------------------
                // 引当額がプラス
                //-----------------------
                if (depositAllowance >= 0)
                {
                    // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ---->>>>>
                    if (this._subflag)
                    {
                        if (maxValue < 0)
                        {
                            grdDmdSalesList.ActiveCell.Value = maxValue;
                        }
                    }
                    else
                    {
                        // 引当残
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = salesTotalTaxExc - depositAllowance - bfDepositAllowanceSales;

                        // 引当済
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = depositAllowance + bfDepositAllowanceSales;
                    }
                    // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ----<<<<<

                    // DEL ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ---->>>>>
                    //// 引当残
                    //selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = salesTotalTaxExc - depositAllowance - bfDepositAllowanceSales;

                    //// 引当済
                    //selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = depositAllowance + bfDepositAllowanceSales;
                    // DEL ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ----<<<<<
                }
                //-----------------------
                // 引当額がマイナス
                //-----------------------
                else
                {
                    //-----------------------
                    // 引当額 > 伝票金額
                    //-----------------------
                    if (depositAllowance < salesTotalTaxExc)
                    {
                        // 引当額
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = maxValue;
                        //grdDmdSalesList.ActiveCell.Value = salesTotalTaxExc;// DEL BY zhujw 2014/07/10 FOR RedMine#42902の⑩_2 「一括引当」ボタンの押下について 
                        grdDmdSalesList.ActiveCell.Value = maxValue;// ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩_2 「一括引当」ボタンの押下について 

                        // 引当残
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                        // 引当済
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = maxValue + bfDepositAllowanceSales;
                    }
                    else
                    {
                        // 引当残
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = salesTotalTaxExc - depositAllowance - bfDepositAllowanceSales;

                        // 引当済
                        selectedDmdSalesRow[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = depositAllowance + bfDepositAllowanceSales;
                    }
                }
            }
            this._subflag = false; // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 受注引当グリッドエディットモード終了後 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 編集モードが終わった後に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_AfterExitEditMode(object sender, EventArgs e)
		{
			// 合計欄計算処理
			this.SetSalesTotal();
		}

		/// <summary>
		/// 受注引当グリッド行非アクティブ イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : アクティブ行が無くなる直前に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			// 受注伝票変更前画面初期化処理
			this.DisplyClearToDmdSalesChange();
		}

		/// <summary>
		/// 受注引当グリッドセル値変更 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : キーが押された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_CellChange(object sender, CellEventArgs e)
		{
			// 引当チェックボックス列の時
			if (e.Cell.Column == grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Columns[InputDepositSalesTypeAcs.ctAlwCheck])
			{
				// 引当チェック変更処理
				this.ChangeAlwcCheck(e.Cell);
			}
		}

		/// <summary>
		/// 受注引当グリッドボタン押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ボタンが押された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_ClickCellButton(object sender, CellEventArgs e)
		{
			//int acceptAnOrderNo = Convert.ToInt32(e.Cell.Row.Cells[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Value);  // 2007.10.09 hikita del

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //int customerCode = Convert.ToInt32(e.Cell.Row.Cells[InputDepositSalesTypeAcs.ctCustomerCode].Value);
            int customerCode = this.tNedit_CustomerCode.GetInt();
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // ↓ 20070130 18322 c MA.NS用に変更
			//string slipNo = e.Cell.Row.Cells[InputDepositSalesTypeAcs.ctSlipNo].Value.ToString();

			string slipNo = e.Cell.Row.Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Value.ToString();
            // ↑ 20070130 18322 c

            int acptStatus = Convert.ToInt32(e.Cell.Row.Cells[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Value);   // 2007.10.09 add 

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 入金引当表示処理(売上伝票→入金引当)
				//sfukk01415UA.ViewAllowanceOfAcceptOdr(depositRelDataAcs.OptSeparateCost, enterpriseCode, customerCode, acceptAnOrderNo, slipNo);  // 2007.10.09 hikita del
                // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                //sfukk01415UA.ViewAllowanceOfAcceptOdr(depositRelDataAcs.OptSeparateCost, enterpriseCode, customerCode, acptStatus, slipNo);         // 2007.10.09 hikita add
                sfukk01415UA.ViewAllowanceOfAcceptOdr(enterpriseCode, customerCode, acptStatus, slipNo);
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// 受注引当グリッド初期化 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : データソースからコントロールにデータがロードされるときなど、
		///                   表示レイアウトが初期化されるときに発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			// 受注引当グリッド初期設定処理処理
			this.InitializeDmdSalesList();
		}

		/// <summary>
		/// 受注引当グリッド行初期化 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 行が初期化されるときに発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			int dmdSalesDebitNoteCd = 0;

			// 請求売上データバンドの時
			if (e.Row.Band == grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable])
			{
                if (e.Row.Cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value == DBNull.Value)
                {
                    dmdSalesDebitNoteCd = 0;
                }
                else
                {
                    dmdSalesDebitNoteCd = (int)e.Row.Cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value;
                }
			}
				
			switch (dmdSalesDebitNoteCd)
			{
				case 0:
					e.Row.Appearance.ForeColor = Color.Black;
					break;
				case 1:
					e.Row.Appearance.ForeColor = Color.Red;
					break;
				case 2:
					e.Row.Appearance.ForeColor = Color.DarkOrchid;
					break;
			}
		}

		/// <summary>
		/// 受注引当グリッドマウスセル移動 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : マウスがセル移動したときに発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// ツールチップを非表示にする
			ultraToolTipGrid.Enabled = false;
			ultraToolTipGrid.SetUltraToolTip(grdDmdSalesList, null);
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 受注引当グリッドクリック イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : マウスがクリックしたときに発生します。 </br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS保守依頼５次改良対応</br>
        /// <br>              引当残＝0の明細は、チェックボックスをグレーアウトし、チェック不可とする</br>
		/// </remarks>
		private void grdDmdSalesList_Click(object sender, EventArgs e)
		{
			// カーソルが行をクリックしたか取得
			Point pt = grdDmdSalesList.PointToClient(Cursor.Position);
            if (pt == null)
            {
                return;
            }

			UIElement uielement = grdDmdSalesList.DisplayLayout.UIElement.ElementFromPoint(new Point(pt.X, pt.Y));
            if (uielement == null)
            {
                return;
            }

			UltraGridRow oRow = (UltraGridRow)uielement.GetContext(typeof(UltraGridRow));
            if (oRow == null)
            {
                return;
            }

            UltraGridColumn oCol = (UltraGridColumn)uielement.GetContext(typeof(UltraGridColumn));
            if (oCol == null)
            {
                return;
            }

			if ((oRow != null) && (oRow.Index >= 0) && (oCol != null) && (oCol.ToString() != InputDepositSalesTypeAcs.ctAlwCheck))
			{
				const int maxLen = 9;
				string tipstring = "";

				// 赤黒区分
				if (Convert.ToInt32(oRow.Cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value) != 0)
				{
					tipstring += grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctDebitNoteNm].Value.ToString();
					tipstring += "\r\n";
				}
				// 売上伝票番号
				tipstring += grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Value.ToString();
				// 伝票日付
				tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Value.ToString();
				// 種別
				tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesKind].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSalesKind].Value.ToString();
				// 伝票備考
				tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSlipNote].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSlipNote].Value.ToString();
				// 請求合計額(売上額)
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Value).ToString("###,###,##0");
				// 引当残 共通 (請求売上マスタ)
				tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value).ToString("###,###,##0");
				// 締めフラグ
				if (oRow.Cells[InputDepositSalesTypeAcs.ctSalesClosedFlg].Value.ToString() != "")
				{
					tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption.PadRight(maxLen, '　') + "：" + "締済み";
				}
				else
				{
					tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption.PadRight(maxLen, '　') + "：" + "未締";
				}

				UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = ToolTipImage.Info;

				ultraToolTipInfo.ToolTipTitle = "売上情報";

				ultraToolTipInfo.ToolTipText = tipstring;

				ultraToolTipGrid.Appearance.FontData.Name = "ＭＳ ゴシック";
				ultraToolTipGrid.SetUltraToolTip(grdDmdSalesList, ultraToolTipInfo);
				ultraToolTipGrid.Enabled = true;
			}

            if ((oRow != null) && (oRow.Index >= 0) && (oCol != null))
            {
                if (oCol.ToString() == InputDepositSalesTypeAcs.ctAlwCheck)
                {
                    // --- ADD 2010/12/20 ---------->>>>>
                    // 引当残＝0の明細は、チェックボックスをグレーアウトし、チェック不可とする。
                    if (this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index].Activation == Activation.Disabled)
                    {
                        return;
                    }
                    // --- ADD 2010/12/20  ----------<<<<<

                    this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index].Activate();

                    if (this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index].Text == "True")
                    {
                        this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index].Value = "False";

                    }
                    else
                    {
                        this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index].Value = "True";
                    }

                    this.grdDmdSalesList.PerformAction(UltraGridAction.ExitEditMode);

                    grdDmdSalesList_CellChange(this.grdDmdSalesList, new CellEventArgs(this.grdDmdSalesList.Rows[oRow.Index].Cells[oCol.Index]));

                    this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                }
                else if (oCol.ToString() == InputDepositSalesTypeAcs.ctDepositAllowance_Alw)
                {
                    if (this.grdDmdSalesList.Rows[oRow.Index].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Text == "True")
                    {
                        this.grdDmdSalesList.Rows[oRow.Index].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
                        this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.grdDmdSalesList.Rows[oRow.Index].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Activate();
                        this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else if (oCol.ToString() == InputDepositSalesTypeAcs.ctDepositAlwBtn)
                {
                    this.grdDmdSalesList.Rows[oRow.Index].Cells[InputDepositSalesTypeAcs.ctDepositAlwBtn].Activate();
                    this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.grdDmdSalesList.Rows[oRow.Index].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Activate();
                    this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 受注引当グリッドクリック イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : マウスがクリックしたときに発生します。 </br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void grdDmdSalesList_Click(object sender, EventArgs e)
        {
            // カーソルが行をクリックしたか取得
            Point pt = grdDmdSalesList.PointToClient(Cursor.Position);
            UIElement uielement = grdDmdSalesList.DisplayLayout.UIElement.ElementFromPoint(new Point(pt.X, pt.Y));
            UltraGridRow oRow = (UltraGridRow)uielement.GetContext(typeof(UltraGridRow));
            UltraGridColumn oCol = (UltraGridColumn)uielement.GetContext(typeof(UltraGridColumn));

            if ((oRow != null) && (oRow.Index >= 0) && (oCol != null) && (oCol.ToString() != InputDepositSalesTypeAcs.ctAlwCheck))
            {
                const int maxLen = 9;
                string tipstring = "";

                // 赤黒区分
                if (Convert.ToInt32(oRow.Cells[InputDepositSalesTypeAcs.ctDebitNoteDiv].Value) != 0)
                {
                    tipstring += grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctDebitNoteNm].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctDebitNoteNm].Value.ToString();
                    tipstring += "\r\n";
                }
                // ↓ 20071030 18322 c
                //// 伝票番号
                //tipstring += grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSlipNo].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSlipNo].Value.ToString();
                //// 受注番号
                //tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt32(oRow.Cells[InputDepositSalesTypeAcs.ctAcceptAnOrderNo].Value).ToString();

                // 売上伝票番号
                tipstring += grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesSlipNum].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Value.ToString();
                // ↑ 20071030 18322 c

                // 伝票日付
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSearchSlipDateDisp].Value.ToString();

                // 2007.10.09 hikita del start ----------------------------------------------------------------------------------------->>
                // ↓ 20070525 18322 a
                // POSレシート番号
                // tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctPosReceiptNo].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctPosReceiptNo].Value.ToString();
                // レジ処理日
                // tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctRegiProcDate].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctRegiProcDate].Value.ToString();
                // ↑ 20070525 18322 a
                // 2007.10.09 hikita del end -------------------------------------------------------------------------------------------<<

                // 種別
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesKind].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSalesKind].Value.ToString();
                // 売上名称
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSlipNote].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctSlipNote].Value.ToString();

                // ↓ 20070125 18322 c MA.NS用に変更
                //// 登録番号
                //tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctNumberPlate].Header.Caption.PadRight(maxLen, '　') + "：" + oRow.Cells[InputDepositSalesTypeAcs.ctNumberPlate].Value.ToString();
                //// 受注売上額
                //tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctAcceptAnOrderSales].Value).ToString("###,###,##0");
                //// 諸費用額
                //tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctTotalVariousCost].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctTotalVariousCost].Value).ToString("###,###,##0");
                //// 受注合計額
                //tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctTotalSales].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctTotalSales].Value).ToString("###,###,##0");

                // 請求合計額(売上額)
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctSalesTotalTaxExc].Value).ToString("###,###,##0");
                // ↑ 20070125 18322 c
                // 引当残 共通 (請求売上マスタ)
                tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Header.Caption.PadRight(maxLen, '　') + "：" + Convert.ToInt64(oRow.Cells[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales].Value).ToString("###,###,##0");
                // 締めフラグ
                if (oRow.Cells[InputDepositSalesTypeAcs.ctSalesClosedFlg].Value.ToString() != "")
                {
                    tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption.PadRight(maxLen, '　') + "：" + "締済み";
                }
                else
                {
                    tipstring += "\r\n" + grdDmdSalesList.DisplayLayout.Bands[0].Columns[InputDepositSalesTypeAcs.ctSalesClosedFlg].Header.Caption.PadRight(maxLen, '　') + "：" + "未締";
                }

                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                // ↓ 20070125 18322 c MA.NS用に変更
                //ultraToolTipInfo.ToolTipTitle = "受注情報";

                ultraToolTipInfo.ToolTipTitle = "売上情報";
                // ↑ 20070125 18322 c

                ultraToolTipInfo.ToolTipText = tipstring;

                ultraToolTipGrid.Appearance.FontData.Name = "ＭＳ ゴシック";
                ultraToolTipGrid.SetUltraToolTip(grdDmdSalesList, ultraToolTipInfo);
                ultraToolTipGrid.Enabled = true;
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 受注引当グリッドキーダウン イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : キーが押された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void grdDmdSalesList_KeyDown(object sender, KeyEventArgs e)
		{
            UltraGrid ug = (UltraGrid)sender;

			if (ug.ActiveCell == null) return;

			switch (e.KeyCode)
			{
				// 上 Key
				case Keys.Up:
				{
					// 最上位行の時
					if(ug.ActiveCell.Row.Index == 0)
					{
                        //if (this.cmbDraftKind.Enabled)
                        //{
                        //    this.cmbDraftKind.Focus();
                        //}
                        //else if (this.tNedit_BankCode.Enabled)
                        //{
                        //    this.tNedit_BankCode.Focus();
                        //}
                        if (this.cmbMoneyKind.Enabled)
                        {
                            this.cmbMoneyKind.Focus();
                        }
                        else if (this.edtDepositDate.Enabled)
                        {
                            this.edtDepositDate.Focus();
                        }
						e.Handled = true;
					}
					else
					{
						ug.PerformAction(UltraGridAction.AboveCell);
						e.Handled = true;
					}
					break;
				}
				// 下 Key
				case Keys.Down:
				{
					// 最下位行の時
					if (ug.ActiveRow.Index == (ug.Rows.Count - 1))
					{
						btnAllAwl.Focus();
						e.Handled = true;
					}
					else
					{
						ug.PerformAction(UltraGridAction.BelowCell);
						e.Handled = true;
					}
					break;
				}
				// 右 Key
				case Keys.Right:
				{
					// エディット編集モードの時
					if ((ug.ActiveCell.Column.DataType != typeof(Boolean)) && (ug.ActiveCell.IsInEditMode == true))
					{
						// カーソルが文字列の一番右端の時
						if ((ug.ActiveCell.SelLength == 0) &&
							(ug.ActiveCell.SelStart == ug.ActiveCell.Text.Length))
						{
							ug.PerformAction(UltraGridAction.NextCell);
							e.Handled = true;
						}
					}
					else
					{
						ug.PerformAction(UltraGridAction.NextCell);
						e.Handled = true;
					}
					break;
				}
				// 左 Key
				case Keys.Left:
				{
					// 編集モードの時
					if ((ug.ActiveCell.Column.DataType != typeof(Boolean)) && (ug.ActiveCell.IsInEditMode == true))
					{
						// カーソルが文字列の一番左端の時
						if ((ug.ActiveCell.SelLength == 0) &&
							(ug.ActiveCell.SelStart == 0))
						{
                            //if (ug.ActiveCell.Row.Index != 0)
                            //{
                            //    ug.PerformAction(UltraGridAction.PrevCell);
                            //}
                            ug.PerformAction(UltraGridAction.PrevCell);
							e.Handled = true;
						}
					}
					else
					{
						ug.PerformAction(UltraGridAction.PrevCell);
						e.Handled = true;
					}
					break;
				}
            case Keys.Space:
                {
                    if (ug.ActiveCell.Column.Key == InputDepositSalesTypeAcs.ctDepositAlwBtn)
                    {
                        grdDmdSalesList_ClickCellButton(ug, new CellEventArgs(ug.ActiveCell));
                    }
                    break;
                }
			}
		}

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 一括引当ボタン押下 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 一括引当ボタンが押された時に発生します。 </br>
		/// <br>Programmer  : 30414 忍 幸史</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		private void btnAllAwl_Click(object sender, EventArgs e)
		{
			Int64 difference;

			// 受注引当一覧を先頭行からループ
			for (int ix = 0; ix < inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows.Count; ix++)
			{
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ------->>>>>
                this.grdDmdSalesList.Rows[ix].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
                string slipNo = this.grdDmdSalesList.Rows[ix].Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Text.ToString().Trim();
                int currentRow = 0;
                for (int i = 0; i < inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows.Count; i++)
                {
                    if (inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows[i][InputDepositSalesTypeAcs.ctSalesSlipNum].ToString().Trim().Equals(slipNo))
                    {
                        currentRow = i;
                        break;
                    }
                }
                DataRow dr = inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows[currentRow];
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について -------<<<<<

                //DataRow dr = inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows[ix];// DEL ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について

                //// 引当残 共通 (請求売上マスタ) が０円の時は無視
                //if (Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales]) == 0) continue;

                // 修正付加請求売上データ判断処理 請求売上(赤)の時は無視
                if ((this.IsLockDmdSalesData(dr) & 0x000000f0) == 0x000000f0) continue;

                // 修正付加請求売上データ判断処理 請求売上(相殺済み黒)の時は無視
                if ((this.IsLockDmdSalesData(dr) & 0x00000f00) == 0x00000f00) continue;

                // 修正付加請求売上データ判断処理 POS売上の売掛以外の時は無視
                if ((this.IsLockDmdSalesData(dr) & 0x000f0000) == 0x000f0000)
                {
                    continue;
                }
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ------->>>>>
                if (Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales]) == 0)
                {
                    continue;
                }
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について -------<<<<<

                // ↑ 20070525 18322 a
                
                // 修正付加請求売上データ判断処理
				if (this.IsLockDmdSalesData(dr) != 0) continue;
				
				// 選択状態にする
                dr[InputDepositSalesTypeAcs.ctAlwCheck] = "true";

                // 伝票合計取得
                Int64 salesTotalExc = Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctSalesTotalTaxExc]);

                // 引当済金額取得
                Int64 depositAllowanceSales = Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctDepositAllowance_Sales]);

                // 引当残金額取得
                Int64 depositAlwcBlnceSales = Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales]);

                if (depositAllowanceSales == 0)
                {
                    // 未引当の場合
                    // 引当額設定
                    dr[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = salesTotalExc;

                    // 引当残設定(伝票合計－引当額)
                    dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                    // 引当済設定
                    dr[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = salesTotalExc;
                }
                else
                {
                    // 引当済の場合
                    // 引当額設定
                    dr[InputDepositSalesTypeAcs.ctDepositAllowance_Alw] = depositAlwcBlnceSales;

                    // 引当残
                    dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales] = 0;

                    // 引当済
                    dr[InputDepositSalesTypeAcs.ctDepositAllowance_Sales] = salesTotalExc;
                }
                this._subflag = true;        // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について 
                this.grdDmdSalesList.Rows[ix].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activation = Activation.AllowEdit;
                this.grdDmdSalesList.Rows[ix].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activate();
                this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について ------->>>>>
                if (!this._subflag) this._subflag = true;
                this.grdDmdSalesList.PerformAction(UltraGridAction.ExitEditMode);
                // ADD ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑩ 「一括引当」ボタンの押下について -------<<<<<

                //this.grdDmdSalesList.Rows[ix].Cells[InputDepositSalesTypeAcs.ctDepositAllowance_Alw].Activation = Activation.AllowEdit;

                //// 引当額 共通 (入金引当額) 最大額取得処理
                //difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(dr);

                //// 入金引当情報 共通 変更処理
                //inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref dr, true, true);
			}

			// 合計欄計算処理
			this.SetSalesTotal();
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 一括引当ボタン押下 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 一括引当ボタンが押された時に発生します。 </br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void btnAllAwl_Click(object sender, EventArgs e)
        {
            Int64 difference;

            // 受注引当一覧を先頭行からループ
            for (int ix = 0; ix < inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows.Count; ix++)
            {
                DataRow dr = inputDepositSalesTypeAcs.GetDsDmdSalesInfo().Tables[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Rows[ix];

                // 引当残 共通 (請求売上マスタ) が０円の時は無視
                if (Convert.ToInt64(dr[InputDepositSalesTypeAcs.ctDepositAlwcBlnce_Sales]) == 0) continue;

                // 修正付加請求売上データ判断処理 請求売上(赤)の時は無視
                if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000000f0) == 0x000000f0) continue;

                // 修正付加請求売上データ判断処理 請求売上(相殺済み黒)の時は無視
                if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x00000f00) == 0x00000f00) continue;

                // ↓ 20070525 18322 a
                // 修正付加請求売上データ判断処理 POS売上の売掛以外の時は無視
                if ((this.IsLockDmdSalesData(selectedDmdSalesRow) & 0x000f0000) == 0x000f0000)
                {
                    continue;
                }
                // ↑ 20070525 18322 a

                // 修正付加請求売上データ判断処理
                if (this.IsLockDmdSalesData(dr) != 0) continue;

                // 選択状態にする
                dr[InputDepositSalesTypeAcs.ctAlwCheck] = "true";

                // ↓ 20070125 18322 c MA.NS用に変更
                #region SF 受注・諸費用（全てコメントアウト）
                //// 諸費用別入金判定
                //if (depositRelDataAcs.OptSeparateCost == true)			// --- 諸費用別入金 有り --- //
                //{
                //	// 引当額 受注 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxAcpOdrDepositAlwc(dr);
                //    
                //	// 入金引当情報 受注 変更処理
                //	inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref dr, true, true, true);
                //    
                //	// 引当額 諸費用 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxCostDepositAlwc(dr);
                //    
                //	// 入金引当情報 諸費用 変更処理
                //	inputDepositSalesTypeAcs.UpdateCostDepositAlwc(difference, ref dr, true, true, true);
                //
                //	// 引当額 共通 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(dr);
                //
                //	// 入金引当情報 共通 変更処理
                //	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref dr, true, true, true);
                //}
                //else													// --- 諸費用別入金 無し --- //
                //{
                //	// 諸費用別入金無しの時は、共通の項目をベースに計算し、受注に反映させる
                //	// ※このやり方でないと、諸費用別入金オプションの途中削除がうまくいかないはず
                //
                //	// 引当額 共通 (入金引当額) 最大額取得処理
                //	difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(dr);
                //
                //	// 入金引当情報 共通 変更処理
                //	inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref dr, true, true, true);
                //
                //	// 入金引当情報 受注 変更処理
                //	inputDepositSalesTypeAcs.UpdateAcpOdrDepositAlwc(difference, ref dr, true, true, true);
                //}
                #endregion

                // 引当額 共通 (入金引当額) 最大額取得処理
                difference = inputDepositSalesTypeAcs.GetMaxDepositAlwc(dr);

                // 入金引当情報 共通 変更処理
                inputDepositSalesTypeAcs.UpdateDepositAlwc(difference, ref dr, true, true);
                // ↑ 20070125 18322 c
            }

            // 合計欄計算処理
            this.SetSalesTotal();
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 伝票番号エディットLeave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォーカスが無くなる時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void tEdit_SalesSlipNum_Leave(object sender, EventArgs e)
		{
			// 伝票番号
			if (tEdit_SalesSlipNum.Text != "")
			{
				string before = tEdit_SalesSlipNum.Text;

                // ↓ 20070130 18322 c MA.NS用に変更
                #region SF 選択中システム/伝票種別取得処理（全てコメントアウト）
                //// 選択中システム/伝票種別取得処理
				//int[] lstDataInputSystem;
				//int[] lstSlipKindCode;
				//this.GetSelectSystemSlipKind(out lstDataInputSystem, out lstSlipKindCode);
				//if ((lstDataInputSystem.Length != 0) && (lstSlipKindCode.Length != 0))
				//{
				//	// 各システム伝票番号番号コード取得処理
				//	int[] noCodeArray = ConstantManagement_SF_AP.GetSlipNoNoCode(lstDataInputSystem, lstSlipKindCode);
                //
				//	if (noCodeArray.Length != 0)
				//	{
                //
				//		NumberControl numberControl = new NumberControl();
                //
				//		// 番号正規化処理
				//		edtSearchSlipNo.Text = numberControl.Convert(noCodeArray, before);
				//	}
                //}
                #endregion

                NumberControl numberControl = new NumberControl();

				// 番号正規化処理
                int noCodeArray = ctNoCodeSalesSlipNum;
    			tEdit_SalesSlipNum.Text = numberControl.Convert(noCodeArray, before);
                // ↑ 20070130 18322 c
			}
		}

		/// <summary>
		/// 伝票種別チェック状態変更 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : チェック状態が変更された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void cbxAcptAnOdrStartus1_CheckedChanged(object sender, EventArgs e)
		{
			// TEditプロパティー変換処理
			this.TEditChangeEdit(tEdit_SalesSlipNum);
		}

		/// <summary>
		/// システムチェック状態変更 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : チェック状態が変更された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void cbxDataInputSystem1_CheckedChanged(object sender, EventArgs e)
		{
			// TEditプロパティー変換処理
			this.TEditChangeEdit(tEdit_SalesSlipNum);
		}

		/// <summary>
		/// スプリッターマウスEnter イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : コントロールにマウスが入った時にします。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void splitter1_MouseEnter(object sender, EventArgs e)
		{
			splitter1.BackColor = Color.FromArgb(192, 192, 255);
		}

		/// <summary>
		/// スプリッターマウスLeave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : コントロールからマウスが抜けた時にします。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void splitter1_MouseLeave(object sender, EventArgs e)
		{
			splitter1.BackColor = Color.FromArgb(222, 239, 255);
		}

		/// <summary>
		/// キーコントロール イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : キーが押された時に発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2012/09/21 田建委</br>
        /// <br>管理番号    : 2012/10/17配信分</br>
        /// <br>              Redmine#32415 発行者の追加対応</br>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/06 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/19 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/25 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// 受注引当グリッドの時
			if (e.PrevCtrl == grdDmdSalesList)
			{
                if (e.ShiftKey == false)
                {
                    // リターンキーの時
                    if ((e.Key == Keys.Return) ||
                        (e.Key == Keys.Tab))
                    {
                        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                        e.NextCtrl = null;
                           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

                        if (grdDmdSalesList.ActiveCell != null)
                        {
                            if ((grdDmdSalesList.ActiveCell.Row.Index == grdDmdSalesList.Rows.Count - 1) &&
                                (grdDmdSalesList.ActiveCell.Column.Key == InputDepositSalesTypeAcs.ctDepositAlwBtn))
                            {
                                e.NextCtrl = this.btnAllAwl;
                            }
                            else
                            {
                                // 次のセルにフォーカス遷移
                                e.NextCtrl = null;
                                grdDmdSalesList.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (grdDmdSalesList.ActiveCell != null)
                        {
                            if ((grdDmdSalesList.ActiveCell.Row.Index == 0) &&
                                (grdDmdSalesList.ActiveCell.Column.Key == InputDepositSalesTypeAcs.ctAlwCheck))
                            {
                                e.NextCtrl = this.edtOutline;
                            }
                            else
                            {
                                // 前のセルにフォーカス遷移
                                e.NextCtrl = null;
                                grdDmdSalesList.PerformAction(UltraGridAction.PrevCellByTab);
                            }
                        }
                    }
                }
			}
            else if (e.PrevCtrl == this.btnSearch)
            {
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Enter)
                    {
                        this.btnSearch_Click(this.btnSearch, new EventArgs());
                        if (this.edtCustomerName.DataText.Trim() == "")
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                // 得意先コード取得
                int customerCode = this.tNedit_CustomerCode.GetInt();

                // ----- ADD 王君 2013/02/19 Redmine#33741 ----- >>>>>
                bool flag;
                if (customerCode == 0)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                // ----- ADD 王君 2013/02/19 Redmine#33741 ----- <<<<<
                if ((customerCode != 0) && (customerCode == this._prevCustomerCode))
                {
                    if (customerCode == 0)
                    {
                        this.edtCustomerName.Clear();
                    }
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            if (this.edtCustomerName.DataText.Trim() != "")
                            {
                                e.NextCtrl = this.tEdit_SalesSlipNum;
                                return;
                            }
                        }
                    }
                    return;
                }

                // 管理拠点コード取得(得意先マスタ)
                CustomerInfo customerInfo;

                int status = GetCustomerInfo(out customerInfo, customerCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先略称取得
                    this.edtCustomerName.DataText = customerInfo.CustomerSnm.Trim();

                    bool bStatus = CheckClaimCode(customerInfo);

                    // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>
                    if (this.inputDepositSalesTypeAcs.KaToOption())
                    {
                        // 売上月次更新履歴取得
                        this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(this.selectSectionCode);

                        // 売上締次処理日取得
                        this._lastAddUpDay = GetTotalDayDmdC(this.selectSectionCode, customerInfo.ClaimCode);
                    }
                    // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<

                    if (!bStatus)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              "請求先に変更しました。",
                                              0,
                                              MessageBoxButtons.OK);

                        status = ChangeCustomerCode(customerInfo.ClaimCode);
                        if (status != 0)
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                            return;
                        }

                    }
                    else
                    {
                        if (customerInfo.DepoDelCode == 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "得意先マスタの入金消込区分が設定されていません。",
                                          0,
                                          MessageBoxButtons.OK);

                            this.tNedit_CustomerCode.Clear();
                            this.edtCustomerName.Clear();
                            e.NextCtrl = this.tNedit_CustomerCode;
                            return;
                        }

                        if (this._consTaxLayCustomerCode != customerInfo.CustomerCode)
                        {
                            if ((customerInfo.ConsTaxLayMethod == 2) || (customerInfo.ConsTaxLayMethod == 3))
                            {
                                DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                                 this.Name,
                                                                 "指定得意先は請求時課税のユーザーです。" + "\r\n" + "売上引当を行うと消費税が合わなくなりますが、よろしいですか？",
                                                                 0,
                                                                 MessageBoxButtons.YesNo);

                                if (res == DialogResult.No)
                                {
                                    this.tNedit_CustomerCode.Clear();
                                    this.edtCustomerName.Clear();
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                    this._consTaxLayCustomerCode = 0;
                                    return;
                                }

                                this._consTaxLayCustomerCode = customerInfo.CustomerCode;
                            }
                        }

                        // 請求先コード
                        this.claimCode = customerInfo.ClaimCode;

                        // 請求拠点コード
                        this.selectSectionCode = customerInfo.ClaimSectionCode.Trim();

                        // 消費税転嫁方式
                        this._consTaxLayMethod = customerInfo.ConsTaxLayMethod;
                    }

                    // 得意先コード
                    this._customerCode = customerCode;
                }
                else
                {
                    this.edtCustomerName.Clear();
                    this._prevCustomerCode = 0;
                    this._customerCode = 0;
                    this.claimCode = 0;
                    this.selectSectionCode = "";
                    /* ----- DEL 王君 2012/02/06 Redmine#33741 ------>>>>>
                    // ----- ADD 王君 2012/12/24 Redmine#33741 ------>>>>>
                    this.tNedit_CustomerCode.Clear();
                    if (e.NextCtrl != this.btnCustomerGuid && e.NextCtrl != this.tNedit_CustomerCode)
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "得意先コードが未入力です。",
                                          0,
                                          MessageBoxButtons.OK);
                        }
                        e.NextCtrl = this.tNedit_CustomerCode;
                        return;
                    }
                    // ----- ADD 王君 2012/12/24 Redmine#33741 ------<<<<< 
                    // ----- ADD 王君 2012/02/06 Redmine#33741 ------<<<<<   */
                }

                if (e.ShiftKey == false)
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Enter:
                            {
                                //if (this.edtCustomerName.DataText.Trim() != "")   // DEL 2009/06/26
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // DEL 2009/06/26
                                {
                                    e.NextCtrl = this.tEdit_SalesSlipNum;
                                    return;
                                }
                                else
                                {
                                    //this.btnCustomerGuid_Click(this.tNedit_CustomerCode, new EventArgs()); // DEL 王君 2013/02/06 Redmine#33741 
                                    //if (this.edtCustomerName.DataText.Trim() != "")   // DEL 2009/06/26
                                    /*  ----- DEL 王君 2013/02/25 Redmine#33741 ----->>>>>
                                    //  ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                    if (!flag)
                                    {
                                        //  ----- ADD 王君 2013/02/19 Redmine#33741 ----- <<<<<
                                        //  ----- ADD 王君 2013/02/06 Redmine#33741 ----->>>>>
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "得意先コードが未入力です。",
                                            0,
                                            MessageBoxButtons.OK);
                                        this.tNedit_CustomerCode.Clear();
                                        this.edtCustomerName.Clear();
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        //  ----- ADD 王君 2013/02/06 Redmine#33741 -----<<<<<
                                        //  ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                        this._prevCustomerCode = 0;
                                        this._customerCode = 0;
                                        this.claimCode = 0;
                                        this.selectSectionCode = "";
                                        return;
                                    }
                                    else
                                    {
                                        this.btnCustomerGuid_Click(this.tNedit_CustomerCode, new EventArgs());
                                    }
                                    //  ----- ADD 王君 2013/02/19 Redmine#33741 ----- <<<<<
                                    ----- DEL 王君 2013/02/25 Redmine#33741 -----<<<<< */
                                    this.btnCustomerGuid_Click(this.tNedit_CustomerCode, new EventArgs());// ADD 王君 2013/02/25 Redmine#33741  
                                    if (this._cusotmerGuideSelected)    // ADD 2009/06/26
                                    {
                                        // ----- ADD 王君　2013/02/19 Redmine#33741 ----- >>>>>
                                        if (this._depoDelCode == 0)
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        else
                                        {
                                        //  ----- ADD 王君 2013/02/19 Redmine#33741 ----- <<<<<
                                            e.NextCtrl = this.tEdit_SalesSlipNum;
                                        }// ADD 王君 2013/02/19 Redmine#33741
                                        return;
                                    }
                                    else
                                    {
                                        // ----- ADD 王君 2013/02/25 Redmine#33741 ----->>>>>
                                        if (!flag)
                                        {
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "得意先コードが未入力です。",
                                                0,
                                                MessageBoxButtons.OK);
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        // ----- ADD 王君 2013/02/25 Redmine#33741 -----<<<<<
                                        this.edtCustomerName.Clear();
                                        this._prevCustomerCode = 0;
                                        this._customerCode = 0;
                                        this.claimCode = 0;
                                        this.selectSectionCode = "";
                                    }
                                }
                                break;
                            }
                            // ----- ADD 王君 2013/02/06 Redmine#33741 ----->>>>>
                        case Keys.Right:
                        case Keys.Down:
                            {
                                /* ----- DEL 王君 2013/02/25 Redmine#33741 ----->>>>>
                                // ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                if (!flag)
                                {
                                    // ----- ADD 王君 2013/02/19 Redmine#33741 -----<<<<<
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                           this.Name,
                                           "得意先コードが未入力です。",
                                           0,
                                           MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode.Clear();
                                    this.edtCustomerName.Clear();
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                } // ADD 王君 2013/02/19 Redmine#33741
                                ----- DEL 王君 2013/02/25 Redmine#33741 -----<<<<< */
                                //----- ADD 王君 2013/02/25 Redmine#33741 ----->>>>>
                                if (!flag)
                                {
                                    this.btnCustomerGuid_Click(this.tNedit_CustomerCode, new EventArgs());
                                    if (this._cusotmerGuideSelected) 
                                    {
                                        if (this._depoDelCode == 0)
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SalesSlipNum;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                           this.Name,
                                           "得意先コードが未入力です。",
                                           0,
                                           MessageBoxButtons.OK);
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        this.edtCustomerName.Clear();
                                        this._prevCustomerCode = 0;
                                        this._customerCode = 0;
                                        this.claimCode = 0;
                                        this.selectSectionCode = "";
                                    }
                                }
                                //----- ADD 王君 2013/02/25 Redmine#33741 -----<<<<<
                            }
                            break;
                            // ----- ADD 王君 2013/02/06 Redmine#33741 -----<<<<<
                    }
                }
            }
            /* ------ DEL 王君 2013/02/06 Redmine#33741 --------->>>>> 
            // ------ ADD 王君 2012/12/24 Redmine#33741 --------->>>>> 
            else if (e.PrevCtrl == this.btnCustomerGuid)
            {
                // 管理拠点コード取得(得意先マスタ)
                CustomerInfo customerInfo;

                int status = GetCustomerInfo(out customerInfo, this.tNedit_CustomerCode.GetInt());
                if (status != 0)
                {
                    if (e.NextCtrl != this.tNedit_CustomerCode)
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                           this.Name,
                                           "得意先コードが未入力です。",
                                           0,
                                           MessageBoxButtons.OK);
                        }
                        e.NextCtrl = this.tNedit_CustomerCode;
                        return;
                    }
                }
            }
            // ------ ADD 王君 2012/12/24 Redmine#33741 ---------<<<<<
            // ------ DEL 王君 2013/02/06 Redmine#33741 ---------<<<<< */
            //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
            else if (e.PrevCtrl == this.edtOutline)
            {
                if (!e.ShiftKey)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = tEdit_EmployeeCode;
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_EmployeeCode)
            {
                string inputValue = tEdit_EmployeeCode.Text;

                string code;
                bool status = ReadSalesInputName(out code);

                if (status == true)
                {
                    // 名称表示
                    if (!string.IsNullOrEmpty(_swSalesInputCode))
                    {
                        this.tEdit_EmployeeCode.Text = this._swSalesInputCode.Trim().PadLeft(4, '0');
                        this.tEdit_SalesInputName.Text = this._swSalesInputName;
                    }
                    else
                    {
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_SalesInputName.Clear();
                    }

                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                }
                                break;
                        }
                    }
                }
                else
                {
                    this.tEdit_EmployeeCode.Clear();
                    this.tEdit_SalesInputName.Clear();

                    uButton_SalesInputCode_Click(tEdit_EmployeeCode, new EventArgs());

                    e.NextCtrl = e.PrevCtrl;
                }
            }
            //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<
            //else if (e.PrevCtrl == this.tNedit_BankCode)
            //{
            //    if (this.tNedit_BankCode.GetInt() == 0)
            //    {
            //        this.teditBankName.Clear();
            //        return;
            //    }

            //    // 銀行コード取得
            //    int bankCode = this.tNedit_BankCode.GetInt();

            //    // 銀行名称取得
            //    this.teditBankName.DataText = GetBankName(bankCode);

            //    if (this.teditBankName.DataText.Trim() == "")
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
            //                      this.Name,
            //                      "銀行コードが存在しません。",
            //                      0,
            //                      MessageBoxButtons.OK);
            //        e.NextCtrl = e.PrevCtrl;
            //        this.tNedit_BankCode.SelectAll();
            //        return;
            //    }

            //    if (e.ShiftKey == false)
            //    {
            //        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
            //        {
            //            if (this.teditBankName.DataText.Trim() != "")
            //            {
            //                e.NextCtrl = dateDraftDrawingDate;
            //            }
            //        }
            //    }
            //}
            else if (e.PrevCtrl == this.tEdit_SalesSlipNum)
            {
                if (e.ShiftKey == true)
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.edtCustomerName.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                            return;
                        }
                    }
                }
            }
            //else if (e.PrevCtrl == this.dateDraftDrawingDate)
            //{
            //    if (e.ShiftKey == true)
            //    {
            //        if (e.Key == Keys.Tab)
            //        {
            //            if (this.teditBankName.DataText.Trim() != "")
            //            {
            //                e.NextCtrl = this.tNedit_BankCode;
            //            }
            //        }
            //    }
            //}

            if (e.NextCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.grdDmdSalesList)
            {
                if (e.ShiftKey == false)
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Enter:
                        case Keys.Down:
                            {
                                if (this.grdDmdSalesList.Rows.Count == 0)
                                {
                                    e.NextCtrl = cmbFontSize;
                                    return;
                                }

                                this.grdDmdSalesList.Rows[0].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Activate();
                                this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        case Keys.Up:
                            {
                                if (this.grdDmdSalesList.Rows.Count == 0)
                                {
                                    //if (this.cmbDraftKind.Enabled)
                                    //{
                                    //    e.NextCtrl = this.cmbDraftKind;
                                    //}
                                    //else if (this.tNedit_BankCode.Enabled)
                                    //{
                                    //    e.NextCtrl = this.tNedit_BankCode;
                                    //}
                                    if (this.cmbMoneyKind.Enabled)
                                    {
                                        e.NextCtrl = this.cmbMoneyKind;
                                    }
                                    return;
                                }

                                this.grdDmdSalesList.Rows[this.grdDmdSalesList.Rows.Count - 1].Cells[InputDepositSalesTypeAcs.ctAlwCheck].Activate();
                                this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.grdDmdSalesList.Rows.Count == 0)
                        {
                            return;
                        }

                        this.grdDmdSalesList.Rows[this.grdDmdSalesList.Rows.Count - 1].Cells[InputDepositSalesTypeAcs.ctDepositAlwBtn].Activate();
                        this.grdDmdSalesList.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
		}

        //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
        /// <summary>
        /// 発行者名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <remarks>
        /// <br>Note　　　  : 発行者名称取得を行う。 </br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2012/09/21</br>
        /// <br>管理番号    : 2012/10/17配信分</br>
        /// <br>              Redmine#32415 発行者の追加対応</br>
        /// </remarks>
        private bool ReadSalesInputName(out string code)
        {
            // 入力値を取得
            string inputValue = this.tEdit_EmployeeCode.Text.Trim();
            code = inputValue;

            // 空でなければ処理開始
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swSalesInputCode)
                    {
                        // コードから名称へ変換
                        Employee employeeInfo;
                        int status = this._employeeAcs.Read(out employeeInfo, this.enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swSalesInputCode = inputValue;
                            this._swSalesInputName = employeeInfo.Name;
                            code = _swSalesInputCode;
                            return true;
                        }
                        else
                        {
                            // 戻す
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_EmployeeCode.Name, _swSalesInputCode);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_EmployeeCode.Name, _swSalesInputCode);
                    return false;
                }
            }
            else
            {
                this._swSalesInputCode = string.Empty;
                this._swSalesInputName = string.Empty;
                code = string.Empty;
                return true;
            }
        }
        //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<

		/// <summary>
		/// タイマー起動 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 画面起動後の処理を行います。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Enabled = false;

			// 得意先コードにフォーカスセット
			tNedit_CustomerCode.Focus();
		}
		# endregion


		# region private class
		/// <summary>
		/// 得意先名称取得クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先名称を取得するクラスです。
		///                : 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private class GetCustomerNamePrc
		{
			/// <summary>結果を返すためのコールバックデリゲート</summary>
            public delegate void Callback(string name, int claimCode);

			/// <summary>デリゲートオブジェクト</summary>
			private Callback callbackDelegate;

 			/// <summary>入金伝票入力画面(受注指定型)アクセスクラス</summary>
			private InputDepositSalesTypeAcs inputDepositSalesTypeAcs;

			/// <summary>情報取得用パラメータ 企業コード</summary>
			private string _enterpriseCode;

			/// <summary>情報取得用パラメータ 得意先コード</summary>
			private int _customerCode;

			/// <summary>
			/// 得意先名称取得クラス
			/// </summary>
			/// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
			/// <param name="customerCode">情報取得用パラメータ 得意先コード</param>
			/// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
			/// <remarks>
			/// <br>Note       : 使用するメンバの初期化を行います。</br>
			/// <br>Programmer : 97036 amami</br>
			/// <br>Date       : 2005.07.21</br>
			/// </remarks>
            public GetCustomerNamePrc(string enterpriseCode, int customerCode, Callback callback)
			{
				// 入金伝票入力画面(受注指定型)アクセスクラス
				this.inputDepositSalesTypeAcs = new InputDepositSalesTypeAcs();

				// 情報取得用パラメータ
				_enterpriseCode	= enterpriseCode;
				_customerCode	= customerCode;

				// コールバックメソッドのデリゲート登録
				callbackDelegate  = callback;
			}

			/// <summary>
			/// メイン処理
			/// </summary>
			/// <remarks>
			/// <br>Note       : 得意先名称の取得を行います。</br>
			/// <br>Programmer : 97036 amami</br>
			/// <br>Date       : 2005.07.21</br>
			/// </remarks>
			public void Main()
			{
				try
				{
					// 得意先取得
					string name;
                    int claimCode;
                    int st = inputDepositSalesTypeAcs.ReadCustomer(ConstantManagement.LogicalMode.GetData0, _enterpriseCode, _customerCode, out name, out claimCode);
					if (st == 0)
					{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
                        if (callbackDelegate != null)
                        {
                            callbackDelegate(name, claimCode);
                        }
					}
				}
				catch (ThreadAbortException)
				{
					// スレッド中断時
				}
				catch (Exception)
				{
					// その他エラー時  たいした処理ではないので、エラーがおきても無視
				}

			}
        }

        #region 2007.10.09 hikita del
        // 2007.10.09 hikita del start -------------------------------------------->>
        ///// <summary>
        ///// クレジット会社名称取得クラス
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : クレジット会社名称を取得するクラスです。
        /////                : 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        //private class GetCreditCompanyNamePrc
		//{
            ///// <summary>結果を返すためのコールバックデリゲート</summary>
            //public delegate void Callback(string creditCompanyName);

            ///// <summary>デリゲートオブジェクト</summary>
            //private Callback callbackDelegate;

            ///// <summary>クレジット会社テーブルアクセスクラス</summary>
            //private CreditCmpAcs creditCmpAcs;

            ///// <summary>情報取得用パラメータ 企業コード</summary>
            //private string _enterpriseCode;

            ///// <summary>情報取得用パラメータ クレジット会社コード</summary>
            //private string _creditCompanyCode;

            ///// <summary>
            ///// クレジット会社名称取得クラス
            ///// </summary>
            ///// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
            ///// <param name="creditCompanyCode">情報取得用パラメータ クレジット会社コード</param>
            ///// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
            ///// <remarks>
            ///// <br>Note       : 使用するメンバの初期化を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public GetCreditCompanyNamePrc(string enterpriseCode, string creditCompanyCode, Callback callback)
		//	{
				// クレジット会社テーブルアクセスクラス
		//		this.creditCmpAcs = new CreditCmpAcs();

				// 情報取得用パラメータ
		//		_enterpriseCode		= enterpriseCode;
		//		_creditCompanyCode	= creditCompanyCode;

				// コールバックメソッドのデリゲート登録
		//		callbackDelegate = callback;
		//	}

            ///// <summary>
            ///// メイン処理
            ///// </summary>
            ///// <remarks>
            ///// <br>Note       : クレジット会社名称の取得を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public void Main()
		//	{
		//		try
		//		{
					// クレジット会社取得
		//			CreditCmp creditCmp = new CreditCmp();
		//			int st = creditCmpAcs.Read(out creditCmp, _enterpriseCode, _creditCompanyCode);
		//			if (st == 0)
		//			{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
		//				if (callbackDelegate != null)
		//					callbackDelegate(creditCmp.CreditCompanyName);
		//			}
		//		}
		//		catch (ThreadAbortException)
		//		{
					// スレッド中断時
		//		}
		//		catch (Exception)
		//		{
					// その他エラー時  たいした処理ではないので、エラーがおきても無視
		//		}

  		//	}
		//}

        ///// <summary>
        ///// 従業員名称取得クラス
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 従業員名称を取得するクラスです。
        /////                : 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
		//private class GetEmployeeNamePrc
		//{
            ///// <summary>結果を返すためのコールバックデリゲート</summary>
            //public delegate void Callback(string name);

            ///// <summary>デリゲートオブジェクト</summary>
            //private Callback callbackDelegate;

            ///// <summary>従業員テーブルアクセスクラス</summary>
            //private EmployeeAcs employeeAcs;

            ///// <summary>情報取得用パラメータ 企業コード</summary>
            //private string _enterpriseCode;

            ///// <summary>情報取得用パラメータ 従業員コード</summary>
            //private string _employeeCode;

            ///// <summary>情報取得用パラメータ 受付/メカ区分</summary>
            //private int _frontMechaCode;

            ///// <summary>
            ///// 従業員名称取得クラス
            ///// </summary>
            ///// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
            ///// <param name="employeeCode">情報取得用パラメータ 従業員コード</param>
            ///// <param name="frontMechaCode">情報取得用パラメータ 受付/メカ区分</param>
            ///// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
            ///// <remarks>
            ///// <br>Note       : 使用するメンバの初期化を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public GetEmployeeNamePrc(string enterpriseCode, string employeeCode, int frontMechaCode, Callback callback)
		//	{
				// 従業員テーブルアクセスクラス
		//		this.employeeAcs = new EmployeeAcs();

				// 情報取得用パラメータ
		//		_enterpriseCode	= enterpriseCode;
		//		_employeeCode	= employeeCode;
		//		_frontMechaCode	= frontMechaCode;

				// コールバックメソッドのデリゲート登録
		//		callbackDelegate = callback;
		//	}

            ///// <summary>
            ///// メイン処理
            ///// </summary>
            ///// <remarks>
            ///// <br>Note       : クレジット会社名称の取得を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public void Main()
		//	{
		//		try
		//		{
					// 従業員取得
		//			Employee employee = new Employee();
		//			int st = employeeAcs.Read(out employee, _enterpriseCode, _employeeCode);
		//			if (st == 0)
		//			{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
		//				if (callbackDelegate != null)
		//				{
							// 受付/メカ区分のチェック
		//					if (employee.FrontMechaCode == _frontMechaCode)
		//					{
		//						callbackDelegate(employee.Name);
		//					}
		//				}
		//			}
		//		}
		//		catch (ThreadAbortException)
		//		{
					// スレッド中断時
		//		}
		//		catch (Exception)
		//		{
					// その他エラー時  たいした処理ではないので、エラーがおきても無視
		//		}

		//	}
		//}

        ///// <summary>
        ///// クレジット会社名称取得クラス
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : クレジット会社名称を取得するクラスです。
        /////                : 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
        //private class GetCreditCompanyNamePrc2
		//{
            ///// <summary>結果を返すためのコールバックデリゲート</summary>
            //public delegate void Callback(string creditCompanyCode, string creditCompanyName);
            ///// <summary>デリゲートオブジェクト</summary>
            //private Callback callbackDelegate;
            ///// <summary>クレジット会社テーブルアクセスクラス</summary>
            //private CreditCmpAcs creditCmpAcs;
            ///// <summary>情報取得用パラメータ 企業コード</summary>
            //private string _enterpriseCode;
            ///// <summary>情報取得用パラメータ クレジット会社コード</summary>
            //private string _creditCompanyCode;
            ///// <summary>
            ///// クレジット会社名称取得クラス
            ///// </summary>
            ///// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
            ///// <param name="creditCompanyCode">情報取得用パラメータ クレジット会社コード</param>
            ///// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
            ///// <remarks>
            ///// <br>Note       : 使用するメンバの初期化を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public GetCreditCompanyNamePrc2(string enterpriseCode, string creditCompanyCode, Callback callback)
		//	{
				// クレジット会社テーブルアクセスクラス
		//		this.creditCmpAcs = new CreditCmpAcs();
				// 情報取得用パラメータ
		//		_enterpriseCode		= enterpriseCode;
		//		_creditCompanyCode	= creditCompanyCode;
				// コールバックメソッドのデリゲート登録
		//		callbackDelegate = callback;
		//	}

            ///// <summary>
            ///// メイン処理
            ///// </summary>
            ///// <remarks>
            ///// <br>Note       : クレジット会社名称の取得を行います。</br>
            ///// <br>Programmer : 97036 amami</br>
            ///// <br>Date       : 2005.07.21</br>
            ///// </remarks>
		//	public void Main()
		//	{
		//		try
		//		{
					// クレジット会社取得
		//			CreditCmp creditCmp = new CreditCmp();
		//			int st = creditCmpAcs.Read(out creditCmp, _enterpriseCode, _creditCompanyCode);
		//			if (st == 0)
		//			{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
		//				if (callbackDelegate != null)
		//					callbackDelegate(_creditCompanyCode, creditCmp.CreditCompanyName);
		//			}
		//			else
		//			{
						// コールバックデリゲートを実行して結果を返す → メソッドコールバック
		//				if (callbackDelegate != null)
		//					callbackDelegate("", "");
		//			}
		//		}
		//		catch (ThreadAbortException)
		//		{
					// スレッド中断時
		//		}
		//		catch (Exception)
		//		{
					// その他エラー時  たいした処理ではないので、エラーがおきても無視
		//		}
		//	}
		//}
        // 2007.10.09 hikita del end -------------------------------------------------------<<
        #endregion 2007.10.09 hikita del

        #region DEL 2008/06/26 Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.09 hikita add start ----------------------------------------------------->>
        /// <summary>
        /// 銀行名称取得クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 銀行名称を取得するクラスです。
        ///                : 取得結果はコンストラクタ引数のコールバックメソッドにて返します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        private class GetBankNamePrc
        {
            /// <summary>結果を返すためのコールバックデリゲート</summary>
        	public delegate void Callback(int bankCode, string bankName);
            /// <summary>デリゲートオブジェクト</summary>
        	private Callback callbackDelegate;
            /// <summary>ユーザーガイドアクセスクラス</summary>
        	private UserGuideAcs userGuideAcs;
            /// <summary>情報取得用パラメータ 企業コード</summary>
        	private string _enterpriseCode;
            /// <summary>情報取得用パラメータ 銀行コード</summary>
        	private int _bankCode;
            /// <summary>
            /// 銀行名称取得クラス
            /// </summary>
            /// <param name="enterpriseCode">情報取得用パラメータ 企業コード</param>
            /// <param name="bankCode">情報取得用パラメータ 銀行コード</param>
            /// <param name="callback">Mainメソッド終了時コールバックメソッド</param>
            /// <remarks>
            /// <br>Note       : 使用するメンバの初期化を行います。</br>
            /// <br>Programmer : 20081 疋田 勇人</br>
            /// <br>Date       : 2007.10.09</br>
            /// </remarks>
        	public GetBankNamePrc(string enterpriseCode, int bankCode, Callback callback)
        	{
                // ユーザーガイドアクセスクラス
        		this.userGuideAcs = new UserGuideAcs();
                // 情報取得用パラメータ
        		_enterpriseCode	 = enterpriseCode;
        		_bankCode	     = bankCode;
                // コールバックメソッドのデリゲート登録
        		callbackDelegate = callback;
        	}

            /// <summary>
            /// メイン処理
            /// </summary>
            /// <remarks>
            /// <br>Note       : クレジット会社名称の取得を行います。</br>
            /// <br>Programmer : 97036 amami</br>
            /// <br>Date       : 2005.07.21</br>
            /// </remarks>
        	public void Main()
        	{
        		try
        		{
                    // 銀行名取得
                    string guideName = "";
                    int iBankCode = 0;
                    iBankCode = Convert.ToInt32(_bankCode);
                    UserGdBd userGdBd = new UserGdBd();

                    int st = userGuideAcs.GetGuideName(out guideName, _enterpriseCode, 46, iBankCode);

        			if (st == 0)
        			{
                        // コールバックデリゲートを実行して結果を返す → メソッドコールバック
        				if (callbackDelegate != null)
                            callbackDelegate(_bankCode, userGdBd.GuideName);
        			}
        			else
        			{
                        // コールバックデリゲートを実行して結果を返す → メソッドコールバック
        				if (callbackDelegate != null)
        					callbackDelegate(0, "");
        			}
        		}
        		catch (ThreadAbortException)
        		{
                // スレッド中断時
        		}
        		catch (Exception)
        		{
                // その他エラー時  たいした処理ではないので、エラーがおきても無視
        		}
        	}
        }
        // 2007.10.09 hikita add end -------------------------------------------------------<<
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman用に変更

        /// <summary>
		/// 画面状態保持クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態を保持する為の外部ＸＭＬファイルのクラスです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		[Serializable]
		public class SFUKK01406UA_DisplayInfo
		{
			/// <summary>コンストラクタ</summary>
			public SFUKK01406UA_DisplayInfo()
			{
				_detailDmdSalesList = 0;
				_separateCost = 0;
			}

			/// <summary>詳細表示</summary>
			private Int32 _detailDmdSalesList;
			/// <summary>諸費用別入金</summary>
			private Int32 _separateCost;

			/// <summary>詳細表示 プロパティ</summary>
			public Int32 DetailDmdSalesList
			{
				get { return _detailDmdSalesList; }
				set { _detailDmdSalesList = value; }
			}
			/// <summary>諸費用別入金 プロパティ</summary>
			public Int32 SeparateCost
			{
				get { return _separateCost; }
				set { _separateCost = value; }
			}
		}
		# endregion

        #region DEL 2008/06/26 使用していないのでコメントアウト
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		# region debug
		private void ultraButton1_Click(object sender, EventArgs e)
		{
			grdDmdSalesList.DisplayLayout.Bands[InputDepositSalesTypeAcs.ctDmdSalesDataTable].Columns[InputDepositSalesTypeAcs.ctCustomerCode].Hidden				= false;			// 得意先コード
			TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, grdDmdSalesList.Rows.Count.ToString(), 0, MessageBoxButtons.OK);
		}
		# endregion
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 使用していないのでコメントアウト

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 得意先ガイドボタン クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先ガイドを起動します。 </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2011/01/21 yangmj Redmine#18653の修正
        /// </remarks>
        private void btnCustomerGuid_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // --- UPD 2011/01/21 ---------->>>>>
                //PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                //customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

                PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                // --- UPD 2011/01/21 ----------<<<<<

                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    if (this._depoDelCode != 0)
                    {
                        this.tEdit_SalesSlipNum.Focus();
                    }
                    else
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            if (customerSearchRet.CustomerCode != this._prevCustomerCode)
            {
                CustomerInfo customerInfo;

                int status = GetCustomerInfo(out customerInfo, customerSearchRet.CustomerCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先コード設定
                    this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                    // 得意先略称取得
                    this.edtCustomerName.DataText = customerSearchRet.Snm.Trim();

                    // 請求先コードチェック
                    bool bStatus = CheckClaimCode(customerInfo);
                    if (!bStatus)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "請求先に変更しました。",
                                          0,
                                          MessageBoxButtons.OK);

                        // 得意先コード
                        this._customerCode = customerInfo.CustomerCode;

                        status = ChangeCustomerCode(customerInfo.ClaimCode);
                    }
                    else
                    {
                        this._depoDelCode = customerInfo.DepoDelCode;

                        if (customerInfo.DepoDelCode == 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "得意先マスタの入金消込区分が設定されていません。",
                                      0,
                                      MessageBoxButtons.OK);

                            this.tNedit_CustomerCode.Clear();
                            this.edtCustomerName.Clear();
                            return;
                        }

                        if (this._consTaxLayCustomerCode != customerInfo.CustomerCode)
                        {
                            if ((customerInfo.ConsTaxLayMethod == 2) || (customerInfo.ConsTaxLayMethod == 3))
                            {
                                DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                                 this.Name,
                                                                 "指定得意先は請求時課税のユーザーです。" + "\r\n" + "売上引当を行うと消費税が合わなくなりますが、よろしいですか？",
                                                                 0,
                                                                 MessageBoxButtons.YesNo);

                                if (res == DialogResult.No)
                                {
                                    this.tNedit_CustomerCode.Clear();
                                    this.edtCustomerName.Clear();
                                    this._consTaxLayCustomerCode = 0;
                                    return;
                                }

                                this._consTaxLayCustomerCode = customerInfo.CustomerCode;
                            }
                        }

                        // 得意先コード
                        this._customerCode = customerSearchRet.CustomerCode;

                        // 請求拠点コード
                        this.selectSectionCode = customerInfo.ClaimSectionCode.Trim();

                        this.claimCode = customerInfo.ClaimCode;// ADD BY zhujw 2014/07/10 FOR RedMine#42902の⑭ 得意先ガイドを使用してコードを入力・検索すると「引当日」、「金種」が表示されない。

                        this._consTaxLayMethod = customerInfo.ConsTaxLayMethod;

                        this._prevCustomerCode = customerSearchRet.CustomerCode;
                    }
                }
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// 請求先コードチェック処理
        /// </summary>
        /// <param name="customerInfo">得意先マスタ</param>
        /// <returns>ステータス(True:一致 Flase:不一致)</returns>
        private bool CheckClaimCode(CustomerInfo customerInfo)
        {
            if (customerInfo.CustomerCode == customerInfo.ClaimCode)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private int ChangeCustomerCode(int claimCode)
        {
            // 得意先コードに請求先コードをセット
            this.tNedit_CustomerCode.SetInt(claimCode);

            CustomerInfo customerInfo;

            int status = GetCustomerInfo(out customerInfo, claimCode);
            if (status == 0)
            {
                // 得意先略称取得
                this.edtCustomerName.DataText = customerInfo.CustomerSnm.Trim();

                this._depoDelCode = customerInfo.DepoDelCode;

                if (customerInfo.DepoDelCode == 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "得意先マスタの入金消込区分が設定されていません。",
                              0,
                              MessageBoxButtons.OK);

                    this.tNedit_CustomerCode.Clear();
                    this.edtCustomerName.Clear();

                    return -1;
                }

                if (this._consTaxLayCustomerCode != customerInfo.CustomerCode)
                {
                    if ((customerInfo.ConsTaxLayMethod == 2) || (customerInfo.ConsTaxLayMethod == 3))
                    {
                        DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                         this.Name,
                                                         "指定得意先は請求時課税のユーザーです。" + "\r\n" + "売上引当を行うと消費税が合わなくなりますが、よろしいですか？",
                                                         0,
                                                         MessageBoxButtons.YesNo);

                        if (res == DialogResult.No)
                        {
                            this.tNedit_CustomerCode.Clear();
                            this.edtCustomerName.Clear();
                            this._consTaxLayCustomerCode = 0;
                            return -1;
                        }

                        this._consTaxLayCustomerCode = customerInfo.CustomerCode;
                    }
                }

                // 請求先コード
                this.claimCode = customerInfo.ClaimCode;

                // 請求拠点コード
                this.selectSectionCode = customerInfo.ClaimSectionCode.Trim();

                // 消費税転嫁方式
                this._consTaxLayMethod = customerInfo.ConsTaxLayMethod;
            }

            return (status);
        }

        /// <summary>
        /// 得意先情報取得処理
        /// </summary>
        /// <param name="customerInfo">得意先情報オブジェクト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードから対象の得意先情報を取得します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private int GetCustomerInfo(out CustomerInfo customerInfo, int customerCode)
        {
            customerInfo = new CustomerInfo();
            int status;

            try
            {
                status = this._customerInfoAcs.ReadDBData(this.enterpriseCode, customerCode, true, out customerInfo);
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }

            return (status);
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロール(手数料)からフォーカスが離れたときに発生します。 </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)</br>
        /// <br>              売上指定型の選択合計入金額の修正</br>
        /// </remarks>
        private void edtFeeDeposit_Leave(object sender, EventArgs e)
        {
            // 合計欄計算処理
            SetSalesTotal();
        }

        /// <summary>
        /// 銀行名称取得処理
        /// </summary>
        /// <param name="bankCode">銀行コード</param>
        /// <returns>銀行名称</returns>
        /// <remarks>
        /// <br>Note　　　  : 銀行名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private string GetBankName(int bankCode)
        {
            string bankName = "";
            try
            {
                // 銀行名称取得
                UserGuideAcs userGuideAcs = new UserGuideAcs();
                int st = userGuideAcs.GetGuideName(out bankName, LoginInfoAcquisition.EnterpriseCode, 46, bankCode);
                if (st != 0)
                {
                    bankName = "";
                }
            }
            catch
            {
                bankName = "";
            }

            return bankName;
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void grdDmdSalesList_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.Column.Key != InputDepositSalesTypeAcs.ctDepositAllowance_Alw)
            {
                return;
            }

            if (uGrid.ActiveCell.IsInEditMode)
            {
                if (!KeyPressNumCheck(10, 0, uGrid.ActiveCell.Text, e.KeyChar, uGrid.ActiveCell.SelStart, uGrid.ActiveCell.SelLength, true))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
        // --- ADD m.suzuki 2010/07/01 ---------->>>>>
        /// <summary>
        /// 未入金一覧表 印刷ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoDepSalList_Click( object sender, EventArgs e )
        {
            PMKAU02000UA noDepSalListForm = new PMKAU02000UA();
            try
            {
                // 初期表示内容セット
                noDepSalListForm.ParaDmdSectionCode = selectSectionCode;
                noDepSalListForm.ParaClaimCode = claimCode;

                // 表示
                noDepSalListForm.ShowDialog( this );
            }
            finally
            {
                noDepSalListForm.Dispose();
            }
        }
        /// <summary>
        /// 未入金一覧表ボタンの有効・無効判定（※起動時に１回のみ使用する想定）
        /// </summary>
        /// <returns></returns>
        private bool CheckNoDepSalListEnabled()
        {
            const int ct_PDFOut = 1;
            const int ct_PrintOut = 2;

            if ( MyOpeCtrlForNoDepSalList.Disabled( ct_PrintOut ) &&
                 MyOpeCtrlForNoDepSalList.Disabled( ct_PDFOut ) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // --- ADD m.suzuki 2010/07/01 ----------<<<<<

        //----- ADD 2012/09/21 田建委 redmine#32415 ---------->>>>>
        /// <summary>
        /// 発行者ガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : 発行者ガイドを押す処理を行う。 </br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2012/09/21</br>
        /// <br>管理番号    : 2012/10/17配信分</br>
        /// <br>              Redmine#32415 発行者の追加対応</br>
        /// </remarks>
        private void uButton_SalesInputCode_Click(object sender, EventArgs e)
        {
            // ガイド表示
            Employee employeeInfo;
            int status;

            status = this._employeeAcs.ExecuteGuid(this.enterpriseCode, true, out employeeInfo);

            // ステータスが正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 名前をUIにセット、コードはメモリ内に保存
                this._swSalesInputName = employeeInfo.Name.TrimEnd();
                this._swSalesInputCode = employeeInfo.EmployeeCode;

                if (!string.IsNullOrEmpty(_swSalesInputCode))
                {
                    this.tEdit_EmployeeCode.Text = this._swSalesInputCode.Trim().PadLeft(4, '0');
                    this.tEdit_SalesInputName.Text = this._swSalesInputName;
                }

                Control nextControl = null;

                if (nextControl != null) nextControl.Focus();
            }
        }
        //----- ADD 2012/09/21 田建委 redmine#32415 ----------<<<<<

        // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 ------->>>>>
        /// <summary>
        /// 入金伝票削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金伝票の削除処理を行います。</br>
        /// <br>Programmer : zhujw</br>
        /// <br>Date       : 2014/07/04</br>
        /// </remarks>
        private void DeleteDeposit()
        {
            // grdDmdSalesListのgrdDmdSalesList->Dictionaryの変更
            Dictionary<string, DataRow> dic = new Dictionary<string, DataRow>();
            DataView dt = grdDmdSalesList.DataSource as DataView;
            foreach (DataRow dr in dt.Table.Rows)
            {
                string key = dr[InputDepositSalesTypeAcs.ctSalesSlipNum].ToString();
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, dr);
                }
            }

            // grdDmdSalesListに選択のDataの情報を設定
            UltraGridRow row = grdDmdSalesList.ActiveRow;
            // 売上伝票番号
            string slipNo = row.Cells[InputDepositSalesTypeAcs.ctSalesSlipNum].Value.ToString();
            // 得意先番号
            int customerCode = this.tNedit_CustomerCode.GetInt();
            //　受注ステータス
            int acptStatus = Convert.ToInt32(row.Cells[InputDepositSalesTypeAcs.ctAcptAnOdrStatus].Value);

            string errMsg = "";
            // 可操作件数
            int num = 0;
            // 入金伝票番号
            int depositSlipNo = 0;
            // 赤伝相殺区分
            int depositDebitNoteCd = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Reflect
                Assembly ass1 = Assembly.LoadFrom("SFUKK02911AC.dll"); // DLL名称
                Type t1 = ass1.GetType("Broadleaf.Application.Controller.KaToDepositAlwViewAcs");//namespace.classname
                object obj11 = Activator.CreateInstance(t1);// 作成対象
                MethodInfo mi1 = t1.GetMethod("SearchAllowanceOfAcceptOdrNo", new Type[] { 
                                            typeof(string),
                                            typeof(int),
                                            typeof(int),
                                            typeof(string),
                                            typeof(DateTime),
                                            typeof(DateTime),
                                            typeof(bool),
                                            typeof(string).MakeByRefType(),
                                            typeof(int).MakeByRefType(),
                                            typeof(int).MakeByRefType(),
                                            typeof(int).MakeByRefType()
                });
                object[] parm1 = new object[11] { enterpriseCode, customerCode, acptStatus, slipNo, this._lastMonthlyAddUpDay, this._lastAddUpDay, false, errMsg, num, depositSlipNo, depositDebitNoteCd };

                // 指定入金伝票番号データ取得
                int st = (int)(mi1.Invoke(obj11, parm1));
                errMsg= (string)(parm1[7]);
                num = (int)(parm1[8]);
                depositSlipNo = (int)(parm1[9]);
                depositDebitNoteCd = (int)(parm1[10]);


                // 一件の場合、該当入金データ直接削除
                if (num == 1)
                {
                    // 確認メッセージを表示
                    // DEL BY zhujw 2014/07/08 FOR RedMine#42902の⑪ デフォルトでいいえにフォーカスがない ---->>>>>
                    //DialogResult res = TMsgDisp.Show(
                    //                    emErrorLevel.ERR_LEVEL_QUESTION
                    //                    , this.Name
                    //                    , "入金引当 削除"
                    //                    , ""
                    //                    , TMsgDisp.OPE_PRINT
                    //                    , "選択中の入金伝票を削除します。" + "\r\n" + "よろしいですか？"
                    //                    , st
                    //                    , null
                    //                    , MessageBoxButtons.YesNo
                    //                    , MessageBoxDefaultButton.Button1);
                    // DEL BY zhujw 2014/07/08 FOR RedMine#42902の⑪ デフォルトでいいえにフォーカスがない ----<<<<<
                    // ADD BY zhujw 2014/07/08 FOR RedMine#42902の⑪ デフォルトでいいえにフォーカスがない ---->>>>>
                    DialogResult res = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_QUESTION
                    , this.Name
                    , "入金引当 削除"
                    , ""
                    , TMsgDisp.OPE_PRINT
                    , "選択中の入金伝票を削除します。" + "\r\n" + "よろしいですか？"
                    , st
                    , null
                    , MessageBoxButtons.YesNo
                    , MessageBoxDefaultButton.Button2);
                    // ADD BY zhujw 2014/07/08 FOR RedMine#42902の⑪ デフォルトでいいえにフォーカスがない ----<<<<<

                    if (res == DialogResult.No) return;
                    // 入金赤黒区分 通常黒の時
                    if (depositDebitNoteCd == 0)
                    {
                        // 削除処理
                        st = _depsitMainAcs.DeleteDB(this.enterpriseCode, depositSlipNo, acptStatus, out errMsg);
                    }
                    // 入金赤黒区分 赤の時
                    else
                    {
                        DepsitDataWork depsitDataWork = null;
                        DepositAlwWork[] depositAlwWorkList = null;
                        // 削除処理
                        st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, acptStatus, out depsitDataWork, out depositAlwWorkList, out errMsg);
                    }
                    // 画面データ再検索
                    if (st == 0)
                    {
                        this.btnSearch_Click(string.Empty, EventArgs.Empty);
                    }
                }
                // 複数件の場合、入金引当削除画面起動
                else if (num != 0)
                {
                    // Reflect
                    Assembly ass = Assembly.LoadFrom("SFUKK02910UC.dll"); // DLL名称
                    Type t = ass.GetType("Broadleaf.Windows.Forms.SFUKK02910UCA");//namespace.classname
                    object obj1 = Activator.CreateInstance(t);// 作成対象
                    MethodInfo mi = t.GetMethod("ViewAllowanceOfAcceptOdr");
                    object[] parm = new object[6] { enterpriseCode, customerCode, acptStatus, slipNo, this.selectSectionCode, this.claimCode };
                    bool ret = (bool)(mi.Invoke(obj1, parm));


                    if (ret)
                    {
                        this.btnSearch_Click(string.Empty, EventArgs.Empty);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  0,
                                  MessageBoxButtons.OK);
                }
            }
        }
        /// <summary>
        /// 売上月次更新履歴取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>売上月次更新日</returns>
        public DateTime GetHisTotalDayMonthlyAccRec(string sectionCode)
        {
            DateTime lastMonthlyAddUpDay;

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisMonthlyAccRec();

            int status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out lastMonthlyAddUpDay);
            if (status != 0)
            {
                lastMonthlyAddUpDay = new DateTime();
            }

            return lastMonthlyAddUpDay;
        }

        /// <summary>
        /// 売上締次処理日取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="cliamCode">請求先コード</param>
        /// <returns>売上締次処理日</returns>
        public DateTime GetTotalDayDmdC(string sectionCode, int cliamCode)
        {
            DateTime lastAddUpDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayDmdC(sectionCode, cliamCode, out lastAddUpDay);
            if (status != 0)
            {
                lastAddUpDay = new DateTime();
            }

            return lastAddUpDay;
        }
    // --- ADD zhujw K2014/07/04 RedMine#42902 入金伝票入力（売上指定型）に伝票削除機能追加 -------<<<<<
    }
}
