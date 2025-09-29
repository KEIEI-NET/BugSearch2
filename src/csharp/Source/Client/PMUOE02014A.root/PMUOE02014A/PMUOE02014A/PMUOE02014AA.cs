using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 回線エラーリスト アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 回線エラーリストで使用するデータを取得する。</br>
    /// <br>Programmer   : 照田 貴志</br>
    /// <br>Date         : 2008/11/04</br>
	/// <br>Updatenote   : </br>
	/// <br>             : </br>
    /// </remarks>
	public class CircuitErrorListAcs
    {
        #region ■定数、変数、構造体
        // 変数
        private List<OrderSndRcvJnl> _CircuitErrorList = null;      // 回線エラーリスト　※送受信ジャーナル(発注)と同レイアウト
        private DataView _circuitErrorListDataView = null;	        // 印刷DataView
        private Hashtable _systemDivHTbl = null;                    // システム区分HashTable
        private Hashtable _dataSendHTbl = null;                     // 送信フラグHashTable

        // static
        private static PrtOutSet _prtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs _prtOutSetAcs;	                // 帳票出力設定アクセスクラス
        #endregion

        #region ■Constructor
        /// <summary>
		/// コンストラクタ
		/// </summary>
        /// <param name="circuitErrorList">回線エラーリスト</param>
		/// <remarks>
		/// <br>Note       : アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 照田 貴志</br>
	    /// <br>Date       : 2008/11/04</br>
		/// </remarks>
		public CircuitErrorListAcs(List<OrderSndRcvJnl> circuitErrorList)
		{
            // 回線エラーリスト用データ取得
            this._CircuitErrorList = circuitErrorList;

            // システム区分HashTable内容取得
            this._systemDivHTbl = new Hashtable();
            this._systemDivHTbl.Add(0, "手入力");
            this._systemDivHTbl.Add(1, "伝発");
            this._systemDivHTbl.Add(2, "検索");
            this._systemDivHTbl.Add(3, "在庫一括");

            // 送信フラグHashTable内容取得
            this._dataSendHTbl = new Hashtable();
            this._dataSendHTbl.Add(2, "未送信");
            this._dataSendHTbl.Add(3, "受信異常");

            // static
            _prtOutSet = null;					        // 帳票出力設定データクラス
            _prtOutSetAcs = new PrtOutSetAcs();	        // 帳票出力設定アクセスクラス
        }
        #endregion ■Constructor - end

        #region ■Public
        /// <summary> 印刷データセットプロパティ(読み取り専用) </summary>
		public DataView circuitErrorListDataView
		{
			get{ return this._circuitErrorListDataView; }
		}

        #region ▼SearchMain(データ取得)
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        public int SearchMain(out string errMsg)
        {
            return this.SearchProc(out errMsg);
        }
        #endregion

        #region ▼ReadPrtOutSet(帳票出力設定取得)
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (_prtOutSet != null)
                {
                    retPrtOutSet = _prtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = _prtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                retPrtOutSet = _prtOutSet.Clone();
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                break;
                            }
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
        #endregion ■Public - end

        #region ■Private
        #region ▼SearchProc(データ取得)
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private int SearchProc(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            if ((this._CircuitErrorList == null) ||
                (this._CircuitErrorList.Count == 0))
            {
                errMsg = "該当データがありません。";
                return status;
            }

            DataTable dataTable = null;
            PMUOE02013EA.CreateDataTable(ref dataTable);

            // データ取得
            foreach (OrderSndRcvJnl circuitError in this._CircuitErrorList)
            {
                DataRow dataRow = dataTable.NewRow();
                this.CopyToDataRowFromCircuitErrorList(circuitError,ref dataRow);

                dataTable.Rows.Add(dataRow);
            }

            // DataView作成
            string sortCondition = string.Format("{0},{1},{2}",PMUOE02013EA.ct_Col_UOESupplierCd,
                                                               PMUOE02013EA.ct_Col_OnlineNo,
                                                               PMUOE02013EA.ct_Col_OnlineRowNo);
            this._circuitErrorListDataView = new DataView(dataTable, "", sortCondition, DataViewRowState.CurrentRows);

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }
        #endregion

        #region ▼CopyToDataRowFromCircuitErrorList(回線エラーリスト→DataRowコピー)
        /// <summary>
        /// 回線エラーリスト→DataRow作成
        /// </summary>
        /// <param name="circuitError">回線エラーリスト</param>
        /// <param name="dataRow">コピー先</param>
        /// <remarks>
        /// <br>Note       : 回線エラーリストの内容を元にDataRowを作成する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private void CopyToDataRowFromCircuitErrorList(OrderSndRcvJnl circuitError, ref DataRow dataRow)
        {
            dataRow[PMUOE02013EA.ct_Col_UOESupplierCd] = circuitError.UOESupplierCd;            // UOE発注先コード
            dataRow[PMUOE02013EA.ct_Col_UOESupplierName] = circuitError.UOESupplierName;        // UOE発注先名称
            dataRow[PMUOE02013EA.ct_Col_OnlineNo] = circuitError.OnlineNo;                      // オンライン番号
            dataRow[PMUOE02013EA.ct_Col_GoodsNo] = circuitError.GoodsNo;                        // 商品番号
            dataRow[PMUOE02013EA.ct_Col_GoodsName] = circuitError.GoodsName;                    // 商品名称
            dataRow[PMUOE02013EA.ct_Col_GoodsMakerCd] = circuitError.GoodsMakerCd;              // 商品メーカーコード
            dataRow[PMUOE02013EA.ct_Col_AcceptAnOrderCnt] = circuitError.AcceptAnOrderCnt;      // 受注数量
            dataRow[PMUOE02013EA.ct_Col_BOCode] = circuitError.BoCode;                          // BO区分
            dataRow[PMUOE02013EA.ct_Col_UOERemark1] = circuitError.UoeRemark1;                  // UOEリマーク1

            // システム区分名称(タイトル)
            if (this._systemDivHTbl.ContainsKey(circuitError.SystemDivCd))
            {
                dataRow[PMUOE02013EA.ct_Col_SystemDivName] = this._systemDivHTbl[circuitError.SystemDivCd].ToString();
            }
            else
            {
                dataRow[PMUOE02013EA.ct_Col_SystemDivName] = string.Empty;
            }

            // 送信フラグ(エラー内容)
            if (this._dataSendHTbl.ContainsKey(circuitError.DataSendCode))
            {
                dataRow[PMUOE02013EA.ct_Col_ErrorContents] = this._dataSendHTbl[circuitError.DataSendCode].ToString();
            }
            else
            {
                dataRow[PMUOE02013EA.ct_Col_ErrorContents] = "例外発生";
            }
        }
        #endregion
        #endregion ■Private - end
	}
}
