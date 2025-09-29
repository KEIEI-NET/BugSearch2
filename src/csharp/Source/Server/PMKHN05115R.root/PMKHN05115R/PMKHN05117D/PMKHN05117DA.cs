//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換データパラメータ(検索)クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　担当者マスタコード変換データパラメータ(検索)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換データパラメータ(検索)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class EmployeeSearchParamWork
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>担当者コード(開始)</summary>
        private string employeeCdSt = String.Empty;
        /// <summary>担当者コード(終了)</summary>
        private string employeeCdEd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>担当者コード(開始)プロパティ</summary>
        public string EmployeeCodeStart
        {
            get { return this.employeeCdSt; }
            set { this.employeeCdSt = value; }
        }

        /// <summary>担当者コード(終了)プロパティ</summary>
        public string EmployeeCodeEnd
        {
            get { return this.employeeCdEd; }
            set { this.employeeCdEd = value; }
        }

        #endregion
    }
}
