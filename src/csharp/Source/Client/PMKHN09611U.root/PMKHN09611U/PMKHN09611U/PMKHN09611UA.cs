//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン売価優先設定マスタメンテナンス
// プログラム概要   : キャンペーン売価優先設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util; // ADD 2011/09/07

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン売価優先設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: キャンペーン売価優先設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 鄧潘ハン</br>
    /// <br>Date		: 2011/04/25</br>
    /// <br>Update Note : 2011/09/07 王飛３</br>
    /// <br>              障害報告 #24169 全社共通の編集　</br>   
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09611UA : Form,IMasterMaintenanceMultiType
    {
        #region コンストラクタ
        /// <summary>
        /// PMKHN09611Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン売価優先設定フォームクラスコンストラクタです</br>
        /// <br>Programer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public PMKHN09611UA()
        {
            InitializeComponent();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // CampaignPrcPrStクラス
            this._campaignPrcPrSt = new CampaignPrcPrSt();
            // CampaignPrcPrStAcsクラスアクセスクラス
            this._campaignPrcPrStAcs = new CampaignPrcPrStAcs();

            this._campaignPrcPrStTable = new Hashtable();
  
            this._recordClone = new CampaignPrcPrSt();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();

            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            this._campaignPrcPrStCheckClone = new CampaignPrcPrSt();
            this._campaignPrcPrStClone = new CampaignPrcPrSt();
            this._campaignPrcPrStInit = new CampaignPrcPrSt();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._checkPrcPrSt=new ArrayList();
            this._checkPrcPrStNumber = new ArrayList();

            checkPrcPrStADD();
            this._indexBuf = -2;
            ReadSecInfoSet();
        }
        #endregion

        #region Private Member

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private SecInfoSetAcs _secInfoSetAcs;
        // 拠点情報アクセスクラス
        private SecInfoAcs _secInfoAcs;
        // 拠点情報ディクショナリ
        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private CampaignPrcPrSt _campaignPrcPrSt;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs;

        // 比較用Clone
        private CampaignPrcPrSt _campaignPrcPrStCheckClone;
        // 保存比較用Clone
        private CampaignPrcPrSt _campaignPrcPrStClone;
        // 閉める比較用Clone
        private CampaignPrcPrSt _campaignPrcPrStInit;

        //HashTable
        private Hashtable _campaignPrcPrStTable;
        // 終了時の編集チェック用
        private CampaignPrcPrSt _recordClone;

        private ArrayList _checkPrcPrSt;

        private ArrayList _checkPrcPrStNumber;
        private int _indexBuf;
        private string _enterpriseCode;

        private const string ASSEMBLY_ID = "PMKHN09611U";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_SECTIONCODE = "拠点コード";
        private const string VIEW_SECTIONNAME = "拠点名称";
        private const string VIEW_PRIORITYSETTINGCD1 = "優先設定１";
        private const string VIEW_PRIORITYSETTINGCD2 = "優先設定２";
        private const string VIEW_PRIORITYSETTINGCD3 = "優先設定３";
        private const string VIEW_PRIORITYSETTINGCD4 = "優先設定４";
        private const string VIEW_PRIORITYSETTINGCD5 = "優先設定５";
        private const string VIEW_PRIORITYSETTINGCD6 = "優先設定６";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private bool isError = false; // ADD 2011/09/07

        #endregion

        #region Main Entry Point
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09611UA());
        }
        #endregion


        #region IMasterMaintenanceMultiType メンバ

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
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            CampaignPrcPrSt campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (campaignPrcPrSt.SectionCode.Trim() == "00")
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMKHN09611U",							// アセンブリID
                    "全社共通データは削除できません。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
                return status;
            }
            // キャンペーン売価優先設定マスタ情報論理削除処理
            status = this._campaignPrcPrStAcs.LogicalDelete(ref campaignPrcPrSt);

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
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._campaignPrcPrStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.YesNo, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // キャンペーン売価優先設定マスタデータセット展開処理
            CampaignPrcPrStToDataSet(campaignPrcPrSt.Clone(), this.DataIndex);
            return 0;
        }


        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMKHN09611U",							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //拠点コード
            appearanceTable.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //拠点名称
            appearanceTable.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード１
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード２
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード３
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード４
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード５
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //優先設定コード６
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          

            return appearanceTable;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
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
            ArrayList campaignPrcPrStAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._campaignPrcPrStTable.Clear();
            // 全検索
            status = this._campaignPrcPrStAcs.SearchAll(out campaignPrcPrStAcsList, this._enterpriseCode);

            totalCount = campaignPrcPrStAcsList.Count;



            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (CampaignPrcPrSt campaignPrcPrSt in campaignPrcPrStAcsList)
                        {

                            // オートバックス設定オブジェクトデータセット展開処理
                            CampaignPrcPrStToDataSet(campaignPrcPrSt.Clone(), index);
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
                            "PMKHN09611UA",							// アセンブリID
                            "オートバックス設定",              　　   // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._campaignPrcPrStAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタメンテナンスクラスをデータセットに格納します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        private void CampaignPrcPrStToDataSet(CampaignPrcPrSt campaignPrcPrSt, int index)
        {
            string sectionName;

            // indexの値がDataSetの既存行をさしていなかったら
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // indexに行の最終行番号をセットする
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            if (campaignPrcPrSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = campaignPrcPrSt.UpdateDateTimeJpInFormal;
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = campaignPrcPrSt.FileHeaderGuid;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE] = campaignPrcPrSt.SectionCode;
            
            GetSectionName(campaignPrcPrSt.SectionCode, out sectionName);

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
           
            #region PrioritySettingCd
            switch (campaignPrcPrSt.PrioritySettingCd1)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "販売区分";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd2)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "販売区分";
                        break;
                    }
            }


            switch (campaignPrcPrSt.PrioritySettingCd3)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "販売区分";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd4)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "販売区分";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd5)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "販売区分";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd6)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "ﾒｰｶｰ+品番";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "ﾒｰｶｰ";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "BLｺｰﾄﾞ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "販売区分";
                        break;
                    }
            }
            #endregion
            // インスタンステーブルにもセットする
            if (this._campaignPrcPrStTable.ContainsKey(campaignPrcPrSt.FileHeaderGuid) == true)
            {
                this._campaignPrcPrStTable.Remove(campaignPrcPrSt.FileHeaderGuid);
            }
            this._campaignPrcPrStTable.Add(campaignPrcPrSt.FileHeaderGuid, campaignPrcPrSt);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        #endregion

        #region ----- Event -----
        /// <summary>
        /// UnDisplaying
        /// </summary>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion ----- Event -----

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
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

        #region ----- Private Method -----

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:新規, 1:更新, 2:削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {

            switch (setType)
            {
                // 0:新規
                default:
                case 0:
                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    // パネル
                    this.panel_Section.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = true;

                    // 画面初期化
                    ScreenClear();

                    break;
                // 1:更新
                case 1:

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // パネル
                    this.panel_Section.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = true;

                    break;
                // 2:削除
                case 2:

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // パネル
                    this.panel_Section.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programer  : 鄧潘ハン</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable campaignPrcPrStTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            campaignPrcPrStTable.Columns.Add(DELETE_DATE, typeof(string));               //削除日
            campaignPrcPrStTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));       //BL コード
            campaignPrcPrStTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //BL　コード名
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD1, typeof(string));          //優先設定コード１
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD2, typeof(string));           //優先設定コード２
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD3, typeof(string));           //優先設定コード３
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD4, typeof(string));     //優先設定コード４
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD5, typeof(string));     //優先設定コード５
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD6, typeof(string));     //優先設定コード６

            campaignPrcPrStTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(campaignPrcPrStTable);
        }


        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();

                // クローン作成
                this._campaignPrcPrStClone = campaignPrcPrSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToCampaignPrcPrSt(ref this._campaignPrcPrStClone);

                //　新規モード
                this.Mode_Label.Text = INSERT_MODE;
                this.tEdit_SectionCodeAllowZero2.Focus();
                ScreenClear();

            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                CampaignPrcPrSt campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];
                campaignPrcPrSt.SectionCode = campaignPrcPrSt.SectionCode.Trim();
                //画面展開処理
                RecordToScreen(campaignPrcPrSt);

                if (campaignPrcPrSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(1);

                    // クローン作成
                    this._campaignPrcPrStClone = campaignPrcPrSt.Clone();

                    this.tComboEditor_PRIORITYSETTING1.Focus();


                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(2);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {

            this.tEdit_SectionCodeAllowZero2.Clear();
            this.tEdit_SectionGuideNm.Clear();
            this.tComboEditor_PRIORITYSETTING1.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING2.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING3.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING4.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING5.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING6.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING1.Enabled = true;
            this.tComboEditor_PRIORITYSETTING2.Enabled = true;
            this.tComboEditor_PRIORITYSETTING3.Enabled = true;
            this.tComboEditor_PRIORITYSETTING4.Enabled = true;
            this.tComboEditor_PRIORITYSETTING5.Enabled = true;
            this.tComboEditor_PRIORITYSETTING6.Enabled = true;
            this.panel_Section.Enabled = true;

            // ボタン
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;
            this.Renewal_Button.Visible = true;
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ画面展開処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void RecordToScreen(CampaignPrcPrSt campaignPrcPrSt)
        {
            if (campaignPrcPrSt.SectionCode.Trim() == "00" || campaignPrcPrSt.SectionCode.Trim() == string.Empty)
            {
                // 拠点コード
                this.tEdit_SectionCodeAllowZero2.Text = "00";
                // 拠点名
                this.tEdit_SectionGuideNm.Text = "全社共通";
            }
            else
            {
                this.tEdit_SectionCodeAllowZero2.Text = campaignPrcPrSt.SectionCode;

                //
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignPrcPrSt.SectionCode);
                if (status == 0)
                {
                    this.tEdit_SectionGuideNm.Text = secInfoSet.SectionGuideNm;
                }
            }


            #region PrioritySettingCd
            switch (campaignPrcPrSt.PrioritySettingCd1)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd2)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 6;
                        break;
                    }
            }


            switch (campaignPrcPrSt.PrioritySettingCd3)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd4)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd5)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd6)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 6;
                        break;
                    }
            }
            #endregion
        }

        /// <summary>
        /// 保存処理(SaveCampaignPrcPrSt())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private bool SaveCampaignPrcPrSt()
        {
            bool result = false;

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            //画面データ入力チェック処理
            bool chkSt = CheckDisplay();
            if (!chkSt)
            {
                return chkSt;
            }

            CampaignPrcPrSt campaignPrcPrSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];
            }

            ScreenToCampaignPrcPrSt(ref campaignPrcPrSt);

            int status = this._campaignPrcPrStAcs.Write(ref campaignPrcPrSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "PMKHN09611U",						// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (this.tEdit_SectionCodeAllowZero2.Enabled == true)
                        {
                            this.tEdit_SectionCodeAllowZero2.Focus();
                        }
                        else
                        {
                            this.tComboEditor_PRIORITYSETTING1.Focus();
                        }
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
                            "PMKHN09611U",							// アセンブリID
                            "PrcPrSt",  　　                 // プログラム名称
                            "CampaignPrcPrSt",                       // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._campaignPrcPrStAcs,				    	// エラーが発生したオブジェクト
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

            CampaignPrcPrStToDataSet(campaignPrcPrSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // 新規登録時がないの場合
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
            // 新規登録時
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                this.ScreenClear();
            }
            result = true;
            return result;
        }


        /// <summary>
        /// キャンペーン売価優先設定クラス格納処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からキャンペーン売価優先設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenToCampaignPrcPrSt(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            if (campaignPrcPrSt == null)
            {
                // 新規の場合
                campaignPrcPrSt = new CampaignPrcPrSt();
            }

            // 企業コード
            campaignPrcPrSt.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            campaignPrcPrSt.SectionCode = this.tEdit_SectionCodeAllowZero2.Text.Trim();

            campaignPrcPrSt.PrioritySettingCd1 = this.tComboEditor_PRIORITYSETTING1.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd2 = this.tComboEditor_PRIORITYSETTING2.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd3 = this.tComboEditor_PRIORITYSETTING3.SelectedIndex;

            campaignPrcPrSt.PrioritySettingCd4 = this.tComboEditor_PRIORITYSETTING4.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd5 = this.tComboEditor_PRIORITYSETTING5.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd6 = this.tComboEditor_PRIORITYSETTING6.SelectedIndex;
        }

        /// <summary>
        /// 画面データ入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面データ入力チェック処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = "設定が重複しています。";
            int zeroCount = 0;
            ArrayList notZero = new ArrayList();

            if (this.tEdit_SectionCodeAllowZero2.Text.Trim() == string.Empty)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMKHN09611U",							// アセンブリID
                    "拠点を入力して下さい。",	            // 表示するメッセージ
                    0,									    // ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン

                this.tEdit_SectionCodeAllowZero2.Focus();
                return false;
            }
            // --- ADD 2011/09/07 -------------------------------->>>>>
            // 拠点コードの存在チェック
            bool existCheck = false;
            // 全社共通は拠点マスタに登録されていないため、チェックの対象外
            if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText=="0")
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                    {
                        existCheck = true;
                        break;
                    }
                }
            }
            else
            {
                existCheck = true;
            }
            if (existCheck)
            {
                status = true;
            }
            else
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMKHN09611U",							// アセンブリID
                    "指定した拠点コードは存在しません。",	// 表示するメッセージ
                    0,									    // ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<

            try
            {
                if (this.tComboEditor_PRIORITYSETTING1.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING1.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING1.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING1.Focus();
                    }

                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING2.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING2.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING2.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING2.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING3.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING3.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING3.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING3.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING4.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING4.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING4.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING4.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
        
                if ((int)this.tComboEditor_PRIORITYSETTING5.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING5.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING5.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING5.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
         
                if ((int)this.tComboEditor_PRIORITYSETTING6.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING6.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING6.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING6.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
            }
            finally
            {
                if (notZero.Count < 6 - zeroCount)
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMKHN09611U",							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    status = false;
                }
            }
            return status;
        }

        private void PMKHN09611UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void uButton_Section_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                string name;
                string sectionMode = "";
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    if (this.tEdit_SectionCodeAllowZero2.DataText == "00" || this.tEdit_SectionCodeAllowZero2.DataText ==string.Empty)
                    {
                        this.tEdit_SectionGuideNm.DataText = "全社共通";
                        sectionMode = "1";
                    }
                    else
                    {
                       this.tEdit_SectionGuideNm.DataText = secInfoSet.SectionGuideNm.Trim();
                    }

                    if (GetSectionName(secInfoSet.SectionCode.Trim(), out name))
                    {
                        this.tEdit_SectionGuideNm.Text = name;

                        if (this._dataIndex < 0)
                        {
                            if (!this.ModeChangeProc(sectionMode, secInfoSet.SectionCode.Trim()))
                            {
                                this.tEdit_SectionCodeAllowZero2.Focus();
                            }
                            else
                            {
                                // 次フォーカス
                                this.SelectNextControl((Control)sender, true, true, true, true);
                            }
                        }
                    }
                }
                else if (status == 1)
                {
                    if (this.tEdit_SectionGuideNm.Text.Trim() == string.Empty)
                    {
                        this.tEdit_SectionCodeAllowZero2.Clear();
                    }
                    else
                    {
                        if (this._secInfoSetDic.ContainsKey(this.tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0')))
                        {
                            SecInfoSet secInfo = this._secInfoSetDic[this.tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0')];
                            if (this.tEdit_SectionGuideNm.Text.Trim() != secInfo.SectionGuideNm)
                            {
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionGuideNm.Clear();
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero2.Clear();
                            this.tEdit_SectionGuideNm.Clear();
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "uButton_Section")
            {
                return;
            }
            # region [一般処理]
            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                //case "tEdit_SectionCodeAllowZero": // DEL 2011/09/07
                case "tEdit_SectionCodeAllowZero2": // ADD 2011/09/07
                    {

                        // --- ADD 2011/09/07 -------------------------------->>>>>
                        isError = false;
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_Section;
                                        }
                                        break;
                                    }
                                case Keys.Right:
                                    {
                                        e.NextCtrl = this.uButton_Section;
                                        break;
                                    }
                            }
                        }
                        if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                        {
                            this.tEdit_SectionGuideNm.Clear();
                            return;
                        }
                        // --- ADD 2011/09/07 --------------------------------<<<<<
                        string sectionCode = this.tEdit_SectionCodeAllowZero2.Text.Trim();
                        string sectionMode = "";
                        // ----- UPD 2011/09/07 --------------------->>>>>
                        //if (sectionCode == string.Empty || sectionCode == "00")
                        if (sectionCode == "0" || sectionCode == "00")
                        // ----- UPD 2011/09/07 ---------------------<<<<<
                        {
                            sectionCode = "00";
                            sectionMode = "1";
                            if (e.NextCtrl == this.Cancel_Button)
                            {
                                return;
                            }
                           
                        }
                        string name;
                        // ----- ADD 2011/09/07 --------------------->>>>>
                        if (!string.IsNullOrEmpty(sectionCode))
                        {
                            this.tEdit_SectionCodeAllowZero2.Text = sectionCode.PadLeft(2, '0');
                        }
                        // ----- ADD 2011/09/07 ---------------------<<<<<
                        if (GetSectionName(sectionCode, out name))
                        {
                            if (e.NextCtrl != this.Ok_Button)
                            {
                                this.tEdit_SectionCodeAllowZero2.Text = (Convert.ToInt32(sectionCode)).ToString("00");
                                this.tEdit_SectionGuideNm.Text = name;
                            }
                            if (this._dataIndex < 0)
                            {
                                if (!this.ModeChangeProc(sectionMode, sectionCode))
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                                }
                                else
                                {
                                    this.tEdit_SectionCodeAllowZero2.Text = (Convert.ToInt32(sectionCode)).ToString("00");
                                    this.tEdit_SectionGuideNm.Text = name;
                                    if (e.NextCtrl != null && this.Mode_Label.Text == INSERT_MODE)
                                    {
                                        if (e.Key == Keys.LButton && e.NextCtrl == this.Ok_Button)
                                        {
                                            //保存処理を行う。
                                        }
                                        else
                                        {
                                            // --- ADD 2011/09/07 ------------------->>>>>
                                            if (e.Key == Keys.Right)
                                            {
                                                e.NextCtrl = this.uButton_Section;
                                            }
                                            else
                                            {
                                            // --- ADD 2011/09/07 -------------------<<<<<
                                                e.NextCtrl = this.tComboEditor_PRIORITYSETTING1;
                                            }// ADD 2011/09/07
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_PRIORITYSETTING1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラーメッセージ
                            TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                              "拠点が存在しません。", 			    // 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン

                            isError = true; // ADD 2011/09/08
                            this.tEdit_SectionCodeAllowZero2.Text = string.Empty;
                            this.tEdit_SectionGuideNm.Text = string.Empty;
                            e.NextCtrl = this.tEdit_SectionGuideNm;
                        }

                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING1":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING1.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING1.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd1;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING1.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING1.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING1.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING2":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING2.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING2.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd2;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING2.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING2.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING2.Text);
                            } 
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING3":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING3.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING3.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd3;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING3.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING3.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING3.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING4":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING4.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING4.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd4;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING4.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING4.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING4.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING5":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING5.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING5.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd5;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING5.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING5.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING5.Text);
                            }
                        } 
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING6":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING6.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING6.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd6;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING6.Text))
                             {
                                  this.tComboEditor_PRIORITYSETTING6.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING6.Text);
                             }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                    
            }
            # endregion

        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">sectionName</param>
        /// <returns>拠点名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private bool GetSectionName(string sectionCode, out string sectionName)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                sectionName = "全社共通";
                return true;
            }
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                sectionName = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                return true;
            }
            else
            {
                sectionName = string.Empty;
                return false;
            }
        }


        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs();
            }
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 売価優先設定チェックリスト
        /// </summary>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void checkPrcPrStADD()
        {
            for (int i = 0; i <= 6; i++)
            {
                string PrcPrSt_Number = i.ToString();
                this._checkPrcPrSt.Add(PrcPrSt_Number);
                this._checkPrcPrStNumber.Add(PrcPrSt_Number);
            }
            this._checkPrcPrSt.Add("0：なし");
            this._checkPrcPrSt.Add("1：ﾒｰｶｰ+品番");
            this._checkPrcPrSt.Add("2：ﾒｰｶｰ+BLｺｰﾄﾞ");
            this._checkPrcPrSt.Add("3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ");
            this._checkPrcPrSt.Add("4：ﾒｰｶｰ");
            this._checkPrcPrSt.Add("5：BLｺｰﾄﾞ");
            this._checkPrcPrSt.Add("6：販売区分");
        }

        /// <summary>
        /// 売価優先設定チェックリスト
        /// </summary>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void PrcPrStADDValue()
        {
            this._campaignPrcPrStCheckClone.PrioritySettingCd1 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING1.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd2 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING2.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd3 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING3.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd4 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING4.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd5 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING5.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd6 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING6.SelectedIndex);
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc(string sectionMode, string theSectionCode)
        {
            string msg = "";

            if (sectionMode == "1")
            {
                msg = "入力されたキャンペーン売価優先設定情報は既に登録されています。\n「拠点名称：全社共通」\n編集を行いますか？";
            }
            else
            {
                msg = "入力されたキャンペーン売価優先設定情報は既に登録されています。\n編集を行いますか？";
            }
        
           
            // キャンペーンコード
            int sectionCode = Convert.ToInt32(theSectionCode.ToString());

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsSectionCode = Convert.ToInt32(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE]);
                if (sectionCode == dsSectionCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたキャンペーン売価優先設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/08
                        // キャンペーンコードのクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        this.tEdit_SectionGuideNm.Text = string.Empty;
                        return false;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/08
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
                                // キャンペーンコードのクリア
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionGuideNm.Text = string.Empty;
                                this.tEdit_SectionCodeAllowZero2.Focus();
                                return false;
                            }
                    }
                    return true;
                }
            }
            return true;
        }
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load イベント(PMKHN09611UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09611UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // ガイドボタンのアイコン設定
            this.uButton_Section.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
            PrcPrStADDValue();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMKHN09611UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09611UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
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

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
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

            if (!SaveCampaignPrcPrSt())
            {
                return;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero2.Focus();
            }

        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // 最新情報
            ReadSecInfoSet();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }


        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
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

            int status = 0;

            CampaignPrcPrSt campaignPrcPrSt = null;
            // 復活対象データ取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];

            // 復活
            status = this._campaignPrcPrStAcs.Revival(ref campaignPrcPrSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        CampaignPrcPrStToDataSet(campaignPrcPrSt, this._dataIndex);
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
                            "PMKHN09611U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._campaignPrcPrStAcs,				// エラーが発生したオブジェクト
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
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
                "PMKHN09611U",						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }


            CampaignPrcPrSt campaignPrcPrSt = null;
            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];


            // 拠点情報論理削除処理
            int status = this._campaignPrcPrStAcs.Delete(campaignPrcPrSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._campaignPrcPrStTable.Remove(campaignPrcPrSt.FileHeaderGuid);

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
                            "PMKHN09611U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._campaignPrcPrStAcs, 				// エラーが発生したオブジェクト
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
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();

                campaignPrcPrSt = this._campaignPrcPrStClone.Clone();
                ScreenToCampaignPrcPrSt(ref campaignPrcPrSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                 
                 if ( !((this._campaignPrcPrStClone.PrioritySettingCd1 == campaignPrcPrSt.PrioritySettingCd1)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd2 == campaignPrcPrSt.PrioritySettingCd2)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd3 == campaignPrcPrSt.PrioritySettingCd3)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd4 == campaignPrcPrSt.PrioritySettingCd4)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd5 == campaignPrcPrSt.PrioritySettingCd5)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd6 == campaignPrcPrSt.PrioritySettingCd6)
                    && (this._campaignPrcPrStClone.SectionCode == campaignPrcPrSt.SectionCode)))
                   
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_QUESTION,
                       this.Name,
                       "編集中のデータが存在します。" + "\r\n" + "\r\n" +
                       "登録してもよいですか？",
                       0,
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxDefaultButton.Button1);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveCampaignPrcPrSt())
                                {
                                    return;
                                }
                                else
                                {
                                    this.tEdit_SectionCodeAllowZero2.Focus();
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

       #endregion ----- Control Events -----

    }
}

