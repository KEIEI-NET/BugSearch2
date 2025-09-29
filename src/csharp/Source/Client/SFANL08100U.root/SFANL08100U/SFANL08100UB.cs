using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票起動ナビゲーター作成画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票用のメインフレーム用ナビゲーターの</br>
	/// <br>			: 作成画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08100UB : Form, IFreeSheetMainFrame
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08100UB()
		{
			InitializeComponent();
		}
		#endregion

		#region SFANL00001IA メンバ
		/// <summary>クローズ許可プロパティ</summary>
		/// <value>画面を終了してよい場合はTrue、問題がある場合はFalseを返します</value>
		public bool CanClose
		{
			get { return true; }
		}

		/// <summary>
		/// ツールバークリックイベント（メインフレーム）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		public void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_Open:
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Title	= "ナビゲーター情報を開く";
					openFileDialog.Filter	= "DATファイル|*.dat";
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						LoadProc(openFileDialog.FileName);
					}
					break;
				}
				case FreeSheetConst.ctToolBase_Save:
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Title	= "ナビゲーター情報を保存";
					saveFileDialog.Filter	= "DATファイル|*.dat";
					saveFileDialog.RestoreDirectory = true;
					saveFileDialog.FileName	= FreeSheetConst.ctFILE_NAVIGATOR;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						if (SaveProc(saveFileDialog.FileName) == 0)
							MessageBox.Show("保存しました");
					}
					break;
				}
			}
		}

		/// <summary>
		/// ドック情報取得処理
		/// </summary>
		/// <param name="dockAreaPaneArray">ドック情報コレクション</param>
		/// <returns>ステータス</returns>
		public int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray)
		{
			dockAreaPaneArray = null;
			return 4;
		}

		/// <summary>
		/// ツールバー情報取得処理
		/// </summary>
		/// <param name="rootToolsCollection">ツールコレクション</param>
		/// <param name="toolbarsCollection">ツールバーコレクション</param>
		/// <returns>ステータス</returns>
		public int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection)
		{
			return 4;
		}

		/// <summary>非表示ツールボタン情報プロパティ</summary>
		/// <value>初期提供分のツールボタンの内、非表示にしたいツールボタンのキー情報</value>
		/// <remarks>FreeSheetConstを使用します。</remarks>
		public string[] HideToolButton
		{
			get
			{
				return new string[] {
					FreeSheetConst.ctToolBase_New,
					FreeSheetConst.ctToolBase_Print,
					FreeSheetConst.ctPopupMenu_Edit,
					FreeSheetConst.ctPopupMenu_Window,
					FreeSheetConst.ctPopupMenu_Display,
					FreeSheetConst.ctPopupMenu_Help
				};
			}
		}

		/// <summary>
		/// ツールボタン入力制御通知イベント
		/// </summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>
		/// ツールボタン表示制御通知イベント
		/// </summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ナビゲータ情報読込処理
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: ナビゲーター情報の保存を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int LoadProc(string filePath)
		{
			Bind_DataSet.Tables[0].Rows.Clear();

			using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
			{
				try
				{
					if (fileStream.Length > 0)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						DataSet ds = (DataSet)binaryFormatter.Deserialize(fileStream);
						foreach (DataRow dr in ds.Tables[0].Rows)
							this.Bind_DataSet.Tables[0].Rows.Add(dr.ItemArray);
					}
				}
				catch (Exception)
				{
					MessageBox.Show("ナビゲーター情報の読込に失敗しました。" + Environment.NewLine + "指定ファイルが自由帳票用のナビゲーターファイルか確認してください。");
				}
				finally
				{
					fileStream.Close();
				}
			}

			return 0;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ナビゲーター情報の保存を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int SaveProc(string filePath)
		{
			int status = 0;

			try
			{
				if (InputCheck())
				{
					using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
					{
						try
						{
							BinaryFormatter binaryFormatter = new BinaryFormatter();
							binaryFormatter.Serialize(fileStream, this.Bind_DataSet);
						}
						finally
						{
							fileStream.Close();
						}
					}
				}
				else
				{
					status = -1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("保存処理にて例外が発生しました。" + Environment.NewLine + ex.Message);
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: データ保存前のチェック処理です。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private bool InputCheck()
		{
			this.dataGridView.EndEdit();

			foreach (DataGridViewRow dr in this.dataGridView.Rows)
			{
				if (dr.IsNewRow)
					continue;

				// nullの場合は空文字に変換
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_STARTARGS].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_CLASSNAME].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_CLASSNAME].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_TITLENAME].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_TITLENAME].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value = string.Empty;

				// データ未設定の行は削除
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_CLASSNAME].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_TITLENAME].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value.Equals(string.Empty))
				{
					this.dataGridView.Rows.Remove(dr);
					continue;
				}

				// 以下入力チェック
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value.Equals(string.Empty))
				{
					MessageBox.Show("引数が入力されていません。");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_STARTARGS];
					return false;
				}

				if (dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value.Equals(string.Empty))
				{
					MessageBox.Show("アセンブリIDが入力されていません。");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_ASSEMBLYID];
					return false;
				}

				if (dr.Cells[FreeSheetConst.COL_CLASSNAME].Value.Equals(string.Empty))
				{
					MessageBox.Show("クラス名が入力されていません。");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_CLASSNAME];
					return false;
				}
			}

			return true;
		}
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL00000UB_Load(object sender, EventArgs e)
		{
			ToolButtonEnableChanged(new List<string>(), true);

			List<string> hideToolKey = new List<string>();
			hideToolKey.Add(FreeSheetConst.ctToolBase_New);
			hideToolKey.Add(FreeSheetConst.ctToolBase_Print);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Edit);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Window);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Display);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Help);
			ToolButtonVisibleChanged(hideToolKey, false);

			LoadProc(FreeSheetConst.ctFILE_NAVIGATOR);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note		: 選択されたセルに対して編集モードが開始するときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.28</br>
		/// </remarks>
		private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.ColumnIndex == 3)
				this.dataGridView.ImeMode = ImeMode.Hiragana;
			else
				this.dataGridView.ImeMode = ImeMode.Disable;
		}
		#endregion
	}
}