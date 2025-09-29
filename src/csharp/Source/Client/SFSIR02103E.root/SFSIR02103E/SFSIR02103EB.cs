using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchSuplierPayRet
    /// <summary>
    ///                      検索用仕入先支払金額クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   検索用仕入先支払金額クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/2/8</br>
    /// <br>Genarated Date   :   2007/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/5/29  木村　武正</br>
    /// <br>                 :   仕入先支払金額クラスのレイアウトが</br>
    /// <br>                 :   変更になったため、修正</br>
    /// <br>Update Note      :   2007/09/05  疋田　勇人</br>
    /// <br>                 :   DC.NS用に項目追加</br>
    /// <br>Update Note      :   2008/07/08  忍　幸史</br>
    /// <br>                 :   Partsman用に変更</br>
    /// </remarks>
    public class SearchSuplierPayRet
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

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>得意先コード</summary>
        //private Int32 _customerCode;

        ///// <summary>得意先名称</summary>
        //private string _customerName = "";

        ///// <summary>得意先名称2</summary>
        //private string _customerName2 = "";

        ///// <summary>得意先略称</summary>
        //private string _customerSnm = "";
        /// <summary>仕入先コード</summary>
        private Int32 _supplierCode;

        /// <summary>仕入先名称</summary>
        private string _supplierName = "";

        /// <summary>仕入先名称2</summary>
        private string _supplierName2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 支払締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>前回支払金額</summary>
        private Int64 _lastTimePayment;

        /// <summary>今回支払金額（通常支払）</summary>
        private Int64 _thisTimePayNrml;

        /// <summary>今回手数料額（通常支払）</summary>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>今回値引額（通常支払）</summary>
        private Int64 _thisTimeDisPayNrml;

        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>今回リベート額（通常支払）</summary>
        private Int64 _thisTimeRbtPayNrml;
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/

        /// <summary>今回繰越残高（支払計）</summary>
        /// <remarks>今回繰越残高＝前回支払額－今回支払額（支払計）</remarks>
        private Int64 _thisTimeTtlBlcPay;

        /// <summary>今回純仕入金額</summary>
        /// <remarks>純仕入 = 仕入 - 返品</remarks>
        private Int64 _thisNetStckPrice;

        /// <summary>今回純仕入消費税</summary>
        /// <remarks>純仕入 = 仕入 - 返品</remarks>
        private Int64 _thisNetStcPrcTax;

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
        /// <remarks>今回仕入金額＝仕入外税対象額＋仕入内税対象額＋仕入非課税対象額</remarks>
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
        /// <remarks>今回返品金額＝返品外税対象額＋返品内税対象額＋返品非課税対象額</remarks>
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
        private Int64 _ttlRetInnerTax;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入先消費税税率</summary>
        /// <remarks>請求転嫁消費税を算出する場合に使用</remarks>
        private Double _supplierConsTaxRate;

        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;

        /// <summary>仕入合計残高（支払計）</summary>
        /// <remarks>今回分の支払金額</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>仕入2回前残高（支払計）</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>仕入3回前残高（支払計）</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>精算処理通番</summary>
        private Int32 _supProcNum;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>日付範囲（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _startDateSpan;

        /// <summary>日付範囲（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _endDateSpan;

        /// <summary>今回支払計</summary>
        /// <remarks>今回支払計＝今回支払金額(通常支払)＋今回手数料額(通常支払)＋今回値引額(通常支払)＋今回リベート額(通常支払)</remarks>
        private Int64 _thisTimePaymentMeter;

        /// <summary>相殺後仕入計</summary>
        /// <remarks>相殺後仕入計＝相殺後外税対象額＋相殺後内税対象額＋相殺後非課税対象額</remarks>
        private Int64 _stcMtrAfOffset;

        /// <summary>相殺後仕入消費税計</summary>
        /// <remarks>相殺後仕入消費税計＝相殺後外税消費税＋相殺後内税消費税</remarks>
        private Int64 _stcConsTaxMtrAfOffset;

        // 2007.09.05 hikita add start ------------------------------------------>>
        /// <summary>残高合計</summary>
        /// <remarks>残高合計＝仕入3回前残高＋仕入2回前残高 + 今回繰越残高</remarks>
        private Int64 _blnceTtl;

        /// <summary>差引残高</summary>
        /// <remarks>差引残高＝残高合計 + 仕入合計残高</remarks>
        private Int64 _balance;
        // 2007.09.05 hikita add end --------------------------------------------<< 

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";

        /// <summary>仕入先消費税転嫁方式名称</summary>
        /// <remarks>伝票単位、明細単位、請求単位</remarks>
        private string _suppCTaxLayMethodNm = "";

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>相殺後今回仕入消費税額</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisStockTax;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// public propaty name  :  CustomerCode
        ///// <summary>得意先コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerCode
        //{
        //    get { return _customerCode; }
        //    set { _customerCode = value; }
        //}

        ///// public propaty name  :  CustomerName
        ///// <summary>得意先名称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustomerName
        //{
        //    get { return _customerName; }
        //    set { _customerName = value; }
        //}

        ///// public propaty name  :  CustomerName2
        ///// <summary>得意先名称2プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先名称2プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustomerName2
        //{
        //    get { return _customerName2; }
        //    set { _customerName2 = value; }
        //}

        ///// public propaty name  :  CustomerSnm
        ///// <summary>得意先略称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先略称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustomerSnm
        //{
        //    get { return _customerSnm; }
        //    set { _customerSnm = value; }
        //}
        /// public property name  :  SupplierCode
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        /// public property name  :  SupplierName
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        /// public property name  :  SupplierName2
        /// <summary>仕入先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名称2プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierName2
        {
            get { return _supplierName2; }
            set { _supplierName2 = value; }
        }

        /// public property name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
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
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
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
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpDateJpFormal
        /// <summary>計上年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateJpInFormal
        /// <summary>計上年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdFormal
        /// <summary>計上年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdInFormal
        /// <summary>計上年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate); }
            set { }
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
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth); }
            set { }
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
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>今回支払金額（通常支払）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回支払金額（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
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
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
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
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  ThisTimeRbtPayNrml
        /// <summary>今回リベート額（通常支払）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回リベート額（通常支払）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeRbtPayNrml
        {
            get { return _thisTimeRbtPayNrml; }
            set { _thisTimeRbtPayNrml = value; }
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  ThisTimeTtlBlcPay
        /// <summary>今回繰越残高（支払計）プロパティ</summary>
        /// <value>今回繰越残高＝前回支払額－今回支払額（支払計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcPay
        {
            get { return _thisTimeTtlBlcPay; }
            set { _thisTimeTtlBlcPay = value; }
        }

        /// public propaty name  :  ThisNetStckPrice
        /// <summary>今回純仕入金額プロパティ</summary>
        /// <value>純仕入 = 仕入 - 返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回純仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisNetStckPrice
        {
            get { return _thisNetStckPrice; }
            set { _thisNetStckPrice = value; }
        }

        /// public propaty name  :  ThisNetStcPrcTax
        /// <summary>今回純仕入消費税プロパティ</summary>
        /// <value>純仕入 = 仕入 - 返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回純仕入消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisNetStcPrcTax
        {
            get { return _thisNetStcPrcTax; }
            set { _thisNetStcPrcTax = value; }
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
            get { return _itdedOffsetOutTax; }
            set { _itdedOffsetOutTax = value; }
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
            get { return _itdedOffsetInTax; }
            set { _itdedOffsetInTax = value; }
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
            get { return _itdedOffsetTaxFree; }
            set { _itdedOffsetTaxFree = value; }
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
            get { return _offsetOutTax; }
            set { _offsetOutTax = value; }
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
            get { return _offsetInTax; }
            set { _offsetInTax = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>今回仕入金額＝仕入外税対象額＋仕入内税対象額＋仕入非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回仕入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
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
            get { return _thisStcPrcTax; }
            set { _thisStcPrcTax = value; }
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
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
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
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
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
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
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
            get { return _ttlStockOuterTax; }
            set { _ttlStockOuterTax = value; }
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
            get { return _ttlStockInnerTax; }
            set { _ttlStockInnerTax = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>今回返品金額プロパティ</summary>
        /// <value>今回返品金額＝返品外税対象額＋返品内税対象額＋返品非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricRgds
        {
            get { return _thisStckPricRgds; }
            set { _thisStckPricRgds = value; }
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
            get { return _thisStcPrcTaxRgds; }
            set { _thisStcPrcTaxRgds = value; }
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
            get { return _ttlItdedRetOutTax; }
            set { _ttlItdedRetOutTax = value; }
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
            get { return _ttlItdedRetInTax; }
            set { _ttlItdedRetInTax = value; }
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
            get { return _ttlItdedRetTaxFree; }
            set { _ttlItdedRetTaxFree = value; }
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
            get { return _ttlRetOuterTax; }
            set { _ttlRetOuterTax = value; }
        }

        /// public propaty name  :  TtlRetInnerTax
        /// <summary>返品内税額合計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品内税額合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TtlRetInnerTax
        {
            get { return _ttlRetInnerTax; }
            set { _ttlRetInnerTax = value; }
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
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
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
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
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
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>仕入合計残高（支払計）プロパティ</summary>
        /// <value>今回分の支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入合計残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
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
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
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
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
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
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDateJpFormal
        /// <summary>締次更新実行年月日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateJpInFormal
        /// <summary>締次更新実行年月日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdFormal
        /// <summary>締次更新実行年月日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdInFormal
        /// <summary>締次更新実行年月日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  SupProcNum
        /// <summary>精算処理通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   精算処理通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupProcNum
        {
            get { return _supProcNum; }
            set { _supProcNum = value; }
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
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDateJpFormal
        /// <summary>締次更新開始年月日 和暦プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateJpInFormal
        /// <summary>締次更新開始年月日 和暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdFormal
        /// <summary>締次更新開始年月日 西暦プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdInFormal
        /// <summary>締次更新開始年月日 西暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _startCAddUpUpdDate); }
            set { }
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
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDateJpFormal
        /// <summary>前回締次更新年月日 和暦プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateJpInFormal
        /// <summary>前回締次更新年月日 和暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdFormal
        /// <summary>前回締次更新年月日 西暦プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdInFormal
        /// <summary>前回締次更新年月日 西暦(略)プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartDateSpan
        /// <summary>日付範囲（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付範囲（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartDateSpan
        {
            get { return _startDateSpan; }
            set { _startDateSpan = value; }
        }

        /// public propaty name  :  EndDateSpan
        /// <summary>日付範囲（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付範囲（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndDateSpan
        {
            get { return _endDateSpan; }
            set { _endDateSpan = value; }
        }

        /// public propaty name  :  ThisTimePaymentMeter
        /// <summary>今回支払計プロパティ</summary>
        /// <value>今回支払計＝今回支払金額(通常支払)＋今回手数料額(通常支払)＋今回値引額(通常支払)＋今回リベート額(通常支払)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回支払計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimePaymentMeter
        {
            get { return _thisTimePaymentMeter; }
            set { _thisTimePaymentMeter = value; }
        }

        /// public propaty name  :  StcMtrAfOffset
        /// <summary>相殺後仕入計プロパティ</summary>
        /// <value>相殺後仕入計＝相殺後外税対象額＋相殺後内税対象額＋相殺後非課税対象額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後仕入計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StcMtrAfOffset
        {
            get { return _stcMtrAfOffset; }
            set { _stcMtrAfOffset = value; }
        }

        /// public propaty name  :  StcConsTaxMtrAfOffset
        /// <summary>相殺後仕入消費税計プロパティ</summary>
        /// <value>相殺後仕入消費税計＝相殺後外税消費税＋相殺後内税消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後仕入消費税計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StcConsTaxMtrAfOffset
        {
            get { return _stcConsTaxMtrAfOffset; }
            set { _stcConsTaxMtrAfOffset = value; }
        }

        /// public propaty name  :  BlnceTtl  
        /// <summary>残高合計プロパティ</summary>
        /// <value>残高合計＝仕入3回前残高＋仕入2回前残高 + 前回支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BlnceTtl
        {
            get { return _blnceTtl; }
            set { _blnceTtl = value; }
        }

        /// public propaty name  :  Balance  
        /// <summary>差引残高プロパティ</summary>
        /// <value>差引残高＝残高合計 + 今回支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   差引残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Balance
        {
            get { return _balance; }
            set { _balance = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>仕入先消費税転嫁方式名称プロパティ</summary>
        /// <value>伝票単位、明細単位、請求単位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税転嫁方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
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
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
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
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 検索用仕入先支払金額クラスコンストラクタ
        /// </summary>
        /// <returns>SearchSuplierPayRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchSuplierPayRet()
        {
        }

        /// <summary>
        /// 検索用仕入先支払金額クラスコンストラクタ
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
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="supplierName">仕入先名称</param>
        /// <param name="supplierName2">仕入先名称2</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="payeeName">支払先名称</param>
        /// <param name="payeeName2">支払先名称2</param>
        /// <param name="payeeSnm">支払先略称</param>
        /// <param name="addUpDate">計上年月日(YYYYMMDD 支払締を行なった日（相手先基準）)</param>
        /// <param name="addUpYearMonth">計上年月(YYYYMM)</param>
        /// <param name="lastTimePayment">前回支払金額</param>
        /// <param name="thisTimePayNrml">今回支払金額（通常支払）</param>
        /// <param name="thisTimeFeePayNrml">今回手数料額（通常支払）</param>
        /// <param name="thisTimeDisPayNrml">今回値引額（通常支払）</param>
        /// <param name="thisTimeTtlBlcPay">今回繰越残高（支払計）(今回繰越残高＝前回支払額－今回支払額（支払計）)</param>
        /// <param name="thisNetStckPrice">今回純仕入金額(純仕入 = 仕入 - 返品)</param>
        /// <param name="thisNetStcPrcTax">今回純仕入消費税(純仕入 = 仕入 - 返品)</param>
        /// <param name="itdedOffsetOutTax">相殺後外税対象額(相殺用：外税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetInTax">相殺後内税対象額(相殺用：内税額（税抜き）の集計)</param>
        /// <param name="itdedOffsetTaxFree">相殺後非課税対象額(相殺用：非課税額の集計)</param>
        /// <param name="offsetOutTax">相殺後外税消費税(相殺用：外税消費税の集計　（請求転嫁時は、課税対象額から算出）)</param>
        /// <param name="offsetInTax">相殺後内税消費税(相殺用：内税消費税の集計)</param>
        /// <param name="thisTimeStockPrice">今回仕入金額(今回仕入金額＝仕入外税対象額＋仕入内税対象額＋仕入非課税対象額)</param>
        /// <param name="thisStcPrcTax">今回仕入消費税(今回仕入消費税＝仕入外税額合計＋仕入内税額合計)</param>
        /// <param name="ttlItdedStcOutTax">仕入外税対象額合計</param>
        /// <param name="ttlItdedStcInTax">仕入内税対象額合計</param>
        /// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計</param>
        /// <param name="ttlStockOuterTax">仕入外税額合計</param>
        /// <param name="ttlStockInnerTax">仕入内税額合計</param>
        /// <param name="thisStckPricRgds">今回返品金額(今回返品金額＝返品外税対象額＋返品内税対象額＋返品非課税対象額)</param>
        /// <param name="thisStcPrcTaxRgds">今回返品消費税(今回返品消費税＝返品外税額合計＋返品内税額合計)</param>
        /// <param name="ttlItdedRetOutTax">返品外税対象額合計</param>
        /// <param name="ttlItdedRetInTax">返品内税対象額合計</param>
        /// <param name="ttlItdedRetTaxFree">返品非課税対象額合計</param>
        /// <param name="ttlRetOuterTax">返品外税額合計</param>
        /// <param name="ttlRetInnerTax">返品内税額合計</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード(端数処理区分設定マスタ参照 0:伝票単位1:明細単位2:請求時一括)</param>
        /// <param name="supplierConsTaxRate">仕入先消費税税率(請求転嫁消費税を算出する場合に使用)</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="stockTotalPayBalance">仕入合計残高（支払計）(今回分の支払金額)</param>
        /// <param name="stockTtl2TmBfBlPay">仕入2回前残高（支払計）</param>
        /// <param name="stockTtl3TmBfBlPay">仕入3回前残高（支払計）</param>
        /// <param name="cAddUpUpdExecDate">締次更新実行年月日(YYYYMMDD)</param>
        /// <param name="supProcNum">精算処理通番</param>
        /// <param name="startCAddUpUpdDate">締次更新開始年月日("YYYYMMDD"  締次更新対象となる開始年月日)</param>
        /// <param name="lastCAddUpUpdDate">前回締次更新年月日("YYYYMMDD"  前回締次更新対象となった年月日)</param>
        /// <param name="startDateSpan">日付範囲（開始）(YYYYMMDD)</param>
        /// <param name="endDateSpan">日付範囲（終了）(YYYYMMDD)</param>
        /// <param name="thisTimePaymentMeter">今回支払計(今回支払計＝今回支払金額(通常支払)＋今回手数料額(通常支払)＋今回値引額(通常支払)＋今回リベート額(通常支払))</param>
        /// <param name="stcMtrAfOffset">相殺後仕入計(相殺後仕入計＝相殺後外税対象額＋相殺後内税対象額＋相殺後非課税対象額)</param>
        /// <param name="stcConsTaxMtrAfOffset">相殺後仕入消費税計(相殺後仕入消費税計＝相殺後外税消費税＋相殺後内税消費税)</param>
        /// <param name="blnceTtl">残高合計＝仕入3回前残高＋仕入2回前残高 + 前回支払金額</param>
        /// <param name="balance">差引残高＝残高合計 + 今回支払金額</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
        /// <param name="ofsThisTimeStock">相殺後今回仕入金額</param>
        /// <param name="ofsThisStockTax">相殺後今回仕入消費税額</param>
        /// <returns>SearchSuplierPayRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        //public SearchSuplierPayRet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimePayNrml, Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimeRbtPayNrml, Int64 thisTimeTtlBlcPay, Int64 thisNetStckPrice, Int64 thisNetStcPrcTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, DateTime cAddUpUpdExecDate, Int32 supProcNum, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 startDateSpan, Int32 endDateSpan, Int64 thisTimePaymentMeter, Int64 stcMtrAfOffset, Int64 stcConsTaxMtrAfOffset, Int64 blnceTtl, Int64 balance, string enterpriseName, string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm)
        public SearchSuplierPayRet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, 
                                   Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, 
                                   string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode,
                                   Int32 supplierCode, string supplierName, string supplierName2,
                                   string supplierSnm, Int32 payeeCode, string payeeName, 
                                   string payeeName2, string payeeSnm, DateTime addUpDate, 
                                   DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimePayNrml, 
                                   Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimeTtlBlcPay, 
                                   Int64 thisNetStckPrice, Int64 thisNetStcPrcTax, Int64 itdedOffsetOutTax, 
                                   Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, 
                                   Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, 
                                   Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, 
                                   Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, 
                                   Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, 
                                   Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, 
                                   Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, 
                                   Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, 
                                   DateTime cAddUpUpdExecDate, Int32 supProcNum, DateTime startCAddUpUpdDate, 
                                   DateTime lastCAddUpUpdDate, Int32 startDateSpan, Int32 endDateSpan, 
                                   Int64 thisTimePaymentMeter, Int64 stcMtrAfOffset, Int64 stcConsTaxMtrAfOffset, 
                                   Int64 blnceTtl, Int64 balance, string enterpriseName, 
                                   string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm,
                                   Int64 ofsThisTimeStock, Int64 ofsThisStockTax)
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
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
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //this._customerCode = customerCode;
            //this._customerName = customerName;
            //this._customerName2 = customerName2;
            //this._customerSnm = customerSnm;
            this._supplierCode = supplierCode;
            this._supplierName = supplierName;
            this._supplierName2 = supplierName2;
            this._supplierSnm = supplierSnm;
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimePayment = lastTimePayment;
            this._thisTimePayNrml = thisTimePayNrml;
            this._thisTimeFeePayNrml = thisTimeFeePayNrml;
            this._thisTimeDisPayNrml = thisTimeDisPayNrml;
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            this._thisTimeRbtPayNrml = thisTimeRbtPayNrml;
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
            this._thisNetStckPrice = thisNetStckPrice;
            this._thisNetStcPrcTax = thisNetStcPrcTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._thisTimeStockPrice = thisTimeStockPrice;
            this._thisStcPrcTax = thisStcPrcTax;
            this._ttlItdedStcOutTax = ttlItdedStcOutTax;
            this._ttlItdedStcInTax = ttlItdedStcInTax;
            this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
            this._ttlStockOuterTax = ttlStockOuterTax;
            this._ttlStockInnerTax = ttlStockInnerTax;
            this._thisStckPricRgds = thisStckPricRgds;
            this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._stockTotalPayBalance = stockTotalPayBalance;
            this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
            this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this._supProcNum = supProcNum;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._startDateSpan = startDateSpan;
            this._endDateSpan = endDateSpan;
            this._thisTimePaymentMeter = thisTimePaymentMeter;
            this._stcMtrAfOffset = stcMtrAfOffset;
            this._stcConsTaxMtrAfOffset = stcConsTaxMtrAfOffset;
            this._blnceTtl = blnceTtl;
            this._balance = balance;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            this._ofsThisTimeStock = ofsThisTimeStock;
            this._ofsThisStockTax = ofsThisStockTax;
        }

        /// <summary>
        /// 検索用仕入先支払金額クラス複製処理
        /// </summary>
        /// <returns>SearchSuplierPayRetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSearchSuplierPayRetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchSuplierPayRet Clone()
        {
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchSuplierPayRet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._thisTimePayNrml, this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimeRbtPayNrml, this._thisTimeTtlBlcPay, this._thisNetStckPrice, this._thisNetStcPrcTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._cAddUpUpdExecDate, this._supProcNum, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._startDateSpan, this._endDateSpan, this._thisTimePaymentMeter, this._stcMtrAfOffset, this._stcConsTaxMtrAfOffset, this._blnceTtl, this._balance, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm);
            return new SearchSuplierPayRet(this._createDateTime, this._updateDateTime, this._enterpriseCode, 
                                           this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, 
                                           this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, 
                                           this._supplierCode, this._supplierName, this._supplierName2, 
                                           this._supplierSnm, this._payeeCode, this._payeeName, 
                                           this._payeeName2, this._payeeSnm, this._addUpDate, 
                                           this._addUpYearMonth, this._lastTimePayment, this._thisTimePayNrml, 
                                           this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimeTtlBlcPay, 
                                           this._thisNetStckPrice, this._thisNetStcPrcTax, this._itdedOffsetOutTax, 
                                           this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, 
                                           this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, 
                                           this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, 
                                           this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, 
                                           this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, 
                                           this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, 
                                           this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, 
                                           this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, 
                                           this._cAddUpUpdExecDate, this._supProcNum, this._startCAddUpUpdDate, 
                                           this._lastCAddUpUpdDate, this._startDateSpan, this._endDateSpan, 
                                           this._thisTimePaymentMeter, this._stcMtrAfOffset, this._stcConsTaxMtrAfOffset, 
                                           this._blnceTtl, this._balance, this._enterpriseName, 
                                           this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm,
                                           this._ofsThisTimeStock, this._ofsThisStockTax);
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 検索用仕入先支払金額クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchSuplierPayRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SearchSuplierPayRet target)
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
                // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                 //&& (this.CustomerCode == target.CustomerCode)
                 //&& (this.CustomerName == target.CustomerName)
                 //&& (this.CustomerName2 == target.CustomerName2)
                 //&& (this.CustomerSnm == target.CustomerSnm)
                 && (this.SupplierCode == target.SupplierCode)
                 && (this.SupplierName == target.SupplierName)
                 && (this.SupplierName2 == target.SupplierName2)
                 && (this.SupplierSnm == target.SupplierSnm)
                // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimePayment == target.LastTimePayment)
                 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
                 && (this.ThisTimeFeePayNrml == target.ThisTimeFeePayNrml)
                 && (this.ThisTimeDisPayNrml == target.ThisTimeDisPayNrml)
                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                && (this.ThisTimeRbtPayNrml == target.ThisTimeRbtPayNrml)
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
                 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
                 && (this.ThisNetStckPrice == target.ThisNetStckPrice)
                 && (this.ThisNetStcPrcTax == target.ThisNetStcPrcTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ThisTimeStockPrice == target.ThisTimeStockPrice)
                 && (this.ThisStcPrcTax == target.ThisStcPrcTax)
                 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
                 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
                 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
                 && (this.TtlStockOuterTax == target.TtlStockOuterTax)
                 && (this.TtlStockInnerTax == target.TtlStockInnerTax)
                 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
                 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
                 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
                 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.SupProcNum == target.SupProcNum)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.StartDateSpan == target.StartDateSpan)
                 && (this.EndDateSpan == target.EndDateSpan)
                 && (this.ThisTimePaymentMeter == target.ThisTimePaymentMeter)
                 && (this.StcMtrAfOffset == target.StcMtrAfOffset)
                 && (this.StcConsTaxMtrAfOffset == target.StcConsTaxMtrAfOffset)
                 && (this.BlnceTtl == target.BlnceTtl)
                 && (this.Balance == target.Balance)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                 && (this.OfsThisTimeStock == target.OfsThisTimeStock)
                 && (this.OfsThisStockTax == target.OfsThisStockTax)
                 );
        }

        /// <summary>
        /// 検索用仕入先支払金額クラス比較処理
        /// </summary>
        /// <param name="searchSuplierPayRet1">
        ///                    比較するSearchSuplierPayRetクラスのインスタンス
        /// </param>
        /// <param name="searchSuplierPayRet2">比較するSearchSuplierPayRetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SearchSuplierPayRet searchSuplierPayRet1, SearchSuplierPayRet searchSuplierPayRet2)
        {
            return ((searchSuplierPayRet1.CreateDateTime == searchSuplierPayRet2.CreateDateTime)
                 && (searchSuplierPayRet1.UpdateDateTime == searchSuplierPayRet2.UpdateDateTime)
                 && (searchSuplierPayRet1.EnterpriseCode == searchSuplierPayRet2.EnterpriseCode)
                 && (searchSuplierPayRet1.FileHeaderGuid == searchSuplierPayRet2.FileHeaderGuid)
                 && (searchSuplierPayRet1.UpdEmployeeCode == searchSuplierPayRet2.UpdEmployeeCode)
                 && (searchSuplierPayRet1.UpdAssemblyId1 == searchSuplierPayRet2.UpdAssemblyId1)
                 && (searchSuplierPayRet1.UpdAssemblyId2 == searchSuplierPayRet2.UpdAssemblyId2)
                 && (searchSuplierPayRet1.LogicalDeleteCode == searchSuplierPayRet2.LogicalDeleteCode)
                 && (searchSuplierPayRet1.AddUpSecCode == searchSuplierPayRet2.AddUpSecCode)
                // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                 //&& (searchSuplierPayRet1.CustomerCode == searchSuplierPayRet2.CustomerCode)
                 //&& (searchSuplierPayRet1.CustomerName == searchSuplierPayRet2.CustomerName)
                 //&& (searchSuplierPayRet1.CustomerName2 == searchSuplierPayRet2.CustomerName2)
                 //&& (searchSuplierPayRet1.CustomerSnm == searchSuplierPayRet2.CustomerSnm)
                 && (searchSuplierPayRet1.SupplierCode == searchSuplierPayRet2.SupplierCode)
                 && (searchSuplierPayRet1.SupplierName == searchSuplierPayRet2.SupplierName)
                 && (searchSuplierPayRet1.SupplierName2 == searchSuplierPayRet2.SupplierName2)
                 && (searchSuplierPayRet1.SupplierSnm == searchSuplierPayRet2.SupplierSnm)
                // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                 && (searchSuplierPayRet1.PayeeCode == searchSuplierPayRet2.PayeeCode)
                 && (searchSuplierPayRet1.PayeeName == searchSuplierPayRet2.PayeeName)
                 && (searchSuplierPayRet1.PayeeName2 == searchSuplierPayRet2.PayeeName2)
                 && (searchSuplierPayRet1.PayeeSnm == searchSuplierPayRet2.PayeeSnm)
                 && (searchSuplierPayRet1.AddUpDate == searchSuplierPayRet2.AddUpDate)
                 && (searchSuplierPayRet1.AddUpYearMonth == searchSuplierPayRet2.AddUpYearMonth)
                 && (searchSuplierPayRet1.LastTimePayment == searchSuplierPayRet2.LastTimePayment)
                 && (searchSuplierPayRet1.ThisTimePayNrml == searchSuplierPayRet2.ThisTimePayNrml)
                 && (searchSuplierPayRet1.ThisTimeFeePayNrml == searchSuplierPayRet2.ThisTimeFeePayNrml)
                 && (searchSuplierPayRet1.ThisTimeDisPayNrml == searchSuplierPayRet2.ThisTimeDisPayNrml)
                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                && (searchSuplierPayRet1.ThisTimeRbtPayNrml == searchSuplierPayRet2.ThisTimeRbtPayNrml)
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
                 && (searchSuplierPayRet1.ThisTimeTtlBlcPay == searchSuplierPayRet2.ThisTimeTtlBlcPay)
                 && (searchSuplierPayRet1.ThisNetStckPrice == searchSuplierPayRet2.ThisNetStckPrice)
                 && (searchSuplierPayRet1.ThisNetStcPrcTax == searchSuplierPayRet2.ThisNetStcPrcTax)
                 && (searchSuplierPayRet1.ItdedOffsetOutTax == searchSuplierPayRet2.ItdedOffsetOutTax)
                 && (searchSuplierPayRet1.ItdedOffsetInTax == searchSuplierPayRet2.ItdedOffsetInTax)
                 && (searchSuplierPayRet1.ItdedOffsetTaxFree == searchSuplierPayRet2.ItdedOffsetTaxFree)
                 && (searchSuplierPayRet1.OffsetOutTax == searchSuplierPayRet2.OffsetOutTax)
                 && (searchSuplierPayRet1.OffsetInTax == searchSuplierPayRet2.OffsetInTax)
                 && (searchSuplierPayRet1.ThisTimeStockPrice == searchSuplierPayRet2.ThisTimeStockPrice)
                 && (searchSuplierPayRet1.ThisStcPrcTax == searchSuplierPayRet2.ThisStcPrcTax)
                 && (searchSuplierPayRet1.TtlItdedStcOutTax == searchSuplierPayRet2.TtlItdedStcOutTax)
                 && (searchSuplierPayRet1.TtlItdedStcInTax == searchSuplierPayRet2.TtlItdedStcInTax)
                 && (searchSuplierPayRet1.TtlItdedStcTaxFree == searchSuplierPayRet2.TtlItdedStcTaxFree)
                 && (searchSuplierPayRet1.TtlStockOuterTax == searchSuplierPayRet2.TtlStockOuterTax)
                 && (searchSuplierPayRet1.TtlStockInnerTax == searchSuplierPayRet2.TtlStockInnerTax)
                 && (searchSuplierPayRet1.ThisStckPricRgds == searchSuplierPayRet2.ThisStckPricRgds)
                 && (searchSuplierPayRet1.ThisStcPrcTaxRgds == searchSuplierPayRet2.ThisStcPrcTaxRgds)
                 && (searchSuplierPayRet1.TtlItdedRetOutTax == searchSuplierPayRet2.TtlItdedRetOutTax)
                 && (searchSuplierPayRet1.TtlItdedRetInTax == searchSuplierPayRet2.TtlItdedRetInTax)
                 && (searchSuplierPayRet1.TtlItdedRetTaxFree == searchSuplierPayRet2.TtlItdedRetTaxFree)
                 && (searchSuplierPayRet1.TtlRetOuterTax == searchSuplierPayRet2.TtlRetOuterTax)
                 && (searchSuplierPayRet1.TtlRetInnerTax == searchSuplierPayRet2.TtlRetInnerTax)
                 && (searchSuplierPayRet1.SuppCTaxLayCd == searchSuplierPayRet2.SuppCTaxLayCd)
                 && (searchSuplierPayRet1.SupplierConsTaxRate == searchSuplierPayRet2.SupplierConsTaxRate)
                 && (searchSuplierPayRet1.FractionProcCd == searchSuplierPayRet2.FractionProcCd)
                 && (searchSuplierPayRet1.StockTotalPayBalance == searchSuplierPayRet2.StockTotalPayBalance)
                 && (searchSuplierPayRet1.StockTtl2TmBfBlPay == searchSuplierPayRet2.StockTtl2TmBfBlPay)
                 && (searchSuplierPayRet1.StockTtl3TmBfBlPay == searchSuplierPayRet2.StockTtl3TmBfBlPay)
                 && (searchSuplierPayRet1.CAddUpUpdExecDate == searchSuplierPayRet2.CAddUpUpdExecDate)
                 && (searchSuplierPayRet1.SupProcNum == searchSuplierPayRet2.SupProcNum)
                 && (searchSuplierPayRet1.StartCAddUpUpdDate == searchSuplierPayRet2.StartCAddUpUpdDate)
                 && (searchSuplierPayRet1.LastCAddUpUpdDate == searchSuplierPayRet2.LastCAddUpUpdDate)
                 && (searchSuplierPayRet1.StartDateSpan == searchSuplierPayRet2.StartDateSpan)
                 && (searchSuplierPayRet1.EndDateSpan == searchSuplierPayRet2.EndDateSpan)
                 && (searchSuplierPayRet1.ThisTimePaymentMeter == searchSuplierPayRet2.ThisTimePaymentMeter)
                 && (searchSuplierPayRet1.StcMtrAfOffset == searchSuplierPayRet2.StcMtrAfOffset)
                 && (searchSuplierPayRet1.StcConsTaxMtrAfOffset == searchSuplierPayRet2.StcConsTaxMtrAfOffset)
                 && (searchSuplierPayRet1.BlnceTtl == searchSuplierPayRet2.BlnceTtl)
                 && (searchSuplierPayRet1.Balance == searchSuplierPayRet2.Balance)
                 && (searchSuplierPayRet1.EnterpriseName == searchSuplierPayRet2.EnterpriseName)
                 && (searchSuplierPayRet1.UpdEmployeeName == searchSuplierPayRet2.UpdEmployeeName)
                 && (searchSuplierPayRet1.AddUpSecName == searchSuplierPayRet2.AddUpSecName)
                 && (searchSuplierPayRet1.SuppCTaxLayMethodNm == searchSuplierPayRet2.SuppCTaxLayMethodNm)
                 && (searchSuplierPayRet1.OfsThisTimeStock == searchSuplierPayRet2.OfsThisTimeStock)
                 && (searchSuplierPayRet1.OfsThisStockTax == searchSuplierPayRet2.OfsThisStockTax)
                 );
        }
        /// <summary>
        /// 検索用仕入先支払金額クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchSuplierPayRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SearchSuplierPayRet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            //if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            //if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            //if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SupplierCode != target.SupplierCode) resList.Add("SupplierCode");
            if (this.SupplierName != target.SupplierName) resList.Add("SupplierName");
            if (this.SupplierName2 != target.SupplierName2) resList.Add("SupplierName2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimePayment != target.LastTimePayment) resList.Add("LastTimePayment");
            if (this.ThisTimePayNrml != target.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (this.ThisTimeFeePayNrml != target.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (this.ThisTimeDisPayNrml != target.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            if (this.ThisTimeRbtPayNrml != target.ThisTimeRbtPayNrml) resList.Add("ThisTimeRbtPayNrml");
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            if (this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (this.ThisNetStckPrice != target.ThisNetStckPrice) resList.Add("ThisNetStckPrice");
            if (this.ThisNetStcPrcTax != target.ThisNetStcPrcTax) resList.Add("ThisNetStcPrcTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ThisTimeStockPrice != target.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (this.ThisStcPrcTax != target.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (this.TtlItdedStcOutTax != target.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (this.TtlItdedStcInTax != target.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (this.TtlStockOuterTax != target.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (this.TtlStockInnerTax != target.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (this.ThisStckPricRgds != target.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.StockTotalPayBalance != target.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.SupProcNum != target.SupProcNum) resList.Add("SupProcNum");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.StartDateSpan != target.StartDateSpan) resList.Add("StartDateSpan");
            if (this.EndDateSpan != target.EndDateSpan) resList.Add("EndDateSpan");
            if (this.ThisTimePaymentMeter != target.ThisTimePaymentMeter) resList.Add("ThisTimePaymentMeter");
            if (this.StcMtrAfOffset != target.StcMtrAfOffset) resList.Add("StcMtrAfOffset");
            if (this.StcConsTaxMtrAfOffset != target.StcConsTaxMtrAfOffset) resList.Add("StcConsTaxMtrAfOffset");
            if (this.BlnceTtl != target.BlnceTtl) resList.Add("BlnceTtl");
            if (this.Balance != target.Balance) resList.Add("Balance");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (this.OfsThisTimeStock != target.OfsThisTimeStock) resList.Add("OfsThisTimeStock");
            if (this.OfsThisStockTax != target.OfsThisStockTax) resList.Add("OfsThisStockTax");

            return resList;
        }

        /// <summary>
        /// 検索用仕入先支払金額クラス比較処理
        /// </summary>
        /// <param name="searchSuplierPayRet1">比較するSearchSuplierPayRetクラスのインスタンス</param>
        /// <param name="searchSuplierPayRet2">比較するSearchSuplierPayRetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchSuplierPayRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SearchSuplierPayRet searchSuplierPayRet1, SearchSuplierPayRet searchSuplierPayRet2)
        {
            ArrayList resList = new ArrayList();
            if (searchSuplierPayRet1.CreateDateTime != searchSuplierPayRet2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchSuplierPayRet1.UpdateDateTime != searchSuplierPayRet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchSuplierPayRet1.EnterpriseCode != searchSuplierPayRet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchSuplierPayRet1.FileHeaderGuid != searchSuplierPayRet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchSuplierPayRet1.UpdEmployeeCode != searchSuplierPayRet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchSuplierPayRet1.UpdAssemblyId1 != searchSuplierPayRet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchSuplierPayRet1.UpdAssemblyId2 != searchSuplierPayRet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchSuplierPayRet1.LogicalDeleteCode != searchSuplierPayRet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchSuplierPayRet1.AddUpSecCode != searchSuplierPayRet2.AddUpSecCode) resList.Add("AddUpSecCode");
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (searchSuplierPayRet1.CustomerCode != searchSuplierPayRet2.CustomerCode) resList.Add("CustomerCode");
            //if (searchSuplierPayRet1.CustomerName != searchSuplierPayRet2.CustomerName) resList.Add("CustomerName");
            //if (searchSuplierPayRet1.CustomerName2 != searchSuplierPayRet2.CustomerName2) resList.Add("CustomerName2");
            //if (searchSuplierPayRet1.CustomerSnm != searchSuplierPayRet2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchSuplierPayRet1.SupplierCode != searchSuplierPayRet2.SupplierCode) resList.Add("SupplierCode");
            if (searchSuplierPayRet1.SupplierName != searchSuplierPayRet2.SupplierName) resList.Add("SupplierName");
            if (searchSuplierPayRet1.SupplierName2 != searchSuplierPayRet2.SupplierName2) resList.Add("SupplierName2");
            if (searchSuplierPayRet1.SupplierSnm != searchSuplierPayRet2.SupplierSnm) resList.Add("SupplierSnm");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (searchSuplierPayRet1.PayeeCode != searchSuplierPayRet2.PayeeCode) resList.Add("PayeeCode");
            if (searchSuplierPayRet1.PayeeName != searchSuplierPayRet2.PayeeName) resList.Add("PayeeName");
            if (searchSuplierPayRet1.PayeeName2 != searchSuplierPayRet2.PayeeName2) resList.Add("PayeeName2");
            if (searchSuplierPayRet1.PayeeSnm != searchSuplierPayRet2.PayeeSnm) resList.Add("PayeeSnm");
            if (searchSuplierPayRet1.AddUpDate != searchSuplierPayRet2.AddUpDate) resList.Add("AddUpDate");
            if (searchSuplierPayRet1.AddUpYearMonth != searchSuplierPayRet2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (searchSuplierPayRet1.LastTimePayment != searchSuplierPayRet2.LastTimePayment) resList.Add("LastTimePayment");
            if (searchSuplierPayRet1.ThisTimePayNrml != searchSuplierPayRet2.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (searchSuplierPayRet1.ThisTimeFeePayNrml != searchSuplierPayRet2.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (searchSuplierPayRet1.ThisTimeDisPayNrml != searchSuplierPayRet2.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            if (searchSuplierPayRet1.ThisTimeRbtPayNrml != searchSuplierPayRet2.ThisTimeRbtPayNrml) resList.Add("ThisTimeRbtPayNrml");
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            if (searchSuplierPayRet1.ThisTimeTtlBlcPay != searchSuplierPayRet2.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (searchSuplierPayRet1.ThisNetStckPrice != searchSuplierPayRet2.ThisNetStckPrice) resList.Add("ThisNetStckPrice");
            if (searchSuplierPayRet1.ThisNetStcPrcTax != searchSuplierPayRet2.ThisNetStcPrcTax) resList.Add("ThisNetStcPrcTax");
            if (searchSuplierPayRet1.ItdedOffsetOutTax != searchSuplierPayRet2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (searchSuplierPayRet1.ItdedOffsetInTax != searchSuplierPayRet2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (searchSuplierPayRet1.ItdedOffsetTaxFree != searchSuplierPayRet2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (searchSuplierPayRet1.OffsetOutTax != searchSuplierPayRet2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (searchSuplierPayRet1.OffsetInTax != searchSuplierPayRet2.OffsetInTax) resList.Add("OffsetInTax");
            if (searchSuplierPayRet1.ThisTimeStockPrice != searchSuplierPayRet2.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (searchSuplierPayRet1.ThisStcPrcTax != searchSuplierPayRet2.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (searchSuplierPayRet1.TtlItdedStcOutTax != searchSuplierPayRet2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (searchSuplierPayRet1.TtlItdedStcInTax != searchSuplierPayRet2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (searchSuplierPayRet1.TtlItdedStcTaxFree != searchSuplierPayRet2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (searchSuplierPayRet1.TtlStockOuterTax != searchSuplierPayRet2.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (searchSuplierPayRet1.TtlStockInnerTax != searchSuplierPayRet2.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (searchSuplierPayRet1.ThisStckPricRgds != searchSuplierPayRet2.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (searchSuplierPayRet1.ThisStcPrcTaxRgds != searchSuplierPayRet2.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (searchSuplierPayRet1.TtlItdedRetOutTax != searchSuplierPayRet2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (searchSuplierPayRet1.TtlItdedRetInTax != searchSuplierPayRet2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (searchSuplierPayRet1.TtlItdedRetTaxFree != searchSuplierPayRet2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (searchSuplierPayRet1.TtlRetOuterTax != searchSuplierPayRet2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (searchSuplierPayRet1.TtlRetInnerTax != searchSuplierPayRet2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (searchSuplierPayRet1.SuppCTaxLayCd != searchSuplierPayRet2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (searchSuplierPayRet1.SupplierConsTaxRate != searchSuplierPayRet2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (searchSuplierPayRet1.FractionProcCd != searchSuplierPayRet2.FractionProcCd) resList.Add("FractionProcCd");
            if (searchSuplierPayRet1.StockTotalPayBalance != searchSuplierPayRet2.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (searchSuplierPayRet1.StockTtl2TmBfBlPay != searchSuplierPayRet2.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (searchSuplierPayRet1.StockTtl3TmBfBlPay != searchSuplierPayRet2.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (searchSuplierPayRet1.CAddUpUpdExecDate != searchSuplierPayRet2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (searchSuplierPayRet1.SupProcNum != searchSuplierPayRet2.SupProcNum) resList.Add("SupProcNum");
            if (searchSuplierPayRet1.StartCAddUpUpdDate != searchSuplierPayRet2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (searchSuplierPayRet1.LastCAddUpUpdDate != searchSuplierPayRet2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (searchSuplierPayRet1.StartDateSpan != searchSuplierPayRet2.StartDateSpan) resList.Add("StartDateSpan");
            if (searchSuplierPayRet1.EndDateSpan != searchSuplierPayRet2.EndDateSpan) resList.Add("EndDateSpan");
            if (searchSuplierPayRet1.ThisTimePaymentMeter != searchSuplierPayRet2.ThisTimePaymentMeter) resList.Add("ThisTimePaymentMeter");
            if (searchSuplierPayRet1.StcMtrAfOffset != searchSuplierPayRet2.StcMtrAfOffset) resList.Add("StcMtrAfOffset");
            if (searchSuplierPayRet1.StcConsTaxMtrAfOffset != searchSuplierPayRet2.StcConsTaxMtrAfOffset) resList.Add("StcConsTaxMtrAfOffset");
            if (searchSuplierPayRet1.BlnceTtl != searchSuplierPayRet2.BlnceTtl) resList.Add("BlnceTtl");
            if (searchSuplierPayRet1.Balance != searchSuplierPayRet2.Balance) resList.Add("Balance");
            if (searchSuplierPayRet1.EnterpriseName != searchSuplierPayRet2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchSuplierPayRet1.UpdEmployeeName != searchSuplierPayRet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchSuplierPayRet1.AddUpSecName != searchSuplierPayRet2.AddUpSecName) resList.Add("AddUpSecName");
            if (searchSuplierPayRet1.SuppCTaxLayMethodNm != searchSuplierPayRet2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (searchSuplierPayRet1.OfsThisTimeStock != searchSuplierPayRet2.OfsThisTimeStock) resList.Add("OfsThisTimeStock");
            if (searchSuplierPayRet1.OfsThisStockTax != searchSuplierPayRet2.OfsThisStockTax) resList.Add("OfsThisStockTax");

            return resList;
        }
    }
}
