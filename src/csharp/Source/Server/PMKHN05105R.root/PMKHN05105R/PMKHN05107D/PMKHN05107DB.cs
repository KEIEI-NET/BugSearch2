//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換データパラメータ(検索)クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換データパラメータ(検索)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換データパラメータ(検索)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WarehouseSearchWork
    {
        #region -- Member --

        /// <summary>論理削除フラグ</summary>
        private int logicalDelete = 0;

        /// <summary>倉庫コード</summary>
        private string warehouseCd = String.Empty;

        /// <summary>倉庫名称</summary>
        private string warehouseNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// 論理削除フラグプロパティ
        /// </summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>
        /// 倉庫コード(開始)プロパティ
        /// </summary>
        public string WarehouseCd
        {
            get { return this.warehouseCd; }
            set { this.warehouseCd = value; }
        }

        /// <summary>
        /// 倉庫名称プロパティ
        /// </summary>
        public string WarehouseNm
        {
            get { return this.warehouseNm; }
            set { this.warehouseNm = value; }
        }

        #endregion
    }
}
