//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充の検品情報取得条件ワーク
// プログラム概要   : ハンディターミナル委託在庫補充の検品情報取得条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 脇田　靖之
// 修 正 日  2017/12/14  修正内容 :ハンディターミナル三次対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConsStockRepInspectParamWork
    /// <summary>
    ///                      委託在庫補充の検品情報取得条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充の検品情報取得条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>委託倉庫コード</summary>
        private string _consignWarehouseCode = "";

        /// <summary>出荷日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDay;

        // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
        /// <summary>主管倉庫コード</summary>
        private string _mainMngWarehouseCode = "";
        // --- ADD 2017/12/14 Y.Wakita ----------<<<<<

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

        /// public propaty name  :  MachineName
        /// <summary>コンピュータ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
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

        /// public propaty name  :  ConsignWarehouseCode
        /// <summary>委託倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ConsignWarehouseCode
        {
            get { return _consignWarehouseCode; }
            set { _consignWarehouseCode = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>出荷日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
        /// public propaty name  :  MainMngWarehouseCode
        /// <summary>主管倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainMngWarehouseCode
        {
            get { return _mainMngWarehouseCode; }
            set { _mainMngWarehouseCode = value; }
        }
        // --- ADD 2017/12/14 Y.Wakita ----------<<<<

        /// <summary>
        /// 委託在庫補充の検品情報取得条件ワークコンストラクタ
        /// </summary>
        /// <returns>ConsStockRepInspectParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConsStockRepInspectParamWork()
        {
        }

    }
}
