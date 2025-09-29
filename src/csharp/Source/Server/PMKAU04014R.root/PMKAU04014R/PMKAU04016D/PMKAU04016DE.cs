using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
    # region // DEL
    ///// public class name:   CustPrtPprBlTblRsltWork
    ///// <summary>
    /////                      得意先電子元帳抽出結果(残高一覧)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   得意先電子元帳抽出結果(残高一覧)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprBlTblRsltWork
    //{
    //    /// <summary>計上日</summary>
    //    /// <remarks>計上年月日(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>前回残高</summary>
    //    /// <remarks>前回請求金額/前回売掛金額</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>今回入金額</summary>
    //    /// <remarks>今回入金金額（通常入金）</remarks>
    //    private Int64 _thisTimeDmdNrml;

    //    /// <summary>繰越残高</summary>
    //    /// <remarks>今回繰越残高（請求計）/今回繰越残高（売掛計）</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>今回売上</summary>
    //    /// <remarks>今回売上金額</remarks>
    //    private Int64 _thisTimeSales;

    //    /// <summary>返品値引</summary>
    //    /// <remarks>今回売上返品金額+今回売上値引金額</remarks>
    //    private Int64 _salesPricRgdsDis;

    //    /// <summary>純売上額</summary>
    //    /// <remarks>相殺後今回売上金額</remarks>
    //    private Int64 _ofsThisTimeSales;

    //    /// <summary>消費税</summary>
    //    /// <remarks>相殺後今回売上消費税</remarks>
    //    private Int64 _ofsThisSalesTax;

    //    /// <summary>今回合計</summary>
    //    /// <remarks>純売上額+消費税</remarks>
    //    private Int64 _thisSalesPricTotal;

    //    /// <summary>今回残高</summary>
    //    /// <remarks>計算後請求金額/計算後当月売掛金額</remarks>
    //    private Int64 _afCalBlc;

    //    /// <summary>伝票枚数</summary>
    //    /// <remarks>売上伝票枚数</remarks>
    //    private Int32 _salesSlipCount;


    //    /// public propaty name  :  AddUpDate
    //    /// <summary>計上日プロパティ</summary>
    //    /// <value>計上年月日(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpDate
    //    {
    //        get { return _addUpDate; }
    //        set { _addUpDate = value; }
    //    }

    //    /// public propaty name  :  LastTimeBlc
    //    /// <summary>前回残高プロパティ</summary>
    //    /// <value>前回請求金額/前回売掛金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   前回残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 LastTimeBlc
    //    {
    //        get { return _lastTimeBlc; }
    //        set { _lastTimeBlc = value; }
    //    }

    //    /// public propaty name  :  ThisTimeDmdNrml
    //    /// <summary>今回入金額プロパティ</summary>
    //    /// <value>今回入金金額（通常入金）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回入金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimeDmdNrml
    //    {
    //        get { return _thisTimeDmdNrml; }
    //        set { _thisTimeDmdNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>繰越残高プロパティ</summary>
    //    /// <value>今回繰越残高（請求計）/今回繰越残高（売掛計）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   繰越残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimeTtlBlc
    //    {
    //        get { return _thisTimeTtlBlc; }
    //        set { _thisTimeTtlBlc = value; }
    //    }

    //    /// public propaty name  :  ThisTimeSales
    //    /// <summary>今回売上プロパティ</summary>
    //    /// <value>今回売上金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回売上プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimeSales
    //    {
    //        get { return _thisTimeSales; }
    //        set { _thisTimeSales = value; }
    //    }

    //    /// public propaty name  :  SalesPricRgdsDis
    //    /// <summary>返品値引プロパティ</summary>
    //    /// <value>今回売上返品金額+今回売上値引金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   返品値引プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPricRgdsDis
    //    {
    //        get { return _salesPricRgdsDis; }
    //        set { _salesPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeSales
    //    /// <summary>純売上額プロパティ</summary>
    //    /// <value>相殺後今回売上金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   純売上額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeSales
    //    {
    //        get { return _ofsThisTimeSales; }
    //        set { _ofsThisTimeSales = value; }
    //    }

    //    /// public propaty name  :  OfsThisSalesTax
    //    /// <summary>消費税プロパティ</summary>
    //    /// <value>相殺後今回売上消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消費税プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisSalesTax
    //    {
    //        get { return _ofsThisSalesTax; }
    //        set { _ofsThisSalesTax = value; }
    //    }

    //    /// public propaty name  :  ThisSalesPricTotal
    //    /// <summary>今回合計プロパティ</summary>
    //    /// <value>純売上額+消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisSalesPricTotal
    //    {
    //        get { return _thisSalesPricTotal; }
    //        set { _thisSalesPricTotal = value; }
    //    }

    //    /// public propaty name  :  AfCalBlc
    //    /// <summary>今回残高プロパティ</summary>
    //    /// <value>計算後請求金額/計算後当月売掛金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 AfCalBlc
    //    {
    //        get { return _afCalBlc; }
    //        set { _afCalBlc = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCount
    //    /// <summary>伝票枚数プロパティ</summary>
    //    /// <value>売上伝票枚数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票枚数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCount
    //    {
    //        get { return _salesSlipCount; }
    //        set { _salesSlipCount = value; }
    //    }


    //    /// <summary>
    //    /// 得意先電子元帳抽出結果(残高一覧)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public CustPrtPprBlTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is CustPrtPprBlTblRsltWork || graph is ArrayList || graph is CustPrtPprBlTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustPrtPprBlTblRsltWork).FullName));

    //        if (graph != null && graph is CustPrtPprBlTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork");

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is CustPrtPprBlTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((CustPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is CustPrtPprBlTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //計上日
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
    //        //前回残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
    //        //今回入金額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
    //        //繰越残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
    //        //今回売上
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
    //        //返品値引
    //        serInfo.MemberInfo.Add(typeof(Int64)); //SalesPricRgdsDis
    //        //純売上額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
    //        //消費税
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
    //        //今回合計
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricTotal
    //        //今回残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //AfCalBlc
    //        //伝票枚数
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is CustPrtPprBlTblRsltWork)
    //        {
    //            CustPrtPprBlTblRsltWork temp = (CustPrtPprBlTblRsltWork)graph;

    //            SetCustPrtPprBlTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is CustPrtPprBlTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((CustPrtPprBlTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (CustPrtPprBlTblRsltWork temp in lst)
    //            {
    //                SetCustPrtPprBlTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// CustPrtPprBlTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 11;

    //    /// <summary>
    //    ///  CustPrtPprBlTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetCustPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, CustPrtPprBlTblRsltWork temp)
    //    {
    //        //計上日
    //        writer.Write((Int64)temp.AddUpDate.Ticks);
    //        //前回残高
    //        writer.Write(temp.LastTimeBlc);
    //        //今回入金額
    //        writer.Write(temp.ThisTimeDmdNrml);
    //        //繰越残高
    //        writer.Write(temp.ThisTimeTtlBlc);
    //        //今回売上
    //        writer.Write(temp.ThisTimeSales);
    //        //返品値引
    //        writer.Write(temp.SalesPricRgdsDis);
    //        //純売上額
    //        writer.Write(temp.OfsThisTimeSales);
    //        //消費税
    //        writer.Write(temp.OfsThisSalesTax);
    //        //今回合計
    //        writer.Write(temp.ThisSalesPricTotal);
    //        //今回残高
    //        writer.Write(temp.AfCalBlc);
    //        //伝票枚数
    //        writer.Write(temp.SalesSlipCount);

    //    }

    //    /// <summary>
    //    ///  CustPrtPprBlTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private CustPrtPprBlTblRsltWork GetCustPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        CustPrtPprBlTblRsltWork temp = new CustPrtPprBlTblRsltWork();

    //        //計上日
    //        temp.AddUpDate = new DateTime(reader.ReadInt64());
    //        //前回残高
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //今回入金額
    //        temp.ThisTimeDmdNrml = reader.ReadInt64();
    //        //繰越残高
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //今回売上
    //        temp.ThisTimeSales = reader.ReadInt64();
    //        //返品値引
    //        temp.SalesPricRgdsDis = reader.ReadInt64();
    //        //純売上額
    //        temp.OfsThisTimeSales = reader.ReadInt64();
    //        //消費税
    //        temp.OfsThisSalesTax = reader.ReadInt64();
    //        //今回合計
    //        temp.ThisSalesPricTotal = reader.ReadInt64();
    //        //今回残高
    //        temp.AfCalBlc = reader.ReadInt64();
    //        //伝票枚数
    //        temp.SalesSlipCount = reader.ReadInt32();


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if (oMemberType is Type)
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
    //                if (t.Equals(typeof(int)))
    //                {
    //                    optCount = Convert.ToInt32(oData);
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if (oMemberType is string)
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
    //                object userData = formatter.Deserialize(reader);  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            CustPrtPprBlTblRsltWork temp = GetCustPrtPprBlTblRsltWork(reader, serInfo);
    //            lst.Add(temp);
    //        }
    //        switch (serInfo.RetTypeInfo)
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (CustPrtPprBlTblRsltWork[])lst.ToArray(typeof(CustPrtPprBlTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
    /// public class name:   CustPrtPprBlTblRsltWork
    /// <summary>
    ///                      得意先電子元帳抽出結果(残高一覧)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先電子元帳抽出結果(残高一覧)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprBlTblRsltWork
    {
        /// <summary>計上年月日</summary>
        /// <remarks>計上年月日(YYYYMMDD)</remarks>
        private DateTime _addUpDate;

        /// <summary>前回残高</summary>
        /// <remarks>前回請求金額/前回売掛金額</remarks>
        private Int64 _lastTimeBlc;

        /// <summary>今回入金金額（通常入金）</summary>
        /// <remarks>今回入金金額（通常入金）</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>繰越残高</summary>
        /// <remarks>今回繰越残高（請求計）/今回繰越残高（売掛計）</remarks>
        private Int64 _thisTimeTtlBlc;

        /// <summary>今回売上金額</summary>
        /// <remarks>今回売上金額</remarks>
        private Int64 _thisTimeSales;

        /// <summary>返品値引</summary>
        /// <remarks>今回売上返品金額+今回売上値引金額</remarks>
        private Int64 _salesPricRgdsDis;

        /// <summary>相殺後今回売上金額</summary>
        /// <remarks>相殺後今回売上金額</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>相殺後今回売上消費税</summary>
        /// <remarks>相殺後今回売上消費税</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>今回合計</summary>
        /// <remarks>純売上額+消費税</remarks>
        private Int64 _thisSalesPricTotal;

        /// <summary>今回残高</summary>
        /// <remarks>計算後請求金額/計算後当月売掛金額</remarks>
        private Int64 _afCalBlc;

        /// <summary>売上伝票枚数</summary>
        /// <remarks>売上伝票枚数</remarks>
        private Int32 _salesSlipCount;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        /// <summary>与信管理区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _creditMngCode;

        /// <summary>与信額</summary>
        /// <remarks>与信額</remarks>
        private Int64 _creditMoney;

        /// <summary>警告与信額</summary>
        /// <remarks>警告与信額</remarks>
        private Int64 _warningCreditMoney;

        /// <summary>与信売掛残高</summary>
        /// <remarks>与信売掛残高</remarks>
        private Int64 _prsntAccRecBalance;

        /// <summary>請求残</summary>
        /// <remarks>請求残</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし 1:売掛する</remarks>
        private Int32 _accRecDivCd;

        /// <summary>自社締日</summary>
        /// <remarks>自社締日</remarks>
        private Int32 _companyTotalDay;

        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<


        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>計上年月日(YYYYMMDD)</value>
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

        /// public propaty name  :  LastTimeBlc
        /// <summary>前回残高プロパティ</summary>
        /// <value>前回請求金額/前回売掛金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeBlc
        {
            get { return _lastTimeBlc; }
            set { _lastTimeBlc = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>今回入金金額（通常入金）プロパティ</summary>
        /// <value>今回入金金額（通常入金）</value>
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

        /// public propaty name  :  ThisTimeTtlBlc
        /// <summary>繰越残高プロパティ</summary>
        /// <value>今回繰越残高（請求計）/今回繰越残高（売掛計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   繰越残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlc
        {
            get { return _thisTimeTtlBlc; }
            set { _thisTimeTtlBlc = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>今回売上金額プロパティ</summary>
        /// <value>今回売上金額</value>
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

        /// public propaty name  :  SalesPricRgdsDis
        /// <summary>返品値引プロパティ</summary>
        /// <value>今回売上返品金額+今回売上値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPricRgdsDis
        {
            get { return _salesPricRgdsDis; }
            set { _salesPricRgdsDis = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>相殺後今回売上金額プロパティ</summary>
        /// <value>相殺後今回売上金額</value>
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
        /// <value>相殺後今回売上消費税</value>
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

        /// public propaty name  :  ThisSalesPricTotal
        /// <summary>今回合計プロパティ</summary>
        /// <value>純売上額+消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisSalesPricTotal
        {
            get { return _thisSalesPricTotal; }
            set { _thisSalesPricTotal = value; }
        }

        /// public propaty name  :  AfCalBlc
        /// <summary>今回残高プロパティ</summary>
        /// <value>計算後請求金額/計算後当月売掛金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalBlc
        {
            get { return _afCalBlc; }
            set { _afCalBlc = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>売上伝票枚数プロパティ</summary>
        /// <value>売上伝票枚数</value>
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

        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>

        /// public propaty name  :  CreditMngCode
        /// <summary>与信管理区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>与信額プロパティ</summary>
        /// <value>与信額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>警告与信額プロパティ</summary>
        /// <value>警告与信額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告与信額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>与信売掛残高プロパティ</summary>
        /// <value>与信売掛残高</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信売掛残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>請求残プロパティ</summary>
        /// <value>請求残</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求残プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし 1:売掛する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  CompanyTotalDay
        /// <summary>自社締日プロパティ</summary>
        /// <value>自社締日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompanyTotalDay
        {
            get { return _companyTotalDay; }
            set { _companyTotalDay = value; }
        }
        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        /// <summary>
        /// 得意先電子元帳抽出結果(残高一覧)クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustPrtPprBlTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprBlTblRsltWork || graph is ArrayList || graph is CustPrtPprBlTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( CustPrtPprBlTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprBlTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprBlTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprBlTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprBlTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上年月日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpDate
            //前回残高
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //LastTimeBlc
            //今回入金金額（通常入金）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeDmdNrml
            //繰越残高
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeTtlBlc
            //今回売上金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeSales
            //返品値引
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPricRgdsDis
            //相殺後今回売上金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisTimeSales
            //相殺後今回売上消費税
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisSalesTax
            //今回合計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisSalesPricTotal
            //今回残高
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //AfCalBlc
            //売上伝票枚数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCount
            //計上年月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpYearMonth
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //与信管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditMngCode
            //与信額
            serInfo.MemberInfo.Add(typeof(Int64)); //CreditMoney
            //警告与信額
            serInfo.MemberInfo.Add(typeof(Int64)); //WarningCreditMoney
            //与信売掛残高
            serInfo.MemberInfo.Add(typeof(Int64)); //PrsntAccRecBalance
            //請求残
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //自社締日
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyTotalDay
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<


            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprBlTblRsltWork )
            {
                CustPrtPprBlTblRsltWork temp = (CustPrtPprBlTblRsltWork)graph;

                SetCustPrtPprBlTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprBlTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprBlTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprBlTblRsltWork temp in lst )
                {
                    SetCustPrtPprBlTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// CustPrtPprBlTblRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        //private const int currentMemberCount = 12;
        private const int currentMemberCount = 19;
        // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        /// <summary>
        ///  CustPrtPprBlTblRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustPrtPprBlTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprBlTblRsltWork temp )
        {
            //計上年月日
            writer.Write( (Int64)temp.AddUpDate.Ticks );
            //前回残高
            writer.Write( temp.LastTimeBlc );
            //今回入金金額（通常入金）
            writer.Write( temp.ThisTimeDmdNrml );
            //繰越残高
            writer.Write( temp.ThisTimeTtlBlc );
            //今回売上金額
            writer.Write( temp.ThisTimeSales );
            //返品値引
            writer.Write( temp.SalesPricRgdsDis );
            //相殺後今回売上金額
            writer.Write( temp.OfsThisTimeSales );
            //相殺後今回売上消費税
            writer.Write( temp.OfsThisSalesTax );
            //今回合計
            writer.Write( temp.ThisSalesPricTotal );
            //今回残高
            writer.Write( temp.AfCalBlc );
            //売上伝票枚数
            writer.Write( temp.SalesSlipCount );
            //計上年月
            writer.Write( (Int64)temp.AddUpYearMonth.Ticks );
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //与信区分
            writer.Write(temp.CreditMngCode);
            //与信額
            writer.Write(temp.CreditMoney);
            //警告与信額
            writer.Write(temp.WarningCreditMoney);
            //与信売掛残高
            writer.Write(temp.PrsntAccRecBalance);
            //請求残
            writer.Write(temp.AfCalDemandPrice);
            //売掛区分
            writer.Write(temp.AccRecDivCd);
            //自社締日
            writer.Write(temp.CompanyTotalDay);
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        }

        /// <summary>
        ///  CustPrtPprBlTblRsltWorkインスタンス取得
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustPrtPprBlTblRsltWork GetCustPrtPprBlTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustPrtPprBlTblRsltWork temp = new CustPrtPprBlTblRsltWork();

            //計上年月日
            temp.AddUpDate = new DateTime( reader.ReadInt64() );
            //前回残高
            temp.LastTimeBlc = reader.ReadInt64();
            //今回入金金額（通常入金）
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //繰越残高
            temp.ThisTimeTtlBlc = reader.ReadInt64();
            //今回売上金額
            temp.ThisTimeSales = reader.ReadInt64();
            //返品値引
            temp.SalesPricRgdsDis = reader.ReadInt64();
            //相殺後今回売上金額
            temp.OfsThisTimeSales = reader.ReadInt64();
            //相殺後今回売上消費税
            temp.OfsThisSalesTax = reader.ReadInt64();
            //今回合計
            temp.ThisSalesPricTotal = reader.ReadInt64();
            //今回残高
            temp.AfCalBlc = reader.ReadInt64();
            //売上伝票枚数
            temp.SalesSlipCount = reader.ReadInt32();
            //計上年月
            temp.AddUpYearMonth = new DateTime( reader.ReadInt64() );
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //与信区分
            temp.CreditMngCode = reader.ReadInt32();
            //与信額
            temp.CreditMoney = reader.ReadInt64();
            //警告与信額
            temp.WarningCreditMoney = reader.ReadInt64();
            //与信売掛残高
            temp.PrsntAccRecBalance = reader.ReadInt64();
            //請求残
            temp.AfCalDemandPrice = reader.ReadInt64();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //自社締日
            temp.CompanyTotalDay = reader.ReadInt32();
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprBlTblRsltWork temp = GetCustPrtPprBlTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprBlTblRsltWork[])lst.ToArray( typeof( CustPrtPprBlTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
}
