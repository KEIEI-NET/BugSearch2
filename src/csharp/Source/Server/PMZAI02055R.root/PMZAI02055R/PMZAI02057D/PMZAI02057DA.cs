using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockSignOrderCndtnWork
	/// <summary>
	///                      在庫看板印刷抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫看板印刷抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSignOrderCndtnWork 
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>倉庫コード(開始)</summary>
		private string _st_WarehouseCode = "";

		/// <summary>倉庫コード(終了)</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>商品メーカーコード(開始)</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>商品メーカーコード(終了)</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>倉庫棚番(開始)</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>倉庫棚番(終了)</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>商品番号(開始)</summary>
		private string _st_GoodsNo = "";

		/// <summary>商品番号(終了)</summary>
		private string _ed_GoodsNo = "";

		/// <summary>印刷順</summary>
		/// <remarks>0:棚番ラベル 1:在庫枚数分</remarks>
		private Int32 _printType;


		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>範囲指定の場合はnullをセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>倉庫コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>倉庫コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>商品メーカーコード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>商品メーカーコード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>倉庫棚番(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>倉庫棚番(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>商品番号(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>商品番号(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>印刷順プロパティ</summary>
		/// <value>0:棚番ラベル 1:在庫枚数分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}


		/// <summary>
		/// 在庫看板印刷抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockSignOrderCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSignOrderCndtnWork()
		{
		}

	}
}




