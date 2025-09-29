//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PCC全体設定
// プログラム概要   : PCC全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葉巧燕
// 作 成 日  2011.08.01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/09/17  修正内容 : 「PCC-UOE(NS)」／pm側 PCC全体設定の修正　for redmine24899
//----------------------------------------------------------------------------//
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
    /// PCC全体設定マスタ表示設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC全体設定マスタ名称設定の設定を行います。</br>
    /// <br>Programmer : 葉巧燕</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
    /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC09000UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor
      
        /// <summary>
        /// PCC全体設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC全体設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br></br>
        /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
        /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
        /// <br></br>
        /// </remarks>
        public PMPCC09000UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //_sectionCode取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            _pccTtlStAcs = new PccTtlStAcs();
            this._pccTtlStTable = new Hashtable();
            this._userGuideAcs = new UserGuideAcs(); // ADD 2011/09/17

            // プロパティー変数初期化
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = true;
            this._dataIndex = -1;
            this._canSpecificationSearch = false;
            this.totalCount = 0;

        }
       
        #endregion

        #region Private Members
        private string _enterpriseCode;    // 企業コード
        private string _sectionCode;      //拠点コード
        private const string PCCTTLST_TABLE = "PCCTTLST";
        private Hashtable _pccTtlStTable;
        private Hashtable _userGdBdTb;// ADD 2011/09/17
        private UserGuideAcs _userGuideAcs;// ADD 2011/09/17
        private bool _modeFlg = false;
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string UPDATEDATETIME_DATE = "更新日";
        private const string DELETE_DATE = "削除日";
        private const string SECTIONCODE_TITLE = "拠点コード";
        private const string SECTIONGUIDENM_TITLE = "拠点名称";
        private const string FRONTEMPLOYEECD_TITLE = "受付従業員コード";
        private const string FRONTEMPLOYEENM_TITLE = "受付従業員名称";
        private const string DELIVEREDGOODSDIV_TITLE = "納品区分";
        private const string SALESSLIPPRTDIV_TITLE = "売上伝票発行区分";
        private const string ACPODRRSLIPPRTDIV_TITLE = "受注伝票印刷区分";
        private const string GUID_TITLE = "GUID";

        // 編集モード
        private const string UPDATE_MODE = "更新モード";
        private const string INSERT_MODE = "新規モード";
        private const string DELETE_MODE = "削除モード";
      
        // Message関連定義
        private const string CT_PGID = "PMPCC09000U";
        private const string CT_PGNM = "自社設定";
        private const string ASSEMBLY_ID = "PMPCC09000U";
        private const string ERR_SEAR_TIME_MSG = "検索中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度検索を行なってください。";
        private const string ERR_WRITE_TIME_MSG = "更新中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string ERR_DEL_TIME_MSG = "削除中にタイムアウトが発生しました。\r\nしばらく時間を置いて再度更新してください。";
        private const string SECTION_00_MES = "全体";
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// 自社設定マスタ アクセスクラス
        /// </summary>
        private PccTtlStAcs _pccTtlStAcs = null;
        private PccTtlSt _pccTtlSt = null;
        // 比較用クローン
        private PccTtlSt _pccTtlSClone;   // 比較用全体項目表示名称クラス
        private int totalCount;
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
        private EmployeeAcs _employeeAcs;
        private Hashtable _employeeTb = null;
        private SecInfoSetAcs _secInfoSetAcs;
        private Hashtable _sectionTb = null;
        /// <summary>
        /// ガイド区分=48:納品区分
        /// </summary>
        private const int USERGUIDEDIVCD = 48;      
        private int _preFrontEmployeeCd = 0;
        //前の拠点コード
        private int _preSectionCd = 0;//ADD by huanghx for Redmine24889 on 20110914 
        
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
          
            // 拠点コード
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 拠点名称
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 従業員
            appearanceTable.Add(FRONTEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 従業員名称
            appearanceTable.Add(FRONTEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // 納品区分
            appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 売上伝票発行区分
            appearanceTable.Add(SALESSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 受注伝票印刷区分
            appearanceTable.Add(ACPODRRSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PCCTTLST_TABLE;
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            PccTtlSt parsepccTtlSt = new PccTtlSt();
            List<PccTtlSt> pccTtlStList = null;
            parsepccTtlSt.EnterpriseCode = this._enterpriseCode;
            if (this._pccTtlStTable.Count == 0)
            {
                status = this._pccTtlStAcs.Search(ref pccTtlStList, parsepccTtlSt, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.totalCount = pccTtlStList.Count;                            
                            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Clear();
                            this._pccTtlStTable.Clear();
                           
                            //全体設定クラスをデータセットへ展開する
                            int index = 0;
                            foreach (PccTtlSt pccTtlSt in pccTtlStList)
                            {
                                if (this._pccTtlStTable.ContainsKey(pccTtlSt.FileHeaderGuid) == false)
                                {
                                    PccTtlStToDataSet(pccTtlSt.Clone(), index);
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
                                this._pccTtlStAcs,                // エラーが発生したオブジェクト
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
                this.totalCount = this._pccTtlStTable.Count;
                SortedList sortedList = new SortedList();

                //全体設定クラスをデータセットへ展開する
                int index = 0;
                foreach (PccTtlSt pccTtlSt in sortedList.Values)
                {
                    PccTtlStToDataSet(pccTtlSt.Clone(), index);
                    ++index;
                }
            }
            // 戻り値セット
            totalCount = this.totalCount;

            return status;
        }
      
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            PccTtlSt pccTtlSt = null;
  
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
            pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];           

            int status;
            int dummy = 0;
            //全体設定論理削除処理
            status = this._pccTtlStAcs.LogicalDelete(ref pccTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        PccTtlStToDataSet(pccTtlSt.Clone(), this.DataIndex);
                         
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        //全体設定クラスデータセット展開処理
                        this._pccTtlStTable.Clear();
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
                            this._pccTtlStAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._pccTtlStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        //全体設定クラスデータセット展開処理
                        this._pccTtlStTable.Clear();
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
        /// <br>Note		: フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer	: 葉巧燕</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_Load(object sender, EventArgs e)
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

            this.Ok_Button.ImageList = imageList24;           // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;           // 閉じるボタン
            this.Revive_Button.ImageList = imageList24;           //復活ボタン
            this.Delete_Button.ImageList = imageList24;           //完全削除ボタン

            this.uButtonFrontEmployeeCdGuid.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;     // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;  //復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;   //完全削除ボタン
            this.uButtonFrontEmployeeCdGuid.Appearance.Image = Size16_Index.STAR1;//ガイドボタン
            this.SectionGuide_ultraButton1.ImageList = imageList16;
            this.SectionGuide_ultraButton1.Appearance.Image = Size16_Index.STAR1;//ガイドボタン
            this.Initial_Timer.Enabled = true;         
        }
      
        /// <summary>
        /// Form.FormClosing イベント (PMPCC09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // チェック用クローン初期化
            this._pccTtlSClone = null;

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
        /// Form.VisibleChanged イベント (PMPCC09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア処理
            ScreenClear();

            this.Initial_Timer.Enabled = true;
           
        }
      
        /// <summary>
        /// Timer.Tick イベント (Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }
      
        /// <summary>
        /// Ok_Button_Click イベント (Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
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
            if (CanClose == true)
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                PccTtlSt comparePccTtlSt = new PccTtlSt();
                comparePccTtlSt = this._pccTtlSClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                //現在の画面情報を取得する
                DispToPccTtlSt(ref comparePccTtlSt);
                //最初に取得した画面情報と比較
                if (!(this._pccTtlSClone.Equals(comparePccTtlSt)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                         this,								// 親ウィンドウフォーム
                         emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                         ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                         "",									// 表示するメッセージ 
                         0,									// ステータス値
                         MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 登録処理
                                if (SaveProc() == false)
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
                                if (_modeFlg)
                                {
                                    this.tEdit_FrontEmployeeCd.Focus();
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
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            // GridのIndexBuffer格納用変数の初期化
            this._detailsIndexBuf = -2;

            this.DialogResult = DialogResult.Cancel;
            
            this.Close();  
        }
     
        /// <summary>
        /// uButtonFrontEmployeeCdGuid_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: 葉巧燕</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void uButtonFrontEmployeeCdGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tEdit_FrontEmployeeCd.Value = employee.EmployeeCode.TrimEnd();
                tEdit_FrontEmployeeNm.Text = employee.Name;
                _preFrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt(); //ADD by huanghx for Redmine24889 on 20110914
            }

        }
      
        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 葉巧燕</br>
        /// <br>Date        : 2011.08.01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FrontEmployeeCd":
                    {
                        int frontEmployeeCd = tEdit_FrontEmployeeCd.GetInt();
                        if (frontEmployeeCd != 0)
                        {
                            if (frontEmployeeCd != _preFrontEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }
                                string employeeNm = GetFrontEmployeeNm(frontEmployeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    // this.tEdit_FrontEmployeeNm.Clear();//DEL by huanghx for Redmine24889 on 20110914

                                    //  _preFrontEmployeeCd = 0;//DEL by huanghx for Redmine24889 on 20110914

                                    //-----ADD by huanghx for Redmine24889 on 20110914 ----->>>>>
                                    this.tEdit_FrontEmployeeCd.SetInt(_preFrontEmployeeCd);
                                    // 入力チェック
                                    TMsgDisp.Show(
                                        this,                                  // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                        CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                                        "従業員が存在しません。",                               // 表示するメッセージ
                                        0,                                     // ステータス値
                                        MessageBoxButtons.OK);                // 表示するボタン
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                    return;
                                    //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                                }
                                else
                                {
                                    this.tEdit_FrontEmployeeNm.Text = employeeNm;
                                    _preFrontEmployeeCd = frontEmployeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeNm.Text = string.Empty;
                            _preFrontEmployeeCd = 0;
                        }
                        //----ADD by huanghx for #24889 on 20110914 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(this.tEdit_FrontEmployeeNm.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tComboEditor1;
                                }
                            }
                        }
                        else if (e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(tEdit_SectionName.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tEdit_SectionCode;
                                }
                            }
                        }
                        //----ADD by huanghx for #24889 on 20110914 -----<<<<<
                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        //-----DEL by huanghx for Redmine24889 on 20110914 ----->>>>>
                        //// 拠点コードが未入力の場合
                        //                   if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.TrimEnd()))
                        //                   {
                        //                       this.tEdit_SectionName.DataText = string.Empty;
                        //                       return;
                        //                   }
                        //                   // 拠点コード取得
                        //                   string sectionCode = this.tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');

                        //                   // 拠点名称取得
                        //                   this.tEdit_SectionName.DataText = GetSectionName(sectionCode.TrimEnd());
                        //                   // 拠点コードにフォーカスがある場合
                        //                   if (e.Key == Keys.Enter)
                        //                   {
                        //                       if (this.tEdit_SectionName.DataText != "")
                        //                       {
                        //                           // 拠点コードにフォーカスを移します
                        //                           e.NextCtrl = this.tEdit_FrontEmployeeCd;
                        //                       }

                        //                   }
                        //                   if (this._dataIndex < 0)
                        //                   {
                        //                       if (ModeChangeProc(sectionCode.TrimEnd()))
                        //                       {

                        //                           e.NextCtrl = tEdit_SectionCode;
                        //                       }
                        //                   }

                        //                   break;
                        //-----DEL by huanghx for Redmine24889 on 20110914 -----<<<<<
                        //-----ADD by huanghx for Redmine24889 on 20110914 ----->>>>>

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');
                        string sectionName = GetSectionName(sectionCode.TrimEnd());
                        if (string.IsNullOrEmpty(sectionName))
                        {
                            // 入力チェック
                            TMsgDisp.Show(
                                this,                                  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                                "拠点が存在しません。",                               // 表示するメッセージ
                                0,                                     // ステータス値
                                MessageBoxButtons.OK);                // 表示するボタン
                            tEdit_SectionCode.Clear();
                            tEdit_SectionName.Clear();
                            return;
                        }
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc(sectionCode.TrimEnd()))
                            {
                                //e.NextCtrl = tEdit_SectionCode; 
                                return;
                            }
                            else
                            {
                                // 拠点名称取得
                                this.tEdit_SectionName.DataText = sectionName;
                            }
                        }
                        this._preSectionCd = tEdit_SectionCode.GetInt();
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (this.tEdit_SectionCode.GetInt() != 0)
                                {
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                }
                            }
                        }
                        break;
                    }
                //add start by wujun for Redmine#24893 on 2011.09.13
                // 拠点コードガイドにフォーカスがある場合
                case "SectionGuide_ultraButton1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = SectionGuide_ultraButton1;
                        }
                        break;
                    }
                //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                // 受注者ガイドにフォーカスがある場合
                case "uButtonFrontEmployeeCdGuid":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = uButtonFrontEmployeeCdGuid;
                        }
                        break;
                    }
                // 納品区分にフォーカスがある場合
                case "tComboEditor1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor1;
                        }
                        else if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = tEdit_FrontEmployeeCd;
                        }
                        else if (e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(tEdit_FrontEmployeeNm.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                }
                            }
                        }
                        break;
                    }
                // 売上伝票発行区分にフォーカスがある場合
                case "tComboEditor_SalesSlipPrtDiv":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor_SalesSlipPrtDiv;
                        }
                        break;
                    }
                // 受注伝票印刷区分にフォーカスがある場合
                case "tComboEditor_AcpOdrrSlipPrtDiv":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor_AcpOdrrSlipPrtDiv;
                        }
                        break;
                    }
                //add end by wujun for Redmine#24893 on 2011.09.13
            }
        }
     
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private void SectionGuide_ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this._secInfoSetAcs == null)
                {
                    this._secInfoSetAcs = new SecInfoSetAcs();
                }

                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (!ModeChangeProc(secInfoSet.SectionCode.ToString().TrimEnd()))
                    {
                        tEdit_SectionCode.Value = secInfoSet.SectionCode.Trim();
                        _preSectionCd = tEdit_SectionCode.GetInt();//ADD by huanghx for Redmine24889 on 20110914
                        tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                        this.Ok_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }      
      
        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 葉巧燕</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            PccTtlSt pccTtlSt = new PccTtlSt();

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(            
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                 0, 									// ステータス値
                 MessageBoxButtons.OKCancel, 		// 表示するボタン
                 MessageBoxDefaultButton.Button2);	// 初期表示ボタン
            if (result == DialogResult.OK)
            {
                // 保持しているデータセットより情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
                pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];
                //PCC全体設定論理削除処理
                int status = this._pccTtlStAcs.Delete(ref pccTtlSt);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex].Delete();
                            this._pccTtlStTable.Remove(pccTtlSt.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, true);

                            //PCC全体設定クラスデータセット展開処理
                            this._pccTtlStTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();
                           
                            return;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // TIMEOUT
                            TMsgDisp.Show(
                               this, 								// 親ウィンドウフォーム
                               emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                               CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                               this.Name,                           // プログラム名称
                               ctPROCNM,                            // 処理名称
                               TMsgDisp.OPE_UPDATE,                 // オペレーション
                               ERR_DEL_TIME_MSG,                    // 表示するメッセージ
                               status,            						// ステータス値
                               this._pccTtlStAcs, 				    // エラーが発生したオブジェクト
                               MessageBoxButtons.OK, 				// 表示するボタン
                               MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            return ;
                        }
                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                                CT_PGNM, 				            // プログラム名称
                                "Delete_Button_Click", 				// 処理名称
                                TMsgDisp.OPE_DELETE, 				// オペレーション
                                "削除に失敗しました。", 			// 表示するメッセージ
                                status, 							// ステータス値
                                this._pccTtlStAcs, 				    // エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                            // PCC全体設定クラスデータセット展開処理
                            this._pccTtlStTable.Clear();
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
        /// Revive_Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 葉巧燕</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            PccTtlSt pccTtlSt = null;

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
            Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
            pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];

            // PCC全体設定登録・更新処理
            int status = this._pccTtlStAcs.RevivalLogicalDelete(ref pccTtlSt);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //クラスデータセット展開処理
                        PccTtlStToDataSet(pccTtlSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        // クラスデータセット展開処理
                        this._pccTtlStTable.Clear();
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
                            this._pccTtlStAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return ;

                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM, 				            // プログラム名称
                            "Revive_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._pccTtlStAcs, 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン                      
                        // クラスデータセット展開処理
                        this._pccTtlStTable.Clear();
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
        /// モード変更処理
        /// </summary>
        /// <param name="sectionCd">拠点コード</param>
        /// <remarks>
        /// <br>Note		: モード変更処理</br>
        /// <br>Programmer	: 葉巧燕</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>  
        private bool ModeChangeProc(string sectionCd)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSectionCd = (string)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSectionCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コードのクリア
                        tEdit_SectionCode.Clear();
                        tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの全体設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 拠点コードのクリア
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

        #endregion

        #region  Private Methods  
      
        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                
                // 0:拠点-新規
                case 0:

                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton1.Enabled = true;
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButtonFrontEmployeeCdGuid.Enabled = true;
                    this.tComboEditor1.Enabled = true;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = true;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = true;

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 1:拠点-更新
                case 1:
                    // 表示項目
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton1.Enabled = false;
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButtonFrontEmployeeCdGuid.Enabled = true;
                    this.tComboEditor1.Enabled = true;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = true;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                   
                    break;
                // 2:拠点-削除
                case 2:
                    // 表示項目
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton1.Enabled = false;
                    this.uButtonFrontEmployeeCdGuid.Enabled = false;
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.tComboEditor1.Enabled = false;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = false;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = false;
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
        /// <param name="pccTtlSt">全体項目表示名称オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
        /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
        /// <br></br>
        /// </remarks>
        private void DispToPccTtlSt(ref PccTtlSt pccTtlSt)
        {
            if (pccTtlSt == null)
            {
                // 新規の場合
                pccTtlSt = new PccTtlSt();
                pccTtlSt.EnterpriseCode = this._enterpriseCode;
            }
            //拠点コード
            pccTtlSt.SectionCode = tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');
            //拠点名称
            pccTtlSt.SectionName = tEdit_SectionName.Text.TrimEnd();
            //受付従業員       
            if (tEdit_FrontEmployeeCd.GetInt() == 0)
            {
                tEdit_FrontEmployeeCd.Text = "";
            }
            else
            {
                pccTtlSt.FrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt().ToString().PadLeft(4, '0');
            }
            //受付従業員名称
            pccTtlSt.FrontEmployeeNm = tEdit_FrontEmployeeCd.Text.TrimEnd();

            //---UPD 2011/09/17 ------------------------>>>>>
            //納品区分
            //pccTtlSt.DeliveredGoodsDiv = (int)tComboEditor1.Value;
            if (this.tComboEditor1.SelectedItem == null)
            {
                pccTtlSt.DeliveredGoodsDiv = 0;
            }
            else
            {
                if (this.tComboEditor1.SelectedItem.DataValue != string.Empty)
                {
                    pccTtlSt.DeliveredGoodsDiv = (int)this.tComboEditor1.SelectedItem.DataValue;
                }
            }
            //---UPD 2011/09/17 ------------------------<<<<<

            //売上伝票発行区分
            pccTtlSt.SalesSlipPrtDiv = (int)tComboEditor_SalesSlipPrtDiv.Value;

            //受注伝票印刷区分
            pccTtlSt.AcpOdrrSlipPrtDiv = (int)tComboEditor_AcpOdrrSlipPrtDiv.Value;

        }
     
        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体項目表示名称クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
        /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
        /// <br></br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {


            //拠点コード
            this.tEdit_SectionCode.Text = _pccTtlSt.SectionCode;

            //受付従業員

            this.tEdit_FrontEmployeeCd.Text = _pccTtlSt.FrontEmployeeCd;

            //---UPD 2011/09/17 ---------------------->>>>>

            //納品区分
            if (this._pccTtlSt.DeliveredGoodsDiv == 0)
            {
                this.tComboEditor1.SelectedItem.DisplayText = string.Empty;
            }
            else
            {
                this.tComboEditor1.SelectedItem.DisplayText = this.GetDeliveredName(this._pccTtlSt.DeliveredGoodsDiv);
            }
            ////納品区分
            //this.tComboEditor1.Value = this._pccTtlSt.DeliveredGoodsDiv;
            //---UPD 2011/09/17 ----------------------<<<<<

            //売上伝票発行区分
            this.tComboEditor_SalesSlipPrtDiv.Value = this._pccTtlSt.SalesSlipPrtDiv;

            //受注伝票印刷区分
            this.tComboEditor_AcpOdrrSlipPrtDiv.Value = this._pccTtlSt.AcpOdrrSlipPrtDiv;

        }
     
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void ScreenClear()
        {

            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;      
           
            // ボタン
            this.Delete_Button.Visible = false;  // 完全削除ボタン
            this.Revive_Button.Visible = false;  // 復活ボタン
            this.Ok_Button.Visible = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
         
            // 拠点部
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Text = "";
            this.tEdit_SectionCode.Enabled = true; 
            this.SectionGuide_ultraButton1.Enabled = true;

            //受付従業員
            this.tEdit_FrontEmployeeCd.Clear();
            this.tEdit_FrontEmployeeNm.Text="";
            this.tEdit_FrontEmployeeCd.Enabled = true;
            this.uButtonFrontEmployeeCdGuid.Enabled = true;
            this.tComboEditor_SalesSlipPrtDiv.SelectedIndex = 0;
            this.tComboEditor_AcpOdrrSlipPrtDiv.SelectedIndex = 0;
            this.tComboEditor1.SelectedIndex = 0;
            _preFrontEmployeeCd = 0;
            _preSectionCd = 0; //ADD by huanghx for Redmine24889 on 20110914 
        }
     
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
        /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
                      
            this._pccTtlSt = new PccTtlSt();
            PccTtlSt pccTtlSt = new PccTtlSt();
            this.SetDelivereds(this._enterpriseCode);// ADD 2011/09/17
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                PccTtlStToScreen(pccTtlSt);
                // 画面クリア
                this.ScreenClear();
                // クローン作成
                this._pccTtlSClone = pccTtlSt.Clone();
              
                // フォーカス設定
                this.tEdit_SectionCode.Focus();
                ScreenInputPermissionControl(0);
                // 画面展開処理
                DispToPccTtlSt(ref this._pccTtlSClone);       
            }
             else
            {
               
                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];

                // 画面展開処理
                PccTtlStToScreen(pccTtlSt);
                if (pccTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    //クローン作成
                    this._pccTtlSClone = pccTtlSt.Clone();

                    // 画面展開処理
                    DispToPccTtlSt(ref this._pccTtlSClone);
                    ScreenInputPermissionControl(1);
                    this.tEdit_FrontEmployeeCd.SelectAll();
                    //-----ADD by huanghx for Redmine25035 on 20110914 ----->>>>>
                    int sectionCode = 0;
                    Int32.TryParse(pccTtlSt.SectionCode.Trim(), out sectionCode);
                    this._preSectionCd = sectionCode;
                    int employeeCd = 0;
                    Int32.TryParse(pccTtlSt.FrontEmployeeCd.Trim(), out employeeCd);
                    this._preFrontEmployeeCd = employeeCd;
                    //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                }
                // 削除の場合
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面展開処理
                    PccTtlStToScreen(pccTtlSt);
                    ScreenInputPermissionControl(2);
                    this.Delete_Button.Focus();

                }  
           
                this._detailsIndexBuf = this._dataIndex;             
          }
     }
    
        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <returns>チェック結果(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
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
            if (this.DataIndex >= 0 )
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                _pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];
            }
            // 画面から全体項目表示名称のデータを取得
            DispToPccTtlSt(ref this._pccTtlSt);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._pccTtlStAcs.Write(ref this._pccTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        PccTtlStToDataSet(_pccTtlSt.Clone(), this.DataIndex);
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
                            this._pccTtlStAcs,                // エラーが発生したオブジェクト
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
                            this._pccTtlStAcs,                    // エラーが発生したオブジェクト
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            if (this.tEdit_SectionCode.Text == "")
            {
                control = this.tEdit_SectionCode;
                message = "拠点コードを入力して下さい。";
                result = false;
            }
            else if (this.tEdit_SectionName.Text.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = "マスタに登録されていません。";
                result = false;
            }
            else if (this.tEdit_FrontEmployeeCd.Text == "")
            {
                control = this.tEdit_FrontEmployeeCd;
                message = "受注者を入力して下さい。";
                result = false;
            }
            else if (this.tEdit_FrontEmployeeNm.Text.Trim() == "")
            {
                control = this.tEdit_FrontEmployeeCd;
                message = "マスタに登録されていません。";
                result = false;
            }
            return result;
        }
     
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
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
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
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
            this._pccTtlSClone = null;

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
        /// 拠点名称の取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;
            if (_sectionTb == null)
            {
                GetALLSectionName();
            }

            if (_sectionTb != null && _sectionTb.Count > 0 && _sectionTb.ContainsKey(sectionCode))
            {
                sectionName = (string)_sectionTb[sectionCode];
            }
            
            return sectionName;
        }

        /// <summary>
        /// 拠点名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetALLSectionName()
        {
            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }
            if (_sectionTb == null)
            {
                _sectionTb = new Hashtable();
            }
            else
            {
                _sectionTb.Clear();
            }

            _sectionTb.Add("00", SECTION_00_MES);
                ArrayList retList = null;
                int status = this._secInfoSetAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            _sectionTb.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideSnm.TrimEnd());
                        }
                    }
                }
        }
     
        /// <summary>
        /// 受付従業員名称の取得
        /// </summary>
        /// <param name="employeeCode"> 受付従業員コード</param>
        /// <returns>受付従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetFrontEmployeeNm(string employeeCode)
        {

            string frontEmployeeNm = string.Empty;
            if (_employeeTb == null)
            {
                GetAllEmployeeNm();
            }
            if (_employeeTb != null && _employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                frontEmployeeNm = (string)_employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return frontEmployeeNm;
        }
     
        /// <summary>
        /// 受付従業員名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
                _employeeTb = new Hashtable();
            }
            else
            {
                _employeeTb.Clear();
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
                        _employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 全体設定マスタ展開処理
        /// </summary>
        /// <param name="pccTtlSt">全体設定マスタ</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 全体設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PccTtlStToDataSet(PccTtlSt pccTtlSt, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PCCTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (pccTtlSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELETE_DATE] = pccTtlSt.UpdateDateTimeJpInFormal;
            }          

            // 拠点コード
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = pccTtlSt.SectionCode;

            // 拠点名称
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(pccTtlSt.SectionCode.TrimEnd()); ;

            // 従業員
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][FRONTEMPLOYEECD_TITLE] = pccTtlSt.FrontEmployeeCd;

            // 従業員名称
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][FRONTEMPLOYEENM_TITLE] = GetFrontEmployeeNm(pccTtlSt.FrontEmployeeCd);

            // 納品区分
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = pccTtlSt.DeliveredGoodsNm;

            // 売上伝票発行区分
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SALESSLIPPRTDIV_TITLE] = pccTtlSt.SalesSlipPrtNm;

            // 受注伝票印刷区分
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][ACPODRRSLIPPRTDIV_TITLE] = pccTtlSt.AcpOdrrSlipPrtNm;

            // GUID
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][GUID_TITLE] = pccTtlSt.FileHeaderGuid;

            if (this._pccTtlStTable.ContainsKey(pccTtlSt.FileHeaderGuid) == true)
            {
                this._pccTtlStTable.Remove(pccTtlSt.FileHeaderGuid);
            }
            this._pccTtlStTable.Add(pccTtlSt.FileHeaderGuid, pccTtlSt);
        }
     
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pccTtlStTable = new DataTable(PCCTTLST_TABLE);

            // Addを行う順番が、列の表示順位となります。
            pccTtlStTable.Columns.Add(DELETE_DATE, typeof(string));                     // 削除日       
            pccTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));			    // 拠点コード
            pccTtlStTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));            // 拠点名称
            pccTtlStTable.Columns.Add(FRONTEMPLOYEECD_TITLE, typeof(string));	    //  従業員
            pccTtlStTable.Columns.Add(FRONTEMPLOYEENM_TITLE, typeof(string));	    //  従業員名称
            pccTtlStTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(string));	    // 納品区分
            pccTtlStTable.Columns.Add(SALESSLIPPRTDIV_TITLE, typeof(string));	// 売上伝票発行区分
            pccTtlStTable.Columns.Add(ACPODRRSLIPPRTDIV_TITLE, typeof(string));	// 受注伝票印刷区分
            pccTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));                
            this.Bind_DataSet.Tables.Add(pccTtlStTable);
        }
     
        /// <summary>
        /// 拠点クラス画面展開処理
        /// </summary>
        /// <param name="pccTtlSt">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 鄧潘ハン</br>
        /// <br>	         rPCC-UOE(NS)」／pm側 PCC全体設定の修正</br>
        /// <br></br>
        /// </remarks>
        private void PccTtlStToScreen(PccTtlSt pccTtlSt)
        {

            //拠点コード
            this.tEdit_SectionCode.Text = pccTtlSt.SectionCode.Trim().PadLeft(2,'0');

            //拠点名称
            this.tEdit_SectionName.Text = GetSectionName(pccTtlSt.SectionCode.TrimEnd());

            //受付従業員コード
            this.tEdit_FrontEmployeeCd.Text = pccTtlSt.FrontEmployeeCd.Trim().PadLeft(4,'0');

            //受付従業員名称
            this.tEdit_FrontEmployeeNm.Text = GetFrontEmployeeNm(pccTtlSt.FrontEmployeeCd);

            //---UPD 2011/09/17 --------------------->>>>>
            //納品区分
            //this.tComboEditor1.Value = pccTtlSt.DeliveredGoodsDiv;
            if (pccTtlSt.DeliveredGoodsDiv == 0)
            {
                this.tComboEditor1.SelectedIndex = 0;
            }
            else
            {
                this.tComboEditor1.Value = pccTtlSt.DeliveredGoodsDiv;
            }
            //---UPD 2011/09/17 ---------------------<<<<<

            //売上伝票発行区分
            this.tComboEditor_SalesSlipPrtDiv.Value = pccTtlSt.SalesSlipPrtDiv;

            //受注伝票印刷区分
            this.tComboEditor_AcpOdrrSlipPrtDiv.Value = pccTtlSt.AcpOdrrSlipPrtDiv;

        }
        
        #endregion
        //---ADD 2011/09/17 --------------------------------->>>>>
        /// <summary>
        /// ユーザーガイド設定の納品区分の取得
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <br>Note       : ユーザーガイド設定の納品区分を取得します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //ユーザーガイド設定の納品区分の取得
            ArrayList userGuidList = null;
            //納品区分の項目
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            tComboEditor1.Items.Clear();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {

                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                       tComboEditor1.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);
                       _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                    }
                }
            }
            if (this.tComboEditor1.SelectedItem == null && this.tComboEditor1.Items.Count == 0)
            {
                tComboEditor1.Items.Add(string.Empty, string.Empty);
                _userGdBdTb.Add(string.Empty, string.Empty);
            }
            this.tComboEditor1.SelectedIndex = 0;
       
        }
        /// <summary>
        /// 納品区分名称の取得
        /// </summary>
        /// <param name="deliveredGoodsDiv"> 納品区分</param>
        /// <remarks>
        /// <returns>納品区分名称</returns>
        /// <br>Note       : 納品区分名称を取得します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        //---ADD 2011/09/17 ---------------------------------<<<<<

      }
    }

