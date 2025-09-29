using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   EstimateDefSet
	/// <summary>
	///                      見積初期値設定
	/// </summary>
	/// <remarks>
	/// <br>note             :   見積初期値設定ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/01/21  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/06/03 30415 柴田 倫幸</br>
    /// <br>        	         ・データ項目の追加/削除による修正</br>  
	/// </remarks>
	public class EstimateDefSet
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

        /* --- DEL 2008/06/03 -------------------------------->>>>>
        /// <summary>端数処理区分</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fractionProcCd;

        /// <summary>消費税転嫁方式</summary>
        private Int32 _consTaxLayMethod;
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// <summary>消費税印刷区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _consTaxPrintDiv;

		/// <summary>定価印刷区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _listPricePrintDiv;

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <summary>元号表示区分１</summary>
		/// <remarks>0:西暦　1:和暦</remarks>
		private Int32 _eraNameDispCd1;
        
        /// <summary>見積合計印刷区分</summary>
		/// <remarks>0:鑑のみ　1:明細末尾　2:合計部　3:印刷しない</remarks>
		private Int32 _estimateTotalPrtCd;

		/// <summary>見積書印刷区分</summary>
		/// <remarks>0:通常 1:1頁に入らない場合明細別紙 2:明細別紙</remarks>
		private Int32 _estimateFormPrtCd;

		/// <summary>敬称印刷区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _honorificTitlePrtCd;

		/// <summary>見積依頼区分</summary>
		/// <remarks>0:通常 1:1頁に入らない場合明細別紙 2:明細別紙</remarks>
		private Int32 _estimateRequestCd;
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// <summary>見積書番号採番区分</summary>
		/// <remarks>0:有り　1:無し</remarks>
		private Int32 _estmFormNoPickDiv;


		/// <summary>見積タイトル１</summary>
		private string _estimateTitle1 = "";


		/// <summary>見積備考１</summary>
		private string _estimateNote1 = "";

		/// <summary>見積備考２</summary>
		private string _estimateNote2 = "";

		/// <summary>見積備考３</summary>
		private string _estimateNote3 = "";


		/// <summary>見積書発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _estimatePrtDiv;

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <summary>見積依頼書発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _estimateReqPrtDiv;

		/// <summary>見積確認書発行区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _estimateConfPrtDiv;
           --- DEL 2008/06/03 --------------------------------<<<<< */

        /// <summary>ＦＡＸ見積区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _faxEstimatetDiv;

        // --- ADD 2008/06/03 -------------------------------->>>>>
        /// <summary>品番印字区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>オプション印字区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>部品選択区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _partsSelectDivCd;

        /// <summary>部品検索区分</summary>
        /// <remarks>0:部品検索,1:品番検索</remarks>
        private Int32 _partsSearchDivCd;

        /// <summary>見積データ作成区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _estimateDtCreateDiv;

        /// <summary>見積書有効期限</summary>
        private Int32 _estimateValidityTerm;

        /// <summary>掛率使用区分</summary>
        /// <remarks>0:売価＝定価 1:掛率指定,2:掛率設定</remarks>
        private Int32 _rateUseCode;
        // --- ADD 2008/06/03 --------------------------------<<<<< 


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税転嫁方式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  ConsTaxPrintDiv
		/// <summary>消費税印刷区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsTaxPrintDiv
		{
			get{return _consTaxPrintDiv;}
			set{_consTaxPrintDiv = value;}
		}

		/// public propaty name  :  ListPricePrintDiv
		/// <summary>定価印刷区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListPricePrintDiv
		{
			get{return _listPricePrintDiv;}
			set{_listPricePrintDiv = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  EraNameDispCd1
		/// <summary>元号表示区分１プロパティ</summary>
		/// <value>0:西暦　1:和暦</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   元号表示区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EraNameDispCd1
		{
			get{return _eraNameDispCd1;}
			set{_eraNameDispCd1 = value;}
		}

		/// public propaty name  :  EstimateTotalPrtCd
		/// <summary>見積合計印刷区分プロパティ</summary>
		/// <value>0:鑑のみ　1:明細末尾　2:合計部　3:印刷しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積合計印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateTotalPrtCd
		{
			get{return _estimateTotalPrtCd;}
			set{_estimateTotalPrtCd = value;}
		}

		/// public propaty name  :  EstimateFormPrtCd
		/// <summary>見積書印刷区分プロパティ</summary>
		/// <value>0:通常 1:1頁に入らない場合明細別紙 2:明細別紙</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積書印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateFormPrtCd
		{
			get{return _estimateFormPrtCd;}
			set{_estimateFormPrtCd = value;}
		}

		/// public propaty name  :  HonorificTitlePrtCd
		/// <summary>敬称印刷区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 HonorificTitlePrtCd
		{
			get{return _honorificTitlePrtCd;}
			set{_honorificTitlePrtCd = value;}
		}

		/// public propaty name  :  EstimateRequestCd
		/// <summary>見積依頼区分プロパティ</summary>
		/// <value>0:通常 1:1頁に入らない場合明細別紙 2:明細別紙</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積依頼区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateRequestCd
		{
			get{return _estimateRequestCd;}
			set{_estimateRequestCd = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  EstmFormNoPickDiv
		/// <summary>見積書番号採番区分プロパティ</summary>
		/// <value>0:有り　1:無し</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積書番号採番区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstmFormNoPickDiv
		{
			get{return _estmFormNoPickDiv;}
			set{_estmFormNoPickDiv = value;}
		}



		/// public propaty name  :  EstimateTitle1
		/// <summary>見積タイトル１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積タイトル１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EstimateTitle1
		{
			get{return _estimateTitle1;}
			set{_estimateTitle1 = value;}
		}


		/// public propaty name  :  EstimateNote1
		/// <summary>見積備考１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積備考１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EstimateNote1
		{
			get{return _estimateNote1;}
			set{_estimateNote1 = value;}
		}

		/// public propaty name  :  EstimateNote2
		/// <summary>見積備考２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EstimateNote2
		{
			get{return _estimateNote2;}
			set{_estimateNote2 = value;}
		}

		/// public propaty name  :  EstimateNote3
		/// <summary>見積備考３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積備考３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EstimateNote3
		{
			get{return _estimateNote3;}
			set{_estimateNote3 = value;}
		}


		/// public propaty name  :  EstimatePrtDiv
		/// <summary>見積書発行区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積書発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimatePrtDiv
		{
			get{return _estimatePrtDiv;}
			set{_estimatePrtDiv = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  EstimateReqPrtDiv
		/// <summary>見積依頼書発行区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積依頼書発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateReqPrtDiv
		{
			get{return _estimateReqPrtDiv;}
			set{_estimateReqPrtDiv = value;}
		}

		/// public propaty name  :  EstimateConfPrtDiv
		/// <summary>見積確認書発行区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積確認書発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimateConfPrtDiv
		{
			get{return _estimateConfPrtDiv;}
			set{_estimateConfPrtDiv = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  FaxEstimatetDiv
		/// <summary>ＦＡＸ見積区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＦＡＸ見積区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FaxEstimatetDiv
		{
			get{return _faxEstimatetDiv;}
			set{_faxEstimatetDiv = value;}
		}

        // --- ADD 2008/06/03 -------------------------------->>>>>
        /// public propaty name  :  PartsNoPrtCd
        /// <summary>品番印字区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>オプション印字区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オプション印字区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  PartsSelectDivCd
        /// <summary>部品選択区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 PartsSelectDivCd
        {
            get { return _partsSelectDivCd; }
            set { _partsSelectDivCd = value; }
        }

        /// public propaty name  :  PartsSearchDivCd
        /// <summary>部品検索区分プロパティ</summary>
        /// <value>0:部品検索,1:品番検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 PartsSearchDivCd
        {
            get { return _partsSearchDivCd; }
            set { _partsSearchDivCd = value; }
        }

        /// public propaty name  :  EstimateDtCreateDiv
        /// <summary>見積データ作成区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ作成区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 EstimateDtCreateDiv
        {
            get { return _estimateDtCreateDiv; }
            set { _estimateDtCreateDiv = value; }
        }

        /// public propaty name  :  EstimateValidityTerm
        /// <summary>見積書有効期限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期限プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 EstimateValidityTerm
        {
            get { return _estimateValidityTerm; }
            set { _estimateValidityTerm = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>掛率使用区分プロパティ</summary>
        /// <value>0:売価＝定価 1:掛率指定,2:掛率設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率使用区分プロパティ</br>
        /// <br>Programer        :   柴田 倫幸</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
        }
        // --- ADD 2008/06/03 --------------------------------<<<<< 


		/// <summary>
		/// 見積初期値設定コンストラクタ
		/// </summary>
		/// <returns>EstimateDefSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EstimateDefSet()
		{
		}

		/// <summary>
		/// 見積初期値設定コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <param name="fractionProcCd">端数処理区分(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="consTaxLayMethod">消費税転嫁方式</param>
           --- DEL 2008/06/03 --------------------------------<<<<< */
        /// <param name="consTaxPrintDiv">消費税印刷区分(0:する　1:しない)</param>
		/// <param name="listPricePrintDiv">定価印刷区分(0:しない　1:する)</param>
        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <param name="eraNameDispCd1">元号表示区分１(0:西暦　1:和暦)</param>
		/// <param name="estimateTotalPrtCd">見積合計印刷区分(0:鑑のみ　1:明細末尾　2:合計部　3:印刷しない)</param>
		/// <param name="estimateFormPrtCd">見積書印刷区分(0:通常 1:1頁に入らない場合明細別紙 2:明細別紙)</param>
		/// <param name="honorificTitlePrtCd">敬称印刷区分(0:する　1:しない)</param>
		/// <param name="estimateRequestCd">見積依頼区分(0:通常 1:1頁に入らない場合明細別紙 2:明細別紙)</param>
	           --- DEL 2008/06/03 --------------------------------<<<<< */
        /// <param name="estmFormNoPickDiv">見積書番号採番区分(0:有り　1:無し)</param>
		/// <param name="estimateTitle1">見積タイトル１</param>
		/// <param name="estimateNote1">見積備考１</param>
		/// <param name="estimateNote2">見積備考２</param>
		/// <param name="estimateNote3">見積備考３</param>
		/// <param name="estimatePrtDiv">見積書発行区分(0:する　1:しない)</param>
		/// <param name="estimateReqPrtDiv">見積依頼書発行区分(0:する　1:しない)</param>
		/// <param name="estimateConfPrtDiv">見積確認書発行区分(0:しない　1:する)</param>
		/// <param name="faxEstimatetDiv">ＦＡＸ見積区分(0:しない　1:する)</param>
        /// <param name="faxEstimatetDiv">品番印字区分(0:しない　1:する)</param>
        /// <param name="faxEstimatetDiv">オプション印字区分(0:しない　1:する)</param>
        /// <param name="faxEstimatetDiv">部品選択区分(0:する,1:しない)</param>
        /// <param name="faxEstimatetDiv">部品検索区分(0:部品検索,1:品番検索)</param>
        /// <param name="faxEstimatetDiv">見積データ作成区分(0:する,1:しない)</param>
        /// <param name="faxEstimatetDiv">見積書有効期限</param>
        /// <param name="faxEstimatetDiv">掛率使用区分(0:売価＝定価 1:掛率指定,2:掛率設定)</param>		
        /// <returns>EstimateDefSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public EstimateDefSet(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 fractionProcCd,Int32 consTaxLayMethod,Int32 consTaxPrintDiv,Int32 listPricePrintDiv,Int32 eraNameDispCd1,Int32 estimateTotalPrtCd,Int32 estimateFormPrtCd,Int32 honorificTitlePrtCd,Int32 estimateRequestCd,Int32 estmFormNoPickDiv,string estimateTitle1,string estimateNote1,string estimateNote2,string estimateNote3,Int32 estimatePrtDiv,Int32 estimateReqPrtDiv,Int32 estimateConfPrtDiv,Int32 faxEstimatetDiv) // DEL 2008/06/03
        public EstimateDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 consTaxPrintDiv, Int32 listPricePrintDiv, Int32 estmFormNoPickDiv,  string estimateTitle1,  string estimateNote1, string estimateNote2, string estimateNote3, Int32 estimatePrtDiv, Int32 faxEstimatetDiv, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 partsSelectDivCd, Int32 partsSearchDivCd, Int32 estimateDtCreateDiv, Int32 estimateValidityTerm, Int32 rateUseCode) // ADD 2008/06/03
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
                this._fractionProcCd = fractionProcCd;
                this._consTaxLayMethod = consTaxLayMethod;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._consTaxPrintDiv = consTaxPrintDiv;
			this._listPricePrintDiv = listPricePrintDiv;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			this._eraNameDispCd1 = eraNameDispCd1;
			this._estimateTotalPrtCd = estimateTotalPrtCd;
			this._estimateFormPrtCd = estimateFormPrtCd;
			this._honorificTitlePrtCd = honorificTitlePrtCd;
			this._estimateRequestCd = estimateRequestCd;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._estmFormNoPickDiv = estmFormNoPickDiv;
			this._estimateTitle1 = estimateTitle1;
			this._estimateNote1 = estimateNote1;
			this._estimateNote2 = estimateNote2;
			this._estimateNote3 = estimateNote3;
			this._estimatePrtDiv = estimatePrtDiv;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			this._estimateReqPrtDiv = estimateReqPrtDiv;
			this._estimateConfPrtDiv = estimateConfPrtDiv;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._faxEstimatetDiv = faxEstimatetDiv;
            // --- ADD 2008/06/03 -------------------------------->>>>>
            this._partsNoPrtCd = partsNoPrtCd;
            this._optionPringDivCd = optionPringDivCd;
            this._partsSelectDivCd = partsSelectDivCd;
            this._partsSearchDivCd = partsSearchDivCd;
            this._estimateDtCreateDiv = estimateDtCreateDiv;
            this._estimateValidityTerm = estimateValidityTerm;
            this._rateUseCode = rateUseCode;
            // --- ADD 2008/06/03 --------------------------------<<<<< 
		}

		/// <summary>
		/// 見積初期値設定複製処理
		/// </summary>
		/// <returns>EstimateDefSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいEstimateDefSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EstimateDefSet Clone()
		{
            // DEL 2008/06/03
            //return new EstimateDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._fractionProcCd, this._consTaxLayMethod, this._consTaxPrintDiv, this._listPricePrintDiv, this._eraNameDispCd1, this._estimateTotalPrtCd, this._estimateFormPrtCd, this._honorificTitlePrtCd, this._estimateRequestCd, this._estmFormNoPickDiv, this._estimateTitle1, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimatePrtDiv, this._estimateReqPrtDiv, this._estimateConfPrtDiv, this._faxEstimatetDiv);
            // ADD 2008/06/03
            return new EstimateDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._consTaxPrintDiv, this._listPricePrintDiv, this._estmFormNoPickDiv,  this._estimateTitle1, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimatePrtDiv, this._faxEstimatetDiv, this._partsNoPrtCd, this._optionPringDivCd, this._partsSelectDivCd, this._partsSearchDivCd, this._estimateDtCreateDiv, this._estimateValidityTerm, this._rateUseCode);
		}

		/// <summary>
		/// 見積初期値設定比較処理
		/// </summary>
		/// <param name="target">比較対象のEstimateDefSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(EstimateDefSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                   --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (this.ConsTaxPrintDiv == target.ConsTaxPrintDiv)
				 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EstimateTotalPrtCd == target.EstimateTotalPrtCd)
                 && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
                 && (this.HonorificTitlePrtCd == target.HonorificTitlePrtCd)
                 && (this.EstimateRequestCd == target.EstimateRequestCd)
                  --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (this.EstmFormNoPickDiv == target.EstmFormNoPickDiv)
				 && (this.EstimateTitle1 == target.EstimateTitle1)
				 && (this.EstimateNote1 == target.EstimateNote1)
				 && (this.EstimateNote2 == target.EstimateNote2)
				 && (this.EstimateNote3 == target.EstimateNote3)
				 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
				 && (this.EstimateReqPrtDiv == target.EstimateReqPrtDiv)
				 && (this.EstimateConfPrtDiv == target.EstimateConfPrtDiv)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
				 && (this.FaxEstimatetDiv == target.FaxEstimatetDiv)
                 // --- ADD 2008/06/03 -------------------------------->>>>>
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.OptionPringDivCd == target.OptionPringDivCd)
                 && (this.PartsSelectDivCd == target.PartsSelectDivCd)
                 && (this.PartsSearchDivCd == target.PartsSearchDivCd)
                 && (this.EstimateDtCreateDiv == target.EstimateDtCreateDiv)
                 && (this.EstimateValidityTerm == target.EstimateValidityTerm)
                 && (this.RateUseCode == target.RateUseCode)
                 // --- ADD 2008/06/03 --------------------------------<<<<< 
                 );
		}

		/// <summary>
		/// 見積初期値設定比較処理
		/// </summary>
		/// <param name="estimateDefSet1">
		///                    比較するEstimateDefSetクラスのインスタンス
		/// </param>
		/// <param name="estimateDefSet2">比較するEstimateDefSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(EstimateDefSet estimateDefSet1, EstimateDefSet estimateDefSet2)
		{
			return ((estimateDefSet1.CreateDateTime == estimateDefSet2.CreateDateTime)
				 && (estimateDefSet1.UpdateDateTime == estimateDefSet2.UpdateDateTime)
				 && (estimateDefSet1.EnterpriseCode == estimateDefSet2.EnterpriseCode)
				 && (estimateDefSet1.FileHeaderGuid == estimateDefSet2.FileHeaderGuid)
				 && (estimateDefSet1.UpdEmployeeCode == estimateDefSet2.UpdEmployeeCode)
				 && (estimateDefSet1.UpdAssemblyId1 == estimateDefSet2.UpdAssemblyId1)
				 && (estimateDefSet1.UpdAssemblyId2 == estimateDefSet2.UpdAssemblyId2)
				 && (estimateDefSet1.LogicalDeleteCode == estimateDefSet2.LogicalDeleteCode)
				 && (estimateDefSet1.SectionCode == estimateDefSet2.SectionCode)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.FractionProcCd == estimateDefSet2.FractionProcCd)
                 && (estimateDefSet1.ConsTaxLayMethod == estimateDefSet2.ConsTaxLayMethod)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (estimateDefSet1.ConsTaxPrintDiv == estimateDefSet2.ConsTaxPrintDiv)
				 && (estimateDefSet1.ListPricePrintDiv == estimateDefSet2.ListPricePrintDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.EraNameDispCd1 == estimateDefSet2.EraNameDispCd1)
                 && (estimateDefSet1.EstimateTotalPrtCd == estimateDefSet2.EstimateTotalPrtCd)
                 && (estimateDefSet1.EstimateFormPrtCd == estimateDefSet2.EstimateFormPrtCd)
                 && (estimateDefSet1.HonorificTitlePrtCd == estimateDefSet2.HonorificTitlePrtCd)
                 && (estimateDefSet1.EstimateRequestCd == estimateDefSet2.EstimateRequestCd)
                   --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (estimateDefSet1.EstmFormNoPickDiv == estimateDefSet2.EstmFormNoPickDiv)
				 && (estimateDefSet1.EstimateTitle1 == estimateDefSet2.EstimateTitle1)
				 && (estimateDefSet1.EstimateNote1 == estimateDefSet2.EstimateNote1)
				 && (estimateDefSet1.EstimateNote2 == estimateDefSet2.EstimateNote2)
				 && (estimateDefSet1.EstimateNote3 == estimateDefSet2.EstimateNote3)
				 && (estimateDefSet1.EstimatePrtDiv == estimateDefSet2.EstimatePrtDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
				 && (estimateDefSet1.EstimateReqPrtDiv == estimateDefSet2.EstimateReqPrtDiv)
				 && (estimateDefSet1.EstimateConfPrtDiv == estimateDefSet2.EstimateConfPrtDiv)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
				 && (estimateDefSet1.FaxEstimatetDiv == estimateDefSet2.FaxEstimatetDiv)
                 // --- ADD 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.PartsNoPrtCd == estimateDefSet2.PartsNoPrtCd)
                 && (estimateDefSet1.OptionPringDivCd == estimateDefSet2.OptionPringDivCd)
                 && (estimateDefSet1.PartsSelectDivCd == estimateDefSet2.PartsSelectDivCd)
                 && (estimateDefSet1.PartsSearchDivCd == estimateDefSet2.PartsSearchDivCd)
                 && (estimateDefSet1.EstimateDtCreateDiv == estimateDefSet2.EstimateDtCreateDiv)
                 && (estimateDefSet1.EstimateValidityTerm == estimateDefSet2.EstimateValidityTerm)
                 && (estimateDefSet1.RateUseCode == estimateDefSet2.RateUseCode)
                 // --- ADD 2008/06/03 --------------------------------<<<<< 
                 );
		}
		/// <summary>
		/// 見積初期値設定比較処理
		/// </summary>
		/// <param name="target">比較対象のEstimateDefSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(EstimateDefSet target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (this.ConsTaxPrintDiv != target.ConsTaxPrintDiv)resList.Add("ConsTaxPrintDiv");
			if(this.ListPricePrintDiv != target.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.EstimateTotalPrtCd != target.EstimateTotalPrtCd)resList.Add("EstimateTotalPrtCd");
			if(this.EstimateFormPrtCd != target.EstimateFormPrtCd)resList.Add("EstimateFormPrtCd");
			if(this.HonorificTitlePrtCd != target.HonorificTitlePrtCd)resList.Add("HonorificTitlePrtCd");
			if(this.EstimateRequestCd != target.EstimateRequestCd)resList.Add("EstimateRequestCd");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (this.EstmFormNoPickDiv != target.EstmFormNoPickDiv)resList.Add("EstmFormNoPickDiv");
			if(this.EstimateTitle1 != target.EstimateTitle1)resList.Add("EstimateTitle1");
			if(this.EstimateNote1 != target.EstimateNote1)resList.Add("EstimateNote1");
			if(this.EstimateNote2 != target.EstimateNote2)resList.Add("EstimateNote2");
			if(this.EstimateNote3 != target.EstimateNote3)resList.Add("EstimateNote3");
			if(this.EstimatePrtDiv != target.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.EstimateReqPrtDiv != target.EstimateReqPrtDiv)resList.Add("EstimateReqPrtDiv");
			if(this.EstimateConfPrtDiv != target.EstimateConfPrtDiv)resList.Add("EstimateConfPrtDiv");
               --- DEL 2008/06/03 --------------------------------<<<<< */
			if(this.FaxEstimatetDiv != target.FaxEstimatetDiv)resList.Add("FaxEstimatetDiv");
            // --- ADD 2008/06/03 -------------------------------->>>>>
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (this.PartsSelectDivCd != target.PartsSelectDivCd) resList.Add("PartsSelectDivCd");
            if (this.PartsSearchDivCd != target.PartsSearchDivCd) resList.Add("PartsSearchDivCd");
            if (this.EstimateDtCreateDiv != target.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (this.EstimateValidityTerm != target.EstimateValidityTerm) resList.Add("EstimateValidityTerm");
            if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return resList;
		}

		/// <summary>
		/// 見積初期値設定比較処理
		/// </summary>
		/// <param name="estimateDefSet1">比較するEstimateDefSetクラスのインスタンス</param>
		/// <param name="estimateDefSet2">比較するEstimateDefSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EstimateDefSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(EstimateDefSet estimateDefSet1, EstimateDefSet estimateDefSet2)
		{
			ArrayList resList = new ArrayList();
			if(estimateDefSet1.CreateDateTime != estimateDefSet2.CreateDateTime)resList.Add("CreateDateTime");
			if(estimateDefSet1.UpdateDateTime != estimateDefSet2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(estimateDefSet1.EnterpriseCode != estimateDefSet2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(estimateDefSet1.FileHeaderGuid != estimateDefSet2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(estimateDefSet1.UpdEmployeeCode != estimateDefSet2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(estimateDefSet1.UpdAssemblyId1 != estimateDefSet2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(estimateDefSet1.UpdAssemblyId2 != estimateDefSet2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(estimateDefSet1.LogicalDeleteCode != estimateDefSet2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(estimateDefSet1.SectionCode != estimateDefSet2.SectionCode)resList.Add("SectionCode");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            if(estimateDefSet1.FractionProcCd != estimateDefSet2.FractionProcCd)resList.Add("FractionProcCd");
            if(estimateDefSet1.ConsTaxLayMethod != estimateDefSet2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (estimateDefSet1.ConsTaxPrintDiv != estimateDefSet2.ConsTaxPrintDiv)resList.Add("ConsTaxPrintDiv");
			if(estimateDefSet1.ListPricePrintDiv != estimateDefSet2.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(estimateDefSet1.EraNameDispCd1 != estimateDefSet2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(estimateDefSet1.EstimateTotalPrtCd != estimateDefSet2.EstimateTotalPrtCd)resList.Add("EstimateTotalPrtCd");
			if(estimateDefSet1.EstimateFormPrtCd != estimateDefSet2.EstimateFormPrtCd)resList.Add("EstimateFormPrtCd");
			if(estimateDefSet1.HonorificTitlePrtCd != estimateDefSet2.HonorificTitlePrtCd)resList.Add("HonorificTitlePrtCd");
			if(estimateDefSet1.EstimateRequestCd != estimateDefSet2.EstimateRequestCd)resList.Add("EstimateRequestCd");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (estimateDefSet1.EstmFormNoPickDiv != estimateDefSet2.EstmFormNoPickDiv)resList.Add("EstmFormNoPickDiv");
			if(estimateDefSet1.EstimateTitle1 != estimateDefSet2.EstimateTitle1)resList.Add("EstimateTitle1");
			if(estimateDefSet1.EstimateNote1 != estimateDefSet2.EstimateNote1)resList.Add("EstimateNote1");
			if(estimateDefSet1.EstimateNote2 != estimateDefSet2.EstimateNote2)resList.Add("EstimateNote2");
			if(estimateDefSet1.EstimateNote3 != estimateDefSet2.EstimateNote3)resList.Add("EstimateNote3");
			if(estimateDefSet1.EstimatePrtDiv != estimateDefSet2.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(estimateDefSet1.EstimateReqPrtDiv != estimateDefSet2.EstimateReqPrtDiv)resList.Add("EstimateReqPrtDiv");
			if(estimateDefSet1.EstimateConfPrtDiv != estimateDefSet2.EstimateConfPrtDiv)resList.Add("EstimateConfPrtDiv");
               --- DEL 2008/06/06 --------------------------------<<<<< */
            if (estimateDefSet1.FaxEstimatetDiv != estimateDefSet2.FaxEstimatetDiv)resList.Add("FaxEstimatetDiv");
            // --- ADD 2008/06/03 -------------------------------->>>>>
            if (estimateDefSet1.PartsNoPrtCd != estimateDefSet2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (estimateDefSet1.OptionPringDivCd != estimateDefSet2.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (estimateDefSet1.PartsSelectDivCd != estimateDefSet2.PartsSelectDivCd) resList.Add("PartsSelectDivCd");
            if (estimateDefSet1.PartsSearchDivCd != estimateDefSet2.PartsSearchDivCd) resList.Add("PartsSearchDivCd");
            if (estimateDefSet1.EstimateDtCreateDiv != estimateDefSet2.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (estimateDefSet1.EstimateValidityTerm != estimateDefSet2.EstimateValidityTerm) resList.Add("EstimateValidityTerm");
            if (estimateDefSet1.RateUseCode != estimateDefSet2.RateUseCode) resList.Add("RateUseCode");
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return resList;
		}
	}
}
