//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換画面データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerSearchDispWork
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCd = String.Empty;
        /// <summary>得意先コード(開始)</summary>
        private int customerCdStart = 0;
        /// <summary>得意先コード(終了)</summary>
        private int customerCdEnd = 0;

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCd; }
            set { this.enterpriseCd = value; }
        }

        /// <summary>得意先コード(開始)プロパティ</summary>
        public int CustomerCodeStart
        {
            get { return this.customerCdStart; }
            set { this.customerCdStart = value; }
        }

        /// <summary>得意先コード(終了)プロパティ</summary>
        public int CustomerCodeEnd
        {
            get { return this.customerCdEnd; }
            set { this.customerCdEnd = value; }
        }

        #endregion
    }
}
