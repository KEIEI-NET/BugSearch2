using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplAccPayWork
	/// <summary>
	///                      仕入先買掛金額ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先買掛金額ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/06/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SuplAccPayWork : IFileHeader
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

		/// <summary>支払先コード</summary>
		/// <remarks>買掛の親コード</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先名称</summary>
		private string _payeeName = "";

		/// <summary>支払先名称2</summary>
		private string _payeeName2 = "";

		/// <summary>支払先略称</summary>
		private string _payeeSnm = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>買掛の子コード</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先名1</summary>
		private string _supplierNm1 = "";

		/// <summary>仕入先名2</summary>
		private string _supplierNm2 = "";

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD 買掛の計上日（自社基準）</remarks>
		private DateTime _addUpDate;

		/// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>前回買掛金額</summary>
		private Int64 _lastTimeAccPay;

		/// <summary>今回手数料額（通常支払）</summary>
		private Int64 _thisTimeFeePayNrml;

		/// <summary>今回値引額（通常支払）</summary>
		private Int64 _thisTimeDisPayNrml;

		/// <summary>今回支払金額（通常支払）</summary>
		/// <remarks>支払額の合計金額</remarks>
		private Int64 _thisTimePayNrml;

		/// <summary>今回繰越残高（買掛計）</summary>
		/// <remarks>今回繰越残高＝前回買掛金額－今回支払額合計（通常入金）</remarks>
		private Int64 _thisTimeTtlBlcAcPay;

		/// <summary>相殺後今回仕入金額</summary>
		/// <remarks>相殺結果</remarks>
		private Int64 _ofsThisTimeStock;

		/// <summary>相殺後今回仕入消費税</summary>
		/// <remarks>相殺結果</remarks>
		private Int64 _ofsThisStockTax;

		/// <summary>相殺後外税対象額</summary>
		/// <remarks>相殺用：外税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetOutTax;

		/// <summary>相殺後内税対象額</summary>
		/// <remarks>相殺用：内税額（税抜き）の集計</remarks>
		private Int64 _itdedOffsetInTax;

		/// <summary>相殺後非課税対象額</summary>
		/// <remarks>相殺用：非課税額の集計</remarks>
		private Int64 _itdedOffsetTaxFree;

		/// <summary>相殺後外税消費税</summary>
		/// <remarks>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</remarks>
		private Int64 _offsetOutTax;

		/// <summary>相殺後内税消費税</summary>
		/// <remarks>相殺用：内税消費税の集計</remarks>
		private Int64 _offsetInTax;

		/// <summary>今回仕入金額</summary>
		/// <remarks>値引、返品を含まない 税抜きの仕入金額</remarks>
		private Int64 _thisTimeStockPrice;

		/// <summary>今回仕入消費税</summary>
		/// <remarks>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</remarks>
		private Int64 _thisStcPrcTax;

		/// <summary>仕入外税対象額合計</summary>
		private Int64 _ttlItdedStcOutTax;

		/// <summary>仕入内税対象額合計</summary>
		private Int64 _ttlItdedStcInTax;

		/// <summary>仕入非課税対象額合計</summary>
		private Int64 _ttlItdedStcTaxFree;

		/// <summary>仕入外税額合計</summary>
		private Int64 _ttlStockOuterTax;

		/// <summary>仕入内税額合計</summary>
		/// <remarks>内税商品仕入の内税消費税額（返品、値引含まず）</remarks>
		private Int64 _ttlStockInnerTax;

		/// <summary>今回返品金額</summary>
		/// <remarks>値引、返品を含まない 税抜きの仕入返品金額</remarks>
		private Int64 _thisStckPricRgds;

		/// <summary>今回返品消費税</summary>
		/// <remarks>今回返品消費税＝返品外税額合計＋返品内税額合計</remarks>
		private Int64 _thisStcPrcTaxRgds;

		/// <summary>返品外税対象額合計</summary>
		private Int64 _ttlItdedRetOutTax;

		/// <summary>返品内税対象額合計</summary>
		private Int64 _ttlItdedRetInTax;

		/// <summary>返品非課税対象額合計</summary>
		private Int64 _ttlItdedRetTaxFree;

		/// <summary>返品外税額合計</summary>
		private Int64 _ttlRetOuterTax;

		/// <summary>返品内税額合計</summary>
		/// <remarks>内税商品返品の内税消費税額（値引含まず）</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>今回値引金額</summary>
		/// <remarks>税抜きの仕入値引き金額</remarks>
		private Int64 _thisStckPricDis;

		/// <summary>今回値引消費税</summary>
		/// <remarks>今回値引消費税＝値引外税額合計＋値引内税額合計</remarks>
		private Int64 _thisStcPrcTaxDis;

		/// <summary>値引外税対象額合計</summary>
		private Int64 _ttlItdedDisOutTax;

		/// <summary>値引内税対象額合計</summary>
		private Int64 _ttlItdedDisInTax;

		/// <summary>値引非課税対象額合計</summary>
		private Int64 _ttlItdedDisTaxFree;

		/// <summary>値引外税額合計</summary>
		private Int64 _ttlDisOuterTax;

		/// <summary>値引内税額合計</summary>
		/// <remarks>内税商品値引の内税消費税額</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>仕入合計残高（買掛計）</summary>
		/// <remarks>今月分の買掛残高 + 今回繰越残高＋今回純仕入金額＋今回純仕入消費税＋消費税調整額＋残高調整額</remarks>
		private Int64 _stckTtlAccPayBalance;

		/// <summary>仕入2回前残高（買掛計）</summary>
		private Int64 _stckTtl2TmBfBlAccPay;

		/// <summary>仕入3回前残高（買掛計）</summary>
		private Int64 _stckTtl3TmBfBlAccPay;

		/// <summary>月次更新実行年月日</summary>
		/// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
		private DateTime _monthAddUpExpDate;

		/// <summary>月次更新開始年月日</summary>
		/// <remarks>"YYYYMMDD"  月次更新対象となる開始年月日</remarks>
		private DateTime _stMonCAddUpUpdDate;

		/// <summary>前回月次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回月次更新対象となった年月日</remarks>
		private DateTime _laMonCAddUpUpdDate;

		/// <summary>仕入伝票枚数</summary>
		/// <remarks>仕入伝票枚数（掛仕入＋現金仕入）</remarks>
		private Int32 _stockSlipCount;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入先消費税税率</summary>
		private Double _supplierConsTaxRate;

		/// <summary>端数処理区分</summary>
		private Int32 _fractionProcCd;


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

		/// public propaty name  :  ResultsAddUpSecCd
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

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// <value>買掛の親コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeName
		/// <summary>支払先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName
		{
			get{return _payeeName;}
			set{_payeeName = value;}
		}

		/// public propaty name  :  PayeeName2
		/// <summary>支払先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeName2
		{
			get{return _payeeName2;}
			set{_payeeName2 = value;}
		}

		/// public propaty name  :  PayeeSnm
		/// <summary>支払先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayeeSnm
		{
			get{return _payeeSnm;}
			set{_payeeSnm = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>買掛の子コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierNm1
		/// <summary>仕入先名1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>仕入先名2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD 買掛の計上日（自社基準）</value>
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

		/// public propaty name  :  SalesDate
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

		/// public propaty name  :  LastTimeAccPay
		/// <summary>前回買掛金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回買掛金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimeAccPay
		{
			get{return _lastTimeAccPay;}
			set{_lastTimeAccPay = value;}
		}

		/// public propaty name  :  ThisTimeFeePayNrml
		/// <summary>今回手数料額（通常支払）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回手数料額（通常支払）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeFeePayNrml
		{
			get{return _thisTimeFeePayNrml;}
			set{_thisTimeFeePayNrml = value;}
		}

		/// public propaty name  :  ThisTimeDisPayNrml
		/// <summary>今回値引額（通常支払）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引額（通常支払）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeDisPayNrml
		{
			get{return _thisTimeDisPayNrml;}
			set{_thisTimeDisPayNrml = value;}
		}

		/// public propaty name  :  ThisTimePayNrml
		/// <summary>今回支払金額（通常支払）プロパティ</summary>
		/// <value>支払額の合計金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回支払金額（通常支払）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimePayNrml
		{
			get{return _thisTimePayNrml;}
			set{_thisTimePayNrml = value;}
		}

		/// public propaty name  :  ThisTimeTtlBlcAcPay
		/// <summary>今回繰越残高（買掛計）プロパティ</summary>
		/// <value>今回繰越残高＝前回買掛金額－今回支払額合計（通常入金）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回繰越残高（買掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcAcPay
		{
			get{return _thisTimeTtlBlcAcPay;}
			set{_thisTimeTtlBlcAcPay = value;}
		}

		/// public propaty name  :  OfsThisTimeStock
		/// <summary>相殺後今回仕入金額プロパティ</summary>
		/// <value>相殺結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回仕入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisTimeStock
		{
			get{return _ofsThisTimeStock;}
			set{_ofsThisTimeStock = value;}
		}

		/// public propaty name  :  OfsThisStockTax
		/// <summary>相殺後今回仕入消費税プロパティ</summary>
		/// <value>相殺結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相殺後今回仕入消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 OfsThisStockTax
		{
			get{return _ofsThisStockTax;}
			set{_ofsThisStockTax = value;}
		}

		/// public propaty name  :  ItdedOffsetOutTax
		/// <summary>相殺後外税対象額プロパティ</summary>
		/// <value>相殺用：外税額（税抜き）の集計</value>
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
		/// <value>相殺用：内税額（税抜き）の集計</value>
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
		/// <value>相殺用：非課税額の集計</value>
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
		/// <value>相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）</value>
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
		/// <value>相殺用：内税消費税の集計</value>
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

		/// public propaty name  :  ThisTimeStockPrice
		/// <summary>今回仕入金額プロパティ</summary>
		/// <value>値引、返品を含まない 税抜きの仕入金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回仕入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeStockPrice
		{
			get{return _thisTimeStockPrice;}
			set{_thisTimeStockPrice = value;}
		}

		/// public propaty name  :  ThisStcPrcTax
		/// <summary>今回仕入消費税プロパティ</summary>
		/// <value>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回仕入消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTax
		{
			get{return _thisStcPrcTax;}
			set{_thisStcPrcTax = value;}
		}

		/// public propaty name  :  TtlItdedStcOutTax
		/// <summary>仕入外税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入外税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcOutTax
		{
			get{return _ttlItdedStcOutTax;}
			set{_ttlItdedStcOutTax = value;}
		}

		/// public propaty name  :  TtlItdedStcInTax
		/// <summary>仕入内税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入内税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcInTax
		{
			get{return _ttlItdedStcInTax;}
			set{_ttlItdedStcInTax = value;}
		}

		/// public propaty name  :  TtlItdedStcTaxFree
		/// <summary>仕入非課税対象額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入非課税対象額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlItdedStcTaxFree
		{
			get{return _ttlItdedStcTaxFree;}
			set{_ttlItdedStcTaxFree = value;}
		}

		/// public propaty name  :  TtlStockOuterTax
		/// <summary>仕入外税額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入外税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlStockOuterTax
		{
			get{return _ttlStockOuterTax;}
			set{_ttlStockOuterTax = value;}
		}

		/// public propaty name  :  TtlStockInnerTax
		/// <summary>仕入内税額合計プロパティ</summary>
		/// <value>内税商品仕入の内税消費税額（返品、値引含まず）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入内税額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TtlStockInnerTax
		{
			get{return _ttlStockInnerTax;}
			set{_ttlStockInnerTax = value;}
		}

		/// public propaty name  :  ThisStckPricRgds
		/// <summary>今回返品金額プロパティ</summary>
		/// <value>値引、返品を含まない 税抜きの仕入返品金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回返品金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStckPricRgds
		{
			get{return _thisStckPricRgds;}
			set{_thisStckPricRgds = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxRgds
		/// <summary>今回返品消費税プロパティ</summary>
		/// <value>今回返品消費税＝返品外税額合計＋返品内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回返品消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxRgds
		{
			get{return _thisStcPrcTaxRgds;}
			set{_thisStcPrcTaxRgds = value;}
		}

		/// public propaty name  :  TtlItdedRetOutTax
		/// <summary>返品外税対象額合計プロパティ</summary>
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
		/// <value>内税商品返品の内税消費税額（値引含まず）</value>
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

		/// public propaty name  :  ThisStckPricDis
		/// <summary>今回値引金額プロパティ</summary>
		/// <value>税抜きの仕入値引き金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStckPricDis
		{
			get{return _thisStckPricDis;}
			set{_thisStckPricDis = value;}
		}

		/// public propaty name  :  ThisStcPrcTaxDis
		/// <summary>今回値引消費税プロパティ</summary>
		/// <value>今回値引消費税＝値引外税額合計＋値引内税額合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回値引消費税プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisStcPrcTaxDis
		{
			get{return _thisStcPrcTaxDis;}
			set{_thisStcPrcTaxDis = value;}
		}

		/// public propaty name  :  TtlItdedDisOutTax
		/// <summary>値引外税対象額合計プロパティ</summary>
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
		/// <value>内税商品値引の内税消費税額</value>
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

		/// public propaty name  :  StckTtlAccPayBalance
		/// <summary>仕入合計残高（買掛計）プロパティ</summary>
		/// <value>今月分の買掛残高 + 今回繰越残高＋今回純仕入金額＋今回純仕入消費税＋消費税調整額＋残高調整額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入合計残高（買掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckTtlAccPayBalance
		{
			get{return _stckTtlAccPayBalance;}
			set{_stckTtlAccPayBalance = value;}
		}

		/// public propaty name  :  StckTtl2TmBfBlAccPay
		/// <summary>仕入2回前残高（買掛計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入2回前残高（買掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckTtl2TmBfBlAccPay
		{
			get{return _stckTtl2TmBfBlAccPay;}
			set{_stckTtl2TmBfBlAccPay = value;}
		}

		/// public propaty name  :  StckTtl3TmBfBlAccPay
		/// <summary>仕入3回前残高（買掛計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入3回前残高（買掛計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StckTtl3TmBfBlAccPay
		{
			get{return _stckTtl3TmBfBlAccPay;}
			set{_stckTtl3TmBfBlAccPay = value;}
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

		/// public propaty name  :  StockSlipCount
		/// <summary>仕入伝票枚数プロパティ</summary>
		/// <value>仕入伝票枚数（掛仕入＋現金仕入）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSlipCount
		{
			get{return _stockSlipCount;}
			set{_stockSlipCount = value;}
		}

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppCTaxLayCd
		{
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
		}

		/// public propaty name  :  SupplierConsTaxRate
		/// <summary>仕入先消費税税率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先消費税税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SupplierConsTaxRate
		{
			get{return _supplierConsTaxRate;}
			set{_supplierConsTaxRate = value;}
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


		/// <summary>
		/// 仕入先買掛金額ワークコンストラクタ
		/// </summary>
		/// <returns>SuplAccPayWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplAccPayWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplAccPayWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuplAccPayWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuplAccPayWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuplAccPayWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccPayWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplAccPayWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplAccPayWork || graph is ArrayList || graph is SuplAccPayWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuplAccPayWork).FullName));

            if (graph != null && graph is SuplAccPayWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplAccPayWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplAccPayWork[])graph).Length;
            }
            else if (graph is SuplAccPayWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //前回買掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //今回手数料額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //今回値引額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //今回繰越残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //相殺後外税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //相殺後内税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //相殺後非課税対象額
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //相殺後外税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //相殺後内税消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTax
            //仕入外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcOutTax
            //仕入内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcInTax
            //仕入非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //仕入外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlStockOuterTax
            //仕入内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlStockInnerTax
            //今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //今回返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxRgds
            //返品外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //返品内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //返品非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //返品外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //返品内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //今回値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxDis
            //値引外税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //値引内税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //値引非課税対象額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //値引外税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //値引内税額合計
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //仕入合計残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //仕入2回前残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl2TmBfBlAccPay
            //仕入3回前残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl3TmBfBlAccPay
            //月次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //月次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //前回月次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplAccPayWork)
            {
                SuplAccPayWork temp = (SuplAccPayWork)graph;

                SetSuplAccPayWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplAccPayWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplAccPayWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplAccPayWork temp in lst)
                {
                    SetSuplAccPayWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplAccPayWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 64;

        /// <summary>
        ///  SuplAccPayWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccPayWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuplAccPayWork(System.IO.BinaryWriter writer, SuplAccPayWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //前回買掛金額
            writer.Write(temp.LastTimeAccPay);
            //今回手数料額（通常支払）
            writer.Write(temp.ThisTimeFeePayNrml);
            //今回値引額（通常支払）
            writer.Write(temp.ThisTimeDisPayNrml);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //今回繰越残高（買掛計）
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //相殺後外税対象額
            writer.Write(temp.ItdedOffsetOutTax);
            //相殺後内税対象額
            writer.Write(temp.ItdedOffsetInTax);
            //相殺後非課税対象額
            writer.Write(temp.ItdedOffsetTaxFree);
            //相殺後外税消費税
            writer.Write(temp.OffsetOutTax);
            //相殺後内税消費税
            writer.Write(temp.OffsetInTax);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            //今回仕入消費税
            writer.Write(temp.ThisStcPrcTax);
            //仕入外税対象額合計
            writer.Write(temp.TtlItdedStcOutTax);
            //仕入内税対象額合計
            writer.Write(temp.TtlItdedStcInTax);
            //仕入非課税対象額合計
            writer.Write(temp.TtlItdedStcTaxFree);
            //仕入外税額合計
            writer.Write(temp.TtlStockOuterTax);
            //仕入内税額合計
            writer.Write(temp.TtlStockInnerTax);
            //今回返品金額
            writer.Write(temp.ThisStckPricRgds);
            //今回返品消費税
            writer.Write(temp.ThisStcPrcTaxRgds);
            //返品外税対象額合計
            writer.Write(temp.TtlItdedRetOutTax);
            //返品内税対象額合計
            writer.Write(temp.TtlItdedRetInTax);
            //返品非課税対象額合計
            writer.Write(temp.TtlItdedRetTaxFree);
            //返品外税額合計
            writer.Write(temp.TtlRetOuterTax);
            //返品内税額合計
            writer.Write(temp.TtlRetInnerTax);
            //今回値引金額
            writer.Write(temp.ThisStckPricDis);
            //今回値引消費税
            writer.Write(temp.ThisStcPrcTaxDis);
            //値引外税対象額合計
            writer.Write(temp.TtlItdedDisOutTax);
            //値引内税対象額合計
            writer.Write(temp.TtlItdedDisInTax);
            //値引非課税対象額合計
            writer.Write(temp.TtlItdedDisTaxFree);
            //値引外税額合計
            writer.Write(temp.TtlDisOuterTax);
            //値引内税額合計
            writer.Write(temp.TtlDisInnerTax);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //仕入合計残高（買掛計）
            writer.Write(temp.StckTtlAccPayBalance);
            //仕入2回前残高（買掛計）
            writer.Write(temp.StckTtl2TmBfBlAccPay);
            //仕入3回前残高（買掛計）
            writer.Write(temp.StckTtl3TmBfBlAccPay);
            //月次更新実行年月日
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //月次更新開始年月日
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //前回月次更新年月日
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先消費税税率
            writer.Write(temp.SupplierConsTaxRate);
            //端数処理区分
            writer.Write(temp.FractionProcCd);

        }

        /// <summary>
        ///  SuplAccPayWorkインスタンス取得
        /// </summary>
        /// <returns>SuplAccPayWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccPayWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuplAccPayWork GetSuplAccPayWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuplAccPayWork temp = new SuplAccPayWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //前回買掛金額
            temp.LastTimeAccPay = reader.ReadInt64();
            //今回手数料額（通常支払）
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //今回値引額（通常支払）
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //今回繰越残高（買掛計）
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //相殺後外税対象額
            temp.ItdedOffsetOutTax = reader.ReadInt64();
            //相殺後内税対象額
            temp.ItdedOffsetInTax = reader.ReadInt64();
            //相殺後非課税対象額
            temp.ItdedOffsetTaxFree = reader.ReadInt64();
            //相殺後外税消費税
            temp.OffsetOutTax = reader.ReadInt64();
            //相殺後内税消費税
            temp.OffsetInTax = reader.ReadInt64();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //今回仕入消費税
            temp.ThisStcPrcTax = reader.ReadInt64();
            //仕入外税対象額合計
            temp.TtlItdedStcOutTax = reader.ReadInt64();
            //仕入内税対象額合計
            temp.TtlItdedStcInTax = reader.ReadInt64();
            //仕入非課税対象額合計
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //仕入外税額合計
            temp.TtlStockOuterTax = reader.ReadInt64();
            //仕入内税額合計
            temp.TtlStockInnerTax = reader.ReadInt64();
            //今回返品金額
            temp.ThisStckPricRgds = reader.ReadInt64();
            //今回返品消費税
            temp.ThisStcPrcTaxRgds = reader.ReadInt64();
            //返品外税対象額合計
            temp.TtlItdedRetOutTax = reader.ReadInt64();
            //返品内税対象額合計
            temp.TtlItdedRetInTax = reader.ReadInt64();
            //返品非課税対象額合計
            temp.TtlItdedRetTaxFree = reader.ReadInt64();
            //返品外税額合計
            temp.TtlRetOuterTax = reader.ReadInt64();
            //返品内税額合計
            temp.TtlRetInnerTax = reader.ReadInt64();
            //今回値引金額
            temp.ThisStckPricDis = reader.ReadInt64();
            //今回値引消費税
            temp.ThisStcPrcTaxDis = reader.ReadInt64();
            //値引外税対象額合計
            temp.TtlItdedDisOutTax = reader.ReadInt64();
            //値引内税対象額合計
            temp.TtlItdedDisInTax = reader.ReadInt64();
            //値引非課税対象額合計
            temp.TtlItdedDisTaxFree = reader.ReadInt64();
            //値引外税額合計
            temp.TtlDisOuterTax = reader.ReadInt64();
            //値引内税額合計
            temp.TtlDisInnerTax = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //仕入合計残高（買掛計）
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //仕入2回前残高（買掛計）
            temp.StckTtl2TmBfBlAccPay = reader.ReadInt64();
            //仕入3回前残高（買掛計）
            temp.StckTtl3TmBfBlAccPay = reader.ReadInt64();
            //月次更新実行年月日
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //月次更新開始年月日
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回月次更新年月日
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入先消費税税率
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>SuplAccPayWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccPayWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplAccPayWork temp = GetSuplAccPayWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SuplAccPayWork[])lst.ToArray(typeof(SuplAccPayWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
