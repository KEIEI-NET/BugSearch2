//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形データメンテナンス
// プログラム概要   : 手形データの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 修 正 日  2010/05/16  修正内容 : 障害対応 redmine#7606：入金伝票入力で入力した金額を手形情報ウィンドでも表示する障害を修正
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 修 正 日  2010/06/28  修正内容 : 障害対応 redmine#10551：手形データメンテナンス　各種仕様変更／障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/10/18  修正内容 : 障害対応 受取手形検索処理の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/10/24  修正内容 : 障害対応 受取手形引当時に支払手形情報をクリア
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/10/29  修正内容 : 障害対応 受取手形引当時の処理日・取引先はクリアしない
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2012/02/15  修正内容 : 障害対応
//                         ①画面レイアウト変更(銀行・振出日の位置を#34123修正前に戻す)
//                           ※手形の重複チェックは手形番号の入力時と新規登録時に行う
//                         ②同一手形選択画面の戻るボタンCaption変更（戻す→戻る）
//                         ③削除済手形存在時のメッセージを修正（削除られています→削除されています）
//                         ④支払手形番号確定時の確認メッセージ修正
//                         ⑤同一手形番号選択画面で引当済/論理削除手形の選択時に確認メッセージを表示
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2013/02/22  修正内容 : 障害対応
//                         ①同一手形番号選択画面で選択後の編集確認メッセージで「はい」を選択した場合のみ
//                           選択手形を手形データパラメータに格納する
//                         ②入力から起動の確定時に既存データの存在チェックを行う
//                           （入金入力から起動時は登録済受取手形の確定不可）
//                         ③支払手形番号確定後(入力から起動)、フォーカスを手形種別に移動
//                         ④入力から起動の確定時に既存データが存在しない場合(新規登録を行う)は
//                           手形データパラメータをクリアする
//                           ※既存データ無しで更新日時が更新対象データに入っている場合、排他となるため
//                         ⑤確定時の既存手形の引当確認で「はい」を選択した場合に該当する手形データを
//                           手形データパラメータに格納する
//                         ⑥手形つき伝票修正の手形画面にて変更なしで確定した場合は既存チェックを行わない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本
// 修 正 日  2013/03/04  修正内容 : 検索処理の分岐判定を修正
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君
// 修 正 日  2013/04/02  修正内容 : 2013/05/15配信分 Redmine #35247
//                                  仕入総括オプションの調査
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 手形データマスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形データメンテナンスのフォームクラスです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.22</br>
	/// <br>UpdateNote : 2010.05.16 姜凱 redmine#7606の対応</br>
    /// <br>UpdateNote : 2010.05.19 葛軍 redmine#7892の対応</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// <br>UpdateNote : 2013/04/02 王君</br>
    /// <br>管理番号   : 10901273-00 2013/05/15配信分 </br>
    /// <br>           : Redmine #35247 仕入総括オプションの調査</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTEG09101UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 手形データメンテナンスフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形データメンテナンスのコンストラクタです。</br>      
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>UpdateNote : 2013/04/02 王君</br>
        /// <br>管理番号   : 10901273-00 2013/05/15配信分</br>
        /// <br>           : redmine #35247 仕入総括オプションの調査</br>
        /// </remarks>
        public PMTEG09101UA(object draftDataParam)
        {
            // 入力画面からの起動区分
            this._startType = START_TYPE_CALL;

            // パラメータとして、手形データパラメータを取得
            if (draftDataParam is RcvDraftData)
            {
                this._rcvDraftData = (RcvDraftData)draftDataParam;
                this._rcvDraftData.SectionCode = this._rcvDraftData.SectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                this._rcvDraftDataOrg = _rcvDraftData.Clone();
                this._rcvDraftDataClear = this._rcvDraftData.Clone();
                // 手形区分
                _draftMode = DRAFT_DIV_RCV;
                // 受取手形データアクセスクラス
                _rcvDraftDataAcs = new RcvDraftDataAcs();
                // 手形番号　一応保存
                if (this._rcvDraftData.RcvDraftNo != "")
                    this._draftNo = this._rcvDraftData.RcvDraftNo;
            }
            else
            {
                this._payDraftData = (PayDraftData)draftDataParam;
                this._payDraftData.SectionCode = this._payDraftData.SectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                this._payDraftDataOrg = _payDraftData.Clone();
                this._payDraftDataClear = this._payDraftData.Clone();
                // 手形区分
                _draftMode = DRAFT_DIV_PAY;
                // 支払手形データアクセスクラス
                _payDraftDataAcs = new PayDraftDataAcs();
                // 手形番号　一応保存
                if (this._payDraftData.PayDraftNo != "")
                    this._draftNo = this._payDraftData.PayDraftNo;
                // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                // 支払手形情報(金額・期日チェック用)
                this._payDraftDataInfo = this._payDraftData.Clone();
                // 受取手形データアクセスクラス
                this._rcvDraftDataAcs = new RcvDraftDataAcs();
                // --- ADD 2012/10/18 --------------------------------------------------<<<<<
            }

            // 初期化処理
            this.InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ログイン拠点(自拠点)
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 拠点情報アクセスクラス
            this._secInfoAcs = new SecInfoAcs();
            // 拠点アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 仕入先アクセスクラス
            this._supplierAcs = new SupplierAcs();
            // 得意先アクセスクラス
            this._customerInfoAcs = new CustomerInfoAcs();
            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();

            CacheOptionInfo(); // ADD 王君 2013/04/02 Redmine#35247
        }
        /// <summary>
        /// 手形データメンテナンスフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形データメンテナンスのコンストラクタです。</br>      
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public PMTEG09101UA()
        {
            // 初期化処理
            this.InitializeComponent();

            // 直接的にからの起動区分
            this._startType = START_TYPE_DIRECT;

            // 手形区分
            this._draftMode = DRAFT_DIV_RCV;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ログイン拠点(自拠点)
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 拠点情報アクセスクラス
            this._secInfoAcs = new SecInfoAcs();
            // 拠点アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 仕入先アクセスクラス
            this._supplierAcs = new SupplierAcs();
            // 得意先アクセスクラス
            this._customerInfoAcs = new CustomerInfoAcs();
            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();
            // 受取手形データアクセスクラス
            this._rcvDraftDataAcs = new RcvDraftDataAcs();
            // 受取手形データ
            this._rcvDraftData = new RcvDraftData();
            this._rcvDraftDataClear = this._rcvDraftData.Clone();
            // 支払手形データアクセスクラス
            this._payDraftDataAcs = new PayDraftDataAcs();
            // 支払手形データ
            this._payDraftData = new PayDraftData();
            this._payDraftDataClear = this._payDraftData.Clone();

        }
        # endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        # region Private Constant

        // ツールバーツールキー設定
        // 閉じる
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // 保存
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        // クリア
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // 復活
        private const string TOOLBAR_REVIVAL_KEY = "ButtonTool_Revival";
        // 削除
        private const string TOOLBAR_LOGICALDELETE_KEY = "ButtonTool_LogicalDelete";
        // 完全削除
        private const string TOOLBAR_DELETE_KEY = "ButtonTool_Delete";
        //ログイン拠点
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LableTool_LoginSection";
        private const string TOOLBAR_LOGINSECTIONLABEL_TITLE = "LableTool_LoginSectionTitle";
        //ログイン担当者
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        // プログラムID
        private const string PGID = "PMTEG09101U";

        // 手形区分
        private const string DRAFT_DIV_NAME_RCV = "受取手形";
        private const string DRAFT_DIV_NAME_PAY = "支払手形";

        // プログラム起動方式
        // 直接起動
        private const int START_TYPE_DIRECT = 0;
        // 入力から起動
        private const int START_TYPE_CALL = 1;
        // 手形種別
        private const string DRAFT_KIND_HAND = "手持手形";
        private const string DRAFT_KIND_GET = "取立手形";
        private const string DRAFT_KIND_DISC = "割引手形";
        private const string DRAFT_KIND_TRANS = "譲渡手形";
        private const string DRAFT_KIND_MORTGAGE = "担保手形";
        private const string DRAFT_KIND_DISHONOR = "不渡手形";
        private const string DRAFT_KIND_PAY = "支払手形";
        private const string DRAFT_KIND_POST = "先付手形";
        private const string DRAFT_KIND_SETTLE = "決済手形";

        // 自他振区分
        private const string TRANS_SELF = "自振";
        private const string TRANS_OTHER = "他振";

        //　処理モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        // 手形区分 0:自振
        private const int DRAFT_DIV_PAY = 0;
        // 手形区分 1:他振
        private const int DRAFT_DIV_RCV = 1;
        // モード区分 0:新規
        private const int MODE_TYPE_INSERT = 0;
        // モード区分 1:更新
        private const int MODE_TYPE_UPDATE = 1;
        // モード区分 2:削除
        private const int MODE_TYPE_DELETE = 2;
        // 論理削除区分 0:有効
        private const int DEL_CD_USE = 0;
        // 論理削除区分 1:論理削除
        private const int DEL_CD_LOG_DEL = 1;
        // 論理削除区分 3:完全削除
        private const int DEL_CD_DEL = 3;
        #endregion

        # region Private Members
        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;
        // 手形区分
        private int _draftMode;
        // モードタイプ
        private int _modeType;
        // 保存フラグ
        private bool _saveFlg = false;
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        // 受取手形検索フラグ
        private bool _rcvDraftFlg;
        private bool _rcvDraftFlgOrg;
        // 支払手形情報(金額・期日チェック用)
        private PayDraftData _payDraftDataInfo = null;
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<
        // 閉じるフラグ
        private bool _closingFlg = false;
        // 初期化フラグ
        private bool _initFlg = false;
        // 手形番号
        private string _draftNo;
        // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
        //銀行の前回値
        private string _bankCdBefore = string.Empty;
        //支店の前回値
        private string _branchCdBefore = string.Empty;
        // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
        // 受取手形データ
        private RcvDraftData _rcvDraftData = null;
        private RcvDraftData _rcvDraftDataOrg = null;
        private RcvDraftData _rcvDraftDataClear = null;

        // 支払手形データ
        private PayDraftData _payDraftData = null;
        private PayDraftData _payDraftDataOrg = null;
        private PayDraftData _payDraftDataClear = null;

        //拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;

        // 起動区分
        private int _startType;
        private ImageList _imageList16 = null;											// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _logicDeleteButton;		// 論理削除
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;				// 削除
        private Infragistics.Win.UltraWinToolbars.ButtonTool _revivalButton;			// 復活
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionLabel;			// ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ログイン担当者名称

        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先アクセスクラス
        private SecInfoAcs _secInfoAcs = null;              // 拠点情報アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private RcvDraftDataAcs _rcvDraftDataAcs = null;    // 受取手形データアクセスクラス
        private PayDraftDataAcs _payDraftDataAcs = null;	// 支払手形データアクセスクラス

        // 支払情報検索クラス
        private PaymentSlpSearch _paymentSlpSearch;
        // 入金伝票入力画面(入金型)アクセスクラス
        private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>複数手形選択画面クラス</summary>
        private PMTEG09101UC _selectForm;
        //手形保存前のチェックフラグ
        private bool _chkflg = false;
        //選択「いいえ」フラグ
        private bool _clickflg = false;
        // 全条件検索フラグ
        private bool _secondsearchflg = false;
        // 支払
        private bool _payflag = false;
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

        // ----- ADD 王君 2013/04/02 Redmine#35247 ----- >>>>>
        // 仕入総括オプションフラグ
        private bool _supplierSummary;
        // ----- ADD 王君 2013/04/02 Redmine#35247 ----- <<<<<

        # endregion

        #region プロパティ
        /// public propaty name  :  SaveFlg
        /// <summary>保存フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   保存フラグプロパティ</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public bool SaveFlg
        {
            get { return _saveFlg; }
            set { _saveFlg = value; }
        }
        /// public propaty name  :  RcvDraftFlg
        /// <summary>受取手形検索フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note       : 受取手形検索フラグプロパティ</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        public bool RcvDraftFlg
        {
            get { return _rcvDraftFlg; }
            set { _rcvDraftFlg = value; }
        }
        /// public propaty name  :  PayDraftData
        /// <summary>支払手形データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払手形データプロパティ</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public PayDraftData PayDraftData
        {
            get { return _payDraftData; }
            set { _payDraftData = value; }
        }
        /// public propaty name  :  RcvDraftData
        /// <summary>受取手形データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受取手形データプロパティ</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public RcvDraftData RcvDraftData
        {
            get { return _rcvDraftData; }
            set { _rcvDraftData = value; }
        }
        #endregion

        # region 画面初期化
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // ツールバー初期設定処理
            this.ToolBarInitilSetting();

            // ボタンアイコン設定
            this.SetGuidButtonIcon();
           
            // ツールボタンEnable設定処理
            if (this._startType == START_TYPE_DIRECT)
            {
                //新規モード
                this.SetControlEnabled(INSERT_MODE);
                this._modeType = MODE_TYPE_INSERT;
            }
            else
            {
                // モードラベルを非表示にする
                this.Mode_Label.Visible = false;

                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    if (this._rcvDraftData.RcvDraftNo != "")
                    {
                        // 更新モード             
                        this.SetControlEnabled(UPDATE_MODE);
                        this._modeType = MODE_TYPE_UPDATE;  
                    }
                    else
                    {
                        //新規モード
                        this.SetControlEnabled(INSERT_MODE);
                        this._modeType = MODE_TYPE_INSERT;
                    }
                }
                else
                {
                    if (this._payDraftData.PayDraftNo != "")
                    {
                        // 更新モード             
                        this.SetControlEnabled(UPDATE_MODE);
                        this._modeType = MODE_TYPE_UPDATE;         
                    }
                    else
                    {
                        //新規モード
                        this.SetControlEnabled(INSERT_MODE);
                        this._modeType = MODE_TYPE_INSERT;
                    }
                }
            }
            // 初期画面データ設定
            this.InitialScreenData();
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // 終了のアイコン設定
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // 保存のアイコン設定
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                if (this._startType == START_TYPE_CALL)
                {
                    this._saveButton.SharedProps.Caption = "確定(&S)";
                    this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DECISION];
                }
                else
                    this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }



            // クリアのアイコン設定
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            if (this._clearButton != null)
            {
                this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ALLCANCEL];
            }

            // 論理削除
            this._logicDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGICALDELETE_KEY];
            {
                this._logicDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // 削除
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_DELETE_KEY];
            {
                this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.DELETE];
            }

            // 復活
            this._revivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_REVIVAL_KEY];
            {
                this._revivalButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.UNDO];
            }

            // ログイン拠点のアイコン設定
            this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABEL_TITLE];
            if (this._loginSectionTitleLabel != null)
            {
                this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ログイン担当者のアイコン設定
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ログイン拠点名
            this._loginSectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            if (this._loginSectionLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._loginSectionLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }

            // ログイン担当者名
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }

        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustSecCdGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BankBranchGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.DraftGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; //ADD 2012/10/18
        }

        /// <summary>
        /// 初期画面データ設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // 手形区分
            this.tComboEditor_DraftDiv.Items.Clear();
            this.tComboEditor_DraftDiv.Items.Add("0", DRAFT_DIV_NAME_RCV);
            this.tComboEditor_DraftDiv.Items.Add("1", DRAFT_DIV_NAME_PAY);

            // 手形種別
            this.tComboEditor_DraftKind.Clear();
            this.tComboEditor_DraftKind.Items.Add("0", DRAFT_KIND_HAND);
            this.tComboEditor_DraftKind.Items.Add("1", DRAFT_KIND_GET);
            this.tComboEditor_DraftKind.Items.Add("2", DRAFT_KIND_DISC);
            this.tComboEditor_DraftKind.Items.Add("3", DRAFT_KIND_TRANS);
            this.tComboEditor_DraftKind.Items.Add("4", DRAFT_KIND_MORTGAGE);
            this.tComboEditor_DraftKind.Items.Add("5", DRAFT_KIND_DISHONOR);
            this.tComboEditor_DraftKind.Items.Add("6", DRAFT_KIND_PAY);
            this.tComboEditor_DraftKind.Items.Add("7", DRAFT_KIND_POST);
            this.tComboEditor_DraftKind.Items.Add("9", DRAFT_KIND_SETTLE);

            // 自他振区分
            this.tComboEditor_SelfOtherTransDiv.Clear();
            this.tComboEditor_SelfOtherTransDiv.Items.Add("0", TRANS_SELF);
            this.tComboEditor_SelfOtherTransDiv.Items.Add("1", TRANS_OTHER);
        }


        # endregion 画面初期化

        /// <summary>
        /// 画面データ表示処理
        /// </summary>
        /// <param name="draftDivChanged">手形区分変更から判断用</param>
        /// <remarks>
        /// <br>Note       : 画面データ表示処理を行う。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
		/// <br>UpdateNote  : 2010.05.16 姜凱 redmine#7606の対応</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// <br>UpdateNote : 2013/04/02 王君</br>
        /// <br>管理番号   : 10901273-00 2013/05/15配信分</br>
        /// <br>           : redmine #35247  仕入総括オプションの調査</br>
        /// </remarks>
        private void SetDataDisp(bool draftDivChanged)
        {
            // 新規モードの場合
            if (this._modeType == MODE_TYPE_INSERT)
            {
                // 直接起動
                if (this._startType == START_TYPE_DIRECT)
                {
                    if (!draftDivChanged)
                    {
                        // 手形区分
                        this.tComboEditor_DraftDiv.Value = "0";
                    }
                    // 自他振区分
                    this.tComboEditor_SelfOtherTransDiv.Value = "1";
                    // 手形種別
                    this.tComboEditor_DraftKind.Value = "0";
                    // 振出日
                    this.tDateEdit_DrawingDate.Clear();
                    // 期日
                    this.tDateEdit_ValidityData.Clear();
                    // 処理日
                    this.tDateEdit_ProcDate.SetDateTime(DateTime.Now);
                    // 取引先拠点コード
                    this.tNedit_CustSecCd.Clear();
                    // 取引先得意先/仕入先コード
                    this.tNedit_CustCd.Clear();
                    // 取引先得意先/仕入先名称
                    this.CustName_Label.Text = "";
                    // サイト
                    this.tNedit_Site.SetInt(0);
					// --- ADD 2010/05/16 -------------->>>>>
					// 金額
					this.tNedit_Amounts.SetInt(0);
					// --- ADD 2010/05/16 --------------<<<<<
                }
                // 間接起動
                else
                {
                    // 支払手形
                    if (this._draftMode == DRAFT_DIV_PAY)
                    {
                        // 手形区分
                        this.tComboEditor_DraftDiv.Value = "1";
                        // 自他振区分
                        this.tComboEditor_SelfOtherTransDiv.Value = this._payDraftData.DraftDivide.ToString();
                        // 振出日
                        this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                        // 期日
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._payDraftData.ValidityTerm));
                        // 手形種別
                        this.tComboEditor_DraftKind.Value = this._payDraftData.DraftKindCd.ToString();
                        // 処理日
                        this.tDateEdit_ProcDate.SetDateTime(this.ChangeDateTime(this._payDraftData.ProcDate));
                        // 取引先拠点コード
                        this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                        // 取引先得意先/仕入先コード
                        this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                        // 取引先得意先/仕入先名称
                        this.CustName_Label.Text = this._payDraftData.SupplierSnm;
						// --- ADD 2010/05/16 -------------->>>>>
						//　金額
						this.tNedit_Amounts.SetValue(this._payDraftData.Payment);
						// --- ADD 2010/05/16 --------------<<<<<
                        // ----- ADD 王君 2013/04/02 Redmine#35247 ----->>>>>
                        // ログイン拠点
                        this.tNedit_Section.Value = this._payDraftData.SectionCode.Trim();
                        // ログイン拠点名
                        SecInfoSet secInfoSet = new SecInfoSet();
                        this._secInfoAcs.GetSecInfo(this._payDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                        if (secInfoSet != null)
                        {
                            this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                        }
                        // ----- ADD 王君 2013/04/02 Redmine#35247 -----<<<<<
                    }
                    // 受取手形
                    else
                    {
                        // 手形区分
                        this.tComboEditor_DraftDiv.Value = "0";
                        // 自他振区分
                        this.tComboEditor_SelfOtherTransDiv.Value = this._rcvDraftData.DraftDivide.ToString();
                        // 振出日
                        this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                        // 期日
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ValidityTerm));
                        // 手形種別
                        this.tComboEditor_DraftKind.Value = this._rcvDraftData.DraftKindCd.ToString();
                        // 処理日
                        this.tDateEdit_ProcDate.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ProcDate));
                        // 取引先拠点コード
                        this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                        // 取引先得意先/仕入先コード
                        this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                        // 取引先得意先/仕入先名称
                        this.CustName_Label.Text = this._rcvDraftData.CustomerSnm;
						// --- ADD 2010/05/16 -------------->>>>>
						//　金額
						this.tNedit_Amounts.SetValue(this._rcvDraftData.Deposit);
						// --- ADD 2010/05/16 --------------<<<<<
                        // ----- ADD 王君 2013/04/02 Redmine#35247 ----->>>>>
                        // ログイン拠点
                        this.tNedit_Section.Value = this._loginSectionCode.Trim();
                        // ログイン拠点名
                        this.SectionName_Label.Text = this._loginSectionLabel.SharedProps.Caption;
                        // ----- ADD 王君 2013/04/02 Redmine#35247 -----<<<<<
                    }
                    // サイト
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                }
                // 手形番号
                this.tNedit_DraftNo.Value = "";
                // ログイン拠点
                //this.tNedit_Section.Value = this._loginSectionCode;// DEL zhuhh 2013/01/10 for Redmine #34123
                //this.tNedit_Section.Value = this._loginSectionCode.Trim();// ADD zhuhh 2013/01/10 for Redmine #34123 //DEL 王君 2013/04/02 Redmine#35247
                // ログイン拠点名
                //this.SectionName_Label.Text = this._loginSectionLabel.SharedProps.Caption;//DEL 王君 2013/04/02 Redmine#35247
				// --- DEL 2010/05/16 -------------->>>>>
				//// 金額
				//this.tNedit_Amounts.SetInt(0);
				// --- DEL 2010/05/16 --------------<<<<<
                // 銀行コード
                this.tNedit_BankCd.Value = "";
                // 支店コード
                this.tNedit_BranchCd.Value = "";
                // 銀行名称
                this.BankName_Label.Text = "";
                // 摘要１
                this.tEdit_Outline1.Value = "";
                // 摘要２
                this.tEdit_Outline2.Value = "";

            }
            // 修正、削除モードの場合
            else
            {
                // 支払手形
                if (this._draftMode == DRAFT_DIV_PAY && this._payDraftData != null)
                {
                    // 支払手形
                    this.tComboEditor_DraftDiv.Value = "1";
                    // 手形番号
                    this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                    // ログイン拠点
                    this.tNedit_Section.Value = this._payDraftData.SectionCode;
                    // ログイン拠点名
                    SecInfoSet secInfoSet = new SecInfoSet();
                    this._secInfoAcs.GetSecInfo(this._payDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                    if (secInfoSet != null)
                    {
                        this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    }
                    // 手形種別
                    this.tComboEditor_DraftKind.Value = this._payDraftData.DraftKindCd.ToString();
                    // 自他振区分
                    this.tComboEditor_SelfOtherTransDiv.Value = this._payDraftData.DraftDivide.ToString();
                    // 振出日
                    this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                    // 期日
                    this.tDateEdit_ValidityData.SetLongDate(this._payDraftData.ValidityTerm);
                    // 処理日
                    this.tDateEdit_ProcDate.SetLongDate(this._payDraftData.ProcDate);
                    // サイト
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                    //　金額
                    this.tNedit_Amounts.SetValue(this._payDraftData.Payment);
                    // 取引先拠点コード
                    this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                    // 取引先得意先/仕入先コード
                    this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                    // 取引先得意先/仕入先名称
                    this.CustName_Label.Text = this._payDraftData.SupplierSnm;
                    // 銀行コード
                    this.tNedit_BankCd.SetInt(this._payDraftData.BankAndBranchCd / 1000);
                    // 支店コード
                    this.tNedit_BranchCd.SetInt(this._payDraftData.BankAndBranchCd % 1000);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    if (this._payDraftData.BankAndBranchCd == 0)
                    {
                        // 銀行コード
                        this.tNedit_BankCd.Value = "";
                        // 支店コード
                        this.tNedit_BranchCd.Value = "";
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // 銀行名称
                    this.BankName_Label.Text = this._payDraftData.BankAndBranchNm;
                    // 摘要１
                    this.tEdit_Outline1.Value = this._payDraftData.Outline1;
                    // 摘要２
                    this.tEdit_Outline2.Value = this._payDraftData.Outline2;
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    // 手形引当
                    RcvDraft_Label.Visible = this._rcvDraftFlg;
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                }
                // 受取手形
                else if (this._draftMode == DRAFT_DIV_RCV && this._rcvDraftData != null)
                {
                    // 受取手形
                    this.tComboEditor_DraftDiv.Value = "0";
                    // 手形番号
                    this.tNedit_DraftNo.Value = this._rcvDraftData.RcvDraftNo;
                    // ログイン拠点
                    this.tNedit_Section.Value = this._rcvDraftData.SectionCode;
                    // ログイン拠点名
                    SecInfoSet secInfoSet = new SecInfoSet();
                    this._secInfoAcs.GetSecInfo(this._rcvDraftData.SectionCode.PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                    if (secInfoSet != null)
                    {
                        this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    }
                    // 手形種別
                    this.tComboEditor_DraftKind.Value = this._rcvDraftData.DraftKindCd.ToString();
                    // 自他振区分
                    this.tComboEditor_SelfOtherTransDiv.Value = this._rcvDraftData.DraftDivide.ToString();
                    // 振出日
                    this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                    // 期日
                    this.tDateEdit_ValidityData.SetLongDate(this._rcvDraftData.ValidityTerm);
                    // 処理日
                    this.tDateEdit_ProcDate.SetLongDate(this._rcvDraftData.ProcDate);
                    // サイト
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.Value = timeSpan.Days.ToString();
                    //　金額
                    this.tNedit_Amounts.SetValue(this._rcvDraftData.Deposit);
                    // 取引先拠点コード
                    this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                    // 取引先得意先/仕入先コード
                    this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                    // 取引先得意先/仕入先名称
                    this.CustName_Label.Text = this._rcvDraftData.CustomerSnm;
                    // 銀行コード
                    this.tNedit_BankCd.SetInt(this._rcvDraftData.BankAndBranchCd / 1000);
                    // 支店コード
                    this.tNedit_BranchCd.SetInt(this._rcvDraftData.BankAndBranchCd % 1000);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    if (this._rcvDraftData.BankAndBranchCd == 0)
                    {
                        // 銀行コード
                        this.tNedit_BankCd.Value = "";
                        // 支店コード
                        this.tNedit_BranchCd.Value = "";
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // 銀行名称
                    this.BankName_Label.Text = this._rcvDraftData.BankAndBranchNm;
                    // 摘要１
                    this.tEdit_Outline1.Value = this._rcvDraftData.Outline1;
                    // 摘要２
                    this.tEdit_Outline2.Value = this._rcvDraftData.Outline2;

                }
            }
            // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
            if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
            {
                this._draftMode = DRAFT_DIV_RCV;
            }
            else
            {
                this._draftMode = DRAFT_DIV_PAY;
            }
            // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // 新規
                case INSERT_MODE:
                    {
                        // 手形区分
                        if (this._startType == START_TYPE_DIRECT)
                        {

                            // 仕入支払管理オプションが成立している場合
                            if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment) == PurchaseStatus.Contract ||
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment) == PurchaseStatus.Trial_Contract)
                            {
                                tComboEditor_DraftDiv.Enabled = true;
                            }
                            else
                            {
                                tComboEditor_DraftDiv.Enabled = false;
                            }
                        }
                        else
                        {
                            tComboEditor_DraftDiv.Enabled = false;
                        }
                        // 手形番号
                        tNedit_DraftNo.Enabled = true;
                        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                        // 手形ガイドボタン
                        if (this._startType != START_TYPE_DIRECT &&
                            this._draftMode == DRAFT_DIV_PAY)
                        {
                            DraftGuide_Button.Visible = true;
                        }
                        else
                        {
                            DraftGuide_Button.Visible = false;
                        }
                        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // 拠点
                            tNedit_Section.Enabled = true;
                            // 拠点ガイドボタン
                            SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 拠点
                            tNedit_Section.Enabled = false;
                            // 拠点ガイドボタン
                            SectionGuide_Button.Enabled = false;
                        }

                        // 手形種別
                        tComboEditor_DraftKind.Enabled = true;
                        // 自他振区分
                        tComboEditor_SelfOtherTransDiv.Enabled = true;
                        // 振出日
                        tDateEdit_DrawingDate.Enabled = true;
                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // 期日
                            tDateEdit_ValidityData.Enabled = true;
                            // 金額
                            tNedit_Amounts.Enabled = true;
                            // 取引先　拠点
                            tNedit_CustSecCd.Enabled = true;
                            // 取引先　拠点ガイドボタン
                            CustSecCdGuide_Button.Enabled = true;
                            // 取引先　得意先／仕入先
                            tNedit_CustCd.Enabled = true;
                            // 取引先　得意先／仕入先ガイドボタン
                            CustomerGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 期日
                            tDateEdit_ValidityData.Enabled = false;
                            // 金額
                            tNedit_Amounts.Enabled = false;
                            // 取引先　拠点
                            tNedit_CustSecCd.Enabled = false;
                            // 取引先　拠点ガイドボタン
                            CustSecCdGuide_Button.Enabled = false;
                            // 取引先　得意先／仕入先
                            tNedit_CustCd.Enabled = false;
                            // 取引先　得意先／仕入先ガイドボタン
                            CustomerGuide_Button.Enabled = false;
                        }
                      
                        // 銀行コード
                        tNedit_BankCd.Enabled = true;
                        // 支店コード
                        tNedit_BranchCd.Enabled = true;
                        // 銀行支店ガイド
                        BankBranchGuide_Button.Enabled = true;
                        // 摘要１
                        tEdit_Outline1.Enabled = true;
                        // 摘要２
                        tEdit_Outline2.Enabled = true;
                        // 操作ボタン
                        this._saveButton.SharedProps.Visible = true;
                        this._clearButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }

                // 更新
                case UPDATE_MODE:
                    {
                        // 手形区分
                        tComboEditor_DraftDiv.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                        // 拠点
                        //tNedit_Section.Enabled = false;
                        // 拠点ガイドボタン
                        //SectionGuide_Button.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<

                        // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // 拠点
                            tNedit_Section.Enabled = true;
                            // 拠点ガイドボタン
                            SectionGuide_Button.Enabled = true;
                            // 取引先拠点
                            tNedit_CustSecCd.Enabled = true;
                            // 取引先　拠点ガイドボタン
                            CustSecCdGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 拠点
                            tNedit_Section.Enabled = false;
                            // 拠点ガイドボタン
                            SectionGuide_Button.Enabled = false;
                            // 取引先拠点
                            tNedit_CustSecCd.Enabled = false;
                            // 取引先　拠点ガイドボタン
                            CustSecCdGuide_Button.Enabled = false;
                        }
                        // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<

                        // 振出日
                        //tDateEdit_DrawingDate.Enabled = true;// DEL zhuhh 2013/01/10 for Redmine #34123

                        if (this._startType == START_TYPE_DIRECT)
                        {
                            // 手形番号
                            tNedit_DraftNo.Enabled = false;
                            // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                            // 手形種別
                            //tComboEditor_DraftKind.Enabled = false;
                            // 自他振区分
                            //tComboEditor_SelfOtherTransDiv.Enabled = false;
                            // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<
                            // 期日
                            tDateEdit_ValidityData.Enabled = true;
                            // 金額
                            tNedit_Amounts.Enabled = true;
                            // 取引先　得意先／仕入先
                            tNedit_CustCd.Enabled = true;
                            // 取引先　得意先／仕入先ガイドボタン
                            CustomerGuide_Button.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            this.tNedit_BankCd.Enabled = false;
                            this.tNedit_BranchCd.Enabled = false;
                            this.BankBranchGuide_Button.Enabled = false;
                            this.tDateEdit_DrawingDate.Enabled = false;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            // 手形番号
                            tNedit_DraftNo.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // 銀行コード
                            tNedit_BankCd.Enabled = true;
                            // 支店コード
                            tNedit_BranchCd.Enabled = true;
                            // 銀行支店ガイド
                            BankBranchGuide_Button.Enabled = true;
                            // 振出日
                            this.tDateEdit_DrawingDate.Enabled = true;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                            // 手形ガイドボタン
                            if (this._draftMode == DRAFT_DIV_PAY)
                            {
                                DraftGuide_Button.Visible = true;
                            }
                            else
                            {
                                DraftGuide_Button.Visible = false;
                            }
                            // --- ADD 2012/10/18 --------------------------------------------------<<<<<

                            // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                            // 手形種別
                            //tComboEditor_DraftKind.Enabled = true;
                            // 自他振区分
                            //tComboEditor_SelfOtherTransDiv.Enabled = true;
                            // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<
                            // 期日
                            tDateEdit_ValidityData.Enabled = false;
                            // 金額
                            tNedit_Amounts.Enabled = false;
                            // 取引先　得意先／仕入先
                            tNedit_CustCd.Enabled = false;
                            // 取引先　得意先／仕入先ガイドボタン
                            CustomerGuide_Button.Enabled = false;
                        }
                        // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                        // 取引先　拠点
                        //tNedit_CustSecCd.Enabled = false;
                        // 取引先　拠点ガイドボタン
                        //CustSecCdGuide_Button.Enabled = false;
                        // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<
                        // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
                        // 手形種別
                        tComboEditor_DraftKind.Enabled = true;
                        // 自他振区分
                        tComboEditor_SelfOtherTransDiv.Enabled = true;
                        // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        // 銀行コード
                        tNedit_BankCd.Enabled = true;
                        // 支店コード
                        tNedit_BranchCd.Enabled = true;
                        // 銀行支店ガイド
                        BankBranchGuide_Button.Enabled = true;
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                        // 摘要１
                        tEdit_Outline1.Enabled = true;
                        // 摘要２
                        tEdit_Outline2.Enabled = true;

                        // 操作ボタン
                        this._saveButton.SharedProps.Visible = true;
                        this._clearButton.SharedProps.Visible = true;
                        if(this._startType == START_TYPE_DIRECT)
                            this._logicDeleteButton.SharedProps.Visible = true;
                        else
                            this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = false;
                        this._revivalButton.SharedProps.Visible = false;

                        this.Mode_Label.Text = UPDATE_MODE;
                        break;
                    }
                // 削除
                case DELETE_MODE:
                    {
                        // 手形区分
                        tComboEditor_DraftDiv.Enabled = false;
                        // 手形番号
                        tNedit_DraftNo.Enabled = false;
                        // 拠点
                        tNedit_Section.Enabled = false;
                        // 拠点ガイドボタン
                        SectionGuide_Button.Enabled = false;
                        // 手形種別
                        tComboEditor_DraftKind.Enabled = false;
                        // 自他振区分
                        tComboEditor_SelfOtherTransDiv.Enabled = false;
                        // 振出日
                        tDateEdit_DrawingDate.Enabled = false;
                        // 期日
                        tDateEdit_ValidityData.Enabled = false;
                        // 金額
                        tNedit_Amounts.Enabled = false;
                        // 取引先　拠点
                        tNedit_CustSecCd.Enabled = false;
                        // 取引先　拠点ガイドボタン
                        CustSecCdGuide_Button.Enabled = false;
                        // 取引先　得意先／仕入先
                        tNedit_CustCd.Enabled = false;
                        // 取引先　得意先／仕入先ガイドボタン
                        CustomerGuide_Button.Enabled = false;
                        // 銀行コード
                        tNedit_BankCd.Enabled = false;
                        // 支店コード
                        tNedit_BranchCd.Enabled = false;
                        // 銀行支店ガイド
                        BankBranchGuide_Button.Enabled = false;
                        // 摘要１
                        tEdit_Outline1.Enabled = false;
                        // 摘要２
                        tEdit_Outline2.Enabled = false;
                        // 操作ボタン
                        this._saveButton.SharedProps.Visible = false;
                        this._clearButton.SharedProps.Visible = true;
                        this._logicDeleteButton.SharedProps.Visible = false;
                        this._deleteButton.SharedProps.Visible = true;
                        this._revivalButton.SharedProps.Visible = true;

                        this.Mode_Label.Text = DELETE_MODE;

                        break;
                    }
            }
        }


        # region 保存処理
        /// <summary>
        ///　保存処理(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus = false;

            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面保存処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return (false);
            }

            // 入力チェック
            bStatus = this.CheckInputScreen();

            if (bStatus != true)
            {
                return (false);
            }

            // ADD 2013/02/22② T.Miyamoto ------------------------------>>>>>
            bool InsChkFlg = false;
            if (this._startType == START_TYPE_DIRECT) // 直接起動
            {
                if (this._modeType == MODE_TYPE_INSERT) // 新規モード
                {
                    // 直接起動で新規モードは重複チェックを実行
                    InsChkFlg = true;
                }
            }
            else
            {
                // UPD 2013/02/22⑥ T.Miyamoto ------------------------------>>>>>
                //if ((this._draftMode == DRAFT_DIV_RCV) ||
                if (((this._draftMode == DRAFT_DIV_RCV) && ((this._rcvDraftData.RcvDraftNo != this._rcvDraftDataOrg.RcvDraftNo) ||
                                                            (this._rcvDraftData.BankAndBranchCd != this._rcvDraftDataOrg.BankAndBranchCd) ||
                                                            (this._rcvDraftData.DraftDrawingDate != this._rcvDraftDataOrg.DraftDrawingDate))) ||
                // UPD 2013/02/22⑥ T.Miyamoto ------------------------------>>>>>
                    ((this._draftMode == DRAFT_DIV_PAY) && ((this._payDraftData.PayDraftNo != this._payDraftDataOrg.PayDraftNo) ||
                                                            (this._payDraftData.BankAndBranchCd != this._payDraftDataOrg.BankAndBranchCd) ||
                                                            (this._payDraftData.DraftDrawingDate != this._payDraftDataOrg.DraftDrawingDate))))
                {
                    // 入金入力から起動または
                    // 支払入力から起動でキー項目に変更があった場合、重複チェックを実行
                    InsChkFlg = true;
                }
            }
            if (InsChkFlg)
            {
                if (!DraftInsertCheck())
                {
                    return (false);
                }
            }
            // ADD 2013/02/22② T.Miyamoto ------------------------------<<<<<

            this.ScreenToDraftData();

            this.DrafDataSetExceptScreen();

            if (this._startType == START_TYPE_DIRECT)
            {
                // DEL 2013/02/22② T.Miyamoto ------------------------------<<<<<
                //// ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                //// 新規モードの場合、手形重複チェックを実行
                //if (this._modeType == MODE_TYPE_INSERT)
                //{
                //    if (!DraftInsertCheck())
                //    {
                //        return (false);
                //    }
                //}
                //// ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                // DEL 2013/02/22② T.Miyamoto ------------------------------<<<<<

                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 支払手形
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                    payDraftDataList.Add(this._payDraftData);
                    status = this._payDraftDataAcs.Write(ref payDraftDataList);
                }
                else
                {
                    List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                    rcvDraftDataList.Add(this._rcvDraftData);
                    status = this._rcvDraftDataAcs.Write(ref rcvDraftDataList);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);                     
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status);

                            return false;
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "SaveProc",
                                           "保存処理に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);
                                                

                            return false;
                        }
                }
                
            }

            this._saveFlg = true;

            return true;
        }
        # endregion 保存処理

        # region チェック処理
        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private bool CheckInputScreen()
        {
            string errMsg = "";

            try
            {
                // 手形番号
                if (this.tNedit_DraftNo.DataText.Trim() == "")
                {
                    errMsg = "手形番号を入力して下さい。";

                    this.tNedit_DraftNo.Focus();
                    return (false);
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // 銀行コード
                else if (this.tNedit_BankCd.DataText == "")
                {
                    errMsg = "銀行を入力して下さい。";
                    this.tNedit_BankCd.Focus();
                    return (false);
                }
                // 支店コード
                else if (this.tNedit_BranchCd.DataText == "")
                {
                    errMsg = "銀行を入力して下さい。";
                    this.tNedit_BranchCd.Focus();
                    return (false);
                }
                // 振出日
                else if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "振出日を入力して下さい。";

                    this.tDateEdit_DrawingDate.Focus();
                    return (false);
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                // 拠点
                else if (this.tNedit_Section.DataText.Trim() == "" && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "拠点を入力して下さい。";

                    this.tNedit_Section.Focus();
                    return (false);
                }
                /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // 振出日
                else if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "振出日を入力して下さい。";

                    this.tDateEdit_DrawingDate.Focus();
                    return (false);
                }
                   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                // 期日
                else if (this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "期日を入力して下さい。";

                    this.tDateEdit_ValidityData.Focus();
                    return (false);
                }
                // 金額
                else if (this.tNedit_Amounts.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    errMsg = "金額を入力して下さい。";

                    this.tNedit_Amounts.Focus();
                    return (false);
                }
                // 取引先拠点
                else if (this.tNedit_CustSecCd.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    //errMsg = "拠点を入力して下さい。";
                    if (_draftMode == DRAFT_DIV_PAY)
                        errMsg = "仕入先を入力して下さい。";
                    else
                        errMsg = "得意先を入力して下さい。";
                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    
                    this.tNedit_CustSecCd.Focus();
                    return (false);
                }
                // 取引先得意先/取引先仕入先
                else if (this.tNedit_CustCd.GetInt() == 0 && this._startType == START_TYPE_DIRECT)
                {
                    // 支払手形
                    if (_draftMode == DRAFT_DIV_PAY)
                        errMsg = "仕入先を入力して下さい。";
                    else
                        errMsg = "得意先を入力して下さい。";

                    this.tNedit_CustCd.Focus();
                    return (false);
                }
                /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                // 銀行コード
                else if (this.tNedit_BankCd.DataText == "")
                {
                    errMsg = "銀行を入力して下さい。";
                    this.tNedit_BankCd.Focus();
                    return (false);
                }
                // 支店コード
                else if (this.tNedit_BranchCd.DataText == "")
                {
                    errMsg = "銀行を入力して下さい。";
                    this.tNedit_BranchCd.Focus();
                    return (false);
                }
                 ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.ToString()
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);

                }
            }

            return true;
        }
        # endregion

        // ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
        # region 手形データ重複チェック処理
        /// <summary>
        /// 手形データ重複チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 手形データの重複チェックを行います。</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2013.02.15</br>
        /// </remarks>
        private bool DraftInsertCheck()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (this._draftMode == DRAFT_DIV_RCV)
            {
                // 受取手形
                List<RcvDraftData> retList = new List<RcvDraftData>();
                RcvDraftData paraRcvDraftData = new RcvDraftData();
                paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                // ADD 2013/02/22④ T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    this._rcvDraftData = new RcvDraftData();
                }
                // ADD 2013/02/22④ T.Miyamoto ------------------------------<<<<<
            }
            else
            {
                // 支払手形
                List<PayDraftData> retList = new List<PayDraftData>();
                PayDraftData paraPayDraftData = new PayDraftData();
                paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                // ADD 2013/02/22④ T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    this._payDraftData = new PayDraftData();
                }
                // ADD 2013/02/22④ T.Miyamoto ------------------------------<<<<<
                // ADD 2013/02/22② T.Miyamoto ------------------------------>>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if ((this._startType == START_TYPE_CALL) &&
                        (this._draftMode == DRAFT_DIV_PAY))
                    {
                        PayDraftData payDraftDataGet = retList[0];
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            if (payDraftDataGet.PaymentSlipNo != 0)
                            {
                                SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                             , "入力された番号の手形データは既に引当られています。", ""
                                             , payDraftDataGet.PayDraftNo
                                             , payDraftDataGet.BankAndBranchCd / 1000
                                             , payDraftDataGet.BankAndBranchCd % 1000
                                             , payDraftDataGet.DraftDrawingDate);
                                return false;
                            }
                            else
                            {
                                DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                   , "入力された番号の手形データは既に登録されています。", "引当処理を行いますか？"
                                                                   , payDraftDataGet.PayDraftNo
                                                                   , payDraftDataGet.BankAndBranchCd / 1000
                                                                   , payDraftDataGet.BankAndBranchCd % 1000
                                                                   , payDraftDataGet.DraftDrawingDate);
                                if (result != DialogResult.Yes)
                                {
                                    return false;
                                }
                                // ADD 2013/02/22⑤ T.Miyamoto ------------------------------>>>>>
                                else
                                {
                                    // 更新モードの初期化処理を行う
                                    this._modeType = MODE_TYPE_UPDATE;
                                    // コントロールEnabled制御
                                    this.SetControlEnabled(UPDATE_MODE);

                                    // 支払手形情報保持(金額・期日チェック用)
                                    this._payDraftDataInfo = payDraftDataGet.Clone();

                                    // 画面情報を反映
                                    int ProcDate = this.tDateEdit_ProcDate.GetLongDate();                     // 処理日
                                    payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // 期日
                                    payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // 金額

                                    // メモリ再設定
                                    this._payDraftData = payDraftDataGet.Clone();
                                    this._payDraftDataOrg = payDraftDataGet.Clone();
                                }
                                // ADD 2013/02/22⑤ T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        else
                        {
                            SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                         , "入力された番号の手形データは既に削除されています。", ""
                                         , payDraftDataGet.PayDraftNo
                                         , payDraftDataGet.BankAndBranchCd / 1000
                                         , payDraftDataGet.BankAndBranchCd % 1000
                                         , payDraftDataGet.DraftDrawingDate);
                            return false;
                        }
                        return true;
                    }
                }
                // ADD 2013/02/22② T.Miyamoto ------------------------------<<<<<
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                SearchMsgShow(emErrorLevel.ERR_LEVEL_EXCLAMATION, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                             ,"入力された番号の手形データは既に存在します。", ""
                             , this.tNedit_DraftNo.Text.Trim()
                          　 , this.tNedit_BankCd.GetInt()
                             , this.tNedit_BranchCd.GetInt()
                             , this.tDateEdit_DrawingDate.GetDateTime());
                return false;
            }
            return true;
        }
        # endregion
        // ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// 手形データ情報変更チェック処理
        /// </summary>
        /// <param name="saveFlg">保存フラグ</param>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private bool CompareDraftData(ref bool saveFlg)
        {
            this.ScreenToDraftData();
            // データ比較
            // 支払手形
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                if (this._payDraftData.Equals(this._payDraftDataOrg))
                {
                    return true;
                }
                else
                {
                    string msg;
                    if (_startType == START_TYPE_CALL)
                        msg = "現在、編集中のデータが存在します。" + "\r\n\r\n" + "確定してもよいですか？";
                    else
                        msg = "現在、編集中のデータが存在します。" + "\r\n\r\n" + "登録してもよいですか？";

                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,                   // エラーレベル
                        PGID, 			                                      // アセンブリＩＤまたはクラスＩＤ
                        msg, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            // 受取手形
            else
            {
                if (this._rcvDraftData.Equals(this._rcvDraftDataOrg))
                {
                    return true;
                }
                else
                {
                    string msg;
                    if (_startType == START_TYPE_CALL)
                        msg = "現在、編集中のデータが存在します。" + "\r\n\r\n" + "確定してもよいですか？";
                    else
                        msg = "現在、編集中のデータが存在します。" + "\r\n\r\n" + "登録してもよいですか？";

                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,                   // エラーレベル
                        PGID, 			                                      // アセンブリＩＤまたはクラスＩＤ
                        msg, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 手形データ情報変更チェック処理(比べるフラグ利用)
        /// </summary>
        /// <param name="saveFlg">保存フラグ</param>
        /// <param name="compareFlg">比べるフラグ</param>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private bool CompareDraftDataWithCompareFlg(ref bool saveFlg, ref bool compareFlg)
        {
            this.ScreenToDraftData();
            // データ比較
            // 支払手形
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                if (this._payDraftData.Equals(this._payDraftDataOrg))
                {
                    compareFlg = true;
                    return true;
                }
                else
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PGID, 			                                      // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            // 受取手形
            else
            {
                if (this._rcvDraftData.Equals(this._rcvDraftDataOrg))
                {
                    compareFlg = true;
                    return true;
                }
                else
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PGID, 			                                      // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                saveFlg = true;
                                return this.SaveProc();
                            }
                        case DialogResult.No:
                            {
                                return true;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }
            }
        }

        # region 画面情報取得
        /// <summary>
        /// 画面情報を手形データに格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報から手形データオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void ScreenToDraftData()
        {
            // 支払手形
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                // 手形番号
                this._payDraftData.PayDraftNo = this.tNedit_DraftNo.Text;
                // ログイン拠点
                this._payDraftData.SectionCode = this.tNedit_Section.Text;
                // 手形種別
                this._payDraftData.DraftKindCd = System.Convert.ToInt32(this.tComboEditor_DraftKind.Value);
                // 自他振区分
                this._payDraftData.DraftDivide = System.Convert.ToInt32(this.tComboEditor_SelfOtherTransDiv.Value);
                // 振出日
                this._payDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                // 期日
                this._payDraftData.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate();
                // 処理日
                this._payDraftData.ProcDate = this.tDateEdit_ProcDate.GetLongDate();
                // 金額
                this._payDraftData.Payment = this.tNedit_Amounts.GetInt();
                // 取引先拠点コード
                this._payDraftData.AddUpSecCode = this.tNedit_CustSecCd.Text;
                // 取引先得意先/仕入先コード
                this._payDraftData.SupplierCd = this.tNedit_CustCd.GetInt();
                // 取引先得意先名称略称
                this._payDraftData.SupplierSnm = this.CustName_Label.Text;
                // 銀行支店コード
                this._payDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                // 銀行名称
                this._payDraftData.BankAndBranchNm = this.BankName_Label.Text;
                // 摘要１
                this._payDraftData.Outline1 = this.tEdit_Outline1.Text;
                // 摘要２
                this._payDraftData.Outline2 = this.tEdit_Outline2.Text;
            }
            // 受取手形
            else
            {
                // 手形番号
                this._rcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text;
                // ログイン拠点
                this._rcvDraftData.SectionCode = this.tNedit_Section.Text;
                // 手形種別
                this._rcvDraftData.DraftKindCd = System.Convert.ToInt32(this.tComboEditor_DraftKind.Value);
                // 自他振区分
                this._rcvDraftData.DraftDivide = System.Convert.ToInt32(this.tComboEditor_SelfOtherTransDiv.Value);
                // 振出日
                this._rcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                // 期日
                this._rcvDraftData.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate();
                // 処理日
                this._rcvDraftData.ProcDate = this.tDateEdit_ProcDate.GetLongDate();
                // 金額
                this._rcvDraftData.Deposit = this.tNedit_Amounts.GetInt();
                // 取引先拠点コード
                this._rcvDraftData.AddUpSecCode = this.tNedit_CustSecCd.Text;
                // 取引先得意先/仕入先コード
                this._rcvDraftData.CustomerCode = this.tNedit_CustCd.GetInt();
                // 取引先得意先名称略称
                this._rcvDraftData.CustomerSnm = this.CustName_Label.Text;
                // 銀行支店コード
                this._rcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                // 銀行名称
                this._rcvDraftData.BankAndBranchNm = this.BankName_Label.Text;
                // 摘要１
                this._rcvDraftData.Outline1 = this.tEdit_Outline1.Text;
                // 摘要２
                this._rcvDraftData.Outline2 = this.tEdit_Outline2.Text;

            }
        }
        # endregion

        # region 他のところから情報取得
        /// <summary>
        /// 他のところから情報を手形データに格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 情報を手形データオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void DrafDataSetExceptScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // 支払手形
            if (this._draftMode == DRAFT_DIV_PAY)
            {

                // 手形決済日
                // 手形種別が｢9:決済｣
                if (this._payDraftData.DraftKindCd == 9)
                    this._payDraftData.DraftStmntDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                else
                    this._payDraftData.DraftStmntDate = 0;

                // 支払日付
                if( this._modeType  == MODE_TYPE_INSERT)
                    this._payDraftData.PaymentDate = DateTime.Now;

                // 仕入先名1 仕入先名2
                Supplier supplier = new Supplier();
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_CustCd.GetInt());
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this._payDraftData.SupplierNm1 = supplier.SupplierNm1;
                    this._payDraftData.SupplierNm2 = supplier.SupplierNm1;
                }
            }
            else
            {
                // 手形決済日
                // 手形種別が｢9:決済｣
                if (this._rcvDraftData.DraftKindCd == 9)
                    this._rcvDraftData.DraftStmntDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                else
                    this._rcvDraftData.DraftStmntDate = 0;
                // 入金日付
                if (this._modeType == MODE_TYPE_INSERT)
                    this._rcvDraftData.DepositDate = DateTime.Now;

                // 得意先名1 得意先名2
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this.tNedit_CustCd.GetInt(), true, out customerInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.CustName_Label.Text = customerInfo.CustomerSnm;
                    this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
                    this._rcvDraftData.CustomerName = customerInfo.Name;
                    this._rcvDraftData.CustomerName2 = customerInfo.Name2;
                }
            }
        }
        # endregion

        #region 画面イベント
        #region FormLoadingイベント
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void PMTEG09101UA_Load(object sender, EventArgs e)
        {
            //　初期化フラグをTrueに設定
            this._initFlg = true;

            // 画面初期化
            InitialScreenSetting();

            // 直接起動
            if (this._startType == START_TYPE_DIRECT)
            {
                this.tNedit_CustCd.MaxLength = 8;
            }
            // 間接起動
            else
            {
                if (_draftMode == DRAFT_DIV_PAY)
                    this.tNedit_CustCd.MaxLength = 6;
                else
                    this.tNedit_CustCd.MaxLength = 8;
            }
            if (this.tNedit_CustCd.MaxLength == 6)
                this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            else
                this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

            // 画面表示処理
            this.SetDataDisp(false);

            // 直接起動
            if (this._startType == START_TYPE_DIRECT)
            {
                // 画面設定から、メモリに保存する
                this.SaveNewDraftMemory();
            }
            // 初期フォーカス設定
            this.tComboEditor_DraftDiv.Select();

            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
            // 支払手形情報取得
            this.PayDraftInfoGet();
            // 受取手形データ引当フラグ
            this._rcvDraftFlgOrg = this._rcvDraftFlg;
            // --- ADD 2012/10/18 --------------------------------------------------<<<<<

            //　初期化フラグをFalseに設定
            this._initFlg = false;
        }
        #endregion

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        #region FormShownイベント
        /// <summary>
        /// FormShownイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面表示時に発生します。</br>      
        /// <br>Programmer  : 宮本</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private void PMTEG09101UA_Shown(object sender, EventArgs e)
        {
            // 支払手形情報チェック処理
            this.PayDraftCheck();
        }
        #endregion
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        #region FormClosingイベント
        /// <summary>
        /// FormClosingイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		:	フォームが閉じられる前に発生します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void PMTEG09101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._closingFlg)
            {
                bool saveFlg = false;
                // 入力中のデータチェック
                if (this.CompareDraftData(ref saveFlg))
                {
                    if (saveFlg)
                    {
                        // 画面処理化
                        this.InitDisp();
                        // 閉じる操作を取り消し
                        e.Cancel = true;

                    }
                }
                else
                {
                    // 閉じる操作を取り消し
                    e.Cancel = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            bool saveFlg = false;
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // 入力中のデータチェック
                        if (this.CompareDraftData(ref saveFlg))
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                if (saveFlg)
                                {
                                    // 画面処理化
                                    this.InitDisp();
                                }
                                else
                                {
                                    this._closingFlg = true;
                                    this.Close();
                                }
                            }
                            else
                            {
                                this._closingFlg = true;
                                this.Close();
                            }
                        }
                        break;
                    }
                // 保存
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        if (this.SaveProc())
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                // 画面処理化
                                this.InitDisp();
                                this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 張義
                            }
                            else
                            {
                                this._closingFlg = true;
                                this.Close();
                            }
                        }
                        break;
                    }
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // 入力中のデータチェック
                        if (this.CompareDraftData(ref saveFlg))
                        {
                            if (this._startType == START_TYPE_DIRECT)
                            {
                                // 画面処理化
                                this.InitDisp();
                                this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 張義
                            }
                            else
                            {
                                if (saveFlg)
                                {
                                    this._closingFlg = true;
                                    this.Close();
                                }
                                else
                                {
                                    if (this._draftMode == DRAFT_DIV_RCV)
                                    {
                                        this._rcvDraftData = this._rcvDraftDataClear.Clone();
                                        this._rcvDraftDataOrg = this._rcvDraftDataClear.Clone();
                                    }
                                    else
                                    {
                                        this._payDraftData = this._payDraftDataClear.Clone();
                                        this._payDraftDataOrg = this._payDraftDataClear.Clone();
                                        this._rcvDraftFlg = this._rcvDraftFlgOrg; // ADD 2012/10/18
                                    }
                                    this._initFlg = true;
                                    this.SetDataDisp(false);
                                    this._initFlg = false;
                                    this.tNedit_DraftNo.Focus(); // ADD 2010.06.28 張義
                                }
                            }
                        }
                        break;
                    }
                // 論理削除
                case TOOLBAR_LOGICALDELETE_KEY:
                    {
                        DateTime targetDate;
                        DialogResult dr;

                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面論理削除処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // 支払手形
                        if (this._draftMode == DRAFT_DIV_PAY)
                        {
                            if (this._paymentSlpSearch == null)
                                this._paymentSlpSearch = new PaymentSlpSearch();

                            targetDate = this._paymentSlpSearch.GetHisTotalDayMonthlyAccPay(this.tNedit_CustSecCd.Text.Trim());
                            if (targetDate != DateTime.MinValue)
                            {
                                // 処理日が前回月次更新日以前の場合
                                if (this._payDraftData.ProcDate <= Convert.ToInt32(targetDate.ToString("yyyyMMdd")))
                                {
                                    dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "処理日が前回仕入月次更新日以前です。" + "\r\n" + "データを論理削除して、よろしいですか？",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        // 論理削除処理
                                        this.LogicalDeleteProc();
                                    }
                                    break;
                                }
                            }
                        }
                        // 受取手形
                        else
                        {
                            if (this._inputDepositNormalTypeAcs == null)
                                this._inputDepositNormalTypeAcs = new InputDepositNormalTypeAcs();
                            targetDate = this._inputDepositNormalTypeAcs.GetHisTotalDayMonthlyAccRec(this.tNedit_CustSecCd.Text.Trim());
                            if (targetDate != DateTime.MinValue)
                            {
                                // 処理日が前回月次更新日以前の場合
                                if (this._rcvDraftData.ProcDate <= Convert.ToInt32(targetDate.ToString("yyyyMMdd")))
                                {
                                    dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "処理日が前回売上月次更新日以前です。" + "\r\n" + "データを論理削除して、よろしいですか？",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        // 論理削除処理
                                        this.LogicalDeleteProc();
                                    }
                                    break;
                                }
                            }
                        }

                        // 決済日チェック
                        bool checkFlg = false;
                        if (_draftMode == DRAFT_DIV_RCV)
                        {
                            if (this._rcvDraftData.DraftStmntDate == 0)
                            {
                                checkFlg = true;
                            }
                        }
                        else
                        {
                            if (this._payDraftData.DraftStmntDate == 0)
                            {
                                checkFlg = true;
                            }
                        }
                        if (checkFlg)
                        {

                            dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    PGID,
                                                    "未決済の手形です。" + "\r\n" + "データを論理削除して、よろしいですか？",
                                                    0,
                                                    MessageBoxButtons.YesNo);

                            if (dr == DialogResult.Yes)
                            {
                                // 論理削除処理
                                this.LogicalDeleteProc();
                                break;
                            }
                            else
                                break;
                        }

                        dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 PGID,
                                                 "データを論理削除します。" + "\r\n" + "よろしいですか？",
                                                 0,
                                                 MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            // 論理削除処理
                            this.LogicalDeleteProc();
                        }

                        break;
                    }
                // 削除
                case TOOLBAR_DELETE_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面物理削除処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                  PGID,
                                  "データを完全削除します。" + "\r\n" + "よろしいですか？",
                                  0,
                                  MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            this.DeleteProc();
                        }
                        break;
                    }
                // 復活
                case TOOLBAR_REVIVAL_KEY:
                    {
                        // オフライン状態チェック
                        if (!CheckOnline())
                        {
                            TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Text,
                                this.Text + "画面復活処理に失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        this.RevivalProc();
                        break;
                    }
            }
        }
        
        /// <summary>
        /// 手形区分コンボボックス値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 手形区分コンボボックス値変更後発生イベントを行う。 </br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void tComboEditor_DraftDiv_ValueChanged(object sender, EventArgs e)
        {
            // 初期化の場合
            if (_initFlg)
                return;

            bool saveFlg = false;
            bool compareFlg = false;

            // 入力中のデータチェック
            if (this.CompareDraftDataWithCompareFlg(ref saveFlg, ref compareFlg))
            {
                if (!compareFlg)
                {
                    this._draftMode = DRAFT_DIV_RCV;
                    this.tNedit_CustCd.MaxLength = 8;
                    this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

                    // 画面処理化
                    this.InitDisp();
                }
                else
                {
                    if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
                    {
                        this._draftMode = DRAFT_DIV_RCV;
                        this.tNedit_CustCd.MaxLength = 8;
                        this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
                    }
                    else
                    {
                        this._draftMode = DRAFT_DIV_PAY;
                        this.tNedit_CustCd.MaxLength = 6;
                        this.tNedit_CustCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));

                    }
                    // 画面処理化
                    this.SetDataDisp(true);
                    // メモリ保存
                    this.SaveNewDraftMemory();
                }
            }
            else
            {
                this._initFlg = true;
                // 変更処理を取り消し
                if (this.tComboEditor_DraftDiv.Value.ToString() == "0")
                    this.tComboEditor_DraftDiv.Value = "1";
                else
                    this.tComboEditor_DraftDiv.Value = "0";
                this._initFlg = false;

            }
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
            /*
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            if (e.Key == Keys.Down)
            {
                if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    // 金額→取引先(拠点ｺｰﾄﾞ)
                    e.NextCtrl = this.tNedit_CustSecCd;
                }
                else if (e.PrevCtrl == this.tNedit_DraftNo)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    if (this.tNedit_Section.Enabled)
                    {
                        e.NextCtrl = this.tNedit_Section;
                    }
                    else
                    {
                        e.NextCtrl = this.tComboEditor_DraftKind;
                    }
                }
                else if (e.PrevCtrl == this.tComboEditor_SelfOtherTransDiv)
                {
                    if (this.tDateEdit_ValidityData.Enabled)
                    {
                        e.NextCtrl = this.tDateEdit_ValidityData;
                    }
                    else 
                    {
                        e.NextCtrl = this.tEdit_Outline1;
                    }
                }
                else if (e.PrevCtrl == this.BankBranchGuide_Button)
                {
                    e.NextCtrl = this.tDateEdit_DrawingDate;
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    e.NextCtrl = this.tComboEditor_DraftKind;
                }
                else if (e.PrevCtrl == this.DraftGuide_Button)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
            }
            else if (e.Key == Keys.Up)
            {
                if (e.PrevCtrl == this.tEdit_Outline1 && this.tNedit_CustSecCd.Enabled)
                {
                    // 摘要１→拠点コード
                    e.NextCtrl = this.tNedit_CustSecCd;
                }
                else if (e.PrevCtrl == this.tEdit_Outline1 && this.tNedit_CustSecCd.Enabled == false)
                {
                    //摘要１→自他振区分
                    e.NextCtrl = this.tComboEditor_SelfOtherTransDiv;
                }
                else if (e.PrevCtrl == this.CustomerGuide_Button)
                {
                    if (this.tNedit_Amounts.Enabled)
                    {
                        e.NextCtrl = this.tNedit_Amounts;
                    }
                    else
                    {
                        e.NextCtrl = this.tComboEditor_SelfOtherTransDiv;
                    }
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    if (this.tDateEdit_DrawingDate.Enabled)
                        e.NextCtrl = this.tDateEdit_DrawingDate;
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    e.NextCtrl = this.tNedit_BankCd;
                }
                else if (e.PrevCtrl == this.BankBranchGuide_Button)
                {
                    e.NextCtrl = this.tNedit_DraftNo;
                }
            }
            else if (e.Key == Keys.Right)
            {
                if (e.PrevCtrl == this.tComboEditor_DraftDiv)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tNedit_DraftNo)
                {
                    if (this.DraftGuide_Button.Visible == false)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.SectionGuide_Button)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tComboEditor_DraftKind)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tComboEditor_SelfOtherTransDiv)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tDateEdit_ValidityData)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tEdit_Outline1)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.tEdit_Outline2)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == this.DraftGuide_Button)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            // 手形番号
            if (e.PrevCtrl == this.tNedit_DraftNo && this.tNedit_DraftNo.Text != "")
            {
                string draftNo = this.tNedit_DraftNo.Value.ToString();
                bool serchflg = false;
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    bool temp = false;
                    if (this._secondsearchflg && this.tNedit_BankCd.Text!="" && this.tNedit_BranchCd.Text!="" && this.tDateEdit_DrawingDate.GetDateTime()!=DateTime.MinValue)
                    {
                        temp = true;
                    }
                    else if (draftNo != this._rcvDraftData.RcvDraftNo)
                    {
                        temp = true;
                    }
                    if (temp)
                    {
                        // 検索処理
                        serchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tNedit_DraftNo.Text = "";
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tNedit_DraftNo.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!serchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        }
                    }
                }
                else
                {
                    bool temp = false;
                    if (this._secondsearchflg && this.tNedit_BankCd.Text!="" && this.tNedit_BranchCd.Text!="" && this.tDateEdit_DrawingDate.GetDateTime()!=DateTime.MinValue)
                    {
                        temp = true;
                    }
                    else if (draftNo != this._payDraftData.PayDraftNo)
                    {
                        temp = true;
                    }
                    if (temp) 
                    {
                        this._rcvDraftFlg = false;
                        RcvDraft_Label.Visible = false;
                        // 検索処理
                        serchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tNedit_DraftNo.Text = "";
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tNedit_DraftNo.Text = "";
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!serchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        }
                    } 
                }
            }
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            */
            // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // DEL 2013/02/15 T.Miyamoto 以降復活
            // 手形番号
            if (e.PrevCtrl == this.tNedit_DraftNo && this.tNedit_DraftNo.Text != "")
            {
                string draftNo = this.tNedit_DraftNo.Value.ToString();
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    if (draftNo != this._rcvDraftData.RcvDraftNo && draftNo != this._draftNo)
                        // 検索処理
                        if (!this.SearchProc())
                        {
                            //e.NextCtrl = e.PrevCtrl;// DEL zhuhh 2013/01/10 for Redmine #34123                            
                            return;
                        }
                }
                else
                {
                    if (draftNo != this._payDraftData.PayDraftNo && draftNo != this._draftNo)
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    {
                        this._rcvDraftFlg = false;
                        RcvDraft_Label.Visible = false;
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                        // 検索処理
                        if (!this.SearchProc())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            return;
                        }
                        // ADD 2013/02/22③ T.Miyamoto ------------------------------>>>>>
                        // 入力からの起動時に再入力不要の場合は手形種別にフォーカス移動
                        if (this._startType == START_TYPE_CALL)
                        {
                            e.NextCtrl = tComboEditor_DraftKind;
                        }
                        // ADD 2013/02/22③ T.Miyamoto ------------------------------<<<<<
                    } // 2012/10/18 ADD
                 }
            }
            //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */ // DEL 2013/02/15 T.Miyamoto 以上復活

            // 拠点
            else if (e.PrevCtrl == this.tNedit_Section && this.tNedit_Section.GetInt() != 0)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this.tNedit_Section.Value.ToString().PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                if (secInfoSet != null)
                {
                    this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "拠点が存在しません。", 0, MessageBoxButtons.OK);
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tNedit_Section.Value = this._rcvDraftData.SectionCode;
                    else
                        this.tNedit_Section.Value = this._payDraftData.SectionCode;
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            // 振出日
            else if (e.PrevCtrl == this.tDateEdit_DrawingDate)
            {
                int longdate = this.tDateEdit_DrawingDate.GetLongDate();
                int year = this.tDateEdit_DrawingDate.GetDateYear();
                int month = this.tDateEdit_DrawingDate.GetDateMonth();
                int day = this.tDateEdit_DrawingDate.GetDateDay();
                // 未入力時はクリア
                // 年号未入力時はクリア
                // 年が未入力時はクリア
                // 12月以降の不正月入力時はクリア（月の未入力不可）
                // 日付の有効性Check
                if (((longdate == 0) ||
                    (this.tDateEdit_DrawingDate.GetLongDate().ToString().Length != 8) ||
                    (year == 0) ||
                    (month == 0) ||
                    (month > 12)) ||
                    ((day != 0) &&
                    (day > TDateTime.GetLastDate(year, month))))
                {
                    this.tDateEdit_DrawingDate.Clear();
                }
                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // DEL 2013/02/15 T.Miyamoto 以降復活
                if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue || this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue)
                    return;
                // 振出日＞期日となる日付が入力
                if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "期日以下の日付を入力して下さい。", 0, MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                    else
                        this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                    return;
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.SetValue(timeSpan.Days);
                }
                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */ // DEL 2013/02/15 T.Miyamoto 以上復活
                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                /*
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                if (this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    // 振出日＞期日となる日付が入力
                    if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "期日以下の日付を入力して下さい。", 0, MessageBoxButtons.OK);
                        e.NextCtrl = e.PrevCtrl;
                        if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                            this.tDateEdit_DrawingDate.SetDateTime(this._rcvDraftData.DraftDrawingDate);
                        else
                            this.tDateEdit_DrawingDate.SetDateTime(this._payDraftData.DraftDrawingDate);
                        return;
                    }

                    if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                    {
                        TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                        this.tNedit_Site.SetValue(timeSpan.Days);
                    }  
                }
                DateTime dateTimeTemp = this.tDateEdit_DrawingDate.GetDateTime();
                bool temp = false;
                string draftNo = this.tNedit_DraftNo.Text.Trim();            
                if ((!String.IsNullOrEmpty(draftNo))&&(this.tNedit_BankCd.GetInt()!=0) && (this.tNedit_BranchCd.GetInt() != 0) &&dateTimeTemp != DateTime.MinValue)
                {
                    if(this._draftMode == DRAFT_DIV_RCV)
                    {
                       if(dateTimeTemp != this._rcvDraftData.DraftDrawingDate )
                           temp=true;
                    }
                    else
                    {
                       if(dateTimeTemp != this._payDraftData.DraftDrawingDate)
                           temp=true;
                    }
                    if (this._secondsearchflg)
                    {
                        temp = true;
                    }
                   
                    if ((!String.IsNullOrEmpty(draftNo))&&(this.tNedit_BankCd.GetInt()!=0) && (this.tNedit_BranchCd.GetInt() != 0)&&temp)
                    {
                        // 検索処理
                        bool searchflg = false;
                        searchflg = this.SearchProc();
                        if (this._chkflg && this._clickflg)
                        {
                            this.tDateEdit_DrawingDate.SetDateTime(DateTime.MinValue);
                            this._clickflg = false;
                            this._chkflg = false;
                            this._secondsearchflg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else 
                        {
                            this._secondsearchflg = false;
                        }
                        if (this._chkflg && this._payflag)
                        {
                            this._payflag = false;
                            this._chkflg = false;
                            this.tDateEdit_DrawingDate.SetDateTime(DateTime.MinValue);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        if (!searchflg)
                        {
                            this.ScreenToDraftData();
                            return;
                        } 
                    }
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                */
                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            }
            // 期日
            else if (e.PrevCtrl == this.tDateEdit_ValidityData)
            {

                int longdate = this.tDateEdit_ValidityData.GetLongDate();
                int year = this.tDateEdit_ValidityData.GetDateYear();
                int month = this.tDateEdit_ValidityData.GetDateMonth();
                int day = this.tDateEdit_ValidityData.GetDateDay();
                // 未入力時はクリア
                // 年号未入力時はクリア
                // 年が未入力時はクリア
                // 12月以降の不正月入力時はクリア（月の未入力不可）
                // 日付の有効性Check
                if (((longdate == 0) ||
                    (this.tDateEdit_ValidityData.GetLongDate().ToString().Length != 8) ||
                    (year == 0) ||
                    (month == 0) ||
                    (month > 12)) ||
                    ((day != 0) &&
                    (day > TDateTime.GetLastDate(year, month))))
                {
                    this.tDateEdit_ValidityData.Clear();
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() == DateTime.MinValue || this.tDateEdit_ValidityData.GetDateTime() == DateTime.MinValue)
                    return;
                // 振出日＞期日となる日付が入力
                if (this.tDateEdit_DrawingDate.GetDateTime() > this.tDateEdit_ValidityData.GetDateTime())
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "振出日以上の日付を入力して下さい。", 0, MessageBoxButtons.OK);
                    e.NextCtrl = e.PrevCtrl;
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._rcvDraftData.ValidityTerm));
                    else
                        this.tDateEdit_ValidityData.SetDateTime(this.ChangeDateTime(this._payDraftData.ValidityTerm));
                    return;
                }

                if (this.tDateEdit_DrawingDate.GetDateTime() != DateTime.MinValue && this.tDateEdit_ValidityData.GetDateTime() != DateTime.MinValue)
                {
                    TimeSpan timeSpan = this.tDateEdit_ValidityData.GetDateTime() - this.tDateEdit_DrawingDate.GetDateTime();
                    this.tNedit_Site.SetValue(timeSpan.Days);
                }
            }
            // 取引拠点
            else if (e.PrevCtrl == this.tNedit_CustSecCd && this.tNedit_CustSecCd.GetInt() != 0)
            {

                SecInfoSet secInfoSet = new SecInfoSet();

                this._secInfoAcs.GetSecInfo(this.tNedit_CustSecCd.GetValue().ToString().PadLeft(2, '0').PadRight(6, ' '), out secInfoSet);
                if (secInfoSet == null)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "拠点が存在しません。", 0, MessageBoxButtons.OK);
                    if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        this.tNedit_CustSecCd.Value = this._rcvDraftData.AddUpSecCode;
                    else
                        this.tNedit_CustSecCd.Value = this._payDraftData.AddUpSecCode;
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            //  取引先コード
            else if (e.PrevCtrl == this.tNedit_CustCd && this.tNedit_CustCd.GetInt() != 0)
            {
                // 支払手形
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    Supplier supplier = new Supplier();
                    status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_CustCd.GetInt());
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        this.CustName_Label.Text = supplier.SupplierSnm;
                        this.tNedit_CustSecCd.Value = supplier.PaymentSectionCode;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "仕入先が存在しません。", 0, MessageBoxButtons.OK);
                        this.tNedit_CustCd.SetInt(this._payDraftData.SupplierCd);
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                }
                else
                {
                    CustomerInfo customerInfo;
                    status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this.tNedit_CustCd.GetInt(), true, out customerInfo);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        this.CustName_Label.Text = customerInfo.CustomerSnm;
                        this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "得意先が存在しません。", 0, MessageBoxButtons.OK);
                        this.tNedit_CustCd.SetInt(this._rcvDraftData.CustomerCode);
                        e.NextCtrl = e.PrevCtrl;
                        return;

                    }
                }

            }
            // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
            //  取引先コード
            else if (e.PrevCtrl == this.tNedit_CustCd && this.tNedit_CustCd.GetInt() == 0)
            {
                //ｺｰﾄﾞをクリアしても名称もクリアする
                this.CustName_Label.Text = string.Empty;
            }
            // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
            // 銀行/支店コード
            //else if (e.PrevCtrl == this.tNedit_BranchCd || e.PrevCtrl == this.tNedit_BankCd ) // DEL 2010.06.28 redmine#10551 張義
            else if (e.PrevCtrl == this.tNedit_BranchCd)// ADD 2010.06.28 redmine#10551 張義
            {
                // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                //// 銀行コード フォーカスアウトすると、0000で補足
                //if (e.PrevCtrl == this.tNedit_BankCd && this.tNedit_BankCd.DataText == "")
                //    this.tNedit_BankCd.SetInt(0);

                //// 支店コード フォーカスアウトすると、000で補足
                //if (e.PrevCtrl == this.tNedit_BranchCd && this.tNedit_BranchCd.DataText == "")
                //    this.tNedit_BranchCd.SetInt(0);
                // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<

                if (this.tNedit_BankCd.DataText != "" && this.tNedit_BranchCd.DataText != "")
                {
                    int bankBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                    bool checkFlg = false;
                    bool haveFlg = false;
                    ArrayList userDgBdList = null;
                    //this._userGuideAcs.SearchAllDivCodeBody(out userDgBdList, this._enterpriseCode, 46, UserGuideAcsData.OfferDivCodeMergeBodyData); // DEL 2010.06.28 redmine#10551 張義
                    this._userGuideAcs.SearchDivCodeBody(out userDgBdList, this._enterpriseCode, 46, UserGuideAcsData.OfferDivCodeMergeBodyData);// ADD 2010.06.28 redmine#10551 張義
                    foreach (UserGdBd userGdBd in userDgBdList)
                    {
                        if (userGdBd.GuideCode == bankBranchCd)
                        {
                            this.BankName_Label.Text = userGdBd.GuideName;
                            checkFlg = true;
                            // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
                            _bankCdBefore = this.tNedit_BankCd.Text;
                            _branchCdBefore = this.tNedit_BranchCd.Text;
                            // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
                        }
                    }
                    if (!checkFlg)
                    {
                        int bankCd;
                        int branchCd;
                        if (this.tComboEditor_DraftDiv.SelectedIndex == 0)
                        {
                            // 銀行コード
                            bankCd = this._rcvDraftData.BankAndBranchCd / 1000;
                            // 支店コード
                            branchCd = this._rcvDraftData.BankAndBranchCd % 1000;
                        }
                        else
                        {
                            // 銀行コード
                            bankCd = this._payDraftData.BankAndBranchCd / 1000;
                            // 支店コード
                            branchCd = this._payDraftData.BankAndBranchCd % 1000;
                        }

                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "銀行が存在しません。", 0, MessageBoxButtons.OK);
                        // --- DEL 2010.06.28 redmine#10551 張義 ---------->>>>>
                        //if (e.PrevCtrl == this.tNedit_BankCd)
                        //{
                        // --- DEL 2010.06.28 redmine#10551 張義 ----------<<<<<
                        foreach (UserGdBd userGdBd in userDgBdList)
                        {
                            if (userGdBd.GuideCode == (bankCd * 1000 + branchCd))
                            {
                                this.tNedit_BankCd.SetInt(bankCd);
                                haveFlg = true;
                                break;
                            }
                        }
                        // 銀行・支店が存在していない
                        if (!haveFlg)
                            //this.tNedit_BankCd.Text = ""; // DEL 2010.06.28 redmine#10551 張義
                            this.tNedit_BankCd.Text = _bankCdBefore; // ADD 2010.06.28 redmine#10551 張義
                        //}// DEL 2010.06.28 redmine#10551 張義

                        if (e.PrevCtrl == this.tNedit_BranchCd)
                        {
                            foreach (UserGdBd userGdBd in userDgBdList)
                            {
                                if (userGdBd.GuideCode == (bankCd * 1000 + branchCd))
                                {
                                    this.tNedit_BranchCd.SetInt(branchCd);
                                    haveFlg = true;
                                    break;
                                }
                            }
                            // 銀行・支店が存在していない
                            if (!haveFlg)
                                //this.tNedit_BranchCd.Text = ""; // DEL 2010.06.28 redmine#10551 張義
                                this.tNedit_BranchCd.Text = _branchCdBefore; // ADD 2010.06.28 redmine#10551 張義
                        }
                        //e.NextCtrl = e.PrevCtrl;// DEL 2010.06.28 redmine#10551 張義
                        //this.tNedit_BankCd.Focus(); // ADD 2010.06.28 redmine#10551 張義 // DEL zhuhh 2013/01/10 for Redmine #34123
                        this.tNedit_BranchCd.Focus(); // ADD zhuhh 2013/01/10 for Redmine #34123
                        return;
                    }
                    // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>
                    /*
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    else 
                    {
                        // 銀行・支店が存在しる場合
                        int bankAndBranchCd = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()+this.tNedit_BranchCd.Value.ToString());
                        if(!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                        {
                            if(this._draftMode == DRAFT_DIV_RCV?(bankAndBranchCd!=this._rcvDraftData.BankAndBranchCd):(bankAndBranchCd!=this._payDraftData.BankAndBranchCd))
                            {
                                bool searchflg = false;
                                searchflg = this.SearchProc();
                                if (this._chkflg && this._clickflg)
                                {
                                    this.tNedit_BankCd.Text = "";
                                    this.tNedit_BranchCd.Text = "";
                                    this.BankName_Label.Text = "";
                                    this._clickflg = false;
                                    this._chkflg = false;
                                    this._secondsearchflg = true;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else 
                                {
                                    this._secondsearchflg = false;
                                }
                                if (this._chkflg && this._payflag)
                                {
                                    this._payflag = false;
                                    this._chkflg = false;
                                    this.tNedit_BankCd.Text = "";
                                    this.tNedit_BranchCd.Text = "";
                                    this.BankName_Label.Text = "";
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                if (!searchflg)
                                {
                                    this.ScreenToDraftData();
                                    return;
                                }
                            }
                            else if(this._draftMode == DRAFT_DIV_RCV?(bankAndBranchCd==this._rcvDraftData.BankAndBranchCd):(bankAndBranchCd==this._payDraftData.BankAndBranchCd))
                            {
                                if(this._secondsearchflg)
                                {
                                    bool searchflg = false;
                                    searchflg = this.SearchProc();
                                    if (this._chkflg && this._clickflg)
                                    {
                                        this.tNedit_BankCd.Text = "";
                                        this.tNedit_BranchCd.Text = "";
                                        this.BankName_Label.Text = "";
                                        this._clickflg = false;
                                        this._chkflg = false;
                                        this._secondsearchflg = true;
                                    }
                                    else 
                                    {
                                        this._secondsearchflg = false;
                                    }
                                    if (this._chkflg && this._payflag)
                                    {
                                        this._payflag = false;
                                        this._chkflg = false;
                                        this.tNedit_BankCd.Text = "";
                                        this.tNedit_BranchCd.Text = "";
                                        this.BankName_Label.Text = "";
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    if (!searchflg)
                                    {
                                        this.ScreenToDraftData();
                                        return;
                                    }    
                                }else{return;}
                            }
                        }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    */
                    // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                }
                // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
                else if (string.IsNullOrEmpty(this.tNedit_BankCd.DataText)
                    && string.IsNullOrEmpty(this.tNedit_BranchCd.DataText))
                {
                    //ｺｰﾄﾞをクリアしても名称もクリアする
                    this.BankName_Label.Text = string.Empty;
                }
                // --- ADD 2010.06.28 redmine#10551 張義 ----------<<<<<
            }
            ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> // UPD 2013/02/15 T.Miyamoto 以降復活
            // --- ADD 2010.06.28 redmine#10551 張義 ---------->>>>>
            if (e.Key == Keys.Down)
            {
                if (e.PrevCtrl == this.tNedit_Amounts)
                {
                    // 金額→取引先(拠点ｺｰﾄﾞ)
                    e.NextCtrl = this.tNedit_CustSecCd;
                }                
            }
            else if (e.Key == Keys.Up)
            {
                if (e.PrevCtrl == this.tEdit_Outline1)
                {
                    // 摘要１→銀行コード
                    e.NextCtrl = this.tNedit_BankCd;
                    //e.NextCtrl = this.tNedit_CustSecCd;// ADD zhuhh 2013/01/10 for Redmine #34123 // DEL 2013/02/15 T.Miyamoto
                }              
            } 
            //  ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */ // UPD 2013/02/15 T.Miyamoto 以上復活
            // メモリ保存
            this.ScreenToDraftData();
        }

        /// <summary>
        /// Button_Click イベント(Guide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private void Guide_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 拠点ガイドボタン
            if (sender == this.SectionGuide_Button)
            {
                // オフライン状態チェック	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Text,
                        "拠点ガイド" + "画面初期化処理に失敗しました。",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
                SecInfoSet secInfoSet;
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {

                    this.tNedit_Section.Value = secInfoSet.SectionCode;
                    this.SectionName_Label.Text = secInfoSet.SectionGuideNm;
                    // フォーカス移動
                    this.tComboEditor_DraftKind.Focus();
                }
            }
            // 得意先、仕入先の拠点ガイドボタン
            else if (sender == this.CustSecCdGuide_Button)
            {
                // オフライン状態チェック	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Text,
                        "拠点ガイド" + "画面初期化処理に失敗しました。",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
                SecInfoSet secInfoSet;
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {

                    this.tNedit_CustSecCd.Value = secInfoSet.SectionCode;
                    // フォーカス移動
                    this.tNedit_CustCd.Focus();
                }
            }
            // 得意先、仕入先ガイドボタン
            else if (sender == this.CustomerGuide_Button)
            {
                // 支払手形
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    // 仕入先ガイド起動
                    // ガイド起動
                    Supplier supplier = new Supplier();
                    status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // 拠点コード
                        this.tNedit_CustSecCd.Value = supplier.MngSectionCode;
                        // 仕入先コード
                        this.tNedit_CustCd.SetValue(supplier.SupplierCd);
                        // 仕入先名称
                        this.CustName_Label.Text = supplier.SupplierSnm;
                        // フォーカス移動
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>
                        ////this.tNedit_BankCd.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                        //this.tEdit_Outline1.Focus();// ADD zhuhh 2013/01/24 for Redmine #34123
                        this.tNedit_BankCd.Focus();
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<

                    }
                }
                // 受取手形
                else
                {
                    _customerGuideOK = false;

                    // 得意先ガイド起動
                    PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                    customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
                    customerSearchForm.ShowDialog(this);
                    if (_customerGuideOK)
                    {
                        // フォーカス移動
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>
                        ////this.tNedit_BankCd.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                        //this.tEdit_Outline1.Focus();// ADD zhuhh 2013/01/24 for Redmine #34123
                        this.tNedit_BankCd.Focus();
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    }
                }
            }
            //銀行支店ガイドボタン
            else if (sender == this.BankBranchGuide_Button)
            {
                UserGdHd userGdHd;
                UserGdBd userGdBd;
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 46);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 銀行コード
                    this.tNedit_BankCd.SetInt(userGdBd.GuideCode / 1000);
                    // 支店コード
                    this.tNedit_BranchCd.SetInt(userGdBd.GuideCode % 1000);
                    this.BankName_Label.Text = userGdBd.GuideName;
                    this._bankCdBefore = this.tNedit_BankCd.Text; // ADD 2010.06.28 redmine#10551 張義
                    this._branchCdBefore = this.tNedit_BranchCd.Text; // ADD 2010.06.28 redmine#10551 張義
                    // フォーカス移動
                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    ////this.tEdit_Outline1.Focus();// DEL zhuhh 2013/01/10 for Redmine #34123
                    //this.tDateEdit_DrawingDate.Focus();// ADD zhuhh 2013/01/10 for Redmine #34123
                    this.tEdit_Outline1.Focus();
                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                }
                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                /*
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                int bankAndBranchCdAfterGuid = 0;
                if (String.IsNullOrEmpty(this.tNedit_BankCd.Text))
                {
                    if (!String.IsNullOrEmpty(this.tNedit_BranchCd.Text))
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BranchCd.Value.ToString());
                    }
                }
                else 
                {
                    if (!String.IsNullOrEmpty(this.tNedit_BranchCd.Text))
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()) * 1000 + Convert.ToInt32(this.tNedit_BranchCd.Value.ToString());
                    }
                    else 
                    {
                        bankAndBranchCdAfterGuid = Convert.ToInt32(this.tNedit_BankCd.Value.ToString()) * 1000;
                    }
                    
                }
                 
                if ((!String.IsNullOrEmpty(this.tNedit_DraftNo.Text)) && (this._draftMode == DRAFT_DIV_RCV ? (bankAndBranchCdAfterGuid != this._rcvDraftData.BankAndBranchCd) : (bankAndBranchCdAfterGuid != this._payDraftData.BankAndBranchCd)))
                {                   
                    this.SearchProc();
                    if (this._chkflg && this._clickflg)
                    {
                        this.tNedit_BankCd.Text = "";
                        this.tNedit_BranchCd.Text = "";
                        this.BankName_Label.Text = "";
                        this._clickflg = false;
                        this._chkflg = false;
                        this._secondsearchflg = true;
                    }
                    else 
                    {
                        this._secondsearchflg = true;
                    }
                }
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                */
                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
            }
            // --- ADD 2012/10/18 -------------------------------------------------->>>>>
            //手形ガイドボタン
            else if (sender == this.DraftGuide_Button)
            {
                //手形手持ち検索画面表示
                PMTEG09101UB salesSlipNumDlg = new PMTEG09101UB();
                DialogResult ret = salesSlipNumDlg.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    this._rcvDraftFlg = true; // 受取手形データのガイド呼出

                    this.tNedit_DraftNo.Value = salesSlipNumDlg._rcvDraftData.RcvDraftNo;
                    this._rcvDraftData = salesSlipNumDlg._rcvDraftData;

                    // 検索処理
                    // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                    /*
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    bool searchflg = false;
                    searchflg = this.SearchProc();
                    if(this._chkflg&&this._clickflg)
                    {
                        this.tNedit_DraftNo.Text="";
                        this._clickflg=false;
                        this._clickflg=false;
                        this.tNedit_DraftNo.Focus();
                    }
                    if(!searchflg)
                    {
                        this.tNedit_DraftNo.Focus();
                    }
                    else
                    {
                        // フォーカス移動
                        this.tComboEditor_DraftKind.Focus();
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    */
                    // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                    ///* ----- DEL zhuhh 2013/01/10 for Redmime #34123 ----->>>>> // UPD 2013/02/15 T.Miyamoto 以降復活
                    if (!this.SearchProc())
                    {
                        this.tNedit_DraftNo.Focus();
                    }
                    else
                    {
                        // フォーカス移動
                        this.tComboEditor_DraftKind.Focus();
                    }
                    //   ----- DEL zhuhh 2013/01/10 for Redmime #34123 -----<<<<< */ // UPD 2013/02/15 T.Miyamoto 以上復活
                }
            }
            // --- ADD 2012/10/18 --------------------------------------------------<<<<<
            // メモリ保存
            this.ScreenToDraftData();
        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // ガイド起動
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
            // 項目に展開
            // 拠点コード
            this.tNedit_CustSecCd.Value = customerInfo.MngSectionCode;
            // 得意先先コード
            this.tNedit_CustCd.SetInt( customerInfo.CustomerCode);
            // 得意先名称
            this.CustName_Label.Text = customerInfo.CustomerSnm;

            _customerGuideOK = true;
        }
        #endregion

        #region 新規メモリ保存処理
        /// <summary>
        /// メモリクリア処理
        /// </summary>
        /// <remarks> 
        /// <br>Note       : メモリを初期メモリで回復する</br> 
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void SaveNewDraftMemory()
        {
            // 画面設定から、メモリに保存する
            if (this._draftMode == DRAFT_DIV_RCV)
            {
                this._rcvDraftData = this._rcvDraftDataClear.Clone();
                this.ScreenToDraftData();
                this._rcvDraftDataOrg = this._rcvDraftData.Clone();
            }
            else
            {
                this._payDraftData = this._payDraftDataClear.Clone();
                this.ScreenToDraftData();
                this._payDraftDataOrg = this._payDraftData.Clone();
            }
        }
        #endregion

        #region 画面初期化
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks> 
        /// <br>Note       : 画面を初期化する</br> 
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private void InitDisp()
        {
            // 初期化フラグ
            this._initFlg = true;
            // 新規モード変更
            this._modeType = MODE_TYPE_INSERT;
            // コントロールEnabled制御
            this.SetControlEnabled(INSERT_MODE);
            // 画面クリア
            this.SetDataDisp(false);
            // 初期化フラグ
            this._initFlg = false;
            // メモリ保存
            this.SaveNewDraftMemory();
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            //手形保存前のチェックフラグ
            this._chkflg = false;
            //選択「いいえ」フラグ
            this._clickflg = false;
            // 全条件検索フラグ
            this._secondsearchflg = false;
            this._payflag = false;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        }
        #endregion

        #region オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 数値からDataTimeに変更処理
        /// <summary>
        /// 数値からDataTimeに変更処理
        /// </summary>
        /// <param name="dateInt">日期数値</param>
        /// <remarks> 
        /// <br>Note       : 数値からDataTimeに変更する</br> 
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DateTime ChangeDateTime(int dateInt)
        {
            string dataStr = dateInt.ToString();
            if (dataStr.Length != 8)
            {
                return DateTime.MinValue;
            }
            else
            {
                return new DateTime(System.Convert.ToInt32(dataStr.Substring(0, 4)), 
                    System.Convert.ToInt32(dataStr.Substring(4, 2)), System.Convert.ToInt32(dataStr.Substring(6, 2)));
            }
        }
        #endregion

        # region DB操作
        # region 検索処理
        /// <summary>
        ///　検索処理(SearchProc())
        /// </summary>
        /// <returns>チェックステータス</returns>
        /// <remarks>
        /// <br>Note　　　  : 検索処理を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// <br>UpdateNote : 2013/04/02 王君</br>
        /// <br>管理番号   : 10901273-00 2013/05/15配信分</br>
        /// <br>           : redmine #35247 仕入総括オプションの調査</br>
        /// </remarks>
        private bool SearchProc()
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 直接起動
            if (this._startType == START_TYPE_DIRECT)
            {
                // 受取手形
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>                    
                    if (!String.IsNullOrEmpty(paraRcvDraftData.RcvDraftNo))
                    {
                        paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraRcvDraftData.BankAndBranchCd==0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithoutBabCd(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        else if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.SearchWithBabCd(out retList, 0, paraRcvDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        RcvDraftData rcvDraftDataGet = (RcvDraftData)retList[0];
                        // 論理削除区分 = 0:有効
                        if (rcvDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //        //"入力された番号の手形データが既に登録されています。" + "\r\n" + "編集を行いますか？",// DEL zhuhh 2013/01/10 for Redmine #34123
                            //        "入力された番号の手形データが既に登録されています。" + "\r\n" + "【手形番号：" + rcvDraftDataGet.RcvDraftNo + "　銀行・支店コード：" + (rcvDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (rcvDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + rcvDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】\r\n" + "編集を行いますか？",// ADD zhuhh 2013/01/10 for Redmine #34123
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "入力された番号の手形データが既に登録されています。","編集を行いますか？"
                                                               , rcvDraftDataGet.RcvDraftNo
                                                               , rcvDraftDataGet.BankAndBranchCd / 1000
                                                               , rcvDraftDataGet.BankAndBranchCd % 1000
                                                               , rcvDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // 編集モード
                                this._modeType = MODE_TYPE_UPDATE;
                                // コントロールEnabled制御
                                this.SetControlEnabled(UPDATE_MODE);
                                // メモリ再設定
                                this._rcvDraftData = rcvDraftDataGet.Clone();
                                this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                                this._initFlg = true;
                                // 画面再表示
                                this.SetDataDisp(false);
                                this._initFlg = false;
                                this.tNedit_Section.Focus();// ADD zhuhh 2013/01/10 for Redmine #34123
                            }
                            else
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this.tNedit_DraftNo.Clear();
                                //this.tNedit_DraftNo.Focus();
                                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this._clickflg = true;
                                //this.tNedit_BankCd.Focus();
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                this._clickflg = true;
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        // 論理削除区分 = 1:論理削除
                        else if (rcvDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に削除されています。", 0, MessageBoxButtons.OK);
                            // 削除モードの初期化処理を行う
                            this._modeType = MODE_TYPE_DELETE;
                            // コントロールEnabled制御
                            this.SetControlEnabled(DELETE_MODE);
                            // メモリ再設定
                            this._rcvDraftData = rcvDraftDataGet.Clone();
                            this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                            this._initFlg = true;
                            // 画面再表示
                            this.SetDataDisp(false);
                            this._initFlg = false;
                               ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //    "入力された番号の手形データが既に削除されています。" + "\r\n" + "【手形番号：" + rcvDraftDataGet.RcvDraftNo + "　銀行・支店コード：" + (rcvDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (rcvDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + rcvDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】\r\n" + "編集を行いますか？",
                            //0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "入力された番号の手形データが既に削除されています。", "編集を行いますか？"
                                                               , rcvDraftDataGet.RcvDraftNo
                                                               , rcvDraftDataGet.BankAndBranchCd / 1000
                                                               , rcvDraftDataGet.BankAndBranchCd % 1000
                                                               , rcvDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // 削除モードの初期化処理を行う
                                this._modeType = MODE_TYPE_DELETE;
                                // コントロールEnabled制御
                                this.SetControlEnabled(DELETE_MODE);
                                // メモリ再設定
                                this._rcvDraftData = rcvDraftDataGet.Clone();
                                this._rcvDraftDataOrg = rcvDraftDataGet.Clone();
                                this._initFlg = true;
                                // 画面再表示
                                this.SetDataDisp(false);
                                this._initFlg = false;
                            }
                            else 
                            {
                                this._clickflg = true;
                            }
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            this.tNedit_DraftNo.Clear();
                            this.tNedit_DraftNo.Focus();
                            return false; // ADD 2013/02/15 T.Miyamoto
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                            {
                                this._selectForm = new PMTEG09101UC();
                            }
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this,ref retList);
                            if (dr == DialogResult.OK)
                            {
                                // UPD 2013/02/22① T.Miyamoto ------------------------------>>>>>
                                //// メモリ再設定
                                //this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                //this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                //if (this._rcvDraftData.LogicalDeleteCode == DEL_CD_USE)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// 編集モード
                                //    //this._modeType = MODE_TYPE_UPDATE;
                                //    //// コントロールEnabled制御
                                //    //this.SetControlEnabled(UPDATE_MODE);
                                //    //this._initFlg = true;
                                //    //// 画面再表示
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    //this.tNedit_Section.Focus();
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "入力された番号の手形データが既に登録されています。", "編集を行いますか？"
                                //                                       , this._rcvDraftData.RcvDraftNo
                                //                                       , this._rcvDraftData.BankAndBranchCd / 1000
                                //                                       , this._rcvDraftData.BankAndBranchCd % 1000
                                //                                       , this._rcvDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // 編集モード
                                //        this._modeType = MODE_TYPE_UPDATE;
                                //        // コントロールEnabled制御
                                //        this.SetControlEnabled(UPDATE_MODE);
                                //        this._initFlg = true;
                                //        // 画面再表示
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //        this.tNedit_Section.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                //else if (this._rcvDraftData.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// 削除モードの初期化処理を行う
                                //    //this._modeType = MODE_TYPE_DELETE;
                                //    //// コントロールEnabled制御
                                //    //this.SetControlEnabled(DELETE_MODE);
                                //    //this._initFlg = true;
                                //    //// 画面再表示
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false; 
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "入力された番号の手形データが既に削除されています。", "編集を行いますか？"
                                //                                       , this._rcvDraftData.RcvDraftNo
                                //                                       , this._rcvDraftData.BankAndBranchCd / 1000
                                //                                       , this._rcvDraftData.BankAndBranchCd % 1000
                                //                                       , this._rcvDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // 削除モードの初期化処理を行う
                                //        this._modeType = MODE_TYPE_DELETE;
                                //        // コントロールEnabled制御
                                //        this.SetControlEnabled(DELETE_MODE);
                                //        this._initFlg = true;
                                //        // 画面再表示
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                RcvDraftData rcvDraftDataChk = this._selectForm.RcvDraftDataLst.Clone(); // チェック用
                                if (rcvDraftDataChk.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "入力された番号の手形データが既に登録されています。", "編集を行いますか？"
                                                                       , rcvDraftDataChk.RcvDraftNo
                                                                       , rcvDraftDataChk.BankAndBranchCd / 1000
                                                                       , rcvDraftDataChk.BankAndBranchCd % 1000
                                                                       , rcvDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // 編集モード
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // コントロールEnabled制御
                                        this.SetControlEnabled(UPDATE_MODE);
                                        this._initFlg = true;
                                        // メモリ再設定
                                        this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                        this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                        // 画面再表示
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                        this.tNedit_Section.Focus();
                                    }
                                }
                                else if (rcvDraftDataChk.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "入力された番号の手形データが既に削除されています。", "編集を行いますか？"
                                                                       , rcvDraftDataChk.RcvDraftNo
                                                                       , rcvDraftDataChk.BankAndBranchCd / 1000
                                                                       , rcvDraftDataChk.BankAndBranchCd % 1000
                                                                       , rcvDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // 削除モードの初期化処理を行う
                                        this._modeType = MODE_TYPE_DELETE;
                                        // コントロールEnabled制御
                                        this.SetControlEnabled(DELETE_MODE);
                                        this._initFlg = true;
                                        // メモリ再設定
                                        this._rcvDraftData = this._selectForm.RcvDraftDataLst.Clone();
                                        this._rcvDraftDataOrg = this._selectForm.RcvDraftDataLst.Clone();
                                        // 画面再表示
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                    }
                                }
                                // UPD 2013/02/22① T.Miyamoto ------------------------------<<<<<
                                else 
                                {
                                    this.tNedit_DraftNo.Clear();
                                    this.tNedit_DraftNo.Focus();
                                }
                            }
                            else
                            {
                                // DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //this.tNedit_BankCd.Focus();
                                // DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        else 
                        {
                            if (this.tNedit_DraftNo.Focused) { this.tNedit_BranchCd.Focus(); }
                            if (this.tNedit_BranchCd.Focused) { this.tNedit_Section.Focus(); }
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }

                }
                // 支払手形データ
                else
                {
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>                    
                    if (!String.IsNullOrEmpty(paraPayDraftData.PayDraftNo))
                    {
                        paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate==DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithoutBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        else if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.SearchWithBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                        // 論理削除区分 = 0:有効
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //        //"入力された番号の手形データが既に登録されています。" + "\r\n" + "編集を行いますか？",// DEL zhuhh 2013/01/10 for Redmine #34123
                            //        "入力された番号の手形データは既に引当られています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】\r\n" + "編集を行いますか？",// ADD zhuhh 2013/01/10 for Redmine #34123
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            string sMsg = "入力された番号の手形データは既に登録されています。";
                            if (payDraftDataGet.PaymentSlipNo != 0)
                                sMsg = "入力された番号の手形データは既に引当られています。";
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , sMsg, "編集を行いますか？"
                                                               , payDraftDataGet.PayDraftNo
                                                               , payDraftDataGet.BankAndBranchCd / 1000
                                                               , payDraftDataGet.BankAndBranchCd % 1000
                                                               , payDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // 更新モードの初期化処理を行う
                                this._modeType = MODE_TYPE_UPDATE;
                                // コントロールEnabled制御
                                this.SetControlEnabled(UPDATE_MODE);
                                // メモリ再設定
                                this._payDraftData = payDraftDataGet.Clone();
                                this._payDraftDataOrg = payDraftDataGet.Clone();
                                this._initFlg = true;
                                // 画面再表示
                                this.SetDataDisp(false);
                                this._initFlg = false;
                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                this.tNedit_BankCd.Enabled = false;
                                this.tNedit_BranchCd.Enabled = false;
                                this.BankBranchGuide_Button.Enabled = false;
                                this.tNedit_Section.Focus();
                                this.tDateEdit_DrawingDate.Enabled = false;
                                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                            }
                            else
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ///* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this.tNedit_DraftNo.Clear();
                                //this.tNedit_DraftNo.Focus();
                                //   ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                                //this._clickflg = true;
                                //this.tNedit_BankCd.Focus();
                                //// ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                                this._clickflg = true;
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                        // 論理削除区分 = 1:論理削除
                        else if (payDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に削除されています。", 0, MessageBoxButtons.OK);
                            // 削除モードの初期化処理を行う
                            this._modeType = MODE_TYPE_DELETE;
                            // コントロールEnabled制御
                            this.SetControlEnabled(DELETE_MODE);
                            // メモリ再設定
                            this._payDraftData = payDraftDataGet.Clone();
                            this._payDraftDataOrg = payDraftDataGet.Clone();
                            this._initFlg = true;
                            // 画面再表示
                            this.SetDataDisp(false);
                            this._initFlg = false;
                            ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                            //    "入力された番号の手形データは既に削除られています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】\r\n" + "編集を行いますか？",
                            //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                            DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                               , "入力された番号の手形データは既に削除されています。", "編集を行いますか？"
                                                               , payDraftDataGet.PayDraftNo
                                                               , payDraftDataGet.BankAndBranchCd / 1000
                                                               , payDraftDataGet.BankAndBranchCd % 1000
                                                               , payDraftDataGet.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            if (result == DialogResult.Yes)
                            {
                                // 削除モードの初期化処理を行う
                                this._modeType = MODE_TYPE_DELETE;
                                // コントロールEnabled制御
                                this.SetControlEnabled(DELETE_MODE);
                                // メモリ再設定
                                this._payDraftData = payDraftDataGet.Clone();
                                this._payDraftDataOrg = payDraftDataGet.Clone();
                                this._initFlg = true;
                                // 画面再表示
                                this.SetDataDisp(false);
                                this._initFlg = false;
                            }
                            else 
                            {
                                this._clickflg = true;
                            }
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        }
                        else
                        {
                            this.tNedit_DraftNo.Clear();
                            this.tNedit_DraftNo.Focus();
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>> 
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this, ref retList);
                            if (dr == DialogResult.OK)
                            {
                                // UPD 2013/02/22① T.Miyamoto ------------------------------>>>>>
                                //// DEL 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                ////// 編集モード
                                ////this._modeType = MODE_TYPE_UPDATE;
                                ////// コントロールEnabled制御
                                ////this.SetControlEnabled(UPDATE_MODE);
                                //// DEL 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //// メモリ再設定
                                //this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                //this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                //
                                //if (this._payDraftData.LogicalDeleteCode == DEL_CD_USE)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //this._initFlg = true;
                                //    //// 画面再表示
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    //this.tNedit_BankCd.Enabled = false;
                                //    //this.tNedit_BranchCd.Enabled = false;
                                //    //this.BankBranchGuide_Button.Enabled = false;
                                //    //this.tNedit_Section.Focus();
                                //    string sMsg = "入力された番号の手形データは既に登録されています。";
                                //    if (this._payDraftData.PaymentSlipNo != 0)
                                //        sMsg = "入力された番号の手形データは既に引当られています。";
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , sMsg, "編集を行いますか？"
                                //                                       , this._payDraftData.PayDraftNo
                                //                                       , this._payDraftData.BankAndBranchCd / 1000
                                //                                       , this._payDraftData.BankAndBranchCd % 1000
                                //                                       , this._payDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // 編集モード
                                //        this._modeType = MODE_TYPE_UPDATE;
                                //        // コントロールEnabled制御
                                //        this.SetControlEnabled(UPDATE_MODE);
                                //        
                                //        this._initFlg = true;
                                //        // 画面再表示
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //        this.tNedit_BankCd.Enabled = false;
                                //        this.tNedit_BranchCd.Enabled = false;
                                //        this.BankBranchGuide_Button.Enabled = false;
                                //        this.tNedit_Section.Focus();
                                //    }
                                //    else
                                //    {
                                //        this._clickflg = true;
                                //        this.tNedit_BankCd.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                //else if (this._payDraftData.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                //{
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //    //// 削除モードの初期化処理を行う
                                //    //this._modeType = MODE_TYPE_DELETE;
                                //    //// コントロールEnabled制御
                                //    //this.SetControlEnabled(DELETE_MODE);
                                //    //this._initFlg = true;
                                //    //// 画面再表示
                                //    //this.SetDataDisp(false);
                                //    //this._initFlg = false;
                                //    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                //                                       , "入力された番号の手形データは既に削除されています。", "編集を行いますか？"
                                //                                       , this._payDraftData.PayDraftNo
                                //                                       , this._payDraftData.BankAndBranchCd / 1000
                                //                                       , this._payDraftData.BankAndBranchCd % 1000
                                //                                       , this._payDraftData.DraftDrawingDate);
                                //    if (result == DialogResult.Yes)
                                //    {
                                //        // 削除モードの初期化処理を行う
                                //        this._modeType = MODE_TYPE_DELETE;
                                //        // コントロールEnabled制御
                                //        this.SetControlEnabled(DELETE_MODE);
                                //        this._initFlg = true;
                                //        // 画面再表示
                                //        this.SetDataDisp(false);
                                //        this._initFlg = false;
                                //    }
                                //    else
                                //    {
                                //        this._clickflg = true;
                                //        this.tNedit_BankCd.Focus();
                                //    }
                                //    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                //}
                                PayDraftData payDraftDataChk = this._selectForm.PayDraftDataLst.Clone(); // チェック用
                                if (payDraftDataChk.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    string sMsg = "入力された番号の手形データは既に登録されています。";
                                    if (payDraftDataChk.PaymentSlipNo != 0)
                                        sMsg = "入力された番号の手形データは既に引当られています。";
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , sMsg, "編集を行いますか？"
                                                                       , payDraftDataChk.PayDraftNo
                                                                       , payDraftDataChk.BankAndBranchCd / 1000
                                                                       , payDraftDataChk.BankAndBranchCd % 1000
                                                                       , payDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // 編集モード
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // コントロールEnabled制御
                                        this.SetControlEnabled(UPDATE_MODE);
                                        this._initFlg = true;
                                        // メモリ再設定
                                        this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                        this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                        // 画面再表示
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                        this.tNedit_BankCd.Enabled = false;
                                        this.tNedit_BranchCd.Enabled = false;
                                        this.BankBranchGuide_Button.Enabled = false;
                                    }
                                    else
                                    {
                                        this._clickflg = true;
                                    }
                                }
                                else if (payDraftDataChk.LogicalDeleteCode == DEL_CD_LOG_DEL)
                                {
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "入力された番号の手形データは既に削除されています。", "編集を行いますか？"
                                                                       , payDraftDataChk.PayDraftNo
                                                                       , payDraftDataChk.BankAndBranchCd / 1000
                                                                       , payDraftDataChk.BankAndBranchCd % 1000
                                                                       , payDraftDataChk.DraftDrawingDate);
                                    if (result == DialogResult.Yes)
                                    {
                                        // 削除モードの初期化処理を行う
                                        this._modeType = MODE_TYPE_DELETE;
                                        // コントロールEnabled制御
                                        this.SetControlEnabled(DELETE_MODE);
                                        this._initFlg = true;
                                        // メモリ再設定
                                        this._payDraftData = this._selectForm.PayDraftDataLst.Clone();
                                        this._payDraftDataOrg = this._selectForm.PayDraftDataLst.Clone();
                                        // 画面再表示
                                        this.SetDataDisp(false);
                                        this._initFlg = false;
                                    }
                                    else
                                    {
                                        this._clickflg = true;
                                    }
                                }
                                // UPD 2013/02/22① T.Miyamoto ------------------------------<<<<<
                                else 
                                {
                                    this.tNedit_DraftNo.Clear();
                                    this.tNedit_DraftNo.Focus();
                                }
                            }
                            else
                            {
                                this._clickflg = true;
                                this.tNedit_BankCd.Focus();
                            }
                        }
                        else 
                        {
                            if (this.tNedit_DraftNo.Focused) { this.tNedit_BranchCd.Focus(); }
                            if (this.tNedit_BranchCd.Focused) { this.tNedit_Section.Focus(); }
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }
                }
            }
            // 入力から起動
            else
            {
                List<RcvDraftData> rcvRetListTemp = null;// ADD zhuhh 2013/01/10 for Redmine #34123
                // 受取手形
                if (this._draftMode == DRAFT_DIV_RCV)
                {
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                       ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<RcvDraftData> retList = new List<RcvDraftData>();
                    RcvDraftData paraRcvDraftData = new RcvDraftData();
                    paraRcvDraftData.EnterpriseCode = this._enterpriseCode;
                    paraRcvDraftData.RcvDraftNo = this.tNedit_DraftNo.Text.Trim();
                    paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                    if (!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                    {

                        paraRcvDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraRcvDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithoutBabCd(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        else if (paraRcvDraftData.BankAndBranchCd == 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._rcvDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.SearchWithBabCd(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraRcvDraftData.BankAndBranchCd != 0 && paraRcvDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._rcvDraftDataAcs.Search(out retList, 0, paraRcvDraftData);
                            rcvRetListTemp = retList;
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    else 
                    {
                        return false;
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                }
                // 支払手形データ
                else
                {
                    // 画面の手形種別を保持
                    int DraftKindCd = this._payDraftData.DraftKindCd;
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    //status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);// DEL zhuhh 2013/01/10 for Redmine #34123
                       ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>> */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    List<PayDraftData> retList = new List<PayDraftData>();
                    PayDraftData paraPayDraftData = new PayDraftData();
                    paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                    paraPayDraftData.PayDraftNo = this.tNedit_DraftNo.Text.Trim();
                    paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                    if (!String.IsNullOrEmpty(this.tNedit_DraftNo.Text))
                    {
                        paraPayDraftData.BankAndBranchCd = this.tNedit_BankCd.GetInt() * 1000 + this.tNedit_BranchCd.GetInt();
                        paraPayDraftData.DraftDrawingDate = this.tDateEdit_DrawingDate.GetDateTime();
                        if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithoutBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        else if (paraPayDraftData.BankAndBranchCd == 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        {
                            status = this._payDraftDataAcs.SearchWithDrawingDate(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate == DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.SearchWithBab(out retList, 0, paraPayDraftData);
                            this._chkflg = false;
                        }
                        // UPD 2013/03/04 T.Miyamoto ------------------------------>>>>>
                        //else if ((this.tNedit_BankCd.GetInt() != 0) && (this.tNedit_BranchCd.GetInt() != 0) && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        else if (paraPayDraftData.BankAndBranchCd != 0 && paraPayDraftData.DraftDrawingDate != DateTime.MinValue)
                        // UPD 2013/03/04 T.Miyamoto ------------------------------<<<<<
                        {
                            status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                            this._chkflg = true;
                        }
                        else { return false; }
                    }
                    else 
                    {
                        return false;
                    }
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    // --- ADD 2012/10/18 -------------------------------------------------->>>>>
                    bool payChkFlg = false; // 既存手形引当無し // ADD 2013/02/22 T.Miyamoto
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                        // 論理削除区分 = 0:有効
                        if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                        {
                            if (payDraftDataGet.PaymentSlipNo != 0)
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に引当られています。", 0, MessageBoxButtons.OK);
                                this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                                return false;
                            }
                            // 更新モードの初期化処理を行う
                            this._modeType = MODE_TYPE_UPDATE;
                            // コントロールEnabled制御
                            this.SetControlEnabled(UPDATE_MODE);

                            // 支払手形情報保持(金額・期日チェック用)
                            this._payDraftDataInfo = payDraftDataGet.Clone();

                            // 画面情報を反映
                            int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // 処理日
                            payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // 期日
                            payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // 金額

                            // メモリ再設定
                            this._payDraftData = payDraftDataGet.Clone();
                            this._payDraftDataOrg = payDraftDataGet.Clone();
                        }
                        // 論理削除区分 = 1:論理削除
                        else if (payDraftDataGet.LogicalDeleteCode == DEL_CD_LOG_DEL)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に削除されています。", 0, MessageBoxButtons.OK);
                            // 手形番号を戻す
                            this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                            return false;
                        }
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (retList.Count == 1)
                        {
                            PayDraftData payDraftDataGet = retList[0];
                            if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                            {
                                if (payDraftDataGet.PaymentSlipNo != 0)
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に引当られています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】", 0, MessageBoxButtons.OK);
                                    SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                 , "入力された番号の手形データは既に引当られています。", ""
                                                 , payDraftDataGet.PayDraftNo
                                                 , payDraftDataGet.BankAndBranchCd / 1000
                                                 , payDraftDataGet.BankAndBranchCd % 1000
                                                 , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    this.tNedit_DraftNo.Focus();
                                    this._clickflg = true;
                                    //return false; // DEL 2013/02/22③ T.Miyamoto
                                }
                                else 
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PGID,
                                    //    "入力された番号の手形データは既に登録されています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】\r\n" + "引当処理を行いますか？",
                                    //    0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                                    DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                       , "入力された番号の手形データは既に登録されています。", "引当処理を行いますか？"
                                                                       , payDraftDataGet.PayDraftNo
                                                                       , payDraftDataGet.BankAndBranchCd / 1000
                                                                       , payDraftDataGet.BankAndBranchCd % 1000
                                                                       , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    if (result == DialogResult.Yes)
                                    {
                                        // 更新モードの初期化処理を行う
                                        this._modeType = MODE_TYPE_UPDATE;
                                        // コントロールEnabled制御
                                        this.SetControlEnabled(UPDATE_MODE);

                                        // 支払手形情報保持(金額・期日チェック用)
                                        this._payDraftDataInfo = payDraftDataGet.Clone();

                                        // 画面情報を反映
                                        int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // 処理日
                                        payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // 期日
                                        payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // 金額

                                        // メモリ再設定
                                        this._payDraftData = payDraftDataGet.Clone();
                                        this._payDraftDataOrg = payDraftDataGet.Clone();
                                        this._payflag = false;

                                        payChkFlg = true; // 既存手形引当あり // ADD 2013/02/22 T.Miyamoto
                                    }
                                    else 
                                    {
                                        this._payflag = true;
                                        //return false; // DEL 2013/02/22③ T.Miyamoto
                                    }
                                }                                                               
                            }
                            else 
                            {
                                // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に削除されています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】", 0, MessageBoxButtons.OK);
                                SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                             , "入力された番号の手形データは既に削除されています。", ""
                                             , payDraftDataGet.PayDraftNo
                                             , payDraftDataGet.BankAndBranchCd / 1000
                                             , payDraftDataGet.BankAndBranchCd % 1000
                                             , payDraftDataGet.DraftDrawingDate);
                                // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                this._clickflg = true;
                                //return false; // DEL 2013/02/22③ T.Miyamoto
                            }
                        }
                        else if (retList.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr = this._selectForm.SelectGoodsGuideShow(this, ref retList);
                            if (dr == DialogResult.OK)
                            {
                                PayDraftData payDraftDataGet = this._selectForm.PayDraftDataLst.Clone();
                                if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                                {
                                    if (payDraftDataGet.PaymentSlipNo != 0)
                                    {
                                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に引当られています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】", 0, MessageBoxButtons.OK);
                                        SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                     , "入力された番号の手形データは既に引当られています。", ""
                                                     , payDraftDataGet.PayDraftNo
                                                     , payDraftDataGet.BankAndBranchCd / 1000
                                                     , payDraftDataGet.BankAndBranchCd % 1000
                                                     , payDraftDataGet.DraftDrawingDate);
                                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                        this.tNedit_DraftNo.Focus();
                                        //return false; // DEL 2013/02/22③ T.Miyamoto
                                    }
                                    else
                                    {
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                                        // 手形選択画面で選択した手形が登録済(未引当)の場合、確認メッセージを表示
                                        DialogResult result = SearchMsgShow(emErrorLevel.ERR_LEVEL_QUESTION, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                                                                           , "入力された番号の手形データは既に登録されています。", "引当処理を行いますか？"
                                                                           , payDraftDataGet.PayDraftNo
                                                                           , payDraftDataGet.BankAndBranchCd / 1000
                                                                           , payDraftDataGet.BankAndBranchCd % 1000
                                                                           , payDraftDataGet.DraftDrawingDate);
                                        if (result == DialogResult.Yes)
                                        {
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                                            // 更新モードの初期化処理を行う
                                            this._modeType = MODE_TYPE_UPDATE;
                                            // コントロールEnabled制御
                                            this.SetControlEnabled(UPDATE_MODE);

                                            // 支払手形情報保持(金額・期日チェック用)
                                            this._payDraftDataInfo = payDraftDataGet.Clone();

                                            // 画面情報を反映
                                            int ProcDate = this.tDateEdit_ProcDate.GetLongDate();         // 処理日
                                            payDraftDataGet.ValidityTerm = this.tDateEdit_ValidityData.GetLongDate(); // 期日
                                            payDraftDataGet.Payment = this.tNedit_Amounts.GetInt();                   // 金額

                                            // メモリ再設定
                                            this._payDraftData = payDraftDataGet.Clone();
                                            this._payDraftDataOrg = payDraftDataGet.Clone();
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                                            payChkFlg = true; // 既存手形引当あり
                                        }
                                        else
                                        {
                                            this._payflag = true;
                                        }
                                        // ADD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                                    }
                                }
                                else 
                                {
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入力された番号の手形データは既に削除されています。" + "\r\n" + "【手形番号：" + payDraftDataGet.PayDraftNo + "　銀行・支店コード：" + (payDraftDataGet.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (payDraftDataGet.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + payDraftDataGet.DraftDrawingDate.ToString("yyyyMMdd") + "】", 0, MessageBoxButtons.OK);
                                    SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                                 , "入力された番号の手形データは既に削除されています。", ""
                                                 , payDraftDataGet.PayDraftNo
                                                 , payDraftDataGet.BankAndBranchCd / 1000
                                                 , payDraftDataGet.BankAndBranchCd % 1000
                                                 , payDraftDataGet.DraftDrawingDate);
                                    // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                                    this._clickflg = true;
                                    //return false; // DEL 2013/02/22③ T.Miyamoto
                                }
                            }
                            else 
                            {
                                //this.tNedit_BankCd.Focus(); // DEL 2013/02/22③ T.Miyamoto
                                //return false;               // DEL 2013/02/22③ T.Miyamoto
                            }
                        }
                        else { return false; }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }

                    if (this._rcvDraftFlg)
                    {
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            // --- ADD 2012/10/29 -------------------------------------------------->>>>>
                            // 画面情報を保持
                            int ProcDate = this._payDraftData.ProcDate;            // 処理日
                            string AddUpSecCode = this._payDraftData.AddUpSecCode; // 取引先拠点コード
                            int SupplierCd = this._payDraftData.SupplierCd;        // 取引先コード
                            string SupplierSnm = this._payDraftData.SupplierSnm;   // 取引先名称
                            // --- ADD 2012/10/29 --------------------------------------------------<<<<<
                            string sectionCode = this._payDraftData.SectionCode;   // 拠点　// ADD 王君 2013/04/02 Redmine#35247

                            // 支払手形データが検索できない場合
                            this._payDraftData = new PayDraftData(); // 2012/10/24 ADD

                            // --- ADD 2012/10/29 -------------------------------------------------->>>>>
                            // 画面情報を反映
                            this._payDraftData.ProcDate = ProcDate;         // 処理日
                            this._payDraftData.AddUpSecCode = AddUpSecCode; // 取引先拠点コード
                            this._payDraftData.SupplierCd = SupplierCd;     // 取引先コード
                            this._payDraftData.SupplierSnm = SupplierSnm;   // 取引先名称
                            // --- ADD 2012/10/29 --------------------------------------------------<<<<<
                            this._payDraftData.SectionCode = sectionCode;   // 拠点　// ADD 王君 2013/04/02 Redmine#35247

                            // 更新モードの初期化処理を行う
                            this._modeType = MODE_TYPE_UPDATE;
                            // コントロールEnabled制御
                            this.SetControlEnabled(UPDATE_MODE);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //========================================
                        // 受取手形データガイド検索の場合
                        //========================================
                        RcvDraft_Label.Visible = true;

                        // 検索した受取手形データを支払手形データ格納領域に展開↓
                        // 手形番号
                        this._payDraftData.PayDraftNo = this._rcvDraftData.RcvDraftNo;
                        // ----- ADD 王君 2013/04/02 Redmine#35247 ----->>>>>
                        if (!this._supplierSummary)
                        {
                        // ----- ADD 王君 2013/04/02 Redmine#35247 -----<<<<<
                        // ログイン拠点
                        this._payDraftData.SectionCode = this._rcvDraftData.SectionCode;
                        }// ADD 王君 2013/04/02 Redmine#35247 
                        // 手形種別
                        this._payDraftData.DraftKindCd = DraftKindCd;
                        // 自他振区分
                        this._payDraftData.DraftDivide = this._rcvDraftData.DraftDivide;
                        // 振出日
                        this._payDraftData.DraftDrawingDate = this._rcvDraftData.DraftDrawingDate;
                        // 期日
                        this._payDraftData.ValidityTerm = this._rcvDraftData.ValidityTerm;
                        //　金額
                        this._payDraftData.Payment = this._rcvDraftData.Deposit;
                        // 銀行・支店コード
                        this._payDraftData.BankAndBranchCd = this._rcvDraftData.BankAndBranchCd;
                        // 銀行名称
                        this._payDraftData.BankAndBranchNm = this._rcvDraftData.BankAndBranchNm;
                        // 摘要１
                        this._payDraftData.Outline1 = this._rcvDraftData.Outline1;
                        // 摘要２
                        this._payDraftData.Outline2 = this._rcvDraftData.Outline2;

                        payChkFlg = true; // 既存手形引当あり // ADD 2013/02/22 T.Miyamoto
                    }
                    // UPD 2013/02/22 T.Miyamoto ------------------------------>>>>>
                    //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) && (payChkFlg))
                    // UPD 2013/02/22 T.Miyamoto ------------------------------<<<<<
                    {
                        this._initFlg = true;
                        // 画面再表示
                        this.SetDataDisp(false);
                        this._initFlg = false;

                        // 支払手形情報チェック処理
                        this.PayDraftCheck();
                    }
                    // --- ADD 2012/10/18 --------------------------------------------------<<<<<
                }
                // --- UPD 2012/10/18 -------------------------------------------------->>>>>
                //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                if (this._draftMode == DRAFT_DIV_RCV &&
                    status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                // --- UPD 2012/10/18 --------------------------------------------------<<<<<
                {
                    /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.ToString()
                                 , "入力された番号の手形データが既に登録されています。"
                                 , 0
                                 , MessageBoxButtons.OK);
                    // 手形番号を戻す
                    if (this._draftMode == DRAFT_DIV_RCV)
                        this.tNedit_DraftNo.Value = this._rcvDraftData.RcvDraftNo;
                    else
                        this.tNedit_DraftNo.Value = this._payDraftData.PayDraftNo;
                     * ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        RcvDraftData rcvDraftDataTemp = null;
                        if (rcvRetListTemp.Count == 1) 
                        {
                            rcvDraftDataTemp = rcvRetListTemp[0];
                            // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                            //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                            //       , this.ToString()
                            //       , "入力された番号の手形データが既に登録されています。" + "\r\n" + "【手形番号：" + rcvDraftDataTemp.RcvDraftNo + "　銀行・支店コード：" + (rcvDraftDataTemp.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (rcvDraftDataTemp.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + rcvDraftDataTemp.DraftDrawingDate.ToString("yyyyMMdd") + "】"
                            //       , 0
                            //       , MessageBoxButtons.OK);
                            SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                         , "入力された番号の手形データが既に登録されています。", ""
                                         , rcvDraftDataTemp.RcvDraftNo
                                         , rcvDraftDataTemp.BankAndBranchCd / 1000
                                         , rcvDraftDataTemp.BankAndBranchCd % 1000
                                         , rcvDraftDataTemp.DraftDrawingDate);
                            // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            this._clickflg = true;
                            this.tNedit_BankCd.Focus();
                        }
                        else if (rcvRetListTemp.Count > 1)
                        {
                            if (this._selectForm == null)
                                this._selectForm = new PMTEG09101UC();
                            DialogResult dr=this._selectForm.SelectGoodsGuideShow(this, ref rcvRetListTemp);
                            if (dr == DialogResult.OK)
                            {
                               rcvDraftDataTemp = this._selectForm.RcvDraftDataLst.Clone();
                               // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                               //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO
                               //   , this.ToString()
                               //   , "入力された番号の手形データが既に登録されています。" + "\r\n" + "【手形番号：" + rcvDraftDataTemp.RcvDraftNo + "　銀行・支店コード：" + (rcvDraftDataTemp.BankAndBranchCd / 1000 + "").PadLeft(4, '0') + "‐" + (rcvDraftDataTemp.BankAndBranchCd % 1000 + "").PadLeft(3, '0') + "  振出日：" + rcvDraftDataTemp.DraftDrawingDate.ToString("yyyyMMdd") + "】"
                               //   , 0
                               //   , MessageBoxButtons.OK);
                               SearchMsgShow(emErrorLevel.ERR_LEVEL_INFO, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1
                                            , "入力された番号の手形データが既に登録されています。", ""
                                            , rcvDraftDataTemp.RcvDraftNo
                                            , rcvDraftDataTemp.BankAndBranchCd / 1000
                                            , rcvDraftDataTemp.BankAndBranchCd % 1000
                                            , rcvDraftDataTemp.DraftDrawingDate);
                               // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                            }
                            this._clickflg = true;
                            this.tNedit_BankCd.Focus();
                        }                    
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    return false;
                }
            }
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        /* ----- DEL zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        string draftNo = "";
                        // 検索できない場合、新規する
                        if (this._draftMode == DRAFT_DIV_RCV)
                        {
                            draftNo = this._rcvDraftData.RcvDraftNo;
                            this._rcvDraftData = new RcvDraftData();
                            this.ScreenToDraftData();
                            this._rcvDraftDataOrg = this._rcvDraftData.Clone();
                            this._rcvDraftDataOrg.RcvDraftNo = draftNo;
                        }
                        else
                        {
                            draftNo = this._payDraftData.PayDraftNo;
                            this._payDraftData = new PayDraftData();
                            this.ScreenToDraftData();
                            this._payDraftDataOrg = this._payDraftData.Clone();
                            this._payDraftDataOrg.PayDraftNo = draftNo;
                        }
                           ----- DEL zhuhh 2013/01/10 for Redmine #34123 -----<<<<< */
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        if (this._draftMode == DRAFT_DIV_RCV)
                        {
                            this._rcvDraftData = new RcvDraftData();
                            this.ScreenToDraftData();                           
                        }
                        else
                        {
                            this._payDraftData = new PayDraftData();
                            this.ScreenToDraftData();                            
                        }
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                        break;
                    }
                default:
                    {
                        // UPD 2013/02/15 T.Miyamoto ------------------------------>>>>>
                        //if (this._modeType == DRAFT_DIV_PAY)
                        if (this._draftMode == DRAFT_DIV_PAY)
                        // UPD 2013/02/15 T.Miyamoto ------------------------------<<<<<
                        {
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                                PGID,							        // アセンブリID
                                this.Text,                              // プログラム名称
                                "Search",                               // 処理名称
                                TMsgDisp.OPE_GET,                       // オペレーション
                                "読み込みに失敗しました。",				// 表示するメッセージ
                                status,									// ステータス値
                                this._payDraftDataAcs,					// エラーが発生したオブジェクト
                                MessageBoxButtons.OK,					// 表示するボタン
                                MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        }
                        else
                        {
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                                PGID,							        // アセンブリID
                                this.Text,                              // プログラム名称
                                "Search",                               // 処理名称
                                TMsgDisp.OPE_GET,                       // オペレーション
                                "読み込みに失敗しました。",				// 表示するメッセージ
                                status,									// ステータス値
                                this._rcvDraftDataAcs,					 // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,					// 表示するボタン
                                MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        }

                        return false;
                    }
            }

            return true;
        }
        # endregion 検索処理

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        # region 支払手形情報取得処理(初期起動時)
        /// <summary>
        ///　支払手形情報取得処理(PayDraftInfoGet())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 支払手形情報の取得を行います。</br>
        /// <br>Programmer  : 宮本</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private void PayDraftInfoGet()
        {
            if (this._startType == START_TYPE_CALL)
            {
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    if (this._payDraftData.PayDraftNo != "")
                    {
                        List<PayDraftData> retList = new List<PayDraftData>();
                        PayDraftData paraPayDraftData = new PayDraftData();
                        paraPayDraftData.EnterpriseCode = this._enterpriseCode;
                        paraPayDraftData.PayDraftNo = this._payDraftData.PayDraftNo;
                        int status = this._payDraftDataAcs.Search(out retList, 0, paraPayDraftData);
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            PayDraftData payDraftDataGet = (PayDraftData)retList[0];
                            // 論理削除区分 = 0:有効
                            if (payDraftDataGet.LogicalDeleteCode == DEL_CD_USE)
                                this._payDraftDataInfo = payDraftDataGet.Clone();
                        }
                    }
                }
            }
        }
        # endregion 支払手形情報取得処理(初期起動時)

        # region 支払手形情報チェック処理
        /// <summary>
        ///　支払手形情報チェック処理(PayDraftChk())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 金額と期日の入力チェックを行います。</br>
        /// <br>Programmer  : 宮本</br>
        /// <br>Date        : 2012/10/18</br>
        /// </remarks>
        private bool PayDraftCheck()
        {
            if (this._startType == START_TYPE_CALL)
            {
                if (this._draftMode == DRAFT_DIV_PAY)
                {
                    if (this._payDraftDataInfo.PayDraftNo != "")
                    {
                        string errMsg = "";
                        if (this._payDraftDataInfo.ValidityTerm != this._payDraftData.ValidityTerm)
                        {
                            errMsg = "期日を確認してください。";
                        }
                        if (this._payDraftDataInfo.Payment != this._payDraftData.Payment)
                        {
                            if (errMsg.Length > 0)
                            errMsg = errMsg + "\r\n";
                            errMsg = errMsg + "金額を確認してください。";
                        }
                        if (errMsg.Length > 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                                        , this.ToString()
                                        , errMsg
                                        , 0
                                        , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        # endregion 支払手形情報チェック処理
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        # region 論理削除処理
        /// <summary>
        /// 論理削除クリック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 論理削除ボタンがクリックされたときに発生</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                rcvDraftDataList.Add(this._rcvDraftData);
                status = this._rcvDraftDataAcs.LogicalDelete(ref rcvDraftDataList);
                }
            else
            {
                List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                payDraftDataList.Add(this._payDraftData);
                status = this._payDraftDataAcs.LogicalDelete(ref payDraftDataList);
               }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 画面処理化
                        this.InitDisp();
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion 論理削除処理

        # region 物理削除処理
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 手形データを物理削除します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> deleteList = new List<RcvDraftData>();
                deleteList.Add(this._rcvDraftData);
                // 物理削除
                status = this._rcvDraftDataAcs.Delete(deleteList);
            }
            else
            {
                List<PayDraftData> deleteList = new List<PayDraftData>();
                deleteList.Add(this._payDraftData);
                // 物理削除
                status = this._payDraftDataAcs.Delete(deleteList);
            }        
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 画面処理化
                        this.InitDisp();
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "完全削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 手形データを復活します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (_draftMode == DRAFT_DIV_RCV)
            {
                List<RcvDraftData> rcvDraftDataList = new List<RcvDraftData>();
                rcvDraftDataList.Add(this._rcvDraftData);
                status　= this._rcvDraftDataAcs.Revival(ref rcvDraftDataList);
                // メモリ保存
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._rcvDraftData = rcvDraftDataList[0];
                    this._rcvDraftDataOrg = this._rcvDraftData.Clone();
                }
            }
            else
            {
                List<PayDraftData> payDraftDataList = new List<PayDraftData>();
                payDraftDataList.Add(this._payDraftData);
                status = this._payDraftDataAcs.Revival(ref payDraftDataList);
                // メモリ保存
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._payDraftData = payDraftDataList[0];
                    this._payDraftDataOrg = this._payDraftData.Clone();
                }
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード
                        this._modeType = MODE_TYPE_UPDATE;
                        // コントロールEnabled制御
                        this.SetControlEnabled(UPDATE_MODE);
                        this._initFlg = true;
                        // 画面再表示
                        this.SetDataDisp(false);
                        this._initFlg = false;
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        # endregion

        # region 排他処理
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
           
        }
        # endregion 排他処理
        # endregion

        # region メッセージボックス表示

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         PGID,                              // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010.04.22</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            if (this._draftMode == DRAFT_DIV_PAY)
            {
                dialogResult = TMsgDisp.Show(this, 						    // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         PGID, 		  　　			        // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._payDraftDataAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
            else
            {
                dialogResult = TMsgDisp.Show(this, 						    // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         PGID, 		  　　			        // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._rcvDraftDataAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
            return dialogResult;
        }

        # endregion メッセージボックス表示

        # region 検索メッセージ表示
        // ADD 2013/02/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 検索メッセージ表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 手形データ検索後のメッセージを表示します。</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2013.02.15</br>
        /// </remarks>
        private DialogResult SearchMsgShow(emErrorLevel errLevel, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton
                                          , string message1, string message2
                                          , string PayDraftNo, int BankCd, int BranchCd, DateTime DraftDrawingDate)
        {
            string sMsg = message1
                        + "\r\n" + "　【手形番号　】：" + PayDraftNo
                        + "\r\n" + "　【銀行／支店】：" + (BankCd + "").PadLeft(4, '0') + "‐" + (BranchCd + "").PadLeft(3, '0')
                        + "\r\n" + "　【振出日　　】：" + DraftDrawingDate.ToString("yyyy/MM/dd")
                        + "\r\n" + message2;

            DialogResult dialogResult = TMsgDisp.Show(errLevel, PGID, sMsg, status, msgButton, defaultButton);
            return dialogResult;
        }
        // ADD 2013/02/15 T.Miyamoto ------------------------------<<<<<
        # endregion メッセージボックス表示

        #region オプション情報キャッシュ
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2013/04/02</br>
        /// <br>管理番号　 : 10901273-00 2013/05/15配信分</br>
        /// <br>           : Redmine#35247 仕入総括オプションの調査</br>
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
        #endregion オプション情報キャッシュ
    }
   
}