using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート処理 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: コンバート処理 アクセス制御を行います。</br>
    /// <br>Programmer	: 30290</br>
    /// <br>Date		: 2008.09.22</br>
    /// <br>Update Note : 2011/09/06 李占川 連番991、Redmine#23658の対応</br>
    /// </remarks>
    public class ConvertProcAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IConvertProcessDB _IConvertProcessDB = null;

        // --- ADD 2011/09/06---------->>>>>
        private static readonly string PROGRAM_ID = "PMKHN08001A";
        private static readonly string PROGRAM_NAME = "PM7⇒PM.NSコンバート";
        // --- ADD 2011/09/06----------<<<<<
        # endregion

        # region ■Constracter
        /// <summary>
        /// コンバート処理 アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンバート処理アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2006.12.19</br>
        /// </remarks>
        public ConvertProcAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._IConvertProcessDB = (IConvertProcessDB)MediationConverProcessDB.GetConvertProcessDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._IConvertProcessDB = null;
            }
        }
        # endregion

        #region [ コンバート処理 ]
        /// <summary>
        /// トランザクションを開始します。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを開始します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int BeginTransaction()
        {
            return _IConvertProcessDB.BeginTransaction();
        }

        /// <summary>
        /// トランザクションを終了します。
        /// </summary>
        /// <param name="commitFlg">true : コミット　false : ロールバック</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを終了します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int EndTransaction(bool commitFlg)
        {
            return _IConvertProcessDB.EndTransaction(commitFlg);
        }

        /// <summary>
        /// コンバートデータをPM.NSのユーザーDBに展開します。
        /// </summary>
        /// <param name="tableID">対象のテーブルID</param>
        /// <param name="truncateFlg">削除フラグ</param>
        /// <param name="deployDataList">データのリスト(ArrayList)</param>
        /// <param name="updateCnt">アップデートデータカウント</param>
        /// <param name="errMsg"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : コンバートデータをPM.NSのユーザーDBに展開します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int DeployConvertData(string tableID, bool truncateFlg, ref ArrayList deployDataList, out int updateCnt, out string errMsg)
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバートデータをPM.NSのユーザーDBに展開開始", string.Empty);
            // --- ADD 2011/09/06----------<<<<<

            ConvertResultWork ret;
            ArrayList retList = new ArrayList();
            CustomSerializeArrayList list = new CustomSerializeArrayList();
            CustomSerializeArrayList errList = new CustomSerializeArrayList();
            //ArrayList errList = new ArrayList();
            list.Add(deployDataList);

            _IConvertProcessDB.StartProcess();
            int status = _IConvertProcessDB.DeployConvertData(tableID, truncateFlg, list, ref errList, out ret);
            updateCnt = ret.UpdateCnt;
            errMsg = ret.ErrMsg;
            if (ret.FailedRowCnt > 0 && errList.Count > 0)
            {
                for (int i = 0; i < errList.Count; i++)
                {
                    ErrorReportWork err = errList[i] as ErrorReportWork;
                    string failedQuery = string.Format("元データ [{0}]\r\n\t⇒エラーメッセージ [{1}]", err.ProcessingData, err.ErrMsg);
                    if (string.IsNullOrEmpty(failedQuery) == false)
                    {
                        retList.Add(failedQuery);
                    }
                }
            }
            deployDataList = retList;

            // --- ADD 2011/09/06---------->>>>>
            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバートデータをPM.NSのユーザーDBに展開終了", string.Empty);
            // --- ADD 2011/09/06----------<<<<<
            return status;
        }

        /// <summary>
        /// 在庫受払設定処理
        /// </summary>
        /// <param name="source">在庫受払設定元データ[0:売上/1:売上履歴/2:仕入/3:仕入履歴/4:在庫移動/5:在庫調整]</param>
        /// <returns></returns>
        public int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt)
        {
            int status = _IConvertProcessDB.SetStockAcPayHist(enterpriseCode, lstSource, out resultCnt);
            return status;
        }

        /// <summary>
        /// 処理中止
        /// </summary>        
        /// <returns></returns>
        public int StopProcess()
        {
            int status = _IConvertProcessDB.StopProcess();
            if (status == 0)
                _IConvertProcessDB.EndTransaction(false);
            return status;
        }
        #endregion
    }
}
