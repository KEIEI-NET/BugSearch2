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
	/// 掛率マスタメインフレーム
	/// </summary>
	/// <remarks>
    /// <br>Note       : 掛率マスタメインフレームクラス</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/09/25</br>
    /// <br>UpdateNote : 2011/08/05 caohh</br>
    /// <br>              NSユーザー改良要望一覧連番265の対応</br>
    /// <br>UpdateNote : 2011/09/14 wangf</br>
    /// <br>              NSユーザー改良要望一覧連番265についてRedMine#25013の対応、デザインファイル改修のみ、本体ソース改修ない</br>
    /// <br>UpdateNote : 2013/04/15 李占川</br>
    /// <br>管理番号   : 10901273-00 2013/05/15配信分 </br>
    /// <br>           : Redmine#35352 メニューのファイルのリストの修正。「PMKHN09300UA.designer.cs」のみを修正する</br>
	/// </remarks>
	public partial class PMKHN09300UA : Form
	{
        #region ■ Private Const

        private const string ct_AssemblyID = "PMKHN09300U";							    // アセンブリID
        private const string ct_ChildAsmID = "PMKHN09302U";							    // 子画面アセンブリID
        private const string ct_ChildClassID = "Broadleaf.Windows.Forms.PMKHN09302UA";	// クラス厳密名
        private const string ct_TabTitle = "掛率マスタ";							    // 画面タブタイトル
        private const string ct_No0_Rate = "Rate";						                // タブ
        private const string ct_Tool_CloseButton = "tool_Close";						// 終了
        private const string ct_Tool_NewButton = "tool_New";							// 新規
        private const string ct_Tool_SaveButton = "tool_Save";							// 保存
        private const string ct_Tool_DeleteButton = "tool_Delete";						// 削除
        private const string ct_Tool_RevivalButton = "tool_Revival";					// 復活
        private const string ct_Tool_RenewalButton = "tool_Renewal";					// 最新情報
        private const string ct_Tool_LoginEmployee = "tool_LoginEmployee";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "tool_LoginEmployeeName";		// ログイン担当者名称
        //----- ADD 2010/08/10----------<<<<<
        private const string ct_Tool_GuideButton = "tool_Guide";				        // ガイドボタン
        //----- ADD 2010/08/10---------->>>>>
        // ----- ADD caohh 2011/08/05 ------>>>>>
        private const string ct_Tool_SetUpButton = "tool_SetUp";				        // 設定ボタン
        // ----- ADD caohh 2011/08/05 ------<<<<<
        #endregion ■ Private Const

        #region ■ Private Member

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //　フォームコントロールクラス辞書
        private Dictionary<string, FormControlInfo_InventInput> _formControlInfoDic = null;

        #endregion ■ Private Member

        #region ■ Constructor
        /// <summary>
		/// 掛率マスタメインフレームコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率マスタメインフレームクラスの新しいインスタンスを作成する</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/09/25</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public PMKHN09300UA ()
		{
			InitializeComponent();

            PMKHN09302UA form = new PMKHN09302UA();
            ((IRateMDIChild)form).ParentToolbarRateSettingEvent += new ParentToolbarRateSettingEventHandler(this.SetToolButtonEnabled);
        }

        #endregion ■ Constructor

        #region ■ Private Method
        /// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面初期化処理</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/09/25</br>
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
		/// <br>Date       : 2008/09/25</br>
		/// </remarks>
		private Dictionary<string, FormControlInfo_InventInput> CreateFormControlInfoDic()
		{
			Dictionary<string, FormControlInfo_InventInput> dic = new Dictionary<string, FormControlInfo_InventInput>();
            dic.Add(ct_No0_Rate, new FormControlInfo_InventInput(ct_No0_Rate, ct_ChildAsmID, ct_ChildClassID, ct_TabTitle, IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH]));
			return dic;
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行う</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 楊明俊 PM1012対応</br>
        /// <br>             キーボード操作の改良を行う</br>
        /// <br>Update Note: 2011/08/05 caohh</br>
        /// <br>             NSユーザー改良要望一覧連番265の対応</br>
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
            // 削除
            this.utm_MainToolBarMng.Tools[ct_Tool_DeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 復活
            this.utm_MainToolBarMng.Tools[ct_Tool_RevivalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // 最新情報
            this.utm_MainToolBarMng.Tools[ct_Tool_RenewalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ログイン担当者
            this.utm_MainToolBarMng.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            //----- ADD 2010/08/10---------->>>>>
            // ガイドボタン
            this.utm_MainToolBarMng.Tools[ct_Tool_GuideButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            //----- ADD 2010/08/10----------<<<<<
            // ----- ADD caohh 2011/08/05 ------>>>>>
            // 設定ボタン
            this.utm_MainToolBarMng.Tools[ct_Tool_SetUpButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // ----- ADD caohh 2011/08/05 ------<<<<<
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
		/// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2011/08/05 caohh</br>
        /// <br>             NSユーザー改良要望一覧連番265の対応</br>
		/// </remarks>
		private void SetToolButtonEnabled(Form targetForm)
		{
			// 掛率マスタインターフェースを実装しているか？
			if (targetForm is IRateMDIChild)
			{
                // 掛率マスタインターフェースにフォームをキャスト
                IRateMDIChild iRateMDIChildForm = (IRateMDIChild)targetForm;
                // 新規
                this.utm_MainToolBarMng.Tools[ct_Tool_NewButton].SharedProps.Enabled = iRateMDIChildForm.IsNew;
                // 保存
                this.utm_MainToolBarMng.Tools[ct_Tool_SaveButton].SharedProps.Enabled = iRateMDIChildForm.IsSave;
                // 削除
                this.utm_MainToolBarMng.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = iRateMDIChildForm.IsDelete;
                // 復活
                this.utm_MainToolBarMng.Tools[ct_Tool_RevivalButton].SharedProps.Enabled = iRateMDIChildForm.IsRevival;
                // 最新情報
                this.utm_MainToolBarMng.Tools[ct_Tool_RenewalButton].SharedProps.Enabled = iRateMDIChildForm.IsRenewal;
                //-----ADD 2010/08/09---------->>>>>
                // ガイドボタン
                this.utm_MainToolBarMng.Tools[ct_Tool_GuideButton].SharedProps.Enabled = iRateMDIChildForm.IsGuide; 
                //-----ADD 2010/08/09----------<<<<<
                // ----- ADD caohh 2011/08/05 ------>>>>>
                // 設定ボタン
                this.utm_MainToolBarMng.Tools[ct_Tool_SetUpButton].SharedProps.Enabled = iRateMDIChildForm.IsSetUp; 
                // ----- ADD caohh 2011/08/05 ------<<<<<
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
		private void SetToolButtonEnabled( object targetForm )
		{
			if ( targetForm is IRateMDIChild )
			{
				SetToolButtonEnabled( (Form)targetForm );
			}
		}

		/// <summary>
		/// タブフォーム作成処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを作成します。</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/09/25</br>
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
		/// <br>Date       : 2008/09/25</br>
		/// </remarks>
		private bool CreateTabForm(FormControlInfo_InventInput info)
		{
            if (info.ClassID == ct_ChildClassID)
            {
                info.Form = new PMKHN09302UA();
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
            if (info.Form is IRateMDIChild)
            {
                ((IRateMDIChild)info.Form).ParentToolbarRateSettingEvent += new ParentToolbarRateSettingEventHandler(SetToolButtonEnabled);
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

			return true;
		}

        /// <summary>
        /// 終了クリック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
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
                    status = ((IRateMDIChild)targetForm).BeforeClose(null);

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
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int NewProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 新規
            status = ((IRateMDIChild)targetForm).New(null);

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
            int status = ((IRateMDIChild)targetForm).Save(null);

            return status;
        }
        //-----ADD 2010/08/10---------->>>>>

        /// <summary>
        /// ガイドクリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : ガイドボタンがクリックされたときに発生</br>
        /// <br>Programer  : 楊明俊</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private int GuideProc(Form targetForm)
        {
            int status = ((IRateMDIChild)targetForm).Guide(null);

            return status;
        }

        //-----ADD 2010/08/10----------<<<<<

        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary>
        /// 設定クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 設定ボタンがクリックされたときに発生</br>
        /// <br>Programer  : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        private int SetUpProc(Form targetForm)
        {
            int status = ((IRateMDIChild)targetForm).SetUp(null);

            return status;
        }
        //-----ADD caohh 2011/08/05 ----------<<<<<

        /// <summary>
        /// 削除クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 削除ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int DeleteProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 削除
            status = ((IRateMDIChild)targetForm).Delete(null);

            return status;
        }

        /// <summary>
        /// 復活クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int RevivalProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 復活
            status = ((IRateMDIChild)targetForm).Revival(null);

            return status;
        }

        /// <summary>
        /// 最新情報クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 最新情報ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int RenewalProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 最新情報取得
            status = ((IRateMDIChild)targetForm).Renewal(null);

            return status;
        }

		#endregion ■ Private Method

		#region ■ Control Event

        /// <summary>
        /// MAZAI05120UA_Load
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがファイルを読み込むときに発生する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void MAZAI05120UA_Load(object sender, EventArgs e)
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
        /// MAZAI05120UA_FormClosing
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるときなどに発生する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void MAZAI05120UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 楊明俊 PM1012対応</br>
        /// <br>             キーボード操作の改良を行う</br>
        /// <br>Update Note: 2011/08/05 caohh</br>
        /// <br>             NSユーザー改良要望一覧連番265の対応</br>
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
            // アクティブタブのフォームがIRateMDIChildインターフェースを実装しているときのみ実行
            else
            {
                if (targetForm is IRateMDIChild)
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
                    //-----ADD 2010/08/10---------->>>>>
                    else if (e.Tool.Key.CompareTo(ct_Tool_GuideButton) == 0)
                    {
                        // ガイド処理
                        status = GuideProc(targetForm);
                    }
                    //-----ADD 2010/08/10----------<<<<<
                    // ----- ADD caohh 2011/08/05 ------>>>>>
                    else if (e.Tool.Key.CompareTo(ct_Tool_SetUpButton) == 0) 
                    {
                        // 設定処理
                        status = SetUpProc(targetForm);
                    }
                    // ----- ADD caohh 2011/08/05 ------>>>>>
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
                    else if (e.Tool.Key.CompareTo(ct_Tool_RenewalButton) == 0)
                    {
                        // 最新情報取得処理
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
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            try
            {
                // 抽出画面タブ作成
                if (!TabCreate(ct_No0_Rate))
                {
                    throw (new Exception("タブ初期化処理に失敗しました。"));
                }

                // ツールバーEnabled設定
                // 指定したキーをもつタブが存在するときのみ設定
                if (this.utc_InventTab.Tabs.Exists(ct_No0_Rate))
                {
                    SetToolButtonEnabled((Form)this.utc_InventTab.Tabs[ct_No0_Rate].Tag);
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