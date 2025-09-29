//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）データパラメータ 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetResultWork
    /// <summary>
    ///                      表示区分マスタ（印刷）検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   表示区分マスタ（印刷）検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetResultWork
    {
        # region ■ private field

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名</summary>
        private string _customerSnm = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名</summary>
        private string _goodsMakerSnm;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>表示区分</summary>
        private Int32 _priceSelectDiv;

        /// <summary>論理削除区分</summary>
        private Int32 _logicalDeleteCode;

        /// <summary>標準価格選択設定パターン</summary>
        private Int32 _priceSelectPtn;
        # endregion  ■ private field

        # region ■ public propaty
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerSnm
        /// <summary>メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerSnm
        {
            get { return _goodsMakerSnm; }
            set { _goodsMakerSnm = value; }
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  PriceSelectDiv
        /// <summary>表示区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分</summary>
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
        /// <summary>標準価格選択設定パターン</summary>
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
        # endregion ■ public propaty
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PriceSelectSetResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PriceSelectSetResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PriceSelectSetResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceSelectSetResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceSelectSetResultWork || graph is ArrayList || graph is PriceSelectSetResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PriceSelectSetResultWork).FullName));

            if (graph != null && graph is PriceSelectSetResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceSelectSetResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceSelectSetResultWork[])graph).Length;
            }
            else if (graph is PriceSelectSetResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }
            //繰り返し数	
            serInfo.Occurrence = occurrence;

            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64));
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32));
            //得意先名
            serInfo.MemberInfo.Add(typeof(string));
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32));
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32));
            //商品メーカー名
            serInfo.MemberInfo.Add(typeof(string));
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32));
            //BL商品名
            serInfo.MemberInfo.Add(typeof(string));
            //標準価格選択区分
            serInfo.MemberInfo.Add(typeof(Int32));
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32));
            //標準価格選択設定パターン
            serInfo.MemberInfo.Add(typeof(Int32));

            serInfo.Serialize(writer, serInfo);
            if (graph is PriceSelectSetResultWork)
            {
                PriceSelectSetResultWork temp = (PriceSelectSetResultWork)graph;

                SetPriceSelectSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceSelectSetResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceSelectSetResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceSelectSetResultWork temp in lst)
                {
                    SetPriceSelectSetWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// PriceSelectSetResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  PriceSelectSetResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPriceSelectSetWork(System.IO.BinaryWriter writer, PriceSelectSetResultWork temp)
        {

            // 更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);

            // 得意先コード
            writer.Write(temp.CustomerCode);

            // 得意先名
            writer.Write(temp.CustomerSnm);

            // 得意先掛率グループコード
            writer.Write(temp.BLGroupCode);

            // 商品メーカーコード
            writer.Write(temp.GoodsMakerCd);

            // 商品メーカー名
            writer.Write(temp.GoodsMakerSnm);

            // BL商品コード
            writer.Write(temp.BLGoodsCode);

            // BL商品名
            writer.Write(temp.BLGoodsHalfName);

            // 標準価格選択区分
            writer.Write(temp.PriceSelectDiv);

            // 論理削除区分
            writer.Write(temp.LogicalDeleteCode);

            // 標準価格選択設定パターン
            writer.Write(temp.PriceSelectPtn);
        }

        /// <summary>
        ///  PriceSelectSetResultWorkインスタンス取得
        /// </summary>
        /// <returns>PriceSelectSetResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PriceSelectSetResultWork GetPriceSelectSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PriceSelectSetResultWork temp = new PriceSelectSetResultWork();

            // 更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());

            // 得意先コード
            temp.CustomerCode = reader.ReadInt32();

            // 得意先名
            temp.CustomerSnm = reader.ReadString();

            // 得意先掛率グループコード
            temp.BLGroupCode = reader.ReadInt32();

            // 商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();

            // 商品メーカー名
            temp.GoodsMakerSnm = reader.ReadString();

            // BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();

            // BL商品名
            temp.BLGoodsHalfName = reader.ReadString();

            // 標準価格選択区分
            temp.PriceSelectDiv = reader.ReadInt32();

            // 論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();

            // 標準価格選択設定パターン
            temp.PriceSelectPtn = reader.ReadInt32();


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
        /// <returns>PriceSelectSetResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceSelectSetResultWork temp = GetPriceSelectSetWork(reader, serInfo);
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
                    retValue = (PriceSelectSetResultWork[])lst.ToArray(typeof(PriceSelectSetResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
