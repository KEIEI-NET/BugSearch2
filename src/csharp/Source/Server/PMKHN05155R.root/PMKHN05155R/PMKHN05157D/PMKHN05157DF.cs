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
    /// PM.NS統合ツール BaseCompanyListXMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール BaseCompanyListXMLデータ格納クラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/12</br>
    /// </remarks>
    [XmlRoot("ArrayOfBaseCompanyList")]
    public class ArrayOfBaseCompanyList
    {
        #region -- Member --

        /// <summary>対象テーブル情報一覧</summary>
        private List<BaseCompanyCvtList> baseCompanyCvtList;

        #endregion

        #region -- Property --

        /// <summary>対象テーブル情報一覧プロパティ</summary>
        [XmlElement("BaseCompanyList")]
        public List<BaseCompanyCvtList> BaseCompanyCvtList
        {
            get { return baseCompanyCvtList; }
            set { baseCompanyCvtList = value; }
        }

        #endregion
    }
}
