using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// コンボアイテムクラス
	/// </summary>
	/// <typeparam name="T">コンボアイテムの値の型を指定します。</typeparam>
	/// <remarks>
	/// <br>Note       : コンボボックスに格納する値と名称の組み合わせを定義します。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	internal class ComboItem<T>
	{
		#region << Constructor >>

		/// <summary>
		/// コンボアイテムクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンボアイテムクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem()
		{
		}

		/// <summary>
		/// コンボアイテムクラスコンストラクタ
		/// </summary>
		/// <param name="value">値</param>
		/// <remarks>
		/// <br>Note       : コンボアイテムクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem( T value ) : this( value, "" )
		{
		}

		/// <summary>
		/// コンボアイテムクラスコンストラクタ
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="name">名称</param>
		/// <remarks>
		/// <br>Note       : コンボアイテムクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ComboItem( T value, string name )
		{
			this._value = value;
			this._name  = name;
		}

		#endregion

		#region << Private Members >>

		/// <summary>値</summary>
		private T      _value;
		/// <summary>名称</summary>
		private string _name = "";

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// 値プロパティ
		/// </summary>
		public T Value
		{
			get {
				return this._value;
			}
			set {
				this._value = value;
			}
		}

		/// <summary>
		/// 名称プロパティ
		/// </summary>
		public string Name
		{
			get {
				return this._name;
			}
			set {
				this._name = value;
			}
		}

		#endregion

		#region << Public Methods >>

		/// <summary>
		/// ComboItem クラスを String 型に変換します。
		/// </summary>
		/// <returns>String 型オブジェクト</returns>
		public override string ToString()
		{
			return this._name ?? String.Empty;
		}

		/// <summary>
		/// 指定した System.Object が、現在の System.Object と等しいかどうかを判断します。
		/// </summary>
		/// <param name="obj">現在の System.Object と比較する System.Object。</param>
		/// <returns></returns>
		public override bool Equals( object obj )
		{
			bool equals = false;

			ComboItem<T> comboItem = obj as ComboItem<T>;

			if( comboItem != null ) {
				equals = ( this.Value.Equals( comboItem.Value ) );
			}

			return equals;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion
	}
}
