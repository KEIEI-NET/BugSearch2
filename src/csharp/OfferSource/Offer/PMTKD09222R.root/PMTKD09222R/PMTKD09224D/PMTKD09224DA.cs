using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PtMkrPriceWork
    /// <summary>
    ///                      部品価格ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品価格ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/5/6</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/4/6  水野　剛史</br>
    /// <br>                 :   共通ファイルヘッダ変更（項目削除）</br>
    /// <br>                 :   ・企業コード</br>
    /// <br>                 :   ・GUID</br>
    /// <br>                 :   ・更新従業員コード</br>
    /// <br>                 :   ・更新アセンブリID1</br>
    /// <br>                 :   ・更新アセンブリID2</br>
    /// <br>Update Note      :   2006/12/27  岩本　勇</br>
    /// <br>                 :   ・部品情報制御フラグ</br>
    /// <br>                 :   追加</br>
    /// <br>Update Note      :   2008/7/3  杉村</br>
    /// <br>                 :   追加：部品価格開始日</br>
    /// <br>                 :   オープン価格区分</br>
    /// <br>                 :   価格区分？</br>
    /// <br>Update Note      :   2008/7/7  杉村</br>
    /// <br>                 :   追加：メーカー提供部品カナ名称</br>
    /// <br>                 :   新ヘッダーへ移行</br>
    /// <br>Update Note      :   2008/7/9  杉村</br>
    /// <br>                 :   ・部品情報制御フラグ削除</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PtMkrPriceWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>部品価格改定区分</summary>
        /// <remarks>0:改定日1,1:改定日2,2:改定日3　※PM.NSは０固定</remarks>
        private Int32 _partsPriceRevCd;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>ハイフン付最新部品品番</summary>
        private string _newPrtsNoWithHyphen = "";

        /// <summary>ハイフン無最新部品品番</summary>
        private string _newPrtsNoNoneHyphen = "";

        /// <summary>部品価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _partsPriceStDate;

        /// <summary>翼部品コード</summary>
        /// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>メーカー提供部品名称</summary>
        private string _makerOfferPartsName = "";

        /// <summary>メーカー提供部品カナ名称</summary>
        private string _makerOfferPartsKana = "";

        /// <summary>部品価格</summary>
        private Int64 _partsPrice;

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;


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

        /// public propaty name  :  PartsPriceRevCd
        /// <summary>部品価格改定区分プロパティ</summary>
        /// <value>0:改定日1,1:改定日2,2:改定日3　※PM.NSは０固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格改定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPriceRevCd
        {
            get { return _partsPriceRevCd; }
            set { _partsPriceRevCd = value; }
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

        /// public propaty name  :  NewPrtsNoWithHyphen
        /// <summary>ハイフン付最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrtsNoWithHyphen
        {
            get { return _newPrtsNoWithHyphen; }
            set { _newPrtsNoWithHyphen = value; }
        }

        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>ハイフン無最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }

        /// public propaty name  :  PartsPriceStDate
        /// <summary>部品価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
        /// <value>1～99999:提供分,100000～ユーザー登録用</value>
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

        /// public propaty name  :  MakerOfferPartsName
        /// <summary>メーカー提供部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー提供部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>メーカー提供部品カナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー提供部品カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  PartsPrice
        /// <summary>部品価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
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

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }


        /// <summary>
        /// 部品価格ワークコンストラクタ
        /// </summary>
        /// <returns>PtMkrPriceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PtMkrPriceWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PtMkrPriceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PtMkrPriceWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PtMkrPriceWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PtMkrPriceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PtMkrPriceWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PtMkrPriceWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PtMkrPriceWork || graph is ArrayList || graph is PtMkrPriceWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PtMkrPriceWork).FullName));

            if (graph != null && graph is PtMkrPriceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PtMkrPriceWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PtMkrPriceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PtMkrPriceWork[])graph).Length;
            }
            else if (graph is PtMkrPriceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //部品価格改定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPriceRevCd
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //ハイフン付最新部品品番
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoWithHyphen
            //ハイフン無最新部品品番
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoNoneHyphen
            //部品価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPriceStDate
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //メーカー提供部品名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsName
            //メーカー提供部品カナ名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsKana
            //部品価格
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPrice
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PtMkrPriceWork)
            {
                PtMkrPriceWork temp = (PtMkrPriceWork)graph;

                SetPtMkrPriceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PtMkrPriceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PtMkrPriceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PtMkrPriceWork temp in lst)
                {
                    SetPtMkrPriceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PtMkrPriceWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  PtMkrPriceWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PtMkrPriceWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPtMkrPriceWork(System.IO.BinaryWriter writer, PtMkrPriceWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //部品価格改定区分
            writer.Write(temp.PartsPriceRevCd);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //ハイフン付最新部品品番
            writer.Write(temp.NewPrtsNoWithHyphen);
            //ハイフン無最新部品品番
            writer.Write(temp.NewPrtsNoNoneHyphen);
            //部品価格開始日
            writer.Write(temp.PartsPriceStDate);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //メーカー提供部品名称
            writer.Write(temp.MakerOfferPartsName);
            //メーカー提供部品カナ名称
            writer.Write(temp.MakerOfferPartsKana);
            //部品価格
            writer.Write(temp.PartsPrice);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);

        }

        /// <summary>
        ///  PtMkrPriceWorkインスタンス取得
        /// </summary>
        /// <returns>PtMkrPriceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PtMkrPriceWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PtMkrPriceWork GetPtMkrPriceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PtMkrPriceWork temp = new PtMkrPriceWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //部品価格改定区分
            temp.PartsPriceRevCd = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //ハイフン付最新部品品番
            temp.NewPrtsNoWithHyphen = reader.ReadString();
            //ハイフン無最新部品品番
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            //部品価格開始日
            temp.PartsPriceStDate = reader.ReadInt32();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //メーカー提供部品名称
            temp.MakerOfferPartsName = reader.ReadString();
            //メーカー提供部品カナ名称
            temp.MakerOfferPartsKana = reader.ReadString();
            //部品価格
            temp.PartsPrice = reader.ReadInt64();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();


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
        /// <returns>PtMkrPriceWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PtMkrPriceWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PtMkrPriceWork temp = GetPtMkrPriceWork(reader, serInfo);
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
                    retValue = (PtMkrPriceWork[])lst.ToArray(typeof(PtMkrPriceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
