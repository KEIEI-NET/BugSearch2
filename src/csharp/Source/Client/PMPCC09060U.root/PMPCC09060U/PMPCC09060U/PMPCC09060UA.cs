//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PCCキャンペーン設定マスタメンテ
// プログラム概要   ：PCCキャンペーン設定マスタ登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/08/10  修正内容 : 新規作成       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 李小路
// 作 成 日  2011/11/25  修正内容 : Redmain#8077 ｷｬﾝﾍﾟｰﾝ表示設定ﾏｽﾀ/異常エラー       
// ---------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/10/11  修正内容 : 2012/11/14配信分 SCM障害№10298 ベース設定を無視
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCCキャンペーン設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCCキャンペーン設定マスタを行います。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.10</br>
    /// </remarks>
    public partial class PMPCC09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Constructor

        /// <summary>
        /// PCCキャンペーン設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public PMPCC09060UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = true;
            this._canNew                    = true;
            this._canDelete                 = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //ログイン担当者の拠点 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 変数初期化
            this._pccCpMsgStAcs = new PccCpMsgStAcs(); 

            this._detailsTable = new Hashtable();
            //得意先コードグリッド
            this._customerBindTable = new DataTable(MY_SCREEN_TABLE);
            //品目設定用データテーブル
            this._itemBindTable = new DataTable(PCCITEMST_TABLE);
            this._allSearchHash = new Hashtable();
            //GridIndexバッファ（メインフレーム最小化対応）
            this._detailsIndexBuf = -2;
            this._customerInfoAcs = new CustomerInfoAcs();
            //キャンペーン設定
            this._campaignStAcs = new CampaignStAcs();
            //キャンペーン関連
            this._campaignLinkAcs = new CampaignLinkAcs();

            _bLGoodsCdAcs = new BLGoodsCdAcs();
           //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            _scmEpCnectAcs = new ScmEpCnectAcs();
            this._scmEpScCntAcs = new ScmEpScCntAcs();

            // 画面初期設定処理
            CustomerScreenInitialSetting();
            ItemScreenInitialSetting();
            //全てBLCode情報取得
            this._pccCpMsgStAcs.GetAllBLGoodsCdUMnt();
            this._bLCodeTable = this._pccCpMsgStAcs.BLCodeTable;
            // 自社設定得意先設定マスタ取得処理
            this._pccCpMsgStAcs.GetCustomerHTable();
            this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            //全て接続情報が設定Hashtable情報取得
            this._pccCpMsgStAcs.GetAllScmEpScCnt();
            this._scmEpScCntTable = this._pccCpMsgStAcs.ScmEpScCntTable;
        }

        # endregion

        #region IMasterMaintenanceMultiType メンバ

        # region ▼Properties
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
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
        # endregion ▼Properties

        # region ▼Public Methods

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(CAMPAIGNCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CAMPAIGNNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(PCCMSGDOCCNTS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CAMPAIGNOBJDIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(APPLYSTADATE_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(APPLYENDDATE_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            return appearanceTable;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }

        # endregion ▼Public Methods

        # region ▼Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers

        private PccCpMsgStAcs _pccCpMsgStAcs;     // PCCキャンペーン設定マスタ用アクセスクラス

        private string _enterpriseCode;         // 企業コード
        private string _loginSectionCode;
        private Hashtable _detailsTable;        // PCCキャンペーン設定マスタ用ハッシュテーブル
        private Hashtable _allSearchHash;       // 全レコード確保用

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
            
        //_GridIndexバッファ（メインフレーム最小化対応）
        private int _detailsIndexBuf;
        //得意先グリッド用データテーブル
        private DataTable _customerBindTable;
        //品目設定用データテーブル
        private DataTable _itemBindTable;

       
        //PCCキャンペーン対象設定ディクショナリー
        Dictionary<string, Dictionary<string, PccCpTgtSt>> _pccCpTgtStDicDic = null;
        Dictionary<string, PccCpTgtSt> _pccCpTgtStDicClone = null;
        Dictionary<string, PccCpTgtSt> _pccCpTgtStDicCloneInsert = null;
        //PCCキャンペーン品目設定データディクショナリー
        Dictionary<string, Dictionary<string, PccCpItmSt>> _pccCpItmStDicDic = null;
        Dictionary<string, PccCpItmSt> _pccCpItmStDicClone = null;
        Dictionary<string, PccCpItmSt> _pccCpItmStDicCloneInsert = null;
        // 得意先テープル
        private Dictionary<int, PccCmpnySt> _customerHTable;
        // Grid変更フラグ
        private bool _customerGridUpdFlg = true;
        private bool _ItemGridUpdFlg = true;
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先情報アクセスクラス
        // 得意先情報ダイアログ
        private int _customerCode;
        private string _customerName;
        //問合せ元企業コード
        private string _inqOriginalEpCd;
        //問合せ元拠点コード
        private string _inqOriginalSecCd;
        //BLCODEアクセスクラス
        private BLGoodsCdAcs _bLGoodsCdAcs;
        private CampaignStAcs _campaignStAcs;
        private CampaignLinkAcs _campaignLinkAcs = null;
        /// <summary>
        /// 元BLコード
        /// </summary>
        private int _beforeBLGoodsCode = 0;
        //品目BLコード情報Hashtable
        private Hashtable _bLCodeTable;
        //接続情報が設定Hashtable
        private Hashtable _scmEpScCntTable = null;
        //日付取得部品
        private DateGetAcs _dateGet;
        //SCM接続設定マスタ
        private ScmEpCnectAcs _scmEpCnectAcs;
        private ScmEpScCntAcs _scmEpScCntAcs;
        #endregion

        # region ■Consts
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private PccCpMsgSt _pccCpMsgSt;
        private PccCpMsgSt _pccCpMsgStInsert;
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE = "削除日";
        private const string CAMPAIGNCODE_TITLE = "キャンペーンコード";
        private const string CAMPAIGNNAME_TITLE = "キャンペーン名称";

        private const string PCCMSGDOCCNTS_TITLE = "PCCメッセージ";

        private const string CAMPAIGNOBJDIV_TITLE = "キャンペーン対象区分";
        private const string APPLYSTADATE_DATE = "適用開始日";
        private const string APPLYENDDATE_DATE = "適用終了日";
        
        // テーブル名称
        private const string DETAILS_TABLE = "PccCpMsgStRF";  

        // ガイドキー
        private const string DETAILS_GUID_KEY = "FileHeaderGuid";

        private const string DATEFORMAT = "YYYY/MM/DD";

        // 得意先のGrid表示用
        private const string MY_SCREEN_CUSTOMER_CODE = "得意先コード";
        private const string MY_SCREEN_CUSTOMER_NAME = "得意先名";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_INQORIGINALEPCD = "問合せ元企業コード";
        private const string MY_INQORIGINALSECCD = "問合せ元拠点コード";

        //品目設定Grid表示用
        private const string BLTIEM_ODER = "No.";
        private const string PCCITEMST_TABLE = "PCCITEMST_TABLE";
        private const string BLGOODSCODE_TITLE = "BLコード";
        /// <summary>ガイドボタン列</summary>
        private const string BLGUID_TITLE = "GUID";
        private const string BLGOODSNAME_TITLE = "BLNAME";
        private const string BLGOODSQTY_TITLE = "BLCODE";
        private const string BLGRIDNO_TITLE = "GRIDNO";

        private const string BLGOODSCODE_NAME = "BLコード";
        /// <summary>ガイドボタン列</summary>
        private const string BLGUID_NAME = "";
        private const string BLGOODSNAME_NAME = "品名";
        private const string BLGOODSQTY_NAME = "数量";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 6;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 133;     // 保存ボタン位置X
        private const int BUTTON_LOCATION3_X = 262;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "PMPCC09060U";
        //private const string PROGRAM_NAME = "PCCキャンペーン設定"; //DEL BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PROGRAM_NAME = "BLﾊﾟｰﾂｵｰﾀﾞｰｷｬﾝﾍﾟｰﾝ表示設定";  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMPCC09060UA());
        }
        # endregion

        # region Properties

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// PCCキャンペーン設定マスタメンテ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // クリア
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                this._detailsTable.Clear();
                //PCCキャンペーンメッセージ設定リスト
                List<PccCpMsgSt> retPccCpMsgStList = null;
                PccCpMsgSt parsePccCpMsgSt = new PccCpMsgSt();
                parsePccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
                //PCCキャンペーン対象設定
                PccCpTgtSt parsePccCpTgtSt = new PccCpTgtSt();
                parsePccCpTgtSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpTgtSt.InqOtherSecCd = this._loginSectionCode;
                //PCCキャンペーン品目設定
                PccCpItmSt parsePccCpItmSt = new PccCpItmSt();
                parsePccCpItmSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpItmSt.InqOtherSecCd = this._loginSectionCode;
                status = this._pccCpMsgStAcs.Search(out retPccCpMsgStList, out this._pccCpTgtStDicDic, out this._pccCpItmStDicDic, parsePccCpMsgSt, parsePccCpTgtSt,parsePccCpItmSt, 0, ConstantManagement.LogicalMode.GetData01);
                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (retPccCpMsgStList == null || retPccCpMsgStList.Count == 0)
                    {
                        return status;
                    }
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PccCpMsgSt pccCpMsgSt in retPccCpMsgStList)
                        {
                            // GUID
                            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
           
                            if (pccCpMsgSt.LogicalDeleteCode > 1)
                            {
                                continue;
                            }
                            if (this._detailsTable.ContainsKey(guid) == false)
                            {
                                DetailsToDataSet(pccCpMsgSt.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retPccCpMsgStList.Count;
                        
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
				    default:
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        PROGRAM_NAME, 			            // プログラム名称
                        "Search", 					        // 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
                        ERR_READ_MSG, 		// 表示するメッセージ
						status, 							// ステータス値
                        this._pccCpMsgStAcs, 		// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
                }
            }
            catch (Exception)
            {
                // サーチ
                TMsgDisp.Show(
                    this,								  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                    this.Text,							  // プログラム名称
                    "Search",							  // 処理名称
                    TMsgDisp.OPE_GET,					  // オペレーション
                    ERR_READ_MSG,						  // 表示するメッセージ 
                    status,								  // ステータス値
                    this._pccCpMsgStAcs,		  // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,				  // 表示するボタン
                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = LogicalDeletePccCpMsgSt();
            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// PCCキャンペーン設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="commColumn">PCCキャンペーン設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DetailsToDataSet(PccCpMsgSt pccCpMsgSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (pccCpMsgSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
               
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pccCpMsgSt.UpdateDateTimeJpInFormal;
            }

            // キャンペーンコード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNCODE_TITLE] = pccCpMsgSt.CampaignCode.ToString().PadLeft(6, '0');

            // キャンペーン名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNNAME_TITLE] = pccCpMsgSt.CampaignName;

            // PCCメッセージ
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCMSGDOCCNTS_TITLE] = pccCpMsgSt.PccMsgDocCnts;

           // 適用開始日
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][APPLYSTADATE_DATE] = TDateTime.LongDateToString(DATEFORMAT, pccCpMsgSt.ApplyStaDate);
            // 適用終了日
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][APPLYENDDATE_DATE] = TDateTime.LongDateToString(DATEFORMAT, pccCpMsgSt.ApplyEndDate);
            
            // RCメーカー別取得名称設定
            string campaignObjDivName = string.Empty;
            if (pccCpMsgSt.CampaignObjDiv == 0)
            {
                campaignObjDivName = "全得意先";
            }
            else if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                campaignObjDivName = "対象得意先";
            }

            // キャンペーン対象区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNOBJDIV_TITLE] = pccCpMsgSt.CampaignObjDiv;

            // GUID
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = guid;

            // ハッシュテーブル更新
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
            this._detailsTable.Add(guid, pccCpMsgSt);
        }

        /// <summary>
        /// PCCキャンペーン設定マスタオブジェクトデータセット削除処理
        /// </summary>
        /// <param name="commColumn">PCCキャンペーン設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン設定マスタオブジェクトデータセット削除を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DeleteFromDataSet(PccCpMsgSt pccCpMsgSt, int index)
        {
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            
            // データセットから行削除します
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // ハッシュテーブルから削除します
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable = new DataTable(DETAILS_TABLE); // PCCキャンペーン設定マスタ

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(PCCMSGDOCCNTS_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNOBJDIV_TITLE, typeof(string));
            detailsTable.Columns.Add(APPLYSTADATE_DATE, typeof(string));
            detailsTable.Columns.Add(APPLYENDDATE_DATE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(string));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;
            this.tNedit_CampaignCode.SetInt(0);                 // キャンペーンコード
            this.tEdit_CampaignName.DataText = string.Empty;                  // キャンペーン名称
            this.tEdit_PccCampaignName.DataText = string.Empty;                  // キャンペーン名称
            this.tEdit_Message.DataText = string.Empty;                  // キャンペーン名称
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // キャンペーン対象区分
            this.ApplyStaDate_TDateEdit.Clear();                    // 適用開始日
            this.ApplyEndDate_TDateEdit.Clear();                    // 適用終了日
            this._customerBindTable.Clear();
            this._itemBindTable.Clear();

            // ボタン
            this.Renewal_Button.Visible = true;  // 最新情報ボタン
            this.Delete_Button.Visible  = true;  // 完全削除ボタン
            this.Revive_Button.Visible  = true;  // 復活ボタン
            this.Ok_Button.Visible      = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                // 新規
                case INSERT_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = true;
                    this.tEdit_PccCampaignName.Enabled = true;
                    this.tEdit_Message.Enabled = true;
                    this.CampaignObjDiv_tComboEditor.Enabled = true;
                    this.ApplyStaDate_TDateEdit.Enabled = true;
                    this.ApplyEndDate_TDateEdit.Enabled = true;
                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;

                    this.DeleteBlCodeRow_Button.Enabled = true;
                    this.BlCodeGuid_Button.Enabled = true;
                    //キャンペーン設定取込みボタン
                    this.Insert_Button.Enabled = false;
                    // 新規モード
                    this.tNedit_CampaignCode.Enabled = true;
                    this.UGrid_Customer.Enabled = true;
                    this.UGrid_ItmSt.Enabled = true;
                    break;
                // 更新
                case UPDATE_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = false;
                    this.tEdit_PccCampaignName.Enabled = true;
                    this.tEdit_Message.Enabled = true;
                    this.CampaignObjDiv_tComboEditor.Enabled = true;
                    this.ApplyStaDate_TDateEdit.Enabled = true;
                    this.ApplyEndDate_TDateEdit.Enabled = true;

                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;

                    this.DeleteBlCodeRow_Button.Enabled = true;
                    this.BlCodeGuid_Button.Enabled = true;
                    //キャンペーン設定取込みボタン
                    this.Insert_Button.Enabled = true;
                    // 更新モード
                    this.tNedit_CampaignCode.Enabled = false;
                    this.UGrid_Customer.Enabled = true;
                    this.UGrid_ItmSt.Enabled = true;
                    break;
                // 削除
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = false;
                    this.tEdit_PccCampaignName.Enabled = false;
                    this.tEdit_Message.Enabled = false;
                    this.CampaignObjDiv_tComboEditor.Enabled = false;
                    this.ApplyStaDate_TDateEdit.Enabled = false;
                    this.ApplyEndDate_TDateEdit.Enabled = false;

                    this.DeleteCustomerRow_Button.Enabled = false;
                    this.CustomerGuid_Button.Enabled = false;

                    this.DeleteBlCodeRow_Button.Enabled = false;
                    this.BlCodeGuid_Button.Enabled = false;
                    this.tNedit_CampaignCode.Enabled = false;
                    this.UGrid_Customer.Enabled = false;
                    this.UGrid_ItmSt.Enabled = false;
                    //キャンペーン設定取込みボタン
                    this.Insert_Button.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // クローン作成
                this._pccCpMsgSt = pccCpMsgSt.Clone();
                this._pccCpTgtStDicClone = null;
                this._pccCpItmStDicClone = null;
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                ScreenClear();
                DispToPccCpMsgSt(ref this._pccCpMsgSt, out this._pccCpTgtStDicClone, out this._pccCpItmStDicClone);
                this._pccCpMsgStInsert = this._pccCpMsgSt;
                this._pccCpTgtStDicCloneInsert = this._pccCpTgtStDicClone;
                this._pccCpItmStDicCloneInsert = this._pccCpItmStDicClone;
                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);
               
                this.DeleteCustomerRow_Button.Enabled = false;
                this.CustomerGuid_Button.Enabled = false;
                
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[0].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                // フォーカス設定
                this.tNedit_CampaignCode.Focus();
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;

                // 表示情報取得
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = (PccCpMsgSt)this._detailsTable[guid];
                
                // 画面入力許可制御処理
                ScreenInputPermissionControl(DELETE_MODE);

                // フォーカス設定
                this.Delete_Button.Focus();

                // 画面展開処理
                PccCpMsgStToScreen(pccCpMsgSt);
            }
            // 更新の場合
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                // 表示情報取得
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = (PccCpMsgSt)this._detailsTable[guid];
                
                // 画面入力許可制御処理
                ScreenInputPermissionControl(UPDATE_MODE);

                // 画面展開処理
                PccCpMsgStToScreen(pccCpMsgSt);
                if (pccCpMsgSt.CampaignObjDiv == 1)
                {
                    this.CustomerGrid_AddRow();
                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;
                }
                else
                {
                    this.DeleteCustomerRow_Button.Enabled = false;
                    this.CustomerGuid_Button.Enabled = false;
                }
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count -1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                // クローン作成
                this._pccCpMsgSt = pccCpMsgSt.Clone();
                
                DispToPccCpMsgSt(ref this._pccCpMsgSt, out this._pccCpTgtStDicClone, out this._pccCpItmStDicClone);
                this._pccCpMsgStInsert = this._pccCpMsgSt;
                this._pccCpTgtStDicCloneInsert = this._pccCpTgtStDicClone;
                this._pccCpItmStDicCloneInsert = this._pccCpItmStDicClone;
                // フォーカス設定
                this.tEdit_PccCampaignName.Focus();
            }

            //_GridIndexバッファ保持
            this._detailsIndexBuf = this._dataIndex;
        }

        /// <summary>
        /// PCCキャンペーン設定マスタクラス画面展開処理
        /// </summary>
        /// <param name="commColumn">PCCキャンペーン設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PccCpMsgStToScreen(PccCpMsgSt pccCpMsgSt)
        {
            this.tNedit_CampaignCode.SetInt(pccCpMsgSt.CampaignCode);
            this.tEdit_PccCampaignName.Text = pccCpMsgSt.CampaignName;
            // キャンペーン名称の取得
            CampaignSt campaignSt = null;
            // キャンペーン名称の取得
            campaignSt = this._pccCpMsgStAcs.GetCampaignSt(pccCpMsgSt.CampaignCode);
            if (campaignSt != null)
            {
                this.tEdit_CampaignName.Text = campaignSt.CampaignName;
            }
            this.tEdit_Message.Text = pccCpMsgSt.PccMsgDocCnts;
            this.CampaignObjDiv_tComboEditor.Value = pccCpMsgSt.CampaignObjDiv;
            this.ApplyStaDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyStaDate);
            this.ApplyEndDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyEndDate);

            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd()
                + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                //PCCキャンペーン対象設定リスト取得
                Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
                this._customerBindTable.Clear();
            
                GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);
                if (pccCpTgtStDic != null)
                {
                    List<PccCpTgtSt> pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);

                    InitCustomerGridDate(pccCpTgtStList);
                }
            }
            //PCCキャンペーン品目設定リスト取得
            List<PccCpItmSt> pccCpItmStList = null;
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            this._itemBindTable.Clear();
            
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            if (pccCpItmStDic != null)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
                InitItemGridDate(pccCpItmStList);
            }
        }

        /// <summary>
        /// 得意先グリッド画面展開処理
        /// </summary>
        /// <param name="pccCpTgtStList"PCCキャンペーン品目設定リスト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void InitCustomerGridDate(List<PccCpTgtSt> pccCpTgtStList)
        {
           DataRow bindRow;
           PccCpTgtSt pccCpTgtSt = null;
           this._customerBindTable.Clear();
           for (int i = 0; i < pccCpTgtStList.Count; i++)
           {
                pccCpTgtSt = pccCpTgtStList[i];
                bindRow = this._customerBindTable.NewRow();
                bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
                if (pccCpTgtSt.CustomerCode == 0)
                {
                    continue;
                }
                bindRow[MY_SCREEN_CUSTOMER_CODE] = pccCpTgtSt.CustomerCode;
                bindRow[MY_SCREEN_CUSTOMER_NAME] = pccCpTgtSt.CustomerName;
                bindRow[MY_INQORIGINALEPCD] = pccCpTgtSt.InqOriginalEpCd.Trim();//@@@@20230303
                bindRow[MY_INQORIGINALSECCD] = pccCpTgtSt.InqOriginalSecCd;
                this._customerBindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// 品目グリッド画面展開処理グリッド画面展開処理
        /// </summary>
        /// <param name="pccCpItmStList">PCCキャンペーン品目設定リスト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void InitItemGridDate(List<PccCpItmSt> pccCpItmStList)
        {
            DataRow bindRow;
            PccCpItmSt pccCpItmSt = null;
            this._itemBindTable.Clear();
            for (int i = 0; i < pccCpItmStList.Count; i++)
            {
                pccCpItmSt = pccCpItmStList[i];
                bindRow = this._itemBindTable.NewRow();
                bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
                bindRow[BLGOODSCODE_TITLE] = pccCpItmSt.BLGoodsCode;
                bindRow[BLGOODSNAME_TITLE] = pccCpItmSt.GoodsNameKana;
                if (pccCpItmSt.ItemQty == 0)
                {
                    bindRow[BLGOODSQTY_TITLE] = 1;
                }
                else
                {
                    bindRow[BLGOODSQTY_TITLE] = pccCpItmSt.ItemQty;
                }
                
                bindRow[BLGRIDNO_TITLE] = 0;
                this._itemBindTable.Rows.Add(bindRow);
                if (pccCpItmSt.BLGoodsCode == 0)
                {
                    this.UGrid_ItmSt.Rows[i].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                }
                else
                {
                    this.UGrid_ItmSt.Rows[i].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                }
            }
        }

        /// <summary>
        /// Valueチェック処理（string）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private string ValueToString(object sorce)
        {
            string dest = null;
            try
            {
                dest = Convert.ToString(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// Valueチェック処理（double）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private double ValueToDouble(object sorce)
        {
            double dest = 0;
            try
            {
                dest = Convert.ToDouble(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// BLCode情報取得
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <remarks>
        /// <returns>BLCode情報</returns>
        /// <br>Note       : LCode情報を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private BLGoodsCdUMnt GetBLGoodsCdUMnt(int blCode)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = null;
            if (_bLCodeTable != null && _bLCodeTable.ContainsKey(blCode))
            {
                bLGoodsCdUMnt = _bLCodeTable[blCode] as BLGoodsCdUMnt;
            }
            return bLGoodsCdUMnt;
        }

        /// <summary>
        /// BLCode商品名称カナ情報取得
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <remarks>
        /// <returns>商品名称カナ</returns>
        /// <br>Note       : BLCode商品名称カナ情報を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private string GetBLGoodsName(int blCode)
        {
            string goodsName = string.Empty;
            BLGoodsCdUMnt bLGoodsCdUMnt = GetBLGoodsCdUMnt(blCode);
            if (bLGoodsCdUMnt != null )
            {
                goodsName = bLGoodsCdUMnt.BLGoodsHalfName;
            }
            return goodsName;
        }

        /// <summary>
        /// 画面情報PCCキャンペーン設定マスタクラス格納処理
        /// </summary>
        /// <param name="pccCpMsgSt">PCCキャンペーン設定マスタオブジェクト</param>
        /// <param name="pccCpTgtStDic">得意先グリッドデータ</param>
        /// <param name="pccCpItmStDic">BLコードグリッドデータ</param>
        /// <remarks>
        /// <br>Note       : 画面情報から部門オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DispToPccCpMsgSt(ref PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
            out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            //画面の得意先グリッドデータを格納
            pccCpTgtStDic = null;
            //画面のBLコードグリッドデータを格納
            pccCpItmStDic = null;
            DispayToPccCpMsgSt(ref pccCpMsgSt);
            if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                CustomerGridToTgtst(pccCpMsgSt, out pccCpTgtStDic);
            }
            else
            {
                GetPccCpTgtStDicFromCmpnySt(out pccCpTgtStDic);
            }
            ItemGridToTgtst(pccCpMsgSt, out pccCpItmStDic);
        }

        /// <summary>
        /// 画面情報PCCキャンペーンマスタクラス格納処理
        /// </summary>
        /// <param name="pccCpMsgSt">PCCキャンペーンマスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報PCCキャンペーンマスタクラスを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DispayToPccCpMsgSt(ref PccCpMsgSt pccCpMsgSt)
        {
            if (pccCpMsgSt == null)
            {
                pccCpMsgSt = new PccCpMsgSt();
            }
            pccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
            pccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
            pccCpMsgSt.CampaignCode = this.tNedit_CampaignCode.GetInt();
            pccCpMsgSt.CampaignName = this.tEdit_PccCampaignName.DataText.TrimEnd();
            pccCpMsgSt.PccMsgDocCnts = this.tEdit_Message.DataText.TrimEnd();
            pccCpMsgSt.CampaignObjDiv = (int)CampaignObjDiv_tComboEditor.Value;
            pccCpMsgSt.ApplyStaDate = ApplyStaDate_TDateEdit.GetLongDate();
            pccCpMsgSt.ApplyEndDate = ApplyEndDate_TDateEdit.GetLongDate();
        }

        /// <summary>
        /// 画面情報得意先グリッド格納処理
        /// </summary>
        /// <param name="pccCpMsgSt">PCCキャンペーン設定マスタオブジェクト</param>
        /// <param name="pccCpTgtStDic">得意先グリッドデータ</param>
        /// <remarks>
        /// <br>Note       : 画面情報得意先グリッドを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGridToTgtst(PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpTgtSt> pccCpTgtStDic)
        {
            pccCpTgtStDic = null;
            if (this.UGrid_Customer != null && this.UGrid_Customer.Rows.Count > 0)
            {
                pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                {
                    UltraGridRow ultraGridEach = this.UGrid_Customer.Rows[i];
                    PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                    pccCpTgtSt.InqOtherEpCd = pccCpMsgSt.InqOtherEpCd;
                    pccCpTgtSt.InqOtherSecCd = pccCpMsgSt.InqOtherSecCd;
                    if (ultraGridEach.Cells[MY_SCREEN_CUSTOMER_CODE].Value == DBNull.Value)
                    {
                        continue;
                    }
                    //問合せ元企業コード
                    pccCpTgtSt.InqOriginalEpCd = ((string)ultraGridEach.Cells[MY_INQORIGINALEPCD].Value).Trim();//@@@@20230303
                    //問合せ元拠点コード
                    pccCpTgtSt.InqOriginalSecCd = (string)ultraGridEach.Cells[MY_INQORIGINALSECCD].Value;
                    //キャンペーンコード
                    pccCpTgtSt.CampaignCode = pccCpMsgSt.CampaignCode;
                    //得意先コード
                    pccCpTgtSt.CustomerCode = (int)ultraGridEach.Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                    pccCpTgtSt.CustomerName = (string)ultraGridEach.Cells[MY_SCREEN_CUSTOMER_NAME].Value;
                    string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6,' ') + pccCpTgtSt.InqOriginalEpCd.Trim() + pccCpTgtSt.InqOriginalSecCd.TrimEnd();//@@@@20230303
                    //自社設定マスタに得意先存在しない場合、削除します。
                    if (this._customerHTable != null && this._customerHTable.Count > 0)
                    {
                        if (this._customerHTable.ContainsKey(pccCpTgtSt.CustomerCode))
                        {
                            if (!pccCpTgtStDic.ContainsKey(guid))
                            {
                                pccCpTgtStDic.Add(guid, pccCpTgtSt);
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 画面情報BLCODEグリッド格納処理
        /// </summary>
        /// <param name="pccCpMsgSt">PCCキャンペーン設定マスタオブジェクト</param>
        /// <param name="pccCpTgtStDic">BLCODEデータ</param>
        /// <remarks>
        /// <br>Note       : 画面情報BLCODEグリッドを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemGridToTgtst(PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            pccCpItmStDic = null;
            if (this.UGrid_ItmSt != null && this.UGrid_ItmSt.Rows.Count > 0)
            {
                pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                for (int i = 0; i < this.UGrid_ItmSt.Rows.Count; i++)
                {
                    UltraGridRow ultraGridRow = this.UGrid_ItmSt.Rows[i];
                    PccCpItmSt pccCpItmSt = new PccCpItmSt();
                    pccCpItmSt.InqOtherEpCd = pccCpMsgSt.InqOtherEpCd;
                    pccCpItmSt.InqOtherSecCd = pccCpMsgSt.InqOtherSecCd;
                     //キャンペーンコード
                    pccCpItmSt.CampaignCode = pccCpMsgSt.CampaignCode;
                    //キャンペーン設定区分 0:BLコード
                    pccCpItmSt.CampStDiv = 0;
                    if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        continue;
                    }
                    pccCpItmSt.BLGoodsCode = (int)ultraGridRow.Cells[BLGOODSCODE_TITLE].Value;
                    pccCpItmSt.GoodsNameKana = (string)ultraGridRow.Cells[BLGOODSNAME_TITLE].Value;
                    if (ultraGridRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ultraGridRow.Cells[BLGOODSQTY_TITLE].Value == 0)
                    {
                        pccCpItmSt.ItemQty = 1;
                    }
                    else
                    {
                        pccCpItmSt.ItemQty = (int)ultraGridRow.Cells[BLGOODSQTY_TITLE].Value;
                    }
                    BLGoodsCdUMnt bLGoodsCdUMnt = GetBLGoodsCdUMnt(pccCpItmSt.BLGoodsCode);
                    //商品番号
                    pccCpItmSt.GoodsNo = "0";
                    //商品メーカーコード
                    pccCpItmSt.GoodsMakerCd = 0;
                    //商品名称カナ
                    if (bLGoodsCdUMnt != null)
                    {
                        //pccCpItmSt.GoodsName = bLGoodsCdUMnt.BLGoodsName; //delete by lingxiaoqing on 2011.10.11 for #Redmine25789
                        pccCpItmSt.GoodsName = bLGoodsCdUMnt.BLGoodsFullName;//add by lingxiaoqing on 2011.10.11 for #Redmine25789
                        pccCpItmSt.GoodsNameKana = bLGoodsCdUMnt.BLGoodsHalfName;//add by lingxiaoqing on 2011.10.11 for #Redmine25789
                    }
                    string guid = pccCpItmSt.InqOtherEpCd.TrimEnd() + pccCpItmSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ')+ pccCpItmSt.CampStDiv.ToString().PadRight(2, ' ') +
                        pccCpItmSt.BLGoodsCode.ToString().PadRight(8, ' ') + pccCpItmSt.GoodsNo.PadRight(40, ' ')
                        + pccCpItmSt.GoodsMakerCd.ToString().PadRight(4, ' ');
                    if (!pccCpItmStDic.ContainsKey(guid))
                    {
                        pccCpItmStDic.Add(guid, pccCpItmSt);
                    }
                }
            }
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            message = string.Empty;
            // PCCキャンペーン設定マスタコード
            if (this.tNedit_CampaignCode.GetInt() == 0)
            {
                control = this.tNedit_CampaignCode;
                message = "キャンペーンコードを入力して下さい。";
                result = false;
                return result;
            }
            result = ScreenInputDateCheck(out message, ref control);
            if (!result)
            {
                return result;
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1)
            {
                if (this.UGrid_Customer == null || this.UGrid_Customer.Rows.Count == 0)
                {
                    control = this.UGrid_Customer;
                    message = "得意先コードを１件以上登録して下さい。";
                    return false;
                }
                else
                {
                    int code = 0;
                    int count = 0;
                    for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                    {
                        if (this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value)
                        {
                            code = (int)this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                        }
                        if (code != 0)
                        {
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        control = this.UGrid_Customer;
                        message = "得意先コードが登録されていません。";
                        return false;
                    }
                }
            }

            if (this.UGrid_ItmSt == null || this.UGrid_ItmSt.Rows.Count == 0)
            {
                control = this.UGrid_Customer;
                message = "BLCODEコードを１件以上登録して下さい。";
                return false;
            }
            else
            {
                int count = 0;
                int code = 0;
                for (int i = 0; i < this.UGrid_ItmSt.Rows.Count; i++)
                {
                    if (this.UGrid_ItmSt.Rows[i].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                    {
                        count = (int)this.UGrid_ItmSt.Rows[i].Cells[BLGOODSCODE_TITLE].Value;
                    }
                    if (code != 0)
                    {
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    control = this.UGrid_ItmSt;
                    message = "BLコードが登録されていません。";
                    return false;
                }
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1 && this.UGrid_Customer != null && this.UGrid_Customer.Rows.Count > 0)
            {

                //接続情報が設定チェック
                int customerCode = 0;
                string inqOriginalEpCd = string.Empty;
                string inqOriginalSecCd = string.Empty;
                string guidKey = string.Empty;
                string customerMess = string.Empty;
                for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                {
                    customerCode = 0;
                    if (this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value)
                    {
                        customerCode = (int)this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                        //問合せ元企業コード
                        inqOriginalEpCd = ((string)this.UGrid_Customer.Rows[i].Cells[MY_INQORIGINALEPCD].Value).Trim();	//@@@@20230303
                        //問合せ元拠点コード
                        inqOriginalSecCd = (string)this.UGrid_Customer.Rows[i].Cells[MY_INQORIGINALSECCD].Value;
                        guidKey = inqOriginalEpCd.Trim() + inqOriginalSecCd.TrimEnd() + this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd();//@@@@20230303
                    }
                    if (customerCode != 0)
                    {
                        if (this._scmEpScCntTable != null && this._scmEpScCntTable.Count > 0 && this._scmEpScCntTable.ContainsKey(guidKey))
                        {
                            continue;
                        }
                        else
                        {
                            customerMess = customerMess + customerCode.ToString("D8") + "\r\n";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(customerMess))
                {
                    control = this.UGrid_Customer;
                    message = "接続情報が設定されていないためこの得意先は設定できません。" + "\r\n" +customerMess;
                    return false;
                }
            }
            return result;
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ScreenInputDateCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;
            //エラー条件メッセージ
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_InputPlease = "を入力してください。";
            //生産日付範囲チェック
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (CallCheckDateRange(out cdrResult, ref ApplyStaDate_TDateEdit, ref ApplyEndDate_TDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始日{0}", ct_InputError);
                            errControl = this.ApplyStaDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("開始日{0}", ct_InputPlease);
                            errControl = this.ApplyStaDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了日{0}", ct_InputError);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("終了日{0}", ct_InputPlease);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("日付{0}", ct_RangeError);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// 日付チェック処理呼び出し（未入力対象外）
        /// </summary>
        /// <param name="cdrResult">日付チェック結果</param>
        /// <param name="tde_St_Date">日付開始</param>
        /// <param name="tde_Ed_Date">日付終了</param>
        /// <returns>日付チェック結果</returns>
        ///<remarks>
        /// <br>Note       : 日付チェック処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, false);

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
       
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : PCCキャンペーン設定マスタの保存処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            // PCCキャンペーン設定マスタ更新
            if (!SavePccCpMsgSt())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PCCキャンペーン設定マスタテーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : PccCpMsgStテーブルの更新を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool SavePccCpMsgSt()
        {
            Control control = null;
            PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();

            // 登録レコード情報取得
            string guid = string.Empty;
            if (this._detailsIndexBuf >= 0)
            {
                guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            }
            else
            {
                guid = this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd() + this.tNedit_CampaignCode.GetInt().ToString().PadRight(6, ' ');
                pccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
                pccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
            }
            List<PccCpMsgSt> pccCpMsgStListNew;
            //PCCキャンペーン対象設定データディクショナリー
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
            //PCCキャンペーン品目設定データデータディクショナリー
            Dictionary<string, PccCpItmSt> pccCpItmStDic;
            GetWriteLists(ref pccCpMsgSt, out pccCpMsgStListNew, out pccCpTgtStDic, out pccCpItmStDic);
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            status = this._pccCpMsgStAcs.Write(ref pccCpMsgStListNew, ref pccCpTgtStDic, ref pccCpItmStDic);

            // エラー処理
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash更新処理
                    DetailsToDataSet(pccCpMsgStListNew[0], this._detailsIndexBuf);
                    //PCCキャンペーン対象設定データディクショナリー更新
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    else
                    {
                        this._pccCpTgtStDicDic = new Dictionary<string, Dictionary<string, PccCpTgtSt>>();
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    //PCCキャンペーン品目設定データデータディクショナリー更新
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    else
                    {
                        this._pccCpItmStDicDic = new Dictionary<string, Dictionary<string, PccCpItmSt>>();
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCpMsgStAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();
                    return false;
                default:
                    // 登録失敗
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "SavePccCpMsgSt",			// 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_UPDT_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCpMsgStAcs,		// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return false;
            }

            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// 画面キャンペーン項目の格納処理
        /// </summary>
        /// <param name="pccCpMsgSt">キャンペーンマスタ</param>
        /// <param name="pccCpMsgStListNew">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStDic">PCCキャンペーン対象設定データデータディクショナリー</param>
        /// <param name="pccCpItmStDic">PCCキャンペーン品目設定データデータディクショナリー</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       :  画面キャンペーン項目を格納処理します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetWriteLists(ref PccCpMsgSt pccCpMsgSt, out List<PccCpMsgSt> pccCpMsgStListNew,
            out Dictionary<string, PccCpTgtSt> pccCpTgtStDic, out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            // PccCpMsgStクラスをアクセスクラスに渡して登録・更新
            //PCCキャンペーン対象設定リスト取得
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
           
            Dictionary<string, PccCpTgtSt> pccCpTgtStDicOld = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDicOld, guid);

            //PCCキャンペーン品目設定リスト取得
            Dictionary<string, PccCpItmSt> pccCpItmStDicOld = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDicOld, guid);

            //画面の得意先グリッドデータを格納
            pccCpTgtStDic = null;
            //画面のBLコードグリッドデータを格納
            pccCpItmStDic = null;
            DispToPccCpMsgSt(ref pccCpMsgSt, out pccCpTgtStDic, out pccCpItmStDic);

            pccCpMsgStListNew = new List<PccCpMsgSt>();
            // PccCpMsgStクラスにデータを格納
            pccCpMsgStListNew.Add(pccCpMsgSt);

           
           //新しいPCCキャンペーン対象設定リスト取得
            if (pccCpTgtStDicOld != null && pccCpTgtStDicOld.Count > 0)
            {
                foreach(KeyValuePair<string, PccCpTgtSt> pccCpTgtStPair in pccCpTgtStDicOld)
                {
                    PccCpTgtSt pccCpTgtStOld = pccCpTgtStPair.Value;
                    if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
                    {
                        if (pccCpTgtStDic.ContainsKey(pccCpTgtStPair.Key))
                        {
                            PccCpTgtSt pccCpTgtStNew = pccCpTgtStDic[pccCpTgtStPair.Key];
                            pccCpTgtStNew.CreateDateTime = pccCpTgtStOld.UpdateDateTime;
                            pccCpTgtStNew.UpdateDateTime = pccCpTgtStOld.UpdateDateTime;
                            pccCpTgtStNew.LogicalDeleteCode = pccCpTgtStOld.LogicalDeleteCode;
                            //更新区分= 1:更新
                            pccCpTgtStNew.UpdateFlag = pccCpTgtStOld.UpdateFlag;
                            pccCpTgtStDic.Remove(pccCpTgtStPair.Key);
                            pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                        }
                        else
                        {
                            PccCpTgtSt pccCpTgtStNew = pccCpTgtStOld;
                            //更新区分= 2:削除
                            pccCpTgtStNew.UpdateFlag = 2;
                            pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                        }
                    }
                    else
                    {
                        pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                        PccCpTgtSt pccCpTgtStNew = pccCpTgtStOld;
                        //更新区分= 2:削除
                        pccCpTgtStNew.UpdateFlag = 2;
                        pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                    }

                }
            }
            

            //新しいPCCキャンペーン品目設定リスト取得
            if (pccCpItmStDicOld != null && pccCpItmStDicOld.Count > 0)
            {
                foreach (KeyValuePair<string, PccCpItmSt> pccCpItmStPair in pccCpItmStDicOld)
                {
                    PccCpItmSt pccCpItmStOld = pccCpItmStPair.Value;
                    if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
                    {
                        if (pccCpItmStDic.ContainsKey(pccCpItmStPair.Key))
                        {
                            PccCpItmSt pccCpItmStNew = pccCpItmStDic[pccCpItmStPair.Key];
                            pccCpItmStNew.CreateDateTime = pccCpItmStOld.UpdateDateTime;
                            pccCpItmStNew.UpdateDateTime = pccCpItmStOld.UpdateDateTime;
                            pccCpItmStNew.LogicalDeleteCode = pccCpItmStOld.LogicalDeleteCode;
                            pccCpItmStNew.GoodsName = pccCpItmStOld.GoodsName;
                            pccCpItmStNew.GoodsNo = pccCpItmStOld.GoodsNo;
                            pccCpItmStNew.GoodsMakerCd = pccCpItmStOld.GoodsMakerCd;
                            pccCpItmStNew.CampStDiv = pccCpItmStOld.CampStDiv;
                            //更新区分= 1:更新
                            pccCpItmStNew.UpdateFlag = pccCpItmStOld.UpdateFlag;
                            pccCpItmStDic.Remove(pccCpItmStPair.Key);
                            pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                        }
                        else
                        {
                            PccCpItmSt pccCpItmStNew = pccCpItmStOld;
                            //更新区分= 2:削除
                            pccCpItmStNew.UpdateFlag = 2;
                            pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                        }
                    }
                    else
                    {
                        pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                        PccCpItmSt pccCpItmStNew = pccCpItmStOld;
                        //更新区分= 2:削除
                        pccCpItmStNew.UpdateFlag = 2;
                        pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                    }

                }
            }
           
            
        }

        /// <summary>
        /// PCCキャンペーン設定マスタ 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン設定マスタの対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int LogicalDeletePccCpMsgSt()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 削除対象PCCキャンペーン設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            //PCCキャンペーンメッセージ設定リスト取得
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCCキャンペーン対象設定ディクショナリー取得
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCCキャンペーン品目設定ディクショナリー取得
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            status = this._pccCpMsgStAcs.LogicalDelete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);
            pccCpMsgSt = pccCpMsgStList[0] as PccCpMsgSt;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DetailsToDataSet(pccCpMsgSt, _dataIndex);
                    //PCCキャンペーン対象設定データディクショナリー更新
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }

                    //PCCキャンペーン品目設定データデータディクショナリー更新
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pccCpMsgStAcs);
                    // フレーム更新
                    DetailsToDataSet(pccCpMsgStList[0], _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "LogicalDeletesharedPartsAddInfo",	// 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCpMsgStAcs,		// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // フレーム更新
                    DetailsToDataSet(pccCpMsgSt, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定リスト取得処理
        /// </summary>
        /// <param name="pccCpTgtStDic">PCCキャンペーン対象設定データディクショナリー</param>
        /// <param name="guid">PCCキャンペーンメッセージ設定KEY</param>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン対象設定リストを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpTgtStDicFromGuid(out  Dictionary<string, PccCpTgtSt> pccCpTgtStDic, string guid)
        {
             pccCpTgtStDic = null;
            if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.ContainsKey(guid))
            {
                pccCpTgtStDic = this._pccCpTgtStDicDic[guid];
            }
        }

        /// <summary>
        /// PCCキャンペーン品目設定リスト取得処理
        /// </summary>
        /// <param name="pccCpItmStDic">PCCキャンペーン品目設定データディクショナリー</param>
        /// <param name="guid">PCCキャンペーンメッセージ設定KEY</param>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン対象設定リストを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpItmStDicFromGuid(out   Dictionary<string, PccCpItmSt> pccCpItmStDic, string guid)
        {
            pccCpItmStDic = null;
            if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.ContainsKey(guid))
            {
                pccCpItmStDic = this._pccCpItmStDicDic[guid];
               
            }
        }

        /// <summary>
        /// PCCキャンペーン対象設定リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン対象設定リストを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpTgtStDicFromCmpnySt(out   Dictionary<string, PccCpTgtSt> pccCpTgtStDic)
        {
            pccCpTgtStDic = null;
            if (this._customerHTable == null)
            {
                this._pccCpMsgStAcs.GetCustomerHTable();
                this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            }
            else
            {
                if (this._customerHTable != null && this._customerHTable.Count > 0)
                {
                    pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                    foreach (KeyValuePair<int, PccCmpnySt> keyValuePair in this._customerHTable)
                    {
                        PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                        PccCmpnySt pccCmpnyStPair = keyValuePair.Value;

                        // --- ADD 2012/10/11 三戸 2012/11/14配信分 SCM障害№10298 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        if (pccCmpnyStPair.PccCompanyCode == 0) continue;　//PCC自社設定のベースは無視する
                        // --- ADD 2012/10/11 三戸 2012/11/14配信分 SCM障害№10298 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        string guidKey = this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd()
                            + this.tNedit_CampaignCode.GetInt().ToString().PadRight(6, ' ')
                            + pccCmpnyStPair.InqOriginalEpCd.Trim() //@@@@20230303
                            + pccCmpnyStPair.InqOriginalSecCd.TrimEnd();
                        //問合せ元企業コード
                        pccCpTgtSt.InqOriginalEpCd = pccCmpnyStPair.InqOriginalEpCd.Trim();//@@@@20230303
                        //問合せ元拠点コード
                        pccCpTgtSt.InqOriginalSecCd = pccCmpnyStPair.InqOriginalSecCd;
                        pccCpTgtSt.InqOtherEpCd = this._enterpriseCode;
                        pccCpTgtSt.InqOtherSecCd = this._loginSectionCode;
                        //キャンペーンコード
                        pccCpTgtSt.CampaignCode = this.tNedit_CampaignCode.GetInt();
                        pccCpTgtStDic.Add(guidKey, pccCpTgtSt);
                    }
                }
            }
        }
       
        /// <summary>
        /// PCCキャンペーン設定マスタ 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン設定マスタの対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int PhysicalDeleteCampaignRate()
        {
            int status = 0;
            
            // 削除対象PCCキャンペーン設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCCキャンペーン対象設定ディクショナリー取得
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCCキャンペーン品目設定ディクショナリー取得
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            // 物理削除
            status = this._pccCpMsgStAcs.Delete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DeleteFromDataSet(pccCpMsgStList[0], _dataIndex);
                    //PCCキャンペーン対象設定ディクショナリー更新
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.ContainsKey(guid))
                    {
                        this._pccCpTgtStDicDic.Remove(guid);
                    }
                    //PCCキャンペーン品目設定データディクショナリー更新
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.ContainsKey(guid))
                    {
                        this._pccCpItmStDicDic.Remove(guid);
                    }
                    //TODO
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccCpMsgStAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "PhysicalDeleteCampaignRate",	// 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCpMsgStAcs,		// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// PCCキャンペーン設定マスタ 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCCキャンペーン設定マスタの対象レコードを復活します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ReviveCampaignRate()
        {
            int status = 0;
            

            // 復活対象PCCキャンペーン設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCCキャンペーン対象設定リスト取得
            //PCCキャンペーン対象設定ディクショナリー取得
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCCキャンペーン品目設定ディクショナリー取得
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            // 復活
            status = this._pccCpMsgStAcs.RevivalLogicalDelete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet展開処理
                    DetailsToDataSet(pccCpMsgStList[0], this._dataIndex);
                    //PCCキャンペーン対象設定データディクショナリー更新
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    
                    //PCCキャンペーン品目設定データデータディクショナリー更新
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCpMsgStAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ReviveSharedPartsAddInfo",			// 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_RVV_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCpMsgStAcs,		// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // 画面クリア処理
                ScreenClear();
                // 画面再構築処理
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="control">対象コントロール</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            control = this.tNedit_CampaignCode;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_800_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_801_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
            }
        }

        /// <summary>
        /// 得意先グリッド初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// <br></br>
        /// </remarks>
        private void CustomerScreenInitialSetting()
        {
            // 得意先スキーマの設定
            CustomerDataTableSchemaSetting();

            // 得意先GRIDの初期設定
            CustomerGridInitialSetting();
        }

        /// <summary>
        /// 品目グリッド初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ItemScreenInitialSetting()
        {
            // スキーマの設定
            ItemDataTableSchemaSetting();

            // GRIDの初期設定
            ItemGridInitialSetting();
        }

        /// <summary>
        /// 得意先グリッドバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 配列項目をグリッドへバインドします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerDataTableSchemaSetting()
        {
            _customerBindTable.Columns.Clear();

            // スキーマの設定
            _customerBindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
            _customerBindTable.Columns.Add(MY_SCREEN_CUSTOMER_CODE, typeof(int));
            _customerBindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
            _customerBindTable.Columns.Add(MY_SCREEN_CUSTOMER_NAME, typeof(string));
            _customerBindTable.Columns.Add(MY_INQORIGINALEPCD, typeof(string));
            _customerBindTable.Columns.Add(MY_INQORIGINALSECCD, typeof(string));
        }

        /// <summary>
        ///	得意先のGRID初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期設定を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGridInitialSetting()
        {
            // 得意先データソースへ追加
            this.UGrid_Customer.DataSource = _customerBindTable;

            // グリッドの背景色
            this.UGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.UGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の追加不可
            this.UGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.UGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.UGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.UGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.UGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.UGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.UGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // タイトルの外観設定
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            this.UGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.UGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            this.UGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.UGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.UGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 「ID」は編集不可（固定項目として設定）
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 得意先コード列の設定
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // ガイドボタンの設定
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL品名列の設定
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = true;

            //特定列を非表示に
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_INQORIGINALEPCD].Hidden = true;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_INQORIGINALSECCD].Hidden = true;

            // セルの幅の設定
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 30;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 255;
            //Format
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Format = "D8";
            // 選択行の外観設定
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 罫線の色を変更
            this.UGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
            UltraGridBand editBand = this.UGrid_Customer.DisplayLayout.Bands[0];
            // グループヘッダのみ表示するようにする
            editBand.ColHeadersVisible = false;
            editBand.GroupHeadersVisible = true;

            //BLNo.

            //得意先名称
            UltraGridGroup ultraGridGroup = editBand.Groups.Add(MY_SCREEN_ODER, editBand.Columns[MY_SCREEN_ODER].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_ODER]);
            //得意先コードグループ
            ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[MY_SCREEN_CUSTOMER_CODE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_CUSTOMER_CODE]);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_GUID]);
            //得意先名称
            ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[MY_SCREEN_CUSTOMER_NAME].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_CUSTOMER_NAME]);
            

        }

        /// <summary>
        /// 品目グリッドバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 配列項目をグリッドへバインドします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemDataTableSchemaSetting()
        {
            _itemBindTable.Columns.Clear();

            // スキーマの設定
            _itemBindTable.Columns.Add(BLTIEM_ODER, typeof(int));
            _itemBindTable.Columns.Add(BLGOODSCODE_TITLE, typeof(int));
            _itemBindTable.Columns.Add(BLGUID_TITLE, typeof(string));
            _itemBindTable.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
            _itemBindTable.Columns.Add(BLGOODSQTY_TITLE, typeof(int));
            _itemBindTable.Columns.Add(BLGRIDNO_TITLE, typeof(int));
        }

        /// <summary>
        /// 品目グリッドの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品目グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ItemGridInitialSetting()
        {


            // グリッドの初期設定処理
            // グリッドへバインド

            this.UGrid_ItmSt.DataSource = _itemBindTable;
            // 行の追加不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.UGrid_ItmSt.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.UGrid_ItmSt.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // タイトルの外観設定
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            this.UGrid_ItmSt.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.UGrid_ItmSt.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.UGrid_ItmSt.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_ItmSt.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_ItmSt.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 「ID」は編集不可（固定項目として設定）
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.ForeColor = Color.White;

            UltraGridBand editBand = this.UGrid_ItmSt.DisplayLayout.Bands[PCCITEMST_TABLE];

            // 選択行の外観設定	
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定	
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定	
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //列の表示Style設定
            editBand.Columns[BLTIEM_ODER].Header.Caption = BLTIEM_ODER;
            editBand.Columns[BLGOODSCODE_TITLE].Header.Caption = BLGOODSCODE_NAME;
            editBand.Columns[BLGUID_TITLE].Header.Caption = BLGUID_TITLE;
            editBand.Columns[BLGOODSNAME_TITLE].Header.Caption = BLGOODSNAME_NAME;
            editBand.Columns[BLGOODSQTY_TITLE].Header.Caption = BLGOODSQTY_NAME;
            editBand.Columns[BLGRIDNO_TITLE].Header.Caption = BLGRIDNO_TITLE;
            editBand.Columns[BLTIEM_ODER].TabStop = false;
            editBand.Columns[BLGOODSCODE_TITLE].TabStop = true;
            editBand.Columns[BLGUID_TITLE].TabStop = true;
            editBand.Columns[BLGOODSNAME_TITLE].TabStop = true;
            editBand.Columns[BLGOODSQTY_TITLE].TabStop = true;
            editBand.Columns[BLGRIDNO_TITLE].TabStop = false;

            //グリッドタイプ
            editBand.Columns[BLGUID_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            //
            editBand.Columns[BLTIEM_ODER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[BLGUID_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[BLGOODSNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[BLGRIDNO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[BLGOODSNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[BLGUID_TITLE].CellActivation = Activation.NoEdit;

            //初期化値の設定
            editBand.Columns[BLTIEM_ODER].DefaultCellValue = 0;
            editBand.Columns[BLGOODSCODE_TITLE].DefaultCellValue = DBNull.Value;
            editBand.Columns[BLGOODSNAME_TITLE].DefaultCellValue = string.Empty;
            editBand.Columns[BLGOODSQTY_TITLE].DefaultCellValue = DBNull.Value;
            editBand.Columns[BLGRIDNO_TITLE].DefaultCellValue = 0;

            //編集グリッドグループ設定
            if (editBand == null)
            {
                return;
            }

            editBand.Groups.Clear();
            // グループヘッダのみ表示するようにする
            editBand.ColHeadersVisible = false;
            editBand.GroupHeadersVisible = true;

            //BLNo.
            UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLTIEM_ODER, editBand.Columns[BLTIEM_ODER].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLTIEM_ODER]);
            //BLコードグループ
            ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSCODE_TITLE]);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGUID_TITLE]);
            //BL名称
            ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[BLGOODSNAME_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSNAME_TITLE]);
            //BL名称
            ultraGridGroup = editBand.Groups.Add(BLGOODSQTY_TITLE, editBand.Columns[BLGOODSQTY_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSQTY_TITLE]);

            editBand.Columns[BLGRIDNO_TITLE].Hidden = true;

            // ボタンのスタイルを設定する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            editBand.Columns[BLGUID_TITLE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

            editBand.Columns[BLTIEM_ODER].Width = 30;
            editBand.Columns[BLGOODSCODE_TITLE].Width = 100;
            editBand.Columns[BLGUID_TITLE].Width = 20;
            editBand.Columns[BLGOODSNAME_TITLE].Width = 205;
            editBand.Columns[BLGOODSQTY_TITLE].Width = 50;
            this.UGrid_ItmSt.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

            //Format
            editBand.Columns[BLGOODSCODE_TITLE].Format = "D8";
        }

        /// <summary>
        ///	Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGrid_AddRow()
        {
            if (this._customerBindTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択した得意先コードを追加
            DataRow bindRow;

            bindRow = this._customerBindTable.NewRow();

            // 得意先情報をGridに追加
            bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_CUSTOMER_CODE] = DBNull.Value;
            bindRow[MY_SCREEN_CUSTOMER_NAME] = "";
            bindRow[MY_INQORIGINALEPCD] = "";
            bindRow[MY_INQORIGINALSECCD] = "";
            this._customerBindTable.Rows.Add(bindRow);
        }

        /// <summary>
        ///	品目設定Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemGrid_AddRow()
        {
            if (this._itemBindTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択した得意先コードを追加
            DataRow bindRow;

            bindRow = this._itemBindTable.NewRow();

            // 得意先情報をGridに追加
            bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
            bindRow[BLGOODSCODE_TITLE] = DBNull.Value;
            bindRow[BLGOODSNAME_TITLE] = string.Empty;
            bindRow[BLGOODSQTY_TITLE] = DBNull.Value;
            bindRow[BLGRIDNO_TITLE] = 0;
            this._itemBindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// 数字文字があるの判断
        /// </summary>
        /// <param name="inputStr">チェック文字</param>
        /// <returns>true:数字文字がある false:数字文字がありません</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public bool IsNumber(string inputStr)
        {
            string reg = "^[0-9]*$";
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputStr);
        }

        /// <summary>
        /// 得意先名称を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <returns>PCC自社設定データ</returns>
        /// <br>Note       :得意先名称を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private PccCmpnySt GetCustomerName(int customerCode)
        {
            PccCmpnySt pccCmpnySt = null;
            if (this._customerHTable == null || this._customerHTable.Count == 0)
            {
                this._pccCpMsgStAcs.GetCustomerHTable();
                this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            }
            if (this._customerHTable != null && this._customerHTable.Count > 0)
            {
               if(this._customerHTable.ContainsKey(customerCode))
               {
                   pccCmpnySt = this._customerHTable[customerCode];
               }
            }

            return pccCmpnySt;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            _customerCode = 0;
            _customerName = "";
            _inqOriginalEpCd = "";
            _inqOriginalSecCd = "";
            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード
            _customerCode = customerSearchRet.CustomerCode;

            // 得意先名称
            _customerName = customerSearchRet.Snm.Trim();
            //問合せ元企業コード
            this._inqOriginalEpCd = customerSearchRet.CustomerEpCode.Trim();//@@@@20230303
            //問合せ元拠点コード
            this._inqOriginalSecCd = customerSearchRet.CustomerSecCode;
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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
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
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart) + key
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
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 正数字判断
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="charCount">文字列位数</param>
        /// <returns>True:数字; False:非数字</returns>
        /// <remarks>
        /// <br>Note       : 正数字判断処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool IsDigitAdd(String str, int charCount)
        {

            string regex1 = "^[0-9]{0," + charCount + "}$";
            Regex objRegex = new Regex(regex1);
            return objRegex.IsMatch(str);
        }

        /// <summary>
        /// キャンペーン設定取込みボタンクリックイベント処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン設定取込みボタンクリックで処理します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Insert_ButtonProc()
        {
            int campaignCode = this.tNedit_CampaignCode.GetInt();
            //画面関連の情報のクリア
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // キャンペーン対象区分
            this.ApplyStaDate_TDateEdit.Clear();                    // 適用開始日
            this.ApplyEndDate_TDateEdit.Clear();                    // 適用終了日
            this._customerBindTable.Clear();
            this._itemBindTable.Clear();
            //キャンペーン情報の取得
            PccCpMsgSt pccCpMsgSt = null;
            List<PccCpTgtSt> pccCpTgtStList = null;
            List<PccCpItmSt> pccCpItmStList = null;
            this._pccCpMsgStAcs.GetCampaignInfo(campaignCode, out pccCpMsgSt, out pccCpTgtStList, out pccCpItmStList);

            if (pccCpMsgSt != null)
            {
                CampaignObjDiv_tComboEditor.Value = pccCpMsgSt.CampaignObjDiv;
                ApplyStaDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyStaDate);
                ApplyEndDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyEndDate);

                //得意先グリッドの設定
                if (pccCpMsgSt.CampaignObjDiv == 1)
                {

                    if (pccCpTgtStList != null && pccCpTgtStList.Count > 0)
                    {
                        InitCustomerGridDate(pccCpTgtStList);
                    }
                    else
                    {
                        this._customerBindTable.Clear();
                    }
                }
                //BLコードグリッドの設定
                if (pccCpItmStList != null && pccCpItmStList.Count > 0)
                {
                    InitItemGridDate(pccCpItmStList);

                }
                else
                {
                    this._itemBindTable.Clear();
                }
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1)
            {
                this.CustomerGrid_AddRow();
            }
            this.ItemGrid_AddRow();
            this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count - 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;
            this.SetIconImage(this.uButton_CampaignGuide, Size16_Index.STAR1);
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
        }

        /// <summary>
        /// Form.Closing イベント(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;

            // フォームの「×」をクリックされた場合の対応です。
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();

                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._detailsIndexBuf == this._dataIndex)
            {
                return;
            }


            //this.Owner.Activate();

            //// 自分自身が非表示になった場合は以下の処理をキャンセルする。
            //if ( this.Visible == false ) {
            //    return;
            //}

            // 画面クリア処理
            ScreenClear();

            // 画面再構築処理
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録処理
            SaveProc();
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                // 現在の画面情報を取得
                PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();
                pccCpMsgSt = this._pccCpMsgSt.Clone();

                //PCCキャンペーン対象設定データディクショナリー
                Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
                //PCCキャンペーン品目設定データデータディクショナリー
                Dictionary<string, PccCpItmSt> pccCpItmStDic;
                DispToPccCpMsgSt(ref pccCpMsgSt, out pccCpTgtStDic, out pccCpItmStDic);
                // 最初に取得した画面情報と比較
                cloneFlg = this.ListCompare(pccCpMsgSt, pccCpTgtStDic, pccCpItmStDic, this._pccCpMsgSt, this._pccCpTgtStDicClone, this._pccCpItmStDicClone);

                if ( !( cloneFlg ) ) {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch ( res ) {
                        case DialogResult.Yes:
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            if (_modeFlg)
                            {
                                this.tNedit_CampaignCode.Focus();
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

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

         /// <summary>
        /// 画面PCC品目グループクラス比較
        /// </summary>
        /// <param name="pccCpMsgSt">キャンペーンマスタNew</param>
        /// <param name="pccCpTgtStDic">PCCキャンペーン対象設定データデータディクショナリー</param>
        /// <param name="pccCpItmStDic">PCCキャンペーン品目設定データデータディクショナリー</param>
        /// <param name="pccCpMsgStOld">キャンペーンマスタOld</param>
        /// <param name="pccCpTgtStDicOld">PCCキャンペーン対象設定データデータディクショナリーOld</param>
        /// <param name="pccCpItmStDicOld">PCCキャンペーン品目設定データデータディクショナリーOld</param>
        /// <remarks>
        /// <br>Note       : 画面PCC品目グループクラスを比較します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(PccCpMsgSt pccCpMsgSt, Dictionary<string, PccCpTgtSt> pccCpTgtStDic, Dictionary<string, PccCpItmSt> pccCpItmStDic, PccCpMsgSt pccCpMsgStOld, Dictionary<string, PccCpTgtSt> pccCpTgtStDicOld, Dictionary<string, PccCpItmSt> pccCpItmStDicOld)
        {
            bool isEqualsValue = true;
            if (this.Mode_Label.Text.Equals(INSERT_MODE) || this.Mode_Label.Text.Equals(UPDATE_MODE))
            {
                if (!pccCpMsgSt.Equals(pccCpMsgStOld))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpTgtStDic == null && pccCpTgtStDicOld != null && pccCpTgtStDicOld.Count > 0)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }

                if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0 && pccCpTgtStDicOld == null)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpTgtStDic != null && pccCpTgtStDicOld != null)
                {
                    if (pccCpTgtStDic.Count != pccCpTgtStDicOld.Count)
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                    foreach (KeyValuePair<string, PccCpTgtSt> pccCpTgtStPair in pccCpTgtStDic)
                    {
                        if (pccCpTgtStDicOld.ContainsKey(pccCpTgtStPair.Key))
                        {
                            if (!pccCpTgtStPair.Value.Equals(pccCpTgtStDicOld[pccCpTgtStPair.Key]))
                            {
                                isEqualsValue = false;
                                return isEqualsValue;
                            }
                        }
                        else
                        {
                            isEqualsValue = false;
                            return isEqualsValue;
                        }
                    }
                }
                if (pccCpItmStDic == null && pccCpItmStDicOld != null && pccCpItmStDicOld.Count > 0)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }

                if (pccCpItmStDic != null && pccCpItmStDic.Count > 0 && pccCpItmStDicOld == null)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpItmStDic != null && pccCpItmStDicOld != null)
                {
                    if (pccCpItmStDic.Count != pccCpItmStDicOld.Count)
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }


                    foreach (KeyValuePair<string, PccCpItmSt> pccCpItmStPair in pccCpItmStDic)
                    {
                        if (pccCpItmStDicOld.ContainsKey(pccCpItmStPair.Key))
                        {
                            if (!pccCpItmStPair.Value.Equals(pccCpItmStDicOld[pccCpItmStPair.Key]))
                            {
                                isEqualsValue = false;
                                return isEqualsValue;
                            }
                        }
                        else
                        {
                            isEqualsValue = false;
                            return isEqualsValue;
                        }
                    }
                }
            }
            return isEqualsValue;
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                //MessageBoxButtons.OKCancel,
                //MessageBoxDefaultButton.Button2);	// 表示するボタン
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if ( result == DialogResult.Yes ) {
                // PCCキャンペーン設定マスタ物理削除
                PhysicalDeleteCampaignRate();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveCampaignRate();
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Insert_Button_Click.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : キャンペーン設定取込みボタンクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Insert_Button_Click(object sender, EventArgs e)
        {
            PccCpMsgSt pccCpMsgStNew = this._pccCpMsgSt.Clone();
            //PCCキャンペーン対象設定データディクショナリー
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
            //PCCキャンペーン品目設定データデータディクショナリー
            Dictionary<string, PccCpItmSt> pccCpItmStDic;
           DispToPccCpMsgSt(ref pccCpMsgStNew, out pccCpTgtStDic, out pccCpItmStDic);
            // 最初に取得した画面情報と比較
           bool cloneFlg = this.ListCompare(pccCpMsgStNew, pccCpTgtStDic, pccCpItmStDic, this._pccCpMsgStInsert,  this._pccCpTgtStDicCloneInsert, this._pccCpItmStDicCloneInsert);

            if (!cloneFlg)
            {
                DialogResult res = TMsgDisp.Show(
                       this,                                   // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                       ASSEMBLY_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                    //"入力されたコードのキャンペーン関連マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ  // DEL 2011/05/06
                       "現在、編集中のデータが存在します廃棄してもよろしいですか？",   // 表示するメッセージ            // ADD 2011/05/06
                       0,                                      // ステータス値
                       MessageBoxButtons.YesNo);               // 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            Insert_ButtonProc();
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                }
            }
            else
            {
                Insert_ButtonProc();
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            _modeFlg = false;
            int campaignCode = this.tNedit_CampaignCode.GetInt();
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":
                    // PCCキャンペーン設定マスタメンテコードコードにフォーカスがある場合
                   if (campaignCode != 0)
                    {
                        if(ModeChangeProc())
                        {
                            if (this.tNedit_CampaignCode.GetInt() == 0)
                            {
                                e.NextCtrl = tNedit_CampaignCode;
                            }
                            return;
                        }
                        // キャンペーン名称の取得
                        CampaignSt campaignSt = null;
                        // キャンペーン名称の取得

                        //campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignCode);               //DEL 2011/11/25 redmain#8077 
                        try{campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignCode);}catch { } //ADD 2011/11/25 redmain#8077 
                        if (campaignSt != null)
                        {
                            if ("00".Equals(campaignSt.SectionCode.TrimEnd()) || string.IsNullOrEmpty(campaignSt.SectionCode.TrimEnd()) || this._loginSectionCode.Equals(campaignSt.SectionCode))
                            {
                                this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                                //キャンペーン設定取込みボタン
                                this.Insert_Button.Enabled = true;
                                DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                                //e.NextCtrl = null;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "拠点は対象外のため、このキャンペーンは選択できません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // 得意先のクリア
                                this.tNedit_CampaignCode.Clear();
                                this.tEdit_CampaignName.Text = "";
                                this.Insert_Button.Enabled = false;
                                DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                                
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "キャンペーン名称マスタに未登録です。",
                            -1,
                            MessageBoxButtons.OK);

                            // 得意先のクリア
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                            this.Insert_Button.Enabled = false;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                            
                            // カーソル制御
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    else
                    {
                        // 未入力
                        // キャンペーンのクリア
                        this.tNedit_CampaignCode.Clear();
                        this.tEdit_CampaignName.Text = "";
                        DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                        
                        this.Insert_Button.Enabled = false;
                    }

                    break;
                //適用終了日
                case "ApplyEndDate_TDateEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        if ((int)CampaignObjDiv_tComboEditor.Value == 0)
                                        {
                                            e.NextCtrl = DeleteBlCodeRow_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = CustomerGuid_Button;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteBlCodeRow_Button":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if ((int)CampaignObjDiv_tComboEditor.Value == 0)
                                        {
                                            e.NextCtrl = ApplyEndDate_TDateEdit;
                                        }
                                        break;
                                    }
                            }
                        }
                        else if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.UGrid_ItmSt.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteCustomerRow_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.UGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "CustomerGuid_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.UGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "BlCodeGuid_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.UGrid_ItmSt.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "UGrid_ItmSt":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.UGrid_ItmSt.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;
                                            string columnKey = this.UGrid_ItmSt.ActiveCell.Column.Key;
                                            int numLen = 0;
                                            if (BLGOODSCODE_TITLE.Equals(columnKey))
                                            {
                                                numLen = 8;
                                            }
                                            else if (BLGOODSQTY_TITLE.Equals(columnKey))
                                            {
                                                numLen = 3;
                                            }
                                            if (this.UGrid_ItmSt.ActiveCell.Column.DataType == typeof(Int32) && this.UGrid_ItmSt.ActiveCell.Activation == Activation.AllowEdit)
                                            {
                                                Infragistics.Win.EmbeddableEditorBase editorBase = this.UGrid_ItmSt.ActiveCell.EditorResolved;
                                                string currentEditText = editorBase.CurrentEditText;
                                                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                                                if (!checkNumber)
                                                {
                                                    if (BLGOODSCODE_TITLE.Equals(columnKey))
                                                    {
                                                        this.UGrid_ItmSt.ActiveCell.Value = DBNull.Value;
                                                    }
                                                    else if (BLGOODSQTY_TITLE.Equals(columnKey))
                                                    {
                                                        this.UGrid_ItmSt.ActiveCell.Value = 0;
                                                    }
                                                }

                                            }
                                            if ((this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                               
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if ((int)this.UGrid_ItmSt.ActiveCell.Row.Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                                                {
                                                    //最終行が入力の場合、新規行を追加
                                                    if (this.UGrid_ItmSt.ActiveCell.Row.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && (int)this.UGrid_ItmSt.ActiveCell.Row.Cells[BLGOODSCODE_TITLE].Value != 0)
                                                    {
                                                        // 最終行の場合、行を追加
                                                        this.ItemGrid_AddRow();
                                                        this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count - 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                                                    }
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
                                        bool moveFlg = this.ItmStMoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._ItemGridUpdFlg)
                                        {
                                            this.ItmStMovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.ItmStMovePrevAllowEditCell(false))
                                        {
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }
                                       
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "UGrid_Customer":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.UGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

                                            string columnKey = this.UGrid_Customer.ActiveCell.Column.Key;
                                            int numLen = 0;
                                            if (MY_SCREEN_CUSTOMER_CODE.Equals(columnKey))
                                            {
                                                numLen = 8;
                                            }

                                            if (this.UGrid_Customer.ActiveCell.Column.DataType == typeof(Int32) && columnKey.Equals(MY_SCREEN_CUSTOMER_CODE))
                                            {
                                                Infragistics.Win.EmbeddableEditorBase editorBase = this.UGrid_Customer.ActiveCell.EditorResolved;
                                                string currentEditText = editorBase.CurrentEditText;
                                                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                                                if (!checkNumber)
                                                {
                                                    this.UGrid_Customer.ActiveCell.Value = DBNull.Value;
                                                }

                                            }
                                            if ((this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if ((int)this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                                                {
                                                    //最終行が入力の場合、新規行を追加
                                                    if (this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value && (int)this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value != 0)
                                                    {
                                                        // 最終行の場合、行を追加
                                                        this.CustomerGrid_AddRow();
                                                    }
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
                                        bool moveFlg = this.CustomerMoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._customerGridUpdFlg)
                                        {
                                            this.CustomerMovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.CustomerMovePrevAllowEditCell(false))
                                        {
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }
                                       
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                //case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        int rowIdx = this.UGrid_ItmSt.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.UGrid_ItmSt.ActiveRow = this.UGrid_ItmSt.Rows[rowIdx];
                                        // アクティブセルを得意先コードに設定(フォーカス遷移のため)
                                        this.UGrid_ItmSt.ActiveCell = this.UGrid_ItmSt.Rows[rowIdx].Cells[BLGOODSCODE_TITLE];
                                        // 得意先コードを編集モードにしてフォーカスを移動
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._itemBindTable.Rows[rowIdx][BLGOODSCODE_TITLE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
                                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        int rowIdx = this.UGrid_ItmSt.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.UGrid_ItmSt.ActiveRow = this.UGrid_ItmSt.Rows[rowIdx];
                                        // アクティブセルを得意先コードに設定(フォーカス遷移のため)
                                        this.UGrid_ItmSt.ActiveCell = this.UGrid_ItmSt.Rows[rowIdx].Cells[BLGOODSCODE_TITLE];
                                        // 得意先コードを編集モードにしてフォーカスを移動
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._itemBindTable.Rows[rowIdx][BLGOODSCODE_TITLE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
                                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary> 
        /// <remarks>
        /// <br>Note       :  モード変更処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            // キャンペーンコード
            int campaignCode = tNedit_CampaignCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCampaignCode = 0;
                string dsCampaignCodeStr = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][CAMPAIGNCODE_TITLE];
                Int32.TryParse(dsCampaignCodeStr, out dsCampaignCode);
                if (campaignCode == dsCampaignCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						        // アセンブリＩＤまたはクラスＩＤ
                            //"入力されたコードのキャンペーン関連マスタ情報は既に削除されています。", // 表示するメッセージ   // DEL 2011/05/06
                          "入力されたコードのキャンペーン設定マスタ情報は既に削除されています。", 			// 表示するメッセージ   // ADD 2011/05/06
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // キャンペーンコード、名称のクリア
                        tNedit_CampaignCode.Clear();
                        tEdit_CampaignName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                        //"入力されたコードのキャンペーン関連マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ  // DEL 2011/05/06
                        "入力されたコードのキャンペーンマスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ            // ADD 2011/05/06
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 一時的に詳細テーブルを更新
                                this._dataIndex = i;
                                // 画面再描画
                                ScreenClear();
                                ScreenReconstruction();

                                // 詳細テーブルを元に戻す
                                break;
                            }   
                        case DialogResult.No:
                            {
                                // キャンペーンコード、名称のクリア
                                tNedit_CampaignCode.Clear();
                                tEdit_CampaignName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Control.VisibleChange イベント(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // アクティブセル・アクティブ行を無効
            this.UGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void UGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return;
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = CustomerMoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = CustomerMoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            // 上のセルへ移動
                            nextControl = CustomerMoveLeftCell();
                            e.Handled = true;

                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            // 下のセルへ移動
                            nextControl = CustomerMoveRightCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.UGrid_Customer.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                UGrid_Customer_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return;
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = ItmStMoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = ItmStMoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            //// 上のセルへ移動
                            nextControl = ItmStMoveLeftCell();
                            e.Handled = true;

                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            //// 下のセルへ移動
                            nextControl = ItmStMoveRightCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.UGrid_ItmSt.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                UGrid_ItmSt_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.UGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_Customer.ActiveCell;

            // 得意先コードの入力桁数チェック
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.UGrid_ItmSt.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_ItmSt.ActiveCell;

            // BLコードの入力桁数チェック
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // BLQTY
            if (cell.Column.Key == BLGOODSQTY_TITLE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのセル編集終了イベント処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.UGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_Customer.ActiveCell;

            // 得意先コード
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                int code = 0;
                if (cell.Value == DBNull.Value || cell.Value == null)
                {
                    code = 0;
                }
                else
                {
                    code = (int)cell.Value;
                }
                this._customerGridUpdFlg = true;

                if (code !=0)
                {
                   
                    // 入力有
                    int customerCode = code;
                    PccCmpnySt pccCmpnyStGuid = null;
                    string customerName = string.Empty;
                    if(_customerHTable != null && _customerHTable.ContainsKey(customerCode))
                    {
                        pccCmpnyStGuid = _customerHTable[customerCode];
                        customerName = pccCmpnyStGuid.PccCompanyName;
                        this._inqOriginalEpCd = pccCmpnyStGuid.InqOriginalEpCd.Trim();//@@@@20230303
                        this._inqOriginalSecCd = pccCmpnyStGuid.InqOriginalSecCd;
                        bool AddFlg = true;     // 追加フラグ
                        int maxRow = this._customerBindTable.Rows.Count;

                        // 得意先コードの重複チェック
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // 同じ行数はSKIP
                                continue;
                            }
                            if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] != DBNull.Value)
                            {
                                int wkTbsPartsCode = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                                if ((wkTbsPartsCode != 0) && (wkTbsPartsCode == customerCode))
                                {
                                    // 重複コード有
                                    AddFlg = false;
                                    break;
                                }
                            }
                        }

                        if (AddFlg)
                        {
                            // 得意先コードの追加
                            // 選択した情報をCellに設定
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode;   // 得意先コード
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // 得意先品名
                            cell.Row.Cells[MY_INQORIGINALEPCD].Value = _inqOriginalEpCd.Trim();                   // 問合せ元企業コード//@@@@20230303
                            cell.Row.Cells[MY_INQORIGINALSECCD].Value = _inqOriginalSecCd;                   // 問合せ元拠点コード
                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                            {
                                // 最終行の場合、行を追加
                                this.CustomerGrid_AddRow();
                            }
                        }
                        else
                        {
                            // 重複エラーを表示
                            TMsgDisp.Show(
                                this,								    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                ASSEMBLY_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                                "選択した得意先コードが重複しています。",	    // 表示するメッセージ 
                                0,									    // ステータス値
                                MessageBoxButtons.OK);				    // 表示するボタン

                            // 得意先コード、得意先名をクリア
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;     // 得意先コード
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名
                            cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // 問合せ元企業コード
                            cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // 問合せ元拠点コード
                            // Grid変更なし
                            this._customerGridUpdFlg = false;
                            this._inqOriginalEpCd = string.Empty;
                            this._inqOriginalSecCd = string.Empty;
                        }
                    }
                    else
                    {
                        // 論理削除データは設定不可
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"PCC自社設定マスタに未登録の為、この得意先は設定できません。\r\n[" + customerCode.ToString("d08") + "]", //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                            "BLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタに未登録の為、この得意先は設定できません。\r\n[" + customerCode.ToString("d08") + "]", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                            -1,
                            MessageBoxButtons.OK);

                        // 得意先コード、得意先名をクリア
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;      // 得意先コード
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名
                        cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // 問合せ元企業コード
                        cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // 問合せ元拠点コード
                        // Grid変更なし
                        this._customerGridUpdFlg = false;
                        this._inqOriginalEpCd = string.Empty;
                        this._inqOriginalSecCd = string.Empty;
                    }
                }
                else
                {
                    // 未入力
                    // 得意先コード、得意先名をクリア
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;     // 得意先コード
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名
                    cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // 問合せ元企業コード
                    cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // 問合せ元拠点コード
                    this._inqOriginalEpCd = string.Empty;
                    this._inqOriginalSecCd = string.Empty;
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのセル編集終了イベント処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_AfterExitEditMode(object sender, EventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = ultraGrid.ActiveCell;

            int rowIndex = cell.Row.Index;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                int blCode = 0;
                if (cell.Value != DBNull.Value && cell.Value != null)
                {
                    blCode = (int)cell.Value;
                }
                this._ItemGridUpdFlg = true;
                if (blCode != 0)
                {

                    bool AddFlg = true;
                    if (this._bLCodeTable != null && this._bLCodeTable.ContainsKey(blCode))
                    {
                        // 得意先コードの重複チェック
                        for (int i = 0; i < this._itemBindTable.Rows.Count; i++)
                        {
                            if (rowIndex == i)
                            {
                                // 同じ行数はSKIP
                                continue;
                            }
                            if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == DBNull.Value || (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == 0)
                            {
                                continue;
                            }
                            int bLGoodsCode = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];

                            if (bLGoodsCode == blCode)
                            {
                                // 重複コード有
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // 選択した情報をCellに設定
                            bLGoodsCdUMnt = this._bLCodeTable[blCode] as BLGoodsCdUMnt;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                            if (ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == 0)
                            {
                                ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                            }
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                            if ((int)ultraGrid.Rows[rowIndex].Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                            {
                                // 最終行の場合、行を追加
                                this.ItemGrid_AddRow();
                                ultraGrid.Rows[rowIndex + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;

                            }

                           
                        }
                        else
                        {
                            // 重複エラーを表示
                            TMsgDisp.Show(
                                this,								    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                ASSEMBLY_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                                "選択したBLコードが重複しています。",	// 表示するメッセージ 
                                0,									    // ステータス値
                                MessageBoxButtons.OK);				    // 表示するボタン
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value = DBNull.Value;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                            this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                            this._beforeBLGoodsCode = 0;
                            this._ItemGridUpdFlg = false;
                        }


                    }
                    else
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BLコード [" + blCode.ToString() + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        // BLコードを元に戻す
                        //cell.Value = this._beforeBLGoodsCode;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value = DBNull.Value;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                        this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        this._beforeBLGoodsCode = 0;
                        this._ItemGridUpdFlg = false;
                    }


                }
                else
                {
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                    this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    this._beforeBLGoodsCode = 0;
                }
            }
           
        }
       
        /// <summary>
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            // 最下段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // 保存ボタンへ移動
                return this.Renewal_Button;
                
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.UGrid_Customer.ActiveCell.Column.Index;
                int prevRow = this.UGrid_Customer.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // セルが移動していない時
                if ((prevCol == this.UGrid_Customer.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_Customer.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                    return this.Renewal_Button;
                   
                }
                // セルが移動してる
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            // 最上段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // 移動しない
                // キャンペーンコードへ移動
                return this.DeleteCustomerRow_Button;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// 左のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveLeftCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // 最左段セルの時
            if (this.UGrid_Customer.ActiveCell.Column.Key.Equals(MY_SCREEN_CUSTOMER_CODE))
            {  // 移動しない
                return null;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                if (performActionResult)
                {
                    if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
               
                return null;

            }
        }

        /// <summary>
        /// 右のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveRightCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            // アクティブセルがnull
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }
            try
            {
                // 更新開始（描画ストップ）
                this.UGrid_Customer.BeginUpdate();

                // 最右段セルの時
                if (this.UGrid_Customer.ActiveCell.Column.Key.Equals(MY_SCREEN_CUSTOMER_NAME))
                {
                    // 保存ボタンへ移動
                    return null;

                }
                // 最下段セルでない時
                else
                {
                    // セル移動前アクティブセルのインデックス
                    int prevCol = this.UGrid_Customer.ActiveCell.Column.Index;
                    int prevRow = this.UGrid_Customer.ActiveCell.Row.Index;

                    // 下のセルに移動UltraGridAction
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }

                    return null;

                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.UGrid_Customer.EndUpdate();
            }
        }

        /// <summary>
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            // アクティブセルがnull
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            // 最下段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // 保存ボタンへ移動
                return this.Renewal_Button;
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.UGrid_ItmSt.ActiveCell.Column.Index;
                int prevRow = this.UGrid_ItmSt.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // セルが移動していない時
                if ((prevCol == this.UGrid_ItmSt.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_ItmSt.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                   return this.Renewal_Button;
                    
                }
                // セルが移動してる
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            // 最上段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // 移動しない
                // キャンペーンコードへ移動
                return this.DeleteBlCodeRow_Button;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// 左のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveLeftCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            // アクティブセルがnull
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // 最左段セルの時
            if (this.UGrid_ItmSt.ActiveCell.Column.Key.Equals(BLGOODSCODE_TITLE))
            {
                return null;
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.UGrid_ItmSt.ActiveCell.Column.Index;
                int prevRow = this.UGrid_ItmSt.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                // セルが移動していない時
                if ((prevCol == this.UGrid_ItmSt.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_ItmSt.ActiveCell.Row.Index))
                {
                    return null;

                }
                // セルが移動してる
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveRightCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // 最右段セルの時
            if (this.UGrid_ItmSt.ActiveCell.Column.Key.Equals(BLGOODSQTY_TITLE))
            {
                // 移動しない
                return null;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                if (performActionResult)
                {
                    if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CustomerMoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_Customer.ActiveCell != null))
            {
                if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ItmStMoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_ItmSt.ActiveCell != null))
            {
                if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CustomerMovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_Customer.ActiveCell != null))
            {
                if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.UGrid_Customer.ActiveCell.Row.Index;
                            if (this._customerBindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value)
                            {
                                // 得意先コードが未入力の場合
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ItmStMovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_ItmSt.ActiveCell != null))
            {
                if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.UGrid_ItmSt.ActiveCell.Row.Index;
                            if (this._itemBindTable.Rows[rowIdx][BLTIEM_ODER] == DBNull.Value)
                            {
                                // 得意先コードが未入力の場合
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click イベント(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのCell Buttonをクリックイベント処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._customerBindTable.Rows.Count;
                int doubleIndex = -1;
                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                   if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value || (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] == 0)
                    {
                        continue;
                    }
                    int customerCode = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    
                    if (customerCode == _customerCode)
                    {
                        // 重複コード有
                        AddFlg = false;
                        doubleIndex = i;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode;    // 得意先コード
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // 得意先名
                    e.Cell.Row.Cells[MY_INQORIGINALEPCD].Value = _inqOriginalEpCd.Trim();                    // 問合せ元企業コード//@@@@20230303
                    e.Cell.Row.Cells[MY_INQORIGINALSECCD].Value = _inqOriginalSecCd;                    // 問合せ元拠点コード

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.CustomerGrid_AddRow();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.CustomerMoveNextAllowEditCell(false);
                }
                else
                {
                    if (doubleIndex != e.Cell.Row.Index)
                    {
                        // 重複エラーを表示
                        TMsgDisp.Show(
                            this,								    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                            ASSEMBLY_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                            "選択した得意先コードが重複しています。",	// 表示するメッセージ 
                            0,									    // ステータス値
                            MessageBoxButtons.OK);				    // 表示するボタン

                        ((Control)sender).Focus();
                    }
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ボタンがクリックされた際のイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            UltraGridRow activeRow = ug.ActiveRow;

            //BLコードガイド
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BLコードガイド起動
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                ((Control)sender).Focus();
                return;
            }
            else
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._itemBindTable.Rows.Count;
                _beforeBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                int doubleIndex = -1;
                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == DBNull.Value || (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == 0)
                    {
                        continue;
                    }
                    int bLGoodsCode = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];

                    if (bLGoodsCode == _beforeBLGoodsCode)
                    {
                        // 重複コード有
                        AddFlg = false;
                        doubleIndex = i;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    activeRow.Cells[BLGOODSCODE_TITLE].Value = bLGoodsCdUMnt.BLGoodsCode;
                    activeRow.Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                    int rowIndex = activeRow.Index;
                    ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                    if (ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == 0)
                    {
                        ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                    }
                    if ((int)activeRow.Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.ItemGrid_AddRow();
                        ug.Rows[rowIndex + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    }

                    // 次のコントロールへフォーカスを移動
                    this.ItmStMoveNextAllowEditCell(false);
                }
                else
                {
                    if (doubleIndex != e.Cell.Row.Index)
                    {
                        // 重複エラーを表示
                        TMsgDisp.Show(
                            this,								    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                            ASSEMBLY_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                            "選択したBLコードが重複しています。",	// 表示するメッセージ 
                            0,									    // ステータス値
                            MessageBoxButtons.OK);				    // 表示するボタン

                        ((Control)sender).Focus();
                    }
                }
            }
           
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerDeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.UGrid_Customer.Rows.Count < 1)
            {
                // デバッグ用
                this.CustomerGrid_AddRow();
            }

            if (this.UGrid_Customer.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除する得意先コードを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UGrid_Customer.Focus();
            }
            else if (this.UGrid_Customer.Rows.Count == 1)
            {
                // Gridの行数が1行の場合は削除不可
                message = "全ての得意先を削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UGrid_Customer.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // 選択行の削除
                this.UGrid_Customer.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._customerBindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._customerBindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
                if (delIndex > 0)
                {
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DeleteBlCodeRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.UGrid_ItmSt.Rows.Count < 1)
            {
                // デバッグ用
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[0].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
            }

            if (this.UGrid_ItmSt.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除するBL商品コードを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UGrid_ItmSt.Focus();
            }
            else if (this.UGrid_ItmSt.Rows.Count == 1)
            {
                // Gridの行数が1行の場合は削除不可
                message = "全てのBL商品コードを削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UGrid_ItmSt.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.UGrid_ItmSt.ActiveRow.Cells[BLTIEM_ODER].Value - 1;

                // 選択行の削除
                this.UGrid_ItmSt.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._itemBindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._itemBindTable.Rows[index][BLTIEM_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Guid_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGuid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._customerBindTable.Rows.Count;

                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] != DBNull.Value)
                    {
                        int code = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                        if ((code != 0) && (code == _customerCode))
                        {
                            // 重複コード有
                            AddFlg = false;
                            break;
                        }
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._customerBindTable.Rows.Count - 1;

                    if (this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value)
                    {
                        // 最終行が空き
                        this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode;
                        this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                        this._customerBindTable.Rows[lastRow][MY_INQORIGINALEPCD] = _inqOriginalEpCd.Trim();//@@@@20230303
                        this._customerBindTable.Rows[lastRow][MY_INQORIGINALSECCD] = _inqOriginalSecCd;
                    }
                    else
                    {
                        // ガイドで選択した得意先コードを追加
                        DataRow bindRow;

                        bindRow = this._customerBindTable.NewRow();

                        // 得意先情報をGridに追加
                        bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_CUSTOMER_CODE] = _customerCode;
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _customerName;
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _inqOriginalEpCd.Trim();//@@@@20230303
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _inqOriginalSecCd;

                        this._customerBindTable.Rows.Add(bindRow);
                    }

                    // 新規行を追加
                    this.CustomerGrid_AddRow();
                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // 重複エラーを表示
                    string message = "選択した得意先コードは選択済です。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(Guid_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void BlCodeGuid_Button_Click(object sender, EventArgs e)
        {
            //BLコードガイド
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BLコードガイド起動
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }
            else
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._itemBindTable.Rows.Count;
                int blCode = bLGoodsCdUMnt.BLGoodsCode;
                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] != DBNull.Value)
                    {
                        int code = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];
                        if ((code != 0) && (code == blCode))
                        {
                            // 重複コード有
                            AddFlg = false;
                            break;
                        }
                    }
                }
                if (AddFlg)
                {
                    int lastRow = this._itemBindTable.Rows.Count - 1;

                    if (this._itemBindTable.Rows[lastRow][BLGOODSCODE_TITLE] == DBNull.Value)
                    {
                        // 最終行が空き
                        this._itemBindTable.Rows[lastRow][BLGOODSCODE_TITLE] = bLGoodsCdUMnt.BLGoodsCode;
                        this._itemBindTable.Rows[lastRow][BLGOODSNAME_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName; 
                        this.UGrid_ItmSt.Rows[lastRow].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        this.UGrid_ItmSt.Rows[lastRow].Cells[BLGOODSQTY_TITLE].Value = 1;
                    }
                    else
                    {
                        // ガイドで選択したBLコードを追加
                        DataRow bindRow;

                        bindRow = this._itemBindTable.NewRow();

                        // 得意先情報をGridに追加
                        bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
                        bindRow[BLGOODSCODE_TITLE] = bLGoodsCdUMnt.BLGoodsCode;
                        bindRow[BLGOODSNAME_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        this._itemBindTable.Rows.Add(bindRow);
                        this.UGrid_ItmSt.Rows[lastRow + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        this.UGrid_ItmSt.Rows[lastRow + 1].Cells[BLGOODSQTY_TITLE].Value = 1;
                       
                    }

                    // 新規行を追加
                    this.ItemGrid_AddRow();
                    this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count -1 ].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // 重複エラーを表示
                    string message = "選択したBLコードは選択済です。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    ((Control)sender).Focus();
                }


               
            }


           
        }

        /// <summary>
        /// 最新情報処理
        /// </summary>
        /// <remarks>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>Note       : 最新情報処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // 最新情報取得
            this._pccCpMsgStAcs.Renewal();
            this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            this._bLCodeTable = this._pccCpMsgStAcs.BLCodeTable;
            this._scmEpScCntTable = this._pccCpMsgStAcs.ScmEpScCntTable;
            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う</br>
        /// <br>Programmer	: 黄海霞</br>
        /// <br>Date		: 2010.11.20</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        #endregion

        /// <summary>
        /// キャンペーン ガイド起動
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キャンペーン ガイド起動処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void uButton_CampaignGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignStOld;
                CampaignSt campaignSt;

                // ガイド起動
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignStOld);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignStOld.CampaignCode);
                    if (campaignSt != null)
                    {
                        if ("00".Equals(campaignSt.SectionCode.TrimEnd()) || string.IsNullOrEmpty(campaignSt.SectionCode.TrimEnd()) || this._loginSectionCode.Equals(campaignSt.SectionCode))
                        {
                            // 結果セット
                            this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                            this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                            this.Insert_Button.Enabled = true;
                            // 次フォーカス
                            this.SelectNextControl((Control)sender, true, true, true, true);
                        }
                        else
                        {
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点は対象外のため、このキャンペーンは選択できません。",
                                        -1,
                                        MessageBoxButtons.OK);

                            // 得意先のクリア
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                            this.Insert_Button.Enabled = false;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
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
        /// 対象得意先区分変更処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 対象得意先区分変更処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CampaignObjDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            int campaignObjDiv = (int)CampaignObjDiv_tComboEditor.Value;
            if (campaignObjDiv == 0)
            {
                //全得意先の場合は、得意先コード明細部を入力不可とする。
                this._customerBindTable.Clear();
                this.DeleteCustomerRow_Button.Enabled = false;
                this.CustomerGuid_Button.Enabled = false;
            }
            else if(campaignObjDiv == 1)
            {
                this.DeleteCustomerRow_Button.Enabled = true;
                this.CustomerGuid_Button.Enabled = true;
                this.CustomerGrid_AddRow();
            }
        }

        /// <summary>
        ///  セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : データチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }
            string columnKey = ultraGrid.ActiveCell.Column.Key;
            int numLen = 0;
            //
            if (BLGOODSCODE_TITLE.Equals(columnKey))
            {
                //BLコード
                numLen = 8;
            }
            else if (BLGOODSQTY_TITLE.Equals(columnKey))
            {
                //BL数量
                numLen = 3;
            }
            else if (MY_SCREEN_CUSTOMER_CODE.Equals(columnKey))
            {
                //得意先コード
                numLen = 8;
            }
            if (ultraGrid.ActiveCell.Column.DataType == typeof(Int32))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = ultraGrid.ActiveCell.EditorResolved;
                string currentEditText = editorBase.CurrentEditText;
                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                if (!checkNumber)
                {
                    if (BLGOODSQTY_TITLE.Equals(columnKey))
                    {
                        ultraGrid.ActiveCell.Value = 0;
                    }
                    else
                    {
                        ultraGrid.ActiveCell.Value = DBNull.Value;
                    }
                }

            }
            e.RaiseErrorEvent = false;   // エラーイベントは発生させない
            e.RestoreOriginalValue = false;  // セルの値を元に戻さない 
            e.StayInEditMode = false;   // 編集モードは抜ける
        }

        /// <summary>
        /// グリッドアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドアクション処理後時に発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // アクティブなセルがあるか？または編集可能セルか？
                    UltraGridCell ugCell = ultraGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (ultraGrid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // 編集モードにある？
                                    if (ultraGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((ultraGrid.ActiveCell.Value is System.DBNull) ||
                                            (ultraGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (ultraGrid.ActiveCell.IsInEditMode)
                                            {
                                                // 全選択
                                                ultraGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Button:
                                {
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    ultraGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        
        # endregion
    }
}
