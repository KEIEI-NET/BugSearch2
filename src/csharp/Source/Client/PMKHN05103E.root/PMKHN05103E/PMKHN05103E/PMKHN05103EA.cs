//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換画面データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertDispInfo
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>倉庫コード(開始)</summary>
        private string warehouseCdStart = String.Empty;
        /// <summary>倉庫コード(終了)</summary>
        private string warehouseCdEnd = String.Empty;        

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>倉庫コード(開始)プロパティ</summary>
        public string WarehouseCdStart
        {
            get { return this.warehouseCdStart; }
            set { this.warehouseCdStart = value; }
        }

        /// <summary>倉庫コード(終了)プロパティ</summary>
        public string WarehouseCdEnd
        {
            get { return this.warehouseCdEnd; }
            set { this.warehouseCdEnd = value; }
        }

        #endregion
    }
}
