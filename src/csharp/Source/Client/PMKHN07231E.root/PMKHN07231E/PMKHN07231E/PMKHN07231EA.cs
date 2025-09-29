//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点情報マスタ（エクスポート）
// プログラム概要   : 拠点情報マスタ（エクスポート）を行う
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
    /// public class name:   SecExportSetWork
    /// <summary>
    ///                      拠点情報マスタ（エクスポート）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点情報マスタ（エクスポート）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SecExportSetWork
    {
        # region ■ private field ■
        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  SectionCodeSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
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
        /// 拠点情報マスタ（エクスポート）データクラスワークコンストラクタ
		/// </summary>
        /// <returns>SecExportSetWorkクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SecExportSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SecExportSetWork()
		{
		}
        # endregion ■ Constructor ■
    }
}
