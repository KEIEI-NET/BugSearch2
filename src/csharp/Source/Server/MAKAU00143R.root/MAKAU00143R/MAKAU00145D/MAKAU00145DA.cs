using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuplierPayWork
	/// <summary>
	///                      仕入先支払金額ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先支払金額ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成(追加項目あり 再生成時注意)</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/06/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SuplierPayWork : IFileHeader
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
		/// <remarks>支払先の親コード</remarks>
		private Int32 _payeeCode;

		/// <summary>支払先名称</summary>
		private string _payeeName = "";

		/// <summary>支払先名称2</summary>
		private string _payeeName2 = "";

		/// <summary>支払先略称</summary>
		private string _payeeSnm = "";

		/// <summary>実績拠点コード</summary>
		/// <remarks>実績集計の対象となっている拠点コード</remarks>
		private string _resultsSectCd = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>支払先の子コード（親レコードの場合０セット）</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先名1</summary>
		private string _supplierNm1 = "";

		/// <summary>仕入先名2</summary>
		private string _supplierNm2 = "";

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD 支払締を行なった日（相手先基準）</remarks>
		private DateTime _addUpDate;

		/// <summary>計上年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

		/// <summary>前回支払金額</summary>
		private Int64 _lastTimePayment;

		/// <summary>今回手数料額（通常支払）</summary>
		private Int64 _thisTimeFeePayNrml;

		/// <summary>今回値引額（通常支払）</summary>
		private Int64 _thisTimeDisPayNrml;

		/// <summary>今回支払金額（通常支払）</summary>
		/// <remarks>支払額の合計金額</remarks>
		private Int64 _thisTimePayNrml;

		/// <summary>今回繰越残高（支払計）</summary>
		/// <remarks>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</remarks>
		private Int64 _thisTimeTtlBlcPay;

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
		/// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入金額</remarks>
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
		private Int64 _ttlStockInnerTax;

		/// <summary>今回返品金額</summary>
		/// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</remarks>
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
		/// <remarks>掛仕入：内税商品返品の内税消費税額（値引含まず）</remarks>
		private Int64 _ttlRetInnerTax;

		/// <summary>今回値引金額</summary>
		/// <remarks>掛仕入：税抜きの仕入値引き金額</remarks>
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
		/// <remarks>掛仕入：内税商品値引の内税消費税額</remarks>
		private Int64 _ttlDisInnerTax;

		/// <summary>消費税調整額</summary>
		private Int64 _taxAdjust;

		/// <summary>残高調整額</summary>
		private Int64 _balanceAdjust;

		/// <summary>仕入合計残高（支払計）</summary>
		/// <remarks>今回分の支払金額 + 今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</remarks>
		private Int64 _stockTotalPayBalance;

		/// <summary>仕入2回前残高（支払計）</summary>
		private Int64 _stockTtl2TmBfBlPay;

		/// <summary>仕入3回前残高（支払計）</summary>
		private Int64 _stockTtl3TmBfBlPay;

		/// <summary>締次更新実行年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _cAddUpUpdExecDate;

		/// <summary>締次更新開始年月日</summary>
		/// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
		private DateTime _startCAddUpUpdDate;

		/// <summary>前回締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
		private DateTime _lastCAddUpUpdDate;

		/// <summary>仕入伝票枚数</summary>
		private Int32 _stockSlipCount;

		/// <summary>支払予定日</summary>
		/// <remarks>今回請求分の支払（入金）予定日</remarks>
		private DateTime _paymentSchedule;

		/// <summary>支払条件</summary>
		/// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
		private Int32 _paymentCond;

		/// <summary>仕入先消費税転嫁方式コード</summary>
		/// <remarks>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>仕入先消費税税率</summary>
		/// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
		private Double _supplierConsTaxRate;

		/// <summary>端数処理区分</summary>
		private Int32 _fractionProcCd;

        // 追加↓
        /// <summary>支払月区分コード</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _paymentMonthCode;

        /// <summary>支払日</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _paymentDay;

        /// <summary>仕入先締日</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _supplierTotalDay;

        /// <summary>相殺後外税消費税（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _offsetOutTaxSlip;

        /// <summary>相殺後外税消費税（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _offsetOutTaxDmd;

        /// <summary>仕入外税対象額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedStcOutTaxSlip;

        /// <summary>仕入外税対象額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedStcOutTaxDmd;

        /// <summary>仕入内税対象額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedStcInTaxSlip;

        /// <summary>仕入内税対象額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedStcInTaxDmd;

        /// <summary>仕入外税額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlStockOuterTaxSlip;

        /// <summary>仕入外税額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlStockOuterTaxDmd;

        /// <summary>返品外税対象額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedRetOutTaxSlip;

        /// <summary>返品外税対象額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedRetOutTaxDmd;

        /// <summary>返品内税対象額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedRetInTaxSlip;

        /// <summary>返品内税対象額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlItdedRetInTaxDmd;

        /// <summary>返品外税額合計（伝票）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlRetOuterTaxSlip;

        /// <summary>返品外税額合計（請求）</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _ttlRetOuterTaxDmd;

        /// <summary>消費税調整額</summary>
        /// <remarks>追加パラメータ（計算用）</remarks>
        private Int64 _taxAdust;

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>追加　0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>仕入時総額表示方法参照区分</summary>
        /// <remarks>追加　0:全体設定参照 1:仕入先参照</remarks>
        private Int32 _stckTtlAmntDspWayRef;

        /// <summary>仕入時消費税率参照区分コード</summary>
        /// <remarks>追加　0:全体設定より税率取得 1:仕入先マスタより税率取得</remarks>
        private Int32 _suppCTaxRateRefCd;

        /// <summary>更新ステータス</summary>
        /// <remarks>追加パラメータ</remarks>
        private Int32 _updateStatus;

        /// <summary>管理拠点コード</summary>
        /// <remarks>追加パラメータ</remarks>
        private string _mngSectionCode = "";

        /// <summary>仕入先区分</summary>
        /// <remarks>0:仕入先以外,1:仕入先</remarks>
        private Int32 _supplierDiv;
        // 追加↑

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

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// <value>支払先の親コード</value>
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

		/// public propaty name  :  ResultsSectCd
		/// <summary>実績拠点コードプロパティ</summary>
		/// <value>実績集計の対象となっている拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ResultsSectCd
		{
			get{return _resultsSectCd;}
			set{_resultsSectCd = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>支払先の子コード（親レコードの場合０セット）</value>
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
		/// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
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

		/// public propaty name  :  LastTimePayment
		/// <summary>前回支払金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回支払金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LastTimePayment
		{
			get{return _lastTimePayment;}
			set{_lastTimePayment = value;}
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

		/// public propaty name  :  ThisTimeTtlBlcPay
		/// <summary>今回繰越残高（支払計）プロパティ</summary>
		/// <value>今回繰越残高＝前回支払額 ー　今回支払額合計（通常支払）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回繰越残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ThisTimeTtlBlcPay
		{
			get{return _thisTimeTtlBlcPay;}
			set{_thisTimeTtlBlcPay = value;}
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
		/// <value>掛仕入：値引、返品を含まない 税抜きの仕入金額</value>
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
		/// <value>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</value>
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
		/// <value>掛仕入：内税商品返品の内税消費税額（値引含まず）</value>
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
		/// <value>掛仕入：税抜きの仕入値引き金額</value>
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
		/// <value>掛仕入：内税商品値引の内税消費税額</value>
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

		/// public propaty name  :  StockTotalPayBalance
		/// <summary>仕入合計残高（支払計）プロパティ</summary>
		/// <value>今回分の支払金額 + 今回繰越残高（支払計）＋今回純仕入金額＋今回純消費税＋残高調整＋消費税調整額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入合計残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTotalPayBalance
		{
			get{return _stockTotalPayBalance;}
			set{_stockTotalPayBalance = value;}
		}

		/// public propaty name  :  StockTtl2TmBfBlPay
		/// <summary>仕入2回前残高（支払計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入2回前残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtl2TmBfBlPay
		{
			get{return _stockTtl2TmBfBlPay;}
			set{_stockTtl2TmBfBlPay = value;}
		}

		/// public propaty name  :  StockTtl3TmBfBlPay
		/// <summary>仕入3回前残高（支払計）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入3回前残高（支払計）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockTtl3TmBfBlPay
		{
			get{return _stockTtl3TmBfBlPay;}
			set{_stockTtl3TmBfBlPay = value;}
		}

		/// public propaty name  :  CAddUpUpdExecDate
		/// <summary>締次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CAddUpUpdExecDate
		{
			get{return _cAddUpUpdExecDate;}
			set{_cAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  StartCAddUpUpdDate
		/// <summary>締次更新開始年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締次更新開始年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StartCAddUpUpdDate
		{
			get{return _startCAddUpUpdDate;}
			set{_startCAddUpUpdDate = value;}
		}

		/// public propaty name  :  LastCAddUpUpdDate
		/// <summary>前回締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前回締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastCAddUpUpdDate
		{
			get{return _lastCAddUpUpdDate;}
			set{_lastCAddUpUpdDate = value;}
		}

		/// public propaty name  :  StockSlipCount
		/// <summary>仕入伝票枚数プロパティ</summary>
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

		/// public propaty name  :  PaymentSchedule
		/// <summary>支払予定日プロパティ</summary>
		/// <value>今回請求分の支払（入金）予定日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PaymentSchedule
		{
			get{return _paymentSchedule;}
			set{_paymentSchedule = value;}
		}

		/// public propaty name  :  PaymentCond
		/// <summary>支払条件プロパティ</summary>
		/// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払条件プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaymentCond
		{
			get{return _paymentCond;}
			set{_paymentCond = value;}
		}

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
		/// <value>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</value>
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
		/// <value>請求転嫁消費税を算出する場合に使用</value>
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

        //追加↓
        /// public propaty name  :  PaymentMonthCode
        /// <summary>支払先月区分コードプロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMonthCode
        {
            get { return _paymentMonthCode; }
            set { _paymentMonthCode = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>支払日プロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  SupplierTotalDay
        /// <summary>仕入先締日プロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay
        {
            get { return _supplierTotalDay; }
            set { _supplierTotalDay = value; }
        }

        /// public propaty name  :  OffsetOutTaxSlip
        /// <summary>相殺後外税消費税（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetOutTaxSlip
        {
            get { return _offsetOutTaxSlip; }
            set { _offsetOutTaxSlip = value; }
        }

        /// public propaty name  :  OffsetOutTaxDmd
        /// <summary>相殺後外税消費税（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後外税消費税（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OffsetOutTaxDmd
        {
            get { return _offsetOutTaxDmd; }
            set { _offsetOutTaxDmd = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTaxSlip
        /// <summary>仕入外税対象額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税対象額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTaxSlip
        {
            get { return _ttlItdedStcOutTaxSlip; }
            set { _ttlItdedStcOutTaxSlip = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTaxDmd
        /// <summary>仕入外税対象額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税対象額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTaxDmd
        {
            get { return _ttlItdedStcOutTaxDmd; }
            set { _ttlItdedStcOutTaxDmd = value; }
        }

        /// public propaty name  :  TtlItdedStcInTaxSlip
        /// <summary>仕入内税対象額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税対象額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcInTaxSlip
        {
            get { return _ttlItdedStcInTaxSlip; }
            set { _ttlItdedStcInTaxSlip = value; }
        }

        /// public propaty name  :  TtlItdedStcInTaxDmd
        /// <summary>仕入内税対象額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入内税対象額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedStcInTaxDmd
        {
            get { return _ttlItdedStcInTaxDmd; }
            set { _ttlItdedStcInTaxDmd = value; }
        }

        /// public propaty name  :  TtlStockOuterTaxSlip
        /// <summary>仕入外税額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlStockOuterTaxSlip
        {
            get { return _ttlStockOuterTaxSlip; }
            set { _ttlStockOuterTaxSlip = value; }
        }

        /// public propaty name  :  TtlStockOuterTaxDmd
        /// <summary>仕入外税額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入外税額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlStockOuterTaxDmd
        {
            get { return _ttlStockOuterTaxDmd; }
            set { _ttlStockOuterTaxDmd = value; }
        }

        /// public propaty name  :  TtlItdedRetOutTaxSlip
        /// <summary>返品外税対象額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetOutTaxSlip
        {
            get { return _ttlItdedRetOutTaxSlip; }
            set { _ttlItdedRetOutTaxSlip = value; }
        }

        /// public propaty name  :  TtlItdedRetOutTaxDmd
        /// <summary>返品外税対象額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税対象額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetOutTaxDmd
        {
            get { return _ttlItdedRetOutTaxDmd; }
            set { _ttlItdedRetOutTaxDmd = value; }
        }

        /// public propaty name  :  TtlItdedRetInTaxSlip
        /// <summary>返品内税対象額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetInTaxSlip
        {
            get { return _ttlItdedRetInTaxSlip; }
            set { _ttlItdedRetInTaxSlip = value; }
        }

        /// public propaty name  :  TtlItdedRetInTaxDmd
        /// <summary>返品内税対象額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税対象額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlItdedRetInTaxDmd
        {
            get { return _ttlItdedRetInTaxDmd; }
            set { _ttlItdedRetInTaxDmd = value; }
        }

        /// public propaty name  :  TtlRetOuterTaxSlip
        /// <summary>返品外税額合計（伝票）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税額合計（伝票）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlRetOuterTaxSlip
        {
            get { return _ttlRetOuterTaxSlip; }
            set { _ttlRetOuterTaxSlip = value; }
        }

        /// public propaty name  :  TtlRetOuterTaxDmd
        /// <summary>返品外税額合計（請求）プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品外税額合計（請求）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlRetOuterTaxDmd
        {
            get { return _ttlRetOuterTaxDmd; }
            set { _ttlRetOuterTaxDmd = value; }
        }

        /// public propaty name  :  TaxAdust
        /// <summary>消費税調整額プロパティ</summary>
        /// <value>追加パラメータ（計算用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税調整額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TaxAdust
        {
            get { return _taxAdust; }
            set { _taxAdust = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>仕入先総額表示方法区分プロパティ</summary>
        /// <value>追加　0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  StckTtlAmntDspWayRef
        /// <summary>仕入時総額表示方法参照区分プロパティ</summary>
        /// <value>追加　0:全体設定参照 1:仕入先参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入時総額表示方法参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckTtlAmntDspWayRef
        {
            get { return _stckTtlAmntDspWayRef; }
            set { _stckTtlAmntDspWayRef = value; }
        }

        /// public propaty name  :  SuppCTaxRateRefCd
        /// <summary>仕入時消費税率参照区分コードプロパティ</summary>
        /// <value>追加　0:全体設定より税率取得 1:仕入先マスタより税率取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入時消費税率参照区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxRateRefCd
        {
            get { return _suppCTaxRateRefCd; }
            set { _suppCTaxRateRefCd = value; }
        }

        /// public propaty name  :  UpdateStatus
        /// <summary>更新ステータスプロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateStatus
        {
            get { return _updateStatus; }
            set { _updateStatus = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// <value>追加パラメータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  SupplierDiv
        /// <summary>仕入先区分プロパティ</summary>
        /// <value>0:仕入先以外,1:仕入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierDiv
        {
            get { return _supplierDiv; }
            set { _supplierDiv = value; }
        }
        //追加↑

		/// <summary>
		/// 仕入先支払金額ワークコンストラクタ
		/// </summary>
		/// <returns>SuplierPayWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuplierPayWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuplierPayWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuplierPayWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuplierPayWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuplierPayWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplierPayWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplierPayWork || graph is ArrayList || graph is SuplierPayWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuplierPayWork).FullName));

            if (graph != null && graph is SuplierPayWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplierPayWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplierPayWork[])graph).Length;
            }
            else if (graph is SuplierPayWork)
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
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //実績拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
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
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //前回支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //今回手数料額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //今回値引額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //今回繰越残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcPay
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
            //仕入合計残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //仕入2回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //仕入3回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //支払予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSchedule
            //支払条件
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //仕入先消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplierPayWork)
            {
                SuplierPayWork temp = (SuplierPayWork)graph;

                SetSuplierPayWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplierPayWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplierPayWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplierPayWork temp in lst)
                {
                    SetSuplierPayWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplierPayWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 67;

        /// <summary>
        ///  SuplierPayWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuplierPayWork(System.IO.BinaryWriter writer, SuplierPayWork temp)
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
            //実績拠点コード
            writer.Write(temp.ResultsSectCd);
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
            //前回支払金額
            writer.Write(temp.LastTimePayment);
            //今回手数料額（通常支払）
            writer.Write(temp.ThisTimeFeePayNrml);
            //今回値引額（通常支払）
            writer.Write(temp.ThisTimeDisPayNrml);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //今回繰越残高（支払計）
            writer.Write(temp.ThisTimeTtlBlcPay);
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
            //仕入合計残高（支払計）
            writer.Write(temp.StockTotalPayBalance);
            //仕入2回前残高（支払計）
            writer.Write(temp.StockTtl2TmBfBlPay);
            //仕入3回前残高（支払計）
            writer.Write(temp.StockTtl3TmBfBlPay);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //支払予定日
            writer.Write((Int64)temp.PaymentSchedule.Ticks);
            //支払条件
            writer.Write(temp.PaymentCond);
            //仕入先消費税転嫁方式コード
            writer.Write(temp.SuppCTaxLayCd);
            //仕入先消費税税率
            writer.Write(temp.SupplierConsTaxRate);
            //端数処理区分
            writer.Write(temp.FractionProcCd);

        }

        /// <summary>
        ///  SuplierPayWorkインスタンス取得
        /// </summary>
        /// <returns>SuplierPayWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuplierPayWork GetSuplierPayWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuplierPayWork temp = new SuplierPayWork();

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
            //実績拠点コード
            temp.ResultsSectCd = reader.ReadString();
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
            //前回支払金額
            temp.LastTimePayment = reader.ReadInt64();
            //今回手数料額（通常支払）
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //今回値引額（通常支払）
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //今回繰越残高（支払計）
            temp.ThisTimeTtlBlcPay = reader.ReadInt64();
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
            //仕入合計残高（支払計）
            temp.StockTotalPayBalance = reader.ReadInt64();
            //仕入2回前残高（支払計）
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //仕入3回前残高（支払計）
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //締次更新実行年月日
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回締次更新年月日
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //支払予定日
            temp.PaymentSchedule = new DateTime(reader.ReadInt64());
            //支払条件
            temp.PaymentCond = reader.ReadInt32();
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
        /// <returns>SuplierPayWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplierPayWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplierPayWork temp = GetSuplierPayWork(reader, serInfo);
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
                    retValue = (SuplierPayWork[])lst.ToArray(typeof(SuplierPayWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
