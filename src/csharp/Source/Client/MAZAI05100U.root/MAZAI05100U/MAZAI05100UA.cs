using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
	/// 棚卸準備処理メインフレームクラス    
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理メインフレームクラスの機能を実装します</br>
	/// <br>Programmer : 23010 中村仁</br>
	/// <br>Date       : 2007.04.12</br>
    /// <br>UpDateNote : 2007.07.23 H.NAKAMURA</br>
    ///                  フレームに自拠点(ログイン拠点名称を表示するよう修正)
    /// <br>UpdateNote : 2008/08/28 30414 忍 幸史</br>
    /// <br>             ・Partsman用に変更</br>
	/// </remarks>
    public partial class MAZAI05100UA : Form
    {
        #region Constructor

        /// <summary>
	    /// 棚卸準備処理メインフレームクラスコンストラクタ    
	    /// </summary>
	    /// <remarks>
	    /// <br>Note       : 棚卸準備処理メインフレームクラスのインスタンスを初期化します</br>
	    /// <br>Programmer : 23010 中村仁</br>
	    /// <br>Date       : 2007.04.12</br>
	    /// </remarks>
        public MAZAI05100UA()
        {
            InitializeComponent();

			// ログイン情報生成 //
			if (LoginInfoAcquisition.Employee != null)
			{
				// 従業員情報
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;			    
                //企業コード
                this._enterpriseCode = employee.EnterpriseCode;
				//ログイン従業員コード
				this._employeeCode = employee.EmployeeCode;
				//ログイン従業員名称
				this._employeeName = employee.Name;

                /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
                //ログイン拠点コード
                this._loginSectionCode = employee.BelongSectionCode;
                   --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

                //ログイン拠点名称
                //従業員から拠点名称が取得できない。。。
                //this._loginSectionName = employee.BelongSectionName;
			}

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            //拠点ガイド名称取得
            SecInfoSet set;
            ArrayList list;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs.GetSecInfo(out set,out list);
            if(set != null)
            {
                this._loginSectionName = set.SectionGuideNm;
            }
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //過不足更新が別フレームになったので１固定
			//起動パラメータ
			//this._iPara = ConvertToInt32(Program._parameter[0]);
            this._iPara = 1;

			// タブに表示するフォームクラスの情報を構築する
            switch (this._iPara)
			{
				case ctInventoryPrepare:
					// 棚卸準備処理
					this.Text = NO0_INVENTORYPREPARE_TITLE;
					break;
				case ctJustEnough:
					// 過不足更新処理
					this.Text = NO1_JUSTENOUGH_TITLE;
					break;
			}
        }

        #endregion 

        #region Private Member

        #region Const

        // パラメータ
		private const int ctInventoryPrepare = 1;			// 棚卸準備処理
		private const int ctJustEnough = 2;					// 過不足更新処理

		// タブ関連
		private const string NO0_INVENTORYPREPARE_TITLE			= "棚卸準備処理";
		private const string NO0_INVENTORYPREPARE_TAB			= "INVENTORYPREPARE_TAB";
		private const string NO0_INVENTORYPREPARE_VIEW_TITLE	= "棚卸準備帳票ビュー";
		private const string NO0_INVENTORYPREPARE_VIEW_TAB		= "INVENTORYPREPARE_VIEW_TAB";
	
		private const string NO1_JUSTENOUGH_TITLE				= "棚卸過不足更新処理";
		private const string NO1_JUSTENOUGH_TAB					= "JUSTENOUGH_TAB";
		private const string NO1_JUSTENOUGH_VIEW_TITLE			= "棚卸表ビュー";
		private const string NO1_JUSTENOUGH_VIEW_TAB			= "JUSTENOUGH_VIEW_TAB";

        //ツールバー関連
        //キー
        private const string ctFILE_POPUPMENUTOOLKEY        = "File_PopupMenuTool";         //ファイル
        private const string ctCLOSE_BUTTONTOOLKEY          = "Close_ButtonTool";           //閉じる
        private const string ctSAVE_BUTTONTOOLKEY           = "Save_ButtonTool";            //保存
        private const string ctPRINT_BUTTONTOOLKEY          = "Print_ButtonTool";           //印刷
        private const string ctLOGINNAMETITLE_LABELTOOLKEY  = "LoginNameTitle_LabelTool";   //ログイン担当者ラベル
        private const string ctLOGINNAME_LABELTOOLKEY       = "LoginName_LabelTool";        //ログイン担当者名

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        private const string ctSECTIONNAMETITLE_LABELTOOLKEY = "SectionNameTitle_LabelTool";      //ログイン拠点タイトルラベル
        private const string ctSECTIONNAME_LABLETOOLKEY     = "SectionName_LableTool";      //ログイン拠点名称
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // StatusBar関連
		private const string ctSTATUSBAR_TEXT = "StatusBarPanel_Text";
		private const string ctSTATUSBAR_PROGRESS = "StatusBarPanel_Progress";

        #endregion

        #region Member

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        //拠点情報アクセスクラス
        private SecInfoAcs _secInfoAcs;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // ログイン情報
		private string _enterpriseCode;
		private string _employeeCode;
		private string _employeeName;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        private string _loginSectionCode;
        private string _loginSectionName;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // イベントキャンセルフラグ
		private bool _eventExecFlg = false;
		// ステータスバーメッセージクリアキャンセルフラグ
		private bool _isMsgClearCansel = false;

        // フォームコントロールクラス辞書
		private Dictionary<string, FormControlInfo_Invent> _formControlInfoDic = null;

        // 起動引数
		int _iPara = 0 ;

        #endregion

        #endregion

        #region Private Methods

        #region 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.02</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ステータスバー進捗バー制御処理(完了)
			this.StatusBarProgressControlEnd();
           
            // ツールバー初期設定処理
			this.SetToolbar();

            // ツールバーにログイン担当者を表示する
			this.ShowToolbarSlip();

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // ツールバーにログイン拠点名称を表示
            this.ShowSectionForToolbar();
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        }
        #endregion

        #region ステータスバー進捗処理

        /// <summary>
		/// ステータスバー進捗バー制御処理(開始)
		/// </summary>
		private void StatusBarProgressControlStart(int max, int min, int val, string message)
		{
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = true;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum = max;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Minimum = min;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = val;
			this.Main_StatusBar.Refresh();
		}

		/// <summary>
		/// ステータスバー進捗バー制御処理(経過)
		/// </summary>
		private void StatusBarProgressControl(string message)
		{
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value++;
			this.Main_StatusBar.Refresh();
		}

        /// <summary>
		/// ステータスバー進捗バー制御処理(完了)
		/// </summary>
		private void StatusBarProgressControlEnd()
		{          
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = "";
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = false;
			this.Main_StatusBar.Refresh();
        }

        #endregion

        #region ツールバー初期設定処理

        /// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void SetToolbar()
		{
			// イメージリストを設定する
            ImageList imageList16 = IconResourceManagement.ImageList16;
			this.Main_ToolbarsManager.ImageListSmall = imageList16;

            // ログイン担当者へのアイコン設定
			LabelTool loginEmployeeLabel = (LabelTool)Main_ToolbarsManager.Tools[ctLOGINNAMETITLE_LABELTOOLKEY];
			if (loginEmployeeLabel != null)
				loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// 終了のアイコン設定
			ButtonTool closeButton = (ButtonTool)Main_ToolbarsManager.Tools[ctCLOSE_BUTTONTOOLKEY];
			if (closeButton != null)
				closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// 保存のアイコン設定
			ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools[ctSAVE_BUTTONTOOLKEY];
			if (saveButton != null)
				saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// 印刷のアイコン設定(フレームからの印刷機能は保留)
			ButtonTool printButton = (ButtonTool)Main_ToolbarsManager.Tools[ctPRINT_BUTTONTOOLKEY];
			if (printButton != null)
				printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // 拠点ラベルのアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[ctSECTIONNAMETITLE_LABELTOOLKEY];
			if (sectionLabel != null)
				sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        }

        #endregion

        #region ログイン担当者表示処理
        /// <summary>
        /// ツールバーにログイン担当者を表示する
        /// </summary>
        private void ShowToolbarSlip()
        {          
			//ログイン従業員名称
            if(LoginInfoAcquisition.Employee.Name != null)
            {
                this.Main_ToolbarsManager.Tools[ctLOGINNAME_LABELTOOLKEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
            
            LabelTool loginName = (LabelTool)Main_ToolbarsManager.Tools[ctLOGINNAME_LABELTOOLKEY];
            if (loginName != null && _employeeName != null)
                loginName.SharedProps.Caption = this._employeeName;
        }
        #endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 棚卸拠点表示処理

        /// <summary>
        /// ツールバーに棚卸拠点を表示する
        /// </summary>
        private void ShowSectionForToolbar()
        {          
			//ログイン拠点名称
            if(LoginInfoAcquisition.Employee.Name != null)
            {
                this.Main_ToolbarsManager.Tools[ctSECTIONNAME_LABLETOOLKEY].SharedProps.Caption = this._loginSectionName;
            }
            
            Infragistics.Win.UltraWinToolbars.LabelTool secName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[ctSECTIONNAME_LABLETOOLKEY];
            if (secName != null)
                secName.SharedProps.Caption = this._loginSectionName;
        }

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region フォームコントロールクラスクリエイト処理
        /// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		private void FormControlInfoCreate()
		{
			if ( this._formControlInfoDic != null ) 
			{
				return;
			}
			else
			{
				this._formControlInfoDic = new Dictionary<string,FormControlInfo_Invent>();
			}

			// タブに表示するフォームクラスの情報を構築する
            switch (this._iPara)
            {
                case ctInventoryPrepare:
                    // 棚卸準備処理
                    // タブに表示するフォームクラスの情報を構築する
                    // UIForm
                    this._formControlInfoDic.Add(
                        NO0_INVENTORYPREPARE_TAB ,                  // Key
                        new FormControlInfo_Invent(			        // Tab Info
                            NO0_INVENTORYPREPARE_TAB,				// Tab Key
                            "MAZAI05110U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05110UA",	// Tab ClassID
                            NO0_INVENTORYPREPARE_TITLE,				// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH	]	// icon
                        )
                    );
                    // ListView(フレームから印刷を行う際に使用。機能拡張の為準備しておく)
                    this._formControlInfoDic.Add(
                        NO0_INVENTORYPREPARE_VIEW_TAB, 
                        new FormControlInfo_Invent(			        // Tab Info
                            NO0_INVENTORYPREPARE_VIEW_TAB,			// Tab Key
                            "MAZAI05100U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05100UB",	// Tab ClassID
                            NO0_INVENTORYPREPARE_VIEW_TITLE,		// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW	]	// icon
                        )
                    );

                    break;
                case ctJustEnough:
                    //今回は過不足更新を行わない仕様なので未使用
                    //今後仕様が変更された場合に使用する
                    // タブに表示するフォームクラスの情報を構築する
                    // 棚卸過不足更新
                    // タブに表示するフォームクラスの情報を構築する
                    // UIForm
                    this._formControlInfoDic.Add(
                        NO1_JUSTENOUGH_TAB ,                        // Key
                        new FormControlInfo_Invent(			        // Tab Info
                            NO1_JUSTENOUGH_TAB,						// Tab Key
                            "MAZAIXXXXXU",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAIXXXXXUA",	// Tab ClassID
                            NO1_JUSTENOUGH_TITLE	,				// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH	]	// icon
                        )
                    );
                    // ListView
                    this._formControlInfoDic.Add(
                        NO1_JUSTENOUGH_VIEW_TAB, 
                        new FormControlInfo_Invent(			// Tab Info
                            NO1_JUSTENOUGH_VIEW_TAB,				// Tab Key
                            "MAZAI05100U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05100UB",	// Tab ClassID
                            NO1_JUSTENOUGH_VIEW_TITLE		,		// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW	]	// icon
                        )
                    );

                    break;
            }
        }

        #endregion

        #region タブクリエイト処理(TabCreate)
		/// <summary>
		/// タブクリエイト処理
		/// </summary>
		/// <param name="key">タブKey</param>
		private void TabCreate(string key)
		{
			// フォームコントロールクラス辞書にキーが存在しない場合は処理しない
			if (!this._formControlInfoDic.ContainsKey(key)) return;
	
			FormControlInfo_Invent info = this._formControlInfoDic[key];

			Cursor _localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (info.Form == null)
				{
					// タブ子画面生成
					if (this.CreateMdiChildForm(info)) return;
				}
				else
				{
					this.Main_UTabControl.Tabs[key].Visible = true;
					this.Main_UTabControl.Tabs[key].Active = true;
					this.Main_UTabControl.Tabs[key].Selected = true;
					this.Main_UTabControl.Tabs[key].Text = info.Name;
				}
			}
			finally
			{
				this.Cursor = _localCursor;
			}
		}
		#endregion

        #region MDI子画面を生成する(CreateMdiChildForm)
		/// <summary>
		/// MDI子画面を生成する
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		private bool CreateMdiChildForm(FormControlInfo_Invent info)
		{
			info.Form = null;
			info.Form = (Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(Form));

			if (info.Form == null)
				info.Form = new Form();

			if (info.Form != null)
			{
				// フォームプロパティ変更
				info.Form.Name = info.Name;

				// タブページコントロールをインスタンス
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// タブの外観を設定し、タブコントロールにタブを追加する
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = info.Name;								// 名称
				uTab.Key = info.Key;								// Key
				uTab.Tag = info.Form;								// フォームのインスタンス
				uTab.Appearance.Image = info.Icon;					// アイコン
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

				this.Main_UTabControl.Controls.Add(uTabPageControl);
				this.Main_UTabControl.Tabs.AddRange(new UltraTab[] { uTab });
				this.Main_UTabControl.SelectedTab = uTab;

				info.Form.TopLevel = false;
				info.Form.FormBorderStyle = FormBorderStyle.None;
				info.Form.Show();

				uTabPageControl.Controls.Add(info.Form);
				info.Form.Dock = DockStyle.Fill;
			}

			return true;
		}
		#endregion

        #region クラスをインスタンス化処理(LoadAssemblyFrom)
		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
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
						obj = Activator.CreateInstance(objType);
				}
			}
			catch (FileNotFoundException er)
			{
				// 対象アセンブリなし！
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					er.Message,
					0, MessageBoxButtons.OK);

			}
			catch (System.Exception er)
			{
				// 対象アセンブリなし
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					"Message=" + er.Message + "\r\n" + "Trace  =" + er.StackTrace + "\r\n" + "Source =" + er.Source,
					0, MessageBoxButtons.OK);
			}

			return obj;
		}
		#endregion

        #region タブアクティブ処理(TabActive)
		/// <summary>
		/// タブアクティブ処理
		/// </summary>
		/// <param name="key">対象キー情報</param>
		private Form TabActive(string key)
		{
			Form form = new Form();
			form = null;

			// 指定Keyのタブが存在するかチェック
			bool bingo = false;
			foreach (UltraTab tab in Main_UTabControl.Tabs)
			{
				if (tab.Key == key)
				{
					bingo = true;

					break;
				}
			}
			if (!bingo) return form;

			Cursor _localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_INVENTORYPREPARE_TAB:
					case NO1_JUSTENOUGH_TAB:
						// フォームを取得する
						if (Main_UTabControl.Tabs[key].Tag is Form) form = (Form)Main_UTabControl.Tabs[key].Tag;

						// 指定KeyのSelect状態でない場合は、タブをSelect状態にする
						if (this.Main_UTabControl.Tabs[key].Selected == false)
							this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];

						break;
					default:
						break;
				}
			}
			finally
			{
				this.Cursor = _localCursor;
			}

			return form;
		}
		#endregion

        #region スタティック情報展開処理→子画面
        /// <summary>
		/// 子画面へStatic情報を表示させる
		/// </summary>
		private void ShowMdiChild()
		{
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			if (formControlInfo != null)
			{
                if (formControlInfo.Form is IEntryTbsMDIChild)
                    // スタティック保存処理
                    ((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData(this);
			}
        }
        #endregion

        #region スタティック情報所得処理
        /// <summary>
		/// FormControlInfo_Invent取得処理
		/// </summary>
		/// <returns>FormControlInfo_Invent</returns>
		private FormControlInfo_Invent GetFormControlInfo_Invent()
		{
			FormControlInfo_Invent formControlInfo = null;
			if ( this._iPara == ctInventoryPrepare )
			{
				if ( this._formControlInfoDic.ContainsKey(NO0_INVENTORYPREPARE_TAB) )
				{
					formControlInfo = this._formControlInfoDic[NO0_INVENTORYPREPARE_TAB];
				}
			}
			else
			{
				if ( this._formControlInfoDic.ContainsKey(NO1_JUSTENOUGH_TAB) )
				{
					formControlInfo = this._formControlInfoDic[NO1_JUSTENOUGH_TAB];
				}
			}
			return formControlInfo;
        }
        #endregion

        #region 入力チェック処理

        /// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <returns>STATUS: 0:OK, 1:NG</returns>
		private int InputCheck()
		{
            //スタティック情報取得
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			int status = 0;
			int status2 = 0;
			ArrayList errorList = new ArrayList();

			if (formControlInfo != null)
			{
				if (formControlInfo.Form is IEntryTbsMDIChild)
					status2 = ((IEntryTbsMDIChildEdit)formControlInfo.Form).ShowErrorItems(this, errorList);

                    if (status2 != 0)
                        status = status2;
			}

			if (status != 0)
			{
				string message = "";
				foreach (string s in errorList)
				{
					if (s != "")
					{
						if (message == "")
							message = s;
						else
							message += "\n" + s;
					}
				}
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					message,
					0, MessageBoxButtons.OK);
			}

			return status;
        }

        #endregion

        #region MDIフォームの登録処理

        /// <summary>
		/// MDIフォームの登録処理
		/// </summary>
		private int SaveEditMdiChild()
		{
			int status = 0;

			// 現在のカーソルを退避する
			Cursor _localCursor = this.Cursor;

			string beforSaveMsg = string.Empty;	// 保存前Msg
			string savingMsg = string.Empty;	// 保存中Msg
			string faledSaveMsg =string.Empty;	// 保存後Msg

			if ( this._iPara == ctInventoryPrepare )
			{
				// 棚卸準備処理
				beforSaveMsg = "棚卸準備処理中です．．．";
				savingMsg = "棚卸準備処理が完了しました。";
				faledSaveMsg = "棚卸準備処理に失敗しました。";
			}
			else
			{
				// 過不足更新
				beforSaveMsg = "棚卸過不足更新中です．．．";
				savingMsg = "棚卸過不足更新が完了しました。";
				faledSaveMsg = "棚卸過不足更新に失敗しました。";
			}

            //スタティック情報取得
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			try
			{

				if (formControlInfo.Form != null)
				{
					// カーソルを『Wait』にする
					this.Cursor = Cursors.WaitCursor;

					this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = beforSaveMsg;
					// 保存する
					status = this.StoreMdiChild(formControlInfo);

				}

				switch (status)
				{
					case 0:
						this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = savingMsg;
						break;
					case 1:	// 既存データ判別Dialogでキャンセルが押されたときの処理。(MethodResult.ctFNC_NO_RETURN)
						this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = "";
						break;
//                    case 4:
//                    case 800:
//                    case 801:
//                        // こちらでは何もしない。子画面でエラー表示など対応する
//                        break;
                    default:
        			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = faledSaveMsg;
		              break;
                }
            }
			finally
			{
				
				((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData(this);

				//extraForm.Close();
				StatusBar_MsgClear_Timer.Enabled = true;
				// カーソルを元に戻す
				this.Cursor = _localCursor;
			}

            return status;
        }

        #endregion

        #region 子画面の保存処理

        /// <summary>
		/// 子画面の保存処理
		/// </summary>
		/// <param name="formControlInfo"></param>
		/// <returns></returns>
		private int StoreMdiChild(FormControlInfo_Invent formControlInfo)
		{
			int status = -1;

			if (formControlInfo != null)
			{
				if (formControlInfo.Form is IEntryTbsMDIChildEdit)
					// スタティック保存処理
					status = ((IEntryTbsMDIChildEdit)formControlInfo.Form).SaveStaticMemoryData(this);
			}

			return status;
        }

        #endregion

        #region PDFプレビュー画面フォーム取得処理

        /// <summary>
		/// PDFプレビュー画面フォーム取得処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns>PDFプレビュー画面フォーム</returns>
		private  MAZAI05100UB GetFormFromControlInfoDic(string key)
		{
			MAZAI05100UB MAZAI05100UB = null;
			if (this._formControlInfoDic.ContainsKey(key))
			{
				Form form = this._formControlInfoDic[key].Form;
				if ((form != null) && (form is MAZAI05100UB))
				{
					MAZAI05100UB = (MAZAI05100UB)form;
				}
			}
			return MAZAI05100UB;
        }

        #endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region コンバート処理

        /// <summary>
		/// コンバート（Int32）処理
		/// </summary>
		/// <param name="source">コンバート対象</param>
		/// <returns>コンバート結果</returns>
		private Int32 ConvertToInt32(object source)
		{
			Int32 dest = 0;

			try
			{
				dest = Convert.ToInt32(source);
			}
			catch
			{
				dest = 0;
			}

			return dest;
        }

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region ツールバーボタン有効無効設定処理
        /// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーボタン有効無効設定を行います</br>
		/// <br>Programer  : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			// 棚卸準備処理or過不足更新タブ
			if ( ((this.Main_UTabControl.Tabs.Exists(NO0_INVENTORYPREPARE_TAB)) && (this.Main_UTabControl.SelectedTab.Key == NO0_INVENTORYPREPARE_TAB)) ||
				 ((this.Main_UTabControl.Tabs.Exists(NO1_JUSTENOUGH_TAB)) && (this.Main_UTabControl.SelectedTab.Key == NO1_JUSTENOUGH_TAB)) )
			{
				this.SetToolEnabled("Close_ButtonTool"		, true);
				this.SetToolEnabled("Save_ButtonTool"		, true);
				this.SetToolEnabled("Print_ButtonTool"		, true);
			}
			else
			{
				this.SetToolEnabled("Close_ButtonTool"		, true);
				this.SetToolEnabled("Save_ButtonTool"		, false);
				this.SetToolEnabled("Print_ButtonTool"		, false);
			}
        }
       
        /// <summary>
		/// ToolBarEnableSetting
		/// </summary>
		/// <param name="key"></param>
		/// <param name="enabled"></param>
		private void SetToolEnabled(string key, bool enabled)
		{
			ToolBase toolBase = this.Main_ToolbarsManager.Tools[key];
			if (toolBase != null) toolBase.SharedProps.Enabled = enabled;
		}

        #endregion

        #region MDIフォームの印刷処理(保留)
        /// <summary>
        /// MDIフォームの印刷処理
        /// </summary>
        private void PrintEditMdiChild()
        {
            //TODO:フレームからの印刷は保留
            #region Del
            //スタティック情報取得
            //FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
            //if (formControlInfo.Form != null)
            //{
            //    // 現在のカーソルを退避する
            //    Cursor _localCursor = this.Cursor;

            //    int status = 0;
            //    string pdfFilePath = string.Empty;
            //    MAZAI05100UB MAZAI05100UB = null;
            //    try
            //    {
            //        // カーソルを『Wait』にする
            //        this.Cursor = Cursors.WaitCursor;

            //        // 棚卸調査表、棚卸表どちらを印刷するかチェック
            //        if ( formControlInfo.Key == NO0_INVENTORYPREPARE_TAB )
            //        {
            //this._prtsInventSearchCndtnWork = new PrtsInventSearchCndtnWork();
            //// 棚卸調査票
            //if (formControlInfo != null)
            //{
            //    if (formControlInfo.Form is IEntryTbsMDIChild)
            //        // UIの抽出条件取得のためスタティック保存処理を呼び出す
            //        ((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData((object)this._prtsInventSearchCndtnWork);
            //}

            //if ( _prtsInventSearchCndtnWork == null )
            //{
            //    this._prtsInventSearchCndtnWork = new PrtsInventSearchCndtnWork();
            //    this._prtsInventSearchCndtnWork.EnterpriseCode = this._enterpriseCode;
            //    this._prtsInventSearchCndtnWork.PartsInventorySecCd = this._stockSecInfoSet.SectionCode;
            //}

            //// 印刷画面表示
            //if ( this._sfzai03005UA == null )
            //{
            //    this._sfzai03005UA = new SFZAI03005UA();
            //}

            //this._sfzai03005UA.Show( this._prtsInventSearchCndtnWork );
            //status = 0; // パラメータが帰ってこないので常にゼロ。エラーは印刷UIで表示

            //// PDF印刷チェック
            //if ( this._sfzai03005UA.PdfTempPath != null )
            //{
            //    pdfFilePath = this._sfzai03005UA.PdfTempPath; // TODO:PDFFilePathを取得する
            //}
            //else
            //{
            //    pdfFilePath = string.Empty;
            //}
            //    if (pdfFilePath != string.Empty)
            //    {
            //        //// 帳票によってタブの名称を変更する
            //        //if ( this._sfzai03005UA.PrpIndex == (int)SFZAI03005UA.PrintOutPaperIndex.PrintOutPaperIndex_1 )
            //        //{
            //        //    this._formControlInfoDic[NO0_INVENTORYPREPARE_VIEW_TAB].Name = SFZAI03005UA.PrintOutPaperName_1 + "ビュー";
            //        //}
            //        //else if ( this._sfzai03005UA.PrpIndex == (int)SFZAI03005UA.PrintOutPaperIndex.PrintOutPaperIndex_2 )
            //        //{
            //        //    this._formControlInfoDic[NO0_INVENTORYPREPARE_VIEW_TAB].Name = SFZAI03005UA.PrintOutPaperName_2 + "ビュー";
            //        //}

            //        // 在庫部品一覧表PDFプレビュー表示
            //        this.TabCreate(NO0_INVENTORYPREPARE_VIEW_TAB);

            //        MAZAI05100UB = this.GetFormFromControlInfoDic(NO0_INVENTORYPREPARE_VIEW_TAB);
            //        if (MAZAI05100UB != null)
            //        {
            //            // PDFプレビュー起動
            //            MAZAI05100UB.ShowPDFPreview(pdfFilePath);
            //        }
            //    }

            //}
            //else if ( formControlInfo.Key == NO1_JUSTENOUGH_TAB )
            //{
            //if ( this._sfzai03045UA == null )
            //{
            //    this._sfzai03045UA = new SFZAI03045UA();
            //}
            //// 棚卸表
            //CreatePrtsInventInputCndtn();
            //this._sfzai03045UA.ShowDialog(this._prtsInventInputCndtn);

            //status = 0; // パラメータが帰ってこないので常にゼロ。エラーは印刷UIで表示

            //// PDF印刷チェック
            //if ( this._sfzai03045UA.PdfTempPath != null )
            //{
            //    pdfFilePath = this._sfzai03045UA.PdfTempPath; // TODO:PDFFilePathを取得する
            //}
            //else
            //{
            //    pdfFilePath = string.Empty;
            //}

            //        if (pdfFilePath != string.Empty)
            //        {
            //            // 在庫部品一覧表PDFプレビュー表示
            //            this.TabCreate(NO1_JUSTENOUGH_VIEW_TAB);
            //            MAZAI05100UB = this.GetFormFromControlInfoDic(NO1_JUSTENOUGH_VIEW_TAB);
            //            if (MAZAI05100UB != null)
            //            {
            //                // PDFプレビュー起動
            //                MAZAI05100UB.ShowPDFPreview(pdfFilePath);
            //            }
            //        }
            //    }


            //}
            //finally
            //{
            //    // カーソルを元に戻す
            //    this.Cursor = _localCursor;
            //}

            //                switch (status)
            //                {
            //                    case 0:
            //                        // 子画面に対して再表示を実行させる
            //                        ShowMdiChild();
            //                        break;
            ////                    case 4:
            ////                    case 800:
            ////                    case 801:
            ////                        // こちらでは何もしない。子画面でエラー表示など対応する
            ////                        break;
            //                    default:
            ////                        if (retMsg != "")
            ////                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, Program.ctPGID,
            //////								"書き込みでエラーが発生しました",
            ////                                retMsg,
            ////                                status, MessageBoxButtons.OK);

            //                        break;
            //                }
            //}
            #endregion
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI05100UA", "未実装です", 0, MessageBoxButtons.OK);
        }

        #endregion

        #region フレームからの印刷機能(保留)
        ///// <summary>
        ///// 部品棚卸検索抽出条件クラス作成処理
        ///// </summary>
        //private void CreatePrtsInventInputCndtn()
        //{
        //    if ( this._prtsInventInputCndtn == null )
        //    {
        //        this._prtsInventInputCndtn = new PrtsInventInputCndtn();
        //        this._prtsInventInputCndtn.EnterpriseCode = this._enterpriseCode.Trim();		// 企業コード
        //        this._prtsInventInputCndtn.PartsInventorySecCd = this._stockSecInfoSet.SectionCode.Trim();	// 拠点コード
        //        this._prtsInventInputCndtn.SortingOrder = 0;// 品番順
        //        this._prtsInventInputCndtn.StckWtoutHyhnPNDiv = 0;	// 品番曖昧検索区分
        //        this._prtsInventInputCndtn.PartsNameDiv = 0;		// 部品名称あいまい検索区分
        //        this._prtsInventInputCndtn.PartsKindDivCd = -1;		// 部品品種区分
        //        this._prtsInventInputCndtn.StockAnalysisDivCd = -1;	// 在庫分析区分
        //        this._prtsInventInputCndtn.WorkAccessoriesCd = -1;	// 作業用品区分
        //        this._prtsInventInputCndtn.InventCountInputDiv = -1; // 棚卸数入力区分
        //    }
        //}
        #endregion

        #endregion

        #region ControlEvent

        #region Form Load イベント

        /// <summary>
        /// Form.Load イベント (MAZAI05100UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが初めて表示される直前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.01</br>
        /// </remarks>
        private void MAZAI05100UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
        }
        
        #endregion

        #region Form Closing イベント

        private void MAZAI05100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // アクティブ状態のタブからフォームを取得する
            for (int index = 0; index < this.Main_UTabControl.Tabs.Count; index++)
            {
                Form frm = this.Main_UTabControl.Tabs[index].Tag as System.Windows.Forms.Form;
				if ( ( frm == null ) || (frm.IsDisposed) ) continue;
                frm.Close();
			}		
        }

        #endregion

        #region Initial_Timer_Tick

        /// <summary>
        /// Initial_Timer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 指定された時間の間隔が経過した時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.01</br>
        /// </remarks> 
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;
            try
			{
				this.Cursor = Cursors.AppStarting;

				// 画面初期設定処理
				this.ScreenInitialSetting();
                
                // イベントキャンセルフラグ
                this._eventExecFlg = false;
                
                // フォームコントロールクラスクリエイト処理
                this.FormControlInfoCreate();

                // 生成するタブのKeyを設定
                string tabCreateKey = string.Empty;
                if ( this._iPara == ctInventoryPrepare )
                {
                    // 棚卸準備処理
                    tabCreateKey = NO0_INVENTORYPREPARE_TAB;
                }
                else
                {
                    // 過不足更新
                    tabCreateKey = NO1_JUSTENOUGH_TAB;
                }
                
                // タブ作成
                this.TabCreate(tabCreateKey);
                
                // タブアクティブ化処理
                // タブに表示するフォームクラスの情報を構築する
                this.TabActive(tabCreateKey);             
                
                // イベントキャンセルフラグ
                this._eventExecFlg = true;
              
                if(this.Main_UTabControl.SelectedTab != null)
                {
                    // Static領域の情報を画面に表示する
                    this.Form_Activated((Form)this.Main_UTabControl.SelectedTab.Tag, new EventArgs());
                }
               
			}
			finally
			{
				// イベントキャンセルフラグ
                this._eventExecFlg = true;

                this.Cursor = Cursors.Default;

                Program._form.Focus();
			}
        }

        #endregion

        #region StatusBar_MsgClear_Timer_Tick

        /// <summary>
        /// StatusBar_MsgClear_Timer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 指定された時間の間隔が経過した時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks> 
        private void StatusBar_MsgClear_Timer_Tick(object sender, EventArgs e)
        {
            StatusBar_MsgClear_Timer.Enabled = false;
			//// 5秒待機してから処理を実行
			if ( this._isMsgClearCansel )
			{
				this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = string.Empty;
				this._isMsgClearCansel = false;
			}
        }

        #endregion

        #region MDI子画面 Activeイベント(Form_Activated)
        /// <summary>
		/// MDI子画面のActiveイベント
		/// </summary>
		private void Form_Activated(object sender, System.EventArgs e)
		{
            
			if (!this._eventExecFlg)
				return;
			Form frm = (Form)sender;
            
			if (frm != null)
				// 子画面に対して再表示を実行させる
				ShowMdiChild();
		}
		#endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region MDI子画面 Deactivedイベント（Form_Deactivated）
        /// <summary>
		/// MDI子画面のDeactivedイベント
		/// </summary>
		private void Form_Deactivated(object sender, System.EventArgs e)
		{
		}

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region Main_ToolbarsManager

        /// <summary>
        /// TToolbarsManager.ToolClick イベント(Main_ToolbarsManager)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">ToolClickイベントに使用されるイベントパラメータ</param>
        private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = string.Empty;	// ステータスバーメッセージクリア
                this._isMsgClearCansel = false;	// ステータスバーメッセージクリアキャンセル
                switch (e.Tool.Key)
                {
                    // 終了ボタン
                    case ctCLOSE_BUTTONTOOLKEY:
                        this.Close();

                        break;
                    // 更新ボタン
                    case ctSAVE_BUTTONTOOLKEY:

                        // 入力チェック処理
                        if (this.InputCheck() != 0)
                            return;

                        // MDIフォーム(編集画面）の登録処理
                        SaveEditMdiChild();
                        break;
                    // 印刷ボタン
                    case ctPRINT_BUTTONTOOLKEY:
                        // 入力チェック処理
                        if (this.InputCheck() != 0)
                            return;

                        // MDIフォーム(編集画面）の登録処理
                        PrintEditMdiChild();

                        break;
                }
            }
            finally
            {
                this._isMsgClearCansel = true;
            }
        }
        
        #endregion

        #region Main_UTabControl

        /// <summary>
        /// タブ選択切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_UTabControl_SelectedTabChanged_1(object sender, SelectedTabChangedEventArgs e)
        {
            this.ToolBarButtonEnabledSetting();
        }

        #endregion

        #endregion
    }
}