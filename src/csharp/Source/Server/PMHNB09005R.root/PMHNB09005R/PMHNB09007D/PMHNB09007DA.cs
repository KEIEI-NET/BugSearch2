//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//


using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetWork
    /// <summary>
    ///                      標準価格選択設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   標準価格選択設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/09/15</br>
    /// <br>Genarated Date   :   2009/10/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetWork : IFileHeader
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

        /// <summary>標準価格選択設定パターン</summary>
        /// <remarks>0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ,2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ,7:ﾒｰｶｰｺｰﾄﾞ,8:BLｺｰﾄﾞ</remarks>
        private Int32 _priceSelectPtn;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>標準価格選択区分</summary>
        /// <remarks>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";


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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>標準価格選択設定パターンプロパティ</summary>
        /// <value>0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ,2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ,7:ﾒｰｶｰｺｰﾄﾞ,8:BLｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択設定パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  PriceSelectDiv
        /// <summary>標準価格選択区分プロパティ</summary>
        /// <value>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }


        /// <summary>
        /// 標準価格選択設定ワークコンストラクタ
        /// </summary>
        /// <returns>PriceSelectSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceSelectSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PriceSelectSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PriceSelectSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PriceSelectSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceSelectSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceSelectSetWork || graph is ArrayList || graph is PriceSelectSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PriceSelectSetWork).FullName));

            if (graph != null && graph is PriceSelectSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceSelectSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceSelectSetWork[])graph).Length;
            }
            else if (graph is PriceSelectSetWork)
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
            //標準価格選択設定パターン
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectPtn
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //標準価格選択区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectDiv
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName


            serInfo.Serialize(writer, serInfo);
            if (graph is PriceSelectSetWork)
            {
                PriceSelectSetWork temp = (PriceSelectSetWork)graph;

                SetPriceSelectSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceSelectSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceSelectSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceSelectSetWork temp in lst)
                {
                    SetPriceSelectSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PriceSelectSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  PriceSelectSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPriceSelectSetWork(System.IO.BinaryWriter writer, PriceSelectSetWork temp)
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
            //標準価格選択設定パターン
            writer.Write(temp.PriceSelectPtn);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //標準価格選択区分
            writer.Write(temp.PriceSelectDiv);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //メーカー名称
            writer.Write(temp.MakerName);

        }

        /// <summary>
        ///  PriceSelectSetWorkインスタンス取得
        /// </summary>
        /// <returns>PriceSelectSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PriceSelectSetWork GetPriceSelectSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PriceSelectSetWork temp = new PriceSelectSetWork();

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
            //標準価格選択設定パターン
            temp.PriceSelectPtn = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //標準価格選択区分
            temp.PriceSelectDiv = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //メーカー名称
            temp.MakerName = reader.ReadString();


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
        /// <returns>PriceSelectSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceSelectSetWork temp = GetPriceSelectSetWork(reader, serInfo);
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
                    retValue = (PriceSelectSetWork[])lst.ToArray(typeof(PriceSelectSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

