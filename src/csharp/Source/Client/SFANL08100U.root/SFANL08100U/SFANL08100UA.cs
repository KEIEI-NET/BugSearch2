using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票用のメインフレームです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08100UA : Form
	{
		#region PrivateMember
		// 起動フォーム
		private Form		_bindForm;
		// 起動引数
		private string[]	_args;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="args">パラメータ引数</param>
		public SFANL08100UA(string[] args)
		{
			InitializeComponent();

			_args = args;

			SetIconImageToToolbar();

			this.tToolbarsManager.ToolClick += new ToolClickEventHandler(tToolbarsManager_ToolClick);

			this.tToolbarsManager.Visible = false;
			this.ultraDockManager.Visible = false;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// アイコン画像設定処理（ツールバー用）
		/// </summary>
		/// <remarks>
		/// <br>Note		: ツールバーのアイコン設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetIconImageToToolbar()
		{
			// イメージリストを設定する
			this.tToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 新規のアイコン設定
			ButtonTool newButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_New];
			if (newButton != null) newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			// 保存のアイコン設定
			ButtonTool saveButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Save];
			if (saveButton != null) saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// 開くのアイコン設定
			ButtonTool openButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Open];
			if (openButton != null) openButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.FOLDER;
			// 印刷のアイコン設定
			ButtonTool printButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Print];
			if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
			// 終了のアイコン設定
			ButtonTool exitButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Exit];
			if (exitButton != null) exitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// ログイン担当者のアイコン設定
			LabelTool loginTitleLabel = (LabelTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_LoginTitle];
			if (loginTitleLabel != null) loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// ログイン担当名の設定
			LabelTool loginNameLabel = (LabelTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_LoginName];
			if ((LoginInfoAcquisition.Employee != null) &&
				(loginNameLabel != null))
			{
				loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
		}

		/// <summary>
		/// メインフォーム作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 起動引数に応じてメインフォームを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void CreateMainForm()
		{
			string classID		= string.Empty;
			string assmPath		= string.Empty;
			string title		= string.Empty;
			string[] startArg	= new string[0];

			// 子画面の起動情報を取得
			DataTable dt;
			if (LoadNavigator(out dt) == 0)
			{
				if (_args.Length > 0)
				{
					string filter = FreeSheetConst.COL_STARTARGS + "='" + _args[0] + "'";
					DataRow[] drArray = dt.Select(filter);
					if (drArray.Length > 0)
					{
						DataRow dr = drArray[0];
						assmPath	= dr[FreeSheetConst.COL_ASSEMBLYID].ToString();
						classID		= dr[FreeSheetConst.COL_CLASSNAME].ToString();
						title		= dr[FreeSheetConst.COL_TITLENAME].ToString();

						if (!dr[FreeSheetConst.COL_CHILDSTARTARGS].Equals(DBNull.Value) &&
							!dr[FreeSheetConst.COL_CHILDSTARTARGS].Equals(string.Empty))
							startArg = dr[FreeSheetConst.COL_CHILDSTARTARGS].ToString().Split(' ');
					}
				}
			}

			// ファイルが存在しない場合は処理しない
			if (!File.Exists(assmPath)) return;

			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton	= false;
			waitForm.Title				= "画面起動中";
			waitForm.Message			= title + "の起動中です．．．";
			waitForm.Show();
			try
			{
				Assembly assm = Assembly.LoadFrom(assmPath);
				Type type = assm.GetType(classID);

				if (startArg.Length > 0)
					_bindForm = Activator.CreateInstance(type, startArg) as Form;
				else
					_bindForm = Activator.CreateInstance(type) as Form;
				if (_bindForm is IFreeSheetMainFrame)
				{
					_bindForm.TopLevel			= false;
					_bindForm.FormBorderStyle	= FormBorderStyle.None;
					this.Text					= title;
					_bindForm.Dock				= DockStyle.Fill;
					this.Controls.Add(_bindForm);

					IFreeSheetMainFrame iFreeSheet = (IFreeSheetMainFrame)_bindForm;

					SetToolbars(iFreeSheet);

					SetDockManager(iFreeSheet);
				}
				else
				{
					throw new Exception("IFreeSheetMainFrameを継承していません。");
				}
			}
			finally
			{
				waitForm.Close();
			}
		}

		/// <summary>
		/// ツールバー設定処理
		/// </summary>
		/// <param name="iFreeSheet">自由帳票インターフェース</param>
		/// <remarks>
		/// <br>Note		: ツールバーの追加及び各種設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetToolbars(IFreeSheetMainFrame iFreeSheet)
		{
			RootToolsCollection rootToolsCollection = this.tToolbarsManager.Tools;
			ToolbarsCollection toolbarsCollection = this.tToolbarsManager.Toolbars;
			iFreeSheet.SetToolBarInfo(ref rootToolsCollection, ref toolbarsCollection);

			// ツールクリックイベントをデリゲートに登録
			this.tToolbarsManager.ToolClick += new ToolClickEventHandler(iFreeSheet.FrameToolbars_ToolClick);

			// 子画面からのツールボタンの入力制御通知
			iFreeSheet.ToolButtonEnableChanged += new ToolButtonDisplayControlEventHandler(iFreeSheet_ToolButtonEnableChanged);

			// 子画面からのツールボタンの表示制御通知
			iFreeSheet.ToolButtonVisibleChanged += new ToolButtonDisplayControlEventHandler(iFreeSheet_ToolButtonVisibleChanged);
		}

		/// <summary>
		/// ドックマネージャー設定処理
		/// </summary>
		/// <param name="iFreeSheet">自由帳票インターフェース</param>
		/// <remarks>
		/// <br>Note		: ドックマネージャー情報の設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetDockManager(IFreeSheetMainFrame iFreeSheet)
		{
			DockAreaPane[] dockAreaPaneArray;
			int status = iFreeSheet.GetDockAreaInfo(out dockAreaPaneArray);

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				foreach (DockAreaPane dockAreaPane in dockAreaPaneArray)
					this.ultraDockManager.DockAreas.Add(dockAreaPane);
			}
		}

		/// <summary>
		/// ナビゲーター読込処理
		/// </summary>
		/// <param name="dt">ナビゲーター情報</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 起動ナビゲーター情報の読込を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int LoadNavigator(out DataTable dt)
		{
			dt = null;

			using (FileStream fileStream = new FileStream(FreeSheetConst.ctFILE_NAVIGATOR, FileMode.Open, FileAccess.Read))
			{
				try
				{
					if (fileStream.Length > 0)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						DataSet ds = (DataSet)binaryFormatter.Deserialize(fileStream);
						dt = ds.Tables[0];
					}
				}
				finally
				{
					fileStream.Close();
				}
			}

			return 0;
		}
		#endregion

		#region Event
		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void tToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_Exit:
				{
					this.Close();
					break;
				}
			}
		}

		/// <summary>
		/// ツールボタン入力制御通知イベント
		/// </summary>
		/// <param name="keys">対象ツールボタンのキー</param>
		/// <param name="allowing">制御情報</param>
		/// <remarks>
		/// <br>Note		: ツールボタンの入力制御の変更を通知された時に。</br>
		/// <br>			: 発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void iFreeSheet_ToolButtonEnableChanged(List<string> keys, bool allowing)
		{
			foreach (string key in keys)
				this.tToolbarsManager.Tools[key].SharedProps.Enabled = allowing;
		}

		/// <summary>
		/// ツールボタン表示制御通知イベント
		/// </summary>
		/// <param name="keys">対象ツールボタンのキー</param>
		/// <param name="allowing">制御情報</param>
		/// <remarks>
		/// <br>Note		: ツールボタンの入力制御の変更を通知された時に。</br>
		/// <br>			: 発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void iFreeSheet_ToolButtonVisibleChanged(List<string> keys, bool allowing)
		{
			foreach (string key in keys)
				this.tToolbarsManager.Tools[key].SharedProps.Visible = allowing;
		}

		/// <summary>
		/// FormClosingイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを閉じるたびに、フォームが閉じられる前、</br>
		/// <br>			: および閉じる理由を指定する前に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// クローズ許可フラグ
			bool canClose = true;

			if (e.CloseReason == CloseReason.UserClosing)
			{
				// インタフェースよりクローズ許可フラグを取得
				if (_bindForm is IFreeSheetMainFrame)
					canClose = ((IFreeSheetMainFrame)_bindForm).CanClose;
			}

			if (!canClose)
				e.Cancel = true;
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_Load(object sender, EventArgs e)
		{
			try
			{
				CreateMainForm();

				this.FormClosing += new FormClosingEventHandler(SFANL08100UA_FormClosing);
			}
			catch (Exception ex)
			{
				string message = "子画面の作成に失敗しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, this.Text
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				this.Close();
			}
		}

		/// <summary>
		/// フォームShownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームが最初に表示されたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_Shown(object sender, EventArgs e)
		{
			try
			{
				// ツールバー等の描画を軽くする為イベントを切る
				this.tToolbarsManager.EventManager.AllEventsEnabled = false;
				this.ultraDockManager.EventManager.AllEventsEnabled = false;

				this.tToolbarsManager.Visible = true;
				this.ultraDockManager.Visible = true;
				_bindForm.Show();

				// イベント復活
				this.tToolbarsManager.EventManager.AllEventsEnabled = true;
				this.ultraDockManager.EventManager.AllEventsEnabled = true;
			}
			catch (FreeSheetStartCancelException ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
					, this.ToString()
					, ex.Message
					, 0
					, MessageBoxButtons.OK);
				this.Close();
			}
			catch (Exception ex)
			{
				string message = "子画面の初期表示中に例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, this.Text
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				this.Close();
			}
		}
		#endregion
	}
}