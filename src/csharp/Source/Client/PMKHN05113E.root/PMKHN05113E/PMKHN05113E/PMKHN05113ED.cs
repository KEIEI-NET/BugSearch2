//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換テーブル情報保存クラス
// プログラム概要   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// 履歴
//----------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　担当者マスタコード変換テーブル情報保存クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換テーブル情報保存クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class TargetTableListResult
    {
        #region -- Member --

        /// <summary>対象テーブル名(物理名)</summary>
        private string targetTable = String.Empty;
        /// <summary>対象テーブル名(論理名)</summary>
        private string targetTableName = String.Empty;
        /// <summary>カラム名(物理名)を格納したリスト</summary>
        private IList<string> columnList = null;

        #endregion

        #region -- Property --

        /// <summary>対象テーブル(物理名)プロパティ</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>対象テーブル(論理名)プロパティ</summary>
        public string TargetTableName
        {
            get { return this.targetTableName; }
            set { this.targetTableName = value; }
        }

        /// <summary>カラム名(物理名)リストプロパティ</summary>
        public IList<string> ColumnList
        {
            get { return this.columnList; }
            set { this.columnList = value; }
        }

        #endregion
    }
}
