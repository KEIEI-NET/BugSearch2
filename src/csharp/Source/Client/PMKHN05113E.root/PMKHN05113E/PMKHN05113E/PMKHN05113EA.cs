//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換データクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　担当者マスタコード変換画面データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeSearchDispWork
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCd = String.Empty;
        /// <summary>担当者コード(開始)</summary>
        private string employeeCdStart = String.Empty;
        /// <summary>担当者コード(終了)</summary>
        private string employeeCdEnd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCd; }
            set { this.enterpriseCd = value; }
        }

        /// <summary>担当者コード(開始)プロパティ</summary>
        public string EmployeeCodeStart
        {
            get { return this.employeeCdStart; }
            set { this.employeeCdStart = value; }
        }

        /// <summary>担当者コード(終了)プロパティ</summary>
        public string EmployeeCodeEnd
        {
            get { return this.employeeCdEnd; }
            set { this.employeeCdEnd = value; }
        }

        #endregion
    }
}
