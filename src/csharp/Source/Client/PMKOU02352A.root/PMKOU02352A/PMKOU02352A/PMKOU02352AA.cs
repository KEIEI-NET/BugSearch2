//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表アクセスクラス
// プログラム概要   : 入荷差異表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 入荷差異表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表で使用するデータを取得する</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class ArrGoodsDiffAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 入荷差異表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入荷差異表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        public ArrGoodsDiffAcs()
		{
            this.ArrGoodsDiffResultDB = (IArrGoodsDiffResultDB)MediationArrGoodsDiffResultDB.GetArrGoodsDiffResultDB();

            this.EnterpriseCd = LoginInfoAcquisition.EnterpriseCode;

            SPrtOutSet = null;                  // 帳票出力設定データクラス
            SPrtOutSetAcs = new PrtOutSetAcs(); // 帳票出力設定アクセスクラス
            this.UoeSndRcvJnlAccess = UoeSndRcvJnlAcs.GetInstance();
		}

		/// <summary>
		/// 入荷差異表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入荷差異表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public ArrGoodsDiffAcs(string param)
        {
            if (param.Equals("NUnit"))
            {
                //　なし
            }
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // 入荷差異表インタフェース
        private IArrGoodsDiffResultDB ArrGoodsDiffResultDB;

        // DataSetオブジェクト
        private DataSet ArrGoodsDiffDataSet;

        // 企業コード
        private string EnterpriseCd;

        // 帳票出力設定データクラス
        private static PrtOutSet SPrtOutSet;
        // 帳票出力設定アクセスクラス
        private static PrtOutSetAcs SPrtOutSetAcs;

        // 出力設定の読込失敗エラーメッセージ
        private const string SettingFail = "帳票出力設定の読込に失敗しました";

        private const string ErrorMessage = "入荷差異表の出力データの取得に失敗しました。";

        private UoeSndRcvJnlAcs UoeSndRcvJnlAccess;

        // ページ毎にデータ行数
        private const int RowCountPerPage = 50;

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this.ArrGoodsDiffDataSet; }
        }

        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return UoeSndRcvJnlAccess.uOESupplierAcs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 入荷差異表データ取得
        /// <summary>
        /// 入荷差異表データ取得
        /// </summary>
        /// <param name="arrGoodsDiffCndtnWork">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入荷差異表データを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        public int SearchArrGoodsDiffProcMain(ArrGoodsDiffCndtnWork arrGoodsDiffCndtnWork, out string errMsg)
        {
            return this.SearchArrGoodsDiffProc(arrGoodsDiffCndtnWork, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>出力設定取得結果</returns>
        /// <remarks>
        /// <br>Note       : 帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (SPrtOutSet != null)
                {
                    retPrtOutSet = SPrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = SPrtOutSetAcs.Read(out SPrtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = SPrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = SettingFail;
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
                WriteErrorLog(ex, "ArrGoodsDiffAcs.ReadPrtOutSet", status);
            }
            return status;
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="arrGoodsDiffCndtnWork">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入荷差異表データを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : K2019/08/14</br>
        /// </remarks>
        private int SearchArrGoodsDiffProc(ArrGoodsDiffCndtnWork arrGoodsDiffCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList arrGoodsDiffList = null;

            try
            {
                #region [入荷差異表検索]

                // DataTableを作成
                PMKOU02354EA.CreateDataTable(ref ArrGoodsDiffDataSet);

                // RクラスのSearchメソッドコール用に整形
                object retList = null;
                object paraWorkRef = arrGoodsDiffCndtnWork;

                // Searchメソッドコール
                status = ArrGoodsDiffResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        arrGoodsDiffList = (ArrayList)retList;
                        if (arrGoodsDiffList.Count <= 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        retList = null;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = ErrorMessage;
                        break;
                }

                #endregion

                #region [名称編集のためのデータ検索とDataSetへのデータ展開]

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    ConverToDataSet(ArrGoodsDiffDataSet.Tables[PMKOU02354EA.ct_Tbl_ArrGoodsDiffReportData], arrGoodsDiffList);
                }

                #endregion

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理

        #region ◎ 取得データ展開処理
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <remarks>
        /// <br>Note       : DataTableにデータを設定処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void ConverToDataSet(DataTable dataTable, ArrayList retList)
        {
            DataRow dr = null;
            ArrGoodsDiffResultWork rsltInfo = null;
            double difNum = 0;

            for (int cnt = 0; cnt < retList.Count; cnt++)
            {
                // 当該行
                rsltInfo = (ArrGoodsDiffResultWork)retList[cnt];

                difNum = rsltInfo.OrderCnt - rsltInfo.OrderRemainCnt - rsltInfo.InspectCnt;
                if (difNum == 0) continue;

                // 前行データ
                ArrGoodsDiffResultWork preArrGoodsDifWork = null;

                if (cnt > 0)
                {
                    preArrGoodsDifWork = retList[cnt - 1] as ArrGoodsDiffResultWork;
                }

                dr = dataTable.NewRow();

                // 発注先コード
                dr[PMKOU02354EA.ct_Col_UOESupplierCd] = SetGroupValue(0, cnt, rsltInfo, preArrGoodsDifWork);
                // 発注先名
                dr[PMKOU02354EA.ct_Col_UOESupplierNm] = SetGroupValue(1, cnt, rsltInfo, preArrGoodsDifWork);
                // 伝票番号
                dr[PMKOU02354EA.ct_Col_SupplierSlipNo] = SetGroupValue(2, cnt, rsltInfo, preArrGoodsDifWork);
                // 品番
                dr[PMKOU02354EA.ct_Col_GoodsNo] = rsltInfo.GoodsNo;
                // 品名
                dr[PMKOU02354EA.ct_Col_GoodsName] = rsltInfo.GoodsName;
                // メーカー
                dr[PMKOU02354EA.ct_Col_MakerName] = rsltInfo.MakerName;
                // 発注数
                dr[PMKOU02354EA.ct_Col_OrderCnt] = rsltInfo.OrderCnt;
                // 発注残
                dr[PMKOU02354EA.ct_Col_OrderRemainCnt] = rsltInfo.OrderRemainCnt;
                // 検品数
                dr[PMKOU02354EA.ct_Col_InspectCnt] = rsltInfo.InspectCnt;
                // 差異数
                dr[PMKOU02354EA.ct_Col_DiffCnt] = difNum;
                // 倉庫
                dr[PMKOU02354EA.ct_Col_WarehouseName] = rsltInfo.WarehouseName;
                // 発注者
                dr[PMKOU02354EA.ct_Col_StockAgentName] = rsltInfo.EmployeeName;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #region ◆ エラーログ出力処理
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">エラー内容</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note	   : エラーログ出力を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }
        #endregion ◆ エラーログ出力処理

        # region ◆ UOE発注先情報キャッシュ制御処理
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先名称</returns>
        /// <remarks>
        /// <br>Note	   : エラーログ出力を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public string GetName_FromUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);

            if (uOESupplier == null)
            {
                return "";
            }
            else
            {
                return uOESupplier.UOESupplierName;
            }
        }

        /// <summary>
        /// UOE発注先クラス取得
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先クラス</returns>
        /// <remarks>
        /// <br>Note	   : エラーログ出力を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        public UOESupplier GetUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = UoeSndRcvJnlAccess.SearchUOESupplier(uOESupplierCd);
            return (uOESupplier);
        }

        /// <summary>
        /// UOE発注先存在チェック
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : エラーログ出力を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        public bool UOESupplierExists(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);
            return (uOESupplier != null);
        }
        # endregion ◆ UOE発注先情報キャッシュ制御処理

        # region ◆ 前行と当前行値項目値比較処理
        /// <summary>
        /// 前行と当前行値項目値比較より設定処理
        /// </summary>
        /// <param name="mode">0:発注先コード 1:発注先名 2:伝票番号</param>
        /// <param name="rowNo">行数</param>
        /// <param name="currWork">当前行データ</param>
        /// <param name="prevWork">前行データ</param>
        /// <remarks>
        /// <br>Note       : 前行と当前行値項目値比較より設定処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public string SetGroupValue(int mode, int rowNo, ArrGoodsDiffResultWork currWork, ArrGoodsDiffResultWork prevWork)
        {
            string resultStr = string.Empty;

            switch (mode)
            {
                // 発注先コード
                case 0:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.UOESupplierCd != prevWork.UOESupplierCd))
                    {
                        resultStr = currWork.UOESupplierCd.ToString("000000");
                    }
                    break;
                // 発注先名
                case 1:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.UOESupplierCd != prevWork.UOESupplierCd))
                    {
                        resultStr = currWork.UOESupplierName.Trim();
                    }
                    break;
                // 伝票番号
                case 2:
                    if (rowNo % RowCountPerPage == 0 || (rowNo % RowCountPerPage != 0 && currWork.SupplierSlipNo != prevWork.SupplierSlipNo))
                    {
                        resultStr = currWork.SupplierSlipNo.ToString("000000000");
                    }
                    break;
                default:
                    // なし
                    break;
            }

            return resultStr;
        }
        # endregion ◆ 前行と当前行値項目値比較処理

        #endregion ■ Private Method
    }
}
