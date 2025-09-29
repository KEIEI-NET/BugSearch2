using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustPrtPprBlDspRsltWork
    /// <summary>
    ///                      得意先電子元帳抽出結果(残高照会)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先電子元帳抽出結果(残高照会)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprBlDspRsltWork
    {
        /// <summary>前々々回残高</summary>
        /// <remarks>受注2回前残高（請求計）</remarks>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>前々回残高</summary>
        /// <remarks>前回請求金額</remarks>
        private Int64 _lastTimeDemand;

        /// <summary>前回残高</summary>
        /// <remarks>計算後請求金額</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>請求範囲</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
        private Int32 _consTaxLayMethod;


        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>前々々回残高プロパティ</summary>
        /// <value>受注2回前残高（請求計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前々々回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>前々回残高プロパティ</summary>
        /// <value>前回請求金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前々回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>前回残高プロパティ</summary>
        /// <value>計算後請求金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>請求範囲プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求範囲プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
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


        /// <summary>
        /// 得意先電子元帳抽出結果(残高照会)クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustPrtPprBlDspRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustPrtPprBlDspRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustPrtPprBlDspRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustPrtPprBlDspRsltWork || graph is ArrayList || graph is CustPrtPprBlDspRsltWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustPrtPprBlDspRsltWork).FullName));

            if (graph != null && graph is CustPrtPprBlDspRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlDspRsltWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustPrtPprBlDspRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprBlDspRsltWork[])graph).Length;
            }
            else if (graph is CustPrtPprBlDspRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //前々々回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //前々回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //前回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //請求範囲
            serInfo.MemberInfo.Add(typeof(DateTime)); //AddUpYearMonth
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod


            serInfo.Serialize(writer, serInfo);
            if (graph is CustPrtPprBlDspRsltWork)
            {
                CustPrtPprBlDspRsltWork temp = (CustPrtPprBlDspRsltWork)graph;

                SetCustPrtPprBlDspRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustPrtPprBlDspRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustPrtPprBlDspRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustPrtPprBlDspRsltWork temp in lst)
                {
                    SetCustPrtPprBlDspRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustPrtPprBlDspRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  CustPrtPprBlDspRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustPrtPprBlDspRsltWork(System.IO.BinaryWriter writer, CustPrtPprBlDspRsltWork temp)
        {
            //前々々回残高
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //前々回残高
            writer.Write(temp.LastTimeDemand);
            //前回残高
            writer.Write(temp.AfCalDemandPrice);
            //請求範囲
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);

        }

        /// <summary>
        ///  CustPrtPprBlDspRsltWorkインスタンス取得
        /// </summary>
        /// <returns>CustPrtPprBlDspRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustPrtPprBlDspRsltWork GetCustPrtPprBlDspRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustPrtPprBlDspRsltWork temp = new CustPrtPprBlDspRsltWork();

            //前々々回残高
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //前々回残高
            temp.LastTimeDemand = reader.ReadInt64();
            //前回残高
            temp.AfCalDemandPrice = reader.ReadInt64();
            //請求範囲
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();


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
        /// <returns>CustPrtPprBlDspRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprBlDspRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustPrtPprBlDspRsltWork temp = GetCustPrtPprBlDspRsltWork(reader, serInfo);
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
                    retValue = (CustPrtPprBlDspRsltWork[])lst.ToArray(typeof(CustPrtPprBlDspRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
