//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/23  修正内容 : Redmine #23764 拠点管理設定 修正依頼対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/09/15  修正内容 : Redmine #25098 「自動送信区分」を非表示にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 修 正 日  2011/10/08  修正内容 : Redmine #25777 「自動送信区分」を復活にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2011/10/08  修正内容 : Redmine #25776  送信先拠点入力に自拠点コードも指定可能に変更の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/10/08  修正内容 : Redmine#25781 拠点管理設定マスタの復活処理のステータスチェックの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xupz
// 修 正 日  2011/11/10  修正内容 : Redmine #26228 「拠点管理改良／伝票日付による抽出対応
//--------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 拠点管理設定マスタメンテナンスフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理設定マスタメンテナンスを行います。</br>
    /// <br>             IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer : 李占川</br> 
    /// <br>Date       : 2009.03.25</br>
    /// <br></br>
    /// <br>Update Note: 2009/05/20 李占川</br>
    /// <br>             PVCS#99について、復活時の確認メッセージを修正します。</br>
    /// <br>Update Note: 2009/05/21 李占川</br>
    /// <br>             PVCS#89について、送受信対象拠点入力時点でチェックを行う様に変更します。</br>
    /// <br>Update Note: 2009/05/21 李占川</br>
    /// <br>             PVCS#100について、送信・受信が混在チェックを追加します。</br>
	/// <br>Update Note: 2011/07/21 張莉莉</br>
	/// <br>             SCM対応‐拠点管理（10704767-00）</br>
    /// <br>Update Note: 2011/10/08 yangmj</br>
    /// <br>             redmine#25776 送信先拠点入力に自拠点コードも指定可能に変更の対応</br>
    /// <br>Update Note: 2011/10/08 tianjw</br>
    /// <br>             Redmine#25781 拠点管理設定マスタの復活処理のステータスチェックの対応</br>
    /// </remarks>
    public partial class PMKYO09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region -- Constructor --
        /// <summary>
        /// 拠点管理設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 拠点管理設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public PMKYO09100UA()
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

            // 変数初期化
            this._dataIndex = -1;
            this._secMngSetAcs = new SecMngSetAcs();
            this._secMngSetTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            this._preSectionCode = string.Empty;
			this._preSendSecCd = string.Empty;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
        }
        # endregion

        # region -- Private Members --
        private SecMngSetAcs _secMngSetAcs;
        private string _enterpriseCode;
        private Hashtable _secMngSetTable;

        // 保存比較用Clone
        private SecMngSet _secMngSetClone;

        private string _preSectionCode;
		private string _preSendSecCd;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

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

        private const string ASSEMBLY_ID = "PMKYO09100U";

        private const string DELETE_DATE = "削除日";
        private const string VIEW_KIND_TITLE = "種別";
		private const string VIEW_RECEIVE_CONDITION_TITLE = "送受信区分";
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		//private const string VIEW_SECTION_NAME_TITLE = "送受信対象拠点";
		//private const string VIEW_SYNCEXEC_DATE_TITLE = "送受信実行日";
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		private const string VIEW_SECTION_NAME_TITLE = "抽出対象拠点";
		private const string VIEW_SENDSEC_NAME_TITLE = "送信先拠点";
		private const string VIEW_SYNCEXEC_DATE_TITLE = "送信実行日";
		private const string VIEW_AUTOSEND_DIV_TITLE = "自動送信";
		private const string VIEW_SNDFINDATA_DIV_TITLE = "送信済データ修正区分";
		private const string VIEW_SENDSEC_CODE_TITLE = "SendSecCode";
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        private const string VIEW_SECTION_CODE_TITLE = "SectionCode";
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string ALL_SECTIONCODE = "00";

        private const string KIND_TCOMEDITOR_VALUE0 = "データ";
        private const string KIND_TCOMEDITOR_VALUE1 = "マスタ";
        private const string RECEIVECONDITION_TCOMEDITOR_VALUE0 = "送信";
        private const string RECEIVECONDITION_TCOMEDITOR_VALUE1 = "受信";
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		private const string AUTOSENDDIV_TCOMEDITOR_VALUE0 = "する";
		private const string AUTOSENDDIV_TCOMEDITOR_VALUE1 = "しない";
		private const string SNDFINDATADIV_TCOMEDITOR_VALUE0 = "修正可";
        //private const string SNDFINDATADIV_TCOMEDITOR_VALUE1 = "修正不可"; //DEL 2011/11/10 xupz
        // ----- ADD 2011/11/10 xupz---------->>>>>
        private const string SNDFINDATADIV_TCOMEDITOR_VALUE1 = "修正不可（送信実行日以前）";
        private const string SNDFINDATADIV_TCOMEDITOR_VALUE2 = "修正不可（伝票日付以前）";
        // ----- ADD 2011/11/10 xupz----------<<<<<
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        # endregion

        # region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region -- Properties --
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

        # region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
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
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
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

            ArrayList secMngSetList = new ArrayList();

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._secMngSetTable.Clear();

            status = this._secMngSetAcs.SearchAll(out secMngSetList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SecMngSet secMngSet in secMngSetList)
                        {
                            // DataSet展開処理
                            SecMngSetToDataSet(secMngSet, index);
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
                            ASSEMBLY_ID,							// アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._secMngSetAcs,					    // エラーが発生したオブジェクト
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
        /// <br>Note	    : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。(未実装)</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
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
            SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

			//if (secMngSet.SectionCode.Trim() == ALL_SECTIONCODE)
			//{
			//    TMsgDisp.Show(this,                             // 親ウィンドウフォーム
			//            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
			//            ASSEMBLY_ID,							// アセンブリID
			//            "全社共通データは削除できません。",	    // 表示するメッセージ
			//            0,									    // ステータス値
			//            MessageBoxButtons.OK);					// 表示するボタン
			//    return (0);
			//}

            int status = 0;

            // 全体初期表示設定情報論理削除処理
            status = this._secMngSetAcs.LogicalDelete(ref secMngSet);

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
                            this._secMngSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 全体初期表示設定情報クラスデータセット展開処理
            SecMngSetToDataSet(secMngSet.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
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
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 種別
            appearanceTable.Add(VIEW_KIND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 送受信区分
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//appearanceTable.Add(VIEW_RECEIVE_CONDITION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_RECEIVE_CONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
			
			// 送受信対象コード
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			// 送信先拠点
			appearanceTable.Add(VIEW_SENDSEC_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SENDSEC_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

			// 送受信実行日
            appearanceTable.Add(VIEW_SYNCEXEC_DATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));//DEL 2011/09/15 fengwx #25098
            //appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));//ADD 2011/09/15 fengwx #25098 //  DEL 2011/10/08  dingjx  #25777
            appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));   //  ADD 2011/10/08  dingjx  #25777
			appearanceTable.Add(VIEW_SNDFINDATA_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        # region -- Private Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date	   : 2009.03.27</br>
        /// </remarks>
        private void SecMngSetToDataSet(SecMngSet secMngSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (secMngSet.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = secMngSet.UpdateDateTimeJpInFormal;
            }

            // 種別
            switch (secMngSet.Kind)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_KIND_TITLE] = KIND_TCOMEDITOR_VALUE0;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_KIND_TITLE] = KIND_TCOMEDITOR_VALUE1;
                    break;
            }

            // 送受信区分
            switch (secMngSet.ReceiveCondition)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVE_CONDITION_TITLE] = RECEIVECONDITION_TCOMEDITOR_VALUE0;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVE_CONDITION_TITLE] = RECEIVECONDITION_TCOMEDITOR_VALUE1;
                    break;
            }

            // 拠点名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = secMngSet.SectionCode.Trim().PadLeft(2, '0');
            // UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(secMngSet.SectionCode);
			if (secMngSet.Kind == 1)
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = string.Empty;
			}
			else
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(secMngSet.SectionCode);
			}
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
			//// 送受信実行日
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SYNCEXEC_DATE_TITLE] = secMngSet.SyncExecDate.ToString("yyyy年M月d日H時m分s秒");

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			// 送信先拠点
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDSEC_CODE_TITLE] = secMngSet.SendDestSecCode.Trim().PadLeft(2, '0');
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDSEC_NAME_TITLE] = GetSectionName(secMngSet.SendDestSecCode);

			// 送受信実行日
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SYNCEXEC_DATE_TITLE] = secMngSet.SyncExecDate.ToString("yyyy年M月d日H時m分s秒");

			// 自動送信
			switch (secMngSet.AutoSendDiv)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSEND_DIV_TITLE] = AUTOSENDDIV_TCOMEDITOR_VALUE0;
					break;
				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSEND_DIV_TITLE] = AUTOSENDDIV_TCOMEDITOR_VALUE1;
					break;
			}
			// 送信済みデータ修正区分
			if (secMngSet.Kind == 1)
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = string.Empty;
			}
			else
			{
				switch (secMngSet.SndFinDataEdDiv)
				{
					case 0:
						this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE0;
						break;
					case 1:
						this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE1;
						break;
                    // ----- ADD 2011/11/10 xupz---------->>>>>
                    case 2:
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE2;
                        break;
                    // ----- ADD 2011/11/10 xupz----------<<<<<
				}
			}
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = secMngSet.FileHeaderGuid;

            if (this._secMngSetTable.ContainsKey(secMngSet.FileHeaderGuid) == true)
            {
                this._secMngSetTable.Remove(secMngSet.FileHeaderGuid);
            }
            this._secMngSetTable.Add(secMngSet.FileHeaderGuid, secMngSet);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable secMngSetTable = new DataTable(VIEW_TABLE);

            // 削除日
            secMngSetTable.Columns.Add(DELETE_DATE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_KIND_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_RECEIVE_CONDITION_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
			//secMngSetTable.Columns.Add(VIEW_SYNCEXEC_DATE_TITLE, typeof(string));

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			// 送信先拠点
			secMngSetTable.Columns.Add(VIEW_SENDSEC_CODE_TITLE, typeof(string));
			secMngSetTable.Columns.Add(VIEW_SENDSEC_NAME_TITLE, typeof(string));
			secMngSetTable.Columns.Add(VIEW_SYNCEXEC_DATE_TITLE, typeof(string));
			// 自動送信
			secMngSetTable.Columns.Add(VIEW_AUTOSEND_DIV_TITLE, typeof(string));
			// 送信済みデータ修正区分
			secMngSetTable.Columns.Add(VIEW_SNDFINDATA_DIV_TITLE, typeof(string));
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            secMngSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(secMngSetTable);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 種別
            Kind_tComEditor.Items.Clear();
            Kind_tComEditor.Items.Add(0, KIND_TCOMEDITOR_VALUE0);
            Kind_tComEditor.Items.Add(1, KIND_TCOMEDITOR_VALUE1);
            Kind_tComEditor.MaxDropDownItems = Kind_tComEditor.Items.Count;

            // 送受信区分
            ReceiveCondition_tComEditor.Items.Clear();
            ReceiveCondition_tComEditor.Items.Add(0, RECEIVECONDITION_TCOMEDITOR_VALUE0);
            ReceiveCondition_tComEditor.Items.Add(1, RECEIVECONDITION_TCOMEDITOR_VALUE1);
            ReceiveCondition_tComEditor.MaxDropDownItems = ReceiveCondition_tComEditor.Items.Count;

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			// 自動送信
			auto_tComboEditor.Items.Clear();
			auto_tComboEditor.Items.Add(0, AUTOSENDDIV_TCOMEDITOR_VALUE0);
			auto_tComboEditor.Items.Add(1, AUTOSENDDIV_TCOMEDITOR_VALUE1);
			auto_tComboEditor.MaxDropDownItems = auto_tComboEditor.Items.Count;
			// 送信済みデータ修正区分
			sndFin_tComboEditor.Items.Clear();
			sndFin_tComboEditor.Items.Add(0, SNDFINDATADIV_TCOMEDITOR_VALUE0);
			sndFin_tComboEditor.Items.Add(1, SNDFINDATADIV_TCOMEDITOR_VALUE1);
            // ----- ADD 2011/11/10 xupz---------->>>>>
            sndFin_tComboEditor.Items.Add(2, SNDFINDATADIV_TCOMEDITOR_VALUE2);
            // ----- ADD 2011/11/10 xupz----------<<<<<
			sndFin_tComboEditor.MaxDropDownItems = sndFin_tComboEditor.Items.Count;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
		/// <br>Update Note: 2011/07/21 張莉莉</br>
		/// <br>             SCM対応‐拠点管理（10704767-00）</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionName.Text = string.Empty;
			this.tEdit_SectionCode.Text = string.Empty;
            this._preSectionCode = string.Empty;
            this.Kind_tComEditor.SelectedIndex = 0;
            this.ReceiveCondition_tComEditor.SelectedIndex = 0;
            this.tNedit_SyncExecDateYear.Text = string.Empty;
            this.tNedit_SyncExecDateMonth.Text = string.Empty;
            this.tNedit_SyncExecDateDay.Text = string.Empty;
            this.tNedit_SyncExecDateHour.Text = string.Empty;
            this.tNedit_SyncExecDateMinute.Text = string.Empty;
            this.tNedit_SyncExecDateSecond.Text = string.Empty;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			this.tEdit_SendSecCd.Text = string.Empty;
			this.tEdit_SendSecName.Text = string.Empty;
			this.auto_tComboEditor.SelectedIndex = 0;
			this.sndFin_tComboEditor.SelectedIndex = 0;
			this._preSendSecCd = string.Empty;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタクラス画面展開処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 拠点管理設定マスタオブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/27</br>
        /// </remarks>
        private void SecMngSetToScreen(SecMngSet secMngSet)
        {
            // 種別
            this.Kind_tComEditor.SelectedIndex = secMngSet.Kind;
            // 送受信区分
            this.ReceiveCondition_tComEditor.SelectedIndex = secMngSet.ReceiveCondition;
            // 拠点コード
			this.tEdit_SectionCode.Text = secMngSet.SectionCode.Trim().PadLeft(2, '0');
            // 拠点名
            this.tEdit_SectionName.Text = this.GetSectionName(secMngSet.SectionCode);
            // 送受信実行日
            List<string> dateList = this.GetSyncExecDateList(secMngSet.SyncExecDate);

            this.tNedit_SyncExecDateYear.Text = dateList[0];
            this.tNedit_SyncExecDateMonth.Text = dateList[1];
            this.tNedit_SyncExecDateDay.Text = dateList[2];
            this.tNedit_SyncExecDateHour.Text = dateList[3];
            this.tNedit_SyncExecDateMinute.Text = dateList[4];
            this.tNedit_SyncExecDateSecond.Text = dateList[5];

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			this.tEdit_SendSecCd.Text = secMngSet.SendDestSecCode.Trim().PadLeft(2, '0');
			this.tEdit_SendSecName.Text = this.GetSectionName(secMngSet.SendDestSecCode);
			this.auto_tComboEditor.SelectedIndex = secMngSet.AutoSendDiv;
			this.sndFin_tComboEditor.SelectedIndex = secMngSet.SndFinDataEdDiv;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面情報拠点管理設定マスタクラス格納処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note        : 画面情報から拠点管理設定マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenToSecMngSet(ref SecMngSet secMngSet)
        {
            if (secMngSet == null)
            {
                // 新規の場合
                secMngSet = new SecMngSet();
            }
            //企業コード
            secMngSet.EnterpriseCode = this._enterpriseCode;

            // 種別
            secMngSet.Kind = (int)this.Kind_tComEditor.Value;
            // 受信状況
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//secMngSet.ReceiveCondition = (int)this.ReceiveCondition_tComEditor.Value;
			secMngSet.ReceiveCondition = 0;
			// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
            // 拠点コード
			secMngSet.SectionCode = this.tEdit_SectionCode.DataText.PadLeft(2, '0');
            // シンク実行日付
            secMngSet.SyncExecDate = this.GetSyncExecDate();

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			// 送信先拠点
			secMngSet.SendDestSecCode = this.tEdit_SendSecCd.DataText.Trim().PadLeft(2,'0');
			// 自動送信
			secMngSet.AutoSendDiv = (int)this.auto_tComboEditor.Value;
			// 送信済データ修正区分
			secMngSet.SndFinDataEdDiv = (int)this.sndFin_tComboEditor.Value;
			// 種別は「マスタ」の場合
			if ((int)this.Kind_tComEditor.Value == 1)
			{
				secMngSet.SectionCode = ALL_SECTIONCODE;
				secMngSet.SndFinDataEdDiv = 0;
			}

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SecMngSet secMngSet = new SecMngSet();
                //クローン作成
                this._secMngSetClone = secMngSet.Clone();
                this._indexBuf = this._dataIndex;

                //// 画面情報を比較用クローンにコピーします
                ScreenToSecMngSet(ref this._secMngSetClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                //// フォーカス設定
                this.Kind_tComEditor.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

                // 全体初期表示情報クラス画面展開処理
                SecMngSetToScreen(secMngSet);

                if (secMngSet.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
					// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					//this.Kind_tComEditor.Focus();
					this.tNedit_SyncExecDateYear.Focus();
					// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                    // クローン作成
                    this._secMngSetClone = secMngSet.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSecMngSet(ref this._secMngSetClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note        : 画面の入力許可を制御します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // ボタン
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // 入力項目
                    this.Kind_tComEditor.Enabled = true;
                    this.ReceiveCondition_tComEditor.Enabled = true;
					this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.tNedit_SyncExecDateYear.Enabled = true;
                    this.tNedit_SyncExecDateMonth.Enabled = true;
                    this.tNedit_SyncExecDateDay.Enabled = true;
                    this.tNedit_SyncExecDateHour.Enabled = true;
                    this.tNedit_SyncExecDateMinute.Enabled = true;
                    this.tNedit_SyncExecDateSecond.Enabled = true;

					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = true;
					this.SendSecGuide_Button.Enabled = true;
					this.auto_tComboEditor.Enabled = true;
					this.sndFin_tComboEditor.Enabled = true;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    break;
                case UPDATE_MODE:
                    // ボタン
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // 入力項目
                    this.Kind_tComEditor.Enabled = false;
                    this.ReceiveCondition_tComEditor.Enabled = false;
					this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_SyncExecDateYear.Enabled = true;
                    this.tNedit_SyncExecDateMonth.Enabled = true;
                    this.tNedit_SyncExecDateDay.Enabled = true;
                    this.tNedit_SyncExecDateHour.Enabled = true;
                    this.tNedit_SyncExecDateMinute.Enabled = true;
                    this.tNedit_SyncExecDateSecond.Enabled = true;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = false;
					this.SendSecGuide_Button.Enabled = false;
					this.auto_tComboEditor.Enabled = true;
					this.sndFin_tComboEditor.Enabled = true;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    break;
                case DELETE_MODE:
                    // ボタン
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 入力項目
                    this.Kind_tComEditor.Enabled = false;
                    this.ReceiveCondition_tComEditor.Enabled = false;
					this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_SyncExecDateYear.Enabled = false;
                    this.tNedit_SyncExecDateMonth.Enabled = false;
                    this.tNedit_SyncExecDateDay.Enabled = false;
                    this.tNedit_SyncExecDateHour.Enabled = false;
                    this.tNedit_SyncExecDateMinute.Enabled = false;
                    this.tNedit_SyncExecDateSecond.Enabled = false;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = false;
					this.SendSecGuide_Button.Enabled = false;
					this.auto_tComboEditor.Enabled = false;
					this.sndFin_tComboEditor.Enabled = false;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : データ更新時の排他処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    ASSEMBLY_ID,							// アセンブリID
                    "既に他端末より更新されています。",	    // 表示するメッセージ
                    status,									// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	拠点管理設定マスタメンテナンス画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note	    : 拠点管理設定マスタメンテナンス画面の入力チェックをします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				//// 送受信対象拠点コードの必須入力チェック
				//if (this.tEdit_SecCd.DataText.Trim() == string.Empty)
				//{
				//    checkMessage = "送受信対象拠点が設定されていません。";
				//    returnStatus = 10;
				//    return returnStatus;
				//}
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				if(this.Kind_tComEditor.SelectedIndex == 0)
				{
					// 送信対象拠点コードの必須入力チェック
					if (this.tEdit_SectionCode.DataText.Trim() == string.Empty)
					{
						//checkMessage = "送受信対象拠点が設定されていません。";
						checkMessage = "抽出対象拠点コードが設定されていません。";
						returnStatus = 10;
						return returnStatus;
					}
				}

				// 送信先拠点コードの必須入力チェック
				if (this.tEdit_SendSecCd.DataText.Trim() == string.Empty)
				{
					checkMessage = "送信先拠点が設定されていません。";
					//returnStatus = 10;// DEL 2011.08.23
					returnStatus = 50;// ADD 2011.08.23
					return returnStatus;
				}
                // DEL 2011/10/08--------->>>>>>
                //// ADD 2011.08.23--------->>>>>>
                //// 自拠点チェック
                //string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //if (this.tEdit_SendSecCd.DataText.Trim().Equals(loginSectionCode.Trim()))
                //{
                //    checkMessage = "送信先に自拠点が登録できません。";
                //    returnStatus = 50;
                //    return returnStatus;
                //}
                //// ADD 2011.08.23---------<<<<<<
                // DEL 2011/10/08---------<<<<<<

				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                // 送受信実行日の必須入力チェック
                if (this.tNedit_SyncExecDateYear.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateMonth.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateDay.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateHour.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateMinute.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateSecond.DataText.Trim() == string.Empty)
                {
					//checkMessage = "送受信実行日が設定されていません。";
					checkMessage = "送信実行日が設定されていません。";
                    returnStatus = 20;
                    return returnStatus;
                }

                if (GetSyncExecDate() == DateTime.MinValue)
                {
					//checkMessage = "送受信実行日が不正な日時です。";
					checkMessage = "送信実行日が不正な日時です。";
                    returnStatus = 20;
                    return returnStatus;
                }

                returnStatus = this.CheckScreenCondtion(ref checkMessage);
                if (returnStatus != 0)
                {
                    if (returnStatus == 2)
                    {
                        // 新規登録時
                        if (this.Mode_Label.Text.Equals(INSERT_MODE))
                        {
                            returnStatus = 20;
                            return returnStatus;
                        }
                        // 修正時
                        else if (this.Mode_Label.Text.Equals(UPDATE_MODE))
                        {
                            DialogResult result = TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                checkMessage,
                                0, 									// ステータス値
                                MessageBoxButtons.OKCancel,
                                MessageBoxDefaultButton.Button2);	// 表示するボタン

                            if (result == DialogResult.OK)
                            {
                                returnStatus = 0;
                                return returnStatus;
                            }
                            else
                            {
                                returnStatus = 40;
                                return returnStatus;
                            }
                        }
                        else
                        {
                            // なし
                        }
                    }
					// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					//else if (returnStatus == 3 || returnStatus == 4)
					//{
					//    // 新規場合
					//    if (this.Mode_Label.Text.Equals(INSERT_MODE))
					//    {
					//        returnStatus = 30;
					//        return returnStatus;
					//    }
					//    // その他場合
					//    else
					//    {
					//        returnStatus = 0;
					//        return returnStatus;
					//    }
					//}
					// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                }
            }
            finally
            {
                if (returnStatus == 10
                    || returnStatus == 20
                    || returnStatus == 30
					|| returnStatus == 50)// ADD 2011.08.23
                {
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							// アセンブリID
                        checkMessage,	                        // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                }

                //エラーステータスに合わせてフォーカスセット
                switch (returnStatus)
                {
                    case 10:
                        {
							this.tEdit_SectionCode.Focus();
                            break;
                        }
                    case 20:
                    case 40:
                        {
                            this.tNedit_SyncExecDateYear.Focus();
                            break;
                        }
                    case 30:
                        {
                            this.Kind_tComEditor.Focus();
                            break;
                        }
					// ADD 2011.08.23------->>>>>
					case 50:
						{
							this.tEdit_SendSecCd.Focus();
							break;
						}
					// ADD 2011.08.23-------<<<<<
                }
            }

            return returnStatus;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	入力チェック処理(種別と送受信区分チェック)
        /// </summary>
        /// <remarks>
        /// <br>Note	    : 画面の入力チェックをします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private int CheckScreenCondtion(ref string message)
        {
            int status = 0;

            // --- ADD 2009/05/21 ------------------------------->>>>>
            SecMngSet secMngSet = new SecMngSet();
            ScreenToSecMngSet(ref secMngSet);

            status = this._secMngSetAcs.CheckScreenData(ref secMngSet);

            switch (status)
            {
                // 送受信実行日チェック
                case 2:
                    if (this.Mode_Label.Text.Equals(UPDATE_MODE))
                    {
                        message = "前回月次更新日以前ですがよろしいですか？";
                    }
                    else
                    {
                        message = "前回月次更新日以前は設定できません。";
                    }
                    break;
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				//// 送信の設定は複数設定チェック
				//case 3:
				//    message = "送信の設定は複数設定できません。";
				//    break;

				//// データは送信・受信のどちらかのみ設定可能チェック
				//case 4:
				//    message = "データは送信・受信のどちらかのみ設定可能です。";
				//    break;
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
            }
            // --- ADD 2009/05/21 ------------------------------<<<<<

            // --- DEL 2009/05/21 ------------------------------->>>>>
            //if (this.Kind_tComEditor.SelectedIndex == 0
            //    && this.ReceiveCondition_tComEditor.SelectedIndex == 0)
            //{
            //    int totalNum = this._secMngSetAcs.CheckSearch(this._enterpriseCode);
            //    if (totalNum > 0)
            //    {
            //        checkResult = false;
            //    }
            //}
            // --- DEL 2009/05/21 ------------------------------<<<<<

            return status;
        }

        // --- ADD 2009/05/21 ------------------------------->>>>>
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　送受信対象拠点の存在チェック
        /// </summary>
        /// <param name="flag">0:種別; 1:送受信区分; 2:送受信対象拠点; 3:送信先拠点</param>
        /// <remarks>
        /// <br>Note　　　  : 送受信対象拠点の存在チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private bool ModeChangeProc(int flag)
        {
            bool status = false;

            if (this.DataIndex > 0 || this._indexBuf == -2)
            {
                return status;
            }

            string iMsg1 = "入力されたコードの拠点管理設定情報が既に登録されています。\n編集を行いますか？";
            string iMsg2 = "入力されたコードの拠点管理設定情報は既に削除されています。";

            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			string sSendSecCd =  this.tEdit_SendSecCd.DataText.Trim().PadLeft(2, '0');
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
            string sKind;
            if (this.Kind_tComEditor.SelectedIndex == 0)
            {
                sKind = KIND_TCOMEDITOR_VALUE0;
            }
            else
            {
                sKind = KIND_TCOMEDITOR_VALUE1;
            }

            string sReCondition;
            if (this.ReceiveCondition_tComEditor.SelectedIndex == 0)
            {
                sReCondition = RECEIVECONDITION_TCOMEDITOR_VALUE0;
            }
            else
            {
                sReCondition = RECEIVECONDITION_TCOMEDITOR_VALUE1;
            }

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string section = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                string kind = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_KIND_TITLE];
                string receiveCondition = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_RECEIVE_CONDITION_TITLE];
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				string sendSecCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SENDSEC_CODE_TITLE];
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                if (sectionCode.Equals(section.Trim().PadLeft(2, '0'))
                    && sKind.Equals(kind)
                    && sReCondition.Equals(receiveCondition)
					&& sSendSecCd.Equals(sendSecCode.Trim().PadLeft(2, '0'))// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
					)
                {
                    // 入力されたコードは削除状態場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != string.Empty)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg2, 0, MessageBoxButtons.OK);
                        if (flag == 0)
                        {
                            this.Kind_tComEditor.SelectedIndex = 0;
                        }
                        else if (flag == 1)
                        {
                            this.ReceiveCondition_tComEditor.SelectedIndex = 0;
                        }
						else if (flag == 2)
                        {
							this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                        }
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						else
						{
							this.tEdit_SendSecCd.Clear();
							this.tEdit_SendSecName.Clear();
						}
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                        return true;
                    }

                    // 入力されたコードが存在場合
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg1, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this.DataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            break;

                        case DialogResult.No:
                            if (flag == 0)
                            {
                                this.Kind_tComEditor.SelectedIndex = 0;
                            }
                            else if (flag == 1)
                            {
                                this.ReceiveCondition_tComEditor.SelectedIndex = 0;
                            }
							else if (flag == 2)
                            {
								this.tEdit_SectionCode.Clear();
                                this.tEdit_SectionName.Clear();
                            }
							// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
							else
							{
								this.tEdit_SendSecCd.Clear();
								this.tEdit_SendSecName.Clear();
							}
							// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                            break;
                    }
                    return true;
                }
            }
            return status;
        }
        // --- ADD 2009/05/21 ------------------------------<<<<<

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　保存処理(SaveSecMngSet())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private bool SaveSecMngSet()
        {
            bool result = false;
            Control control = null;

            //画面データ入力チェック処理
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);

            if (chkSt != 0)
            {
                return result;
            }

            SecMngSet secMngSet = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                secMngSet = ((SecMngSet)this._secMngSetTable[guid]).Clone();
            }

            ScreenToSecMngSet(ref secMngSet);

            int status = this._secMngSetAcs.Write(ref secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
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
                            ASSEMBLY_ID,							// アセンブリID
                            this.Text,  　　                        // プログラム名称
                            "SaveSecMngSet",                        // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._secMngSetAcs,				    	// エラーが発生したオブジェクト
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

            this.SecMngSetToDataSet(secMngSet, this.DataIndex);

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
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/27</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

			//if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
			//{
			//    sectionName = "全社共通";
			//    return sectionName;
			//}

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

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
                sectionName = string.Empty;
            }

            return sectionName;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 送受信実行日のconver処理(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 送受信実行日のconver処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private DateTime GetSyncExecDate()
        {
            StringBuilder syncExecDateBuf = new StringBuilder();
            syncExecDateBuf.Append(this.tNedit_SyncExecDateYear.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateMonth.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateDay.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateHour.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateMinute.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateSecond.Value);

            DateTime syncExecDate = new DateTime();
            try
            {
                syncExecDate = string.IsNullOrEmpty(syncExecDateBuf.ToString())
                    ? DateTime.MaxValue
                    : new DateTime(
                    this.tNedit_SyncExecDateYear.GetInt(),
                    this.tNedit_SyncExecDateMonth.GetInt(),
                    this.tNedit_SyncExecDateDay.GetInt(),
                    Convert.ToInt32(this.tNedit_SyncExecDateHour.DataText),
                    Convert.ToInt32(this.tNedit_SyncExecDateMinute.DataText),
                    Convert.ToInt32(this.tNedit_SyncExecDateSecond.DataText),
                    0);
            }
            catch
            {
                syncExecDate = DateTime.MinValue;
            }

            return syncExecDate;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 送受信実行日のconver処理(ToArrayList)
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 送受信実行日のconver処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private List<string> GetSyncExecDateList(DateTime syncExecDate)
        {
            List<string> syncExecDateList = new List<string>();

            String dateStr = syncExecDate.ToString("yyyyMMddHHmmss");
            syncExecDateList.Add(dateStr.Substring(0, 4));
            syncExecDateList.Add(dateStr.Substring(4, 2));
            syncExecDateList.Add(dateStr.Substring(6, 2));
            syncExecDateList.Add(dateStr.Substring(8, 2));
            syncExecDateList.Add(dateStr.Substring(10, 2));
            syncExecDateList.Add(dateStr.Substring(12, 2));

            return syncExecDateList;
        }

        /// <summary>
        /// 同一データのメッセージ
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 既に拠点管理設定マスタに同一データある場合、メッセージがある。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/30</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データが既に存在しています。", 	// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
			this.tEdit_SectionCode.Focus();

			control = tEdit_SectionCode;
        }
        # endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load イベント(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
			this.SendSecGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）


            // 画面初期設定処理
            ScreenInitialSetting();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/03/25</br>
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
                    this._preSectionCode = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.ModeChangeProc(2);
					
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		/// <summary>
		/// Control.Click イベント(SectionGuide_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		private void SendSecGuide_Button_Click(object sender, EventArgs e)
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
					bool chkFlg = CheckSection(secInfoSet.SectionCode.Trim());

					if (!chkFlg)
					{
						TMsgDisp.Show(this,                     // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						ASSEMBLY_ID,							// アセンブリID
						"指定した送信先拠点は企業設定に登録されていません。",	                // 表示するメッセージ
						0,									    // ステータス値
						MessageBoxButtons.OK);					// 表示するボタン

						this.tEdit_SendSecCd.DataText = this._preSendSecCd;
					}
					else
					{
						this.tEdit_SendSecCd.DataText = secInfoSet.SectionCode.Trim();
						this._preSendSecCd = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
						this.tEdit_SendSecName.DataText = secInfoSet.SectionGuideNm.Trim();
					}

					this.ModeChangeProc(3);
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/03/25</br>
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

            int status = 0;

            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

            // 拠点情報論理削除処理
            status = this._secMngSetAcs.Delete(secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._secMngSetTable.Remove(secMngSet.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._secMngSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Save_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
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

            if (!SaveSecMngSet())
            {
                return;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/03/25</br>
        /// <br>Update Note: 2011/10/08 tianjw</br>
        /// <br>             Redmine#25781 拠点管理設定マスタの復活処理のステータスチェックの対応</br>
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

            // 確認メッセージ
            DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,                       // エラーレベル
                ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                //"現在表中の拠点管理設定マスタを復活します。"+ "\r\n"  //DEL 2009/05/20
                "現在表示中の拠点管理設定マスタを復活します。" + "\r\n"
                + "よろしいですか？", 					              // 表示するメッセージ
                0, 					                                  // ステータス値
                MessageBoxButtons.YesNo);	                          // 表示するボタン

            if (res != DialogResult.Yes)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            string msg = string.Empty;
            status = this.CheckScreenCondtion(ref msg);
            // ----- DEL 2011/10/08 -------------------->>>>>
            //if (status == 3 || status == 4)
            //{
            //    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
            //        ASSEMBLY_ID,							// アセンブリID
            //        msg,	                                // 表示するメッセージ
            //        0,									    // ステータス値
            //        MessageBoxButtons.OK);					// 表示するボタン

            //    return;
            //}
            // ----- DEL 2011/10/08 --------------------<<<<<
            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SecMngSet secMngSet = ((SecMngSet)this._secMngSetTable[guid]).Clone();


            //  拠点管理設定マスタ論理削除復活処理
            status = this._secMngSetAcs.Revival(ref secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        SecMngSetToDataSet(secMngSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._secMngSetAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SecMngSet compareSecMngSet = new SecMngSet();

                compareSecMngSet = this._secMngSetClone.Clone();
                ScreenToSecMngSet(ref compareSecMngSet);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._secMngSetClone.Equals(compareSecMngSet))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SaveSecMngSet();

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
            this._preSectionCode = string.Empty;

			this._preSendSecCd = string.Empty;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカスローストときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

			if (e.PrevCtrl == this.tEdit_SectionCode)
            {
                // --- ADD 2009/05/21 ------------------------------->>>>>
                // 送受信対象拠点の存在チェック
                if (this.ModeChangeProc(2))
                {
                    return;
                }
                // --- ADD 2009/05/21 ------------------------------<<<<<
                bool flag = true;
                try
                {
                    // 拠点コード取得
					string sectionCode = this.tEdit_SectionCode.DataText;
					if (sectionCode.Trim().Equals(ALL_SECTIONCODE) || sectionCode.Trim().Equals(""))
					{
						this.tEdit_SectionName.DataText = string.Empty;
						this._preSectionCode = string.Empty;
						flag = false;
						return;
					}

                    if (sectionCode.Trim().Equals(this._preSectionCode))
                    {
						this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
                        flag = true;
                        return;
                    }

                    // 拠点名称取得
                    string sectionName = GetSectionName(sectionCode);

                    if (sectionName.Trim() != string.Empty)
                    {
                        this._preSectionCode = sectionCode;
                        this.tEdit_SectionName.DataText = sectionName;
						this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');
                        flag = true;
                    }
                    else
                    {
                        TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							// アセンブリID
                        "指定した拠点コードは存在しません。",	                // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

						this.tEdit_SectionCode.DataText = this._preSectionCode;
                        flag = false;
                    }
                }
                finally
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (flag)
                            {
                                // フォーカス設定
								e.NextCtrl = this.tEdit_SendSecCd;
                            }
                            else
                            {
                                // フォーカス設定
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                    }
                }
            }

			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			if (e.PrevCtrl == this.tEdit_SendSecCd)
			{
				// --- ADD 2009/05/21 ------------------------------->>>>>
				// 送受信対象拠点の存在チェック
				if (this.ModeChangeProc(3))
				{
					return;
				}
				// --- ADD 2009/05/21 ------------------------------<<<<<
				bool flag = true;
				try
				{
					// 拠点コード取得
					string sendSecCd = this.tEdit_SendSecCd.DataText.Trim().PadLeft(2, '0');

					if (sendSecCd.Trim().Equals(ALL_SECTIONCODE) || sendSecCd.Trim().Equals(""))
					{
						this.tEdit_SendSecCd.Text = string.Empty;
						this.tEdit_SendSecName.DataText = string.Empty;
						this._preSendSecCd = string.Empty;
						flag = false;
						return;
					}

					if (sendSecCd.Trim().Equals(this._preSendSecCd))
					{
						this.tEdit_SendSecCd.Text = sendSecCd.Trim().PadLeft(2, '0');
						flag = true;
						return;
					}

					// 拠点名称取得
					string sectionName = GetSectionName(sendSecCd);

					if (sectionName.Trim() != string.Empty)
					{
						// 企業設定に登録しない拠点チェック
						bool checkFlg = CheckSection(sendSecCd);
						
						if (!checkFlg)
						{
							TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							ASSEMBLY_ID,							// アセンブリID
							"指定した送信先拠点は企業設定に登録されていません。",	                // 表示するメッセージ
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン

							this.tEdit_SendSecCd.DataText = this._preSendSecCd;
							flag = false;
							return;
						}
						else
						{
							this._preSendSecCd = sendSecCd;
							this.tEdit_SendSecName.DataText = sectionName;
							this.tEdit_SendSecCd.Text = sendSecCd.Trim().PadLeft(2, '0');
							flag = true;
						}
					}
					else
					{
						TMsgDisp.Show(this,                     // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						ASSEMBLY_ID,							// アセンブリID
						"指定した拠点コードは存在しません。",	                // 表示するメッセージ
						0,									    // ステータス値
						MessageBoxButtons.OK);					// 表示するボタン

						this.tEdit_SendSecCd.DataText = this._preSendSecCd;
						flag = false;
					}
				}
				finally
				{
					if (e.ShiftKey == false)
					{
						if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
						{
							if (flag)
							{
								// フォーカス設定
								e.NextCtrl = this.tNedit_SyncExecDateYear;
							}
							else
							{
								// フォーカス設定
								e.NextCtrl = this.SendSecGuide_Button;
							}
						}
					}
				}
			}
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
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
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged イベント(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_VisibleChanged(object sender, EventArgs e)
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

            // 画面クリア処理
            ScreenClear();

            Timer.Enabled = true;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing イベント(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            this._preSectionCode = string.Empty;
			this._preSendSecCd = string.Empty;// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）
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
        ///	ValueChangedイベント(tNedit_SyncExecDateYear)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateYear_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateYear.DataText.Length == tNedit_SyncExecDateYear.MaxLength)
            {
                tNedit_SyncExecDateMonth.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(tNedit_SyncExecDateMonth)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateMonth_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateMonth.DataText.Length == this.tNedit_SyncExecDateMonth.MaxLength)
            {
                tNedit_SyncExecDateDay.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(tNedit_SyncExecDateDay)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateDay_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateDay.DataText.Length == this.tNedit_SyncExecDateDay.MaxLength)
            {
                tNedit_SyncExecDateHour.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(tNedit_SyncExecDateHour)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateHour_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateHour.DataText.Length == this.tNedit_SyncExecDateHour.MaxLength)
            {
                tNedit_SyncExecDateMinute.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(tNedit_SyncExecDateMinute)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateMinute_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateMinute.DataText.Length == this.tNedit_SyncExecDateMinute.MaxLength)
            {
                tNedit_SyncExecDateSecond.Focus();
            }
        }

        // --- ADD 2009/05/21 ------------------------------->>>>>
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(ReceiveCondition_tComEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void ReceiveCondition_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // 送受信対象拠点の存在チェック
            this.ModeChangeProc(1);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChangedイベント(Kind_tComEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void Kind_tComEditor_ValueChanged(object sender, EventArgs e)
        {
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			if (this.Kind_tComEditor.SelectedIndex == 1)
			{
				this.uLabel_SectionCode.Visible = false;
				this.tEdit_SectionCode.Visible = false;
				this.tEdit_SectionName.Visible = false;
				this.SectionGuide_Button.Visible = false;
				this.ultraLabel3.Visible = false;
				this.sndFin_tComboEditor.Visible = false;

				this.tEdit_SectionCode.Text = string.Empty;
				this.tEdit_SectionName.Text = string.Empty;
				this.sndFin_tComboEditor.SelectedIndex = 0;

			}
			else
			{
				this.uLabel_SectionCode.Visible = true;
				this.tEdit_SectionCode.Visible = true;
				this.tEdit_SectionName.Visible = true;
				this.SectionGuide_Button.Visible = true;
				this.ultraLabel3.Visible = true;
				this.sndFin_tComboEditor.Visible = true;
			}
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
            if (this._indexBuf == -2)
            {
                return;
            }
            // 送受信対象拠点の存在チェック
            this.ModeChangeProc(0);
        }
        // --- ADD 2009/05/21 ------------------------------<<<<<
        # endregion

        #region ◎ オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>				
		/// 企業設定に登録しない拠点チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
		private bool CheckSection(string sendSecCd)
		{
			// 企業設定に登録しない拠点を設定した場合
			EnterpriseSetAcs enterpriseSetAcs = new EnterpriseSetAcs();
			EnterpriseSet enterpriseSet = new EnterpriseSet();
			ArrayList enterpriseSetList = new ArrayList();
			enterpriseSetAcs.SearchAll(out enterpriseSetList, this._enterpriseCode);
			bool checkFlg = false;
			foreach (EnterpriseSet tmpEnterpriseSet in enterpriseSetList)
			{
				if (tmpEnterpriseSet.SectionCode.Trim().Equals(sendSecCd))
				{
					checkFlg = true;
				}
			}
			return checkFlg;
		}

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

    }
}