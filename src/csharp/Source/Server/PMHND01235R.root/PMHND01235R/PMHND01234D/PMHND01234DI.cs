//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫一括削除データ結果対象ワーク
// プログラム概要   : 在庫一括削除データ結果対象ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyDeleteStockRsltWork
    /// <summary>
    ///                      在庫一括削除データ結果対象ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫一括削除データ結果対象ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyDeleteStockRsltWork
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>品番</summary>
        private string _goodsNo = "";


        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
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

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// メーカー品番パターン検索履歴結果ワークコンストラクタ
        /// </summary>
        /// <returns>HandyDeleteStockRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyDeleteStockRsltWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>HandyDeleteStockRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyDeleteStockRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyDeleteStockRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyDeleteStockRsltWork || graph is ArrayList || graph is HandyDeleteStockRsltWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyDeleteStockRsltWork).FullName));

            if (graph != null && graph is HandyDeleteStockRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyDeleteStockRsltWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyDeleteStockRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyDeleteStockRsltWork[])graph).Length;
            }
            else if (graph is HandyDeleteStockRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo

            serInfo.Serialize(writer, serInfo);
            if (graph is HandyDeleteStockRsltWork)
            {
                HandyDeleteStockRsltWork temp = (HandyDeleteStockRsltWork)graph;

                SetHandyDeleteStockRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyDeleteStockRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyDeleteStockRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyDeleteStockRsltWork temp in lst)
                {
                    SetHandyDeleteStockRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyDeleteStockRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  HandyDeleteStockRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyDeleteStockRsltWork(System.IO.BinaryWriter writer, HandyDeleteStockRsltWork temp)
        {
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //品番
            writer.Write(temp.GoodsNo);

        }

        /// <summary>
        ///  HandyDeleteStockRsltWorkインスタンス取得
        /// </summary>
        /// <returns>HandyDeleteStockRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyDeleteStockRsltWork GetHandyDeleteStockRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyDeleteStockRsltWork temp = new HandyDeleteStockRsltWork();

            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //品番
            temp.GoodsNo = reader.ReadString();


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
        /// <returns>HandyDeleteStockRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyDeleteStockRsltWork temp = GetHandyDeleteStockRsltWork(reader, serInfo);
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
                    retValue = (HandyDeleteStockRsltWork[])lst.ToArray(typeof(HandyDeleteStockRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}