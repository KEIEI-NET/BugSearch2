//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新データテキスト出力
// プログラム概要   : 出品一括更新データテキスト出力
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 出品一括更新テーブル
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品一括更新データテーブル用カラムクラス。</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// </remarks>
    public class ExportMoveDataItems
    {
        #region ■ 移動データ用テーブル
        /// <summary>データ用テーブル名称</summary>
        public const string ct_Tbl_Arrival = "Tbl_Arrival";
        /// <summary>警告用テーブル名称</summary>
        public const string ct_Tbl_ArrivalWarning = "Tbl_ArrivalWarning";


        /// <summary>企業コード</summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>倉庫</summary>
        public const string ct_Col_WarehCode = "BfEnterWarehCode";
        /// <summary>倉庫名</summary>
        public const string ct_Col_WarehName = "BfEnterWarehName";
        /// <summary>品名</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary>品番</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>メーカーコード</summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>メーカー名</summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary>BLｺｰﾄﾞ</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>オープン価格区分</summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary>販売単価</summary>
        public const string ct_Col_SalesPrice = "SalesPrice";
        /// <summary>売価率</summary>
        public const string ct_Col_SalesRate = "SalesRate";
        /// <summary>現在庫数</summary>
        public const string ct_Col_ShipmentCount = "ShipmentCount";
        /// <summary>警告理由</summary>
        public const string ct_Col_AlertReason = "AlertReason";

        #endregion
    }
}
