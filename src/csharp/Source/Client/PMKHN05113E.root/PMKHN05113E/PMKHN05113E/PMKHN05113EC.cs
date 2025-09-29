//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換コード変更情報保持データクラス
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
    /// PM.NS統合ツール　担当者マスタコード変換画面変更情報保持データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換画面変更情報保持データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeConvertData
    {
        #region -- Member --

        /// <summary>変換前担当者コード</summary>
        private string bfEmployeeCd = String.Empty;
        /// <summary>変換後担当者コード</summary>
        private string afEmployeeCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>変更前担当者コード</summary>
        public string BfEmployeeCd
        {
            get { return this.bfEmployeeCd; }
            set { this.bfEmployeeCd = value; }
        }

        /// <summary>変更後担当者コード</summary>
        public string AfEmployeeCd
        {
            get { return this.afEmployeeCd; }
            set { this.afEmployeeCd = value; }
        }

        #endregion
    }
}
