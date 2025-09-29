using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンボエディタアイテム（得意先用）
    /// </summary>
	public class ComboEditorItemCustomer : IComparable
	{
		// ===================================================================================== //
		// コンストラクタ
        // ===================================================================================== //
        # region [コンストラクタ]
        /// <summary>
		/// コンストラクタ
		/// </summary>
        public ComboEditorItemCustomer()
		{
			//
		}
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="code"></param>
		/// <param name="name"></param>
		public ComboEditorItemCustomer(int code, string name)
		{
			this._code = code;
			this._name = name;
        }
        # endregion

        # region [private フィールド]
        /// <summary>コード</summary>
        private int _code = 0;
        /// <summary>名称</summary>
        private string _name = string.Empty;
        # endregion

        # region [public プロパティ]
        /// <summary>
        /// コード
        /// </summary>
        public int Code
		{
			get{ return this._code; }
			set{ this._code = value; }
		}
        /// <summary>
        /// 名称
        /// </summary>
		public string Name
		{
			get{ return this._name; }
			set{ this._name = value; }
        }
        # endregion

        // ===================================================================================== //
		// IComparable メンバ
		// ===================================================================================== //
		#region IComparable メンバ
		/// <summary>
		/// 比較処理
		/// </summary>
		/// <param name="obj">対象オブジェクト</param>
		/// <returns>比較結果</returns>
		/// <remarks>
		/// <br>Note　　　: ソート用の比較処理です。</br>
		/// <br>Programer : 980076 妻鳥 謙一郎</br>
		/// </remarks>
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			ComboEditorItemCustomer comboEditorItemCustomer = obj as ComboEditorItemCustomer;
			if (comboEditorItemCustomer == null) return 1;

			return this.Code.CompareTo(comboEditorItemCustomer.Code);
		}
		#endregion
	}
}
