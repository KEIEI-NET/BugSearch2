//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタメンテ抽出結果ワーク
// プログラム概要   : リコメンド商品関連設定マスタメンテ抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015.01.16  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecGoodsLkOWork
    /// <summary>
    ///                      レコメンド商品関連設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   レコメンド商品関連設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/1/9</br>
    /// <br>Genarated Date   :   2015/01/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecGoodsLkOWork
    {
        /// <summary>提供日付</summary>
        private Int32 _offerDate;

        /// <summary>推奨元BL商品コード</summary>
        private Int32 _recSourceBLGoodsCd;

        /// <summary>推奨先BL商品コード</summary>
        private Int32 _recDestBLGoodsCd;

        /// <summary>商品コメント</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _goodsComment = "";


        /// public propaty name  :  OfferDate
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  RecSourceBLGoodsCd
        /// <summary>推奨元BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨元BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCd
        {
            get { return _recSourceBLGoodsCd; }
            set { _recSourceBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsCd
        /// <summary>推奨先BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨先BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecDestBLGoodsCd
        {
            get { return _recDestBLGoodsCd; }
            set { _recDestBLGoodsCd = value; }
        }

        /// public propaty name  :  GoodsComment
        /// <summary>商品コメントプロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コメントプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
        }

        /// <summary>
        /// レコメンド商品関連設定ワークコンストラクタ
        /// </summary>
        /// <returns>RecGoodsLkOWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkOWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecGoodsLkOWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecGoodsLkOWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecGoodsLkOWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecGoodsLkOWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkOWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecGoodsLkOWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecGoodsLkOWork || graph is ArrayList || graph is RecGoodsLkOWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecGoodsLkOWork).FullName));

            if (graph != null && graph is RecGoodsLkOWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecGoodsLkOWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecGoodsLkOWork[])graph).Length;
            }
            else if (graph is RecGoodsLkOWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //推奨元BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RecSourceBLGoodsCd
            //推奨先BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //RecDestBLGoodsCd
            //商品コメント
            serInfo.MemberInfo.Add(typeof(string)); //GoodsComment


            serInfo.Serialize(writer, serInfo);
            if (graph is RecGoodsLkOWork)
            {
                RecGoodsLkOWork temp = (RecGoodsLkOWork)graph;

                SetRecGoodsLkOWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecGoodsLkOWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecGoodsLkOWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecGoodsLkOWork temp in lst)
                {
                    SetRecGoodsLkOWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecGoodsLkOWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  RecGoodsLkOWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkOWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecGoodsLkOWork(System.IO.BinaryWriter writer, RecGoodsLkOWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //推奨元BL商品コード
            writer.Write(temp.RecSourceBLGoodsCd);
            //推奨先BL商品コード
            writer.Write(temp.RecDestBLGoodsCd);
            //商品コメント
            writer.Write(temp.GoodsComment);

        }

        /// <summary>
        ///  RecGoodsLkOWorkインスタンス取得
        /// </summary>
        /// <returns>RecGoodsLkOWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkOWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecGoodsLkOWork GetRecGoodsLkOWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecGoodsLkOWork temp = new RecGoodsLkOWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //推奨元BL商品コード
            temp.RecSourceBLGoodsCd = reader.ReadInt32();
            //推奨先BL商品コード
            temp.RecDestBLGoodsCd = reader.ReadInt32();
            //商品コメント
            temp.GoodsComment = reader.ReadString();


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
        /// <returns>RecGoodsLkOWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecGoodsLkOWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecGoodsLkOWork temp = GetRecGoodsLkOWork(reader, serInfo);
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
                    retValue = (RecGoodsLkOWork[])lst.ToArray(typeof(RecGoodsLkOWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
