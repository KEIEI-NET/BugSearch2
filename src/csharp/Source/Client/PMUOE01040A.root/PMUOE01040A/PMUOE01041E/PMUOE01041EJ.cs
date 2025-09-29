//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 買上一覧明細テーブルスキーマクラス
// プログラム概要   : 買上一覧明細テーブル定義を行う
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
    /// 買上一覧明細テーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買上一覧明細テーブルスキーマ</br>
    /// <br>Programmer : 96186　立花裕輔</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class BuyOutLstDtlSchema
    {
        #region Public Members
        /// <summary>買上一覧明細テーブル名</summary>
        public const string CT_BuyOutLstDtlDataTable = "BuyOutLstDtlDataTable";


        #region カラム初期情報
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValueString = "";
        #endregion

        #region カラム情報
        /// <summary> 通番 </summary>
        public const string ct_Col_No = "No";
        /// <summary> 注文月日 </summary>
        public const string ct_Col_OrderDate = "OrderDate";
        /// <summary> お買上日 </summary>
        public const string ct_Col_BuyOutDate = "BuyOutDate";
        /// <summary> 部番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 数量 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 希望小売価格 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> お買上単価 </summary>
        public const string ct_Col_BuyOutCost = "BuyOutCost";
        /// <summary> お買上額合計 </summary>
        public const string ct_Col_BuyOutTotalCost = "BuyOutTotalCost";
        /// <summary> 伝票番号 </summary>
        public const string ct_Col_BuyOutSlipNo = "BuyOutSlipNo";
        /// <summary> 注文時伝票番号 </summary>
        public const string ct_Col_OrderSlipNo = "OrderSlipNo";
        /// <summary> コメント(特記事項) </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> 注文時単価 </summary>
        public const string ct_Col_OrderCost = "OrderCost";
        /// <summary> 更新結果 </summary>
        public const string ct_Col_UpdRsl = "UpdRsl";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 買上一覧明細テーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 買上一覧明細テーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 96186　立花裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public BuyOutLstDtlSchema()
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
        /// 買上一覧明細作成処理
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

            // 通番
            dt.Columns.Add(ct_Col_No, typeof(Int32));
            dt.Columns[ct_Col_No].DefaultValue = defValueInt32;
            // 注文月日
            dt.Columns.Add(ct_Col_OrderDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDate].DefaultValue = DateTime.MinValue;
            // お買上日
            dt.Columns.Add(ct_Col_BuyOutDate, typeof(DateTime));
            dt.Columns[ct_Col_BuyOutDate].DefaultValue = DateTime.MinValue;
            // 部番
            dt.Columns.Add(ct_Col_GoodsNo, typeof(String));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValueString;
            // 品名
            dt.Columns.Add(ct_Col_GoodsName, typeof(String));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValueString;
            // 数量
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // 希望小売価格
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // お買上単価
            dt.Columns.Add(ct_Col_BuyOutCost, typeof(Double));
            dt.Columns[ct_Col_BuyOutCost].DefaultValue = defValueDouble;
            // お買上額合計
            dt.Columns.Add(ct_Col_BuyOutTotalCost, typeof(Double));
            dt.Columns[ct_Col_BuyOutTotalCost].DefaultValue = defValueDouble;
            // 伝票番号
            dt.Columns.Add(ct_Col_BuyOutSlipNo, typeof(String));
            dt.Columns[ct_Col_BuyOutSlipNo].DefaultValue = defValueString;
            // 注文時伝票番号
            dt.Columns.Add(ct_Col_OrderSlipNo, typeof(String));
            dt.Columns[ct_Col_OrderSlipNo].DefaultValue = defValueString;
            // コメント(特記事項)
            dt.Columns.Add(ct_Col_Comment, typeof(String));
            dt.Columns[ct_Col_Comment].DefaultValue = defValueString;
            // 注文時単価
            dt.Columns.Add(ct_Col_OrderCost, typeof(Double));
            dt.Columns[ct_Col_OrderCost].DefaultValue = defValueDouble;
            // 更新結果
            dt.Columns.Add(ct_Col_UpdRsl, typeof(Int32));
            dt.Columns[ct_Col_UpdRsl].DefaultValue = defValueInt32;

            //PrimaryKeyの設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_No] };

        }
        #endregion
    }
}