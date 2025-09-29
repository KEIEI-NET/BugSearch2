//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO検索マスタ(ユーザー登録)データパラメータ
//                  :   PMKEN09116D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.11.17
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
    /// public class name:   TBOSearchUWork
    /// <summary>
    ///                      TBO検索（ユーザー登録）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO検索（ユーザー登録）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2008/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   β版→PM.NS対応</br>
    /// <br>Update Note      :   2008/10/17  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   BL商品コード</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchUWork : IFileHeader
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

        /// <summary>BL商品コード</summary>
        /// <remarks>提供:1～9999 ユーザー:10000～</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>装備分類</summary>
        /// <remarks>例）1001：バッテリ</remarks>
        private Int32 _equipGenreCode;

        /// <summary>装備名称</summary>
        /// <remarks>例）100D26L（バッテリ規格）</remarks>
        private string _equipName = "";

        /// <summary>車両結合表示順位</summary>
        /// <remarks>4,5,6,7,8が同一の結合が複数存在する場合の連番</remarks>
        private Int32 _carInfoJoinDispOrder;

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合ＱＴＹ</summary>
        private Double _joinQty;

        /// <summary>装備規格・特記事項</summary>
        private string _equipSpecialNote = "";

        /// <summary>結合先メーカー名称</summary>
        private string _joinDestMakerName = "";

        /// <summary>結合先品名</summary>
        private string _joinDestGoodsName = "";


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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>提供:1～9999 ユーザー:10000～</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  EquipGenreCode
        /// <summary>装備分類プロパティ</summary>
        /// <value>例）1001：バッテリ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>装備名称プロパティ</summary>
        /// <value>例）100D26L（バッテリ規格）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  CarInfoJoinDispOrder
        /// <summary>車両結合表示順位プロパティ</summary>
        /// <value>4,5,6,7,8が同一の結合が複数存在する場合の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarInfoJoinDispOrder
        {
            get { return _carInfoJoinDispOrder; }
            set { _carInfoJoinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>結合先品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>結合ＱＴＹプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合ＱＴＹプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  EquipSpecialNote
        /// <summary>装備規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipSpecialNote
        {
            get { return _equipSpecialNote; }
            set { _equipSpecialNote = value; }
        }

        /// public propaty name  :  JoinDestMakerName
        /// <summary>結合先メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestMakerName
        {
            get { return _joinDestMakerName; }
            set { _joinDestMakerName = value; }
        }

        /// public propaty name  :  JoinDestGoodsName
        /// <summary>結合先品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestGoodsName
        {
            get { return _joinDestGoodsName; }
            set { _joinDestGoodsName = value; }
        }


        /// <summary>
        /// TBO検索（ユーザー登録）ワークコンストラクタ
        /// </summary>
        /// <returns>TBOSearchUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TBOSearchUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TBOSearchUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TBOSearchUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBOSearchUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBOSearchUWork || graph is ArrayList || graph is TBOSearchUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TBOSearchUWork).FullName));

            if (graph != null && graph is TBOSearchUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBOSearchUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBOSearchUWork[])graph).Length;
            }
            else if (graph is TBOSearchUWork)
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
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //装備分類
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenreCode
            //装備名称
            serInfo.MemberInfo.Add(typeof(string)); //EquipName
            //車両結合表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //CarInfoJoinDispOrder
            //結合先メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //結合先品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //結合ＱＴＹ
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //装備規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //EquipSpecialNote
            //結合先メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestMakerName
            //結合先品名
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestGoodsName


            serInfo.Serialize(writer, serInfo);
            if (graph is TBOSearchUWork)
            {
                TBOSearchUWork temp = (TBOSearchUWork)graph;

                SetTBOSearchUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBOSearchUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBOSearchUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBOSearchUWork temp in lst)
                {
                    SetTBOSearchUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TBOSearchUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  TBOSearchUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTBOSearchUWork(System.IO.BinaryWriter writer, TBOSearchUWork temp)
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
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //装備分類
            writer.Write(temp.EquipGenreCode);
            //装備名称
            writer.Write(temp.EquipName);
            //車両結合表示順位
            writer.Write(temp.CarInfoJoinDispOrder);
            //結合先メーカーコード
            writer.Write(temp.JoinDestMakerCd);
            //結合先品番(－付き品番)
            writer.Write(temp.JoinDestPartsNo);
            //結合ＱＴＹ
            writer.Write(temp.JoinQty);
            //装備規格・特記事項
            writer.Write(temp.EquipSpecialNote);
            //結合先メーカー名称
            writer.Write(temp.JoinDestMakerName);
            //結合先品名
            writer.Write(temp.JoinDestGoodsName);

        }

        /// <summary>
        ///  TBOSearchUWorkインスタンス取得
        /// </summary>
        /// <returns>TBOSearchUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TBOSearchUWork GetTBOSearchUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TBOSearchUWork temp = new TBOSearchUWork();

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
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //装備分類
            temp.EquipGenreCode = reader.ReadInt32();
            //装備名称
            temp.EquipName = reader.ReadString();
            //車両結合表示順位
            temp.CarInfoJoinDispOrder = reader.ReadInt32();
            //結合先メーカーコード
            temp.JoinDestMakerCd = reader.ReadInt32();
            //結合先品番(－付き品番)
            temp.JoinDestPartsNo = reader.ReadString();
            //結合ＱＴＹ
            temp.JoinQty = reader.ReadDouble();
            //装備規格・特記事項
            temp.EquipSpecialNote = reader.ReadString();
            //結合先メーカー名称
            temp.JoinDestMakerName = reader.ReadString();
            //結合先品名
            temp.JoinDestGoodsName = reader.ReadString();


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
        /// <returns>TBOSearchUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBOSearchUWork temp = GetTBOSearchUWork(reader, serInfo);
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
                    retValue = (TBOSearchUWork[])lst.ToArray(typeof(TBOSearchUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
