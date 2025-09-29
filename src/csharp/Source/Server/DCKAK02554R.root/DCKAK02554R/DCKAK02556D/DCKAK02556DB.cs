using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_PaymentPlanWork
    /// <summary>
    ///                      支払予定表抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払予定表抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_PaymentPlanWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上拠点名称</summary>
        /// <remarks>リモート内で算出</remarks>
        private string _addUpSecName = "";

        /// <summary>支払先コード</summary>
        /// <remarks>支払先の親コード</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 支払締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>仕入3回前残高（支払計）</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>仕入2回前残高（支払計）</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>前回支払金額</summary>
        private Int64 _lastTimePayment;

        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>今回返品金額</summary>
        /// <remarks>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>今回値引金額</summary>
        /// <remarks>掛仕入：税抜きの仕入値引き金額</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>相殺後今回仕入消費税</summary>
        /// <remarks>相殺結果</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>今回支払金額（通常支払）</summary>
        /// <remarks>支払額の合計金額</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>締後支払額</summary>
        /// <remarks>締日翌日～支払予定日までの支払額(リモート内で算出)</remarks>
        private Int64 _afterClosePayment;

        /// <summary>支払月区分コード</summary>
        /// <remarks>0:当月 1:翌月 2:翌々月</remarks>
        private Int32 _paymentMonthCode;

        /// <summary>支払月区分名称</summary>
        /// <remarks>当月、翌月、翌々月</remarks>
        private string _paymentMonthName = "";

        /// <summary>支払日</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>支払条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _paymentCond;

        /// <summary>支払サイト</summary>
        /// <remarks>仕入先マスタから取得</remarks>
        private Int32 _paymentSight;

        /// <summary>仕入担当者コード</summary>
        /// <remarks>仕入先マスタから取得</remarks>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>従業員マスタから取得</remarks>
        private string _stockAgentName = "";

        /// <summary>回収予定区分</summary>
        /// <remarks>0:区分 1:日付 請求全体設定マスタから取得</remarks>
        private Int32 _collectPlnDiv;


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
        /// <value>リモート内で算出</value>
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

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先の親コード</value>
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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 支払締を行なった日（相手先基準）</value>
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

        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>仕入3回前残高（支払計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入3回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl3TmBfBlPay
        {
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
        }

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>仕入2回前残高（支払計）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入2回前残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>前回支払金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
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

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>今回返品金額プロパティ</summary>
        /// <value>掛仕入：値引、返品を含まない 税抜きの仕入返品金額</value>
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

        /// public propaty name  :  ThisStckPricDis
        /// <summary>今回値引金額プロパティ</summary>
        /// <value>掛仕入：税抜きの仕入値引き金額</value>
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

        /// public propaty name  :  AfterClosePayment
        /// <summary>締後支払額プロパティ</summary>
        /// <value>締日翌日～支払予定日までの支払額(リモート内で算出)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締後支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfterClosePayment
        {
            get { return _afterClosePayment; }
            set { _afterClosePayment = value; }
        }

        /// public propaty name  :  PaymentMonthCode
        /// <summary>支払月区分コードプロパティ</summary>
        /// <value>0:当月 1:翌月 2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentMonthCode
        {
            get { return _paymentMonthCode; }
            set { _paymentMonthCode = value; }
        }

        /// public propaty name  :  PaymentMonthName
        /// <summary>支払月区分名称プロパティ</summary>
        /// <value>当月、翌月、翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentMonthName
        {
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>支払日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>支払条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  PaymentSight
        /// <summary>支払サイトプロパティ</summary>
        /// <value>仕入先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払サイトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSight
        {
            get { return _paymentSight; }
            set { _paymentSight = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>仕入先マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// <value>従業員マスタから取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
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


        /// <summary>
        /// 支払予定表抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_PaymentPlanWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_PaymentPlanWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_PaymentPlanWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_PaymentPlanWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_PaymentPlanWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_PaymentPlanWork || graph is ArrayList || graph is RsltInfo_PaymentPlanWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_PaymentPlanWork).FullName));

            if (graph != null && graph is RsltInfo_PaymentPlanWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentPlanWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_PaymentPlanWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_PaymentPlanWork[])graph).Length;
            }
            else if (graph is RsltInfo_PaymentPlanWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //計上拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecName
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //仕入3回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //仕入2回前残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //前回支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //今回返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //今回値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //締後支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfterClosePayment
            //支払月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMonthCode
            //支払月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMonthName
            //支払日
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDay
            //支払条件
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //支払サイト
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSight
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //回収予定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectPlnDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_PaymentPlanWork)
            {
                RsltInfo_PaymentPlanWork temp = (RsltInfo_PaymentPlanWork)graph;

                SetRsltInfo_PaymentPlanWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_PaymentPlanWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_PaymentPlanWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_PaymentPlanWork temp in lst)
                {
                    SetRsltInfo_PaymentPlanWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_PaymentPlanWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  RsltInfo_PaymentPlanWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_PaymentPlanWork(System.IO.BinaryWriter writer, RsltInfo_PaymentPlanWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //計上拠点名称
            writer.Write(temp.AddUpSecName);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //仕入3回前残高（支払計）
            writer.Write(temp.StockTtl3TmBfBlPay);
            //仕入2回前残高（支払計）
            writer.Write(temp.StockTtl2TmBfBlPay);
            //前回支払金額
            writer.Write(temp.LastTimePayment);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //今回返品金額
            writer.Write(temp.ThisStckPricRgds);
            //今回値引金額
            writer.Write(temp.ThisStckPricDis);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //締後支払額
            writer.Write(temp.AfterClosePayment);
            //支払月区分コード
            writer.Write(temp.PaymentMonthCode);
            //支払月区分名称
            writer.Write(temp.PaymentMonthName);
            //支払日
            writer.Write(temp.PaymentDay);
            //支払条件
            writer.Write(temp.PaymentCond);
            //支払サイト
            writer.Write(temp.PaymentSight);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            //回収予定区分
            writer.Write(temp.CollectPlnDiv);

        }

        /// <summary>
        ///  RsltInfo_PaymentPlanWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_PaymentPlanWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_PaymentPlanWork GetRsltInfo_PaymentPlanWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_PaymentPlanWork temp = new RsltInfo_PaymentPlanWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //計上拠点名称
            temp.AddUpSecName = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //仕入3回前残高（支払計）
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //仕入2回前残高（支払計）
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //前回支払金額
            temp.LastTimePayment = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //今回返品金額
            temp.ThisStckPricRgds = reader.ReadInt64();
            //今回値引金額
            temp.ThisStckPricDis = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //締後支払額
            temp.AfterClosePayment = reader.ReadInt64();
            //支払月区分コード
            temp.PaymentMonthCode = reader.ReadInt32();
            //支払月区分名称
            temp.PaymentMonthName = reader.ReadString();
            //支払日
            temp.PaymentDay = reader.ReadInt32();
            //支払条件
            temp.PaymentCond = reader.ReadInt32();
            //支払サイト
            temp.PaymentSight = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //回収予定区分
            temp.CollectPlnDiv = reader.ReadInt32();


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
        /// <returns>RsltInfo_PaymentPlanWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_PaymentPlanWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PaymentPlanWork temp = GetRsltInfo_PaymentPlanWork(reader, serInfo);
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
                    retValue = (RsltInfo_PaymentPlanWork[])lst.ToArray(typeof(RsltInfo_PaymentPlanWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
