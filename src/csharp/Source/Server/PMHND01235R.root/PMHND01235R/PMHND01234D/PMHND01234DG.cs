//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディ在庫情報
// プログラム概要   : ハンディ在庫情報です
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyStockInsStockInfo
    /// <summary>
    ///                      ハンディ在庫情報
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディ在庫情報ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyStockInsStockInfo
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>出荷可能数</summary>
        private double _shipmentPosCnt;


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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// <summary>
        /// ハンディ在庫情報ワークコンストラクタ
        /// </summary>
        /// <returns>HandyStockInsStockInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockInsStockInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyStockInsStockInfo()
        {
        }

    }
}
