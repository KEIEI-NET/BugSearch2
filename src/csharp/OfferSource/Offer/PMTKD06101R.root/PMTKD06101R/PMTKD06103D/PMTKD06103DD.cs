using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CtgyMdlLnkCondWork
	/// <summary>
	///                      類別車両情報抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   類別車両情報抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CtgyMdlLnkCondWork
	{
		/// <summary>フル型式固定番号</summary>
		private Int32[] _fullModelFixedNo;


		/// public propaty name  :  FullModelFixedNo
		/// <summary>フル型式固定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   フル型式固定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] FullModelFixedNo
		{
			get { return _fullModelFixedNo; }
			set { _fullModelFixedNo = value; }
		}


		/// <summary>
		/// 類別車両情報抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>CtgyMdlLnkCondWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkCondWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CtgyMdlLnkCondWork()
		{
		}

	}
}
