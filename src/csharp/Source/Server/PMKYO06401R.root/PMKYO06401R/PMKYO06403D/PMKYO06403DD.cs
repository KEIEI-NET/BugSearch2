using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockProcParamWork
    /// <summary>
    ///                      在庫マスタ抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫マスタ抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockProcParamWork
    {
        /// <summary>開始日時</summary>
        private Int64 _beginningDate;

        /// <summary>終了日時</summary>
        private Int64 _endingDate;

        /// <summary>倉庫(開始)</summary>
        private string _warehouseCodeBegin = "";

        /// <summary>倉庫(終了)</summary>
        private string _warehouseCodeEnd = "";

        /// <summary>棚番(開始)</summary>
        private string _warehouseShelfNoBegin = "";

        /// <summary>棚番(終了)</summary>
        private string _warehouseShelfNoEnd = "";

        /// <summary>仕入先(開始)</summary>
        private Int32 _supplierCdBegin;

        /// <summary>仕入先(終了)</summary>
        private Int32 _supplierCdEnd;

        /// <summary>メーカー(開始)</summary>
        private Int32 _goodsMakerCdBegin;

        /// <summary>メーカー(終了)</summary>
        private Int32 _goodsMakerCdEnd;

        /// <summary>グループコード(開始)</summary>
        private Int32 _bLGloupCodeBegin;

        /// <summary>グループコード(終了)</summary>
        private Int32 _bLGloupCodeEnd;

        /// <summary>品番(開始)</summary>
        private string _goodsNoBegin = "";

        /// <summary>品番(終了)</summary>
        private string _goodsNoEnd = "";


        /// public propaty name  :  BeginningDate
        /// <summary>開始日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>終了日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  WarehouseCodeBegin
        /// <summary>倉庫(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeBeginRF
        {
            get { return _warehouseCodeBegin; }
            set { _warehouseCodeBegin = value; }
        }

        /// public propaty name  :  WarehouseCodeEnd
        /// <summary>倉庫(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEndRF
        {
            get { return _warehouseCodeEnd; }
            set { _warehouseCodeEnd = value; }
        }

        /// public propaty name  :  WarehouseShelfNoBegin
        /// <summary>棚番(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoBeginRF
        {
            get { return _warehouseShelfNoBegin; }
            set { _warehouseShelfNoBegin = value; }
        }

        /// public propaty name  :  WarehouseShelfNoEnd
        /// <summary>棚番(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoEndRF
        {
            get { return _warehouseShelfNoEnd; }
            set { _warehouseShelfNoEnd = value; }
        }

        /// public propaty name  :  SupplierCdBegin
        /// <summary>仕入先(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdBeginRF
        {
            get { return _supplierCdBegin; }
            set { _supplierCdBegin = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>仕入先(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEndRF
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }

        /// public propaty name  :  GoodsMakerCdBegin
        /// <summary>メーカー(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdBeginRF
        {
            get { return _goodsMakerCdBegin; }
            set { _goodsMakerCdBegin = value; }
        }

        /// public propaty name  :  GoodsMakerCdEnd
        /// <summary>メーカー(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEndRF
        {
            get { return _goodsMakerCdEnd; }
            set { _goodsMakerCdEnd = value; }
        }

        /// public propaty name  :  BLGloupCodeBegin
        /// <summary>グループコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGloupCodeBeginRF
        {
            get { return _bLGloupCodeBegin; }
            set { _bLGloupCodeBegin = value; }
        }

        /// public propaty name  :  BLGloupCodeEnd
        /// <summary>グループコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGloupCodeEndRF
        {
            get { return _bLGloupCodeEnd; }
            set { _bLGloupCodeEnd = value; }
        }

        /// public propaty name  :  GoodsNoBegin
        /// <summary>品番(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoBeginRF
        {
            get { return _goodsNoBegin; }
            set { _goodsNoBegin = value; }
        }

        /// public propaty name  :  GoodsNoEnd
        /// <summary>品番(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEndRF
        {
            get { return _goodsNoEnd; }
            set { _goodsNoEnd = value; }
        }


        /// <summary>
        /// 在庫マスタ抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StockProcParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockProcParamWork()
        {
        }

    }
}
