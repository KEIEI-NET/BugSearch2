using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.CodeDom.Compiler;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Drawing.Printing;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票印字位置設定UI
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票の印字位置を設定する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: 2008.03.19 22024 寺坂誉志</br>
	/// <br>             : １．帳票の抽出条件に日付系項目が含まれない状態での登録を不可とする。</br>
	/// <br>             : ２．SummaryGroupに存在しないGroupHeaderが指定されていると</br>
	/// <br>             : 　　印刷時にエラーが発生する不具合修正。</br>
	/// <br>             : ３．抽出条件の必須条件の入力チェックが行なわれるように修正。</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008.05.21 22018 鈴木正臣</br>
    /// <br>             : １．PM.NS向け変更。</br>
    /// <br>             : ２．ActiveReportのバージョンアップ対応</br>
	/// </remarks>
	public partial class SFANL08105UA : Form, IFreeSheetMainFrame
	{
		#region Enum
		/// <summary>ツールバーモード</summary>
		private enum LayoutToolbarModes
		{
			/// <summary>単一選択</summary>
			SingleControl,
			/// <summary>二コントロール選択</summary>
			TwoControls,
			/// <summary>複数選択</summary>
			MultiControls,
			/// <summary>未選択</summary>
			NoControls,
		}

		/// <summary>終了モード</summary>
		private enum ExitMode
		{
			/// <summary>新規作成</summary>
			CreateNew,
			/// <summary>画面終了</summary>
			Close,
		}

		/// <summary>帳票使用区分種別</summary>
		internal enum PrintPaperUseDivcdKind
		{
			/// <summary>帳票</summary>
			Report = 1,
			/// <summary>伝票</summary>
			Slip = 2,
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            ///// <summary>DM帳票</summary>
            //DMReport = 3,
            ///// <summary>DMはがき</summary>
            //DMPostCard = 4,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            /// <summary>請求書</summary>
            DmdBill = 5,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
        /// <summary>
        /// 自由帳票特殊用途区分
        /// </summary>
        internal enum FreePrtPprSpPrpseCd
        {
            EstimateForm = 1, // 見積書
            StockReturnSlip = 4, // 仕入返品
            StockMoveSlip = 15, // 在庫移動
            UoeSlip = 16, // UOE伝票
            DmdSum = 50, // 合計請求書
            DmdDetail = 60, // 明細請求書
            DmdSlipSum = 70, // 伝票合計請求書
            DmdRect = 80, // 領収書
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD

		/// <summary>自由帳票項目コード種別</summary>
		internal enum FreePrtPaperItemCdKind
		{
			/// <summary>集計項目</summary>
			SummaryTextBox = 1,
			/// <summary>発行日付（和暦）</summary>
			DateJpFormal = 2,
			/// <summary>発行日付（和暦・略）</summary>
			DateJpAbbr = 3,
			/// <summary>発行日付（西暦）</summary>
			DateAdFormal = 4,
			/// <summary>発行時間（HH:MM）</summary>
			TimeAdFormal = 5,
			/// <summary>発行時間（HH時MM分）</summary>
			TimeJpFormal = 6,
			/// <summary>抽出条件</summary>
			ExtrCondition = 7,
			/// <summary>共通フッター1</summary>
			CommonFooter1 = 8,
			/// <summary>共通フッター2</summary>
			CommonFooter2 = 9,
			/// <summary>固定文字</summary>
			LiteralLabel = 10,
			/// <summary>画像</summary>
			Picture = 11,
			/// <summary>枠線</summary>
			Shap = 12,
			/// <summary>直線</summary>
			Line = 13,
			/// <summary>ソート順1</summary>
			SortOder1 = 14,
			/// <summary>ソート順2</summary>
			SortOder2 = 15,
			/// <summary>ソート順3</summary>
			SortOder3 = 16,
			/// <summary>ソート順4</summary>
			SortOder4 = 17,
			/// <summary>ソート順5</summary>
			SortOder5 = 18,
			/// <summary>固定文字（TextBox）</summary>
			/// <remarks>使用禁止</remarks>
			TextBox = 19,
			/// <summary>ページ番号</summary>
			PageNumber = 20,
			/// <summary>総ページ番号</summary>
			TotalPageNumber = 21,
			/// <summary>行番号（5行刻み）</summary>
			RowNumber5 = 22,
			/// <summary>行番号（10行刻み）</summary>
			RowNumber10 = 23,
		}
		#endregion

		#region Const
		// ☆☆☆ デフォルトフォント制御用 ☆☆☆
		private const string	ctStyleSheet_Normal	= "Normal";
		private const string	ctDefault_FontName	= "ＭＳ 明朝";
		private const float		ctDefault_FontSize	= 10;

		// ☆☆☆ ツールバー制御用 ☆☆☆
		private const string ctToolBar_Layout		= "Layout";
		private const string ctToolBar_SheetSetting	= "SheetSetting";
		private const string ctToolButton_SaveNewName			= "SaveNewName_ButtonTool";		// 名前を付けて保存
		private const string ctToolButton_FitPaper				= "FitPaper_ButtonTool";		// 用紙幅に合わせる
		private const string ctToolButton_ExtrSetting			= "ExtrSetting_ButtonTool";		// 抽出条件設定
		private const string ctToolButton_SortSetting			= "SortSetting_ButtonTool";		// ソート順位設定

		private const string ctToolButton_AlignToGrid			= "AlignToGrid";				// グリッドに合わせて整列
		private const string ctToolButton_AlignLefts			= "AlignLefts";					// 左揃え
		private const string ctToolButton_AlignCenters			= "AlignCenters";				// 上下中央整列
		private const string ctToolButton_AlignRights			= "AlignRights";				// 右揃え
		private const string ctToolButton_AlignTops				= "AlignTops";					// 上揃え
		private const string ctToolButton_AlignMiddles			= "AlignMiddles";				// 左右中央整列
		private const string ctToolButton_AlignBottoms			= "AlignBottoms";				// 下揃え
		private const string ctToolButton_MakeSameWidth			= "MakeSameWidth";				// 幅を揃える
		private const string ctToolButton_SizeToGrid			= "SizeToGrid";					// グリッドのサイズに揃える
		private const string ctToolButton_MakeSameHeight		= "MakeSameHeight";				// 高さを揃える
		private const string ctToolButton_MakeSameSize			= "MakeSameSize";				// 同じサイズに揃える
		private const string ctToolButton_MakeHorizSpaceEqual	= "MakeHorizSpaceEqual";		// 左右の間隔を均等にする
		private const string ctToolButton_IncreaseHorizSpace	= "IncreaseHorizSpace";			// 左右の間隔を広くする
		private const string ctToolButton_DecreaseHorizSpace	= "DecreaseHorizSpace";			// 左右の間隔を狭くする
		private const string ctToolButton_RemoveHorizSpace		= "RemoveHorizSpace";			// 左右の間隔を削除する
		private const string ctToolButton_MakeVertSpaceEqual	= "MakeVertSpaceEqual";			// 上下の間隔を均等にする
		private const string ctToolButton_IncreaseVertSpace		= "IncreaseVertSpace";			// 上下の間隔を広げる
		private const string ctToolButton_DecreaseVertSpace		= "DecreaseVertSpace";			// 上下の間隔を狭くする
		private const string ctToolButton_RemoveVertSpace		= "RemoveVertSpace";			// 上下の間隔を削除する
		private const string ctToolButton_CenterHoriz			= "CenterHoriz";				// 左右中央揃え
		private const string ctToolButton_CenterVert			= "CenterVert";					// 上下中央揃え
		private const string ctToolButton_BringToFront			= "BringToFront";				// 最前面へ移動
		private const string ctToolButton_SendToBack			= "SendToBack";					// 最背面へ移動
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        private const string ctToolButton_ChangeUnit = "ChangeUnit"; // 単位切替
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

		// ☆☆☆ ARControl型判別ICON用 ☆☆☆
		internal const string AR_ICON_TEXTBOX	= "AR_Textbox";
		internal const string AR_ICON_LABEL		= "AR_Label";
		internal const string AR_ICON_LINE		= "AR_Line";
		internal const string AR_ICON_PICTURE	= "AR_Picture";
		internal const string AR_ICON_SHAPE		= "AR_Shape";
		internal const string AR_ICON_BARCODE	= "AR_Barcode";

		// ☆☆☆ ActiveReport各種プロパティ表示用 ☆☆☆
		internal const string ctPropName_Top			= "Top";
		internal const string ctPropName_Left			= "Left";
		internal const string ctPropName_Height			= "Height";
		internal const string ctPropName_Width			= "Width";
		internal const string ctPropName_X1				= "X1";
		internal const string ctPropName_X2				= "X2";
		internal const string ctPropName_Y1				= "Y1";
		internal const string ctPropName_Y2				= "Y2";
		internal const string ctPropName_LineWeight		= "LineWeight";
		internal const string ctPropName_Font			= "Font";
		internal const string ctPropName_Alignment		= "Alignment";
		internal const string ctPropName_PictureAlign	= "PictureAlignment";
		internal const string ctPropName_VAlignment		= "VerticalAlignment";
		internal const string ctPropName_BackColor		= "BackColor";
		internal const string ctPropName_ForeColor		= "ForeColor";
		internal const string ctPropName_LineColor		= "LineColor";
		internal const string ctPropName_WordWrap		= "WordWrap";
		internal const string ctPropName_MultiLine		= "MultiLine";
		internal const string ctPropName_Visible		= "Visible";
		internal const string ctPropName_OutputFormat	= "OutputFormat";
		internal const string ctPropName_LineStyle		= "LineStyle";
		internal const string ctPropName_Style			= "Style";
		internal const string ctPropName_SizeMode		= "SizeMode";
		internal const string ctPropName_FontSize		= "FontSize";
		internal const string ctPropName_FontFamily		= "FontFamily";
		internal const string ctPropName_Tag			= "Tag";
		internal const string ctPropName_Name			= "Name";
		internal const string ctPropName_Bold			= "Bold";
		internal const string ctPropName_Italic			= "Italic";
		internal const string ctPropName_UnderLine		= "UnderLine";
		internal const string ctPropName_Text			= "Text";
		internal const string ctPropName_Caption		= "Caption";
		internal const string ctPropName_PrintPage		= "PrintPageCtrlDivCd";
		internal const string ctPropName_Image			= "Image";
		internal const string ctPropName_DelImage		= "DelImage";
		internal const string ctPropName_CanShrink		= "CanShrink";
		internal const string ctPropName_CanGrow		= "CanGrow";
		internal const string ctPropName_PrintAtBottom	= "PrintAtBottom";
		internal const string ctPropName_KeepTogether	= "KeepTogether";
		internal const string ctPropName_NewPage		= "NewPage";
		internal const string ctPropName_RepeatStyle	= "RepeatStyle";
		internal const string ctPropName_SummaryRunning = "SummaryRunning";
		internal const string ctPropName_SummaryFunc	= "SummaryFunc";
		internal const string ctPropName_SummaryType	= "SummaryType";
		internal const string ctPropName_SummaryGroup	= "SummaryGroup";
		internal const string ctPropName_DataField		= "DataField";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        internal const string ctPropName_CharacterSpacing = "CharacterSpacing";
        internal const string ctPropName_PrintableByteCount = "PrintableByteCount";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 多重起動防止用 ☆☆☆
		// --------------------------------------------------------
		private static Mutex		_mutex;

		// --------------------------------------------------------
		// ☆☆☆ ツールボタン ☆☆☆
		// --------------------------------------------------------
		private ButtonTool			_buttonTool_AlignToGrid;
		private ButtonTool			_buttonTool_AlignLefts;
		private ButtonTool			_buttonTool_AlignCenters;
		private ButtonTool			_buttonTool_AlignRights;
		private ButtonTool			_buttonTool_AlignTops;
		private ButtonTool			_buttonTool_AlignMiddles;
		private ButtonTool			_buttonTool_AlignBottoms;
		private ButtonTool			_buttonTool_MakeSameWidth;
		private ButtonTool			_buttonTool_SizeToGrid;
		private ButtonTool			_buttonTool_MakeSameHeight;
		private ButtonTool			_buttonTool_MakeSameSize;
		private ButtonTool			_buttonTool_MakeHorizSpaceEqual;
		private ButtonTool			_buttonTool_IncreaseHorizSpace;
		private ButtonTool			_buttonTool_DecreaseHorizSpace;
		private ButtonTool			_buttonTool_RemoveHorizSpace;
		private ButtonTool			_buttonTool_MakeVertSpaceEqual;
		private ButtonTool			_buttonTool_IncreaseVertSpace;
		private ButtonTool			_buttonTool_DecreaseVertSpace;
		private ButtonTool			_buttonTool_RemoveVertSpace;
		private ButtonTool			_buttonTool_CenterHoriz;
		private ButtonTool			_buttonTool_CenterVert;
		private ButtonTool			_buttonTool_BringToFront;
		private ButtonTool			_buttonTool_SendToBack;

		// --------------------------------------------------------
		// ☆☆☆ 各種ドック画面 ☆☆☆
		// --------------------------------------------------------
		// 追加項目
		private SFANL08105UB		_addItemControl;
		// 全体設定
		private SFANL08105UC		_allSettingControl;
		// 項目設定
		private SFANL08105UD		_itemSettingControl;

		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票印字位置設定UIアクセスクラス
		private FrePrtPosAcs		_frePrtPosAcs;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        // 伝票印刷設定アクセスクラス
        private SlipPrtSetAcs _slipPrtSetAcs;
        // 請求書印刷パターンアクセスクラス
        private DmdPrtPtnAcs _dmdPrtPtnAcs;
        // センチ・インチ制御
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		// --------------------------------------------------------
		// ☆☆☆ ガイド ☆☆☆
		// --------------------------------------------------------
		// 自由帳票選択ガイド
		private FPprSearchGuide		_frePprSelectGuide;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// 企業コード
		private string				_enterpriseCode;
		// クローズ許可プロパティ用
		private bool				_canClose;
		// 追加コントロール名称LIST
		private List<string>		_addControlNames;
		//
		private float				_prevReportSize;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UA()
		{
			InitializeComponent();

			_frePrtPosAcs = new FrePrtPosAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            _slipPrtSetAcs = new SlipPrtSetAcs();
            _dmdPrtPtnAcs = new DmdPrtPtnAcs();
            _cmInchControl = new CmInchControl();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			_addControlNames = new List<string>();

			_canClose = true;
		}
		#endregion

		#region SFANL08101IA メンバ
		/// <summary>クローズ許可プロパティ</summary>
		/// <value>画面を終了してよい場合はTrue、問題がある場合はFalseを返します</value>
		public bool CanClose
		{
			get {
				ExitDataEditProc(ExitMode.Close);
				return _canClose;
			}
		}

		/// <summary>
		/// ツールバークリックイベント（メインフレーム）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フレームのツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_New:		// 新規
				{
					DialogResult dlgRet = ExitDataEditProc(ExitMode.CreateNew);
					if (dlgRet == DialogResult.Yes || dlgRet == DialogResult.No)
						CreateNewDataProc();
					break;
				}
				case FreeSheetConst.ctToolBase_Open:	// 開く
				{
					DialogResult dlgRet = ExitDataEditProc(ExitMode.CreateNew);
					if (dlgRet == DialogResult.Yes || dlgRet == DialogResult.No)
						OpenExistingDataProc();
					break;
				}
				case FreeSheetConst.ctToolBase_Save:	// 上書き保存
				{
					SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.OverWrite, true);
					break;
				}
				case FreeSheetConst.ctToolBase_Print:	// 印刷
				{
					PrintProc();
					break;
				}
				case ctToolButton_SaveNewName:			// 名前を付けて保存
				{
					SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.NewWrite, true);
					break;
				}
				case ctToolButton_FitPaper:				// 用紙幅に合わせる
				{
					_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);

					FitPageWidthProc();
					break;
				}
				case ctToolButton_ExtrSetting:			// 抽出条件設定
				{
					ShowExecuteExtractionConditionGuide();
					break;
				}
				case ctToolButton_SortSetting:			// ソート順位設定
				{
					ShowSortSetting();
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                case ctToolButton_ChangeUnit: // 単位切替
                {
                    ChangeDesignUnit();
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				default:
				{
					ExecuteLayoutAction(e.Tool.Key);
					break;
				}
			}
		}

		/// <summary>
		/// ドック情報取得処理
		/// </summary>
		/// <param name="dockAreaPaneArray">ドック情報コレクション</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: Dock情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray)
		{
			// 追加項目
			_addItemControl = new SFANL08105UB();
			DockableControlPane dcpAddItem
				= new DockableControlPane(_addItemControl.Name, "追加項目", _addItemControl);
			dcpAddItem.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINTOUT];
			dcpAddItem.Pinned		= false;
			dcpAddItem.Size			= new Size(260, this.Height);
			dcpAddItem.MinimumSize	= dcpAddItem.Size;
			dcpAddItem.Settings.AllowClose	=  DefaultableBoolean.False;
			// 自由帳票管理オプション導入されていない場合は非表示
			if (!_frePrtPosAcs.FreeSheetMngOpt) dcpAddItem.Closed = true;

			// 全体設定
			_allSettingControl = new SFANL08105UC();
			DockableControlPane dcpAllSetting
				= new DockableControlPane(_allSettingControl.Name, "全体設定", _allSettingControl);
			dcpAllSetting.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];
			dcpAllSetting.Pinned		= false;
			dcpAllSetting.Size			= new Size(260, this.Height);
			dcpAllSetting.MinimumSize	= dcpAllSetting.Size;
			dcpAllSetting.Settings.AllowClose		=  DefaultableBoolean.False;
			dcpAllSetting.Settings.AllowFloating	=  DefaultableBoolean.False;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            _allSettingControl.CmInchControl = _cmInchControl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			// 項目設定
			_itemSettingControl = new SFANL08105UD();
			DockableControlPane dcpItemSetting
				= new DockableControlPane(_itemSettingControl.Name, "項目設定", _itemSettingControl);
			dcpItemSetting.Settings.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			dcpItemSetting.Pinned		= true;
			dcpItemSetting.Size			= new Size(260, this.Height);
			dcpItemSetting.MinimumSize	= dcpItemSetting.Size;
			dcpItemSetting.Settings.AllowClose		= DefaultableBoolean.False;
			dcpItemSetting.Settings.AllowFloating	= DefaultableBoolean.False;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            _itemSettingControl.CmInchControl = _cmInchControl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			// ドック項目（左）
			DockAreaPane dapLeft = new DockAreaPane(DockedLocation.DockedLeft);
			dapLeft.Panes.Add(dcpAddItem);
			dapLeft.Size = new Size(260, this.Height);

			// ドック項目（右）
			DockableGroupPane dgpRight1 = new DockableGroupPane();
			dgpRight1.Panes.Add(dcpAllSetting);
			dgpRight1.TextTab	= dcpAllSetting.Text;
			DockableGroupPane dgpRight2 = new DockableGroupPane();
			dgpRight2.Panes.Add(dcpItemSetting);
			dgpRight2.TextTab	= dcpItemSetting.Text;
			DockAreaPane dapRight = new DockAreaPane(DockedLocation.DockedRight);
			dapRight.Panes.Add(dgpRight1);
			dapRight.Panes.Add(dgpRight2);
			dapRight.ChildPaneStyle	= ChildPaneStyle.TabGroup;
			dapRight.Size			= new Size(260, this.Height);

			dockAreaPaneArray = new DockAreaPane[] { dapRight, dapLeft };

			return 0;
		}

		/// <summary>
		/// ツールバー情報取得処理
		/// </summary>
		/// <param name="rootToolsCollection">ツールコレクション</param>
		/// <param name="toolbarsCollection">ツールバーコレクション</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ツールバーの情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection)
		{
			// --------------------------------------------------------
			// ☆☆☆ メインメニューの設定 ☆☆☆
			// --------------------------------------------------------
			UltraToolbar mainMenuToolbar = toolbarsCollection[FreeSheetConst.ctToolBar_MainMenu];
			mainMenuToolbar.Settings.AllowFloating		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			mainMenuToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;

			// --------------------------------------------------------
			// ☆☆☆ ファイルの設定 ☆☆☆
			// --------------------------------------------------------
			UltraToolbar mainToolbar = toolbarsCollection[FreeSheetConst.ctToolBar_Main];
			mainToolbar.Text						= "ボタンメニュー（ファイル）";
			mainToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			mainToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;
			mainToolbar.Settings.CaptionPlacement	= TextPlacement.RightOfImage;

			// 開くのアイコンを変更
			rootToolsCollection[FreeSheetConst.ctToolBase_Open].SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];

			// 保存のCaptionを変更
			rootToolsCollection[FreeSheetConst.ctToolBase_Save].SharedProps.Caption = "上書き保存(&S)";
			// 保存ボタンの位置の変更
			mainToolbar.Tools.RemoveAt(1);
			mainToolbar.Tools.InsertTool(3, FreeSheetConst.ctToolBase_Save);

			mainToolbar.Tools[FreeSheetConst.ctToolBase_Print].InstanceProps.IsFirstInGroup = true;

			// 名前を付けて保存ボタンの追加
			ButtonTool saveButtonTool = new ButtonTool(ctToolButton_SaveNewName);
			saveButtonTool.SharedProps.Caption = "名前を付けて保存(&A)";
			rootToolsCollection.Add(saveButtonTool);
			PopupMenuTool fileMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_File];
			fileMenuTool.Tools.InsertTool(3, ctToolButton_SaveNewName);

			// セパレータの設定
			fileMenuTool.Tools[FreeSheetConst.ctToolBase_Print].InstanceProps.IsFirstInGroup = true;
			fileMenuTool.Tools[FreeSheetConst.ctToolBase_Save].InstanceProps.IsFirstInGroup = true;

			// --------------------------------------------------------
			// ☆☆☆ 編集の設定 ☆☆☆
			// --------------------------------------------------------
			// 帳票設定用ツールバーの設定
			UltraToolbar sheetSettingToolbar = toolbarsCollection.AddToolbar(ctToolBar_SheetSetting);
			sheetSettingToolbar.Text						= "ボタンメニュー（編集）";
			sheetSettingToolbar.DockedPosition				= DockedPosition.Top;
			sheetSettingToolbar.DockedRow					= 1;
			sheetSettingToolbar.Settings.AllowHiding		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockBottom	= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockLeft		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.AllowDockRight		= DefaultableBoolean.False;
			sheetSettingToolbar.Settings.ToolDisplayStyle	= ToolDisplayStyle.ImageAndText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //// 抽出条件設定の追加
            //ButtonTool extrSettingButtonTool = new ButtonTool(ctToolButton_ExtrSetting);
            //extrSettingButtonTool.SharedProps.Caption		= "抽出条件設定";
            //extrSettingButtonTool.SharedProps.AppearancesSmall.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.SETUP1];
            //rootToolsCollection.Add(extrSettingButtonTool);
            //sheetSettingToolbar.Tools.AddTool(ctToolButton_ExtrSetting);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

			// ソート順位設定の追加
			ButtonTool sortSettingButtonTool = new ButtonTool(ctToolButton_SortSetting);
			sortSettingButtonTool.SharedProps.Caption		= "ソート順位設定";
			sortSettingButtonTool.SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SETUP1];
			rootToolsCollection.Add(sortSettingButtonTool);
			sheetSettingToolbar.Tools.AddTool(ctToolButton_SortSetting);

			// --------------------------------------------------------
			// ☆☆☆ 編集メニューの設定 ☆☆☆
			// --------------------------------------------------------
			PopupMenuTool editMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_Edit];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //editMenuTool.Tools.AddTool(ctToolButton_ExtrSetting);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
			editMenuTool.Tools.AddTool(ctToolButton_SortSetting);

			// --------------------------------------------------------
			// ☆☆☆ レイアウト関係のボタン追加 ☆☆☆
			// --------------------------------------------------------
			// レイアウト用ツールバーの設定
			UltraToolbar layoutToolbar = toolbarsCollection.AddToolbar(ctToolBar_Layout);
			layoutToolbar.Text								= "レイアウト";
			layoutToolbar.DockedPosition					= DockedPosition.Top;
			layoutToolbar.DockedRow							= 2;
			layoutToolbar.Settings.AllowHiding				= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockBottom			= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockLeft			= DefaultableBoolean.False;
			layoutToolbar.Settings.AllowDockRight			= DefaultableBoolean.False;

			// レイアウト用ボタンの追加
			CreateLayoutToolButton(rootToolsCollection, layoutToolbar);

			// 用紙幅に合わせるの追加
			ButtonTool fitPaperButtonTool = new ButtonTool(ctToolButton_FitPaper);
			fitPaperButtonTool.SharedProps.Caption			= "用紙幅を最大にする";
			fitPaperButtonTool.SharedProps.AppearancesSmall.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INDICATIONCHANGE];
			fitPaperButtonTool.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
			rootToolsCollection.Add(fitPaperButtonTool);
			layoutToolbar.Tools.AddTool(ctToolButton_FitPaper);
			layoutToolbar.Tools[ctToolButton_FitPaper].InstanceProps.IsFirstInGroup = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // 単位切替の追加
            ButtonTool changeUnitButtonTool = new ButtonTool( ctToolButton_ChangeUnit );
            changeUnitButtonTool.SharedProps.Caption = "単位切替";
            changeUnitButtonTool.SharedProps.DisplayStyle = ToolDisplayStyle.TextOnlyAlways;
            rootToolsCollection.Add( changeUnitButtonTool );
            layoutToolbar.Tools.AddTool( ctToolButton_ChangeUnit );
            layoutToolbar.Tools[ctToolButton_ChangeUnit].InstanceProps.IsFirstInGroup = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

			return 0;
		}

		/// <summary>ツールボタン入力制御通知イベント</summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>ツールボタン表示制御通知イベント</summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
		#endregion

		#region PrivateMethod
		// ---------------------------------------------
		// レイアウトツールバー関連制御
		// ---------------------------------------------
		#region LayoutToolbar
		/// <summary>
		/// レイアウト用ツールボタン作成処理
		/// </summary>
		/// <param name="rootToolsCollection">ツールコレクション</param>
		/// <param name="layoutToolbar">レイアウト用ツールバー</param>
		/// <remarks>
		/// <br>Note		: レイアウト用のツールバーにツールボタンを設定します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void CreateLayoutToolButton(RootToolsCollection rootToolsCollection, UltraToolbar layoutToolbar)
		{
			// ツールボタンのインスタンス化
			_buttonTool_AlignToGrid			= new ButtonTool(ctToolButton_AlignToGrid);
			_buttonTool_AlignLefts			= new ButtonTool(ctToolButton_AlignLefts);
			_buttonTool_AlignCenters		= new ButtonTool(ctToolButton_AlignCenters);
			_buttonTool_AlignRights			= new ButtonTool(ctToolButton_AlignRights);
			_buttonTool_AlignTops			= new ButtonTool(ctToolButton_AlignTops);
			_buttonTool_AlignMiddles		= new ButtonTool(ctToolButton_AlignMiddles);
			_buttonTool_AlignBottoms		= new ButtonTool(ctToolButton_AlignBottoms);
			_buttonTool_MakeSameWidth		= new ButtonTool(ctToolButton_MakeSameWidth);
			_buttonTool_SizeToGrid			= new ButtonTool(ctToolButton_SizeToGrid);
			_buttonTool_MakeSameHeight		= new ButtonTool(ctToolButton_MakeSameHeight);
			_buttonTool_MakeSameSize		= new ButtonTool(ctToolButton_MakeSameSize);
			_buttonTool_MakeHorizSpaceEqual	= new ButtonTool(ctToolButton_MakeHorizSpaceEqual);
			_buttonTool_IncreaseHorizSpace	= new ButtonTool(ctToolButton_IncreaseHorizSpace);
			_buttonTool_DecreaseHorizSpace	= new ButtonTool(ctToolButton_DecreaseHorizSpace);
			_buttonTool_RemoveHorizSpace	= new ButtonTool(ctToolButton_RemoveHorizSpace);
			_buttonTool_MakeVertSpaceEqual	= new ButtonTool(ctToolButton_MakeVertSpaceEqual);
			_buttonTool_IncreaseVertSpace	= new ButtonTool(ctToolButton_IncreaseVertSpace);
			_buttonTool_DecreaseVertSpace	= new ButtonTool(ctToolButton_DecreaseVertSpace);
			_buttonTool_RemoveVertSpace		= new ButtonTool(ctToolButton_RemoveVertSpace);
			_buttonTool_CenterHoriz			= new ButtonTool(ctToolButton_CenterHoriz);
			_buttonTool_CenterVert			= new ButtonTool(ctToolButton_CenterVert);
			_buttonTool_BringToFront		= new ButtonTool(ctToolButton_BringToFront);
			_buttonTool_SendToBack			= new ButtonTool(ctToolButton_SendToBack);

			// ツールチップの設定
			_buttonTool_AlignToGrid.SharedProps.ToolTipText			= "グリッドに合わせて整列";
			_buttonTool_AlignLefts.SharedProps.ToolTipText			= "左揃え";
			_buttonTool_AlignCenters.SharedProps.ToolTipText		= "上下中央整列";
			_buttonTool_AlignRights.SharedProps.ToolTipText			= "右揃え";
			_buttonTool_AlignTops.SharedProps.ToolTipText			= "上揃え";
			_buttonTool_AlignMiddles.SharedProps.ToolTipText		= "左右中央整列";
			_buttonTool_AlignBottoms.SharedProps.ToolTipText		= "下揃え";
			_buttonTool_MakeSameWidth.SharedProps.ToolTipText		= "幅を揃える";
			_buttonTool_SizeToGrid.SharedProps.ToolTipText			= "グリッドのサイズに揃える";
			_buttonTool_MakeSameHeight.SharedProps.ToolTipText		= "高さを揃える";
			_buttonTool_MakeSameSize.SharedProps.ToolTipText		= "同じサイズに揃える";
			_buttonTool_MakeHorizSpaceEqual.SharedProps.ToolTipText	= "左右の間隔を均等にする";
			_buttonTool_IncreaseHorizSpace.SharedProps.ToolTipText	= "左右の間隔を広くする";
			_buttonTool_DecreaseHorizSpace.SharedProps.ToolTipText	= "左右の間隔を狭くする";
			_buttonTool_RemoveHorizSpace.SharedProps.ToolTipText	= "左右の間隔を削除する";
			_buttonTool_MakeVertSpaceEqual.SharedProps.ToolTipText	= "上下の間隔を均等にする";
			_buttonTool_IncreaseVertSpace.SharedProps.ToolTipText	= "上下の間隔を広げる";
			_buttonTool_DecreaseVertSpace.SharedProps.ToolTipText	= "上下の間隔を狭くする";
			_buttonTool_RemoveVertSpace.SharedProps.ToolTipText		= "上下の間隔を削除する";
			_buttonTool_CenterHoriz.SharedProps.ToolTipText			= "左右中央揃え";
			_buttonTool_CenterVert.SharedProps.ToolTipText			= "上下中央揃え";
			_buttonTool_BringToFront.SharedProps.ToolTipText		= "最前面へ移動";
			_buttonTool_SendToBack.SharedProps.ToolTipText			= "最背面へ移動";

			// ツールコレクションに追加
			rootToolsCollection.Add(_buttonTool_AlignToGrid);
			rootToolsCollection.Add(_buttonTool_AlignLefts);
			rootToolsCollection.Add(_buttonTool_AlignCenters);
			rootToolsCollection.Add(_buttonTool_AlignRights);
			rootToolsCollection.Add(_buttonTool_AlignTops);
			rootToolsCollection.Add(_buttonTool_AlignMiddles);
			rootToolsCollection.Add(_buttonTool_AlignBottoms);
			rootToolsCollection.Add(_buttonTool_MakeSameWidth);
			rootToolsCollection.Add(_buttonTool_SizeToGrid);
			rootToolsCollection.Add(_buttonTool_MakeSameHeight);
			rootToolsCollection.Add(_buttonTool_MakeSameSize);
			rootToolsCollection.Add(_buttonTool_MakeHorizSpaceEqual);
			rootToolsCollection.Add(_buttonTool_IncreaseHorizSpace);
			rootToolsCollection.Add(_buttonTool_DecreaseHorizSpace);
			rootToolsCollection.Add(_buttonTool_RemoveHorizSpace);
			rootToolsCollection.Add(_buttonTool_MakeVertSpaceEqual);
			rootToolsCollection.Add(_buttonTool_IncreaseVertSpace);
			rootToolsCollection.Add(_buttonTool_DecreaseVertSpace);
			rootToolsCollection.Add(_buttonTool_RemoveVertSpace);
			rootToolsCollection.Add(_buttonTool_CenterHoriz);
			rootToolsCollection.Add(_buttonTool_CenterVert);
			rootToolsCollection.Add(_buttonTool_BringToFront);
			rootToolsCollection.Add(_buttonTool_SendToBack);

			// レイアウト用ツールバーにボタンを設定
			layoutToolbar.Tools.AddTool(ctToolButton_AlignToGrid);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignLefts);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignCenters);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignRights);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignTops);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignMiddles);
			layoutToolbar.Tools.AddTool(ctToolButton_AlignBottoms);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameWidth);
			layoutToolbar.Tools.AddTool(ctToolButton_SizeToGrid);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameHeight);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeSameSize);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeHorizSpaceEqual);
			layoutToolbar.Tools.AddTool(ctToolButton_IncreaseHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_DecreaseHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_RemoveHorizSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_MakeVertSpaceEqual);
			layoutToolbar.Tools.AddTool(ctToolButton_IncreaseVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_DecreaseVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_RemoveVertSpace);
			layoutToolbar.Tools.AddTool(ctToolButton_CenterHoriz);
			layoutToolbar.Tools.AddTool(ctToolButton_CenterVert);
			layoutToolbar.Tools.AddTool(ctToolButton_BringToFront);
			layoutToolbar.Tools.AddTool(ctToolButton_SendToBack);

			// ボタンにアイコンを設定
			_buttonTool_AlignToGrid.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[0];
			_buttonTool_AlignLefts.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[1];
			_buttonTool_AlignCenters.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[2];
			_buttonTool_AlignRights.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[3];
			_buttonTool_AlignTops.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[4];
			_buttonTool_AlignMiddles.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[5];
			_buttonTool_AlignBottoms.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[6];
			_buttonTool_MakeSameWidth.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[7];
			_buttonTool_SizeToGrid.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[8];
			_buttonTool_MakeSameHeight.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[9];
			_buttonTool_MakeSameSize.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[10];
			_buttonTool_MakeHorizSpaceEqual.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[11];
			_buttonTool_IncreaseHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[12];
			_buttonTool_DecreaseHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[13];
			_buttonTool_RemoveHorizSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[14];
			_buttonTool_MakeVertSpaceEqual.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[15];
			_buttonTool_IncreaseVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[16];
			_buttonTool_DecreaseVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[17];
			_buttonTool_RemoveVertSpace.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[18];
			_buttonTool_CenterHoriz.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[19];
			_buttonTool_CenterVert.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[20];
			_buttonTool_BringToFront.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[21];
			_buttonTool_SendToBack.SharedProps.AppearancesSmall.Appearance.Image
				= this.LayoutIconList.Images[22];

			// セパレータの設定
			layoutToolbar.Tools[ctToolButton_AlignLefts].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_AlignTops].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_MakeSameWidth].InstanceProps.IsFirstInGroup		= true;
			layoutToolbar.Tools[ctToolButton_MakeHorizSpaceEqual].InstanceProps.IsFirstInGroup	= true;
			layoutToolbar.Tools[ctToolButton_MakeVertSpaceEqual].InstanceProps.IsFirstInGroup	= true;
			layoutToolbar.Tools[ctToolButton_CenterHoriz].InstanceProps.IsFirstInGroup			= true;
			layoutToolbar.Tools[ctToolButton_BringToFront].InstanceProps.IsFirstInGroup			= true;
		}

		/// <summary>
		/// レイアウト処理
		/// </summary>
		/// <param name="actionTool">押下されたレイアウトボタン</param>
		/// <remarks>
		/// <br>Note		: 押下されたボタンに応じてレイアウトを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ExecuteLayoutAction(string actionTool)
		{
			switch (actionTool)
			{
				case ctToolButton_AlignToGrid:
					this.designer.ExecuteAction(DesignerAction.FormatAlignToGrid); break;
				case ctToolButton_BringToFront:
					this.designer.ExecuteAction(DesignerAction.FormatOrderBringToFront); break;
				case ctToolButton_SendToBack:
					this.designer.ExecuteAction(DesignerAction.FormatOrderSendToBack); break;
				case ctToolButton_MakeSameHeight:
					this.designer.ExecuteAction(DesignerAction.FormatSizeSameHeight); break;
				case ctToolButton_MakeSameWidth:
					this.designer.ExecuteAction(DesignerAction.FormatSizeSameWidth); break;
				case ctToolButton_MakeSameSize:
					this.designer.ExecuteAction(DesignerAction.FormatSizeBoth); break;
				case ctToolButton_AlignTops:
					this.designer.ExecuteAction(DesignerAction.FormatAlignTop); break;
				case ctToolButton_AlignBottoms:
					this.designer.ExecuteAction(DesignerAction.FormatAlignBottom); break;
				case ctToolButton_AlignLefts:
					this.designer.ExecuteAction(DesignerAction.FormatAlignLeft); break;
				case ctToolButton_AlignRights:
					this.designer.ExecuteAction(DesignerAction.FormatAlignRight); break;
				case ctToolButton_AlignMiddles:
					this.designer.ExecuteAction(DesignerAction.FormatAlignMiddle); break;
				case ctToolButton_AlignCenters:
					this.designer.ExecuteAction(DesignerAction.FormatAlignCenter); break;
				case ctToolButton_SizeToGrid:
					this.designer.ExecuteAction(DesignerAction.SnapToGrid); break;
				case ctToolButton_MakeHorizSpaceEqual:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceEquallyHorizontal); break;
				case ctToolButton_IncreaseHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceIncreaseHorizontal); break;
				case ctToolButton_DecreaseHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceDecreaseHorizontal); break;
				case ctToolButton_MakeVertSpaceEqual:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceEquallyVertical); break;
				case ctToolButton_IncreaseVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceIncreaseVertical); break;
				case ctToolButton_DecreaseVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceDecreaseVertical); break;
				case ctToolButton_CenterHoriz:
					this.designer.ExecuteAction(DesignerAction.FormatCenterHorizontally); break;
				case ctToolButton_CenterVert:
					this.designer.ExecuteAction(DesignerAction.FormatCenterVertically); break;
				case ctToolButton_RemoveHorizSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceRemoveHorizontal); break;
				case ctToolButton_RemoveVertSpace:
					this.designer.ExecuteAction(DesignerAction.FormatSpaceRemoveVertical); break;
			}
		}

		/// <summary>
		/// レイアウトボタン入力可否設定処理
		/// </summary>
		/// <param name="toolbarModes">ツールバーモード</param>
		/// <remarks>
		/// <br>Note		: レイアウトボタンの入力制御を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetEnabledLayoutToolbar(LayoutToolbarModes toolbarModes)
		{
			switch (toolbarModes)
			{
				case LayoutToolbarModes.MultiControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= true;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= true;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= true;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= true;
					this._buttonTool_AlignRights.SharedProps.Enabled			= true;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= true;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= true;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= true;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= true;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.TwoControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= true;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= true;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= true;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= true;
					this._buttonTool_AlignRights.SharedProps.Enabled			= true;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= true;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= true;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= true;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= true;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= true;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.SingleControl:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= false;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= false;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= false;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= false;
					this._buttonTool_AlignRights.SharedProps.Enabled			= false;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= true;
					this._buttonTool_AlignTops.SharedProps.Enabled				= false;
					this._buttonTool_BringToFront.SharedProps.Enabled			= true;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= true;
					this._buttonTool_CenterVert.SharedProps.Enabled				= true;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= false;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_SendToBack.SharedProps.Enabled				= true;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= true;
					break;
				}
				case LayoutToolbarModes.NoControls:
				{
					this._buttonTool_AlignBottoms.SharedProps.Enabled			= false;
					this._buttonTool_AlignCenters.SharedProps.Enabled			= false;
					this._buttonTool_AlignLefts.SharedProps.Enabled				= false;
					this._buttonTool_AlignMiddles.SharedProps.Enabled			= false;
					this._buttonTool_AlignRights.SharedProps.Enabled			= false;
					this._buttonTool_AlignToGrid.SharedProps.Enabled			= false;
					this._buttonTool_AlignTops.SharedProps.Enabled				= false;
					this._buttonTool_BringToFront.SharedProps.Enabled			= false;
					this._buttonTool_CenterHoriz.SharedProps.Enabled			= false;
					this._buttonTool_CenterVert.SharedProps.Enabled				= false;
					this._buttonTool_DecreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_DecreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_IncreaseVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_MakeHorizSpaceEqual.SharedProps.Enabled	= false;
					this._buttonTool_MakeSameHeight.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameSize.SharedProps.Enabled			= false;
					this._buttonTool_MakeSameWidth.SharedProps.Enabled			= false;
					this._buttonTool_MakeVertSpaceEqual.SharedProps.Enabled		= false;
					this._buttonTool_RemoveHorizSpace.SharedProps.Enabled		= false;
					this._buttonTool_RemoveVertSpace.SharedProps.Enabled		= false;
					this._buttonTool_SendToBack.SharedProps.Enabled				= false;
					this._buttonTool_SizeToGrid.SharedProps.Enabled				= false;
					break;
				}
			}
		}

		/// <summary>
		/// レイアウトツールバー設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: レイアウトツールバーの設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetLayoutToolbar()
		{
			int count = this.designer.Selection.Count;
			if (count == 0)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);
			}
			else if (count == 1)
			{
				if (this.designer.Selection[0] is ar.ARControl)
					SetEnabledLayoutToolbar(LayoutToolbarModes.SingleControl);
				else
					SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);
			}
			else if (count == 2)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.TwoControls);
			}
			else if (count > 2)
			{
				SetEnabledLayoutToolbar(LayoutToolbarModes.MultiControls);
			}
		}
		#endregion

		// ---------------------------------------------
		// ツールバークリック関連制御
		// ---------------------------------------------
		#region ToolbarClickProcedure
		/// <summary>
		/// 新規作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 自由帳票の新規データを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void CreateNewDataProc()
		{
			// 新規作成ダイアログを起動
			SFANL08105UF newSheetDialog = new SFANL08105UF();
			DialogResult dlgRet = newSheetDialog.ShowNewReportInfoDialog(_frePrtPosAcs.PrtItemGrpList);
			if (dlgRet == DialogResult.OK)
			{
				// アクセスクラスの新規データ作成処理をCall
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //int status = _frePrtPosAcs.CreateNewData(_enterpriseCode, newSheetDialog.DisplayName, newSheetDialog.SelectedPrtItemGrp);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                int status = _frePrtPosAcs.CreateNewData( _enterpriseCode, newSheetDialog.PrtFormId, newSheetDialog.DisplayName, newSheetDialog.SelectedPrtItemGrp );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.designer.Visible = false;
						try
						{
							// 新規レポート生成
							_prevReportSize = 0;
							this.designer.NewReport();
							this.designer.Report.PageSettings.PaperKind	= newSheetDialog.PaperKind;
							// 各種幅をセット
							this.designer.Report.PageSettings.Orientation		= newSheetDialog.Landscape;
                            this.designer.Report.PageSettings.Margins.Top = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Right = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch( 1 );
                            this.designer.Report.PageSettings.Margins.Left = ar.ActiveReport3.CmToInch( 1 );
							FitPageWidthProc();
							// 標準フォントをMS明朝 10ptに設定
							this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontName = ctDefault_FontName;
							this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontSize = ctDefault_FontSize;
							// 単位変換による数値誤差が発生する為の処理
                            this.designer.Report.PrintWidth
                                = ar.ActiveReport3.CmToInch( (float)FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( this.designer.Report.PrintWidth ), 1 ) );
							// タイプ毎にデフォルトのSectionを作成
							CreateDefaultSection(newSheetDialog.SelectedPrtItemGrp.PrintPaperUseDivcd, newSheetDialog.SelectedPrtItemGrp.DataInputSystem);
						}
						finally
						{
							this.designer.Visible = true;
						}

						// ☆☆☆ 追加項目 ☆☆☆
						_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.PrtItemGroupingDispTitle, this.ilARControlIcon);

						// ☆☆☆ 全体設定 ☆☆☆
						_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

						// ☆☆☆ 項目設定 ☆☆☆
						_itemSettingControl.PrtItemSetList = _frePrtPosAcs.PrtItemSetList;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        _itemSettingControl.FrePrtPSet = _frePrtPosAcs.FrePrtPSet;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
						_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

						// アクセスクラスにデータをセット
						SetDataToAccessClass();
						// 印字位置情報バッファ退避処理
						_frePrtPosAcs.CopyPrtPosDataToBuffer();

						ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);
						
						break;
					}
					default:
					{
						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリＩＤまたはクラスＩＤ
							_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
							status,								// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン
						return;
					}
				}

				_prevReportSize = this.designer.Report.PrintWidth;
				// コピー、切り取り、アンドゥ情報をクリア
				this.designer.UndoManager.Clear();
			}
		}

		/// <summary>
		/// 既存データ呼出し処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 登録済みの自由帳票データ或いは既存レイアウトの呼び出しを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private int OpenExistingDataProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			// 共通処理中画面
			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton = false;
			try
			{
				// 自由帳票選択ガイド
                if ( _frePprSelectGuide == null )
                {
                    _frePprSelectGuide = new FPprSearchGuide();
                    _frePprSelectGuide.PrtItemGrpList = _frePrtPosAcs.PrtItemGrpList;
                }

				// 既存シート選択ガイドを起動
				_frePprSelectGuide.ShowInTaskbar	= false;
				_frePprSelectGuide.TopLevel			= true;
				FrePrtGuideSearchRet frePrtGuideSearchRet;
				FPprSearchGuide.DialogRetCode retCode = _frePprSelectGuide.ShowFrePrtGuide(out frePrtGuideSearchRet);
				switch (retCode)
				{
					case FPprSearchGuide.DialogRetCode.FreePrt:
					case FPprSearchGuide.DialogRetCode.FreeSlip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case FPprSearchGuide.DialogRetCode.FreeDMList:
                    //case FPprSearchGuide.DialogRetCode.FreeDMPostCard:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case FPprSearchGuide.DialogRetCode.FreeDmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						// 共通処理中画面（開始）
						waitForm.Title      = "自由帳票印字位置データ読込中";
						waitForm.Message    = "自由帳票印字位置データの読込中です．．．";
						waitForm.Show();

						// 検索パラメータをセット
						FrePrtPSet frePrtPSet = new FrePrtPSet();
						frePrtPSet.EnterpriseCode		= _enterpriseCode;
						frePrtPSet.UpdateDateTime		= frePrtGuideSearchRet.UpdateDateTime;
						frePrtPSet.OutputFormFileName	= frePrtGuideSearchRet.OutputFormFileName;
						frePrtPSet.UserPrtPprIdDerivNo	= frePrtGuideSearchRet.UserPrtPprIdDerivNo;
						frePrtPSet.FreePrtPprItemGrpCd	= frePrtGuideSearchRet.FreePrtPprItemGrpCd;

						status = _frePrtPosAcs.ReadReportInfo(frePrtPSet);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								_prevReportSize = 0;
								this.designer.NewReport();
								using (MemoryStream stream = new MemoryStream(_frePrtPosAcs.FrePrtPSet.PrintPosClassData))
								{
									this.designer.LoadReport(stream);
									stream.Close();
								}
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								// 共通処理中画面（終了）
								waitForm.Close();

								TMsgDisp.Show(
									this,								// 親ウィンドウフォーム
									emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
									SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
									this.Text,							// プログラム名称
									"OpenExistingDataProc",				// 処理名称
									TMsgDisp.OPE_READ,					// オペレーション
									"既に他端末より削除されています。",	// 表示するメッセージ 
									status,								// ステータス値
									_frePrtPosAcs,						// エラーが発生したオブジェクト
									MessageBoxButtons.OK,				// 表示するボタン
									MessageBoxDefaultButton.Button1);	// 初期表示ボタン
								break;
							}
							default:
							{
								// 共通処理中画面（終了）
								waitForm.Close();

								TMsgDisp.Show(
									this,								// 親ウィンドウフォーム
									emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
									SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
									this.Text,							// プログラム名称
									"OpenExistingDataProc",				// 処理名称
									TMsgDisp.OPE_READ,					// オペレーション
									_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
									status,								// ステータス値
									_frePrtPosAcs,						// エラーが発生したオブジェクト
									MessageBoxButtons.OK,				// 表示するボタン
									MessageBoxDefaultButton.Button1);	// 初期表示ボタン
								break;
							}
						}
						break;
					}
					case FPprSearchGuide.DialogRetCode.PrintPaper:
					case FPprSearchGuide.DialogRetCode.Slip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case FPprSearchGuide.DialogRetCode.DMList:
                    //case FPprSearchGuide.DialogRetCode.DMPostCard:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case FPprSearchGuide.DialogRetCode.DmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						// 共通処理中画面プロパティ設定
						waitForm.Title      = "提供（パッケージ）データ読込中";
                        waitForm.Message    = "提供（パッケージ）データの読込中です．．．";
						waitForm.Show();

						FPprSchmGrWork fPprSchmGrWork = (FPprSchmGrWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePrtGuideSearchRet, typeof(FPprSchmGrWork));
						status = _frePrtPosAcs.CreateNewData(_enterpriseCode, frePrtGuideSearchRet);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							this.designer.Visible = false;
							try
							{
								_prevReportSize = 0;
								this.designer.NewReport();
								using (MemoryStream stream = new MemoryStream(_frePrtPosAcs.FrePrtPSet.PrintPosClassData))
								{
									this.designer.LoadReport(stream);
									stream.Close();
								}
								// 標準フォントをMS明朝に設定
								this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontName = ctDefault_FontName;
								this.designer.Report.StyleSheet[ctStyleSheet_Normal].FontSize = ctDefault_FontSize;
								// タイプ毎にデフォルトのSectionを作成
								CreateDefaultSection(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd, _frePrtPosAcs.FrePrtPSet.DataInputSystem);
								switch (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd)
								{
									case (int)PrintPaperUseDivcdKind.Report:
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                                    //case (int)PrintPaperUseDivcdKind.DMReport:
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
									{
										this.designer.Report.PageSettings.Orientation = PageOrientation.Landscape;
										break;
									}
									case (int)PrintPaperUseDivcdKind.Slip:
                                    case (int)PrintPaperUseDivcdKind.DmdBill:
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
									//case (int)PrintPaperUseDivcdKind.DMPostCard:
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
									{
										this.designer.Report.PageSettings.Orientation = PageOrientation.Portrait;
										break;
									}
								}
							}
							finally
							{
								this.designer.Visible = true;
							}
						}
						else
						{
							// 共通処理中画面（終了）
							waitForm.Close();

							TMsgDisp.Show(
								this,								// 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
								SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
								this.Text,							// プログラム名称
								"OpenExistingDataProc",				// 処理名称
								TMsgDisp.OPE_READ,					// オペレーション
								_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
								status,								// ステータス値
								_frePrtPosAcs,						// エラーが発生したオブジェクト
								MessageBoxButtons.OK,				// 表示するボタン
								MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						}
						break;
					}
					case FPprSearchGuide.DialogRetCode.Return:
					{
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					}
					default:
					{
						// 共通処理中画面（終了）
						waitForm.Close();

						string message = "自由帳票データの呼び出しに失敗しました。";
						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
							this.Text,							// プログラム名称
							"OpenExistingDataProc",				// 処理名称
							TMsgDisp.OPE_READ,					// オペレーション
							message,							// 表示するメッセージ 
							status,								// ステータス値
							_frePrtPosAcs,						// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
						break;
					}
				}

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// ☆☆☆ 追加項目 ☆☆☆
					_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.PrtItemGroupingDispTitle, this.ilARControlIcon);

					// ☆☆☆ 全体設定 ☆☆☆
					_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
					_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

					// ☆☆☆ 項目設定 ☆☆☆
					_itemSettingControl.PrtItemSetList = _frePrtPosAcs.PrtItemSetList;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    _itemSettingControl.FrePrtPSet = _frePrtPosAcs.FrePrtPSet;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
					_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

					// アクセスクラスにデータをセット
					SetDataToAccessClass();
					// 印字位置情報バッファ退避処理
					_frePrtPosAcs.CopyPrtPosDataToBuffer();

					ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);

					_prevReportSize = this.designer.Report.PrintWidth;
					// コピー、切り取り、アンドゥ情報をクリア
					this.designer.UndoManager.Clear();

					// 共通処理中画面（終了）
					waitForm.Close();
				}
			}
			catch (Exception ex)
			{
				// 共通処理中画面（終了）
				waitForm.Close();

				string message = "自由帳票データの呼び出しにて例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					this.Text,							// プログラム名称
					"OpenExistingDataProc",				// 処理名称
					TMsgDisp.OPE_READ,					// オペレーション
					message,							// 表示するメッセージ 
					status,								// ステータス値
					_frePrtPosAcs,						// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="saveMode">保存モード</param>
		/// <param name="isShowCompletionDlg">保存完了画面表示フラグ</param>
		/// <remarks>
		/// <br>Note		: 保存処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private int SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode saveMode, bool isShowCompletionDlg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			this.designer.Focus();

			// 共通処理中画面
			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton = false;
			try
			{
				SetDataToAccessClass();

////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//				if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Report)
//				{
//					if (_frePrtPosAcs.FrePprECndList == null || _frePrtPosAcs.FrePprECndList.Count == 0)
//					{
//						TMsgDisp.Show(
//							this,								// 親ウィンドウフォーム
//							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
//							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
//							"抽出条件を設定してください。",		// 表示するメッセージ 
//							0,									// ステータス値
//							MessageBoxButtons.OK);				// 表示するボタン
//
//						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
//						return status;
//					}
//				}
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
				// 入力チェック
				string message;
				if (!InputCheck(out message))
				{
					TMsgDisp.Show(
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
						message,							// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
					return status;
				}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////

				// 作成日が入っていない場合は新規登録
				if (_frePrtPosAcs.FrePrtPSet.CreateDateTime == DateTime.MinValue)
					saveMode = FrePrtPosAcs.FreeSheet_SaveMode.NewWrite;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
				// 新規登録時は新規登録情報入力画面を起動する
                //if ( saveMode == FrePrtPosAcs.FreeSheet_SaveMode.NewWrite )
                //{
                //    SFANL08105UG saveDlg = new SFANL08105UG();
                //    DialogResult dlgRet = saveDlg.ShowNewWriteInfoDialog( _frePrtPosAcs.FrePrtPSet );
                //    if ( dlgRet != DialogResult.OK )
                //    {
                //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //        return status;
                //    }
                //    if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Slip )
                //        _frePrtPosAcs.SlipPrtKindList = saveDlg.SlipPrtKindList;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                // 登録済み伝票印刷設定取得処理
                List<int> prevSlipPrtKindList;
                if ( saveMode != FrePrtPosAcs.FreeSheet_SaveMode.NewWrite )
                {
                    // 更新の場合は登録済み伝票印刷設定のリストを取得する
                    prevSlipPrtKindList = this.GetPrevSlipPrtKindList( _frePrtPosAcs.FrePrtPSet.EnterpriseCode, _frePrtPosAcs.FrePrtPSet.OutputFormFileName );
                }
                else
                {
                    // 新規・名前をつけて保存の場合は登録済み無しで判断
                    prevSlipPrtKindList = new List<int>();
                }

                // 保存確認ダイアログ表示
                SFANL08105UG saveDlg = new SFANL08105UG();
                saveDlg.IsNewWrite = (saveMode == FrePrtPosAcs.FreeSheet_SaveMode.NewWrite);
                saveDlg.SlipPrtKindList.AddRange( prevSlipPrtKindList );
                DialogResult dlgRet = saveDlg.ShowNewWriteInfoDialog( _frePrtPosAcs.FrePrtPSet );
                if ( dlgRet != DialogResult.OK )
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return status;
                }

                // 同時登録する伝票種別リスト
                if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Slip )
                {
                    // (伝票)
                    List<int> slipKindList = new List<int>();

                    foreach ( int slipKind in saveDlg.SlipPrtKindList )
                    {
                        // 今回追加される分だけをリストに追加する
                        if ( !prevSlipPrtKindList.Contains( slipKind ) )
                        {
                            slipKindList.Add( slipKind );
                        }
                    }
                    _frePrtPosAcs.SlipPrtKindList = slipKindList;
                }
                else if ( _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.DmdBill )
                {
                    // (請求書)
                    List<int> prevDmdPrtPtnList = GetPrevDmdPrtPtnList( _frePrtPosAcs.FrePrtPSet.EnterpriseCode, _frePrtPosAcs.FrePrtPSet.OutputFormFileName );

                    List<int> slipKindList = new List<int>();
                    if ( !prevDmdPrtPtnList.Contains( _frePrtPosAcs.FrePrtPSet.FreePrtPprSpPrpseCd ) )
                    {
                        slipKindList.Add( _frePrtPosAcs.FrePrtPSet.FreePrtPprSpPrpseCd );
                    }
                    _frePrtPosAcs.SlipPrtKindList = slipKindList;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                ////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
                //				else
                //				{
                //					// 全体設定の入力チェック
                //					Control control;
                //					string message;
                //					if (!_allSettingControl.InputCheck(out message, out control))
                //					{
                //						DialogResult dlgRet = TMsgDisp.Show(
                //							this,								// 親ウィンドウフォーム
                //							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                //							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリＩＤまたはクラスＩＤ
                //							message,							// 表示するメッセージ 
                //							0,									// ステータス値
                //							MessageBoxButtons.OK);				// 表示するボタン
                //						control.Focus();
                //						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //						return status;
                //					}
                //				}
                // 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////

				// 共通処理中画面（起動）
				waitForm.Title = "自由帳票印字位置データ保存中";
				waitForm.Message = "自由帳票印字位置データの保存中です．．．";
				waitForm.Show();

				// リモーティング
				status = _frePrtPosAcs.WriteDBFrePrtPSet(saveMode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// ☆☆☆ 全体設定 ☆☆☆
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);

						ChangeInputMode(_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd);

						// アクセスクラスにデータをセット
						SetDataToAccessClass();
						// 印字位置情報バッファ退避処理
						_frePrtPosAcs.CopyPrtPosDataToBuffer();

						// 共通処理中画面（終了）
						waitForm.Close();
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						// 共通処理中画面（終了）
						waitForm.Close();

						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
							_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
							0,									// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン
						break;
					}
					default:
					{
						// 共通処理中画面（終了）
						waitForm.Close();

						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
							this.Text,							// プログラム名称
							"SaveDataProc",						// 処理名称
							TMsgDisp.OPE_INSERT,				// オペレーション
							_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
							status,								// ステータス値
							_frePrtPosAcs,						// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						break;
					}
				}
			}
			catch (Exception ex)
			{
				// 共通処理中画面（終了）
				waitForm.Close();

				string message = "自由帳票印字位置データ保存処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					this.Text,							// プログラム名称
					"SaveDataProc",						// 処理名称
					TMsgDisp.OPE_INSERT,				// オペレーション
					message,							// 表示するメッセージ 
					status,								// ステータス値
					_frePrtPosAcs,						// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isShowCompletionDlg)
				{
					SaveCompletionDialog compDialog = new SaveCompletionDialog();
					compDialog.ShowDialog(2);
				}
			}
			return status;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// 登録済み伝票種別リスト取得処理（伝票）
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="outputFormFileName"></param>
        /// <returns></returns>
        private List<int> GetPrevSlipPrtKindList( string enterpriseCode, string outputFormFileName )
        {
            List<int> slipKindList = new List<int>();
            ArrayList retList;
            
            int status = _slipPrtSetAcs.SearchAllSlipPrtSet( out retList, enterpriseCode );
            if ( status == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is SlipPrtSet )
                    {
                        if ( (obj as SlipPrtSet).OutputFormFileName.Trim() == outputFormFileName.Trim() )
                        {
                            slipKindList.Add( (obj as SlipPrtSet).SlipPrtKind );
                        }
                    }
                }
            }

            return slipKindList;
        }
        /// <summary>
        /// 登録済み伝票種別リスト取得処理（請求書）
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="ouputFormFileName"></param>
        /// <returns></returns>
        private List<int> GetPrevDmdPrtPtnList( string enterpriseCode, string ouputFormFileName )
        {
            List<int> slipKindList = new List<int>();
            ArrayList retList;

            int status = _dmdPrtPtnAcs.SearchAll( out retList, enterpriseCode );
            if ( status == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is DmdPrtPtn )
                    {
                        if ( (obj as DmdPrtPtn).OutputFormFileName.Trim() == ouputFormFileName.Trim() )
                        {
                            slipKindList.Add( (obj as DmdPrtPtn).SlipPrtKind );
                        }
                    }
                }
            }

            return slipKindList;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		/// <summary>
		/// 試し印刷処理
		/// </summary>
		/// <remarks>30
		/// <br>Note		: 設計中のレイアウトの試し印刷を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void PrintProc()
		{
			try
			{
				SetDataToAccessClass();

				using (MemoryStream stream = new MemoryStream((_frePrtPosAcs.FrePrtPSet.PrintPosClassData)))
				{
					ar.ActiveReport3 rpt = new ar.ActiveReport3();
					rpt.LoadLayout(stream);
					stream.Close();
				}

				SFANL08205C printInfo = new SFANL08205C();
				printInfo.InportFrePrtPSet(_frePrtPosAcs.FrePrtPSet, _enterpriseCode, SFANL08105UH.ctASSEMBLY_ID, null, null, true);

				using (MemoryStream stream = new MemoryStream((_frePrtPosAcs.FrePrtPSet.PrintPosClassData)))
				{
					ar.ActiveReport3 rpt = new ar.ActiveReport3();
					rpt.LoadLayout(stream);
					stream.Close();
				}
				SFANL08203U dmyPrintDlg = new SFANL08203U();
				dmyPrintDlg.PrintInfo = printInfo;
				Bitmap bitmap = null;
				if (_frePrtPosAcs.WaterMark != null)
					bitmap = new Bitmap(_frePrtPosAcs.WaterMark);

				switch (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd)
				{
					case (int)PrintPaperUseDivcdKind.Report:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case (int)PrintPaperUseDivcdKind.DMReport:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
					{
						dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 30, bitmap);
						break;
					}
					case (int)PrintPaperUseDivcdKind.Slip:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    case (int)PrintPaperUseDivcdKind.DmdBill:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					{
						if (_frePrtPosAcs.FrePrtPSet.FormFeedLineCount > 0)
							dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, _frePrtPosAcs.FrePrtPSet.FormFeedLineCount, bitmap);
						else
							dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 30, bitmap);
						break;
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                    //case (int)PrintPaperUseDivcdKind.DMPostCard:
                    //{
                    //    dmyPrintDlg.DummyDataPreview(_frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePrtPSet, 1, bitmap);
                    //    break;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				}
			}
			catch (ar.ReportException rptEx)
			{
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					this.Text,							// プログラム名称
					"PrintProc",						// 処理名称
					TMsgDisp.OPE_PRINT,					// オペレーション
					rptEx.Message,						// 表示するメッセージ 
					-1,									// ステータス値
					null,								// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン
			}
			catch (Exception ex)
			{
				string message = "自由帳票データの試し印刷処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					this.Text,							// プログラム名称
					"PrintProc",						// 処理名称
					TMsgDisp.OPE_PRINT,					// オペレーション
					message,							// 表示するメッセージ 
					-1,									// ステータス値
					null,								// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン
			}
		}

		/// <summary>
		/// 抽出条件設定ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 抽出条件設定ガイドを起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowExecuteExtractionConditionGuide()
		{
			SFANL08130UA extrSetting = new SFANL08130UA();

			// 抽出条件設定画面を起動
			DialogResult dlgRet = extrSetting.ShowFrePprECndSetting(_frePrtPosAcs.FrePprECndList, _frePrtPosAcs.FrePExCndDList, _frePrtPosAcs.PrtItemSetList);
			if (dlgRet == DialogResult.OK)
			{
				_frePrtPosAcs.FrePprECndList = extrSetting.UseFrePprECndList;
			}
		}

		/// <summary>
		/// ソート順位ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ソート順位設定ガイドを起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowSortSetting()
		{
			SFANL08131UB sortSetting = new SFANL08131UB();

			DialogResult dlgRet = sortSetting.ShowSortOderSetting(_frePrtPosAcs.FrePprSrtOList);
		}

		/// <summary>
		/// 用紙幅最適化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 用紙幅を適合サイズに調整します。</br>
		/// <br>			: ※ActiveReportは高さの予測が難しい為、幅のみ設定します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void FitPageWidthProc()
		{
			// カスタム用紙サイズの場合は処理しない
			if (this.designer.Report.PageSettings.PaperKind == System.Drawing.Printing.PaperKind.Custom) return;

			if (this.designer.Report.PageSettings.Orientation == PageOrientation.Landscape)
			{
				this.designer.Report.PrintWidth
					= this.designer.Report.PageSettings.PaperHeight
					- this.designer.Report.PageSettings.Margins.Left
					- this.designer.Report.PageSettings.Margins.Right;
			}
			else
			{
				this.designer.Report.PrintWidth
					= this.designer.Report.PageSettings.PaperWidth
					- this.designer.Report.PageSettings.Margins.Left
					- this.designer.Report.PageSettings.Margins.Right;
			}

			// 単位変換による数値誤差が発生する為の処理
            this.designer.Report.PrintWidth
                = ar.ActiveReport3.CmToInch( (float)FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( this.designer.Report.PrintWidth ), 1 ) );
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: デザインの終了時の処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private DialogResult ExitDataEditProc(ExitMode exitMode)
		{
			DialogResult dlgRet = DialogResult.Yes;

			if (exitMode == ExitMode.Close)
				_canClose = true;

			// 画面の内容をアクセスクラスにセット
			if (this.designer.Enabled)
				SetDataToAccessClass();

			// 変更チェック
			if (_frePrtPosAcs.CheckDataChange())
			{
				dlgRet = DialogResult.Cancel;

				dlgRet = TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					"",									// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.YesNoCancel);		// 表示するボタン
				switch (dlgRet)
				{
					case DialogResult.Yes:
					{
						if (SaveDataProc(FrePrtPosAcs.FreeSheet_SaveMode.OverWrite, false) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							dlgRet = DialogResult.Cancel;
							_canClose = false;
						}
						break;
					}
					case DialogResult.Cancel:
					{
						if (exitMode == ExitMode.Close)
							_canClose = false;
						break;
					}
				}
			}

			// 終了時のログを出力
			if (exitMode == ExitMode.Close && _canClose) _frePrtPosAcs.WriteLog(_enterpriseCode, "FrePrtPos Edit End");

			return dlgRet;
		}
		#endregion

		// ---------------------------------------------
		// Script関連制御
		// ---------------------------------------------
		#region Script
		/// <summary>
		/// Script作成処理
		/// </summary>
		/// <returns>C# Scriptコード</returns>
		/// <remarks>
		/// <br>Note		: デザイン画面の内容よりScriptを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string CreateScript()
		{
			StringBuilder script = new StringBuilder();
			
			// --------------------------------------
			// PrivateMemberの定義
			// --------------------------------------
			#region PrivateMemberの定義
			script.AppendLine("private int _beforePrtRowNumInPage = 1;");
			script.AppendLine("private int _prevPageNumber = 1;");
			script.AppendLine("private int _detailFormatCount = 0;");
			script.AppendLine("private int _pageStartDataIndex = 0;");
			script.AppendLine("private bool _isGroupKeyBreak = false;");
			script.AppendLine("private object _groupKeyObj = null;");
			script.AppendLine("private System.Data.DataSet _ds;");
			// 改ページの発生するGroupHeader項目のキーリスト
			script.AppendLine("private System.Collections.Generic.List<string> _groupKeyList;");
			// フォント縮小時のデフォルトフォント情報
			if (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd == 2)
				script.AppendLine("private System.Collections.Generic.Dictionary<string, System.Drawing.Font> _defFontList;");
			// 印刷するデータのDataField（ページヘッダー用）
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _pageHeaderDataFieldList;");
			// 印刷するデータのDataField（ページフッター用）
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _pageFooterDataFieldList;");
			// 印刷するデータのDataField（レポートフッター用）
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _reportFooterDataFieldList;");
			// WordWrap=false,CanGrow=true,MultiLine=true 項目の幅保持用
			script.AppendLine("private System.Collections.Generic.Dictionary<string, float> _wordWrapCtrlWidthList;");
			// 網掛け項目の内容バッファ用
			script.AppendLine("private bool _isAlternate;");
			script.AppendLine("private System.Collections.Generic.Dictionary<string, System.Drawing.Color> _dtlColorBuf;");
			script.AppendLine("private System.Drawing.Color _dtlColorAlt = System.Drawing.Color.FromArgb("
				+ _frePrtPosAcs.FrePrtPSet.RDetailBackColor + ","
				+ _frePrtPosAcs.FrePrtPSet.GDetailBackColor + ","
				+ _frePrtPosAcs.FrePrtPSet.BDetailBackColor + ");");
			// グループサプレス用
			script.AppendLine("private System.Collections.Generic.Dictionary<string, string> _suppressBuf;");
			// 明細高さ同期用
			script.AppendLine("private System.Collections.Generic.List<ARControl> _heightAdjustList;");
			// 日付印字用
			script.AppendLine("private System.DateTime _nowDateTime;");
			#endregion

			// --------------------------------------
			// ReportStartイベント
			// --------------------------------------
			#region ReportStartイベント
			script.AppendLine(string.Empty);	// 各イベントの前には改行を入れる（ログ参照時の可読性向上の為）
			script.AppendLine("public void ActiveReport_ReportStart(){");
			script.AppendLine("try{");
			script.AppendLine("_ds = (System.Data.DataSet)rpt.DataSource;");
			script.AppendLine(string.Empty);
			// 以下DataDynamicsが「仕様です」で突っ返してきた不具合を調整する為のロジック
			//  ∧_∧      ぼこぼこにしてやんよ
			// ( ･ω･)＝つ≡つ
			// (っ ≡つ＝つ
			// /    ) ﾊﾞﾊﾞﾊﾞﾊﾞ
			// (/￣∪
			script.AppendLine("_pageHeaderDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine("_pageFooterDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine("_reportFooterDataFieldList = new System.Collections.Generic.Dictionary<string, string>();");
			script.AppendLine(string.Empty);
			script.AppendLine("foreach (Section wkSection in rpt.Sections){");
			script.AppendLine("System.Collections.Generic.Dictionary<string, string> wkDictionary = null;");
			script.AppendLine("if (wkSection is PageHeader){");
			script.AppendLine("wkDictionary = _pageHeaderDataFieldList;");
			script.AppendLine("}");
			script.AppendLine("else if (wkSection is PageFooter){");
			script.AppendLine("wkDictionary = _pageFooterDataFieldList;");
			script.AppendLine("}");
			script.AppendLine("else if (wkSection is ReportFooter){");
			script.AppendLine("wkDictionary = _reportFooterDataFieldList;");
			script.AppendLine("}");
			script.AppendLine(string.Empty);
			script.AppendLine("if (wkDictionary != null){");
			script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
			script.AppendLine("if (wkCtrl is TextBox && !string.IsNullOrEmpty(((TextBox)wkCtrl).DataField)){");
			script.AppendLine("if (((TextBox)wkCtrl).SummaryType == SummaryType.None){");
			script.AppendLine("wkDictionary[((TextBox)wkCtrl).Name] = ((TextBox)wkCtrl).DataField;");
			script.AppendLine("((TextBox)wkCtrl).DataField = string.Empty;");
			script.AppendLine("((TextBox)wkCtrl).Text = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Label && !string.IsNullOrEmpty(((Label)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Label)wkCtrl).Name] = ((Label)wkCtrl).DataField;");
			script.AppendLine("((Label)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Picture && !string.IsNullOrEmpty(((Picture)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Picture)wkCtrl).Name] = ((Picture)wkCtrl).DataField;");
			script.AppendLine("((Picture)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("else if (wkCtrl is Barcode && !string.IsNullOrEmpty(((Barcode)wkCtrl).DataField)){");
			script.AppendLine("wkDictionary[((Barcode)wkCtrl).Name] = ((Barcode)wkCtrl).DataField;");
			script.AppendLine("((Barcode)wkCtrl).DataField = string.Empty;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");
			// ここまでDataDynamicsが「仕様です」で突っ返してきた不具合を調整する為のロジック
			script.AppendLine(string.Empty);

			// フォント縮小時のデフォルトフォント情報を取得
			if (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd == 2)
			{
				script.AppendLine("_defFontList = new System.Collections.Generic.Dictionary<string, System.Drawing.Font>();");
				script.AppendLine("foreach (Section wkSection in rpt.Sections){");
				script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
				script.AppendLine("if (wkCtrl is TextBox)");
				script.AppendLine("_defFontList[((TextBox)wkCtrl).Name] = ((TextBox)wkCtrl).Font;");
				script.AppendLine("else if (wkCtrl is Label)");
				script.AppendLine("_defFontList[((Label)wkCtrl).Name] = ((Label)wkCtrl).Font;");
				script.AppendLine("}");
				script.AppendLine("}");
			}
			// WordWrap=false,CanGrow=true,MultiLine=trueのバグ修正用
			script.AppendLine("_wordWrapCtrlWidthList = new System.Collections.Generic.Dictionary<string, float>();");
			script.AppendLine("foreach (Section wkSection in rpt.Sections){");
			script.AppendLine("foreach (ARControl wkCtrl in wkSection.Controls){");
			script.AppendLine("if (wkCtrl is TextBox){");
			script.AppendLine("TextBox wrapBugTextBox = (TextBox)wkCtrl;");
			script.AppendLine("if (!wrapBugTextBox.WordWrap && wrapBugTextBox.CanGrow && wrapBugTextBox.MultiLine)");
			script.AppendLine("_wordWrapCtrlWidthList[wrapBugTextBox.Name] = wrapBugTextBox.Width;");
			script.AppendLine("}");
			script.AppendLine("}");
			script.AppendLine("}");

			script.AppendLine("if (_groupKeyList == null) _groupKeyList = new System.Collections.Generic.List<string>();");
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (section is ar.Detail)
				{
					// 網掛け
					script.AppendLine("_dtlColorBuf = new System.Collections.Generic.Dictionary<string, System.Drawing.Color>();");
					// グループサプレス
					script.AppendLine("_suppressBuf = new System.Collections.Generic.Dictionary<string, string>();");
					// 明細高さ同期
					script.AppendLine("_heightAdjustList = new System.Collections.Generic.List<ARControl>();");
					foreach (ar.ARControl aRControl in section.Controls)
					{
						// 明細にて交互に色を変えるコントロールの名前とデフォルト色を取得
						PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
						if (prtItemSetWork != null)
						{
							if (prtItemSetWork.DtlColorChangeCd == 1)
							{
								if (aRControl is ar.TextBox)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Label)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Shape)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Shape)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Picture)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Picture)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
								else if (aRControl is ar.Barcode)
									script.AppendLine("_dtlColorBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = "
										+ "((Barcode)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).BackColor;");
							}

							// グループサプレスのコントロールを取得
							if (prtItemSetWork.GroupSuppressCd == 1)
							{
								if (aRControl is ar.TextBox)
									script.AppendLine("_suppressBuf[rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"].Name] = string.Empty;");
							}

							// 明細高さ同期のコントロールを取得
							if (prtItemSetWork.HeightAdjustDivCd == 1)
								script.AppendLine("_heightAdjustList.Add(rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]);");
						}
					}
				}
				else if (section is ar.GroupHeader)
				{
					ar.GroupHeader wkGroupHeader = (ar.GroupHeader)section;
					if (!string.IsNullOrEmpty(wkGroupHeader.DataField) && wkGroupHeader.NewPage != ar.NewPage.None && wkGroupHeader.Visible)
						script.AppendLine("_groupKeyList.Add(\"" + wkGroupHeader.DataField + "\");");
				}
			}
			script.AppendLine("}catch(System.Exception ex){");
			script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
			script.AppendLine("}");
			script.AppendLine("}");
			#endregion

			// --------------------------------------
			// PageStartイベント
			// --------------------------------------
			#region PageStartイベント
			script.AppendLine(string.Empty);	// 各イベントの前には改行を入れる（ログ参照時の可読性向上の為）
			script.AppendLine("public void ActiveReport_PageStart(){");
			script.AppendLine("try{");
			// グループサプレス用バッファをクリア
			script.AppendLine("foreach (string key in _suppressBuf.Keys)");
			script.AppendLine("_suppressBuf[key] = string.Empty;");
			// 現在の日時を取得
			script.AppendLine("_nowDateTime = System.DateTime.Now;");
			// GroupHeaderのKeyBreakが発生しているか？
			script.AppendLine("if (_isGroupKeyBreak){");
			// Format回数とBeforePrintの回数が同期しているかチェック
			script.AppendLine("if (_detailBeforePrintCount == _detailFormatCount){");
			script.AppendLine("_pageStartDataIndex = _detailFormatCount;");
			script.AppendLine("_isGroupKeyBreak = false;");
			script.AppendLine("}else{");
			// 同期していない場合は用紙幅オーバーによる改頁が発生している
			script.AppendLine("_pageStartDataIndex = _detailFormatCount - 1;");
			script.AppendLine("}");
			script.AppendLine("}else{");
			script.AppendLine("if (_detailFormatCount > 0)");
			script.AppendLine("_pageStartDataIndex = _detailFormatCount - 1;");
			script.AppendLine("else");
			script.AppendLine("_pageStartDataIndex = 0;");
			script.AppendLine("}");
			script.AppendLine("}catch(System.Exception ex){");
			script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
			script.AppendLine("}");
			script.AppendLine("}");
			#endregion

			script.AppendLine("private int _detailBeforePrintCount = 0;");
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				// 印字ページ制御用
				List<string> firstPageOnly = new List<string>();
				List<string> lastPageOnly = new List<string>();

				foreach (ar.ARControl aRControl in section.Controls)
				{
					PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
					if (prtItemSetWork != null)
					{
						// 印字ページ制御区分(0:全ページ,1:1ページ目のみ,2:最終ページのみ)
						switch (prtItemSetWork.PrintPageCtrlDivCd)
						{
							case 1: firstPageOnly.Add(aRControl.Name); break;
							case 2: if (section is ar.GroupFooter) lastPageOnly.Add(aRControl.Name); break;
						}
					}
				}

				// --------------------------------------
				// Formatイベント
				// --------------------------------------
				#region Formatイベント
				script.AppendLine(string.Empty);	// 各イベントの前には改行を入れる（ログ参照時の可読性向上の為）
				script.AppendLine("public void " + section.Name + "_Format(){");
				script.AppendLine("try{");
				if (section is ar.Detail)
				{
					// グループサプレス
					script.AppendLine("System.Collections.Generic.List<string> keyList = new System.Collections.Generic.List<string>();");
					script.AppendLine("foreach (string ctrlName in _suppressBuf.Keys) keyList.Add(ctrlName);");
					script.AppendLine("foreach (string ctrlName in keyList){");
					script.AppendLine("ARControl wkControl = rpt.Sections[\"" + section.Name + "\"].Controls[ctrlName];");
					script.AppendLine("if (wkControl is TextBox){");
					script.AppendLine("if (((TextBox)wkControl).Text == _suppressBuf[ctrlName]){");
					script.AppendLine("((TextBox)wkControl).Text = string.Empty;");
					script.AppendLine("}else{");
					script.AppendLine("_suppressBuf[ctrlName] = ((TextBox)wkControl).Text;");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("_detailFormatCount++;");
					// 次のデータを先読みしてGroupHeaderのKeyBreak条件に合致するか判断
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Rows.Count > _detailFormatCount){");
					script.AppendLine("foreach (string groupKey in _groupKeyList){");
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Columns.Contains(groupKey)){");
					script.AppendLine("if (_ds.Tables[rpt.DataMember].Rows[_detailFormatCount-1][groupKey] != _ds.Tables[rpt.DataMember].Rows[_detailFormatCount][groupKey])");
					script.AppendLine("_isGroupKeyBreak = true;");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("}");
				}

				// 以下DataDynamicsが「仕様です」で突っ返してきた不具合を調整する為のロジック
				//  ∧_∧      モコモコにしてやんよ
				// ( ･ω･)＝つ≡つ
				// (っ ≡つ＝つ
				// /    ) ﾊﾞﾊﾞﾊﾞﾊﾞ
				// (/￣∪
				//
				//   /ヽ /ヽ
				//  ':'''"`':,　　
				// ミ  ・ω・ ;,
				// :;.っ     ,つ
				// `:;     ,;'  モコッ
				//   `(/'"`∪
				// PageHeaderやPageFooterに変動するデータを印字する場合
				// 改頁等で印字すべきIndexがずれ、正常に印字されない為
				// 直接データをセットする
				if (section is ar.PageHeader || section is ar.PageFooter || section is ar.ReportFooter)
				{
					StringBuilder templete = new StringBuilder();
					templete.AppendLine("foreach (ARControl control in rpt.Sections[\"" + section.Name + "\"].Controls){");
					// TextBoxの場合
					templete.AppendLine("if (control is TextBox){");
					templete.AppendLine("TextBox textBox = (TextBox)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(textBox.Name)) continue;");
					templete.AppendLine("if (textBox.SummaryType == SummaryType.None){");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[textBox.Name])){");
					templete.AppendLine("textBox.Value = dr[<DictionaryName>[textBox.Name]];");
					templete.AppendLine("}");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// Labelの場合
					templete.AppendLine("else if (control is Label){");
					templete.AppendLine("Label label = (Label)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(label.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[label.Name])){");
					templete.AppendLine("label.Text = dr[<DictionaryName>[label.Name]].ToString();");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// Pictureの場合
					templete.AppendLine("else if (control is Picture){");
					templete.AppendLine("Picture picture = (Picture)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(picture.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[picture.Name])){");
					templete.AppendLine("if (dr[<DictionaryName>[picture.Name]] is System.Drawing.Image)");
					templete.AppendLine("picture.Image = (System.Drawing.Image)dr[<DictionaryName>[picture.Name]];");
					templete.AppendLine("}");
					templete.AppendLine("}");
					// BarCodeの場合
					templete.AppendLine("else if (control is Barcode){");
					templete.AppendLine("Barcode barcode = (Barcode)control;");
					templete.AppendLine("if (!<DictionaryName>.ContainsKey(barcode.Name)) continue;");
					templete.AppendLine("if (dt.Columns.Contains(<DictionaryName>[barcode.Name])){");
					templete.AppendLine("barcode.Text = dr[<DictionaryName>[barcode.Name]].ToString();");
					templete.AppendLine("}");
					templete.AppendLine("}");
					templete.AppendLine("}");

					script.AppendLine("System.Data.DataTable dt = _ds.Tables[rpt.DataMember];");
					if (section is ar.ReportFooter)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[dt.Rows.Count-1];");
						templete.Replace("<DictionaryName>", "_reportFooterDataFieldList");
					}
					else if (section is ar.PageHeader)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[_pageStartDataIndex];");
						templete.Replace("<DictionaryName>", "_pageHeaderDataFieldList");
					}
					else if (section is ar.PageFooter)
					{
						script.AppendLine("System.Data.DataRow dr = dt.Rows[_pageStartDataIndex];");
						templete.Replace("<DictionaryName>", "_pageFooterDataFieldList");
					}
					script.AppendLine(templete.ToString());
				}
				// ここまでDataDynamicsが「仕様です」で突っ返してきた不具合を調整する為のロジック

				// 端文字処理区分(1:端文字切捨て,2:フォント縮小)
				switch (_frePrtPosAcs.FrePrtPSet.EdgeCharProcDivCd)
				{
					case 1:
					{
						script.AppendLine("foreach (ARControl edgeCharCtrl in rpt.Sections[\"" + section.Name + "\"].Controls){");
						script.AppendLine("if (edgeCharCtrl is TextBox){");
						script.AppendLine("if (!((TextBox)edgeCharCtrl).WordWrap)");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.ConvertReportString(edgeCharCtrl);");
						script.AppendLine("}");
						script.AppendLine("if (edgeCharCtrl is Label){");
						script.AppendLine("if (!((Label)edgeCharCtrl).WordWrap)");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.ConvertReportString(edgeCharCtrl);");
						script.AppendLine("}");
						script.AppendLine("}");
						break;
					}
					case 2:
					{
						script.AppendLine("for (int ix = 0 ; ix != rpt.Sections[\"" + section.Name + "\"].Controls.Count ; ix++){");
						script.AppendLine("ARControl edgeCharCtrl = rpt.Sections[\"" + section.Name + "\"].Controls[ix];");
						script.AppendLine("if (edgeCharCtrl is TextBox){");
						script.AppendLine("if (!((TextBox)edgeCharCtrl).WordWrap){");
						script.AppendLine("((TextBox)edgeCharCtrl).Font = _defFontList[((TextBox)edgeCharCtrl).Name];");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.AdjustControlFontSize(ref edgeCharCtrl, ((TextBox)edgeCharCtrl).Font);");
						script.AppendLine("}");
						script.AppendLine("}");
						script.AppendLine("else if (edgeCharCtrl is Label){");
						script.AppendLine("if (!((Label)edgeCharCtrl).WordWrap){");
						script.AppendLine("((Label)edgeCharCtrl).Font = _defFontList[((Label)edgeCharCtrl).Name];");
						script.AppendLine("Broadleaf.Drawing.Printing.PrintCommonLibrary.AdjustControlFontSize(ref edgeCharCtrl, ((Label)edgeCharCtrl).Font);");
						script.AppendLine("}");
						script.AppendLine("}");
						script.AppendLine("}");
						break;
					}
				}

				// WordWrap=false,CanGrow=true,MultiLine=trueのバグ修正用
				script.AppendLine("foreach (ARControl wrapBugCtrl in rpt.Sections[\"" + section.Name + "\"].Controls){");
				script.AppendLine("if (wrapBugCtrl is TextBox){");
				script.AppendLine("TextBox wrapBugTextBox = (TextBox)wrapBugCtrl;");
				script.AppendLine("if (!wrapBugTextBox.WordWrap && wrapBugTextBox.CanGrow && wrapBugTextBox.MultiLine)");
				script.AppendLine("wrapBugTextBox.Width = float.MaxValue;");
				script.AppendLine("}");
				script.AppendLine("}");

				bool isAppendextrTextBox = false;
				bool isAppendtxtFooter1 = false;
				bool isAppendtxtFooter2 = false;
				bool isAppendtxtSort1 = false;
				bool isAppendtxtSort2 = false;
				bool isAppendtxtSort3 = false;
				bool isAppendtxtSort4 = false;
				bool isAppendtxtSort5 = false;
				foreach (ar.ARControl aRControl in section.Controls)
				{
					// 伝票レイアウトで赤伝区分の非表示制御
					if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 2)
					{
						if (aRControl.DataField == "AcceptOdrRF.DebitNoteDivRF")
						{
							script.AppendLine("if (rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"] is TextBox){");
							script.AppendLine("if (string.IsNullOrEmpty(((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text))");
							script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Visible = false;");
							script.AppendLine("}");
							script.AppendLine("else if (rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"] is Label){");
							script.AppendLine("if (string.IsNullOrEmpty(((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text))");
							script.AppendLine("((Label)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Visible = false;");
							script.AppendLine("}");
						}
					}

					PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
					if (prtItemSetWork != null)
					{
						switch (prtItemSetWork.FreePrtPaperItemCd)
						{
							case (int)FreePrtPaperItemCdKind.ExtrCondition:
							{
								// 抽出条件用部品を通す
								if (!isAppendextrTextBox)
								{
									script.AppendLine("TextBox extrTextBox = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendextrTextBox = true;
								}
								else
								{
									script.AppendLine("extrTextBox = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("Broadleaf.Application.Common.SFANL08235CE.SetExrCndTextBox(ref extrTextBox, _ds);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.CommonFooter1:	// 共通フッター1
							{
								if (!isAppendtxtFooter1)
								{
									script.AppendLine("TextBox txtFooter1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtFooter1 = true;
								}
								else
								{
									script.AppendLine("txtFooter1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtFooter1.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_PFTR_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_PRINTFOOTER1 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.CommonFooter2:	// 共通フッター2
							{
								if (!isAppendtxtFooter2)
								{
									script.AppendLine("TextBox txtFooter2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtFooter2 = true;
								}
								else
								{
									script.AppendLine("txtFooter2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtFooter2.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_PFTR_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_PRINTFOOTER2 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateAdFormal:	// 日付の印刷（西暦）
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"YYYY/mm/dd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateJpFormal:	// 日付の印刷（和暦）
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"GGyymmdd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.DateJpAbbr:	// 日付の印刷（和暦・略）
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"ggyy.mm.dd\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.TimeAdFormal:	// 時間の印刷
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"HH:MM\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.TimeJpFormal:	// 時間の印刷
							{
								script.AppendLine("((TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"]).Text = Broadleaf.Library.Globarization.TDateTime.DateTimeToString(\"HHMM\", _nowDateTime);");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder1:	// ソート順位1
							{
								if (!isAppendtxtSort1)
								{
									script.AppendLine("TextBox txtSort1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort1 = true;
								}
								else
								{
									script.AppendLine("txtSort1 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort1.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER1 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder2:	// ソート順位2
							{
								if (!isAppendtxtSort2)
								{
									script.AppendLine("TextBox txtSort2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort2 = true;
								}
								else
								{
									script.AppendLine("txtSort2 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort2.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER2 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder3:	// ソート順位3
							{
								if (!isAppendtxtSort3)
								{
									script.AppendLine("TextBox txtSort3 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort3 = true;
								}
								else
								{
									script.AppendLine("txtSort3 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort3.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER3 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder4:	// ソート順位4
							{
								if (!isAppendtxtSort4)
								{
									script.AppendLine("TextBox txtSort4 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort4 = true;
								}
								else
								{
									script.AppendLine("txtSort4 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort4.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER4 + "\"].ToString();");
								break;
							}
							case (int)FreePrtPaperItemCdKind.SortOder5:	// ソート順位5
							{
								if (!isAppendtxtSort5)
								{
									script.AppendLine("TextBox txtSort5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									isAppendtxtSort5 = true;
								}
								else
								{
									script.AppendLine("txtSort5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
								}
								script.AppendLine("txtSort5.Text = _ds.Tables[\"" + SFANL08235CD.CT_FREPPRPRINT_SRTO_DT + "\"].Rows[0][\"" + SFANL08235CD.CT_SORTODER5 + "\"].ToString();");
								break;
							}
						}
					}
				}

				script.AppendLine("}catch(System.Exception ex){");
				script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
				script.AppendLine("}");
				script.AppendLine("}");
				#endregion

				// --------------------------------------
				// BeforePrintイベント
				// --------------------------------------
				#region BeforePrintイベント
				script.AppendLine(string.Empty);	// 各イベントの前には改行を入れる（ログ参照時の可読性向上の為）
				script.AppendLine("public void " + section.Name + "_BeforePrint(){");
				script.AppendLine("try{");
				if (firstPageOnly.Count > 0)
				{
					script.AppendLine("if (rpt.PageNumber != 1){");
					foreach (string aRControlName in firstPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = false;");
					script.AppendLine("}");
				}

				if (lastPageOnly.Count > 0)
				{
					script.AppendLine("if (_detailFormatCount == _ds.Tables[rpt.DataMember].Rows.Count){");
					foreach (string aRControlName in lastPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = true;");
					script.AppendLine("}");
					script.AppendLine("else{");
					foreach (string aRControlName in lastPageOnly)
						script.AppendLine("rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControlName + "\"]" + ".Visible = false;");
					script.AppendLine("}");
				}
				
				if (section is ar.Detail)
				{
					script.AppendLine("if (_prevPageNumber != rpt.PageNumber){");
					script.AppendLine("_beforePrtRowNumInPage = 1;");
					script.AppendLine("_isAlternate = false;");
					script.AppendLine("}");

					// 明細の互い違いに色を変更する
					script.AppendLine("foreach (string ctrlName in _dtlColorBuf.Keys){");
					script.AppendLine("ARControl wkControl = rpt.Sections[\"" + section.Name + "\"].Controls[ctrlName];");
					script.AppendLine("if (_isAlternate){");
					script.AppendLine("if (wkControl is TextBox) ((TextBox)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Label) ((Label)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Shape) ((Shape)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Picture) ((Picture)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("else if (wkControl is Barcode) ((Barcode)wkControl).BackColor = _dtlColorAlt;");
					script.AppendLine("}else{");
					script.AppendLine("if (wkControl is TextBox) ((TextBox)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Label) ((Label)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Shape) ((Shape)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Picture) ((Picture)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("else if (wkControl is Barcode) ((Barcode)wkControl).BackColor = _dtlColorBuf[ctrlName];");
					script.AppendLine("}");
					script.AppendLine("}");
					script.AppendLine("if (_isAlternate) _isAlternate = false;");
					script.AppendLine("else _isAlternate = true;");

					bool isAppendrowNumber5 = false;
					bool isAppendrowNumber10 = false;
					foreach (ar.ARControl aRControl in section.Controls)
					{
						PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
						if (prtItemSetWork != null)
						{
							switch (prtItemSetWork.FreePrtPaperItemCd)
							{
								case (int)FreePrtPaperItemCdKind.RowNumber5:	// 行番号（5行刻み）
								{
									if (!isAppendrowNumber5)
									{
										script.AppendLine("TextBox rowNumber5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
										isAppendrowNumber5 = true;
									}
									else
									{
										script.AppendLine("rowNumber5 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									}
									script.AppendLine("if (_beforePrtRowNumInPage % 5 == 0 && _beforePrtRowNumInPage > 0)");
									script.AppendLine("rowNumber5.Text = _beforePrtRowNumInPage.ToString();");
									script.AppendLine("else");
									script.AppendLine("rowNumber5.Text = string.Empty;");
									break;
								}
								case (int)FreePrtPaperItemCdKind.RowNumber10:	// 行番号（10行刻み）
								{
									if (!isAppendrowNumber10)
									{
										script.AppendLine("TextBox rowNumber10 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
										isAppendrowNumber10 = true;
									}
									else
									{
										script.AppendLine("rowNumber10 = (TextBox)rpt.Sections[\"" + section.Name + "\"].Controls[\"" + aRControl.Name + "\"];");
									}
									script.AppendLine("if (_beforePrtRowNumInPage % 10 == 0)");
									script.AppendLine("rowNumber10.Text = _beforePrtRowNumInPage.ToString();");
									script.AppendLine("else");
									script.AppendLine("rowNumber10.Text = string.Empty;");
									break;
								}
							}
						}
					}
					script.AppendLine("_prevPageNumber = rpt.PageNumber;");
					script.AppendLine("_beforePrtRowNumInPage++;");

					// 伝票明細の高さを統一する
					script.AppendLine("float maxHeight = 0;");
					script.AppendLine("foreach (ARControl targetCtrl in _heightAdjustList){");
					script.AppendLine("if (targetCtrl is TextBox) maxHeight = System.Math.Max(((TextBox)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Label) maxHeight = System.Math.Max(((Label)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Picture) maxHeight = System.Math.Max(((Picture)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Shape) maxHeight = System.Math.Max(((Shape)targetCtrl).Height, maxHeight);");
					script.AppendLine("else if (targetCtrl is Barcode) maxHeight = System.Math.Max(((Barcode)targetCtrl).Height, maxHeight);");
					script.AppendLine("}");
					script.AppendLine("foreach (ARControl targetCtrl in _heightAdjustList){");
					script.AppendLine("if (targetCtrl is TextBox) ((TextBox)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Label) ((Label)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Picture) ((Picture)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Shape) ((Shape)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Barcode) ((Barcode)targetCtrl).Height = maxHeight;");
					script.AppendLine("else if (targetCtrl is Line){");
					script.AppendLine("if (((Line)targetCtrl).Y1 > ((Line)targetCtrl).Y2)");
					script.AppendLine("((Line)targetCtrl).Y1 = ((Line)targetCtrl).Y2 + maxHeight;");
					script.AppendLine("else");
					script.AppendLine("((Line)targetCtrl).Y2 = ((Line)targetCtrl).Y1 + maxHeight;");
					script.AppendLine("}");
					script.AppendLine("}");

					// 明細のFormatとBeforePrintの回数をチェック
					// GroupHeaderのKeyBreakが発生する場合は上記回数が同期する為
					script.AppendLine("_detailBeforePrintCount++;");
				}

				script.AppendLine("foreach (ARControl wkARControl in rpt.Sections[\"" + section.Name + "\"].Controls){");
				script.AppendLine("if (wkARControl is TextBox){");
				script.AppendLine("TextBox wkTextBox = (TextBox)wkARControl;");

				// WordWrap=false,CanGrow=true,MultiLine=trueのバグ修正用
				script.AppendLine("if (!wkTextBox.WordWrap && wkTextBox.CanGrow && wkTextBox.MultiLine)");
				script.AppendLine("wkTextBox.Width = _wordWrapCtrlWidthList[wkTextBox.Name];");
				
				// OutputFormat "\#,##0","\#,##0-"
				// 上記出力はマイナス値に正常に反映されない.NET仕様の修正
				// 尚、異常に「\」が多いのは・・・
				// OutputFormat == \\#,##0 → ｴｽｹｰﾌﾟｼｰｹﾝｽ表記 \\\\#,##0 → Scriptは文字列の為さらにｴｽｹｰﾌﾟｼｰｹﾝｽ表記 \\\\\\\\#,##0
				script.AppendLine("if (!string.IsNullOrEmpty(wkTextBox.OutputFormat)){");
				script.AppendLine("if (wkTextBox.OutputFormat == \"\\\\\\\\#,##0\" && wkTextBox.Value != null){");
				script.AppendLine("double result = 0;");
				script.AppendLine("double.TryParse(wkTextBox.Value.ToString(), out result);");
				script.AppendLine("if (result < 0)");
				script.AppendLine("wkTextBox.Text = (result * -1).ToString(\"\\\\\\\\-#,##0\");");
				script.AppendLine("}");
				script.AppendLine("if (wkTextBox.OutputFormat == \"\\\\\\\\#,##0-\" && wkTextBox.Value != null){");
				script.AppendLine("double result = 0;");
				script.AppendLine("double.TryParse(wkTextBox.Value.ToString(), out result);");
				script.AppendLine("if (result < 0)");
				script.AppendLine("wkTextBox.Text = (result * -1).ToString(\"\\\\\\\\-#,##0-\");");
				script.AppendLine("}");
				script.AppendLine("}");
				script.AppendLine("}");
				script.AppendLine("}");

				script.AppendLine("}catch(System.Exception ex){");
				script.AppendLine("Broadleaf.Library.Windows.Forms.TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_NODISP, \"SFANL08105U\", \"ActiveReport Script\", \"CreateScript\", Broadleaf.Library.Windows.Forms.TMsgDisp.OPE_PRINT, ex.Message, -1, rpt, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);");
				script.AppendLine("}");
				script.AppendLine("}");
				#endregion

				// （￣□￣;）疲れた
			}
			return ApplyCSharpIndent(script.ToString());
		}

		/// <summary>
		/// C#用コード用インデント適用処理
		/// </summary>
		/// <param name="baseStr">適用する文字列</param>
		/// <returns>適用結果文字列</returns>
		/// <remarks>
		/// <br>Note		: C#コード文字列にインデントを追加します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string ApplyCSharpIndent(string baseStr)
		{
			// ログ参照時の可読性向上の為、インデントを追加
			StringWriter baseWriter = new StringWriter();
			IndentedTextWriter writer = new IndentedTextWriter(baseWriter);
			writer.Indent = 0;

			StringReader reader = new StringReader(baseStr);
			string wkStr = string.Empty;
			int onceIndent = 0;
			while ((wkStr = reader.ReadLine()) != null)
			{
				if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"^ ?\}.+\{ ?$"))
				{
					--writer.Indent;
					writer.WriteLine(wkStr);
					++writer.Indent;
				}
				else if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"\{ ?$"))
				{
					writer.WriteLine(wkStr);
					++writer.Indent;
				}
				else if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @"^ ?\}"))
				{
					if (writer.Indent > 0)
						--writer.Indent;
					writer.WriteLine(wkStr);
				}
				else
				{
					if (System.Text.RegularExpressions.Regex.IsMatch(wkStr, @" ?(foreach|if|else if) ?(.+)[^{;] ?$") ||
						System.Text.RegularExpressions.Regex.IsMatch(wkStr, @" ?else ?$"))
					{
						writer.WriteLine(wkStr);
						++writer.Indent;
						++onceIndent;
					}
					else
					{
						if (onceIndent > 0)
						{
							writer.WriteLine(wkStr);
							while (onceIndent > 0)
							{
								--writer.Indent;
								--onceIndent;
							}
						}
						else
						{
							writer.WriteLine(wkStr);
						}
					}
				}
			}

			return baseWriter.ToString();
		}
		#endregion

		/// <summary>
		/// 初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面の初期処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void InitializeSetting()
		{
			// アクセスクラス初期処理
			int status = _frePrtPosAcs.Initialize(_enterpriseCode);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリIDまたはクラスID
					this.Text,							// プログラム名称
					"InitializeSetting",					// 処理名称
					TMsgDisp.OPE_INIT,					// オペレーション
					_frePrtPosAcs.ErrorMessage,			// 表示するメッセージ 
					status,								// ステータス値
					_frePrtPosAcs,						// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン
			}

			_addItemControl.ShowPrtItemSetList(_frePrtPosAcs.PrtItemSetList, new List<PrtItemGroupingDispTitle>(), this.ilARControlIcon);

			// ☆☆☆ 全体設定 ☆☆☆
			_allSettingControl.Watermark = _frePrtPosAcs.WaterMark;
			_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, null, _frePrtPosAcs.FreeSheetMngOpt);
			_allSettingControl.WholeSettingChanged += new EventHandler(AllSettingControl_WholeSettingChanged);

			// ☆☆☆ 項目設定 ☆☆☆
			_itemSettingControl.SelectedARControlNameChanged += new SFANL08105UD.SelectedARControlNameChangedEventHandler(ItemSettingControl_SelectedARControlNameChanged);
			_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);

			SetEnabledLayoutToolbar(LayoutToolbarModes.NoControls);

			List<string> keys = new List<string>(new string[] {FreeSheetConst.ctPopupMenu_Display, FreeSheetConst.ctPopupMenu_Window, FreeSheetConst.ctPopupMenu_Help});
			ToolButtonVisibleChanged(keys, false);

			ChangeInputMode(-1);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            ReflectDesignUnit();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// アクセスクラスデータ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: アクセスクラスにデータの設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SetDataToAccessClass()
		{
			// ☆☆☆ 全体設定 ☆☆☆
			_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);

            // Scriptをセット
            this.designer.Report.Script = CreateScript();

			// SELECT文をセット
			if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 1)
			{
				SFANL08132CG cnv = new SFANL08132CG();
				if (_frePrtPosAcs.PrtItemSetList != null)
				{
					byte[] frePrtItmSetPrmByte = XmlByteSerializer.Serialize(cnv.CreateFrePrtItmSetPrm(this.designer.Report, _frePrtPosAcs.PrtItemSetList, _frePrtPosAcs.FrePprSrtOList));
					StringBuilder wkStr = new StringBuilder();
					foreach (byte wkByte in frePrtItmSetPrmByte)
					{
						if (wkStr.Length > 0)
							wkStr.Append(",");
						wkStr.Append(wkByte);
					}
					this.designer.Report.UserData = wkStr.ToString();
				}
			}
			
			// レポートデータをセット
			using (MemoryStream stream = new MemoryStream())
			{
				this.designer.SaveReport(stream);
				stream.Position = 0;
				_frePrtPosAcs.FrePrtPSet.PrintPosClassData = stream.ToArray();
				stream.Close();
			}
		}

		/// <summary>
		/// ActiveReportControl作成処理
		/// </summary>
		/// <param name="prtItemSet">印字項目設定マスタ</param>
		/// <returns>ARControl</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定マスタを元にARControlを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private ar.ARControl CreateARControlFromPrtItemSet(PrtItemSetWork prtItemSet)
		{
			ar.ARControl arControl = null;
			// レポートコントロール区分(1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode)
			switch (prtItemSet.ReportControlCode)
			{
				case 1:
				{
					ar.TextBox textBox	= new ar.TextBox();
					textBox.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
                    textBox.Text = prtItemSet.FreePrtPaperItemNm;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 DEL
                    //textBox.WordWrap = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 ADD
                    textBox.WordWrap = true;
                    textBox.MultiLine = false;
                    textBox.CanGrow = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 ADD

					switch (prtItemSet.CommaEditExistCd)
					{
						case 1: textBox.OutputFormat = "#,###";		break;
						case 2: textBox.OutputFormat = "#,##0";		break;
						case 3: textBox.OutputFormat = "0.0";		break;
						case 4: textBox.OutputFormat = "0.00";		break;
						case 5: textBox.OutputFormat = @"\\#,##0";	break;
						case 6: textBox.OutputFormat = @"\\#,##0-";	break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 ADD
                        case 7: textBox.OutputFormat = @"\\#,###"; break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 ADD
					}
					switch (prtItemSet.FreePrtPaperItemCd)
					{
						case (int)FreePrtPaperItemCdKind.PageNumber:
						{
							textBox.SummaryType		= ar.SummaryType.PageCount;
							textBox.SummaryRunning	= ar.SummaryRunning.All;
							break;
						}
						case (int)FreePrtPaperItemCdKind.TotalPageNumber:
						{
							textBox.SummaryType		= ar.SummaryType.PageCount;
							break;
						}
					}
					arControl = textBox;
					break;
				}
				case 2:
				{
					ar.Label label	= new ar.Label();
					label.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					label.Text		= prtItemSet.FreePrtPaperItemNm;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 DEL
                    //label.WordWrap	= false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/14 ADD
                    label.WordWrap = true;
                    label.MultiLine = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/14 ADD
					arControl = label;
					break;
				}
				case 3:
				{
					ar.Picture picture	= new ar.Picture();
					picture.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					arControl = picture;
					break;
				}
				case 4:
				{
					arControl = new ar.Shape();
					break;
				}
				case 5:
				{
					arControl = new ar.Line();
					break;
				}
				case 6:
				{
					ar.Barcode barcode	= new ar.Barcode();
					barcode.DataField	= FrePrtSettingController.CreateDataField(prtItemSet);
					switch (prtItemSet.BarCodeStyle)
					{
						case 2: barcode.Style = ar.BarCodeStyle.JapanesePostal; break;
						case 3: barcode.Style = ar.BarCodeStyle.QRCode; break;
						default: barcode.Style = ar.BarCodeStyle.Code_128_A; break;
					}
					barcode.BackColor	= Color.White;
					arControl = barcode;
					break;
				}
				case 7:
				{
					arControl = new ar.SubReport();
					break;
				}
			}

			arControl.Name = prtItemSet.DDName;

			arControl.Tag = FrePrtSettingController.GetARControlTagInfo(prtItemSet);

			return arControl;
		}

		/// <summary>
		/// 入力モード変更処理
		/// </summary>
		/// <param name="printPaperUseDivcd">帳票使用区分</param>
		/// <remarks>
		/// <br>Note		: 入力モードに応じて、画面の入力制御を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ChangeInputMode(int printPaperUseDivcd)
		{
			List<string> enabledKeyList = new List<string>();
			List<string> disableKeyList = new List<string>();

			switch (printPaperUseDivcd)
			{
				case (int)PrintPaperUseDivcdKind.Report:
				{
					// ツールバー（入力可）
					enabledKeyList.Add(ctToolButton_SaveNewName);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //enabledKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
					enabledKeyList.Add(ctToolButton_SortSetting);
					enabledKeyList.Add(ctToolButton_FitPaper);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    enabledKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Print);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Save);
					// 編集画面
					this.designer.Enabled		= true;
					// 追加項目
					_addItemControl.Enabled		= true;
					// 全体設定
					_allSettingControl.Enabled	= true;
					// 項目設定
					_itemSettingControl.Enabled = true;
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMReport:
                //case (int)PrintPaperUseDivcdKind.DMPostCard:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				case (int)PrintPaperUseDivcdKind.Slip:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                case (int)PrintPaperUseDivcdKind.DmdBill:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
				{
					// ツールバー（入力可）
					enabledKeyList.Add(ctToolButton_SaveNewName);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Save);
					enabledKeyList.Add(FreeSheetConst.ctToolBase_Print);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    enabledKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					// ツールバー（入力不可）
					disableKeyList.Add(ctToolButton_SortSetting);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //disableKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

					// 伝票の更新モード時は「用紙幅に合わせる」は無効
                    if ( !_frePrtPosAcs.FreeSheetMngOpt &&
                        _frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == 2 &&
                        _frePrtPosAcs.FrePrtPSet.UpdateDateTime > DateTime.MinValue )
                    {
                        disableKeyList.Add( ctToolButton_FitPaper );
                    }
                    else
                    {
                        enabledKeyList.Add( ctToolButton_FitPaper );
                    }

					// 編集画面
					this.designer.Enabled		= true;
					// 追加項目
					_addItemControl.Enabled		= true;
					// 全体設定
					_allSettingControl.Enabled	= true;
					// 項目設定
					_itemSettingControl.Enabled = true;
					break;
				}
				default:
				{
					// ツールバー（入力不可）
					disableKeyList.Add(ctToolButton_SaveNewName);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
                    //disableKeyList.Add(ctToolButton_ExtrSetting);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL
					disableKeyList.Add(ctToolButton_SortSetting);
					disableKeyList.Add(ctToolButton_FitPaper);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    disableKeyList.Add( ctToolButton_ChangeUnit );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
					disableKeyList.Add(FreeSheetConst.ctToolBase_Print);
					disableKeyList.Add(FreeSheetConst.ctToolBase_Save);
					// 編集画面
					this.designer.Enabled		= false;
					// 追加項目
					_addItemControl.Enabled		= false;
					// 全体設定
					_allSettingControl.Enabled	= false;
					// 項目設定
					_itemSettingControl.Enabled	= false;
					break;
				}
			}

			// 自由帳票管理オプションが未導入時は「名前を付けて保存」「新規」「用紙幅に合わせる」を非表示
			if (!_frePrtPosAcs.FreeSheetMngOpt)
				ToolButtonVisibleChanged(new List<string>(new string[] { ctToolButton_SaveNewName, FreeSheetConst.ctToolBase_New, ctToolButton_FitPaper }), false);

			ToolButtonEnableChanged(enabledKeyList, true);
			ToolButtonEnableChanged(disableKeyList, false);
		}

		/// <summary>
		/// デザイナー追加可能チェック
		/// </summary>
		/// <param name="section">追加対象となるSection</param>
		/// <param name="prtItemSet">印字項目設定マスタ</param>
		/// <returns>追加可能フラグ</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定マスタの内容を元に対象のSectionにARControlが</br>
		/// <br>			: が追加可能かチェックします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private bool CanAddDesigner(ar.Section section, PrtItemSetWork prtItemSet)
		{
			if (section is ar.ReportHeader || section is ar.PageHeader || section is ar.GroupHeader)
			{
				if (prtItemSet.HeaderUseDivCd == 1)
					return true;
			}
			else if (section is ar.Detail)
			{
				if (prtItemSet.DetailUseDivCd == 1)
					return true;
			}
			else if (section is ar.ReportFooter || section is ar.PageFooter || section is ar.GroupFooter)
			{
				if (prtItemSet.FooterUseDivCd == 1)
					return true;
			}

			return false;
		}

		/// <summary>
		/// コントロール名称設定処理
		/// </summary>
		/// <param name="targetCtrl">対象コントロール</param>
		/// <returns>設定結果</returns>
		private bool SetNewControlName(ar.ARControl targetCtrl)
		{
			try
			{
				List<string> nameList = new List<string>();
				foreach (ar.Section section in this.designer.Report.Sections)
				{
                    foreach ( ar.ARControl control in section.Controls )
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 DEL
                        //nameList.Add(control.Name);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 ADD
                        nameList.Add( control.Name.ToUpper() );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 ADD
				}

				int branchNumber = 1;
				string wkName = targetCtrl.Name;
				// 既に同名コントロールが存在する場合は枝番を付与
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 DEL
                //while (nameList.Contains(wkName))
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/19 ADD
                while ( nameList.Contains( wkName.ToUpper() ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/19 ADD
				{
					wkName = targetCtrl.Name + branchNumber++;
				}
				targetCtrl.Name = wkName;
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 初期セクション作成処理
		/// </summary>
		/// <param name="printPaperUseDivcd">帳票使用区分</param>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <returns>作成結果</returns>
		private int CreateDefaultSection(int printPaperUseDivcd, int dataInputSystem)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			this.designer.SuspendLayout();

			int nowReportHFCnt	= 0;
			int nowPageHFCnt	= 0;
			int nowGroupHFCnt	= 0;
			List<string> sectionNameList = new List<string>();
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (section is ar.ReportHeader) nowReportHFCnt++;
				else if (section is ar.PageHeader) nowPageHFCnt++;
				else if (section is ar.GroupHeader) nowGroupHFCnt++;
				sectionNameList.Add(section.Name);
			}

			int reportHFCnt = 0;
			int pageHFCnt	= 0;
			int groupHFCnt	= 0;
			switch (printPaperUseDivcd)
			{
				case (int)PrintPaperUseDivcdKind.Report:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMReport:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
				{
					reportHFCnt	= 1;
					pageHFCnt	= 1;
					groupHFCnt	= 4;
					break;
				}
				case (int)PrintPaperUseDivcdKind.Slip:
				{
					reportHFCnt	= 1;
					pageHFCnt	= 1;
					groupHFCnt	= 1;
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //case (int)PrintPaperUseDivcdKind.DMPostCard:
                //{
                //    reportHFCnt	= 0;
                //    pageHFCnt	= 1;
                //    groupHFCnt	= 0;
                //    break;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                case (int)PrintPaperUseDivcdKind.DmdBill:
                {
                    reportHFCnt = 1;
                    pageHFCnt = 1;
                    groupHFCnt = 2;
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
			}

			// ReportHeader,ReportFooterを追加
			while (reportHFCnt > nowReportHFCnt)
			{
				this.designer.Report.Sections.InsertReportHF();
				nowReportHFCnt++;
			}
			// PageHeader,PageFooterを追加
			while (pageHFCnt > nowPageHFCnt)
			{
				this.designer.Report.Sections.InsertPageHF();
				nowPageHFCnt++;
			}
			// GroupHeader,GroupFooterを追加
			while (groupHFCnt > nowGroupHFCnt)
			{
				this.designer.Report.Sections.InsertGroupHF();
				nowGroupHFCnt++;
			}

			// 鈑金伝票の場合は特殊用途（保険情報印字用）用GroupHeader,GroupFooterを追加する
			if (printPaperUseDivcd == 2 && dataInputSystem == 2 && !sectionNameList.Contains(SFANL08235CD.CT_INSURINFO_GROUPHEADERNAME))
			{
				int pageHeaderIndex = 0;
				int pageFooterIndex = 0;
				for (int ix = 0; ix != this.designer.Report.Sections.Count; ix++)
				{
					if (this.designer.Report.Sections[ix] is ar.PageHeader)
						pageHeaderIndex = ix;
					if (this.designer.Report.Sections[ix] is ar.PageFooter)
						pageFooterIndex = ix;
				}
				// Insert順番は必ずFooter→Header
				this.designer.Report.Sections.Insert(pageFooterIndex, ar.SectionType.GroupFooter, SFANL08235CD.CT_INSURINFO_GROUPFOOTERNAME);
				this.designer.Report.Sections.Insert(pageHeaderIndex + 1, ar.SectionType.GroupHeader, SFANL08235CD.CT_INSURINFO_GROUPHEADERNAME);
			}

			// PageHeader,PageFooter,Detail以外の高さは0
			foreach (ar.Section section in this.designer.Report.Sections)
			{
				if (!(section is ar.Detail))
				{
					if (!sectionNameList.Contains(section.Name) || section.Controls.Count == 0)
						section.Height = 0;
				}
			}

			this.designer.ResumeLayout(true);

			return status;
		}

////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面の入力チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2008.03.19</br>
		/// </remarks>
		public bool InputCheck(out string message)
		{
			message = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 DEL
            //if (_frePrtPosAcs.FrePrtPSet.PrintPaperUseDivcd == (int)PrintPaperUseDivcdKind.Report)
            //{
            //    // 抽出条件の設定チェック
            //    if (_frePrtPosAcs.FrePprECndList == null || _frePrtPosAcs.FrePprECndList.Count == 0)
            //    {
            //        message = "抽出条件を設定してください。";
            //        return false;
            //    }

            //    // 抽出条件の入力チェック
            //    SFANL08130UA extrSetting = new SFANL08130UA();
            //    int errIndex = 0;
            //    if (!extrSetting.InputCheck(_frePrtPosAcs.FrePprECndList, out message, out errIndex))
            //    {
            //        message = "[抽出条件設定] - " + message;
            //        return false;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 DEL

			return true;
		}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        /// <summary>
        /// 単位変更
        /// </summary>
        private void ChangeDesignUnit()
        {
            // 切り替え（反転）
            _cmInchControl.IsInchMode = (!_cmInchControl.IsInchMode);

            // 表示反映
            ReflectDesignUnit();
        }
        /// <summary>
        /// 単位変更時の制御
        /// </summary>
        private void ReflectDesignUnit()
        {
            // デザイナの単位変更
            if ( _cmInchControl.IsInchMode )
            {
                // インチ単位
                designer.DesignUnits = MeasurementUnits.US;
            }
            else
            {
                // cm単位
                designer.DesignUnits = MeasurementUnits.Metric;
            }

            try
            {
                // 子フォームの単位変更

                // 全体設定
                if ( _allSettingControl != null && _frePrtPosAcs != null && _frePrtPosAcs.FrePrtPSet != null &&
                     this.designer != null && this.designer.Report != null )
                {
                    _allSettingControl.ShowWholeSetting( _frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt );
                }

                // 項目プロパティ
                if ( _itemSettingControl != null && this.designer != null && this.designer.Report != null &&
                     _frePrtPosAcs != null && _frePrtPosAcs.ARCtrlPropertyDispInfo != null )
                {
                    _itemSettingControl.ShowPropertyInfo( this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UA_Load(object sender, EventArgs e)
		{
			this.designer.Report.Sections.Clear();
			this.designer.Enabled = false;

			// ---------------------------------------
			// 多重起動の防止
			// ---------------------------------------
			_mutex = new Mutex(false, SFANL08105UH.ctASSEMBLY_ID);
			if (!_mutex.WaitOne(0, false))
			{
				_frePrtPosAcs.WriteLog(_enterpriseCode, "FrePrtPos StartCancelException:Duplicate");
				throw new FreeSheetStartCancelException(this.Text + "の多重起動はできません。");
			}
			else
			{
				InitializeSetting();
			}
		}

		/// <summary>
		/// DragOverイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: オブジェクトがコントロールの境界内にドラッグされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_DragOver(object sender, DragEventArgs e)
		{
			PrtItemSetWork prtItemSet = e.Data.GetData(typeof(PrtItemSetWork)) as PrtItemSetWork;
			if (prtItemSet != null)
			{
                ar.Section section = this.designer.SectionAt( new Point( e.X, e.Y ) );
				Point nowPoint = this.designer.PointToSection(section, new Point(e.X, e.Y));
				if (nowPoint.X >= 0 && nowPoint.Y >= 0)
				{
					if (CanAddDesigner(section, prtItemSet))
						e.Effect = DragDropEffects.Copy;
				}
			}
		}

		/// <summary>
		/// DragDropイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ドラッグアンドドロップ操作が完了したときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(PrtItemSetWork)))
			{
				PrtItemSetWork prtItemSet	= (PrtItemSetWork)e.Data.GetData(typeof(PrtItemSetWork));
				ar.ARControl aRControl		= CreateARControlFromPrtItemSet(prtItemSet);
				if (aRControl != null)
				{
					// 追加対象Sectionを取得
                    ar.Section section = this.designer.SectionAt( new Point( e.X, e.Y ) );
					if (section != null)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10
                        //Point dropPoint = this.designer.PointToSection( section, new Point( e.X, e.Y ) );
                        // ↓Ver.Upによりアクティブレポートの仕様が変わっている可能性があります。位置を調整。
                        Control parent = this.Parent;
                        Point dropPoint = this.designer.PointToSection( section, new Point( e.X - this.Left - parent.Left, e.Y - this.Top - parent.Top ) );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10

						// ActiveReportは全てInch基準の為、Graphicsクラスより解像度を取得、変換
						Graphics graphics = this.designer.CreateGraphics();
						try
						{
                            aRControl.Location = new PointF( dropPoint.X / graphics.DpiX, dropPoint.Y / graphics.DpiY );
                        }
						finally
						{
							graphics.Dispose();
						}

						if (SetNewControlName(aRControl))
						{
							// 追加するコントロール名称を退避
							_addControlNames.Add(aRControl.Name);

                            try
                            {
                                // コントロールを追加
                                section.Controls.Add( aRControl );
                            }
                            catch( Exception ex)
                            {
                                string msg = ex.Message;
                            }

							this.designer.Selection.Select(aRControl);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // ↓ ｱｸﾃｨﾌﾞﾚﾎﾟｰﾄVer.UpによりAddに関するレイアウト変更イベントが走らないようなったのでここで追加。
                            _itemSettingControl.UpdateSelectItemCombo( this.designer.Report, this.ilARControlIcon );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
						}
					}
				}
			}
		}

		/// <summary>
		/// SelectionChangedイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択が変更されたときに発生します。Selectionプロパティを使用すると、</br>
		/// <br>			: 現在の選択内容を確認できます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_SelectionChanged()
		{
			// レイアウトツールバーの入力制御
			SetLayoutToolbar();

			_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
		}

		/// <summary>
		/// LayoutChangingイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポートレイアウトが変更される前に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_LayoutChanging(object sender, LayoutChangingArgs e)
		{
			if (_itemSettingControl.IsNowWorking) return;

			switch (e.Type)
			{
				case LayoutChangeType.SectionSize:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "セクションの高さ、幅の変更は出来ません。";
						TMsgDisp.Show(
							this,							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,		// アセンブリIDまたはクラスID
							message,						// 表示するメッセージ 
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
						e.AllowChange = false;
					}
					break;
				}
				case LayoutChangeType.SectionMove:
				case LayoutChangeType.SectionAdd:
				case LayoutChangeType.SectionDelete:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "セクションの移動、追加、削除は出来ません。";
						TMsgDisp.Show(
							this,							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,		// アセンブリIDまたはクラスID
							message,						// 表示するメッセージ 
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
						e.AllowChange = false;
					}
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					else if (e.Type == LayoutChangeType.SectionDelete)
					{
						// SummaryGroupに存在しないGroupHeaderが指定されていると
						// 実印刷時にエラーが出る為クリアを行う。
						foreach (ar.Section section in this.designer.Report.Sections)
						{
							foreach (ar.ARControl control in section.Controls)
							{
								if (control is ar.TextBox)
								{
									ar.TextBox textBox = (ar.TextBox)control;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                                    //if (e.Names != null && e.Names.Length > 0 && textBox.SummaryGroup == e.Names[0])
                                    //    textBox.SummaryGroup = string.Empty;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                                    if ( e.Name != null && textBox.SummaryGroup == e.Name )
                                    {
                                        textBox.SummaryGroup = string.Empty;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
								}
							}
						}
					}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					break;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
				case LayoutChangeType.ControlAdd:
				case LayoutChangeType.ControlDelete:
				{
					if (!_frePrtPosAcs.FreeSheetMngOpt)
					{
						string message = "コントロールの追加、削除は出来ません。";
						TMsgDisp.Show(
							this,							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,		// アセンブリIDまたはクラスID
							message,						// 表示するメッセージ 
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
						e.AllowChange = false;
					}
					else if (e.Type == LayoutChangeType.ControlAdd)
					{
						// 今回追加するARControlのNameを退避する
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                        //_addControlNames.AddRange(e.Names);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                        //_addControlNames.Add( e.Name );
                        _itemSettingControl.UpdateSelectItemCombo( this.designer.Report, this.ilARControlIcon );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
					}
					break;
				}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				case LayoutChangeType.ControlMove:
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
					//PointF newPointF = (PointF)e.NewValues[0];
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD

                    if ( !(e.NewValue is PointF) )
                    {
                        break;
                    }
                    PointF newPointF = (PointF)e.NewValue;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/12 DEL ﾚｲｱｳﾄの自由度を高める為、ﾏｲﾅｽを許可する
                    //if (newPointF.X < 0 || newPointF.Y < 0)
                    //{
                    //    // マイナスになる場合はイベントをキャンセル
                    //    e.AllowChange = false;

                    //    // マイナス値→0に変更して再度Control移動イベントを発生させる
                    //    if (newPointF.X < 0)
                    //        newPointF.X = 0;
                    //    if (newPointF.Y < 0)
                    //        newPointF.Y = 0;
                    //    for (int ix = 0 ; ix != this.designer.Selection.Count ; ix++)
                    //    {
                    //        ar.ARControl aRControl = this.designer.Selection[ix] as ar.ARControl;
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 DEL
                    //        //if (aRControl != null && aRControl.Name == e.Names[0])
                    //        //{
                    //        //    aRControl.Location = newPointF;
                    //        //    break;
                    //        //}
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 DEL
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/21 ADD
                    //        if ( aRControl != null && aRControl.Name == e.Name )
                    //        {
                    //            aRControl.Location = newPointF;
                    //            break;
                    //        }
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/21 ADD
                    //    }
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/12 DEL
					break;
				}
			}
		}

		/// <summary>
		/// LayoutChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポートレイアウトが変更されたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void designer_LayoutChanged(object sender, LayoutChangedArgs e)
		{
			if (_itemSettingControl.IsNowWorking) return;

			switch (e.Type)
			{
				case LayoutChangeType.ReportSize:
				{
					// ReportSizeだけLayoutChangingイベントが発生しない orz
					// バグだらけでまともにサポートもしない製品なんか販売すんなよ
					if (!_frePrtPosAcs.FreeSheetMngOpt && _prevReportSize != 0 && this.designer.Report.PrintWidth != _prevReportSize)
					{
						string message = "セクションの高さ、幅の変更は出来ません。";
						TMsgDisp.Show(
							this,							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
							SFANL08105UH.ctASSEMBLY_ID,		// アセンブリIDまたはクラスID
							message,						// 表示するメッセージ 
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
						this.designer.Report.PrintWidth = _prevReportSize;
					}
					else
					{
						if (!_itemSettingControl.IsNowWorking)
							_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
						if (e.Type == LayoutChangeType.ReportSize && !_allSettingControl.IsNowWorking)
							_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);
						this.designer.Focus();
					}
					break;
				}
				case LayoutChangeType.ControlAdd:
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // ↓ ｱｸﾃｨﾌﾞﾚﾎﾟｰﾄVer.Upでの仕様変更なのか、addでLayoutChangedが走らないので削除。

                    //_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);

                    //while (_addControlNames.Count > 0)
                    //{
                    //    bool isExistName = false;
                    //    foreach (ar.Section section in this.designer.Report.Sections)
                    //    {
                    //        for (int iy = 0 ; iy != section.Controls.Count ; iy++)
                    //        {
                    //            ar.ARControl aRControl = section.Controls[iy];
                    //            if (aRControl.Name.Equals(_addControlNames[0]))
                    //            {
                    //                PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, _frePrtPosAcs.PrtItemSetList);
                    //                if (prtItemSet != null)
                    //                {
                    //                    if (!CanAddDesigner(section, prtItemSet))
                    //                        section.Controls.Remove(aRControl);
                    //                }
                    //                isExistName = true;
                    //                break;
                    //            }
                    //        }
                    //        if (isExistName) break;
                    //    }
                    //    _addControlNames.RemoveAt(0);
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					break;
				}
				case LayoutChangeType.ControlDelete:
				{
					List<ar.ARControl> aRControlList = new List<ar.ARControl>();
					for (int ix = 0 ; ix != this.designer.Selection.Count ; ix++)
					{
						if (this.designer.Selection[ix] is ar.Section)
						{
							ar.Section section = (ar.Section)this.designer.Selection[ix];
							foreach (ar.ARControl aRControl in section.Controls)
								aRControlList.Add(aRControl);
						}
						else if (this.designer.Selection[ix] is ar.ARControl)
						{
							aRControlList.Add(this.designer.Selection[ix] as ar.ARControl);
						}
					}
					_itemSettingControl.UpdateSelectItemCombo(this.designer.Report, this.ilARControlIcon);
					break;
				}
				case LayoutChangeType.ControlMove:
				case LayoutChangeType.ControlSize:
				case LayoutChangeType.SectionSize:
				{
					if (!_itemSettingControl.IsNowWorking)
						_itemSettingControl.ShowPropertyInfo(this.designer.Report, this.designer.Selection, _frePrtPosAcs.ARCtrlPropertyDispInfo);
					if (e.Type == LayoutChangeType.ReportSize && !_allSettingControl.IsNowWorking)
						_allSettingControl.ShowWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report, _frePrtPosAcs.FreeSheetMngOpt);
					this.designer.Focus();
					break;
				}
			}
		}

		/// <summary>
		/// 選択ARControl変更イベント
		/// </summary>
		/// <param name="name">コントロール名称</param>
		/// <remarks>
		/// <br>Note		: 選択ARControlが変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ItemSettingControl_SelectedARControlNameChanged(string name)
		{
			this.designer.Selection.Clear();

			foreach (ar.Section section in this.designer.Report.Sections)
			{
				foreach (ar.ARControl control in section.Controls)
				{
					if (control.Name.Equals(name))
					{
						this.designer.Selection.Select(section.Controls[name]);
						break;
					}
				}
			}
		}

		/// <summary>
		/// 全体設定変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 全体設定が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void AllSettingControl_WholeSettingChanged(object sender, EventArgs e)
		{
			if (sender is SFANL08105UC.ChangedType)
			{
				switch ((SFANL08105UC.ChangedType)sender)
				{
					case SFANL08105UC.ChangedType.Comment:
					case SFANL08105UC.ChangedType.PrintPos:
					{
						_allSettingControl.GetWholeSetting(_frePrtPosAcs.FrePrtPSet, this.designer.Report);
						break;
					}
					case SFANL08105UC.ChangedType.Watermark:
					{
						_frePrtPosAcs.SetNewImageData(_enterpriseCode, _allSettingControl.Watermark);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
                        this.designer.Report.Watermark = _allSettingControl.Watermark;
                        this.designer.Report.WatermarkAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

						break;
					}
				}
			}
		}

		/// <summary>
		/// FormClosedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームが閉じた後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UA_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Mutexが発行されている場合は破棄
			if (_mutex != null)
			{
				_mutex.ReleaseMutex();	// 解放
				_mutex.Close();			// 破棄
			}
		}
		#endregion
	}
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
    # region [センチメートル・インチ制御クラス]
    /// <summary>
    /// センチメートル・インチ制御クラス
    /// </summary>
    /// <remarks>※データ上はInch固定です。表示方法をcmまたはinchで表示する為制御します。</remarks>
    internal class CmInchControl
    {
        // インチモード(true = 表示はInchで扱う)
        private bool _isInchMode;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CmInchControl()
        {
            _isInchMode = true;
        }

        /// <summary>
        /// インチモード(true = 表示はInchで扱う)
        /// </summary>
        public bool IsInchMode
        {
            get { return _isInchMode; }
            set { _isInchMode = value; }
        }
        /// <summary>
        /// 表示(cm or inch)→データ(inch)
        /// </summary>
        /// <param name="cmOrInch"></param>
        /// <returns></returns>
        public float ToData( float cmOrInch )
        {
            // Cm or Inch → Inch
            if ( _isInchMode )
            {
                // Inch → Inch
                return cmOrInch;
            }
            else
            {
                // Cm → Inch
                return ar.ActiveReport3.CmToInch( cmOrInch );
            }
        }
        /// <summary>
        /// データ(inch)→表示(cm or inch)
        /// </summary>
        /// <param name="cmOrInch"></param>
        /// <returns></returns>
        public float ToDisp( float cmOrInch )
        {
            // Inch → Cm or Inch
            if ( _isInchMode )
            {
                // Inch → Inch
                return cmOrInch;
            }
            else
            {
                // Inch → Cm
                return ar.ActiveReport3.InchToCm( cmOrInch );
            }
        }
        /// <summary>
        /// 単位タイトル(cm or inch)
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            if ( _isInchMode )
            {
                return "ｲﾝﾁ";
            }
            else
            {
                return "cm";
            }
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
}