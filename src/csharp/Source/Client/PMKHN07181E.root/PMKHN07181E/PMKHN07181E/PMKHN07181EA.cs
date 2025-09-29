//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部位マスタ（エクスポート）
// プログラム概要   : 部位マスタ（エクスポート）を行う
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
    /// public class name:   PartsPosCodeExportWork
    /// <summary>
    ///                      部位マスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   部位マスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PartsPosCodeExportWork
    {
        # region ■ private field ■
        /// <summary>開始検索部位コード</summary>
        private Int32 _searchPartsPosCodeSt;

        /// <summary>終了検索部位コード</summary>
        private Int32 _searchPartsPosCodeEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  SearchPartsPosCodeSt
        /// <summary>開始検索部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsPosCodeSt
        {
            get { return _searchPartsPosCodeSt; }
            set { _searchPartsPosCodeSt = value; }
        }

        /// public propaty name  :  SearchPartsPosCodeEd
        /// <summary>終了検索部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsPosCodeEd
        {
            get { return _searchPartsPosCodeEd; }
            set { _searchPartsPosCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
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
        /// 部位マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsPosCodeExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsPosCodeExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
