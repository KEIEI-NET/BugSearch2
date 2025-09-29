//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：請求書設定マスタ
// プログラム概要   ：請求書設定の登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30415 柴田 倫幸
// 修正日    2008/06/18     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤 恵優
// 修正日    2008/09/19     修正内容：不具合対応による共通仕様の展開
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/17     修正内容：Mantis【12828】速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/25     修正内容：得意先コードのチェック処理を修正
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 不具合対応による共通仕様の展開
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 不具合対応による共通仕様の展開
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先マスタ（請求書管理）フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（請求書管理）の設定を行います。</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/18</br>
    /// </remarks>
    public partial class PMKHN09080UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members

        // プロパティ用
        private bool _canNew;
        private bool _canClose;
        private bool _canPrint;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private int _logicalDeleteMode;		      // モード
        private string _enterpriseCode;           // 企業コード

        private CustDmdSetAcs _custDmdSetAcs;	  // 得意先マスタ（請求書管理）アクセスクラス
        private SecInfoAcs _secInfoAcs;           // 拠点マスタアクセスクラス
        private DmdPrtPtnAcs _dmdPrtPtnAcs;       // 請求書印刷パターンマスタアクセスクラス
        private CustDmdSet _custDmdSetClone;	  // 比較用得意先マスタ（請求書管理）クローンクラス
        private Hashtable _custDmdSetTable;	      // 得意先マスタ（請求書管理）テーブル
        private CustomerInfoAcs _customerInfoAcs = null;

        // ADD 2009/04/17 ------>>>
        // 得意先情報キャッシュ
        private ArrayList _customerList;
        // 請求書印刷パターンキャッシュ
        private Dictionary<string, DmdPrtPtn> _dmdPrtPtnDic;
        // ADD 2009/04/17 ------<<<
        
        private const string PROGRAM_ID = "PMKHN09080U";                   // プログラムID
        private const string PROGRAM_NAME = "得意先マスタ（請求書管理）";  // プログラム名称
        private const string CUSTDMDSET_TABLE = "CUSTDMDSET";              // テーブル名

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE        = "削除日";
        private const string SECTIONCODE_TITLE  = "拠点コード";         // MOD 2008/09/12 不具合対応[5086] "コード"→"拠点コード"
        private const string SECTIONNAME_TITLE  = "拠点名";             // MOD 2008/10/01 不具合対応[5961] "拠点名称"→"拠点名"
        private const string CUSTOMERCODE_TITLE = "得意先コード";
        private const string CUSTOMERNAME_TITLE = "得意先名";           // MOD 2008/10/01 不具合対応[5961] "得意先名称"→"得意先名"
        private const string PRINTKIND_TITLE    = "請求書印刷種別";
        private const string PATTERNNAME_TITLE  = "請求書パターン名";   // MOD 2008/10/01 不具合対応[5961] "請求書パターン名称"→"請求書パターン名"

        private const string GUID_TITLE = "GUID";

        // 未設定時に使用
        private const string UNREGISTER = "";

        // 設定種別
        private const string SETKIND_SECTION  = "拠点単位";
        private const string SETKIND_CUSTOMER = "得意先単位";
        private const int SETKIND_SECTION_VALUE = 0;
        private const int SETKIND_CUSTOMER_VALUE= 1;

        // データ入力システム
        private const string DATAINPUTSYSTEM_COMMON = "共通";
        private const string DATAINPUTSYSTEM_REPAIR = "整備";
        private const string DATAINPUTSYSTEM_METAL  = "板金";
        private const string DATAINPUTSYSTEM_CAR    = "車販";

        // 伝票印刷種別
        private const string SLIPPRTKIND_TOTAL   = "合計請求書";
        private const string SLIPPRTKIND_DETAIL  = "明細請求書";
        private const string SLIPPRTKIND_SLIP    = "伝票合計請求書";
        private const string SLIPPRTKIND_RECEIPT = "領収書";
        // 伝票印刷種別ID
        private const int SLIPPRTKINDID_TOTAL   = 50;
        private const int SLIPPRTKINDID_DETAIL  = 60;
        private const int SLIPPRTKINDID_SLIP    = 70;
        private const int SLIPPRTKINDID_RECEIPT = 80;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // ADD 2008/09/12 不具合対応[5084] ---------->>>>>
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

        /// <summary>得意先ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _customerGuideController;
        /// <summary>
        /// 得意先ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>得意先ガイドの制御オブジェクト</value>
        private GeneralGuideUIController CustomerGuideController
        {
            get { return _customerGuideController; }
        }
        // ADD 2008/09/12 不具合対応[5084] ----------<<<<<

        #endregion

        #region Constructor

        /// <summary>
        /// 得意先マスタ（請求書管理）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public PMKHN09080UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 得意先マスタ（請求書管理）アクセスクラスインスタンス化
            this._custDmdSetAcs = new CustDmdSetAcs();

            // 請求書印刷パターンマスタアクセスクラスインスタンス化
            this._dmdPrtPtnAcs = new DmdPrtPtnAcs();

            // 比較用クローン
            this._custDmdSetClone = null;
      
            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;
            this._canDelete = true;		                     // 削除機能
            this._canLogicalDeleteDataExtraction = true;	 // 論理削除データ表示機能
            this._canNew = true;		                     // 新規作成機能
            this._canSpecificationSearch = false;	         // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	         // 列サイズ自動調整機能

            this._dataIndex = -1;
            this._logicalDeleteMode = 0;
            this._custDmdSetAcs     = new CustDmdSetAcs();
            this._custDmdSetTable   = new Hashtable();
            this._secInfoAcs        = new SecInfoAcs(1);
            this._customerInfoAcs   = new CustomerInfoAcs();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // ADD 2008/09/12 不具合対応[5084] ---------->>>>>
            // 拠点ガイドのフォーカス制御
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero,
                this.SectionGd_ultraButton,
                this.SlipPrtKind_tComboEditor
            );

            // 得意先ガイドのフォーカス制御
            _customerGuideController = new GeneralGuideUIController(
                this.tNedit_CustomerCode,
                this.CustomerGd_ultraButton,
                this.SlipPrtKind_tComboEditor
            );
            // ADD 2008/09/12 不具合対応[5084] ----------<<<<<

            // ADD 2009/04/17 ------>>>
            // キャッシュ情報取得
            this.GetCacheData();
            // ADD 2009/04/17 ------<<<
        }

        #endregion

        #region Main
        
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09080UA());
        }
        
        #endregion

        #region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Properties

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
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        
        #endregion

        #region Public Methods
        
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = CUSTDMDSET_TABLE;
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchCustDmdSet(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
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
            // 得意先コード
            appearanceTable.Add(CUSTOMERCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));
            // 得意先名称
            appearanceTable.Add(CUSTOMERNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 請求書印刷種別
            appearanceTable.Add(PRINTKIND_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 請求書パターン名称
            appearanceTable.Add(PATTERNNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
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
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._custDmdSetClone = null;

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
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable custDmdSetTable = new DataTable(CUSTDMDSET_TABLE);
            custDmdSetTable.Columns.Add(DELETE_DATE, typeof(string));

            custDmdSetTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));    // 拠点コード
            custDmdSetTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));    // 拠点名称
            custDmdSetTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));   // 得意先コード
            custDmdSetTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));   // 得意先名称
            custDmdSetTable.Columns.Add(PRINTKIND_TITLE, typeof(string));      // 請求書印刷種別
            custDmdSetTable.Columns.Add(PATTERNNAME_TITLE, typeof(string));    // 請求書パターン名称

            custDmdSetTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(custDmdSetTable);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
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

            // 設定種別
            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTION_VALUE, SETKIND_SECTION);
            this.SetKind_tComboEditor.Items.Add(SETKIND_CUSTOMER_VALUE,SETKIND_CUSTOMER);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;

            // 印刷種別
            this.SlipPrtKind_tComboEditor.Items.Clear();
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_TOTAL, SLIPPRTKIND_TOTAL);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_DETAIL, SLIPPRTKIND_DETAIL);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_SLIP, SLIPPRTKIND_SLIP);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_RECEIPT, SLIPPRTKIND_RECEIPT);
            this.SlipPrtKind_tComboEditor.MaxDropDownItems = this.SlipPrtKind_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                CustDmdSet newCustDmdSet = new CustDmdSet();

                // 印刷種別初期値設定
                newCustDmdSet.SlipPrtKind = SLIPPRTKINDID_TOTAL;

                // パターン
                if (Pattern_tComboEditor.Items.Count > 0)
                {
                    newCustDmdSet.SlipPrtSetPaperId = (string)Pattern_tComboEditor.Value;
                }

                // 得意先マスタ（請求書管理）オブジェクトを画面に展開
                CustDmdSetToScreen(newCustDmdSet);

                // クローン作成
                this._custDmdSetClone = newCustDmdSet.Clone();
                ScreenToCustDmdSet(ref this._custDmdSetClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
                CustDmdSet custDmdSet = (CustDmdSet)this._custDmdSetTable[guid];

                // 得意先マスタ（請求書管理）オブジェクトを画面に展開
                CustDmdSetToScreen(custDmdSet);

                if (custDmdSet.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._custDmdSetClone = custDmdSet.Clone();
                    ScreenToCustDmdSet(ref this._custDmdSetClone);
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
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）オブジェクト画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustDmdSetToScreen(CustDmdSet custDmdSet)
        {
            // 拠点コードは空？
            if ((custDmdSet.SectionCode.Trim() == "") && (this._dataIndex >= 0))
            {
                SetKind_tComboEditor.SelectedIndex = 1;

                // 得意先コード
                tNedit_CustomerCode.DataText = custDmdSet.CustomerCode.ToString();

                // 得意先名称
                CustomerName_tEdit.DataText = GetCustomerName(custDmdSet.CustomerCode);

                // 拠点非表示
                this.SectionCode_Title_Label.Visible = false;
                this.tEdit_SectionCodeAllowZero.Visible = false;
                this.SectionGd_ultraButton.Visible = false;
                this.SectionNm_tEdit.Visible = false;
                this.SectionNm_Label.Visible = false;

                // 得意先表示
                this.Customer_Label.Top = this.SectionCode_Title_Label.Top;
                this.tNedit_CustomerCode.Top = this.Customer_Label.Top;
                this.CustomerGd_ultraButton.Top = this.Customer_Label.Top;
                this.CustomerName_tEdit.Top = this.Customer_Label.Top;
                this.Customer_Label.Visible = true;
                this.tNedit_CustomerCode.Visible = true;
                this.CustomerGd_ultraButton.Visible = true;
                this.CustomerName_tEdit.Visible = true;
            }
            else
            {
                SetKind_tComboEditor.SelectedIndex = 0;

                this.tEdit_SectionCodeAllowZero.Value = custDmdSet.SectionCode.TrimEnd();  // 拠点コード

                // 拠点名称
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == custDmdSet.SectionCode.TrimEnd())
                    {
                        this.SectionNm_tEdit.Value = si.SectionGuideNm;
                        break;
                    }
                }
                // ADD 2008/10/02 不具合対応[5960]---------->>>>>
                // 拠点コード（全社共通）
                if (SectionUtil.IsAllSection(custDmdSet.SectionCode.TrimEnd()))
                {
                    this.SectionNm_tEdit.Value = SectionUtil.ALL_SECTION_NAME;
                }
                // ADD 2008/10/02 不具合対応[5960]----------<<<<<

                // 拠点表示
                this.SectionCode_Title_Label.Visible = true;
                this.tEdit_SectionCodeAllowZero.Visible = true;
                this.SectionGd_ultraButton.Visible = true;
                this.SectionNm_tEdit.Visible = true;
                this.SectionNm_Label.Visible = true;

                // 得意先非表示
                this.Customer_Label.Visible = false;
                this.tNedit_CustomerCode.Visible = false;
                this.CustomerGd_ultraButton.Visible = false;
                this.CustomerName_tEdit.Visible = false;
            }

            // 印刷種別
            SlipPrtKind_tComboEditor.Value = custDmdSet.SlipPrtKind;

            // パターン
            Pattern_tComboEditor.Value = custDmdSet.SlipPrtSetPaperId;
        }

        /// <summary>
        /// 画面情報を得意先マスタ（請求書管理）クラス格納処理
        /// </summary>
        /// <br paramname="stockMngTtlSt">保存するデータクラス</br>
        /// <remarks>
        /// <br>Note       : 画面情報から得意先マスタ（請求書管理）クラスにデータを格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenToCustDmdSet(ref CustDmdSet custDmdSet)
        {
            if (custDmdSet == null)
            {
                // 新規の時
                custDmdSet = new CustDmdSet();
            }

            // 企業コード
            custDmdSet.EnterpriseCode = this._enterpriseCode;

            // 拠点単位？
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点コード
                custDmdSet.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();

                // 得意先コード
                custDmdSet.CustomerCode = 0;
            }
            else
            {
                // 拠点コード
                custDmdSet.SectionCode = "";

                // 得意先コード
                if (this.tNedit_CustomerCode.DataText != "")
                {
                    custDmdSet.CustomerCode = Int32.Parse(this.tNedit_CustomerCode.DataText.TrimEnd());
                }
                else
                {
                    custDmdSet.CustomerCode = 0;
                }
            }

            // 印刷種別
            custDmdSet.SlipPrtKind = (int)this.SlipPrtKind_tComboEditor.Value;

            if (Pattern_tComboEditor.Value != null)
            {
                // パターン
                custDmdSet.SlipPrtSetPaperId = Pattern_tComboEditor.Value.ToString();
            }
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面に一定の値を設定します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SetKind_tComboEditor.SelectedIndex = 0;      // 設定種別
            this.tEdit_SectionCodeAllowZero.Clear();          // 拠点コード
            this.SectionNm_tEdit.Clear();                     // 拠点ガイド名称
            this.tNedit_CustomerCode.Clear();                  // 得意先コード
            this.CustomerName_tEdit.Clear();                  // 得意先名称
            this.SlipPrtKind_tComboEditor.SelectedIndex = 0;  // 印刷種別

            // パターン
            if (this.Pattern_tComboEditor.Items.Count > 0)
            {
                this.Pattern_tComboEditor.SelectedIndex = 0;     
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の保存を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool SaveProc()
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
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            CustDmdSet custDmdSet = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
                custDmdSet = ((CustDmdSet)this._custDmdSetTable[guid]).Clone();
            }
            ScreenToCustDmdSet(ref custDmdSet);

            // ADD 2008/09/12 不具合対応[5093] ---------->>>>>
            // 拠点コードまたは得意先コードが存在していない場合、登録しない。
            if (!ExistsCodeBySetKind(custDmdSet))
            {
                TMsgDisp.Show(
                    this, 								                    // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 		                                        // プログラム名称
                    MethodBase.GetCurrentMethod().Name, 					// 処理名称
                    TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                    "拠点コードまたは得意先コードが存在しません。",         // LITERAL:表示するメッセージ
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				                    // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return false;
            }
            // ADD 2008/09/12 不具合対応[5093] ----------<<<<<

            int status = this._custDmdSetAcs.Write(ref custDmdSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        CustDmdSetToDataSet(custDmdSet.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            PROGRAM_ID, 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCodeAllowZero.Focus();                  
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 		                // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdSetAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
        }

        // ADD 2008/09/12 不具合対応[5093] ---------->>>>>
        /// <summary>
        /// 設定種別に応じて、拠点コードまたは得意先コードが存在するか判定します。
        /// </summary>
        /// <param name="custDmdSet">得意先マスタ（請求書管理）</param>
        /// <returns><c>true</c> :存在する。<br/><c>false</c>:存在しない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5093]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private bool ExistsCodeBySetKind(CustDmdSet custDmdSet)
        {
            // 拠点単位
            if (((int)this.SetKind_tComboEditor.SelectedItem.DataValue).Equals(SETKIND_SECTION_VALUE))
            {
                // 全社共通は拠点マスタに登録されていないため、チェックの対象外
                if (SectionUtil.IsAllSection(custDmdSet.SectionCode)) return true;  // ADD 2008/09/26 不具合対応[5658]

                // DEL 2008/09/26 不具合対応[5657]↓
                //return SectionUtil.ExistsCode(custDmdSet.SectionCode);

                // ADD 2008/09/26 不具合対応[5657]---------->>>>>
                bool existsSectionCode = SectionUtil.ExistsCode(custDmdSet.SectionCode);
                if (!existsSectionCode) this.tEdit_SectionCodeAllowZero.Focus();
                return existsSectionCode;
                // ADD 2008/09/26 不具合対応[5657]----------<<<<<
            }

            // 得意先単位
            if (((int)this.SetKind_tComboEditor.SelectedItem.DataValue).Equals(SETKIND_CUSTOMER_VALUE))
            {
                try
                {
                    string name = GetCustomerName(custDmdSet.CustomerCode, true);
                    return true;
                }
                catch (ArgumentException)
                {
                    this.tNedit_CustomerCode.Focus();   // ADD 2008/09/26 不具合対応[5657]
                    return false;
                }
            }

            return false;
        }
        // ADD 2008/09/12 不具合対応[5093] ----------<<<<<

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点コード
                if (this.tEdit_SectionCodeAllowZero.DataText == "")
                {
                    message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                    control = this.tEdit_SectionCodeAllowZero;
                    result = false;
                }
            }
            else
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.DataText == "")
                {
                    message = this.Customer_Label.Text + "を設定して下さい。";
                    control = this.tNedit_CustomerCode;
                    result = false;
                }
            }

            // 印刷種別
            if (SlipPrtKind_tComboEditor.Text == "")
            {
                message = this.SlipPrtKind_Label.Text + "を設定して下さい。";
                control = this.SlipPrtKind_tComboEditor;
                result = false;
            }

            // パターン
            if (Pattern_tComboEditor.Text == "")
            {
                message = this.Pattern_Label.Text + "を設定して下さい。";
                control = this.Pattern_tComboEditor;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）オブジェクトの論理削除復活を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
            CustDmdSet custDmdSet = ((CustDmdSet)this._custDmdSetTable[guid]).Clone();

            // 得意先マスタ（請求書管理）が存在していない
            if (custDmdSet == null)
            {
                return -1;
            }

            status = this._custDmdSetAcs.Revival(ref custDmdSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        CustDmdSetToDataSet(custDmdSet.Clone(), this._dataIndex);
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 		                // プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdSetAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）ブジェクトの完全削除を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
            CustDmdSet custDmdSet = (CustDmdSet)this._custDmdSetTable[guid];

            // 得意先マスタ（請求書管理）が存在していない
            if (custDmdSet == null)
            {
                return -1;
            }

            // ADD 2008/09/12 不具合対応[5097] ---------->>>>>
            // 設定種別が「拠点単位」の時に全社設定の場合には削除不可
            if (!IsDeletableCondition(custDmdSet))
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
            // ADD 2008/09/12 不具合対応[5097] ----------<<<<<

            status = this._custDmdSetAcs.Delete(custDmdSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._custDmdSetTable.Remove((Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex].Delete();
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 				        // プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdSetAcs,			    // エラーが発生したオブジェクト
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
        /// <br>Date       : 2008/06/18</br>
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
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, false);

                        // 初期フォーカスをセット
                        this.SetKind_tComboEditor.Focus();

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
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false, false);

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
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, true);

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        // 初期フォーカスをセット
                        this.Pattern_tComboEditor.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <param name="update">更新フラグ</param>        
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled, bool update)
        {
            this.SetKind_tComboEditor.Enabled = enabled;         // 設定種別
            this.tEdit_SectionCodeAllowZero.Enabled = enabled;   // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;        // 拠点ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;              // 拠点ガイド名称
            this.tNedit_CustomerCode.Enabled = enabled;          // 得意先コード
            this.CustomerGd_ultraButton.Enabled = enabled;       // 得意先ガイドボタン
            this.CustomerName_tEdit.Enabled = enabled;           // 得意先名称
            this.SlipPrtKind_tComboEditor.Enabled = enabled;     // 印刷種別
            this.Pattern_tComboEditor.Enabled = enabled;         // パターン

            // 更新時処理？
            if (update == true)
            {
                SetKind_tComboEditor.Enabled = false;
                tEdit_SectionCodeAllowZero.Enabled = false;
                SectionGd_ultraButton.Enabled = false;
                SectionNm_tEdit.Enabled = false;
                tNedit_CustomerCode.Enabled = false;
                CustomerGd_ultraButton.Enabled = false;
                CustomerName_tEdit.Enabled = false;
                SlipPrtKind_tComboEditor.Enabled = false;
            }

            // ちらつき防止の為
            this.Enabled = true;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
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
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int SearchCustDmdSet(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList custDmdSets = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._custDmdSetAcs.SearchAll(out custDmdSets, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (CustDmdSet custDmdSet in custDmdSets)
                        {
                            if (this._custDmdSetTable.ContainsKey(custDmdSet.FileHeaderGuid) == false)
                            {
                                CustDmdSetToDataSet(custDmdSet.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:    // MOD 2008/09/12 不具合対応[5076] default:→case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 			            // プログラム名称
                            "SearchStockMngTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdSetAcs, 		    	// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            if (custDmdSets == null) custDmdSets = new ArrayList(); // ADD 2008/09/12 不具合対応[5076]
            // ADD 2008/09/26 不具合対応[5076]↓マスメンフレーム側でエラーとして扱ってしまうため、正常値に改算
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_ERROR)) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            totalCnt = custDmdSets.Count;

            return status;
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）オブジェクト展開処理
        /// </summary>
        /// <param name="custDmdSet">得意先マスタ（請求書管理）オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustDmdSetToDataSet(CustDmdSet custDmdSet, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (custDmdSet.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][DELETE_DATE] = custDmdSet.UpdateDateTime;
            }

            if (custDmdSet.CustomerCode == 0)
            {
                // 拠点コード
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][SECTIONCODE_TITLE] = custDmdSet.SectionCode.TrimEnd();
                // 拠点名称
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == custDmdSet.SectionCode.TrimEnd())
                    {
                        this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                        break;
                    }
                }
                // ADD 2008/10/02 不具合対応[5960]---------->>>>>
                // 拠点コード（全社共通）
                if (SectionUtil.IsAllSection(custDmdSet.SectionCode.TrimEnd()))
                {
                    this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][SECTIONNAME_TITLE] = SectionUtil.ALL_SECTION_NAME;
                }
                // ADD 2008/10/02 不具合対応[5960]----------<<<<<

                // 2009.03.27 30413 犬飼 データセットの得意先コードを設定 >>>>>>START
                // 得意先コード
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][CUSTOMERCODE_TITLE] = 0;
                // 2009.03.27 30413 犬飼 データセットの得意先コードを設定 <<<<<<END
            }
            else
            {
                // 得意先コード
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][CUSTOMERCODE_TITLE] = custDmdSet.CustomerCode;

                // 得意先名称
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][CUSTOMERNAME_TITLE] = GetCustomerName(custDmdSet.CustomerCode);

                // 2009.03.27 30413 犬飼 データセットの拠点コードを設定 >>>>>>START
                // 拠点コード
                this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][SECTIONCODE_TITLE] = "";
                // 2009.03.27 30413 犬飼 データセットの拠点コードを設定 <<<<<<END
            }

            // 印刷種別
            switch (custDmdSet.SlipPrtKind)
            {
                case SLIPPRTKINDID_TOTAL:
                    wrkstr = SLIPPRTKIND_TOTAL;     // 合計請求書
                    break;
                case SLIPPRTKINDID_DETAIL:
                    wrkstr = SLIPPRTKIND_DETAIL;    // 明細請求書
                    break;
                case SLIPPRTKINDID_SLIP:
                    wrkstr = SLIPPRTKIND_SLIP;      // 伝票合計請求書
                    break;
                case SLIPPRTKINDID_RECEIPT:
                    wrkstr = SLIPPRTKIND_RECEIPT;   // 領収書
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][PRINTKIND_TITLE] = wrkstr;

            // 請求書パターン名称
            this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][PATTERNNAME_TITLE] = SetPrintPatternName(custDmdSet.SlipPrtKind,custDmdSet.SlipPrtSetPaperId);

            // GUID
            this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[index][GUID_TITLE] = custDmdSet.FileHeaderGuid;

            if (this._custDmdSetTable.ContainsKey(custDmdSet.FileHeaderGuid) == true)
            {
                this._custDmdSetTable.Remove(custDmdSet.FileHeaderGuid);
            }
            this._custDmdSetTable.Add(custDmdSet.FileHeaderGuid, custDmdSet);

        }

        /// <summary>
        /// 得意先マスタ（請求書管理）オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
            CustDmdSet custDmdSet = ((CustDmdSet)this._custDmdSetTable[guid]).Clone();

            // 得意先マスタ（請求書管理）が存在していない
            if (custDmdSet == null)
            {
                return -1;
            }

            // ADD 2008/09/12 不具合対応[5097] ---------->>>>>
            // 設定種別が「拠点単位」の時に全社設定の場合には削除不可
            if (!IsDeletableCondition(custDmdSet))
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
            // ADD 2008/09/12 不具合対応[5097] ----------<<<<<

            status = this._custDmdSetAcs.LogicalDelete(ref custDmdSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        CustDmdSetToDataSet(custDmdSet.Clone(), this._dataIndex);
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 				        // プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdSetAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/12 不具合対応[5097] ---------->>>>>
        /// <summary>
        /// 削除できる条件か判定します。
        /// </summary>
        /// <param name="custDmdSet">得意先マスタ（請求書管理）</param>
        /// <returns><c>true</c> :削除可<br/><c>false</c>:削除不可</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5097]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private static bool IsDeletableCondition(CustDmdSet custDmdSet)
        {
            return !SectionUtil.IsAllSection(custDmdSet.SectionCode);
        }
        // ADD 2008/09/12 不具合対応[5097] ----------<<<<<

        /// <summary>
        /// 印刷パターン設定処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷パターンをPattern_tComboEditorに設定する</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetPrintPattern(int slipPrtKind)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            Pattern_tComboEditor.Items.Clear();

            // パターン取得
            ArrayList dmdPrtPtnList = null;
            status = this._dmdPrtPtnAcs.SearchAllPrintKindGroup(out dmdPrtPtnList, this._enterpriseCode, slipPrtKind);
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        Pattern_tComboEditor.Clear();

                        // 読み込んだインスタンスのそれぞれをデータセットに展開
                        foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
                        {
                            if (dmdPrtPtn.LogicalDeleteCode == 0)
                            {
                                Pattern_tComboEditor.Items.Add(dmdPrtPtn.SlipPrtSetPaperId, dmdPrtPtn.SlipComment);
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 全件読み込み完了の場合は、何もしない
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:    // MOD 2008/09/12 不具合対応[5096] default:→case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 			            // プログラム名称
                            "SetPrintPattern", 	    	        // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
        }

        /// <summary>
        /// 印刷パターン設定処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷パターンをPattern_tComboEditorに設定する</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string SetPrintPatternName(int slipPrtKind, string slipPrtSetPaperId)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();
            string slipComment = "";

            // ADD 2009/04/17 ------>>>
            string key = slipPrtKind.ToString() + "-" + slipPrtSetPaperId;
            if (_dmdPrtPtnDic.ContainsKey(key))
            {
                dmdPrtPtn = _dmdPrtPtnDic[key];
                return dmdPrtPtn.SlipComment;
            }
            // ADD 2009/04/17 ------<<<
            
            // パターン取得
            status = this._dmdPrtPtnAcs.Read(out dmdPrtPtn, this._enterpriseCode, slipPrtKind, slipPrtSetPaperId);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        slipComment = dmdPrtPtn.SlipComment;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 全件読み込み完了の場合は、何もしない
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:    // MOD 2008/09/12 不具合対応[5096] default:→case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            PROGRAM_NAME, 			            // プログラム名称
                            "SetPrintPatternName", 	    	    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return (slipComment);
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            // DEL 2008/09/12 不具合対応[5093] ---------->>>>>
            //string customerName = "";
            //CustomerInfo customerInfo = new CustomerInfo();

            //try
            //{
            //    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
            //    if (status == 0)
            //    {
            //        customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
            //    }
            //}
            //catch
            //{
            //    customerName = "";
            //}

            //return customerName;
            // DEL 2008/09/12 不具合対応[5093] ----------<<<<<

            return GetCustomerName(customerCode, false);
        }

        // ADD 2008/09/12 不具合対応[5093] ---------->>>>>
        /// <summary>
        /// 得意先名称を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">該当する得意先コードがない場合、例外を投入するフラグ</param>
        /// <returns>得意先名称</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>が<c>true</c>のとき、
        /// 得意先マスタに該当する得意先コードが存在しない場合、投入されます。
        /// </exception>
        /// <remarks>
        /// <br>Note       : 不具合対応[5093]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private string GetCustomerName(
            int customerCode,
            bool throwsExceptionWhenCodeIsNotFound
        )
        {
            string customerName = string.Empty;
            CustomerInfo customerInfo = new CustomerInfo();

            bool codeIsFound = false;
            try
            {
                // DEL 2009/04/18 ------>>>
                //int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                //if (status.Equals(0))
                //{
                //    codeIsFound = true;
                //    // DEL 2008/10/07 不具合対応[5095]↓
                //    //customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                //    customerName = customerInfo.CustomerSnm.Trim(); // MOD 2008/10/07 不具合対応[5095]
                //}
                // DEL 2009/04/18 ------<<<
                
                // ADD 2009/04/18 ------>>>
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        codeIsFound = true;     // ADD 2009/05/25
                        customerName = customerSearchRet.Snm.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        codeIsFound = true;     // ADD 2009/05/25
                        customerName = customerInfo.CustomerSnm.Trim();
                    }
                }
                // ADD 2009/04/18 ------<<<
            }
            catch
            {
                customerName = string.Empty;
            }

            if (!codeIsFound && throwsExceptionWhenCodeIsNotFound)
            {
                throw new ArgumentException("customerCode(=" + customerCode.ToString() + ") is not found.");
            }

            return customerName;
        }
        // ADD 2008/09/12 不具合対応[5093] ----------<<<<<

        // ADD 2009/04/17 ------>>>
        /// <summary>
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先と倉庫の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 得意先名称リスト取得
            this.GetCustomerNameList();
            // 印刷パターン名称リスト取得処理
            this.GetPrintPatternList();
        }

        /// <summary>
        /// 得意先名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称のリストを取得します。</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // 論理削除データは読み込まない
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// 印刷パターン名称リスト取得処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷パターン名称のリストを取得します。</br>
        /// </remarks>
        private void GetPrintPatternList()
        {
            int status;
            ArrayList dmdPrtPtnList = null;

            _dmdPrtPtnDic = new Dictionary<string, DmdPrtPtn>();

            status = this._dmdPrtPtnAcs.SearchAll(out dmdPrtPtnList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
                {
                    string key = dmdPrtPtn.SlipPrtKind.ToString() + "-" + dmdPrtPtn.SlipPrtSetPaperId;
                    if (!_dmdPrtPtnDic.ContainsKey(key))
                    {
                        _dmdPrtPtnDic.Add(key, dmdPrtPtn);
                    }
                }
            }
        }
        // ADD 2009/04/17 ------<<<
        
        #endregion

        #region Control Event

        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面構築
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            if (!SaveProc())
            {
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

                CustDmdSet newCustDmdSet = new CustDmdSet();

                // 印刷種別初期値設定
                newCustDmdSet.SlipPrtKind = SLIPPRTKINDID_TOTAL;

                // パターン
                if (Pattern_tComboEditor.Items.Count > 0)
                {
                    newCustDmdSet.SlipPrtSetPaperId = (string)Pattern_tComboEditor.Value;
                }

                // 得意先マスタ（請求書管理）オブジェクトを画面に展開
                CustDmdSetToScreen(newCustDmdSet);

                // クローン作成
                this._custDmdSetClone = newCustDmdSet.Clone();
                ScreenToCustDmdSet(ref this._custDmdSetClone);

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
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                CustDmdSet compareCustDmdSet = new CustDmdSet();
                compareCustDmdSet = this._custDmdSetClone.Clone();
                ScreenToCustDmdSet(ref compareCustDmdSet);

                // 最初に取得した画面情報と比較
                if (!(this._custDmdSetClone.Equals(compareCustDmdSet)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
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
                                this.Cancel_Button.Focus();
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
        /// tRetKeyControl イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Returnキーが押されたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "Pattern_tComboEditor":      // パターン
                case "Ok_Button":
                    {
                        if (this._dataIndex < 0)
                        {
                            if (SetKind_tComboEditor.SelectedIndex == 0)
                            {
                                if (ModeChangeProcSection())
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
                                }
                            }
                            else
                            {
                                if (ModeChangeProcCustomer())
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                        }
                        break;
                    }
            }
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 不具合対応[6226]
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;
            }
            finally
            {
                this.Cursor = Cursors.Default;
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
        /// <br>Date       : 2008/06/18</br>
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
        /// 完全削除ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero.Text != "")
            {
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero.Text.Trim());

                // ADD 2008/09/26 不具合対応[5658]---------->>>>>
                if (SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero.Text))
                {
                    this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                }
                // ADD 2008/09/26 不具合対応[5658]----------<<<<<
            }
            else
            {
                // uiSetControlが"00"に補正するので、拠点名称は全社共通を設定
                this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;   // MOD 2008/09/26 不具合対応[5658] = "";→= SectionUtil.ALL_SECTION_NAME;
            }
        }

        /// <summary>
        /// Form.Load イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void PMKHN09080UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
            this.Cancel_Button.ImageList = imageList24;   
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;         // 保存ボタン
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	 // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	 // 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            ScreenInitialSetting();

            // ADD 2008/09/12 不具合対応[5084] ---------->>>>>
            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();

            // 得意先ガイドのフォーカス制御の開始
            CustomerGuideController.StartControl();
            // ADD 2008/09/12 不具合対応[5084] ----------<<<<<
        }

        /// <summary>
        /// Form.Closing イベント(PMKHN09080UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void PMKHN09080UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._custDmdSetClone = null;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
            if (this._canClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント(PMKHN09080UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void PMKHN09080UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
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

            this.Initial_Timer.Enabled = true;

            // 画面クリア
            ScreenClear();
        }

        /// <summary>
        /// Control.ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 印刷種別の値がユーザーによって変更された時に発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SlipPrtKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // パターン取得
            SetPrintPattern((int)SlipPrtKind_tComboEditor.Value);

            if (Pattern_tComboEditor.Items.Count > 0)
            {
                Pattern_tComboEditor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 得意先コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustomerGd_ultraButton_Click(object sender, EventArgs e)
        {
            string previousText = this.tNedit_CustomerCode.Text.Trim(); // ADD 2008/10/09 不具合対応[6226]
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // ADD 2008/10/09 不具合対応[6226]---------->>>>>
                if (this.tNedit_CustomerCode.Text.Trim().Equals(previousText))
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                }
                // ADD 2008/10/09 不具合対応[6226]----------<<<<<
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
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCode.DataText = customerSearchRet.CustomerCode.ToString();
            
            // 得意先名称
            this.CustomerName_tEdit.DataText = customerSearchRet.Snm.Trim();   // MOD 2008/09/26 不具合対応[5095] .Name→.Snm
        }

        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別が変更されたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 拠点単位？
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTION)
            {
                // 拠点表示
                this.SectionCode_Title_Label.Visible = true;
                this.tEdit_SectionCodeAllowZero.Visible = true;
                this.SectionGd_ultraButton.Visible = true;
                this.SectionNm_tEdit.Visible = true;
                this.SectionNm_Label.Visible = true;

                // 得意先非表示
                this.Customer_Label.Visible = false;
                this.tNedit_CustomerCode.Visible = false;
                this.CustomerGd_ultraButton.Visible = false;
                this.CustomerName_tEdit.Visible = false;
            }
            else
            {
                // 拠点非表示
                this.SectionCode_Title_Label.Visible = false;
                this.tEdit_SectionCodeAllowZero.Visible = false;
                this.SectionGd_ultraButton.Visible = false;
                this.SectionNm_tEdit.Visible = false;
                this.SectionNm_Label.Visible = false;

                // 得意先非表示
                this.Customer_Label.Visible = true;
                this.tNedit_CustomerCode.Visible = true;
                this.CustomerGd_ultraButton.Visible = true;
                this.CustomerName_tEdit.Visible = true;
                this.Customer_Label.Top = this.SectionCode_Title_Label.Top;
                this.tNedit_CustomerCode.Top = this.SectionCode_Title_Label.Top;
                this.CustomerGd_ultraButton.Top = this.SectionCode_Title_Label.Top;
                this.CustomerName_tEdit.Top = this.SectionCode_Title_Label.Top;
            }
        }

        /// <summary>
        /// Leave イベント(tNedit_CustomerCode)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 30415 柴田 倫幸</br>
        /// <br>Date        : 2008/06/18</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            // 得意先コードが未入力の場合
            if (this.tNedit_CustomerCode.DataText.Trim() == "")
            {
                this.CustomerName_tEdit.DataText = "";
                return;
            }

            // 得意先コード取得
            int customerCode = this.tNedit_CustomerCode.GetInt();

            // 得意先名称取得
            this.CustomerName_tEdit.DataText = GetCustomerName(customerCode);
        }

        #endregion

        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // ADD 2009/04/17 ------>>>
            this._secInfoAcs.ResetSectionInfo();
            this.GetCacheData();
            // ADD 2009/04/17 ------<<<

            if (SlipPrtKind_tComboEditor.Value != null)
            {
                string index = (string)Pattern_tComboEditor.Value;

                SetPrintPattern((int)SlipPrtKind_tComboEditor.Value);

                Pattern_tComboEditor.Value = index;

                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "PMKHN09080U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
            }
        }
        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理(拠点別)
        /// </summary>
        private bool ModeChangeProcSection()
        {
            string msg = "入力されたコードの請求書設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');
            // 印刷種別
            string slipPrtKind = (string)SlipPrtKind_tComboEditor.SelectedItem.DisplayText;

            for (int i = 0; i < this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][SECTIONCODE_TITLE];
                string dsSlipPrtKind = (string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][PRINTKIND_TITLE];
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][CUSTOMERCODE_TITLE]);
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (slipPrtKind.Equals(dsSlipPrtKind)) &&
                    (dsCustomerCode == 0))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの請求書設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、印刷種別のクリア
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionNm_tEdit.Clear();
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SetPrintPattern((Int32)this.SlipPrtKind_tComboEditor.Value);
                        Pattern_tComboEditor.SelectedIndex = 0;
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの請求書設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
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
                                // 拠点コード、印刷種別のクリア
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionNm_tEdit.Clear();
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SetPrintPattern((Int32)this.SlipPrtKind_tComboEditor.Value);
                                Pattern_tComboEditor.SelectedIndex = 0;
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// モード変更処理(得意先別)
        /// </summary>
        private bool ModeChangeProcCustomer()
        {
            // 得意先コード
            int customerCode = tNedit_CustomerCode.GetInt();
            // 伝票印刷種別
            string slipPrtKind = (string)SlipPrtKind_tComboEditor.SelectedItem.DisplayText;

            for (int i = 0; i < this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][CUSTOMERCODE_TITLE]);
                string dsSlipPrtKind = (string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][PRINTKIND_TITLE];
                if ((customerCode == dsCustomerCode) &&
                    (slipPrtKind.Equals(dsSlipPrtKind)))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[CUSTDMDSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの請求書設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コード、印刷種別のクリア
                        tNedit_CustomerCode.Clear();
                        CustomerName_tEdit.Clear();
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SetPrintPattern((Int32)this.SlipPrtKind_tComboEditor.Value);
                        Pattern_tComboEditor.SelectedIndex = 0;
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの請求書設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 得意先コード、印刷種別のクリア
                                tNedit_CustomerCode.Clear();
                                CustomerName_tEdit.Clear();
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SetPrintPattern((Int32)this.SlipPrtKind_tComboEditor.Value);
                                Pattern_tComboEditor.SelectedIndex = 0;
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}