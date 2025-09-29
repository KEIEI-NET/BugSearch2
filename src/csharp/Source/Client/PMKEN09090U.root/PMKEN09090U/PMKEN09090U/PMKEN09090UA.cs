using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 部品代替設定（ユーザー登録）フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 部品代替設定（ユーザー登録）の設定を行います。</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date        : 2008.07.25</br>
    /// <br>UpdateNote   : 2008/10/10 30462 行澤 仁美　バグ修正</br>
    /// <br>Update Note : 2009/03/16 30452 上野 俊治</br>
    /// <br>            ・障害対応12342</br>
    /// </remarks>
    public partial class PMKEN09090UA : Form, IMasterMaintenanceMultiType
    {
        // --------------------------------------------------
        #region Constructor
        /// <summary>
        /// 部品代替設定（ユーザー登録）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public PMKEN09090UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._sectionCode = this._loginEmployee.BelongSectionCode.Trim();
            }

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値
            this._canPrint = false;                         // 印刷機能
            this._canClose = false;							// 閉じる機能(false固定)
            this._canNew = true;                            // 新規作成機能
            this._canDelete = true;							// 削除機能
            this._canLogicalDeleteDataExtraction = true;    // 論理削除データ表示機能
            this._defaultAutoFillToColumn = false;          // 列サイズ自動調整機能
            this._canSpecificationSearch = false;           // 件数指定検索機能

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            this._partsSubstUAcs = new PartsSubstUAcs();
            this._makerAcs = new MakerAcs();
            this._partsSubstUTable = new Hashtable();

            // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 >>>>>>START
            string message;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out message);
            // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 <<<<<<END
        }

        #endregion

        // --------------------------------------------------
        #region Private Members

        private int _totalCount;
        private string _enterpriseCode = "";           // 企業コード
        private Hashtable _partsSubstUTable;

        private PartsSubstUAcs _partsSubstUAcs = null;
        private MakerAcs _makerAcs = null;

        // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 >>>>>>START
        private GoodsAcs _goodsAcs = null;
        // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 <<<<<<END
            
        //比較用clone
        private PartsSubstU _partsSubstUClone = null;

        // ワークデータ関連
        private int _chgSrcMakerCdWork = 0;			// 代替元メーカーコード（ワーク）
        private int _chgDestMakerCdWork = 0;		// 代替先メーカーコード（ワーク）
        private string _chgSrcGoodsNoWork = "";		// 代替元品番（ワーク）
        private string _chgDestGoodsNoWork = "";	// 代替先品番（ワーク）

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _dataIndex;
        private int _indexBuf;

        // 拠点コード
        private string _sectionCode;

        // ログイン従業員
        private Employee _loginEmployee = null;

        // プロパティ用
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE = "削除日";
        private const string CHGSRCMAKERCD_TITLE = "代替元メーカーコード";
        private const string CHGSRCMAKERNM_TITLE = "代替元メーカー名";
        private const string CHGSRCGOODSNO_TITLE = "代替元品番";
        private const string CHGDESTMAKERCD_TITLE = "代替先メーカーコード";
        private const string CHGDESTMAKERNM_TITLE = "代替先メーカー名";
        private const string CHGDESTGOODSNO_TITLE = "代替先品番";
        private const string APPLYSTADATE_TITLE = "適用開始日";
        private const string APPLYENDDATE_TITLE = "適用終了日";
        
        private const string GUID_TITLE = "GUID";

        // テーブル名称
        private const string PARTSSUBSTU_TABLE = "PARTSSUBSTU_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string REFERENCE_MODE = "参照モード";

        // Message関連定義
        private const string ASSEMBLY_ID = "PMKEN09090U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています。";
        private const string ERR_801_MSG = "既に他端末より削除されています。";
        private const string SDC_RDEL_MSG = "マスタから削除されています。";
        private const string CONF_DEL_MSG = "データを削除します。" + "\r\n" + "よろしいですか？";

        #endregion

        #region enum
        /// <summary>
        /// 入力エラーチェックステータス
        /// </summary>
        private enum InputChkStatus
        {
            // 未入力
            NotInput = -1,
            // 存在しない
            NotExist = -2,
            // 入力ミス
            InputErr = -3,
            // 正常
            Normal = 0,
            // キャンセル
            Cancel = 1
        }

        /// <summary>
        /// 画面データ設定ステータス
        /// </summary>
        private enum DispSetStatus
        {
            // クリア
            Clear = 0,
            // 更新
            Update = 1,
            // 元に戻す
            Back = 2
        }
        #endregion enum

        // --------------------------------------------------
        #region Events

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion

        // --------------------------------------------------
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

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
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

        /// <summary>新規作成可能設定プロパティ</summary>
        /// <value>新規作成が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷が可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
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
        #endregion

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note        : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PARTSSUBSTU_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : データの検索を行い抽出結果をDataSetに格納し、該当件数を返します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList partsSubstUretList = null;

            // 抽出対象件数が0の場合は全件抽出を実行する
            status = this._partsSubstUAcs.SearchAll(out partsSubstUretList, this._enterpriseCode);

            this._totalCount = partsSubstUretList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (PartsSubstU partsSubstU in partsSubstUretList)
                        {
                            // ハッシュキー取得
                            string hashKey = CreateHashKey(partsSubstU);

                            if (this._partsSubstUTable.ContainsKey(hashKey) == false)
                            {
                                PartsSubstUToDataSet(partsSubstU.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:      // 検索結果0件
                    {
                        // 検索結果0件は、ステータスをノーマルで返す
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                            this.Text,                          // プログラム名称
                            "Search",                           // 処理名称
                            TMsgDisp.OPE_GET,                   // オペレーション
                            ERR_READ_MSG,                       // 表示するメッセージ
                            status,                             // ステータス値
                            this._partsSubstUAcs,              // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);  // 初期表示ボタン
                        break;
                    }
            }
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// Nextデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : Nextデータの検索処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Delete()
        {
            // 論理削除
            int status = LogicalDeletePartsSubstU();

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする(未実装)
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : グリッドの各列の外観を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 代替元メーカーコード
            appearanceTable.Add(CHGSRCMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 代替元メーカー名称
            appearanceTable.Add(CHGSRCMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 代替元品番
            appearanceTable.Add(CHGSRCGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 代替先メーカーコード
            appearanceTable.Add(CHGDESTMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 代替先メーカー名称
            appearanceTable.Add(CHGDESTMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 代替先品番
            appearanceTable.Add(CHGDESTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 適用開始日
            appearanceTable.Add(APPLYSTADATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 適用終了日
            appearanceTable.Add(APPLYENDDATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// 部品代替設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="partsSubstU">部品代替設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note        : 部品代替設定クラスをデータセットに格納します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PartsSubstUToDataSet(PartsSubstU partsSubstU, int index)
        {
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            if ((index < 0) || (this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].NewRow();
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (partsSubstU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][DELETE_DATE] = partsSubstU.UpdateDateTimeJpInFormal;
            }

            // 代替元メーカーコード
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCMAKERCD_TITLE] = partsSubstU.ChgSrcMakerCd;

            // 代替元メーカー名称
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCMAKERNM_TITLE] = this._partsSubstUAcs.GetMakerName(partsSubstU.ChgSrcMakerCd);
            
            // 代替元品番
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCGOODSNO_TITLE] = partsSubstU.ChgSrcGoodsNo;

            // 代替先メーカーコード
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTMAKERCD_TITLE] = partsSubstU.ChgDestMakerCd;

            // 代替先メーカー名称
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTMAKERNM_TITLE] = this._partsSubstUAcs.GetMakerName(partsSubstU.ChgDestMakerCd);
            
            // 代替先品番
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTGOODSNO_TITLE] = partsSubstU.ChgDestGoodsNo;

            //--------------------
            // 適用開始日チェック
            //--------------------
            // 条件設定
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(partsSubstU.ApplyStaDate.Year);
            inParamList.Add(partsSubstU.ApplyStaDate.Month);
            inParamList.Add(partsSubstU.ApplyStaDate.Day);
            inParamObj = inParamList;

            // 適用開始日が正常の場合のみ設定
            if (CheckDetApplyDate(inParamObj, out outParamObj) == 0)
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYSTADATE_TITLE] = partsSubstU.ApplyStaDate;
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYSTADATE_TITLE] = DBNull.Value;
            }

            //--------------------
            // 適用終了日チェック
            //--------------------
            // 条件設定
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(partsSubstU.ApplyEndDate.Year);
            inParamList.Add(partsSubstU.ApplyEndDate.Month);
            inParamList.Add(partsSubstU.ApplyEndDate.Day);
            inParamObj = inParamList;

            // 適用終了日が正常の場合のみ設定
            if (CheckDetApplyDate(inParamObj, out outParamObj) == 0)
            {
                if ((partsSubstU.ApplyEndDate == DateTime.Parse("9999/12/31")) ||
                    (partsSubstU.ApplyEndDate == DateTime.MaxValue))
                {
                    // 適用終了日がMaxValueの場合は空白
                    this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = DBNull.Value;
                }
                else
                {
                    // 上記以外の場合は部品代替設定の値を設定
                    this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = partsSubstU.ApplyEndDate;
                }
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = DBNull.Value;
            }

            // ハッシュキー取得
            string hashKey = CreateHashKey(partsSubstU);

            // キー設定
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][GUID_TITLE] = hashKey;

            if (this._partsSubstUTable.ContainsKey(hashKey))
            {
                this._partsSubstUTable.Remove(hashKey);
            }
            this._partsSubstUTable.Add(hashKey, partsSubstU);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : データセットの列情報を構築します。
        ///                   データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable goodschangeUTable = new DataTable(PARTSSUBSTU_TABLE);

            // 2009.02.16 30413 犬飼 品番→メーカー順に変更-----
            // Addを行う順番が、列の表示順位となります。
            goodschangeUTable.Columns.Add(DELETE_DATE, typeof(string));	// 削除日
            goodschangeUTable.Columns.Add(CHGSRCGOODSNO_TITLE, typeof(string));	    // 代替元品番
            goodschangeUTable.Columns.Add(CHGSRCMAKERCD_TITLE, typeof(Int32));		// 代替元メーカーコード
            goodschangeUTable.Columns.Add(CHGSRCMAKERNM_TITLE, typeof(string));		// 代替元メーカー名
            goodschangeUTable.Columns.Add(CHGDESTGOODSNO_TITLE, typeof(string));	// 代替先品番
            goodschangeUTable.Columns.Add(CHGDESTMAKERCD_TITLE, typeof(Int32));		// 代替先メーカーコード
            goodschangeUTable.Columns.Add(CHGDESTMAKERNM_TITLE, typeof(string));	// 代替先メーカー名
            goodschangeUTable.Columns.Add(APPLYSTADATE_TITLE, typeof(DateTime));	// 適用開始日
            goodschangeUTable.Columns.Add(APPLYENDDATE_TITLE, typeof(DateTime));	// 適用終了日
            goodschangeUTable.Columns.Add(GUID_TITLE, typeof(string));	// GUID

            this.Bind_DataSet.Tables.Add(goodschangeUTable);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面のクリアを行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible = true;		// 完全削除ボタン
            this.Revive_Button.Visible = true;		// 復活ボタン
            this.Ok_Button.Visible = true;			// 保存ボタン
            this.Cancel_Button.Visible = true;		// 閉じるボタン

            // 項目
            this.ChgSrcMakerCd_tNedit.Clear();		// 代替元メーカーコード
            this.ChgSrcMakerCdNm_tEdit.Clear();		// 代替元メーカー名
            this.ChgSrcGoodsNo_tEdit.Clear();		// 代替元品番
            this.ChgSrcGoodsNoNm_tEdit.Clear();     // 代替元商品名
            
            this.ChgDestMakerCd_tNedit.Clear();		// 代替先メーカーコード
            this.ChgDestMakerCdNm_tEdit.Clear();	// 代替先メーカー名
            this.ChgDestGoodsNo_tEdit.Clear();		// 代替先品番
            this.ChgDestGoodsNoNm_tEdit.Clear();	// 代替先商品名		

            this.detApplyStaDate.Clear();			// 適用開始日
            this.detApplyEndDate.Clear();			// 適用終了日
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面の再構築処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // 新規の時
            if (this._dataIndex < 0)
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
                ScreenInputPermissionControl(INSERT_MODE);

                //------------
                // 初期値設定
                //------------
                // 適用開始日初期値設定（現在日付）
                this.detApplyStaDate.SetDateTime(DateTime.Today);

                PartsSubstU partsSubstU = new PartsSubstU();

                //クローン作成
                this._partsSubstUClone = partsSubstU.Clone();
                DispToPartsSubstU(ref this._partsSubstUClone);

                // 2009.02.16 30413 犬飼 初期フォーカスを代替元品番に変更-----
                // フォーカス設定
                //this.ChgSrcMakerCd_tNedit.Focus();
                this.ChgSrcGoodsNo_tEdit.Focus();

                // ADD 2008/10/10 不具合対応[6525] ---------->>>>>
                //前回値クリア
                this._chgSrcMakerCdWork = 0;			// 代替元メーカーコード（ワーク）
                this._chgDestMakerCdWork = 0;		// 代替先メーカーコード（ワーク）
                this._chgSrcGoodsNoWork = "";		// 代替元品番（ワーク）
                this._chgDestGoodsNoWork = "";	// 代替先品番（ワーク）
                // ADD 2008/10/10 不具合対応[6525] ----------<<<<<
            }
            else
            {
                // ハッシュキー取得
                string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

                if (partsSubstU.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ボタン設定
                    this.Ok_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // 画面展開処理
                    PartsSubstUToScreen(partsSubstU);

                    //クローン作成
                    this._partsSubstUClone = partsSubstU.Clone();
                    DispToPartsSubstU(ref this._partsSubstUClone);

                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    // フォーカス設定
                    this.detApplyStaDate.Focus();
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
                    ScreenInputPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    PartsSubstUToScreen(partsSubstU);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="editingMode">編集モード</param>
        /// <remarks>
        /// <br>Note        : 画面の入力許可を制御します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:		// 新規
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = true;			// 代替元メーカーコード
                        this.ChgSrcMakerGuide_Button.Enabled = true;		// 代替元メーカーガイド
                        this.ChgSrcGoodsNo_tEdit.Enabled = true;			// 代替元品番
                        
                        this.ChgDestMakerCd_tNedit.Enabled = true;			// 代替先メーカーコード
                        this.ChgDestMakerGuide_Button.Enabled = true;		// 代替先メーカーガイド
                        this.ChgDestGoodsNo_tEdit.Enabled = true;			// 代替先品番
                        
                        this.detApplyStaDate.Enabled = true;				// 適用開始日
                        this.detApplyEndDate.Enabled = true;				// 適用終了日

                        break;
                    }
                case UPDATE_MODE:		// 更新
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = false;			// 代替元メーカーコード
                        this.ChgSrcMakerGuide_Button.Enabled = false;		// 代替元メーカーガイド
                        this.ChgSrcGoodsNo_tEdit.Enabled = false;			// 代替元品番
                        
                        this.ChgDestMakerCd_tNedit.Enabled = false;			// 代替先メーカーコード
                        this.ChgDestMakerGuide_Button.Enabled = false;		// 代替先メーカーガイド
                        this.ChgDestGoodsNo_tEdit.Enabled = false;			// 代替先品番
                        
                        this.detApplyStaDate.Enabled = true;				// 適用開始日
                        this.detApplyEndDate.Enabled = true;				// 適用終了日

                        break;
                    }
                case DELETE_MODE:		// 削除
                case REFERENCE_MODE:	// 参照
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = false;			// 代替元メーカーコード
                        this.ChgSrcMakerGuide_Button.Enabled = false;		// 代替元メーカーガイド
                        this.ChgSrcGoodsNo_tEdit.Enabled = false;			// 代替元品番
                        
                        this.ChgDestMakerCd_tNedit.Enabled = false;			// 代替先メーカーコード
                        this.ChgDestMakerGuide_Button.Enabled = false;		// 代替先メーカーガイド
                        this.ChgDestGoodsNo_tEdit.Enabled = false;			// 代替先品番
                        
                        this.detApplyStaDate.Enabled = false;				// 適用開始日
                        this.detApplyEndDate.Enabled = false;				// 適用終了日

                        break;
                    }
            }
        }

        /// <summary>
        /// 部品代替設定マスタ　クラス画面展開処理
        /// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
        /// <remarks>
        /// <br>Note        : マスタ情報を画面に展開します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PartsSubstUToScreen(PartsSubstU partsSubstU)
        {
            // 商品名称検索用
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;
            ArrayList outParamList = null;

            this.ChgSrcMakerCd_tNedit.SetInt(partsSubstU.ChgSrcMakerCd);			// 代替元メーカーコード 
            this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();			// 代替元メーカーコードワーク
            this.ChgSrcMakerCdNm_tEdit.Text =
                this._partsSubstUAcs.GetMakerName(partsSubstU.ChgSrcMakerCd);		// 代替元メーカー名

            this.ChgSrcGoodsNo_tEdit.Text = partsSubstU.ChgSrcGoodsNo;				// 代替元品番
            this._chgSrcGoodsNoWork = this.ChgSrcGoodsNo_tEdit.Text;				// 代替元商品コードワーク

            //--------------------
            // 代替元商品名称取得
            //--------------------
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            // 条件設定
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // 存在チェック
            if (CheckGoodsNoCd(inParamObj, out outParamObj, false) == 0)
            {
                if ((outParamObj != null) && (outParamObj is ArrayList))
                {
                    outParamList = outParamObj as ArrayList;

                    if ((outParamList != null)
                        && (outParamList.Count == 5)
                        && (outParamList[1] is string)
                        && (outParamList[2] is string)
                        && (outParamList[3] is int)
                        && (outParamList[4] is string))
                    {
                        this.ChgSrcGoodsNoNm_tEdit.Text = (string)outParamList[2];	// 代替元商品名称
                    }
                }
            }
            
            this.ChgDestMakerCd_tNedit.SetInt(partsSubstU.ChgDestMakerCd);			// 代替先メーカーコード
            this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();			// 代替先メーカーコードワーク
            this.ChgDestMakerCdNm_tEdit.Text =
                this._partsSubstUAcs.GetMakerName(partsSubstU.ChgDestMakerCd);	// 代替先メーカー名

            this.ChgDestGoodsNo_tEdit.Text = partsSubstU.ChgDestGoodsNo;			// 代替先品番
            this._chgDestGoodsNoWork = this.ChgDestGoodsNo_tEdit.Text;				// 代替先商品コードワーク

            //--------------------
            // 代替先商品名称取得
            //--------------------
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            // 条件設定
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // 存在チェック
            if (CheckGoodsNoCd(inParamObj, out outParamObj, false) == 0)
            {
                if ((outParamObj != null) && (outParamObj is ArrayList))
                {
                    outParamList = outParamObj as ArrayList;

                    if ((outParamList != null)
                        && (outParamList.Count == 5)
                        && (outParamList[1] is string)
                        && (outParamList[2] is string)
                        && (outParamList[3] is int)
                        && (outParamList[4] is string))
                    {
                        this.ChgDestGoodsNoNm_tEdit.Text = (string)outParamList[2];	// 代替先商品名
                    }
                }
            }

            this.detApplyStaDate.SetDateTime(partsSubstU.ApplyStaDate);			// 適用開始日
            
            if ((partsSubstU.ApplyEndDate == DateTime.Parse("9999/12/31")) ||
                (partsSubstU.ApplyEndDate == DateTime.MaxValue))
            {
                // 適用終了日がMaxValueの場合は空白
                this.detApplyEndDate.Clear();                                   // 適用終了日
            }
            else
            {
                // 上記以外の場合は部品代替設定の値を設定
                this.detApplyEndDate.SetDateTime(partsSubstU.ApplyEndDate);     // 適用終了日
            }
        }

        /// <summary>
        /// 画面情報部品代替設定マスタ　クラス格納処理
        /// </summary>
        /// <param name="partsSubstU">部品代替設定マスタ　オブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報から部品代替設定マスタ　オブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispToPartsSubstU(ref PartsSubstU partsSubstU)
        {
            if (partsSubstU == null)
            {
                // 新規の場合
                partsSubstU = new PartsSubstU();
            }

            partsSubstU.EnterpriseCode = this._enterpriseCode;							// 企業コード
            partsSubstU.ChgSrcMakerCd = this.ChgSrcMakerCd_tNedit.GetInt();			    // 代替元メーカーコード
            partsSubstU.ChgSrcGoodsNo = this.ChgSrcGoodsNo_tEdit.Text.TrimEnd();		// 代替元品番
            partsSubstU.ChgSrcGoodsNoNoneHp = this.ChgSrcGoodsNo_tEdit.Text.TrimEnd().Replace("-", "");     // ハイフン無変換元商品番号
            partsSubstU.ChgDestMakerCd = this.ChgDestMakerCd_tNedit.GetInt();			// 代替先メーカーコード
            partsSubstU.ChgDestGoodsNo = this.ChgDestGoodsNo_tEdit.Text.TrimEnd();		// 代替先品番
            partsSubstU.ChgDestGoodsNoNoneHp = this.ChgDestGoodsNo_tEdit.Text.TrimEnd().Replace("-", "");   // ハイフン無変換先商品番号
            partsSubstU.ApplyStaDate = (DateTime)this.detApplyStaDate.GetDateTime();	// 適用開始日
            if (this.detApplyEndDate.GetLongDate() == 0)
            {
                // 未入力時は最大値を設定
                partsSubstU.ApplyEndDate = DateTime.MaxValue;                               // 適用終了日
            }
            else
            {
                partsSubstU.ApplyEndDate = (DateTime)this.detApplyEndDate.GetDateTime();	// 適用終了日
            }            
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果[true: OK, false: NG]</returns>
        /// <remarks>
        /// <br>Note        : 画面の入力情報の不正チェックを行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>   
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            //bool canChangeFocus = true;	// ここでは未使用
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            // 2009.02.16 30413 犬飼 品番→メーカー順に入力チェックを変更-----
            //-----------------------------
            // 代替元品番（必須入力）
            //-----------------------------
            // 条件設定クリア
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

            // 条件設定
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // 存在チェック
            switch (CheckGoodsNoCd(inParamObj, out outParamObj, false))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "代替元品番を入力してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                case (int)InputChkStatus.Cancel:
                    {
                        message = "代替元品番を選択してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "指定された条件で品番は存在しませんでした。";
                        dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// データ設定
            //DispSetChgSrcGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgSrcGoodsNo_tEdit;
                return false;
            }

            //---------------------------------
            // 代替元メーカーコード（必須入力）
            //---------------------------------
            // 条件設定クリア
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

            // 条件設定
            inParamObj = this.ChgSrcMakerCd_tNedit.GetInt();

            // 存在チェック
            switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "代替元メーカーコードを入力してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "指定された条件でメーカーコードは存在しませんでした。";
                        dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// データ設定
            //DispSetChgSrcMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgSrcMakerCd_tNedit;
                return false;
            }

            //-----------------------------
            // 代替先品番（必須入力）
            //-----------------------------
            // 条件設定クリア
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

            // 条件設定
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // 存在チェック
            switch (CheckGoodsNoCd(inParamObj, out outParamObj, false))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "代替先品番を入力してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                case (int)InputChkStatus.Cancel:
                    {
                        message = "代替先品番を選択してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "指定された条件で品番は存在しませんでした。";
                        dispSetStatus = this._chgDestGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// データ設定
            //DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgDestGoodsNo_tEdit;
                return false;
            }
            
            //---------------------------------
            // 代替先メーカーコード（必須入力）
            //---------------------------------
            // 条件設定クリア
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

            // 条件設定
            inParamObj = this.ChgDestMakerCd_tNedit.GetInt();

            // 存在チェック
            switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "代替先メーカーコードを入力してください。";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "指定された条件でメーカーコードは存在しませんでした。";
                        dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// データ設定
            //DispSetChgDestMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgDestMakerCd_tNedit;
                return false;
            }

            // 2008.10.16 30413 犬飼 代替元と代替先が同一商品かチェックを追加 >>>>>>START
            // 代替元と代替先の同一商品チェック
            if ((this.ChgSrcMakerCd_tNedit.GetInt() == this.ChgDestMakerCd_tNedit.GetInt()) &&
                (this.ChgSrcGoodsNo_tEdit.Text == this.ChgDestGoodsNo_tEdit.Text))
            {
                // 代替元と代替先が同一商品
                message = "代替元と代替先の商品が同一です。";
                control = this.ChgDestGoodsNo_tEdit;
                return false;
                        
            }

            //-----------------------
            // 適用開始日（必須入力）
            //-----------------------
            // 条件設定
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(this.detApplyStaDate.GetDateYear());
            inParamList.Add(this.detApplyStaDate.GetDateMonth());
            inParamList.Add(this.detApplyStaDate.GetDateDay());
            inParamObj = inParamList;

            // 適用開始日エラーチェック
            switch (CheckDetApplyDate(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        // 何もしない
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        // 未入力
                        control = this.detApplyStaDate;
                        message = "適用開始日が入力されていません。";
                        return false;
                    }
                case (int)InputChkStatus.InputErr:
                    {
                        // 不正データ
                        control = this.detApplyStaDate;
                        message = "適用開始日が正しくありません。";
                        return false;
                    }
            }

            //-------------------------------------------------
            // 適用終了日（任意入力）
            //-------------------------------------------------
            // 入力時
            if ((this.detApplyEndDate.GetDateYear() > 0)
                || (this.detApplyEndDate.GetDateMonth() > 0)
                || (this.detApplyEndDate.GetDateDay() > 0))
            {
                // 条件設定
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                inParamList.Add(this.detApplyEndDate.GetDateYear());
                inParamList.Add(this.detApplyEndDate.GetDateMonth());
                inParamList.Add(this.detApplyEndDate.GetDateDay());
                inParamObj = inParamList;

                // 適用終了日エラーチェック
                switch (CheckDetApplyDate(inParamObj, out outParamObj))
                {
                    case (int)InputChkStatus.Normal:
                        {
                            // 何もしない
                            break;
                        }
                    case (int)InputChkStatus.NotInput:
                        {
                            // 未入力
                            control = this.detApplyEndDate;
                            message = "適用終了日に入力漏れがあります。";
                            return false;
                        }
                    case (int)InputChkStatus.InputErr:
                        {
                            // 不正データ
                            control = this.detApplyEndDate;
                            message = "適用終了日が正しくありません。";
                            return false;
                        }
                }
            }

            //------------------------
            // 適用開始日・終了日判定
            //------------------------
            if ((this.detApplyStaDate.GetDateYear() > 0)
                && (this.detApplyStaDate.GetDateMonth() > 0)
                && (this.detApplyStaDate.GetDateDay() > 0)
                && (this.detApplyEndDate.GetDateYear() > 0)
                && (this.detApplyEndDate.GetDateMonth() > 0)
                && (this.detApplyEndDate.GetDateDay() > 0))
            {
                if (this.detApplyStaDate.GetDateTime() >= this.detApplyEndDate.GetDateTime())
                {
                    control = this.detApplyStaDate;
                    message = "「適用開始日　＜　適用終了日」で設定してください。";
                    return false;
                }
            }
            return result;
        }

        #region メーカーコードエラーチェック処理
        /// <summary>
        /// メーカーコードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードのエラーチェックを行います。
        ///					  条件オブジェクト:メーカーコード
        ///					  結果オブジェクト:メーカーマスタ検索結果ステータス, メーカー名称</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //------------------
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // 存在チェック
                //--------------
                MakerUMnt makerUMnt = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// メーカーマスタステータス設定

                if (makerUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    if (makerUMnt.LogicalDeleteCode == 0)
                    {
                        ret = (int)InputChkStatus.Normal;
                        outParamList.Add(makerUMnt.MakerName);	// メーカー名称設定
                    }
                    else
                    {
                        ret = (int)InputChkStatus.NotExist;
                    }
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        #endregion メーカーコードエラーチェック処理

        #region 部品代替設定エラーチェック処理
        /// <summary>
        /// 部品代替設定エラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <param name="sameWindowDiv">ウィンドウ表示区分</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定のエラーチェックを行います。
        ///					  条件オブジェクト:拠点コード, メーカーコード, メーカー名称, 商品コード
        ///					  結果オブジェクト:商品マスタ検索結果ステータス, 商品コード, 商品名称, メーカーコード, メーカー名称</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsNoCd(object inParamObj, out object outParamObj, bool sameWindowDiv)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;

            try
            {
                //------------------
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 4)) return ret;
                if ((inParamList[0] is string) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is string) == false) return ret;
                if ((inParamList[3] is string) == false) return ret;
                if ((string)inParamList[3] == "") return ret;

                //--------------
                // 存在チェック
                //--------------
                
                // 検索の種類を取得
                string searchCode;
                int searchType = GetSearchType((string)inParamList[3], out searchCode);

                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // 商品検索条件設定
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = (string)inParamList[0];
                goodsCndtn.GoodsMakerCd = (int)inParamList[1];
                goodsCndtn.MakerName = (string)inParamList[2];
                goodsCndtn.GoodsNo = (string)inParamList[3];
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 >>>>>>START
                //GoodsAcs goodsAcs = new GoodsAcs();
                //status = goodsAcs.SearchInitial(this._enterpriseCode, (string)inParamList[0], out message);
                // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 >>>>>>START
                //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out list, out message);
                //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, sameWindowDiv, out list, out message);
                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, sameWindowDiv, out list, out message);
                // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 <<<<<<END
                // 2008.10.08 30413 犬飼 商品アクセスクラスのパフォーマンス改善対策 <<<<<<END
            
                outParamList.Add(status);	// 商品マスタステータス設定

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品マスタデータクラス
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    goodsUnitData = (GoodsUnitData)list[0];

                    outParamList.Add(goodsUnitData.GoodsNo);		// 商品コード
                    outParamList.Add(goodsUnitData.GoodsName);		// 商品名設定
                    outParamList.Add(goodsUnitData.GoodsMakerCd);	// メーカーコード設定
                    outParamList.Add(goodsUnitData.MakerName);		// メーカー名設定

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // 選択ダイアログでキャンセル
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        #endregion 部品代替設定エラーチェック処理

        #region 適用日付エラーチェック処理
        /// <summary>
        /// 適用日付エラーチェック処理
        /// </summary>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note        : 適用日付エラーチェックを行います。
        ///				 	  条件オブジェクト:適用日付
        ///					  結果オブジェクト:無し</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckDetApplyDate(object inParamObj, out object outParamObj)
        {
            outParamObj = 0;	// 結果オブジェクトは未使用
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;

            ArrayList inParamList = null;

            try
            {
                //------------------
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is int) == false) return ret;

                if (((int)inParamList[0] > 0) && ((int)inParamList[1] > 0) && ((int)inParamList[2] > 0))
                {
                    // 入力が正しい日付か？
                    int inputDate_int = ((int)inParamList[0] * 10000) + ((int)inParamList[1] * 100) + ((int)inParamList[2]);
                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);

                    // 正しい
                    if (inputDate != DateTime.MinValue)
                    {
                        ret = (int)InputChkStatus.Normal;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.InputErr;	// 不正データ
                    }
                }
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion 適用日付エラーチェック処理

        #region 代替元メーカーコード設定処理
        /// <summary>
        /// 代替元メーカーコード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note        : 代替元メーカーコードを画面に設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgSrcMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.ChgSrcMakerCd_tNedit.Clear();
                            this.ChgSrcMakerCdNm_tEdit.Clear();

                            // 現在データクリア
                            this._chgSrcMakerCdWork = 0;

                            // 品番クリア
                            this.ChgSrcGoodsNo_tEdit.Clear();
                            this.ChgSrcGoodsNoNm_tEdit.Clear();
                            this._chgSrcGoodsNoWork = "";

                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.ChgSrcMakerCd_tNedit.SetInt(this._chgSrcMakerCdWork);

                            // フォーカス移動しない
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.ChgSrcMakerCdNm_tEdit.Text = (string)outParamList[1];	// メーカー名

                                    //----------------------------
                                    // メーカーコード変更チェック
                                    //----------------------------
                                    if (this._chgSrcMakerCdWork != this.ChgSrcMakerCd_tNedit.GetInt())
                                    {
                                        // メーカーコード変更時は、商品コードクリア
                                        this.ChgSrcGoodsNo_tEdit.Clear();
                                        this.ChgSrcGoodsNoNm_tEdit.Clear();
                                        this._chgSrcGoodsNoWork = "";
                                    }

                                    // 現在データ保存
                                    this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 代替元メーカーコード設定処理

        #region 代替元品番設定処理
        /// <summary>
        /// 代替元品番設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note        : 代替元品番を画面に設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgSrcGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.ChgSrcGoodsNo_tEdit.Clear();
                            this.ChgSrcGoodsNoNm_tEdit.Clear();

                            // 現在データクリア
                            this._chgSrcGoodsNoWork = "";

                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.ChgSrcGoodsNo_tEdit.Text = this._chgSrcGoodsNoWork;

                            // フォーカス移動しない
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 5)
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is int)
                                    && (outParamList[4] is string))
                                {
                                    this.ChgSrcGoodsNo_tEdit.Text = (string)outParamList[1];	// 代替元品番
                                    this.ChgSrcGoodsNoNm_tEdit.Text = (string)outParamList[2];	// 代替元商品
                                    this.ChgSrcMakerCd_tNedit.SetInt((int)outParamList[3]);	    // 代替元メーカーコード
                                    this.ChgSrcMakerCdNm_tEdit.Text = (string)outParamList[4];	// 代替元メーカー名

                                    // 現在データ保存
                                    this._chgSrcGoodsNoWork = this.ChgSrcGoodsNo_tEdit.Text;
                                    this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 代替元品番設定処理

        #region 代替先メーカーコード設定処理
        /// <summary>
        /// 代替先メーカーコード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note        : 代替先メーカーコードを画面に設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.ChgDestMakerCd_tNedit.Clear();
                            this.ChgDestMakerCdNm_tEdit.Clear();

                            // 現在データクリア
                            this._chgDestMakerCdWork = 0;

                            // 商品コードクリア
                            this.ChgDestGoodsNo_tEdit.Clear();
                            this.ChgDestGoodsNoNm_tEdit.Clear();
                            this._chgDestGoodsNoWork = "";

                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.ChgDestMakerCd_tNedit.SetInt(this._chgDestMakerCdWork);

                            // フォーカス移動しない
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.ChgDestMakerCdNm_tEdit.Text = (string)outParamList[1];	// メーカー名

                                    //----------------------------
                                    // メーカーコード変更チェック
                                    //----------------------------
                                    if (this._chgDestMakerCdWork != this.ChgDestMakerCd_tNedit.GetInt())
                                    {
                                        // メーカーコード変更時は、商品コードクリア
                                        this.ChgDestGoodsNo_tEdit.Clear();
                                        this.ChgDestGoodsNoNm_tEdit.Clear();
                                        this._chgDestGoodsNoWork = "";
                                    }

                                    // 現在データ保存
                                    this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 代替先メーカーコード設定処理

        #region 代替先品番設定処理
        /// <summary>
        /// 代替先品番設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note        : 代替先品番を画面に設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.ChgDestGoodsNo_tEdit.Clear();
                            this.ChgDestGoodsNoNm_tEdit.Clear();

                            // 現在データクリア
                            this._chgDestGoodsNoWork = "";

                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.ChgDestGoodsNo_tEdit.Text = this._chgDestGoodsNoWork;

                            // フォーカス移動しない
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 5)
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is int)
                                    && (outParamList[4] is string))
                                {
                                    this.ChgDestGoodsNo_tEdit.Text = (string)outParamList[1];	// 代替先品番
                                    this.ChgDestGoodsNoNm_tEdit.Text = (string)outParamList[2];	// 代替先品名
                                    this.ChgDestMakerCd_tNedit.SetInt((int)outParamList[3]);	// 代替先メーカーコード
                                    this.ChgDestMakerCdNm_tEdit.Text = (string)outParamList[4];	// 代替先メーカー名

                                    // 現在データ保存
                                    this._chgDestGoodsNoWork = this.ChgDestGoodsNo_tEdit.Text;
                                    this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 代替先品番設定処理

        #region 検索タイプ取得処理
        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// <br>Note		: 検索する方法を取得する処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }
        #endregion 検索タイプ取得処理

        /// <summary>
        /// 部品代替設定マスタ　情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定マスタ　情報登録を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ
                    0,                                  // ステータス値
                    MessageBoxButtons.OK);             // 表示するボタン

                control.Focus();
                return false;
            }

            // 部品代替設定更新
            SavePartsSubstU();

            return true;
        }

        /// <summary>
        /// 部品代替設定更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note        : 部品代替設定の更新を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private bool SavePartsSubstU()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            PartsSubstU partsSubstU = null;

            if (this._dataIndex >= 0)
            {
                // ハッシュキー取得
                string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();
            }

            DispToPartsSubstU(ref partsSubstU);

            // 書き込み
            status = this._partsSubstUAcs.Write(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                           // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                            ASSEMBLY_ID,                    // アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,                    // 表示するメッセージ
                            0,                              // ステータス値
                            MessageBoxButtons.OK);          // 表示するボタン

                        this.ChgSrcMakerCd_tNedit.Focus();
                        this.ChgSrcMakerCd_tNedit.SelectAll();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return false;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SavePartsSubstU",					// 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_UPDT_MSG,                       // 表示するメッセージ
                            status,                             // ステータス値
                            this._partsSubstUAcs,               // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return false;
                    }
            }

            // DataSet展開処理
            PartsSubstUToDataSet(partsSubstU, this._dataIndex);

            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// 部品代替設定 論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int LogicalDeletePartsSubstU()
        {
            int status = 0;
            int dummy = 0;

            // ハッシュキー取得
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // 論理削除
            status = this._partsSubstUAcs.LogicalDelete(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet更新の為
                        Search(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        // フレーム更新
                        Search(ref dummy, 0);
                        return status;
                    }
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

                        // フレーム更新
                        Search(ref dummy, 0);
                        return status;
                    }

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
                            this._partsSubstUAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        // フレーム更新
                        Search(ref dummy, 0);
                        return status;
                    }
            }

            // データセット展開処理
            PartsSubstUToDataSet(partsSubstU.Clone(), this._dataIndex);
            return status;
        }

        /// <summary>
        /// 部品代替設定 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int PhysicalDeletePartsSubstU()
        {
            int status = 0;

            // ハッシュキー取得
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // 物理削除
            status = this._partsSubstUAcs.Delete(partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet更新の為
                        this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex].Delete();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return status;
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
                            this._partsSubstUAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        this.Hide();

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            int dummy = 0;
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了させずに連続入力を可能とする。
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // データインデックスを初期化する
                this._dataIndex = -1;

                // フレーム更新
                Search(ref dummy, 0);

                // 画面クリア処理
                ScreenClear();

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;
                
                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                ScreenInputPermissionControl(INSERT_MODE);

                Initial_Timer.Enabled = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                //_dataIndexバッファ保持
                this._indexBuf = -2;
            }
        }

        /// <summary>
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
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
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : 排他処理を行います</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            ERR_800_MSG,							// 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            ERR_801_MSG,							// 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                        break;
                    }
            }
        }

        # region HashTable用Key作成
        /// <summary>
        /// HashTable用Key作成
        /// </summary>
        /// <param name="goodsChangeU">商品変換クラス</param>
        /// <returns>Hash用Key</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定クラスからハッシュテーブル用の
        ///					  キーを作成します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private string CreateHashKey(PartsSubstU partsSubstU)
        {
            return partsSubstU.ChgSrcMakerCd.ToString("d6") +
                    partsSubstU.ChgSrcGoodsNo.PadRight(40) +
                    partsSubstU.ChgDestMakerCd.ToString("d6") +
                    partsSubstU.ChgDestGoodsNo.PadRight(40);
        }
        #endregion HashTable用Key作成

        /// <summary>
        /// Form.Load イベント (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_Load(object sender, EventArgs e)
        {
            this.ChgSrcMakerGuide_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.ChgDestMakerGuide_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;         // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;     // 閉じるボタン
            this.Revive_Button.ImageList = imageList24;     // 復活ボタン
            this.Delete_Button.ImageList = imageList24;     // 完全削除ボタン

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;            // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;       // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;     // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;      // 完全削除ボタン
        }

        /// <summary>
        /// Form.FormClosing イベント (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_dataIndexバッファ保持
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
        /// Form.VisibleChanged イベント (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォームの表示状態が変化した時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            Initial_Timer.Enabled = true;
        }


        /// <summary>
        /// UltraButton.Click イベント (Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 保存ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 登録処理
            SaveProc();
        }

        /// <summary>
        /// UltraButton.Click イベント (Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                PartsSubstU comparePartsSubstU = new PartsSubstU();
                comparePartsSubstU = this._partsSubstUClone.Clone();

                //現在の画面情報を取得する
                DispToPartsSubstU(ref comparePartsSubstU);

                // 最初に取得した画面と比較
                if (!(this._partsSubstUClone.Equals(comparePartsSubstU)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する。
                    DialogResult res = TMsgDisp.Show(
                        this,                               // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ
                        0,                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

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

            //_dataIndexバッファ保持
            this._indexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

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
        /// UltraButton.Click イベント (Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 完全削除ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        // </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                CONF_DEL_MSG,						// 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OKCancel,         // 表示するボタン
                MessageBoxDefaultButton.Button2);  // 初期表示ボタン

            if (result == DialogResult.OK)
            {
                // 部品代替設定物理削除
                PhysicalDeletePartsSubstU();
            }
            else
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            //_dataIndexバッファ保持
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
        /// UltraButton.Click イベント (Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 復活ボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ハッシュキー取得
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // 論理削除復活
            status = this._partsSubstUAcs.Revival(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(this,						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリID
                            SDC_RDEL_MSG,						// 表示するメッセージ
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

                        this.Hide();
                        break;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            ERR_RVV_MSG,                        // 表示するメッセージ
                            status,                             // ステータス値
                            this._partsSubstUAcs,              // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);  // 初期表示ボタン

                        this.Hide();
                        return;
                    }
            }

            PartsSubstUToDataSet(partsSubstU, this._dataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            //_dataIndexバッファ保持
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
        /// Timer.Tick イベント (Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        // --------------------------------------------------
        #region ChangeFocus Events
        /// <summary>Control.ChangeFocus イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォーカス移動時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;
            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = new ArrayList();

            switch (e.PrevCtrl.Name)
            {
                #region 代替元メーカーコード
                case "ChgSrcMakerCd_tNedit":
                    {
                        if ((this._chgSrcMakerCdWork == 0) && (this.ChgSrcMakerCd_tNedit.GetInt() == 0))
                        {
                            // 未入力時は存在チェック等は実施しない
                            break;
                        }
                        else if (this._chgSrcMakerCdWork == this.ChgSrcMakerCd_tNedit.GetInt())
                        {
                            // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                            // 値が変更されていない場合は存在チェック等は実施しない
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.ChgSrcGoodsNo_tEdit;
                            //}
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                }
                            }
                            break;
                        }

                        // 条件設定
                        inParamObj = this.ChgSrcMakerCd_tNedit.GetInt();

                        // 存在チェック
                        switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    //{
                                    //    //e.NextCtrl = this.ChgSrcGoodsNo_tEdit;
                                    //    //e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                    //}
                                    if (!e.ShiftKey)
                                    {
                                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                        {
                                            e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                        }
                                    }
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 													// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                                            this.Name,												// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            0,														// ステータス値
                                            MessageBoxButtons.OK);									// 表示するボタン

                                    dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // データ設定
                        DispSetChgSrcMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                        break;
                    }
                #endregion

                #region 代替元品番
                case "ChgSrcGoodsNo_tEdit":
                    {
                        if ((this.ChgSrcMakerCd_tNedit.GetInt() == 0) && (this.ChgSrcGoodsNo_tEdit.Text == "")) 
                        {
                            // メーカーと品番が未入力の場合は存在チェックを行わない
                            break;
                        }
                        else if ((this.ChgSrcMakerCd_tNedit.GetInt() != 0) && (this.ChgSrcGoodsNo_tEdit.Text != "") &&
                                 (this._chgSrcMakerCdWork == this.ChgSrcMakerCd_tNedit.GetInt()) &&
                                 (this._chgSrcGoodsNoWork == this.ChgSrcGoodsNo_tEdit.Text))
                        {
                            // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                            // メーカーと品番が入力済みで値が変更されていない場合は存在チェックを行わない
                            //if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                            //}
                            break;
                        }

                        // 条件設定
                        inParamList.Add(this._sectionCode);
                        //inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt()); // DEL 2009/03/16
                        //inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text); // DEL 2009/03/16
                        inParamList.Add(0); // ADD 2009/03/16
                        inParamList.Add(string.Empty); // ADD 2009/03/16
                        inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
                        inParamObj = inParamList;

                        // 存在チェック
                        switch (CheckGoodsNoCd(inParamObj, out outParamObj, true))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            case (int)InputChkStatus.Cancel:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で品番は存在しませんでした。", // 表示するメッセージ
                                            0,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                                    dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // データ設定
                        DispSetChgSrcGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

                        // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                        // フォーカス変更時
                        //if ((canChangeFocus) && (e.ShiftKey) && (e.Key == Keys.Tab))
                        //{
                        //    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                        //}
                        
                        break;
                    }
                #endregion

                #region 代替先メーカーコード
                case "ChgDestMakerCd_tNedit":
                    {
                        if ((this._chgDestMakerCdWork == 0) && (this.ChgDestMakerCd_tNedit.GetInt() == 0))
                        {
                            // 未入力時は存在チェック等は実施しない
                            break;
                        }
                        else if (this._chgDestMakerCdWork == this.ChgDestMakerCd_tNedit.GetInt())
                        {
                            // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                            // 値が変更されていない場合は存在チェック等は実施しない
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            //{
                            //    //e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                            //}
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.detApplyStaDate;
                                }
                            }
                            break;
                        }

                        // 条件設定
                        inParamObj = this.ChgDestMakerCd_tNedit.GetInt();

                        // 存在チェック
                        switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    //{
                                    //    e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                    //}
                                    if (!e.ShiftKey)
                                    {
                                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                        {
                                            e.NextCtrl = this.detApplyStaDate;
                                        }
                                    }
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 													// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 							// エラーレベル
                                            this.Name,												// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            0,														// ステータス値
                                            MessageBoxButtons.OK);									// 表示するボタン

                                    dispSetStatus = this._chgDestMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // データ設定
                        DispSetChgDestMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            
                        break;
                    }
                #endregion

                #region 代替先品番
                case "ChgDestGoodsNo_tEdit":
                    {
                        if ((this.ChgDestMakerCd_tNedit.GetInt() == 0) && (this.ChgDestGoodsNo_tEdit.Text == ""))
                        {
                            // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                            // メーカーと品番が未入力の場合は存在チェックを行わない
                            if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            {
                                if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                                {
                                    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                                }
                            }
                            break;
                        }
                        else if ((this.ChgDestMakerCd_tNedit.GetInt() != 0) && (this.ChgDestGoodsNo_tEdit.Text != "") &&
                                 (this._chgDestMakerCdWork == this.ChgDestMakerCd_tNedit.GetInt()) &&
                                 (this._chgDestGoodsNoWork == this.ChgDestGoodsNo_tEdit.Text))
                        {
                            // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                            // メーカーと品番が入力済みで値が変更されていない場合は存在チェックを行わない
                            if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            {
                                //e.NextCtrl = this.ChgDestMakerCd_tNedit;
                                if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                                {
                                    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                                }
                            }
                            break;
                        }

                        // 条件設定
                        inParamList.Add(this._sectionCode);
                        //inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt()); // DEL 2009/03/16
                        //inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text); // DEL 2009/03/16
                        inParamList.Add(0); // ADD 2009/03/16
                        inParamList.Add(string.Empty); // ADD 2009/03/16
                        inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
                        inParamObj = inParamList;

                        // 存在チェック
                        switch (CheckGoodsNoCd(inParamObj, out outParamObj, true))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            case (int)InputChkStatus.Cancel:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で品番は存在しませんでした。", // 表示するメッセージ
                                            0,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                                    dispSetStatus = this._chgDestGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // データ設定
                        DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

                        // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                        // フォーカス変更時
                        if ((canChangeFocus) && (e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            //e.NextCtrl = this.ChgDestMakerCd_tNedit;
                            if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                            {
                                e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                            }
                        }

                        break;
                    }
                #endregion

                // 2009.02.16 30413 犬飼 フォーカス制御を修正-----
                #region 適用開始日
                case "detApplyStaDate":
                    {
                        // 代替先のメーカーコードが設定済
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.ChgDestMakerCd_tNedit.GetInt() != 0)
                            {
                                e.NextCtrl = this.ChgDestMakerCd_tNedit;
                            }
                        }
                        break;
                    }
                #endregion
            }

            // フォーカス制御
            if (canChangeFocus == false)
            {
                e.NextCtrl = e.PrevCtrl;

                // 現在の項目から移動せず、テキスト全選択状態とする
                e.NextCtrl.Select();
            }

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "ChgDestGoodsNo_tEdit":        // 代替先品番
                case "ChgDestMakerCd_tNedit":       // 代替先メーカーコード
                case "ChgDestMakerGuide_Button":    // 代替先メーカーガイド
                case "detApplyStaDate":     // 適用開始日
                case "detApplyEndDate":     // 適用終了日
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = ChgSrcGoodsNo_tEdit;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }
        #endregion ChangeFocus Events

        #region ガイド処理
        /// <summary>
        /// ChgSrcMakerGuide_Button_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 代替元メーカーガイドボタンを押下すると発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ChgSrcMakerGuide_Button_Click(object sender, EventArgs e)
        {
            int goodsMakerCd = 0;
            string makerName = "";

            if (GoodsMakerCdGuide(out goodsMakerCd, out makerName) == 0)
            {
                this.ChgSrcMakerCd_tNedit.SetInt(goodsMakerCd);
                this.ChgSrcMakerCdNm_tEdit.Text = makerName;

                // 現在データ保存
                this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ChgDestMakerGuide_Button_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 代替先メーカーガイドボタンを押下すると発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ChgDestMakerGuide_Button_Click(object sender, EventArgs e)
        {
            int goodsMakerCd = 0;
            string makerName = "";

            if (GoodsMakerCdGuide(out goodsMakerCd, out makerName) == 0)
            {
                this.ChgDestMakerCd_tNedit.SetInt(goodsMakerCd);
                this.ChgDestMakerCdNm_tEdit.Text = makerName;

                //----------------------------
                // メーカーコード変更チェック
                //----------------------------
                if (this.ChgDestMakerCd_tNedit.GetInt() != this._chgDestMakerCdWork)
                {
                    // 商品コードクリア
                    this.ChgDestGoodsNo_tEdit.Clear();
                    this.ChgDestGoodsNoNm_tEdit.Clear();
                }

                // 現在データ保存
                this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// メーカーコードガイド起動処理
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="makerName">メーカーコード名称</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードガイドを起動します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int GoodsMakerCdGuide(out int goodsMakerCd, out string makerName)
        {
            MakerUMnt makerUMnt;
            goodsMakerCd = 0;
            makerName = "";

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);  // ガイドデータ

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                goodsMakerCd = makerUMnt.GoodsMakerCd;
                makerName = makerUMnt.MakerName.TrimEnd();
            }
            return status;
        }

        #endregion ガイド処理

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 代替元品番
            string chgSrcGoodsNo = ChgSrcGoodsNo_tEdit.Text.TrimEnd();
            // 代替元メーカーコード
            int chgSrcMakerCd = ChgSrcMakerCd_tNedit.GetInt();
            //// 代替先品番
            //string chgDestGoodsNo = ChgDestGoodsNo_tEdit.Text.TrimEnd();
            //// 代替先メーカーコード
            //int chgDestMakerCd = ChgDestMakerCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsChgSrcGoodsNo = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGSRCGOODSNO_TITLE];
                int dsChgSrcMakerCd = (int)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGSRCMAKERCD_TITLE];
                //string dsChgDestGoodsNo = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGDESTGOODSNO_TITLE];
                //int dsChgDestMakerCd = (int)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGDESTMAKERCD_TITLE];
                if ((chgSrcGoodsNo.Equals(dsChgSrcGoodsNo.TrimEnd())) &&
                    (chgSrcMakerCd == dsChgSrcMakerCd))
                    //(chgSrcMakerCd == dsChgSrcMakerCd) &&
                    //(chgDestGoodsNo.Equals(dsChgDestGoodsNo.TrimEnd())) &&
                    //(chgDestMakerCd == dsChgDestMakerCd))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの代替マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 代替元／代替先のクリア
                        ChgSrcGoodsNo_tEdit.Clear();
                        ChgSrcGoodsNoNm_tEdit.Clear();
                        ChgSrcMakerCd_tNedit.Clear();
                        ChgSrcMakerCdNm_tEdit.Clear();
                        //ChgDestGoodsNo_tEdit.Clear();
                        //ChgDestGoodsNoNm_tEdit.Clear();
                        //ChgDestMakerCd_tNedit.Clear();
                        //ChgDestMakerCdNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの代替マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 代替元／代替先のクリア
                                ChgSrcGoodsNo_tEdit.Clear();
                                ChgSrcGoodsNoNm_tEdit.Clear();
                                ChgSrcMakerCd_tNedit.Clear();
                                ChgSrcMakerCdNm_tEdit.Clear();
                                //ChgDestGoodsNo_tEdit.Clear();
                                //ChgDestGoodsNoNm_tEdit.Clear();
                                //ChgDestMakerCd_tNedit.Clear();
                                //ChgDestMakerCdNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}