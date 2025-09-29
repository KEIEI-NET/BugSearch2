//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 倉庫マスタ（エクスポート）
// プログラム概要   : 倉庫マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   WarehouseExportWork
    /// <summary>
    ///                      倉庫マスタ（エクスポート）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   倉庫マスタ（エクスポート）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class WarehouseExportWork
    {
        # region ■ private field ■
        /// <summary>開始倉庫コード</summary>
        private string _warehouseCdSt = "";

        /// <summary>終了倉庫コード</summary>
        private string _warehouseCdEd = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  WarehouseCdSt
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCdSt
        {
            get { return _warehouseCdSt; }
            set { _warehouseCdSt = value; }
        }

        /// public propaty name  :  WarehouseCdEd
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCdEd
        {
            get { return _warehouseCdEd; }
            set { _warehouseCdEd = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
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

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 倉庫マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>WarehouseExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   WarehouseExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public WarehouseExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
