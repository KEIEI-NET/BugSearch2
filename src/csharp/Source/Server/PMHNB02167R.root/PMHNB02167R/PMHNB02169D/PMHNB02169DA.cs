using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesHistAnalyzeCndtnWork
	/// <summary>
	///                      売上内容分析表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上内容分析表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesHistAnalyzeCndtnWork  
	{
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string[] _sectionCode;

        /// <summary>開始対象日付</summary>
        private Int32 _st_SalesDate;

        /// <summary>終了対象日付</summary>
        private Int32 _ed_SalesDate;

        /// <summary>開始対象日付(累計)</summary>
        /// <remarks>累計抽出範囲の開始日付をセット</remarks>
        private Int32 _st_MonthReportDate;

        /// <summary>終了対象日付(累計)</summary>
        /// <remarks>終了日付をセット</remarks>
        private Int32 _ed_MonthReportDate;

        /// <summary>開始得意先コード</summary>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>開始販売従業員コード</summary>
        private string _st_SalesEmployeeCd = "";

        /// <summary>終了販売従業員コード</summary>
        private string _ed_SalesEmployeeCd = "";

        /// <summary>開始販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _st_SalesAreaCode;

        /// <summary>終了販売エリアコード</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _ed_SalesAreaCode;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:得意先別,1:担当者別,2:地区別</remarks>
        private Int32 _printDiv;


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>開始対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>終了対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_MonthReportDate
        /// <summary>開始対象日付(累計)プロパティ</summary>
        /// <value>累計抽出範囲の開始日付をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日付(累計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_MonthReportDate
        {
            get { return _st_MonthReportDate; }
            set { _st_MonthReportDate = value; }
        }

        /// public propaty name  :  Ed_MonthReportDate
        /// <summary>終了対象日付(累計)プロパティ</summary>
        /// <value>終了日付をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日付(累計)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_MonthReportDate
        {
            get { return _ed_MonthReportDate; }
            set { _ed_MonthReportDate = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_SalesEmployeeCd
        /// <summary>開始販売従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SalesEmployeeCd
        {
            get { return _st_SalesEmployeeCd; }
            set { _st_SalesEmployeeCd = value; }
        }

        /// public propaty name  :  Ed_SalesEmployeeCd
        /// <summary>終了販売従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SalesEmployeeCd
        {
            get { return _ed_SalesEmployeeCd; }
            set { _ed_SalesEmployeeCd = value; }
        }

        /// public propaty name  :  St_SalesAreaCode
        /// <summary>開始販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesAreaCode
        {
            get { return _st_SalesAreaCode; }
            set { _st_SalesAreaCode = value; }
        }

        /// public propaty name  :  Ed_SalesAreaCode
        /// <summary>終了販売エリアコードプロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesAreaCode
        {
            get { return _ed_SalesAreaCode; }
            set { _ed_SalesAreaCode = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>発行タイププロパティ</summary>
        /// <value>0:得意先別,1:担当者別,2:地区別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }


        /// <summary>
        /// 売上内容分析表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>SalesHistAnalyzeCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistAnalyzeCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesHistAnalyzeCndtnWork()
        {
        }

	}
}




