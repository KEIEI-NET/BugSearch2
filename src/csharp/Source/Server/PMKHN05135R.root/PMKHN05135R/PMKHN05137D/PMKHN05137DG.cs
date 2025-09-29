//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換XMLデータ格納クラス
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
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　拠点コード変換XMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換XMLデータ格納クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [XmlRoot("ArrayOfSectionConvertList")]
    public class ArrayOfSectionConvertList
    {
        #region -- Member --

        /// <summary>対象テーブル情報一覧</summary>
        private List<SectionConvertList> sectionConvertList;

        #endregion

        #region -- Property --

        /// <summary>
        /// 対象テーブル情報一覧プロパティ
        /// </summary>
        [XmlElement("SectionConvertList")]
        public List<SectionConvertList> SectionConvertList
        {
            get { return this.sectionConvertList; }
            set { this.sectionConvertList = value; }
        }

        #endregion
    }
}
