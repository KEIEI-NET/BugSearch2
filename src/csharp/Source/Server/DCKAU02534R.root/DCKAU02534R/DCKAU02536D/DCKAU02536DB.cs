using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_CollectPlanWork
    /// <summary>
    ///                      回収予定表抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   回収予定表抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_CollectPlanWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上拠点名称</summary>
        /// <remarks>拠点情報設定マスタから取得</remarks>
        private string _addUpSecName = "";

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        private string _claimName2 = "";

        /// <summary>請求先略称</summary>
        private string _claimSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>前回請求金額</summary>
        private Int64 _lastTimeDemand;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>相殺結果　「相殺後：***」の値が請求金額となる</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>今回売上返品金額</summary>
        /// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>今回売上値引金額</summary>
        /// <remarks>掛売：税抜きの売上値引金額</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>入金額の合計金額</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>締後入金額</summary>
        /// <remarks>締日翌日～回収予定日までの入金額(リモート内で算出)</remarks>
        private Int64 _afterCloseDemand;

        /// <summary>集金月区分コード</summary>
        /// <remarks>0:当月,1:翌月,2:翌々月</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _collectCond;

        /// <summary>回収サイト</summary>
        /// <remarks>手形サイト　180等</remarks>
        private Int32 _collectSight;

        /// <summary>集金担当従業員コード</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _billCollecterCd = "";

        /// <summary>集金担当従業員名称</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _billCollecterNm = "";

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>得意先マスタから取得(新旧担当対応をリモート内で実行)</remarks>
        private string _customerAgentCd = "";

        /// <summary>顧客担当従業員名称</summary>
        /// <remarks>得意先マスタから取得(新旧担当対応をリモート内で実行)</remarks>
        private string _customerAgentNm = "";

        /// <summary>販売エリアコード</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        /// <remarks>得意先マスタから取得</remarks>
        private string _salesAreaName = "";

        /// <summary>回収予定区分</summary>
        /// <remarks>0:区分 1:日付 請求全体設定マスタから取得</remarks>
        private Int32 _collectPlnDiv;

        /// <summary>締日</summary>
        /// <remarks>DD 得意先マスタから取得</remarks>
        private Int32 _totalDay;


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

        /// public propaty name  :  AddUpSecName
        /// <summary>計上拠点名称プロパティ</summary>
        /// <value>拠点情報設定マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
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

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// <value>入金額の合計金額</value>
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

        /// public propaty name  :  AfterCloseDemand
        /// <summary>締後入金額プロパティ</summary>
        /// <value>締日翌日～回収予定日までの入金額(リモート内で算出)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締後入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfterCloseDemand
        {
            get { return _afterCloseDemand; }
            set { _afterCloseDemand = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>集金月区分コードプロパティ</summary>
        /// <value>0:当月,1:翌月,2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectSight
        /// <summary>回収サイトプロパティ</summary>
        /// <value>手形サイト　180等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収サイトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// <value>得意先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>集金担当従業員名称プロパティ</summary>
        /// <value>得意先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>得意先マスタから取得(新旧担当対応をリモート内で実行)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// <value>得意先マスタから取得(新旧担当対応をリモート内で実行)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// <value>得意先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// <value>得意先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  CollectPlnDiv
        /// <summary>回収予定区分プロパティ</summary>
        /// <value>0:区分 1:日付 請求全体設定マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収予定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectPlnDiv
        {
            get { return _collectPlnDiv; }
            set { _collectPlnDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD 得意先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }


        /// <summary>
        /// 回収予定表抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_CollectPlanWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_CollectPlanWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_CollectPlanWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_CollectPlanWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_CollectPlanWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_CollectPlanWork || graph is ArrayList || graph is RsltInfo_CollectPlanWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_CollectPlanWork).FullName));

            if (graph != null && graph is RsltInfo_CollectPlanWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_CollectPlanWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_CollectPlanWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_CollectPlanWork[])graph).Length;
            }
            else if (graph is RsltInfo_CollectPlanWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //計上拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecName
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //請求先名称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //請求先名称2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //請求先略称
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //今回売上返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //今回売上値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //締後入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfterCloseDemand
            //集金月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //集金月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //集金日
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //回収条件
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //回収サイト
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectSight
            //集金担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //集金担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //顧客担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //回収予定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectPlnDiv
            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_CollectPlanWork)
            {
                RsltInfo_CollectPlanWork temp = (RsltInfo_CollectPlanWork)graph;

                SetRsltInfo_CollectPlanWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_CollectPlanWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_CollectPlanWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_CollectPlanWork temp in lst)
                {
                    SetRsltInfo_CollectPlanWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_CollectPlanWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  RsltInfo_CollectPlanWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_CollectPlanWork(System.IO.BinaryWriter writer, RsltInfo_CollectPlanWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //計上拠点名称
            writer.Write(temp.AddUpSecName);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //請求先名称
            writer.Write(temp.ClaimName);
            //請求先名称2
            writer.Write(temp.ClaimName2);
            //請求先略称
            writer.Write(temp.ClaimSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //今回売上返品金額
            writer.Write(temp.ThisSalesPricRgds);
            //今回売上値引金額
            writer.Write(temp.ThisSalesPricDis);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //締後入金額
            writer.Write(temp.AfterCloseDemand);
            //集金月区分コード
            writer.Write(temp.CollectMoneyCode);
            //集金月区分名称
            writer.Write(temp.CollectMoneyName);
            //集金日
            writer.Write(temp.CollectMoneyDay);
            //回収条件
            writer.Write(temp.CollectCond);
            //回収サイト
            writer.Write(temp.CollectSight);
            //集金担当従業員コード
            writer.Write(temp.BillCollecterCd);
            //集金担当従業員名称
            writer.Write(temp.BillCollecterNm);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
            //顧客担当従業員名称
            writer.Write(temp.CustomerAgentNm);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称
            writer.Write(temp.SalesAreaName);
            //回収予定区分
            writer.Write(temp.CollectPlnDiv);
            //締日
            writer.Write(temp.TotalDay);

        }

        /// <summary>
        ///  RsltInfo_CollectPlanWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_CollectPlanWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_CollectPlanWork GetRsltInfo_CollectPlanWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_CollectPlanWork temp = new RsltInfo_CollectPlanWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //計上拠点名称
            temp.AddUpSecName = reader.ReadString();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //請求先名称
            temp.ClaimName = reader.ReadString();
            //請求先名称2
            temp.ClaimName2 = reader.ReadString();
            //請求先略称
            temp.ClaimSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //受注3回前残高（請求計）
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //受注2回前残高（請求計）
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //前回請求金額
            temp.LastTimeDemand = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //今回売上返品金額
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //今回売上値引金額
            temp.ThisSalesPricDis = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //締後入金額
            temp.AfterCloseDemand = reader.ReadInt64();
            //集金月区分コード
            temp.CollectMoneyCode = reader.ReadInt32();
            //集金月区分名称
            temp.CollectMoneyName = reader.ReadString();
            //集金日
            temp.CollectMoneyDay = reader.ReadInt32();
            //回収条件
            temp.CollectCond = reader.ReadInt32();
            //回収サイト
            temp.CollectSight = reader.ReadInt32();
            //集金担当従業員コード
            temp.BillCollecterCd = reader.ReadString();
            //集金担当従業員名称
            temp.BillCollecterNm = reader.ReadString();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
            //顧客担当従業員名称
            temp.CustomerAgentNm = reader.ReadString();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称
            temp.SalesAreaName = reader.ReadString();
            //回収予定区分
            temp.CollectPlnDiv = reader.ReadInt32();
            //締日
            temp.TotalDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_CollectPlanWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_CollectPlanWork temp = GetRsltInfo_CollectPlanWork(reader, serInfo);
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
                    retValue = (RsltInfo_CollectPlanWork[])lst.ToArray(typeof(RsltInfo_CollectPlanWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
