//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換データクラス(担当者コード、担当者名称)
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
    /// PM.NS統合ツール　担当者マスタコード変換画面データクラス(担当者コード、担当者名称)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeDispInfo
    {
        #region -- Member --

        /// <summary>論理削除フラグ</summary>
        private int logicalDelete = 0;
        /// <summary>担当者コード</summary>
        private string employeeCd = String.Empty;
        /// <summary>担当者名</summary>
        private string employeeNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>論理削除フラグプロパティ</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>担当者コードプロパティ</summary>
        public string EmployeeCode
        {
            get { return this.employeeCd; }
            set { this.employeeCd = value; }
        }

        /// <summary>担当者名プロパティ</summary>
        public string EmployeeName
        {
            get { return this.employeeNm; }
            set { this.employeeNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　担当者マスタコード変換画面データクラス(担当者コード、担当者名称)コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、担当者マスタコード変換画面データクラス(担当者コード、担当者名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks> 
        public EmployeeDispInfo()
        {
            // 処理なし
        }

        /// <summary>
        /// PM.NS統合ツール　担当者マスタコード変換画面データ転送クラス(担当者コード、担当者名称)コンストラクタ
        /// </summary>
        /// <param name="code">担当者コード</param>
        /// <param name="name">担当者名称</param>
        /// <param name="logicalDel">論理削除フラグ</param>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、担当者マスタコード変換画面データ転送クラス(担当者コード、担当者名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>  
        public EmployeeDispInfo(string code, string name, int logicalDel)
        {
            this.EmployeeCode = code;
            this.EmployeeName = name;
            this.LogicalDelete = logicalDel;
        }

        #endregion
    }
}
