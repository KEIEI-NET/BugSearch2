//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリストアクセスクラス
// プログラム概要   : 発注点設定マスタリスト一覧で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注点設定マスタリストアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリスト一覧で使用するデータを取得する</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.03.26</br>
    /// </remarks>
    public class OrderSetMasListReportAcs
    {
        #region ■ Private Member
        // 発注点設定マスタリスト検索インタフェース
        private IOrderSetMasListDB _iOrderSetMasListDB;

        // DataSetオブジェクト
        private DataSet _dataSet;
        #endregion

        #region ■ Public Property
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion ■ Public Property

        #region ■ コンストラクタ
        /// <summary>
        /// 発注点設定マスタリストアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public OrderSetMasListReportAcs()
        {
            _iOrderSetMasListDB = (IOrderSetMasListDB)MediationOrderSetMasListDB.GetOrderSetMasListDB();
        }
        #endregion

        #region ■ 発注点設定マスタリスト情報検索
        /// <summary>
        /// 発注点設定マスタリストデータ取得処理
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(OrderSetMasListPara para, out string errMsg)
        {
            return this.SearchProc(para, out errMsg);
        }

        /// <summary>
        /// 発注点設定マスタリストデータ取得
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private int SearchProc( OrderSetMasListPara para, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            // DataTable Create ----------------------------------------------------------
            PMHAT02025EA.CreateDataTable(ref _dataSet);

            OrderSetMasListParaWork paraWork = new OrderSetMasListParaWork();


            // 抽出条件展開<画面検索情報->remoteDean>  --------------------------------------------------------------
            status = this.SetCondInfo(ref para, out paraWork, out errMsg);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // データ取得  ----------------------------------------------------------------
            object retList = null;
            object paraWorkRef = paraWork;

            status = _iOrderSetMasListDB.Search(out retList, ref paraWorkRef);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    //remote -> dataset
                    ConverToDataSetForPdf(_dataSet.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData], (ArrayList)retList);
                   
                    if (this._dataSet.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData].Rows.Count < 1)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    break;
                default:
                    errMsg = "発注点設定マスタの帳票出力データの取得に失敗しました。";
                    break;
            }
            return status;
        }
        #endregion

        #region ■ 抽出条件設定
        /// <summary>
        /// 抽出条件設定処理
        /// </summary>
        /// <param name="condition">UI抽出条件クラス</param>
        /// <param name="dRemoteCondition">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private int SetCondInfo(ref OrderSetMasListPara condition, out OrderSetMasListParaWork dRemoteCondition, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            dRemoteCondition = new OrderSetMasListParaWork();
            errMsg = string.Empty;
            try
            {   // 企業コード
                dRemoteCondition.EnterpriseCode = condition.EnterpriseCode;

                // 設定コード（開始）
                dRemoteCondition.StartSetCode = condition.StartSetCode;

                //  設定コード（終了）
                dRemoteCondition.EndSetCode = condition.EndSetCode;

                // 倉庫コード（開始）
                dRemoteCondition.StartWarehouseCode= condition.StartWarehouseCode;

                // 倉庫コード（終了）
                dRemoteCondition.EndWarehouseCode = condition.EndWarehouseCode;

                // 仕入先コード（開始）
                dRemoteCondition.StartSupplierCd = condition.StartSupplierCd;

                // 仕入先コード（終了）
                dRemoteCondition.EndSupplierCd = condition.EndSupplierCd;

                // 中分類コード（開始）
                dRemoteCondition.StartGoodsMGroup = condition.StartGoodsMGroup;

                // 中分類コード（終了）
                dRemoteCondition.EndGoodsMGroup = condition.EndGoodsMGroup;

               // グループコード（開始）
                dRemoteCondition.StartBLGroupCode = condition.StartBLGroupCode;

                // グループコード（終了）
                dRemoteCondition.EndBLGroupCode = condition.EndBLGroupCode;

                 // ＢＬコード（開始）
                dRemoteCondition.StartBLGoodsCode = condition.StartBLGoodsCode;

                // ＢＬコード（終了）
                dRemoteCondition.EndBLGoodsCode = condition.EndBLGoodsCode;
               
                 // メーカーコード（開始）
                dRemoteCondition.StartGoodsMakerCd = condition.StartGoodsMakerCd;

                // メーカーコード（終了）
                dRemoteCondition.EndGoodsMakerCd = condition.EndGoodsMakerCd;

                // 発行タイプ
                dRemoteCondition.PrintType = condition.PrintType;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region ■ DataTableにデータ設定
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList)
        {
            for (int i = 0; i < retList.Count; i++)
            {
                OrderSetMasListWork rsltInfo = (OrderSetMasListWork)retList[i];
                DataRow dr = null;
                dr = dataTable.NewRow();
                // 設定コード
                dr[PMHAT02025EA.Col_SetCode] = rsltInfo.PatterNo.ToString("D3");
                // 倉庫コード
                dr[PMHAT02025EA.Col_WarehouseCodeRF] = rsltInfo.WarehouseCode.PadLeft(4, '0');
                // 倉庫名称
                dr[PMHAT02025EA.Col_WarehouseNameRF] = rsltInfo.WarehouseName;
                // 仕入先コード
                dr[PMHAT02025EA.Col_SupplierCdRF] = rsltInfo.SupplierCd.PadLeft(6, '0');
                // 仕入先名称
                dr[PMHAT02025EA.Col_SupplierNameRF] = rsltInfo.SupplierSnm;
                // メーカーコード
                dr[PMHAT02025EA.Col_GoodsMakerCdRF] = rsltInfo.GoodsMakerCd.PadLeft(4, '0');
                // メーカー名称
                dr[PMHAT02025EA.Col_GoodsMakerNameRF] = rsltInfo.MakerName;
                // 中分類コード
                dr[PMHAT02025EA.Col_GoodsMGroupCdRF] = rsltInfo.GoodsMGroup.PadLeft(4, '0');
                // 中分類名称
                dr[PMHAT02025EA.Col_GoodsMGroupNameRF] = rsltInfo.GoodsMGroupName;
                // BLグループコード
                dr[PMHAT02025EA.Col_BLGroupCodeRF] = rsltInfo.BLGroupCode.PadLeft(5, '0');
                // BLグループ名称
                dr[PMHAT02025EA.Col_BLGroupNameRF] = rsltInfo.BLGroupName;
                // BL商品コード
                dr[PMHAT02025EA.Col_BLGoodsCodeRF] = rsltInfo.BLGoodsCode.PadLeft(5, '0');                // BL商品コード名称
                dr[PMHAT02025EA.Col_BLGoodsNameRF] = rsltInfo.BLGoodsHalfName;
                // 在庫出荷対象開始月
                dr[PMHAT02025EA.Col_StckShipMonthStRF] = rsltInfo.StckShipMonthSt;
                // 在庫出荷対象終了月
                dr[PMHAT02025EA.Col_StckShipMonthEdRF] = rsltInfo.StckShipMonthEd;
                // 在庫登録日
                dr[PMHAT02025EA.Col_StockCreateDateRF] = rsltInfo.StockCreateDate;
                // 出荷数範囲(以上)
                dr[PMHAT02025EA.Col_ShipScopeMoreRF] = rsltInfo.ShipScopeMore;
                // 出荷数範囲(以下)
                dr[PMHAT02025EA.Col_ShipScopeLessRF] = rsltInfo.ShipScopeLess;
                // 最低在庫数
                dr[PMHAT02025EA.Col_MinimumStockCntRF] = rsltInfo.MinimumStockCnt;
                // 最高在庫数
                dr[PMHAT02025EA.Col_MaximumStockCntRF] = rsltInfo.MaximumStockCnt;
                // ロット数
                dr[PMHAT02025EA.Col_SalesOrderUnitRF] = rsltInfo.SalesOrderUnit;
                // 発注点処理更新フラグ
                dr[PMHAT02025EA.Col_OrderPProcUpdFlgRF] = rsltInfo.OrderPProcUpdFlg;
                // 区分
                dr[PMHAT02025EA.Col_OrderApplyDivRF] = rsltInfo.OrderApplyDiv;

                dataTable.Rows.Add(dr);
            }
        }

        #endregion

        #region ■ Private Mehtods
        /// <summary>
        /// 文字列断ち切る処理
        /// </summary>
        /// <param name="useName">文字列</param>
        /// <param name="byteLength">断ち切るサイズ</param>
        private string GetStringToByte(string useName, int byteLength)
        {
            if (string.IsNullOrEmpty(useName))
            {
                return string.Empty;
            }

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(useName);
            int n = 0;  //  当該の漢字
            int i;  //  表示の漢字
            if (bytes.GetLength(0) < byteLength)
            {
                return useName;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                //  
                if (i % 2 == 0)
                {
                    n++;      //  
                }
                else
                {
                    //  
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            //  
            if (i % 2 == 1)
            {
                // 
                if (bytes[i] > 0)
                    i = i - 1;
                 //  
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
        #endregion
    }
}
