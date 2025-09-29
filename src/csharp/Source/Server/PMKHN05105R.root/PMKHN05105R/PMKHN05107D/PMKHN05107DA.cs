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
    public class WarehouseSearchParamWork
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterPriseCode = String.Empty;

        /// <summary>倉庫コード(開始)</summary>
        private string warehouseStCd = String.Empty;

        /// <summary>倉庫コード(終了)</summary>
        private string warehouseEdCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// 企業コードプロパティ
        /// </summary>
        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }

        /// <summary>
        /// 倉庫コード(開始)プロパティ
        /// </summary>
        public string WarehouseStCd
        {
            get { return this.warehouseStCd; }
            set { this.warehouseStCd = value; }
        }

        /// <summary>
        /// 倉庫コード(終了)プロパティ
        /// </summary>
        public string WarehouseEdCd
        {
            get { return this.warehouseEdCd; }
            set { this.warehouseEdCd = value; }
        }

        #endregion
    }
}
