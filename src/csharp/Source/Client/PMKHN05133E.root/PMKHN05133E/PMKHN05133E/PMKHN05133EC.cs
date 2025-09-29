//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換コード変更情報保持データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//========================================================================================//
// 履歴
//----------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　拠点コード変換画面変更情報保持データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換画面変更情報保持データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionConvertData
    {
        #region -- Member --

        /// <summary>変換前拠点コード</summary>
        private string bfsectionCd = String.Empty;
        /// <summary>変換後拠点コード</summary>
        private string afsectionCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>変更前拠点コード</summary>
        public string BfSectionCd
        {
            get { return this.bfsectionCd; }
            set { this.bfsectionCd = value; }
        }

        /// <summary>変更後拠点コード</summary>
        public string AfSectionCd
        {
            get { return this.afsectionCd; }
            set { this.afsectionCd = value; }
        }

        #endregion
    }
}
