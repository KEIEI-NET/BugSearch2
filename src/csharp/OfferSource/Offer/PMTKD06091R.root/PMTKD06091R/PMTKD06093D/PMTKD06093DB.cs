using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PartsNoSearchCondWork
	/// <summary>
	///                      ユーザー結合検索抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザー結合検索抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PartsNoSearchCondWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>ハイフン付部品品番</summary>
		private string _prtsNo = "";

		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  PrtsNoWithHyphen
		/// <summary>ハイフン付部品品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ハイフン付部品品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtsNo
		{
			get { return _prtsNo; }
			set { _prtsNo = value; }
		}

		/// <summary>
		/// ユーザー結合検索抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>OfrJoinPartsCondWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrJoinPartsCondWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PartsNoSearchCondWork()
		{
		}
	}
}
