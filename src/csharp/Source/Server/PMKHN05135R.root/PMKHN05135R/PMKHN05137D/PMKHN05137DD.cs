//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換データパラメータ(実行)クラス
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
    /// PM.NS統合ツール　拠点コード変換データパラメータ(実行)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換データパラメータ(実行)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class SectionConvertPrmWork
    {
        #region -- Member --

        /// <summary>変換前拠点コード</summary>
        private string bfSectionCode = String.Empty;
        /// <summary>変換後拠点コード</summary>
        private string afSectionCode = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// 変更前拠点コード
        /// </summary>
        public string BfSectionCode
        {
            get { return this.bfSectionCode; }
            set { this.bfSectionCode = value; }
        }

        /// <summary>
        /// 変更後拠点コード
        /// </summary>
        public string AfSectionCode
        {
            get { return this.afSectionCode; }
            set { this.afSectionCode = value; }
        }

        #endregion
    }
}
