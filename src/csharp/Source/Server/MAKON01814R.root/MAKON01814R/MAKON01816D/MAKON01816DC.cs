using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteMASIRDeleteWork
    /// <summary>
    ///                      仕入データ(IOWriteMASIRDelete)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入データ(IOWriteMASIRDelete)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/30 在庫マスタ更新区分を追加</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   仕入明細通番を追加</br>
    /// <br>                     売上仕入同時入力で売上伝票を別々で入力し仕入伝票番号を同一で作成し、</br>
    /// <br>                     作成した売上伝票の片方を伝票削除した場合、仕入伝票が呼び出せなくなる件の修正</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/11/30</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRDeleteWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入形式</summary>
        /// <remarks>0:買取(仕入),1:受託</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        // -- ADD 2009/09/30 -------------------->>>
        /// <summary>在庫マスタ更新区分</summary>
        /// <remarks>0:更新,1更新しない</remarks>
        private Int32 _stockUpdDiv;
        // -- ADD 2009/09/30 --------------------<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:買取(仕入),1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        // -- ADD 2009/09/30 ---------------------------->>>
        /// public propaty name  :  StockUpdDiv
        /// <summary>在庫マスタ更新区分プロパティ</summary>
        /// <value>0:更新,1:更新しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫マスタ更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUpdDiv
        {
            get { return _stockUpdDiv; }
            set { _stockUpdDiv = value; }
        }
        // -- ADD 2009/09/30 ----------------------------<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        /// <summary>
        /// 仕入データ(IOWriteMASIRDelete)ワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteMASIRDeleteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteMASIRDeleteWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteMASIRDeleteWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteMASIRDeleteWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRDeleteWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRDeleteWork || graph is ArrayList || graph is IOWriteMASIRDeleteWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteMASIRDeleteWork).FullName));

            if (graph != null && graph is IOWriteMASIRDeleteWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRDeleteWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRDeleteWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRDeleteWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRDeleteWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            // -- ADD 2009/09/30 ------------------------------->>>
            //在庫マスタ更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUpdDiv
            // -- ADD 2009/09/30 -------------------------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRDeleteWork)
            {
                IOWriteMASIRDeleteWork temp = (IOWriteMASIRDeleteWork)graph;

                SetIOWriteMASIRDeleteWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRDeleteWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRDeleteWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRDeleteWork temp in lst)
                {
                    SetIOWriteMASIRDeleteWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRDeleteWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 5; // DEL 2009/09/30
        //private const int currentMemberCount = 6; // ADD 2009/09/30 DEL 2012/11/30 Y.Wakita
        private const int currentMemberCount = 7; // --- ADD 2012/11/30 Y.Wakita

        /// <summary>
        ///  IOWriteMASIRDeleteWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteMASIRDeleteWork(System.IO.BinaryWriter writer, IOWriteMASIRDeleteWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            // -- ADD 2009/09/30 ------------>>>
            //在庫マスタ更新区分
            writer.Write(temp.StockUpdDiv);
            // -- ADD 2009/09/30 ------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<
        }

        /// <summary>
        ///  IOWriteMASIRDeleteWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteMASIRDeleteWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteMASIRDeleteWork GetIOWriteMASIRDeleteWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteMASIRDeleteWork temp = new IOWriteMASIRDeleteWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            // -- ADD 2009/09/30 -------------->>>
            //在庫マスタ更新区分
            temp.StockUpdDiv = reader.ReadInt32();
            // -- ADD 2009/09/30 --------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

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
        /// <returns>IOWriteMASIRDeleteWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMASIRDeleteWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRDeleteWork temp = GetIOWriteMASIRDeleteWork(reader, serInfo);
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
                    retValue = (IOWriteMASIRDeleteWork[])lst.ToArray(typeof(IOWriteMASIRDeleteWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
