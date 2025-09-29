//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換情報保持データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//========================================================================================//
// 履歴
//----------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール 伝票番号変換保持データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール 伝票番号変換情報保持データクラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/10</br>
    /// </remarks>
    public class SlpNoConvertData
    {
        #region -- Member --

        /// <summary>番号コード(処理対象番号)</summary>
        private int noCode = 0;

        /// <summary>テーブルID(物理名)</summary>
        private string table = String.Empty;

        /// <summary>テーブル名(論理名)</summary>
        private string tableName = String.Empty;
        
        /// <summary>カラム名(物理名)</summary>
        private string colum = String.Empty;
        
        /// <summary>カラム名(論理名)</summary>
        private string columName = String.Empty;
        
        /// <summary>受注ステータスID</summary>
        private string acptStatusId = String.Empty;
        /// <summary>受注ステータスコード</summary>
        private int acptStatus = 0;

        /// <summary>番号現在値</summary>
        private Int64 noPresentVal = 0;

        /// <summary>設定開始番号</summary>
        private Int64 settingStartNo = 0;
       
        /// <summary>設定終了番号</summary>
        private Int64 settingEndNo = 0;
        
        /// <summary>番号増減値</summary>
        private Int64 noIncDecWidth = 0;
        
        

        #endregion

        #region -- Property --

        /// <summary>番号コード(処理対象番号)</summary>
        public int NoCode
        {
            get { return noCode; }
            set { noCode = value; }
        }

        /// <summary>テーブルID(物理名)</summary>
        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        /// <summary>テーブル名(論理名)</summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>受注ステータスコード</summary>
        public int AcptStatus
        {
            get { return acptStatus; }
            set { acptStatus = value; }
        }

        /// <summary>カラム名(物理名)</summary>
        public string Colum
        {
            get { return colum; }
            set { colum = value; }
        }

        /// <summary>カラム名(論理名)</summary>
        public string ColumName
        {
            get { return columName; }
            set { columName = value; }
        }

        
        /// <summary>受注ステータスID</summary>
        public string AcptStatusId
        {
            get { return acptStatusId; }
            set { acptStatusId = value; }
        }

        /// <summary>番号現在値</summary>
        public Int64 NoPresentVal
        {
            get { return noPresentVal; }
            set { noPresentVal = value; }
        }

        /// <summary>設定開始番号</summary>
        public Int64 SettingStartNo
        {
            get { return settingStartNo; }
            set { settingStartNo = value; }
        }


        /// <summary>設定終了番号</summary>
        public Int64 SettingEndNo
        {
            get { return settingEndNo; }
            set { settingEndNo = value; }
        }

        /// <summary>番号増減値</summary>
        public Int64 NoIncDecWidth
        {
            get { return noIncDecWidth; }
            set { noIncDecWidth = value; }
        }
        #endregion
    }
}
