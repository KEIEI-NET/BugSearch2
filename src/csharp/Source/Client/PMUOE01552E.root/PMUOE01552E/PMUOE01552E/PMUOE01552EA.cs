//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 注文一覧更新処理
// プログラム概要   : ホンダe-Partsシステムより「ご注文一覧CSV」を取り込み、
//                    回答情報を更新します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESupplierInfo
    /// <summary>
    ///                      注文一覧データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   注文一覧データクラスヘッダファイル</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2009/06/01</br>
    /// <br>Update Note      : 　2009/06/25 李占川</br>
    /// <br>                   　PVCS#273について、アイテムを追加します。</br>
    /// </remarks>
    public class UOESupplierInfo
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        /// <summary>UOE発注先コード</summary>
        private int _uOESupplierCd;

        /// <summary>回答保存フォルダ</summary>
        private string _answerSaveFolder;

        // --- ADD 2009/06/25 ------------------------------->>>>>
        /// <summary>アイテム</summary>
        private string _uOEItemCd;
        // --- ADD 2009/06/25 ------------------------------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コード</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コード</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public int UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>回答保存フォルダ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答保存フォルダ</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        // --- ADD 2009/06/25 ------------------------------->>>>>
        /// public propaty name  :  UOEItemCd
        /// <summary>アイテム</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   アイテム</br>
        /// <br>Programer        :   李占川</br>
        /// </remarks>
        public string UOEItemCd
        {
            get { return _uOEItemCd; }
            set { _uOEItemCd = value; }
        }
        // --- ADD 2009/06/25 ------------------------------<<<<<
    }
}
