using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBOSearchRetWork
    /// <summary>
    ///                      提供車輌情報結合検索抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供車輌情報結合検索抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchRetWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>装備分類</summary>
        /// <remarks>例）1001：バッテリ</remarks>
        private Int32 _equipGenreCode;

        /// <summary>装備名称</summary>
        /// <remarks>例）100D26L（バッテリ規格）</remarks>
        private string _equipName = "";

        /// <summary>車両結合表示順位</summary>
        /// <remarks>2,3,5,6が同一の結合が複数存在する場合の連番</remarks>
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

        /// <summary>優良部品名称</summary>
        /// <remarks>全角</remarks>
        private string _primePartsName = "";

        /// <summary>優良部品カナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _primePartsKanaName = "";

        /// <summary>層別コード</summary>
        /// <remarks>掛率設定で使用する</remarks>
        private string _partsLayerCd = "";

        /// <summary>優良部品規格・特記事項</summary>
        private string _primePartsSpecialNote = "";

        /// <summary>部品属性</summary>
        /// <remarks>0:純正 や優良、用品などを区別するための属性</remarks>
        private Int32 _partsAttribute;

        /// <summary>カタログ削除フラグ</summary>
        private Int32 _catalogDelteFlag;

        /// <summary>検索品名（全角）</summary>
        private string _searchPartsFullName = "";

        /// <summary>検索品名（半角）</summary>
        private string _searchPartsHalfName = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
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
        /// <value>2,3,5,6が同一の結合が複数存在する場合の連番</value>
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

        /// public propaty name  :  PrimePartsName
        /// <summary>優良部品名称プロパティ</summary>
        /// <value>全角</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaName
        /// <summary>優良部品カナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsKanaName
        {
            get { return _primePartsKanaName; }
            set { _primePartsKanaName = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// <value>掛率設定で使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>優良部品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }

        /// public propaty name  :  PartsAttribute
        /// <summary>部品属性プロパティ</summary>
        /// <value>0:純正 や優良、用品などを区別するための属性</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsAttribute
        {
            get { return _partsAttribute; }
            set { _partsAttribute = value; }
        }

        /// public propaty name  :  CatalogDelteFlag
        /// <summary>カタログ削除フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ削除フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CatalogDelteFlag
        {
            get { return _catalogDelteFlag; }
            set { _catalogDelteFlag = value; }
        }

        /// public propaty name  :  SearchPartsFullName
        /// <summary>検索品名（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsFullName
        {
            get { return _searchPartsFullName; }
            set { _searchPartsFullName = value; }
        }

        /// public propaty name  :  SearchPartsHalfName
        /// <summary>検索品名（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsHalfName
        {
            get { return _searchPartsHalfName; }
            set { _searchPartsHalfName = value; }
        }


        /// <summary>
        /// 提供車輌情報結合検索抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>TBOSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TBOSearchRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TBOSearchRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TBOSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBOSearchRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBOSearchRetWork || graph is ArrayList || graph is TBOSearchRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TBOSearchRetWork).FullName));

            if (graph != null && graph is TBOSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBOSearchRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBOSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBOSearchRetWork[])graph).Length;
            }
            else if (graph is TBOSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
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
            //優良部品名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //優良部品カナ名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaName
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //部品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsAttribute
            //カタログ削除フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDelteFlag
            //検索品名（全角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //検索品名（半角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is TBOSearchRetWork)
            {
                TBOSearchRetWork temp = (TBOSearchRetWork)graph;

                SetTBOSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBOSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBOSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBOSearchRetWork temp in lst)
                {
                    SetTBOSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TBOSearchRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  TBOSearchRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTBOSearchRetWork(System.IO.BinaryWriter writer, TBOSearchRetWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
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
            //優良部品名称
            writer.Write(temp.PrimePartsName);
            //優良部品カナ名称
            writer.Write(temp.PrimePartsKanaName);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //優良部品規格・特記事項
            writer.Write(temp.PrimePartsSpecialNote);
            //部品属性
            writer.Write(temp.PartsAttribute);
            //カタログ削除フラグ
            writer.Write(temp.CatalogDelteFlag);
            //検索品名（全角）
            writer.Write(temp.SearchPartsFullName);
            //検索品名（半角）
            writer.Write(temp.SearchPartsHalfName);

        }

        /// <summary>
        ///  TBOSearchRetWorkインスタンス取得
        /// </summary>
        /// <returns>TBOSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TBOSearchRetWork GetTBOSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TBOSearchRetWork temp = new TBOSearchRetWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
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
            //優良部品名称
            temp.PrimePartsName = reader.ReadString();
            //優良部品カナ名称
            temp.PrimePartsKanaName = reader.ReadString();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //優良部品規格・特記事項
            temp.PrimePartsSpecialNote = reader.ReadString();
            //部品属性
            temp.PartsAttribute = reader.ReadInt32();
            //カタログ削除フラグ
            temp.CatalogDelteFlag = reader.ReadInt32();
            //検索品名（全角）
            temp.SearchPartsFullName = reader.ReadString();
            //検索品名（半角）
            temp.SearchPartsHalfName = reader.ReadString();


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
        /// <returns>TBOSearchRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBOSearchRetWork temp = GetTBOSearchRetWork(reader, serInfo);
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
                    retValue = (TBOSearchRetWork[])lst.ToArray(typeof(TBOSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

