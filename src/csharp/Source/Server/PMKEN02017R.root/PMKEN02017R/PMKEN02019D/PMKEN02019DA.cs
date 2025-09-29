using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrmSettingPrintOrderCndtnWork
	/// <summary>
	///                      優良設定印刷抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   優良設定印刷抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrmSettingPrintOrderCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>商品中分類コード(開始)</summary>
		/// <remarks>※中分類</remarks>
		private Int32 _st_GoodsMGroup;

		/// <summary>商品中分類コード(終了)</summary>
		/// <remarks>※中分類</remarks>
		private Int32 _ed_GoodsMGroup;


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

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>商品中分類コード(開始)プロパティ</summary>
		/// <value>※中分類</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>商品中分類コード(終了)プロパティ</summary>
		/// <value>※中分類</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}


		/// <summary>
		/// 優良設定印刷抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>PrmSettingPrintOrderCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrmSettingPrintOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrmSettingPrintOrderCndtnWork()
		{
		}

	}
}




