using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 変更PG案内エラー例外クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 変更PG案内のページ内でエラーが発生した場合に発生します。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.28</br>
	/// </remarks>
	public class NSChangeInfoErrorException : Exception
	{
		#region << Constructor >>

		/// <summary>
		/// 変更PG案内エラー例外クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 変更PG案内エラー例外クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException() : this( -1, "", null )
		{
		}

		/// <summary>
		/// 変更PG案内エラー例外クラスコンストラクタ
		/// </summary>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <remarks>
		/// <br>Note       : 変更PG案内エラー例外クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( string message ) : this( -1, message, null )
		{
		}

		/// <summary>
		/// 変更PG案内エラー例外クラスコンストラクタ
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <remarks>
		/// <br>Note       : 変更PG案内エラー例外クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( int status, string message ) : this( status, message, null )
		{
		}

		/// <summary>
		/// 変更PG案内エラー例外クラスコンストラクタ
		/// </summary>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照。</param>
		/// <remarks>
		/// <br>Note       : 変更PG案内エラー例外クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( string message, Exception innerException ) : this( -1, message, innerException )
		{
		}

		/// <summary>
		/// 変更PG案内エラー例外クラスコンストラクタ
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照。</param>
		/// <remarks>
		/// <br>Note       : 変更PG案内エラー例外クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.28</br>
		/// </remarks>
		public NSChangeInfoErrorException( int status, string message, Exception innerException ) : base( message, innerException )
		{
			this._status = status;
		}

		#endregion



		#region << Private Members >>

		/// <summary>ステータス</summary>
		private int _status = -1;

		#endregion



		#region << Public Properties >>

		/// <summary>
		/// ステータス
		/// </summary>
		public int Status
		{
			get {
				return this._status;
			}
		}

		#endregion

    }
}
