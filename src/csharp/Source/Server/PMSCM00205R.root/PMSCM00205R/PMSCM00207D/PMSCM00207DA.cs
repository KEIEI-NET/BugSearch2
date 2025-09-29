using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SimplInqCnectInfoWork
    /// <summary>
    ///                      簡単問合せ接続情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   簡単問合せ接続情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/03/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SimplInqCnectInfoWork
    {
        /// <summary>レジ番号</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;


        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
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


        /// <summary>
        /// 簡単問合せ接続情報ワークコンストラクタ
        /// </summary>
        /// <returns>CMTCnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SimplInqCnectInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SimplInqCnectInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CMTCnectInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SimplInqCnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SimplInqCnectInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is SimplInqCnectInfoWork || graph is ArrayList || graph is SimplInqCnectInfoWork[] ))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SimplInqCnectInfoWork).FullName));

            if (graph != null && graph is SimplInqCnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is SimplInqCnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (SimplInqCnectInfoWork[])graph ).Length;
            }
            else if (graph is SimplInqCnectInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //レジ番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode


            serInfo.Serialize(writer, serInfo);
            if (graph is SimplInqCnectInfoWork)
            {
                SimplInqCnectInfoWork temp = (SimplInqCnectInfoWork)graph;

                SetCMTCnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SimplInqCnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SimplInqCnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SimplInqCnectInfoWork temp in lst)
                {
                    SetCMTCnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CMTCnectInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 2;

        /// <summary>
        ///  CMTCnectInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCMTCnectInfoWork(System.IO.BinaryWriter writer, SimplInqCnectInfoWork temp)
        {
            //レジ番号
            writer.Write(temp.CashRegisterNo);
            //得意先コード
            writer.Write(temp.CustomerCode);

        }

        /// <summary>
        ///  CMTCnectInfoWorkインスタンス取得
        /// </summary>
        /// <returns>CMTCnectInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SimplInqCnectInfoWork GetCMTCnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SimplInqCnectInfoWork temp = new SimplInqCnectInfoWork();

            //レジ番号
            temp.CashRegisterNo = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();


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
        /// <returns>CMTCnectInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SimplInqCnectInfoWork temp = GetCMTCnectInfoWork(reader, serInfo);
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
                    retValue = (SimplInqCnectInfoWork[])lst.ToArray(typeof(SimplInqCnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
