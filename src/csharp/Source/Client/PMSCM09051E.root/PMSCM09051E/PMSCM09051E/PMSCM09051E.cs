//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM相場価格設定マスタ
// プログラム概要   : SCM相場価格設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/12  修正内容 : 相場価格品質コード２、相場価格品質コード３の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SCMMrktPriSt
    /// <summary>
    ///                      SCM相場価格設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM相場価格設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/11  杉村</br>
    /// </remarks>
    public class SCMMrktPriSt
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
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>相場価格地域コード</summary>
        /// <remarks>RCのマスタ</remarks>
        private Int32 _marketPriceAreaCd;

        /// <summary>相場価格品質コード</summary>
        /// <remarks>0:極上 1:良 …RCのマスタ</remarks>
        private Int32 _marketPriceQualityCd;

        /// <summary>相場価格種別コード１</summary>
        /// <remarks>0:新品 1:リビルト 2:中古 …RCのマスタ</remarks>
        private Int32 _marketPriceKindCd1;

        /// <summary>相場価格種別コード２</summary>
        /// <remarks>-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ</remarks>
        private Int32 _marketPriceKindCd2;

        /// <summary>相場価格種別コード３</summary>
        /// <remarks>-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ</remarks>
        private Int32 _marketPriceKindCd3;

        /// <summary>相場価格回答区分</summary>
        /// <remarks>0:しない 1:する(売価率) 1:する(加算テーブル)</remarks>
        private Int32 _marketPriceAnswerDiv;

        /// <summary>相場価格売価率</summary>
        /// <remarks>掛率</remarks>
        private Double _marketPriceSalesRate;

        /// <summary>加算額範囲1</summary>
        /// <remarks>１以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit1;

        /// <summary>加算額範囲2</summary>
        /// <remarks>加算テーブル１以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit2;

        /// <summary>加算額範囲3</summary>
        /// <remarks>加算テーブル２以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit3;

        /// <summary>加算額範囲4</summary>
        /// <remarks>加算テーブル３以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit4;

        /// <summary>加算額範囲5</summary>
        /// <remarks>加算テーブル４以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit5;

        /// <summary>加算額範囲6</summary>
        /// <remarks>加算テーブル５以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit6;

        /// <summary>加算額範囲7</summary>
        /// <remarks>加算テーブル６以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit7;

        /// <summary>加算額範囲8</summary>
        /// <remarks>加算テーブル７以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit8;

        /// <summary>加算額範囲9</summary>
        /// <remarks>加算テーブル８以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit9;

        /// <summary>加算額範囲10</summary>
        /// <remarks>加算テーブル９以上～○○円未満</remarks>
        private Int32 _addPaymntAmbit10;

        /// <summary>加算額1</summary>
        /// <remarks>加算テーブル１の加算額</remarks>
        private Int32 _addPaymnt1;

        /// <summary>加算額2</summary>
        /// <remarks>加算テーブル２の加算額</remarks>
        private Int32 _addPaymnt2;

        /// <summary>加算額3</summary>
        /// <remarks>加算テーブル３の加算額</remarks>
        private Int32 _addPaymnt3;

        /// <summary>加算額4</summary>
        /// <remarks>加算テーブル４の加算額</remarks>
        private Int32 _addPaymnt4;

        /// <summary>加算額5</summary>
        /// <remarks>加算テーブル５の加算額</remarks>
        private Int32 _addPaymnt5;

        /// <summary>加算額6</summary>
        /// <remarks>加算テーブル６の加算額</remarks>
        private Int32 _addPaymnt6;

        /// <summary>加算額7</summary>
        /// <remarks>加算テーブル７の加算額</remarks>
        private Int32 _addPaymnt7;

        /// <summary>加算額8</summary>
        /// <remarks>加算テーブル８の加算額</remarks>
        private Int32 _addPaymnt8;

        /// <summary>加算額9</summary>
        /// <remarks>加算テーブル９の加算額</remarks>
        private Int32 _addPaymnt9;

        /// <summary>加算額10</summary>
        /// <remarks>加算テーブル１０の加算額</remarks>
        private Int32 _addPaymnt10;

        /// <summary>端数処理区分</summary>
        /// <remarks>0:１０円単位(四捨五入) 1:１００円単位(四捨五入)</remarks>
        private Int32 _fractionProcCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // 2010/04/12 Add >>>
        /// <summary>相場価格品質コード２</summary>
        /// <remarks>0:極上 1:良 …RCのマスタ</remarks>
        private Int32 _marketPriceQualityCd2;

        /// <summary>相場価格品質コード３</summary>
        /// <remarks>0:極上 1:良 …RCのマスタ</remarks>
        private Int32 _marketPriceQualityCd3;
        // 2010/04/12 Add <<<

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
        /// <value>00は全社</value>
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

        /// public propaty name  :  MarketPriceAreaCd
        /// <summary>相場価格地域コードプロパティ</summary>
        /// <value>RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格地域コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceAreaCd
        {
            get { return _marketPriceAreaCd; }
            set { _marketPriceAreaCd = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd
        /// <summary>相場価格品質コードプロパティ</summary>
        /// <value>0:極上 1:良 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd
        {
            get { return _marketPriceQualityCd; }
            set { _marketPriceQualityCd = value; }
        }

        /// public propaty name  :  MarketPriceKindCd1
        /// <summary>相場価格種別コード１プロパティ</summary>
        /// <value>0:新品 1:リビルト 2:中古 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格種別コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceKindCd1
        {
            get { return _marketPriceKindCd1; }
            set { _marketPriceKindCd1 = value; }
        }

        /// public propaty name  :  MarketPriceKindCd2
        /// <summary>相場価格種別コード２プロパティ</summary>
        /// <value>-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格種別コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceKindCd2
        {
            get { return _marketPriceKindCd2; }
            set { _marketPriceKindCd2 = value; }
        }

        /// public propaty name  :  MarketPriceKindCd3
        /// <summary>相場価格種別コード３プロパティ</summary>
        /// <value>-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格種別コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceKindCd3
        {
            get { return _marketPriceKindCd3; }
            set { _marketPriceKindCd3 = value; }
        }

        /// public propaty name  :  MarketPriceAnswerDiv
        /// <summary>相場価格回答区分プロパティ</summary>
        /// <value>0:しない 1:する(売価率) 1:する(加算テーブル)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceAnswerDiv
        {
            get { return _marketPriceAnswerDiv; }
            set { _marketPriceAnswerDiv = value; }
        }

        /// public propaty name  :  MarketPriceSalesRate
        /// <summary>相場価格売価率プロパティ</summary>
        /// <value>掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MarketPriceSalesRate
        {
            get { return _marketPriceSalesRate; }
            set { _marketPriceSalesRate = value; }
        }

        /// public propaty name  :  AddPaymntAmbit1
        /// <summary>加算額範囲1プロパティ</summary>
        /// <value>１以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit1
        {
            get { return _addPaymntAmbit1; }
            set { _addPaymntAmbit1 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit2
        /// <summary>加算額範囲2プロパティ</summary>
        /// <value>加算テーブル１以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit2
        {
            get { return _addPaymntAmbit2; }
            set { _addPaymntAmbit2 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit3
        /// <summary>加算額範囲3プロパティ</summary>
        /// <value>加算テーブル２以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit3
        {
            get { return _addPaymntAmbit3; }
            set { _addPaymntAmbit3 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit4
        /// <summary>加算額範囲4プロパティ</summary>
        /// <value>加算テーブル３以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit4
        {
            get { return _addPaymntAmbit4; }
            set { _addPaymntAmbit4 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit5
        /// <summary>加算額範囲5プロパティ</summary>
        /// <value>加算テーブル４以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit5
        {
            get { return _addPaymntAmbit5; }
            set { _addPaymntAmbit5 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit6
        /// <summary>加算額範囲6プロパティ</summary>
        /// <value>加算テーブル５以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit6
        {
            get { return _addPaymntAmbit6; }
            set { _addPaymntAmbit6 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit7
        /// <summary>加算額範囲7プロパティ</summary>
        /// <value>加算テーブル６以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit7
        {
            get { return _addPaymntAmbit7; }
            set { _addPaymntAmbit7 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit8
        /// <summary>加算額範囲8プロパティ</summary>
        /// <value>加算テーブル７以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit8
        {
            get { return _addPaymntAmbit8; }
            set { _addPaymntAmbit8 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit9
        /// <summary>加算額範囲9プロパティ</summary>
        /// <value>加算テーブル８以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit9
        {
            get { return _addPaymntAmbit9; }
            set { _addPaymntAmbit9 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit10
        /// <summary>加算額範囲10プロパティ</summary>
        /// <value>加算テーブル９以上～○○円未満</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額範囲10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymntAmbit10
        {
            get { return _addPaymntAmbit10; }
            set { _addPaymntAmbit10 = value; }
        }

        /// public propaty name  :  AddPaymnt1
        /// <summary>加算額1プロパティ</summary>
        /// <value>加算テーブル１の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt1
        {
            get { return _addPaymnt1; }
            set { _addPaymnt1 = value; }
        }

        /// public propaty name  :  AddPaymnt2
        /// <summary>加算額2プロパティ</summary>
        /// <value>加算テーブル２の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt2
        {
            get { return _addPaymnt2; }
            set { _addPaymnt2 = value; }
        }

        /// public propaty name  :  AddPaymnt3
        /// <summary>加算額3プロパティ</summary>
        /// <value>加算テーブル３の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt3
        {
            get { return _addPaymnt3; }
            set { _addPaymnt3 = value; }
        }

        /// public propaty name  :  AddPaymnt4
        /// <summary>加算額4プロパティ</summary>
        /// <value>加算テーブル４の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt4
        {
            get { return _addPaymnt4; }
            set { _addPaymnt4 = value; }
        }

        /// public propaty name  :  AddPaymnt5
        /// <summary>加算額5プロパティ</summary>
        /// <value>加算テーブル５の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt5
        {
            get { return _addPaymnt5; }
            set { _addPaymnt5 = value; }
        }

        /// public propaty name  :  AddPaymnt6
        /// <summary>加算額6プロパティ</summary>
        /// <value>加算テーブル６の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt6
        {
            get { return _addPaymnt6; }
            set { _addPaymnt6 = value; }
        }

        /// public propaty name  :  AddPaymnt7
        /// <summary>加算額7プロパティ</summary>
        /// <value>加算テーブル７の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt7
        {
            get { return _addPaymnt7; }
            set { _addPaymnt7 = value; }
        }

        /// public propaty name  :  AddPaymnt8
        /// <summary>加算額8プロパティ</summary>
        /// <value>加算テーブル８の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt8
        {
            get { return _addPaymnt8; }
            set { _addPaymnt8 = value; }
        }

        /// public propaty name  :  AddPaymnt9
        /// <summary>加算額9プロパティ</summary>
        /// <value>加算テーブル９の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt9
        {
            get { return _addPaymnt9; }
            set { _addPaymnt9 = value; }
        }

        /// public propaty name  :  AddPaymnt10
        /// <summary>加算額10プロパティ</summary>
        /// <value>加算テーブル１０の加算額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   加算額10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddPaymnt10
        {
            get { return _addPaymnt10; }
            set { _addPaymnt10 = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>0:１０円単位(四捨五入) 1:１００円単位(四捨五入)</value>
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

        // 2010/04/12 Add >>>
        /// public propaty name  :  MarketPriceQualityCd2
        /// <summary>相場価格品質コード２プロパティ</summary>
        /// <value>0:極上 1:良 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd2
        {
            get { return _marketPriceQualityCd2; }
            set { _marketPriceQualityCd2 = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd3
        /// <summary>相場価格品質コード３プロパティ</summary>
        /// <value>0:極上 1:良 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd3
        {
            get { return _marketPriceQualityCd3; }
            set { _marketPriceQualityCd3 = value; }
        }
        // 2010/04/12 Add <<<

        /// <summary>
        /// SCM相場価格設定マスタコンストラクタ
        /// </summary>
        /// <returns>SCMMrktPriStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMMrktPriSt()
        {
        }

        /// <summary>
        /// SCM相場価格設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="marketPriceAreaCd">相場価格地域コード(RCのマスタ)</param>
        /// <param name="marketPriceQualityCd">相場価格品質コード(0:極上 1:良 …RCのマスタ)</param>
        /// <param name="marketPriceKindCd1">相場価格種別コード１(0:新品 1:リビルト 2:中古 …RCのマスタ)</param>
        /// <param name="marketPriceKindCd2">相場価格種別コード２(-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ)</param>
        /// <param name="marketPriceKindCd3">相場価格種別コード３(-1:なし 0:新品 1:リビルト 2:中古 …RCのマスタ)</param>
        /// <param name="marketPriceAnswerDiv">相場価格回答区分(0:しない 1:する(売価率) 1:する(加算テーブル))</param>
        /// <param name="marketPriceSalesRate">相場価格売価率(掛率)</param>
        /// <param name="addPaymntAmbit1">加算額範囲1(１以上～○○円未満)</param>
        /// <param name="addPaymntAmbit2">加算額範囲2(加算テーブル１以上～○○円未満)</param>
        /// <param name="addPaymntAmbit3">加算額範囲3(加算テーブル２以上～○○円未満)</param>
        /// <param name="addPaymntAmbit4">加算額範囲4(加算テーブル３以上～○○円未満)</param>
        /// <param name="addPaymntAmbit5">加算額範囲5(加算テーブル４以上～○○円未満)</param>
        /// <param name="addPaymntAmbit6">加算額範囲6(加算テーブル５以上～○○円未満)</param>
        /// <param name="addPaymntAmbit7">加算額範囲7(加算テーブル６以上～○○円未満)</param>
        /// <param name="addPaymntAmbit8">加算額範囲8(加算テーブル７以上～○○円未満)</param>
        /// <param name="addPaymntAmbit9">加算額範囲9(加算テーブル８以上～○○円未満)</param>
        /// <param name="addPaymntAmbit10">加算額範囲10(加算テーブル９以上～○○円未満)</param>
        /// <param name="addPaymnt1">加算額1(加算テーブル１の加算額)</param>
        /// <param name="addPaymnt2">加算額2(加算テーブル２の加算額)</param>
        /// <param name="addPaymnt3">加算額3(加算テーブル３の加算額)</param>
        /// <param name="addPaymnt4">加算額4(加算テーブル４の加算額)</param>
        /// <param name="addPaymnt5">加算額5(加算テーブル５の加算額)</param>
        /// <param name="addPaymnt6">加算額6(加算テーブル６の加算額)</param>
        /// <param name="addPaymnt7">加算額7(加算テーブル７の加算額)</param>
        /// <param name="addPaymnt8">加算額8(加算テーブル８の加算額)</param>
        /// <param name="addPaymnt9">加算額9(加算テーブル９の加算額)</param>
        /// <param name="addPaymnt10">加算額10(加算テーブル１０の加算額)</param>
        /// <param name="fractionProcCd">端数処理区分(0:１０円単位(四捨五入) 1:１００円単位(四捨五入))</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="marketPriceQualityCd2">相場価格品質コード２(0:極上 1:良 …RCのマスタ)</param>
        /// <param name="marketPriceQualityCd3">相場価格品質コード３(0:極上 1:良 …RCのマスタ)</param>
        /// <returns>SCMMrktPriStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // 2010/04/12 >>>
        //public SCMMrktPriSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 marketPriceAreaCd, Int32 marketPriceQualityCd, Int32 marketPriceKindCd1, Int32 marketPriceKindCd2, Int32 marketPriceKindCd3, Int32 marketPriceAnswerDiv, Double marketPriceSalesRate, Int32 addPaymntAmbit1, Int32 addPaymntAmbit2, Int32 addPaymntAmbit3, Int32 addPaymntAmbit4, Int32 addPaymntAmbit5, Int32 addPaymntAmbit6, Int32 addPaymntAmbit7, Int32 addPaymntAmbit8, Int32 addPaymntAmbit9, Int32 addPaymntAmbit10, Int32 addPaymnt1, Int32 addPaymnt2, Int32 addPaymnt3, Int32 addPaymnt4, Int32 addPaymnt5, Int32 addPaymnt6, Int32 addPaymnt7, Int32 addPaymnt8, Int32 addPaymnt9, Int32 addPaymnt10, Int32 fractionProcCd, string enterpriseName, string updEmployeeName)
        public SCMMrktPriSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 marketPriceAreaCd, Int32 marketPriceQualityCd, Int32 marketPriceKindCd1, Int32 marketPriceKindCd2, Int32 marketPriceKindCd3, Int32 marketPriceAnswerDiv, Double marketPriceSalesRate, Int32 addPaymntAmbit1, Int32 addPaymntAmbit2, Int32 addPaymntAmbit3, Int32 addPaymntAmbit4, Int32 addPaymntAmbit5, Int32 addPaymntAmbit6, Int32 addPaymntAmbit7, Int32 addPaymntAmbit8, Int32 addPaymntAmbit9, Int32 addPaymntAmbit10, Int32 addPaymnt1, Int32 addPaymnt2, Int32 addPaymnt3, Int32 addPaymnt4, Int32 addPaymnt5, Int32 addPaymnt6, Int32 addPaymnt7, Int32 addPaymnt8, Int32 addPaymnt9, Int32 addPaymnt10, Int32 fractionProcCd, string enterpriseName, string updEmployeeName
            , Int32 marketPriceQualityCd2
            , Int32 marketPriceQualityCd3
            )
        // 2010/04/12 <<<
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
            this._marketPriceAreaCd = marketPriceAreaCd;
            this._marketPriceQualityCd = marketPriceQualityCd;
            this._marketPriceKindCd1 = marketPriceKindCd1;
            this._marketPriceKindCd2 = marketPriceKindCd2;
            this._marketPriceKindCd3 = marketPriceKindCd3;
            this._marketPriceAnswerDiv = marketPriceAnswerDiv;
            this._marketPriceSalesRate = marketPriceSalesRate;
            this._addPaymntAmbit1 = addPaymntAmbit1;
            this._addPaymntAmbit2 = addPaymntAmbit2;
            this._addPaymntAmbit3 = addPaymntAmbit3;
            this._addPaymntAmbit4 = addPaymntAmbit4;
            this._addPaymntAmbit5 = addPaymntAmbit5;
            this._addPaymntAmbit6 = addPaymntAmbit6;
            this._addPaymntAmbit7 = addPaymntAmbit7;
            this._addPaymntAmbit8 = addPaymntAmbit8;
            this._addPaymntAmbit9 = addPaymntAmbit9;
            this._addPaymntAmbit10 = addPaymntAmbit10;
            this._addPaymnt1 = addPaymnt1;
            this._addPaymnt2 = addPaymnt2;
            this._addPaymnt3 = addPaymnt3;
            this._addPaymnt4 = addPaymnt4;
            this._addPaymnt5 = addPaymnt5;
            this._addPaymnt6 = addPaymnt6;
            this._addPaymnt7 = addPaymnt7;
            this._addPaymnt8 = addPaymnt8;
            this._addPaymnt9 = addPaymnt9;
            this._addPaymnt10 = addPaymnt10;
            this._fractionProcCd = fractionProcCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // 2010/04/12 Add >>>
            this._marketPriceQualityCd2 = marketPriceQualityCd2;
            this._marketPriceQualityCd3 = marketPriceQualityCd3;
            // 2010/04/12 Add <<<
        }

        /// <summary>
        /// SCM相場価格設定マスタ複製処理
        /// </summary>
        /// <returns>SCMMrktPriStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSCMMrktPriStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMMrktPriSt Clone()
        {
            // 2010/04/12 >>>
            //return new SCMMrktPriSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._marketPriceAreaCd, this._marketPriceQualityCd, this._marketPriceKindCd1, this._marketPriceKindCd2, this._marketPriceKindCd3, this._marketPriceAnswerDiv, this._marketPriceSalesRate, this._addPaymntAmbit1, this._addPaymntAmbit2, this._addPaymntAmbit3, this._addPaymntAmbit4, this._addPaymntAmbit5, this._addPaymntAmbit6, this._addPaymntAmbit7, this._addPaymntAmbit8, this._addPaymntAmbit9, this._addPaymntAmbit10, this._addPaymnt1, this._addPaymnt2, this._addPaymnt3, this._addPaymnt4, this._addPaymnt5, this._addPaymnt6, this._addPaymnt7, this._addPaymnt8, this._addPaymnt9, this._addPaymnt10, this._fractionProcCd, this._enterpriseName, this._updEmployeeName);
            return new SCMMrktPriSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._marketPriceAreaCd, this._marketPriceQualityCd, this._marketPriceKindCd1, this._marketPriceKindCd2, this._marketPriceKindCd3, this._marketPriceAnswerDiv, this._marketPriceSalesRate, this._addPaymntAmbit1, this._addPaymntAmbit2, this._addPaymntAmbit3, this._addPaymntAmbit4, this._addPaymntAmbit5, this._addPaymntAmbit6, this._addPaymntAmbit7, this._addPaymntAmbit8, this._addPaymntAmbit9, this._addPaymntAmbit10, this._addPaymnt1, this._addPaymnt2, this._addPaymnt3, this._addPaymnt4, this._addPaymnt5, this._addPaymnt6, this._addPaymnt7, this._addPaymnt8, this._addPaymnt9, this._addPaymnt10, this._fractionProcCd, this._enterpriseName, this._updEmployeeName
                ,this._marketPriceQualityCd2
                , this._marketPriceQualityCd3
                );
            // 2010/04/12 <<<
        }

        /// <summary>
        /// SCM相場価格設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMMrktPriStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SCMMrktPriSt target)
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
                 && (this.MarketPriceAreaCd == target.MarketPriceAreaCd)
                 && (this.MarketPriceQualityCd == target.MarketPriceQualityCd)
                 && (this.MarketPriceKindCd1 == target.MarketPriceKindCd1)
                 && (this.MarketPriceKindCd2 == target.MarketPriceKindCd2)
                 && (this.MarketPriceKindCd3 == target.MarketPriceKindCd3)
                 && (this.MarketPriceAnswerDiv == target.MarketPriceAnswerDiv)
                 && (this.MarketPriceSalesRate == target.MarketPriceSalesRate)
                 && (this.AddPaymntAmbit1 == target.AddPaymntAmbit1)
                 && (this.AddPaymntAmbit2 == target.AddPaymntAmbit2)
                 && (this.AddPaymntAmbit3 == target.AddPaymntAmbit3)
                 && (this.AddPaymntAmbit4 == target.AddPaymntAmbit4)
                 && (this.AddPaymntAmbit5 == target.AddPaymntAmbit5)
                 && (this.AddPaymntAmbit6 == target.AddPaymntAmbit6)
                 && (this.AddPaymntAmbit7 == target.AddPaymntAmbit7)
                 && (this.AddPaymntAmbit8 == target.AddPaymntAmbit8)
                 && (this.AddPaymntAmbit9 == target.AddPaymntAmbit9)
                 && (this.AddPaymntAmbit10 == target.AddPaymntAmbit10)
                 && (this.AddPaymnt1 == target.AddPaymnt1)
                 && (this.AddPaymnt2 == target.AddPaymnt2)
                 && (this.AddPaymnt3 == target.AddPaymnt3)
                 && (this.AddPaymnt4 == target.AddPaymnt4)
                 && (this.AddPaymnt5 == target.AddPaymnt5)
                 && (this.AddPaymnt6 == target.AddPaymnt6)
                 && (this.AddPaymnt7 == target.AddPaymnt7)
                 && (this.AddPaymnt8 == target.AddPaymnt8)
                 && (this.AddPaymnt9 == target.AddPaymnt9)
                 && (this.AddPaymnt10 == target.AddPaymnt10)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 // 2010/04/12 Add >>>
                 && ( this.MarketPriceQualityCd2 == target.MarketPriceQualityCd2 )
                 && ( this.MarketPriceQualityCd3 == target.MarketPriceQualityCd3 )
                 // 2010/04/12 Add <<<
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// SCM相場価格設定マスタ比較処理
        /// </summary>
        /// <param name="sCMMrktPriSt1">
        ///                    比較するSCMMrktPriStクラスのインスタンス
        /// </param>
        /// <param name="sCMMrktPriSt2">比較するSCMMrktPriStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SCMMrktPriSt sCMMrktPriSt1, SCMMrktPriSt sCMMrktPriSt2)
        {
            return ((sCMMrktPriSt1.CreateDateTime == sCMMrktPriSt2.CreateDateTime)
                 && (sCMMrktPriSt1.UpdateDateTime == sCMMrktPriSt2.UpdateDateTime)
                 && (sCMMrktPriSt1.EnterpriseCode == sCMMrktPriSt2.EnterpriseCode)
                 && (sCMMrktPriSt1.FileHeaderGuid == sCMMrktPriSt2.FileHeaderGuid)
                 && (sCMMrktPriSt1.UpdEmployeeCode == sCMMrktPriSt2.UpdEmployeeCode)
                 && (sCMMrktPriSt1.UpdAssemblyId1 == sCMMrktPriSt2.UpdAssemblyId1)
                 && (sCMMrktPriSt1.UpdAssemblyId2 == sCMMrktPriSt2.UpdAssemblyId2)
                 && (sCMMrktPriSt1.LogicalDeleteCode == sCMMrktPriSt2.LogicalDeleteCode)
                 && (sCMMrktPriSt1.SectionCode == sCMMrktPriSt2.SectionCode)
                 && (sCMMrktPriSt1.MarketPriceAreaCd == sCMMrktPriSt2.MarketPriceAreaCd)
                 && (sCMMrktPriSt1.MarketPriceQualityCd == sCMMrktPriSt2.MarketPriceQualityCd)
                 && (sCMMrktPriSt1.MarketPriceKindCd1 == sCMMrktPriSt2.MarketPriceKindCd1)
                 && (sCMMrktPriSt1.MarketPriceKindCd2 == sCMMrktPriSt2.MarketPriceKindCd2)
                 && (sCMMrktPriSt1.MarketPriceKindCd3 == sCMMrktPriSt2.MarketPriceKindCd3)
                 && (sCMMrktPriSt1.MarketPriceAnswerDiv == sCMMrktPriSt2.MarketPriceAnswerDiv)
                 && (sCMMrktPriSt1.MarketPriceSalesRate == sCMMrktPriSt2.MarketPriceSalesRate)
                 && (sCMMrktPriSt1.AddPaymntAmbit1 == sCMMrktPriSt2.AddPaymntAmbit1)
                 && (sCMMrktPriSt1.AddPaymntAmbit2 == sCMMrktPriSt2.AddPaymntAmbit2)
                 && (sCMMrktPriSt1.AddPaymntAmbit3 == sCMMrktPriSt2.AddPaymntAmbit3)
                 && (sCMMrktPriSt1.AddPaymntAmbit4 == sCMMrktPriSt2.AddPaymntAmbit4)
                 && (sCMMrktPriSt1.AddPaymntAmbit5 == sCMMrktPriSt2.AddPaymntAmbit5)
                 && (sCMMrktPriSt1.AddPaymntAmbit6 == sCMMrktPriSt2.AddPaymntAmbit6)
                 && (sCMMrktPriSt1.AddPaymntAmbit7 == sCMMrktPriSt2.AddPaymntAmbit7)
                 && (sCMMrktPriSt1.AddPaymntAmbit8 == sCMMrktPriSt2.AddPaymntAmbit8)
                 && (sCMMrktPriSt1.AddPaymntAmbit9 == sCMMrktPriSt2.AddPaymntAmbit9)
                 && (sCMMrktPriSt1.AddPaymntAmbit10 == sCMMrktPriSt2.AddPaymntAmbit10)
                 && (sCMMrktPriSt1.AddPaymnt1 == sCMMrktPriSt2.AddPaymnt1)
                 && (sCMMrktPriSt1.AddPaymnt2 == sCMMrktPriSt2.AddPaymnt2)
                 && (sCMMrktPriSt1.AddPaymnt3 == sCMMrktPriSt2.AddPaymnt3)
                 && (sCMMrktPriSt1.AddPaymnt4 == sCMMrktPriSt2.AddPaymnt4)
                 && (sCMMrktPriSt1.AddPaymnt5 == sCMMrktPriSt2.AddPaymnt5)
                 && (sCMMrktPriSt1.AddPaymnt6 == sCMMrktPriSt2.AddPaymnt6)
                 && (sCMMrktPriSt1.AddPaymnt7 == sCMMrktPriSt2.AddPaymnt7)
                 && (sCMMrktPriSt1.AddPaymnt8 == sCMMrktPriSt2.AddPaymnt8)
                 && (sCMMrktPriSt1.AddPaymnt9 == sCMMrktPriSt2.AddPaymnt9)
                 && (sCMMrktPriSt1.AddPaymnt10 == sCMMrktPriSt2.AddPaymnt10)
                 && (sCMMrktPriSt1.FractionProcCd == sCMMrktPriSt2.FractionProcCd)
                 && (sCMMrktPriSt1.EnterpriseName == sCMMrktPriSt2.EnterpriseName)
                // 2010/04/12 Add >>>
                && ( sCMMrktPriSt1.MarketPriceQualityCd2 == sCMMrktPriSt2.MarketPriceQualityCd2 )
                && ( sCMMrktPriSt1.MarketPriceQualityCd3 == sCMMrktPriSt2.MarketPriceQualityCd3 )
                // 2010/04/12 Add <<<
                 && (sCMMrktPriSt1.UpdEmployeeName == sCMMrktPriSt2.UpdEmployeeName));
        }
        /// <summary>
        /// SCM相場価格設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMMrktPriStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SCMMrktPriSt target)
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
            if (this.MarketPriceAreaCd != target.MarketPriceAreaCd) resList.Add("MarketPriceAreaCd");
            if (this.MarketPriceQualityCd != target.MarketPriceQualityCd) resList.Add("MarketPriceQualityCd");
            if (this.MarketPriceKindCd1 != target.MarketPriceKindCd1) resList.Add("MarketPriceKindCd1");
            if (this.MarketPriceKindCd2 != target.MarketPriceKindCd2) resList.Add("MarketPriceKindCd2");
            if (this.MarketPriceKindCd3 != target.MarketPriceKindCd3) resList.Add("MarketPriceKindCd3");
            if (this.MarketPriceAnswerDiv != target.MarketPriceAnswerDiv) resList.Add("MarketPriceAnswerDiv");
            if (this.MarketPriceSalesRate != target.MarketPriceSalesRate) resList.Add("MarketPriceSalesRate");
            if (this.AddPaymntAmbit1 != target.AddPaymntAmbit1) resList.Add("AddPaymntAmbit1");
            if (this.AddPaymntAmbit2 != target.AddPaymntAmbit2) resList.Add("AddPaymntAmbit2");
            if (this.AddPaymntAmbit3 != target.AddPaymntAmbit3) resList.Add("AddPaymntAmbit3");
            if (this.AddPaymntAmbit4 != target.AddPaymntAmbit4) resList.Add("AddPaymntAmbit4");
            if (this.AddPaymntAmbit5 != target.AddPaymntAmbit5) resList.Add("AddPaymntAmbit5");
            if (this.AddPaymntAmbit6 != target.AddPaymntAmbit6) resList.Add("AddPaymntAmbit6");
            if (this.AddPaymntAmbit7 != target.AddPaymntAmbit7) resList.Add("AddPaymntAmbit7");
            if (this.AddPaymntAmbit8 != target.AddPaymntAmbit8) resList.Add("AddPaymntAmbit8");
            if (this.AddPaymntAmbit9 != target.AddPaymntAmbit9) resList.Add("AddPaymntAmbit9");
            if (this.AddPaymntAmbit10 != target.AddPaymntAmbit10) resList.Add("AddPaymntAmbit10");
            if (this.AddPaymnt1 != target.AddPaymnt1) resList.Add("AddPaymnt1");
            if (this.AddPaymnt2 != target.AddPaymnt2) resList.Add("AddPaymnt2");
            if (this.AddPaymnt3 != target.AddPaymnt3) resList.Add("AddPaymnt3");
            if (this.AddPaymnt4 != target.AddPaymnt4) resList.Add("AddPaymnt4");
            if (this.AddPaymnt5 != target.AddPaymnt5) resList.Add("AddPaymnt5");
            if (this.AddPaymnt6 != target.AddPaymnt6) resList.Add("AddPaymnt6");
            if (this.AddPaymnt7 != target.AddPaymnt7) resList.Add("AddPaymnt7");
            if (this.AddPaymnt8 != target.AddPaymnt8) resList.Add("AddPaymnt8");
            if (this.AddPaymnt9 != target.AddPaymnt9) resList.Add("AddPaymnt9");
            if (this.AddPaymnt10 != target.AddPaymnt10) resList.Add("AddPaymnt10");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2010/04/12 Add >>>
            if (this.MarketPriceQualityCd2 != target.MarketPriceQualityCd2) resList.Add("MarketPriceQualityCd2");
            if (this.MarketPriceQualityCd3 != target.MarketPriceQualityCd3) resList.Add("MarketPriceQualityCd3");
            // 2010/04/12 Add <<<
            return resList;
        }

        /// <summary>
        /// SCM相場価格設定マスタ比較処理
        /// </summary>
        /// <param name="sCMMrktPriSt1">比較するSCMMrktPriStクラスのインスタンス</param>
        /// <param name="sCMMrktPriSt2">比較するSCMMrktPriStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SCMMrktPriSt sCMMrktPriSt1, SCMMrktPriSt sCMMrktPriSt2)
        {
            ArrayList resList = new ArrayList();
            if (sCMMrktPriSt1.CreateDateTime != sCMMrktPriSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (sCMMrktPriSt1.UpdateDateTime != sCMMrktPriSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sCMMrktPriSt1.EnterpriseCode != sCMMrktPriSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sCMMrktPriSt1.FileHeaderGuid != sCMMrktPriSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sCMMrktPriSt1.UpdEmployeeCode != sCMMrktPriSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sCMMrktPriSt1.UpdAssemblyId1 != sCMMrktPriSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sCMMrktPriSt1.UpdAssemblyId2 != sCMMrktPriSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sCMMrktPriSt1.LogicalDeleteCode != sCMMrktPriSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sCMMrktPriSt1.SectionCode != sCMMrktPriSt2.SectionCode) resList.Add("SectionCode");
            if (sCMMrktPriSt1.MarketPriceAreaCd != sCMMrktPriSt2.MarketPriceAreaCd) resList.Add("MarketPriceAreaCd");
            if (sCMMrktPriSt1.MarketPriceQualityCd != sCMMrktPriSt2.MarketPriceQualityCd) resList.Add("MarketPriceQualityCd");
            if (sCMMrktPriSt1.MarketPriceKindCd1 != sCMMrktPriSt2.MarketPriceKindCd1) resList.Add("MarketPriceKindCd1");
            if (sCMMrktPriSt1.MarketPriceKindCd2 != sCMMrktPriSt2.MarketPriceKindCd2) resList.Add("MarketPriceKindCd2");
            if (sCMMrktPriSt1.MarketPriceKindCd3 != sCMMrktPriSt2.MarketPriceKindCd3) resList.Add("MarketPriceKindCd3");
            if (sCMMrktPriSt1.MarketPriceAnswerDiv != sCMMrktPriSt2.MarketPriceAnswerDiv) resList.Add("MarketPriceAnswerDiv");
            if (sCMMrktPriSt1.MarketPriceSalesRate != sCMMrktPriSt2.MarketPriceSalesRate) resList.Add("MarketPriceSalesRate");
            if (sCMMrktPriSt1.AddPaymntAmbit1 != sCMMrktPriSt2.AddPaymntAmbit1) resList.Add("AddPaymntAmbit1");
            if (sCMMrktPriSt1.AddPaymntAmbit2 != sCMMrktPriSt2.AddPaymntAmbit2) resList.Add("AddPaymntAmbit2");
            if (sCMMrktPriSt1.AddPaymntAmbit3 != sCMMrktPriSt2.AddPaymntAmbit3) resList.Add("AddPaymntAmbit3");
            if (sCMMrktPriSt1.AddPaymntAmbit4 != sCMMrktPriSt2.AddPaymntAmbit4) resList.Add("AddPaymntAmbit4");
            if (sCMMrktPriSt1.AddPaymntAmbit5 != sCMMrktPriSt2.AddPaymntAmbit5) resList.Add("AddPaymntAmbit5");
            if (sCMMrktPriSt1.AddPaymntAmbit6 != sCMMrktPriSt2.AddPaymntAmbit6) resList.Add("AddPaymntAmbit6");
            if (sCMMrktPriSt1.AddPaymntAmbit7 != sCMMrktPriSt2.AddPaymntAmbit7) resList.Add("AddPaymntAmbit7");
            if (sCMMrktPriSt1.AddPaymntAmbit8 != sCMMrktPriSt2.AddPaymntAmbit8) resList.Add("AddPaymntAmbit8");
            if (sCMMrktPriSt1.AddPaymntAmbit9 != sCMMrktPriSt2.AddPaymntAmbit9) resList.Add("AddPaymntAmbit9");
            if (sCMMrktPriSt1.AddPaymntAmbit10 != sCMMrktPriSt2.AddPaymntAmbit10) resList.Add("AddPaymntAmbit10");
            if (sCMMrktPriSt1.AddPaymnt1 != sCMMrktPriSt2.AddPaymnt1) resList.Add("AddPaymnt1");
            if (sCMMrktPriSt1.AddPaymnt2 != sCMMrktPriSt2.AddPaymnt2) resList.Add("AddPaymnt2");
            if (sCMMrktPriSt1.AddPaymnt3 != sCMMrktPriSt2.AddPaymnt3) resList.Add("AddPaymnt3");
            if (sCMMrktPriSt1.AddPaymnt4 != sCMMrktPriSt2.AddPaymnt4) resList.Add("AddPaymnt4");
            if (sCMMrktPriSt1.AddPaymnt5 != sCMMrktPriSt2.AddPaymnt5) resList.Add("AddPaymnt5");
            if (sCMMrktPriSt1.AddPaymnt6 != sCMMrktPriSt2.AddPaymnt6) resList.Add("AddPaymnt6");
            if (sCMMrktPriSt1.AddPaymnt7 != sCMMrktPriSt2.AddPaymnt7) resList.Add("AddPaymnt7");
            if (sCMMrktPriSt1.AddPaymnt8 != sCMMrktPriSt2.AddPaymnt8) resList.Add("AddPaymnt8");
            if (sCMMrktPriSt1.AddPaymnt9 != sCMMrktPriSt2.AddPaymnt9) resList.Add("AddPaymnt9");
            if (sCMMrktPriSt1.AddPaymnt10 != sCMMrktPriSt2.AddPaymnt10) resList.Add("AddPaymnt10");
            if (sCMMrktPriSt1.FractionProcCd != sCMMrktPriSt2.FractionProcCd) resList.Add("FractionProcCd");
            if (sCMMrktPriSt1.EnterpriseName != sCMMrktPriSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMMrktPriSt1.UpdEmployeeName != sCMMrktPriSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2010/04/12 Add >>>
            if (sCMMrktPriSt1.MarketPriceQualityCd2 != sCMMrktPriSt2.MarketPriceQualityCd2) resList.Add("MarketPriceQualityCd2");
            if (sCMMrktPriSt1.MarketPriceQualityCd3 != sCMMrktPriSt2.MarketPriceQualityCd3) resList.Add("MarketPriceQualityCd3");
            // 2010/04/12 Add <<<
            return resList;
        }
    }
}
