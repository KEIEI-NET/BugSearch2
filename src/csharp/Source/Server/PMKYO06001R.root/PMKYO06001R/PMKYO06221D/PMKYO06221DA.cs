//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信抽出・更新DB仲介クラス              //
//                  :   PMKYO06221D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.04.29                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APRateWork
    /// <summary>
    ///                      掛率ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/19  杉村</br>
    /// <br>                 :   ○区分変更</br>
    /// <br>                 :   1:売上単価　2:売上原価　3:仕入単価 4:定価 5:作業原価 6:作業売価</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APRateWork : IFileHeader
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

        /// <summary>単価掛率設定区分</summary>
        /// <remarks>単価種類＋掛率設定区分（1A1,2A2等）</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>単価種類</summary>
        /// <remarks>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</remarks>
        private string _unitPriceKind = "";

        /// <summary>掛率設定区分</summary>
        /// <remarks>A1,A2等</remarks>
        private string _rateSettingDivide = "";

        /// <summary>掛率設定区分（商品）</summary>
        /// <remarks>A～O　</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>掛率設定名称（商品）</summary>
        /// <remarks>A： "メーカー＋商品"</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>掛率設定区分（得意先）</summary>
        /// <remarks>1～9　</remarks>
        private string _rateMngCustCd = "";

        /// <summary>掛率設定名称（得意先）</summary>
        /// <remarks>1： "得意先＋仕入先"</remarks>
        private string _rateMngCustNm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>中分類を使用</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>ロット数</summary>
        /// <remarks>表示順位はロット数の昇順とする</remarks>
        private Double _lotCount;

        /// <summary>価格（浮動）</summary>
        /// <remarks>売価設定/売上単価、原価設定/仕入単価、定価設定/定価</remarks>
        private Double _priceFl;

        /// <summary>掛率</summary>
        /// <remarks>掛率（売価設定/売価率、仕入設定/仕入率）</remarks>
        private Double _rateVal;

        /// <summary>UP率</summary>
        /// <remarks>UP率（売価設定/原価UP率、定価/定価UP率）</remarks>
        private Double _upRate;

        /// <summary>粗利確保率</summary>
        /// <remarks>売上単価のみ</remarks>
        private Double _grsProfitSecureRate;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        /// <remarks>1:切捨て, 2:四捨五入, 3:切上げ</remarks>
        private Int32 _unPrcFracProcDiv;


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

        /// public propaty name  :  UnitRateSetDivCd
        /// <summary>単価掛率設定区分プロパティ</summary>
        /// <value>単価種類＋掛率設定区分（1A1,2A2等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価掛率設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitRateSetDivCd
        {
            get { return _unitRateSetDivCd; }
            set { _unitRateSetDivCd = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>単価種類プロパティ</summary>
        /// <value>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>掛率設定区分プロパティ</summary>
        /// <value>A1,A2等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>掛率設定区分（商品）プロパティ</summary>
        /// <value>A～O　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>掛率設定名称（商品）プロパティ</summary>
        /// <value>A： "メーカー＋商品"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>掛率設定区分（得意先）プロパティ</summary>
        /// <value>1～9　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>掛率設定名称（得意先）プロパティ</summary>
        /// <value>1： "得意先＋仕入先"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>中分類を使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  LotCount
        /// <summary>ロット数プロパティ</summary>
        /// <value>表示順位はロット数の昇順とする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロット数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LotCount
        {
            get { return _lotCount; }
            set { _lotCount = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>価格（浮動）プロパティ</summary>
        /// <value>売価設定/売上単価、原価設定/仕入単価、定価設定/定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>掛率プロパティ</summary>
        /// <value>掛率（売価設定/売価率、仕入設定/仕入率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP率プロパティ</summary>
        /// <value>UP率（売価設定/原価UP率、定価/定価UP率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>粗利確保率プロパティ</summary>
        /// <value>売上単価のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利確保率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitSecureRate
        {
            get { return _grsProfitSecureRate; }
            set { _grsProfitSecureRate = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>単価端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>単価端数処理区分プロパティ</summary>
        /// <value>1:切捨て, 2:四捨五入, 3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }


        /// <summary>
        /// 掛率ワークコンストラクタ
        /// </summary>
        /// <returns>RateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APRateWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RateWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RateWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class APRateWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RateWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APRateWork || graph is ArrayList || graph is APRateWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APRateWork).FullName));

            if (graph != null && graph is APRateWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RateWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APRateWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APRateWork[])graph).Length;
            }
            else if (graph is APRateWork)
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
            //単価掛率設定区分
            serInfo.MemberInfo.Add(typeof(string)); //UnitRateSetDivCd
            //単価種類
            serInfo.MemberInfo.Add(typeof(string)); //UnitPriceKind
            //掛率設定区分
            serInfo.MemberInfo.Add(typeof(string)); //RateSettingDivide
            //掛率設定区分（商品）
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsCd
            //掛率設定名称（商品）
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsNm
            //掛率設定区分（得意先）
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustCd
            //掛率設定名称（得意先）
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustNm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //商品掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //ロット数
            serInfo.MemberInfo.Add(typeof(Double)); //LotCount
            //価格（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //PriceFl
            //掛率
            serInfo.MemberInfo.Add(typeof(Double)); //RateVal
            //UP率
            serInfo.MemberInfo.Add(typeof(Double)); //UpRate
            //粗利確保率
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitSecureRate
            //単価端数処理単位
            serInfo.MemberInfo.Add(typeof(Double)); //UnPrcFracProcUnit
            //単価端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcFracProcDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is APRateWork)
            {
                APRateWork temp = (APRateWork)graph;

                SetRateWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APRateWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APRateWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APRateWork temp in lst)
                {
                    SetRateWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RateWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  RateWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRateWork(System.IO.BinaryWriter writer, APRateWork temp)
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
            //単価掛率設定区分
            writer.Write(temp.UnitRateSetDivCd);
            //単価種類
            writer.Write(temp.UnitPriceKind);
            //掛率設定区分
            writer.Write(temp.RateSettingDivide);
            //掛率設定区分（商品）
            writer.Write(temp.RateMngGoodsCd);
            //掛率設定名称（商品）
            writer.Write(temp.RateMngGoodsNm);
            //掛率設定区分（得意先）
            writer.Write(temp.RateMngCustCd);
            //掛率設定名称（得意先）
            writer.Write(temp.RateMngCustNm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //商品掛率グループコード
            writer.Write(temp.GoodsRateGrpCode);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //ロット数
            writer.Write(temp.LotCount);
            //価格（浮動）
            writer.Write(temp.PriceFl);
            //掛率
            writer.Write(temp.RateVal);
            //UP率
            writer.Write(temp.UpRate);
            //粗利確保率
            writer.Write(temp.GrsProfitSecureRate);
            //単価端数処理単位
            writer.Write(temp.UnPrcFracProcUnit);
            //単価端数処理区分
            writer.Write(temp.UnPrcFracProcDiv);

        }

        /// <summary>
        ///  RateWorkインスタンス取得
        /// </summary>
        /// <returns>RateWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private APRateWork GetRateWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APRateWork temp = new APRateWork();

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
            //単価掛率設定区分
            temp.UnitRateSetDivCd = reader.ReadString();
            //単価種類
            temp.UnitPriceKind = reader.ReadString();
            //掛率設定区分
            temp.RateSettingDivide = reader.ReadString();
            //掛率設定区分（商品）
            temp.RateMngGoodsCd = reader.ReadString();
            //掛率設定名称（商品）
            temp.RateMngGoodsNm = reader.ReadString();
            //掛率設定区分（得意先）
            temp.RateMngCustCd = reader.ReadString();
            //掛率設定名称（得意先）
            temp.RateMngCustNm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //商品掛率グループコード
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //ロット数
            temp.LotCount = reader.ReadDouble();
            //価格（浮動）
            temp.PriceFl = reader.ReadDouble();
            //掛率
            temp.RateVal = reader.ReadDouble();
            //UP率
            temp.UpRate = reader.ReadDouble();
            //粗利確保率
            temp.GrsProfitSecureRate = reader.ReadDouble();
            //単価端数処理単位
            temp.UnPrcFracProcUnit = reader.ReadDouble();
            //単価端数処理区分
            temp.UnPrcFracProcDiv = reader.ReadInt32();


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
        /// <returns>RateWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APRateWork temp = GetRateWork(reader, serInfo);
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
                    retValue = (APRateWork[])lst.ToArray(typeof(APRateWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
