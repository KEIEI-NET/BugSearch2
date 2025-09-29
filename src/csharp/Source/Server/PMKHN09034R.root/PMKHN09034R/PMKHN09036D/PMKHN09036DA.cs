//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタデータパラメータ
//                  :   PMKHN09036D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内 数馬
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ModelNameUWork
    /// <summary>
    ///                      車種名称（ユーザー登録）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車種名称（ユーザー登録）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/05/27</br>
    /// <br>Genarated Date   :   2008/06/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ModelNameUWork : IFileHeader
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

        /// <summary>車種コード（ユニーク）</summary>
        /// <remarks>メーカーコード3桁+車種コード3桁+車種サブコード3桁</remarks>
        private Int32 _modelUniqueCode;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ユーザー登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>車種呼び名名称</summary>
        /// <remarks>呼び名（発音で管理）</remarks>
        private string _modelAliasName = "";

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:提供データ,1:ユーザーデータ</remarks>
        private Int32 _offerDataDiv;


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

        /// public propaty name  :  ModelUniqueCode
        /// <summary>車種コード（ユニーク）プロパティ</summary>
        /// <value>メーカーコード3桁+車種コード3桁+車種サブコード3桁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（ユニーク）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelUniqueCode
        {
            get { return _modelUniqueCode; }
            set { _modelUniqueCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  ModelAliasName
        /// <summary>車種呼び名名称プロパティ</summary>
        /// <value>呼び名（発音で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種呼び名名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelAliasName
        {
            get { return _modelAliasName; }
            set { _modelAliasName = value; }
        }


        /// <summary>
        /// 車種名称（ユーザー登録）ワークコンストラクタ
        /// </summary>
        /// <returns>ModelNameUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameUWork()
        {
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分</summary>
        /// <value>0:提供データ,1:ユーザーデータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }


    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ModelNameUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ModelNameUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ModelNameUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ModelNameUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ModelNameUWork || graph is ArrayList || graph is ModelNameUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ModelNameUWork).FullName));

            if (graph != null && graph is ModelNameUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ModelNameUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ModelNameUWork[])graph).Length;
            }
            else if (graph is ModelNameUWork)
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
            //車種コード（ユニーク）
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelUniqueCode
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //車種呼び名名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelAliasName
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv

            serInfo.Serialize(writer, serInfo);
            if (graph is ModelNameUWork)
            {
                ModelNameUWork temp = (ModelNameUWork)graph;

                SetModelNameUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ModelNameUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ModelNameUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ModelNameUWork temp in lst)
                {
                    SetModelNameUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ModelNameUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  ModelNameUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetModelNameUWork(System.IO.BinaryWriter writer, ModelNameUWork temp)
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
            //車種コード（ユニーク）
            writer.Write(temp.ModelUniqueCode);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //車種呼び名名称
            writer.Write(temp.ModelAliasName);
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);
        }

        /// <summary>
        ///  ModelNameUWorkインスタンス取得
        /// </summary>
        /// <returns>ModelNameUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ModelNameUWork GetModelNameUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ModelNameUWork temp = new ModelNameUWork();

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
            //車種コード（ユニーク）
            temp.ModelUniqueCode = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //車種呼び名名称
            temp.ModelAliasName = reader.ReadString();
            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();


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
        /// <returns>ModelNameUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ModelNameUWork temp = GetModelNameUWork(reader, serInfo);
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
                    retValue = (ModelNameUWork[])lst.ToArray(typeof(ModelNameUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
