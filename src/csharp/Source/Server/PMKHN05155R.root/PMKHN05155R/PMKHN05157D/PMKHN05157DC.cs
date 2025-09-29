//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　伝票番号変換XMLデータ格納クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/11  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　伝票番号変換XMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS伝票番号変換処理ツールの伝票番号変換XMLデータ格納クラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/11</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class SlpNoTargetTableList
    {
        #region -- Member --

        /// <summary>番号コード(処理対象番号)</summary>
        private int targetNo = 0;
        /// <summary>テーブルID(物理名)</summary>
        private string targetTable = String.Empty;
        /// <summary>テーブル名(論理名)</summary>
        private string targetTableName = String.Empty;
        /// <summary>カラム名(物理名)</summary>
        private string targetColum = String.Empty;
        /// <summary>カラム名(論理名)</summary>
        private string targetColumName = String.Empty;
        /// <summary>受注ステータスID</summary>
        private string targetAcptStatusId = String.Empty;
        /// <summary>受注ステータスコード</summary>
        private int targetAcptStatus = 0;

        #endregion

        #region -- Property --

        /// <summary>番号コード(処理対象番号)</summary>
        public int TargetNo
        {
            get { return targetNo; }
            set { targetNo = value; }
        }

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

        /// <summary>カラム名(物理名)</summary>
        public string TargetColum
        {
            get { return targetColum; }
            set { targetColum = value; }
        }

        /// <summary>カラム名(論理名)</summary>
        public string TargetColumName
        {
            get { return targetColumName; }
            set { targetColumName = value; }
        }

        /// <summary>受注ステータスID</summary>
        public string TargetAcptStatusId
        {
            get { return targetAcptStatusId; }
            set { targetAcptStatusId = value; }
        }

        /// <summary>受注ステータスコード</summary>
        public int TargetAcptStatus
        {
            get { return targetAcptStatus; }
            set { targetAcptStatus = value; }
        }

        #endregion
    }
}
