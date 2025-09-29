using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprBlTblRsltWork
    ///// <summary>
    /////                      仕入先電子元帳抽出結果(残高一覧)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   仕入先電子元帳抽出結果(残高一覧)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/18  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprBlTblRsltWork
    //{
    //    /// <summary>計上日</summary>
    //    /// <remarks>計上年月日(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>前回残高</summary>
    //    /// <remarks>前回支払金額/前回買掛金額</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>今回支払額</summary>
    //    /// <remarks>今回入金金額（通常入金）</remarks>
    //    private Int64 _thisTimePayNrml;

    //    /// <summary>繰越残高</summary>
    //    /// <remarks>今回繰越残高（支払計）/今回繰越残高（買掛計）</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>今回仕入</summary>
    //    /// <remarks>今回仕入金額</remarks>
    //    private Int64 _thisTimeStockPrice;

    //    /// <summary>返品値引</summary>
    //    /// <remarks>今回返品金額+今回値引金額</remarks>
    //    private Int64 _thisStckPricRgdsDis;

    //    /// <summary>純仕入額</summary>
    //    /// <remarks>相殺後今回仕入金額</remarks>
    //    private Int64 _ofsThisTimeStock;

    //    /// <summary>消費税</summary>
    //    /// <remarks>相殺後今回仕入消費税</remarks>
    //    private Int64 _ofsThisStockTax;

    //    /// <summary>今回合計</summary>
    //    /// <remarks>純売上額+消費税</remarks>
    //    private Int64 _thisStckPricTotal;

    //    /// <summary>今回残高</summary>
    //    /// <remarks>仕入合計残高（支払計）/仕入合計残高（買掛計）</remarks>
    //    private Int64 _stckTtlPayBlc;

    //    /// <summary>伝票枚数</summary>
    //    /// <remarks>仕入伝票枚数</remarks>
    //    private Int32 _stockSlipCount;


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
    //    /// <value>前回支払金額/前回買掛金額</value>
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

    //    /// public propaty name  :  ThisTimePayNrml
    //    /// <summary>今回支払額プロパティ</summary>
    //    /// <value>今回入金金額（通常入金）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回支払額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimePayNrml
    //    {
    //        get { return _thisTimePayNrml; }
    //        set { _thisTimePayNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>繰越残高プロパティ</summary>
    //    /// <value>今回繰越残高（支払計）/今回繰越残高（買掛計）</value>
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

    //    /// public propaty name  :  ThisTimeStockPrice
    //    /// <summary>今回仕入プロパティ</summary>
    //    /// <value>今回仕入金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回仕入プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimeStockPrice
    //    {
    //        get { return _thisTimeStockPrice; }
    //        set { _thisTimeStockPrice = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricRgdsDis
    //    /// <summary>返品値引プロパティ</summary>
    //    /// <value>今回返品金額+今回値引金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   返品値引プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricRgdsDis
    //    {
    //        get { return _thisStckPricRgdsDis; }
    //        set { _thisStckPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeStock
    //    /// <summary>純仕入額プロパティ</summary>
    //    /// <value>相殺後今回仕入金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   純仕入額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeStock
    //    {
    //        get { return _ofsThisTimeStock; }
    //        set { _ofsThisTimeStock = value; }
    //    }

    //    /// public propaty name  :  OfsThisStockTax
    //    /// <summary>消費税プロパティ</summary>
    //    /// <value>相殺後今回仕入消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消費税プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisStockTax
    //    {
    //        get { return _ofsThisStockTax; }
    //        set { _ofsThisStockTax = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricTotal
    //    /// <summary>今回合計プロパティ</summary>
    //    /// <value>純売上額+消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricTotal
    //    {
    //        get { return _thisStckPricTotal; }
    //        set { _thisStckPricTotal = value; }
    //    }

    //    /// public propaty name  :  StckTtlPayBlc
    //    /// <summary>今回残高プロパティ</summary>
    //    /// <value>仕入合計残高（支払計）/仕入合計残高（買掛計）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckTtlPayBlc
    //    {
    //        get { return _stckTtlPayBlc; }
    //        set { _stckTtlPayBlc = value; }
    //    }

    //    /// public propaty name  :  StockSlipCount
    //    /// <summary>伝票枚数プロパティ</summary>
    //    /// <value>仕入伝票枚数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票枚数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockSlipCount
    //    {
    //        get { return _stockSlipCount; }
    //        set { _stockSlipCount = value; }
    //    }


    //    /// <summary>
    //    /// 仕入先電子元帳抽出結果(残高一覧)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SuppPrtPprBlTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppPrtPprBlTblRsltWork).FullName));

    //        if (graph != null && graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork");

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is SuppPrtPprBlTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //計上日
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
    //        //前回残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
    //        //今回支払額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
    //        //繰越残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
    //        //今回仕入
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
    //        //返品値引
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgdsDis
    //        //純仕入額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
    //        //消費税
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
    //        //今回合計
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricTotal
    //        //今回残高
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlPayBlc
    //        //伝票枚数
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

    //            SetSuppPrtPprBlTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is SuppPrtPprBlTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((SuppPrtPprBlTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (SuppPrtPprBlTblRsltWork temp in lst)
    //            {
    //                SetSuppPrtPprBlTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprBlTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 11;

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp)
    //    {
    //        //計上日
    //        writer.Write((Int64)temp.AddUpDate.Ticks);
    //        //前回残高
    //        writer.Write(temp.LastTimeBlc);
    //        //今回支払額
    //        writer.Write(temp.ThisTimePayNrml);
    //        //繰越残高
    //        writer.Write(temp.ThisTimeTtlBlc);
    //        //今回仕入
    //        writer.Write(temp.ThisTimeStockPrice);
    //        //返品値引
    //        writer.Write(temp.ThisStckPricRgdsDis);
    //        //純仕入額
    //        writer.Write(temp.OfsThisTimeStock);
    //        //消費税
    //        writer.Write(temp.OfsThisStockTax);
    //        //今回合計
    //        writer.Write(temp.ThisStckPricTotal);
    //        //今回残高
    //        writer.Write(temp.StckTtlPayBlc);
    //        //伝票枚数
    //        writer.Write(temp.StockSlipCount);

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

    //        //計上日
    //        temp.AddUpDate = new DateTime(reader.ReadInt64());
    //        //前回残高
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //今回支払額
    //        temp.ThisTimePayNrml = reader.ReadInt64();
    //        //繰越残高
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //今回仕入
    //        temp.ThisTimeStockPrice = reader.ReadInt64();
    //        //返品値引
    //        temp.ThisStckPricRgdsDis = reader.ReadInt64();
    //        //純仕入額
    //        temp.OfsThisTimeStock = reader.ReadInt64();
    //        //消費税
    //        temp.OfsThisStockTax = reader.ReadInt64();
    //        //今回合計
    //        temp.ThisStckPricTotal = reader.ReadInt64();
    //        //今回残高
    //        temp.StckTtlPayBlc = reader.ReadInt64();
    //        //伝票枚数
    //        temp.StockSlipCount = reader.ReadInt32();


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
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork(reader, serInfo);
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
    //                retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray(typeof(SuppPrtPprBlTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
    # region
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
    ///// public class name:   SuppPrtPprBlTblRsltWork
    ///// <summary>
    /////                      仕入先電子元帳抽出結果(残高一覧)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   仕入先電子元帳抽出結果(残高一覧)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprBlTblRsltWork
    //{
    //    /// <summary>計上年月日</summary>
    //    /// <remarks>計上年月日(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>前回残高</summary>
    //    /// <remarks>前回支払金額/前回買掛金額</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>今回支払金額（通常支払）</summary>
    //    /// <remarks>今回入金金額（通常入金）</remarks>
    //    private Int64 _thisTimePayNrml;

    //    /// <summary>繰越残高</summary>
    //    /// <remarks>今回繰越残高（支払計）/今回繰越残高（買掛計）</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>今回仕入金額</summary>
    //    /// <remarks>今回仕入金額</remarks>
    //    private Int64 _thisTimeStockPrice;

    //    /// <summary>返品値引</summary>
    //    /// <remarks>今回返品金額+今回値引金額</remarks>
    //    private Int64 _thisStckPricRgdsDis;

    //    /// <summary>相殺後今回仕入金額</summary>
    //    /// <remarks>相殺後今回仕入金額</remarks>
    //    private Int64 _ofsThisTimeStock;

    //    /// <summary>相殺後今回仕入消費税</summary>
    //    /// <remarks>相殺後今回仕入消費税</remarks>
    //    private Int64 _ofsThisStockTax;

    //    /// <summary>今回合計</summary>
    //    /// <remarks>純売上額+消費税</remarks>
    //    private Int64 _thisStckPricTotal;

    //    /// <summary>今回残高</summary>
    //    /// <remarks>仕入合計残高（支払計）/仕入合計残高（買掛計）</remarks>
    //    private Int64 _stckTtlPayBlc;

    //    /// <summary>仕入伝票枚数</summary>
    //    /// <remarks>仕入伝票枚数</remarks>
    //    private Int32 _stockSlipCount;

    //    /// <summary>計上年月</summary>
    //    /// <remarks>YYYYMM</remarks>
    //    private DateTime _addUpYearMonth;


    //    /// public propaty name  :  AddUpDate
    //    /// <summary>計上年月日プロパティ</summary>
    //    /// <value>計上年月日(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上年月日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpDate
    //    {
    //        get { return _addUpDate; }
    //        set { _addUpDate = value; }
    //    }

    //    /// public propaty name  :  LastTimeBlc
    //    /// <summary>前回残高プロパティ</summary>
    //    /// <value>前回支払金額/前回買掛金額</value>
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

    //    /// public propaty name  :  ThisTimePayNrml
    //    /// <summary>今回支払金額（通常支払）プロパティ</summary>
    //    /// <value>今回入金金額（通常入金）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回支払金額（通常支払）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimePayNrml
    //    {
    //        get { return _thisTimePayNrml; }
    //        set { _thisTimePayNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>繰越残高プロパティ</summary>
    //    /// <value>今回繰越残高（支払計）/今回繰越残高（買掛計）</value>
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

    //    /// public propaty name  :  ThisTimeStockPrice
    //    /// <summary>今回仕入金額プロパティ</summary>
    //    /// <value>今回仕入金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回仕入金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisTimeStockPrice
    //    {
    //        get { return _thisTimeStockPrice; }
    //        set { _thisTimeStockPrice = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricRgdsDis
    //    /// <summary>返品値引プロパティ</summary>
    //    /// <value>今回返品金額+今回値引金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   返品値引プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricRgdsDis
    //    {
    //        get { return _thisStckPricRgdsDis; }
    //        set { _thisStckPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeStock
    //    /// <summary>相殺後今回仕入金額プロパティ</summary>
    //    /// <value>相殺後今回仕入金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   相殺後今回仕入金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeStock
    //    {
    //        get { return _ofsThisTimeStock; }
    //        set { _ofsThisTimeStock = value; }
    //    }

    //    /// public propaty name  :  OfsThisStockTax
    //    /// <summary>相殺後今回仕入消費税プロパティ</summary>
    //    /// <value>相殺後今回仕入消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   相殺後今回仕入消費税プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 OfsThisStockTax
    //    {
    //        get { return _ofsThisStockTax; }
    //        set { _ofsThisStockTax = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricTotal
    //    /// <summary>今回合計プロパティ</summary>
    //    /// <value>純売上額+消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回合計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricTotal
    //    {
    //        get { return _thisStckPricTotal; }
    //        set { _thisStckPricTotal = value; }
    //    }

    //    /// public propaty name  :  StckTtlPayBlc
    //    /// <summary>今回残高プロパティ</summary>
    //    /// <value>仕入合計残高（支払計）/仕入合計残高（買掛計）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   今回残高プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckTtlPayBlc
    //    {
    //        get { return _stckTtlPayBlc; }
    //        set { _stckTtlPayBlc = value; }
    //    }

    //    /// public propaty name  :  StockSlipCount
    //    /// <summary>仕入伝票枚数プロパティ</summary>
    //    /// <value>仕入伝票枚数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入伝票枚数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockSlipCount
    //    {
    //        get { return _stockSlipCount; }
    //        set { _stockSlipCount = value; }
    //    }

    //    /// public propaty name  :  AddUpYearMonth
    //    /// <summary>計上年月プロパティ</summary>
    //    /// <value>YYYYMM</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上年月プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpYearMonth
    //    {
    //        get { return _addUpYearMonth; }
    //        set { _addUpYearMonth = value; }
    //    }


    //    /// <summary>
    //    /// 仕入先電子元帳抽出結果(残高一覧)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SuppPrtPprBlTblRsltWork()
    //    {
    //    }
    //}
    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( SuppPrtPprBlTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork" );

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is SuppPrtPprBlTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //計上年月日
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpDate
    //        //前回残高
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //LastTimeBlc
    //        //今回支払金額（通常支払）
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimePayNrml
    //        //繰越残高
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeTtlBlc
    //        //今回仕入金額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeStockPrice
    //        //返品値引
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisStckPricRgdsDis
    //        //相殺後今回仕入金額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisTimeStock
    //        //相殺後今回仕入消費税
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisStockTax
    //        //今回合計
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisStckPricTotal
    //        //今回残高
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckTtlPayBlc
    //        //仕入伝票枚数
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockSlipCount
    //        //計上年月
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpYearMonth


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

    //            SetSuppPrtPprBlTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is SuppPrtPprBlTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (SuppPrtPprBlTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( SuppPrtPprBlTblRsltWork temp in lst )
    //            {
    //                SetSuppPrtPprBlTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprBlTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 12;

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprBlTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp )
    //    {
    //        //計上年月日
    //        writer.Write( (Int64)temp.AddUpDate.Ticks );
    //        //前回残高
    //        writer.Write( temp.LastTimeBlc );
    //        //今回支払金額（通常支払）
    //        writer.Write( temp.ThisTimePayNrml );
    //        //繰越残高
    //        writer.Write( temp.ThisTimeTtlBlc );
    //        //今回仕入金額
    //        writer.Write( temp.ThisTimeStockPrice );
    //        //返品値引
    //        writer.Write( temp.ThisStckPricRgdsDis );
    //        //相殺後今回仕入金額
    //        writer.Write( temp.OfsThisTimeStock );
    //        //相殺後今回仕入消費税
    //        writer.Write( temp.OfsThisStockTax );
    //        //今回合計
    //        writer.Write( temp.ThisStckPricTotal );
    //        //今回残高
    //        writer.Write( temp.StckTtlPayBlc );
    //        //仕入伝票枚数
    //        writer.Write( temp.StockSlipCount );
    //        //計上年月
    //        writer.Write( (Int64)temp.AddUpYearMonth.Ticks );

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

    //        //計上年月日
    //        temp.AddUpDate = new DateTime( reader.ReadInt64() );
    //        //前回残高
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //今回支払金額（通常支払）
    //        temp.ThisTimePayNrml = reader.ReadInt64();
    //        //繰越残高
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //今回仕入金額
    //        temp.ThisTimeStockPrice = reader.ReadInt64();
    //        //返品値引
    //        temp.ThisStckPricRgdsDis = reader.ReadInt64();
    //        //相殺後今回仕入金額
    //        temp.OfsThisTimeStock = reader.ReadInt64();
    //        //相殺後今回仕入消費税
    //        temp.OfsThisStockTax = reader.ReadInt64();
    //        //今回合計
    //        temp.ThisStckPricTotal = reader.ReadInt64();
    //        //今回残高
    //        temp.StckTtlPayBlc = reader.ReadInt64();
    //        //仕入伝票枚数
    //        temp.StockSlipCount = reader.ReadInt32();
    //        //計上年月
    //        temp.AddUpYearMonth = new DateTime( reader.ReadInt64() );


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray( typeof( SuppPrtPprBlTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
    #endregion
    # region  ADD
    /// public class name:   SuppPrtPprBlTblRsltWork
    /// <summary>
    ///                      仕入先電子元帳抽出結果(残高一覧)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先電子元帳抽出結果(残高一覧)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/07/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprBlTblRsltWork
    {
        /// <summary>計上年月日</summary>
        /// <remarks>計上年月日(YYYYMMDD)</remarks>
        private DateTime _addUpDate;

        /// <summary>前回残高</summary>
        /// <remarks>前回支払金額/前回買掛金額</remarks>
        private Int64 _lastTimeBlc;

        /// <summary>今回支払金額（通常支払）</summary>
        /// <remarks>今回入金金額（通常入金）</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>繰越残高</summary>
        /// <remarks>今回繰越残高（支払計）/今回繰越残高（買掛計）</remarks>
        private Int64 _thisTimeTtlBlc;

        /// <summary>今回仕入金額</summary>
        /// <remarks>今回仕入金額</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>返品値引</summary>
        /// <remarks>今回返品金額+今回値引金額</remarks>
        private Int64 _thisStckPricRgdsDis;

        /// <summary>相殺後今回仕入金額</summary>
        /// <remarks>相殺後今回仕入金額</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>相殺後今回仕入消費税</summary>
        /// <remarks>相殺後今回仕入消費税</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>今回合計</summary>
        /// <remarks>純売上額+消費税</remarks>
        private Int64 _thisStckPricTotal;

        /// <summary>今回残高</summary>
        /// <remarks>仕入合計残高（支払計）/仕入合計残高（買掛計）</remarks>
        private Int64 _stckTtlPayBlc;

        /// <summary>仕入伝票枚数</summary>
        /// <remarks>仕入伝票枚数</remarks>
        private Int32 _stockSlipCount;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>支払先の子コード（親レコードの場合０セット）</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";


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
        /// <value>前回支払金額/前回買掛金額</value>
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

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>今回支払金額（通常支払）プロパティ</summary>
        /// <value>今回入金金額（通常入金）</value>
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

        /// public propaty name  :  ThisTimeTtlBlc
        /// <summary>繰越残高プロパティ</summary>
        /// <value>今回繰越残高（支払計）/今回繰越残高（買掛計）</value>
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

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>今回仕入金額プロパティ</summary>
        /// <value>今回仕入金額</value>
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

        /// public propaty name  :  ThisStckPricRgdsDis
        /// <summary>返品値引プロパティ</summary>
        /// <value>今回返品金額+今回値引金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品値引プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricRgdsDis
        {
            get { return _thisStckPricRgdsDis; }
            set { _thisStckPricRgdsDis = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>相殺後今回仕入金額プロパティ</summary>
        /// <value>相殺後今回仕入金額</value>
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
        /// <value>相殺後今回仕入消費税</value>
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

        /// public propaty name  :  ThisStckPricTotal
        /// <summary>今回合計プロパティ</summary>
        /// <value>純売上額+消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回合計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ThisStckPricTotal
        {
            get { return _thisStckPricTotal; }
            set { _thisStckPricTotal = value; }
        }

        /// public propaty name  :  StckTtlPayBlc
        /// <summary>今回残高プロパティ</summary>
        /// <value>仕入合計残高（支払計）/仕入合計残高（買掛計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckTtlPayBlc
        {
            get { return _stckTtlPayBlc; }
            set { _stckTtlPayBlc = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>仕入伝票枚数プロパティ</summary>
        /// <value>仕入伝票枚数</value>
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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>支払先の子コード（親レコードの場合０セット）</value>
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



        /// <summary>
        /// 仕入先電子元帳抽出結果(残高一覧)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPprBlTblRsltWork()
        {
        }
    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppPrtPprBlTblRsltWork).FullName));

            if (graph != null && graph is SuppPrtPprBlTblRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppPrtPprBlTblRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
            }
            else if (graph is SuppPrtPprBlTblRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //前回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
            //今回支払金額（通常支払）
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //繰越残高
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
            //今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //返品値引
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgdsDis
            //相殺後今回仕入金額
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //相殺後今回仕入消費税
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //今回合計
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricTotal
            //今回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlPayBlc
            //仕入伝票枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1

            serInfo.Serialize(writer, serInfo);
            if (graph is SuppPrtPprBlTblRsltWork)
            {
                SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

                SetSuppPrtPprBlTblRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppPrtPprBlTblRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppPrtPprBlTblRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppPrtPprBlTblRsltWork temp in lst)
                {
                    SetSuppPrtPprBlTblRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppPrtPprBlTblRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  SuppPrtPprBlTblRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuppPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp)
        {
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //前回残高
            writer.Write(temp.LastTimeBlc);
            //今回支払金額（通常支払）
            writer.Write(temp.ThisTimePayNrml);
            //繰越残高
            writer.Write(temp.ThisTimeTtlBlc);
            //今回仕入金額
            writer.Write(temp.ThisTimeStockPrice);
            //返品値引
            writer.Write(temp.ThisStckPricRgdsDis);
            //相殺後今回仕入金額
            writer.Write(temp.OfsThisTimeStock);
            //相殺後今回仕入消費税
            writer.Write(temp.OfsThisStockTax);
            //今回合計
            writer.Write(temp.ThisStckPricTotal);
            //今回残高
            writer.Write(temp.StckTtlPayBlc);
            //仕入伝票枚数
            writer.Write(temp.StockSlipCount);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);

        }

        /// <summary>
        ///  SuppPrtPprBlTblRsltWorkインスタンス取得
        /// </summary>
        /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //前回残高
            temp.LastTimeBlc = reader.ReadInt64();
            //今回支払金額（通常支払）
            temp.ThisTimePayNrml = reader.ReadInt64();
            //繰越残高
            temp.ThisTimeTtlBlc = reader.ReadInt64();
            //今回仕入金額
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //返品値引
            temp.ThisStckPricRgdsDis = reader.ReadInt64();
            //相殺後今回仕入金額
            temp.OfsThisTimeStock = reader.ReadInt64();
            //相殺後今回仕入消費税
            temp.OfsThisStockTax = reader.ReadInt64();
            //今回合計
            temp.ThisStckPricTotal = reader.ReadInt64();
            //今回残高
            temp.StckTtlPayBlc = reader.ReadInt64();
            //仕入伝票枚数
            temp.StockSlipCount = reader.ReadInt32();
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();


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
        /// <returns>SuppPrtPprBlTblRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork(reader, serInfo);
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
                    retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray(typeof(SuppPrtPprBlTblRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    #endregion
}
