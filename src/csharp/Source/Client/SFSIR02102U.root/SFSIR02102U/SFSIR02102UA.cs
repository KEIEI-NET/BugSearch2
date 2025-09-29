//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払伝票入力
// プログラム概要   : 支払伝票入力の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/07/08  修正内容 : Partsman用にレイアウトの変更を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/26  修正内容 : MANTIS【13344】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/20  修正内容 : ＰＭ．ＮＳ保守依頼④,操作性/入力速度向上のために以下の改良を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/03/26  修正内容 : MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/03/26  修正内容 : MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/04/30  修正内容 : MANTIS【15200】入金内訳に0円も表示する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/05/12  修正内容 : MANTIS【15200】入金0を修正呼出し直後の保存が行えない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/05/14  修正内容 : MANTIS【15200】0円データでは、有効期間を持つ金種の日付チェックは不要
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 李占川
// 修 正 日  2010/06/08  修正内容 : 障害改良対応（７月リリース分）の対応
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 李占川
// 修 正 日  2010/06/17  修正内容 : Redmine#9949の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 修 正 日  2010/07/12  修正内容 : 成果物統合２
//                               :   ①明細部のアローキー制御修正。
//                               :   ②明細部でマイナス金額入力可能に修正。
//                               :   ③コピーペーストで不正入力した場合の制御を追加。
//                               :   ④デザイナ上の変更
//                               :   　　grdDepositKindにAfterCellActivateイベント処理を追加。
//                               :   　　edtFeeDeposit.ActiveAppearance.TextHAlign = Right に変更。
//                               :   　　edtDiscountDeposit.ActiveAppearance.TextHAlign = Right に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 修 正 日  2010/12/20  修正内容 : 支払伝票入力の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2011/02/09  修正内容 : RedMine #18847
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qijh
// 修 正 日  2011/08/24  修正内容 : RedMine #23931
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/12/15  修正内容 : Redmine#27390 拠点管理/売上日のチェック
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2012/05/10  修正内容 : 売上締次集計処理中に伝票発行不可の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI上北田 秀樹
// 修 正 日  2012/09/07  修正内容 : 仕入先総括対応の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/10/18  修正内容 : 受取手形データ更新処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/10/24  修正内容 : 画面クリア時に受取手形データフラグクリア
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/06  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/07  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田　靖之
// 修 正 日  2013/02/15  修正内容 : 登録済みの支払伝票を変更せず、手形画面で確定後に保存を実行すると締め伝票になる障害対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本　利明
// 修 正 日  2013/02/15  修正内容 : 受取手形データ検索時のキー項目を追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田　靖之
// 修 正 日  2013/02/21  修正内容 : 支払伝票削除時、手形データ紐付け解除対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田　靖之
// 修 正 日  2013/02/22  修正内容 : 登録済みの支払伝票を変更せず、手形画面で確定後に保存を実行すると締め伝票になる障害対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/03/01  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君
// 修 正 日  2013/04/02  修正内容 : 2013/05/15配信分 Redmine#35247の対応 仕入総括オプションの調査
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2013/06/20  修正内容 : 配信なし分 Redmine#35133
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉軍
// 修 正 日  2013/07/18  修正内容 : 配信なし分 Redmine#35133　既存障害№1の対応
//                                  手数料プラス・マイナスのチェック処理を削除
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
//using System.Diagnostics;  <= スレッドのクラスと競合するクラスがある為、NG
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Windows.Forms;            //ADD 2009/04/28 gejun forM1007A-手形データ追加

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 支払い入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払い入力を行う画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.05.18</br>
	/// <br></br>
	/// <br>UpdateNote	: 2006.12.22 木村 武正</br>
    /// <br>              携帯.NS用に変更</br>
    /// <br>　　　　　　　　・インセンティブ</br>
    /// <br>　　　　　　　　・赤伝処理(赤伝相殺は考えない)</br>
    /// <br>              を追加</br>
	/// <br>UpdateNote	: 2007.01.04 木村 武正</br>
    /// <br>              仕入先名・支払担当者名等を保存するように修正</br>
	/// <br>UpdateNote	: 2007.02.13 木村 武正</br>
    /// <br>           　　 ・画面スキン変更対応</br>
    /// <br>           　　 ・赤伝の削除機能を追加(入金入力と同じ機能を実装)</br>
    /// <br>UpdateNote	: 2007.05.29 木村 武正</br>
    /// <br>                ・鏡部分の支払準備処理対応</br>
    /// <br>UpdateNote	: 2007.05.30 木村 武正</br>
    /// <br>                ・クレジット会社が存在しなかったときにメッセージを表示するように修正</br>
    /// <br>UpdateNote	: 2007.06.29 木村 武正</br>
    /// <br>                ・〆データに対し赤伝の発行ができない不具合を修正</br>
    /// <br>                ・〆データの赤伝が削除できる不具合を修正</br>
    /// <br>UpdateNote	: 2007.07.30 木村 武正 保存時にクレジット会社のチェックを追加</br>
    /// <br>UpdateNote	: 2007.08.01 木村 武正 月次締めのチェックを追加</br>
    /// <br>UpdateNote	: 2007.09.05 疋田 勇人 DC.NS用にレイアウト変更</br>
    /// <br>UpdateNote	: 2008/07/08 忍 幸史 Partsman用にレイアウト変更</br>
    /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>                ・操作性/入力速度向上のために以下の改良を行う</br>
    /// <br>                ・メニューボタンの有効／無効の設定の対応</br>
    /// <br>                ・金額入力時のｶｰｿﾙ遷移が遅いのを修正</br>
    /// <br>                ・支払内訳のスクロールを無くし、入力可能な金種は全て一度に確認できるように修正</br>
    /// <br>                ・仕入先入力後に入金一覧を初期表示しないように変更</br>
    /// <br>                ・伝票登録後に支払一覧を更新しないように変更</br>
    /// <br>                ・支払先変更時等の入力済みチェックの対象を金額項目のみに変更</br>
    /// <br>Update Note : 2010/05/11 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
    /// <br>Update Note : 2010/06/17　李占川　Redmine#9949の修正</br>
    /// <br>UpdateNote  : 2010/07/02 葛軍 各種仕様変更／障害対応</br>
    /// <br>              RedMine# 10658</br>
    /// <br>UpdateNote : 2010/07/12 22018 鈴木 正臣</br>
    /// <br>               成果物統合２</br>
    /// <br>                 1.明細部のアローキー制御修正。</br>
    /// <br>                 2.明細部でマイナス金額入力可能に修正。</br>
    /// <br>                 3.コピーペーストで不正入力した場合の制御を追加。</br>
    /// <br>                 4.デザイナ上の変更</br>
    /// <br>                 　　grdDepositKindにAfterCellActivateイベント処理を追加。</br>
    /// <br>                 　　edtFeeDeposit.ActiveAppearance.TextHAlign = Right に変更。</br>
    /// <br>                 　　edtDiscountDeposit.ActiveAppearance.TextHAlign = Right に変更。</br>
    /// <br>UpdateNote  : 2011/02/09 曹文傑</br>
    /// <br>              RedMine #18847</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2012/05/10  yangmj</br>
    /// <br>            : 売上締次集計処理中に伝票発行不可の修正</br> 
    /// <br>Update Note : 2012/09/07  FSI上北田 秀樹</br>
    /// <br>            : 仕入先総括対応の追加</br>  
    /// <br></br>
  　/// <br>Update Note : 2012/12/24  王君</br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br> 
    /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>            : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// <br>Update Note : 2013/02/06  王君</br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br>
    /// <br>Update Note : 2013/02/07  王君</br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br> 
    /// <br>Update Note : 2013/02/15  脇田　靖之</br>
    /// <br>管理番号　　: 10801804-00 2013/03/13配信分</br>
    /// <br>            : 登録済みの支払伝票を変更せず、手形画面で確定後に保存を実行すると締め伝票になる障害対応</br> 
    /// <br>Update Note : 2013/02/15  宮本　利明</br>
    /// <br>管理番号　　: 10801804-00 2013/03/13配信分</br>
    /// <br>            : 受取手形データ検索時のキー項目を追加</br> 
    /// <br>Update Note : 2013/03/01  王君</br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br> 
    /// <br>Update Note : 2013/04/01  王君</br>
    /// <br>管理番号　　: 10806793-00 2013/05/15配信分</br>
    /// <br>            : Redmine#35247の対応 仕入総括オプションの調査</br> 
    /// <br>Update Note : 2013/06/20 高峰</br>
    /// <br>管理番号    : 配信なし分</br>
    /// <br>              Redmine#35133の対応</br>
    /// <br>Update Note : 2013/07/18 呉軍</br>
    /// <br>管理番号    : 配信なし分</br>
    /// <br>              Redmine#35133 既存障害№1の対応</br
	/// </remarks>
	public partial class SFSIR02102UA : Form, IDepositInputMDIChild
	{
		#region Enum
		/// <summary>
		/// 金額種別区分
		/// </summary>
		private enum MnyKindDiv
		{
            // 2007.09.05 upd start -------------------------------->>
			// 現金
			//Cash = 101,
			// 振込
			//Remittance = 102,
			// クレジット
			//Credit = 103,
			// ローン
			//Loan = 104,
			// 手形
			//Bill = 105,
			// 相殺
			//Offset = 106,
			// その他
			//Others = 109,
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
            // 2007.09.05 upd end <---------------------------------<<
		}

        // ↓ 20070213 18322 a MA.NS用に変更
		/// <summary>
		/// 画面更新モード
		/// </summary>
        private enum ScreenUpdateMode
        {
            // 新規
            New = 0,
            // 更新
            Update = 1,
            // 参照
            Reference = 2,
            // 赤伝参照
            RedReference = 3
        }
        // ↑ 20070213 18322 a
		#endregion

		#region Const
		// 画面状態保存用ファイル名
		private const string ctDisplayInfoFileNm	= "SFSIR02102U_State.dat";
		private const string XML_FILE_INITIAL_DATA	= "SFSIR02102U.dat";

        // 支払内訳グリッド列
        // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
        //private const string ctMoneyKindDiv = "MoneyKindDiv";
        //private const string ctMoneyKindCode = "MoneyKindCode";
        //private const string ctMoneyKindName = "MoneyKindName";
        //private const string ctPayment = "Payment";
        //private const string ctYear = "Year";
        //private const string ctMonth = "Month";
        //private const string ctDay = "Day";
        // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
        // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
        internal const string ctMoneyKindDiv = "MoneyKindDiv";
        internal const string ctMoneyKindCode = "MoneyKindCode";
        internal const string ctMoneyKindName = "MoneyKindName";
        internal const string ctPayment = "Payment";
        internal const string ctYear = "Year";
        internal const string ctMonth = "Month";
        internal const string ctDay = "Day";

        /// <summary>0円の支払伝票を作成するメッセージ</summary>
        private const string SAVING_ZERO_DEPOSIT_MSG = "支払金額を入力して下さい。";
        // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<

        // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        /// <summary>
        /// 送信済チェック失敗のエラーメッセージ
        /// </summary>
        private const string CHK_SEND_ERR_MSG = "送信済みのデータの為、更新できません。";
        // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

		#endregion

		#region PrivateStaticMember
		// PG名称
		private const string ctPGNM = "支払伝票入力画面";
		#endregion

		#region PrivateMember
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　アクセスクラス系
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 支払情報検索クラス
		private PaymentSlpSearch _paymentSlpSearch;
		// クレジット会社アクセスクラス
		//private CreditCmpAcs _creditCmpAcs;   // 2007.09.05 del
        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;     // 2007.09.05 add
        // 拠点アクセスクラス
        private SecInfoAcs _secInfoAcs;
        // --- ADD 2012/09/07 ---------->>>>>
        private SecInfoSetAcs _secInfoSetAcs;
        // --- ADD 2012/09/07 ----------<<<<<

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        //// 得意先情報クラス
        //private CustomerInfoAcs _customerInfoAcs;
        // 仕入先情報クラス
        private SupplierAcs _supplierAcs;
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　データクラス系
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 現在ログイン中の従業員
		private Employee _employee;

        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		// 支払設定
		private PaymentSet _paymentSet;
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        
        // 仕入先情報
		private SearchCustSuppliRet _searchCustSuppliRet;
		// 支払金額情報
		private SearchSuplierPayRet _searchSuplierPayRet;
		// 現在表示中の支払伝票
		private PaymentSlp _buffPaymentSlp;
		// 金種マスタ保持用
		private Hashtable _moneyKindHashTable;

		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　プロパティ用
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 新規ボタン
		private bool _btnNew;
		// 保存ボタン
		private bool _btnSave;
		// 削除ボタン
		private bool _btnDelete;
		// 赤伝ボタン
		private bool _btnDebitNote;
		// 領収書印刷ボタン
		private bool _receiptPrintButton;

        private bool _btnRenewal;
        //伝票呼出ボタン　　　　　　　
        private bool _btnReadSupSlip;　// ADD 王君 2012/12/24 Redmine#33741

		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　その他
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 企業コード
		private string _enterpriseCode;
        // 支払先コード
        private int _payeeCode;
        // 仕入先コード
        private int _supplierCode;
   		// 拠点コード
		private string _selectSectionCode;
        // ログイン拠点
        private string _loginSectionCode;
		// クレジット会社名称取得スレッド
		//private Thread creditCompanyNamePrcThread; // 2007.09.05 del
        //// 銀行名称取得スレッド
        //private Thread bankNamePrcThread;            // 2007.09.05 add
		// 支払情報取得スレッド
		private Thread stockAndPayPrcThread;
		// 支払情報一覧用データテーブル
		private DataTable _paymentListDataTable;

        // ↓ 20070213 18322 c MA.NS用に変更
		//// 更新モード（0:新規,1:更新）
		//private int _updateMode;

		// 更新モード
		private ScreenUpdateMode _updateMode;
        // ↑ 20070213 18322 c

		// グリッド設定制御クラス
		private GridStateController _gridStateController;

        // ↓ 20070213 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070213 18322 a

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        // 仕入在庫全体設定マスタアクセスクラス
        private StockTtlStAcs _stockTtlStAcs;

        /// <summary>支払伝票日付クリア区分</summary>
        /// <value>0:システム日付に戻す 1:入力日付そのまま</value>
        private Int32 _paySlipDateClrDiv;

        /// <summary>支払伝票日付範囲区分</summary>
        /// <value>0:制限なし 1:入力不可</value>
        private Int32 _paySlipDateAmbit;

        //ADD START 2009/04/27 gejun forM1007A-手形データ追加
        // 支払手形データアクセスクラス
        private PayDraftDataAcs _payDraftDataAcs;
        // 支払手形データ更新用
        private PayDraftData _payDraftData = null;
        // 支払手形データ削除用
        private PayDraftData _payDraftDataDel = null;
        //ADD END 2009/04/27 gejun forM1007A-手形データ追加
        // --- ADD 2012/10/18 ----------------------------------------->>>>>
        // 手形引当フラグ(true:受取)
        private bool _rcvDraftFlg = false;
        // 受取手形データアクセスクラス
        private RcvDraftDataAcs _rcvDraftDataAcs;
        // 受取手形データ更新用
        private RcvDraftData _rcvDraftData = null;
        // 受取手形データ削除用
        private RcvDraftData _rcvDraftDataDel = null;
        // --- ADD 2012/10/18 -----------------------------------------<<<<<

        // 支払設定マスタアクセスクラス
        private PaymentSetAcs _paymentSetAcs;

        // 支払内訳リスト
        private Dictionary<Int32, String> _dicPaymentSetKind;

        // 支払行番号リスト
        private Dictionary<Int32, Int32> _dicPaymentRowNo;

        // 金種情報マスタアクセスクラス
        private MoneyKindAcs _moneyKindAcs;

        // 金種情報リスト
        private Dictionary<Int32, MoneyKind> _dicMoneyKind;

        // --- ADD 2012/09/07 ---------->>>>>
        // 拠点コード(前回値)
        private string _prevSectionCode;
        private string _prevSectionName;
        // --- ADD 2012/09/07 ----------<<<<<

        // 仕入先コード(前回値)
        private Int32 _prevSupplierCode;

        //// 銀行コード(前回値)
        //private Int32 _prevBankCode;

        private EmployeeAcs _employeeAcs;

        private Dictionary<string, EmployeeDtl> _emoloyeeDtlDic;

        // 検索済みフラグ
        private bool _searchFlg;

        private bool _detailsShowFlg;         // ADD 2009/12/20

        private int _prevDoubleClickRowIndex;

        private bool _firstFlg;

        //ADD START 2009/04/27 gejun forM1007A-手形データ追加
        // マウス移動フラグ
        private bool _notMouseMoveFlg;

        // 重複チェック避けフラグ
        private bool _doubleCheckFlg;

        // 手形管理オプション成立フラグ
        private bool _draftOptSet;

        // --- ADD 2012/09/07 ---------->>>>>
        // 仕入総括オプションフラグ
        private bool _supplierSummary;
        // --- ADD 2012/09/07 ----------<<<<<

        //ADD END 2009/04/27 gejun forM1007A-手形データ追加

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        // ADD 2009/06/26 ------>>>
        /// <summary>仕入先ガイド選択フラグ</summary>
        private bool _supplierGuideSelected;
        // ADD 2009/06/26 ------<<<

        // --- ADD 2010/06/17 ---------->>>>>
        // 初回登録
        private bool _FirstStartFlag = true;
        // --- ADD 2010/06/17 ----------<<<<<
        // --- ADD 2011/02/09 ---------->>>>>
        // 前回手数料
        private long _prevFeePayment = 0;
        // 前回値引
        private long _prevDiscountPayment = 0;
        // --- ADD 2011/02/09 ----------<<<<<
        private int _savaStatus = 0; // ADD 王君 2012/12/24 Redmine#33741 
        #endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFSIR02102UA()
		{
			InitializeComponent();

            // --- ADD 2012/09/07 ---------->>>>>
            CacheOptionInfo();
            // --- ADD 2012/09/07 ----------<<<<<

			// ☆☆☆ アイコン画像の設定 ☆☆☆
			// 検索ボタン(日付指定)
			//this.btnSearch.Appearance.Image                                           // 2007.09.05 del
            //	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];  // 2007.09.05 del
			// 検索ボタン(支払番号)
			this.btnSearchPayList.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
            //// 銀行ガイド
            //this.btnBankGuid.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // 仕入先
			this.uButton_StockCustomerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // --- ADD 2012/09/07 ---------->>>>>
            // 拠点
            this.uButton_SectionGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2012/09/07 ----------<<<<<

			// ☆☆☆ グローバル変数のインスタンス作成 ☆☆☆
			// 企業コード
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 従業員
			_employee = LoginInfoAcquisition.Employee;
			// 拠点コード
			_selectSectionCode = "";
            // ログイン拠点コード
            _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            // 支払先コード
            _payeeCode = 0;
			// 支払情報検索クラス
			_paymentSlpSearch = new PaymentSlpSearch();
			// クレジット会社アクセスクラス
			//_creditCmpAcs = new CreditCmpAcs();  // 2007.09.05 del
			// ユーザーガイドアクセスクラス
            _userGuideAcs = new UserGuideAcs();    // 2007.09.05 add

            // 拠点情報アクセスクラス
            // --- DEL 2012/09/07 ---------->>>>>
            //this._secInfoAcs = new SecInfoAcs();
            // --- DEL 2012/09/07 ----------<<<<<
            // --- ADD 2012/09/07 ---------->>>>>
            if (_supplierSummary)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }
            else
            {
            this._secInfoAcs = new SecInfoAcs();
            }
            // --- ADD 2012/09/07 ----------<<<<<

            

            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //// 得意先情報アクセスクラス    
            //this._customerInfoAcs = new CustomerInfoAcs();
            // 仕入先情報アクセスクラス
            this._supplierAcs = new SupplierAcs();

            this._employeeAcs = new EmployeeAcs();

            ReadEmployee();
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

            // ↓ 20070519 18322 c エントリ共通初期処理データアクセスクラス(SFSIR02943A)
            //                     は使用しないように変更(処理をロードへ移動)
            //// 支払設定
			//_paymentSet = StokCommonInitDataAcs.PaymentSet;
			//
            //// 金種マスタ
			//CreateMoneyKindHashTable();
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            // 支払設定
			_paymentSet = new PaymentSet();;
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            // 金種
			_moneyKindHashTable = new Hashtable();
            // ↑ 20070519 18322 c

			// グリッド制御コントロールクラス
			_gridStateController = new GridStateController();

            // ↓ 20070213 18322 c MA.NS用に変更
			//// 新規モード
			//_updateMode = 0;

            // 新規モード
            _updateMode = ScreenUpdateMode.New;
            // ↑ 20070213 18322 c

            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            // 仕入先全体設定マスタアクセスクラス
            this._stockTtlStAcs = new StockTtlStAcs();

            // 支払設定マスタアクセスクラス
            this._paymentSetAcs = new PaymentSetAcs();

            // 金種情報マスタアクセスクラス
            this._moneyKindAcs = new MoneyKindAcs();

            this._dicPaymentSetKind = new Dictionary<int, string>();
            this._dicPaymentRowNo = new Dictionary<int, int>();
            this._dicMoneyKind = new Dictionary<int, MoneyKind>();
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

            this._detailsShowFlg = false;     // ADD 2009/12/20

            this._FirstStartFlag = true; // ADD 2010/06/17
        }
		#endregion

        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>修正</summary>
            Revision = 10,
            /// <summary>削除</summary>
            Delete = 11,
            /// <summary>赤伝</summary>
            RedSlip = 12,
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
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("SFSIR02101U", this);
                }
                return _operationAuthority;
            }
        }

		#region IPaymentInputMDIChild メンバ
		/// <summary>
		/// 新規ボタン
		/// </summary>
		public bool NewButton
		{
			get { return _btnNew; }
		}

		/// <summary>
		/// 保存ボタン
		/// </summary>
		public bool SaveButton
		{
			get { return _btnSave; }
		}

		/// <summary>
		/// 削除ボタン
		/// </summary>
		public bool DeleteButton
		{
			get { return _btnDelete; }
		}

		/// <summary>
		/// 赤伝ボタン
		/// </summary>
		public bool AkaButton
		{
			get { return _btnDebitNote; }
		}

		/// <summary>
		/// 領収書印刷ボタン
		/// </summary>
		public bool ReceiptPrintButton
		{
			get { return _receiptPrintButton; }
		}

        public bool RenewalButton
        {
            get { return _btnRenewal; }
        }
        // ---- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
        /// <summary>
        /// 伝票呼出ボタン
        /// </summary>
        public bool ReadSlipButton
        {
            get { return _btnReadSupSlip; }
        }
        // ---- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<

		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームのボタン有効無効制御をしたい場合に発生させます。
		///					  (IPaymentInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public event ParentToolbarDepositSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// 選択拠点取得イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public event GetDepositSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

        /// <summary>                     
        /// 計上拠点取得イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : メインにて取得した計上拠点名称をフレームに渡す</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.05</br>
        /// </remarks>
        public event HandOverDepositAddUpSecNameEventHandler HandOverAddUpSecNameEvent;

		/// <summary>
		/// モードレス表示処理（パラメータ有り）
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <remarks>
		/// <br>Note		: 通常起動時にフレームから呼び出されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

        public void RenewalProc()
        {
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            int indexKind = -1;
            int indexList = -1;
            GetGuidRowNo(out indexKind, out indexList);
            Control control = new Control();
            bool flag = false;
            if (indexKind != -1 || this.nedtFeePayment.Focused || this.nedtDiscountPayment.Focused)
            {
                if (this.nedtFeePayment.Focused)
                {
                    control = this.nedtFeePayment;
                    flag = true;
                }
                if (this.nedtDiscountPayment.Focused)
                {
                    control = this.nedtDiscountPayment;
                    flag = true;
                }
                this.tNedit_SupplierCd.Focus();
            }
            this._savaStatus = 0;
            if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                if (this._savaStatus == 3)
                {
                    if (indexKind != -1)
                    {
                        this.grdPaymentKind.Rows[indexKind].Cells[ctPayment].Activate();
                    }
                    if (indexList != -1)
                    {
                        this.gridPaymentList.Rows[indexList].Activate();
                    }
                    if (flag)
                    {
                        control.Focus();
                    }
                }
                return;
            }
            ClearScreen();
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
            ReadEmployee();
            GetStockTtlSt();
            this.PaymentSlipDateClrDiv_tComboEditor.Value = this._paySlipDateClrDiv;

            TMsgDisp.Show(this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          "最新情報を取得しました。",
                          0,
                          MessageBoxButtons.OK);
            this.tNedit_SupplierCd.Focus(); // ADD 王君 2012/12/24 Redmine#33741
        }

        /// <summary>
        /// モードレス表示処理（パラメータ、モード指定有り）
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: フレームのスライダーにて仕入先が決定された時に呼び出されます。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
        public int ShowData(int mode, object[] parameter)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // パラメータから仕入先コードを取得
                int supplierCode = TStrConv.StrToIntDef(parameter[0].ToString(), 0);

                if (supplierCode == 0)
                {
                    return (status);
                }

                //--------------------------------------------------------------------
                // 仕入先コードから仕入先マスタを取得し、支払先コードと比較
                // 仕入先コードと支払先コードに差異がある場合は支払先コードで再検索
                //--------------------------------------------------------------------
                Supplier supplier;
                status = GetSupplier(out supplier, supplierCode);
                if (status == 0)
                {
                    // 仕入先コード設定
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                    // 仕入先略称取得
                    this.lblCustNm.Text = supplier.SupplierSnm.Trim();

                    // 仕入先コード
                    this._supplierCode = supplier.SupplierCd;

                    #region DEL 2012/09/07 仕入先総括対応
                    // --- DEL 2012/09/07 ---------->>>>>
                    // 請求先コードチェック
                    //bool bStatus = CheckPayeeCode(supplier);
                    //if (!bStatus)
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                    //                      this.Name,
                    //                      "支払先に変更しました。",
                    //                      0,
                    //                      MessageBoxButtons.OK);

                    //    ChangeSupplierCode(supplier.PayeeCode);
                    //}
                    //else
                    //{
                        
                        // 計上拠点取得
                        //this._selectSectionCode = supplier.PaymentSectionCode.Trim();
                    
                        // 支払先コード
                        //this._payeeCode = supplier.PayeeCode;
                    //}

                    //this._prevSupplierCode = this._payeeCode;
                    // --- DEL 2012/09/07 ----------<<<<<
                    #endregion

                    // --- ADD 2012/09/07 ---------->>>>>
                    if (_supplierSummary)
                    {
                        // 支払先コード
                        this._payeeCode = supplier.SupplierCd;
                        // 仕入先コード
                        this._prevSupplierCode = supplier.SupplierCd;
                    }
                    else
                    {
                    // 請求先コードチェック
                    bool bStatus = CheckPayeeCode(supplier);
                    if (!bStatus)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "支払先に変更しました。",
                                          0,
                                          MessageBoxButtons.OK);

                        ChangeSupplierCode(supplier.PayeeCode);
                    }
                    else
                    {
                        // 計上拠点取得
                        this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                        // 支払先コード
                        this._payeeCode = supplier.PayeeCode;
                    }

                    this._prevSupplierCode = this._payeeCode;
                }
                    // --- ADD 2012/09/07 ----------<<<<<
                }

                //LeaveSupplierCode(this._payeeCode); // DEL　王君 2012/12/24 Redmine#33741
                LeaveSupplierCode(this._payeeCode, 0); // ADD　王君 2012/12/24 Redmine#33741

                this.datePaymentDate.Focus();

                //// 検索条件のクリア
                //this.tNedit_SupplierCd.Clear();
                //this.tNedit_SupplierSlipNo.Clear();

                //// 支払情報検索
                //status = SearchAllPaymentInfo(this._payeeCode);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            _btnNew = true;	        // 新規

                //            // 画面初期化処理
                //            InitializeDisplay(1);
                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //        {
                //            // 画面初期化処理
                //            InitializeDisplay(1);

                //            _btnNew = false;	    // 新規
                //            _btnSave = false;	    // 保存
                //            _btnDelete = false;	    // 削除
                //            _btnDebitNote = false;  // 赤伝

                //            this._searchFlg = false;

                //            // フレームのボタン設定イベント
                //            if (ParentToolbarSettingEvent != null)
                //            {
                //                ParentToolbarSettingEvent(this);
                //            }

                //            // 仕入先情報のクリア
                //            this.lblCustNm.Clear();
                //            this.lblTotalDay.Clear();
                //            this.lblPaySpan.Text = string.Empty;

                //            // 鏡項目
                //            this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;
                //            this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;
                //            this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;
                //            this.lbl_BlnceTtl.Text = string.Empty;
                //            this.lbl_StockTotalPayBalance.Text = string.Empty;
                //            this.lbl_Balance.Text = string.Empty;
                //            this.lbl_ThisTimeStockPrice.Text = string.Empty;
                //            this.lbl_TtlBlcPay.Text = string.Empty;

                //            // モードをクリア
                //            this.lblMode.Text = string.Empty;

                //            // フォーカス設定
                //            this.tNedit_SupplierCd.Focus();
                //            break;
                //        }
                //}
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return status;
        }

        /// <summary>
        /// 拠点変更後処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: フレームの拠点を変更後に処理されます。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        public void AfterSectionChange()
        {
            // 選択拠点を取得
            if (GetSelectSectionCodeEvent != null)
            {
                this._selectSectionCode = GetSelectSectionCodeEvent(this);
            }

            // 仕入在庫全体設定マスタ取得
            GetStockTtlSt();

            // 仕入先が展開されていなければ検索は行わない
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                return;
            }

            // 仕入先コード取得
            int supplierCode = this.tNedit_SupplierCd.GetInt();

            // 支払情報検索
            //int status = SearchAllPaymentInfo(supplierCode);// DEL 王君 2012/12/24 Redmine#33741
            int status = SearchAllPaymentInfo(supplierCode, 0);// ADD 王君 2012/12/24 Redmine#33741
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _btnNew		= true;	    // 新規
                _btnSave	= true;	    // 保存
                _btnDelete	= true;	    // 削除
                _btnDebitNote = true;   // 赤伝
                _btnRenewal = true;
                _btnReadSupSlip = true; // 伝票呼出  ADD 王君 2012/12/24 Redmine#33741
                this._searchFlg = true;

                // フレームのボタン設定イベント
                if (ParentToolbarSettingEvent != null)
                {
                    ParentToolbarSettingEvent(this);
                }

                // 画面初期化処理
                InitializeDisplay(1);
            }
        }

        /// <summary>
        /// 拠点変更前処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: フレームにて拠点が変更される前に処理されます。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int BeforeSectionChange()
        {
            if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                return (-1);
            }

            // 仕入先が展開されていなければ検索用入力チェックは行わない
			if (this.tNedit_SupplierCd.GetInt() != 0)
   			{
                // 支払伝票一覧検索前チェック処理
				if (!CheckBeforePaymentListSearch())
				{
					return (-1);
				}
			}

            return (0);
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// モードレス表示処理（パラメータ、モード指定有り）
		/// </summary>
		/// <param name="mode">モード</param>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームのスライダーにて仕入先が決定された時に呼び出されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public int ShowData(int mode, object[] parameter)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// パラメータから仕入先コードを取得
				int customerCode = TStrConv.StrToIntDef(parameter[0].ToString(), 0);

				if (customerCode != 0)
				{
					this.Cursor = Cursors.WaitCursor;

					// 検索条件のクリア
					this.tNedit_SupplierCd.Clear();
					this.tNedit_SupplierSlipNo.Clear();

					status = SearchAllPaymentInfo(customerCode);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							_btnNew = true;	// 新規

							// 画面初期化処理
							InitializeDisplay(1);
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						{
							// 画面初期化処理
							InitializeDisplay(1);

							_btnNew = false;	// 新規
							_btnSave = false;	// 保存
							_btnDelete = false;	// 削除
                            // ↓ 20061222 18322 a
                            _btnDebitNote = false;  // 赤伝
                            // ↑ 20061222 18322 a

							// フレームのボタン設定イベント
							if (ParentToolbarSettingEvent != null)
								ParentToolbarSettingEvent(this);

							// 仕入先情報のクリア
							this.lblSupplierCd.Clear();
                            this.lblCustNm.Clear();
							this.lblTotalDay.Clear();
							this.lblPaySpan.Text			= string.Empty;
							this.lblSuppCTaxLayMethodNm.Text= string.Empty;
							// 鑑のクリア
                            // ↓ 20070529 18322 c 鏡部分の項目を変更
							//this.lblStockTtlLMBlPay.Text		= string.Empty;
							//this.lblStockPriceTtlPayment.Text	= string.Empty;
							//this.lblStockTtlConsTaxPay.Text		= string.Empty;
							//this.lblTotalPayment.Text			= string.Empty;
							//this.lblStockTotalPayBalance.Text	= string.Empty;

                            // 2007.09.05 del start ---------------------->>
                            //this.StockTtl3TmBfBlPayl.Text = string.Empty;
                            //this.StockTtl2TmBfBlPayl.Text = string.Empty;
                            //this.ThisTimePayNrml.Text = string.Empty;
                            //this.ThisStcPrcTax.Text = string.Empty;
                            //this.ThisNetStckPricel.Text = string.Empty;
                            //this.ThisTimeTtlBlcPay.Text = string.Empty;
                            //this.StockTotalPayBalance.Text = string.Empty;  
                            // 2007.09.05 del end ------------------------<<
                            // ↑ 20070529 18322 c

                            // 2007.09.05 add start ---------------------->>
                            // 鏡項目
                            this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;
                            this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;
                            this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;
                            this.lbl_BlnceTtl.Text = string.Empty;
                            this.lbl_StockTotalPayBalance.Text = string.Empty;
                            this.lbl_Balance.Text = string.Empty;
                            this.lbl_ThisTimeStockPrice.Text = string.Empty;
                            this.lbl_TtlBlcPay.Text = string.Empty;
                            // 2007.09.05 add end ------------------------<<

							// モードをクリア
							this.lblMode.Text				= string.Empty;

							// this.btnSearch.Focus();      // 2007.09.05 del
                            this.tNedit_SupplierCd.Focus();    // 2007.09.05 add
							break;
						}
					}
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return status;
		}

		/// <summary>
		/// 拠点変更後処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームの拠点を変更後に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public void AfterSectionChange()
		{
			// 選択拠点を取得
			if (GetSelectSectionCodeEvent != null)
			{
				_selectSectionCode = GetSelectSectionCodeEvent(this);
			}

			// 仕入先が展開されていなければ検索は行わない
			if (lblSupplierCd.GetInt() == 0) return;     
            
            // 検索条件のクリア
            this.tNedit_SupplierCd.Clear();

            int status = SearchAllPaymentInfo(this.lblSupplierCd.GetInt());
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _btnNew		= true;	// 新規
                _btnSave	= true;	// 保存
                _btnDelete	= true;	// 削除
                // ↓ 20061222 18322 a
                _btnDebitNote = true;  // 赤伝
                // ↑ 20061222 18322 a

                // フレームのボタン設定イベント
                if (ParentToolbarSettingEvent != null)
                    ParentToolbarSettingEvent(this);

                // 画面初期化処理
                InitializeDisplay(1);
            }
        }

		/// <summary>
		/// 拠点変更前処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにて拠点が変更される前に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
			{
				return -1;
			}

			// 仕入先が展開されていなければ検索用入力チェックは行わない
			if (lblSupplierCd.GetInt() != 0)
   			{
				Control control;
				if (!CheckBeforePaymentListSearch(out control, false))
				{
					control.Focus();
					return -1;
				}
			}
            
            return 0;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 画面を閉じる前に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
            // -------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
            int indexKind = -1;
            int indexList = -1;
            GetGuidRowNo(out indexKind, out indexList);
            Control control = new Control();
            bool flag = false;
            if (indexKind != -1 || this.nedtFeePayment.Focused || this.nedtDiscountPayment.Focused)
            {
                if (this.nedtFeePayment.Focused)
                {
                    control = this.nedtFeePayment;
                    flag = true;
                }
                if (this.nedtDiscountPayment.Focused)
                {
                    control = this.nedtDiscountPayment;
                    flag = true;
                }
                this.tNedit_SupplierCd.Focus();
            }
            this._savaStatus = 0;
            // -------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<
			int status = SaveBeforeClose();

            // -------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
            if (this._savaStatus == 3)
            {
                if (indexKind != -1)
                {
                    this.grdPaymentKind.Rows[indexKind].Cells[ctPayment].Activate();
                }
                if (indexList != -1)
                {
                    this.gridPaymentList.Rows[indexList].Activate();
                }
                if (flag)
                {
                    control.Focus();
                }
            }
            // -------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<
			SaveStateXmlData();

			return status;
		}

		/// <summary>
		/// タブ切替前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにてタブが切り替えられる前に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{           
			int status = SaveBeforeClose();

			SaveStateXmlData();

			return status;
		}

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて削除ボタンが押下された時に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public void DeleteDepositProc()
		{
			// 削除メイン処理
			DeleteMainProc();
		}

		/// <summary>
		/// 新規処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて新規ボタンが押下された時に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public void NewDepositProc()
		{
			// 新規メイン処理
			NewMainProc();
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて保存ボタンが押下された時に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		public void SaveDepositProc()
		{
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            ctPGNM,
                                            "登録してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }
            this.tNedit_SupplierCd.Focus();// ADD 王君 2012/12/24 Redmine#33741
			// 保存メイン処理
			SaveMainProc();
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて赤伝ボタンが押下された時に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Date        : 2006.12.22 木村 武正</br>
        /// <br>　　　　　　　携帯.NS用に変更</br>
        /// <br></br>
		/// </remarks>
		public void AkaDepositProc()
		{
            // ↓ 20061222 18322 c 携帯.NS用に変更
			//// 支払伝票入力では赤伝無し

            // 支払伝票赤伝処理
            this.AkaDeposit();
            // ↑ 20061222 18322 
		}

		/// <summary>
		/// 領収書印刷処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて領収書ボタンが押下された時に処理されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		public void ReceiptPrintProc()
		{
			// 支払伝票入力では領収書印刷無し
		}

        // ----- ADD 王君 2012/12/24 Redmine#33741 --------->>>>>
        /// <summary>
        /// グリッドフォーカス情報取得処理
        /// </summary>
        /// <param name="PaymentKindRowNo">グリッドの行番号(grdPaymentKind)</param>
        /// <param name="PaymentListRowNo">グリッドの行番号(gridPaymentList)</param>
        /// <remarks>
        /// <br>Note       : グリッド行番号取得処理を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        private void GetGuidRowNo(out int paymentKindRowNo,out int paymentListRowNo)
        {
            paymentKindRowNo = -1;
            paymentListRowNo = -1;
            int payKindRowCount = this.grdPaymentKind.Rows.Count;
            int paymentListRowCount = this.gridPaymentList.Rows.Count;
            if (payKindRowCount > 0)
            {
                for (int i = 0; i < payKindRowCount; i++)
                {
                    if (this.grdPaymentKind.Rows[i].Activated)
                    {
                        paymentKindRowNo = i;
                    }
                }
            }
            if (paymentListRowCount > 0)
            {
                for (int i = 0; i < paymentListRowCount; i++)
                {
                    if (this.gridPaymentList.Rows[i].Activated)
                    {
                        paymentListRowNo = i;
                    }
                }
            }
        }
        /// <summary>
        /// 支払伝票呼出(支払伝票番号検索モード)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払伝票呼出ボタンが押下された時に処理されます。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public void ReadSlipProc()
        {
            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Left, this.tNedit_SupplierCd, null));
            #region [FocusSave]
            int indexKind = -1;
            int indexList = -1;
            GetGuidRowNo(out indexKind, out indexList);
            Control control = new Control();
            bool flag = false;
            if (indexKind != -1 || this.nedtFeePayment.Focused || this.nedtDiscountPayment.Focused)
            {
                if (this.nedtFeePayment.Focused)
                {
                    control = this.nedtFeePayment;
                    flag = true;
                }
                if (this.nedtDiscountPayment.Focused)
                {
                    control = this.nedtDiscountPayment;
                    flag = true;
                }
                this.btnSearchPayList.Focus();
            }
            #endregion
            this._savaStatus = 0;
            if (SaveBeforeCloseUG() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                if (indexKind != -1)
                {
                    this.grdPaymentKind.Rows[indexKind].Cells[ctPayment].Activate();
                }
                if (indexList != -1)
                {
                    this.gridPaymentList.Rows[indexList].Activate();
                }
                if (flag)
                {
                    control.Focus();
                }
                return;
            }
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //支払伝票情報検索条件取得処理
            SearchPaySlpInfoParameter searchPaySlpInfoParameter = new SearchPaySlpInfoParameter();

            ScreenToSearchPaySlpInfoParameterUG(ref searchPaySlpInfoParameter);

            SFSIR02102UG sFSIR02102UG = new SFSIR02102UG(this._paymentSlpSearch, searchPaySlpInfoParameter);
            sFSIR02102UG.Employee = this._employee;
            //伝票番号入力表示
            sFSIR02102UG.ShowDialog();

            if (sFSIR02102UG.DialogResult == DialogResult.OK)
            {
                this.Cursor = Cursors.Default;
                status = sFSIR02102UG.status;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.datePaymentDateStart.Clear();
                    this.datePaymentDateEnd.Clear();
                    this.tNedit_SupplierSlipNo.Clear();
                    if (_paymentListDataTable.Rows.Count > 0)
                    {
                        //仕入先コード
                        int SupplierCd = Convert.ToInt32(this._paymentListDataTable.Rows[0][PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].ToString());
                        this.tNedit_SupplierCd.Text = SupplierCd.ToString();
                     
                        //仕入先情報取得処理
                        ChangeSupplierCodeUG(SupplierCd);

                        this.datePaymentDate.Focus();

                        InitializeDisplay(1);
                        if (this.gridPaymentList.Rows.Count > 0)
                        {
                            this.gridPaymentList.Rows[0].Activate();
                        }
                        UltraGridRow ultraGridRow = this.gridPaymentList.ActiveRow;
                        if (ultraGridRow != null)
                        {
                            // 現在選択中のGridRowに対応するDataRowを取得
                            DataRow dr = _paymentListDataTable.Rows[ultraGridRow.ListIndex];
                            PaymentSlp paymentSlp;
                            int paymentSlipNo = TStrConv.StrToIntDef(dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);
                            _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
                            if (paymentSlp != null)
                            {
                                // 支払伝票画面表示
                                SetPaymentSlpToDisp(paymentSlp);
                                // 前回手数料をセット
                                this._prevFeePayment = paymentSlp.FeePayment;
                                // 前回値引をセット
                                this._prevDiscountPayment = paymentSlp.DiscountPayment;
                            }
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    //画面初期化処理
                    InitializeDisplay(1);
                    this.datePaymentDate.Focus();
                }
                else
                {
                }
            }
            else 
            {
                status = sFSIR02102UG.status;
                if (sFSIR02102UG.flag)
                {
                    if (this.tNedit_SupplierCd.GetInt() != 0)
                    {
                        this.datePaymentDate.Focus();
                        //画面初期化処理
                        InitializeDisplay(1);
                    }
                    else
                    {
                        //初期化処理
                        ClearScreen();
                        this.tNedit_SupplierCd.Focus();
                    }
                }
                else
                {
                    Supplier supplier;
                    int supCode = this.tNedit_SupplierCd.GetInt();
                    int statusSup = GetSupplier(out supplier, supCode);
                    if (statusSup != 0)
                    {
                        //初期化処理
                        ClearScreen();
                        this.tNedit_SupplierCd.Focus();
                    }
                    else
                    {
                        if (this._savaStatus == 1 || this._savaStatus == 2)
                        {
                            this.datePaymentDate.SetDateTime(DateTime.Today);
                            this.datePaymentDate.Focus();
                        }
                        else
                        {
                            if (indexKind != -1)
                            {
                                this.grdPaymentKind.Rows[indexKind].Cells[ctPayment].Activate();
                            }
                            if (this.gridPaymentList.Rows.Count > 0)
                            {
                                if (indexList != -1)
                                {
                                    this.gridPaymentList.Rows[indexList].Activate();
                                }
                            }
                            if (flag)
                            {
                                control.Focus();
                            }
                        }
                    }    
                }
            }
            this._firstFlg = true;
        }

        /// <summary>
        /// 画面切替時保存確認(支払伝票番号検索モード)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 画面切替時の画面変更チェックを行います。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// <br>Update Note : 2013/03/01  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
        private int SaveBeforeCloseUG()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if ((_updateMode == ScreenUpdateMode.Reference) || (_updateMode == ScreenUpdateMode.RedReference))
            {
                return status;
            }
            else if (_buffPaymentSlp != null)
            {
                PaymentSlp paymentSlp = SetDispToPaymentSlp();
                DateTime paymentDate = new DateTime();
                DateTime addUpADate = new DateTime();
                string outline = string.Empty;

                if (_updateMode == ScreenUpdateMode.New)
                {
                    paymentDate = _buffPaymentSlp.PaymentDate;
                    addUpADate = _buffPaymentSlp.AddUpADate;
                    outline = _buffPaymentSlp.Outline;

                    paymentSlp.PaymentDate = new DateTime();
                    paymentSlp.AddUpADate = new DateTime();
                    paymentSlp.Outline = string.Empty;

                    _buffPaymentSlp.PaymentDate = new DateTime();
                    _buffPaymentSlp.AddUpADate = new DateTime();
                    _buffPaymentSlp.Outline = string.Empty;
                }

                if (!_buffPaymentSlp.Equals(paymentSlp))
                {
                    if (_updateMode == ScreenUpdateMode.New)
                    {
                        _buffPaymentSlp.PaymentDate = paymentDate;
                        _buffPaymentSlp.AddUpADate = addUpADate;
                        _buffPaymentSlp.Outline = outline;
                    }

                    DialogResult dialogRet = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "現在、編集中のデータが存在します。" + "\r\n\r\n" + "登録してもよろしいですか？", 0, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);
                    switch (dialogRet)
                    {
                        case DialogResult.Yes:
                            {
                                // 入金伝票保存処理
                                this.SaveMainProc();
                                this._savaStatus = 1;
                                break;
                            }
                        case DialogResult.No:
                            {
                                this._payDraftData = null;
                                this._payDraftDataDel = null;
                                this._rcvDraftData = null;
                                this._rcvDraftDataDel = null;
                                ClearPaymentUG();
                                //this._buffPaymentSlp = null; // DEL 王君 2013/03/01 Redmine#33741
                                InitializeDisplay(1);// ADD 王君 2013/03/01 Redmine#33741
                                this._savaStatus = 2;
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                this._savaStatus = 3;
                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                break;
                            }
                    }
                }
                else
                {
                    this._payDraftData = null;
                    this._payDraftDataDel = null;
                    this._rcvDraftData = null;
                    this._rcvDraftDataDel = null;
                }
                if (_updateMode == ScreenUpdateMode.New && _buffPaymentSlp != null)
                {
                    _buffPaymentSlp.PaymentDate = paymentDate;
                    _buffPaymentSlp.AddUpADate = addUpADate;
                    _buffPaymentSlp.Outline = outline;
                }
            }
            else
            {
            }
            return status;
        }

        /// <summary>
        /// 仕入先チェック(支払伝票番号検索モード)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕入先チェック処理されます。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        private int GetSupplierUG(out Supplier supplier, int supplierCode)
        {
            int status;
            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
            }
            catch
            {
                status = -1;
                supplier = new Supplier();
            }

            return (status);
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 ---------<<<<<
		#endregion

		#region PrivateMethod

        private void ReadEmployee()
        {
            this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();

            try
            {
                ArrayList retList1;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList1, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (EmployeeDtl employeeDtl in retList2)
                    {
                        if (employeeDtl.LogicalDeleteCode == 0)
                        {
                            this._emoloyeeDtlDic.Add(employeeDtl.EmployeeCode.Trim(), employeeDtl);
                        }
                    }
                }
            }
            catch
            {
                this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();
            }
        }

        private int GetSubSectionCode(string employeeCode)
        {
            employeeCode = employeeCode.Trim().PadLeft(2, '0');

            if (this._emoloyeeDtlDic.ContainsKey(employeeCode))
            {
                return this._emoloyeeDtlDic[employeeCode].BelongSubSectionCode;
            }

            return 0;
        }

		#region データアクセス系処理
		/// <summary>
		/// 保存メイン処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の保存を行います。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2010/06/17 李占川 Redmine#9949の修正
        /// <br>UpdateNote  : 2010/06/30 葛軍 各種仕様変更／障害対応</br>
        /// <br>              RedMine# 10658</br>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note: 2012/05/10  yangmj</br>
        /// <br>           : 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
		private int SaveMainProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // セキュリティ対応
            if (this._updateMode != ScreenUpdateMode.New)
            {
                if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                {
                    TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "セキュリティにより伝票修正が制限されています。",
                                      0,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);

                    return 0;
                }
            }

            // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
            // 画面より登録データを取得
            PaymentSlp paymentSlp = SetDispToPaymentSlp();
            // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<

            // 支払伝票保存前チェック処理
            // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
            //if (CheckDispBeforeSave() != true)
            // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
            // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
            // 0円支払伝票の金種項目は↓で設定される
            if (CheckDispBeforeSave(paymentSlp) != true)
            // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
            {
                return (status);
            }

            // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
            //// 画面より登録データを取得
            //PaymentSlp paymentSlp = SetDispToPaymentSlp();
            // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<

            // 保存前の支払日を退避
            DateTime dtPaymentDate = this.datePaymentDate.GetDateTime();

            // 新規作成時
            if (this._updateMode == ScreenUpdateMode.New)
            {
                paymentSlp.EnterpriseCode = _enterpriseCode;                    // 企業コード
                paymentSlp.SupplierCd = this.tNedit_SupplierCd.GetInt();        // 仕入先コード
                paymentSlp.SupplierNm1 = this._searchCustSuppliRet.Name;        // 仕入先名1
                paymentSlp.SupplierNm2 = this._searchCustSuppliRet.Name2;       // 仕入先名2
                paymentSlp.SupplierSnm = this._searchCustSuppliRet.SNm;         // 仕入先略称
                #region DEL 2012/09/07 仕入先総括対応
                // --- DEL 2012/09/07 ---------->>>>>
                //paymentSlp.PayeeCode = this._searchCustSuppliRet.PayeeCode;     // 支払先コード
                //paymentSlp.PayeeName = this._searchCustSuppliRet.PName;         // 支払先名1
                //paymentSlp.PayeeName2 = this._searchCustSuppliRet.PName2;       // 支払先名2
                //paymentSlp.PayeeSnm = this._searchCustSuppliRet.PSNm;           // 支払先略称
                // --- DEL 2012/09/07 ----------<<<<<
                #endregion
                // --- ADD 2012/09/07 ---------->>>>>
                if (_supplierSummary)
                {
                    paymentSlp.PayeeCode = this.tNedit_SupplierCd.GetInt();         // 支払先コード
                    paymentSlp.PayeeName = this._searchCustSuppliRet.Name;          // 支払先名1
                    paymentSlp.PayeeName2 = this._searchCustSuppliRet.Name2;        // 支払先名2
                    paymentSlp.PayeeSnm = this._searchCustSuppliRet.SNm;            // 支払先略称
                }
                else
                {
                paymentSlp.PayeeCode = this._searchCustSuppliRet.PayeeCode;     // 支払先コード
                paymentSlp.PayeeName = this._searchCustSuppliRet.PName;         // 支払先名1
                paymentSlp.PayeeName2 = this._searchCustSuppliRet.PName2;       // 支払先名2
                paymentSlp.PayeeSnm = this._searchCustSuppliRet.PSNm;           // 支払先略称
                }
                // --- ADD 2012/09/07 ----------<<<<<
                paymentSlp.AddUpSecCode = _selectSectionCode;                   // 計上拠点コード
                paymentSlp.PaymentInpSectionCd = _employee.BelongSectionCode;   // 支払伝票入力拠点コード
            }

            paymentSlp.PaymentDate = dtPaymentDate;                             // 支払日
            paymentSlp.PrePaymentDate = this._buffPaymentSlp.PaymentDate;       // 前回支払日 // ADD 2011/12/15
            paymentSlp.AddUpADate = this.datePaymentDate.GetDateTime();         // 計上日付
            paymentSlp.UpdateSecCd = _employee.BelongSectionCode;               // 更新拠点拠点コード
            paymentSlp.PaymentAgentCode = this._employee.EmployeeCode;          // 支払担当者コード
            paymentSlp.PaymentAgentName = this._employee.Name;                  // 支払担当者名称
            paymentSlp.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);
            paymentSlp.InputDay = DateTime.Today;
            paymentSlp.PaymentInputAgentCd = this._employee.EmployeeCode;
            paymentSlp.PaymentInputAgentNm = this._employee.Name;

        try
        {
            this.Cursor = Cursors.WaitCursor;
            // TODO:登録処理

            // --- ADD 2010/06/30 ----------------------------------------->>>>>
            if (this._payDraftData == null)
            {
                int moneyKindDiv;
                int moneyKindCode;
                Int64 payment;
                DateTime dateTime;
                int rowIndex = -1;
                bool changeFlg = false;

                List<PayDraftData> retList = new List<PayDraftData>();
                if (this._draftOptSet && SearchDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this._payDraftData = (PayDraftData)retList[0];
                    // 論理削除区分=1:論理削除
                    if (this._payDraftData.LogicalDeleteCode == 1)
                    {
                        this._payDraftData = null;
                    }

                    if (this._payDraftData != null)
                    {
                        for (int index = 0; index < this.grdPaymentKind.Rows.Count; index++)
                        {
                            moneyKindDiv = (int)this.grdPaymentKind.Rows[index].Cells[ctMoneyKindDiv].Value;
                            if (moneyKindDiv == (int)MnyKindDiv.Bill)
                            {
                                rowIndex = index;
                                break;
                            }
                        }

                        if (rowIndex >= 0)
                        {
                            // ADD 2010/07/02 ----->>>
                            if (!(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) &&
                                    !((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == ""))
                            {
                            // ADD 2010/07/02 ----->>>
                                // 金種コード
                                moneyKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;
                                moneyKindCode = (Int32)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindCode].Value;
                                payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                                GetValidityTerm(rowIndex, out dateTime);
                                if (this._buffPaymentSlp != null)
                                {
                                    for (int index = 0; index < this._buffPaymentSlp.PaymentDtl.Length; index++)
                                    {
                                        if (moneyKindCode == this._buffPaymentSlp.MoneyKindCodeDtl[index])
                                        {
                                            if (this._buffPaymentSlp.PaymentDtl[index] != payment ||
                                                this._buffPaymentSlp.ValidityTermDtl[index] != dateTime)
                                                changeFlg = true;
                                            break;
                                        }
                                    }
                                }
                            }// ADD 2010/07/02 ----->>>
                            
                        }
                        if (!changeFlg)
                            this._payDraftData = null;
                    }
                }

            }
            // --- ADD 2010/06/30 ----------------------------------------->>>>>
            //MODIFY START 2009/04/27 gejun forM1007A-手形データ追加
            if (this._payDraftData == null)
            {
                status = this._paymentSlpSearch.SavePaymentData(ref paymentSlp);
            }
            else
            {
                // 支払行番号取得
                int paymentRowNo = 0;
                bool updateFlg = false;
                for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                {
                    // 金種区分取得
                    int moneyKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;
                    // 金種コード取得
                    int moneyKindCode = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindCode].Value;
                    // 金種区分が「105：手形」の場合
                    if ((moneyKindDiv == (int)MnyKindDiv.Bill))
                    {
                        if (this._dicPaymentRowNo.ContainsKey(moneyKindCode))
                        {
                            // 手形支払期日取得
                            DateTime dateTime;
                            bool bStatus = GetValidityTerm(rowIndex, out dateTime);
                            // 手形支払期日
                            if (TDateTime.IsAvailableDate(dateTime) == false)
                            {
                                updateFlg = false;
                                break;
                            }

                            if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                    (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == "")
                            {
                                updateFlg = false;
                                break;
                            }

                            paymentRowNo = this._dicPaymentRowNo[moneyKindCode];
                            // 行番号
                            this._payDraftData.PaymentRowNo = paymentRowNo;
                            // --- ADD 2010/06/30 ----------------------------------------->>>>>
                            this._payDraftData.ValidityTerm = Convert.ToInt32(dateTime.ToString("yyyyMMdd"));
                            this._payDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                            // --- ADD 2010/06/30 ----------------------------------------->>>>>

                            // 手形データがある
                            updateFlg = true;
                        }
                    }
                }

                if (updateFlg)
                    // --- UPD 2013/02/22 Y.Wakita ---------->>>>>
                    //// --- UPD 2012/10/18 ----------------------------------------->>>>>
                    ////status = this._paymentSlpSearch.SavePaymentDataWithDraft(ref paymentSlp, this._payDraftData, this._payDraftDataDel);
                    //status = this._paymentSlpSearch.SavePaymentDataWithDraftAll(ref paymentSlp, this._payDraftData, this._payDraftDataDel, this._rcvDraftData, this._rcvDraftDataDel);
                    //// --- UPD 2012/10/18 -----------------------------------------<<<<<
                    status = this._paymentSlpSearch.SavePaymentDataWithDraftAll(ref paymentSlp, this._payDraftData, this._payDraftDataDel, this._rcvDraftData, this._rcvDraftDataDel, true);
                    // --- UPD 2013/02/22 Y.Wakita ----------<<<<<
                else
                    status = this._paymentSlpSearch.SavePaymentData(ref paymentSlp);
            }
            this._payDraftData = null;
            this._payDraftDataDel = null;
            // --- ADD 2012/10/18 ----------------------------------------->>>>>
            this._rcvDraftData = null;
            this._rcvDraftDataDel = null;
            // --- ADD 2012/10/18 -----------------------------------------<<<<<
            //MODIFY END 2009/04/27 gejun forM1007A-手形データ追加

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (this._updateMode != ScreenUpdateMode.New)
                        {
                            // ログ出力
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Revision",
                                    (int)OperationCode.Revision,
                                    0,
                                    string.Format("{0}伝票、伝票番号:{1}を修正", "支払", paymentSlp.PaymentSlipNo.ToString("000000000")));
                            }
                        }

                        // 支払情報（鑑）更新スレッド
                        StockAndPayPrcThreadStart();

                        // 画面初期化処理
                        InitializeDisplay(2);

                        if (this.gridPaymentList.Rows.Count > 0)
                        {
                            // 支払一覧グリッドの全てのイベントを無効化
                            this.gridPaymentList.EventManager.AllEventsEnabled = false;
                            this.gridPaymentList.Rows[0].Activate();

                            foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                            {
                                if (ultraGridRow.Selected)
                                {
                                    ultraGridRow.Selected = false;
                                }
                            }
                            // 支払一覧グリッドの全てのイベントを有効化
                            this.gridPaymentList.EventManager.AllEventsEnabled = true;
                        }

                        //LeaveSupplierCode(this._payeeCode); // DEL 王君 2012/12/24 Redmine#33741
                        LeaveSupplierCode(this._payeeCode, 0); // ADD 王君 2012/12/24 Redmine#33741

                        if ((int)this.PaymentSlipDateClrDiv_tComboEditor.Value == 0)
                        {
                            // システム日付をセット
                            this.datePaymentDate.SetDateTime(DateTime.Today);
                        }
                        else
                        {
                            // 前回の支払日をセット
                            this.datePaymentDate.SetDateTime(dtPaymentDate);
                        }

                        SaveCompletionDialog compDialog = new SaveCompletionDialog();
                        compDialog.ShowDialog(2);

                        // 支払日にフォーカスセット
                        this.tNedit_SupplierCd.Focus();

                        this._FirstStartFlag = false; // ADD 2010/06/17
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                    {
                        TMsgDisp.Show(this, 
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                                      this.Name, 
                                      ctPGNM, 
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE, 
                                      this._paymentSlpSearch.ErrorMessage, 
                                      status, 
                                      this._paymentSlpSearch, 
                                      MessageBoxButtons.OK, 
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(企業ロック)です。" + "\r\n" +
                                      "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                      "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                      "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
                case STATUS_CHK_SEND_ERR:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      CHK_SEND_ERR_MSG,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<
                //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "対象の期間を集計処理中のため中断しました。" + "\r\n" +
                                      "計上日を変更して、再度処理を実行して下さい。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE,
                                      "処理が込み合っているため中断しました。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を実行して下さい。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<
                default:
                    {
                        TMsgDisp.Show(this, 
                                      emErrorLevel.ERR_LEVEL_STOPDISP, 
                                      this.Name, 
                                      ctPGNM, 
                                      "SaveMainProc",
                                      TMsgDisp.OPE_UPDATE, 
                                      this._paymentSlpSearch.ErrorMessage, 
                                      status, 
                                      this._paymentSlpSearch, 
                                      MessageBoxButtons.OK, 
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }
			return (status);
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 保存メイン処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の保存を行います。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// </remarks>
        private int SaveMainProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            Control control;
            if (CheckDispBeforeSave(out control))
            {
                // 画面より登録データを取得
                PaymentSlp paymentSlp = SetDispToPaymentSlp();

                // ↓ 20070213 18322 c MA.NS用に変更
                //// 新規作成時
                //if (_updateMode == 0)
                //{

                // 新規作成時
                if (_updateMode == ScreenUpdateMode.New)
                {
                    // ↑ 20070213 18322 c
                    // 企業コード
                    paymentSlp.EnterpriseCode = _enterpriseCode;

                    // 仕入先コード
                    paymentSlp.CustomerCode			= this.lblSupplierCd.GetInt();  
                    // ↓ 20070104 18322 a
                    // 仕入先名(得意先名称)
                    paymentSlp.CustomerName         = this._searchCustSuppliRet.Name;
                    paymentSlp.CustomerName2        = this._searchCustSuppliRet.Name2;
                    // ↑ 20070104 18322 a
                    paymentSlp.CustomerSnm          = this._searchCustSuppliRet.SNm;

                    paymentSlp.PayeeCode = this._searchCustSuppliRet.PayeeCode;
                    paymentSlp.PayeeName = this._searchCustSuppliRet.PName;
                    paymentSlp.PayeeName2 = this._searchCustSuppliRet.PName2;
                    paymentSlp.PayeeSnm = this._searchCustSuppliRet.PSNm;
                    // 計上拠点コード
                    paymentSlp.AddUpSecCode = _selectSectionCode;
                    // 支払伝票入力拠点コード
                    paymentSlp.PaymentInpSectionCd = _employee.BelongSectionCode;
                }
                // 支払日
                paymentSlp.PaymentDate = DateTime.Today;

                // 計上日付
                paymentSlp.AddUpADate = this.datePaymentDate.GetDateTime();

                // 保存前の支払日を退避
                DateTime dtPaymentDate = this.datePaymentDate.GetDateTime();

                // 更新拠点拠点コード
                paymentSlp.UpdateSecCd = _employee.BelongSectionCode;

                // ↓ 20070104 18322 a
                // 支払担当者コード
                paymentSlp.PaymentAgentCode = this._employee.EmployeeCode;

                // 支払担当者名称
                paymentSlp.PaymentAgentName = this._employee.Name;
                // ↑ 20070104 18322 a

                // 登録処理
                status = _paymentSlpSearch.SavePaymentData(ref paymentSlp);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 支払情報（鑑）更新スレッド
                            StockAndPayPrcThreadStart();

                            InitializeDisplay(2);

                            // 前回の支払日をセット
                            this.datePaymentDate.SetDateTime(dtPaymentDate);

                            if (this.gridPaymentList.Rows.Count > 0)
                            {
                                // 支払一覧グリッドの全てのイベントを無効化
                                this.gridPaymentList.EventManager.AllEventsEnabled = false;
                                this.gridPaymentList.Rows[0].Activate();
                                foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                                {
                                    if (ultraGridRow.Selected)
                                    {
                                        ultraGridRow.Selected = false;
                                    }
                                }
                                // 支払一覧グリッドの全てのイベントを有効化
                                this.gridPaymentList.EventManager.AllEventsEnabled = true;
                            }

                            SaveCompletionDialog compDialog = new SaveCompletionDialog();
                            compDialog.ShowDialog(2);

                            // ↓ 20070726 18322 a
                            // 画面の内容を退避
                            this._buffPaymentSlp = SetDispToPaymentSlp();
                            // ↑ 20070726 18322 a
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, ctPGNM, "SaveMainProc",
                                TMsgDisp.OPE_UPDATE, _paymentSlpSearch.ErrorMessage, status, _paymentSlpSearch, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, ctPGNM, "SaveMainProc",
                                TMsgDisp.OPE_UPDATE, _paymentSlpSearch.ErrorMessage, status, _paymentSlpSearch, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }
            else
            {
                control.Focus();
            }
            return status;
        }

        /// <summary>
		/// 削除メイン処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の削除を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private int DeleteMainProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			int paymentSlipNo = this.nedtPaymentSlipNo.GetInt();
			if (paymentSlipNo != 0)
			{
			    // 削除確認
				string denInfo = "支払番号 ： [" + paymentSlipNo.ToString("000000000") + "]";
				string message = "選択中の支払伝票を削除します。" + "\r\n\r\n" + "  " + denInfo + "\r\n\r\n" + "よろしいですか？";
				DialogResult dialogRet = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
					message , 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);

				if (dialogRet == DialogResult.Yes)
				{
					// 選択行から支払伝票情報を取得
					PaymentSlp paymentSlp;
					status = _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// 削除処理
						status = _paymentSlpSearch.DeletePaymentData(paymentSlp);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								// 支払情報（鑑）更新スレッド
								StockAndPayPrcThreadStart();

								InitializeDisplay(2);
								
								if (this.gridPaymentList.Rows.Count > 0)
								{
									// 支払一覧グリッドの全てのイベントを無効化
									this.gridPaymentList.EventManager.AllEventsEnabled = false;
									this.gridPaymentList.Rows[0].Activate();
									foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
									{
										if (ultraGridRow.Selected)
										{
											ultraGridRow.Selected = false;
										}
									}
									// 支払一覧グリッドの全てのイベントを有効化
									this.gridPaymentList.EventManager.AllEventsEnabled = true;
								}
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
							case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, ctPGNM, "DeleteMainProc",
									TMsgDisp.OPE_DELETE, _paymentSlpSearch.ErrorMessage, status, _paymentSlpSearch, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
								break;
							}
							default:
							{
								TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, ctPGNM, "DeleteMainProc",
									TMsgDisp.OPE_DELETE, _paymentSlpSearch.ErrorMessage, status, _paymentSlpSearch, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
								break;
							}
						}
					}
				}
			}
			else
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払伝票が選択されていません。", 0, MessageBoxButtons.OK);
			}

			return status;
		}

        /// <summary>
        /// 支払伝票赤伝処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 支払伝票の赤伝処理を行います。</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void AkaDeposit()
        {
            int paymentSlipNo;    // 支払伝票番号
            int paymentDate;     // 支払日付
            int status;

            // 現在の支払伝票番号を取得
            paymentSlipNo = this.nedtPaymentSlipNo.GetInt();

            // 新規支払の時
            if (paymentSlipNo == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払伝票を選択して下さい。", 0, MessageBoxButtons.OK);
                return;
            }

            // 選択行から支払伝票情報を取得
            PaymentSlp paymentSlp;
            status = _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得失敗
                return;
            }

            // 修正不可支払データ判断処理 赤伝入金の時
            if (paymentSlp.DebitNoteDiv == 1) 
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "選択されている支払伝票は既に赤伝の為、処理は行えません。", 0, MessageBoxButtons.OK);
                return;
            }

            // 赤伝画面を起動
            SFSIR02102UE frm = new SFSIR02102UE();

            // ↓ 20070213 18322 a MA.NS用に変更
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(frm);
            // ↑ 20070213 18322 a

            // 支払伝票赤伝処理
            DialogResult result = frm.ShowDialogAkaCreate( paymentSlp
                                                                              , paymentSlipNo
                                                                              , this._paymentSlpSearch.GetLastMonthlyDate()
                                                                              , out paymentDate);

            if (result == DialogResult.OK)
            {
                // 選択支払伝票再展開処理 ※編集中の時に変更前状態へ戻す
                SetPaymentSlpToDisp(paymentSlp);

                // 支払データ赤伝処理
                string message = "";
                int akaPaymentSlpNo = 0;

                int st = _paymentSlpSearch.RedCreatePaymentSlp(0,
                                                               this._employee.EnterpriseCode,
                                                               this._employee.BelongSectionCode,
                                                               this._employee.EmployeeCode,
                                                               this._employee.Name,
                                                               paymentDate,
                                                               paymentSlp,
                                                               out akaPaymentSlpNo,
                                                               out message);
                if (st == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    // エラー発生
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払伝票は他端末により更新されています。" + "\r\n\r\n" +
                        "再度支払伝票を呼び出して下さい。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    return;
                }
                else if ((st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (st == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
                {
                    // エラー発生
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払伝票は他端末により既に削除されています。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    return;
                }
                else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー発生
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "支払伝票の赤伝処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
                    return;
                }

                // 支払情報（鑑）更新スレッド
                StockAndPayPrcThreadStart();

                InitializeDisplay(2);

                if (this.gridPaymentList.Rows.Count > 0)
                {
                    // 支払一覧グリッドの全てのイベントを無効化
                    this.gridPaymentList.EventManager.AllEventsEnabled = false;
                    this.gridPaymentList.Rows[0].Activate();
                    foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                    {
                        if (ultraGridRow.Selected)
                        {
                            ultraGridRow.Selected = false;
                        }
                    }
                    // 支払一覧グリッドの全てのイベントを有効化
                    this.gridPaymentList.EventManager.AllEventsEnabled = true;
                }

                // 保存確認ダイアログ表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "赤支払伝票を次の番号で作成しました。" + "\r\n\r\n" + "  支払番号 : [" + akaPaymentSlpNo.ToString("00000000#") + "]", 0, MessageBoxButtons.OK);
            }
        }

		/// <summary>
		/// 支払情報検索処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払情報の検索を行います。</br>
		/// <br>			: この処理にて支払伝票と鑑の両方を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private int SearchAllPaymentInfo(int customerCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			// 支払情報取得用
			SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
            searchPaymentParameter.PayeeCode        = this._payeeCode;
            searchPaymentParameter.CustomerCode     = customerCode;
   			searchPaymentParameter.AddUpSecCode		= _selectSectionCode;
			searchPaymentParameter.AddUpADate		= DateTime.Today;
            searchPaymentParameter.EnterpriseCode	= _enterpriseCode;

			// 支払伝票情報取得用
			SearchPaySlpInfoParameter searchPaySlpInfoParameter = new SearchPaySlpInfoParameter();
            searchPaySlpInfoParameter.PayeeCode         = this._payeeCode;
            searchPaySlpInfoParameter.CustomerCode      = customerCode;
            searchPaySlpInfoParameter.AddUpSecCode		= _selectSectionCode;
			searchPaySlpInfoParameter.AddUpADate		= DateTime.Today;
			searchPaySlpInfoParameter.EnterpriseCode	= _enterpriseCode;
			searchPaySlpInfoParameter.PaymentSlipNo		= this.tNedit_SupplierSlipNo.GetInt();
			searchPaySlpInfoParameter.PaymentCallMonthsStart= DateTime.MinValue;
			searchPaySlpInfoParameter.PaymentCallMonthsEnd	= DateTime.MaxValue;
            
			SearchCustSuppliRet custSuppliRet;
			SearchSuplierPayRet suplierPayRet;
			status = _paymentSlpSearch.SearchPaymentInfo(searchPaymentParameter, searchPaySlpInfoParameter, out custSuppliRet, out suplierPayRet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if (custSuppliRet.PaymentDay == 0)
					{
						string message = "仕入先設定が行われていません。\r\n仕入先情報入力にて設定してください。";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, message, status, MessageBoxButtons.OK);
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					else
					{
						_searchCustSuppliRet = custSuppliRet;
						_searchSuplierPayRet = suplierPayRet;
					}

                    if (custSuppliRet.PayeeCode != custSuppliRet.CustomerCode)
                    {
                        CustomerInfo customerInfo;
                        this._paymentSlpSearch.GetCustomerInfo(out customerInfo
                                                              ,    this._enterpriseCode
                                                              ,    custSuppliRet.PayeeCode);
                        string showText = "入力された仕入先の支払先に設定されているコードが、　　\r\n"
                                        + "仕入先と異なっています。\r\n\r\n";

                        if (customerInfo != null)
                        {

                            showText += "　入力仕入先[" + custSuppliRet.CustomerCode + ":" + custSuppliRet.Name + "]\r\n"
                                      + "　支　払　先[" + customerInfo.CustomerCode + "：" + customerInfo.Name + "]\r\n\r\n";
                        }
                        showText += "仕入先と支払先が異なっていますので入力には\r\n" +
                                    "注意して下さい。"
                                  ;

                        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , showText
                                     , 0
                                     , MessageBoxButtons.OK);
                    }

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, _paymentSlpSearch.ErrorMessage, status, MessageBoxButtons.OK);
					break;
				}
				default:
				{
					// エラー発生
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "支払伝票の読込処理に失敗しました。" + "\r\n" + _paymentSlpSearch.ErrorMessage, status, MessageBoxButtons.OK);
					break;
				}
			}

			return status;
		}

		/// <summary>
		/// 支払伝票一覧再検索処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の検索を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private int ReSearchPaymentInfo()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			SearchPaySlpInfoParameter searchPaySlpInfoParameter = new SearchPaySlpInfoParameter();
            searchPaySlpInfoParameter.PayeeCode         = this._payeeCode;
            searchPaySlpInfoParameter.CustomerCode		= this.lblSupplierCd.GetInt();  
            searchPaySlpInfoParameter.AddUpSecCode		= _selectSectionCode;
			searchPaySlpInfoParameter.AddUpADate		= DateTime.Today;
			searchPaySlpInfoParameter.EnterpriseCode	= _enterpriseCode;
            searchPaySlpInfoParameter.PaymentSlipNo     = this.tNedit_SupplierSlipNo.GetInt();
			searchPaySlpInfoParameter.PaymentCallMonthsStart= this.datePaymentDateStart.GetDateTime();
			if (this.datePaymentDateEnd.GetDateTime() == DateTime.MinValue)
			{
				searchPaySlpInfoParameter.PaymentCallMonthsEnd = DateTime.MaxValue;
			}
			else
			{
				searchPaySlpInfoParameter.PaymentCallMonthsEnd = this.datePaymentDateEnd.GetDateTime();
			}

			status = _paymentSlpSearch.SearchPaySlpInfo(searchPaySlpInfoParameter, _searchCustSuppliRet.TotalDay);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, _paymentSlpSearch.ErrorMessage, 0, MessageBoxButtons.OK);
					this.datePaymentDateStart.Focus();
					break;
				}
				default:
				{
					// エラー発生
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "支払伝票の読込処理に失敗しました。" + "\r\n" + _paymentSlpSearch.ErrorMessage, status, MessageBoxButtons.OK);
					break;
				}
			}

			return status;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 削除メイン処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の削除を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private int DeleteMainProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (this.nedtPaymentSlipNo.GetInt() == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                              this.Name, 
                              "支払伝票が選択されていません。", 
                              0, 
                              MessageBoxButtons.OK);

                return (status);
            }

            // 支払伝票番号取得
            int paymentSlipNo = this.nedtPaymentSlipNo.GetInt();

            // 削除確認

            //ADD START 2009/04/28 gejun forM1007A-手形データ追加
            string message = "";
            string denInfo = "支払番号 ： [" + paymentSlipNo.ToString("000000000") + "]";
            List<PayDraftData> retList = new List<PayDraftData>();
            if (this._draftOptSet && SearchDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                message = "手形データは削除されません。" + "\r\n\r\n" + "削除してもよいですか？";
            }
            else
            {

                message = "選択中の支払伝票を削除します。" + "\r\n\r\n" + "  " + denInfo + "\r\n\r\n" + "よろしいですか？";
            }
            //ADD END 2009/04/28 gejun forM1007A-手形データ追加
            
            DialogResult dialogRet = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, 
                                                   this.Name,
                                                   message, 
                                                   0, 
                                                   MessageBoxButtons.YesNo, 
                                                   MessageBoxDefaultButton.Button2);
            if (dialogRet != DialogResult.Yes)
            {
                return (status);
            }

            // 選択行から支払伝票情報を取得
            PaymentSlp paymentSlp;
            status = this._paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
                if (retList.Count > 0)
                {
                    this._payDraftData = (PayDraftData)retList[0];
                }
                // --- ADD 2013/02/21 Y.Wakita ----------<<<<<
                // ADD 2009/05/01 コメント追記
                // 物理削除メソッドを使用しているが、リモート側で論理削除処理に変更している
                // 削除処理
                // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
                //status = this._paymentSlpSearch.DeletePaymentData(paymentSlp);
                status = this._paymentSlpSearch.DeletePaymentData(paymentSlp, this._payDraftData);
                // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                                          this.Name, 
                                          ctPGNM, 
                                          "DeleteMainProc",
                                          TMsgDisp.OPE_DELETE, 
                                          this._paymentSlpSearch.ErrorMessage, 
                                          status, 
                                          this._paymentSlpSearch, 
                                          MessageBoxButtons.OK, 
                                          MessageBoxDefaultButton.Button1);
                            return (status);
                        }
                    // 企業ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          ctPGNM,
                                          "DeleteMainProc",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(企業ロック)です。" + "\r\n" +
                                          "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._paymentSlpSearch,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return (status);
                        }
                    // 拠点ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          ctPGNM,
                                          "DeleteMainProc",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                          "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._paymentSlpSearch,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return (status);
                        }
                    // 倉庫ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          ctPGNM,
                                          "DeleteMainProc",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                          "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._paymentSlpSearch,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return (status);
                        }

                    // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          CHK_SEND_ERR_MSG,
                                          status,
                                          MessageBoxButtons.OK);
                            return (status);
                        }
                    // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, 
                                          this.Name, 
                                          ctPGNM, 
                                          "DeleteMainProc",
                                          TMsgDisp.OPE_DELETE, 
                                          this._paymentSlpSearch.ErrorMessage, 
                                          status, 
                                          this._paymentSlpSearch, 
                                          MessageBoxButtons.OK, 
                                          MessageBoxDefaultButton.Button1);
                            return (status);
                        }
                }
            }

            // ログ出力
            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
            {
                MyOpeCtrl.Logger.WriteOperationLog(
                    "Delete",
                    (int)OperationCode.Delete,
                    0,
                    string.Format("{0}伝票、伝票番号:{1}を削除", "支払", paymentSlipNo.ToString("000000000")));
            }

            // 支払情報（鑑）更新スレッド
            StockAndPayPrcThreadStart();

            // 画面初期化処理
            InitializeDisplay(2);

            if (this.gridPaymentList.Rows.Count > 0)
            {
                // 支払一覧グリッドの全てのイベントを無効化
                this.gridPaymentList.EventManager.AllEventsEnabled = false;
                this.gridPaymentList.Rows[0].Activate();
                foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                {
                    if (ultraGridRow.Selected)
                    {
                        ultraGridRow.Selected = false;
                    }
                }
                // 支払一覧グリッドの全てのイベントを有効化
                this.gridPaymentList.EventManager.AllEventsEnabled = true;
            }

            return (status);
        }

        /// <summary>
        /// 支払伝票赤伝処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 支払伝票の赤伝処理を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private void AkaDeposit()
        {
            int paymentSlipNo;      // 支払伝票番号
            int paymentDate;        // 支払日付
            int status;

            // 現在の支払伝票番号を取得
            paymentSlipNo = this.nedtPaymentSlipNo.GetInt();

            // 新規支払の時
            if (paymentSlipNo == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                              this.Name, 
                              "支払伝票を選択して下さい。", 
                              0, 
                              MessageBoxButtons.OK);
                return;
            }

            // 選択行から支払伝票情報を取得
            PaymentSlp paymentSlp;
            status = this._paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得失敗
                return;
            }

            // 修正不可支払データ判断処理 赤伝入金の時
            if (paymentSlp.DebitNoteDiv == 1)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                              this.Name, 
                              "選択されている支払伝票は既に赤伝の為、処理は行えません。", 
                              0, 
                              MessageBoxButtons.OK);
                return;
            }
            //ADD START 2009/04/28 gejun forM1007A-手形データ追加
            List<PayDraftData> retList = new List<PayDraftData>();
            if (this._draftOptSet && SearchDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                DialogResult dialogRet = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                       this.Name,
                                       "手形データの赤伝は発行されません。" + "\r\n\r\n" + "発行してもよいですか？",
                                       0,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxDefaultButton.Button2);
                if (dialogRet != DialogResult.Yes)
                {
                    return;
                }
            }
            //ADD END 2009/04/28 gejun forM1007A-手形データ追加

            // 赤伝画面を起動
            SFSIR02102UE frm = new SFSIR02102UE();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(frm);

            // 支払伝票赤伝処理
            DialogResult result = frm.ShowDialogAkaCreate(paymentSlp, 
                                                          paymentSlipNo, 
                                                          this._paymentSlpSearch.GetLastMonthlyDate(), 
                                                          out paymentDate);
            if (result != DialogResult.OK)
            {
                return;
            }

            // 選択支払伝票再展開処理 ※編集中の時に変更前状態へ戻す
            SetPaymentSlpToDisp(paymentSlp);

            // 支払データ赤伝処理
            string message = "";
            int akaPaymentSlpNo = 0;

            // 赤伝作成
            status = this._paymentSlpSearch.RedCreatePaymentSlp(0,
                                                                this._employee.EnterpriseCode,
                                                                this._employee.BelongSectionCode,
                                                                this._employee.EmployeeCode,
                                                                this._employee.Name,
                                                                paymentDate,
                                                                paymentSlp,
                                                                out akaPaymentSlpNo,
                                                                out message);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                                  this.Name, 
                                  "支払伝票は他端末により既に削除されています。" + "\r\n\r\n" + message, 
                                  status, 
                                  MessageBoxButtons.OK);
                    return;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                                  this.Name, 
                                  "支払伝票は他端末により更新されています。" + "\r\n\r\n" + "再度支払伝票を呼び出して下さい。" + "\r\n\r\n" + message, 
                                  status, 
                                  MessageBoxButtons.OK);
                    return;
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "AkaDeposit",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(企業ロック)です。" + "\r\n" +
                                      "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        return;
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "AkaDeposit",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                      "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        return;
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      ctPGNM,
                                      "AkaDeposit",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                      "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._paymentSlpSearch,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        return;
                    }
                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
                case STATUS_CHK_SEND_ERR:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      CHK_SEND_ERR_MSG,
                                      status,
                                      MessageBoxButtons.OK);
                        return;
                    }
                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<
                default:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, 
                                  this.Name, 
                                  "支払伝票の赤伝処理に失敗しました。" + "\r\n\r\n" + message, 
                                  status, 
                                  MessageBoxButtons.OK);
                    return;
            }

            // ログ出力
            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.RedSlip))
            {
                MyOpeCtrl.Logger.WriteOperationLog(
                    "RedSlip",
                    (int)OperationCode.RedSlip,
                    0,
                    string.Format("{0}伝票、伝票番号:{1}を赤伝", "支払", paymentSlp.PaymentSlipNo.ToString("000000000")));
            }

            // 支払情報（鑑）更新スレッド
            StockAndPayPrcThreadStart();

            // 画面初期化処理
            InitializeDisplay(2);

            if (this.gridPaymentList.Rows.Count > 0)
            {
                // 支払一覧グリッドの全てのイベントを無効化
                this.gridPaymentList.EventManager.AllEventsEnabled = false;
                this.gridPaymentList.Rows[0].Activate();
                foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                {
                    if (ultraGridRow.Selected)
                    {
                        ultraGridRow.Selected = false;
                    }
                }
                // 支払一覧グリッドの全てのイベントを有効化
                this.gridPaymentList.EventManager.AllEventsEnabled = true;
            }

            // 保存確認ダイアログ表示
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                          this.Name, 
                          "赤支払伝票を次の番号で作成しました。" + "\r\n\r\n" + "  支払番号 : [" + akaPaymentSlpNo.ToString("00000000#") + "]", 
                          status, 
                          MessageBoxButtons.OK);
        }

        /// <summary>
        /// 支払情報検索処理
        /// </summary>
        /// <param name="mode">検索モード(0:仕入先コードモード,1:伝票番号モード)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払情報の検索を行います。</br>
        /// <br>			: この処理にて支払伝票と鑑の両方を取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
        //private int SearchAllPaymentInfo(int supplierCode) // DEL 王君 2012/12/24 Redmine#33741
        private int SearchAllPaymentInfo(int supplierCode, int mode)// ADD 王君 2012/12/24 Redmine#33741
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 仕入先情報/仕入先金額情報検索条件取得
            SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
            //ScreenToSearchPaymentParameter(ref searchPaymentParameter); // DEL 王君 2012/12/24 Redmine#33741
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            if (mode == 0)
            {
                ScreenToSearchPaymentParameter(ref searchPaymentParameter, 0);
            }
            else
            {
                ScreenToSearchPaymentParameter(ref searchPaymentParameter, 1); 
            }
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
            //searchPaymentParameter.SupplierCode = supplierCode;
            
            // 支払伝票情報検索条件取得
            SearchPaySlpInfoParameter searchPaySlpInfoParameter = new SearchPaySlpInfoParameter();
            ScreenToSearchPaySlpInfoParameter(ref searchPaySlpInfoParameter, true);
            //searchPaySlpInfoParameter.SupplierCode = supplierCode;

            SearchCustSuppliRet custSuppliRet;
            SearchSuplierPayRet suplierPayRet;

            // 支払情報検索
            //status = this._paymentSlpSearch.SearchPaymentInfo(searchPaymentParameter, searchPaySlpInfoParameter, out custSuppliRet, out suplierPayRet);                    // DEL 2009/12/20
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            if (mode == 0)
            {
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
                status = this._paymentSlpSearch.SearchPaymentInfo(searchPaymentParameter, searchPaySlpInfoParameter, out custSuppliRet, out suplierPayRet, this._detailsShowFlg);  // ADD 2009/12/20
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            }
            else
            {
                status = this._paymentSlpSearch.SearchPaymentInfoUG(searchPaymentParameter, searchPaySlpInfoParameter, out custSuppliRet, out suplierPayRet, this._detailsShowFlg);
            }
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // --- CHG 2008/12/08 --------------------------------------------------------------------->>>>>
                        //if (custSuppliRet.PaymentDay == 0)
                        //{
                        //    string message = "仕入先設定が行われていません。\r\n仕入先情報入力にて設定してください。";
                        //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                        //                  this.Name, 
                        //                  message, 
                        //                  status, 
                        //                  MessageBoxButtons.OK);

                        //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        //}
                        //else
                        //{
                        //    this._searchCustSuppliRet = custSuppliRet;
                        //    this._searchSuplierPayRet = suplierPayRet.Clone();
                        //}

                        //if (custSuppliRet.PayeeCode != custSuppliRet.SupplierCode)
                        //{
                        //    Supplier supplier;
                        //    this._paymentSlpSearch.GetCustSuppli(out supplier, 
                        //                                         this._enterpriseCode, 
                        //                                         custSuppliRet.PayeeCode);
                            
                        //    string showText = "入力された仕入先の支払先に設定されているコードが、　　\r\n"
                        //                    + "仕入先と異なっています。\r\n\r\n";

                        //    if (_enterpriseCode != null)
                        //    {

                        //        showText += "　入力仕入先[" + custSuppliRet.SupplierCode + ":" + custSuppliRet.Name + "]\r\n"
                        //                  + "　支　払　先[" + supplier.PayeeCode + "：" + supplier.PayeeName + "]\r\n\r\n";
                        //    }

                        //    showText += "仕入先と支払先が異なっていますので入力には\r\n" +
                        //                "注意して下さい。"
                        //              ;

                        //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                        //                  this.Name, 
                        //                  showText, 
                        //                  0, 
                        //                  MessageBoxButtons.OK);
                        //}

                        this._searchCustSuppliRet = custSuppliRet.Clone();
                        this._searchSuplierPayRet = suplierPayRet.Clone();
                        // --- CHG 2008/12/08 ---------------------------------------------------------------------<<<<<

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                        //              this.Name, 
                        //              this._paymentSlpSearch.ErrorMessage, 
                        //              status, 
                        //              MessageBoxButtons.OK);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        if (custSuppliRet != null)
                        {
                            this._searchCustSuppliRet = custSuppliRet.Clone();
                        }
                        if (suplierPayRet != null)
                        {
                            this._searchSuplierPayRet = suplierPayRet.Clone();
                        }
                        break;
                    }
                default:
                    {
                        // エラー発生
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, 
                                      this.Name, 
                                      "支払伝票の読込処理に失敗しました。" + "\r\n" + this._paymentSlpSearch.ErrorMessage, 
                                      status, 
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 支払伝票一覧再検索処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の検索を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private int ReSearchPaymentInfo()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 支払伝票情報検索条件取得
            SearchPaySlpInfoParameter searchPaySlpInfoParameter = new SearchPaySlpInfoParameter();
            ScreenToSearchPaySlpInfoParameter(ref searchPaySlpInfoParameter, false);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                // 支払伝票情報検索
                status = this._paymentSlpSearch.SearchPaySlpInfo(searchPaySlpInfoParameter, this._searchCustSuppliRet.TotalDay);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                                      this.Name, 
                                      this._paymentSlpSearch.ErrorMessage, 
                                      0, 
                                      MessageBoxButtons.OK);

                        // フォーカス設定
                        this.datePaymentDateStart.Focus();
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, 
                                      this.Name, 
                                      "支払伝票の読込処理に失敗しました。" + "\r\n" + this._paymentSlpSearch.ErrorMessage, 
                                      status, 
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 支払伝票情報検索条件取得処理
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">支払伝票情報検索条件</param>
        /// <param name="allSearchFlg">全検索フラグ(True:全検索 False:再検索)</param>
        /// <remarks>
        /// <br>Note		: 支払伝票情報検索条件を取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private void ScreenToSearchPaySlpInfoParameter(ref SearchPaySlpInfoParameter searchPaySlpInfoParameter, bool allSearchFlg)
        {
            searchPaySlpInfoParameter.PayeeCode = this._payeeCode;                                      // 支払先コード
            //searchPaySlpInfoParameter.SupplierCode = this._supplierCode;                                // 仕入先コード
            // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
            searchPaySlpInfoParameter.SupplierCode = this._supplierCode;                                // 仕入先コード
            // --- ADD 2013/02/21 Y.Wakita ----------<<<<<
            searchPaySlpInfoParameter.AddUpSecCode = this._selectSectionCode;                           // 計上拠点コード
            searchPaySlpInfoParameter.AddUpADate = DateTime.Today;                                      // 計上日付
            searchPaySlpInfoParameter.EnterpriseCode = this._enterpriseCode;                            // 企業コード
            searchPaySlpInfoParameter.PaymentSlipNo = this.tNedit_SupplierSlipNo.GetInt();              // 支払伝票番号

            // 全検索
            if (allSearchFlg == true)
            {
                searchPaySlpInfoParameter.PaymentCallMonthsStart = DateTime.MinValue;
                searchPaySlpInfoParameter.PaymentCallMonthsEnd = DateTime.MaxValue;
            }
            // 再検索
            else
            {
                searchPaySlpInfoParameter.PaymentCallMonthsStart = this.datePaymentDateStart.GetDateTime();
                
                if (this.datePaymentDateEnd.GetDateTime() == DateTime.MinValue)
                {
                    searchPaySlpInfoParameter.PaymentCallMonthsEnd = DateTime.MaxValue;
                }
                else
                {
                    searchPaySlpInfoParameter.PaymentCallMonthsEnd = this.datePaymentDateEnd.GetDateTime();
                }
            }
        }
        // ---------ADD 王君 2012/12/24 Redmine#33741-------->>>>>
        /// <summary>
        /// 支払伝票情報検索条件取得処理
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">支払伝票情報検索条件</param>
        /// <remarks>
        /// <br>Note		: 支払伝票情報検索条件を取得します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        private void ScreenToSearchPaySlpInfoParameterUG(ref SearchPaySlpInfoParameter searchPaySlpInfoParameter)
        {
            searchPaySlpInfoParameter.EnterpriseCode = this._enterpriseCode;                            // 企業コード
            searchPaySlpInfoParameter.PaymentCallMonthsStart = DateTime.MinValue;
            searchPaySlpInfoParameter.PaymentCallMonthsEnd = DateTime.MaxValue;
        }
        // ---------ADD 王君 2012/12/24 Redmine#33741--------<<<<<

        /// <summary>
        /// 仕入先情報/仕入先金額情報検索条件取得処理
        /// </summary>
        /// <param name="searchPaymentParameter">仕入先情報/仕入先金額情報検索条件</param>
        /// <remarks>
        /// <br>Note		: 仕入先情報/仕入先金額情報検索条件を取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        //private void ScreenToSearchPaymentParameter(ref SearchPaymentParameter searchPaymentParameter)　// DEL 王君 2012/12/24 Redmine#33741
        private void ScreenToSearchPaymentParameter(ref SearchPaymentParameter searchPaymentParameter, int mode)// ADD 王君 2012/12/24 Redmine#33741
        {
            searchPaymentParameter.PayeeCode = this._payeeCode;
            //searchPaymentParameter.SupplierCode = this._supplierCode;
            searchPaymentParameter.AddUpSecCode = this._selectSectionCode;
            searchPaymentParameter.AddUpADate = DateTime.Today;
            searchPaymentParameter.EnterpriseCode = this._enterpriseCode;
            //----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            if (mode == 1)
            {
                searchPaymentParameter.SupplierCode = this._supplierCode;
            }
            //----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// ＸＭＬデータの読込処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2013/02/07  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private void LoadStateXmlData()
		{
			int status = _gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.gridPaymentList);
			if (status == 0)
			{
				GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this.gridPaymentList);
				if (gridStateInfo != null)
				{
					// フォントサイズ
					this.cmbFontSize.Value = (int)gridStateInfo.FontSize;
					// 列の自動調整
					this.uceAutoFitCol.Checked = gridStateInfo.AutoFit;

                    // --- ADD 王君　2013/02/07 Redmine#33741 ----- >>>>>
                    if (!this.uceAutoFitCol.Checked)
                    {
                        this.gridPaymentList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    }
                    // --- ADD 王君　2013/02/07 Redmine#33741 ----- <<<<<
				}
				else
				{
					status = 4;
				}
			}
			if (status != 0)
			{
				// フォントサイズ
				this.cmbFontSize.Value = 11;
				// 列の自動調整
				this.uceAutoFitCol.Checked = false;

                //foreach (UltraGridColumn col in this.gridPaymentList.DisplayLayout.Bands[0].Columns)
                //{
                //    col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
                //}
			}
			SFSIR02102U_DisplayInfo displayInfo;
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, ctDisplayInfoFileNm)))
			{
				displayInfo = UserSettingController.ByteDeserializeUserSetting<SFSIR02102U_DisplayInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, ctDisplayInfoFileNm));
				if (displayInfo != null)
				{
					if (displayInfo.DetailPaymentList == 1)
						this.uceShowDetail.Checked = true;
					else
						this.uceShowDetail.Checked = false;
				}
			}
		}

		/// <summary>
		/// ＸＭＬデータの保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private void SaveStateXmlData()
		{
            // ----- ADD 王君 2012/12/24 Redmine ----- >>>>>
            // グリッド設定制御クラスにグリッド情報を展開
            this._gridStateController.GetGridStateFromGrid(ref gridPaymentList);
            // ----- ADD 王君 2012/12/24 Redmine ----- <<<<<
			// グリッド情報を保存
			_gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.gridPaymentList);

			SFSIR02102U_DisplayInfo displayInfo = new SFSIR02102U_DisplayInfo();
			// 支払一覧 詳細表示
			if (this.uceShowDetail.Checked)
				displayInfo.DetailPaymentList = 1;
			else
				displayInfo.DetailPaymentList = 0;
			UserSettingController.ByteSerializeUserSetting(displayInfo, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, ctDisplayInfoFileNm));
		}
		#endregion

		#region スレッド処理
		// 2007.09.05 del start ----------------------------------------------------->>
        /*
        private void CreditCompanyNamePrcThreadStart()
		{
			// スレッドが実行中だったら処理を中断させる
			if ((creditCompanyNamePrcThread != null) && (creditCompanyNamePrcThread.ThreadState == ThreadState.Running))
			{
				creditCompanyNamePrcThread.Abort();
			}

			// GetCreditCompanyNamePrc オブジェクトの作成
			GetCreditCompanyNamePrc getCreditCompanyNamePrc = new GetCreditCompanyNamePrc(_enterpriseCode, this.tEdit_BankCode.DataText, new GetCreditCompanyNamePrc.Callback(SetCreditCompanyName));

			// Threadオブジェクトを作成する
			creditCompanyNamePrcThread = new Thread(new ThreadStart(getCreditCompanyNamePrc.GetCreditCmpNm));

			// スレッドを開始する
			creditCompanyNamePrcThread.Start();
		}
        */ 
        // 2007.09.05 del end ------------------------------------------------------<<

        // 2007.09.05 add start ---------------------------------------------------->>
        /// <summary>
        /// 銀行名称取得スレッド開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 銀行名称の取得を別スレッドにて行います。</br>
        /// <br>Programmer	: 20081 疋田　勇人</br>
        /// <br>Date		: 2007.09.05</br>
        /// </remarks>
        private void BankNamePrcThreadStart()
        {
            //// スレッドが実行中だったら処理を中断させる
            //if ((bankNamePrcThread != null) && (bankNamePrcThread.ThreadState == ThreadState.Running))
            //{
            //    bankNamePrcThread.Abort();
            //}

            //// GetBankNamePrc オブジェクトの作成
            //GetBankNamePrc getBankNamePrc = new GetBankNamePrc(_enterpriseCode, Convert.ToInt32(this.tEdit_BankCode.DataText), new GetBankNamePrc.Callback(SetBankName));

            //// Threadオブジェクトを作成する
            //bankNamePrcThread = new Thread(new ThreadStart(getBankNamePrc.GetBankName));

            //// スレッドを開始する
            //bankNamePrcThread.Start();
        }
        // 2007.09.05 add end ------------------------------------------------------<<

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払金額情報取得スレッド開始処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 支払金額情報（鑑）の取得を別スレッドにて行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void StockAndPayPrcThreadStart()
		{
			// スレッドが実行中だったら処理を中断させる
			if ((stockAndPayPrcThread != null) && (stockAndPayPrcThread.ThreadState == ThreadState.Running))
			{
				stockAndPayPrcThread.Abort();
			}

			// 仕入先情報/仕入先金額情報取得用パラメータ 作成処理
			SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
            searchPaymentParameter.PayeeCode        = this._payeeCode;
            searchPaymentParameter.CustomerCode = this.lblSupplierCd.GetInt();
            searchPaymentParameter.SupplierCode = this.tNedit_SupplierCd.GetInt();
            searchPaymentParameter.AddUpSecCode		= _selectSectionCode;
			searchPaymentParameter.AddUpADate		= DateTime.Today;
			searchPaymentParameter.EnterpriseCode	= _enterpriseCode;

			// GetCustDmdPrc オブジェクトの作成
            GetCustPaymentPrc getCustPaymentPrc = new GetCustPaymentPrc(searchPaymentParameter, new GetCustPaymentPrc.Callback(this.ThreadSetPayAndStockInfoToDisp));

			// Threadオブジェクトを作成する
			stockAndPayPrcThread = new Thread(new ThreadStart(getCustPaymentPrc.GetPaymentInfo));

			// スレッドを開始する
			stockAndPayPrcThread.Start();
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
        /// 支払金額情報取得スレッド開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払金額情報（鑑）の取得を別スレッドにて行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        private void StockAndPayPrcThreadStart()
        {
            // スレッドが実行中だったら処理を中断させる
            if ((stockAndPayPrcThread != null) && (stockAndPayPrcThread.ThreadState == ThreadState.Running))
            {
                stockAndPayPrcThread.Abort();
            }

            // 仕入先情報/仕入先金額情報取得用パラメータ 作成処理
            SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
            //ScreenToSearchPaymentParameter(ref searchPaymentParameter); // DEL 王君 2012/12/24 Redmine#33741
            ScreenToSearchPaymentParameter(ref searchPaymentParameter, 0); // ADD 王君 2012/12/24 Redmine#33741

            // GetCustDmdPrc オブジェクトの作成
            GetCustPaymentPrc getCustPaymentPrc = new GetCustPaymentPrc(searchPaymentParameter, new GetCustPaymentPrc.Callback(this.ThreadSetPayAndStockInfoToDisp));

            // Threadオブジェクトを作成する
            stockAndPayPrcThread = new Thread(new ThreadStart(getCustPaymentPrc.GetPaymentInfo));

            // スレッドを開始する
            stockAndPayPrcThread.Start();
        }

        /// <summary>
        /// 支払金額情報取得スレッド鏡情報再設定処理
        /// </summary>
        /// <param name="searchSuplierPayRet">仕入先支払情報クラス</param>
        /// <remarks>
        /// <br>Note		: 新規スレッドでの鏡情報の再設定処理を行います。</br>
        /// <br>Programmer	: 18322 木村 武正</br>
        /// <br>Date		: 2006.12.22</br>
        /// </remarks>
        private void ThreadSetPayAndStockInfoToDisp(SearchSuplierPayRet searchSuplierPayRet)
        {
            if (this.InvokeRequired)
            {
                // 現在のスレッドがワーカースレッドの場合は、Invokeメソッドを使用してメソッドをコール
                this.Invoke(new GetCustPaymentPrc.Callback(this.SetPayAndStockInfoToDisp), new object[] { searchSuplierPayRet });
            }
            else
            {
                // 現在のスレッドがUIスレッドの場合は、そのままメソッドをコール
                this.SetPayAndStockInfoToDisp(searchSuplierPayRet);
            }
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 銀行名称の取得を行います。</br>
        /// <br>Programmer	: 20081 疋田　勇人</br>
        /// <br>Date		: 2007.09.05</br>
        /// </remarks>
        private string GetBankName(int bankCode)
        {
            string bankName = "";
            try
            {
                // 銀行名取得
                string guideName = "";

                int st = this._userGuideAcs.GetGuideName(out guideName, _enterpriseCode, 46, bankCode);
                if (st == 0)
                {
                    bankName = guideName.Trim();
                }
            }
            catch (Exception)
            {
                bankName = "";
            }

            return bankName;
        }
		#endregion

		#region 画面表示系
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="initializeMode">初期化モード（0:初回起動,1:仕入先情報,2:伝票情報）</param>
		/// <remarks>
		/// <br>Note		: モードに応じて画面を初期化します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		private void InitializeDisplay(int initializeMode)
		{
            this._rcvDraftFlg = false; // 手形引当フラグクリア 2012/10/24 ADD

			// ☆☆☆ 初回起動時の処理 ☆☆☆
			if (initializeMode == 0)
			{
                //// 手形種類
                //this.cmbDraftKind.Items.Clear();
                //this.cmbDraftKind.Items.Add(0, " ");
                //this.cmbDraftKind.Items.Add(1, "約束");
                //this.cmbDraftKind.Items.Add(2, "為替");
                //// 手形区分
                //this.cmbDraftDivide.Items.Clear();
                //this.cmbDraftDivide.Items.Add(0, " ");
                //this.cmbDraftDivide.Items.Add(1, "自振");
                //this.cmbDraftDivide.Items.Add(2, "廻し");
                //// 支払検索開始日
                //this.datePaymentDateStart.SetDateTime(DateTime.Today.AddMonths(this._paymentSet.pa * -1));
				
                // 伝票日付制御コンボボックス初期値設定
                this.PaymentSlipDateClrDiv_tComboEditor.Value = this._paySlipDateClrDiv;

                // --- ADD 2012/09/07 ---------->>>>>
                if (_supplierSummary)
                {
                    // 拠点コードにログイン拠点を設定
                    this.tEdit_SectionCode.Text = _loginSectionCode;
                    SecInfoSet section;
                    if (GetSection(out section, _loginSectionCode) == 0)
                    {
                        this.lblSectionNm.Text = section.SectionGuideNm.Trim();
                    }
                    else
                    {
                        this.tEdit_SectionCode.Text = string.Empty;
                    }
                    _selectSectionCode = _loginSectionCode;
                }
                // --- ADD 2012/09/07 ----------<<<<<
			}

			// ☆☆☆ 仕入先情報が変更される場合の処理 ☆☆☆
			if (initializeMode <= 1)
			{
                //this.tNedit_SupplierCd.Clear();                     // 仕入先コード
                //this.lblCustNm.Clear();                             // 仕入先名称
                this.lblTotalDay.Clear();                           // 締・支払
                this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;    // 前前々回残高
                this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;    // 前々回残高
                this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;     // 前回残高
                this.lbl_BlnceTtl.Text = string.Empty;              // 残高合計
                this.lbl_StockTotalPayBalance.Text = string.Empty;  // 今回支払額
                this.lbl_Balance.Text = string.Empty;               // 差引残高　
                this.lbl_ThisTimeStockPrice.Text = string.Empty;    // 今回仕入額
                this.lbl_TtlBlcPay.Text = string.Empty;             // 更新後残高
                //this._prevSupplierCode = 0;

                if ((this._searchCustSuppliRet != null) && (this._searchSuplierPayRet != null))
				{
					// 仕入先情報セット処理
					SetSupplierInfoToDisp(this._searchCustSuppliRet, this._searchSuplierPayRet);
				}
			}

			// ☆☆☆ 共通の初期化処理 ☆☆☆
            this.nedtPaymentSlipNo.Clear();                                                     // 支払伝票番号
            this.labDebitNoteLinkDepoNo.Text = "";                                              // 赤伝情報
            this.datePaymentDate.SetDateTime(DateTime.Today);                                   // 支払日
            // 支払内訳グリッド
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)       
            {
                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = "";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag = 0;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value = "";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value = "";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value = "";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Activation = Activation.Disabled;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Activation = Activation.Disabled;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Activation = Activation.Disabled;
            }
            this.nedtFeePayment.Clear();                                                        // 手数料
            this.nedtDiscountPayment.Clear();                                                   // 値引き
            this.nedtPaymentTotal.Clear();                                                      // 支払合計
            //this.cmbDraftDivide.Value = 0;                                                      // 手形区分
            //this.tEdit_DraftNo.Clear();                                                         // 手形番号
            //this.cmbDraftKind.Value = 0;                                                        // 手形種類
            //this.tEdit_BankCode.Clear();                                                        // 銀行コード
            //this.teditBankName.Clear();                                                         // 銀行名称
            //this.dateDraftDrawingDate.Clear();                                                  // 振出日
            this.editOutline.Clear();                                                           // 摘要
            //this._prevBankCode = 0;

			// 初期フォーカス設定
			if (initializeMode >= 1)
			{
				// 新規モードでデータをセット（支払日）
				PaymentSlp paymentSlp	= new PaymentSlp();
                paymentSlp.PaymentDate = DateTime.Today;
                paymentSlp.AddUpADate = DateTime.Today;

                // 支払伝票画面セット処理
				SetPaymentSlpToDisp(paymentSlp);

                if ((this._searchCustSuppliRet != null) && (this._searchSuplierPayRet != null))
                {
                    // 仕入先情報セット処理
                    SetSupplierInfoToDisp(this._searchCustSuppliRet, this._searchSuplierPayRet);
                }
            }
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="initializeMode">初期化モード（0:初回起動,1:仕入先情報,2:伝票情報）</param>
        /// <remarks>
        /// <br>Note		: モードに応じて画面を初期化します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// </remarks>
        private void InitializeDisplay(int initializeMode)
        {
            // ☆☆☆ 初回起動時の処理 ☆☆☆
            if (initializeMode == 0)
            {
                // 2007.09.05 upd start --------------------------------->>
                // クレジット
                //this.cmbCreditOrLoanCd.Items.Clear();
                //this.cmbCreditOrLoanCd.Items.Add(0, " ");
                //this.cmbCreditOrLoanCd.Items.Add(1, "クレジット");
                //this.cmbCreditOrLoanCd.Items.Add(2, "ローン");
                // 手形種類
                this.cmbDraftKind.Items.Clear();
                this.cmbDraftKind.Items.Add(0, " ");
                this.cmbDraftKind.Items.Add(1, "約束");
                this.cmbDraftKind.Items.Add(2, "為替");
                // 手形区分
                this.cmbDraftDivide.Items.Clear();
                this.cmbDraftDivide.Items.Add(0, " ");
                this.cmbDraftDivide.Items.Add(1, "自振");
                this.cmbDraftDivide.Items.Add(2, "廻し");
                // 2007.09.05 upd end -----------------------------------<<

                // 支払検索開始日
                this.datePaymentDateStart.SetDateTime(DateTime.Today.AddMonths(_paymentSet.PaySlipCallMonths * -1));
                // 金種をセット
                //bool canDispCredit = false;       // 2007.09.05 del
				this.treeMoneyKind.Nodes.Clear();
				for (int ix = 1 ; ix <= 10 ; ix++)
				{
					int moneyKindCode
						= TStrConv.StrToIntDef(_paymentSet.GetType().InvokeMember("PayStMoneyKindCd" + ix, BindingFlags.GetProperty, null, _paymentSet, null).ToString(), 0);
					if (moneyKindCode != 0)
					{
						if ((_moneyKindHashTable.ContainsKey(moneyKindCode)) &&
							(this.treeMoneyKind.GetNodeByKey(moneyKindCode.ToString()) == null))
						{
							MoneyKind moneyKind = (MoneyKind)_moneyKindHashTable[moneyKindCode];
                            this.treeMoneyKind.Nodes.Add(moneyKindCode.ToString(), moneyKind.MoneyKindName);
                            // 2007.09.05 del start ----------------------------------------------------->>
                            //if (moneyKind.MoneyKindDiv == (int)MnyKindDiv.Credit || moneyKind.MoneyKindDiv == (int)MnyKindDiv.Loan)
							//{
							//	canDispCredit = true;
							//}
                            // 2007.09.05 del end -------------------------------------------------------<<
						}
					}
				}
                //this.pnlCredit.Visible = canDispCredit;   // 2007.09.05 del
            }

            // ☆☆☆ 仕入先情報が変更される場合の処理 ☆☆☆
            if (initializeMode <= 1)
            {
                // 仕入先コード
				this.lblSupplierCd.Clear();  
                // 仕入先名称
                this.lblCustNm.Clear();
                // 締・支払
                this.lblTotalDay.Clear();

                // ↓ 20070529 18322 c 鏡部分の項目を変更
                //// 前回残高
                //this.lblStockTtlLMBlPay.Text = string.Empty;
                //// 今回消費税
                //this.lblStockTtlConsTaxPay.Text = string.Empty;
                //// 今回仕入
                //this.lblStockPriceTtlPayment.Text = string.Empty;
                //// 今回支払
                //this.lblTotalPayment.Text = string.Empty;
                //// 残高
                //this.lblStockTotalPayBalance.Text = string.Empty;

                // 2007.09.05 del start ---------------------------------->>
                //this.StockTtl3TmBfBlPayl.Text = string.Empty;        // 前回支払額
                //this.StockTtl2TmBfBlPayl.Text = string.Empty;  // 今回支払
                //this.ThisTimePayNrml.Text = string.Empty;     // 今回仕入
                //this.ThisStcPrcTax.Text = string.Empty;          // 今回仕入（消費税）
                //this.ThisNetStckPricel.Text = string.Empty;  // 相殺後仕入
                //this.ThisTimeTtlBlcPay.Text = string.Empty;   // 相殺後仕入(消費税)
                //this.StockTotalPayBalance.Text = string.Empty;   // 支払金額(残高)
                // 2007.09.05 del end ------------------------------------<<
                // ↑ 20070529 18322 c

                // 2007.09.05 add start ---------------------------------->>
                this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;   // 前前々回残高
                this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;   // 前々回残高
                this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;    // 前回残高
                this.lbl_BlnceTtl.Text = string.Empty;             // 残高合計
                this.lbl_StockTotalPayBalance.Text = string.Empty; // 今回支払額
                this.lbl_Balance.Text = string.Empty;              // 差引残高　
                this.lbl_ThisTimeStockPrice.Text = string.Empty;   // 今回仕入額
                this.lbl_TtlBlcPay.Text = string.Empty;            // 更新後残高
                // 2007.09.05 add end ------------------------------------<<

                if ((_searchCustSuppliRet != null) &&
                    (_searchSuplierPayRet != null))
                {
                    // 仕入先情報セット処理
                    SetSupplierInfoToDisp(_searchCustSuppliRet, _searchSuplierPayRet);
                }
            }

            // ☆☆☆ 共通の初期化処理 ☆☆☆
            // 支払伝票番号
            this.nedtPaymentSlipNo.Clear();

            // ↓ 20061222 18322 a
            // 赤伝情報クリア
            labDebitNoteLinkDepoNo.Text = "";
            // ↑ 20061222 18322 a

            // 支払日
            this.datePaymentDate.SetDateTime(DateTime.Today);

			// 金種
			foreach (UltraTreeNode node in this.treeMoneyKind.Nodes)
			{
				if (node.Key.Equals(_paymentSet.InitSelMoneyKindCd.ToString()))
				{
					node.CheckedState = CheckState.Checked;
					break;
				}
			}
			// 支払額
			this.nedtPayment.Clear();

            // 手数料
            this.nedtFeePayment.Clear();
            // 値引き
            this.nedtDiscountPayment.Clear();
            // ↓ 20061222 18322 a
            // インセンティブ
            //this.nedtRebatePayment.Clear();  // 2007.09.05 del
            // ↑ 20061222 18322 a
            // 支払合計
            this.nedtPaymentTotal.Clear();

            // 2007.09.05 add start ------------------>>
            // 手形区分
            this.cmbDraftDivide.Value = 0;
            // 手形番号
            this.tEdit_DraftNo.Clear();
            // 手形種類
            this.cmbDraftKind.Value = 0;
            // 銀行コード
            this.tEdit_BankCode.Clear();
            // 銀行名称
            this.teditBankName.Clear();
            // 2007.09.05 add end --------------------<<
            // 振出日
            this.dateDraftDrawingDate.Clear();
			// 手形支払期日
			this.dateDraftPayTimeLimit.Clear();
            // 摘要
            this.editOutline.Clear();

            // 初期フォーカス設定
            if (initializeMode >= 1)
            {
                // 新規モードでデータをセット（支払日、金種）
                PaymentSlp paymentSlp = new PaymentSlp();
                paymentSlp.PaymentDate = DateTime.Today;

				paymentSlp.PaymentMoneyKindCode = _paymentSet.InitSelMoneyKindCd;
				MoneyKind moneyKind = (MoneyKind)_moneyKindHashTable[paymentSlp.PaymentMoneyKindCode];
				paymentSlp.PaymentMoneyKindName	= moneyKind.MoneyKindName;
				paymentSlp.PaymentMoneyKindDiv	= moneyKind.MoneyKindDiv;

                // 支払伝票画面セット処理
                SetPaymentSlpToDisp(paymentSlp);

				// 支払日付
				this.nedtPayment.Focus();
            }
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
		/// 仕入先情報画面セット処理
		/// </summary>
		/// <param name="searchCustSuppliRet">仕入先情報クラス</param>
		/// <param name="searchSuplierPayRet">仕入先支払情報クラス</param>
		/// <remarks>
		/// <br>Note		: 仕入先に関する情報を画面にセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void SetSupplierInfoToDisp(SearchCustSuppliRet searchCustSuppliRet, SearchSuplierPayRet searchSuplierPayRet)
		{
            //// 仕入先コード
            //// --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            ////this.lblSupplierCd.SetInt(searchCustSuppliRet.CustomerCode);
            //this.tNedit_SupplierCd.SetInt(searchCustSuppliRet.SupplierCode);
            //this._prevSupplierCode = searchCustSuppliRet.SupplierCode;
            //// --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            
            //// 仕入先名称
            //this.lblCustNm.Text = searchCustSuppliRet.Name;

            //// 支払先コード
            //_payeeCode = searchCustSuppliRet.PayeeCode;

            // 締・集金
			this.lblTotalDay.Text = searchCustSuppliRet.TotalDay.ToString() + "日締  " +
				searchCustSuppliRet.PaymentMonthName + searchCustSuppliRet.PaymentDay.ToString().PadLeft(2, ' ') + "日 支払";

            // 支払対象期間
            string fromText = "";
            if (searchCustSuppliRet.StartDateSpan <= 19800101)
            {
                // 初期値
                fromText = "              ";
            }
            else
            {
                fromText = TDateTime.DateTimeToString("yyyy年mm月dd日", TDateTime.LongDateToDateTime(searchCustSuppliRet.StartDateSpan));
            }
			this.lblPaySpan.Text = "( 支払対象期間 ： " + fromText + " ～ " +
                      TDateTime.DateTimeToString("yyyy年mm月dd日", TDateTime.LongDateToDateTime(searchCustSuppliRet.EndDateSpan)) + " )";

            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
			// 消費税転嫁方式
			this.lblSuppCTaxLayMethodNm.Text = "消費税転嫁方式：" + searchCustSuppliRet.SuppCTaxLayMethodNm;
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            
            // 鑑情報の表示
			SetPayAndStockInfoToDisp(searchSuplierPayRet);
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払情報画面セット処理
		/// </summary>
		/// <param name="searchSuplierPayRet">仕入先支払情報クラス</param>
		/// <remarks>
		/// <br>Note		: 支払情報（鑑）を画面にセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Date		: 2006.12.22 木村 武正</br>
        /// <br>              携帯.NS用に変更</br>
        /// <br></br>
		/// </remarks>
		private void SetPayAndStockInfoToDisp(SearchSuplierPayRet searchSuplierPayRet)
        {
            // ↓ 20061222 18322 c 携帯.NS用に変更
            #region SF
            //// 前回残高
			//this.lblStockTtlLMBlPay.Text		= searchSuplierPayRet.StockTtlLMBlPay.ToString("#,##0");
			//// 今回仕入
			//this.lblStockPriceTtlPayment.Text	= searchSuplierPayRet.StockPriceTtlPayment.ToString("#,##0");
			//// 今回消費税
			//this.lblStockTtlConsTaxPay.Text		= searchSuplierPayRet.StockTtlConsTaxPay.ToString("#,##0");
			//// 今回支払
			//this.lblTotalPayment.Text			= searchSuplierPayRet.TotalPayment.ToString("#,##0");
			//// 残高
			//this.lblStockTotalPayBalance.Text	= searchSuplierPayRet.StockTotalPayBalance.ToString("#,##0");
            #endregion

            #region 携帯.NS 支払先情報の金額表示
            // 支払準備処理の機能を使用して算出した値を設定します。
            // 2007.09.05 del start ----------------------------------------------------------->>
            // 前回支払額
            //this.StockTtl3TmBfBlPayl.Text       = searchSuplierPayRet.LastTimePayment.ToString("#,##0");
            // 今回支払
            //this.StockTtl2TmBfBlPayl.Text = searchSuplierPayRet.ThisTimePaymentMeter.ToString("#,##0");
            // 今回仕入
            //this.ThisTimePayNrml.Text    = searchSuplierPayRet.ThisNetStckPrice.ToString("#,##0");
            // 今回仕入（消費税）
            //this.ThisStcPrcTax.Text         = searchSuplierPayRet.ThisNetStcPrcTax.ToString("#,##0");
            // 相殺後仕入
            //this.ThisNetStckPricel.Text = searchSuplierPayRet.StcMtrAfOffset.ToString("#,##0");
            // 相殺後仕入(消費税)
            //this.ThisTimeTtlBlcPay.Text  = searchSuplierPayRet.StcConsTaxMtrAfOffset.ToString("#,##0");
            // 支払金額(残高)
            //this.StockTotalPayBalance.Text  = searchSuplierPayRet.StockTotalPayBalance.ToString("#,##0");
            // 2007.09.05 del end -------------------------------------------------------------<<
            #endregion
            // ↑ 20061222 18322 c

            // 2007.09.05 add start ----------------------------------------------------------->>
            #region DC.NS 支払先情報の金額表示
            // 前前々回残高
            this.lbl_StockTtl3TmBfBlPay.Text = searchSuplierPayRet.StockTtl3TmBfBlPay.ToString("#,##0");
            // 前々回残高
            this.lbl_StockTtl2TmBfBlPay.Text = searchSuplierPayRet.StockTtl2TmBfBlPay.ToString("#,##0");
            // 前回残高
            this.lbl_ThisTimeTtlBlcPay.Text = searchSuplierPayRet.ThisTimeTtlBlcPay.ToString("#,##0");
            // 残高合計
            this.lbl_BlnceTtl.Text = searchSuplierPayRet.BlnceTtl.ToString("#,##0");
            // 今回支払額
            this.lbl_StockTotalPayBalance.Text = searchSuplierPayRet.ThisTimePayNrml.ToString("#,##0");
            this._stockTotalPayBalance = searchSuplierPayRet.ThisTimePayNrml;
            // 差引残高
            this.lbl_Balance.Text = searchSuplierPayRet.Balance.ToString("#,##0");
            this._balance = searchSuplierPayRet.Balance;
            // 今回仕入額
            this.lbl_ThisTimeStockPrice.Text = searchSuplierPayRet.ThisTimeStockPrice.ToString("#,##0");
            // 更新後残高
            this.lbl_TtlBlcPay.Text = searchSuplierPayRet.ThisTimeTtlBlcPay.ToString("#,##0");
            this._ttlBlcPay = searchSuplierPayRet.ThisTimeTtlBlcPay;
            #endregion
            // 2007.09.05 add end -------------------------------------------------------------<<

        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払情報画面セット処理
        /// </summary>
        /// <param name="searchSuplierPayRet">仕入先支払情報クラス</param>
        /// <remarks>
        /// <br>Note		: 支払情報（鑑）を画面にセットします。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br></br>
        /// </remarks>
        private void SetPayAndStockInfoToDisp(SearchSuplierPayRet searchSuplierPayRet)
        {
            // 前前々回残高
            this.lbl_StockTtl3TmBfBlPay.Text = searchSuplierPayRet.StockTtl3TmBfBlPay.ToString("#,##0");
            // 前々回残高
            this.lbl_StockTtl2TmBfBlPay.Text = searchSuplierPayRet.StockTtl2TmBfBlPay.ToString("#,##0");
            // 前回残高
            this.lbl_ThisTimeTtlBlcPay.Text = searchSuplierPayRet.LastTimePayment.ToString("#,##0");
            // 残高合計
            Int64 blnceTtl = searchSuplierPayRet.StockTtl3TmBfBlPay + searchSuplierPayRet.StockTtl2TmBfBlPay + searchSuplierPayRet.LastTimePayment;
            this.lbl_BlnceTtl.Text = blnceTtl.ToString("#,##0");
            // 今回支払額
            this.lbl_StockTotalPayBalance.Text = searchSuplierPayRet.ThisTimePayNrml.ToString("#,##0");
            // 差引残高
            Int64 balance = blnceTtl - searchSuplierPayRet.ThisTimePayNrml;
            this.lbl_Balance.Text = balance.ToString("#,##0");
            // 今回仕入額
            Int64 thisTimeStockPrice = searchSuplierPayRet.OfsThisTimeStock + searchSuplierPayRet.OfsThisStockTax;
            this.lbl_ThisTimeStockPrice.Text = thisTimeStockPrice.ToString("#,##0");
            // 更新後残高
            Int64 ttlBlcPay = balance + thisTimeStockPrice;
            this.lbl_TtlBlcPay.Text = ttlBlcPay.ToString("#,##0");
        }

        /// <summary>
        /// 支払伝票画面表示処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <remarks>
        /// <br>Note		: 支払伝票マスタの情報を画面に展開します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>UpdateNote  : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>              金額入力時のｶｰｿﾙ遷移が遅いのを修正</br>
        /// </remarks>
        private void SetPaymentSlpToDisp(PaymentSlp paymentSlp)
        {
            // バッファに確保
            this._buffPaymentSlp = paymentSlp.Clone();

            // 支払伝票一覧情報をクリア
            this.lblListInfo.Text = string.Empty;

            // 支払伝票番号
            if (paymentSlp.PaymentSlipNo != 0)
            {
                switch (paymentSlp.DebitNoteDiv)
                {
                    case 1:
                        //=======================
                        // 赤伝の時
                        //=======================
                        // 赤参照モード
                        this.lblMode.Text = "[ 参照 ]";
                        this._updateMode = ScreenUpdateMode.RedReference;
                        this.lblListInfo.Text = "赤支払伝票の為、更新 は出来ません。";
                        break;
                    case 2:
                        //=======================
                        // 相殺済み黒伝の時
                        //=======================
                        // 参照モード
                        this.lblMode.Text = "[ 参照 ]";
                        this._updateMode = ScreenUpdateMode.Reference;
                        this.lblListInfo.Text = "相殺済み伝票の為、更新 / 削除 は出来ません。";
                        break;
                    default:
                        //=======================
                        // 通常伝票の時
                        //=======================
                        // 通常支払
                        if (paymentSlp.AutoPayment == 0)
                        {
                            if ((TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= this._paymentSlpSearch.GetCAddUpUpDate()) ||
                                (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= this._paymentSlpSearch.GetLastMonthlyDate()))
                            {
                                // 参照モード
                                this.lblMode.Text = "[ 参照 ]";
                                this._updateMode = ScreenUpdateMode.Reference;

                                this.lblListInfo.Text = "締済支払伝票の為、 更新 / 削除 は出来ません。";
                            }
                            else
                            {
                                // 更新モード
                                this.lblMode.Text = "[ 更新 ]";
                                this._updateMode = ScreenUpdateMode.Update;
                            }
                        }
                        // 自動支払
                        else  
                        {
                            // 参照モード
                            this.lblMode.Text = "[ 参照 ]";
                            this._updateMode = ScreenUpdateMode.Reference;
                            this.lblListInfo.Text = "自動支払伝票の為、更新 / 削除 は出来ません。";
                        }
                        break;
                }

                switch (paymentSlp.DebitNoteDiv)
                {
                    case 1:
                        // 赤伝
                        nedtPaymentSlipNo.Appearance.ForeColor = Color.Red;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = Color.DarkOrchid;
                        labDebitNoteLinkDepoNo.Text = "[連結(黒)：" + paymentSlp.DebitNoteLinkPayNo.ToString("000000000") + "]";
                        break;
                    case 2:
                        // 相殺済み黒伝
                        nedtPaymentSlipNo.Appearance.ForeColor = Color.DarkOrchid;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = Color.Red;
                        labDebitNoteLinkDepoNo.Text = "[連結(赤)：" + paymentSlp.DebitNoteLinkPayNo.ToString("000000000") + "]";
                        break;
                    default:
                        nedtPaymentSlipNo.Appearance.ForeColor = Color.Black;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = Color.Black;
                        labDebitNoteLinkDepoNo.Text = "";
                        break;
                }

                // 金種
                ClearPaymentKindGrid();

                for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                {
                    for (int index = 0; index < paymentSlp.PaymentDtl.Length; index++)
                    {
                        if ((int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindCode].Value == paymentSlp.MoneyKindCodeDtl[index])
                        {
                            if (paymentSlp.PaymentDtl[index] == 0)
                            {
                                // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>
                                //this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = DBNull.Value;
                                // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<
                                // ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>
                                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = 0;
                                // ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<
                                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag = 0;
                            }
                            else
                            {
                                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = paymentSlp.PaymentDtl[index].ToString("###,##0");
                                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag = paymentSlp.PaymentDtl[index];
                            }

                            if ((paymentSlp.MoneyKindDivDtl[index] == 105) || (paymentSlp.MoneyKindDivDtl[index] == 107))
                            {
                                SetValidityTerm(paymentSlp.ValidityTermDtl[index], rowIndex);
                                if (paymentSlp.ValidityTermDtl[index] == DateTime.MinValue)
                                {
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Activation = Activation.Disabled;
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Activation = Activation.Disabled;
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Activation = Activation.Disabled;
                                }
                                else
                                {
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Activation = Activation.AllowEdit;
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Activation = Activation.AllowEdit;
                                    this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Activation = Activation.AllowEdit;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // 新規モード
                this.lblMode.Text = "[ 新規 ]";
                this._updateMode = ScreenUpdateMode.New;
                this.lblListInfo.Text = "";
            }

            this.nedtPaymentSlipNo.SetInt(paymentSlp.PaymentSlipNo);
            if (paymentSlp.AddUpADate != DateTime.MinValue)
            {
                this.datePaymentDate.SetDateTime(paymentSlp.AddUpADate);
            }
            // 手数料
            this.nedtFeePayment.SetValue(paymentSlp.FeePayment);
            // 値引
            this.nedtDiscountPayment.SetValue(paymentSlp.DiscountPayment);
            // 総額
            //this.nedtPaymentTotal.SetValue(paymentSlp.PaymentTotal); // DEL 2009/12/20
            this.nedtPaymentTotal.DataText = paymentSlp.PaymentTotal.ToString(); // ADD 2009/12/20

            // 摘要
            this.editOutline.Text = paymentSlp.Outline;

            // 入力項目のEnable制御処理
            ChangeInputCtlOnMode(paymentSlp);
        }

        private void SetValidityTerm(DateTime targetDate, int rowIndex)
        {
            if (targetDate == DateTime.MinValue)
            {
                this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value = DBNull.Value;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value = DBNull.Value;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value = DBNull.Value;
            }
            else
            {
                this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value = targetDate.Year.ToString() + "年";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value = targetDate.Month.ToString() + "月";
                this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value = targetDate.Day.ToString() + "日";
            }
        }

        /// <summary>
        /// 支払金種グリッド初期化処理
        /// </summary>
        private void ClearPaymentKindGrid()
        {
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = DBNull.Value;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag = 0;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value = DBNull.Value;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value = DBNull.Value;
                this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value = DBNull.Value;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <remarks>
        /// <br>Note		: 画面コントロールの入力制御を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・メニューボタンの有効／無効の設定の対応</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        private void ChangeInputCtlOnMode(PaymentSlp paymentSlp)
        {
            // ☆☆☆ 以下入力制御（参照モード対応） ☆☆☆
            if ((this._updateMode == ScreenUpdateMode.Reference) ||
                (this._updateMode == ScreenUpdateMode.RedReference))
            {
                this.datePaymentDate.Enabled = false;       // 支払日
                ChangeGridEnabled(Activation.Disabled);
                this.nedtFeePayment.Enabled = false;        // 手数料
                this.nedtDiscountPayment.Enabled = false;   // 値引額
                //this.dateDraftDrawingDate.Enabled = false;  // 振出日
                this.editOutline.Enabled = false;           // 摘要
                //this.cmbDraftKind.Enabled = false;          // 手形種類
                //this.cmbDraftDivide.Enabled = false;        // 手形区分
                //this.tEdit_BankCode.Enabled = false;        // 銀行コード
                //this.btnBankGuid.Enabled = false;           // 銀行ガイド 
                //this.tEdit_DraftNo.Enabled = false;         // 手形番号

                // フレームのボタン設定
                bool btnDel = false;
                if (this._updateMode == ScreenUpdateMode.RedReference)
                {
                    // 赤伝参照の時、削除ボタンは押下可
                    if (paymentSlp.CAddUpUpdDate < TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate))
                    {
                        // 前回締め日以降のデータの場合
                        btnDel = true;
                    }
                }

                this._btnSave = true;	                    // 保存
                this._btnRenewal = true;
                this._btnDelete = btnDel;                   // 削除

                if (paymentSlp.AutoPayment != 1)            // 自動支払以外
                {
                    this._btnDebitNote = true;              // 赤伝
                }
                else
                {
                    this._btnDebitNote = false;             // 赤伝
                }
                this._btnReadSupSlip = true;                // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                this._searchFlg = false;
            }
            else
            {
                this.datePaymentDate.Enabled = true;      // 支払日
                ChangeGridEnabled(Activation.AllowEdit);
                this.nedtFeePayment.Enabled = true;       // 手数料
                this.nedtDiscountPayment.Enabled = true;  // 値引額

                //bool divFlg = false;
                //for (int index = 0; index < paymentSlp.MoneyKindDivDtl.Length; index++)
                //{
                //    if (paymentSlp.MoneyKindDivDtl[index] == 105)
                //    {
                //        divFlg = true;
                //        break;
                //    }
                //}
                //if (divFlg == true)
                //{
                //    this.dateDraftDrawingDate.Enabled = true;  // 振出日
                //    this.cmbDraftKind.Enabled = true;          // 手形種類
                //    this.cmbDraftDivide.Enabled = true;        // 手形区分
                //    this.tEdit_BankCode.Enabled = true;        // 銀行コード
                //    this.btnBankGuid.Enabled = true;           // 銀行ガイド 
                //    this.tEdit_DraftNo.Enabled = true;         // 手形番号
                //}
                //else
                //{
                //    this.dateDraftDrawingDate.Enabled = false;  // 振出日
                //    this.cmbDraftKind.Enabled = false;          // 手形種類
                //    this.cmbDraftDivide.Enabled = false;        // 手形区分
                //    this.tEdit_BankCode.Enabled = false;        // 銀行コード
                //    this.btnBankGuid.Enabled = false;           // 銀行ガイド 
                //    this.tEdit_DraftNo.Enabled = false;         // 手形番号
                //}

                // 入力不可制御
                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                switch (paymentSlp.PaymentMoneyKindDiv)
                {
                    case (int)MnyKindDiv.Bill:
                    case (int)MnyKindDiv.ACheck:
                        {
                            this.cmbDraftKind.ReadOnly = false;           // 手形種類
                            this.cmbDraftDivide.ReadOnly = false;         // 手形区分
                            this.tEdit_DraftNo.Enabled = true;               // 手形番号
                            this.tEdit_BankCode.ReadOnly = false;           // 銀行コード
                            this.btnBankGuid.Enabled = true;              // 銀行ガイド
                            this.dateDraftDrawingDate.ReadOnly = false;   // 振出日
                            break;
                        }
                    case (int)MnyKindDiv.Check:
                        {
                            this.tEdit_BankCode.ReadOnly = false;           // 銀行コード
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;               // 銀行ガイド
                            this.dateDraftDrawingDate.ReadOnly	= false;   // 振出日
                            break;
                        }
                    case (int)MnyKindDiv.Remittance:
                        {
                            this.tEdit_BankCode.ReadOnly = false;           // 銀行コード
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;                // 銀行ガイド
                            break;
                        }
                    default:
                        {
                            this.cmbDraftKind.ReadOnly = true;              // 手形種類
                            this.cmbDraftDivide.ReadOnly = true;            // 手形区分
                            this.tEdit_DraftNo.Enabled = false;             // 手形番号
                            this.tEdit_BankCode.ReadOnly = true;            // 銀行コード
                            this.btnBankGuid.Enabled = false;               // 銀行ガイド 
                            this.dateDraftDrawingDate.ReadOnly = true;      // 振出日
                            break;
                        }
                }
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/

                this.editOutline.Enabled = true;                          // 摘要

                // フレームのボタン設定
                // DELL 2009/12/20 ----->>>>
                //this._btnSave = true;	    // 保存
                //this._btnRenewal = true;
                //this._btnDelete = true;	    // 削除
                //this._btnDebitNote = true;  // 赤伝
                // DELL 009/12/20 -----<<<<

                // ADD 2009/12/20 ----->>>>
                if (this.tNedit_SupplierCd.GetInt() != 0 && this.gridPaymentList.Rows.Count > 0)
                {
                    this._btnNew = true;
                    this._btnSave = true;	    // 保存
                    this._btnDelete = true;	    // 削除
                    this._btnDebitNote = true;  // 赤伝
                    this._btnReadSupSlip = true; // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                }
                else if (this.tNedit_SupplierCd.GetInt() != 0 && this.gridPaymentList.Rows.Count == 0)
                {
                    this._btnNew = true;
                    this._btnSave = true;	    // 保存
                    this._btnDelete = false;	    // 削除
                    this._btnDebitNote = false;  // 赤伝
                    this._btnReadSupSlip = true; // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                }
                else
                {
                    this._btnNew = false;
                    this._btnSave = false;	    // 保存
                    this._btnDelete = false;	    // 削除
                    this._btnDebitNote = false;  // 赤伝
                    this._btnReadSupSlip = true; // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                }
                // ADD 2009/12/20 -----<<<<

                this._searchFlg = true;
            }

            if (ParentToolbarSettingEvent != null)
            {
                ParentToolbarSettingEvent(this);
            }
        }

        /// <summary>
        /// 画面表示情報取得処理
        /// </summary>
        /// <returns>支払伝票マスタ</returns>
        /// <remarks>
        /// <br>Note		: 画面の情報を元に支払伝票マスタを作成します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>UpdateNote  : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>              金額入力時のｶｰｿﾙ遷移が遅いのを修正</br>
        /// </remarks>
        private PaymentSlp SetDispToPaymentSlp()
        {
            PaymentSlp paymentSlp = this._buffPaymentSlp.Clone();

            // 支払伝票番号
            paymentSlp.PaymentSlipNo = this.nedtPaymentSlipNo.GetInt();
            // 計上日付
            paymentSlp.AddUpADate = this.datePaymentDate.GetDateTime();
			// TODO:金種
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                paymentSlp.PaymentRowNoDtl[rowIndex] = 0;
                paymentSlp.MoneyKindCodeDtl[rowIndex] = 0;
                paymentSlp.MoneyKindNameDtl[rowIndex] = "";
                paymentSlp.MoneyKindDivDtl[rowIndex] = 0;
                paymentSlp.PaymentDtl[rowIndex] = 0;
                paymentSlp.ValidityTermDtl[rowIndex] = DateTime.MinValue;

                if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                    ((String)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == ""))
                {
                    continue;
                }

                // 金種コード取得
                int moneyKindCode = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindCode].Value;
                // 金種名称取得
                string moneyKindName = (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindName].Value;
                // 金種区分取得
                int moneyKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;
                // 支払行番号取得
                int paymentRowNo = 0;
                if (this._dicPaymentRowNo.ContainsKey(moneyKindCode))
                {
                    paymentRowNo = this._dicPaymentRowNo[moneyKindCode];
                }
                // 支払金額取得
                double payment;
                if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                    ((String)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == ""))
                {
                    payment = 0;
                }
                else
                {
                    payment = double.Parse((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value);
                }
                // 期日
                DateTime validityTerm;
                bool bStatus = GetValidityTerm(rowIndex, out validityTerm);

                paymentSlp.PaymentRowNoDtl[paymentRowNo - 1] = paymentRowNo;
                paymentSlp.MoneyKindCodeDtl[paymentRowNo - 1] = moneyKindCode;
                paymentSlp.MoneyKindNameDtl[paymentRowNo - 1] = moneyKindName;
                paymentSlp.MoneyKindDivDtl[paymentRowNo - 1] = moneyKindDiv;
                paymentSlp.PaymentDtl[paymentRowNo - 1] = (long)payment;
                paymentSlp.ValidityTermDtl[paymentRowNo - 1] = validityTerm;
            }
			// 支払額
            //paymentSlp.Payment = (long)this.nedtPaymentTotal.GetValue() - (long)this.nedtFeePayment.GetValue() - (long)this.nedtDiscountPayment.GetValue(); // DEL 2009/12/20
            // ADD 2009/12/20 ---------->>>>>
            if (this.nedtPaymentTotal.DataText == string.Empty)
            {
                paymentSlp.Payment = long.Parse("0") - (long)this.nedtFeePayment.GetValue() - (long)this.nedtDiscountPayment.GetValue();
            }
            else
            {
                paymentSlp.Payment = long.Parse(this.nedtPaymentTotal.DataText) - (long)this.nedtFeePayment.GetValue() - (long)this.nedtDiscountPayment.GetValue();
            }
            // ADD 2009/12/20 ----------<<<<<
            // 手数料
            paymentSlp.FeePayment = (long)this.nedtFeePayment.GetValue();
            // 値引
            paymentSlp.DiscountPayment = (long)this.nedtDiscountPayment.GetValue();
            //// 銀行コード
            //int iBankCd = TStrConv.StrToIntDef(this.tEdit_BankCode.Text, 0);
            //if (iBankCd != 0)
            //{
            //    paymentSlp.BankCode = TStrConv.StrToIntDef(this.tEdit_BankCode.Text, 0);
            //}
            //else
            //{
            //    paymentSlp.BankCode = 0;
            //}
            //// 銀行名称
            //paymentSlp.BankName = this.teditBankName.Text.TrimEnd();
            //// 手形種類
            //if (this.cmbDraftKind.Value == null)
            //{
            //    paymentSlp.DraftKind = 0;
            //}
            //else
            //{
            //    paymentSlp.DraftKind = (int)this.cmbDraftKind.Value;
            //}
            //// 手形種類名称
            //paymentSlp.DraftKindName = this.cmbDraftKind.Text.TrimEnd();
            //// 手形区分
            //if (this.cmbDraftDivide.Value == null)
            //{
            //    paymentSlp.DraftDivide = 0;
            //}
            //else
            //{
            //    paymentSlp.DraftDivide = (int)this.cmbDraftDivide.Value;
            //}
            //// 手形区分名称 
            //paymentSlp.DraftDivideName = this.cmbDraftDivide.Text.TrimEnd();
            //// 手形番号
            //paymentSlp.DraftNo = this.tEdit_DraftNo.Text.TrimEnd();
            //// 手形振出日
            //paymentSlp.DraftDrawingDate = this.dateDraftDrawingDate.GetDateTime();
            // 摘要
            paymentSlp.Outline = this.editOutline.Text.TrimEnd();
            // 支払計
            //paymentSlp.PaymentTotal = (long)this.nedtPaymentTotal.GetValue(); // DEL 2009/12/20l
            // ADD 2009/12/20 ---------->>>>>
            if (this.nedtPaymentTotal.DataText == string.Empty)
            {
                paymentSlp.PaymentTotal = 0;
            }
            else
            {
                paymentSlp.PaymentTotal = long.Parse(this.nedtPaymentTotal.DataText);
            }
            // ADD 2009/12/20 ----------<<<<<
            // 自動支払区分(0:通常支払をセット)
            paymentSlp.AutoPayment = 0;

            return paymentSlp;
        }

        private bool GetValidityTerm(int rowIndex, out DateTime validityTerm)
        {
            validityTerm = new DateTime();

            int year;
            int month;
            int day;

            string targetValue;

            if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value == DBNull.Value) ||
                ((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value == ""))
            {
                return (false);
            }
            else
            {
                targetValue = (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Value;
                if (targetValue[targetValue.Length - 1].ToString() == "年")
                {
                    targetValue = targetValue.Remove(targetValue.Length - 1);
                }
                year = int.Parse(targetValue);
            }

            if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value == DBNull.Value) ||
                ((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value == ""))
            {
                return (false);
            }
            else
            {
                targetValue = (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctMonth].Value;
                if (targetValue[targetValue.Length - 1].ToString() == "月")
                {
                    targetValue = targetValue.Remove(targetValue.Length - 1);
                }
                month = int.Parse(targetValue);

                if (month > 12)
                {
                    return (false);
                }
            }

            if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value == DBNull.Value) ||
                ((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value == ""))
            {
                return (false);
            }
            else
            {
                targetValue = (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Value;
                if (targetValue[targetValue.Length - 1].ToString() == "日")
                {
                    targetValue = targetValue.Remove(targetValue.Length - 1);
                }
                day = int.Parse(targetValue);

                if (DateTime.DaysInMonth(year, month) < day)
                {
                    return (false);
                }
            }

            if (TDateTime.IsAvailableDate(new DateTime(year, month, day)) == false)
            {
                return (false);
            }

            validityTerm = new DateTime(year, month, day);

            return (true);
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払伝票画面表示処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <remarks>
		/// <br>Note		: 支払伝票マスタの情報を画面に展開します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void SetPaymentSlpToDisp(PaymentSlp paymentSlp)
		{
			// バッファに確保
			_buffPaymentSlp = paymentSlp.Clone();

			// 支払伝票一覧情報をクリア
			this.lblListInfo.Text = string.Empty;

			// 支払伝票番号
			if (paymentSlp.PaymentSlipNo != 0)
			{
                // ↓ 20061222 18322 c 携帯.NS用に変更
                #region SF
                //if (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= _paymentSlpSearch.GetCAddUpUpDate())
				//{
				//	this.lblMode.Text = "[ 参照 ]";
				//	// 参照モード
				//	_updateMode = 2;
                //
				//	this.lblListInfo.Text = "締済支払伝票の為、 更新 / 削除 は出来ません。";
				//}
				//else
				//{
				//	this.lblMode.Text = "[ 更新 ]";
				//	// 更新モード
				//	_updateMode = 1;
                //}
                #endregion

                #region 携帯.NS
                switch (paymentSlp.DebitNoteDiv){
                    case 1:
                        //=======================
                        // 赤伝の時
                        //=======================
                        this.lblMode.Text = "[ 参照 ]";
                        // 赤参照モード
                        _updateMode = ScreenUpdateMode.RedReference;
                        this.lblListInfo.Text = "赤入金伝票の為、更新 は出来ません。";
                        break;
                    case 2:
                        //=======================
                        // 相殺済み黒伝の時
                        //=======================
                        this.lblMode.Text = "[ 参照 ]";
                        // 参照モード
                        _updateMode = ScreenUpdateMode.Reference;
                        this.lblListInfo.Text = "相殺済み伝票の為、更新 / 削除 は出来ません。";
                        break;
                    default :
                        //=======================
                        // 通常伝票の時
                        //=======================
                        if (paymentSlp.AutoPayment == 0) // 通常支払   // 2007.09.05 add
                        {

                            if ((TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= _paymentSlpSearch.GetCAddUpUpDate()) ||
                                (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= _paymentSlpSearch.GetLastMonthlyDate()))
                            {
                                this.lblMode.Text = "[ 参照 ]";
                                // 参照モード
                                _updateMode = ScreenUpdateMode.Reference;

                                this.lblListInfo.Text = "締済支払伝票の為、 更新 / 削除 は出来ません。";
                            }
                            else
                            {
                                this.lblMode.Text = "[ 更新 ]";
                                // 更新モード
                                _updateMode = ScreenUpdateMode.Update;
                            }
                        }
                        // 2007.09.05 add start -------------------------------->> 
                        else  // 自動支払
                        {
                            this.lblMode.Text = "[ 参照 ]";
                            // 参照モード
                            _updateMode = ScreenUpdateMode.Reference;
                            this.lblListInfo.Text = "自動支払伝票の為、更新 / 削除 は出来ません。";
                        }
                        // 2007.09.05 add end ----------------------------------<<
                        break;
                }

                switch (paymentSlp.DebitNoteDiv)
                {
                    case 1 :    // 赤伝
                        nedtPaymentSlipNo.Appearance.ForeColor = System.Drawing.Color.Red;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = System.Drawing.Color.DarkOrchid;
                        labDebitNoteLinkDepoNo.Text = "[連結(黒)：" + paymentSlp.DebitNoteLinkPayNo.ToString("000000000") + "]";
                        break;
                    case 2 :    // 相殺済み黒伝
                        nedtPaymentSlipNo.Appearance.ForeColor = System.Drawing.Color.DarkOrchid;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = System.Drawing.Color.Red;
                        labDebitNoteLinkDepoNo.Text = "[連結(赤)：" + paymentSlp.DebitNoteLinkPayNo.ToString("000000000") + "]";
                        break;
                    default :
                        nedtPaymentSlipNo.Appearance.ForeColor = System.Drawing.Color.Black;
                        labDebitNoteLinkDepoNo.Appearance.ForeColor = System.Drawing.Color.Black;
                        labDebitNoteLinkDepoNo.Text = "";
                        break;
                }

                #endregion
                // ↑ 20061222 18322 c

                // 金種
				foreach (UltraTreeNode node in this.treeMoneyKind.Nodes)
				{
                    
					if (node.Key.Equals(paymentSlp.PaymentMoneyKindCode.ToString()))
					{
						node.CheckedState = CheckState.Checked;
					}
					else
					{
						node.CheckedState = CheckState.Unchecked;
					}
                }
            }
			else
			{
				// モード表示
				this.lblMode.Text = "[ 新規 ]";

                // ↓ 20070213 18322 c MA.NS用に変更
				//// 新規モード
				//_updateMode = 0;

				// 新規モード
				_updateMode = ScreenUpdateMode.New;
                // ↑ 20070213 18322 c
			}

			this.nedtPaymentSlipNo.SetInt(paymentSlp.PaymentSlipNo);
			// 支払日付
            // 2007.09.05 upd start ----------------------------------->>
            //if (paymentSlp.PaymentDate != DateTime.MinValue)
            //{
                
            //    this.datePaymentDate.SetDateTime(paymentSlp.PaymentDate);
            //}
            if (paymentSlp.AddUpADate != DateTime.MinValue)
            {
                this.datePaymentDate.SetDateTime(paymentSlp.AddUpADate);
            }
            // 2007.09.05 upd end -------------------------------------<<

			// 支払額
			this.nedtPayment.SetValue(paymentSlp.Payment);
            
            // 手数料
			this.nedtFeePayment.SetValue(paymentSlp.FeePayment);
			// 値引
			this.nedtDiscountPayment.SetValue(paymentSlp.DiscountPayment);
            // ↓ 20061222 18322 a
            // インセンティブ
            //this.nedtRebatePayment.SetValue(paymentSlp.RebatePayment);   // 2007.09.05 del
            // ↑ 20061222 18322 a
			// 総額
			this.nedtPaymentTotal.SetValue(paymentSlp.PaymentTotal);
			
            // 2007.09.05 upd start -------------------------------->>
            // クレジット
			//this.cmbDraftKind.Value = paymentSlp.CreditOrLoanCd;
			//if (!this.tEdit_BankCode.ReadOnly)
			//{
				// クレジット会社コード
			//	this.tEdit_BankCode.Text = paymentSlp.CreditCompanyCode;
			//	CreditCompanyNamePrcThreadStart();
			//}
            if (!this.tEdit_BankCode.ReadOnly)
            {
                // 銀行コード
                if (paymentSlp.BankCode != 0)
                {
                    this.tEdit_BankCode.Text = paymentSlp.BankCode.ToString().Trim();
                    this.teditBankName.Text = paymentSlp.BankName.ToString().Trim();
                }
            }
            // 手形番号
            this.tEdit_DraftNo.Text = paymentSlp.DraftNo;
            // 手形種類
            this.cmbDraftKind.Value = paymentSlp.DraftKind;
            // 手形区分
            this.cmbDraftDivide.Value = paymentSlp.DraftDivide;
            // 2007.09.05 upd end ----------------------------------<<

			// 手形振出日
			this.dateDraftDrawingDate.SetDateTime(paymentSlp.DraftDrawingDate);

			// 手形支払期限
			this.dateDraftPayTimeLimit.SetDateTime(paymentSlp.DraftPayTimeLimit);
            
            // 摘要
			this.editOutline.Text = paymentSlp.Outline;

			// 入力項目のEnable制御処理
			ChangeInputCtlOnMode(paymentSlp);
		}

		private void ChangeInputCtlOnMode(PaymentSlp paymentSlp)
		{
			// ☆☆☆ 以下入力制御（参照モード対応） ☆☆☆

            // ↓ 20070213 18322 c MA.NS用に変更
			//if (_updateMode == 2)
			//{

			if ((_updateMode == ScreenUpdateMode.Reference   ) ||
                (_updateMode == ScreenUpdateMode.RedReference)   )
			{
            // ↑ 20070213 18322 c
				this.datePaymentDate.ReadOnly		= true;   // 支払日

				this.treeMoneyKind.Enabled			= false;  // 支払金種
				this.nedtPayment.ReadOnly			= true;   // 支払額
                
                this.nedtFeePayment.ReadOnly		= true;   // 手数料
				this.nedtDiscountPayment.ReadOnly	= true;   // 値引額
                // ↓ 20061222 18322 a
                // インセンティブ
                //this.nedtRebatePayment.ReadOnly = true;  // 2007.09.05 del
                // ↑ 20061222 18322 a
				this.dateDraftDrawingDate.ReadOnly	= true;   // 振出日

				this.dateDraftPayTimeLimit.ReadOnly	= true;　 // 手形支払期日　

                this.editOutline.ReadOnly			= true;   // 摘要
 
                // 2007.09.05 add start ----------------------------->>
                this.cmbDraftKind.ReadOnly = true;       // 手形種類
                this.cmbDraftDivide.ReadOnly = true;     // 手形区分
                this.tEdit_BankCode.Enabled = false;       // 銀行コード
                this.btnBankGuid.Enabled = false;        // 銀行ガイド 
                this.tEdit_DraftNo.Enabled = false;         // 手形番号
                // 2007.09.05 add end -------------------------------<<

                // ↓ 20070213 18322 c MA.NS用に変更
				//// フレームのボタン設定
				//_btnSave	= false;	// 保存
				//_btnDelete	= false;	// 削除

                // フレームのボタン設定
                bool btnDel = false;
                if (_updateMode == ScreenUpdateMode.RedReference)
                {
                    // 赤伝参照の時、削除ボタンは押下可
                    if (paymentSlp.CAddUpUpdDate < TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate))
                    {
                        // 前回締め日以降のデータの場合
                        btnDel = true;
                    }
                }

                _btnSave      = false;	   // 保存
                _btnDelete    = btnDel;    // 削除

                if (paymentSlp.AutoPayment != 1)   // 自動支払以外
                {
                    _btnDebitNote = true;      // 赤伝
                }
                else
                {
                    _btnDebitNote = false;      // 赤伝
                }
                // ↑ 20070213 18322 c
			}
			else
			{
				this.datePaymentDate.ReadOnly		= false;

				this.treeMoneyKind.Enabled			= true;
				this.nedtPayment.ReadOnly			= false;
                this.nedtFeePayment.ReadOnly		= false;
				this.nedtDiscountPayment.ReadOnly	= false;
                // ↓ 20061222 18322 a
                // インセンティブ
                //this.nedtRebatePayment.ReadOnly = false;  // 2007.09.05 del
                // ↑ 20061222 18322 a

                // 2007.09.05 upd start ----------------------------------->>
				//if ((paymentSlp.PaymentMoneyKindDiv == (int)MnyKindDiv.Credit) ||
				//	(paymentSlp.PaymentMoneyKindDiv == (int)MnyKindDiv.Loan))
				//{
				//	this.cmbDraftKind.ReadOnly = false;
				//	this.btnBankGuid.Enabled = true;
				//}
				//else
				//{
				//	this.cmbDraftKind.ReadOnly		= true;
				//	this.btnBankGuid.Enabled	= false;
				//}
				//if (paymentSlp.PaymentMoneyKindDiv == (int)MnyKindDiv.Bill)
				//{
				//	this.dateDraftDrawingDate.ReadOnly	= false;
				//	this.dateDraftPayTimeLimit.ReadOnly	= false;
				//}
				//else
				//{
				//	this.dateDraftDrawingDate.ReadOnly	= true;
				//	this.dateDraftPayTimeLimit.ReadOnly	= true;
				//}
                // 入力不可制御
                switch (paymentSlp.PaymentMoneyKindDiv)
                {
                    case (int)MnyKindDiv.Bill:
                    case (int)MnyKindDiv.ACheck:
                        {
                            this.dateDraftPayTimeLimit.ReadOnly = false;　// 手形支払期日　
                            this.cmbDraftKind.ReadOnly = false;           // 手形種類
                            this.cmbDraftDivide.ReadOnly = false;         // 手形区分
                            this.tEdit_DraftNo.Enabled = true;               // 手形番号
                            this.tEdit_BankCode.ReadOnly = false;           // 銀行コード
                            this.btnBankGuid.Enabled = true;              // 銀行ガイド
                            this.dateDraftDrawingDate.ReadOnly = false;   // 振出日
                            break;
                        }
                    case (int)MnyKindDiv.Check:
                        {
                            this.tEdit_BankCode.ReadOnly = false;            // 銀行コード
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;               // 銀行ガイド
                            this.dateDraftDrawingDate.ReadOnly	= false;   // 振出日
                            break;
                        }
                    case (int)MnyKindDiv.Remittance:
                        {
                            this.tEdit_BankCode.ReadOnly = false;            // 銀行コード
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;               // 銀行ガイド
                            break;
                        }
                    default:
                        {
                            this.dateDraftPayTimeLimit.ReadOnly = true;　// 手形支払期日　
                            this.cmbDraftKind.ReadOnly = true;           // 手形種類
                            this.cmbDraftDivide.ReadOnly = true;         // 手形区分
                            this.tEdit_DraftNo.Enabled = false;             // 手形番号
                            this.tEdit_BankCode.ReadOnly = true;           // 銀行コード
                            this.btnBankGuid.Enabled = false;            // 銀行ガイド 
                            this.dateDraftDrawingDate.ReadOnly = true;   // 振出日
                            break;
                        }
                }
                // 2007.09.05 upd end --------------------------------------<<
                
                this.editOutline.ReadOnly			= false;

				// フレームのボタン設定
				_btnSave	= true;	// 保存
				_btnDelete	= true;	// 削除
                // ↓ 20061222 18322 a
                _btnDebitNote = true;  // 赤伝
                // ↑ 20061222 18322 a
			}

			if (ParentToolbarSettingEvent != null)
				ParentToolbarSettingEvent(this);
		}

		/// <summary>
		/// 画面表示情報取得処理
		/// </summary>
		/// <returns>支払伝票マスタ</returns>
		/// <remarks>
		/// <br>Note		: 画面の情報を元に支払伝票マスタを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>UpdateNote  : 2006.12.22 木村 武正</br>
        /// <br>              携帯.NS用に赤伝区分、計上日、インセンティブ、自動支払区分、赤黒支払連結番号を追加</br>
        /// <br></br>
        /// <br></br>
		/// </remarks>
		private PaymentSlp SetDispToPaymentSlp()
		{
			PaymentSlp paymentSlp = _buffPaymentSlp.Clone();

            // 支払伝票番号
			paymentSlp.PaymentSlipNo = this.nedtPaymentSlipNo.GetInt();
			
            // 2007.09.05 upd start -------------------------------------->>
            // 支払日付
			//paymentSlp.PaymentDate = this.datePaymentDate.GetDateTime();
            // 計上日付
            paymentSlp.AddUpADate = this.datePaymentDate.GetDateTime();
            // 2007.09.05 upd end ----------------------------------------<<

			// 金種
			foreach (UltraTreeNode node in this.treeMoneyKind.Nodes)
			{
				if (node.CheckedState == CheckState.Checked)
				{
                    
					paymentSlp.PaymentMoneyKindCode	= TStrConv.StrToIntDef(node.Key, 0);
					paymentSlp.PaymentMoneyKindName	= node.Text;
					MoneyKind moneyKind = (MoneyKind)_moneyKindHashTable[paymentSlp.PaymentMoneyKindCode];
					paymentSlp.PaymentMoneyKindDiv	= moneyKind.MoneyKindDiv;
                    break;
				}
			}
			// 支払額
			paymentSlp.Payment = (long)this.nedtPayment.GetValue();
            // 手数料
			paymentSlp.FeePayment = (long)this.nedtFeePayment.GetValue();
			// 値引
			paymentSlp.DiscountPayment = (long)this.nedtDiscountPayment.GetValue();
            // クレジット
			// paymentSlp.CreditOrLoanCd = TStrConv.StrToIntDef(this.cmbDraftKind.Value.ToString(), 0);  // 2007.09.05 del
			// クレジット会社コード
            //paymentSlp.CreditCompanyCode = this.tEdit_BankCode.Text; // 2007.09.05 del
            // 2007.09.05 add start ------------------------------------------->>
            // 銀行コード
            int iBankCd = TStrConv.StrToIntDef(this.tEdit_BankCode.Text, 0);
            if (iBankCd != 0)
            {
                paymentSlp.BankCode = TStrConv.StrToIntDef(this.tEdit_BankCode.Text, 0);
            }
            // 銀行名称
            paymentSlp.BankName = this.teditBankName.Text.TrimEnd();
            // 手形種類
            paymentSlp.DraftKind = TStrConv.StrToIntDef(this.cmbDraftKind.Value.ToString(), 0); 
            // 手形種類名称
            paymentSlp.DraftKindName = this.cmbDraftKind.Text.TrimEnd();
            // 手形区分
            paymentSlp.DraftDivide = TStrConv.StrToIntDef(this.cmbDraftDivide.Value.ToString(), 0);
            // 手形区分名称 
            paymentSlp.DraftDivideName = this.cmbDraftDivide.Text.TrimEnd();
            // 手形番号
            paymentSlp.DraftNo = this.tEdit_DraftNo.Text.TrimEnd();
            // 2007.09.05 add end ---------------------------------------------<<
            // 手形振出日
			paymentSlp.DraftDrawingDate = this.dateDraftDrawingDate.GetDateTime();

			// 手形支払期限
			paymentSlp.DraftPayTimeLimit = this.dateDraftPayTimeLimit.GetDateTime();
            
            // 摘要
			paymentSlp.Outline = this.editOutline.Text.TrimEnd();

            // ↓ 20061222 18322 a
            //paymentSlp.PaymentDate = paymentSlp.PaymentDate;  // 2007.09.05 del

            // インセンティブ
            // paymentSlp.RebatePayment = (long)this.nedtRebatePayment.GetValue();  // 2007.09.05 del

            // 支払計
            paymentSlp.PaymentTotal = (long)this.nedtPaymentTotal.GetValue();

            // 自動支払区分(0:通常支払をセット)
            paymentSlp.AutoPayment = 0;
            // ↑ 20061222 18322 a

			return paymentSlp;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #endregion

        #region チェック処理系

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払伝票保存前チェック処理
		/// </summary>
		/// <param name="control">NGとなるコントロール</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票の保存前チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private bool CheckDispBeforeSave(out Control control)
		{
			control = null;

			this.nedtPaymentTotal.SetValue(GetPayTotal());

            // ↓ 20070213 18322 c MA.NS用に変更
			//// 修正の時は変更状態チェックを行う
			//if (_updateMode == 1)
			//{

			// 修正の時は変更状態チェックを行う
			if (_updateMode == ScreenUpdateMode.Update)
			{
            // ↑ 20070213 18322 c
				if (_buffPaymentSlp.Equals(SetDispToPaymentSlp()))
				{
					// 未変更の時
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払伝票の変更は行われていません。", 0, MessageBoxButtons.OK);
					control = nedtPayment;
                    return false;
				}
			}

			int payDate = datePaymentDate.GetLongDate();
			// 支払日チェック
			if (payDate == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日を入力して下さい。", 0, MessageBoxButtons.OK);
				control = datePaymentDate;
				return false;
			}
			if (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(payDate)))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日の日付が不正です。", 0, MessageBoxButtons.OK);
				control = datePaymentDate;
				return false;
			}

			// 支払日チェック 最終締次更新年月日チェック
			if (TDateTime.DateTimeToLongDate(datePaymentDate.GetDateTime()) <= _paymentSlpSearch.GetCAddUpUpDate())
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日が前回支払締日以前になっています。", 0, MessageBoxButtons.OK);
				control = datePaymentDate;
				return false;
			}

            // ↓ 20070801 18322 a
			if (TDateTime.DateTimeToLongDate(datePaymentDate.GetDateTime()) <= _paymentSlpSearch.GetLastMonthlyDate())
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日が前回月次更新日以前になっています。", 0, MessageBoxButtons.OK);
				control = datePaymentDate;
				return false;
			}
            // ↑ 20070801 18322 a

			// 支払金種チェック
			bool flg = false;
			foreach (UltraTreeNode node in this.treeMoneyKind.Nodes)
			{
				if (node.CheckedState == CheckState.Checked)
				{
					flg = true;
					break;
				}
			}
            if (flg == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払金種を選択して下さい。", 0, MessageBoxButtons.OK);
				control = treeMoneyKind;
                return false;
			}

			// 支払額チェック
			if (nedtPaymentTotal.GetValue() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払額を入力して下さい。", 0, MessageBoxButtons.OK);
				control = nedtPayment;
                return false;
			}

            // 2007.09.05 del start ------------------------------------------------------------>>
            //if (this.cmbDraftKind.ReadOnly == false)
            //{
                // クレジット・ローン区分が選択可のとき、クレジット会社コードチェック
            //    if (this.teditBankName.Text.Trim() == "")
            //    {
            //		TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "クレジット会社を入力して下さい。", 0, MessageBoxButtons.OK);
  			//		if (this.btnBankGuid.Enabled)
            //        {
                        // クレジット会社コード
            //            control = this.tEdit_BankCode;
            //        }
            //        else
            //        {
                        // クレジット・ローン区分
            //            control = this.cmbDraftKind;
            //        }
      		//		return false;
            //    }
            //}
            // 2007.09.05 del end --------------------------------------------------------------<<

			// 手形振出日
			int drawingDate = dateDraftDrawingDate.GetLongDate();
			if ((drawingDate != 0) && (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(drawingDate))))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手形振出日の日付が不正です。", 0, MessageBoxButtons.OK);
				control = dateDraftDrawingDate;
				return false;
			}

			// 手形支払期日
			int payTimeLimit = dateDraftPayTimeLimit.GetLongDate();
			if ((payTimeLimit != 0) && (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(payTimeLimit))))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手形支払期日の日付が不正です。", 0, MessageBoxButtons.OK);
				control = dateDraftPayTimeLimit;
				return false;
			}

			// 手形振出日/手形支払期日範囲チェック
			if ((dateDraftDrawingDate.GetLongDate() != 0) && (dateDraftPayTimeLimit.GetLongDate() != 0) &&
				(dateDraftDrawingDate.GetLongDate() > dateDraftPayTimeLimit.GetLongDate()))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "手形支払期日が手形振出日より過去になっています。", 0, MessageBoxButtons.OK);
				control = dateDraftDrawingDate;
				return false;
			}
            
            return true;
		}

		/// <summary>
		/// 支払伝票一覧検索前チェック処理
		/// </summary>
		/// <param name="control">NGとなるコントロール</param>
		/// <param name="isSuppliSearch">仕入先検索フラグ</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票一覧検索前チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private bool CheckBeforePaymentListSearch(out Control control, bool isSuppliSearch)
		{
			control = null;
			control = null;
			if (isSuppliSearch)
			{
                //if ((tNedit_SupplierCd.GetInt() == 0) && (tNedit_SupplierSlipNo.GetInt() == 0))  
                //{
                //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "検索条件を指定して下さい。", 0, MessageBoxButtons.OK);
                //    control = tNedit_SupplierCd;
                //    return false;
                //}
   			}
			else
			{
				if (lblSupplierCd.GetInt() == 0)  
   				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "先に仕入先の検索を行ってください。", 0, MessageBoxButtons.OK);
					control = tNedit_SupplierCd;
					return false;
				}
            }

			int startDate	= datePaymentDateStart.GetLongDate();
			int endDate		= datePaymentDateEnd.GetLongDate();

			// 支払日（開始）
			if ((startDate != 0) &&	(!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate))))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日（開始）の日付が不正です。", 0, MessageBoxButtons.OK);
				control = datePaymentDateStart;
				return false;
			}

			// 支払日（終了）
			if ((endDate != 0) && (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate))))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日（終了）の日付が不正です。", 0, MessageBoxButtons.OK);
				control = datePaymentDateEnd;
				return false;
			}

			// 支払日 範囲
			if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日の範囲指定が不正です。", 0, MessageBoxButtons.OK);
				control = datePaymentDateStart;
				return false;
			}

			return true;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
        /// 支払伝票保存前チェック処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタに保存しようとしているデータ</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の保存前チェックを行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Note		: MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更</br>
        /// <br>            : 0円支払伝票の金種項目を設定用に引数を追加</br>
        /// <br>Programmer	: 30434 工藤</br>
        /// <br>Date		: 2010/03/26</br>
        /// <br>Update Note : 2010/12/20 徐佳 支払伝票入力手形データあり支払の金額ゼロ変更時のメッセージ追加</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Update Note : 2013/07/18 呉軍</br>
        /// <br>管理番号    : 配信日なし</br>
        /// <br>              Redmine#35133既存障害№1の対応</br>
        /// </remarks>
        // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
        //private bool CheckDispBeforeSave()
        // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
        // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
        private bool CheckDispBeforeSave(PaymentSlp paymentSlp)
        // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
        {
            this._doubleCheckFlg = true; //ADD 2009/04/28 gejun for M1007A-手形データ追加

            this.grdPaymentKind.ActiveCell = null;

            this._doubleCheckFlg = false;//ADD 2009/04/28 gejun for M1007A-手形データ追加

            string errMsg = "";   
         
            // --- ADD 2010/12/20 ----------------------------------------->>>>>
            bool updateFlg = false;//手形データ判定
            // --- ADD 2010/12/20 -----------------------------------------<<<<<

            try
            {
                // 仕入先
                if (this.tNedit_SupplierCd.GetInt() != this._prevSupplierCode)
                {
                    errMsg = "仕入先コードが変更されています。";
                    ClearScreen();
                    this._btnNew = false;	        // 新規
                    //this._btnSave = true;	        // 保存    // DEL 2009/12/20
                    this._btnSave = false;	        // 保存    // ADD 2009/12/20
                    this._btnRenewal = false;
                    this._btnDelete = false;	    // 削除
                    this._btnDebitNote = false;     // 赤伝
                    this._btnReadSupSlip = true;    // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                    this._searchFlg = false;

                    // フレームのボタン設定イベント
                    if (ParentToolbarSettingEvent != null)
                    {
                        ParentToolbarSettingEvent(this);
                    }
                    return (false);
                }

                // 支払金額合計取得
                double total = GetPayTotal();
                if (total == 0)
                {
                    this.nedtPaymentTotal.DataText = "";
                }
                else
                {
                    //this.nedtPaymentTotal.SetValue(total);   // DEL 2009/12/20
                    this.nedtPaymentTotal.DataText = total.ToString(); // ADD 2009/12/20
                }

                
                // 修正の時は変更状態チェックを行う
                if (this._updateMode == ScreenUpdateMode.Update)
                {
                    // 未変更の時
                    if (this._buffPaymentSlp.Equals(SetDispToPaymentSlp()))
                    {
                        // ADD 2010/05/12 MANTIS対応[15200]：入金0を修正呼出し直後の保存が行えない ---------->>>>>
                        // 0円の支払の場合、無視
                        if (!this._buffPaymentSlp.PaymentTotal.Equals(0))
                        // ADD 2010/05/12 MANTIS対応[15200]：入金0を修正呼出し直後の保存が行えない ----------<<<<<
                        {
                            errMsg = "支払伝票の変更は行われていません。";
                            this.grdPaymentKind.Focus();
                            //ADD START 2009/05/04 gejun forM1007A-手形データ追加
                            if (_draftOptSet)
                            {
                                for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                                {
                                    // 金種区分取得
                                    int moneyKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;
                                    // 金種コード取得
                                    int moneyKindCode = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindCode].Value;
                                    // 金種区分が「105：手形」の場合
                                    if ((moneyKindDiv == (int)MnyKindDiv.Bill))
                                    {
                                        if (this._payDraftData != null)
                                        {
                                            PaymentSlp paymentSlpTemp = this._buffPaymentSlp.Clone();
                                            // --- DEL 2013/02/22 Y.Wakita ---------->>>>>
                                            //// --- ADD 2013/02/15 Y.Wakita ---------->>>>>
                                            //DateTime addUpADateBk = new DateTime();
                                            //addUpADateBk = paymentSlpTemp.AddUpADate;
                                            //// --- ADD 2013/02/15 Y.Wakita ----------<<<<<
                                            //paymentSlpTemp.AddUpADate = DateTime.MinValue;
                                            // --- DEL 2013/02/22 Y.Wakita ----------<<<<<

                                            // 支払行番号取得
                                            int paymentRowNo = 0;
                                            if (this._dicPaymentRowNo.ContainsKey(moneyKindCode))
                                            {
                                                // 手形支払期日取得
                                                DateTime dateTime;
                                                bool bStatus = GetValidityTerm(rowIndex, out dateTime);
                                                // 手形支払期日
                                                if (TDateTime.IsAvailableDate(dateTime) == false)
                                                {
                                                    return (false);
                                                }

                                                if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                                        (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == "")
                                                {
                                                    return (false);
                                                }

                                                paymentRowNo = this._dicPaymentRowNo[moneyKindCode];
                                                // 行番号
                                                this._payDraftData.PaymentRowNo = paymentRowNo;
                                            }
                                            // --- UPD 2012/10/18 ----------------------------------------->>>>>
                                            //int status = this._paymentSlpSearch.SavePaymentDataWithDraft(ref paymentSlpTemp, this._payDraftData, this._payDraftDataDel);
                                            // --- UPD 2013/02/22 Y.Wakita ---------->>>>>
                                            //int status = this._paymentSlpSearch.SavePaymentDataWithDraftAll(ref paymentSlpTemp, this._payDraftData, this._payDraftDataDel, this._rcvDraftData, this._rcvDraftDataDel);
                                            int status = this._paymentSlpSearch.SavePaymentDataWithDraftAll(ref paymentSlpTemp, this._payDraftData, this._payDraftDataDel, this._rcvDraftData, this._rcvDraftDataDel, false);
                                            // --- UPD 2013/02/22 Y.Wakita ----------<<<<<
                                            this._rcvDraftData = null;
                                            this._rcvDraftDataDel = null;
                                            // --- UPD 2012/10/18 -----------------------------------------<<<<<
                                            this._payDraftData = null;
                                            this._payDraftDataDel = null;
                                            // --- DEL 2013/02/22 Y.Wakita ---------->>>>>
                                            //// --- ADD 2013/02/15 Y.Wakita ---------->>>>>
                                            //paymentSlpTemp.AddUpADate = addUpADateBk;
                                            //// --- ADD 2013/02/15 Y.Wakita ----------<<<<<
                                            // --- DEL 2013/02/22 Y.Wakita ----------<<<<<
                                            switch (status)
                                            {
                                                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                                    {
                                                        break;
                                                    }
                                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:

                                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP,
                                                        "SaveProc",
                                                       "既に他端末より更新されています。",
                                                        status,
                                                        MessageBoxButtons.OK);
                                                    break;
                                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                                    {
                                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP,
                                                            "SaveProc",
                                                            "既に他端末より削除されています。",
                                                            status,
                                                            MessageBoxButtons.OK);
                                                        break;
                                                    }
                                                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
                                                case STATUS_CHK_SEND_ERR:
                                                    {
                                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                                      this.Name,
                                                                      CHK_SEND_ERR_MSG,
                                                                      status,
                                                                      MessageBoxButtons.OK);
                                                        break;
                                                    }
                                                // ADD 2011/08/24 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<
                                                default:
                                                    {
                                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP,
                                                              "SaveProc",
                                                              "保存処理に失敗しました。",
                                                              status,
                                                              MessageBoxButtons.OK);
                                                        break;
                                                    }
                                            }
                                        }
                                        break;
                                    }
                                }
                            }

                            //ADD END 2009/05/04 gejun forM1007A-手形データ追加
                            return (false);
                        }
                    }
                    // --- ADD 2010/12/20 ----------------------------------------->>>>>
                    if (total == 0)
                    {
                        this.grdPaymentKind.Focus();
                        List<PayDraftData> retList = new List<PayDraftData>();
                        if (this._draftOptSet && SearchDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            updateFlg = true;
                        }
                    }
                    // --- ADD 2010/12/20 -----------------------------------------<<<<<
                }

                // 支払日チェック
                if (this.datePaymentDate.GetLongDate() == 0)
                {
                    errMsg = "支払日を入力して下さい。";
                    this.datePaymentDate.Focus();
                    return (false);
                }
                if (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.datePaymentDate.GetLongDate())))
                {
                    errMsg = "支払日の日付が不正です。";
                    this.datePaymentDate.Focus();
                    return (false);
                }

                // 未来日付チェック
                if (this._paySlipDateAmbit == 1)
                {
                    if (this.datePaymentDate.GetLongDate() > TDateTime.GetSFDateNow("YYYYMMDD"))
                    {
                        errMsg = "未来日付での支払はできません。";
                        this.datePaymentDate.Focus();
                        return (false);
                    }
                }
                //ADD START 2009/04/27 gejun forM1007A-手形データ追加
                // 期日チェック
                if (_draftOptSet)
                {
                    for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                    {
                        if ((int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value == (int)MnyKindDiv.Bill)
                        {
                            if (!this.ValidityTermCheck(rowIndex))
                            {
                                return (false);
                            }
                        }
                    }
                }
                //ADD END 2009/04/27 gejun forM1007A-手形データ追加

                DateTime targetDate;

                // 支払日が変更された場合
                if (this.nedtPaymentSlipNo.GetInt() != 0)
                {
                    if (this._buffPaymentSlp.PaymentDate != this.datePaymentDate.GetDateTime())
                    {
                        targetDate = this._paymentSlpSearch.GetTotalDayPayment(this._buffPaymentSlp.AddUpSecCode, this._buffPaymentSlp.PayeeCode);
                        if (targetDate != DateTime.MinValue)
                        {
                            // 変更前の支払日が前回締更新日以前の場合
                            if (this._buffPaymentSlp.PaymentDate <= targetDate)
                            {
                                //errMsg = "変更前の支払日が前回支払締日以前のため修正できません。";
                                errMsg = "支払日が前回支払締日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回支払締日：" + targetDate.ToString("yyyy年MM月dd日");
                                this.datePaymentDate.Focus();
                                return (false);
                            }
                        }

                        targetDate = this._paymentSlpSearch.GetHisTotalDayMonthlyAccPay(this._buffPaymentSlp.AddUpSecCode);
                        if (targetDate != DateTime.MinValue)
                        {
                            // 変更前の支払日が前回月次更新日以前の場合
                            if (this._buffPaymentSlp.PaymentDate <= targetDate)
                            {
                                //errMsg = "変更前の支払日が前回月次更新日以前のため修正できません。";
                                errMsg = "支払日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                                this.datePaymentDate.Focus();
                                return (false);
                            }
                        }
                    }
                }

                // 支払日チェック 最終締次更新年月日チェック
                targetDate = this._paymentSlpSearch.GetTotalDayPayment(this._selectSectionCode, this._payeeCode);
                if (targetDate != DateTime.MinValue)
                {
                    if (this.datePaymentDate.GetDateTime() <= targetDate)
                    {
                        errMsg = "支払日が前回支払締日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回支払締日：" + targetDate.ToString("yyyy年MM月dd日");
                        this.datePaymentDate.Focus();
                        return (false);
                    }
                }

                targetDate = this._paymentSlpSearch.GetHisTotalDayMonthlyAccPay(this._selectSectionCode);
                if (targetDate != DateTime.MinValue)
                {
                    if (this.datePaymentDate.GetDateTime() <= targetDate)
                    {
                        errMsg = "支払日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                        this.datePaymentDate.Focus();
                        return (false);
                    }
                }

                // HACK:支払額チェック
                //if (this.nedtPaymentTotal.GetValue() == 0) // DEL 2009/12/20l
                // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>
                //if (this.nedtPaymentTotal.DataText == string.Empty) // ADD 2009/12/20
                // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<
                // ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>

                // ----- DEL 2013/06/20 gaofeng For Redmine#35133 ----- >>>>>
                //bool isZeroSlip = false;
                //if (this.nedtPaymentTotal.DataText == string.Empty || this.nedtPaymentTotal.DataText == "0")
                //// ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<
                //{
                //    // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                //    //errMsg = "支払金額を入力して下さい。";
                //    //this.grdPaymentKind.Focus();
                //    //this.grdPaymentKind.Rows[0].Cells[ctPayment].Activate();
                //    //this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                //    //return false;
                //    // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                //    // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                //    // FIXME:金種選択
                //    errMsg = SAVING_ZERO_DEPOSIT_MSG;
                //    SFSIR02102UF selectingMoneyKindDialog = new SFSIR02102UF(
                //        this.grdPaymentKind,
                //        paymentSlp  // [OK]すると金種項目が設定される
                //    );
                //    // --- ADD 2010/12/20 ----------------------------------------->>>>>
                //    if (updateFlg)
                //    {
                //        selectingMoneyKindDialog.ulblTeGataMessage.Visible = true;
                //    }
                //    else
                //    {
                //        selectingMoneyKindDialog.ulblTeGataMessage.Visible = false;
                //    }
                //    // --- ADD 2010/12/20 -----------------------------------------<<<<<
                //    {
                //        selectingMoneyKindDialog.TakeValidityTerm += this.GetValidityTerm;
                //        DialogResult dialogResult = selectingMoneyKindDialog.ShowDialog(this);
                //        if (dialogResult.Equals(DialogResult.Cancel))
                //        {
                //            return false;   // 0円の支払伝票を作成せずに戻る
                //        }
                //        this.Update();
                //        isZeroSlip = true;
                //    }
                //    // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                //}
                // ----- DEL 2013/06/20 gaofeng For Redmine#35133 ----- <<<<<

                // ----- ADD 2013/06/20 gaofeng For Redmine#35133 ----- >>>>>
                // 全ての金種の金額が空白かを判断
                bool allZero = (this.nedtFeePayment.GetInt() == 0 && this.nedtDiscountPayment.GetInt() == 0);
                if (allZero == true)
                {
                    for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                {
                        // 支払金額が空白
                        if ((this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                            (string)this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Value == "")
                    {
                            continue;
                    }
                    else
                    {
                            allZero = false;
                            break;
                        }
                    }
                    }

                // 支払が入力しない場合、メッセージを出す
                if (allZero == true)
                    {
                    errMsg = SAVING_ZERO_DEPOSIT_MSG;

                    this.grdPaymentKind.Focus();
                    if (this.grdPaymentKind.Rows.Count > 0)
                        {
                        this.grdPaymentKind.Rows[0].Cells[ctPayment].Activate();
                        this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                        }

                    return (false);
                }
                // ----- ADD 2013/06/20 gaofeng For Redmine#35133 ----- <<<<<

                // 手形支払期日
                for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
                {
                    // 金種区分取得
                    int moneyKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;

                    // 金種区分が「105：手形」「107：小切手」以外の場合
                    if ((moneyKindDiv != 105) && (moneyKindDiv != 107))
                    {
                        continue;
                    }

                    // 支払金額が空白
                    if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                        (this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == null) ||
                        (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == "")
                    {
                        continue;
                    }

                    // 手形支払期日取得
                    DateTime dateTime;
                    bool bStatus = GetValidityTerm(rowIndex, out dateTime);
                    // 手形支払期日
                    if (TDateTime.IsAvailableDate(dateTime) == false)
                    {
                        // ADD 2010/05/14 MANTIS対応[15200]：0円データでは、有効期間を持つ金種の日付チェックは不要 ---------->>>>>
                        //if (!isZeroSlip)　// DEL 2013/06/20 gaofeng For Redmine#35133
                        // ADD 2010/05/14 MANTIS対応[15200]：0円データでは、有効期間を持つ金種の日付チェックは不要 ----------<<<<<
                        {
                            errMsg = "手形支払期日の日付が不正です。";
                            this.grdPaymentKind.Focus();
                            this.grdPaymentKind.Rows[rowIndex].Cells[ctYear].Activate();
                            this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                    }
                }

                // 支払金額
                Int64 deposit = (Int64)GetPayment();

                // 手数料取得
                Int64 feeDeposit = this.nedtFeePayment.GetInt();

                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- >>>>>
                //if (deposit >= 0)
                //{
                //    if (feeDeposit < 0)
                //    {
                //        errMsg = "手数料の値が不正です。";
                //        this.nedtFeePayment.Focus();
                //        return (false);
                //    }
                //    //if (deposit < feeDeposit)
                //    //{
                //    //    errMsg = "手数料の値が不正です。";
                //    //    this.nedtFeePayment.Focus();
                //    //    return (false);
                //    //}
                //}
                //else
                //{
                //    if (feeDeposit > 0)
                //    {
                //        errMsg = "手数料の値が不正です。";
                //        this.nedtFeePayment.Focus();
                //        return (false);
                //    }
                //    //if (deposit > feeDeposit)
                //    //{
                //    //    errMsg = "手数料の値が不正です。";
                //    //    this.nedtFeePayment.Focus();
                //    //    return (false);
                //    //}
                //}
                // ----- DEL 2013/07/18 呉軍 For Redmine#35133 ----- <<<<<
            }
            finally
            {
                // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                //if (errMsg.Length > 0)
                // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                //if (errMsg.Length > 0 && !errMsg.Equals(SAVING_ZERO_DEPOSIT_MSG)) // DEL 2013/06/20 gaofeng For Redmine#35133
                if (errMsg.Length > 0) // ADD 2013/06/20 gaofeng For Redmine#35133
                // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                                  this.Name, 
                                  errMsg, 
                                  0, 
                                  MessageBoxButtons.OK);
                }
            }

            return true;
        }

        /// <summary>
        /// 支払伝票一覧検索前チェック処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票一覧検索前チェックを行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private bool CheckBeforePaymentListSearch()
        {
            string errMsg = "";

            try
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    errMsg = "先に仕入先の検索を行ってください。";
                    this.tNedit_SupplierCd.Focus();
                    return (false);
                }

                int startDate = datePaymentDateStart.GetLongDate();
                int endDate = datePaymentDateEnd.GetLongDate();

                // 支払日（開始）
                if ((startDate != 0) && (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate))))
                {
                    errMsg = "支払日（開始）の日付が不正です。";
                    this.datePaymentDateStart.Focus();
                    return (false);
                }

                // 支払日（終了）
                if ((endDate != 0) && (!TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate))))
                {
                    errMsg = "支払日（終了）の日付が不正です。";
                    this.datePaymentDateEnd.Focus();
                    return (false);
                }

                // 支払日 範囲
                if ((startDate != 0) && (endDate != 0) && (startDate > endDate))
                {
                    errMsg = "支払日の範囲指定が不正です。";
                    this.datePaymentDateStart.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, 
                                  this.Name, 
                                  errMsg, 
                                  0, 
                                  MessageBoxButtons.OK);
                }
            }
            return (true);
        }

		/// <summary>
		/// 画面切替時保存確認
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 画面切替時の画面変更チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・支払先変更時等の入力済みチェックの対象を金額項目のみに変更</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
		/// </remarks>
		private int SaveBeforeClose()
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 2007.09.05 add start --------------------------->>
            if ((_updateMode == ScreenUpdateMode.Reference) || (_updateMode == ScreenUpdateMode.RedReference))
            {
                return status;
            }
            // 2007.09.05 add end -----------------------------<<
			else if (_buffPaymentSlp != null)
			{
                // ADD 2009/12/20 ---->>>>
                PaymentSlp paymentSlp = SetDispToPaymentSlp();
                DateTime paymentDate = new DateTime();
                DateTime addUpADate = new DateTime();
                string outline = string.Empty;

                if (_updateMode == ScreenUpdateMode.New)
                {
                    paymentDate = _buffPaymentSlp.PaymentDate;
                    addUpADate = _buffPaymentSlp.AddUpADate;
                    outline = _buffPaymentSlp.Outline;

                    paymentSlp.PaymentDate = new DateTime();
                    paymentSlp.AddUpADate = new DateTime();
                    paymentSlp.Outline = string.Empty;

                    _buffPaymentSlp.PaymentDate = new DateTime();
                    _buffPaymentSlp.AddUpADate = new DateTime();
                    _buffPaymentSlp.Outline = string.Empty;
                }
                // ADD 2009/12/20 ----<<<<

                //if (!_buffPaymentSlp.Equals(SetDispToPaymentSlp()))    // DEL 2009/12/20
                // ADD 2009/12/20 ---->>>>
                if (!_buffPaymentSlp.Equals(paymentSlp))                 
				{
                    if (_updateMode == ScreenUpdateMode.New)
                    {
                        _buffPaymentSlp.PaymentDate = paymentDate;
                        _buffPaymentSlp.AddUpADate = addUpADate;
                        _buffPaymentSlp.Outline = outline;
                    }
                    // ADD 2009/12/20 ----<<<<
					// 変更中の時
					DialogResult dialogRet = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "現在、編集中のデータが存在します。" + "\r\n\r\n" + "登録してもよろしいですか？", 0, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);
					switch (dialogRet)
					{
						case DialogResult.Yes:
						{
							// 入金伝票保存処理
							this.SaveMainProc();
                            this._savaStatus = 1; // ADD 王君 2012/12/24 Redmine#33741
							break;
						}
						case DialogResult.No:
						{
                            this._savaStatus = 2; // ADD 王君 2012/12/24 Redmine#33741
                            //ADD START 2009/04/28 gejun forM1007A-手形データ追加
                            this._payDraftData = null;
                            this._payDraftDataDel = null;
                            //ADD START 2009/04/28 gejun forM1007A-手形データ追加
                            // --- ADD 2012/10/18 ----------------------------------------->>>>>
                            this._rcvDraftData = null;
                            this._rcvDraftDataDel = null;
                            // --- ADD 2012/10/18 -----------------------------------------<<<<<
							break;
						}
						case DialogResult.Cancel:
						{
                            this._savaStatus = 3; // ADD 王君 2012/12/24 Redmine#33741
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
						}
					}
				}
                else
                {
                    //ADD START 2009/04/28 gejun forM1007A-手形データ追加
                    this._payDraftData = null;
                    this._payDraftDataDel = null;
                    //ADD START 2009/04/28 gejun forM1007A-手形データ追加
                    // --- ADD 2012/10/18 ----------------------------------------->>>>>
                    this._rcvDraftData = null;
                    this._rcvDraftDataDel = null;
                    // --- ADD 2012/10/18 -----------------------------------------<<<<<
                }
                // ADD 2009/12/20 ---->>>>
                if (_updateMode == ScreenUpdateMode.New && _buffPaymentSlp != null)
                {
                    _buffPaymentSlp.PaymentDate = paymentDate;
                    _buffPaymentSlp.AddUpADate = addUpADate;
                    _buffPaymentSlp.Outline = outline;
                }
                // ADD 2009/12/20 ----<<<<
			}
			return status;
		}
		#endregion

		/// <summary>
		/// 新規メイン処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 新規モードにて画面を初期化します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・操作性/入力速度向上のために以下の改良を行う</br>
        /// <br>                ・メニューボタンの有効／無効の設定の対応</br>
        /// <br>                ・伝票登録後に支払一覧を更新しないように変更</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private int NewMainProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // -------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
            int indexKind = -1;
            int indexList = -1;
            GetGuidRowNo(out indexKind, out indexList);
            Control control = new Control();
            bool flag = false;
            if (indexKind != -1 || this.nedtFeePayment.Focused || this.nedtDiscountPayment.Focused)
            {
                if (this.nedtFeePayment.Focused)
                {
                    control = this.nedtFeePayment;
                    flag = true;
                }
                if (this.nedtDiscountPayment.Focused)
                {
                    control = this.nedtDiscountPayment;
                    flag = true;
                }
                this.tNedit_SupplierCd.Focus();
            }
            this._savaStatus = 0;
            // -------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<

			DialogResult dialogRet = DialogResult.OK;
			if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
			{
                // -------- ADD 王君 2012/12/24 Redmine#33741 ------->>>>>
                if (this._savaStatus == 3)
                {
                    if (indexKind != -1)
                    {
                        this.grdPaymentKind.Rows[indexKind].Cells[ctPayment].Activate();
                    }
                    if (indexList != -1)
                    {
                        this.gridPaymentList.Rows[indexList].Activate();
                    }
                    if (flag)
                    {
                        control.Focus();
                    }
                }
                // -------- ADD 王君 2012/12/24 Redmine#33741 -------<<<<<
				dialogRet = DialogResult.Cancel;
			}

			switch (dialogRet)
			{
				case DialogResult.OK:
				{
                    //InitializeDisplay(2);

                    //if (this.gridPaymentList.Rows.Count > 0)
                    //{
                    //    // 支払一覧グリッドの全てのイベントを無効化
                    //    this.gridPaymentList.EventManager.AllEventsEnabled = false;
                    //    this.gridPaymentList.Rows[0].Activate();
                    //    foreach (UltraGridRow ultraGridRow in this.gridPaymentList.Rows)
                    //    {
                    //        if (ultraGridRow.Selected)
                    //        {
                    //            ultraGridRow.Selected = false;
                    //        }
                    //    }
                    //    // 支払一覧グリッドの全てのイベントを有効化
                    //    this.gridPaymentList.EventManager.AllEventsEnabled = true;
                    //}

                    // 画面情報初期化
                    ClearScreen();

                    this._btnNew = false;	        // 新規
                    //this._btnSave = true;	        // 保存         // DEL 2009/12/20
                    this._btnSave = false;	        // 保存         // ADD 2009/12/20
                    this._btnRenewal = true;
                    this._btnDelete = false;	    // 削除
                    this._btnDebitNote = false;     // 赤伝
                    this._btnReadSupSlip = true;    // 伝票呼出     //ADD 王君 2012/12/24 Redmine#33741
                    this._searchFlg = false;

                    // フレームのボタン設定イベント
                    if (ParentToolbarSettingEvent != null)
                    {
                        ParentToolbarSettingEvent(this);
                    }

                    // フォーカス設定
                    // --- DEL 2012/09/07 ---------->>>>>
                    //this.tNedit_SupplierCd.Focus();
                    // --- DEL 2012/09/07 ----------<<<<<
                    // --- ADD 2012/09/07 ---------->>>>>
                    if (_supplierSummary)
                    {
                        this.tEdit_SectionCode.Focus();
                    }
                    else
                    {
                        this.tNedit_SupplierCd.Focus();
                    }
                    // --- ADD 2012/09/07 ----------<<<<<

                    //this.tNedit_SupplierCd.Focus();
					break;
				}
				case DialogResult.Cancel:
				{
					break;
				}
			}

			return status;
		}


        // ↓ 20070519 18322 d Loadイベントに移動したため削除
        #region 金種情報保持用HashTable作成処理
        ///// <summary>
		///// 金種情報保持用HashTable作成処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 金種マスタ取得用のHashTableを作成します。</br>
		///// <br>Programmer	: 22024 寺坂　誉志</br>
		///// <br>Date		: 2006.05.18</br>
		///// </remarks>
		//private void CreateMoneyKindHashTable()
		//{
		//	_moneyKindHashTable = new Hashtable();
		//	if (StokCommonInitDataAcs.MoneyKind != null)
		//	{
		//		MoneyKind[] moneyKindArray = StokCommonInitDataAcs.MoneyKind;
		//		foreach (MoneyKind moneyKind in moneyKindArray)
		//		{
		//			if ((moneyKind.LogicalDeleteCode == 0) &&
		//				(moneyKind.PriceStCode == 0))
		//				_moneyKindHashTable[moneyKind.MoneyKindCode] = moneyKind.Clone();
		//		}
		//	}
        //}
        #endregion
        // ↑ 20070519 18322 d

		/// <summary>
		/// 支払金額合計取得
		/// </summary>
		/// <returns>支払金額の合計</returns>
		/// <remarks>
		/// <br>Note		: 画面より支払金額の合計を取得します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		private double GetPayTotal()
		{
            if (this._searchFlg != true)
            {
                return 0;
            }

            // 支払額
            double payment = GetPayment();

            // 手数料
            double feePayment = this.nedtFeePayment.GetValue();

            // 値引
            double discountPayment = this.nedtDiscountPayment.GetValue();

            // 支払金額 = 支払額＋手数料＋値引
            double total = payment + feePayment + discountPayment;

            return total;
        }

        /// <summary>
        /// 支払金額取得処理
        /// </summary>
        /// <returns>支払金額</returns>
        private double GetPayment()
        {
            if (this._searchFlg != true)
            {
                return 0;
            }

            // 支払額
            double payment = 0;
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                    (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == "")
                {
                    continue;
                }

                double targetValue = double.Parse((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value);

                payment += targetValue;
            }

            return payment;
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払金額合計取得
        /// </summary>
        /// <returns>支払金額の合計</returns>
        /// <remarks>
        /// <br>Note		: 画面より支払金額の合計を取得します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// <br>Update Date : 2006.12.22 18322 木村 武正</br>
        /// <br>              携帯.NS用にインセンティブを追加</br>
        /// <br></br>
        /// </remarks>
        private long GetPayTotal()
        {
            // ↓ 20061222 18322 c インセンティブを追加
            //double total = this.nedtPayment.GetValue() + this.nedtFeePayment.GetValue() + this.nedtDiscountPayment.GetValue();

            // 2007.09.05 upd start -------------------------------------------------->>
            // 支払金額 = 支払額＋手数料＋値引＋インセンティブ(20061222 首藤KKに確認済み)
            //double total = this.nedtPayment.GetValue()
            //             + this.nedtFeePayment.GetValue()
            //             + this.nedtDiscountPayment.GetValue()
            //             + this.nedtRebatePayment.GetValue()
            //             ;
            // 支払金額 = 支払額＋手数料＋値引
            double total = this.nedtPayment.GetValue()
                           + this.nedtFeePayment.GetValue()
                           + this.nedtDiscountPayment.GetValue()
                           ;
            // 2007.09.05 upd end ----------------------------------------------------<<
            // ↑ 20061222 18322 c

            return (long)total;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #region 2007.09.05 del
        // 2007.09.05 del start ------------------------------------------------------->>
        /*
        private void SetCreditCompanyName(string creditCompanyCode, string creditCompanyName)
		{
			// コード無しの時はクリア
			if (creditCompanyCode.Equals(""))
			{
                if (tEdit_BankCode.Text != "")
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new GetCreditCompanyNamePrc.Callback(this.SetCreditCompanyName), new object[]{creditCompanyCode, creditCompanyName});
                    }
                    else
                    {
        				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name, 
								      "該当するクレジット会社が\r\n見つかりませんでした。",
                                      0,
                                      MessageBoxButtons.OK);
                    }
                }
				this.tEdit_BankCode.Text = "";
				this.teditBankName.Text = "";
				return;
			}

			// クレジット会社コードが同一の時
			if (tEdit_BankCode.Text.Equals(creditCompanyCode))
			{
				this.teditBankName.Text = creditCompanyName;
			}
		}
        */
        // 2007.09.05 del end -----------------------------------------------------<<
        #endregion 2007.09.05 del

        // 2007.09.05 add start --------------------------------------------------->>
        /// <summary>
        /// 銀行名称セット処理
        /// </summary>
        /// <param name="bankCode">情報取得用パラメータ 銀行コード</param>
        /// <param name="bankName">銀行名称</param>
        /// <remarks>
        /// <br>Note		: 銀行名称を設定します。</br>
        /// <br>Programmer	: 20081 疋田　勇人</br>
        /// <br>Date		: 2007.09.05</br>
        /// </remarks>
        private void SetBankName(Int32 bankCode, string bankName)
        {
            //// コード無しの時はクリア
            //if (bankCode != 0)
            //{
            //    this.teditBankName.Text = bankName;
            //}
            //else
            //{
            //    this.tEdit_BankCode.Text = "";
            //    this.teditBankName.Text = "";
            //}
        }
        // 2007.09.05 add end -----------------------------------------------------<<

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入在庫全体設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕入在庫全体設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private void GetStockTtlSt()
        {
            int status;
            ArrayList retList = new ArrayList();

            status = this._stockTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (StockTtlSt stockTtlSt in retList)
                {
                    if (stockTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
                    {
                        // 支払伝票日付クリア区分
                        this._paySlipDateClrDiv = stockTtlSt.PaySlipDateClrDiv;
                        // 支払伝票日付範囲区分
                        this._paySlipDateAmbit = stockTtlSt.PaySlipDateAmbit;
                        return;
                    }
                }
            }

            this._paySlipDateClrDiv = 0;
            this._paySlipDateAmbit = 0;
        }

        /// <summary>
        /// 金種情報マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 金種情報マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private void GetMoneyKind()
        {
            int status;
            ArrayList retList = new ArrayList();

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                this._dicMoneyKind = new Dictionary<int, MoneyKind>();

                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                    {
                        this._dicMoneyKind.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }

                return;
            }

            this._dicMoneyKind = new Dictionary<int, MoneyKind>();
        }

        /// <summary>
        /// 支払設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private void GetPaymentSet()
        {
            int status;
            PaymentSet paymentSet = new PaymentSet();

            status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);
            if (status == 0)
            {
                this._dicPaymentSetKind = new Dictionary<int, string>();

                if ((paymentSet.PayStMoneyKindCd1 != 0) && 
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd1)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd1, this._dicMoneyKind[paymentSet.PayStMoneyKindCd1].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd1, 1);
                }
                if ((paymentSet.PayStMoneyKindCd2 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd2)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd2, this._dicMoneyKind[paymentSet.PayStMoneyKindCd2].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd2, 2);
                }
                if ((paymentSet.PayStMoneyKindCd3 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd3)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd3, this._dicMoneyKind[paymentSet.PayStMoneyKindCd3].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd3, 3);
                }
                if ((paymentSet.PayStMoneyKindCd4 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd4)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd4, this._dicMoneyKind[paymentSet.PayStMoneyKindCd4].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd4, 4);
                }
                if ((paymentSet.PayStMoneyKindCd5 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd5)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd5, this._dicMoneyKind[paymentSet.PayStMoneyKindCd5].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd5, 5);
                }
                if ((paymentSet.PayStMoneyKindCd6 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd6)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd6, this._dicMoneyKind[paymentSet.PayStMoneyKindCd6].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd6, 6);
                }
                if ((paymentSet.PayStMoneyKindCd7 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd7)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd7, this._dicMoneyKind[paymentSet.PayStMoneyKindCd7].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd7, 7);
                }
                if ((paymentSet.PayStMoneyKindCd8 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd8)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd8, this._dicMoneyKind[paymentSet.PayStMoneyKindCd8].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd8, 8);
                }
                if ((paymentSet.PayStMoneyKindCd9 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd9)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd9, this._dicMoneyKind[paymentSet.PayStMoneyKindCd9].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd9, 9);
                }
                if ((paymentSet.PayStMoneyKindCd10 != 0) &&
                    (this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd10)))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd10, this._dicMoneyKind[paymentSet.PayStMoneyKindCd10].MoneyKindName.Trim());
                    this._dicPaymentRowNo.Add(paymentSet.PayStMoneyKindCd10, 10);
                }

                return;
            }

            this._dicPaymentSetKind = new Dictionary<int, string>();
            this._dicPaymentRowNo = new Dictionary<int, int>();
        }

        /// <summary>
        /// 支払内訳グリッド設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払内訳グリッドの設定を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>UpdateNote  : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>              支払内訳のスクロールを無くし、入力可能な金種は全て一度に確認できるように修正</br>
        /// </remarks>
        private void SetPaymentKindGrid()
        {
            // データテーブルの列定義
            DataTable dataTable = new DataTable();

            // Addを行う順番が、列の表示順位となります。
            dataTable.Columns.Add(ctMoneyKindDiv, typeof(Int32));       // 金種区分
            dataTable.Columns.Add(ctMoneyKindCode, typeof(Int32));      // 金種コード
            dataTable.Columns.Add(ctMoneyKindName, typeof(string));     // 支払内訳
            dataTable.Columns.Add(ctPayment, typeof(string));           // 支払金額
            dataTable.Columns.Add(ctYear, typeof(string));              // 年(期日)
            dataTable.Columns.Add(ctMonth, typeof(string));             // 月(期日)
            dataTable.Columns.Add(ctDay, typeof(string));               // 日(期日)

            DataRow dataRow;

            foreach (int key in this._dicPaymentSetKind.Keys)
            {
                dataRow = dataTable.NewRow();

                dataRow[ctMoneyKindDiv] = (int)this._dicMoneyKind[key].MoneyKindDiv;
                dataRow[ctMoneyKindCode] = key;
                dataRow[ctMoneyKindName] = (string)this._dicMoneyKind[key].MoneyKindName.Trim();
                dataRow[ctPayment] = "";
                dataRow[ctYear] = DBNull.Value;
                dataRow[ctMonth] = DBNull.Value;
                dataRow[ctDay] = DBNull.Value;

                dataTable.Rows.Add(dataRow);
            }

            this.grdPaymentKind.DataSource = dataTable;

            // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>
            // string moneyFormat = "#,##0;-#,##0;''";
            // DEL 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<
            // ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ---------->>>>>
            string moneyFormat = "#,##0;-#,##0";
            // ADD 2010/04/30 MANTIS対応[15200]：入金内訳に0円も表示する ----------<<<<<

            // --- 支払内訳バンド --- //
            ColumnsCollection pareColumns = this.grdPaymentKind.DisplayLayout.Bands[0].Columns;

            // ADD 2009/12/20 ---------->>>>>
            int rowCount = this.grdPaymentKind.Rows.Count;
            if (rowCount < 6)
            {
                int height = (this.grdPaymentKind.Rows[0].Height - 1) * (6 - rowCount);
                this.grdPaymentKind.Height = this.grdPaymentKind.Height - height;
                this.ultraLabel60.Location = new System.Drawing.Point(5, this.ultraLabel60.Location.Y - height);
                this.ultraLabel62.Location = new System.Drawing.Point(5, this.ultraLabel62.Location.Y - height);
                this.ultraLabel61.Location = new System.Drawing.Point(5, this.ultraLabel61.Location.Y - height);
                this.ultraLabel65.Location = new System.Drawing.Point(5, this.ultraLabel65.Location.Y - height);
                this.nedtFeePayment.Location = new System.Drawing.Point(88, this.nedtFeePayment.Location.Y - height);
                this.nedtDiscountPayment.Location = new System.Drawing.Point(88, this.nedtDiscountPayment.Location.Y - height);
                this.nedtPaymentTotal.Location = new System.Drawing.Point(88, this.nedtPaymentTotal.Location.Y - height);
                this.editOutline.Location = new System.Drawing.Point(88, this.editOutline.Location.Y - height);
            }
            else if (rowCount == 7)
            {
                int height = this.grdPaymentKind.Rows[0].Height * (rowCount - 6) - 1;
                this.grdPaymentKind.Height = this.grdPaymentKind.Height + height;
                this.ultraLabel60.Location = new System.Drawing.Point(5, this.ultraLabel60.Location.Y + height);
                this.ultraLabel62.Location = new System.Drawing.Point(5, this.ultraLabel62.Location.Y + height);
                this.ultraLabel61.Location = new System.Drawing.Point(5, this.ultraLabel61.Location.Y + height);
                this.ultraLabel65.Location = new System.Drawing.Point(5, this.ultraLabel65.Location.Y + height);
                this.nedtFeePayment.Location = new System.Drawing.Point(88, this.nedtFeePayment.Location.Y + height);
                this.nedtDiscountPayment.Location = new System.Drawing.Point(88, this.nedtDiscountPayment.Location.Y + height);
                this.nedtPaymentTotal.Location = new System.Drawing.Point(88, this.nedtPaymentTotal.Location.Y + height);
                this.editOutline.Location = new System.Drawing.Point(88, this.editOutline.Location.Y + height);
            }
            else if (rowCount > 7)
            {
                int height = this.grdPaymentKind.Rows[0].Height * (rowCount - 6) - 2;
                this.grdPaymentKind.Height = this.grdPaymentKind.Height + height;
                this.ultraLabel60.Location = new System.Drawing.Point(5, this.ultraLabel60.Location.Y + height);
                this.ultraLabel62.Location = new System.Drawing.Point(5, this.ultraLabel62.Location.Y + height);
                this.ultraLabel61.Location = new System.Drawing.Point(5, this.ultraLabel61.Location.Y + height);
                this.ultraLabel65.Location = new System.Drawing.Point(5, this.ultraLabel65.Location.Y + height);
                this.nedtFeePayment.Location = new System.Drawing.Point(88, this.nedtFeePayment.Location.Y + height);
                this.nedtDiscountPayment.Location = new System.Drawing.Point(88, this.nedtDiscountPayment.Location.Y + height);
                this.nedtPaymentTotal.Location = new System.Drawing.Point(88, this.nedtPaymentTotal.Location.Y + height);
                this.editOutline.Location = new System.Drawing.Point(88, this.editOutline.Location.Y + height);
            }

            // ADD 2009/12/20 ----------<<<<<

            // 金種区分
            pareColumns[ctMoneyKindDiv].Header.Caption = "金種区分";
            pareColumns[ctMoneyKindDiv].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[ctMoneyKindDiv].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctMoneyKindDiv].Hidden = true;

            // 金種コード
            pareColumns[ctMoneyKindCode].Header.Caption = "金種コード";
            pareColumns[ctMoneyKindCode].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[ctMoneyKindCode].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctMoneyKindCode].Hidden = true;

            // 支払内訳
            pareColumns[ctMoneyKindName].Header.Caption = "支払内訳";
            pareColumns[ctMoneyKindName].Header.Appearance.FontData.SizeInPoints = 10;
            pareColumns[ctMoneyKindName].CellActivation = Activation.Disabled;
            pareColumns[ctMoneyKindName].CellAppearance.ForeColorDisabled = Color.Black;
            pareColumns[ctMoneyKindName].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[ctMoneyKindName].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctMoneyKindName].CellAppearance.FontData.SizeInPoints = 10;
            pareColumns[ctMoneyKindName].Width = 105;

            // 支払金額
            pareColumns[ctPayment].Header.Caption = "支払金額";
            pareColumns[ctPayment].Header.Appearance.FontData.SizeInPoints = 10;
            pareColumns[ctPayment].CellAppearance.ForeColorDisabled = Color.Black;
            pareColumns[ctPayment].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[ctPayment].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctPayment].CellAppearance.FontData.SizeInPoints = 10;
            pareColumns[ctPayment].Width = 104;
            pareColumns[ctPayment].Format = moneyFormat;

            // 年
            pareColumns[ctYear].Header.Caption = "年";
            pareColumns[ctYear].Header.Appearance.FontData.SizeInPoints = 10;
            pareColumns[ctYear].CellAppearance.ForeColorDisabled = Color.Black;
            // --- UPD m.suzuki 2010/07/12 ---------->>>>>
            //pareColumns[ctYear].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[ctYear].CellAppearance.TextHAlign = HAlign.Right;
            // --- UPD m.suzuki 2010/07/12 ----------<<<<<
            pareColumns[ctYear].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctYear].CellAppearance.FontData.SizeInPoints = 10;
            pareColumns[ctYear].Width = 49;
            // 月
            pareColumns[ctMonth].Header.Caption = "月";
            pareColumns[ctMonth].Header.Appearance.FontData.SizeInPoints = 10;
            pareColumns[ctMonth].CellAppearance.ForeColorDisabled = Color.Black;
            // --- UPD m.suzuki 2010/07/12 ---------->>>>>
            //pareColumns[ctMonth].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[ctMonth].CellAppearance.TextHAlign = HAlign.Right;
            // --- UPD m.suzuki 2010/07/12 ----------<<<<<
            pareColumns[ctMonth].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctMonth].CellAppearance.FontData.SizeInPoints = 10;
            pareColumns[ctMonth].Width = 35;
            // 日
            pareColumns[ctDay].Header.Caption = "日";
            pareColumns[ctDay].Header.Appearance.FontData.SizeInPoints = 10;
            pareColumns[ctDay].CellAppearance.ForeColorDisabled = Color.Black;
            // --- UPD m.suzuki 2010/07/12 ---------->>>>>
            //pareColumns[ctDay].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[ctDay].CellAppearance.TextHAlign = HAlign.Right;
            // --- UPD m.suzuki 2010/07/12 ----------<<<<<
            pareColumns[ctDay].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[ctDay].CellAppearance.FontData.SizeInPoints = 10;
            pareColumns[ctDay].Width = 35;

            for (int index = 0; index < this.grdPaymentKind.Rows.Count; index++)
            {
                this.grdPaymentKind.Rows[index].Cells[ctYear].Activation = Activation.Disabled;
                this.grdPaymentKind.Rows[index].Cells[ctMonth].Activation = Activation.Disabled;
                this.grdPaymentKind.Rows[index].Cells[ctDay].Activation = Activation.Disabled;

                this.grdPaymentKind.Rows[index].Cells[ctPayment].Tag = 0;
            }
        }

        /// <summary>
        /// カンマ削除処理
        /// </summary>
        /// <param name="targetText">カンマ削除前テキスト</param>
        /// <param name="retText">カンマ削除済みテキスト</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストからカンマを削除します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        private string RemoveComma(string targetText)
        {
            string retText = "";

            // セル値編集用にカンマ削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

            retText = targetText;

            return retText;
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが読み込まれるタイミングで発生します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/07  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private void SFSIR02102UA_Load(object sender, EventArgs e)
		{
            // --- ADD 2012/09/07 ---------->>>>>
            if (!_supplierSummary) 
            {
                // 拠点コード、拠点ガイドボタン、拠点テキストボックス非表示
                Section_uLabel.Visible = false;
                tEdit_SectionCode.Visible = false;
                uButton_SectionGuide.Visible = false;
                lblSectionNm.Visible = false;

                // 位置調整
                ultraLabel54.Location = ultraLabel52.Location;
                lblTotalDay.Location = tNedit_SupplierCd.Location;

                ultraLabel52.Location = Section_uLabel.Location;
                tNedit_SupplierCd.Location = tEdit_SectionCode.Location;
                uButton_StockCustomerGuide.Location = uButton_SectionGuide.Location;
                lblCustNm.Location = lblSectionNm.Location;

                Size size = new Size();
                size.Width = 984;
                size.Height = 113;
                pnlTop.Size = size;

            }
            // --- ADD 2012/09/07 ----------<<<<<

			this._btnNew			    = false;	// 新規
            this._btnSave               = false;	// 保存
            this._btnRenewal = true;
            this._btnDelete             = false;	// 削除
            this._btnDebitNote          = false;	// 赤伝
            this._receiptPrintButton    = false;    // 領収書
            this._btnReadSupSlip        = true;     // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741

            this._searchFlg = false;

            // ADD START 2009/05/11 gejun forM1007A-手形データ追加
            // 手形管理オプションが成立判断
            int draftOption = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_DraftMng);
            if (draftOption > 0)
                this._draftOptSet = true;
            else
                this._draftOptSet = false;
            // ADD END 2009/05/11 gejun forM1007A-手形データ追加

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

			// フレームのボタン設定イベント
			ParentToolbarSettingEvent(this);

			// グリッドにDataTableをバインド
            this._paymentListDataTable = this._paymentSlpSearch.GetPaymentInfoDataTable();
            this.gridPaymentList.DataSource = this._paymentListDataTable;

            //SetGridLayout(); // DEL 王君 2013/02/07 Redmine#33741

            // 画面状態読込
            LoadStateXmlData();

            SetGridLayout(); // ADD 王君 2013/02/07 Redmine#33741

            // 金種情報マスタ取得
            GetMoneyKind();

            // 支払設定マスタ取得
            GetPaymentSet();

            // 仕入在庫全体設定マスタ取得
            GetStockTtlSt();

            // 支払内訳グリッド設定
            SetPaymentKindGrid();

			// 画面初期化処理
			InitializeDisplay(0);

            // フォーカス設定
            // --- DEL 2012/09/07 ---------->>>>>
            //this.tNedit_SupplierCd.Focus();
            // --- DEL 2012/09/07 ----------<<<<<
            // --- ADD 2012/09/07 ---------->>>>>
            if (_supplierSummary)
            {
                this.tEdit_SectionCode.Focus();
            }
            else
            {
            this.tNedit_SupplierCd.Focus();
            }
            // --- ADD 2012/09/07 ----------<<<<<

            this.pnlLeft.Width = 357;

            uceAutoFitCol_CheckedChanged(null, null); //  ADD 王君 2013/02/07 Redmine#33741
        }

        private void SetGridLayout()
        {
            // 支払伝票番号
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Width = 100;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Header.Caption
                = "支払番号";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].CellAppearance.TextHAlign
                = HAlign.Right;
            // 支払日付
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Width = 110;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Header.Caption
                = "支払日";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Header.Caption
                = "計上日";
            // 支払金種名称
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Width = 150;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Header.Caption
                = "金種";
            // 支払金額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Header.Caption
                = "支払金額";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Format = "#,##0";
            // 手数料支払額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Width = 11;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Header.Caption
                = "手数料";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Format = "#,##0";
            // 値引支払額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Width = 110;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Header.Caption
                = "値引";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Format = "#,##0";
            // 支払金額計
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Header.Caption
                = "支払計";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Format = "#,##0";
            // 伝票摘要
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Header.Caption
                = "摘要";
            // 締フラグ
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG].Header.Caption
                = "締";
            // 赤伝区分
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Header.Caption
                = "赤黒種類";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Hidden = true;

            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            // 支払入力者名称
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Width = 150;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Header.Caption
                = "入力担当者";
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----- >>>>>
            //仕入先コード
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Hidden = true;
            //仕入先名
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Hidden = true; 
            // グリッド設定情報取得
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref gridPaymentList);

            if (gridStateInfo != null)
            {
                // グリッドに設定セット
                this._gridStateController.SetGridStateToGrid(ref gridPaymentList);
                // フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
                cmbFontSize.Tag = false;
                cmbFontSize.Value = (int)gridStateInfo.FontSize;
                cmbFontSize.Tag = true;
                // 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
                uceAutoFitCol.Tag = false;
                uceAutoFitCol.Checked = gridStateInfo.AutoFit;
                uceAutoFitCol.Tag = true;
            }
            else
            {
                // フォントサイズ ValueChangedイベント内の列サイズ変更を不可にする
                cmbFontSize.Tag = false;
                cmbFontSize.Value = 11;
                cmbFontSize.Tag = true;
                // 列の自動調整 ValueChangedイベント内の列サイズ変更を不可にする
                uceAutoFitCol.Tag = false;
                uceAutoFitCol.Checked = false;
                uceAutoFitCol.Tag = true;
            }
            // ------ ADD 王君 2012/12/24 Redmine#33741 ----- <<<<<
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームが読み込まれるタイミングで発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// </remarks>
        private void SFSIR02102UA_Load(object sender, EventArgs e)
        {
            _btnNew = false;	// 新規
            _btnSave = false;	// 保存
            _btnDelete = false;	// 削除
            _btnDebitNote = false;	// 赤伝
            _receiptPrintButton = false;// 領収書

            // ↓ 20070213 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070213 18322 a

            // フレームのボタン設定イベント
            ParentToolbarSettingEvent(this);

            // グリッドにDataTableをバインド
            _paymentListDataTable = _paymentSlpSearch.GetPaymentInfoDataTable();
            this.gridPaymentList.DataSource = _paymentListDataTable;

            // 画面状態読込
            LoadStateXmlData();

            // ↓ 20070519 18322 a 支払設定情報、金種情報取得
            // 支払設定
            PaymentSetAcs paymentSetAcs = new PaymentSetAcs();
            paymentSetAcs.Read(out this._paymentSet, this._enterpriseCode, 0);
            
            // 金種情報取得
            _moneyKindHashTable.Clear();
            MoneyKindAcs moneyKindAcs = new MoneyKindAcs();
            ArrayList moneyKindList;
            int status = moneyKindAcs.GetBuff(out moneyKindList, this._enterpriseCode, 0);
            if (status == 0)
            {
				foreach (MoneyKind moneyKind in moneyKindList)
				{
					if ((moneyKind.LogicalDeleteCode == 0) &&
						(moneyKind.PriceStCode       == 0)   )
                    {
                        // 金額設定区分が0:入金を使用
						_moneyKindHashTable[moneyKind.MoneyKindCode] = moneyKind.Clone();
                    }
				}
            }
            // ↑ 20070519 18322 a

            // 画面初期化処理
            InitializeDisplay(0);

            //this.StartTimer.Enabled = true;  // 2007.09.05 del

            this.tNedit_SupplierCd.Focus();       // 2007.09.05 add 
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #region 2007.09.05 del
        // 2007.09.05 del start --------------------------------------------->>
        /*
        private void btnCreditCompanyGuid_Click(object sender, EventArgs e)
		{
			CreditCmp creditCmp;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// クレジット会社ガイド起動
				if (_creditCmpAcs.ExecuteGuid(_enterpriseCode, _selectSectionCode, out creditCmp) == 0)
				{
					this.tEdit_BankCode.Text	= creditCmp.CreditCompanyCode;
					this.teditBankName.Text= creditCmp.CreditCompanyName;
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
        */
        // 2007.09.05 del end -----------------------------------------------<<
        #endregion 2007.09.05 del

        // 2007.09.05 add start --------------------------------------------->>
        /// <summary>
        /// 銀行ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 銀行ガイドボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer	: 20081 疋田　勇人</br>
        /// <br>Date		: 2007.09.05</br>
        /// </remarks>
        private void btnBankGuid_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ユーザーガイド起動
                
                if (_userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 46) == 0)
                {
                    //// --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
                    //if (userGdBd.GuideCode == this._prevBankCode)
                    //{
                    //    // フォーカス設定
                    //    this.dateDraftDrawingDate.Focus();

                    //    return;
                    //}

                    //this._prevBankCode = userGdBd.GuideCode;
                    //// --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

                    //this.tEdit_BankCode.SetInt(userGdBd.GuideCode);
                    //this.teditBankName.Text = userGdBd.GuideName;

                    //// --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
                    //// フォーカス設定
                    //this.dateDraftDrawingDate.Focus();
                    //// --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // 2007.09.05 add end -----------------------------------------------<<

        #region 2007.09.05 del
        // 2007.09.05 del start ---------------------------------------------->>
        //private void cmbCreditOrLoanCd_ValueChanged(object sender, EventArgs e)
		//{
		//	if (this.cmbDraftKind.SelectedIndex == 0)
		//	{
		//		this.tEdit_BankCode.ReadOnly	= true;
		//		this.btnBankGuid.Enabled	= false;
		//		this.tEdit_BankCode.Clear();
		//		this.teditBankName.Clear();
		//	}
		//	else
		//	{
		//		this.tEdit_BankCode.ReadOnly	= false;
		//		this.btnBankGuid.Enabled	= true;
		//	}
		//}
        // 2007.09.05 del end ------------------------------------------------<<
        #endregion 2007.09.05 del

        /// <summary>
		/// 列サイズの自動調整チェックチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: チェックボックスのチェック状態が変更されたタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2013/02/07  王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
            if (this.gridPaymentList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !this.uceAutoFitCol.Checked) return;//  ADD 王君 2013/02/07 Redmine#33741

			if (this.gridPaymentList.DataSource != null)
			{
				if (this.uceAutoFitCol.Checked)
				{
					this.gridPaymentList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
				}
				else
				{
					this.gridPaymentList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
				}

				foreach (UltraGridColumn col in this.gridPaymentList.DisplayLayout.Bands[0].Columns)
				{
					if (col.Key != PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE)
					{
						col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
					}
				}
			}
		}

		/// <summary>
		/// 詳細チェックチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: チェックボックスのチェック状態が変更されたタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
		/// </remarks>
		private void uceShowDetail_CheckedChanged(object sender, EventArgs e)
		{
			// 支払金額
			this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Hidden
				= !this.uceShowDetail.Checked;
			// 手数料支払額
			this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Hidden
				= !this.uceShowDetail.Checked;
			// 値引支払額
			this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Hidden
				= !this.uceShowDetail.Checked;
            // ↓ 20061222 18322 a
            // インセンティブ支払額                                                                                      // 2007.09.05 del
            //this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT].Hidden  // 2007.09.05 del
            //    = !this.uceShowDetail.Checked;

            // 赤黒
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Hidden = true;
            // ↑ 20061222 18322 a
            //----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Hidden = true;
            //----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            // 支払入力者名称
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Hidden
                = !this.uceShowDetail.Checked;
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<

            foreach (UltraGridColumn col in this.gridPaymentList.DisplayLayout.Bands[0].Columns)
            {
                if (col.Key != PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE)
                {
                    col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
                }
            }
        }

        #region 2007.09.05 del
        // 2007.09.05 del start ------------------------------------------------------->>
        ///// <summary>
        ///// 検索ボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントハンドラ</param>
        ///// <remarks>
        ///// <br>Note		: 検索ボタンが押下されたタイミングで発生します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
        ///// <br>Date		: 2006.05.18</br>
        ///// </remarks>
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    Control control;
        //    if (CheckBeforePaymentListSearch(out control, true))
        //    {
        //        status = SearchAllPaymentInfo(this.tNedit_SupplierCd.GetInt());
        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                _btnNew		= true;	// 新規

        //                // 画面初期化処理
        //                InitializeDisplay(1);
        //                break;
        //            }
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            {
        //                // 画面初期化処理
        //                InitializeDisplay(1);

        //                _btnNew		= false;	// 新規
        //                _btnSave	= false;	// 保存
        //                _btnDelete	= false;	// 削除
        //                // ↓ 20061222 18322 a
        //                _btnDebitNote = false;  // 赤伝
        //                // ↑ 20061222 18322 a

        //                // フレームのボタン設定イベント
        //                if (ParentToolbarSettingEvent != null)
        //                    ParentToolbarSettingEvent(this);

        //                // 仕入先情報のクリア
        //                this.lblSupplierCd.Clear();
        //                this.lblCustNm.Clear();
        //                this.lblTotalDay.Clear();
        //                this.lblPaySpan.Text				= string.Empty;
        //                this.lblSuppCTaxLayMethodNm.Text	= string.Empty;

        //                // 鑑のクリア
        //                // ↓ 20070529 18322 c 鏡部分の項目を変更
        //                //this.lblStockTtlLMBlPay.Text		= string.Empty;
        //                //this.lblStockPriceTtlPayment.Text	= string.Empty;
        //                //this.lblStockTtlConsTaxPay.Text		= string.Empty;
        //                //this.lblTotalPayment.Text			= string.Empty;
        //                //this.lblStockTotalPayBalance.Text	= string.Empty;
        //                // 前回支払額
        //                this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;
        //                // 今回支払
        //                this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;
        //                // 今回仕入
        //                this.lbl_ThisTimePayNrml.Text = string.Empty;
        //                // 今回仕入（消費税）
        //                this.lbl_Balance.Text = string.Empty;
        //                // 相殺後仕入
        //                this.lbl_ThisTimeStockPrice.Text = string.Empty;
        //                // 相殺後仕入(消費税)
        //                this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;
        //                // 支払金額(残高)
        //                this.StockTotalPayBalance.Text = string.Empty;
        //                // ↑ 20070529 18322 c
                        
        //                // モードをクリア
        //                this.lblMode.Text					= string.Empty;

        //                // グリッドをクリア
        //                this._paymentListDataTable.Rows.Clear();

        //                this.btnSearch.Focus();
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        control.Focus();
        //    }
        //}
        // 2007.09.05 del end ---------------------------------------------------------<<
        #endregion 2007.09.05 del

        /// <summary>
		/// 再検索ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 再検索ボタンが押下されたタイミングで発生します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・伝票登録後に支払一覧を更新しないように変更</br>
		/// </remarks>
		private void btnSearchPayList_Click(object sender, EventArgs e)
		{

            this._detailsShowFlg = true;  // ADD 2009/12/20

            // 支払伝票一覧検索前チェック処理
			if (CheckBeforePaymentListSearch())
			{
                if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {
                    return;
                }

  				// 支払伝票呼出処理
				int status = ReSearchPaymentInfo();

                this._firstFlg = true;

                // 画面初期化処理
                InitializeDisplay(1);
			}
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 再検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 再検索ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// </remarks>
        private void btnSearchPayList_Click(object sender, EventArgs e)
        {
            Control control = null;
            if (CheckBeforePaymentListSearch(out control, false))
            {
                // 支払伝票呼出処理
                int status = ReSearchPaymentInfo();
            }
            else
            {
                control.Focus();
            }
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
        /// 起動タイマーイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: タイマー処理にて発生します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.18</br>
        /// </remarks>
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            this.StartTimer.Enabled = false;

            // 仕入先番号
            this.tNedit_SupplierCd.Focus();
        }
        
		/// <summary>
		/// 支払伝票一覧初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッドの初期化時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void gridPaymentList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			// 支払伝票番号
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Width = 100;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Header.Caption
				= "支払番号";
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].CellAppearance.TextHAlign
				= HAlign.Right;
			// 支払日付
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Width = 100;
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Header.Caption
                = "支払日";
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            // 2007.09.05 add start -------------------------------------->>
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Hidden = true;
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Header.Caption
            //    = "支払日";
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Header.Caption
                = "計上日";
            // 2007.09.05 add end ----------------------------------------<<
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 支払金種名称
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Width = 150;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Header.Caption
				= "金種";
			// 支払金額
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Header.Caption
				= "支払金額";
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].CellAppearance.TextHAlign
				= HAlign.Right;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Hidden = true;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Format = "#,##0";
			// 手数料支払額
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Width = 11;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Header.Caption
				= "手数料";
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].CellAppearance.TextHAlign
				= HAlign.Right;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Hidden = true;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Format = "#,##0";
			// 値引支払額
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Width = 110;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Header.Caption
				= "値引";
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].CellAppearance.TextHAlign
				= HAlign.Right;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Hidden = true;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Format = "#,##0";

            // ↓ 20061222 18322 a
            // 2007.09.05 del start --------------------------------------------------------->>
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT].Header.Caption
            //    = "インセンティブ";
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT].CellAppearance.TextHAlign
            //    = HAlign.Right;
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT].Hidden = true;
            //e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT].Format = "#,##0";
            // 2007.09.05 del end -----------------------------------------------------------<<
            // ↑ 20061222 18322 a

			// 支払金額計
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Width = 130;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Header.Caption
				= "支払計";
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].CellAppearance.TextHAlign
				= HAlign.Right;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Format = "#,##0";
			// 伝票摘要
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Width = 130;
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Header.Caption
				= "摘要";
			// 締フラグ
			e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG].Header.Caption
				= "締";

            // ↓ 20061222 18322 a
            // 赤伝区分
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Header.Caption
                = "赤黒種類";
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Hidden = true;
            // ↑ 20061222 18322 a

            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            // 支払入力者名称
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Width = 150;
            e.Layout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Header.Caption
                = "入力担当者";
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<
		}

		/// <summary>
		/// 支払伝票一覧行初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行の初期化が発生したタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void gridPaymentList_InitializeRow(object sender, InitializeRowEventArgs e)
		{
//			foreach (UltraGridColumn col in this.gridPaymentList.DisplayLayout.Bands[0].Columns)
//			{
//				if (col.Key != PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE)
//				{
//					col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
//				}
//			}

            // ↓ 20061222 18322 a
            // 赤伝の時は文字色を赤くするように変更
            if (e.Row.Cells[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Value is int)
            {
                switch ((int)e.Row.Cells[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Value)
                {
                    case 1:    // 赤伝
                        e.Row.Appearance.ForeColor = Color.Red;
                        break;
                    case 2:    // 相殺済み黒伝
                        e.Row.Appearance.ForeColor = Color.DarkOrchid;
                        break;
                    default:
                        e.Row.Appearance.ForeColor = Color.Black;
                        break;
                }
            }
            else
            {
                e.Row.Appearance.ForeColor = Color.Black;
            }
            // ↑ 20061222 18322 a
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払伝票一覧行アクティブ状態解除イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行が非アクティブ化する前に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void gridPaymentList_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 支払伝票一覧選択行変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行の選択が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void gridPaymentList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
		{
            UltraGridRow ultraGridRow = this.gridPaymentList.ActiveRow;
            if (ultraGridRow != null)
            {
                // 現在選択中のGridRowに対応するDataRowを取得
                DataRow dr = _paymentListDataTable.Rows[ultraGridRow.ListIndex];

                PaymentSlp paymentSlp;
                int paymentSlipNo = TStrConv.StrToIntDef(dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);
                _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
                if (paymentSlp != null)
                {
                    // 支払伝票画面表示
                    SetPaymentSlpToDisp(paymentSlp);
                }
            }
        }

		/// <summary>
		/// 金種キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 金種にてキーが入力された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void treeMoneyKind_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				{
					if (this.treeMoneyKind.ActiveNode != null)
					{
						if (this.treeMoneyKind.ActiveNode.Index == 0)
						{
							this.datePaymentDate.Focus();
						}
					}
					break;
				}
				case Keys.Down:
				{
					if (this.treeMoneyKind.ActiveNode != null)
					{
						if (this.treeMoneyKind.ActiveNode.Index == this.treeMoneyKind.Nodes.Count - 1)
						{
							this.nedtPayment.Focus();
						}
					}
					break;
				}
				case Keys.Right:
				{
					this.gridPaymentList.Focus();
					if (this.gridPaymentList.ActiveRow != null)
					{
						if (!this.gridPaymentList.ActiveRow.Selected)
						{
							if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
							{
								this.treeMoneyKind.Focus();
								return;
							}
							else
							{
								this.gridPaymentList.ActiveRow.Selected = true;
							}
						}
					}
					break;
				}
			}
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
		/// 支払伝票一覧キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 支払伝票一覧にてキーが入力された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void gridPaymentList_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				{
					if (this.gridPaymentList.ActiveRow != null)
					{
						if (this.gridPaymentList.ActiveRow.Index == 0)
						{
							this.datePaymentDateStart.Focus();
						}
					}
					break;
				}
				case Keys.Down:
				{
					if (this.gridPaymentList.ActiveRow != null)
					{
						if (this.gridPaymentList.ActiveRow.Index == this.gridPaymentList.Rows.Count - 1)
						{
							this.cmbFontSize.Focus();
						}
					}
					break;
				}
				case Keys.Left:
				{
					e.Handled = true;
                    // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                    //this.treeMoneyKind.Focus();
                    if (this.grdPaymentKind.Rows.Count > 0)
                    {
                        this.grdPaymentKind.Focus();
                        this.grdPaymentKind.Rows[0].Cells[ctPayment].Activate();
                        this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.datePaymentDate.Focus();
                    }
                    // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                    break;
				}
			}
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 金種エンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 金種がアクティブになった時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void treeMoneyKind_Enter(object sender, EventArgs e)
		{
			// アクティブノード＝選択ノードにする
			if (this.treeMoneyKind.ActiveNode != null)
			{
				this.treeMoneyKind.PerformAction(UltraTreeAction.SelectActiveNode, false, false);
			}
		}

		/// <summary>
		/// 金種ツリー項目クリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 金種ツリーをクリックした時に発生します。</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.05.30</br>
		/// </remarks>
        private void treeMoneyKind_Click(object sender, EventArgs e)
        {
			// カーソルがノードをクリックしたか取得
			Point pt = treeMoneyKind.PointToClient(Cursor.Position);
			Infragistics.Win.UIElement uielement = treeMoneyKind.UIElement.ElementFromPoint(new Point(pt.X, pt.Y));
			Infragistics.Win.UltraWinTree.UltraTreeNode nd = uielement.GetContext(typeof(Infragistics.Win.UltraWinTree.UltraTreeNode)) as Infragistics.Win.UltraWinTree.UltraTreeNode;
			if (nd != null)
			{
				nd.CheckedState = CheckState.Checked;
			}
        }

		/// <summary>
		/// 金種変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: OptionButtonのCheckedStateが変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void treeMoneyKind_AfterCheck(object sender, NodeEventArgs e)
		{
			// 手形関連項目を全て入力不可に設定
			this.dateDraftDrawingDate.ReadOnly = true;     // 振出日
			this.dateDraftPayTimeLimit.ReadOnly = true;    // 支払期日

            // 2007.09.05 add start ---------------------------->>
            this.cmbDraftKind.ReadOnly = true;             // 手形種類
            this.cmbDraftDivide.ReadOnly = true;             // 手形区分
            this.tEdit_BankCode.Enabled = false;             // 銀行コード
            this.btnBankGuid.Enabled = false;              // 銀行ガイド
            this.tEdit_DraftNo.Enabled = false;               // 手形番号
            // 2007.09.05 add end ------------------------------<<

			int moneyKindCode = TStrConv.StrToIntDef(e.TreeNode.Key, 0);
			if (_moneyKindHashTable.ContainsKey(moneyKindCode))
			{
				MoneyKind moneyKind = (MoneyKind)_moneyKindHashTable[moneyKindCode];
				switch (moneyKind.MoneyKindDiv)
				{
                    // 2007.09.05 upd start ------------------->>
					//case (int)MnyKindDiv.Credit:
					//case (int)MnyKindDiv.Loan:
					//{
					//	this.cmbDraftKind.ReadOnly = false;
					//	if (this.cmbDraftKind.SelectedIndex > 0)
					//	{
					//		this.btnBankGuid.Enabled = true;
					//	}
						// 手形関連の項目をクリア
					//	this.dateDraftDrawingDate.Clear();
					//	this.dateDraftPayTimeLimit.Clear();
					//	break;
					//}
   					//case (int)MnyKindDiv.Bill:
					//{
					//	this.dateDraftDrawingDate.ReadOnly = false;
					//	this.dateDraftPayTimeLimit.ReadOnly = false;
						// クレジット関連の項目をクリア
					//	this.cmbDraftKind.SelectedIndex = 0;
					//	break;
					//}
					//default:
					//{
						// クレジット・手形関連の項目をクリア
					//	this.cmbDraftKind.SelectedIndex = 0;
					//	this.dateDraftDrawingDate.Clear();
					//	this.dateDraftPayTimeLimit.Clear();
					//	break;
					//}
                    case (int)MnyKindDiv.Check:
                        {
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;
                            this.dateDraftDrawingDate.ReadOnly = false;
                            break;
                        }
                    case (int)MnyKindDiv.Remittance:
                        {
                            this.tEdit_BankCode.ReadOnly = false;
                            this.tEdit_BankCode.Enabled = true;
                            this.btnBankGuid.Enabled = true;
                            break;
                        }
                    case (int)MnyKindDiv.Bill:
                    case (int)MnyKindDiv.ACheck:
                        {
                        this.tEdit_BankCode.Enabled = true;
                        this.btnBankGuid.Enabled = true;
                        this.dateDraftDrawingDate.ReadOnly = false;
                        this.tEdit_DraftNo.Enabled = true;                 // 手形番号
                        this.cmbDraftKind.ReadOnly = false;             // 手形種類
                        this.cmbDraftDivide.ReadOnly = false;             // 手形区分
                        this.dateDraftPayTimeLimit.ReadOnly = false;    // 支払期日
                        break;
                        }
                    default:
                        {
                        this.tEdit_BankCode.Clear();
                        this.dateDraftDrawingDate.Clear();
                        this.tEdit_DraftNo.Clear();                        // 手形番号
                        this.cmbDraftKind.SelectedIndex = 0;            // 手形種類
                        this.cmbDraftDivide.SelectedIndex = 0;            // 手形区分
                        this.dateDraftPayTimeLimit.Clear();             // 支払期日
                        break;
                        }
                    // 2007.09.05 upd end ---------------------<<
				}
			}
		}

        /// <summary>
		/// tArrowKeyControlChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
        /// <br>Update Date : 2006.12.22 18322 木村 武正</br>
        /// <br>              携帯.NS用にインセンティブを追加</br>
        /// <br>Update Date : 2007.09.05 20081 疋田 勇人</br>
        /// <br>              DC.NS用に項目変更</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
            // 2007.09.05 add start -------------------------->>
            // 仕入先コードを入力した時点で検索
            if ((e.PrevCtrl.Name == "tNedit_SupplierCd") && (this.tNedit_SupplierCd.GetInt() != 0))
            {
                // 管理拠点コード取得(得意先マスタ)
                CustomerInfo customerInfo;
                CustSuppli customerSuppli;
                string sectionNm = string.Empty;

                int status1 = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, 
                                                                             this._enterpriseCode, 
                                                                             this.tNedit_SupplierCd.GetInt(), 
                                                                             true, 
                                                                             out customerInfo, 
                                                                             out customerSuppli);
                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 支払計上拠点の取得
                    
                    SecInfoSet secInfoSet;
                    _secInfoAcs.GetSecInfo(customerInfo.MngSectionCode, SecInfoAcs.CtrlFuncCode.PayAddUpSecCd, out secInfoSet);
                    if (secInfoSet != null)
                    {
                        this._selectSectionCode = secInfoSet.SectionCode;
                        sectionNm = secInfoSet.SectionGuideNm;
                    }
                    
                }
                // 拠点名称をフレームに渡す
                if (HandOverAddUpSecNameEvent != null) HandOverAddUpSecNameEvent(this, sectionNm);

                // 支払情報の検索を行う
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                Control control;
                if (CheckBeforePaymentListSearch(out control, true))
                {
                    status = SearchAllPaymentInfo(this.tNedit_SupplierCd.GetInt());
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                _btnNew = true;	// 新規

                                // 画面初期化処理
                                InitializeDisplay(1);
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            {
                                // 画面初期化処理
                                InitializeDisplay(1);

                                _btnNew = false;	// 新規
                                _btnSave = false;	// 保存
                                _btnDelete = false;	// 削除
                                _btnDebitNote = false;  // 赤伝

                                // フレームのボタン設定イベント
                                if (ParentToolbarSettingEvent != null)
                                    ParentToolbarSettingEvent(this);

                                // 仕入先情報のクリア
                                this.lblCustNm.Clear();
                                this.lblTotalDay.Clear();
                                this.lblPaySpan.Text = string.Empty;
                                this.lblSuppCTaxLayMethodNm.Text = string.Empty;
                                this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;   // 前前々回残高
                                this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;   // 前々回残高
                                this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;    // 前回残高
                                this.lbl_BlnceTtl.Text = string.Empty;             // 残高合計
                                this.lbl_StockTotalPayBalance.Text = string.Empty; // 今回支払額
                                this.lbl_Balance.Text = string.Empty;              // 差引残高　
                                this.lbl_ThisTimeStockPrice.Text = string.Empty;   // 今回仕入額
                                this.lbl_TtlBlcPay.Text = string.Empty;            // 更新後残高
                                // モードをクリア
                                this.lblMode.Text = string.Empty;
                                // グリッドをクリア
                                this._paymentListDataTable.Rows.Clear();
                                this.tNedit_SupplierCd.Focus();
                                break;
                            }
                    }
                }
                else
                {
                    control.Focus();
                }
                if (lblCustNm.Text.Trim() == "") return;  // 検索無は終了 
            }
            // 2007.09.05 add end ----------------------------<<

            // 仕入先の検索後に処理を行う。
   			if (this.lblSupplierCd.GetInt() != 0)
            {
                // ↓ 20061222 18322 c インセンティブを追加
				//// 支払合計セット
				//if ((e.PrevCtrl == this.nedtPayment) ||
				//	(e.PrevCtrl == this.nedtFeePayment) ||
				//	(e.PrevCtrl == this.nedtDiscountPayment))

                // 2007.09.05 upd start ---------------------->>
                // 支払合計セット
                //if ((e.PrevCtrl == this.nedtPayment) ||
                //    (e.PrevCtrl == this.nedtFeePayment) ||
                //    (e.PrevCtrl == this.nedtDiscountPayment) ||
                //    (e.PrevCtrl == this.nedtRebatePayment))
                if ((e.PrevCtrl == this.nedtPayment) ||
                    (e.PrevCtrl == this.nedtFeePayment) ||
                    (e.PrevCtrl == this.nedtDiscountPayment))
                // 2007.09.05 upd end ------------------------<< 
                // ↑ 20061222 18322 c
                {
                    this.nedtPaymentTotal.SetValue(GetPayTotal());
				}

                // 2007.09.05 upd start ---------------------->>
				// クレジット会社情報取得
				//if (e.PrevCtrl == this.editCreditCompanyCode)
				//{
				//	if (!this.editCreditCompanyCode.Text.Equals(string.Empty))
				//	{
				//		CreditCompanyNamePrcThreadStart();
				//	}
				//}
                // 銀行情報を取得
                if (e.PrevCtrl == this.tEdit_BankCode)
                {
                    if ( this.tEdit_BankCode.GetInt() != 0)
                    {
                        this.teditBankName.Text = "";
                        BankNamePrcThreadStart();
                    }
                }
                // 2007.09.05 upd end ------------------------<<
			}

            if ((e.PrevCtrl.Name == "tEdit_BankCode") && (this.tEdit_BankCode.GetInt() != 0))
            {
                BankNamePrcThreadStart();
            }

			if (e.NextCtrl == this.gridPaymentList)
			{
				if (e.Key != Keys.RButton)
				{
					if (this.gridPaymentList.ActiveRow != null)
					{
						if (!this.gridPaymentList.ActiveRow.Selected)
						{
							if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
							{
								e.NextCtrl = e.PrevCtrl;
								return;
							}
							else
							{
								this.gridPaymentList.ActiveRow.Selected = true;
							}
						}
					}
				}
			}
        }

		/// <summary>
		/// 仕入先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
		{
            this.tNedit_SupplierCd.Clear();   // 2007.09.05 add
			SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
            this.tNedit_SupplierCd.Focus();   // 2007.09.05 add       
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			// 支払先（仕入先）設定処理
            this.tNedit_SupplierCd.SetInt(customerSearchRet.CustomerCode);

            System.Diagnostics.Debug.Print("支払先[" + customerSearchRet.CustomerCode + "]");
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
		/// フォントサイズ変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォントサイズの値が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.18</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
			// フォントサイズを変更
			this.gridPaymentList.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)cmbFontSize.Value;
		}

        /// <summary>
        /// 仕入先コードフォーカスLeave処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="mode">検索ノード(0:仕入先コード,1:伝票番号モード)</param>
        /// <remarks>
        /// <br>Note　　　  : 仕入先コードからフォーカスが離れた後に処理を行います。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// <br>Update Note : 2012/12/24  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        //private void LeaveSupplierCode(int supplierCode)　// DEL 王君　2012/12/24 Redmine#33741
        private void LeaveSupplierCode(int supplierCode, int mode)// ADD 王君　2012/12/24 Redmine#33741
        {
            DateTime datePaymentDateBak = DateTime.Now;
            if (this.datePaymentDate.GetDateTime() != DateTime.MinValue)
            {
                datePaymentDateBak = this.datePaymentDate.GetDateTime();
            }
            bool paymentBool = false;
            // 支払内訳グリッド
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value)))
                {
                    paymentBool = true;
                }
            }

            // 支払情報検索
            //int status = SearchAllPaymentInfo(supplierCode); // DEL　王君 2012/12/24 Redmine#33741
            // ---- ADD　王君 2012/12/24 Redmine#33741 ----->>>>>
            int status;
            if (mode == 1)
            {
                status = SearchAllPaymentInfo(supplierCode, 1); 
            }
            else
            {
                status = SearchAllPaymentInfo(supplierCode, 0); 
            }
            // ---- ADD　王君 2012/12/24 Redmine#33741 -----<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this._btnNew = true;	// 新規

                        // 画面初期化処理
                        InitializeDisplay(1);

                        this._firstFlg = true;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // 画面初期化処理
                        InitializeDisplay(1);

                        this._btnNew = false;	        // 新規
                        this._btnSave = false;	        // 保存
                        this._btnRenewal = true;
                        this._btnDelete = false;	    // 削除
                        this._btnDebitNote = false;     // 赤伝
                        this._btnReadSupSlip = true;    // 伝票呼出 // ADD 王君 2012/12/24 Redmine#33741
                        this._searchFlg = false;

                        // フレームのボタン設定イベント
                        if (ParentToolbarSettingEvent != null)
                        {
                            ParentToolbarSettingEvent(this);
                        }

                        // 仕入先情報のクリア
                        this.lblCustNm.Clear();
                        this.lblTotalDay.Clear();
                        this.lblPaySpan.Text = string.Empty;
                        this.lbl_StockTtl3TmBfBlPay.Text = string.Empty;   // 前前々回残高
                        this.lbl_StockTtl2TmBfBlPay.Text = string.Empty;   // 前々回残高
                        this.lbl_ThisTimeTtlBlcPay.Text = string.Empty;    // 前回残高
                        this.lbl_BlnceTtl.Text = string.Empty;             // 残高合計
                        this.lbl_StockTotalPayBalance.Text = string.Empty; // 今回支払額
                        this.lbl_Balance.Text = string.Empty;              // 差引残高　
                        this.lbl_ThisTimeStockPrice.Text = string.Empty;   // 今回仕入額
                        this.lbl_TtlBlcPay.Text = string.Empty;            // 更新後残高

                        // モードをクリア
                        this.lblMode.Text = string.Empty;

                        // グリッドをクリア
                        this._paymentListDataTable.Rows.Clear();

                        // フォーカス設定
                        this.tNedit_SupplierCd.Focus();

                        break;
                    }
            }



            if (!paymentBool)
            {
                this.datePaymentDate.SetDateTime(datePaymentDateBak);
            }
        }

        private void ClearScreen()
        {
            ClearCustomer();
            ClearPayment();
            ClearPyamentList();

            this._buffPaymentSlp = null;

            this._FirstStartFlag = true; // ADD 2010/06/17
        }


        // --- ADD 2012/09/07 ---------->>>>>                     
        private void ClearScreen2()
        {
            ClearSection();
            ClearPayment();
            ClearPyamentList();

            this._buffPaymentSlp = null;

            this._FirstStartFlag = true;
        }
        // --- ADD 2012/09/07 ----------<<<<<
        

        /// <summary>
        /// 仕入先情報欄初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先情報欄の初期化を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private void ClearCustomer()
        {
            // 伝票日付制御コンボボックス初期値設定
            this.PaymentSlipDateClrDiv_tComboEditor.Value = this._paySlipDateClrDiv;

            this.tNedit_SupplierCd.Clear();       // 仕入先コード
            this.lblCustNm.Clear();           // 仕入先名称
            this.lblTotalDay.Clear();               // 締/集金
            this.lblPaySpan.Text = "";              // 請求対象期間
            this.lbl_StockTtl3TmBfBlPay.Text = ""; // 前前々回残高
            this.lbl_StockTtl2TmBfBlPay.Text = ""; // 前々回残高
            this.lbl_ThisTimeTtlBlcPay.Text = "";      // 前回残高
            this.lbl_BlnceTtl.Text = "";            // 残高合計
            this.lbl_StockTotalPayBalance.Text = "";      // 今回入金額
            this.lbl_Balance.Text = "";             // 差引残高
            this.lbl_ThisTimeStockPrice.Text = "";       // 今回売上
            this.lbl_TtlBlcPay.Text = "";    // 更新後残高
            this._prevSupplierCode = 0;
            this._searchCustSuppliRet = new SearchCustSuppliRet();
            this._searchSuplierPayRet = new SearchSuplierPayRet();
        }

        // --- ADD 2012/09/07 ---------->>>>>
        /// <summary>
        /// 拠点情報欄初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報欄の初期化を行います。</br>
        /// <br>Programmer : FSI上北田　秀樹</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void ClearSection()
        {
            // 伝票日付制御コンボボックス初期値設定
            this.PaymentSlipDateClrDiv_tComboEditor.Value = this._paySlipDateClrDiv;
            this.lblSectionNm.Clear();                  // 拠点名称
            this.lblTotalDay.Clear();                   // 締/集金
            this.lblPaySpan.Text = "";                  // 請求対象期間
            this.lbl_StockTtl3TmBfBlPay.Text = "";      // 前前々回残高
            this.lbl_StockTtl2TmBfBlPay.Text = "";      // 前々回残高
            this.lbl_ThisTimeTtlBlcPay.Text = "";       // 前回残高
            this.lbl_BlnceTtl.Text = "";                // 残高合計
            this.lbl_StockTotalPayBalance.Text = "";    // 今回入金額
            this.lbl_Balance.Text = "";                 // 差引残高
            this.lbl_ThisTimeStockPrice.Text = "";      // 今回売上
            this.lbl_TtlBlcPay.Text = "";               // 更新後残高
            this._prevSectionCode = "";
            this._prevSectionName = "";
            this._searchCustSuppliRet = new SearchCustSuppliRet();
            this._searchSuplierPayRet = new SearchSuplierPayRet();
        } 
        // --- ADD 2012/09/07 ----------<<<<<

        /// <summary>
        /// 入金伝票入力欄初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金伝票入力欄の初期化を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private void ClearPayment()
        {
            this.nedtPaymentSlipNo.Clear();          // 入金番号
            this.labDebitNoteLinkDepoNo.Text = "";
            this.datePaymentDate.Clear();            // 入金日
            this.nedtFeePayment.Clear();             // 手数料
            this.nedtDiscountPayment.Clear();        // 値引
            this.nedtPaymentTotal.Clear();           // 入金合計
            //this.dateDraftDrawingDate.Clear();       // 振出日
            this.editOutline.Clear();                // 摘要
            //this.tEdit_BankCode.Clear();           // 銀行コード
            //this.teditBankName.Clear();             // 銀行名称
            //this.tEdit_DraftNo.Clear();             // 手形番号
            //this.cmbDraftKind.Clear();              // 手形種類
            //this.cmbDraftDivide.Clear();            // 手形区分

            // 入金内訳グリッド
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Value = "";
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Tag = 0;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctYear].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctMonth].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctDay].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctYear].Activation = Activation.Disabled;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctMonth].Activation = Activation.Disabled;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctDay].Activation = Activation.Disabled;
            }

            //this._prevBankCode = 0;
            this._prevSupplierCode = 0;
        }

        /// <summary>
        /// 入金一覧初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金一覧の初期化を行います。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void ClearPyamentList()
        {
            // 入金情報DataSet初期化処理
            this._paymentSlpSearch.ClearPaymentDataTable();

            this.datePaymentDateStart.SetDateTime(new DateTime());
            this.datePaymentDateEnd.SetDateTime(new DateTime());
            this.tNedit_SupplierSlipNo.Clear();

            this.lblListInfo.Text = "";
        }

        // ----- ADD 王君 2012/12/24 Redmine#33741 --------->>>>>
        /// <summary>
        /// 入金伝票入力欄初期化処理(支払番号検索モード)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金伝票入力欄の初期化を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void ClearPaymentUG()
        {
            this.nedtPaymentSlipNo.Clear();          // 入金番号
            this.labDebitNoteLinkDepoNo.Text = "";
            this.nedtFeePayment.Clear();             // 手数料
            this.nedtDiscountPayment.Clear();        // 値引
            this.nedtPaymentTotal.Clear();           // 入金合計
            this.editOutline.Clear();                // 摘要
            // 入金内訳グリッド
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Value = "";
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctPayment].Tag = 0;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctYear].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctMonth].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctDay].Value = DBNull.Value;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctYear].Activation = Activation.Disabled;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctMonth].Activation = Activation.Disabled;
                this.grdPaymentKind.DisplayLayout.Rows[rowIndex].Cells[ctDay].Activation = Activation.Disabled;
            }
        }

        /// <summary>
        ///  仕入先情報取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <remarks>
        /// <br>Note       : 入金伝票入力欄の初期化を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void ChangeSupplierCodeUG(int supplierCode)
        {
            Supplier supplier;

            //--------------------------------------------------------------------
            // 仕入先コードから仕入先マスタを取得し、支払先コードと比較
            // 仕入先コードと支払先コードに差異がある場合は支払先コードで再検索
            //--------------------------------------------------------------------
            int status = GetSupplier(out supplier, supplierCode);
            if (status == 0)
            {
                // 仕入先コード設定
                this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                // 仕入先略称取得
                this.lblCustNm.Text = supplier.SupplierSnm.Trim();

                // 仕入先コード
                this._supplierCode = supplier.SupplierCd;
                
                // 計上拠点取得
                this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                // 支払先コード
                this._payeeCode = supplier.PayeeCode;
                
                // 仕入先コード
                this._supplierCode = supplierCode;

                this._prevSupplierCode = this._payeeCode;
            }

            if (status == 0)
            {
                LeaveSupplierCode(this._payeeCode, 1);
            }
            else
            {
                // 画面情報初期化
                ClearScreen();

                this._btnNew = false;	        // 新規
                this._btnSave = false;	        // 保存
                this._btnRenewal = true;
                this._btnDelete = false;	    // 削除
                this._btnDebitNote = false;     // 赤伝
                this._btnReadSupSlip = true;    // 伝票呼出  // ADD 王君 2012/12/24 Redmine#33741
                this._searchFlg = false;

                // フレームのボタン設定イベント
                if (ParentToolbarSettingEvent != null)
                {
                    ParentToolbarSettingEvent(this);
                }
            }
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 ---------<<<<<

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・伝票登録後に支払一覧を更新しないように変更</br>
        /// <br>Update Note : 2010/06/17 李占川 Redmine#9949の修正
        /// <br>Update Note : 10806793-00 2012/12/24  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Update Note : 10806793-00 2013/02/06  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Update Note : 10806793-00 2013/02/07  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Update Note : 10806793-00 2013/02/19  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                // 伝票日付制御
                case "PaymentSlipDateClrDiv_tComboEditor":
                    if (e.Key == Keys.Down)
                    {
                        // --- DEL 2012/09/07 ---------->>>>>
                        //e.NextCtrl = this.tNedit_SupplierCd;
                        //this.tNedit_SupplierCd.Focus();
                        // --- DEL 2012/09/07 ----------<<<<<
                        // --- ADD 2012/09/07 ---------->>>>>
                        if (_supplierSummary)
                        {
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                        }
                        else
                        {
                        e.NextCtrl = this.tNedit_SupplierCd;
                        this.tNedit_SupplierCd.Focus();
                        }
                        // --- ADD 2012/09/07 ----------<<<<<
                        return;
                    }
                    break;
                // --- ADD 2012/09/07 ---------->>>>>
                // 拠点コード
                case "tEdit_SectionCode":

                    if (e.ShiftKey == true)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = this.uceShowDetail;
                            this.uceShowDetail.Focus();
                            return;
                        }
                    }

                    int retSection = 0;

                    string sectionCode = this.tEdit_SectionCode.Text;


                    // 前回値と一緒
                    if ((sectionCode != "") && (sectionCode == this._prevSectionCode))
                    {
                        // 拠点名称設定
                        this.lblSectionNm.Text = this._prevSectionName;

                        if (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Down )
                        {
                            // 次フォーカス(仕入先コード)
                            e.NextCtrl = this.tNedit_SupplierCd;
                            this.tNedit_SupplierCd.Focus();
                        }
                        else if (e.Key == Keys.Right)
                        {
                            // 次フォーカス(拠点ガイドボタン)
                            e.NextCtrl = this.uButton_SectionGuide;
                            this.uButton_SectionGuide.Focus();
                        }
                        else if (e.Key == Keys.Up)
                        {
                            // 次フォーカス(伝票日付制御)
                            e.NextCtrl = this.PaymentSlipDateClrDiv_tComboEditor;
                            this.PaymentSlipDateClrDiv_tComboEditor.Focus();
                        }

                        return;
                    }

                    // 拠点コード未入力＆フォーカス移動時ガイド表示
                    if (this.tEdit_SectionCode.Text != string.Empty)
                    {
                        // 拠点情報取得
                        SecInfoSet section;
                        retSection = GetSection(out section, sectionCode);

                        if (retSection == 0)
                        {
                            // 拠点名称設定
                            this.lblSectionNm.Text = section.SectionGuideNm.Trim();
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // 拠点コード、拠点名称を初期化
                            this.tEdit_SectionCode.Text = string.Empty;
                            this.lblSectionNm.Text = string.Empty;

                    break;
                        }

                        // 前回値設定
                        this._prevSectionCode = sectionCode;
                        this._prevSectionName = section.SectionGuideNm.Trim();
                        
                        // 計上拠点設定
                        this._selectSectionCode = this.tEdit_SectionCode.Text;
                    }
                    else
                    {
                        // 拠点コード、拠点名称を初期化
                        this.tEdit_SectionCode.Text = string.Empty;
                        this.lblSectionNm.Text = string.Empty;
                    }


                    if (e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.PaymentSlipDateClrDiv_tComboEditor;
                        this.PaymentSlipDateClrDiv_tComboEditor.Focus();
                        if (tEdit_SectionCode.Text == "")
                        {
                            ClearScreen2();
                            this._btnNew = false;	        // 新規
                            this._btnSave = false;	        // 保存
                            this._btnRenewal = true;
                            this._btnDelete = false;	    // 削除
                            this._btnDebitNote = false;     // 赤伝
                            this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                            this._searchFlg = false;

                            // フレームのボタン設定イベント
                            if (ParentToolbarSettingEvent != null)
                            {
                                ParentToolbarSettingEvent(this);
                            }
                        }
                    }
                    else if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this.uButton_SectionGuide;
                        this.uButton_SectionGuide.Focus();
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this.tNedit_SupplierCd;
                        this.tNedit_SupplierCd.Focus();
                        if (tEdit_SectionCode.Text == "")
                        {
                            ClearScreen2();
                            this._btnNew = false;	        // 新規
                            this._btnSave = false;	        // 保存
                            this._btnRenewal = true;
                            this._btnDelete = false;	    // 削除
                            this._btnDebitNote = false;     // 赤伝
                            this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                            this._searchFlg = false;

                            // フレームのボタン設定イベント
                            if (ParentToolbarSettingEvent != null)
                            {
                                ParentToolbarSettingEvent(this);
                            }
                        }
                    }
                    else if (e.Key == Keys.LButton)
                    {
                        if (tEdit_SectionCode.Text == "")
                        {
                            ClearScreen2();
                            this._btnNew = false;	        // 新規
                            this._btnSave = false;	        // 保存
                            this._btnRenewal = true;
                            this._btnDelete = false;	    // 削除
                            this._btnDebitNote = false;     // 赤伝
                            this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                            this._searchFlg = false;

                            // フレームのボタン設定イベント
                            if (ParentToolbarSettingEvent != null)
                            {
                                ParentToolbarSettingEvent(this);
                            }
                        }
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        if (lblSectionNm.Text.Trim() != "")
                        {
                            // 次フォーカス(仕入先コード)
                            e.NextCtrl = this.tNedit_SupplierCd;
                            this.tNedit_SupplierCd.Focus();
                        }
                        else
                        {
                            if (tEdit_SectionCode.Text.Trim() == "")
                            {
                                // 拠点ガイド起動
                                this.uButton_SectionGuide_Click(this.tEdit_SectionCode, new EventArgs());

                                if (tEdit_SectionCode.Text.Trim() == "")
                                {
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    e.NextCtrl = tNedit_SupplierCd;
                                }
                            }
                            else
                            {
                                // 次フォーカス(拠点ガイドボタン)
                                e.NextCtrl = this.uButton_SectionGuide;
                                this.uButton_SectionGuide.Focus();
                            }
                        }
                    }
 

                    if (retSection == 0 && this.lblSectionNm.Text.Trim() != "" && this.lblCustNm.Text.Trim() != "")
                    {
                        LeaveSupplierCode(this._payeeCode,0);
                    }
                    else
                    {
                        if (this.lblSectionNm.Text.Trim() == "")
                        {
                            ClearScreen2();
                        }

                        this._btnNew = false;	        // 新規
                        this._btnSave = false;	        // 保存
                        this._btnRenewal = true;
                        this._btnDelete = false;	    // 削除
                        this._btnDebitNote = false;     // 赤伝
                        this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                        this._searchFlg = false;

                        // フレームのボタン設定イベント
                        if (ParentToolbarSettingEvent != null)
                        {
                            ParentToolbarSettingEvent(this);
                        }
                    }

                    break;

                case "uButton_SectionGuide":
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this.uButton_SectionGuide;
                        this.uButton_SectionGuide.Focus();
                    }
                    break;

                case "uButton_StockCustomerGuide":
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this.uButton_StockCustomerGuide;
                        this.uButton_StockCustomerGuide.Focus();
                    }

                    break;

                // --- ADD 2012/09/07 ----------<<<<<
                // 仕入先コード
                case "tNedit_SupplierCd":
                    //// 未入力
                    //if (this.tNedit_SupplierCd.GetInt() == 0)
                    //{
                    //    this.lblCustNm.Clear();
                    //    this.lblTotalDay.Clear();
                    //    this._prevSupplierCode = 0;
                    //    return;
                    //}

                    // 仕入先コード取得
                    int supplierCode = this.tNedit_SupplierCd.GetInt();
                    // ---- ADD 王君 2013/02/19 Redmine#33741 ----- >>>>>
                    bool flag;
                    if (supplierCode == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                    // ---- ADD 王君 2013/02/19 Redmine#33741 ----- <<<<<
                    // 前回値と一緒
                    if ((supplierCode != 0) && (supplierCode == this._prevSupplierCode))
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.lblCustNm.Text.Trim() != "")
                                {
                                    if (this.datePaymentDate.Enabled)
                                    {
                                        // --- UPD 2010/06/08 ---------->>>>>
                                        //e.NextCtrl = this.datePaymentDate;
                                        if (this.PaymentSlipDateClrDiv_tComboEditor.SelectedIndex == 1)
                                        {
                                            // --- UPD 2010/06/17 ---------->>>>>
                                            //e.NextCtrl = null;
                                            //this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                                            //this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);

                                            if (_FirstStartFlag)
                                            {
                                                e.NextCtrl = this.datePaymentDate;
                                            }
                                            else
                                            {
                                                e.NextCtrl = null;
                                                this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                                                this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                            // --- UPD 2010/06/17 ----------<<<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.datePaymentDate;
                                        }
                                        // --- UPD 2010/06/08 ----------<<<<<
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.datePaymentDateStart;
                                    }
                                    return;
                                }
                            }
                        }
                        return;
                    }

                    // ADD 2009/12/20 ---->>>>
                    DialogResult dialogRet = DialogResult.OK;
                    if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                    {
                        dialogRet = DialogResult.Cancel;
                    }

                    switch (dialogRet)
                    {
                        case DialogResult.OK:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                this.tNedit_SupplierCd.SetInt(this._prevSupplierCode);
                                e.NextCtrl = this.tNedit_SupplierCd;
                                return;
                            }
                    }

                    this._detailsShowFlg = false;
                    // ADD 2009/12/20 ----<<<<

                    Supplier supplier;

                    //--------------------------------------------------------------------
                    // 仕入先コードから仕入先マスタを取得し、支払先コードと比較
                    // 仕入先コードと支払先コードに差異がある場合は支払先コードで再検索
                    //--------------------------------------------------------------------
                    int status = GetSupplier(out supplier, supplierCode);
                    if (status == 0)
                    {
                        // 仕入先コード設定
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        // 仕入先略称取得
                        this.lblCustNm.Text = supplier.SupplierSnm.Trim();

                        // 仕入先コード
                        this._supplierCode = supplier.SupplierCd;

                        #region DEL 2012/09/07 仕入先総括対応
                        // --- DEL 2012/09/07 ---------->>>>>
                        // 支払先コードチェック
                        //bool bStatus = CheckPayeeCode(supplier);
                        //if (!bStatus)
                        //{
                        //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                        //                      this.Name,
                        //                      "支払先に変更しました。",
                        //                      0,
                        //                      MessageBoxButtons.OK);

                        //    ChangeSupplierCode(supplier.PayeeCode);
                        //}
                        //else
                        //{
                            
                        //     計上拠点取得
                        //    this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                        //     支払先コード
                        //    this._payeeCode = supplier.PayeeCode;

                        //     仕入先コード
                        //    this._supplierCode = this._payeeCode;
                        //}

                        //this._prevSupplierCode = this._payeeCode;
                        // --- DEL 2012/09/07 ----------<<<<<
                        #endregion


                        // --- ADD 2012/09/07 ---------->>>>>
                        if (_supplierSummary)
                        {
                            // 支払先コード
                            this._payeeCode = supplier.SupplierCd;
                            this._prevSupplierCode = supplier.SupplierCd;
                            this.lblCustNm.Text = supplier.SupplierSnm.Trim();
                        }
                        else
                        {
                        // 支払先コードチェック
                        bool bStatus = CheckPayeeCode(supplier);
                        if (!bStatus)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              "支払先に変更しました。",
                                              0,
                                              MessageBoxButtons.OK);

                            ChangeSupplierCode(supplier.PayeeCode);
                        }
                        else
                        {
                            // 計上拠点取得
                            this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                            // 支払先コード
                            this._payeeCode = supplier.PayeeCode;

                            // 仕入先コード
                            this._supplierCode = this._payeeCode;
                        }

                        this._prevSupplierCode = this._payeeCode;
                    }
                        // --- ADD 2012/09/07 ----------<<<<<
                    }
                    #region DEL 2012/09/07 仕入先総括対応
                    // --- DEL 2012/09/07 ---------->>>>>
                    //if (status == 0)
                    //{
                    //    LeaveSupplierCode(this._payeeCode);
                    //}
                    //else
                    //{
                    //    // --- DEL 2012/09/07 ---------->>>>>
                    //    // 画面情報初期化
                    //    //ClearScreen();
                    //    // --- DEL 2012/09/07 ----------<<<<<

                    //    this._btnNew = false;	        // 新規
                    //    this._btnSave = false;	        // 保存
                    //    this._btnRenewal = true;
                    //    this._btnDelete = false;	    // 削除
                    //    this._btnDebitNote = false;     // 赤伝

                    //    this._searchFlg = false;

                    //    // フレームのボタン設定イベント
                    //    if (ParentToolbarSettingEvent != null)
                    //    {
                    //        ParentToolbarSettingEvent(this);
                    //    }
                    //}
                    // --- DEL 2012/09/07 ----------<<<<<
                    #endregion

                    // --- ADD 2012/09/07 ---------->>>>>
                    if (_supplierSummary)
                    {
                        if (status == 0 && this.lblSectionNm.Text.Trim() != "")
                        {
                            //LeaveSupplierCode(this._payeeCode); //DEL 王君 2012/12/24 Redmine#33741
                            LeaveSupplierCode(this._payeeCode, 0); //ADD 王君 2012/12/24 Redmine#33741
                        }
                        else
                        {
                            /* ----- DEL 王君 2013/02/06 Redmine#33741 ----------->>>>>
                            // ----- ADD 王君 2012/12/24 Redmine#33741 ----------->>>>>
                            if (e.NextCtrl == null)
                            {
                                if (this.tNedit_SupplierCd.GetInt() != 0)
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                     this.Name,
                                                     "仕入先コードが存在しません。",
                                                     0,
                                                     MessageBoxButtons.OK);
                                    ClearScreen();
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            if (this.tNedit_SupplierCd.GetInt() == 0 && !"uButton_StockCustomerGuide".Equals(e.NextCtrl.Name))
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                      this.Name,
                                                      "仕入先コードが未入力です。",
                                                      0,
                                                      MessageBoxButtons.OK);
                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                            else if (this.tNedit_SupplierCd.GetInt() != 0 && !"uButton_StockCustomerGuide".Equals(e.NextCtrl.Name))
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                     this.Name,
                                                     "仕入先コードが存在しません。",
                                                     0,
                                                     MessageBoxButtons.OK);
                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                            else
                            {
                            }
                            // ----- ADD 王君 2012/12/24 Redmine#33741 -----------<<<<<
                            // ----- DEL 王君 2013/02/06 Redmine#33741 -----------<<<<< */
                            // 画面情報初期化
                            ClearScreen();
                            this._btnNew = false;	        // 新規
                            this._btnSave = false;	        // 保存
                            this._btnRenewal = true;
                            this._btnDelete = false;	    // 削除
                            this._btnDebitNote = false;     // 赤伝
                            this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                            this._searchFlg = false;

                            // フレームのボタン設定イベント
                            if (ParentToolbarSettingEvent != null)
                            {
                                ParentToolbarSettingEvent(this);
                            }
                        }
                    }
                    else
                    {
                        if (status == 0)
                        {
                            LeaveSupplierCode(this._payeeCode,0);
                        }
                        else
                        {
                            // 画面情報初期化
                            ClearScreen();

                            this._btnNew = false;	        // 新規
                            this._btnSave = false;	        // 保存
                            this._btnRenewal = true;
                            this._btnDelete = false;	    // 削除
                            this._btnDebitNote = false;     // 赤伝
                            this._btnReadSupSlip = true;    // 伝票呼出   // ADD 王君 2012/12/24 Redmine#33741
                            this._searchFlg = false;

                            // フレームのボタン設定イベント
                            if (ParentToolbarSettingEvent != null)
                            {
                                ParentToolbarSettingEvent(this);
                            }
                        }
                    }
                    // --- ADD 2012/09/07 ----------<<<<<

                    //this._prevSupplierCode = supplierCode;

                    //LeaveSupplierCode(supplierCode);

                    if (e.ShiftKey == false)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Enter:
                                {
                                    //if (this.lblCustNm.Text.Trim() != "") // DEL 2009/06/26
                                    if (status == 0)    // ADD 2009/06/26
                                    {
                                        if (this.datePaymentDate.Enabled)
                                        {
                                            // --- UPD 2010/06/08 ---------->>>>>
                                            //e.NextCtrl = this.datePaymentDate;
                                            if (this.PaymentSlipDateClrDiv_tComboEditor.SelectedIndex == 1)
                                            {
                                                // --- UPD 2010/06/17 ---------->>>>>
                                                //e.NextCtrl = null;
                                                //this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                                                //this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);

                                                if (_FirstStartFlag)
                                                {
                                                    e.NextCtrl = this.datePaymentDate;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                    this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                                                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                // --- UPD 2010/06/17 ----------<<<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.datePaymentDate;
                                            }
                                            // --- UPD 2010/06/08 ----------<<<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.datePaymentDateStart;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        //this.uButton_StockCustomerGuide_Click(this.tNedit_SupplierCd, new EventArgs()); // DEL 王君　2013/02/06 Redmine#33741
                                        //if (this.lblCustNm.Text.Trim() != "") // DEL 2009/06/26
                                        // ----- ADD 王君　2013/02/07 Redmine#33741 ----- >>>>>
                                        this.uButton_StockCustomerGuide_Click(this.tNedit_SupplierCd, new EventArgs()); 
                                        if (this.tNedit_SupplierCd.GetInt() == 0)
                                        {
                                        // ----- ADD 王君　2013/02/07 Redmine#33741 ----- <<<<<
                                            // ----- ADD 王君 2013/02/06 Redmine#33741 ----- >>>>>
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "仕入先コードが未入力です。",
                                                0,
                                                MessageBoxButtons.OK);
                                            //e.NextCtrl = this.tNedit_SupplierCd; // DEL 王君 2013/02/07 Redmine#33741
                                            // ----- ADD 王君 2013/02/06 Redmine#33741 ----- <<<<<
                                        } // ----- ADD 王君 2013/02/07 Redmine#33741
                                        if (this._supplierGuideSelected)    // ADD 2009/06/26
                                        {
                                            e.NextCtrl = this.datePaymentDate;
                                            return;
                                        }
                                        else
                                        {
                                            ClearScreen();

                                            this._btnNew = false;	        // 新規
                                            this._btnSave = false;	        // 保存
                                            this._btnRenewal = true;
                                            this._btnDelete = false;	    // 削除
                                            this._btnDebitNote = false;     // 赤伝
                                            this._btnReadSupSlip = true;    // 伝票呼出  // ADD 王君 2012/12/24 Redmine#33741
                                            this._searchFlg = false;

                                            // フレームのボタン設定イベント
                                            if (ParentToolbarSettingEvent != null)
                                            {
                                                ParentToolbarSettingEvent(this);
                                            }
                                            e.NextCtrl = this.tNedit_SupplierCd;// ADD 王君 2013/02/19 Redmine#33741
                                            return;
                                        }
                                    }
                                }
                            case Keys.Up:
                                {
                                    //if (this.lblCustNm.Text.Trim() == "") // DEL 2009/06/26
                                    if (status != 0)    // ADD 2009/06/26
                                    {
                                        ClearScreen();

                                        this._btnNew = false;	        // 新規
                                        this._btnSave = false;	        // 保存
                                        this._btnRenewal = true;
                                        this._btnDelete = false;	    // 削除
                                        this._btnDebitNote = false;     // 赤伝
                                        this._btnReadSupSlip = true;    // 伝票呼出  // ADD 王君 2012/12/24 Redmine#33741
                                        this._searchFlg = false;

                                        // フレームのボタン設定イベント
                                        if (ParentToolbarSettingEvent != null)
                                        {
                                            ParentToolbarSettingEvent(this);
                                        }
                                        /* ----- DEL 王君 2013/02/06 Redmine#33741 ----->>>>>
                                        // e.NextCtrl = this.tNedit_SupplierCd;// ADD 王君 2012/12/24 Redmine#33741 
                                    }
                                    // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
                                    else
                                    {
                                    // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
                                         ----- DEL 王君 2013/02/06 Redmine#33741 -----<<<<<*/

                                        //e.NextCtrl = this.PaymentSlipDateClrDiv_tComboEditor;
                                        //this.PaymentSlipDateClrDiv_tComboEditor.Focus();
                                    }// ADD 王君 2012/12/24 Redmine#33741
                                      // --- ADD 2012/09/07 ---------->>>>>
                                    if (_supplierSummary)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCode;
                                        this.tEdit_SectionCode.Focus();
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.PaymentSlipDateClrDiv_tComboEditor;
                                        this.PaymentSlipDateClrDiv_tComboEditor.Focus();
                                    }
                                    // --- ADD 2012/09/07 ----------<<<<<
                                    return;
                                }
                            case Keys.Down:
                                // ----- ADD 王君 2013/02/06 Redmine#33741 ----->>>>>
                                {
                                    if (status != 0)
                                    {
                                        // ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                        if (!flag)
                                        {
                                            this.uButton_StockCustomerGuide_Click(this.tNedit_SupplierCd, new EventArgs());
                                            if (!this._supplierGuideSelected)
                                            {
                                                // ----- ADD 王君 2013/02/19 Redmine#33741 -----<<<<<
                                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                    this.Name,
                                                    "仕入先コードが未入力です。",
                                                    0,
                                                    MessageBoxButtons.OK);
                                                // ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.datePaymentDate;
                                                return;
                                            }
                                        }
                                        // ----- ADD 王君 2013/02/19 Redmine#33741 -----<<<<<
                                        ClearScreen();
                                        this._btnNew = false;	        // 新規
                                        this._btnSave = false;	        // 保存
                                        this._btnRenewal = true;
                                        this._btnDelete = false;	    // 削除
                                        this._btnDebitNote = false;     // 赤伝
                                        this._btnReadSupSlip = true;    // 伝票呼出  
                                        this._searchFlg = false;

                                        // フレームのボタン設定イベント
                                        if (ParentToolbarSettingEvent != null)
                                        {
                                            ParentToolbarSettingEvent(this);
                                        }
                                        //e.NextCtrl = this.tNedit_SupplierCd;// DEL 王君 2013/02/19 Redmine#33741 
                                        return;
                                    }
                                    break;
                                }
                            // ----- ADD 王君 2013/02/06 Redmine#33741 -----<<<<<
                            case Keys.Left:
                                // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
                                {
                                    if (status != 0)  
                                    {
                                        ClearScreen();

                                        this._btnNew = false;	        // 新規
                                        this._btnSave = false;	        // 保存
                                        this._btnRenewal = true;
                                        this._btnDelete = false;	    // 削除
                                        this._btnDebitNote = false;     // 赤伝
                                        this._btnReadSupSlip = true;    // 伝票呼出  
                                        this._searchFlg = false;

                                        // フレームのボタン設定イベント
                                        if (ParentToolbarSettingEvent != null)
                                        {
                                            ParentToolbarSettingEvent(this);
                                        }
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                        return;
                                    }
                                    break;
                                }
                            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
                            case Keys.Right:
                                {
                                    //if (this.lblCustNm.Text.Trim() == "") // DEL 2009/06/26
                                    if (status != 0)    // ADD 2009/06/26
                                    {
                                        // ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                        if (!flag)
                                        {
                                            this.uButton_StockCustomerGuide_Click(this.tNedit_SupplierCd, new EventArgs());
                                            if (!this._supplierGuideSelected)
                                            {
                                        // ----- ADD 王君 2013/02/19 Redmine#33741 -----<<<<<
                                                // ----- ADD 王君 2013/02/06 Redmine#33741 ----- >>>>>
                                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                    this.Name,
                                                    "仕入先コードが未入力です。",
                                                     0,
                                                     MessageBoxButtons.OK);
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                                // ----- ADD 王君 2013/02/06 Redmine#33741 ----- <<<<<
                                                // ----- ADD 王君 2013/02/19 Redmine#33741 ----->>>>>
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.datePaymentDate;
                                                return;
                                            }
                                        }
                                        // ----- ADD 王君 2013/02/19 Redmine#33741 -----<<<<<
                                        ClearScreen();

                                        this._btnNew = false;	        // 新規
                                        this._btnSave = false;	        // 保存
                                        this._btnRenewal = true;
                                        this._btnDelete = false;	    // 削除
                                        this._btnDebitNote = false;     // 赤伝
                                        this._btnReadSupSlip = true; 　 // 伝票呼出  // ADD 王君 2012/12/24 Redmine#33741
                                        this._searchFlg = false;

                                        // フレームのボタン設定イベント
                                        if (ParentToolbarSettingEvent != null)
                                        {
                                            ParentToolbarSettingEvent(this);
                                        }
                                        // e.NextCtrl = this.uButton_StockCustomerGuide;// ADD 王君 2012/12/24 Redmine#33741 // DEL 王君 2013/02/06 Redmine#33741
                                        return;
                                    }
                                    break;
                                }
                        }
                    }
                    break;
                /* ----- DEL 王君 2013/02/06 Redmine#33741 -------->>>>>
                // ----- ADD 王君 2012/12/24 Redmine#33741 -------->>>>>
            case "uButton_StockCustomerGuide":　//得意先ガイド
                {
                    if (e.ShiftKey == false)
                    {
                        if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
                        {
                            if ("tNedit_SupplierCd" != e.NextCtrl.Name && "uButton_StockCustomerGuide" != e.NextCtrl.Name)
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "仕入先コードが未入力です。",
                                    0,
                                    MessageBoxButtons.OK);
                                ClearScreen();
                                e.NextCtrl = this.uButton_StockCustomerGuide;
                            }
                        }
                    }
                    break;
                }
            // ----- ADD 王君 2012/12/24 Redmine#33741 --------<<<<<
            //----- DEL 王君 2013/02/06 Redmine#33741 --------<<<<< */
                // 手数料・値引
                case "nedtFeePayment":
                case "nedtDiscountPayment":
                    {
                        if (this._searchFlg != true)
                        {
                            break;
                        }

                        double total = GetPayTotal();
                        //this.nedtPaymentTotal.SetValue(total); // ADD 2009/12/20
                        this.nedtPaymentTotal.DataText = total.ToString(); // ADD 2009/12/20

                        ////------------------
                        //// 支払金額情報更新
                        ////------------------
                        //// 今回支払額
                        //Int64 stockTotalPayBalance = this._searchSuplierPayRet.ThisTimePayNrml + (Int64)total;
                        //this.lbl_StockTotalPayBalance.Text = stockTotalPayBalance.ToString("###,##0");
                        //// 差引残高
                        //Int64 balance = this._searchSuplierPayRet.StockTtl3TmBfBlPay + this._searchSuplierPayRet.StockTtl2TmBfBlPay + this._searchSuplierPayRet.LastTimePayment - stockTotalPayBalance;
                        //this.lbl_Balance.Text = balance.ToString("###,##0");
                        //// 更新後残高
                        //Int64 ttlBlcPay = balance + this._searchSuplierPayRet.OfsThisTimeStock + this._searchSuplierPayRet.OfsThisStockTax;
                        //this.lbl_TtlBlcPay.Text = ttlBlcPay.ToString("###,##0");
                    }
                    break;
                // 銀行コード
                case "tEdit_BankCode":
                    //if (this.tEdit_BankCode.GetInt() == 0)
                    //{
                    //    this.teditBankName.Clear();
                    //    this._prevBankCode = 0;
                    //    return;
                    //}

                    //// 銀行コード取得
                    //int bankCode = this.tEdit_BankCode.GetInt();

                    //if (bankCode == this._prevBankCode)
                    //{
                    //    return;
                    //}

                    //this._prevBankCode = bankCode;

                    //this.teditBankName.DataText = GetBankName(bankCode);
                    ////// 銀行名称取得スレッド開始
                    ////BankNamePrcThreadStart();

                    //if (this.teditBankName.DataText.Trim() == "")
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                    //              this.Name,
                    //              "銀行コードが存在しません。",
                    //              0,
                    //              MessageBoxButtons.OK);
                    //    e.NextCtrl = e.PrevCtrl;
                    //    this.tEdit_BankCode.SelectAll();
                    //    return;
                    //}

                    //if (e.ShiftKey == false)
                    //{
                    //    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    //    {
                    //        if (this.teditBankName.DataText.Trim() != "")
                    //        {
                    //            e.NextCtrl = this.dateDraftDrawingDate;
                    //        }
                    //    }
                    //}
                    break;
                // 振出日
                case "dateDraftDrawingDate":
                    {
                        //if (e.ShiftKey == true)
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (this.teditBankName.DataText.Trim() != "")
                        //        {
                        //            e.NextCtrl = this.tEdit_BankCode;
                        //            return;
                        //        }
                        //    }
                        //}
                        break;
                    }
                // 支払内訳グリッド
                case "grdPaymentKind":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.grdPaymentKind.ActiveCell == null)
                                {
                                    return;
                                }

                                int rowIndex = this.grdPaymentKind.ActiveCell.Row.Index;
                                this._notMouseMoveFlg = true; // ADD 2009/04/27 gejun forM1007A-手形データ追加

                                //if (this.grdPaymentKind.ActiveCell.Text != "")
                                //{
                                //    //--------------------------------------
                                //    // 現在のセルに値が入力されている場合
                                //    //--------------------------------------

                                //    // 金種区分取得
                                //    int depositKindDiv = (int)this.grdPaymentKind.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;

                                //    // 金種区分が「102：振込」の場合
                                //    if (depositKindDiv == 102)
                                //    {
                                //        // 手数料にフォーカス設定
                                //        e.NextCtrl = this.nedtFeePayment;
                                //        this.grdPaymentKind.ActiveCell = null;
                                //        this.nedtFeePayment.Focus();
                                //        return;
                                //    }

                                //    if (rowIndex == this.grdPaymentKind.Rows.Count - 1)
                                //    {
                                //        // 最終行
                                //        e.NextCtrl = this.nedtFeePayment;
                                //        this.grdPaymentKind.ActiveCell = null;
                                //        this.nedtFeePayment.Focus();
                                //        return;
                                //    }
                                //    else
                                //    {
                                //        // 最終行以外
                                //        e.NextCtrl = null;
                                //        this.grdPaymentKind.PerformAction(UltraGridAction.NextCellByTab);
                                //        this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //    //--------------------------------------
                                //    // 現在のセルの値が空白の場合
                                //    //--------------------------------------

                                //    if (rowIndex == this.grdPaymentKind.Rows.Count - 1)
                                //    {
                                //        // 最終行
                                //        e.NextCtrl = this.nedtFeePayment;
                                //        this.grdPaymentKind.ActiveCell = null;
                                //        this.nedtFeePayment.Focus();
                                //        return;
                                //    }
                                //    else
                                //    {
                                //        // 最終行以外
                                //        e.NextCtrl = null;
                                //        this.grdPaymentKind.PerformAction(UltraGridAction.NextCellByTab);
                                //        this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                //        return;
                                //    }
                                //}
                                if (rowIndex == this.grdPaymentKind.Rows.Count - 1)
                                {
                                    // 最終行
                                    e.NextCtrl = this.nedtFeePayment;
                                    this.grdPaymentKind.ActiveCell = null;
                                    this.nedtFeePayment.Focus();
                                    return;
                                }
                                else
                                {
                                    // 最終行以外
                                    e.NextCtrl = null;
                                    this.grdPaymentKind.PerformAction(UltraGridAction.NextCellByTab);
                                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.grdPaymentKind.ActiveCell == null)
                                {
                                    return;
                                }

                                int rowIndex = this.grdPaymentKind.ActiveCell.Row.Index;
                                int columnIndex = this.grdPaymentKind.ActiveCell.Column.Index;
                                this._notMouseMoveFlg = true;// ADD 2009/04/27 gejun forM1007A-手形データ追加

                                if ((rowIndex == 0) && (columnIndex == 3))
                                {
                                    e.NextCtrl = datePaymentDate;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.grdPaymentKind.PerformAction(UltraGridAction.PrevCellByTab);
                                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        this._notMouseMoveFlg = false;// ADD 2009/04/27 gejun forM1007A-手形データ追加
                        break;
                    }
                case "gridPaymentList":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.gridPaymentList.Rows.Count == 0)
                                {
                                    return;
                                }

                                if (this.gridPaymentList.ActiveRow == null)
                                {
                                    return;
                                }

                                gridPaymentList_DoubleClickRow(this.gridPaymentList, new DoubleClickRowEventArgs(this.gridPaymentList.ActiveRow, RowArea.CellArea));

                                if (this.datePaymentDate.Enabled == true)
                                {
                                    e.NextCtrl = this.datePaymentDate;
                                }
                                else
                                {
                                    e.NextCtrl = this.gridPaymentList;
                                }
                            }
                        }
                        return;
                    }
                case "editOutline":
                    {
                        if (e.ShiftKey == false)
                        {
                            // 2009.04.02 30413 犬飼 Enterで保存処理実行を追加 >>>>>>START
                            //if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = e.PrevCtrl;

                                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                                ctPGNM,
                                                                "登録してもよろしいですか？",
                                                                0,
                                                                MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    e.NextCtrl = null;
                                    // 保存処理実行
                                    this.SaveMainProc();
                                }
                            }
                            // 2009.04.02 30413 犬飼 Enterで保存処理実行を追加 <<<<<<END
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // 支払内訳グリッド
                case "grdPaymentKind":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                if ((this.grdPaymentKind.Rows.Count == 0) ||
                                    (this.grdPaymentKind.Rows[0].Activation == Activation.Disabled))
                                {
                                    e.NextCtrl = nedtFeePayment;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Up) || (e.Key == Keys.Left))
                            {
                                if ((this.grdPaymentKind.Rows.Count == 0) ||
                                    (this.grdPaymentKind.Rows[0].Activation == Activation.Disabled))
                                {
                                    e.NextCtrl = datePaymentDate;
                                    return;
                                }
                            }
                        }

                        // 金種区分取得
                        int depositKindDiv = (int)grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[ctMoneyKindDiv].Value;

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down) || (e.Key == Keys.Left))
                            {
                                e.NextCtrl = null;
                                this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                                this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[3].Activate();
                                this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if ((depositKindDiv == 105) || (depositKindDiv == 107))
                                {
                                    e.NextCtrl = null;
                                    this.grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[6].Activate();
                                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[3].Activate();
                                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                    }
                    break;
                // 支払一覧リスト
                case "gridPaymentList":
                    //if (e.Key != Keys.RButton)
                    //{
                    //    if (this.gridPaymentList.ActiveRow != null)
                    //    {
                    //        if (!this.gridPaymentList.ActiveRow.Selected)
                    //        {
                    //            // 画面切替時保存処理
                    //            if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                    //            {
                    //                e.NextCtrl = e.PrevCtrl;
                    //                return;
                    //            }
                    //            else
                    //            {
                    //                this.gridPaymentList.ActiveRow.Selected = true;
                    //            }
                    //        }
                    //    }
                    //}
                    break;
                // 伝票日付制御
                case "PaymentSlipDateClrDiv_tComboEditor":
                    if (e.ShiftKey == true)
                    {
                        e.NextCtrl = this.uceShowDetail;
                        this.uceShowDetail.Focus();
                        return;
                    }
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        // --- DEL 2012/09/07 ---------->>>>>
                        //e.NextCtrl = this.tNedit_SupplierCd;
                        //this.tNedit_SupplierCd.Focus();
                        // --- DEL 2012/09/07 ----------<<<<<
                        // --- ADD 2012/09/07 ---------->>>>>
                        if (_supplierSummary)
                        {
                            // 次フォーカス(拠点コード)
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                        }
                        else
                        {
                            // 次フォーカス(仕入先コード)
                        e.NextCtrl = this.tNedit_SupplierCd;
                        this.tNedit_SupplierCd.Focus();
                        }
                        // --- ADD 2012/09/07 ----------<<<<<
                        return;
                    }
                    break;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・伝票登録後に支払一覧を更新しないように変更</br>
        /// <br>                ・支払先変更時等の入力済みチェックの対象を金額項目のみに変更</br>
        /// <br>Update Note : 2010/06/17 李占川 Redmine#9949の修正
        /// </remarks>
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            int status;
            Supplier supplier;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._supplierGuideSelected = false;    // ADD 2009/06/26

                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    // --- ADD 2012/09/07 ---------->>>>>
                    if (!_supplierSummary)
                    {
                    // ADD 2009/12/20   ---->>>>
                    if (supplier.SupplierCd != this._prevSupplierCode)
                    {
                        this._detailsShowFlg = false;

                        DialogResult dialogRet = DialogResult.OK;
                        if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                        {
                            dialogRet = DialogResult.Cancel;
                        }

                        switch (dialogRet)
                        {
                            case DialogResult.OK:
                                {
                                    break;
                                }
                            case DialogResult.Cancel:
                                {
                                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCode);
                                    this.uButton_StockCustomerGuide.Focus();
                                    return;
                                }
                        }
                    }
                    else
                    {
                        return;
                    }
                    // ADD 2009/12/20   ----<<<<
                    }
                    // --- ADD 2012/09/07 ----------<<<<<

                    // 仕入先コード取得
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                    // 仕入先略称取得
                    this.lblCustNm.DataText = supplier.SupplierSnm.Trim();

                    // 仕入先コード
                    this._supplierCode = supplier.SupplierCd;

                    //// 支払先コードチェック
                    //bool bStatus = CheckPayeeCode(supplier);
                    //if (!bStatus)
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                    //                      this.Name,
                    //                      "支払先に変更しました。",
                    //                      0,
                    //                      MessageBoxButtons.OK);

                    //    ChangeSupplierCode(supplier.PayeeCode);
                    //}

                    //_selectSectionCode = supplier.PaymentSectionCode.Trim();
                    // --- ADD 2012/09/07 ---------->>>>>
                     if (_supplierSummary)
                    {
                        // 支払先コード
                        this._payeeCode = supplier.SupplierCd;

                        this._prevSupplierCode = supplier.SupplierCd;

                        if (this.lblSectionNm.Text.Trim() != "")
                        {
                            LeaveSupplierCode(supplier.SupplierCd,0);
                        }
                    }
                    else
                    {
                    // 支払先コードチェック
                    bool bStatus = CheckPayeeCode(supplier);
                    if (!bStatus)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "支払先に変更しました。",
                                          0,
                                          MessageBoxButtons.OK);

                        ChangeSupplierCode(supplier.PayeeCode);
                    }
                    else
                    {
                        // 計上拠点取得
                        this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                        // 支払先コード
                        this._payeeCode = supplier.PayeeCode;

                        // 仕入先コード
                        this._supplierCode = this._payeeCode;
                    }

                    this._prevSupplierCode = this._payeeCode;

                    //LeaveSupplierCode(supplier.PayeeCode);//DEL 王君 2012/12/24 Redmine#33741
                    LeaveSupplierCode(supplier.PayeeCode, 0);//DEL 王君 2012/12/24 Redmine#33741

                    this._prevSupplierCode = supplier.PayeeCode;
                    }
                    // --- ADD 2012/09/07 ----------<<<<<



                    // フォーカス設定
                    // --- UPD 2010/06/08 ---------->>>>>
                    //this.datePaymentDate.Focus();
                    if (this.PaymentSlipDateClrDiv_tComboEditor.SelectedIndex == 1)
                    {
                        // --- UPD 2010/06/17 ---------->>>>>
                        //this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                        //this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);

                        if (_FirstStartFlag)
                        {
                            this.datePaymentDate.Focus();
                        }
                        else
                        {
                            this.grdPaymentKind.DisplayLayout.Rows[0].Cells[3].Activate();
                            this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        // --- UPD 2010/06/17 ----------<<<<<
                    }
                    else
                    {
                        this.datePaymentDate.Focus();
                    }
                    // --- UPD 2010/06/08 ----------<<<<<

                    this._supplierGuideSelected = true; // ADD 2009/06/26
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2012/09/07 ---------->>>>>
        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer	: FSI上北田　秀樹</br>
        /// <br>Date		: 2012/09/07</br>
        /// <br>Update Note : </br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI設定
                this.tEdit_SectionCode.Text = sectionInfo.SectionCode.Trim();
                this.lblSectionNm.Text = sectionInfo.SectionGuideNm.Trim();

                // 前回値設定
                this._prevSectionCode = sectionInfo.SectionCode.Trim();
                this._prevSectionName = sectionInfo.SectionGuideNm.Trim();

                // 計上拠点設定
                this._selectSectionCode = sectionInfo.SectionCode.Trim();

                if (this.lblCustNm.Text.Trim() != "")
                {
                    LeaveSupplierCode(this.tNedit_SupplierCd.GetInt(),0);
                }

                // 次フォーカス
                this.tNedit_SupplierCd.Focus();

            }

        }
        // --- ADD 2012/09/07 ----------<<<<<

        private bool CheckPayeeCode(Supplier supplier)
        {
            if (supplier.PayeeCode == supplier.SupplierCd)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private void ChangeSupplierCode(int payeeCode)
        {
            // 仕入先コードに支払先コードをセット
            this.tNedit_SupplierCd.SetInt(payeeCode);

            Supplier supplier;

            int status = GetSupplier(out supplier, payeeCode);
            if (status == 0)
            {
                // 仕入先略称取得
                this.lblCustNm.DataText = supplier.SupplierSnm.Trim();

                // 計上拠点取得
                this._selectSectionCode = supplier.PaymentSectionCode.Trim();

                // 請求先コード
                this._payeeCode = supplier.PayeeCode;
            }
        }

        private int GetSupplier(out Supplier supplier, int supplierCode)
        {
            int status;
            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
                if ((status == 0) && (supplier.LogicalDeleteCode != 0))
                {
                    return 9;
                }
            }
            catch
            {
                status = -1;
                supplier = new Supplier();
            }

            return (status);
        }


        // --- ADD 2012/09/07 ---------->>>>>
        /// <summary>
        /// 拠点情報処理
        /// </summary>
        /// <param name="section">拠点情報</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note　　　  :  </br>
        /// <br>Programmer  : FSI上北田　秀樹</br>
        /// <br>Date        : 2012/09/07</br>
        /// </remarks>
        private int GetSection(out SecInfoSet section, string sectionCode)
        {
            int status = 0;
            section = new SecInfoSet();

            try
            {
                status = this._secInfoSetAcs.Read(out section, this._enterpriseCode, sectionCode);
                if (status == 0 && section.LogicalDeleteCode != 0)
                {
                    return 9;
                }

            }
            catch
            {
                status = -1;
                section = new SecInfoSet();
            }

            return status;

        }

        // --- ADD 2012/09/07 ----------<<<<<
        /// <summary>
        /// AfterEnterEditMode イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : セルが編集モードになったときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// </remarks>
        private void grdPaymentKind_AfterEnterEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;

            string targetText;
            string retText;

            switch (columnIndex)
            {
                case 3: // 入金金額列
                    {
                        targetText = (string)uGrid.ActiveCell.Value;

                        // カンマ削除
                        retText = RemoveComma(targetText);

                        uGrid.ActiveCell.Value = retText;
                        uGrid.ActiveCell.SelStart = 0;
                        uGrid.ActiveCell.SelLength = retText.Length;
                        return;
                    }
                case 4: // 年
                case 5: // 月
                case 6: // 日
                    {
                        targetText = (string)uGrid.ActiveCell.Value;
                        retText = targetText.Remove(targetText.Length - 1);

                        uGrid.ActiveCell.Value = retText;
                        uGrid.ActiveCell.SelStart = 0;
                        uGrid.ActiveCell.SelLength = retText.Length;
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void grdPaymentKind_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            //UltraGrid uGrid = (UltraGrid)sender;

            //if (uGrid.ActiveCell == null)
            //{
            //    return;
            //}

            //int rowIndex = uGrid.ActiveCell.Row.Index;
            //int columnIndex = uGrid.ActiveCell.Column.Index;

            //switch (columnIndex)
            //{
            //    case 3: // 支払金額列
            //        {
            //            // 支払合計算出
            //            SetPayTotal();
            //            return;
            //        }
            //    default:
            //        {
            //            return;
            //        }
            //}
        }

        private void grdPaymentKind_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // --- DEL m.suzuki 2010/07/12 ---------->>>>>
            //UltraGrid uGrid = (UltraGrid)sender;

            //if (uGrid.ActiveCell == null)
            //{
            //    return;
            //}

            //int rowIndex = uGrid.ActiveCell.Row.Index;
            //int columnIndex = uGrid.ActiveCell.Column.Index;

            //switch (columnIndex)
            //{
            //    case 3: // 支払金額列
            //        {
            //            // 支払合計算出
            //            SetPayTotal();
            //            return;
            //        }
            //    default:
            //        {
            //            return;
            //        }
            //}
            // --- DEL m.suzuki 2010/07/12 ----------<<<<<
        }

        /// <summary>
        /// AfterExitEditMode イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : セルの編集モードが終了したときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private void grdPaymentKind_AfterExitEditMode(object sender, EventArgs e)
        {
            // ADD START 2009/04/27 gejun forM1007A-手形データ追加
            bool notMouseMoveFlg = this._notMouseMoveFlg;
            this._notMouseMoveFlg = false;
            // ADD END 2009/04/27 gejun forM1007A-手形データ追加
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;

            switch (columnIndex)
            {
                case 3: // 支払金額列
                    {
                        // --- ADD m.suzuki 2010/07/12 ---------->>>>>
                        // ハイフンのみ入力状態で編集終了した場合は金額=0とみなす。
                        // その他、不正入力も一度数値変換することで補正する。
                        if ( this.grdPaymentKind.ActiveCell.Value != DBNull.Value )
                        {
                             this.grdPaymentKind.ActiveCell.Value = ToInt64((string)this.grdPaymentKind.ActiveCell.Value).ToString("###,###");
                        }
                        // 支払合計算出
                        SetPayTotal();
                        // --- ADD m.suzuki 2010/07/12 ----------<<<<<

                        //// 支払合計算出
                        //SetPayTotal();

                        if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
                        {
                            return;
                        }

                        string targetText = (string)uGrid.ActiveCell.Value;

                        // カンマ削除
                        string retText = RemoveComma(targetText);

                        double targetValue = double.Parse(retText);

                        uGrid.ActiveCell.Value = targetValue.ToString("###,###");
                        
                        return;
                    }
                case 4: // 年
                    {
                        if ((uGrid.ActiveCell.Value != DBNull.Value) &&
                            ((string)uGrid.ActiveCell.Value != ""))
                        {
                            int year = int.Parse((string)uGrid.ActiveCell.Value);
                            uGrid.ActiveCell.Value = year.ToString() + "年";
                        }
                        return;
                    }
                case 5: // 月
                    {
                        if ((uGrid.ActiveCell.Value != DBNull.Value) &&
                            ((string)uGrid.ActiveCell.Value != ""))
                        {
                            int month = int.Parse((string)uGrid.ActiveCell.Value);
                            if ((month > 0) && (month <= 12))
                            {
                                uGrid.ActiveCell.Value = month.ToString() + "月";
                            }
                            else
                            {
                                uGrid.ActiveCell.Value = "";
                            }
                        }
                        return;
                    }
                case 6: // 日
                    {
                        if ((uGrid.ActiveCell.Value != DBNull.Value) &&
                            ((string)uGrid.ActiveCell.Value != ""))
                        {
                            int day = int.Parse((string)uGrid.ActiveCell.Value);
                            if (day <= 31)
                            {
                                uGrid.ActiveCell.Value = day.ToString() + "日";
                                //ADD START 2009/04/28 gejun forM1007A-手形データ追加
                                if (!this._draftOptSet) return;
                                // 金種区分取得
                                int depositKindDiv = (int)uGrid.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;

                                // 手形の場合
                                if (depositKindDiv == (int)MnyKindDiv.Bill && !_doubleCheckFlg)
                                {
                                    // 期日入力チェック
                                    if (!ValidityTermCheck(rowIndex))
                                        return;
                                }
                                // 手形　仕入先コード入力                             
                                if (depositKindDiv == (int)MnyKindDiv.Bill && this.tNedit_SupplierCd.GetInt() != 0 && notMouseMoveFlg)
                                {

                                    PayDraftData paraPayDraftData = new PayDraftData();
                                    // 手形データ設定処理
                                    if (this.SetDraftData(ref paraPayDraftData, rowIndex))
                                    {
                                        // 手形データメンテナンス画面
                                        PMTEG09101UA pMTEG09101UA = new PMTEG09101UA(paraPayDraftData.Clone());
                                        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                                        pMTEG09101UA.RcvDraftFlg = this._rcvDraftFlg; // 手形引当フラグ
                                        // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                                        pMTEG09101UA.ShowDialog();

                                        // 手形データを保存する場合
                                        if (pMTEG09101UA.SaveFlg)
                                        {
                                            if (pMTEG09101UA.PayDraftData != null)
                                            {
                                                this._payDraftData = pMTEG09101UA.PayDraftData.Clone();
                                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                                if (!String.IsNullOrEmpty(this._payDraftData.SectionCode))
                                                {
                                                    this._payDraftData.SectionCode = this._payDraftData.SectionCode.PadRight(6, ' ');
                                                }
                                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                                this._payDraftData.EnterpriseCode = this._enterpriseCode;
                                                // 手形データ変更の場合
                                                if (!this._payDraftData.Equals(paraPayDraftData))
                                                {
                                                    //if (paraPayDraftData.PayDraftNo != this._payDraftData.PayDraftNo)// DEL zhuhh 2013/01/10 for Redmine #34123
                                                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>
                                                    if ((paraPayDraftData.PayDraftNo != this._payDraftData.PayDraftNo) || (paraPayDraftData.BankAndBranchCd != this._payDraftData.BankAndBranchCd)
                                                    || (paraPayDraftData.DraftDrawingDate != this._payDraftData.DraftDrawingDate))
                                                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                                    {
                                                        if (this._updateMode == ScreenUpdateMode.Update && paraPayDraftData.PayDraftNo != "")
                                                        {
                                                            // 削除用手形データ保存
                                                            if (this._payDraftDataDel == null)
                                                            {
                                                                this._payDraftDataDel = paraPayDraftData.Clone();
                                                                this._payDraftDataDel.EnterpriseCode = this._enterpriseCode;
                                                            }
                                                        }
                                                    }
                                                }
                                                // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                                                this._rcvDraftFlg = pMTEG09101UA.RcvDraftFlg; // 手形引当フラグ保持

                                                if (this._rcvDraftFlg == true) // 受取手形データ検索時
                                                {
                                                    List<RcvDraftData> retList = new List<RcvDraftData>();
                                                    if (SearchRcvDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                                    {
                                                        this._rcvDraftData = (RcvDraftData)retList[0];
                                                        this._rcvDraftData.DraftKindCd = 3; // 手形種別を譲渡に変更
                                                    }
                                                }
                                                // 金額・期日を画面表示
                                                this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value = pMTEG09101UA.PayDraftData.Payment.ToString("###,##0");
                                                SetValidityTerm(TDateTime.LongDateToDateTime(pMTEG09101UA.PayDraftData.ValidityTerm), rowIndex);
                                                // 支払合計算出
                                                SetPayTotal();
                                                // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                                            }
                                        }
                                        // リソースをすべてクリーンアップする。
                                        pMTEG09101UA.Dispose();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                //ADD END 2009/04/28 gejun forM1007A-手形データ追加
                            }
                            else
                            {
                                uGrid.ActiveCell.Value = "";
                            }
                        }
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        //ADD START 2009/04/28 gejun forM1007A-手形データ追加
        /// <summary>
        /// 支払手形データ設定処理
        /// </summary>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note		: 支払手形データ設定処理を行う。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010.04.28</br>
        /// <br>UpdateNote  : 2010/06/30 葛軍 各種仕様変更／障害対応</br>
        /// <br>              RedMine# 10658</br>
        /// <br>UpdateNote  : 2010/12/20 徐佳 手形金額の数値変換処理を修正する。</br>
        /// <br>UpdateNote  : 2013/04/02 王君</br>
        /// <br>管理番号    : 10901273-00 2013/05/15配信分</br>
        /// <br>            : redmine #35247 仕入総括オプションの調査</br>
        /// </remarks>
        private bool SetDraftData(ref PayDraftData payDraftData, int rowIndex)
        {
            // 新規の場合
            if (this._updateMode == ScreenUpdateMode.New)
            {
                // 表示用ﾊﾟﾗﾒｰﾀの準備
                if (this._payDraftData == null)
                    this.SetNewDraftData(ref payDraftData, rowIndex);
                else
                // --- UPD 2012/10/18 -------------------------------------------------->>>>>
                //    payDraftData = this._payDraftData;
                {
                    payDraftData = this._payDraftData;
                    // ----- ADD 王君 2013/04/02 Redmine#35247 ----->>>>> 
                    if (this._supplierSummary)
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                        {
                            payDraftData.SectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0').PadRight(6, ' ');
                        }
                        else
                        {
                            payDraftData.SectionCode = "";
                        }
                    }
                    else
                    {
                        // 拠点コード
                        payDraftData.SectionCode = this._loginSectionCode.PadLeft(2, '0').PadRight(6, ' ');
                    }
                    // ----- ADD 王君 2013/04/02 Redmine#35247 -----<<<<<
                    // 期日
                    DateTime validityTerm;
                    GetValidityTerm(rowIndex, out validityTerm);
                    payDraftData.ValidityTerm = Convert.ToInt32(validityTerm.ToString("yyyyMMdd"));
                    // 金額
                    try
                    {
                        payDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                    }
                    catch
                    {
                        payDraftData.Payment = 0;
                    }
                }
                // --- UPD 2012/10/18 --------------------------------------------------<<<<<
                return true;
            }
            // 更新の場合
            else
            {
                if (this.nedtPaymentSlipNo.GetInt() != 0)
                {
                    if (this._payDraftData == null)
                    {
                        List<PayDraftData> retList = new List<PayDraftData>();
                        if (SearchDraftData(ref retList) == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            payDraftData = (PayDraftData)retList[0];
                            // 論理削除区分=1:論理削除
                            if (payDraftData.LogicalDeleteCode == 1)
                            {
                                TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "手形データが削除されている為、処理出来ません。",
                                      0,
                                      MessageBoxButtons.OK);

                                // 保存ボタンを利用不可にする
                                _btnSave = false;
                                if (ParentToolbarSettingEvent != null)
                                {
                                    ParentToolbarSettingEvent(this);
                                }
                                return false;
                            }

                            // --- ADD 2010/06/30 ----------------------------------------->>>>>
                            DateTime validityTerm;
                            GetValidityTerm(rowIndex, out validityTerm);
                            payDraftData.ValidityTerm = Convert.ToInt32(validityTerm.ToString("yyyyMMdd"));
                            // --- UPD 2010/12/20 ----------------------------------------->>>>>
                            //payDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                            try
                            {
                                payDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                            }
                            catch
                            {
                                payDraftData.Payment = 0;
                            }
                            // --- UPD 2010/12/20 -----------------------------------------<<<<<
                            // --- ADD 2010/06/30 ----------------------------------------->>>>>
                        }
                        else
                            this.SetNewDraftData(ref payDraftData, rowIndex);
                    }
                    else
                    {
                        // 表示用ﾊﾟﾗﾒｰﾀの準備
                        // --- ADD 2010/06/30 ----------------------------------------->>>>>
                        DateTime validityTerm;
                        GetValidityTerm(rowIndex, out validityTerm);
                        this._payDraftData.ValidityTerm = Convert.ToInt32(validityTerm.ToString("yyyyMMdd"));
                        this._payDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
                        // --- ADD 2010/06/30 ----------------------------------------->>>>>
                        payDraftData = this._payDraftData;
                    }
                    return true;
                }
                return false;
            }

        }
        /// <summary>
        /// 支払手形データの新規処理
        /// </summary>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note		: 支払手形データの新規処理を行う。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010.04.28</br>
        /// <br>UpdateNote  : 2010.05.16 姜凱 redmine#7606の対応</br>
        /// <br>UpdateNote  : 2013/04/02 王君</br>
        /// <br>管理番号    : 10901273-00 2013/05/15配信分</br>
        /// <br>            : redmine #35247 仕入総括オプションの調査</br>
        /// </remarks>
        private void SetNewDraftData(ref PayDraftData paraPayDraftData, int rowIndex)
        {
             // ----- ADD 王君 2013/04/02 Redmine#35247 ----->>>>> 
            if (this._supplierSummary)
            {
                if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                {
                    paraPayDraftData.SectionCode = "";
                }
                else
                {
                    paraPayDraftData.SectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0').PadRight(6, ' ');
                }
            }
            else
            {
                // ----- ADD 王君 2013/04/02 Redmine#35247 -----<<<<<
            // 拠点コード
            paraPayDraftData.SectionCode = this._loginSectionCode.PadLeft(2, '0').PadRight(6, ' ');
            }// ADD 王君 2013/04/02 Redmine#35247
            // 手形種別
            paraPayDraftData.DraftKindCd = 0;
            // 自他振区分
            paraPayDraftData.DraftDivide = 0;
            // 振出日
            paraPayDraftData.DraftDrawingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            // 期日
            DateTime validityTerm;
            GetValidityTerm(rowIndex, out validityTerm);
            paraPayDraftData.ValidityTerm = Convert.ToInt32(validityTerm.ToString("yyyyMMdd"));
            // 処理日
            paraPayDraftData.ProcDate = Convert.ToInt32(paraPayDraftData.DraftDrawingDate.ToString("yyyyMMdd"));
            // 取引先仕入先コード
            paraPayDraftData.SupplierCd = this.tNedit_SupplierCd.GetInt();
            Supplier supplier = new Supplier();
            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 取引先仕入先拠点コード
                paraPayDraftData.AddUpSecCode = supplier.PaymentSectionCode;
                // 取引先仕入先名称
                paraPayDraftData.SupplierSnm = supplier.SupplierSnm;
            }
            // --- ADD 2010/05/16 -------------->>>>>
            // 入金金額
            // --- UPD 2010/12/20 ----------------------------------------->>>>>
            //paraPayDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
            try
            {
                paraPayDraftData.Payment = Convert.ToInt64(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value.ToString().Replace(",", ""));
            }
            catch
            {
                paraPayDraftData.Payment = 0;
            }
            // --- UPD 2010/12/20 -----------------------------------------<<<<<
            // --- ADD 2010/05/16 --------------<<<<<
        }

        /// <summary>
        /// 支払手形データ検索処理
        /// </summary>
        /// <param name="retList">支払手形データオブジェクトリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払手形データ検索処理を行う。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010.04.28</br>
        /// </remarks>
        private int SearchDraftData(ref List<PayDraftData> retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (_payDraftDataAcs == null)
                _payDraftDataAcs = new PayDraftDataAcs();
            PayDraftData paraPayDraftData = new PayDraftData();
            paraPayDraftData.EnterpriseCode = this._enterpriseCode;
            paraPayDraftData.PaymentSlipNo = this.nedtPaymentSlipNo.GetInt();
            status = this._payDraftDataAcs.Search(out retList, 1, paraPayDraftData);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            "SFSIR02102U",							// アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._payDraftDataAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        break;
                    }
            }
            return status;
        }
        // --- ADD 2012/10/18 ----------------------------------------->>>>>
        /// <summary>
        /// 受取手形データ検索処理
        /// </summary>
        /// <param name="retList">受取手形データオブジェクトリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 受取手形データ検索処理を行う。</br>
        /// <br>Programmer	: 宮本</br>
        /// <br>Date		: 2012/10/18</br>
        /// </remarks>
        private int SearchRcvDraftData(ref List<RcvDraftData> retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (_rcvDraftDataAcs == null)
                _rcvDraftDataAcs = new RcvDraftDataAcs();
            RcvDraftData paraRcvDraftData = new RcvDraftData();
            paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
            paraRcvDraftData.RcvDraftNo = this._payDraftData.PayDraftNo;
            // ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
            paraRcvDraftData.BankAndBranchCd = this._payDraftData.BankAndBranchCd;
            paraRcvDraftData.DraftDrawingDate = this._payDraftData.DraftDrawingDate;
            // ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<
            status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            "SFSIR02102U",							// アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._rcvDraftDataAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        break;
                    }
            }
            return status;
        }
        // --- ADD 2012/10/18 -----------------------------------------<<<<<

        /// <summary>
        /// 期日チェック処理
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 期日チェック処理を行う。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010.04.28</br>
        /// </remarks>
        private bool ValidityTermCheck(int rowIndex)
        {
            if (this.datePaymentDate.GetDateTime() != DateTime.MinValue)
            {
                DateTime validityTerm;
                GetValidityTerm(rowIndex, out validityTerm);
                if (validityTerm != DateTime.MinValue && this.datePaymentDate.GetDateTime() > validityTerm)
                {
                    TMsgDisp.Show(this,
                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                          this.Name,
                          "支払日以上の日付を入力して下さい。",
                          0,
                          MessageBoxButtons.OK);

                    this.grdPaymentKind.Focus();
                    this.grdPaymentKind.Rows[rowIndex].Cells[ctDay].Activate();
                    this.grdPaymentKind.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }
            }
            return true;
        }
        //ADD END 2009/04/28 gejun forM1007A-手形データ追加

        private void SetPayTotal()
        {
            if (this._searchFlg == false)
            {
                return;
            }

            // 支払合計算出
            double total = GetPayTotal();
            //this.nedtPaymentTotal.SetValue(total); // DEL 2009/12/20
            this.nedtPaymentTotal.DataText = total.ToString(); // ADD 2009/12/20

            double payment = 0;
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                if ((this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == DBNull.Value) ||
                    (string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value == "")
                {
                    payment += 0 - double.Parse(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag.ToString());
                    continue;
                }
                
                double targetValue = double.Parse((string)this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Value);

                payment += targetValue - double.Parse(this.grdPaymentKind.Rows[rowIndex].Cells[ctPayment].Tag.ToString());
            }

            // ---UPD 2011/02/09----------------->>>>
            //// 手数料
            //double feePayment = this.nedtFeePayment.GetValue();
            //// 値引
            //double discountPayment = this.nedtDiscountPayment.GetValue();

            // 手数料
            double feePayment = 0;
            // 値引
            double discountPayment = 0;
            if (this.nedtPaymentSlipNo.GetInt() == 0)
            {
                // 手数料
                feePayment = this.nedtFeePayment.GetValue();
                // 値引
                discountPayment = this.nedtDiscountPayment.GetValue();
            }
            else
            {
                // 手数料
                feePayment = this.nedtFeePayment.GetValue() - (double)this._prevFeePayment;
                // 値引
                discountPayment = this.nedtDiscountPayment.GetValue() - (double)this._prevDiscountPayment;
            }
            // ---UPD 2011/02/09-----------------<<<<
            // 支払金額 = 支払額＋手数料＋値引
            total = payment + feePayment + discountPayment;

            //------------------
            // 支払金額情報更新
            //------------------
            // 今回支払額
            Int64 stockTotalPayBalance = this._searchSuplierPayRet.ThisTimePayNrml + (Int64)total;
            this.lbl_StockTotalPayBalance.Text = stockTotalPayBalance.ToString("###,##0");
            // 差引残高
            Int64 balance = this._searchSuplierPayRet.StockTtl3TmBfBlPay + this._searchSuplierPayRet.StockTtl2TmBfBlPay + this._searchSuplierPayRet.LastTimePayment - stockTotalPayBalance;
            this.lbl_Balance.Text = balance.ToString("###,##0");
            // 更新後残高
            Int64 ttlBlcPay = balance + this._searchSuplierPayRet.OfsThisTimeStock + this._searchSuplierPayRet.OfsThisStockTax;
            this.lbl_TtlBlcPay.Text = ttlBlcPay.ToString("###,##0");
        }

        private void ChangeGridEnabled(Activation rowActivation)
        {
            for (int rowIndex = 0; rowIndex < this.grdPaymentKind.Rows.Count; rowIndex++)
            {
                this.grdPaymentKind.Rows[rowIndex].Activation = rowActivation;
            }
        }

        /// <summary>
        /// CellChange イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : セルの値が変更されたときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// <br>UpdateNote  : 2010/06/30 葛軍 各種仕様変更／障害対応</br>
        /// <br>              RedMine# 10658</br>
        /// </remarks>
        private void grdPaymentKind_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;
            int rowIndex = uGrid.ActiveCell.Row.Index;

            if (columnIndex != 3)
            {
                return;
            }

            // 金種区分取得
            int depositKindDiv = (int)uGrid.Rows[rowIndex].Cells[ctMoneyKindDiv].Value;

            // 金種区分が「105：手形」、「107:小切手」以外の場合
            if ((depositKindDiv != 105) && (depositKindDiv != 107))
            {
                return;
            }

            // セルの値を取得
            // --- UPD m.suzuki 2010/07/12 ---------->>>>>
            //string targetText = e.Cell.Text.Trim();
            string targetText = ToInt64( e.Cell.Text.Trim() ).ToString( "###,###" );
            // --- UPD m.suzuki 2010/07/12 ----------<<<<<

            if (targetText == "")
            {
                // 期日列を入力不可に設定
                uGrid.Rows[rowIndex].Cells[ctYear].Value = DBNull.Value;
                uGrid.Rows[rowIndex].Cells[ctMonth].Value = DBNull.Value;
                uGrid.Rows[rowIndex].Cells[ctDay].Value = DBNull.Value;
                uGrid.Rows[rowIndex].Cells[ctYear].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[ctMonth].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[ctDay].Activation = Activation.Disabled;

            }
            else
            {
                // --- ADD 2010/06/30 ----------------------------------------->>>>>
                // 期日列が未入力の場合
                if ("" == uGrid.Rows[rowIndex].Cells[ctYear].Text.Trim() ||
                    "" == uGrid.Rows[rowIndex].Cells[ctMonth].Text.Trim() ||
                    "" == uGrid.Rows[rowIndex].Cells[ctDay].Text.Trim())
                {
                // --- ADD 2010/06/30 ----------------------------------------->>>>>
                    // 期日列を入力可に設定
                    uGrid.Rows[rowIndex].Cells[ctYear].Activation = Activation.AllowEdit;
                    uGrid.Rows[rowIndex].Cells[ctMonth].Activation = Activation.AllowEdit;
                    uGrid.Rows[rowIndex].Cells[ctDay].Activation = Activation.AllowEdit;

                    uGrid.Rows[rowIndex].Cells[ctYear].Value = DateTime.Today.Year.ToString() + "年";
                    uGrid.Rows[rowIndex].Cells[ctMonth].Value = DateTime.Today.Month.ToString() + "月";
                    uGrid.Rows[rowIndex].Cells[ctDay].Value = DateTime.Today.Day.ToString() + "日";
                }// --- ADD 2010/06/30 ----------------------------------------->>>>>
            }
        }

        /// <summary>
        /// KeyDown イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 支払内訳グリッド上でKeyが押されたときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// </remarks>
        private void grdPaymentKind_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;
            int rowIndex = uGrid.ActiveCell.Row.Index;

            // -------------------------------------------
            // カーソルキー押下時のフォーカス制御を行います
            // -------------------------------------------
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (rowIndex == 0)
                    {
                        // 入金日にフォーカス設定
                        e.Handled = true;
                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;
                        this.datePaymentDate.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        uGrid.DisplayLayout.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    break;
                case Keys.Down:
                    if (rowIndex == uGrid.Rows.Count - 1)
                    {
                        // 手数料にフォーカス設定
                        e.Handled = true;
                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;
                        this.nedtFeePayment.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        uGrid.DisplayLayout.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    break;
                case Keys.Left:
                    // --- UPD m.suzuki 2010/07/12 ---------->>>>>
                    //if (columnIndex > 3)
                    //{
                    //    e.Handled = true;
                    //    uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                    //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    //}

                    // 編集モードの時
                    if ( (uGrid.ActiveCell.Column.DataType != typeof( Boolean )) && (uGrid.ActiveCell.IsInEditMode == true) )
                    {
                        // 選択文字長によらず、選択開始位置が先頭ならば、左項目へ移動する
                        if ( uGrid.ActiveCell.SelStart == 0 )
                        {
                            uGrid.PerformAction( UltraGridAction.PrevCell );
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        uGrid.PerformAction( UltraGridAction.PrevCell );
                        e.Handled = true;
                    }
                    // --- UPD m.suzuki 2010/07/12 ----------<<<<<
                    break;
                case Keys.Right:
                    // --- UPD m.suzuki 2010/07/12 ---------->>>>>
                    //if (columnIndex < 6)
                    //{
                    //    e.Handled = true;
                    //    uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                    //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    //}

                    // エディット編集モードの時
                    if ( (uGrid.ActiveCell.Column.DataType != typeof( Boolean )) && (uGrid.ActiveCell.IsInEditMode == true) )
                    {
                        // カーソルが文字列の一番右端の時
                        if ( (uGrid.ActiveCell.SelLength == 0) &&
                            (uGrid.ActiveCell.SelStart == uGrid.ActiveCell.Text.Length) )
                        {
                            // "日"から"→"キーで移動するとき、手形データ登録ＵＩを表示する準備をする。
                            // (※フラグを立てておくと、grdDepositKind_AfterExitEditModeでＵＩ起動される)
                            if ( columnIndex == this.grdPaymentKind.DisplayLayout.Bands[0].Columns[ctDay].Index )
                            {
                                this._notMouseMoveFlg = true;
                            }

                            uGrid.PerformAction( UltraGridAction.NextCell );
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        uGrid.PerformAction( UltraGridAction.NextCell );
                        e.Handled = true;
                    }
                    // --- UPD m.suzuki 2010/07/12 ----------<<<<<
                    break;
                case Keys.Escape:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            UltraGridCell cell = uGrid.ActiveCell;
                            uGrid.ActiveCell = null;
                            if (cell.Row.Index != uGrid.Rows.Count - 1)
                            {
                                uGrid.Rows[cell.Row.Index + 1].Activate();
                            }
                            else if (uGrid.Rows.Count == 1)
                            {
                                uGrid.ActiveCell = null;
                            }
                            else
                            {
                                uGrid.Rows[cell.Row.Index - 1].Activate();
                            }
                            uGrid.Rows[cell.Row.Index].Activate();
                            uGrid.ActiveCell = cell;
                            e.Handled = true;
                        }
                    } 
                    break;
            }
        }

        /// <summary>
        /// KeyPress イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 支払内訳グリッド上でKeyが押されたときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// </remarks>
        private void grdPaymentKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;

            switch (columnIndex)
            {
                case 3: // 入金金額
                    {
                        // --- UPD m.suzuki 2010/07/12 ---------->>>>>
                        # region // DEL
                        //// 「Backspace」キーを押された時
                        //if ((byte)e.KeyChar == (byte)'\b')
                        //{
                        //    return;
                        //}

                        //// 対象セルのテキスト取得
                        //string retText;
                        //string targetText = uGrid.ActiveCell.Text;
                        //uGrid.PerformAction(UltraGridAction.EnterEditMode);

                        //// セルのテキストが選択されている場合
                        //if (uGrid.ActiveCell.SelText == targetText)
                        //{
                        //    // 数値のみ入力可
                        //    if ((byte)e.KeyChar != (byte)'-')
                        //    {
                        //        if ((byte)e.KeyChar < (byte)'1' || (byte)'9' < (byte)e.KeyChar)
                        //        {
                        //            e.KeyChar = '\0';
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    // カンマ削除
                        //    retText = RemoveComma(targetText);

                        //    // 文字数が10文字だったら入力不可
                        //    if ((retText[0] != '-') && (retText.Length == 10))
                        //    {
                        //        e.KeyChar = '\0';
                        //    }
                        //    else if ((retText[0] == '-') && (retText.Length == 11))
                        //    {
                        //        e.KeyChar = '\0';
                        //    }
                        //    else
                        //    {
                        //        // 数値以外の時
                        //        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        //        {
                        //            // 入力値の1文字目は「,」不可
                        //            if (targetText == "")
                        //            {
                        //                if ((byte)e.KeyChar != (byte)'-')
                        //                {
                        //                    e.KeyChar = '\0';
                        //                }
                        //            }
                        //            else
                        //            {
                        //                if (targetText[targetText.Length - 1].ToString() == ",")
                        //                {
                        //                    e.KeyChar = '\0';
                        //                }

                        //                // 「,」は入力可
                        //                if ((byte)e.KeyChar == ',')
                        //                {
                        //                    return;
                        //                }
                        //                else
                        //                {
                        //                    e.KeyChar = '\0';
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            // 入力値の1文字目は「0」不可
                        //            if (targetText == "")
                        //            {
                        //                if ((byte)e.KeyChar != (byte)'-')
                        //                {
                        //                    if ((byte)e.KeyChar < (byte)'1' || (byte)'9' < (byte)e.KeyChar)
                        //                    {
                        //                        e.KeyChar = '\0';
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        # endregion

                        string retText = "";
                        string targetText = "";
                        int beginIndex, endIndex;
                        if ( uGrid.ActiveCell.Text == "" )
                        {
                            if ( !NumberInputCheck( e.KeyChar ) )
                            {
                                e.KeyChar = '\0';
                            }
                        }
                        else
                        {
                            targetText = RemoveComma( uGrid.ActiveCell.Text );
                            if ( uGrid.ActiveCell.SelText == uGrid.ActiveCell.Text )
                            {
                                if ( !NumberInputCheck( e.KeyChar ) )
                                {
                                    e.KeyChar = '\0';
                                }

                            }
                            else
                            {
                                beginIndex = uGrid.ActiveCell.SelStart;
                                endIndex = uGrid.ActiveCell.SelStart + uGrid.ActiveCell.SelLength;
                                if ( !NumberInputCheck( e.KeyChar ) )
                                {
                                    for ( int index = 0; index < targetText.Length; index++ )
                                    {
                                        if ( index < beginIndex || index >= endIndex )
                                            retText = retText + targetText[index];
                                        else
                                            continue;
                                    }
                                    if ( retText != "" && ToInt64( retText ) == 0 )
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }

                            }

                        }

                        // 現在位置より右側に'-'(ハイフン)があったら制御キー以外はキャンセル
                        if ( ((uGrid.ActiveCell.SelStart + uGrid.ActiveCell.SelLength) <= uGrid.ActiveCell.Text.IndexOf( '-' )) && !char.IsControl( e.KeyChar ) )
                        {
                            e.Handled = true;
                            return;
                        }

                        // 標準の入力チェック
                        if ( !KeyPressNumCheck( 10, 0, uGrid.ActiveCell.Text, e.KeyChar, uGrid.ActiveCell.SelStart, uGrid.ActiveCell.SelLength, true ) )
                        {
                            e.Handled = true;
                            return;
                        }
                        // --- UPD m.suzuki 2010/07/12 ----------<<<<<
                        break;
                    }
                case 4: // 年
                    {
                        // 「Backspace」キーを押された時
                        if ((byte)e.KeyChar == (byte)'\b')
                        {
                            return;
                        }

                        // 対象セルのテキスト取得
                        string targetText = uGrid.ActiveCell.Text;
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);

                        // セルのテキストが選択されている場合
                        if (uGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            if ((byte)e.KeyChar != (byte)'-')
                            {
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    e.KeyChar = '\0';
                                }
                            }
                        }
                        else
                        {
                            if (targetText.Length == 4)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {
                                // 数値のみ入力可
                                if ((byte)e.KeyChar != (byte)'-')
                                {
                                    if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 5: // 月
                case 6: // 日
                    {
                        // 「Backspace」キーを押された時
                        if ((byte)e.KeyChar == (byte)'\b')
                        {
                            return;
                        }

                        // 対象セルのテキスト取得
                        string targetText = uGrid.ActiveCell.Text;
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);

                        // セルのテキストが選択されている場合
                        if (uGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            if ((byte)e.KeyChar != (byte)'-')
                            {
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    e.KeyChar = '\0';
                                }
                            }
                        }
                        else
                        {
                            if (targetText.Length == 2)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {
                                // 数値のみ入力可
                                if ((byte)e.KeyChar != (byte)'-')
                                {
                                    if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        // --- ADD m.suzuki 2010/07/12 ---------->>>>>
        /// <summary>
        /// セルアクティブ後の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_AfterCellActivate( object sender, EventArgs e )
        {
            try
            {
            }
            finally
            {
                // 入力可能セルの時は編集モードにする
                grdPaymentKind.PerformAction( UltraGridAction.EnterEditMode );
            }
        }
        /// <summary>
        /// 数値入力チェック
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private bool NumberInputCheck( char ch )
        {
            // ※KeyPressNumCheckで再度チェックする前提で、
            //   制御文字、ハイフンを許可する。

            // 制御文字はOK
            if ( Char.IsControl( ch ) )
            {
                return true;
            }

            // 数字はOK
            if ( (byte)'1' <= (byte)ch && (byte)ch <= (byte)'9' )
            {
                return true;
            }

            // '-'はOK
            if ( (byte)'-' == (byte)ch )
            {
                return true;
            }

            // それ以外はNG
            return false;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Int64 ToInt64( string text )
        {
            // ※Convert.ToInt32を使用すると、"-"のような入力は例外発生するので、
            //   try-catchする。

            try
            {
                return Convert.ToInt64( text );
            }
            catch
            {
                return 0;
            }
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
        private bool KeyPressNumCheck( int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg )
        {
            // 制御キーが押された？
            if ( Char.IsControl( key ) )
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if ( !Char.IsDigit( key ) )
            {
                // 小数点または、マイナス以外
                if ( (key != '.') && (key != '-') )
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if ( sellength > 0 )
            {
                _strResult = prevVal.Substring( 0, selstart ) + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if ( key == '-' )
            {
                if ( (minusFlg == false) || (selstart > 0) || (_strResult.IndexOf( '-' ) != -1) )
                {
                    return false;
                }
            }

            // 小数点のチェック
            if ( key == '.' )
            {
                if ( (priod <= 0) || (_strResult.IndexOf( '.' ) != -1) )
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring( 0, selstart )
                + key
                + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );

            // 桁数チェック！
            if ( _strResult.Length > keta )
            {
                if ( _strResult[0] == '-' )
                {
                    if ( _strResult.Length > (keta + 1) )
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
            if ( priod > 0 )
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf( '.' );

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    if ( _pointPos > _Rketa )
                    {
                        return false;
                    }
                }
                else
                {
                    if ( _strResult.Length > _Rketa )
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if ( priod < _priketa )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // --- ADD m.suzuki 2010/07/12 ----------<<<<<

        /// <summary>
        /// Leave イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロール(支払内訳グリッド)からフォーカスが離れたときに発生します。 </br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// </remarks>
        private void grdPaymentKind_Leave(object sender, EventArgs e)
        {
            this.grdPaymentKind.ActiveCell = null;
            this.grdPaymentKind.ActiveRow = null;
        }

		#endregion

		# region public class
		/// <summary>
		/// 画面状態保持クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面状態を保持する為の外部ＸＭＬファイルのクラスです。</br>
		/// <br>Programmer : 22024 寺坂　誉志</br>
		/// <br>Date       : 2006.10.23</br>
		/// </remarks>
		[Serializable]
		public class SFSIR02102U_DisplayInfo
		{
			/// <summary>コンストラクタ</summary>
			public SFSIR02102U_DisplayInfo()
			{
				_detailPaymentList = 0;
			}

			/// <summary>支払一覧 詳細表示</summary>
			private Int32 _detailPaymentList;

			/// <summary>支払一覧 詳細表示 プロパティ</summary>
			public Int32 DetailPaymentList
			{
				get { return _detailPaymentList; }
				set { _detailPaymentList = value; }
			}
		}
		# endregion

        private void nedt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TNedit tNedit = (TNedit)sender;

            if (tNedit.DataText.Trim() == "")
            {
                return;
            }

            string targetText = tNedit.DataText.Trim();

            if (targetText[0] == '-')
            {
                tNedit.ExtEdit.Column = 14;
            }
            else
            {
                tNedit.ExtEdit.Column = 13;
            }
        }

        private void gridPaymentList_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (SaveBeforeClose() == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                //this.grdPaymentKind.Rows[this._prevDoubleClickRowIndex].Activate(); // DEL 王君　2013/03/01 Redmine#33741
                //----- ADD 王君　2013/03/01 Redmine#33741 -------------------->>>>>
                this.gridPaymentList.Rows[e.Row.Index].Selected = false;
                this.gridPaymentList.Rows[this._prevDoubleClickRowIndex].Activate();
                this.gridPaymentList.Rows[this._prevDoubleClickRowIndex].Selected = true;
                //----- ADD 王君　2013/03/01 Redmine#33741 --------------------<<<<<
                return;
            }

            this._prevDoubleClickRowIndex = e.Row.Index;

            InitializeDisplay(1);

            UltraGridRow ultraGridRow = this.gridPaymentList.ActiveRow;
            if (ultraGridRow != null)
            {
                // 現在選択中のGridRowに対応するDataRowを取得
                DataRow dr = _paymentListDataTable.Rows[ultraGridRow.ListIndex];

                PaymentSlp paymentSlp;
                int paymentSlipNo = TStrConv.StrToIntDef(dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);
                
                _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);
                
                if (paymentSlp != null)
                {
                    // 支払伝票画面表示
                    SetPaymentSlpToDisp(paymentSlp);
                    // ---ADD 2011/02/09------------->>>>
                    // 前回手数料をセット
                    this._prevFeePayment = paymentSlp.FeePayment;
                    // 前回値引をセット
                    this._prevDiscountPayment = paymentSlp.DiscountPayment;
                    // ---ADD 2011/02/09-------------<<<<
                }
            }
        }

        private void gridPaymentList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this._firstFlg)
            {
                this._firstFlg = false;
                return;
            }

            UltraGridRow ultraGridRow = this.gridPaymentList.ActiveRow;
            if (ultraGridRow != null)
            {
                // 現在選択中のGridRowに対応するDataRowを取得
                DataRow dr = _paymentListDataTable.Rows[ultraGridRow.ListIndex];

                PaymentSlp paymentSlp;
                int paymentSlipNo = TStrConv.StrToIntDef(dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);

                _paymentSlpSearch.GetPaymentSlp(out paymentSlp, paymentSlipNo);

                if (paymentSlp != null)
                {
                    // 支払伝票一覧情報をクリア
                    this.lblListInfo.Text = string.Empty;

                    // 支払伝票番号
                    if (paymentSlp.PaymentSlipNo != 0)
                    {
                        switch (paymentSlp.DebitNoteDiv)
                        {
                            case 1:
                                //=======================
                                // 赤伝の時
                                //=======================
                                // 赤参照モード
                                this.lblListInfo.Text = "赤支払伝票の為、更新 は出来ません。";
                                break;
                            case 2:
                                //=======================
                                // 相殺済み黒伝の時
                                //=======================
                                // 参照モード
                                this.lblListInfo.Text = "相殺済み伝票の為、更新 / 削除 は出来ません。";
                                break;
                            default:
                                //=======================
                                // 通常伝票の時
                                //=======================
                                // 通常支払
                                if (paymentSlp.AutoPayment == 0)
                                {
                                    if ((TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= this._paymentSlpSearch.GetCAddUpUpDate()) ||
                                        (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) <= this._paymentSlpSearch.GetLastMonthlyDate()))
                                    {
                                        // 参照モード
                                        this.lblListInfo.Text = "締済支払伝票の為、 更新 / 削除 は出来ません。";
                                    }
                                }
                                // 自動支払
                                else
                                {
                                    // 参照モード
                                    this.lblListInfo.Text = "自動支払伝票の為、更新 / 削除 は出来ません。";
                                }
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// スプリッターマウスEnter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールにマウスが入った時にします。 </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/08</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/08</br>
        /// </remarks>
        private void splitter1_MouseLeave(object sender, EventArgs e)
        {
            splitter1.BackColor = Color.FromArgb(222, 239, 255);
        }

        // --- ADD 2010/12/20 ----------------------------------------->>>>>
        /// <summary>
        /// スプリッターマウスLeave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールの内容が変更する時にします。 </br>
        /// <br>Programmer  : 徐佳</br>
        /// <br>Date        : 2010/12/20</br>
        /// </remarks>
        private void nedtFeePayment_Validated(object sender, EventArgs e)
        {
            SetPayTotal();
        }
        // --- ADD 2010/12/20 -----------------------------------------<<<<<
        // --- ADD 2010/12/20 ----------------------------------------->>>>>
        /// <summary>
        /// スプリッターマウスLeave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールの内容が変更する時にします。 </br>
        /// <br>Programmer  : 徐佳</br>
        /// <br>Date        : 2010/12/20</br>
        /// </remarks>
        private void nedtDiscountPayment_Validated(object sender, EventArgs e)
        {
            SetPayTotal();
        }
        // --- ADD 2010/12/20 -----------------------------------------<<<<<

        // --- ADD 2012/09/07 ----------------------------------------->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●仕入先総括オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._supplierSummary = true;
            }
            else
            {
                this._supplierSummary = false;
            }
            #endregion
        }
        // --- ADD 2012/09/07 -----------------------------------------<<<<<
    }
}