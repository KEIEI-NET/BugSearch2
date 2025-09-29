//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 注文一覧明細(手入力)アクセスクラス
// プログラム概要   : 注文一覧明細(手入力)アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 注文一覧明細(手入力)アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 注文一覧明細(手入力)アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2009/05/25</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 新規作成</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// publicメソッド
		// ===================================================================================== //
		# region public Methods
        # region 注文一覧明細(手入力)データテーブルRow作成
        /// <summary>
        /// 注文一覧明細(手入力)データテーブルRow作成
        /// </summary>
        /// <param name="orderLstInputDtlList">注文一覧明細(手入力)</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int orderLstInputDtlFromDtlWrite(ArrayList list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                OrderLstInputDtlSchema.SettingDataSet(ref _uoeJnlDataSet, OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable);

                foreach (OrderLstInputDtl rst in list)
                {
                    DataRow dr = OrderLstInputDtlTable.NewRow();
                    CreateSchemaFromOrderLstInputDtl(ref dr, rst);
                    OrderLstInputDtlTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 注文一覧明細(手入力)データテーブルRow作成
        /// <summary>
        /// 注文一覧明細(手入力)データテーブルRow作成
		/// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">注文一覧明細(手入力)クラス</param>
        public void CreateSchemaFromOrderLstInputDtl(ref DataRow dr, OrderLstInputDtl rst)
		{
            dr[OrderLstInputDtlSchema.ct_Col_UserName] = rst.UserName;// お客様名
            dr[OrderLstInputDtlSchema.ct_Col_UserCode] = rst.UserCode;// お客様CD
            dr[OrderLstInputDtlSchema.ct_Col_ItemCode] = rst.ItemCode;// アイテム
            dr[OrderLstInputDtlSchema.ct_Col_OrderDate] = rst.OrderDate;// 注文日
            dr[OrderLstInputDtlSchema.ct_Col_OrderTime] = rst.OrderTime;// 注文時間
            dr[OrderLstInputDtlSchema.ct_Col_SlipNoHead] = rst.SlipNoHead;// 伝票番号(ヘッダー部)
            dr[OrderLstInputDtlSchema.ct_Col_Memo] = rst.Memo;// メモ欄
            dr[OrderLstInputDtlSchema.ct_Col_OrderGoodsNo] = rst.OrderGoodsNo;// 発注部品番号
            dr[OrderLstInputDtlSchema.ct_Col_ShipmGoodsNo] = rst.ShipmGoodsNo;// 出荷部品番号
            dr[OrderLstInputDtlSchema.ct_Col_GoodsName] = rst.GoodsName;// 出荷部品名
            dr[OrderLstInputDtlSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;// 引当数量
            dr[OrderLstInputDtlSchema.ct_Col_OrderRemCnt] = rst.OrderRemCnt;// 発注残数量
            dr[OrderLstInputDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;// 希望小売価格
            dr[OrderLstInputDtlSchema.ct_Col_SourceShipment] = rst.SourceShipment;// 出荷元名
            dr[OrderLstInputDtlSchema.ct_Col_PlanDate] = rst.PlanDate;// お届予定日
            dr[OrderLstInputDtlSchema.ct_Col_SlipNoDtl] = rst.SlipNoDtl;// 伝票番号(明細部)
            dr[OrderLstInputDtlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost;// 仕入れ価格
        }
		# endregion

        # region 注文一覧明細(手入力)＜DataRow → クラス＞作成
        /// <summary>
        /// 注文一覧明細(手入力)＜DataRow → クラス＞作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
        public OrderLstInputDtl CreateOrderLstInputDtlFromSchema(DataRow dr)
		{
            OrderLstInputDtl rst = new OrderLstInputDtl();

            rst.UserName = (String)dr[OrderLstInputDtlSchema.ct_Col_UserName];// お客様名
            rst.UserCode = (String)dr[OrderLstInputDtlSchema.ct_Col_UserCode];// お客様CD
            rst.ItemCode = (String)dr[OrderLstInputDtlSchema.ct_Col_ItemCode];// アイテム
            rst.OrderDate = (DateTime)dr[OrderLstInputDtlSchema.ct_Col_OrderDate];// 注文日
            rst.OrderTime = (Int32)dr[OrderLstInputDtlSchema.ct_Col_OrderTime];// 注文時間
            rst.SlipNoHead = (String)dr[OrderLstInputDtlSchema.ct_Col_SlipNoHead];// 伝票番号(ヘッダー部)
            rst.Memo = (String)dr[OrderLstInputDtlSchema.ct_Col_Memo];// メモ欄
            rst.OrderGoodsNo = (String)dr[OrderLstInputDtlSchema.ct_Col_OrderGoodsNo];// 発注部品番号
            rst.ShipmGoodsNo = (String)dr[OrderLstInputDtlSchema.ct_Col_ShipmGoodsNo];// 出荷部品番号
            rst.GoodsName = (String)dr[OrderLstInputDtlSchema.ct_Col_GoodsName];// 出荷部品名
            rst.ShipmentCnt = (Double)dr[OrderLstInputDtlSchema.ct_Col_ShipmentCnt];// 引当数量
            rst.OrderRemCnt = (Double)dr[OrderLstInputDtlSchema.ct_Col_OrderRemCnt];// 発注残数量
            rst.AnswerListPrice = (Double)dr[OrderLstInputDtlSchema.ct_Col_AnswerListPrice];// 希望小売価格
            rst.SourceShipment = (String)dr[OrderLstInputDtlSchema.ct_Col_SourceShipment];// 出荷元名
            rst.PlanDate = (DateTime)dr[OrderLstInputDtlSchema.ct_Col_PlanDate];// お届予定日
            rst.SlipNoDtl = (String)dr[OrderLstInputDtlSchema.ct_Col_SlipNoDtl];// 伝票番号(明細部)
            rst.AnswerSalesUnitCost = (Double)dr[OrderLstInputDtlSchema.ct_Col_AnswerSalesUnitCost];// 仕入れ価格

			return (rst);
		}
		# endregion

        # region 注文一覧明細(手入力)対象データの抽出
        /// <summary>
        /// 注文一覧明細(手入力)対象データの抽出
        /// </summary>
        /// <param name="StockDate">仕入日付</param>
        /// <param name="PartySaleSlipNum">相手先伝票番号</param>
        /// <returns>DataView</returns>
        public DataView GetOrderLstInputFormCreateView(DateTime stockDate, string partySaleSlipNum)
        {
            DataView view = new DataView(this.OrderLstInputDtlTable);

            //string rowFilterText = string.Format("{0} = {1}",
            string rowFilterText = string.Format("{0} = '{1}' AND {2} = '{3}'",
                                            OrderLstInputDtlSchema.ct_Col_PlanDate, stockDate,
                                            OrderLstInputDtlSchema.ct_Col_SlipNoDtl, partySaleSlipNum
                                            );


            // ソート順設定
            string sortText = string.Format("{0}",
                                            OrderLstInputDtlSchema.ct_Col_OrderGoodsNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        # endregion

        # endregion
    }
}
