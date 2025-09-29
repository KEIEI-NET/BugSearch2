using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上目標設定メインフレーム
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上目標設定メインフレームクラス</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/10/08</br>
	/// </remarks>
	public partial class PMKHN09250UA : Form
	{
        #region ■ Private Const

        private const string ct_AssemblyID = "PMKHN09250U";							    // アセンブリID
        private const string ct_ChildAsmID = "PMKHN09251U";							    // 子画面アセンブリID
        private const string ct_ChildClassID = "Broadleaf.Windows.Forms.PMKHN09251UA";	// クラス厳密名
        private const string ct_TabTitle = "売上目標設定";							    // 画面タブタイトル
        private const string ct_No0_SalesTarget = "SalesTarget";						// タブ
        private const string ct_Tool_CloseButton = "tool_Close";						// 終了
        private const string ct_Tool_NewButton = "tool_New";							// 新規
        private const string ct_Tool_SaveButton = "tool_Save";							// 保存
        private const string ct_Tool_LogicalDeleteButton = "tool_LogicalDelete";		// 論理削除
        private const string ct_Tool_DeleteButton = "tool_Delete";						// 削除
        private const string ct_Tool_RevivalButton = "tool_Revival";					// 復活
        private const string ct_Tool_UndoButton = "tool_Undo";					        // 元に戻す
        private const string ct_Tool_CalcButton = "tool_Calc";					        // 比率から計算
        private const string ct_Tool_RenewalButton = "tool_Renewal";					// 最新情報
        private const string ct_Tool_LoginEmployee = "tool_LoginEmployee";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "tool_LoginEmployeeName";		// ログイン担当者名称
        #endregion ■ Private Const

        #region ■ Private Member

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //　フォームコントロールクラス辞書
        private Dictionary<string, FormControlInfo_InventInput> _formControlInfoDic = null;

        #endregion ■ Private Member

        #region ■ Constructor
        /// <summary>
		/// 売上目標設定メインフレームコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上目標設定メインフレームクラスの新しいインスタンスを作成する</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public PMKHN09250UA ()
		{
			InitializeComponent();

            PMKHN09251UA form = new PMKHN09251UA();
            ((ISalesTargetMDIChild)form).ParentToolbarSalesTargetEvent += new ParentToolbarSalesTargetEventHandler(this.SetToolButtonVisible);
        }

        #endregion ■ Constructor

        #region ■ Private Method
        /// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面初期化処理</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private void InitialSetting()
		{
            // フォームコントロールクラス辞書作成
			this._formControlInfoDic = CreateFormControlInfoDic();

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			// ツールバー初期設定処理
			InitialToolbarSetting();
		}

		/// <summary>
		/// フォームコントロールクラス辞書作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォームコントロールクラス辞書を作成</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private Dictionary<string, FormControlInfo_InventInput> CreateFormControlInfoDic()
		{
			Dictionary<string, FormControlInfo_InventInput> dic = new Dictionary<string, FormControlInfo_InventInput>();
            dic.Add(ct_No0_SalesTarget, new FormControlInfo_InventInput(ct_No0_SalesTarget, ct_ChildAsmID, ct_ChildClassID, ct_TabTitle, IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH]));
			return dic;
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行う</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private void InitialToolbarSetting()
		{
			// イメージリスト設定
			this.utm_MainToolBarMng.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
			// ツールアイコン設定
            //----------------------------
            // 終了
            this.utm_MainToolBarMng.Tools[ct_Tool_CloseButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 新規
            this.utm_MainToolBarMng.Tools[ct_Tool_NewButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // 保存
            this.utm_MainToolBarMng.Tools[ct_Tool_SaveButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 論理削除
            this.utm_MainToolBarMng.Tools[ct_Tool_LogicalDeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 削除
            this.utm_MainToolBarMng.Tools[ct_Tool_DeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 復活
            this.utm_MainToolBarMng.Tools[ct_Tool_RevivalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // 元に戻す
            this.utm_MainToolBarMng.Tools[ct_Tool_UndoButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // 比率から計算
            this.utm_MainToolBarMng.Tools[ct_Tool_CalcButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;
            // 最新情報
            this.utm_MainToolBarMng.Tools[ct_Tool_RenewalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ログイン担当者
            this.utm_MainToolBarMng.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// 担当者表示
			if (LoginInfoAcquisition.Employee != null)
			{
				LabelTool loginNameLabel = (LabelTool)this.utm_MainToolBarMng.Tools[ct_Tool_LoginEmployeeName];
                if (loginNameLabel != null)
                {
                    loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
                }
			}
		}

        /// <summary>
		/// ツールボタンEnable設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールボタンEnableを設定する</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private void SetToolButtonVisible(Form targetForm)
		{
			// 売上目標設定インターフェースを実装しているか？
			if (targetForm is ISalesTargetMDIChild)
			{
                // 売上目標設定インターフェースにフォームをキャスト
                ISalesTargetMDIChild iRateMDIChildForm = (ISalesTargetMDIChild)targetForm;
                // 新規
                this.utm_MainToolBarMng.Tools[ct_Tool_NewButton].SharedProps.Visible = iRateMDIChildForm.IsNew;
                // 保存
                this.utm_MainToolBarMng.Tools[ct_Tool_SaveButton].SharedProps.Visible = iRateMDIChildForm.IsSave;
                // 論理削除
                this.utm_MainToolBarMng.Tools[ct_Tool_LogicalDeleteButton].SharedProps.Visible = iRateMDIChildForm.IsLogicalDelete;
                // 削除
                this.utm_MainToolBarMng.Tools[ct_Tool_DeleteButton].SharedProps.Visible = iRateMDIChildForm.IsDelete; 
                // 復活
                this.utm_MainToolBarMng.Tools[ct_Tool_RevivalButton].SharedProps.Visible = iRateMDIChildForm.IsRevival;
                // 元に戻す
                this.utm_MainToolBarMng.Tools[ct_Tool_UndoButton].SharedProps.Visible = iRateMDIChildForm.IsUndo;
                // 比率から計算
                this.utm_MainToolBarMng.Tools[ct_Tool_CalcButton].SharedProps.Visible = iRateMDIChildForm.IsCalc;
                // 最新情報
                this.utm_MainToolBarMng.Tools[ct_Tool_RenewalButton].SharedProps.Visible = iRateMDIChildForm.IsRenewal; 
			}
		}
		
        /// <summary>
		/// ツールボタンEnable設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールボタンEnableを設定する</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		private void SetToolButtonVisible( object targetForm )
		{
			if ( targetForm is ISalesTargetMDIChild )
			{
				SetToolButtonVisible( (Form)targetForm );
			}
		}

		/// <summary>
		/// タブフォーム作成処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを作成します。</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private bool TabCreate(string key)
		{
			// フォームコントロールクラス辞書にキーが存在しない場合は処理しない
			if (!this._formControlInfoDic.ContainsKey(key)) return false;

			FormControlInfo_InventInput info = this._formControlInfoDic[key];
			if (info.Form == null)
			{
				// タブ子画面作成
				if (!CreateTabForm(info)) return false;
			}
			else
			{
				this.utc_InventTab.Tabs[key].Visible = true;
				this.utc_InventTab.Tabs[key].Active = true;
				this.utc_InventTab.Tabs[key].Selected = true;
			}

			return true;
		}

		/// <summary>
		/// タブ子画面作成処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI子画面を作成する</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// </remarks>
		private bool CreateTabForm(FormControlInfo_InventInput info)
		{
            if (info.ClassID == ct_ChildClassID)
            {
                info.Form = new PMKHN09251UA();
            }

			// info.Formがnullならば(画面の作成に失敗している)処理を終了
			if (info.Form == null) return false;

			// フォームプロパティ変更
			info.Form.AutoScroll = true;
			info.Form.Dock = DockStyle.Fill;
			info.Form.FormBorderStyle = FormBorderStyle.None;
			info.Form.Name = info.Name;
			info.Form.TopLevel = false;

            // インターフェースの実装を確認し、実装されているならばプロパティを設定
            if (info.Form is ISalesTargetMDIChild)
            {
                ((ISalesTargetMDIChild)info.Form).ParentToolbarSalesTargetEvent += new ParentToolbarSalesTargetEventHandler(SetToolButtonVisible);
            }

			// タブの外観を設定
			UltraTab targetTab = new UltraTab();
			targetTab.Text = info.Name;
			targetTab.Key = info.Key;
			targetTab.Tag = info.Form;
			targetTab.Appearance.Image = info.Icon;
			targetTab.Appearance.BackColor = Color.White;
			targetTab.Appearance.BackColor2 = Color.Lavender;
			targetTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
			targetTab.ActiveAppearance.BackColor = Color.White;
			targetTab.ActiveAppearance.BackColor2 = Color.LightPink;
			targetTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
			targetTab.ActiveAppearance.FontData.Bold = DefaultableBoolean.True;

			// タブコントロールに追加するタブページをインスタンス化する
			targetTab.TabPage = new UltraTabPageControl();
			// タブページにフォームをバインド
			targetTab.TabPage.Controls.Add(info.Form);
			
            info.Form.Show();	// 画面の初期設定

			// タブコントロールにタブを追加する
			this.utc_InventTab.Controls.Add( targetTab.TabPage );
			this.utc_InventTab.Tabs.Add( targetTab );
			this.utc_InventTab.SelectedTab = targetTab;

            ((ISalesTargetMDIChild)info.Form).SetFocus();
			return true;
		}

        /// <summary>
        /// 終了クリック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int CloseProc()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            Form targetForm = null;

            // 表示されているタブに対して操作
            foreach (UltraTab targetTab in this.utc_InventTab.Tabs)
            {
                targetForm = (Form)targetTab.Tag;

                if (targetForm != null)
                {
                    // 終了前チェック
                    status = ((ISalesTargetMDIChild)targetForm).BeforeClose();

                    // 終了前チェックが正常じゃない場合は処理終了
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return status;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }

            // ステータスが正常で帰ってきたときは自身の終了イベントを起動
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    Close();
                    break;
                default:
                    break;
            }

            return status;
        }

        /// <summary>
        /// 新規クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 新規ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int NewProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 新規
            status = ((ISalesTargetMDIChild)targetForm).New();

            return status;
        }

		/// <summary>
        /// 保存クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int SaveProc(Form targetForm)
        {
            int status = ((ISalesTargetMDIChild)targetForm).Save();

            return status;
        }

        /// <summary>
        /// 論理削除クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 論理削除ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 削除
            status = ((ISalesTargetMDIChild)targetForm).LogicalDelete();

            return status;
        }

        /// <summary>
        /// 削除クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 削除ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int DeleteProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 削除
            status = ((ISalesTargetMDIChild)targetForm).Delete();

            return status;
        }

        /// <summary>
        /// 復活クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 復活
            status = ((ISalesTargetMDIChild)targetForm).Revival();

            return status;
        }

        /// <summary>
        /// 元に戻すクリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 元に戻すボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int UndoProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 復活
            status = ((ISalesTargetMDIChild)targetForm).Undo();

            return status;
        }

        /// <summary>
        /// 比率から計算クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 比率から計算ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int CalcProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 復活
            status = ((ISalesTargetMDIChild)targetForm).Calc();

            return status;
        }

        /// <summary>
        /// 最新情報クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 最新情報ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RenewalProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 最新情報取得
            status = ((ISalesTargetMDIChild)targetForm).Renewal();

            return status;
        }

		#endregion ■ Private Method

		#region ■ Control Event

        /// <summary>
        /// PMKHN09250UA_Load
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがファイルを読み込むときに発生する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void PMKHN09250UA_Load(object sender, EventArgs e)
        {
            try
            {
                // 初期設定処理
                InitialSetting();

                // 初期化タイマー起動
                Initial_Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                              ct_AssemblyID,
                              ex.Message,
                              (int)ConstantManagement.MethodResult.ctFNC_CANCEL,
                              MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// PMKHN09250UA_FormClosing
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるときなどに発生する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void PMKHN09250UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // フォームコントロール辞書が設定されていない場合はすぐに終了
            if (this._formControlInfoDic == null)
            {
                return;
            }

            foreach (KeyValuePair<string, FormControlInfo_InventInput> kvp in this._formControlInfoDic)
            {
                FormControlInfo_InventInput info = kvp.Value;

                if ((info.Form == null) || (info.Form.IsDisposed))
                {
                    continue;
                }

                info.Form.Close();
            }
        }
		
        /// <summary>
        /// utm_MainToolBarMng_ToolClick
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Toolがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void utm_MainToolBarMng_ToolClick(object sender, ToolClickEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // 選択中のタブを取得
            UltraTab activeTab = this.utc_InventTab.ActiveTab;
            Form targetForm = null;

            // アクティブなタブまたは、アクティブなタブのTagプロパティがnullなら処理をしない。
            if ((activeTab != null) && (activeTab.Tag != null))
            {
                targetForm = (Form)activeTab.Tag;
            }

            if (e.Tool.Key.CompareTo(ct_Tool_CloseButton) == 0)
            {
                if ((activeTab == null) || targetForm == null)
                {
                    this.Close();
                }
                else
                {
                    // 終了のときは全てのタブの終了前イベントを実行するからActiveTabのインターフェース判断をしない
                    status = CloseProc();
                }
            }
            // アクティブタブのフォームがISalesTargetMDIChildインターフェースを実装しているときのみ実行
            else
            {
                if (targetForm is ISalesTargetMDIChild)
                {
                    if (e.Tool.Key.CompareTo(ct_Tool_CloseButton) == 0)
                    {
                        // 終了処理
                        status = CloseProc();
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_NewButton) == 0)
                    {
                        // 新規処理
                        status = NewProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_SaveButton) == 0)
                    {
                        // 保存処理
                        status = SaveProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_LogicalDeleteButton) == 0)
                    {
                        // 論理削除処理
                        status = LogicalDeleteProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_DeleteButton) == 0)
                    {
                        // 削除処理
                        status = DeleteProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_RevivalButton) == 0)
                    {
                        // 復活処理
                        status = RevivalProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_UndoButton) == 0)
                    {
                        // 元に戻す処理
                        status = UndoProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_CalcButton) == 0)
                    {
                        // 比率から計算処理
                        status = CalcProc(targetForm);
                    }
                    else if (e.Tool.Key.CompareTo(ct_Tool_RenewalButton) == 0)
                    {
                        // 最新情報処理
                        status = RenewalProc(targetForm);
                    }
                }
            }
        }

        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            try
            {
                // 抽出画面タブ作成
                if (!TabCreate(ct_No0_SalesTarget))
                {
                    throw (new Exception("タブ初期化処理に失敗しました。"));
                }

                // ツールバーEnabled設定
                // 指定したキーをもつタブが存在するときのみ設定
                if (this.utc_InventTab.Tabs.Exists(ct_No0_SalesTarget))
                {
                    SetToolButtonVisible((Form)this.utc_InventTab.Tabs[ct_No0_SalesTarget].Tag);
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                              ct_AssemblyID,
                              ex.Message,
                              (int)ConstantManagement.MethodResult.ctFNC_CANCEL,
                              MessageBoxButtons.OK);
            }
        }

		#endregion ■ Control Event
	}
}