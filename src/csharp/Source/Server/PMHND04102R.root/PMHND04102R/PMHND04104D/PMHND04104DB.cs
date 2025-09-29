//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル在庫情報取得(通常)ワーク
// プログラム概要   : ハンディターミナル在庫情報取得(通常)ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : ハンディターミナル二次開発 在庫仕入（出荷・入荷）の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   HandyStockWork
	/// <summary>
	///                      在庫情報結果クラス（ハンディターミナル）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫情報結果クラス（ハンディターミナル）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/19</br>
	/// <br>Genarated Date   :   2017/06/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   陳艶丹</br>
    /// <br>Date             :   2017/08/02</br>
    /// <br>管理番号         :   11370074-00</br>
    /// <br>                 : ハンディターミナル二次開発の対応</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class HandyStockWork
	{
		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

		/// <summary>出荷可能数</summary>
		/// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
		private Double _shipmentPosCnt;

		/// <summary>最終仕入年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

		/// <summary>最終売上日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>在庫発注先コード</summary>
        private Int32 _stockSupplierCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>仕入先名</summary>
        private string _supplierNm = "";

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
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
			get{return _warehouseName;}
			set{_warehouseName = value;}
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
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
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
			get{return _goodsNo;}
			set{_goodsNo = value;}
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

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>出荷可能数プロパティ</summary>
		/// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷可能数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentPosCnt
		{
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  LastStockDate
		/// <summary>最終仕入年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終仕入年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastStockDate
		{
			get{return _lastStockDate;}
			set{_lastStockDate = value;}
		}

		/// public propaty name  :  LastSalesDate
		/// <summary>最終売上日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終売上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime LastSalesDate
		{
			get{return _lastSalesDate;}
			set{_lastSalesDate = value;}
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
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// public propaty name  :  StockSupplierCode
        /// <summary>在庫発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
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

        /// public propaty name  :  SupplierNm
        /// <summary>仕入先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm
        {
            get { return _supplierNm; }
            set { _supplierNm = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<


		/// <summary>
		/// 在庫情報結果クラス（ハンディターミナル）ワークコンストラクタ
		/// </summary>
		/// <returns>HandyStockWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   HandyStockWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public HandyStockWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>HandyStockWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyStockWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyStockWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyStockWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyStockWork || graph is ArrayList || graph is HandyStockWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyStockWork).FullName));

            if (graph != null && graph is HandyStockWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyStockWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyStockWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyStockWork[])graph).Length;
            }
            else if (graph is HandyStockWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //最終仕入年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastStockDate
            //最終売上日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastSalesDate
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
            //在庫発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //仕入先名
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm
            //UOE発注先名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is HandyStockWork)
            {
                HandyStockWork temp = (HandyStockWork)graph;

                SetHandyStockWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyStockWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyStockWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyStockWork temp in lst)
                {
                    SetHandyStockWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyStockWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  HandyStockWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyStockWork(System.IO.BinaryWriter writer, HandyStockWork temp)
        {
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //最終仕入年月日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //最終売上日
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
            //在庫発注先コード
            writer.Write(temp.StockSupplierCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //仕入先名
            writer.Write(temp.SupplierNm);
            //UOE発注先名称
            writer.Write(temp.UOESupplierName);
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
        }

        /// <summary>
        ///  HandyStockWorkインスタンス取得
        /// </summary>
        /// <returns>HandyStockWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyStockWork GetHandyStockWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyStockWork temp = new HandyStockWork();

            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadDouble();
            //最終仕入年月日
            temp.LastStockDate = new DateTime(reader.ReadInt64());
            //最終売上日
            temp.LastSalesDate = new DateTime(reader.ReadInt64());
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
            //在庫発注先コード
            temp.StockSupplierCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //仕入先名
            temp.SupplierNm = reader.ReadString();
            //UOE発注先名称
            temp.UOESupplierName = reader.ReadString();
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

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
        /// <returns>HandyStockWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyStockWork temp = GetHandyStockWork(reader, serInfo);
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
                    retValue = (HandyStockWork[])lst.ToArray(typeof(HandyStockWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
