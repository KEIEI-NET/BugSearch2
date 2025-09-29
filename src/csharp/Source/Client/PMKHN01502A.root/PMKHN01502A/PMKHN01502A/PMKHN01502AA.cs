//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/13  修正内容 : 連番No.2 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : caohh
// 修 正 日  2011/07/21  修正内容 : 連番No.2 優良データ削除チェックリスト対応
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 高騁
// 修 正 日  2015/06/08  修正内容 : REDMINE#45792掛率マスタ削除・削除しないの制御修正
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 優良データ削除処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 優良データ削除処理で使用するデータを取得する。</br>
    /// <br>Programmer	: 梁森東</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br>Update Nota : 2011/07/21 caohh</br>
    /// <br>            : 優良データ削除チェックリスト対応</br>
    /// <br>Update Note : 2015/06/08 高騁</br>
    /// <br>管理番号    : 11100068-00 </br>
    /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
    /// </remarks>
    public class DeleteConditionAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public DeleteConditionAcs()
        {
            this._yuuRyouDataDelDB = MediationYuuRyouDataDelDB.GetYuuRyouDataDelDB();
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private IYuuRyouDataDelDB _yuuRyouDataDelDB = null;
        private static DeleteConditionAcs _deleteConditionAcs = null;
        // ---- ADD caohh 2011/07/21 ---->>>>
        private DataTable _deleteListDt;			// 印刷DataTable
        private DataView _deleteListDataView;	    // 印刷DataView
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        // ---- ADD caohh 2011/07/21 ----<<<<
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView DeleteListDataView
        {
            get { return this._deleteListDataView; }
        }
        #endregion ■ Public Property
        // ---- ADD caohh 2011/07/21 ----<<<<

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public static DeleteConditionAcs GetInstance()
        {
            // ---- ADD caohh 2011/07/21 ---->>>>
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
            // ---- ADD caohh 2011/07/21 ----<<<<

            if (_deleteConditionAcs == null)
            {
                _deleteConditionAcs = new DeleteConditionAcs();
            }

            return _deleteConditionAcs;
        }

        #region 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理を行い。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note : 2015/06/08 高騁</br>
        /// <br>管理番号    : 11100068-00 </br>
        /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
        /// </remarks>
        public int DeleteData(ref string errMsg, ref DeleteCondition deleteCondition)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                DeleteConditionWork deleteConditionWork = new DeleteConditionWork();
                //企業コード
                deleteConditionWork.EnterpriseCode = deleteCondition.EnterpriseCode;
                //削除区分
                deleteConditionWork.DeleteCode = deleteCondition.DeleteCode;
                //拠点
                deleteConditionWork.SectionCode = deleteCondition.SectionCode;
                //メーカー
                if (deleteCondition.GoodsMakerCode != 0)
                {
                    deleteConditionWork.GoodsMakerCode = deleteCondition.GoodsMakerCode;
                }
                // 入力コード1
                deleteConditionWork.Code1 = deleteCondition.Code1;
                // 入力コード2
                if (deleteCondition.Code2 != 0)
                {
                    deleteConditionWork.Code2 = deleteCondition.Code2;
                }
                // 入力コード3
                if (deleteCondition.Code3 != 0)
                {
                    deleteConditionWork.Code3 = deleteCondition.Code3;
                }
                // 入力コード4
                if (deleteCondition.Code4 != 0)
                {
                    deleteConditionWork.Code4 = deleteCondition.Code4;
                }
                //商品在庫削除区分
                if (deleteCondition.GoodsDeleteCode != 0)
                {
                    deleteConditionWork.GoodsDeleteCode = deleteCondition.GoodsDeleteCode;
                }
                //結合在庫削除区分
                if (deleteCondition.JoinDeleteCode != 0)
                {
                    deleteConditionWork.JoinDeleteCode = deleteCondition.JoinDeleteCode;
                }
                // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                //掛率マスタ削除区分
                if (deleteCondition.RateDeleteCode != 0)
                {
                    deleteConditionWork.RateDeleteCode = deleteCondition.RateDeleteCode;
                }
                // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                object objDeletePara = (object)deleteConditionWork;
                status = this._yuuRyouDataDelDB.Delete(ref objDeletePara);

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    deleteConditionWork = new DeleteConditionWork();
                    deleteConditionWork = objDeletePara as DeleteConditionWork;
                    deleteCondition = new DeleteCondition();
                    deleteCondition.GoodsDeleteCnt = deleteConditionWork.GoodsDeleteCnt;
                    deleteCondition.GoodsNotDeleteCnt = deleteConditionWork.GoodsNotDeleteCnt;
                    deleteCondition.JoinDeleteCnt = deleteConditionWork.JoinDeleteCnt;
                    deleteCondition.JoinNotDeleteCnt = deleteConditionWork.JoinNotDeleteCnt;
                    deleteCondition.StockDeleteCnt = deleteConditionWork.StockDeleteCnt;
                    deleteCondition.StockNotDeleteCnt = deleteConditionWork.StockNotDeleteCnt;
                    // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                    deleteCondition.RateDeleteCnt = deleteConditionWork.RateDeleteCnt;
                    deleteCondition.RateNotDeleteCnt = deleteConditionWork.RateNotDeleteCnt;
                    // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }
            return status;
        }
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region データ取得処理
        /// <summary>
        /// データ取得処理
        /// </summary>
        /// <param name="errMsg">errMsg</param>
        /// <param name="deleteCondition">UI抽出条件クラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : データ取得処理を行い。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        public int SearchMain(ref string errMsg, ref DeleteCondition deleteCondition)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKHN01505EA.CreateDataTable(ref this._deleteListDt);

                DeleteConditionWork deleteConditionWork = new DeleteConditionWork();
                #region 抽出条件展開
                //企業コード
                deleteConditionWork.EnterpriseCode = deleteCondition.EnterpriseCode;
                //削除区分
                deleteConditionWork.DeleteCode = deleteCondition.DeleteCode;
                //拠点
                deleteConditionWork.SectionCode = deleteCondition.SectionCode;
                //メーカー
                if (deleteCondition.GoodsMakerCode != 0)
                {
                    deleteConditionWork.GoodsMakerCode = deleteCondition.GoodsMakerCode;
                }
                // 入力コード1
                deleteConditionWork.Code1 = deleteCondition.Code1;
                // 入力コード2
                if (deleteCondition.Code2 != 0)
                {
                    deleteConditionWork.Code2 = deleteCondition.Code2;
                }
                // 入力コード3
                if (deleteCondition.Code3 != 0)
                {
                    deleteConditionWork.Code3 = deleteCondition.Code3;
                }
                // 入力コード4
                if (deleteCondition.Code4 != 0)
                {
                    deleteConditionWork.Code4 = deleteCondition.Code4;
                }
                //商品在庫削除区分
                if (deleteCondition.GoodsDeleteCode != 0)
                {
                    deleteConditionWork.GoodsDeleteCode = deleteCondition.GoodsDeleteCode;
                }
                //結合在庫削除区分
                if (deleteCondition.JoinDeleteCode != 0)
                {
                    deleteConditionWork.JoinDeleteCode = deleteCondition.JoinDeleteCode;
                }
                #endregion
                object objDeletePara = (object)deleteConditionWork;
                // データ取得  ----------------------------------------------------------------
                object deleteData = null;
                status = this._yuuRyouDataDelDB.Search(out deleteData, objDeletePara, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DeleteListData(deleteCondition, (ArrayList)deleteData);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._deleteListDataView.Count == 0)
                        {
                            // 印刷データが存在しない
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        this._deleteListDataView = new DataView();
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "優良データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }
            return status;
        }
        #endregion

        #region 取得データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="deleteCondition">UI抽出条件クラス</param>
        /// <param name="deleteData">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        private void DeleteListData(DeleteCondition deleteCondition, ArrayList deleteData)
        {
            DataRow dr;
            foreach (DeleteResultWork deleteResultWork in deleteData)
            {
                dr = this._deleteListDt.NewRow();
                // 取得データ展開
                #region 取得データ展開
                dr[PMKHN01505EA.ct_Col_GoodsMakerCd] = deleteResultWork.GoodsMakerCd;                // 商品メーカーコード
                dr[PMKHN01505EA.ct_Col_MakerName] = deleteResultWork.MakerName;                      // メーカー名称
                dr[PMKHN01505EA.ct_Col_GoodsNo] = deleteResultWork.GoodsNo;                          // 商品番号
                dr[PMKHN01505EA.ct_Col_BLGoodsCode] = deleteResultWork.BLGoodsCode;                  // BL商品コード
                dr[PMKHN01505EA.ct_Col_GoodsName] = deleteResultWork.GoodsName;                      // 商品名称
                dr[PMKHN01505EA.ct_Col_WarehouseCode] = deleteResultWork.WarehouseCode;              // 倉庫コード
                dr[PMKHN01505EA.ct_Col_WarehouseName] = deleteResultWork.WarehouseName;              // 倉庫名称
                dr[PMKHN01505EA.ct_Col_WarehouseShelfNo] = deleteResultWork.WarehouseShelfNo;        // 倉庫棚番
                dr[PMKHN01505EA.ct_Col_SalesOrderCount] = deleteResultWork.SalesOrderCount;          // 受注数(発注残)
                dr[PMKHN01505EA.ct_Col_ShipmentPosCnt] = deleteResultWork.ShipmentPosCnt;            // 出荷可能数
               
                #endregion

                // TableにAdd
                this._deleteListDt.Rows.Add(dr);
            }

            if (this._deleteListDt.Rows.Count == 0)
            {
                // 対象データがゼロ件
                this._deleteListDataView = new DataView();
                return;
            }

            // DataView作成
            this._deleteListDataView = new DataView(this._deleteListDt, "", "", DataViewRowState.CurrentRows);
        }
        #endregion

        #region 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion 
        // ---- ADD caohh 2011/07/21 ----<<<<
    }
}
