//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : BLコードガイドマスタ
// プログラム概要   : BLコードガイドマスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 作 成 日  2008/09/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  12694       作成担当 : 工藤　恵優
// 修 正 日  2009/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // メインテーブルの削除日をサブテーブルに関連させるフラグ

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Resources;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLコードガイドマスタUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: BLコードガイドマスタのUI設定を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/09/30</br>
    /// <br>Note		: 「削除済データの表示」は最上位項目で制御</br>
    /// <br>Programmer	: 30434 工藤　恵優</br>
    /// <br>Date		: 2009/03/24</br>
    /// </remarks>
    public partial class PMKHN09230UA : Form, IMasterMaintenanceArrayType
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKHN09230U";

        // テーブル名称
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // データビュータイトル
        private const string GRIDTITLE_SECTION = "拠点";
        private const string GRIDTITLE_BLGOODSCODE = "BLｺｰﾄﾞ";

        // データビュー表示用
        private const string VIEW_SECTIONCODE = "拠点コード";
        private const string VIEW_SECTIONNAME = "拠点名";
        private const string VIEW_DELETEDATE = "削除日";
        private const string VIEW_BLGOODSCODE = "BLｺｰﾄﾞ";
        private const string VIEW_BLGOODSCODENAME = "BLｺｰﾄﾞ名";

        // グリッド列タイトル
        private const string COLUMN_BLGOODSCODE = "BLGoodsCode";
        private const string COLUMN_BLGOODSCODEGUIDE = "BLGoodsCodeGuide";
        private const string COLUMN_BLGOODSCODENAME = "BLGoodsCodeName";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 各グリッド行数
        private const int ROWCOUNT = 18;

        #endregion ■ Constants


        #region ■ Private Members

        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;

        private MGridDisplayLayout _defaultGridDisplayLayout;

        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        private string _enterpriseCode;

        private BLCodeGuideAcs _bLCodeGuidAcs;              // BLコードガイドマスタアクセスクラス
        private SecInfoAcs _secInfoAcs;                     // 拠点マスタアクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;               // 拠点情報設定マスタアクセスクラス
        private BLGoodsCdAcs _bLGoodsCdAcs;                 // BLコードマスタアクセスクラス

        private List<BLCodeGuide> _bLCodeGuideListClone;    // BLコードガイドマスタリストClone
        private UltraGrid[] _bLGoodsCode_Grid;              // グリッド用配列

        private ControlScreenSkin _controlScreenSkin;       // 画面デザイン変更クラス

        private Dictionary<string, SecInfoSet> _mainList;
        private List<BLCodeGuide> _detailList;

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		
        #endregion ■ Private Members


        # region ■ Constructor

        /// <summary>
        /// BLコードガイドマスタUIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタUIクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public PMKHN09230UA()
        {
            InitializeComponent();

            this._canClose = true;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            // 各種インデックス初期化
            this._mainDataIndex = -1;
            this._detailDataIndex = -1;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._controlScreenSkin = new ControlScreenSkin();

            // インスタンス生成
            this._bLCodeGuidAcs = new BLCodeGuideAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            // グリッドを配列にセット
            this._bLGoodsCode_Grid = new UltraGrid[15];
            this._bLGoodsCode_Grid[0] = this.uGrid_BLGoodsCode1;
            this._bLGoodsCode_Grid[1] = this.uGrid_BLGoodsCode2;
            this._bLGoodsCode_Grid[2] = this.uGrid_BLGoodsCode3;
            this._bLGoodsCode_Grid[3] = this.uGrid_BLGoodsCode4;
            this._bLGoodsCode_Grid[4] = this.uGrid_BLGoodsCode5;
            this._bLGoodsCode_Grid[5] = this.uGrid_BLGoodsCode6;
            this._bLGoodsCode_Grid[6] = this.uGrid_BLGoodsCode7;
            this._bLGoodsCode_Grid[7] = this.uGrid_BLGoodsCode8;
            this._bLGoodsCode_Grid[8] = this.uGrid_BLGoodsCode9;
            this._bLGoodsCode_Grid[9] = this.uGrid_BLGoodsCode10;
            this._bLGoodsCode_Grid[10] = this.uGrid_BLGoodsCode11;
            this._bLGoodsCode_Grid[11] = this.uGrid_BLGoodsCode12;
            this._bLGoodsCode_Grid[12] = this.uGrid_BLGoodsCode13;
            this._bLGoodsCode_Grid[13] = this.uGrid_BLGoodsCode14;
            this._bLGoodsCode_Grid[14] = this.uGrid_BLGoodsCode15;

            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();
        }

        # endregion ■ Constructor


        #region ■ IMasterMaintenanceArrayType メンバ

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return _canDelete; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return _canNew; }
        }

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return _defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>操作対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get
            {
                return _targetTableName;
            }
            set
            {
                _targetTableName = value;
            }
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));    // ADD 2008/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御
            main.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            main.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // 詳細
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_BLGOODSCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_BLGOODSCODENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = { TABLE_MAIN, TABLE_DETAIL };
            tableName = strRet;
        }

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };   // MOD 2008/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 { false, true }→{ true, false }
            return logicalDeleteButton;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButton = { true, false };
            return deleteButton;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { null, null };
            return gridIcon;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SECTION, GRIDTITLE_BLGOODSCODE };
            return gridTitle;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButton = { true, false };
            return modifyButton;
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButton = { true, false };
            return newButton;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailDataIndex = intVal[1];
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Delete()
        {
            // 論理削除処理
            bool bStatus = LogicalDeleteProc();
            if (!bStatus)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList bLCodeGuideList;

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 選択されているデータを取得する
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

            // 検索処理（論理削除含む）
            int status = this._bLCodeGuidAcs.Search(out bLCodeGuideList, this._enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll);
            
            // BLコードガイドをキャッシュ
            CacheBLCodeGuideList(ConvertSectionCodeNumber(sectionCode), bLCodeGuideList);   // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得したクラスをデータセットへ展開する
                        int index = 0;
                        foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                        {
                            // DataSet展開処理
                            DetailToDataSet(bLCodeGuide, index);
                            index++;
                        }

                        totalCount = bLCodeGuideList.Count;

                        if (status == 0)
                        {
                            this._canNew = false;
                        }
                        else
                        {
                            this._canNew = true;
                        }

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DetailsDataSearch",
                                       "読み込みに失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            // メインテーブルの削除日をサブテーブルから設定
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御

            return 0;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<string, SecInfoSet>();
            this._detailList = new List<BLCodeGuide>();

            // 拠点マスタに登録されている拠点一覧を取得
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._mainList.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }

            ArrayList retList;

            int status = this._bLCodeGuidAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        foreach (BLCodeGuide bLCodeGuide in retList)
                        {
                            this._detailList.Add(bLCodeGuide);
                        }

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "読み込みに失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            // 読み込んだインスタンスのそれぞれをデータセットに展開
            int index = 0;
            foreach (SecInfoSet secInfoSet in this._mainList.Values)
            {
                // DataSet展開処理
                MainToDataSet(secInfoSet, index);
                index++;
            }

            totalCount = this._mainList.Count;

            // メインテーブルの削除日をサブテーブルから設定
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御

            return 0;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 0;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // 未実装
            return 0;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Print()
        {
            // 未実装
            return 0;
        }

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        #endregion ■ IMasterMaintenanceArrayType メンバ


        #region ■ Private Methods

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社は対象外
            if ((sectionCode.Trim() == "") || (sectionCode.Trim().PadLeft(2, '0') == "00"))
            {
                return "";
            }

            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionName = secInfoSet.SectionGuideNm.Trim();
                            break;
                        }
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
        /// BLコード名取得処理
        /// </summary>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <returns>BLコード名</returns>
        /// <remarks>
        /// <br>Note       : BLコード名を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetBLGoodsCodeName(int bLGoodsCode)
        {
            string bLGoodsCodeName = "";

            try
            {
                BLGoodsCdUMnt bLGoodsCdUMnt;

                // 読込
                int status = this._bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCode);
                if (status == 0)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        bLGoodsCodeName = bLGoodsCdUMnt.BLGoodsHalfName.Trim();
                    }
                }
            }
            catch
            {
                bLGoodsCodeName = "";
            }

            return bLGoodsCodeName;
        }

        /// <summary>
        /// DataSet展開処理(メインテーブル)
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドマスタ</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : BLコードマスタをDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // 削除日
            // ADD 2008/03/24 不具合対応[12694]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = GetDeleteDate(secInfoSet);

            // 拠点コード
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SECTIONCODE] = secInfoSet.SectionCode.Trim();
            // 拠点名称
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SECTIONNAME] = GetSectionName(secInfoSet.SectionCode.Trim());
        }

        // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="makerUMnt">BLコードガイドマスタ</param>
        /// <returns>メインテーブルの削除日（削除されていない場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDeleteDate(SecInfoSet secInfoSet)
        {
            if (secInfoSet.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return secInfoSet.UpdateDateTimeJpInFormal;
            }
        }

        #region <BLコードガイドのキャッシュ/>

        /// <summary>BLコードガイドのキャッシュ</summary>
        /// <remarks>キー：拠点コード</remarks>
        private readonly IDictionary<int, ArrayList> _blCodeGuideListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// BLコードガイドのキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> BLCodeGuideListCacheMap
        {
            get { return _blCodeGuideListCacheMap; }
        }

        /// <summary>
        /// 拠点コードの数値に変換します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点コードの数値</returns>
        private int ConvertSectionCodeNumber(string sectionCode)
        {
            return string.IsNullOrEmpty(sectionCode.Trim()) ? 0 : int.Parse(sectionCode.Trim());
        }

        /// <summary>
        /// BLコードガイドをキャッシュします。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="blCodeGuideList">BLコードガイドのレコードリスト</param>
        private void CacheBLCodeGuideList(
            int sectionCode,
            ArrayList blCodeGuideList
        )
        {
            if (BLCodeGuideListCacheMap.ContainsKey(sectionCode))
            {
                BLCodeGuideListCacheMap.Remove(sectionCode);
            }
            BLCodeGuideListCacheMap.Add(sectionCode, (blCodeGuideList != null ? blCodeGuideList : new ArrayList()));
        }

        /// <summary>
        /// BLコードガイドのキャッシュをリセットします。
        /// </summary>
        private void ResetBLCodeGuideCache()
        {
            BLCodeGuideListCacheMap.Clear();
        }

        #endregion  // <BLコードガイドのキャッシュ/>

        /// <summary>
        /// メインテーブルの削除日を設定します。
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = TABLE_MAIN;
            const string RELATION_COLUMN_NAME   = VIEW_SECTIONCODE;
            const string SUB_TABLE_NAME         = TABLE_DETAIL;
            const string DELETE_DATE_COLUMN_NAME= VIEW_DELETEDATE;

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // 対応するサブテーブルのレコードを抽出
                string relationColumn = mainRow[RELATION_COLUMN_NAME].ToString();
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "='" + relationColumn.ToString() + "'"
                );
                Debug.WriteLine("関連 = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "件");

                if (foundSubRows.Length.Equals(0))
                {
                    #region サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定

                    // 拠点コード指定 BLコードガイド検索処理（論理削除含む）
                    int sectionCode = ConvertSectionCodeNumber(relationColumn);
                    ArrayList blCodeGuideList = null;
                    if (BLCodeGuideListCacheMap.ContainsKey(sectionCode))
                    {
                        blCodeGuideList = BLCodeGuideListCacheMap[sectionCode];
                    }
                    else
                    {
                        int status = this._bLCodeGuidAcs.Search(out blCodeGuideList, this._enterpriseCode, relationColumn, ConstantManagement.LogicalMode.GetDataAll);
                        CacheBLCodeGuideList(sectionCode, blCodeGuideList);
                    }
                    if (blCodeGuideList == null || blCodeGuideList.Count.Equals(0)) continue;

                    // 削除日を降順で抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (BLCodeGuide blCodeGuide in blCodeGuideList)
                    {
                        if (blCodeGuide.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(blCodeGuide.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                blCodeGuide.UpdateDateTimeJpInFormal,
                                blCodeGuide.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(blCodeGuideList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定
                }
                else
                {
                    #region サブテーブルに該当レコードがある場合、サブテーブルより設定

                    // 削除日を降順に抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("削除日：" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
                        if (string.IsNullOrEmpty(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            continue;
                        }

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            sortedDeleteDateList.Add(
                                subRow[DELETE_DATE_COLUMN_NAME].ToString(),
                                subRow[DELETE_DATE_COLUMN_NAME].ToString()
                            );
                        }
                    }

                    // サブテーブルが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードがある場合、サブテーブルより設定
                }
            }
        }
        // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// DataSet展開処理(詳細テーブル)
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドマスタ</param>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// <br>Note       : BLコードマスタをDataSetに展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void DetailToDataSet(BLCodeGuide bLCodeGuide, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONCODE] = bLCodeGuide.SectionCode.ToString().Trim();   // ADD 2008/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御

            // BLコード
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_BLGOODSCODE] = bLCodeGuide.BLGoodsCode.ToString("00000");
            // BL名称
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_BLGOODSCODENAME] = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);
            // 削除日
            if (bLCodeGuide.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = bLCodeGuide.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// DataSet列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet列情報を構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // メイン
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string)); // ADD 2008/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御
            mainTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));

            //==============================
            // 詳細
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));  // ADD 2008/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御
            detailTable.Columns.Add(VIEW_BLGOODSCODE, typeof(string));
            detailTable.Columns.Add(VIEW_BLGOODSCODENAME, typeof(string));
            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 拠点
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // グリッド
            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._bLGoodsCode_Grid[index].Rows.Count; rowIndex++)
                {
                    this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
                    this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = DBNull.Value;
                }

                this._bLGoodsCode_Grid[index].ActiveCell = null;
                this._bLGoodsCode_Grid[index].ActiveRow = null;
            }

            // タブ
            this.MainTabControl.Tabs[0].Active = true;
            this.MainTabControl.Tabs[0].Selected = true;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // コントロールサイズ設定
            this.tEdit_SectionCode.Size = new Size(28, 24);
            this.tEdit_SectionName.Size = new Size(108, 24);

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.SectionGuide_Button.ImageList = imageList16;
            this.SectionGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // グリッド構築
            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
                dataTable.Columns.Add(COLUMN_BLGOODSCODEGUIDE, typeof(string));
                dataTable.Columns.Add(COLUMN_BLGOODSCODENAME, typeof(string));

                for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[COLUMN_BLGOODSCODE] = DBNull.Value;
                    dataRow[COLUMN_BLGOODSCODEGUIDE] = DBNull.Value;
                    dataRow[COLUMN_BLGOODSCODENAME] = DBNull.Value;
                    dataTable.Rows.Add(dataRow);
                }

                this._bLGoodsCode_Grid[index].DataSource = dataTable;

                this._bLGoodsCode_Grid[index].Tag = index;

                ColumnsCollection columns = this._bLGoodsCode_Grid[index].DisplayLayout.Bands[0].Columns;

                // ヘッダーキャプション
                columns[COLUMN_BLGOODSCODE].Header.Caption = "BLｺｰﾄﾞ";
                columns[COLUMN_BLGOODSCODEGUIDE].Header.Caption = "";
                columns[COLUMN_BLGOODSCODENAME].Header.Caption = "BLｺｰﾄﾞ名";
                // TextHAlign
                columns[COLUMN_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.TextHAlign = HAlign.Center;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.TextHAlign = HAlign.Left;
                // TextVAlign
                columns[COLUMN_BLGOODSCODE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.TextVAlign = VAlign.Middle;
                // 列スタイル(ボタン設定)
                columns[COLUMN_BLGOODSCODEGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                columns[COLUMN_BLGOODSCODEGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.Cursor = Cursors.Hand;
                // 入力制御
                columns[COLUMN_BLGOODSCODE].CellActivation = Activation.AllowEdit;
                columns[COLUMN_BLGOODSCODEGUIDE].CellActivation = Activation.AllowEdit;
                columns[COLUMN_BLGOODSCODENAME].CellActivation = Activation.Disabled;
                // 列幅
                columns[COLUMN_BLGOODSCODE].Width = 70;
                columns[COLUMN_BLGOODSCODEGUIDE].Width = 25;
                columns[COLUMN_BLGOODSCODENAME].Width = 180;
                // セルColor
                columns[COLUMN_BLGOODSCODE].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                // MaxLength
                columns[COLUMN_BLGOODSCODE].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_BLGOODSCODE);
                columns[COLUMN_BLGOODSCODENAME].MaxLength = 20;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                //------------------------------
                // 新規モード
                //------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御
                PermitScreenInput(INSERT_MODE);

                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                // クローン作成
                this._bLCodeGuideListClone = new List<BLCodeGuide>();

                // フォーカス設定
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                // DataSetから拠点コードを取得
                string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

                // 拠点コードでインスタンスリストから該当データを取得
                List<BLCodeGuide> bLCodeGuideList = this._detailList.FindAll(delegate(BLCodeGuide x)
                {
                    if (x.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                this._bLCodeGuideListClone = new List<BLCodeGuide>();

                if (bLCodeGuideList.Count == 0)
                {
                    BLCodeGuide bLCodeGuide = new BLCodeGuide();
                    bLCodeGuide.SectionCode = sectionCode.Trim();
                    bLCodeGuideList.Add(bLCodeGuide);
                }
                else
                {
                    // クローン作成
                    foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                    {
                        this._bLCodeGuideListClone.Add(bLCodeGuide.Clone());
                    }
                }

                // 画面展開処理
                BLCodeGuideListToScreen(bLCodeGuideList);

                if (bLCodeGuideList[0].LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御
                    PermitScreenInput(UPDATE_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // フォーカス設定
                    this._bLGoodsCode_Grid[0].Focus();
                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御
                    PermitScreenInput(DELETE_MODE);

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">編集モード</param>
        /// <remarks>
        /// <br>Note       : 編集モードによって画面の入力許可制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:   
                    {
                        // 新規モード
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case UPDATE_MODE:   
                    {
                        // 更新モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case DELETE_MODE:   
                    {
                        // 削除モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BLコードガイドリスト画面展開処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドリスト</param>
        /// <remarks>
        /// <br>Note       : BLコードガイドリストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void BLCodeGuideListToScreen(List<BLCodeGuide> bLCodeGuideList)
        {
            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                // 拠点コード
                this.tEdit_SectionCode.DataText = bLCodeGuide.SectionCode.Trim();
                // 拠点名
                this.tEdit_SectionName.DataText = GetSectionName(bLCodeGuide.SectionCode.Trim());

                if ((bLCodeGuide.BLCodeDspPage == 0) || (bLCodeGuide.BLCodeDspCol == 0) || (bLCodeGuide.BLCodeDspRow == 0))
                {
                    continue;
                }

                int gridIndex = GetTargetGridIndex(bLCodeGuide);

                // BLコード
                this._bLGoodsCode_Grid[gridIndex].Rows[bLCodeGuide.BLCodeDspRow - 1].Cells[COLUMN_BLGOODSCODE].Value = bLCodeGuide.BLGoodsCode.ToString("00000");
                // BLコード名
                this._bLGoodsCode_Grid[gridIndex].Rows[bLCodeGuide.BLCodeDspRow - 1].Cells[COLUMN_BLGOODSCODENAME].Value = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);
            }
        }

        /// <summary>
        /// Mainリスト取得処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドリスト</param>
        /// <returns>Mainリスト</returns>
        /// <remarks>
        /// <br>Note       : Mainリストを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private Dictionary<string, BLCodeGuide> GetMainList(ArrayList bLCodeGuideList)
        {
            Dictionary<string, BLCodeGuide> mainList = new Dictionary<string, BLCodeGuide>();

            if ((bLCodeGuideList == null) || (bLCodeGuideList.Count == 0))
            {
                return mainList;
            }

            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                if (mainList.ContainsKey(bLCodeGuide.SectionCode.Trim()) == false)
                {
                    mainList.Add(bLCodeGuide.SectionCode.Trim(), bLCodeGuide);
                }
            }

            return mainList;
        }

        /// <summary>
        /// 保存データ取得処理
        /// </summary>
        /// <returns>保存データ</returns>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存データを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private Dictionary<string, BLCodeGuide> GetSaveBLCodeGuideDicFromScreen()
        {
            Dictionary<string, BLCodeGuide> bLCodeGuideDic = new Dictionary<string, BLCodeGuide>();

            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                {
                    CellsCollection cells = this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells;

                    // BLコードが空白の場合
                    if ((cells[COLUMN_BLGOODSCODE].Value == DBNull.Value) || (((string)cells[COLUMN_BLGOODSCODE].Value).Trim() == ""))
                    {
                        continue;
                    }

                    BLCodeGuide bLCodeGuide = new BLCodeGuide();

                    // 企業コード
                    bLCodeGuide.EnterpriseCode = this._enterpriseCode;
                    // 拠点コード
                    bLCodeGuide.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                    // BLコード表示頁
                    bLCodeGuide.BLCodeDspPage = GetTargetTabIndex(index) + 1;
                    // BLコード表示行
                    bLCodeGuide.BLCodeDspRow = rowIndex + 1;
                    // BLコード表示列
                    bLCodeGuide.BLCodeDspCol = GetTargetColIndex(index);
                    // BLコード
                    bLCodeGuide.BLGoodsCode = int.Parse((string)cells[COLUMN_BLGOODSCODE].Value);
                    // BLコード名
                    bLCodeGuide.BLGoodsName = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);

                    bLCodeGuideDic.Add(GetKey(bLCodeGuide), bLCodeGuide);   
                }
            }

            return bLCodeGuideDic;
        }

        /// <summary>
        /// 更新用リスト取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から、保存リスト・削除リストを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // 保存用データ取得
            Dictionary<string, BLCodeGuide> saveBLCodeGuideDic = GetSaveBLCodeGuideDicFromScreen();

            // 削除リスト作成
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                deleteList.Add(bLCodeGuide.Clone());
            }

            // 保存リスト作成
            foreach (BLCodeGuide bLCodeGuide in saveBLCodeGuideDic.Values)
            {
                saveList.Add(bLCodeGuide);
            }
        }

        /// <summary>
        /// Key取得処理
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドマスタ</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタからKeyを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetKey(BLCodeGuide bLCodeGuide)
        {
            string key = "";

            // 拠点コード(2桁)＋表示頁(2桁)＋表示列(2桁)＋表示行(2桁)
            key = bLCodeGuide.SectionCode.Trim() + bLCodeGuide.BLCodeDspPage.ToString("00") + 
                  bLCodeGuide.BLCodeDspCol.ToString("00") + bLCodeGuide.BLCodeDspRow.ToString("00");

            return key;
        }

        /// <summary>
        /// Tabインデックス取得処理
        /// </summary>
        /// <param name="gridIndex">Gridインデックス</param>
        /// <returns>Tabインデックス</returns>
        /// <remarks>
        /// <br>Note       : Gridインデックスから現在のTabインデックスを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetTabIndex(int gridIndex)
        {
            switch (gridIndex)
            {
                case 0:
                case 1:
                case 2:
                    return 0;
                case 3:
                case 4:
                case 5:
                    return 1;
                case 6:
                case 7:
                case 8:
                    return 2;
                case 9:
                case 10:
                case 11:
                    return 3;
                case 12:
                case 13:
                case 14:
                    return 4;
            }

            return 0;
        }

        /// <summary>
        /// 列インデックス取得処理
        /// </summary>
        /// <param name="gridIndex">Gridインデックス</param>
        /// <returns>列インデックス</returns>
        /// <remarks>
        /// <br>Note       : Gridインデックスから列インデックスを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetColIndex(int gridIndex)
        {
            switch (gridIndex)
            {
                case 0:
                case 3:
                case 6:
                case 9:
                case 12:
                    return 1;
                case 1:
                case 4:
                case 7:
                case 10:
                case 13:
                    return 2;
                case 2:
                case 5:
                case 8:
                case 11:
                case 14:
                    return 3;
            }

            return 1;
        }

        /// <summary>
        /// Gridインデックス取得処理
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドマスタ</param>
        /// <returns>Gridインデックス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタから対象のGridインデックスを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetGridIndex(BLCodeGuide bLCodeGuide)
        {
            switch (bLCodeGuide.BLCodeDspPage)
            {
                case 1:
                    {
                        return bLCodeGuide.BLCodeDspCol - 1;
                    }
                case 2:
                    {
                        return bLCodeGuide.BLCodeDspCol + 2;
                    }
                case 3:
                    {
                        return bLCodeGuide.BLCodeDspCol + 5;
                    }
                case 4:
                    {
                        return bLCodeGuide.BLCodeDspCol + 8;
                    }
                case 5:
                    {
                        return bLCodeGuide.BLCodeDspCol + 11;
                    }
            }

            return 0;
        }

        /// <summary>
        /// 入力情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入力情報のチェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 拠点コード
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    errMsg = "拠点コードを入力してください。";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }
                string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    foreach (BLCodeGuide blCodeGuide in this._detailList)
                    {
                        if (blCodeGuide.SectionCode.Trim() == sectionCode)
                        {
                            errMsg = "この拠点コードは既に使用されています。";
                            this.tEdit_SectionCode.Focus();
                            return (false);
                        }
                    }
                }

                // BLコード
                bool inputFlg = false;

                for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                {
                    for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                    {
                        CellsCollection cells = this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells;

                        // BLコードが空白の場合
                        if ((cells[COLUMN_BLGOODSCODE].Value == DBNull.Value) || (((string)cells[COLUMN_BLGOODSCODE].Value).Trim() == ""))
                        {
                            continue;
                        }

                        inputFlg = true;

                        // BLコード取得
                        int bLGoodsCode = int.Parse((string)cells[COLUMN_BLGOODSCODE].Value);

                        // マスタに登録されていない場合
                        if (GetBLGoodsCodeName(bLGoodsCode) == "")
                        {
                            errMsg = "マスタに登録されていません。";
                            int tabIndex = GetTargetTabIndex(index);
                            this.MainTabControl.Tabs[tabIndex].Selected = true;
                            this.MainTabControl.Tabs[tabIndex].Active = true;
                            this._bLGoodsCode_Grid[index].Focus();
                            this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                            this._bLGoodsCode_Grid[index].PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                    }
                }

                // BLコードが1件も入力されていなかった場合
                if (inputFlg == false)
                {
                    errMsg = "BLｺｰﾄﾞの登録がありません。";
                    this.MainTabControl.Tabs[0].Active = true;
                    this.MainTabControl.Tabs[0].Selected = true;
                    this._bLGoodsCode_Grid[0].Focus();
                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// BLコード名設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="bLGoodsCodeName">BLコード名</param>
        /// <remarks>
        /// <br>Note       : BLコード名をグリッドの対象セルに設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetBLGoodsCodeName(UltraGrid uGrid, out string bLGoodsCodeName)
        {
            bLGoodsCodeName = "";

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.Column.Key != COLUMN_BLGOODSCODE)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;

            if (uGrid.ActiveCell.Text.Trim() == "")
            {
                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = DBNull.Value;
                return;
            }

            // BLコード取得
            int bLGoodsCode = int.Parse(uGrid.ActiveCell.Text.Trim());

            // BLコード名取得
            bLGoodsCodeName = GetBLGoodsCodeName(bLGoodsCode);
            uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = bLGoodsCodeName;
        }

        /// <summary>
        /// NextFocus 設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="bLGoodsCodeName">BLコード名</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内でEnterキーが押下された時のNextFocus設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetNextFocus(UltraGrid uGrid, string bLGoodsCodeName, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (columnIndex == 0)
            {
                //-------------------------
                // BLコード列
                //-------------------------

                if (bLGoodsCodeName.Trim() == "")
                {
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (rowIndex == ROWCOUNT - 1)
                    {
                        int gridIndex = (int)uGrid.Tag;

                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;

                        switch (gridIndex)
                        {
                            case 2:
                            case 5:
                            case 8:
                            case 11:
                            case 14:
                                {
                                    this.Ok_Button.Focus();
                                    break;
                                }
                            default:
                                {
                                    this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                    this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                //-------------------------
                // BLコードガイドボタン列
                //-------------------------

                if (rowIndex == ROWCOUNT - 1)
                {
                    int gridIndex = (int)uGrid.Tag;

                    uGrid.ActiveCell = null;
                    uGrid.ActiveRow = null;

                    switch (gridIndex)
                    {
                        case 2:
                        case 5:
                        case 8:
                        case 11:
                        case 14:
                            {
                                this.Ok_Button.Focus();
                                break;
                            }
                        default:
                            {
                                this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                    }
                }
                else
                {
                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// BeforeFocus 設定処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="bLGoodsCodeName">BLコード名</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッド内でShift + Tabキーが押下された時のNextFocus設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetBeforeFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (columnIndex == 0)
            {
                //-------------------------
                // BLコード列
                //-------------------------

                if (rowIndex == 0)
                {
                    int gridIndex = (int)uGrid.Tag;

                    switch (gridIndex)
                    {
                        case 0:
                        case 3:
                        case 6:
                        case 9:
                        case 12:
                            {
                                this.MainTabControl.Focus();
                                break;
                            }
                        default:
                            {
                                e.NextCtrl = this._bLGoodsCode_Grid[gridIndex - 1];

                                if ((this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODENAME].Value == DBNull.Value) ||
                                    ((string)this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODENAME].Value == ""))
                                {
                                    this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                break;
                            }
                    }
                }
                else
                {
                    if ((uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODENAME].Value == DBNull.Value) ||
                        ((string)uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODENAME].Value == ""))
                    {
                        uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                //-------------------------
                // BLコードガイドボタン列
                //-------------------------

                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool SaveProc()
        {
            // 入力チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            ArrayList saveList;
            ArrayList deleteList;

            // 更新用データ取得
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // 削除処理
                status = this._bLCodeGuidAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "登録に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }
            }

            // 保存処理
            status = this._bLCodeGuidAcs.Write(ref saveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "この拠点コードは既に使用されています。",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        this.tEdit_SectionCode.Focus();

                        return (false);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        // 登録失敗
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "登録に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return (true);
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool DeleteProc()
        {
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "データを削除します。" + "\r\n" + "よろしいですか？",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);

            
            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return (false);
            }

            // 削除リスト取得
            ArrayList deleteList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                deleteList.Add(bLCodeGuide.Clone());
            }

            // 削除処理
            int status = this._bLCodeGuidAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSetから拠点コードを取得
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

            // 拠点コードでインスタンスリストから該当データを取得
            List<BLCodeGuide> bLCodeGuideList = this._detailList.FindAll(delegate(BLCodeGuide x)
            {
                if (x.SectionCode.Trim() == sectionCode.Trim())
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (bLCodeGuideList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "削除対象データが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                logicalList.Add(bLCodeGuide.Clone());
            }

            // 論理削除処理
            int status = this._bLCodeGuidAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string key;

                        foreach (BLCodeGuide bLCodeGuide in logicalList)
                        {
                            key = GetKey(bLCodeGuide);
                            int listIndex = this._detailList.FindIndex(delegate(BLCodeGuide x)
                            {
                                string key2 = GetKey(x);

                                if (key == key2)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            if (listIndex >= 0)
                            {
                                // バッファ更新
                                this._detailList[listIndex] = bLCodeGuide.Clone();
                            }

                            // DataSet展開
                            DetailToDataSet(bLCodeGuide, index);
                            index++;
                        }

                        

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他制御
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "LogicalDeleteProc",
                                       "論理削除に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            return (true);
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス(True:成功 False:失敗)</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // 復活リスト取得
            ArrayList reviveList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                reviveList.Add(bLCodeGuide.Clone());
            }

            // 復活処理
            int status = this._bLCodeGuidAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // 再検索
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "RevivalProc",
                                       "復活に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面読込時と画面終了時のデータを比較します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // 新規読込時に拠点コードが入力されていた場合
            if ((this._bLCodeGuideListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
            }

            // 保存データ取得
            Dictionary<string, BLCodeGuide> saveBLCodeGuideDic = GetSaveBLCodeGuideDicFromScreen();

            // 画面読込時と保存データの件数が違う場合
            if (this._bLCodeGuideListClone.Count != saveBLCodeGuideDic.Values.Count)
            {
                return (false);
            }

            string key;
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                // Key取得
                key = GetKey(bLCodeGuide);

                // 画面読込時のデータが無い場合
                if (!saveBLCodeGuideDic.ContainsKey(key))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より更新されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より削除されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._bLCodeGuidAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームのLoad時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            SetScreenInitialSetting();

            // 画面クリア
            ScreenClear();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変更した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click イベント(拠点ガイドボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._secInfoAcs.ResetSectionInfo();
                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 拠点コード取得
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // 拠点名取得
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // フォーカス設定
                    if (this.MainTabControl.ActiveTab == null)
                    {
                        this.MainTabControl.Tabs[0].Active = true;
                        this.MainTabControl.Tabs[0].Selected = true;
                        this._bLGoodsCode_Grid[0].Focus();
                        this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                        this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Focus();
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                    }

                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                    if (this._mainDataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                           ((Control)sender).Focus();
                        }
                    }
                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(保存ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            SaveProc();
        }

        /// <summary>
        /// Button_Click イベント(閉じるボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面情報比較
                if (!CompareOriginalScreen())
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                      "",
                                                      0,
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxDefaultButton.Button1);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 保存処理
                                if (SaveProc() != true)
                                {
                                    return;
                                }

                                this.DialogResult = DialogResult.OK;

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;

                                break;
                            }
                        default:
                            {
                                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCode.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

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
        /// Button_Click イベント(復活ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 復活処理
                bool bStatus = RevivalProc();
                if (!bStatus)
                {
                    return;
                }

                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
                // 削除日を再取得
                ResetBLCodeGuideCache();
                SetDeleteDateOfMainTable();
                // ADD 2009/03/24 不具合対応[12694]：「削除済データの表示」は最上位項目で制御 ----------<<<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(削除ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 削除ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 物理削除処理
            bool bStatus = DeleteProc();
            if (!bStatus)
            {
                return;
            }

            int totalCount = 0;

            // 再検索処理
            Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

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
        /// Timer_Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : タブがアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void MainTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    {
                        e.Handled = true;

                        if (this.MainTabControl.ActiveTab == null)
                        {
                            this.MainTabControl.Tabs[0].Active = true;
                            this.MainTabControl.Tabs[0].Selected = true;
                        }
                        else
                        {
                            int index = this.MainTabControl.ActiveTab.Index;

                            if (index == 4)
                            {
                                this.MainTabControl.Tabs[0].Active = true;
                                this.MainTabControl.Tabs[0].Selected = true;
                            }
                            else
                            {
                                this.MainTabControl.Tabs[index + 1].Active = true;
                                this.MainTabControl.Tabs[index + 1].Selected = true;
                            }
                        }

                        break;
                    }
                case Keys.PageDown:
                    {
                        e.Handled = true;

                        if (this.MainTabControl.ActiveTab == null)
                        {
                            this.MainTabControl.Tabs[4].Active = true;
                            this.MainTabControl.Tabs[4].Selected = true;
                        }
                        else
                        {
                            int index = this.MainTabControl.ActiveTab.Index;

                            if (index == 0)
                            {
                                this.MainTabControl.Tabs[4].Active = true;
                                this.MainTabControl.Tabs[4].Selected = true;
                            }
                            else
                            {
                                this.MainTabControl.Tabs[index - 1].Active = true;
                                this.MainTabControl.Tabs[index - 1].Selected = true;
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                int status = this._bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
                if (status == 0)
                {
                    UltraGrid uGrid = (UltraGrid)sender;

                    int rowIndex = e.Cell.Row.Index;

                    // BLコード取得
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = bLGoodsCdUMnt.BLGoodsCode.ToString("00000");
                    // BLコード名取得
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = bLGoodsCdUMnt.BLGoodsHalfName.Trim();

                    // フォーカス設定
                    if (rowIndex != ROWCOUNT - 1)
                    {
                        // 最終行ではない場合は、単純に一つ下の行のBLコードにフォーカス設定
                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        // 最終行の場合は、次のグリッドの先頭行のBLコードにフォーカス設定
                        // ただし、アクティブグリッドが最後のグリッドだった場合は、保存ボタンにフォーカス設定
                        int gridIndex = (int)uGrid.Tag;

                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;

                        switch (gridIndex)
                        {
                            case 2:
                            case 5:
                            case 8:
                            case 11:
                            case 14:
                                {
                                    this.Ok_Button.Focus();
                                    break;
                                }
                            default:
                                {
                                    this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                    this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            string bLGoodsCodeName;

            if (columnIndex == 0)
            {
                //-------------------------
                // BLコード列
                //-------------------------
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            // BLコード名設定
                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                            e.Handled = true;

                            if (rowIndex == 0)
                            {
                                this.MainTabControl.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            // BLコード名設定
                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                            e.Handled = true;

                            if (rowIndex == ROWCOUNT - 1)
                            {
                                this.Ok_Button.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            int gridIndex = (int)uGrid.Tag;
                            switch (gridIndex)
                            {
                                case 0:
                                case 3:
                                case 6:
                                case 9:
                                case 12:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        if (uGrid.ActiveCell.SelStart == 0)
                                        {
                                            // BLコード名設定
                                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                                            this._bLGoodsCode_Grid[gridIndex - 1].Focus();
                                            this._bLGoodsCode_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                            this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case Keys.Right:
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                // BLコード名設定
                                SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;
                            }
                            
                            break;
                        }
                }
            }
            else
            {
                //-------------------------
                // BLコードガイドボタン列
                //-------------------------
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            e.Handled = true;

                            if (rowIndex == 0)
                            {
                                this.MainTabControl.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            e.Handled = true;

                            if (rowIndex == ROWCOUNT - 1)
                            {
                                this.Ok_Button.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            e.Handled = true;

                            uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Right:
                        {
                            e.Handled = true;

                            int gridIndex = (int)uGrid.Tag;
                            switch (gridIndex)
                            {
                                case 2:
                                case 5:
                                case 8:
                                case 11:
                                case 14:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                        this._bLGoodsCode_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                                        this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                            }
                            break;
                        }
                    case Keys.Space:
                        {
                            uGrid_BLGoodsCode_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.IsInEditMode)
            {
                // UI設定を参照
                if (this.uiSetControl1.CheckMatchingSet(uGrid.ActiveCell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードに入る前に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;

            if (columnIndex != 0)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            // ゼロ詰め解除
            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPadCanceledText(uGrid.ActiveCell.Column.Key, (string)uGrid.ActiveCell.Value);
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;

            if (columnIndex != 0)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            // ゼロ詰め
            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, (string)uGrid.ActiveCell.Value);
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : アクティブコントロールが変わった時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            string bLGoodsCodeName;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":
                    {
                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            return;
                        }

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                        // 拠点名取得
                        this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // フォーカス設定
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.MainTabControl;

                                    //return;
                                }
                            }
                        }

                        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._mainDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = this.MainTabControl;
                        }
                        break;
                    }
                case "MainTabControl":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = null;

                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;

                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_SectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() == "")
                                {
                                    e.NextCtrl = this.SectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        break;
                    }
                case "Ok_Button":
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    e.NextCtrl = this._bLGoodsCode_Grid[2];
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.NextCtrl = this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2];
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.PrevCtrl == this.Ok_Button)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.MainTabControl.ActiveTab == null)
                                    {
                                        e.NextCtrl = this._bLGoodsCode_Grid[2];
                                        this.MainTabControl.Tabs[0].Active = true;
                                        this.MainTabControl.Tabs[0].Selected = true;
                                        this._bLGoodsCode_Grid[0].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                        this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2];
                                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode1":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode1, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode1, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode1, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode2":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode2, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode2, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode2, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode3":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode3, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode3, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode3, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode4":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode4, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode4, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode4, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode5":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode5, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode5, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode5, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode6":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode6, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode6, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode6, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode7":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode7, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode7, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode7, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode8":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode8, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode8, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode8, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode9":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode9, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode9, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode9, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode10":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode10, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode10, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode10, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode11":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode11, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode11, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode11, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode12":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode12, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode12, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode12, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode13":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode13, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode13, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode13, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode14":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode14, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode14, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode14, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode15":
                    {
                        // BLコード名設定
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode15, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode15, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode15, ref e);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion ■ Control Events

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();
        }

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 拠点コード
            string sectionCd = tEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_SECTIONCODE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    BLCodeGuide blCodeGuide = this._detailList.Find(delegate(BLCodeGuide x)
                    {
                        if (x.SectionCode.Trim() == sectionCd)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                    if ((blCodeGuide != null) && (blCodeGuide.LogicalDeleteCode != 0))
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのBLガイドコードマスタ情報情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、名称のクリア
                        tEdit_SectionCode.Clear();
                        tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのBLガイドコードマスタ情報が既に登録されています。\n編集を行いますか？",     // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._mainDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCode.Clear();
                                tEdit_SectionName.Clear();
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