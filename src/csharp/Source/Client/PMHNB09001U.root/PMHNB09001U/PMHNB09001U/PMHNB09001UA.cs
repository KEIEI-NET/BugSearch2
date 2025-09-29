//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2009/11/11  修正内容 : Redmine#1223対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 修 正 日  2009/12/01  修正内容 : 得意先掛率グループ改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津
// 修 正 日  2012/04/23  修正内容 : 掛率G未選択の値は0のまま、入力区分で挙動を分岐するよう修正。
//                                  ユーザーが使いやすいようにキー重複チェックタイミング等を改良。
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 表示区分フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 表示区分を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2009.10.15</br>
    /// <br></br>
    /// <br>Update Note  : 2009/11/11 呉元嘯</br>
    /// <br>               Redmine#1223対応</br>
    /// </remarks>
    public partial class PMHNB09001UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 表示区分フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public PMHNB09001UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // インターフェース初期化
            this._makerAcs = new MakerAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            // this._secInfoAcs = new SecInfoAcs();
            this._priceSelectSet = new PriceSelectSet();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._priceSelectSetAcs = new PriceSelectSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();

            // 変数初期化
            this._dataIndex = -1;
            this._totalCount = 0;
            this._priceSelectSetTable = new Hashtable();
            this._preControl = null;
            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;
        }

        #endregion

        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        /*----------------------------------------------------------------------------------*/
        private PriceSelectSetAcs _priceSelectSetAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _priceSelectSetTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private PriceSelectSet _priceSelectSetClone;
        // 閉める比較用Clone
        private PriceSelectSet _priceSelectSetInit;
        private PriceSelectSet _priceSelectSet;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // tComboEditor用
        private const string PRICESELECTPTN_VALUE0 = "ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ";
        private const string PRICESELECTPTN_VALUE1 = "ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ";
        private const string PRICESELECTPTN_VALUE2 = "BLｺｰﾄﾞ・得意先ｺｰﾄﾞ";
        private const string PRICESELECTPTN_VALUE3 = "ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ";
        private const string PRICESELECTPTN_VALUE4 = "ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ";
        private const string PRICESELECTPTN_VALUE5 = "BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ";
        private const string PRICESELECTPTN_VALUE6 = "ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ";
        private const string PRICESELECTPTN_VALUE7 = "ﾒｰｶｰｺｰﾄﾞ";
        // private const string PRICESELECTPTN_VALUE8 = "BLｺｰﾄ"; // DEL 2009/11/11
        private const string PRICESELECTPTN_VALUE8 = "BLｺｰﾄﾞ"; // ADD 2009/11/11
        private const string PRICESELECTDIV_VALUE0 = "優良";
        private const string PRICESELECTDIV_VALUE1 = "純正";
        private const string PRICESELECTDIV_VALUE2 = "高い方(1:N)";
        private const string PRICESELECTDIV_VALUE3 = "高い方(1:1)";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_PRICESELECTPTN_TITLE = "入力区分";
        private const string VIEW_MAKERCODE_TITLE = "メーカーコード";
        private const string VIEW_MAKERNAME_TITLE = "メーカー名";
        private const string VIEW_BLGOODSCODE_TITLE = "BLコード";
        private const string VIEW_BLGOODSNAME_TITLE = "BLコード名";
        private const string VIEW_CUSTRATEGRPCODE_TITLE = "得意先掛率グループ";
        private const string VIEW_CUSTOMERCODE_TITLE = "得意先コード";
        private const string VIEW_CUSTOMERNAME_TITLE = "得意先名";
        private const string VIEW_PRICESELECTDIV_TITLE = "価格表示区分";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>起動時の得意先掛率コード</summary>
        private const int INITIAL_CUST_RATE_GRP_CODE = -1;
        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

        // エラーメッセージ
        private string ct_NoInput = "を設定して下さい。";

        // 得意先ガイド結果OKフラグ
        //private bool _customerGuideOK; // DEL 2012/04/23

        // 得意先ガイド用
        private UltraButton _customerGuideSender;

        // 抽出条件前回入力値(更新有無チェック用)
        private int _preMakerCode;
        private int _preCustomerCode;
        private int _preCustRateGrpCode;
        private int _preBLGoodsCode;
        private string _preMakerName;
        private string _preCustomerName;
        private string _preBLGoodsName;

        // メーカー情報
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        // 拠点情報
        //private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // 得意先情報
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // BLコード情報
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, string> _custRateGrpDic;

        // インターフェース
        private MakerAcs _makerAcs;
        private CustomerInfoAcs _customerInfoAcs;
        //private SecInfoAcs _secInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private UserGuideAcs _userGuideAcs;

        // 保存前にマスタチェック
        private bool flg;
        private Control _preControl;

        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        # endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            int status = 0;
            ArrayList priceSelectSets = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._priceSelectSetTable.Clear();

            // 全検索
            status = this._priceSelectSetAcs.SearchAll(out priceSelectSets, this._enterpriseCode);
            this._totalCount = priceSelectSets.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (PriceSelectSet priceSelectSet in priceSelectSets)
                        {
                            // 表示区分オブジェクトデータセット展開処理
                            PriceSelectSetToDataSet(priceSelectSet.Clone(), index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            "PMHNB09001U",							// アセンブリID
                            "表示区分",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._priceSelectSetAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。(未実装)</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public int Delete()
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面削除処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];

            int status = 1;

            // 企業コード設定情報論理削除処理
            status = this._priceSelectSetAcs.LogicalDelete(ref priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMHNB09001U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._priceSelectSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 企業コード設定情報クラスデータセット展開処理
            PriceSelectSetToDataSet(priceSelectSet.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {

            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 入力パターン
            appearanceTable.Add(VIEW_PRICESELECTPTN_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // メーカー
            appearanceTable.Add(VIEW_MAKERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // メーカー名
            appearanceTable.Add(VIEW_MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BLコード
            appearanceTable.Add(VIEW_BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BLコード名
            appearanceTable.Add(VIEW_BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先掛率グループ
            appearanceTable.Add(VIEW_CUSTRATEGRPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先コード
            appearanceTable.Add(VIEW_CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先略称
            appearanceTable.Add(VIEW_CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 表示区分
            appearanceTable.Add(VIEW_PRICESELECTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --

        /// <summary>
        /// 初期化ComboEditor
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化ComboEditorを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void InitComboEditor()
        {
            this.tComboEditor_PriceSelectPtn.Items.Clear();
            this.tComboEditor_PriceSelectPtn.Items.Add(0, PRICESELECTPTN_VALUE0);
            this.tComboEditor_PriceSelectPtn.Items.Add(1, PRICESELECTPTN_VALUE1);
            this.tComboEditor_PriceSelectPtn.Items.Add(2, PRICESELECTPTN_VALUE2);
            this.tComboEditor_PriceSelectPtn.Items.Add(3, PRICESELECTPTN_VALUE3);
            this.tComboEditor_PriceSelectPtn.Items.Add(4, PRICESELECTPTN_VALUE4);
            this.tComboEditor_PriceSelectPtn.Items.Add(5, PRICESELECTPTN_VALUE5);
            this.tComboEditor_PriceSelectPtn.Items.Add(6, PRICESELECTPTN_VALUE6);
            this.tComboEditor_PriceSelectPtn.Items.Add(7, PRICESELECTPTN_VALUE7);
            this.tComboEditor_PriceSelectPtn.Items.Add(8, PRICESELECTPTN_VALUE8);

            this.tComboEditor_PriceSelectDiv.Items.Clear();
            this.tComboEditor_PriceSelectDiv.Items.Add(0, PRICESELECTDIV_VALUE0);
            this.tComboEditor_PriceSelectDiv.Items.Add(1, PRICESELECTDIV_VALUE1);
            this.tComboEditor_PriceSelectDiv.Items.Add(2, PRICESELECTDIV_VALUE2);
            this.tComboEditor_PriceSelectDiv.Items.Add(3, PRICESELECTDIV_VALUE3);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                PriceSelectSet priceSelectSet = new PriceSelectSet();


                //クローン作成
                this._priceSelectSetClone = priceSelectSet.Clone();

                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToPriceSelectSet(ref this._priceSelectSetClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tComboEditor_PriceSelectPtn.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];
                
                if (priceSelectSet.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 表示区分マスタ情報クラス画面展開処理
                    PriceSelectSetToScreen(priceSelectSet);

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.tComboEditor_PriceSelectDiv.Focus();

                    // クローン作成
                    this._priceSelectSetClone = priceSelectSet.Clone();

                    // 画面情報を比較用クローンにコピーします
                    ScreenToPriceSelectSet(ref this._priceSelectSetClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 表示区分マスタ情報クラス画面展開処理
                    PriceSelectSetToScreen(priceSelectSet);

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();

                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Renewal_Button.Visible = true;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    if (mode == INSERT_MODE)
                    {
                        // 新規モード
                        this.tComboEditor_PriceSelectPtn.Enabled = true;
                        this.tComboEditor_PriceSelectDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tComboEditor_PriceSelectPtn.SelectedIndex = 0;
                        this.tComboEditor_PriceSelectDiv.SelectedIndex = 0;
                        // 画面初期化
                        ScreenClear();
                    }
                    else
                    {
                        // 更新モード
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tComboEditor_PriceSelectPtn.Enabled = false;
                        this.tComboEditor_PriceSelectDiv.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tNedit_GoodsMakerCd.Enabled = false;
                    this.tNedit_BLGoodsCode.Enabled = false;
                    this.CustRateGrpCodeAllowZero.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.uButton_BLGoodsGuide.Enabled = false;
                    this.uButton_CustRateGrpGuide.Enabled = false;
                    this.uButton_GoodsMakerGuid.Enabled = false;
                    this.tComboEditor_PriceSelectPtn.Enabled = false;
                    this.tComboEditor_PriceSelectDiv.Enabled = false;

                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報表示区分クラス格納処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から表示区分オブジェクトにデータを格納します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        private void ScreenToPriceSelectSet(ref PriceSelectSet priceSelectSet)
        {
            if (priceSelectSet == null)
            {
                // 新規の場合
                priceSelectSet = new PriceSelectSet();
            }

            //企業コード
            priceSelectSet.EnterpriseCode = this._enterpriseCode;
            // 入力パターン
            priceSelectSet.PriceSelectPtn = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            // メーカーコード
            priceSelectSet.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // メーカー名
            priceSelectSet.MakerName = this.tEdit_GoodsMakerName.DataText;
            // BLコード
            priceSelectSet.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            // BLコード名
            priceSelectSet.BLGoodsFullName = this.tEdit_BLGoodsName.DataText;
            // 得意先掛率グループ
            priceSelectSet.CustRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
            // 得意先コード
            priceSelectSet.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 得意先名
            priceSelectSet.CustomerSnm = this.tEdit_CustomerName.DataText;
            // 表示区分
            priceSelectSet.PriceSelectDiv = this.tComboEditor_PriceSelectDiv.SelectedIndex;

        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string str = "";
            LoadCustomerSearchRet(false);
            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    str = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }
            catch
            {
                str = "";
            }
            return str;

        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";
            LoadMakerUMnt(false);
            try
            {
                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";
            LoadBLGoodsCdUMnt(false);
            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <param name="flg">読込DBのフラグ</param>
        /// <remarks>
        /// <br>Note       : メーカーマスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void LoadMakerUMnt( bool flg)
        {
            if (flg == false && _makerUMntDic != null)
            {
                return;
            }
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            try
            {
                ArrayList retList;

                // メーカー検索
                int status = _makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            // 保存メーカー
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : 得意先マスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void LoadCustomerSearchRet(bool flg)
        {
            if (flg == false && _customerSearchRetDic != null)
            {
                return;
            }

            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            try
            {
                CustomerSearchRet[] retArray;
                CustomerSearchPara paraRec = new CustomerSearchPara();
                paraRec.EnterpriseCode = this._enterpriseCode;


                // 得意先マスタ情報検索
                if (_customerSearchAcs.Serch(out retArray, paraRec) == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            // 保存得意先マスタ情報
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : BLコードマスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void LoadBLGoodsCdUMnt(bool flg)
        {
            if (flg == false && _blGoodsCdUMntDic != null)
            {
                return;
            }

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();
            ArrayList retList = new ArrayList();
            int status = this.GetUserGuideBd(out retList, 0x2b);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
            allDefSetTable.Columns.Add(VIEW_PRICESELECTPTN_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_MAKERCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_MAKERNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODSCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODSNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTRATEGRPCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMERCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMERNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRICESELECTDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(allDefSetTable);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 新規画面を戻る
            this.tComboEditor_PriceSelectPtn.SelectedIndex = 0;
            this.tComboEditor_PriceSelectDiv.SelectedIndex = 0;
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tNedit_CustomerCode.Clear();
            this.CustRateGrpCodeAllowZero.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_GoodsMakerName.Clear();

            this._preCustomerCode = 0;
            this._preCustomerName = string.Empty;

            // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
            //this._preCustRateGrpCode = 0;
            // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
            this._preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

            this._preMakerCode = 0;
            this._preMakerName = string.Empty;
            this._preBLGoodsCode = 0;
            this._preBLGoodsName = string.Empty;

            ScreenToPriceSelectSet(ref _priceSelectSetInit);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分クラス画面展開処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 表示区分オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void PriceSelectSetToScreen(PriceSelectSet priceSelectSet)
        {
            // 入力パターン
            this.tComboEditor_PriceSelectPtn.SelectedIndex = priceSelectSet.PriceSelectPtn;
            // メーカーコード
            this.tNedit_GoodsMakerCd.SetInt(priceSelectSet.GoodsMakerCd);
            // メーカー名
            this.tEdit_GoodsMakerName.DataText = priceSelectSet.MakerName;
            // BLコード
            this.tNedit_BLGoodsCode.SetInt(priceSelectSet.BLGoodsCode);
            // BLコード名
            this.tEdit_BLGoodsName.DataText = priceSelectSet.BLGoodsFullName;
            // 得意先掛率グループ
            // -- UPD 2012/04/23 -------------------------->>>>
            #region DEL 入力区分だけで掛率Gの表示方法を判別するよう修正
            //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
            //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
            //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
            //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
            //if (priceSelectSet.CustRateGrpCode < 0)
            //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
            //{
            //    // 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
            //    // 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
            //    // 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
            //    if (this.tComboEditor_PriceSelectPtn.SelectedIndex == 3 || this.tComboEditor_PriceSelectPtn.SelectedIndex == 4 || this.tComboEditor_PriceSelectPtn.SelectedIndex == 5)
            //    {
            //        this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            //    }
            //    else
            //    {
            //        this.CustRateGrpCodeAllowZero.Clear();
            //    }
            //}
            //else
            //{
            //    this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            //}
            #endregion DEL 入力区分だけで掛率Gの表示方法を判別するよう修正
            if (this.tComboEditor_PriceSelectPtn.SelectedIndex == 3 || // 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                this.tComboEditor_PriceSelectPtn.SelectedIndex == 4 || // 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                this.tComboEditor_PriceSelectPtn.SelectedIndex == 5)   // 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
            {
                this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            }
            else
            {
                this.CustRateGrpCodeAllowZero.Clear();
            }
            // -- UPD 2012/04/23 --------------------------<<<<
            // 得意先コード
            this.tNedit_CustomerCode.SetInt(priceSelectSet.CustomerCode);
            // 得意先名
            this.tEdit_CustomerName.DataText = priceSelectSet.CustomerSnm;
            // 表示区分
            this.tComboEditor_PriceSelectDiv.SelectedIndex = priceSelectSet.PriceSelectDiv;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	企業コード設定画面入力チェック処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note	   : 企業コード設定画面の入力チェックをします。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = string.Empty;
            try
            {
                // メーカーコード
                if ((this.tNedit_GoodsMakerCd.GetInt() == 0) && (this.tNedit_GoodsMakerCd.Enabled == true))
                {
                    checkMessage = string.Format("メーカー{0}", ct_NoInput);
                    this.tNedit_GoodsMakerCd.Focus();
                    status = false;
                }
                // BLコード
                else if ((this.tNedit_BLGoodsCode.GetInt() == 0) && (this.tNedit_BLGoodsCode.Enabled == true))
                {
                    checkMessage = string.Format("BLコード{0}", ct_NoInput);
                    this.tNedit_BLGoodsCode.Focus();
                    status = false;
                }
                // 得意先掛率グループ
                // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // TODO:else if ((this.tNedit_CustRateGrpCode.GetInt() == 0) && (this.tNedit_CustRateGrpCode.Enabled == true))
                // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // -- UPD 2012/04/23 --------------------------------->>>>
                //else if ((this.CustRateGrpCodeAllowZero.GetInt() < 0) && (this.CustRateGrpCodeAllowZero.Enabled == true))
                else if ((this.CustRateGrpCodeAllowZero.Text == "") && (this.CustRateGrpCodeAllowZero.Enabled == true))
                // -- UPD 2012/04/23 ---------------------------------<<<<
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                {
                    checkMessage = string.Format("得意先掛率グループ{0}", ct_NoInput);
                    this.CustRateGrpCodeAllowZero.Focus();
                    status = false;
                }
                // 得意先コード
                else if ((this.tNedit_CustomerCode.GetInt() == 0)&&(this.tNedit_CustomerCode.Enabled == true))
                {
                    checkMessage = string.Format("得意先コード{0}", ct_NoInput);
                    this.tNedit_CustomerCode.Focus();
                    status = false;
                }
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMHNB09001U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }
            }
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SavePriceSelectSet())
        /// </summary>
        /// <returns>保存処理状態</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private bool SavePriceSelectSet()
        {
            bool result = false;
            Control control = null;

            // 画面フォーカスを取得する
            GetCurrentFocus();

            //「Alt+S」チェック(マスタとメーカーのチェック)
            ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._preControl, this._preControl);
            this.tRetKeyControl1_ChangeFocus(this, e2);
            if (this.flg == false)
            {
                return false;
            }

            //画面データ入力チェック処理
            bool chkSt = CheckDisplay();
            if (!chkSt)
            {
                return chkSt;
            }

            PriceSelectSet priceSelectSet = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                priceSelectSet = ((PriceSelectSet)this._priceSelectSetTable[guid]).Clone();
            }

            ScreenToPriceSelectSet(ref priceSelectSet);

            int status = this._priceSelectSetAcs.Write(ref priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // -- UPD 2012/04/23 -------------------->>>>
                        //this.ScreenClear();
                        MessageBox.Show("保存しました。", "保存確認",
                                        MessageBoxButtons.OK, MessageBoxIcon.None);

                        //比較用クローンにコピー
                        this._priceSelectSetClone = priceSelectSet.Clone();
                        // -- UPD 2012/04/23 --------------------<<<<

                        this.tComboEditor_PriceSelectPtn.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        //control.Focus();    // DEL 2012/04/23
                        
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

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
                        return false;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            "PMHNB09001U",							// アセンブリID
                            "表示区分",  　　                 // プログラム名称
                            "SavePriceSelectSet",                       // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._priceSelectSet,				    	// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,			  		// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

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
                        return false;
                    }
            }

            PriceSelectSetToDataSet(priceSelectSet, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // 新規登録時
            if (this.Mode_Label.Text.Equals(UPDATE_MODE))
            {
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            result = true;
            return result;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 表示区分クラスをデータセットに格納します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void PriceSelectSetToDataSet(PriceSelectSet priceSelectSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (priceSelectSet.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = priceSelectSet.UpdateDateTimeJpInFormal;
            }

            // 入力パターン
            // 0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
            if (priceSelectSet.PriceSelectPtn == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE0;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            //  1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
            else if (priceSelectSet.PriceSelectPtn == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE1;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
            else if (priceSelectSet.PriceSelectPtn == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE2;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
            else if (priceSelectSet.PriceSelectPtn == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE3;
                // 得意先掛率グループ
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
            }
            // 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
            else if (priceSelectSet.PriceSelectPtn == 4)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE4;
                // 得意先掛率グループ
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");

            }
            // 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
            else if (priceSelectSet.PriceSelectPtn == 5)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE5;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
            }
            // 6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
            else if (priceSelectSet.PriceSelectPtn == 6)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE6;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 7:ﾒｰｶｰｺｰﾄﾞ
            else if (priceSelectSet.PriceSelectPtn == 7)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE7;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 8:BLｺｰﾄﾞ
            else if (priceSelectSet.PriceSelectPtn == 8)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE8;
                // 得意先掛率グループ
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL この入力パターンの時は、固定で空白にするよう変更
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL この入力パターンの時は、固定で空白にするよう変更
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }

            // メーカーコード
            if (priceSelectSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERCODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERCODE_TITLE] = priceSelectSet.GoodsMakerCd.ToString("D4");
            }

            //　メーカー名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERNAME_TITLE] = priceSelectSet.MakerName;

            //　BLコード
            if (priceSelectSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSCODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSCODE_TITLE] = priceSelectSet.BLGoodsCode.ToString("D5");
            }

            // BLコード名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSNAME_TITLE] = priceSelectSet.BLGoodsFullName;

            //　得意先コード
            if (priceSelectSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCODE_TITLE] =string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCODE_TITLE] = priceSelectSet.CustomerCode.ToString("D8");
            }

            //　得意先名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERNAME_TITLE] = priceSelectSet.CustomerSnm;

            // 表示区分
            if (priceSelectSet.PriceSelectDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE0;
            }
            else if (priceSelectSet.PriceSelectDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE1;
            }
            else if (priceSelectSet.PriceSelectDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE2;
            }
            else if (priceSelectSet.PriceSelectDiv == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE3;
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = priceSelectSet.FileHeaderGuid;

            if (this._priceSelectSetTable.ContainsKey(priceSelectSet.FileHeaderGuid) == true)
            {
                this._priceSelectSetTable.Remove(priceSelectSet.FileHeaderGuid);
            }

            this._priceSelectSetTable.Add(priceSelectSet.FileHeaderGuid, priceSelectSet);
        }

        /// <summary>
        /// 同一データのメッセージ
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 既に拠点管理設定マスタに同一データある場合、メッセージがある。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "PMHNB09001U",						// アセンブリＩＤまたはクラスＩＤ
                "このコードが既に存在しています。", // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            // -- DEL 2012/04/23 ------------------------->>>>
            //this.tComboEditor_PriceSelectPtn.Focus();

            //control = tComboEditor_PriceSelectPtn;
            // -- DEL 2012/04/23 -------------------------<<<<
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMHNB09001U",							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /// <summary>
        /// 入力パターンより画面の状態を判断
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入力パターンより画面の状態を判断を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private bool PriceSelectPtnCheck()
        {
            int currMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            int currBLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            string currustRateGrpCode = this.CustRateGrpCodeAllowZero.DataText;
            int number = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            bool flg = true;
            switch (number)
            {
                case 0:// 0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        if ((currMakerCode == 0) || (currCustomerCode == 0) || (currBLGoodsCode == 0))
                        {
                            flg = false;
                        }
                        break;
                    }
                case 1:// 1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        if (currMakerCode == 0 || currCustomerCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 2:// 2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        if (currCustomerCode == 0 || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 3:// 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        if (currMakerCode == 0 || string.IsNullOrEmpty(currustRateGrpCode) || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 4:// 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        if (currMakerCode == 0 || string.IsNullOrEmpty(currustRateGrpCode))
                        {
                            flg = false;
                        }
                        break;
                    }
                case 5:// 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        if (string.IsNullOrEmpty(currustRateGrpCode) || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 6:// 6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ 
                    {
                        if (currMakerCode == 0 || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 7:// 7:ﾒｰｶｰｺｰﾄﾞ 
                    {
                        if (currMakerCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 8:// 8:BLｺｰﾄﾞ
                    {
                        if (currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
            }
            return flg;
        }

        /// <summary>
        /// 入力されたコードの表示区分マスタ情報の存在チェック処理
        /// </summary>
        /// <returns>存在の判断</returns>
        /// <remarks>
        /// <br>Note       : 入力されたコードの表示区分マスタ情報の存在チェック処理します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "入力されたコードの表示区分マスタ情報が既に登録されています。\n編集を行いますか？";
            if (!PriceSelectPtnCheck())
            {
                return true;
            }

            int currMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            int currBLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            int currCustRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
            int currNumber = this.tComboEditor_PriceSelectPtn.SelectedIndex;


            // 新規モードかつメーカーと得意先と得意先掛率グループとBL商品コードの入力内容が表示区分マスタに存在チェック処理
            int makerCode = 0;
            int BLGoodsCode = 0;
            int custRateGrpCode = 0;
            int customerCode = 0;
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                // メーカー
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_MAKERCODE_TITLE].ToString().Trim()))
                {
                    makerCode = 0;
                }
                else
                {
                    makerCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_MAKERCODE_TITLE].ToString().Trim());
                }
                // BL商品コード
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODSCODE_TITLE].ToString().Trim()))
                {
                    BLGoodsCode = 0;
                }
                else
                {
                    BLGoodsCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODSCODE_TITLE].ToString().Trim());
                }
                // 得意先掛率グループ
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTRATEGRPCODE_TITLE].ToString().Trim()))
                {
                    custRateGrpCode = 0;
                }
                else
                {
                    custRateGrpCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTRATEGRPCODE_TITLE].ToString().Trim());
                }
                // 得意先
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCODE_TITLE].ToString().Trim()))
                {
                    customerCode = 0;
                }
                else
                {
                    customerCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCODE_TITLE].ToString().Trim());
                }
                
                // 表示区分マスタに存在する場合
                if ((currMakerCode == makerCode) && (currCustomerCode == customerCode) && (currBLGoodsCode == BLGoodsCode) && (currCustRateGrpCode == custRateGrpCode))
                {
                    // 選択したのデータは削除した場合
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", "入力されたコードの表示区分マスタ情報は既に削除されています。", 0, MessageBoxButtons.OK);
                        this.tNedit_BLGoodsCode.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        _preCustomerCode = 0;
                        _preCustomerCode = 0;

                        // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //_preCustRateGrpCode = 0;
                        // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        _preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

                        _preBLGoodsCode = 0;
                        _preBLGoodsName = string.Empty;
                        _preCustomerName = string.Empty;
                        _preMakerName = string.Empty;
                        return false;
                    }
                    // 選択したのデータは削除しない場合
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            // this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:

                            #region DEL 2012/04/23 いいえ選択時、画面クリアしないよう変更
                            //this.tNedit_BLGoodsCode.Clear();
                            //this.CustRateGrpCodeAllowZero.Clear();
                            //this.tNedit_CustomerCode.Clear();
                            //this.tNedit_GoodsMakerCd.Clear();
                            //this.tEdit_BLGoodsName.Clear();
                            //this.tEdit_CustomerName.Clear();
                            //this.tEdit_GoodsMakerName.Clear();
                            //_preCustomerCode = 0;
                            //_preCustomerCode = 0;

                            //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            ////_preCustRateGrpCode = 0;
                            //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            //_preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                            //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

                            //_preBLGoodsCode = 0;
                            //_preBLGoodsName = string.Empty;
                            //_preCustomerName = string.Empty;
                            //_preMakerName = string.Empty;
                            #endregion DEL 2012/04/23 いいえ選択時、画面クリアしないよう変更

                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 画面フォーカス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面フォーカス取得を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void GetCurrentFocus()
        {
            // 画面フォーカス判断、画面フォーカスを取得する
            if (this.tNedit_GoodsMakerCd.Focused)
            {
                // メーカー
                this._preControl = this.tNedit_GoodsMakerCd;
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                // 得意先
                this._preControl = this.tNedit_CustomerCode;
            }
            else if (this.tNedit_BLGoodsCode.Focused)
            {
                // BLコード
                this._preControl = this.tNedit_BLGoodsCode;
            }
            else if (this.CustRateGrpCodeAllowZero.Focused)
            {
                // 得意先掛率グループ
                this._preControl = this.CustRateGrpCodeAllowZero;
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_BLGoodsGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustRateGrpGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            InitComboEditor();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing イベント(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged イベント(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_VisibleChanged(object sender, EventArgs e)
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
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            ScreenClear();

            Timer.Enabled = true;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面保存処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!SavePriceSelectSet())
            {
                return;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                PriceSelectSet comparePriceSelectSet = new PriceSelectSet();

                comparePriceSelectSet = this._priceSelectSetClone.Clone();
                ScreenToPriceSelectSet(ref comparePriceSelectSet);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (!(this._priceSelectSetClone.Equals(comparePriceSelectSet) || this._priceSelectSetInit.Equals(comparePriceSelectSet)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        "PMHNB09001U", 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SavePriceSelectSet())
                                {
                                    return;
                                }
                                return;
                            }

                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

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

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面完全削除処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                "PMHNB09001U",						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];

            // 拠点情報論理削除処理
            int status = this._priceSelectSetAcs.Delete(priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._priceSelectSetTable.Remove(priceSelectSet.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMHNB09001U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._priceSelectSet, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
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

            // 復活処理確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                "PMHNB09001U",						// アセンブリＩＤまたはクラスＩＤ
                "現在表示中の表示区分マスタを復活します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            PriceSelectSet priceSelectSet = ((PriceSelectSet)this._priceSelectSetTable[guid]).Clone();
            // 復活
            status = this._priceSelectSetAcs.Revival(ref priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        PriceSelectSetToDataSet(priceSelectSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            "PMHNB09001U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._priceSelectSet,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Control.Click イベント(Renewal_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 最新情報ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            LoadMakerUMnt(true);
            LoadBLGoodsCdUMnt(true);
            LoadCustomerSearchRet(true);
            GetCustRateGrp();
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", "最新情報を取得しました。", 0, MessageBoxButtons.OK);

        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : メーカーガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_GoodsMakerGuid_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MakerUMnt makerUMnt = new MakerUMnt();

                // メーカーガイド表示
                status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    this.tEdit_GoodsMakerName.DataText = makerUMnt.MakerName;

                    // 設定値を保存
                    this._preMakerCode = makerUMnt.GoodsMakerCd;
                    this._preMakerName = makerUMnt.MakerName;

                    #region DEL 2012/04/23
                    // 表示区分マスタに存在チェック
                    //if (this.ModeChangeProc())
                    //{
                    //    // フォーカス設定
                    //    if (this.tNedit_BLGoodsCode.Enabled == true)
                    //    {
                    //        this.tNedit_BLGoodsCode.Focus();
                    //    }
                    //    else if (this.CustRateGrpCodeAllowZero.Enabled == true)
                    //    {
                    //        this.CustRateGrpCodeAllowZero.Focus();
                    //    }
                    //    else if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// BL商品コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : BL商品コードガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_BLGoodsGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    // -- UPD 2012/04/23 ----------------------------------->>>>
                    //this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();
                    this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    // -- UPD 2012/04/23 -----------------------------------<<<<

                    // 設定値を保存
                    this._preBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                    // -- UPD 2012/04/23 ----------------------------------->>>>
                    //this._preBLGoodsName = blGoodsCdUMnt.BLGoodsFullName.ToString().Trim();
                    this._preBLGoodsName = blGoodsCdUMnt.BLGoodsHalfName.ToString().Trim();
                    // -- UPD 2012/04/23 -----------------------------------<<<<

                    #region DEL 2012/04/23
                    // 表示区分マスタに存在チェック
                    //if (this.ModeChangeProc())
                    //{
                    //    // フォーカス設定
                    //    if (this.CustRateGrpCodeAllowZero.Enabled == true)
                    //    {
                    //        this.CustRateGrpCodeAllowZero.Focus();
                    //    }
                    //    else if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// マスタチェックしてフォーカス設定イベント
        /// </summary>
        /// <returns>TNedit</returns>
        /// <remarks> 
        /// <br>Note       : マスタチェックしてフォーカス設定の処理を行う</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private TNedit SetModeChangeProcFocus()
        {
            int num = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            TNedit nextTNedit = new TNedit();
            switch (num)
            {
                case 0:// 0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                case 1:// 1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                case 3:// 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                case 4:// 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                case 6:// 6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ 
                case 7:// 7:ﾒｰｶｰｺｰﾄﾞ 
                    {
                        nextTNedit = this.tNedit_GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.Focus();
                        break;
                    }
                case 2:// 2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                case 5:// 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                case 8:// 8:BLｺｰﾄﾞ
                    {
                        nextTNedit = this.tNedit_BLGoodsCode;
                        this.tNedit_BLGoodsCode.Focus();
                        break;
                    }

            }
            return nextTNedit;
        }

        /// <summary>
        /// 得意先掛率グループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 得意先掛率グループガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_CustRateGrpGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    this.CustRateGrpCodeAllowZero.DataText = userGdBd.GuideCode.ToString("D4");
                    // 設定値を保存
                    this._preCustRateGrpCode = userGdBd.GuideCode;

                    #region DEL 2012/04/23
                    // 表示区分マスタに存在チェック
                    //if (this.ModeChangeProc())
                    //{
                    //    // フォーカス設定
                    //    if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            //_customerGuideOK = false; // DEL 2012/04/23

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            #region DEL 2012/04/23
            //if (_customerGuideOK)
            //{
            //     表示区分マスタに存在チェック
            //    if (this.ModeChangeProc())
            //    {
            //        this.tComboEditor_PriceSelectDiv.Focus();
            //    }
            //    else
            //    {
            //        SetModeChangeProcFocus();
            //    }
            //}
            #endregion DEL 2012/04/23

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // ガイド起動
            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;
            // 項目に展開
            if (_customerGuideSender == this.uButton_CustomerGuide)
            {
                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                this.tEdit_CustomerName.Text = customerInfo.CustomerSnm;

                // 設定値を保存
                this._preCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._preCustomerName = this.tEdit_CustomerName.DataText;
            }

            //_customerGuideOK = true; // DEL 2012/04/23
        }

        /// <summary>
        /// 入力パターンValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : 入力パターンValueChangedときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void tComboEditor_PriceSelectPtn_ValueChanged(object sender, EventArgs e)
        {
            switch (this.tComboEditor_PriceSelectPtn.SelectedIndex)
            {
                case 0:// 0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 1:// 1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 2:// 2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 3:// 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 4:// 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 5:// 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 6:// 6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 7:// 7:ﾒｰｶｰｺｰﾄﾞ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 8:// 8:BLｺｰﾄﾞ
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
            }

        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus イベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._preControl = e.NextCtrl;
            this.flg = true;

            switch (e.PrevCtrl.Name)
            {
                // メーカー
                case "tNedit_GoodsMakerCd":
                    {
                        // 入力無し
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            this._preMakerCode = 0;
                            this._preMakerName = string.Empty;
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tEdit_GoodsMakerName.Clear();
                            break;
                        }

                        // メーカー名称取得
                        string makerName = GetMakerName(this.tNedit_GoodsMakerCd.GetInt());
                        if (!string.IsNullOrEmpty(makerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_GoodsMakerName.DataText = makerName;

                            // 設定値を保存
                            this._preMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                            this._preMakerName = makerName;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_GoodsMakerCd.SetInt(this._preMakerCode);
                            this.tEdit_GoodsMakerName.DataText = this._preMakerName;
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMHNB09001U",							// アセンブリID
                                "メーカーが存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす                          
                        //            if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();
                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        // 入力無し
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            this._preCustomerCode = 0;
                            this.tNedit_CustomerCode.DataText = string.Empty;
                            this.tEdit_CustomerName.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();
                        // 得意先名称取得
                        string customerName = GetCustomerName(customerCode);

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tNedit_CustomerCode.SetInt(customerCode);
                            this.tEdit_CustomerName.DataText = customerName;

                            // 設定値を保存
                            this._preCustomerCode = customerCode;
                            this._preCustomerName = customerName;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_CustomerCode.SetInt(this._preCustomerCode);
                            this.tEdit_CustomerName.DataText = this._preCustomerName;

                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMHNB09001U",							// アセンブリID
                                "得意先が存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else if (this.tComboEditor_PriceSelectPtn.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();

                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // BLコード
                case "tNedit_BLGoodsCode":
                    {
                        // 入力無し
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            this._preBLGoodsCode = 0;
                            this._preBLGoodsName = string.Empty;
                            this.tNedit_BLGoodsCode.DataText = string.Empty;
                            this.tEdit_BLGoodsName.DataText = string.Empty;
                            break;
                        }

                        // 得意先コード取得
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        // 得意先名称取得
                        string bLGoodsName = GetBLGoodsName(bLGoodsCode);

                        if (!string.IsNullOrEmpty(bLGoodsName))
                        {
                            // 結果を画面に設定
                            this.tNedit_BLGoodsCode.SetInt(bLGoodsCode);
                            this.tEdit_BLGoodsName.DataText = bLGoodsName;

                            // 設定値を保存
                            this._preBLGoodsCode = bLGoodsCode;
                            this._preBLGoodsName = bLGoodsName;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_BLGoodsCode.SetInt(this._preBLGoodsCode);
                            this.tEdit_BLGoodsName.DataText = this._preBLGoodsName;

                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMHNB09001U",							// アセンブリID
                                "BLコードが存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();
                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // 得意先掛率グループ
                // -- UPD 2012/04/23 -------------------------->>>>
                //case "tNedit_CustRateGrpCode":
                case "CustRateGrpCodeAllowZero":
                // -- UPD 2012/04/23 -------------------------->>>>
                    {
                        // -- UPD 2012/04/23 ---------------------------->>>>
                        #region DEL -1ではなく空白だった場合に未入力と判定する
                        //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //// TODO:if (this.tNedit_CustRateGrpCode.GetInt() == 0)
                        //// DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //if (this.CustRateGrpCodeAllowZero.GetInt() < 0)
                        //// ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        #endregion DEL -1ではなく空白だった場合に未入力と判定する
                        if (this.CustRateGrpCodeAllowZero.Text == "")
                        // -- UPD 2012/04/23 ----------------------------<<<<
                        {
                            this.CustRateGrpCodeAllowZero.Clear();
                            // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            // this._preCustRateGrpCode = 0;
                            // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            this._preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            return;
                        }
                        int custRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
                        // マスタの検索
                        if (this._custRateGrpDic == null)
                        {
                            // メーカーマスタ読込処理
                            GetCustRateGrp();
                        }
                        if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
                        {
                            this._preCustRateGrpCode = custRateGrpCode;
                            this.CustRateGrpCodeAllowZero.SetInt(custRateGrpCode);
                        }
                        else
                        {
                            // 前回入力値を設定
                            // -- UPD 2012/04/23 ------------------------------->>>>
                            //this.CustRateGrpCodeAllowZero.SetInt(this._preCustRateGrpCode);
                            if (this._preCustRateGrpCode != INITIAL_CUST_RATE_GRP_CODE)
                            {
                                this.CustRateGrpCodeAllowZero.SetInt(this._preCustRateGrpCode);
                            }
                            else
                            {
                                this.CustRateGrpCodeAllowZero.Text = "";
                            }
                            // -- UPD 2012/04/23 -------------------------------<<<<
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMHNB09001U",							// アセンブリID
                                "得意先掛率グループが存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                        //            if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();

                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
            }
            // -- ADD 2012/04/23 ------------------------------->>>>
            if ((e.PrevCtrl.Name == "tComboEditor_PriceSelectPtn") ||
                (e.PrevCtrl.Name == "tNedit_GoodsMakerCd") ||
                (e.PrevCtrl.Name == "tNedit_CustomerCode") ||
                (e.PrevCtrl.Name == "tNedit_BLGoodsCode") ||
                (e.PrevCtrl.Name == "CustRateGrpCodeAllowZero") ||
                (e.PrevCtrl.Name == "uButton_GoodsMakerGuid") ||
                (e.PrevCtrl.Name == "uButton_BLGoodsGuide") ||
                (e.PrevCtrl.Name == "uButton_CustRateGrpGuide") ||
                (e.PrevCtrl.Name == "uButton_CustomerGuide") ||
                (e.PrevCtrl.Name == "Cancel_Button"))
            {
                if ((e.NextCtrl.Name != "tComboEditor_PriceSelectPtn") &&
                    (e.NextCtrl.Name != "tNedit_GoodsMakerCd") &&
                    (e.NextCtrl.Name != "tNedit_CustomerCode") &&
                    (e.NextCtrl.Name != "tNedit_BLGoodsCode") &&
                    (e.NextCtrl.Name != "CustRateGrpCodeAllowZero") &&
                    (e.NextCtrl.Name != "uButton_GoodsMakerGuid") &&
                    (e.NextCtrl.Name != "uButton_BLGoodsGuide") &&
                    (e.NextCtrl.Name != "uButton_CustRateGrpGuide") &&
                    (e.NextCtrl.Name != "uButton_CustomerGuide") &&
                    (e.NextCtrl.Name != "Cancel_Button"))
                {
                    ModeChangeProc();
                }
            }
            // -- ADD 2012/04/23 -------------------------------<<<<
        }
        #endregion

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
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
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
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

    }
}
