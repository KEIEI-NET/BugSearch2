//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換データパラメータ(検索)クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　拠点コード変換データパラメータ(検索)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換データパラメータ(検索)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class SectionSearchParamWork
    {
        #region -- Member --

        /// <summary>企業コード</summary>
        private string enterPriseCode = String.Empty;

        /// <summary>拠点コード(開始)</summary>
        private string sectionStCd = String.Empty;

        /// <summary>拠点コード(終了)</summary>
        private string sectionEdCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// 企業コードプロパティ
        /// </summary>
        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }

        /// <summary>
        /// 拠点コード(開始)プロパティ
        /// </summary>
        public string SectionStCd
        {
            get { return this.sectionStCd; }
            set { this.sectionStCd = value; }
        }

        /// <summary>
        /// 拠点コード(終了)プロパティ
        /// </summary>
        public string SectionEdCd
        {
            get { return this.sectionEdCd; }
            set { this.sectionEdCd = value; }
        }

        #endregion
    }
}
