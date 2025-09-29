//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PCC自社設定マスタメンテ
// プログラム概要   ：PCC自社設定マスタ登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.04  修正内容 : 新規作成       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/28  修正内容 : SCM障害№10292対応 ヘッダタイトル部の変更       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/12  修正内容 : SCM障害№10342,10343対応        
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/17  修正内容 : 2013/03/06配信 システムテスト障害対応       
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応 参照倉庫コード追加      
// ---------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の1現在庫数表示区分の追加     
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 修 正 日  2014/09/04  修正内容 : SCM仕掛一覧№10678対応　回答納期表示区分追加
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 修 正 日  2014/10/22  修正内容 : 表示区分が問合せ発注共通で回答納期表示区分を設定しても、発注の区分が設定されない件の対応
//----------------------------------------------------------------------//
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
// ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinToolTip;// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加

// ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC自社設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC自社設定マスタを行います。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.04 </br>
    /// </remarks>
    public partial class PMPCC09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        # region Constructor

        /// <summary>
        /// PCC自社設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public PMPCC09010UA()
        {
            InitializeComponent();

            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            // USBオプションチェック
            this._optionBLPPriWareHouse = GetBLPPriWareHouseOption();
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = true;
            this._canNew                    = true;
            this._canDelete                 = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //ログイン担当者の拠点 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 変数初期化
            this._pccCmpnyStAcs = new PccCmpnyStAcs();
            _customerInfoAcs = new CustomerInfoAcs();
            this._detailsTable = new Hashtable();
            //GridIndexバッファ（メインフレーム最小化対応）
            this._detailsIndexBuf = -2;

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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //問合せ元企業コード
            appearanceTable.Add(INQORIGINALEPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //問合せ元拠点コード
            appearanceTable.Add(INQORIGINALSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //問合せ先企業コード
            appearanceTable.Add(INQOTHEREPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //問合せ先拠点コード
            appearanceTable.Add(INQOTHERSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC自社コード
            appearanceTable.Add(PCCCOMPANYCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC自社名称
            appearanceTable.Add(PCCCOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC倉庫コード
            appearanceTable.Add(PCCWAREHOUSECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC優先倉庫コード1
            appearanceTable.Add(PCCPRIWAREHOUSECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC優先倉庫コード2
            appearanceTable.Add(PCCPRIWAREHOUSECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC優先倉庫コード3
            appearanceTable.Add(PCCPRIWAREHOUSECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC優先倉庫コード4
                appearanceTable.Add(PCCPRIWAREHOUSECD4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            }
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            appearanceTable.Add(GOODSNODSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //標準価格表示区分
            appearanceTable.Add(LISTPRCDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //仕切価格表示区分
            appearanceTable.Add(COSTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //棚番表示区分
            appearanceTable.Add(SHELFDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(問合せ)
            appearanceTable.Add(PRSNTSTKCTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            appearanceTable.Add(ANSDELIDTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            //コメント表示区分
            appearanceTable.Add(COMMENTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //出荷数表示区分
            appearanceTable.Add(SPMTCNTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //appearanceTable.Add(ACPTCNTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            //部品選択品番表示区分
            appearanceTable.Add(PRTSELGDNODSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //部品選択標準価格表示区分
            appearanceTable.Add(PRTSELLSPRDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //部品選択棚番表示区分
            appearanceTable.Add(PRTSELSELFDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
           //PCC発注先名称1
            appearanceTable.Add(PCCSUPLNAME1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先名称2
            appearanceTable.Add(PCCSUPLNAME2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先カナ名称
            appearanceTable.Add(PCCSUPLKANA_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先略称
            appearanceTable.Add(PCCSUPLSNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先郵便番号
            appearanceTable.Add(PCCSUPLPOSTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先住所1
            appearanceTable.Add(PCCSUPLADDR1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先住所2
            appearanceTable.Add(PCCSUPLADDR2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先住所3
            appearanceTable.Add(PCCSUPLADDR3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先電話番号1
            appearanceTable.Add(PCCSUPLTELNO1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先電話番号2
            appearanceTable.Add(PCCSUPLTELNO2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC発注先FAX番号
            appearanceTable.Add(PCCSUPLFAXNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //伝票発行区分（PCC）
            appearanceTable.Add(PCCSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          　//在庫コメント1
            appearanceTable.Add(STCKSTCOMMENT1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //在庫コメント2
            appearanceTable.Add(STCKSTCOMMENT2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //在庫コメント3
            appearanceTable.Add(STCKSTCOMMENT3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //appearanceTable.Add(STOCKDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            ////部品選択在庫表示区分(問合せ)
            //appearanceTable.Add(PRTSELSTCKDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            appearanceTable.Add(WAREHOUSEDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //取消表示区分(問合せ)
            appearanceTable.Add(CANCELDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //品番表示区分(発注)
            appearanceTable.Add(GOODSNODSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //標準価格表示区分(発注)
            appearanceTable.Add(LISTPRCDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //仕切価格表示区分(発注)
            appearanceTable.Add(COSTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //棚番表示区分(発注)
            appearanceTable.Add(SHELFDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            appearanceTable.Add(PRSNTSTKCTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(発注)
            appearanceTable.Add(ANSDELIDTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //appearanceTable.Add(STOCKDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            appearanceTable.Add(COMMENTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //出荷数表示区分(発注)
            appearanceTable.Add(SPMTCNTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //appearanceTable.Add(ACPTCNTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            appearanceTable.Add(PRTSELGDNODSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //部品選択標準価格表示区分(発注)
            appearanceTable.Add(PRTSELLSPRDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //部品選択棚番表示区分(発注)
            appearanceTable.Add(PRTSELSELFDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //appearanceTable.Add(PRTSELSTCKDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            appearanceTable.Add(WAREHOUSEDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //取消表示区分(発注)
            appearanceTable.Add(CANCELDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //問合せ発注表示区分設定
            appearanceTable.Add(INQODRDSPDIVSET_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

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
        /// <br>Date       : 2011.08.04 </br>
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
        
        private string _enterpriseCode;         // 企業コード
        private string _loginSectionCode;
        private Hashtable _detailsTable;        // 自社設定マスタ用ハッシュテーブル
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
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
        //問合せ元企業コード
        private string _inqOriginalEpCd = string.Empty;
        //問合せ元拠点コード
        private string _inqOriginalSecCd = string.Empty;
        //前問合せ元企業コード
        private string _inqOriginalEpCdPre = string.Empty;
        //前問合せ元拠点コード
        private string _inqOriginalSecCdPre = string.Empty;
        private CustomerInfoAcs _customerInfoAcs;
        private PMPCC09010UB _pMPCC09010UB;
        /// <summary>
        /// 前得意先コード
        /// </summary>
        private int _customerCodePre = -1;
        /// <summary>
        /// 前得意先名称
        /// </summary>
        private string _customerNamePre = string.Empty;

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        // USBオプション BLP参照倉庫追加オプション
        private bool _optionBLPPriWareHouse = false;
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        #endregion

        #region  Private const
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private PccCmpnySt _pccCmpnySt;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE = "削除日";
        private const string INQORIGINALEPCD_TITLE = "問合せ元企業コード";
        private const string INQORIGINALSECCD_TITLE = "問合せ元拠点コード";
        private const string INQOTHEREPCD_TITLE = "問合せ先企業コード";
        private const string INQOTHERSECCD_TITLE = "問合せ先拠点コード";
        //DEL SATART BY wujun FOR Redmine#25173 ON 2011.09.15 
        //private const string PCCCOMPANYCODE_TITLE = "PCC自社コード";
        //private const string PCCCOMPANYNAME_TITLE = "PCC自社名称";
        //private const string PCCWAREHOUSECD_TITLE = "PCC倉庫コード";
        //private const string PCCPRIWAREHOUSECD1_TITLE = "PCC優先倉庫コード1";
        //private const string PCCPRIWAREHOUSECD2_TITLE = "PCC優先倉庫コード2";
        //private const string PCCPRIWAREHOUSECD3_TITLE = "PCC優先倉庫コード3";
        //DEL END BY wujun FOR Redmine#25173 ON 2011.09.15
        //ADD START BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCCOMPANYCODE_TITLE = "自社コード";
        private const string PCCCOMPANYNAME_TITLE = "自社名称";
        // UPD 2012/06/28 湯上 No.10292 -------------------------------------------->>>>>
        //private const string PCCWAREHOUSECD_TITLE = "倉庫コード";
        //private const string PCCPRIWAREHOUSECD1_TITLE = "優先倉庫コード1";
        //private const string PCCPRIWAREHOUSECD2_TITLE = "優先倉庫コード2";
        //private const string PCCPRIWAREHOUSECD3_TITLE = "優先倉庫コード3";
        private const string PCCWAREHOUSECD_TITLE = "委託倉庫コード";
        private const string PCCPRIWAREHOUSECD1_TITLE = "参照倉庫コード1";
        private const string PCCPRIWAREHOUSECD2_TITLE = "参照倉庫コード2";
        private const string PCCPRIWAREHOUSECD3_TITLE = "参照倉庫コード3";
        // UPD 2012/06/28 湯上 No.10292 --------------------------------------------<<<<<
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        private const string PCCPRIWAREHOUSECD4_TITLE = "参照倉庫コード4";
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        //ADD END BY wujun FOR Redmine#25173 ON 2011.09.15
        // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
        //private const string GOODSNODSPDIV_TITLE = "品番表示区分";
        //private const string LISTPRCDSPDIV_TITLE = "標準価格表示区分";
        //private const string COSTDSPDIV_TITLE = "仕切価格表示区分";
        //private const string SHELFDSPDIV_TITLE = "棚番表示区分";
        //private const string COMMENTDSPDIV_TITLE = "コメント表示区分";
        //private const string SPMTCNTDSPDIV_TITLE = "出荷数表示区分";
        //private const string ACPTCNTDSPDIV_TITLE = "受注数表示区分";
        //private const string PRTSELGDNODSPDIV_TITLE = "部品選択品番表示区分";
        //private const string PRTSELLSPRDSPDIV_TITLE = "部品選択標準価格表示区分";
        //private const string PRTSELSELFDSPDIV_TITLE = "部品選択棚番表示区分";
        // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
        //private const string GOODSNODSPDIV_TITLE = "品番表示区分(問合せ)";
        //private const string LISTPRCDSPDIV_TITLE = "標準価格表示区分(問合せ)";
        //private const string COSTDSPDIV_TITLE = "仕切価格表示区分(問合せ)";
        //private const string SHELFDSPDIV_TITLE = "棚番表示区分(問合せ)";
        //private const string STOCKDSPDIV_TITLE = "在庫表示区分(問合せ)";
        //private const string COMMENTDSPDIV_TITLE = "コメント表示区分(問合せ)";
        //private const string SPMTCNTDSPDIV_TITLE = "出荷数表示区分(問合せ)";
        //private const string ACPTCNTDSPDIV_TITLE = "受注数表示区分(問合せ)";
        //private const string PRTSELGDNODSPDIV_TITLE = "部品選択品番表示区分(問合せ)";
        //private const string PRTSELLSPRDSPDIV_TITLE = "部品選択標準価格表示区分(問合せ)";
        //private const string PRTSELSELFDSPDIV_TITLE = "部品選択棚番表示区分(問合せ)";
        //private const string PRTSELSTCKDSPDIV_TITLE = "部品選択在庫表示区分(問合せ)";
        //private const string WAREHOUSEDSPDIV_TITLE = "倉庫表示区分(問合せ)";
        //private const string CANCELDSPDIV_TITLE = "取消表示区分(問合せ)";
        //private const string GOODSNODSPDIVOD_TITLE = "品番表示区分(発注)";
        //private const string LISTPRCDSPDIVOD_TITLE = "標準価格表示区分(発注)";
        //private const string COSTDSPDIVOD_TITLE = "仕切価格表示区分(発注)";
        //private const string SHELFDSPDIVOD_TITLE = "棚番表示区分(発注)";
        //private const string STOCKDSPDIVOD_TITLE = "在庫表示区分(発注)";
        //private const string COMMENTDSPDIVOD_TITLE = "コメント表示区分(発注)";
        //private const string SPMTCNTDSPDIVOD_TITLE = "出荷数表示区分(発注)";
        //private const string ACPTCNTDSPDIVOD_TITLE = "受注数表示区分(発注)";
        //private const string PRTSELGDNODSPDIVOD_TITLE = "部品選択品番表示区分(発注)";
        //private const string PRTSELLSPRDSPDIVOD_TITLE = "部品選択標準価格表示区分(発注)";
        //private const string PRTSELSELFDSPDIVOD_TITLE = "部品選択棚番表示区分(発注)";
        //private const string PRTSELSTCKDSPDIVOD_TITLE = "部品選択在庫表示区分(発注)";
        //private const string WAREHOUSEDSPDIVOD_TITLE = "倉庫表示区分(発注)";
        //private const string CANCELDSPDIVOD_TITLE = "取消表示区分(発注)";
        //private const string INQODRDSPDIVSET_TITLE = "問合せ発注表示区分設定";
        private const string GOODSNODSPDIV_TITLE = "品番表示区分(問合せ)";
        private const string LISTPRCDSPDIV_TITLE = "標準価格表示区分(問合せ)";
        private const string COSTDSPDIV_TITLE = "仕切価格表示区分(問合せ)";
        private const string SHELFDSPDIV_TITLE = "棚番表示区分(問合せ)";
        private const string PRSNTSTKCTDSPDIV_TITLE = "現在庫数表示区分(問合せ)";// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        private const string COMMENTDSPDIV_TITLE = "コメント表示区分(問合せ)";
        private const string SPMTCNTDSPDIV_TITLE = "出荷数表示区分(問合せ)";
        private const string PRTSELGDNODSPDIV_TITLE = "部品選択品番表示区分(問合せ)";
        private const string PRTSELLSPRDSPDIV_TITLE = "部品選択標準価格表示区分(問合せ)";
        private const string PRTSELSELFDSPDIV_TITLE = "部品選択棚番表示区分(問合せ)";
        private const string WAREHOUSEDSPDIV_TITLE = "倉庫表示区分(問合せ)";
        private const string CANCELDSPDIV_TITLE = "取消表示区分(問合せ)";
        private const string GOODSNODSPDIVOD_TITLE = "品番表示区分(発注)";
        private const string LISTPRCDSPDIVOD_TITLE = "標準価格表示区分(発注)";
        private const string COSTDSPDIVOD_TITLE = "仕切価格表示区分(発注)";
        private const string SHELFDSPDIVOD_TITLE = "棚番表示区分(発注)";
        private const string PRSNTSTKCTDSPDIVOD_TITLE = "現在庫数表示区分(発注)";// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        private const string COMMENTDSPDIVOD_TITLE = "コメント表示区分(発注)";
        private const string SPMTCNTDSPDIVOD_TITLE = "出荷数表示区分(発注)";
        private const string PRTSELGDNODSPDIVOD_TITLE = "部品選択品番表示区分(発注)";
        private const string PRTSELLSPRDSPDIVOD_TITLE = "部品選択標準価格表示区分(発注)";
        private const string PRTSELSELFDSPDIVOD_TITLE = "部品選択棚番表示区分(発注)";
        private const string WAREHOUSEDSPDIVOD_TITLE = "倉庫表示区分(発注)";
        private const string CANCELDSPDIVOD_TITLE = "取消表示区分(発注)";
        private const string INQODRDSPDIVSET_TITLE = "問合せ発注表示区分設定";
        // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
        // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
        //DEL SATART BY wujun FOR Redmine#25173 ON 2011.09.15 
        //private const string PCCSUPLNAME1_TITLE = "PCC発注先名称1";
        //private const string PCCSUPLNAME2_TITLE = "PCC発注先名称2";
        //private const string PCCSUPLKANA_TITLE = "PCC発注先カナ名称";
        //private const string PCCSUPLSNM_TITLE = "PCC発注先略称";
        //private const string PCCSUPLPOSTNO_TITLE = "PCC発注先郵便番号";
        //private const string PCCSUPLADDR1_TITLE = "PCC発注先住所1";
        //private const string PCCSUPLADDR2_TITLE = "PCC発注先住所2";
        //private const string PCCSUPLADDR3_TITLE = "PCC発注先住所3";
        //private const string PCCSUPLTELNO1_TITLE = "PCC発注先電話番号1";
        //private const string PCCSUPLTELNO2_TITLE = "PCC発注先電話番号2";
        //private const string PCCSUPLFAXNO_TITLE = "PCC発注先FAX番号";
        //private const string PCCSLIPPRTDIV_TITLE = "伝票発行区分（PCC）";
        //private const string STCKSTCOMMENT1_TITLE = "在庫コメント1";
        //private const string STCKSTCOMMENT2_TITLE = "在庫コメント2";
        //private const string STCKSTCOMMENT3_TITLE = "在庫コメント3";
        //DEL END BY wujun FOR Redmine#25173 ON 2011.09.15
        //ADD START BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCSUPLNAME1_TITLE = "発注先名称1";
        private const string PCCSUPLNAME2_TITLE = "発注先名称2";
        private const string PCCSUPLKANA_TITLE = "発注先カナ名称";
        private const string PCCSUPLSNM_TITLE = "発注先略称";
        private const string PCCSUPLPOSTNO_TITLE = "発注先郵便番号";
        private const string PCCSUPLADDR1_TITLE = "発注先住所1";
        private const string PCCSUPLADDR2_TITLE = "発注先住所2";
        private const string PCCSUPLADDR3_TITLE = "発注先住所3";
        private const string PCCSUPLTELNO1_TITLE = "発注先電話番号1";
        private const string PCCSUPLTELNO2_TITLE = "発注先電話番号2";
        private const string PCCSUPLFAXNO_TITLE = "発注先FAX番号";
        private const string PCCSLIPPRTDIV_TITLE = "リモート伝発区分";
        private const string STCKSTCOMMENT1_TITLE = "在庫有り";
        private const string STCKSTCOMMENT2_TITLE = "在庫無し";
        private const string STCKSTCOMMENT3_TITLE = "在庫不足";
        //ADD END BY wujun FOR Redmine#25173 ON 2011.09.15
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        private const string ANSDELIDTDSPDIV_TITLE = "回答納期表示区分(問合せ)";
        private const string ANSDELIDTDSPDIVOD_TITLE = "回答納期表示区分(発注)";

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        //PCCオンライン種別区分
        private const int ONLINEKINDDIV = 10;
        
        // テーブル名称
        private const string DETAILS_TABLE = "PccCmpnyStRF";  

        // ガイドキー
        private const string DETAILS_GUID_KEY = "FileHeaderGuid";

        // Message関連定義
        private const string ASSEMBLY_ID = "PMPCC09010U";
        //private const string PROGRAM_NAME = "PCC自社設定";　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PROGRAM_NAME = "BLﾊﾟｰﾂｵｰﾀﾞｰ自社設定";　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        private const string ERR_TIMEOUT_MSG = "削除中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string CUSTOMEMPTY_BASE = "ベース設定";
        #endregion

        // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
        // 問合せ発注表示区分
        private const int INQODRCOMMON = 0; // 問合せ発注共通
        private const int INQODRINDIVIDUAL = 1; // 問合せ発注個別
        // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

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
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
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

                List<PccCmpnySt> retList = null;
                PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
                parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
                parsePccCmpnySt.InqOtherSecCd = this._loginSectionCode;
                status = this._pccCmpnyStAcs.Search(out retList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData01);
                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
                    return status;
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PccCmpnySt pccCmpnySt in retList)
                        {
                            if (pccCmpnySt.LogicalDeleteCode > 1)
                            {
                                continue;
                            }
                            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();//@@@@20230303
                            if (this._detailsTable.ContainsKey(guid) == false)
                            {
                                DetailsToDataSet(pccCmpnySt.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            TMsgDisp.Show(
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                                this.Text,							  // プログラム名称
                                "Search",							  // 処理名称
                                TMsgDisp.OPE_GET,					  // オペレーション
                                ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._pccCmpnyStAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                            break;
                        }
				    default:
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        PROGRAM_NAME, 			            // プログラム名称
                        "Search", 					        // 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
                        ERR_READ_MSG, 		                // 表示するメッセージ
						status, 							// ステータス値
                        this._pccCmpnyStAcs, 		        // エラーが発生したオブジェクト
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
                    this._pccCmpnyStAcs,		          // エラーが発生したオブジェクト
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
        /// <br>Date       : 2011.08.04 </br>
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            status = LogicalDeletePccCmpnySt();
            Initial_Timer.Enabled = true;
            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// PCC自社設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="commColumn">PCC自社設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DetailsToDataSet(PccCmpnySt pccCmpnySt, int index)
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
            if (pccCmpnySt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pccCmpnySt.UpdateDateTimeJpInFormal;
            }

            //問合せ元企業コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQORIGINALEPCD_TITLE] = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            //問合せ元拠点コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQORIGINALSECCD_TITLE] = pccCmpnySt.InqOriginalSecCd;
            //問合せ先企業コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQOTHEREPCD_TITLE] = pccCmpnySt.InqOtherEpCd;
            //問合せ先拠点コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQOTHERSECCD_TITLE] = pccCmpnySt.InqOtherSecCd;
            //PCC自社コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCCOMPANYCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            //PCCCOMPANYNAME_TITLE
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCCOMPANYNAME_TITLE] = pccCmpnySt.PccCompanyName;
            //PCC倉庫コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCWAREHOUSECD_TITLE] = pccCmpnySt.PccWarehouseCd;
            //PCC優先倉庫コード1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD1_TITLE] = pccCmpnySt.PccPriWarehouseCd1;
            //PCC優先倉庫コード2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD2_TITLE] = pccCmpnySt.PccPriWarehouseCd2;
            //PCC優先倉庫コード3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD3_TITLE] = pccCmpnySt.PccPriWarehouseCd3;
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC優先倉庫コード4
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD4_TITLE] = pccCmpnySt.PccPriWarehouseCd4;
            }
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][GOODSNODSPDIV_TITLE] = pccCmpnySt.GoodsNoDspDivName;
            //標準価格表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LISTPRCDSPDIV_TITLE] = pccCmpnySt.ListPrcDspDivName;
            //仕切価格表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COSTDSPDIV_TITLE] = pccCmpnySt.CostDspDivName;
            //棚番表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SHELFDSPDIV_TITLE] = pccCmpnySt.ShelfDspDivName;
            //コメント表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COMMENTDSPDIV_TITLE] = pccCmpnySt.CommentDspDivName;
            //出荷数表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SPMTCNTDSPDIV_TITLE] = pccCmpnySt.SpmtCntDspDivName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ACPTCNTDSPDIV_TITLE] = pccCmpnySt.AcptCntDspDivName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELGDNODSPDIV_TITLE] = pccCmpnySt.PrtSelGdNoDspDivName;
            //部品選択標準価格表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELLSPRDSPDIV_TITLE] = pccCmpnySt.PrtSelLsPrDspDivName;
            //部品選択棚番表示区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSELFDSPDIV_TITLE] = pccCmpnySt.PrtSelSelfDspDivName;
            //PCC発注先名称1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLNAME1_TITLE] = pccCmpnySt.PccSuplName1;
            //PCC発注先名称2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLNAME2_TITLE] = pccCmpnySt.PccSuplName2;
            //PCC発注先カナ名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLKANA_TITLE] = pccCmpnySt.PccSuplKana;
            //PCC発注先略称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLSNM_TITLE] = pccCmpnySt.PccSuplSnm;
            //PCC発注先郵便番号
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLPOSTNO_TITLE] = pccCmpnySt.PccSuplPostNo;
            //PCC発注先住所1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR1_TITLE] = pccCmpnySt.PccSuplAddr1;
            //PCC発注先住所2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR2_TITLE] = pccCmpnySt.PccSuplAddr2;
            //PCC発注先住所3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR3_TITLE] = pccCmpnySt.PccSuplAddr3;
            //PCC発注先電話番号1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLTELNO1_TITLE] = pccCmpnySt.PccSuplTelNo1;
            //PCC発注先電話番号2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLTELNO2_TITLE] = pccCmpnySt.PccSuplTelNo2;
            //PCC発注先FAX番号
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLFAXNO_TITLE] = pccCmpnySt.PccSuplFaxNo;
            //伝票発行区分（PCC）
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSLIPPRTDIV_TITLE] = pccCmpnySt.PccSlipPrtDivName;
            //在庫コメント1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT1_TITLE] = pccCmpnySt.StckStComment1;
            //在庫コメント2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT2_TITLE] = pccCmpnySt.StckStComment2;
            //在庫コメント3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT3_TITLE] = pccCmpnySt.StckStComment3;

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKDSPDIV_TITLE] = pccCmpnySt.StockDspDivName;
            ////部品選択在庫表示区分(問合せ)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSTCKDSPDIV_TITLE] = pccCmpnySt.PrtSelStckDspDivName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSEDSPDIV_TITLE] = pccCmpnySt.WarehouseDspDivName;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(問合せ)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRSNTSTKCTDSPDIV_TITLE] = pccCmpnySt.PrsntStkCtDspDivName;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ANSDELIDTDSPDIV_TITLE] = pccCmpnySt.AnsDeliDtDspDivName;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            //取消表示区分(問合せ)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CANCELDSPDIV_TITLE] = pccCmpnySt.CancelDspDivName;
            //品番表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][GOODSNODSPDIVOD_TITLE] = pccCmpnySt.GoodsNoDspDivOdName;
            //標準価格表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LISTPRCDSPDIVOD_TITLE] = pccCmpnySt.ListPrcDspDivOdName;
            //仕切価格表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COSTDSPDIVOD_TITLE] = pccCmpnySt.CostDspDivOdName;
            //棚番表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SHELFDSPDIVOD_TITLE] = pccCmpnySt.ShelfDspDivOdName;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRSNTSTKCTDSPDIVOD_TITLE] = pccCmpnySt.PrsntStkCtDspDivOdName;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ANSDELIDTDSPDIVOD_TITLE] = pccCmpnySt.AnsDeliDtDspDivOdName;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKDSPDIVOD_TITLE] = pccCmpnySt.StockDspDivOdName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COMMENTDSPDIVOD_TITLE] = pccCmpnySt.CommentDspDivOdName;
            //出荷数表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SPMTCNTDSPDIVOD_TITLE] = pccCmpnySt.SpmtCntDspDivOdName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ACPTCNTDSPDIVOD_TITLE] = pccCmpnySt.AcptCntDspDivOdName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELGDNODSPDIVOD_TITLE] = pccCmpnySt.PrtSelGdNoDspDivOdName;
            //部品選択標準価格表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELLSPRDSPDIVOD_TITLE] = pccCmpnySt.PrtSelLsPrDspDivOdName;
            //部品選択棚番表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSELFDSPDIVOD_TITLE] = pccCmpnySt.PrtSelSelfDspDivOdName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSTCKDSPDIVOD_TITLE] = pccCmpnySt.PrtSelStckDspDivOdName;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSEDSPDIVOD_TITLE] = pccCmpnySt.WarehouseDspDivOdName;
            //取消表示区分(発注)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CANCELDSPDIVOD_TITLE] = pccCmpnySt.CancelDspDivOdName;
            //問合せ発注表示区分設定
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQODRDSPDIVSET_TITLE] = pccCmpnySt.InqOdrDspDivSetName;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

            // GUID
            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = guid;

            // ハッシュテーブル更新
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
            this._detailsTable.Add(guid, pccCmpnySt);
        }

        /// <summary>
        /// PCC自社設定マスタオブジェクトデータセット削除処理
        /// </summary>
        /// <param name="commColumn">PCC自社設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        private void DeleteFromDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            // データセットから行削除します
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // ハッシュテーブルから削除します
            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + //@@@@20230303
                pccCmpnySt.InqOriginalSecCd.TrimEnd() + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();

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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //PCC自社設定マスタ
            DataTable detailsTable = new DataTable(DETAILS_TABLE); 
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            //問合せ元企業コード
            detailsTable.Columns.Add(INQORIGINALEPCD_TITLE, typeof(string));
            //問合せ元拠点コード
            detailsTable.Columns.Add(INQORIGINALSECCD_TITLE, typeof(string));
            //問合せ先企業コード
            detailsTable.Columns.Add(INQOTHEREPCD_TITLE, typeof(string));
            //問合せ先拠点コード
            detailsTable.Columns.Add(INQOTHERSECCD_TITLE, typeof(string));
            //PCC自社コード
            detailsTable.Columns.Add(PCCCOMPANYCODE_TITLE, typeof(Int32));
            //PCC自社名称
            detailsTable.Columns.Add(PCCCOMPANYNAME_TITLE, typeof(string));
            //PCC倉庫コード
            detailsTable.Columns.Add(PCCWAREHOUSECD_TITLE, typeof(string));
            //PCC優先倉庫コード1
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD1_TITLE, typeof(string));
            //PCC優先倉庫コード2
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD2_TITLE, typeof(string));
            //PCC優先倉庫コード3
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD3_TITLE, typeof(string));
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC優先倉庫コード4
                detailsTable.Columns.Add(PCCPRIWAREHOUSECD4_TITLE, typeof(string));
            }
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            detailsTable.Columns.Add(GOODSNODSPDIV_TITLE, typeof(string));
            //標準価格表示区分
            detailsTable.Columns.Add(LISTPRCDSPDIV_TITLE, typeof(string));
            //仕切価格表示区分
            detailsTable.Columns.Add(COSTDSPDIV_TITLE, typeof(string));
            //棚番表示区分
            detailsTable.Columns.Add(SHELFDSPDIV_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(問合せ)
            detailsTable.Columns.Add(PRSNTSTKCTDSPDIV_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            detailsTable.Columns.Add(ANSDELIDTDSPDIV_TITLE, typeof(string));
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            //コメント表示区分
            detailsTable.Columns.Add(COMMENTDSPDIV_TITLE, typeof(string));
            //出荷数表示区分
            detailsTable.Columns.Add(SPMTCNTDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //detailsTable.Columns.Add(ACPTCNTDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分
            detailsTable.Columns.Add(PRTSELGDNODSPDIV_TITLE, typeof(string));
            //部品選択標準価格表示区分
            detailsTable.Columns.Add(PRTSELLSPRDSPDIV_TITLE, typeof(string));
            //部品選択棚番表示区分
            detailsTable.Columns.Add(PRTSELSELFDSPDIV_TITLE, typeof(string));
            //PCC発注先名称1
            detailsTable.Columns.Add(PCCSUPLNAME1_TITLE, typeof(string));
            //PCC発注先名称2
            detailsTable.Columns.Add(PCCSUPLNAME2_TITLE, typeof(string));
            //PCC発注先カナ名称
            detailsTable.Columns.Add(PCCSUPLKANA_TITLE, typeof(string));
            //PCC発注先略称
            detailsTable.Columns.Add(PCCSUPLSNM_TITLE, typeof(string));
            //PCC発注先郵便番号
            detailsTable.Columns.Add(PCCSUPLPOSTNO_TITLE, typeof(string));
            //PCC発注先住所1
            detailsTable.Columns.Add(PCCSUPLADDR1_TITLE, typeof(string));
            //PCC発注先住所2
            detailsTable.Columns.Add(PCCSUPLADDR2_TITLE, typeof(string));
            //PCC発注先住所3
            detailsTable.Columns.Add(PCCSUPLADDR3_TITLE, typeof(string));
            //PCC発注先電話番号1
            detailsTable.Columns.Add(PCCSUPLTELNO1_TITLE, typeof(string));
            //PCC発注先電話番号2
            detailsTable.Columns.Add(PCCSUPLTELNO2_TITLE, typeof(string));
            //PCC発注先FAX番号
            detailsTable.Columns.Add(PCCSUPLFAXNO_TITLE, typeof(string));
            //伝票発行区分（PCC）
            detailsTable.Columns.Add(PCCSLIPPRTDIV_TITLE, typeof(string));
            //在庫コメント1
            detailsTable.Columns.Add(STCKSTCOMMENT1_TITLE, typeof(string));
            //在庫コメント2
            detailsTable.Columns.Add(STCKSTCOMMENT2_TITLE, typeof(string));
            //在庫コメント3
            detailsTable.Columns.Add(STCKSTCOMMENT3_TITLE, typeof(string));

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //detailsTable.Columns.Add(STOCKDSPDIV_TITLE, typeof(string));
            ////部品選択在庫表示区分(問合せ)
            //detailsTable.Columns.Add(PRTSELSTCKDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            detailsTable.Columns.Add(WAREHOUSEDSPDIV_TITLE, typeof(string));
            //取消表示区分(問合せ)
            detailsTable.Columns.Add(CANCELDSPDIV_TITLE, typeof(string));
            //品番表示区分(発注)
            detailsTable.Columns.Add(GOODSNODSPDIVOD_TITLE, typeof(string));
            //標準価格表示区分(発注)
            detailsTable.Columns.Add(LISTPRCDSPDIVOD_TITLE, typeof(string));
            //仕切価格表示区分(発注)
            detailsTable.Columns.Add(COSTDSPDIVOD_TITLE, typeof(string));
            //棚番表示区分(発注)
            detailsTable.Columns.Add(SHELFDSPDIVOD_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            detailsTable.Columns.Add(PRSNTSTKCTDSPDIVOD_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(発注)
            detailsTable.Columns.Add(ANSDELIDTDSPDIVOD_TITLE, typeof(string));
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //detailsTable.Columns.Add(STOCKDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            detailsTable.Columns.Add(COMMENTDSPDIVOD_TITLE, typeof(string));
            //出荷数表示区分(発注)
            detailsTable.Columns.Add(SPMTCNTDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //detailsTable.Columns.Add(ACPTCNTDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            detailsTable.Columns.Add(PRTSELGDNODSPDIVOD_TITLE, typeof(string));
            //部品選択標準価格表示区分(発注)
            detailsTable.Columns.Add(PRTSELLSPRDSPDIVOD_TITLE, typeof(string));
            //部品選択棚番表示区分(発注)
            detailsTable.Columns.Add(PRTSELSELFDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //detailsTable.Columns.Add(PRTSELSTCKDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            detailsTable.Columns.Add(WAREHOUSEDSPDIVOD_TITLE, typeof(string));
            //取消表示区分(発注)
            detailsTable.Columns.Add(CANCELDSPDIVOD_TITLE, typeof(string));
            //問合せ発注表示区分設定
            detailsTable.Columns.Add(INQODRDSPDIVSET_TITLE, typeof(string));
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(string));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;
            this.ClearAll();
            // ボタン
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                // 新規
                case INSERT_MODE:
                    //得意先コード
                    this.tNedit_CustomerCode.Enabled = true;
                    //得意先名称
                    this.uLabel_CustomerName.Enabled = true;
                    //PCC自社コード
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC倉庫コード
                    this.tNedit_PccWarehouseCd.Enabled = true;
                    //PCC優先倉庫コード1
                    this.tNedit_PccPriWarehouseCd1.Enabled = true;
                    //PCC優先倉庫コード2
                    this.tNedit_PccPriWarehouseCd2.Enabled = true;
                    //PCC優先倉庫コード3
                    this.tNedit_PccPriWarehouseCd3.Enabled = true;
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                    // オプションチェック
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC優先倉庫コード4
                        this.tNedit_PccPriWarehouseCd4.Enabled = true;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                    //品番表示区分
                    this.tComboEditor_GoodsNoDspDiv.Enabled = true;
                    //標準価格表示区分
                    this.tComboEditor_ListPrcDspDiv.Enabled = true;
                    //仕切価格表示区分
                    this.tComboEditor_CostDspDiv.Enabled = true;
                    //棚番表示区分
                    this.tComboEditor_ShelfDspDiv.Enabled = true;
                    //コメント表示区分
                    this.tComboEditor_CommentDspDiv.Enabled = true;
                    //出荷数表示区分
                    this.tComboEditor_SpmtCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////受注数表示区分
                    //this.tComboEditor_AcptCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //部品選択品番表示区分
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = true;
                    //部品選択標準価格表示区分
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = true;
                    //部品選択棚番表示区分
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = true;
                    //在庫状況マーク1
                    this.tEdit_StckStComment1.Enabled = true;
                    //在庫状況マーク2
                    this.tEdit_StckStComment2.Enabled = true;
                    //在庫状況マーク3
                    this.tEdit_StckStComment3.Enabled = true;
                    //PCC発注先名称1
                    this.tEdit_PccSuplName1.Enabled = true;
                    //PCC発注先名称2
                    this.tEdit_PccSuplName2.Enabled = true;
                    //PCC発注先カナ名称
                    this.tEdit_PccSuplKana.Enabled = true;
                    //PCC発注先略称
                    this.tEdit_PccSuplSnm.Enabled = true;
                    //PCC発注先郵便番号
                    this.tEdit_PccSuplPostNo.Enabled = true;
                    //PCC発注先住所1
                    this.tEdit_PccSuplAddr1.Enabled = true;
                    //PCC発注先住所2
                    this.tEdit_PccSuplAddr2.Enabled = true;
                    //PCC発注先住所3
                    this.tEdit_PccSuplAddr3.Enabled = true;
                    //PCC発注先電話番号1
                    this.tEdit_PccSuplTelNo1.Enabled = true;
                    //PCC発注先電話番号2
                    this.tEdit_PccSuplTelNo2.Enabled = true;
                    //PCC発注先FAX番号
                    this.tEdit_PccSuplFaxNo.Enabled = true;
                    //伝票発行区分（PCC）
                    this.tComboEditor_PccSlipPrtDiv.Enabled = true;

                    // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////在庫表示区分(問合せ）
                    //this.tComboEditor_StockDspDiv.Enabled = true;
                    ////部品選択在庫表示区分(問合せ)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //倉庫表示区分(問合せ)
                    this.tComboEditor_WarehouseDspDiv.Enabled = true;

                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                    // 現在庫数表示区分(問合せ)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                    // 回答納期表示区分(問合せ)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = true;
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                    //取消表示区分(問合せ)
                    this.tComboEditor_CancelDspDiv.Enabled = true;
                    //問合せ発注表示区分設定
                    this.tComboEditor_InqOdrDspDivSet.Enabled = true;

                    //問合せ発注表示区分が共通の時
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //ラベル非表示
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        // 回答納期表示区分(発注)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //問合せ発注表示区分が個別の時
                    else
                    {
                        //ラベル表示
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = true;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = true;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = true;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = true;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = true;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = true;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = true;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = true;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = true;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = true;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = true;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = true;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.UltraButton_Quote.Visible = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    break;
                // 更新
                case UPDATE_MODE:
                    //得意先コード
                    this.tNedit_CustomerCode.Enabled = true;
                    //得意先名称
                    this.uLabel_CustomerName.Enabled = true;
                    //PCC自社コード
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC倉庫コード
                    this.tNedit_PccWarehouseCd.Enabled = true;
                    //PCC優先倉庫コード1
                    this.tNedit_PccPriWarehouseCd1.Enabled = true;
                    //PCC優先倉庫コード2
                    this.tNedit_PccPriWarehouseCd2.Enabled = true;
                    //PCC優先倉庫コード3
                    this.tNedit_PccPriWarehouseCd3.Enabled = true;
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                    // オプションチェック
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC優先倉庫コード4
                        this.tNedit_PccPriWarehouseCd4.Enabled = true;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                    //品番表示区分
                    this.tComboEditor_GoodsNoDspDiv.Enabled = true;
                    //標準価格表示区分
                    this.tComboEditor_ListPrcDspDiv.Enabled = true;
                    //仕切価格表示区分
                    this.tComboEditor_CostDspDiv.Enabled = true;
                    //棚番表示区分
                    this.tComboEditor_ShelfDspDiv.Enabled = true;
                    //コメント表示区分
                    this.tComboEditor_CommentDspDiv.Enabled = true;
                    //出荷数表示区分
                    this.tComboEditor_SpmtCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////受注数表示区分
                    //this.tComboEditor_AcptCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //部品選択品番表示区分
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = true;
                    //部品選択標準価格表示区分
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = true;
                    //部品選択棚番表示区分
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = true;
                    //在庫状況マーク1
                    this.tEdit_StckStComment1.Enabled = true;
                    //在庫状況マーク2
                    this.tEdit_StckStComment2.Enabled = true;
                    //在庫状況マーク3
                    this.tEdit_StckStComment3.Enabled = true;
                    //PCC発注先名称1
                    this.tEdit_PccSuplName1.Enabled = true;
                    //PCC発注先名称2
                    this.tEdit_PccSuplName2.Enabled = true;
                    //PCC発注先カナ名称
                    this.tEdit_PccSuplKana.Enabled = true;
                    //PCC発注先略称
                    this.tEdit_PccSuplSnm.Enabled = true;
                    //PCC発注先郵便番号
                    this.tEdit_PccSuplPostNo.Enabled = true;
                    //PCC発注先住所1
                    this.tEdit_PccSuplAddr1.Enabled = true;
                    //PCC発注先住所2
                    this.tEdit_PccSuplAddr2.Enabled = true;
                    //PCC発注先住所3
                    this.tEdit_PccSuplAddr3.Enabled = true;
                    //PCC発注先電話番号1
                    this.tEdit_PccSuplTelNo1.Enabled = true;
                    //PCC発注先電話番号2
                    this.tEdit_PccSuplTelNo2.Enabled = true;
                    //PCC発注先FAX番号
                    this.tEdit_PccSuplFaxNo.Enabled = true;
                    //伝票発行区分（PCC）
                    this.tComboEditor_PccSlipPrtDiv.Enabled = true;

                    // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////在庫表示区分(問合せ）
                    //this.tComboEditor_StockDspDiv.Enabled = true;
                    ////部品選択在庫表示区分(問合せ)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //倉庫表示区分(問合せ)
                    this.tComboEditor_WarehouseDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                    // 現在庫数表示区分(問合せ)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                    // 回答納期表示区分(問合せ)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = true;
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                    //取消表示区分(問合せ)
                    this.tComboEditor_CancelDspDiv.Enabled = true;
                    //問合せ発注表示区分設定
                    this.tComboEditor_InqOdrDspDivSet.Enabled = true;

                    //問合せ発注表示区分が共通の時
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //ラベル非表示
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        // 回答納期表示区分(発注)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //問合せ発注表示区分が個別の時
                    else
                    {
                        //ラベル表示
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = true;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = true;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = true;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = true;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = true;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = true;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = true;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = true;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = true;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = true;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = true;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = true;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.UltraButton_Quote.Visible = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    break;
                // 削除
                case DELETE_MODE:
                    //得意先コード
                    this.tNedit_CustomerCode.Enabled = false;
                    //得意先名称
                    this.uLabel_CustomerName.Enabled = false;
                    //PCC自社コード
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC倉庫コード
                    this.tNedit_PccWarehouseCd.Enabled = false;
                    //PCC優先倉庫コード1
                    this.tNedit_PccPriWarehouseCd1.Enabled = false;
                    //PCC優先倉庫コード2
                    this.tNedit_PccPriWarehouseCd2.Enabled = false;
                    //PCC優先倉庫コード3
                    this.tNedit_PccPriWarehouseCd3.Enabled = false;
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                    // オプションチェック
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC優先倉庫コード4
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                    //品番表示区分
                    this.tComboEditor_GoodsNoDspDiv.Enabled = false;
                    //標準価格表示区分
                    this.tComboEditor_ListPrcDspDiv.Enabled = false;
                    //仕切価格表示区分
                    this.tComboEditor_CostDspDiv.Enabled = false;
                    //棚番表示区分
                    this.tComboEditor_ShelfDspDiv.Enabled = false;
                    //コメント表示区分
                    this.tComboEditor_CommentDspDiv.Enabled = false;
                    //出荷数表示区分
                    this.tComboEditor_SpmtCntDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////受注数表示区分
                    //this.tComboEditor_AcptCntDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //部品選択品番表示区分
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = false;
                    //部品選択標準価格表示区分
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = false;
                    //部品選択棚番表示区分
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = false;
                    //在庫状況マーク1
                    this.tEdit_StckStComment1.Enabled = false;
                    //在庫状況マーク2
                    this.tEdit_StckStComment2.Enabled = false;
                    //在庫状況マーク3
                    this.tEdit_StckStComment3.Enabled = false;
                    //PCC発注先名称1
                    this.tEdit_PccSuplName1.Enabled = false;
                    //PCC発注先名称2
                    this.tEdit_PccSuplName2.Enabled = false;
                    //PCC発注先カナ名称
                    this.tEdit_PccSuplKana.Enabled = false;
                    //PCC発注先略称
                    this.tEdit_PccSuplSnm.Enabled = false;
                    //PCC発注先郵便番号
                    this.tEdit_PccSuplPostNo.Enabled = false;
                    //PCC発注先住所1
                    this.tEdit_PccSuplAddr1.Enabled = false;
                    //PCC発注先住所2
                    this.tEdit_PccSuplAddr2.Enabled = false;
                    //PCC発注先住所3
                    this.tEdit_PccSuplAddr3.Enabled = false;
                    //PCC発注先電話番号1
                    this.tEdit_PccSuplTelNo1.Enabled = false;
                    //PCC発注先電話番号2
                    this.tEdit_PccSuplTelNo2.Enabled = false;
                    //PCC発注先FAX番号
                    this.tEdit_PccSuplFaxNo.Enabled = false;
                    //伝票発行区分（PCC）
                    this.tComboEditor_PccSlipPrtDiv.Enabled = false;

                    // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                    ////在庫表示区分(問合せ）
                    //this.tComboEditor_StockDspDiv.Enabled = false;
                    ////部品選択在庫表示区分(問合せ)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                    //倉庫表示区分(問合せ)
                    this.tComboEditor_WarehouseDspDiv.Enabled = false;
                    //取消表示区分(問合せ)
                    this.tComboEditor_CancelDspDiv.Enabled = false;
                    //問合せ発注表示区分設定
                    this.tComboEditor_InqOdrDspDivSet.Enabled = false;

                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                    // 現在庫数表示区分(問合せ)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = false;
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                    // 回答納期表示区分(問合せ)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = false;
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                    //問合せ発注表示区分が共通の時
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //ラベル非表示
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        // 回答納期表示区分(発注)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //問合せ発注表示区分が個別の時
                    else
                    {
                        //ラベル表示
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //品番表示区分(発注)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //標準価格表示区分(発注)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //仕切価格表示区分(発注)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //棚番表示区分(発注)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////在庫表示区分(発注)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //コメント表示区分(発注)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //出荷数表示区分(発注)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////受注数表示区分(発注)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //部品選択品番表示区分(発注)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //部品選択標準価格表示区分(発注)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //部品選択棚番表示区分(発注)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                        ////部品選択在庫表示区分(発注)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                        //倉庫表示区分(発注)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                        // 現在庫数表示区分(発注)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                        //取消表示区分(発注)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.UltraButton_Quote.Visible = false;
                    this.UButton_CustomerGuide.Enabled = false;
                    break;
            }

        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PccCmpnySt pccCmpnySt = new PccCmpnySt();
            ScreenClear();
                
            // 新規の場合
            if (this._dataIndex < 0)
            {
                // クローン作成
                this._pccCmpnySt = pccCmpnySt.Clone();
                DispToPccCmpnySt(ref this._pccCmpnySt);
                //問合せ元企業コード
                this._inqOriginalEpCd =string.Empty;
                //問合せ元拠点コード
                this._inqOriginalSecCd = string.Empty;
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
                // フォーカス設定
                this.tNedit_CustomerCode.Focus();
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;

                // 表示情報取得
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = (PccCmpnySt)this._detailsTable[guid];
                //問合せ元企業コード
                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                //問合せ元拠点コード
                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd.TrimEnd();
                // 画面入力許可制御処理
                ScreenInputPermissionControl(DELETE_MODE);
                // フォーカス設定
                this.Delete_Button.Focus();
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
                // 画面展開処理
                PccCmpnyStToScreen(pccCmpnySt);
            }
            // 更新の場合
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                // 表示情報取得
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = (PccCmpnySt)this._detailsTable[guid];

                //問合せ元企業コード
                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                //問合せ元拠点コード
                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd.TrimEnd();
                //前得意先コード
                this._customerCodePre = pccCmpnySt.PccCompanyCode;
                //前得意先名称
                this._customerNamePre = pccCmpnySt.PccCompanyName;
                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                // 画面入力許可制御処理
                ScreenInputPermissionControl(UPDATE_MODE);

                // 画面展開処理
                PccCmpnyStToScreen(pccCmpnySt);

                // クローン作成
                this._pccCmpnySt = pccCmpnySt.Clone();
                DispToPccCmpnySt(ref this._pccCmpnySt);

                // フォーカス設定 PCC倉庫コード
                this.tNedit_PccWarehouseCd.Focus();
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
            }

            //_GridIndexバッファ保持
            this._detailsIndexBuf = this._dataIndex;
        }

        /// <summary>
        /// PCC自社設定マスタクラス画面展開処理
        /// </summary>
        /// <param name="commColumn">PCC自社設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PccCmpnyStToScreen(PccCmpnySt pccCmpnySt)
        {
            //得意先コード
            this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
            //得意先名称
            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName;
            //PCC自社コード
            this.tNedit_PccCompanyCode.SetInt(pccCmpnySt.PccCompanyCode);
            //PCC倉庫コード
            int pccWarehouseCd = 0;
            Int32.TryParse(pccCmpnySt.PccWarehouseCd, out pccWarehouseCd);
            this.tNedit_PccWarehouseCd.SetInt(pccWarehouseCd);
            //PCC優先倉庫コード1
            int pccPriWarehouseCd1 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd1, out pccPriWarehouseCd1);
            this.tNedit_PccPriWarehouseCd1.SetInt(pccPriWarehouseCd1);
            //PCC優先倉庫コード2
            int pccPriWarehouseCd2 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd2, out pccPriWarehouseCd2);
            this.tNedit_PccPriWarehouseCd2.SetInt(pccPriWarehouseCd2);
            //PCC優先倉庫コード3
            int pccPriWarehouseCd3 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd3, out pccPriWarehouseCd3);
            this.tNedit_PccPriWarehouseCd3.SetInt(pccPriWarehouseCd3);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            int pccPriWarehouseCd4 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd4, out pccPriWarehouseCd4);
            this.tNedit_PccPriWarehouseCd4.SetInt(pccPriWarehouseCd4);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            this.tComboEditor_GoodsNoDspDiv.Value = pccCmpnySt.GoodsNoDspDiv;
            //標準価格表示区分
            this.tComboEditor_ListPrcDspDiv.Value = pccCmpnySt.ListPrcDspDiv;
            //仕切価格表示区分
            this.tComboEditor_CostDspDiv.Value = pccCmpnySt.CostDspDiv;
            //棚番表示区分
            this.tComboEditor_ShelfDspDiv.Value = pccCmpnySt.ShelfDspDiv;
            //コメント表示区分
            this.tComboEditor_CommentDspDiv.Value = pccCmpnySt.CommentDspDiv;
            //出荷数表示区分
            this.tComboEditor_SpmtCntDspDiv.Value = pccCmpnySt.SpmtCntDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //this.tComboEditor_AcptCntDspDiv.Value = pccCmpnySt.AcptCntDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分
            this.tComboEditor_PrtSelGdNoDspDiv.Value = pccCmpnySt.PrtSelGdNoDspDiv;
            //部品選択標準価格表示区分
            this.tComboEditor_PrtSelLsPrDspDiv.Value = pccCmpnySt.PrtSelLsPrDspDiv;
            //部品選択棚番表示区分
            this.tComboEditor_PrtSelSelfDspDiv.Value = pccCmpnySt.PrtSelSelfDspDiv;
            //在庫コメント1
            this.tEdit_StckStComment1.Value = pccCmpnySt.StckStComment1;
            //在庫コメント2
            this.tEdit_StckStComment2.Value = pccCmpnySt.StckStComment2;
            //在庫コメント3
            this.tEdit_StckStComment3.Value = pccCmpnySt.StckStComment3;
            //PCC発注先名称1
            this.tEdit_PccSuplName1.Value = pccCmpnySt.PccSuplName1;
            //PCC発注先名称2
            this.tEdit_PccSuplName2.Value = pccCmpnySt.PccSuplName2;
            //PCC発注先カナ名称
            this.tEdit_PccSuplKana.Value = pccCmpnySt.PccSuplKana;
            //PCC発注先略称
            this.tEdit_PccSuplSnm.Value = pccCmpnySt.PccSuplSnm;
            //PCC発注先郵便番号
            this.tEdit_PccSuplPostNo.Value = pccCmpnySt.PccSuplPostNo;
            //PCC発注先住所1
            this.tEdit_PccSuplAddr1.Value = pccCmpnySt.PccSuplAddr1;
            //PCC発注先住所2
            this.tEdit_PccSuplAddr2.Value = pccCmpnySt.PccSuplAddr2;
            //PCC発注先住所3
            this.tEdit_PccSuplAddr3.Value = pccCmpnySt.PccSuplAddr3;
            //PCC発注先電話番号1
            this.tEdit_PccSuplTelNo1.Value = pccCmpnySt.PccSuplTelNo1;
            //PCC発注先電話番号2
            this.tEdit_PccSuplTelNo2.Value = pccCmpnySt.PccSuplTelNo2;
            //PCC発注先FAX番号
            this.tEdit_PccSuplFaxNo.Value = pccCmpnySt.PccSuplFaxNo;
            //伝票発行区分（PCC）
            this.tComboEditor_PccSlipPrtDiv.Value = pccCmpnySt.PccSlipPrtDiv;

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //this.tComboEditor_StockDspDiv.Value = pccCmpnySt.StockDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            this.tComboEditor_WarehouseDspDiv.Value = pccCmpnySt.WarehouseDspDiv;
            //取消表示区分(問合せ)
            this.tComboEditor_CancelDspDiv.Value = pccCmpnySt.CancelDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(問合せ）
            //this.tComboEditor_PrtSelStckDspDiv.Value = pccCmpnySt.PrtSelStckDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //品番表示区分(発注)
            this.tComboEditor_GoodsNoDspDivOd.Value = pccCmpnySt.GoodsNoDspDivOd;
            //標準価格表示区分(発注)
            this.tComboEditor_ListPrcDspDivOd.Value = pccCmpnySt.ListPrcDspDivOd;
            //仕切価格表示区分(発注)
            this.tComboEditor_CostDspDivOd.Value = pccCmpnySt.CostDspDivOd;
            //棚番表示区分(発注)
            this.tComboEditor_ShelfDspDivOd.Value = pccCmpnySt.ShelfDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //this.tComboEditor_StockDspDivOd.Value = pccCmpnySt.StockDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            this.tComboEditor_CommentDspDivOd.Value = pccCmpnySt.CommentDspDivOd;
            //出荷数表示区分(発注)
            this.tComboEditor_SpmtCntDspDivOd.Value = pccCmpnySt.SpmtCntDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //this.tComboEditor_AcptCntDspDivOd.Value = pccCmpnySt.AcptCntDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            this.tComboEditor_PrtSelGdNoDspDivOd.Value = pccCmpnySt.PrtSelGdNoDspDivOd;
            //部品選択標準価格表示区分(発注)
            this.tComboEditor_PrtSelLsPrDspDivOd.Value = pccCmpnySt.PrtSelLsPrDspDivOd;
            //部品選択棚番表示区分(発注)
            this.tComboEditor_PrtSelSelfDspDivOd.Value = pccCmpnySt.PrtSelSelfDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //this.tComboEditor_PrtSelStckDspDivOd.Value = pccCmpnySt.PrtSelStckDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            this.tComboEditor_WarehouseDspDivOd.Value = pccCmpnySt.WarehouseDspDivOd;
            //取消表示区分(発注)
            this.tComboEditor_CancelDspDivOd.Value = pccCmpnySt.CancelDspDivOd;
            //問合せ発注表示区分設定
            this.tComboEditor_InqOdrDspDivSet.Value = pccCmpnySt.InqOdrDspDivSet;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            this.tComboEditor_PrsntStkCtDspDivOd.Value = pccCmpnySt.PrsntStkCtDspDivOd;
            //現在庫数表示区分(問合せ)
            this.tComboEditor_PrsntStkCtDspDiv.Value = pccCmpnySt.PrsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            this.tComboEditor_AnsDeliDtDspDiv.Value = pccCmpnySt.AnsDeliDtDspDiv;
            // 回答納期表示区分(発注)
            this.tComboEditor_AnsDeliDtDspDivOd.Value = pccCmpnySt.AnsDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC自社設定マスタクラス画面展開処理
        /// </summary>
        /// <param name="commColumn">PCC自社設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PccCmpnyStToScreenForQuote(PccCmpnySt pccCmpnySt)
        {
           
            //PCC倉庫コード
            int pccWarehouseCd = 0;
            Int32.TryParse(pccCmpnySt.PccWarehouseCd, out pccWarehouseCd);
            this.tNedit_PccWarehouseCd.SetInt(pccWarehouseCd);
            //PCC優先倉庫コード1
            int pccPriWarehouseCd1 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd1, out pccPriWarehouseCd1);
            this.tNedit_PccPriWarehouseCd1.SetInt(pccPriWarehouseCd1);
            //PCC優先倉庫コード2
            int pccPriWarehouseCd2 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd2, out pccPriWarehouseCd2);
            this.tNedit_PccPriWarehouseCd2.SetInt(pccPriWarehouseCd2);
            //PCC優先倉庫コード3
            int pccPriWarehouseCd3 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd3, out pccPriWarehouseCd3);
            this.tNedit_PccPriWarehouseCd3.SetInt(pccPriWarehouseCd3);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            int pccPriWarehouseCd4 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd4, out pccPriWarehouseCd4);
            this.tNedit_PccPriWarehouseCd4.SetInt(pccPriWarehouseCd4);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            this.tComboEditor_GoodsNoDspDiv.Value = pccCmpnySt.GoodsNoDspDiv;
            //標準価格表示区分
            this.tComboEditor_ListPrcDspDiv.Value = pccCmpnySt.ListPrcDspDiv;
            //仕切価格表示区分
            this.tComboEditor_CostDspDiv.Value = pccCmpnySt.CostDspDiv;
            //棚番表示区分
            this.tComboEditor_ShelfDspDiv.Value = pccCmpnySt.ShelfDspDiv;
            //コメント表示区分
            this.tComboEditor_CommentDspDiv.Value = pccCmpnySt.CommentDspDiv;
            //出荷数表示区分
            this.tComboEditor_SpmtCntDspDiv.Value = pccCmpnySt.SpmtCntDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //this.tComboEditor_AcptCntDspDiv.Value = pccCmpnySt.AcptCntDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分
            this.tComboEditor_PrtSelGdNoDspDiv.Value = pccCmpnySt.PrtSelGdNoDspDiv;
            //部品選択標準価格表示区分
            this.tComboEditor_PrtSelLsPrDspDiv.Value = pccCmpnySt.PrtSelLsPrDspDiv;
            //部品選択棚番表示区分
            this.tComboEditor_PrtSelSelfDspDiv.Value = pccCmpnySt.PrtSelSelfDspDiv;
            //在庫コメント1
            this.tEdit_StckStComment1.Value = pccCmpnySt.StckStComment1;
            //在庫コメント2
            this.tEdit_StckStComment2.Value = pccCmpnySt.StckStComment2;
            //在庫コメント3
            this.tEdit_StckStComment3.Value = pccCmpnySt.StckStComment3;
            //PCC発注先名称1
            this.tEdit_PccSuplName1.Value = pccCmpnySt.PccSuplName1;
            //PCC発注先名称2
            this.tEdit_PccSuplName2.Value = pccCmpnySt.PccSuplName2;
            //PCC発注先カナ名称
            this.tEdit_PccSuplKana.Value = pccCmpnySt.PccSuplKana;
            //PCC発注先略称
            this.tEdit_PccSuplSnm.Value = pccCmpnySt.PccSuplSnm;
            //PCC発注先郵便番号
            this.tEdit_PccSuplPostNo.Value = pccCmpnySt.PccSuplPostNo;
            //PCC発注先住所1
            this.tEdit_PccSuplAddr1.Value = pccCmpnySt.PccSuplAddr1;
            //PCC発注先住所2
            this.tEdit_PccSuplAddr2.Value = pccCmpnySt.PccSuplAddr2;
            //PCC発注先住所3
            this.tEdit_PccSuplAddr3.Value = pccCmpnySt.PccSuplAddr3;
            //PCC発注先電話番号1
            this.tEdit_PccSuplTelNo1.Value = pccCmpnySt.PccSuplTelNo1;
            //PCC発注先電話番号2
            this.tEdit_PccSuplTelNo2.Value = pccCmpnySt.PccSuplTelNo2;
            //PCC発注先FAX番号
            this.tEdit_PccSuplFaxNo.Value = pccCmpnySt.PccSuplFaxNo;
            //伝票発行区分（PCC）
            this.tComboEditor_PccSlipPrtDiv.Value = pccCmpnySt.PccSlipPrtDiv;

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //this.tComboEditor_StockDspDiv.Value = pccCmpnySt.StockDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            this.tComboEditor_WarehouseDspDiv.Value = pccCmpnySt.WarehouseDspDiv;
            //取消表示区分(問合せ)
            this.tComboEditor_CancelDspDiv.Value = pccCmpnySt.CancelDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(問合せ)
            //this.tComboEditor_PrtSelStckDspDiv.Value = pccCmpnySt.PrtSelStckDspDiv;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //品番表示区分(発注)
            this.tComboEditor_GoodsNoDspDivOd.Value = pccCmpnySt.GoodsNoDspDivOd;
            //標準価格表示区分(発注)
            this.tComboEditor_ListPrcDspDivOd.Value = pccCmpnySt.ListPrcDspDivOd;
            //仕切価格表示区分(発注)
            this.tComboEditor_CostDspDivOd.Value = pccCmpnySt.CostDspDivOd;
            //棚番表示区分(発注)
            this.tComboEditor_ShelfDspDivOd.Value = pccCmpnySt.ShelfDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //this.tComboEditor_StockDspDivOd.Value = pccCmpnySt.StockDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            this.tComboEditor_CommentDspDivOd.Value = pccCmpnySt.CommentDspDivOd;
            //出荷数表示区分(発注)
            this.tComboEditor_SpmtCntDspDivOd.Value = pccCmpnySt.SpmtCntDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //this.tComboEditor_AcptCntDspDivOd.Value = pccCmpnySt.AcptCntDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            this.tComboEditor_PrtSelGdNoDspDivOd.Value = pccCmpnySt.PrtSelGdNoDspDivOd;
            //部品選択標準価格表示区分(発注)
            this.tComboEditor_PrtSelLsPrDspDivOd.Value = pccCmpnySt.PrtSelLsPrDspDivOd;
            //部品選択棚番表示区分(発注)
            this.tComboEditor_PrtSelSelfDspDivOd.Value = pccCmpnySt.PrtSelSelfDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //this.tComboEditor_PrtSelStckDspDivOd.Value = pccCmpnySt.PrtSelStckDspDivOd;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            this.tComboEditor_WarehouseDspDivOd.Value = pccCmpnySt.WarehouseDspDivOd;
            //取消表示区分(発注)
            this.tComboEditor_CancelDspDivOd.Value = pccCmpnySt.CancelDspDivOd;
            //問合せ発注表示区分設定
            this.tComboEditor_InqOdrDspDivSet.Value = pccCmpnySt.InqOdrDspDivSet;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            this.tComboEditor_PrsntStkCtDspDivOd.Value = pccCmpnySt.PrsntStkCtDspDivOd;
            //現在庫数表示区分(問合せ)
            this.tComboEditor_PrsntStkCtDspDiv.Value = pccCmpnySt.PrsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            this.tComboEditor_AnsDeliDtDspDiv.Value = pccCmpnySt.AnsDeliDtDspDiv;
            // 回答納期表示区分(発注)
            this.tComboEditor_AnsDeliDtDspDivOd.Value = pccCmpnySt.AnsDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// Valueチェック処理（string）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private string ValueToString(object sorce)
        {
            string dest = string.Empty;
            try
            {
                if (sorce != null)
                {
                    dest = Convert.ToString(sorce);
                }
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                if (sorce != null)
                {
                    Int32.TryParse(sorce.ToString(), out dest);
                }
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// 画面情報PCC自社設定マスタクラス格納処理
        /// </summary>
        /// <param name="commColumn">PCC自社設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から部門オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DispToPccCmpnySt(ref PccCmpnySt pccCmpnySt)
        {
            //問合せ元企業コード
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            //問合せ元拠点コード
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            //問合せ先企業コード
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            //問合せ先拠点コード
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
             //PCC自社コード
            pccCmpnySt.PccCompanyCode = this.tNedit_PccCompanyCode.GetInt();
            //PCC倉庫コード
            pccCmpnySt.PccWarehouseCd = this.ValueToString(this.tNedit_PccWarehouseCd.Value);
            //PCC優先倉庫コード1
            pccCmpnySt.PccPriWarehouseCd1 = this.ValueToString(this.tNedit_PccPriWarehouseCd1.Value);
            //PCC優先倉庫コード2
            pccCmpnySt.PccPriWarehouseCd2 = this.ValueToString(this.tNedit_PccPriWarehouseCd2.Value);
            //PCC優先倉庫コード3
            pccCmpnySt.PccPriWarehouseCd3 = this.ValueToString(this.tNedit_PccPriWarehouseCd3.Value);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            pccCmpnySt.PccPriWarehouseCd4 = this.ValueToString(this.tNedit_PccPriWarehouseCd4.Value);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            pccCmpnySt.GoodsNoDspDiv = this.ValueToInt(this.tComboEditor_GoodsNoDspDiv.Value);
            //標準価格表示区分
            pccCmpnySt.ListPrcDspDiv = this.ValueToInt(this.tComboEditor_ListPrcDspDiv.Value);
            //仕切価格表示区分
            pccCmpnySt.CostDspDiv = this.ValueToInt(this.tComboEditor_CostDspDiv.Value);
            //棚番表示区分
            pccCmpnySt.ShelfDspDiv = this.ValueToInt(this.tComboEditor_ShelfDspDiv.Value);
            //コメント表示区分
            pccCmpnySt.CommentDspDiv = this.ValueToInt(this.tComboEditor_CommentDspDiv.Value);
            //出荷数表示区分
            pccCmpnySt.SpmtCntDspDiv = this.ValueToInt(this.tComboEditor_SpmtCntDspDiv.Value);
            //受注数表示区分
            pccCmpnySt.AcptCntDspDiv = 1;
            //部品選択品番表示区分
            pccCmpnySt.PrtSelGdNoDspDiv = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDiv.Value);
            //部品選択標準価格表示区分
            pccCmpnySt.PrtSelLsPrDspDiv = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDiv.Value);
            //部品選択棚番表示区分
            pccCmpnySt.PrtSelSelfDspDiv = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDiv.Value);
            //在庫状況コメント1
            pccCmpnySt.StckStComment1 = this.ValueToString(this.tEdit_StckStComment1.Value);
            //在庫状況コメント2
            pccCmpnySt.StckStComment2 = this.ValueToString(this.tEdit_StckStComment2.Value);
            //在庫状況コメント3
            pccCmpnySt.StckStComment3 = this.ValueToString(this.tEdit_StckStComment3.Value);
            //PCC発注先名称1
            pccCmpnySt.PccSuplName1 = this.ValueToString(this.tEdit_PccSuplName1.Value);
            //PCC発注先名称2
            pccCmpnySt.PccSuplName2 = this.ValueToString(this.tEdit_PccSuplName2.Value);
            //PCC発注先カナ名称
            pccCmpnySt.PccSuplKana = this.ValueToString(this.tEdit_PccSuplKana.Value);
            //PCC発注先略称
            pccCmpnySt.PccSuplSnm = this.ValueToString(this.tEdit_PccSuplSnm.Value);
            //PCC発注先郵便番号
            pccCmpnySt.PccSuplPostNo = this.ValueToString(this.tEdit_PccSuplPostNo.Value);
            //PCC発注先住所1
            pccCmpnySt.PccSuplAddr1 = this.ValueToString(this.tEdit_PccSuplAddr1.Value);
            //PCC発注先住所2
            pccCmpnySt.PccSuplAddr2 = this.ValueToString(this.tEdit_PccSuplAddr2.Value);
            //PCC発注先住所3
            pccCmpnySt.PccSuplAddr3 = this.ValueToString(this.tEdit_PccSuplAddr3.Value);
            //PCC発注先電話番号1
            pccCmpnySt.PccSuplTelNo1 = this.ValueToString(this.tEdit_PccSuplTelNo1.Value);
            //PCC発注先電話番号2
            pccCmpnySt.PccSuplTelNo2 = this.ValueToString(this.tEdit_PccSuplTelNo2.Value);
            //PCC発注先FAX番号
            pccCmpnySt.PccSuplFaxNo = this.ValueToString(this.tEdit_PccSuplFaxNo.Value);
            //伝票発行区分（PCC）
            pccCmpnySt.PccSlipPrtDiv = this.ValueToInt(this.tComboEditor_PccSlipPrtDiv.Value);

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            //問合せ発注表示区分設定
            pccCmpnySt.InqOdrDspDivSet = this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value);

            // 問合せ発注共通の時
            if (pccCmpnySt.InqOdrDspDivSet.Equals(INQODRCOMMON))
            {
                //在庫表示区分(問合せ)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.StockDspDiv = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDiv = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //倉庫表示区分(問合せ)
                pccCmpnySt.WarehouseDspDiv = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //取消表示区分(問合せ)
                pccCmpnySt.CancelDspDiv = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                //部品選択在庫表示区分(問合せ)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDiv = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDiv = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //品番表示区分(発注)
                pccCmpnySt.GoodsNoDspDivOd = this.ValueToInt(this.tComboEditor_GoodsNoDspDiv.Value);
                //標準価格表示区分(発注)
                pccCmpnySt.ListPrcDspDivOd = this.ValueToInt(this.tComboEditor_ListPrcDspDiv.Value);
                //仕切価格表示区分(発注)
                pccCmpnySt.CostDspDivOd = this.ValueToInt(this.tComboEditor_CostDspDiv.Value);
                //棚番表示区分(発注)
                pccCmpnySt.ShelfDspDivOd = this.ValueToInt(this.tComboEditor_ShelfDspDiv.Value);
                //在庫表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.StockDspDivOd = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //コメント表示区分(発注)
                pccCmpnySt.CommentDspDivOd = this.ValueToInt(this.tComboEditor_CommentDspDiv.Value);
                //出荷数表示区分(発注)
                pccCmpnySt.SpmtCntDspDivOd = this.ValueToInt(this.tComboEditor_SpmtCntDspDiv.Value);
                //受注数表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.AcptCntDspDivOd = this.ValueToInt(this.tComboEditor_AcptCntDspDiv.Value);
                pccCmpnySt.AcptCntDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //部品選択品番表示区分(発注)
                pccCmpnySt.PrtSelGdNoDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDiv.Value);
                //部品選択標準価格表示区分(発注)
                pccCmpnySt.PrtSelLsPrDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDiv.Value);
                //部品選択棚番表示区分(発注)
                pccCmpnySt.PrtSelSelfDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDiv.Value);
                //部品選択在庫表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //倉庫表示区分(発注)
                pccCmpnySt.WarehouseDspDivOd = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //取消表示区分(発注)
                pccCmpnySt.CancelDspDivOd = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(問合せ)
                pccCmpnySt.PrsntStkCtDspDiv = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                //現在庫数表示区分(発注)
                pccCmpnySt.PrsntStkCtDspDivOd = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                pccCmpnySt.AnsDeliDtDspDiv = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // 回答納期表示区分(発注)
                // 2014/10/22 UPD TAKAGAWA 表示区分が問合せ発注共通で回答納期表示区分を設定しても、発注の区分が設定されない件の対応 ---------->>>>>>>>>>
                //pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDivOd.Value);
                pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // 2014/10/22 UPD TAKAGAWA 表示区分が問合せ発注共通で回答納期表示区分を設定しても、発注の区分が設定されない件の対応 ----------<<<<<<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            }
            // 問合せ発注個別の時
            else
            {
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //在庫表示区分(問合せ)
                //pccCmpnySt.StockDspDiv = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDiv = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //倉庫表示区分(問合せ)
                pccCmpnySt.WarehouseDspDiv = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //取消表示区分(問合せ)
                pccCmpnySt.CancelDspDiv = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                //部品選択在庫表示区分(問合せ)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDiv = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDiv = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //品番表示区分(発注)
                pccCmpnySt.GoodsNoDspDivOd = this.ValueToInt(this.tComboEditor_GoodsNoDspDivOd.Value);
                //標準価格表示区分(発注)
                pccCmpnySt.ListPrcDspDivOd = this.ValueToInt(this.tComboEditor_ListPrcDspDivOd.Value);
                //仕切価格表示区分(発注)
                pccCmpnySt.CostDspDivOd = this.ValueToInt(this.tComboEditor_CostDspDivOd.Value);
                //棚番表示区分(発注)
                pccCmpnySt.ShelfDspDivOd = this.ValueToInt(this.tComboEditor_ShelfDspDivOd.Value);
                //在庫表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.StockDspDivOd = this.ValueToInt(this.tComboEditor_StockDspDivOd.Value);
                pccCmpnySt.StockDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //コメント表示区分(発注)
                pccCmpnySt.CommentDspDivOd = this.ValueToInt(this.tComboEditor_CommentDspDivOd.Value);
                //出荷数表示区分(発注)
                pccCmpnySt.SpmtCntDspDivOd = this.ValueToInt(this.tComboEditor_SpmtCntDspDivOd.Value);
                //受注数表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.AcptCntDspDivOd = this.ValueToInt(this.tComboEditor_AcptCntDspDivOd.Value);
                pccCmpnySt.AcptCntDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
                //部品選択品番表示区分(発注)
                pccCmpnySt.PrtSelGdNoDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDivOd.Value);
                //部品選択標準価格表示区分(発注)
                pccCmpnySt.PrtSelLsPrDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDivOd.Value);
                //部品選択棚番表示区分(発注)
                pccCmpnySt.PrtSelSelfDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDivOd.Value);
                //部品選択在庫表示区分(発注)
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelStckDspDivOd.Value);
                pccCmpnySt.PrtSelStckDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
                //倉庫表示区分(発注)
                pccCmpnySt.WarehouseDspDivOd = this.ValueToInt(this.tComboEditor_WarehouseDspDivOd.Value);
                //取消表示区分(発注)
                pccCmpnySt.CancelDspDivOd = this.ValueToInt(this.tComboEditor_CancelDspDivOd.Value);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                //現在庫数表示区分(発注)
                pccCmpnySt.PrsntStkCtDspDivOd = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDivOd.Value);
                //現在庫数表示区分(問合せ)
                pccCmpnySt.PrsntStkCtDspDiv = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                // 回答納期表示区分(問合せ)
                pccCmpnySt.AnsDeliDtDspDiv = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // 回答納期表示区分(発注)
                pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDivOd.Value);
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            }
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
           
            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : PCC自社設定マスタの保存処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
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

            // PCC自社設定マスタ更新
            if (!SavePccCmpnySt())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PCC自社設定マスタテーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : PccCmpnyStテーブルの更新を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool SavePccCmpnySt()
        {
            Control control = null;
            PccCmpnySt pccCmpnySt = new PccCmpnySt();

            // 登録レコード情報取得
            if (this._detailsIndexBuf >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            }

            // PccCmpnyStクラスにデータを格納
            DispToPccCmpnySt(ref pccCmpnySt);
            List<PccCmpnySt> pccCmpnyStList = new  List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            // PccCmpnyStクラスをアクセスクラスに渡して登録・更新
            int status = this._pccCmpnyStAcs.Write(ref pccCmpnyStList);

            // エラー処理
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash更新処理
                    DetailsToDataSet(pccCmpnyStList[0], this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCmpnyStAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "SavePccCmpnySt",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccCmpnyStAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return false;
                    }
                default:
                    // 登録失敗
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "SavePccCmpnySt",			// 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_UPDT_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCmpnyStAcs,		// エラーが発生したオブジェクト
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
        /// PCC自社設定マスタ 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタの対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int LogicalDeletePccCmpnySt()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 削除対象PCC自社設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            status = this._pccCmpnyStAcs.LogicalDelete(ref pccCmpnyStList);
            pccCmpnySt = pccCmpnyStList[0] as PccCmpnySt;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DetailsToDataSet(pccCmpnySt, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pccCmpnyStAcs);
                    // フレーム更新
                    DetailsToDataSet(pccCmpnyStList[0], _dataIndex);
                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "LogicalDeletePccCmpnySt",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccCmpnyStAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // フレーム更新
                        DetailsToDataSet(pccCmpnySt, _dataIndex);

                        return status;
                    }
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "LogicalDeletePccCmpnySt",	// 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pccCmpnyStAcs,		// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // フレーム更新
                    DetailsToDataSet(pccCmpnySt, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PCC自社設定マスタ 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタの対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int PhysicalDeleteCampaignRate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            // 削除対象PCC自社設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            // 物理削除
            status = this._pccCmpnyStAcs.Delete(ref pccCmpnyStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DeleteFromDataSet(pccCmpnyStList[0], _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccCmpnyStAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "PhysicalDeleteCampaignRate",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccCmpnyStAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return status;
                    }
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
                        this._pccCmpnyStAcs,		// エラーが発生したオブジェクト
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
        /// PCC自社設定マスタ 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタの対象レコードを復活します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int ReviveSharedPartsAddInfo()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 復活対象PCC自社設定マスタ取得
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            
            // 復活
            status = this._pccCmpnyStAcs.RevivalLogicalDelete(ref pccCmpnyStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet展開処理
                    DetailsToDataSet(pccCmpnyStList[0], this._dataIndex);
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCmpnyStAcs);
                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "ReviveSharedPartsAddInfo",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_TIMEOUT_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._pccCmpnyStAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                        // PCC品目クラスデータセット展開処理
                        return status;
                    }
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
                        this._pccCmpnyStAcs,		// エラーが発生したオブジェクト
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
        /// <br>Date       : 2011.08.04 </br>
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
        /// <br>Date       : 2011.08.04 </br>
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
        /// <br>Date       : 2011.08.04 </br>
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
            control = this.tNedit_CustomerCode;
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
        /// <br>Date       : 2011.08.04 </br>
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
        /// 画面のクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面のクリアを行う</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ClearAll()
        {
            //得意先コード
            this.tNedit_CustomerCode.SetInt(0);
            //得意先名称
            this.uLabel_CustomerName.Text = string.Empty;
            //PCC自社コード
            this.tNedit_PccCompanyCode.SetInt(0);
            //PCC倉庫コード
            this.tNedit_PccWarehouseCd.SetInt(0);
            //PCC優先倉庫コード1
            this.tNedit_PccPriWarehouseCd1.SetInt(0);
            //PCC優先倉庫コード2
            this.tNedit_PccPriWarehouseCd2.SetInt(0);
            //PCC優先倉庫コード3
            this.tNedit_PccPriWarehouseCd3.SetInt(0);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            this.tNedit_PccPriWarehouseCd4.SetInt(0);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            //品番表示区分
            this.tComboEditor_GoodsNoDspDiv.SelectedIndex = 0;
            //標準価格表示区分
            this.tComboEditor_ListPrcDspDiv.SelectedIndex = 0;
            //仕切価格表示区分
            this.tComboEditor_CostDspDiv.SelectedIndex = 0;
            //棚番表示区分
            this.tComboEditor_ShelfDspDiv.SelectedIndex = 0;
            //コメント表示区分
            this.tComboEditor_CommentDspDiv.SelectedIndex = 0;
            //出荷数表示区分
            this.tComboEditor_SpmtCntDspDiv.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分
            //this.tComboEditor_AcptCntDspDiv.SelectedIndex = 1;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分
            this.tComboEditor_PrtSelGdNoDspDiv.SelectedIndex = 0;
            //部品選択標準価格表示区分
            this.tComboEditor_PrtSelLsPrDspDiv.SelectedIndex = 0;
            //部品選択棚番表示区分
            this.tComboEditor_PrtSelSelfDspDiv.SelectedIndex = 0;
            //在庫状況コメント1
            this.tEdit_StckStComment1.Text = "在庫あり";
            //在庫状況コメント2
            this.tEdit_StckStComment2.Text = "在庫なし";
            //在庫状況コメント3
            this.tEdit_StckStComment3.Text = "在庫不足";
            //PCC発注先名称1
            this.tEdit_PccSuplName1.Text = string.Empty;
            //PCC発注先名称2
            this.tEdit_PccSuplName2.Text = string.Empty;
            //PCC発注先カナ名称
            this.tEdit_PccSuplKana.Text = string.Empty;
            //PCC発注先略称
            this.tEdit_PccSuplSnm.Text = string.Empty;
            //PCC発注先郵便番号
            this.tEdit_PccSuplPostNo.Text = string.Empty;
            //PCC発注先住所1
            this.tEdit_PccSuplAddr1.Text = string.Empty;
            //PCC発注先住所2
            this.tEdit_PccSuplAddr2.Text = string.Empty;
            //PCC発注先住所3
            this.tEdit_PccSuplAddr3.Text = string.Empty;
            //PCC発注先電話番号1
            this.tEdit_PccSuplTelNo1.Text = string.Empty;
            //PCC発注先電話番号2
            this.tEdit_PccSuplTelNo2.Text = string.Empty;
            //PCC発注先FAX番号
            this.tEdit_PccSuplFaxNo.Text = string.Empty;
            //伝票発行区分（PCC）
            this.tComboEditor_PccSlipPrtDiv.SelectedIndex = 0;
            this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
            //前得意先コード
            this._customerCodePre = -1;
            //前得意先名称
            this._customerNamePre = string.Empty;
            this._inqOriginalEpCdPre = string.Empty;
            this._inqOriginalSecCdPre = string.Empty;

            // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(問合せ)
            //this.tComboEditor_StockDspDiv.SelectedIndex = 0;
            ////部品選択在庫表示区分(問合せ)
            //this.tComboEditor_PrtSelStckDspDiv.SelectedIndex = 0;
            ////部品選択在庫表示区分(問合せ)
            //this.tComboEditor_PrtSelStckDspDiv.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(問合せ)
            this.tComboEditor_WarehouseDspDiv.SelectedIndex = 0;
            //取消表示区分(問合せ)
            this.tComboEditor_CancelDspDiv.SelectedIndex = 0;
            //品番表示区分(発注)
            this.tComboEditor_GoodsNoDspDivOd.SelectedIndex = 0;
            //標準価格表示区分(発注)
            this.tComboEditor_ListPrcDspDivOd.SelectedIndex = 0;
            //仕切価格表示区分(発注)
            this.tComboEditor_CostDspDivOd.SelectedIndex = 0;
            //棚番表示区分(発注)
            this.tComboEditor_ShelfDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////在庫表示区分(発注)
            //this.tComboEditor_StockDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //コメント表示区分(発注)
            this.tComboEditor_CommentDspDivOd.SelectedIndex = 0;
            //出荷数表示区分(発注)
            this.tComboEditor_SpmtCntDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////受注数表示区分(発注)
            //this.tComboEditor_AcptCntDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //部品選択品番表示区分(発注)
            this.tComboEditor_PrtSelGdNoDspDivOd.SelectedIndex = 0;
            //部品選択標準価格表示区分(発注)
            this.tComboEditor_PrtSelLsPrDspDivOd.SelectedIndex = 0;
            //部品選択棚番表示区分(発注)
            this.tComboEditor_PrtSelSelfDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 ----------------------->>>>>
            ////部品選択在庫表示区分(発注)
            //this.tComboEditor_PrtSelStckDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06配信 システムテスト障害対応 -----------------------<<<<<
            //倉庫表示区分(発注)
            this.tComboEditor_WarehouseDspDivOd.SelectedIndex = 0;
            //取消表示区分(発注)
            this.tComboEditor_CancelDspDivOd.SelectedIndex = 0;
            //問合せ発注表示区分設定
            this.tComboEditor_InqOdrDspDivSet.SelectedIndex = 0;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            // 現在庫数表示区分(問合せ)
            this.tComboEditor_PrsntStkCtDspDiv.SelectedIndex = 0;
            // 現在庫数表示区分(発注)
            this.tComboEditor_PrsntStkCtDspDivOd.SelectedIndex = 0;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            this.tComboEditor_AnsDeliDtDspDiv.SelectedIndex = 0;
            // 回答納期表示区分(発注)
            this.tComboEditor_AnsDeliDtDspDivOd.SelectedIndex = 0;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// 引用ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 引用ボタン処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void QuoteButtonProc()
        {

            _pMPCC09010UB = new PMPCC09010UB(this._detailsTable);
            string inqCondition = string.Empty;
            this._pMPCC09010UB.ShowDialog();
            DialogResult dialogResult = this._pMPCC09010UB.DialogResult;
            PccCmpnySt parsePccCmpnySt = null;
            int customerCode = this.tNedit_CustomerCode.GetInt();

            if (DialogResult.OK == dialogResult)
            {
                inqCondition = this._pMPCC09010UB.PccInqCondition;
                if (this._detailsTable != null && this._detailsTable.ContainsKey(inqCondition))
                {
                    parsePccCmpnySt = this._detailsTable[inqCondition] as PccCmpnySt;
                }
                if (parsePccCmpnySt != null)
                {
                    // 画面展開処理
                    PccCmpnyStToScreenForQuote(parsePccCmpnySt);
                }

            }

        }

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        /// <summary>
        ///  オプションチェック：BLP参照倉庫追加オプション
        /// </summary>
        /// <returns></returns>
        private bool GetBLPPriWareHouseOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                 ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse
            );
            return status.Equals(PurchaseStatus.Contract) ? true : false;
        }
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<


        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.UltraButton_Quote.ImageList = imageList25;
            this.SetIconImage(this.UButton_CustomerGuide, Size16_Index.STAR1);
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.UltraButton_Quote.Appearance.Image = Size24_Index.ADJUST;
            this.PictureBox_type();// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            this.PictureBox2_type();
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
        /// <summary>
        /// 「状況表示」のヒント表示の設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 「状況表示」のヒント表示の設定処理します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2014/07/23</br>
        /// </remarks>
        private void PictureBox_type()
        {
            this.pictureBox1.Image
                    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.pictureBox1.Visible = true;

            UltraToolTipInfo toolTipInfo = this.ultraToolTipManager2.GetUltraToolTip(this.pictureBox1);
            toolTipInfo.Enabled = Infragistics.Win.DefaultableBoolean.True;

            toolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Custom;

            toolTipInfo.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
         
            this.ultraToolTipManager2.Appearance.FontData.SizeInPoints = 11f;
            this.ultraToolTipManager2.Appearance.FontData.Name = "ＭＳ ゴシック";
            this.ultraToolTipManager2.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager2.AutoPopDelay = 0;

    
            toolTipInfo.ToolTipTitleAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            toolTipInfo.ToolTipTitle = "「状況表示」について";

            toolTipInfo.ToolTipText = "\n取引先で以下の内容を表示します。"
                                      + "\n \n取り寄せ・・・・現在庫数がない場合"
                                      + "\n在庫不足・・・・現在庫数が問合せ数未満の場合"
                                      + "\n在庫残少・・・・現在庫数が在庫マスタで設定された最低在庫数未満になる場合"
                                      + "\n在庫豊富・・・・現在庫数が在庫マスタで設定された最低在庫数以上の場合"
                                      + "\n該当なし・・・・問合せに該当する部品がない場合"
                                      + "\n \n \n ";
        
        }
        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        /// <summary>
        /// 「回答納期表示区分」のヒント表示の設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 「回答納期表示区分」のヒント表示の設定処理します。</br>
        /// <br>Programmer	: 30746 高川 悟</br>
        /// <br>Date		: 2014/09/04</br>
        /// </remarks>
        private void PictureBox2_type()
        {
            this.pictureBox2.Image
                    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.pictureBox2.Visible = true;

            UltraToolTipInfo toolTipInfo = this.ultraToolTipManager2.GetUltraToolTip(this.pictureBox2);
            toolTipInfo.Enabled = Infragistics.Win.DefaultableBoolean.True;

            toolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Custom;

            toolTipInfo.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.ultraToolTipManager2.Appearance.FontData.SizeInPoints = 11f;
            this.ultraToolTipManager2.Appearance.FontData.Name = "ＭＳ ゴシック";
            this.ultraToolTipManager2.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager2.AutoPopDelay = 0;


            toolTipInfo.ToolTipTitleAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            toolTipInfo.ToolTipTitle = "「回答納期表示区分」について";

            toolTipInfo.ToolTipText = "\n「CarpodTab 車検コース提案サービス」のみに適用されます。";

        }
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        /// <summary>
        /// Form.Closing イベント(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Control.VisibleChanged イベント(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Date       : 2011.08.04 </br>
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                // 現在の画面情報を取得
                PccCmpnySt pccCmpnySt = new PccCmpnySt();
                pccCmpnySt = this._pccCmpnySt.Clone();
                DispToPccCmpnySt(ref pccCmpnySt);
                // 最初に取得した画面情報と比較
                cloneFlg = this._pccCmpnySt.Equals(pccCmpnySt);

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
                                this.tNedit_CustomerCode.Focus();
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
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
                // PCC自社設定マスタ物理削除
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSharedPartsAddInfo();
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 引用ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void UltraButton_Quote_Click(object sender, EventArgs e)
        {
            this.QuoteButtonProc();
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            _modeFlg = false;
            int customerCode = this.tNedit_CustomerCode.GetInt();
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    if (_customerCodePre != customerCode)
                    {
                        // PCC自社設定マスタメンテコードコードにフォーカスがある場合
                        if (customerCode != 0)
                        {
                            if (e.NextCtrl.Name == "Cancel_Button")
                            {
                                // 遷移先が閉じるボタン
                                _modeFlg = true;
                            }
                            else
                            {
                                //得意先情報を取得
                                CustomerInfo customerInfo;
                                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                                {
                                    //前問合せ元企業コード
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //前問合せ元拠点コード
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    if (customerInfo.OnlineKindDiv == ONLINEKINDDIV)
                                    {
                                        if (ModeChangeProc(customerInfo))
                                        {
                                            if (this._dataIndex < 0 && this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = tNedit_CustomerCode;
                                            }
                                        }
                                        else
                                        {
                                            //問合せ元企業コード
                                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                            //問合せ元拠点コード
                                            this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                            this.tNedit_PccCompanyCode.SetInt(customerCode);
                                            //前問合せ元企業コード
                                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                            //前問合せ元拠点コード
                                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                            //前得意先コード
                                            this._customerCodePre = customerCode;
                                            //前得意先名称
                                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                        }
                                    }
                                    else
                                    {
                                        // エラー時
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "得意先コード [" + customerInfo.CustomerCode + "] は設定できません。\r\nオンライン情報を確認して下さい。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        if (this._customerCodePre == -1)
                                        {
                                            this.tNedit_PccCompanyCode.SetInt(0);
                                        }
                                        else
                                        {
                                            this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                                        }
                                        e.NextCtrl = tNedit_CustomerCode;
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                         this, 								// 親ウィンドウフォーム
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                         ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                         "マスタに登録されていません。", 							// 表示するメッセージ
                                         0, 									// ステータス値
                                         MessageBoxButtons.OK);				// 表示するボタン
                                    e.NextCtrl = tNedit_CustomerCode;
                                    if (this._customerCodePre == -1)
                                    {
                                        this.tNedit_PccCompanyCode.SetInt(0);
                                    }
                                    else
                                    {
                                        this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                                    }
                                }

                            }
                        }
                        else
                        {
                           //得意先情報を取得
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.CustomerSnm = CUSTOMEMPTY_BASE;
                            customerInfo.CustomerEpCode = string.Empty;
                            customerInfo.CustomerSecCode = string.Empty;
                            if (ModeChangeProc(customerInfo))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                            else
                            {
                                //問合せ元企業コード
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                this.tNedit_PccCompanyCode.SetInt(customerCode);
                                //前問合せ元企業コード
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //前問合せ元拠点コード
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                //前得意先コード
                                this._customerCodePre = customerCode;
                                //前得意先名称
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            }
                           
                        }
                    }
                    break;
                //-----ADD by huanghx for #24894 on 20110913----->>>>>
                //得意先ガイド
                case "UButton_CustomerGuide":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = UButton_CustomerGuide;
                        }
                        break;
                    }
                case "TabControl_PccCmpnySt":
                    {
                        if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = tNedit_CustomerCode;
                        }
                        break;
                    }
                //引用
                case "UltraButton_Quote":
                    {
                        switch (TabControl_PccCmpnySt.SelectedTab.Key)
                        {
                            case "firstTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                                        //e.NextCtrl = tNedit_PccPriWarehouseCd3;
                                        if (this._optionBLPPriWareHouse)
                                        {
                                            e.NextCtrl = tNedit_PccPriWarehouseCd4;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_PccPriWarehouseCd3;
                                        }
                                        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                                    }
                                    break;
                                }
                            case "secondTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        e.NextCtrl = tEdit_PccSuplFaxNo;
                                    }
                                    break;
                                }
                            case "thirdTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        e.NextCtrl = tEdit_StckStComment3;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
               //伝票発行区分
                case "tComboEditor_PccSlipPrtDiv":
                    {
                        if (e.Key == Keys.Left)
                        {
                            e.NextCtrl = tComboEditor_PccSlipPrtDiv;
                        }
                        break;
                    }
                //PCC自社倉庫コード
                case "tNedit_PccWarehouseCd":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccWarehouseCd;
                        }
                        break;
                    }
                //優先倉庫1
                case "tNedit_PccPriWarehouseCd1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd1;
                        }
                        break;
                    }
                //優先倉庫2
                case "tNedit_PccPriWarehouseCd2":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd2;
                        }
                        break;
                    }
                //優先倉庫3
                case "tNedit_PccPriWarehouseCd3":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd3;
                        }
                        break;
                    }
                //-----ADD by huanghx for #24894 on 20110913-----<<<<<
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                //優先倉庫4
                case "tNedit_PccPriWarehouseCd4":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd4;
                        }
                        break;
                    }
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                default:
                    break;
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント（オーバーロード）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void UButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_CMPNYST_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    //オンライン種別区分 0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール
                    if (customerInfo.OnlineKindDiv == ONLINEKINDDIV)
                    {
                        //前問合せ元企業コード
                        this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                        //前問合せ元拠点コード
                        this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                        if (ModeChangeProc(customerInfo))
                        {

                        }
                        else
                        {
                            //得意先情報をUIに設定
                            //問合せ元企業コード
                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                            //問合せ元拠点コード
                            this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                            //前問合せ元企業コード
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //前問合せ元拠点コード
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                        
                            tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                            tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                            uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                            TabControl_PccCmpnySt.Tabs[0].Selected = true;
                            //前得意先コード
                            this._customerCodePre = customerInfo.CustomerCode;
                            //前得意先名称
                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                        }
                       
                        return;
                    }
                    else
                    {
                        // エラー時
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コード [" + customerSearchRet.CustomerCode + "]は設定できません。\r\nオンライン情報を確認して下さい。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    return;
                }

            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }
        }
        #endregion

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
        /// モード変更処理
        /// </summary>
        /// <param name="pccInqCondition">問せ条件</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <remarks>
        /// <br>Note       : モード変更処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool ModeChangeProc(CustomerInfo customerInfo)
        {
            // PCC自社設定マスタメンテコード
            int customerCode = this.tNedit_CustomerCode.GetInt();

            string pccInqCondition = customerInfo.CustomerEpCode.TrimEnd() + customerInfo.CustomerSecCode.TrimEnd()
                + this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd();
            bool exsit = false;
            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string pccInqConditionPre = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DETAILS_GUID_KEY];
                int customerCodePre = (Int32)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][PCCCOMPANYCODE_TITLE];

                if (pccInqConditionPre.Equals(pccInqCondition))
                {
                    exsit = true;
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        if (customerInfo.CustomerCode == 0)
                        {
                            TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                //"ベース設定のPCC自社設定マスタ情報は既に削除されています。", 	// 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                             "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報は既に削除されています。", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15　 
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
                        }
                        else
                        {
                            TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                             emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                             ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                //"入力されたコードのPCC自社設定マスタ情報は既に削除されています。", 　// 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                             "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報は既に削除されています。",  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                             0, 									// ステータス値
                             MessageBoxButtons.OK);				// 表示するボタン
                        }
                        // PCC自社設定マスタメンテコードのクリア
                        if (this._customerCodePre == -1)
                        {
                            this.tNedit_PccCompanyCode.SetInt(0);
                        }
                        else
                        {
                            this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                        }
                        this.uLabel_CustomerName.Text = this._customerNamePre;
                        //問合せ元企業コード
                        this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                        //問合せ元拠点コード
                        this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                        return true;
                    }
                    //新規場合、更新場合
                    DialogResult res = DialogResult.No;
                    if (customerInfo.CustomerCode == 0)
                    {
                        res = TMsgDisp.Show(
                       this,                                   // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                       ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                       //"ベース設定のPCC自社情報は既に登録されています。編集を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                       "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ自社情報は既に登録されています。編集を行いますか？",  　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                       0,                                      // ステータス値
                       MessageBoxButtons.YesNo);               // 表示するボタン
                    }
                    else
                    {
                        res = TMsgDisp.Show(
                       this,                                   // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                       ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                            //"入力された得意先のPCC自社情報は既に登録されています。編集を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                       "入力された得意先のBLﾊﾟｰﾂｵｰﾀﾞｰ自社情報は既に登録されています。編集を行いますか？",  　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                       0,                                      // ステータス値
                       MessageBoxButtons.YesNo);               // 表示するボタン
                    }
                   
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenReconstruction();
                                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                                this.tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                //問合せ元企業コード
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                //前得意先コード
                                this._customerCodePre = customerInfo.CustomerCode;
                                //前得意先名称
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // コードのクリア
                                if (this._customerCodePre == -1)
                                {
                                    this.tNedit_CustomerCode.SetInt(0);
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.SetInt(this._customerCodePre);
                                }
                                this.uLabel_CustomerName.Text = this._customerNamePre;
                                //問合せ元企業コード
                                this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                                //問合せ元拠点コード
                                this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                                break;
                            }
                    }
                    return true;
                }

            }
            if (!exsit && this._dataIndex >= 0)
            {
                DialogResult res = DialogResult.No;
                if (customerInfo.CustomerCode == 0)
                {
                    res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        //"ベース設定のPCC自社設定マスタ情報が存在しません。\n新規登録を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "ベース設定のBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報が存在しません。\n新規登録を行いますか？",　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                }
                else
                {
                    res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        //"入力されたコードのPCC自社設定マスタ情報が存在しません。\n新規登録を行いますか？",   // 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報が存在しません。\n新規登録を行いますか？",  　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                }
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 画面再描画
                            this._dataIndex = -1;
                            ScreenReconstruction();
                            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                            this.tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm;
                            //問合せ元企業コード
                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                            //問合せ元拠点コード
                            this._inqOriginalSecCd = customerInfo.CustomerSecCode;
                            //前得意先コード
                            this._customerCodePre = customerInfo.CustomerCode;
                            //前得意先名称
                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            break;
                        }
                    case DialogResult.No:
                        {
                            // コードのクリア
                            if (this._customerCodePre == -1)
                            {
                                this.tNedit_CustomerCode.SetInt(0);
                            }
                            else
                            {
                                this.tNedit_CustomerCode.SetInt(this._customerCodePre);
                            }
                            this.uLabel_CustomerName.Text = this._customerNamePre;
                            //問合せ元企業コード
                            this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                            //問合せ元拠点コード
                            this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                            break;
                        }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// KeyPress イベント(grdPaymentKind)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : グリッド上でKeyが押されたときに発生します。 </br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Name_tEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TEdit nametEdit = (TEdit)sender;
            if (!nametEdit.Focused)
            {
                return;
            }
            if (!nametEdit.IsInEditMode)
            {
                return;
            }

            // 全角以外は、ＮＧ
            int length = System.Text.Encoding.Default.GetByteCount(e.KeyChar.ToString());
            if ((byte)e.KeyChar == (byte)'\b' || e.KeyChar == (char)3 || e.KeyChar == (char)22) //ADD ③CTRL+「C」、CTRL+「V」
            {
                return;
            }


            if (length == 2)
            {
                e.KeyChar = '\0';
                e.Handled = true;
                return;
            }
        }
        # endregion

        // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
        /// <summary>
        /// ValueChanged イベントInqOdrDspDivSet)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 問合せ発注表示区分が選択されたときに発生します。 </br>
        /// <br>Programmer  : </br>
        /// <br>Date        : </br>
        /// </remarks>
        private void tComboEditor_InqOdrDspDivSet_ValueChanged(object sender, EventArgs e)
        {
            // 入力補正
            if (this.tComboEditor_InqOdrDspDivSet.Value == null)
            {
                this.tComboEditor_InqOdrDspDivSet.Value = 0;
            }
            // 新規登録の時
            if (this._dataIndex < 0)
            {
                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 画面入力許可制御処理
                ScreenInputPermissionControl(DELETE_MODE);
            }
            // 更新の場合
            else
            {
                // 画面入力許可制御処理
                ScreenInputPermissionControl(UPDATE_MODE);
            }
        }

        private void ultraLabel44_Click(object sender, EventArgs e)
        {

        }
        // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
    }
}
