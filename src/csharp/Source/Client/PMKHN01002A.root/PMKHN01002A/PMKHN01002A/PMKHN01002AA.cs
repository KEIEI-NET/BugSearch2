//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// データクリア処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : データクリア処理です。<br />
    /// Programmer : 劉学智<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class DataClearAcs
    {
        #region ■ Constructor ■

        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMKHN01000UA";
        private const string PROGRAM_NAME = "データクリア処理";
        #endregion ■ Const Memebers ■

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DataClearAcs()
        {
            // 変数初期化
            this._dataSet = new DataClearDataSet();
            this._dataClearDataTable = this._dataSet.DataClear;
            this._iDataClearDB = MediationDataClearDB.GetDataClearDB();
			this._iDCControlDB = MediationDCControlDB.GetDCControlDB(); // ADD 2011.08.26
			this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();// ADD 2011.08.26
        }
        #endregion ■ Constructor ■

        #region ■ Properties ■
        /// <summary>
        /// データクリア処理データテーブルプロパティ
        /// </summary>
        public DataClearDataSet.DataClearDataTable DataClearDataTable
        {
            get { return _dataClearDataTable; }
        }
        #endregion ■ Properties ■

        #region ■ Private Members ■
        // データクリアデータセット
        private DataClearDataSet _dataSet;
        // データクリアデータテーブル
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;
        // 日付チェック用のアクセス
        private static DataClearAcs _dataClearInsts;
        // リモート用のクラス
        private IDataClearDB _iDataClearDB;
		private IDCControlDB _iDCControlDB; // ADD 2011.08.26
		private IMstDCControlDB _iMstDCControlDB; // ADD 2011.08.26
        #endregion ■ Private Members ■

        #region ■ データクリア処理アクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// データクリア処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>データクリア処理アクセスクラス インスタンス</returns>
        public static DataClearAcs GetInstance()
        {
            if (_dataClearInsts == null)
            {
                _dataClearInsts = new DataClearAcs();
            }

            return _dataClearInsts;
        }
        #endregion ■ データクリア処理アクセスクラス インスタンス取得処理 ■

        #region 選択・非選択状態処理(指定型)
        /// <summary>
        /// 選択・非選択状態処理(指定型)
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <param name="selected">true:選択,false:非選択</param>
        /// <remarks>
        /// <br>Note       : 選択・非選択状態処理を行います。</br>
        /// <br>Programmer : 2009</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public void SelectCheckbox(string _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this._dataClearDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this._dataClearDataTable.IsCheckedColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        #region 処理対象の選択チェック処理
        /// <summary>
        /// 処理対象の選択チェック処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 処理対象の選択チェック処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public bool IsGridDetailSelected()
        {
            bool isSelected = true;
            int count = 0;

            foreach (DataRow row in this._dataClearDataTable.Rows)
            {
                DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;
                dataRow.ClearResult = string.Empty;
            }

            try
            {
                DataView orderDataView = new DataView(this._dataClearDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this._dataClearDataTable.IsCheckedColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }

            if (count == this._dataClearDataTable.Rows.Count)
            {
                isSelected = false;
            }

            return isSelected;
        }
        #endregion 処理対象の選択チェック処理

        #region データクリア処理
        /// <summary>
        /// データクリア処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : データクリア処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>データクリア処理処理結果</returns>
        //public int DataClear(string enterpriseCode, Int32 delYM, Int32 delYMD, out string errMsg)//DEL by Liangsd     2011/09/06
        public int DataClear(string sectionCode, string enterpriseCode, Int32 delYM, Int32 delYMD, out string errMsg)//ADD by Liangsd    2011/09/06
        {
            ArrayList dataList = new ArrayList();
            errMsg = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ADD 2011.08.26 張莉莉 ---------->>>>>
			bool dcDataClearFlg = false;
			bool dcMustClearFlg = false;
		    int status1 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
		    int status2 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ADD 2011.08.26 張莉莉 ----------<<<<<
            try
            {
                foreach (DataRow row in this._dataClearDataTable.Rows)
                {
                    DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;

                    if (dataRow.IsChecked)
                    {
                        // リモート用のワークリスト作成
						//dataList.Add(CopyDataClearWork(dataRow)); // DEL 2011.08.26 張莉莉
						// ADD 2011.08.26 張莉莉 ---------->>>>>
						if (dataRow.TableId.Equals("DCDATAINFO"))
						{
							dcDataClearFlg = true;
						}
                        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                        //else if (dataRow.TableId.Equals("DCMUSTINFO"))
                        //{
                        //    dcMustClearFlg = true;
                        //}
                        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
						else
						{
							dataList.Add(CopyDataClearWork(dataRow));
						}
						// ADD 2011.08.26 張莉莉 ----------<<<<<
                    }
                }
                Object objDataClearList = dataList as object;

                // データクリア処理
                status = this._iDataClearDB.Clear(enterpriseCode, delYM, delYMD, ref objDataClearList, out errMsg);

                foreach (DataClearWork work in objDataClearList as ArrayList)
                {
                    DataRow _row = this._dataClearDataTable.Rows.Find(work.TableId);

                    // 一致する行が存在する！
                    if (_row != null)
                    {
                        string message = work.TableNm + " クリア処理 ";
                        OperationHistoryLog log = new OperationHistoryLog();
                        _row.BeginEdit();
                        if (work.Result.Equals("OK"))
                        {
                            message += "正常終了";
                            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "正常終了";
                        }
                        else
                        {
                            message += "エラー";
                            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "処理中にエラーが発生しました。";
                        }
                        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
                        _row.EndEdit();
                    }
                }

				// ADD 2011.08.26 張莉莉 ---------->>>>>
				// 拠点管理送受信データ（DC）clear
				if(dcDataClearFlg)
				{
                    status1 = this._iDCControlDB.DCDataClear(sectionCode,LoginInfoAcquisition.EnterpriseCode);

					DataRow _row = this._dataClearDataTable.Rows.Find("DCDATAINFO");
					// 一致する行が存在する！
					if (_row != null)
					{
						string message = "拠点管理送受信データ（DC）クリア処理 ";
						OperationHistoryLog log = new OperationHistoryLog();
						_row.BeginEdit();
						if (status1 == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							message += "正常終了";
							_row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "正常終了";
						}
						else
						{
							message += "エラー";
							_row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "処理中にエラーが発生しました。";
						}
						log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
						_row.EndEdit();
					}
				}

                #region DEL by Liangsd     2011/09/06
                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                // 拠点管理送受信マスタ（DC）clear
                //if (dcMustClearFlg)
                //{
                //    status1 = this._iMstDCControlDB.DCMSDataClear(LoginInfoAcquisition.EnterpriseCode);

                //    DataRow _row = this._dataClearDataTable.Rows.Find("DCMUSTINFO");
                //    // 一致する行が存在する！
                //    if (_row != null)
                //    {
                //        string message = "拠点管理送受信マスタ（DC）クリア処理 ";
                //        OperationHistoryLog log = new OperationHistoryLog();
                //        _row.BeginEdit();
                //        if (status1 == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                //        {
                //            message += "正常終了";
                //            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "正常終了";
                //        }
                //        else
                //        {
                //            message += "エラー";
                //            _row[this._dataClearDataTable.ClearResultColumn.ColumnName] = "処理中にエラーが発生しました。";
                //        }
                //        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, message, string.Empty);
                //        _row.EndEdit();
                //    }
                //}
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
                #endregion
                // ADD 2011.08.26 張莉莉 ----------<<<<<
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// データクリア処理
        /// </summary>
        /// <param name="dataRow">データ行情報</param>
        /// <remarks>
        /// <br>Note       : データクリア処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>データクリアワーク</returns>
        private DataClearWork CopyDataClearWork(DataClearDataSet.DataClearRow dataRow)
        {
            DataClearWork work = new DataClearWork();
            work.TableId = dataRow.TableId;
            work.TableNm = dataRow.TableNm;
            work.IsChecked = dataRow.IsChecked;
            work.ClearCode = dataRow.ClearCode;
            work.FileId = dataRow.FileId;

            return work;
        }
        #endregion データクリア処理

        #region ■ オフライン状態チェック処理 ■

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>判定結果</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion ■ オフライン状態チェック処理 ■

        //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
        /// <summary>
        /// 拠点管理送受信データ判定
        /// </summary>
        /// <returns></returns>
        public bool IsSelected()
        {
            bool flag = false;
            foreach (DataRow row in this._dataClearDataTable.Rows)
            {
                DataClearDataSet.DataClearRow dataRow = (DataClearDataSet.DataClearRow)row;

                if (dataRow.IsChecked)
                {
                    if (dataRow.TableId.Equals("DCDATAINFO"))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
    }
}
