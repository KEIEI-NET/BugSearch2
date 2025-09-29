//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス設定マスタメンテナンス
// プログラム概要   : オートバックス設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/07/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 修 正 日  2012/12/07  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鹿庭 一郎
// 修 正 日  2014/05/16  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの初期値変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢貞義
// 修 正 日  2018/07/20  修正内容 : Ｓ＆Ｅブレーキ企業名称変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 修 正 日  2025/03/04  修正内容 : PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応
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
using Broadleaf.Application.Resources; // ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// オートバックス設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: オートバックス設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2009.07.30</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
    /// <br>UpdateNote  : 2014/05/16 鹿庭 一郎</br>
    /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの初期値変更</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSAE09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オートバックス設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: オートバックス設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public PMSAE09010UA()
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
            this._secInfoAcs = new SecInfoAcs();
            this._sAndESettingAcs = new SAndESettingAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // 変数初期化
            this._dataIndex = -1;
            this._totalCount = 0;
            this._sAndESettingTable = new Hashtable();
            this.flg = true;
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
        private SAndESettingAcs _sAndESettingAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _sAndESettingTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private SAndESetting _sAndESettingClone;
        // 閉める比較用Clone
        private SAndESetting _sAndESettingInit;

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

        private const int MAKER_COUNT = 15;

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_SECTION_CODE_TITLE = "拠点ｺｰﾄﾞ";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";
        private const string VIEW_CUSTOMER_CODE_TITLE = "得意先ｺｰﾄﾞ";
        private const string VIEW_CUSTOMER_NAME_TITLE = "得意先略称";
        private const string VIEW_ADDRESSEESHOP_CODE_TITLE = "納品先店舗ｺｰﾄﾞ";
        private const string VIEW_SANDEMNG_CODE_TITLE = "S&E管理ｺｰﾄﾞ";
        private const string VIEW_EXPENSEDIV_CODE_TITLE = "経費区分";
        private const string VIEW_DIRECTSENDING_CODE_TITLE = "直送区分";
        private const string VIEW_ACPTANORDERDIV_TITLE = "受注区分";
        private const string VIEW_DELIVERER_CODE_TITLE = "納入者ｺｰﾄﾞ";
        private const string VIEW_DELIVERER_NAME_TITLE = "納入者名";
        private const string VIEW_DELIVERERADDRESS_TITLE = "納入者住所";
        private const string VIEW_DELIVERERPHONENUM_TITLE = "納入者TEL";
        private const string VIEW_TRADCOMP_NAME_TITLE = "部品商名";
        private const string VIEW_TRADCOMPSECT_NAME_TITLE = "部品商拠点名";
        private const string VIEW_PURETRADCOMP_CODE_TITLE = "部品商ｺｰﾄﾞ（純正）";
        private const string VIEW_PURETRADCOMPRATE_TITLE = "部品商仕切率（純正）";
        private const string VIEW_PRITRADCOMP_CODE_TITLE = "部品商ｺｰﾄﾞ（優良）";
        private const string VIEW_PRITRADCOMPRATE_TITLE = "部品商仕切率（優良）";
        private const string VIEW_ABGOODS_CODE_TITLE = "商品ｺｰﾄﾞ";
        private const string VIEW_COMMENTRESERVEDDIV_TITLE = "7行目コメント指定";
        private const string VIEW_GOODSMAKER_CODE1_TITLE = "純正対応メーカー１";
        private const string VIEW_GOODSMAKER_CODE2_TITLE = "純正対応メーカー２";
        private const string VIEW_GOODSMAKER_CODE3_TITLE = "純正対応メーカー３";
        private const string VIEW_GOODSMAKER_CODE4_TITLE = "純正対応メーカー４";
        private const string VIEW_GOODSMAKER_CODE5_TITLE = "純正対応メーカー５";
        private const string VIEW_GOODSMAKER_CODE6_TITLE = "純正対応メーカー６";
        private const string VIEW_GOODSMAKER_CODE7_TITLE = "純正対応メーカー７";
        private const string VIEW_GOODSMAKER_CODE8_TITLE = "純正対応メーカー８";
        private const string VIEW_GOODSMAKER_CODE9_TITLE = "純正対応メーカー９";
        private const string VIEW_GOODSMAKER_CODE10_TITLE = "純正対応メーカー１０";
        private const string VIEW_GOODSMAKER_CODE11_TITLE = "純正対応メーカー１１";
        private const string VIEW_GOODSMAKER_CODE12_TITLE = "純正対応メーカー１２";
        private const string VIEW_GOODSMAKER_CODE13_TITLE = "純正対応メーカー１３";
        private const string VIEW_GOODSMAKER_CODE14_TITLE = "純正対応メーカー１４";
        private const string VIEW_GOODSMAKER_CODE15_TITLE = "純正対応メーカー１５";
        private const string VIEW_PARTSOEMDIV_TITLE = "OEM区分";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // エラーメッセージ
        private string ct_DupliInput = "が重複しています。";
        private string ct_SetError = "は設定できません。";
        private string ct_NoInput = "を設定して下さい。";

        //設定XMLファイル名
        private const string XML_FILE_NAME = "SANDESETTING.XML"; // ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        // 得意先ガイド用
        private UltraButton _customerGuideSender;

        // 抽出条件前回入力値(更新有無チェック用)
        private string _tmpSectionCode;
        private string _tmpSectionName;
        private int _tmpCustomerCode;
        private string _tmpCustomerName;
        private int _prevMakerCode1;
        private int _prevMakerCode2;
        private int _prevMakerCode3;
        private int _prevMakerCode4;
        private int _prevMakerCode5;
        private int _prevMakerCode6;
        private int _prevMakerCode7;
        private int _prevMakerCode8;
        private int _prevMakerCode9;
        private int _prevMakerCode10;
        private int _prevMakerCode11;
        private int _prevMakerCode12;
        private int _prevMakerCode13;
        private int _prevMakerCode14;
        private int _prevMakerCode15;

        // メーカー情報
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        // 拠点情報
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // 得意先情報
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        // インターフェース
        private MakerAcs _makerAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private SecInfoAcs _secInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;

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
        /// <br>Date		: 2009.07.30</br>
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
        /// <br>Date		: 2009.07.30</br>
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
            ArrayList sAndESettings = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._sAndESettingTable.Clear();

            // 全検索
            status = this._sAndESettingAcs.SearchAll(out sAndESettings, this._enterpriseCode);
            this._totalCount = sAndESettings.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SAndESetting sAndESetting in sAndESettings)
                        {
                            // オートバックス設定オブジェクトデータセット展開処理
                            SAndESettingToDataSet(sAndESetting.Clone(), index);
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
                            "PMSAE09010U",							// アセンブリID
                            "オートバックス設定",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._sAndESettingAcs,					    // エラーが発生したオブジェクト
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
        /// <br>Date		: 2009.07.30</br>
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
        /// <br>Date		: 2009.07.30</br>
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
            SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

            int status;

            // 企業コード設定情報論理削除処理
            status = this._sAndESettingAcs.LogicalDelete(ref sAndESetting);

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
                            "PMSAE09010U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._sAndESettingAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 企業コード設定情報クラスデータセット展開処理
            SAndESettingToDataSet(sAndESetting.Clone(), this.DataIndex);

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
        /// <br>Date		: 2009.07.30</br>
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
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {

            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先コード
            appearanceTable.Add(VIEW_CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 得意先略称
            appearanceTable.Add(VIEW_CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 納品先店舗コード
            appearanceTable.Add(VIEW_ADDRESSEESHOP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // S&E管理コード
            appearanceTable.Add(VIEW_SANDEMNG_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 経費区分
            appearanceTable.Add(VIEW_EXPENSEDIV_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 直送区分
            appearanceTable.Add(VIEW_DIRECTSENDING_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 受注区分
            appearanceTable.Add(VIEW_ACPTANORDERDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 納品者コード
            appearanceTable.Add(VIEW_DELIVERER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 納品者名
            appearanceTable.Add(VIEW_DELIVERER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 納品者住所
            appearanceTable.Add(VIEW_DELIVERERADDRESS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 納品者TEL
            appearanceTable.Add(VIEW_DELIVERERPHONENUM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部品商名
            appearanceTable.Add(VIEW_TRADCOMP_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部品商拠点名
            appearanceTable.Add(VIEW_TRADCOMPSECT_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部品商コード（純正）
            appearanceTable.Add(VIEW_PURETRADCOMP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部品商仕切率（純正）
            appearanceTable.Add(VIEW_PURETRADCOMPRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 部品商コード（優良）
            appearanceTable.Add(VIEW_PRITRADCOMP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 部品商仕切率（優良）
            appearanceTable.Add(VIEW_PRITRADCOMPRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 商品コード
            appearanceTable.Add(VIEW_ABGOODS_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // OEM区分
            appearanceTable.Add(VIEW_PARTSOEMDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 7行目コメント指定
            appearanceTable.Add(VIEW_COMMENTRESERVEDDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 純正対応メーカ１～１５
            appearanceTable.Add(VIEW_GOODSMAKER_CODE1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE11_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE12_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE13_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE14_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE15_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

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
        /// <br>Date       : 2009.07.30</br>
        /// </remarks>
        private void InitComboEditor()
        {
            tComboEditor_PartsOEMDiv.Items.Clear();
            tComboEditor_PartsOEMDiv.Items.Add(0, "印刷しない");
            tComboEditor_PartsOEMDiv.Items.Add(1, "印刷する");

            tComboEditor_CommentReservedDiv.Items.Clear();
            tComboEditor_CommentReservedDiv.Items.Add(0, "無し");
            tComboEditor_CommentReservedDiv.Items.Add(1, "備考");
            tComboEditor_CommentReservedDiv.Items.Add(2, "類別型式＋型式車種名");
            tComboEditor_CommentReservedDiv.Items.Add(3, "類別＋車種名＋備考");
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SAndESetting sAndESetting = new SAndESetting();


                //クローン作成
                this._sAndESettingClone = sAndESetting.Clone();

                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToSAndESetting(ref this._sAndESettingClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

                if (sAndESetting.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.tEdit_AddresseeShopCd.Focus();

                    // オートバックス設定マスタ情報クラス画面展開処理
                    SAndESettingToScreen(sAndESetting);

                    // クローン作成
                    this._sAndESettingClone = sAndESetting.Clone();

                    // 画面情報を比較用クローンにコピーします
                    ScreenToSAndESetting(ref this._sAndESettingClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();

                    // オートバックス設定マスタ情報クラス画面展開処理
                    SAndESettingToScreen(sAndESetting);

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
        /// <br>Date		: 2009.07.30</br>
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
                        this.tEdit_SectionCode.Enabled = true;
                        this.uButton_SectionGuide.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tEdit_AddresseeShopCd.Enabled = true;
                        this.tEdit_SAndEMngCode.Enabled = true;
                        this.tNedit_ExpenseDivCd.Enabled = true;
                        this.tNedit_DirectSendingCd.Enabled = true;
                        this.tNedit_AcptAnOrderDiv.Enabled = true;
                        this.tEdit_DelivererCd.Enabled = true;
                        this.tEdit_DelivererNm.Enabled = true;
                        this.tEdit_DelivererPhoneNum.Enabled = true;
                        this.tEdit_DelivererAddress.Enabled = true;
                        this.tEdit_TradCompName.Enabled = true;
                        this.tEdit_TradCompSectName.Enabled = true;
                        this.tEdit_PureTradCompCd.Enabled = true;
                        this.tNedit_PureTradCompRate.Enabled = true;
                        this.tEdit_PriTradCompCd.Enabled = true;
                        this.tNedit_PriTradCompRate.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                        this.tComboEditor_CommentReservedDiv.Enabled = true;
                        this.tComboEditor_PartsOEMDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd1.Enabled = true;
                        this.tNedit_GoodsMakerCd2.Enabled = true;
                        this.tNedit_GoodsMakerCd3.Enabled = true;
                        this.tNedit_GoodsMakerCd4.Enabled = true;
                        this.tNedit_GoodsMakerCd5.Enabled = true;
                        this.tNedit_GoodsMakerCd6.Enabled = true;
                        this.tNedit_GoodsMakerCd7.Enabled = true;
                        this.tNedit_GoodsMakerCd8.Enabled = true;
                        this.tNedit_GoodsMakerCd9.Enabled = true;
                        this.tNedit_GoodsMakerCd10.Enabled = true;
                        this.tNedit_GoodsMakerCd11.Enabled = true;
                        this.tNedit_GoodsMakerCd12.Enabled = true;
                        this.tNedit_GoodsMakerCd13.Enabled = true;
                        this.tNedit_GoodsMakerCd14.Enabled = true;
                        this.tNedit_GoodsMakerCd15.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;

                        // 画面初期化
                        ScreenClear();
                    }
                    else
                    {
                        // 更新モード
                        this.tEdit_SectionCode.Enabled = false;
                        this.uButton_SectionGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tEdit_AddresseeShopCd.Enabled = true;
                        this.tEdit_SAndEMngCode.Enabled = true;
                        this.tNedit_ExpenseDivCd.Enabled = true;
                        this.tNedit_DirectSendingCd.Enabled = true;
                        this.tNedit_AcptAnOrderDiv.Enabled = true;
                        this.tEdit_DelivererCd.Enabled = true;
                        this.tEdit_DelivererNm.Enabled = true;
                        this.tEdit_DelivererPhoneNum.Enabled = true;
                        this.tEdit_DelivererAddress.Enabled = true;
                        this.tEdit_TradCompName.Enabled = true;
                        this.tEdit_TradCompSectName.Enabled = true;
                        this.tEdit_PureTradCompCd.Enabled = true;
                        this.tNedit_PureTradCompRate.Enabled = true;
                        this.tEdit_PriTradCompCd.Enabled = true;
                        this.tNedit_PriTradCompRate.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                        this.tComboEditor_CommentReservedDiv.Enabled = true;
                        this.tComboEditor_PartsOEMDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd1.Enabled = true;
                        this.tNedit_GoodsMakerCd2.Enabled = true;
                        this.tNedit_GoodsMakerCd3.Enabled = true;
                        this.tNedit_GoodsMakerCd4.Enabled = true;
                        this.tNedit_GoodsMakerCd5.Enabled = true;
                        this.tNedit_GoodsMakerCd6.Enabled = true;
                        this.tNedit_GoodsMakerCd7.Enabled = true;
                        this.tNedit_GoodsMakerCd8.Enabled = true;
                        this.tNedit_GoodsMakerCd9.Enabled = true;
                        this.tNedit_GoodsMakerCd10.Enabled = true;
                        this.tNedit_GoodsMakerCd11.Enabled = true;
                        this.tNedit_GoodsMakerCd12.Enabled = true;
                        this.tNedit_GoodsMakerCd13.Enabled = true;
                        this.tNedit_GoodsMakerCd14.Enabled = true;
                        this.tNedit_GoodsMakerCd15.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;

                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tEdit_SectionCode.Enabled = false;
                    this.uButton_SectionGuide.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tEdit_AddresseeShopCd.Enabled = false;
                    this.tEdit_SAndEMngCode.Enabled = false;
                    this.tNedit_ExpenseDivCd.Enabled = false;
                    this.tNedit_DirectSendingCd.Enabled = false;
                    this.tNedit_AcptAnOrderDiv.Enabled = false;
                    this.tEdit_DelivererCd.Enabled = false;
                    this.tEdit_DelivererNm.Enabled = false;
                    this.tEdit_DelivererPhoneNum.Enabled = false;
                    this.tEdit_DelivererAddress.Enabled = false;
                    this.tEdit_TradCompName.Enabled = false;
                    this.tEdit_TradCompSectName.Enabled = false;
                    this.tEdit_PureTradCompCd.Enabled = false;
                    this.tNedit_PureTradCompRate.Enabled = false;
                    this.tEdit_PriTradCompCd.Enabled = false;
                    this.tNedit_PriTradCompRate.Enabled = false;
                    this.tEdit_ABGoodsCode.Enabled = false;
                    this.tComboEditor_CommentReservedDiv.Enabled = false;
                    this.tComboEditor_PartsOEMDiv.Enabled = false;
                    this.tNedit_GoodsMakerCd1.Enabled = false;
                    this.tNedit_GoodsMakerCd2.Enabled = false;
                    this.tNedit_GoodsMakerCd3.Enabled = false;
                    this.tNedit_GoodsMakerCd4.Enabled = false;
                    this.tNedit_GoodsMakerCd5.Enabled = false;
                    this.tNedit_GoodsMakerCd6.Enabled = false;
                    this.tNedit_GoodsMakerCd7.Enabled = false;
                    this.tNedit_GoodsMakerCd8.Enabled = false;
                    this.tNedit_GoodsMakerCd9.Enabled = false;
                    this.tNedit_GoodsMakerCd10.Enabled = false;
                    this.tNedit_GoodsMakerCd11.Enabled = false;
                    this.tNedit_GoodsMakerCd12.Enabled = false;
                    this.tNedit_GoodsMakerCd13.Enabled = false;
                    this.tNedit_GoodsMakerCd14.Enabled = false;
                    this.tNedit_GoodsMakerCd15.Enabled = false;
                    this.uButton_GoodsMakerGuid.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報オートバックス設定クラス格納処理
        /// </summary>
        /// <param name="sAndESetting">オートバックス設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からオートバックス設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.07.30</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void ScreenToSAndESetting(ref SAndESetting sAndESetting)
        {
            if (sAndESetting == null)
            {
                // 新規の場合
                sAndESetting = new SAndESetting();
            }

            //企業コード
            sAndESetting.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            sAndESetting.SectionCode = this.tEdit_SectionCode.DataText.PadLeft(2,'0');
            // 拠点名称
            sAndESetting.SectionName = this.tEdit_SectionName.DataText;
            // 得意先コード
            sAndESetting.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 得意先略称
            sAndESetting.CustomerName = this.tEdit_CustomerName.DataText;
            // 納品先店舗コード
            sAndESetting.AddresseeShopCd = this.tEdit_AddresseeShopCd.DataText.PadLeft(6,'0');
            // S&E管理コード
            sAndESetting.SAndEMngCode = this.tEdit_SAndEMngCode.DataText.PadLeft(6, '0');
            // 経費区分
            sAndESetting.ExpenseDivCd = this.tNedit_ExpenseDivCd.GetInt();
            // 直送区分
            sAndESetting.DirectSendingCd = this.tNedit_DirectSendingCd.GetInt();
            // 受注区分
            sAndESetting.AcptAnOrderDiv = this.tNedit_AcptAnOrderDiv.GetInt();
            // 納品者コード
            sAndESetting.DelivererCd = this.tEdit_DelivererCd.DataText.PadLeft(6, '0');
            // 納品者名
            sAndESetting.DelivererNm = this.tEdit_DelivererNm.DataText;
            // 納品者住所
            sAndESetting.DelivererAddress = this.tEdit_DelivererAddress.DataText;
            // 納品者TEL
            sAndESetting.DelivererPhoneNum = this.tEdit_DelivererPhoneNum.DataText;
            // 部品商名
            sAndESetting.TradCompName = this.tEdit_TradCompName.DataText;
            // 部品商拠点名
            sAndESetting.TradCompSectName = this.tEdit_TradCompSectName.DataText;
            // 部品商コード（純正）
            sAndESetting.PureTradCompCd = this.tEdit_PureTradCompCd.DataText.PadLeft(6, '0');
            // 部品商仕切率（純正）
            sAndESetting.PureTradCompRate = Convert.ToDouble(this.tNedit_PureTradCompRate.DataText);
            // 部品商コード（優良）
            sAndESetting.PriTradCompCd = this.tEdit_PriTradCompCd.DataText.PadLeft(6, '0');
            // 部品商仕切率（優良）
            sAndESetting.PriTradCompRate = Convert.ToDouble(this.tNedit_PriTradCompRate.DataText);
            // 商品コード
            //sAndESetting.ABGoodsCode = this.tEdit_ABGoodsCode.DataText.PadLeft(6, '0');// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            sAndESetting.ABGoodsCode = this.tEdit_ABGoodsCode.DataText.PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            // 7行目コメント指定
            sAndESetting.CommentReservedDiv = this.tComboEditor_CommentReservedDiv.SelectedIndex;
            // OEM区分
            sAndESetting.PartsOEMDiv = this.tComboEditor_PartsOEMDiv.SelectedIndex;
            // 純正対応メーカー１
            sAndESetting.GoodsMakerCd1 = this.tNedit_GoodsMakerCd1.GetInt();
            // 純正対応メーカー２
            sAndESetting.GoodsMakerCd2 = this.tNedit_GoodsMakerCd2.GetInt();
            // 純正対応メーカー３
            sAndESetting.GoodsMakerCd3 = this.tNedit_GoodsMakerCd3.GetInt();
            // 純正対応メーカー４
            sAndESetting.GoodsMakerCd4 = this.tNedit_GoodsMakerCd4.GetInt();
            // 純正対応メーカー５
            sAndESetting.GoodsMakerCd5 = this.tNedit_GoodsMakerCd5.GetInt();
            // 純正対応メーカー６
            sAndESetting.GoodsMakerCd6 = this.tNedit_GoodsMakerCd6.GetInt();
            // 純正対応メーカー７
            sAndESetting.GoodsMakerCd7 = this.tNedit_GoodsMakerCd7.GetInt();
            // 純正対応メーカー８
            sAndESetting.GoodsMakerCd8 = this.tNedit_GoodsMakerCd8.GetInt();
            // 純正対応メーカー９
            sAndESetting.GoodsMakerCd9 = this.tNedit_GoodsMakerCd9.GetInt();
            // 純正対応メーカー１０
            sAndESetting.GoodsMakerCd10 = this.tNedit_GoodsMakerCd10.GetInt();
            // 純正対応メーカー１１
            sAndESetting.GoodsMakerCd11 = this.tNedit_GoodsMakerCd11.GetInt();
            // 純正対応メーカー１２
            sAndESetting.GoodsMakerCd12 = this.tNedit_GoodsMakerCd12.GetInt();
            // 純正対応メーカー１３
            sAndESetting.GoodsMakerCd13 = this.tNedit_GoodsMakerCd13.GetInt();
            // 純正対応メーカー１４
            sAndESetting.GoodsMakerCd14 = this.tNedit_GoodsMakerCd14.GetInt();
            // 純正対応メーカー１５
            sAndESetting.GoodsMakerCd15 = this.tNedit_GoodsMakerCd15.GetInt();

        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
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
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
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
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : 拠点マスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void LoadSecInfoSet(bool flg)
        {
            if (flg == false && _secInfoSetDic != null)
            {
                return;
            }
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            _secInfoAcs.ResetSectionInfo();
            try
            {
                // 拠点情報の取得
                foreach (SecInfoSet set in _secInfoAcs.SecInfoSetList)
                {
                    if (set.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(set.SectionCode.Trim(), set);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : 得意先マスタ読込処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
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
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string str = "";
            // 取得拠点情報
            LoadSecInfoSet(false);
            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode))
                {
                    str = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                }
            }
            catch
            {
                str = "";
            }
            return str;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.07.30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
            allDefSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMER_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMER_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ADDRESSEESHOP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SANDEMNG_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_EXPENSEDIV_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DIRECTSENDING_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ACPTANORDERDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERER_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERER_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERERADDRESS_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERERPHONENUM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_TRADCOMP_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_TRADCOMPSECT_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PURETRADCOMP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PURETRADCOMPRATE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRITRADCOMP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRITRADCOMPRATE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ABGOODS_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PARTSOEMDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_COMMENTRESERVEDDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE1_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE2_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE3_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE4_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE5_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE6_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE7_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE8_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE9_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE10_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE11_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE12_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE13_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE14_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE15_TITLE, typeof(string));
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
        /// <br>Date	    : 2009.07.31</br>
        /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
        /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// <br>UpdateNote  : 2014/05/16 鹿庭 一郎</br>
        /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの初期値変更</br>
        /// <br>Date        : 2025/03/04 陳艶丹</br>
        /// <br>Update Note : PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 新規画面を戻る
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tEdit_CustomerName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_AddresseeShopCd.Clear();
            this.tEdit_SAndEMngCode.Clear();
            // --- ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------>>>>>
            SAndEConst sAndeSetting = new SAndEConst();
            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                sAndeSetting = UserSettingController.DeserializeUserSetting<SAndEConst>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                this.tNedit_ExpenseDivCd.SetInt(sAndeSetting.ExpenseDivCd);
                this.tNedit_DirectSendingCd.SetInt(sAndeSetting.DirectSendingCd);
                this.tNedit_AcptAnOrderDiv.SetInt(sAndeSetting.AcptAnOrderDiv);
                this.tEdit_DelivererCd.DataText = sAndeSetting.DelivererCd;
                this.tEdit_DelivererNm.DataText = sAndeSetting.DelivererNm;
                this.tEdit_DelivererPhoneNum.DataText = sAndeSetting.DelivererPhoneNum;
                this.tEdit_DelivererAddress.DataText = sAndeSetting.DelivererAddress;
                this.tNedit_PureTradCompRate.SetValue(sAndeSetting.PureTradCompRate);
                this.tNedit_PriTradCompRate.SetValue(sAndeSetting.PriTradCompRate);
                this.tEdit_ABGoodsCode.DataText = sAndeSetting.ABGoodsCode;
                this.tComboEditor_CommentReservedDiv.SelectedIndex = sAndeSetting.CommentReservedDiv;
                this.tComboEditor_PartsOEMDiv.SelectedIndex = sAndeSetting.PartsOEMDiv;
            }
            else 
            {
                this.tNedit_ExpenseDivCd.SetInt(1);
                this.tNedit_DirectSendingCd.SetInt(1);
                this.tNedit_AcptAnOrderDiv.SetInt(10);
                this.tEdit_DelivererCd.DataText = "913011";
                this.tEdit_DelivererNm.DataText = "（株）アドヴィックスセールス";
                this.tEdit_DelivererPhoneNum.DataText = "05030944299";
                this.tEdit_DelivererAddress.DataText = "愛知県刈谷市昭和町2-1";
                this.tNedit_PureTradCompRate.SetValue(98.0);
                this.tNedit_PriTradCompRate.SetValue(95.0);
                this.tEdit_ABGoodsCode.DataText = "00790322";
                this.tComboEditor_CommentReservedDiv.SelectedIndex = 0;
                this.tComboEditor_PartsOEMDiv.SelectedIndex = 0;
            }
            // --- ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------<<<<<
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------>>>>>
            //this.tNedit_ExpenseDivCd.SetInt(1);
            //this.tNedit_DirectSendingCd.SetInt(1);
            //this.tNedit_AcptAnOrderDiv.SetInt(10);
            //this.tEdit_DelivererCd.DataText = "913011";
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------<<<<<
            // --- UPD 金沢貞義 2018/07/20 Ｓ＆Ｅ企業名称変更 ---------->>>>>
            //this.tEdit_DelivererNm.DataText = "Ｓ＆Ｅブレーキ（株）";
            //this.tEdit_DelivererPhoneNum.DataText = "072-771-0591";
            //this.tEdit_DelivererAddress.DataText = "兵庫県伊丹市昆陽北１－１－１";
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------>>>>>
            //this.tEdit_DelivererNm.DataText = "（株）アドヴィックスセールス";
            //this.tEdit_DelivererPhoneNum.DataText = "03-3454-7640";
            //this.tEdit_DelivererAddress.DataText = "東京都港区三田３－１１－３４－９Ｆ";
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------<<<<<
            // --- UPD 金沢貞義 2018/07/20 Ｓ＆Ｅ企業名称変更 ----------<<<<<
            this.tEdit_TradCompName.Clear();
            this.tEdit_TradCompSectName.Clear();
            this.tEdit_PureTradCompCd.Clear();
            //this.tNedit_PureTradCompRate.SetValue(98.0);// DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応
            this.tEdit_PriTradCompCd.Clear();
            //this.tNedit_PriTradCompRate.SetValue(95.0); // DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応
            //this.tEdit_ABGoodsCode.DataText = "790304";// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            // --- UPD 鹿庭一郎 2014/05/16 ＡＢ商品コードの初期値変更 ---------->>>>>
            //this.tEdit_ABGoodsCode.DataText = "00790304";// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            //this.tEdit_ABGoodsCode.DataText = "00790322"; // DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応
            // --- UPD 鹿庭一郎 2014/05/16 ＡＢ商品コードの初期値変更 ----------<<<<<
            this.tNedit_GoodsMakerCd1.Clear();
            this.tNedit_GoodsMakerCd2.Clear();
            this.tNedit_GoodsMakerCd3.Clear();
            this.tNedit_GoodsMakerCd4.Clear();
            this.tNedit_GoodsMakerCd5.Clear();
            this.tNedit_GoodsMakerCd6.Clear();
            this.tNedit_GoodsMakerCd7.Clear();
            this.tNedit_GoodsMakerCd8.Clear();
            this.tNedit_GoodsMakerCd9.Clear();
            this.tNedit_GoodsMakerCd10.Clear();
            this.tNedit_GoodsMakerCd11.Clear();
            this.tNedit_GoodsMakerCd12.Clear();
            this.tNedit_GoodsMakerCd13.Clear();
            this.tNedit_GoodsMakerCd14.Clear();
            this.tNedit_GoodsMakerCd15.Clear();
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------>>>>>
            //this.tComboEditor_CommentReservedDiv.SelectedIndex = 0;
            //this.tComboEditor_PartsOEMDiv.SelectedIndex = 0;
            // --- DEL 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------<<<<<
            this._tmpSectionCode = string.Empty;
            this._tmpSectionName = string.Empty;
            this._tmpCustomerName = string.Empty;
            this._tmpCustomerCode = 0;
            this._prevMakerCode1 = 0;
            this._prevMakerCode2 = 0;
            this._prevMakerCode3 = 0;
            this._prevMakerCode4 = 0;
            this._prevMakerCode5 = 0;
            this._prevMakerCode6 = 0;
            this._prevMakerCode7 = 0;
            this._prevMakerCode8 = 0;
            this._prevMakerCode9 = 0;
            this._prevMakerCode10 = 0;
            this._prevMakerCode11 = 0;
            this._prevMakerCode12 = 0;
            this._prevMakerCode13 = 0;
            this._prevMakerCode14 = 0;
            this._prevMakerCode15 = 0;

            ScreenToSAndESetting( ref _sAndESettingInit);


        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オートバックス設定クラス画面展開処理
        /// </summary>
        /// <param name="sAndESetting">オートバックス設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オートバックス設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.07.31</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void SAndESettingToScreen(SAndESetting sAndESetting)
        {
            // 拠点コード
            this.tEdit_SectionCode.DataText = sAndESetting.SectionCode.Trim();
            // 拠点名称
            this.tEdit_SectionName.DataText = sAndESetting.SectionName.Trim();
            // 得意先コード
            this.tNedit_CustomerCode.SetInt(sAndESetting.CustomerCode);
            // 得意先略称
            this.tEdit_CustomerName.DataText = sAndESetting.CustomerName.Trim();
            // 納品先店舗コード
            this.tEdit_AddresseeShopCd.DataText = sAndESetting.AddresseeShopCd.Trim();
            // S&E管理コード
            this.tEdit_SAndEMngCode.DataText = sAndESetting.SAndEMngCode.Trim();
            // 経費区分
            this.tNedit_ExpenseDivCd.SetInt(sAndESetting.ExpenseDivCd);
            // 直送区分
            this.tNedit_DirectSendingCd.SetInt(sAndESetting.DirectSendingCd);
            // 受注区分
            this.tNedit_AcptAnOrderDiv.SetInt(sAndESetting.AcptAnOrderDiv);
            // 納品者コード
            this.tEdit_DelivererCd.DataText = sAndESetting.DelivererCd.Trim();
            // 納品者名
            this.tEdit_DelivererNm.DataText = sAndESetting.DelivererNm.Trim();
            // 納品者住所
            this.tEdit_DelivererAddress.DataText = sAndESetting.DelivererAddress.Trim();
            // 納品者TEL
            this.tEdit_DelivererPhoneNum.DataText = sAndESetting.DelivererPhoneNum.Trim();
            // 部品商名
            this.tEdit_TradCompName.DataText = sAndESetting.TradCompName.Trim();
            // 部品商拠点名
            this.tEdit_TradCompSectName.DataText = sAndESetting.TradCompSectName.Trim();
            // 部品商コード（純正）
            this.tEdit_PureTradCompCd.Text = sAndESetting.PureTradCompCd.Trim();
            // 部品商仕切率（純正）
            this.tNedit_PureTradCompRate.SetValue(sAndESetting.PureTradCompRate);
            // 部品商コード（優良）
            this.tEdit_PriTradCompCd.Text = sAndESetting.PriTradCompCd.Trim();
            // 部品商仕切率（優良）
            this.tNedit_PriTradCompRate.SetValue(sAndESetting.PriTradCompRate);
            // 商品コード
            //this.tEdit_ABGoodsCode.Text = sAndESetting.ABGoodsCode.Trim();// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            this.tEdit_ABGoodsCode.Text = sAndESetting.ABGoodsCode.Trim().PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            // 7行目コメント指定
            this.tComboEditor_CommentReservedDiv.SelectedIndex = sAndESetting.CommentReservedDiv;
            // OEM区分
            this.tComboEditor_PartsOEMDiv.SelectedIndex = sAndESetting.PartsOEMDiv;
            // 純正対応メーカー１
            this.tNedit_GoodsMakerCd1.SetInt(sAndESetting.GoodsMakerCd1);
            // 純正対応メーカー２
            this.tNedit_GoodsMakerCd2.SetInt(sAndESetting.GoodsMakerCd2);
            // 純正対応メーカー３
            this.tNedit_GoodsMakerCd3.SetInt(sAndESetting.GoodsMakerCd3);
            // 純正対応メーカー４
            this.tNedit_GoodsMakerCd4.SetInt(sAndESetting.GoodsMakerCd4);
            // 純正対応メーカー５
            this.tNedit_GoodsMakerCd5.SetInt(sAndESetting.GoodsMakerCd5);
            // 純正対応メーカー６
            this.tNedit_GoodsMakerCd6.SetInt(sAndESetting.GoodsMakerCd6);
            // 純正対応メーカー７
            this.tNedit_GoodsMakerCd7.SetInt(sAndESetting.GoodsMakerCd7);
            // 純正対応メーカー８
            this.tNedit_GoodsMakerCd8.SetInt(sAndESetting.GoodsMakerCd8);
            // 純正対応メーカー９
            this.tNedit_GoodsMakerCd9.SetInt(sAndESetting.GoodsMakerCd9);
            // 純正対応メーカー１０
            this.tNedit_GoodsMakerCd10.SetInt(sAndESetting.GoodsMakerCd10);
            // 純正対応メーカー１１
            this.tNedit_GoodsMakerCd11.SetInt(sAndESetting.GoodsMakerCd11);
            // 純正対応メーカー１２
            this.tNedit_GoodsMakerCd12.SetInt(sAndESetting.GoodsMakerCd12);
            // 純正対応メーカー１３
            this.tNedit_GoodsMakerCd13.SetInt(sAndESetting.GoodsMakerCd13);
            // 純正対応メーカー１４
            this.tNedit_GoodsMakerCd14.SetInt(sAndESetting.GoodsMakerCd14);
            // 純正対応メーカー１５
            this.tNedit_GoodsMakerCd15.SetInt(sAndESetting.GoodsMakerCd15);
            // 保存前回メーカー
            this._prevMakerCode1 = sAndESetting.GoodsMakerCd1;
            this._prevMakerCode2 = sAndESetting.GoodsMakerCd2;
            this._prevMakerCode3 = sAndESetting.GoodsMakerCd3;
            this._prevMakerCode4 = sAndESetting.GoodsMakerCd4;
            this._prevMakerCode5 = sAndESetting.GoodsMakerCd5;
            this._prevMakerCode6 = sAndESetting.GoodsMakerCd6;
            this._prevMakerCode7 = sAndESetting.GoodsMakerCd7;
            this._prevMakerCode8 = sAndESetting.GoodsMakerCd8;
            this._prevMakerCode9 = sAndESetting.GoodsMakerCd9;
            this._prevMakerCode10 = sAndESetting.GoodsMakerCd10;
            this._prevMakerCode11 = sAndESetting.GoodsMakerCd11;
            this._prevMakerCode12 = sAndESetting.GoodsMakerCd12;
            this._prevMakerCode13 = sAndESetting.GoodsMakerCd13;
            this._prevMakerCode14 = sAndESetting.GoodsMakerCd14;
            this._prevMakerCode15 = sAndESetting.GoodsMakerCd15;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	企業コード設定画面入力チェック処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note	   : 企業コード設定画面の入力チェックをします。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.07.31</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = string.Empty;
            try
            {
                // 拠点コード
                if (this.tEdit_SectionCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("拠点{0}", ct_NoInput);
                    tEdit_SectionCode.Focus();
                    status = false;
                }
                // 得意先コード
                else if (this.tNedit_CustomerCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("得意先{0}", ct_NoInput);
                    tNedit_CustomerCode.Focus();
                    status = false;
                }
                // 納品先店舗コード
                else if (this.tEdit_AddresseeShopCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("納品先店舗ｺｰﾄﾞ{0}", ct_NoInput);
                    tEdit_AddresseeShopCd.Focus();
                    status = false;
                }
                // S&E管理ｺｰﾄﾞ
                else if (this.tEdit_SAndEMngCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("S&E管理ｺｰﾄﾞ{0}", ct_NoInput);
                    tEdit_SAndEMngCode.Focus();
                    status = false;
                }
                // 納入者ｺｰﾄﾞ
                else if (this.tEdit_DelivererCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("納入者ｺｰﾄﾞ{0}", ct_NoInput);
                    tEdit_DelivererCd.Focus();
                    status = false;
                }
                // 部品商ｺｰﾄﾞ(純正)
                else if (this.tEdit_PureTradCompCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("部品商ｺｰﾄﾞ(純正){0}", ct_NoInput);
                    tEdit_PureTradCompCd.Focus();
                    status = false;
                }
                // 部品商ｺｰﾄﾞ(優良)
                else if (this.tEdit_PriTradCompCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("部品商ｺｰﾄﾞ(優良){0}", ct_NoInput);
                    tEdit_PriTradCompCd.Focus();
                    status = false;
                }
                // 商品ｺｰﾄﾞ
                else if (this.tEdit_ABGoodsCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("商品ｺｰﾄﾞ{0}", ct_NoInput);
                    tEdit_ABGoodsCode.Focus();
                    status = false;
                }
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMSAE09010U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }
            }
            return status;
        }

        /// <summary>
        ///	メーカーチェック処理
        /// </summary>
        /// <param name="flg">1～99が入力チェックflg</param>
        /// <returns>チェック状態</returns>
        /// <remarks>
        /// <br>Note	   : メーカーチェック処理をします。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.07.31</br>
        /// </remarks>
        private bool MakerInputCheck(ref bool flg)
        {
            ArrayList makerList = new ArrayList();

            // 入力したメーカー情報の保存
            makerList.Add(tNedit_GoodsMakerCd1.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd2.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd3.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd4.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd5.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd6.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd7.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd8.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd9.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd10.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd11.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd12.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd13.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd14.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd15.DataText.Trim());

            // 1～99が入力されたチェック
            for (int i = 0; i < MAKER_COUNT; i++)
            {
                if (string.IsNullOrEmpty(makerList[i].ToString().Trim()))
                {
                    continue;
                }
                else
                {
                    int maker = Convert.ToInt32(makerList[i].ToString().Trim());
                    if (maker.CompareTo(0) > 0 && maker.CompareTo(99) <= 0)
                    {
                        flg = false;
                        return (false);

                    }
                }
            }
            // メーカーコードが重複されている場合はエラー
            for (int i = 1; i <= MAKER_COUNT; i++)
            {
                string maker = makerList[i - 1].ToString();
                if (string.IsNullOrEmpty(maker))
                {
                    continue;
                }
                else
                {
                    for (int j = i+1; j < 16; j++)
                    {
                        string tempMaker = makerList[j - 1].ToString().PadLeft(4, '0');
                        if (maker.PadLeft(4, '0').Equals(tempMaker))
                        {
                            return (false);
                        }
                    }
                }
            }
            return true;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SaveSAndESetting())
        /// </summary>
        /// <returns>保存処理状態</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date	    : 2009.07.31</br>
        /// </remarks>
        private bool SaveSAndESetting()
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

            SAndESetting sAndESetting = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                sAndESetting = ((SAndESetting)this._sAndESettingTable[guid]).Clone();
            }

            ScreenToSAndESetting(ref sAndESetting);

            int status = this._sAndESettingAcs.Write(ref sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        this.tEdit_SectionCode.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        
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
                            "PMSAE09010U",							// アセンブリID
                            "オートバックス設定",  　　                 // プログラム名称
                            "SaveSAndESetting",                       // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._sAndESettingAcs,				    	// エラーが発生したオブジェクト
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

            SAndESettingToDataSet(sAndESetting, this.DataIndex);

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
        /// オートバックス設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="sAndESetting">オートバックス設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : オートバックス設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.07.30</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// </remarks>
        private void SAndESettingToDataSet(SAndESetting sAndESetting, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (sAndESetting.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = sAndESetting.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = sAndESetting.SectionCode;
            // 拠点名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sAndESetting.SectionName;
            //得意先コード
            if (sAndESetting.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = sAndESetting.CustomerCode.ToString("D8");
            }
            //得意先略称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = sAndESetting.CustomerName;
            // 納品先店舗コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADDRESSEESHOP_CODE_TITLE] = sAndESetting.AddresseeShopCd;
            // S&E管理コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SANDEMNG_CODE_TITLE] = sAndESetting.SAndEMngCode;
            //経費区分
            if (sAndESetting.ExpenseDivCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXPENSEDIV_CODE_TITLE] =string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXPENSEDIV_CODE_TITLE] = sAndESetting.ExpenseDivCd;
 
            }
            //直送区分
            if (sAndESetting.DirectSendingCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DIRECTSENDING_CODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DIRECTSENDING_CODE_TITLE] = sAndESetting.DirectSendingCd;

            }
            // 受注区分
            if (sAndESetting.AcptAnOrderDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANORDERDIV_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANORDERDIV_TITLE] = sAndESetting.AcptAnOrderDiv.ToString("D2");

            }
            // 納品者コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERER_CODE_TITLE] = sAndESetting.DelivererCd;
            // 納品者名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERER_NAME_TITLE] = sAndESetting.DelivererNm;
            // 納品者住所
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERERADDRESS_TITLE] = sAndESetting.DelivererAddress;
            // 納品者TEL
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERERPHONENUM_TITLE] = sAndESetting.DelivererPhoneNum;
            // 部品商名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TRADCOMP_NAME_TITLE] = sAndESetting.TradCompName;
            // 部品商拠点名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TRADCOMPSECT_NAME_TITLE] = sAndESetting.TradCompSectName;
            // 部品商コード（純正）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PURETRADCOMP_CODE_TITLE] = sAndESetting.PureTradCompCd;
            // 部品商仕切率（純正）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PURETRADCOMPRATE_TITLE] = sAndESetting.PureTradCompRate.ToString("F1");
            // 部品商コード（優良）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRITRADCOMP_CODE_TITLE] = sAndESetting.PriTradCompCd;
            // 部品商仕切率（優良）
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRITRADCOMPRATE_TITLE] = sAndESetting.PriTradCompRate.ToString("F1");
            // 商品コード
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODS_CODE_TITLE] = sAndESetting.ABGoodsCode;// DEL zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODS_CODE_TITLE] = sAndESetting.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 ＡＢ商品コードの桁数の改修

            // 7行目コメント指定
            if (sAndESetting.CommentReservedDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "無し";
            }
            else if (sAndESetting.CommentReservedDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "備考";
            }
            else if (sAndESetting.CommentReservedDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "類別型式＋型式車種名";
            }
            else if (sAndESetting.CommentReservedDiv == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "類別＋車種名＋備考";
            }

            // OEM区分
            if (sAndESetting.PartsOEMDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PARTSOEMDIV_TITLE] = "印刷しない";
            }
            else if (sAndESetting.PartsOEMDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PARTSOEMDIV_TITLE] = "印刷する";
            }
            // 純正対応メーカー１
            if (sAndESetting.GoodsMakerCd1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE1_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE1_TITLE] = sAndESetting.GoodsMakerCd1.ToString("D4");
            }
            // 純正対応メーカー２
            if (sAndESetting.GoodsMakerCd2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE2_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE2_TITLE] = sAndESetting.GoodsMakerCd2.ToString("D4");
            }
            // 純正対応メーカー３
            if (sAndESetting.GoodsMakerCd3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE3_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE3_TITLE] = sAndESetting.GoodsMakerCd3.ToString("D4");
            }
            // 純正対応メーカー４
            if (sAndESetting.GoodsMakerCd4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE4_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE4_TITLE] = sAndESetting.GoodsMakerCd4.ToString("D4");
            }
            // 純正対応メーカー５
            if (sAndESetting.GoodsMakerCd5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE5_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE5_TITLE] = sAndESetting.GoodsMakerCd5.ToString("D4");
            }
            // 純正対応メーカー６
            if (sAndESetting.GoodsMakerCd6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE6_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE6_TITLE] = sAndESetting.GoodsMakerCd6.ToString("D4");
            }
            // 純正対応メーカー７
            if (sAndESetting.GoodsMakerCd7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE7_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE7_TITLE] = sAndESetting.GoodsMakerCd7.ToString("D4");
            }
            // 純正対応メーカー８
            if (sAndESetting.GoodsMakerCd8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE8_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE8_TITLE] = sAndESetting.GoodsMakerCd8.ToString("D4");
            }
            // 純正対応メーカー９
            if (sAndESetting.GoodsMakerCd9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE9_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE9_TITLE] = sAndESetting.GoodsMakerCd9.ToString("D4");
            }
            // 純正対応メーカー１０
            if (sAndESetting.GoodsMakerCd10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE10_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE10_TITLE] = sAndESetting.GoodsMakerCd10.ToString("D4");
            }
            // 純正対応メーカー１１
            if (sAndESetting.GoodsMakerCd11 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE11_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE11_TITLE] = sAndESetting.GoodsMakerCd11.ToString("D4");
            } 
            // 純正対応メーカー１２
            if (sAndESetting.GoodsMakerCd12 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE12_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE12_TITLE] = sAndESetting.GoodsMakerCd12.ToString("D4");
            }
            // 純正対応メーカー１３
            if (sAndESetting.GoodsMakerCd13 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE13_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE13_TITLE] = sAndESetting.GoodsMakerCd13.ToString("D4");
            }
            // 純正対応メーカー１４
            if (sAndESetting.GoodsMakerCd14 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE14_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE14_TITLE] = sAndESetting.GoodsMakerCd14.ToString("D4");
            } 
            // 純正対応メーカー１５
            if (sAndESetting.GoodsMakerCd15 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE15_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE15_TITLE] = sAndESetting.GoodsMakerCd15.ToString("D4");
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sAndESetting.FileHeaderGuid;

            if (this._sAndESettingTable.ContainsKey(sAndESetting.FileHeaderGuid) == true)
            {
                this._sAndESettingTable.Remove(sAndESetting.FileHeaderGuid);
            }
            this._sAndESettingTable.Add(sAndESetting.FileHeaderGuid, sAndESetting);
        }

        /// <summary>
        /// 同一データのメッセージ
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 既に拠点管理設定マスタに同一データある場合、メッセージがある。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date	    : 2009.07.30</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "PMSAE09010U",						// アセンブリＩＤまたはクラスＩＤ
                "このコードが既に存在しています。", // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            tEdit_SectionCode.Focus();

            control = tEdit_SectionCode;
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMSAE09010U",							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /// <summary>
        /// 入力されたコードのオートバックス設定マスタ情報の存在チェック処理
        /// </summary>
        /// <returns>存在の判断</returns>
        /// <remarks>
        /// <br>Note       : 入力されたコードのオートバックス設定マスタ情報の存在チェック処理します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "入力されたコードのオートバックス設定マスタ情報が既に登録されています。\n編集を行いますか？";
            string currSectionCode = this.tEdit_SectionCode.DataText;
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            if (string.IsNullOrEmpty(currSectionCode) || currCustomerCode == 0)
            {
                return true;
            }
            // 新規モードかつ拠点と得意先の入力内容がオートバックス設定マスタに存在チェック処理
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string sectionCode = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE].ToString().Trim();
                string customerCode = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMER_CODE_TITLE].ToString().Trim();
                if (string.IsNullOrEmpty(sectionCode) || string.IsNullOrEmpty(customerCode))
                {
                    continue;
                }

                int intCustomerCode = Int32.Parse(customerCode);
                // オートバックス設定マスタに存在する場合
                if (currSectionCode.Equals(sectionCode) && currCustomerCode == intCustomerCode)
                {
                    // 選択したのデータは削除した場合
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", "入力されたコードのオートバックス設定マスタ情報は既に削除されています。", 0, MessageBoxButtons.OK);
                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        _tmpSectionCode = string.Empty;
                        _tmpCustomerCode = 0;
                        _tmpCustomerName = string.Empty;
                        _tmpSectionName = string.Empty;
                        return false;
                    }
                    // 選択したのデータは削除しない場合
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            // this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                            this.tNedit_CustomerCode.Clear();
                            this.tEdit_CustomerName.Clear();
                            _tmpSectionCode = string.Empty;
                            _tmpCustomerCode = 0;
                            _tmpCustomerName = string.Empty;
                            _tmpSectionName = string.Empty;
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 数字を判断処理
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>判断結果</returns>
        /// <remarks>
        /// <br>Note		: 数字を判断処理を行い</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool NumberCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        /// <summary>
        /// 全角を判断処理
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>判断結果</returns>
        /// <remarks>
        /// <br>Note		: 全角を判断処理を行い</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool FullCheck(string str)
        {
            bool isFull = true;
            if (str.Length < 0)
            {
                return true;
            }
            for (int i = 0; i < str.Length; i++)
            {
                String cutStr = str.Substring(i, 1);
                // 全角ではない場合
                if (ASCIIEncoding.Default.GetByteCount(cutStr) != 2)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        /// <summary>
        /// TELを判断処理
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>判断結果</returns>
        /// <remarks>
        /// <br>Note		: TELを判断処理を行い</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool TelCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([0-9]|[-])*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        /// <summary>
        /// メーカー存在チェック処理
        /// </summary>
        /// <param name="prev">prev</param>
        /// <param name="tNedit_GoodsMakerCd">当用tNedit</param>
        /// <param name="next">next</param>
        /// <param name="prevMakerCode">保存した当用tNedit値</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : メーカー存在チェック処理を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void CheckExistMaker(Object prev, TNedit tNedit_GoodsMakerCd, Object next, ref int prevMakerCode, ChangeFocusEventArgs e)
        {
            TNedit nextGoodsMakerCd;
            UltraButton button;
            TComboEditor tComboEditor;

            if (tNedit_GoodsMakerCd.GetInt() == 0)
            {
                prevMakerCode = 0;
                tNedit_GoodsMakerCd.DataText = string.Empty;
                return;

            }

            // メーカー取得
            int makerCode = tNedit_GoodsMakerCd.GetInt();

            // メーカーコードマスタの検索
            if (this._makerUMntDic == null)
            {
                // メーカーマスタ読込処理
                LoadMakerUMnt(false);
            }
            // メーカーコードマスタチェックOKの場合
            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                bool status = true;
                // 1～99入力チェックと重複チェック
                this.tNedit_GoodsMakerCd1_Leave(tNedit_GoodsMakerCd, out status);
                // 1～99入力チェックと重複チェックNG場合
                if (status == false)
                {
                    this.flg = false;
                    e.NextCtrl = e.PrevCtrl;
                }
                // 1～99入力チェックと重複チェックOK場合
                else
                {
                    this.flg = true;
                    if (e.ShiftKey == false)
                    {
                        //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down) // DEL 2009/09/04 WUYX PVCS422
                        if (e.Key == Keys.Return || e.Key == Keys.Tab) // ADD 2009/09/04 WUYX PVCS422
                        {
                            if (next is TNedit)
                            {
                                nextGoodsMakerCd = next as TNedit;
                                e.NextCtrl = nextGoodsMakerCd;
                            }
                            else if (next is UltraButton)
                            {
                                button = next as UltraButton;
                                e.NextCtrl = button;
                            }

                        }
                    }
                    // [Shift+Tab]の場合
                    else if (e.ShiftKey == true)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (prev is TNedit)
                            {
                                nextGoodsMakerCd = prev as TNedit;
                                e.NextCtrl = nextGoodsMakerCd;
                            }
                            else if (prev is TComboEditor)
                            {
                                tComboEditor = prev as TComboEditor;
                                e.NextCtrl = tComboEditor;
                            }
                        }
                    }
                }
            }
            else
            {
                // 前回入力値を設定
                tNedit_GoodsMakerCd.SetInt(prevMakerCode);
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                    "PMSAE09010U",							// アセンブリID
                    "メーカーが存在しません。",	                // 表示するメッセージ
                    0,									    // ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン

                e.NextCtrl = e.PrevCtrl;
                this.flg = false;

            }
        }

        /// <summary>
        /// メーカーガイド選択した後設定メーカー値処理
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">当用tNedit</param>
        /// <param name="next">NEXT</param>
        /// <param name="prevMakerCode">保存した当用tNedit値</param>
        /// <param name="makerUMnt">makerUMnt</param>
        /// <remarks> 
        /// <br>Note       : メーカーガイド選択した後設定メーカー値処理を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void SetGoodsMakerValue(TNedit tNedit_GoodsMakerCd, Object next, ref int prevMakerCode, MakerUMnt makerUMnt)
        {

            TNedit nextGoodsMakerCd;
            UltraButton button;

            string checkMessage = string.Empty;
            bool flg = true;

            tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            // 1～99が入力されたチェックとメーカーコードが重複されている場合チェック
            if (!MakerInputCheck(ref flg))
            {
                // 前回メーカーの取得
                tNedit_GoodsMakerCd.SetInt(prevMakerCode);
                if (flg == false)
                {
                    checkMessage = string.Format("純正メーカー{0}", ct_SetError);
                }
                else
                {
                    checkMessage = string.Format("メーカー{0}", ct_DupliInput);
                }
                tNedit_GoodsMakerCd.Focus();
            }
            else
            {
                // 保存入力したメーカー１
                prevMakerCode = makerUMnt.GoodsMakerCd;
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                if (next is TNedit)
                {
                    nextGoodsMakerCd = next as TNedit;
                    nextGoodsMakerCd.Focus();
                }
                else if (next is UltraButton)
                {
                    button = next as UltraButton;
                    button.Focus();
                }
            }

            if (checkMessage.Length > 0)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMSAE09010U",							// アセンブリID
                    checkMessage,	                        // 表示するメッセージ
                    0,									    // ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }

        }

        /// <summary>
        /// エラー発生時再設定メーカー値処理
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">当用tNedit</param>
        /// <remarks> 
        /// <br>Note       : エラー発生時再設定メーカー値処理を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void ResetGoodsMaker(TNedit tNedit_GoodsMakerCd)
        {
            // メーカー１
            if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd1)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode1);
            }
            // メーカー２
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd2)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode2);
            }
            // メーカー３
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd3)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode3);
            }
            // メーカー４
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd4)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode4);
            }
            // メーカー５
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd5)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode5);
            }
            // メーカー６
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd6)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode6);
            }
            // メーカー７
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd7)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode7);
            }
            // メーカー８
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd8)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode8);
            }
            // メーカー９
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd9)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode9);
            }
            // メーカー１０
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd10)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode10);
            }
            // メーカー１１
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd11)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode11);
            }
            // メーカー１２
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd12)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode12);
            }
            // メーカー１３
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd13)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode13);
            }
            // メーカー１４
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd14)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode14);
            }
            // メーカー１５
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd15)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode15);
            }
        }

        /// <summary>
        /// 今回メーカー値保存処理
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">当用tNedit</param>
        /// <remarks> 
        /// <br>Note       : 今回メーカー値保存処理を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void SaveGoodsMaker(TNedit tNedit_GoodsMakerCd)
        {
            // メーカー１
            if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd1)
            {
                this._prevMakerCode1 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー２
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd2)
            {
                this._prevMakerCode2 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー３
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd3)
            {
                this._prevMakerCode3 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー４
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd4)
            {
                this._prevMakerCode4 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー５
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd5)
            {
                this._prevMakerCode5 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー６
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd6)
            {
                this._prevMakerCode6 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー７
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd7)
            {
                this._prevMakerCode7 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー８
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd8)
            {
                this._prevMakerCode8 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー９
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd9)
            {
                this._prevMakerCode9 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１０
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd10)
            {
                this._prevMakerCode10 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１１
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd11)
            {
                this._prevMakerCode11 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１２
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd12)
            {
                this._prevMakerCode12 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１３
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd13)
            {
                this._prevMakerCode13 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１４
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd14)
            {
                this._prevMakerCode14 = tNedit_GoodsMakerCd.GetInt();
            }
            // メーカー１５
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd15)
            {
                this._prevMakerCode15 = tNedit_GoodsMakerCd.GetInt();
            }
        }

        /// <summary>
        /// 画面フォーカス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面フォーカス取得を行う</br> 
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void GetCurrentFocus()
        {
            // 画面フォーカス判断、画面フォーカスを取得する
            if (this.tEdit_SectionCode.Focused)
            {
                // 拠点
                this._preControl = this.tEdit_SectionCode;
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                // 得意先
                this._preControl = this.tNedit_CustomerCode;
            }
            else if (this.tNedit_GoodsMakerCd1.Focused)
            {
                // メーカー１
                this._preControl = this.tNedit_GoodsMakerCd1;
            }
            else if (this.tNedit_GoodsMakerCd2.Focused)
            {
                // メーカー２
                this._preControl = this.tNedit_GoodsMakerCd2;
            }
            else if (this.tNedit_GoodsMakerCd3.Focused)
            {
                // メーカー３
                this._preControl = this.tNedit_GoodsMakerCd3;
            }
            else if (this.tNedit_GoodsMakerCd4.Focused)
            {
                // メーカー４
                this._preControl = this.tNedit_GoodsMakerCd4;
            }
            else if (this.tNedit_GoodsMakerCd5.Focused)
            {
                // メーカー５
                this._preControl = this.tNedit_GoodsMakerCd5;
            }
            else if (this.tNedit_GoodsMakerCd6.Focused)
            {
                // メーカー６
                this._preControl = this.tNedit_GoodsMakerCd6;
            }
            else if (this.tNedit_GoodsMakerCd7.Focused)
            {
                // メーカー７
                this._preControl = this.tNedit_GoodsMakerCd7;
            }
            else if (this.tNedit_GoodsMakerCd8.Focused)
            {
                // メーカー８
                this._preControl = this.tNedit_GoodsMakerCd8;
            }
            else if (this.tNedit_GoodsMakerCd9.Focused)
            {
                // メーカー９
                this._preControl = this.tNedit_GoodsMakerCd9;
            }
            else if (this.tNedit_GoodsMakerCd10.Focused)
            {
                // メーカー１０
                this._preControl = this.tNedit_GoodsMakerCd10;
            }
            else if (this.tNedit_GoodsMakerCd11.Focused)
            {
                // メーカー１１
                this._preControl = this.tNedit_GoodsMakerCd11;
            }
            else if (this.tNedit_GoodsMakerCd12.Focused)
            {
                // メーカー１２
                this._preControl = this.tNedit_GoodsMakerCd12;
            }
            else if (this.tNedit_GoodsMakerCd13.Focused)
            {
                // メーカー１３
                this._preControl = this.tNedit_GoodsMakerCd13;
            }
            else if (this.tNedit_GoodsMakerCd14.Focused)
            {
                // メーカー１４
                this._preControl = this.tNedit_GoodsMakerCd14;
            }
            else if (this.tNedit_GoodsMakerCd15.Focused)
            {
                // メーカー１５
                this._preControl = this.tNedit_GoodsMakerCd15;
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_SectionGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        ///	Form.Closing イベント(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged イベント(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Date        : 2009.08.03</br>
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

            if (!SaveSAndESetting())
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
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SAndESetting compareSAndESetting = new SAndESetting();

                compareSAndESetting = this._sAndESettingClone.Clone();
                ScreenToSAndESetting(ref compareSAndESetting);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (!(this._sAndESettingClone.Equals(compareSAndESetting) || this._sAndESettingInit.Equals(compareSAndESetting)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        "PMSAE09010U", 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSAndESetting())
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
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                    // 設定値を保存
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    this._tmpSectionName = secInfoSet.SectionGuideNm.Trim();
                    if (this.ModeChangeProc())
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
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
                "PMSAE09010U",						// アセンブリＩＤまたはクラスＩＤ
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
            SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

            // 拠点情報論理削除処理
            int status = this._sAndESettingAcs.Delete(sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._sAndESettingTable.Remove(sAndESetting.FileHeaderGuid);

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
                            "PMSAE09010U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._sAndESettingAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Date       : 2009.08.03</br>
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
                "PMSAE09010U",						// アセンブリＩＤまたはクラスＩＤ
                "現在表示中のオートバックス設定マスタを復活します。" + "\r\n" +
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
            SAndESetting sAndESetting = ((SAndESetting)this._sAndESettingTable[guid]).Clone();

            // 復活
            status = this._sAndESettingAcs.Revival(ref sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        SAndESettingToDataSet(sAndESetting, this._dataIndex);
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
                            "PMSAE09010U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._sAndESettingAcs,				// エラーが発生したオブジェクト
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
        /// <br>Date       : 2009.07.31</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            LoadMakerUMnt(true);
            LoadSecInfoSet(true);
            LoadCustomerSearchRet(true);
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", "最新情報を取得しました。", 0, MessageBoxButtons.OK);

        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks> 
        /// <br>Note       : メーカーガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.07.31</br> 
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
                    // メーカー1
                    if (this.tNedit_GoodsMakerCd1.GetInt() == 0)
                    {

                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, ref this._prevMakerCode1, makerUMnt);

                    }
                    // メーカー2
                    else if (this.tNedit_GoodsMakerCd2.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, ref this._prevMakerCode2, makerUMnt);
                    }
                    // メーカー3
                    else if (this.tNedit_GoodsMakerCd3.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, ref this._prevMakerCode3, makerUMnt);
                    }
                    // メーカー4
                    else if (this.tNedit_GoodsMakerCd4.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, ref this._prevMakerCode4, makerUMnt);
                    }
                    // メーカー5
                    else if (this.tNedit_GoodsMakerCd5.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, ref this._prevMakerCode5, makerUMnt);
                    }
                    // メーカー6
                    else if (this.tNedit_GoodsMakerCd6.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, ref this._prevMakerCode6, makerUMnt);
                    }
                    // メーカー7
                    else if (this.tNedit_GoodsMakerCd7.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, ref this._prevMakerCode7, makerUMnt);

                    }
                    // メーカー8
                    else if (this.tNedit_GoodsMakerCd8.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, ref this._prevMakerCode8, makerUMnt);

                    }

                    // メーカー9
                    else if (this.tNedit_GoodsMakerCd9.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, ref this._prevMakerCode9, makerUMnt);

                    }
                    // メーカー10
                    else if (this.tNedit_GoodsMakerCd10.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, ref this._prevMakerCode10, makerUMnt);

                    }
                    // メーカー11
                    else if (this.tNedit_GoodsMakerCd11.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, ref this._prevMakerCode11, makerUMnt);
                    }
                    // メーカー12
                    else if (this.tNedit_GoodsMakerCd12.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, ref this._prevMakerCode12, makerUMnt);

                    }
                    // メーカー13
                    else if (this.tNedit_GoodsMakerCd13.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, ref this._prevMakerCode13, makerUMnt);

                    }
                    // メーカー14
                    else if (this.tNedit_GoodsMakerCd14.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, ref this._prevMakerCode14, makerUMnt);

                    }
                    // メーカー15
                    else
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd15, this.Renewal_Button, ref this._prevMakerCode15, makerUMnt);
                    }
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
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (this.ModeChangeProc())
                {
                    this.tEdit_AddresseeShopCd.Focus();
                }
                else
                {
                    this.tEdit_SectionCode.Focus();
                }
            }

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : 得意先ガイドをクリックするときに発生する</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.07.31</br> 
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
                this._tmpCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._tmpCustomerName = this.tEdit_CustomerName.DataText;
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus イベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.07.31</br> 
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
                // 拠点コード
                case "tEdit_SectionCode":
                    {
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.Trim()))
                        {
                            _tmpSectionCode = string.Empty;
                            _tmpSectionName = string.Empty;
                            this.tEdit_SectionName.DataText = string.Empty;

                            break;
                        }

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        // 拠点名称取得
                        string sectionName = GetSectionName(sectionCode);
                        if (!string.IsNullOrEmpty(sectionName))
                        {
                            // 結果を画面に設定
                            this.tEdit_SectionCode.Text = sectionCode;
                            this.tEdit_SectionName.DataText = sectionName;

                            // 設定値を保存
                            this._tmpSectionCode = sectionCode;
                            this._tmpSectionName = sectionName;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_SectionCode.Text = this._tmpSectionCode;
                            this.tEdit_SectionName.DataText = this._tmpSectionName;
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMSAE09010U",							// アセンブリID
                                "拠点が存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }
                        if (ModeChangeProc())
                        {
                            if (e.ShiftKey == false)
                            {
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)  // DEL 2009/09/04 WUYX PVCS422
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)  // ADD 2009/09/04 WUYX PVCS422
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                            // [Shift+Tab]
                            else if (e.ShiftKey == true)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.Cancel_Button;
                                }
                            }
                        }
                        else
                        {
                            // --- DEL 2009/09/04 WUYX PVCS422 ----->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            //{
                            //    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //    e.NextCtrl = this.tEdit_SectionCode;
                            //    this.tEdit_SectionCode.Focus();
                            //    this.flg = false;
                            //}
                            // --- DEL 2009/09/04 WUYX PVCS422 -----<<<<<

                            // --- ADD 2009/09/04 WUYX PVCS422 ----->>>>>
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                            this.flg = false;
                            // --- ADD 2009/09/04 WUYX PVCS422 -----<<<<<
                        }
                        break;
                    }
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        // 入力無し
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            _tmpCustomerCode = 0;
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
                            this._tmpCustomerCode = customerCode;
                            this._tmpCustomerName = customerName;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_CustomerCode.SetInt(_tmpCustomerCode);
                            this.tEdit_CustomerName.DataText = _tmpCustomerName;

                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                "PMSAE09010U",							// アセンブリID
                                "得意先が存在しません。",	                // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }
                        if (ModeChangeProc())
                        {
                            if (e.ShiftKey == false)
                            {
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)  // DEL 2009/09/04 WUYX PVCS422
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)  // ADD 2009/09/04 WUYX PVCS422
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_AddresseeShopCd;
                                }
                            }
                            // [Shift+Tab]
                            else if (e.ShiftKey == true)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        else
                        {
                            // --- DEL 2009/09/04 WUYX PVCS422 ----->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            //{
                            //    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //    e.NextCtrl = this.tEdit_SectionCode;
                            //    this.tEdit_SectionCode.Focus();
                            //    this.flg = false;
                            //}
                            // --- DEL 2009/09/04 WUYX PVCS422 -----<<<<<

                            // --- ADD 2009/09/04 WUYX PVCS422 ----->>>>>
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                            this.flg = false;
                            // --- ADD 2009/09/04 WUYX PVCS422 -----<<<<<

                        }
                        break;
                    }
                // 納品先店舗コード
                case "tEdit_AddresseeShopCd":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_AddresseeShopCd.Text))
                        {
                            this.tEdit_AddresseeShopCd.Text = string.Empty;
                        }
                        break;
                    }
                // S&E管理コード
                case "tEdit_SAndEMngCode":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_SAndEMngCode.Text))
                        {
                            this.tEdit_SAndEMngCode.Text = string.Empty;
                        }
                        break;
                    }
                // 経費区分
                case "tNedit_ExpenseDivCd":
                    {
                        // コピーした文字チェック
                        if (this.tNedit_ExpenseDivCd.GetInt() == 0)
                        {
                            this.tNedit_ExpenseDivCd.DataText = string.Empty;
                        }
                        break;
                    }
                // 直送区分
                case "tNedit_DirectSendingCd":
                    {
                        // コピーした文字チェック
                        if (this.tNedit_DirectSendingCd.GetInt() == 0)
                        {
                            this.tNedit_DirectSendingCd.DataText = string.Empty;
                        }
                        break;
                    }
                // 受注区分
                case "tNedit_AcptAnOrderDiv":
                    {
                        // コピーした文字チェック
                        if (this.tNedit_AcptAnOrderDiv.GetInt() == 0)
                        {
                            this.tNedit_AcptAnOrderDiv.DataText = string.Empty;
                        }
                        break;
                    }
                // 納入者コード
                case "tEdit_DelivererCd":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_DelivererCd.Text))
                        {
                            this.tEdit_DelivererCd.Text = string.Empty;
                        }
                        break;
                    }
                // 納入者名
                case "tEdit_DelivererNm":
                    {
                        // コピーした文字チェック
                        if (!FullCheck(this.tEdit_DelivererNm.Text))
                        {
                            this.tEdit_DelivererNm.Text = string.Empty;
                        }
                        break;
                    }
                // 納入者住所
                case "tEdit_DelivererAddress":
                    {
                        // コピーした文字チェック
                        if (!FullCheck(this.tEdit_DelivererAddress.Text))
                        {
                            this.tEdit_DelivererAddress.Text = string.Empty;
                        }
                        break;
                    }
                // 納入者TEL
                case "tEdit_DelivererPhoneNum":
                    {
                        // コピーした文字チェック
                        if (!TelCheck(this.tEdit_DelivererPhoneNum.Text))
                        {
                            this.tEdit_DelivererPhoneNum.Text = string.Empty;
                        }
                        break;
                    }
                // 部品商名
                case "tEdit_TradCompName":
                    {
                        // コピーした文字チェック
                        if (!FullCheck(this.tEdit_TradCompName.Text))
                        {
                            this.tEdit_TradCompName.Text = string.Empty;
                        }
                        break;
                    }
                // 部品商コード(純正)
                case "tEdit_PureTradCompCd":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_PureTradCompCd.Text))
                        {
                            this.tEdit_PureTradCompCd.Text = string.Empty;
                        }
                        break;
                    }
                // 部品商仕切率(純正)
                case "tNedit_PureTradCompRate":
                    {
                        // コピーした文字チェック
                        try
                        {
                            Double value = 0;
                            value = Convert.ToDouble(this.tNedit_PureTradCompRate.DataText);
                        }
                        catch
                        {
                            tNedit_PureTradCompRate.DataText = "0.0";
                        }
                        break;
                    }
                // 部品商コード(優良)
                case "tEdit_PriTradCompCd":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_PriTradCompCd.Text))
                        {
                            this.tEdit_PriTradCompCd.Text = string.Empty;
                        }
                        break;
                    }
                // 部品商仕切率(優良)
                case "tNedit_PriTradCompRate":
                    {
                        // コピーした文字チェック
                        try
                        {
                            Double value = 0;
                            value = Convert.ToDouble(this.tNedit_PriTradCompRate.DataText);
                        }
                        catch
                        {
                            tNedit_PriTradCompRate.DataText = "0.0";
                        }
                        break;
                    }
                // 商品コード
                case "tEdit_ABGoodsCode":
                    {
                        // コピーした文字チェック
                        if (!NumberCheck(this.tEdit_ABGoodsCode.Text))
                        {
                            this.tEdit_ABGoodsCode.Text = string.Empty;
                        }
                        break;
                    }
                // メーカーコード1
                case "tNedit_GoodsMakerCd1":
                    {
                        CheckExistMaker(this.tComboEditor_CommentReservedDiv, this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, ref this._prevMakerCode1, e);
                        break;
                    }
                // メーカーコード2
                case "tNedit_GoodsMakerCd2":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, ref this._prevMakerCode2, e);
                        break;
                    }
                // メーカーコード3
                case "tNedit_GoodsMakerCd3":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, ref this._prevMakerCode3, e);
                        break;
                    }
                // メーカーコード4
                case "tNedit_GoodsMakerCd4":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, ref this._prevMakerCode4, e);
                        break;
                    }
                // メーカーコード5
                case "tNedit_GoodsMakerCd5":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, ref this._prevMakerCode5, e);
                        break;
                    }
                // メーカーコード6
                case "tNedit_GoodsMakerCd6":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, ref this._prevMakerCode6, e);
                        break;
                    }
                // メーカーコード7
                case "tNedit_GoodsMakerCd7":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, ref this._prevMakerCode7, e);
                        break;
                    }
                // メーカーコード8
                case "tNedit_GoodsMakerCd8":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, ref this._prevMakerCode8, e);
                        break;
                    }
                // メーカーコード9
                case "tNedit_GoodsMakerCd9":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, ref this._prevMakerCode9, e);
                        break;
                    }
                // メーカーコード10
                case "tNedit_GoodsMakerCd10":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, ref this._prevMakerCode10, e);
                        break;
                    }
                // メーカーコード11
                case "tNedit_GoodsMakerCd11":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, ref this._prevMakerCode11, e);
                        break;
                    }
                // メーカーコード12
                case "tNedit_GoodsMakerCd12":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, ref this._prevMakerCode12, e);
                        break;
                    }
                // メーカーコード13
                case "tNedit_GoodsMakerCd13":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, ref this._prevMakerCode13, e);
                        break;
                    }
                // メーカーコード14
                case "tNedit_GoodsMakerCd14":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, ref this._prevMakerCode14, e);
                        break;
                    }
                // メーカーコード15
                case "tNedit_GoodsMakerCd15":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, this.Renewal_Button, ref this._prevMakerCode15, e);
                        break;
                    }
            }
        }

        /// <summary>
        /// tNedit_GoodsMakerCd1_Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="status">status</param>
        /// <returns>status</returns>
        /// <remarks> 
        /// <br>Note       : tNedit_GoodsMakerCd1_Leaveイベントを行う</br> 
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private bool tNedit_GoodsMakerCd1_Leave(object sender, out bool status)
        {
            status = true;
            // エラー
            string checkMessage = string.Empty;
            bool flg = true;
            TNedit currentTNedit = (TNedit)sender;
            try
            {
                if (!MakerInputCheck(ref flg))
                {
                    if (flg == false)
                    {
                        checkMessage = string.Format("純正メーカー{0}", ct_SetError);
                        status = false;
                    }
                    else
                    {
                        checkMessage = string.Format("メーカー{0}", ct_DupliInput);
                        status = false;
                    }
                }
                else
                {
                    status = true;
                }

                return status;
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    // 前回メーカー値を戻る
                    ResetGoodsMaker(currentTNedit);
                    currentTNedit.Focus();
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMSAE09010U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }
                else
                {
                    // 今回メーカー値を保存する
                    SaveGoodsMaker(currentTNedit);
                }
            }
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
        /// <br>Date       : 2009.08.03</br>
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
        /// <br>Date       : 2009.08.03</br>
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
    // --- ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------>>>>>
    [Serializable]
    /// <summary>
    /// SAndEConst
    /// </summary>
    /// <remarks>
    /// <br>Date         : 2025/03/04</br>
    /// <br>Update Note  : PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応</br>
    /// <br>Programmer   : 陳艶丹</br>
    /// </remarks>
    public struct SAndEConst
    { 
        /// <summary>経費区分</summary>
		private Int32 _expenseDivCd;

		/// <summary>直送区分</summary>
		private Int32 _directSendingCd;

		/// <summary>受注区分</summary>
		private Int32 _acptAnOrderDiv;

		/// <summary>納品者コード</summary>
        private string _delivererCd;

		/// <summary>納品者名</summary>
        private string _delivererNm;

		/// <summary>納品者住所</summary>
        private string _delivererAddress;

		/// <summary>納品者ＴＥＬ</summary>
        private string _delivererPhoneNum;

		/// <summary>部品商仕切率（純正）</summary>
		private Double _pureTradCompRate;

		/// <summary>部品商仕切率（優良）</summary>
		private Double _priTradCompRate;

		/// <summary>AB商品コード</summary>
        private string _aBGoodsCode;

		/// <summary>コメント指定区分</summary>
		private Int32 _commentReservedDiv;

		/// <summary>部品ＯＥＭ区分</summary>
		private Int32 _partsOEMDiv;


		/// public propaty name  :  ExpenseDivCd
		/// <summary>経費区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   経費区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExpenseDivCd
		{
			get{return _expenseDivCd;}
			set{_expenseDivCd = value;}
		}

		/// public propaty name  :  DirectSendingCd
		/// <summary>直送区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   直送区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DirectSendingCd
		{
			get{return _directSendingCd;}
			set{_directSendingCd = value;}
		}

		/// public propaty name  :  AcptAnOrderDiv
		/// <summary>受注区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOrderDiv
		{
			get{return _acptAnOrderDiv;}
			set{_acptAnOrderDiv = value;}
		}

		/// public propaty name  :  DelivererCd
		/// <summary>納品者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DelivererCd
		{
			get{return _delivererCd;}
			set{_delivererCd = value;}
		}

		/// public propaty name  :  DelivererNm
		/// <summary>納品者名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品者名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DelivererNm
		{
			get{return _delivererNm;}
			set{_delivererNm = value;}
		}

		/// public propaty name  :  DelivererAddress
		/// <summary>納品者住所プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品者住所プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DelivererAddress
		{
			get{return _delivererAddress;}
			set{_delivererAddress = value;}
		}

		/// public propaty name  :  DelivererPhoneNum
		/// <summary>納品者ＴＥＬプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品者ＴＥＬプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DelivererPhoneNum
		{
			get{return _delivererPhoneNum;}
			set{_delivererPhoneNum = value;}
		}

		/// public propaty name  :  PureTradCompRate
		/// <summary>部品商仕切率（純正）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品商仕切率（純正）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PureTradCompRate
		{
			get{return _pureTradCompRate;}
			set{_pureTradCompRate = value;}
		}

		/// public propaty name  :  PriTradCompRate
		/// <summary>部品商仕切率（優良）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品商仕切率（優良）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PriTradCompRate
		{
			get{return _priTradCompRate;}
			set{_priTradCompRate = value;}
		}

		/// public propaty name  :  ABGoodsCode
		/// <summary>AB商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   AB商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ABGoodsCode
		{
			get{return _aBGoodsCode;}
			set{_aBGoodsCode = value;}
		}

		/// public propaty name  :  CommentReservedDiv
		/// <summary>コメント指定区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   コメント指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CommentReservedDiv
		{
			get{return _commentReservedDiv;}
			set{_commentReservedDiv = value;}
		}

		/// public propaty name  :  PartsOEMDiv
		/// <summary>部品ＯＥＭ区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品ＯＥＭ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsOEMDiv
		{
			get{return _partsOEMDiv;}
			set{_partsOEMDiv = value;}
		}
    }
    // --- ADD 2025/03/04 陳艶丹 PMKOBETSU-4374 Ｓ＆Ｅブレーキオプション変更対応 ------<<<<<

}
