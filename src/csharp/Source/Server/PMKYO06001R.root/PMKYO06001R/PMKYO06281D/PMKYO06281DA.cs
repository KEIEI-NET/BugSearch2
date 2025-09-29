//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信抽出・更新DB仲介クラス              //
//                  :   PMKYO06281D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.04.29                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APJoinPartsUWork
    /// <summary>
    ///                      結合（ユーザー登録）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合（ユーザー登録）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2006/11/22</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APJoinPartsUWork : IFileHeader
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

        /// <summary>結合表示順位</summary>
        /// <remarks>ユーザー登録分の表示順位（提供より必ず上になる）</remarks>
        private Int32 _joinDispOrder;

        /// <summary>結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithH = "";

        /// <summary>結合元品番(－無し品番)</summary>
        private string _joinSourPartsNoNoneH = "";

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合QTY</summary>
        private Double _joinQty;

        /// <summary>結合規格・特記事項</summary>
        private string _joinSpecialNote = "";


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

        /// public propaty name  :  JoinDispOrder
        /// <summary>結合表示順位プロパティ</summary>
        /// <value>ユーザー登録分の表示順位（提供より必ず上になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>結合元品番(－無し品番)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
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
        /// <summary>結合QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>結合規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
        }


        /// <summary>
        /// 結合（ユーザー登録）ワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APJoinPartsUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>JoinPartsUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   JoinPartsUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class APJoinPartsUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  JoinPartsUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APJoinPartsUWork || graph is ArrayList || graph is APJoinPartsUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APJoinPartsUWork).FullName));

            if (graph != null && graph is APJoinPartsUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APJoinPartsUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APJoinPartsUWork[])graph).Length;
            }
            else if (graph is APJoinPartsUWork)
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
            //結合表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
            //結合元メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
            //結合元品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
            //結合元品番(－無し品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
            //結合先メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //結合先品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //結合QTY
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //結合規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote


            serInfo.Serialize(writer, serInfo);
            if (graph is APJoinPartsUWork)
            {
                APJoinPartsUWork temp = (APJoinPartsUWork)graph;

                SetJoinPartsUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APJoinPartsUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APJoinPartsUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APJoinPartsUWork temp in lst)
                {
                    SetJoinPartsUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// JoinPartsUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  JoinPartsUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetJoinPartsUWork(System.IO.BinaryWriter writer, APJoinPartsUWork temp)
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
            //結合表示順位
            writer.Write(temp.JoinDispOrder);
            //結合元メーカーコード
            writer.Write(temp.JoinSourceMakerCode);
            //結合元品番(－付き品番)
            writer.Write(temp.JoinSourPartsNoWithH);
            //結合元品番(－無し品番)
            writer.Write(temp.JoinSourPartsNoNoneH);
            //結合先メーカーコード
            writer.Write(temp.JoinDestMakerCd);
            //結合先品番(－付き品番)
            writer.Write(temp.JoinDestPartsNo);
            //結合QTY
            writer.Write(temp.JoinQty);
            //結合規格・特記事項
            writer.Write(temp.JoinSpecialNote);

        }

        /// <summary>
        ///  JoinPartsUWorkインスタンス取得
        /// </summary>
        /// <returns>JoinPartsUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private APJoinPartsUWork GetJoinPartsUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APJoinPartsUWork temp = new APJoinPartsUWork();

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
            //結合表示順位
            temp.JoinDispOrder = reader.ReadInt32();
            //結合元メーカーコード
            temp.JoinSourceMakerCode = reader.ReadInt32();
            //結合元品番(－付き品番)
            temp.JoinSourPartsNoWithH = reader.ReadString();
            //結合元品番(－無し品番)
            temp.JoinSourPartsNoNoneH = reader.ReadString();
            //結合先メーカーコード
            temp.JoinDestMakerCd = reader.ReadInt32();
            //結合先品番(－付き品番)
            temp.JoinDestPartsNo = reader.ReadString();
            //結合QTY
            temp.JoinQty = reader.ReadDouble();
            //結合規格・特記事項
            temp.JoinSpecialNote = reader.ReadString();


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
        /// <returns>JoinPartsUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APJoinPartsUWork temp = GetJoinPartsUWork(reader, serInfo);
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
                    retValue = (APJoinPartsUWork[])lst.ToArray(typeof(APJoinPartsUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
