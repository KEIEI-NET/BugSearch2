using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// フローティングWindowクラス
	/// </summary>
	public class FloatingWindow
	{
		/// <summary>画面バッファ</summary>
		private FloatingWindowF _floatingWindowF = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FloatingWindow()
		{
		}

		/// <summary>
		/// フローティング画面表示
		/// </summary>
		/// <param name="owner">オーナー画面</param>
		public void Show(System.Windows.Forms.Form owner)
		{
			if (_floatingWindowF == null) _floatingWindowF = new FloatingWindowF();
			_floatingWindowF.Owner = owner;
			_floatingWindowF.Show();
			_floatingWindowF.Update();
		}

		/// <summary>
		/// フローティング画面終了
		/// </summary>
		public void Close()
		{
			if (_floatingWindowF != null)
			{
				_floatingWindowF.Close();
				_floatingWindowF.Dispose();
				_floatingWindowF = null;
			}
		}

	}
}
