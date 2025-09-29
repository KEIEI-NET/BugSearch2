using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierCheckResult
    /// <summary>
    ///                      仕入チェック処理抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入チェック処理抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :  2012/08/30 凌小青</br>
    /// <br>                    Redmine#31879の対応 UOE仕入データの区分を取得</br>
    /// <br>Update Note      :  2012/10/09 朱 猛</br>
    /// <br>                    Redmine#31879の対応 赤伝区分を取得</br>
    /// </remarks>
    public class SupplierCheckResult
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

        /// <summary>仕入チェック区分（締次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>仕入チェック区分（日次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivDaily;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _stockDate;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入金額（税込み）</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>仕入数</summary>
        private Double _stockCount;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>売上入力者名称</summary>
        private string _salesInputName = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>変更前仕入単価（浮動）</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>仕入商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879------->>>>>>>
        /// <summary> 赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;
        //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879-------<<<<<<<<

        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
        /// <summary> 注文方法</summary>
        /// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
        private Int32 _wayToOrder;

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   追加</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }
        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<<

        //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879------->>>>>>>
        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   追加</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }
        //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879-------<<<<<<<<

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>仕入チェック区分（締次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（締次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>仕入チェック区分（日次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（日次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockDateJpFormal
        /// <summary>仕入日 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>仕入日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>仕入日 西暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>仕入日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  InputDayJpFormal
        /// <summary>入力日 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>入力日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>入力日 西暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>入力日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>仕入金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>仕入数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>売上日付 和暦(略)プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>売上日付 西暦プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>売上日付 西暦(略)プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
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
            get { return _customerCode; }
            set { _customerCode = value; }
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
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
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
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// 仕入チェック処理抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>SupplierCheckResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckResult()
        {
        }

        /// <summary>
        /// 仕入チェック処理抽出結果クラスコンストラクタ
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
        /// <param name="stockCheckDivCAddUp">仕入チェック区分（締次）(0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）)</param>
        /// <param name="stockCheckDivDaily">仕入チェック区分（日次）(0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）)</param>
        /// <param name="stockDate">仕入日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="inputDay">入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="supplierSlipNo">仕入伝票番号(発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる)</param>
        /// <param name="partySaleSlipNum">相手先伝票番号(仕入先伝票番号に使用する)</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入金額消費税額(仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる)</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="stockCount">仕入数</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）(税抜き)</param>
        /// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税抜き)</param>
        /// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <param name="salesDate">売上日付((YYYYMMDD))</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="frontEmployeeNm">受付従業員名称</param>
        /// <param name="salesInputName">売上入力者名称</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１(UserOrderEntory)</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="supplierFormal">仕入形式(0:仕入　（受注ステータス）)</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="bfStockUnitPriceFl">変更前仕入単価（浮動）(税抜き、掛率算出結果)</param>
        /// <param name="supplierSlipCd">仕入伝票区分(10:仕入,20:返品)</param>
        /// <param name="stockGoodsCd">仕入商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>SupplierCheckResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockCheckDivCAddUp, Int32 stockCheckDivDaily, DateTime stockDate, DateTime inputDay, Int32 supplierSlipNo, string partySaleSlipNum, Int64 stockPriceTaxInc, Int64 stockPriceTaxExc, Int64 stockPriceConsTax, string goodsNo, Double stockCount, Int32 bLGoodsCode, string goodsName, Double stockUnitPriceFl, Double listPriceTaxExcFl, Double salesUnPrcTaxExcFl, Int64 salesMoneyTaxExc, DateTime salesDate, string salesSlipNum, Int32 customerCode, string customerSnm, string salesEmployeeNm, string frontEmployeeNm, string salesInputName, string uoeRemark1, string uoeRemark2, Int32 supplierCd, string supplierSnm, Int32 supplierFormal, Int64 stockSlipDtlNum, Double bfStockUnitPriceFl, Int32 supplierSlipCd, Int32 stockGoodsCd, string enterpriseName, string updEmployeeName, string bLGoodsName)
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
            this._stockCheckDivCAddUp = stockCheckDivCAddUp;
            this._stockCheckDivDaily = stockCheckDivDaily;
            this.StockDate = stockDate;
            this.InputDay = inputDay;
            this._supplierSlipNo = supplierSlipNo;
            this._partySaleSlipNum = partySaleSlipNum;
            this._stockPriceTaxInc = stockPriceTaxInc;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceConsTax = stockPriceConsTax;
            this._goodsNo = goodsNo;
            this._stockCount = stockCount;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this.SalesDate = salesDate;
            this._salesSlipNum = salesSlipNum;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._salesEmployeeNm = salesEmployeeNm;
            this._frontEmployeeNm = frontEmployeeNm;
            this._salesInputName = salesInputName;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._supplierFormal = supplierFormal;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._bfStockUnitPriceFl = bfStockUnitPriceFl;
            this._supplierSlipCd = supplierSlipCd;
            this._stockGoodsCd = stockGoodsCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 仕入チェック処理抽出結果クラス複製処理
        /// </summary>
        /// <returns>SupplierCheckResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSupplierCheckResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckResult Clone()
        {
            return new SupplierCheckResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockCheckDivCAddUp, this._stockCheckDivDaily, this._stockDate, this._inputDay, this._supplierSlipNo, this._partySaleSlipNum, this._stockPriceTaxInc, this._stockPriceTaxExc, this._stockPriceConsTax, this._goodsNo, this._stockCount, this._bLGoodsCode, this._goodsName, this._stockUnitPriceFl, this._listPriceTaxExcFl, this._salesUnPrcTaxExcFl, this._salesMoneyTaxExc, this._salesDate, this._salesSlipNum, this._customerCode, this._customerSnm, this._salesEmployeeNm, this._frontEmployeeNm, this._salesInputName, this._uoeRemark1, this._uoeRemark2, this._supplierCd, this._supplierSnm, this._supplierFormal, this._stockSlipDtlNum, this._bfStockUnitPriceFl, this._supplierSlipCd, this._stockGoodsCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
        }

        /// <summary>
        /// 仕入チェック処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSupplierCheckResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SupplierCheckResult target)
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
                 && (this.StockCheckDivCAddUp == target.StockCheckDivCAddUp)
                 && (this.StockCheckDivDaily == target.StockCheckDivDaily)
                 && (this.StockDate == target.StockDate)
                 && (this.InputDay == target.InputDay)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.StockCount == target.StockCount)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.SalesDate == target.SalesDate)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.StockGoodsCd == target.StockGoodsCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// 仕入チェック処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="supplierCheckResult1">
        ///                    比較するSupplierCheckResultクラスのインスタンス
        /// </param>
        /// <param name="supplierCheckResult2">比較するSupplierCheckResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SupplierCheckResult supplierCheckResult1, SupplierCheckResult supplierCheckResult2)
        {
            return ((supplierCheckResult1.CreateDateTime == supplierCheckResult2.CreateDateTime)
                 && (supplierCheckResult1.UpdateDateTime == supplierCheckResult2.UpdateDateTime)
                 && (supplierCheckResult1.EnterpriseCode == supplierCheckResult2.EnterpriseCode)
                 && (supplierCheckResult1.FileHeaderGuid == supplierCheckResult2.FileHeaderGuid)
                 && (supplierCheckResult1.UpdEmployeeCode == supplierCheckResult2.UpdEmployeeCode)
                 && (supplierCheckResult1.UpdAssemblyId1 == supplierCheckResult2.UpdAssemblyId1)
                 && (supplierCheckResult1.UpdAssemblyId2 == supplierCheckResult2.UpdAssemblyId2)
                 && (supplierCheckResult1.LogicalDeleteCode == supplierCheckResult2.LogicalDeleteCode)
                 && (supplierCheckResult1.SectionCode == supplierCheckResult2.SectionCode)
                 && (supplierCheckResult1.StockCheckDivCAddUp == supplierCheckResult2.StockCheckDivCAddUp)
                 && (supplierCheckResult1.StockCheckDivDaily == supplierCheckResult2.StockCheckDivDaily)
                 && (supplierCheckResult1.StockDate == supplierCheckResult2.StockDate)
                 && (supplierCheckResult1.InputDay == supplierCheckResult2.InputDay)
                 && (supplierCheckResult1.SupplierSlipNo == supplierCheckResult2.SupplierSlipNo)
                 && (supplierCheckResult1.PartySaleSlipNum == supplierCheckResult2.PartySaleSlipNum)
                 && (supplierCheckResult1.StockPriceTaxInc == supplierCheckResult2.StockPriceTaxInc)
                 && (supplierCheckResult1.StockPriceTaxExc == supplierCheckResult2.StockPriceTaxExc)
                 && (supplierCheckResult1.StockPriceConsTax == supplierCheckResult2.StockPriceConsTax)
                 && (supplierCheckResult1.GoodsNo == supplierCheckResult2.GoodsNo)
                 && (supplierCheckResult1.StockCount == supplierCheckResult2.StockCount)
                 && (supplierCheckResult1.BLGoodsCode == supplierCheckResult2.BLGoodsCode)
                 && (supplierCheckResult1.GoodsName == supplierCheckResult2.GoodsName)
                 && (supplierCheckResult1.StockUnitPriceFl == supplierCheckResult2.StockUnitPriceFl)
                 && (supplierCheckResult1.ListPriceTaxExcFl == supplierCheckResult2.ListPriceTaxExcFl)
                 && (supplierCheckResult1.SalesUnPrcTaxExcFl == supplierCheckResult2.SalesUnPrcTaxExcFl)
                 && (supplierCheckResult1.SalesMoneyTaxExc == supplierCheckResult2.SalesMoneyTaxExc)
                 && (supplierCheckResult1.SalesDate == supplierCheckResult2.SalesDate)
                 && (supplierCheckResult1.SalesSlipNum == supplierCheckResult2.SalesSlipNum)
                 && (supplierCheckResult1.CustomerCode == supplierCheckResult2.CustomerCode)
                 && (supplierCheckResult1.CustomerSnm == supplierCheckResult2.CustomerSnm)
                 && (supplierCheckResult1.SalesEmployeeNm == supplierCheckResult2.SalesEmployeeNm)
                 && (supplierCheckResult1.FrontEmployeeNm == supplierCheckResult2.FrontEmployeeNm)
                 && (supplierCheckResult1.SalesInputName == supplierCheckResult2.SalesInputName)
                 && (supplierCheckResult1.UoeRemark1 == supplierCheckResult2.UoeRemark1)
                 && (supplierCheckResult1.UoeRemark2 == supplierCheckResult2.UoeRemark2)
                 && (supplierCheckResult1.SupplierCd == supplierCheckResult2.SupplierCd)
                 && (supplierCheckResult1.SupplierSnm == supplierCheckResult2.SupplierSnm)
                 && (supplierCheckResult1.SupplierFormal == supplierCheckResult2.SupplierFormal)
                 && (supplierCheckResult1.StockSlipDtlNum == supplierCheckResult2.StockSlipDtlNum)
                 && (supplierCheckResult1.BfStockUnitPriceFl == supplierCheckResult2.BfStockUnitPriceFl)
                 && (supplierCheckResult1.SupplierSlipCd == supplierCheckResult2.SupplierSlipCd)
                 && (supplierCheckResult1.StockGoodsCd == supplierCheckResult2.StockGoodsCd)
                 && (supplierCheckResult1.EnterpriseName == supplierCheckResult2.EnterpriseName)
                 && (supplierCheckResult1.UpdEmployeeName == supplierCheckResult2.UpdEmployeeName)
                 && (supplierCheckResult1.BLGoodsName == supplierCheckResult2.BLGoodsName));
        }
        /// <summary>
        /// 仕入チェック処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSupplierCheckResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SupplierCheckResult target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.StockCheckDivCAddUp != target.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (this.StockCheckDivDaily != target.StockCheckDivDaily) resList.Add("StockCheckDivDaily");
            if (this.StockDate != target.StockDate) resList.Add("StockDate");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.StockPriceTaxInc != target.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.BfStockUnitPriceFl != target.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (this.StockGoodsCd != target.StockGoodsCd) resList.Add("StockGoodsCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 仕入チェック処理抽出結果クラス比較処理
        /// </summary>
        /// <param name="supplierCheckResult1">比較するSupplierCheckResultクラスのインスタンス</param>
        /// <param name="supplierCheckResult2">比較するSupplierCheckResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SupplierCheckResult supplierCheckResult1, SupplierCheckResult supplierCheckResult2)
        {
            ArrayList resList = new ArrayList();
            if (supplierCheckResult1.CreateDateTime != supplierCheckResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (supplierCheckResult1.UpdateDateTime != supplierCheckResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (supplierCheckResult1.EnterpriseCode != supplierCheckResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (supplierCheckResult1.FileHeaderGuid != supplierCheckResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (supplierCheckResult1.UpdEmployeeCode != supplierCheckResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (supplierCheckResult1.UpdAssemblyId1 != supplierCheckResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (supplierCheckResult1.UpdAssemblyId2 != supplierCheckResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (supplierCheckResult1.LogicalDeleteCode != supplierCheckResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (supplierCheckResult1.SectionCode != supplierCheckResult2.SectionCode) resList.Add("SectionCode");
            if (supplierCheckResult1.StockCheckDivCAddUp != supplierCheckResult2.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (supplierCheckResult1.StockCheckDivDaily != supplierCheckResult2.StockCheckDivDaily) resList.Add("StockCheckDivDaily");
            if (supplierCheckResult1.StockDate != supplierCheckResult2.StockDate) resList.Add("StockDate");
            if (supplierCheckResult1.InputDay != supplierCheckResult2.InputDay) resList.Add("InputDay");
            if (supplierCheckResult1.SupplierSlipNo != supplierCheckResult2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (supplierCheckResult1.PartySaleSlipNum != supplierCheckResult2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (supplierCheckResult1.StockPriceTaxInc != supplierCheckResult2.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (supplierCheckResult1.StockPriceTaxExc != supplierCheckResult2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (supplierCheckResult1.StockPriceConsTax != supplierCheckResult2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (supplierCheckResult1.GoodsNo != supplierCheckResult2.GoodsNo) resList.Add("GoodsNo");
            if (supplierCheckResult1.StockCount != supplierCheckResult2.StockCount) resList.Add("StockCount");
            if (supplierCheckResult1.BLGoodsCode != supplierCheckResult2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (supplierCheckResult1.GoodsName != supplierCheckResult2.GoodsName) resList.Add("GoodsName");
            if (supplierCheckResult1.StockUnitPriceFl != supplierCheckResult2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (supplierCheckResult1.ListPriceTaxExcFl != supplierCheckResult2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (supplierCheckResult1.SalesUnPrcTaxExcFl != supplierCheckResult2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (supplierCheckResult1.SalesMoneyTaxExc != supplierCheckResult2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (supplierCheckResult1.SalesDate != supplierCheckResult2.SalesDate) resList.Add("SalesDate");
            if (supplierCheckResult1.SalesSlipNum != supplierCheckResult2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (supplierCheckResult1.CustomerCode != supplierCheckResult2.CustomerCode) resList.Add("CustomerCode");
            if (supplierCheckResult1.CustomerSnm != supplierCheckResult2.CustomerSnm) resList.Add("CustomerSnm");
            if (supplierCheckResult1.SalesEmployeeNm != supplierCheckResult2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (supplierCheckResult1.FrontEmployeeNm != supplierCheckResult2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (supplierCheckResult1.SalesInputName != supplierCheckResult2.SalesInputName) resList.Add("SalesInputName");
            if (supplierCheckResult1.UoeRemark1 != supplierCheckResult2.UoeRemark1) resList.Add("UoeRemark1");
            if (supplierCheckResult1.UoeRemark2 != supplierCheckResult2.UoeRemark2) resList.Add("UoeRemark2");
            if (supplierCheckResult1.SupplierCd != supplierCheckResult2.SupplierCd) resList.Add("SupplierCd");
            if (supplierCheckResult1.SupplierSnm != supplierCheckResult2.SupplierSnm) resList.Add("SupplierSnm");
            if (supplierCheckResult1.SupplierFormal != supplierCheckResult2.SupplierFormal) resList.Add("SupplierFormal");
            if (supplierCheckResult1.StockSlipDtlNum != supplierCheckResult2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (supplierCheckResult1.BfStockUnitPriceFl != supplierCheckResult2.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (supplierCheckResult1.SupplierSlipCd != supplierCheckResult2.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (supplierCheckResult1.StockGoodsCd != supplierCheckResult2.StockGoodsCd) resList.Add("StockGoodsCd");
            if (supplierCheckResult1.EnterpriseName != supplierCheckResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (supplierCheckResult1.UpdEmployeeName != supplierCheckResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (supplierCheckResult1.BLGoodsName != supplierCheckResult2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
