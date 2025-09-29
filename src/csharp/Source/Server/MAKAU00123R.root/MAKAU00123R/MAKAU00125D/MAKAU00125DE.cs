using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcUpdStatusWork
    /// <summary>
    ///                      得意先請求金額更新有無パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先請求金額更新有無パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/03/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcUpdStatusWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>更新ステータス</summary>
        /// <remarks>0:更新,1:未更新</remarks>
        private Int32 _updateStatus;


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

        /// public propaty name  :  UpdateStatus
        /// <summary>更新ステータスプロパティ</summary>
        /// <value>0:更新,1:未更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateStatus
        {
            get { return _updateStatus; }
            set { _updateStatus = value; }
        }


        /// <summary>
        /// 得意先請求金額更新有無パラメータワークコンストラクタ
        /// </summary>
        /// <returns>CustDmdPrcUpdStatusWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustDmdPrcUpdStatusWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustDmdPrcUpdStatusWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustDmdPrcUpdStatusWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustDmdPrcUpdStatusWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustDmdPrcUpdStatusWork || graph is ArrayList || graph is CustDmdPrcUpdStatusWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CustDmdPrcUpdStatusWork).FullName));

            if (graph != null && graph is CustDmdPrcUpdStatusWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdStatusWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustDmdPrcUpdStatusWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustDmdPrcUpdStatusWork[])graph).Length;
            }
            else if (graph is CustDmdPrcUpdStatusWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //更新ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateStatus


            serInfo.Serialize(writer, serInfo);
            if (graph is CustDmdPrcUpdStatusWork)
            {
                CustDmdPrcUpdStatusWork temp = (CustDmdPrcUpdStatusWork)graph;

                SetCustDmdPrcUpdStatusWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustDmdPrcUpdStatusWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustDmdPrcUpdStatusWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustDmdPrcUpdStatusWork temp in lst)
                {
                    SetCustDmdPrcUpdStatusWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustDmdPrcUpdStatusWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  CustDmdPrcUpdStatusWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustDmdPrcUpdStatusWork(System.IO.BinaryWriter writer, CustDmdPrcUpdStatusWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //更新ステータス
            writer.Write(temp.UpdateStatus);

        }

        /// <summary>
        ///  CustDmdPrcUpdStatusWorkインスタンス取得
        /// </summary>
        /// <returns>CustDmdPrcUpdStatusWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustDmdPrcUpdStatusWork GetCustDmdPrcUpdStatusWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustDmdPrcUpdStatusWork temp = new CustDmdPrcUpdStatusWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //更新ステータス
            temp.UpdateStatus = reader.ReadInt32();


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
        /// <returns>CustDmdPrcUpdStatusWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustDmdPrcUpdStatusWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustDmdPrcUpdStatusWork temp = GetCustDmdPrcUpdStatusWork(reader, serInfo);
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
                    retValue = (CustDmdPrcUpdStatusWork[])lst.ToArray(typeof(CustDmdPrcUpdStatusWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
