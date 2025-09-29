using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RatePrtRstWork
    /// <summary>
    ///                      掛率印刷抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率印刷抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
    /// <br>                     ユーザー価格指定を追加する</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RatePrtRstWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>掛率設定区分</summary>
        /// <remarks>A1,A2等</remarks>
        private string _rateSettingDivide = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>0:有効,1:論理削除,2:保留,3:完全削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコードカナ名称</summary>
        private string _bLGroupKanaName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>上限</summary>
        /// <remarks>ロット数</remarks>
        private Double _lotCount;

        /// <summary>売価率</summary>
        /// <remarks>売価設定時の掛率</remarks>
        private Double _salRateVal;

        /// <summary>売価額</summary>
        /// <remarks>売価設定時の価格（浮動）</remarks>
        private Double _salPriceFl;

        /// <summary>原価UP率</summary>
        /// <remarks>売価設定時のUP率</remarks>
        private Double _salUpRate;

        /// <summary>粗利確保率</summary>
        private Double _grsProfitSecureRate;

        /// <summary>仕入率</summary>
        /// <remarks>原価設定時の掛率</remarks>
        private Double _cstRateVal;

        /// <summary>仕入原価</summary>
        /// <remarks>原価設定時の価格（浮動）</remarks>
        private Double _cstPriceFl;

        /// <summary>ユーザー価格</summary>
        /// <remarks>価格設定時の価格（浮動）</remarks>
        private Double _prcPriceFl;

        // --- ADD 2011/07/22 ---------->>>>>
        /// <summary>価格</summary>
        /// <remarks>価格設定時の価格</remarks>
        private Double _price;
        // --- ADD 22011/07/22  ----------<<<<<

        /// <summary>価格UP率</summary>
        /// <remarks>価格設定時のUP率</remarks>
        private Double _prcUpRate;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        /// <remarks>1:切捨て, 2:四捨五入, 3:切上げ</remarks>
        private Int32 _unPrcFracProcDiv;

        /// <summary>単価種類</summary>
        /// <remarks>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</remarks>
        private string _unitPriceKind = "";


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>0:有効,1:論理削除,2:保留,3:完全削除</value>
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  LotCount
        /// <summary>上限プロパティ</summary>
        /// <value>ロット数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LotCount
        {
            get { return _lotCount; }
            set { _lotCount = value; }
        }

        /// public propaty name  :  SalRateVal
        /// <summary>売価率プロパティ</summary>
        /// <value>売価設定時の掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalRateVal
        {
            get { return _salRateVal; }
            set { _salRateVal = value; }
        }

        /// public propaty name  :  SalPriceFl
        /// <summary>売価額プロパティ</summary>
        /// <value>売価設定時の価格（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalPriceFl
        {
            get { return _salPriceFl; }
            set { _salPriceFl = value; }
        }

        /// public propaty name  :  SalUpRate
        /// <summary>原価UP率プロパティ</summary>
        /// <value>売価設定時のUP率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalUpRate
        {
            get { return _salUpRate; }
            set { _salUpRate = value; }
        }

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>粗利確保率プロパティ</summary>
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

        /// public propaty name  :  CstRateVal
        /// <summary>仕入率プロパティ</summary>
        /// <value>原価設定時の掛率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CstRateVal
        {
            get { return _cstRateVal; }
            set { _cstRateVal = value; }
        }

        /// public propaty name  :  CstPriceFl
        /// <summary>仕入原価プロパティ</summary>
        /// <value>原価設定時の価格（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CstPriceFl
        {
            get { return _cstPriceFl; }
            set { _cstPriceFl = value; }
        }

        /// public propaty name  :  PrcPriceFl
        /// <summary>ユーザー価格プロパティ</summary>
        /// <value>価格設定時の価格（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PrcPriceFl
        {
            get { return _prcPriceFl; }
            set { _prcPriceFl = value; }
        }

        // --- ADD 2011/07/22 ---------->>>>>
        /// public propaty name  :  Price
        /// <summary>価格プロパティ</summary>
        /// <value>価格設定時の価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格プロパティ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public Double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        // --- ADD 22011/07/22  ----------<<<<<

        /// public propaty name  :  PrcUpRate
        /// <summary>価格UP率プロパティ</summary>
        /// <value>価格設定時のUP率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PrcUpRate
        {
            get { return _prcUpRate; }
            set { _prcUpRate = value; }
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


        /// <summary>
        /// 掛率印刷抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>RatePrtRstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RatePrtRstWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RatePrtRstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RatePrtRstWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RatePrtRstWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RatePrtRstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RatePrtRstWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RatePrtRstWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RatePrtRstWork || graph is ArrayList || graph is RatePrtRstWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RatePrtRstWork).FullName));

            if (graph != null && graph is RatePrtRstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RatePrtRstWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RatePrtRstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RatePrtRstWork[])graph).Length;
            }
            else if (graph is RatePrtRstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //掛率設定区分
            serInfo.MemberInfo.Add(typeof(string)); //RateSettingDivide
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //商品掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //上限
            serInfo.MemberInfo.Add(typeof(Double)); //LotCount
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //SalRateVal
            //売価額
            serInfo.MemberInfo.Add(typeof(Double)); //SalPriceFl
            //原価UP率
            serInfo.MemberInfo.Add(typeof(Double)); //SalUpRate
            //粗利確保率
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitSecureRate
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //CstRateVal
            //仕入原価
            serInfo.MemberInfo.Add(typeof(Double)); //CstPriceFl
            //ユーザー価格
            serInfo.MemberInfo.Add(typeof(Double)); //PrcPriceFl
            // --- ADD 2011/07/22 ---------->>>>>
            //価格
            serInfo.MemberInfo.Add(typeof(Double)); //Price
            // --- ADD 22011/07/22  ----------<<<<<
            //価格UP率
            serInfo.MemberInfo.Add(typeof(Double)); //PrcUpRate
            //単価端数処理単位
            serInfo.MemberInfo.Add(typeof(Double)); //UnPrcFracProcUnit
            //単価端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcFracProcDiv
            //単価種類
            serInfo.MemberInfo.Add(typeof(string)); //UnitPriceKind


            serInfo.Serialize(writer, serInfo);
            if (graph is RatePrtRstWork)
            {
                RatePrtRstWork temp = (RatePrtRstWork)graph;

                SetRatePrtRstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RatePrtRstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RatePrtRstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RatePrtRstWork temp in lst)
                {
                    SetRatePrtRstWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RatePrtRstWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD 2011/07/22 ---------->>>>>
        //private const int currentMemberCount = 31;
        private const int currentMemberCount = 32;
        // --- UPD 22011/07/22  ----------<<<<<

        /// <summary>
        ///  RatePrtRstWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RatePrtRstWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRatePrtRstWork(System.IO.BinaryWriter writer, RatePrtRstWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //掛率設定区分
            writer.Write(temp.RateSettingDivide);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //商品掛率グループコード
            writer.Write(temp.GoodsRateGrpCode);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //上限
            writer.Write(temp.LotCount);
            //売価率
            writer.Write(temp.SalRateVal);
            //売価額
            writer.Write(temp.SalPriceFl);
            //原価UP率
            writer.Write(temp.SalUpRate);
            //粗利確保率
            writer.Write(temp.GrsProfitSecureRate);
            //仕入率
            writer.Write(temp.CstRateVal);
            //仕入原価
            writer.Write(temp.CstPriceFl);
            //ユーザー価格
            writer.Write(temp.PrcPriceFl);
            // --- ADD 2011/07/22 ---------->>>>>
            //価格
            writer.Write(temp.Price);
            // --- ADD 22011/07/22  ----------<<<<<
            //価格UP率
            writer.Write(temp.PrcUpRate);
            //単価端数処理単位
            writer.Write(temp.UnPrcFracProcUnit);
            //単価端数処理区分
            writer.Write(temp.UnPrcFracProcDiv);
            //単価種類
            writer.Write(temp.UnitPriceKind);

        }

        /// <summary>
        ///  RatePrtRstWorkインスタンス取得
        /// </summary>
        /// <returns>RatePrtRstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RatePrtRstWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RatePrtRstWork GetRatePrtRstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RatePrtRstWork temp = new RatePrtRstWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //掛率設定区分
            temp.RateSettingDivide = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //商品掛率グループコード
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //上限
            temp.LotCount = reader.ReadDouble();
            //売価率
            temp.SalRateVal = reader.ReadDouble();
            //売価額
            temp.SalPriceFl = reader.ReadDouble();
            //原価UP率
            temp.SalUpRate = reader.ReadDouble();
            //粗利確保率
            temp.GrsProfitSecureRate = reader.ReadDouble();
            //仕入率
            temp.CstRateVal = reader.ReadDouble();
            //仕入原価
            temp.CstPriceFl = reader.ReadDouble();
            //ユーザー価格
            temp.PrcPriceFl = reader.ReadDouble();
            // --- ADD 2011/07/22 ---------->>>>>
            //ユーザー価格
            temp.Price = reader.ReadDouble();
            // --- ADD 22011/07/22  ----------<<<<<
            //価格UP率
            temp.PrcUpRate = reader.ReadDouble();
            //単価端数処理単位
            temp.UnPrcFracProcUnit = reader.ReadDouble();
            //単価端数処理区分
            temp.UnPrcFracProcDiv = reader.ReadInt32();
            //単価種類
            temp.UnitPriceKind = reader.ReadString();


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
        /// <returns>RatePrtRstWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RatePrtRstWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RatePrtRstWork temp = GetRatePrtRstWork(reader, serInfo);
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
                    retValue = (RatePrtRstWork[])lst.ToArray(typeof(RatePrtRstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
