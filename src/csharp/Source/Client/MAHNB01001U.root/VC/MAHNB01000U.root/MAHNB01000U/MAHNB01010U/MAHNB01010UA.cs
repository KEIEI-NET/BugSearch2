using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Diagnostics;// 2010/02/26

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上入力のフォームクラスです。</br>
	/// <br>Programmer : 20056 對馬 大輔</br>
	/// <br>Date       : 2007.09.10</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
	/// <br>2009.06.17 21024 佐々木 健 MANTIS[0013518] 車台番号の範囲チェックを追加</br>
	/// <br>                           MANTIS[0013536] 年式の範囲エラーで入力前の値に戻らない不具合の修正</br>
	/// <br>2009.06.18 21024 佐々木 健 MANTIS[0013552] 伝票ガイドボタン、伝票呼出(F11)で現金売上の伝票を呼び出した場合に伝票区分が空白になる障害の修正</br>
	/// <br>2009.07.14 22018 鈴木 正臣 MANTIS[0013804] 車台番号の範囲チェックを一部修正(範囲:1～xなら入力:000…0を許可しない)</br>
	/// <br>2009.07.15 22018 鈴木 正臣 初期描画の不正を抑える為、再描画するよう変更。</br>
	/// <br>2009.08.03 21024 佐々木 健 MANTIS[0013907] 得意先名称に略称を使用するように修正</br>
	/// <br>2009.08.10 22018 鈴木 正臣 見出貼付機能の追加(ファンクションボタン(X)追加)</br>
	/// <br>2009/09/04 20056 對馬 大輔 MANTIS[0014226] 車台番号入力時の部品検索年式絞込機能を有効となるように修正</br>
	/// <br>2009/09/08 20056 對馬 大輔 MANTIS[0013827] 品番入力モード切替時のボタン選択初期位置を変更</br>
	/// <br>2009/09/09 20056 對馬 大輔 MANTIS[0013994] 明細部画面表示無し状態でフォーカスを指定しないように変更</br>
	/// <br>                           MANTIS[0014258] 保存後、続けて入力した場合のフォーカス位置を修正</br>
	/// <br>2009/09/10 20056 對馬 大輔 MANTIS[0013830] 新規ボタンクリック時、得意先コードも初期化するように変更</br>
	/// <br>                           MANTIS[0014027] 伝票照会終了時、Disposeを追加</br>
	/// <br>                           MANTIS[0014162] 修正呼出時、諸元、カラー、トリム、装備情報の参照を可能にする</br>
	/// <br>                           MANTIS[0013891] 売上日変更時の商品価格再取得処理で、商品情報(在庫情報)の再取得を行わないように変更<の/br>
	/// <br>2009/10/15 22018 鈴木 正臣 MANTIS[0014360] 見出貼付機能の修正。（フル型式固定番号＝ゼロを含む場合の対応）</br>
	/// <br>                           MANTIS[0014406] 年式・車台番号をセット後に再検索した時、年式・車台番号をクリアしないよう変更</br>
	/// <br>Update Note : 2009/09/08② 張凱</br>
	/// <br>              PM.NS-2-A・車輌管理</br>
	/// <br>              車輌管理機能の追加</br>
	/// <br>2009/10/21 22018 鈴木 正臣 MANTIS[0014465] 見出貼付機能の修正。（型式検索後に品番入力モードにして型式手入力した場合の対応）</br>
	/// <br>Update Note : 2009/10/19 張凱</br>
	/// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
	/// <br>              PM.NS保守依頼②を追加</br>
	/// <br>Update Note : 2009/11/13 李占川 保守依頼③対応</br>
	/// <br>              担当者、受注者、発行者の初期表示内容の変更</br>
	/// <br>              TBO検索の修正</br>
	/// <br>Update Note : 2009/11/24 張凱 保守依頼③対応</br>
	/// <br>              伝票呼出時、伝票発行を行わず、伝票の更新のみ行える機能を追加する</br>
	/// <br>Update Note : 2009/12/08 張凱 保守依頼③対応</br>
	/// <br>              車種選択ガイドでメーカーのみの指定を可能にする</br>
	/// <br>Update Note : 2009/12/17 對馬 大輔 保守依頼③対応</br>
	/// <br>             MANTIS[14785] BLコードガイドから標準価格選択を行った場合も選択した標準価格を有効にする</br>
	/// <br>             MANTIS[14756] 既存修正時、伝票タイプの明細数に従い明細数を制限する</br>
	/// <br>             MANTIS[14755] 伝票修正時でも、追加明細は印刷用品番をセットするように変更</br>
	/// <br>             MANTIS[14717] 標準価格選択で選択した価格を売価へ反映するように変更</br>
	/// <br>Update Note : 2009/12/25 對馬 大輔 保守依頼③対応</br>
	/// <br>             MANTIS[14829] 型式選択で入力した年式、車台番号を売伝へ反映する</br>
	/// <br>Update Note : 2010/01/13 對馬 大輔 保守依頼③対応</br>
	/// <br>             MANTIS[14880] 年式、車台番号を入力した伝票を伝票番号直接入力し修正呼出しすると不正終了する件の対応</br>
	/// <br>             MANTIS[14881] 伝票番号直接入力し、修正呼出しすると車輌情報の一部が変更可能になっている件の対応</br>
	/// <br>Update Note : 2009/12/23 張凱</br>
	/// <br>              PM.NS-5-A・PM.NS保守依頼④</br>
	/// <br>              PM.NS保守依頼④を追加</br>
	/// <br>Update Note : 2010/01/27 張凱 ４次改良対応</br>
	/// <br>              PM.NS保守依頼４次改良対応を追加</br>
	/// <br>Update Note:  2010/02/02 張凱</br>
	/// <br>           :  Redmine#2760の対応</br>
	/// <br>Update Note:  2010/02/03 張凱</br>
	/// <br>           :  Redmine#2793の対応</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note:  2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
	/// <br>              ①単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
	/// <br>              ②計上残区分の仕様変更</br>
	/// <br>Update Note:  2010/03/10 22018 鈴木 正臣</br>
	/// <br>           :  ヘッダ部の最終項目から明細部へ移動するように修正。（最終項目がトリム以外で不正だった為）</br>
    /// <br>Update Note : 2010/03/15 佐々木 健</br>
    /// <br>              SCM回答送信処理のパラメータ修正</br>
    /// <br>Update Note : 2010/03/30 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>              ①SCMオプションが無効の場合、リサイクル関連項目の読込を行わない</br>
    /// <br>              ②回答送信後、回答処理ボタンの押下を不可とする</br>
    /// <br>              ③回答処理ボタン入力制御を追加</br>
    /// <br>              ④問合せ一覧よりキャンセルデータを読み込んだ場合、返品として展開する</br>
    /// <br>Update Note:  2010/04/02 22018 鈴木 正臣</br>
	/// <br>           :  MANTIS[15240]見出貼付の修正（車種名カナの対応）</br>
    /// <br>Update Note : 2010/04/08 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/04/13 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/04/21 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/04/28 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/04/30 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>              ①プロパティ追加(回答区分)</br>
    /// <br>Update Note : 2010/05/04 王海立 PM1007・6次改良</br>
	/// <br>              発行者チェック、入力倉庫チェック等処理を追加</br>
    /// <br>Update Note : 2010/05/13 鈴木 正臣</br>
    /// <br>              自由検索部品自動登録対応</br>   
    /// <br>Update Note : 2010/05/20 鈴木 正臣</br>
    /// <br>              自由検索型式固定番号配列の対応を修正</br>   
    /// <br>Update Note:  2010/05/20 姜凱</br>
	/// <br>           :  Redmine#7774の備考２と備考３のリテラル表示は、項目の表示と同様に、売上全体設定で備考２と備考３ありの時に表示するように変更</br>
	/// <br>Update Note:  2010/05/21 姜凱</br>
	/// <br>           :  Redmine#7774の売上日付（追加）</br>
    /// <br>Update Note:  2010/05/27 20056 對馬 大輔</br>
    /// <br>           :  MANTIS[15528]伝票登録後に続けて入力した場合、得意先コードおよびフッタ部がクリアされてしまう件の対応</br>
    /// <br>Update Note:  2010/06/07 20056 對馬 大輔</br>
    /// <br>           :  ・同じ伝票番号の貸出伝票と受注伝票が存在する伝票番号で修正呼出しした場合の不具合修正</br>
    /// <br>           :  ・保存前チェックの在庫チェックの不具合修正</br>
    /// <br>Update Note:  2010/06/08 20056 對馬 大輔</br>
    /// <br>           :  ・各種ロックエラー時のメッセージを修正</br>
    /// <br>           :  ・伝票呼出時の車輌情報テーブルの再セットを追加(伝票種別違いで同伝票番号がある場合、エラーとなる件)</br>
    /// <br>Update Note:  2010/10/28 22018 鈴木 正臣</br>
    /// <br>              ①クリア処理時の伝票区分の更新処理を修正。</br>
    /// <br>Update Note: 2011/02/18 21024 佐々木 健</br>
    /// <br>             SCM対応</br>
    /// <br>              1)キャンセル区分の対応</br>
    /// <br>UpdateNote : K2011/08/12 yangyi</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: 2011/09/19 Redmine25264 周正雨</br>
    /// <br>             SF側からの発注ではなく、PM側からいきなり回答送信した場合、</br>
    /// <br>             SCM受注データ、売上明細データ、売上履歴明細データの受発注種別(AcceptOrOrderKind)を下記の仕様でセットするよう変更して下さい。</br>
    /// <br>             ・PCC接続設定（企業・拠点連結設定）の通信方式「BLﾊﾟｰﾂｵｰｻｰｼｽﾃﾑ」にチェックが付いている場合 ⇒ 1:PCC-UOE をセット</br>
    /// <br>             ・「BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ」にチェックが付いていない場合　⇒　0:通常</br>
    /// <br>             ※「部品問合・発注」と「BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ」の両方にチェックが付いている場合も1:PCC-UOE</br>
    /// <br>             なお、SF側からの問合せや発注で自動回答または手動回答する場合は、SFでセットされた内容のままで良いです。（変更無し）</br>
    /// <br>UpdateNote : K2011/12/09 鄧潘ハン</br>
    /// <br>管理番号   : 10703874-00</br>
    /// <br>作成内容   : イスコ個別対応</br>
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>管理番号   : 10801804-00 №1668</br>
    /// <br>             売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>             ※参照設定に SFCMN00615C、SFCMN00654D を追加</br>
    /// <br>Update Note: 2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応</br>   
    /// </remarks>
	public partial class MAHNB01010UA : Form
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private MAHNB01010UB _salesSlipDetailInput;
		private ImageList _imageList16 = null;											// イメージリスト
		private List<Control> _carControlList;                                          // 車両情報項目リスト
		private List<Control> _memoControlList;                                         // メモ項目リスト
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;				// 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;				// 新規ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _stockSearchButton;		// 在庫検索ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;				// 設定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _redSlipButton;			// 赤伝ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnSlipButton;			// 返品ボタン
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;		// ログイン担当者タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ログイン拠点タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;		// ログイン拠点名称
		private Infragistics.Win.UltraWinToolbars.ButtonTool _readSlipButton;			// 伝票呼出ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteSlipButton;			// 伝票削除ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _copySlipButton;			// 伝票複写ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _shipmentAddUpButton;		// 出荷計上ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _acceptAnOrderAddUpButton;	// 受注計上ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _estimateAddUpButton;		// 見積計上ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _printSlipButton;			// 伝票印刷ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _forwardButton;			// 進むボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;		    	// 戻るボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _searchChangeButton;	    // 入力変更ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _searchCarChangeButton;	// 車両検索切替ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;		   	// 最新情報ボタン
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
		private Infragistics.Win.UltraWinToolbars.ButtonTool _slipHeaderCopyButton;		// 見出貼付ボタン
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
		// --- ADD 2009/11/24 ---------->>>>>
		private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;		        // 更新ボタン
		// --- ADD 2009/11/24 ----------<<<<<
        //>>>2010/02/26
        private Infragistics.Win.UltraWinToolbars.ButtonTool _referenceListButton;	   	// 問合せ一覧ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _replyTransactionButton;  	// 回答処理ボタン
        //<<<2010/02/26

		private ControlScreenSkin _controlScreenSkin;
		private SalesSlipInputAcs _salesSlipInputAcs;                                   // 売上入力アクセスクラス
		private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;                   // 売上入力用初期値設定アクセスクラス
		private SalesSlipInputConstructionAcs _salesInputConstructionAcs;               // 売上入力用設定アクセスクラス
		// --- ADD 2009/09/08② ---------->>>>>
		private CarMngInputAcs _carMngInputAcs;                                         // 車輌管理マスタアクセスクラス
		// --- ADD 2009/09/08② ----------<<<<<
		private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
		private Dictionary<string, Control> _guideEnableExceptControlDictionary = new Dictionary<string, Control>();
		private Dictionary<string, int> _controlIndexForwordDictionary = new Dictionary<string, int>();
		private Dictionary<string, int> _controlIndexBackDictionary = new Dictionary<string, int>();
		private Dictionary<string, int> _controlIndexForwordDictionaryForFooter = new Dictionary<string, int>();
		private Dictionary<string, int> _controlIndexBackDictionaryForFooter = new Dictionary<string, int>();
		private Dictionary<string, Control> _headerItemsDictionary = new Dictionary<string, Control>();
		private Dictionary<string, Control> _footerItemsDictionary = new Dictionary<string, Control>();// ADD 2009/12/23
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private CustomerInfoAcs _customerInfoAcs;
		private Control _prevControl = null;									// 現在のコントロール
		private SalesSlipInputInitData _salesSlipInputInitData;
		private DateGetAcs _dateGetAcs;

		private MAHNB01010UK _carOtherInfoInput;
		private SalesInputDataSet.CarInfoDataTable _carInfoDataTable;
		private SalesInputDataSet.CarSpecDataTable _carSpecDataTable;

		private Control _detailControl;
		private Control _footerControl;

		private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
		private static readonly Color ct_NORMAL_FONT_COLOR = Color.Black;

		private static readonly Color ct_SALES_BACKCOLOR = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(142)))), ((int)(((byte)(232)))));
		private static readonly Color ct_SALES_BACKCOLOR2 = Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(14)))), ((int)(((byte)(138)))));
		private static readonly Color ct_SHIPMENT_BACKCOLOR = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
		private static readonly Color ct_SHIPMENT_BACKCOLOR2 = Color.Teal;
		private static readonly Color ct_ESTIMATE_BACKCOLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
		private static readonly Color ct_ESTIMATE_BACKCOLOR2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
		private static readonly Color ct_UNITESTIMATE_BACKCOLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(5)))));
		private static readonly Color ct_UNITESTIMATE_BACKCOLOR2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(74)))), ((int)(((byte)(5)))));

		private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

		private Thread _readInitialThread;
		private Thread _readInitialThreadSecond;
		private Thread _readInitialThreadThird;

		private bool _changeFocusSaveCancel;

		private List<SalesSlipInputAcs.AcptAnOdrStatusState> _stateList;
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
		private BeforeCarSearchBuffer _beforeCarSearchBuffer;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

        //>>>2010/02/26
        string _parameter = string.Empty; // 起動パラメータ
        long _scmInquiryNumber = 0;    // 問合せ番号(SCM用)
        int _scmAcptAnOdrStatus = 0;   // 受注ステータス(SCM用)
        string _scmSalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;   // 売上伝票番号(SCM用)
        string _inqOriginalEpCd = string.Empty;
        string _inqOriginalSecCd = string.Empty;
        int _inqOrdDivCd = 0;
        int _customerCode = 0;
        //<<<2010/02/26

        //>>>2010/03/30
        bool _scmSave = false;
        bool _isMakeQRFlg = false;
        // 2011/02/18 Add >>>
        //int _answerDivCd = 0;
        short _cancelDiv = 0;
        // 2011/02/18 Add <<<
        //<<<2010/03/30

		// ---------- ADD 2010/01/27 ---------->>>>>>>>>>
		private string _carMngCode = null;
		private int _categoryNo = 0;
		private int _modelDesignationNo = 0;
		private string _fullModel = null;
		private string _engineModelNm = null;
		// ---------- ADD 2010/01/27 ----------<<<<<<<<<<

		// --- ADD 2010/05/04 ---------->>>>>
		private bool _readSlipFlg = false;
		// --- ADD 2010/05/04 ----------<<<<<

        // ----- ADD K2011/08/12 --------------------------->>>>>
        private EmployeeAcs _employeeAcs;
        //private Broadleaf.Application.Remoting.IGetServerTime _iGetServerTime; // DEL K2011/12/09
        // ----- ADD K2011/08/12 ---------------------------<<<<<  

        private string login_EnterpriseCode = "0123130012020600"; // ADD K2011/12/09
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 売上入力フォームクラス デフォルトコンストラクタ
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		public MAHNB01010UA()
		{
            //>>>2010/02/26
            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "▼▼▼▼▼開始▼▼▼▼▼");

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "InitializeComponent");
            //InitializeComponent();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputInitDataAcs インスタンス化");
            //this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            ////this._salesSlipInputInitDataAcs.CreateSecInfoAcs();
            ////this._salesSlipInputInitDataAcs.EmployeeCodeMaxLength = uiSetControl1.GetSettingColumnCount("tEdit_EmployeeCode");
            ////this._salesSlipInputInitDataAcs.Owner = this;

            //this._readInitialThread = new Thread(this.ReadInitialThread);
            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThread 開始");
            //this._readInitialThread.Start();

            //this._readInitialThreadSecond = new Thread(this.ReadInitialThreadSecond);
            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThreadSecond 開始");
            //this._readInitialThreadSecond.Start();

            //this._readInitialThreadThird = new Thread(this.ReadInitialThreadThird);
            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThreadThird 開始");
            //this._readInitialThreadThird.Start();

            ////SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "InitializeComponent");
            ////InitializeComponent();

            //this._salesSlipInputInitDataAcs.EmployeeCodeMaxLength = uiSetControl1.GetSettingColumnCount("tEdit_EmployeeCode");
            //this._salesSlipInputInitDataAcs.Owner = this;

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "MAHNB01010UB インスタンス化");
            //this._salesSlipDetailInput = new MAHNB01010UB(MyOpeCtrl);

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "MAHNB01010UK インスタンス化");
            //this._carOtherInfoInput = new MAHNB01010UK();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ControlScreenSkin インスタンス化");
            //this._controlScreenSkin = new ControlScreenSkin();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputInitData インスタンス化");
            //this._salesSlipInputInitData = new SalesSlipInputInitData();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputAcs インスタンス取得");
            //this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            //this._salesSlipInputAcs.Owner = this;

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesInputConstructionAcs インスタンス取得");
            //this._salesInputConstructionAcs = SalesSlipInputConstructionAcs.GetInstance();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "その他のクラスのインスタンス化");
            //this._carInfoDataTable = this._salesSlipInputAcs.CarInfoDataTable;
            //this._carSpecDataTable = new SalesInputDataSet.CarSpecDataTable();
            //SalesInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable.NewCarSpecRow();
            //this._carSpecDataTable.AddCarSpecRow(carSpecRow);

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "デリゲート設定");
            //this._salesInputConstructionAcs.DataChanged += new EventHandler(this.SalesInputConstructionAcs_DataChanged);
            //this._salesSlipDetailInput.GridKeyDownTopRow += new EventHandler(this.SalesSlipDetailInput_GridKeyDownTopRow);
            //this._salesSlipDetailInput.GridKeyDownButtomRow += new EventHandler(this.SalesSlipDetailInput_GridKeyDownButtomRow);
            //this._salesSlipDetailInput.SalesPriceChanged += new EventHandler(this.SalesSlipDetailInput_SalesPriceChanged);
            //this._salesSlipDetailInput.StatusBarMessageSetting += new MAHNB01010UB.SettingStatusBarMessageEventHandler(this.SalesSlipDetailInput_StatusBarMessageSetting);
            //this._salesSlipDetailInput.FocusSetting += new MAHNB01010UB.SettingFocusEventHandler(this.SalesSlipDetailInput_FocusSetting);
            //this._salesSlipDetailInput.SettingFooter += new MAHNB01010UB.SettingFooterEventHandler(this.SalesSlipDetailInput_DetailChanged);
            //this._salesSlipDetailInput.SettingFooter += new MAHNB01010UB.SettingFooterEventHandler(this.SlipMemoInfoFormSetting);
            //this._salesSlipDetailInput.SettingCarInfo += new MAHNB01010UB.SettingCarInfoEventHandler(this.CarInfoFormSetting);
            //this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
            //this._salesSlipDetailInput.SettingVisible += new MAHNB01010UB.SettingVisibleEventHandler(this.SettingVisible);
            //this._salesSlipInputAcs.DataChanged += new EventHandler(this.SalesSlipInputAcs_DataChanged);
            //this._carOtherInfoInput.SettingColorInfo += new MAHNB01010UK.SettingColorEventHandler(this.SettingColorInfo);
            //this._carOtherInfoInput.SettingTrimInfo += new MAHNB01010UK.SettingTrimEventHandler(this.SettingTrimInfo);

            //this._imageList16 = IconResourceManagement.ImageList16;

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ツール取得");
            //this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            //this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            //this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            //this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            //this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Retry"];
            //this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_New"];
            //this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            //this._stockSearchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_StockSearch"];
            //this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            //this._redSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RedSlip"];
            //this._returnSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReturnSlip"];
            //this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];
            //this._loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"];
            //this._readSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReadSlip"];
            //this._deleteSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_DeleteSlip"];
            //this._copySlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CopySlip"];			            // 伝票複写ボタン
            //this._shipmentAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShipmentAddUp"];		        // 出荷計上ボタン
            //this._acceptAnOrderAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AcceptAnOrderAddUp"];	// 受注計上ボタン
            //this._estimateAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_EstimateAddUp"];		        // 見積計上ボタン
            //this._printSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PrintSlip"];			            // 伝票印刷ボタン
            //this._forwardButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Forward"];			                // 進むボタン
            //this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Return"];			                // 戻るボタン
            //this._searchChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SearchChange"];			    // 入力変更ボタン
            //this._searchCarChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SearchCarChange"];	        // 車両検索切替ボタン
            //this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReNewal"];			                // 戻るボタン
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            //this._slipHeaderCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SlipHeaderCopy"];           // 見出貼付ボタン
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
            //// --- ADD 2009/11/24 ---------->>>>>
            //this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];	                        // 更新ボタン
            //// --- ADD 2009/11/24 ----------<<<<<

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "その他変数初期化");
            //this._salesSlipInputAcs.PartySaleSlipDiv = this._salesInputConstructionAcs.PartySaleSlipValue;
            //this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.BLCodeSearch; // 初期値[部品検索]
            //this._salesSlipInputAcs.SearchCarModeProperty = SalesSlipInputAcs.SearchCarMode.FullModelSearch; // 初期値[型式検索]
            //this._salesSlipInputAcs.SearchCarDiv = false; // true:車両検索する,false:車両検索しない

            //this._guideEnableControlDictionary.Add(this.tEdit_SectionCode.Name, ctGUIDE_NAME_SectionGuide);                 // 拠点
            //this._guideEnableControlDictionary.Add(this.tNedit_SubSectionCode.Name, ctGUIDE_NAME_SubSectionGuide);          // 部門
            //this._guideEnableControlDictionary.Add(this.tEdit_SalesEmployeeCd.Name, ctGUIDE_NAME_EmployeeGuide);            // 担当者
            //this._guideEnableControlDictionary.Add(this.tEdit_FrontEmployeeCd.Name, ctGUIDE_NAME_FrontEmployeeGuide);       // 受注者
            //this._guideEnableControlDictionary.Add(this.tEdit_SalesInputCode.Name, ctGUIDE_NAME_SalesInputGuide);           // 発行者
            //this._guideEnableControlDictionary.Add(this.tNedit_SalesSlipNum.Name, ctGUIDE_NAME_SalesSlipGuide);             // 伝票番号
            //this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);              // 得意先
            //this._guideEnableControlDictionary.Add(this.tNedit_AddresseeCode.Name, ctGUIDE_NAME_AddresseeGuide);　          // 納入先
            //// --- DEL 2009/12/23 ---------->>>>>
            ////this._guideEnableControlDictionary.Add(this.tEdit_SlipNote.Name, ctGUIDE_NAME_SlipNoteGuide);　                 // 備考
            ////this._guideEnableControlDictionary.Add(this.tEdit_SlipNote2.Name, ctGUIDE_NAME_SlipNoteGuide2);                 // 備考２
            ////this._guideEnableControlDictionary.Add(this.tEdit_SlipNote3.Name, ctGUIDE_NAME_SlipNoteGuide3);                 // 備考３
            //// --- DEL 2009/12/23 ----------<<<<<
            //// --- ADD 2009/12/23 ---------->>>>>
            //this._guideEnableControlDictionary.Add(this.tNedit_SlipNoteCode.Name, ctGUIDE_NAME_SlipNoteGuide);　                 // 備考
            //this._guideEnableControlDictionary.Add(this.tNedit_SlipNote2Code.Name, ctGUIDE_NAME_SlipNoteGuide2);                 // 備考２
            //this._guideEnableControlDictionary.Add(this.tNedit_SlipNote3Code.Name, ctGUIDE_NAME_SlipNoteGuide3);                 // 備考３
            //// --- ADD 2009/12/23 ----------<<<<<
            //this._guideEnableControlDictionary.Add(this.tNedit_MakerCode.Name, ctGUIDE_NAME_ModelFullGuide);                // メーカーコード
            //this._guideEnableControlDictionary.Add(this.tNedit_ModelCode.Name, ctGUIDE_NAME_ModelFullGuide);                // 車種コード
            //this._guideEnableControlDictionary.Add(this.tNedit_ModelSubCode.Name, ctGUIDE_NAME_ModelFullGuide);             // 車種呼称コード
            //this._guideEnableControlDictionary.Add(this.tEdit_CarMngCode.Name, ctGUIDE_NAME_CarMngNoGuide);                 // 管理番号
            //this._guideEnableControlDictionary.Add(this.tEdit_RetGoodsReason.Name, ctGUIDE_NAME_RetGoodsReason);            // 返品理由
            //// --- ADD 2009/09/08② ---------->>>>>
            //this._guideEnableControlDictionary.Add(this.tEdit_CarSlipNote.Name, ctGUIDE_NAME_CarSlipNoteGuide);             // 車種備考
            //// --- ADD 2009/09/08② ----------<<<<<

            //this._guideEnableControlDictionary.Add(this.uButton_SectionGuide.Name, ctGUIDE_NAME_SectionGuide);              // 拠点ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SubSectionGuide.Name, ctGUIDE_NAME_SubSectionGuide);        // 部門ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_EmployeeGuide.Name, ctGUIDE_NAME_EmployeeGuide);            // 担当者ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_FrontEmployeeGuide.Name, ctGUIDE_NAME_FrontEmployeeGuide);  // 受注者ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SalesInputGuide.Name, ctGUIDE_NAME_SalesInputGuide);        // 発行者ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SalesSlipGuide.Name, ctGUIDE_NAME_SalesSlipGuide);          // 伝票番号ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_CustomerGuide.Name, ctGUIDE_NAME_CustomerGuide);            // 得意先ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_AddresseeGuide.Name, ctGUIDE_NAME_AddresseeGuide);          // 納入先ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SlipNote.Name, ctGUIDE_NAME_SlipNoteGuide);                 // 備考ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SlipNote2.Name, ctGUIDE_NAME_SlipNoteGuide2);               // 備考２ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_SlipNote3.Name, ctGUIDE_NAME_SlipNoteGuide3);               // 備考３ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_ModelFullGuide.Name, ctGUIDE_NAME_ModelFullGuide);          // 車種ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_CarMngNoGuide.Name, ctGUIDE_NAME_CarMngNoGuide);            // 管理番号ガイドボタン
            //this._guideEnableControlDictionary.Add(this.uButton_RetGoodsReason.Name, ctGUIDE_NAME_RetGoodsReason);          // 返品理由ガイドボタン
            //// --- ADD 2009/09/08② ---------->>>>>
            //this._guideEnableControlDictionary.Add(this.uButton_SlipNoteGuide.Name, ctGUIDE_NAME_CarSlipNoteGuide);         // 車種備考ガイドボタン
            //// --- ADD 2009/09/08② ----------<<<<<

            //this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.Name, this._salesSlipDetailInput);
            //this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.uGrid_Details.Name, this._salesSlipDetailInput.uGrid_Details);
            //this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.uButton_Guide.Name, this._salesSlipDetailInput.uButton_Guide);

            //this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            //this._loginSectionNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.BelongSectionName;
            //this._customerInfoAcs = new CustomerInfoAcs();
            //this._customerInfoAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            //this._dateGetAcs = DateGetAcs.GetInstance();

            //int controlIndexForword = 0;
            //this._controlIndexForwordDictionary.Add(this.tEdit_SectionCode.Name, controlIndexForword++);                    // 拠点
            //this._controlIndexForwordDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexForword++);                // 部門
            //this._controlIndexForwordDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexForword++);                  // 得意先
            //this._controlIndexForwordDictionary.Add(this.tEdit_CustomerName.Name, controlIndexForword++);                   // 得意先名称
            //this._controlIndexForwordDictionary.Add(this.uButton_CustomerClaimConfirmation.Name, controlIndexForword++);    // 請求先確認
            //this._controlIndexForwordDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexForword++);                // 担当者
            //this._controlIndexForwordDictionary.Add(this.tEdit_FrontEmployeeCd.Name, controlIndexForword++);                // 受注者
            //this._controlIndexForwordDictionary.Add(this.tEdit_SalesInputCode.Name, controlIndexForword++);                 // 発行者
            //this._controlIndexForwordDictionary.Add(this.tComboEditor_AcptAnOdrStatusDisplay.Name, controlIndexForword++);  // 伝票種別
            //this._controlIndexForwordDictionary.Add(this.tComboEditor_SalesSlipDisplay.Name, controlIndexForword++);        // 伝票区分
            //this._controlIndexForwordDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexForword++);                  // 売上日
            //this._controlIndexForwordDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexForword++);                     // 管理番号
            //this._controlIndexForwordDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexForword++);            // 類別
            //this._controlIndexForwordDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexForword++);                  // エンジン型式
            //this._controlIndexForwordDictionary.Add(this.tEdit_FullModel.Name, controlIndexForword++);                      // 型式
            //this._controlIndexForwordDictionary.Add(this.tNedit_MakerCode.Name, controlIndexForword++);                     // カーメーカーコード
            //this._controlIndexForwordDictionary.Add(this.tNedit_ModelCode.Name, controlIndexForword++);                     // 車種コード
            //this._controlIndexForwordDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexForword++);                  // 車種呼称コード
            //this._controlIndexForwordDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexForword++);                  // 車種名称
            //this._controlIndexForwordDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexForword++);             // 年式
            //this._controlIndexForwordDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexForword++);                 // 車台番号
            //this._controlIndexForwordDictionary.Add(this.tEdit_ColorNo.Name, controlIndexForword++);                        // カラー
            //this._controlIndexForwordDictionary.Add(this.tEdit_TrimNo.Name, controlIndexForword++);                         // トリム
            //// --- ADD 2009/12/23 ---------->>>>>
            //this._controlIndexForwordDictionary.Add(this.tNedit_SlipNoteCode.Name, controlIndexForword++);                  // 伝票備考コード
            //this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote.Name, controlIndexForword++);                       // 伝票備考
            //this._controlIndexForwordDictionary.Add(this.tNedit_SlipNote2Code.Name, controlIndexForword++);                 // 伝票備考２コード
            //this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote2.Name, controlIndexForword++);                      // 伝票備考２
            //this._controlIndexForwordDictionary.Add(this.tNedit_SlipNote3Code.Name, controlIndexForword++);                 // 伝票備考３コード
            //this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote3.Name, controlIndexForword++);                      // 伝票備考３
            //this._controlIndexForwordDictionary.Add(this.tNedit_AddresseeCode.Name, controlIndexForword++);                 // 納入先コード
            //this._controlIndexForwordDictionary.Add(this.tEdit_AddresseeName.Name, controlIndexForword++);                  // 納入先
            //this._controlIndexForwordDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexForword++);       // 納品区分
            //this._controlIndexForwordDictionary.Add(this.uButton_AddresseeConfirmation.Name, controlIndexForword++);        // 納入先確認
            //this._controlIndexForwordDictionary.Add(this.tEdit_RetGoodsReason.Name, controlIndexForword++);                 // 返品理由
            //this._controlIndexForwordDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);               // 仮伝番号
            //this._controlIndexForwordDictionary.Add(this.tEdit_CarSlipNote.Name, controlIndexForword++);                    // 車輌備考
            //this._controlIndexForwordDictionary.Add(this.tNedit_Mileage.Name, controlIndexForword++);                       // 走行距離
            //// --- ADD 2009/12/23 ----------<<<<<
            //int controlIndexBack = 99;
            //this._controlIndexBackDictionary.Add(this.tEdit_SectionCode.Name, controlIndexBack--);                          // 拠点
            //this._controlIndexBackDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexBack--);                      // 部門
            //this._controlIndexBackDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexBack--);                        // 得意先
            //this._controlIndexBackDictionary.Add(this.tEdit_CustomerName.Name, controlIndexBack--);                         // 得意先名称
            //this._controlIndexBackDictionary.Add(this.uButton_CustomerClaimConfirmation.Name, controlIndexBack--);          // 請求先確認
            //this._controlIndexBackDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexBack--);                      // 担当者
            //this._controlIndexBackDictionary.Add(this.tEdit_FrontEmployeeCd.Name, controlIndexBack--);                      // 受注者
            //this._controlIndexBackDictionary.Add(this.tEdit_SalesInputCode.Name, controlIndexBack--);                       // 発行者
            //this._controlIndexBackDictionary.Add(this.tComboEditor_AcptAnOdrStatusDisplay.Name, controlIndexBack--);        // 伝票種別
            //this._controlIndexBackDictionary.Add(this.tComboEditor_SalesSlipDisplay.Name, controlIndexBack--);              // 伝票区分
            //this._controlIndexBackDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexBack--);                        // 売上日
            //this._controlIndexBackDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexBack--);                           // 管理番号
            //this._controlIndexBackDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexBack--);                  // 類別
            //this._controlIndexBackDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexBack--);                        // エンジン型式
            //this._controlIndexBackDictionary.Add(this.tEdit_FullModel.Name, controlIndexBack--);                            // 型式
            //this._controlIndexBackDictionary.Add(this.tNedit_MakerCode.Name, controlIndexBack--);                           // カーメーカーコード
            //this._controlIndexBackDictionary.Add(this.tNedit_ModelCode.Name, controlIndexBack--);                           // 車種コード
            //this._controlIndexBackDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexBack--);                        // 車種呼称コード
            //this._controlIndexBackDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexBack--);                        // 車種名称
            //this._controlIndexBackDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexBack--);                   // 年式
            //this._controlIndexBackDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexBack--);                      // 車台番号
            //this._controlIndexBackDictionary.Add(this.tEdit_ColorNo.Name, controlIndexBack--);                              // カラー
            //this._controlIndexBackDictionary.Add(this.tEdit_TrimNo.Name, controlIndexBack--);                               // トリム
            //// --- ADD 2009/12/23 ---------->>>>>
            //this._controlIndexBackDictionary.Add(this.tNedit_SlipNoteCode.Name, controlIndexBack--);                  // 伝票備考コード
            //this._controlIndexBackDictionary.Add(this.tEdit_SlipNote.Name, controlIndexBack--);                       // 伝票備考
            //this._controlIndexBackDictionary.Add(this.tNedit_SlipNote2Code.Name, controlIndexBack--);                 // 伝票備考２コード
            //this._controlIndexBackDictionary.Add(this.tEdit_SlipNote2.Name, controlIndexBack--);                      // 伝票備考２
            //this._controlIndexBackDictionary.Add(this.tNedit_SlipNote3Code.Name, controlIndexBack--);                 // 伝票備考３コード
            //this._controlIndexBackDictionary.Add(this.tEdit_SlipNote3.Name, controlIndexBack--);                      // 伝票備考３
            //this._controlIndexBackDictionary.Add(this.tNedit_AddresseeCode.Name, controlIndexBack--);                 // 納入先コード
            //this._controlIndexBackDictionary.Add(this.tEdit_AddresseeName.Name, controlIndexBack--);                  // 納入先
            //this._controlIndexBackDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexBack--);       // 納品区分
            //this._controlIndexBackDictionary.Add(this.uButton_AddresseeConfirmation.Name, controlIndexBack--);        // 納入先確認
            //this._controlIndexBackDictionary.Add(this.tEdit_RetGoodsReason.Name, controlIndexBack--);                 // 返品理由
            //this._controlIndexBackDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);               // 仮伝番号
            //this._controlIndexBackDictionary.Add(this.tEdit_CarSlipNote.Name, controlIndexBack--);                    // 車輌備考
            //this._controlIndexBackDictionary.Add(this.tNedit_Mileage.Name, controlIndexBack--);                       // 走行距離
            //// --- ADD 2009/12/23 ----------<<<<<

            //// ヘッダ項目Dictionary作成
            //this._headerItemsDictionary.Add(this.uLabel_SectionCode.Text.Trim(), this.tEdit_SectionCode);
            //this._headerItemsDictionary.Add(this.uLabel_SubSectionCode.Text.Trim(), this.tNedit_SubSectionCode);
            //this._headerItemsDictionary.Add(this.uLabel_CustomerCode.Text.Trim(), this.tNedit_CustomerCode);
            //this._headerItemsDictionary.Add(this.uLabel_CustomerName.Text.Trim(), this.tEdit_CustomerName);
            //this._headerItemsDictionary.Add(this.uButton_CustomerClaimConfirmation.Text.Trim(), this.uButton_CustomerClaimConfirmation);
            //this._headerItemsDictionary.Add(this.uLabel_SalesEmployeeCd.Text.Trim(), this.tEdit_SalesEmployeeCd);
            //this._headerItemsDictionary.Add(this.uLabel_FrontEmployeeCd.Text.Trim(), this.tEdit_FrontEmployeeCd);
            //this._headerItemsDictionary.Add(this.uLabel_SalesInputCode.Text.Trim(), this.tEdit_SalesInputCode);
            //this._headerItemsDictionary.Add(this.uLabel_AcptAnOdrStatus.Text.Trim(), this.tComboEditor_AcptAnOdrStatusDisplay);
            //this._headerItemsDictionary.Add(this.uLabel_SalesSlip.Text.Trim(), this.tComboEditor_SalesSlipDisplay);
            //this._headerItemsDictionary.Add(this.uLabel_SalesDate.Text.Trim(), this.tDateEdit_SalesDate);
            //this._headerItemsDictionary.Add(this.uLabel_CarMngNo.Text.Trim(), this.tEdit_CarMngCode);
            //this._headerItemsDictionary.Add(this.uLabel_ModelDesignationNo.Text.Trim(), this.tNedit_ModelDesignationNo);
            //this._headerItemsDictionary.Add(this.uLabel_EngineModelNm.Text.Trim(), this.tEdit_EngineModelNm);
            //this._headerItemsDictionary.Add(this.uButton_ChangeSearchCarMode.Text.Trim(), this.tEdit_FullModel);
            //this._headerItemsDictionary.Add(this.uLabel_MakerCode.Text.Trim(), this.tNedit_MakerCode);
            //this._headerItemsDictionary.Add(this.uLabel_ModelCode.Text.Trim(), this.tNedit_ModelCode);
            //this._headerItemsDictionary.Add(this.uLabel_ModelSubCode.Text.Trim(), this.tNedit_ModelSubCode);
            //this._headerItemsDictionary.Add(this.uLabel_CarName.Text.Trim(), this.tEdit_ModelFullName);
            //this._headerItemsDictionary.Add(this.uLabel_FirstEntryDate.Text.Trim(), this.tDateEdit_FirstEntryDate);
            //this._headerItemsDictionary.Add(this.uLabel_ProduceFrameNo.Text.Trim(), this.tEdit_ProduceFrameNo);
            //this._headerItemsDictionary.Add(this.uLabel_ColorNo.Text.Trim(), this.tEdit_ColorNo);
            //this._headerItemsDictionary.Add(this.uLabel_TrimNo.Text.Trim(), this.tEdit_TrimNo);

            //controlIndexForword = 0;
            //this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNoteCode.Name, controlIndexForword++);                  // 伝票備考１コード ADD 2009/12/23
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote.Name, controlIndexForword++);                       // 伝票備考１
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote.Name, controlIndexForword++);                     // 伝票備考１ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNote2Code.Name, controlIndexForword++);                 // 伝票備考２コード ADD 2009/12/23
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote2.Name, controlIndexForword++);                      // 伝票備考２
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexForword++);                    // 伝票備考２ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNote3Code.Name, controlIndexForword++);                 // 伝票備考３コード ADD 2009/12/23
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote3.Name, controlIndexForword++);                      // 伝票備考３
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote3.Name, controlIndexForword++);                    // 伝票備考３ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_AddresseeCode.Name, controlIndexForword++);                 // 納入先コード
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_AddresseeName.Name, controlIndexForword++);                  // 納入先名称
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_AddresseeGuide.Name, controlIndexForword++);               // 納入先ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexForword++);       // 納品区分
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_AddresseeConfirmation.Name, controlIndexForword++);        // 納入先確認ボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexForword++);                  // 納入先名称
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexForword++);               // 納入先ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);               // 得意先注番
            //// --- ADD 2009/09/08② ---------->>>>>
            //this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_CarSlipNote.Name, controlIndexForword++);                    // 車輌備考
            //this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNoteGuide.Name, controlIndexForword++);                // 車輌備考ガイドボタン
            //this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_Mileage.Name, controlIndexForword++);                       // 走行距離
            //// --- ADD 2009/09/08② ----------<<<<<

            //controlIndexBack = 99;
            //this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNoteCode.Name, controlIndexBack--);                        // 伝票備考１コード ADD 2009/12/23
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote.Name, controlIndexBack--);                             // 伝票備考１
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote.Name, controlIndexBack--);                           // 伝票備考１ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNote2Code.Name, controlIndexBack--);                       // 伝票備考２コード ADD 2009/12/23
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote2.Name, controlIndexBack--);                            // 伝票備考２
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexBack--);                          // 伝票備考２ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNote3Code.Name, controlIndexBack--);                       // 伝票備考３コード ADD 2009/12/23
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote3.Name, controlIndexBack--);                            // 伝票備考３
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote3.Name, controlIndexBack--);                          // 伝票備考３ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tNedit_AddresseeCode.Name, controlIndexBack--);                       // 納入先コード
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_AddresseeName.Name, controlIndexBack--);                        // 納入先名称
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_AddresseeGuide.Name, controlIndexBack--);                     // 納入先ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexBack--);             // 納品区分
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_AddresseeConfirmation.Name, controlIndexBack--);              // 納入先確認ボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexBack--);                        // 納入先名称
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexBack--);                     // 納入先ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);                     // 得意先注番
            //// --- ADD 2009/09/08② ---------->>>>>
            //this._controlIndexBackDictionaryForFooter.Add(this.tEdit_CarSlipNote.Name, controlIndexBack--);                           // 車輌備考
            //this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNoteGuide.Name, controlIndexBack--);                       // 車輌備考ガイドボタン
            //this._controlIndexBackDictionaryForFooter.Add(this.tNedit_Mileage.Name, controlIndexBack--);                              // 走行距離
            //// --- ADD 2009/09/08② ----------<<<<<

            //// --- ADD 2009/12/23 ---------->>>>>
            //// フッタ項目Dictionary作成
            //this._footerItemsDictionary.Add("伝票備考コード", this.tNedit_SlipNoteCode);
            //this._footerItemsDictionary.Add("伝票備考", this.tEdit_SlipNote);
            //this._footerItemsDictionary.Add("伝票備考２コード", this.tNedit_SlipNote2Code);
            //this._footerItemsDictionary.Add("伝票備考２", this.tEdit_SlipNote2);
            //this._footerItemsDictionary.Add("伝票備考３コード", this.tNedit_SlipNote3Code);
            //this._footerItemsDictionary.Add("伝票備考３", this.tEdit_SlipNote3);
            //this._footerItemsDictionary.Add("納入先コード", this.tNedit_AddresseeCode);

            //this._footerItemsDictionary.Add(this.uLabel_AddresseeCode.Text.Trim(), this.tEdit_AddresseeName);
            //this._footerItemsDictionary.Add(this.uLabel_DeliveredGoodsDiv.Text.Trim(), this.tComboEditor_DeliveredGoodsDiv);
            //this._footerItemsDictionary.Add(this.uButton_AddresseeConfirmation.Text.Trim(), this.uButton_AddresseeConfirmation);
            //this._footerItemsDictionary.Add(this.uLabel_ReturnReasonTitle.Text.Trim(), this.tEdit_RetGoodsReason);
            //this._footerItemsDictionary.Add(this.uLabel_PartySaleSlipNum.Text.Trim(), this.tEdit_PartySaleSlipNum);
            //this._footerItemsDictionary.Add(this.ultraLabel47.Text.Trim(), this.tEdit_CarSlipNote);
            //this._footerItemsDictionary.Add(this.ultraLabel45.Text.Trim(), this.tNedit_Mileage);

            //this._salesInputConstructionAcs.FooterItemsDictionary = this._footerItemsDictionary;
            //// --- ADD 2009/12/23 ----------<<<<<

            //this._salesInputConstructionAcs.HeaderItemsDictionary = this._headerItemsDictionary;
            //this._salesInputConstructionAcs.EnterpriseCode = this._enterpriseCode;

            //this._carControlList = new List<Control>();
            //this._carControlList.Add(this.tEdit_CarMngCode);
            //this._carControlList.Add(this.uButton_CarMngNoGuide);
            //this._carControlList.Add(this.tNedit_ModelDesignationNo);
            //this._carControlList.Add(this.tNedit_CategoryNo);
            //this._carControlList.Add(this.tEdit_EngineModelNm);
            //this._carControlList.Add(this.tEdit_FullModel);
            //this._carControlList.Add(this.tNedit_MakerCode);
            //this._carControlList.Add(this.tNedit_ModelCode);
            //this._carControlList.Add(this.tNedit_ModelSubCode);
            //this._carControlList.Add(this.tEdit_ModelFullName);
            //this._carControlList.Add(this.uButton_ModelFullGuide);
            //this._carControlList.Add(this.tDateEdit_FirstEntryDate);
            //this._carControlList.Add(this.tEdit_ProduceFrameNo);
            //this._carControlList.Add(this.tEdit_ColorNo);
            //this._carControlList.Add(this.tEdit_TrimNo);

            //this._memoControlList = new List<Control>();
            //this._memoControlList.Add(this.tEdit_InsideMemo1);
            //this._memoControlList.Add(this.tEdit_InsideMemo2);
            //this._memoControlList.Add(this.tEdit_InsideMemo3);
            //this._memoControlList.Add(this.tEdit_SlipMemo1);
            //this._memoControlList.Add(this.tEdit_SlipMemo2);
            //this._memoControlList.Add(this.tEdit_SlipMemo3);

            //this._detailControl = this._salesSlipDetailInput.uGrid_Details;
            //// --- UPD 2009/12/23 ---------->>>>>
            ////this._footerControl = this.tEdit_SlipNote;
            //this._footerControl = this.tNedit_SlipNoteCode;
            //// --- UPD 2009/12/23 ----------<<<<<

            //this._salesSlipInputAcs.MyOpeCtrl = MyOpeCtrl;

            //this._changeFocusSaveCancel = false;

            //// 受注ステータスリスト作成
            //this._stateList = new List<SalesSlipInputAcs.AcptAnOdrStatusState>();
            //this._stateList.AddRange(new SalesSlipInputAcs.AcptAnOdrStatusState[] {
            //                                SalesSlipInputAcs.AcptAnOdrStatusState.Sales,
            //                                SalesSlipInputAcs.AcptAnOdrStatusState.Shipment,
            //                                SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder,
            //                                SalesSlipInputAcs.AcptAnOdrStatusState.Estimate,
            //                                SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate});

            //// --- ADD 2009/09/08② ---------->>>>>
            //this._carMngInputAcs = CarMngInputAcs.GetInstance();
            //// --- ADD 2009/09/08② ----------<<<<<

            //// --- ADD 2009/12/23 ---------->>>>>
            ////伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
            //this._salesSlipInputAcs.GetNoteCharCnt();
            //SetNoteCharCnt();
            //// --- ADD 2009/12/23 ----------<<<<<

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "▲▲▲▲▲終了▲▲▲▲▲");

            this.MAHNB01010UA_Method();
            //<<<2010/02/26
		}

        //>>>2010/02/26
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="scmInquiryNumber"></param>
        /// <param name="scmAcptAnOdrStatus"></param>
        /// <param name="scmSalesSlipNum"></param>
        /// <param name="inqOriginalEpCd"></param>
        /// <param name="inqOriginalSecCd"></param>
        /// <param name="inqOrdDivCd"></param>
        // 2011/02/18 >>>
        ////public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd) // 2010/03/30
        //public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int answerDivCd) // 2010/03/30
        public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, short cancelDiv)
        // 2011/02/18 <<<
        {
            this.MAHNB01010UA_Method();

            this._parameter = parameter;
            this._scmInquiryNumber = scmInquiryNumber;
            this._scmAcptAnOdrStatus = scmAcptAnOdrStatus;
            this._scmSalesSlipNum = scmSalesSlipNum;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOrdDivCd = inqOrdDivCd;
            this._customerCode = 0;
            // 2011/02/18 >>>
            //this._answerDivCd = answerDivCd; // 2010/03/30
            this._cancelDiv = cancelDiv;
            // 2011/02/18 <<<
            if (scmSalesSlipNum == null) this._scmSalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="scmInquiryNumber"></param>
        /// <param name="scmAcptAnOdrStatus"></param>
        /// <param name="scmSalesSlipNum"></param>
        /// <param name="inqOriginalEpCd"></param>
        /// <param name="inqOriginalSecCd"></param>
        /// <param name="inqOrdDivCd"></param>
        /// <param name="customerCode"></param>
        // 2011/02/18 >>>
        ////public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int customerCode) // 2010/03/30
        //public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int customerCode, int answerDivCd) // 2010/03/30
        public MAHNB01010UA(string parameter, long scmInquiryNumber, int scmAcptAnOdrStatus, string scmSalesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int customerCode, short cancelDiv) 
        // 2011/02/18 <<<
        {
            this.MAHNB01010UA_Method();

            this._parameter = parameter;
            this._scmInquiryNumber = scmInquiryNumber;
            this._scmAcptAnOdrStatus = scmAcptAnOdrStatus;
            this._scmSalesSlipNum = scmSalesSlipNum;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOrdDivCd = inqOrdDivCd;
            this._customerCode = customerCode;
            // 2011/02/18 >>>
            //this._answerDivCd = answerDivCd; // 2010/03/30
            this._cancelDiv = cancelDiv; 
            // 2011/02/18 <<<
            if (scmSalesSlipNum == null) this._scmSalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
        }

        /// <summary>
        /// コンストラクタメソッド
        /// </summary>
        private void MAHNB01010UA_Method()
        {
            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "▼▼▼▼▼開始▼▼▼▼▼");

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "InitializeComponent");
            InitializeComponent();

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputInitDataAcs インスタンス化");
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            //this._salesSlipInputInitDataAcs.CreateSecInfoAcs();
            //this._salesSlipInputInitDataAcs.EmployeeCodeMaxLength = uiSetControl1.GetSettingColumnCount("tEdit_EmployeeCode");
            //this._salesSlipInputInitDataAcs.Owner = this;

            this._readInitialThread = new Thread(this.ReadInitialThread);
            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThread 開始");
            this._readInitialThread.Start();

            this._readInitialThreadSecond = new Thread(this.ReadInitialThreadSecond);
            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThreadSecond 開始");
            this._readInitialThreadSecond.Start();

            this._readInitialThreadThird = new Thread(this.ReadInitialThreadThird);
            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ReadInitialThreadThird 開始");
            this._readInitialThreadThird.Start();

            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "InitializeComponent");
            //InitializeComponent();

            this._salesSlipInputInitDataAcs.EmployeeCodeMaxLength = uiSetControl1.GetSettingColumnCount("tEdit_EmployeeCode");
            this._salesSlipInputInitDataAcs.Owner = this;

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "MAHNB01010UB インスタンス化");
            this._salesSlipDetailInput = new MAHNB01010UB(MyOpeCtrl);

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "MAHNB01010UK インスタンス化");
            this._carOtherInfoInput = new MAHNB01010UK();

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ControlScreenSkin インスタンス化");
            this._controlScreenSkin = new ControlScreenSkin();

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputInitData インスタンス化");
            this._salesSlipInputInitData = new SalesSlipInputInitData();

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesSlipInputAcs インスタンス取得");
            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipInputAcs.Owner = this;

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "SalesInputConstructionAcs インスタンス取得");
            this._salesInputConstructionAcs = SalesSlipInputConstructionAcs.GetInstance();

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "その他のクラスのインスタンス化");
            this._carInfoDataTable = this._salesSlipInputAcs.CarInfoDataTable;
            this._carSpecDataTable = new SalesInputDataSet.CarSpecDataTable();
            SalesInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable.NewCarSpecRow();
            this._carSpecDataTable.AddCarSpecRow(carSpecRow);

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "デリゲート設定");
            this._salesInputConstructionAcs.DataChanged += new EventHandler(this.SalesInputConstructionAcs_DataChanged);
            this._salesSlipDetailInput.GridKeyDownTopRow += new EventHandler(this.SalesSlipDetailInput_GridKeyDownTopRow);
            this._salesSlipDetailInput.GridKeyDownButtomRow += new EventHandler(this.SalesSlipDetailInput_GridKeyDownButtomRow);
            this._salesSlipDetailInput.SalesPriceChanged += new EventHandler(this.SalesSlipDetailInput_SalesPriceChanged);
            this._salesSlipDetailInput.StatusBarMessageSetting += new MAHNB01010UB.SettingStatusBarMessageEventHandler(this.SalesSlipDetailInput_StatusBarMessageSetting);
            this._salesSlipDetailInput.FocusSetting += new MAHNB01010UB.SettingFocusEventHandler(this.SalesSlipDetailInput_FocusSetting);
            this._salesSlipDetailInput.SettingFooter += new MAHNB01010UB.SettingFooterEventHandler(this.SalesSlipDetailInput_DetailChanged);
            this._salesSlipDetailInput.SettingFooter += new MAHNB01010UB.SettingFooterEventHandler(this.SlipMemoInfoFormSetting);
            this._salesSlipDetailInput.SettingCarInfo += new MAHNB01010UB.SettingCarInfoEventHandler(this.CarInfoFormSetting);
            this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
            this._salesSlipDetailInput.SettingVisible += new MAHNB01010UB.SettingVisibleEventHandler(this.SettingVisible);
            this._salesSlipInputAcs.DataChanged += new EventHandler(this.SalesSlipInputAcs_DataChanged);
            this._carOtherInfoInput.SettingColorInfo += new MAHNB01010UK.SettingColorEventHandler(this.SettingColorInfo);
            this._carOtherInfoInput.SettingTrimInfo += new MAHNB01010UK.SettingTrimEventHandler(this.SettingTrimInfo);

            this._imageList16 = IconResourceManagement.ImageList16;

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "ツール取得");
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Retry"];
            this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_New"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._stockSearchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_StockSearch"];
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._redSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RedSlip"];
            this._returnSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReturnSlip"];
            this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionTitle"];
            this._loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginSectionName"];
            this._readSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReadSlip"];
            this._deleteSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_DeleteSlip"];
            this._copySlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CopySlip"];			            // 伝票複写ボタン
            this._shipmentAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShipmentAddUp"];		        // 出荷計上ボタン
            this._acceptAnOrderAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AcceptAnOrderAddUp"];	// 受注計上ボタン
            this._estimateAddUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_EstimateAddUp"];		        // 見積計上ボタン
            this._printSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PrintSlip"];			            // 伝票印刷ボタン
            this._forwardButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Forward"];			                // 進むボタン
            this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Return"];			                // 戻るボタン
            this._searchChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SearchChange"];			    // 入力変更ボタン
            this._searchCarChangeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SearchCarChange"];	        // 車両検索切替ボタン
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReNewal"];			                // 戻るボタン
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            this._slipHeaderCopyButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SlipHeaderCopy"];           // 見出貼付ボタン
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
            // --- ADD 2009/11/24 ---------->>>>>
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];	                        // 更新ボタン
            // --- ADD 2009/11/24 ----------<<<<<
            //>>>2010/02/26
            this._referenceListButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReferenceList"];			    // 問合せ一覧ボタン
            this._replyTransactionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ReplyTransaction"];	    // 回答処理ボタン
            //<<<2010/02/26

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "その他変数初期化");
            this._salesSlipInputAcs.PartySaleSlipDiv = this._salesInputConstructionAcs.PartySaleSlipValue;
            this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.BLCodeSearch; // 初期値[部品検索]
            this._salesSlipInputAcs.SearchCarModeProperty = SalesSlipInputAcs.SearchCarMode.FullModelSearch; // 初期値[型式検索]
            this._salesSlipInputAcs.SearchCarDiv = false; // true:車両検索する,false:車両検索しない

            this._guideEnableControlDictionary.Add(this.tEdit_SectionCode.Name, ctGUIDE_NAME_SectionGuide);                 // 拠点
            this._guideEnableControlDictionary.Add(this.tNedit_SubSectionCode.Name, ctGUIDE_NAME_SubSectionGuide);          // 部門
            this._guideEnableControlDictionary.Add(this.tEdit_SalesEmployeeCd.Name, ctGUIDE_NAME_EmployeeGuide);            // 担当者
            this._guideEnableControlDictionary.Add(this.tEdit_FrontEmployeeCd.Name, ctGUIDE_NAME_FrontEmployeeGuide);       // 受注者
            this._guideEnableControlDictionary.Add(this.tEdit_SalesInputCode.Name, ctGUIDE_NAME_SalesInputGuide);           // 発行者
            this._guideEnableControlDictionary.Add(this.tNedit_SalesSlipNum.Name, ctGUIDE_NAME_SalesSlipGuide);             // 伝票番号
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);              // 得意先
            this._guideEnableControlDictionary.Add(this.tNedit_AddresseeCode.Name, ctGUIDE_NAME_AddresseeGuide);　          // 納入先
            // --- DEL 2009/12/23 ---------->>>>>
            //this._guideEnableControlDictionary.Add(this.tEdit_SlipNote.Name, ctGUIDE_NAME_SlipNoteGuide);　                 // 備考
            //this._guideEnableControlDictionary.Add(this.tEdit_SlipNote2.Name, ctGUIDE_NAME_SlipNoteGuide2);                 // 備考２
            //this._guideEnableControlDictionary.Add(this.tEdit_SlipNote3.Name, ctGUIDE_NAME_SlipNoteGuide3);                 // 備考３
            // --- DEL 2009/12/23 ----------<<<<<
            // --- ADD 2009/12/23 ---------->>>>>
            this._guideEnableControlDictionary.Add(this.tNedit_SlipNoteCode.Name, ctGUIDE_NAME_SlipNoteGuide);　                 // 備考
            this._guideEnableControlDictionary.Add(this.tNedit_SlipNote2Code.Name, ctGUIDE_NAME_SlipNoteGuide2);                 // 備考２
            this._guideEnableControlDictionary.Add(this.tNedit_SlipNote3Code.Name, ctGUIDE_NAME_SlipNoteGuide3);                 // 備考３
            // --- ADD 2009/12/23 ----------<<<<<
            this._guideEnableControlDictionary.Add(this.tNedit_MakerCode.Name, ctGUIDE_NAME_ModelFullGuide);                // メーカーコード
            this._guideEnableControlDictionary.Add(this.tNedit_ModelCode.Name, ctGUIDE_NAME_ModelFullGuide);                // 車種コード
            this._guideEnableControlDictionary.Add(this.tNedit_ModelSubCode.Name, ctGUIDE_NAME_ModelFullGuide);             // 車種呼称コード
            this._guideEnableControlDictionary.Add(this.tEdit_CarMngCode.Name, ctGUIDE_NAME_CarMngNoGuide);                 // 管理番号
            this._guideEnableControlDictionary.Add(this.tEdit_RetGoodsReason.Name, ctGUIDE_NAME_RetGoodsReason);            // 返品理由
            // --- ADD 2009/09/08② ---------->>>>>
            this._guideEnableControlDictionary.Add(this.tEdit_CarSlipNote.Name, ctGUIDE_NAME_CarSlipNoteGuide);             // 車種備考
            // --- ADD 2009/09/08② ----------<<<<<

            this._guideEnableControlDictionary.Add(this.uButton_SectionGuide.Name, ctGUIDE_NAME_SectionGuide);              // 拠点ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SubSectionGuide.Name, ctGUIDE_NAME_SubSectionGuide);        // 部門ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_EmployeeGuide.Name, ctGUIDE_NAME_EmployeeGuide);            // 担当者ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_FrontEmployeeGuide.Name, ctGUIDE_NAME_FrontEmployeeGuide);  // 受注者ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SalesInputGuide.Name, ctGUIDE_NAME_SalesInputGuide);        // 発行者ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SalesSlipGuide.Name, ctGUIDE_NAME_SalesSlipGuide);          // 伝票番号ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_CustomerGuide.Name, ctGUIDE_NAME_CustomerGuide);            // 得意先ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_AddresseeGuide.Name, ctGUIDE_NAME_AddresseeGuide);          // 納入先ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SlipNote.Name, ctGUIDE_NAME_SlipNoteGuide);                 // 備考ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SlipNote2.Name, ctGUIDE_NAME_SlipNoteGuide2);               // 備考２ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_SlipNote3.Name, ctGUIDE_NAME_SlipNoteGuide3);               // 備考３ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_ModelFullGuide.Name, ctGUIDE_NAME_ModelFullGuide);          // 車種ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_CarMngNoGuide.Name, ctGUIDE_NAME_CarMngNoGuide);            // 管理番号ガイドボタン
            this._guideEnableControlDictionary.Add(this.uButton_RetGoodsReason.Name, ctGUIDE_NAME_RetGoodsReason);          // 返品理由ガイドボタン
            // --- ADD 2009/09/08② ---------->>>>>
            this._guideEnableControlDictionary.Add(this.uButton_SlipNoteGuide.Name, ctGUIDE_NAME_CarSlipNoteGuide);         // 車種備考ガイドボタン
            // --- ADD 2009/09/08② ----------<<<<<

            this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.Name, this._salesSlipDetailInput);
            this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.uGrid_Details.Name, this._salesSlipDetailInput.uGrid_Details);
            this._guideEnableExceptControlDictionary.Add(this._salesSlipDetailInput.uButton_Guide.Name, this._salesSlipDetailInput.uButton_Guide);

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._loginSectionNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.BelongSectionName;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
            this._dateGetAcs = DateGetAcs.GetInstance();

            int controlIndexForword = 0;
            this._controlIndexForwordDictionary.Add(this.tEdit_SectionCode.Name, controlIndexForword++);                    // 拠点
            this._controlIndexForwordDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexForword++);                // 部門
            this._controlIndexForwordDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexForword++);                  // 得意先
            this._controlIndexForwordDictionary.Add(this.tEdit_CustomerName.Name, controlIndexForword++);                   // 得意先名称
            this._controlIndexForwordDictionary.Add(this.uButton_CustomerClaimConfirmation.Name, controlIndexForword++);    // 請求先確認
            this._controlIndexForwordDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexForword++);                // 担当者
            this._controlIndexForwordDictionary.Add(this.tEdit_FrontEmployeeCd.Name, controlIndexForword++);                // 受注者
            this._controlIndexForwordDictionary.Add(this.tEdit_SalesInputCode.Name, controlIndexForword++);                 // 発行者
            this._controlIndexForwordDictionary.Add(this.tComboEditor_AcptAnOdrStatusDisplay.Name, controlIndexForword++);  // 伝票種別
            this._controlIndexForwordDictionary.Add(this.tComboEditor_SalesSlipDisplay.Name, controlIndexForword++);        // 伝票区分
            this._controlIndexForwordDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexForword++);                  // 売上日
            this._controlIndexForwordDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexForword++);                     // 管理番号
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexForword++);            // 類別
            this._controlIndexForwordDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexForword++);                  // エンジン型式
            this._controlIndexForwordDictionary.Add(this.tEdit_FullModel.Name, controlIndexForword++);                      // 型式
            this._controlIndexForwordDictionary.Add(this.tNedit_MakerCode.Name, controlIndexForword++);                     // カーメーカーコード
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelCode.Name, controlIndexForword++);                     // 車種コード
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexForword++);                  // 車種呼称コード
            this._controlIndexForwordDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexForword++);                  // 車種名称
            this._controlIndexForwordDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexForword++);             // 年式
            this._controlIndexForwordDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexForword++);                 // 車台番号
            this._controlIndexForwordDictionary.Add(this.tEdit_ColorNo.Name, controlIndexForword++);                        // カラー
            this._controlIndexForwordDictionary.Add(this.tEdit_TrimNo.Name, controlIndexForword++);                         // トリム
            // --- ADD 2009/12/23 ---------->>>>>
            this._controlIndexForwordDictionary.Add(this.tNedit_SlipNoteCode.Name, controlIndexForword++);                  // 伝票備考コード
            this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote.Name, controlIndexForword++);                       // 伝票備考
            this._controlIndexForwordDictionary.Add(this.tNedit_SlipNote2Code.Name, controlIndexForword++);                 // 伝票備考２コード
            this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote2.Name, controlIndexForword++);                      // 伝票備考２
            this._controlIndexForwordDictionary.Add(this.tNedit_SlipNote3Code.Name, controlIndexForword++);                 // 伝票備考３コード
            this._controlIndexForwordDictionary.Add(this.tEdit_SlipNote3.Name, controlIndexForword++);                      // 伝票備考３
            this._controlIndexForwordDictionary.Add(this.tNedit_AddresseeCode.Name, controlIndexForword++);                 // 納入先コード
            this._controlIndexForwordDictionary.Add(this.tEdit_AddresseeName.Name, controlIndexForword++);                  // 納入先
            this._controlIndexForwordDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexForword++);       // 納品区分
            this._controlIndexForwordDictionary.Add(this.uButton_AddresseeConfirmation.Name, controlIndexForword++);        // 納入先確認
            this._controlIndexForwordDictionary.Add(this.tEdit_RetGoodsReason.Name, controlIndexForword++);                 // 返品理由
            this._controlIndexForwordDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);               // 仮伝番号
            this._controlIndexForwordDictionary.Add(this.tEdit_CarSlipNote.Name, controlIndexForword++);                    // 車輌備考
            this._controlIndexForwordDictionary.Add(this.tNedit_Mileage.Name, controlIndexForword++);                       // 走行距離
            // --- ADD 2009/12/23 ----------<<<<<
            int controlIndexBack = 99;
            this._controlIndexBackDictionary.Add(this.tEdit_SectionCode.Name, controlIndexBack--);                          // 拠点
            this._controlIndexBackDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexBack--);                      // 部門
            this._controlIndexBackDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexBack--);                        // 得意先
            this._controlIndexBackDictionary.Add(this.tEdit_CustomerName.Name, controlIndexBack--);                         // 得意先名称
            this._controlIndexBackDictionary.Add(this.uButton_CustomerClaimConfirmation.Name, controlIndexBack--);          // 請求先確認
            this._controlIndexBackDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexBack--);                      // 担当者
            this._controlIndexBackDictionary.Add(this.tEdit_FrontEmployeeCd.Name, controlIndexBack--);                      // 受注者
            this._controlIndexBackDictionary.Add(this.tEdit_SalesInputCode.Name, controlIndexBack--);                       // 発行者
            this._controlIndexBackDictionary.Add(this.tComboEditor_AcptAnOdrStatusDisplay.Name, controlIndexBack--);        // 伝票種別
            this._controlIndexBackDictionary.Add(this.tComboEditor_SalesSlipDisplay.Name, controlIndexBack--);              // 伝票区分
            this._controlIndexBackDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexBack--);                        // 売上日
            this._controlIndexBackDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexBack--);                           // 管理番号
            this._controlIndexBackDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexBack--);                  // 類別
            this._controlIndexBackDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexBack--);                        // エンジン型式
            this._controlIndexBackDictionary.Add(this.tEdit_FullModel.Name, controlIndexBack--);                            // 型式
            this._controlIndexBackDictionary.Add(this.tNedit_MakerCode.Name, controlIndexBack--);                           // カーメーカーコード
            this._controlIndexBackDictionary.Add(this.tNedit_ModelCode.Name, controlIndexBack--);                           // 車種コード
            this._controlIndexBackDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexBack--);                        // 車種呼称コード
            this._controlIndexBackDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexBack--);                        // 車種名称
            this._controlIndexBackDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexBack--);                   // 年式
            this._controlIndexBackDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexBack--);                      // 車台番号
            this._controlIndexBackDictionary.Add(this.tEdit_ColorNo.Name, controlIndexBack--);                              // カラー
            this._controlIndexBackDictionary.Add(this.tEdit_TrimNo.Name, controlIndexBack--);                               // トリム
            // --- ADD 2009/12/23 ---------->>>>>
            this._controlIndexBackDictionary.Add(this.tNedit_SlipNoteCode.Name, controlIndexBack--);                  // 伝票備考コード
            this._controlIndexBackDictionary.Add(this.tEdit_SlipNote.Name, controlIndexBack--);                       // 伝票備考
            this._controlIndexBackDictionary.Add(this.tNedit_SlipNote2Code.Name, controlIndexBack--);                 // 伝票備考２コード
            this._controlIndexBackDictionary.Add(this.tEdit_SlipNote2.Name, controlIndexBack--);                      // 伝票備考２
            this._controlIndexBackDictionary.Add(this.tNedit_SlipNote3Code.Name, controlIndexBack--);                 // 伝票備考３コード
            this._controlIndexBackDictionary.Add(this.tEdit_SlipNote3.Name, controlIndexBack--);                      // 伝票備考３
            this._controlIndexBackDictionary.Add(this.tNedit_AddresseeCode.Name, controlIndexBack--);                 // 納入先コード
            this._controlIndexBackDictionary.Add(this.tEdit_AddresseeName.Name, controlIndexBack--);                  // 納入先
            this._controlIndexBackDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexBack--);       // 納品区分
            this._controlIndexBackDictionary.Add(this.uButton_AddresseeConfirmation.Name, controlIndexBack--);        // 納入先確認
            this._controlIndexBackDictionary.Add(this.tEdit_RetGoodsReason.Name, controlIndexBack--);                 // 返品理由
            this._controlIndexBackDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);               // 仮伝番号
            this._controlIndexBackDictionary.Add(this.tEdit_CarSlipNote.Name, controlIndexBack--);                    // 車輌備考
            this._controlIndexBackDictionary.Add(this.tNedit_Mileage.Name, controlIndexBack--);                       // 走行距離
            // --- ADD 2009/12/23 ----------<<<<<

            // ヘッダ項目Dictionary作成
            this._headerItemsDictionary.Add(this.uLabel_SectionCode.Text.Trim(), this.tEdit_SectionCode);
            this._headerItemsDictionary.Add(this.uLabel_SubSectionCode.Text.Trim(), this.tNedit_SubSectionCode);
            this._headerItemsDictionary.Add(this.uLabel_CustomerCode.Text.Trim(), this.tNedit_CustomerCode);
            this._headerItemsDictionary.Add(this.uLabel_CustomerName.Text.Trim(), this.tEdit_CustomerName);
            this._headerItemsDictionary.Add(this.uButton_CustomerClaimConfirmation.Text.Trim(), this.uButton_CustomerClaimConfirmation);
            this._headerItemsDictionary.Add(this.uLabel_SalesEmployeeCd.Text.Trim(), this.tEdit_SalesEmployeeCd);
            this._headerItemsDictionary.Add(this.uLabel_FrontEmployeeCd.Text.Trim(), this.tEdit_FrontEmployeeCd);
            this._headerItemsDictionary.Add(this.uLabel_SalesInputCode.Text.Trim(), this.tEdit_SalesInputCode);
            this._headerItemsDictionary.Add(this.uLabel_AcptAnOdrStatus.Text.Trim(), this.tComboEditor_AcptAnOdrStatusDisplay);
            this._headerItemsDictionary.Add(this.uLabel_SalesSlip.Text.Trim(), this.tComboEditor_SalesSlipDisplay);
            this._headerItemsDictionary.Add(this.uLabel_SalesDate.Text.Trim(), this.tDateEdit_SalesDate);
            this._headerItemsDictionary.Add(this.uLabel_CarMngNo.Text.Trim(), this.tEdit_CarMngCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelDesignationNo.Text.Trim(), this.tNedit_ModelDesignationNo);
            this._headerItemsDictionary.Add(this.uLabel_EngineModelNm.Text.Trim(), this.tEdit_EngineModelNm);
            this._headerItemsDictionary.Add(this.uButton_ChangeSearchCarMode.Text.Trim(), this.tEdit_FullModel);
            this._headerItemsDictionary.Add(this.uLabel_MakerCode.Text.Trim(), this.tNedit_MakerCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelCode.Text.Trim(), this.tNedit_ModelCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelSubCode.Text.Trim(), this.tNedit_ModelSubCode);
            this._headerItemsDictionary.Add(this.uLabel_CarName.Text.Trim(), this.tEdit_ModelFullName);
            this._headerItemsDictionary.Add(this.uLabel_FirstEntryDate.Text.Trim(), this.tDateEdit_FirstEntryDate);
            this._headerItemsDictionary.Add(this.uLabel_ProduceFrameNo.Text.Trim(), this.tEdit_ProduceFrameNo);
            this._headerItemsDictionary.Add(this.uLabel_ColorNo.Text.Trim(), this.tEdit_ColorNo);
            this._headerItemsDictionary.Add(this.uLabel_TrimNo.Text.Trim(), this.tEdit_TrimNo);

            controlIndexForword = 0;
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNoteCode.Name, controlIndexForword++);                  // 伝票備考１コード ADD 2009/12/23
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote.Name, controlIndexForword++);                       // 伝票備考１
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote.Name, controlIndexForword++);                     // 伝票備考１ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNote2Code.Name, controlIndexForword++);                 // 伝票備考２コード ADD 2009/12/23
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote2.Name, controlIndexForword++);                      // 伝票備考２
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexForword++);                    // 伝票備考２ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SlipNote3Code.Name, controlIndexForword++);                 // 伝票備考３コード ADD 2009/12/23
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SlipNote3.Name, controlIndexForword++);                      // 伝票備考３
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote3.Name, controlIndexForword++);                    // 伝票備考３ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_AddresseeCode.Name, controlIndexForword++);                 // 納入先コード
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_AddresseeName.Name, controlIndexForword++);                  // 納入先名称
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_AddresseeGuide.Name, controlIndexForword++);               // 納入先ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexForword++);       // 納品区分
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_AddresseeConfirmation.Name, controlIndexForword++);        // 納入先確認ボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexForword++);                  // 納入先名称
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexForword++);               // 納入先ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);               // 得意先注番
            // --- ADD 2009/09/08② ---------->>>>>
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_CarSlipNote.Name, controlIndexForword++);                    // 車輌備考
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNoteGuide.Name, controlIndexForword++);                // 車輌備考ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_Mileage.Name, controlIndexForword++);                       // 走行距離
            // --- ADD 2009/09/08② ----------<<<<<

            controlIndexBack = 99;
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNoteCode.Name, controlIndexBack--);                        // 伝票備考１コード ADD 2009/12/23
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote.Name, controlIndexBack--);                             // 伝票備考１
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote.Name, controlIndexBack--);                           // 伝票備考１ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNote2Code.Name, controlIndexBack--);                       // 伝票備考２コード ADD 2009/12/23
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote2.Name, controlIndexBack--);                            // 伝票備考２
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexBack--);                          // 伝票備考２ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SlipNote3Code.Name, controlIndexBack--);                       // 伝票備考３コード ADD 2009/12/23
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SlipNote3.Name, controlIndexBack--);                            // 伝票備考３
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote3.Name, controlIndexBack--);                          // 伝票備考３ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_AddresseeCode.Name, controlIndexBack--);                       // 納入先コード
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_AddresseeName.Name, controlIndexBack--);                        // 納入先名称
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_AddresseeGuide.Name, controlIndexBack--);                     // 納入先ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexBack--);             // 納品区分
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_AddresseeConfirmation.Name, controlIndexBack--);              // 納入先確認ボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexBack--);                        // 納入先名称
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexBack--);                     // 納入先ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);                     // 得意先注番
            // --- ADD 2009/09/08② ---------->>>>>
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_CarSlipNote.Name, controlIndexBack--);                           // 車輌備考
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNoteGuide.Name, controlIndexBack--);                       // 車輌備考ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_Mileage.Name, controlIndexBack--);                              // 走行距離
            // --- ADD 2009/09/08② ----------<<<<<

            // --- ADD 2009/12/23 ---------->>>>>
            // フッタ項目Dictionary作成
            this._footerItemsDictionary.Add("伝票備考コード", this.tNedit_SlipNoteCode);
            this._footerItemsDictionary.Add("伝票備考", this.tEdit_SlipNote);
            this._footerItemsDictionary.Add("伝票備考２コード", this.tNedit_SlipNote2Code);
            this._footerItemsDictionary.Add("伝票備考２", this.tEdit_SlipNote2);
            this._footerItemsDictionary.Add("伝票備考３コード", this.tNedit_SlipNote3Code);
            this._footerItemsDictionary.Add("伝票備考３", this.tEdit_SlipNote3);
            this._footerItemsDictionary.Add("納入先コード", this.tNedit_AddresseeCode);

            this._footerItemsDictionary.Add(this.uLabel_AddresseeCode.Text.Trim(), this.tEdit_AddresseeName);
            this._footerItemsDictionary.Add(this.uLabel_DeliveredGoodsDiv.Text.Trim(), this.tComboEditor_DeliveredGoodsDiv);
            this._footerItemsDictionary.Add(this.uButton_AddresseeConfirmation.Text.Trim(), this.uButton_AddresseeConfirmation);
            this._footerItemsDictionary.Add(this.uLabel_ReturnReasonTitle.Text.Trim(), this.tEdit_RetGoodsReason);
            this._footerItemsDictionary.Add(this.uLabel_PartySaleSlipNum.Text.Trim(), this.tEdit_PartySaleSlipNum);
            this._footerItemsDictionary.Add(this.ultraLabel47.Text.Trim(), this.tEdit_CarSlipNote);
            this._footerItemsDictionary.Add(this.ultraLabel45.Text.Trim(), this.tNedit_Mileage);

            this._salesInputConstructionAcs.FooterItemsDictionary = this._footerItemsDictionary;
            // --- ADD 2009/12/23 ----------<<<<<

            this._salesInputConstructionAcs.HeaderItemsDictionary = this._headerItemsDictionary;
            this._salesInputConstructionAcs.EnterpriseCode = this._enterpriseCode;

            this._carControlList = new List<Control>();
            this._carControlList.Add(this.tEdit_CarMngCode);
            this._carControlList.Add(this.uButton_CarMngNoGuide);
            this._carControlList.Add(this.tNedit_ModelDesignationNo);
            this._carControlList.Add(this.tNedit_CategoryNo);
            this._carControlList.Add(this.tEdit_EngineModelNm);
            this._carControlList.Add(this.tEdit_FullModel);
            this._carControlList.Add(this.tNedit_MakerCode);
            this._carControlList.Add(this.tNedit_ModelCode);
            this._carControlList.Add(this.tNedit_ModelSubCode);
            this._carControlList.Add(this.tEdit_ModelFullName);
            this._carControlList.Add(this.uButton_ModelFullGuide);
            this._carControlList.Add(this.tDateEdit_FirstEntryDate);
            this._carControlList.Add(this.tEdit_ProduceFrameNo);
            this._carControlList.Add(this.tEdit_ColorNo);
            this._carControlList.Add(this.tEdit_TrimNo);

            this._memoControlList = new List<Control>();
            this._memoControlList.Add(this.tEdit_InsideMemo1);
            this._memoControlList.Add(this.tEdit_InsideMemo2);
            this._memoControlList.Add(this.tEdit_InsideMemo3);
            this._memoControlList.Add(this.tEdit_SlipMemo1);
            this._memoControlList.Add(this.tEdit_SlipMemo2);
            this._memoControlList.Add(this.tEdit_SlipMemo3);

            this._detailControl = this._salesSlipDetailInput.uGrid_Details;
            // --- UPD 2009/12/23 ---------->>>>>
            //this._footerControl = this.tEdit_SlipNote;
            this._footerControl = this.tNedit_SlipNoteCode;
            // --- UPD 2009/12/23 ----------<<<<<

            this._salesSlipInputAcs.MyOpeCtrl = MyOpeCtrl;

            this._changeFocusSaveCancel = false;

            // 受注ステータスリスト作成
            this._stateList = new List<SalesSlipInputAcs.AcptAnOdrStatusState>();
            this._stateList.AddRange(new SalesSlipInputAcs.AcptAnOdrStatusState[] {
                                            SalesSlipInputAcs.AcptAnOdrStatusState.Sales,
                                            SalesSlipInputAcs.AcptAnOdrStatusState.Shipment,
                                            SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder,
                                            SalesSlipInputAcs.AcptAnOdrStatusState.Estimate,
                                            SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate});

            // --- ADD 2009/09/08② ---------->>>>>
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            // --- ADD 2009/09/08② ----------<<<<<

            // --- ADD 2009/12/23 ---------->>>>>
            //伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
            this._salesSlipInputAcs.GetNoteCharCnt();
            SetNoteCharCnt();
            // --- ADD 2009/12/23 ----------<<<<<

            SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Constructor", "▲▲▲▲▲終了▲▲▲▲▲");
        }
        //<<<2010/02/26

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		public const int ctSET_DISPLAY_MODE_All = 0;							// 画面表示モード（すべて）
		public const int ctSET_DISPLAY_MODE_TotalPriceInfoOnly = 1;				// 画面表示モード（合計金額情報のみ）
		private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
		private const string ctGUIDE_NAME_SubSectionGuide = "SubSectionGuide";
		private const string ctGUIDE_NAME_EmployeeGuide = "EmployeeGuide";
		private const string ctGUIDE_NAME_FrontEmployeeGuide = "FrontEmployeeGuide";
		private const string ctGUIDE_NAME_SalesInputGuide = "SalesInputGuide";
		private const string ctGUIDE_NAME_SalesSlipGuide = "SalesSlipGuide";
		private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
		private const string ctGUIDE_NAME_ReturnReasonGuide = "ReturnReasonGuide";
		private const string ctGUIDE_NAME_AddresseeGuide = "AddresseeGuide";
		private const string ctGUIDE_NAME_SlipNoteGuide = "SlipNoteGuide";
		private const string ctGUIDE_NAME_SlipNoteGuide2 = "SlipNoteGuide2";
		private const string ctGUIDE_NAME_SlipNoteGuide3 = "SlipNoteGuide3";
		private const string ctGUIDE_NAME_WarehouseGuide = "WarehouseGuide";
		private const string ctGUIDE_NAME_ModelFullGuide = "ModelFullGuide";
		private const string ctGUIDE_NAME_CarMngNoGuide = "CarMngNoGuide";
		private const string ctGUIDE_NAME_RetGoodsReason = "RetGoodsReason";
		private const string ctGUIDE_NAME_CarSlipNoteGuide = "CarSlipNoteGuide";// ADD 2009/09/08②
		private const string ctAssemblyName = "MAHNB01010UA";

		private const string ctTAB_KEY_TotalInfo = "TotalInfo";
		private const string ctTAB_KEY_MemoInfo = "MemoInfo";
		private const string ctTAB_KEY_AddInfo = "AddInfo"; // ADD 2009/09/08②
		private const string ctTAB_KEY_EstimateInfo = "EstimateInfo";

		private const string ctSearchMode_BLSearch = "部品検索"; // BLコード検索
		private const string ctSearchMode_GoodsNoSearch = "品番入力"; // 品番検索

		private const string ctSearchCarMode_FullModel = "型式";
		private const string ctSearchCarMode_ModelPlate = "ﾓﾃﾞﾙﾌﾟﾚｰﾄ";

		private const string ctSave = "保存";
		private const string ctDecision = "確定";
		private const string ctSaveToolTipText = "現在編集中の情報を保存します。";
		private const string ctDecisionToolTipText = "次グループへ移動します。";

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
		private const string SLIPHEADERCOPY_XML_FILE_NAME = "SalesSlipHeaderCopy_PMKAU04000U.xml";
		private const string ENCRYPTION_KEY = "44965615-3203-47ac-a6b0-ea8191390f0b";
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

		private const int ctEffectiveDetailHeight = 48; // 2009/09/09 ADD

		#region Delegate
		/// <summary>
		/// タブ変更デリゲート
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key">タブキー</param>
		public delegate void TabChangeEventHandler(object sender, string key);
		#endregion

		#region Events
		private event TabChangeEventHandler TabChanged;
		#endregion
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
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
					_operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAHNB01000U", this);
				}
				return _operationAuthority;
			}
		}

        //>>>2010/02/26
        /// <summary>起動パラメータ</summary>
        public string Parameter
        {
            set { this._parameter = value; }
            get { return this._parameter; }
        }
        /// <summary>問合せ番号(SCM用)</summary>
        public long InquiryNumber
        {
            set { this._scmInquiryNumber = value; }
            get { return this._scmInquiryNumber; }
        }
        /// <summary>受注ステータス(SCM用)</summary>
        public int AcptAnOdrStatus
        {
            set { this._scmAcptAnOdrStatus = value; }
            get { return this._scmAcptAnOdrStatus; }
        }
        /// <summary>売上伝票番号(SCM用)</summary>
        public string SalesSlipNum
        {
            set { this._scmSalesSlipNum = value; }
            get { return this._scmSalesSlipNum; }
        }
        /// <summary>問合元企業コード(SCM用)</summary>
        public string InqOriginalEpCd
        {
            set { this._inqOriginalEpCd = value; }
            get { return this._inqOriginalEpCd; }
        }
        /// <summary>問合元拠点コード(SCM用)</summary>
        public string InqOriginalSecCd
        {
            set { this._inqOriginalSecCd = value; }
            get { return this._inqOriginalSecCd; }
        }
        /// <summary>問合せ・発注種別(SCM用)</summary>
        public int InqOrdDivCd
        {
            set { this._inqOrdDivCd = value; }
            get { return this._inqOrdDivCd; }
        }
        /// <summary>得意先コード(SCM用)</summary>
        public int CustomerCode
        {
            set { this._customerCode = value; }
            get { return this._customerCode; }
        }
        //<<<2010/02/26

        // 2011/02/18 >>>
        ////>>>2010/04/30
        ///// <summary>回答区分</summary>
        //public int AnswerDivCd
        //{
        //    set { this._answerDivCd = value; }
        //    get { return this._answerDivCd; }
        //}
        ////<<<2010/04/30

        /// <summary>回答区分</summary>
        public short CancelDiv
        {
            set { this._cancelDiv = value; }
            get { return this._cancelDiv; }
        }
        // 2011/02/18 <<<
        # endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 初期データ取得用のスレッド
		/// </summary>
		private void ReadInitialThread()
		{
			this._salesSlipInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "ReadInitialThread", "終了");
		}

		/// <summary>
		/// 初期データ取得用のスレッド
		/// </summary>
		private void ReadInitialThreadSecond()
		{
			this._salesSlipInputInitDataAcs.ReadInitDataSecond(this._enterpriseCode, this._loginSectionCode);
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "ReadInitialThreadSecond", "終了");
		}

		/// <summary>
		/// 初期データ取得用のスレッド
		/// </summary>
		private void ReadInitialThreadThird()
		{
			this._salesSlipInputInitDataAcs.ReadInitDataThird(this._enterpriseCode, this._loginSectionCode);
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "ReadInitialThreadThird", "終了");
		}

		/// <summary>
		/// Loadイベント用のスレッド
		/// </summary>
		private void LoadInitialThread()
		{
			SalesSlipInputInitDataAcs.LogWrite("Ｌ MAHNB01010UA", "MAHNB01010UA_Load", "ツールバー初期設定処理");
			// ツールバー初期設定処理
			ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.tToolbarsManager_MainMenu);

			SalesSlipInputInitDataAcs.LogWrite("Ｌ MAHNB01010UA", "MAHNB01010UA_Load", "ボタン初期設定処理");
			// ボタン初期設定処理
			this.ButtonInitialSetting();

			SalesSlipInputInitDataAcs.LogWrite("Ｌ MAHNB01010UA", "MAHNB01010UA_Load", "フォーカス移動設定処理");
			// フォーカス移動設定処理
			this.SettingFocusDictionary();

			SalesSlipInputInitDataAcs.LogWrite("Ｌ MAHNB01010UA", "LoadInitialThread", "LoadInitialThread 終了");
		}

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
			this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			this._stockSearchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
			this._redSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
			this._returnSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this._readSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
			this._deleteSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			this._copySlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
			this._shipmentAddUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIP;
			this._acceptAnOrderAddUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIP;
			this._estimateAddUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIP;
			this._printSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
			this._forwardButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
			this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			this._searchChangeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
			this._searchCarChangeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
			this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
			this._slipHeaderCopyButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
			// --- ADD 2009/11/24 ---------->>>>>
			this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// --- ADD 2009/11/24 ----------<<<<<
            //>>>2010/02/26
            this._referenceListButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            this._replyTransactionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT3;
            //<<<2010/02/26

			this.uButton_SectionGuide.ImageList = this._imageList16;
			this.uButton_SubSectionGuide.ImageList = this._imageList16;
			this.uButton_SalesSlipGuide.ImageList = this._imageList16;
			this.uButton_EmployeeGuide.ImageList = this._imageList16;
			this.uButton_FrontEmployeeGuide.ImageList = this._imageList16;
			this.uButton_SalesInputGuide.ImageList = this._imageList16;
			this.uButton_CustomerGuide.ImageList = this._imageList16;
			this.uButton_AddresseeGuide.ImageList = this._imageList16;
			this.uButton_SlipNote.ImageList = this._imageList16;
			this.uButton_SlipNote2.ImageList = this._imageList16;
			this.uButton_SlipNote3.ImageList = this._imageList16;
			this.uButton_ModelFullGuide.ImageList = this._imageList16;
			this.uButton_CarMngNoGuide.ImageList = this._imageList16;
			this.uButton_RetGoodsReason.ImageList = this._imageList16;
			this.uButton_SlipNoteGuide.ImageList = this._imageList16;// ADD 2009/09/08②

			this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SalesSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_FrontEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_AddresseeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SlipNote.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SlipNote2.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SlipNote3.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_CarMngNoGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_RetGoodsReason.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SlipNoteGuide.Appearance.Image = (int)Size16_Index.STAR1;// ADD 2009/09/08②
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// ログイン拠点名称
			this._loginSectionNameLabel.SharedProps.Caption = this._salesSlipInputInitDataAcs.OwnSectionName;
		}

		/// <summary>
		/// コンボエディタアイテム初期設定処理
		/// </summary>
		private void ComboEditorItemInitialSetting()
		{
			// 納品区分
			this._salesSlipInputInitDataAcs.SetUserGdBdComboEditor(ref this.tComboEditor_DeliveredGoodsDiv, SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv);
		}

		/// <summary>
		/// 売上データクラス→画面格納処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		private void SetDisplay(SalesSlip salesSlip)
		{
			// 画面表示処理（ヘッダ、フッタ情報／売上データより）
			this.SetDisplayHeaderFooterInfo(salesSlip);

			// 画面表示処理（売上金額合計情報）
			this.SetDisplayTotalPriceInfo(salesSlip);
		}

		/// <summary>
		/// 売上データクラス→画面格納処理（オーバーロード）
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="mode">表示モード</param>
		private void SetDisplay(SalesSlip salesSlip, int mode)
		{
			switch (mode)
			{
				case ctSET_DISPLAY_MODE_All:
					{
						this.SetDisplay(salesSlip);
						break;
					}
				case ctSET_DISPLAY_MODE_TotalPriceInfoOnly:
					{
						// 画面表示処理（売上金額合計情報）
						this.SetDisplayTotalPriceInfo(salesSlip);
						break;
					}
			}
		}

		/// <summary>
		/// 売上データクラス→画面格納処理（オーバーロード）
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		private void SetDisplay(SalesSlip salesSlip, SalesInputDataSet.SalesDetailRow row)
		{
			// 画面表示処理（売上金額合計情報）
			this.SetDisplayTotalPriceInfo(salesSlip);

			// フッタ画面表示処理（明細情報）
			this.SetDisplayDetailInfo(row);
		}

		/// <summary>
		/// 明細コンポーネント取得処理
		/// </summary>
		/// <returns></returns>
		private Control GetDetailComponent()
		{
			return this._salesSlipDetailInput;
		}

		/// <summary>
		/// フッタータブ変更時発生処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key"></param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void FooterTabChanged(object sender, string key)
		{
			switch (key)
			{
				case MAHNB01010UA.ctTAB_KEY_TotalInfo:
					{
						if ((this.tEdit_SlipNote.Visible) && (this.tEdit_SlipNote.Enabled) && (!this.tEdit_SlipNote.ReadOnly))
						{
							// --- UPD 2009/12/23 ---------->>>>>
							//this.tEdit_SlipNote.Focus();
							this.tNedit_SlipNoteCode.Focus();
							// --- UPD 2009/12/23 ----------<<<<<
						}
						break;
					}
				case MAHNB01010UA.ctTAB_KEY_MemoInfo:
					{
						if ((this.tEdit_InsideMemo1.Visible) && (this.tEdit_InsideMemo1.Enabled) && (!this.tEdit_InsideMemo1.ReadOnly))
						{
							this.tEdit_SlipMemo1.Focus();
						}
						break;
					}
				// --- ADD 2009/09/08② ---------->>>>>
				case MAHNB01010UA.ctTAB_KEY_AddInfo:
					{
						if ((this.tEdit_CarSlipNote.Visible) && (this.tEdit_CarSlipNote.Enabled) && (!this.tEdit_CarSlipNote.ReadOnly))
						{
							this._prevControl = this.tEdit_CarSlipNote;

							this.tEdit_CarSlipNote.Focus();
							this.tEdit_CarSlipNote.Select(0, this.tEdit_CarSlipNote.Text.Length);
						}
						break;
					}
				// --- ADD 2009/09/08② ----------<<<<<
#if false // 見積情報
                case MAHNB01010UA.ctTAB_KEY_EstimateInfo:
                    {
                        if ((this.tEdit_EstimateSubject.Visible) && (this.tEdit_EstimateSubject.Enabled) && (!this.tEdit_EstimateSubject.ReadOnly))
                        {
                            this.tEdit_EstimateSubject.Focus();
                        }
                        break;
                    }
#endif
			}
		}

		/// <summary>
		/// 画面表示処理（ヘッダ、フッタ情報／売上データより）
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void SetDisplayHeaderFooterInfo(SalesSlip salesSlip)
		{
			#region ●売上情報
			if (salesSlip == null) return;

			// 拠点
			this.tEdit_SectionCode.Value = salesSlip.ResultsAddUpSecCd.Trim();
			if (string.IsNullOrEmpty(salesSlip.ResultsAddUpSecNm))
			{
				SecInfoSet secInfoSet = this._salesSlipInputInitDataAcs.GetSecInfo(salesSlip.ResultsAddUpSecCd.Trim());
				if (secInfoSet != null) this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
				else this.uLabel_SectionNm.Text = string.Empty;
			}
			else
			{
				this.uLabel_SectionNm.Text = salesSlip.ResultsAddUpSecNm;
			}
			// 部門
			this.tNedit_SubSectionCode.SetInt(salesSlip.SubSectionCode);
			if (string.IsNullOrEmpty(salesSlip.SubSectionName))
			{
				string name = this._salesSlipInputInitDataAcs.GetName_FromSubSection(salesSlip.SubSectionCode);
				if (string.IsNullOrEmpty(name.Trim()))
				{
					this.tNedit_SubSectionCode.SetInt(0);
					this.uLabel_SubSectionNm.Text = string.Empty;
				}
				else
				{
					this.uLabel_SubSectionNm.Text = name;
				}
			}
			else
			{
				this.uLabel_SubSectionNm.Text = salesSlip.SubSectionName;
			}
			// 伝票番号
			this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(salesSlip.SalesSlipNum, 0));
			// 担当者
			this.tEdit_SalesEmployeeCd.Text = salesSlip.SalesEmployeeCd.Trim();
			this.uLabel_SalesEmployeeNm.Text = salesSlip.SalesEmployeeNm;
			// 受注者
			this.tEdit_FrontEmployeeCd.Text = salesSlip.FrontEmployeeCd.Trim();
			this.uLabel_FrontEmployeeNm.Text = salesSlip.FrontEmployeeNm;
			// 発行者
			this.tEdit_SalesInputCode.Text = salesSlip.SalesInputCode.Trim();
			this.uLabel_SalesInputNm.Text = salesSlip.SalesInputName;
			// 売上形式(表示用)
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatusDisplay, salesSlip.AcptAnOdrStatusDisplay, true);
			// 売上形式
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AcptAnOdrStatus, salesSlip.AcptAnOdrStatus, true);
			// 伝票区分(表示用)
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SalesSlipDisplay, salesSlip.SalesSlipDisplay, true);
			// 商品区分
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SalesGoodsCd, salesSlip.SalesGoodsCd, true);
			// 得意先
			this.tNedit_CustomerCode.SetInt(salesSlip.CustomerCode);
			// 2009.08.03 >>>
			//this.tEdit_CustomerName.Text = salesSlip.CustomerName + salesSlip.CustomerName2;
			this.tEdit_CustomerName.Text = salesSlip.CustomerSnm;
			// 2009.08.03 <<<
			// 納入先
			this.tNedit_AddresseeCode.SetInt(salesSlip.AddresseeCode);
			this.tEdit_AddresseeName.Text = salesSlip.AddresseeName + salesSlip.AddresseeName2;
			// 売上日
			this.tDateEdit_SalesDate.SetDateTime(salesSlip.SalesDate);
			// 入力日
			this.tDateEdit_SearchSlipDate.SetDateTime(salesSlip.SearchSlipDate);
			// 得意先注番
			this.tEdit_PartySaleSlipNum.Text = salesSlip.PartySaleSlipNum;
			// 備考１
			this.tEdit_SlipNote.Text = salesSlip.SlipNote;
			// 備考２
			this.tEdit_SlipNote2.Text = salesSlip.SlipNote2;
			// 備考３
			this.tEdit_SlipNote3.Text = salesSlip.SlipNote3;

			// --- ADD 2009/12/23 ---------->>>>>
			// 備考１コード
			this.tNedit_SlipNoteCode.SetInt(salesSlip.SlipNoteCode);
			// 備考２コード
			this.tNedit_SlipNote2Code.SetInt(salesSlip.SlipNote2Code);
			// 備考３コード
			this.tNedit_SlipNote3Code.SetInt(salesSlip.SlipNote3Code);
			// --- ADD 2009/12/23 ----------<<<<<

			// 返品理由
			this.tEdit_RetGoodsReason.Text = salesSlip.RetGoodsReason;
			// 納品区分
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_DeliveredGoodsDiv, salesSlip.DeliveredGoodsDiv, false);

            //>>>2010/02/26
            // 回答区分
            ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AnswerDiv, salesSlip.AnswerDiv, false);
            // 問合せ番号
            this.tNedit_InquiryNumber.SetValue(salesSlip.InquiryNumber);
            //<<<2010/02/26

			// 入力モード
			if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Return)
			{
				this.uLabel_InputModeTitle.Text = "返品";
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Red)
			{
				this.uLabel_InputModeTitle.Text = "赤伝";
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly)
			{
				if (salesSlip.DebitNoteDiv == 2)
				{
					this.uLabel_InputModeTitle.Text = "元黒";
				}
				else if (salesSlip.DepositAllowanceTtl != 0)
				{
					this.uLabel_InputModeTitle.Text = "入金済み";
				}
				else if (!this._salesSlipInputAcs.CheckTransStopDate(salesSlip.TransStopDate, salesSlip.SalesDate))
				{
					this.uLabel_InputModeTitle.Text = "取引中止";
				}
				else
				{
					this.uLabel_InputModeTitle.Text = "編集不可";
				}
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp)
			{
				this.uLabel_InputModeTitle.Text = "貸出計上";
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp)
			{
				this.uLabel_InputModeTitle.Text = "受注計上";
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp)
			{
				this.uLabel_InputModeTitle.Text = "見積計上";
			}
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp)
			{
				this.uLabel_InputModeTitle.Text = "締済み";
			}
			else
			{
				this.uLabel_InputModeTitle.Text = "通常";
			}

			// 伝票種別アイテム再設定
			this.SetItemtAcptAnOdrStatus(salesSlip.AcptAnOdrStatusDisplay, salesSlip.InputMode, false);

			// 伝票区分が返品の場合は返品理由を表示する＆金額文字色設定
			if (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
			{
				this.uLabel_ReturnReasonTitle.Visible = true;
				this.tEdit_RetGoodsReason.Visible = true;
				this.uButton_RetGoodsReason.Visible = true;
				this.uLabel_SalesPriceTotal.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_SalesPriceConsTaxTotal.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_TotalGrossProfit.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_TotalCost.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_TotalPrice.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_DetailGrossProfitRate.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_TotalGrossProfitRate.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				// --- ADD 2009/09/08② ---------->>>>>
				this.uLabel_AddSalesPriceTotal.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddSalesPriceConsTaxTotal.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddTotalGrossProfit.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddTotalCost.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddTotalPrice.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddDetailGrossProfitRate.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				this.uLabel_AddTotalGrossProfitRate.Appearance.ForeColor = ct_MINUS_FONT_COLOR;
				// --- ADD 2009/09/08② ----------<<<<<
			}
			else
			{
				this.uLabel_ReturnReasonTitle.Visible = false;
				this.tEdit_RetGoodsReason.Visible = false;
				this.uButton_RetGoodsReason.Visible = false;
				this.uLabel_SalesPriceTotal.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_SalesPriceConsTaxTotal.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_TotalGrossProfit.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_TotalCost.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_TotalPrice.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_DetailGrossProfitRate.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_TotalGrossProfitRate.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				// --- ADD 2009/09/08② ---------->>>>>
				this.uLabel_AddSalesPriceTotal.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddSalesPriceConsTaxTotal.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddTotalGrossProfit.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddTotalCost.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddTotalPrice.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddDetailGrossProfitRate.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				this.uLabel_AddTotalGrossProfitRate.Appearance.ForeColor = ct_NORMAL_FONT_COLOR;
				// --- ADD 2009/09/08② ----------<<<<<
			}

			// 伝票種別タイトルの再表示
			switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatusDisplay)
			{
				case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
					this.uLabel_AcptAnOdrStatusTitle.Text = "見積";
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor = ct_ESTIMATE_BACKCOLOR;
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor2 = ct_ESTIMATE_BACKCOLOR2;
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
					this.uLabel_AcptAnOdrStatusTitle.Text = "単価見積";
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor = ct_UNITESTIMATE_BACKCOLOR;
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor2 = ct_UNITESTIMATE_BACKCOLOR2;
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
					this.uLabel_AcptAnOdrStatusTitle.Text = "売上";
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor = ct_SALES_BACKCOLOR;
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor2 = ct_SALES_BACKCOLOR2;
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
					this.uLabel_AcptAnOdrStatusTitle.Text = "貸出";
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor = ct_SHIPMENT_BACKCOLOR;
					this.uLabel_AcptAnOdrStatusTitle.Appearance.BackColor2 = ct_SHIPMENT_BACKCOLOR2;
					break;
			}

			#endregion

#if false // 見積情報
			#region ●見積情報
            //---------------------------------------------
            // 見積情報
            //---------------------------------------------
            // 税表示
            this.tComboEditor_GoodsNoPrintDiv.Value = salesSlip.EstimaTaxDivCd;
            // 定価印刷
            this.tComboEditor_ListPricePrintDiv.Value = salesSlip.ListPricePrintDiv;
            // 品番印刷
            this.tComboEditor_GoodsNoPrintDiv.Value = salesSlip.PartsNoPrtCd;
            // 見積有効期限
            this.tDateEdit_EstimateValidityDate.SetDateTime(salesSlip.EstimateValidityDate);

            // 物件名
            this.tEdit_EstimateSubject.Text = salesSlip.EstimateSubject;
            // 見積備考１
            this.tEdit_EstimateNote1.Text = salesSlip.EstimateNote1;
            // 見積備考２
            this.tEdit_EstimateNote2.Text = salesSlip.EstimateNote2;
            // 見積備考３
            this.tEdit_EstimateNote3.Text = salesSlip.EstimateNote3;
			#endregion
#endif

			#region ●画面項目Enabled設定
			//---------------------------------------------
			// 画面項目Dictionary作成
			//---------------------------------------------
			Dictionary<Control, bool> itemDic = this.MakeItemDic();
			this.groupBox17.Enabled = true;

			this._salesSlipDetailInput.Refresh();

			// 入力モードが「参照モード」の場合は、全て入力不可とする
			// 入力モードが「締済みモード」の場合は、赤伝以外入力不可とする
			if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
				(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
			{
				itemDic[tEdit_SectionCode] = false;
				itemDic[uButton_SectionGuide] = false;
				itemDic[tNedit_SubSectionCode] = false;
				itemDic[uButton_SubSectionGuide] = false;
				itemDic[tEdit_SalesEmployeeCd] = false;
				itemDic[uButton_EmployeeGuide] = false;
				itemDic[tEdit_FrontEmployeeCd] = false;
				itemDic[uButton_FrontEmployeeGuide] = false;
				itemDic[tEdit_SalesInputCode] = false;
				itemDic[uButton_SalesInputGuide] = false;
				itemDic[tNedit_SalesSlipNum] = false;
				itemDic[tComboEditor_AcptAnOdrStatusDisplay] = false;
				itemDic[tComboEditor_SalesSlipDisplay] = false;
				itemDic[tComboEditor_SalesGoodsCd] = false;
				itemDic[tNedit_CustomerCode] = false;
				itemDic[tEdit_CustomerName] = false;
				itemDic[uButton_CustomerGuide] = false;
				itemDic[tNedit_AddresseeCode] = false;
				itemDic[tEdit_AddresseeName] = false;
				itemDic[uButton_AddresseeGuide] = false;
				itemDic[uButton_FrontEmployeeGuide] = false;
				itemDic[tDateEdit_SalesDate] = false;
				itemDic[tEdit_PartySaleSlipNum] = false;
				itemDic[tEdit_SlipNote] = false;
				itemDic[tEdit_SlipNote2] = false;
				itemDic[tEdit_SlipNote3] = false;
				// --- ADD 2009/12/23 ---------->>>>>
				itemDic[tNedit_SlipNoteCode] = false;
				itemDic[tNedit_SlipNote2Code] = false;
				itemDic[tNedit_SlipNote3Code] = false;
				// --- ADD 2009/12/23 ----------<<<<<
                //itemDic[panel_Footer] = false; // 2010/04/08
                itemDic[uButton_CustomerClaimConfirmation] = false;
				itemDic[uButton_AddresseeConfirmation] = false;
				itemDic[tComboEditor_SalesSlipDisplay] = false;
                //>>>2010/04/08
                itemDic[tEdit_SlipMemo1] = false;
                itemDic[tEdit_SlipMemo2] = false;
                itemDic[tEdit_SlipMemo3] = false;
                itemDic[tEdit_InsideMemo1] = false;
                itemDic[tEdit_InsideMemo2] = false;
                itemDic[tEdit_InsideMemo3] = false;
                itemDic[tComboEditor_DeliveredGoodsDiv] = false;
                //<<<2010/04/08
			}
			// 入力モードが「返品入力モード」
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Return)
			{
				itemDic[tEdit_SectionCode] = false;
				itemDic[uButton_SectionGuide] = false;
				itemDic[tNedit_SubSectionCode] = false;
				itemDic[uButton_SubSectionGuide] = false;
				itemDic[tComboEditor_AcptAnOdrStatusDisplay] = false;
				itemDic[tComboEditor_SalesSlipDisplay] = false;
				itemDic[tComboEditor_SalesGoodsCd] = false;
				itemDic[tNedit_CustomerCode] = false;
				itemDic[tEdit_CustomerName] = false;
				itemDic[uButton_CustomerGuide] = false;
				itemDic[tNedit_AddresseeCode] = false;
				itemDic[tEdit_AddresseeName] = false;
				itemDic[uButton_AddresseeGuide] = false;
				itemDic[uButton_CustomerClaimConfirmation] = false;
				itemDic[uButton_AddresseeConfirmation] = false;
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivDate)
				{
					// 修正可能
					case 0:
						break;
					// 修正不可
					case 1:
						itemDic[tDateEdit_SalesDate] = false;
						break;
				}
				// --- ADD 2009/09/08② ---------->>>>>
				itemDic[tNedit_Mileage] = false;
				// --- ADD 2009/09/08② ----------<<<<<
			}
			// 入力モードが「赤伝入力モード」
			else if (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Red)
			{
				itemDic[tEdit_SectionCode] = false;
				itemDic[uButton_SectionGuide] = false;
				itemDic[tNedit_SubSectionCode] = false;
				itemDic[uButton_SubSectionGuide] = false;
				itemDic[tComboEditor_AcptAnOdrStatusDisplay] = false;
				itemDic[tComboEditor_SalesSlipDisplay] = false;
				itemDic[tComboEditor_SalesGoodsCd] = false;
				itemDic[tNedit_CustomerCode] = false;
				itemDic[tEdit_CustomerName] = false;
				itemDic[uButton_CustomerGuide] = false;
				itemDic[tNedit_AddresseeCode] = false;
				itemDic[tEdit_AddresseeName] = false;
				itemDic[uButton_AddresseeGuide] = false;
				itemDic[uButton_CustomerClaimConfirmation] = false;
				itemDic[uButton_AddresseeConfirmation] = false;

				itemDic[this._salesSlipDetailInput] = false;
				this.groupBox17.Enabled = false;
				this._salesSlipDetailInput.Refresh();

				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivDate)
				{
					// 修正可能
					case 0:
						break;
					// 修正不可
					case 1:
						itemDic[tDateEdit_SalesDate] = false;
						break;
				}
				// --- ADD 2009/09/08② ---------->>>>>
				itemDic[tNedit_Mileage] = false;
				// --- ADD 2009/09/08② ----------<<<<<
			}
			else if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp) ||
				(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
				(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp))
			{
				// 「伝票種別」「伝票区分」「商品区分」「拠点」「部門」「得意先」「得意先名称」を入力不可とする
				itemDic[tComboEditor_AcptAnOdrStatusDisplay] = false;
				itemDic[tComboEditor_SalesGoodsCd] = false;
				itemDic[tComboEditor_SalesSlipDisplay] = false;
				itemDic[tEdit_SectionCode] = false;
				itemDic[uButton_SectionGuide] = false;
				itemDic[tNedit_SubSectionCode] = false;
				itemDic[uButton_SubSectionGuide] = false;
				itemDic[tNedit_CustomerCode] = false;
				itemDic[tEdit_CustomerName] = false;
				itemDic[uButton_CustomerGuide] = false;

				if (salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
				{
					switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivDate)
					{
						// 修正可能
						case 0:
							break;
						// 修正不可
						case 1:
							itemDic[tDateEdit_SalesDate] = false;
							break;
					}
				}
			}
			else
			{
				// 売上伝票番号が入力されている場合は「伝票種別」「伝票区分」「商品区分」「拠点」「部門」「得意先」「得意先名称」を入力不可とする
				if (salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
				{
					itemDic[tComboEditor_AcptAnOdrStatusDisplay] = false;
					itemDic[tComboEditor_SalesGoodsCd] = false;
					itemDic[tComboEditor_SalesSlipDisplay] = false;
					itemDic[tEdit_SectionCode] = false;
					itemDic[uButton_SectionGuide] = false;
					itemDic[tNedit_SubSectionCode] = false;
					itemDic[uButton_SubSectionGuide] = false;
					itemDic[tNedit_CustomerCode] = false;
					itemDic[tEdit_CustomerName] = false;
					itemDic[uButton_CustomerGuide] = false;
				}

				if (salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
				{
					switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivDate)
					{
						// 修正可能
						case 0:
							break;
						// 修正不可
						case 1:
							itemDic[tDateEdit_SalesDate] = false;
							break;
					}
				}
			}

			switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatus)
			{
				// 見積 
				// 単価見積
				case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
				case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
					{
						this.uLabel_SalesDate.Text = "見積日";
						this.tComboEditor_DeliveredGoodsDiv.Visible = false; // 納品区分
						this.uLabel_DeliveredGoodsDiv.Visible = false; // 納品区分ラベル

						itemDic[tNedit_AddresseeCode] = false;
						itemDic[tEdit_AddresseeName] = false;
						itemDic[uButton_AddresseeGuide] = false;
						itemDic[uButton_CustomerClaimConfirmation] = false;
						itemDic[uButton_AddresseeConfirmation] = false;

						itemDic[tEdit_PartySaleSlipNum] = false;
						itemDic[uLabel_PartySaleSlipNum] = false;
						itemDic[uLabel_AddresseeCode] = false;
						break;
					}
				// 売上
				case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
					{
						this.uLabel_SalesDate.Text = "売上日";
						this.tComboEditor_DeliveredGoodsDiv.Visible = true; // 納品区分
						this.uLabel_DeliveredGoodsDiv.Visible = true;       // 納品区分ラベル
						break;
					}
				case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
				case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
					{
						this.uLabel_SalesDate.Text = "売上日";
						this.tComboEditor_DeliveredGoodsDiv.Visible = true; // 納品区分
						this.uLabel_DeliveredGoodsDiv.Visible = true;       // 納品区分ラベル
						itemDic[uButton_CustomerClaimConfirmation] = false;
						break;
					}
			}

			// 車種名称 品番／ＢＬコード検索の切替に連動
			if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
			{
				itemDic[this.tEdit_ModelFullName] = false;                    // 車種名称
			}

			// 車種コード、車種サブコード
			if (this.tNedit_MakerCode.GetInt() == 0)
			{
				itemDic[this.tNedit_ModelCode] = false;
				itemDic[this.tNedit_ModelSubCode] = false;
			}
			else if (this.tNedit_ModelCode.GetInt() == 0)
			{
				itemDic[this.tNedit_ModelSubCode] = false;
			}

			// カラー・トリム・装備情報
			if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
				 (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
				((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
				 (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
				((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
				 (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
			{
				itemDic[this.uExpandableGroupBox_CarInfo] = true;
			}
			else
			{
				itemDic[this.uExpandableGroupBox_CarInfo] = false;
				this.uExpandableGroupBox_CarInfo.Expanded = false;
			}

			// 売上全体設定マスタ「拠点表示区分」が「2:表示無し」の場合は拠点入力不可
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SectDspDivCd == 2)
			{
				itemDic[this.tEdit_SectionCode] = false;
				itemDic[this.uButton_SectionGuide] = false;
			}

			// 自社情報設定マスタで「部署管理区分」が「0:拠点」の場合は部門非表示
			if (this._salesSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
			{
				this.panel_SubSection.Visible = false;
			}

			// 既存修正時は、売上伝票番号入力不可
			if (salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
			{
				itemDic[this.tNedit_SalesSlipNum] = false;
			}

			this.uLabel_BeforeSalesSlipNum.Visible = true;

			// セキュリティ対応
			if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.Revision))
			{
				itemDic[this.tNedit_SalesSlipNum] = false;
				itemDic[this.uButton_SalesSlipGuide] = false;
			}

			// --- ADD 2009/09/08② ---------->>>>>
			//管理番号でのガイド表示
			SettingCarMngNoGuideVisible(ref itemDic);
			// --- ADD 2009/09/08② ----------<<<<<

            //>>>2010/02/26
            // 問合せ番号
            //if (salesSlip.InquiryNumber != 0)
            //{
            itemDic[this.tNedit_InquiryNumber] = false;
            //}
            //<<<2010/02/26

			//---------------------------------------------
			// 画面項目情報更新
			//---------------------------------------------
			this.SetItemDic(itemDic);
			#endregion

			#region ●ツールバーボタン設定
			// ツールバーボタン有効無効設定処理
			this.SettingToolBarButtonEnabled();
			#endregion

		}

		/// <summary>
		/// 画面項目Dictionary設定処理
		/// </summary>
		/// <param name="itemDic"></param>
		private void SetItemDic(Dictionary<Control, bool> itemDic)
		{
			foreach (Control control in itemDic.Keys)
			{
				control.Enabled = itemDic[control];
			}
		}

		/// <summary>
		/// 画面項目Dictionary作成処理
		/// </summary>
		/// <returns></returns>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private Dictionary<Control, bool> MakeItemDic()
		{
			Dictionary<Control, bool> itemDic = new Dictionary<Control, bool>();

			itemDic.Add(this.panel_Footer, true);                           // フッタ部パネル

			itemDic.Add(this.tEdit_SectionCode, true);                      // 拠点コード
			itemDic.Add(this.uButton_SectionGuide, true);                   // 拠点ガイド
			itemDic.Add(this.tNedit_SubSectionCode, true);                  // 部門コード
			itemDic.Add(this.uButton_SubSectionGuide, true);                // 部門ガイド
			itemDic.Add(this.tNedit_CustomerCode, true);                    // 得意先コード
			itemDic.Add(this.uButton_CustomerGuide, true);                  // 得意先ガイド
			itemDic.Add(this.uButton_CustomerClaimConfirmation, true);      // 請求先確認
			itemDic.Add(this.tEdit_SalesEmployeeCd, true);                  // 担当者コード
			itemDic.Add(this.uButton_EmployeeGuide, true);                  // 担当者ガイド
			itemDic.Add(this.tEdit_FrontEmployeeCd, true);                  // 受注者コード
			itemDic.Add(this.uButton_FrontEmployeeGuide, true);             // 受注者ガイド
			itemDic.Add(this.tEdit_SalesInputCode, true);                   // 発行者コード
			itemDic.Add(this.uButton_SalesInputGuide, true);                // 発行者ガイド
			itemDic.Add(this.tNedit_SalesSlipNum, true);                    // 伝票番号
			itemDic.Add(this.uButton_SalesSlipGuide, true);                 // 伝票番号ガイド
			itemDic.Add(this.tComboEditor_AcptAnOdrStatusDisplay, true);    // 伝票種別
			itemDic.Add(this.tComboEditor_SalesSlipDisplay, true);          // 伝票区分
			itemDic.Add(this.tComboEditor_SalesGoodsCd, true);              // 商品区分
			itemDic.Add(this.uLabel_SalesDate, true);                       // 売上日タイトル
			itemDic.Add(this.tDateEdit_SalesDate, true);                    // 売上日

			itemDic.Add(this.tEdit_CarMngCode, true);                         // 管理番号
			itemDic.Add(this.uButton_CarMngNoGuide, true);                  // 管理番号ガイド
			//itemDic.Add(, true); // 型式指定番号
			//itemDic.Add(, true); // 類別区分番号
			itemDic.Add(this.tEdit_EngineModelNm, true);                    // エンジン型式
			itemDic.Add(this.tEdit_FullModel, true);                        // 型式
			itemDic.Add(this.tNedit_MakerCode, true);                       // カーメーカーコード
			itemDic.Add(this.tNedit_ModelCode, true);                       // 車種コード
			itemDic.Add(this.tNedit_ModelSubCode, true);                    // 車種呼称コード
			itemDic.Add(this.tEdit_ModelFullName, true);                    // 車種名称
			itemDic.Add(this.uButton_ModelFullGuide, true);                 // 車種ガイド
			itemDic.Add(this.tDateEdit_FirstEntryDate, true);               // 年式
			itemDic.Add(this.uLabel_FirstEntryDateRange, true);             // 年式範囲
			itemDic.Add(this.tEdit_ProduceFrameNo, true);                  // 車台番号
			itemDic.Add(this.uLabel_ProduceFrameNoRange, true);             // 車台番号範囲
			itemDic.Add(this.tEdit_ColorNo, true);                          // カラー
			itemDic.Add(this.tEdit_TrimNo, true);                           // トリム
			itemDic.Add(this.ultraGrid_CarSpec, true);                      // 諸元情報
			itemDic.Add(this.uExpandableGroupBox_CarInfo, true);            // カラー・トリム・装備

			itemDic.Add(this.tEdit_SlipNote, true);                         // 備考１
			itemDic.Add(this.uButton_SlipNote, true);                       // 備考１ガイド
			itemDic.Add(this.tEdit_SlipNote2, true);                        // 備考２
			itemDic.Add(this.uButton_SlipNote2, true);                      // 備考２ガイド
			itemDic.Add(this.tEdit_SlipNote3, true);                        // 備考３
			itemDic.Add(this.uButton_SlipNote3, true);                      // 備考３ガイド
			// --- ADD 2009/12/23 ---------->>>>>
			itemDic.Add(this.tNedit_SlipNoteCode, true);                    // 備考１
			itemDic.Add(this.tNedit_SlipNote2Code, true);                   // 備考２
			itemDic.Add(this.tNedit_SlipNote3Code, true);                   // 備考３
			// --- ADD 2009/12/23 ----------<<<<<
			itemDic.Add(this.uLabel_AddresseeCode, true);                   // 納入先タイトル
			itemDic.Add(this.tNedit_AddresseeCode, true);                   // 納入先
			itemDic.Add(this.tEdit_AddresseeName, true);                    // 納入先名称
			itemDic.Add(this.uButton_AddresseeGuide, true);                 // 納入先ガイド
			itemDic.Add(this.tComboEditor_DeliveredGoodsDiv, true);         // 納品区分
			itemDic.Add(this.uButton_AddresseeConfirmation, true);          // 納入先確認
			itemDic.Add(this.uLabel_ReturnReasonTitle, true);               // 返品理由タイトル
			itemDic.Add(this.tEdit_RetGoodsReason, true);                   // 返品理由
			itemDic.Add(this.uButton_RetGoodsReason, true);                 // 返品理由
			itemDic.Add(this.uLabel_PartySaleSlipNum, true);                // 得意先注番タイトル
			itemDic.Add(this.tEdit_PartySaleSlipNum, true);                 // 得意先注番

            //>>>2010/02/26
            itemDic.Add(this.tNedit_InquiryNumber, true);                   // 問合せ番号
            itemDic.Add(this.tComboEditor_AnswerDiv, true);                 // 回答区分
            //<<<2010/02/26

			itemDic.Add(this._salesSlipDetailInput, true);                  // 売上明細
			// --- ADD 2009/09/08② ---------->>>>>
			itemDic.Add(this.tNedit_Mileage, true);                         // 走行距離
			// --- ADD 2009/09/08② ----------<<<<<

            //>>>2010/04/08
            itemDic.Add(this.tEdit_SlipMemo1, true);                         // 伝票メモ１
            itemDic.Add(this.tEdit_SlipMemo2, true);                         // 伝票メモ２
            itemDic.Add(this.tEdit_SlipMemo3, true);                         // 伝票メモ３
            itemDic.Add(this.tEdit_InsideMemo1, true);                       // 社内メモ１
            itemDic.Add(this.tEdit_InsideMemo2, true);                       // 社内メモ２
            itemDic.Add(this.tEdit_InsideMemo3, true);                       // 社内メモ３
            //<<<2010/04/08
            
            return itemDic;
		}

		/// <summary>
		/// 画面表示処理（車両情報）
		/// </summary>
		/// <param name="salesRowNo"></param>
		private void SetDisplayCarInfo(int salesRowNo, CarSearchType searchType)
		{
			SalesInputDataSet.CarInfoRow carInfoRow = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode);

			if (carInfoRow != null) this.SetDisplayCarInfo(carInfoRow, searchType);
		}

		/// <summary>
		/// 画面表示処理（車両情報）
		/// </summary>
		/// <param name="row"></param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void SetDisplayCarInfo(SalesInputDataSet.CarInfoRow row, CarSearchType searchType)
		{
			if (row == null) return;

			try
			{
				this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
				this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
				this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();

				this.tNedit_AcceptAnOrderNo.SetInt(row.AcceptAnOrderNo); // 受注番号

				//if (searchType != CarSearchType.csCategory)
				//{
				//    this.tNedit_ModelDesignationNo.Text = ""; // 型式指定番号
				//    this.tNedit_CategoryNo.Text = "";// 類別区分番号
				//}
				this.tNedit_ModelDesignationNo.SetInt(row.ModelDesignationNo); // 型式指定番号
				this.tNedit_CategoryNo.SetInt(row.CategoryNo);// 類別区分番号

				this.tEdit_CarMngCode.Text = row.CarMngCode;// 管理番号
				this.tEdit_FullModel.Text = row.FullModel;// 型式
				this.tEdit_EngineModelNm.Text = row.EngineModelNm;// エンジン型式
				this.tNedit_MakerCode.SetInt(row.MakerCode);// カーメーカーコード
				this.tNedit_ModelCode.SetInt(row.ModelCode);// 車種コード
				this.tNedit_ModelSubCode.SetInt(row.ModelSubCode);// 車種呼称コード
				// --- UPD m.suzuki 2010/04/02 ---------->>>>>
				//if ((row.ModelCode != 0) || (row.ModelSubCode != 0))
				if ((row.ModelCode != 0) || (row.ModelSubCode != 0) || (string.IsNullOrEmpty(row.MakerFullName)))
				// --- UPD m.suzuki 2010/04/02 ----------<<<<<
				{
					this.tEdit_ModelFullName.Text = row.ModelFullName;// 車種名称
				}
				else
				{
					this.tEdit_ModelFullName.Text = row.MakerFullName;// メーカー名称
				}

				// --- ADD 2009/09/08② ---------->>>>>
				this.tEdit_CarSlipNote.Text = row.CarNote;// 車輌備考
				this.tNedit_Mileage.Text = row.Mileage.ToString("#,###"); //走行距離
				// --- ADD 2009/09/08② ----------<<<<<

				this.tDateEdit_FirstEntryDate.Clear();
				if (row.ProduceTypeOfYearInput != 0) this.tDateEdit_FirstEntryDate.SetLongDate(row.ProduceTypeOfYearInput * 100); // 年式
				string stProduceTypeOfYear = this.GetProduceTypeOfYear(row.StProduceTypeOfYear);
				string edProduceTypeOfYear = this.GetProduceTypeOfYear(row.EdProduceTypeOfYear);
				this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);

                // --- DEL 2013/03/21 ---------->>>>>
                //this.tEdit_ProduceFrameNo.Text = row.FrameNo;                        // 車台番号
                // --- DEL 2013/03/21 ----------<<<<<
                // PMNS:車台番号切り替え
                // --- ADD 2013/03/21 ---------->>>>>
                // 国産/外車区分が外車(2)の場合に、表示をVINコードに切り替える
                // 外車以外の場合は車台番号を表示する
                if (row.DomesticForeignCode == 2)
                {
                    this.uLabel_ProduceFrameNo.Text = "VINｺｰﾄﾞ";
                    this.uLabel_ProduceFrameNo.Size = new Size(80, 24);
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                    this.tEdit_ProduceFrameNo.Size = new Size(120, 24);
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 17;
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = true;
                }
                else
                {
                    this.uLabel_ProduceFrameNo.Text = "車台番号";
                    this.uLabel_ProduceFrameNo.Size = new Size(67, 24);
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                    this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 8;
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = false;
                }
                // 車台番号/VINコードの値をテキストボックスに表示する
                this.tEdit_ProduceFrameNo.Text = row.FrameNo;
                // --- ADD 2013/03/21 ----------<<<<<
				string stProduceFrameNo = (row.StProduceFrameNo != 0) ? string.Format("{0,8:########}", row.StProduceFrameNo) : string.Empty;
				string edProduceFrameNo = (row.EdProduceFrameNo != 0) ? string.Format("{0,8:########}", row.EdProduceFrameNo) : string.Empty;
				this.SettingProduceFrameNoRange(stProduceFrameNo, edProduceFrameNo);

				// カラー情報
				this._carOtherInfoInput.ColorCdInfoDataTable = this._salesSlipInputAcs.GetColorInfo(row.CarRelationGuid);

				// カラー
				PMKEN01010E.ColorCdInfoRow colorInfoRow = this._salesSlipInputAcs.GetSelectColorInfo(row.CarRelationGuid);
				if (colorInfoRow != null)
				{
					this.tEdit_ColorNo.Text = colorInfoRow.ColorCode;
				}
				else
				{
					this.tEdit_ColorNo.Text = string.Empty;
				}

				// トリム情報
				this._carOtherInfoInput.TrimCdInfoDataTable = this._salesSlipInputAcs.GetTrimInfo(row.CarRelationGuid);

				// トリム
				PMKEN01010E.TrimCdInfoRow trimInfoRow = this._salesSlipInputAcs.GetSelectTrimInfo(row.CarRelationGuid);
				if (trimInfoRow != null)
				{
					this.tEdit_TrimNo.Text = trimInfoRow.TrimCode;
				}
				else
				{
					this.tEdit_TrimNo.Text = string.Empty;
				}

				// 諸元情報
				SalesInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable[0];
				this._salesSlipInputAcs.SetCarSpecFromCarInfoRow(ref carSpecRow, row);
				this.SettingCarSpecGridCol(row);

				// 装備情報
				//if (this._salesSlipInputAcs.BeforeCarRelationGuid != row.CarRelationGuid) // 前回行の車両情報と異なった場合のみ再構築
				//{
				this._carOtherInfoInput.CEqpDefDspInfoDataTable = this._salesSlipInputAcs.GetEquipInfo(row.CarRelationGuid);
				this._carOtherInfoInput.SettingEquipGridLayout();
				//}

				// 車両情報共通キー
				this._carOtherInfoInput.CarRelationGuid = row.CarRelationGuid;

				// 前回車両情報共通キー(保持用)
				this._salesSlipInputAcs.BeforeCarRelationGuid = row.CarRelationGuid;

				// 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				double acceptAnOrderNo = (double)this.tNedit_AcceptAnOrderNo.GetValue();
				this._carOtherInfoInput.AcceptAnOrderNo = acceptAnOrderNo;
				// 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				#region Enabled設定

				// 2010/01/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				//this.tNedit_ModelCode.Enabled = true;
				//this.tNedit_ModelSubCode.Enabled = true;
				if (acceptAnOrderNo == 0)
				{
					this.tNedit_ModelCode.Enabled = true;
					this.tNedit_ModelSubCode.Enabled = true;
				}
				// 2010/01/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				// 車種コード、車種サブコード
				if (this.tNedit_MakerCode.GetInt() == 0)
				{
					this.tNedit_ModelCode.Enabled = false;
					this.tNedit_ModelSubCode.Enabled = false;
				}
				else if (this.tNedit_ModelCode.GetInt() == 0)
				{
					this.tNedit_ModelSubCode.Enabled = false;
				}

				// カラー・トリム・装備情報
				if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
					 (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
					((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
					 (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
					((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
					 (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
				{
					this.uExpandableGroupBox_CarInfo.Enabled = true;
				}
				else
				{
					this.uExpandableGroupBox_CarInfo.Enabled = false;
					this.uExpandableGroupBox_CarInfo.Expanded = false;
				}
				#endregion

			}
			finally
			{
				this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
				this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
				this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
			}
		}

		/// <summary>
		/// 画面表示処理（車両情報）
		/// </summary>
		/// <param name="row"></param>
		private void ClearDisplayCarInfo()
		{
			try
			{
				this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
				this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
				this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();

				this.tNedit_AcceptAnOrderNo.Clear(); // 受注番号

				this.tNedit_ModelDesignationNo.Clear(); // 型式指定番号
				this.tNedit_CategoryNo.Clear();// 類別区分番号

				this.tEdit_CarMngCode.Clear();// 管理番号
				this.tEdit_FullModel.Clear();// 型式
				this.tEdit_EngineModelNm.Clear();// エンジン型式
				this.tNedit_MakerCode.Clear();// カーメーカーコード
				this.tNedit_ModelCode.Clear();// 車種コード
				this.tNedit_ModelSubCode.Clear();// 車種呼称コード
				this.tEdit_ModelFullName.Clear();// 車種名称

				this.tDateEdit_FirstEntryDate.Clear(); // 年式
				this.uLabel_FirstEntryDateRange.Text = string.Empty; // 年式範囲

				this.tEdit_ProduceFrameNo.Clear();// 車台番号
				this.uLabel_ProduceFrameNoRange.Text = string.Empty; // 車台番号範囲

				// カラー情報
				if (this._carOtherInfoInput.ColorCdInfoDataTable != null) this._carOtherInfoInput.ColorCdInfoDataTable.Clear();

				this.tEdit_ColorNo.Clear();

				// トリム情報
				if (this._carOtherInfoInput.TrimCdInfoDataTable != null) this._carOtherInfoInput.TrimCdInfoDataTable.Clear();
				this.tEdit_TrimNo.Clear();

				// 諸元情報
				this.ClearCarSpecDataTable();

				// 装備情報
				if (this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) this._carOtherInfoInput.CEqpDefDspInfoDataTable.Clear();
				this._carOtherInfoInput.SettingEquipGridLayout();

				//// 車両情報共通キー
				//this._carOtherInfoInput.CarRelationGuid = Guid.Empty;

				//// 前回車両情報共通キー(保持用)
				//this._salesSlipInputAcs.BeforeCarRelationGuid = Guid.Empty;

			}
			finally
			{
				this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
				this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
				this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
			}
		}

		/// <summary>
		/// 画面表示処理（車両追加情報）
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面を表示処理します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void ClearAddCarInfo()
		{
			int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();

			//管理番号の値をクリアする
			this.tEdit_CarMngCode.Text = string.Empty;
			this._salesSlipInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);

			//車両走行距離
			this.tEdit_CarSlipNote.Text = string.Empty;
			this._salesSlipInputAcs.SettingCarInfoRowFromCarNote(salesRowNo, string.Empty);

			//車輌備考
			this.tNedit_Mileage.SetInt(0);
			this._salesSlipInputAcs.SettingCarInfoRowFromMileage(salesRowNo, 0);
		}

		/// <summary>
		/// 車台番号範囲設定処理
		/// </summary>
		/// <param name="stProduceFrameNo"></param>
		/// <param name="edProduceFrameNo"></param>
		private void SettingProduceFrameNoRange(string stProduceFrameNo, string edProduceFrameNo)
		{
			string retString = string.Empty;
			int maxLength = 8;

			stProduceFrameNo = stProduceFrameNo.PadLeft(maxLength, ' ');
			edProduceFrameNo = edProduceFrameNo.PadLeft(maxLength, ' ');
			if ((string.IsNullOrEmpty(stProduceFrameNo.Trim())) && (string.IsNullOrEmpty(edProduceFrameNo.Trim())))
			{
				this.uLabel_ProduceFrameNoRange.Text = string.Empty;
			}
			else
			{
				this.uLabel_ProduceFrameNoRange.Text = stProduceFrameNo + "-" + edProduceFrameNo;
			}
		}

		/// <summary>
		/// 生産年式範囲設定処理
		/// </summary>
		/// <param name="stProduceTypeOfYear"></param>
		/// <param name="edProduceTypeOfYear"></param>
		/// <returns></returns>
		private void SettingProduceTypeOfYearRange(string stProduceTypeOfYear, string edProduceTypeOfYear)
		{
			string retString = string.Empty;
			int maxLength = 7;

			stProduceTypeOfYear = stProduceTypeOfYear.PadRight(maxLength, ' ');
			edProduceTypeOfYear = edProduceTypeOfYear.PadRight(maxLength, ' ');
			if ((string.IsNullOrEmpty(stProduceTypeOfYear.Trim())) && (string.IsNullOrEmpty(edProduceTypeOfYear.Trim())))
			{
				this.uLabel_FirstEntryDateRange.Text = string.Empty;
			}
			else
			{
				this.uLabel_FirstEntryDateRange.Text = stProduceTypeOfYear + "-" + edProduceTypeOfYear;
			}
		}

		/// <summary>
		/// 生産年式取得処理(和歴／西暦)
		/// </summary>
		/// <param name="StProduceTypeOfYear"></param>
		/// <param name="EdProduceTypeOfYear"></param>
		private string GetProduceTypeOfYear(DateTime produceTypeOfYear)
		{
			string retYear = string.Empty;
			if (produceTypeOfYear != DateTime.MinValue)
			{
				if (this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1 == 0)
				{
					// 0:西暦
					int iyy = produceTypeOfYear.Year;
					int imm = produceTypeOfYear.Month;
					retYear = (produceTypeOfYear != DateTime.MinValue) ? string.Format(@"{0:0000}{1:\.00}", iyy, imm) : string.Empty;
				}
				else
				{
					// 1:和歴
					System.Globalization.DateTimeFormatInfo FormatInfo = null;
					System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
					System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
					culture.DateTimeFormat.Calendar = calendar;
					FormatInfo = culture.DateTimeFormat;
					FormatInfo.Calendar = calendar;

					retYear = produceTypeOfYear.ToString("gyy/MM/dd", culture);

					int Era = FormatInfo.Calendar.GetEra(produceTypeOfYear);
					string eraString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
					string eraName = string.Empty;
					string tempRetYear = string.Empty;
					tempRetYear = retYear.Substring(2, retYear.Length - 2);
					for (int eraCounter = 0; eraCounter < eraString.Length; eraCounter++)
					{
						if (FormatInfo.GetEra(eraString[eraCounter].ToString()) == Era)
						{
							eraName = eraString[eraCounter].ToString();
							break;
						}
					}
					tempRetYear = eraName + tempRetYear;
					retYear = tempRetYear.Remove(tempRetYear.Length - 3);
					retYear = retYear.Replace('/', '.');
				}
			}
			return retYear;
		}

		/// <summary>
		/// 画面表示処理（売上金額合計情報）
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void SetDisplayTotalPriceInfo(SalesSlip salesSlip)
		{
			if (salesSlip == null) return;

			int totalAmountDispWayCd = salesSlip.TotalAmountDispWayCd;
			int sign = (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
			long totalPrice = 0;

			switch ((SalesSlipInputAcs.SalesGoodsCd)salesSlip.SalesGoodsCd)
			{
				case SalesSlipInputAcs.SalesGoodsCd.Goods:
					if (totalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
					{
						// 総額表示しない
						switch (salesSlip.ConsTaxLayMethod)
						{
							case 0: // 伝票転嫁
							case 1: // 明細転嫁
								// 売上金額
								this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc * sign).ToString("N0");

								this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc * sign).ToString("N0"); // ADD 2009/09/08②

								// 消費税
								this.uLabel_SalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax * sign).ToString("N0");

								this.uLabel_AddSalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax * sign).ToString("N0");// ADD 2009/09/08②

								// 総合計
								totalPrice = salesSlip.SalesTotalTaxInc * sign;
								this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");

								this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
								break;
							case 2: // 請求親
							case 3: // 請求子
							case 9: // 非課税
								// 売上金額
								this.uLabel_SalesPriceTotal.Text = ((salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
																	 salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre) * sign).ToString("N0");

								// --- ADD 2009/09/08② ---------->>>>>
								this.uLabel_AddSalesPriceTotal.Text = ((salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
									 salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre) * sign).ToString("N0");
								// --- ADD 2009/09/08② ----------<<<<<

								// 消費税
								this.uLabel_SalesPriceConsTaxTotal.Text = ((salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu) * sign).ToString("N0");

								// --- ADD 2009/09/08② ---------->>>>>
								this.uLabel_AddSalesPriceConsTaxTotal.Text = ((salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu) * sign).ToString("N0");
								// --- ADD 2009/09/08② ----------<<<<<

								// 総合計
								totalPrice = ((salesSlip.ItdedSalesInTax + salesSlip.ItdedSalesOutTax + salesSlip.SalSubttlSubToTaxFre +
											   salesSlip.ItdedSalesDisOutTax + salesSlip.ItdedSalesDisInTax + salesSlip.ItdedSalesDisTaxFre +
											   salesSlip.SalAmntConsTaxInclu + salesSlip.SalesDisTtlTaxInclu) * sign);
								this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");

								this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
								break;
						}

						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost * sign).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost * sign).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc * sign;

						// 粗利額(常に税抜き)
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost * sign).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost * sign).ToString("N0");// ADD 2009/09/08②

						// 粗利率(常に税抜きで算出)
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost * sign), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");

						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②
					}
					else
					{
						// 総額表示する
						// 売上金額
						this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc * sign).ToString("N0");

						this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc * sign).ToString("N0"); // ADD 2009/09/08②

						// 消費税
						this.uLabel_SalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax * sign).ToString("N0") + ")";

						this.uLabel_AddSalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax * sign).ToString("N0") + ")"; // ADD 2009/09/08②

						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost * sign).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost * sign).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc * sign;

						// 粗利額(常に税抜き)
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost * sign).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost * sign).ToString("N0");// ADD 2009/09/08②

						// 粗利率(常に税抜きで算出)
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost * sign), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");
						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

						// 総合計
						totalPrice = salesSlip.SalesTotalTaxInc * sign;
						this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");

						this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
					}
					break;
				case SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust:
				case SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust:
					if (totalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
					{
						// 総額表示しない
						// 売上金額
						this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc).ToString("N0");

						this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc).ToString("N0");// ADD 2009/09/08②

						// 消費税
						this.uLabel_SalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax).ToString("N0");

						this.uLabel_AddSalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax).ToString("N0");// ADD 2009/09/08②


						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc;

						// 粗利額(常に税抜き)
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						// 粗利率(常に税抜きで算出)
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");
						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

						// 総合計
						totalPrice = salesSlip.SalesTotalTaxInc * sign;
						this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");

						this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
					}
					else
					{
						// 総額表示する
						// 売上金額
						this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc).ToString("N0");

						this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc).ToString("N0"); // ADD 2009/09/08②

						// 消費税
						this.uLabel_SalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax).ToString("N0") + ")";

						this.uLabel_AddSalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax).ToString("N0") + ")";// ADD 2009/09/08②

						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc;

						// 粗利額(常に税抜き)
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						// 粗利率(常に税抜きで算出)
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");
						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

						// 総合計
						totalPrice = salesSlip.SalesTotalTaxInc * sign;
						this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");
						this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
					}
					break;
				case SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust:
				case SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust:
					if (totalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
					{
						// 総額表示しない
						// 売上金額
						this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc).ToString("N0");

						this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxExc).ToString("N0");// ADD 2009/09/08②

						// 消費税
						this.uLabel_SalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax).ToString("N0");

						this.uLabel_AddSalesPriceConsTaxTotal.Text = (salesSlip.SalesSubtotalTax).ToString("N0");// ADD 2009/09/08②

						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc;

						// 粗利額
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						// 粗利率
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");
						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

						// 総合計
						totalPrice = salesSlip.SalesTotalTaxInc * sign;
						this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");
						this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
					}
					else
					{
						// 総額表示する
						// 売上金額
						this.uLabel_SalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc).ToString("N0");

						this.uLabel_AddSalesPriceTotal.Text = (salesSlip.SalesTotalTaxInc).ToString("N0");// ADD 2009/09/08②

						// 消費税
						this.uLabel_SalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax).ToString("N0") + ")";

						this.uLabel_AddSalesPriceConsTaxTotal.Text = "内(" + (salesSlip.SalesSubtotalTax).ToString("N0") + ")";// ADD 2009/09/08②

						// 原価金額
						uLabel_TotalCost.Text = (salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalCost.Text = (salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						long salesTotal = salesSlip.SalesTotalTaxExc;

						// 粗利額
						uLabel_TotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");

						uLabel_AddTotalGrossProfit.Text = (salesTotal - salesSlip.TotalCost).ToString("N0");// ADD 2009/09/08②

						// 粗利率
						double totalGrossProfitRate;
						this._salesSlipInputAcs.GetRate((salesTotal - salesSlip.TotalCost), salesTotal, out totalGrossProfitRate);
						uLabel_TotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");
						uLabel_AddTotalGrossProfitRate.Text = (totalGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

						// 総合計
						totalPrice = salesSlip.SalesTotalTaxInc * sign;
						this.uLabel_TotalPrice.Text = totalPrice.ToString("N0");
						this.uLabel_AddTotalPrice.Text = totalPrice.ToString("N0");// ADD 2009/09/08②
					}
					break;
			}
		}

		/// <summary>
		/// 画面表示処理（明細情報）
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void SetDisplayDetailInfo(SalesInputDataSet.SalesDetailRow row)
		{
			if (row == null) return;

			SalesInputDataSet.CarInfoRow carInfoRow = this._salesSlipInputAcs.GetCarInfoRow(row.SalesRowNo, SalesSlipInputAcs.GetCarInfoMode.CarInfoChangeMode);

			// 車両データ既存更新の場合、車両項目無効
			double acceptAnOrderNo = (double)this.tNedit_AcceptAnOrderNo.GetValue();
			if (acceptAnOrderNo != 0)
			{
				// --- UPD 2009/10/19 ---------->>>>>
				//this.panel_CarInfo.Enabled = false;
				this.tEdit_ProduceFrameNo.Enabled = false;
				this.tDateEdit_FirstEntryDate.Enabled = false;
				this.uButton_ChangeSearchCarMode.Enabled = false;
				this.panel_CarMngNo.Enabled = false;
				this.uLabel_FirstEntryDateRange.Enabled = false;
				this.tEdit_FullModel.Enabled = false;
				this.tEdit_EngineModelNm.Enabled = false;
				this.tNedit_CategoryNo.Enabled = false;
				this.tNedit_ModelDesignationNo.Enabled = false;
				this.uLabel_EngineModelNm.Enabled = false;
				this.tNedit_ModelSubCode.Enabled = false;
				this.tNedit_ModelCode.Enabled = false;
				this.tNedit_MakerCode.Enabled = false;
				this.tEdit_TrimNo.Enabled = false;
				this.tEdit_ColorNo.Enabled = false;
				this.tEdit_ModelFullName.Enabled = false;
				this.uButton_ModelFullGuide.Enabled = false;
				// --- UPD 2009/10/19 ----------<<<<<
			}
			else
			{
				// 商品以外は車両項目無効
				switch ((SalesSlipInputAcs.SalesGoodsCd)this._salesSlipInputAcs.SalesSlip.SalesGoodsCd)
				{
					case SalesSlipInputAcs.SalesGoodsCd.Goods:
						this.panel_CarInfo.Enabled = true;
						break;
					case SalesSlipInputAcs.SalesGoodsCd.NonGoods:
					case SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust:
					case SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust:
					case SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust:
					case SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust:
						// --- UPD 2009/10/19 ---------->>>>>
						//this.panel_CarInfo.Enabled = false;
						this.tEdit_ProduceFrameNo.Enabled = false;
						this.tDateEdit_FirstEntryDate.Enabled = false;
						this.uButton_ChangeSearchCarMode.Enabled = false;
						this.panel_CarMngNo.Enabled = false;
						this.uLabel_FirstEntryDateRange.Enabled = false;
						this.tEdit_FullModel.Enabled = false;
						this.tEdit_EngineModelNm.Enabled = false;
						this.tNedit_CategoryNo.Enabled = false;
						this.tNedit_ModelDesignationNo.Enabled = false;
						this.uLabel_EngineModelNm.Enabled = false;
						this.tNedit_ModelSubCode.Enabled = false;
						this.tNedit_ModelCode.Enabled = false;
						this.tNedit_MakerCode.Enabled = false;
						this.tEdit_TrimNo.Enabled = false;
						this.tEdit_ColorNo.Enabled = false;
						this.tEdit_ModelFullName.Enabled = false;
						this.uButton_ModelFullGuide.Enabled = false;
						// --- UPD 2009/10/19 ----------<<<<<
						break;
				}
			}

			//-----------------------------------------
			// 明細粗利率
			//-----------------------------------------
			this.uLabel_DetailGrossProfitRate.Text = (row.DetailGrossProfitRate / 100).ToString("P");

			this.uLabel_AddDetailGrossProfitRate.Text = (row.DetailGrossProfitRate / 100).ToString("P");// ADD 2009/09/08②

		}

		/// <summary>
		/// 得意先情報画面格納処理
		/// </summary>
		/// <param name="customerCode"></param>
		private void SetDisplayCustomerInfo(int customerCode)
		{
			CustomerInfo customerInfo = null;
			if (customerCode != 0)
			{
				SalesSlipInputInitDataAcs.LogWrite("▼得意先マスタＲｅａｄ開始");
				int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, false, out customerInfo);
				SalesSlipInputInitDataAcs.LogWrite("▲得意先マスタＲｅａｄ終了");
			}
			this.SetDisplayCustomerInfo(customerInfo);
		}

		/// <summary>
		/// 得意先情報画面格納処理
		/// </summary>
		/// <param name="customerInfo"></param>
		private void SetDisplayCustomerInfo(CustomerInfo customerInfo)
		{
			if (customerInfo != null)
			{
				// 得意先名称
				if ((!customerInfo.IsCustomer) || (customerInfo.AccRecDivCd != 0)) // 0:現金 1:売掛
				{
					this.tEdit_CustomerName.Enabled = false;
				}
				else
				{
					this.tEdit_CustomerName.Enabled = true;
				}

				// 締日
				uLabel_TotalDay.Text = customerInfo.TotalDay.ToString("N0");

				// 集金月日
				uLabel_CollectMoney.Text = customerInfo.CollectMoneyName + customerInfo.CollectMoneyDay.ToString("N0");
			}
			else
			{
				// 得意先名称
				this.tEdit_CustomerName.Enabled = false;

				// 締日
				uLabel_TotalDay.Text = string.Empty;

				// 集金月日
				uLabel_CollectMoney.Text = string.Empty;
			}
		}

		/// <summary>
		/// 伝票種別コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		private void SetItemtAcptAnOdrStatus(int acptAnOdrStatus, int inputMode)
		{
			this.SetItemtAcptAnOdrStatus(acptAnOdrStatus, inputMode, true);
		}

		/// <summary>
		/// 伝票種別コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		private void SetItemtAcptAnOdrStatus(int acptAnOdrStatus, int inputMode, bool formatFlg)
		{
			//----------------------------------------------
			// 見積計上
			//----------------------------------------------
			if (inputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp)
			{
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Clear();
				Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
				item0.Tag = 1;
				item0.DataValue = 30;
				item0.DisplayText = "売上";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item0);
				Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
				item1.Tag = 2;
				item1.DataValue = 40;
				item1.DisplayText = "貸出";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item1);
				if (formatFlg == true) this.tComboEditor_AcptAnOdrStatusDisplay.Value = 30;
				else this.tComboEditor_AcptAnOdrStatusDisplay.Value = acptAnOdrStatus;
			}
			//----------------------------------------------
			// 受注計上
			//----------------------------------------------
			else if (inputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp)
			{
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Clear();
				Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
				item0.Tag = 1;
				item0.DataValue = 30;
				item0.DisplayText = "売上";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item0);
				Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
				item1.Tag = 2;
				item1.DataValue = 40;
				item1.DisplayText = "貸出";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item1);
				if (formatFlg == true) this.tComboEditor_AcptAnOdrStatusDisplay.Value = 30;
				else this.tComboEditor_AcptAnOdrStatusDisplay.Value = acptAnOdrStatus;
			}
			//----------------------------------------------
			// 出荷計上
			//----------------------------------------------
			else if (inputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp)
			{
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Clear();
				Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
				item0.Tag = 1;
				item0.DataValue = 30;
				item0.DisplayText = "売上";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item0);
				if (formatFlg == true) this.tComboEditor_AcptAnOdrStatusDisplay.Value = 30;
				else this.tComboEditor_AcptAnOdrStatusDisplay.Value = acptAnOdrStatus;
			}
			else
			{
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Clear();
				Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
				item0.Tag = 1;
				item0.DataValue = 30;
				item0.DisplayText = "売上";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item0);
				Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
				item1.Tag = 2;
				item1.DataValue = 40;
				item1.DisplayText = "貸出";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item1);
				Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
				item2.Tag = 3;
				item2.DataValue = 10;
				item2.DisplayText = "見積";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item2);
				Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
				item3.Tag = 4;
				item3.DataValue = 15;
				item3.DisplayText = "単価見積";
				this.tComboEditor_AcptAnOdrStatusDisplay.Items.Add(item3);
				if (formatFlg == true) this.tComboEditor_AcptAnOdrStatusDisplay.Value = 30;
				else this.tComboEditor_AcptAnOdrStatusDisplay.Value = acptAnOdrStatus;
			}
		}

		/// <summary>
		/// 商品区分コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		private void SetItemtSalesGoodsCd(int acptAnOdrStatus)
		{
			this.SetItemtSalesGoodsCd(acptAnOdrStatus, true);
		}

		/// <summary>
		/// 商品区分コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		private void SetItemtSalesGoodsCd(int acptAnOdrStatus, bool formatFlg)
		{
			switch ((SalesSlipInputAcs.AcptAnOdrStatusState)acptAnOdrStatus)
			{
				case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate: // 10:見積
				case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate: // 15:単価見積
					{
						this.tComboEditor_SalesGoodsCd.Items.Clear();

						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 1;
						item0.DataValue = 0;
						item0.DisplayText = "商品";
						this.tComboEditor_SalesGoodsCd.Items.Add(item0);

						if (formatFlg == true) this.tComboEditor_SalesGoodsCd.Value = 0;

						break;
					}
				case SalesSlipInputAcs.AcptAnOdrStatusState.Sales: // 30:売上
					{
						this.tComboEditor_SalesGoodsCd.Items.Clear();

						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 1;
						item0.DataValue = 0;
						item0.DisplayText = "商品";
						this.tComboEditor_SalesGoodsCd.Items.Add(item0);

						Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
						item2.Tag = 2;
						item2.DataValue = 2;
						item2.DisplayText = "消費税調整";
						this.tComboEditor_SalesGoodsCd.Items.Add(item2);

						Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
						item3.Tag = 3;
						item3.DataValue = 3;
						item3.DisplayText = "残高調整";
						this.tComboEditor_SalesGoodsCd.Items.Add(item3);

						Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
						item4.Tag = 4;
						item4.DataValue = 4;
						item4.DisplayText = "売掛消費税調整";
						this.tComboEditor_SalesGoodsCd.Items.Add(item4);

						Infragistics.Win.ValueListItem item5 = new Infragistics.Win.ValueListItem();
						item5.Tag = 5;
						item5.DataValue = 5;
						item5.DisplayText = "売掛残高調整";
						this.tComboEditor_SalesGoodsCd.Items.Add(item5);

						if (formatFlg == true) this.tComboEditor_SalesGoodsCd.Value = 0;

						break;
					}
				case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment: // 40:出荷
					{
						this.tComboEditor_SalesGoodsCd.Items.Clear();

						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 1;
						item0.DataValue = 0;
						item0.DisplayText = "商品";
						this.tComboEditor_SalesGoodsCd.Items.Add(item0);

						if (formatFlg == true) this.tComboEditor_SalesGoodsCd.Value = 0;

						break;
					}
			}
		}

		/// <summary>
		/// 伝票区分コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="acptAnOdrStatus"></param>
		private void SetItemtSalesSlipCd(ref SalesSlip salesSlip, int acptAnOdrStatus)
		{
			this.SetItemtSalesSlipCd(ref salesSlip, acptAnOdrStatus, true);
		}

		/// <summary>
		/// 伝票区分コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="acptAnOdrStatus"></param>
		/// <param name="formatFlg"></param>
		private void SetItemtSalesSlipCd(ref SalesSlip salesSlip, int acptAnOdrStatus, bool formatFlg)
		{
			switch ((SalesSlipInputAcs.AcptAnOdrStatusState)acptAnOdrStatus)
			{
				case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate: // 10:見積
				case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate: // 15:単価見積
					{
						this.tComboEditor_SalesSlipDisplay.Items.Clear();

						if (salesSlip.AccRecDivCd != 0)
						{
							Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
							item0.Tag = 1;
							item0.DataValue = 10;
							item0.DisplayText = "掛売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item0);
						}
						else
						{
							Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
							item2.Tag = 1;
							item2.DataValue = 30;
							item2.DisplayText = "現金売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item2);
						}
						if ((formatFlg == true) || (this._salesSlipInputAcs.SalesSlip.AccRecDivCd != salesSlip.AccRecDivCd))
						{
							this.tComboEditor_SalesSlipDisplay.SelectedIndex = 0;
							if (salesSlip.AccRecDivCd != 0)
							{
								salesSlip.SalesSlipDisplay = 10;
							}
							else
							{
								salesSlip.SalesSlipDisplay = 30;
							}
							SalesSlipInputAcs.SetSlipCdAndAccRecDivCdFromDisplay(ref salesSlip);
						}

						break;
					}
				case SalesSlipInputAcs.AcptAnOdrStatusState.Sales: // 30:売上
					{
						this.tComboEditor_SalesSlipDisplay.Items.Clear();

						if (salesSlip.AccRecDivCd != 0)
						{
							Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
							item0.Tag = 1;
							item0.DataValue = 10;
							item0.DisplayText = "掛売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item0);

							Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
							item1.Tag = 2;
							item1.DataValue = 20;
							item1.DisplayText = "掛返品";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item1);
						}
						else
						{
							Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
							item2.Tag = 1;
							item2.DataValue = 30;
							item2.DisplayText = "現金売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item2);

							Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
							item3.Tag = 2;
							item3.DataValue = 40;
							item3.DisplayText = "現金返品";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item3);
						}
						if ((formatFlg == true) || (this._salesSlipInputAcs.SalesSlip.AccRecDivCd != salesSlip.AccRecDivCd))
						{
							this.tComboEditor_SalesSlipDisplay.SelectedIndex = 0;
							if (salesSlip.AccRecDivCd != 0)
							{
								salesSlip.SalesSlipDisplay = 10;
							}
							else
							{
								salesSlip.SalesSlipDisplay = 30;
							}
							SalesSlipInputAcs.SetSlipCdAndAccRecDivCdFromDisplay(ref salesSlip);
						}

						break;
					}
				case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment: // 40:出荷
					{
						this.tComboEditor_SalesSlipDisplay.Items.Clear();

						if (salesSlip.AccRecDivCd != 0)
						{
							Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
							item0.Tag = 1;
							item0.DataValue = 10;
							item0.DisplayText = "掛売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item0);

							Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
							item1.Tag = 2;
							item1.DataValue = 20;
							item1.DisplayText = "掛返品";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item1);
						}
						else
						{
							Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
							item2.Tag = 1;
							item2.DataValue = 30;
							item2.DisplayText = "現金売上";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item2);

							Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
							item3.Tag = 2;
							item3.DataValue = 40;
							item3.DisplayText = "現金返品";
							this.tComboEditor_SalesSlipDisplay.Items.Add(item3);
						}
						if ((formatFlg == true) || (this._salesSlipInputAcs.SalesSlip.AccRecDivCd != salesSlip.AccRecDivCd))
						{
							this.tComboEditor_SalesSlipDisplay.SelectedIndex = 0;
							if (salesSlip.AccRecDivCd != 0)
							{
								salesSlip.SalesSlipDisplay = 10;
							}
							else
							{
								salesSlip.SalesSlipDisplay = 30;
							}
							SalesSlipInputAcs.SetSlipCdAndAccRecDivCdFromDisplay(ref salesSlip);
						}

						break;
					}
			}
		}

		/// <summary>
		/// グリッド最上位行キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SalesSlipDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
		{
			// 型式、得意先コード、担当者コード移動
			if (this.tEdit_FullModel.Enabled == true)
			{
				this.tEdit_FullModel.Focus();
				this.ActiveControl = this.tEdit_FullModel;
			}
			else if (this.tNedit_CustomerCode.Enabled == true)
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;
			}
			else if (this.tEdit_SalesEmployeeCd.Enabled == true)
			{
				this.tEdit_SalesEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_SalesEmployeeCd;
			}
			else
			{
				this._salesSlipDetailInput.uGrid_Details.Focus();
				this.ActiveControl = this._salesSlipDetailInput.uGrid_Details;
			}

			// 計上ボタンツール有効無効設定処理
			this.SettingAddUpButtonToolEnabled(this.ActiveControl);

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.ActiveControl);

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// グリッド最下層行キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		/// <br>Update Note: 2010/02/02 張凱 redmine#2760対応</br>
		private void SalesSlipDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
		{
			// 備考１へ移動
			// --- UPD 2009/12/23 ---------->>>>>
			//this.tEdit_SlipNote.Focus();
			//this.ActiveControl = this.tEdit_SlipNote;

			// --- UPD 2010/02/02 ---------->>>>>
			//this.tNedit_SlipNoteCode.Focus();
			//this.ActiveControl = this.tNedit_SlipNoteCode;
            //>>>2010/04/08
            //GetFooterFirstControl().Focus();
            //this.ActiveControl = this.GetFooterFirstControl();
            Control firstctrl = GetFooterFirstControl();
            if (firstctrl != null)
            {
                firstctrl.Focus();
                this.ActiveControl = firstctrl;
            }
            //<<<2010/04/08
            // --- UPD 2010/02/02 ----------<<<<<

			// --- UPD 2009/12/23 ----------<<<<<

			// --- DEL 2010/02/02 ---------->>>>>
			// 売上情報タブ選択
			//uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];
			// --- DEL 2010/02/02 ----------<<<<<

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.ActiveControl);

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 売上金額変更後発生イベント処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SalesSlipDetailInput_SalesPriceChanged(object sender, EventArgs e)
		{
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			if (salesSlip == null) return;

			// 売上金額合計設定
			this._salesSlipInputAcs.TotalPriceSetting(ref salesSlip);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理（オーバーロード）
			this.SetDisplay(salesSlip, ctSET_DISPLAY_MODE_TotalPriceInfoOnly);
		}

		/// <summary>
		/// 明細部変更後発生イベント処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SalesSlipDetailInput_DetailChanged(object sender, Int32 salesRowNo)
		{
			// 伝票情報
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			if (salesSlip == null) return;

			// 明細情報
			SalesInputDataSet.SalesDetailRow row = this._salesSlipInputAcs.SalesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._salesSlipInputAcs.SalesSlip.SalesSlipNum.PadLeft(9, '0'), salesRowNo);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理（オーバーロード）
			this.SetDisplay(salesSlip, row);
		}

		/// <summary>
		/// ステータスバーメッセージ表示イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="message">メッセージ</param>
		private void SalesSlipDetailInput_StatusBarMessageSetting(object sender, string message)
		{
			this.uStatusBar_Main.Panels[0].Text = message;
		}

		/// <summary>
		/// フォーカスセッティングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="itemName">項目名称</param>
		private void SalesSlipDetailInput_FocusSetting(object sender, string itemName)
		{
			//-----------------------------------------------------------------------------
			// 得意先コード
			//-----------------------------------------------------------------------------
			if (itemName == MAHNB01010UB.ct_ITEM_NAME_CUSTOMERCODE)
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;

				// ガイドボタンツール有効無効設定処理
				this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

				this._prevControl = this.ActiveControl;
			}
			//-----------------------------------------------------------------------------
			// 管理番号
			//-----------------------------------------------------------------------------
			else if (itemName == MAHNB01010UB.ct_ITEM_NAME_CARMNGCODE)
			{
				if (this.tEdit_CarMngCode.Visible)
				{
					this.tEdit_CarMngCode.Focus(); // 管理番号
					this.ActiveControl = this.tEdit_CarMngCode;
				}
				else
				{
					this.tNedit_ModelDesignationNo.Focus(); // 型式指定番号
					this.ActiveControl = this.tNedit_ModelDesignationNo;
				}

				// ガイドボタンツール有効無効設定処理
				this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);
				this._prevControl = this.ActiveControl;
			}
			//-----------------------------------------------------------------------------
			// 売上明細
			//-----------------------------------------------------------------------------
			else if (itemName == MAHNB01010UB.ct_ITEM_NAME_SALESDETAIL)
			{
				if (this._salesSlipDetailInput.Visible)
				{
					this._salesSlipDetailInput.Focus();
					this.ActiveControl = this._salesSlipDetailInput;
				}
				this._prevControl = this.ActiveControl;
			}
		}

		/// <summary>
		/// ツールバー設定イベント
		/// </summary>
		private void ToolButtonSettingDetail()
		{
			this._guideButton.SharedProps.Enabled = this._salesSlipDetailInput.GuideButtonEnabled;
			this._stockSearchButton.SharedProps.Enabled = this._salesSlipDetailInput.StockSearchButtonEnabled;

			if ((this.ActiveControl == this._salesSlipDetailInput) || (this._salesSlipDetailInput.ContainsFocus))
			{
				this._shipmentAddUpButton.SharedProps.Enabled = this._salesSlipDetailInput.ShipmentReferenceButtonEnabled;
				this._estimateAddUpButton.SharedProps.Enabled = this._salesSlipDetailInput.EstimateReferenceButtonEnabled;
				this._acceptAnOrderAddUpButton.SharedProps.Enabled = this._salesSlipDetailInput.AcceptAnOrderReferenceButtonEnabled;
				this._copySlipButton.SharedProps.Enabled = this._salesSlipDetailInput.SalesReferenceButtonEnabled;
				this._searchChangeButton.SharedProps.Enabled = this._salesSlipDetailInput.SearchChangeButtonEnabled;
			}
		}

		/// <summary>
		/// 売上関連データ変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SalesSlipInputAcs_DataChanged(object sender, EventArgs e)
		{
			// ツールバーボタン有効無効設定処理
			this.SettingToolBarButtonEnabled();
		}

        //>>>2010/02/26
        /// <summary>
        /// メイン画面再描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesSlipInputAcs_RefreshMainDisplay(object sender, EventArgs e)
        {
            this.Refresh();
        }
        //<<<2010/02/26

		/// <summary>
		/// ユーザー設定値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SalesInputConstructionAcs_DataChanged(object sender, EventArgs e)
		{
			this._salesSlipDetailInput.SetEnterMoveTable();
			this._salesSlipDetailInput.SetStartKeyNameList();
			this._salesSlipDetailInput.SetEndKeyNameList();
			//this.SettingToolBarButtonCaption(this.ActiveControl);     // ツールバー情報設定
			this.SettingFocusDictionary();

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細項目情報DATファイルシリアライズ
			this._salesSlipDetailInput.Closing();
		}

		/// <summary>
		/// ガイドボタンツール有効無効設定処理
		/// </summary>
		/// <param name="nextControl">次のコントロール</param>
		private void SettingGuideButtonToolEnabled(Control nextControl)
		{
			if (nextControl == null) return;

			Control targetControl = nextControl;
			if (nextControl.Parent != null)
			{
				if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
						(nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
				{
					targetControl = nextControl.Parent;
				}
			}

			if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
				(this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
			{
				this._guideButton.SharedProps.Enabled = false;
			}
			else
			{
				// 明細部にフォーカスがある時は明細画面に従って設定する
				if (this._salesSlipDetailInput.Contains(targetControl))
				{
					this.ToolButtonSettingDetail();
				}
				else if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
				{
					// --- UPD 2009/09/08② -------------->>>
					if (this.tEdit_CarMngCode.Name.Equals(targetControl.Name))
					{
						if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
						{
							this._guideButton.SharedProps.Enabled = true;
						}
						else
						{
							this._guideButton.SharedProps.Enabled = false;
						}
					}
					else
					{
						this._guideButton.SharedProps.Enabled = true;
					}
					// --- UPD 2009/09/08② --------------<<<
					this._guideButton.SharedProps.Tag = this._guideEnableControlDictionary[targetControl.Name];

					this._salesSlipDetailInput.uButton_Guide.Enabled = false;
				}
				else
				{
					this._guideButton.SharedProps.Enabled = false;
					this._guideButton.SharedProps.Tag = string.Empty;

					if (!this._guideEnableExceptControlDictionary.ContainsKey(targetControl.Name))
					{
						this._salesSlipDetailInput.uButton_Guide.Enabled = false;
					}
				}
			}
		}

		/// <summary>
		/// 計上ボタンツール有効無効設定処理
		/// </summary>
		/// <param name="nextControl">次のコントロール</param>
		private void SettingAddUpButtonToolEnabled(Control nextControl)
		{
			if (nextControl == null) return;

			if ((nextControl.Name == this._salesSlipDetailInput.uGrid_Details.Name) ||
				(nextControl.Name == this._salesSlipDetailInput.Name))
			{

				if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
					(this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
				{
					this._shipmentAddUpButton.SharedProps.Enabled = false;
					this._estimateAddUpButton.SharedProps.Enabled = false;
					this._acceptAnOrderAddUpButton.SharedProps.Enabled = false;
				}
				else
				{
					switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay)
					{
						case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
							this._shipmentAddUpButton.SharedProps.Enabled = false;
							this._estimateAddUpButton.SharedProps.Enabled = false;
							this._acceptAnOrderAddUpButton.SharedProps.Enabled = false;
							break;
						case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
							this._shipmentAddUpButton.SharedProps.Enabled = false;
							this._estimateAddUpButton.SharedProps.Enabled = false;
							this._acceptAnOrderAddUpButton.SharedProps.Enabled = false;
							break;
						case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
							this._shipmentAddUpButton.SharedProps.Enabled = true;
							this._estimateAddUpButton.SharedProps.Enabled = true;
							this._acceptAnOrderAddUpButton.SharedProps.Enabled = true;
							break;
						case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
							this._shipmentAddUpButton.SharedProps.Enabled = false;
							this._estimateAddUpButton.SharedProps.Enabled = true;
							this._acceptAnOrderAddUpButton.SharedProps.Enabled = true;
							break;
					}
				}
			}
			else
			{
				this._shipmentAddUpButton.SharedProps.Enabled = true;
				this._estimateAddUpButton.SharedProps.Enabled = true;
				this._acceptAnOrderAddUpButton.SharedProps.Enabled = true;
			}
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Close(bool isConfirm)
		{
			bool canClose = this.ShowSaveCheckDialog(isConfirm);

			if (canClose)
			{
				this.Close();
			}
		}

        //>>>2010/02/26
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="isShowSaveCompletionDialog"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        private bool Save(bool isShowSaveCompletionDialog, bool isConfirm)
        {
            return this.Save(isShowSaveCompletionDialog, isConfirm, false);
        }
        //<<<2010/02/26

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="isShowSaveCompletionDialog">保存完了ダイアログ表示フラグ</param>
		/// <param name="isConfirm">true:保存確認ダイアログを表示する false:表示しない</param>
		/// <returns>true:保存完了 false:未保存</returns>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		/// <br>Update Note: 2010/02/03 張凱 Redmine#2793の対応</br>
		/// <br>Update Note: 2010/05/04 王海立 修正呼出時に以下の操作を行った場合は、伝票印刷処理を行わずにデータ更新処理のみ行う</br>
        /// <br>UpdateNote : K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
        //>>>2010/02/26
        //// --- UPD 2009/12/23 ---------->>>>>
        ////private bool Save(bool isShowSaveCompletionDialog)
        //private bool Save(bool isShowSaveCompletionDialog, bool isConfirm)
        //// --- UPD 2009/12/23 ----------<<<<<
        private bool Save(bool isShowSaveCompletionDialog, bool isConfirm, bool scmFlg)
        //<<<2010/02/26
        {
			bool isSave = false;

			try
			{
                //>>>2010/04/13
                #region ●保存確認
                if (isConfirm == true)
                {
                    //---------------------------------------------------------------
                    // 保存確認
                    //---------------------------------------------------------------
                    DialogResult dResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dResult == DialogResult.No)
                    {
                        return isSave;
                    }
                }
                #endregion
                //<<<2010/04/13

                // 明細部描画停止
                //this._salesSlipDetailInput.uGrid_Details.BeginUpdate(); // 2010/02/26

				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "", "▼初期処理　開始");
				#region ●初期処理
				//---------------------------------------------------------------
				// 初期処理
				//---------------------------------------------------------------
				if (this._prevControl != null)
				{
					this._changeFocusSaveCancel = true;
					this.ActiveControl = this._prevControl;
					ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
					this.tArrowKeyControl1_ChangeFocus(this, e);
                    // ----- ADD K2011/08/12 --------------------------->>>>>
                    // ----- ADD K2011/12/09 --------------------------->>>>>
                    if (this._enterpriseCode == login_EnterpriseCode)
                    {
                    // ----- ADD K2011/12/09 ---------------------------<<<<<
                        if (this._changeFocusSaveCancel)
                        {
                            return isSave;
                        }
                    }// ADD K2011/12/09
                    // ----- ADD K2011/08/12 ---------------------------<<<<< 
					this._changeFocusSaveCancel = false;
				}
				this.Cursor = Cursors.WaitCursor;
				string retMessage;
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "", "▲初期処理　終了");

				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "CheckCredit", "▼伝票分割前チェック　開始");
				#region ●伝票分割前チェック(与信管理)
				//---------------------------------------------------------------
				// 伝票分割前チェック(与信管理)
				//---------------------------------------------------------------
				if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales)
				{
					if (CheckCredit(this._salesSlipInputAcs.SalesSlip)) return isSave;
				}

                //>>>2010/04/21
                if ((scmFlg) &&
                    (this._salesSlipInputAcs.ExistSalesDetailAcptCntOnly()))
                {
                    // 受注数のみの明細が存在する場合、回答不可
                    DialogResult dResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "受注数のみ入力された明細を含む為、回答処理できません。",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    return isSave;
                }
                //<<<2010/04/21
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "CheckCredit", "▲伝票分割前チェック　終了");

				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▼補正処理　開始");
				#region ●補正処理
				//---------------------------------------------------------------
				// 売上データ補正処理
				//---------------------------------------------------------------
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽売上データ補正　開始");
				// --- ADD 2010/02/03 ---------->>>>>
				//車輌管理区分補正
				int carMngDivCd = this._salesSlipInputAcs.SalesSlip.CarMngDivCd;
				// --- ADD 2010/02/03 ----------<<<<<
				this.ReviseSalesSlip();
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△売上データ補正　終了");

				//---------------------------------------------------------------
				// 仕入明細データ情報設定
				//---------------------------------------------------------------
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽仕入明細データ補正　開始");
				this._salesSlipInputAcs.SettingStockTempFromSalesDetail();
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△仕入明細データ補正　終了");

				//---------------------------------------------------------------
				// 受注明細データ情報設定
				//---------------------------------------------------------------
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽受注明細データ補正　開始");
				this._salesSlipInputAcs.SettingSalesDetailAcptAnOdrFromSalesDetail();
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△受注明細データ補正　終了");

				//---------------------------------------------------------------
				// 保存用仕入データ調整処理(品名数量なし明細削除)
				//---------------------------------------------------------------
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽仕入データ不要明細削除補正　開始");
				this._salesSlipInputAcs.AdjustStockSaveData();
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△仕入データ不要明細削除補正　終了");

				//---------------------------------------------------------------
				// UOE発注データ情報設定
				//---------------------------------------------------------------
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽UOE発注データ補正　開始");
				this._salesSlipInputAcs.SettingUOEOrderDtlFromSalesDetail();
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△UOE発注データ補正　終了");

                this._salesSlipInputAcs.SaveDataTable();                                                                    // 明細データテーブル退避 // 2010/02/26

                //>>>2010/02/26
                //---------------------------------------------------------------
                // 保存用車両情報調整処理(全項目初期値明細削除)
                //---------------------------------------------------------------
                SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▽車両情報不要明細削除補正　開始");
                this._salesSlipInputAcs.AdjustCarInfoSaveData();
                SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "△車両情報不要明細削除補正　終了");
                //<<<2010/02/26
                #endregion
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "", "▲補正処理　終了");

				#region ●受注データテーブル分割処理
				//---------------------------------------------------------------
				// 受注データテーブル分割処理(通常受注データと発注受注データを別テーブルへ分割)
				//---------------------------------------------------------------
                //this._salesSlipInputAcs.SaveDataTable();                                                                    // 明細データテーブル退避 // 2010/02/26
                this._salesSlipInputAcs.DivisionAcceptAnOrderDataTable();
				#endregion

				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "GetCurrentSalesDetailList", "▼伝票分割　開始");
				#region ●伝票分割
				//---------------------------------------------------------------
				// 伝票分割
				//---------------------------------------------------------------
				this._salesSlipInputAcs.MakeSalesSlipAcptAnOdr();                                                           // 受注データヘッダ情報作成
				ArrayList salesDataList;                                                                                    // 売上データリスト
				ArrayList acptDataList;                                                                                     // 受注データリスト
				List<SalesSlipInputAcs.StockSyncInfoKey> stockSyncInfoKeyList;                                              // 売仕入同時入力データキーリスト
                //>>>2010/02/26
                //_salesSlipInputAcs.GetCurrentSalesDetailList(out salesDataList, out acptDataList, out stockSyncInfoKeyList);// 売上受注データリスト取得
                _salesSlipInputAcs.GetCurrentSalesDetailList(out salesDataList, out acptDataList, out stockSyncInfoKeyList, scmFlg);// 売上受注データリスト取得
                //<<<2010/02/26
                #endregion
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "GetCurrentSalesDetailList", "▲伝票分割　終了");

				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "CheckSaveData", "▼保存チェック　開始");
				#region ●保存チェック
				//---------------------------------------------------------------
				// 保存データチェック処理
				//---------------------------------------------------------------
				bool check = this.CheckSaveData(salesDataList, acptDataList);
				if (!check)
				{
					this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
					this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
					this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理

					// --- ADD 2010/02/03 ---------->>>>>
					//車輌管理区分戻る
					this._salesSlipInputAcs.SalesSlip.CarMngDivCd = carMngDivCd;
					// --- ADD 2010/02/03 ----------<<<<<
					return isSave;
				}

                //>>>2010/02/26
                //---------------------------------------------------------------
                // 保存データチェック処理
                //---------------------------------------------------------------
                if (scmFlg)
                {
                    check = this.CheckSaveDataScm(salesDataList, acptDataList);
                    if (!check)
                    {
                        this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
                        this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
                        this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理

                        return isSave;
                    }
                }
                //<<<2010/02/26
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "CheckSaveData", "▲保存チェック　終了");

                // --- ADD m.suzuki 2010/05/13 自由検索 ---------->>>>>
                #region ●自由検索部品自動登録
                //---------------------------------------------------------------
                // 自由検索部品自動登録 選択
                //---------------------------------------------------------------
                if (this._salesSlipInputInitDataAcs.Opt_FreeSearch == (int)SalesSlipInputInitDataAcs.Option.ON)
                {
                    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().FrSrchPrtAutoEntDiv == (int)SalesSlipInputAcs.FrSrchPrtAutoEntDiv.Write)
                    {
                        PMJKN01000UA autoEntryFSPartsDialog = new PMJKN01000UA();
                        if (autoEntryFSPartsDialog.AutoEntryCheck())
                        {
                            DialogResult dialogResultFS = autoEntryFSPartsDialog.ShowDialog(this);
                        }
                    }
                }
                #endregion
                // --- ADD m.suzuki 2010/05/13 自由検索 ----------<<<<<
                
                SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UL", "ShowDialog", "▼商品自動登録　開始");
				#region ●商品自動登録
				//---------------------------------------------------------------
				// 商品自動登録
				//---------------------------------------------------------------
				if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AutoEntryGoodsDivCd == (int)SalesSlipInputAcs.AutoEntryGoodsDivCd.Write)
				{
					if (this._salesSlipInputAcs.GetAutoEntryGoodsDataTable())
					{
						MAHNB01010UL autoEntryGoodsDialog = new MAHNB01010UL();
						DialogResult dialogResult = autoEntryGoodsDialog.ShowDialog(this);
					}
				}
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UL", "ShowDialog", "▲商品自動登録　終了");

				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SettingSlipDetailAddInfoForSalesData", "▼伝票明細追加情報設定　開始");
				#region ●伝票明細追加情報
				//---------------------------------------------------------------
				// 伝票明細追加情報
				//---------------------------------------------------------------
				this._salesSlipInputAcs.SettingSlipDetailAddInfoForSalesData(ref salesDataList, ref acptDataList);
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SettingSlipDetailAddInfoForSalesData", "▲伝票明細追加情報設定　終了");

                #region 削除
                //>>>2010/04/13
                //#region ●保存確認
                //if (isConfirm == true) // ADD 2009/12/23
                //{
                //    //---------------------------------------------------------------
                //    // 保存確認
                //    //---------------------------------------------------------------
                //    DialogResult dResult = TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_QUESTION,
                //        this.Name,
                //        "登録してもよろしいですか？",
                //        0,
                //        MessageBoxButtons.YesNo,
                //        MessageBoxDefaultButton.Button1);

                //    if (dResult == DialogResult.No)
                //    {
                //        this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
                //        this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
                //        this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理

                //        // --- ADD 2009/09/08② ---------->>>>>
                //        //追加情報タブ項目Visible設定
                //        SettingAddInfoVisible();
                //        // --- ADD 2009/09/08② ----------<<<<<

                //        return isSave;
                //    }
                //}
                //#endregion
                //<<<2010/04/13
                #endregion

				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SaveDBData", "▼保存処理　開始");
				#region ●保存処理
				//---------------------------------------------------------------
				// 保存処理
				//---------------------------------------------------------------
				// --- ADD 2010/05/04 ---------->>>>>
				if (this._readSlipFlg && MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.RePrint))
				{
					_salesSlipInputAcs.PrintSlipFlag = false;
				}
				// --- ADD 2010/05/04 ----------<<<<<

				this.Cursor = Cursors.WaitCursor;
                //>>>2010/02/26
                //int status = this._salesSlipInputAcs.SaveDBData(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, out retMessage, salesDataList, acptDataList, stockSyncInfoKeyList);
                //int status = this._salesSlipInputAcs.SaveDBData(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, out retMessage, salesDataList, acptDataList, stockSyncInfoKeyList, scmFlg);
                int status = this._salesSlipInputAcs.SaveDBData(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, out retMessage, salesDataList, acptDataList, stockSyncInfoKeyList, scmFlg, _isMakeQRFlg);  // ADD 2010/07/12
                //<<<2010/02/26
                this.Cursor = Cursors.Default;
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "SaveDBData", "▲保存処理　終了");

				// --- ADD 2010/03/01 ---------->>>>>
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "DeleteDBData", "▼伝票削除処理　開始");
				#region ●伝票削除処理
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 削除対象伝票情報リストの取り込処理
					ArrayList salesInfoMsgList;
					ArrayList salesInfoList;
					status = this._salesSlipInputAcs.GetSalesInfoList(out salesInfoMsgList, out salesInfoList);

					if (salesInfoMsgList != null && salesInfoMsgList.Count > 0)
					{
						string message = string.Empty;
						foreach (ArrayList list in salesInfoMsgList)
						{
							SalesSlip salesSlip = list[0] as SalesSlip;

							message += "  " + this._salesSlipInputAcs.GetAcptAnOdrStatusName(salesSlip.AcptAnOdrStatus) + ":" + salesSlip.SalesSlipNum + "\r\n";
						}

						// 削除確認メッセージ表示
						DialogResult dr = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								"以下の伝票に計上していない明細が存在します。\r\n\r\n" +
								message + "\r\n" +
								"計上しない明細は削除されますがよろしいですか？",
								0,
								MessageBoxButtons.YesNo);

						if (dr == DialogResult.Yes)
						{
							// 伝票削除処理
							salesInfoList.AddRange(salesInfoMsgList);
						}
					}

					if (salesInfoList != null && salesInfoList.Count > 0)
					{
						// 伝票削除処理
						status = this._salesSlipInputAcs.DeleteDBData(salesInfoList, out retMessage);
					}
				}
				#endregion
				SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "DeleteDBData", "▲伝票削除処理　終了");
				// --- ADD 2010/03/01 ----------<<<<<

				#region ●保存後処理
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    //>>>2010/02/26
                    if (isShowSaveCompletionDialog)
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                    }

                    //-----------------------------------------------------------------------------
                    // 回答送信処理(SCM)
                    //-----------------------------------------------------------------------------
                    //>>>2010/04/08
                    //// 2010/03/15 >>>
                    ////if (scmFlg) Process.Start("PMSCM01100U.EXE", Parameter + " /A");
                    //if (scmFlg) Process.Start("PMSCM01100U.EXE", Parameter + " /A" + " " + this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus + ":" + this._salesSlipInputAcs.SalesSlip.SalesSlipNum);
                    //// 2010/03/15 <<<
                    if (scmFlg) Process.Start("PMSCM01100U.EXE", Parameter + " /A" + " " + this._salesSlipInputAcs.SalesSlip.InquiryNumber + ":" + this._salesSlipInputAcs.SalesSlip.InqOrdDivCd);
                    //<<<2010/04/08
                    //<<<2010/02/26
	                // zhouzy add 20110919 begin
                	SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "PrintSlip", "●印刷処理　開始");
                    if (_salesSlipInputAcs.PrintSlipFlag == true)
	                {
	                    #region 印刷処理
	                    //------------------------------------------------------
	                    // 伝票印刷処理
	                    //------------------------------------------------------
                        _salesSlipInputAcs.ScmFlg = scmFlg;
                        Thread printSlipThread = new Thread(_salesSlipInputAcs.PrintSlipThread);
	                    SalesSlipInputInitDataAcs.LogWrite("MAHNB01012AA", "SaveDBData", "PrintSlipThread 開始");
                        printSlipThread.Start();

	                    #endregion
	                }
	                else
	                {
	                    _salesSlipInputAcs.PrintSlipFlag = true;
	                }
                	SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "PrintSlip", "○印刷処理　終了");
	                // zhouzy add 20110919 end
                    //>>>2010/04/08
                    if (scmFlg)
                    {
                        this._salesSlipDetailInput.Clear();
                        this._salesSlipInputAcs.CurrentSalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
                        this._salesSlipInputAcs.SalesSlip.SalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
                        this._salesSlipInputAcs.SalesSlip.InputMode = SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly;
                        this._salesSlipInputAcs.RevivalDataTable(true); // 明細データテーブル復活
                        this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
                        this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理
                    }
                    //<<<2010/04/08

                    // 売上入力明細クリア処理
                    //>>>2010/02/26
                    //this._salesSlipDetailInput.Clear();
                    if (!scmFlg) this._salesSlipDetailInput.Clear();
                    //<<<2010/02/26

					//---------------------------------------------------------------
					// 正常処理
					//---------------------------------------------------------------
					this.uLabel_BeforeSalesSlipNum.Text = "前回伝票番号：" + this._salesSlipInputAcs.SalesSlip.SalesSlipNum.ToString().PadLeft(9, '0');

                    //this._salesSlipDetailInput.uGrid_Details.BeginUpdate(); // 2010/02/26

					SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

					// 表示用受注ステータス設定処理
					SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

					// 表示用伝票区分設定処理
					SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

					// 売上データクラス→画面格納処理
					this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

					// 計上時は空白行を削除する(出荷計上 受注計上 見積計上)
					if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
						(this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
						(this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
					{
						this._salesSlipDetailInput.DeleteEmptyRow(true);
					}

                    //this._salesSlipDetailInput.uGrid_Details.EndUpdate(); // 2010/02/26

					// 明細グリッド設定処理
					this._salesSlipDetailInput.SettingGrid();

                    //>>>2010/02/26
                    //if (isShowSaveCompletionDialog)
                    //{
                    //    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    //    dialog.ShowDialog(2);
                    //}
                    //<<<2010/02/26

					if (this._salesInputConstructionAcs.SaveInfoStoreValue == SalesSlipInputConstructionAcs.SaveInfoStore_ON)
					{
						if (this._salesSlipInputAcs.SalesSlip.SalesSlipNum.PadLeft(9, '0') != SalesSlipInputAcs.ctDefaultSalesSlipNum)
						{
							// 売上入力用初期値クラスをシリアライズ
							this._salesSlipInputInitData.EnterpriseCode = this._salesSlipInputAcs.SalesSlip.EnterpriseCode;
							this._salesSlipInputInitData.SectionCode = this._salesSlipInputAcs.SalesSlip.SectionCode;
							this._salesSlipInputInitData.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
						}
						else
						{
							// 売上入力用初期値クラスをシリアライズ
							this._salesSlipInputInitData.EnterpriseCode = this._salesSlipInputAcs.SalesSlipAcptAnOdr.EnterpriseCode;
							this._salesSlipInputInitData.SectionCode = this._salesSlipInputAcs.SalesSlipAcptAnOdr.SectionCode;
							this._salesSlipInputInitData.CustomerCode = this._salesSlipInputAcs.SalesSlipAcptAnOdr.CustomerCode;
						}
						this._salesSlipInputInitData.Serialize();
					}

					// 売上金額計算処理
					this._salesSlipDetailInput.CalculationSalesPrice();

					// 売上金額変更後発生イベント処理
					this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

					// --- ADD 2009/09/08② ---------->>>>>
					//追加情報タブ項目Visible設定
					SettingAddInfoVisible();
					// --- ADD 2009/09/08② ----------<<<<<

					isSave = true;
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
				{
					//---------------------------------------------------------------
					// 重複
					//---------------------------------------------------------------
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
				{
					//---------------------------------------------------------------
					// 別端末更新済み
					//---------------------------------------------------------------
					// 担当者にフォーカスをセット（一時的に）
					this.tEdit_SalesEmployeeCd.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"現在、編集中の売上データは既に更新されています。" + "\r\n" + "\r\n" +
						"最新の情報を取得します。",
						-1,
						MessageBoxButtons.OK);

					// 再読込処理
					this.ReLoad(this._salesSlipInputAcs.SalesSlip.EnterpriseCode, this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus, this._salesSlipInputAcs.SalesSlip.SalesSlipNum);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
				{
					//---------------------------------------------------------------
					// 別端末物理削除済み
					//---------------------------------------------------------------
					// 担当者にフォーカスをセット（一時的に）
					this.tEdit_SalesEmployeeCd.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"現在、編集中の売上データは既に削除されています。",
						-1,
						MessageBoxButtons.OK);

					this.Clear(false, true);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == 999)																// 排他（別端末更新済）
				{
					//---------------------------------------------------------------
					// 別端末更新済み
					//---------------------------------------------------------------
					// 担当者にフォーカスをセット（一時的に）
					this.tEdit_SalesEmployeeCd.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"保存に失敗しました。" + retMessage + "\r\n" + "\r\n" +
						"申し訳ありませんが、再度処理を行ってください。",
						-1,
						MessageBoxButtons.OK);

					this.Clear(false, true);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == 811)
				{
					//---------------------------------------------------------------
					// タイムアウトエラー
					//---------------------------------------------------------------
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。（タイムアウトエラー）" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);
				}
				else if (status == 850)
				{
					//---------------------------------------------------------------
					// 企業ロックタイムアウトエラー
					//---------------------------------------------------------------
                    //>>>2010/06/08
                    //TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_STOPDISP,
                    //    this.Name,
                    //    "保存に失敗しました。" + "\r\n" + "\r\n" +
                    //    "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                    //    "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                    //    "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                    //    status,
                    //    MessageBoxButtons.OK);
					TMsgDisp.Show(
						this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
                        "処理が込み合っているため中断しました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
						status,
						MessageBoxButtons.OK);
                    //<<<2010/06/08

					this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
					this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
					this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理
				}
				else if (status == 851)
				{
					//---------------------------------------------------------------
					// 拠点ロックタイムアウトエラー
					//---------------------------------------------------------------
                    //>>>2010/06/08
                    //TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_STOPDISP,
                    //    this.Name,
                    //    "保存に失敗しました。" + "\r\n" + "\r\n" +
                    //    "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                    //    "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                    //    "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                    //    status,
                    //    MessageBoxButtons.OK);
					TMsgDisp.Show(
						this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
                        "処理が込み合っているため中断しました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
						status,
						MessageBoxButtons.OK);
                    //<<<2010/06/08
					this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
					this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
					this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理
				}
				else if (status == 852)
				{
					//---------------------------------------------------------------
					// 倉庫ロックタイムアウトエラー
					//---------------------------------------------------------------
                    //>>>2010/06/08
                    //TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_STOPDISP,
                    //    this.Name,
                    //    "保存に失敗しました。" + "\r\n" + "\r\n" +
                    //    "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                    //    "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました" + "\r\n" +
                    //    "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n",
                    //    status,
                    //    MessageBoxButtons.OK);
					TMsgDisp.Show(
						this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
                        "処理が込み合っているため中断しました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
						status,
						MessageBoxButtons.OK);
                    //<<<2010/06/08
					this._salesSlipInputAcs.RevivalDataTable(); // 明細データテーブル復活
					this._salesSlipDetailInput.SettingDataTable(this._salesSlipInputAcs.SalesDetailDataTable); // 明細データテーブル設定
					this._salesSlipDetailInput.SettingGrid(); // 明細グリッド設定処理
				}
				else
				{
					//---------------------------------------------------------------
					// その他例外
					//---------------------------------------------------------------
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);
				}
				#endregion
			}
			finally
			{
				this.Cursor = Cursors.Default;
                //this._salesSlipDetailInput.uGrid_Details.EndUpdate(); // 2010/02/26
            }

			if (tEdit_SectionCode.Enabled == true)
			{
				this._prevControl = this.tEdit_SectionCode; // フォーカス位置設定
			}
			else
			{
				this._prevControl = this.tEdit_SalesEmployeeCd; // フォーカス位置設定
			}

			this.SettingAddUpButtonToolEnabled(this._prevControl);

			this.SettingToolBarButtonEnabled();

			// フッタタブ位置セット
			uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];

			return isSave;
		}

		/// <summary>
		/// 売上データ補正処理
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void ReviseSalesSlip()
		{
			DialogResult dialogResult;

			#region 車両管理オプション
			if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
			{
				#region 車両管理区分(0:しない 1:登録(確認) 2:登録(自動) 3:登録無)
				if (this._salesSlipInputAcs.ExistCarInfo())
				{
					switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
					{
						case 0: // しない
							this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
							break;
						case 1: // 登録(確認)
							// --- UPD 2009/09/08② -------------->>>
							if (this._salesSlipInputAcs.ExistCarMngNoInfo())
							{
								dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								"車輌管理マスタに車輌情報を更新します。" + "\r\n" + "\r\n" +
								"よろしいですか？" + "\r\n" + "\r\n" +
								"管理番号＝" + this.tEdit_CarMngCode.Text,// ADD 2009/09/08②
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button1);
								if (dialogResult == DialogResult.Yes)
								{
									this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 1; // する
								}
								else
								{
									// --- DEL 2009/09/08② -------------->>>
									//this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
									// --- DEL 2009/09/08② --------------<<<
									this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 2; // しない
								}
							}
							else
							{
								//新規登録時の処理
								if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal
									&& (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
								{
									dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"車輌管理マスタに車輌情報を登録します。" + "\r\n" + "\r\n" +
												"よろしいですか？" + "\r\n" + "\r\n" +
												"管理番号＝" + this.tEdit_CarMngCode.Text,// ADD 2009/09/08②
										0,
										MessageBoxButtons.YesNo,
										MessageBoxDefaultButton.Button1);
									if (dialogResult == DialogResult.Yes)
									{
										this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 1; // する
									}
									else
									{

										// --- DEL 2009/09/08② -------------->>>
										//this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
										// --- DEL 2009/09/08② --------------<<<<<
										this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 2; // しない
									}
								}
								else
								{
									//修正呼び出し時の登録パターン
									this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 3; // しない
								}
							}
							break;
						case 2: // 登録(自動)
							if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal
									&& (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
							{
								this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 1; // しない
							}
							else
							{
								//修正呼び出し時の登録パターン
								this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 3; // する
							}
							break;

						// --- UPD 2009/09/08② --------------<<<
						case 3: // 登録無
							this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
							break;
					}
				}
				else
				{
					this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
				}
				#endregion
			}
			else
			{
				this._salesSlipInputAcs.SalesSlip.CarMngDivCd = 0; // しない
			}
			#endregion
		}

		/// <summary>
		/// 保存データチェック処理
		/// </summary>
		/// <returns></returns>
		private bool CheckSaveData(ArrayList salesDataList, ArrayList acptDataList)
		{
			string mainMessage;
			List<string> itemNameList = new List<string>();
			List<string> itemList = new List<string>();
			List<int> errorRowNoList;
			bool check;

			SalesSlip salesSlip = new SalesSlip();
			List<SalesDetail> salesDetailList = new List<SalesDetail>();
			SalesInputDataSet.SalesDetailDataTable salesDetailDataTable = new SalesInputDataSet.SalesDetailDataTable();
			SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable = new SalesInputDataSet.SalesDetailAcceptAnOrderDataTable();

			if ((salesDataList.Count == 0) && (acptDataList.Count == 0))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"有効な明細が入力されていません。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return false;
			}

			#region 売上データ
			foreach (ArrayList list in salesDataList)
			{
				foreach (object obj in list)
				{
					if (obj is SalesSlip)
					{
						salesSlip = (SalesSlip)obj;
					}
					else if (obj is List<SalesDetail>)
					{
						salesDetailList = (List<SalesDetail>)obj;
					}
					else if (obj is SalesInputDataSet.SalesDetailDataTable)
					{
						salesDetailDataTable = (SalesInputDataSet.SalesDetailDataTable)obj;
					}
				}

				#region エラーチェック
				//---------------------------------------------------------------
				// エラーチェック
				//---------------------------------------------------------------
				check = this._salesSlipInputAcs.CheckSaveData(out mainMessage, out itemNameList, out itemList, out errorRowNoList, salesSlip, salesDetailDataTable);
				if (!check)
				{
					StringBuilder message = new StringBuilder();
					message.Append(mainMessage);

					if (!check)
					{
						foreach (string s in itemNameList)
						{
							message.Append(s + "\r\n");
						}
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						message.ToString(),
						0,
						MessageBoxButtons.OK);

					string itemName = string.Empty;
					if (itemList.Count > 0)
					{
						itemName = itemList[0].ToString();

						// 指定フォーカス設定処理
						this.SetControlFocus(itemName, (errorRowNoList.Count > 0) ? errorRowNoList[0] : -1, this._salesSlipInputAcs.SalesDetailDataTableSave);
					}

					return false;
				}
				#endregion
			}
			#endregion

			#region 受注データ
			foreach (ArrayList list in acptDataList)
			{
				foreach (object obj in list)
				{
					if (obj is SalesSlip)
					{
						salesSlip = (SalesSlip)obj;
					}
					else if (obj is List<SalesDetail>)
					{
						salesDetailList = (List<SalesDetail>)obj;
					}
					else if (obj is SalesInputDataSet.SalesDetailAcceptAnOrderDataTable)
					{
						salesDetailAcceptAnOrderDataTable = (SalesInputDataSet.SalesDetailAcceptAnOrderDataTable)obj;
					}
				}

				#region エラーチェック
				//---------------------------------------------------------------
				// エラーチェック
				//---------------------------------------------------------------
				check = this._salesSlipInputAcs.CheckSaveDataForAcptAnOdr(out mainMessage, out itemNameList, out itemList, out errorRowNoList, salesSlip, salesDetailAcceptAnOrderDataTable);
				if (!check)
				{
					StringBuilder message = new StringBuilder();
					message.Append(mainMessage);

					if (!check)
					{
						foreach (string s in itemNameList)
						{
							message.Append(s + "\r\n");
						}
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						message.ToString(),
						0,
						MessageBoxButtons.OK);

					string itemName = string.Empty;
					if (itemList.Count > 0)
					{
						itemName = itemList[0].ToString();

						// 指定フォーカス設定処理
						this.SetControlFocus(itemName, (errorRowNoList.Count > 0) ? errorRowNoList[0] : -1, this._salesSlipInputAcs.AcptDetailDataTableSave);
					}

					return false;
				}
				#endregion
			}
			#endregion

			#region 画面入力値チェック
			// ※Copy&Pasteで不正文字の入力が可能な為。
			if (!this.uiSetControl1.CheckMatchingSet(this.tEdit_PartySaleSlipNum))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"得意先注番に不正な文字が入力されています。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				// 指定フォーカス設定処理
				this.SetControlFocus(this.tEdit_PartySaleSlipNum.Name, -1, this._salesSlipInputAcs.SalesDetailDataTableSave);

				return false;
			}
			#endregion

			return true;
		}

        //>>>2010/02/26
        /// <summary>
        /// 保存データチェック処理(SCM)
        /// </summary>
        /// <returns></returns>
        private bool CheckSaveDataScm(ArrayList salesDataList, ArrayList acptDataList)
        {
            string mainMessage;
            List<string> itemNameList = new List<string>();
            List<string> itemList = new List<string>();
            List<int> errorRowNoList;
            bool check;

            SalesSlip salesSlip = new SalesSlip();
            List<SalesDetail> salesDetailList = new List<SalesDetail>();
            SalesInputDataSet.SalesDetailDataTable salesDetailDataTable = new SalesInputDataSet.SalesDetailDataTable();
            SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable = new SalesInputDataSet.SalesDetailAcceptAnOrderDataTable();

            #region 売上データ
            foreach (ArrayList list in salesDataList)
            {
                foreach (object obj in list)
                {
                    if (obj is SalesSlip)
                    {
                        salesSlip = (SalesSlip)obj;
                    }
                    else if (obj is List<SalesDetail>)
                    {
                        salesDetailList = (List<SalesDetail>)obj;
                    }
                    else if (obj is SalesInputDataSet.SalesDetailDataTable)
                    {
                        salesDetailDataTable = (SalesInputDataSet.SalesDetailDataTable)obj;
                    }
                }

                #region エラーチェック
                //---------------------------------------------------------------
                // エラーチェック
                //---------------------------------------------------------------
                check = this._salesSlipInputAcs.CheckSaveDataScm(out mainMessage, out itemNameList, out itemList, out errorRowNoList, salesSlip, salesDetailList, salesDetailDataTable);
                if (!check)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append(mainMessage);

                    if (!check)
                    {
                        foreach (string s in itemNameList)
                        {
                            message.Append(s + "\r\n");
                        }
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    string itemName = string.Empty;
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();

                        // 指定フォーカス設定処理
                        this.SetControlFocus(itemName, (errorRowNoList.Count > 0) ? errorRowNoList[0] : -1, this._salesSlipInputAcs.SalesDetailDataTableSave);
                    }

                    return false;
                }
                #endregion
            }
            #endregion

            //#region 受注データ
            //foreach (ArrayList list in acptDataList)
            //{
            //    foreach (object obj in list)
            //    {
            //        if (obj is SalesSlip)
            //        {
            //            salesSlip = (SalesSlip)obj;
            //        }
            //        else if (obj is List<SalesDetail>)
            //        {
            //            salesDetailList = (List<SalesDetail>)obj;
            //        }
            //        else if (obj is SalesInputDataSet.SalesDetailAcceptAnOrderDataTable)
            //        {
            //            salesDetailAcceptAnOrderDataTable = (SalesInputDataSet.SalesDetailAcceptAnOrderDataTable)obj;
            //        }
            //    }

            //    #region エラーチェック
            //    //---------------------------------------------------------------
            //    // エラーチェック
            //    //---------------------------------------------------------------
            //    check = this._salesSlipInputAcs.CheckSaveDataForAcptAnOdr(out mainMessage, out itemNameList, out itemList, out errorRowNoList, salesSlip, salesDetailAcceptAnOrderDataTable);
            //    if (!check)
            //    {
            //        StringBuilder message = new StringBuilder();
            //        message.Append(mainMessage);

            //        if (!check)
            //        {
            //            foreach (string s in itemNameList)
            //            {
            //                message.Append(s + "\r\n");
            //            }
            //        }

            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //            this.Name,
            //            message.ToString(),
            //            0,
            //            MessageBoxButtons.OK);

            //        string itemName = string.Empty;
            //        if (itemList.Count > 0)
            //        {
            //            itemName = itemList[0].ToString();

            //            // 指定フォーカス設定処理
            //            this.SetControlFocus(itemName, (errorRowNoList.Count > 0) ? errorRowNoList[0] : -1, this._salesSlipInputAcs.AcptDetailDataTableSave);
            //        }

            //        return false;
            //    }
            //    #endregion
            //}
            //#endregion

            //#region 画面入力値チェック
            //// ※Copy&Pasteで不正文字の入力が可能な為。
            //if (!this.uiSetControl1.CheckMatchingSet(this.tEdit_PartySaleSlipNum))
            //{
            //    DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "得意先注番に不正な文字が入力されています。",
            //        0,
            //        MessageBoxButtons.OK,
            //        MessageBoxDefaultButton.Button1);

            //    // 指定フォーカス設定処理
            //    this.SetControlFocus(this.tEdit_PartySaleSlipNum.Name, -1, this._salesSlipInputAcs.SalesDetailDataTableSave);

            //    return false;
            //}
            //#endregion

            return true;
        }
        //<<<2010/02/26

		/// <summary>
		/// 与信額チェック
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <returns>true:処理中止 false:処理続行</returns>
		public bool CheckCredit(SalesSlip salesSlip)
		{
			bool ret = false;
			long creditMoney;
			long totalMoney;
			DialogResult dialogResult;

			int st = this._salesSlipInputAcs.CheckCredit(out creditMoney, out totalMoney, salesSlip);

			switch (st)
			{
				case 0:
					break;
				case 1:
					dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"警告与信額を超えています。   " + "\r\n" +
						"続行してよろしいですか？" + "\r\n" + "\r\n" +
						"警告与信額：" + string.Format("{0:###,##0}", creditMoney) + "\r\n" +
						"比較対象額：" + string.Format("{0:###,##0}", totalMoney),
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);
					if (dialogResult == DialogResult.No)
					{
						ret = true;
					}
					break;
				case 2:
					dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"与信限度額を超えています。   " + "\r\n" +
						"処理を中止します。" + "\r\n" + "\r\n" +
						"与信限度額：" + string.Format("{0:###,##0}", creditMoney) + "\r\n" +
						"比較対象額：" + string.Format("{0:###,##0}", totalMoney),
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					ret = true;
					break;
			}

			return ret;
		}

		/// <summary>
		/// 注釈行チェック
		/// </summary>
		/// <returns></returns>
		private bool CheckOnlyAnnotation()
		{
			if (this._salesSlipInputAcs.ExistSalesDetailExceptAnnotation() != true)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"注釈行のみの売上データが作成されます。　　" + "\r\n" +
					"よろしいですか？\r\n",
					1,
					MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.No)
				{
					return false;
				}

			}
			return true;
		}

		/// <summary>
		/// 実績計上拠点コード変更チェック
		/// </summary>
		/// <param name="beforeSecCode"></param>
		/// <param name="employeeCode"></param>
		/// <returns></returns>
		private bool CheckResultsAddUpSecCd(string beforeSecCode, string employeeCode, out DialogResult dialogResult)
		{
			bool ret = false;
			dialogResult = DialogResult.No;

			// 実績計上拠点チェック
			string afterSecCode = this._salesSlipInputAcs.GetBelongSectionCode(employeeCode);

			if (beforeSecCode != afterSecCode)
			{

				dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"実績計上拠点が変更されます。　　" + "\r\n" +
					"変更してもよろしいですか？",
					1,
					MessageBoxButtons.YesNo);

				ret = true;
			}

			return ret;

		}

		/// <summary>
		/// 伝票印刷が可能かどうかをチェックします。
		/// </summary>
		/// <returns></returns>
		public SalesSlipInputAcs.PrintCheckType CheckPrintData()
		{
			SalesSlipInputAcs.PrintCheckType ret = SalesSlipInputAcs.PrintCheckType.Cancel;

			if (this._salesSlipInputAcs.CheckPrintData() == true)
			{
				ret = SalesSlipInputAcs.PrintCheckType.Print;
			}
			else
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"伝票情報が保存されていません。　　" + "\r\n" +
					"保存してもよろしいですか？",
					1,
					MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					ret = SalesSlipInputAcs.PrintCheckType.SaveAndPrint;
				}
			}

			return ret;
		}

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Retry(bool isConfirm)
		{
			this.Retry(isConfirm, this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay, this._salesSlipInputAcs.SalesSlip.SalesSlipNum);
		}

		/// <summary>
		/// 再読込処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private bool ReLoad(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			bool isSuccess = false;
			SalesSlip baseSalesSlip;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.ReadDBData(enterpriseCode, acptAnOdrStatus, salesSlipNum, out baseSalesSlip);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

				// 売上データ入力モード設定処理
				this.SettingStockSlipInputMode(ref salesSlip);

				// 表示用受注ステータス設定処理
				SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

				// 表示用伝票区分設定処理
				SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);

				// 計上時は空白行を削除する(出荷計上 受注計上 見積計上)
				if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
					(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
					(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
				{
					this._salesSlipDetailInput.DeleteEmptyRow(true);
				}

				// 明細グリッド設定処理
				this._salesSlipDetailInput.SettingGrid();

				if (this._salesSlipDetailInput.Enabled)
				{
					this._salesSlipDetailInput.Focus();
				}
				else
				{
					this._salesSlipDetailInput.Focus();
				}

				isSuccess = true;
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"該当するデータが存在しません。",
					-1,
					MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"売上・出荷データの取得に失敗しました。",
					status,
					MessageBoxButtons.OK);
			}

			return isSuccess;
		}

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void Retry(bool isConfirm, int acptAnOdrStatus, string salesSlipNum)
		{
			if ((isConfirm) && (this._salesSlipInputAcs.IsDataChanged))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"初期状態に戻しますか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}

			// 画面初期化処理
			this.Clear(false, false);

			if (salesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
			{
				SalesSlip baseSalesSlip;

				// データリード処理
				this.Cursor = Cursors.WaitCursor;
				int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, salesSlipNum, out baseSalesSlip);
				this.Cursor = Cursors.Default;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

					// 表示用受注ステータス設定処理
					SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

					// 表示用伝票区分設定処理
					SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

					// 売上データクラス→画面格納処理
					this.SetDisplay(salesSlip);

					// 明細グリッド設定処理
					this._salesSlipDetailInput.SettingGrid();
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"該当する売上データが存在しません。",
						-1,
						MessageBoxButtons.OK);
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"売上データの取得に失敗しました。",
						status,
						MessageBoxButtons.OK);
				}
			}
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepAcptAnOdrStatus">true:受注ステータスを保持する false:保持しない</param>
		/// <returns></returns>
		private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus)
		{
			return this.Clear(isConfirm, keepAcptAnOdrStatus, false);
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepAcptAnOdrStatus">true:受注ステータスを保持する false:保持しない</param>
		/// <param name="keepDate">true:日付を保持する false:保持しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
		private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate)
		{
			//return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false); // 2009/09/10
			//return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false); // 2009/09/10 // DEL 2010/05/21
            //return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false, false); //ADD 2010/05/21 // 2010/02/26
            return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false, false, 0); // 2010/02/26
        }

		// ----- ADD 2010/05/21 ------------>>>>>
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepAcptAnOdrStatus">true:受注ステータスを保持する false:保持しない</param>
		/// <param name="keepDate">true:日付を保持する false:保持しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
		private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepSalesDate)
		{
			//>>>2010/02/26
            //return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false, keepSalesDate);
            return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false, keepSalesDate, 0);
            //<<<2010/02/26
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm"></param>
		/// <param name="keepAcptAnOdrStatus"></param>
		/// <param name="keepDate"></param>
		/// <param name="keepFooterInfo"></param>
		/// <param name="keepCustomer"></param>
		/// <returns></returns>
		private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo, bool keepCustomer)
		{
            //>>>2010/02/26
            ////>>> 2010/05/27
            ////return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, false, false, false);
            //return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, keepFooterInfo, keepCustomer, false);
            ////<<< 2010/05/27
            return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, keepFooterInfo, keepCustomer, false, 0);
            //<<<2010/02/26
		}
		// ----- ADD 2010/05/21 ------------<<<<<

        //>>>2010/02/26
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="keepAcptAnOdrStatus"></param>
        /// <param name="keepDate"></param>
        /// <param name="keepFooterInfo"></param>
        /// <param name="keepCustomer"></param>
        /// <param name="keepSalesDate"></param>
        /// <returns></returns>
        private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo, bool keepCustomer, bool keepSalesDate)
        {
            return this.Clear(isConfirm, keepAcptAnOdrStatus, keepDate, keepFooterInfo, keepCustomer, keepSalesDate, 0);
        }
        //<<<2010/02/26

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepAcptAnOdrStatus">true:受注ステータスを保持する false:保持しない</param>
		/// <param name="keepDate">true:日付を保持する false:保持しない</param>
		/// <param name="keepFooterInfo">true:フッタ情報を保持する false:保持しない</param>
		/// <param name="keepCustomer">true:得意先情報を保持する false:保持しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/11/13 李占川 保守依頼③対応</br>
		/// <br>             担当者、受注者、発行者の初期表示内容の変更</br>
		/// <br>Update Note: 2010/05/04 王海立 修正呼出時に以下の操作を行った場合は、伝票印刷処理を行わずにデータ更新処理のみ行う</br>
		//private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo) // 2009/09/10 DEL
		//private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo, bool keepCustomer) // 2009/09/10 ADD //DEL 2010/05/21
		//private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo, bool keepCustomer, bool keepSalesDate) //ADD 2010/05/21 // 2010/02/26
		private bool Clear(bool isConfirm, bool keepAcptAnOdrStatus, bool keepDate, bool keepFooterInfo, bool keepCustomer, bool keepSalesDate, int customerCode) // 2010/02/26
		{
			try
			{
				if ((isConfirm) && (this._salesSlipInputAcs.IsDataChanged))
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
						"初期状態に戻しますか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult != DialogResult.Yes) return false;
				}

				// 受注ステータスを保持
				SalesSlip svSalesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

				// 受注ステータスを再設定
				if (keepAcptAnOdrStatus)
				{
					// 売上データ初期インスタンス取得処理
					this._salesSlipInputAcs.CreateSalesSlipInitialData(svSalesSlip.AcptAnOdrStatusDisplay, svSalesSlip.AccRecDivCd, this._salesInputConstructionAcs.SalesInputConstruction.StockGoodsCdValue, keepDate, keepFooterInfo);

					this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay = svSalesSlip.AcptAnOdrStatusDisplay; // 受注ステータス

					// 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//this._salesSlipInputAcs.RevivalHeader(svSalesSlip, keepFooterInfo);
					//this._salesSlipInputAcs.RevivalHeader(svSalesSlip, keepFooterInfo, keepCustomer); // DEL 2010/05/21
                    //this._salesSlipInputAcs.RevivalHeader(svSalesSlip, keepFooterInfo, keepCustomer, keepSalesDate); //ADD 2010/05/21 // 2010/02/26
                    this._salesSlipInputAcs.RevivalHeader(svSalesSlip, keepFooterInfo, keepCustomer, keepSalesDate, customerCode); // 2010/02/26
                    // 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				}
				else
				{
					// 売上データ初期インスタンス取得処理
					this._salesSlipInputAcs.CreateSalesSlipInitialData((int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales, (int)SalesSlipInputAcs.AccRecDivCd.AccRec, this._salesInputConstructionAcs.SalesInputConstruction.StockGoodsCdValue, keepDate, keepFooterInfo);

					// 前回使用した値を初期表示する
					SalesSlip tempSalesSlip = this._salesSlipInputAcs.SalesSlip;

                    //>>>2010/02/26
                    ////this.SettingInitData(tempSalesSlip); // 2009/09/10 
                    //this.SettingInitData(tempSalesSlip, false); // 2009/09/10

                    if (customerCode != 0)
                    {
                        this.SettingInitData(tempSalesSlip, customerCode);
                    }
                    else
                    {
                        this.SettingInitData(tempSalesSlip, false);
                    }
                    //<<<2010/02/26

					// 部品検索モード
					this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.BLCodeSearch; // 初期値[部品検索]
					if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
					{
						if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchDivCd == 0)
						{
							this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.BLCodeSearch;
						}
						else
						{
							this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch;
						}
					}

                    // --- DEL m.suzuki 2010/10/28 ---------->>>>>
                    //// 伝票区分コンボエディタアイテム設定処理
                    //this.SetItemtSalesSlipCd(ref tempSalesSlip, tempSalesSlip.AcptAnOdrStatusDisplay, !keepAcptAnOdrStatus);
                    // --- DEL m.suzuki 2010/10/28 ----------<<<<<
				}

				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

				// 伝票番号
				salesSlip.SalesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;

				// 受注ステータス、見積区分セット
				SalesSlipInputAcs.SetAcptAnOdrStatusAndEstimateDivideFromDisplay(ref salesSlip);
				// 受注ステータス(表示用)再セット
				SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

                // --- ADD m.suzuki 2010/10/28 ---------->>>>>
                // 伝票区分コンボエディタアイテム設定処理
                this.SetItemtSalesSlipCd( ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, !keepAcptAnOdrStatus );
                // --- ADD m.suzuki 2010/10/28 ----------<<<<<
			}
			catch (ApplicationException ae)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOP,
					this.Name,
					ae.Message,
					4,
					MessageBoxButtons.OK);

				return false;
			}

			// 各種データクリア処理
			this._salesSlipInputAcs.ClearDataForNew();

			// 売上入力明細クリア処理
			this._salesSlipDetailInput.Clear();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// 車両情報データ→画面
			SalesInputDataSet.CarInfoRow row = this._salesSlipInputAcs.GetCarInfoRow(1, SalesSlipInputAcs.GetCarInfoMode.NewInsertMode);
			this.SetDisplayCarInfo(row, CarSearchType.csNone);

			// 部品検索切替反映処理
			this.ChangeSearchModeReflect();

			// データ変更フラグプロパティをfalseにする
			this._salesSlipInputAcs.IsDataChanged = false;

			// --- ADD 2010/05/04 ---------->>>>>
			this._readSlipFlg = false;
			// --- ADD 2010/05/04 ----------<<<<<

			return true;
		}

		/// <summary>
		/// 商品区分タイプ比較処理
		/// </summary>
		/// <param name="stockGoodsCd1">商品区分1</param>
		/// <param name="stockGoodsCd2">商品区分2</param>
		/// <returns>true:同一タイプ false:異なるタイプ</returns>
		private bool EqualsSalesGoodsCdType(int salesGoodsCd1, int salesGoodsCd2)
		{
			bool equals = false;

			if (salesGoodsCd1 == salesGoodsCd2)
			{
				equals = true;
			}
			else
			{
				equals = false;
			}

			return equals;
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <br>Update Note: 2009/11/24 伝票呼出時、伝票発行を行わず、伝票の更新のみ行える機能を追加する対応</br>
		private void SettingToolBarButtonEnabled()
		{
			if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly) ||
				(this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AddUp))
			{
				this._saveButton.SharedProps.Enabled = false;
				this._retryButton.SharedProps.Enabled = false;
				this._deleteSlipButton.SharedProps.Enabled = false;
				this._redSlipButton.SharedProps.Enabled = false;
				this._returnSlipButton.SharedProps.Enabled = false;
				this._shipmentAddUpButton.SharedProps.Enabled = false;
				this._acceptAnOrderAddUpButton.SharedProps.Enabled = false;
				this._estimateAddUpButton.SharedProps.Enabled = false;
				// --- ADD 2009/11/24 ---------->>>>>
				this._updateButton.SharedProps.Enabled = false;
				// --- ADD 2009/11/24 ----------<<<<<
                //>>>2010/04/08
                this._setupButton.SharedProps.Enabled = false;
                this._slipHeaderCopyButton.SharedProps.Enabled = false;
                this._reNewalButton.SharedProps.Enabled = false;
                //<<<2010/04/08
            }
			else
			{
                //>>>2010/03/30
                ////>>>2010/02/26
                ////this._saveButton.SharedProps.Enabled = true;
                //if (!this._salesSlipInputAcs.ExistSCMInfo())
                //{
                //    this._saveButton.SharedProps.Enabled = true;
                //}
                //else
                //{
                //    this._saveButton.SharedProps.Enabled = false;
                //}
                ////<<<2010/02/26
                this._saveButton.SharedProps.Enabled = true;
                //<<<2010/03/30
                
                this._retryButton.SharedProps.Enabled = this._salesSlipInputAcs.IsDataChanged;

				this._redSlipButton.SharedProps.Enabled = true;
				this._returnSlipButton.SharedProps.Enabled = true;

				this._copySlipButton.SharedProps.Enabled = true;
				this._searchChangeButton.SharedProps.Enabled = true;

				if (this._salesSlipInputAcs.SalesSlip.SalesSlipNum.PadLeft(9, '0') == SalesSlipInputAcs.ctDefaultSalesSlipNum)
				{
					this._deleteSlipButton.SharedProps.Enabled = false;

					// --- ADD 2009/11/24 ---------->>>>>
					this._updateButton.SharedProps.Enabled = false;
					// --- ADD 2009/11/24 ----------<<<<<
				}
				else
				{
					if (this._salesSlipInputAcs.SalesSlip.DebitNoteDiv == 2)
					{
						this._deleteSlipButton.SharedProps.Enabled = false;
					}
					else
					{
						this._deleteSlipButton.SharedProps.Enabled = true;
					}

					// --- ADD 2009/11/24 ---------->>>>>
					this._updateButton.SharedProps.Enabled = true;
					// --- ADD 2009/11/24 ----------<<<<<
				}

				if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
				{
					this.uButton_ChangeSearchCarMode.Enabled = true;
				}
				else
				{
					this.uButton_ChangeSearchCarMode.Enabled = false;
					if (this._salesSlipInputAcs.SearchCarModeProperty == SalesSlipInputAcs.SearchCarMode.ModelPlateSearch) this.ChangeSearchCarMode();
				}

                //>>>2010/02/26
                //>>>2010/03/30
                //if ((this._salesSlipInputAcs.SalesSlip.CustomerCode == 0) ||
                //    (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM))
                if (((this._salesSlipInputAcs.SalesSlip.CustomerCode == 0) ||
                     (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM)) &&
                     ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) ||
                      (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate)))
                //<<<2010/03/30
                {
                    //this._referenceListButton.SharedProps.Enabled = true; // 2010/03/30
                    this._replyTransactionButton.SharedProps.Enabled = true;
                }
                else
                {
                    //this._referenceListButton.SharedProps.Enabled = false; // 2010/03/30
                    this._replyTransactionButton.SharedProps.Enabled = false;
                }
                //<<<2010/02/26

                //>>>2010/03/30
                if (((this._salesSlipInputAcs.SalesSlip.CustomerCode == 0) ||
                     (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM)))
                {
                    this._referenceListButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._referenceListButton.SharedProps.Enabled = false;
                }

                // 回答処理後、キャンセルデータ表示後は、回答処理ボタン無効
                if (this._scmSave)
                {
                    this._replyTransactionButton.SharedProps.Enabled = false;
                }

                // 明細入力されていない状態になった場合、回答処理フラグクリア
                if (!this._salesSlipInputAcs.ExistSalesDetail())
                {
                    this._scmSave = false;
                }
                //<<<2010/03/30

			}
		}

		/// <summary>
		/// ツールバーキャプション設定
		/// </summary>
		/// <param name="ctrl"></param>
		private void SettingToolBarButtonCaption(Control ctrl)
		{
			if (ctrl == null) return;

			string subCaption = this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Shortcut.ToString();
			subCaption = "(" + subCaption + ")";

			if ((this.panel_Header.Contains(ctrl)) ||
				(this.panel_CarInfo.Contains(ctrl)) ||
				(this.panel_DetailInput.Contains(ctrl)))
			{
				this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Caption = ctDecision + subCaption;
				this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.ToolTipText = ctDecisionToolTipText;
			}
			else
			{
				this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Caption = ctSave + subCaption;
				this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.ToolTipText = ctSaveToolTipText;
			}
		}

		/// <summary>
		/// 画面項目名称設定処理
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void DisplayNameSetting()
		{
			// 消費税ラベル
			string rateName = this._salesSlipInputInitDataAcs.GetTaxRateName();
			if (rateName.Length > 5) rateName = rateName.Substring(0, 5);
			this.uLabel_SalesPriceConsTaxTotalTitle.Text = rateName;

			this.uLabel_AddSalesPriceConsTaxTotalTitle.Text = rateName;// ADD 2009/09/08②

			// 部品検索ラベル
			this.uLabel_SearchMode.Text = ctSearchMode_BLSearch; // 初期値[部品検索]

			// 車両検索ラベル
			this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_FullModel; // 初期値[型式]
		}

		/// <summary>
		/// 指定フォーカス設定処理
		/// </summary>
		/// <param name="ddID"></param>
		/// <param name="rowNO"></param>
        /// <br>UpdateNote : K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
		private void SetControlFocus(string ddID, int rowNo, SalesInputDataSet.SalesDetailDataTable salesTable)
		{
			if (ddID == "ResultsAddUpSecCd")
			{
				this.tEdit_SectionCode.Focus();
				this.ActiveControl = this.tEdit_SectionCode;
			}
			else if (ddID == "CustomerCode")
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;
			}
			else if (ddID == "SalesEmployeeCd")
			{
				this.tEdit_SalesEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_SalesEmployeeCd;
			}
			else if (ddID == "FrontEmployeeCd")
			{
				this.tEdit_FrontEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_FrontEmployeeCd;
			}
			else if (ddID == "CustomerCode")
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;
			}
			else if (ddID == "SalesDate")
			{
				if (this.tDateEdit_SalesDate.Enabled)
				{
					this.tDateEdit_SalesDate.Focus();
					this.ActiveControl = this.tDateEdit_SalesDate;
				}
				else
				{
					this.tEdit_SalesEmployeeCd.Focus();
					this.ActiveControl = this.tEdit_SalesEmployeeCd;
				}
			}
			else if (ddID == "AddUpADate")
			{
				this.tEdit_SalesEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_SalesEmployeeCd;
			}
			else if (ddID == this.tEdit_PartySaleSlipNum.Name)
			{
				this.tEdit_PartySaleSlipNum.Focus();
				this.ActiveControl = this.tEdit_PartySaleSlipNum;
			}
			else if (ddID.Contains(this._salesSlipInputAcs.SalesDetailDataTable.TableName))
			{
				this._salesSlipDetailInput.Focus();

				//if (ddID.Contains(salesTable.ShipmentCntDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_ShipmentCntError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.AcceptAnOrderCntDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_AcptAnOdrCntError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesUnPrcDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesUnitPriceError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesUnitCostColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesUnitCostError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.ListPriceDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_ListPriceError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesMoneyDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesMoneyError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.CostColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_CostError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesRateColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesRateError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.BLGoodsCodeColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_BLGoodsCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.GoodsMakerCdColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_GoodsMakerCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SupplierCdColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SupplierCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.DeliveredGoodsDivNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_DeliveredGoodsDiv, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.FollowDeliGoodsDivNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_FollowDeliGoodsDiv, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.UOEResvdSectionNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_UOEResvdSection, rowNo, salesTable);
				//}
				//else
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_GoodsName, rowNo, salesTable);
				//}

				this._prevControl = this._salesSlipDetailInput;
			}
            // ----- ADD K2011/08/12 --------------------------->>>>>
            else if (ddID == "SlipNote2")
            {
                // ----- ADD K2011/12/09 --------------------------->>>>>
                if (this._enterpriseCode == login_EnterpriseCode)
                {
                // ----- ADD K2011/12/09 ---------------------------<<<<<
                    this.tEdit_SlipNote2.Focus();
                    this.ActiveControl = this.tEdit_SlipNote2;
                }// ADD K2011/12/09
            }
            // ----- ADD K2011/08/12 ---------------------------<<<<<

			this._prevControl = this.ActiveControl;

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);
		}

		/// <summary>
		/// 指定フォーカス設定処理
		/// </summary>
		/// <param name="ddID"></param>
		/// <param name="rowNO"></param>
		private void SetControlFocus(string ddID, int rowNo, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesTable)
		{
			if (ddID == "ResultsAddUpSecCd")
			{
				this.tEdit_SectionCode.Focus();
				this.ActiveControl = this.tEdit_SectionCode;
			}
			else if (ddID == "CustomerCode")
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;
			}
			else if (ddID == "SalesEmployeeCd")
			{
				this.tEdit_SalesEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_SalesEmployeeCd;
			}
			else if (ddID == "FrontEmployeeCd")
			{
				this.tEdit_FrontEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_FrontEmployeeCd;
			}
			else if (ddID == "CustomerCode")
			{
				this.tNedit_CustomerCode.Focus();
				this.ActiveControl = this.tNedit_CustomerCode;
			}
			else if (ddID == "SalesDate")
			{
				if (this.tDateEdit_SalesDate.Enabled)
				{
					this.tDateEdit_SalesDate.Focus();
					this.ActiveControl = this.tDateEdit_SalesDate;
				}
				else
				{
					this.tEdit_SalesEmployeeCd.Focus();
					this.ActiveControl = this.tEdit_SalesEmployeeCd;
				}
			}
			else if (ddID == "AddUpADate")
			{
				this.tEdit_SalesEmployeeCd.Focus();
				this.ActiveControl = this.tEdit_SalesEmployeeCd;
			}
			else if (ddID == this.tEdit_PartySaleSlipNum.Name)
			{
				this.tEdit_PartySaleSlipNum.Focus();
				this.ActiveControl = this.tEdit_PartySaleSlipNum;
			}
			else if (ddID.Contains(this._salesSlipInputAcs.SalesDetailDataTable.TableName))
			{
				this._salesSlipDetailInput.Focus();

				//if (ddID.Contains(salesTable.ShipmentCntDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_ShipmentCntError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.AcceptAnOrderCntDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_AcptAnOdrCntError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesUnPrcDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesUnitPriceError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesUnitCostColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesUnitCostError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.ListPriceDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_ListPriceError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesMoneyDisplayColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesMoneyError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.CostColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_CostError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SalesRateColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SalesRateError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.BLGoodsCodeColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_BLGoodsCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.GoodsMakerCdColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_GoodsMakerCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.SupplierCdColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_SupplierCdError, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.DeliveredGoodsDivNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_DeliveredGoodsDiv, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.FollowDeliGoodsDivNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_FollowDeliGoodsDiv, rowNo, salesTable);
				//}
				//else if (ddID.Contains(salesTable.UOEResvdSectionNmColumn.ColumnName))
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_UOEResvdSection, rowNo, salesTable);
				//}
				//else
				//{
				//    this._salesSlipDetailInput.SettingActiveCell(MAHNB01010UB.ct_SettingActiveCell_GoodsName, rowNo, salesTable);
				//}

				this._prevControl = this._salesSlipDetailInput;
			}

			this._prevControl = this.ActiveControl;

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);
		}

		/// <summary>
		/// コントロールインデックス取得処理(フッタ部)
		/// </summary>
		/// <param name="prevCtrl">現在のコントロールの名称</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>コントロールインデックス</returns>
		private int GetControlIndexForFooter(string prevCtrl, SalesSlipInputAcs.MoveMethod mode)
		{
			int controlIndex = -1;

			switch (mode)
			{
				case SalesSlipInputAcs.MoveMethod.NextMove:
					{
						if (this._controlIndexForwordDictionaryForFooter.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexForwordDictionaryForFooter[prevCtrl];
						}

						break;
					}
				case SalesSlipInputAcs.MoveMethod.PrevMove:
					{
						if (this._controlIndexBackDictionaryForFooter.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexBackDictionaryForFooter[prevCtrl];
						}

						break;
					}
			}
			return controlIndex;
		}

		/// <summary>
		/// ネクストコントロール取得処理(フッタ部)
		/// </summary>
		/// <param name="prevCtrl">現在のコントロール</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>次のコントロール</returns>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private Control GetNextControlForFooter(Control prevCtrl, SalesSlipInputAcs.MoveMethod mode)
		{
			Control control = null;

			switch (mode)
			{
				case SalesSlipInputAcs.MoveMethod.NextMove:
					{
						int prevControlIndex = this.GetControlIndexForFooter(prevCtrl.Name, mode);

						// --- ADD 2009/12/23 ---------->>>>>
						if ((this.tNedit_SlipNoteCode.Enabled) && (!this.tNedit_SlipNoteCode.ReadOnly) && (this.tNedit_SlipNoteCode.Visible) && (prevCtrl != this.tNedit_SlipNoteCode) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNoteCode.Name, mode)))
						{
							control = this.tNedit_SlipNoteCode;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else if ((this.tEdit_SlipNote.Enabled) && (!this.tEdit_SlipNote.ReadOnly) && (this.tEdit_SlipNote.Visible) && (prevCtrl != this.tEdit_SlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote.Name, mode)))
						{
							control = this.tEdit_SlipNote;
						}
						else if ((this.uButton_SlipNote.Enabled) && (this.uButton_SlipNote.Visible) && (prevCtrl != this.uButton_SlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote.Name, mode)))
						{
							control = this.uButton_SlipNote;
						}
						// --- ADD 2009/12/23 ---------->>>>>
						else if ((this.tNedit_SlipNote2Code.Enabled) && (!this.tNedit_SlipNote2Code.ReadOnly) && (this.tNedit_SlipNote2Code.Visible) && (prevCtrl != this.tNedit_SlipNote2Code) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNote2Code.Name, mode)))
						{
							control = this.tNedit_SlipNote2Code;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else if ((this.tEdit_SlipNote2.Enabled) && (!this.tEdit_SlipNote2.ReadOnly) && (this.tEdit_SlipNote2.Visible) && (prevCtrl != this.tEdit_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote2.Name, mode)))
						{
							control = this.tEdit_SlipNote2;
						}
						else if ((this.uButton_SlipNote2.Enabled) && (this.uButton_SlipNote2.Visible) && (prevCtrl != this.uButton_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote2.Name, mode)))
						{
							control = this.uButton_SlipNote2;
						}
						// --- ADD 2009/12/23 ---------->>>>>
						else if ((this.tNedit_SlipNote3Code.Enabled) && (!this.tNedit_SlipNote3Code.ReadOnly) && (this.tNedit_SlipNote3Code.Visible) && (prevCtrl != this.tNedit_SlipNote3Code) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNote3Code.Name, mode)))
						{
							control = this.tNedit_SlipNote3Code;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else if ((this.tEdit_SlipNote3.Enabled) && (!this.tEdit_SlipNote3.ReadOnly) && (this.tEdit_SlipNote3.Visible) && (prevCtrl != this.tEdit_SlipNote3) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote3.Name, mode)))
						{
							control = this.tEdit_SlipNote3;
						}
						else if ((this.uButton_SlipNote3.Enabled) && (this.uButton_SlipNote3.Visible) && (prevCtrl != this.uButton_SlipNote3) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote3.Name, mode)))
						{
							control = this.uButton_SlipNote3;
						}
						else if ((this.tNedit_AddresseeCode.Enabled) && (!this.tNedit_AddresseeCode.ReadOnly) && (this.tNedit_AddresseeCode.Visible) && (prevCtrl != this.tNedit_AddresseeCode) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_AddresseeCode.Name, mode)))
						{
							control = this.tNedit_AddresseeCode;
						}
						else if ((this.tEdit_AddresseeName.Enabled) && (!this.tEdit_AddresseeName.ReadOnly) && (this.tEdit_AddresseeName.Visible) && (prevCtrl != this.tEdit_AddresseeName) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_AddresseeName.Name, mode)))
						{
							control = this.tEdit_AddresseeName;
						}
						else if ((this.uButton_AddresseeGuide.Enabled) && (this.uButton_AddresseeGuide.Visible) && (prevCtrl != this.uButton_AddresseeGuide) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_AddresseeGuide.Name, mode)))
						{
							control = this.uButton_AddresseeGuide;
						}
						else if ((this.tComboEditor_DeliveredGoodsDiv.Enabled) && (!this.tComboEditor_DeliveredGoodsDiv.ReadOnly) && (this.tComboEditor_DeliveredGoodsDiv.Visible) && (prevCtrl != this.tComboEditor_DeliveredGoodsDiv) && (prevControlIndex < this.GetControlIndexForFooter(this.tComboEditor_DeliveredGoodsDiv.Name, mode)))
						{
							control = this.tComboEditor_DeliveredGoodsDiv;
						}
						else if ((this.uButton_AddresseeConfirmation.Enabled) && (this.uButton_AddresseeConfirmation.Visible) && (prevCtrl != this.uButton_AddresseeConfirmation) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_AddresseeConfirmation.Name, mode)))
						{
							control = this.uButton_AddresseeConfirmation;
						}
						else if ((this.tEdit_RetGoodsReason.Enabled) && (!this.tEdit_RetGoodsReason.ReadOnly) && (this.tEdit_RetGoodsReason.Visible) && (prevCtrl != this.tEdit_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_RetGoodsReason.Name, mode)))
						{
							control = this.tEdit_RetGoodsReason;
						}
						else if ((this.uButton_RetGoodsReason.Enabled) && (this.uButton_RetGoodsReason.Visible) && (prevCtrl != this.uButton_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_RetGoodsReason.Name, mode)))
						{
							control = this.uButton_RetGoodsReason;
						}
						else if ((this.tEdit_PartySaleSlipNum.Enabled) && (!this.tEdit_PartySaleSlipNum.ReadOnly) && (this.tEdit_PartySaleSlipNum.Visible) && (prevCtrl != this.tEdit_PartySaleSlipNum) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_PartySaleSlipNum.Name, mode)))
						{
							control = this.tEdit_PartySaleSlipNum;
						}
                        //>>>2010/02/26
                        else if ((this.tNedit_InquiryNumber.Enabled) && (!this.tNedit_InquiryNumber.ReadOnly) && (this.tNedit_InquiryNumber.Visible) && (prevCtrl != this.tNedit_InquiryNumber) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_InquiryNumber.Name, mode)))
                        {
                            control = this.tNedit_InquiryNumber;
                        }
                        else if ((this.tComboEditor_AnswerDiv.Enabled) && (!this.tComboEditor_AnswerDiv.ReadOnly) && (this.tComboEditor_AnswerDiv.Visible) && (prevCtrl != this.tComboEditor_AnswerDiv) && (prevControlIndex < this.GetControlIndexForFooter(this.tComboEditor_AnswerDiv.Name, mode)))
                        {
                            control = this.tComboEditor_AnswerDiv;
                        }
                        //<<<2010/02/26
						// --- ADD 2009/09/08② ---------->>>>>
						else if ((this.tEdit_CarSlipNote.Enabled) && (!this.tEdit_CarSlipNote.ReadOnly) && (this.tEdit_CarSlipNote.Visible) && (prevCtrl != this.tEdit_CarSlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_CarSlipNote.Name, mode)))
						{
							control = this.tEdit_CarSlipNote;
						}
						else if ((this.uButton_SlipNoteGuide.Enabled) && (this.uButton_SlipNoteGuide.Visible) && (prevCtrl != this.uButton_SlipNoteGuide) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNoteGuide.Name, mode)))
						{
							control = this.uButton_SlipNoteGuide;
						}
						else if ((this.tNedit_Mileage.Enabled) && (this.tNedit_Mileage.Visible) && (prevCtrl != this.tNedit_Mileage) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_Mileage.Name, mode)))
						{
							control = this.tNedit_Mileage;
						}
						// --- ADD 2009/09/08② ----------<<<<<
						else
						{
							control = prevCtrl;
						}

						break;
					}
				case SalesSlipInputAcs.MoveMethod.PrevMove:
					{
						int prevControlIndex = this.GetControlIndexForFooter(prevCtrl.Name, mode);

						// --- ADD 2009/09/08② ---------->>>>>
						if ((this.tNedit_Mileage.Enabled) && (!this.tNedit_Mileage.ReadOnly) && (this.tNedit_Mileage.Visible) && (prevCtrl != this.tNedit_Mileage) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_Mileage.Name, mode)))
						{
							control = this.tNedit_Mileage;
						}
						else if ((this.uButton_SlipNoteGuide.Enabled) && (this.uButton_SlipNoteGuide.Visible) && (prevCtrl != this.uButton_SlipNoteGuide) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNoteGuide.Name, mode)))
						{
							control = this.uButton_SlipNoteGuide;
						}
						else if ((this.tEdit_CarSlipNote.Enabled) && (!this.tEdit_CarSlipNote.ReadOnly) && (this.tEdit_CarSlipNote.Visible) && (prevCtrl != this.tEdit_CarSlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_CarSlipNote.Name, mode)))
						{
							control = this.tEdit_CarSlipNote;
						}
						// --- ADD 2009/09/08② ----------<<<<<
                        //>>>2010/02/26
                        else if ((this.tComboEditor_AnswerDiv.Enabled) && (!this.tComboEditor_AnswerDiv.ReadOnly) && (this.tComboEditor_AnswerDiv.Visible) && (prevCtrl != this.tComboEditor_AnswerDiv) && (prevControlIndex < this.GetControlIndexForFooter(this.tComboEditor_AnswerDiv.Name, mode)))
                        {
                            control = this.tComboEditor_AnswerDiv;
                        }
                        else if ((this.tNedit_InquiryNumber.Enabled) && (!this.tNedit_InquiryNumber.ReadOnly) && (this.tNedit_InquiryNumber.Visible) && (prevCtrl != this.tNedit_InquiryNumber) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_InquiryNumber.Name, mode)))
                        {
                            control = this.tNedit_InquiryNumber;
                        }
                        //<<<2010/02/26
						else if ((this.tEdit_PartySaleSlipNum.Enabled) && (!this.tEdit_PartySaleSlipNum.ReadOnly) && (this.tEdit_PartySaleSlipNum.Visible) && (prevCtrl != this.tEdit_PartySaleSlipNum) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_PartySaleSlipNum.Name, mode)))
						{
							control = this.tEdit_PartySaleSlipNum;
						}
						else if ((this.uButton_RetGoodsReason.Enabled) && (this.uButton_RetGoodsReason.Visible) && (prevCtrl != this.uButton_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_RetGoodsReason.Name, mode)))
						{
							control = this.uButton_RetGoodsReason;
						}
						else if ((this.tEdit_RetGoodsReason.Enabled) && (!this.tEdit_RetGoodsReason.ReadOnly) && (this.tEdit_RetGoodsReason.Visible) && (prevCtrl != this.tEdit_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_RetGoodsReason.Name, mode)))
						{
							control = this.tEdit_RetGoodsReason;
						}
						else if ((this.uButton_AddresseeConfirmation.Enabled) && (this.uButton_AddresseeConfirmation.Visible) && (prevCtrl != this.uButton_AddresseeConfirmation) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_AddresseeConfirmation.Name, mode)))
						{
							control = this.uButton_AddresseeConfirmation;
						}
						else if ((this.tComboEditor_DeliveredGoodsDiv.Enabled) && (!this.tComboEditor_DeliveredGoodsDiv.ReadOnly) && (this.tComboEditor_DeliveredGoodsDiv.Visible) && (prevCtrl != this.tComboEditor_DeliveredGoodsDiv) && (prevControlIndex < this.GetControlIndexForFooter(this.tComboEditor_DeliveredGoodsDiv.Name, mode)))
						{
							control = this.tComboEditor_DeliveredGoodsDiv;
						}
						else if ((this.uButton_AddresseeGuide.Enabled) && (this.uButton_AddresseeGuide.Visible) && (prevCtrl != this.uButton_AddresseeGuide) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_AddresseeGuide.Name, mode)))
						{
							control = this.uButton_AddresseeGuide;
						}
						else if ((this.tEdit_AddresseeName.Enabled) && (!this.tEdit_AddresseeName.ReadOnly) && (this.tEdit_AddresseeName.Visible) && (prevCtrl != this.tEdit_AddresseeName) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_AddresseeName.Name, mode)))
						{
							control = this.tEdit_AddresseeName;
						}
						else if ((this.tNedit_AddresseeCode.Enabled) && (!this.tNedit_AddresseeCode.ReadOnly) && (this.tNedit_AddresseeCode.Visible) && (prevCtrl != this.tNedit_AddresseeCode) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_AddresseeCode.Name, mode)))
						{
							control = this.tNedit_AddresseeCode;
						}
						else if ((this.uButton_SlipNote3.Enabled) && (this.uButton_SlipNote3.Visible) && (prevCtrl != this.uButton_SlipNote3) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote3.Name, mode)))
						{
							control = this.uButton_SlipNote3;
						}
						else if ((this.tEdit_SlipNote3.Enabled) && (!this.tEdit_SlipNote3.ReadOnly) && (this.tEdit_SlipNote3.Visible) && (prevCtrl != this.tEdit_SlipNote3) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote3.Name, mode)))
						{
							control = this.tEdit_SlipNote3;
						}
						// --- ADD 2009/12/23 ---------->>>>>
						else if ((this.tNedit_SlipNote3Code.Enabled) && (!this.tNedit_SlipNote3Code.ReadOnly) && (this.tNedit_SlipNote3Code.Visible) && (prevCtrl != this.tNedit_SlipNote3Code) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNote3Code.Name, mode)))
						{
							control = this.tNedit_SlipNote3Code;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else if ((this.uButton_SlipNote2.Enabled) && (this.uButton_SlipNote2.Visible) && (prevCtrl != this.uButton_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote2.Name, mode)))
						{
							control = this.uButton_SlipNote2;
						}
						else if ((this.tEdit_SlipNote2.Enabled) && (!this.tEdit_SlipNote2.ReadOnly) && (this.tEdit_SlipNote2.Visible) && (prevCtrl != this.tEdit_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote2.Name, mode)))
						{
							control = this.tEdit_SlipNote2;
						}
						// --- ADD 2009/12/23 ---------->>>>>
						else if ((this.tNedit_SlipNote2Code.Enabled) && (!this.tNedit_SlipNote2Code.ReadOnly) && (this.tNedit_SlipNote2Code.Visible) && (prevCtrl != this.tNedit_SlipNote2Code) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNote2Code.Name, mode)))
						{
							control = this.tNedit_SlipNote2Code;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else if ((this.uButton_SlipNote.Enabled) && (this.uButton_SlipNote.Visible) && (prevCtrl != this.uButton_SlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote.Name, mode)))
						{
							control = this.uButton_SlipNote;
						}
						else if ((this.tEdit_SlipNote.Enabled) && (!this.tEdit_SlipNote.ReadOnly) && (this.tEdit_SlipNote.Visible) && (prevCtrl != this.tEdit_SlipNote) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SlipNote.Name, mode)))
						{
							control = this.tEdit_SlipNote;
						}
						// --- ADD 2009/12/23 ---------->>>>>
						else if ((this.tNedit_SlipNoteCode.Enabled) && (!this.tNedit_SlipNoteCode.ReadOnly) && (this.tNedit_SlipNoteCode.Visible) && (prevCtrl != this.tNedit_SlipNoteCode) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SlipNoteCode.Name, mode)))
						{
							control = this.tNedit_SlipNoteCode;
						}
						// --- ADD 2009/12/23 ----------<<<<<
						else
						{
							if ((this._salesSlipDetailInput.uGrid_Details.Enabled) && (this._salesSlipDetailInput.uGrid_Details.Visible) && (prevCtrl != this._salesSlipDetailInput.uGrid_Details))
							{
								control = this._salesSlipDetailInput.uGrid_Details;
							}
							else if ((this.tEdit_FullModel.Enabled) && (!this.tEdit_FullModel.ReadOnly) && (this.tEdit_FullModel.Visible) && (prevCtrl != this.tEdit_FullModel))
							{
								control = this.tEdit_FullModel;
							}
							else if ((this.tDateEdit_SalesDate.Enabled) && (!this.tDateEdit_SalesDate.ReadOnly) && (this.tDateEdit_SalesDate.Visible) && (prevCtrl != this.tDateEdit_SalesDate))
							{
								control = this.tDateEdit_SalesDate;
							}
						}

						break;
					}
			}

			return control;
		}

		#region ●返品処理関係
		/// <summary>
		/// 返品計上処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void ReturnSlip(bool isConfirm)
		{
			bool canReturn = this.ShowSaveCheckDialog(isConfirm);

			if (!canReturn) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

            //>>>2010/03/30
            int acptAnOdrStatus = this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay;
            if ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay != (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
                (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay != (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment))
            {
                acptAnOdrStatus = (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales;
            }
            //<<<2010/03/30

            //>>>2010/03/30
            //MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD(this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_True, MAHNB01010UD.ct_MODE_RetGoods);
            MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD(acptAnOdrStatus, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_True, MAHNB01010UD.ct_MODE_RetGoods);
            //<<<2010/03/30
            this._controlScreenSkin.SettingScreenSkin(salesSlipNumInputDialog);
			DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNumInputDialog.SalesSlip;
				SalesSlip baseSalesSlip = salesSlipNumInputDialog.BaseSalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNumInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNumInputDialog.AddUpSrcDetailList;
				SearchDepsitMain depsitMain = salesSlipNumInputDialog.DepsitMain;
				SearchDepositAlw depositAlw = salesSlipNumInputDialog.DepositAlw;
				List<StockWork> stockWorkList = salesSlipNumInputDialog.StockWorkList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNumInputDialog.AcceptOdrCarList;
				List<StockSlipWork> stockSlipWorkList = salesSlipNumInputDialog.StockSlipWorkList;
				List<StockDetailWork> stockDetailWorkList = salesSlipNumInputDialog.StockDetailWorkList;
				List<AddUpOrgStockDetailWork> addUpOrgStockDetailList = salesSlipNumInputDialog.addUpOrgStockDetailList;
				List<PaymentSlpWork> paymentSlpWorkList = salesSlipNumInputDialog.paymentSlpWorkList;

				// 返品時は消費税転嫁方式の更新を行わないので、再取得前に戻す
				salesSlip.ConsTaxLayMethod = baseSalesSlip.ConsTaxLayMethod;

				this.ReturnSlip(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 返品計上処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void ReturnSlip(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			SalesSlip salesSlip;
			SalesSlip baseSalesSlip;
			List<SalesDetail> salesDetailList;
			List<SalesDetail> addUpSrcDetailList;
			SearchDepsitMain depsitMain;
			SearchDepositAlw depositAlw;
			List<StockWork> stockWorkList;
			List<StockSlipWork> stockSlipWorkList;
			List<StockDetailWork> stockDetailWorkList;
			List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
			List<AcceptOdrCar> acceptOdrCarList;
			List<UOEOrderDtlWork> uoeOrderDtlWorkList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 返品時は消費税転嫁方式の更新を行わないので、再取得前に戻す
				salesSlip.ConsTaxLayMethod = baseSalesSlip.ConsTaxLayMethod;

				this.ReturnSlip(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);
			}
		}

		/// <summary>
		/// 返品計上処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
		/// <param name="depsitMain">入金データオブジェクト</param>
		/// <param name="depositAlw">入金引当データオブジェクト</param>
		/// <param name="stockSlipWorkList">仕入データオブジェクトリスト</param>
		/// <param name="stockDetailWorkList">仕入明明細データオブジェクトリスト</param>
		/// <param name="addUppOrgStockDetailList">同時入力計上元仕入明細データオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void ReturnSlip(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUppOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
		{
			// 返品伝票情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateReturnSlipInfo(salesSlip, salesDetailList, out message);
			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);
				return;
			}

			// 計上元データ表示テキスト作成
			string addText = string.Empty;
			if (this._salesSlipInputAcs.ExistSalesDetailAddUpSrcDataDBList(salesDetailList))
			{
				// 計上元明細読込
				List<SalesDetail> salesDetailListSrc = this._salesSlipInputAcs.ReadDetailSrc(salesDetailList);

				// 出力文字列作成処理
				if (salesDetailListSrc != null) addText = this._salesSlipInputAcs.MakeAddTextSrc(salesDetailList, salesDetailListSrc);

				DialogResult dr = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"関連するデータが存在します。　　\r\n\r\n" +
					addText + "\r\n" +
					"返品処理を行ってよろしいですか？",
					0,
					MessageBoxButtons.YesNo);
				if (dr == DialogResult.No) return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 返品伝票情報生成処理
			this._salesSlipInputAcs.CreateReturnSlipInfo(ref salesSlip);

			// キャッシュ
			this._salesSlipInputAcs.Cache(salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList);

			// 返品伝票明細情報生成処理
			this._salesSlipInputAcs.CreateReturnSlipDetailInfo(stockWorkList);

			// 出荷数０行削除処理
			this._salesSlipDetailInput.DeleteShipmentCountZeroRow(false);

			//// 受注残数０行削除処理
			//this._salesSlipDetailInput.DeleteAcptAnOdrRemainCntZeroRow(false);

			// 空白行削除処理
			this._salesSlipDetailInput.DeleteEmptyRow(true);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 売単価、原単価の初期値設定
			this._salesSlipInputAcs.CacheDefaultValue();

			// 明細グリッドにフォーカスをセット
			this._salesSlipDetailInput.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;

		}
		#endregion

		#region ●赤伝処理関係
		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void RedSlip(bool isConfirm)
		{
			bool canRed = this.ShowSaveCheckDialog(isConfirm);

			if (!canRed) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

			MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD((int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_False, MAHNB01010UD.ct_MODE_RedSlip);
			this._controlScreenSkin.SettingScreenSkin(salesSlipNumInputDialog);
			DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNumInputDialog.SalesSlip;
				SalesSlip baseSalesSlip = salesSlipNumInputDialog.BaseSalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNumInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNumInputDialog.AddUpSrcDetailList;
				SearchDepsitMain depsitMain = salesSlipNumInputDialog.DepsitMain;
				SearchDepositAlw depositAlw = salesSlipNumInputDialog.DepositAlw;
				List<StockWork> stockWorkList = salesSlipNumInputDialog.StockWorkList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNumInputDialog.AcceptOdrCarList;
				List<StockSlipWork> stockSlipWorkList = salesSlipNumInputDialog.StockSlipWorkList;
				List<StockDetailWork> stockDetailWorkList = salesSlipNumInputDialog.StockDetailWorkList;
				List<AddUpOrgStockDetailWork> addUpOrgStockDetailList = salesSlipNumInputDialog.addUpOrgStockDetailList;

				// 赤伝時は消費税転嫁方式の更新を行わないので、再取得前に戻す
				salesSlip.ConsTaxLayMethod = baseSalesSlip.ConsTaxLayMethod;

				this.RedSlip(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void RedSlip(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			SalesSlip salesSlip;
			SalesSlip baseSalesSlip;
			List<SalesDetail> salesDetailList;
			List<SalesDetail> addUpSrcDetailList;
			SearchDepsitMain depsitMain;
			SearchDepositAlw depositAlw;
			List<StockWork> stockWorkList;
			List<StockSlipWork> stockSlipWorkList;
			List<StockDetailWork> stockDetailWorkList;
			List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
			List<AcceptOdrCar> acceptOdrCarList;
			List<UOEOrderDtlWork> uoeOrderDtlWorkList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 赤伝時は消費税転嫁方式の更新を行わないので、再取得前に戻す
				salesSlip.ConsTaxLayMethod = baseSalesSlip.ConsTaxLayMethod;

				this.RedSlip(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);
			}
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
		/// <param name="depsitMain">入金データオブジェクト</param>
		/// <param name="depositAlw">入金引当データオブジェクト</param>
		/// <param name="stockSlipWorkList">仕入データオブジェクトリスト</param>
		/// <param name="stockDetailWorkList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUppOrgStockDetailList">同時入力計上元仕入明細データオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void RedSlip(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
		{
			// 赤伝票情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateRedSlipInfo(salesSlip, salesDetailList, out message);

			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);
				return;
			}

			// 計上元データ表示テキスト作成
			string addText = string.Empty;
			if (this._salesSlipInputAcs.ExistSalesDetailAddUpSrcDataDBList(salesDetailList))
			{
				// 計上元明細読込
				List<SalesDetail> salesDetailListSrc = this._salesSlipInputAcs.ReadDetailSrc(salesDetailList);

				// 出力文字列作成処理
				if (salesDetailListSrc != null) addText = this._salesSlipInputAcs.MakeAddTextSrc(salesDetailList, salesDetailListSrc);

				DialogResult dr = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"関連するデータが存在します。　　\r\n\r\n" +
					addText + "\r\n" +
					"赤伝処理を行ってよろしいですか？",
					0,
					MessageBoxButtons.YesNo);
				if (dr == DialogResult.No) return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 赤伝票情報生成処理
			this._salesSlipInputAcs.CreateRedSlipInfo(ref salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList);

			// 赤伝票明細情報生成処理
			this._salesSlipInputAcs.CreateRedSlipDetailInfo(stockWorkList);

			// 出荷数０行削除処理
			//this._salesSlipDetailInput.DeleteShipmentCountZeroRow(false);

			// 空白行削除処理
			this._salesSlipDetailInput.DeleteEmptyRow(true);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 返品理由コードにフォーカスをセット
			this.tEdit_RetGoodsReason.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;
		}
		#endregion

		#region ●削除処理関係
		/// <summary>
		/// 削除処理
		/// </summary>
		private void Delete()
		{
			// 計上元データ表示テキスト作成
			string addText = string.Empty;
			if (this._salesSlipInputAcs.ExistSalesDetailAddUpSrcData())
			{
				addText = "関連するデータが存在します。　　\r\n\r\n";

				// 計上元明細読込
				List<SalesDetail> salesDetailListSrc = this._salesSlipInputAcs.ReadDetailSrc();

				// 出力文字列作成処理
				if (salesDetailListSrc != null) addText = addText + this._salesSlipInputAcs.MakeAddTextSrc(salesDetailListSrc) + "\r\n";

			}

			// 確認画面
			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_EXCLAMATION,
				this.Name,
				"表示中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "伝票" + "を削除します。" + "\r\n" + "\r\n" + addText +
				"削除してよろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			if (dialogResult != DialogResult.Yes) return;

			// 仕入伝票削除区分
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierSlipDelDiv == 1)
			{
				if (this._salesSlipInputAcs.ExistStockTemp() == true)
				{
					dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"同時入力分の仕入情報も同時に削除します。" + "\r\n" + "\r\n" +
						"よろしいですか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);
					if (dialogResult == DialogResult.Yes)
					{
						this._salesSlipInputAcs.SupplierSlipDelDiv = 2; // 削除する
					}
					else
					{
						this._salesSlipInputAcs.SupplierSlipDelDiv = 0; // 削除しない
					}
				}
			}

			List<string> itemNameList = new List<string>();
			List<string> itemList = new List<string>();
			string mainMessage;

			// 削除データチェック処理
			bool check = this._salesSlipInputAcs.CheckDeleteData(this._salesSlipInputAcs.SalesSlip, out mainMessage, out itemNameList, out itemList);

			if (!check)
			{
				StringBuilder message = new StringBuilder();
				message.Append(mainMessage);

				if (!check)
				{
					foreach (string s in itemNameList)
					{
						message.Append(s + "\r\n");
					}
				}

				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					message.ToString(),
					0,
					MessageBoxButtons.OK);

				string itemName = string.Empty;
				if (itemList.Count > 0)
				{
					itemName = itemList[0].ToString();

					// 指定フォーカス設定処理
					this.SetControlFocus(itemName, -1, this._salesSlipInputAcs.SalesDetailDataTable);
				}

				return;
			}

			string retMessage;
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.DeleteDBData(this._salesSlipInputAcs.SalesSlip, this._salesSlipInputAcs.SalesDetailDataTable, this._salesSlipInputAcs.DepsitMain, this._salesSlipInputAcs.DepositAlw, this._salesSlipInputAcs.StockSlipForReadDataTable, this._salesSlipInputAcs.StockDetailForReadDataTable, this._salesSlipInputAcs.PaymentSlpDataTable, out retMessage);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				#region ログ出力
				SortedDictionary<string, ArrayList> logInfoDic = new SortedDictionary<string, ArrayList>();
				this._salesSlipInputAcs.MakeLogInfoForSlip(this._salesSlipInputAcs.SalesSlip, SalesSlipInputAcs.OutPutLogMode.SlipDelete, ref logInfoDic);
				this._salesSlipInputAcs.OutPutLogInfo(logInfoDic);
				#endregion

				this.uLabel_BeforeSalesSlipNum.Text = "前回伝票番号：" + this._salesSlipInputAcs.SalesSlip.SalesSlipNum.ToString().PadLeft(9, '0');

				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"削除しました。",
					-1,
					MessageBoxButtons.OK);

				// 画面初期化処理
				this.Clear(false, false);

				this.timer_InitialSetFocus.Enabled = true;
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
			{
				// 担当者にフォーカスをセット（一時的に）
				this.tEdit_SalesEmployeeCd.Focus();

				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"現在、編集中の売上データは既に更新されています。" + "\r\n" + "\r\n" +
					"最新の情報を取得します。",
					-1,
					MessageBoxButtons.OK);

				// 再読込処理
				this.ReLoad(this._salesSlipInputAcs.SalesSlip.EnterpriseCode, this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay, this._salesSlipInputAcs.SalesSlip.SalesSlipNum);

				// 明細グリッドにフォーカスをセット
				this._salesSlipDetailInput.Focus();
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
			{
				// 担当者にフォーカスをセット（一時的に）
				this.tEdit_SalesEmployeeCd.Focus();

				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"現在、編集中の売上データは既に削除されています。",
					-1,
					MessageBoxButtons.OK);

				this.Clear(false, true);

				this.timer_InitialSetFocus.Enabled = true;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "データの削除に失敗しました。",
					status,
					MessageBoxButtons.OK);
			}
		}
		#endregion

		#region ●伝票複写関係
		/// <summary>
		/// 伝票複写処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void CopySlip(bool isConfirm)
		{
			// 伝票複写
			bool canRed = this.ShowSaveCheckDialog(isConfirm);

			if (!canRed) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

			MAHNB01010UD salesSlipNoInputDialog = new MAHNB01010UD(this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_True, MAHNB01010UD.ct_MODE_Normal);
			this._controlScreenSkin.SettingScreenSkin(salesSlipNoInputDialog);
			DialogResult dialogResult = salesSlipNoInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNoInputDialog.SalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNoInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNoInputDialog.AddUpSrcDetailList;
				List<StockWork> stockWorkList = salesSlipNoInputDialog.StockWorkList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNoInputDialog.AcceptOdrCarList;

				this.CopySlip(salesSlip, salesDetailList, addUpSrcDetailList, stockWorkList, acceptOdrCarList);

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;

		}

		/// <summary>
		/// 伝票複写
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void CopySlip(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			SalesSlip salesSlip;
			SalesSlip baseSalesSlip;
			List<SalesDetail> salesDetailList;
			List<SalesDetail> addUpSrcDetailList;
			List<StockWork> stockWorkList;
			List<AcceptOdrCar> acceptOdrCarList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out stockWorkList, out acceptOdrCarList);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.CopySlip(salesSlip, salesDetailList, addUpSrcDetailList, stockWorkList, acceptOdrCarList);
			}
		}

		/// <summary>
		/// 伝票複写
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void CopySlip(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
		{
			// 複写情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateCopySlipInfo(salesSlip, salesDetailList, out message);
			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 複写情報生成処理
			this._salesSlipInputAcs.CreateSlipCopyInfo(ref salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, stockWorkList, acceptOdrCarList);

			// コピー伝票明細情報生成処理
			this._salesSlipInputAcs.CreateSlipCopyDetailInfo();

			// コピー伝票車輌情報生成処理
			this._salesSlipInputAcs.CreateSlipCopyCarInfo();

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;
		}
		#endregion

		#region ●出荷計上処理関係
		/// <summary>
		/// 出荷計上処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void ShipmentAddUp(bool isConfirm)
		{
			bool canShipmentAddUp = this.ShowSaveCheckDialog(isConfirm);

			if (!canShipmentAddUp) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

			string salesSlipNum = string.Empty;
			if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment) // 出荷
			{
				salesSlipNum = this._salesSlipInputAcs.SalesSlip.SalesSlipNum;
			}
			MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD((int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment, salesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_False, MAHNB01010UD.ct_MODE_Normal);
			this._controlScreenSkin.SettingScreenSkin(salesSlipNumInputDialog);
			DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNumInputDialog.SalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNumInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNumInputDialog.AddUpSrcDetailList;
				SearchDepsitMain depsitMain = salesSlipNumInputDialog.DepsitMain;
				SearchDepositAlw depositAlw = salesSlipNumInputDialog.DepositAlw;
				List<StockWork> stockWorkList = salesSlipNumInputDialog.StockWorkList;
				List<StockSlipWork> stockSlipWorkList = salesSlipNumInputDialog.StockSlipWorkList;
				List<StockDetailWork> stockDetailWorkList = salesSlipNumInputDialog.StockDetailWorkList;
				List<AddUpOrgStockDetailWork> addUpOrgStockDetailList = salesSlipNumInputDialog.addUpOrgStockDetailList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNumInputDialog.AcceptOdrCarList;

				// 出荷計上処理
				this.ShipmentAddUp(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 出荷計上処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void ShipmentAddUp(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			SalesSlip salesSlip;
			SalesSlip baseSalesSlip;
			List<SalesDetail> salesDetailList;
			List<SalesDetail> addUpSrcDetailList;
			SearchDepsitMain depsitMain;
			SearchDepositAlw depositAlw;
			List<StockWork> stockWorkList;
			List<StockSlipWork> stockSlipWorkList;
			List<StockDetailWork> stockDetailWorkList;
			List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
			List<AcceptOdrCar> acceptOdrCarList;
			List<UOEOrderDtlWork> uoeOrderDtlWorkList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.ShipmentAddUp(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);
			}
		}

		/// <summary>
		/// 出荷計上処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
		/// <param name="depsitMain">入金データオブジェクト</param>
		/// <param name="depositAlw">入金引当データオブジェクト</param>
		/// <param name="stockSlipWorkList">仕入データオブジェクトリスト</param>
		/// <param name="stockDetailWorkList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUppOrgStockDetailList">同時入力計上元仕入明細データオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void ShipmentAddUp(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
		{
			// 出荷計上情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateShipmentAddUpInfo(salesSlip, salesDetailList, out message);
			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 計上初期値セット前情報キャッシュ
			this._salesSlipInputAcs.CacheSalesSlipBeforeAddUp(salesSlip);

			// 出荷計上情報生成処理
			this._salesSlipInputAcs.CreateShipmentAddUpInfo(ref salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList);

			// 出荷計上明細情報生成処理
			this._salesSlipInputAcs.CreateShipmentAddUpDetailInfo(stockWorkList);

			// 売上数量０行削除処理
			this._salesSlipDetailInput.DeleteShipmentCountZeroRow(false);

			//// 受注残数０行削除処理
			//this._salesSlipDetailInput.DeleteAcptAnOdrRemainCntZeroRow(false);

			// 空白行削除処理
			this._salesSlipDetailInput.DeleteEmptyRow(true);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 売単価、原単価の初期値設定
			this._salesSlipInputAcs.CacheDefaultValue();

			// 明細グリッドにフォーカスをセット
			this._salesSlipDetailInput.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;
		}
		#endregion

		#region ●受注計上処理関係
		/// <summary>
		/// 受注計上処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void AcceptAnOrderAddup(bool isConfirm)
		{
			bool canAcceptAnOrderAddUp = this.ShowSaveCheckDialog(isConfirm);

			if (!canAcceptAnOrderAddUp) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

			string salesSlipNum = string.Empty;
			if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) // 受注
			{
				salesSlipNum = this._salesSlipInputAcs.SalesSlip.SalesSlipNum;
			}
			MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD((int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder, salesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_False, MAHNB01010UD.ct_MODE_Normal);
			this._controlScreenSkin.SettingScreenSkin(salesSlipNumInputDialog);
			DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNumInputDialog.SalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNumInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNumInputDialog.AddUpSrcDetailList;
				SearchDepsitMain depsitMain = salesSlipNumInputDialog.DepsitMain;
				SearchDepositAlw depositAlw = salesSlipNumInputDialog.DepositAlw;
				List<StockWork> stockWorkList = salesSlipNumInputDialog.StockWorkList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNumInputDialog.AcceptOdrCarList;
				List<StockSlipWork> stockSlipWorkList = salesSlipNumInputDialog.StockSlipWorkList;
				List<StockDetailWork> stockDetailWorkList = salesSlipNumInputDialog.StockDetailWorkList;
				List<AddUpOrgStockDetailWork> addUpOrgStockDetailList = salesSlipNumInputDialog.addUpOrgStockDetailList;
				List<UOEOrderDtlWork> uoeOrderDtlWorkList = salesSlipNumInputDialog.uoeOrderDtlWorkList;
                //>>>2010/02/26
                UserSCMOrderHeaderRecord scmHeader = salesSlipNumInputDialog.scmHeader;
                UserSCMOrderCarRecord scmCar = salesSlipNumInputDialog.scmCar;
                List<UserSCMOrderAnswerRecord> scmAnswerList = salesSlipNumInputDialog.scmAnswerList;
                //<<<2010/02/26

				// 受注計上処理
                //>>>2010/02/26
                //this.AcceptAnOrderAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList, uoeOrderDtlWorkList);
                this.AcceptAnOrderAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList, uoeOrderDtlWorkList, scmHeader, scmCar, scmAnswerList);
                //<<<2010/02/26

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 受注計上
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクト</param>
		/// <param name="depsitMain">入金データオブジェクト</param>
		/// <param name="depositAlw">入金引当データオブジェクト</param>
		/// <param name="stockSlipWorkList">仕入ワークデータオブジェクトリスト</param>
		/// <param name="stockDetailWorkList">仕入明細ワークデータオブジェクトリスト</param>
		/// <param name="addUpOrgStockDetailList">同時入力計上元仕入明細ワークデータオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <param name="uoeOrderDtlWorkList">UOE発注データワークオブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
        //>>>2010/02/26
        //private void AcceptAnOrderAddup(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList, List<UOEOrderDtlWork> uoeOrderDtlWorkList)
        private void AcceptAnOrderAddup(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList, List<UOEOrderDtlWork> uoeOrderDtlWorkList, UserSCMOrderHeaderRecord scmHeader, UserSCMOrderCarRecord scmCar, List<UserSCMOrderAnswerRecord> scmAnswerList)
        //<<<2010/02/26
        {
			// 受注計上情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateAcceptAnOrderAddUpInfo(salesSlip, salesDetailList, uoeOrderDtlWorkList, out message);
			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);
				return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 計上初期値セット前情報キャッシュ
			this._salesSlipInputAcs.CacheSalesSlipBeforeAddUp(salesSlip);

			// 受注計上情報生成処理
			this._salesSlipInputAcs.CreateAcceptAnOrderAddUpInfo(ref salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
            //>>>2010/02/26
            //this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList);
            this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList, scmHeader, scmCar, null, scmAnswerList);
            //<<<2010/02/26

			// 受注計上明細情報生成処理
			this._salesSlipInputAcs.CreateAcceptAnOrderAddUpDetailInfo(stockWorkList);

            //>>>2010/02/26
            // SCM情報補正処理
            this._salesSlipInputAcs.AdjustScmInfoForAcceptAnOrderAddup();
            //<<<2010/02/26

			// 売上数量０行削除処理
			this._salesSlipDetailInput.DeleteShipmentCountZeroRow(false);

			//// 受注残数０行削除処理
			//this._salesSlipDetailInput.DeleteAcptAnOdrRemainCntZeroRow(false);

			// 空白行削除処理
			this._salesSlipDetailInput.DeleteEmptyRow(true);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 売単価、原単価の初期値設定
			this._salesSlipInputAcs.CacheDefaultValue();

			// 明細グリッドにフォーカスをセット
			this._salesSlipDetailInput.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;
		}
		#endregion

		#region ●見積計上処理関係
		/// <summary>
		/// 見積計上処理
		/// </summary>
		/// <param name="isConfirm">確認ダイアログ表示有無(true:表示する false:表示しない)</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void EstimateAddup(bool isConfirm)
		{
			bool canEstimateAddUp = this.ShowSaveCheckDialog(isConfirm);

			if (!canEstimateAddUp) return;

			this.tEdit_SalesEmployeeCd.Focus();
			this.ActiveControl = this.tEdit_SalesEmployeeCd;

			string salesSlipNum = string.Empty;
			if (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) // 見積
			{
				salesSlipNum = this._salesSlipInputAcs.SalesSlip.SalesSlipNum;
			}
			MAHNB01010UD salesSlipNumInputDialog = new MAHNB01010UD((int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate, salesSlipNum, MAHNB01010UD.ct_AcptAnOdrStatusEnable_True, MAHNB01010UD.ct_MODE_Estimate);
			this._controlScreenSkin.SettingScreenSkin(salesSlipNumInputDialog);
			DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
				SalesSlip salesSlip = salesSlipNumInputDialog.SalesSlip;
				List<SalesDetail> salesDetailList = salesSlipNumInputDialog.SalesDetailList;
				List<SalesDetail> addUpSrcDetailList = salesSlipNumInputDialog.AddUpSrcDetailList;
				SearchDepsitMain depsitMain = salesSlipNumInputDialog.DepsitMain;
				SearchDepositAlw depositAlw = salesSlipNumInputDialog.DepositAlw;
				List<StockWork> stockWorkList = salesSlipNumInputDialog.StockWorkList;
				List<AcceptOdrCar> acceptOdrCarList = salesSlipNumInputDialog.AcceptOdrCarList;
				List<StockSlipWork> stockSlipWorkList = salesSlipNumInputDialog.StockSlipWorkList;
				List<StockDetailWork> stockDetailWorkList = salesSlipNumInputDialog.StockDetailWorkList;
				List<AddUpOrgStockDetailWork> addUpOrgStockDetailList = salesSlipNumInputDialog.addUpOrgStockDetailList;
                //>>>2010/02/26
                UserSCMOrderHeaderRecord scmHeader = salesSlipNumInputDialog.scmHeader;
                UserSCMOrderCarRecord scmCar = salesSlipNumInputDialog.scmCar;
                List<UserSCMOrderAnswerRecord> scmAnswerList = salesSlipNumInputDialog.scmAnswerList;
                //<<<2010/02/26

                // 見積計上処理
                //>>>2010/02/26
                //this.EstimateAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);
                this.EstimateAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList, scmHeader, scmCar, scmAnswerList);
                //<<2010/02/26

				// --- ADD 2009/12/23 ---------->>>>>
				//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
				this._salesSlipInputAcs.GetNoteCharCnt();
				SetNoteCharCnt();
				// --- ADD 2009/12/23 ----------<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		/// <summary>
		/// 見積計上処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		private void EstimateAddup(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
		{
			SalesSlip salesSlip;
			SalesSlip baseSalesSlip;
			List<SalesDetail> salesDetailList;
			List<SalesDetail> addUpSrcDetailList;
			SearchDepsitMain depsitMain;
			SearchDepositAlw depositAlw;
			List<StockWork> stockWorkList;
			List<StockSlipWork> stockSlipWorkList;
			List<StockDetailWork> stockDetailWorkList;
			List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
			List<AcceptOdrCar> acceptOdrCarList;
			List<UOEOrderDtlWork> uoeOrderDtlWorkList;
            //>>>2010/02/26
            UserSCMOrderHeaderRecord scmHeader;
            UserSCMOrderCarRecord scmCar;
            List<UserSCMOrderDetailRecord> scmDetailList;
            List<UserSCMOrderAnswerRecord> scmAnswerList;
            //<<<2010/02/26

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
			//>>>2010/02/26
            //int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList);
            int status = this._salesSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2010/02/26
            this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //>>>2010/02/26
                //this.EstimateAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList);
                this.EstimateAddup(salesSlip, salesDetailList, addUpSrcDetailList, depsitMain, depositAlw, stockSlipWorkList, stockDetailWorkList, addUpOrgStockDetailList, stockWorkList, acceptOdrCarList, scmHeader, scmCar, scmAnswerList);
                //<<2010/02/26
            }
		}

		/// <summary>
		/// 見積計上処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
		/// <param name="depsitMain">入金データオブジェクト</param>
		/// <param name="depositAlw">入金引当データオブジェクト</param>
		/// <param name="stockSlipWorkList">仕入ワークデータオブジェクトリスト</param>
		/// <param name="stockDetailWorkList">仕入明細ワークデータオブジェクトリスト</param>
		/// <param name="addUppOrgStockDetailList">同時入力計上元仕入明細ワークデータオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
		/// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
        //>>>2010/02/26
        //private void EstimateAddup(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
        private void EstimateAddup(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<SalesDetail> addUpSrcDetailList, SearchDepsitMain depsitMain, SearchDepositAlw depositAlw, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, List<AddUpOrgStockDetailWork> addUpOrgStockDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList, UserSCMOrderHeaderRecord scmHeader, UserSCMOrderCarRecord scmCar, List<UserSCMOrderAnswerRecord> scmAnswerList)
        //<<<2010/02/26
        {
			// 見積計上情報生成可能チェック処理
			string message;
			bool created = this._salesSlipInputAcs.CanCreateEstimateAddUpInfo(salesSlip, salesDetailList, out message);
			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

			SalesSlip baseSalesSlip = salesSlip.Clone();

			// 計上初期値セット前情報キャッシュ
			this._salesSlipInputAcs.CacheSalesSlipBeforeAddUp(salesSlip);

			// 見積計上情報生成処理
			this._salesSlipInputAcs.CreateEstimateAddUpInfo(ref salesSlip);

			// 表示用受注ステータスの設定
			SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 表示用伝票区分設定処理
			SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			// キャッシュ処理
            //>>>2010/02/26
            //this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList);
            this._salesSlipInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, addUpSrcDetailList, acceptOdrCarList, scmHeader, scmCar, null, scmAnswerList);
            //<<<2010/02/26

			// 見積計上明細情報生成処理
			this._salesSlipInputAcs.CreateEstimateAddUpDetailInfo(stockWorkList);

            //>>>2010/02/26
            // SCM情報補正処理
            this._salesSlipInputAcs.AdjustScmInfoForEstimateAddup();
            //<<<2010/02/26

			//// 売上数量０行削除処理
			//this._salesSlipDetailInput.DeleteStockCountZeroRow(false);

			////// 受注残数０行削除処理
			////this._salesSlipDetailInput.DeleteAcptAnOdrRemainCntZeroRow(false);

			// 空白行削除処理
			this._salesSlipDetailInput.DeleteEmptyRow(true);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細粗利率設定処理
			this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 売単価、原単価の初期値設定
			this._salesSlipInputAcs.CacheDefaultValue();

			// 明細グリッドにフォーカスをセット
			this._salesSlipDetailInput.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay);

			// Visible設定
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

			// データ変更フラグプロパティをtrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._prevControl = this.ActiveControl;
		}
		#endregion

        #region ●SCM
        /// <summary>
        /// SCM問合せ一覧選択
        /// </summary>
        /// <param name="isConfirm"></param>
        private void SCMReferenceSearch(bool isConfirm)
        {
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            long inquiryNum = 0;
            int acptAnOdrStatus = 0;
            string salesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
            string inqOriginalEpCd = string.Empty;
            string inqOriginalSecCd = string.Empty;
            int inqOrdDivCd = 0;
            // 2011/02/18 >>>
            //int answerDivCd = 0; // 2010/03/30
            short cancelDiv = 0;
            // 2011/02/18 <<<
            //bool iMsg = false;

            ////-----------------------------------------------------------------------------
            //// 確認ウインドウ
            ////-----------------------------------------------------------------------------
            //bool canSCMReferenceSearch = this.ShowSaveCheckDialog(isConfirm);

            //if (!canSCMReferenceSearch) return;

            this.tEdit_SalesEmployeeCd.Focus();
            this.ActiveControl = this.tEdit_SalesEmployeeCd;

            //-----------------------------------------------------------------------------
            // SCM問合せ一覧起動
            //-----------------------------------------------------------------------------
            PMSCM04001UA SCMReferenceDisp = new PMSCM04001UA(this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd,
                                  this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm,
                                  this._salesSlipInputAcs.SalesSlip.CustomerCode,
                                  this._salesSlipInputAcs.SalesSlip.CustomerSnm);

            //if (SCMReferenceDisp.SearchInquiryCountForSalesSlip() > 0) // 表示対象件数チェック
            //{
            //-----------------------------------------------------------------------------
            // SCM問合せ一覧画面表示
            //-----------------------------------------------------------------------------
            //>>>2011/02/01
            //DialogResult dr = SCMReferenceDisp.ShowGuideForSalesSlip(this, out inquiryNum, out acptAnOdrStatus, out salesSlipNum, out inqOriginalEpCd, out inqOriginalSecCd, out answerDivCd);
            DialogResult dr = SCMReferenceDisp.ShowGuideForSalesSlip(this, out inquiryNum, out acptAnOdrStatus, out salesSlipNum, out inqOriginalEpCd, out inqOriginalSecCd, out cancelDiv, out inqOrdDivCd);
            //<<<2011/02/01

            //-----------------------------------------------------------------------------
            // データ読み込み
            //-----------------------------------------------------------------------------
            if ((dr == DialogResult.OK) && ((inquiryNum != 0) || (salesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)))
            {
                // 2011/02/18 >>>
                ////this.SCMRead(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd); // 2010/03/30
                //this.SCMRead(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd, answerDivCd); // 2010/03/30

                this.SCMRead(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOrdDivCd, cancelDiv); //@@@@20230303
                // 2011/02/18 <<<
            }
            //}
            //else
            //{
            //    DialogResult dResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "選択対象となるデータが存在しません。",
            //        0,
            //        MessageBoxButtons.OK,
            //        MessageBoxDefaultButton.Button1);
            //}
        }

        /// <summary>
        /// SCM情報読込処理
        /// </summary>
        /// <param name="inquiryNum"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="inqOriginalEpCd"></param>
        /// <param name="inqOriginalSecCd"></param>
        /// <param name="inqOrdDivCd"></param>
        //private void SCMRead(long inquiryNum, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd)
        // 2011/02/18 >>>
        //private void SCMRead(long inquiryNum, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int answerDivCd)
        private void SCMRead(long inquiryNum, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, short cancelDiv)
        // 2011/02/18 <<<
        {
            SalesSlip salesSlip = null;
            SalesSlip baseSalesSlip;
            List<SalesDetail> salesDetailList = null;
            List<SalesDetail> addUpSrcDetailList;
            SearchDepsitMain depsitMain;
            SearchDepositAlw depositAlw;
            List<StockWork> stockWorkList;
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWorkList;
            List<AddUpOrgStockDetailWork> addUpOrgStockDetailList;
            List<AcceptOdrCar> acceptOdrCarList;
            List<UOEOrderDtlWork> uoeOrderDtlWorkList;
            UserSCMOrderHeaderRecord scmHeader = new UserSCMOrderHeaderRecord();
            UserSCMOrderCarRecord scmCar;
            List<UserSCMOrderDetailRecord> scmDetailList;
            List<UserSCMOrderAnswerRecord> scmAnswerList;

            this.Cursor = Cursors.WaitCursor;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            if (salesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)
            {
                status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, salesSlipNum, true, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpOrgStockDetailList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            }
            else
            {
                using (NowRunningProgress nowRunningProgress = new NowRunningProgress(
                    this.uStatusBar_Main.Panels[0],   // 1パラ目：ステータスバーのテキストパネル
                    this.uStatusBar_Main.Panels[1]    // 2パラ目：ステータスバーの進捗バーパネル
                ))
                {
                    //status = this._salesSlipInputAcs.SCMReadDBData(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd, out salesSlip, out salesDetailList); // 2010/03/30
                    // 2011/02/18 >>>
                    //status = this._salesSlipInputAcs.SCMReadDBData(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd, inqOriginalSecCd, inqOrdDivCd, answerDivCd, out salesSlip, out salesDetailList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList); // 2010/03/30
                    status = this._salesSlipInputAcs.SCMReadDBData(inquiryNum, acptAnOdrStatus, salesSlipNum, inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOrdDivCd, cancelDiv, out salesSlip, out salesDetailList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);//@@@@20230303
                    // 2011/02/18 <<<
                }
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DialogResult dResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "対象となるデータが存在しません。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                //>>>2010/03/30
                this._scmSave = false;

                // キャンセル時は返品として展開
                if (scmHeader.AnswerDivCd == 99)
                {
                    salesSlip.SalesSlipCd = (int)SalesSlipInputAcs.SalesSlipCd.RetGoods;
                    this._scmSave = true;
                }
                //<<<2010/03/30

                // 表示用受注ステータスの設定
                SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

                // 伝票区分コンボエディタアイテム設定処理
                this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

                // 表示用伝票区分設定処理
                SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

                this._salesSlipInputAcs.Cache(salesSlip);

                // 売上金額計算処理
                this._salesSlipDetailInput.CalculationSalesPrice();

                // 売上金額変更後発生イベント処理
                this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

                // 売上データクラスキャッシュ
                this._salesSlipInputAcs.Cache(this._salesSlipInputAcs.SalesSlip);

                // 売上データクラス→画面格納処理
                this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

                // 明細粗利率設定処理
                this._salesSlipInputAcs.SettingSalesDetailRowGrossProfitRate(salesDetailList);

                // 明細グリッド設定処理
                this._salesSlipDetailInput.SettingGrid();

                // 売単価、原単価の初期値設定
                this._salesSlipInputAcs.CacheDefaultValue();

                // 明細グリッドにフォーカスをセット
                this._salesSlipDetailInput.Focus();

                // ガイドボタンツール有効無効設定処理
                this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);

                // 伝票区分コンボエディタアイテム設定処理
                //>>>2010/03/30
                //this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatus);
                this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatus, false);
                //<<<2010/03/30

                // Visible設定
                this.SettingVisible();

                // データ変更フラグプロパティをtrueにする
                this._salesSlipInputAcs.IsDataChanged = true;

                // 明細行数制限
                this._salesSlipInputAcs.SettingSalesDetailRowInputRowCount(salesDetailList.Count);

            }
            this._prevControl = this.ActiveControl;

            this.Cursor = Cursors.Default;
        }
        #endregion

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void ExecuteGuide()
		{
			if (this._salesSlipDetailInput.ContainsFocus)
			{
				this._salesSlipDetailInput.ExecuteGuide();
			}
			else if (this._guideButton.SharedProps.Tag != null)
			{
				switch (this._guideButton.SharedProps.Tag.ToString())
				{
					//-----------------------------------------------------------------------------
					// 売上伝票番号
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SalesSlipGuide:
						{
							this.uButton_SalesSlipGuide_Click(this.uButton_SalesSlipGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 拠点
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SectionGuide:
						{
							this.uButton_SectionGuide_Click(this.uButton_SectionGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 部門
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SubSectionGuide:
						{
							this.uButton_SubSectionGuide_Click(this.uButton_SubSectionGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 担当者
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_EmployeeGuide:
						{
							this.uButton_EmployeeGuide_Click(this.uButton_EmployeeGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 受注者
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_FrontEmployeeGuide:
						{
							this.uButton_EmployeeGuide_Click(this.uButton_FrontEmployeeGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 発行者
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SalesInputGuide:
						{
							this.uButton_EmployeeGuide_Click(this.uButton_SalesInputGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 得意先
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_CustomerGuide:
						{
							this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 納入先
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_AddresseeGuide:
						{
							this.uButton_CustomerGuide_Click(this.uButton_AddresseeGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 伝票備考１
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SlipNoteGuide:
						{
							this.uButton_SlipNote_Click(this.uButton_SlipNote, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 伝票備考２
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SlipNoteGuide2:
						{
							this.uButton_SlipNote_Click(this.uButton_SlipNote2, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 伝票備考３
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_SlipNoteGuide3:
						{
							this.uButton_SlipNote_Click(this.uButton_SlipNote3, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 車種ガイド
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_ModelFullGuide:
						{
							this.uButton_ModelFullGuide_Click(this.uButton_ModelFullGuide, new EventArgs());
							break;
						}
					// --- ADD 2009/09/08② ---------->>>>>
					//-----------------------------------------------------------------------------
					// 管理番号ガイド
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_CarMngNoGuide:
						{
							this.uButton_CarMngNoGuide_Click(this.uButton_CarMngNoGuide, new EventArgs());
							break;
						}
					//-----------------------------------------------------------------------------
					// 車輌備考ガイド
					//-----------------------------------------------------------------------------
					case ctGUIDE_NAME_CarSlipNoteGuide:
						{
							this.uButton_SlipNoteGuide_Click(this.uButton_SlipNoteGuide, new EventArgs());
							break;
						}
					// --- ADD 2009/09/08② ----------<<<<<
				}
			}
		}

		/// <summary>
		/// コントロールインデックス取得処理
		/// </summary>
		/// <param name="prevCtrl">現在のコントロールの名称</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>コントロールインデックス</returns>
		private int GetControlIndex(string prevCtrl, SalesSlipInputAcs.MoveMethod mode)
		{
			int controlIndex = -1;

			switch (mode)
			{
				case SalesSlipInputAcs.MoveMethod.NextMove:
					{
						if (this._controlIndexForwordDictionary.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexForwordDictionary[prevCtrl];
						}

						break;
					}
				case SalesSlipInputAcs.MoveMethod.PrevMove:
					{
						if (this._controlIndexBackDictionary.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexBackDictionary[prevCtrl];
						}

						break;
					}
			}

			return controlIndex;
		}

		/// <summary>
		/// ネクストコントロール取得処理
		/// </summary>
		/// <param name="prevCtrl">現在のコントロール</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>次のコントロール</returns>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private Control GetNextControl(Control prevCtrl, SalesSlipInputAcs.MoveMethod mode)
		{
			Control control = null;
			Control nextCtrl = null;

			HeaderFocusConstructionList headerFocusConstructionList = this._salesInputConstructionAcs.HeaderFocusConstructionListValue;
			FooterFocusConstructionList footerFocusConstructionList = this._salesInputConstructionAcs.FooterFocusConstructionListValue; // ADD 2009/12/23
			int targetControlIndex = 0;
			int prevControlIndex = this.GetControlIndex(prevCtrl.Name, mode);

			switch (mode)
			{
				case SalesSlipInputAcs.MoveMethod.NextMove:
					{
						if (prevControlIndex < 0) return this.GetNextControlException(prevCtrl, mode);
						foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
						{
							if (!this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption)) continue;
							control = this._headerItemsDictionary[headerFocusConstruction.Caption];
							targetControlIndex = this.GetControlIndex(control.Name, mode);

							if (targetControlIndex == 0) nextCtrl = (this._detailControl.Enabled) ? this._detailControl : this._footerControl;

							if ((control.Enabled) &&
								(control.Visible) &&
								(prevCtrl != control) &&
								(prevControlIndex < targetControlIndex))
							{
								nextCtrl = control;
								//break; DEL 2009/12/23
								return nextCtrl;// ADD 2009/12/23
							}
						}
						// --- ADD m.suzuki 2010/03/10 ---------->>>>>
						// foreachの後でNextCtrlが確定していない、かつ
						// ヘッダ項目の一覧に含まれるControlならば
						// 明細部への移動を試みる。
						if (this._headerItemsDictionary.ContainsValue(prevCtrl))
						{
							if (this._detailControl.Enabled)
							{
								return this._detailControl;
							}
							// 明細入力不可ならば、処理続行してフッタ項目確定
						}
						// --- ADD m.suzuki 2010/03/10 ----------<<<<<


						// --- ADD 2009/12/23 ---------->>>>>
						bool addInfoShow = false;
						bool totalInfoShow = false;
						foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
						{
							if (!this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption)) continue;
							control = this._footerItemsDictionary[footerFocusConstruction.Caption];
							targetControlIndex = this.GetControlIndex(control.Name, mode);

							nextCtrl = prevCtrl;
							addInfoShow = false;
							totalInfoShow = false;

							if (control.Name.Equals(this.tEdit_CarSlipNote.Name) ||
								control.Name.Equals(this.tNedit_Mileage.Name))
							{
								if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true)
								{
									addInfoShow = true;
								}
							}

							if (this.uTab_Total.Contains(control))
							{
								if (this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Selected != true
									&& this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Selected == true)
								{
									totalInfoShow = true;
								}
							}

							if ((control.Enabled) &&
								(control.Visible || addInfoShow || totalInfoShow) &&
								(prevCtrl != control) &&
								(prevControlIndex < targetControlIndex))
							{
								nextCtrl = control;
								break;
							}
						}

						if ((nextCtrl.Name.Equals(this.tEdit_CarSlipNote.Name) ||
								nextCtrl.Name.Equals(this.tNedit_Mileage.Name)) && this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true &&
							this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Selected == false)
						{
							int controlIndex = -1;
							if (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) > 0 && this.GetControlIndex(this.tNedit_Mileage.Name, mode) > 0)
							{
								controlIndex = (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) > this.GetControlIndex(this.tNedit_Mileage.Name, mode)) ?
									this.GetControlIndex(this.tNedit_Mileage.Name, mode) : this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode);

								if (targetControlIndex > controlIndex)
								{
									controlIndex = (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) < this.GetControlIndex(this.tNedit_Mileage.Name, mode)) ?
									this.GetControlIndex(this.tNedit_Mileage.Name, mode) : this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode);
								}
							}
							else if (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) > 0 && this.GetControlIndex(this.tNedit_Mileage.Name, mode) < 0)
							{
								controlIndex = this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode);
							}
							else if (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) < 0 && this.GetControlIndex(this.tNedit_Mileage.Name, mode) > 0)
							{
								controlIndex = this.GetControlIndex(this.tNedit_Mileage.Name, mode);
							}

							if (prevControlIndex < this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode)
								&& (this.GetControlIndex(this.tEdit_CarSlipNote.Name, mode) == controlIndex))
							{
								// フッタタブ位置セット
								this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];

								nextCtrl = this.tEdit_CarSlipNote;
							}
							else if (prevControlIndex < this.GetControlIndex(this.tNedit_Mileage.Name, mode)
								&& (this.GetControlIndex(this.tNedit_Mileage.Name, mode) == controlIndex))
							{
								this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);

								// フッタタブ位置セット
								this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];

								nextCtrl = this.tNedit_Mileage;

								this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
							}
						}

						if (this.uTab_Total.Contains(nextCtrl) && (targetControlIndex > 0 && prevControlIndex < targetControlIndex)
							&& this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Selected == false)
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);
							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo];

							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
						}
						// --- ADD 2009/12/23 ----------<<<<<
						break;
					}
				case SalesSlipInputAcs.MoveMethod.PrevMove:
					{
						if (prevControlIndex < 0) return this.GetNextControlException(prevCtrl, mode);
						bool addInfoShow = false;
						bool totalInfoShow = false;

						// --- ADD 2009/12/23 ---------->>>>>
						for (int count = footerFocusConstructionList.footerFocusConstruction.Count - 1; count >= 0; count--)
						{
							FooterFocusConstruction footerFocusConstruction = footerFocusConstructionList.footerFocusConstruction[count];

							if (!this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption)) continue;

							control = this._footerItemsDictionary[footerFocusConstruction.Caption];

							addInfoShow = false;
							totalInfoShow = false;
							if (control.Name.Equals(this.tEdit_CarSlipNote.Name) ||
								control.Name.Equals(this.tNedit_Mileage.Name))
							{
								if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true)
								{
									addInfoShow = true;
								}
							}

							if (this.uTab_Total.Contains(control))
							{
								if (this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Selected != true
									&& this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Selected == true)
								{
									totalInfoShow = true;
								}
							}

							if ((control.Enabled) &&
								(control.Visible || addInfoShow || totalInfoShow) &&
								(prevCtrl != control) &&
								(prevControlIndex < this.GetControlIndex(control.Name, mode)))
							{
								nextCtrl = control;
								break;
							}
						}

						if (this.uTab_Total.Contains(nextCtrl) && this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Visible == true &&
							this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Selected == false)
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);

							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo];

							for (int count = footerFocusConstructionList.footerFocusConstruction.Count - 1; count >= 0; count--)
							{
								FooterFocusConstruction footerFocusConstruction = footerFocusConstructionList.footerFocusConstruction[count];

								if (!this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption)) continue;

								control = this._footerItemsDictionary[footerFocusConstruction.Caption];

								if ((control.Enabled) &&
									(control.Visible) &&
									(prevCtrl != control) &&
									(prevControlIndex < this.GetControlIndex(control.Name, mode)))
								{
									nextCtrl = control;
									break;
								}
							}

							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
							break;
						}
						else if (nextCtrl != null && this.uTab_Add.Contains(nextCtrl) && addInfoShow)
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);
							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];

							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
						}

						if (nextCtrl != null) return nextCtrl;
						// --- ADD 2009/12/23 ----------<<<<<

						for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
						{
							HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];

							if (!this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption)) continue;

							control = this._headerItemsDictionary[headerFocusConstruction.Caption];

							if ((control.Enabled) &&
								(control.Visible) &&
								(prevCtrl != control) &&
								(prevControlIndex < this.GetControlIndex(control.Name, mode)))
							{
								nextCtrl = control;
								//break; DEL 2009/12/23
								return nextCtrl;// ADD 2009/12/23
							}
						}
						break;
					}
			}

			if (nextCtrl == null || nextCtrl.Visible == false) nextCtrl = this.GetNextControlException(prevCtrl, mode);

			return nextCtrl;
		}

		/// <summary>
		/// ネクストコントロール取得処理
		/// </summary>
		/// <param name="prevCtrl">現在のコントロール</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>次のコントロール</returns>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private Control GetNextControlException(Control prevCtrl, SalesSlipInputAcs.MoveMethod mode)
		{
			Control control = null;
			Control nextCtrl = null;

			HeaderFocusConstructionList headerFocusConstructionList = this._salesInputConstructionAcs.HeaderFocusConstructionListValue;
			FooterFocusConstructionList footerFocusConstructionList = this._salesInputConstructionAcs.FooterFocusConstructionListValue; // ADD 2009/12/23
			bool selectFlg = false;

			switch (mode)
			{
				case SalesSlipInputAcs.MoveMethod.NextMove:
					{
						foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
						{
							if (!this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption)) continue;
							control = this._headerItemsDictionary[headerFocusConstruction.Caption];

							if (selectFlg)
							{
								if ((control.Enabled) && (control.Visible))
								{
									nextCtrl = control;
									//break; DEL 2009/12/23
									return nextCtrl;// ADD 2009/12/23
								}
								else
								{
									nextCtrl = this.GetNextControlException(control, mode);
									break;
								}
							}
							if (prevCtrl == control) selectFlg = true;
						}
						if (nextCtrl != null) return nextCtrl;

						// --- ADD m.suzuki 2010/03/10 ---------->>>>>
						// foreachの後でNextCtrlが確定していない、かつ
						// ヘッダ項目の一覧に含まれるControlならば
						// 明細部への移動を試みる。
						if (this._headerItemsDictionary.ContainsValue(prevCtrl))
						{
							if (this._detailControl.Enabled)
							{
								return this._detailControl;
							}
							// 明細入力不可ならば、処理続行してフッタ項目確定
						}
						// --- ADD m.suzuki 2010/03/10 ----------<<<<<

						// --- ADD 2009/12/23 ---------->>>>>
						bool addInfoShow = false;
						foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
						{
							if (!this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption)) continue;
							control = this._footerItemsDictionary[footerFocusConstruction.Caption];
							nextCtrl = prevCtrl;

							addInfoShow = false;
							if (control.Name.Equals(this.tEdit_CarSlipNote.Name) ||
								control.Name.Equals(this.tNedit_Mileage.Name))
							{
								if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true)
								{
									addInfoShow = true;
								}
							}

							if (selectFlg)
							{
								if ((control.Enabled) && (control.Visible || addInfoShow) && (this.GetControlIndex(control.Name, mode) > 0))
								{
									nextCtrl = control;
									break;
								}
								//else
								//{
								//    nextCtrl = this.GetNextControlException(control, mode);
								//    break;
								//}
							}
							if (prevCtrl == control) selectFlg = true;
						}

						if ((nextCtrl.Name.Equals(this.tEdit_CarSlipNote.Name) ||
							nextCtrl.Name.Equals(this.tNedit_Mileage.Name)) && this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true &&
							this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Selected == false)
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);
							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];
							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
						}
						// --- ADD 2009/12/23 ----------<<<<<

						if (nextCtrl == null) nextCtrl = (this._detailControl.Enabled) ? this._detailControl : this._footerControl;
						break;
					}
				case SalesSlipInputAcs.MoveMethod.PrevMove:
					{
						for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
						{
							HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];
							if (!this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption)) continue;
							control = this._headerItemsDictionary[headerFocusConstruction.Caption];

							if (selectFlg)
							{
								if ((control.Enabled) && (control.Visible))
								{
									nextCtrl = control;
									//break; DEL 2009/12/23
									return nextCtrl;// ADD 2009/12/23
								}
								else
								{
									nextCtrl = this.GetNextControlException(control, mode);
									break;
								}
							}
							if (prevCtrl == control) selectFlg = true;
						}

						// --- ADD 2009/12/23 ---------->>>>>
						for (int count = footerFocusConstructionList.footerFocusConstruction.Count - 1; count >= 0; count--)
						{
							FooterFocusConstruction footerFocusConstruction = footerFocusConstructionList.footerFocusConstruction[count];
							if (!this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption)) continue;
							control = this._footerItemsDictionary[footerFocusConstruction.Caption];

							if (selectFlg)
							{
								if ((control.Enabled) && (control.Visible))
								{
									nextCtrl = control;
									break;
								}
								else
								{
									nextCtrl = this.GetNextControlException(control, mode);
									break;
								}
							}
							if (prevCtrl == control) selectFlg = true;
						}

						// --- ADD 2009/12/23 ----------<<<<<

						if (nextCtrl == null) nextCtrl = prevCtrl;
						break;
					}
			}

			return nextCtrl;
		}

		/// <summary>
		/// ヘッダー部 フォーカス先頭コントロール取得処理
		/// </summary>
		/// <returns>先頭コントロール</returns>
		private Control GetHeaderFirstControl()
		{
			Control retControl = null;

			if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_AcptAnOdrStatus) && (this.tComboEditor_AcptAnOdrStatusDisplay.Enabled) && (this.tComboEditor_AcptAnOdrStatusDisplay.Visible))
			{
				retControl = tComboEditor_AcptAnOdrStatusDisplay;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_CustomerCode) && (this.tNedit_CustomerCode.Enabled) && (this.tNedit_CustomerCode.Visible))
			{
				retControl = tNedit_CustomerCode;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_FrontEmployeeCd) && (this.tEdit_FrontEmployeeCd.Enabled) && (this.tEdit_FrontEmployeeCd.Visible))
			{
				retControl = tEdit_FrontEmployeeCd;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesEmployeeCd) && (this.tEdit_SalesEmployeeCd.Enabled) && (this.tEdit_SalesEmployeeCd.Visible))
			{
				retControl = tEdit_SalesEmployeeCd;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesInputCd) && (this.tEdit_SalesInputCode.Enabled) && (this.tEdit_SalesInputCode.Visible))
			{
				retControl = tEdit_SalesInputCode;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesSlipNum) && (this.tNedit_SalesSlipNum.Enabled) && (this.tNedit_SalesSlipNum.Visible))
			{
				retControl = tNedit_SalesSlipNum;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SectionCode) && (this.tEdit_SectionCode.Enabled) && (this.tEdit_SectionCode.Visible))
			{
				retControl = tEdit_SectionCode;
			}
			else
			{
				HeaderFocusConstructionList headerFocusConstructionList = this._salesInputConstructionAcs.HeaderFocusConstructionListValue;

				foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
				{
					Control ctrl = this._headerItemsDictionary[headerFocusConstruction.Caption];
					if ((ctrl != null) && (ctrl.Enabled) && (ctrl.Visible))
					{
						retControl = ctrl;
						break;
					}
				}
			}

			return retControl;
		}

		/// <summary>
		/// フッター部 フォーカス先頭コントロール取得処理
		/// </summary>
		/// <returns>先頭コントロール</returns>
		/// <br>Note       :  フッター部 フォーカス先頭コントロール取得処理</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2010/02/02</br>
		private Control GetFooterFirstControl()
		{
			Control retControl = null;

			FooterFocusConstructionList footerFocusConstructionList = this._salesInputConstructionAcs.FooterFocusConstructionListValue;

			foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
			{
				Control ctrl = this._footerItemsDictionary[footerFocusConstruction.Caption];
				if ((ctrl != null) && (ctrl.Enabled))
				{
					if (this.uTab_Total.Contains(ctrl))
					{
						if (this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo].Selected == true)
						{
							if (ctrl.Visible)
							{
								retControl = ctrl;
								break;
							}
						}
						else
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);
							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_TotalInfo];
							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
							if (ctrl.Visible)
							{
								retControl = ctrl;
								break;
							}
						}
					}
					else if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true
						&& this.uTab_Add.Contains(ctrl))
					{
						if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Selected == true)
						{
							if (ctrl.Visible)
							{
								retControl = ctrl;
								break;
							}
						}
						else
						{
							this.TabChanged -= new TabChangeEventHandler(this.FooterTabChanged);
							// フッタタブ位置セット
							this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];
							this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
							if (ctrl.Visible)
							{
								retControl = ctrl;
								break;
							}
						}
					}
				}
			}

			return retControl;
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			// 得意先設定処理
			this.SettingCustomer(false, customerSearchRet);

			// 納入先設定処理
			this.SettingAddressee(false, customerSearchRet);
		}

		/// <summary>
		/// 得意先設定処理
		/// </summary>
		/// <param name="isClear">true:クリアする false:クリアしない</param>
		/// <param name="seldata">得意先検索結果クラス</param>
		private void SettingCustomer(bool isClear, CustomerSearchRet seldata)
		{
			if (isClear)
			{
				// 画面初期化処理
				bool canClear = this.Clear(true, true);

				if (!canClear) return;
			}
			else
			{
				if (!this.tNedit_CustomerCode.Enabled)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"選択中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "伝票に対して得意先を変更することができません。",
						-1,
						MessageBoxButtons.OK);

					return;
				}
			}

			// 得意先を自動で設定
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

			bool reCalcStockUnitPrice = false;
			bool clearRateInfo = false;
			CustomerInfo customerInfo;
			this.Cursor = Cursors.WaitCursor;
			DialogResult dialogResult = DialogResult.No;
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, seldata.EnterpriseCode, seldata.CustomerCode, true, false, out customerInfo);

			// 得意先チェック
			if (customerInfo != null)
			{
				if (customerInfo.IsCustomer != true)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			this.Cursor = Cursors.Default;

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
				(!this._salesSlipInputAcs.CheckTransStopDate(customerInfo.TransStopDate)))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"取引停止中により設定できません。",
					-1,
					MessageBoxButtons.OK);
				return;
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				bool settingFlg = false;
				if ((this._salesSlipInputAcs.ExistSalesDetail()) &&
					(salesSlip.CustomerCode != 0) &&
					(customerInfo.AccRecDivCd != salesSlip.AccRecDivCd))
				{
					dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"売掛得意先と現金得意先間のコード変更です。" + "\r\n" + "\r\n" +
						this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
						"よろしいですか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult == DialogResult.Yes)
					{
						settingFlg = true;
						this._salesSlipDetailInput.Clear();
						this._salesSlipInputAcs.ClearCarInfo();
						this.ClearDisplayCarInfo();
					}
				}
				else
				{
					settingFlg = true;
				}

				if (settingFlg)
				{

					// 得意先情報設定処理
					this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);

					// 得意先掛率グループ再セット
					this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

					// 担当者情報設定処理
					this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, salesSlip.SalesEmployeeCd);

					// 売上明細データセッティング処理（課税区分設定）
					this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

					if ((salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
						(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
					{
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"得意先が変更されました。" + "\r\n" + "\r\n" +
							"商品価格を再取得しますか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							reCalcStockUnitPrice = true;
						}
						else
						{
							clearRateInfo = true;
						}

					}
				}

			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"得意先が存在しません。",
					-1,
					MessageBoxButtons.OK);
				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);
				return;
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// 得意先情報画面格納処理
			this.SetDisplayCustomerInfo(customerInfo);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// データ変更フラグプロパティをTrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			if (reCalcStockUnitPrice)
			{
				List<List<GoodsUnitData>> goodsUnitDataListList;
				string msg;
				this._salesSlipInputAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(out goodsUnitDataListList, out msg);
				this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(goodsUnitDataListList);
			}

			//---------------------------------------------------------------
			// 掛率情報クリア
			//---------------------------------------------------------------
			if (clearRateInfo)
			{
				// 掛率情報クリア
				this._salesSlipInputAcs.ClearAllRateInfo();
			}

			this._salesSlipDetailInput.SetToolbarButton -= new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();
			this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
		}

		/// <summary>
		/// 納入先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_AddresseeSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			// 納入先設定処理
			this.SettingAddressee(false, customerSearchRet);
		}

		/// <summary>
		/// 納入先設定処理
		/// </summary>
		/// <param name="isClear">true:クリアする false:クリアしない</param>
		/// <param name="seldata">得意先検索結果クラス</param>
		private void SettingAddressee(bool isClear, CustomerSearchRet seldata)
		{
			if (isClear)
			{
				// 画面初期化処理
				bool canClear = this.Clear(true, true);

				if (!canClear) return;
			}
			else
			{
				if (!this.tNedit_CustomerCode.Enabled)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"選択中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "伝票に対して納入先を変更することができません。",
						-1,
						MessageBoxButtons.OK);

					return;
				}
			}

			// 得意先を自動で設定
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

			CustomerInfo customerInfo;
			this.Cursor = Cursors.WaitCursor;
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, seldata.EnterpriseCode, seldata.CustomerCode, true, false, out customerInfo);

			// 得意先チェック
			if (customerInfo != null)
			{
				if ((customerInfo.IsCustomer != true) && (customerInfo.IsReceiver != true))
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{

				// 得意先（仕入先）情報設定処理
				this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);

			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"得意先が存在しません。",
					-1,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

				return;
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// データ変更フラグプロパティをTrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			this._salesSlipDetailInput.SetToolbarButton -= new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();
			this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
		}

		/// <summary>
		/// 保存確認ダイアログ表示処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <returns>確認後OK 確認後NG</returns>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private bool ShowSaveCheckDialog(bool isConfirm)
		{
			bool checkedValue = false;

			if ((isConfirm) && (this._salesSlipInputAcs.IsDataChanged))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"登録してもよろしいですか？",
					0,
					MessageBoxButtons.YesNoCancel,
					// --- UPD 2009/11/24 ---------->>>>>
					//MessageBoxDefaultButton.Button1);
					MessageBoxDefaultButton.Button2);
				// --- UPD 2009/11/24 ----------<<<<<

				if (dialogResult == DialogResult.Yes)
				{
					SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▼▼▼保存処理　開始");
					// --- UPD 2009/12/23 ---------->>>>>
					//checkedValue = this.Save(true);
					checkedValue = this.Save(true, false);
					// --- UPD 2009/12/23 ----------<<<<<
					SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▲▲▲保存処理　終了");
				}
				else if (dialogResult == DialogResult.No)
				{
					checkedValue = true;
				}
				else
				{
					//
				}
			}
			else
			{
				checkedValue = true;
			}

			return checkedValue;
		}

		/// <summary>
		/// 売上データ入力モード設定処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		private void SettingStockSlipInputMode(ref SalesSlip salesSlip)
		{
			/*
			if (stockSlip.DebitNoteDiv == 1)
			{
				// 赤伝の場合は何もしない
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"既に「赤伝」が発行されている為、編集できません。" + "\r\n" + "\r\n" + "参照モードで表示します。",
					-1,
					MessageBoxButtons.OK);

				stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly;
			}
			else if (stockSlip.TrustAddUpSpCd == 2)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"「売上時自動作成伝票」の為、編集できません。" + "\r\n" + "\r\n" + "参照モードで表示します。",
					-1,
					MessageBoxButtons.OK);

				stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly;
			}
			//else if (stockSlip.SupplierSlipCd == 10)
			else
			{
				bool isAddUp = false;
				if (stockSlip.SupplierFormal == 0)
				{
					string message;
					isAddUp = this._stockSlipInputAcs.CheckAddUp(stockSlip, 1, out message);

					if (isAddUp)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							message + "\r\n" + "\r\n" + "参照モードで表示します。",
							-1,
							MessageBoxButtons.OK);

						stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp;
					}
				}

				if (!isAddUp)
				{
					bool exist = this._stockSlipInputAcs.ExistAllReadonlyRow();

					if (exist)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"「在庫状態」が変更されているか、または「在庫移動」が行われている商品が存在する為、" + "\r\n" + "編集出来ない項目があります。" + "\r\n" + "\r\n" +
							"詳細を確認する場合は、商品の数量にマウスカーソルを合わせて下さい。",
							-1,
							MessageBoxButtons.OK);

						stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ChangeStockStatus;
					}
				}

				//bool check = false;
				//List<int> stockStateList = new List<int>();
				//stockStateList.Add((int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods);
				//bool existReturnedGoods = this._stockSlipInputAcs.ExistStockStateProductStockRow(stockStateList, true, true);

				//if (existReturnedGoods)
				//{
				//    TMsgDisp.Show(
				//        this,
				//        emErrorLevel.ERR_LEVEL_INFO,
				//        this.Name,
				//        "「返品」が発生している為、編集出来ない項目があります。",
				//        -1,
				//        MessageBoxButtons.OK);

				//    stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ChangeStockStatus;
				//    check = true;
				//}
			}
			 */
		}

		///// <summary>
		///// 初期データ設定処理
		///// </summary>
		///// <param name="salesSlip">売上データオブジェクト</param>

		/// <summary>
		/// 初期データ設定処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="keepCustomer">true:得意先情報を保持する false:保持しない</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		//private void SettingInitData(SalesSlip salesSlip) // 2009/09/10 DEL
		private void SettingInitData(SalesSlip salesSlip, bool keepCustomer) // 2009/09/10 ADD
		{
			#region 見積初期値設定情報
			this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
			#endregion

			// 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//#region 前回情報表示有無
			//if (this._salesInputConstructionAcs.SaveInfoStoreValue == SalesSlipInputConstructionAcs.SaveInfoStore_OFF) return;
			//#endregion

			if (!keepCustomer)
			{
				#region 前回情報表示有無
				if (this._salesInputConstructionAcs.SaveInfoStoreValue == SalesSlipInputConstructionAcs.SaveInfoStore_OFF) return;
				#endregion
			}
			// 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			this._salesSlipInputInitData.Deserialize();

			#region 得意先情報
			//-------------------------------------------------
			// 得意先
			//-------------------------------------------------
			if (this._enterpriseCode == this._salesSlipInputInitData.EnterpriseCode)
			{
				if (this._salesSlipInputInitData.CustomerCode != 0)
				{

					CustomerInfo customerInfo = null;
					this.Cursor = Cursors.WaitCursor;
					int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					SalesSlipInputInitDataAcs.LogWrite("▼得意先マスタＲｅａｄ開始");
					if (this._salesSlipInputInitData.CustomerCode != 0)
					{
						status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._salesSlipInputInitData.CustomerCode, true, false, out customerInfo);
					}
					SalesSlipInputInitDataAcs.LogWrite("▲得意先マスタＲｅａｄ終了");

					// 得意先チェック
					if (customerInfo != null)
					{
						if (customerInfo.IsCustomer != true)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						}
					}

					this.Cursor = Cursors.Default;

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// 得意先情報設定処理
						this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);

						// 得意先掛率グループ再セット
						this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

						// 売上明細データセッティング処理（課税区分設定）
						this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

						// 得意先情報画面格納処理
						this.SetDisplayCustomerInfo(customerInfo);

						// 納入先情報設定処理
						this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);

						this.SettingVisible();

						// --- ADD 2009/09/08② ---------->>>>>
						//追加情報タブ項目Visible設定
						SettingAddInfoVisible();
						// --- ADD 2009/09/08② ----------<<<<<
					}

				}
			}
			#endregion
		}
		# endregion

        //>>>2010/02/26
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="keepCustomer"></param>
        private void SettingInitData(SalesSlip salesSlip, int customerCode)
        {
            #region 見積初期値設定情報
            this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
            #endregion

            #region 得意先情報
            //-------------------------------------------------
            // 得意先
            //-------------------------------------------------

            if (customerCode != 0)
            {

                CustomerInfo customerInfo = null;
                this.Cursor = Cursors.WaitCursor;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, customerCode, true, false, out customerInfo);

                // 得意先チェック
                if (customerInfo != null)
                {
                    if (customerInfo.IsCustomer != true)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                this.Cursor = Cursors.Default;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先情報設定処理
                    this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);

                    // 得意先掛率グループ再セット
                    this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

                    // 売上明細データセッティング処理（課税区分設定）
                    this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

                    // 得意先情報画面格納処理
                    this.SetDisplayCustomerInfo(customerInfo);

                    // 納入先情報設定処理
                    this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);

                    this.SettingVisible();

                    // --- ADD 2009/09/08② ---------->>>>>
                    //追加情報タブ項目Visible設定
                    SettingAddInfoVisible();
                    // --- ADD 2009/09/08② ----------<<<<<
                }

            }

            #endregion
        }
        //<<<2010/02/26

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
		/// <br>             単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
		private void MAHNB01010UA_Load(object sender, EventArgs e)
		{
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "▼▼▼▼▼開始▼▼▼▼▼");

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "Skinの設定");
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			this._controlScreenSkin.SettingScreenSkin(this._salesSlipDetailInput);

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "明細コントロールのロード");
			// 売上明細画面追加
			this.panel_DetailInput.Controls.Add(this._salesSlipDetailInput);
			this._salesSlipDetailInput.Dock = DockStyle.Fill;

			// 諸元情報データソース追加
			this.ultraGrid_CarSpec.DataSource = this._carSpecDataTable;

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "カラー・トリム・装備情報コントロールのロード");
			// カラー・トリム・装備情報画面追加
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this._carOtherInfoInput);
			this._carOtherInfoInput.Dock = DockStyle.Fill;




			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ツールバー初期設定処理");
			// ツールバー初期設定処理
			ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.tToolbarsManager_MainMenu);

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ボタン初期設定処理");
			// ボタン初期設定処理
			this.ButtonInitialSetting();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "フォーカス移動設定処理");
			// フォーカス移動設定処理
			this.SettingFocusDictionary();




			//-----------------------------------------------------------------------------
			// 初期データ取得が終了するで待つ
			//-----------------------------------------------------------------------------
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThread 待ち");
            //>>>2010/02/26
            //while (this._readInitialThread.ThreadState == ThreadState.Running)
            while (this._readInitialThread.ThreadState == System.Threading.ThreadState.Running)
            //<<<2010/02/26
            {
				Thread.Sleep(100);
			}
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThread 終了");

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThreadSecond 待ち");
            //>>>2010/02/26
            //while (this._readInitialThreadSecond.ThreadState == ThreadState.Running)
            while (this._readInitialThreadSecond.ThreadState == System.Threading.ThreadState.Running)
            //<<<2010/02/26
            {
				Thread.Sleep(100);
			}
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThreadSecond 終了");

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThreadThird 待ち");
            //>>>2010/02/26
            //while (this._readInitialThreadThird.ThreadState == ThreadState.Running)
            while (this._readInitialThreadThird.ThreadState == System.Threading.ThreadState.Running)
            //<<<2010/02/26
            {
				Thread.Sleep(100);
			}
			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ReadInitialThreadThird 終了");



			this._salesSlipInputInitDataAcs.CacheSalesProcMoneyListCall();
			this._salesSlipInputInitDataAcs.CacheStockProcMoneyListCall();
			this._salesSlipInputInitDataAcs.CacheRateProtyMngListCall(); // ADD 2010/03/01

			// 処理区分マスタリスト設定
			this._salesSlipInputInitDataAcs.SettingProcMoney();

			// 各種マスタチェック
			if (!this.InitMstCheck()) this.timer_Close.Enabled = true;

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "初期値補正");
			#region 初期値補正
			// 部門有無
			if (this._salesSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
			{
				if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionCode.Text.Trim()))
				{
					this._headerItemsDictionary.Remove(this.uLabel_SubSectionCode.Text.Trim());
				}
			}

			// 仕入伝票削除区分
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				this._salesSlipInputAcs.SupplierSlipDelDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierSlipDelDiv; // 0:しない 1:確認 2:する
			}
			else
			{
				this._salesSlipInputAcs.SupplierSlipDelDiv = 1; // 0:しない 1:確認 2:する
			}
			#endregion

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ボタン初期設定処理");
			// ボタン初期設定処理
			this._salesSlipDetailInput.ButtonInitialSetting();

			//SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "売上明細画面クリア処理");
			//// 売上明細画面クリア処理
			//this._salesSlipDetailInput.Clear();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "オプション情報反映処理");
			// オプション情報反映処理
			this._salesSlipDetailInput.SettingOptionInfo();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ツールバー初期設定処理");
			// ツールバー初期設定処理
			this.ToolBarInitilSetting();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "コンボエディタアイテム初期設定処理");
			// コンボエディタアイテム初期設定処理
			this.ComboEditorItemInitialSetting();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "得意先情報画面格納処理");
			// 得意先情報画面格納処理
			this.SetDisplayCustomerInfo(null);

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "画面項目Visible設定");
			// Visible設定
			this.SettingVisible();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "画面項目名称設定処理");
			// 画面項目名称設定処理
			this.DisplayNameSetting();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "セキュリティ権限による制御設定");
			// セキュリティ権限による制御開始(ツールバーボタン)
			this.BeginControllingByOperationAuthority();

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "メイン画面クリア処理");
			// クリア処理
			bool canClear = this.Clear(false, false);

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブを非表示
			this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = false;
			// --- ADD 2009/09/08② ----------<<<<<

			if (canClear)
			{
				this.timer_InitialSetFocus.Enabled = true;
			}
			else
			{
				this.timer_Close.Enabled = true;
			}

			// フッター選択タブ変更デリゲードの挿入（画面起動時に発生させない為このタイミング）
			this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);

			// --- ADD 2009/12/23 ---------->>>>>
			//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
			this._salesSlipInputAcs.GetNoteCharCnt();
			SetNoteCharCnt();
			// --- ADD 2009/12/23 ----------<<<<<

			SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "▲▲▲▲▲終了▲▲▲▲▲" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
		}

        //>>>2010/02/26
        /// <summary>
        /// オプション情報反映処理
        /// </summary>
        public void SettingOptionInfo()
        {
            #region ●SCMオプション
            if (this._salesSlipInputInitDataAcs.Opt_SCM == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                this._referenceListButton.SharedProps.Visible = true;
                this._replyTransactionButton.SharedProps.Visible = true;
            }
            else
            {
                this._referenceListButton.SharedProps.Visible = false;
                this._replyTransactionButton.SharedProps.Visible = false;
            }
            #endregion
        }
        //<<<2010/02/26

		/// <summary>
		/// 初期取得マスタ取得チェック
		/// </summary>
		/// <returns></returns>
		private bool InitMstCheck()
		{
			bool ret = true;
			string mstName = string.Empty;


			if (this._salesSlipInputInitDataAcs.GetAllDefSet() == null) mstName = "全体初期値設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetAcptAnOdrTtlSt() == null) mstName = "受発注管理全体設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() == null) mstName = "売上全体設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetEstimateDefSet() == null) mstName = "見積初期値設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetStockTtlSt() == null) mstName = "仕入在庫全体設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetTaxRateSet() == null) mstName = "税率設定マスタ";
			if (this._salesSlipInputInitDataAcs.GetPosTerminalMg() == null) mstName = "端末管理マスタ";
			if (this._salesSlipInputInitDataAcs.GetMinCode_FormUserCd(SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv) == 0) mstName = "ユーザーガイドマスタ(納品区分)";
			if (mstName != string.Empty)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					mstName + "の登録を行って下さい。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				ret = false;
			}

			return ret;
		}

		/// <summary>
		/// 画面項目Visible設定
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2010/05/20 姜凱 備考２と備考３のリテラル表示は、項目の表示と同様に、売上全体設定で備考２と備考３ありの時に表示するように変更</br>
		private void SettingVisible()
		{
			#region 年式
			if (this._salesSlipInputInitDataAcs.GetAllDefSet() != null)
			{
				if (this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1 == 0)
				{
					// 西暦
					this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.df4Y2M;
				}
				else
				{
					// 和歴
					this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.dfG2Y2M;
				}
			}
			#endregion

			#region 粗利情報
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitDspCd == 1) || // 粗利表示区分(0:する 1:しない)
					(this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd == 0) || // 原価表示区分(0:しない 1:する)
					((this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) && (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost == 2)) || // 伝票修正区分(原価)(2:未使用)
					((this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) && (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost == 2)) || // 返品伝票修正区分(原価)(2:未使用)
					(this._salesSlipInputAcs.CostDisplay == false))
				{
					this.uLabel_TotalGrossProfit.Visible = false;
					this.uLabel_TotalGrossProfitTitle.Visible = false;
					this.uLabel_DetailGrossProfitRateTitle.Visible = false;
					this.uLabel_DetailGrossProfitRate.Visible = false;
					this.uLabel_TotalGrossProfitRate.Visible = false;
					this.uLabel_TotalGrossProfitRateTitle.Visible = false;
					// --- ADD 2009/09/08② ---------->>>>>
					this.uLabel_AddTotalGrossProfit.Visible = false;
					this.uLabel_AddTotalGrossProfitTitle.Visible = false;
					this.uLabel_AddDetailGrossProfitRate.Visible = false;
					this.uLabel_AddDetailGrossProfitRateTitle.Visible = false;
					this.uLabel_AddTotalGrossProfitRate.Visible = false;
					this.uLabel_AddTotalGrossProfitRateTitle.Visible = false;
					// --- ADD 2009/09/08② ----------<<<<<
				}
				else
				{
					this.uLabel_TotalGrossProfit.Visible = true;
					this.uLabel_TotalGrossProfitTitle.Visible = true;
					this.uLabel_DetailGrossProfitRateTitle.Visible = true;
					this.uLabel_DetailGrossProfitRate.Visible = true;
					this.uLabel_TotalGrossProfitRate.Visible = true;
					this.uLabel_TotalGrossProfitRateTitle.Visible = true;
					// --- ADD 2009/09/08② ---------->>>>>
					this.uLabel_AddTotalGrossProfit.Visible = true;
					this.uLabel_AddTotalGrossProfitTitle.Visible = true;
					this.uLabel_AddDetailGrossProfitRate.Visible = true;
					this.uLabel_AddDetailGrossProfitRateTitle.Visible = true;
					this.uLabel_AddTotalGrossProfitRate.Visible = true;
					this.uLabel_AddTotalGrossProfitRateTitle.Visible = true;
					// --- ADD 2009/09/08② ----------<<<<<
				}
			}
			#endregion

			#region 原価情報
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().CostDspDivCd == 0) || // 原価表示区分(0:しない 1:する)
					((this._salesSlipInputAcs.SalesSlip.SalesSlipCd != (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) && (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipChngDivCost == 2)) || // 伝票修正区分(原価)(2:未使用)
					((this._salesSlipInputAcs.SalesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) && (this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetSlipChngDivCost == 2)) || // 返品伝票修正区分(原価)(2:未使用)
					(this._salesSlipInputAcs.CostDisplay == false))
				{
					this.uLabel_TotalCost.Visible = false;
					this.uLabel_TotalCostTitle.Visible = false;
					// --- ADD 2009/09/08② ---------->>>>>
					this.uLabel_AddTotalCost.Visible = false;
					this.uLabel_AddTotalCostTitle.Visible = false;
					// --- ADD 2009/09/08② ----------<<<<<
				}
				else
				{
					this.uLabel_TotalCost.Visible = true;
					this.uLabel_TotalCostTitle.Visible = true;
					// --- ADD 2009/09/08② ---------->>>>>
					this.uLabel_AddTotalCost.Visible = true;
					this.uLabel_AddTotalCostTitle.Visible = true;
					// --- ADD 2009/09/08② ----------<<<<<
				}
			}
			#endregion

			#region 得意先注番
            //>>>2010/02/26
            //if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
            //{
            //    switch (this._salesSlipInputAcs.SalesSlip.CustOrderNoDispDiv)
            //    {
            //        // しない
            //        case 0:
            //            this.panel_PartySaleSlipNum.Visible = false;
            //            break;
            //        // する
            //        case 1:
            //            this.panel_PartySaleSlipNum.Visible = true;
            //            break;
            //    }
            //}

            if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
            {
                if (this._salesSlipInputAcs.SalesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.None)
                {
                    switch (this._salesSlipInputAcs.SalesSlip.CustOrderNoDispDiv)
                    {
                        // しない
                        case 0:
                            this.panel_PartySaleSlipNum.Visible = false;
                            break;
                        // する
                        case 1:
                            this.panel_PartySaleSlipNum.Visible = true;
                            break;
                    }
                }
                else
                {
                    this.panel_PartySaleSlipNum.Visible = false;
                }
            }
            //<<<2010/02/26
            #endregion

            //>>>2010/02/26
            #region SCM情報
            if ((this._salesSlipInputAcs.SalesSlip.OnlineKindDiv != (int)SalesSlipInputAcs.OnlineKindDiv.None) &&
                (this._salesSlipInputInitDataAcs.Opt_SCM == (int)SalesSlipInputInitDataAcs.Option.ON))
            {
                this.panel_InquiryNumber.Visible = true;
            }
            else
            {
                this.panel_InquiryNumber.Visible = false;
            }
            #endregion
            //<<<2010/02/26

			#region 車両管理番号
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv)
				{
					// しない
					case 0:
						this.panel_CarMngNo.Visible = false;
						break;
					// する
					case 1:
						this.panel_CarMngNo.Visible = true;
						break;
				}
			}
			#endregion

			#region 受注者
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrAgentDispDiv)
				{
					// あり
					case 0:
						panel_FrontEmployee.Visible = true;
						break;
					// なし
					case 1:
						panel_FrontEmployee.Visible = false;
						break;
					// 必須
					case 2:
						panel_FrontEmployee.Visible = true;
						break;
					default:
						panel_FrontEmployee.Visible = true;
						break;
				}
			}
			else
			{
				panel_FrontEmployee.Visible = true;
			}
			#endregion

			#region 発行者
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpAgentDispDiv)
				{
					// あり
					case 0:
						panel_SalesInput.Visible = true;
						break;
					// なし
					case 1:
						panel_SalesInput.Visible = false;
						break;
					// 必須
					case 2:
						panel_SalesInput.Visible = true;
						break;
					default:
						panel_SalesInput.Visible = true;
						break;
				}
			}
			else
			{
				panel_SalesInput.Visible = true;
			}
			#endregion

			#region 伝票備考２
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().BrSlipNote2DispDiv)
				{
					// あり
					case 0:
						panel_SlipNote2.Visible = true;
						uLabel_SlipNote1.Visible = true;// ADD 2010/05/20
						break;
					// なし
					case 1:
						panel_SlipNote2.Visible = false;
						uLabel_SlipNote1.Visible = false;// ADD 2010/05/20
						break;
					default:
						panel_SlipNote2.Visible = true;
						uLabel_SlipNote1.Visible = true;// ADD 2010/05/20
						break;
				}
			}
			else
			{
				panel_SlipNote2.Visible = true;
				uLabel_SlipNote1.Visible = true;// ADD 2010/05/20
			}
			#endregion

			#region 伝票備考３
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
			{
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().BrSlipNote3DispDiv)
				{
					// あり
					case 0:
						panel_SlipNote3.Visible = true;
						uLabel_SlipNote2.Visible = true;// ADD 2010/05/20
						break;
					// なし
					case 1:
						panel_SlipNote3.Visible = false;
						uLabel_SlipNote2.Visible = false;// ADD 2010/05/20
						break;
					default:
						panel_SlipNote3.Visible = true;
						uLabel_SlipNote2.Visible = true;// ADD 2010/05/20
						break;
				}
			}
			else
			{
				panel_SlipNote3.Visible = true;
				uLabel_SlipNote1.Visible = true;// ADD 2010/05/20
			}
			#endregion

			// --- ADD 2009/09/08② ---------->>>>>
			#region 車輌管理オプション
			if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
			{
				this.uButton_CarMngNoGuide.Visible = true;
				if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null &&
					this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1)
				{
					this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = true;
				}
			}
			else
			{
				this.uButton_CarMngNoGuide.Visible = false;
				this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = false;
			}
			#endregion
			// --- ADD 2009/09/08② ----------<<<<<

            //>>>2010/02/26
            #region オプション情報反映
            this.SettingOptionInfo();
            #endregion
            //<<<2010/02/26
		}

		/// <summary>
		/// 追加情報タブ項目Visible設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : 追加情報タブ項目をVisible設定します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void SettingAddInfoVisible()
		{
			if (tNedit_CustomerCode.GetInt() != 0 && this.tEdit_CarMngCode.Text.Trim() != string.Empty)
			{
				//売上明細データ
				SalesInputDataSet.CarInfoDataTable detailtable = this._salesSlipInputAcs.CarInfoDataTable;
				if (this._salesSlipInputAcs.ExistCarInfo() || (detailtable == null || detailtable.Count == 1))
				{
					CustomerInfo customerInfo = null;
					SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
					int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					SalesSlipInputInitDataAcs.LogWrite("▼得意先マスタＲｅａｄ開始");
					status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, salesSlip.CustomerCode, true, false, out customerInfo);
					SalesSlipInputInitDataAcs.LogWrite("▲得意先マスタＲｅａｄ終了");

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// 得意先情報設定処理
						this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);
					}
					switch (salesSlip.CarMngDivCd)
					{
						case 0: // しない
							this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = false;
							break;
						case 1: // 登録(確認)
						case 2: // 登録(自動)
						case 3: // 登録無
							//車輌管理オプション
							if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null
								&& this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1)
							{
								if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
								{
									this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = true;
								}
							}
							break;
					}
				}
				else
				{
					this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = false;
				}
			}
			else
			{
				this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible = false;
			}

			if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == false)
			{
				int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();

				//車両走行距離
				this.tEdit_CarSlipNote.Text = string.Empty;
				this._salesSlipInputAcs.SettingCarInfoRowFromCarNote(salesRowNo, string.Empty);

				//車輌備考
				this.tNedit_Mileage.SetInt(0);
				this._salesSlipInputAcs.SettingCarInfoRowFromMileage(salesRowNo, 0);
			}

		}

		/// <summary>
		/// 車種変更ボタンVisible設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : 車種変更ボタンをVisible設定します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void SettingChangeCarInfoVisible()
		{
			if (tNedit_CustomerCode.GetInt() != 0 && this.tEdit_CarMngCode.Text.Trim() != string.Empty)
			{
				switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
				{
					case 0: // しない
						this._salesSlipDetailInput.uButton_ChangeCarInfoChangeEnable(1);
						break;
					case 1: // 登録(確認)
					case 2: // 登録(自動)
					case 3: // 登録無
						this._salesSlipDetailInput.uButton_ChangeCarInfoChangeEnable(0);
						break;
				}

				if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.OFF)
				{
					this._salesSlipDetailInput.uButton_ChangeCarInfoChangeEnable(1);
				}
			}
			else
			{
				this._salesSlipDetailInput.uButton_ChangeCarInfoChangeEnable(1);
			}
		}

		/// <summary>
		/// 管理番号でガイドVisible設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : 管理番号でガイドをVisible設定します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void SettingCarMngNoGuideVisible(ref Dictionary<Control, bool> itemDic)
		{
			if (tNedit_CustomerCode.GetInt() != 0)
			{
				switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
				{
					case 0: // しない
						itemDic[uButton_CarMngNoGuide] = false;
						break;
					case 1: // 登録(確認)
					case 2: // 登録(自動)
						break;
					case 3: // 登録無
						itemDic[uButton_CarMngNoGuide] = false;
						break;
				}
			}
		}

		/// <summary>
		/// フォーム表示後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAHNB01010UA_Shown(object sender, EventArgs e)
		{
            //>>>2010/02/26
            timer_SCMRead.Enabled = true;
            timer_SCMRead.Interval = 1000;
            //<<<2010/02/26
		}

        //>>>2010/02/26
        /// <summary>
        /// SCMReadタイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SCMRead_Tick(object sender, EventArgs e)
        {

            timer_SCMRead.Enabled = false;
            if (this._customerCode == 0)
            {
                //-----------------------------------------------------------------------------
                // SCM情報読込
                //-----------------------------------------------------------------------------
                if ((this._scmInquiryNumber != 0) ||
                    ((this._scmSalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum) &&
                     (this._scmSalesSlipNum != string.Empty) &&
                     (this._scmSalesSlipNum != null)))
                {
                    this.InputInquiryNumberProc(false);
                }
            }
            else
            {
                //-----------------------------------------------------------------------------
                // 得意先情報読込
                //-----------------------------------------------------------------------------
                this.LinkCommunicationToolProc(false); // 売伝起動時→確認画面を表示しない
            }
        }
        //<<<2010/02/26

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④対応</br>
		private void MAHNB01010UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				// --- DEL 2009/12/23 ---------->>>>>
				//this._salesSlipDetailInput.Closing();
				// --- DEL 2009/12/23 ----------<<<<<
			}
			catch (NullReferenceException)
			{
				//
			}

			ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.tToolbarsManager_MainMenu);
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/11/24 売価率、売単価の入力チェックを追加対応</br>
		/// <br>Update Note: 2009/12/23 PM.NS保守依頼④を追加対応</br>
		/// <br>Update Note: 2010/01/27 高峰 売上日を変更しても標準価格が更新されない件の対応</br>
		/// <br>                             車種変更ボタンを使用しないで車種変更した場合の不具合対応</br>
		/// <br>Update Note: 2010/02/02 張凱 redmine#2760対応</br>
		/// <br>Update Note: 2010/05/04 王海立 発行者チェック処理の追加</br>
		/// <br>                               修正呼出時に以下の操作を行った場合は、伝票印刷処理を行わずにデータ更新処理のみ行う</br>
        /// <br>Update Note: 2010/06/02 呉元嘯 PM.NS障害・改良対応（７月リリース案件）No.17</br>
        /// <br>                        以下オペレーションでエラーが発生するので、エラー発生しないように修正する。</br> 
        /// <br>Update Note: K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			this._prevControl = e.NextCtrl;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
			_beforeCarSearchBuffer = new BeforeCarSearchBuffer();
			_beforeCarSearchBuffer.Clear();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

			// PrevCtrl設定
			Control prevCtrl = new Control();
			if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

			//// ここ 明細でカーソルキー移動した場合、e.NextCtrlがGridにメイン画面のNextになる。(Gridにならない)
			////      カーソルキーで数値項目へ移動し、保存した場合、
			////      this._prevControlがGrid以外で保存前のChangeFocusが動作する為、BeforeCellDeactivateが動作せず
			////      数値項目がDBNullのままで保存処理が発生し、エラーとなる。
			//if (prevCtrl == this._salesSlipDetailInput.uGrid_Details) this._prevControl = prevCtrl;

			// 変更前情報保持
			SalesSlip salesSlipCurrent = this._salesSlipInputAcs.SalesSlip.Clone();
			if (salesSlipCurrent == null) return;
			int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();
			SalesInputDataSet.CarInfoRow carInfoRowCurrent = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode);

			// 各種変数初期化
			SalesSlip salesSlip = salesSlipCurrent.Clone();
			bool reCalcSalesPrice = false;
			bool reCalcSalesUnitPrice = false;
			bool clearRateInfo = false;
			bool changeSalesGoodsCd = false;
			bool changeAcptAnOdrStatus = false;
			bool changeSalesSlip = false;
			bool changeStockInfo = false;
			bool changeCarInfo = false;
			bool getNextCtrl = false;
			bool getNextCtrlForFooter = false;
			bool isCache = false;
			bool inputSalesSlipNum = false; // 2010/01/13
			Control nextCtrl = null;
			double taxRate = 0;
            bool changeCustomer = false; // 2010/02/26

			// 商品情報再取得
			List<List<GoodsUnitData>> goodsUnitDataListList = new List<List<GoodsUnitData>>();
			string msg;

			switch (prevCtrl.Name)
			{
				#region ●売上情報
				#region 売上明細
				//---------------------------------------------------------------
				// 売上明細
				//---------------------------------------------------------------
				case "uGrid_Details":
					{
						switch (e.Key)
						{
							case Keys.Return:
							case Keys.Tab:
								{
									// 明細部にフォーカス有り(GridActive)
									if (this._salesSlipDetailInput.uGrid_Details.ActiveCell != null)
									{
										// 明細部キーダウン処理
										if (this._salesSlipDetailInput.ReturnKeyDown())
										{
											e.NextCtrl = null;
										}
										else
										{
											// --- UPD 2009/11/16 ---------->>>>>
											// --- UPD 2009/11/24 ---------->>>>>
											//if (this._salesSlipDetailInput.CheckSalesUnitCost())
											if (this._salesSlipDetailInput.CheckSalesUnitCost() && this._salesSlipDetailInput.CheckSalesRateAndUnPrcDisplay())
											// --- UPD 2009/11/24 ----------<<<<<
											{
												// --- UPD 2009/12/23 ---------->>>>>
												//e.NextCtrl = this.tEdit_SlipNote;
												// --- UPD 2010/02/02 ---------->>>>>
												//e.NextCtrl = this.tNedit_SlipNoteCode;
												e.NextCtrl = GetFooterFirstControl();
												// --- UPD 2010/02/02 ----------<<<<<
												// --- UPD 2009/12/23 ----------<<<<<
											}
											else
											{
												e.NextCtrl = null;
											}
											// --- UPD 2009/11/16 ----------<<<<<
										}
									}

									salesSlipCurrent = this._salesSlipInputAcs.SalesSlip;
									salesSlip = salesSlipCurrent.Clone();
									this._salesSlipDetailInput.DisplayOpenPrice();
									break;
								}
						}
						break;
					}
				#endregion

				#region カラー情報
				//---------------------------------------------------------------
				// カラー情報
				//---------------------------------------------------------------
				case "uGrid_ColorInfo":
					{
						switch (e.Key)
						{
							case Keys.Return:
								{
									this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
									e.NextCtrl = null;
									break;
								}
						}
						break;
					}
				#endregion

				#region トリム情報
				//---------------------------------------------------------------
				// トリム情報
				//---------------------------------------------------------------
				case "uGrid_TrimInfo":
					{
						switch (e.Key)
						{
							case Keys.Return:
								{
									this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
									e.NextCtrl = null;
									break;
								}
						}
						break;
					}
				#endregion

				#region 装備情報
				//---------------------------------------------------------------
				// 装情報
				//---------------------------------------------------------------
				case "uGrid_EquipInfo":
					{
						switch (e.Key)
						{
							case Keys.Return:
								{
									this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
									e.NextCtrl = null;
									break;
								}
						}
						break;
					}
				#endregion

				#region 拠点コード
				//---------------------------------------------------------------
				// 拠点コード
				//---------------------------------------------------------------
				case "tEdit_SectionCode":
					{
						getNextCtrl = true;

						bool canChangeFocus = true;

						string code = this.tEdit_SectionCode.Text.Trim();
						code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);

						if (salesSlipCurrent.ResultsAddUpSecCd.Trim() != code)
						{
							if (string.IsNullOrEmpty(code))
							{
								salesSlip.ResultsAddUpSecCd = code;
								salesSlip.ResultsAddUpSecNm = string.Empty;
							}
							else
							{
								code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);
								SecInfoSet secInfoSet = this._salesSlipInputInitDataAcs.GetSecInfo(code);

								if (secInfoSet == null)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"拠点が存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									DialogResult dialogResult = DialogResult.No;

									salesSlip.ResultsAddUpSecCd = code;
									salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;

									if ((salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
										(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
									{
										dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"拠点が変更されました。" + "\r\n" + "\r\n" +
											"商品価格を再取得しますか？",
											0,
											MessageBoxButtons.YesNo,
											MessageBoxDefaultButton.Button1);

										if (dialogResult == DialogResult.Yes)
										{
											reCalcSalesPrice = true;
											reCalcSalesUnitPrice = true;
											salesSlip.StockUpdateFlag = true;  //ADD 2010/01/27
										}
										else
										{
											clearRateInfo = true;
										}
									}

								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{

								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
										{
											nextCtrl = this.uButton_SectionGuide;
											getNextCtrl = false;
										}
										break;
									default:
										break;
								}
							}
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
							getNextCtrl = false;
						}

						break;
					}
				#endregion

				#region 拠点ガイドボタン
				//---------------------------------------------------------------
				// 拠点ガイドボタン
				//---------------------------------------------------------------
				case "uButton_SectionGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SectionCode;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SectionCode;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 部門コード
				//---------------------------------------------------------------
				// 部門コード
				//---------------------------------------------------------------
				case "tNedit_SubSectionCode":
					{
						getNextCtrl = true;

						bool canChangeFocus = true;
						int code = this.tNedit_SubSectionCode.GetInt();

						if (salesSlipCurrent.SubSectionCode != code)
						{
							if (code == 0)
							{
								salesSlip.SubSectionCode = code;
								salesSlip.SubSectionName = string.Empty;
							}
							else
							{
								string name = this._salesSlipInputInitDataAcs.GetName_FromSubSection(code);
								//string selectedSectionCode = this._sectionComboBox.ValueList.ValueListItems[this._sectionComboBox.SelectedIndex].DataValue.ToString();
								//string name = this._stockSlipInputInitDataAcs.GetName_FromWarehouse(selectedSectionCode, code);

								if (string.IsNullOrEmpty(name))
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"部門が存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									salesSlip.SubSectionCode = code;
									salesSlip.SubSectionName = name;
								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{

								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (this.tNedit_SubSectionCode.GetInt() == 0)
										{
											nextCtrl = this.uButton_SubSectionGuide;
											getNextCtrl = false;
										}
										break;
									default:
										break;
								}
							}
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
							getNextCtrl = false;
						}

						break;
					}
				#endregion

				#region 部門ガイドボタン
				//---------------------------------------------------------------
				// 部門ガイドボタン
				//---------------------------------------------------------------
				case "uButton_SubSectionGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tNedit_SubSectionCode;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tNedit_SubSectionCode;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 売上伝票番号
				//---------------------------------------------------------------
				// 売上伝票番号
				//---------------------------------------------------------------
				case "tNedit_SalesSlipNum":
					{
						bool read = false;
						// 売上伝票番号
						string code = this.tNedit_SalesSlipNum.Text.PadLeft(9, '0');
                        int statusCheck = (int)ConstantManagement.DB_Status.ctDB_EOF;// ADD 2010/06/02

						if (salesSlipCurrent.SalesSlipNum.PadLeft(9, '0') != code)
						{
							DialogResult dialogResult = DialogResult.Yes;

							if (this._salesSlipInputAcs.IsDataChanged)
							{
								dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"入力中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "情報がクリアされます。" + "\r\n" + "\r\n" +
									"よろしいですか？",
									0,
									MessageBoxButtons.YesNo,
									MessageBoxDefaultButton.Button1);
							}

							if (dialogResult == DialogResult.Yes)
							{
								SalesSlip baseSalesSlip;

								// データリード処理
								this.Cursor = Cursors.WaitCursor;
								int status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus, code, out baseSalesSlip);

								this.Cursor = Cursors.Default;

								if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
								{
                                    // ----- ADD K2011/08/12 --------------------------->>>>>
                                    // ----- ADD K2011/12/09 --------------------------->>>>>
                                    // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
                                    //if (this._enterpriseCode == login_EnterpriseCode)
                                    if ((this._salesSlipInputInitDataAcs.Opt_DateCtrl == (int)SalesSlipInputInitDataAcs.Option.ON) ||
                                        (this._enterpriseCode == login_EnterpriseCode))
                                    // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
                                    {
                                    // ----- ADD K2011/12/09 ---------------------------<<<<<
                                        if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false)
                                        {
                                            e.NextCtrl = this.tNedit_SalesSlipNum;
                                            return;
                                        }
                                    }// ADD K2011/12/09
                                    // ----- ADD K2011/08/12 ---------------------------<<<<<     
									int acptAnOdrStatus = this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay;

									foreach (SalesSlipInputAcs.AcptAnOdrStatusState state in _stateList)
									{
										if ((int)state == acptAnOdrStatus) continue;

										// データが存在しない場合は売上形式を変更して再度読み込み
										this.Cursor = Cursors.WaitCursor;
										status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, (int)state, code, out baseSalesSlip);
										this.Cursor = Cursors.Default;

										if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
									}
								}
                                statusCheck = status;// ADD 2010/06/02
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{

									// 2010/01/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
									// 前回情報再セット
									carInfoRowCurrent = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode);
									inputSalesSlipNum = true;
									// 2010/01/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

									// 売上伝票番号を再設定
									this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(code, 0));

									// 売上or出荷の場合、受注データ再読込
									if ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) ||
										(this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment))
									{
										SalesSlip saveSalesSlip = baseSalesSlip;
										this.Cursor = Cursors.WaitCursor;
										status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder, this._salesSlipInputAcs.SalesSlip.SalesSlipNum, out baseSalesSlip);
										this.Cursor = Cursors.Default;

										if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
										{
                                            //>>>2010/06/07
                                            //string statusName = (salesSlipCurrent.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) ? "売上伝票" : "貸出伝票";
                                            string statusName = (saveSalesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) ? "売上伝票" : "貸出伝票";
                                            //<<<2010/06/07

											dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_INFO,
												this.Name,
												"同伝票番号で" + statusName + "と受注伝票が存在します。　" + Environment.NewLine + Environment.NewLine +
												statusName + "を表示してよろしいですか？" + Environment.NewLine + Environment.NewLine +
												"はい：" + statusName + Environment.NewLine +
												"いいえ：受注伝票" + Environment.NewLine,
												-1,
												MessageBoxButtons.YesNo);
											if (dialogResult == DialogResult.Yes)
											{
												this.Cursor = Cursors.WaitCursor;
                                                //>>>2010/06/07
                                                //status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, salesSlipCurrent.AcptAnOdrStatus, code, out baseSalesSlip);
                                                status = this._salesSlipInputAcs.ReadDBData(this._enterpriseCode, saveSalesSlip.AcptAnOdrStatus, code, out baseSalesSlip);
                                                //<<<2010/06/07
												this.Cursor = Cursors.Default;
											}
										}
										else
										{
											baseSalesSlip = saveSalesSlip;
										}
									}

									salesSlipCurrent = this._salesSlipInputAcs.SalesSlip;
									salesSlip = salesSlipCurrent.Clone();

                                    // 2010/06/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    carInfoRowCurrent = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode);
                                    // 2010/06/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

									// 売上データ入力モード設定処理
									this.SettingStockSlipInputMode(ref salesSlip);

									// 表示用受注ステータスの設定
									SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

									// 表示用伝票区分の設定
									SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

									// 伝票区分コンボエディタアイテム設定処理
									this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

									// フッタタブ位置セット
									uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];

									if (baseSalesSlip.ConsTaxLayMethod != this._salesSlipInputAcs.SalesSlip.ConsTaxLayMethod)
									{
										reCalcSalesPrice = true;
									}
									read = true;

									// --- ADD 2009/12/23 ---------->>>>>
									//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
									this._salesSlipInputAcs.GetNoteCharCnt();
									SetNoteCharCnt();
									// --- ADD 2009/12/23 ----------<<<<<

									// --- ADD 2010/05/04 ---------->>>>>
									this._readSlipFlg = true;
									// --- ADD 2010/05/04 ----------<<<<<
								}
								else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"該当するデータが存在しません。",
										-1,
										MessageBoxButtons.OK);

									e.NextCtrl = prevCtrl;
								}
								else
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_STOPDISP,
										this.Name,
										"売上・出荷データの取得に失敗しました。",
										status,
										MessageBoxButtons.OK);

									e.NextCtrl = prevCtrl;
								}
							}

							// 売上データキャッシュ処理
							this._salesSlipInputAcs.Cache(salesSlip);

							// 計上時は空白行を削除する(出荷計上 受注計上 見積計上)
							if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
								(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
								(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
							{
								this._salesSlipDetailInput.DeleteEmptyRow(true);
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);

							salesSlipCurrent = salesSlip.Clone();

							// 明細グリッド設定処理
							this._salesSlipDetailInput.SettingGrid();

                            // ------------UPD 2010/06/02------------>>>>>
                            //// 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// 明細行数制限
                            //this._salesSlipInputAcs.SettingSalesDetailRowInputRowCount(salesSlip.DetailRowCountForReadSlip);
                            //// 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            if (statusCheck == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //明細行数制限
                                this._salesSlipInputAcs.SettingSalesDetailRowInputRowCount(salesSlip.DetailRowCountForReadSlip);
                            }
                            // ------------UPD 2010/06/02------------<<<<<
							this.SettingVisible();

							if (read)
							{
								if (this._salesSlipDetailInput.Enabled)
								{
									e.NextCtrl = this._salesSlipDetailInput;
								}
								else
								{
									e.NextCtrl = this._salesSlipDetailInput;
								}

                                //>>>2010/09/27
                                //// --- ADD 2009/12/23 ---------->>>>>
                                //if (salesSlip.DepositAllowanceTtl != 0)
                                //{
                                //    TMsgDisp.Show(
                                //    this,
                                //    emErrorLevel.ERR_LEVEL_INFO,
                                //    this.Name,
                                //    "入金済み伝票です。" + "\r\n" + "\r\n" +
                                //    "削除する場合は、入金伝票入力より　" + "\r\n" +
                                //    "対象の入金伝票を赤伝処理後、　" + "\r\n" +
                                //    "削除することができます。　",
                                //    -1,
                                //    MessageBoxButtons.OK);
                                //}
                                //// --- ADD 2009/12/23 ----------<<<<<
                                //<<<2010/09/27
							}

							// --- ADD 2009/09/08② ---------->>>>>
							//追加情報タブ項目Visible設定
							SettingAddInfoVisible();
							// --- ADD 2009/09/08② ----------<<<<<
						}

						changeCarInfo = true;

						break;
					}
				#endregion

				#region 担当者
				//---------------------------------------------------------------
				// 担当者
				//---------------------------------------------------------------
				case "tEdit_SalesEmployeeCd":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_SalesEmployeeCd.Text.Trim();
						code = this.uiSetControl1.GetZeroPaddedText(tEdit_SalesEmployeeCd.Name, code);

						canChangeFocus = this.ChangeSalesEmployee(ref salesSlip, salesSlipCurrent, code);

						#region NextCtrl制御
						// NextCtrl制御
						if (canChangeFocus)
						{
							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_SalesEmployeeCd.Text.Trim()))
										{
											nextCtrl = this.uButton_EmployeeGuide;
										}
										else
										{
											nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
										}
										break;
									default:
										break;
								}
							}
							if (nextCtrl != null) e.NextCtrl = nextCtrl;
						}
						else
						{
							e.NextCtrl = prevCtrl;
						}
						#endregion

						break;
					}
				#endregion

				#region 担当者ガイドボタン
				//---------------------------------------------------------------
				// 担当者ガイドボタン
				//---------------------------------------------------------------
				case "uButton_EmployeeGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SalesEmployeeCd;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SalesEmployeeCd;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 受注者
				//---------------------------------------------------------------
				// 受注者
				//---------------------------------------------------------------
				case "tEdit_FrontEmployeeCd":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_FrontEmployeeCd.Text.Trim();

						canChangeFocus = this.ChangeFrontEmployee(ref salesSlip, salesSlipCurrent, code);

						#region NextCtrl制御
						// NextCtrl制御
						if (canChangeFocus)
						{
							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_FrontEmployeeCd.Text.Trim()))
										{
											nextCtrl = this.uButton_FrontEmployeeGuide;
										}
										else
										{
											nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
										}
										break;
									default:
										break;
								}
							}
							if (nextCtrl != null) e.NextCtrl = nextCtrl;
						}
						else
						{
							e.NextCtrl = prevCtrl;
						}
						#endregion

						break;
					}
				#endregion

				#region 受注者ガイドボタン
				//---------------------------------------------------------------
				// 受注者ガイドボタン
				//---------------------------------------------------------------
				case "uButton_FrontEmployeeGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_FrontEmployeeCd;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_FrontEmployeeCd;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 発行者
				//---------------------------------------------------------------
				// 発行者
				//---------------------------------------------------------------
				case "tEdit_SalesInputCode":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_SalesInputCode.Text.Trim();
						canChangeFocus = this.ChangeSalesInput(ref salesSlip, salesSlipCurrent, code);

						#region NextCtrl制御
						// NextCtrl制御
						if (canChangeFocus)
						{
							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_SalesInputCode.Text.Trim()))
										{
											nextCtrl = this.uButton_SalesInputGuide;
										}
										else
										{
											nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
										}
										break;
									default:
										break;
								}
							}
							if (nextCtrl != null) e.NextCtrl = nextCtrl;
						}
						else
						{
							e.NextCtrl = prevCtrl;
						}
						#endregion

						break;
					}
				#endregion

				#region 発行者ガイドボタン
				//---------------------------------------------------------------
				// 発行者ガイドボタン
				//---------------------------------------------------------------
				case "uButton_SalesInputGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SalesInputCode;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SalesInputCode;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 得意先コード
				//---------------------------------------------------------------
				// 得意先コード
				//---------------------------------------------------------------
				case "tNedit_CustomerCode":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_CustomerCode.GetInt();
						CustomerInfo customerInfo = null;
						bool guideStart = true;

						if (salesSlipCurrent.CustomerCode != code)
						{
                            changeCustomer = true; // 2010/02/26

							// --- ADD 2009/09/08② ---------->>>>>
							// 車輌管理オプション有りの場合
							if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
							{
								//得意先を変更した場合は、管理番号の値をクリアする
								ClearAddCarInfo();
							}

							// --- ADD 2009/09/08② ----------<<<<<
							if (code == 0)
							{
								#region コードゼロ入力時
								if (this._salesSlipInputAcs.ExistSalesDetail())
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報が入力されているため、得意先のクリアは行えません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									try
									{
										// 得意先情報設定処理
										this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, null);

										// 得意先掛率グループ再セット
										this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

										// 売上明細データセッティング処理（課税区分設定）
										this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

										reCalcSalesPrice = true;
									}
									catch (Exception ex)
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											ex.Message,
											-1,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
								}
								#endregion
							}
							else
							{
								this.Cursor = Cursors.WaitCursor;
								bool changeFlg = false;
								DialogResult dialogResult = DialogResult.No;
								SalesSlipInputInitDataAcs.LogWrite("▼得意先マスタＲｅａｄ開始");
								int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, false, out customerInfo);
								SalesSlipInputInitDataAcs.LogWrite("▲得意先マスタＲｅａｄ終了");

								if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
								{
									#region マスタ未登録
									//-----------------------------------------------------------------------------
									// マスタ未登録
									//-----------------------------------------------------------------------------
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"得意先が存在しません。",
										-1,
										MessageBoxButtons.OK);
									this.tNedit_CustomerCode.SetInt(salesSlip.CustomerCode);
									guideStart = false;
									#endregion
								}
								else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									// 変更チェック
									if (salesSlip.CustomerCode != customerInfo.CustomerCode)
									{
										if (customerInfo.IsCustomer != true)
										{
											#region 納入先入力
											//-----------------------------------------------------------------------------
											// 納入先入力
											//-----------------------------------------------------------------------------
											TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_INFO,
												this.Name,
												"納入先は入力できません。",
												-1,
												MessageBoxButtons.OK);
											this.tNedit_CustomerCode.SetInt(salesSlip.CustomerCode);
											guideStart = false;
											#endregion
										}
										else if (!this._salesSlipInputAcs.CheckTransStopDate(customerInfo.TransStopDate))
										{
											#region 取引中止チェック
											//-----------------------------------------------------------------------------
											// 取引中止チェック
											//-----------------------------------------------------------------------------
											TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_INFO,
												this.Name,
												"取引中止中により設定できません。",
												-1,
												MessageBoxButtons.OK);
											this.tNedit_CustomerCode.SetInt(salesSlip.CustomerCode);
											guideStart = false;
											#endregion
										}
										else
										{
                                            //>>>2010/02/26
                                            #region オンライン区分判定
                                            if (!this._salesSlipInputAcs.CheckCustomerEpCode(customerInfo))
                                            {
                                                TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_INFO,
                                                    this.Name,
                                                    "得意先マスタの得意先企業コードまたは得意先拠点コードが" + "\r\n" + "\r\n" +
                                                    "設定されていない為、回答処理および問合せ一覧の起動はできません。",
                                                    -1,
                                                    MessageBoxButtons.OK);
                                            }
                                            #endregion
                                            //<<<2010/02/26

											bool settingFlg = false;
											if ((this._salesSlipInputAcs.ExistSalesDetail()) &&
												(salesSlip.CustomerCode != 0) &&
												(customerInfo.AccRecDivCd != salesSlip.AccRecDivCd))
											{
												#region 売掛／現金間のコード変更
												//-----------------------------------------------------------------------------
												// 売掛／現金間のコード変更
												//-----------------------------------------------------------------------------
												dialogResult = TMsgDisp.Show(
													this,
													emErrorLevel.ERR_LEVEL_EXCLAMATION,
													this.Name,
													"売掛得意先と現金得意先間のコード変更です。" + "\r\n" + "\r\n" +
													this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
													"よろしいですか？",
													0,
													MessageBoxButtons.YesNo,
													MessageBoxDefaultButton.Button1);

												if (dialogResult == DialogResult.Yes)
												{
													settingFlg = true;
													this._salesSlipDetailInput.Clear();
													this._salesSlipInputAcs.ClearCarInfo();
													this.ClearDisplayCarInfo();
												}
												#endregion
											}
											else
											{
												settingFlg = true;
											}

											if (settingFlg)
											{
												#region 各種設定
												reCalcSalesPrice = true;

												// 得意先情報設定処理
												this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);

												// 得意先掛率グループ再セット
												this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

												// 計上日の再セット
												this._salesSlipInputAcs.SettingSalesSlipAddUpDate(ref salesSlip); // 計上日再設定

												// 担当者情報設定処理
												this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, salesSlip.SalesEmployeeCd);

												// 納入先情報設定処理
												this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);

												// 売上明細データセッティング処理（課税区分設定）
												this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

												if ((salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
													(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
												{
													dialogResult = TMsgDisp.Show(
														this,
														emErrorLevel.ERR_LEVEL_EXCLAMATION,
														this.Name,
														"得意先が変更されました。" + "\r\n" + "\r\n" +
														"商品価格を再取得しますか？",
														0,
														MessageBoxButtons.YesNo,
														MessageBoxDefaultButton.Button1);

													if (dialogResult == DialogResult.Yes)
													{
														reCalcSalesUnitPrice = true;
														salesSlip.StockUpdateFlag = true;  //ADD 2010/01/27
													}
													else
													{
														clearRateInfo = true;
													}
												}
												#endregion
											}

										}
									}
								}
								else
								{
									#region 取得失敗
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_STOPDISP,
										this.Name,
										"得意先の取得に失敗しました。",
										status,
										MessageBoxButtons.OK);

									canChangeFocus = false;
									#endregion
								}
							}

							// 得意先情報画面格納処理
							this.SetDisplayCustomerInfo(customerInfo);

							// 伝票区分コンボエディタアイテム設定処理
							this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

							// 伝票区分設定処理
							changeSalesSlip = this.ChangeSalesSlip(ref salesSlip, false);

							// 売上データキャッシュ処理
							this._salesSlipInputAcs.Cache(salesSlip);

							// Visible設定
							this.SettingVisible();

							// --- ADD 2009/09/08② ---------->>>>>
							//追加情報タブ項目Visible設定
							SettingAddInfoVisible();

							//車種変更ボタンVisible設定
							SettingChangeCarInfoVisible();
							// --- ADD 2009/09/08② ----------<<<<<

							// --- ADD 2009/12/23 ---------->>>>>
							//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
							this._salesSlipInputAcs.GetNoteCharCnt();
							SetNoteCharCnt();
							// --- ADD 2009/12/23 ----------<<<<<

							//this._salesSlipDetailInput.SetToolbarButton -= new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
							//// 明細グリッドセル設定処理
							//this._salesSlipDetailInput.SettingGrid();
							//this._salesSlipDetailInput.ActiveCellButtonEnabledControl();
							//this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);

                            //>>>2010/02/26
                            this._customerCode = salesSlip.CustomerCode;
                            //<<<2010/02/26
                        }

						#region NextCtrl制御
						if (canChangeFocus)
						{
							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if ((this.tNedit_CustomerCode.GetInt() == 0) && (guideStart))
										{
											this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, EventArgs.Empty, ref salesSlip);
											salesSlip = this._salesSlipInputAcs.SalesSlip;
											this.SettingVisible();
											// --- ADD 2009/09/08② ---------->>>>>
											//追加情報タブ項目Visible設定
											SettingAddInfoVisible();
											// --- ADD 2009/09/08② ----------<<<<<
										}

										if (!guideStart)
										{
											nextCtrl = prevCtrl;
										}
										else if (this.tNedit_CustomerCode.GetInt() == 0)
										{
											nextCtrl = this.uButton_CustomerGuide;
										}
										else
										{
											nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
										}
										break;
									default:
										break;
								}
							}
							if (nextCtrl != null) e.NextCtrl = nextCtrl;
						}
						else
						{
							e.NextCtrl = prevCtrl;
						}
						#endregion

						break;
					}
				#endregion

				#region 得意先ガイド
				//---------------------------------------------------------------
				// 得意先ガイド
				//---------------------------------------------------------------
				case "uButton_CustomerGuide":
					{
						getNextCtrl = true;
						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if ((this.tEdit_CustomerName.Visible) && (this.tEdit_CustomerName.Enabled))
									{
										nextCtrl = this.tEdit_CustomerName;
									}
									else
									{
										nextCtrl = this.tNedit_CustomerCode;
									}
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if ((this.uButton_CustomerClaimConfirmation.Visible) && (this.uButton_CustomerClaimConfirmation.Enabled))
									{
										nextCtrl = this.uButton_CustomerClaimConfirmation;
										getNextCtrl = false;
									}
									else
									{
										nextCtrl = this.tEdit_SalesEmployeeCd;
										getNextCtrl = false;
									}
									break;
								default:
									break;
							}
						}
						if (nextCtrl != null) e.NextCtrl = nextCtrl;
						break;
					}
				#endregion

				#region 得意先名称
				//---------------------------------------------------------------
				// 得意先名称
				//---------------------------------------------------------------
				case "tEdit_CustomerName":
					{
						// 2009.08.03 >>>
						//if ((salesSlipCurrent.CustomerName.Trim() + salesSlipCurrent.CustomerName2.Trim()) != this.tEdit_CustomerName.Text)
						if ((salesSlipCurrent.CustomerSnm.Trim()) != this.tEdit_CustomerName.Text)
						// 2009.08.03 <<<
						{
							if (!string.IsNullOrEmpty(this.tEdit_CustomerName.Text))
							{
								string name = this.tEdit_CustomerName.Text;
								if (name.Length > 20) name = name.Substring(0, 20);
								salesSlip.CustomerName = name;
								salesSlip.CustomerName2 = string.Empty;
								salesSlip.CustomerSnm = name;
							}
						}

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (string.IsNullOrEmpty(this.tEdit_CustomerName.Text))
									{
										nextCtrl = this.uButton_CustomerGuide;
									}
									else
									{
										nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
									}
									break;
								default:
									break;
							}
						}
						if (nextCtrl != null) e.NextCtrl = nextCtrl;

						break;
					}
				#endregion

				#region 請求先確認
				//---------------------------------------------------------------
				// 請求先確認
				//---------------------------------------------------------------
				case "uButton_CustomerClaimConfirmation":
					{
						getNextCtrl = true;
						break;
					}
				#endregion

				#region 伝票種別
				//---------------------------------------------------------------
				// 伝票種別
				//---------------------------------------------------------------
				case "tComboEditor_AcptAnOdrStatusDisplay":
					{
						// 売上形式コンボエディタ選択値変更確定後イベントを一時的に解除
						this.tComboEditor_AcptAnOdrStatusDisplay.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_AcptAnOdrStatusDisplay_SelectionChangeCommitted);

						changeAcptAnOdrStatus = this.ChangeAcptAnOdrStatus(ref salesSlip, false);

						// 売上形式コンボエディタ選択値変更確定後イベントを挿入
						this.tComboEditor_AcptAnOdrStatusDisplay.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_AcptAnOdrStatusDisplay_SelectionChangeCommitted);

						getNextCtrl = true;
						break;
					}
				#endregion

				#region 伝票区分
				//---------------------------------------------------------------
				// 伝票区分
				//---------------------------------------------------------------
				case "tComboEditor_SalesSlipDisplay":
					{
						// 伝票区分コンボエディタ選択確定後発生イベントを一時的に解除
						this.tComboEditor_SalesSlipDisplay.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SalesSlipDisplay_SelectionChangeCommitted);

						changeSalesSlip = this.ChangeSalesSlip(ref salesSlip, false);

						// 伝票区分コンボエディタ選択確定後発生イベントを挿入
						this.tComboEditor_SalesSlipDisplay.SelectionChangeCommitted += new EventHandler(this.tComboEditor_SalesSlipDisplay_SelectionChangeCommitted);

						getNextCtrl = true;
						switch (e.Key)
						{
							case Keys.Down:
								nextCtrl = this.tNedit_MakerCode;
								getNextCtrl = false;
								break;
							default:
								break;
						}

						break;
					}
				#endregion

				#region 商品区分
				//---------------------------------------------------------------
				// 商品区分
				//---------------------------------------------------------------
				case "tComboEditor_SalesGoodsCd":
					{
						// 商品区分コンボエディタ選択確定後発生イベントを一時的に解除
						this.tComboEditor_SalesGoodsCd.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SalesGoodsCd_SelectionChangeCommitted);

						int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SalesGoodsCd, ComboEditorGetDataType.TAG);

						if (salesSlipCurrent.SalesGoodsCd != code)
						{
							if (code != -1)
							{
								if ((!this.EqualsSalesGoodsCdType(salesSlipCurrent.SalesGoodsCd, code)) && (this._salesSlipInputAcs.ExistSalesDetail()))
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
										"よろしいですか？",
										0,
										MessageBoxButtons.YesNo,
										MessageBoxDefaultButton.Button1);

									if (dialogResult == DialogResult.Yes)
									{
										this._salesSlipDetailInput.Clear();
										this._salesSlipInputAcs.ClearCarInfo();
										this.ClearDisplayCarInfo();
										changeSalesGoodsCd = true;
									}
								}
								else
								{
									this._salesSlipInputAcs.ClearCarInfo();
									this.ClearDisplayCarInfo();
									changeSalesGoodsCd = true;
								}
							}

							if (changeSalesGoodsCd)
							{
								salesSlip.SalesGoodsCd = code;

								// グリッド設定処理（ユーザー設定より）
								this._salesSlipDetailInput.GridSetting(this._salesInputConstructionAcs.SalesInputConstruction);
							}
						}

						// 売上データクラス→画面格納処理
						this.SetDisplay(salesSlip);

						// 商品区分コンボエディタ選択確定後発生イベントを挿入
						this.tComboEditor_SalesGoodsCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SalesGoodsCd_SelectionChangeCommitted);

						getNextCtrl = true;
						switch (e.Key)
						{
							case Keys.Down:
								nextCtrl = this.tNedit_MakerCode;
								getNextCtrl = false;
								break;
							default:
								break;
						}

						break;
					}
				#endregion

				#region 売上日
				//---------------------------------------------------------------
				// 売上日
				//---------------------------------------------------------------
				case "tDateEdit_SalesDate":
					{
						DateTime value = this.tDateEdit_SalesDate.GetDateTime();

                        // ----- ADD K2011/08/12 --------------------------->>>>>
                        // ----- ADD K2011/12/09 --------------------------->>>>>
                        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
                        //if (this._enterpriseCode == login_EnterpriseCode)
                        if ((this._salesSlipInputInitDataAcs.Opt_DateCtrl == (int)SalesSlipInputInitDataAcs.Option.ON) ||
                            (this._enterpriseCode == login_EnterpriseCode))
                        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
                        {
                        // ----- ADD K2011/12/09 ---------------------------<<<<<
                            if (salesSlipCurrent.AcptAnOdrStatus == 30)
                            {
                                // ----- DEL K2011/12/09 --------------------------->>>>>
                                //this._iGetServerTime = (Broadleaf.Application.Remoting.IGetServerTime)Broadleaf.Application.Remoting.Adapter.MediationGetServerTimeDB.GetServerTimeDB();
                                //DateTime serverTime = _iGetServerTime.GetServerNowTime();
                                // ----- DEL K2011/12/09 ---------------------------<<<<<
                                DateTime serverTime = this._salesSlipInputAcs.GetServerNowTime;// ADD K2011/12/09

                                if (_employeeAcs == null)
                                {
                                    _employeeAcs = new EmployeeAcs();
                                }
                                Employee employee = new Employee();
                                int status = _employeeAcs.Read(out employee, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;
                                }
                                if (employee.AuthorityLevel1 != 99 || employee.AuthorityLevel2 != 99)
                                {
                                    if (Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(value) < Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(serverTime))
                                    {
                                        TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          "",
                                          "当日以前の伝票日付は入力できません。",
                                          -1,
                                          MessageBoxButtons.OK);

                                        this.tDateEdit_SalesDate.SetDateTime(salesSlipCurrent.SalesDate);
                                        e.NextCtrl = this.tDateEdit_SalesDate;
                                        getNextCtrl = false;
                                        break;
                                    }
                                }
                            }
                        }// ADD K2011/12/09
                        // ----- ADD K2011/08/12 ---------------------------<<<<<

						if (salesSlipCurrent.SalesDate != value)
						{
							salesSlip.SalesDate = value;
							this._salesSlipInputAcs.SettingSalesSlipAddUpDate(ref salesSlip); // 計上日再設定

							salesSlip.SalesDate = value;

							if (salesSlip.SalesDate != DateTime.MinValue)
							{
								this._salesSlipInputAcs.SettingSalesSlipAddUpDate(ref salesSlip); // 計上日再設定

								if (this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData())
								{
									DialogResult dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										this.uLabel_SalesDate.Text + "が変更されました。" + "\r\n" + "\r\n" +
										"商品価格を再取得しますか？",
										0,
										MessageBoxButtons.YesNo,
										MessageBoxDefaultButton.Button1);

									if (dialogResult == DialogResult.Yes)
									{
										// --- UPD 2010/01/27 -------------->>>>>
										//reCalcSalesUnitPrice = true; // 2009/09/10 DEL
										reCalcSalesUnitPrice = true;
										// --- UPD 2010/01/27 --------------<<<<<
										reCalcSalesPrice = true;
										salesSlip.StockUpdateFlag = true;  //ADD 2010/01/27
									}
								}
							}

							// 消費税再設定
							taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);
							this._salesSlipInputAcs.SettingSalesSlipConsTaxRate(ref salesSlip, taxRate);
						}
						getNextCtrl = true;
						break;
					}
				#endregion

				#region 納入先コード
				//---------------------------------------------------------------
				// 納入先コード
				//---------------------------------------------------------------
				case "tNedit_AddresseeCode":
					{
						int code = this.tNedit_AddresseeCode.GetInt();

						if (salesSlipCurrent.AddresseeCode != code)
						{
							if (code == 0)
							{
								try
								{
									// 納入先情報設定処理
									this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, null);

									reCalcSalesPrice = true;
								}
								catch (Exception ex)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										ex.Message,
										-1,
										MessageBoxButtons.OK);
								}
							}
							else
							{
								CustomerInfo customerInfo;
								this.Cursor = Cursors.WaitCursor;
								int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, false, out customerInfo);
								// 得意先チェック
								if (customerInfo != null)
								{
									if ((customerInfo.IsCustomer != true) && (customerInfo.IsReceiver != true))
									{
										status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
									}
								}
								this.Cursor = Cursors.Default;

								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									reCalcSalesPrice = true;

									// 納入先情報設定処理
									this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);
								}
								else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"得意先が存在しません。",
										-1,
										MessageBoxButtons.OK);
								}
								else
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_STOPDISP,
										this.Name,
										"得意先の取得に失敗しました。",
										status,
										MessageBoxButtons.OK);
								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);
						}

						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<
						getNextCtrl = true; //ADD 2009/12/23
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									// --- DEL 2009/12/23 ---------->>>>>
									//if (!string.IsNullOrEmpty(this.tNedit_AddresseeCode.Text))
									//{
									//    prevCtrl = this.uButton_AddresseeGuide;
									//}
									// --- DEL 2009/12/23 ----------<<<<<
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}
				#endregion

				#region 納入先名称
				//---------------------------------------------------------------
				// 納入先名称
				//---------------------------------------------------------------
				case "tEdit_AddresseeName":
					{
						if ((salesSlipCurrent.AddresseeName.Trim() + salesSlipCurrent.AddresseeName2.Trim()) != this.tEdit_AddresseeName.Text)
						{
							if (!(string.IsNullOrEmpty(this.tEdit_AddresseeName.Text)))
							{
								salesSlip.AddresseeName = this.tEdit_AddresseeName.Text;
								salesSlip.AddresseeName2 = string.Empty;
								if (this.tEdit_AddresseeName.Text.Length > 30)
									salesSlip.AddresseeName = this.tEdit_AddresseeName.Text.Substring(0, 30);
							}
						}

						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<
						getNextCtrl = true; //ADD 2009/12/23
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									// --- UPD 2009/12/23 ---------->>>>>
									//if (!string.IsNullOrEmpty(this.tEdit_AddresseeName.Text))
									//{
									//    prevCtrl = this.uButton_AddresseeGuide;
									//}
									if (string.IsNullOrEmpty(this.tEdit_AddresseeName.Text))
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_AddresseeGuide;
									}
									// --- UPD 2009/12/23 ----------<<<<<
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}
				#endregion

				#region 納入先確認
				//---------------------------------------------------------------
				// 納入先確認
				//---------------------------------------------------------------
				case "uButton_AddresseeConfirmation":
					{
						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						getNextCtrl = true;
						// --- UPD 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;
						#endregion

						break;
					}
				#endregion

				#region 納入先ガイド
				//---------------------------------------------------------------
				// 納入先ガイド
				//---------------------------------------------------------------
				case "uButton_AddresseeGuide":
					{
						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_AddresseeName;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_AddresseeName;
									break;
								default:
									break;
							}
						}
						// --- UPD 2009/12/23 ----------<<<<<
						#endregion

						break;
					}
				#endregion

				#region 得意先注番
				//---------------------------------------------------------------
				// 得意先注番
				//---------------------------------------------------------------
				case "tEdit_PartySaleSlipNum":
					{
						string value = this.tEdit_PartySaleSlipNum.Text;

						if (salesSlipCurrent.PartySaleSlipNum != value)
						{
							salesSlip.PartySaleSlipNum = value;
							if ((this._salesSlipInputAcs.PartySaleSlipDiv == (int)SalesSlipInputConstructionAcs.PartySaleSlipDiv.On) &&
								(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
							{
								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"得意先注番を明細へ展開します。" + "\r\n" +
									"よろしいですか？",
									0,
									MessageBoxButtons.YesNo,
									MessageBoxDefaultButton.Button1);
								if (dialogResult == DialogResult.Yes)
								{
									this._salesSlipInputAcs.SettingSalesDetailRowPartySaleSlipNum(salesSlip);
								}
							}
						}

						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						getNextCtrl = true;
						// --- UPD 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;
						#endregion

						break;
					}
				#endregion

				// --- ADD 2009/12/23 ---------->>>>>
				#region 備考１コード
				//---------------------------------------------------------------
				// 備考１コード
				//---------------------------------------------------------------
				case "tNedit_SlipNoteCode":
					{
						getNextCtrl = true;
						int value = this.tNedit_SlipNoteCode.GetInt();

						if (salesSlipCurrent.SlipNoteCode != value)
						{
							string noteGuideName = string.Empty;

							if (value == 0)
							{
								salesSlip.SlipNote = noteGuideName;

								salesSlip.SlipNoteCode = 0;
							}
							else
							{
								int status = this._salesSlipInputInitDataAcs.GetName_NoteGuidBd(SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_1,
									value, out noteGuideName);

								if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
								{
									// --- UPD 2010/02/02 ---------->>>>>
									//salesSlip.SlipNote = noteGuideName;
									if (this._salesSlipInputInitDataAcs.SlipNoteCharCnt != 0
										&& this._salesSlipInputInitDataAcs.SlipNoteCharCnt < noteGuideName.Length)
									{
										salesSlip.SlipNote = noteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNoteCharCnt);
									}
									else
									{
										salesSlip.SlipNote = noteGuideName;
									}
									// --- UPD 2010/02/02 ----------<<<<<

									salesSlip.SlipNoteCode = value;
								}
								else
								{
									TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"伝票備考コードが存在しません。",
									-1,
									MessageBoxButtons.OK);
								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);

							// 売上データキャッシュ処理
							this._salesSlipInputAcs.Cache(salesSlip);
						}

						#region NextCtrl制御
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (string.IsNullOrEmpty(this.tNedit_SlipNoteCode.Text.Trim()))
									{
										//getNextCtrl = false;
										//nextCtrl = uButton_SlipNote;
									}
									break;
								default:
									break;
							}
						}
						else
						{
							nextCtrl = null;
							getNextCtrlForFooter = true;
							getNextCtrl = false;
						}
						#endregion

						break;
					}

				#endregion

				#region 備考２コード
				//---------------------------------------------------------------
				// 備考２コード
				//---------------------------------------------------------------
				case "tNedit_SlipNote2Code":
					{
						getNextCtrl = true;
						int value = this.tNedit_SlipNote2Code.GetInt();

						if (salesSlipCurrent.SlipNote2Code != value)
						{
							string noteGuideName = string.Empty;

							if (value == 0)
							{
								salesSlip.SlipNote2 = noteGuideName;

								salesSlip.SlipNote2Code = 0;
							}
							else
							{
								int status = this._salesSlipInputInitDataAcs.GetName_NoteGuidBd(SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_2,
									value, out noteGuideName);

								if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
								{
									// --- UPD 2010/02/02 ---------->>>>>
									//salesSlip.SlipNote2 = noteGuideName;
									if (this._salesSlipInputInitDataAcs.SlipNote2CharCnt != 0
										&& this._salesSlipInputInitDataAcs.SlipNote2CharCnt < noteGuideName.Length)
									{
										salesSlip.SlipNote2 = noteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNote2CharCnt);
									}
									else
									{
										salesSlip.SlipNote2 = noteGuideName;
									}
									// --- UPD 2010/02/02 ----------<<<<<

                                    // ----- ADD K2011/08/12 --------------------------->>>>>
                                    // ----- ADD K2011/12/09 --------------------------->>>>>
                                    if (this._enterpriseCode == login_EnterpriseCode)
                                    {
                                    // ----- ADD K2011/12/09 ---------------------------<<<<<
                                        // 備考２
                                        if (this._salesSlipInputAcs == null)
                                        {
                                            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                                        }
                                        int countNum = 0;
                                        string PaperId = this._salesSlipInputAcs.CallGetSlipPrtSetPaperId(salesSlip);
                                        if (PaperId == "A995" || PaperId == "A998")
                                        {
                                            if (string.IsNullOrEmpty(noteGuideName))
                                            {
                                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                "",
                                                "ドットを２つ以上入力して下さい。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            }
                                            else
                                            {
                                                foreach (char car in noteGuideName)
                                                {
                                                    if (car == '.')
                                                    {
                                                        ++countNum;
                                                    }
                                                }
                                                if (countNum < 2)
                                                {
                                                    TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                    "",
                                                    "ドットを２つ以上入力して下さい。",
                                                    -1,
                                                    MessageBoxButtons.OK);
                                                }
                                            }
                                        }
                                    }// ADD K2011/12/09
                                    // ----- ADD K2011/08/12 ---------------------------<<<<<

									salesSlip.SlipNote2Code = value;
								}
								else
								{
									TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"伝票備考２コードが存在しません。",
									-1,
									MessageBoxButtons.OK);
								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);

							// 売上データキャッシュ処理
							this._salesSlipInputAcs.Cache(salesSlip);
						}

						#region NextCtrl制御
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (string.IsNullOrEmpty(this.tNedit_SlipNote2Code.Text.Trim()))
									{
										//getNextCtrl = false;
										//nextCtrl = this.uButton_SlipNote2;
									}
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}

				#endregion

				#region 備考３コード
				//---------------------------------------------------------------
				// 備考３コード
				//---------------------------------------------------------------
				case "tNedit_SlipNote3Code":
					{
						getNextCtrl = true;
						int value = this.tNedit_SlipNote3Code.GetInt();

						if (salesSlipCurrent.SlipNote3Code != value)
						{
							string noteGuideName = string.Empty;

							if (value == 0)
							{
								salesSlip.SlipNote3 = noteGuideName;

								salesSlip.SlipNote3Code = 0;
							}
							else
							{
								int status = this._salesSlipInputInitDataAcs.GetName_NoteGuidBd(SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_3,
									value, out noteGuideName);

								if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
								{
									// --- UPD 2010/02/02 ---------->>>>>
									//salesSlip.SlipNote3 = noteGuideName;
									if (this._salesSlipInputInitDataAcs.SlipNote3CharCnt != 0
										&& this._salesSlipInputInitDataAcs.SlipNote3CharCnt < noteGuideName.Length)
									{
										salesSlip.SlipNote3 = noteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNote3CharCnt);
									}
									else
									{
										salesSlip.SlipNote3 = noteGuideName;
									}
									// --- UPD 2010/02/02 ----------<<<<<

									salesSlip.SlipNote3Code = value;
								}
								else
								{
									TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"伝票備考３コードが存在しません。",
									-1,
									MessageBoxButtons.OK);
								}
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);

							// 売上データキャッシュ処理
							this._salesSlipInputAcs.Cache(salesSlip);
						}

						#region NextCtrl制御
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (string.IsNullOrEmpty(this.tNedit_SlipNote3Code.Text.Trim()))
									{
										//getNextCtrl = false;
										//nextCtrl = this.uButton_SlipNote3;
									}
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}

				#endregion

				// --- ADD 2009/12/23 ----------<<<<<

				#region 備考１
				//---------------------------------------------------------------
				// 備考１
				//---------------------------------------------------------------
				case "tEdit_SlipNote":
					{
						getNextCtrl = true;
						string value = this.tEdit_SlipNote.Text;

						if (salesSlipCurrent.SlipNote != value)
						{
							salesSlip.SlipNote = value;
						}

						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									// if (!string.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim())) prevCtrl = this.uButton_SlipNote; DEL 2009/12/23
									if (string.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()))
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_SlipNote;
									}
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}

				#endregion

				#region 備考２
				//---------------------------------------------------------------
				// 備考２
				//---------------------------------------------------------------
				case "tEdit_SlipNote2":
					{
						//getNextCtrl = false; DEL 2009/12/23
						getNextCtrl = true; // ADD 2009/12/23

						string value = this.tEdit_SlipNote2.Text;

						if (salesSlipCurrent.SlipNote2 != value)
						{
							salesSlip.SlipNote2 = value;
						}

                        // ----- ADD K2011/08/12 --------------------------->>>>>
                        // ----- ADD K2011/12/09 --------------------------->>>>>
                        bool errFlag = false;
                        if (this._enterpriseCode == login_EnterpriseCode)
                        {
                        // ----- ADD K2011/12/09 ---------------------------<<<<<
                            if (this._salesSlipInputAcs == null)
                            {
                                this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                            }
                            int countNum = 0;
                            //bool errFlag = false; // DEL K2011/12/09
                            string PaperId = this._salesSlipInputAcs.CallGetSlipPrtSetPaperId(salesSlip);
                            if (PaperId == "A995" || PaperId == "A998")
                            {
                                if (string.IsNullOrEmpty(salesSlip.SlipNote2))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    "",
                                    "ドットを２つ以上入力して下さい。",
                                    -1,
                                    MessageBoxButtons.OK);
                                    errFlag = true;
                                }
                                else
                                {
                                    foreach (char car in salesSlip.SlipNote2)
                                    {
                                        if (car == '.')
                                        {
                                            ++countNum;
                                        }
                                    }
                                    if (countNum < 2)
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "",
                                        "ドットを２つ以上入力して下さい。",
                                        -1,
                                        MessageBoxButtons.OK);
                                        errFlag = true;
                                    }
                                }
                            }
    
                        }// ADD K2011/12/09
                        // ----- ADD K2011/08/12 ---------------------------<<<<<
						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;

                        // ----- ADD K2011/08/12 --------------------------->>>>>
                        if (errFlag)
                        {
                            // ----- ADD K2011/12/09 --------------------------->>>>>
                            if (this._enterpriseCode == login_EnterpriseCode)
                            {
                            // ----- ADD K2011/12/09 ---------------------------<<<<<
                                // 指定フォーカス設定処理
                                e.NextCtrl = this.tEdit_SlipNote2;
                                this._changeFocusSaveCancel = true;
                                getNextCtrl = false;
                            }// ADD K2011/12/09
                        }
                        else
                        // ----- ADD K2011/08/12 ---------------------------<<<<<
						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									// if (!string.IsNullOrEmpty(this.tEdit_SlipNote2.Text.Trim())) prevCtrl = this.uButton_SlipNote2; DEL 2009/12/23
									if (string.IsNullOrEmpty(this.tEdit_SlipNote2.Text.Trim()))
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_SlipNote2;
									}
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}
				#endregion

				#region 備考３
				//---------------------------------------------------------------
				// 備考３
				//---------------------------------------------------------------
				case "tEdit_SlipNote3":
					{
						getNextCtrl = true; // ADD 2009/12/23

						string value = this.tEdit_SlipNote3.Text;

						if (salesSlipCurrent.SlipNote3 != value)
						{
							salesSlip.SlipNote3 = value;
						}

						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									// if (!string.IsNullOrEmpty(this.tEdit_SlipNote3.Text.Trim())) prevCtrl = this.uButton_SlipNote3; DEL 2009/12/23
									if (string.IsNullOrEmpty(this.tEdit_SlipNote3.Text.Trim()))
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_SlipNote3;
									}
									break;
								default:
									break;
							}
						}
						#endregion

						break;
					}
				#endregion

				#region 備考１ガイド
				//---------------------------------------------------------------
				// 備考１ガイド
				//---------------------------------------------------------------
				case "uButton_SlipNote":
					{
						// --- UPD 2009/12/23 ---------->>>>>
						//#region NextCtrl制御
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;
						//#endregion

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SlipNote;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SlipNote;
									break;
								default:
									break;
							}
						}
						// --- UPD 2009/12/23 ----------<<<<<

						break;
					}
				#endregion

				#region 備考２ガイド
				//---------------------------------------------------------------
				// 備考２ガイド
				//---------------------------------------------------------------
				case "uButton_SlipNote2":
					{
						// --- UPD 2009/12/23 ---------->>>>>
						//#region NextCtrl制御
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;
						//#endregion

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SlipNote2;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SlipNote2;
									break;
								default:
									break;
							}
						}

						// --- UPD 2009/12/23 ----------<<<<<

						break;
					}
				#endregion

				#region 備考３ガイド
				//---------------------------------------------------------------
				// 備考３ガイド
				//---------------------------------------------------------------
				case "uButton_SlipNote3":
					{
						// --- UPD 2009/12/23 ---------->>>>>
						//#region NextCtrl制御
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;
						//#endregion

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_SlipNote3;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_SlipNote3;
									break;
								default:
									break;
							}
						}
						// --- UPD 2009/12/23 ----------<<<<<

						break;
					}
				#endregion

				#region 返品理由
				//---------------------------------------------------------------
				// 返品理由
				//---------------------------------------------------------------
				case "tEdit_RetGoodsReason":
					{
						string value = this.tEdit_RetGoodsReason.Text;

						if (salesSlipCurrent.RetGoodsReason != value)
						{
							salesSlip.RetGoodsReason = value;
							salesSlip.RetGoodsReasonDiv = 0;
						}

						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						getNextCtrl = true;
						getNextCtrlForFooter = false;
						// --- UPD 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (string.IsNullOrEmpty(this.tEdit_RetGoodsReason.Text.Trim()))
									{
										getNextCtrl = false; // ADD 2009/12/23
										nextCtrl = this.uButton_RetGoodsReason;
									}
									break;
								default:
									break;
							}
						}
						#endregion
						break;
					}
				#endregion

				#region 返品理由ガイド
				//---------------------------------------------------------------
				// 返品理由ガイド
				//---------------------------------------------------------------
				case "uButton_RetGoodsReason":
					{
						// --- UPD 2009/12/23 ---------->>>>>
						//#region NextCtrl制御
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;
						//#endregion

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_RetGoodsReason;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_RetGoodsReason;
									break;
								default:
									break;
							}
						}
						// --- UPD 2009/12/23 ----------<<<<<

						break;
					}
				#endregion

				#region 納品区分
				//---------------------------------------------------------------
				// 納品区分
				//---------------------------------------------------------------
				case "tComboEditor_DeliveredGoodsDiv":
					{

						// 数値のみが入力されている場合は、入力値とvalueを比較する。
						System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
						if (regex.IsMatch(this.tComboEditor_DeliveredGoodsDiv.Text.Trim()))
						{
							int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_DeliveredGoodsDiv, ComboEditorGetDataType.TAG);
							string name = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_DeliveredGoodsDiv, code);

							if (code != -1)
							{
								salesSlip.DeliveredGoodsDiv = code;
								salesSlip.DeliveredGoodsDivNm = name;
								if (salesSlip.DeliveredGoodsDivNm.Length > 10) salesSlip.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm.Substring(0, 10);
							}
							else
							{
								// 設定内容を戻す
								salesSlip.DeliveredGoodsDiv = salesSlipCurrent.DeliveredGoodsDiv;
								salesSlip.DeliveredGoodsDivNm = salesSlipCurrent.DeliveredGoodsDivNm;
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);
						}
						else
						{
							int code = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_DeliveredGoodsDiv);
							string name = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_DeliveredGoodsDiv, code);

							if (code != -1)
							{
								salesSlip.DeliveredGoodsDiv = code;
								salesSlip.DeliveredGoodsDivNm = name;
								if (salesSlip.DeliveredGoodsDivNm.Length > 10) salesSlip.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm.Substring(0, 10);
							}
							else
							{
								// 設定内容を戻す
								salesSlip.DeliveredGoodsDiv = salesSlipCurrent.DeliveredGoodsDiv;
								salesSlip.DeliveredGoodsDivNm = salesSlipCurrent.DeliveredGoodsDivNm;
							}

							// 売上データクラス→画面格納処理
							this.SetDisplay(salesSlip);
						}

						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						getNextCtrl = true;
						getNextCtrlForFooter = false;
						// --- UPD 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;
						#endregion

						break;
					}
				#endregion

                //>>>2010/02/26
                #region 問合せ番号
                //---------------------------------------------------------------
                // 問合せ番号
                //---------------------------------------------------------------
                case "tNedit_InquiryNumber":
                    {
                        salesSlip.InquiryNumber = (long)this.tNedit_InquiryNumber.GetInt();

                        // 売上データクラス→画面格納処理
                        this.SetDisplay(salesSlip);

                        #region NextCtrl制御
                        nextCtrl = null;
                        getNextCtrl = false;
                        getNextCtrlForFooter = true;
                        prevCtrl = e.PrevCtrl;
                        #endregion

                        break;
                    }
                #endregion

                #region 回答区分
                //---------------------------------------------------------------
                // 回答区分
                //---------------------------------------------------------------
                case "tComboEditor_AnswerDiv":
                    {

                        // 数値のみが入力されている場合は、入力値とvalueを比較する。
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                        if (regex.IsMatch(this.tComboEditor_AnswerDiv.Text.Trim()))
                        {
                            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_AnswerDiv, ComboEditorGetDataType.TAG);
                            string name = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_AnswerDiv, code);

                            if (code != -1)
                            {
                                salesSlip.AnswerDiv = code;
                            }
                            else
                            {
                                // 設定内容を戻す
                                salesSlip.AnswerDiv = salesSlipCurrent.AnswerDiv;
                            }

                            // 売上データクラス→画面格納処理
                            this.SetDisplay(salesSlip);
                        }
                        else
                        {
                            int code = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AnswerDiv);
                            string name = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_AnswerDiv, code);

                            if (code != -1)
                            {
                                salesSlip.AnswerDiv = code;
                            }
                            else
                            {
                                // 設定内容を戻す
                                salesSlip.AnswerDiv = salesSlipCurrent.AnswerDiv;
                            }

                            // 売上データクラス→画面格納処理
                            this.SetDisplay(salesSlip);
                        }

                        #region NextCtrl制御
                        nextCtrl = null;
                        getNextCtrl = false;
                        getNextCtrlForFooter = true;
                        prevCtrl = e.PrevCtrl;
                        #endregion

                        break;
                    }
                #endregion
                //<<<2010/02/26
				#endregion

				#region ●車両情報
				#region 諸元情報
				//---------------------------------------------------------------
				// 諸元情報
				//---------------------------------------------------------------
				case "ultraGrid_CarSpec":
					{
						switch (e.Key)
						{
							case Keys.Up:
								getNextCtrl = false;
								e.NextCtrl = this.tEdit_FullModel;
								break;
							case Keys.Return:
							case Keys.Tab:
							case Keys.Down:
								getNextCtrl = false;
								e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
								break;
							default:
								break;
						}
						break;
					}
				#endregion

				#region 管理番号
				case "tEdit_CarMngCode":
					{
						// --- ADD 2009/09/08② ---------->>>>>
						int flag = 0; //フォーカス　0:次項目　1:型式

						int inputflag = 1;//管理番号　0:異なる　1:同じ
						// --- ADD 2009/09/08② ----------<<<<<

						if ((carInfoRowCurrent != null) &&
							(carInfoRowCurrent.CarMngCode != this.tEdit_CarMngCode.Text.Trim()))
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, this.tEdit_CarMngCode.Text.Trim());

							// --- ADD 2009/09/08② ---------->>>>>
							inputflag = 0;
						}

						//管理番号でのガイド表示設定
						if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
						{
							flag = SettingCarMngNoGuide(this.tEdit_CarMngCode.Text.Trim(), inputflag);
						}

						//追加情報タブ項目Visible設定
						SettingAddInfoVisible();

						//車種変更ボタンVisible設定
						SettingChangeCarInfoVisible();
						// --- ADD 2009/09/08② ----------<<<<<

						getNextCtrl = true;
						switch (e.Key)
						{
							case Keys.Down:
								getNextCtrl = false;
								e.NextCtrl = this.tNedit_ModelDesignationNo;
								break;
							// --- ADD 2009/09/08② ---------->>>>>
							case Keys.Return:
							case Keys.Tab:
								if (flag == 0)
								{
									prevCtrl = this.tEdit_CarMngCode;
								}
								else if (flag == 1)
								{
									getNextCtrl = false;
									nextCtrl = this.GetNextCtrlAfterCarSearch();
								}
								else
								{
									prevCtrl = this.tDateEdit_SalesDate;
								}
								break;
							// --- ADD 2009/09/08② ----------<<<<<
							default:
								break;
						}
						break;
					}
				#endregion

				#region 管理番号ガイド
				case "uButton_CarMngNoGuide":
					{
						switch (e.Key)
						{
							case Keys.Return:
							case Keys.Tab:
								getNextCtrl = false;
								e.NextCtrl = this.tNedit_ModelDesignationNo;
								break;
							default:
								break;
						}

						break;
					}
				#endregion

				#region 型式指定番号
				//---------------------------------------------------------------
				// 型式指定番号
				//---------------------------------------------------------------
				case "tNedit_ModelDesignationNo":
					{
						getNextCtrl = true;

						//if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
						//{
						//    if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
						//        (this.tNedit_CategoryNo.GetInt() != 0) &&
						//        (carInfoRowCurrent != null) &&
						//        ((this.tNedit_ModelDesignationNo.GetInt() != carInfoRowCurrent.ModelDesignationNo) ||
						//         (this.tNedit_CategoryNo.GetInt() != carInfoRowCurrent.CategoryNo) ||
						//         (this._salesSlipInputAcs.SearchCarDiv == true)))
						//    {
						//        this._salesSlipInputAcs.SearchCarDiv = false;
						//        CarSearchCondition con = new CarSearchCondition();
						//        con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
						//        con.CategoryNo = this.tNedit_CategoryNo.GetInt();
						//        con.Type = CarSearchType.csCategory;

						//        int result = this.CarSearch(con);

						//        switch ((ConstantManagement.MethodResult)result)
						//        {
						//            case ConstantManagement.MethodResult.ctFNC_CANCEL:
						//                getNextCtrl = false;
						//                e.NextCtrl = this.tNedit_ModelDesignationNo;
						//                this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, 0, 0);
						//                this.tNedit_ModelDesignationNo.Clear();
						//                this.tNedit_CategoryNo.Clear();
						//                break;
						//            case ConstantManagement.MethodResult.ctFNC_NORMAL:
						//                changeCarInfo = true;
						//                nextCtrl = this.GetNextCtrlAfterCarSearch();
						//                getNextCtrl = (nextCtrl == null);
						//                break;
						//            case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						//                DialogResult dialogResult = TMsgDisp.Show(
						//                    this,
						//                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
						//                    this.Name,
						//                    "該当する車両情報が存在しません。" + "\r\n" + "\r\n" +
						//                    "品番入力モードに変更しますか？",
						//                    0,
						//                    MessageBoxButtons.YesNo,
						//                    MessageBoxDefaultButton.Button1);
						//                if (dialogResult == DialogResult.Yes)
						//                {
						//                    this.ChangeSearchMode();
						//                    changeCarInfo = true;
						//                    getNextCtrl = true;
						//                    this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
						//                }
						//                else
						//                {
						//                    getNextCtrl = false;
						//                    e.NextCtrl = this.tNedit_ModelDesignationNo;
						//                    this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, 0, 0);
						//                    this.tNedit_ModelDesignationNo.Clear();
						//                    this.tNedit_CategoryNo.Clear();
						//                }
						//                break;
						//            default:
						//                break;
						//        }
						//    }
						//    else
						//    {
						//        this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
						//    }
						//}
						//else
						//{
						// --- DEL 2010/01/27 -------------->>>>>
						//this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
						// --- DEL 2010/01/27 --------------<<<<<
						//}

						if (!e.ShiftKey)
						{
							getNextCtrl = false;
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									e.NextCtrl = tNedit_CategoryNo;
									break;
								default:
									break;
							}
						}
						break;
					}
				#endregion

				#region 類別区分番号
				//---------------------------------------------------------------
				// 類別区分番号
				//---------------------------------------------------------------
				case "tNedit_CategoryNo":
					{
						if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
						{
							if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
								(this.tNedit_CategoryNo.GetInt() != 0) &&
								(carInfoRowCurrent != null) &&
								((this.tNedit_ModelDesignationNo.GetInt() != carInfoRowCurrent.ModelDesignationNo) ||
								 (this.tNedit_CategoryNo.GetInt() != carInfoRowCurrent.CategoryNo) ||
								 (this._salesSlipInputAcs.SearchCarDiv == true)))
							{
								this._salesSlipInputAcs.SearchCarDiv = false;
								CarSearchCondition con = new CarSearchCondition();
								con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
								con.CategoryNo = this.tNedit_CategoryNo.GetInt();
								con.Type = CarSearchType.csCategory;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										getNextCtrl = false;
										e.NextCtrl = this.tNedit_ModelDesignationNo;
										this.tNedit_ModelDesignationNo.Clear();
										this.tNedit_CategoryNo.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										changeCarInfo = true;
										nextCtrl = this.GetNextCtrlAfterCarSearch();
										getNextCtrl = (nextCtrl == null);
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
											"品番入力モードに変更しますか？",
											0,
											MessageBoxButtons.YesNo,
											//MessageBoxDefaultButton.Button1); // 2009/09/08 DEL
											MessageBoxDefaultButton.Button2); // 2009/09/08 ADD
										if (dialogResult == DialogResult.Yes)
										{
											this.ChangeSearchMode(0);
											changeCarInfo = true;
											getNextCtrl = true;
											this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
										}
										else
										{
											getNextCtrl = false;
											e.NextCtrl = this.tNedit_ModelDesignationNo;
											this.tNedit_ModelDesignationNo.Clear();
											this.tNedit_CategoryNo.Clear();
										}
										break;
									default:
										break;
								}
							}
							else
							{
								this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
								getNextCtrl = true;
								prevCtrl = this.tNedit_ModelDesignationNo;
								break;
							}
						}
						else
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
							getNextCtrl = true;
							prevCtrl = this.tNedit_ModelDesignationNo;
							break;
						}
						getNextCtrl = false;
						prevCtrl = this.tNedit_ModelDesignationNo;
						break;
					}
				#endregion

				#region 車両検索切替ボタン
				case "uButton_ChangeSearchCarMode":
					{
						switch (e.Key)
						{
							case Keys.Down:
								getNextCtrl = false;
								e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
								break;
							default:
								break;
						}
						break;
					}
				#endregion

				#region 型式／モデルプレート
				//---------------------------------------------------------------
				// 型式／モデルプレート
				//---------------------------------------------------------------
				case "tEdit_FullModel":
					{
						getNextCtrl = true;

						if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
						{
							if (this._salesSlipInputAcs.SearchCarModeProperty == SalesSlipInputAcs.SearchCarMode.FullModelSearch)
							{
								//---------------------------------------------------------------
								// 型式検索
								//---------------------------------------------------------------
								if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
									((carInfoRowCurrent == null) ||
									 (carInfoRowCurrent.FullModel != this.tEdit_FullModel.Text.Trim()) ||
									 (this._salesSlipInputAcs.SearchCarDiv == true)))
								{
									this._salesSlipInputAcs.SearchCarDiv = false;
									CarSearchCondition con = new CarSearchCondition();
									con.CarModel.FullModel = this.tEdit_FullModel.Text;
									con.Type = CarSearchType.csModel;

									int result = this.CarSearch(con);

									switch ((ConstantManagement.MethodResult)result)
									{
										case ConstantManagement.MethodResult.ctFNC_CANCEL:
											getNextCtrl = false;
											e.NextCtrl = e.PrevCtrl;
											this.tEdit_FullModel.Clear();
											break;
										case ConstantManagement.MethodResult.ctFNC_NORMAL:
											changeCarInfo = true;
											nextCtrl = this.GetNextCtrlAfterCarSearch();
											getNextCtrl = (nextCtrl == null);
											break;
										case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
												"品番入力モードに変更しますか？",
												0,
												MessageBoxButtons.YesNo,
												//MessageBoxDefaultButton.Button1); // 2009/09/08 DEL
												MessageBoxDefaultButton.Button2); // 2009/09/08 ADD
											if (dialogResult == DialogResult.Yes)
											{
												this.ChangeSearchMode(0);
												changeCarInfo = true;
												getNextCtrl = true;
												this._salesSlipInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, this.tEdit_FullModel.Text);
											}
											else
											{
												getNextCtrl = false;
												e.NextCtrl = e.PrevCtrl;
												this.tEdit_FullModel.Clear();
											}
											break;
										default:
											break;
									}
								}
								else
								{
									//// 車両情報クリア
									//if ((!string.IsNullOrEmpty(carInfoRowCurrent.FullModel)) &&
									//    (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())))
									//{
									//    changeCarInfo = true;
									//    this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
									//}
								}
							}
							else if (this._salesSlipInputAcs.SearchCarModeProperty == SalesSlipInputAcs.SearchCarMode.ModelPlateSearch)
							{
								//---------------------------------------------------------------
								// モデルプレート検索
								//---------------------------------------------------------------
								if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
									((carInfoRowCurrent == null) ||
									 (carInfoRowCurrent.FullModel != this.tEdit_FullModel.Text.Trim()) ||
									 (this._salesSlipInputAcs.SearchCarDiv == true)))
								{
									this._salesSlipInputAcs.SearchCarDiv = false;
									CarSearchCondition con = new CarSearchCondition();
									con.ModelPlate = this.tEdit_FullModel.Text;
									con.Type = CarSearchType.csPlate;

									int result = this.CarSearch(con);

									switch ((ConstantManagement.MethodResult)result)
									{
										case ConstantManagement.MethodResult.ctFNC_CANCEL:
											getNextCtrl = false;
											e.NextCtrl = e.PrevCtrl;
											this.tEdit_FullModel.Clear();
											break;
										case ConstantManagement.MethodResult.ctFNC_NORMAL:
											changeCarInfo = true;
											nextCtrl = this.GetNextCtrlAfterCarSearch();
											getNextCtrl = (nextCtrl == null);
											break;
										case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												"該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
												"品番入力モードに変更しますか？",
												0,
												MessageBoxButtons.YesNo,
												//MessageBoxDefaultButton.Button1); // 2009/09/08 DEL
												MessageBoxDefaultButton.Button2); // 2009/09/08 ADD
											if (dialogResult == DialogResult.Yes)
											{
												this.ChangeSearchMode(0);
												changeCarInfo = true;
												getNextCtrl = true;
												this._salesSlipInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, this.tEdit_FullModel.Text);
											}
											else
											{
												getNextCtrl = false;
												e.NextCtrl = e.PrevCtrl;
												this.tEdit_FullModel.Clear();
											}
											break;
										default:
											break;
									}
								}
								else
								{
									//// 車両情報クリア
									//if ((!string.IsNullOrEmpty(carInfoRowCurrent.FullModel)) &&
									//    (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())))
									//{
									//    changeCarInfo = true;
									//    this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
									//}
								}

							}
						}
						else
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, this.tEdit_FullModel.Text);
						}

						switch (e.Key)
						{
							case Keys.Down:
								getNextCtrl = false;
								e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
								break;
							case Keys.Up:
								getNextCtrl = false;
								e.NextCtrl = tNedit_ModelDesignationNo;
								break;
							default:
								break;
						}
						break;
					}
				#endregion

				#region エンジン型式
				//---------------------------------------------------------------
				// エンジン型式
				//---------------------------------------------------------------
				case "tEdit_EngineModelNm":
					{
						getNextCtrl = true;

						if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
						{
							if ((!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text.Trim())) &&
								((carInfoRowCurrent == null) ||
								 (carInfoRowCurrent.EngineModelNm != this.tEdit_EngineModelNm.Text.Trim()) ||
								 (this._salesSlipInputAcs.SearchCarDiv == true)))
							{
								this._salesSlipInputAcs.SearchCarDiv = false;
								CarSearchCondition con = new CarSearchCondition();
								con.EngineModel.FullModel = this.tEdit_EngineModelNm.Text;
								con.Type = CarSearchType.csEngineModel;

								int result = this.CarSearch(con);

								switch ((ConstantManagement.MethodResult)result)
								{
									case ConstantManagement.MethodResult.ctFNC_CANCEL:
										getNextCtrl = false;
										e.NextCtrl = e.PrevCtrl;
										this.tEdit_EngineModelNm.Clear();
										break;
									case ConstantManagement.MethodResult.ctFNC_NORMAL:
										changeCarInfo = true;
										nextCtrl = this.GetNextCtrlAfterCarSearch();
										getNextCtrl = (nextCtrl == null);
										break;
									case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
										DialogResult dialogResult = TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_EXCLAMATION,
											this.Name,
											"該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
											"品番入力モードに変更しますか？",
											0,
											MessageBoxButtons.YesNo,
											//MessageBoxDefaultButton.Button1); // 2009/09/08 DEL
											MessageBoxDefaultButton.Button2); // 2009/09/08 ADD
										if (dialogResult == DialogResult.Yes)
										{
											this.ChangeSearchMode(0);
											changeCarInfo = true;
											getNextCtrl = true;
											this._salesSlipInputAcs.SettingCarInfoRowFromEngineModelNm(salesRowNo, this.tEdit_EngineModelNm.Text);
										}
										else
										{
											getNextCtrl = false;
											e.NextCtrl = e.PrevCtrl;
											this.tEdit_EngineModelNm.Clear();
										}
										break;
									default:
										break;
								}
							}
						}
						else
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromEngineModelNm(salesRowNo, this.tEdit_EngineModelNm.Text);
						}
						break;
					}
				#endregion

				#region カラー
				//---------------------------------------------------------------
				// カラー
				//---------------------------------------------------------------
				case "tEdit_ColorNo":
					{
                        // >>>2010/02/26
                        // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                        if (carInfoRowCurrent != null)
                        {
                            // <<<2010/02/26
                            if (this.tEdit_ColorNo.Text.Trim() != string.Empty)
                            {
                                string currentColorCode = carInfoRowCurrent.ColorCode;
                                if (!this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim()))
                                {
                                    this.tEdit_ColorNo.Text = string.Empty;
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "カラーコードが設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    this.tEdit_ColorNo.Text = currentColorCode;
                                    this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim());
                                    e.NextCtrl = prevCtrl;
                                    changeCarInfo = false;
                                    getNextCtrl = false;
                                    break;
                                }
                            }
                            else
                            {
                                this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim());
                            }
                        }  //2010/02/26
                        getNextCtrl = true;
						break;
					}
				#endregion

				#region トリム
				//---------------------------------------------------------------
				// トリム
				//---------------------------------------------------------------
				case "tEdit_TrimNo":
					{
                        // >>>2010/02/26
                        // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                        if (carInfoRowCurrent != null)
                        {
                            // <<<2010/02/26
                            if (this.tEdit_TrimNo.Text.Trim() != string.Empty)
                            {
                                string currentTrimCode = carInfoRowCurrent.TrimCode;
                                if (!this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim()))
                                {
                                    this.tEdit_TrimNo.Text = string.Empty;
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "トリムコードが設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    this.tEdit_TrimNo.Text = currentTrimCode;
                                    this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim());
                                    e.NextCtrl = prevCtrl;
                                    changeCarInfo = false;
                                    getNextCtrl = false;
                                    break;
                                }
                            }
                            else
                            {
                                this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim());
                            }

                        }  // 2010/02/26
                        getNextCtrl = true;

						switch (e.Key)
						{
							case Keys.Down:
								getNextCtrl = false;
								e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
								break;
							default:
								break;
						}

						break;
					}
				#endregion

				#region カーメーカーコード
				case "tNedit_MakerCode":
					{
						changeCarInfo = false;
						getNextCtrl = false;

						if ((carInfoRowCurrent != null) &&
							(carInfoRowCurrent.MakerCode != this.tNedit_MakerCode.GetInt()))
						{
							if (this.tNedit_MakerCode.GetInt() != 0)
							{
								int makerCode = this.tNedit_MakerCode.GetInt();
								string name = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
								string hName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
								this.tEdit_ModelFullName.Text = name;
								if (string.IsNullOrEmpty(name))
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"入力したメーカーコードは存在しません。",
										-1,
										MessageBoxButtons.OK);
									e.NextCtrl = e.PrevCtrl;
									this.tNedit_MakerCode.SetInt(carInfoRowCurrent.MakerCode);
									this.tEdit_ModelFullName.Text = carInfoRowCurrent.MakerFullName;
									this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, carInfoRowCurrent.ModelCode, carInfoRowCurrent.ModelSubCode, carInfoRowCurrent.ModelFullName, carInfoRowCurrent.ModelHalfName);
									break;
								}
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, 0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, name, hName, 0, 0, string.Empty, string.Empty);
								changeCarInfo = true;
							}
							else
							{
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, 0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
								changeCarInfo = true;
							}
						}

						#region NextCtrl制御
						getNextCtrl = true;
						// NextCtrl制御
						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (this.tNedit_MakerCode.GetInt() == 0)
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_ModelFullGuide;
									}
									break;
								default:
									break;
							}
							if (nextCtrl != null) e.NextCtrl = nextCtrl;
						}
						#endregion
						break;
					}
				#endregion

				#region 車種コード
				case "tNedit_ModelCode":
					{
						changeCarInfo = false;
						getNextCtrl = false;
						if ((carInfoRowCurrent != null) &&
							((carInfoRowCurrent.ModelCode != this.tNedit_ModelCode.GetInt()) ||
							 (carInfoRowCurrent.ModelSubCode != this.tNedit_ModelSubCode.GetInt())))
						{
							if (this.tNedit_ModelCode.GetInt() != 0)
							{
								int makerCode = this.tNedit_MakerCode.GetInt();
								string makerName = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
								string makerHName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
								int modelCode = this.tNedit_ModelCode.GetInt();
								int modelSubCode = this.tNedit_ModelSubCode.GetInt();
								string name = this._salesSlipInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
								string hName = this._salesSlipInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
								this.tEdit_ModelFullName.Text = name;
								if (string.IsNullOrEmpty(name))
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"入力した車種コードは存在しません。",
										-1,
										MessageBoxButtons.OK);
									e.NextCtrl = e.PrevCtrl;
									//modelSubCode = 0;
									this.tNedit_ModelCode.SetInt(carInfoRowCurrent.ModelCode);
									this.tEdit_ModelFullName.Text = carInfoRowCurrent.ModelFullName;
									this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, carInfoRowCurrent.ModelCode, carInfoRowCurrent.ModelSubCode, carInfoRowCurrent.ModelFullName, carInfoRowCurrent.ModelHalfName);
									break;
								}
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
								changeCarInfo = true;
								getNextCtrl = true;
							}
							else
							{
								int makerCode = carInfoRowCurrent.MakerCode;
								string makerName = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
								string makerHName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
								int modelCode = 0;
								int modelSubCode = 0;
								string name = string.Empty;
								string hName = string.Empty;
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
								changeCarInfo = true;
								getNextCtrl = true;
							}
						}
						else
						{
							getNextCtrl = true;
						}
						break;
					}
				#endregion

				#region 車種呼称コード
				case "tNedit_ModelSubCode":
					{
						changeCarInfo = false;
						getNextCtrl = false;
						if ((carInfoRowCurrent != null) &&
							((carInfoRowCurrent.ModelCode != this.tNedit_ModelCode.GetInt()) ||
							 (carInfoRowCurrent.ModelSubCode != this.tNedit_ModelSubCode.GetInt())))
						{
							if (this.tNedit_ModelSubCode.GetInt() != 0)
							{
								int makerCode = this.tNedit_MakerCode.GetInt();
								string makerName = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
								string makerHName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
								int modelCode = this.tNedit_ModelCode.GetInt();
								int modelSubCode = this.tNedit_ModelSubCode.GetInt();
								string name = this._salesSlipInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
								string hName = this._salesSlipInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
								this.tEdit_ModelFullName.Text = name;
								if (string.IsNullOrEmpty(name))
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"入力した車種呼称コードは存在しません。",
										-1,
										MessageBoxButtons.OK);
									e.NextCtrl = e.PrevCtrl;
									this.tNedit_ModelCode.SetInt(carInfoRowCurrent.ModelCode);
									this.tNedit_ModelSubCode.SetInt(carInfoRowCurrent.ModelSubCode);
									this.tEdit_ModelFullName.Text = carInfoRowCurrent.ModelFullName;
									this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, carInfoRowCurrent.ModelCode, carInfoRowCurrent.ModelSubCode, carInfoRowCurrent.ModelFullName, carInfoRowCurrent.ModelHalfName);
									break;
								}
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
								changeCarInfo = true;
								getNextCtrl = true;
							}
							else
							{
								int makerCode = carInfoRowCurrent.MakerCode;
								string makerName = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
								string makerHName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
								int modelCode = carInfoRowCurrent.ModelCode;
								int modelSubCode = 0;
								string name = this._salesSlipInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
								string hName = this._salesSlipInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
								this._salesSlipInputAcs.ClearCarInfoRow(salesRowNo);
								this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
								changeCarInfo = true;
								getNextCtrl = true;
							}
						}
						else
						{
							getNextCtrl = true;
						}

						break;
					}
				#endregion

				#region 車種名称
				case "tEdit_ModelFullName":
					{
						int makerCode = this.tNedit_MakerCode.GetInt();
						string makerName = this._salesSlipInputInitDataAcs.GetName_FromMaker(makerCode);
						string makerHName = this._salesSlipInputInitDataAcs.GetKanaName_FromMaker(makerCode);
						int modelCode = this.tNedit_ModelCode.GetInt();
						int modelSubCode = this.tNedit_ModelSubCode.GetInt();
						string name = this.tEdit_ModelFullName.Text.Trim();

						if ((modelCode == 0) && (modelSubCode == 0))
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, name, string.Empty, modelCode, modelSubCode, string.Empty, string.Empty);
						}
						else
						{
							this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerHName, modelCode, modelSubCode, name, string.Empty);
						}

						changeCarInfo = true;
						getNextCtrl = true;

						// NextCtrl制御
						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if (this.tEdit_ModelFullName.Text.Trim() == string.Empty)
									{
										nextCtrl = this.uButton_ModelFullGuide;
										getNextCtrl = false;
									}
									break;
								default:
									break;
							}
						}
						break;
					}
				#endregion

				#region 車種ガイドボタン
				//---------------------------------------------------------------
				// 車種ガイドボタン
				//---------------------------------------------------------------
				case "uButton_ModelFullGuide":
					{
						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									if ((this.tEdit_ModelFullName.Enabled) && (this.tEdit_ModelFullName.Visible))
									{
										nextCtrl = this.tEdit_ModelFullName;
									}
									else
									{
										nextCtrl = this.tNedit_MakerCode;
									}
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_ModelFullName;
									break;
								default:
									break;
							}
						}

						break;

					}
				#endregion

				#region 年式
				case "tDateEdit_FirstEntryDate":
					{
						TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
						DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate(ref tempFirstEntryDate, true);
						if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"日付が不正です。",
								-1,
								MessageBoxButtons.OK);
							e.NextCtrl = prevCtrl;
							changeCarInfo = true;
							getNextCtrl = false;

						}
						else
						{

							int newValue = this.tDateEdit_FirstEntryDate.GetLongDate();
                            // >>>2010/02/26
                            // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                            //if (carInfoRowCurrent.ProduceTypeOfYearInput != (newValue / 100))
                            if (carInfoRowCurrent != null && carInfoRowCurrent.ProduceTypeOfYearInput != (newValue / 100))
                            // <<<2010/02/26
                            {
								if (this._salesSlipInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate()))
								{
									// 年式設定処理
									this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, tDateEdit_FirstEntryDate.GetLongDate());
									this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate());
									changeCarInfo = true;
									getNextCtrl = true;
								}
								else
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"生産年式が設定範囲外です。",
										-1,
										MessageBoxButtons.OK);
									e.NextCtrl = prevCtrl;
									changeCarInfo = false;
									getNextCtrl = false;

									this.tDateEdit_FirstEntryDate.SetLongDate(carInfoRowCurrent.ProduceTypeOfYearInput * 100);  // 2009.06.17 Add 
								}
							}
							else
							{
								getNextCtrl = true;
							}

							switch (e.Key)
							{
								case Keys.Down:
									getNextCtrl = false;
									e.NextCtrl = this.tEdit_ProduceFrameNo;
									break;
								default:
									break;
							}
						}
						break;
					}
				#endregion

				#region 車台番号
				case "tEdit_ProduceFrameNo":
					{
						bool canChangeFocus = true;

						string newValue = this.tEdit_ProduceFrameNo.Text;
						int newIntValue = TStrConv.StrToIntDef(newValue.Trim(), 0);
                        // >>>2010/02/26
                        // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                        //if (carInfoRowCurrent.FrameNo != newValue)
                        if (carInfoRowCurrent != null && carInfoRowCurrent.FrameNo != newValue)
                        // <<<2010/02/26
                        {
							// 2009.06.17 >>>
							//// 車台番号設定処理
							//this._salesSlipInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
							//this._salesSlipInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

							//// 年式取得処理
							//int firstEntryDate = this._salesSlipInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

							//// 年式設定処理
							//if (firstEntryDate != 0) this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);

							//this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

							//changeCarInfo = true;

							// 車台番号番号のチェック
							// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 DEL
							//if (this._salesSlipInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newIntValue))
							// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 DEL
							// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 ADD
							if (this._salesSlipInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue, newIntValue))
							// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 ADD
							{
								// 車台番号設定処理
								this._salesSlipInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
								this._salesSlipInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

								// 年式取得処理
								int firstEntryDate = this._salesSlipInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

								// 年式設定処理
								// 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
								//if (firstEntryDate != 0) this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);

								// --- UPD 2009/12/23 ---------->>>>>
								//if (firstEntryDate != 0)
								//{
								//    this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
								//    this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, firstEntryDate);
								//}
								this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
								this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, firstEntryDate);
								// --- UPD 2009/12/23 ----------<<<<<

								// 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD

								this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

								changeCarInfo = true;

                                // --- ADD 2013/03/21 ---------->>>>>
                                // PMNS:ハンドル位置のチェック
                                // 型式が入力済みかつ、メーカーコードがBENZ、
                                // VINコードが入力済みの場合(外車の場合)
                                // ハンドル位置をチェックする
                                if (!string.IsNullOrEmpty(carInfoRowCurrent.FullModel) &&
                                    carInfoRowCurrent.MakerCode == 80 &&
                                    carInfoRowCurrent.DomesticForeignCode == 2 &&
                                    !this._salesSlipInputAcs.CheckHandlePosition(carInfoRowCurrent.CarRelationGuid, carInfoRowCurrent.FrameNo))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "ハンドル位置が異なります。",
                                    -1,
                                    MessageBoxButtons.OK);
                                    e.NextCtrl = prevCtrl;
                                    changeCarInfo = false;
                                    getNextCtrl = false;
                                    canChangeFocus = false;
                                    this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                                }
                                // --- ADD 2013/03/21 ----------<<<<<
							}
							else
							{
								TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"車台番号が設定範囲外です。",
										-1,
										MessageBoxButtons.OK);
								e.NextCtrl = prevCtrl;
								changeCarInfo = false;
								getNextCtrl = false;
								canChangeFocus = false;

								this.tEdit_ProduceFrameNo.Text = carInfoRowCurrent.FrameNo;
								this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
							}
							// 2009.06.17 <<<
						}

						getNextCtrl = canChangeFocus;
						// 2009.06.17 >>>
						//switch (e.Key)
						//{
						//    case Keys.Down:
						//        getNextCtrl = false;
						//        e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
						//        break;
						//    default:
						//        break;
						//}
						if (getNextCtrl)
						{
							switch (e.Key)
							{
								case Keys.Down:
									getNextCtrl = false;
									e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
									break;
								default:
									break;
							}
						}
						// 2009.06.17 <<<
						break;


						//int newValue = this.tEdit_ProduceFrameNo.GetInt();
						//if (carInfoRowCurrent.ProduceFrameNoInput != newValue)
						//{
						//    // 車台番号設定処理
						//    this._salesSlipInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, tEdit_ProduceFrameNo.GetInt());
						//    this._salesSlipInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, tEdit_ProduceFrameNo.GetInt());

						//    // 年式取得処理
						//    int firstEntryDate = this._salesSlipInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, tEdit_ProduceFrameNo.GetInt());

						//    // 年式設定処理
						//    if (firstEntryDate != 0) this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);

						//    this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

						//    changeCarInfo = true;
						//    getNextCtrl = true;
						//}
						//else
						//{
						//    getNextCtrl = true;
						//}

						//switch (e.Key)
						//{
						//    case Keys.Down:
						//        getNextCtrl = false;
						//        e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
						//        break;
						//    default:
						//        break;
						//}

						//break;
					}
				#endregion
				#endregion

				#region ●メモ
				//---------------------------------------------------------------
				// 伝票メモ
				//---------------------------------------------------------------
				case "tEdit_InsideMemo1":
				case "tEdit_InsideMemo2":
				case "tEdit_InsideMemo3":
				case "tEdit_SlipMemo1":
				case "tEdit_SlipMemo2":
				case "tEdit_SlipMemo3":
					{
						this.SetSlipMemo();
						// 明細グリッド設定処理
						this._salesSlipDetailInput.SettingGrid();
						break;
					}
				#endregion

				// --- ADD 2009/09/08② ---------->>>>>
				#region ●車輌管理追加情報
				#region 車輌備考
				//---------------------------------------------------------------
				// 車輌備考
				//---------------------------------------------------------------
				case "tEdit_CarSlipNote":
					{

						string carSlipNote = this.tEdit_CarSlipNote.Text;
                        // >>>2010/02/26
                        // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                        //if (carInfoRowCurrent.CarNote != carSlipNote)
                        if (carInfoRowCurrent != null && carInfoRowCurrent.CarNote != carSlipNote)
                        // <<<2010/02/26
                        {
							// 車輌備考設定処理
							this._salesSlipInputAcs.SettingCarInfoRowFromCarNote(salesRowNo, carSlipNote);

							this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

							changeCarInfo = true;
						}

						#region NextCtrl制御
						// --- DEL 2009/12/23 ---------->>>>>
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						// --- DEL 2009/12/23 ----------<<<<<

						getNextCtrl = true; //ADD 2009/12/23
						prevCtrl = e.PrevCtrl;

						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									//if (!string.IsNullOrEmpty(this.tEdit_CarSlipNote.Text.Trim())) DEL 2009/12/23
									if (string.IsNullOrEmpty(this.tEdit_CarSlipNote.Text.Trim())) //ADD 2009/12/23
									{
										getNextCtrl = false;
										nextCtrl = this.uButton_SlipNoteGuide;
									}
									break;
								default:
									break;
							}
						}
						#endregion
						break;
					}
				#endregion

				#region 走行距離
				//---------------------------------------------------------------
				// 走行距離
				//---------------------------------------------------------------
				case "tNedit_Mileage":
					{
						int mileage = this.tNedit_Mileage.GetInt();
                        // >>>2010/02/26
                        // 有効な明細がない状態で、確定か回答処理後、carInfoRowCurrentがnullなのでエラーで落ちる。
                        //if (carInfoRowCurrent.Mileage != mileage)
                        if (carInfoRowCurrent != null && carInfoRowCurrent.Mileage != mileage)
                        // <<<2010/02/26
                        {
							// 車輌備考設定処理
							this._salesSlipInputAcs.SettingCarInfoRowFromMileage(salesRowNo, mileage);

							this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

							changeCarInfo = true;
						}

						#region NextCtrl制御
						nextCtrl = null;
						// --- UPD 2009/12/23 ---------->>>>>
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						getNextCtrl = true;
						// --- UPD 2009/12/23 ----------<<<<<
						prevCtrl = e.PrevCtrl;
						#endregion
						break;
					}
				#endregion

				#region 車輌備考ガイド
				//---------------------------------------------------------------
				// 車輌備考ガイド
				//---------------------------------------------------------------
				case "uButton_SlipNoteGuide":
					{
						// --- UPD 2009/12/23 ---------->>>>>
						#region NextCtrl制御
						//nextCtrl = null;
						//getNextCtrl = false;
						//getNextCtrlForFooter = true;
						//prevCtrl = e.PrevCtrl;
						//this._prevControl = this.tNedit_Mileage;
						#endregion

						getNextCtrl = true;

						if (e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									nextCtrl = this.tEdit_CarSlipNote;
									getNextCtrl = false;
									break;
								default:
									break;
							}
						}
						else
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									prevCtrl = this.tEdit_CarSlipNote;
									break;
								default:
									break;
							}
						}
						// --- UPD 2009/12/23 ----------<<<<<

						break;
					}
				#endregion

				#endregion
				// --- ADD 2009/09/08② ----------<<<<<

#if false // 見積情報
				#region ●見積情報
                //---------------------------------------------------------------
                // 見積タイトル
                //---------------------------------------------------------------
                case "tEdit_EstimateSubject":
                    {
                        string value = this.tEdit_EstimateSubject.Text;
                        if (salesSlipCurrent.EstimateSubject != value)
                        {
                            salesSlip.EstimateSubject = value;
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // 備考１
                //---------------------------------------------------------------
                case "tEdit_EstimateNote1":
                    {
                        string value = this.tEdit_EstimateNote1.Text;
                        if (salesSlipCurrent.EstimateNote1 != value)
                        {
                            salesSlip.EstimateNote1 = value;
                        }
                        break;
                    }

                //---------------------------------------------------------------
                // 備考２
                //---------------------------------------------------------------
                case "tEdit_EstimateNote2":
                    {
                        string value = this.tEdit_EstimateNote2.Text;
                        if (salesSlipCurrent.EstimateNote2 != value)
                        {
                            salesSlip.EstimateNote2 = value;
                        }
                        break;
                    }

                //---------------------------------------------------------------
                // 備考３
                //---------------------------------------------------------------
                case "tEdit_EstimateNote3":
                    {
                        string value = this.tEdit_EstimateNote3.Text;
                        if (salesSlipCurrent.EstimateNote3 != value)
                        {
                            salesSlip.EstimateNote3 = value;
                        }
                        break;
                    }

                //---------------------------------------------------------------
                // 品番印刷
                //---------------------------------------------------------------
                case "tComboEditor_GoodsNoPrintDiv":
                    {
                        // 数値のみが入力されている場合は、入力値とvalueを比較する。
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                        if (regex.IsMatch(this.tComboEditor_GoodsNoPrintDiv.Text.Trim()))
                        {
                            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_GoodsNoPrintDiv, ComboEditorGetDataType.TAG);

                            if (code != -1)
                            {
                                salesSlip.PartsNoPrtCd = code;
                            }
                            else
                            {
                                salesSlip.PartsNoPrtCd = 0;
                            }
                        }
                        else if (salesSlipCurrent.PartsNoPrtCd != (int)this.tComboEditor_GoodsNoPrintDiv.Value)
                        {
                            int code = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_GoodsNoPrintDiv);

                            if (code != -1)
                            {
                                salesSlip.PartsNoPrtCd = code;
                            }
                            else
                            {
                                salesSlip.PartsNoPrtCd = 0;
                            }
                        }
                        // 売上データクラス→画面格納処理
                        this.SetDisplay(salesSlip);

                        break;
                    }

                //---------------------------------------------------------------
                // 定価印刷
                //---------------------------------------------------------------
                case "tComboEditor_ListPricePrintDiv":
                    {
                        // 数値のみが入力されている場合は、入力値とvalueを比較する。
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                        if (regex.IsMatch(this.tComboEditor_ListPricePrintDiv.Text.Trim()))
                        {
                            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_ListPricePrintDiv, ComboEditorGetDataType.TAG);

                            if (code != -1)
                            {
                                salesSlip.ListPricePrintDiv = code;
                            }
                            else
                            {
                                salesSlip.ListPricePrintDiv = 0;
                            }
                        }
                        else if (salesSlipCurrent.ListPricePrintDiv != (int)this.tComboEditor_ListPricePrintDiv.Value)
                        {
                            int code = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_ListPricePrintDiv);

                            if (code != -1)
                            {
                                salesSlip.ListPricePrintDiv = code;
                            }
                            else
                            {
                                salesSlip.ListPricePrintDiv = 0;
                            }
                        }
                        // 売上データクラス→画面格納処理
                        this.SetDisplay(salesSlip);

                        break;
                    }

                //---------------------------------------------------------------
                // 見積有効期限
                //---------------------------------------------------------------
                case "tDateEdit_EstimateValidityDate":
                    {
                        getNextCtrl = true;
                        DateTime value = this.tDateEdit_EstimateValidityDate.GetDateTime();

                        if (salesSlipCurrent.EstimateValidityDate != value)
                        {
                            if (value == DateTime.MinValue)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "日付が入力されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tDateEdit_EstimateValidityDate.SetDateTime(salesSlipCurrent.EstimateValidityDate);
                                e.NextCtrl = prevCtrl;
                                getNextCtrl = false;
                            }
                            else
                            {
                                salesSlip.EstimateValidityDate = value;
                            }
                        }
                        break;
                    }
				#endregion
#endif
			}

			//---------------------------------------------------------------
			// メモリ上の内容と比較
			//---------------------------------------------------------------
			ArrayList arRetList = salesSlip.Compare(salesSlipCurrent);

			//---------------------------------------------------------------
			// 売上データ変更時
			//---------------------------------------------------------------
			if ((arRetList.Count > 0) || (isCache))
			{
				// 売上データキャッシュ処理
				this._salesSlipInputAcs.CacheForChange(salesSlip);

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// データ変更フラグプロパティをTrueにする
				this._salesSlipInputAcs.IsDataChanged = true;
			}

			//---------------------------------------------------------------
			// 車両情報変更時
			//---------------------------------------------------------------
			if (changeCarInfo == true)
			{
				// 車両情報画面表示処理
				this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// データ変更フラグプロパティをTrueにする
				this._salesSlipInputAcs.IsDataChanged = true;

				// --- ADD 2009/09/08② ---------->>>>>
				//追加情報タブ項目Visible設定
				SettingAddInfoVisible();
				// --- ADD 2009/09/08② ----------<<<<<
			}
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
			//----------------------------------------------------------------
			// 車輌検索前に退避しておいた内容の再セット
			//----------------------------------------------------------------
			# region [車輌検索前に退避しておいた内容の再セット]
			// 退避しておいた値のセット（※UI表示の都合により先にセットだけしておき、まとめて入力チェックする）
			// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//if (this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty)
			if ((this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty) &&
				(string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text)))
			// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			{
				tEdit_ProduceFrameNo.Text = this._beforeCarSearchBuffer.ProduceFrameNo;
			}
			// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//if (this._beforeCarSearchBuffer.FirstEntryDate != 0)
			int idate = this.tDateEdit_FirstEntryDate.GetLongDate();
			if ((this._beforeCarSearchBuffer.FirstEntryDate != 0) &&
				(idate == 0))
			// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			{
				tDateEdit_FirstEntryDate.SetLongDate(this._beforeCarSearchBuffer.FirstEntryDate);
			}
			if (this._beforeCarSearchBuffer.ColorNo != string.Empty)
			{
				tEdit_ColorNo.Text = this._beforeCarSearchBuffer.ColorNo;
			}
			if (this._beforeCarSearchBuffer.TrimNo != string.Empty)
			{
				tEdit_TrimNo.Text = this._beforeCarSearchBuffer.TrimNo;
			}

			// 入力チェック
			// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//if (this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty)
			if ((this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty) ||
				(!string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text)))
			// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			{
				# region [車台番号]
				// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				//tEdit_ProduceFrameNo.Text = this._beforeCarSearchBuffer.ProduceFrameNo;
				// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				string newValue = this.tEdit_ProduceFrameNo.Text;
				int newIntValue = TStrConv.StrToIntDef(newValue.Trim(), 0);

				// 車台番号番号のチェック
				if (this._salesSlipInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue, newIntValue))
				{
					// 車台番号設定処理
					this._salesSlipInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
					this._salesSlipInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

					// 年式取得処理
					int firstEntryDate = this._salesSlipInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

					// 年式設定処理
					if (firstEntryDate != 0)
					{
						this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
						this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, firstEntryDate);
					}
					this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
				}
				else
				{
					TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"車台番号が設定範囲外です。",
							-1,
							MessageBoxButtons.OK);
					e.NextCtrl = tEdit_ProduceFrameNo;
					nextCtrl = null;
					getNextCtrl = false;
					this.tEdit_ProduceFrameNo.Text = string.Empty;
				}
				# endregion
			}
			// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//if (this._beforeCarSearchBuffer.FirstEntryDate != 0)
			idate = this.tDateEdit_FirstEntryDate.GetLongDate();
			if ((this._beforeCarSearchBuffer.FirstEntryDate != 0) ||
				(idate != 0))
			// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			{
				# region [年式]
				// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				//tDateEdit_FirstEntryDate.SetLongDate(this._beforeCarSearchBuffer.FirstEntryDate);
				// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
				DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate(ref tempFirstEntryDate, true);
				if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"日付が不正です。",
						-1,
						MessageBoxButtons.OK);
					e.NextCtrl = tDateEdit_FirstEntryDate;
					nextCtrl = null;
					getNextCtrl = false;
				}
				else
				{
					// 2009/12/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//int newValue = this.tDateEdit_FirstEntryDate.GetLongDate();
					//if (carInfoRowCurrent.ProduceTypeOfYearInput != (newValue / 100))
					//{
					//    if (this._salesSlipInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate()))
					//    {
					//        // 年式設定処理
					//        this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, tDateEdit_FirstEntryDate.GetLongDate());
					//        this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate());
					//    }
					//    else
					//    {
					//        TMsgDisp.Show(
					//            this,
					//            emErrorLevel.ERR_LEVEL_INFO,
					//            this.Name,
					//            "生産年式が設定範囲外です。",
					//            -1,
					//            MessageBoxButtons.OK);
					//        e.NextCtrl = tDateEdit_FirstEntryDate;
					//        nextCtrl = null;
					//        getNextCtrl = false;
					//        this.tDateEdit_FirstEntryDate.SetLongDate(0);
					//    }
					//}
					if (this._salesSlipInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate()))
					{
						// 年式設定処理
						this._salesSlipInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, tDateEdit_FirstEntryDate.GetLongDate());
						this._salesSlipInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate());
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"生産年式が設定範囲外です。",
							-1,
							MessageBoxButtons.OK);
						// --- UPD 2009/12/23 ---------->>>>>
						//e.NextCtrl = tDateEdit_FirstEntryDate;
						if (!string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text.Trim()))
						{
							e.NextCtrl = tEdit_ProduceFrameNo;
						}
						// --- UPD 2009/12/23 ----------<<<<<
						nextCtrl = null;
						getNextCtrl = false;
						this.tDateEdit_FirstEntryDate.SetLongDate(0);
					}
					// 2009/12/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				}
				# endregion
			}
			if (this._beforeCarSearchBuffer.ColorNo != string.Empty)
			{
				# region [カラー]
				tEdit_ColorNo.Text = this._beforeCarSearchBuffer.ColorNo;
				if (this.tEdit_ColorNo.Text.Trim() != string.Empty)
				{
					string currentColorCode = carInfoRowCurrent.ColorCode;
					if (!this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim()))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"カラーコードが設定範囲外です。",
							-1,
							MessageBoxButtons.OK);
						this.tEdit_ColorNo.Text = string.Empty;

						this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim());
						e.NextCtrl = tEdit_ColorNo;
						nextCtrl = null;
						getNextCtrl = false;
					}
				}
				else
				{
					this._salesSlipInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim());
				}
				# endregion
			}
			if (this._beforeCarSearchBuffer.TrimNo != string.Empty)
			{
				# region [トリム]
				tEdit_TrimNo.Text = this._beforeCarSearchBuffer.TrimNo;
				if (this.tEdit_TrimNo.Text.Trim() != string.Empty)
				{
					string currentTrimCode = carInfoRowCurrent.TrimCode;
					if (!this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim()))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"トリムコードが設定範囲外です。",
							-1,
							MessageBoxButtons.OK);
						this.tEdit_TrimNo.Text = string.Empty;

						this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim());
						e.NextCtrl = tEdit_TrimNo;
						nextCtrl = null;
						getNextCtrl = false;
					}
				}
				else
				{
					this._salesSlipInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim());
				}
				# endregion
			}
			# endregion
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

			//---------------------------------------------------------------
			// 商品情報再取得
			//---------------------------------------------------------------
			if (reCalcSalesUnitPrice)
			{
				this._salesSlipInputAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(out goodsUnitDataListList, out msg);

				this._salesSlipInputAcs.SalesSlip.StockUpdateFlag = false; //ADD 2010/01/27
				salesSlip.StockUpdateFlag = false; //ADD 2010/01/27
			}

			//---------------------------------------------------------------
			// 売上単価再計算時
			//---------------------------------------------------------------
			if (reCalcSalesUnitPrice)
			{
				// 消費税再設定
				taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);
				this._salesSlipInputAcs.SettingSalesSlipConsTaxRate(ref salesSlip, taxRate);

				// 商品価格の再設定を行います。（売上情報）
				this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(goodsUnitDataListList);

				// 商品価格の再設定を行います。（受注情報）
				this._salesSlipInputAcs.AcptAnOdrDetailRowGoodsPriceReSetting(goodsUnitDataListList);

				// 売上金額変更後発生イベント処理
				this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
			}

			//---------------------------------------------------------------
			// 売上金額再計算時
			//---------------------------------------------------------------
			if (reCalcSalesPrice)
			{
				// 売上金額計算処理
				this._salesSlipDetailInput.CalculationSalesPrice();

				// 売上金額変更後発生イベント処理
				this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
			}

			//---------------------------------------------------------------
			// 明細情報更新
			//---------------------------------------------------------------
			//if ((reCalcSalesUnitPrice) || (reCalcSalesPrice)) // 2010/01/13
			if ((reCalcSalesUnitPrice) || (reCalcSalesPrice) || (inputSalesSlipNum)) // 2010/01/13
			{
				// 明細部変更後発生イベント処理
				SalesSlipDetailInput_DetailChanged(this, this._salesSlipDetailInput.GetActiveRowSalesRowNo());
			}

			//---------------------------------------------------------------
			// 仕入情報変更時
			//---------------------------------------------------------------
			if (changeStockInfo)
			{
			}

			//---------------------------------------------------------------
			// 掛率情報クリア
			//---------------------------------------------------------------
			if (clearRateInfo)
			{
				// 掛率情報クリア
				this._salesSlipInputAcs.ClearAllRateInfo();
			}

			//---------------------------------------------------------------
			// 明細グリッドセル再設定
			//---------------------------------------------------------------
            //>>>2010/02/26
            //if ((changeSalesGoodsCd) || (changeAcptAnOdrStatus) || (changeSalesSlip) || (clearRateInfo) || (reCalcSalesUnitPrice))
            if ((changeSalesGoodsCd) || (changeAcptAnOdrStatus) || (changeSalesSlip) || (clearRateInfo) || (reCalcSalesUnitPrice) || (changeCustomer))
            //<<<2010/02/26
            {
				// 明細グリッドセル設定処理
				this._salesSlipDetailInput.SettingGrid();

				this._salesSlipDetailInput.ActiveCellButtonEnabledControl();
			}

			// --- DEL m.suzuki 2010/03/10 ---------->>>>>
			//// --- ADD 2009/10/19 ---------->>>>>
			//if (((e.Key == Keys.Down) || (e.Key == Keys.Return)) &&
			//    (e.NextCtrl == this.ultraGrid_CarSpec))
			//{
			//    getNextCtrl = false;
			//    e.NextCtrl = this._salesSlipDetailInput.uGrid_Details;
			//}
			//// --- ADD 2009/10/19 ----------<<<<<
			// --- DEL m.suzuki 2010/03/10 ----------<<<<<

			//---------------------------------------------------------------
			// NextCtrl算出
			//---------------------------------------------------------------
			if (getNextCtrl)
			{
				#region フォーカス指定
				if (e.ShiftKey)
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
							break;
						default:
							break;
					}
				}
				else
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControl(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
							break;
						default:
							break;
					}
				}
				#endregion
			}
			else if (getNextCtrlForFooter)
			{
				#region フォーカス指定
				if (e.ShiftKey)
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControlForFooter(prevCtrl, SalesSlipInputAcs.MoveMethod.PrevMove);
							break;
						default:
							break;
					}
				}
				else
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControlForFooter(prevCtrl, SalesSlipInputAcs.MoveMethod.NextMove);
							break;
						default:
							break;
					}
				}
				#endregion
			}

			// 2009/09/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			if ((nextCtrl == this._salesSlipDetailInput.uGrid_Details) ||
				(e.NextCtrl == this._salesSlipDetailInput.uGrid_Details))
			{
				if (ctEffectiveDetailHeight > this._salesSlipDetailInput.uGrid_Details.Height) nextCtrl = e.PrevCtrl;
			}
			// 2009/09/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			if (nextCtrl != null) e.NextCtrl = nextCtrl;

			//---------------------------------------------------------------
			// ボタンツール有効無効設定処理
			//---------------------------------------------------------------
			if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
			{
				this.SettingGuideButtonToolEnabled(e.NextCtrl);
				this.SettingAddUpButtonToolEnabled(e.NextCtrl);
				this.SettingToolBarButtonCaption(e.NextCtrl);
				this.SettingToolBarButtonEnabled();
			}

			//---------------------------------------------------------------
			// 登録処理
			//---------------------------------------------------------------
			//   最終項目(納入先確認、返品理由、返品理由ガイド、得意先注番)でEnterキーを押下した場合
			//---------------------------------------------------------------
			if ((e.Key == Keys.Enter) && (!this._changeFocusSaveCancel))
			{
				if (e.PrevCtrl == e.NextCtrl || (getNextCtrl == true && prevCtrl == e.NextCtrl))
				{
					if ((e.PrevCtrl.Name == "tEdit_SlipNote") ||
						(e.PrevCtrl.Name == "uButton_SlipNote") ||
						(e.PrevCtrl.Name == "tEdit_SlipNote3") ||
						(e.PrevCtrl.Name == "uButton_SlipNote3") ||
						(e.PrevCtrl.Name == "uButton_AddresseeConfirmation") ||
						(e.PrevCtrl.Name == "tEdit_RetGoodsReason") ||
						(e.PrevCtrl.Name == "uButton_RetGoodsReason") ||
						(e.PrevCtrl.Name == "tEdit_PartySaleSlipNum") ||
                        (e.PrevCtrl.Name == "tComboEditor_AnswerDiv") ||          // 回答区分 // 2010/02/26
                        (e.PrevCtrl.Name == "tNedit_Mileage") ||// ADD 2009/09/08②
						(e.PrevCtrl.Name == "uButton_SlipNoteGuide") ||// ADD 2009/09/08②
						(e.PrevCtrl.Name == "tComboEditor_DeliveredGoodsDiv") || // ADD 2009/09/08②

						(e.PrevCtrl.Name == "tNedit_SlipNoteCode") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tNedit_SlipNote2Code") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tEdit_SlipNote2") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "uButton_SlipNote2") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tNedit_SlipNote3Code") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tNedit_AddresseeCode") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "uButton_AddresseeGuide") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tEdit_CarSlipNote") || // ADD 2009/12/23
						(e.PrevCtrl.Name == "tEdit_AddresseeName")) // ADD 2009/12/23
					{
						// --- DEL 2009/12/23 ---------->>>>>

						// --- ADD 2009/09/08② ---------->>>>>
						//    if (this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo].Visible == true
						//        && this.uTabControl_Footer.ActiveTab.Key != ctTAB_KEY_AddInfo)
						//{
						//        // フッタタブ位置セット
						//        this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[ctTAB_KEY_AddInfo];
						//        this.tEdit_CarSlipNote.Focus(); // 明細→車輌備考

						//        return;
						//    }
						// --- ADD 2009/09/08② ----------<<<<<

						// --- DEL 2009/12/23 ----------<<<<<

						SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▼▼▼保存処理　開始");
						// --- UPD 2009/12/23 ---------->>>>>
						//bool isSave = this.Save(true);
						this._prevControl = e.PrevCtrl;
						bool isSave = this.Save(true, true);
						// --- UPD 2009/12/23 ----------<<<<<
						SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▲▲▲保存処理　終了");

						if (isSave)
						{
							DialogResult dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_QUESTION,
								this.Name,
								"続けて入力しますか？",
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button2);

							bool keepAcptAnOdrStatus = false;
							bool keepDate = false;

							if (dialogResult == DialogResult.Yes)
							{
								// ヘッダ情報はクリアしない
								keepDate = true; // 日付保持
								keepAcptAnOdrStatus = true; // 受注ステータス保持

								// クリア処理
								//this.Clear(false, keepAcptAnOdrStatus, keepDate, true); // 2009/09/10
                                this.Clear(false, keepAcptAnOdrStatus, keepDate, true, true); // 2009/09/10

								// 見積初期値設定情報
								salesSlip = this._salesSlipInputAcs.SalesSlip;
								this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
								this._salesSlipInputAcs.Cache(salesSlip);

								// 車輌情報キャッシュ
								if (this._salesSlipInputAcs.SvAcceptOdrCar != null)
								{
									this._salesSlipInputAcs.CacheCarInfo(1, null, null, this._salesSlipInputAcs.SvAcceptOdrCar);
									this.SetDisplayCarInfo(1, CarSearchType.csNone);
									this._salesSlipInputAcs.SearchCarDiv = false;

									// --- ADD 2009/09/08② ---------->>>>>
									//追加情報タブ項目Visible設定
									SettingAddInfoVisible();
									// --- ADD 2009/09/08② ----------<<<<<
								}

								e.NextCtrl = null;
								this.panel_Detail.Focus();
								this._salesSlipDetailInput.FirstEnter = true; // 2009/09/09 ADD
								this._salesSlipDetailInput.uGrid_Details.Focus();
							}
							else
							{
								// 全てクリア(初期状態へ)
								keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;
								keepAcptAnOdrStatus = false; // 受注ステータス保持

								// クリア処理
								this.Clear(false, keepAcptAnOdrStatus, keepDate);

								this.timer_InitialSetFocus.Enabled = true;
							}
						}
					}
				}
			}

		}

		/// <summary>
		/// 車両検索後のコントロール取得処理
		/// </summary>
		/// <returns></returns>
		private Control GetNextCtrlAfterCarSearch()
		{
			Control retControl = null;

			if ((this._salesInputConstructionAcs.FocusPositionAfterCarSearchValue == SalesSlipInputConstructionAcs.FocusPositionAfterCarSearch_FirstEntryDate) &&
				(this.tDateEdit_FirstEntryDate.Visible) && (this.tDateEdit_FirstEntryDate.Enabled))
			{
				retControl = this.tDateEdit_FirstEntryDate;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionAfterCarSearchValue == SalesSlipInputConstructionAcs.FocusPositionAfterCarSearch_ProduceFrameNo) &&
					 (this.tEdit_ProduceFrameNo.Visible) && (this.tEdit_ProduceFrameNo.Enabled))
			{
				retControl = this.tEdit_ProduceFrameNo;
			}
			else if ((this._salesInputConstructionAcs.FocusPositionAfterCarSearchValue == SalesSlipInputConstructionAcs.FocusPositionAfterCarSearch_Detail) &&
				(this._salesSlipDetailInput.Enabled))
			{
				retControl = this._salesSlipDetailInput.uGrid_Details;
			}
			return retControl;
		}

		/// <summary>
		/// 車両検索処理
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		private int CarSearch(CarSearchCondition condition)
		{
			//------------------------------------------------------
			// 初期処理
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
			this._beforeCarSearchBuffer.ProduceFrameNo = tEdit_ProduceFrameNo.Text.Trim();
			this._beforeCarSearchBuffer.FirstEntryDate = tDateEdit_FirstEntryDate.GetLongDate();
			this._beforeCarSearchBuffer.ColorNo = tEdit_ColorNo.Text.Trim();
			this._beforeCarSearchBuffer.TrimNo = tEdit_TrimNo.Text.Trim();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

			//------------------------------------------------------
			// 売上行番号取得
			//------------------------------------------------------
			int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();

			//------------------------------------------------------
			// 西暦／和歴区分（年式）
			//------------------------------------------------------
			condition.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;

			//------------------------------------------------------
			// カーメーカーコード、車種コード、車種呼称コード設定
			//------------------------------------------------------
			if (condition.Type != CarSearchType.csCategory)
			{
				int makerCd, modelCd, modelSubCd;
				if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
				{
					condition.MakerCode = makerCd;
				}
				if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
				{
					condition.ModelCode = modelCd;
				}
				if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
				{
					condition.ModelSubCode = modelSubCd;
				}
			}
			//------------------------------------------------------
			// 各種検索処理
			//------------------------------------------------------
			//  CarSearchCondition の検索タイプにより指定
			//------------------------------------------------------
			CarSearchResultReport ret;
			PMKEN01010E dat = new PMKEN01010E();
			ret = this._salesSlipInputAcs.SearchCar(condition, ref dat);
			if (ret == CarSearchResultReport.retFailed)
			{
				//DialogResult dialogResult = TMsgDisp.Show(
				//    this,
				//    emErrorLevel.ERR_LEVEL_INFO,
				//    this.Name,
				//    "検索結果 0件です。",
				//    0,
				//    MessageBoxButtons.OK,
				//    MessageBoxDefaultButton.Button1);
				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			}
			else if (ret == CarSearchResultReport.retError)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"検索中にエラーが発生しました。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			if (ret == CarSearchResultReport.retMultipleCarKind)
			{
				//------------------------------------------------------
				// 車種選択画面起動
				//------------------------------------------------------
				if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
				{
					ret = this._salesSlipInputAcs.SearchCar(condition, ref dat);
				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			if (ret == CarSearchResultReport.retMultipleCarModel)
			{
				//------------------------------------------------------
				// 型式選択画面起動
				//------------------------------------------------------
				if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
				{
					ret = this._salesSlipInputAcs.SearchCar(condition, ref dat);
				}
				else
				{
					return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}

			if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
			{
				//------------------------------------------------------
				// 検索結果キャッシュ
				//------------------------------------------------------
				this._salesSlipInputAcs.CacheCarInfo(salesRowNo, dat);

				//------------------------------------------------------
				// 車両情報画面表示処理
				//------------------------------------------------------
				this.SetDisplayCarInfo(salesRowNo, condition.Type);

				return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

			return retStatus;
		}

		/// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			bool isSetting = false;
			Control nextCtrl = new Control();

			#region ●拠点
			//---------------------------------------------------
			// 拠点
			//---------------------------------------------------
			if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SectionCode)
			{
				if ((this.tEdit_SectionCode.Enabled) && (this.tEdit_SectionCode.Visible))
				{
					this.tEdit_SectionCode.Focus();
					nextCtrl = this.tEdit_SectionCode;
					isSetting = true;
				}
			}
			#endregion

			#region ●担当者
			//---------------------------------------------------
			// 担当者
			//---------------------------------------------------
			if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesEmployeeCd)
			{
				if ((this.tEdit_SalesEmployeeCd.Enabled) && (this.tEdit_SalesEmployeeCd.Visible))
				{
					this.tEdit_SalesEmployeeCd.Focus();
					nextCtrl = this.tEdit_SalesEmployeeCd;
					isSetting = true;
				}
			}
			#endregion

			#region ●受注者
			//---------------------------------------------------
			// 受注者
			//---------------------------------------------------
			else if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_FrontEmployeeCd)
			{
				if ((this.tEdit_FrontEmployeeCd.Enabled) && (this.tEdit_FrontEmployeeCd.Visible))
				{
					this.tEdit_FrontEmployeeCd.Focus();
					nextCtrl = this.tEdit_FrontEmployeeCd;
					isSetting = true;
				}
			}
			#endregion

			#region ●発行者
			//---------------------------------------------------
			// 発行者
			//---------------------------------------------------
			else if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesInputCd)
			{
				if ((this.tEdit_SalesInputCode.Enabled) && (this.tEdit_SalesInputCode.Visible))
				{
					this.tEdit_SalesInputCode.Focus();
					nextCtrl = this.tEdit_SalesInputCode;
					isSetting = true;
				}
			}
			#endregion

			#region ●伝票番号
			//---------------------------------------------------
			// 伝票番号
			//---------------------------------------------------
			else if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_SalesSlipNum)
			{
				if ((this.tNedit_SalesSlipNum.Enabled) && (this.tNedit_SalesSlipNum.Visible))
				{
					this.tNedit_SalesSlipNum.Focus();
					nextCtrl = this.tNedit_SalesSlipNum;
					isSetting = true;
				}
			}
			#endregion

			#region ●伝票種別
			//---------------------------------------------------
			// 伝票種別
			//---------------------------------------------------
			else if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_AcptAnOdrStatus)
			{
				if ((this.tComboEditor_AcptAnOdrStatusDisplay.Enabled) && (this.tComboEditor_AcptAnOdrStatusDisplay.Visible))
				{
					this.tComboEditor_AcptAnOdrStatusDisplay.Focus();
					nextCtrl = this.tComboEditor_AcptAnOdrStatusDisplay;
					isSetting = true;
				}
				else if ((this.tComboEditor_SalesSlipDisplay.Enabled) && (this.tComboEditor_SalesSlipDisplay.Visible))
				{
					this.tComboEditor_SalesSlipDisplay.Focus();
					nextCtrl = this.tComboEditor_SalesSlipDisplay;
					isSetting = true;
				}
			}
			#endregion

			#region ●得意先
			//---------------------------------------------------
			// 得意先
			//---------------------------------------------------
			else if (this._salesInputConstructionAcs.FocusPositionValue == SalesSlipInputConstructionAcs.FocusPosition_CustomerCode)
			{
				if ((this.tNedit_CustomerCode.Enabled) && (this.tNedit_CustomerCode.Visible))
				{
					this.tNedit_CustomerCode.Focus();
					nextCtrl = this.tNedit_CustomerCode;
					isSetting = true;
				}
			}
			#endregion

			if (!isSetting)
			{
				this.tEdit_SalesEmployeeCd.Focus();
				nextCtrl = this.tEdit_SalesEmployeeCd;
			}

			this._salesSlipInputAcs.PartySaleSlipDiv = this._salesInputConstructionAcs.PartySaleSlipValue;

			// Enterキー入力時フォーカス移動先テーブル更新
			this._salesSlipDetailInput.EnterMoveSetting();

			// ガイドボタンツール有効無効設定処理
			//this.SettingGuideButtonToolEnabled(this.tComboEditor_SalesGoodsCd);
			this.SettingGuideButtonToolEnabled(nextCtrl);
			this.SettingAddUpButtonToolEnabled(nextCtrl);
			this.ActiveControl = nextCtrl;
			this._prevControl = nextCtrl;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
			// 再描画
			this.Refresh();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD

			// --- ADD 2009/10/19 ---------->>>>>
			this._salesSlipDetailInput.FirstEnter = true;
			// --- ADD 2009/10/19 ----------<<<<<
		}

		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/11/24 伝票呼出時、伝票発行を行わず、伝票の更新のみ行える機能を追加する対応</br>
		/// <br>Update Note: 2010/02/02 張凱 redmine#2760対応</br>
		/// <br>Update Note: 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
		/// <br>             単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{

			switch (e.Tool.Key)
			{
				#region 終了処理
				//--------------------------------------------------
				// 終了処理
				//--------------------------------------------------
				case "ButtonTool_Close":
					{
						this.Close(true);
						break;
					}
				#endregion

				#region 保存処理
				//--------------------------------------------------
				// 保存処理
				//--------------------------------------------------
				case "ButtonTool_Save":
					{
						Control nextControl = null;

						if (this.panel_Header.ContainsFocus)
						{
							if ((this.tEdit_CarMngCode.Enabled) && (this.tEdit_CarMngCode.Visible))
							{
								nextControl = this.tEdit_CarMngCode; // ヘッダ→管理番号
							}
							else if (this.tNedit_ModelDesignationNo.Enabled)
							{
								nextControl = this.tNedit_ModelDesignationNo; // ヘッダ→型式指定番号
							}
							else if (this._salesSlipDetailInput.Enabled)
							{
								nextControl = this._salesSlipDetailInput; // 車両情報→明細
							}
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_TotalInfo)
							{
								// --- UPD 2009/12/23 ---------->>>>>
								//if (this.tEdit_SlipNote.Enabled) nextControl = this.tEdit_SlipNote; // 明細→備考１
								if (this.tNedit_SlipNoteCode.Enabled) nextControl = this.tNedit_SlipNoteCode; // 明細→備考１
								// --- UPD 2009/12/23 ----------<<<<<
							}
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_MemoInfo)
							{
								if (this.tEdit_SlipMemo1.Enabled) nextControl = this.tEdit_SlipMemo1; // 明細→伝票メモ１
							}
							// --- ADD 2009/09/08② ---------->>>>> 
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_AddInfo)
							{
								if (this.tEdit_CarSlipNote.Enabled) nextControl = this.tEdit_CarSlipNote; // 明細→車輌備考
							}
							// --- ADD 2009/09/08② ----------<<<<<
#if false // 見積情報
                            else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_EstimateInfo)
                            {
                                if (this.tEdit_EstimateSubject.Enabled) nextControl = tEdit_EstimateSubject; // 明細→見積タイトル
                            }
#endif
						}
						if ((this.panel_CarInfo.ContainsFocus) && (nextControl == null))
						{
							if (this._salesSlipDetailInput.Enabled) nextControl = this._salesSlipDetailInput; // 車両情報→明細
						}
						if ((this.panel_DetailInput.ContainsFocus) && (nextControl == null))
						{
							// --- ADD 2009/10/19 ---------->>>>>
							if (this._salesSlipDetailInput.CheckSalesUnitCost())
							{
								if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_TotalInfo)
								{
									// --- UPD 2009/12/23 ---------->>>>>
									//if (this.tEdit_SlipNote.Enabled) nextControl = this.tEdit_SlipNote; // 明細→備考１
									// --- UPD 2010/02/02 ---------->>>>>
									//if (this.tNedit_SlipNoteCode.Enabled) nextControl = this.tNedit_SlipNoteCode; // 明細→備考１
									nextControl = GetFooterFirstControl();
									// --- UPD 2010/02/02 ----------<<<<<
									// --- UPD 2009/12/23 ----------<<<<<
								}
								else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_MemoInfo)
								{
									if (this.tEdit_SlipMemo1.Enabled) nextControl = this.tEdit_SlipMemo1; // 明細→伝票メモ１
								}
								// --- ADD 2009/09/08② ---------->>>>> 
								else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_AddInfo)
								{
									// --- UPD 2010/02/02 ---------->>>>>
									//if (this.tEdit_CarSlipNote.Enabled) nextControl = this.tEdit_CarSlipNote; // 明細→車輌備考
									nextControl = GetFooterFirstControl();
									// --- UPD 2010/02/02 ----------<<<<<
								}
								// --- ADD 2009/09/08② ----------<<<<<
							}
							else
							{
								//nextControl = this._prevControl;
								return;
							}
							// --- ADD 2009/10/19 ----------<<<<<

							// --- DEL 2009/10/19 ---------->>>>>
							//if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_TotalInfo)
							//{
							//    if (this.tEdit_SlipNote.Enabled) nextControl = this.tEdit_SlipNote; // 明細→備考１
							//}
							//else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_MemoInfo)
							//{
							//    if (this.tEdit_SlipMemo1.Enabled) nextControl = this.tEdit_SlipMemo1; // 明細→伝票メモ１
							//}
							//// --- ADD 2009/09/08② ---------->>>>> 
							//else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_AddInfo)
							//{
							//    if (this.tEdit_CarSlipNote.Enabled) nextControl = this.tEdit_CarSlipNote; // 明細→車輌備考
							//}
							//// --- ADD 2009/09/08② ----------<<<<<
							// --- DEL 2009/10/19 ----------<<<<<
#if false // 見積情報
                            else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_EstimateInfo)
                            {
                                if (this.tEdit_EstimateSubject.Enabled) nextControl = tEdit_EstimateSubject; // 明細→見積タイトル
                            }
#endif
						}

						if (nextControl != null)
						{
							//nextControl.Focus();
							//this.SettingToolBarButtonCaption(nextControl);

							// 一括ゼロ詰め
							this.uiSetControl1.SettingAllControlsZeroPaddedText();
							ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
							this.tArrowKeyControl1_ChangeFocus(this, ex);
							nextControl = ex.NextCtrl;
							nextControl.Focus();
							this._prevControl = nextControl;
						}
						else
						{
							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▼▼▼保存処理　開始");
							// --- UPD 2009/12/23 ---------->>>>>
							//bool isSave = this.Save(true);
							bool isSave = this.Save(true, true);
							// --- UPD 2009/12/23 ----------<<<<<
							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▲▲▲保存処理　終了");

							if (isSave)
							{
								//if ((this._salesSlipInputAcs.SalesDetailDataTable.Count == 0) ||
								//    (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.Revision)))
								//if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.Revision))
								//{

								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_QUESTION,
									this.Name,
									"続けて入力しますか？",
									0,
									MessageBoxButtons.YesNo,
									MessageBoxDefaultButton.Button2);

								bool keepAcptAnOdrStatus = false;
								bool keepDate = false;

								SalesSlip svSalesSlip = this._salesSlipInputAcs.SalesSlip.Clone(); // ADD 2009/11/13

								if (dialogResult == DialogResult.Yes)
								{
									// ヘッダ情報はクリアしない
									keepDate = true; // 日付保持
									keepAcptAnOdrStatus = true; // 受注ステータス保持

									// クリア処理
									//this.Clear(false, keepAcptAnOdrStatus, keepDate, true); // 2009/09/10
									this.Clear(false, keepAcptAnOdrStatus, keepDate, true, true); // 2009/09/10

									// 見積初期値設定情報
									SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
									this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
									this._salesSlipInputAcs.Cache(salesSlip);

									// 車輌情報キャッシュ
									if (this._salesSlipInputAcs.SvAcceptOdrCar != null)
									{
										this._salesSlipInputAcs.CacheCarInfo(1, null, null, this._salesSlipInputAcs.SvAcceptOdrCar);
										this.SetDisplayCarInfo(1, CarSearchType.csNone);
										this._salesSlipInputAcs.SearchCarDiv = false;
									}

									// --- ADD 2009/11/13 ---------->>>>>
									// 担当者(ログイン担当者)
									this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd = svSalesSlip.SalesEmployeeCd;
									this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm = svSalesSlip.SalesEmployeeNm;

									// 売上データクラス→画面格納処理
									this.SetDisplay(this._salesSlipInputAcs.SalesSlip);
									// --- ADD 2009/11/13 ----------<<<<<

									this.panel_Detail.Focus();
									this._salesSlipDetailInput.FirstEnter = true; // 2009/09/09 ADD
									this._salesSlipDetailInput.uGrid_Details.Focus();
								}
								else
								{
									// 全てクリア(初期状態へ)
									keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;
									keepAcptAnOdrStatus = false; // 受注ステータス保持

									// クリア処理
									this.Clear(false, keepAcptAnOdrStatus, keepDate);

									// --- ADD 2009/11/13 ---------->>>>>
									// 担当者(ログイン担当者)
									this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd = svSalesSlip.SalesEmployeeCd;
									this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm = svSalesSlip.SalesEmployeeNm;

									// 受注者
									this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd = svSalesSlip.FrontEmployeeCd;
									this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm = svSalesSlip.FrontEmployeeNm;

									// 発行者
									this._salesSlipInputAcs.SalesSlip.SalesInputCode = svSalesSlip.SalesInputCode;
									this._salesSlipInputAcs.SalesSlip.SalesInputName = svSalesSlip.SalesInputName;

									// 売上データクラス→画面格納処理
									this.SetDisplay(this._salesSlipInputAcs.SalesSlip);
									// --- ADD 2009/11/13 ----------<<<<<

									// ----- ADD 2010/05/21 ------------>>>>>
									// 伝票日付クリア区分 == 0:システム日付
									// ----- DEL 2010/05/21 ------------>>>>>
									//if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == 0)
									//{
									//    // 売上日
									//    this.tDateEdit_SalesDate.SetDateTime(DateTime.Today);
									//}
									//else
									//{
									//    // 売上日
									//    this.tDateEdit_SalesDate.SetDateTime(this._salesSlipInputAcs.SalesSlip.SalesDate);
									//}
									// ----- DEL 2010/05/21 ------------>>>>>
									// ----- ADD 2010/05/21 ------------<<<<<

									this.timer_InitialSetFocus.Enabled = true;
								}
								//}
								// --- ADD 2009/09/08② ---------->>>>>
								//追加情報タブ項目Visible設定
								SettingAddInfoVisible();
								// --- ADD 2009/09/08② ----------<<<<<
							}
						}

						break;
					}
				#endregion

				#region 元に戻す処理
				//--------------------------------------------------
				// 元に戻す処理
				//--------------------------------------------------
				case "ButtonTool_Retry":
					{
						this.Retry(true);

						this.timer_InitialSetFocus.Enabled = true;
						break;
					}

				#endregion

				#region クリア処理
				//--------------------------------------------------
				// クリア処理(新規作成)
				//--------------------------------------------------
				case "ButtonTool_New":
					{
						bool keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;

						// ----- UPD 2010/05/21 ------------>>>>>
						//this.Clear(true, true, keepDate);
						this.Clear(true, true, keepDate, true);
						// ----- UPD 2010/05/21 ------------<<<<<

						this.timer_InitialSetFocus.Enabled = true;
						break;
					}
				#endregion

				#region 表示設定
				//--------------------------------------------------
				// 表示設定
				//--------------------------------------------------
				case "ButtonTool_Setup":
					{
						SalesSlipInputSetup salesInputSetup = new SalesSlipInputSetup();
						DialogResult dialogResult = salesInputSetup.ShowDialog(this);

						if (dialogResult == DialogResult.OK)
						{
							this.timer_InitialSetFocus.Enabled = true;
						}
						break;
					}

				#endregion

				#region 返品
				//--------------------------------------------------
				// 返品
				//--------------------------------------------------
				case "ButtonTool_ReturnSlip":
					{
						// 返品処理
						this.ReturnSlip(true);
						break;
					}
				#endregion

				#region 赤伝
				//--------------------------------------------------
				// 赤伝
				//--------------------------------------------------
				case "ButtonTool_RedSlip":
					{
						// 赤伝処理
						this.RedSlip(true);
						break;
					}
				#endregion

				#region ガイド
				//--------------------------------------------------
				// ガイド
				//--------------------------------------------------
				case "ButtonTool_Guide":
					{
						// ガイド起動処理
						this.ExecuteGuide();
						break;
					}

				#endregion

				#region 在庫検索
				//---------------------------------------------------------------
				// 在庫検索
				//---------------------------------------------------------------
				case "ButtonTool_StockSearch":
					{
						this.StockSearch();
						break;
					}
				#endregion

				#region 伝票呼出
				//--------------------------------------------------
				// 伝票呼出(伝票選択)
				//--------------------------------------------------
				case "ButtonTool_ReadSlip":
					{
						// 売上伝票ガイドボタンクリックイベント
						this.uButton_SalesSlipGuide_Click(this.uButton_SalesSlipGuide, new EventArgs());
						break;
					}
				#endregion

				#region 伝票複写
				//--------------------------------------------------
				// 伝票複写(伝票選択)
				//--------------------------------------------------
				case "ButtonTool_CopySlip":
					{
						if ((this.panel_Detail.ContainsFocus) &&
							(!this.panel_CarInfo.ContainsFocus))
						{
							// 履歴照会(売上履歴データから明細選択)
							this.SalesReferenceSearch();
						}
						else
						{
							// 伝票複写
							this.CopySlip(true);
						}

						// フッタタブ位置セット
						this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[0];

						break;
					}
				#endregion

				#region 削除処理
				//--------------------------------------------------
				// 削除処理
				//--------------------------------------------------
				case "ButtonTool_DeleteSlip":
					{
						this.Delete();
						break;
					}
				#endregion

				#region 出荷計上
				//--------------------------------------------------
				// 出荷計上
				//--------------------------------------------------
				case "ButtonTool_ShipmentAddUp":
					{
						if ((this.panel_Detail.ContainsFocus) &&
							(!this.panel_CarInfo.ContainsFocus))
						{
							// 出荷照会(明細選択)
							this.ShipmentReferenceSearch();
						}
						else
						{
							// 出荷計上処理(伝票選択)
							this.ShipmentAddUp(true);
						}

						// フッタタブ位置セット
						this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[0];

						break;
					}
				#endregion

				#region 受注計上
				//--------------------------------------------------
				// 受注計上
				//--------------------------------------------------
				case "ButtonTool_AcceptAnOrderAddUp":
					{
						if ((this.panel_Detail.ContainsFocus) &&
							(!this.panel_CarInfo.ContainsFocus))
						{
							// 受注照会(明細選択)
							this.AcceptAnOrderReferenceSearch();
						}
						else
						{
							// 受注照会(伝票選択)
							this.AcceptAnOrderAddup(true);
						}

						// フッタタブ位置セット
						this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[0];

						break;
					}
				#endregion

				#region 見積計上
				//--------------------------------------------------
				// 見積計上
				//--------------------------------------------------
				case "ButtonTool_EstimateAddUp":
					{
						if ((this.panel_Detail.ContainsFocus) &&
							(!this.panel_CarInfo.ContainsFocus))
						{
							// 見積照会(明細選択)
							this.EstimateReferenceSearch();
						}
						else
						{
							// 見積照会(伝票選択)
							this.EstimateAddup(true);
						}

						// フッタタブ位置セット
						this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[0];

						break;
					}
				#endregion

				#region 検索切替(BLコード検索／品番検索)
				//--------------------------------------------------
				// 検索切替(BLコード検索／品番検索)
				//--------------------------------------------------
				case "ButtonTool_SearchChange":
					{
						this.ChangeSearchMode(1);
						break;
					}
				#endregion

				#region 進む
				//---------------------------------------------------------------
				// 進む
				//---------------------------------------------------------------
				case "ButtonTool_Forward":
					{
						Control nextControl = null;

						if (this.panel_Header.ContainsFocus)
						{
							if ((this.tEdit_CarMngCode.Enabled) && (this.tEdit_CarMngCode.Visible))
							{
								nextControl = this.tEdit_CarMngCode; // ヘッダ→管理番号
							}
							else if (this.tNedit_ModelDesignationNo.Enabled)
							{
								nextControl = this.tNedit_ModelDesignationNo; // ヘッダ→型式指定番号
							}
							// 2009/09/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
							//else if (this._salesSlipDetailInput.Enabled)
							else if ((this._salesSlipDetailInput.Enabled) &&
								(ctEffectiveDetailHeight <= this._salesSlipDetailInput.uGrid_Details.Height))
							// 2009/09/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
							{
								nextControl = this._salesSlipDetailInput; // 車両情報→明細
							}
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_TotalInfo)
							{
								// --- UPD 2009/12/23 ---------->>>>>
								//if (this.tEdit_SlipNote.Enabled) nextControl = this.tEdit_SlipNote; // 明細→備考１
								if (this.tNedit_SlipNoteCode.Enabled) nextControl = this.tNedit_SlipNoteCode; // 明細→備考１
								// --- UPD 2009/12/23 ----------<<<<<
							}
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_MemoInfo)
							{
								if (this.tEdit_SlipMemo1.Enabled) nextControl = this.tEdit_SlipMemo1; // 明細→伝票メモ１
							}
							// --- ADD 2009/09/08② ---------->>>>> 
							else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_AddInfo)
							{
								if (this.tEdit_CarSlipNote.Enabled) nextControl = this.tEdit_CarSlipNote; // 明細→車輌備考
							}
							// --- ADD 2009/09/08② ----------<<<<<
#if false // 見積情報
                            else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_EstimateInfo)
                            {
                                if (this.tEdit_EstimateSubject.Enabled) nextControl = tEdit_EstimateSubject; // 明細→見積タイトル
                            }
#endif
						}
						if ((this.panel_CarInfo.ContainsFocus) && (nextControl == null))
						{
							// 2009/09/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
							//if (this._salesSlipDetailInput.Enabled) nextControl = this._salesSlipDetailInput; // 車両情報→明細
							if ((this._salesSlipDetailInput.Enabled) && // 2009/09/09 ADD
								(ctEffectiveDetailHeight <= this._salesSlipDetailInput.uGrid_Details.Height))
							{
								nextControl = this._salesSlipDetailInput; // 車両情報→明細
							}
							// 2009/09/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
						}
						//if ((this.panel_DetailInput.ContainsFocus) && (nextControl == null)) // 2009/09/09 DEL
						if (nextControl == null) // 2009/09/09 ADD
						{
							// --- UPD 2009/10/19 ---------->>>>>
							if (this._salesSlipDetailInput.CheckSalesUnitCost())
							{
								if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_TotalInfo)
								{
									// --- UPD 2009/12/23 ---------->>>>>
									//if (this.tEdit_SlipNote.Enabled) nextControl = this.tEdit_SlipNote; // 明細→備考１
									// --- UPD 2010/02/02 ---------->>>>>
									//if (this.tNedit_SlipNoteCode.Enabled) nextControl = this.tNedit_SlipNoteCode; // 明細→備考１
									nextControl = GetFooterFirstControl();
									// --- UPD 2010/02/02 ----------<<<<<
									// --- UPD 2009/12/23 ----------<<<<<
								}
								else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_MemoInfo)
								{
									if (this.tEdit_SlipMemo1.Enabled) nextControl = this.tEdit_SlipMemo1; // 明細→伝票メモ１
								}
								// --- ADD 2009/09/08② ---------->>>>> 
								else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_AddInfo)
								{
									// --- UPD 2010/02/02 ---------->>>>>
									//if (this.tEdit_CarSlipNote.Enabled) nextControl = this.tEdit_CarSlipNote; // 明細→車輌備考
									nextControl = GetFooterFirstControl();
									// --- UPD 2010/02/02 ----------<<<<<
								}
								// --- ADD 2009/09/08② ----------<<<<<
							}
							else
							{
								return;
							}
							// --- UPD 2009/10/19 ----------<<<<<
#if false // 見積情報
                            else if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_EstimateInfo)
                            {
                                if (this.tEdit_EstimateSubject.Enabled) nextControl = tEdit_EstimateSubject; // 明細→見積タイトル
                            }
#endif
						}

						if (nextControl != null)
						{
							//nextControl.Focus();
							//this.SettingToolBarButtonCaption(nextControl);

							// 一括ゼロ詰め
							this.uiSetControl1.SettingAllControlsZeroPaddedText();
							ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
							this.tArrowKeyControl1_ChangeFocus(this, ex);
							nextControl = ex.NextCtrl;
							nextControl.Focus();
							this._prevControl = nextControl;
						}

						break;
					}
				#endregion

				#region 戻る
				//---------------------------------------------------------------
				// 戻る
				//---------------------------------------------------------------
				case "ButtonTool_Return":
					{
						Control nextControl = null;

						if (this.uTabControl_Footer.ContainsFocus)
						{
							// 2009/09/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
							//if (this._salesSlipDetailInput.Enabled)
							if ((this._salesSlipDetailInput.Enabled) &&
								(ctEffectiveDetailHeight <= this._salesSlipDetailInput.uGrid_Details.Height))
							// 2009/09/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
							{
								nextControl = this._salesSlipDetailInput; // フッタ→明細
							}
							else if ((tEdit_CarMngCode.Enabled) && (this.tEdit_CarMngCode.Visible))
							{
								nextControl = this.tEdit_CarMngCode; // 明細→管理番号
							}
							else if (this.tNedit_ModelDesignationNo.Enabled)
							{
								nextControl = this.tNedit_ModelDesignationNo; // 明細→型式指定番号
							}
							else
							{
								nextControl = this.GetHeaderFirstControl(); // 車両情報→ヘッダ
							}
						}

						if ((this.panel_DetailInput.ContainsFocus) && (nextControl == null))
						{
							// --- UPD 2009/10/19 ---------->>>>>
							if (this._salesSlipDetailInput.CheckSalesUnitCost())
							{
								if ((tEdit_CarMngCode.Enabled) && (this.tEdit_CarMngCode.Visible))
								{
									nextControl = this.tEdit_CarMngCode; // 明細→管理番号
								}
								else if (this.tNedit_ModelDesignationNo.Enabled)
								{
									nextControl = this.tNedit_ModelDesignationNo; // 明細→型式指定番号
								}
							}
							else
							{
								return;
							}
							// --- UPD 2009/10/19 ----------<<<<<
						}
						if ((this.panel_CarInfo.ContainsFocus) && (nextControl == null))
						{
							nextControl = this.GetHeaderFirstControl(); // 車両情報→ヘッダ
						}

						if (nextControl != null)
						{
							// 一括ゼロ詰め
							this.uiSetControl1.SettingAllControlsZeroPaddedText();
							ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Up, this.GetActiveControl(), nextControl);
							this.tArrowKeyControl1_ChangeFocus(this, ex);
							nextControl = ex.NextCtrl;

							nextControl.Focus();
						}

						//if (nextControl != null)
						//{
						//    nextControl.Focus();
						//    this.SettingToolBarButtonCaption(nextControl);
						//}

						break;
					}
				#endregion

				#region 最新情報
				//---------------------------------------------------------------
				// 最新情報
				//---------------------------------------------------------------
				case "ButtonTool_ReNewal":
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"画面情報はクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.No) break;

						SFCMN00299CA processingDialog = new SFCMN00299CA();
						try
						{
							processingDialog.Title = "最新情報取得";
							processingDialog.Message = "現在、最新情報取得中です。";
							processingDialog.DispCancelButton = false;
							processingDialog.Show((Form)this.Parent);

							this._salesSlipInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
							this._salesSlipInputInitDataAcs.ReadInitDataSecond(this._enterpriseCode, this._loginSectionCode);
							this._salesSlipInputInitDataAcs.ReadInitDataThird(this._enterpriseCode, this._loginSectionCode);

							this._salesSlipInputInitDataAcs.CacheSalesProcMoneyListCall();
							this._salesSlipInputInitDataAcs.CacheStockProcMoneyListCall();
							this._salesSlipInputInitDataAcs.CacheRateProtyMngListCall(); // ADD 2010/03/01

							this._customerInfoAcs.DeleteStaticMemoryData();

                            //>>>2010/04/28
                            this._salesSlipInputAcs.AcsCacheClear();
                            //<<<2010/04/28

							this._salesSlipInputInitDataAcs.GetOwnSectionName();

							// 処理区分マスタリスト設定
							this._salesSlipInputInitDataAcs.SettingProcMoney();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "初期値補正");
							#region 初期値補正
							// 部門有無
							if (this._salesSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
							{
								if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionCode.Text.Trim()))
								{
									this._headerItemsDictionary.Remove(this.uLabel_SubSectionCode.Text.Trim());
								}
							}

							// 仕入伝票削除区分
							if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null)
							{
								this._salesSlipInputAcs.SupplierSlipDelDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierSlipDelDiv; // 0:しない 1:確認 2:する
							}
							else
							{
								this._salesSlipInputAcs.SupplierSlipDelDiv = 1; // 0:しない 1:確認 2:する
							}
							#endregion

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ボタン初期設定処理");
							// ボタン初期設定処理
							this._salesSlipDetailInput.ButtonInitialSetting();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "オプション情報反映処理");
							// オプション情報反映処理
							this._salesSlipDetailInput.SettingOptionInfo();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "ツールバー初期設定処理");
							// ツールバー初期設定処理
							this.ToolBarInitilSetting();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "コンボエディタアイテム初期設定処理");
							// コンボエディタアイテム初期設定処理
							this.ComboEditorItemInitialSetting();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "得意先情報画面格納処理");
							// 得意先情報画面格納処理
							this.SetDisplayCustomerInfo(null);

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "画面項目Visible設定");
							// Visible設定
							this.SettingVisible();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "画面項目名称設定処理");
							// 画面項目名称設定処理
							this.DisplayNameSetting();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "セキュリティ権限による制御設定");
							// セキュリティ権限による制御開始(ツールバーボタン)
							this.BeginControllingByOperationAuthority();

							SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "メイン画面クリア処理");

							this.Clear(false, false);
							this.SetDisplayHeaderFooterInfo(this._salesSlipInputAcs.SalesSlip);
							this.timer_InitialSetFocus.Enabled = true;

						}
						finally
						{
							processingDialog.Dispose();

							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"最新情報を取得しました。　　",
								0,
								MessageBoxButtons.OK,
								MessageBoxDefaultButton.Button1);
						}

						break;
					}
				#endregion

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
				# region 見出貼付
				case "ButtonTool_SlipHeaderCopy":
					{
						// 見出貼付
						CopySlipHeader();
						break;
					}
				# endregion
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

				// --- ADD 2009/11/24 ---------->>>>>
				# region 更新
				case "ButtonTool_Update":
					{
						SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▼▼▼保存処理　開始");

						this._salesSlipInputAcs.PrintSlipFlag = false;
						// --- UPD 2009/12/23 ---------->>>>>
						//bool isSave = this.Save(true);
						bool isSave = this.Save(true, true);
						// --- UPD 2009/12/23 ----------<<<<<
						SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▲▲▲保存処理　終了");

						if (isSave)
						{
							DialogResult dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_QUESTION,
								this.Name,
								"続けて入力しますか？",
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button2);

							bool keepAcptAnOdrStatus = false;
							bool keepDate = false;

							SalesSlip svSalesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

							if (dialogResult == DialogResult.Yes)
							{
								// ヘッダ情報はクリアしない
								keepDate = true; // 日付保持
								keepAcptAnOdrStatus = true; // 受注ステータス保持

								// クリア処理
								this.Clear(false, keepAcptAnOdrStatus, keepDate, true, true);

								// 見積初期値設定情報
								SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
								this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
								this._salesSlipInputAcs.Cache(salesSlip);

								// 車輌情報キャッシュ
								if (this._salesSlipInputAcs.SvAcceptOdrCar != null)
								{
									this._salesSlipInputAcs.CacheCarInfo(1, null, null, this._salesSlipInputAcs.SvAcceptOdrCar);
									this.SetDisplayCarInfo(1, CarSearchType.csNone);
									this._salesSlipInputAcs.SearchCarDiv = false;
								}

								// 担当者(ログイン担当者)
								this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd = svSalesSlip.SalesEmployeeCd;
								this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm = svSalesSlip.SalesEmployeeNm;

								// 売上データクラス→画面格納処理
								this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

								this.panel_Detail.Focus();
								this._salesSlipDetailInput.FirstEnter = true;
								this._salesSlipDetailInput.uGrid_Details.Focus();
							}
							else
							{
								// 全てクリア(初期状態へ)
								keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;
								keepAcptAnOdrStatus = false; // 受注ステータス保持

								// クリア処理
								this.Clear(false, keepAcptAnOdrStatus, keepDate);

								// 担当者(ログイン担当者)
								this._salesSlipInputAcs.SalesSlip.SalesEmployeeCd = svSalesSlip.SalesEmployeeCd;
								this._salesSlipInputAcs.SalesSlip.SalesEmployeeNm = svSalesSlip.SalesEmployeeNm;

								// 受注者
								this._salesSlipInputAcs.SalesSlip.FrontEmployeeCd = svSalesSlip.FrontEmployeeCd;
								this._salesSlipInputAcs.SalesSlip.FrontEmployeeNm = svSalesSlip.FrontEmployeeNm;

								// 発行者
								this._salesSlipInputAcs.SalesSlip.SalesInputCode = svSalesSlip.SalesInputCode;
								this._salesSlipInputAcs.SalesSlip.SalesInputName = svSalesSlip.SalesInputName;

								// 売上データクラス→画面格納処理
								this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

								// ----- ADD 2010/05/21 ------------>>>>>
								// ----- DEL 2010/05/21 ------------>>>>>
								//// 伝票日付クリア区分 == 0:システム日付
								//if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == 0)
								//{
								//    // 売上日
								//    this.tDateEdit_SalesDate.SetDateTime(DateTime.Today);
								//}
								//else
								//{
								//    // 売上日
								//    this.tDateEdit_SalesDate.SetDateTime(this._salesSlipInputAcs.SalesSlip.SalesDate);
								//}
								// ----- DEL 2010/05/21 ------------<<<<<
								// ----- ADD 2010/05/21 ------------<<<<<

								this.timer_InitialSetFocus.Enabled = true;
							}

							//追加情報タブ項目Visible設定
							SettingAddInfoVisible();
						}
						break;
					}
				# endregion
				// --- ADD 2009/11/24 ----------<<<<<

                //>>>2010/02/26
                #region SCM問合せ一覧
                //--------------------------------------------------
                // SCM問合せ一覧
                //--------------------------------------------------
                case "ButtonTool_ReferenceList":
                    {
                        this.SCMReferenceSearch(true);

                        //>>>2010/03/30
                        this.SettingToolBarButtonEnabled();
                        //<<<2010/03/30

                        break;
                    }
                #endregion

                #region SCM回答処理
                //--------------------------------------------------
                // SCM回答処理
                //--------------------------------------------------
                case "ButtonTool_ReplyTransaction":
                    {
                        SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▼▼▼保存処理　開始");
                        bool isSave = this.Save(true, true, true);
                        SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "Save", "▲▲▲保存処理　終了");

                        if (isSave)
                        {
                            //>>>2010/02/26
                            this.CarInfoFormSetting(this, 1);
                            this.panel_Detail.Focus();
                            this._salesSlipDetailInput.uGrid_Details.Focus();
                            // 明細行数制限
                            this._salesSlipInputAcs.SettingSalesDetailRowInputRowCount(this._salesSlipInputAcs.SalesSlip.DetailRowCount);
                            //<<<2010/02/26

                            //>>>2010/03/30
                            this._scmSave = true;
                            this.SettingToolBarButtonEnabled();
                            //<<<2010/03/30

                            //>>>2010/02/26
                            //DialogResult dialogResult = TMsgDisp.Show(
                            //    this,
                            //    emErrorLevel.ERR_LEVEL_QUESTION,
                            //    this.Name,
                            //    "続けて入力しますか？",
                            //    0,
                            //    MessageBoxButtons.YesNo,
                            //    MessageBoxDefaultButton.Button2);

                            //bool keepAcptAnOdrStatus = false;
                            //bool keepDate = false;

                            //if (dialogResult == DialogResult.Yes)
                            //{
                            //    // ヘッダ情報はクリアしない
                            //    keepDate = true; // 日付保持
                            //    keepAcptAnOdrStatus = true; // 受注ステータス保持

                            //    // クリア処理
                            //    //this.Clear(false, keepAcptAnOdrStatus, keepDate, true, true); // 2010/02/26
                            //    this.Clear(false, keepAcptAnOdrStatus, keepDate, true, true, 0); // 2010/02/26

                            //    // 見積初期値設定情報
                            //    SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
                            //    this._salesSlipInputAcs.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());
                            //    this._salesSlipInputAcs.Cache(salesSlip);

                            //    // 車輌情報キャッシュ
                            //    if (this._salesSlipInputAcs.SvAcceptOdrCar != null)
                            //    {
                            //        this._salesSlipInputAcs.CacheCarInfo(1, null, null, this._salesSlipInputAcs.SvAcceptOdrCar);
                            //        this.SetDisplayCarInfo(1, CarSearchType.csNone);
                            //        this._salesSlipInputAcs.SearchCarDiv = false;
                            //    }

                            //    this.panel_Detail.Focus();
                            //    this._salesSlipDetailInput.uGrid_Details.Focus();
                            //}
                            //else
                            //{
                            //    // 全てクリア(初期状態へ)
                            //    keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;
                            //    keepAcptAnOdrStatus = false; // 受注ステータス保持

                            //    // クリア処理
                            //    this.Clear(false, keepAcptAnOdrStatus, keepDate);

                            //    this.timer_InitialSetFocus.Enabled = true;
                            //}
                            //<<<2010/02/26
                        }
                        break;
                    }
                #endregion
                //<<<2010/02/26
            }

			this.SettingAddUpButtonToolEnabled(null);

		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
		/// <summary>
		/// 見出貼付メイン
		/// </summary>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void CopySlipHeader()
		{
			// 見出貼付データ
			SalesSlipHeaderCopyData salesSlipHeaderCopyData = null;
			// 見出貼付XML
			string xmlFileName = System.IO.Path.Combine(Broadleaf.Application.Resources.ConstantManagement_ClientDirectory.UISettings, SLIPHEADERCOPY_XML_FILE_NAME);

			//-----------------------------------------------
			// 見出貼付XML読み込み
			//-----------------------------------------------
			# region [salesSlipHeaderCopyData←XML]
			// XML存在チェック
			if (!System.IO.File.Exists(xmlFileName))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"貼り付ける情報がありません。" + Environment.NewLine +
					"得意先電子元帳で見出複写を実行して下さい。",
					-1,
					MessageBoxButtons.OK);
				return;
			}

			// XML読み込み
			try
			{
				salesSlipHeaderCopyData = UserSettingController.DecryptionDeserializeUserSetting<SalesSlipHeaderCopyData>(xmlFileName, new string[] { ENCRYPTION_KEY });
			}
			catch
			{
				salesSlipHeaderCopyData = null;
			}

			// エラーチェック
			if (salesSlipHeaderCopyData == null)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"見出貼付情報の読み込みに失敗しました。" + Environment.NewLine +
					"得意先電子元帳で見出複写を再度実行して下さい。" + Environment.NewLine,
					-1,
					MessageBoxButtons.OK);
				return;
			}
			# endregion

			//-----------------------------------------------
			// 明細入力済み時のクリア確認・クリア処理
			//-----------------------------------------------
			# region [Clear]
			if (this._salesSlipInputAcs.ExistSalesDetail())
			{
				// 確認ダイアログを出す為、データ変更済みの扱いにする。
				// （修正呼出後に新規ボタンを押した場合、通常はダイアログ表示しない為）
				this._salesSlipInputAcs.IsDataChanged = true;

				bool keepDate = (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SlipDateClrDivCd == (int)SalesSlipInputAcs.SlipDateClrDivCd.InputDate) ? true : false;
				if (this.Clear(true, true, keepDate) == false) return;
			}
			else
			{
				# region [Clear(この時点で明細は無いが関連情報をクリアする為)]
				// 各種データクリア処理
				this._salesSlipInputAcs.ClearDataForNew();

				// 売上入力明細クリア処理
				this._salesSlipDetailInput.Clear();

				// 車両情報データ→画面
				SalesInputDataSet.CarInfoRow row = this._salesSlipInputAcs.GetCarInfoRow(1, SalesSlipInputAcs.GetCarInfoMode.NewInsertMode);
				this.SetDisplayCarInfo(row, CarSearchType.csNone);

				// 部品検索切替反映処理
				this.ChangeSearchModeReflect();

				// データ変更フラグプロパティをfalseにする
				this._salesSlipInputAcs.IsDataChanged = false;
				# endregion
			}
			# endregion

			//-----------------------------------------------
			// 見出貼付情報のセット
			//-----------------------------------------------
			// 入力中の売上データ
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

			# region [salesSlip(UI表示用)←salesSlipHeaderCopyData]
			// 得意先
			CopySlipHeaderCustomer(ref salesSlip, salesSlipHeaderCopyData); // 得意先・納入先・拠点・担当者・部門

			// 受注者
			try
			{
				if (!string.IsNullOrEmpty(_salesInputConstructionAcs.FrontEmployeeCdValue))
				{
					// 設定UIより
					salesSlip.FrontEmployeeCd = _salesInputConstructionAcs.FrontEmployeeCdValue.Trim();
					salesSlip.FrontEmployeeNm = this._salesSlipInputInitDataAcs.GetName_FromEmployee(salesSlip.FrontEmployeeCd);
				}
				else
				{
					// 見出貼付XMLより
					salesSlip.FrontEmployeeCd = salesSlipHeaderCopyData.FrontEmployeeCd.Trim();
					salesSlip.FrontEmployeeNm = this._salesSlipInputInitDataAcs.GetName_FromEmployee(salesSlip.FrontEmployeeCd);
				}
				// 名称の長さチェック
				if (salesSlip.FrontEmployeeNm.Length > 16) salesSlip.FrontEmployeeNm = salesSlip.FrontEmployeeNm.Substring(0, 16);
			}
			catch
			{
			}

			// 発行者
			try
			{
				if (!string.IsNullOrEmpty(_salesInputConstructionAcs.SalesInputCdValue))
				{
					// 設定UIより
					salesSlip.SalesInputCode = _salesInputConstructionAcs.SalesInputCdValue.Trim();
					salesSlip.SalesInputName = this._salesSlipInputInitDataAcs.GetName_FromEmployee(salesSlip.SalesInputCode);
				}
				else
				{
					// 見出貼付XMLより
					salesSlip.SalesInputCode = salesSlipHeaderCopyData.SalesInputCode.Trim();
					salesSlip.SalesInputName = this._salesSlipInputInitDataAcs.GetName_FromEmployee(salesSlip.SalesInputCode);
				}
				// 名称の長さチェック
				if (salesSlip.SalesInputName.Length > 16) salesSlip.SalesInputName = salesSlip.SalesInputName.Substring(0, 16);
			}
			catch
			{
			}

			// フッタ
			salesSlip.SlipNote = salesSlipHeaderCopyData.SlipNote; // 備考１
			salesSlip.SlipNote2 = salesSlipHeaderCopyData.SlipNote2; // 備考２
			salesSlip.SlipNote3 = salesSlipHeaderCopyData.SlipNote3; // 備考３
			salesSlip.PartySaleSlipNum = salesSlipHeaderCopyData.PartySaleSlipNum; // 仮伝番号

			salesSlip.AddresseeCode = salesSlipHeaderCopyData.AddresseeCode; // 納入先コード
			salesSlip.AddresseeName = salesSlipHeaderCopyData.AddresseeName.Trim(); // 納入先名１
			salesSlip.AddresseeName2 = salesSlipHeaderCopyData.AddresseeName2.Trim(); // 納入先名２

			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_DeliveredGoodsDiv, salesSlipHeaderCopyData.DeliveredGoodsDiv, false); // 納品区分
			salesSlip.DeliveredGoodsDiv = salesSlipHeaderCopyData.DeliveredGoodsDiv;
			salesSlip.DeliveredGoodsDivNm = this.tComboEditor_DeliveredGoodsDiv.Text;
			if (salesSlip.DeliveredGoodsDivNm.Length > 10) salesSlip.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm.Substring(0, 10);
			# endregion

			# region [車輌情報セット・検索]
			if (this.panel_CarInfo.Enabled)
			{
				// 型式指定番号のイベント処理を一時解除＞＞＞
				tNedit_ModelDesignationNo.ValueChanged -= this.tNedit_ModelDesignationNo_ValueChanged;

				// --- UPD 2009/09/08② -------------->>>
				ClearSlipHeaderCarSearch(ref salesSlipHeaderCopyData);
				// --- UPD 2009/09/08② --------------<<<
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
				// 車輌検索
				CopySlipHeaderCarSearch(salesSlipHeaderCopyData);
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

				// 車輌情報
				tEdit_CarMngCode.Text = salesSlipHeaderCopyData.CarMngCode.Trim(); // 管理番号
				tNedit_ModelDesignationNo.SetInt(salesSlipHeaderCopyData.ModelDesignationNo); // 型式指定番号
				tNedit_CategoryNo.SetInt(salesSlipHeaderCopyData.CategoryNo); // 類別番号
				tEdit_FullModel.Text = salesSlipHeaderCopyData.FullModel.Trim(); // フル型式
				tEdit_EngineModelNm.Text = salesSlipHeaderCopyData.EngineModelNm.Trim(); // エンジン型式
				tNedit_MakerCode.SetInt(salesSlipHeaderCopyData.MakerCode); // 車種メーカーコード
				tNedit_ModelCode.SetInt(salesSlipHeaderCopyData.ModelCode); // 車種コード
				tNedit_ModelSubCode.SetInt(salesSlipHeaderCopyData.ModelSubCode); // 車種サブコード
				tEdit_ModelFullName.Text = salesSlipHeaderCopyData.ModelFullName.Trim(); // 車種全角名称
				tDateEdit_FirstEntryDate.SetLongDate(salesSlipHeaderCopyData.FirstEntryDate); // 年式
				tEdit_ProduceFrameNo.Text = salesSlipHeaderCopyData.FrameNo; // 車台番号
				tEdit_ColorNo.Text = salesSlipHeaderCopyData.ColorCode.Trim(); // カラーコード
				tEdit_TrimNo.Text = salesSlipHeaderCopyData.TrimCode.Trim(); // トリムコード

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 DEL
				//// 車輌検索
				//CopySlipHeaderCarSearch( salesSlipHeaderCopyData );
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 DEL

				// 型式指定番号のイベント処理を再登録＜＜＜
				tNedit_ModelDesignationNo.ValueChanged += this.tNedit_ModelDesignationNo_ValueChanged;
			}
			# endregion

			//-----------------------------------------------
			// 変更内容の摘要とキャッシュ
			//-----------------------------------------------

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.CacheForChange(salesSlip);
			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// 納入先名 桁数補正
			if (this.tEdit_AddresseeName.Text.Length > 30)
			{
				salesSlip.AddresseeName = this.tEdit_AddresseeName.Text.Substring(0, 30);
			}

			// データ変更フラグプロパティをTrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			//-----------------------------------------------
			// フォーカス制御
			//-----------------------------------------------
			# region [フォーカス制御]
			if (this.panel_CarInfo.Enabled)
			{
                // --- UPD m.suzuki 2010/05/20 自由検索---------->>>>>
                //if (salesSlipHeaderCopyData.FullModelFixedNoAry == null || salesSlipHeaderCopyData.FullModelFixedNoAry.Length == 0)
                if ((salesSlipHeaderCopyData.FullModelFixedNoAry == null || salesSlipHeaderCopyData.FullModelFixedNoAry.Length == 0) &&
                    (salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry == null || salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry.Length == 0))
                // --- UPD m.suzuki 2010/05/20 自由検索----------<<<<<
                {
					if (salesSlipHeaderCopyData.CategoryNo != 0)
					{
						// 類別番号
						this.tNedit_CategoryNo.Focus();
					}
					else if (salesSlipHeaderCopyData.ModelDesignationNo != 0)
					{
						// 型式指定番号
						this.tNedit_ModelDesignationNo.Focus();
					}
					else if (!string.IsNullOrEmpty(salesSlipHeaderCopyData.FullModel))
					{
						// フル型式
						this.tEdit_FullModel.Focus();
					}
					else if (!string.IsNullOrEmpty(salesSlipHeaderCopyData.EngineModelNm))
					{
						// エンジン型式
						this.tEdit_EngineModelNm.Focus();
					}
				}
			}
			# endregion

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();

			//-----------------------------------------------
			// 管理番号ガイド制御
			//-----------------------------------------------
			# region [管理番号ガイド制御]
			//if (salesSlipHeaderCopyData.CarMngNo == 0 &&
			//    (!string.IsNullOrEmpty(salesSlipHeaderCopyData.CarMngCode))
			//    && (this._salesSlipInputAcs.SalesSlip.CarMngDivCd == 1 ||
			//    this._salesSlipInputAcs.SalesSlip.CarMngDivCd == 2))
			//{
			//    CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
			//    paramInfo.EnterpriseCode = this._enterpriseCode;
			//    // 管理番号絞り込み前方一致
			//    paramInfo.IsCheckCarMngCode = true;
			//    // 管理コード
			//    paramInfo.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
			//    // 管理コードの前方
			//    paramInfo.CheckCarMngCodeType = 1;
			//    // 車輌管理区分チェック有り
			//    paramInfo.IsCheckCarMngDivCd = true;
			//    //得意先コード絞り込み有り
			//    paramInfo.IsCheckCustomerCode = true;
			//    //得意先コード
			//    paramInfo.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
			//    // データ存在チェック
			//    int status = this._carMngInputAcs.ExecuteGuidBeforeDataCheck(paramInfo);
			//    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			//    {
			//        this.uButton_CarMngNoGuide.Enabled = true;
			//    }
			//    else
			//    {
			//        this.uButton_CarMngNoGuide.Enabled = false;
			//    }
			//}
			//else
			//{
			//    this.uButton_CarMngNoGuide.Enabled = false;
			//}
			# endregion
			// --- ADD 2009/09/08② ----------<<<<<

			// --- ADD 2009/12/23 ---------->>>>>
			//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
			this._salesSlipInputAcs.GetNoteCharCnt();
			SetNoteCharCnt();
			// --- ADD 2009/12/23 ----------<<<<<
		}

		/// <summary>
		/// 見出貼付（得意先）
		/// </summary>
		/// <param name="_enterpriseCode"></param>
		/// <param name="customerCode"></param>
		/// <remarks>※得意先コード変更時の処理をコピーして一部変更</remarks>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void CopySlipHeaderCustomer(ref SalesSlip salesSlip, SalesSlipHeaderCopyData salesSlipHeaderCopyData)
		{
			bool reCalcStockUnitPrice = false;
			bool clearRateInfo = false;
			CustomerInfo customerInfo;
			this.Cursor = Cursors.WaitCursor;
			DialogResult dialogResult = DialogResult.No;
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _enterpriseCode, salesSlipHeaderCopyData.CustomerCode, true, false, out customerInfo);

			// 得意先チェック
			if (customerInfo != null)
			{
				if (customerInfo.IsCustomer != true)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			this.Cursor = Cursors.Default;

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
				(!this._salesSlipInputAcs.CheckTransStopDate(customerInfo.TransStopDate)))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"取引停止中により設定できません。",
					-1,
					MessageBoxButtons.OK);
				return;
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				bool settingFlg = false;
				if ((this._salesSlipInputAcs.ExistSalesDetail()) &&
					(salesSlip.CustomerCode != 0) &&
					(customerInfo.AccRecDivCd != salesSlip.AccRecDivCd))
				{
					dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"売掛得意先と現金得意先間のコード変更です。" + "\r\n" + "\r\n" +
						this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
						"よろしいですか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult == DialogResult.Yes)
					{
						settingFlg = true;
						this._salesSlipDetailInput.Clear();
						this._salesSlipInputAcs.ClearCarInfo();
						this.ClearDisplayCarInfo();
					}
				}
				else
				{
					settingFlg = true;
				}

				if (settingFlg)
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
					// 現金売り得意先(AccRecDivCd = 0:売掛なし)の場合は、見出貼付情報から略称をセットする。
					if (customerInfo.AccRecDivCd == 0 && !string.IsNullOrEmpty(salesSlipHeaderCopyData.CustomerSnm))
					{
						customerInfo.CustomerSnm = salesSlipHeaderCopyData.CustomerSnm.Trim();
					}
					if (customerInfo.CustomerSnm.Length > 20) customerInfo.CustomerSnm = customerInfo.CustomerSnm.Substring(0, 20);
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

					// 得意先情報設定処理
					this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);

					// 得意先掛率グループ再セット
					this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
					// 計上日の再セット
					this._salesSlipInputAcs.SettingSalesSlipAddUpDate(ref salesSlip); // 計上日再設定
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

					// 担当者情報設定処理
					this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, salesSlip.SalesEmployeeCd);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
					// 納入先情報設定処理
					this._salesSlipInputAcs.SettingSalesSlipAddressee(ref salesSlip, customerInfo);
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD


					// 売上明細データセッティング処理（課税区分設定）
					this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);

					if ((salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
						(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
					{
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"得意先が変更されました。" + "\r\n" + "\r\n" +
							"商品価格を再取得しますか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							reCalcStockUnitPrice = true;
						}
						else
						{
							clearRateInfo = true;
						}

					}
				}

			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"得意先が存在しません。",
					-1,
					MessageBoxButtons.OK);
				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);
				return;
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// 得意先情報画面格納処理
			this.SetDisplayCustomerInfo(customerInfo);

			// 伝票区分コンボエディタアイテム設定処理
			this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatusDisplay, false);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
			// Visible設定
			this.SettingVisible();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

			// データ変更フラグプロパティをTrueにする
			this._salesSlipInputAcs.IsDataChanged = true;

			if (reCalcStockUnitPrice)
			{
				List<List<GoodsUnitData>> goodsUnitDataListList;
				string msg;
				this._salesSlipInputAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(out goodsUnitDataListList, out msg);
				this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(goodsUnitDataListList);
			}

			//---------------------------------------------------------------
			// 掛率情報クリア
			//---------------------------------------------------------------
			if (clearRateInfo)
			{
				// 掛率情報クリア
				this._salesSlipInputAcs.ClearAllRateInfo();
			}

			this._salesSlipDetailInput.SetToolbarButton -= new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);
			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();
			this._salesSlipDetailInput.SetToolbarButton += new MAHNB01010UB.SettingToolbarEventHandler(this.ToolButtonSettingDetail);

			// 売上金額計算処理
			this._salesSlipDetailInput.CalculationSalesPrice();

			// 売上金額変更後発生イベント処理
			this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<
		}

		/// <summary>
		/// 車両検索処理
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2010/01/27 張凱 各種車輌検索後のTBO検索を可能対応</br>
		private int CopySlipHeaderCarSearch(SalesSlipHeaderCopyData salesSlipHeaderCopyData)
		{
			//------------------------------------------------------
			// 初期処理
			//------------------------------------------------------
			int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			//------------------------------------------------------
			// 売上行番号取得
			//------------------------------------------------------
			int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();

			//------------------------------------------------------
			// 各種検索処理
			//------------------------------------------------------
			//  CarSearchCondition の検索タイプにより指定
			//------------------------------------------------------
			CarSearchResultReport ret;
			PMKEN01010E dat = new PMKEN01010E();
			int[] fullModelFixedNo = salesSlipHeaderCopyData.FullModelFixedNoAry;
            // --- UPD m.suzuki 2010/05/20 自由検索---------->>>>>
            string[] freeSrchMdlFxdNo = salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry;
            // --- UPD m.suzuki 2010/05/20 自由検索----------<<<<<

            // --- UPD m.suzuki 2010/05/20 自由検索---------->>>>>
            //if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
            if ((fullModelFixedNo != null && fullModelFixedNo.Length > 0) ||
                 (freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0))
            // --- UPD m.suzuki 2010/05/20 自由検索----------<<<<<
            {
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 UPD
				//ret = this._salesSlipInputAcs.SearchCar( fullModelFixedNo, tNedit_ModelDesignationNo.GetInt(), tNedit_CategoryNo.GetInt(), ref dat );

				CarSearchCondition carSearchCond = new CarSearchCondition();

				carSearchCond.CarModel.FullModel = salesSlipHeaderCopyData.FullModel;
				carSearchCond.MakerCode = salesSlipHeaderCopyData.MakerCode;
				carSearchCond.ModelCode = salesSlipHeaderCopyData.ModelCode;
				carSearchCond.ModelSubCode = salesSlipHeaderCopyData.ModelSubCode;
				// --- ADD 2010/01/27 -------------->>>>>
				carSearchCond.ModelDesignationNo = salesSlipHeaderCopyData.ModelDesignationNo;
				carSearchCond.CategoryNo = salesSlipHeaderCopyData.CategoryNo;
				// --- ADD 2010/01/27 --------------<<<<<

                // --- UPD m.suzuki 2010/05/20 自由検索---------->>>>>
                //ret = this._salesSlipInputAcs.SearchCar(fullModelFixedNo, carSearchCond, ref dat);
                ret = this._salesSlipInputAcs.SearchCar(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref dat);
                // --- UPD m.suzuki 2010/05/20 自由検索----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 UPD
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/21 UPD
				//// 検索結果キャッシュ
				//this._salesSlipInputAcs.CacheCarInfoForSlipHeaderCopy( salesRowNo, dat, salesSlipHeaderCopyData );
				//// 検索済みにする
				//this._salesSlipInputAcs.SearchCarDiv = false;
				//// 車両情報画面表示処理
				//this.SetDisplayCarInfo( salesRowNo, CarSearchType.csNone );

				if ((ret != CarSearchResultReport.retError) && (ret != CarSearchResultReport.retFailed))
				{
					// 検索済みにする
					this._salesSlipInputAcs.SearchCarDiv = false;
				}
				else
				{
					// 後で検索が必要
					this._salesSlipInputAcs.SearchCarDiv = true;
				}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/21 UPD
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/21 ADD
				// 検索結果キャッシュ
				this._salesSlipInputAcs.CacheCarInfoForSlipHeaderCopy(salesRowNo, dat, salesSlipHeaderCopyData);
				// 車両情報画面表示処理
				this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/21 ADD
			}
			else
			{
				// --- UPD 2009/09/08② -------------->>>
				// 検索結果キャッシュ
				this._salesSlipInputAcs.CacheCarInfoForSlipHeaderCopy(salesRowNo, dat, salesSlipHeaderCopyData);

				// 車両情報画面表示処理
				this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

				// --- UPD 2009/09/08② --------------<<<
				// 後で検索が必要
				this._salesSlipInputAcs.SearchCarDiv = true;
			}
			return retStatus;
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

		/// <summary>
		/// 車両クリア処理
		/// </summary>
		/// <param name="salesSlipHeaderCopyData"></param>
		/// <remarks>
		/// <br>Note       : 車両クリア処理します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void ClearSlipHeaderCarSearch(ref SalesSlipHeaderCopyData salesSlipHeaderCopyData)
		{
			bool clearflag = false;
			if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() != null &&
					this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1)
			{
				if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
				{
					clearflag = false;
				}
				else
				{
					clearflag = true;
				}
			}
			else
			{
				clearflag = true;
			}

			if (clearflag == true)
			{
				// 車両管理番号
				salesSlipHeaderCopyData.CarMngNo = 0;
				// 車両走行距離
				salesSlipHeaderCopyData.Mileage = 0;
				// 車輌備考
				salesSlipHeaderCopyData.CarNote = string.Empty;
				// 陸運事務所番号
				salesSlipHeaderCopyData.NumberPlate1Code = 0;
				// 陸運事務局名称
				salesSlipHeaderCopyData.NumberPlate1Name = string.Empty;
				// 車両登録番号（種別）
				salesSlipHeaderCopyData.NumberPlate2 = string.Empty;
				// 車両登録番号（カナ）
				salesSlipHeaderCopyData.NumberPlate3 = string.Empty;
				// 車両登録番号（プレート番号）
				salesSlipHeaderCopyData.NumberPlate4 = 0;

				if (this._salesSlipInputInitDataAcs.GetSalesTtlSt() == null ||
					this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 0)
				{
					salesSlipHeaderCopyData.CarMngCode = string.Empty;
				}
			}
		}

		/// <summary>
		/// アクティブコントロール取得処理
		/// </summary>
		/// <returns></returns>
		private Control GetActiveControl()
		{
			Control ctrl = this.ActiveControl;

			if (ctrl != null)
			{
				ctrl = this.GetParentControl(ctrl);
			}

			return ctrl;
		}

		/// <summary>
		/// 親コントロール取得処理
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private Control GetParentControl(Control ctrl)
		{
			Control retCtrl = ctrl;
			if (ctrl.Parent != null)
			{
				if ((ctrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
					(ctrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
					(ctrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
					(ctrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
				{
					//retCtrl = ctrl.Parent;
					retCtrl = GetParentControl(ctrl.Parent);
				}
			}

			return retCtrl;
		}

		/// <summary>
		/// 在庫検索処理
		/// </summary>
		private void StockSearch()
		{
			this._salesSlipDetailInput.StockSearch();

			// 明細部変更後発生イベント処理
			SalesSlipDetailInput_DetailChanged(this, this._salesSlipDetailInput.GetActiveRowSalesRowNo());
		}

		/// <summary>
		/// 売上履歴検索処理
		/// </summary>
		private void SalesReferenceSearch()
		{
			if (this.panel_Detail.ContainsFocus) this._salesSlipDetailInput.SalesReferenceSearch();
		}

		/// <summary>
		/// 出荷照会検索処理(明細選択)
		/// </summary>
		private void ShipmentReferenceSearch()
		{
			if (this.panel_Detail.ContainsFocus) this._salesSlipDetailInput.ShipmentReferenceSearch();
		}

		/// <summary>
		/// 受注照会検索処理(明細選択)
		/// </summary>
		private void AcceptAnOrderReferenceSearch()
		{
			if (this.panel_Detail.ContainsFocus) this._salesSlipDetailInput.AcceptAnOrderReferenceSearch();
		}

		/// <summary>
		/// 見積照会検索処理(明細選択)
		/// </summary>
		private void EstimateReferenceSearch()
		{
			if (this.panel_Detail.ContainsFocus) this._salesSlipDetailInput.EstimateReferenceSearch();
		}

		/// <summary>
		/// 部品検索切替処理
		/// </summary>
		/// <param name="clearCarFlag">カラー、トリム、、装備ガイドの内容もクリア 1:する、0：なし</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2010/01/27 高峰 検索モード切替時のフォーカス制御の変更の対応</br>
		private void ChangeSearchMode(int clearCarFlag)
		{
			if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
			{
				this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch;
				// ---------- ADD 2010/01/27 ---------->>>>>>>>>>
				this._carMngCode = this.tEdit_CarMngCode.Text;
				this._categoryNo = this.tNedit_CategoryNo.GetInt();
				this._modelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
				this._fullModel = this.tEdit_FullModel.Text;
				this._engineModelNm = this.tEdit_EngineModelNm.Text;
				// ---------- ADD 2010/01/27 ----------<<<<<<<<<<
			}
			else if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
			{
				this._salesSlipInputAcs.SearchPartsModeProperty = SalesSlipInputAcs.SearchPartsMode.BLCodeSearch;

				// ---------- ADD 2010/01/27 ---------->>>>>>>>>>
				if (clearCarFlag == 1)
				{
					this._salesSlipDetailInput.uGrid_Details.BeginUpdate();
					this._salesSlipDetailInput.uGrid_Details.UpdateData();
					//無効行の場合、品番検索モード->BLコード検索モード変換すると、無効行の内容をクリア
					foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this._salesSlipDetailInput.uGrid_Details.Rows)
					{
						if (!this._salesSlipDetailInput.CheckRowEffective(row.Index))
						{
							this._salesSlipInputAcs.ClearSalesDetailRow(row.Index + 1);
						}
					}
					this._salesSlipDetailInput.uGrid_Details.EndUpdate();
				}
				// ---------- ADD 2010/01/27 ----------<<<<<<<<<<
			}

			this.ChangeSearchModeReflect();

			if (clearCarFlag == 1)
			{
				// --- UPD 2009/11/24 ---------->>>>>

				// --- ADD 2009/09/08② ---------->>>>>
				int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();
				//this._salesSlipInputAcs.ClearCarRelationGuid(salesRowNo);

				//新規登録時の処理
				if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal
					&& (this._salesSlipInputAcs.SalesSlip.SalesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum))
				{
					if (!this._salesSlipDetailInput.ContainsFocus)
					{
						if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
						{
							this._salesSlipInputAcs.ClearCarInfoByGoodsNoSearch();

							// 車両情報画面表示処理
							this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
						}
					}

					// ---------- ADD 2010/01/27 ---------->>>>>>>>>>
					if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
					{
						bool carMngCodeMode = false;

						if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON
							&& this._salesSlipInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1
							&& (this._salesSlipInputAcs.SalesSlip.CarMngDivCd == 1 ||
							this._salesSlipInputAcs.SalesSlip.CarMngDivCd == 2))
						{
							carMngCodeMode = true;
						}

						if (!this._salesSlipDetailInput.uGrid_Details.ContainsFocus)
						{
							if (!string.IsNullOrEmpty(this.tEdit_CarMngCode.Text) && carMngCodeMode)
							{
								// 管理番号
								this.tEdit_CarMngCode.Focus();
							}
							else if (this.tNedit_CategoryNo.GetInt() != 0)
							{
								// 類別番号
								this.tNedit_CategoryNo.Focus();
							}
							else if (this.tNedit_ModelDesignationNo.GetInt() != 0)
							{
								// 型式指定番号
								this.tNedit_ModelDesignationNo.Focus();
							}
							else if (!string.IsNullOrEmpty(this.tEdit_FullModel.Text))
							{
								// フル型式
								this.tEdit_FullModel.Focus();
							}
							else if (!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text))
							{
								// エンジン型式
								this.tEdit_EngineModelNm.Focus();
							}
						}
						else
						{
							if (this._carMngCode != this.tEdit_CarMngCode.Text
								|| this._categoryNo != this.tNedit_CategoryNo.GetInt()
								|| this._modelDesignationNo != this.tNedit_ModelDesignationNo.GetInt()
								|| this._fullModel != this.tEdit_FullModel.Text
								|| this._engineModelNm != this.tEdit_EngineModelNm.Text)
							{
								if (!string.IsNullOrEmpty(this.tEdit_CarMngCode.Text) && carMngCodeMode)
								{
									// 管理番号
									this.tEdit_CarMngCode.Focus();
								}
								else if (this.tNedit_CategoryNo.GetInt() != 0)
								{
									// 類別番号
									this.tNedit_CategoryNo.Focus();
								}
								else if (this.tNedit_ModelDesignationNo.GetInt() != 0)
								{
									// 型式指定番号
									this.tNedit_ModelDesignationNo.Focus();
								}
								else if (!string.IsNullOrEmpty(this.tEdit_FullModel.Text))
								{
									// フル型式
									this.tEdit_FullModel.Focus();
								}
								else if (!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text))
								{
									// エンジン型式
									this.tEdit_EngineModelNm.Focus();
								}
							}
						}
					}
					// ---------- ADD 2010/01/27 ----------<<<<<<<<<<
				}

				// --- ADD 2009/09/08② ----------<<<<<

				// --- UPD 2009/11/24 ----------<<<<<
			}
		}

		/// <summary>
		/// 部品検索切替反映処理
		/// </summary>
		private void ChangeSearchModeReflect()
		{
			if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
			{
				this.uLabel_SearchMode.Text = ctSearchMode_BLSearch;
				this._salesSlipInputAcs.SearchCarDiv = true;
			}
			else if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
			{
				this.uLabel_SearchMode.Text = ctSearchMode_GoodsNoSearch;
				this._salesSlipInputAcs.SearchCarDiv = false;
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(this._salesSlipInputAcs.SalesSlip);

			// 明細グリッド設定処理
			this._salesSlipDetailInput.SettingGrid();

			// 明細フォーカス位置設定
			if (this._salesSlipDetailInput.ContainsFocus)
			{
				if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.GoodsNoSearch)
				{
					if (this._salesSlipDetailInput.uGrid_Details.ActiveCell != null) this._salesSlipDetailInput.SettingFocus(this._salesSlipInputAcs.SalesDetailDataTable.GoodsNoColumn.ColumnName);
				}
				else if (this._salesSlipInputAcs.SearchPartsModeProperty == SalesSlipInputAcs.SearchPartsMode.BLCodeSearch)
				{
					if (this._salesSlipDetailInput.uGrid_Details.ActiveCell != null) this._salesSlipDetailInput.SettingFocus(this._salesSlipInputAcs.SalesDetailDataTable.BLGoodsCodeColumn.ColumnName);
				}
			}

			// 移動先テーブル再設定処理
			this._salesSlipDetailInput.ReSettingEnterMoveTable();
		}

		/// <summary>
		/// 車両検索切替処理
		/// </summary>
		private void ChangeSearchCarMode()
		{
			if (this._salesSlipInputAcs.SearchCarModeProperty == SalesSlipInputAcs.SearchCarMode.FullModelSearch)
			{
				this._salesSlipInputAcs.SearchCarModeProperty = SalesSlipInputAcs.SearchCarMode.ModelPlateSearch;
				this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_ModelPlate;
			}
			else if (this._salesSlipInputAcs.SearchCarModeProperty == SalesSlipInputAcs.SearchCarMode.ModelPlateSearch)
			{
				this._salesSlipInputAcs.SearchCarModeProperty = SalesSlipInputAcs.SearchCarMode.FullModelSearch;
				this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_FullModel;
			}
		}

		/// <summary>
		/// 得意先名称ラベルマウスエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_CustomerName_MouseEnter(object sender, EventArgs e)
		{
			if (this.tNedit_CustomerCode.GetInt() == 0) return;

			CustomerInfo customerInfo;
			int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, this.tNedit_CustomerCode.GetInt());

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tEdit_CustomerName.Cursor = Cursors.Help;

				StringBuilder tipString = new StringBuilder();

				int totalWidth = 4;

				// セパレータ
				//tipString = tipString.Append("　");

				// 得意先名称
				tipString = tipString.Append("名称".PadRight(totalWidth, '　') + "：" + customerInfo.Name + " " + customerInfo.Name2);

				// カナ
				tipString = tipString.Append("\r\n" + "カナ".PadRight(totalWidth, '　') + "：" + customerInfo.Kana);

				// コード
				tipString = tipString.Append("\r\n" + "コード".PadRight(totalWidth, '　') + "：" + customerInfo.CustomerCode.ToString());

				// 電話番号
				switch (customerInfo.MainContactCode)
				{
					case 0:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.HomeTelNo);
							break;
						}
					case 1:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OfficeTelNo);
							break;
						}
					case 2:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.PortableTelNo);
							break;
						}
					case 3:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.HomeFaxNo);
							break;
						}
					case 4:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OfficeFaxNo);
							break;
						}
					case 5:
						{
							tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OthersTelNo);
							break;
						}
				}

				CustomerInfo claim;

				status = this._customerInfoAcs.ReadStaticMemoryData(out claim, this._enterpriseCode, this.tNedit_CustomerCode.GetInt());

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// セパレータ
					tipString = tipString.Append("\r\n" + "　");

					// 請求先名
					tipString = tipString.Append("\r\n" + "請求先".PadRight(totalWidth, '　') + "：" + claim.Name + " " + claim.Name2);
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "得意先情報";
				ultraToolTipInfo.ToolTipText = tipString.ToString();

				this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
				this.uToolTipManager_Information.SetUltraToolTip(this.uLabel_CustomerCode, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;
			}
		}

		/// <summary>
		/// 得意先名称ラベルマウスリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_CustomerName_MouseLeave(object sender, EventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;
			this.tEdit_CustomerName.Cursor = Cursors.Default;
		}

		/// <summary>
		/// tEdit_CarMngCode_MouseEnterイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_CarMngCode_MouseEnter(object sender, EventArgs e)
		{
			//if (this.tEdit_CarMngCode.Text.Trim() != string.Empty) return;

			//switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
			//{
			//    case 0: // しない
			//        break;
			//    case 1: // 登録(確認)
			//    case 2: // 登録(自動)
			//        StringBuilder tipString = new StringBuilder();

			//        tipString = tipString.Append("型式および管理番号が入力されていなければ、車両管理マスタの登録は行いません。");

			//        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
			//        ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
			//        ultraToolTipInfo.ToolTipTitle = "車両管理マスタ登録条件";
			//        ultraToolTipInfo.ToolTipText = tipString.ToString();

			//        this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
			//        this.uToolTipManager_Information.SetUltraToolTip(this.tEdit_CarMngCode, ultraToolTipInfo);
			//        this.uToolTipManager_Information.Enabled = true;
			//        break;
			//    case 3: // 登録無
			//        break;
			//}
		}

		/// <summary>
		/// コンボボックスツール値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			//switch (e.Tool.Key)
			//{
			//    case "ComboBoxTool_SectionCode":			// 拠点コンボボックス
			//        {
			//            string selectedSectionCode = this._sectionComboBox.ValueList.ValueListItems[this._sectionComboBox.SelectedIndex].DataValue.ToString();
			//            string sectionCode;
			//            string sectionName;

			//            SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			//            try
			//            {
			//                //-------------------------------------------
			//                // 自拠点設定
			//                //-------------------------------------------
			//                this._salesSlipInputInitDataAcs.GetOwnSeCtrlCode(selectedSectionCode, out sectionCode, out sectionName);
			//                // 実績計上拠点コード
			//                salesSlip.ResultsAddUpSecCd = sectionCode;
			//                salesSlip.ResultsAddUpSecNm = sectionName;
			//                //// 拠点コード
			//                //salesSlip.SectionCode = selectedSectionCode.ToString();
			//                //// 売上入力拠点コード
			//                //salesSlip.SalesInpSecCd = selectedSectionCode.ToString();
			//                //// 更新拠点コード
			//                //salesSlip.UpdateSecCd = selectedSectionCode.ToString();
			//                this._salesSlipInputAcs.Cache(salesSlip);
			//            }
			//            catch { }

			//            break;
			//        }
			//}
		}

		/// <summary>
		/// 商品区分コンボエディタ選択確定後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SalesGoodsCd_SelectionChangeCommitted(object sender, EventArgs e)
		{
			bool changeStockGoodsCd = false;
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SalesGoodsCd, ComboEditorGetDataType.TAG);

			if (salesSlip.SalesGoodsCd != code)
			{
				if (code != -1)
				{
					// 売上明細データ存在チェック処理
					if ((!this.EqualsSalesGoodsCdType(salesSlip.SalesGoodsCd, code)) && (this._salesSlipInputAcs.ExistSalesDetail()))
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							this._salesSlipDetailInput.Clear();
							this._salesSlipInputAcs.ClearCarInfo();
							this.ClearDisplayCarInfo();
							changeStockGoodsCd = true;
							salesSlip.SalesGoodsCd = code;
						}
					}
					else
					{
						this._salesSlipInputAcs.ClearCarInfo();
						this.ClearDisplayCarInfo();
						changeStockGoodsCd = true;
					}
				}
			}

			if (changeStockGoodsCd)
			{
				salesSlip.SalesGoodsCd = code;

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// グリッド設定処理（ユーザー設定より）
			this._salesSlipDetailInput.GridSetting(this._salesInputConstructionAcs.SalesInputConstruction);

			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();
		}

		/// <summary>
		/// 売上形式コンボエディタ選択値変更確定後イベント(表示用)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tComboEditor_AcptAnOdrStatusDisplay_SelectionChangeCommitted(object sender, EventArgs e)
		{
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			this.ChangeAcptAnOdrStatus(ref salesSlip, true);

			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();

			this._salesSlipDetailInput.ActiveCellButtonEnabledControl();

			this.ToolButtonSettingDetail();
		}

		/// <summary>
		/// 売上形式変更処理
		/// </summary>
		/// <param name="salesSlip">売上データオブジェクト</param>
		/// <param name="isCache">キャッシュ有無</param>
		/// <returns></returns>
		private bool ChangeAcptAnOdrStatus(ref SalesSlip salesSlip, bool isCache)
		{
			bool changeAcptAnOdrStatus = true;
			bool formatFlg = true;
			int svCode = salesSlip.AcptAnOdrStatusDisplay;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_AcptAnOdrStatusDisplay, ComboEditorGetDataType.TAG);

			if (code == -1)
			{
				changeAcptAnOdrStatus = false;
			}
			else if (salesSlip.AcptAnOdrStatusDisplay != code)
			{
				if (this._salesSlipInputAcs.ExistSalesDetail())
				{
					formatFlg = false;
					if (ChangeCheckAcptAnOdrStatus(code, salesSlip) != true)
					{
						changeAcptAnOdrStatus = false;
					}
				}
			}
			else
			{
				changeAcptAnOdrStatus = false;
			}

			if (changeAcptAnOdrStatus)
			{
				// 受注ステータス、見積区分セット
				salesSlip.AcptAnOdrStatusDisplay = code;
				SalesSlipInputAcs.SetAcptAnOdrStatusAndEstimateDivideFromDisplay(ref salesSlip);

				// 商品区分
				salesSlip.SalesGoodsCd = 0;

				switch ((SalesSlipInputAcs.AcptAnOdrStatusState)code)
				{
					// 売上形式が「見積」の場合
					case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
						{
							salesSlip.AddUpADate = DateTime.MinValue;		                                            // 計上日クリア
							switch ((SalesSlipInputAcs.AcptAnOdrStatusState)svCode)
							{
								case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
								case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
									this._salesSlipInputAcs.SettingClearCount(1);
									break;
								default:
									break;
							}
							break;
						}
					// 売上形式が「単価見積」の場合
					case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
						{
							salesSlip.AddUpADate = DateTime.MinValue;		                                            // 計上日をクリアする
							this._salesSlipInputAcs.SettingClearCount(0);
							break;
						}
					// 売上形式が「売上」の場合
					case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
						{
							this._salesSlipInputAcs.SettingSalesSlipAddUpDate(ref salesSlip);
							break;
						}
					// 売上形式が「出荷」の場合
					case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
						{
							break;
						}
				}

				// 売上金額変更後発生イベント処理
				this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
				// 明細部変更後発生イベント処理
				SalesSlipDetailInput_DetailChanged(this, this._salesSlipDetailInput.GetActiveRowSalesRowNo());

				// フッタタブ位置セット
				uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];

				// 売上商品区分コンボエディタアイテム設定処理
				this.SetItemtSalesGoodsCd(code, formatFlg);
				this.SetItemtSalesSlipCd(ref salesSlip, code, formatFlg);

				// 売上商品区分を取得
				salesSlip.SalesGoodsCd = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SalesGoodsCd, ComboEditorGetDataType.TAG);

				if (isCache == true)
				{
					// 売上データキャッシュ処理
					this._salesSlipInputAcs.Cache(salesSlip);
				}
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			return changeAcptAnOdrStatus;
		}

		/// <summary>
		/// 売上形式変更可能チェック処理
		/// </summary>
		/// <param name="code"></param>
		/// <param name="salesSlip"></param>
		/// <returns></returns>
		private bool ChangeCheckAcptAnOdrStatus(int code, SalesSlip salesSlip)
		{

			bool ret = false;

			SalesSlipInputAcs.AcptAnOdrStatusState acptAnOdrStatusStateAfter = (SalesSlipInputAcs.AcptAnOdrStatusState)code;
			SalesSlipInputAcs.SalesGoodsCd salesGoodsCd = (SalesSlipInputAcs.SalesGoodsCd)salesSlip.SalesGoodsCd;
			SalesSlipInputAcs.SalesSlipDisplay salesSlipDisplay = (SalesSlipInputAcs.SalesSlipDisplay)salesSlip.SalesSlipDisplay;

			// 伝票区分
			Dictionary<SalesSlipInputAcs.AcptAnOdrStatusState, List<SalesSlipInputAcs.SalesSlipDisplay>> salesSlipDisplayDic = new Dictionary<SalesSlipInputAcs.AcptAnOdrStatusState, List<SalesSlipInputAcs.SalesSlipDisplay>>();
			salesSlipDisplayDic[SalesSlipInputAcs.AcptAnOdrStatusState.Estimate] = MakeSalesSlipDisplayList(SalesSlipInputAcs.AcptAnOdrStatusState.Estimate);
			salesSlipDisplayDic[SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate] = MakeSalesSlipDisplayList(SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate);
			salesSlipDisplayDic[SalesSlipInputAcs.AcptAnOdrStatusState.Sales] = MakeSalesSlipDisplayList(SalesSlipInputAcs.AcptAnOdrStatusState.Sales);
			salesSlipDisplayDic[SalesSlipInputAcs.AcptAnOdrStatusState.Shipment] = MakeSalesSlipDisplayList(SalesSlipInputAcs.AcptAnOdrStatusState.Shipment);
			List<SalesSlipInputAcs.SalesSlipDisplay> salesSlipDisplayList = new List<SalesSlipInputAcs.SalesSlipDisplay>();
			salesSlipDisplayList = salesSlipDisplayDic[acptAnOdrStatusStateAfter];
			ret = SalesSlipInputAcs.diverge<bool>(salesSlipDisplayList.Contains(salesSlipDisplay), true, false);
			if (ret == false)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"伝票区分が有効ではない為、変更できません。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return false;
			}

			// 商品区分
			Dictionary<SalesSlipInputAcs.AcptAnOdrStatusState, List<SalesSlipInputAcs.SalesGoodsCd>> salesGoodsCdDic = new Dictionary<SalesSlipInputAcs.AcptAnOdrStatusState, List<SalesSlipInputAcs.SalesGoodsCd>>();
			salesGoodsCdDic[SalesSlipInputAcs.AcptAnOdrStatusState.Estimate] = MakeSalesGoodsCdList(SalesSlipInputAcs.AcptAnOdrStatusState.Estimate);
			salesGoodsCdDic[SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate] = MakeSalesGoodsCdList(SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate);
			salesGoodsCdDic[SalesSlipInputAcs.AcptAnOdrStatusState.Sales] = MakeSalesGoodsCdList(SalesSlipInputAcs.AcptAnOdrStatusState.Sales);
			salesGoodsCdDic[SalesSlipInputAcs.AcptAnOdrStatusState.Shipment] = MakeSalesGoodsCdList(SalesSlipInputAcs.AcptAnOdrStatusState.Shipment);
			List<SalesSlipInputAcs.SalesGoodsCd> salesGoodsCdList = new List<SalesSlipInputAcs.SalesGoodsCd>();
			salesGoodsCdList = salesGoodsCdDic[acptAnOdrStatusStateAfter];
			ret = SalesSlipInputAcs.diverge<bool>(salesGoodsCdList.Contains(salesGoodsCd), true, false);
			if (ret == false)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"商品区分が有効ではない為、変更できません。",
					0,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return false;
			}

			// 商品以外、行値引き、出荷数マイナス入力行、仕入情報入力行、発注情報入力行があった場合はクリアする
			if ((salesSlip.SalesGoodsCd != 0) ||
				(this._salesSlipInputAcs.ExistSalesDetailDiscountData()) ||
				(this._salesSlipInputAcs.ExistSalesDetailMinusCount()) ||
				(this._salesSlipInputAcs.ExistStockTemp()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
					"よろしいですか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					this._salesSlipDetailInput.Clear();
					this._salesSlipInputAcs.ClearCarInfo();
					this.ClearDisplayCarInfo();
					return true;
				}
				else
				{
					return false;
				}
			}
			else if ((this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Normal) &&
					 (this._salesSlipInputAcs.ExistSalesDetailAddUpSrcData()))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "計上情報がクリアされます。" + "\r\n" + "\r\n" +
					"よろしいですか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					this._salesSlipInputAcs.ClearAddUpInfo();
					return true;
				}
				else
				{
					return false;
				}
			}

			return true;

		}

		/// <summary>
		/// 伝票区分設定リスト作成処理
		/// </summary>
		/// <param name="acptAnOdrStatusState"></param>
		/// <returns></returns>
		private List<SalesSlipInputAcs.SalesSlipDisplay> MakeSalesSlipDisplayList(SalesSlipInputAcs.AcptAnOdrStatusState acptAnOdrStatusState)
		{
			List<SalesSlipInputAcs.SalesSlipDisplay> salesSlipDisplayList = new List<SalesSlipInputAcs.SalesSlipDisplay>();

			switch (acptAnOdrStatusState)
			{
                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRec);
                    break;
                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRec);
                    break;
                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRec);
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRecRetGoods);
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.Cash);
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.CashRetGoods);
                    break;
                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRec);
                    salesSlipDisplayList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRecRetGoods);
                    break;
            }
			return salesSlipDisplayList;
		}

		/// <summary>
		/// 商品区分設定リスト作成処理
		/// </summary>
		/// <param name="acptAnOdrStatusState"></param>
		/// <returns></returns>
		private List<SalesSlipInputAcs.SalesGoodsCd> MakeSalesGoodsCdList(SalesSlipInputAcs.AcptAnOdrStatusState acptAnOdrStatusState)
		{
			List<SalesSlipInputAcs.SalesGoodsCd> salesGoodsCdList = new List<SalesSlipInputAcs.SalesGoodsCd>();
			switch (acptAnOdrStatusState)
			{
				case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.Goods);
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.Goods);
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.Goods);
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust);
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust);
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust);
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust);
					break;
				case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
					salesGoodsCdList.Add(SalesSlipInputAcs.SalesGoodsCd.Goods);
					break;
			}
			return salesGoodsCdList;
		}

		/// <summary>
		/// 伝票区分変更処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="isCache"></param>
		private bool ChangeSalesSlip(ref SalesSlip salesSlip, bool isCache)
		{
			bool changeSalesSlipDisplay = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SalesSlipDisplay, ComboEditorGetDataType.TAG);

			if (code == salesSlip.SalesSlipDisplay) return changeSalesSlipDisplay;

			if ((!ChangeCheckSalesSlipDisplay(code, salesSlip)) &&    // 伝票区分変更不可
				(this._salesSlipInputAcs.ExistSalesDetail())) // 明細入力あり
			{
				if (salesSlip.SalesSlipDisplay != code)
				{
					if (code != -1)
					{
						if ((!this.EqualsSalesGoodsCdType(salesSlip.SalesSlipDisplay, code)) && (this._salesSlipInputAcs.ExistSalesDetail()))
						{
							DialogResult dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
								"よろしいですか？",
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button1);

							if (dialogResult == DialogResult.Yes)
							{
								this._salesSlipDetailInput.Clear();
								this._salesSlipInputAcs.ClearCarInfo();
								this.ClearDisplayCarInfo();
								changeSalesSlipDisplay = true;
							}
						}
						else
						{
							this._salesSlipInputAcs.ClearCarInfo();
							this.ClearDisplayCarInfo();
							changeSalesSlipDisplay = true;
						}
					}
				}
			}
			else
			{
				changeSalesSlipDisplay = true;
			}

			if (changeSalesSlipDisplay)
			{

				if (code != -1)
				{
					salesSlip.SalesSlipDisplay = code;

					// 伝票区分、売掛区分のセット
					SalesSlipInputAcs.SetSlipCdAndAccRecDivCdFromDisplay(ref salesSlip);

					// 売上データキャッシュ処理
					if (isCache) this._salesSlipInputAcs.Cache(salesSlip);
				}
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			return changeSalesSlipDisplay;
		}

		/// <summary>
		/// 伝票区分コンボエディタ選択確定後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SalesSlipDisplay_SelectionChangeCommitted(object sender, EventArgs e)
		{
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			// 伝票区分変更処理
			this.ChangeSalesSlip(ref salesSlip, true);

			// 明細グリッドセル設定処理
			this._salesSlipDetailInput.SettingGrid();

			this._salesSlipDetailInput.ActiveCellButtonEnabledControl();

			// ツールバー設定イベント
			this.ToolButtonSettingDetail();
		}

		/// <summary>
		/// 伝票区分変更可能チェック処理
		/// </summary>
		/// <param name="code"></param>
		/// <param name="salesSlip"></param>
		/// <returns></returns>
		private bool ChangeCheckSalesSlipDisplay(int code, SalesSlip salesSlip)
		{

			bool ret = false;

			SalesSlipInputAcs.SalesSlipDisplay salesSlipDisplayBefore = (SalesSlipInputAcs.SalesSlipDisplay)salesSlip.SalesSlipDisplay;
			SalesSlipInputAcs.SalesSlipDisplay salesSlipDisplayAfter = (SalesSlipInputAcs.SalesSlipDisplay)code;

			List<SalesSlipInputAcs.SalesSlipDisplay> salesSlipDisplaySalesList = new List<SalesSlipInputAcs.SalesSlipDisplay>();
			salesSlipDisplaySalesList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRec);
			salesSlipDisplaySalesList.Add(SalesSlipInputAcs.SalesSlipDisplay.Cash);
			List<SalesSlipInputAcs.SalesSlipDisplay> salesSlipDisplayRetGoodsList = new List<SalesSlipInputAcs.SalesSlipDisplay>();
			salesSlipDisplayRetGoodsList.Add(SalesSlipInputAcs.SalesSlipDisplay.AccRecRetGoods);
			salesSlipDisplayRetGoodsList.Add(SalesSlipInputAcs.SalesSlipDisplay.CashRetGoods);

			if ((salesSlipDisplaySalesList.Contains(salesSlipDisplayBefore)) &&
				(salesSlipDisplaySalesList.Contains(salesSlipDisplayAfter)))
			{
				ret = true;
			}

			if ((salesSlipDisplayRetGoodsList.Contains(salesSlipDisplayBefore)) &&
				(salesSlipDisplayRetGoodsList.Contains(salesSlipDisplayAfter)))
			{
				ret = true;
			}

			return ret;

		}

		/// <summary>
		/// 担当者変更処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="salesSlipCurrent"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		private bool ChangeSalesEmployee(ref SalesSlip salesSlip, SalesSlip salesSlipCurrent, string code)
		{
			bool ret = true;
			DialogResult dialogResult;

			if (salesSlipCurrent.SalesEmployeeCd.Trim() != code)
			{
				#region 変更可能チェック
				switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SalesAgentChngDiv)
				{
					// 変更可能
					case 0:
						break;
					// 変更時警告
					case 1:
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"担当者が変更されました。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.No) ret = false;
						break;
					// 変更不可
					case 2:
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"担当者の変更はできません。" + "\r\n",
							0,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						ret = false;
						break;
					default:
						break;
				}
				#endregion

				if (ret == true)
				{
					if (string.IsNullOrEmpty(code))
					{
						this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, code);
					}
					else
					{
						string name = this._salesSlipInputInitDataAcs.GetName_FromEmployee(code);

						if (string.IsNullOrEmpty(name.Trim()))
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"従業員が存在しません。",
								-1,
								MessageBoxButtons.OK);

							ret = false;
						}
						else
						{
							this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, code);
						}
					}
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);
			}

			return ret;

		}

		/// <summary>
		/// 受注者変更処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="salesSlipCurrent"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		private bool ChangeFrontEmployee(ref SalesSlip salesSlip, SalesSlip salesSlipCurrent, string code)
		{
			bool ret = true;

			if (salesSlipCurrent.FrontEmployeeCd.Trim() != code)
			{

				if (string.IsNullOrEmpty(code))
				{
					salesSlip.FrontEmployeeCd = code;
					salesSlip.FrontEmployeeNm = string.Empty;
				}
				else
				{
					string name = this._salesSlipInputInitDataAcs.GetName_FromEmployee(code);

					if (string.IsNullOrEmpty(name.Trim()))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"従業員が存在しません。",
							-1,
							MessageBoxButtons.OK);

						ret = false;
					}
					else
					{
						salesSlip.FrontEmployeeCd = code;
						salesSlip.FrontEmployeeNm = name;
						if (salesSlip.FrontEmployeeNm.Length > 16) salesSlip.FrontEmployeeNm = salesSlip.FrontEmployeeNm.Substring(0, 16);
					}
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);
			}

			return ret;

		}

		/// <summary>
		/// 発行者変更処理
		/// </summary>
		/// <param name="salesSlip"></param>
		/// <param name="salesSlipCurrent"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		/// <br>Update Note: 2010/05/08 王海立 発行者チェック処理の追加</br>
		private bool ChangeSalesInput(ref SalesSlip salesSlip, SalesSlip salesSlipCurrent, string code)
		{
			bool ret = true;

			if (salesSlipCurrent.SalesInputCode.Trim() != code)
			{

				if (string.IsNullOrEmpty(code))
				{
					salesSlip.SalesInputCode = code;
					salesSlip.SalesInputName = string.Empty;
				}
				else
				{
					string name = this._salesSlipInputInitDataAcs.GetName_FromEmployee(code);

					if (string.IsNullOrEmpty(name.Trim()))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"従業員が存在しません。",
							-1,
							MessageBoxButtons.OK);

						ret = false;
					}
					else
					{
						// --- ADD 2010/05/04 ---------->>>>>
						bool isReInputErr = false;
						if (!code.Equals(LoginInfoAcquisition.Employee.EmployeeCode.Trim()))
						{
							// 発行者チェック区分 0:無視 1:再入力 2:警告
							switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpAgentChkDiv)
							{
								case 0:
									break;
								case 1:
									{
										TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"不正な値が存在するため、登録できません。"
										+ "\r\n"
										+ "\r\n"
										+ "発行者とログイン担当者が不一致です。",
										0,
										MessageBoxButtons.OK);

										ret = false;
										isReInputErr = true;

										break;
									}
								case 2:
									{
										TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"発行者とログイン担当者が不一致です。",
										0,
										MessageBoxButtons.OK);

										ret = true;

										break;
									}
							}
						}
						if (!isReInputErr)
						{
							// --- ADD 2010/05/04 ----------<<<<<
							salesSlip.SalesInputCode = code;
							salesSlip.SalesInputName = name;
							if (salesSlip.SalesInputName.Length > 16) salesSlip.SalesInputName = salesSlip.SalesInputName.Substring(0, 16);
							Employee employee = this._salesSlipInputInitDataAcs.GetEmployee(code);
							salesSlip.SalesInpSecCd = employee.BelongSectionCode; // 売上入力拠点コード
						}// ADD 2010/05/04
					}
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);
			}

			return ret;

		}

		#region ●ガイドボタンクリックイベント
		/// <summary>
		/// 売上伝票ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		/// <br>Update Note: 2009/12/23 張凱 PM.NS保守依頼④を追加対応</br>
		/// <br>Update Note: 2010/05/04 王海立 修正呼出時に以下の操作を行った場合は、伝票印刷処理を行わずにデータ更新処理のみ行う</br>
        /// <br>Update Note: K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
		private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
		{
			// 2009/09/10 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
			#region 2009/09/10 DEL
			//MAHNB04110UA salesSlipGuide = new MAHNB04110UA();

			//salesSlipGuide.TComboEditor_SalesFormalCode = true;
			//salesSlipGuide.AutoSearch = true;
			//salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
			//salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
			//salesSlipGuide.AcptAnOdrStatus = this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay;
			//salesSlipGuide.ShowEstimateInput = false;
			//SalesSlipSearchResult searchResult;

			//int acptAnOdrStatusDisplay = (int)this.tComboEditor_AcptAnOdrStatusDisplay.Value;
			//int acptAnOdrStatus = (int)this.tComboEditor_AcptAnOdrStatus.Value;
			//int estimateDivide;
			//SalesSlipInputAcs.GetAcptAnOdrStatusAndEstimateDivideFromDisplay(acptAnOdrStatusDisplay, ref acptAnOdrStatus, out estimateDivide);
			//DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatus, estimateDivide, out searchResult);

			//if (result == DialogResult.OK)
			//{
			//    if (searchResult != null)
			//    {
			//        DialogResult dialogResult = DialogResult.Yes;

			//        if (this._salesSlipInputAcs.IsDataChanged)
			//        {
			//            dialogResult = TMsgDisp.Show(
			//                this,
			//                emErrorLevel.ERR_LEVEL_EXCLAMATION,
			//                this.Name,
			//                "入力中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "情報がクリアされます。" + "\r\n" + "\r\n" +
			//                "よろしいですか？",
			//                0,
			//                MessageBoxButtons.YesNo,
			//                MessageBoxDefaultButton.Button1);
			//        }

			//        if (dialogResult == DialogResult.Yes)
			//        {
			//            this.tEdit_SalesEmployeeCd.Focus();

			//            // 画面初期化処理
			//            this.Clear(false, false);

			//            // データリード処理
			//            this.Cursor = Cursors.WaitCursor;

			//            SalesSlip baseSalesSlip;
			//            int status = this._salesSlipInputAcs.ReadDBData(searchResult.EnterpriseCode, searchResult.AcptAnOdrStatus, searchResult.SalesSlipNum, out baseSalesSlip);
			//            this.Cursor = Cursors.Default;

			//            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			//            {
			//                SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

			//                // 売上データ入力モード設定処理
			//                this.SettingStockSlipInputMode(ref salesSlip);

			//                // 表示用受注ステータスの設定
			//                SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

			//                // 2009.06.18 Add >>>
			//                // 伝票区分コンボエディタアイテム設定処理
			//                this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatus, false);
			//                // 2009.06.18 Add <<<

			//                // 表示用伝票区分の設定
			//                SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

			//                // 売上データクラス→画面格納処理
			//                this.SetDisplay(salesSlip);

			//                // 売上データキャッシュ処理
			//                this._salesSlipInputAcs.Cache(salesSlip);

			//                if (baseSalesSlip.ConsTaxLayMethod != salesSlip.ConsTaxLayMethod)
			//                {
			//                    // 売上金額計算処理
			//                    this._salesSlipDetailInput.CalculationSalesPrice();

			//                    // 売上金額変更後発生イベント処理
			//                    this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
			//                }

			//                // 計上時は空白行を削除する(出荷計上 受注計上 見積計上)
			//                if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
			//                    (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
			//                    (salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
			//                {
			//                    this._salesSlipDetailInput.DeleteEmptyRow(true);
			//                }

			//                // 明細グリッド設定処理
			//                this._salesSlipDetailInput.SettingGrid();

			//                this.SettingVisible();

			//                // ツールバーボタン有効無効設定処理
			//                this.SettingToolBarButtonEnabled();

			//                if (this._salesSlipDetailInput.Enabled)
			//                {
			//                    this._salesSlipDetailInput.Focus();
			//                }
			//                else
			//                {
			//                    this.tEdit_SlipNote.Focus();
			//                }

			//                // フッタタブ位置セット
			//                uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];
			//            }
			//            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			//            {
			//                TMsgDisp.Show(
			//                    this,
			//                    emErrorLevel.ERR_LEVEL_INFO,
			//                    this.Name,
			//                    "該当するデータが存在しません。",
			//                    -1,
			//                    MessageBoxButtons.OK);

			//                return;
			//            }
			//            else
			//            {
			//                TMsgDisp.Show(
			//                    this,
			//                    emErrorLevel.ERR_LEVEL_STOPDISP,
			//                    this.Name,
			//                    "売上・出荷データの取得に失敗しました。",
			//                    status,
			//                    MessageBoxButtons.OK);

			//                return;
			//            }
			//        }
			//    }
			//}
			//this._prevControl = this.ActiveControl;            
			#endregion

			MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
			try
			{
				salesSlipGuide.TComboEditor_SalesFormalCode = true;
				salesSlipGuide.AutoSearch = true;
				salesSlipGuide.SectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
				salesSlipGuide.SectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
				salesSlipGuide.AcptAnOdrStatus = this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay;
				salesSlipGuide.ShowEstimateInput = false;
				SalesSlipSearchResult searchResult;

				int acptAnOdrStatusDisplay = (int)this.tComboEditor_AcptAnOdrStatusDisplay.Value;
				int acptAnOdrStatus = (int)this.tComboEditor_AcptAnOdrStatus.Value;
				int estimateDivide;
				SalesSlipInputAcs.GetAcptAnOdrStatusAndEstimateDivideFromDisplay(acptAnOdrStatusDisplay, ref acptAnOdrStatus, out estimateDivide);
				DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, acptAnOdrStatus, estimateDivide, out searchResult);

				if (result == DialogResult.OK)
				{
					if (searchResult != null)
					{
						DialogResult dialogResult = DialogResult.Yes;

						if (this._salesSlipInputAcs.IsDataChanged)
						{
							dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								"入力中の" + this._salesSlipInputAcs.GetAcptAnOdrStatusName(this._salesSlipInputAcs.SalesSlip) + "情報がクリアされます。" + "\r\n" + "\r\n" +
								"よろしいですか？",
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button1);
						}

						if (dialogResult == DialogResult.Yes)
						{
							this.tEdit_SalesEmployeeCd.Focus();

							// 画面初期化処理
							this.Clear(false, false);

							// データリード処理
							this.Cursor = Cursors.WaitCursor;

							SalesSlip baseSalesSlip;
							int status = this._salesSlipInputAcs.ReadDBData(searchResult.EnterpriseCode, searchResult.AcptAnOdrStatus, searchResult.SalesSlipNum, out baseSalesSlip);
							this.Cursor = Cursors.Default;

							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip.Clone();

								// 売上データ入力モード設定処理
								this.SettingStockSlipInputMode(ref salesSlip);

								// 表示用受注ステータスの設定
								SalesSlipInputAcs.SetDisplayFromAcptAnOdrStatusAndEstimateDivide(ref salesSlip);

								// 2009.06.18 Add >>>
								// 伝票区分コンボエディタアイテム設定処理
								this.SetItemtSalesSlipCd(ref salesSlip, salesSlip.AcptAnOdrStatus, false);
								// 2009.06.18 Add <<<

								// 表示用伝票区分の設定
								SalesSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref salesSlip);

								// 売上データクラス→画面格納処理
								this.SetDisplay(salesSlip);

								// 売上データキャッシュ処理
								this._salesSlipInputAcs.Cache(salesSlip);

								if (baseSalesSlip.ConsTaxLayMethod != salesSlip.ConsTaxLayMethod)
								{
									// 売上金額計算処理
									this._salesSlipDetailInput.CalculationSalesPrice();

									// 売上金額変更後発生イベント処理
									this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
								}

								// 計上時は空白行を削除する(出荷計上 受注計上 見積計上)
								if ((salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
									(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
									(salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp))
								{
									this._salesSlipDetailInput.DeleteEmptyRow(true);
								}

								// 明細グリッド設定処理
								this._salesSlipDetailInput.SettingGrid();

								// 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
								// 明細行数制限
								this._salesSlipInputAcs.SettingSalesDetailRowInputRowCount(salesSlip.DetailRowCountForReadSlip);
								// 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

								this.SettingVisible();

								// ツールバーボタン有効無効設定処理
								this.SettingToolBarButtonEnabled();

								if (this._salesSlipDetailInput.Enabled)
								{
									this._salesSlipDetailInput.Focus();
								}
								else
								{
									// --- UPD 2009/12/23 ---------->>>>>
									//this.tEdit_SlipNote.Focus();
									// --- UPD 2010/02/02 ---------->>>>>
									//this.tNedit_SlipNoteCode.Focus();
									GetFooterFirstControl().Focus();
									// --- UPD 2010/02/02 ----------<<<<<
									// --- UPD 2009/12/23 ----------<<<<<
								}

								// --- ADD 2009/09/08② ---------->>>>>
								this.SettingAddInfoVisible();
								// --- ADD 2009/09/08② ----------<<<<<

								// フッタタブ位置セット
								uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[0];

                                //>>>2010/09/27
                                //// --- ADD 2009/12/23 ---------->>>>>
                                //if (salesSlip.DepositAllowanceTtl != 0)
                                //{
                                //    TMsgDisp.Show(
                                //    this,
                                //    emErrorLevel.ERR_LEVEL_INFO,
                                //    this.Name,
                                //    "入金済み伝票です。" + "\r\n" + "\r\n" +
                                //    "削除する場合は、入金伝票入力より　" + "\r\n" +
                                //    "対象の入金伝票を赤伝処理後、　" + "\r\n" +
                                //    "削除することができます。　",
                                //    -1,
                                //    MessageBoxButtons.OK);
                                //}
                                //// --- ADD 2009/12/23 ----------<<<<<
                                //<<<2010/09/27

								// --- ADD 2009/12/23 ---------->>>>>
								//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
								this._salesSlipInputAcs.GetNoteCharCnt();
								SetNoteCharCnt();
								// --- ADD 2009/12/23 ----------<<<<<

								// --- ADD 2010/05/04 ---------->>>>>
								this._readSlipFlg = true;
								// --- ADD 2010/05/04 ----------<<<<<
							}
							else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
							{
                                // ----- ADD K2011/12/09 --------------------------->>>>>
                                // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
                                //if (this._enterpriseCode == login_EnterpriseCode)
                                if ((this._salesSlipInputInitDataAcs.Opt_DateCtrl == (int)SalesSlipInputInitDataAcs.Option.ON) ||
                                    (this._enterpriseCode == login_EnterpriseCode))
                                // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
                                {
                                    if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return;
                                }
                                // ----- ADD K2011/12/09 ---------------------------<<<<<
                                //if (this._salesSlipInputAcs.SalesSlipCanEditDivCd == false) return; // ADD K2011/08/12 // DEL K2011/12/09
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"該当するデータが存在しません。",
									-1,
									MessageBoxButtons.OK);

								return;
							}
							else
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_STOPDISP,
									this.Name,
									"売上・出荷データの取得に失敗しました。",
									status,
									MessageBoxButtons.OK);

								return;
							}
						}
					}
				}
				this._prevControl = this.ActiveControl;
			}
			finally
			{
				salesSlipGuide.Dispose();
			}
			// 2009/09/10 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
		}

		/// <summary>
		/// 拠点ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SectionGuide_Click(object sender, EventArgs e)
		{
			SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
			SecInfoSet secInfoSet;
			bool reCalcSalesUnitPrice = false;

			int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

				if (salesSlip.ResultsAddUpSecCd.Trim() != secInfoSet.SectionCode.Trim())
				{
					salesSlip.ResultsAddUpSecCd = secInfoSet.SectionCode.Trim();
					salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;

					DialogResult dialogResult = DialogResult.No;

					if ((salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales) &&
						(this._salesSlipInputAcs.ExistSalesDetailCanGoodsPriceReSettingData()))
					{
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"拠点が変更されました。" + "\r\n" + "\r\n" +
							"商品価格を再取得しますか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							reCalcSalesUnitPrice = true;
						}
					}
				}

				//---------------------------------------------------------------
				// 売上単価再計算時
				//---------------------------------------------------------------
				if (reCalcSalesUnitPrice)
				{
					// 消費税再設定
					this._salesSlipInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);

					// 商品情報再取得
					List<List<GoodsUnitData>> goodsUnitDataListList;
					string msg;
					this._salesSlipInputAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(out goodsUnitDataListList, out msg);

					// 商品価格の再設定を行います。
					this._salesSlipInputAcs.SalesDetailRowGoodsPriceReSetting(goodsUnitDataListList);

					// 商品価格の再設定を行います。(受注情報)
					this._salesSlipInputAcs.AcptAnOdrDetailRowGoodsPriceReSetting(goodsUnitDataListList);

					// 売上金額変更後発生イベント処理
					this.SalesSlipDetailInput_SalesPriceChanged(this, new EventArgs());
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);

				// 次の項目へフォーカス移動
				//ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SectionGuide, this.uButton_SectionGuide);
				//this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				//if (changeFocusEventArgs.NextCtrl != null)
				//{
				//    changeFocusEventArgs.NextCtrl.Focus();
				//}

				// NextCtrl制御
				Control nextCtrl = null;
				if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
				{
					nextCtrl = this.uButton_SectionGuide;
				}
				else
				{
					nextCtrl = this.GetNextControl(this.tEdit_SectionCode, SalesSlipInputAcs.MoveMethod.NextMove);
				}
				if (nextCtrl != null) nextCtrl.Focus();
			}
		}

		/// <summary>
		/// 部門ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SubSectionGuide_Click(object sender, EventArgs e)
		{
			SubSectionAcs subSectionAcs = new SubSectionAcs();
			SubSection subSection;

			int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

				if (salesSlip.SubSectionCode != subSection.SubSectionCode)
				{
					salesSlip.SubSectionCode = subSection.SubSectionCode;
					salesSlip.SubSectionName = subSection.SubSectionName;
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);

				// 次の項目へフォーカス移動
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SubSectionGuide, this.uButton_SubSectionGuide);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
		}

		/// <summary>
		/// 従業員ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2010/05/04 王海立 発行者チェック処理の追加</br>
		private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
		{
			EmployeeAcs employeeAcs = new EmployeeAcs();
			employeeAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
			Employee employee;
			int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
			// --- ADD 2010/05/04 ---------->>>>>
			string beforeCode = this.tEdit_SalesInputCode.Text;
			string beforeName = this.uLabel_SalesInputNm.Text;
			// --- ADD 2010/05/04 ----------<<<<< 

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

				// 担当者
				if (sender == uButton_EmployeeGuide)
				{
					this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, employee);
				}
				// 受注者
				else if (sender == uButton_FrontEmployeeGuide)
				{
					salesSlip.FrontEmployeeCd = employee.EmployeeCode.Trim();
					salesSlip.FrontEmployeeNm = employee.Name;
					if (salesSlip.FrontEmployeeCd.Length > 16) salesSlip.FrontEmployeeNm = salesSlip.FrontEmployeeNm.Substring(0, 16);
				}
				// 発行者
				else if (sender == uButton_SalesInputGuide)
				{
					salesSlip.SalesInputCode = employee.EmployeeCode.Trim();
					salesSlip.SalesInputName = employee.Name;
					if (salesSlip.SalesInputName.Length > 16) salesSlip.SalesInputName = salesSlip.SalesInputName.Substring(0, 16);
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);

				// 次の項目へフォーカス移動
				if (sender == uButton_EmployeeGuide)
				{
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_EmployeeGuide, this.uButton_EmployeeGuide);
					this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl != null)
					{
						changeFocusEventArgs.NextCtrl.Focus();
					}
				}
				else if (sender == uButton_FrontEmployeeGuide)
				{
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_FrontEmployeeGuide, this.uButton_FrontEmployeeGuide);
					this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl != null)
					{
						changeFocusEventArgs.NextCtrl.Focus();
					}
				}
				else if (sender == uButton_SalesInputGuide)
				{
					// --- ADD 2010/05/04 ---------->>>>>
					bool isReInputErr = false;
					string code = this.tEdit_SalesInputCode.Text;

					if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(LoginInfoAcquisition.Employee.EmployeeCode))
						return;
					if (!code.Equals(LoginInfoAcquisition.Employee.EmployeeCode.Trim()))
					{
						// 発行者チェック区分 0:無視 1:再入力 2:警告
						switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpAgentChkDiv)
						{
							case 0:
								break;
							case 1:
								{
									TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"不正な値が存在するため、登録できません。"
									+ "\r\n"
									+ "\r\n"
									+ "発行者とログイン担当者が不一致です。",
									0,
									MessageBoxButtons.OK);

									isReInputErr = true;

									break;
								}
							case 2:
								{
									TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									"発行者とログイン担当者が不一致です。",
									0,
									MessageBoxButtons.OK);

									break;
								}
						}
					}

					if (isReInputErr)
					{
						salesSlip.SalesInputCode = beforeCode;
						salesSlip.SalesInputName = beforeName;
						if (salesSlip.SalesInputName.Length > 16) salesSlip.SalesInputName = salesSlip.SalesInputName.Substring(0, 16);

						// 売上データクラス→画面格納処理
						this.SetDisplay(salesSlip);

						// 売上データキャッシュ処理
						this._salesSlipInputAcs.Cache(salesSlip);

						this.tEdit_SalesInputCode.Focus();
					}
					else
					{
						// --- ADD 2010/05/04 ----------<<<<< 
						ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SalesInputGuide, this.uButton_SalesInputGuide);
						this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
						if (changeFocusEventArgs.NextCtrl != null)
						{
							changeFocusEventArgs.NextCtrl.Focus();
						}
					}// ADD 2010/05/04
				}
			}
		}

		/// <summary>
		/// 備考ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <br>Update Note: 2010/02/02 張凱 redmine#2760対応</br>
        /// <br>Update Note: K2011/12/09 鄧潘ハン</br>
        /// <br>管理番号   : 10703874-00</br>
        /// <br>作成内容   : イスコ個別対応</br>
		private void uButton_SlipNote_Click(object sender, EventArgs e)
		{
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
			noteGuidAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
			NoteGuidBd noteGuidBd;
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip; ;
			int status;
            bool errFlag = false; // ADD K2011/08/12 

			// 備考１
			if (sender == uButton_SlipNote)
			{
				status = noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_1);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// --- UPD 2010/02/02 ---------->>>>>
					//salesSlip.SlipNote = noteGuidBd.NoteGuideName;
					if (this._salesSlipInputInitDataAcs.SlipNoteCharCnt != 0
						&& this._salesSlipInputInitDataAcs.SlipNoteCharCnt < noteGuidBd.NoteGuideName.Length)
					{
						salesSlip.SlipNote = noteGuidBd.NoteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNoteCharCnt);
					}
					else
					{
						salesSlip.SlipNote = noteGuidBd.NoteGuideName;
					}
					// --- UPD 2010/02/02 ----------<<<<<
					// --- ADD 2009/12/23 ---------->>>>>
					salesSlip.SlipNoteCode = noteGuidBd.NoteGuideCode;
					// --- ADD 2009/12/23 ----------<<<<<
				}
			}

			// 備考２
			if (sender == uButton_SlipNote2)
			{
				status = noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_2);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// --- UPD 2010/02/02 ---------->>>>>
					//salesSlip.SlipNote2 = noteGuidBd.NoteGuideName;
					if (this._salesSlipInputInitDataAcs.SlipNote2CharCnt != 0
						&& this._salesSlipInputInitDataAcs.SlipNote2CharCnt < noteGuidBd.NoteGuideName.Length)
					{
						salesSlip.SlipNote2 = noteGuidBd.NoteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNote2CharCnt);
					}
					else
					{
						salesSlip.SlipNote2 = noteGuidBd.NoteGuideName;
					}
					// --- UPD 2010/02/02 ----------<<<<<
					// --- ADD 2009/12/23 ---------->>>>>
					salesSlip.SlipNote2Code = noteGuidBd.NoteGuideCode;
					// --- ADD 2009/12/23 ----------<<<<<

                    // ----- ADD K2011/08/12 --------------------------->>>>>
                    // ----- ADD K2011/12/09 --------------------------->>>>>
                    if (this._enterpriseCode == login_EnterpriseCode)
                    {
                    // ----- ADD K2011/12/09 ---------------------------<<<<<
                        if (this._salesSlipInputAcs == null)
                        {
                            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                        }
                        int countNum = 0;
                        string PaperId = this._salesSlipInputAcs.CallGetSlipPrtSetPaperId(salesSlip);
                        if (PaperId == "A995" || PaperId == "A998")
                        {
                            if (string.IsNullOrEmpty(salesSlip.SlipNote2))
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                "ドットを２つ以上入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);
                                errFlag = true;
                            }
                            else
                            {
                                foreach (char car in salesSlip.SlipNote2)
                                {
                                    if (car == '.')
                                    {
                                        ++countNum;
                                    }
                                }
                                if (countNum < 2)
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    "",
                                    "ドットを２つ以上入力して下さい。",
                                    -1,
                                    MessageBoxButtons.OK);
                                    errFlag = true;
                                }
                            }
                        }
                    }
                    // ----- ADD K2011/08/12 ---------------------------<<<<<
				}
			}

			// 備考３
			if (sender == uButton_SlipNote3)
			{
				status = noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SalesSlipInputInitDataAcs.ctDIVCODE_NoteGuideDivCd_3);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// --- UPD 2010/02/02 ---------->>>>>
					//salesSlip.SlipNote3 = noteGuidBd.NoteGuideName;
					if (this._salesSlipInputInitDataAcs.SlipNote3CharCnt != 0
						&& this._salesSlipInputInitDataAcs.SlipNote3CharCnt < noteGuidBd.NoteGuideName.Length)
					{
						salesSlip.SlipNote3 = noteGuidBd.NoteGuideName.Substring(0, this._salesSlipInputInitDataAcs.SlipNote3CharCnt);
					}
					else
					{
						salesSlip.SlipNote3 = noteGuidBd.NoteGuideName;
					}
					// --- UPD 2010/02/02 ----------<<<<<
					// --- ADD 2009/12/23 ---------->>>>>
					salesSlip.SlipNote3Code = noteGuidBd.NoteGuideCode;
					// --- ADD 2009/12/23 ----------<<<<<
				}
			}

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 次の項目へフォーカス移動
			if (sender == uButton_SlipNote)
			{
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SlipNote, this.uButton_SlipNote);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
			if (sender == uButton_SlipNote2)
			{
                // ----- ADD K2011/08/12 --------------------------->>>>>
                // ----- ADD K2011/12/09 --------------------------->>>>>
                if (this._enterpriseCode == login_EnterpriseCode)
                {
                // ----- ADD K2011/12/09 ---------------------------<<<<<
                    if (errFlag)
                    {
                        this.tEdit_SlipNote2.Focus();
                        return;
                    }
                }// ADD K2011/12/09
                // ----- ADD K2011/08/12 ---------------------------<<<<<
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SlipNote2, this.uButton_SlipNote2);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
			if (sender == uButton_SlipNote3)
			{
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SlipNote3, this.uButton_SlipNote3);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}

		}

		/// <summary>
		/// 車輌備考ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note       : 車輌備考ガイド画面を表示します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void uButton_SlipNoteGuide_Click(object sender, EventArgs e)
		{
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
			noteGuidAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
			NoteGuidBd noteGuidBd;
			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip; ;
			int status;

			status = noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SalesSlipInputInitDataAcs.ctDIVCODE_CarNoteGuideDivCd);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				salesSlip.CarSlipNote = noteGuidBd.NoteGuideName;

				int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();
				this._salesSlipInputAcs.SettingCarInfoRowFromCarNote(salesRowNo, salesSlip.CarSlipNote);
				this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
				// 次の項目へフォーカス移動
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SlipNoteGuide, this.uButton_SlipNoteGuide);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
		}

		/// <summary>
		/// 得意先ガイドボタンクリックイベント（オーバーロード）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void uButton_CustomerGuide_Click(object sender, EventArgs e)
		{
			SalesSlip salesSlip = new SalesSlip();
			uButton_CustomerGuide_Click(sender, e, ref salesSlip);
			this.SettingVisible();

			// --- ADD 2009/09/08② ---------->>>>>
			//追加情報タブ項目Visible設定
			SettingAddInfoVisible();
			// --- ADD 2009/09/08② ----------<<<<<

            //>>>2010/02/26
            this._customerCode = salesSlip.CustomerCode;
            //<<<2010/02/26
		}

		/// <summary>
		/// 得意先ガイドボタンクリックイベント（オーバーロード）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <br>Update Note: 2009/09/08② 張凱 車輌管理機能対応</br>
		private void uButton_CustomerGuide_Click(object sender, EventArgs e, ref SalesSlip salesSlip)
		{
			PMKHN04001UA customerSearchForm = new PMKHN04001UA();

			// --- ADD 2009/09/08② ---------->>>>>
			int tempcustomerCode = this.tNedit_CustomerCode.GetInt();
			// --- ADD 2009/09/08② ----------<<<<<

			// 得意先
			if (sender == this.uButton_CustomerGuide)
			{
				customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
				customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
				if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CustGuideDispDiv == 1) // 0:全て表示 1:自拠点のみ表示
				{
					customerSearchForm.MngSectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
					customerSearchForm.MngSectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
				}
				customerSearchForm.AutoSearch = true;

				// 納入先未入力時は得意先情報をセット
				if (this.tNedit_AddresseeCode.GetInt() == 0)
				{
					this.tNedit_AddresseeCode.Value = this.tNedit_CustomerCode.Value;
					customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_AddresseeSelect);
				}
			}
			// 納入先
			if (sender == this.uButton_AddresseeGuide)
			{
				customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_RECEIVER, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
				if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().CustGuideDispDiv == 1) // 0:全て表示 1:自拠点のみ表示
				{
					customerSearchForm.MngSectionCode = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecCd;
					customerSearchForm.MngSectionName = this._salesSlipInputAcs.SalesSlip.ResultsAddUpSecNm;
				}
				customerSearchForm.AutoSearch = true;
				customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_AddresseeSelect);
			}


			DialogResult dialogResult = customerSearchForm.ShowDialog(this);

			if (dialogResult != DialogResult.OK)
			{
				salesSlip = this._salesSlipInputAcs.SalesSlip;

				// 得意先情報設定処理
				this._salesSlipInputAcs.SettingSalesSlipFromCustomer(ref salesSlip, null);

				// 得意先掛率グループ再セット
				this._salesSlipInputAcs.SettingSalesDetailCustRateGrpCode();

				// 売上明細データセッティング処理（課税区分設定）
				this._salesSlipInputAcs.SettingSalesDetailTaxationCode(salesSlip.ConsTaxLayMethod, salesSlip.TotalAmountDispWayCd);
			}
			else
			{
				// --- ADD 2009/09/08② ---------->>>>>
				if (this._salesSlipInputAcs.SalesSlip.CustomerCode != tempcustomerCode)
				{
					// 車輌管理オプション有りの場合
					if (this._salesSlipInputInitDataAcs.Opt_CarMng == (int)SalesSlipInputInitDataAcs.Option.ON)
					{
						//得意先を変更した場合は、管理番号の値をクリアする
						ClearAddCarInfo();
					}

					// --- ADD 2009/12/23 ---------->>>>>
					//伝票備考、伝票備考２、伝票備考３の入力桁数を制御する
					this._salesSlipInputAcs.GetNoteCharCnt();
					SetNoteCharCnt();
					// --- ADD 2009/12/23 ----------<<<<<
				}
				// --- ADD 2009/09/08② ----------<<<<<

				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, (Control)sender, (Control)sender);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
			//salesSlip = this._salesSlipInputAcs.SalesSlip;
		}

		/// <summary>
		/// 管理番号ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 管理番号ガイドボタンをクリックします。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private void uButton_CarMngNoGuide_Click(object sender, EventArgs e)
		{
			CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
			CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

			paramInfo.EnterpriseCode = this._enterpriseCode;

			// ガイドイベントフラグ
			paramInfo.IsGuideClick = true;

			if (tNedit_CustomerCode.GetInt() != 0)
			{
				switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
				{
					case 0: // しない
						break;
					case 1: // 登録(確認)
					case 2: // 登録(自動)
						// 「新規登録」行表示なし
						paramInfo.IsDispNewRow = false;
						// 得意先表示なし
						paramInfo.IsDispCustomerInfo = false;
						//得意先コード絞り込み有り
						paramInfo.IsCheckCustomerCode = true;
						//得意先コード
						paramInfo.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
						// 管理番号絞り込み無し
						paramInfo.IsCheckCarMngCode = false;
						// 車輌管理区分チェック有り
						paramInfo.IsCheckCarMngDivCd = true;
						break;
					case 3: // 登録無
						break;
				}
			}
			else
			{
				// 「新規登録」行表示なし
				paramInfo.IsDispNewRow = false;
				// 得意先表示有り
				paramInfo.IsDispCustomerInfo = true;
				//得意先コード絞り込みなし
				paramInfo.IsCheckCustomerCode = false;
				// 管理番号絞り込み無し
				paramInfo.IsCheckCarMngCode = false;
				// 車輌管理区分チェック有り
				paramInfo.IsCheckCarMngDivCd = true;
			}

			int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

			AfterCarMngNoGuideReturn(status, selectedInfo, 0);

		}

		/// <summary>
		///自動起動で管理番号ガイド表示設定の処理
		/// </summary>
		/// <param name="carMngCode">管理コード</param>
		/// <param name="inputflag">管理番号　0:異なる　1:同じ</param>
		/// <returns>フォーカス　0:次項目　1:型式</returns>
		/// <remarks>
		/// <br>Note       : 自動起動で管理番号ガイド表示を設定処理します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private int SettingCarMngNoGuide(string carMngCode, int inputflag)
		{
			int flag = 0;
			if (!string.IsNullOrEmpty(carMngCode))
			{
				CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
				CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

				paramInfo.EnterpriseCode = this._enterpriseCode;
				// ガイドイベントフラグ
				paramInfo.IsGuideClick = false;
				// 「新規登録」行表示有り
				paramInfo.IsDispNewRow = true;
				// 管理番号絞り込み前方一致
				paramInfo.IsCheckCarMngCode = true;
				// 管理コード
				paramInfo.CarMngCode = carMngCode;
				// 管理コードの前方
				paramInfo.CheckCarMngCodeType = 1;
				// 車輌管理区分チェック有り
				paramInfo.IsCheckCarMngDivCd = true;

				if (tNedit_CustomerCode.GetInt() != 0)
				{
					switch (this._salesSlipInputAcs.SalesSlip.CarMngDivCd)
					{
						case 0: // しない
							break;
						case 1: // 登録(確認)
						case 2: // 登録(自動)
							// 得意先表示なし
							paramInfo.IsDispCustomerInfo = false;
							//得意先コード絞り込み有り
							paramInfo.IsCheckCustomerCode = true;
							//得意先コード
							paramInfo.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
							break;
						case 3: // 登録無
							//得意先コード絞り込み有り
							paramInfo.IsCheckCustomerCode = true;
							//得意先コード
							paramInfo.CustomerCode = this._salesSlipInputAcs.SalesSlip.CustomerCode;
							break;
					}
				}
				else
				{
					// 得意先表示有り
					paramInfo.IsDispCustomerInfo = true;
					//得意先コード絞り込み無し
					paramInfo.IsCheckCustomerCode = false;
				}

				if (this._salesSlipInputAcs.SalesSlip.CustomerCode == 0)
				{
					int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

					flag = AfterCarMngNoGuideReturn(status, selectedInfo, inputflag);
				}
				else
				{
					//車輌管理区分しない
					if (this._salesSlipInputAcs.SalesSlip.CarMngDivCd != 0)
					{
						int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

						flag = AfterCarMngNoGuideReturn(status, selectedInfo, inputflag);
					}
				}
			}
			return flag;
		}

		/// <summary>
		///管理番号ガイド表示後の処理
		/// </summary>
		/// <param name="status">対象オブジェクト</param>
		/// <param name="selectedInfo">イベントパラメータクラス</param>
		/// <param name="inputflag">管理番号　0:異なる　1:同じ</param>
		/// <returns>フォーカス　0:次項目　1:型式 2:管理番号</returns>
		/// <remarks>
		/// <br>Note       : 管理番号ガイド表示後を処理します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009/09/08②</br>
		/// </remarks>
		private int AfterCarMngNoGuideReturn(int status, CarMangInputExtraInfo selectedInfo, int inputflag)
		{
			int flag = 0;

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				//ガイド表示後のフォーカス制御
				if ("新規登録".Equals(selectedInfo.CarMngCode))
				{
					this.tNedit_ModelDesignationNo.Focus();

					flag = 0;
					inputflag = 0;
				}
				else
				{
					//得意先コード
					tNedit_CustomerCode.SetInt(selectedInfo.CustomerCode);

					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tNedit_CustomerCode, this.tNedit_CustomerCode);
					this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);

					// 型式指定番号
					tNedit_ModelDesignationNo.SetInt(selectedInfo.ModelDesignationNo);
					// 類別番号
					tNedit_CategoryNo.SetInt(selectedInfo.CategoryNo);

					SalesSlipHeaderCopyData salesSlipHeaderCopyData = this._salesSlipInputAcs.CacheCarInfo(selectedInfo);

					// 車輌検索
					CopySlipHeaderCarSearch(salesSlipHeaderCopyData);

					//追加情報タブ項目Visible設定
					SettingAddInfoVisible();

					//車種変更ボタンVisible設定
					SettingChangeCarInfoVisible();

					//フル型式固定番号配列があり
                    // --- UPD m.suzuki 2010/05/20 自由検索---------->>>>>
                    //if (salesSlipHeaderCopyData.FullModelFixedNoAry != null &&
                    //    salesSlipHeaderCopyData.FullModelFixedNoAry.Length > 0)
                    if ((salesSlipHeaderCopyData.FullModelFixedNoAry != null &&
                         salesSlipHeaderCopyData.FullModelFixedNoAry.Length > 0) ||
                        (salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry != null &&
                         salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry.Length > 0))
                    // --- UPD m.suzuki 2010/05/20 自由検索----------<<<<<
                    {
						flag = 1;
						if (this.GetNextCtrlAfterCarSearch() != null) this.GetNextCtrlAfterCarSearch().Focus();
					}
					else
					{
						flag = 0;
						inputflag = 1;
						this.tNedit_ModelDesignationNo.Focus();

					}
				}

			}
			else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN && (string.IsNullOrEmpty(selectedInfo.CarMngCode)))
			{
				flag = 0;
			}
			else
			{
				//新規登録
				flag = 2;
			}

			//車輌情報をクリア処理
			if (flag == 0 && inputflag == 0)
			{
				string tempCarMngCode = this.tEdit_CarMngCode.Text;
				this._salesSlipInputAcs.ClearCarInfo();
				this.ClearDisplayCarInfo();
				ClearAddCarInfo();

				//管理番号の値をセットする
				int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();
				this.tEdit_CarMngCode.Text = tempCarMngCode;
				this._salesSlipInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, tempCarMngCode);
			}

			return flag;
		}

		/// <summary>
		/// 車種ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
		{
			ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
			ModelNameU modelNameU;
			int makerCode = this.tNedit_MakerCode.GetInt();
			// -------UPD 2009/12/08------->>>>>
			//int status = modelNameUAcs.ExecuteGuid(makerCode, this._enterpriseCode, out modelNameU);
			int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
				this._enterpriseCode, out modelNameU);
			// -------UPD 2009/12/08------->>>>>

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				int salesRowNo = this._salesSlipDetailInput.GetActiveRowSalesRowNo();
				this._salesSlipInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, modelNameU);
				this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
				this.SetDisplayHeaderFooterInfo(this._salesSlipInputAcs.SalesSlip);

				// 次の項目へフォーカス移動
				ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.uButton_ModelFullGuide);
				this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);
				if (changeFocusEventArgs.NextCtrl != null)
				{
					changeFocusEventArgs.NextCtrl.Focus();
				}
			}
		}

		/// <summary>
		/// 返品理由ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_RetGoodsReason_Click(object sender, EventArgs e)
		{
			UserGuideAcs userGuideAcs = new UserGuideAcs();
			UserGdHd userGdHd;
			UserGdBd userGdBd;

			if (userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, SalesSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_RetGoodsReason) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

				salesSlip.RetGoodsReasonDiv = userGdBd.GuideCode;
				salesSlip.RetGoodsReason = userGdBd.GuideName;
				if (salesSlip.RetGoodsReason.Length > 100)
				{
					salesSlip.RetGoodsReason = salesSlip.RetGoodsReason.Substring(0, 100);
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(salesSlip);

				// 売上データキャッシュ処理
				this._salesSlipInputAcs.Cache(salesSlip);

				// 次の項目へフォーカス移動
				if (sender is Control)
				{
					// 次の項目へフォーカス移動
					Control nextCtrl = this.GetNextControlForFooter(this.tEdit_RetGoodsReason, SalesSlipInputAcs.MoveMethod.NextMove);
					if (nextCtrl != null)
					{
						nextCtrl.Focus();
						this._prevControl = nextCtrl;
						this.SettingGuideButtonToolEnabled(nextCtrl);
					}
				}
			}
		}
		#endregion

		#region ●伝票メモ情報
		/// <summary>
		/// 伝票メモ情報設定処理
		/// </summary>
		private void SetSlipMemo()
		{
			List<string> slipMemoList = new List<string>();
			slipMemoList.Add(tEdit_SlipMemo1.Text);
			slipMemoList.Add(tEdit_SlipMemo2.Text);
			slipMemoList.Add(tEdit_SlipMemo3.Text);

			List<string> insideMemoList = new List<string>();
			insideMemoList.Add(tEdit_InsideMemo1.Text);
			insideMemoList.Add(tEdit_InsideMemo2.Text);
			insideMemoList.Add(tEdit_InsideMemo3.Text);

			this._salesSlipInputAcs.SettingSlipMemo(this._salesSlipDetailInput.GetActiveRowSalesRowNo(), slipMemoList, insideMemoList);
		}

		/// <summary>
		/// 伝票メモ表示処理
		/// </summary>
		/// <param name="stockRow">明細対象行</param>
		private void SlipMemoInfoFormSetting(object sender, int stockRow)
		{
			ComponentBlanketControl.BeginUpdate(this._memoControlList);
			try
			{
                //>>>2010/04/08
                //MemoInputSetting(true);
                if (this._salesSlipInputAcs.SalesSlip.InputMode != SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ReadOnly)
                {
                    MemoInputSetting(true);
                }
                else
                {
                    MemoInputSetting(false);
                }
                //<<<2010/04/08
                SalesInputDataSet.SalesDetailRow salesDetailRow = this._salesSlipInputAcs.GetSalesDetailRow(stockRow);


				if (((!String.IsNullOrEmpty(salesDetailRow.GoodsNo)) || (!String.IsNullOrEmpty(salesDetailRow.GoodsName)))
					&& (salesDetailRow.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_RowDiscount)
					&& (salesDetailRow.EditStatus != SalesSlipInputAcs.ctEDITSTATUS_Annotation))
				{
					this.tEdit_SlipMemo1.Text = salesDetailRow.SlipMemo1;
					this.tEdit_SlipMemo2.Text = salesDetailRow.SlipMemo2;
					this.tEdit_SlipMemo3.Text = salesDetailRow.SlipMemo3;
					this.tEdit_InsideMemo1.Text = salesDetailRow.InsideMemo1;
					this.tEdit_InsideMemo2.Text = salesDetailRow.InsideMemo2;
					this.tEdit_InsideMemo3.Text = salesDetailRow.InsideMemo3;
				}
				else
				{
					MemoInputSetting(false);
				}
			}
			finally
			{
				ComponentBlanketControl.EndUpdate(this._memoControlList);
			}
		}

		/// <summary>
		/// 伝票メモ入力設定
		/// </summary>
		/// <param name="input">入力可否</param>
		private void MemoInputSetting(bool input)
		{
			this.tEdit_InsideMemo1.Enabled = input;
			this.tEdit_InsideMemo2.Enabled = input;
			this.tEdit_InsideMemo3.Enabled = input;
			this.tEdit_SlipMemo1.Enabled = input;
			this.tEdit_SlipMemo2.Enabled = input;
			this.tEdit_SlipMemo3.Enabled = input;
			if (!input) this.ClearMemoInfo();
		}

		/// <summary>
		/// 伝票メモクリア処理
		/// </summary>
		private void ClearMemoInfo()
		{
			this.tEdit_InsideMemo1.Text = string.Empty;
			this.tEdit_InsideMemo2.Text = string.Empty;
			this.tEdit_InsideMemo3.Text = string.Empty;
			this.tEdit_SlipMemo1.Text = string.Empty;
			this.tEdit_SlipMemo2.Text = string.Empty;
			this.tEdit_SlipMemo3.Text = string.Empty;
		}
		#endregion

		//#region ●売仕入同時入力情報
		///// <summary>
		///// 売仕入同時入力情報設定処理
		///// </summary>
		///// <param name="stockRowNo"></param>
		//private void SettingStockTempInfo(object sender, int salesRowNo)
		//{
		//    // 売上情報取得
		//    SalesInputDataSet.SalesDetailRow row = this._salesSlipInputAcs.GetSalesDetailRow(this._salesSlipDetailInput.GetActiveRowSalesRowNo());

		//    // 仕入情報取得
		//    SalesInputDataSet.StockTempRow stockTempRow = null;
		//    if (row != null)
		//    {
		//        if (row.DtlRelationGuid != Guid.Empty) stockTempRow = this._salesSlipInputAcs.StockTempDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

		//        if (stockTempRow != null)
		//        {
		//            //--------------------------------------------
		//            // 仕入情報あり
		//            //--------------------------------------------
		//            if (stockTempRow.SalesSlipDtlNumSync != 0)
		//            {
		//                //--------------------------------------------
		//                // 既存更新
		//                //--------------------------------------------
		//                if ((row.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&       // 受注
		//                    (stockTempRow.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Order) &&    // 発注
		//                    (stockTempRow.StockSlipDtlNumSrc == 0) &&                                                   // 計上元仕入明細通番→未計上
		//                    (stockTempRow.OrderFormIssuedDiv == 0))                                                     // 発注書発行済区分(0:未発行 1:発行済)→未発注
		//                {
		//                    // 受発注入力の場合、修正可能
		//                    //this.panel2.Enabled = true;
		//                    //this.uTab_Stock.Enabled = true;
		//                }
		//                else
		//                {
		//                    //this.panel2.Enabled = false;
		//                    //this.uTab_Stock.Enabled = true;
		//                }
		//            }
		//            else
		//            {
		//                //--------------------------------------------
		//                // 新規作成
		//                //--------------------------------------------
		//                //this.panel2.Enabled = true;
		//                //this.uTab_Stock.Enabled = true;
		//            }
		//        }
		//        else
		//        {
		//            //--------------------------------------------
		//            // 仕入情報なし
		//            //--------------------------------------------
		//            if ((this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
		//                (this._salesSlipInputAcs.SalesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate))
		//            {
		//                // 見積 単価見積の場合、仕入発注情報タブの選択不可
		//                //this.panel2.Enabled = false;
		//                //this.uTab_Stock.Enabled = false;
		//            }
		//            else
		//            {
		//                //this.panel2.Enabled = true;
		//                //this.uTab_Stock.Enabled = true;
		//            }
		//        }

		//        //if (this._salesSlipInputAcs.SalesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_Red) this.uTab_Stock.Enabled = false;

		//        this._salesSlipInputAcs.SettingStockTempInfo(salesRowNo);
		//    }
		//}
		//#endregion

		#region ●車両情報
		/// <summary>
		/// 車両情報設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="salesRowNo"></param>
		/// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
		private void CarInfoFormSetting(object sender, int salesRowNo)
		{

			ComponentBlanketControl.BeginUpdate(this._carControlList);

			try
			{
				SalesInputDataSet.SalesDetailRow salesDetailRow = this._salesSlipInputAcs.GetSalesDetailRow(salesRowNo);

				SalesInputDataSet.CarInfoRow carInfoRow = this._salesSlipInputAcs.GetCarInfoRow(salesRowNo, SalesSlipInputAcs.GetCarInfoMode.CarInfoChangeMode);
				if (this._salesSlipInputAcs.SalesSlip.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.Goods)
				{
					if (carInfoRow != null)
					{
						this.SetDisplayCarInfo(carInfoRow, CarSearchType.csNone);
					}

					// 車両情報
					double acceptAnOrderNo = (double)this.tNedit_AcceptAnOrderNo.GetValue();
					if (acceptAnOrderNo != 0)
					{
						// --- UPD 2009/10/19 ---------->>>>>
						//this.panel_CarInfo.Enabled = false; // 2009/09/10 DEL
						//this.panel_CarInfo.Enabled = true;
						this.tEdit_ProduceFrameNo.Enabled = false;
						this.tDateEdit_FirstEntryDate.Enabled = false;
						this.uButton_ChangeSearchCarMode.Enabled = false;
						this.panel_CarMngNo.Enabled = false;
						this.uLabel_FirstEntryDateRange.Enabled = false;
						this.tEdit_FullModel.Enabled = false;
						this.tEdit_EngineModelNm.Enabled = false;
						this.tNedit_CategoryNo.Enabled = false;
						this.tNedit_ModelDesignationNo.Enabled = false;
						this.uLabel_EngineModelNm.Enabled = false;
						this.tNedit_ModelSubCode.Enabled = false;
						this.tNedit_ModelCode.Enabled = false;
						this.tNedit_MakerCode.Enabled = false;
						this.tEdit_TrimNo.Enabled = false;
						this.tEdit_ColorNo.Enabled = false;
						this.tEdit_ModelFullName.Enabled = false;
						this.uButton_ModelFullGuide.Enabled = false;
						// --- UPD 2009/10/19 ----------<<<<<
						this._carOtherInfoInput.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // 2009/09/10 ADD
					}
					else
					{
						// --- UPD 2009/10/19 ---------->>>>>
						//this.panel_CarInfo.Enabled = true;
						this.tEdit_ProduceFrameNo.Enabled = true;
						this.tDateEdit_FirstEntryDate.Enabled = true;
						this.uButton_ChangeSearchCarMode.Enabled = true;
						this.panel_CarMngNo.Enabled = true;
						this.uLabel_FirstEntryDateRange.Enabled = true;
						this.tEdit_FullModel.Enabled = true;
						this.tEdit_EngineModelNm.Enabled = true;
						this.tNedit_CategoryNo.Enabled = true;
						this.tNedit_ModelDesignationNo.Enabled = true;
						this.uLabel_EngineModelNm.Enabled = true;
						this.tNedit_ModelSubCode.Enabled = true;
						this.tNedit_ModelCode.Enabled = true;
						this.tNedit_MakerCode.Enabled = true;
						this.tEdit_TrimNo.Enabled = true;
						this.tEdit_ColorNo.Enabled = true;
						this.tEdit_ModelFullName.Enabled = true;
						this.uButton_ModelFullGuide.Enabled = true;
						// --- UPD 2009/10/19 ----------<<<<<
						this._carOtherInfoInput.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 2009/09/10 ADD
					}


					// カラー・トリム・装備情報
					if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
						 (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
						((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
						 (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
						((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
						 (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
					{
						this.uExpandableGroupBox_CarInfo.Enabled = true;
					}
					else
					{
						this.uExpandableGroupBox_CarInfo.Enabled = false;
						this.uExpandableGroupBox_CarInfo.Expanded = false;
					}

				}
			}
			finally
			{
				ComponentBlanketControl.EndUpdate(this._carControlList);
			}
		}
		#endregion

		#region ●カラー情報
		/// <summary>
		/// カラー情報設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="colorCode"></param>
		private void SettingColorInfo(object sender, string colorCode)
		{
			this.tEdit_ColorNo.Text = colorCode;
		}
		#endregion

		#region ●トリム情報
		/// <summary>
		/// トリム情報設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="trimCode"></param>
		private void SettingTrimInfo(object sender, string trimCode)
		{
			this.tEdit_TrimNo.Text = trimCode;
		}
		#endregion

		/// <summary>
		/// クローズタイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Close_Tick(object sender, EventArgs e)
		{
			this.timer_Close.Enabled = false;
			this.Close();
		}

		/// <summary>
		/// 請求先確認ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_CustomerClaimConfirmation_Click(object sender, EventArgs e)
		{

			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			SalesSlip salesSlipCurrent = this._salesSlipInputAcs.SalesSlip.Clone();

			if (salesSlip.CustomerCode == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"得意先が入力されていません。",
					-1,
					MessageBoxButtons.OK);
				this.tNedit_CustomerCode.Focus();
				return;
			}
			if (tDateEdit_SalesDate.GetDateTime() == DateTime.MinValue)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"売上日が入力されていません。",
					-1,
					MessageBoxButtons.OK);
				this.tDateEdit_SalesDate.Focus();
				return;
			}

			DCKOU01050UA CustomerClaimConfirmation = new DCKOU01050UA();
			CustomerClaimConfirmation.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;

			// ウインドウ起動
			CustomerClaimConfirmation.ShowDialog(this, salesSlip.ClaimCode, salesSlip.DemandAddUpSecCd, tDateEdit_SalesDate.GetDateTime(), salesSlip.AddUpADate, salesSlip.DelayPaymentDiv, CustomerClaimConfAcs.GuideType.Claim);

			salesSlip.ClaimCode = CustomerClaimConfirmation.CustomerClaimConf.CustomerCode;                     // 請求先コード
			salesSlip.AddUpADate = CustomerClaimConfirmation.CustomerClaimConf.AddUpADate;                      // 計上日
			salesSlip.ClaimSnm = CustomerClaimConfirmation.CustomerClaimConf.CustomerSnm;                       // 略称
			salesSlip.TotalAmountDispWayCd = CustomerClaimConfirmation.CustomerClaimConf.TotalAmountDispWayCd;  // 総額表示方法区分
			salesSlip.ConsTaxLayMethod = CustomerClaimConfirmation.CustomerClaimConf.ConsTaxLayMethod;          // 消費税転嫁方式
			salesSlip.DemandAddUpSecCd = CustomerClaimConfirmation.CustomerClaimConf.AddUpSectionCode;          // 実績計上拠点
			salesSlip.DelayPaymentDiv = CustomerClaimConfirmation.CustomerClaimConf.CollectMoneyCode;           // 来勘区分
			salesSlip.ClaimName = CustomerClaimConfirmation.CustomerClaimConf.Name;                             // 名称１
			salesSlip.ClaimName2 = CustomerClaimConfirmation.CustomerClaimConf.Name2;                           // 名称２
			salesSlip.CreditMngCode = CustomerClaimConfirmation.CustomerClaimConf.CreditMngCode;                // 与信管理区分
			salesSlip.TotalDay = CustomerClaimConfirmation.CustomerClaimConf.TotalDay;				            // 締日
			salesSlip.NTimeCalcStDate = CustomerClaimConfirmation.CustomerClaimConf.NTimeCalcStDate;	        // 次回勘定開始日

			// 売上データキャッシュ処理

			this._salesSlipInputAcs.Cache(salesSlip);

		}

		/// <summary>
		/// 納入先確認ボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_AddresseeConfirmation_Click(object sender, EventArgs e)
		{

			SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;

			if (salesSlip.AddresseeCode == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"納入先が入力されていません。",
					-1,
					MessageBoxButtons.OK);

				return;
			}

			DCHNB01050UA AddresseeConfirmation = new DCHNB01050UA();
			AddresseeConfirmation.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;
			Addressee addressee = new Addressee();
			addressee.AddresseeCode = salesSlip.AddresseeCode;
			addressee.AddresseeName = salesSlip.AddresseeName;
			addressee.AddresseeName2 = salesSlip.AddresseeName2;
			addressee.AddresseeAddr1 = salesSlip.AddresseeAddr1;
			addressee.AddresseeAddr3 = salesSlip.AddresseeAddr3;
			addressee.AddresseeAddr4 = salesSlip.AddresseeAddr4;
			addressee.AddresseeTelNo = salesSlip.AddresseeTelNo;
			addressee.AddresseePostNo = salesSlip.AddresseePostNo;

			// ウインドウ起動
			AddresseeConfirmation.ShowDialog(this, addressee, salesSlip.AddresseeCode, salesSlip.CustomerCode, salesSlip.ClaimCode, AddresseeConfirmation.GuideMode);

			// 名称、アドレス、区分変更
			salesSlip.AddresseeName = AddresseeConfirmation.Addressee.AddresseeName;
			salesSlip.AddresseeName2 = AddresseeConfirmation.Addressee.AddresseeName2;
			salesSlip.AddresseeAddr1 = AddresseeConfirmation.Addressee.AddresseeAddr1;
			salesSlip.AddresseeAddr3 = AddresseeConfirmation.Addressee.AddresseeAddr3;
			salesSlip.AddresseeAddr4 = AddresseeConfirmation.Addressee.AddresseeAddr4;
			salesSlip.SlipAddressDiv = AddresseeConfirmation.Addressee.SlipAddressDiv;

			// 売上データキャッシュ処理
			this._salesSlipInputAcs.Cache(salesSlip);

			// 売上データクラス→画面格納処理
			this.SetDisplay(salesSlip);

		}

		/// <summary>
		/// フォーカス移動Dictionary設定処理
		/// </summary>
		private void SettingFocusDictionary()
		{
			HeaderFocusConstructionList headerFocusConstructionList = this._salesInputConstructionAcs.HeaderFocusConstructionListValue;

			// --- ADD 2009/12/23 ---------->>>>>
			int controlIndexForword = 0;
			int controlIndexBack = 99;
			this._controlIndexForwordDictionary.Clear();
			this._controlIndexBackDictionary.Clear();
			// --- ADD 2009/12/23 ----------<<<<<

			if ((headerFocusConstructionList.headerFocusConstruction != null) &&
				(headerFocusConstructionList.headerFocusConstruction.Count != 0))
			{

				Dictionary<string, Control> tempDic = new Dictionary<string, Control>();
				foreach (string key in this._headerItemsDictionary.Keys)
				{
					bool flg = false;
					foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
					{
						if (headerFocusConstruction.Caption == key)
						{
							flg = true;
							break;
						}
					}
					if (flg != true) tempDic.Add(key, this._headerItemsDictionary[key]);
				}

				if (tempDic.Count != 0)
				{
					foreach (string key in tempDic.Keys)
					{
						HeaderFocusConstruction tempHeaderFocusConstruction = new HeaderFocusConstruction();
						tempHeaderFocusConstruction.Caption = key;
						tempHeaderFocusConstruction.EnterStop = true;
						tempHeaderFocusConstruction.Key = tempDic[key].Name;
						headerFocusConstructionList.headerFocusConstruction.Add(tempHeaderFocusConstruction);
					}
				}
				this._salesInputConstructionAcs.HeaderFocusConstructionListValue = headerFocusConstructionList;

				// --- DEL 2009/12/23 ---------->>>>>
				//int controlIndexForword = 0;
				//int controlIndexBack = 99;
				//this._controlIndexForwordDictionary.Clear();
				//this._controlIndexBackDictionary.Clear();
				// --- DEL 2009/12/23 ----------<<<<<

				List<HeaderFocusConstruction> tempHeaderFocusConstructionList = new List<HeaderFocusConstruction>();

				foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
				{
					if (this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption) == true)
					{
						Control control = this._headerItemsDictionary[headerFocusConstruction.Caption];
						if (headerFocusConstruction.EnterStop == true)
						{
							this._controlIndexForwordDictionary.Add(control.Name, controlIndexForword++);
							this._controlIndexBackDictionary.Add(control.Name, controlIndexBack--);
						}
					}
					else
					{
						tempHeaderFocusConstructionList.Add(headerFocusConstruction);
					}
				}

				List<HeaderFocusConstruction> cloneHeaderFocusConstructionList = new List<HeaderFocusConstruction>();
				cloneHeaderFocusConstructionList.AddRange(headerFocusConstructionList.headerFocusConstruction);
				if (tempHeaderFocusConstructionList.Count != 0)
				{
					foreach (HeaderFocusConstruction tempHeaderFocusConstruction in tempHeaderFocusConstructionList)
					{
						foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
						{
							if ((tempHeaderFocusConstruction.Key == headerFocusConstruction.Key) &&
								(tempHeaderFocusConstruction.Caption == headerFocusConstruction.Caption))
							{
								cloneHeaderFocusConstructionList.Remove(tempHeaderFocusConstruction);
								break;
							}
						}
					}
				}
				this._salesInputConstructionAcs.HeaderFocusConstructionListValue.headerFocusConstruction = cloneHeaderFocusConstructionList;

			}

			// --- ADD 2009/12/23 ---------->>>>>
			FooterFocusConstructionList footerFocusConstructionList = this._salesInputConstructionAcs.FooterFocusConstructionListValue;

			if ((footerFocusConstructionList.footerFocusConstruction != null) &&
				(footerFocusConstructionList.footerFocusConstruction.Count != 0))
			{

				Dictionary<string, Control> tempDicFooter = new Dictionary<string, Control>();
				foreach (string key in this._footerItemsDictionary.Keys)
				{
					bool flg = false;
					foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
					{
						if (footerFocusConstruction.Caption == key)
						{
							flg = true;
							break;
						}
					}
					if (flg != true) tempDicFooter.Add(key, this._footerItemsDictionary[key]);
				}

				if (tempDicFooter.Count != 0)
				{
					foreach (string key in tempDicFooter.Keys)
					{
						FooterFocusConstruction tempFooterFocusConstruction = new FooterFocusConstruction();
						tempFooterFocusConstruction.Caption = key;
						tempFooterFocusConstruction.EnterStop = true;
						tempFooterFocusConstruction.Key = tempDicFooter[key].Name;
						footerFocusConstructionList.footerFocusConstruction.Add(tempFooterFocusConstruction);
					}
				}
				this._salesInputConstructionAcs.FooterFocusConstructionListValue = footerFocusConstructionList;

				List<FooterFocusConstruction> tempFooterFocusConstructionList = new List<FooterFocusConstruction>();

				foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
				{
					if (this._footerItemsDictionary.ContainsKey(footerFocusConstruction.Caption) == true)
					{
						Control control = this._footerItemsDictionary[footerFocusConstruction.Caption];
						if (footerFocusConstruction.EnterStop == true)
						{
							this._controlIndexForwordDictionary.Add(control.Name, controlIndexForword++);
							this._controlIndexBackDictionary.Add(control.Name, controlIndexBack--);
						}
					}
					else
					{
						tempFooterFocusConstructionList.Add(footerFocusConstruction);
					}
				}

				List<FooterFocusConstruction> cloneFooterFocusConstructionList = new List<FooterFocusConstruction>();
				cloneFooterFocusConstructionList.AddRange(footerFocusConstructionList.footerFocusConstruction);
				if (tempFooterFocusConstructionList.Count != 0)
				{
					foreach (FooterFocusConstruction tempFooterFocusConstruction in tempFooterFocusConstructionList)
					{
						foreach (FooterFocusConstruction footerFocusConstruction in footerFocusConstructionList.footerFocusConstruction)
						{
							if ((tempFooterFocusConstruction.Key == footerFocusConstruction.Key) &&
								(tempFooterFocusConstruction.Caption == footerFocusConstruction.Caption))
							{
								cloneFooterFocusConstructionList.Remove(tempFooterFocusConstruction);
								break;
							}
						}
					}
				}
				this._salesInputConstructionAcs.FooterFocusConstructionListValue.footerFocusConstruction = cloneFooterFocusConstructionList;

			}
			// --- ADD 2009/12/23 ----------<<<<<

		}

		/// <summary>
		/// 操作権限の制御を開始します。
		/// </summary>
		private void BeginControllingByOperationAuthority()
		{
			// 伝票修正ボタン
			if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.Revision))
			{
				this._readSlipButton.SharedProps.Visible = false;
				this._readSlipButton.SharedProps.Shortcut = Shortcut.None;
			}

			// 伝票削除ボタン
			if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.Delete))
			{
				this._deleteSlipButton.SharedProps.Visible = false;
				this._deleteSlipButton.SharedProps.Shortcut = Shortcut.None;
			}

			// 赤伝ボタン
			if (MyOpeCtrl.Disabled((int)SalesSlipInputAcs.OperationCode.RedSlip))
			{
				this._redSlipButton.SharedProps.Visible = false;
				this._redSlipButton.SharedProps.Shortcut = Shortcut.None;
			}
		}

		/// <summary>
		/// タブ変更後イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Footer_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (this.TabChanged != null)
			{
				this.timer_FooterSetFocus.Enabled = true;
			}
		}

		/// <summary>
		/// フッタータブフォーカスセットタイマー起動イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_FooterSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_FooterSetFocus.Enabled = false;
			this.TabChanged(sender, this.uTabControl_Footer.SelectedTab.Key);
		}

		/// <summary>
		/// tNedit_ModelDesignationNo_ValueChangedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_ModelDesignationNo_ValueChanged(object sender, EventArgs e)
		{
			string modelDesignationNo = this.tNedit_ModelDesignationNo.Text;

			if (this.ActiveControl != this._salesSlipDetailInput)
			{
				if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
				{
					this.tNedit_CategoryNo.Focus();
				}
			}
		}

		/// <summary>
		/// uButton_ChangeSearchCarMode_Clickイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_ChangeSearchCarMode_Click(object sender, EventArgs e)
		{
			this.ChangeSearchCarMode();
		}

		/// <summary>
		/// ultraExpandableGroupBox1_ExpandedStateChangingイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExpandableGroupBox1_ExpandedStateChanging(object sender, CancelEventArgs e)
		{
			if (uExpandableGroupBox_CarInfo.Expanded == true)
			{
				panel_CarInfo.Height = 152;
			}
			else
			{
				panel_CarInfo.Height = 409;
			}
		}
		# endregion

		#region 諸元情報グリッド関係
		/// <summary>
		/// グリッド初期設定イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid_CarSpec_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			this.InitialSettingGridCol();
		}

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void InitialSettingGridCol()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
			if (editBand == null) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;

				if ((col.Key == this._carSpecDataTable.AddiCarSpec1Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.AddiCarSpec2Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.AddiCarSpec3Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.AddiCarSpec4Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.AddiCarSpec5Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.AddiCarSpec6Column.ColumnName) ||
					(col.Key == this._carSpecDataTable.BodyNameColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.DoorCountColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.EDivNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.EngineModelNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.ModelGradeNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.ShiftNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.TransmissionNmColumn.ColumnName) ||
					(col.Key == this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName))
				{
					col.Hidden = false;
				}
			}

			//---------------------------------------------------------------------
			// 入力許可設定
			//---------------------------------------------------------------------
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			//---------------------------------------------------------------------
			// フォーマット設定
			//---------------------------------------------------------------------
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].Format = "#0;'';''";
		}

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void SettingCarSpecGridCol(SalesInputDataSet.CarInfoRow carInfoRow)
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
			if (editBand == null) return;

			//this.ultraGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;

			if (carInfoRow != null)
			{
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle1)) ? true : false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle2)) ? true : false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle3)) ? true : false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle4)) ? true : false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle5)) ? true : false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle6)) ? true : false;

				this._carSpecDataTable.AddiCarSpec1Column.Caption = carInfoRow.AddiCarSpecTitle1;
				this._carSpecDataTable.AddiCarSpec2Column.Caption = carInfoRow.AddiCarSpecTitle2;
				this._carSpecDataTable.AddiCarSpec3Column.Caption = carInfoRow.AddiCarSpecTitle3;
				this._carSpecDataTable.AddiCarSpec4Column.Caption = carInfoRow.AddiCarSpecTitle4;
				this._carSpecDataTable.AddiCarSpec5Column.Caption = carInfoRow.AddiCarSpecTitle5;
				this._carSpecDataTable.AddiCarSpec6Column.Caption = carInfoRow.AddiCarSpecTitle6;
			}
			else
			{
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = false;
				this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = false;

				this._carSpecDataTable.AddiCarSpec1Column.Caption = string.Empty;
				this._carSpecDataTable.AddiCarSpec2Column.Caption = string.Empty;
				this._carSpecDataTable.AddiCarSpec3Column.Caption = string.Empty;
				this._carSpecDataTable.AddiCarSpec4Column.Caption = string.Empty;
				this._carSpecDataTable.AddiCarSpec5Column.Caption = string.Empty;
				this._carSpecDataTable.AddiCarSpec6Column.Caption = string.Empty;
			}

			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ModelGradeNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].MaxLength = this._carSpecDataTable.BodyNameColumn.MaxLength;
			//this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].MaxLength          = this._carSpecDataTable.DoorCountColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineModelNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineDisplaceNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EDivNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].MaxLength = this._carSpecDataTable.TransmissionNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].MaxLength = this._carSpecDataTable.WheelDriveMethodNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ShiftNmColumn.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec1Column.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec2Column.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec3Column.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec4Column.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec5Column.MaxLength;
			this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec6Column.MaxLength;
		}

		/// <summary>
		/// ultraGrid_CarSpec_KeyDownイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid_CarSpec_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.ultraGrid_CarSpec.BeginUpdate();

				//-----------------------------------------------------------------------------
				// ActivCell判定
				//-----------------------------------------------------------------------------
				if (this.ultraGrid_CarSpec.ActiveCell != null)
				{
					Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.ultraGrid_CarSpec.ActiveCell;

					switch (e.KeyCode)
					{
						//-----------------------------------------------------------------------------
						// UP
						//-----------------------------------------------------------------------------
						case Keys.Up:
							this.tEdit_FullModel.Focus(); // 型式へ移動
							e.Handled = true;
							break;
						//-----------------------------------------------------------------------------
						// DOWN
						//-----------------------------------------------------------------------------
						case Keys.Down:
							this._salesSlipDetailInput.uGrid_Details.Focus(); // 売上明細へ移動
							e.Handled = true;
							break;
					}
				}
			}
			finally
			{
				this.ultraGrid_CarSpec.EndUpdate();
			}
		}

		/// <summary>
		/// 諸元情報テーブルクリア処理
		/// </summary>
		private void ClearCarSpecDataTable()
		{
			this._carSpecDataTable[0].AddiCarSpec1 = string.Empty;
			this._carSpecDataTable[0].AddiCarSpec2 = string.Empty;
			this._carSpecDataTable[0].AddiCarSpec3 = string.Empty;
			this._carSpecDataTable[0].AddiCarSpec4 = string.Empty;
			this._carSpecDataTable[0].AddiCarSpec5 = string.Empty;
			this._carSpecDataTable[0].AddiCarSpec6 = string.Empty;
			this._carSpecDataTable[0].BodyName = string.Empty;
			this._carSpecDataTable[0].DoorCount = 0;
			this._carSpecDataTable[0].EDivNm = string.Empty;
			this._carSpecDataTable[0].EngineDisplaceNm = string.Empty;
			this._carSpecDataTable[0].EngineModelNm = string.Empty;
			this._carSpecDataTable[0].ModelGradeNm = string.Empty;
			this._carSpecDataTable[0].ShiftNm = string.Empty;
			this._carSpecDataTable[0].TransmissionNm = string.Empty;
			this._carSpecDataTable[0].WheelDriveMethodNm = string.Empty;
		}

		/// <summary>
		/// ultraGrid_CarSpec_Leaveイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid_CarSpec_Leave(object sender, EventArgs e)
		{
			if (this.ultraGrid_CarSpec.ActiveCell != null)
			{
				this.ultraGrid_CarSpec.Rows[this.ultraGrid_CarSpec.ActiveCell.Row.Index].Cells[this.ultraGrid_CarSpec.ActiveCell.Column.Key].Selected = false;
				this.ultraGrid_CarSpec.ActiveCell = null;
			}
			if (this.ultraGrid_CarSpec.ActiveRow != null)
			{
				this.ultraGrid_CarSpec.ActiveRow.Selected = false;
				this.ultraGrid_CarSpec.ActiveRow = null;
			}
		}
		#endregion

		/// <summary>
		/// 終了ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_Cancel_Click(object sender, EventArgs e)
		{
			// ボタンは隠れてます
			DialogResult dResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"終了してもよろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button1);

			if (dResult == DialogResult.Yes)
			{
				this.Close(true);
			}
		}

		/// <summary>
		/// tEdit_SalesEmployeeCd_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_SalesEmployeeCd_AfterExitEditMode(object sender, EventArgs e)
		{
			//// ゼロ詰めコード取得
			//string code = this.tEdit_SalesEmployeeCd.Text.Trim();
			//code = this.uiSetControl1.GetZeroPaddedText(tEdit_SalesEmployeeCd.Name, code);

			//// コード設定
			//SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			//this._salesSlipInputAcs.SettingSalesSlipFromEmployeeInfo(ref salesSlip, code);

			//// 売上データクラス→画面格納処理
			//this.SetDisplay(salesSlip);
		}

		/// <summary>
		/// tEdit_FrontEmployeeCd_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_FrontEmployeeCd_AfterExitEditMode(object sender, EventArgs e)
		{
			//string code = this.tEdit_FrontEmployeeCd.Text.Trim();
			//code = this.uiSetControl1.GetZeroPaddedText(tEdit_SalesEmployeeCd.Name, code);
			//string name = this._salesSlipInputInitDataAcs.GetName_FromEmployee(code);

			//// コード設定
			//SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			//salesSlip.FrontEmployeeCd = code;
			//salesSlip.FrontEmployeeNm = name;
			//if (salesSlip.FrontEmployeeNm.Length > 16) salesSlip.FrontEmployeeNm = salesSlip.FrontEmployeeNm.Substring(0, 16);

			//// 売上データキャッシュ処理
			//this._salesSlipInputAcs.CacheForChange(salesSlip);

			//// 売上データクラス→画面格納処理
			//this.SetDisplay(salesSlip);
		}

		/// <summary>
		/// tEdit_SalesInputCode_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_SalesInputCode_AfterExitEditMode(object sender, EventArgs e)
		{
			//string code = this.tEdit_SalesInputCode.Text.Trim();
			//code = this.uiSetControl1.GetZeroPaddedText(tEdit_SalesEmployeeCd.Name, code);
			//string name = string.Empty;
			//SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			//Employee employee = this._salesSlipInputInitDataAcs.GetEmployee(code);
			//if (employee != null)
			//{
			//    name = employee.Name;
			//    salesSlip.SalesInpSecCd = employee.BelongSectionCode; // 売上入力拠点コード
			//}

			//// コード設定
			//salesSlip.SalesInputCode = code;
			//salesSlip.SalesInputName = name;
			//if (salesSlip.SalesInputName.Length > 16) salesSlip.SalesInputName = salesSlip.SalesInputName.Substring(0, 16);

			//// 売上データキャッシュ処理
			//this._salesSlipInputAcs.CacheForChange(salesSlip);

			//// 売上データクラス→画面格納処理
			//this.SetDisplay(salesSlip);
		}

		/// <summary>
		/// tEdit_SectionCode_AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tEdit_SectionCode_AfterExitEditMode(object sender, EventArgs e)
		{
			//string code = this.tEdit_SectionCode.Text.Trim();
			//code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);
			//SalesSlip salesSlip = this._salesSlipInputAcs.SalesSlip;
			//SecInfoSet secInfoSet = this._salesSlipInputInitDataAcs.GetSecInfo(code);
			//if (secInfoSet != null)
			//{
			//    salesSlip.ResultsAddUpSecCd = code;
			//    salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;
			//}
			//else
			//{
			//    salesSlip.ResultsAddUpSecCd = string.Empty;
			//    salesSlip.ResultsAddUpSecNm = string.Empty;
			//}

			//// 売上データキャッシュ処理
			//this._salesSlipInputAcs.CacheForChange(salesSlip);

			//// 売上データクラス→画面格納処理
			//this.SetDisplay(salesSlip);
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
		# region [車輌情報保持用]
		/// <summary>
		/// 車輌情報保持用
		/// </summary>
		private struct BeforeCarSearchBuffer
		{
			/// <summary>車台番号</summary>
			private string _produceFrameNo;
			/// <summary>生産年式</summary>
			private int _firstEntryDate;
			/// <summary>カラーコード</summary>
			private string _colorNo;
			/// <summary>トリムコード</summary>
			private string _trimNo;
			/// <summary>
			/// 車台番号
			/// </summary>
			public string ProduceFrameNo
			{
				get { return _produceFrameNo; }
				set { _produceFrameNo = value; }
			}
			/// <summary>
			/// 生産年式
			/// </summary>
			public int FirstEntryDate
			{
				get { return _firstEntryDate; }
				set { _firstEntryDate = value; }
			}
			/// <summary>
			/// カラーコード
			/// </summary>
			public string ColorNo
			{
				get { return _colorNo; }
				set { _colorNo = value; }
			}
			/// <summary>
			/// トリムコード
			/// </summary>
			public string TrimNo
			{
				get { return _trimNo; }
				set { _trimNo = value; }
			}
			/// <summary>
			/// 初期化
			/// </summary>
			public void Clear()
			{
				_produceFrameNo = string.Empty;
				_firstEntryDate = 0;
				_colorNo = string.Empty;
				_trimNo = string.Empty;
			}
		}
		# endregion
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

		// --- ADD 2009/12/23 ---------->>>>>
		/// <summary>
		/// 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理
		/// </summary>
		private void SetNoteCharCnt()
		{
			if (this._salesSlipInputInitDataAcs.SlipNoteCharCnt == 0)
			{
				tEdit_SlipNote.ExtEdit.Column = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote");
			}
			else
			{
				tEdit_SlipNote.ExtEdit.Column = this._salesSlipInputInitDataAcs.SlipNoteCharCnt;
			}

			if (this._salesSlipInputInitDataAcs.SlipNote2CharCnt == 0)
			{
				tEdit_SlipNote2.ExtEdit.Column = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote2");
			}
			else
			{
				tEdit_SlipNote2.ExtEdit.Column = this._salesSlipInputInitDataAcs.SlipNote2CharCnt;
			}

			if (this._salesSlipInputInitDataAcs.SlipNote3CharCnt == 0)
			{
				tEdit_SlipNote3.ExtEdit.Column = uiSetControl1.GetSettingColumnCount("tEdit_SlipNote3");
			}
			else
			{
				tEdit_SlipNote3.ExtEdit.Column = this._salesSlipInputInitDataAcs.SlipNote3CharCnt;
			}
		}
		// --- ADD 2009/12/23 ----------<<<<<

        //>>>2010/02/26
        /// <summary>
        /// 得意先情報表示
        /// </summary>
        /// <returns></returns>
        public bool LinkCommunicationTool()
        {
            bool isConfirm = false;
            if (_salesInputConstructionAcs.ScmValue == 0) // 0:展開確認画面表示しない 1:展開確認画面表示する
            {
                isConfirm = false;
            }
            else
            {
                isConfirm = true;
            }

            return this.LinkCommunicationToolProc(isConfirm);
        }

        /// <summary>
        /// 得意先情報表示
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        private bool LinkCommunicationToolProc(bool isConfirm)
        {
            bool ret = false;

            bool read = false;
            if (isConfirm)
            {
                this.Activate();
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "コミュニケーションツールの接続がありました。" + Environment.NewLine +
                    "得意先情報を読み込んでもよろしいですか？" + Environment.NewLine,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {
                    read = true;
                }
            }
            else
            {
                read = true;
            }
            if (read)
            {
                ret = true;
                if (!isConfirm)
                {
                    this.Clear(false, false, false, false, true, false, this._customerCode);
                }
                else
                {
                    this.Clear(false, true, false, false, true, false, this._customerCode);
                    this.timer_InitialSetFocus.Enabled = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// SCM情報読込処理
        /// </summary>
        /// <returns></returns>
        public bool InputInquiryNumber()
        {
            bool isConfirm = false;
            if (_salesInputConstructionAcs.ScmValue == 0) // 0:展開確認画面表示しない 1:展開確認画面表示する
            {
                isConfirm = false;
            }
            else
            {
                isConfirm = true;
            }

            return this.InputInquiryNumberProc(isConfirm);
        }

        /// <summary>
        /// SCM情報読込処理
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        private bool InputInquiryNumberProc(bool isConfirm)
        {
            bool ret = false;

            bool read = false;
            if (isConfirm)
            {
                string inqString = string.Empty;
                if (this._inqOrdDivCd == 1)
                {
                    inqString = "問合せ";
                }
                else
                {
                    inqString = "発注";
                }

                this.Activate();

                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    inqString + "があります。" + Environment.NewLine +
                    inqString + "情報を読み込んでもよろしいですか？" + Environment.NewLine,
                    0,
                    MessageBoxButtons.OKCancel,
                    MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.OK)
                {
                    read = true;
                }
            }
            else
            {
                read = true;
            }

            if (read)
            {
                ret = true;

                if ((this._scmInquiryNumber != 0) ||
                    ((this._scmSalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum) &&
                     (this._scmSalesSlipNum != string.Empty) &&
                     (this._scmSalesSlipNum != null)))
                {
                    //this.SCMRead(this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOrdDivCd);
                    // 2011/02/18 >>>
                    //this.SCMRead(this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOrdDivCd, this._answerDivCd);
                    this.SCMRead(this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOrdDivCd, this._cancelDiv);//@@@@20230303
                    // 2011/02/18 <<<
                }
            }

            return ret;
        }
        //<<<2010/02/26
	}
}