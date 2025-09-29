using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
	
namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrJoinPartsCondWork
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
	public class OfrPartsCondWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>ハイフン付部品品番</summary>
		private string _prtsNo = "";

        /// <summary>元品番（結合、セットの元品番）</summary>
        private string _prtsNoOrg = "";

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

		/// public propaty name  :  PrtsNo
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

        /// public propaty name  :  PrtsNoOrg
        /// <summary>元品番（結合、セットの元品番）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元品番（結合、セットの元品番）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtsNoOrg
        {
            get { return _prtsNoOrg; }
            set { _prtsNoOrg = value; }
        }

		/// <summary>
		/// ユーザー結合検索抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>UsrJoinPartsCondWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsCondWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OfrPartsCondWork()
		{
		}
	}
}
