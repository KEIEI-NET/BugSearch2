using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriUpdTblUpdHisWork
    /// <summary>
    ///                      価格改正テーブル更新履歴ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   価格改正テーブル更新履歴ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriUpdTblUpdHisWork : IFileHeader
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

        /// <summary>更新データ区分</summary>
        /// <remarks>0:ＵＩ　1:自動</remarks>
        private Int32 _updateDataDiv;

        /// <summary>データ更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _dataUpdateDateTime;

        /// <summary>シンク対象テーブルID</summary>
        private string _syncTableID = "";

        /// <summary>シンク対象テーブル名</summary>
        private string _syncTableName = "";

        /// <summary>追加更新行数</summary>
        private Int32 _addUpdateRowsNo;

        /// <summary>シンク実行日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _syncExecuteDate;

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>提供バージョン</summary>
        /// <remarks>xx.xx.xx.xxx（8.10.1.0）</remarks>
        private string _offerVersion = "";

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

        /// public propaty name  :  UpdateDataDiv
        /// <summary>更新データ区分プロパティ</summary>
        /// <value>0:ＵＩ　1:自動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDataDiv
        {
            get { return _updateDataDiv; }
            set { _updateDataDiv = value; }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>データ更新日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  SyncTableID
        /// <summary>シンク対象テーブルIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク対象テーブルIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncTableID
        {
            get { return _syncTableID; }
            set { _syncTableID = value; }
        }

        /// public propaty name  :  SyncTableName
        /// <summary>シンク対象テーブル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク対象テーブル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SyncTableName
        {
            get { return _syncTableName; }
            set { _syncTableName = value; }
        }

        /// public propaty name  :  AddUpdateRowsNo
        /// <summary>追加更新行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加更新行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpdateRowsNo
        {
            get { return _addUpdateRowsNo; }
            set { _addUpdateRowsNo = value; }
        }

        /// public propaty name  :  SyncExecuteDate
        /// <summary>シンク実行日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SyncExecuteDate
        {
            get { return _syncExecuteDate; }
            set { _syncExecuteDate = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferVersion
        /// <summary>提供バージョンプロパティ</summary>
        /// <value>xx.xx.xx.xxx（8.10.1.0）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供バージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfferVersion
        {
            get { return _offerVersion; }
            set { _offerVersion = value; }
        }

        /// <summary>
        /// 価格改正テーブル更新履歴ワークコンストラクタ
        /// </summary>
        /// <returns>PriUpdTblUpdHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriUpdTblUpdHisWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PriUpdTblUpdHisWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PriUpdTblUpdHisWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriUpdTblUpdHisWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriUpdTblUpdHisWork || graph is ArrayList || graph is PriUpdTblUpdHisWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PriUpdTblUpdHisWork).FullName));

            if (graph != null && graph is PriUpdTblUpdHisWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriUpdTblUpdHisWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriUpdTblUpdHisWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriUpdTblUpdHisWork[])graph).Length;
            }
            else if (graph is PriUpdTblUpdHisWork)
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
            //更新データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDataDiv
            //データ更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime
            //シンク対象テーブルID
            serInfo.MemberInfo.Add(typeof(string)); //SyncTableID
            //シンク対象テーブル名
            serInfo.MemberInfo.Add(typeof(string)); //SyncTableName
            //追加更新行数
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpdateRowsNo
            //シンク実行日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncExecuteDate
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //提供バージョン
            serInfo.MemberInfo.Add(typeof(string)); //OfferVersion


            serInfo.Serialize(writer, serInfo);
            if (graph is PriUpdTblUpdHisWork)
            {
                PriUpdTblUpdHisWork temp = (PriUpdTblUpdHisWork)graph;

                SetPriUpdTblUpdHisWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriUpdTblUpdHisWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriUpdTblUpdHisWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriUpdTblUpdHisWork temp in lst)
                {
                    SetPriUpdTblUpdHisWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PriUpdTblUpdHisWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  PriUpdTblUpdHisWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPriUpdTblUpdHisWork(System.IO.BinaryWriter writer, PriUpdTblUpdHisWork temp)
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
            //更新データ区分
            writer.Write(temp.UpdateDataDiv);
            //データ更新日時
            writer.Write(temp.DataUpdateDateTime);
            //シンク対象テーブルID
            writer.Write(temp.SyncTableID);
            //シンク対象テーブル名
            writer.Write(temp.SyncTableName);
            //追加更新行数
            writer.Write(temp.AddUpdateRowsNo);
            //シンク実行日付
            writer.Write(temp.SyncExecuteDate);
            //提供日付
            writer.Write(temp.OfferDate);
            //提供バージョン
            writer.Write(temp.OfferVersion);

        }

        /// <summary>
        ///  PriUpdTblUpdHisWorkインスタンス取得
        /// </summary>
        /// <returns>PriUpdTblUpdHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PriUpdTblUpdHisWork GetPriUpdTblUpdHisWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PriUpdTblUpdHisWork temp = new PriUpdTblUpdHisWork();

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
            //更新データ区分
            temp.UpdateDataDiv = reader.ReadInt32();
            //データ更新日時
            temp.DataUpdateDateTime = reader.ReadInt64();
            //シンク対象テーブルID
            temp.SyncTableID = reader.ReadString();
            //シンク対象テーブル名
            temp.SyncTableName = reader.ReadString();
            //追加更新行数
            temp.AddUpdateRowsNo = reader.ReadInt32();
            //シンク実行日付
            temp.SyncExecuteDate = reader.ReadInt32();
            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //提供バージョン
            temp.OfferVersion = reader.ReadString();


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
        /// <returns>PriUpdTblUpdHisWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriUpdTblUpdHisWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriUpdTblUpdHisWork temp = GetPriUpdTblUpdHisWork(reader, serInfo);
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
                    retValue = (PriUpdTblUpdHisWork[])lst.ToArray(typeof(PriUpdTblUpdHisWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
