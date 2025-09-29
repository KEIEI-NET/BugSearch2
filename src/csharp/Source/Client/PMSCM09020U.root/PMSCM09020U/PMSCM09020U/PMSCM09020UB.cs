//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : PCC全体設定マスタ
// プログラム概要   : PCC全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/09/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修正日    2011/09/16  修正内容 : Redmine 25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更                            
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修正日    2012/04/20  修正内容 : 販売区分設定、販売区分コードの追加 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/31  修正内容 : 2012/10月配信予定 SCM障害№76の対応 
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;  
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text; 

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC全体設定マスタ表示設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC全体設定マスタ名称設定の設定を行います。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.09.13</br>
    /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
    /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
    /// </remarks>
	public partial class PMSCM09020UB : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Constructor --
		/// <summary>
        /// PCC全体設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: PCC全体設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// <br></br>
		/// </remarks>
        public PMSCM09020UB()
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
            this._scmTtlStAcs = new SCMTtlStAcs();
            this._totalCount = 0;
            this._scmTtlStTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点設定アクセスクラス
            this._secInfoAcs = new SecInfoAcs();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this._userGuideAcs = new UserGuideAcs();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // 端末管理情報キャッシュ
            this._scmTtlStAcs.CachePosTerminalMg(this._enterpriseCode);
        }
		#endregion

		#region -- Events --
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		private SCMTtlStAcs _scmTtlStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _scmTtlStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// 保存比較用Clone
		private SCMTtlSt _scmTtlStClone;
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09020U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";

        private const string VIEW_SALES_SLIP_PRT_DIV_TITLE = "売上伝票発行区分";
        private const string VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE = "受注伝票発行区分";
        private const string VIEW_ESTIMATE_PRT_DIV_TITLE = "見積書発行区分";
        //---DEL 2011/09/16 --------------------------->>>>>
        //private const string VIEW_OLD_SYS_COOPERAT_DIV_TITLE = "旧システム連携区分";
        //private const string VIEW_OLD_SYS_COOP_FOLDER_TITLE = "旧システム連携用フォルダ";
        //---DEL 2011/09/16 ---------------------------<<<<<
        private const string VIEW_BL_CODE_CHG_DIV_TITLE = "BLコード変換";
        private const string VIEW_AUTO_ANSWER_DIV = "自動回答区分";
        private const string VIEW_DISCOUNT_APPLY_CD_TITLE = "値引適用区分";
        private const string VIEW_AUTO_COOPERAT_DIS_TITLE = "自動連携値引";
        private const string VIEW_CASHREGISTERNO_TITLE = "受信処理起動端末番号";
        private const string VIEW_CASHREGISTERNONM_TITLE = "受信処理起動端末番号名称";
        private const string VIEW_RCVPROCSTINTERVAL_TITLE = "受信処理起動間隔";
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private const string VIEW_SALESCD_ST_AUTO_ANS_TITLE = "販売区分設定";
        private const string VIEW_SALES_CODE_TITLE = "販売区分";
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string VIEW_AUTO_ANSWER_PRICE_DIV = "自動回答時表示区分";
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        private const string VIEW_GUID_KEY_TITLE = "Guid";
		
		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";
        
		#endregion

		#region -- Main --
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMSCM09020UA());
		}
		# endregion

		#region -- Properties --
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
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

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		#endregion

		#region -- Public Methods --
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmTtlStTable.Clear();

            // 全検索
            status = this._scmTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (SCMTtlSt scmTtlSt in retList)
					{
                        // SCM全体設定情報クラスのデータセット展開処理
                        SCMTtlStToDataSet(scmTtlSt.Clone(), index);
						++index;
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}

				default:
				{
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        PROGRAM_ID,							    // アセンブリID
                        this.Text,              　　            // プログラム名称
						"Search",                               // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._scmTtlStAcs,					    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

					break;
				}
			}
			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // 実装なし
            return 9;
        }

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Delete()
		{
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // 全社共通データは削除不可
            if (scmTtlSt.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        PROGRAM_ID,							    // アセンブリID
                        "全社共通データは削除できません。",	    // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                return (0);
            }
            
            int status;

            // SCM全体設定情報の論理削除処理
            status = this._scmTtlStAcs.LogicalDelete(ref scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmTtlStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // SCM全体設定情報クラスのデータセット展開処理
            SCMTtlStToDataSet(scmTtlSt.Clone(), this.DataIndex);

            return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
        /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
        /// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // 売上伝票発行区分
            appearanceTable.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));
            // 受注伝票発行区分
            appearanceTable.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 見積書発行区分
            appearanceTable.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 --------------------------->>>>>
            //// 旧システム連携区分
            //appearanceTable.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// 旧システム連携用フォルダ
            //appearanceTable.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 ---------------------------<<<<<
            // BLコード変換
            appearanceTable.Add(VIEW_BL_CODE_CHG_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2010/05/21 Add >>>
            // 自動回答区分
            //appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動回答区分は、SCM自動回答オプションが契約されている場合のみ表示する
            PurchaseStatus psAutoAnswer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer);
            if (psAutoAnswer == PurchaseStatus.Contract || psAutoAnswer == PurchaseStatus.Trial_Contract)
            {
                appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            else
            {
                appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            // 2010/05/21 Add <<<

            // 値引適用区分
            appearanceTable.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動連携値引
            appearanceTable.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 受信処理起動端末番号
            appearanceTable.Add(VIEW_CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 受信処理起動端末番号
            appearanceTable.Add(VIEW_CASHREGISTERNONM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 受信処理起動間隔
            appearanceTable.Add(VIEW_RCVPROCSTINTERVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定
            appearanceTable.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 販売区分コード
            appearanceTable.Add(VIEW_SALES_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            appearanceTable.Add(VIEW_AUTO_ANSWER_PRICE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SCMTtlSt scmTtlSt = new SCMTtlSt();
                //クローン作成
                this._scmTtlStClone = scmTtlSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToSCMTtlSt(ref this._scmTtlStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

                // SCM全体設定クラス画面展開処理
                SCMTtlStToScreen(scmTtlSt);

                if (scmTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.tEdit_CashRegisterNo.Focus();

                    // クローン作成
                    this._scmTtlStClone = scmTtlSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSCMTtlSt(ref this._scmTtlStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;

                        this.tEdit_CashRegisterNo.Enabled = true;
                        this.tEdit_CashRegisterNoNm.Enabled = true;
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCdStAutoAns_tComboEditor.Enabled = true;
                        if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
                        {
                            this.SalesCode_tNedit.Enabled = false;
                            this.uButton_SalesCode.Enabled = false;
                        }
                        else
                        {
                            this.SalesCode_tNedit.Enabled = true;
                            this.uButton_SalesCode.Enabled = true;
                        }
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.tEdit_SectionCodeAllowZero.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 更新モード
                            this.tEdit_SectionCodeAllowZero.Enabled = false;
                            this.SectionGuide_Button.Enabled = false;
                        }
                        //ADD START BY wujun FOR Redmine#25181 ON 2011.09.15
                        this.tEdit_CashRegisterNo.Enabled = true;
                        this.tEdit_RcvProcStInterval.Enabled = true;
                        //ADD END BY wujun FOR Redmine#25181 ON 2011.09.15

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = true;
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.tEdit_CashRegisterNo.Enabled = false;
                        this.tEdit_CashRegisterNoNm.Enabled = false;
                        this.tEdit_RcvProcStInterval.Enabled = false;
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCode_tNedit.Enabled = false;
                        this.uButton_SalesCode.Enabled = false;
                        this.SalesCdStAutoAns_tComboEditor.Enabled = false;
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = false;
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        break;
                    }
            }
        }

		/// <summary>
		/// SCM全体設定オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : SCM全体設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
        /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
        /// </remarks>
		private void SCMTtlStToDataSet(SCMTtlSt scmTtlSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (scmTtlSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmTtlSt.UpdateDateTimeJpInFormal;
            }

			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmTtlSt.SectionCode;
            // 拠点名称
            string sectionName = GetSectionName(scmTtlSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // 売上伝票発行区分
            switch (scmTtlSt.SalesSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "する";
                    break;
            }

            // 受注伝票発行区分
            switch (scmTtlSt.AcpOdrrSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "する";
                    break;
            }

            // 見積書発行区分
            switch (scmTtlSt.EstimatePrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "する";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "しない";
                    break;
            }

            //---DEL 2011/09/16 --------------------------->>>>>
            //// 旧システム連携区分
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "しない(PM.NS)";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "する(PM7SP)";
            //        break;
            //}

            //// 旧システム連携用フォルダ
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = string.Empty;
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = scmTtlSt.OldSysCoopFolder;
            //        break;
            //}
            //---DEL 2011/09/16 ---------------------------<<<<<
            // BLコード変換
			switch(scmTtlSt.BLCodeChgDiv)
			{
				case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "する";
					break;
				case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "しない";
					break;
			}

            // 自動回答区分
            switch (scmTtlSt.AutoAnswerDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "しない";
                    break;
                case 1:
                   this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(委託在庫分のみ)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(在庫分のみ)";
                    break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(全て)";
                    break;
            }

            // 値引適用区分
			switch(scmTtlSt.DiscountApplyCd)
			{
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "しない";
                    break;
				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "全て";
					break;
				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "外装品除く";
					break;
				case 3:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "重点品目";
					break;
			}

            // 自動連携値引
            switch (scmTtlSt.DiscountApplyCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = string.Empty;
                    break;
                case 1:
                case 2:
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = scmTtlSt.AutoCooperatDis.ToString("#0.00");
                    break;
            }
            //受信処理起動端末番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO_TITLE] = scmTtlSt.CashRegisterNo;
            
            //受信処理起動端末番号名称
             PosTerminalMg posTerminalMg = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, scmTtlSt.CashRegisterNo);
             if (posTerminalMg != null)
             {
                 this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNONM_TITLE] = posTerminalMg.MachineName;
             }
            //受信処理起動間隔
             this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RCVPROCSTINTERVAL_TITLE] = scmTtlSt.RcvProcStInterval;
             //2012/04/20 ADD T.Nishi >>>>>>>>>>
             //販売区分設定(自動回答時)
             switch (scmTtlSt.SalesCdStAutoAns)
             {
                 case 0:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "しない";
                     //販売区分
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = "";
                     break;
                 case 1:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "する";
                     //販売区分
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = String.Format("{0:0000}", scmTtlSt.SalesCode);
                     break;
             }
             //2012/04/20 ADD T.Nishi <<<<<<<<<<

             // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
             //自動回答時表示区分
             switch (scmTtlSt.AutoAnsHourDspDiv)
             {
                 case 0:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "使用しない";
                     break;
                 case 1:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "PM設定に従う";
                     break;
                 case 2:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "優良";
                     break;
                 case 3:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "純正";
                     break;
                 case 4:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "高い方(1:N)";
                     break;
                 case 5:
                     this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "高い方(1:1)";
                     break;
             }
             // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmTtlSt.FileHeaderGuid;
			
			if (this._scmTtlStTable.ContainsKey(scmTtlSt.FileHeaderGuid) == true)
			{
				this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);
			}
			this._scmTtlStTable.Add(scmTtlSt.FileHeaderGuid, scmTtlSt);

		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
        /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable scmTtlStTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。

            scmTtlStTable.Columns.Add(DELETE_DATE, typeof(string));			                // 削除日
            
            scmTtlStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));             // 拠点コード
			scmTtlStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));             // 拠点名称

            scmTtlStTable.Columns.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, typeof(string));       // 売上伝票発行区分
            scmTtlStTable.Columns.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, typeof(string));    // 受注伝票発行区分
            scmTtlStTable.Columns.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, typeof(string));         // 見積書発行区分
            //---DEL 2011/09/16 --------------------------->>>>>
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, typeof(string));     // 旧システム連携区分
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, typeof(string));      // 旧システム連携用フォルダ
            //---DEL 2011/09/16 ---------------------------<<<<<
            scmTtlStTable.Columns.Add(VIEW_BL_CODE_CHG_DIV_TITLE, typeof(string));          // BLコード変換
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_DIV, typeof(string));                // 自動回答区分
            scmTtlStTable.Columns.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, typeof(string));        // 値引適用区分
            scmTtlStTable.Columns.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, typeof(string));        // 自動連携値引
            scmTtlStTable.Columns.Add(VIEW_CASHREGISTERNO_TITLE, typeof(int));        // 受信処理起動端末番号
            scmTtlStTable.Columns.Add(VIEW_CASHREGISTERNONM_TITLE, typeof(string));        // 受信処理起動端末番号
            scmTtlStTable.Columns.Add(VIEW_RCVPROCSTINTERVAL_TITLE, typeof(int));        // 受信処理起動間隔
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, typeof(string));        // 販売区分設定
            scmTtlStTable.Columns.Add(VIEW_SALES_CODE_TITLE, typeof(string));        // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_PRICE_DIV, typeof(string));          // 自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            scmTtlStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

			this.Bind_DataSet.Tables.Add(scmTtlStTable);
		}

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            //販売区分設定(自動回答時)
            SalesCdStAutoAns_tComboEditor.Items.Clear();
            SalesCdStAutoAns_tComboEditor.Items.Add(0, "しない");
            SalesCdStAutoAns_tComboEditor.Items.Add(1, "する");
            SalesCdStAutoAns_tComboEditor.MaxDropDownItems = SalesCdStAutoAns_tComboEditor.Items.Count;

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            AutoAnsHourDspDiv_tComboEditor.Items.Clear();
            AutoAnsHourDspDiv_tComboEditor.Items.Add(0, "使用しない");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(1, "PM設定に従う");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(2, "優良");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(3, "純正");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(4, "高い方(1:N)");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(5, "高い方(1:1)");
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        /// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.SectionName_tEdit.DataText = "";

            this.tEdit_CashRegisterNo.DataText = string.Empty;          // 受信処理起動端末番号
            this.tEdit_CashRegisterNoNm.DataText = string.Empty;        // 受信処理起動端末番号名称
            this.tEdit_RcvProcStInterval.DataText = string.Empty;       // 受信処理起動間隔
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = 0;          // 販売区分設定(自動回答時)
            this.SalesCode_tNedit.DataText = "";               // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = 0;     //自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
        /// SCM全体設定クラス画面展開処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : SCM全体設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void SCMTtlStToScreen(SCMTtlSt scmTtlSt)
		{
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = scmTtlSt.SectionCode;
            // 拠点名称
            string sectionName = string.Empty;
            if (scmTtlSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this.GetSectionName(scmTtlSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;
            
            // 受信処理起動端末番号
            if (scmTtlSt.CashRegisterNo != 0) this.tEdit_CashRegisterNo.DataText = scmTtlSt.CashRegisterNo.ToString();
            PosTerminalMg posTerminalMg = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, scmTtlSt.CashRegisterNo);
            if (posTerminalMg != null) this.tEdit_CashRegisterNoNm.Text = posTerminalMg.MachineName;

            // 受信処理起動間隔
            this.tEdit_RcvProcStInterval.DataText = scmTtlSt.RcvProcStInterval.ToString();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定(自動回答時)
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = scmTtlSt.SalesCdStAutoAns;

            // 販売区分コード
            this.SalesCode_tNedit.DataText = scmTtlSt.SalesCode.ToString();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnsHourDspDiv;
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
        /// 画面情報SCM全体設定クラス格納処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からSCM全体設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void ScreenToSCMTtlSt(ref SCMTtlSt scmTtlSt)
		{
			if (scmTtlSt == null)
			{
				// 新規の場合
                scmTtlSt = new SCMTtlSt();
			}

            //企業コード
            scmTtlSt.EnterpriseCode = this._enterpriseCode; 
            // 拠点コード
            scmTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;
            // 受信処理起動端末番号
            scmTtlSt.CashRegisterNo = TStrConv.StrToIntDef(this.tEdit_CashRegisterNo.DataText, 0);
            // 受信処理起動間隔
            scmTtlSt.RcvProcStInterval = TStrConv.StrToIntDef(this.tEdit_RcvProcStInterval.DataText, 0);
            //画面上に無い項目の設定
            // 売上伝票発行区分:しない
            scmTtlSt.SalesSlipPrtDiv = 0;

            // 受注伝票発行区分:しない
            scmTtlSt.AcpOdrrSlipPrtDiv = 0;

            // 見積書発行区分:しない
            scmTtlSt.EstimatePrtDiv = 1;

            // 旧システム連携区分:しない（PM.NS）
            scmTtlSt.OldSysCooperatDiv = 0;

            // 旧システム連携用フォルダ:空白
            scmTtlSt.OldSysCoopFolder = string.Empty;

            // BLコード変換:しない
            scmTtlSt.BLCodeChgDiv = 1;

            // 自動回答区分:する(全て)
            scmTtlSt.AutoAnswerDiv = 3;

            // 値引適用区分:しない
            scmTtlSt.DiscountApplyCd = 0;

            // 自動連携値引率:0
            scmTtlSt.AutoCooperatDis = 0;

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定(自動回答時)
            scmTtlSt.SalesCdStAutoAns = (int)this.SalesCdStAutoAns_tComboEditor.Value;
            // 販売区分コード
            scmTtlSt.SalesCode = this.SalesCode_tNedit.GetInt();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            scmTtlSt.AutoAnsHourDspDiv = (int)this.AutoAnsHourDspDiv_tComboEditor.Value;
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<


		}

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._scmTtlStClone = null;

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
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
		{
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	SCM全体設定画面入力チェック処理
		/// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM全体設定画面の入力チェックをします。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            bool result = true;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero;
                result = false;
            }

            //ADD START BY wujun FOR Redmine#25181 ON 2011.09.15
            // 受信処理起動端末番号
            if (string.IsNullOrEmpty(this.tEdit_CashRegisterNo.DataText.Trim()))
            {
                message = this.ultraLabel7.Text + "を設定して下さい。";
                control = this.tEdit_CashRegisterNo;
                result = false;
            }
            //ADD END BY wujun FOR Redmine#25181 ON 2011.09.15
            //ADD START BY wujun FOR Redmine#25181 ON 2011.09.20
            // 受信処理起動間隔
            else if (string.IsNullOrEmpty(this.tEdit_RcvProcStInterval.DataText.Trim()))
            {
                message = this.ultraLabel9.Text + "を設定して下さい。";
                control = this.tEdit_RcvProcStInterval;
                result = false;
            }
            //ADD END BY wujun FOR Redmine#25181 ON 2011.09.20

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //販売区分設定(自動回答時)
            if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
            {
                //販売区分コード
                if (this.SalesCode_tNedit.GetValue() == 0)
                {
                    message = this.ultraLabel13.Text + "を設定して下さい。";
                    control = this.SalesCode_tNedit;
                    result = false;
                }
            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            return result;
		}
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        #region 販売区分

        /// <summary>
        /// 販売区分ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2012/04/20 西 毅</br>
        /// <br>              抽出条件を入力後の表示はコード＋名称で表示する。</br>
        private void uButton_SalesCode_Click(object sender, EventArgs e)
        {
            int userGuideDivCd_SalesCode = 71;  // 販売区分：71

            // コードから名称へ変換
            UserGdHd userGuideHdInfo;
            UserGdBd userGuideBdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (userGuideBdInfo.GuideCode != 0)
                {
                    this.SalesCode_tNedit.DataText = String.Format("{0:0000}", userGuideBdInfo.GuideCode);
                }
                //最新情報にフォーカスセット
                Renewal_Button.Focus();

            }
        }

        #endregion // 販売区分

        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		/// <summary>
        ///　保存処理(SaveProc())
		/// </summary>
		/// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
			//画面データ入力チェック処理
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }
	
			SCMTtlSt scmTtlSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();
			}

            // 画面情報を取得
			ScreenToSCMTtlSt(ref scmTtlSt);
            // 登録・更新処理
			int status = this._scmTtlStAcs.Write(ref scmTtlSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
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
                    // 排他処理
                    ExclusiveTransaction(status, true);					
					
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
                        PROGRAM_ID,							    // アセンブリID
						this.Text,  　　                        // プログラム名称
                        "SaveProc",                             // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._scmTtlStAcs,				    	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,			  		// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // SCM全体設定情報クラスのデータセット展開処理
			SCMTtlStToDataSet(scmTtlSt, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			result = true;
			return result;
		}


        /// <summary>
        ///　競合中メッセージ表示
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 該当コードが使用されている場合にメッセージを表示します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています" ,// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(190, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称 ※存在しない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社共通";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <param name="sectionCd">拠点コード</param>
        /// <remarks>
        /// <br>Note		: モード変更処理</br>
        /// <br>Programmer	: 黄海霞</br>
        /// <br>Date		: 2011.09.13</br>
        /// </remarks>  
        private bool ModeChangeProc()
        {
            string msg = "入力されたコードのSCM全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのSCM全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
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
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load イベント(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void PMSCM09020UB_Load(object sender, System.EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

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

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.uButton_SalesCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //2012/04/20 ADD T.Nishi <<<<<<<<<<
            
            // コントロールサイズ設定
            SetControlSize();

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 画面初期設定処理
            ScreenInitialSetting();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

		}

		/// <summary>
        ///	Form.Closing イベント(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void PMSCM09020UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

		/// <summary>
        ///	Form.VisibleChanged イベント(PMSCM09020UB)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09020UB_VisibleChanged(object sender, System.EventArgs e)
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
			
            // 画面クリア
			ScreenClear();

            Timer.Enabled = true;
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
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // 登録・更新処理
			if (!SaveProc())
			{
				return;
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SCMTtlSt compareSCMTtlSt = new SCMTtlSt();

                compareSCMTtlSt = this._scmTtlStClone.Clone();
                ScreenToSCMTtlSt(ref compareSCMTtlSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._scmTtlStClone.Equals(compareSCMTtlSt))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PROGRAM_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
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
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero.Focus();
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

		/// <summary>
		/// Timer.Tick イベント(timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

            // 画面表示処理
			ScreenReconstruction();
		}

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
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
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.tEdit_CashRegisterNo.Focus();

                    // 新規モードからモード変更対応
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
                else if (status == 1)
                {
                    // [戻る]の場合
                    if (ModeChangeProc())
                    {
                        SectionGuide_Button.Focus();
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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // 完全削除処理
            int status = this._scmTtlStAcs.Delete(scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // 完全削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmTtlStAcs, 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();

            // 復活処理
            status = this._scmTtlStAcs.Revival(ref scmTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM全体設定情報クラスのデータセット展開処理
                        SCMTtlStToDataSet(scmTtlSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._scmTtlStAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        ///  <br>Note　　　 : ChangeFocus イベント発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // 拠点名称取得
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero.Clear();
                    this.SectionName_tEdit.Clear();
                    //e.NextCtrl = SectionGuide_Button;
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    e.NextCtrl.Select();
                    return;
                }
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.tEdit_CashRegisterNo;
                        }
                    }
                }

                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tEdit_SectionCodeAllowZero
                            &&
                        e.NextCtrl == this.SectionGuide_Button
                            &&
                        string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim())
                    )
                    {
                        // 何もしない ∵新規モードで起動直後に拠点のガイドボタンをクリックした場合に相当
                    }
                    else
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            // 受信処理起動端末
            else if (e.PrevCtrl == tEdit_CashRegisterNo)
            {
                int cashRegisterno = TStrConv.StrToIntDef(tEdit_CashRegisterNo.DataText, 0);
                if (cashRegisterno != 0)
                {
                    PosTerminalMg pos = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, cashRegisterno);
                    if (pos == null)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "該当する端末番号が存在しません",
                            -1,
                            MessageBoxButtons.OK
                        );
                        this.tEdit_CashRegisterNo.Clear();
                        this.tEdit_CashRegisterNoNm.Clear();
                        e.NextCtrl = this.tEdit_CashRegisterNo;
                        e.NextCtrl.Select();
                        return;
                    }
                    else
                    {
                        this.tEdit_CashRegisterNoNm.DataText = pos.MachineName;
                    }
                }
                else
                {
                    this.tEdit_CashRegisterNo.Clear();
                    this.tEdit_CashRegisterNoNm.Clear();
                }
            }
            // 受信処理起動間隔
            else if (e.PrevCtrl == tEdit_RcvProcStInterval)
            {
                int rcvProcStInterval = TStrConv.StrToIntDef(tEdit_RcvProcStInterval.DataText, 0);
                if (rcvProcStInterval < 1)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "1分以上で設定して下さい",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_RcvProcStInterval.Clear();
                    e.NextCtrl = this.tEdit_RcvProcStInterval;
                    e.NextCtrl.Select();
                    return;
                }
            }

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            else if (e.PrevCtrl == SalesCode_tNedit)
            {
                //販売区分設定(自動回答時)
                if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
                {
                    //販売区分コード
                    if (this.SalesCode_tNedit.GetValue() != 0)
                    {
                        //マスタ存在チェック
                        int SalesCode = this.SalesCode_tNedit.GetInt();
                        UserGdBd userGdBd = null;
                        UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                        int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 71, SalesCode, ref acsDataType);

                        if (userGdBd == null || status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || userGdBd.LogicalDeleteCode != 0)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                this.ultraLabel13.Text + "[" + SalesCode + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK
                            );
                            this.SalesCode_tNedit.Clear();
                            e.NextCtrl = this.SalesCode_tNedit;
                            e.NextCtrl.Select();
                            return;
                        }
                    }
                }

            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        /// <remarks>
        ///  <br>Note　　　: 最新情報ボタンクリック発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.09.13</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
      
		#endregion

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private void SalesCdStAutoAns_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
            {
                // 販売区分設定をしない
                SalesCode_tNedit.DataText = "";
                SalesCode_tNedit.Enabled = false;
                uButton_SalesCode.Enabled = false;
            }
            else
            {
                // 販売区分設定が上記以外
                SalesCode_tNedit.Enabled = true;
                uButton_SalesCode.Enabled = true;
            }
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<


	}
}
