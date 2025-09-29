using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>ボタンステータス変更イベント用デリゲート</summary>
	internal delegate void PanelChangeEventHandler(object sender, PanelChangeEventArgs e);

	/// <summary>ランチャー起動イベント用デリゲート</summary>
	internal delegate void LuncherStartEventHandler(object sender, LuncherStartEventArgs e);

	/// <summary>
	/// パネル変更イベントパラメータクラス
	/// </summary>
	internal class PanelChangeEventArgs : EventArgs
	{
		internal const int MODE_UPDATE = 0;
		internal const int MODE_NON_UPDATE = 1;

		int _recodeUpdateMode = 0;
		int _dispNo = 0;

		/// <summary>
		/// パネル変更イベントパラメータクラス デフォルトコンストラクタ
		/// </summary>
		public PanelChangeEventArgs()
		{
			// 
		}

		/// <summary>
		/// パネル変更イベントパラメータクラス コンストラクタ
		/// </summary>
		/// <param name="recodeUpdateMode">画面遷移履歴更新モード</param>
		/// <param name="dispNo">表示画面番号</param>
		public PanelChangeEventArgs(int recodeUpdateMode, int dispNo) : this()
		{
			this._recodeUpdateMode = recodeUpdateMode;
			this._dispNo = dispNo;
		}

		/// <summary>
		/// 画面遷移履歴更新モードプロパティ
		/// </summary>
		public int RecodeUpdateMode
		{
			get
			{
				return this._recodeUpdateMode;
			}
			set
			{
				this._recodeUpdateMode = value;
			}
		}

		/// <summary>
		/// 表示画面番号プロパティ
		/// </summary>
		public int DispNo
		{
			get
			{
				return this._dispNo;
			}
			set
			{
				this._dispNo = value;
			}
		}
	}

	/// <summary>
	/// ランチャー起動イベントパラメータクラス
	/// </summary>
	internal class LuncherStartEventArgs : EventArgs
	{
		LuncherStartAssemblyInfo _luncherStartAssemblyInfo = new LuncherStartAssemblyInfo();
		int _dispNo = 0;

		/// <summary>
		/// ランチャー起動イベントパラメータクラス デフォルトコンストラクタ
		/// </summary>
		public LuncherStartEventArgs()
		{
			// 
		}

		/// <summary>
		/// ランチャー起動イベントパラメータクラス コンストラクタ
		/// </summary>
		/// <param name="luncherStartAssemblyInfo">ランチャースタートアセンブリ情報クラス</param>
		/// <param name="dispNo">表示画面番号</param>
		public LuncherStartEventArgs(LuncherStartAssemblyInfo luncherStartAssemblyInfo, int dispNo) : this()
		{
			this._luncherStartAssemblyInfo = luncherStartAssemblyInfo;
			this._dispNo = dispNo;
		}

		/// <summary>
		/// ランチャースタートアセンブリ情報クラスプロパティ
		/// </summary>
		public LuncherStartAssemblyInfo LuncherStartAssemblyInfoData
		{
			get
			{
				return this._luncherStartAssemblyInfo;
			}
			set
			{
				this._luncherStartAssemblyInfo = value;
			}
		}

		/// <summary>
		/// 表示画面番号プロパティ
		/// </summary>
		public int DispNo
		{
			get
			{
				return this._dispNo;
			}
			set
			{
				this._dispNo = value;
			}
		}
	}
}
