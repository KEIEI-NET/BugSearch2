//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignMngStWork
    /// <summary>
    ///                      キャンペーン管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/05/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/11  杉村</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   得意先コード</br>
    /// <br>                 :   仕入先コード</br>
    /// <br>                 :   BLグループコード</br>
    /// <br>Update Note      :    2009/5/13  杉村</br>
    /// <br>                 :   ○型変更</br>
    /// <br>                 :   キャンペーンコード</br>
    /// <br>                 :   nvarchar ⇒ Int32</br>
    /// <br>Update Note      :   2011/3/29  花原</br>
    /// <br>                 :   ○項目追加、ＫＥＹ変更</br>
    /// <br>                 :   BLグループコード～価格開始日</br>
    /// <br>                 :   3,9,10,11,12,13→3,9,17,22,10,20,11,21,12,13,24,25,26</br>
    /// <br>Update Note      :   2011/5/9  花原</br>
    /// <br>                 :   ○値引率追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignMngStWork
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

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>売上目標数量</summary>
        private Double _salesTargetCount;

        /// <summary>キャンペーンコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _campaignCode;

        /// <summary>価格（浮動）</summary>
        /// <remarks>売上単価（品番単位のみ設定可）</remarks>
        private Double _priceFl;

        /// <summary>掛率</summary>
        /// <remarks>売価率</remarks>
        private Double _rateVal;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>販売区分コード</summary>
        /// <remarks>ユーザーガイド</remarks>
        private Int32 _salesCode;

        /// <summary>キャンペーン設定種別</summary>
        /// <remarks>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _campaignSettingKind;

        /// <summary>売価設定区分</summary>
        /// <remarks>0なし、1：あり</remarks>
        private Int32 _salesPriceSetDiv;

        /// <summary>得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>価格終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceEndDate;

        /// <summary>値引率</summary>
        private Double _discountRate;

        /// <summary>名称</summary>
        private string _campaignName = "";

        /// <summary>拠点名</summary>
        private string _sectionName = "";

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm = "";

        /// <summary>得意先名</summary>
        private string _customerName = "";

        /// <summary>商品名（カナ）</summary>
        private string _goodsName = "";


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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
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

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>売上目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>価格（浮動）プロパティ</summary>
        /// <value>売上単価（品番単位のみ設定可）</value>
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
        /// <value>売価率</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
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

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// <value>ユーザーガイド</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  CampaignSettingKind
        /// <summary>キャンペーン設定種別プロパティ</summary>
        /// <value>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン設定種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignSettingKind
        {
            get { return _campaignSettingKind; }
            set { _campaignSettingKind = value; }
        }

        /// public propaty name  :  SalesPriceSetDiv
        /// <summary>売価設定区分プロパティ</summary>
        /// <value>0なし、1：あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesPriceSetDiv
        {
            get { return _salesPriceSetDiv; }
            set { _salesPriceSetDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
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

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  PriceEndDate
        /// <summary>価格終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceEndDate
        {
            get { return _priceEndDate; }
            set { _priceEndDate = value; }
        }

        /// public propaty name  :  DiscountRate
        /// <summary>値引率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>商品メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }


        /// <summary>
        /// キャンペーン管理ワークコンストラクタ
        /// </summary>
        /// <returns>CampaignMngStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignMngStWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CampaignMngStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CampaignMngStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CampaignMngStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignMngStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignMngStWork || graph is ArrayList || graph is CampaignMngStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CampaignMngStWork).FullName));

            if (graph != null && graph is CampaignMngStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignMngStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignMngStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignMngStWork[])graph).Length;
            }
            else if (graph is CampaignMngStWork)
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
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //売上目標金額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //売上目標粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //売上目標数量
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //価格（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //PriceFl
            //掛率
            serInfo.MemberInfo.Add(typeof(Double)); //RateVal
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //キャンペーン設定種別
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignSettingKind
            //売価設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesPriceSetDiv
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //価格終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceEndDate
            //値引率
            serInfo.MemberInfo.Add(typeof(Double)); //DiscountRate
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //拠点名
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //商品メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //得意先名
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //商品名（カナ）
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignMngStWork)
            {
                CampaignMngStWork temp = (CampaignMngStWork)graph;

                SetCampaignMngStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignMngStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignMngStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignMngStWork temp in lst)
                {
                    SetCampaignMngStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignMngStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  CampaignMngStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCampaignMngStWork(System.IO.BinaryWriter writer, CampaignMngStWork temp)
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
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //売上目標金額
            writer.Write(temp.SalesTargetMoney);
            //売上目標粗利額
            writer.Write(temp.SalesTargetProfit);
            //売上目標数量
            writer.Write(temp.SalesTargetCount);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //価格（浮動）
            writer.Write(temp.PriceFl);
            //掛率
            writer.Write(temp.RateVal);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //キャンペーン設定種別
            writer.Write(temp.CampaignSettingKind);
            //売価設定区分
            writer.Write(temp.SalesPriceSetDiv);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //価格終了日
            writer.Write(temp.PriceEndDate);
            //値引率
            writer.Write(temp.DiscountRate);
            //名称
            writer.Write(temp.CampaignName);
            //拠点名
            writer.Write(temp.SectionName);
            //商品メーカー名称
            writer.Write(temp.GoodsMakerNm);
            //得意先名
            writer.Write(temp.CustomerName);
            //商品名（カナ）
            writer.Write(temp.GoodsName);

        }

        /// <summary>
        ///  CampaignMngStWorkインスタンス取得
        /// </summary>
        /// <returns>CampaignMngStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CampaignMngStWork GetCampaignMngStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CampaignMngStWork temp = new CampaignMngStWork();

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
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //売上目標金額
            temp.SalesTargetMoney = reader.ReadInt64();
            //売上目標粗利額
            temp.SalesTargetProfit = reader.ReadInt64();
            //売上目標数量
            temp.SalesTargetCount = reader.ReadDouble();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //価格（浮動）
            temp.PriceFl = reader.ReadDouble();
            //掛率
            temp.RateVal = reader.ReadDouble();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //キャンペーン設定種別
            temp.CampaignSettingKind = reader.ReadInt32();
            //売価設定区分
            temp.SalesPriceSetDiv = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //価格終了日
            temp.PriceEndDate = reader.ReadInt32();
            //値引率
            temp.DiscountRate = reader.ReadDouble();
            //名称
            temp.CampaignName = reader.ReadString();
            //拠点名
            temp.SectionName = reader.ReadString();
            //商品メーカー名称
            temp.GoodsMakerNm = reader.ReadString();
            //得意先名
            temp.CustomerName = reader.ReadString();
            //商品名（カナ）
            temp.GoodsName = reader.ReadString();


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
        /// <returns>CampaignMngStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignMngStWork temp = GetCampaignMngStWork(reader, serInfo);
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
                    retValue = (CampaignMngStWork[])lst.ToArray(typeof(CampaignMngStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
