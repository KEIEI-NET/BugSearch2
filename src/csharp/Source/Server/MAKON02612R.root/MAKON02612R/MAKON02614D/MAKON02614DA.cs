using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuplAccInfGetWork
    /// <summary>
    ///                      仕入先元帳（買掛）抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先元帳（買掛）抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuplAccInfGetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>支払先コード</summary>
        /// <remarks>買掛の親コード</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>買掛の子コード</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 買掛の計上日（自社基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>前回買掛金額</summary>
        private Int64 _lastTimeAccPay;

        /// <summary>仕入2回前残高（買掛計）</summary>
        private Int64 _stckTtl2TmBfBlAccPay;

        /// <summary>仕入3回前残高（買掛計）</summary>
        private Int64 _stckTtl3TmBfBlAccPay;

        /// <summary>今回支払金額（通常支払）</summary>
        /// <remarks>支払額の合計金額</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>今回繰越残高（買掛計）</summary>
        /// <remarks>今回繰越残高＝前回買掛金額－今回支払額合計（通常入金）</remarks>
        private Int64 _thisTimeTtlBlcAcPay;

        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>相殺後今回仕入消費税</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>今回返品金額</summary>
        /// <remarks>値引、返品を含まない 税抜きの仕入返品金額</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>今回返品消費税</summary>
        /// <remarks>今回返品消費税＝返品外税額合計＋返品内税額合計</remarks>
        private Int64 _thisStcPrcTaxRgds;

        /// <summary>今回値引金額</summary>
        /// <remarks>税抜きの仕入値引き金額</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>今回値引消費税</summary>
        /// <remarks>今回値引消費税＝値引外税額合計＋値引内税額合計</remarks>
        private Int64 _thisStcPrcTaxDis;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>仕入合計残高（買掛計）</summary>
        private Int64 _stckTtlAccPayBalance;

        /// <summary>月次更新実行年月日</summary>
        /// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
        private DateTime _monthAddUpExpDate;

        /// <summary>月次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  月次更新対象となる開始年月日</remarks>
        private DateTime _stMonCAddUpUpdDate;

        /// <summary>前回月次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回月次更新対象となった年月日</remarks>
        private DateTime _laMonCAddUpUpdDate;

        /// <summary>仕入伝票枚数</summary>
        /// <remarks>仕入伝票枚数（掛仕入＋現金仕入）</remarks>
        private Int32 _stockSlipCount;

        /// <summary>今回仕入金額</summary>
        /// <remarks>値引、返品を含まない 税抜きの仕入金額</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>今回仕入消費税</summary>
        /// <remarks>今回仕入消費税＝仕入外税額合計＋仕入内税額合計</remarks>
        private Int64 _thisStcPrcTax;

        /// <summary>締済みフラグ</summary>
        /// <remarks>0:未処理,1:締済み</remarks>
        private Int32 _closeFlg;


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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>買掛の親コード</value>
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
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>買掛の子コード</value>
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

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
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
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 買掛の計上日（自社基準）</value>
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

        /// public propaty name  :  LastTimeAccPay
        /// <summary>前回買掛金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回買掛金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeAccPay
        {
            get { return _lastTimeAccPay; }
            set { _lastTimeAccPay = value; }
        }

        /// public propaty name  :  StckTtl2TmBfBlAccPay
        /// <summary>仕入2回前残高（買掛計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入2回前残高（買掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckTtl2TmBfBlAccPay
        {
            get { return _stckTtl2TmBfBlAccPay; }
            set { _stckTtl2TmBfBlAccPay = value; }
        }

        /// public propaty name  :  StckTtl3TmBfBlAccPay
        /// <summary>仕入3回前残高（買掛計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入3回前残高（買掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckTtl3TmBfBlAccPay
        {
            get { return _stckTtl3TmBfBlAccPay; }
            set { _stckTtl3TmBfBlAccPay = value; }
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
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcPay
        /// <summary>今回繰越残高（買掛計）プロパティ</summary>
        /// <value>今回繰越残高＝前回買掛金額－今回支払額合計（通常入金）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（買掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcPay
        {
            get { return _thisTimeTtlBlcAcPay; }
            set { _thisTimeTtlBlcAcPay = value; }
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

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>今回返品金額プロパティ</summary>
        /// <value>値引、返品を含まない 税抜きの仕入返品金額</value>
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

        /// public propaty name  :  ThisStckPricDis
        /// <summary>今回値引金額プロパティ</summary>
        /// <value>税抜きの仕入値引き金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricDis
        {
            get { return _thisStckPricDis; }
            set { _thisStckPricDis = value; }
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
            get { return _thisStcPrcTaxDis; }
            set { _thisStcPrcTaxDis = value; }
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
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
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
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  StckTtlAccPayBalance
        /// <summary>仕入合計残高（買掛計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入合計残高（買掛計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckTtlAccPayBalance
        {
            get { return _stckTtlAccPayBalance; }
            set { _stckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>月次更新実行年月日プロパティ</summary>
        /// <value>YYYYMMDD　月次更新実行年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }

        /// public propaty name  :  StMonCAddUpUpdDate
        /// <summary>月次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StMonCAddUpUpdDate
        {
            get { return _stMonCAddUpUpdDate; }
            set { _stMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LaMonCAddUpUpdDate
        /// <summary>前回月次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回月次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>仕入伝票枚数プロパティ</summary>
        /// <value>仕入伝票枚数（掛仕入＋現金仕入）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>値引、返品を含まない 税抜きの仕入金額</value>
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

        /// public propaty name  :  CloseFlg
        /// <summary>締済みフラグプロパティ</summary>
        /// <value>0:未処理,1:締済み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締済みフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CloseFlg
        {
            get { return _closeFlg; }
            set { _closeFlg = value; }
        }


        /// <summary>
        /// 仕入先元帳（買掛）抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>SuplAccInfGetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccInfGetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuplAccInfGetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuplAccInfGetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuplAccInfGetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuplAccInfGetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccInfGetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuplAccInfGetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuplAccInfGetWork || graph is ArrayList || graph is SuplAccInfGetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuplAccInfGetWork).FullName));

            if (graph != null && graph is SuplAccInfGetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuplAccInfGetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuplAccInfGetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuplAccInfGetWork[])graph).Length;
            }
            else if (graph is SuplAccInfGetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
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
            //前回買掛金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //仕入2回前残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl2TmBfBlAccPay
            //仕入3回前残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl3TmBfBlAccPay
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //今回繰越残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //今回返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxRgds
            //今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //今回値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxDis
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //仕入合計残高（買掛計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //月次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //月次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //前回月次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTax
            //締済みフラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CloseFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is SuplAccInfGetWork)
            {
                SuplAccInfGetWork temp = (SuplAccInfGetWork)graph;

                SetSuplAccInfGetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuplAccInfGetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuplAccInfGetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuplAccInfGetWork temp in lst)
                {
                    SetSuplAccInfGetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuplAccInfGetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  SuplAccInfGetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccInfGetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuplAccInfGetWork(System.IO.BinaryWriter writer, SuplAccInfGetWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
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
            //前回買掛金額
            writer.Write(temp.LastTimeAccPay);
            //仕入2回前残高（買掛計）
            writer.Write(temp.StckTtl2TmBfBlAccPay);
            //仕入3回前残高（買掛計）
            writer.Write(temp.StckTtl3TmBfBlAccPay);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //今回繰越残高（買掛計）
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //今回返品金額
            writer.Write(temp.ThisStckPricRgds);
            //今回返品消費税
            writer.Write(temp.ThisStcPrcTaxRgds);
            //今回値引金額
            writer.Write(temp.ThisStckPricDis);
            //今回値引消費税
            writer.Write(temp.ThisStcPrcTaxDis);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //仕入合計残高（買掛計）
            writer.Write(temp.StckTtlAccPayBalance);
            //月次更新実行年月日
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //月次更新開始年月日
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //前回月次更新年月日
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            //今回仕入消費税
            writer.Write(temp.ThisStcPrcTax);
            //締済みフラグ
            writer.Write(temp.CloseFlg);

        }

        /// <summary>
        ///  SuplAccInfGetWorkインスタンス取得
        /// </summary>
        /// <returns>SuplAccInfGetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccInfGetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuplAccInfGetWork GetSuplAccInfGetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuplAccInfGetWork temp = new SuplAccInfGetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
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
            //前回買掛金額
            temp.LastTimeAccPay = reader.ReadInt64();
            //仕入2回前残高（買掛計）
            temp.StckTtl2TmBfBlAccPay = reader.ReadInt64();
            //仕入3回前残高（買掛計）
            temp.StckTtl3TmBfBlAccPay = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //今回繰越残高（買掛計）
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //今回返品金額
            temp.ThisStckPricRgds = reader.ReadInt64();
            //今回返品消費税
            temp.ThisStcPrcTaxRgds = reader.ReadInt64();
            //今回値引金額
            temp.ThisStckPricDis = reader.ReadInt64();
            //今回値引消費税
            temp.ThisStcPrcTaxDis = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //仕入合計残高（買掛計）
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //月次更新実行年月日
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //月次更新開始年月日
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回月次更新年月日
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //今回仕入消費税
            temp.ThisStcPrcTax = reader.ReadInt64();
            //締済みフラグ
            temp.CloseFlg = reader.ReadInt32();


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
        /// <returns>SuplAccInfGetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuplAccInfGetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuplAccInfGetWork temp = GetSuplAccInfGetWork(reader, serInfo);
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
                    retValue = (SuplAccInfGetWork[])lst.ToArray(typeof(SuplAccInfGetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
