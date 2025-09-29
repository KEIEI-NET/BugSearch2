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
    /// PM.NS統合ツール　WholeCompanyXMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール　WholeCompanyXMLデータ格納クラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/11</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WholeCompanyCvtList
    {
        #region -- Member --
        /// <summary>テーブル名(論理名)</summary>
        private string tableName = String.Empty;
        /// <summary>テーブルID(物理名)</summary>
        private string table = String.Empty;
        /// <summary>番号コード(処理対象番号)</summary>
        private string targetNo = String.Empty;
        /// <summary>カラム名(物理名)</summary>
        private string targetColum = String.Empty;
        /// <summary>カラム名(論理名)</summary>
        private string targetColumName = String.Empty;
        /// <summary>受注ステータスID</summary>
        private string acptStatusId = String.Empty;
        /// <summary>受注ステータスコード</summary>
        private string acptStatus = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>対象テーブル(論理名)プロパティ</summary>
        public string TABLENAME
        {
            get { return this.tableName; }
            set { this.tableName = value; }
        }

        /// <summary>対象テーブル(物理名)プロパティ</summary>
        public string TABLE
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>カラム名(論理名)</summary>
        public string TARGETCOLUMNNAME
        {
            get { return targetColumName; }
            set { targetColumName = value; }
        }

        /// <summary>カラム名(物理名)</summary>
        public string TARGETCOLUM
        {
            get { return targetColum; }
            set { targetColum = value; }
        }

        /// <summary>番号コード(処理対象番号)</summary>
        public string TARGETNO
        {
            get { return targetNo; }
            set { targetNo = value; }
        }

        /// <summary>受注ステータスID</summary>
        public string ACPTSTATUSID
        {
            get { return acptStatusId; }
            set { acptStatusId = value; }
        }

        /// <summary>受注ステータスコード</summary>
        public string ACPTSTATUS
        {
            get { return acptStatus; }
            set { acptStatus = value; }
        }

        #endregion
    }
}
