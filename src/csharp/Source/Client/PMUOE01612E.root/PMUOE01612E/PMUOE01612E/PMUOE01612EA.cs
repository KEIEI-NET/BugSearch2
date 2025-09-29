//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 李占川
// 作 成 日  2010/01/04  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
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
    /// public class name:   ToyotaAnswerDatePara
    /// <summary>
    ///                      トヨタ回答データ取込処理条件抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   トヨタ回答データ取込処理条件抽出クラスヘッダファイル</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2010/01/04</br>
    /// </remarks>
    public class ToyotaAnswerDatePara
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        /// <summary>UOE発注先コード</summary>
        private int _uOESupplierCd;

        /// <summary>回答保存フォルダ</summary>
        private string _answerSaveFolder;

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
    }
}
