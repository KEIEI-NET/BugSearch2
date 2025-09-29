//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 注文一覧明細(手入力)テーブルスキーマクラス
// プログラム概要   : 注文一覧明細(手入力)テーブル定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 注文一覧明細(手入力)テーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 注文一覧明細(手入力)テーブルスキーマ</br>
    /// <br>Programmer : 96186　立花裕輔</br>
    /// <br>Date       : 2009/05/25</br>
    /// </remarks>
    public class OrderLstInputDtlSchema
    {
        #region Public Members
        /// <summary>注文一覧明細(手入力)テーブル名</summary>
        public const string CT_OrderLstInputDtlDataTable = "OrderLstInputDtlDataTable";


        #region カラム初期情報
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValueString = "";
        #endregion

        #region カラム情報
        /// <summary> お客様名 </summary>
        public const string ct_Col_UserName = "UserName";
        /// <summary> お客様CD </summary>
        public const string ct_Col_UserCode = "UserCode";
        /// <summary> アイテム </summary>
        public const string ct_Col_ItemCode = "ItemCode";
        /// <summary> 注文日 </summary>
        public const string ct_Col_OrderDate = "OrderDate";
        /// <summary> 注文時間 </summary>
        public const string ct_Col_OrderTime = "OrderTime";
        /// <summary> 伝票番号(ヘッダー部) </summary>
        public const string ct_Col_SlipNoHead = "SlipNoHead";
        /// <summary> メモ欄 </summary>
        public const string ct_Col_Memo = "Memo";
        /// <summary> 発注部品番号 </summary>
        public const string ct_Col_OrderGoodsNo = "OrderGoodsNo";
        /// <summary> 出荷部品番号 </summary>
        public const string ct_Col_ShipmGoodsNo = "ShipmGoodsNo";
        /// <summary> 出荷部品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 引当数量 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 発注残数量 </summary>
        public const string ct_Col_OrderRemCnt = "OrderRemCnt";
        /// <summary> 希望小売価格 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 出荷元名 </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> お届予定日 </summary>
        public const string ct_Col_PlanDate = "PlanDate";
        /// <summary> 伝票番号(明細部) </summary>
        public const string ct_Col_SlipNoDtl = "SlipNoDtl";
        /// <summary> 仕入れ価格 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 注文一覧明細(手入力)テーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 注文一覧明細(手入力)テーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 96186　立花裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public OrderLstInputDtlSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[dataTableName].Clear();
            }
            else
            {
                CreateTable(ref ds, dataTableName);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 注文一覧明細(手入力)作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // スキーマ設定
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // お客様名
            dt.Columns.Add(ct_Col_UserName, typeof(String));
            dt.Columns[ct_Col_UserName].DefaultValue = defValueString;
            // お客様CD
            dt.Columns.Add(ct_Col_UserCode, typeof(String));
            dt.Columns[ct_Col_UserCode].DefaultValue = defValueString;
            // アイテム
            dt.Columns.Add(ct_Col_ItemCode, typeof(String));
            dt.Columns[ct_Col_ItemCode].DefaultValue = defValueString;
            // 注文日
            dt.Columns.Add(ct_Col_OrderDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDate].DefaultValue = DateTime.MinValue;
            // 注文時間
            dt.Columns.Add(ct_Col_OrderTime, typeof(Int32));
            dt.Columns[ct_Col_OrderTime].DefaultValue = defValueInt32;
            // 伝票番号(ヘッダー部)
            dt.Columns.Add(ct_Col_SlipNoHead, typeof(String));
            dt.Columns[ct_Col_SlipNoHead].DefaultValue = defValueString;
            // メモ欄
            dt.Columns.Add(ct_Col_Memo, typeof(String));
            dt.Columns[ct_Col_Memo].DefaultValue = defValueString;
            // 発注部品番号
            dt.Columns.Add(ct_Col_OrderGoodsNo, typeof(String));
            dt.Columns[ct_Col_OrderGoodsNo].DefaultValue = defValueString;
            // 出荷部品番号
            dt.Columns.Add(ct_Col_ShipmGoodsNo, typeof(String));
            dt.Columns[ct_Col_ShipmGoodsNo].DefaultValue = defValueString;
            // 出荷部品名
            dt.Columns.Add(ct_Col_GoodsName, typeof(String));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValueString;
            // 引当数量
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // 発注残数量
            dt.Columns.Add(ct_Col_OrderRemCnt, typeof(Double));
            dt.Columns[ct_Col_OrderRemCnt].DefaultValue = defValueDouble;
            // 希望小売価格
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // 出荷元名
            dt.Columns.Add(ct_Col_SourceShipment, typeof(String));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defValueString;
            // お届予定日
            dt.Columns.Add(ct_Col_PlanDate, typeof(DateTime));
            dt.Columns[ct_Col_PlanDate].DefaultValue = DateTime.MinValue;
            // 伝票番号(明細部)
            dt.Columns.Add(ct_Col_SlipNoDtl, typeof(String));
            dt.Columns[ct_Col_SlipNoDtl].DefaultValue = defValueString;
            // 仕入れ価格
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
        }
        #endregion
    }
}