//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 棚卸マスタ（エクスポート）
// プログラム概要   : 棚卸マスタ（エクスポート）を行う
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
    /// public class name:   InventoryExportWork
    /// <summary>
    ///                      棚卸マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryExportWork
    {
        # region ■ private field ■
        /// <summary>開始棚卸通番コード</summary>
        private int _inventorySeqNoSt;

        /// <summary>終了棚卸通番コード</summary>
        private int _inventorySeqNoEd;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        # endregion  ■ private field ■

        # region ■ public propaty ■

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  InventorySeqNoSt
        /// <summary>開始棚卸通番コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始棚卸通番コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventorySeqNoSt
        {
            get { return _inventorySeqNoSt; }
            set { _inventorySeqNoSt = value; }
        }

        /// public propaty name  :  InventorySeqNoEd
        /// <summary>終了棚卸通番コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了棚卸通番コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventorySeqNoEd
        {
            get { return _inventorySeqNoEd; }
            set { _inventorySeqNoEd = value; }
        }


        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 棚卸マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>InventoryExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventoryExportWork()
        {
        }
        # endregion ■ Constructor ■

    }
}
