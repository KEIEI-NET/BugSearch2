//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換XMLデータ格納クラス
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
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換XMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換XMLデータ格納クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertList
    {
        #region -- Member --

        /// <summary>対象テーブル(物理名)</summary>
        private string targetTable;
        /// <summary>対象テーブル(論理名)</summary>
        private string targetTableName;
        /// <summary>対象カラム(物理名)</summary>
        private string targetColumn;
        /// <summary>対象カラム(論理名)</summary>
        private string targetColumnName;

        #endregion

        #region -- Property --

        /// <summary>
        /// 対象テーブル(物理名)プロパティ
        /// </summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>
        /// 対象テーブル(論理名)プロパティ
        /// </summary>
        public string TargetTableName
        {
            get { return this.targetTableName; }
            set { this.targetTableName = value; }
        }

        /// <summary>
        /// 対象カラム(物理名)プロパティ
        /// </summary>
        public string TargetColumn
        {
            get { return this.targetColumn; }
            set { this.targetColumn = value; }
        }

        /// <summary>
        /// 対象カラム(論理名)プロパティ
        /// </summary>
        public string TargetColumnName
        {
            get { return this.targetColumnName; }
            set { this.targetColumnName = value; }
        }

        #endregion
    }
}
