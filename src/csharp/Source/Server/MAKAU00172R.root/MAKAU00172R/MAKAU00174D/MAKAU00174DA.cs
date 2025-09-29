using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcInfGetWork
    /// <summary>
    ///                      得意先元帳（請求）抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先元帳（請求）抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcInfGetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先親コード</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>実績拠点コード</summary>
        /// <remarks>実績集計の対象となっている拠点コード</remarks>
        private string _resultsSectCd = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名称</summary>
        private string _customerName = "";

        /// <summary>得意先名称2</summary>
        private string _customerName2 = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>前回請求金額</summary>
        private Int64 _lastTimeDemand;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>今回入金金額（通常入金）</summary>
        private Int64 _thisTimeDmdNrml;

        /// <summary>今回繰越残高（請求計）</summary>
        /// <remarks>今回繰越残高＝前回請求額－今回入金額合計（通常）</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>相殺結果　「相殺後：***」の値が請求金額となる</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>今回売上返品金額</summary>
        /// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>今回売上返品消費税</summary>
        /// <remarks>今回売上返品消費税＝返品外税額合計＋返品内税額合計</remarks>
        private Int64 _thisSalesPrcTaxRgds;

        /// <summary>今回売上値引金額</summary>
        /// <remarks>掛売：税抜きの売上値引金額</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>今回売上値引消費税</summary>
        /// <remarks>今回売上値引消費税＝値引外税額合計＋値引内税額合計</remarks>
        private Int64 _thisSalesPrcTaxDis;

        /// <summary>消費税調整額</summary>
        private Int64 _taxAdjust;

        /// <summary>残高調整額</summary>
        private Int64 _balanceAdjust;

        /// <summary>計算後請求金額</summary>
        /// <remarks>今回請求金額</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>掛売の伝票枚数</remarks>
        private Int32 _salesSlipCount;

        /// <summary>今回売上金額</summary>
        /// <remarks>掛売：値引、返品を含まない税抜きの売上金額</remarks>
        private Int64 _thisTimeSales;

        /// <summary>今回売上消費税</summary>
        private Int64 _thisSalesTax;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</remarks>
        private Int32 _consTaxLayMethod;

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

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先親コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  ResultsSectCd
        /// <summary>実績拠点コードプロパティ</summary>
        /// <value>実績集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsSectCd
        {
            get { return _resultsSectCd; }
            set { _resultsSectCd = value; }
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>得意先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
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

        /// public propaty name  :  LastTimeDemand
        /// <summary>前回請求金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>受注2回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注2回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>受注3回前残高（請求計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注3回前残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回入金金額（通常入金）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>今回繰越残高（請求計）プロパティ</summary>
        /// <value>今回繰越残高＝前回請求額－今回入金額合計（通常）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（請求計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// <value>相殺結果　「相殺後：***」の値が請求金額となる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>相殺後今回売上消費税プロパティ</summary>
        /// <value>相殺結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相殺後今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ThisSalesPricRgds
        /// <summary>今回売上返品金額プロパティ</summary>
        /// <value>掛売：値引を含まない税抜きの売上返品金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPricRgds
        {
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxRgds
        /// <summary>今回売上返品消費税プロパティ</summary>
        /// <value>今回売上返品消費税＝返品外税額合計＋返品内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上返品消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxRgds
        {
            get { return _thisSalesPrcTaxRgds; }
            set { _thisSalesPrcTaxRgds = value; }
        }

        /// public propaty name  :  ThisSalesPricDis
        /// <summary>今回売上値引金額プロパティ</summary>
        /// <value>掛売：税抜きの売上値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPricDis
        {
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxDis
        /// <summary>今回売上値引消費税プロパティ</summary>
        /// <value>今回売上値引消費税＝値引外税額合計＋値引内税額合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上値引消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxDis
        {
            get { return _thisSalesPrcTaxDis; }
            set { _thisSalesPrcTaxDis = value; }
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

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>計算後請求金額プロパティ</summary>
        /// <value>今回請求金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計算後請求金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
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

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>掛売の伝票枚数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票枚数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>今回売上金額プロパティ</summary>
        /// <value>掛売：値引、返品を含まない税抜きの売上金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  ThisSalesTax
        /// <summary>今回売上消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回売上消費税プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesTax
        {
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>消費税転嫁区分設定マスタを参照 0:伝票単位1:明細単位2:請求時一括</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
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
        /// 得意先元帳（請求）抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcInfGetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrcInfGetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustDmdPrcInfGetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustDmdPrcInfGetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustDmdPrcInfGetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustDmdPrcInfGetWork || graph is ArrayList || graph is CustDmdPrcInfGetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustDmdPrcInfGetWork).FullName));

            if (graph != null && graph is CustDmdPrcInfGetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcInfGetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustDmdPrcInfGetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustDmdPrcInfGetWork[])graph).Length;
            }
            else if (graph is CustDmdPrcInfGetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //実績拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsSectCd
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //得意先名称2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //今回繰越残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //今回売上返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //今回売上返品消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //今回売上値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //今回売上値引消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //消費税調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //残高調整額
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //計算後請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //締済みフラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CloseFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is CustDmdPrcInfGetWork)
            {
                CustDmdPrcInfGetWork temp = (CustDmdPrcInfGetWork)graph;

                SetCustDmdPrcInfGetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustDmdPrcInfGetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustDmdPrcInfGetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustDmdPrcInfGetWork temp in lst)
                {
                    SetCustDmdPrcInfGetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustDmdPrcInfGetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  CustDmdPrcInfGetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustDmdPrcInfGetWork(System.IO.BinaryWriter writer, CustDmdPrcInfGetWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //実績拠点コード
            writer.Write(temp.ResultsSectCd);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //得意先名称2
            writer.Write(temp.CustomerName2);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //今回繰越残高（請求計）
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //今回売上返品金額
            writer.Write(temp.ThisSalesPricRgds);
            //今回売上返品消費税
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //今回売上値引金額
            writer.Write(temp.ThisSalesPricDis);
            //今回売上値引消費税
            writer.Write(temp.ThisSalesPrcTaxDis);
            //消費税調整額
            writer.Write(temp.TaxAdjust);
            //残高調整額
            writer.Write(temp.BalanceAdjust);
            //計算後請求金額
            writer.Write(temp.AfCalDemandPrice);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //今回売上金額
            writer.Write(temp.ThisTimeSales);
            //今回売上消費税
            writer.Write(temp.ThisSalesTax);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //締済みフラグ
            writer.Write(temp.CloseFlg);

        }

        /// <summary>
        ///  CustDmdPrcInfGetWorkインスタンス取得
        /// </summary>
        /// <returns>CustDmdPrcInfGetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustDmdPrcInfGetWork GetCustDmdPrcInfGetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustDmdPrcInfGetWork temp = new CustDmdPrcInfGetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //実績拠点コード
            temp.ResultsSectCd = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //得意先名称2
            temp.CustomerName2 = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //前回請求金額
            temp.LastTimeDemand = reader.ReadInt64();
            //受注2回前残高（請求計）
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //受注3回前残高（請求計）
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //今回繰越残高（請求計）
            temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //今回売上返品金額
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //今回売上返品消費税
            temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
            //今回売上値引金額
            temp.ThisSalesPricDis = reader.ReadInt64();
            //今回売上値引消費税
            temp.ThisSalesPrcTaxDis = reader.ReadInt64();
            //消費税調整額
            temp.TaxAdjust = reader.ReadInt64();
            //残高調整額
            temp.BalanceAdjust = reader.ReadInt64();
            //計算後請求金額
            temp.AfCalDemandPrice = reader.ReadInt64();
            //締次更新実行年月日
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //前回締次更新年月日
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //今回売上金額
            temp.ThisTimeSales = reader.ReadInt64();
            //今回売上消費税
            temp.ThisSalesTax = reader.ReadInt64();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
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
        /// <returns>CustDmdPrcInfGetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcInfGetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustDmdPrcInfGetWork temp = GetCustDmdPrcInfGetWork(reader, serInfo);
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
                    retValue = (CustDmdPrcInfGetWork[])lst.ToArray(typeof(CustDmdPrcInfGetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
