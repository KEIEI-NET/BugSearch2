//****************************************************************************
// システム         : PM.NSシリーズ
// プログラム名称   : PMTAB初期表示従業員設定マスタ
// プログラム概要   : PMTAB初期表示従業員設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================
// 履歴
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/23  修正内容 : ログイン担当者に0000共通を設定できない件の対応
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/27  修正内容 : システムテスト障害対応(No3～No7)
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/10/28  修正内容 : コード入力ありでコードからShift＋Enterキーを押下すると、フォーカスが前項目に移動しない
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/10/28  修正内容 : コード入力後、従業員名称が表示されない場合がある
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/28  修正内容 : 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/29  修正内容 : 編集中のダイアログにて「キャンセル」を選択すると、画面が閉じる
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMTAB初期表示従業員設定マスタ表示設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB初期表示従業員設定マスタの設定を行います。</br>
    /// <br>Programmer : 31065 豊沢 憲弘</br>
    /// <br>Date       : 2014/09/19</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTAB09190UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor

        /// <summary>
        /// PMTAB初期表示従業員設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        public PMTAB09190UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            this.DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmtDefEmpAcs = new PmtDefEmpAcs();
            this._pmtDefEmpTable = new Hashtable();
            this._pmtEmployeeDivTable = new Hashtable();

            // プロパティー変数初期化
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = true;
            this._dataIndex = -1;
            this._canSpecificationSearch = false;
            this._totalCount = 0;

            // 担当者区分文字列取得用マップ構築
            for (int index = 0; index < this.SalesEmployeeDiv_ce.Items.Count; index++)
            {
                this._pmtEmployeeDivTable.Add(
                    this.SalesEmployeeDiv_ce.Items[index].DataValue,
                    this.SalesEmployeeDiv_ce.Items[index].DisplayText);
            }

        }

        #endregion

        #region Private const Members
        // テーブル名
        private const string PmtDefEmp_TABLE = "PmtDefEmp";

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string UPDATEDATETIME_DATE = "更新日";
        private const string DELETE_DATE = "削除日";
        private const string LOGINAGENCODE_TITLE = "ログイン担当者コード";
        private const string LOGINAGENNAME_TITLE = "ログイン担当者名称";
        private const string SALESEMPDIV_TITLE = "担当者区分";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 --->>>>>>
        private const string SALESEMPLOYEECD_TITLE = "担当者コード";
        private const string SALESEMPLOYEENM_TITLE = "担当者名称";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 ---<<<<<<
        private const string FRONTEMPDIV_TITLE = "受注者区分";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 --->>>>>>
        private const string FRONTEMPLOYEECD_TITLE = "受注者コード";
        private const string FRONTEMPLOYEENM_TITLE = "受注者名称";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 ---<<<<<<
        private const string SALESINPUTDIV_TITLE = "発行者区分";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 --->>>>>>
        private const string SALESINPUTCD_TITLE = "発行者コード";
        private const string SALESINPUTNM_TITLE = "発行者名称";
        // UPD 2014/10/27 k.toyosawa データビューの項目名称が統一されていないの対応 ---<<<<<<
        private const string GUID_TITLE = "GUID";

        // 編集モード
        private const string UPDATE_MODE = "更新モード";
        private const string INSERT_MODE = "新規モード";
        private const string DELETE_MODE = "削除モード";

        // Message関連定義
        private const string CT_PGID = "PMSCM05300U";
        private const string CT_PGNM = "受信対象情報マスタ";
        private const string ASSEMBLY_ID = "PMSCM05300U";
        private const string ERR_SEAR_TIME_MSG = "検索中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度検索を行なってください。";
        private const string ERR_WRITE_TIME_MSG = "更新中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string ERR_DEL_TIME_MSG = "削除中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string SECTION_00_MES = "全体";

        // 各担当者チェック対象区分定数
        private const int EMPLOYEE_CHECK_DIV = 3;

        // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
        private const string ID_0000_ID = "0000";
        // ADD 2014/10/27 k.toyosawa 共通設定の表示が他画面と統一されていない件の対応 --->>>>>>
        private const string ID_0000_NAME = "共通";
        // ADD 2014/10/27 k.toyosawa 共通設定の表示が他画面と統一されていない件の対応 ---<<<<<<
        // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
        #endregion

        #region Private Members
        private string _enterpriseCode;    // 企業コード
        private Hashtable _pmtDefEmpTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ アクセスクラス
        private PmtDefEmpAcs _pmtDefEmpAcs;
        private PmtDefEmp _pmtDefEmp;
        /// </summary>
        // 比較用クローン
        private PmtDefEmp _pmtDefEmpClone = new PmtDefEmp();
        private int _totalCount;
        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private int _detailsIndexBuf;
        // ガイド系アクセスクラス
        private EmployeeAcs _employeeAcs = null;
        private Hashtable _employeeTb = null;
        // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
        private int _preLoginAgenCd = -1;   // 変更前ログイン担当者コード
        // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
        private int _preSalesEmployeeCd = 0;   // 変更前販売従業員コード
        private int _preFrontEmployeeCd = 0;   // 変更前受付従業員コード
        private int _preSalesInputCd = 0;   // 変更前売上入力者コード

        // 担当者区分文字列取得用マップ
        private Hashtable _pmtEmployeeDivTable;
        #endregion

        #region  Events

        /// <summary>
        /// 画面非表示イベント
        /// </summary>
        /// <remarks>
        /// 画面が非表示状態になった際に発生します。
        /// </remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

        #region Properties

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

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;

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

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;

            }
        }

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
            get { return this._canSpecificationSearch; }
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
            get { return this._defaultAutoFillToColumn; }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 画面情報全体項目表示名称クラス格納処理(チェック用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            // ログイン担当者コード
            appearanceTable.Add(LOGINAGENCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ログイン担当者名称
            appearanceTable.Add(LOGINAGENNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 担当者区分
            appearanceTable.Add(SALESEMPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 販売従業員コード
            appearanceTable.Add(SALESEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 販売従業員名称
            appearanceTable.Add(SALESEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 受注者区分
            appearanceTable.Add(FRONTEMPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 受付従業員コード
            appearanceTable.Add(FRONTEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 受付従業員名称
            appearanceTable.Add(FRONTEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 発行者区分
            appearanceTable.Add(SALESINPUTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 売上入力者コード
            appearanceTable.Add(SALESINPUTCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 売上入力者名称
            appearanceTable.Add(SALESINPUTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //GUID_TITLE
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// 画面情報全体項目表示名称クラス格納処理(チェック用)
        /// </summary>
        /// <param name="tableName">全体項目表示名称オブジェクト</param>
        /// <param name="bindDataSet">全体項目表示名称オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PmtDefEmp_TABLE;
        }

        /// <summary>
        ///  Print
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 拠点検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            PmtDefEmp parsePmtDefEmp = new PmtDefEmp();
            List<PmtDefEmp> PmtDefEmpList = new List<PmtDefEmp>();
            parsePmtDefEmp.EnterpriseCode = this._enterpriseCode;
            if (this._pmtDefEmpTable.Count == 0)
            {
                status = this._pmtDefEmpAcs.Search(ref PmtDefEmpList, parsePmtDefEmp, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData01);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this._totalCount = PmtDefEmpList.Count;
                            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Clear();
                            this._pmtDefEmpTable.Clear();

                            // PMTAB初期表示従業員設定マスタクラスをデータセットへ展開する
                            int index = 0;
                            foreach (PmtDefEmp PmtDefEmp in PmtDefEmpList)
                            {
                                if (this._pmtDefEmpTable.ContainsKey(PmtDefEmp.FileHeaderGuid) == false)
                                {
                                    this.PmtDefEmpToDataSet(PmtDefEmp.Clone(), index);
                                    ++index;
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // サーチ
                            TMsgDisp.Show(
                                this,                               // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                                CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                                this.Name,                          // プログラム名称
                                ctPROCNM,                           // 処理名称
                                TMsgDisp.OPE_GET,                   // オペレーション
                                ERR_SEAR_TIME_MSG,                  // 表示するメッセージ
                                status,                             // ステータス値
                                this._pmtDefEmpAcs,                 // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,               // 表示するボタン
                                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "読み込みに失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                            break;
                        }
                }
            }

            else
            {
                this._totalCount = this._pmtDefEmpTable.Count;
                SortedList sortedList = new SortedList();

                // PMTAB初期表示従業員設定マスタクラスをデータセットへ展開する
                int index = 0;
                foreach (PmtDefEmp pmtDefEmp in sortedList.Values)
                {
                    this.PmtDefEmpToDataSet(pmtDefEmp.Clone(), index);
                    ++index;
                }
            }
            // 戻り値セット
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
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            PmtDefEmp PmtDefEmp = null;

            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
            PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

            int status;
            int dummy = 0;
            // PMTAB初期表示従業員設定マスタ論理削除処理
            status = this._pmtDefEmpAcs.LogicalDelete(ref PmtDefEmp);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.PmtDefEmpToDataSet(PmtDefEmp.Clone(), this.DataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);

                        // PMTAB初期表示従業員設定マスタクラスデータセット展開処理
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_DEL_TIME_MSG,                   // 表示するメッセージ
                            status,                             // ステータス値
                            this._pmtDefEmpAcs,                 // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                            // プログラム名称
                            "Delete",                           // 処理名称
                            TMsgDisp.OPE_HIDE,                  // オペレーション
                            "削除に失敗しました。",             // 表示するメッセージ
                            status,                             // ステータス値
                            this._pmtDefEmpAcs,                 // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                        //PMTAB初期表示従業員設定マスタクラスデータセット展開処理
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);

                        return status;
                    }
            }

            return status;
        }

        # endregion Public Methods

        #region  Control Events

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // 保存ボタン
            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;

            // 閉じるボタン
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // 復活ボタン
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            // 完全削除ボタン
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ログイン担当者ガイド
            this.LoginAgenCdGuid_ultraButton.ImageList = imageList16;
            this.LoginAgenCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // 販売従業員ガイド
            this.SalesEmployeeCdGuid_ultraButton.ImageList = imageList16;
            this.SalesEmployeeCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // 受付従業員ガイド
            this.FrontEmployeeCdGuid_ultraButton.ImageList = imageList16;
            this.FrontEmployeeCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // 売上入力者ガイド
            this.SalesInputCdGuid_ultraButton.ImageList = imageList16;
            this.SalesInputCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.FormClosing イベント (PMSCM05300UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // チェック用クローン初期化
            this._pmtDefEmpClone = null;

            // ユーザーによって閉じられる場合
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント (PMSCM05300UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                if (this.Owner != null)
                {
                    this.Owner.Activate();
                }
                return;
            }

            // 画面クリア処理
            this.ScreenClear();

            this.Initial_Timer.Enabled = true;

        }

        /// <summary>
        /// Timer.Tick イベント (Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "LoginAgenCd_tEdit":
                    {
                        int employeeCd = this.LoginAgenCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preLoginAgenCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    // ADD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる件の対応  --->>>>>>
                                    int code = 0;
                                    if (this._preLoginAgenCd != -1)
                                    {
                                        code = this._preLoginAgenCd;
                                    }
                                    // ADD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる件の対応  ---<<<<<<

                                    // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる件の対応  --->>>>>>
                                    this.LoginAgenCd_tEdit.SetInt(code);
                                    // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる件の対応  ---<<<<<<
                                    // 入力チェック
                                    TMsgDisp.Show(
                                        this,                                   // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  --->>>>>>
                                        "マスタに登録されていません",           // 表示するメッセージ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  ---<<<<<<
                                        0,                                      // ステータス値
                                        MessageBoxButtons.OK);                  // 表示するボタン
                                    e.NextCtrl = this.LoginAgenCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.LoginAgenNm_tEdit.Text = employeeNm;
                                    this._preLoginAgenCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            // DEL 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応  --->>>>>>
                            //this.LoginAgenNm_tEdit.Text = string.Empty;
                            //_preLoginAgenCd = 0;
                            // DEL 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<

                            // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                            if (0 < this.LoginAgenCd_tEdit.DataText.Length)
                            {
                                this.LoginAgenCd_tEdit.Text = ID_0000_ID;
                                this.LoginAgenNm_tEdit.Text = ID_0000_NAME;
                                this._preLoginAgenCd = 0;
                            }
                            else
                            {
                                this.LoginAgenNm_tEdit.Text = string.Empty;
                                _preLoginAgenCd = -1;
                            }
                            // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.LoginAgenNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                        if ( _preLoginAgenCd == -1)
                        {
                            break;
                        }
                        // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<

                        if (this.ModeChangeProc(this.LoginAgenCd_tEdit.GetInt().ToString().PadLeft(4, '0')))
                        {
                            e.NextCtrl = this.LoginAgenCd_tEdit;
                        }

                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
                        if (0 < this.LoginAgenCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 吉岡 ------->>>>>>>>>>>>
                            // e.NextCtrl = this.SalesEmployeeDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.SalesEmployeeDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  ---<<<<<<
                            }
                            // UPD 2014/10/28 吉岡 -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
                        break;
                    }
                case "SalesEmployeeCd_tEdit":
                    {
                        int employeeCd = this.SalesEmployeeCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preSalesEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.SalesEmployeeCd_tEdit.SetInt(this._preSalesEmployeeCd);
                                    // 入力チェック
                                    TMsgDisp.Show(
                                        this,                                   // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  --->>>>>>
                                        "マスタに登録されていません",           // 表示するメッセージ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  ---<<<<<<
                                        0,                                      // ステータス値
                                        MessageBoxButtons.OK);                  // 表示するボタン
                                    e.NextCtrl = SalesEmployeeCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.SalesEmployeeNm_tEdit.Text = employeeNm;
                                    this._preSalesEmployeeCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.SalesEmployeeNm_tEdit.Text = string.Empty;
                            this._preSalesEmployeeCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.SalesEmployeeNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
                        if (0 < this.SalesEmployeeCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 吉岡 ------->>>>>>>>>>>>
                            // e.NextCtrl = this.FrontEmployeeDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.FrontEmployeeDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  ---<<<<<<
                            }
                            // UPD 2014/10/28 吉岡 -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
                        break;
                    }
                case "FrontEmployeeCd_tEdit":
                    {
                        int employeeCd = this.FrontEmployeeCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preFrontEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.FrontEmployeeCd_tEdit.SetInt(this._preFrontEmployeeCd);
                                    // 入力チェック
                                    TMsgDisp.Show(
                                        this,                                   // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  --->>>>>>
                                        "マスタに登録されていません",           // 表示するメッセージ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  ---<<<<<<
                                        0,                                      // ステータス値
                                        MessageBoxButtons.OK);                  // 表示するボタン
                                    e.NextCtrl = FrontEmployeeCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.FrontEmployeeNm_tEdit.Text = employeeNm;
                                    this._preFrontEmployeeCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.FrontEmployeeNm_tEdit.Text = string.Empty;
                            this._preFrontEmployeeCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.FrontEmployeeNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
                        if (0 < this.FrontEmployeeCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 吉岡 ------->>>>>>>>>>>>
                            // e.NextCtrl = this.SalesInputDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.SalesInputDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  ---<<<<<<
                            }
                            // UPD 2014/10/28 吉岡 -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
                        break;
                    }
                case "SalesInputCd_tEdit":
                    {
                        int employeeCd = this.SalesInputCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preSalesInputCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.SalesInputCd_tEdit.SetInt(this._preSalesInputCd);
                                    // 入力チェック
                                    TMsgDisp.Show(
                                        this,                                   // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  --->>>>>>
                                        "マスタに登録されていません",           // 表示するメッセージ
                                        // UPD 2014/10/27 k.toyosawa マスタ未登録のチェックメッセージが仕様と異なる  ---<<<<<<
                                        0,                                      // ステータス値
                                        MessageBoxButtons.OK);                  // 表示するボタン
                                    e.NextCtrl = SalesInputCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.SalesInputNm_tEdit.Text = employeeNm;
                                    this._preSalesInputCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.SalesInputNm_tEdit.Text = string.Empty;
                            this._preSalesInputCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
                                this.SalesInputNm_tEdit.Text.TrimEnd();
                                // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
                        if (0 < this.SalesInputCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 吉岡 ------->>>>>>>>>>>>
                            // e.NextCtrl = this.Ok_Button;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                // ADD 2014/10/27 k.toyosawa 担当者コードから上下左右キーを押下すると、フォーカス移動先が合わない件の対応  ---<<<<<<
                            }
                            // UPD 2014/10/28 吉岡 -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// LoginAgenCdGuid_ultraButton_Click イベント (LoginAgenCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void LoginAgenCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._employeeAcs == null)
                {
                    this._employeeAcs = new EmployeeAcs();
                }

                Employee employee;
                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    string employeeCode = employee.EmployeeCode.TrimEnd();
                    if (!this.ModeChangeProc(employeeCode))
                    {
                        this.LoginAgenCd_tEdit.Value = employeeCode;
                        this.LoginAgenNm_tEdit.Text = employee.Name;
                        this._preLoginAgenCd = this.LoginAgenCd_tEdit.GetInt();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
            this.SalesEmployeeDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<

        }

        /// <summary>
        /// SalesEmployeeCdGuid_ultraButton_Click イベント(SalesEmployeeCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesEmployeeCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.SalesEmployeeCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.SalesEmployeeNm_tEdit.Text = employee.Name;
                this._preSalesEmployeeCd = this.SalesEmployeeCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
            this.FrontEmployeeDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
        }

        /// <summary>
        /// FrontEmployeeCdGuid_ultraButton_Click イベント (FrontEmployeeCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void FrontEmployeeCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.FrontEmployeeCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.FrontEmployeeNm_tEdit.Text = employee.Name;
                this._preFrontEmployeeCd = this.FrontEmployeeCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
            this.SalesInputDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<
        }

        /// <summary>
        /// SalesInputCdGuid_ultraButton_Click イベント (SalesInputCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesInputCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.SalesInputCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.SalesInputNm_tEdit.Text = employee.Name;
                this._preSalesInputCd = this.SalesInputCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  --->>>>>>
            this.Ok_Button.Focus();
            // UPD 2014/10/27 k.toyosawa コードが空白以外のときに、ガイドから従業員を選択すると、ガイドボタンへフォーカスが移動する件の対応  ---<<<<<<

        }

        /// <summary>
        /// Ok_Button_Click イベント (Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // フォームを閉じる
            this.CloseForm(DialogResult.OK);

            // フォームを非表示化する。
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

        }

        /// <summary>
        /// Cancel_Button_Click イベント (Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 保存確認
                PmtDefEmp comparePmtDefEmp = new PmtDefEmp();
                comparePmtDefEmp = this._pmtDefEmpClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                // 現在の画面情報を取得する
                this.DispToPmtDefEmp(ref comparePmtDefEmp);
                // 最初に取得した画面情報と比較
                if (!(this._pmtDefEmpClone.Equals(comparePmtDefEmp)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                         this,                                  // 親ウィンドウフォーム
                         emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
                         ASSEMBLY_ID,                           // アセンブリＩＤまたはクラスＩＤ
                         "",                                    // 表示するメッセージ 
                         0,                                     // ステータス値
                         MessageBoxButtons.YesNoCancel);        // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 登録処理
                                if (this.SaveProc() == false)
                                {
                                    return;
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        default:
                            {
                                this.Cancel_Button.Focus();
                                // UPD 2014/10/29 k.toyosawa 編集中のダイアログにて「キャンセル」を選択すると、画面が閉じる件の対応  --->>>>>>
                                return;
                                // UPD 2014/10/29 k.toyosawa 編集中のダイアログにて「キャンセル」を選択すると、画面が閉じる件の対応  ---<<<<<<
                            }
                    }
                }
            }
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            PmtDefEmp PmtDefEmp = new PmtDefEmp();

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？",                 // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OKCancel,         // 表示するボタン
                MessageBoxDefaultButton.Button2);   // 初期表示ボタン
            if (result == DialogResult.OK)
            {
                // 保持しているデータセットより情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
                PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];
                // PMTAB初期表示従業員設定マスタ論理削除処理
                int status = this._pmtDefEmpAcs.Delete(ref PmtDefEmp);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex].Delete();
                            this._pmtDefEmpTable.Remove(PmtDefEmp.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            this.ExclusiveTransaction(status, true);

                            // PMTAB初期表示従業員設定マスタクラスデータセット展開処理
                            this._pmtDefEmpTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // TIMEOUT
                            TMsgDisp.Show(
                               this,                                // 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_STOP,         // エラーレベル
                               CT_PGID,                             // アセンブリＩＤまたはクラスＩＤ
                               this.Name,                           // プログラム名称
                               ctPROCNM,                            // 処理名称
                               TMsgDisp.OPE_UPDATE,                 // オペレーション
                               ERR_DEL_TIME_MSG,                    // 表示するメッセージ
                               status,                              // ステータス値
                               this._pmtDefEmpAcs,                  // エラーが発生したオブジェクト
                               MessageBoxButtons.OK,                // 表示するボタン
                               MessageBoxDefaultButton.Button1);    // 初期表示ボタン
                            return;
                        }
                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this,                               // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                                CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                                CT_PGNM,                            // プログラム名称
                                "Delete_Button_Click",              // 処理名称
                                TMsgDisp.OPE_DELETE,                // オペレーション
                                "削除に失敗しました。",             // 表示するメッセージ
                                status,                             // ステータス値
                                this._pmtDefEmpAcs,                 // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,               // 表示するボタン
                                MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                            // PMTAB初期表示従業員設定マスタクラスデータセット展開処理
                            this._pmtDefEmpTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                }

            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;


            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

        }

        /// <summary>
        /// Revive_Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            PmtDefEmp PmtDefEmp = null;

            DialogResult res = TMsgDisp.Show(this,
                                             emErrorLevel.ERR_LEVEL_QUESTION,
                                             CT_PGID,
                                             "現在表示中のマスタを復活します。" + "\r\n" + "よろしいですか？",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
            PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

            // PMTAB初期表示従業員設定マスタ登録・更新処理
            int status = this._pmtDefEmpAcs.RevivalLogicalDelete(ref PmtDefEmp);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // クラスデータセット展開処理
                        this.PmtDefEmpToDataSet(PmtDefEmp, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);

                        // クラスデータセット展開処理
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();

                        return;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_WRITE_TIME_MSG,                 // 表示するメッセージ
                            status,                             // ステータス値
                            this._pmtDefEmpAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return;

                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                            // プログラム名称
                            "Revive_Button_Click",              // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            "復活に失敗しました。",             // 表示するメッセージ
                            status,                             // ステータス値
                            this._pmtDefEmpAcs,                 // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        // クラスデータセット展開処理
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();
                        break;
                    }
            }
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            this._detailsIndexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <param name="sectionCd">拠点コード</param>
        /// <remarks>
        /// <br>Note		: モード変更処理</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>  
        private bool ModeChangeProc(string employeeCd)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsEmployeeCd = (string)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[i][LOGINAGENCODE_TITLE];
                if (employeeCd.Equals(dsEmployeeCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this,                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                            ASSEMBLY_ID,                    // アセンブリＩＤまたはクラスＩＤ
                            "入力されたコードのPMTAB初期表示従業員設定マスタ情報は既に削除されています。",  // 表示するメッセージ
                            0,                              // ステータス値
                            MessageBoxButtons.OK);          // 表示するボタン
                        this.LoginAgenCd_tEdit.Clear();
                        this.LoginAgenNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのPMTAB初期表示従業員設定マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                this.ScreenClear();
                                this.ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                this.LoginAgenCd_tEdit.Clear();
                                this.LoginAgenNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// SalesEmployeeDiv_ce_ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesEmployeeDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.SalesEmployeeCd_tEdit.Enabled = true;
                this.SalesEmployeeCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.SalesEmployeeCd_tEdit.Enabled = false;
                this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
            }
            this.SalesEmployeeCd_tEdit.Text = string.Empty;
            this.SalesEmployeeNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある --------->>>>>>>>>>>>>>>>>>
            this._preSalesEmployeeCd = 0;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある ---------<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// FrontEmployeeDiv_ce_ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void FrontEmployeeDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.FrontEmployeeCd_tEdit.Enabled = true;
                this.FrontEmployeeCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.FrontEmployeeCd_tEdit.Enabled = false;
                this.FrontEmployeeCdGuid_ultraButton.Enabled = false;
            }
            this.FrontEmployeeCd_tEdit.Text = string.Empty;
            this.FrontEmployeeNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある --------->>>>>>>>>>>>>>>>>>
            this._preFrontEmployeeCd = 0;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある ---------<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SalesInputDiv_ce_ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesInputDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesInputDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.SalesInputCd_tEdit.Enabled = true;
                this.SalesInputCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.SalesInputCd_tEdit.Enabled = false;
                this.SalesInputCdGuid_ultraButton.Enabled = false;
            }
            this.SalesInputCd_tEdit.Text = string.Empty;
            this.SalesInputNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある --------->>>>>>>>>>>>>>>>>>
            this._preSalesInputCd = 0;
            // ADD 2014/10/28 吉岡 コード入力後、従業員名称が表示されない場合がある ---------<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region  Private Methods

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:新規, 1:更新, 2:削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:新規
                case 0:
                    // ログイン担当者
                    this.LoginAgenCd_tEdit.Enabled = true;
                    this.LoginAgenCdGuid_ultraButton.Enabled = true;

                    // 担当者
                    // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                    this.SalesEmployeeDiv_ce.Enabled = true;
                    // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
                    // 新規の場合、担当者区分は優先従業員のため販売従業員コードは入力不可
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
                    this.SalesEmployeeCd_tEdit.Enabled = false;
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;

                    // 受注者
                    this.FrontEmployeeDiv_ce.Enabled = true;
                    // 新規の場合、受注者区分は優先従業員のため受付従業員コードは入力不可
                    this.FrontEmployeeDiv_ce.SelectedIndex = 0;
                    this.FrontEmployeeCd_tEdit.Enabled = false;
                    this.FrontEmployeeCdGuid_ultraButton.Enabled = false;

                    // 発行者
                    this.SalesInputDiv_ce.Enabled = true;
                    // 新規の場合、発行者に区分は優先従業員のため売上入力者コードは入力不可
                    this.SalesInputDiv_ce.SelectedIndex = 0;
                    this.SalesInputCd_tEdit.Enabled = false;
                    this.SalesInputCdGuid_ultraButton.Enabled = false;


                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 1:更新
                case 1:
                    // ログイン担当者
                    this.LoginAgenCd_tEdit.Enabled = false;
                    this.LoginAgenCdGuid_ultraButton.Enabled = false;

                    // 担当者
                    this.SalesEmployeeDiv_ce.Enabled = true;
                    // 販売従業員コードの入力は担当者区分に依存
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.SalesEmpDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.SalesEmployeeCd_tEdit.Enabled = true;
                        this.SalesEmployeeCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.SalesEmployeeCd_tEdit.Enabled = false;
                        this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
                    }

                    // 受注者
                    this.FrontEmployeeDiv_ce.Enabled = true;
                    // 受付従業員コードの入力は受注者区分に依存
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.FrontEmpDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.FrontEmployeeCd_tEdit.Enabled = true;
                        this.FrontEmployeeCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.FrontEmployeeCd_tEdit.Enabled = false;
                        this.FrontEmployeeCdGuid_ultraButton.Enabled = false;
                    }

                    // 発行者
                    this.SalesInputDiv_ce.Enabled = true;
                    // 売上入力者コードの入力は発行者に区分
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.SalesInputDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.SalesInputCd_tEdit.Enabled = true;
                        this.SalesInputCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.SalesInputCd_tEdit.Enabled = false;
                        this.SalesInputCdGuid_ultraButton.Enabled = false;
                    }


                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 2:削除
                case 2:
                    // ログイン担当者
                    this.LoginAgenCd_tEdit.Enabled = false;
                    this.LoginAgenCdGuid_ultraButton.Enabled = false;

                    // 担当者
                    this.SalesEmployeeDiv_ce.Enabled = false;
                    this.SalesEmployeeCd_tEdit.Enabled = false;
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;

                    // 受注者
                    this.FrontEmployeeDiv_ce.Enabled = false;
                    this.FrontEmployeeCd_tEdit.Enabled = false;
                    this.FrontEmployeeCdGuid_ultraButton.Enabled = false;

                    // 発行者
                    this.SalesInputDiv_ce.Enabled = false;
                    this.SalesInputCd_tEdit.Enabled = false;
                    this.SalesInputCdGuid_ultraButton.Enabled = false;


                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// 画面情報全体項目表示名称クラス格納処理(チェック用)
        /// </summary>
        /// <param name="PmtDefEmp">全体項目表示名称オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void DispToPmtDefEmp(ref PmtDefEmp pmtDefEmp)
        {
            if (pmtDefEmp == null)
            {
                // 新規の場合
                pmtDefEmp = new PmtDefEmp();
                pmtDefEmp.EnterpriseCode = this._enterpriseCode;
            }

            if (pmtDefEmp.EnterpriseCode == "")
            {
                pmtDefEmp.EnterpriseCode = this._enterpriseCode;
            }

            // ログイン担当者コード
            if (this.LoginAgenCd_tEdit.GetInt() == 0)
            {
                // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                pmtDefEmp.LoginAgenCode = ID_0000_ID;
                // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
            }
            else
            {
                pmtDefEmp.LoginAgenCode = this.LoginAgenCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // 担当者区分
            pmtDefEmp.SalesEmpDiv = int.Parse(this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString());

            // 販売従業員コード
            if (this.SalesEmployeeCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.SalesEmployeeCd = "";
            }
            else
            {
                pmtDefEmp.SalesEmployeeCd = this.SalesEmployeeCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // 受注者区分
            pmtDefEmp.FrontEmpDiv = int.Parse(this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString());

            // 受付従業員コード
            if (this.FrontEmployeeCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.FrontEmployeeCd = "";
            }
            else
            {
                pmtDefEmp.FrontEmployeeCd = this.FrontEmployeeCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // 発行者区分
            pmtDefEmp.SalesInputDiv = int.Parse(this.SalesInputDiv_ce.SelectedItem.DataValue.ToString());

            // 売上入力者コード
            if (this.SalesInputCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.SalesInputCode = "";
            }
            else
            {
                pmtDefEmp.SalesInputCode = this.SalesInputCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }
        }

        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体項目表示名称クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {
            this.PmtDefEmpToScreen(this._pmtDefEmp);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            this.ScreenInputPermissionControl(0);

            // ログイン担当者
            this.LoginAgenCd_tEdit.Clear();
            this.LoginAgenNm_tEdit.Text = "";
            // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
            this._preLoginAgenCd = -1;
            // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<

            // 担当者
            this.SalesEmployeeDiv_ce.SelectedIndex = 0;
            this.SalesEmployeeCd_tEdit.Clear();
            this.SalesEmployeeNm_tEdit.Text = "";
            this._preSalesEmployeeCd = 0;

            // 受注者
            this.FrontEmployeeDiv_ce.SelectedIndex = 0;
            this.FrontEmployeeCd_tEdit.Clear();
            this.FrontEmployeeNm_tEdit.Text = "";
            this._preFrontEmployeeCd = 0;

            // 発行者
            this.SalesInputDiv_ce.SelectedIndex = 0;
            this.SalesInputCd_tEdit.Clear();
            this.SalesInputNm_tEdit.Text = "";
            // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
            //this._preLoginAgenCd = 0;
            this._preSalesInputCd = 0;
            // UPD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {

            this._pmtDefEmp = new PmtDefEmp();
            PmtDefEmp pmtDefEmp = new PmtDefEmp();
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                this.PmtDefEmpToScreen(pmtDefEmp);
                // 画面クリア
                this.ScreenClear();
                // クローン作成
                this._pmtDefEmpClone = pmtDefEmp.Clone();

                // フォーカス設定
                this.SalesEmployeeCd_tEdit.Focus();
                this.ScreenInputPermissionControl(0);
                // 画面展開処理
                this.DispToPmtDefEmp(ref this._pmtDefEmpClone);
            }
            else
            {
                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this._dataIndex][GUID_TITLE];
                pmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

                // 画面展開処理
                this.PmtDefEmpToScreen(pmtDefEmp);
                if (pmtDefEmp.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    //クローン作成
                    this._pmtDefEmpClone = pmtDefEmp.Clone();

                    // 画面展開処理
                    this.DispToPmtDefEmp(ref this._pmtDefEmpClone);
                    this.ScreenInputPermissionControl(1);
                    this.SalesEmployeeDiv_ce.Focus();
                }
                // 削除の場合
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面展開処理
                    this.PmtDefEmpToScreen(pmtDefEmp);
                    this.ScreenInputPermissionControl(2);
                    this.Delete_Button.Focus();

                }

                this._detailsIndexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// データ保存チェック処理
        /// </summary>
        /// <returns>チェック結果(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 入力データの保存を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private bool SaveProc()
        {

            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = null;

            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    message,                               // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.OK);                // 表示するボタン

                // コントロールを選択
                control.Focus();

                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            // 表示情報取得
            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this._dataIndex][GUID_TITLE];
                this._pmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];
            }
            // 画面から全体項目表示名称のデータを取得
            this.DispToPmtDefEmp(ref this._pmtDefEmp);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._pmtDefEmpAcs.Write(ref this._pmtDefEmp);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.PmtDefEmpToDataSet(this._pmtDefEmp.Clone(), this.DataIndex);
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                                    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
                            CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",    // 表示するメッセージ
                            0,                                       // ステータス値
                            MessageBoxButtons.OK);                   // 表示するボタン

                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            CT_PGID,                            // アセンブリＩＤまたはクラスＩＤ
                            this.Name,                          // プログラム名称
                            ctPROCNM,                           // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_WRITE_TIME_MSG,                 // 表示するメッセージ
                            status,                             // ステータス値
                            this._pmtDefEmpAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "登録に失敗しました。",               // 表示するメッセージ
                            status,                               // ステータス値
                            this._pmtDefEmpAcs,                    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            return result;
        }

        /// <summary>
        /// 画面Check
        /// </summary>
        /// <param name="control">STATUS</param>
        /// <param name="message">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 画面Checkを行います</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (this.LoginAgenCd_tEdit.Text == "")
            {
                control = this.LoginAgenCd_tEdit;
                message = "ログイン担当者コードを入力して下さい";
                return false;
            }

            if (this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.SalesEmployeeCd_tEdit.Text == "")
                {
                    control = this.SalesEmployeeCd_tEdit;
                    message = "担当者を入力して下さい";
                    return false;
                }

                if (this.SalesEmployeeNm_tEdit.Text.Trim() == "")
                {
                    control = this.SalesEmployeeNm_tEdit;
                    message = "マスタに登録されていません";
                    return false;
                }
            }

            if (this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.FrontEmployeeCd_tEdit.Text == "")
                {
                    // UPD 2014/10/27 k.toyosawa 受注者未入力の入力チェック後、フォーカスがコードではなく区分に移動する --->>>>>>
                    control = this.FrontEmployeeCd_tEdit;
                    // UPD 2014/10/27 k.toyosawa 受注者未入力の入力チェック後、フォーカスがコードではなく区分に移動する ---<<<<<<
                    message = "受注者を入力して下さい";
                    return false;
                }

                if (this.FrontEmployeeNm_tEdit.Text.Trim() == "")
                {
                    control = this.FrontEmployeeNm_tEdit;
                    message = "マスタに登録されていません";
                    return false;
                }
            }

            if (this.SalesInputDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.SalesInputCd_tEdit.Text == "")
                {
                    control = this.SalesInputCd_tEdit;
                    message = "発行者を入力して下さい";
                    return false;
                }

                if (this.SalesInputNm_tEdit.Text.Trim() == "")
                {
                    control = this.SalesInputNm_tEdit;
                    message = "マスタに登録されていません";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                 // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                 // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
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
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // 比較用クローンクリア
            this._pmtDefEmpClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
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
        /// 従業員名称の取得
        /// </summary>
        /// <param name="employeeCode"> 受付従業員コード</param>
        /// <returns>受付従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称の取得を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private string GetEmployeeNm(string employeeCode)
        {
            // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
            if (employeeCode.TrimEnd() == ID_0000_ID)
            {
                return ID_0000_NAME;
            }
            // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<

            string employeeNm = string.Empty;
            if (_employeeTb == null)
            {
                this.GetAllEmployeeNm();
            }
            if (_employeeTb != null && this._employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                employeeNm = (string)this._employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return employeeNm;
        }

        /// <summary>
        /// 全従業員名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全従業員名称の取得を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
               this._employeeTb = new Hashtable();
            }
            else
            {
                this._employeeTb.Clear();
            }

            ArrayList employeeList;
            ArrayList employeeDtlList;
            int status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.LogicalDeleteCode == 0)
                    {
                        this._employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ展開処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタ</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PmtDefEmpToDataSet(PmtDefEmp pmtDefEmp, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PmtDefEmp_TABLE].NewRow();
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (pmtDefEmp.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][DELETE_DATE] = pmtDefEmp.UpdateDateTimeJpFormal;
            }

            // ログイン担当者コード
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][LOGINAGENCODE_TITLE] = pmtDefEmp.LoginAgenCode;

            // ログイン担当者名称
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][LOGINAGENNAME_TITLE] = this.GetEmployeeNm(pmtDefEmp.LoginAgenCode);

            // 担当者区分
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.SalesEmpDiv);

            // 販売従業員コード
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPLOYEECD_TITLE] = pmtDefEmp.SalesEmployeeCd;

            // 販売従業員名称
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPLOYEENM_TITLE] = this.GetEmployeeNm(pmtDefEmp.SalesEmployeeCd);

            // 受注者区分
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.FrontEmpDiv);

            // 受付従業員コード
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPLOYEECD_TITLE] = pmtDefEmp.FrontEmployeeCd;

            // 受付従業員名称
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPLOYEENM_TITLE] = this.GetEmployeeNm(pmtDefEmp.FrontEmployeeCd);

            // 発行者区分
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.SalesInputDiv);

            // 売上入力者コード
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTCD_TITLE] = pmtDefEmp.SalesInputCode;

            // 売上入力者名称
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTNM_TITLE] = this.GetEmployeeNm(pmtDefEmp.SalesInputCode);

            // GUID
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][GUID_TITLE] = pmtDefEmp.FileHeaderGuid;

            if (this._pmtDefEmpTable.ContainsKey(pmtDefEmp.FileHeaderGuid) == true)
            {
                this._pmtDefEmpTable.Remove(pmtDefEmp.FileHeaderGuid);
            }
            this._pmtDefEmpTable.Add(pmtDefEmp.FileHeaderGuid, pmtDefEmp);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pmtDefEmpTable = new DataTable(PmtDefEmp_TABLE);

            // Addを行う順番が、列の表示順位となります。
            pmtDefEmpTable.Columns.Add(DELETE_DATE, typeof(string));                // 削除日
            pmtDefEmpTable.Columns.Add(LOGINAGENCODE_TITLE, typeof(string));        // ログイン担当者コード
            pmtDefEmpTable.Columns.Add(LOGINAGENNAME_TITLE, typeof(string));        // ログイン担当者名称
            pmtDefEmpTable.Columns.Add(SALESEMPDIV_TITLE, typeof(string));          // 担当者区分
            pmtDefEmpTable.Columns.Add(SALESEMPLOYEECD_TITLE, typeof(string));      // 販売従業員コード
            pmtDefEmpTable.Columns.Add(SALESEMPLOYEENM_TITLE, typeof(string));      // 販売従業員名称
            pmtDefEmpTable.Columns.Add(FRONTEMPDIV_TITLE, typeof(string));          // 受注者区分
            pmtDefEmpTable.Columns.Add(FRONTEMPLOYEECD_TITLE, typeof(string));      // 受付従業員コード
            pmtDefEmpTable.Columns.Add(FRONTEMPLOYEENM_TITLE, typeof(string));      // 受付従業員名称
            pmtDefEmpTable.Columns.Add(SALESINPUTDIV_TITLE, typeof(string));        // 発行者区分
            pmtDefEmpTable.Columns.Add(SALESINPUTCD_TITLE, typeof(string));         // 売上入力者コード
            pmtDefEmpTable.Columns.Add(SALESINPUTNM_TITLE, typeof(string));         // 売上入力者名称
            pmtDefEmpTable.Columns.Add(GUID_TITLE, typeof(Guid));
            this.Bind_DataSet.Tables.Add(pmtDefEmpTable);
        }

        /// <summary>
        /// データクラス画面展開処理
        /// </summary>
        /// <param name="PmtDefEmp">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void PmtDefEmpToScreen(PmtDefEmp pmtDefEmp)
        {

            // ログイン担当者コード
            this.LoginAgenCd_tEdit.Text = pmtDefEmp.LoginAgenCode.Trim().PadLeft(4, '0');

            // ログイン担当者名称
            this.LoginAgenNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.LoginAgenCode);

            this._preLoginAgenCd = int.Parse(this.LoginAgenCd_tEdit.Text);

            // 担当者区分
            this.SalesEmployeeDiv_ce.SelectedIndex = pmtDefEmp.SalesEmpDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.SalesEmployeeCd))
            {
                // 販売従業員コード
                this.SalesEmployeeCd_tEdit.Text = string.Empty;

                // 販売従業員名称
                this.SalesEmployeeNm_tEdit.Text = string.Empty;

                this._preSalesEmployeeCd = 0;
            }
            else
            {
                // 販売従業員コード
                this.SalesEmployeeCd_tEdit.Text = pmtDefEmp.SalesEmployeeCd.Trim().PadLeft(4, '0');

                // 販売従業員名称
                this.SalesEmployeeNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.SalesEmployeeCd);

                this._preSalesEmployeeCd = int.Parse(this.SalesEmployeeCd_tEdit.Text);
            }

            // 受注者区分
            this.FrontEmployeeDiv_ce.SelectedIndex = pmtDefEmp.FrontEmpDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.FrontEmployeeCd))
            {
                // 受付従業員コード
                this.FrontEmployeeCd_tEdit.Text = string.Empty;

                // 受付従業員名称
                this.FrontEmployeeNm_tEdit.Text = string.Empty;

                this._preFrontEmployeeCd = 0;
            }
            else
            {
                // 受付従業員コード
                this.FrontEmployeeCd_tEdit.Text = pmtDefEmp.FrontEmployeeCd.Trim().PadLeft(4, '0');

                // 受付従業員名称
                this.FrontEmployeeNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.FrontEmployeeCd);

                this._preFrontEmployeeCd = int.Parse(this.FrontEmployeeCd_tEdit.Text);
            }

            // 発行者区分
            this.SalesInputDiv_ce.SelectedIndex = pmtDefEmp.SalesInputDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.SalesInputCode))
            {
                // 売上入力者コード
                this.SalesInputCd_tEdit.Text = string.Empty;

                // 売上入力者名称
                this.SalesInputNm_tEdit.Text = string.Empty;

                this._preSalesInputCd = 0;
            }
            else
            {
                // 売上入力者コード
                this.SalesInputCd_tEdit.Text = pmtDefEmp.SalesInputCode.Trim().PadLeft(4, '0');

                // 売上入力者名称
                this.SalesInputNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.SalesInputCode);

                this._preSalesInputCd = int.Parse(this.SalesInputCd_tEdit.Text);
            }
        }

        /// <summary>
        /// 担当者区分(文字列)の取得
        /// </summary>
        /// <param name="employeeCode"> 担当者区分(数値)</param>
        /// <returns>担当者区分(文字列)</returns>
        /// <remarks>
        /// <br>Note       : 担当者区分(文字列)取得を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private string GetEmployeeDivString(int employeeDiv)
        {
            string divString = string.Empty;
            if (this._pmtEmployeeDivTable.ContainsKey(employeeDiv))
            {
                divString = this._pmtEmployeeDivTable[employeeDiv].ToString();
            }
            return divString;
        }
        #endregion
    }
}