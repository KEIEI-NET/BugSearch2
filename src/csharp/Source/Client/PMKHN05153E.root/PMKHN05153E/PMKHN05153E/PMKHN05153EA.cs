//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　伝票番号変換データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　伝票番号変換データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの伝票番号変換画面データクラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/12</br>
    /// </remarks>
    public class SlipNOConvertDispInfo
    {
        #region -- Member --

        /// <summary>番号コード(処理対象番号)</summary>
        private int noCode = 0;
        /// <summary>番号コード名称(処理対象番号)</summary>
        private string noCodeName = String.Empty;
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
        
        /// <summary>番号コード名称(処理対象番号)</summary>
        public string NoCodeName
        {
            get { return noCodeName; }
            set { noCodeName = value; }
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
