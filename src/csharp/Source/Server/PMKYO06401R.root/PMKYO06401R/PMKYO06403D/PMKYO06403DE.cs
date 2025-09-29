using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SupplierProcParamWork
	/// <summary>
    ///                      仕入先マスタ抽出条件ワーク
	/// </summary>
	/// <remarks>
    /// <br>note             :   仕入先マスタ抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SupplierProcParamWork
	{
		/// <summary>開始日時</summary>
		private Int64 _beginningDate;

		/// <summary>終了日時</summary>
		private Int64 _endingDate;

		/// <summary>仕入先(開始)</summary>
		private Int32 _supplierCdBegin;

		/// <summary>仕入先(終了)</summary>
		private Int32 _supplierCdEnd;


		/// public propaty name  :  BeginningDate
		/// <summary>開始日時プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int64 UpdateDateTimeBegin
		{
			get{return _beginningDate;}
			set{_beginningDate = value;}
		}

		/// public propaty name  :  EndingDate
		/// <summary>終了日時プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int64 UpdateDateTimeEnd
		{
			get{return _endingDate;}
			set{_endingDate = value;}
		}

		/// public propaty name  :  SupplierCdBegin
		/// <summary>仕入先(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdBeginRF
		{
			get{return _supplierCdBegin;}
			set{_supplierCdBegin = value;}
		}

		/// public propaty name  :  SupplierCdEnd
		/// <summary>仕入先(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCdEndRF
		{
			get{return _supplierCdEnd;}
			set{_supplierCdEnd = value;}
		}


		/// <summary>
        /// 仕入先マスタ抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>SupplierProcParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SupplierProcParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SupplierProcParamWork()
		{
		}

	}
}