using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 電帳.DX連携用CSVエンティティクラス
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class DenchoDXIndexCSVEntity
    {

        # region ■ private field ■
        /// <summary>システム区分</summary>
        private EMcdType _mcd;

        /// <summary>取引先コード(自社)</summary>
        private string _blcustomercd;

        /// <summary>ファイル名</summary>
        private string _filename;

        /// <summary>書類分類</summary>
        private EDocType _doctype;

        /// <summary>取引先コード</summary>
        private string _customercd;

        /// <summary>取引先名称</summary>
        private string _customername;

        /// <summary>書類番号</summary>
        private string _docnumber;

        /// <summary>取引年月日</summary>
        private DateTime _transactiondate;

        /// <summary>取引時間</summary>
        private DateTime _transactiontime;

        /// <summary>取引金額合計(税込み)</summary>
        private decimal _price_tax_included;

        /// <summary>取引金額合計(税抜き)</summary>
        private decimal _price_tax_excluded;

        /// <summary>消費税金額合計</summary>
        private decimal _total_tax;

        /// <summary>備考</summary>
        private string _memo;

        /// <summary>登録番号(発行者)</summary>
        private string _aojcorporatenumber;

        /// <summary>発行者名称</summary>
        private string _companyname;

        /// <summary>発行拠点コード</summary>
        private ulong _sectioncd;

        /// <summary>発行拠点名称</summary>
        private string _sectionname;

        /// <summary>拡張1(予備)</summary>
        private string _ext1;

        /// <summary>拡張2(予備)</summary>
        private string _ext2;

        /// <summary>拡張3(予備)</summary>
        private string _ext3;

        /// <summary>拡張4(予備)</summary>
        private string _ext4;

        /// <summary>通貨単位</summary>
        private ECurrencyUnitType _currencyunit;

        /// <summary>税率(1)</summary>
        private int _taxrate1;

        /// <summary>税額(1)</summary>
        private decimal _tax1;

        /// <summary>税率(1)対象金額合計(税込み)</summary>
        private decimal _price_taxrate1_included;

        /// <summary>税率(1)対象金額合計(税抜き)</summary>
        private decimal _price_taxrate1_excluded;

        /// <summary>税率(2)</summary>
        private int _taxrate2;

        /// <summary>税率(2)対象金額合計(税込み)</summary>
        private decimal _price_taxrate2_included;

        /// <summary>税率(2)対象金額合計(税抜き)</summary>
        private decimal _price_taxrate2_excluded;

        /// <summary>税額(2)</summary>
        private decimal _tax2;

        /// <summary>税率(3)</summary>
        private int _taxrate3;

        /// <summary>税率(3)対象金額合計(税込み)</summary>
        private decimal _price_taxrate3_included;

        /// <summary>税率(3)対象金額合計(税抜き)</summary>
        private decimal _price_taxrate3_excluded;

        /// <summary>税額(3)</summary>
        private decimal _tax3;
        # endregion

        # region ■ public sratic ■
        /// <summary>システム区分列挙体</summary>
        public enum EMcdType
        {
            /// <summary>Maintenance.c</summary>
            MaintenanceC = 1011,
            /// <summary>Repair.c</summary>
            RepairC = 1015,
            /// <summary>Carsales.c</summary>
            CarsalesC = 1018,
            /// <summary>Partsman.c</summary>
            PartsmanC = 1020,
            /// <summary>Recycle+</summary>
            RecyclePlus = 1023,
            /// <summary>SF.NS</summary>
            SFNS = 2011,
            /// <summary>BK.NS</summary>
            BKNS = 2015,
            /// <summary>CS.NS</summary>
            CSNS = 2018,
            /// <summary>PM.NS</summary>
            PMNS = 2020,
            /// <summary>RCオプション</summary>
            RCOption = 2023,
            /// <summary>MK.NS</summary>
            MKNS = 2301,
            /// <summary>TR.NS</summary>
            TRNS = 2350,
            /// <summary>ガラス商システムSP</summary>
            GlassSP = 3030,
            /// <summary>機工メイト</summary>
            Kikou = 3201,
            /// <summary>旅行業システムSP</summary>
            RyokouSP = 3340,
            /// <summary>バス運航管理システムSP</summary>
            BusSP = 3345,
            /// <summary>一新多助</summary>
            IsshinTazyo = 5101
        }

        /// <summary>書類分類列挙体</summary>
        public enum EDocType
        {
            /// <summary>見積書</summary>
            Quotation = 100,
            /// <summary>注文書（発注書）</summary>
            PurchaseOrder = 120,
            /// <summary>注文請書（発注請書）</summary>
            ConfirmationOfOrder = 140,
            /// <summary>納品書</summary>
            DeliverySlip = 160,
            /// <summary>受領書</summary>
            ReceiptType1 = 180,
            /// <summary>請求書</summary>
            Invoice = 200,
            /// <summary>領収書</summary>
            ReceiptType2 = 220,
            /// <summary>精算書</summary>
            Settlement = 220,
            /// <summary>契約書</summary>
            Contract = 220,
            /// <summary>その他</summary>
            Other = 9999
        }

        /// <summary>通貨単位</summary>
        public enum ECurrencyUnitType
        {
            /// <summary>日本円</summary>
            JPY = 100,
            /// <summary>アメリカドル</summary>
            USD = 120
        }
        # endregion

        # region ■ public property ■
        /// <summary>システム区分のプロパティ</summary>
        public EMcdType Mcd
        {
            get { return _mcd; }
            set { _mcd = value; }
        }

        /// <summary>取引先コード(自社)のプロパティ</summary>
        public string Blcustomercd
        {
            get { return _blcustomercd; }
            set { _blcustomercd = value; }
        }

        /// <summary>ファイル名のプロパティ</summary>
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        /// <summary>取引先コード(自社)のプロパティ</summary>
        public EDocType Doctype
        {
            get { return _doctype; }
            set { _doctype = value; }
        }

        /// <summary>取引先コードのプロパティ</summary>
        public string Customercd
        {
            get { return _customercd; }
            set { _customercd = value; }
        }

        /// <summary>取引先名称のプロパティ</summary>
        public string Customername
        {
            get { return _customername; }
            set { _customername = value; }
        }

        /// <summary>書類番号のプロパティ</summary>
        public string Docnumber
        {
            get { return _docnumber; }
            set { _docnumber = value; }
        }

        /// <summary>取引年月日のプロパティ</summary>
        public DateTime Transactiondate
        {
            get { return _transactiondate; }
            set { _transactiondate = value; }
        }

        /// <summary>取引時間のプロパティ</summary>
        public DateTime Transactiontime
        {
            get { return _transactiontime; }
            set { _transactiontime = value; }
        }

        /// <summary>取引金額合計(税込み)のプロパティ</summary>
        public decimal Price_tax_included
        {
            get { return _price_tax_included; }
            set { _price_tax_included = value; }
        }

        /// <summary>取引金額合計(税抜き)のプロパティ</summary>
        public decimal Price_tax_excluded
        {
            get { return _price_tax_excluded; }
            set { _price_tax_excluded = value; }
        }

        /// <summary>消費税金額合計のプロパティ</summary>
        public decimal Total_tax
        {
            get { return _total_tax; }
            set { _total_tax = value; }
        }

        /// <summary>備考のプロパティ</summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        /// <summary>登録番号(発行者)のプロパティ</summary>
        public string Aojcorporatenumber
        {
            get { return _aojcorporatenumber; }
            set { _aojcorporatenumber = value; }
        }

        /// <summary>発行者名称のプロパティ</summary>
        public string Companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        /// <summary>発行拠点コードのプロパティ</summary>
        public ulong Sectioncd
        {
            get { return _sectioncd; }
            set { _sectioncd = value; }
        }

        /// <summary>発行拠点名称のプロパティ</summary>
        public string Sectionname
        {
            get { return _sectionname; }
            set { _sectionname = value; }
        }

        /// <summary>拡張(予備)のプロパティ</summary>
        public string Ext1
        {
            get { return _ext1; }
            set { _ext1 = value; }
        }

        /// <summary>拡張(予備)のプロパティ</summary>
        public string Ext2
        {
            get { return _ext2; }
            set { _ext2 = value; }
        }

        /// <summary>拡張(予備)のプロパティ</summary>
        public string Ext3
        {
            get { return _ext3; }
            set { _ext3 = value; }
        }

        /// <summary>拡張(予備)のプロパティ</summary>
        public string Ext4
        {
            get { return _ext4; }
            set { _ext4 = value; }
        }

        /// <summary>通貨単位のプロパティ</summary>
        public ECurrencyUnitType Currencyunit
        {
            get { return _currencyunit; }
            set { _currencyunit = value; }
        }

        /// <summary>税率(1)のプロパティ</summary>
        public int Taxrate1
        {
            get { return _taxrate1; }
            set { _taxrate1 = value; }
        }

        /// <summary>税率(1)対象金額合計(税込み)のプロパティ</summary>
        public decimal Price_taxrate1_included
        {
            get { return _price_taxrate1_included; }
            set { _price_taxrate1_included = value; }
        }

        /// <summary>税率(1)対象金額合計(税抜き)のプロパティ</summary>
        public decimal Price_taxrate1_excluded
        {
            get { return _price_taxrate1_excluded; }
            set { _price_taxrate1_excluded = value; }
        }

        /// <summary>税額(1)のプロパティ</summary>
        public decimal Tax1
        {
            get { return _tax1; }
            set { _tax1 = value; }
        }

        /// <summary>税率(2)のプロパティ</summary>
        public int Taxrate2
        {
            get { return _taxrate2; }
            set { _taxrate2 = value; }

        }

        /// <summary>税率(2)対象金額合計(税込み)のプロパティ</summary>
        public decimal Price_taxrate2_included
        {
            get { return _price_taxrate2_included; }
            set { _price_taxrate2_included = value; }
        }

        /// <summary>税率(2)対象金額合計(税抜き)のプロパティ</summary>
        public decimal Price_taxrate2_excluded
        {
            get { return _price_taxrate2_excluded; }
            set { _price_taxrate2_excluded = value; }
        }

        /// <summary>税額(2)のプロパティ</summary>
        public decimal Tax2
        {
            get { return _tax2; }
            set { _tax2 = value; }
        }

        /// <summary>税率(3)のプロパティ</summary>
        public int Taxrate3
        {
            get { return _taxrate3; }
            set { _taxrate3 = value; }
        }

        /// <summary>税率(3)対象金額合計(税込み)のプロパティ</summary>
        public decimal Price_taxrate3_included
        {
            get { return _price_taxrate3_included; }
            set { _price_taxrate3_included = value; }
        }

        /// <summary>税率(3)対象金額合計(税抜き)のプロパティ</summary>
        public decimal Price_taxrate3_excluded
        {
            get { return _price_taxrate3_excluded; }
            set { _price_taxrate3_excluded = value; }
        }

        /// <summary>税額(3)のプロパティ</summary>
        public decimal Tax3
        {
            get { return _tax3; }
            set { _tax3 = value; }
        }

        # endregion

    }

}