using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockTtlSt
    /// <summary>
    ///                      仕入在庫全体設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入在庫全体設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/7/24</br>
    /// <br>Genarated Date   :   2008/02/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/2/13  杉村</br>
    /// <br>                 :   自動支払金種コード，自動支払金種名称</br>
    /// <br>                 :   自動支払金種区分の追加</br>
    /// <br>Update Note      :   2008.02.18 30167 上野　弘貴</br>
    /// <br>					 自動支払関連項目追加</br>
    /// <br>Update Note      :   2008/2/25  杉村</br>
    /// <br>                 :   入出荷数区分２の追加</br>
    /// <br>Update Note      :   </br>
    /// <br>                 :   ※変更する際の注意事項※※</br>
    /// <br>                 :   このクラスを項目追加などで変更する場合、自動生成ツールを使いそのまま置き換えたら</br>
    /// <br>                 :   アクセスクラスや画面でリビルドできません。自動支払金種リストなどのファイル仕様書にはない項目が追加されています。</br>
    /// <br>                 :   (このクラスに上記項目やメソッドを追加しているのがおかしい(static？)、本来ならアクセスクラスに追加しないと自動生成できる意味がないし、本来の意味での仕入在庫全体設定マスタのクラスにならない)</br>  
    /// <br>UpdateNote       :   2008/06/05 30415 柴田 倫幸</br>
    /// <br>        	         ・データ項目の追加/削除による修正</br>    
    /// <br>UpdateNote       :   2008/07/22 30415 柴田 倫幸</br>
    /// <br>        	         ・項目の削除による修正</br>
    /// <br>UpdateNote       :   2008/09/12 30452 上野 俊治</br>
    /// <br>        	         ・在庫検索区分を追加</br>   
    /// </remarks>
    public class StockTtlSt
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

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        /// <remarks>オール０は全社</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>仕入在庫全体設定管理コード</summary>
        /// <remarks>常に０設定</remarks>
        private Int32 _stockAllStMngCd;

        /// <summary>税率有効日1</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate1;

        /// <summary>消費税率1</summary>
        private Double _consTaxRate1;

        /// <summary>税率有効日2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate2;

        /// <summary>消費税率2</summary>
        private Double _consTaxRate2;

        /// <summary>税率有効日3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate3;

        /// <summary>消費税率3</summary>
        private Double _consTaxRate3;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>仕入値引名称</summary>
        private string _stockDiscountName = "";

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>部品単価0区分</summary>
        /// <remarks>0:提供データを参照しない,1:提供データを参照する　※１</remarks>
        private Int32 _partsUnitPrcZeroCd;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</remarks>
        private Int32 _suppCTaxLayCd;
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>返品伝票発行区分</summary>
        /// <remarks>0:しない　1:する。</remarks>
        private Int32 _rgdsSlipPrtDiv;

        /// <summary>返品時単価印刷区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _rgdsUnPrcPrtDiv;

        /// <summary>返品時ゼロ円印刷区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _rgdsZeroPrtDiv;

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// <summary>入出荷数区分</summary>
        ///// <remarks>0:チェック無し　1:警告  2:警告＋再入力(仕入売上同時入力の際の入荷数＜出荷数のチェック）</remarks>
        //private Int32 _ioGoodsCntDiv;

        ///// <summary>入出荷数区分２</summary>
        ///// <remarks>0:チェック無し　1:警告  2:警告＋再入力(仕入売上同時入力の際の入荷数＞出荷数のチェック）</remarks>
        //private Int32 _ioGoodsCntDiv2;

        ///// <summary>仕入形式初期値</summary>
        ///// <remarks>0:仕入　1:入荷　(仕入売上同時入力の初期値設定）</remarks>
        //private Int32 _supplierFormalIni;

        ///// <summary>売上明細確認</summary>
        ///// <remarks>0:任意　1:必須　（仕入売上同時入力の売上明細確認）</remarks>
        //private Int32 _salesSlipDtlConf;
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        /// <summary>定価入力区分</summary>
        /// <remarks>0:可能　1:不可  (仕入明細の定価入力）</remarks>
        private Int32 _listPriceInpDiv;

        /// <summary>単価入力区分</summary>
        /// <remarks>0:可能　1:不可  (仕入明細の仕入単価入力）</remarks>
        private Int32 _unitPriceInpDiv;

        /// <summary>明細備考表示区分</summary>
        /// <remarks>0:有り　1:無し　（無しの場合、画面項目を非表示) </remarks>
        private Int32 _dtlNoteDispDiv;

        /// <summary>自動支払金種コード</summary>
        /// <remarks>エントリでの自動支払の金種</remarks>
        private Int32 _autoPayMoneyKindCode;

        /// <summary>自動支払金種名称</summary>
        /// <remarks>エントリでの自動支払の金種</remarks>
        private string _autoPayMoneyKindName = "";

        /// <summary>自動支払金種区分</summary>
        /// <remarks>エントリでの自動支払の金種</remarks>
        private Int32 _autoPayMoneyKindDiv;

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// <summary>自動支払区分</summary>
        /// <remarks>0:通常支払,1:自動支払（支払伝票入力から発生）</remarks>
        private Int32 _autoPayment;

        /// <summary>定価原価更新区分</summary>
        /// <remarks>0:非更新　1:無条件更新　2:確認更新</remarks>
        private Int32 _priceCostUpdtDiv;

        /// <summary>商品自動登録</summary>
        /// <remarks>0:なし　1:あり</remarks>
        private Int32 _autoEntryGoodsDivCd;

        /// <summary>定価チェック区分</summary>
        /// <remarks>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</remarks>
        private Int32 _priceCheckDivCd;

        /// <summary>仕入単価チェック区分</summary>
        /// <remarks>0:無視　1:再入力　2:警告MSG　（単価≠原価の場合）</remarks>
        private Int32 _stockUnitChgDivCd;

        /// <summary>拠点表示区分</summary>
        /// <remarks>0:標準　1:自社ﾏｽﾀ　2:表示無し</remarks>
        private Int32 _sectDspDivCd;

        /// <summary>伝票日付クリア区分</summary>
        /// <remarks>0:システム日付 1:入力日付</remarks>
        private Int32 _slipDateClrDivCd;

        /// <summary>支払伝票日付クリア区分</summary>
        /// <remarks>0:システム日付に戻す 1:入力日付のまま</remarks>
        private Int32 _paySlipDateClrDiv;

        /// <summary>支払伝票日付範囲区分</summary>
        /// <remarks>0:制限なし 1:システム日付以降入力不可</remarks>
        private Int32 _paySlipDateAmbit;
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>仕入先消費税転嫁方式名称</summary>
        /// <remarks>伝票単位、明細単位、請求単位</remarks>
        private string _suppCTaxLayMethodNm = "";

        // --- ADD 2008/09/12 -------------------------------->>>>>
        /// <summary>在庫検索区分</summary>
        /// <remarks>0:優先倉庫 1:指定倉庫</remarks>
        private Int32 _stockSearchDiv;
        // --- ADD 2008/09/12 --------------------------------<<<<<

        // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
        /// <summary>商品名再表示区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _goodsNmReDispDivCd;
        // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        

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

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>オール０は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  StockAllStMngCd
        /// <summary>仕入在庫全体設定管理コードプロパティ</summary>
        /// <value>常に０設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫全体設定管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAllStMngCd
        {
            get { return _stockAllStMngCd; }
            set { _stockAllStMngCd = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate1
        /// <summary>税率有効日1プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate1
        {
            get { return _validDtConsTaxRate1; }
            set { _validDtConsTaxRate1 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate1JpFormal
        /// <summary>税率有効日1 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日1 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate1JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1JpInFormal
        /// <summary>税率有効日1 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日1 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate1JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1AdFormal
        /// <summary>税率有効日1 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日1 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate1AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1AdInFormal
        /// <summary>税率有効日1 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日1 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate1AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate1
        /// <summary>消費税率1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税率1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate1
        {
            get { return _consTaxRate1; }
            set { _consTaxRate1 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate2
        /// <summary>税率有効日2プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate2
        {
            get { return _validDtConsTaxRate2; }
            set { _validDtConsTaxRate2 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate2JpFormal
        /// <summary>税率有効日2 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日2 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate2JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2JpInFormal
        /// <summary>税率有効日2 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日2 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate2JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2AdFormal
        /// <summary>税率有効日2 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日2 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate2AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2AdInFormal
        /// <summary>税率有効日2 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日2 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate2AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate2
        /// <summary>消費税率2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税率2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate2
        {
            get { return _consTaxRate2; }
            set { _consTaxRate2 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate3
        /// <summary>税率有効日3プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate3
        {
            get { return _validDtConsTaxRate3; }
            set { _validDtConsTaxRate3 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate3JpFormal
        /// <summary>税率有効日3 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日3 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate3JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3JpInFormal
        /// <summary>税率有効日3 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日3 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate3JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3AdFormal
        /// <summary>税率有効日3 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日3 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate3AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3AdInFormal
        /// <summary>税率有効日3 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率有効日3 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ValidDtConsTaxRate3AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate3
        /// <summary>消費税率3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税率3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate3
        {
            get { return _consTaxRate3; }
            set { _consTaxRate3 = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// public propaty name  :  StockDiscountName
        /// <summary>仕入値引名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDiscountName
        {
            get { return _stockDiscountName; }
            set { _stockDiscountName = value; }
        }

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  PartsUnitPrcZeroCd
        /// <summary>部品単価0区分プロパティ</summary>
        /// <value>0:提供データを参照しない,1:提供データを参照する　※１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品単価0区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsUnitPrcZeroCd
        {
            get { return _partsUnitPrcZeroCd; }
            set { _partsUnitPrcZeroCd = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税</value>
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
            --- DEL 2008/06/05 --------------------------------<<<<< */

        /// public propaty name  :  RgdsSlipPrtDiv
        /// <summary>返品伝票発行区分プロパティ</summary>
        /// <value>0:しない　1:する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RgdsSlipPrtDiv
        {
            get { return _rgdsSlipPrtDiv; }
            set { _rgdsSlipPrtDiv = value; }
        }

        /// public propaty name  :  RgdsUnPrcPrtDiv
        /// <summary>返品時単価印刷区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品時単価印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RgdsUnPrcPrtDiv
        {
            get { return _rgdsUnPrcPrtDiv; }
            set { _rgdsUnPrcPrtDiv = value; }
        }

        /// public propaty name  :  RgdsZeroPrtDiv
        /// <summary>返品時ゼロ円印刷区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品時ゼロ円印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RgdsZeroPrtDiv
        {
            get { return _rgdsZeroPrtDiv; }
            set { _rgdsZeroPrtDiv = value; }
        }

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// public propaty name  :  IoGoodsCntDiv
        ///// <summary>入出荷数区分プロパティ</summary>
        ///// <value>0:チェック無し　1:警告  2:警告＋再入力(仕入売上同時入力の際の入荷数＜出荷数のチェック）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   入出荷数区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv
        //{
        //    get { return _ioGoodsCntDiv; }
        //    set { _ioGoodsCntDiv = value; }
        //}

        ///// public propaty name  :  IoGoodsCntDiv2
        ///// <summary>入出荷数区分２プロパティ</summary>
        ///// <value>0:チェック無し　1:警告  2:警告＋再入力(仕入売上同時入力の際の入荷数＞出荷数のチェック）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   入出荷数区分２プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv2
        //{
        //    get { return _ioGoodsCntDiv2; }
        //    set { _ioGoodsCntDiv2 = value; }
        //}

        ///// public propaty name  :  SupplierFormalIni
        ///// <summary>仕入形式初期値プロパティ</summary>
        ///// <value>0:仕入　1:入荷　(仕入売上同時入力の初期値設定）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入形式初期値プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SupplierFormalIni
        //{
        //    get { return _supplierFormalIni; }
        //    set { _supplierFormalIni = value; }
        //}

        ///// public propaty name  :  SalesSlipDtlConf
        ///// <summary>売上明細確認プロパティ</summary>
        ///// <value>0:任意　1:必須　（仕入売上同時入力の売上明細確認）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   売上明細確認プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SalesSlipDtlConf
        //{
        //    get { return _salesSlipDtlConf; }
        //    set { _salesSlipDtlConf = value; }
        //}
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        /// public propaty name  :  ListPriceInpDiv
        /// <summary>定価入力区分プロパティ</summary>
        /// <value>0:可能　1:不可  (仕入明細の定価入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価入力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPriceInpDiv
        {
            get { return _listPriceInpDiv; }
            set { _listPriceInpDiv = value; }
        }

        /// public propaty name  :  UnitPriceInpDiv
        /// <summary>単価入力区分プロパティ</summary>
        /// <value>0:可能　1:不可  (仕入明細の仕入単価入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価入力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnitPriceInpDiv
        {
            get { return _unitPriceInpDiv; }
            set { _unitPriceInpDiv = value; }
        }

        /// public propaty name  :  DtlNoteDispDiv
        /// <summary>明細備考表示区分プロパティ</summary>
        /// <value>0:有り　1:無し　（無しの場合、画面項目を非表示) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlNoteDispDiv
        {
            get { return _dtlNoteDispDiv; }
            set { _dtlNoteDispDiv = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindCode
        /// <summary>自動支払金種コードプロパティ</summary>
        /// <value>エントリでの自動支払の金種</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayMoneyKindCode
        {
            get { return _autoPayMoneyKindCode; }
            set { _autoPayMoneyKindCode = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindName
        /// <summary>自動支払金種名称プロパティ</summary>
        /// <value>エントリでの自動支払の金種</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AutoPayMoneyKindName
        {
            get { return _autoPayMoneyKindName; }
            set { _autoPayMoneyKindName = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindDiv
        /// <summary>自動支払金種区分プロパティ</summary>
        /// <value>エントリでの自動支払の金種</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoPayMoneyKindDiv
        {
            get { return _autoPayMoneyKindDiv; }
            set { _autoPayMoneyKindDiv = value; }
        }

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  AutoPayment
        /// <summary>自動支払区分プロパティ</summary>
        /// <value>0:通常支払,1:自動支払（支払伝票入力から発生）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動支払区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  PriceCostUpdtDiv
        /// <summary>定価原価更新区分プロパティ</summary>
        /// <value>0:非更新　1:無条件更新　2:確認更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価原価更新区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PriceCostUpdtDiv
        {
            get { return _priceCostUpdtDiv; }
            set { _priceCostUpdtDiv = value; }
        }

        /// public propaty name  :  AutoEntryGoodsDivCd
        /// <summary>商品自動登録プロパティ</summary>
        /// <value>0:なし　1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品自動登録プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 AutoEntryGoodsDivCd
        {
            get { return _autoEntryGoodsDivCd; }
            set { _autoEntryGoodsDivCd = value; }
        }

        /// public propaty name  :  PriceCheckDivCd
        /// <summary>定価チェック区分プロパティ</summary>
        /// <value>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価チェック区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PriceCheckDivCd
        {
            get { return _priceCheckDivCd; }
            set { _priceCheckDivCd = value; }
        }

        /// public propaty name  :  StockUnitChgDivCd
        /// <summary>仕入単価チェック区分プロパティ</summary>
        /// <value>0:無視　1:再入力　2:警告MSG　（単価≠原価の場合）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価チェック区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 StockUnitChgDivCd
        {
            get { return _stockUnitChgDivCd; }
            set { _stockUnitChgDivCd = value; }
        }

        /// public propaty name  :  SectDspDivCd
        /// <summary>拠点表示区分プロパティ</summary>
        /// <value>0:標準　1:自社ﾏｽﾀ　2:表示無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SectDspDivCd
        {
            get { return _sectDspDivCd; }
            set { _sectDspDivCd = value; }
        }

        /// public propaty name  :  SlipDateClrDivCd
        /// <summary>伝票日付クリア区分プロパティ</summary>
        /// <value>0:システム日付 1:入力日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票日付クリア区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SlipDateClrDivCd
        {
            get { return _slipDateClrDivCd; }
            set { _slipDateClrDivCd = value; }
        }

        /// public propaty name  :  PaySlipDateClrDiv
        /// <summary>支払伝票日付クリア区分プロパティ</summary>
        /// <value>0:システム日付に戻す 1:入力日付のまま</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票日付クリア区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PaySlipDateClrDiv
        {
            get { return _paySlipDateClrDiv; }
            set { _paySlipDateClrDiv = value; }
        }

        /// public propaty name  :  PaySlipDateAmbit
        /// <summary>支払伝票日付範囲区分プロパティ</summary>
        /// <value>0:制限なし 1:システム日付以降入力不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票日付範囲区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PaySlipDateAmbit
        {
            get { return _paySlipDateAmbit; }
            set { _paySlipDateAmbit = value; }
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

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

        // --- ADD 2008/09/12 -------------------------------->>>>>
        /// public propaty name  :  StockSearchDiv
        /// <summary>在庫検索区分プロパティ</summary>
        /// <value>0:優先倉庫 1:指定倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSearchDiv
        {
            get { return _stockSearchDiv; }
            set { _stockSearchDiv = value; }
        }
        // --- ADD 2008/09/12 --------------------------------<<<<<

        // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
        /// public propaty name  :  StockSearchDiv
        /// <summary>商品名再表示区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名再表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNmReDispDivCd
        {
            get { return _goodsNmReDispDivCd; }
            set { _goodsNmReDispDivCd = value; }
        }
        // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        
        /// <summary>
        /// 仕入在庫全体設定マスタコンストラクタ
        /// </summary>
        /// <returns>StockTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTtlSt()
        {
        }

        /// <summary>
        /// 仕入在庫全体設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード（オール０は全社）</param>  // ADD 2008/06/05
        /// <param name="stockDiscountName">仕入値引名称</param>
        /// <param name="rgdsSlipPrtDiv">返品伝票発行区分(0:しない　1:する。)</param>
        /// <param name="rgdsUnPrcPrtDiv">返品時単価印刷区分(0:する　1:しない)</param>
        /// <param name="rgdsZeroPrtDiv">返品時ゼロ円印刷区分(0:する　1:しない)</param>
        /// <param name="listPriceInpDiv">定価入力区分(0:可能　1:不可  (仕入明細の定価入力）)</param>
        /// <param name="unitPriceInpDiv">単価入力区分(0:可能　1:不可  (仕入明細の仕入単価入力）)</param>
        /// <param name="dtlNoteDispDiv">明細備考表示区分(0:有り　1:無し　（無しの場合、画面項目を非表示) )</param>
        /// <param name="autoPayMoneyKindCode">自動支払金種コード(エントリでの自動支払の金種)</param>
        /// <param name="autoPayMoneyKindName">自動支払金種名称(エントリでの自動支払の金種)</param>
        /// <param name="autoPayMoneyKindDiv">自動支払金種区分(エントリでの自動支払の金種)</param>
        /// <param name="autoPayment">自動支払区分（0:通常支払,1:自動支払（支払伝票入力から発生））</param>
        /// <param name="priceCostUpdtDiv">定価原価更新区分（0:非更新　1:無条件更新　2:確認更新）</param>
        /// <param name="autoEntryGoodsDivCd">商品自動登録（0:なし　1:あり）</param>
        /// <param name="priceCheckDivCd">定価チェック区分（0:無視　1:再入力　2:警告MSG　（定価＜単価の場合））</param>
        /// <param name="stockUnitChgDivCd">仕入単価チェック区分（0:無視　1:再入力　2:警告MSG　（単価≠原価の場合））</param>
        /// <param name="sectDspDivCd">拠点表示区分（0:標準　1:自社ﾏｽﾀ　2:表示無し）</param>
        /// <param name="slipDateClrDivCd">伝票日付クリア区分（0:システム日付 1:入力日付）</param>
        /// <param name="paySlipDateClrDiv">支払伝票日付クリア区分（0:システム日付に戻す 1:入力日付のまま）</param>
        /// <param name="paySlipDateAmbit">支払伝票日付範囲区分（0:制限なし 1:システム日付以降入力不可）</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="suppCTaxLayMethodNm">仕入先消費税転嫁方式名称(伝票単位、明細単位、請求単位)</param>
        /// <param name="stockSearchDiv">在庫検索区分</param>
        /// <param name="goodsNmReDispDivCd">商品名再表示区分</param>
        /// <returns>StockTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockAllStMngCd, DateTime validDtConsTaxRate1, Double consTaxRate1, DateTime validDtConsTaxRate2, Double consTaxRate2, DateTime validDtConsTaxRate3, Double consTaxRate3, Int32 totalAmountDispWayCd, string stockDiscountName, Int32 partsUnitPrcZeroCd, Int32 suppCTaxLayCd, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 ioGoodsCntDiv, Int32 ioGoodsCntDiv2, Int32 supplierFormalIni, Int32 salesSlipDtlConf, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm)  // DEL 2008/06/05
        //public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string stockDiscountName, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm, Int32 autoPayment, Int32 priceCostUpdtDiv, Int32 autoEntryGoodsDivCd, Int32 priceCheckDivCd, Int32 stockUnitChgDivCd, Int32 sectDspDivCd, Int32 slipDateClrDivCd, Int32 paySlipDateClrDiv, Int32 paySlipDateAmbit, Int32 stockSearchDiv)  // ADD 2008/06/05
        public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string stockDiscountName, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm, Int32 autoPayment, Int32 priceCostUpdtDiv, Int32 autoEntryGoodsDivCd, Int32 priceCheckDivCd, Int32 stockUnitChgDivCd, Int32 sectDspDivCd, Int32 slipDateClrDivCd, Int32 paySlipDateClrDiv, Int32 paySlipDateAmbit, Int32 stockSearchDiv, Int32 goodsNmReDispDivCd)  // ADD 2009.04.02
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;  // ADD 2008/06/05
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            this._stockAllStMngCd = stockAllStMngCd;
            this.ValidDtConsTaxRate1 = validDtConsTaxRate1;
            this._consTaxRate1 = consTaxRate1;
            this.ValidDtConsTaxRate2 = validDtConsTaxRate2;
            this._consTaxRate2 = consTaxRate2;
            this.ValidDtConsTaxRate3 = validDtConsTaxRate3;
            this._consTaxRate3 = consTaxRate3;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
               --- DEL 2008/06/05 --------------------------------<<<<< */
            this._stockDiscountName = stockDiscountName;
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            this._partsUnitPrcZeroCd = partsUnitPrcZeroCd;
            this._suppCTaxLayCd = suppCTaxLayCd;
               --- DEL 2008/06/05 --------------------------------<<<<< */
            this._rgdsSlipPrtDiv = rgdsSlipPrtDiv;
            this._rgdsUnPrcPrtDiv = rgdsUnPrcPrtDiv;
            this._rgdsZeroPrtDiv = rgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this._ioGoodsCntDiv = ioGoodsCntDiv;
            //this._ioGoodsCntDiv2 = ioGoodsCntDiv2;
            //this._supplierFormalIni = supplierFormalIni;
            //this._salesSlipDtlConf = salesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            this._listPriceInpDiv = listPriceInpDiv;
            this._unitPriceInpDiv = unitPriceInpDiv;
            this._dtlNoteDispDiv = dtlNoteDispDiv;
            this._autoPayMoneyKindCode = autoPayMoneyKindCode;
            this._autoPayMoneyKindName = autoPayMoneyKindName;
            this._autoPayMoneyKindDiv = autoPayMoneyKindDiv;
            // --- ADD 2008/06/05 -------------------------------->>>>>
            this._autoPayment = autoPayment;
            this._priceCostUpdtDiv = priceCostUpdtDiv;
            this._autoEntryGoodsDivCd = autoEntryGoodsDivCd;
            this._priceCheckDivCd = priceCheckDivCd;
            this._stockUnitChgDivCd = stockUnitChgDivCd;
            this._sectDspDivCd = sectDspDivCd;
            this._slipDateClrDivCd = slipDateClrDivCd;
            this._paySlipDateClrDiv = paySlipDateClrDiv;
            this._paySlipDateAmbit = paySlipDateAmbit;
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            // --- ADD 2008/09/12 -------------------------------->>>>>
            this._stockSearchDiv = stockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            this._goodsNmReDispDivCd = goodsNmReDispDivCd;
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ複製処理
        /// </summary>
        /// <returns>StockTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockTtlStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockTtlSt Clone()
        {
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockAllStMngCd, this._validDtConsTaxRate1, this._consTaxRate1, this._validDtConsTaxRate2, this._consTaxRate2, this._validDtConsTaxRate3, this._consTaxRate3, this._totalAmountDispWayCd, this._stockDiscountName, this._partsUnitPrcZeroCd, this._suppCTaxLayCd, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._ioGoodsCntDiv, this._ioGoodsCntDiv2, this._supplierFormalIni, this._salesSlipDtlConf, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm);  // DEL 2008/06/05
            // --- DEL 2008/09/12 -------------------------------->>>>>
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit);  // ADD 2008/06/05
            // --- DEL 2008/09/12 --------------------------------<<<<<
            // --- ADD 2008/09/12 -------------------------------->>>>>
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit, this._stockSearchDiv);
            // --- ADD 2008/09/12 --------------------------------<<<<<
            return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit, this._stockSearchDiv, this._goodsNmReDispDivCd);   // ADD 2009.04.02
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockTtlSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)  // ADD 2008/06/05
                 /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (this.StockAllStMngCd == target.StockAllStMngCd)
                && (this.ValidDtConsTaxRate1 == target.ValidDtConsTaxRate1)
                && (this.ConsTaxRate1 == target.ConsTaxRate1)
                && (this.ValidDtConsTaxRate2 == target.ValidDtConsTaxRate2)
                && (this.ConsTaxRate2 == target.ConsTaxRate2)
                && (this.ValidDtConsTaxRate3 == target.ValidDtConsTaxRate3)
                && (this.ConsTaxRate3 == target.ConsTaxRate3)
                && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                    --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (this.StockDiscountName == target.StockDiscountName)
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (this.PartsUnitPrcZeroCd == target.PartsUnitPrcZeroCd)
                && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (this.RgdsSlipPrtDiv == target.RgdsSlipPrtDiv)
                 && (this.RgdsUnPrcPrtDiv == target.RgdsUnPrcPrtDiv)
                 && (this.RgdsZeroPrtDiv == target.RgdsZeroPrtDiv)

                 // --- DEL 2008/07/22 -------------------------------->>>>>
                 //&& (this.IoGoodsCntDiv == target.IoGoodsCntDiv)
                 //&& (this.IoGoodsCntDiv2 == target.IoGoodsCntDiv2)
                 //&& (this.SupplierFormalIni == target.SupplierFormalIni)
                 //&& (this.SalesSlipDtlConf == target.SalesSlipDtlConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

                 && (this.ListPriceInpDiv == target.ListPriceInpDiv)
                 && (this.UnitPriceInpDiv == target.UnitPriceInpDiv)
                 && (this.DtlNoteDispDiv == target.DtlNoteDispDiv)
                 && (this.AutoPayMoneyKindCode == target.AutoPayMoneyKindCode)
                 && (this.AutoPayMoneyKindName == target.AutoPayMoneyKindName)
                 && (this.AutoPayMoneyKindDiv == target.AutoPayMoneyKindDiv)
                 // --- ADD 2008/06/05 -------------------------------->>>>>
                 && (this.AutoPayment == target.AutoPayment)      
                 && (this.PriceCostUpdtDiv == target.PriceCostUpdtDiv)
                 && (this.AutoEntryGoodsDivCd == target.AutoEntryGoodsDivCd)
                 && (this.PriceCheckDivCd == target.PriceCheckDivCd)
                 && (this.StockUnitChgDivCd == target.StockUnitChgDivCd)
                 && (this.SectDspDivCd == target.SectDspDivCd)
                 && (this.SlipDateClrDivCd == target.SlipDateClrDivCd)
                 && (this.PaySlipDateClrDiv == target.PaySlipDateClrDiv)
                 && (this.PaySlipDateAmbit == target.PaySlipDateAmbit)
                 // --- ADD 2008/06/05 --------------------------------<<<<< 
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                // --- ADD 2008/09/12 -------------------------------->>>>>
                 //&& (this.StockSearchDiv == target.StockSearchDiv));
                 // --- ADD 2008/09/12 --------------------------------<<<<<
                 // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
                 && (this.StockSearchDiv == target.StockSearchDiv)
                 && (this.GoodsNmReDispDivCd == target.GoodsNmReDispDivCd));
                 // 2009.04.02 30413 犬飼 項目追加 <<<<<<END

        }

        /// <summary>
        /// 仕入在庫全体設定マスタ比較処理
        /// </summary>
        /// <param name="stockTtlSt1">
        ///                    比較するStockTtlStクラスのインスタンス
        /// </param>
        /// <param name="stockTtlSt2">比較するStockTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockTtlSt stockTtlSt1, StockTtlSt stockTtlSt2)
        {
            return ((stockTtlSt1.CreateDateTime == stockTtlSt2.CreateDateTime)
                 && (stockTtlSt1.UpdateDateTime == stockTtlSt2.UpdateDateTime)
                 && (stockTtlSt1.EnterpriseCode == stockTtlSt2.EnterpriseCode)
                 && (stockTtlSt1.FileHeaderGuid == stockTtlSt2.FileHeaderGuid)
                 && (stockTtlSt1.UpdEmployeeCode == stockTtlSt2.UpdEmployeeCode)
                 && (stockTtlSt1.UpdAssemblyId1 == stockTtlSt2.UpdAssemblyId1)
                 && (stockTtlSt1.UpdAssemblyId2 == stockTtlSt2.UpdAssemblyId2)
                 && (stockTtlSt1.LogicalDeleteCode == stockTtlSt2.LogicalDeleteCode)
                 && (stockTtlSt1.SectionCode == stockTtlSt2.SectionCode)  // ADD 2008/06/05
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (stockTtlSt1.StockAllStMngCd == stockTtlSt2.StockAllStMngCd)
                && (stockTtlSt1.ValidDtConsTaxRate1 == stockTtlSt2.ValidDtConsTaxRate1)
                && (stockTtlSt1.ConsTaxRate1 == stockTtlSt2.ConsTaxRate1)
                && (stockTtlSt1.ValidDtConsTaxRate2 == stockTtlSt2.ValidDtConsTaxRate2)
                && (stockTtlSt1.ConsTaxRate2 == stockTtlSt2.ConsTaxRate2)
                && (stockTtlSt1.ValidDtConsTaxRate3 == stockTtlSt2.ValidDtConsTaxRate3)
                && (stockTtlSt1.ConsTaxRate3 == stockTtlSt2.ConsTaxRate3)
                && (stockTtlSt1.TotalAmountDispWayCd == stockTtlSt2.TotalAmountDispWayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (stockTtlSt1.StockDiscountName == stockTtlSt2.StockDiscountName)
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (stockTtlSt1.PartsUnitPrcZeroCd == stockTtlSt2.PartsUnitPrcZeroCd)
                && (stockTtlSt1.SuppCTaxLayCd == stockTtlSt2.SuppCTaxLayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (stockTtlSt1.RgdsSlipPrtDiv == stockTtlSt2.RgdsSlipPrtDiv)
                 && (stockTtlSt1.RgdsUnPrcPrtDiv == stockTtlSt2.RgdsUnPrcPrtDiv)
                 && (stockTtlSt1.RgdsZeroPrtDiv == stockTtlSt2.RgdsZeroPrtDiv)

                 // --- DEL 2008/07/22 -------------------------------->>>>>
                 //&& (stockTtlSt1.IoGoodsCntDiv == stockTtlSt2.IoGoodsCntDiv)
                 //&& (stockTtlSt1.IoGoodsCntDiv2 == stockTtlSt2.IoGoodsCntDiv2)
                 //&& (stockTtlSt1.SupplierFormalIni == stockTtlSt2.SupplierFormalIni)
                 //&& (stockTtlSt1.SalesSlipDtlConf == stockTtlSt2.SalesSlipDtlConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

                 && (stockTtlSt1.ListPriceInpDiv == stockTtlSt2.ListPriceInpDiv)
                 && (stockTtlSt1.UnitPriceInpDiv == stockTtlSt2.UnitPriceInpDiv)
                 && (stockTtlSt1.DtlNoteDispDiv == stockTtlSt2.DtlNoteDispDiv)
                 && (stockTtlSt1.AutoPayMoneyKindCode == stockTtlSt2.AutoPayMoneyKindCode)
                 && (stockTtlSt1.AutoPayMoneyKindName == stockTtlSt2.AutoPayMoneyKindName)
                 && (stockTtlSt1.AutoPayMoneyKindDiv == stockTtlSt2.AutoPayMoneyKindDiv)
                 // --- ADD 2008/06/05 -------------------------------->>>>>
                 && (stockTtlSt1.AutoPayment == stockTtlSt2.AutoPayment)
                 && (stockTtlSt1.PriceCostUpdtDiv == stockTtlSt2.PriceCostUpdtDiv)
                 && (stockTtlSt1.AutoEntryGoodsDivCd == stockTtlSt2.AutoEntryGoodsDivCd)
                 && (stockTtlSt1.PriceCheckDivCd == stockTtlSt2.PriceCheckDivCd)
                 && (stockTtlSt1.StockUnitChgDivCd == stockTtlSt2.StockUnitChgDivCd)
                 && (stockTtlSt1.SectDspDivCd == stockTtlSt2.SectDspDivCd)
                 && (stockTtlSt1.SlipDateClrDivCd == stockTtlSt2.SlipDateClrDivCd)
                 && (stockTtlSt1.PaySlipDateClrDiv == stockTtlSt2.PaySlipDateClrDiv)
                 && (stockTtlSt1.PaySlipDateAmbit == stockTtlSt2.PaySlipDateAmbit)
                 // --- ADD 2008/06/05 --------------------------------<<<<< 
                 && (stockTtlSt1.EnterpriseName == stockTtlSt2.EnterpriseName)
                 && (stockTtlSt1.UpdEmployeeName == stockTtlSt2.UpdEmployeeName)
                 && (stockTtlSt1.SuppCTaxLayMethodNm == stockTtlSt2.SuppCTaxLayMethodNm)
                 // --- ADD 2008/09/12 -------------------------------->>>>>
                 //&& (stockTtlSt1.StockSearchDiv == stockTtlSt2.StockSearchDiv));
                 // --- ADD 2008/09/12 --------------------------------<<<<<
                 // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
                 && (stockTtlSt1.StockSearchDiv == stockTtlSt2.StockSearchDiv)
                 && (stockTtlSt1.GoodsNmReDispDivCd == stockTtlSt2.GoodsNmReDispDivCd));
                 // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        }
        /// <summary>
        /// 仕入在庫全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockTtlSt target)
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
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (this.StockAllStMngCd != target.StockAllStMngCd) resList.Add("StockAllStMngCd");
            if (this.ValidDtConsTaxRate1 != target.ValidDtConsTaxRate1) resList.Add("ValidDtConsTaxRate1");
            if (this.ConsTaxRate1 != target.ConsTaxRate1) resList.Add("ConsTaxRate1");
            if (this.ValidDtConsTaxRate2 != target.ValidDtConsTaxRate2) resList.Add("ValidDtConsTaxRate2");
            if (this.ConsTaxRate2 != target.ConsTaxRate2) resList.Add("ConsTaxRate2");
            if (this.ValidDtConsTaxRate3 != target.ValidDtConsTaxRate3) resList.Add("ValidDtConsTaxRate3");
            if (this.ConsTaxRate3 != target.ConsTaxRate3) resList.Add("ConsTaxRate3");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (this.StockDiscountName != target.StockDiscountName) resList.Add("StockDiscountName");
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (this.PartsUnitPrcZeroCd != target.PartsUnitPrcZeroCd) resList.Add("PartsUnitPrcZeroCd");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (this.RgdsSlipPrtDiv != target.RgdsSlipPrtDiv) resList.Add("RgdsSlipPrtDiv");
            if (this.RgdsUnPrcPrtDiv != target.RgdsUnPrcPrtDiv) resList.Add("RgdsUnPrcPrtDiv");
            if (this.RgdsZeroPrtDiv != target.RgdsZeroPrtDiv) resList.Add("RgdsZeroPrtDiv");

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //if (this.IoGoodsCntDiv != target.IoGoodsCntDiv) resList.Add("IoGoodsCntDiv");
            //if (this.IoGoodsCntDiv2 != target.IoGoodsCntDiv2) resList.Add("IoGoodsCntDiv2");
            //if (this.SupplierFormalIni != target.SupplierFormalIni) resList.Add("SupplierFormalIni");
            //if (this.SalesSlipDtlConf != target.SalesSlipDtlConf) resList.Add("SalesSlipDtlConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            if (this.ListPriceInpDiv != target.ListPriceInpDiv) resList.Add("ListPriceInpDiv");
            if (this.UnitPriceInpDiv != target.UnitPriceInpDiv) resList.Add("UnitPriceInpDiv");
            if (this.DtlNoteDispDiv != target.DtlNoteDispDiv) resList.Add("DtlNoteDispDiv");
            if (this.AutoPayMoneyKindCode != target.AutoPayMoneyKindCode) resList.Add("AutoPayMoneyKindCode");
            if (this.AutoPayMoneyKindName != target.AutoPayMoneyKindName) resList.Add("AutoPayMoneyKindName");
            if (this.AutoPayMoneyKindDiv != target.AutoPayMoneyKindDiv) resList.Add("AutoPayMoneyKindDiv");
            // --- ADD 2008/06/05 -------------------------------->>>>>
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.PriceCostUpdtDiv != target.PriceCostUpdtDiv) resList.Add("PriceCostUpdtDiv");
            if (this.AutoEntryGoodsDivCd != target.AutoEntryGoodsDivCd) resList.Add("AutoEntryGoodsDivCd");
            if (this.PriceCheckDivCd != target.PriceCheckDivCd) resList.Add("PriceCheckDivCd");
            if (this.StockUnitChgDivCd != target.StockUnitChgDivCd) resList.Add("StockUnitChgDivCd");
            if (this.SectDspDivCd != target.SectDspDivCd) resList.Add("SectDspDivCd");
            if (this.SlipDateClrDivCd != target.SlipDateClrDivCd) resList.Add("SlipDateClrDivCd");
            if (this.PaySlipDateClrDiv != target.PaySlipDateClrDiv) resList.Add("PaySlipDateClrDiv");
            if (this.PaySlipDateAmbit != target.PaySlipDateAmbit) resList.Add("PaySlipDateAmbit");
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            // --- ADD 2008/09/12 -------------------------------->>>>>
            if (this.StockSearchDiv != target.StockSearchDiv) resList.Add("StockSearchDiv");
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            if (this.GoodsNmReDispDivCd != target.GoodsNmReDispDivCd) resList.Add("GoodsNmReDispDivCd");
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
            return resList;
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ比較処理
        /// </summary>
        /// <param name="stockTtlSt1">比較するStockTtlStクラスのインスタンス</param>
        /// <param name="stockTtlSt2">比較するStockTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockTtlSt stockTtlSt1, StockTtlSt stockTtlSt2)
        {
            ArrayList resList = new ArrayList();
            if (stockTtlSt1.CreateDateTime != stockTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockTtlSt1.UpdateDateTime != stockTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockTtlSt1.EnterpriseCode != stockTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockTtlSt1.FileHeaderGuid != stockTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockTtlSt1.UpdEmployeeCode != stockTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockTtlSt1.UpdAssemblyId1 != stockTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockTtlSt1.UpdAssemblyId2 != stockTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockTtlSt1.LogicalDeleteCode != stockTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockTtlSt1.SectionCode != stockTtlSt2.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/05
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.StockAllStMngCd != stockTtlSt2.StockAllStMngCd) resList.Add("StockAllStMngCd");
            if (stockTtlSt1.ValidDtConsTaxRate1 != stockTtlSt2.ValidDtConsTaxRate1) resList.Add("ValidDtConsTaxRate1");
            if (stockTtlSt1.ConsTaxRate1 != stockTtlSt2.ConsTaxRate1) resList.Add("ConsTaxRate1");
            if (stockTtlSt1.ValidDtConsTaxRate2 != stockTtlSt2.ValidDtConsTaxRate2) resList.Add("ValidDtConsTaxRate2");
            if (stockTtlSt1.ConsTaxRate2 != stockTtlSt2.ConsTaxRate2) resList.Add("ConsTaxRate2");
            if (stockTtlSt1.ValidDtConsTaxRate3 != stockTtlSt2.ValidDtConsTaxRate3) resList.Add("ValidDtConsTaxRate3");
            if (stockTtlSt1.ConsTaxRate3 != stockTtlSt2.ConsTaxRate3) resList.Add("ConsTaxRate3");
            if (stockTtlSt1.TotalAmountDispWayCd != stockTtlSt2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (stockTtlSt1.StockDiscountName != stockTtlSt2.StockDiscountName) resList.Add("StockDiscountName");
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.PartsUnitPrcZeroCd != stockTtlSt2.PartsUnitPrcZeroCd) resList.Add("PartsUnitPrcZeroCd");
            if (stockTtlSt1.SuppCTaxLayCd != stockTtlSt2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (stockTtlSt1.RgdsSlipPrtDiv != stockTtlSt2.RgdsSlipPrtDiv) resList.Add("RgdsSlipPrtDiv");
            if (stockTtlSt1.RgdsUnPrcPrtDiv != stockTtlSt2.RgdsUnPrcPrtDiv) resList.Add("RgdsUnPrcPrtDiv");
            if (stockTtlSt1.RgdsZeroPrtDiv != stockTtlSt2.RgdsZeroPrtDiv) resList.Add("RgdsZeroPrtDiv");

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //if (stockTtlSt1.IoGoodsCntDiv != stockTtlSt2.IoGoodsCntDiv) resList.Add("IoGoodsCntDiv");
            //if (stockTtlSt1.IoGoodsCntDiv2 != stockTtlSt2.IoGoodsCntDiv2) resList.Add("IoGoodsCntDiv2");
            //if (stockTtlSt1.SupplierFormalIni != stockTtlSt2.SupplierFormalIni) resList.Add("SupplierFormalIni");
            //if (stockTtlSt1.SalesSlipDtlConf != stockTtlSt2.SalesSlipDtlConf) resList.Add("SalesSlipDtlConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            if (stockTtlSt1.ListPriceInpDiv != stockTtlSt2.ListPriceInpDiv) resList.Add("ListPriceInpDiv");
            if (stockTtlSt1.UnitPriceInpDiv != stockTtlSt2.UnitPriceInpDiv) resList.Add("UnitPriceInpDiv");
            if (stockTtlSt1.DtlNoteDispDiv != stockTtlSt2.DtlNoteDispDiv) resList.Add("DtlNoteDispDiv");
            if (stockTtlSt1.AutoPayMoneyKindCode != stockTtlSt2.AutoPayMoneyKindCode) resList.Add("AutoPayMoneyKindCode");
            if (stockTtlSt1.AutoPayMoneyKindName != stockTtlSt2.AutoPayMoneyKindName) resList.Add("AutoPayMoneyKindName");
            if (stockTtlSt1.AutoPayMoneyKindDiv != stockTtlSt2.AutoPayMoneyKindDiv) resList.Add("AutoPayMoneyKindDiv");
            // --- ADD 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.AutoPayment != stockTtlSt2.AutoPayment) resList.Add("AutoPayment");
            if (stockTtlSt1.PriceCostUpdtDiv != stockTtlSt2.PriceCostUpdtDiv) resList.Add("PriceCostUpdtDiv");
            if (stockTtlSt1.AutoEntryGoodsDivCd != stockTtlSt2.AutoEntryGoodsDivCd) resList.Add("AutoEntryGoodsDivCd");
            if (stockTtlSt1.PriceCheckDivCd != stockTtlSt2.PriceCheckDivCd) resList.Add("PriceCheckDivCd");
            if (stockTtlSt1.StockUnitChgDivCd != stockTtlSt2.StockUnitChgDivCd) resList.Add("StockUnitChgDivCd");
            if (stockTtlSt1.SectDspDivCd != stockTtlSt2.SectDspDivCd) resList.Add("SectDspDivCd");
            if (stockTtlSt1.SlipDateClrDivCd != stockTtlSt2.SlipDateClrDivCd) resList.Add("SlipDateClrDivCd");
            if (stockTtlSt1.PaySlipDateClrDiv != stockTtlSt2.PaySlipDateClrDiv) resList.Add("PaySlipDateClrDiv");
            if (stockTtlSt1.PaySlipDateAmbit != stockTtlSt2.PaySlipDateAmbit) resList.Add("PaySlipDateAmbit");
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            if (stockTtlSt1.EnterpriseName != stockTtlSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockTtlSt1.UpdEmployeeName != stockTtlSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockTtlSt1.SuppCTaxLayMethodNm != stockTtlSt2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            // --- ADD 2008/09/12 -------------------------------->>>>>
            if (stockTtlSt1.StockSearchDiv != stockTtlSt2.StockSearchDiv) resList.Add("StockSearchDiv");
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            if (stockTtlSt1.GoodsNmReDispDivCd != stockTtlSt2.GoodsNmReDispDivCd) resList.Add("GoodsNmReDispDivCd");
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
            
            return resList;
        }
        //----- ueno add ---------- start 2008.02.18
        /// <summary>自動支払金種リスト</summary>
        public static SortedList _autoPayMoneyKindCodeList;

        /// <summary>金額種別区分リスト</summary>
        public static SortedList _mnyKindDivList;

        /// <summary>
        /// コンボボックス名称取得処理
        /// </summary>
        /// <param name="code">コンボボックスコード</param>
        /// <param name="sList">ソートリスト</param>
        /// <returns>コンボボックス名称</returns>
        /// <remarks>
        /// <br>Note       : コンボボックスコードからコンボボックス名称を取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.02.18</br>
        /// </remarks>
        public static string GetComboBoxNm(int code, SortedList sList)
        {
            string retStr = "";

            if (sList.ContainsKey((object)code))
            {
                retStr = sList[code].ToString();
            }
            return retStr;
        }
        //----- ueno add ---------- end 2008.02.18
    }
}
