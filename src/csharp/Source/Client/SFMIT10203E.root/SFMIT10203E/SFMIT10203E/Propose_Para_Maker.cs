using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Maker
	/// <summary>
	///                      提案商品起動パラメータクラス（メーカー）
	/// </summary>
	/// <remarks>
	/// <br>note             :   提案商品起動パラメータクラス（メーカー）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Maker
	{
		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>メーカーカナ名称</summary>
		private string _makerKanaName = "";

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>提供データ区分</summary>
		/// <remarks>0:ユーザデータ,1:提供データ</remarks>
		private Int32 _offerDataDiv;


		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>メーカーカナ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーカナ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>提供データ区分プロパティ</summary>
		/// <value>0:ユーザデータ,1:提供データ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供データ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）コンストラクタ
		/// </summary>
		/// <returns>Propose_Para_Makerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Maker()
		{
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）コンストラクタ
		/// </summary>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="makerKanaName">メーカーカナ名称</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="offerDataDiv">提供データ区分(0:ユーザデータ,1:提供データ)</param>
		/// <param name="goodsMakerNm">商品メーカー名称</param>
		/// <returns>Propose_Para_Makerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Maker(Int32 goodsMakerCd,string makerName,string makerKanaName,Int32 displayOrder,Int32 offerDataDiv)
		{
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerKanaName = makerKanaName;
			this._displayOrder = displayOrder;
			this._offerDataDiv = offerDataDiv;

		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）複製処理
		/// </summary>
		/// <returns>Propose_Para_Makerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいPropose_Para_Makerクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Maker Clone()
		{
			return new Propose_Para_Maker(this._goodsMakerCd,this._makerName,this._makerKanaName,this._displayOrder,this._offerDataDiv);
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）比較処理
		/// </summary>
		/// <param name="target">比較対象のPropose_Para_Makerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(Propose_Para_Maker target)
		{
            return ((this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.OfferDataDiv == target.OfferDataDiv));
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）比較処理
		/// </summary>
		/// <param name="propose_Para_Maker1">
		///                    比較するPropose_Para_Makerクラスのインスタンス
		/// </param>
		/// <param name="propose_Para_Maker2">比較するPropose_Para_Makerクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(Propose_Para_Maker propose_Para_Maker1, Propose_Para_Maker propose_Para_Maker2)
		{
            return ((propose_Para_Maker1.GoodsMakerCd == propose_Para_Maker2.GoodsMakerCd)
                 && (propose_Para_Maker1.MakerName == propose_Para_Maker2.MakerName)
                 && (propose_Para_Maker1.MakerKanaName == propose_Para_Maker2.MakerKanaName)
                 && (propose_Para_Maker1.DisplayOrder == propose_Para_Maker2.DisplayOrder)
                 && (propose_Para_Maker1.OfferDataDiv == propose_Para_Maker2.OfferDataDiv));
		}
		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）比較処理
		/// </summary>
		/// <param name="target">比較対象のPropose_Para_Makerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(Propose_Para_Maker target)
		{
			ArrayList resList = new ArrayList();
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.OfferDataDiv != target.OfferDataDiv)resList.Add("OfferDataDiv");

			return resList;
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メーカー）比較処理
		/// </summary>
		/// <param name="propose_Para_Maker1">比較するPropose_Para_Makerクラスのインスタンス</param>
		/// <param name="propose_Para_Maker2">比較するPropose_Para_Makerクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Makerクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(Propose_Para_Maker propose_Para_Maker1, Propose_Para_Maker propose_Para_Maker2)
		{
			ArrayList resList = new ArrayList();
			if(propose_Para_Maker1.GoodsMakerCd != propose_Para_Maker2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(propose_Para_Maker1.MakerName != propose_Para_Maker2.MakerName)resList.Add("MakerName");
			if(propose_Para_Maker1.MakerKanaName != propose_Para_Maker2.MakerKanaName)resList.Add("MakerKanaName");
			if(propose_Para_Maker1.DisplayOrder != propose_Para_Maker2.DisplayOrder)resList.Add("DisplayOrder");
			if(propose_Para_Maker1.OfferDataDiv != propose_Para_Maker2.OfferDataDiv)resList.Add("OfferDataDiv");

			return resList;
		}
	}
}
