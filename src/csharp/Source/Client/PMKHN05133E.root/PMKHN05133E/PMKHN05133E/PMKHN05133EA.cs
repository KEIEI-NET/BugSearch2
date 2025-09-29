//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換データクラス
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
    /// PM.NS統合ツール　拠点コード変換画面データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換画面データクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionConvertDispInfo
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>拠点コード(開始)</summary>
        private string sectionCdStart = String.Empty;
        /// <summary>拠点コード(終了)</summary>
        private string sectionCdEnd = String.Empty;        

        #endregion

        #region -- Property --

        /// <summary>企業コードプロパティ</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>拠点コード(開始)プロパティ</summary>
        public string SectionCdStart
        {
            get { return this.sectionCdStart; }
            set { this.sectionCdStart = value; }
        }

        /// <summary>拠点コード(終了)プロパティ</summary>
        public string SectionCdEnd
        {
            get { return this.sectionCdEnd; }
            set { this.sectionCdEnd = value; }
        }

        #endregion
    }
}
