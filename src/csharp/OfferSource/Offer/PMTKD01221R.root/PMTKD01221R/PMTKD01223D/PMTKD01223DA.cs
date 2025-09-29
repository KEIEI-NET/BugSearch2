using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SetPartsWork
    /// <summary>
    ///                      セットワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   セットワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/11/22</br>
    /// <br>Genarated Date   :   2009/06/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   β版→PM.NSに変更</br>
    /// <br>Update Note      :   2008/6/11  長内</br>
    /// <br>                 :   キー変更</br>
    /// <br>                 :   5,6,7,8 ⇒ 5,6,7,8,9</br>
    /// <br>Update Note      :   2008/9/2  杉村</br>
    /// <br>                 :   ○NULL許可に変更</br>
    /// <br>                 :   セット名称</br>
    /// <br>                 :   セット規格・特記事項</br>
    /// <br>                 :   カタログ図番</br>
    /// <br>Update Note      :   2008/10/15  杉村</br>
    /// <br>                 :   ○型変更</br>
    /// <br>                 :   結合QTY（Int 3桁　⇒ Double 5桁）</br>
    /// <br>Update Note      :   2008/11/10  杉村</br>
    /// <br>                 :   ○NULL許可変更（すべて不可にする）</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SetPartsWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>翼部品コード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>セット親メーカーコード</summary>
        private Int32 _setMainMakerCd;

        /// <summary>セット親品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _setMainPartsNo = "";

        /// <summary>セット子メーカーコード</summary>
        private Int32 _setSubMakerCd;

        /// <summary>セット子品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _setSubPartsNo = "";

        /// <summary>セット表示順位</summary>
        private Int32 _setDispOrder;

        /// <summary>セットQTY</summary>
        private Double _setQty;

        /// <summary>セット名称</summary>
        private string _setName = "";

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";

        /// <summary>カタログ図番</summary>
        private string _catalogShapeNo = "";


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
        /// <summary>翼部品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>翼部品コード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  SetMainMakerCd
        /// <summary>セット親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetMainMakerCd
        {
            get { return _setMainMakerCd; }
            set { _setMainMakerCd = value; }
        }

        /// public propaty name  :  SetMainPartsNo
        /// <summary>セット親品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット親品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetMainPartsNo
        {
            get { return _setMainPartsNo; }
            set { _setMainPartsNo = value; }
        }

        /// public propaty name  :  SetSubMakerCd
        /// <summary>セット子メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット子メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetSubMakerCd
        {
            get { return _setSubMakerCd; }
            set { _setSubMakerCd = value; }
        }

        /// public propaty name  :  SetSubPartsNo
        /// <summary>セット子品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット子品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSubPartsNo
        {
            get { return _setSubPartsNo; }
            set { _setSubPartsNo = value; }
        }

        /// public propaty name  :  SetDispOrder
        /// <summary>セット表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetDispOrder
        {
            get { return _setDispOrder; }
            set { _setDispOrder = value; }
        }

        /// public propaty name  :  SetQty
        /// <summary>セットQTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セットQTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SetQty
        {
            get { return _setQty; }
            set { _setQty = value; }
        }

        /// public propaty name  :  SetName
        /// <summary>セット名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetName
        {
            get { return _setName; }
            set { _setName = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  CatalogShapeNo
        /// <summary>カタログ図番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ図番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CatalogShapeNo
        {
            get { return _catalogShapeNo; }
            set { _catalogShapeNo = value; }
        }


        /// <summary>
        /// セットワークコンストラクタ
        /// </summary>
        /// <returns>SetPartsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SetPartsWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SetPartsWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SetPartsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SetPartsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SetPartsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SetPartsWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SetPartsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SetPartsWork || graph is ArrayList || graph is SetPartsWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SetPartsWork).FullName));

            if (graph != null && graph is SetPartsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SetPartsWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SetPartsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SetPartsWork[])graph).Length;
            }
            else if (graph is SetPartsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //セット親メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SetMainMakerCd
            //セット親品番
            serInfo.MemberInfo.Add(typeof(string)); //SetMainPartsNo
            //セット子メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SetSubMakerCd
            //セット子品番
            serInfo.MemberInfo.Add(typeof(string)); //SetSubPartsNo
            //セット表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //SetDispOrder
            //セットQTY
            serInfo.MemberInfo.Add(typeof(Double)); //SetQty
            //セット名称
            serInfo.MemberInfo.Add(typeof(string)); //SetName
            //セット規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
            //カタログ図番
            serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo


            serInfo.Serialize(writer, serInfo);
            if (graph is SetPartsWork)
            {
                SetPartsWork temp = (SetPartsWork)graph;

                SetSetPartsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SetPartsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SetPartsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SetPartsWork temp in lst)
                {
                    SetSetPartsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SetPartsWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  SetPartsWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SetPartsWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSetPartsWork(System.IO.BinaryWriter writer, SetPartsWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //セット親メーカーコード
            writer.Write(temp.SetMainMakerCd);
            //セット親品番
            writer.Write(temp.SetMainPartsNo);
            //セット子メーカーコード
            writer.Write(temp.SetSubMakerCd);
            //セット子品番
            writer.Write(temp.SetSubPartsNo);
            //セット表示順位
            writer.Write(temp.SetDispOrder);
            //セットQTY
            writer.Write(temp.SetQty);
            //セット名称
            writer.Write(temp.SetName);
            //セット規格・特記事項
            writer.Write(temp.SetSpecialNote);
            //カタログ図番
            writer.Write(temp.CatalogShapeNo);

        }

        /// <summary>
        ///  SetPartsWorkインスタンス取得
        /// </summary>
        /// <returns>SetPartsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SetPartsWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SetPartsWork GetSetPartsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SetPartsWork temp = new SetPartsWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //セット親メーカーコード
            temp.SetMainMakerCd = reader.ReadInt32();
            //セット親品番
            temp.SetMainPartsNo = reader.ReadString();
            //セット子メーカーコード
            temp.SetSubMakerCd = reader.ReadInt32();
            //セット子品番
            temp.SetSubPartsNo = reader.ReadString();
            //セット表示順位
            temp.SetDispOrder = reader.ReadInt32();
            //セットQTY
            temp.SetQty = reader.ReadDouble();
            //セット名称
            temp.SetName = reader.ReadString();
            //セット規格・特記事項
            temp.SetSpecialNote = reader.ReadString();
            //カタログ図番
            temp.CatalogShapeNo = reader.ReadString();


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
        /// <returns>SetPartsWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SetPartsWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SetPartsWork temp = GetSetPartsWork(reader, serInfo);
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
                    retValue = (SetPartsWork[])lst.ToArray(typeof(SetPartsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
