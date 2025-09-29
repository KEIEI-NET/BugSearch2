using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_DemandBalanceWork
    /// <summary>
    ///                      請求残高元帳抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求残高元帳抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_DemandBalanceWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上拠点名称</summary>
        /// <remarks>リモート内で算出</remarks>
        private string _addUpSecName = "";

        /// <summary>請求先コード</summary>
        /// <remarks>請求先親コード</remarks>
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

        /// <summary>前回請求金額</summary>
        private Int64 _lastTimeDemand;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>入金額の合計金額</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>今回繰越残高（支払計）</summary>
        /// <remarks>今回繰越残高＝前回請求額 ＋ 残高調整額 ー　今回請求額（請求計）</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>掛売：今回売上金額＋今回売上返品金額＋今回売上値引金額</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>掛売：消費税額合計</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>今回売上金額</summary>
        /// <remarks>掛売：値引、返品を含まない税抜きの売上金額</remarks>
        private Int64 _thisTimeSales;

        /// <summary>今回売上消費税</summary>
        private Int64 _thisSalesTax;

        /// <summary>今回売上返品金額</summary>
        /// <remarks>掛売：値引を含まない税抜きの売上返品金額</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>今回売上値引金額</summary>
        /// <remarks>掛売：税抜きの売上値引金額</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>計算後請求金額</summary>
        /// <remarks>今回請求金額</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>売上伝票枚数</summary>
        private Int32 _salesSlipCount;

        /// <summary>受注2回前残高（請求計）</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>受注3回前残高（請求計）</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>集金担当従業員名称</summary>
        private string _billCollecterNm = "";

        /// <summary>回収条件</summary>
        private Int32 _collectCond;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;


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

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>今回繰越残高（支払計）プロパティ</summary>
        /// <value>今回繰越残高＝前回請求額 ＋ 残高調整額 ー　今回請求額（請求計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回繰越残高（支払計）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// <value>掛売：今回売上金額＋今回売上返品金額＋今回売上値引金額</value>
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
        /// <value>掛売：消費税額合計</value>
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

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
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

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
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

        /// public propaty name  :  CollectCond
        /// <summary>回収条件プロパティ</summary>
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

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
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


        /// <summary>
        /// 請求残高元帳抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_DemandBalanceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_DemandBalanceWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_DemandBalanceWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_DemandBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_DemandBalanceWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_DemandBalanceWork || graph is ArrayList || graph is RsltInfo_DemandBalanceWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_DemandBalanceWork).FullName));

            if (graph != null && graph is RsltInfo_DemandBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandBalanceWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_DemandBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_DemandBalanceWork[])graph).Length;
            }
            else if (graph is RsltInfo_DemandBalanceWork)
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
            //前回請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //今回繰越残高（支払計）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //相殺後今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //今回売上金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //今回売上消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //今回売上返品金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //今回売上値引金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //計算後請求金額
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //売上伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //受注2回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //受注3回前残高（請求計）
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //集金担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //集金担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //回収条件
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //集金月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //集金日
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_DemandBalanceWork)
            {
                RsltInfo_DemandBalanceWork temp = (RsltInfo_DemandBalanceWork)graph;

                SetRsltInfo_DemandBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_DemandBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_DemandBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_DemandBalanceWork temp in lst)
                {
                    SetRsltInfo_DemandBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_DemandBalanceWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  RsltInfo_DemandBalanceWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_DemandBalanceWork(System.IO.BinaryWriter writer, RsltInfo_DemandBalanceWork temp)
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
            //前回請求金額
            writer.Write(temp.LastTimeDemand);
            //今回入金金額（通常入金）
            writer.Write(temp.ThisTimeDmdNrml);
            //今回繰越残高（支払計）
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //相殺後今回売上金額
            writer.Write(temp.OfsThisTimeSales);
            //相殺後今回売上消費税
            writer.Write(temp.OfsThisSalesTax);
            //今回売上金額
            writer.Write(temp.ThisTimeSales);
            //今回売上消費税
            writer.Write(temp.ThisSalesTax);
            //今回売上返品金額
            writer.Write(temp.ThisSalesPricRgds);
            //今回売上値引金額
            writer.Write(temp.ThisSalesPricDis);
            //計算後請求金額
            writer.Write(temp.AfCalDemandPrice);
            //売上伝票枚数
            writer.Write(temp.SalesSlipCount);
            //受注2回前残高（請求計）
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //受注3回前残高（請求計）
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //集金担当従業員コード
            writer.Write(temp.BillCollecterCd);
            //集金担当従業員名称
            writer.Write(temp.BillCollecterNm);
            //回収条件
            writer.Write(temp.CollectCond);
            //集金月区分名称
            writer.Write(temp.CollectMoneyName);
            //締日
            writer.Write(temp.TotalDay);
            //集金日
            writer.Write(temp.CollectMoneyDay);

        }

        /// <summary>
        ///  RsltInfo_DemandBalanceWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_DemandBalanceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_DemandBalanceWork GetRsltInfo_DemandBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_DemandBalanceWork temp = new RsltInfo_DemandBalanceWork();

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
            //前回請求金額
            temp.LastTimeDemand = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //今回繰越残高（支払計）
            temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //今回売上金額
            temp.ThisTimeSales = reader.ReadInt64();
            //今回売上消費税
            temp.ThisSalesTax = reader.ReadInt64();
            //今回売上返品金額
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //今回売上値引金額
            temp.ThisSalesPricDis = reader.ReadInt64();
            //計算後請求金額
            temp.AfCalDemandPrice = reader.ReadInt64();
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //受注2回前残高（請求計）
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //受注3回前残高（請求計）
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //集金担当従業員コード
            temp.BillCollecterCd = reader.ReadString();
            //集金担当従業員名称
            temp.BillCollecterNm = reader.ReadString();
            //回収条件
            temp.CollectCond = reader.ReadInt32();
            //集金月区分名称
            temp.CollectMoneyName = reader.ReadString();
            //締日
            temp.TotalDay = reader.ReadInt32();
            //集金日
            temp.CollectMoneyDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_DemandBalanceWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_DemandBalanceWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_DemandBalanceWork temp = GetRsltInfo_DemandBalanceWork(reader, serInfo);
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
                    retValue = (RsltInfo_DemandBalanceWork[])lst.ToArray(typeof(RsltInfo_DemandBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
