//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換データパラメータ(実行)クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換データパラメータ(実行)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換データパラメータ(実行)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class CustomerConvertParamInfoList
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>コード変換対象テーブル</summary>
        private string targetTable = String.Empty;
        /// <summary>コード変換対象カラムのリスト</summary>
        private IList<string> columnList = null;
        /// <summary>コード変換対象データのリスト</summary>
        private IList<CustomerConvertParamWork> cstmrCnvPrmWrkList = null;

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>コード変換対象テーブルプロパティ</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>コード変換対象カラムリストプロパティ</summary>
        public IList<string> ColumnList
        {
            get { return this.columnList; }
            set { this.columnList = value; }
        }

        /// <summary>コード変換対象データリストプロパティ</summary>
        public IList<CustomerConvertParamWork> CustomerConvertParamWorkList
        {
            get { return this.cstmrCnvPrmWrkList; }
            set { this.cstmrCnvPrmWrkList = value; }
        }

        #endregion
    }
}
