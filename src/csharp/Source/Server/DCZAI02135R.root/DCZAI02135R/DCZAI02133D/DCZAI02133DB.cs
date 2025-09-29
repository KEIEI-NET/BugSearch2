using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockShipArrivalListWork
    /// <summary>
    ///                      在庫入出荷一覧表リモート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫入出荷一覧表リモート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockShipArrivalListWork 
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

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

        /// <summary>棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>在庫登録日</summary>
        private DateTime _stockCreateDate;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>仕入先コード</summary>
        /// <remarks>在庫発注先コード</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>総出荷数1</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt1;

        /// <summary>総入荷数1</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt1;

        /// <summary>総出荷数2</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt2;

        /// <summary>総入荷数2</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt2;

        /// <summary>総出荷数3</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt3;

        /// <summary>総入荷数3</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt3;

        /// <summary>総出荷数4</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt4;

        /// <summary>総入荷数4</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt4;

        /// <summary>総出荷数5</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt5;

        /// <summary>総入荷数5</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt5;

        /// <summary>総出荷数6</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt6;

        /// <summary>総入荷数6</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt6;

        /// <summary>総出荷数7</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt7;

        /// <summary>総入荷数7</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt7;

        /// <summary>総出荷数8</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt8;

        /// <summary>総入荷数8</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt8;

        /// <summary>総出荷数9</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt9;

        /// <summary>総入荷数9</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt9;

        /// <summary>総出荷数10</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt10;

        /// <summary>総入荷数10</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt10;

        /// <summary>総出荷数11</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt11;

        /// <summary>総入荷数11</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt11;

        /// <summary>総出荷数12</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _shipmentCnt12;

        /// <summary>総入荷数12</summary>
        /// <remarks>在庫履歴データより取得</remarks>
        private Double _arrivalCnt12;

        /// <summary>平均出荷数</summary>
        private Double _aVG_ShipmentCnt;

        /// <summary>平均入荷数</summary>
        private Double _aVG_ArrivalCnt;

        /// <summary>合計出荷数</summary>
        private Double _sUM_ShipmentCnt;

        /// <summary>合計入荷数</summary>
        private Double _sUM_ArrivalCnt;

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類（マスタ有）</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>商品区分</summary>
        private Int32 _enterpriseGanreCode;


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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>在庫登録日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
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

        /// public propaty name  :  StockSupplierCode
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>在庫発注先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  ShipmentCnt1
        /// <summary>総出荷数1プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt1
        {
            get { return _shipmentCnt1; }
            set { _shipmentCnt1 = value; }
        }

        /// public propaty name  :  ArrivalCnt1
        /// <summary>総入荷数1プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt1
        {
            get { return _arrivalCnt1; }
            set { _arrivalCnt1 = value; }
        }

        /// public propaty name  :  ShipmentCnt2
        /// <summary>総出荷数2プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt2
        {
            get { return _shipmentCnt2; }
            set { _shipmentCnt2 = value; }
        }

        /// public propaty name  :  ArrivalCnt2
        /// <summary>総入荷数2プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt2
        {
            get { return _arrivalCnt2; }
            set { _arrivalCnt2 = value; }
        }

        /// public propaty name  :  ShipmentCnt3
        /// <summary>総出荷数3プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt3
        {
            get { return _shipmentCnt3; }
            set { _shipmentCnt3 = value; }
        }

        /// public propaty name  :  ArrivalCnt3
        /// <summary>総入荷数3プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt3
        {
            get { return _arrivalCnt3; }
            set { _arrivalCnt3 = value; }
        }

        /// public propaty name  :  ShipmentCnt4
        /// <summary>総出荷数4プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt4
        {
            get { return _shipmentCnt4; }
            set { _shipmentCnt4 = value; }
        }

        /// public propaty name  :  ArrivalCnt4
        /// <summary>総入荷数4プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt4
        {
            get { return _arrivalCnt4; }
            set { _arrivalCnt4 = value; }
        }

        /// public propaty name  :  ShipmentCnt5
        /// <summary>総出荷数5プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt5
        {
            get { return _shipmentCnt5; }
            set { _shipmentCnt5 = value; }
        }

        /// public propaty name  :  ArrivalCnt5
        /// <summary>総入荷数5プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt5
        {
            get { return _arrivalCnt5; }
            set { _arrivalCnt5 = value; }
        }

        /// public propaty name  :  ShipmentCnt6
        /// <summary>総出荷数6プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt6
        {
            get { return _shipmentCnt6; }
            set { _shipmentCnt6 = value; }
        }

        /// public propaty name  :  ArrivalCnt6
        /// <summary>総入荷数6プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt6
        {
            get { return _arrivalCnt6; }
            set { _arrivalCnt6 = value; }
        }

        /// public propaty name  :  ShipmentCnt7
        /// <summary>総出荷数7プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt7
        {
            get { return _shipmentCnt7; }
            set { _shipmentCnt7 = value; }
        }

        /// public propaty name  :  ArrivalCnt7
        /// <summary>総入荷数7プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt7
        {
            get { return _arrivalCnt7; }
            set { _arrivalCnt7 = value; }
        }

        /// public propaty name  :  ShipmentCnt8
        /// <summary>総出荷数8プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt8
        {
            get { return _shipmentCnt8; }
            set { _shipmentCnt8 = value; }
        }

        /// public propaty name  :  ArrivalCnt8
        /// <summary>総入荷数8プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt8
        {
            get { return _arrivalCnt8; }
            set { _arrivalCnt8 = value; }
        }

        /// public propaty name  :  ShipmentCnt9
        /// <summary>総出荷数9プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt9
        {
            get { return _shipmentCnt9; }
            set { _shipmentCnt9 = value; }
        }

        /// public propaty name  :  ArrivalCnt9
        /// <summary>総入荷数9プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt9
        {
            get { return _arrivalCnt9; }
            set { _arrivalCnt9 = value; }
        }

        /// public propaty name  :  ShipmentCnt10
        /// <summary>総出荷数10プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt10
        {
            get { return _shipmentCnt10; }
            set { _shipmentCnt10 = value; }
        }

        /// public propaty name  :  ArrivalCnt10
        /// <summary>総入荷数10プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt10
        {
            get { return _arrivalCnt10; }
            set { _arrivalCnt10 = value; }
        }

        /// public propaty name  :  ShipmentCnt11
        /// <summary>総出荷数11プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt11
        {
            get { return _shipmentCnt11; }
            set { _shipmentCnt11 = value; }
        }

        /// public propaty name  :  ArrivalCnt11
        /// <summary>総入荷数11プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数11プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt11
        {
            get { return _arrivalCnt11; }
            set { _arrivalCnt11 = value; }
        }

        /// public propaty name  :  ShipmentCnt12
        /// <summary>総出荷数12プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総出荷数12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt12
        {
            get { return _shipmentCnt12; }
            set { _shipmentCnt12 = value; }
        }

        /// public propaty name  :  ArrivalCnt12
        /// <summary>総入荷数12プロパティ</summary>
        /// <value>在庫履歴データより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総入荷数12プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ArrivalCnt12
        {
            get { return _arrivalCnt12; }
            set { _arrivalCnt12 = value; }
        }

        /// public propaty name  :  AVG_ShipmentCnt
        /// <summary>平均出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   平均出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AVG_ShipmentCnt
        {
            get { return _aVG_ShipmentCnt; }
            set { _aVG_ShipmentCnt = value; }
        }

        /// public propaty name  :  AVG_ArrivalCnt
        /// <summary>平均入荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   平均入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AVG_ArrivalCnt
        {
            get { return _aVG_ArrivalCnt; }
            set { _aVG_ArrivalCnt = value; }
        }

        /// public propaty name  :  SUM_ShipmentCnt
        /// <summary>合計出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SUM_ShipmentCnt
        {
            get { return _sUM_ShipmentCnt; }
            set { _sUM_ShipmentCnt = value; }
        }

        /// public propaty name  :  SUM_ArrivalCnt
        /// <summary>合計入荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計入荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SUM_ArrivalCnt
        {
            get { return _sUM_ArrivalCnt; }
            set { _sUM_ArrivalCnt = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類（マスタ有）</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>商品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }


        /// <summary>
        /// 在庫入出荷一覧表リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockShipArrivalListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockShipArrivalListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockShipArrivalListWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockShipArrivalListWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockShipArrivalListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockShipArrivalListWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockShipArrivalListWork || graph is ArrayList || graph is StockShipArrivalListWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockShipArrivalListWork).FullName));

            if (graph != null && graph is StockShipArrivalListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockShipArrivalListWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockShipArrivalListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockShipArrivalListWork[])graph).Length;
            }
            else if (graph is StockShipArrivalListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
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
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //在庫登録日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //総出荷数1
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt1
            //総入荷数1
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt1
            //総出荷数2
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt2
            //総入荷数2
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt2
            //総出荷数3
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt3
            //総入荷数3
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt3
            //総出荷数4
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt4
            //総入荷数4
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt4
            //総出荷数5
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt5
            //総入荷数5
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt5
            //総出荷数6
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt6
            //総入荷数6
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt6
            //総出荷数7
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt7
            //総入荷数7
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt7
            //総出荷数8
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt8
            //総入荷数8
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt8
            //総出荷数9
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt9
            //総入荷数9
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt9
            //総出荷数10
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt10
            //総入荷数10
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt10
            //総出荷数11
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt11
            //総入荷数11
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt11
            //総出荷数12
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt12
            //総入荷数12
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt12
            //平均出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //AVG_ShipmentCnt
            //平均入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //AVG_ArrivalCnt
            //合計出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //SUM_ShipmentCnt
            //合計入荷数
            serInfo.MemberInfo.Add(typeof(Double)); //SUM_ArrivalCnt
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode


            serInfo.Serialize(writer, serInfo);
            if (graph is StockShipArrivalListWork)
            {
                StockShipArrivalListWork temp = (StockShipArrivalListWork)graph;

                SetStockShipArrivalListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockShipArrivalListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockShipArrivalListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockShipArrivalListWork temp in lst)
                {
                    SetStockShipArrivalListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockShipArrivalListWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  StockShipArrivalListWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockShipArrivalListWork(System.IO.BinaryWriter writer, StockShipArrivalListWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
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
            //棚番
            writer.Write(temp.WarehouseShelfNo);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //仕入先コード
            writer.Write(temp.StockSupplierCode);
            //総出荷数1
            writer.Write(temp.ShipmentCnt1);
            //総入荷数1
            writer.Write(temp.ArrivalCnt1);
            //総出荷数2
            writer.Write(temp.ShipmentCnt2);
            //総入荷数2
            writer.Write(temp.ArrivalCnt2);
            //総出荷数3
            writer.Write(temp.ShipmentCnt3);
            //総入荷数3
            writer.Write(temp.ArrivalCnt3);
            //総出荷数4
            writer.Write(temp.ShipmentCnt4);
            //総入荷数4
            writer.Write(temp.ArrivalCnt4);
            //総出荷数5
            writer.Write(temp.ShipmentCnt5);
            //総入荷数5
            writer.Write(temp.ArrivalCnt5);
            //総出荷数6
            writer.Write(temp.ShipmentCnt6);
            //総入荷数6
            writer.Write(temp.ArrivalCnt6);
            //総出荷数7
            writer.Write(temp.ShipmentCnt7);
            //総入荷数7
            writer.Write(temp.ArrivalCnt7);
            //総出荷数8
            writer.Write(temp.ShipmentCnt8);
            //総入荷数8
            writer.Write(temp.ArrivalCnt8);
            //総出荷数9
            writer.Write(temp.ShipmentCnt9);
            //総入荷数9
            writer.Write(temp.ArrivalCnt9);
            //総出荷数10
            writer.Write(temp.ShipmentCnt10);
            //総入荷数10
            writer.Write(temp.ArrivalCnt10);
            //総出荷数11
            writer.Write(temp.ShipmentCnt11);
            //総入荷数11
            writer.Write(temp.ArrivalCnt11);
            //総出荷数12
            writer.Write(temp.ShipmentCnt12);
            //総入荷数12
            writer.Write(temp.ArrivalCnt12);
            //平均出荷数
            writer.Write(temp.AVG_ShipmentCnt);
            //平均入荷数
            writer.Write(temp.AVG_ArrivalCnt);
            //合計出荷数
            writer.Write(temp.SUM_ShipmentCnt);
            //合計入荷数
            writer.Write(temp.SUM_ArrivalCnt);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //商品区分
            writer.Write(temp.EnterpriseGanreCode);

        }

        /// <summary>
        ///  StockShipArrivalListWorkインスタンス取得
        /// </summary>
        /// <returns>StockShipArrivalListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockShipArrivalListWork GetStockShipArrivalListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockShipArrivalListWork temp = new StockShipArrivalListWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
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
            //棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //在庫登録日
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //仕入先コード
            temp.StockSupplierCode = reader.ReadInt32();
            //総出荷数1
            temp.ShipmentCnt1 = reader.ReadDouble();
            //総入荷数1
            temp.ArrivalCnt1 = reader.ReadDouble();
            //総出荷数2
            temp.ShipmentCnt2 = reader.ReadDouble();
            //総入荷数2
            temp.ArrivalCnt2 = reader.ReadDouble();
            //総出荷数3
            temp.ShipmentCnt3 = reader.ReadDouble();
            //総入荷数3
            temp.ArrivalCnt3 = reader.ReadDouble();
            //総出荷数4
            temp.ShipmentCnt4 = reader.ReadDouble();
            //総入荷数4
            temp.ArrivalCnt4 = reader.ReadDouble();
            //総出荷数5
            temp.ShipmentCnt5 = reader.ReadDouble();
            //総入荷数5
            temp.ArrivalCnt5 = reader.ReadDouble();
            //総出荷数6
            temp.ShipmentCnt6 = reader.ReadDouble();
            //総入荷数6
            temp.ArrivalCnt6 = reader.ReadDouble();
            //総出荷数7
            temp.ShipmentCnt7 = reader.ReadDouble();
            //総入荷数7
            temp.ArrivalCnt7 = reader.ReadDouble();
            //総出荷数8
            temp.ShipmentCnt8 = reader.ReadDouble();
            //総入荷数8
            temp.ArrivalCnt8 = reader.ReadDouble();
            //総出荷数9
            temp.ShipmentCnt9 = reader.ReadDouble();
            //総入荷数9
            temp.ArrivalCnt9 = reader.ReadDouble();
            //総出荷数10
            temp.ShipmentCnt10 = reader.ReadDouble();
            //総入荷数10
            temp.ArrivalCnt10 = reader.ReadDouble();
            //総出荷数11
            temp.ShipmentCnt11 = reader.ReadDouble();
            //総入荷数11
            temp.ArrivalCnt11 = reader.ReadDouble();
            //総出荷数12
            temp.ShipmentCnt12 = reader.ReadDouble();
            //総入荷数12
            temp.ArrivalCnt12 = reader.ReadDouble();
            //平均出荷数
            temp.AVG_ShipmentCnt = reader.ReadDouble();
            //平均入荷数
            temp.AVG_ArrivalCnt = reader.ReadDouble();
            //合計出荷数
            temp.SUM_ShipmentCnt = reader.ReadDouble();
            //合計入荷数
            temp.SUM_ArrivalCnt = reader.ReadDouble();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //商品区分
            temp.EnterpriseGanreCode = reader.ReadInt32();


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
        /// <returns>StockShipArrivalListWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockShipArrivalListWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockShipArrivalListWork temp = GetStockShipArrivalListWork(reader, serInfo);
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
                    retValue = (StockShipArrivalListWork[])lst.ToArray(typeof(StockShipArrivalListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
