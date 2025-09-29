//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充の検品情報取得結果ワーク
// プログラム概要   : ハンディターミナル委託在庫補充の検品情報取得結果ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConsStockRepInspectRetWork
    /// <summary>
    ///                      委託在庫補充の検品情報取得結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充の検品情報取得結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectRetWork
    {
        /// <summary>在庫調整伝票番号</summary>
        private Int32 _stockAdjustSlipNo;

        /// <summary>在庫調整行番号</summary>
        private Int32 _stockAdjustRowNo;

        /// <summary>調整日付</summary>
        private Int32 _adjustDate;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>調整数</summary>
        /// <remarks>変更前と変更後の仕入在庫数の差を登録する。</remarks>
        private Double _adjustCount;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>商品バーコード</summary>
        private string _goodsBarCode = "";

        /// <summary>検品ステータス</summary>
        /// <remarks>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</remarks>
        private Int32 _inspectStatus;

        /// <summary>検品区分</summary>
        /// <remarks>1:通常 2:手動検品 </remarks>
        private Int32 _inspectCode;

        /// <summary>検品数</summary>
        private Double _inspectCnt;


        /// public propaty name  :  StockAdjustSlipNo
        /// <summary>在庫調整伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustSlipNo
        {
            get { return _stockAdjustSlipNo; }
            set { _stockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAdjustRowNo
        /// <summary>在庫調整行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustRowNo
        {
            get { return _stockAdjustRowNo; }
            set { _stockAdjustRowNo = value; }
        }

        /// public propaty name  :  AdjustDate
        /// <summary>調整日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AdjustDate
        {
            get { return _adjustDate; }
            set { _adjustDate = value; }
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
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
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

        /// public propaty name  :  AdjustCount
        /// <summary>調整数プロパティ</summary>
        /// <value>変更前と変更後の仕入在庫数の差を登録する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

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

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>商品バーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  InspectStatus
        /// <summary>検品ステータスプロパティ</summary>
        /// <value>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InspectStatus
        {
            get { return _inspectStatus; }
            set { _inspectStatus = value; }
        }

        /// public propaty name  :  InspectCode
        /// <summary>検品区分プロパティ</summary>
        /// <value>1:通常 2:手動検品 </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InspectCode
        {
            get { return _inspectCode; }
            set { _inspectCode = value; }
        }

        /// public propaty name  :  InspectCnt
        /// <summary>検品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InspectCnt
        {
            get { return _inspectCnt; }
            set { _inspectCnt = value; }
        }


        /// <summary>
        /// 委託在庫補充の検品情報取得結果ワークコンストラクタ
        /// </summary>
        /// <returns>ConsStockRepInspectRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConsStockRepInspectRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>ConsStockRepInspectRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ConsStockRepInspectRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepInspectRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepInspectRetWork || graph is ArrayList || graph is ConsStockRepInspectRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ConsStockRepInspectRetWork).FullName));

            if (graph != null && graph is ConsStockRepInspectRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepInspectRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepInspectRetWork[])graph).Length;
            }
            else if (graph is ConsStockRepInspectRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //在庫調整伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustSlipNo
            //在庫調整行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustRowNo
            //調整日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AdjustDate
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //商品バーコード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsBarCode
            //検品ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //検品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //検品数
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepInspectRetWork)
            {
                ConsStockRepInspectRetWork temp = (ConsStockRepInspectRetWork)graph;

                SetConsStockRepInspectRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepInspectRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepInspectRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepInspectRetWork temp in lst)
                {
                    SetConsStockRepInspectRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepInspectRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  ConsStockRepInspectRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetConsStockRepInspectRetWork(System.IO.BinaryWriter writer, ConsStockRepInspectRetWork temp)
        {
            //在庫調整伝票番号
            writer.Write(temp.StockAdjustSlipNo);
            //在庫調整行番号
            writer.Write(temp.StockAdjustRowNo);
            //調整日付
            writer.Write(temp.AdjustDate);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //調整数
            writer.Write(temp.AdjustCount);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //商品バーコード
            writer.Write(temp.GoodsBarCode);
            //検品ステータス
            writer.Write(temp.InspectStatus);
            //検品区分
            writer.Write(temp.InspectCode);
            //検品数
            writer.Write(temp.InspectCnt);

        }

        /// <summary>
        ///  ConsStockRepInspectRetWorkインスタンス取得
        /// </summary>
        /// <returns>ConsStockRepInspectRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ConsStockRepInspectRetWork GetConsStockRepInspectRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ConsStockRepInspectRetWork temp = new ConsStockRepInspectRetWork();

            //在庫調整伝票番号
            temp.StockAdjustSlipNo = reader.ReadInt32();
            //在庫調整行番号
            temp.StockAdjustRowNo = reader.ReadInt32();
            //調整日付
            temp.AdjustDate = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //調整数
            temp.AdjustCount = reader.ReadDouble();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //商品バーコード
            temp.GoodsBarCode = reader.ReadString();
            //検品ステータス
            temp.InspectStatus = reader.ReadInt32();
            //検品区分
            temp.InspectCode = reader.ReadInt32();
            //検品数
            temp.InspectCnt = reader.ReadDouble();


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
        /// <returns>ConsStockRepInspectRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepInspectRetWork temp = GetConsStockRepInspectRetWork(reader, serInfo);
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
                    retValue = (ConsStockRepInspectRetWork[])lst.ToArray(typeof(ConsStockRepInspectRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
