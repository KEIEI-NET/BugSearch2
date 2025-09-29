//****************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換コード変更情報保持データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// 履歴
//----------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換画面変更情報保持データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換画面変更情報保持データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerConvertData
    {
        #region -- Member --

        /// <summary>変換前得意先コード</summary>
        private int bfCustomerCd = 0;
        /// <summary>変換後得意先コード</summary>
        private int afCustomerCd = 0;

        #endregion

        #region -- Property --

        /// <summary>変更前得意先コード</summary>
        public int BfCustomerCd
        {
            get { return this.bfCustomerCd; }
            set { this.bfCustomerCd = value; }
        }

        /// <summary>変更後得意先コード</summary>
        public int AfCustomerCd
        {
            get { return this.afCustomerCd; }
            set { this.afCustomerCd = value; }
        }

        #endregion
    }
}
