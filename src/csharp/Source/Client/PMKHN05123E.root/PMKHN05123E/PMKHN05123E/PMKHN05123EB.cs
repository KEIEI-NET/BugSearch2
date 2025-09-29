//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換データクラス(得意先コード、得意先名称)
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
    /// PM.NS統合ツール　得意先マスタコード変換画面データクラス(得意先コード、得意先名称)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerDispInfo
    {
        #region -- Member --

        /// <summary>論理削除フラグ</summary>
        private int logicalDelete = 0;
        /// <summary>得意先コード</summary>
        private int customerCd = 0;
        /// <summary>得意先名</summary>
        private string customerNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>論理削除フラグプロパティ</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>得意先コードプロパティ</summary>
        public int CustomerCode
        {
            get { return this.customerCd; }
            set { this.customerCd = value; }
        }

        /// <summary>得意先名プロパティ</summary>
        public string CustomerName
        {
            get { return this.customerNm; }
            set { this.customerNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　得意先マスタコード変換画面データクラス(得意先コード、得意先名称)コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、得意先マスタコード変換画面データクラス(得意先コード、得意先名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks> 
        public CustomerDispInfo()
        {
            // 処理なし
        }

        /// <summary>
        /// PM.NS統合ツール　得意先マスタコード変換画面データ転送クラス(得意先コード、得意先名称)コンストラクタ
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <param name="name">得意先名称</param>
        /// <param name="logicalDel">論理削除フラグ</param>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、得意先マスタコード変換画面データ転送クラス(得意先コード、得意先名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>  
        public CustomerDispInfo(int code, string name, int logicalDel)
        {
            this.CustomerCode = code;
            this.CustomerName = name;
            this.LogicalDelete = logicalDel;
        }

        #endregion
    }
}
