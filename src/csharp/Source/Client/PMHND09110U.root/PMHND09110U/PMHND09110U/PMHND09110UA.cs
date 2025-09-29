//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 検品全体設定
// プログラム概要   : 検品全体設定の設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// Programmer       : 3H 楊善娟                                               //
// Date             : K2017/06/02                                             //
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検品全体設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品全体設定の設定を行います。</br>
    /// <br>Programmer  : 3H 楊善娟</br>
    /// <br>Date        : K2017/06/02</br>
    /// </remarks>
    public partial class PMHND09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members
        // テーブル名
        private const string INSPECTTTLST_TABLE = "INSPECTTTLST";

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string GUID_TITLE = "GUID";
        private const string DELETE_DATE = "削除日";
        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONNAME_TITLE = "拠点名";

        // 取寄検品区分
        private const string ORDERINSPECTCODE_TITLE = "取寄検品区分";
        private const string ORDERINSPECTCODE_YES = "する";
        private const string ORDERINSPECTCODE_NO = "しない";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // アセンブリＩＤまたはクラスＩＤ
        private const string ctPgId = "PMHND09110UA";
        // プログラム名称
        private const string ctPgName = "検品全体設定";

        // 未設定時に使用
        private const string UNREGISTER = "";

        // プロパティ用
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canPrint;
        private bool _canClose;
        private int _logicalDeleteMode;
        private int _indexBuf;

        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        private bool isError = false;

        private Hashtable _inspectTtlStTable;      // 検品全体設定テーブル
        private string _enterpriseCode;            // 企業コード取得
        private InspectTtlStAcs _inspectTtlStAcs;  // 検品全体設定アクセスクラス
        private SecInfoAcs _secInfoAcs;            // 拠点マスタアクセスクラス
        private InspectTtlSt _inspectTtlStClone;   // 比較用検品全体設定クローンクラス

        /// <summary>全社設定の検品全体設定オブジェクト</summary>
        /// <remarks>Search時に初期化されます。</remarks>
        private InspectTtlSt _inspectTtlStOfAllSection;

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
        #endregion

        #region Constructor
        /// <summary>
        /// 検品全体設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品全体設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public PMHND09110UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 伝票初期値設定アクセスクラスインスタンス化
            this._inspectTtlStAcs = new InspectTtlStAcs();

            // 比較用クローン
            this._inspectTtlStClone = null;

            // コード参照変更フラグ
            //this._changeFlg = false;

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
            this._inspectTtlStAcs = new InspectTtlStAcs();
            this._inspectTtlStTable = new Hashtable();
            this._secInfoAcs = new SecInfoAcs(1);

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点ガイドのフォーカス制御     
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.OrderInspectCode_tComboEditor
            );
        }
        #endregion

        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMHND09110UA());
        }
        #endregion

        #region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        # region Properties
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

        /// <summary>
        /// 全社設定の検品全体設定オブジェクトを取得します。
        /// </summary>
        /// <value>全社設定の検品全体設定オブジェクト</value>
        /// <remarks>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private InspectTtlSt InspectTtlStOfAllSection
        {
            get { return _inspectTtlStOfAllSection ?? new InspectTtlSt(); }
            set { _inspectTtlStOfAllSection = value; }
        }
        # endregion

        # region Public Methods
        /// <summary>
        ///	印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note			:	（未実装）</br>
        /// <br>Programmer      : 3H 楊善娟</br>
        /// <br>Date            : K2017/06/02</br>
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = INSPECTTTLST_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchInspectTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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

            // 取寄検品区分
            appearanceTable.Add(ORDERINSPECTCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region Private Methods
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
            this._inspectTtlStClone = null;
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable inspectTtlStTable = new DataTable(INSPECTTTLST_TABLE);
            inspectTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            inspectTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            inspectTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            inspectTtlStTable.Columns.Add(ORDERINSPECTCODE_TITLE, typeof(string));
            inspectTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(inspectTtlStTable);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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

            // 取寄検品区分
            this.OrderInspectCode_tComboEditor.Items.Clear();
            this.OrderInspectCode_tComboEditor.Items.Add(0, ORDERINSPECTCODE_NO);
            this.OrderInspectCode_tComboEditor.Items.Add(1, ORDERINSPECTCODE_YES);
            this.OrderInspectCode_tComboEditor.MaxDropDownItems = this.OrderInspectCode_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                InspectTtlSt newInspectTtlSt = new InspectTtlSt();
                // 検品全体設定オブジェクトを画面に展開
                InspectTtlStToScreen(newInspectTtlSt);

                // クローン作成
                this._inspectTtlStClone = newInspectTtlSt.Clone();
                DispToInspectTtlSt(ref this._inspectTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                InspectTtlSt inspectTtlSt = (InspectTtlSt)this._inspectTtlStTable[guid];

                // 検品全体設定オブジェクトを画面に展開
                InspectTtlStToScreen(inspectTtlSt);

                if (inspectTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._inspectTtlStClone = inspectTtlSt.Clone();
                    DispToInspectTtlSt(ref this._inspectTtlStClone);
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
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票初期値設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void InspectTtlStToScreen(InspectTtlSt inspectTtlSt)
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero2.Value = inspectTtlSt.SectionCode.TrimEnd();
            // 拠点名称
            if (this.tEdit_SectionCodeAllowZero2.Text == "00")
            {
                this.SectionNm_tEdit.Value = "全社共通";
            }
            else
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == inspectTtlSt.SectionCode.TrimEnd())
                    {
                        this.SectionNm_tEdit.Value = si.SectionGuideNm;
                        break;
                    }
                }
            }
            // 取寄検品区分
            this.OrderInspectCode_tComboEditor.SelectedIndex = inspectTtlSt.OrderInspectCode;
        }

        /// <summary>
        /// 画面情報を検品全体設定クラス格納処理(チェック用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から検品全体設定クラスにデータを格納します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void DispToInspectTtlSt(ref InspectTtlSt inspectTtlSt)
        {
            if (inspectTtlSt == null)
            {
                // 新規の時
                inspectTtlSt = new InspectTtlSt();
            }

            inspectTtlSt.EnterpriseCode = this._enterpriseCode;

            // 取寄検品区分
            if (this.OrderInspectCode_tComboEditor.SelectedIndex < 0)
            {
                inspectTtlSt.OrderInspectCode = 0;
            }
            else
            {
                inspectTtlSt.OrderInspectCode = this.OrderInspectCode_tComboEditor.SelectedIndex;
            }
            // 拠点コード
            inspectTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd();
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                inspectTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面に一定の値を設定します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 取寄検品区分
            this.OrderInspectCode_tComboEditor.SelectedIndex = 0;
            // コード参照入力変更フラグ初期化
            this.tEdit_SectionCodeAllowZero2.Clear();  // 拠点コード
            this.SectionNm_tEdit.Clear();              // 拠点ガイド名称
        }

        /// <summary>
        /// 検品全体設定保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の保存を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
                    ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
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

            InspectTtlSt inspectTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                inspectTtlSt = ((InspectTtlSt)this._inspectTtlStTable[guid]).Clone();
            }
            DispToInspectTtlSt(ref inspectTtlSt);

            int status = this._inspectTtlStAcs.Write(ref inspectTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        if (IsAllSection(inspectTtlSt))
                        {
                            this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Clear();
                            this._inspectTtlStTable.Clear();
                            int totalCount = 0;
                            const int READ_COUNT = 0;
                            SearchInspectTtlSt(ref totalCount, READ_COUNT);
                            break;
                        }

                        InspectTtlStToDataSet(inspectTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            ctPgId, 							    // アセンブリＩＤまたはクラスＩＤ
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
                            ctPgName, 				            // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._inspectTtlStAcs,			    // エラーが発生したオブジェクト
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
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 検品全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定オブジェクトの論理削除復活を行います</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            InspectTtlSt inspectTtlSt = ((InspectTtlSt)this._inspectTtlStTable[guid]).Clone();

            // 検品全体設定が存在していない
            if (inspectTtlSt == null)
            {
                return -1;
            }

            status = this._inspectTtlStAcs.Revival(ref inspectTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        InspectTtlStToDataSet(inspectTtlSt.Clone(), this._dataIndex);
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
                            ctPgName, 				            // プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._inspectTtlStAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 検品全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定ブジェクトの完全削除を行います</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            InspectTtlSt inspectTtlSt = (InspectTtlSt)this._inspectTtlStTable[guid];

            // 検品全体設定が存在していない
            if (inspectTtlSt == null)
            {
                return -1;
            }

            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(inspectTtlSt))
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

            status = this._inspectTtlStAcs.Delete(inspectTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._inspectTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex].Delete();
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
                            ctPgName, 				            // プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._inspectTtlStAcs,			    // エラーが発生したオブジェクト
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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

                        // ちらつき防止の為
                        this.Enabled = true;

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

                        // ちらつき防止の為
                        this.Enabled = true;

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
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGd_ultraButton.Enabled = false;
                        this.SectionNm_tEdit.Enabled = false;

                        // ちらつき防止の為
                        this.Enabled = true;

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;      // 拠点コード
            this.SectionGd_ultraButton.Enabled = enabled;            // ガイドボタン 
            this.SectionNm_tEdit.Enabled = enabled;                  // 拠点ガイド名称
            this.OrderInspectCode_tComboEditor.Enabled = enabled;    // 取寄検品区分
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private int SearchInspectTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList inspectTtlSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._inspectTtlStAcs.SearchAll(out inspectTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (InspectTtlSt inspectTtlSt in inspectTtlSts)
                        {
                            // 全社設定の値を保持
                            if (IsAllSection(inspectTtlSt))
                            {
                                InspectTtlStOfAllSection = inspectTtlSt;
                            }

                            if (this._inspectTtlStTable.ContainsKey(inspectTtlSt.FileHeaderGuid) == false)
                            {
                                InspectTtlStToDataSet(inspectTtlSt.Clone(), index);
                                index++;
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
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
                            ctPgName, 			                // プログラム名称
                            "SearchInspectTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._inspectTtlStAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = inspectTtlSts.Count;

            return status;
        }

        /// <summary>
        /// 検品全体設定オブジェクト展開処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 検品全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void InspectTtlStToDataSet(InspectTtlSt inspectTtlSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (inspectTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][DELETE_DATE] = inspectTtlSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = inspectTtlSt.SectionCode.TrimEnd();
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == inspectTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            if (inspectTtlSt.SectionCode.Trim().Equals("00"))
            {
                this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }

            // 取寄検品区分
            switch (inspectTtlSt.OrderInspectCode)
            {
                case 0:
                    wrkstr = ORDERINSPECTCODE_NO;       // しない
                    break;
                case 1:
                    wrkstr = ORDERINSPECTCODE_YES;      // する
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][ORDERINSPECTCODE_TITLE] = wrkstr;
            // GUID
            this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[index][GUID_TITLE] = inspectTtlSt.FileHeaderGuid;

            if (this._inspectTtlStTable.ContainsKey(inspectTtlSt.FileHeaderGuid) == true)
            {
                this._inspectTtlStTable.Remove(inspectTtlSt.FileHeaderGuid);
            }
            this._inspectTtlStTable.Add(inspectTtlSt.FileHeaderGuid, inspectTtlSt);

        }

        /// <summary>
        /// 検品全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            InspectTtlSt inspectTtlSt = ((InspectTtlSt)this._inspectTtlStTable[guid]).Clone();

            // 検品全体設定が存在していない
            if (inspectTtlSt == null)
            {
                return -1;
            }

            // 拠点コードが全社共通の場合、削除不可
            if (IsAllSection(inspectTtlSt))
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

            status = this._inspectTtlStAcs.LogicalDelete(ref inspectTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        InspectTtlStToDataSet(inspectTtlSt.Clone(), this._dataIndex);
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
                            ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
                            ctPgName, 				            // プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._inspectTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 全社設定か判定します。
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定</param>
        /// <returns><c>true</c> :全社設定である。<br/><c>false</c>:全社設定ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5290]にて追加</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private static bool IsAllSection(InspectTtlSt inspectTtlSt)
        {
            return SectionUtil.IsAllSection(inspectTtlSt.SectionCode);
        }
        #endregion

        #region Control Event
        /// <summary>
        /// Form.Load イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発生します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void PMHND09110UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;                     // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;                 // 閉じるボタン

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;        // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;   // 閉じるボタン

            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            ScreenInitialSetting();

            // 取寄検品区分
            OrderInspectCode_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);

            // 拠点ガイドのフォーカス制御の開始
            SectionGuideController.StartControl();
        }

        /// <summary>
        /// Form.Closing イベント(PMHND09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void PMHND09110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._inspectTtlStClone = null;

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
        /// Form.VisibleChanged イベント(PMHND09110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void PMHND09110UA_VisibleChanged(object sender, EventArgs e)
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
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer  : 3H 楊善娟</br>
        /// <br>Date        : K2017/06/02</br>
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
        /// <br>Programmer      : 3H 楊善娟</br>
        /// <br>Date            : K2017/06/02</br>
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

                InspectTtlSt newInspectTtlSt = new InspectTtlSt();
                // 見積初期値設定オブジェクトを画面に展開
                InspectTtlStToScreen(newInspectTtlSt);

                // クローン作成
                this._inspectTtlStClone = newInspectTtlSt.Clone();
                DispToInspectTtlSt(ref this._inspectTtlStClone);

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
        /// <br>Programmer      : 3H 楊善娟</br>
        /// <br>Date            : K2017/06/02</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                InspectTtlSt compareInspectTtlSt = new InspectTtlSt();
                compareInspectTtlSt = this._inspectTtlStClone.Clone();
                DispToInspectTtlSt(ref compareInspectTtlSt);

                // 最初に取得した画面情報と比較
                if (!(this._inspectTtlStClone.Equals(compareInspectTtlSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
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
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
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
        /// <br>Programmer      : 3H 楊善娟</br>
        /// <br>Date            : K2017/06/02</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":
                    {
                        // 拠点コードが存在していない場合、登録しない。
                        if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text) && !SectionUtil.ExistsCode(this.tEdit_SectionCodeAllowZero2.Text))
                        {
                            this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
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
                            // 拠点コード、名称のクリア
                            tEdit_SectionCodeAllowZero2.Clear();
                            SectionNm_tEdit.Clear();
                            e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            break;
                        }
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
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    return;
                }

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                        ((Control)sender).Focus();
                    }
                }
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ctPgId, 						    // アセンブリＩＤまたはクラスＩＤ
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
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            if ((this.tEdit_SectionCodeAllowZero2.Text == "0") ||
                (this.tEdit_SectionCodeAllowZero2.Text == "00"))
            {
                this.SectionNm_tEdit.Text = "全社共通";
                this.tEdit_SectionCodeAllowZero2.Text = "00";
                return;
            }

            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // 拠点コード名称クリア
                this.SectionNm_tEdit.Text = "";
            }

            if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
            }
        }
        #endregion

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        private bool ModeChangeProc()
        {
            isError = false;
            EventArgs e = new EventArgs();
            tEdit_SectionCode_Leave(null, e);

            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }

            string msg = "入力されたコードの検品全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[INSPECTTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ctPgId,						        // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの検品全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true;
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの検品全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ctPgId,                                 // アセンブリＩＤまたはクラスＩＤ
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
        /// <summary>
        /// tEdit_SectionCodeAllowZero2_Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCodeAllowZero2_Enter イベント</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero2_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text))
            {
                tEdit_SectionCodeAllowZero2.Text = Convert.ToInt32(tEdit_SectionCodeAllowZero2.Text).ToString();
            }
        }
    }
}