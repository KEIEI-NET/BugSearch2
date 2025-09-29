using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 自由帳票インタフェース用コンスト定義
	/// </summary>
	public static class FreeSheetConst
	{
		// メインメニュー用Const定義
		/// <summary>ファイル</summary>
		public const string ctPopupMenu_File		= "File_PopupMenuTool";
		/// <summary>編集</summary>
		public const string ctPopupMenu_Edit		= "Edit_PopupMenuTool";
		/// <summary>表示</summary>
		public const string ctPopupMenu_Display		= "Display_PopupMenuTool";
		/// <summary>ウィンドウ</summary>
		public const string ctPopupMenu_Window		= "Window_PopupMenuTool";
		/// <summary>ヘルプ</summary>
		public const string ctPopupMenu_Help		= "Help_PopupMenuTool";
		// ツールボタン用Const定義
		/// <summary>ログイン名称（タイトル）</summary>
		public const string ctToolBase_LoginTitle	= "LoginTitle_LabelTool";
		/// <summary>ログイン名称</summary>
		public const string ctToolBase_LoginName	= "LoginName_LabelTool";
		/// <summary></summary>
		public const string ctToolBase_Dummy		= "Dummy_LabelTool";
		/// <summary>終了</summary>
		public const string ctToolBase_Exit			= "Exit_ButtonTool";
		/// <summary>保存</summary>
		public const string ctToolBase_Save			= "Save_ButtonTool";
		/// <summary>新規</summary>
		public const string ctToolBase_New			= "New_ButtonTool";
		/// <summary>開く</summary>
		public const string ctToolBase_Open			= "Open_ButtonTool";
		/// <summary>印刷</summary>
		public const string ctToolBase_Print		= "Print_ButtonTool";
		// ツールバー用Const定義
		/// <summary>メインメニュー</summary>
		public const string ctToolBar_MainMenu		= "MainMenu_UltraToolbar";
		/// <summary>メインツールバー</summary>
		public const string ctToolBar_Main			= "Main_UltraToolbar";
		// 子画面起動情報用ファイルパス
		/// <summary>子画面起動情報用ファイルパス</summary>
		public const string ctFILE_NAVIGATOR		= "SFANL08100U.DAT";
		// 子画面起動情報用列名称
		/// <summary>起動パラメータ</summary>
		public const string COL_STARTARGS			= "StartArgs";
		/// <summary>アセンブリID</summary>
		public const string COL_ASSEMBLYID			= "AssemblyID";
		/// <summary>クラス名称</summary>
		public const string COL_CLASSNAME			= "ClassName";
		/// <summary>表示タイトル名称</summary>
		public const string COL_TITLENAME			= "TitleName";
		/// <summary>子画面起動パラメータ</summary>
		public const string COL_CHILDSTARTARGS		= "ChildStartArgs";
	}

	/// <summary>
	/// ツールボタン入力制御通知イベントハンドラ
	/// </summary>
	/// <param name="keys">ツールバーキー</param>
	/// <param name="allowing">制御フラグ</param>
	public delegate void ToolButtonDisplayControlEventHandler(List<string> keys, bool allowing);

	/// <summary>
	/// 自由帳票インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票のメインフレーム用インターフェースです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public interface IFreeSheetMainFrame
	{
		/// <summary>クローズ許可プロパティ</summary>
		/// <value>画面を終了してよい場合はTrue、問題がある場合はFalseを返します</value>
		bool CanClose { get; }

		/// <summary>
		/// ツールバー情報設定処理
		/// </summary>
		/// <param name="rootToolsCollection">ツールコレクション</param>
		/// <param name="toolbarsCollection">ツールバーコレクション</param>
		/// <returns>ステータス</returns>
		int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection);

		/// <summary>
		/// ドック情報取得処理
		/// </summary>
		/// <param name="dockAreaPaneArray">ドック情報配列</param>
		/// <returns>ステータス</returns>
		int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray);

		/// <summary>
		/// ツールバークリックイベント（メインフレーム）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e);

		/// <summary>
		/// ツールボタン入力制御通知イベント
		/// </summary>
		event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>
		/// ツールボタン表示制御通知イベント
		/// </summary>
		event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
	}

	/// <summary>
	/// 自由帳票起動キャンセル例外
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票のメインフレーム起動をキャンセルする為の例外です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class FreeSheetStartCancelException : Exception
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="message">例外メッセージ</param>
		public FreeSheetStartCancelException(string message)
			: base(message)
		{
		}
	}
}
