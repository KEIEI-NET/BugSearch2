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
    public class SectionSearchWork
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

        /// <summary>
        /// 論理削除フラグプロパティ
        /// </summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>
        /// 拠点コード(開始)プロパティ
        /// </summary>
        public string SectionCd
        {
            get { return this.sectionCd; }
            set { this.sectionCd = value; }
        }

        /// <summary>
        /// 拠点名称プロパティ
        /// </summary>
        public string SectionNm
        {
            get { return this.sectionNm; }
            set { this.sectionNm = value; }
        }

        #endregion
    }
}
