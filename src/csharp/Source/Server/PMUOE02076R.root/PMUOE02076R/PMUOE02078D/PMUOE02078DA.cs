using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SupplierUnmOrderCndtnWork
	/// <summary>
	///                      仕入ｱﾝﾏｯﾁﾘｽﾄ抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入ｱﾝﾏｯﾁﾘｽﾄ抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SupplierUnmOrderCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>システム区分</summary>
		/// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
		private Int32 _systemDivCd;

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>開始受信日付</summary>
		private DateTime _st_ReceiveDate;

		/// <summary>終了受信日付</summary>
		private DateTime _ed_ReceiveDate;


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

		/// public propaty name  :  SystemDivCd
		/// <summary>システム区分プロパティ</summary>
		/// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   システム区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
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

		/// public propaty name  :  St_ReceiveDate
		/// <summary>開始受信日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始受信日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_ReceiveDate
		{
			get{return _st_ReceiveDate;}
			set{_st_ReceiveDate = value;}
		}

		/// public propaty name  :  Ed_ReceiveDate
		/// <summary>終了受信日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了受信日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_ReceiveDate
		{
			get{return _ed_ReceiveDate;}
			set{_ed_ReceiveDate = value;}
		}


		/// <summary>
		/// 仕入ｱﾝﾏｯﾁﾘｽﾄ抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SupplierUnmOrderCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SupplierUnmOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SupplierUnmOrderCndtnWork()
		{
		}

	}
}




