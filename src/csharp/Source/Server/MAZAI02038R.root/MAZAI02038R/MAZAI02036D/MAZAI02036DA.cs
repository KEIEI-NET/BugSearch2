using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockMoveListCndtnWork
	/// <summary>
	///                      在庫・倉庫移動確認表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫・倉庫移動確認表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockMoveListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>主入出荷拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _bfAfSectionCd;

		/// <summary>主開始入出荷倉庫コード</summary>
		private string _st_MainBfAfEnterWarehCd = "";

		/// <summary>主終了入出荷倉庫コード</summary>
		private string _ed_MainBfAfEnterWarehCd = "";

		/// <summary>在庫移動形式</summary>
		private Int32 _stockMoveFormalDiv;

		/// <summary>開始伝票日付</summary>
		/// <remarks>1:在庫移動,2:倉庫移動</remarks>
		private DateTime _st_ShipArrivalDate;

		/// <summary>終了伝票日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_ShipArrivalDate;

		/// <summary>開始入力日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_CreateDate;

		/// <summary>終了入力日付</summary>
		private DateTime _ed_CreateDate;

		/// <summary>開始入出荷拠点コード</summary>
		private string _st_ShipArrivalSectionCd = "";

		/// <summary>終了入出荷拠点コード</summary>
		private string _ed_ShipArrivalSectionCd = "";

		/// <summary>開始入出荷倉庫コード</summary>
		private string _st_ShipArrivalEnterWarehCd = "";

		/// <summary>終了入出荷倉庫コード</summary>
		private string _ed_ShipArrivalEnterWarehCd = "";

		/// <summary>開始在庫移動入力従業員コード</summary>
		private string _st_StockMvEmpCode = "";

		/// <summary>終了在庫移動入力従業員コード</summary>
		private string _ed_StockMvEmpCode = "";

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:出庫,1:入庫,2：全て</remarks>
		private Int32 _printType;

		/// <summary>出力指定</summary>
		/// <remarks>0:未出力分,1:出力済分,-1：全て</remarks>
		private Int32 _outputDesignat;

        /// <summary>在庫移動確定区分</summary>
        /// <remarks>1：入荷確定あり、２：入荷確定なし </remarks>
        private Int32 _stockMoveFixCode;

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

		/// public propaty name  :  BfAfSectionCd
		/// <summary>主入出荷拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   主入出荷拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] BfAfSectionCd
		{
			get{return _bfAfSectionCd;}
			set{_bfAfSectionCd = value;}
		}

		/// public propaty name  :  St_MainBfAfEnterWarehCd
		/// <summary>主開始入出荷倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   主開始入出荷倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_MainBfAfEnterWarehCd
		{
			get{return _st_MainBfAfEnterWarehCd;}
			set{_st_MainBfAfEnterWarehCd = value;}
		}

		/// public propaty name  :  Ed_MainBfAfEnterWarehCd
		/// <summary>主終了入出荷倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   主終了入出荷倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_MainBfAfEnterWarehCd
		{
			get{return _ed_MainBfAfEnterWarehCd;}
			set{_ed_MainBfAfEnterWarehCd = value;}
		}

		/// public propaty name  :  StockMoveFormalDiv
		/// <summary>在庫移動形式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫移動形式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockMoveFormalDiv
		{
			get{return _stockMoveFormalDiv;}
			set{_stockMoveFormalDiv = value;}
		}

		/// public propaty name  :  St_ShipArrivalDate
		/// <summary>開始伝票日付プロパティ</summary>
		/// <value>1:在庫移動,2:倉庫移動</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始伝票日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_ShipArrivalDate
		{
			get{return _st_ShipArrivalDate;}
			set{_st_ShipArrivalDate = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalDate
		/// <summary>終了伝票日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了伝票日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_ShipArrivalDate
		{
			get{return _ed_ShipArrivalDate;}
			set{_ed_ShipArrivalDate = value;}
		}

		/// public propaty name  :  St_CreateDate
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_CreateDate
		{
			get{return _st_CreateDate;}
			set{_st_CreateDate = value;}
		}

		/// public propaty name  :  Ed_CreateDate
		/// <summary>終了入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_CreateDate
		{
			get{return _ed_CreateDate;}
			set{_ed_CreateDate = value;}
		}

		/// public propaty name  :  St_ShipArrivalSectionCd
		/// <summary>開始入出荷拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入出荷拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_ShipArrivalSectionCd
		{
			get{return _st_ShipArrivalSectionCd;}
			set{_st_ShipArrivalSectionCd = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalSectionCd
		/// <summary>終了入出荷拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入出荷拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_ShipArrivalSectionCd
		{
			get{return _ed_ShipArrivalSectionCd;}
			set{_ed_ShipArrivalSectionCd = value;}
		}

		/// public propaty name  :  St_ShipArrivalEnterWarehCd
		/// <summary>開始入出荷倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入出荷倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_ShipArrivalEnterWarehCd
		{
			get{return _st_ShipArrivalEnterWarehCd;}
			set{_st_ShipArrivalEnterWarehCd = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalEnterWarehCd
		/// <summary>終了入出荷倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入出荷倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_ShipArrivalEnterWarehCd
		{
			get{return _ed_ShipArrivalEnterWarehCd;}
			set{_ed_ShipArrivalEnterWarehCd = value;}
		}

		/// public propaty name  :  St_StockMvEmpCode
		/// <summary>開始在庫移動入力従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始在庫移動入力従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_StockMvEmpCode
		{
			get{return _st_StockMvEmpCode;}
			set{_st_StockMvEmpCode = value;}
		}

		/// public propaty name  :  Ed_StockMvEmpCode
		/// <summary>終了在庫移動入力従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了在庫移動入力従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_StockMvEmpCode
		{
			get{return _ed_StockMvEmpCode;}
			set{_ed_StockMvEmpCode = value;}
		}

		/// public propaty name  :  St_SupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SupplierCd
		{
			get{return _st_SupplierCd;}
			set{_st_SupplierCd = value;}
		}

		/// public propaty name  :  Ed_SupplierCd
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SupplierCd
		{
			get{return _ed_SupplierCd;}
			set{_ed_SupplierCd = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:出庫,1:入庫,2：全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  OutputDesignat
		/// <summary>出力指定プロパティ</summary>
		/// <value>0:未出力分,1:出力済分,-1：全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutputDesignat
		{
			get{return _outputDesignat;}
			set{_outputDesignat = value;}
		}

        /// public propaty name  :  StockMoveFixCode
        /// <summary>在庫移動確定区分プロパティ</summary>
        /// <value>1：入荷確定あり、２：入荷確定なし </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動確定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

		/// <summary>
		/// 在庫・倉庫移動確認表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockMoveListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMoveListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockMoveListCndtnWork()
		{
		}

	}

}




