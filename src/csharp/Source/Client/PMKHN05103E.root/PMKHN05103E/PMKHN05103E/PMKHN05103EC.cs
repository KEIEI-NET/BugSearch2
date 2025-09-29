//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換コード変更情報保持データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// 履歴
//----------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換画面変更情報保持データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換画面変更情報保持データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertData
    {
        #region -- Member --

        /// <summary>変換前倉庫コード</summary>
        private string bfwarehouseCd = String.Empty;
        /// <summary>変換後倉庫コード</summary>
        private string afwarehouseCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>変更前倉庫コード</summary>
        public string BfWarehouseCd
        {
            get { return this.bfwarehouseCd; }
            set { this.bfwarehouseCd = value; }
        }

        /// <summary>変更後倉庫コード</summary>
        public string AfWarehouseCd
        {
            get { return this.afwarehouseCd; }
            set { this.afwarehouseCd = value; }
        }

        #endregion
    }
}
