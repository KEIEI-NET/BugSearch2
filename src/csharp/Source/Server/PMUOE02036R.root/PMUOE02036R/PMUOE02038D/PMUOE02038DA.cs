using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SendBeforOrderCndtnWork
	/// <summary>
	///                      送信前リスト抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   送信前リスト抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SendBeforOrderCndtnWork
	{
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";
        
        /// <summary>システム区分</summary>
		/// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
		private Int32 _systemDivCd;

		/// <summary>開始オンライン番号</summary>
		private Int32 _st_OnlineNo;

		/// <summary>終了オンライン番号</summary>
		private Int32 _ed_OnlineNo;

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>開始UOE発注先コード</summary>
		private Int32 _st_UOESupplierCd;

		/// <summary>終了UOE発注先コード</summary>
		private Int32 _ed_UOESupplierCd;


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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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

		/// public propaty name  :  St_OnlineNo
		/// <summary>開始オンライン番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始オンライン番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_OnlineNo
		{
			get{return _st_OnlineNo;}
			set{_st_OnlineNo = value;}
		}

		/// public propaty name  :  Ed_OnlineNo
		/// <summary>終了オンライン番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了オンライン番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_OnlineNo
		{
			get{return _ed_OnlineNo;}
			set{_ed_OnlineNo = value;}
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

		/// public propaty name  :  St_UOESupplierCd
		/// <summary>開始UOE発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_UOESupplierCd
		{
			get{return _st_UOESupplierCd;}
			set{_st_UOESupplierCd = value;}
		}

		/// public propaty name  :  Ed_UOESupplierCd
		/// <summary>終了UOE発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_UOESupplierCd
		{
			get{return _ed_UOESupplierCd;}
			set{_ed_UOESupplierCd = value;}
		}


		/// <summary>
		/// 送信前リスト抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SendBeforOrderCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SendBeforOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SendBeforOrderCndtnWork()
		{
		}

	}
}




