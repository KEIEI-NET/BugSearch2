//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換データクラス(拠点コード、拠点名称)
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS統合ツール　拠点コード変換画面データクラス(拠点コード、拠点名称)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionDispInfo
    {
        #region -- Member --

        /// <summary>論理削除フラグ</summary>
        private int logicalDelete = 0;
        /// <summary>拠点コード</summary>
        private string sectionCd = String.Empty;
        /// <summary>拠点名称</summary>
        private string sectionNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>論理削除フラグプロパティ</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>拠点コードプロパティ</summary>
        public string SectionCode
        {
            get { return this.sectionCd; }
            set { this.sectionCd = value; }
        }

        /// <summary>拠点名称</summary>
        public string SectionName
        {
            get { return this.sectionNm; }
            set { this.sectionNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　拠点コード変換画面データクラス(拠点コード、拠点名称)コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、拠点コード変換画面データクラス(拠点コード、拠点名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>   
        public SectionDispInfo()
        {
            // 処理なし
        }

        /// <summary>
        /// PM.NS統合ツール　拠点コード変換画面データ転送クラス(拠点コード、拠点名称)コンストラクタ
        /// </summary>
        /// <param name="code">拠点コード</param>
        /// <param name="name">拠点名称</param>
        /// <param name="logicalDel">論理削除フラグ</param>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、拠点コード変換画面データ転送クラス(拠点コード、拠点名称)の初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>   
        public SectionDispInfo(string code, string name, int logicalDel)
        {
            this.SectionCode = code;
            this.SectionName = name;
            this.logicalDelete = logicalDel;
        }

        #endregion
    }
}
