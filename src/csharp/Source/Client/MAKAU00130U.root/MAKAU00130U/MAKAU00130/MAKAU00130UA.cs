using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 月次更新メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上月次更新/仕入月次更新の各子画面を制御するメインフレームです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.03.07</br>
	/// <br>Update Date: </br>
    /// <br>UpdateNote   : 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>UpdateNote   : 2011/04/11 liyp 月次更新にタイマーをつけて、処理開始時間を指定可能とする</br>
	/// </remarks>
	public partial class MAKAU00130UA : Form
	{
		//----------------------------------------------------------------------------------------------------
		//  コンストラクタ
		//----------------------------------------------------------------------------------------------------
		# region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAKAU00130UA()
		{
			InitializeComponent();

            /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
            if (Program.Param[0] == "1")
            {
                // 売上月次更新
                MAKAU00138UA.GetSection += new MAKAU00138UA.GetSectionEventHandler(this.GetSection);
            }
            else if (Program.Param[0] == "2")
            {
                // 仕入月次更新
                MAKAU00139UA.GetSection += new MAKAU00139UA.GetSectionEventHandler(this.GetSection);
            }

            // 製番在庫クラス初期化
            this._custDmdPrcAcs = new CustDmdPrcAcs();
               --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        }
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  プライベイトメンバ
		//----------------------------------------------------------------------------------------------------
		# region プライベイトメンバ

        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
        /// 製番在庫データアクセスクラス
        private CustDmdPrcAcs _custDmdPrcAcs = null;
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

        /// <summary>企業コード</summary>
		private string _enterpriseCode;

        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
		/// <summary>自拠点コード</summary>
		private string _ownSectionCode;
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

        private Employee _employee;

        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
		/// <summary>拠点オプション有効フラグ</summary>
		private bool _optSection = false;
        
        /// <summary>表示モード</summary>
		private int _dispMode;
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

        /// <summary>スライダーパネルクラス(Form型)</summary>
		private SFCMN00221UA _superSlider;
		/// <summary>子画面制御クラス</summary>
		private FormControlInfo _formControlInfo;

        private MAKAU00138UA _MAKAU00138UA = new MAKAU00138UA();

        private MAKAU00139UA _MAKAU00139UA = new MAKAU00139UA();
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  定数宣言
		//----------------------------------------------------------------------------------------------------
		# region 定数宣言
		/// <summary>先頭タブKEY名称</summary>
		private const string NO0_TOP_TAB = "TOP_TAB";
		/// <summary>タブなし</summary>
		private const string NO_TAB = "";

		/// <summary>PGID</summary>
		private const string ctPGID = "MAZAI04370U";
		# endregion

        /// <summary>
        /// 担当者リスト取得
        /// </summary>
        /// <returns></returns>
        public Employee GetEmployee()
        {
            return _employee;
        }

        #region DEL 2008/08/07 使用していないのでコメントアウト
        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点取得
        /// </summary>
        public string GetSection()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            return (string)cmbOwnSection.Value;
        }
        public string GetSectionNm()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            return (string)cmbOwnSection.SelectedItem.ToString();
        }
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/07 使用していないのでコメントアウト

        //----------------------------------------------------------------------------------------------------
		//  コントロールイベントハンドラ
		//----------------------------------------------------------------------------------------------------
		# region コントロールイベントハンドラ
		/// <summary>
		/// フォームロードイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームがロードされた時に発動します</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void MAKAU00130UA_Load(object sender, EventArgs e)
		{
			try
			{
				if (LoginInfoAcquisition.EnterpriseCode != null)
				{
					this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
				}

                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
				// 拠点情報の取得
				SecInfoSet secInfoSet;
				SecInfoAcs secInfoAcs = new SecInfoAcs();
                
				// 自社情報取得
				secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

				// 拠点コンボボックスに拠点リストを設定する
				Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
				foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = secInfoSetWk.SectionCode;
					secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
					secInfoList.ValueListItems.Add(secInfoItem);
				}
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"]).ValueList = secInfoList;

				// 本社機能無しor拠点オプション無しなら拠点を変更できないようにする
				this._optSection = !((secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) || (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0));
				this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                
                // ツールバーの有効無効設定
				this.ToolbarEnableChange(0);

                // ツールバーの設定
                this.SettingToolbar();

                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
                // 締取消有効・無効
                if (Program.Param[0] == "2")
                {
                    //仕入月次更新
                }
                else if (Program.Param[0] == "1")
                {
                    //売上月次更新 (無効化する)
                    ToolbarsManager_Main.Tools["ButtonTool_Bns"].SharedProps.Enabled = false;
                }
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                
                //                //イベント関連付け
//                CustDmdPrcAcs.GetEmployeeEv += new CustDmdPrcAcs.GetEmployeeEventHandler(this.GetEmployee);

                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
                CustDmdPrcAcs CustDmdPrcAcs = new CustDmdPrcAcs();

                string sectionCode = "";
                Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"];
                if (cmbOwnSection.Value is string)
                {
                    sectionCode = (string)cmbOwnSection.Value;
                }

                // 自拠点情報を設定する
                cmbOwnSection.Value = secInfoSet.SectionCode;
                this._ownSectionCode = secInfoSet.SectionCode;
                // 拠点情報を表示する
                this.ShowToolBarSection();
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

                // フォーム制御テーブルを生成する
				this.FormControlInfoCreate("");

				// 先頭タブ生成
				this.TabCreate(NO0_TOP_TAB);

                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
				// 先頭タブアクティブ化
				this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

				// 画面に表示した内容を初期値にする
				this.StoreTabChild();
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

                if (_formControlInfo != null)
                {
                    if (Program.Param[0] == "1")
                    {
                        MAKAU00138UA MAKAU00138UA = new MAKAU00138UA();
                        MAKAU00138UA = (MAKAU00138UA)_formControlInfo.Form;
                        //                    MAKAU00138UA.Section_tNedit.Text = GetSectionNm();

                        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
                        MAKAU00138UA.Section_tEdit.Text = GetSectionNm();
                        MAKAU00138UA._sectionCd = GetSection();
                           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/

                        MAKAU00138UA.SetFocus();
                    }
                    else if (Program.Param[0] == "2")
                    {
                        MAKAU00139UA MAKAU00139UA = new MAKAU00139UA();
                        MAKAU00139UA = (MAKAU00139UA)_formControlInfo.Form;
                        //                    MAKAU00138UA.Section_tNedit.Text = GetSectionNm();

                        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
                        MAKAU00139UA.Section_tEdit.Text = GetSectionNm();
                        MAKAU00139UA._sectionCd = GetSection();
                           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                        
                        MAKAU00139UA.SetFocus();
                    }
                }
			}
			finally
			{
				// 起動用スプラッシュウィンドウ(Close)
				Program.SplashWindow.Close();
			}

		}

		/// <summary>
		/// フォームClose前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが終了する前に発生します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void MAKAU00130UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// TAB子画面が展開されていない→exit
			if (this.TabControl_Main.Tabs.Count <= 0) return;

            /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
			// 編集画面の内容をStatic領域にストアする
			this.StoreTabChild();
               --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
            
            // スライダーを閉じる
			if (_superSlider != null) _superSlider.ClosePanel();
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ツールバーがクリックされた時に発動します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
		{
            if (Program.Param[0] == "1")
            {
                MAKAU00138UA MAKAU00138UA = new MAKAU00138UA();
                MAKAU00138UA = (MAKAU00138UA)_formControlInfo.Form;
            
                int status = 0;
	    		switch (e.Tool.Key)
	    		{
    				case "ButtonTool_Close":
    					//--------------------------------------------------------------
    					// 終了ボタン
    					//--------------------------------------------------------------
    					// メイン画面のクローズ
    					this.Close();
    					break;
    				case "ButtonTool_Save":
    					//--------------------------------------------------------------
    					// 保存ボタン
    					//--------------------------------------------------------------
//                        string retMessage;
                        //登録
                        status = MAKAU00138UA.CheckInput();
                        if (status == 0)
                        {
                            //string msg;
                            status = MAKAU00138UA.ExecuteSaveProc();
                        }
                        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
                        else
                        {       
                            string msg = "";
                            if (chkSt == 1)
                            {
                                msg = "締日の指定に誤りがあります。";
                            }
                            else if (chkSt == 2)
                            {
                                msg = "準備処理年月日の指定に誤りがあります。";
                            }
                               
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, msg, 0, MessageBoxButtons.OK);
                        }
                           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
                        break;
                    case "ButtonTool_Bns":
                        //--------------------------------------------------------------
                        // 締取消ボタン
                        //--------------------------------------------------------------
                        status = MAKAU00138UA.ExecuteDelProc();

                        break;

    				case "ButtonTool_New":
	    				//--------------------------------------------------------------
		    			// 新規ボタン
			    		//--------------------------------------------------------------
				    	// 新規処理
					    this.NewEditTabChild(true);
//                    _custDmdPrcAcs.DBDataClear();
//                    _custDmdPrcAcs.StockDataClear();

//                    CustDmdPrcAcs.IncrementProductStock();                    
                        MAKAU00138UA.DispClear();
                        MAKAU00138UA.SetFocus();
    					break;
                }			
			}else if (Program.Param[0] == "2")
            {
                //請求準備処理
                MAKAU00139UA MAKAU00139UA = new MAKAU00139UA();
                MAKAU00139UA = (MAKAU00139UA)_formControlInfo.Form;
                
                int status = 0;
                switch (e.Tool.Key)
                {
                    case "ButtonTool_Close":
                        //--------------------------------------------------------------
                        // 終了ボタン
                        //--------------------------------------------------------------
                        // メイン画面のクローズ
                        this.Close();
                        break;
                    case "ButtonTool_Save":
                        //--------------------------------------------------------------
                        // 保存ボタン
                        //--------------------------------------------------------------
                        //登録
                        status = MAKAU00139UA.CheckInput();
                        if (status == 0)
                        {
                            status = MAKAU00139UA.ExecuteSaveProc();
                        }
                        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
                        else
                        {
                            string msg = "";
                            if (chkSt == 1)
                            {
                                msg = "締日の指定に誤りがあります。";
                            }
                            else if (chkSt == 2)
                            {
                                msg = "更新処理年月日の指定に誤りがあります。";
                            }

                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, msg, 0, MessageBoxButtons.OK);
                        }
                           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
                        break;
                    case "ButtonTool_Bns":
                        //--------------------------------------------------------------
                        // 締取消ボタン
                        //--------------------------------------------------------------
                        status = MAKAU00139UA.ExecuteDelProc();

                        break;
                    case "ButtonTool_New":
                        //--------------------------------------------------------------
                        // 新規ボタン
                        //--------------------------------------------------------------
                        // 新規処理
                        this.NewEditTabChild(true);
                        //                    _custDmdPrcAcs.DBDataClear();
                        //                    _custDmdPrcAcs.StockDataClear();

                        //                    CustDmdPrcAcs.IncrementProductStock();                    
                        MAKAU00139UA.DispClear();
                        MAKAU00139UA.SetFocus();

                        break;
                }				
			}
        }

        #region DEL 2008/08/07 使用していないのでコメントアウト
        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバー値変更時イベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolbarsManager_Main_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ComboBoxTool_Section":
					//--------------------------------------------------------------
					// 入力拠点を変更する
					//--------------------------------------------------------------
					Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
					if (cmbOwnSection.Value is string)
					{

						// 選択した拠点コードを取得する
						string sectionCode = (string)cmbOwnSection.Value;			// 拠点コード

                        if (_formControlInfo != null)
                        {
                            if (Program.Param[0] == "1")
                            {
                                MAKAU00138UA MAKAU00138UA = new MAKAU00138UA();
                                MAKAU00138UA = (MAKAU00138UA)_formControlInfo.Form;
                                //                            MAKAU00138UA.Section_tNedit.Text = GetSectionNm();
                                MAKAU00138UA.Section_tEdit.Text = GetSectionNm();
                                MAKAU00138UA._sectionCd = GetSection();

                            }
                            else if (Program.Param[0] == "2")
                            {
                                MAKAU00139UA MAKAU00139UA = new MAKAU00139UA();
                                MAKAU00139UA = (MAKAU00139UA)_formControlInfo.Form;
                                //                            MAKAU00138UA.Section_tNedit.Text = GetSectionNm();
                                MAKAU00139UA.Section_tEdit.Text = GetSectionNm();
                                MAKAU00139UA._sectionCd = GetSection();
                            }

                            // 拠点情報を表示する
                            this.ShowToolBarSection();
                        }
		
					}
					break;
			}
		}
        
        /// <summary>
		/// バーコード読み取りイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tBarcodeReader1_BarcodeReaded(object sender, BarcodeReadedEventArgs e)
		{
//			int st;

			if (_formControlInfo != null)
			{
//				if (_formControlInfo.Form is IStockEntryTbsCtrlChildResponse)
				{
					// 子画面アクション通知処理
//					st = ((IStockEntryTbsCtrlChildResponse)_formControlInfo.Form).ChildResponse(this, _formControlInfo.Form, "BarcodeRead", e.BarcodeString);
				}
			}
		}
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/07 使用していないのでコメントアウト
        
        # endregion

        //----------------------------------------------------------------------------------------------------
		//  プライベートメソッド
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド
		/// <summary>
		/// 新規作成処理
		/// </summary>
		/// <param name="comparer">編集中チェック有無</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンが押された時に発動して、全データを初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int NewEditTabChild(bool comparer)
		{
			// タブ子画面が展開されていない→exit
			if (this.TabControl_Main.Tabs.Count <= 0) return -1;

			// 現在のカーソルを退避する
			Cursor bufCursor = this.Cursor;
			try
			{
				// カーソルを『Wait』にする
				this.Cursor = Cursors.WaitCursor;

				// 表示モード初期化
//				this.SettingDispMode((int)ChildFormDispMode.Normal);

                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
				// 子画面に対して再表示を実行させる
				this.ShowTabChild();
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                
                //･･････････････････････････････････････････････････････････････････････････
				// 画面系の初期化を行う
				//･･････････････････････････････････････････････････････････････････････････
				try
				{
                    /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
					// 拠点情報表示
					this.ShowToolBarSection();
                       --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                    
                    // ツールバー調整
					this.ToolbarEnableChange(0);
				}
				finally
				{
                    /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
					// 画面に表示した内容を初期値にする
					this.StoreTabChild();
//					this._stockMngAcs.CopyStaticMemory(this, 0);	// 0:Main→Undo
                       --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                }
			}
			finally // マウスカーソルに対するfinally
			{
				// マウスカーソルを元に戻す
				this.Cursor = bufCursor;
			}

			return 0;
        }

        #region DEL 2008/08/07 使用していないのでコメントアウト
        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 子画面の保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 子画面に対して、Staticに保存させる処理を実行させます。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int StoreTabChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
			}

			return st;
		}

		/// <summary>
		/// 子画面へStatic情報を表示させる
		/// </summary>
		/// <remarks>
		/// <br>Note       : 子画面に対して、Staticに保持されているデータを表示するように要求します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void ShowTabChild()
		{
			if (_formControlInfo != null)
			{
			}
		}

		/// <summary>
		/// 子画面（編集画面）の入力チェック処理
		/// </summary>
		/// <returns>0=入力エラー無し,1=入力エラー有り</returns>
		/// <remarks>
		/// <br>Note       : MDIフォーム(編集画面）の入力チェック処理</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int CheckEditTabChild()
		{
			if (_formControlInfo != null)
			{

			}

			return 0;
		}

		/// <summary>
		/// タブアクティブ処理
		/// </summary>
		/// <param name="form"></param>
		private void TabActivatedProc(Form form)
		{
			if (form != null)
			{
				if (this._formControlInfo == null) return;

				// 子画面の描画をかける
				this.RefreshTabChild(form);
			}
		}

		/// <summary>
		/// タブ非アクティブ処理
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		private int TabDeactivattingProc(Form form)
		{
			if (form != null)
			{
			}

			return 0;
		}

		/// <summary>
		/// MDI子画面の再描画指示（staticな領域からデータを取得して表示）
		/// </summary>
		/// <param name="form">MDI子画面(編集画面)</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI子画面の再描画指示（staticな領域からデータを取得して表示）</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void RefreshTabChild(Form form)
		{
			if (form != null)
			{
			}
		}
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/07 使用していないのでコメントアウト

        # endregion

        //----------------------------------------------------------------------------------------------------
		//  プライベートメソッド(タブ構築関連)
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド(タブ構築関連)
		/// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		/// <param name="NexViewFormname">次に表示するフォーム</param>
		/// <remarks>
		/// <br>Note       : フレームが起動するフォームクラステーブルを生成します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void FormControlInfoCreate(string NexViewFormname)
		{
			_formControlInfo = null;

            if (Program.Param[0] == "1")
            {
                _formControlInfo = new FormControlInfo(
                    NO0_TOP_TAB,
                    "MAKAU00138U",
                    "Broadleaf.Windows.Forms.MAKAU00138UA",
                    "売上月次更新",
                    IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
                    NO_TAB,
                    NO_TAB);
            }
            else if (Program.Param[0] == "2")
            {
                _formControlInfo = new FormControlInfo(
                    NO0_TOP_TAB,
                    "MAKAU00139U",
                    "Broadleaf.Windows.Forms.MAKAU00139UA",
                    "仕入月次更新",
                    IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
                    NO_TAB,
                    NO_TAB);
            }
		}

		/// <summary>
		/// タブクリエイト処理
		/// </summary>
		/// <param name="key">タブ管理キー</param>
		/// <remarks>
		/// <br>Note       : フレームのタブをクリエイトします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			Cursor localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_TOP_TAB:
						// 先頭画面生成
						if (_formControlInfo == null) return;

						this.CreateTabChildForm(_formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
						break;
				}
			}
			finally
			{
				this.Cursor = localCursor;
			}
		}

		/// <summary>
		/// TAB子画面を生成する
		/// </summary>
		/// <param name="frmAssemblyName">フォームアセンブリ名</param>
		/// <param name="frmClassName">フォームクラス名称</param>
		/// <param name="title">表示タイトル</param>
		/// <param name="frmName">フォーム名</param>
		/// <param name="icon">アイコン・イメージ</param>
		/// <param name="info">フォーム制御情報</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : TAB子画面を生成する</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br>UpdateNote   : 2011/04/11 liyp 月次更新にタイマーをつけて、処理開始時間を指定可能とする</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;
			form = (Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(Form));

			if (form == null)
			{
//				ErrorForm ef = new ErrorForm();
//				form = (System.Windows.Forms.Form)ef;
			}
			else
			{
				// フォームプロパティ変更
				form.Name = frmName;

				// タブページコントロールをインスタンス
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// タブの外観を設定し、タブコントロールにタブを追加する
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;												// 名称
				uTab.Key = frmName;												// Key
				uTab.Tag = form;												// フォームのインスタンス
				uTab.Appearance.Image = icon;									// アイコン
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            	uTab.ActiveAppearance.BackColor = Color.White;        		
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
                // --- ADD 2011/04/11 ---------->>>>>
                // ツールバーボタン制御イベント 
                if (Program.Param[0] == "1")
                {
                    ((MAKAU00138UA)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                }
                else if (Program.Param[0] == "2")
                {
                    ((MAKAU00139UA)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                }
                // --- ADD 2011/04/11 ----------<<<<<
				this.TabControl_Main.Controls.Add(uTabPageControl);
				this.TabControl_Main.Tabs.AddRange(new UltraTab[] { uTab });
                this.TabControl_Main.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;

        		form.Show();

				uTabPageControl.Controls.Add(form);
				form.Dock = System.Windows.Forms.DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : アセンブリをロードします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (System.IO.FileNotFoundException ex)
			{
				// 対象アセンブリなし（警告）
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, ex.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (System.Exception ex)
			{
				// 対象アセンブリなし（警告)
				string _msg = "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}
			return obj;
		}
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  プライベートメソッド(画面設定関連)
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド(画面設定関連)

        #region DEL 2008/08/07 使用していないのでコメントアウト
        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバー拠点表示処理
		/// </summary>
		private void ShowToolBarSection()
		{
			// 計上拠点名称を表示
			SecInfoAcs secInfoAcs = new SecInfoAcs();	// 拠点情報取得アクセスクラス
		}

		/// <summary>
		/// 画面表示モード設定処理
		/// </summary>
		/// <param name="dispMode">表示モード</param>
		private void SettingDispMode(int dispMode)
		{
			this._dispMode = dispMode;

//            switch (dispMode)
//            {
//                case (int)ChildFormDispMode.Normal:
//                case (int)ChildFormDispMode.RefNormal:
////					this.DockManager_Main.Enabled = true;
//                    // 拠点変更可
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
//                    break;
//                case (int)ChildFormDispMode.ReadOnly:
////					this.DockManager_Main.Enabled = false;
//                    // 拠点変更不可
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
//                    break;
//                case (int)ChildFormDispMode.RefNew:
////					this.DockManager_Main.Enabled = true;
//                    // 拠点変更可
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
//                    break;
//                case (int)ChildFormDispMode.RefRed:
////					this.DockManager_Main.Enabled = false;
//                    // 拠点変更不可
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
//                    break;
//            }

			// ステータスバー表示
//			if (dispMode == (int)ChildFormDispMode.ReadOnly)
//			{
//				this.ultraStatusBar1.Panels["Text"].Text = "読み取り専用";
//			}
//			else
//			{
//				this.ultraStatusBar1.Panels["Text"].Text = "";
//			}
		}
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/07 使用していないのでコメントアウト

        /// <summary>
		/// ツールバーのアイコン設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのツールバーの設定を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void SettingToolbar()
		{
			//--------------------------------------------------------------
			// メインツールバー
			//--------------------------------------------------------------
			// イメージリストを設定する
			this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

			// 拠点のアイコン設定
			ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			// ログイン担当者のアイコン設定
			ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// 終了のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// 保存のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// 新規のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // 締削除のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_Bns"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			// ログイン名
			ToolBase LoginName = ToolbarsManager_Main.Tools["LabelTool_LoginName"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;
                this._employee = employee;
			}
		}

		/// <summary>
		/// ツールバー有効無効変更処理
		/// </summary>
		/// <param name="mode">モード[0:初期表示, 1:呼出し, 2:読み取り専用]</param>
		private void ToolbarEnableChange(int mode)
		{
			switch (mode)
			{
				case 0:
					// 保存ボタン有効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// 削除ボタン無効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
				case 1:
					// 保存ボタン有効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// 削除ボタン有効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					break;
				case 2:
					// 保存ボタン無効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
					// 削除ボタン無効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
			}
		}

		/// <summary>
		/// ドッキングウィンドウ設定(検索スライダー)
		/// </summary>
		private void SettingDockingWindow()
		{
			_superSlider = new SFCMN00221UA();
			Panel sldpanel = _superSlider.GetMainPanel(0, 13);

			sldpanel.Dock = DockStyle.Fill;
		}
		# endregion

        // --- ADD 2010/06/08 ---------->>>>>
        /// <summary>
        /// MAKAU00130UA_Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 障害・改良対応（７月リリース案件）</br>
        /// <br>Programer  : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void MAKAU00130UA_Shown(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "月次更新中は伝票発行が出来ませんので、" + "\r\n"
               + "\r\n" +
               "ご注意願います。",
               "確認－ ＜月次更新＞",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }
        // --- ADD 2010/06/08 ----------<<<<<

        // --- ADD 2011/04/11 ---------->>>>>
        // ===============================================================================
        // デリゲートイベント
        // ===============================================================================
        #region delegateEvent
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }
        #endregion

        #region ◆　ツールバーの表示・有効設定
        /// <summary>
        /// ツールバーの表示・有効設定
        /// </summary>
        /// <param name="activeForm">アクティブなフォームのオブジェクト</param>
        /// <remarks>
        /// <br>Note       : ツールバーの表示・非表示、有効・無効設定を行います。</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonSaveTool;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonCloseTool;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonDeleteTool; //PopupMenuTool_Tool
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpMenuTool;
            int count = 0;

            for (int i = 0; i < this.TabControl_Main.Tabs.Count; i++)
            {
                if (this.TabControl_Main.Tabs[i].IsInView)
                {
                    count++;
                }
            }
            // 保存ボタン有効
            buttonSaveTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)ToolbarsManager_Main.Tools["ButtonTool_Save"];
            // 終了のアイコン設定
            buttonCloseTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)ToolbarsManager_Main.Tools["ButtonTool_Close"];
            buttonDeleteTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)ToolbarsManager_Main.Tools["ButtonTool_Bns"];
            popUpMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)ToolbarsManager_Main.Tools["PopupMenuTool_Tool"];

            if (Program.Param[0] == "1")
            {
                if (((MAKAU00138UA)activeForm).ProcessWaitFlg)
                {
                    // 保存ボタン有効
                    buttonSaveTool.SharedProps.Enabled = false;
                    buttonCloseTool.SharedProps.Enabled = false;
                    buttonDeleteTool.SharedProps.Enabled = false;
                    popUpMenuTool.SharedProps.Enabled = false;
                }
                else
                {
                    // 保存ボタン有効
                    buttonSaveTool.SharedProps.Enabled = true;
                    buttonCloseTool.SharedProps.Enabled = true;
                    buttonDeleteTool.SharedProps.Enabled = true;
                    popUpMenuTool.SharedProps.Enabled = true;
                }
            }
            else if (Program.Param[0] == "2")
            {
                if (((MAKAU00139UA)activeForm).ProcessWaitFlg)
                {
                    // 保存ボタン有効
                    buttonSaveTool.SharedProps.Enabled = false;
                    buttonCloseTool.SharedProps.Enabled = false;
                    buttonDeleteTool.SharedProps.Enabled = false;
                    popUpMenuTool.SharedProps.Enabled = false;
                }
                else
                {
                    // 保存ボタン有効
                    buttonSaveTool.SharedProps.Enabled = true;
                    buttonCloseTool.SharedProps.Enabled = true;
                    buttonDeleteTool.SharedProps.Enabled = true;
                    popUpMenuTool.SharedProps.Enabled = true;
                }
            }
        }
        #endregion
        // --- ADD 2011/04/11 ----------<<<<<

        #region DEL 2008/08/07 使用していないのでコメントアウト
        /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
        private void ultraTabSharedControlsPage1_Paint(object sender, PaintEventArgs e)
        {

        }
           --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/07 使用していないのでコメントアウト
    }
}
