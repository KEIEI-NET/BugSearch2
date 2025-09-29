using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMMrktPriStWork
    /// <summary>
    ///                      SCM相場価格設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM相場価格設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/11  杉村</br>
    /// <br>                 :   ○項目変更</br>
    /// <br>                 :   加算額1～9の型変更</br>
    /// <br>                 :   　Dobule⇒Int32</br>
    /// <br>                 :   加算額1～9の補足変更</br>
    /// <br>                 :   　○○以下⇒○○未満</br>
    /// <br>Update Note      :   2009/5/15  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   端数処理区分</br>
    /// <br>Update Note      :   2009/5/15  杉村</br>
    /// <br>                 :   ○補足変更</br>
    /// <br>                 :   加算額範囲</br>
    /// <br>                 :   ○○以上 ～ ○○未満</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   ○○を超え ～ ○○以下</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/12  21024 佐々木</br>
    /// <br>                 :   相場価格品質コード２、相場価格品質コード３の追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMMrktPriStWork : IFileHeader
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
        /// <remarks>加算額範囲1を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit2;

        /// <summary>加算額範囲3</summary>
        /// <remarks>加算額範囲2を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit3;

        /// <summary>加算額範囲4</summary>
        /// <remarks>加算額範囲3を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit4;

        /// <summary>加算額範囲5</summary>
        /// <remarks>加算額範囲4を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit5;

        /// <summary>加算額範囲6</summary>
        /// <remarks>加算額範囲5を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit6;

        /// <summary>加算額範囲7</summary>
        /// <remarks>加算額範囲6を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit7;

        /// <summary>加算額範囲8</summary>
        /// <remarks>加算額範囲7を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit8;

        /// <summary>加算額範囲9</summary>
        /// <remarks>加算額範囲8を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit9;

        /// <summary>加算額範囲10</summary>
        /// <remarks>加算額範囲9を超え～○○円以下</remarks>
        private Int32 _addPaymntAmbit10;

        /// <summary>加算額1</summary>
        /// <remarks>加算額範囲1の加算額</remarks>
        private Int32 _addPaymnt1;

        /// <summary>加算額2</summary>
        /// <remarks>加算額範囲2の加算額</remarks>
        private Int32 _addPaymnt2;

        /// <summary>加算額3</summary>
        /// <remarks>加算額範囲3の加算額</remarks>
        private Int32 _addPaymnt3;

        /// <summary>加算額4</summary>
        /// <remarks>加算額範囲4の加算額</remarks>
        private Int32 _addPaymnt4;

        /// <summary>加算額5</summary>
        /// <remarks>加算額範囲5の加算額</remarks>
        private Int32 _addPaymnt5;

        /// <summary>加算額6</summary>
        /// <remarks>加算額範囲6の加算額</remarks>
        private Int32 _addPaymnt6;

        /// <summary>加算額7</summary>
        /// <remarks>加算額範囲7の加算額</remarks>
        private Int32 _addPaymnt7;

        /// <summary>加算額8</summary>
        /// <remarks>加算額範囲8の加算額</remarks>
        private Int32 _addPaymnt8;

        /// <summary>加算額9</summary>
        /// <remarks>加算額範囲9の加算額</remarks>
        private Int32 _addPaymnt9;

        /// <summary>加算額10</summary>
        /// <remarks>加算額範囲10の加算額</remarks>
        private Int32 _addPaymnt10;

        /// <summary>端数処理区分</summary>
        /// <remarks>0:１０円単位(四捨五入) 1:１００円単位(四捨五入)</remarks>
        private Int32 _fractionProcCd;

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
        /// <value>加算額範囲1を超え～○○円以下</value>
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
        /// <value>加算額範囲2を超え～○○円以下</value>
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
        /// <value>加算額範囲3を超え～○○円以下</value>
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
        /// <value>加算額範囲4を超え～○○円以下</value>
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
        /// <value>加算額範囲5を超え～○○円以下</value>
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
        /// <value>加算額範囲6を超え～○○円以下</value>
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
        /// <value>加算額範囲7を超え～○○円以下</value>
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
        /// <value>加算額範囲8を超え～○○円以下</value>
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
        /// <value>加算額範囲9を超え～○○円以下</value>
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
        /// <value>加算額範囲1の加算額</value>
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
        /// <value>加算額範囲2の加算額</value>
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
        /// <value>加算額範囲3の加算額</value>
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
        /// <value>加算額範囲4の加算額</value>
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
        /// <value>加算額範囲5の加算額</value>
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
        /// <value>加算額範囲6の加算額</value>
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
        /// <value>加算額範囲7の加算額</value>
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
        /// <value>加算額範囲8の加算額</value>
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
        /// <value>加算額範囲9の加算額</value>
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
        /// <value>加算額範囲10の加算額</value>
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

        // 2010/04/12 Add >>>
        /// public propaty name  :  MarketPriceQualityCd2
        /// <summary>相場価格品質コード２プロパティ</summary>
        /// <value>0:極上 1:良 …RCのマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相場価格品質コード２プロパティ</br>
        /// <br>Programer        :   21024 佐々木</br>
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
        /// <br>note             :   相場価格品質コード３プロパティ</br>
        /// <br>Programer        :   21024 佐々木</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd3
        {
            get { return _marketPriceQualityCd3; }
            set { _marketPriceQualityCd3 = value; }
        }
        // 2010/04/12 Add <<<

        /// <summary>
        /// SCM相場価格設定ワークコンストラクタ
        /// </summary>
        /// <returns>SCMMrktPriStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMMrktPriStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMMrktPriStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMMrktPriStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMMrktPriStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMMrktPriStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMMrktPriStWork || graph is ArrayList || graph is SCMMrktPriStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMMrktPriStWork).FullName));

            if (graph != null && graph is SCMMrktPriStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMMrktPriStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMMrktPriStWork[])graph).Length;
            }
            else if (graph is SCMMrktPriStWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //相場価格地域コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceAreaCd
            //相場価格品質コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd
            //相場価格種別コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd1
            //相場価格種別コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd2
            //相場価格種別コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd3
            //相場価格回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceAnswerDiv
            //相場価格売価率
            serInfo.MemberInfo.Add(typeof(Double)); //MarketPriceSalesRate
            //加算額範囲1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit1
            //加算額範囲2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit2
            //加算額範囲3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit3
            //加算額範囲4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit4
            //加算額範囲5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit5
            //加算額範囲6
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit6
            //加算額範囲7
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit7
            //加算額範囲8
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit8
            //加算額範囲9
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit9
            //加算額範囲10
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit10
            //加算額1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt1
            //加算額2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt2
            //加算額3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt3
            //加算額4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt4
            //加算額5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt5
            //加算額6
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt6
            //加算額7
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt7
            //加算額8
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt8
            //加算額9
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt9
            //加算額10
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt10
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd

            // 2010/04/12 Add >>>
            //相場価格品質コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd2
            //相場価格品質コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd3
            // 2010/04/12 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMMrktPriStWork)
            {
                SCMMrktPriStWork temp = (SCMMrktPriStWork)graph;

                SetSCMMrktPriStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMMrktPriStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMMrktPriStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMMrktPriStWork temp in lst)
                {
                    SetSCMMrktPriStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMMrktPriStWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2010/04/12 >>>
        //private const int currentMemberCount = 37;
        private const int currentMemberCount = 39;
        // 2010/04/12 <<<
        
        /// <summary>
        ///  SCMMrktPriStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMMrktPriStWork(System.IO.BinaryWriter writer, SCMMrktPriStWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //相場価格地域コード
            writer.Write(temp.MarketPriceAreaCd);
            //相場価格品質コード
            writer.Write(temp.MarketPriceQualityCd);
            //相場価格種別コード１
            writer.Write(temp.MarketPriceKindCd1);
            //相場価格種別コード２
            writer.Write(temp.MarketPriceKindCd2);
            //相場価格種別コード３
            writer.Write(temp.MarketPriceKindCd3);
            //相場価格回答区分
            writer.Write(temp.MarketPriceAnswerDiv);
            //相場価格売価率
            writer.Write(temp.MarketPriceSalesRate);
            //加算額範囲1
            writer.Write(temp.AddPaymntAmbit1);
            //加算額範囲2
            writer.Write(temp.AddPaymntAmbit2);
            //加算額範囲3
            writer.Write(temp.AddPaymntAmbit3);
            //加算額範囲4
            writer.Write(temp.AddPaymntAmbit4);
            //加算額範囲5
            writer.Write(temp.AddPaymntAmbit5);
            //加算額範囲6
            writer.Write(temp.AddPaymntAmbit6);
            //加算額範囲7
            writer.Write(temp.AddPaymntAmbit7);
            //加算額範囲8
            writer.Write(temp.AddPaymntAmbit8);
            //加算額範囲9
            writer.Write(temp.AddPaymntAmbit9);
            //加算額範囲10
            writer.Write(temp.AddPaymntAmbit10);
            //加算額1
            writer.Write(temp.AddPaymnt1);
            //加算額2
            writer.Write(temp.AddPaymnt2);
            //加算額3
            writer.Write(temp.AddPaymnt3);
            //加算額4
            writer.Write(temp.AddPaymnt4);
            //加算額5
            writer.Write(temp.AddPaymnt5);
            //加算額6
            writer.Write(temp.AddPaymnt6);
            //加算額7
            writer.Write(temp.AddPaymnt7);
            //加算額8
            writer.Write(temp.AddPaymnt8);
            //加算額9
            writer.Write(temp.AddPaymnt9);
            //加算額10
            writer.Write(temp.AddPaymnt10);
            //端数処理区分
            writer.Write(temp.FractionProcCd);
            // 2010/04/12 Add >>>
            //相場価格品質コード２
            writer.Write(temp.MarketPriceQualityCd2);
            //相場価格品質コード３
            writer.Write(temp.MarketPriceQualityCd3);
            // 2010/04/12 Add <<<
        }

        /// <summary>
        ///  SCMMrktPriStWorkインスタンス取得
        /// </summary>
        /// <returns>SCMMrktPriStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMMrktPriStWork GetSCMMrktPriStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMMrktPriStWork temp = new SCMMrktPriStWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //相場価格地域コード
            temp.MarketPriceAreaCd = reader.ReadInt32();
            //相場価格品質コード
            temp.MarketPriceQualityCd = reader.ReadInt32();
            //相場価格種別コード１
            temp.MarketPriceKindCd1 = reader.ReadInt32();
            //相場価格種別コード２
            temp.MarketPriceKindCd2 = reader.ReadInt32();
            //相場価格種別コード３
            temp.MarketPriceKindCd3 = reader.ReadInt32();
            //相場価格回答区分
            temp.MarketPriceAnswerDiv = reader.ReadInt32();
            //相場価格売価率
            temp.MarketPriceSalesRate = reader.ReadDouble();
            //加算額範囲1
            temp.AddPaymntAmbit1 = reader.ReadInt32();
            //加算額範囲2
            temp.AddPaymntAmbit2 = reader.ReadInt32();
            //加算額範囲3
            temp.AddPaymntAmbit3 = reader.ReadInt32();
            //加算額範囲4
            temp.AddPaymntAmbit4 = reader.ReadInt32();
            //加算額範囲5
            temp.AddPaymntAmbit5 = reader.ReadInt32();
            //加算額範囲6
            temp.AddPaymntAmbit6 = reader.ReadInt32();
            //加算額範囲7
            temp.AddPaymntAmbit7 = reader.ReadInt32();
            //加算額範囲8
            temp.AddPaymntAmbit8 = reader.ReadInt32();
            //加算額範囲9
            temp.AddPaymntAmbit9 = reader.ReadInt32();
            //加算額範囲10
            temp.AddPaymntAmbit10 = reader.ReadInt32();
            //加算額1
            temp.AddPaymnt1 = reader.ReadInt32();
            //加算額2
            temp.AddPaymnt2 = reader.ReadInt32();
            //加算額3
            temp.AddPaymnt3 = reader.ReadInt32();
            //加算額4
            temp.AddPaymnt4 = reader.ReadInt32();
            //加算額5
            temp.AddPaymnt5 = reader.ReadInt32();
            //加算額6
            temp.AddPaymnt6 = reader.ReadInt32();
            //加算額7
            temp.AddPaymnt7 = reader.ReadInt32();
            //加算額8
            temp.AddPaymnt8 = reader.ReadInt32();
            //加算額9
            temp.AddPaymnt9 = reader.ReadInt32();
            //加算額10
            temp.AddPaymnt10 = reader.ReadInt32();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();
            // 2010/04/12 Add >>>
            //相場価格品質コード２
            temp.MarketPriceQualityCd2 = reader.ReadInt32();
            //相場価格品質コード３
            temp.MarketPriceQualityCd3 = reader.ReadInt32();
            // 2010/04/12 Add <<<

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
        /// <returns>SCMMrktPriStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMMrktPriStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMMrktPriStWork temp = GetSCMMrktPriStWork(reader, serInfo);
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
                    retValue = (SCMMrktPriStWork[])lst.ToArray(typeof(SCMMrktPriStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}