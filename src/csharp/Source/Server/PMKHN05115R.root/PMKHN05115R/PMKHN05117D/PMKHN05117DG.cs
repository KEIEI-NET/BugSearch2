//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換XMLデータ格納クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　担当者マスタコード変換XMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換XMLデータ格納クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [XmlRoot("ArrayOfEmployeeConvertList")]
    public class ArrayOfEmployeeConvertList
    {
        #region -- Member --

        /// <summary>対象テーブル情報一覧</summary>
        private List<EmployeeConvertList> emplyCnvList = null;

        #endregion

        #region -- Property --

        /// <summary>対象テーブル情報一覧プロパティ</summary>
        [XmlElement("EmployeeConvertList")]
        public List<EmployeeConvertList> EmployeeConvertList
        {
            get { return this.emplyCnvList; }
            set { this.emplyCnvList = value; }
        }

        #endregion
    }
}
