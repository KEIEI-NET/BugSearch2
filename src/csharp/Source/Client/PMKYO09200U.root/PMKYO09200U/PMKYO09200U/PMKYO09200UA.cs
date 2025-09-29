//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信対象設定マスタメンテナンス
// プログラム概要   : 送受信対象設定の変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/25  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/25  修正内容 : Redmine #23998 在庫移動データの受信区分変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/20  修正内容 : Redmine #25368 「送受信対象設定」の更新項目の制御について
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 送受信対象設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 送受信対象設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
	/// <br>Programmer	: 張凱</br>
	/// <br>Date		: 2009.04.22</br>
	/// <br>Update Note : 張莉莉 2011.07.25</br>
	/// <br>            : SCM対応‐拠点管理（10704767-00）</br>
    /// <br>Update Note : 2020/09/25 陳艶丹</br>
    /// <br>管理番号    : 11600006-00</br>
    /// <br>            : PMKOBETSU-3877の対応</br>
	/// <br></br>
	/// </remarks>
	public partial class PMKYO09200UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{

		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 送受信対象設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 送受信対象設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public PMKYO09200UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = false;
			this._canDelete = false;
			this._canClose = true;
			this._defaultAutoFillToColumn = false;
			this._canSpecificationSearch = false;
			this._canLogicalDeleteDataExtraction = false;

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
			this._sendSetAcs = new SendSetAcs();
			this._totalCount = 0;
			this._sendSetTable = new Hashtable();
			_secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();
			_secMngSndRcvList = new List<SecMngSndRcv>();
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			_newSndRcvList = new List<SecMngSndRcv>();
			_newSndRcvDtlList = new List<SecMngSndRcvDtl>();
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

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
		private SendSetAcs _sendSetAcs;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _sendSetTable;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 保存比較用Clone
		private SecMngSndRcv _sendSetClone;

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

		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
		private const string VIEW_NAME_TITLE = "データ・マスタ名称";
		private const string VIEW_SEND_TITLE = "送信区分";
		private const string VIEW_RECEIVED_TITLE = "受信区分";
		private const string VIEW_SORTS_TITLE = "表示順位";
		private const string VIEW_FILEID_TITLE = "ファイルＩＤ";
		private const string VIEW_FILENM_TITLE = "ファイル名称";
		private const string VIEW_USERGUIDEDIVCD_TITLE = "ユーザーガイド区分";
		private const string VIEW_GUID_KEY_TITLE = "Guid";
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
        private const string VIEW_ACPTANODSEND_TITLE = "受注データ送信区分";
        private const string VIEW_ACPTANODRECEIVED_TITLE = "受注データ受信区分";
        private const string VIEW_SHIPMENTSEND_TITLE = "貸出データ送信区分";
        private const string VIEW_SHIPMENTRECEIVED_TITLE = "貸出データ受信区分";
        private const string VIEW_ESTIMATESEND_TITLE = "見積データ送信区分";
        private const string VIEW_ESTIMATERECEIVED_TITLE = "見積データ受信区分";
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

		//子画面用Grid列のKEY情報
		private const string COLUMN_FILEID = "FileId";
		private const string COLUMN_FILENM = "FileNm";
		private const string COLUMN_ITEMID = "ItemId";
		private const string COLUMN_ITEMNAME = "ItemName";
		private const string COLUMN_UPDATECD = "UpdateCd";
		//送受信対象詳細マスタ
		List<SecMngSndRcvDtl> _secMngSndRcvDtlList;
		//送受信対象マスタ
		List<SecMngSndRcv> _secMngSndRcvList;

		// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// _callForm
		/// </summary>
		public bool _callForm = false;
		/// <summary>
		/// _callPara
		/// </summary>
		public int _callPara = 0;
		private List<SecMngSndRcvDtl> _newSndRcvDtlList;
		private List<SecMngSndRcv> _newSndRcvList;
		// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
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
				return -1;
			}

			int status = 0;

			List<SecMngSndRcv> sentSets = null;
			List<SecMngSndRcvDtl> sentDtlSets = null;
			List<SecMngSndRcv> _sentSets = new List<SecMngSndRcv>();

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
			this._sendSetTable.Clear();

			status = this._sendSetAcs.SearchAll(out sentSets, out sentDtlSets, this._enterpriseCode);
			this._totalCount = sentSets.Count;

			switch (status)
			{
				case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
					{
						int index = 0;

						_sentSets = GetDisplayList(sentSets);

						foreach (SecMngSndRcv sentSet in _sentSets)
						{
							SendSetToDataSet(sentSet.Clone(), index);
							++index;
						}

						_secMngSndRcvList = sentSets;
						_secMngSndRcvDtlList = sentDtlSets;

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
							"PMKYO09200U",							// アセンブリID
							"送受信対象設定",              　　     // プログラム名称
							"Search",                               // 処理名称
							TMsgDisp.OPE_GET,                       // オペレーション
							"読み込みに失敗しました。",				// 表示するメッセージ
							status,									// ステータス値
							this._sendSetAcs,					    // エラーが発生したオブジェクト
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public int Delete()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 印刷処理を実行します。(未実装)</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();
			appearanceTable.Add(VIEW_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SEND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_RECEIVED_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SORTS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_FILEID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_FILENM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_USERGUIDEDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            appearanceTable.Add(VIEW_ACPTANODSEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ACPTANODRECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SHIPMENTSEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SHIPMENTRECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ESTIMATESEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ESTIMATERECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面の再構築を行います。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			if (_callForm && (_callPara != 0))
			{
				List<SecMngSndRcvDtl> allSndRcvDtlList = new List<SecMngSndRcvDtl>();
				List<SecMngSndRcv> allSndRcvList = new List<SecMngSndRcv>();
				int status = _sendSetAcs.SearchAll(out allSndRcvList, out allSndRcvDtlList, this._enterpriseCode);

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					if (allSndRcvList != null && allSndRcvList.Count > 0)
					{
						//送受信対象
						foreach (SecMngSndRcv myresult in allSndRcvList)
						{
							if (myresult.DisplayOrder == _callPara)
							{
								_newSndRcvList.Add(myresult);
							}
						}
					}
					if (allSndRcvDtlList != null && allSndRcvDtlList.Count > 0)
					{
						//送受信対象詳細
						foreach (SecMngSndRcv sndRcv in _newSndRcvList)
						{
							foreach (SecMngSndRcvDtl result in allSndRcvDtlList)
							{
								if (result.FileId.Equals(sndRcv.FileId))
								{
									_newSndRcvDtlList.Add(result);
								}
							}
						}
					}
					if (_newSndRcvList != null && _newSndRcvList.Count > 0)
					{
						// ファイル名称
						this.FileName_tEdit.Text = _newSndRcvList[0].MasterName;

						//送信区分
						this.SendCode_uOption.Value = (object)_newSndRcvList[0].SecMngSendDiv;

						//受信区分
						ReceivedCode_tComEditorInit(_newSndRcvList[0].DisplayOrder);

						this.ReceivedCode_tComEditor.Value = (object)_newSndRcvList[0].SecMngRecvDiv;

                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                        //受注データ送信区分
                        this.AcptAnOdrSend_tComEditor.Value = (object)_newSndRcvList[0].AcptAnOdrSendDiv;
                        //受注データ受信区分
                        this.AcptAnOdrReceived_tComEditor.Value = (object) _newSndRcvList[0].AcptAnOdrRecvDiv;
                        //貸出データ送信区分
                        this.ShipmentSend_tComEditor.Value = (object)_newSndRcvList[0].ShipmentSendDiv;
                        //貸出データ受信区分
                        this.ShipmentReceived_tComEditor.Value = (object)_newSndRcvList[0].ShipmentRecvDiv;
                        //見積データ送信区分
                        this.EstimateSend_tComEditor.Value = (object)_newSndRcvList[0].EstimateSendDiv;
                        //見積データ受信区分
                        this.EstimateReceived_tComEditor.Value = (object)_newSndRcvList[0].EstimateRecvDiv;
                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
					}

					this.uGrid_Details.BeginUpdate();

					// グリッド初期化
					CreateGrid();

					_newSndRcvDtlList.Sort(delegate(SecMngSndRcvDtl x, SecMngSndRcvDtl y) { return x.DisplayOrder - y.DisplayOrder; });

					// 新規行作成
					CreateNewRow(ref this.uGrid_Details, _newSndRcvDtlList);

					SetGridNoEdit();

					this.uGrid_Details.EndUpdate();

					if (this.uGrid_Details.Rows.Count == 0)
					{
						this.uGrid_Details.ActiveRow = null;
					}
					else
					{
						this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
					}
				}

			}
			else
			{
				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
				if (this.DataIndex < 0)
				{
					SecMngSndRcv sendSet = new SecMngSndRcv();
					//クローン作成
					this._sendSetClone = sendSet.Clone();

					this._indexBuf = this._dataIndex;

					// 画面情報を比較用クローンにコピーします
					ScreenToSendSet(ref this._sendSetClone);

				}
				else
				{
					// 保持しているデータセットより修正前情報取得
					Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
					SecMngSndRcv sendSet = (SecMngSndRcv)this._sendSetTable[guid];

					// データ入力画面展開処理
					SendSetToScreen(sendSet);

					// フォーカス設定
					int focusindex = sendSet.SecMngSendDiv;
					if (focusindex == 0)
					{
						this.SendCode_uOption.FocusedIndex = 0;
					}
					else
					{
						this.SendCode_uOption.FocusedIndex = 1;
					}


					// クローン作成
					this._sendSetClone = sendSet.Clone();

					// 画面情報を比較用クローンにコピーします　   
					ScreenToSendSet(ref this._sendSetClone);

					this._indexBuf = this._dataIndex;
				}
			}
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            // ファイル名称
            if (!this.FileName_tEdit.Text.Equals("売上データ"))
            {
                this.panel1.Visible = false;
                this.uGrid_Details.Location = new Point(46, 130);
                this.uGrid_Details.Size = new Size(457, 334);
                // 受注データ送信区分
                this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                // 貸出データ送信区分
                this.ShipmentSend_tComEditor.SelectedIndex = 0;
                // 見積データ送信区分
                this.EstimateSend_tComEditor.SelectedIndex = 0;
                // 受注データ受信区分
                this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                // 貸出データ受信区分
                this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                // 見積データ受信区分
                this.EstimateReceived_tComEditor.SelectedIndex = 0;
            }
            else
            {
                this.panel1.Visible = true;
                this.uGrid_Details.Location = new Point(46, 315);
                this.uGrid_Details.Size = new Size(457, 149);
                // 送信区分
                if (Convert.ToInt32(this.SendCode_uOption.Value.ToString()) == 0)
                {
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.Enabled = false;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.Enabled = false;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.Enabled = false;
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.SelectedIndex = 0;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.Enabled = true;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.Enabled = true;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.Enabled = true;
                }

                // 受信区分
                if (this.ReceivedCode_tComEditor.SelectedIndex == 0)
                {
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.Enabled = false;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.Enabled = false;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.Enabled = false;
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.Enabled = true;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.Enabled = true;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.Enabled = true;
                }
            }
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面情報送受信対象設定クラス格納処理
		/// </summary>
		/// <param name="sendSet">送受信対象設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から送受信対象設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private void ScreenToSendSet(ref SecMngSndRcv sendSet)
		{
			if (sendSet == null)
			{
				// 新規の場合
				sendSet = new SecMngSndRcv();
			}

			//企業コード
			sendSet.EnterpriseCode = this._enterpriseCode;
			// 送信区分
			sendSet.SecMngSendDiv = Convert.ToInt32(this.SendCode_uOption.Value.ToString());
			//受信区分
			sendSet.SecMngRecvDiv = Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString());
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ送信区分
            sendSet.AcptAnOdrSendDiv = Convert.ToInt32(this.AcptAnOdrSend_tComEditor.Value.ToString());
            //受注データ受信区分
            sendSet.AcptAnOdrRecvDiv = Convert.ToInt32(this.AcptAnOdrReceived_tComEditor.Value.ToString());
            //貸出データ送信区分
            sendSet.ShipmentSendDiv = Convert.ToInt32(this.ShipmentSend_tComEditor.Value.ToString());
            //貸出データ受信区分
            sendSet.ShipmentRecvDiv = Convert.ToInt32(this.ShipmentReceived_tComEditor.Value.ToString());
            //見積データ送信区分
            sendSet.EstimateSendDiv = Convert.ToInt32(this.EstimateSend_tComEditor.Value.ToString());
            //見積データ受信区分
            sendSet.EstimateRecvDiv = Convert.ToInt32(this.EstimateReceived_tComEditor.Value.ToString());
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 保存情報送受信対象設定クラス格納処理
		/// </summary>
		/// <param name="secMngSndRcv">送受信対象設定オブジェクト</param>
		/// <param name="secMngSndRcvDtlList"></param>
		/// <param name="secMngSndRcvList"></param>
		/// <remarks>
		/// <br>Note       : 保存情報から送受信対象設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
		/// </remarks>
		private void SaveToSetList(SecMngSndRcv secMngSndRcv, ref List<SecMngSndRcv> secMngSndRcvList, ref List<SecMngSndRcvDtl> secMngSndRcvDtlList)
		{
			//送受信対象マスタ
			secMngSndRcvList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
			{
				if (secMngSndRcv.DisplayOrder == target.DisplayOrder)
				{
					return (true);
				}
				else
				{
					return (false);
				}
			});

			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				_secMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
				_secMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
			}

			//送受信対象詳細マスタ
			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
				{
					if (_secMngSndRcv.FileId.Equals(target.FileId))
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				foreach (SecMngSndRcvDtl result in resultDtlList)
				{
					secMngSndRcvDtlList.Add(result);
				}
			}

			for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
			{
				string fileId = this.uGrid_Details.Rows[index].Cells[COLUMN_FILEID].Value.ToString().Trim();
				string itemId = this.uGrid_Details.Rows[index].Cells[COLUMN_ITEMID].Value.ToString().Trim();

				foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
				{
					if (fileId.Equals(secMngSndRcvDtl.FileId) && itemId.Equals(secMngSndRcvDtl.ItemId))
					{
						secMngSndRcvDtl.DataUpdateDiv = (int)this.uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
					}
				}
			}

		}


		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable allDefSetTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。
			allDefSetTable.Columns.Add(VIEW_NAME_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SEND_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_RECEIVED_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SORTS_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_FILEID_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_FILENM_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_USERGUIDEDIVCD_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            allDefSetTable.Columns.Add(VIEW_ACPTANODSEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ACPTANODRECEIVED_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SHIPMENTSEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SHIPMENTRECEIVED_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ESTIMATESEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ESTIMATERECEIVED_TITLE, typeof(string));
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
			this.Bind_DataSet.Tables.Add(allDefSetTable);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void ScreenClear()
		{
			// グリッド初期化
			CreateGrid();
			SetGridLayout();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		private void ReceivedCode_tComEditorInit(int displayOrder)
		{
			this.ReceivedCode_tComEditor.Items.Clear();

			if ((0 <= displayOrder) && (99 >= displayOrder))
			{
				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				// 売上系、仕入系、在庫仕入系
				if ((1 == displayOrder) || (3 == displayOrder) || (21 == displayOrder) || (2 == displayOrder)
					|| (10 == displayOrder) || (11 == displayOrder) || (17 == displayOrder) || (18 == displayOrder)
					|| (19 == displayOrder)) //在庫移動データ // ADD 2011.08.25
				{
					// なし
					Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
					listItem0.DataValue = "0";
					listItem0.DisplayText = "なし";

					// あり（在庫更新なし）
					Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
					listItem1.DataValue = "1";
					listItem1.DisplayText = "あり（在庫更新なし）";

					// あり（在庫更新あり）
					Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
					listItem2.DataValue = "2";
					listItem2.DisplayText = "あり（在庫更新あり）";

					this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });
				}
				else
				{
                // ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

					// なし
					Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
					listItem0.DataValue = "0";
					listItem0.DisplayText = "なし";

					// あり
					Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
					listItem1.DataValue = "1";
					listItem1.DisplayText = "あり";

					this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1 });
				}
			}
			else if (100 <= displayOrder)
			{
				// なし
				Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
				listItem2.DataValue = "0";
				listItem2.DisplayText = "なし";

				// あり（追加のみ）
				Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
				listItem3.DataValue = "1";
				listItem3.DisplayText = "あり（追加のみ）";

				// あり（追加・更新）
				Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
				listItem4.DataValue = "2";
				listItem4.DisplayText = "あり（追加・更新）";

				// あり
				Infragistics.Win.ValueListItem listItem5 = new Infragistics.Win.ValueListItem();
				listItem5.DataValue = "3";
				listItem5.DisplayText = "あり（更新のみ）";

				this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem2, listItem3, listItem4, listItem5 });

			}
			else
			{
				//なし
			}

		}

		/// <summary>
		/// グリッド作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドを作成します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void CreateGrid()
		{
			DataTable dataTable = new DataTable();

			// ファイルＩＤ
			dataTable.Columns.Add(COLUMN_FILEID, typeof(string));
			// ファイル名称
			dataTable.Columns.Add(COLUMN_FILENM, typeof(string));
			// 項目ＩＤ
			dataTable.Columns.Add(COLUMN_ITEMID, typeof(string));
			//項目名称 
			dataTable.Columns.Add(COLUMN_ITEMNAME, typeof(string));
			//更新区分
			dataTable.Columns.Add(COLUMN_UPDATECD, typeof(int));

			this.uGrid_Details.DataSource = dataTable;

			this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
		}

		/// <summary>
		/// 新規行作成処理
		/// </summary>
		/// <param name="uGrid">グリッド</param>
		/// <param name="secMngSndRcvDtlList"></param>
		/// <remarks>
		/// <br>Note       : グリッドに行を追加します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void CreateNewRow(ref UltraGrid uGrid, List<SecMngSndRcvDtl> secMngSndRcvDtlList)
		{

			foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
			{
				// 行追加
				uGrid.DisplayLayout.Bands[0].AddNew();

				//項目ＩＤ
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMID].Value = secMngSndRcvDtl.ItemId;

				//項目名称
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMNAME].Value = secMngSndRcvDtl.ItemName;

				//ファイルＩＤ
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILEID].Value = secMngSndRcvDtl.FileId;

				//マスタ名称
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILENM].Value = secMngSndRcvDtl.FileNm;

				//更新区分
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_UPDATECD].Value = secMngSndRcvDtl.DataUpdateDiv;

			}
		}

		/// <summary>
		/// グリッドレの制御設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       :グリッドレの制御設定します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void SetGridNoEdit()
		{
			int index = (int)this.ReceivedCode_tComEditor.SelectedIndex;

			if (this.uGrid_Details.Rows.Count == 0)
			{
				return;
			}

			//「受信なし」及び「受信あり（追加のみ）」の場合
			if (index == 0 || index == 1)
			{
				foreach (UltraGridRow row in this.uGrid_Details.Rows)
				{
					row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

					// ADD 2011/09/20 for #25368 ---------- >>>>>
					if (index == 1
						&& row.Cells[COLUMN_FILEID].Text.Equals("StockRF")
						&& row.Cells[COLUMN_ITEMID].Text.Equals("SupplierStockRF"))
					{
						row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
					}
					// ADD 2011/09/20 for #25368 ---------- <<<<<
				}
			}
			else
			{
				foreach (UltraGridRow row in this.uGrid_Details.Rows)
				{
					row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				}
			}
		}

		/// <summary>
		/// グリッドレイアウト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドレイアウトを設定します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void SetGridLayout()
		{
			ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;


			//--------------------------------------
			// 入力不可
			//--------------------------------------
			columns[COLUMN_FILEID].CellActivation = Activation.NoEdit;
			columns[COLUMN_FILENM].CellActivation = Activation.NoEdit;
			columns[COLUMN_ITEMID].CellActivation = Activation.NoEdit;
			columns[COLUMN_ITEMNAME].CellActivation = Activation.NoEdit;

			//--------------------------------------
			// 列固定
			//--------------------------------------
			//columns[COLUMN_FILENM].Header.Fixed = true;
			//columns[COLUMN_ITEMNAME].Header.Fixed = true;
			//columns[COLUMN_UPDATECD].Header.Fixed = true;

			//--------------------------------------
			// キャプション
			//--------------------------------------
			columns[COLUMN_FILEID].Header.Caption = "ファイルＩＤ";
			columns[COLUMN_FILENM].Header.Caption = "ファイル名称";
			columns[COLUMN_ITEMID].Header.Caption = "項目ＩＤ";
			columns[COLUMN_ITEMNAME].Header.Caption = "項目名称";
			columns[COLUMN_UPDATECD].Header.Caption = "更新区分";

			//--------------------------------------
			// 列幅
			//--------------------------------------
			columns[COLUMN_FILEID].Width = 50;
			columns[COLUMN_FILENM].Width = 174;
			columns[COLUMN_ITEMID].Width = 50;
			columns[COLUMN_ITEMNAME].Width = 160;
			columns[COLUMN_UPDATECD].Width = 92;

			//--------------------------------------
			// 非表示
			//--------------------------------------
			columns[COLUMN_FILEID].Hidden = true;
			columns[COLUMN_ITEMID].Hidden = true;

			//--------------------------------------
			// テキスト位置(VAlign)
			//--------------------------------------
			for (int index = 0; index < columns.Count; index++)
			{
				columns[index].CellAppearance.TextVAlign = VAlign.Middle;
			}

			//--------------------------------------
			// コンボボックス設定
			//--------------------------------------
			ValueList valueList = new ValueList();
			valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			valueList.ValueListItems.Clear();
			valueList.ValueListItems.Add(0, "する");
			valueList.ValueListItems.Add(1, "しない");
			columns[COLUMN_UPDATECD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			columns[COLUMN_UPDATECD].ValueList = valueList.Clone();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 送受信対象詳細設定クラス画面展開処理
		/// </summary>
		/// <param name="sendSet">送受信対象詳細設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 送受信対象詳細設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private void SendSetToScreen(SecMngSndRcv sendSet)
		{
			if (sendSet != null)
			{
				// ファイル名称
				this.FileName_tEdit.Text = sendSet.MasterName;

				//送信区分
				this.SendCode_uOption.Value = (object)sendSet.SecMngSendDiv;

				//受信区分
				ReceivedCode_tComEditorInit(sendSet.DisplayOrder);

				this.ReceivedCode_tComEditor.Value = (object)sendSet.SecMngRecvDiv;

                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                //受注データ送信区分
                this.AcptAnOdrSend_tComEditor.Value = (object)sendSet.AcptAnOdrSendDiv;
                //受注データ受信区分
                this.AcptAnOdrReceived_tComEditor.Value = (object)sendSet.AcptAnOdrRecvDiv;
                //貸出データ送信区分
                this.ShipmentSend_tComEditor.Value = (object)sendSet.ShipmentSendDiv;
                //貸出データ受信区分
                this.ShipmentReceived_tComEditor.Value = (object)sendSet.ShipmentRecvDiv;
                //見積データ送信区分
                this.EstimateSend_tComEditor.Value = (object)sendSet.EstimateSendDiv;
                //見積データ受信区分
                this.EstimateReceived_tComEditor.Value = (object)sendSet.EstimateRecvDiv;
                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

				//送受信対象
				List<SecMngSndRcv> resultList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
				{
					if (sendSet.DisplayOrder == target.DisplayOrder)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				List<SecMngSndRcvDtl> resultDtlDisPlayList = new List<SecMngSndRcvDtl>();
				//送受信対象詳細
				foreach (SecMngSndRcv secMngSndRcv in resultList)
				{
					List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
					{
						if (secMngSndRcv.FileId.Equals(target.FileId))
						{
							return (true);
						}
						else
						{
							return (false);
						}
					});

					foreach (SecMngSndRcvDtl result in resultDtlList)
					{
						resultDtlDisPlayList.Add(result);
					}
				}

				this.uGrid_Details.BeginUpdate();

				// グリッド初期化
				CreateGrid();

				resultDtlDisPlayList.Sort(delegate(SecMngSndRcvDtl x, SecMngSndRcvDtl y) { return x.DisplayOrder - y.DisplayOrder; });

				// 新規行作成
				CreateNewRow(ref this.uGrid_Details, resultDtlDisPlayList);

				SetGridNoEdit();

				this.uGrid_Details.EndUpdate();

				if (this.uGrid_Details.Rows.Count == 0)
				{
					this.uGrid_Details.ActiveRow = null;
				}
				else
				{
					this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
				}

			}

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///　保存処理(SaveSendSet())
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 保存処理を行います。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private bool SaveSendSet()
		{
			bool result = false;
			Control control = null;
			int status;

			SecMngSndRcv secMngSndRcv = null;
			List<SecMngSndRcv> secMngSndRcvList = new List<SecMngSndRcv>();
			List<SecMngSndRcvDtl> secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();

			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			if (_callForm && _callPara != 0 && _newSndRcvList.Count > 0)
			{
				for (int cnt = 0; cnt < _newSndRcvList.Count; cnt++)
				{
					//企業コード
					_newSndRcvList[cnt].EnterpriseCode = this._enterpriseCode;
					// 送信区分
					_newSndRcvList[cnt].SecMngSendDiv = Convert.ToInt32(this.SendCode_uOption.Value.ToString());
					//受信区分
					_newSndRcvList[cnt].SecMngRecvDiv = Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString());
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                    //受注データ送信区分
                    _newSndRcvList[cnt].AcptAnOdrSendDiv = Convert.ToInt32(this.AcptAnOdrSend_tComEditor.Value.ToString());
                    //受注データ受信区分
                    _newSndRcvList[cnt].AcptAnOdrRecvDiv = Convert.ToInt32(this.AcptAnOdrReceived_tComEditor.Value.ToString());
                    //貸出データ送信区分
                    _newSndRcvList[cnt].ShipmentSendDiv = Convert.ToInt32(this.ShipmentSend_tComEditor.Value.ToString());
                    //貸出データ受信区分
                    _newSndRcvList[cnt].ShipmentRecvDiv = Convert.ToInt32(this.ShipmentReceived_tComEditor.Value.ToString());
                    //見積データ送信区分
                    _newSndRcvList[cnt].EstimateSendDiv = Convert.ToInt32(this.EstimateSend_tComEditor.Value.ToString());
                    //見積データ受信区分
                    _newSndRcvList[cnt].EstimateRecvDiv = Convert.ToInt32(this.EstimateReceived_tComEditor.Value.ToString());
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
				}

				for (int cnt = 0; cnt < this.uGrid_Details.Rows.Count; cnt++)
				{
					_newSndRcvDtlList[cnt].DataUpdateDiv = (int)this.uGrid_Details.Rows[cnt].Cells[COLUMN_UPDATECD].Value;
				}

				status = this._sendSetAcs.Write(ref _newSndRcvList, ref _newSndRcvDtlList);
			}
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
			else
			{
				if (this.DataIndex >= 0)
				{
					Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
					secMngSndRcv = ((SecMngSndRcv)this._sendSetTable[guid]).Clone();
				}

				ScreenToSendSet(ref secMngSndRcv);

				//SaveToSetList(secMngSndRcv, ref secMngSndRcvList, ref secMngSndRcvDtlList);// DEL 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）

				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				if (secMngSndRcv != null)
				{
					int displayOd = secMngSndRcv.DisplayOrder;
					if ((1 == displayOd) || (3 == displayOd) || (21 == displayOd) || (2 == displayOd)
					|| (10 == displayOd) || (11 == displayOd) || (17 == displayOd) || (18 == displayOd))
					{
						string msg = string.Empty;

						if ((1 == displayOd) || (3 == displayOd) || (21 == displayOd) || (2 == displayOd))
						{
							// 売上系
							msg = "データ整合性を確保する為に、売上データ、売上明細データ、受注マスタ、車輌情報データも一緒に更新してよろしいでしょうか？";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((1 == tmpDisplayOrder) || (3 == tmpDisplayOrder) || (21 == tmpDisplayOrder) || (2 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
                                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                                    if (1 == tmpDisplayOrder)
                                    {
                                        if (tmpDisplayOrder == displayOd)
                                        {
                                            //受注データ送信区分
                                            tmpSecMngSndRcv.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                                            //受注データ受信区分
                                            tmpSecMngSndRcv.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                                            //貸出データ送信区分
                                            tmpSecMngSndRcv.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                                            //貸出データ受信区分
                                            tmpSecMngSndRcv.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                                            //見積データ送信区分
                                            tmpSecMngSndRcv.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
                                            //見積データ受信区分
                                            tmpSecMngSndRcv.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                                        }
                                        else
                                        {
                                            // 送信区分
                                            if (secMngSndRcv.SecMngSendDiv == 0)
                                            {
                                                //受注データ送信区分
                                                tmpSecMngSndRcv.AcptAnOdrSendDiv = 0;
                                                //貸出データ送信区分
                                                tmpSecMngSndRcv.ShipmentSendDiv = 0;
                                                //見積データ送信区分
                                                tmpSecMngSndRcv.EstimateSendDiv = 0;
                                            }
                                            // 受信区分
                                            if (secMngSndRcv.SecMngRecvDiv == 0)
                                            {
                                                //受注データ受信区分
                                                tmpSecMngSndRcv.AcptAnOdrRecvDiv = 0;
                                                //貸出データ受信区分
                                                tmpSecMngSndRcv.ShipmentRecvDiv = 0;
                                                //見積データ受信区分
                                                tmpSecMngSndRcv.EstimateRecvDiv = 0;
                                            }

                                        }
                                    }
                                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						else if ((10 == displayOd) || (11 == displayOd))
						{
							// 仕入系
							msg = "データ整合性を確保する為に、仕入データ、仕入明細データは一緒に更新してよろしいでしょうか？";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((10 == tmpDisplayOrder) || (11 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						else
						{
							// 在庫仕入系
							msg = "データ整合性を確保する為に、在庫仕入データ、在庫仕入明細データは一緒に更新してよろしいでしょうか？";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((17 == tmpDisplayOrder) || (18 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						DialogResult res = TMsgDisp.Show(this, 					// 親ウィンドウフォーム
									 emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
									  this.Name,						    // アセンブリＩＤまたはクラスＩＤ
									 msg, 	// 表示するメッセージ
									 0, 									// ステータス値
									 MessageBoxButtons.YesNo);				// 表示するボタン

						if (res == DialogResult.Yes)
						{

						}
						else
						{
							return false;
						}
					}
					else
					{
						SaveToSetList(secMngSndRcv, ref secMngSndRcvList, ref secMngSndRcvDtlList);
					}

				}
				
				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

				status = this._sendSetAcs.Write(ref secMngSndRcvList, ref secMngSndRcvDtlList);
			}
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 登録完了ダイアログ表示
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);

						// 再検索
						int totalCount = 0;
						Search(ref totalCount, 0);

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
							"PMKYO09200U",							// アセンブリID
							"送受信対象設定設定",  　　             // プログラム名称
							"SaveSendSet",                          // 処理名称
							TMsgDisp.OPE_UPDATE,                    // オペレーション
							"登録に失敗しました。",				    // 表示するメッセージ
							status,									// ステータス値
							this._sendSetAcs,				    	// エラーが発生したオブジェクト
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
			// UPD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//SendSetToDataSet(secMngSndRcv, this.DataIndex);
			if (!_callForm)
			{
				SendSetToDataSet(secMngSndRcv, this.DataIndex);
			}
			// UPD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 送受信対象設定オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="sendSet">送受信対象設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 企業コード設定クラスをデータセットに格納します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
		/// </remarks>
		private void SendSetToDataSet(SecMngSndRcv sendSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

			// 名称
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NAME_TITLE] = sendSet.MasterName;
			//送信区分
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SEND_TITLE] = GetSendName(sendSet.SecMngSendDiv);
			//受信区分
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVED_TITLE] = GetReceivedName(sendSet.SecMngRecvDiv, sendSet.DisplayOrder);
			//表示順位
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SORTS_TITLE] = sendSet.DisplayOrder;
			//ファイルＩＤ
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEID_TITLE] = sendSet.FileId;
			//ファイル名称
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILENM_TITLE] = sendSet.FileNm;
			//ユーザーガイド区分
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_USERGUIDEDIVCD_TITLE] = sendSet.UserGuideDivCd;

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sendSet.FileHeaderGuid;

            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            //受注データ送信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANODSEND_TITLE] = GetSendName(sendSet.AcptAnOdrSendDiv);
            //受注データ受信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANODRECEIVED_TITLE] = GetSendName(sendSet.AcptAnOdrRecvDiv);
            //貸出データ送信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SHIPMENTSEND_TITLE] = GetSendName(sendSet.ShipmentSendDiv);
            //貸出データ受信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SHIPMENTRECEIVED_TITLE] = GetSendName(sendSet.ShipmentRecvDiv);
            //見積データ送信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATESEND_TITLE] = GetSendName(sendSet.EstimateSendDiv);
            //見積データ受信区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATERECEIVED_TITLE] = GetSendName(sendSet.EstimateRecvDiv);
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

			if (this._sendSetTable.ContainsKey(sendSet.FileHeaderGuid) == true)
			{
				this._sendSetTable.Remove(sendSet.FileHeaderGuid);
			}
			this._sendSetTable.Add(sendSet.FileHeaderGuid, sendSet);
		}

		/// <summary>
		/// 同一データのメッセージ
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 既に拠点管理設定マスタに同一データある場合、メッセージがある。</br>
		/// <br>Programmer  : 張凱</br>
		/// <br>Date        : 2009/03/30</br>
		/// </remarks>
		private void RepeatTransaction(int status, ref Control control)
		{
			TMsgDisp.Show(
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				"PMKYO09200U",						// アセンブリＩＤまたはクラスＩＤ
				"データが既に存在しています。", 	// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.OK);				// 表示するボタン
			SendCode_uOption.Focus();

			control = SendCode_uOption;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date	   : 2009.04.22</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
				|| status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
			{
				TMsgDisp.Show(this,                         // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
					"PMKYO09200U",							// アセンブリID
					"既に他端末より更新されています。",	    // 表示するメッセージ
					status,									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
			}
		}

		#endregion

		# region -- Control Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Load イベント(PMKYO09200U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_Load(object sender, EventArgs e)
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

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Closing イベント(PMKYO09200U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
		///					  ようとしたときに発生します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
		///	Form.VisibleChanged イベント(PMKYO09200U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// メインフレームアクティブ化
                //this.Owner.Activate();//DEL 2011/07/25
                //-----ADD 2011/07/25----->>>>>
                if (!this._callForm)
                {
                    this.Owner.Activate();
                }
                //-----ADD 2011/07/25-----<<<<<
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
		///	ReceivedCode_.VisibleChanged イベント(PMKYO09200U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void ReceivedCode_tComEditor_SelectionChanged(object sender, EventArgs e)
		{
			SetGridNoEdit();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
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

			if (!SaveSendSet())
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			if (_callForm && (_callPara != 0))
			{
				this.Close();
			}
			// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
			else
			{
				// 画面のデータを取得する
				SecMngSndRcv comparesecMngSndRcv = new SecMngSndRcv();
				comparesecMngSndRcv = this._sendSetClone.Clone();
				ScreenToSendSet(ref comparesecMngSndRcv);

				// 画面情報と起動時のクローンと比較し変更を監視する
				if (!(this._sendSetClone.Equals(comparesecMngSndRcv)) || !CompareOriginalScreen())
				{
					// 画面情報が変更されていた場合は、保存確認メッセージを表示
					DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
						"PMKYO09200U", 			                              // アセンブリＩＤまたはクラスＩＤ
						null, 					                              // 表示するメッセージ
						0, 					                                  // ステータス値
						MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

					switch (res)
					{
						case DialogResult.Yes:
							{
								if (!SaveSendSet())
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
		/// <br>Programmer	: 張凱</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Timer_Tick(object sender, EventArgs e)
		{
			Timer.Enabled = false;

			ScreenReconstruction();
		}

		/// <summary>
		/// ChangeFocus イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null)
			{
				return;
			}

			switch (e.PrevCtrl.Name)
			{
				// グリッド
				case "uGrid_Details":
					{
						#region グリッド

						if (e.ShiftKey == false)
						{
							if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
							{
								int rowIndex;
								int colIndex;

								if (this.uGrid_Details.ActiveCell != null)
								{
									rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
									colIndex = this.uGrid_Details.ActiveCell.Column.Index;
								}
								else if (this.uGrid_Details.ActiveRow != null)
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									return;
								}
								else
								{
									if (this.uGrid_Details.Rows.Count == 0)
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
									else
									{
										e.NextCtrl = null;
										this.uGrid_Details.Rows[0].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
								}

								e.NextCtrl = null;

								if (colIndex < 4)
								{
									// にフォーカス
									this.uGrid_Details.Rows[rowIndex].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									return;
								}
								else if (colIndex == 4)
								{
									if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
									{
										// フォーカス移動なし
										//this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
										e.NextCtrl = this.Ok_Button;
										this.uGrid_Details.ActiveCell = null;
										return;
									}
									else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
									{
										e.NextCtrl = null;
										this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
									else
									{
										this.uGrid_Details.Rows[rowIndex + 1].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
								}
								else
								{
									this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
								}
							}
						}
						else
						{
							if (e.Key == Keys.Tab)
							{
								int rowIndex;
								int colIndex;

								if (this.uGrid_Details.ActiveCell != null)
								{
									rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
									colIndex = this.uGrid_Details.ActiveCell.Column.Index;
								}
								else if (this.uGrid_Details.ActiveRow != null)
								{
									rowIndex = this.uGrid_Details.ActiveRow.Index;
									colIndex = 5;
								}
								else
								{
									if (this.uGrid_Details.Rows.Count == 0)
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
									else
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
								}

								e.NextCtrl = null;

								if (colIndex <= 4)
								{
									if (rowIndex == 0)
									{
                                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                                        // ファイル名称
                                        if (this.FileName_tEdit.Text.Equals("売上データ"))
                                        {
                                            if (this.EstimateReceived_tComEditor.Enabled == true)
                                            {
                                                e.NextCtrl = this.EstimateReceived_tComEditor;
                                            }
                                            else if (this.EstimateSend_tComEditor.Enabled == true)
                                            {
                                                e.NextCtrl = this.EstimateSend_tComEditor;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ReceivedCode_tComEditor;
                                            }
                                        }
                                        else
                                        {
                                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                                            e.NextCtrl = this.ReceivedCode_tComEditor;
                                        }// ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応
									}
									else
									{
										this.uGrid_Details.Rows[rowIndex - 1].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									}
								}
								else
								{
									this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
								}
							}
						}
						break;

						#endregion
					}
			}

			if (e.NextCtrl == null)
			{
				return;
			}

			switch (e.NextCtrl.Name)
			{
				// グリッド
				case "uGrid_Details":
					{
						#region グリッド

						if (e.ShiftKey == false)
						{
							if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
							{
								if (this.uGrid_Details.Rows.Count == 0)
								{
									e.NextCtrl = this.Ok_Button;
								}
								else
								{
									e.NextCtrl = null;

									int selectIndex = this.ReceivedCode_tComEditor.SelectedIndex;

									if (selectIndex == 0 || selectIndex == 1)
									{
										e.NextCtrl = this.Ok_Button;
									}
									else
									{
										this.uGrid_Details.Rows[0].Cells[4].Activate();
									}

									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
							else if (e.Key == Keys.Up)
							{
								if (this.uGrid_Details.Rows.Count == 0)
								{
									e.NextCtrl = this.Ok_Button;
								}
								else
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						else
						{
							if (e.Key == Keys.Tab)
							{
                                if (this.uGrid_Details.Rows.Count == 0 || ReceivedCode_tComEditor.SelectedIndex == 0 ||
                                    ReceivedCode_tComEditor.SelectedIndex == 1)
								{
                                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                                    // ファイル名称
                                    if (this.FileName_tEdit.Text.Equals("売上データ"))
                                    {
                                        if (this.EstimateReceived_tComEditor.Enabled == true)
                                        {
                                            e.NextCtrl = this.EstimateReceived_tComEditor;
                                        }
                                        else if (this.EstimateSend_tComEditor.Enabled == true)
                                        {
                                            e.NextCtrl = this.EstimateSend_tComEditor;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ReceivedCode_tComEditor;
                                        }
                                    }
                                    else
                                    {
                                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                                        e.NextCtrl = this.ReceivedCode_tComEditor;
                                    }// ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応
									
								}
								else
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						break;

						#endregion
					}
			}
		}

		/// <summary>
		/// 送信名称取得処理
		/// </summary>
		/// <param name="sendCode">送信コード</param>
		/// <returns>送信名称</returns>
		/// <remarks>
		/// <br>Note       : 送信名称を取得します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private string GetSendName(int sendCode)
		{
			string sendName = string.Empty;
			if (sendCode == 0)
			{
				sendName = "なし";
			}
			else if (sendCode == 1)
			{
				sendName = "あり";
			}
			else
			{
				sendName = "";
			}
			return sendName;
		}

		/// <summary>
		/// 受信名称取得処理
		/// </summary>
		/// <param name="receivedCode">受信コード</param>
		/// <param name="displayOrder"></param>
		/// <returns>受信名称</returns>
		/// <remarks>
		/// <br>Note       : 受信名称を取得します。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private string GetReceivedName(int receivedCode, int displayOrder)
		{
			string receivedName = string.Empty;
			if ((1 <= displayOrder) && (displayOrder <= 99))
			{
				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				// 売上系、仕入系、在庫仕入系
				if ((1 == displayOrder) || (3 == displayOrder) || (21 == displayOrder) || (2 == displayOrder)
					|| (10 == displayOrder) || (11 == displayOrder) || (17 == displayOrder) || (18 == displayOrder)
					|| (19 == displayOrder)) //在庫移動データ // ADD 2011.08.25)
				{
					if (receivedCode == 0)
					{
						receivedName = "なし";
					}
					else if (receivedCode == 1)
					{
						receivedName = "あり（在庫更新なし）";
					}
					else if (receivedCode == 2)
					{
						receivedName = "あり（在庫更新あり）";
					}
					else
					{
						receivedName = string.Empty;
					}
				}
				else
				{
				// ADD 2011/07/25 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

					if (receivedCode == 0)
					{
						receivedName = "なし";
					}
					else if (receivedCode == 1)
					{
						receivedName = "あり";
					}
					else
					{
						receivedName = string.Empty;
					}
				}

			}
			else if (100 <= displayOrder)
			{
				if (receivedCode == 0)
				{
					receivedName = "なし";
				}
				else if (receivedCode == 1)
				{
					receivedName = "あり（追加のみ）";
				}
				else if (receivedCode == 2)
				{
					receivedName = "あり（追加・更新）";
				}
				else if (receivedCode == 3)
				{
					receivedName = "あり（更新のみ）";
				}
				else
				{
					receivedName = string.Empty;
				}
			}
			else
			{
				receivedName = string.Empty;
			}

			return receivedName;
		}

		/// <summary>
		/// グリッド表示リスト取得処理
		/// </summary>
		/// <param name="secMngSndRcvList">送受信対象マスタ検索結果リスト</param>
		/// <remarks>
		/// <br>Note        : グリッドに表示するリストを取得します。</br>
		/// <br>Programmer  : 張凱</br>
		/// <br>Date        : 2009.04.22</br>
		/// </remarks>
		private List<SecMngSndRcv> GetDisplayList(List<SecMngSndRcv> secMngSndRcvList)
		{
			// 重複しているデータがある場合は、同一順位のデータを取得
			Dictionary<int, SecMngSndRcv> parentDic = new Dictionary<int, SecMngSndRcv>();

			foreach (SecMngSndRcv secMngSndRcv in secMngSndRcvList)
			{
				int key = secMngSndRcv.DisplayOrder;
				if (!parentDic.ContainsKey(key))
				{
					parentDic.Add(key, secMngSndRcv.Clone());
				}
			}

			List<SecMngSndRcv> _secMngSndRcvList = new List<SecMngSndRcv>();

			foreach (SecMngSndRcv result in parentDic.Values)
			{
				_secMngSndRcvList.Add(result.Clone());
			}

			return _secMngSndRcvList;
		}

		/// <summary>
		/// 画面情報比較処理
		/// </summary>
		/// <returns>ステータス(True:変更なし False:変更あり)</returns>
		/// <remarks>
		/// <br>Note       : 画面情報の比較を行います。</br>
		/// <br>Programmer : 張凱</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private bool CompareOriginalScreen()
		{
			bool sameFlg = true;
			SecMngSndRcv secMngSndRcv = new SecMngSndRcv();

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				secMngSndRcv = ((SecMngSndRcv)this._sendSetTable[guid]).Clone();
			}

			//送受信対象マスタ
			List<SecMngSndRcv> secMngSndRcvList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
			{
				if (secMngSndRcv.DisplayOrder == target.DisplayOrder)
				{
					return (true);
				}
				else
				{
					return (false);
				}
			});

			//送受信対象詳細マスタ
			List<SecMngSndRcvDtl> secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();

			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
				{
					if (_secMngSndRcv.FileId.Equals(target.FileId))
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				foreach (SecMngSndRcvDtl result in resultDtlList)
				{
					secMngSndRcvDtlList.Add(result);
				}
			}

			for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
			{
				string fileId = this.uGrid_Details.Rows[index].Cells[COLUMN_FILEID].Value.ToString().Trim();
				string itemId = this.uGrid_Details.Rows[index].Cells[COLUMN_ITEMID].Value.ToString().Trim();

				foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
				{
					if (fileId.Equals(secMngSndRcvDtl.FileId) && itemId.Equals(secMngSndRcvDtl.ItemId))
					{
						int dataUpdate = (int)this.uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
						if (dataUpdate != secMngSndRcvDtl.DataUpdateDiv)
						{
							sameFlg = false;
							break;
						}
					}
				}
			}

			return sameFlg;
		}

		#endregion

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

        #region
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
        /// <summary>
        /// 送信区分 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 送信区分のチェックを変更した時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void SendCode_uOption_ValueChanged(object sender, EventArgs e)
        {
            // ファイル名称
            if (this.FileName_tEdit.Text.Equals("売上データ"))
            {
                // 送信区分
                if (Convert.ToInt32(this.SendCode_uOption.Value.ToString()) == 0)
                {
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.Enabled = false;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.Enabled = false;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.Enabled = false;
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.SelectedIndex = 0;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // 受注データ送信区分
                    this.AcptAnOdrSend_tComEditor.Enabled = true;
                    // 貸出データ送信区分
                    this.ShipmentSend_tComEditor.Enabled = true;
                    // 見積データ送信区分
                    this.EstimateSend_tComEditor.Enabled = true;
                }
            }
            else
            {
                // 受注データ送信区分
                this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                // 貸出データ送信区分
                this.ShipmentSend_tComEditor.SelectedIndex = 0;
                // 見積データ送信区分
                this.EstimateSend_tComEditor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 受信区分 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 受信区分のチェックを変更した時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void ReceivedCode_tComEditor_ValueChanged(object sender, EventArgs e)
        {
             // ファイル名称
            if (this.FileName_tEdit.Text.Equals("売上データ"))
            {
                // 受信区分
                if (Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString()) == 0)
                {
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.Enabled = false;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.Enabled = false;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.Enabled = false;
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // 受注データ受信区分
                    this.AcptAnOdrReceived_tComEditor.Enabled = true;
                    // 貸出データ受信区分
                    this.ShipmentReceived_tComEditor.Enabled = true;
                    // 見積データ受信区分
                    this.EstimateReceived_tComEditor.Enabled = true;
                }
            }
            else
            {
                // 受注データ受信区分
                this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                // 貸出データ受信区分
                this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                // 見積データ受信区分
                this.EstimateReceived_tComEditor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 受注データ送信区分値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 受注データ送信区分を変更した時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void AcptAnOdrSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // 受注データ送信区分
            if (this.AcptAnOdrSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.AcptAnOdrSend_tComEditor.Focus();
            }
        }

        /// <summary>
        /// データ送信区分変更のメッセージ
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ送信区分を変更した時に提示メッセージを表示する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void SendMessage()
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                "PMKYO09200U",						// アセンブリＩＤまたはクラスＩＤ
                "未送信のデータがある場合にデータの不整合が発生する可能性があります。", 	// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// 貸出データ送信区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 貸出データ送信区分を変更した時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void ShipmentSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // 貸出データ送信区分
            if (this.ShipmentSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.ShipmentSend_tComEditor.Focus();
            }
        }

        /// <summary>
        /// 貸出データ送信区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 貸出データ送信区分を変更した時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void EstimateSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // 見積データ送信区分
            if (this.EstimateSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.EstimateSend_tComEditor.Focus();
            }
        }
        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
        #endregion
	}
}