using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ツールバーマネージャーカスタマイズ設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ツールマネージャーのカスタマイズ設定を管理するクラスです。</br>
	/// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2008.05.22</br>
	/// <br></br>
	/// </remarks>
	public class ToolbarManagerCustomizeSettingAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private static readonly string ct_CommonFileName = "ToolButtonCustomize";

		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ToolbarManagerCustomizeSettingAcs()
		{
		}

		#endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods

		/// <summary>
		/// ツールマネージャーのカスタマイズ情報をデシリアライズします。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
		/// <returns>ToolManagerCustomizeSettingオブジェクト</returns>
		private static ToolManagerCustomizeSetting Deserialize( string saveFileName )
		{
			if (string.IsNullOrEmpty(saveFileName)) return null;

			string fileName = string.Format("{0}_{1}.xml", ToolbarManagerCustomizeSettingAcs.ct_CommonFileName, saveFileName);
			try
			{
				if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
				{
					return UserSettingController.ByteDeserializeUserSetting<ToolManagerCustomizeSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}
			catch (System.InvalidOperationException)
			{
				UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
			}
			return null;
		}

		/// <summary>
		/// ツールマネージャーのカスタマイズ情報をシリアライズします。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
		/// <param name="toolManagerCustomizeSetting">ToolManagerCustomizeSettingオブジェクト</param>
		private static void Serialize( string saveFileName, ToolManagerCustomizeSetting toolManagerCustomizeSetting )
		{
			if (string.IsNullOrEmpty(saveFileName)) return;

			string fileName = string.Format("{0}_{1}.xml", ct_CommonFileName, saveFileName);

            UserSettingController.ByteSerializeUserSetting(toolManagerCustomizeSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
		}

		/// <summary>
		/// ツールバーのカスタマイズ情報を設定します。
		/// </summary>
		/// <param name="toolMenuCustomizeSetting">ToolMenuCustomizeSettingオブジェクト</param>
		/// <param name="toolBar">UltraToolbarオブジェクト</param>
		private static void ToolbarCustomizeSetting( ToolMenuCustomizeSetting toolMenuCustomizeSetting, ref Infragistics.Win.UltraWinToolbars.UltraToolbar toolBar )
		{
            toolBar.Visible = toolMenuCustomizeSetting.ToolBarVisible;
            toolBar.DockedRow = toolMenuCustomizeSetting.DockedRow;
            toolBar.DockedColumn = toolMenuCustomizeSetting.DockedColumn;
            toolBar.DockedPosition = (Infragistics.Win.UltraWinToolbars.DockedPosition)toolMenuCustomizeSetting.DockedPosition;
                
            for (int index = 0; index < toolBar.Tools.Count; index++)
            {
                ToolButtonCustomizeSetting toolButtonCustomizeSetting = toolMenuCustomizeSetting.GetToolButtonCustomizeSetting(toolBar.Tools[index].Key);

                if (toolButtonCustomizeSetting != null)
                {
                    toolBar.Tools[index].CustomizedVisible = toolButtonCustomizeSetting.ToolButtonCustomizeInfo.CustomizedVisible;
                }
            }
		}

		/// <summary>
		/// ツールバーのカスタマイズ設定を取得します。
		/// </summary>
		/// <param name="toolBar">UltraToolbarオブジェクト</param>
		/// <returns></returns>
		private static ToolMenuCustomizeSetting GetToolbarCustomizeSetting( Infragistics.Win.UltraWinToolbars.UltraToolbar toolBar )
		{
			ToolMenuCustomizeSetting toolButtonCustomizeSettings = new ToolMenuCustomizeSetting();
			toolButtonCustomizeSettings.ToolBarKey= toolBar.Key;
            toolButtonCustomizeSettings.ToolBarVisible = toolBar.Visible;
            toolButtonCustomizeSettings.DockedRow = toolBar.DockedRow;
            toolButtonCustomizeSettings.DockedColumn = toolBar.DockedColumn;
            toolButtonCustomizeSettings.DockedPosition = (int)toolBar.DockedPosition;

			for (int index = 0; index < toolBar.Tools.Count; index++)
			{
				string key = toolBar.Tools[index].Key;
				Infragistics.Win.DefaultableBoolean defaultboolean = toolBar.Tools[key].CustomizedVisible;
				toolButtonCustomizeSettings.ToolButtonCustomizeSettingsList.Add(new ToolButtonCustomizeSetting(key, new ToolButtonCustomizeInfo(defaultboolean)));
			}

			return toolButtonCustomizeSettings;
		}


		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// ツールバーマネージャーのカスタマイズ情報をロードします。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
        /// <param name="ultraToolbarsManager">UltraToolbarsManagerオブジェクト</param>
		public static void LoadToolManagerCustomizeInfo( string saveFileName, ref Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = ToolbarManagerCustomizeSettingAcs.Deserialize(saveFileName);
			if (toolManagerCustomizeSetting == null)
			{
				return;
			}

			for (int index = 0; index < ultraToolbarsManager.Toolbars.Count; index++)
			{
				ToolMenuCustomizeSetting toolMenuCustomizeSetting = toolManagerCustomizeSetting.GetMenueToolButtonCustomizeSettings(ultraToolbarsManager.Toolbars[index].Key);
				if (toolMenuCustomizeSetting != null)
				{
					Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = ultraToolbarsManager.Toolbars[index];
					ToolbarManagerCustomizeSettingAcs.ToolbarCustomizeSetting(toolMenuCustomizeSetting, ref toolbar);
				}
			}

		}

		/// <summary>
		/// ツールバーマネージャーのカスタマイズ情報をロードします。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
		/// <param name="tToolbarsManatger">TToolbarsManagerオブジェクト</param>
		public static void LoadToolManagerCustomizeInfo( string saveFileName, ref TToolbarsManager tToolbarsManatger )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = ToolbarManagerCustomizeSettingAcs.Deserialize(saveFileName);
			if (toolManagerCustomizeSetting == null)
			{
				return;
			}

			for (int index = 0; index < tToolbarsManatger.Toolbars.Count; index++)
			{
				ToolMenuCustomizeSetting toolMenuCustomizeSetting = toolManagerCustomizeSetting.GetMenueToolButtonCustomizeSettings(tToolbarsManatger.Toolbars[index].Key);
				if (toolMenuCustomizeSetting != null)
				{
					Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = tToolbarsManatger.Toolbars[index];
					ToolbarManagerCustomizeSettingAcs.ToolbarCustomizeSetting(toolMenuCustomizeSetting, ref toolbar);
				}
			}
		}

		/// <summary>
		/// ツールバーマネージャーのカスタマイズ情報を保存します。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
		/// <param name="ultraToolbarsManager">UltraToolbarsManagerオブジェクト</param>
		public static void SaveToolManagerCustomizeInfo( string saveFileName, Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = new ToolManagerCustomizeSetting();

			for (int index = 0; index < ultraToolbarsManager.Toolbars.Count; index++)
			{
				Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = ultraToolbarsManager.Toolbars[index];
				toolManagerCustomizeSetting.ToolMenuCustomizeSettingList.Add(GetToolbarCustomizeSetting(toolbar));
			}

			ToolbarManagerCustomizeSettingAcs.Serialize(saveFileName, toolManagerCustomizeSetting);
		}
		
		/// <summary>
		/// ツールバーマネージャーのカスタマイズ情報を保存します。
		/// </summary>
		/// <param name="saveFileName">保存ファイル名</param>
		/// <param name="tToolbarsManatger">TToolbarsManagerオブジェクト</param>
		public static void SaveToolManagerCustomizeInfo( string saveFileName, TToolbarsManager tToolbarsManatger )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = new ToolManagerCustomizeSetting();

			for (int index = 0; index < tToolbarsManatger.Toolbars.Count; index++)
			{
				Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = tToolbarsManatger.Toolbars[index];
				toolManagerCustomizeSetting.ToolMenuCustomizeSettingList.Add(GetToolbarCustomizeSetting(toolbar));
			}

			ToolbarManagerCustomizeSettingAcs.Serialize(saveFileName, toolManagerCustomizeSetting);
		}

		#endregion
	}

	/// <summary>
	/// ツールマネージャーカスタマイズ設定クラス
	/// </summary>
	[Serializable]
	public class ToolManagerCustomizeSetting
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private List<ToolMenuCustomizeSetting> _toolMenuCustomizeSettingList;

		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ToolManagerCustomizeSetting()
		{
			this._toolMenuCustomizeSettingList = new List<ToolMenuCustomizeSetting>();
		}

		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>ツールメニューカスタマイズ設定リスト</summary>
		public List<ToolMenuCustomizeSetting> ToolMenuCustomizeSettingList
		{
			get { return _toolMenuCustomizeSettingList; }
			set { _toolMenuCustomizeSettingList = value; }
		}

		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// ツールメニューカスタマイズ設定を取得します。
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		public ToolMenuCustomizeSetting GetMenueToolButtonCustomizeSettings( string keyName )
		{
			foreach (ToolMenuCustomizeSetting toolButtonCustomizeSettings in _toolMenuCustomizeSettingList)
			{
				if (toolButtonCustomizeSettings.ToolBarKey == keyName)
				{
					return toolButtonCustomizeSettings;
				}
			}
			return null;
		}

		#endregion
	}

	/// <summary>
	/// ツールメニューカスタマイズ設定クラス
	/// </summary>
	[Serializable]
	public class ToolMenuCustomizeSetting
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private List<ToolButtonCustomizeSetting> _toolButtonCustomizeSettingList;
		private string _toolBarKey;
        private bool _toolBarVisible;
        private int _dockedRow;
        private int _dockedColumn;
        private int _dockedPosition;

		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ToolMenuCustomizeSetting()
		{
			this._toolBarKey = "";
            this._toolBarVisible = true;
            this._dockedColumn = 0;
            this._dockedRow = 0;
			this._toolButtonCustomizeSettingList = new List<ToolButtonCustomizeSetting>();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="toolBarKey">ツールバーのキー</param>
        /// <param name="toolbarVisible">ツールバーの表示有無</param>
		/// <param name="toolButtonCustomizeSettingList">ツールバーのツールボタンカスタマイズ設定リスト</param>
        public ToolMenuCustomizeSetting(string toolBarKey, bool toolbarVisible, List<ToolButtonCustomizeSetting> toolButtonCustomizeSettingList)
		{
			this._toolBarKey = toolBarKey;
            this._toolBarVisible = toolbarVisible;
			this._toolButtonCustomizeSettingList = toolButtonCustomizeSettingList;
		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>ツールバーのキー</summary>
		public string ToolBarKey
		{
			get { return _toolBarKey; }
			set { _toolBarKey = value; }
		}

        /// <summary>ツールバーの表示有無</summary>
        public bool ToolBarVisible
        {
            get { return _toolBarVisible; }
            set { _toolBarVisible = value; }
        }

		/// <summary>ツールバーのツールボタンカスタマイズ設定リスト</summary>
		public List<ToolButtonCustomizeSetting> ToolButtonCustomizeSettingsList
		{
			get { return _toolButtonCustomizeSettingList; }
			set { _toolButtonCustomizeSettingList = value; }
		}

        /// <summary></summary>
        public int DockedRow
        {
            get { return _dockedRow; }
            set { _dockedRow = value; }
        }

        /// <summary></summary>
        public int DockedColumn
        {
            get { return _dockedColumn; }
            set { _dockedColumn = value; }
        }

        /// <summary></summary>
        public int DockedPosition
        {
            get { return _dockedPosition; }
            set { _dockedPosition = value; }
        }

		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods

		/// <summary>
		/// ツールボタンカスタマイズ設定を取得します。
		/// </summary>
		/// <param name="buttonKey">取得するツールボタンのキー</param>
		/// <returns>ツールボタンカスタマイズ設定オブジェクト</returns>
		public ToolButtonCustomizeSetting GetToolButtonCustomizeSetting( string buttonKey )
		{
			foreach (ToolButtonCustomizeSetting toolButtonCustomizeSetting in this._toolButtonCustomizeSettingList)
			{
				if (toolButtonCustomizeSetting.ButtonKey == buttonKey)
				{
					return toolButtonCustomizeSetting;
				}
			}

			return null;
		}
		#endregion
	}

	/// <summary>
	/// ツールボタンカスタマイズ設定クラス
	/// </summary>
	[Serializable]
	public class ToolButtonCustomizeSetting
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private string _buttonKey;
		private ToolButtonCustomizeInfo _toolButtonCustomizeInfo;

		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ToolButtonCustomizeSetting()
		{
			this._toolButtonCustomizeInfo = new ToolButtonCustomizeInfo();
			this._buttonKey = "";
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="buttonKey">ツールボタンキー</param>
		/// <param name="toolButtonCustomizeInfo">ツールボタンカスタマイズ設定情報オブジェクト</param>
		public ToolButtonCustomizeSetting( string buttonKey, ToolButtonCustomizeInfo toolButtonCustomizeInfo )
		{
			this._toolButtonCustomizeInfo = toolButtonCustomizeInfo;
			this._buttonKey = buttonKey;
		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties
		/// <summary>ツールボタンのキー</summary>
		public string ButtonKey
		{
			get { return _buttonKey; }
			set { _buttonKey = value; }
		}

		/// <summary>ツールボタンカスタマイズ設定情報</summary>
		public ToolButtonCustomizeInfo ToolButtonCustomizeInfo
		{
			get { return _toolButtonCustomizeInfo; }
			set { _toolButtonCustomizeInfo = value; }
		}
		#endregion
	}

	/// <summary>
	/// ツールボタンカスタマイズ設定情報クラス
	/// </summary>
	[Serializable]
	public class ToolButtonCustomizeInfo
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members

		private Infragistics.Win.DefaultableBoolean _customizedVisible;

		#endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructors
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public ToolButtonCustomizeInfo()
		{
			this._customizedVisible = Infragistics.Win.DefaultableBoolean.Default;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="customizedVisible">CustomizedVisibleプロパティ値</param>
		public ToolButtonCustomizeInfo( Infragistics.Win.DefaultableBoolean customizedVisible )
		{
			this._customizedVisible = customizedVisible;
		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>CustomizedVisible</summary>
		public Infragistics.Win.DefaultableBoolean CustomizedVisible
		{
			get { return _customizedVisible; }
			set { _customizedVisible = value; }
		}

		#endregion
	}
}
