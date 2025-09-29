//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換XMLデータ格納クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換XMLデータ格納クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換XMLデータ格納クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [XmlRoot("ArrayOfWarehouseConvertList")]
    public class ArrayOfWarehouseConvertList
    {
        #region -- Member --

        /// <summary>対象テーブル情報一覧</summary>
        private List<WarehouseConvertList> warehouseConvertList;

        #endregion

        #region -- Property --

        /// <summary>
        /// 対象テーブル情報一覧プロパティ
        /// </summary>
        [XmlElement("WarehouseConvertList")]
        public List<WarehouseConvertList> WarehouseConvertList
        {
            get { return this.warehouseConvertList; }
            set { this.warehouseConvertList = value; }
        }

        #endregion
    }
}
