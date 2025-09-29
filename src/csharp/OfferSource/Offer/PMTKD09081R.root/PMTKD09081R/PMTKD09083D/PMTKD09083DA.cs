using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsPosCodeWork
    /// <summary>
    ///                      部位コードワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部位コードワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2007/1/17</br>
    /// <br>Genarated Date   :   2008/06/17  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsPosCodeWork : IFileHeaderOffer2
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>検索タイプ</summary>
        /// <remarks>0:基本 10:拡張 20:外装</remarks>
        private Int32 _searchPartsType;

        /// <summary>大型提供区分</summary>
        /// <remarks>0:小型 1:大型</remarks>
        private Int32 _bigCarOfferDiv;

        /// <summary>検索部位コード</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>検索部位コード名称</summary>
        /// <remarks>表示順位0、BLコード0の場合部位名称をセット</remarks>
        private string _searchPartsPosName = "";

        /// <summary>検索部位表示順位</summary>
        private Int32 _posDispOrder;

        /// <summary>BLコード</summary>
        /// <remarks>０の場合、部位名称用レコード</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;


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

        /// public propaty name  :  SearchPartsType
        /// <summary>検索タイププロパティ</summary>
        /// <value>0:基本 10:拡張 20:外装</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsType
        {
            get { return _searchPartsType; }
            set { _searchPartsType = value; }
        }

        /// public propaty name  :  BigCarOfferDiv
        /// <summary>大型提供区分プロパティ</summary>
        /// <value>0:小型 1:大型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   大型提供区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BigCarOfferDiv
        {
            get { return _bigCarOfferDiv; }
            set { _bigCarOfferDiv = value; }
        }

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>検索部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>検索部位コード名称プロパティ</summary>
        /// <value>表示順位0、BLコード0の場合部位名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>検索部位表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>０の場合、部位名称用レコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }


        /// <summary>
        /// 部位コードワークコンストラクタ
        /// </summary>
        /// <returns>PartsPosCodeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsPosCodeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsPosCodeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsPosCodeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsPosCodeWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsPosCodeWork || graph is ArrayList || graph is PartsPosCodeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsPosCodeWork).FullName));

            if (graph != null && graph is PartsPosCodeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsPosCodeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsPosCodeWork[])graph).Length;
            }
            else if (graph is PartsPosCodeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchPartsType
            //大型提供区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BigCarOfferDiv
            //検索部位コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchPartsPosCode
            //検索部位コード名称
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsPosName
            //検索部位表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //PosDispOrder
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsPosCodeWork)
            {
                PartsPosCodeWork temp = (PartsPosCodeWork)graph;

                SetPartsPosCodeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsPosCodeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsPosCodeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsPosCodeWork temp in lst)
                {
                    SetPartsPosCodeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsPosCodeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  PartsPosCodeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsPosCodeWork(System.IO.BinaryWriter writer, PartsPosCodeWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //検索タイプ
            writer.Write(temp.SearchPartsType);
            //大型提供区分
            writer.Write(temp.BigCarOfferDiv);
            //検索部位コード
            writer.Write(temp.SearchPartsPosCode);
            //検索部位コード名称
            writer.Write(temp.SearchPartsPosName);
            //検索部位表示順位
            writer.Write(temp.PosDispOrder);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);

        }

        /// <summary>
        ///  PartsPosCodeWorkインスタンス取得
        /// </summary>
        /// <returns>PartsPosCodeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsPosCodeWork GetPartsPosCodeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsPosCodeWork temp = new PartsPosCodeWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //検索タイプ
            temp.SearchPartsType = reader.ReadInt32();
            //大型提供区分
            temp.BigCarOfferDiv = reader.ReadInt32();
            //検索部位コード
            temp.SearchPartsPosCode = reader.ReadInt32();
            //検索部位コード名称
            temp.SearchPartsPosName = reader.ReadString();
            //検索部位表示順位
            temp.PosDispOrder = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();


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
        /// <returns>PartsPosCodeWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsPosCodeWork temp = GetPartsPosCodeWork(reader, serInfo);
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
                    retValue = (PartsPosCodeWork[])lst.ToArray(typeof(PartsPosCodeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

