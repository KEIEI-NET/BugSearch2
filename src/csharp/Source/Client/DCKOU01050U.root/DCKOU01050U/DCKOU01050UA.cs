using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 請求確認画面フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 請求確認画面フォームクラスです。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2007.09.28</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 對馬 大輔</br>
    ///	<br>			・PM.NS 共通修正 得意先・仕入先分離対応</br>
	/// <br></br>
	/// <br>Update Note : 2008.05.29 21024 佐々木 健</br>
	///	<br>			・起動時にエラーが出るので修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.11.21 21024 佐々木 健</br>
    ///	<br>			・請求・支払先は変更できないように修正</br>
    /// <br>Update Note : 2010.01.06 30434 工藤 恵優</br>
    ///	<br>			・請求・支払先の名称は略称を使用する</br>
    /// </remarks>
	public partial class DCKOU01050UA : Form
	{
		#region■Constructor

		/// <summary>
		/// 請求確認画面フォームクラス コンストラクタ
		/// </summary>
		public DCKOU01050UA()
		{
			InitializeComponent();

			// 変数初期化
			this._customerClaimConfAcs = new CustomerClaimConfAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;

			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];

			this._controlScreenSkin = new ControlScreenSkin();

			this._constrolList = new List<Control>();
			this._constrolList.Add(this.tNedit_CustomerCode);
			this._constrolList.Add(this.uLabel_CustomerName);
			this._constrolList.Add(this.tComboEditor_CollectMoneyMonth);
			this._constrolList.Add(this.tDateEdit_AddUpADate);
			this._constrolList.Add(this.uLabel_SuppCTaxLay);
			//this._constrolList.Add(this.uLabel_SuppTtlAmntDspWay);
			this._constrolList.Add(this.uLabel_FractionProc);
			this._constrolList.Add(this.uLabel_OfficeTelNo);
			this._constrolList.Add(this.uLabel_CustomerAgent);
			this._constrolList.Add(this.uLabel_NTimeCalcStDate);
			this._constrolList.Add(this.uLabel_TotalDay);
			this._constrolList.Add(this.tDateEdit_LastAmntDay);
			this._constrolList.Add(this.uLabel_LastTimeDemand);
			this._constrolList.Add(this.uLabel_CreditBalance);
			this._constrolList.Add(this.uLabel_CreditMoney);
			this._constrolList.Add(this.uLabel_OfficeFaxNoDspName);
			this._constrolList.Add(this.uLabel_OfficeTelNoDspName);

			this._titleLabelList = new List<Control>();
			this._titleLabelList.Add(this.uLabel_CustomerCodeTitle);
			this._titleLabelList.Add(this.uLabel_CollectMoneyMonthTitle);
			this._titleLabelList.Add(this.uLabel_AddUpADateTitle);
			this._titleLabelList.Add(this.uLabel_LastAmntDayTitle);
			this._titleLabelList.Add(this.uLabel_LastAmntClaimedTitle);
			this._titleLabelList.Add(this.uLabel_CustomerCodeTitle);
		}

		#endregion

		#region■Private Member

		private CustomerClaimConfAcs _customerClaimConfAcs;						// 請求確認画面アクセスクラス

		private ImageList _imageList16 = null;									// イメージリスト
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;		// 取消ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;		// 取消ボタン
		private DialogResult _dialogRes = DialogResult.Cancel;					// ダイアログリザルト
		private DateTime _defaultAddUpDate = DateTime.MinValue;					// 計上日
		private int _defaultCustomerCode = 0;									// 請求先
		private DateTime _salesDate = DateTime.MinValue;						// 売上(仕入)日
		private CustomerClaimConf _customerClaimConf;							// 請求確認画面（初期表示）
		private ControlScreenSkin _controlScreenSkin;
		private string _addUpSectionCode = "";                                  // 請求計上拠点
		private int _defaultDelayPaymentDiv = 0;                                // 来勘区分
        private string _enterpriseCode;                                         // 企業コード
        private List<Control> _constrolList;
		private List<Control> _titleLabelList;
		private bool _isReadOnlyPayee = false;
		private bool _isReadOnlyAddUpDate = false;

		// 2008.05.29 Update >>>
		//private bool _isLocalDBRead = true;
		private bool _isLocalDBRead = false;
		// 2008.05.29 Update <<<

		#endregion

		#region ■Properties

		/// <summary>請求確認画面プロパティ</summary>
		public CustomerClaimConf CustomerClaimConf
		{
			get { return ( this._customerClaimConfAcs.CustomerClaimConf == null ) ? new CustomerClaimConf() : this._customerClaimConfAcs.CustomerClaimConf; }
		}

		/// <summary>得意先変動情報プロパティ</summary>
		public CustomerChange CustomerChange
		{
			get { return ( this._customerClaimConfAcs.CustomerChange == null ) ? new CustomerChange() : this._customerClaimConfAcs.CustomerChange; }
		}
		/// <summary>支払先読み取り専用プロパティ</summary>
		public bool IsReadOnlyPayee
		{
			get { return _isReadOnlyPayee; }
			set { _isReadOnlyPayee = value; }
		}

		/// <summary>計上日読み取り専用</summary>
		public bool IsReadOnlyAddUpDate
		{
			get { return _isReadOnlyAddUpDate; }
			set { _isReadOnlyAddUpDate = value; }
		}

		/// <summary>ローカルDB読み込みモードプロパティ</summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set 
			{ 
				_isLocalDBRead = value;
				this._customerClaimConfAcs.IsLocalDBRead = value;
			}
		}

		#endregion

		#region ■Public Method

		/// <summary>
		/// 呼出制御処理（計上日入力無し）
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		/// <param name="customerCode">請求先コード</param>
		/// <param name="addUpSectionCd">請求計上拠点コード</param>
		/// <param name="guideType">ガイド起動モード</param>
		/// <returns></returns>
		public DialogResult ShowDialog( IWin32Window owner, int customerCode, string addUpSectionCd, CustomerClaimConfAcs.GuideType guideType )
		{
			return this.ShowDialog(owner, customerCode, addUpSectionCd, DateTime.MinValue, DateTime.MinValue, 0, guideType);
		}

		/// <summary>
		/// 呼出制御処理
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		/// <param name="customerCode">請求先コード</param>
		/// <param name="addUpSectionCd">請求計上拠点コード</param>
		/// <param name="salesDate">売上日・仕入日</param>
		/// <param name="addUpDate">計上日</param>
		/// <param name="delayPaymentDiv">来勘区分</param>
		/// <param name="guideType">ガイド起動モード</param>
		/// <returns></returns>
		public DialogResult ShowDialog( IWin32Window owner, int customerCode, string addUpSectionCd, DateTime salesDate, DateTime addUpDate, int delayPaymentDiv, CustomerClaimConfAcs.GuideType guideType )
		{
			this._defaultCustomerCode = customerCode;
			this._defaultAddUpDate = addUpDate;
			this._salesDate = salesDate;
			this._addUpSectionCode = addUpSectionCd;
			this._defaultDelayPaymentDiv = delayPaymentDiv;

			this._customerClaimConfAcs.Mode = guideType;
			this._customerClaimConfAcs.InitialSearch();

			if (salesDate == DateTime.MinValue)
			{
				this.tDateEdit_AddUpADate.Enabled = false;
				this.tComboEditor_CollectMoneyMonth.Enabled = false;
			}
			else
			{
				this.tDateEdit_AddUpADate.Enabled = true;
				this.tComboEditor_CollectMoneyMonth.Enabled = true;
			}

			// 計上拠点の設定
			this._customerClaimConfAcs.CustomerClaimConf.AddUpSectionCode = this._addUpSectionCode;
			

			CustomerInfo customerInfo;
			//CustSuppli custSuppli; // DEL 2008.04.24
			CustomerChange customerChange;
            Supplier supplier; // ADD 2008.04.24

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this._customerClaimConfAcs.ReadCustomer(this._defaultCustomerCode, out customerInfo, out custSuppli, out customerChange);
            //this._customerClaimConfAcs.Cache(customerInfo, custSuppli, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, false);
            if (this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Claim)
            {
                this._customerClaimConfAcs.ReadCustomer(this._defaultCustomerCode, out customerInfo, out customerChange);
                this._customerClaimConfAcs.CacheCustomer(customerInfo, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, false);
            }
            else
            {
                this._customerClaimConfAcs.ReadSupplier(this._defaultCustomerCode, out supplier);
                this._customerClaimConfAcs.CacheSupplier(supplier, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, false);
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return this.ShowDialog(owner);
		}

		#endregion

		#region ■Private Method

		#region 各コントロールイベント処理

		/// <summary>
		/// 画面Loadイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Form1_Load( object sender, EventArgs e )
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			//// 画面初期情報設定処理
			this.SetInitialInput();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
		{
			switch (e.Tool.Key)
			{
				// 終了
				case "ButtonTool_Close":
					{
						this.SetDialogRes(DialogResult.Cancel);
						this.CloseForm();
						break;
					}
				// 確定
				case "ButtonTool_Decision":
					{
						// 確定処理
						if (DecisionProc())
						{
							this.SetDialogRes(DialogResult.OK);
							this.CloseForm();
						}
						break;
					}
				// クリア
				case "ButtonTool_Clear":
					{
						// 元に戻す処理
						this._customerClaimConfAcs.CustomerClaimConf = this._customerClaimConf.Clone();
						this.ClearDisplay();
						this.SetDisplayInfo();

						break;
					}
				// ガイド
				case "ButtonTool_Guide":
					{
						this.uButton_StockCustomerGuide_Click(this.uButton_StockCustomerGuide, new EventArgs());
						break;
					}
			}
		}

		/// <summary>
		/// ステータスバーメッセージ表示イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="message">メッセージ</param>
		private void SetStatusBarMessage( object sender, string message )
		{
			this.uStatusBar_Main.Panels[0].Text = message;
		}

		/// <summary>
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。
		///	                 この処理は、システムが提供するスレッド プール
		///	                 スレッドで実行されます。</br>
		/// </remarks>
		private void Initial_Timer_Tick( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;

			this._customerClaimConf = this._customerClaimConfAcs.CustomerClaimConf.Clone();
			this.SetInitialInput();

            // 2008.11.21 Update >>>
			//this.tNedit_CustomerCode.Focus();
            //this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode);
            this.tComboEditor_CollectMoneyMonth.Focus();
            this.SettingGuideButtonToolEnabled(this.tComboEditor_CollectMoneyMonth);
            // 2008.11.21 Update <<<
		}

		/// <summary>
		/// フォーカス移動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			SetStatusBarMessage(this, "");
			bool canChangeFocus = true;

			// 名称取得 ============================================ //
			switch (e.PrevCtrl.Name)
			{
				#region ●仕入先
				// 仕入先
				case "tNedit_CustomerCode":
					{
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //int code = this.tNedit_CustomerCode.GetInt();

                        //if (this._customerClaimConfAcs.CustomerClaimConf.CustomerCode != code)
                        //{
                        //    CustomerInfo customerInfo;
                        //    CustSuppli custSuppli;
                        //    CustomerChange customerChange;
                        //    int status = this._customerClaimConfAcs.ReadCustomer(code, out customerInfo, out custSuppli, out customerChange);

                        //    // 読み込みOK
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        // 支払先モードで、仕入先が取得できなかった場合
                        //        if (( this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Payment ) &&
                        //            ( custSuppli == null ))
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //                this.Name,
                        //                "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        //                status,
                        //                MessageBoxButtons.OK);
                        //            canChangeFocus = false;
                        //        }
                        //        // 請求先モードで、業販先以外を指定した場合
                        //        else if (( this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Claim ) &&
                        //                 ( customerInfo == null ))
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //                this.Name,
                        //                "選択した得意先は選択出来ません。",
                        //                status,
                        //                MessageBoxButtons.OK);
                        //            canChangeFocus = false;
                        //        }
                        //        else
                        //        {
                        //            this._customerClaimConfAcs.Cache(customerInfo, custSuppli, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
                        //            SetDisplayInfo();
                        //        }
                        //    }
                        //    // データ無し
                        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //    {
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            string.Format("{0}が存在しません。", GetTitleString(this._customerClaimConfAcs.Mode)),
                        //            -1,
                        //            MessageBoxButtons.OK);

                        //        canChangeFocus = false;
                        //    }
                        //    // その他読み込み失敗
                        //    else
                        //    {
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            string.Format("{0}の取得に失敗しました。", GetTitleString(this._customerClaimConfAcs.Mode)),
                        //            status,
                        //            MessageBoxButtons.OK);

                        //        canChangeFocus = false;
                        //    }

                        //}
                        //if (!canChangeFocus)
                        //{
                        //    this.tNedit_CustomerCode.SetInt(this._customerClaimConfAcs.CustomerClaimConf.CustomerCode);
                        //}

                        int code = this.tNedit_CustomerCode.GetInt();

                        if (this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Claim)
                        {
                            if (this._customerClaimConfAcs.CustomerClaimConf.CustomerCode != code)
                            {
                                CustomerInfo customerInfo;
                                CustomerChange customerChange;
                                int status = this._customerClaimConfAcs.ReadCustomer(code, out customerInfo, out customerChange);

                                // 読み込みOK
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 請求先モードで、業販先以外を指定した場合
                                    if (customerInfo == null)
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "選択した得意先は選択出来ません。",
                                            status,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                    }
                                    else
                                    {
                                        this._customerClaimConfAcs.CacheCustomer(customerInfo, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
                                        SetDisplayInfo();
                                    }
                                }
                                // データ無し
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        string.Format("{0}が存在しません。", GetTitleString(this._customerClaimConfAcs.Mode)),
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                // その他読み込み失敗
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        string.Format("{0}の取得に失敗しました。", GetTitleString(this._customerClaimConfAcs.Mode)),
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }

                            }
                        }
                        else
                        {
                            if (this._customerClaimConfAcs.CustomerClaimConf.CustomerCode != code)
                            {
                                Supplier supplier;
                                int status = this._customerClaimConfAcs.ReadSupplier(code, out supplier);

                                // 読み込みOK
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 支払先モードで、仕入先が取得できなかった場合
                                    if (supplier == null)
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "選択した仕入先は選択出来ません。",
                                            status,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                    }
                                    else
                                    {
                                        this._customerClaimConfAcs.CacheSupplier(supplier, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
                                        SetDisplayInfo();
                                    }
                                }
                                // データ無し
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        string.Format("{0}が存在しません。", GetTitleString(this._customerClaimConfAcs.Mode)),
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                // その他読み込み失敗
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        string.Format("{0}の取得に失敗しました。", GetTitleString(this._customerClaimConfAcs.Mode)),
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }

                            }
                        }


                        if (!canChangeFocus)
                        {
                            this.tNedit_CustomerCode.SetInt(this._customerClaimConfAcs.CustomerClaimConf.CustomerCode);
                        }
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

						break;

					}
				#endregion

				#region ●計上日
				// 計上日
				case "tDateEdit_AddUpADate":
					{

						DateTime value = tDateEdit_AddUpADate.GetDateTime();

						if (value < this._salesDate)
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								string.Format("{0}は{1}より大きい日付にして下さい。", uLabel_AddUpADateTitle.Text, GetDateTitleString(this._customerClaimConfAcs.Mode)),
								-1,
								MessageBoxButtons.OK);
							canChangeFocus = false;
						}
						else if (value != this._customerClaimConfAcs.CustomerClaimConf.AddUpADate)
						{
							int collectMoneyCode = CustomerClaimConfAcs.CalcCollectMoneyCode(this._customerClaimConfAcs.CustomerClaimConf.TotalDay, this._salesDate, value);

							if (collectMoneyCode > 9)
							{
								TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									string.Format("{0}が１０ヶ月以降になる為指定出来ません。", this.uLabel_CollectMoneyMonthTitle.Text),
									-1,
									MessageBoxButtons.OK);
								canChangeFocus = false;
							}
							else
							{
								this._customerClaimConfAcs.CustomerClaimConf.CollectMoneyCode = collectMoneyCode;
								this._customerClaimConfAcs.CustomerClaimConf.AddUpADate = value;
								SetDisplayInfo();
							}
						}

						if (!canChangeFocus)
						{
							this.tDateEdit_AddUpADate.SetDateTime(this._customerClaimConfAcs.CustomerClaimConf.AddUpADate);
						}

						break;
					}
				#endregion

				#region ●区分
				// 区分
				case "tComboEditor_CollectMoneyMonth":
					{
						tComboEditor_CollectMoneyMonth.SelectionChangeCommitted -= this.tComboEditor_CollectMoneyMonth_SelectionChangeCommitted;

						int code = ValueToInt(tComboEditor_CollectMoneyMonth.Value);

						if (code != this._customerClaimConfAcs.CustomerClaimConf.CollectMoneyCode)
						{
							this.CollectMoneyMonth_Change(code);
						}


						tComboEditor_CollectMoneyMonth.SelectionChangeCommitted += this.tComboEditor_CollectMoneyMonth_SelectionChangeCommitted;
						break;
					}
				#endregion
			}

			if (!canChangeFocus)
			{
				e.NextCtrl = e.PrevCtrl;
			}

			if (( e.NextCtrl != null ) && ( e.NextCtrl.TabStop ))
			{
				this.SettingGuideButtonToolEnabled(e.NextCtrl);
			}
		}

		/// <summary>
		/// ガイドボタンのEnabledプロパティを設定します。
		/// </summary>
		/// <param name="control">対象コントロール</param>
		private void SettingGuideButtonToolEnabled( Control control )
		{
			if (control == null) return;

			Control target = control;
			if (control.Parent != null)
			{
				if (( control.Parent is Broadleaf.Library.Windows.Forms.TNedit ) || ( control.Parent is Broadleaf.Library.Windows.Forms.TEdit ))
				{
					target = control.Parent;
				}
			}

			if (control == this.tNedit_CustomerCode)
			{
				this._guideButton.SharedProps.Enabled = !this._isReadOnlyPayee;
			}
			else
			{
				this._guideButton.SharedProps.Enabled = false;
			}
		}

		/// <summary>
		/// フォーム終了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON01320UA_FormClosed( object sender, FormClosedEventArgs e )
		{
			DialogResult = _dialogRes;
		}

		/// <summary>
		/// 仕入先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_StockCustomerGuide_Click( object sender, EventArgs e )
		{
			// UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;

            //if (this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Payment)
            //{
            //    searchMode = SFTOK01370UA.SEARCHMODE_SUPPLIER;
            //}

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(searchMode, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            if (this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Claim)
            {
                PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_AND_EDIT);
                customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);
            }
            else
            {
                SupplierAcs supplierAcs = new SupplierAcs();
                Supplier supplier;
                int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SupplierSearchForm_SupplierSelect(supplier);
                }
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;
        //    CustomerChange customerChange;

        //    int status = this._customerClaimConfAcs.ReadCustomer(customerSearchRet.CustomerCode, out customerInfo, out custSuppli, out customerChange);

        //    // 読み込みOK
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 支払先モードで、仕入先が取得できなかった場合
        //        if (( this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Payment ) && ( custSuppli == null ))
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //                status,
        //                MessageBoxButtons.OK);
        //        }
        //        // 請求先モードで、業販先以外を指定した場合
        //        else if (( this._customerClaimConfAcs.Mode == CustomerClaimConfAcs.GuideType.Claim ) && ( customerInfo == null ))
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "選択した得意先は選択出来ません。",
        //                status,
        //                MessageBoxButtons.OK);
        //        }
        //        else
        //        {
        //            this._customerClaimConfAcs.Cache(customerInfo, custSuppli, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
        //            SetDisplayInfo();
        //        }

        //    }
        //    // データ無し
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            string.Format("選択した{0}は既に削除されています。", GetTitleString(this._customerClaimConfAcs.Mode)),
        //            -1,
        //            MessageBoxButtons.OK);
        //    }
        //}
        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerChange customerChange;

            int status = this._customerClaimConfAcs.ReadCustomer(customerSearchRet.CustomerCode, out customerInfo, out customerChange);

            // 読み込みOK
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 請求先モードで、業販先以外を指定した場合
                if (customerInfo == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した得意先は選択出来ません。",
                        status,
                        MessageBoxButtons.OK);
                }
                else
                {
                    this._customerClaimConfAcs.CacheCustomer(customerInfo, customerChange, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
                    SetDisplayInfo();
                }

            }
            // データ無し
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    string.Format("選択した{0}は既に削除されています。", GetTitleString(this._customerClaimConfAcs.Mode)),
                    -1,
                    MessageBoxButtons.OK);
            }
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplier">仕入先情報データクラス</param>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            if (supplier == null) return;

            Supplier tempSupplier;
           
            int status = this._customerClaimConfAcs.ReadSupplier(supplier.SupplierCd, out tempSupplier);

            // 読み込みOK
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 支払先モードで、仕入先が取得できなかった場合
                if (tempSupplier == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は選択出来ません。",
                        status,
                        MessageBoxButtons.OK);
                }
                else
                {
                    this._customerClaimConfAcs.CacheSupplier(tempSupplier, this._salesDate, this._defaultAddUpDate, this._defaultDelayPaymentDiv, true);
                    SetDisplayInfo();
                }

            }
            // データ無し
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    string.Format("選択した{0}は既に削除されています。", GetTitleString(this._customerClaimConfAcs.Mode)),
                    -1,
                    MessageBoxButtons.OK);
            }            
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 集金月（支払月）コンボエディタ選択確定後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_CollectMoneyMonth_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int code = ValueToInt(tComboEditor_CollectMoneyMonth.Value);
			CollectMoneyMonth_Change(code);
		}

		# endregion

		/// <summary>
		/// 画面初期情報設定処理
		/// </summary>
		private void SetInitialInput()
		{
			// ヘッダ情報クリア処理
			this.ClearDisplay();

			// ヘッダ初期表示処理
			this.SetDisplayInfo();
		}


		/// <summary>
		/// 画面ヘッダクリア処理
		/// </summary>
		private void ClearDisplay()
		{
			ComponentBlanketControl.Clear(this._constrolList);

			ComponentBlanketControl.BeginUpdate(this._titleLabelList);
			try
			{
				switch (this._customerClaimConfAcs.Mode)
				{
					case CustomerClaimConfAcs.GuideType.Claim:
						{
							this.Text = "請求先確認";
							this.uLabel_CustomerCodeTitle.Text = "請求先";
							this.uLabel_CollectMoneyMonthTitle.Text = "請求月";
							this.uLabel_AddUpADateTitle.Text = "計上日";
							this.uLabel_LastAmntDayTitle.Text = "前回請求日";
							this.uLabel_LastAmntClaimedTitle.Text = "請求残高";
							this.groupBox_CreditInfo.Visible = true;
							break;
						}
					case CustomerClaimConfAcs.GuideType.Payment:
						{
							this.Text = "支払先確認";
							this.uLabel_CustomerCodeTitle.Text = "支払先";
							this.uLabel_CollectMoneyMonthTitle.Text = "支払月";
							this.uLabel_AddUpADateTitle.Text = "計上日";
							this.uLabel_LastAmntDayTitle.Text = "前回支払日";
							this.uLabel_LastAmntClaimedTitle.Text = "支払残高";
							this.groupBox_CreditInfo.Visible = false;
							break;
						}
				}
			}
			finally
			{
				ComponentBlanketControl.EndUpdate(this._titleLabelList);
			}
		}

		/// <summary>
		/// 画面ヘッダ表示処理
		/// </summary>
		private void SetDisplayInfo()
		{
			if (this._customerClaimConfAcs.CustomerClaimConf.CustomerCode == 0) return;
			
			ComponentBlanketControl.BeginUpdate(this._constrolList);

			try
			{
				this.tComboEditor_CollectMoneyMonth.Value = this._customerClaimConfAcs.CustomerClaimConf.CollectMoneyCode;										// 集金月
				this.tDateEdit_AddUpADate.SetDateTime(this._customerClaimConfAcs.CustomerClaimConf.AddUpADate);													// 請求日
                this.tNedit_CustomerCode.SetInt(this._customerClaimConfAcs.CustomerClaimConf.CustomerCode);														// 請求先コード

                // DEL 2010/01/06 MANTIS対応[14858]：請求・支払先の名称は略称を使用する ---------->>>>>
                // this.uLabel_CustomerName.Text = this._customerClaimConfAcs.CustomerClaimConf.Name + " " + this._customerClaimConfAcs.CustomerClaimConf.Name2;	// 得意先名称
                // DEL 2010/01/06 MANTIS対応[14858]：請求・支払先の名称は略称を使用する ----------<<<<<
                // ADD 2010/01/06 MANTIS対応[14858]：請求・支払先の名称は略称を使用する ---------->>>>>
                this.uLabel_CustomerName.Text = this._customerClaimConfAcs.CustomerClaimConf.CustomerSnm;
                // ADD 2010/01/06 MANTIS対応[14858]：請求・支払先の名称は略称を使用する ----------<<<<<

				this.tDateEdit_LastAmntDay.SetDateTime(this._customerClaimConfAcs.CustomerClaimConf.LastCAddUpUpdDate);											// 前回請求日
				this.uLabel_LastTimeDemand.Text = this._customerClaimConfAcs.CustomerClaimConf.LastTimeDemand.ToString("#,##0");								// 前回請求額
				this.uLabel_TotalDay.Text = this._customerClaimConfAcs.CustomerClaimConf.TotalDay.ToString();													// 締日
				this.uLabel_SuppCTaxLay.Text = DCKOU01050UA.GetConsTaxLayMethodNm(this._customerClaimConfAcs.CustomerClaimConf.ConsTaxLayMethod);				// 転嫁方式
				//this.uLabel_SuppTtlAmntDspWay.Text = DCKOU01050UA.GetTotalAmountDispWay(this._customerClaimConfAcs.CustomerClaimConf.TotalAmountDispWayCd);		// 総額表示方法
				this.uLabel_FractionProc.Text = DCKOU01050UA.GetFractionProc(this._customerClaimConfAcs.CustomerClaimConf.TaxFractionProcCd);					// 消費税転嫁方式
				this.uLabel_OfficeTelNoDspName.Text = this._customerClaimConfAcs.CustomerClaimConf.OfficeTelNoDspName;
				this.uLabel_OfficeFaxNoDspName.Text = this._customerClaimConfAcs.CustomerClaimConf.OfficeFaxNoDspName;
				this.uLabel_OfficeTelNo.Text = this._customerClaimConfAcs.CustomerClaimConf.OfficeTelNo;
				this.uLabel_OfficeFaxNo.Text = this._customerClaimConfAcs.CustomerClaimConf.OfficeFaxNo;
				// 2008.05.29 Update >>>
				//this.uLabel_CreditBalance.Text = ( (decimal)( this._customerClaimConfAcs.CustomerChange.CreditMoney - this._customerClaimConfAcs.CustomerChange.PrsntAccRecBalance ) ).ToString("#,##0");
				//this.uLabel_CreditMoney.Text = this._customerClaimConfAcs.CustomerChange.CreditMoney.ToString("#,##0");
				if (this.groupBox_CreditInfo.Visible)
				{
					this.uLabel_CreditBalance.Text = ( (decimal)( this._customerClaimConfAcs.CustomerChange.CreditMoney - this._customerClaimConfAcs.CustomerChange.PrsntAccRecBalance ) ).ToString("#,##0");
					this.uLabel_CreditMoney.Text = this._customerClaimConfAcs.CustomerChange.CreditMoney.ToString("#,##0");
				}
				// 2008.05.29 Update <<<
				this.uLabel_CustomerAgent.Text = this._customerClaimConfAcs.CustomerClaimConf.CustomerAgent;
				this.uLabel_NTimeCalcStDate.Text = this._customerClaimConfAcs.CustomerClaimConf.NTimeCalcStDate.ToString("##");

                //this.tNedit_CustomerCode.Enabled = !this._isReadOnlyPayee;        // 2008.11.21 Del
				//this.uButton_StockCustomerGuide.Enabled = !this._isReadOnlyPayee;
				this.tDateEdit_AddUpADate.Enabled = !this._isReadOnlyAddUpDate;
				this.tComboEditor_CollectMoneyMonth.Enabled = !this._isReadOnlyAddUpDate;

				this.panel_NTimeCalcStDateHide.Visible = ( this._customerClaimConfAcs.CustomerClaimConf.NTimeCalcStDate == 0 ) ? true : false;
			}
			finally
			{
				
				ComponentBlanketControl.EndUpdate(this._constrolList);
			}
		}

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

			this.uButton_StockCustomerGuide.ImageList = this._imageList16;
			this.uButton_StockCustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
		}

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
		/// <br>Programmer	: 21024　佐々木 健</br>
		/// <br>Date		: 2007.09.28</br>
		/// </remarks>
		private int ValueToInt( object sorce )
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
		/// 画面終了処理
		/// </summary>
		private void CloseForm()
		{
			this.Close();
		}

		/// <summary>
		/// ダイアログリザルト設定処理
		/// </summary>
		/// <param name="dialogRes">ダイアログリザルト</param>
		private void SetDialogRes( DialogResult dialogRes )
		{
			_dialogRes = dialogRes;
		}

		/// <summary>
		/// 「確定」ボタン表示変更処理
		/// </summary>
		/// <param name="enableSet">表示設定(true:表示、false:非表示)</param>
		private void ChangeDecisionButtonEnable( bool enableSet )
		{
			this._decisionButton.SharedProps.Enabled = enableSet;
		}

		/// <summary>
		/// 確定処理
		/// </summary>
		private bool DecisionProc()
		{

			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				control.Focus();
				this.SettingGuideButtonToolEnabled(this.ActiveControl);
				return false;
			}

			this._defaultCustomerCode = this.tNedit_CustomerCode.GetInt();
			this._defaultAddUpDate = this.tDateEdit_AddUpADate.GetDateTime();
			this._defaultDelayPaymentDiv = ValueToInt(tComboEditor_CollectMoneyMonth.Value);
			return true;
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

			if (tNedit_CustomerCode.GetInt() == 0)
			{
				control = this.tNedit_CustomerCode;
				message = this.uLabel_CustomerCodeTitle.Text + "を入力して下さい。";
				result = false;
			}
			// 計上日入力有りの場合
			else if (tDateEdit_AddUpADate.Enabled)
			{
				if (tDateEdit_AddUpADate.GetDateTime() == DateTime.MinValue)
				{
					control = this.tDateEdit_AddUpADate;
					message = this.uLabel_AddUpADateTitle.Text + "を入力して下さい。";
					result = false;
				}
				else if (( tDateEdit_LastAmntDay.GetDateTime() != DateTime.MinValue ) && ( tDateEdit_AddUpADate.GetDateTime() <= tDateEdit_LastAmntDay.GetDateTime() ))
				{
					control = this.tDateEdit_AddUpADate;
					message = "計上日が前回支払締日以前になっています。";
					result = false;
				}
			}
			return result;
		}

		/// <summary>
		/// 集金月（支払月）変更時処理
		/// </summary>
		/// <param name="code">集金月(コンボボックスのインデックス）</param>
		private void CollectMoneyMonth_Change( int code )
		{
			this._customerClaimConfAcs.CustomerClaimConf.CollectMoneyCode = code;

			DateTime addUpDate = CustomerClaimConfAcs.CalcAddUpDate(code, this._customerClaimConfAcs.CustomerClaimConf.TotalDay, this._salesDate);

			this._customerClaimConfAcs.CustomerClaimConf.AddUpADate = addUpDate;
			tDateEdit_AddUpADate.SetDateTime(addUpDate);
		}

		#endregion

		# region ■Static Method
		/// <summary>
		/// タイトル取得
		/// </summary>
		/// <param name="guideType">ガイドモード</param>
		/// <returns>タイトル（得意先or仕入先)</returns>
		private static string GetTitleString( CustomerClaimConfAcs.GuideType guideType )
		{
			switch (guideType)
			{
				case CustomerClaimConfAcs.GuideType.Claim:
					return "得意先";
				case CustomerClaimConfAcs.GuideType.Payment:
					return "仕入先";
				default:
					return "";
			}
		}

		/// <summary>
		/// タイトル取得
		/// </summary>
		/// <param name="guideType">ガイドモード</param>
		/// <returns>タイトル（売上日or仕入日)</returns>
		private static string GetDateTitleString( CustomerClaimConfAcs.GuideType guideType )
		{
			switch (guideType)
			{
				case CustomerClaimConfAcs.GuideType.Claim:
					return "売上日";
				case CustomerClaimConfAcs.GuideType.Payment:
					return "仕入日";
				default:
					return "";
			}
		}

		/// <summary>
		/// 総額表示方法取得
		/// </summary>
		/// <param name="totalAmountDispWayCd">総額表示区分</param>
		/// <returns>総額表示方法</returns>
		private static string GetTotalAmountDispWay( int totalAmountDispWayCd )
		{
			switch (totalAmountDispWayCd)
			{
				case 0:
					return "総額表示しない";
				case 1:
					return "総額表示する";
				default:
					return "";
			}
		}
		/// <summary>
		/// 消費税転嫁方式名称取得
		/// </summary>
		/// <param name="consTaxLayMethod">消費税転嫁方式コード</param>
		/// <returns>消費税転嫁方式名称</returns>
		private static string GetConsTaxLayMethodNm( int consTaxLayMethod )
		{
			switch (consTaxLayMethod)
			{
				case 0:
					return "伝票単位";
				case 1:
					return "明細単位";
				case 2:
					return "請求親";
				case 3:
					return "請求子";
				case 9:
					return "非課税";
				default:
					return "";
			}
		}

		/// <summary>
		/// 端数処理方法名称取得
		/// </summary>
		/// <param name="fractionProcCd">端数処理区分</param>
		/// <returns>端数処理方法</returns>
		private static string GetFractionProc( int fractionProcCd )
		{
			switch (fractionProcCd)
			{
				case 1:
					return "切捨て";
				case 2:
					return "四捨五入";
				case 3:
					return "切上";
				default:
					return "";
			}
		}
		#endregion

        private void tNedit_CustomerCode_ValueChanged(object sender, EventArgs e)
        {

        }

	}

	#region ■コンポーネント一括制御用のクラス

	/// <summary>
	/// コンポーネント一括制御
	/// </summary>
	internal class ComponentBlanketControl
	{
		/// <summary>
		/// BeginUpdate一括実行
		/// </summary>
		/// <param name="controlList">対象コントロールリスト</param>
		public static void BeginUpdate( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				MethodInfo method = target.GetType().GetMethod("BeginUpdate", new Type[0]);

				if (method != null)
				{
					method.Invoke(target, null);
				}
			}
		}

		/// <summary>
		/// EndUpdate一括実行
		/// </summary>
		/// <param name="controlList">対象コントロールリスト</param>
		public static void EndUpdate( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				MethodInfo method = target.GetType().GetMethod("EndUpdate", new Type[0]);

				if (method != null)
				{
					method.Invoke(target, null);
				}
			}
		}

		/// <summary>
		/// 一括クリア
		/// </summary>
		/// <param name="controlList">対象コントロールリスト</param>
		public static void Clear( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				if (target is TEdit)
				{
					( (TEdit)target ).Text = "";
				}
				else if (target is TNedit)
				{
					( (TNedit)target ).SetValue(0);
				}
				else if (target is TDateEdit)
				{
					( (TDateEdit)target ).SetDateTime(DateTime.MinValue);
				}
				else if (target is Infragistics.Win.Misc.UltraLabel)
				{
					( (Infragistics.Win.Misc.UltraLabel)target ).Text = "";
				}
				else if (target is TComboEditor)
				{
					( (TComboEditor)target ).SelectedIndex = -1;
				}

			}
		}

		/// <summary>
		/// Enableプロパティ一括制御
		/// </summary>
		/// <param name="controlList">対象コントロールリスト</param>
		/// <param name="enabled">Enabledプロパティ値</param>
		public static void SetEnabled( List<Control> controlList, bool enabled )
		{
			foreach (Control target in controlList)
			{
				PropertyInfo property = target.GetType().GetProperty("Enabled", typeof(bool));

				if (property != null)
				{
					property.SetValue(target, enabled, null);
				}
			}
		}
	}
	#endregion
}