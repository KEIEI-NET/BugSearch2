using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
	#region EventHandler
	/// <summary>商品情報変更デリゲート</summary>
	public delegate void ChangedGoodsDataEventHandler(object seder, GoodsAcsEventArgs e);
	#endregion

	//================================================================================
	//  商品アクセスクラスで使用するイベント引数
	//================================================================================
	#region EventArgs
	/// <summary>
	/// 商品アクセスクラスイベント引数
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品アクセスクラスのイベント引数クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.05.10</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.08.30</br>
    /// <br>           :・DC.NS対応</br>
    /// </remarks>
	public class GoodsAcsEventArgs: EventArgs
	{
		/// <summary>対象データ</summary>
		private object _objData;

		/// <summary>エラーメッセージ</summary>
		string _message;
		
		/// <summary>
		/// 商品アクセスクラスイベント引数のコンストラクタ
		/// </summary>
		public GoodsAcsEventArgs(object dst): base()
		{
			this._message = "";
			this._objData = dst;
		}

		/// <summary>
		/// 対象データ
		/// </summary>
		public object Data
		{
			get { return this._objData; }
		}

		/// <summary>
		/// エラーメッセージ
		/// </summary>
		public string Message
		{
			get { return this._message; } 
		}
	}
	#endregion

}
