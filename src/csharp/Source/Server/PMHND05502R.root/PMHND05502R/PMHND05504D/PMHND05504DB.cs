//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸データ結果ワーク
// プログラム概要   : ハンディターミナル棚卸データ結果ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInventoryDataWork
    /// <summary>
    /// ハンディターミナル棚卸データ結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル棚卸データ結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/16</br>
    /// <br>Genarated Date   :   2017/08/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInventoryDataWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>棚卸通番</summary>
        private Int32 _circulInventSeqNo;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>在庫総数</summary>
        /// <remarks>帳簿数</remarks>
        private Double _stockTotal;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>棚卸在庫数</summary>
        /// <remarks>棚卸数</remarks>
        private Double _inventoryStockCnt;

        /// <summary>棚卸実施日時</summary>
        private DateTime _inventoryDateTime;

        /// <summary>備考</summary>
        private string _note = "";

        /// <summary>従業員コード</summary>
        /// <remarks>棚卸従業員</remarks>
        private string _employeeCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>オール０は全社</remarks>
        private string _sectionCode = "";

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
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
        /// <value>商品番号</value>
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

        /// public propaty name  :  CirculInventSeqNo
        /// <summary>棚卸通番プロパティ</summary>
        /// <value>棚卸通番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CirculInventSeqNo
        {
            get { return _circulInventSeqNo; }
            set { _circulInventSeqNo = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカー名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>帳簿数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数（実施日）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// <value>倉庫棚番</value>
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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名称</value>
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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>棚卸従業員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  InventoryStockCnt
        /// <summary>棚卸在庫数プロパティ</summary>
        /// <value>棚卸数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _inventoryStockCnt; }
            set { _inventoryStockCnt = value; }
        }

        /// public propaty name  :  Note
        /// <summary>備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        /// public propaty name  :  InventoryDateTime
        /// <summary>棚卸実施日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸実施日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDateTime
        {
            get { return _inventoryDateTime; }
            set { _inventoryDateTime = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>オール０は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// 棚卸データ結果ワークコンストラクタ
        /// </summary>
        /// <returns>HandyInventoryDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyInventoryDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>HandyInventoryDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyInventoryDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyInventoryDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyInventoryDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyInventoryDataWork || graph is ArrayList || graph is HandyInventoryDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyInventoryDataWork).FullName));

            if (graph != null && graph is HandyInventoryDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyInventoryDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyInventoryDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyInventoryDataWork[])graph).Length;
            }
            else if (graph is HandyInventoryDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //棚卸通番
            serInfo.MemberInfo.Add(typeof(Int32)); //CirculInventSeqNo
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //在庫総数（実施日）
            serInfo.MemberInfo.Add(typeof(Double)); //StockTotal
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //棚卸在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryStockCnt
            //棚卸実施日時
            serInfo.MemberInfo.Add(typeof(Int64)); //InventoryDateTime
            //備考
            serInfo.MemberInfo.Add(typeof(string)); //Note
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyInventoryDataWork)
            {
                HandyInventoryDataWork temp = (HandyInventoryDataWork)graph;

                SetHandyInventoryDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyInventoryDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyInventoryDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyInventoryDataWork temp in lst)
                {
                    SetHandyInventoryDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyInventoryDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  HandyInventoryDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyInventoryDataWork(System.IO.BinaryWriter writer, HandyInventoryDataWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //棚卸通番
            writer.Write(temp.CirculInventSeqNo);
            //メーカー名称
            writer.Write(temp.MakerName);
            //在庫総数
            writer.Write(temp.StockTotal);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //棚卸在庫数
            writer.Write(temp.InventoryStockCnt);
            //棚卸実施日時
            writer.Write((Int64)temp.InventoryDateTime.Ticks);
            //備考
            writer.Write(temp.Note);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //拠点コード
            writer.Write(temp.SectionCode);

        }

        /// <summary>
        ///  HandyInventoryDataWorkインスタンス取得
        /// </summary>
        /// <returns>HandyInventoryDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyInventoryDataWork GetHandyInventoryDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyInventoryDataWork temp = new HandyInventoryDataWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //棚卸通番
            temp.CirculInventSeqNo = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //在庫総数
            temp.StockTotal = reader.ReadDouble();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //棚卸在庫数
            temp.InventoryStockCnt = reader.ReadDouble();
            //棚卸実施日時
            temp.InventoryDateTime = new DateTime(reader.ReadInt64());
            //備考
            temp.Note = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();

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
        /// <returns>HandyInventoryDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyInventoryDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyInventoryDataWork temp = GetHandyInventoryDataWork(reader, serInfo);
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
                    retValue = (HandyInventoryDataWork[])lst.ToArray(typeof(HandyInventoryDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
