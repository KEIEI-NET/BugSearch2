//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員マスタ（エクスポート）
// プログラム概要   : 従業員マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EmployeeExportWork
    /// <summary>
    ///                      従業員マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class EmployeeExportWork
    {
        # region ■ private field ■
        /// <summary>開始拠点コード</summary>
        private string _sectionCdSt = "";

        /// <summary>終了拠点コード</summary>
        private string _sectionCdEd = "";

        /// <summary>開始担当者コード</summary>
        private string _employeeCdSt = "";

        /// <summary>終了担当者コード</summary>
        private string _employeeCdEd = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        # endregion  ■ private field ■
        # region ■ public propaty ■
        /// public propaty name  :  SectionCdSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCdSt
        {
            get { return _sectionCdSt; }
            set { _sectionCdSt = value; }
        }

        /// public propaty name  :  SectionCdEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCdEd
        {
            get { return _sectionCdEd; }
            set { _sectionCdEd = value; }
        }

        /// public propaty name  :  EmployeeCdSt
        /// <summary>開始担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCdSt
        {
            get { return _employeeCdSt; }
            set { _employeeCdSt = value; }
        }

        /// public propaty name  :  EmployeeCdEd
        /// <summary>終了担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCdEd
        {
            get { return _employeeCdEd; }
            set { _employeeCdEd = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        # endregion ■ public propaty ■
        # region ■ Constructor ■
        /// <summary>
        /// 従業員マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EmployeeExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
