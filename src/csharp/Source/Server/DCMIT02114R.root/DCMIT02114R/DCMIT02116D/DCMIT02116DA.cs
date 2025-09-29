using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   EstimateListCndtnWork
	/// <summary>
	///                      見積確認表抽出条件クラスワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   見積確認表抽出条件クラスワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class EstimateListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>開始見積日付</summary>
		private DateTime _st_SalesDate;

		/// <summary>終了見積日付</summary>
		private DateTime _ed_SalesDate;

		/// <summary>開始入力日付</summary>
		private DateTime _st_SearchSlipDate;

		/// <summary>終了入力日付</summary>
		private DateTime _ed_SearchSlipDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始販売従業員コード</summary>
		private string _st_SalesEmployeeCd = "";

		/// <summary>終了販売従業員コード</summary>
		private string _ed_SalesEmployeeCd = "";

		/// <summary>見積タイプ</summary>
		/// <remarks>0:売上入力分,1:検索見積分,-1:全て</remarks>
		private Int32 _estimateDivide;

		/// <summary>発行タイプ</summary>
		/// <remarks>0:見積計上,-1:全て</remarks>
		private Int32 _printDiv;

        // 2011/11/11 add start ----------------------------------------------->>
        /// <summary>発行タイプ</summary>
        /// <remarks>0:連携伝票を含まない,1:連携伝票を含む,2:連携伝票のみ対象</remarks>
        private Int32 _autoAnswerDivSCMRF;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:PCCforNS分を含む,1:BLﾊﾟｰﾂｵｰﾀﾞｰ分を含む</remarks>
        private Int16 _acceptOrOrderKindRF;
        // 2011/11/11 add end -----------------------------------------------<<


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
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_SalesDate
		/// <summary>開始見積日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始見積日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_SalesDate
		{
			get{return _st_SalesDate;}
			set{_st_SalesDate = value;}
		}

		/// public propaty name  :  Ed_SalesDate
		/// <summary>終了見積日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了見積日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_SalesDate
		{
			get{return _ed_SalesDate;}
			set{_ed_SalesDate = value;}
		}

		/// public propaty name  :  St_SearchSlipDate
		/// <summary>開始入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_SearchSlipDate
		{
			get{return _st_SearchSlipDate;}
			set{_st_SearchSlipDate = value;}
		}

		/// public propaty name  :  Ed_SearchSlipDate
		/// <summary>終了入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_SearchSlipDate
		{
			get{return _ed_SearchSlipDate;}
			set{_ed_SearchSlipDate = value;}
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
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
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
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
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
			get{return _st_SalesEmployeeCd;}
			set{_st_SalesEmployeeCd = value;}
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
			get{return _ed_SalesEmployeeCd;}
			set{_ed_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  EstimateDivide
		/// <summary>見積タイププロパティ</summary>
		/// <value>0:売上入力分,1:検索見積分,-1:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateDivide
		{
			get{return _estimateDivide;}
			set{_estimateDivide = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:見積計上,-1:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

        // 2011/11/11 add start ----------------------------------------------->>
        /// public propaty name  :  AutoAnswerDivSCMRF
        /// <summary>連携伝票出力区分プロパティ</summary>
        /// <value>0:連携伝票を含まない,1:連携伝票を含む,2:連携伝票のみ対象</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携伝票出力区分プロパティ</br>
        /// <br>Programer        :   x_zhuxk</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCMRF
        {
            get { return _autoAnswerDivSCMRF; }
            set { _autoAnswerDivSCMRF = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>連携伝票対象区分プロパティ</summary>
        /// <value>0:PCCforNS分を含む,1:BLﾊﾟｰﾂｵｰﾀﾞｰ分を含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携伝票対象区分プロパティ</br>
        /// <br>Programer        :   x_zhuxk</br>
        /// </remarks>
        public Int16 AcceptOrOrderKindRF
        {
            get { return _acceptOrOrderKindRF; }
            set { _acceptOrOrderKindRF = value; }
        }
        // 2011/11/11 add end -----------------------------------------------<<

		/// <summary>
		/// 見積確認表抽出条件クラスワークワークコンストラクタ
		/// </summary>
		/// <returns>EstimateListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EstimateListCndtnWork()
		{
		}

	}

}
