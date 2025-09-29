using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PM7RkSRHistWork
    /// <summary>
    ///                      PM7連携送受信履歴ログデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   PM7連携送受信履歴ログデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/22  呂亜玲</br>
    /// <br>                 :   自動区分を追加する</br>
    /// <br>                 :   送受信エラーの場合、履歴を登録しないため、ステータス、送信エラーログファイル名称、受信エラーログファイル名称を削除する</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PM7RkSRHistWork : IFileHeader
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>PM7連携送受信履歴番号</summary>
        private string _pM7RkSRHistNo = "";

        /// <summary>PM7連携履歴区分</summary>
        /// <remarks>1：送信　2：受信</remarks>
        private Int32 _pM7RkHistCode;

        /// <summary>PM7連携自動区分</summary>
        /// <remarks>0：手動　1：自動</remarks>
        private Int32 _pM7RkAutoCode;

        /// <summary>送信開始日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _sndBeginDateTime;

        /// <summary>送信終了日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _sndEndDateTime;

        /// <summary>送信ファイル名称</summary>
        private string _sndFileNm = "";

        /// <summary>受信開始日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _rcvBeginDateTime;

        /// <summary>受信終了日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _rcvEndDateTime;

        /// <summary>受信ファイル名称</summary>
        private string _rcvFileNm = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  PM7RkSRHistNo
        /// <summary>PM7連携送受信履歴番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7連携送受信履歴番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PM7RkSRHistNo
        {
            get { return _pM7RkSRHistNo; }
            set { _pM7RkSRHistNo = value; }
        }

        /// public propaty name  :  PM7RkHistCode
        /// <summary>PM7連携履歴区分プロパティ</summary>
        /// <value>1：送信　2：受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7連携履歴区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PM7RkHistCode
        {
            get { return _pM7RkHistCode; }
            set { _pM7RkHistCode = value; }
        }

        /// public propaty name  :  PM7RkAutoCode
        /// <summary>PM7連携自動区分プロパティ</summary>
        /// <value>0：手動　1：自動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM7連携自動区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PM7RkAutoCode
        {
            get { return _pM7RkAutoCode; }
            set { _pM7RkAutoCode = value; }
        }

        /// public propaty name  :  SndBeginDateTime
        /// <summary>送信開始日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndBeginDateTime
        {
            get { return _sndBeginDateTime; }
            set { _sndBeginDateTime = value; }
        }

        /// public propaty name  :  SndEndDateTime
        /// <summary>送信終了日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SndEndDateTime
        {
            get { return _sndEndDateTime; }
            set { _sndEndDateTime = value; }
        }

        /// public propaty name  :  SndFileNm
        /// <summary>送信ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndFileNm
        {
            get { return _sndFileNm; }
            set { _sndFileNm = value; }
        }

        /// public propaty name  :  RcvBeginDateTime
        /// <summary>受信開始日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RcvBeginDateTime
        {
            get { return _rcvBeginDateTime; }
            set { _rcvBeginDateTime = value; }
        }

        /// public propaty name  :  RcvEndDateTime
        /// <summary>受信終了日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 RcvEndDateTime
        {
            get { return _rcvEndDateTime; }
            set { _rcvEndDateTime = value; }
        }

        /// public propaty name  :  RcvFileNm
        /// <summary>受信ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RcvFileNm
        {
            get { return _rcvFileNm; }
            set { _rcvFileNm = value; }
        }


        /// <summary>
        /// PM7連携送受信履歴ログデータワークコンストラクタ
        /// </summary>
        /// <returns>PM7RkSRHistWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSRHistWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PM7RkSRHistWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PM7RkSRHistWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PM7RkSRHistWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PM7RkSRHistWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSRHistWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PM7RkSRHistWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PM7RkSRHistWork || graph is ArrayList || graph is PM7RkSRHistWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PM7RkSRHistWork).FullName));

            if (graph != null && graph is PM7RkSRHistWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PM7RkSRHistWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PM7RkSRHistWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PM7RkSRHistWork[])graph).Length;
            }
            else if (graph is PM7RkSRHistWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //PM7連携送受信履歴番号
            serInfo.MemberInfo.Add(typeof(string)); //PM7RkSRHistNo
            //PM7連携履歴区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PM7RkHistCode
            //PM7連携自動区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PM7RkAutoCode
            //送信開始日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndBeginDateTime
            //送信終了日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndEndDateTime
            //送信ファイル名称
            serInfo.MemberInfo.Add(typeof(string)); //SndFileNm
            //受信開始日時
            serInfo.MemberInfo.Add(typeof(Int64)); //RcvBeginDateTime
            //受信終了日時
            serInfo.MemberInfo.Add(typeof(Int64)); //RcvEndDateTime
            //受信ファイル名称
            serInfo.MemberInfo.Add(typeof(string)); //RcvFileNm


            serInfo.Serialize(writer, serInfo);
            if (graph is PM7RkSRHistWork)
            {
                PM7RkSRHistWork temp = (PM7RkSRHistWork)graph;

                SetPM7RkSRHistWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PM7RkSRHistWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PM7RkSRHistWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PM7RkSRHistWork temp in lst)
                {
                    SetPM7RkSRHistWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PM7RkSRHistWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  PM7RkSRHistWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSRHistWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPM7RkSRHistWork(System.IO.BinaryWriter writer, PM7RkSRHistWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //PM7連携送受信履歴番号
            writer.Write(temp.PM7RkSRHistNo);
            //PM7連携履歴区分
            writer.Write(temp.PM7RkHistCode);
            //PM7連携自動区分
            writer.Write(temp.PM7RkAutoCode);
            //送信開始日時
            writer.Write(temp.SndBeginDateTime);
            //送信終了日時
            writer.Write(temp.SndEndDateTime);
            //送信ファイル名称
            writer.Write(temp.SndFileNm);
            //受信開始日時
            writer.Write(temp.RcvBeginDateTime);
            //受信終了日時
            writer.Write(temp.RcvEndDateTime);
            //受信ファイル名称
            writer.Write(temp.RcvFileNm);

        }

        /// <summary>
        ///  PM7RkSRHistWorkインスタンス取得
        /// </summary>
        /// <returns>PM7RkSRHistWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSRHistWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PM7RkSRHistWork GetPM7RkSRHistWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PM7RkSRHistWork temp = new PM7RkSRHistWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //PM7連携送受信履歴番号
            temp.PM7RkSRHistNo = reader.ReadString();
            //PM7連携履歴区分
            temp.PM7RkHistCode = reader.ReadInt32();
            //PM7連携自動区分
            temp.PM7RkAutoCode = reader.ReadInt32();
            //送信開始日時
            temp.SndBeginDateTime = reader.ReadInt64();
            //送信終了日時
            temp.SndEndDateTime = reader.ReadInt64();
            //送信ファイル名称
            temp.SndFileNm = reader.ReadString();
            //受信開始日時
            temp.RcvBeginDateTime = reader.ReadInt64();
            //受信終了日時
            temp.RcvEndDateTime = reader.ReadInt64();
            //受信ファイル名称
            temp.RcvFileNm = reader.ReadString();


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
        /// <returns>PM7RkSRHistWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PM7RkSRHistWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PM7RkSRHistWork temp = GetPM7RkSRHistWork(reader, serInfo);
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
                    retValue = (PM7RkSRHistWork[])lst.ToArray(typeof(PM7RkSRHistWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
