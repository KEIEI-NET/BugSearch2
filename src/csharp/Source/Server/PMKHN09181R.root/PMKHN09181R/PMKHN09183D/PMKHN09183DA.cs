using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PosTerminalMgServerWork
    /// <summary>
    ///                      端末管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   端末管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/06/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/4/21  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   端末IPアドレス</br>
    /// <br>                 :   端末名称</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PosTerminalMgServerWork : IFileHeader
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

        /// <summary>レジ番号</summary>
        /// <remarks>マシン番号</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>POS/PC端末使用区分</summary>
        /// <remarks>1：POS端末使用、2：PC端末使用</remarks>
        private Int32 _posPCTermCd;

        /// <summary>使用言語区分</summary>
        private string _useLanguageDivCd = "";

        /// <summary>使用カルチャー区分</summary>
        private string _useCultureDivCd = "";

        /// <summary>端末IPアドレス</summary>
        private string _machineIpAddr = "";

        /// <summary>端末名称</summary>
        /// <remarks>コンピュータ名</remarks>
        private string _machineName = "";


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

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// <value>マシン番号</value>
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

        /// public propaty name  :  PosPCTermCd
        /// <summary>POS/PC端末使用区分プロパティ</summary>
        /// <value>1：POS端末使用、2：PC端末使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POS/PC端末使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PosPCTermCd
        {
            get { return _posPCTermCd; }
            set { _posPCTermCd = value; }
        }

        /// public propaty name  :  UseLanguageDivCd
        /// <summary>使用言語区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用言語区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UseLanguageDivCd
        {
            get { return _useLanguageDivCd; }
            set { _useLanguageDivCd = value; }
        }

        /// public propaty name  :  UseCultureDivCd
        /// <summary>使用カルチャー区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用カルチャー区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UseCultureDivCd
        {
            get { return _useCultureDivCd; }
            set { _useCultureDivCd = value; }
        }

        /// public propaty name  :  MachineIpAddr
        /// <summary>端末IPアドレスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末IPアドレスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineIpAddr
        {
            get { return _machineIpAddr; }
            set { _machineIpAddr = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>端末名称プロパティ</summary>
        /// <value>コンピュータ名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }


        /// <summary>
        /// 端末管理ワークコンストラクタ
        /// </summary>
        /// <returns>PosTerminalMgServerWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgServerWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PosTerminalMgServerWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PosTerminalMgServerWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PosTerminalMgServerWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PosTerminalMgServerWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgServerWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PosTerminalMgServerWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PosTerminalMgServerWork || graph is ArrayList || graph is PosTerminalMgServerWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PosTerminalMgServerWork).FullName));

            if (graph != null && graph is PosTerminalMgServerWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PosTerminalMgServerWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PosTerminalMgServerWork[])graph).Length;
            }
            else if (graph is PosTerminalMgServerWork)
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
            //レジ番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //POS/PC端末使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PosPCTermCd
            //使用言語区分
            serInfo.MemberInfo.Add(typeof(string)); //UseLanguageDivCd
            //使用カルチャー区分
            serInfo.MemberInfo.Add(typeof(string)); //UseCultureDivCd
            //端末IPアドレス
            serInfo.MemberInfo.Add(typeof(string)); //MachineIpAddr
            //端末名称
            serInfo.MemberInfo.Add(typeof(string)); //MachineName


            serInfo.Serialize(writer, serInfo);
            if (graph is PosTerminalMgServerWork)
            {
                PosTerminalMgServerWork temp = (PosTerminalMgServerWork)graph;

                SetPosTerminalMgServerWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PosTerminalMgServerWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PosTerminalMgServerWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PosTerminalMgServerWork temp in lst)
                {
                    SetPosTerminalMgServerWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PosTerminalMgServerWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  PosTerminalMgServerWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgServerWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPosTerminalMgServerWork(System.IO.BinaryWriter writer, PosTerminalMgServerWork temp)
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
            //レジ番号
            writer.Write(temp.CashRegisterNo);
            //POS/PC端末使用区分
            writer.Write(temp.PosPCTermCd);
            //使用言語区分
            writer.Write(temp.UseLanguageDivCd);
            //使用カルチャー区分
            writer.Write(temp.UseCultureDivCd);
            //端末IPアドレス
            writer.Write(temp.MachineIpAddr);
            //端末名称
            writer.Write(temp.MachineName);

        }

        /// <summary>
        ///  PosTerminalMgServerWorkインスタンス取得
        /// </summary>
        /// <returns>PosTerminalMgServerWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgServerWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PosTerminalMgServerWork GetPosTerminalMgServerWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PosTerminalMgServerWork temp = new PosTerminalMgServerWork();

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
            //レジ番号
            temp.CashRegisterNo = reader.ReadInt32();
            //POS/PC端末使用区分
            temp.PosPCTermCd = reader.ReadInt32();
            //使用言語区分
            temp.UseLanguageDivCd = reader.ReadString();
            //使用カルチャー区分
            temp.UseCultureDivCd = reader.ReadString();
            //端末IPアドレス
            temp.MachineIpAddr = reader.ReadString();
            //端末名称
            temp.MachineName = reader.ReadString();


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
        /// <returns>PosTerminalMgServerWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgServerWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PosTerminalMgServerWork temp = GetPosTerminalMgServerWork(reader, serInfo);
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
                    retValue = (PosTerminalMgServerWork[])lst.ToArray(typeof(PosTerminalMgServerWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}