using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppPrtPprBlDspRsltWork
    /// <summary>
    ///                      仕入先電子元帳抽出結果(残高照会)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先電子元帳抽出結果(残高照会)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprBlDspRsltWork
    {
        /// <summary>前々々回残高</summary>
        /// <remarks>仕入2回前残高（支払計）</remarks>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>前々回残高</summary>
        /// <remarks>前回支払金額</remarks>
        private Int64 _lastTimePayment;

        /// <summary>前回残高</summary>
        /// <remarks>仕入合計残高（支払計）</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>請求範囲</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>仕入先消費税転嫁方式コード(0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税)</remarks>
        private Int32 _suppCTaxationCd;


        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>前々々回残高プロパティ</summary>
        /// <value>仕入2回前残高（支払計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前々々回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>前々回残高プロパティ</summary>
        /// <value>前回支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前々回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>前回残高プロパティ</summary>
        /// <value>仕入合計残高（支払計）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
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

        /// public propaty name  :  SuppCTaxationCd
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>仕入先消費税転嫁方式コード(0:伝票単位 1:明細単位 2:請求単位（請求先）3:請求単位（得意先）9:非課税)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppCTaxationCd
        {
            get { return _suppCTaxationCd; }
            set { _suppCTaxationCd = value; }
        }


        /// <summary>
        /// 仕入先電子元帳抽出結果(残高照会)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SuppPrtPprBlDspRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPprBlDspRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuppPrtPprBlDspRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuppPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppPrtPprBlDspRsltWork || graph is ArrayList || graph is SuppPrtPprBlDspRsltWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppPrtPprBlDspRsltWork).FullName));

            if (graph != null && graph is SuppPrtPprBlDspRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlDspRsltWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppPrtPprBlDspRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprBlDspRsltWork[])graph).Length;
            }
            else if (graph is SuppPrtPprBlDspRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //前々々回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //前々回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //前回残高
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //請求範囲
            serInfo.MemberInfo.Add(typeof(DateTime)); //AddUpYearMonth
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxationCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppPrtPprBlDspRsltWork)
            {
                SuppPrtPprBlDspRsltWork temp = (SuppPrtPprBlDspRsltWork)graph;

                SetSuppPrtPprBlDspRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppPrtPprBlDspRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppPrtPprBlDspRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppPrtPprBlDspRsltWork temp in lst)
                {
                    SetSuppPrtPprBlDspRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppPrtPprBlDspRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  SuppPrtPprBlDspRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSuppPrtPprBlDspRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlDspRsltWork temp)
        {
            //前々々回残高
            writer.Write(temp.StockTtl2TmBfBlPay);
            //前々回残高
            writer.Write(temp.LastTimePayment);
            //前回残高
            writer.Write(temp.StockTotalPayBalance);
            //請求範囲
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //消費税転嫁方式
            writer.Write(temp.SuppCTaxationCd);

        }

        /// <summary>
        ///  SuppPrtPprBlDspRsltWorkインスタンス取得
        /// </summary>
        /// <returns>SuppPrtPprBlDspRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SuppPrtPprBlDspRsltWork GetSuppPrtPprBlDspRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuppPrtPprBlDspRsltWork temp = new SuppPrtPprBlDspRsltWork();

            //前々々回残高
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //前々回残高
            temp.LastTimePayment = reader.ReadInt64();
            //前回残高
            temp.StockTotalPayBalance = reader.ReadInt64();
            //請求範囲
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //消費税転嫁方式
            temp.SuppCTaxationCd = reader.ReadInt32();


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
        /// <returns>SuppPrtPprBlDspRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprBlDspRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppPrtPprBlDspRsltWork temp = GetSuppPrtPprBlDspRsltWork(reader, serInfo);
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
                    retValue = (SuppPrtPprBlDspRsltWork[])lst.ToArray(typeof(SuppPrtPprBlDspRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
