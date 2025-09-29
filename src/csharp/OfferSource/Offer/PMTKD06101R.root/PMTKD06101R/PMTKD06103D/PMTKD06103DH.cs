using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ColTrmEquSearchCondWork
	/// <summary>
	///                      カラートリム装備抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   カラートリム装備抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ColTrmEquSearchCondWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>系統コード</summary>
		private Int32[] _systematicCode;

		/// <summary>生産年式コード</summary>
		private Int32[] _produceTypeOfYearCd;

        /// <summary>フル型式固定番号</summary>
        private Int32[] _fullModelFixedNo;

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

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get { return _modelCode; }
			set { _modelCode = value; }
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get { return _modelSubCode; }
			set { _modelSubCode = value; }
		}

		/// public propaty name  :  SystematicCode
		/// <summary>系統コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   系統コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] SystematicCode
		{
			get { return _systematicCode; }
			set { _systematicCode = value; }
		}

		/// public propaty name  :  ProduceTypeOfYearCd
		/// <summary>生産年式コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産年式コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] ProduceTypeOfYearCd
		{
			get { return _produceTypeOfYearCd; }
			set { _produceTypeOfYearCd = value; }
		}

        /// public property name  :  FullModelFixedNo
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
		/// カラートリム装備抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>ColTrmEquSearchCondWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColTrmEquSearchCondWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ColTrmEquSearchCondWork()
		{
		}

	}
}
