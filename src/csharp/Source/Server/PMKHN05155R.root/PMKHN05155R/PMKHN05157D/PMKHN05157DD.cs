//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換XMLデータ格納クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール woleCompanyCvtListXMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール woleCompanyCvtListXMLデータ格納クラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/12</br>
    /// </remarks>
    [XmlRoot("ArrayOfWholeCompanyList")]
    public class ArrayOfWholeCompanyList
    {
        #region -- Member --

        /// <summary>対象テーブル情報一覧</summary>
        private List<WholeCompanyCvtList> woleCompanyCvtList;

        #endregion

        #region -- Property --

        /// <summary>対象テーブル情報一覧プロパティ</summary>
        [XmlElement("WholeCompanyList")]

        public List<WholeCompanyCvtList> WoleCompanyCvtList
        {
            get { return woleCompanyCvtList; }
            set { woleCompanyCvtList = value; }
        }

        #endregion
    }
}
