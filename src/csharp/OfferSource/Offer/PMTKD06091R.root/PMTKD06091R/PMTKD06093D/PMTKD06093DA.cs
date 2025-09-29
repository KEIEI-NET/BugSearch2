using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfrPartsRetWork
    /// <summary>
    ///                      部品情報クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品情報クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfrPartsRetWork
    {
        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>ハイフン付最新部品品番</summary>
        private string _partsNoWithHyphen = "";

        /// <summary>ハイフン無最新部品品番</summary>
        private string _partsNoNoneHyphen = "";

        /// <summary>部品名称</summary>
        private string _partsName = "";

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        /// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>優良部品規格・特記事項</summary>
        /// <remarks>[優良専用]</remarks>
        private string _primePartsSpecialNote = "";

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>部品区分</summary>
        /// <remarks>0:純正、1:優良、2:用品</remarks>
        private Int32 _partsCode;


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

        /// public propaty name  :  PartsNoWithHyphen
        /// <summary>ハイフン付最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsNoWithHyphen
        {
            get { return _partsNoWithHyphen; }
            set { _partsNoWithHyphen = value; }
        }

        /// public propaty name  :  PartsNoNoneHyphen
        /// <summary>ハイフン無最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsNoNoneHyphen
        {
            get { return _partsNoNoneHyphen; }
            set { _partsNoNoneHyphen = value; }
        }

        /// public propaty name  :  PartsName
        /// <summary>部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
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
        /// <value>1～99999:提供分,100000～ユーザー登録用</value>
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

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
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
        /// <value>[優良専用]</value>
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

        /// public propaty name  :  PartsCode
        /// <summary>部品区分プロパティ</summary>
        /// <value>0:純正、1:優良、2:用品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }


        /// <summary>
        /// 部品情報クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfrPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPartsRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfrPartsRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OfrPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfrPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfrPartsRetWork || graph is ArrayList || graph is OfrPartsRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfrPartsRetWork).FullName));

            if (graph != null && graph is OfrPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfrPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfrPartsRetWork[])graph).Length;
            }
            else if (graph is OfrPartsRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //ハイフン付最新部品品番
            serInfo.MemberInfo.Add(typeof(string)); //PartsNoWithHyphen
            //ハイフン無最新部品品番
            serInfo.MemberInfo.Add(typeof(string)); //PartsNoNoneHyphen
            //部品名称
            serInfo.MemberInfo.Add(typeof(string)); //PartsName
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //部品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is OfrPartsRetWork)
            {
                OfrPartsRetWork temp = (OfrPartsRetWork)graph;

                SetOfrPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfrPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfrPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfrPartsRetWork temp in lst)
                {
                    SetOfrPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfrPartsRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  OfrPartsRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPartsRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfrPartsRetWork(System.IO.BinaryWriter writer, OfrPartsRetWork temp)
        {
            //メーカーコード
            writer.Write(temp.MakerCode);
            //ハイフン付最新部品品番
            writer.Write(temp.PartsNoWithHyphen);
            //ハイフン無最新部品品番
            writer.Write(temp.PartsNoNoneHyphen);
            //部品名称
            writer.Write(temp.PartsName);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //優良部品規格・特記事項
            writer.Write(temp.PrimePartsSpecialNote);
            //提供日付
            writer.Write(temp.OfferDate);
            //部品区分
            writer.Write(temp.PartsCode);

        }

        /// <summary>
        ///  OfrPartsRetWorkインスタンス取得
        /// </summary>
        /// <returns>OfrPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPartsRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfrPartsRetWork GetOfrPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfrPartsRetWork temp = new OfrPartsRetWork();

            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //ハイフン付最新部品品番
            temp.PartsNoWithHyphen = reader.ReadString();
            //ハイフン無最新部品品番
            temp.PartsNoNoneHyphen = reader.ReadString();
            //部品名称
            temp.PartsName = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //優良部品規格・特記事項
            temp.PrimePartsSpecialNote = reader.ReadString();
            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //部品区分
            temp.PartsCode = reader.ReadInt32();


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
        /// <returns>OfrPartsRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfrPartsRetWork temp = GetOfrPartsRetWork(reader, serInfo);
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
                    retValue = (OfrPartsRetWork[])lst.ToArray(typeof(OfrPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

/*
namespace Broadleaf.Application.Remoting.ParamData
{
	# region public class OfrPartsRetWork
	/// public class name:   OfrPartsRetWork
	/// <summary>
	///                      ユーザー商品抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザー商品抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OfrPartsRetWork
	{
		/// <summary>メーカーコード</summary>
		private Int32 _makerCd;

		/// <summary>商品品番（ハイフン付き）</summary>
		private string _goodsNoWithHyp = "";

		/// <summary>商品品番（ハイフン無し）</summary>
		private string _goodsNoNoneHyp = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>中分類コード</summary>
		private Int32 _middleGenreCode;

		/// <summary>BLコード</summary>
		private Int32 _tbsPartsCode;

		/// <summary>定価</summary>
		private Int64 _listPrice;

		/// <summary>層別コード</summary>
		private string _goodsLayerCd = "";

		/// <summary>商品規格・特記事項</summary>
		/// <remarks>日付が入っていれば提供</remarks>
		private string _goodsSpecialNote = "";

		/// <summary>データ提供日付</summary>
		private Int32 _offerDate;

		/// <summary>新定価</summary>
		private Int64 _newListPrice;

		/// <summary>新定価適用日付</summary>
		private Int32 _newListPriceApplyDate;

		/// <summary>部品区分</summary>
		/// <remarks>0:純正、1:優良、2:用品</remarks>
		private Int32 _partsCode;

		/// <summary>商品区分 </summary>
		private Int32 _goodsCode;

		/// <summary>税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationCode;

		/// <summary>商品備考1</summary>
		private string _goodsNote1 = "";

		/// <summary>商品備考2</summary>
		private string _goodsNote2 = "";


		/// public propaty name  :  MakerCd
		/// <summary>メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCd
		{
			get { return _makerCd; }
			set { _makerCd = value; }
		}

		/// public propaty name  :  GoodsNoWithHyp
		/// <summary>商品品番（ハイフン付き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品品番（ハイフン付き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoWithHyp
		{
			get { return _goodsNoWithHyp; }
			set { _goodsNoWithHyp = value; }
		}

		/// public propaty name  :  GoodsNoNoneHyp
		/// <summary>商品品番（ハイフン無し）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品品番（ハイフン無し）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoNoneHyp
		{
			get { return _goodsNoNoneHyp; }
			set { _goodsNoNoneHyp = value; }
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get { return _goodsName; }
			set { _goodsName = value; }
		}

		/// public propaty name  :  MiddleGenreCode
		/// <summary>中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MiddleGenreCode
		{
			get { return _middleGenreCode; }
			set { _middleGenreCode = value; }
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

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get { return _listPrice; }
			set { _listPrice = value; }
		}

		/// public propaty name  :  GoodsLayerCd
		/// <summary>層別コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   層別コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsLayerCd
		{
			get { return _goodsLayerCd; }
			set { _goodsLayerCd = value; }
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>商品規格・特記事項プロパティ</summary>
		/// <value>日付が入っていれば提供</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get { return _goodsSpecialNote; }
			set { _goodsSpecialNote = value; }
		}

		/// public propaty name  :  OfferDate
		/// <summary>データ提供日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   データ提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDate
		{
			get { return _offerDate; }
			set { _offerDate = value; }
		}

		/// public propaty name  :  NewListPrice
		/// <summary>新定価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   新定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 NewListPrice
		{
			get { return _newListPrice; }
			set { _newListPrice = value; }
		}

		/// public propaty name  :  NewListPriceApplyDate
		/// <summary>新定価適用日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   新定価適用日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NewListPriceApplyDate
		{
			get { return _newListPriceApplyDate; }
			set { _newListPriceApplyDate = value; }
		}

		/// public propaty name  :  PartsCode
		/// <summary>部品区分プロパティ</summary>
		/// <value>0:純正、1:優良、2:用品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsCode
		{
			get { return _partsCode; }
			set { _partsCode = value; }
		}

		/// public propaty name  :  GoodsCode
		/// <summary>商品区分 プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分 プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsCode
		{
			get { return _goodsCode; }
			set { _goodsCode = value; }
		}

		/// public propaty name  :  TaxationCode
		/// <summary>税区分プロパティ</summary>
		/// <value>0:課税,1:非課税,2:課税（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationCode
		{
			get { return _taxationCode; }
			set { _taxationCode = value; }
		}

		/// public propaty name  :  GoodsNote1
		/// <summary>商品備考1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote1
		{
			get { return _goodsNote1; }
			set { _goodsNote1 = value; }
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>商品備考2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote2
		{
			get { return _goodsNote2; }
			set { _goodsNote2 = value; }
		}


		/// <summary>
		/// ユーザー商品抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>OfrPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrPartsRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OfrPartsRetWork()
		{
		}

	}
	# endregion

	# region public class OfrPartsRetWork_SerializationSurrogate_For_V51010
	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>OfrPartsRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class OfrPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  OfrPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is OfrPartsRetWork || graph is ArrayList || graph is OfrPartsRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfrPartsRetWork).FullName));

			if (graph != null && graph is OfrPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is OfrPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((OfrPartsRetWork[])graph).Length;
			}
			else if (graph is OfrPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCd
			//商品品番（ハイフン付き）
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNoWithHyp
			//商品品番（ハイフン無し）
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyp
			//商品名称
			serInfo.MemberInfo.Add(typeof(string)); //GoodsName
			//中分類コード
			serInfo.MemberInfo.Add(typeof(Int32)); //MiddleGenreCode
			//BLコード
			serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
			//定価
			serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
			//層別コード
			serInfo.MemberInfo.Add(typeof(string)); //GoodsLayerCd
			//商品規格・特記事項
			serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
			//データ提供日付
			serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
			//新定価
			serInfo.MemberInfo.Add(typeof(Int64)); //NewListPrice
			//新定価適用日付
			serInfo.MemberInfo.Add(typeof(Int32)); //NewListPriceApplyDate
			//部品区分
			serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode
			//商品区分 
			serInfo.MemberInfo.Add(typeof(Int32)); //GoodsCode
			//税区分
			serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
			//商品備考1
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
			//商品備考2
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2


			serInfo.Serialize(writer, serInfo);
			if (graph is OfrPartsRetWork)
			{
				OfrPartsRetWork temp = (OfrPartsRetWork)graph;

				SetOfrPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is OfrPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((OfrPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (OfrPartsRetWork temp in lst)
				{
					SetOfrPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// OfrPartsRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 17;

		/// <summary>
		///  OfrPartsRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrPartsRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetOfrPartsRetWork(System.IO.BinaryWriter writer, OfrPartsRetWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCd);
			//商品品番（ハイフン付き）
			writer.Write(temp.GoodsNoWithHyp);
			//商品品番（ハイフン無し）
			writer.Write(temp.GoodsNoNoneHyp);
			//商品名称
			writer.Write(temp.GoodsName);
			//中分類コード
			writer.Write(temp.MiddleGenreCode);
			//BLコード
			writer.Write(temp.TbsPartsCode);
			//定価
			writer.Write(temp.ListPrice);
			//層別コード
			writer.Write(temp.GoodsLayerCd);
			//商品規格・特記事項
			writer.Write(temp.GoodsSpecialNote);
			//データ提供日付
			writer.Write(temp.OfferDate);
			//新定価
			writer.Write(temp.NewListPrice);
			//新定価適用日付
			writer.Write(temp.NewListPriceApplyDate);
			//部品区分
			writer.Write(temp.PartsCode);
			//商品区分 
			writer.Write(temp.GoodsCode);
			//税区分
			writer.Write(temp.TaxationCode);
			//商品備考1
			writer.Write(temp.GoodsNote1);
			//商品備考2
			writer.Write(temp.GoodsNote2);

		}

		/// <summary>
		///  OfrPartsRetWorkインスタンス取得
		/// </summary>
		/// <returns>OfrPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrPartsRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private OfrPartsRetWork GetOfrPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			OfrPartsRetWork temp = new OfrPartsRetWork();

			//メーカーコード
			temp.MakerCd = reader.ReadInt32();
			//商品品番（ハイフン付き）
			temp.GoodsNoWithHyp = reader.ReadString();
			//商品品番（ハイフン無し）
			temp.GoodsNoNoneHyp = reader.ReadString();
			//商品名称
			temp.GoodsName = reader.ReadString();
			//中分類コード
			temp.MiddleGenreCode = reader.ReadInt32();
			//BLコード
			temp.TbsPartsCode = reader.ReadInt32();
			//定価
			temp.ListPrice = reader.ReadInt64();
			//層別コード
			temp.GoodsLayerCd = reader.ReadString();
			//商品規格・特記事項
			temp.GoodsSpecialNote = reader.ReadString();
			//データ提供日付
			temp.OfferDate = reader.ReadInt32();
			//新定価
			temp.NewListPrice = reader.ReadInt64();
			//新定価適用日付
			temp.NewListPriceApplyDate = reader.ReadInt32();
			//部品区分
			temp.PartsCode = reader.ReadInt32();
			//商品区分 
			temp.GoodsCode = reader.ReadInt32();
			//税区分
			temp.TaxationCode = reader.ReadInt32();
			//商品備考1
			temp.GoodsNote1 = reader.ReadString();
			//商品備考2
			temp.GoodsNote2 = reader.ReadString();


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
		/// <returns>OfrPartsRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OfrPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				OfrPartsRetWork temp = GetOfrPartsRetWork(reader, serInfo);
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
					retValue = (OfrPartsRetWork[])lst.ToArray(typeof(OfrPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
	# endregion
}
*/