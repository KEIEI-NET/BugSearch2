//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 買上一覧明細アクセスクラス
// プログラム概要   : 買上一覧明細アクセスを行う
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
    /// 買上一覧明細アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 買上一覧明細アクセスクラス</br>
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
        # region 買上一覧明細データテーブルRow作成
        /// <summary>
        /// 買上一覧明細データテーブルRow作成
        /// </summary>
        /// <param name="orderLstInputDtlList">買上一覧明細(手入力)</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int buyOutLstDtlFromDtlWrite(ArrayList list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                BuyOutLstDtlSchema.SettingDataSet(ref _uoeJnlDataSet, BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable);

                foreach (BuyOutLstDtl rst in list)
                {
                    DataRow dr = BuyOutLstDtlTable.NewRow();
                    CreateSchemaFromBuyOutLstDtl(ref dr, rst);
                    BuyOutLstDtlTable.Rows.Add(dr);
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

        # region 買上一覧明細データテーブルRow作成
        /// <summary>
        /// 買上一覧明細データテーブルRow作成
		/// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">買上一覧明細(手入力)クラス</param>
        public void CreateSchemaFromBuyOutLstDtl(ref DataRow dr, BuyOutLstDtl rst)
		{
            dr[BuyOutLstDtlSchema.ct_Col_No] = rst.No;// 通番
            dr[BuyOutLstDtlSchema.ct_Col_OrderDate] = rst.OrderDate;// 注文月日
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutDate] = rst.BuyOutDate;// お買上日
            dr[BuyOutLstDtlSchema.ct_Col_GoodsNo] = rst.GoodsNo;// 部番
            dr[BuyOutLstDtlSchema.ct_Col_GoodsName] = rst.GoodsName;// 品名
            dr[BuyOutLstDtlSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;// 数量
            dr[BuyOutLstDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;// 希望小売価格
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutCost] = rst.BuyOutCost;// お買上単価
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutTotalCost] = rst.BuyOutTotalCost;// お買上額合計
            dr[BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo] = rst.BuyOutSlipNo;// 伝票番号
            dr[BuyOutLstDtlSchema.ct_Col_OrderSlipNo] = rst.OrderSlipNo;// 注文時伝票番号
            dr[BuyOutLstDtlSchema.ct_Col_Comment] = rst.Comment;// コメント(特記事項)
            dr[BuyOutLstDtlSchema.ct_Col_OrderCost] = rst.OrderCost;// 注文時単価
            dr[BuyOutLstDtlSchema.ct_Col_UpdRsl] = rst.UpdRsl;// 更新結果
        }
		# endregion

        # region 買上一覧明細＜DataRow → クラス＞作成
        /// <summary>
        /// 買上一覧明細＜DataRow → クラス＞作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
        public BuyOutLstDtl CreateBuyOutLstDtlFromSchema(DataRow dr)
		{
            BuyOutLstDtl rst = new BuyOutLstDtl();

            rst.No = (Int32)dr[BuyOutLstDtlSchema.ct_Col_No];// 通番
            rst.OrderDate = (DateTime)dr[BuyOutLstDtlSchema.ct_Col_OrderDate];// 注文月日
            rst.BuyOutDate = (DateTime)dr[BuyOutLstDtlSchema.ct_Col_BuyOutDate];// お買上日
            rst.GoodsNo = (String)dr[BuyOutLstDtlSchema.ct_Col_GoodsNo];// 部番
            rst.GoodsName = (String)dr[BuyOutLstDtlSchema.ct_Col_GoodsName];// 品名
            rst.ShipmentCnt = (Double)dr[BuyOutLstDtlSchema.ct_Col_ShipmentCnt];// 数量
            rst.AnswerListPrice = (Double)dr[BuyOutLstDtlSchema.ct_Col_AnswerListPrice];// 希望小売価格
            rst.BuyOutCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_BuyOutCost];// お買上単価
            rst.BuyOutTotalCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_BuyOutTotalCost];// お買上額合計
            rst.BuyOutSlipNo = (String)dr[BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo];// 伝票番号
            rst.OrderSlipNo = (String)dr[BuyOutLstDtlSchema.ct_Col_OrderSlipNo];// 注文時伝票番号
            rst.Comment = (String)dr[BuyOutLstDtlSchema.ct_Col_Comment];// コメント(特記事項)
            rst.OrderCost = (Double)dr[BuyOutLstDtlSchema.ct_Col_OrderCost];// 注文時単価
            rst.UpdRsl = (Int32)dr[BuyOutLstDtlSchema.ct_Col_UpdRsl];// 更新結果
			return (rst);
		}
		# endregion

        # region 買上明細対象データの抽出
        /// <summary>
        /// 買上明細対象データの抽出
        /// </summary>
        /// <param name="mode">0:＜買上時伝票番号＞ 1:＜注文時伝票番号＞</param>
        /// <param name="PartySaleSlipNum">相手先伝票番号</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(int mode, string partySaleSlipNum)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //＜買上時伝票番号＞
            if (mode == 0)
            {
                rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_BuyOutSlipNo, partySaleSlipNum
                                                );
            }
            //＜注文時伝票番号＞
            else
            {
                rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_OrderSlipNo, partySaleSlipNum
                                                );
            }


            // ソート順設定
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }
        
        /// <summary>
        /// 買上明細対象データの抽出
        /// </summary>
        /// <param name="PartySaleSlipNum">相手先伝票番号</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="updRsl">更新結果</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(string partySaleSlipNum, string goodsNo, double shipmentCnt, Int32 updRsl)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //＜注文日・注文時伝票番号・品番・数量＞
            rowFilterText = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                BuyOutLstDtlSchema.ct_Col_OrderSlipNo, partySaleSlipNum,
                                                BuyOutLstDtlSchema.ct_Col_GoodsNo, goodsNo,
                                                BuyOutLstDtlSchema.ct_Col_ShipmentCnt, shipmentCnt,
                                                BuyOutLstDtlSchema.ct_Col_UpdRsl, updRsl
                                            );


            // ソート順設定
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// 買上明細対象データの抽出
        /// </summary>
        /// <param name="updRsl">更新結果</param>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView(Int32 updRsl)
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            //＜注文日・注文時伝票番号・品番・数量＞
            rowFilterText = string.Format("{0} = {1}",
                                                BuyOutLstDtlSchema.ct_Col_UpdRsl, updRsl
                                            );


            // ソート順設定
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// 買上明細対象データの抽出
        /// </summary>
        /// <returns>DataView</returns>
        public DataView GetBuyOutLstDtlFormCreateView()
        {
            DataView view = new DataView(this.BuyOutLstDtlTable);

            string rowFilterText = String.Empty;

            // ソート順設定
            string sortText = string.Format("{0}",
                                            BuyOutLstDtlSchema.ct_Col_No
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        # endregion



		# endregion
	}
}
