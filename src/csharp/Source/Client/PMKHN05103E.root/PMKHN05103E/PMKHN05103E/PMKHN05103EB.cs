//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換データクラス(倉庫コード、倉庫名称)
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
    /// PM.NS統合ツール　倉庫マスタコード変換画面データクラス(倉庫コード、倉庫名称)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseDispInfo
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

        /// <summary>論理削除フラグプロパティ</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>倉庫コードプロパティ</summary>
        public string WarehouseCode
        {
            get { return this.warehouseCd; }
            set { this.warehouseCd = value; }
        }

        /// <summary>倉庫名称</summary>
        public string WarehouseName
        {
            get { return this.warehouseNm; }
            set { this.warehouseNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　倉庫マスタコード変換画面データクラス(倉庫コード、倉庫名称)コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、倉庫マスタコード変換画面データクラス(倉庫コード、倉庫名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>   
        public WarehouseDispInfo()
        {
            // 処理なし
        }

        /// <summary>
        /// PM.NS統合ツール　倉庫マスタコード変換画面データ転送クラス(倉庫コード、倉庫名称)コンストラクタ
        /// </summary>
        /// <param name="code">倉庫コード</param>
        /// <param name="name">倉庫名称</param>
        /// <param name="logicalDel">論理削除フラグ</param>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、倉庫マスタコード変換画面データ転送クラス(倉庫コード、倉庫名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>   
        public WarehouseDispInfo(string code, string name, int logicalDel)
        {
            this.WarehouseCode = code;
            this.WarehouseName = name;
            this.logicalDelete = logicalDel;
        }

        #endregion
    }
}
