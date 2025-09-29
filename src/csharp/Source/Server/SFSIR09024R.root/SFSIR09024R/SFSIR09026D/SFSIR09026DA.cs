using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentSetWork
    /// <summary>
    ///                      支払設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/03/30</br>
    /// <br>Genarated Date   :   2006/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentSetWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>支払設定管理No</summary>
        /// <remarks>0固定</remarks>
        private Int32 _payStMngNo;

        /// <summary>支払設定金種コード1</summary>
        private Int32 _payStMoneyKindCd1;

        /// <summary>支払設定金種コード2</summary>
        private Int32 _payStMoneyKindCd2;

        /// <summary>支払設定金種コード3</summary>
        private Int32 _payStMoneyKindCd3;

        /// <summary>支払設定金種コード4</summary>
        private Int32 _payStMoneyKindCd4;

        /// <summary>支払設定金種コード5</summary>
        private Int32 _payStMoneyKindCd5;

        /// <summary>支払設定金種コード6</summary>
        private Int32 _payStMoneyKindCd6;

        /// <summary>支払設定金種コード7</summary>
        private Int32 _payStMoneyKindCd7;

        /// <summary>支払設定金種コード8</summary>
        private Int32 _payStMoneyKindCd8;

        /// <summary>支払設定金種コード9</summary>
        private Int32 _payStMoneyKindCd9;

        /// <summary>支払設定金種コード10</summary>
        private Int32 _payStMoneyKindCd10;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PayStMngNo
        /// <summary>支払設定管理Noプロパティ</summary>
        /// <value>0固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定管理Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMngNo
        {
            get { return _payStMngNo; }
            set { _payStMngNo = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd1
        /// <summary>支払設定金種コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd1
        {
            get { return _payStMoneyKindCd1; }
            set { _payStMoneyKindCd1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd2
        /// <summary>支払設定金種コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd2
        {
            get { return _payStMoneyKindCd2; }
            set { _payStMoneyKindCd2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd3
        /// <summary>支払設定金種コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd3
        {
            get { return _payStMoneyKindCd3; }
            set { _payStMoneyKindCd3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd4
        /// <summary>支払設定金種コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd4
        {
            get { return _payStMoneyKindCd4; }
            set { _payStMoneyKindCd4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd5
        /// <summary>支払設定金種コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd5
        {
            get { return _payStMoneyKindCd5; }
            set { _payStMoneyKindCd5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd6
        /// <summary>支払設定金種コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd6
        {
            get { return _payStMoneyKindCd6; }
            set { _payStMoneyKindCd6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd7
        /// <summary>支払設定金種コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd7
        {
            get { return _payStMoneyKindCd7; }
            set { _payStMoneyKindCd7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd8
        /// <summary>支払設定金種コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd8
        {
            get { return _payStMoneyKindCd8; }
            set { _payStMoneyKindCd8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd9
        /// <summary>支払設定金種コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd9
        {
            get { return _payStMoneyKindCd9; }
            set { _payStMoneyKindCd9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd10
        /// <summary>支払設定金種コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd10
        {
            get { return _payStMoneyKindCd10; }
            set { _payStMoneyKindCd10 = value; }
        }

        /// <summary>
        /// 支払設定ワークコンストラクタ
        /// </summary>
        /// <returns>PaymentSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PaymentSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PaymentSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PaymentSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PaymentSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PaymentSetWork || graph is ArrayList || graph is PaymentSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PaymentSetWork).FullName));

            if (graph != null && graph is PaymentSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PaymentSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PaymentSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PaymentSetWork[])graph).Length;
            }
            else if (graph is PaymentSetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //支払設定管理No
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMngNo
            //支払設定金種コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd1
            //支払設定金種コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd2
            //支払設定金種コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd3
            //支払設定金種コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd4
            //支払設定金種コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd5
            //支払設定金種コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd6
            //支払設定金種コード7
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd7
            //支払設定金種コード8
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd8
            //支払設定金種コード9
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd9
            //支払設定金種コード10
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd10


            serInfo.Serialize(writer, serInfo);
            if (graph is PaymentSetWork)
            {
                PaymentSetWork temp = (PaymentSetWork)graph;

                SetPaymentSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PaymentSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PaymentSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PaymentSetWork temp in lst)
                {
                    SetPaymentSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PaymentSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  PaymentSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPaymentSetWork(System.IO.BinaryWriter writer, PaymentSetWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //支払設定管理No
            writer.Write(temp.PayStMngNo);
            //支払設定金種コード1
            writer.Write(temp.PayStMoneyKindCd1);
            //支払設定金種コード2
            writer.Write(temp.PayStMoneyKindCd2);
            //支払設定金種コード3
            writer.Write(temp.PayStMoneyKindCd3);
            //支払設定金種コード4
            writer.Write(temp.PayStMoneyKindCd4);
            //支払設定金種コード5
            writer.Write(temp.PayStMoneyKindCd5);
            //支払設定金種コード6
            writer.Write(temp.PayStMoneyKindCd6);
            //支払設定金種コード7
            writer.Write(temp.PayStMoneyKindCd7);
            //支払設定金種コード8
            writer.Write(temp.PayStMoneyKindCd8);
            //支払設定金種コード9
            writer.Write(temp.PayStMoneyKindCd9);
            //支払設定金種コード10
            writer.Write(temp.PayStMoneyKindCd10);

        }

        /// <summary>
        ///  PaymentSetWorkインスタンス取得
        /// </summary>
        /// <returns>PaymentSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PaymentSetWork GetPaymentSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PaymentSetWork temp = new PaymentSetWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //支払設定管理No
            temp.PayStMngNo = reader.ReadInt32();
            //支払設定金種コード1
            temp.PayStMoneyKindCd1 = reader.ReadInt32();
            //支払設定金種コード2
            temp.PayStMoneyKindCd2 = reader.ReadInt32();
            //支払設定金種コード3
            temp.PayStMoneyKindCd3 = reader.ReadInt32();
            //支払設定金種コード4
            temp.PayStMoneyKindCd4 = reader.ReadInt32();
            //支払設定金種コード5
            temp.PayStMoneyKindCd5 = reader.ReadInt32();
            //支払設定金種コード6
            temp.PayStMoneyKindCd6 = reader.ReadInt32();
            //支払設定金種コード7
            temp.PayStMoneyKindCd7 = reader.ReadInt32();
            //支払設定金種コード8
            temp.PayStMoneyKindCd8 = reader.ReadInt32();
            //支払設定金種コード9
            temp.PayStMoneyKindCd9 = reader.ReadInt32();
            //支払設定金種コード10
            temp.PayStMoneyKindCd10 = reader.ReadInt32();


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
        /// <returns>PaymentSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PaymentSetWork temp = GetPaymentSetWork(reader, serInfo);
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
                    retValue = (PaymentSetWork[])lst.ToArray(typeof(PaymentSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
