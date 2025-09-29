using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockCheckWork
    /// <summary>
    ///                      在庫チェックワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫チェックワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2012/06/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  杉村</br>
    /// <br>                 :   出荷可能数の補足修正</br>
    /// <br>Update Note      :   2012/07/03 zhangy3 </br>
    /// <br>                 :   10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockCheckWork 
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>商品メーカーコード</summary>
        private string _goodsMakerCd = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>仕入単価（税抜,浮動）</summary>
        private string _stockUnitPriceFl = "";

        /// <summary>仕入在庫数</summary>
        private string _supplierStock = "";

        /// <summary>入荷数（未計上）</summary>
        private string _arrivalCnt = "";

        /// <summary>出荷数（未計上）</summary>
        private string _shipmentCnt = "";

        /// <summary>受注数</summary>
        private string _acpOdrCount = "";

        /// <summary>移動中仕入在庫数</summary>
        private string _movingSupliStock = "";

        /// <summary>出荷可能数</summary>
        private string _shipmentPosCnt = "";

        /// <summary>発注数</summary>
        private string _salesOrderCount;

        /// <summary>在庫区分</summary>
        private string _stockDiv = "";

        /// <summary>最低在庫数</summary>
        private string _minimumStockCnt;

        /// <summary>最高在庫数</summary>
        private string _maximumStockCnt;

        /// <summary>発注単位</summary>
        private string _salesOrderUnit = "";

        /// <summary>在庫発注先コード</summary>
        private string _stockSupplierCode = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>重複棚番１</summary>
        private string _duplicationShelfNo1 = "";

        /// <summary>重複棚番２</summary>
        private string _duplicationShelfNo2 = "";

        /// <summary>部品管理区分１</summary>
        private string _partsManagementDivide1 = "";

        /// <summary>部品管理区分２</summary>
        private string _partsManagementDivide2 = "";

        /// <summary>仕入備考1</summary>
        /// <remarks>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</remarks>
        private string _stockNote1 = "";

        /// <summary>仕入備考2</summary>
        private string _stockNote2 = "";

        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// <summary>エラーメッセージ</summary>
        private string _errMessage = "";
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<

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
        public string GoodsMakerCd
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierStock
        /// <summary>仕入在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>入荷数（未計上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数（未計上）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数（未計上）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>受注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>移動中仕入在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動中仕入在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  MinimumStockCnt
        /// <summary>最低在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最低在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MinimumStockCnt
        {
            get { return _minimumStockCnt; }
            set { _minimumStockCnt = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>最高在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  SalesOrderUnit
        /// <summary>発注単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderUnit
        {
            get { return _salesOrderUnit; }
            set { _salesOrderUnit = value; }
        }

        /// public propaty name  :  StockSupplierCode
        /// <summary>在庫発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
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

        /// public propaty name  :  DuplicationShelfNo1
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DuplicationShelfNo1
        {
            get { return _duplicationShelfNo1; }
            set { _duplicationShelfNo1 = value; }
        }

        /// public propaty name  :  DuplicationShelfNo2
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DuplicationShelfNo2
        {
            get { return _duplicationShelfNo2; }
            set { _duplicationShelfNo2 = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  StockNote1
        /// <summary>仕入備考1プロパティ</summary>
        /// <value>※何の仕入かわかる内容を設定する　例）車両仕入であれば車種名　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockNote1
        {
            get { return _stockNote1; }
            set { _stockNote1 = value; }
        }

        /// public propaty name  :  StockNote2
        /// <summary>仕入備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockNote2
        {
            get { return _stockNote2; }
            set { _stockNote2 = value; }
        }


        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// public propaty name  :  ERRMESSAGE
        /// <summary>エラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージプロパティ</br>
        /// <br>Programer        :   zhangy3</br>
        /// </remarks>
        public string ERRMESSAGE
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<
        /// <summary>
        /// 在庫チェックワークコンストラクタ
        /// </summary>
        /// <returns>StockCheckWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCheckWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockCheckWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockCheckWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockCheckWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/07/03 zhangy3 </br>
        /// <br>                 :   10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockCheckWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockCheckWork || graph is ArrayList || graph is StockCheckWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockCheckWork).FullName));

            if (graph != null && graph is StockCheckWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockCheckWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockCheckWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockCheckWork[])graph).Length;
            }
            else if (graph is StockCheckWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add(typeof(string)); //StockUnitPriceFl
            //仕入在庫数
            serInfo.MemberInfo.Add(typeof(string)); //SupplierStock
            //入荷数（未計上）
            serInfo.MemberInfo.Add(typeof(string)); //ArrivalCnt
            //出荷数（未計上）
            serInfo.MemberInfo.Add(typeof(string)); //ShipmentCnt
            //受注数
            serInfo.MemberInfo.Add(typeof(string)); //AcpOdrCount
            //移動中仕入在庫数
            serInfo.MemberInfo.Add(typeof(string)); //MovingSupliStock
            //出荷可能数
            serInfo.MemberInfo.Add(typeof(string)); //ShipmentPosCnt
            //発注数
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderCount
            //在庫区分
            serInfo.MemberInfo.Add(typeof(string)); //StockDiv
            //最低在庫数
            serInfo.MemberInfo.Add(typeof(string)); //MinimumStockCnt
            //最高在庫数
            serInfo.MemberInfo.Add(typeof(string)); //MaximumStockCnt
            //発注単位
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderUnit
            //在庫発注先コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSupplierCode
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //重複棚番１
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo1
            //重複棚番２
            serInfo.MemberInfo.Add(typeof(string)); //DuplicationShelfNo2
            //部品管理区分１
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide1
            //部品管理区分２
            serInfo.MemberInfo.Add(typeof(string)); //PartsManagementDivide2
            //仕入備考1
            serInfo.MemberInfo.Add(typeof(string)); //StockNote1
            //仕入備考2
            serInfo.MemberInfo.Add(typeof(string)); //StockNote2
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
            //エラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErrMessage
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockCheckWork)
            {
                StockCheckWork temp = (StockCheckWork)graph;

                SetStockCheckWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockCheckWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockCheckWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockCheckWork temp in lst)
                {
                    SetStockCheckWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockCheckWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 24;//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        private const int currentMemberCount = 25;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387

        /// <summary>
        ///  StockCheckWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/07/03 zhangy3 </br>
        /// <br>                 :   10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        private void SetStockCheckWork(System.IO.BinaryWriter writer, StockCheckWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入在庫数
            writer.Write(temp.SupplierStock);
            //入荷数（未計上）
            writer.Write(temp.ArrivalCnt);
            //出荷数（未計上）
            writer.Write(temp.ShipmentCnt);
            //受注数
            writer.Write(temp.AcpOdrCount);
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //在庫区分
            writer.Write(temp.StockDiv);
            //最低在庫数
            writer.Write(temp.MinimumStockCnt);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //発注単位
            writer.Write(temp.SalesOrderUnit);
            //在庫発注先コード
            writer.Write(temp.StockSupplierCode);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.DuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.DuplicationShelfNo2);
            //部品管理区分１
            writer.Write(temp.PartsManagementDivide1);
            //部品管理区分２
            writer.Write(temp.PartsManagementDivide2);
            //仕入備考1
            writer.Write(temp.StockNote1);
            //仕入備考2
            writer.Write(temp.StockNote2);
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
            //エラーメッセージ
            writer.Write(temp.ERRMESSAGE);
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<

        }

        /// <summary>
        ///  StockCheckWorkインスタンス取得
        /// </summary>
        /// <returns>StockCheckWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/07/03 zhangy3 </br>
        /// <br>                 :   10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        private StockCheckWork GetStockCheckWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockCheckWork temp = new StockCheckWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //仕入単価（税抜,浮動）
            temp.StockUnitPriceFl = reader.ReadString();
            //仕入在庫数
            temp.SupplierStock = reader.ReadString();
            //入荷数（未計上）
            temp.ArrivalCnt = reader.ReadString();
            //出荷数（未計上）
            temp.ShipmentCnt = reader.ReadString();
            //受注数
            temp.AcpOdrCount = reader.ReadString();
            //移動中仕入在庫数
            temp.MovingSupliStock = reader.ReadString();
            //出荷可能数
            temp.ShipmentPosCnt = reader.ReadString();
            //発注数
            temp.SalesOrderCount = reader.ReadString();
            //在庫区分
            temp.StockDiv = reader.ReadString();
            //最低在庫数
            temp.MinimumStockCnt = reader.ReadString();
            //最高在庫数
            temp.MaximumStockCnt = reader.ReadString();
            //発注単位
            temp.SalesOrderUnit = reader.ReadString();
            //在庫発注先コード
            temp.StockSupplierCode = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //重複棚番１
            temp.DuplicationShelfNo1 = reader.ReadString();
            //重複棚番２
            temp.DuplicationShelfNo2 = reader.ReadString();
            //部品管理区分１
            temp.PartsManagementDivide1 = reader.ReadString();
            //部品管理区分２
            temp.PartsManagementDivide2 = reader.ReadString();
            //仕入備考1
            temp.StockNote1 = reader.ReadString();
            //仕入備考2
            temp.StockNote2 = reader.ReadString();
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
            //エラーメッセージ
            temp.ERRMESSAGE = reader.ReadString();
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<


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
        /// <returns>StockCheckWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockCheckWork temp = GetStockCheckWork(reader, serInfo);
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
                    retValue = (StockCheckWork[])lst.ToArray(typeof(StockCheckWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
