//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換データパラメータ(実行)クラス
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
    /// PM.NS統合ツール　倉庫マスタコード変換データパラメータ(実行)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換データパラメータ(実行)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WarehouseConvertPrmWork
    {
        #region -- Member --

        /// <summary>変換前倉庫コード</summary>
        private string bfWarehouseCode = String.Empty;
        /// <summary>変換後倉庫コード</summary>
        private string afWarehouseCode = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// 変更前倉庫コード
        /// </summary>
        public string BfWarehouseCode
        {
            get { return this.bfWarehouseCode; }
            set { this.bfWarehouseCode = value; }
        }

        /// <summary>
        /// 変更後倉庫コード
        /// </summary>
        public string AfWarehouseCode
        {
            get { return this.afWarehouseCode; }
            set { this.afWarehouseCode = value; }
        }

        #endregion
    }
}
