using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TbsPartsCodeWork
    /// <summary>
    ///                      ＢＬコードワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＢＬコードワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/1/17</br>
    /// <br>Genarated Date   :   2008/06/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   β版→PM.NS対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TbsPartsCodeWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        /// <remarks>※グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>BLコード名称（全角）</summary>
        private string _tbsPartsFullName = "";

        /// <summary>BLコード名称（半角）</summary>
        private string _tbsPartsHalfName = "";

        /// <summary>装備分類</summary>
        /// <remarks>例）1001：バッテリ</remarks>
        private Int32 _equipGenre;
        
        /// <summary>優良検索区分</summary>
        /// <remarks>0：優良検索無し　1：優良検索有り</remarks>
        private Int32 _primeSearchFlg;


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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>※グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
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

        /// public propaty name  :  TbsPartsFullName
        /// <summary>BLコード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsFullName
        {
            get { return _tbsPartsFullName; }
            set { _tbsPartsFullName = value; }
        }

        /// public propaty name  :  TbsPartsHalfName
        /// <summary>BLコード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsHalfName
        {
            get { return _tbsPartsHalfName; }
            set { _tbsPartsHalfName = value; }
        }

        /// public propaty name  :  EquipGenre
        /// <summary>装備分類プロパティ</summary>
        /// <value>例）1001：バッテリ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipGenre
        {
            get { return _equipGenre; }
            set { _equipGenre = value; }
        }

        /// public propaty name  :  PrimeSearchFlg
        /// <summary>優良検索区分プロパティ</summary>
        /// <value>0：優良検索無し　1：優良検索有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrimeSearchFlg
        {
            get { return _primeSearchFlg; }
            set { _primeSearchFlg = value; }
        }

        /// <summary>
        /// ＢＬコードワークコンストラクタ
        /// </summary>
        /// <returns>TbsPartsCodeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCodeWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TbsPartsCodeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TbsPartsCodeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TbsPartsCodeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TbsPartsCodeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCodeWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TbsPartsCodeWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TbsPartsCodeWork || graph is ArrayList || graph is TbsPartsCodeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TbsPartsCodeWork).FullName));

            if (graph != null && graph is TbsPartsCodeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TbsPartsCodeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TbsPartsCodeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TbsPartsCodeWork[])graph).Length;
            }
            else if (graph is TbsPartsCodeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //BLコード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //TbsPartsFullName
            //BLコード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //TbsPartsHalfName
            //装備分類
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenre
            //優良検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeSearchFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is TbsPartsCodeWork)
            {
                TbsPartsCodeWork temp = (TbsPartsCodeWork)graph;

                SetTbsPartsCodeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TbsPartsCodeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TbsPartsCodeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TbsPartsCodeWork temp in lst)
                {
                    SetTbsPartsCodeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TbsPartsCodeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  TbsPartsCodeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCodeWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTbsPartsCodeWork(System.IO.BinaryWriter writer, TbsPartsCodeWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //BLコード名称（全角）
            writer.Write(temp.TbsPartsFullName);
            //BLコード名称（半角）
            writer.Write(temp.TbsPartsHalfName);
            //装備分類
            writer.Write(temp.EquipGenre);
            //優良検索区分
            writer.Write(temp.PrimeSearchFlg);

        }

        /// <summary>
        ///  TbsPartsCodeWorkインスタンス取得
        /// </summary>
        /// <returns>TbsPartsCodeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCodeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TbsPartsCodeWork GetTbsPartsCodeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TbsPartsCodeWork temp = new TbsPartsCodeWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //BLコード名称（全角）
            temp.TbsPartsFullName = reader.ReadString();
            //BLコード名称（半角）
            temp.TbsPartsHalfName = reader.ReadString();
            //装備分類
            temp.EquipGenre = reader.ReadInt32();
            //優良検索区分
            temp.PrimeSearchFlg = reader.ReadInt32();


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
        /// <returns>TbsPartsCodeWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCodeWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TbsPartsCodeWork temp = GetTbsPartsCodeWork(reader, serInfo);
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
                    retValue = (TbsPartsCodeWork[])lst.ToArray(typeof(TbsPartsCodeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
