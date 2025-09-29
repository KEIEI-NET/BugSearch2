using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustAccRec
	/// <summary>
	///                      得意先売掛金額マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先売掛金額マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustAccRec
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

		/// <summary>計上拠点コード</summary>
		/// <remarks>集計の対象となっている拠点コード</remarks>
		private string _addUpSecCode = "";

		/// <summary>請求先コード</summary>
		/// <remarks>請求先親コード</remarks>
		private Int32 _claimCode;

		/// <summary>請求先名称</summary>
		private string _claimName = "";

		/// <summary>請求先名称2</summary>
		private string _claimName2 = "";

		/// <summary>請求先略称</summary>
		private string _claimSnm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD 自社締を行なった日（自社締め基準）</remarks>
		private DateTime _addUpDate;

		/// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>前回売掛金額</summary>
		private Int64 _lastTimeAccRec;

		/// <summary>今回手数料額（通常入金）</summary>
		private Int64 _thisTimeFeeDmdNrml;

		/// <summary>今回値引額（通常入金）</summary>
		private Int64 _thisTimeDisDmdNrml;

		/// <summary>今回入金金額（通常入金）</summary>
		/// <remarks>入金額の合計金額</remarks>
		private Int64 _thisTimeDmdNrml;

		/// <summary>今回繰越残高（売掛計）</summary>
		/// <remarks>今回繰越残高＝前回売掛金額－今回入金額合計（通常入金）</remarks>
		private Int64 _thisTimeTtlBlcAcc;

		/// <summary>相殺後今回売上金額</summary>
		/// <remarks>相殺結果　「相殺後：***」の値が請求金額となる</remarks>
		private Int64 _ofsThisTimeSales;

		/// <summary>相殺後今回売上消費税</summary>
		/// <remarks>相殺結果</remarks>
		private Int64 _ofsThisSalesTax;

		/// <summary>相殺後外税対象額</summary>
		/// <remarks>相殺結果：外税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>相殺後内税対象額</summary>
		/// <remarks>相殺結果：内税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>相殺後非課税対象額</summary>
		/// <remarks>相殺結果：非課税額の集計</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>相殺後外税消費税</summary>
		/// <remarks>相殺結果：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
		private Int64 _offsetOutTax;

		/// <summary>相殺後内税消費税</summary>
		/// <remarks>相殺結果：内税消費税の集計</remarks>
		private Int64 _offsetInTax;

		/// <summary>今回売上金額</summary>
		/// <remarks>請求用：値引、返品を含まない税抜きの売上金額</remarks>
		private Int64 _thisTimeSales;

		/// <summary>今回売上消費税</summary>
		/// <remarks>請求用</remarks>
		private Int64 _thisSalesTax;

		/// <summary>売上外税対象額</summary>
		/// <remarks>請求用：外税額（税抜き）の集計</remarks>
		private Int64 _itdedSalesOutTax;

		/// <summary>売上内税対象額</summary>
		/// <remarks>請求用：内税額（税抜き）の集計</remarks>
		private Int64 _itdedSalesInTax;

		/// <summary>売上非課税対象額</summary>
		/// <remarks>請求用：非課税額の集計</remarks>
		private Int64 _itdedSalesTaxFree;

		/// <summary>売上外税額</summary>
		/// <remarks>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
		private Int64 _salesOutTax;

		/// <summary>売上内税額</summary>
		/// <remarks>請求用：内税商品売上の内税消費税額（返品、値引含まず）</remarks>
		private Int64 _salesInTax;

		/// <summary>今回売上返品金額</summary>
		/// <remarks>返品用：値引を含まない税抜きの売上返品金額</remarks>
		private Int64 _thisSalesPricRgds;

		/// <summary>今回売上返品消費税</summary>
		/// <remarks>返品用：返品外税額合計＋返品内税額合計</remarks>
		private Int64 _thisSalesPrcTaxRgds;

		/// <summary>返品外税対象額合計</summary>
		/// <remarks>返品用</remarks>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>返品内税対象額合計</summary>
		/// <remarks>返品用</remarks>
		private Int64 _ttlItdedRetInTax;

		/// <summary>返品非課税対象額合計</summary>
		/// <remarks>返品用</remarks>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>返品外税額合計</summary>
		/// <remarks>返品用</remarks>
		private Int64 _ttlRetOuterTax;

		/// <summary>返品内税額合計</summary>
		/// <remarks>返品用：内税商品返品の内税消費税額（値引含まず）</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>今回売上値引金額</summary>
		/// <remarks>値引用：税抜きの売上値引金額</remarks>
		private Int64 _thisSalesPricDis;

		/// <summary>今回売上値引消費税</summary>
		/// <remarks>値引用：値引外税額合計＋値引内税額合計</remarks>
		private Int64 _thisSalesPrcTaxDis;

		/// <summary>値引外税対象額合計</summary>
		/// <remarks>値引用</remarks>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>値引内税対象額合計</summary>
		/// <remarks>値引用</remarks>
		private Int64 _ttlItdedDisInTax;

		/// <summary>値引非課税対象額合計</summary>
		/// <remarks>値引用</remarks>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>値引外税額合計</summary>
		/// <remarks>値引用</remarks>
		private Int64 _ttlDisOuterTax;

		/// <summary>値引内税額合計</summary>
		/// <remarks>値引用：内税商品返品の内税消費税額</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>計算後当月売掛金額</summary>
		/// <remarks>今月分の売掛金額
        /// 繰越額＋今回純売上金額＋今回純売上消費税＋消費税調整額＋残高調整額</remarks>
		private Int64 _afCalTMonthAccRec;

		/// <summary>受注2回前残高（売掛計）</summary>
		private Int64 _acpOdrTtl2TmBfAccRec;

		/// <summary>受注3回前残高（売掛計）</summary>
		private Int64 _acpOdrTtl3TmBfAccRec;

		/// <summary>月次更新実行年月日</summary>
		/// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
		private DateTime _monthAddUpExpDate;

		/// <summary>月次更新開始年月日</summary>
		/// <remarks>"YYYYMMDD"  月次更新対象となる開始年月日</remarks>
		private DateTime _stMonCAddUpUpdDate;

		/// <summary>前回月次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回月次更新対象となった年月日</remarks>
		private DateTime _laMonCAddUpUpdDate;

		/// <summary>売上伝票枚数</summary>
		/// <remarks>売上伝票枚数（掛売上＋現金売上）</remarks>
		private Int32 _salesSlipCount;

		/// <summary>消費税転嫁方式</summary>
		/// <remarks>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>消費税率</summary>
		/// <remarks>変更2007/8/22(型,桁) 塩原</remarks>
		private Double _consTaxRate;

		/// <summary>端数処理区分</summary>
		private Int32 _fractionProcCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>計上拠点名称</summary>
		private string _addUpSecName = "";


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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  AddUpSecCode
		/// <summary>計上拠点コードプロパティ</summary>
		/// <value>集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecCode
		{
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>請求先コードプロパティ</summary>
		/// <value>請求先親コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  ClaimName
		/// <summary>請求先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimName
		{
			get{return _claimName;}
			set{_claimName = value;}
		}

		/// public propaty name  :  ClaimName2
		/// <summary>請求先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimName2
		{
			get{return _claimName2;}
			set{_claimName2 = value;}
		}

		/// public propaty name  :  ClaimSnm
		/// <summary>請求先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimSnm
		{
			get{return _claimSnm;}
			set{_claimSnm = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerName
		/// <summary>得意先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  CustomerName2
		/// <summary>得意先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  AddUpDateJpFormal
		/// <summary>計上年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateJpInFormal
		/// <summary>計上年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdFormal
		/// <summary>計上年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpDateAdInFormal
		/// <summary>計上年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD 自社締を行なった日（自社締め基準）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonth
		/// <summary>計上年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

		/// public propaty name  :  AddUpYearMonthJpFormal
		/// <summary>計上年月 和暦プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthJpInFormal
		/// <summary>計上年月 和暦(略)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdFormal
		/// <summary>計上年月 西暦プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  AddUpYearMonthAdInFormal
		/// <summary>計上年月 西暦(略)プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpYearMonthAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth);}
			set{}
		}

		/// public propaty name  :  LastTimeAccRec
		/// <summary>前回売掛金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回売掛金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimeAccRec
		{
			get{return _lastTimeAccRec;}
			set{_lastTimeAccRec = value;}
		}

		/// public propaty name  :  ThisTimeFeeDmdNrml
		/// <summary>今回手数料額（通常入金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回手数料額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeFeeDmdNrml
		{
			get{return _thisTimeFeeDmdNrml;}
			set{_thisTimeFeeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisDmdNrml
		/// <summary>今回値引額（通常入金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeDisDmdNrml
		{
			get{return _thisTimeDisDmdNrml;}
			set{_thisTimeDisDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeDmdNrml
		/// <summary>今回入金金額（通常入金）プロパティ</summary>
		/// <value>入金額の合計金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回入金金額（通常入金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeDmdNrml
		{
			get{return _thisTimeDmdNrml;}
			set{_thisTimeDmdNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcAcc
		/// <summary>今回繰越残高（売掛計）プロパティ</summary>
		/// <value>今回繰越残高＝前回売掛金額－今回入金額合計（通常入金）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回繰越残高（売掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcAcc
		{
			get{return _thisTimeTtlBlcAcc;}
			set{_thisTimeTtlBlcAcc = value;}
		}

		/// public propaty name  :  OfsThisTimeSales
		/// <summary>相殺後今回売上金額プロパティ</summary>
		/// <value>相殺結果　「相殺後：***」の値が請求金額となる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回売上金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisTimeSales
		{
			get{return _ofsThisTimeSales;}
			set{_ofsThisTimeSales = value;}
		}

		/// public propaty name  :  OfsThisSalesTax
		/// <summary>相殺後今回売上消費税プロパティ</summary>
		/// <value>相殺結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回売上消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisSalesTax
		{
			get{return _ofsThisSalesTax;}
			set{_ofsThisSalesTax = value;}
		}

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>相殺後外税対象額プロパティ</summary>
		/// <value>相殺結果：外税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後外税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetOutTax
		{
			get{return _itdedOffsetOutTax;}
			set{_itdedOffsetOutTax = value;}
		}

		/// public propaty name  :  ItdedOffsetInTax
		/// <summary>相殺後内税対象額プロパティ</summary>
		/// <value>相殺結果：内税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後内税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetInTax
		{
			get{return _itdedOffsetInTax;}
			set{_itdedOffsetInTax = value;}
		}

		/// public propaty name  :  ItdedOffsetTaxFree
		/// <summary>相殺後非課税対象額プロパティ</summary>
		/// <value>相殺結果：非課税額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後非課税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedOffsetTaxFree
		{
			get{return _itdedOffsetTaxFree;}
			set{_itdedOffsetTaxFree = value;}
		}

		/// public propaty name  :  OffsetOutTax
		/// <summary>相殺後外税消費税プロパティ</summary>
		/// <value>相殺結果：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後外税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OffsetOutTax
		{
			get{return _offsetOutTax;}
			set{_offsetOutTax = value;}
		}

		/// public propaty name  :  OffsetInTax
		/// <summary>相殺後内税消費税プロパティ</summary>
		/// <value>相殺結果：内税消費税の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後内税消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OffsetInTax
		{
			get{return _offsetInTax;}
			set{_offsetInTax = value;}
		}

		/// public propaty name  :  ThisTimeSales
		/// <summary>今回売上金額プロパティ</summary>
		/// <value>請求用：値引、返品を含まない税抜きの売上金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeSales
		{
			get{return _thisTimeSales;}
			set{_thisTimeSales = value;}
		}

		/// public propaty name  :  ThisSalesTax
		/// <summary>今回売上消費税プロパティ</summary>
		/// <value>請求用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesTax
		{
			get{return _thisSalesTax;}
			set{_thisSalesTax = value;}
		}

		/// public propaty name  :  ItdedSalesOutTax
		/// <summary>売上外税対象額プロパティ</summary>
		/// <value>請求用：外税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上外税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesOutTax
		{
			get{return _itdedSalesOutTax;}
			set{_itdedSalesOutTax = value;}
		}

		/// public propaty name  :  ItdedSalesInTax
		/// <summary>売上内税対象額プロパティ</summary>
		/// <value>請求用：内税額（税抜き）の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上内税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesInTax
		{
			get{return _itdedSalesInTax;}
			set{_itdedSalesInTax = value;}
		}

		/// public propaty name  :  ItdedSalesTaxFree
		/// <summary>売上非課税対象額プロパティ</summary>
		/// <value>請求用：非課税額の集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上非課税対象額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ItdedSalesTaxFree
		{
			get{return _itdedSalesTaxFree;}
			set{_itdedSalesTaxFree = value;}
		}

		/// public propaty name  :  SalesOutTax
		/// <summary>売上外税額プロパティ</summary>
		/// <value>請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上外税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesOutTax
		{
			get{return _salesOutTax;}
			set{_salesOutTax = value;}
		}

		/// public propaty name  :  SalesInTax
		/// <summary>売上内税額プロパティ</summary>
		/// <value>請求用：内税商品売上の内税消費税額（返品、値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上内税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesInTax
		{
			get{return _salesInTax;}
			set{_salesInTax = value;}
		}

		/// public propaty name  :  ThisSalesPricRgds
		/// <summary>今回売上返品金額プロパティ</summary>
		/// <value>返品用：値引を含まない税抜きの売上返品金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上返品金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPricRgds
		{
			get{return _thisSalesPricRgds;}
			set{_thisSalesPricRgds = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxRgds
		/// <summary>今回売上返品消費税プロパティ</summary>
		/// <value>返品用：返品外税額合計＋返品内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上返品消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxRgds
		{
			get{return _thisSalesPrcTaxRgds;}
			set{_thisSalesPrcTaxRgds = value;}
		}

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>返品外税対象額合計プロパティ</summary>
		/// <value>返品用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetOutTax
		{
			get{return _ttlItdedRetOutTax;}
			set{_ttlItdedRetOutTax = value;}
		}

		/// public propaty name  :  TtlItdedRetInTax
		/// <summary>返品内税対象額合計プロパティ</summary>
		/// <value>返品用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetInTax
		{
			get{return _ttlItdedRetInTax;}
			set{_ttlItdedRetInTax = value;}
		}

		/// public propaty name  :  TtlItdedRetTaxFree
		/// <summary>返品非課税対象額合計プロパティ</summary>
		/// <value>返品用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedRetTaxFree
		{
			get{return _ttlItdedRetTaxFree;}
			set{_ttlItdedRetTaxFree = value;}
		}

		/// public propaty name  :  TtlRetOuterTax
		/// <summary>返品外税額合計プロパティ</summary>
		/// <value>返品用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品外税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlRetOuterTax
		{
			get{return _ttlRetOuterTax;}
			set{_ttlRetOuterTax = value;}
		}

		/// public propaty name  :  TtlRetInnerTax
		/// <summary>返品内税額合計プロパティ</summary>
		/// <value>返品用：内税商品返品の内税消費税額（値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品内税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlRetInnerTax
		{
			get{return _ttlRetInnerTax;}
			set{_ttlRetInnerTax = value;}
		}

		/// public propaty name  :  ThisSalesPricDis
		/// <summary>今回売上値引金額プロパティ</summary>
		/// <value>値引用：税抜きの売上値引金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上値引金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPricDis
		{
			get{return _thisSalesPricDis;}
			set{_thisSalesPricDis = value;}
		}

		/// public propaty name  :  ThisSalesPrcTaxDis
		/// <summary>今回売上値引消費税プロパティ</summary>
		/// <value>値引用：値引外税額合計＋値引内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回売上値引消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisSalesPrcTaxDis
		{
			get{return _thisSalesPrcTaxDis;}
			set{_thisSalesPrcTaxDis = value;}
		}

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>値引外税対象額合計プロパティ</summary>
		/// <value>値引用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisOutTax
		{
			get{return _ttlItdedDisOutTax;}
			set{_ttlItdedDisOutTax = value;}
		}

		/// public propaty name  :  TtlItdedDisInTax
		/// <summary>値引内税対象額合計プロパティ</summary>
		/// <value>値引用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisInTax
		{
			get{return _ttlItdedDisInTax;}
			set{_ttlItdedDisInTax = value;}
		}

		/// public propaty name  :  TtlItdedDisTaxFree
		/// <summary>値引非課税対象額合計プロパティ</summary>
		/// <value>値引用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedDisTaxFree
		{
			get{return _ttlItdedDisTaxFree;}
			set{_ttlItdedDisTaxFree = value;}
		}

		/// public propaty name  :  TtlDisOuterTax
		/// <summary>値引外税額合計プロパティ</summary>
		/// <value>値引用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引外税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlDisOuterTax
		{
			get{return _ttlDisOuterTax;}
			set{_ttlDisOuterTax = value;}
		}

		/// public propaty name  :  TtlDisInnerTax
		/// <summary>値引内税額合計プロパティ</summary>
		/// <value>値引用：内税商品返品の内税消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引内税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlDisInnerTax
		{
			get{return _ttlDisInnerTax;}
			set{_ttlDisInnerTax = value;}
		}

		/// public propaty name  :  TaxAdjust
		/// <summary>消費税調整額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税調整額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TaxAdjust
		{
			get{return _taxAdjust;}
			set{_taxAdjust = value;}
		}

		/// public propaty name  :  BalanceAdjust
		/// <summary>残高調整額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残高調整額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 BalanceAdjust
		{
			get{return _balanceAdjust;}
			set{_balanceAdjust = value;}
		}

		/// public propaty name  :  AfCalTMonthAccRec
		/// <summary>計算後当月売掛金額プロパティ</summary>
		/// <value>今月分の売掛金額
        /// 繰越額＋今回純売上金額＋今回純売上消費税＋消費税調整額＋残高調整額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計算後当月売掛金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AfCalTMonthAccRec
		{
			get{return _afCalTMonthAccRec;}
			set{_afCalTMonthAccRec = value;}
		}

		/// public propaty name  :  AcpOdrTtl2TmBfAccRec
		/// <summary>受注2回前残高（売掛計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注2回前残高（売掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AcpOdrTtl2TmBfAccRec
		{
			get{return _acpOdrTtl2TmBfAccRec;}
			set{_acpOdrTtl2TmBfAccRec = value;}
		}

		/// public propaty name  :  AcpOdrTtl3TmBfAccRec
		/// <summary>受注3回前残高（売掛計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注3回前残高（売掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 AcpOdrTtl3TmBfAccRec
		{
			get{return _acpOdrTtl3TmBfAccRec;}
			set{_acpOdrTtl3TmBfAccRec = value;}
		}

		/// public propaty name  :  MonthAddUpExpDate
		/// <summary>月次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD　月次更新実行年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime MonthAddUpExpDate
		{
			get{return _monthAddUpExpDate;}
			set{_monthAddUpExpDate = value;}
		}

		/// public propaty name  :  MonthAddUpExpDateJpFormal
		/// <summary>月次更新実行年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD　月次更新実行年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新実行年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MonthAddUpExpDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateJpInFormal
		/// <summary>月次更新実行年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　月次更新実行年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新実行年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MonthAddUpExpDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateAdFormal
		/// <summary>月次更新実行年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD　月次更新実行年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新実行年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MonthAddUpExpDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  MonthAddUpExpDateAdInFormal
		/// <summary>月次更新実行年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　月次更新実行年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新実行年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MonthAddUpExpDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _monthAddUpExpDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDate
		/// <summary>月次更新開始年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新開始年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StMonCAddUpUpdDate
		{
			get{return _stMonCAddUpUpdDate;}
			set{_stMonCAddUpUpdDate = value;}
		}

		/// public propaty name  :  StMonCAddUpUpdDateJpFormal
		/// <summary>月次更新開始年月日 和暦プロパティ</summary>
		/// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新開始年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StMonCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateJpInFormal
		/// <summary>月次更新開始年月日 和暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新開始年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StMonCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateAdFormal
		/// <summary>月次更新開始年月日 西暦プロパティ</summary>
		/// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新開始年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StMonCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  StMonCAddUpUpdDateAdInFormal
		/// <summary>月次更新開始年月日 西暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   月次更新開始年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StMonCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _stMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDate
		/// <summary>前回月次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回月次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LaMonCAddUpUpdDate
		{
			get{return _laMonCAddUpUpdDate;}
			set{_laMonCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateJpFormal
		/// <summary>前回月次更新年月日 和暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回月次更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateJpInFormal
		/// <summary>前回月次更新年月日 和暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回月次更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateAdFormal
		/// <summary>前回月次更新年月日 西暦プロパティ</summary>
		/// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回月次更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  LaMonCAddUpUpdDateAdInFormal
		/// <summary>前回月次更新年月日 西暦(略)プロパティ</summary>
		/// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回月次更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LaMonCAddUpUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _laMonCAddUpUpdDate);}
			set{}
		}

		/// public propaty name  :  SalesSlipCount
		/// <summary>売上伝票枚数プロパティ</summary>
		/// <value>売上伝票枚数（掛売上＋現金売上）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCount
		{
			get{return _salesSlipCount;}
			set{_salesSlipCount = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// <value>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</value>
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

		/// public propaty name  :  ConsTaxRate
		/// <summary>消費税率プロパティ</summary>
		/// <value>変更2007/8/22(型,桁) 塩原</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
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

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// public propaty name  :  AddUpSecName
		/// <summary>計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpSecName
		{
			get{return _addUpSecName;}
			set{_addUpSecName = value;}
		}


		/// <summary>
		/// 得意先売掛金額マスタコンストラクタ
		/// </summary>
		/// <returns>CustAccRecクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustAccRec()
		{
		}

		/// <summary>
		/// 得意先売掛金額マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
		/// <param name="claimCode">請求先コード(請求先親コード)</param>
		/// <param name="claimName">請求先名称</param>
		/// <param name="claimName2">請求先名称2</param>
		/// <param name="claimSnm">請求先略称</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerName">得意先名称</param>
		/// <param name="customerName2">得意先名称2</param>
		/// <param name="customerSnm">得意先略称</param>
		/// <param name="addUpDate">計上年月日(YYYYMMDD 自社締を行なった日（自社締め基準）)</param>
		/// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
		/// <param name="lastTimeAccRec">前回売掛金額</param>
		/// <param name="thisTimeFeeDmdNrml">今回手数料額（通常入金）</param>
		/// <param name="thisTimeDisDmdNrml">今回値引額（通常入金）</param>
		/// <param name="thisTimeDmdNrml">今回入金金額（通常入金）(入金額の合計金額)</param>
		/// <param name="thisTimeTtlBlcAcc">今回繰越残高（売掛計）(今回繰越残高＝前回売掛金額－今回入金額合計（通常入金）)</param>
		/// <param name="ofsThisTimeSales">相殺後今回売上金額(相殺結果　「相殺後：***」の値が請求金額となる)</param>
		/// <param name="ofsThisSalesTax">相殺後今回売上消費税(相殺結果)</param>
		/// <param name="itdedOffsetOutTax">相殺後外税対象額(相殺結果：外税額（税抜き）の集計)</param>
		/// <param name="itdedOffsetInTax">相殺後内税対象額(相殺結果：内税額（税抜き）の集計)</param>
		/// <param name="itdedOffsetTaxFree">相殺後非課税対象額(相殺結果：非課税額の集計)</param>
		/// <param name="offsetOutTax">相殺後外税消費税(相殺結果：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
		/// <param name="offsetInTax">相殺後内税消費税(相殺結果：内税消費税の集計)</param>
		/// <param name="thisTimeSales">今回売上金額(請求用：値引、返品を含まない税抜きの売上金額)</param>
		/// <param name="thisSalesTax">今回売上消費税(請求用)</param>
		/// <param name="itdedSalesOutTax">売上外税対象額(請求用：外税額（税抜き）の集計)</param>
		/// <param name="itdedSalesInTax">売上内税対象額(請求用：内税額（税抜き）の集計)</param>
		/// <param name="itdedSalesTaxFree">売上非課税対象額(請求用：非課税額の集計)</param>
		/// <param name="salesOutTax">売上外税額(請求用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
		/// <param name="salesInTax">売上内税額(請求用：内税商品売上の内税消費税額（返品、値引含まず）)</param>
		/// <param name="thisSalesPricRgds">今回売上返品金額(返品用：値引を含まない税抜きの売上返品金額)</param>
		/// <param name="thisSalesPrcTaxRgds">今回売上返品消費税(返品用：返品外税額合計＋返品内税額合計)</param>
		/// <param name="ttlItdedRetOutTax">返品外税対象額合計(返品用)</param>
		/// <param name="ttlItdedRetInTax">返品内税対象額合計(返品用)</param>
		/// <param name="ttlItdedRetTaxFree">返品非課税対象額合計(返品用)</param>
		/// <param name="ttlRetOuterTax">返品外税額合計(返品用)</param>
		/// <param name="ttlRetInnerTax">返品内税額合計(返品用：内税商品返品の内税消費税額（値引含まず）)</param>
		/// <param name="thisSalesPricDis">今回売上値引金額(値引用：税抜きの売上値引金額)</param>
		/// <param name="thisSalesPrcTaxDis">今回売上値引消費税(値引用：値引外税額合計＋値引内税額合計)</param>
		/// <param name="ttlItdedDisOutTax">値引外税対象額合計(値引用)</param>
		/// <param name="ttlItdedDisInTax">値引内税対象額合計(値引用)</param>
		/// <param name="ttlItdedDisTaxFree">値引非課税対象額合計(値引用)</param>
		/// <param name="ttlDisOuterTax">値引外税額合計(値引用)</param>
		/// <param name="ttlDisInnerTax">値引内税額合計(値引用：内税商品返品の内税消費税額)</param>
		/// <param name="taxAdjust">消費税調整額</param>
		/// <param name="balanceAdjust">残高調整額</param>
		/// <param name="afCalTMonthAccRec">計算後当月売掛金額(今月分の売掛金額
        /// 繰越額＋今回純売上金額＋今回純売上消費税＋消費税調整額＋残高調整額)</param>
		/// <param name="acpOdrTtl2TmBfAccRec">受注2回前残高（売掛計）</param>
		/// <param name="acpOdrTtl3TmBfAccRec">受注3回前残高（売掛計）</param>
		/// <param name="monthAddUpExpDate">月次更新実行年月日(YYYYMMDD　月次更新実行年月日)</param>
		/// <param name="stMonCAddUpUpdDate">月次更新開始年月日("YYYYMMDD"  月次更新対象となる開始年月日)</param>
		/// <param name="laMonCAddUpUpdDate">前回月次更新年月日("YYYYMMDD"  前回月次更新対象となった年月日)</param>
		/// <param name="salesSlipCount">売上伝票枚数(売上伝票枚数（掛売上＋現金売上）)</param>
		/// <param name="consTaxLayMethod">消費税転嫁方式(消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括)</param>
		/// <param name="consTaxRate">消費税率(変更2007/8/22(型,桁) 塩原)</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="addUpSecName">計上拠点名称</param>
		/// <returns>CustAccRecクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustAccRec(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string addUpSecCode,Int32 claimCode,string claimName,string claimName2,string claimSnm,Int32 customerCode,string customerName,string customerName2,string customerSnm,DateTime addUpDate,DateTime addUpYearMonth,Int64 lastTimeAccRec,Int64 thisTimeFeeDmdNrml,Int64 thisTimeDisDmdNrml,Int64 thisTimeDmdNrml,Int64 thisTimeTtlBlcAcc,Int64 ofsThisTimeSales,Int64 ofsThisSalesTax,Int64 itdedOffsetOutTax,Int64 itdedOffsetInTax,Int64 itdedOffsetTaxFree,Int64 offsetOutTax,Int64 offsetInTax,Int64 thisTimeSales,Int64 thisSalesTax,Int64 itdedSalesOutTax,Int64 itdedSalesInTax,Int64 itdedSalesTaxFree,Int64 salesOutTax,Int64 salesInTax,Int64 thisSalesPricRgds,Int64 thisSalesPrcTaxRgds,Int64 ttlItdedRetOutTax,Int64 ttlItdedRetInTax,Int64 ttlItdedRetTaxFree,Int64 ttlRetOuterTax,Int64 ttlRetInnerTax,Int64 thisSalesPricDis,Int64 thisSalesPrcTaxDis,Int64 ttlItdedDisOutTax,Int64 ttlItdedDisInTax,Int64 ttlItdedDisTaxFree,Int64 ttlDisOuterTax,Int64 ttlDisInnerTax,Int64 taxAdjust,Int64 balanceAdjust,Int64 afCalTMonthAccRec,Int64 acpOdrTtl2TmBfAccRec,Int64 acpOdrTtl3TmBfAccRec,DateTime monthAddUpExpDate,DateTime stMonCAddUpUpdDate,DateTime laMonCAddUpUpdDate,Int32 salesSlipCount,Int32 consTaxLayMethod,Double consTaxRate,Int32 fractionProcCd,string enterpriseName,string updEmployeeName,string addUpSecName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._addUpSecCode = addUpSecCode;
			this._claimCode = claimCode;
			this._claimName = claimName;
			this._claimName2 = claimName2;
			this._claimSnm = claimSnm;
			this._customerCode = customerCode;
			this._customerName = customerName;
			this._customerName2 = customerName2;
			this._customerSnm = customerSnm;
			this.AddUpDate = addUpDate;
			this.AddUpYearMonth = addUpYearMonth;
			this._lastTimeAccRec = lastTimeAccRec;
			this._thisTimeFeeDmdNrml = thisTimeFeeDmdNrml;
			this._thisTimeDisDmdNrml = thisTimeDisDmdNrml;
			this._thisTimeDmdNrml = thisTimeDmdNrml;
			this._thisTimeTtlBlcAcc = thisTimeTtlBlcAcc;
			this._ofsThisTimeSales = ofsThisTimeSales;
			this._ofsThisSalesTax = ofsThisSalesTax;
			this._itdedOffsetOutTax = itdedOffsetOutTax;
			this._itdedOffsetInTax = itdedOffsetInTax;
			this._itdedOffsetTaxFree = itdedOffsetTaxFree;
			this._offsetOutTax = offsetOutTax;
			this._offsetInTax = offsetInTax;
			this._thisTimeSales = thisTimeSales;
			this._thisSalesTax = thisSalesTax;
			this._itdedSalesOutTax = itdedSalesOutTax;
			this._itdedSalesInTax = itdedSalesInTax;
			this._itdedSalesTaxFree = itdedSalesTaxFree;
			this._salesOutTax = salesOutTax;
			this._salesInTax = salesInTax;
			this._thisSalesPricRgds = thisSalesPricRgds;
			this._thisSalesPrcTaxRgds = thisSalesPrcTaxRgds;
			this._ttlItdedRetOutTax = ttlItdedRetOutTax;
			this._ttlItdedRetInTax = ttlItdedRetInTax;
			this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
			this._ttlRetOuterTax = ttlRetOuterTax;
			this._ttlRetInnerTax = ttlRetInnerTax;
			this._thisSalesPricDis = thisSalesPricDis;
			this._thisSalesPrcTaxDis = thisSalesPrcTaxDis;
			this._ttlItdedDisOutTax = ttlItdedDisOutTax;
			this._ttlItdedDisInTax = ttlItdedDisInTax;
			this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
			this._ttlDisOuterTax = ttlDisOuterTax;
			this._ttlDisInnerTax = ttlDisInnerTax;
			this._taxAdjust = taxAdjust;
			this._balanceAdjust = balanceAdjust;
			this._afCalTMonthAccRec = afCalTMonthAccRec;
			this._acpOdrTtl2TmBfAccRec = acpOdrTtl2TmBfAccRec;
			this._acpOdrTtl3TmBfAccRec = acpOdrTtl3TmBfAccRec;
			this.MonthAddUpExpDate = monthAddUpExpDate;
			this.StMonCAddUpUpdDate = stMonCAddUpUpdDate;
			this.LaMonCAddUpUpdDate = laMonCAddUpUpdDate;
			this._salesSlipCount = salesSlipCount;
			this._consTaxLayMethod = consTaxLayMethod;
			this._consTaxRate = consTaxRate;
			this._fractionProcCd = fractionProcCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._addUpSecName = addUpSecName;

		}

		/// <summary>
		/// 得意先売掛金額マスタ複製処理
		/// </summary>
		/// <returns>CustAccRecクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustAccRecクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustAccRec Clone()
		{
			return new CustAccRec(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._addUpSecCode,this._claimCode,this._claimName,this._claimName2,this._claimSnm,this._customerCode,this._customerName,this._customerName2,this._customerSnm,this._addUpDate,this._addUpYearMonth,this._lastTimeAccRec,this._thisTimeFeeDmdNrml,this._thisTimeDisDmdNrml,this._thisTimeDmdNrml,this._thisTimeTtlBlcAcc,this._ofsThisTimeSales,this._ofsThisSalesTax,this._itdedOffsetOutTax,this._itdedOffsetInTax,this._itdedOffsetTaxFree,this._offsetOutTax,this._offsetInTax,this._thisTimeSales,this._thisSalesTax,this._itdedSalesOutTax,this._itdedSalesInTax,this._itdedSalesTaxFree,this._salesOutTax,this._salesInTax,this._thisSalesPricRgds,this._thisSalesPrcTaxRgds,this._ttlItdedRetOutTax,this._ttlItdedRetInTax,this._ttlItdedRetTaxFree,this._ttlRetOuterTax,this._ttlRetInnerTax,this._thisSalesPricDis,this._thisSalesPrcTaxDis,this._ttlItdedDisOutTax,this._ttlItdedDisInTax,this._ttlItdedDisTaxFree,this._ttlDisOuterTax,this._ttlDisInnerTax,this._taxAdjust,this._balanceAdjust,this._afCalTMonthAccRec,this._acpOdrTtl2TmBfAccRec,this._acpOdrTtl3TmBfAccRec,this._monthAddUpExpDate,this._stMonCAddUpUpdDate,this._laMonCAddUpUpdDate,this._salesSlipCount,this._consTaxLayMethod,this._consTaxRate,this._fractionProcCd,this._enterpriseName,this._updEmployeeName,this._addUpSecName);
		}

		/// <summary>
		/// 得意先売掛金額マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のCustAccRecクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustAccRec target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AddUpSecCode == target.AddUpSecCode)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.ClaimName == target.ClaimName)
				 && (this.ClaimName2 == target.ClaimName2)
				 && (this.ClaimSnm == target.ClaimSnm)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerName == target.CustomerName)
				 && (this.CustomerName2 == target.CustomerName2)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.AddUpDate == target.AddUpDate)
				 && (this.AddUpYearMonth == target.AddUpYearMonth)
				 && (this.LastTimeAccRec == target.LastTimeAccRec)
				 && (this.ThisTimeFeeDmdNrml == target.ThisTimeFeeDmdNrml)
				 && (this.ThisTimeDisDmdNrml == target.ThisTimeDisDmdNrml)
				 && (this.ThisTimeDmdNrml == target.ThisTimeDmdNrml)
				 && (this.ThisTimeTtlBlcAcc == target.ThisTimeTtlBlcAcc)
				 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
				 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
				 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
				 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
				 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
				 && (this.OffsetOutTax == target.OffsetOutTax)
				 && (this.OffsetInTax == target.OffsetInTax)
				 && (this.ThisTimeSales == target.ThisTimeSales)
				 && (this.ThisSalesTax == target.ThisSalesTax)
				 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
				 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
				 && (this.ItdedSalesTaxFree == target.ItdedSalesTaxFree)
				 && (this.SalesOutTax == target.SalesOutTax)
				 && (this.SalesInTax == target.SalesInTax)
				 && (this.ThisSalesPricRgds == target.ThisSalesPricRgds)
				 && (this.ThisSalesPrcTaxRgds == target.ThisSalesPrcTaxRgds)
				 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
				 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
				 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
				 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
				 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
				 && (this.ThisSalesPricDis == target.ThisSalesPricDis)
				 && (this.ThisSalesPrcTaxDis == target.ThisSalesPrcTaxDis)
				 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
				 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
				 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
				 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
				 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
				 && (this.TaxAdjust == target.TaxAdjust)
				 && (this.BalanceAdjust == target.BalanceAdjust)
				 && (this.AfCalTMonthAccRec == target.AfCalTMonthAccRec)
				 && (this.AcpOdrTtl2TmBfAccRec == target.AcpOdrTtl2TmBfAccRec)
				 && (this.AcpOdrTtl3TmBfAccRec == target.AcpOdrTtl3TmBfAccRec)
				 && (this.MonthAddUpExpDate == target.MonthAddUpExpDate)
				 && (this.StMonCAddUpUpdDate == target.StMonCAddUpUpdDate)
				 && (this.LaMonCAddUpUpdDate == target.LaMonCAddUpUpdDate)
				 && (this.SalesSlipCount == target.SalesSlipCount)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.ConsTaxRate == target.ConsTaxRate)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.AddUpSecName == target.AddUpSecName));
		}

		/// <summary>
		/// 得意先売掛金額マスタ比較処理
		/// </summary>
		/// <param name="custAccRec1">
		///                    比較するCustAccRecクラスのインスタンス
		/// </param>
		/// <param name="custAccRec2">比較するCustAccRecクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustAccRec custAccRec1, CustAccRec custAccRec2)
		{
			return ((custAccRec1.CreateDateTime == custAccRec2.CreateDateTime)
				 && (custAccRec1.UpdateDateTime == custAccRec2.UpdateDateTime)
				 && (custAccRec1.EnterpriseCode == custAccRec2.EnterpriseCode)
				 && (custAccRec1.FileHeaderGuid == custAccRec2.FileHeaderGuid)
				 && (custAccRec1.UpdEmployeeCode == custAccRec2.UpdEmployeeCode)
				 && (custAccRec1.UpdAssemblyId1 == custAccRec2.UpdAssemblyId1)
				 && (custAccRec1.UpdAssemblyId2 == custAccRec2.UpdAssemblyId2)
				 && (custAccRec1.LogicalDeleteCode == custAccRec2.LogicalDeleteCode)
				 && (custAccRec1.AddUpSecCode == custAccRec2.AddUpSecCode)
				 && (custAccRec1.ClaimCode == custAccRec2.ClaimCode)
				 && (custAccRec1.ClaimName == custAccRec2.ClaimName)
				 && (custAccRec1.ClaimName2 == custAccRec2.ClaimName2)
				 && (custAccRec1.ClaimSnm == custAccRec2.ClaimSnm)
				 && (custAccRec1.CustomerCode == custAccRec2.CustomerCode)
				 && (custAccRec1.CustomerName == custAccRec2.CustomerName)
				 && (custAccRec1.CustomerName2 == custAccRec2.CustomerName2)
				 && (custAccRec1.CustomerSnm == custAccRec2.CustomerSnm)
				 && (custAccRec1.AddUpDate == custAccRec2.AddUpDate)
				 && (custAccRec1.AddUpYearMonth == custAccRec2.AddUpYearMonth)
				 && (custAccRec1.LastTimeAccRec == custAccRec2.LastTimeAccRec)
				 && (custAccRec1.ThisTimeFeeDmdNrml == custAccRec2.ThisTimeFeeDmdNrml)
				 && (custAccRec1.ThisTimeDisDmdNrml == custAccRec2.ThisTimeDisDmdNrml)
				 && (custAccRec1.ThisTimeDmdNrml == custAccRec2.ThisTimeDmdNrml)
				 && (custAccRec1.ThisTimeTtlBlcAcc == custAccRec2.ThisTimeTtlBlcAcc)
				 && (custAccRec1.OfsThisTimeSales == custAccRec2.OfsThisTimeSales)
				 && (custAccRec1.OfsThisSalesTax == custAccRec2.OfsThisSalesTax)
				 && (custAccRec1.ItdedOffsetOutTax == custAccRec2.ItdedOffsetOutTax)
				 && (custAccRec1.ItdedOffsetInTax == custAccRec2.ItdedOffsetInTax)
				 && (custAccRec1.ItdedOffsetTaxFree == custAccRec2.ItdedOffsetTaxFree)
				 && (custAccRec1.OffsetOutTax == custAccRec2.OffsetOutTax)
				 && (custAccRec1.OffsetInTax == custAccRec2.OffsetInTax)
				 && (custAccRec1.ThisTimeSales == custAccRec2.ThisTimeSales)
				 && (custAccRec1.ThisSalesTax == custAccRec2.ThisSalesTax)
				 && (custAccRec1.ItdedSalesOutTax == custAccRec2.ItdedSalesOutTax)
				 && (custAccRec1.ItdedSalesInTax == custAccRec2.ItdedSalesInTax)
				 && (custAccRec1.ItdedSalesTaxFree == custAccRec2.ItdedSalesTaxFree)
				 && (custAccRec1.SalesOutTax == custAccRec2.SalesOutTax)
				 && (custAccRec1.SalesInTax == custAccRec2.SalesInTax)
				 && (custAccRec1.ThisSalesPricRgds == custAccRec2.ThisSalesPricRgds)
				 && (custAccRec1.ThisSalesPrcTaxRgds == custAccRec2.ThisSalesPrcTaxRgds)
				 && (custAccRec1.TtlItdedRetOutTax == custAccRec2.TtlItdedRetOutTax)
				 && (custAccRec1.TtlItdedRetInTax == custAccRec2.TtlItdedRetInTax)
				 && (custAccRec1.TtlItdedRetTaxFree == custAccRec2.TtlItdedRetTaxFree)
				 && (custAccRec1.TtlRetOuterTax == custAccRec2.TtlRetOuterTax)
				 && (custAccRec1.TtlRetInnerTax == custAccRec2.TtlRetInnerTax)
				 && (custAccRec1.ThisSalesPricDis == custAccRec2.ThisSalesPricDis)
				 && (custAccRec1.ThisSalesPrcTaxDis == custAccRec2.ThisSalesPrcTaxDis)
				 && (custAccRec1.TtlItdedDisOutTax == custAccRec2.TtlItdedDisOutTax)
				 && (custAccRec1.TtlItdedDisInTax == custAccRec2.TtlItdedDisInTax)
				 && (custAccRec1.TtlItdedDisTaxFree == custAccRec2.TtlItdedDisTaxFree)
				 && (custAccRec1.TtlDisOuterTax == custAccRec2.TtlDisOuterTax)
				 && (custAccRec1.TtlDisInnerTax == custAccRec2.TtlDisInnerTax)
				 && (custAccRec1.TaxAdjust == custAccRec2.TaxAdjust)
				 && (custAccRec1.BalanceAdjust == custAccRec2.BalanceAdjust)
				 && (custAccRec1.AfCalTMonthAccRec == custAccRec2.AfCalTMonthAccRec)
				 && (custAccRec1.AcpOdrTtl2TmBfAccRec == custAccRec2.AcpOdrTtl2TmBfAccRec)
				 && (custAccRec1.AcpOdrTtl3TmBfAccRec == custAccRec2.AcpOdrTtl3TmBfAccRec)
				 && (custAccRec1.MonthAddUpExpDate == custAccRec2.MonthAddUpExpDate)
				 && (custAccRec1.StMonCAddUpUpdDate == custAccRec2.StMonCAddUpUpdDate)
				 && (custAccRec1.LaMonCAddUpUpdDate == custAccRec2.LaMonCAddUpUpdDate)
				 && (custAccRec1.SalesSlipCount == custAccRec2.SalesSlipCount)
				 && (custAccRec1.ConsTaxLayMethod == custAccRec2.ConsTaxLayMethod)
				 && (custAccRec1.ConsTaxRate == custAccRec2.ConsTaxRate)
				 && (custAccRec1.FractionProcCd == custAccRec2.FractionProcCd)
				 && (custAccRec1.EnterpriseName == custAccRec2.EnterpriseName)
				 && (custAccRec1.UpdEmployeeName == custAccRec2.UpdEmployeeName)
				 && (custAccRec1.AddUpSecName == custAccRec2.AddUpSecName));
		}
		/// <summary>
		/// 得意先売掛金額マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のCustAccRecクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustAccRec target)
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
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.ClaimName != target.ClaimName)resList.Add("ClaimName");
			if(this.ClaimName2 != target.ClaimName2)resList.Add("ClaimName2");
			if(this.ClaimSnm != target.ClaimSnm)resList.Add("ClaimSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerName != target.CustomerName)resList.Add("CustomerName");
			if(this.CustomerName2 != target.CustomerName2)resList.Add("CustomerName2");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.AddUpYearMonth != target.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(this.LastTimeAccRec != target.LastTimeAccRec)resList.Add("LastTimeAccRec");
			if(this.ThisTimeFeeDmdNrml != target.ThisTimeFeeDmdNrml)resList.Add("ThisTimeFeeDmdNrml");
			if(this.ThisTimeDisDmdNrml != target.ThisTimeDisDmdNrml)resList.Add("ThisTimeDisDmdNrml");
			if(this.ThisTimeDmdNrml != target.ThisTimeDmdNrml)resList.Add("ThisTimeDmdNrml");
			if(this.ThisTimeTtlBlcAcc != target.ThisTimeTtlBlcAcc)resList.Add("ThisTimeTtlBlcAcc");
			if(this.OfsThisTimeSales != target.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(this.OfsThisSalesTax != target.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(this.ItdedOffsetOutTax != target.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(this.ItdedOffsetInTax != target.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(this.OffsetOutTax != target.OffsetOutTax)resList.Add("OffsetOutTax");
			if(this.OffsetInTax != target.OffsetInTax)resList.Add("OffsetInTax");
			if(this.ThisTimeSales != target.ThisTimeSales)resList.Add("ThisTimeSales");
			if(this.ThisSalesTax != target.ThisSalesTax)resList.Add("ThisSalesTax");
			if(this.ItdedSalesOutTax != target.ItdedSalesOutTax)resList.Add("ItdedSalesOutTax");
			if(this.ItdedSalesInTax != target.ItdedSalesInTax)resList.Add("ItdedSalesInTax");
			if(this.ItdedSalesTaxFree != target.ItdedSalesTaxFree)resList.Add("ItdedSalesTaxFree");
			if(this.SalesOutTax != target.SalesOutTax)resList.Add("SalesOutTax");
			if(this.SalesInTax != target.SalesInTax)resList.Add("SalesInTax");
			if(this.ThisSalesPricRgds != target.ThisSalesPricRgds)resList.Add("ThisSalesPricRgds");
			if(this.ThisSalesPrcTaxRgds != target.ThisSalesPrcTaxRgds)resList.Add("ThisSalesPrcTaxRgds");
			if(this.TtlItdedRetOutTax != target.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(this.TtlItdedRetInTax != target.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(this.TtlRetOuterTax != target.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(this.TtlRetInnerTax != target.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(this.ThisSalesPricDis != target.ThisSalesPricDis)resList.Add("ThisSalesPricDis");
			if(this.ThisSalesPrcTaxDis != target.ThisSalesPrcTaxDis)resList.Add("ThisSalesPrcTaxDis");
			if(this.TtlItdedDisOutTax != target.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(this.TtlItdedDisInTax != target.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(this.TtlDisOuterTax != target.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(this.TtlDisInnerTax != target.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(this.TaxAdjust != target.TaxAdjust)resList.Add("TaxAdjust");
			if(this.BalanceAdjust != target.BalanceAdjust)resList.Add("BalanceAdjust");
			if(this.AfCalTMonthAccRec != target.AfCalTMonthAccRec)resList.Add("AfCalTMonthAccRec");
			if(this.AcpOdrTtl2TmBfAccRec != target.AcpOdrTtl2TmBfAccRec)resList.Add("AcpOdrTtl2TmBfAccRec");
			if(this.AcpOdrTtl3TmBfAccRec != target.AcpOdrTtl3TmBfAccRec)resList.Add("AcpOdrTtl3TmBfAccRec");
			if(this.MonthAddUpExpDate != target.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(this.StMonCAddUpUpdDate != target.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(this.LaMonCAddUpUpdDate != target.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(this.SalesSlipCount != target.SalesSlipCount)resList.Add("SalesSlipCount");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.ConsTaxRate != target.ConsTaxRate)resList.Add("ConsTaxRate");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.AddUpSecName != target.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}

		/// <summary>
		/// 得意先売掛金額マスタ比較処理
		/// </summary>
		/// <param name="custAccRec1">比較するCustAccRecクラスのインスタンス</param>
		/// <param name="custAccRec2">比較するCustAccRecクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustAccRecクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustAccRec custAccRec1, CustAccRec custAccRec2)
		{
			ArrayList resList = new ArrayList();
			if(custAccRec1.CreateDateTime != custAccRec2.CreateDateTime)resList.Add("CreateDateTime");
			if(custAccRec1.UpdateDateTime != custAccRec2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(custAccRec1.EnterpriseCode != custAccRec2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custAccRec1.FileHeaderGuid != custAccRec2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(custAccRec1.UpdEmployeeCode != custAccRec2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(custAccRec1.UpdAssemblyId1 != custAccRec2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(custAccRec1.UpdAssemblyId2 != custAccRec2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(custAccRec1.LogicalDeleteCode != custAccRec2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(custAccRec1.AddUpSecCode != custAccRec2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(custAccRec1.ClaimCode != custAccRec2.ClaimCode)resList.Add("ClaimCode");
			if(custAccRec1.ClaimName != custAccRec2.ClaimName)resList.Add("ClaimName");
			if(custAccRec1.ClaimName2 != custAccRec2.ClaimName2)resList.Add("ClaimName2");
			if(custAccRec1.ClaimSnm != custAccRec2.ClaimSnm)resList.Add("ClaimSnm");
			if(custAccRec1.CustomerCode != custAccRec2.CustomerCode)resList.Add("CustomerCode");
			if(custAccRec1.CustomerName != custAccRec2.CustomerName)resList.Add("CustomerName");
			if(custAccRec1.CustomerName2 != custAccRec2.CustomerName2)resList.Add("CustomerName2");
			if(custAccRec1.CustomerSnm != custAccRec2.CustomerSnm)resList.Add("CustomerSnm");
			if(custAccRec1.AddUpDate != custAccRec2.AddUpDate)resList.Add("AddUpDate");
			if(custAccRec1.AddUpYearMonth != custAccRec2.AddUpYearMonth)resList.Add("AddUpYearMonth");
			if(custAccRec1.LastTimeAccRec != custAccRec2.LastTimeAccRec)resList.Add("LastTimeAccRec");
			if(custAccRec1.ThisTimeFeeDmdNrml != custAccRec2.ThisTimeFeeDmdNrml)resList.Add("ThisTimeFeeDmdNrml");
			if(custAccRec1.ThisTimeDisDmdNrml != custAccRec2.ThisTimeDisDmdNrml)resList.Add("ThisTimeDisDmdNrml");
			if(custAccRec1.ThisTimeDmdNrml != custAccRec2.ThisTimeDmdNrml)resList.Add("ThisTimeDmdNrml");
			if(custAccRec1.ThisTimeTtlBlcAcc != custAccRec2.ThisTimeTtlBlcAcc)resList.Add("ThisTimeTtlBlcAcc");
			if(custAccRec1.OfsThisTimeSales != custAccRec2.OfsThisTimeSales)resList.Add("OfsThisTimeSales");
			if(custAccRec1.OfsThisSalesTax != custAccRec2.OfsThisSalesTax)resList.Add("OfsThisSalesTax");
			if(custAccRec1.ItdedOffsetOutTax != custAccRec2.ItdedOffsetOutTax)resList.Add("ItdedOffsetOutTax");
			if(custAccRec1.ItdedOffsetInTax != custAccRec2.ItdedOffsetInTax)resList.Add("ItdedOffsetInTax");
			if(custAccRec1.ItdedOffsetTaxFree != custAccRec2.ItdedOffsetTaxFree)resList.Add("ItdedOffsetTaxFree");
			if(custAccRec1.OffsetOutTax != custAccRec2.OffsetOutTax)resList.Add("OffsetOutTax");
			if(custAccRec1.OffsetInTax != custAccRec2.OffsetInTax)resList.Add("OffsetInTax");
			if(custAccRec1.ThisTimeSales != custAccRec2.ThisTimeSales)resList.Add("ThisTimeSales");
			if(custAccRec1.ThisSalesTax != custAccRec2.ThisSalesTax)resList.Add("ThisSalesTax");
			if(custAccRec1.ItdedSalesOutTax != custAccRec2.ItdedSalesOutTax)resList.Add("ItdedSalesOutTax");
			if(custAccRec1.ItdedSalesInTax != custAccRec2.ItdedSalesInTax)resList.Add("ItdedSalesInTax");
			if(custAccRec1.ItdedSalesTaxFree != custAccRec2.ItdedSalesTaxFree)resList.Add("ItdedSalesTaxFree");
			if(custAccRec1.SalesOutTax != custAccRec2.SalesOutTax)resList.Add("SalesOutTax");
			if(custAccRec1.SalesInTax != custAccRec2.SalesInTax)resList.Add("SalesInTax");
			if(custAccRec1.ThisSalesPricRgds != custAccRec2.ThisSalesPricRgds)resList.Add("ThisSalesPricRgds");
			if(custAccRec1.ThisSalesPrcTaxRgds != custAccRec2.ThisSalesPrcTaxRgds)resList.Add("ThisSalesPrcTaxRgds");
			if(custAccRec1.TtlItdedRetOutTax != custAccRec2.TtlItdedRetOutTax)resList.Add("TtlItdedRetOutTax");
			if(custAccRec1.TtlItdedRetInTax != custAccRec2.TtlItdedRetInTax)resList.Add("TtlItdedRetInTax");
			if(custAccRec1.TtlItdedRetTaxFree != custAccRec2.TtlItdedRetTaxFree)resList.Add("TtlItdedRetTaxFree");
			if(custAccRec1.TtlRetOuterTax != custAccRec2.TtlRetOuterTax)resList.Add("TtlRetOuterTax");
			if(custAccRec1.TtlRetInnerTax != custAccRec2.TtlRetInnerTax)resList.Add("TtlRetInnerTax");
			if(custAccRec1.ThisSalesPricDis != custAccRec2.ThisSalesPricDis)resList.Add("ThisSalesPricDis");
			if(custAccRec1.ThisSalesPrcTaxDis != custAccRec2.ThisSalesPrcTaxDis)resList.Add("ThisSalesPrcTaxDis");
			if(custAccRec1.TtlItdedDisOutTax != custAccRec2.TtlItdedDisOutTax)resList.Add("TtlItdedDisOutTax");
			if(custAccRec1.TtlItdedDisInTax != custAccRec2.TtlItdedDisInTax)resList.Add("TtlItdedDisInTax");
			if(custAccRec1.TtlItdedDisTaxFree != custAccRec2.TtlItdedDisTaxFree)resList.Add("TtlItdedDisTaxFree");
			if(custAccRec1.TtlDisOuterTax != custAccRec2.TtlDisOuterTax)resList.Add("TtlDisOuterTax");
			if(custAccRec1.TtlDisInnerTax != custAccRec2.TtlDisInnerTax)resList.Add("TtlDisInnerTax");
			if(custAccRec1.TaxAdjust != custAccRec2.TaxAdjust)resList.Add("TaxAdjust");
			if(custAccRec1.BalanceAdjust != custAccRec2.BalanceAdjust)resList.Add("BalanceAdjust");
			if(custAccRec1.AfCalTMonthAccRec != custAccRec2.AfCalTMonthAccRec)resList.Add("AfCalTMonthAccRec");
			if(custAccRec1.AcpOdrTtl2TmBfAccRec != custAccRec2.AcpOdrTtl2TmBfAccRec)resList.Add("AcpOdrTtl2TmBfAccRec");
			if(custAccRec1.AcpOdrTtl3TmBfAccRec != custAccRec2.AcpOdrTtl3TmBfAccRec)resList.Add("AcpOdrTtl3TmBfAccRec");
			if(custAccRec1.MonthAddUpExpDate != custAccRec2.MonthAddUpExpDate)resList.Add("MonthAddUpExpDate");
			if(custAccRec1.StMonCAddUpUpdDate != custAccRec2.StMonCAddUpUpdDate)resList.Add("StMonCAddUpUpdDate");
			if(custAccRec1.LaMonCAddUpUpdDate != custAccRec2.LaMonCAddUpUpdDate)resList.Add("LaMonCAddUpUpdDate");
			if(custAccRec1.SalesSlipCount != custAccRec2.SalesSlipCount)resList.Add("SalesSlipCount");
			if(custAccRec1.ConsTaxLayMethod != custAccRec2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(custAccRec1.ConsTaxRate != custAccRec2.ConsTaxRate)resList.Add("ConsTaxRate");
			if(custAccRec1.FractionProcCd != custAccRec2.FractionProcCd)resList.Add("FractionProcCd");
			if(custAccRec1.EnterpriseName != custAccRec2.EnterpriseName)resList.Add("EnterpriseName");
			if(custAccRec1.UpdEmployeeName != custAccRec2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(custAccRec1.AddUpSecName != custAccRec2.AddUpSecName)resList.Add("AddUpSecName");

			return resList;
		}
	}
}
