using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderPointOrderCndtnWork
	/// <summary>
	///                      発注点発注抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   発注点発注抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008.12.10  渋谷　大輔</br>
    /// <br>                 :   帳票タイプ区分追加</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderPointOrderCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>倉庫指定（複数指定）</summary>
		/// <remarks>nullの場合は、開始終了範囲指定を使用</remarks>
		private string[] _warehouseCodes;

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCode;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCode;

		/// <summary>仕入先指定（複数指定</summary>
		/// <remarks>nullの場合は、開始終了範囲指定を使用</remarks>
		private Int32[] _supplierCodes;

		/// <summary>受託在庫区分</summary>
		/// <remarks>0:発注対象としない,1:発注対象とする</remarks>
		private Int32 _trustStockDiv;

		/// <summary>対象区分</summary>
		/// <remarks>0:全て,1:UOE発注分,2:UOE発注以外</remarks>
		private Int32 _objDiv;

		/// <summary>UOE以外発注残更新</summary>
		/// <remarks>0:する,しない</remarks>
		private Int32 _orderRemainUpDate;

		/// <summary>現在庫数基準</summary>
        /// <remarks>0:ﾏｲﾅｽはｾﾞﾛで計算,1:ﾏｲﾅｽも含めて計算</remarks>
        private Int32 _stkCntStandard;

        /// <summary>発注基準</summary>
        /// <remarks>0:最低在庫,1:最高在庫</remarks>
        private Int32 _orderStandard;
        
        /// <summary>貸出数計算</summary>
		/// <remarks>0:する,しない</remarks>
		private Int32 _lendCntCalc;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>0:発注一覧表,1:発注残一覧表</remarks>
        private Int32 _prtPaperTypeDiv;

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
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  WarehouseCodes
		/// <summary>倉庫指定（複数指定）プロパティ</summary>
		/// <value>nullの場合は、開始終了範囲指定を使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫指定（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] WarehouseCodes
		{
			get{return _warehouseCodes;}
			set{_warehouseCodes = value;}
		}

		/// public propaty name  :  St_SupplierCode
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SupplierCode
		{
			get{return _st_SupplierCode;}
			set{_st_SupplierCode = value;}
		}

		/// public propaty name  :  Ed_SupplierCode
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SupplierCode
		{
			get{return _ed_SupplierCode;}
			set{_ed_SupplierCode = value;}
		}

		/// public propaty name  :  SupplierCodes
		/// <summary>仕入先指定（複数指定プロパティ</summary>
		/// <value>nullの場合は、開始終了範囲指定を使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先指定（複数指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] SupplierCodes
		{
			get{return _supplierCodes;}
			set{_supplierCodes = value;}
		}

		/// public propaty name  :  TrustStockDiv
		/// <summary>受託在庫区分プロパティ</summary>
		/// <value>0:発注対象としない,1:発注対象とする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受託在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TrustStockDiv
		{
			get{return _trustStockDiv;}
			set{_trustStockDiv = value;}
		}

		/// public propaty name  :  ObjDiv
		/// <summary>対象区分プロパティ</summary>
		/// <value>0:全て,1:UOE発注分,2:UOE発注以外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ObjDiv
		{
			get{return _objDiv;}
			set{_objDiv = value;}
		}

		/// public propaty name  :  OrderRemainUpDate
		/// <summary>UOE以外発注残更新プロパティ</summary>
		/// <value>0:する,しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE以外発注残更新プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderRemainUpDate
		{
			get{return _orderRemainUpDate;}
			set{_orderRemainUpDate = value;}
		}

        /// public propaty name  :  OrderStandard
        /// <summary>現在庫数基準プロパティ</summary>
        /// <value>0:ﾏｲﾅｽはｾﾞﾛで計算,1:ﾏｲﾅｽも含めて計算</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数基準プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StkCntStandard
        {
            get { return _stkCntStandard; }
            set { _stkCntStandard = value; }
        }

        /// public propaty name  :  OrderStandard
		/// <summary>発注基準プロパティ</summary>
		/// <value>0:最低在庫,1:最高在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注基準プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderStandard
		{
			get{return _orderStandard;}
			set{_orderStandard = value;}
		}

        /// public propaty name  :  LendCntCalc
		/// <summary>貸出数計算プロパティ</summary>
		/// <value>0:する,しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   貸出数計算プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LendCntCalc
		{
			get{return _lendCntCalc;}
			set{_lendCntCalc = value;}
		}

        /// public propaty name  :  PrtPaperTypeDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>0:発注一覧表,1:発注残一覧表</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtPaperTypeDiv
        {
            get { return _prtPaperTypeDiv; }
            set { _prtPaperTypeDiv = value; }
        }


		/// <summary>
		/// 発注点発注抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>OrderPointOrderCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderPointOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderPointOrderCndtnWork()
		{
		}

	}
}




