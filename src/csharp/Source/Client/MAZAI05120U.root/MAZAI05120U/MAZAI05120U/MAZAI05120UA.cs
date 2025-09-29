//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力のメインフレーム。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 作 成 日  2007/04/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/24  修正内容 : フレームにログイン拠点名称を表示するよう修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/25  修正内容 : 編集ボタン追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]　保存前チェック処理を追加
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  2015/04/27 修正内容 : Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
//                                  Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 黄興貴
// 修 正 日  2015/05/12 修正内容 : Redmine#45745 #25 受入テスト障害No.1指摘の対応
//                                  文言が変わるのは抽出条件タブのみの修正
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  2015/05/22 修正内容 : Redmine#45745 編集メニューに品番検索を追加
//                                 MAZAI05120UA.Designer.csを修正
//----------------------------------------------------------------------------//
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

using Infragistics.Win.UltraWinTabControl;		// タブ
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;		// ツールバー

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸数入力メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸数入力メインフレームクラス</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.04.05</br>
    /// <br>UpDateNote : 2007.07.24 22013 kubo</br>
    ///						・フレームにログイン拠点名称を表示するよう修正
    /// <br>UpDateNote : 2007.07.25 22013 kubo</br>
    ///						・編集ボタン追加
    /// <br>           : 2009/05/14 照田 貴志　不具合対応[13260]</br>
	/// </remarks>
	public partial class MAZAI05120UA : Form
	{
		/// <summary>
		/// 棚卸数入力メインフレームコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸数入力メインフレームクラスの新しいインスタンスを作成する</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public MAZAI05120UA ()
		{
			InitializeComponent();

			// 初期データ
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;					// 企業コード
		}

		#region ■ Private Member
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		private Dictionary<string, FormControlInfo_InventInput> _formControlInfoDic = null;		//　フォームコントロールクラス辞書
		private string _enterpriseCode	= string.Empty;	// 企業コード
		private string _sectionCode		= string.Empty;	// ログイン拠点コード
		private string _sectionName		= string.Empty;	// ログイン拠点名称

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        private SecInfoAcs _secInfoAcs = null;			// 拠点情報アクセスクラス
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        private object _extractInfoObj = null;			// 抽出条件オブジェクト
        #endregion ■ Private Member

        #region ■ Private Const
        // アセンブリ関係定数
        private const string ct_AssemblyID					= "MAZAI05120U";							// アセンブリID
        private const string ct_ChildAsmID					= "MAZAI05130U";							// 子画面アセンブリID
        private const string ct_ChildClassID_Extract		= "Broadleaf.Windows.Forms.MAZAI05130UA";	// 抽出画面クラス厳密名
        private const string ct_ChildClassID_Result			= "Broadleaf.Windows.Forms.MAZAI05130UB";	// 抽出画面クラス厳密名
	
        // タブタイトル
        private const string ct_TabTitle_Extract			= "抽出条件入力";							// 抽出条件入力画面タブタイトル
        private const string ct_TabTitle_Result				= "棚卸入力";								// 棚卸数入力画面タブタイトル

        //// 棚卸モード名称
        //private const string ct_InventMode_Goods			= "商品毎";
        //private const string ct_InventMode_GoodsAndProduct	= "商品 + 製造番号毎";

        // 画面表示タブKey
        private const string ct_No0_InventExtract			= "No0_InventExtract";						// 抽出条件タブ
        private const string ct_No1_InventInput				= "No1_InventInput";						// 抽出結果タブ

        // ToolBarのKey
        // ボタン
        private const string ct_Tool_CloseButton			= "tool_Close";								// 終了
        private const string ct_Tool_CanselButton			= "tool_Cansel";							// 取消
        private const string ct_Tool_ExtractButton			= "tool_Extract";							// 抽出
        private const string ct_Tool_SaveButton				= "tool_Save";								// 保存
//		private const string ct_Tool_DetailButton			= "tool_Detail";						// 詳細
        private const string ct_Tool_NewButton				= "tool_New";								// 新規
        private const string ct_Tool_BarcodeReadButton		= "tool_BarcodeRead";						// バーコード読込
        // 2007.07.25 kubo add 
        private const string ct_Tool_DataEdit				= "tool_DataEdit";							// 編集
        private const string ct_Tool_GoodsSearchButton 　   = "tool_GoodsSearch";						// 品番検索 // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
        // ラベル
        private const string ct_Tool_LoginEmployee			= "tool_LoginEmployee";						// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName		= "tool_LoginEmployeeName";					// ログイン担当者名称

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        // 2007.07.24 kubo add ------------->
        private const string ct_Tool_InventSection			= "tool_InventSection";						// 棚卸拠点タイトル
        private const string ct_Tool_InventSectionName		= "tool_InventSectionName";					// 棚卸拠点名称
        // 2007.07.24 kubo add <-------------
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        // Container
		private const string ct_Tool_InventMoeContainer		= "tool_InventMoeContainer";				// 棚卸モード用コンテナツール
		#endregion ■ Private Const

		#region ■ Private Method
		#region ◆ 初期化関係
		#region ◎ 画面初期化処理
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面初期化処理</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void InitialSetting()
		{
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			// 拠点設定の取得
			if ( this._secInfoAcs == null )
			{
				this._secInfoAcs = new SecInfoAcs();
			}
			
			SecInfoSet secInfoSet = null;
			this._secInfoAcs.GetSecInfo( SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet );
			// 自拠点設定無し
			if( secInfoSet == null )
			{
				// 自拠点が設定されていない場合はログイン従業員の拠点情報を取得
				if( this._secInfoAcs.SecInfoSet != null ) 
					secInfoSet = this._secInfoAcs.SecInfoSet;
				// 自拠点が設定されていない場合
				else 
					// 例外をスローする(自拠点情報無し)
					throw( new Exception( "自拠点が設定されていません。" ) );
			}

			this._sectionCode = secInfoSet.SectionCode;
			this._sectionName = secInfoSet.SectionGuideNm;
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
            
            // フォームコントロールクラス辞書作成
			this._formControlInfoDic = this.CreateFormControlInfoDic();

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

			// ツールバー初期設定処理
			this.InitialToolbarSetting();
		}
		#endregion

		#region ◎ フォームコントロールクラス辞書作成処理
		/// <summary>
		/// フォームコントロールクラス辞書作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォームコントロールクラス辞書を作成</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private Dictionary<string, FormControlInfo_InventInput> CreateFormControlInfoDic()
		{
			Dictionary<string, FormControlInfo_InventInput> dic = new Dictionary<string, FormControlInfo_InventInput>();
			dic.Add(ct_No0_InventExtract, new FormControlInfo_InventInput(ct_No0_InventExtract, ct_ChildAsmID, ct_ChildClassID_Extract, ct_TabTitle_Extract, IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH]));
			dic.Add(ct_No1_InventInput	, new FormControlInfo_InventInput(ct_No1_InventInput,	ct_ChildAsmID, ct_ChildClassID_Result , ct_TabTitle_Result,	IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW]));
			return dic;
		}
		#endregion

		#region ◎ ツールバー初期設定処理
		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void InitialToolbarSetting()
		{
            this.utm_MainToolBarMng.Tools[ct_Tool_DataEdit].SharedProps.Visible = false;    //2009/05/21A　編集ボタンは使用しない

            // イメージリスト設定
			this.utm_MainToolBarMng.ImageListSmall = IconResourceManagement.ImageList16;

			// ツールアイコン設定
			this.SetIconForToolBar(ct_Tool_CloseButton			, Size16_Index.CLOSE);			// 終了
			this.SetIconForToolBar(ct_Tool_CanselButton			, Size16_Index.UNDO);			// 取消
			this.SetIconForToolBar(ct_Tool_ExtractButton		, Size16_Index.SEARCH);			// 抽出
			this.SetIconForToolBar(ct_Tool_SaveButton			, Size16_Index.SAVE);			// 保存
//			this.SetIconForToolBar(ct_Tool_DetailButton			, Size16_Index.DETAILS);		// 詳細
			this.SetIconForToolBar(ct_Tool_NewButton			, Size16_Index.NEW);			// 新規
            this.SetIconForToolBar(ct_Tool_GoodsSearchButton    , Size16_Index.SLIPSEARCH);     // 品番検索 // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
			this.SetIconForToolBar(ct_Tool_BarcodeReadButton	, Size16_Index.PACKAGEINPUT);	// バーコード読込
			// 2007.07.24 kubo add
			this.SetIconForToolBar(ct_Tool_LoginEmployee		, Size16_Index.EMPLOYEE		);	// ログイン担当者
			// 2007.07.25 kubo add
			this.SetIconForToolBar(ct_Tool_DataEdit				, Size16_Index.EDITING		);	// 編集

			// 担当者表示
			if (LoginInfoAcquisition.Employee != null)
			{
				LabelTool loginNameLabel = (LabelTool)this.utm_MainToolBarMng.Tools[ct_Tool_LoginEmployeeName];
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
			// 2007.07.24 kubo add ------------->
			this.SetIconForToolBar(ct_Tool_InventSection	, Size16_Index.BASE			);	// 棚卸拠点

			if ( this._sectionName != "" )
			{
				LabelTool sectionName = (LabelTool)this.utm_MainToolBarMng.Tools[ct_Tool_InventSectionName];
				if (sectionName != null ) sectionName.SharedProps.Caption = this._sectionName;
			}
			// 2007.07.24 kubo add ------------->
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
		}
		#endregion

		#region ◎ ツールアイコン設定処理
		/// <summary>
		/// ツールアイコン設定処理
		/// </summary>
		/// <param name="key">ToolのKey</param>
		/// <param name="size16_Index">イメージリストインデックス</param>
		/// <remarks>
		/// <br>Note       : ツールアイコンを設定する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void SetIconForToolBar(string key, Size16_Index size16_Index)
		{
			if (this.utm_MainToolBarMng.Tools.Exists(key))
			{
				this.utm_MainToolBarMng.Tools[key].SharedProps.AppearancesSmall.Appearance.Image = size16_Index;
			}
		}
		#endregion

		#region ◎ ツールボタンEnable設定処理
		/// <summary>
		/// ツールボタンEnable設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールボタンEnableを設定する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void SetToolButtonEnabled( System.Windows.Forms.Form targetForm )
		{
			// 棚卸数入力インターフェースを実装しているか？
			if ( targetForm is IInventInputMdiChild )
			{
				// 棚卸数入力インターフェースにフォームをキャスト
				IInventInputMdiChild iInventInputMdiChildForm = (IInventInputMdiChild)targetForm;

				SetToolEnabledProc( ct_Tool_CanselButton		, iInventInputMdiChildForm.IsCansel			);	// 取消
				SetToolEnabledProc( ct_Tool_ExtractButton		, iInventInputMdiChildForm.IsExtract		);	// 抽出
				SetToolEnabledProc( ct_Tool_SaveButton			, iInventInputMdiChildForm.IsSave			);	// 保存
//				SetToolEnabledProc( ct_Tool_DetailButton		, iInventInputMdiChildForm.IsDetail			);	// 詳細表示
				SetToolEnabledProc( ct_Tool_NewButton			, iInventInputMdiChildForm.IsNewInvent		);	// 新規棚卸
				SetToolEnabledProc( ct_Tool_BarcodeReadButton	, iInventInputMdiChildForm.IsBarcodeRead	);	// バーコード読込
				SetToolEnabledProc( ct_Tool_DataEdit			, iInventInputMdiChildForm.IsDataEdit		);	// 編集
                SetToolEnabledProc(ct_Tool_GoodsSearchButton    , iInventInputMdiChildForm.IsGoodsSearch);	// 品番検索  // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
			}
			else
			{
				SetToolEnabledProc( ct_Tool_CanselButton		, false	);	// 取消
				SetToolEnabledProc( ct_Tool_ExtractButton		, false	);	// 抽出
				SetToolEnabledProc( ct_Tool_SaveButton			, false );	// 保存
//				SetToolEnabledProc( ct_Tool_DetailButton		, false );	// 詳細表示
				SetToolEnabledProc( ct_Tool_NewButton			, false );	// 新規棚卸
				SetToolEnabledProc( ct_Tool_BarcodeReadButton	, false	);	// バーコード読込
				SetToolEnabledProc( ct_Tool_DataEdit			, false	);	// 編集
                SetToolEnabledProc(ct_Tool_GoodsSearchButton    , false);	// 品番検索  // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
			}
		}

		/// <summary>
		/// ツールボタンEnable設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールボタンEnableを設定する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		private void SetToolButtonEnabled( object targetForm )
		{
			if ( targetForm is IInventInputMdiChild )
			{
				SetToolButtonEnabled( (Form)targetForm );
			}
		}

		#endregion

		#region ◎ ツールアイコン設定処理
		/// <summary>
		/// ツールアイコン設定処理
		/// </summary>
		/// <param name="toolKey">ToolのKey</param>
		/// <param name="toolEnabled">イメージのイネーブル</param>
		/// <remarks>
		/// <br>Note       : ツールアイコンを設定する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
        /// <br>UpdateNote : 2015/05/12 黄興貴</br>
        /// <br>             11070149-00 Redmine#45745 #25 受入テスト障害No.1指摘の対応</br>
        /// <br>             文言が変わるのは抽出条件タブのみの修正<br>
		/// </remarks>
		private void SetToolEnabledProc( string toolKey, bool toolEnabled)
		{
			this.utm_MainToolBarMng.Tools[toolKey].SharedProps.Enabled = toolEnabled;
            // --- ADD 黄興貴 2015/05/12 Redmine#45745 文言が変わるのは抽出条件タブのみの修正 --------->>>>>
            if (toolEnabled)
            {
                switch (toolKey)
                {
                    case ct_Tool_SaveButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "保存(S)";
                            break;
                        }
                    case ct_Tool_NewButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "新規(N)";
                            break;
                        }
                    case ct_Tool_GoodsSearchButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "品番検索(F1)";
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (toolKey)
                {
                    case ct_Tool_SaveButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "保存(S)<br/>抽出後、棚卸入力で利用可能です。";
                            break;
                        }
                    case ct_Tool_NewButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "新規(N)<br/>抽出後、棚卸入力で利用可能です。";
                            break;
                        }
                    case ct_Tool_GoodsSearchButton:
                        {
                            this.utm_MainToolBarMng.Tools[toolKey].SharedProps.ToolTipTextFormatted = "品番検索(F1)<br/>抽出後、棚卸入力で利用可能です。";
                            break;
                        }
                    default:
                        break;
                }
            }
            // --- ADD 黄興貴 2015/05/12 Redmine#45745 文言が変わるのは抽出条件タブのみの修正 ---------<<<<<
		}
		#endregion

		#endregion

		#region ◆ タブ操作関係
		#region ◎ タブフォーム作成処理
		/// <summary>
		/// タブフォーム作成処理
		/// </summary>
		/// <param name="key">キー</param>
		/// <remarks>
		/// <br>Note       : Tabフォームを作成します。</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private bool TabCreate(string key)
		{
			// フォームコントロールクラス辞書にキーが存在しない場合は処理しない
			if (!this._formControlInfoDic.ContainsKey(key)) return false;

			FormControlInfo_InventInput info = this._formControlInfoDic[key];
			if (info.Form == null)
			{
				// タブ子画面作成
				if (!this.CreateTabForm(info)) return false;
			}
			else
			{
				this.utc_InventTab.Tabs[key].Visible = true;
				this.utc_InventTab.Tabs[key].Active = true;
				this.utc_InventTab.Tabs[key].Selected = true;
			}

			return true;
		}
		#endregion

		#region ◎ タブ子画面作成処理
		/// <summary>
		/// タブ子画面作成処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI子画面を作成する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private bool CreateTabForm(FormControlInfo_InventInput info)
		{
            if (info.ClassID == ct_ChildClassID_Extract)
            {
                info.Form = new MAZAI05130UA();	// 抽出条件画面インスタンス作成
                //info.Form = new MAZAI05130UB();	// 抽出結果画面インスタンス作成
            }
            else if (info.ClassID == ct_ChildClassID_Result)
            {
                info.Form = new MAZAI05130UB();	// 抽出結果画面インスタンス作成
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
			if ( info.Form is IInventInputMdiChild )
			{
				( (IInventInputMdiChild)info.Form ).ParentToolbarInventSettingEvent += new ParentToolbarInventSettingEventHandler(this.SetToolButtonEnabled);

				( (IInventInputMdiChild)info.Form ).EnterpriseCode = this._enterpriseCode;
				( (IInventInputMdiChild)info.Form ).SectionCode = this._sectionCode;
				( (IInventInputMdiChild)info.Form ).SectionName = this._sectionName;
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

			//// FormがIInventInputMdiChildインターフェースを実装しているならば画面表示処理を実行する
			//if ( info.Form is IInventInputMdiChild )
			//{
			//    ((IInventInputMdiChild)info.Form).Show( null );	// データの表示
			//}

			// タブコントロールにタブを追加する
			this.utc_InventTab.Controls.Add( targetTab.TabPage );
			this.utc_InventTab.Tabs.Add( targetTab );
			this.utc_InventTab.SelectedTab = targetTab;

			return true;
		}
		#endregion
		#endregion ◆ タブ操作処理

		#region ◆ Toolクリック処理関係
		#region ◎ 終了クリック処理
		/// <summary>
		/// 終了クリック処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 終了ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int CloseProc( )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			System.Windows.Forms.Form targetForm = null;

			// 表示されているタブに対して操作
			foreach ( UltraTab targetTab in this.utc_InventTab.Tabs )
			{
				targetForm = (Form)targetTab.Tag;

				if ( targetForm != null )
				{
					// 抽出結果画面が存在するならば終了前チェック(抽出結果画面で終了前チェックが入る可能性がある)
					status = ( (IInventInputMdiChild)targetForm ).BeforeClose( null );

					// 終了前チェックが正常じゃない場合は処理終了
					if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
						return status;
				}
				else
				{
					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}

			// ステータスが正常で帰ってきたときは自身の終了イベントを起動
			switch ( status )
			{
				case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
					this.Close();
					break;
				default:
					break;
			}

			return status;
		}
		#endregion

		#region ◎ 取消クリック処理
		/// <summary>
		/// 取消クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 取消ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int CanselProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			// 全ての子画面の取消クリック処理を実行
			status = ( (IInventInputMdiChild)targetForm ).Cansel( null );

			return status;
		}
		#endregion

		#region ◎ 抽出クリック処理
		/// <summary>
		/// 抽出クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 抽出ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int ExtractProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			SFCMN00299CA msgForm = new SFCMN00299CA();
			// 抽出中画面部品のインスタンスを作成
			msgForm.Title  = "抽出中";
			msgForm.Message = "棚卸データの抽出中です。";

	
			// 抽出前処理を実行して項目の変更があるかどうかをチェック
			status = ( (IInventInputMdiChild)targetForm ).BeforeExtract( null );

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

			try
			{
				// 抽出前処理が正常に終了したとき抽出処理を実行
				msgForm.Show();	// ダイアログ表示
				status = ( (IInventInputMdiChild)targetForm ).Extract(ref this._extractInfoObj );

				if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					// タブ作成されるのは抽出条件画面だけだからKeyは固定でOk
					// 抽出画面タブ作成
					if ( !this.TabCreate( ct_No1_InventInput) )
					{
						throw( new Exception( "タブ作成処理に失敗しました。" ) );
					}

					FormControlInfo_InventInput info = this._formControlInfoDic[ ct_No1_InventInput ];

					// FormがIInventInputMdiChildインターフェースを実装しているならば画面表示処理を実行する
					if ( (info.Form != null) && ( info.Form is IInventInputMdiChild ) )
					{

						((IInventInputMdiChild)info.Form).ShowData( this._extractInfoObj );
					}

				}
			}
			finally
			{
				msgForm.Close();
			}
			return status;
		}
		#endregion

		#region ◎ 保存クリック処理
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 保存クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int SaveProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 保存処理を実行
            SFCMN00299CA msgForm = new SFCMN00299CA();
            // 抽出中画面部品のインスタンスを作成
            msgForm.Title = "保存中";
            msgForm.Message = "棚卸データの保存中です。";

			try
			{
                msgForm.Show();
				status = ( (IInventInputMdiChild)targetForm ).Save( null );
			}
			finally
			{
                msgForm.Close();
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
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
            // ---ADD 2009/05/14 不具合対応[13260] --------------------------->>>>>
            int ret = ((IInventInputMdiChild)targetForm).BeforeSave(null);
            if (ret != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return ret;
            }
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------<<<<<

            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            this.Name,
                                            "登録してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return (0);
            }

            int status = ((IInventInputMdiChild)targetForm).Save(null);

            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 初期表示状態に戻す
                this.utc_InventTab.Tabs[ct_No0_InventExtract].Selected = true;
                this.utc_InventTab.Tabs.RemoveAt(this.utc_InventTab.Tabs.IndexOf(ct_No1_InventInput));

                this._formControlInfoDic = this.CreateFormControlInfoDic();
            }
            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------<<<<<

            return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region ◎ 詳細クリック処理
		/// <summary>
		/// 詳細クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 詳細ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int DetailProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			// 詳細表示
			status = ( (IInventInputMdiChild)targetForm ).ShowDetail( null );

			return status;
		}
		#endregion

		#region ◎ 新規クリック処理
		/// <summary>
		/// 新規クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 新規ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int NewProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			// 新規
			status = ( (IInventInputMdiChild)targetForm ).NewInvent( null );

			return status;
		}
		#endregion

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
        #region ◎ 品番検索処理
        /// <summary>
        /// 品番検索クリック処理
        /// </summary>
        /// <param name="targetForm">アクティブなタブのフォーム</param>
        /// <remarks>
        /// <br>Note       : 品番検索ボタンがクリックされたときに発生</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        private int GoodsSearchProc(Form targetForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 品番検索
            status = ((IInventInputMdiChild)targetForm).GoodsSearch(null);

            return status;
        }
        #endregion
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<

		#region ◎ バーコード読込クリック処理
		/// <summary>
		/// バーコード読込クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : バーコード読込ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private int BarcodeReadProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			// バーコード読込
			status = ( (IInventInputMdiChild)targetForm ).BarcodeRead( null );

			return status;
		}
		#endregion

		#region ◎ 編集クリック処理
		/// <summary>
		/// 編集クリック処理
		/// </summary>
		/// <param name="targetForm">アクティブなタブのフォーム</param>
		/// <remarks>
		/// <br>Note       : 編集ボタンがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		private int DataEditProc( Form targetForm )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			// 編集
			status = ( (IInventInputMdiChild)targetForm ).DataEdit( null );

			return status;
		}
		#endregion
		#endregion
		#endregion ■ Private Method

		#region ■ Control Event
		#region ◆ MAZAI05120UA Event
		#region ◎ MAZAI05120UA_Load
		/// <summary>
		/// MAZAI05120UA_Load
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがファイルを読み込むときに発生する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void MAZAI05120UA_Load ( object sender, EventArgs e )
		{
			try
			{
				// 初期設定処理
				this.InitialSetting();

				// 初期化タイマー起動
				this.Initial_Timer.Enabled = true;
			}
			catch ( Exception ex )
			{
				TMsgDisp.Show( 
					emErrorLevel.ERR_LEVEL_STOPDISP, 
					ct_AssemblyID, 
					ex.Message, 
					(int)ConstantManagement.MethodResult.ctFNC_CANCEL, 
					MessageBoxButtons.OK 
					);
			}
		}
		#endregion

		#region ◎ MAZAI05120UA_FormClosing
		/// <summary>
		/// MAZAI05120UA_FormClosing
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを閉じるときなどに発生する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void MAZAI05120UA_FormClosing ( object sender, FormClosingEventArgs e )
		{
			// フォームコントロール辞書が設定されていない場合は巣部に終了
			if ( this._formControlInfoDic == null )
				return;

            // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示対応 ----->>>>>
            FormControlInfo_InventInput infoForClose = this._formControlInfoDic[ct_No1_InventInput];

            // FormがIInventInputMdiChildインターフェースを実装しているならば画面表示処理を実行する
            if ((infoForClose.Form != null) && (infoForClose.Form is IInventInputMdiChild))
            {
                // 画面閉じる前に、変更チェック処理を行う
                if (!((IInventInputMdiChild)infoForClose.Form).ClosingCheck())
                {
                    // 変更した場合、画面閉じる付加
                    e.Cancel = true;
                    return;
                }
            }
            // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示対応 -----<<<<<

			foreach (KeyValuePair<string, FormControlInfo_InventInput> kvp in this._formControlInfoDic)
			{
			    FormControlInfo_InventInput info = kvp.Value;

			    if ((info.Form == null) || (info.Form.IsDisposed)) continue;

			    info.Form.Close();
			}

			//this.Close();
		}
		#endregion
		#endregion ◆ MAZAI05120UA Event

		#region ◆ utm_MainToolBarMng Event
		#region ◎ utm_MainToolBarMng_ToolClick
		/// <summary>
		/// utm_MainToolBarMng_ToolClick
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Toolがクリックされたときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void utm_MainToolBarMng_ToolClick ( object sender, ToolClickEventArgs e )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			// 選択中のタブを取得
			UltraTab activeTab = this.utc_InventTab.ActiveTab;
			System.Windows.Forms.Form targetForm = null;
			// アクティブなタブまたは、アクティブなタブのTagプロパティがnullなら処理をしない。
			if ( ( activeTab != null ) && ( activeTab.Tag != null ) )
			{
				targetForm = (Form)activeTab.Tag;
			}


			if ( e.Tool.Key.CompareTo(ct_Tool_CloseButton) == 0 )
			{
				if ( ( activeTab == null ) || targetForm == null )
				{
					this.Close();
				}
				else
				{
					// 終了のときは全てのタブの終了前イベントを実行するからActiveTabのインターフェース判断をしない
					status = this.CloseProc();// 終了
				}
			}
			// アクティブタブのフォームがIInventInputMdiChildインターフェースを実装しているときのみ実行
			else
			{
				if ( targetForm is IInventInputMdiChild )
				{
					if ( e.Tool.Key.CompareTo(ct_Tool_CanselButton) == 0 )
					{
						status = this.CanselProc( targetForm );// 取消
					}
					else if ( e.Tool.Key.CompareTo(ct_Tool_ExtractButton) == 0 )
					{
						status = this.ExtractProc( targetForm );// 抽出
					}
					else if ( e.Tool.Key.CompareTo(ct_Tool_SaveButton) == 0 )
					{
						status = this.SaveProc( targetForm );// 保存
					}
					//else if ( e.Tool.Key.CompareTo(ct_Tool_DetailButton) == 0 )
					//{
					//    status = this.DetailProc( targetForm );// 詳細
					//}
					else if ( e.Tool.Key.CompareTo(ct_Tool_NewButton) == 0 )
					{
						status = this.NewProc( targetForm );// 新規
					}
                    // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
                    else if (e.Tool.Key.CompareTo(ct_Tool_GoodsSearchButton) == 0)
                    {
                        status = this.GoodsSearchProc(targetForm);// 品番検索
                    }
                    // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<
					else if ( e.Tool.Key.CompareTo(ct_Tool_BarcodeReadButton) == 0 )
					{
						status = this.BarcodeReadProc( targetForm );// バーコード読込
					}
					else if ( e.Tool.Key.CompareTo(ct_Tool_DataEdit) == 0 )
					{
						status = this.DataEditProc( targetForm );
					}
				}
			}

			// 一応ステータスを返してきているが、メッセージ表示処理などは全て子画面で行う。
			// フレームで何か対応を入れることになったときのために一応記述。
			switch( status )
			{
				case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
					break;
				case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
					break;
				default:
					break;
			}
		}
		#endregion
		#endregion ◆ utm_MainToolBarMng Event

		#region ◆ Initial_Timer Event
		#region ◎ Initial_Timer_Tick
		/// <summary>
		/// Initial_Timer_Tick
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void Initial_Timer_Tick ( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;	// タイマーストップ

			try
			{
				// 抽出画面タブ作成
				if ( !this.TabCreate( ct_No0_InventExtract ) )
				{
					throw( new Exception( "タブ初期化処理に失敗しました。" ) );
				}

				// ツールバーEnabled設定
				// 指定したキーをもつタブが存在するときのみ設定
				if ( this.utc_InventTab.Tabs.Exists( ct_No0_InventExtract ) )
					this.SetToolButtonEnabled( (Form)this.utc_InventTab.Tabs[ct_No0_InventExtract].Tag );
			}
			catch ( Exception ex )
			{
				TMsgDisp.Show( 
					emErrorLevel.ERR_LEVEL_STOPDISP, 
					ct_AssemblyID, 
					ex.Message, 
					(int)ConstantManagement.MethodResult.ctFNC_CANCEL, 
					MessageBoxButtons.OK 
					);
			}
		}
		#endregion
		#endregion ◆ Initial_Timer Event

		#region ◆ utc_InventTab Event
		#region ◎ utc_InventTab_SelectedTabChanged
		/// <summary>
		/// utc_InventTab_SelectedTabChanged
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 選択されているタブが切り替わった後に発生する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void utc_InventTab_SelectedTabChanged ( object sender, SelectedTabChangedEventArgs e )
		{
			UltraTab activeTab = this.utc_InventTab.ActiveTab;

			if ( activeTab != null )
			{
				this.SetToolButtonEnabled( (Form)activeTab.Tag );

                // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                Form targetForm = (Form)activeTab.Tag;
                if (targetForm.Name == ct_TabTitle_Extract)
                {
                    // 抽出条件入力
                    this.MainStatusBar.Panels[0].Text = "";
                }
                else
                {
                    // 棚卸入力
                    this.MainStatusBar.Panels[0].Text = "ESC：棚卸数、日付クリア";
                }
                // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
            }
		}
		#endregion

		#region ◎ utc_InventTab_SelectedTabChanged
		/// <summary>
		/// utc_InventTab_SelectedTabChanged
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 選択されているタブが切り替わる前に発生する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		private void utc_InventTab_SelectedTabChanging ( object sender, SelectedTabChangingEventArgs e )
		{
			UltraTab selectedTab = this.utc_InventTab.SelectedTab;

			// ActiveTabを取得できたら
			if ( selectedTab != null )
			{
				// ActiveTabのフォームがIInventInputMdiChildインターフェースを実装していたら
				if ( ((Form)selectedTab.Tag) is IInventInputMdiChild )
				{
					// タブ変更前イベントを実行
					((IInventInputMdiChild)((Form)selectedTab.Tag)).BeforeTabChange( null );
				}
			}
		}
		#endregion
		#endregion ◆ utc_InventTab Event
		#endregion ■ Control Event
	}
}