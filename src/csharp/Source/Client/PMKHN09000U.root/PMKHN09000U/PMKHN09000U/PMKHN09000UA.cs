//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先マスタ
// プログラム概要   ：得意先の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/04/30     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/09/04     修正内容：完全削除、復活処理追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/12/01     修正内容：完全削除、復活処理時、ツールバーの表示・非表示制御処理追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤仁美
// 修正日    2008/12/05     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤仁美
// 修正日    2008/12/10     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤仁美
// 修正日    2008/12/26     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/03     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009/07/30     修正内容：LoginInfoAcquisition.OnlineFlagを参照して処理を行わない。
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caowj
// 修正日    2010/08/10     修正内容：得意先マスタ障害改良対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：朱 猛
// 修正日    2010/12/06     修正内容：障害改良対応12月
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：caohh
// 修正日    2011/08/04     修正内容：NSユーザー改良要望一覧連番265の対応
// ---------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    2014/03/07     修正内容：Redmine#42174 初期表示タブの対応
// ---------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先情報登録フレームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先情報登録フォームのフレームクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2208.04.30</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.09.04 30452 上野 俊治</br>
    /// <br>             完全削除、復活処理追加</br>
    /// <br>Update Note: 2008.12.01 30452 上野 俊治</br>
    /// <br>             完全削除、復活処理時、ツールバーの表示・非表示制御処理追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote  : 2008/12/05 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/12/10 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/12/26 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2010/08/10 caowj</br>
    /// <br>              得意先マスタ障害改良対応</br>
    /// <br>UpdateNote　: 2011/08/04 caohh</br>
    /// <br>              NSユーザー改良要望一覧連番265の対応</br>
	/// </remarks>
	public partial class PMKHN09000UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		#region Const
		private const int    SAVE_DIALOG_YES	= 0;
		private const int    SAVE_DIALOG_NO		= 1;
		private const int    SAVE_DIALOG_CANCEL	= 2;
		private const string TITLE = "得意先マスタ";
		private const string OFFLINE_TITLE = " [Offline]";
		# endregion

		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		#region Const
        /// <summary>編集モード</summary>
		public static readonly int EXEC_MODE_EDIT = 1;				// 編集モード
        /// <summary>参照モード</summary>
        public static readonly int EXEC_MODE_VIEWER = 2;			// ビューアモード
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		PMKHN09010UA _inputForm = null;
		private string _key = Guid.NewGuid().ToString();							// ユニークキー文字列
		private int _execMode = 0;													// 起動モード
		private string _enterpriseCode = string.Empty;
		private ImageList _imageList16;
		private CustomerInfo _customerInfo;											// 得意先クラス
		private CustomerInfoAcs _customerInfoAcs;									// 得意先アクセスクラス
		private CustomerInputAcs _customerInputAcs;									// 得意先画面用アクセスクラス
		private CustomerSectionInfoControl _sectionInfoControl;						// 拠点情報コントロールクラス
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead;
		private CustomerInputSetUp _customerInputSetUp;
		private int _initialReadStatus = 0;
		private Hashtable _initToolTipTextTable = new Hashtable();							// ツールバー用初期ヒント文字列格納用
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;	// ログイン拠点コード
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Save;			// 保存ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Retry;			// 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Setup;			// 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_New;			// 新規ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Delete;			// 削除ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Search;			// 検索ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Close;			// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Edit;			// 編集ボタン
        // --- ADD 2008/09/04 -------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Revive;			// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_CompleteDelete;	// 編集ボタン
        // --- ADD 2008/09/04 --------------------------------<<<<< 
        // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Renewal;			// 最新情報ボタン
        // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
        // --- ADD 2010/08/10 ------------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool_Guide;			// ガイドボタン
        private CustomerInputConstructionAcs _customerInputConstructionAcs = null;
        // --- ADD 2010/08/10 ------------------------------------<<<<< 
		private ControlScreenSkin _controlScreenSkin;
        // --- ADD 2010/12/06 ------------------------------------>>>>>
        private BillAllStAcs _billAllStAcs = null; // 請求全体設定アクセスクラス
        private ArrayList _billAllStList; // 請求全体設定保存用
        private ArrayList _customerTotalDayList;// 得意先締日
        // --- ADD 2010/12/06 ------------------------------------<<<<<
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        // ===================================================================================== //
        // デリゲート定義
        // ===================================================================================== //
        # region Delegates
        /// <summary>
        /// 得意先レコード更新後イベントデリゲート
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="customerSearchRet">更新対象得意先情報</param>
        public delegate void AfterCustomerRecordUpdateEventHandler( object sender, CustomerSearchRet customerSearchRet );
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
        
        // ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// 親フォーム最前面化イベント
		/// </summary>
		public event EventHandler OwnerFormBringToFront;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// 得意先レコード更新後イベント
        /// </summary>
        public event AfterCustomerRecordUpdateEventHandler AfterCustomerRecordUpdate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

		# endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 得意先情報登録フォームフレームクラスデフォルトコンストラクタ
        /// </summary>
        public PMKHN09000UA()
        {
            InitializeComponent();

            // プライベート変数初期化
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerInfoAcs = new CustomerInfoAcs( this._key );
            this._customerInputAcs = new CustomerInputAcs( this._key );
            this._initialDataRead = new InitialDataReadHandler( this.InitialDataRead );
            this._customerInputSetUp = new CustomerInputSetUp();
            this._sectionInfoControl = new CustomerSectionInfoControl();
            this._execMode = EXEC_MODE_EDIT;
            this._controlScreenSkin = new ControlScreenSkin();

            this.buttonTool_Save = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Save_ButtonTool"];						// 保存ボタン
            this.buttonTool_Retry = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Retry_ButtonTool"];					// 元に戻すボタン
            this.buttonTool_Setup = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Setup_ButtonTool"];					// 元に戻すボタン
            this.buttonTool_New = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["New_ButtonTool"];						// 新規ボタン
            this.buttonTool_Delete = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Delete_ButtonTool"];				// 削除ボタン
            this.buttonTool_Search = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Search_ButtonTool"];				// 検索ボタン
            this.buttonTool_Close = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Close_ButtonTool"];					// 終了ボタン
            this.buttonTool_Edit = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Edit_ButtonTool"];					// 編集ボタン
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this.buttonTool_CompleteDelete = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["CompleteDelete_ButtonTool"];
            this.buttonTool_Revive = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Revive_ButtonTool"];
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
            this.buttonTool_Renewal = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Renewal_ButtonTool"];            
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools["Guide_ButtonTool"];			        // ガイドボタン
            // --- ADD 2010/08/10 ------------------------------------<<<<< 

            // デリゲート起動時イベント登録
            this._customerInfoAcs.AddInfoCustomerChangeEvent( new CustomerInfoChangeEventHandler( this.CustomerInfoChange ) );
            this._customerInfoAcs.AddInfoDeleteCustomerEvent( new CustomerInfoDeleteEventHandler( this.CustomerInfoDelete ) );

            // StaticMemory初期化処理
            this._customerInputAcs.InitialStaticMemory( 0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo );

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this._customerInputConstructionAcs = new CustomerInputConstructionAcs();
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // --- ADD 2010/12/06 ------------------------------------>>>>>
            this._billAllStAcs = new BillAllStAcs(); // 請求全体設定アクセスクラス
            this._customerTotalDayList = new ArrayList();
            // --- ADD 2010/12/06 ------------------------------------<<<<<
        }

        /// <summary>
        /// 得意先情報登録フォームフレームクラスコンストラクタ
        /// </summary>
        /// <param name="mode">0:編集モード 1:参照モード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        public PMKHN09000UA( int mode, string enterpriseCode, int customerCode )
            : this()
        {
            this._execMode = mode;

            CustomerInfo customerInfo;
            // --- DEL 2008/09/04 -------------------------------->>>>>
            //this._initialReadStatus = this._customerInfoAcs.ReadDBData( enterpriseCode, customerCode, out customerInfo );
            // --- DEL 2008/09/04 --------------------------------<<<<<
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this._initialReadStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData01, enterpriseCode, customerCode, out customerInfo);
            // --- ADD 2008/09/04 --------------------------------<<<<<

            if ( this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                this._customerInfo = customerInfo;
            }
        }
        # endregion
        
        // ===================================================================================== //
		// デリゲート用メソッド
		// ===================================================================================== //
		# region Delegate Method
		/// <summary>
		/// 得意先情報変更イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="frameKey">フレームのユニークキー</param>
        /// <param name="customerInfo">得意先クラス</param>
		private void CustomerInfoChange(object sender, string frameKey, ref CustomerInfo customerInfo)
		{
			// 同一フレーム内にて得意先情報が変更された
			if (frameKey == this._key)
			{
				this._customerInfo = customerInfo.Clone();

                //// 拠点コンボエディタ選択値設定処理
                //this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);

				// ツールバーボタン有効無効設定処理
				this.ToolBarButtonEnabledSetting();
			}
			// 他フレームにて得意先情報が変更された
			else
			{
				// 渡されてきた得意先情報クラスの得意先コードが0の場合は何もしない
				if (customerInfo.CustomerCode == 0) return;

				// 渡されてきた得意先情報クラスの得意先コードと保持している得意先コードが同一の場合は
				// 最新の情報に画面を更新する
				if (this._customerInfo.CustomerCode == customerInfo.CustomerCode)
				{
					this._customerInfo = customerInfo.Clone();

                    //// 拠点コンボエディタ選択値設定処理
                    //this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);

					if (this._execMode == EXEC_MODE_EDIT)
					{
						// Staticメモリ画面情報表示処理
						this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
					}
					else
					{
						//this._viewerForm.RepaintWebBrowser(false, this._trustContInfo);
					}

					// ツールバーボタン有効無効設定処理
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// 得意先情報削除イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
        /// <param name="frameKey">フレームキー文字列</param>
        /// <param name="customerInfo">得意先クラス</param>
		private void CustomerInfoDelete(object sender, string frameKey, ref CustomerInfo customerInfo)
		{
			// 同一フレーム内にて得意先情報が変更された
			if (frameKey == this._key)
			{
				// ツールバーボタン有効無効設定処理
				this.ToolBarButtonEnabledSetting();
			}
			// 他フレームにて得意先情報が変更された
			else
			{
				// 渡されてきた得意先情報クラスの得意先コードが0の場合は何もしない
				if (customerInfo.CustomerCode == 0) return;

				// 渡されてきた得意先情報クラスの得意先コードと保持している得意先コードが同一の場合は
				// 最新の情報に画面を更新する
				if (this._customerInfo.CustomerCode == customerInfo.CustomerCode)
				{
					// ツールバーボタン有効無効設定処理
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// 選択コード変更後発生イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SelectCodeChangedEvent(object sender, EventArgs e)
		{
			if (this.IsDisposed) return;

			if (!(e is CustomerSelectCodeChangeCtlEventArgs))
			{
				return;
			}

			CustomerSelectCodeChangeCtlEventArgs csa = (CustomerSelectCodeChangeCtlEventArgs)e;

			if (csa.Code != 0)
			{
				CustomerInfo customerInfo;
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, csa.Code, out customerInfo);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._customerInfo = customerInfo.Clone();
					
					// Staticメモリ画面情報表示処理
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// ツールバーボタン有効無効設定処理
					this.ToolBarButtonEnabledSetting();
				}
			}
		}

		/// <summary>
		/// 管理コード転送イベント処理
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="sectionCode">拠点コード</param>
		private void TransmitMngSectionCode(object sender, string sectionCode)
		{
            //bool isSetting = false;

            //if ((sectionCode != null) && (sectionCode.ToString() != ""))
            //{
            //    isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, sectionCode);
            //}
            //else
            //{
            //    isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._loginSectionCode);
            //}

            //if (isSetting)
            //{
            //    // 管理拠点コード展開処理
            //    this.MngSectionCodeBroadCast();
            //}
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region Public Methods
		/// <summary>
		/// キープロパティ
		/// </summary>
		public string Key
		{
			get { return _key; }
		}

		/// <summary>
		/// 選択情報（企業コード・得意先コード）取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:取得成功 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : 現在選択中の企業コード、得意先コードを取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int GetSelectInfo(out string enterpriseCode, out int customerCode)
		{
			int status;

			// 更新日がMinValueの場合は、DBにデータが登録されていないと判断する
			if ((this._customerInfo == null) || (this._customerInfo.UpdateDateTime == DateTime.MinValue))
			{
				enterpriseCode = string.Empty;
				customerCode = 0;

				status = -1;
			}
			else
			{
				enterpriseCode = this._customerInfo.EnterpriseCode;
				customerCode = this._customerInfo.CustomerCode;

				status = 0;
			}

			return status;
		}

		/// <summary>
		/// 編集状態取得処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <returns>true:編集中 false:未編集</returns>
		public bool IsEditting(out string message)
		{
			bool result = false;

			int status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status != 0)
			{
				result = true;
				if (this._customerInfo.CustomerCode == 0)
				{
					message = "'得意先コード：未入力'";
				}
				else
				{
					message = "'得意先コード：" + this._customerInfo.CustomerCode.ToString() + "'";
				}

				if (this._customerInfo.Name == "")
				{
					message += "\r\n" + "'得意先名：未入力'";
				}
				else
				{
					message += "\r\n" + "'得意先名：" + this._customerInfo.Name + "'";
				}
			}
			else
			{
				message = string.Empty;
			}

			return result;
		}

		/// <summary>
		/// 画面終了処理
		/// </summary>
		/// <returns>0:終了完了 1:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : 終了チェック処理後、画面を終了します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DispClose()
		{
			// データ保存確認処理
			if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
			{
				return 1;
			}

			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory初期化処理
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// 得意先データ戻し処理
				this._customerInfoAcs.CopyStaticMemory(1, this._enterpriseCode, this._customerInfo.CustomerCode);
			}

			this.Close();
			return 0;
		}

		/// <summary>
		/// 画面終了チェック処理
		/// </summary>
		/// <returns>0:終了可 1:終了不可</returns>
		/// <remarks>
		/// <br>Note       : 終了チェック処理を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DispCloseCheck()
		{
			// データ保存確認処理
			if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
			{
				return 1;
			}

			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory初期化処理
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// 得意先データ戻し処理
				this._customerInfoAcs.CopyStaticMemory(1, this._enterpriseCode, this._customerInfo.CustomerCode);
			}

			return 0;
		}

		/// <summary>
		/// 得意先新規処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <remarks>
		/// <br>Note       : 得意先画面を新規の状態で表示します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void CustomerNew(string enterpriseCode)
		{
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory初期化処理
				this._customerInputAcs.InitialStaticMemory(0, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);
			}
			else
			{
				// 得意先データ戻し処理
				this._customerInfoAcs.CopyStaticMemory(1, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
			}

			// StaticMemory初期化処理
			this._customerInputAcs.InitialStaticMemory(0, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out this._customerInfo);

            //// 管理拠点コードを設定する
            //bool isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);
            //if (isSetting) this.MngSectionCodeBroadCast();

			// Staticメモリ画面情報表示処理
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			// フォーカス初期設定処理
			this.SetInitFocus();
		}

		/// <summary>
		/// 終了ボタン表示非表示設定プロパティ
		/// </summary>
		/// <remarks>
		/// <br>Note       :  終了ボタンの表示非表示を設定します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public bool IsClosedButtonDisplay
		{
			get
			{
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				return closeButton.SharedProps.Visible;
			}
			set
			{
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				closeButton.SharedProps.Visible = value;
			}
		}

		/// <summary>
		/// 選択情報キー取得処理
		/// </summary>
		/// <returns>各フォーム毎の選択情報キー文字列</returns>
		public string GetSelectedInfoKey()
		{
			if (this._customerInfo.CustomerCode == 0)
			{
				return this._key;
			}
			else
			{
				return this._customerInfo.EnterpriseCode + "-" + this._customerInfo.CustomerCode.ToString();
			}
		}
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// Tab生成処理
		/// </summary>
		private void TabCreate(int mode)
		{
			if (mode == EXEC_MODE_EDIT)
			{
				this._inputForm = new PMKHN09010UA(this._key, this._customerInfo);

				// フォームプロパティ変更
				this._inputForm.TopLevel = false;
				this._inputForm.FormBorderStyle = FormBorderStyle.None;
                this.Form1_Fill_Panel.Controls.Add( this._inputForm );
                this._inputForm.Show();
				this._inputForm.Dock = System.Windows.Forms.DockStyle.Fill;

				this._inputForm.SelectCodeChanged += new EventHandler(this.SelectCodeChangedEvent);
				this._inputForm.TransmitMngSectionCode += new CustomerCarSectionCodeTransmitEventHandler(this.TransmitMngSectionCode);
				this._inputForm.OwnSectionCode = this._loginSectionCode;

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                // --- ADD 梶谷貴士 2021/05/10 ------------------------------------>>>>>
                //this._inputForm.DataSave += new DataSaveEventHandler(this.Save);
                // --- ADD 梶谷貴士 2021/05/10 ------------------------------------<<<<<
                this._inputForm.SetGuideEnabled += new SetGuideEnableEventHandler(this.SetGuideEnabled);
                // --- ADD 2010/08/10 ------------------------------------<<<<<
			}
			else if (mode == EXEC_MODE_VIEWER)
			{
			}
		}

		/// <summary>
		/// 初期設定系データリード処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 初期設定系データをリードします。非同期処理です。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialDataRead()
		{
			// オフラインモードの場合は処理しない
			if (!LoginInfoAcquisition.OnlineFlag)
			{
				return;
			}
		}

		/// <summary>
		/// 初期設定系データリード処理コールバックメソッド
		/// </summary>
		/// <remarks>
		/// <br>Note       : 初期設定系データリード処理が完了した後に実行されます。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialDataReadCallBack(IAsyncResult ar)
		{
			InitialDataReadHandler initialDataReadHandler = (InitialDataReadHandler)ar.AsyncState;
			initialDataReadHandler.EndInvoke(ar);
		}

		/// <summary>
		/// ツールバー用初期ヒント文字列格納用Hashtable設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバー用初期ヒント文字列格納用Hashtable設定処理に初期ヒントを格納します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void ToolTipTextTableSetting()
		{
			foreach (object tool in this.Main_ToolbarsManager.Tools.All)
			{
				if (tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool)
				{
					this._initToolTipTextTable.Add(((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool).Key, 
						((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool).SharedProps.ToolTipText);
				}
				else if (tool is Infragistics.Win.UltraWinToolbars.ButtonTool)
				{
					this._initToolTipTextTable.Add(((Infragistics.Win.UltraWinToolbars.ButtonTool)tool).Key,
						((Infragistics.Win.UltraWinToolbars.ButtonTool)tool).SharedProps.ToolTipText);
				}
			}
		}

		/// <summary>
		/// ツールバー用初期ヒント文字列取得処理
		/// </summary>
		/// <param name="key">ツールボタン用Key</param>
		/// <returns>ツールバー用初期ヒント文字列</returns>
		/// <remarks>
		/// <br>Note       : ツールバー用初期ヒント文字列を取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private string GetInitToolTipText(string key)
		{
			if (this._initToolTipTextTable.ContainsKey(key))
			{
				return this._initToolTipTextTable[key].ToString();
			}
			else
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// </remarks>
		private void SetToolbar()
		{
			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = this._imageList16;

			// ログイン担当者へのアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
			loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			
			// 新規のアイコン設定
			this.buttonTool_New.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			
			// 保存のアイコン設定
			this.buttonTool_Save.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// 終了のアイコン設定
			this.buttonTool_Close.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            //// 伝票に反映のアイコン設定
            //this.buttonTool_Reflect.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPREFLECT;

			// 検索のアイコン設定
			this.buttonTool_Search.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			// 設定のアイコン設定
			this.buttonTool_Setup.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// 元に戻すのアイコン設定
			this.buttonTool_Retry.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

			// 削除のアイコン設定
			this.buttonTool_Delete.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERDELETE;

			// 編集のアイコン設定
			this.buttonTool_Edit.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // 復活のアイコン設定
            this.buttonTool_Revive.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // 完全削除のアイコン設定
            this.buttonTool_CompleteDelete.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
            this.buttonTool_Renewal.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // --- ADD 2010/08/10 ------------------------------------<<<<< 

            //// メモのアイコン設定
            //this.buttonTool_Memo.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.FREEMEMO;

            //// 仕入先情報入力のアイコン／表示非表示設定
            //this.buttonTool_CustSuppli.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERCORP1;

			// 管理拠点のアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["SectionTitle_LabelTool"];
			sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

            //// 管理拠点コンボボックスの設定
            //try
            //{
            //    this._sectionInfoControl.SetSectionComboEditor(ref this.comboBoxTool_Section, false);

            //    // 拠点コンボエディタ選択値設定処理
            //    this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._loginSectionCode);
            //}
            //catch (ApplicationException ex)
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_STOP,
            //        this.Name,
            //        ex.Message,
            //        0,
            //        MessageBoxButtons.OK);

            //    this.Close();
            //    return;
            //}

            //Infragistics.Win.UltraWinToolbars.ControlContainerTool sectionContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools["SectionCode_ControlContainerTool"];

            //if (CustomerSectionInfoControl.IsSectionOptionIntroduce)
            //{
            //    sectionTitleLabel.SharedProps.Visible = true;
            //    sectionContainer.SharedProps.Visible = true;
            //    this.comboBoxTool_Section.SharedProps.Visible = true;
            //}
            //else
            //{
            //    sectionTitleLabel.SharedProps.Visible = false;
            //    sectionContainer.SharedProps.Visible = false;
            //    this.comboBoxTool_Section.SharedProps.Visible = false;
            //}
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private void InitialSetting()
		{
			// ツールバー初期設定処理
			this.SetToolbar();

			// 各コントロール初期設定
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;

			Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginInfoAcquisition.Employee != null)
			{
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーボタン有効無効設定を行います</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			// StaticMemory変更有無チェック 
			int compareFlg = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (compareFlg == 0)
			{
				// 戻るボタンを無効にする
				this.buttonTool_Retry.SharedProps.Enabled = false;
			}
			else
			{
				// 戻るボタンを有効にする
				this.buttonTool_Retry.SharedProps.Enabled = true;
			}

			// 新規or更新にてボタンの有効無効を制御する
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				this.buttonTool_Delete.SharedProps.Enabled = false;				// 削除
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_CompleteDelete.SharedProps.Enabled = false;
                this.buttonTool_Revive.SharedProps.Enabled = false;
                // --- ADD 2008/09/04 --------------------------------<<<<<
			}
			else
			{
				this.buttonTool_Delete.SharedProps.Enabled = true;				// 削除
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_CompleteDelete.SharedProps.Enabled = true;
                this.buttonTool_Revive.SharedProps.Enabled = true;
                // --- ADD 2008/09/04 --------------------------------<<<<<
			}

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // 論理削除にて有効無効を制御する
            if (_customerInfo.LogicalDeleteCode == 0)
            {
                this.buttonTool_Save.SharedProps.Enabled = true;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Enabled = true;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
            }
            else
            {
                this.buttonTool_Save.SharedProps.Enabled = false;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Enabled = false;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
            }
            // --- ADD 2008/09/04 --------------------------------<<<<<

            //// 参照画面の場合は管理拠点を無効にする
            //// 参照画面でメモが割り当てられていない場合は、メモボタンを無効にする
            //if (this._execMode == EXEC_MODE_EDIT)
            //{
            //    if (this._sectionInfoControl.IsMainOfficeFunc())
            //    {
            //        this.comboBoxTool_Section.SharedProps.Enabled = true;
            //    }
            //    else
            //    {
            //        this.comboBoxTool_Section.SharedProps.Enabled = false;
            //    }


            //    //if (this._customerInfo.TakeInImageGroupCd == Guid.Empty)
            //    //{
            //    //    this.buttonTool_Memo.SharedProps.Enabled = false;
            //    //}
            //    //else
            //    //{
            //    //    this.buttonTool_Memo.SharedProps.Enabled = true;
            //    //}
            //}
            //else
            //{
            //    this.comboBoxTool_Section.SharedProps.Enabled = false;
            //    this.buttonTool_Memo.SharedProps.Enabled = false;
            //}

            //// 仕入先区分が全て0の場合は仕入先情報入力ボタンを無効化する
            //if ((this._customerInfo.SupplierDiv == 0) && (this._customerInfo.SupplierDiv == 0))
            //{
            //    this.buttonTool_CustSuppli.SharedProps.Enabled = false;

            //    // ToolTipTextを有効無効用に変更する
            //    this.buttonTool_CustSuppli.SharedProps.ToolTipText = TOOL_TIP_TEXT_ENABLED_CUSTSUPPLI;
            //}
            //else
            //{
            //    this.buttonTool_CustSuppli.SharedProps.Enabled = true;

            //    // ToolTipTextを元に戻す
            //    this.buttonTool_CustSuppli.SharedProps.ToolTipText = this.GetInitToolTipText(this.buttonTool_CustSuppli.Key);
            //}

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オフラインモードでは使用できないボタンを無効化する
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    this.buttonTool_Save.SharedProps.Enabled = false;						// 保存ボタン
            //    this.buttonTool_New.SharedProps.Enabled = false;						// 新規
            //    //this.buttonTool_CustSuppli.SharedProps.Enabled = false;					// 仕入先情報入力ボタン
            //    this.buttonTool_Edit.SharedProps.Enabled = false;						// 編集ボタン
            //    // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
            //    this.buttonTool_Renewal.SharedProps.Enabled = false;						// 最新ボタン
            //    // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
            //}
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// フォームテキスト設定処理


            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.buttonTool_Guide.SharedProps.Enabled = false;
            // --- ADD 2010/08/10 ------------------------------------<<<<<
			this.SetFormText();
		}

		/// <summary>
		/// ツールバーボタン表示非表示コントロール処理
		/// </summary>
		private void ToolBarButtonVisibleControl()
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this.buttonTool_New.SharedProps.Visible = true;
				this.buttonTool_Save.SharedProps.Visible = true;
				this.buttonTool_Setup.SharedProps.Visible = true;
				this.buttonTool_Retry.SharedProps.Visible = true;
                // --- DEL 2008/09/04 -------------------------------->>>>>
				//this.buttonTool_Delete.SharedProps.Visible = true;
                // --- DEL 2008/09/04 --------------------------------<<<<<
				this.buttonTool_Edit.SharedProps.Visible = false;
                //this.buttonTool_Memo.SharedProps.Visible = true;
                //this.buttonTool_CustSuppli.SharedProps.Visible = true;
                
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Visible = true;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<

                // --- ADD 2008/09/04 -------------------------------->>>>>
                // 削除と完全削除・復活は表示制御する
                if (this._customerInfo.LogicalDeleteCode == 0)
                {
                    this.buttonTool_Delete.SharedProps.Visible = true;
                    this.buttonTool_Revive.SharedProps.Visible = false;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                }
                else if (this._customerInfo.LogicalDeleteCode == 1)
                {
                    this.buttonTool_Delete.SharedProps.Visible = false;
                    this.buttonTool_Revive.SharedProps.Visible = true;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = true;
                }
                else
                {
                    this.buttonTool_Delete.SharedProps.Visible = false;
                    this.buttonTool_Revive.SharedProps.Visible = false;
                    this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                }

                // --- ADD 2008/09/04 --------------------------------<<<<< 
			}
			else
			{
				this.buttonTool_New.SharedProps.Visible = false;
				this.buttonTool_Save.SharedProps.Visible = false;
				this.buttonTool_Setup.SharedProps.Visible = false;
				this.buttonTool_Retry.SharedProps.Visible = false;
				this.buttonTool_Delete.SharedProps.Visible = false;
				this.buttonTool_Edit.SharedProps.Visible = true;
                // --- ADD 2008/09/04 -------------------------------->>>>>
                this.buttonTool_Revive.SharedProps.Visible = false;
                this.buttonTool_CompleteDelete.SharedProps.Visible = false;
                // --- ADD 2008/09/04 --------------------------------<<<<< 
                //this.buttonTool_Memo.SharedProps.Visible = true;
                //this.buttonTool_CustSuppli.SharedProps.Visible = false;

                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
                this.buttonTool_Renewal.SharedProps.Visible = false;
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
			}

			this.buttonTool_Search.SharedProps.Visible = false;
            //this.buttonTool_Reflect.SharedProps.Visible = false;

			// イベントがnullの場合は該当するボタンを非表示とする
			if (this.OwnerFormBringToFront == null)
			{
				this.buttonTool_Search.SharedProps.Visible = false;
			}

			// PopupMenu内にToolが存在しない場合はPopupMenuを非表示とする
			Infragistics.Win.UltraWinToolbars.PopupMenuTool[] popupMenuToolArray = new Infragistics.Win.UltraWinToolbars.PopupMenuTool[5];
			popupMenuToolArray[0] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["File_PopupMenuTool"];
			popupMenuToolArray[1] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["AddInfo_PopupMenuTool"];
			popupMenuToolArray[2] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Guide_PopupMenuTool"];
			popupMenuToolArray[3] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Tool_PopupMenuTool"];
			popupMenuToolArray[4] = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["Window_PopupMenuTool"];

			foreach(Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool in popupMenuToolArray)
			{
				if (popupMenuTool != null)
				{
					int count = 0;
					foreach(Infragistics.Win.UltraWinToolbars.ToolBase toolBase in popupMenuTool.Tools)
					{
						if (toolBase.SharedProps.Visible)
						{
							count++;
						}
					}

					if (count == 0)
					{
						popupMenuTool.SharedProps.Visible = false;
					}
					else
					{
						popupMenuTool.SharedProps.Visible = true;
					}
				}
			}
		}

		/// <summary>
		/// データ戻し確認処理
		/// </summary>
		/// <param name="isCompare">比較実行フラグ[true:比較する false:比較しない]</param>
		/// <returns>true:チェック制御完了 false:キャンセル</returns>
		private bool DataBackDialogCheck(bool isCompare)
		{
			bool result = true;

			int status = 1;
			if (isCompare)
			{
				status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);
			}

			if (status != 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" +
					"初期状態に戻しますか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case (DialogResult.Yes):
					{
						break;
					}
					default:
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = true;
			}

			return result;
		}

		/// <summary>
		/// データ削除確認処理
		/// </summary>
		/// <returns>TRUE:チェック制御完了 FALSE:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ削除確認処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool DataDeleteDialogCheck()
		{
			bool result = true;

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"現在表示中の得意先を削除します。" + "\r\n" +
				"よろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult.Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// データ復活確認処理
        /// </summary>
        /// <returns>TRUE:チェック制御完了 FALSE:キャンセル</returns>
        /// <remarks>
        /// <br>Note       : データ復活確認処理を実行します。</br>
        /// <br>Programmer : 30452 上野俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private bool DataReviveDialogCheck()
        {
            bool result = true;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "現在表示中の得意先を復活します。" + "\r\n" +
                "よろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            switch (dialogResult)
            {
                case (DialogResult.Yes):
                    {
                        result = true;
                        break;
                    }
                case (DialogResult.No):
                    {
                        result = false;
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// データ完全削除確認処理
        /// </summary>
        /// <returns>TRUE:チェック制御完了 FALSE:キャンセル</returns>
        /// <remarks>
        /// <br>Note       : データ完全削除確認処理を実行します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private bool DataCompleteDeleteDialogCheck()
        {
            bool result = true;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "現在表示中の得意先を完全削除します。" + "\r\n" +
                "よろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            switch (dialogResult)
            {
                case (DialogResult.Yes):
                    {
                        result = true;
                        break;
                    }
                case (DialogResult.No):
                    {
                        result = false;
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// データ登録処理
		/// </summary>
		/// <param name="saveCompletionDialogDisp">保存完了ダイアログ表示フラグ</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>UpdateNote　: 2011/08/04 caohh</br>
        /// <br>              NSユーザー改良要望一覧連番265の対応</br>
        /// </remarks>
        private int Save(bool saveCompletionDialogDisp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
			ArrayList duplicationItemList = new ArrayList();
			ArrayList itemList = new ArrayList();

			// 表示中データStaticMemory登録処理
			this._inputForm.SaveStaticMemoryData(this);

			// Static情報の取得処理
			CustomerInfo customerInfo;
			status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
               
                #region DEL 2008/12/12
                //// 得意先クラス入力データチェック処理
                //if (!this._customerInfoAcs.CustomerInputDataCheck(customerInfo, out duplicationItemList, out itemList))
                //{
                //    StringBuilder message = new StringBuilder();
                //    message.Append("未入力の項目が存在するため、登録できません。" + "\r\n" + "\r\n");

                //    foreach (string s in duplicationItemList)
                //    {
                //        message.Append(s + "\r\n");
                //    }
						
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        message.ToString(),
                //        status,
                //        MessageBoxButtons.OK);

                //    string itemName = string.Empty;
                //    if (itemList.Count > 0)
                //    {
                //        itemName = itemList[0].ToString();

                //        // 指定フォーカス設定処理
                //        this.SetFocus(itemName);
                //    }

                //    return -1;
                //}

                //// ADD 2008/12/03 不具合対応[8548] ---------->>>>>
                //// 拠点存在チェック処理
                //string sectionCode = customerInfo.MngSectionCode;
                //StringBuilder Sectionmessage = new StringBuilder();
                //bool errFlg = false;
                //bool errFlg2 = false;

                //SecInfoSet secInfoSet;
                //int CkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, sectionCode);
                //if (CkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    errFlg = true;
                //}

                //sectionCode = customerInfo.ClaimSectionCode;

                //CkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, sectionCode);
                //if (CkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    errFlg2 = true;
                    
                //}
                //if (errFlg == true ||
                //    errFlg2==true)
                //{
                //    Sectionmessage.Append("拠点が削除されています。" + "\r\n" + "\r\n");

                //    if (errFlg == true)
                //    {
                //        Sectionmessage.Append("管理拠点" + "\r\n");
                //    }
                //    if (errFlg2 == true)
                //    {
                //        Sectionmessage.Append("請求拠点" + "\r\n");
                //    }
                //    TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            Sectionmessage.ToString(),
                //            status,
                //            MessageBoxButtons.OK);

                //    if (errFlg == true)
                //    {
                //        // 指定フォーカス設定処理
                //        this.SetFocus("ClaimSectionCode");
                //    }
                //    else
                //    {
                //        // 指定フォーカス設定処理
                //        this.SetFocus("MngSectionCode");
                //    }

                //    return -1;
                //}
                //// ADD 2008/12/03 不具合対応[8548] ----------<<<<<


                //// ADD 2008/12/05 不具合対応[8763] ---------->>>>>
                //// 優先倉庫存在チェック処理

                //// ｺｰﾄﾞ変換
                //string warehouseCode = customerInfo.CustWarehouseCd;

                //Warehouse warehouse = null;
                //int WarehouseStatus = this._customerInputAcs.GetWarehouseFromWarehouseCode(out warehouse, customerInfo.MngSectionCode, warehouseCode);

                //// ADD 2008/12/10 不具合対応[8763] ---------->>>>>
                //if (warehouseCode != null &&
                //    !warehouseCode.Trim().Equals(string.Empty) &&
                //    !warehouseCode.Trim().Equals("0"))
                //{
                //// ADD 2008/12/10 不具合対応[8763] ----------<<<<<
                //    if (WarehouseStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //            //"優先倉庫が削除されています。",
                //            "優先倉庫がマスタに未登録、または削除されています。",
                //            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                //            status,
                //            MessageBoxButtons.OK);

                //        // 指定フォーカス設定処理
                //        this.SetFocus("CustWarehouseCd");

                //        return -1;
                //    }
                //// ADD 2008/12/10 不具合対応[8763] ---------->>>>>
                //}
                //// ADD 2008/12/10 不具合対応[8763] ----------<<<<<
                //// ADD 2008/12/05 不具合対応[8763] ----------<<<<<


                //// 得意先クラス不正データチェック処理
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
                ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
                //////if (!this._customerInfoAcs.CustomerUnJustDataCheck(customerInfo, out duplicationItemList, out itemList))
                ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
                ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
                ////if ( !this.CustomerUnJustDataCheckScreen( customerInfo, out duplicationItemList, out itemList ) )
                ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                //if ( !this._inputForm.CustomerUnJustDataCheck( out duplicationItemList, out itemList ) )
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                //{
                //    StringBuilder message = new StringBuilder();
                //    message.Append("入力値が不正な項目が存在するため、登録できません。" + "\r\n" + "\r\n");

                //    foreach (string s in duplicationItemList)
                //    {
                //        message.Append(s + "\r\n");
                //    }
						
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        message.ToString(),
                //        status,
                //        MessageBoxButtons.OK);

                //    string itemName = string.Empty;
                //    if (itemList.Count > 0)
                //    {
                //        itemName = itemList[0].ToString();

                //        // 指定フォーカス設定処理
                //        this.SetFocus(itemName);
                //    }

                //    return -1;
                //}

                //// 請求先存在チェック処理
                //if ((customerInfo.ClaimCode != 0) && (customerInfo.CustomerCode != customerInfo.ClaimCode))
                //{
                //    int existStatus = this._customerInfoAcs.ExistData(customerInfo.EnterpriseCode, customerInfo.ClaimCode, ConstantManagement.LogicalMode.GetData0);

                //    if (existStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //            this.Name,
                //            "請求先が削除されています。",
                //            status,
                //            MessageBoxButtons.OK);

                //        // 指定フォーカス設定処理
                //        this.SetFocus("ClaimName");

                //        return -1;
                //    }
                //}
                #endregion DEL 2008/12/12

                // 得意先クラス入力データチェック処理
                this._customerInfoAcs.CustomerInputDataCheck(customerInfo, out duplicationItemList, out itemList);

                if (!customerInfo.IsReceiver)
                {
                    // 拠点存在チェック処理
                    bool mngSectionCheck = false;
                    bool claimSectionCheck = false;
                    foreach (string name in duplicationItemList)
                    {
                        if (name == "管理拠点")
                        {
                            mngSectionCheck = true;
                        }
                        if (name == "請求拠点")
                        {
                            claimSectionCheck = true;
                        }

                        if ((mngSectionCheck == true) && (claimSectionCheck == true))
                        {
                            break;
                        }
                    }

                    SecInfoSet secInfoSet;
                    if (!mngSectionCheck)
                    {
                        int chkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, customerInfo.MngSectionCode);
                        if (chkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList.Add("管理拠点");
                            itemList.Add("MngSectionCode");
                        }
                    }
                    if (!claimSectionCheck)
                    {
                        int chkStatus = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, customerInfo.ClaimSectionCode);
                        if (chkStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList.Add("請求拠点");
                            itemList.Add("ClaimSectionCode");
                        }
                    }
                }

                // 得意先担当チェック処理
                if ((customerInfo.CustomerAgentCd != null) && (customerInfo.CustomerAgentCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.CustomerAgentCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("得意先担当");
                        itemList.Add("CustomerAgentCd");
                    }
                }

                // 旧担当チェック処理
                if ((customerInfo.OldCustomerAgentCd != null) && (customerInfo.OldCustomerAgentCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.OldCustomerAgentCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("旧担当");
                        itemList.Add("OldCustomerAgentCd");
                    }
                }

                // 集金担当チェック処理
                if ((customerInfo.BillCollecterCd != null) && (customerInfo.BillCollecterCd.Trim() != ""))
                {
                    Employee employee;
                    int employeeStatus = this._customerInputAcs.GetEmployeeFromEmployeeCode(customerInfo.BillCollecterCd.Trim(), out employee);
                    if (employeeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("集金担当");
                        itemList.Add("BillCollecterCd");
                    }
                }

                // 優先倉庫存在チェック処理
                if ((customerInfo.CustWarehouseCd != null) && (customerInfo.CustWarehouseCd.Trim() != ""))
                {
                    Warehouse warehouse;
                    int warehouseStatus = this._customerInputAcs.GetWarehouseFromWarehouseCode(out warehouse, customerInfo.MngSectionCode, customerInfo.CustWarehouseCd);
                    if (warehouseStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        duplicationItemList.Add("優先倉庫");
                        itemList.Add("CustWarehouseCd");
                    }
                }

                // --- ADD 2010/12/06 ------------------------------------>>>>>
                // 締日の入力チェック
                if (this._inputForm.CheckTotalDay(this._customerTotalDayList) < 0)
                {
                    duplicationItemList.Add("締日");
                    itemList.Add("TotalDay");
                }
                // --- ADD 2010/12/06 ------------------------------------<<<<<

                ArrayList duplicationItemList2 = new ArrayList();
                ArrayList itemList2 = new ArrayList();
                this._inputForm.CustomerUnJustDataCheck(out duplicationItemList2, out itemList2);

                // 請求先存在チェック処理
                bool claimCheck = false;
                foreach (string name in duplicationItemList)
                {
                    if (name == "請求先コード")
                    {
                        claimCheck = true;
                        break;
                    }
                }

                if (!claimCheck)
                {
                    if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                    {
                        int existStatus = this._customerInfoAcs.ExistData(customerInfo.EnterpriseCode, customerInfo.ClaimCode, ConstantManagement.LogicalMode.GetData0);
                        if (existStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            duplicationItemList2.Add("請求先コード");
                            itemList2.Add("ClaimName");
                        }
                    }
                }

                //ADD 2008/12/26 不具合対応[9531] ---------->>>>>
                //現金売りのチェック
                string fildname = "";
                if (customerInfo.AccRecDivCd == 0)
                {
                    if(customerInfo.ConsTaxLayMethod == 2){
                        fildname = "請求親";
                    }else if(customerInfo.ConsTaxLayMethod == 3){
                        fildname = "請求子";
                    }

                    if (fildname.Equals(string.Empty) == false)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    fildname + "になっている為、売掛なしの指定はできません。",
                                    status,
                                    MessageBoxButtons.OK);

                        // 指定フォーカス設定処理
                        this.SetFocus("AccRecDivCd");

                        return -1;
                    }
                }
                //ADD 2008/12/26 不具合対応[9531] ----------<<<<<

                // ADD 2009/06/03 ------>>>
                if (customerInfo.OnlineKindDiv != 0)
                {
                    // オンライン接続区分が"なし"以外
                    if (customerInfo.CustomerEpCode == string.Empty)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "得意先企業コードを入力して下さい。",
                                    status,
                                    MessageBoxButtons.OK);
                        // 指定フォーカス設定処理
                        this.SetFocus("CustomerEpCode");
                        return -1;
                    }
                    else if (customerInfo.CustomerEpCode.Length != 16)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "得意先企業コードは１６桁で入力して下さい。",
                                    status,
                                    MessageBoxButtons.OK);
                        // 指定フォーカス設定処理
                        this.SetFocus("CustomerEpCode");
                        return -1;
                    }

                    if (customerInfo.CustomerSecCode == string.Empty)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "得意先拠点コードを入力して下さい。",
                                    status,
                                    MessageBoxButtons.OK);
                        // 指定フォーカス設定処理
                        this.SetFocus("CustomerSecCode");
                        return -1;
                    }
                }
                // ADD 2009/06/03 ------<<<

                Dictionary<string, string> duplicationItemDic = new Dictionary<string, string>();
                foreach (string itemName in duplicationItemList)
                {
                    if (!duplicationItemDic.ContainsKey(itemName))
                    {
                        duplicationItemDic.Add(itemName, itemName);
                    }
                }
                foreach (string itemName in duplicationItemList2)
                {
                    if (!duplicationItemDic.ContainsKey(itemName))
                    {
                        duplicationItemDic.Add(itemName, itemName);
                    }
                }


                Dictionary<string, string> itemListDic = new Dictionary<string, string>();
                foreach (string itemName in itemList)
                {
                    if (!itemListDic.ContainsKey(itemName))
                    {
                        itemListDic.Add(itemName, itemName);
                    }
                }
                foreach (string itemName in itemList2)
                {
                    if (!itemListDic.ContainsKey(itemName))
                    {
                        itemListDic.Add(itemName, itemName);
                    }
                }

                if (duplicationItemDic.Count > 0)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("入力値が不正な項目が存在するため、登録できません。" + "\r\n" + "\r\n");

                    foreach (string s in duplicationItemDic.Values)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        status,
                        MessageBoxButtons.OK);

                    string itemName = string.Empty;
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();

                        // 指定フォーカス設定処理
                        this.SetFocus(itemName);
                    }

                    return -1;
                }

                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<

				// StaticMemoryＤＢ書き込み処理
				status = this._customerInfoAcs.WriteDBData(this, false, ref customerInfo, out duplicationItemList);
				
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._customerInfo = customerInfo.Clone();

					// Staticメモリ画面情報表示処理
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// ツールバーボタン有効無効設定処理
					this.ToolBarButtonEnabledSetting();

					StringBuilder message = new StringBuilder();

					foreach(string s in duplicationItemList)
					{
						if (s.Trim() != "")
						{
							message.Append(s + "\r\n");
						}
					}

					if (message.ToString().Trim() != "")
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							message.ToString(),
							0,
							MessageBoxButtons.OK);
					}

					if (saveCompletionDialogDisp)
					{
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // データ更新イベントコール
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 表示データクローン生成
                    CustomerInfo customerInfoDispBuffer = _customerInfo.Clone();
                    customerInfoDispBuffer.CustomerCode = 0;
                    customerInfoDispBuffer.ClaimCode = 0;
                    customerInfoDispBuffer.ClaimName = string.Empty;
                    customerInfoDispBuffer.ClaimName2 = string.Empty;
                    customerInfoDispBuffer.ClaimSnm = string.Empty;
                    customerInfoDispBuffer.UpdateDateTime = DateTime.MinValue;

                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //「1：得意先コードを保持」の場合、得意先コードを取得する
                    int customerCodeTmp = 0;
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        customerCodeTmp = this._customerInfo.CustomerCode;
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<

                    // StaticMemory初期化処理
                    this._customerInputAcs.InitialStaticMemory( 0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo );

                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //「1：得意先コードを保持」の場合、得意先コード情報をセットする
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        customerInfoDispBuffer = this._customerInfo;
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<

                    // 画面情報表示処理
                    this._inputForm.ShowCustomerBuffer( this, this._enterpriseCode, customerInfoDispBuffer );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                    //「1：得意先コードを保持」の場合、画面に得意先コードをセットする
                    if (_customerInputConstructionAcs.KeepOnInfoSetting == 1)
                    {
                        if (customerCodeTmp != 0)
                        {
                            this._inputForm.SetCustomerCode(customerCodeTmp);
                        }
                    }
                    // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                    // 初期フォーカス
                    SetInitFocus();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
				{
					foreach(string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_INFO,
									this.Name,
									"この得意先サブコードは既に登録済みです。",
									status,
									MessageBoxButtons.OK);

								break;
							}
							default:
							{
								break;
							}
						}
					}
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					if (duplicationItemList.Count > 0)
					{
						StringBuilder message = new StringBuilder();

						foreach(string s in duplicationItemList)
						{
							if (s.Trim() != "")
							{
								message.Append(s + "\r\n");
							}
						}

						if (message.ToString().Trim() != "")
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								message.ToString(),
								0,
								MessageBoxButtons.OK);
						}
					}
					else
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"現在、編集中の得意先データは既に更新されています。" + "\r\n" + "\r\n" +
							"最新の情報を取得しますか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							// 選択コード変更後発生イベント
							this.SelectCodeChangedEvent(this, new EventArgs());
						}
					}
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
				{
					string errorMsg = string.Empty;

					foreach (string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								break;
							}
							default:
							{
								errorMsg = strItem;
								break;
							}
						}

						if (errorMsg != "")
						{
							break;
						}
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"データサーバーの接続がタイムアウトになりました。" + "\r\n" + "\r\n" +
						errorMsg,
						status,
						MessageBoxButtons.OK);
				}
				else
				{
					string errorMsg = string.Empty;

					foreach(string strItem in duplicationItemList)
					{
						switch (strItem)
						{
							case "CustomerSubCode":
							{
								break;
							}
							default:
							{
								errorMsg = strItem;
								break;
							}
						}

						if (errorMsg != "")
						{
							break;
						}
					}

					if (errorMsg != "")
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"得意先情報の登録に失敗しました。" + "\r\n" + 
							errorMsg,
							status,
							MessageBoxButtons.OK);
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"得意先情報の登録に失敗しました。",
							status,
							MessageBoxButtons.OK);
					}
				}
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"登録対象データが存在しません。",
					status,
					MessageBoxButtons.OK);
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
        ///// <summary>
        ///// 入力チェック処理（ＵＩクラス＋アクセスクラス）
        ///// </summary>
        ///// <param name="customerInfo"></param>
        ///// <param name="duplicationItemList"></param>
        ///// <param name="itemList"></param>
        ///// <returns></returns>
        //private bool CustomerUnJustDataCheckScreen( CustomerInfo customerInfo, out ArrayList duplicationItemList, out ArrayList itemList )
        //{
        //    ArrayList duplicationItemListUI;
        //    ArrayList itemListUI;
        //    ArrayList duplicationItemListAcs;
        //    ArrayList itemListAcs;

        //    // UI上でしかチェックできない内容
        //    bool statusU = this._inputForm.CustomerUnJustDataCheck( out duplicationItemListUI, out itemListUI );
        //    // アクセスクラスでチェックする内容
        //    bool statusA = this._customerInfoAcs.CustomerUnJustDataCheck( customerInfo, out duplicationItemListAcs, out itemListAcs );

        //    duplicationItemList = duplicationItemListUI;
        //    duplicationItemList.AddRange( duplicationItemListAcs );
        //    itemList = itemListUI;
        //    itemList.AddRange( itemListAcs );

        //    // 共にtrueでないとtrueを返さない
        //    return (statusU && statusA);
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL

		/// <summary>
		/// 論理削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		private int LogicalDelete()
		{
			// Static情報の取得処理
			CustomerInfo customerInfo;
			int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 得意先削除チェック処理
				string message = string.Empty;
				bool checkFlg = false;
				status = this._customerInfoAcs.DeleteCheck(customerInfo.EnterpriseCode, customerInfo.CustomerCode, out message, out checkFlg);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (!checkFlg)
					{
						// Staticメモリ画面情報表示処理
						this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"得意先を削除することが出来ません。" + "\r\n" + "\r\n" + 
							message,
							status,
							MessageBoxButtons.OK);

						return -1;
					}
				}
				else
				{
					return status;
				}

				status = this._customerInfoAcs.LogicalDeleteDBData(this, false, ref customerInfo, true);

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"削除しました。",
						status,
						MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // データ更新イベントコール
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 1;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

					// 削除完了後は、「新規」と同様の処理を実行する

					// StaticMemory初期化処理
					this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

					// Staticメモリ画面情報表示処理
					this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

					// ツールバーボタン有効無効設定処理
					this.ToolBarButtonEnabledSetting();
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"現在、編集中の得意先データは既に更新されています。" + "\r\n" + "\r\n" +
						"最新の情報を取得しますか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult == DialogResult.Yes)
					{
						// 選択コード変更後発生イベント
						this.SelectCodeChangedEvent(this, new EventArgs());
					}
				}
				else if (status == -1)														// 2006.12.15 men add
				{
					// ユーザーによるキャンセルの場合は何も表示しない
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"得意先の削除に失敗しました。",
						status,
						MessageBoxButtons.OK);
				}
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"削除対象データが存在しません。",
					status,
					MessageBoxButtons.OK);
			}

			return status;
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// 完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        private int CompleteDelete()
        {
            // Static情報の取得処理
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 得意先削除チェック処理
                string message = string.Empty;
                bool checkFlg = false;

                status = this._customerInfoAcs.CompleteDeleteCheck(customerInfo.EnterpriseCode, customerInfo.CustomerCode, out message, out checkFlg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!checkFlg)
                    {
                        // Staticメモリ画面情報表示処理
                        this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先を削除することが出来ません。" + "\r\n" + "\r\n" +
                            message,
                            status,
                            MessageBoxButtons.OK);

                        return -1;
                    }
                }
                else
                {
                    return status;
                }

                status = this._customerInfoAcs.CompleteDeleteDBData(this, false, ref customerInfo);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "削除しました。",
                        status,
                        MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // データ更新イベントコール
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 3;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // 削除完了後は、「新規」と同様の処理を実行する

                    // StaticMemory初期化処理
                    this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

                    // Staticメモリ画面情報表示処理
                    this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                    // --- ADD 2008/12/01 -------------------------------->>>>>
                    // ツールバーボタン表示非表示コントロール処理
                    this.ToolBarButtonVisibleControl();
                    // --- ADD 2008/12/01 --------------------------------<<<<<

                    // ツールバーボタン有効無効設定処理
                    this.ToolBarButtonEnabledSetting();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "現在、編集中の得意先データは既に更新されています。" + "\r\n" + "\r\n" +
                        "最新の情報を取得しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // 選択コード変更後発生イベント
                        this.SelectCodeChangedEvent(this, new EventArgs());
                    }
                }
                else if (status == -1)														// 2006.12.15 men add
                {
                    // ユーザーによるキャンセルの場合は何も表示しない
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "得意先の削除に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "削除対象データが存在しません。",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        private int Revive()
        {
            // Static情報の取得処理
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 得意先削除チェック処理
                string message = string.Empty;

                // 復活処理実行
                status = this._customerInfoAcs.RevivalDBData(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "復活しました。",
                        status,
                        MessageBoxButtons.OK);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // データ更新イベントコール
                    if ( this.AfterCustomerRecordUpdate != null )
                    {
                        _customerInfo.LogicalDeleteCode = 0;
                        this.AfterCustomerRecordUpdate( this, CustomerInputAcs.CopyToCustomerSearchRetFromCustomerInfo( this._customerInfo ) );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                    // 復活後は、「新規」と同様の処理を実行する

                    // StaticMemory初期化処理
                    this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

                    // Staticメモリ画面情報表示処理
                    this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                    // --- ADD 2008/12/01 -------------------------------->>>>>
                    // ツールバーボタン表示非表示コントロール処理
                    this.ToolBarButtonVisibleControl();
                    // --- ADD 2008/12/01 --------------------------------<<<<<

                    // ツールバーボタン有効無効設定処理
                    this.ToolBarButtonEnabledSetting();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "現在、編集中の得意先データは既に更新されています。" + "\r\n" + "\r\n" +
                        "最新の情報を取得しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // 選択コード変更後発生イベント
                        this.SelectCodeChangedEvent(this, new EventArgs());
                    }
                }
                else if (status == -1)
                {
                    // ユーザーによるキャンセルの場合は何も表示しない
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "得意先の復活に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "復活対象データが存在しません。",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		private void Retry()
		{
			if (this._customerInfo.UpdateDateTime == DateTime.MinValue)
			{
				// StaticMemory初期化処理
				this._customerInputAcs.InitialStaticMemory(0, this._enterpriseCode, 0, this._loginSectionCode, out this._customerInfo);

			}
			else
			{
				// 得意先データ戻し処理
				this._customerInfoAcs.CopyStaticMemory(1, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

				// Static情報の取得処理
				CustomerInfo customerInfo;
				int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this._customerInfo = customerInfo.Clone();
                //    bool isSetting = this._sectionInfoControl.SetSectionComboEditorValue(this.comboBoxTool_Section, this._customerInfo.MngSectionCode);
                //    if (isSetting) this.MngSectionCodeBroadCast();
                //}
			}

			// Staticメモリ画面情報表示処理
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			// フォーカス初期設定処理
			this.SetInitFocus();
		}

		/// <summary>
		/// データ保存確認処理
		/// </summary>
		/// <returns>0:登録完了 1:登録未完了 2:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ保存確認処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, false, MessageBoxButtons.YesNoCancel);
		}

		/// <summary>
		/// データ保存確認処理
		/// </summary>
		/// <returns>0:登録完了 1:登録未完了 2:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ保存確認処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, bool codeZeroCheck)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, codeZeroCheck, MessageBoxButtons.YesNoCancel);
		}

		/// <summary>
		/// データ保存確認処理
		/// </summary>
		/// <returns>0:登録完了 1:登録未完了 2:キャンセル</returns>
		/// <param name="saveCompletionDialogDisp">保存完了ダイアログ表示フラグ</param>
        /// <param name="messageBoxButtons">メッセージボックス表示ボタン</param>
		/// <remarks>
		/// <br>Note       : データ保存確認処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, MessageBoxButtons messageBoxButtons)
		{
			return this.DataSaveDialogCheck(saveCompletionDialogDisp, false, messageBoxButtons);
		}

		/// <summary>
		/// データ保存確認処理
		/// </summary>
		/// <param name="saveCompletionDialogDisp">保存完了ダイアログ表示フラグ</param>
		/// <param name="codeZeroCheck">コードゼロチェックフラグ</param>
        /// <param name="messageBoxButtons">メッセージボックス表示ボタン</param>
		/// <returns>0:登録完了 1:登録未完了 2:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ保存確認処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int DataSaveDialogCheck(bool saveCompletionDialogDisp, bool codeZeroCheck, MessageBoxButtons messageBoxButtons)
		{
			// 参照画面の場合はチェックしない
			if (this._execMode == EXEC_MODE_VIEWER)
			{
				return SAVE_DIALOG_NO;
			}

			int result = SAVE_DIALOG_YES;

			// 表示中データStaticMemory登録処理
			//this._inputForm.SaveStaticMemoryData(this);

			int status = this._customerInfoAcs.CompareStaticMemory(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			string message = "現在、編集中のデータが存在します。" + "\r\n" + "登録してもよろしいですか？";

			if ((status == 0) && (codeZeroCheck) && (this._customerInfo.CustomerCode == 0))
			{
				status = -1;
				message = "得意先情報が確定していません。" + "\r\n" + "登録してもよろしいですか？";
			}

			if (status != 0)
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_QUESTION,
					this.Name,
					message,
					0,
					messageBoxButtons,
					MessageBoxDefaultButton.Button1);

				switch (dialogResult)
				{
					case (DialogResult.Yes):
					{
						// データ登録処理
						status = this.Save(saveCompletionDialogDisp);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							result = SAVE_DIALOG_YES;
							break;
						}
						else
						{
							result = SAVE_DIALOG_CANCEL;
							break;
						}
					}
					case (DialogResult.No):
					{
						result = SAVE_DIALOG_NO;
						break;
					}
					default:
					{
						result = SAVE_DIALOG_CANCEL;
						break;
					}
				}
			}
			else
			{
				result = SAVE_DIALOG_YES;
			}

			return result;
		}

		/// <summary>
		/// 初期フォーカス設定処理
		/// </summary>
		private void SetInitFocus()
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this._inputForm.SetFocus("CustomerCode");
			}
		}

		/// <summary>
		/// 指定フォーカス設定処理
		/// </summary>
		private void SetFocus(string ddID)
		{
			if (this._execMode == EXEC_MODE_EDIT)
			{
				this._inputForm.SetFocus(ddID);
			}
		}

		/// <summary>
		/// フォームテキスト設定処理
		/// </summary>
		private void SetFormText()
		{
			string kana = string.Empty;

			if (this._customerInfo.CustomerCode == 0)
			{
				kana = "[新規]";
			}
			else
			{
				kana = "[" + this._customerInfo.Kana + "]";
			}

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// タイトル設定
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    this.Text = TITLE + " － " + kana;
            //}
            //else
            //{
            //    this.Text = TITLE + OFFLINE_TITLE + " － " + kana;
            //}

            // タイトル設定
            this.Text = TITLE + " － " + kana;
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// ガイド（F5）表示設定処理
        /// </summary>
        private void SetGuideEnabled(bool enabled)
        {
            this.buttonTool_Guide.SharedProps.Enabled = enabled;
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        /// <summary>
        /// 請求全体設定締日取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求全体設定締日取得を行います。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/12/06</br>
        /// </remarks>
        private int GetBillAllSt()
        {
            int status = this._billAllStAcs.SearchAll(out this._billAllStList, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._customerTotalDayList.Clear();
                foreach (BillAllSt billAllSt in this._billAllStList)
                {
                    // 全社共通の場合
                    if ("0".Equals(billAllSt.SectionCode.Trim()) || "00".Equals(billAllSt.SectionCode.Trim()))
                    {
                        // 締日の取得
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay1);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay2);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay3);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay4);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay5);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay6);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay7);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay8);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay9);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay10);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay11);
                        this._customerTotalDayList.Add(billAllSt.CustomerTotalDay12);
                    }
                }
            }
            return status;
        }
		# endregion

		// ===================================================================================== //
		// 拠点制御ロジック
		// ===================================================================================== //
		# region Section Control Methods
		/// <summary>
		/// 管理拠点コード展開処理
		/// </summary>
		private void MngSectionCodeBroadCast()
		{
            //string mngSectionCode = this.comboBoxTool_Section.ValueList.ValueListItems[this.comboBoxTool_Section.SelectedIndex].DataValue.ToString();

            //if (this._execMode == EXEC_MODE_EDIT)
            //{
            //    if (this._inputForm != null)
            //    {
            //        this._inputForm.MngSectionCode = mngSectionCode;
            //    }
            //}
		}
		# endregion

		// ===================================================================================== //
		// 各コンポーネントイベント処理
		// ===================================================================================== //
		# region Conponent Event Methods
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void PMKHN09000UA_Load(object sender, System.EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			// 起動チェック処理
			try
			{
				this._sectionInfoControl.CheckSectionInfo();
			}
			catch (ApplicationException ex)
			{
				// 警告メッセージを表示する（自拠点情報なし）
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					ex.Message,
					0,
					MessageBoxButtons.OK);

				if (!this.IsMdiChild)
				{
					this.Close();
					return;
				}
			}

			if (this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// OK
			} 
			else if (this._initialReadStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "選択した得意先は既に削除されています。",
                //        0,
                //        MessageBoxButtons.OK);
                //}
                //else
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "オフラインモードの為、処理を行えません。",
                //        0,
                //        MessageBoxButtons.OK);
                //}

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    0,
                    MessageBoxButtons.OK);
                // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				this.Close();
				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先情報の取得に失敗しました。",
					this._initialReadStatus,
					MessageBoxButtons.OK);
				
				this.Close();
				return;
			}
            // --- ADD 2010/12/06 ------------------------------------>>>>>
            // 請求全体設定締日取得処理
            int status = this.GetBillAllSt();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 請求全体設定締日取得に失敗
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "請求全体設定が取得できませんでした。" + "\r\n" + 
                    "請求全体設定を設定してから起動して下さい。",
                    status,
                    MessageBoxButtons.OK);

                this.Close();
                return;
            }
            // --- ADD 2010/12/06 ------------------------------------<<<<<
			// ツールバー用初期ヒント文字列格納用Hashtable設定処理
			this.ToolTipTextTableSetting();

			// 画面初期化処理
			this.InitialSetting();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			// Tab生成処理
			this.TabCreate(this._execMode);

			// 管理拠点コード展開処理
			this.MngSectionCodeBroadCast();

			// Staticメモリ画面情報表示処理
			this._inputForm.ShowStaticMemoryData(this, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode);

			// ツールバーボタン表示非表示コントロール処理
			this.ToolBarButtonVisibleControl();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			// フォーカス初期設定処理
			this.SetInitFocus();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			IAsyncResult iRet = this._initialDataRead.BeginInvoke(new AsyncCallback(this.InitialDataReadCallBack), this._initialDataRead);

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            try
            {
                // DEL 陳健 2014/03/07 ---------------------------------------------------------------------------->>>>>
                //this._customerInputConstructionAcs.FirstDisplayTab = this._customerInputConstructionAcs.InputType;
                // DEL 陳健 2014/03/07 ----------------------------------------------------------------------------<<<<<
            }
            catch
            {
                this._customerInputConstructionAcs.FirstDisplayTab = CustomerInputConstructionAcs.FIRST_DISPLAY_TAB_DEFAULT;
            }
            this._customerInputConstructionAcs.Serialize();
            // --- ADD 2010/08/10 ------------------------------------<<<<<
		}

		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Close_ButtonTool":			// 終了ボタン
				{
                    // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    // データ保存確認処理
                    //    if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL)
                    //    {
                    //        return;
                    //    }
                    //}

                    // データ保存確認処理
                    if (this.DataSaveDialogCheck(false) == SAVE_DIALOG_CANCEL) return;
                    // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 元に戻す処理
                    this.Retry();

					this.Close();
					break;
				}
				case "Save_ButtonTool":				// 保存ボタン
				{
					// 得意先情報登録処理
					this.Save(true);

					break;
				}
				case "Retry_ButtonTool":			// 元に戻すボタン
				{
					if (!this.DataBackDialogCheck(false))
					{
						return;
					}

					// 元に戻す処理
					this.Retry();

                    // フォーカス初期設定処理
                    this.SetInitFocus();

					break;
				}
				case "Setup_ButtonTool":			// ユーザー設定ボタン
				{
					this._customerInputSetUp.ShowDialog();
					break;
				}
				case "New_ButtonTool":				// 新規ボタン
				{
					// データ保存確認処理
					if (this.DataSaveDialogCheck(true) == SAVE_DIALOG_CANCEL)
					{
						return;
					}

					// 新規得意先画面表示処理
					this.CustomerNew(this._enterpriseCode);

					break;
				}
                // --- DEL 2010/08/10 ------------------------------------>>>>>
                //case "Delete_ButtonTool":			// 削除ボタン
                //{
                //    if (!this.buttonTool_Delete.VisibleResolved)
                //    {
                //        return;
                //    }
                //    // データ削除確認処理
                //    if (!this.DataDeleteDialogCheck())
                //    {
                //        return;
                //    }

                //    // 得意先論理削除処理
                //    this.LogicalDelete();

                //    // フォーカス初期設定処理
                //    this.SetInitFocus();

                //    break;
                //}
                // --- DEL 2010/08/10 ------------------------------------<<<<<
				case "Edit_ButtonTool":				// 編集ボタン
				{

					break;
				}
				case "OfflineDataOutput_ButtonTool":	// データ出力
				{
					// データ保存確認処理
					int checkRet = this.DataSaveDialogCheck(true, true, MessageBoxButtons.YesNo);
					 
					if ((checkRet == SAVE_DIALOG_CANCEL) || (checkRet == SAVE_DIALOG_NO))
					{
						return;
					}

					int status = this._customerInfoAcs.WriteOfflineData(this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, sender);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"得意先情報のデータ出力に失敗しました。",
							status,
							MessageBoxButtons.OK);

						return;
					}

					break;
				}
				case "Search_ButtonTool":				// 検索
				{
					if (this.OwnerFormBringToFront != null)
					{
						this.OwnerFormBringToFront(this, new EventArgs());
					}

					break;
				}
				case "Reflect_ButtonTool":				// 伝票に反映
				{
					// データ保存確認処理
					int checkRet = this.DataSaveDialogCheck(false, true, MessageBoxButtons.YesNo);

					if ((checkRet == SAVE_DIALOG_CANCEL) || (checkRet == SAVE_DIALOG_NO))
					{
						return;
					}

					if (this.OwnerFormBringToFront != null)
					{
						this.OwnerFormBringToFront(this, new EventArgs());
					}

					break;
				}
            // --- ADD 2008/09/04 -------------------------------->>>>>
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //case "CompleteDelete_ButtonTool":
            //    {
            //        // データ完全削除前確認処理
            //        if (!this.DataCompleteDeleteDialogCheck())
            //        {
            //            return;
            //        }

            //        // 得意先完全削除処理
            //        this.CompleteDelete();

            //        // フォーカス初期設定処理
            //        this.SetInitFocus();

            //        break;
            //    }
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            case "Delete_ButtonTool":			 // 削除ボタン
            case "CompleteDelete_ButtonTool":    // 完全削除ボタン
                {
                    if (!this.buttonTool_CompleteDelete.VisibleResolved && this.buttonTool_Delete.VisibleResolved)
                    {
                        // データ削除確認処理
                        if (!this.DataDeleteDialogCheck())
                        {
                            return;
                        }

                        // 得意先論理削除処理
                        this.LogicalDelete();
                    }

                    if (this.buttonTool_CompleteDelete.VisibleResolved && !this.buttonTool_Delete.VisibleResolved)
                    {
                        // データ完全削除前確認処理
                        if (!this.DataCompleteDeleteDialogCheck())
                        {
                            return;
                        }

                        // 得意先完全削除処理
                        this.CompleteDelete();
                    }

                    // フォーカス初期設定処理
                    this.SetInitFocus();

                    break;
                }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            case "Revive_ButtonTool":
                {
                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    // logicalcode=0の場合、復活処理できません
                    if (!this.buttonTool_CompleteDelete.VisibleResolved && this.buttonTool_Delete.VisibleResolved)
                    {
                        return;
                    }
                    // --- ADD 2010/08/10 ------------------------------------<<<<<

                    // データ復活前確認処理
                    if (!this.DataReviveDialogCheck())
                    {
                        return;
                    }

                    // 得意先完全削除処理
                    this.Revive();

                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    this._inputForm.OnlineKindCheck();
                    // --- ADD 2010/08/10 ------------------------------------<<<<< 

                    // フォーカス初期設定処理
                    this.SetInitFocus();

                    break;
                }
            // --- ADD 2008/09/04 --------------------------------<<<<< 
            
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
            case "Renewal_ButtonTool":
                {
                    // --- ADD 2010/12/06 ------------------------------------>>>>>
                    // 請求全体設定締日取得処理
                    int status = this.GetBillAllSt();
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 請求全体設定締日取得に失敗
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "請求全体設定が取得できませんでした。" + "\r\n" +
                            "請求全体設定を設定してから起動して下さい。",
                            status,
                            MessageBoxButtons.OK);

                        this.Close();
                        return;
                    }
                    // --- ADD 2010/12/06 ------------------------------------<<<<<
                    // 最新情報取得
                    this._inputForm.Renewal();
                    break;
                }
            // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            case "Guide_ButtonTool":         // ガイドボタン
                {
                    this._inputForm.ExecuteGuide();
                    break;
                }
            // --- ADD 2010/08/10 ------------------------------------<<<<< 
			}
		}

		/// <summary>
		/// ツールバーツール値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "SectionCode_ComboBoxTool":			// 拠点コンボボックス
				{
					// 管理拠点コード展開処理
					this.MngSectionCodeBroadCast();

					break;
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// 値変更イベント
		// ===================================================================================== //
		# region Value Changed Event Method
		/// <summary>
		/// 拠点コンボエディタ選択確定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SectionCode_TComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			// 管理拠点コード展開処理
			this.MngSectionCodeBroadCast();
		}
		# endregion
	}
}
