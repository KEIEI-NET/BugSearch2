//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタアクセスクラス
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日 2009/10/10   修正内容 : 障害報告Redmine#537の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日 2009/10/16   修正内容 : 障害報告Redmine#679の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日 2009/10/26   修正内容 : 障害報告Redmine#831,878の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 施ヘイ中
// 修 正 日 2010/12/22   修正内容 : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正
//----------------------------------------------------------------------------//
// 管理番号 10900269-00  作成担当 : FSI高橋 文彰
// 修 正 日 2013/03/22   修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2013/05/08  修正内容 : 全体初期表示設定の元号表示区分（年式）対応
//----------------------------------------------------------------------------//
// 管理番号  11070091-00 作成担当 : 譚洪
// 修 正 日  2014/08/01  修正内容 : 全体初期値設定マスタデータ取得障害を修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;  // ADD 2013/05/08 Y.Wakita

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車輌管理マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌管理マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : 張莉莉 2009.10.10</br>
    /// <br>            : 障害報告Redmine#537の修正</br>
    /// <br>Update Note : 張莉莉 2009.10.16</br>
    /// <br>            : 障害報告Redmine#679の修正</br>
    /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// </remarks>
    public class CarMngListInputAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■private変数
        private static CarMngListInputAcs _carMngInputAcs;

        private CarMngInputDataSet _carMngInputDataSet;
        private CarMngInputDataSet.CarInfoDataTable _carInfoDataTable;
        private DataTable _originalCarInfoDataTable;
        private DataTable _csvCarInfoDataTable;

        private ICarManagementDB _iCarManagementDB;

        private string _enterpriseCode;

        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        // ユーザーガイドマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;

        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, UserGdBd> _numberPlate1CodeDic;

        private CarMngInputAcs carMngInputAcs; // ADD 2013/05/08 Y.Wakita

        private int _index = 1;

        // 車輌管理区分
        Hashtable carMngDivHt = new Hashtable(); // ADD 2009/10/26
        # endregion

        // ===================================================================================== //
        // private定数
        // ===================================================================================== //
        # region ■private定数
        // 各種ステータス
        /// <summary>
        /// 行状態、正常
        /// </summary>
        public const int ROWSTATUS_NORMAL = 0;
        /// <summary>
        /// 行状態、コピー
        /// </summary>
        public const int ROWSTATUS_COPY = 1;

        /// <summary>
        /// 行正常
        /// </summary>
        public const int DELETE_FLAG0 = 0;

        /// <summary>
        /// 行論理削除
        /// </summary>
        public const int DELETE_FLAG1 = 1;
        /// <summary>
        /// 新規行
        /// </summary>
        public const string ROWNO_NEW = "新規";

        // --- ADD 2009/10/26 ----->>>>>
        /// <summary>
        /// 保存可能行
        /// </summary>
        public const int SAVECAN_FLAG0 = 0;
        /// <summary>
        /// 保存不可行
        /// </summary>
        public const int SAVECAN_FLAG1 = 1;
        // --- ADD 2009/10/26 -----<<<<<

        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■publicプロパティ
        /// <summary>
        /// 車輌管理マスタテーブルプロパティ
        /// </summary>
        public CarMngInputDataSet.CarInfoDataTable CarInfoDataTable
        {
            get { return _carInfoDataTable; }
        }

        /// <summary>
        /// 検索時の商品在庫データテーブルプロパティ
        /// </summary>
        public DataTable OriginalCarInfoDataTable
        {
            get { return _originalCarInfoDataTable; }
        }

        /// <summary>
        /// 得意先検索マスタプロパティ
        /// </summary>
        public Dictionary<int, CustomerSearchRet> CustomerSearchRetDic
        {
            get { return _customerSearchRetDic; }
        }

        /// <summary>
        /// 陸運事務所番号プロパティ
        /// </summary>
        public Dictionary<int, UserGdBd> NumberPlate1CodeDic
        {
            get { return _numberPlate1CodeDic; }
        }
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■コンストラクタ
        /// <summary>
        /// 車輌管理マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngListInputAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._carMngInputDataSet = new CarMngInputDataSet();
            this._carInfoDataTable = this._carMngInputDataSet.CarInfo;
            this._originalCarInfoDataTable = this._carInfoDataTable.Clone();
            this._csvCarInfoDataTable = new DataTable();

            this._carInfoDataTable.CaseSensitive = true;
            this._originalCarInfoDataTable.CaseSensitive = true;
            this._csvCarInfoDataTable.CaseSensitive = true;

            this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._userGuideAcs = new UserGuideAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            this.LoadCustomerSearchRet();
            this.LoadNumberPlate1Code();
        }

        /// <summary>
        /// 車輌管理マスタアクセスクラスのインスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタテーブルアクセスクラスのインスタンスを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public static CarMngListInputAcs GetInstance()
        {
            if (_carMngInputAcs == null)
            {
                _carMngInputAcs = new CarMngListInputAcs();
            }

            return _carMngInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■publicメソッド
        #region ■ 検索処理
        /// <summary>
        /// 車両管理マスタ情報を検索します。
        /// </summary>
        /// <param name="extractInfo">検索条件</param>
        /// <param name="errMsg">エラーmessage</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車両管理マスタ情報を検索します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Search(CarManagementExtractInfo extractInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // 検索データクリア
            this._carInfoDataTable.Clear();
            this._originalCarInfoDataTable.Clear();
            this._csvCarInfoDataTable.Clear();

            try
            {
                // 検索条件
                CarManagementWork carManagementObj = this.CopyToCarManagementWorkFromExtractInfo(extractInfo);
                carManagementObj.EnterpriseCode = extractInfo.EnterpriseCode;
                carManagementObj.LogicalDeleteCode = 1;

                // 検索結果
                ArrayList carManagementList = new ArrayList();
                object objCarManagementList = (object)carManagementList;

                // 検索
                status = this._iCarManagementDB.Search(ref objCarManagementList, carManagementObj, 0, ConstantManagement.LogicalMode.GetData01);

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCarManagementList as ArrayList;
                    
                    // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
                    // 全体初期値設定マスタ
                    carMngInputAcs = new CarMngInputAcs();

                    this.carMngInputAcs.ReadInitData(this._enterpriseCode, "00");
                    // --- ADD 2013/05/08 Y.Wakita ----------<<<<<
                    
                    this._index = 1;
                    foreach (CarManagementWork work in resultList)
                    {
                        CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.NewCarInfoRow();
                        row = this.CopyToRowFromCarManagementWork(work);

                        // RowNoの処理
                        if (row["DeleteDate"] != DBNull.Value)
                        {
                            // 論理削除したデータ
                            row.RowNo = "-";
                        }
                        else
                        {
                            // 正常データ
                            row.RowNo = Convert.ToString(this._index);
                            this._index++;
                        }

                        this._carInfoDataTable.AddCarInfoRow(row);
                    }

                    this._originalCarInfoDataTable = this._carInfoDataTable.Copy();
                    this._csvCarInfoDataTable = this._carInfoDataTable.Copy();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                // 結果ない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this._carInfoDataTable.Clear();
                    this._originalCarInfoDataTable.Clear();
                    this._csvCarInfoDataTable.Clear();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                // その他エラー場合
                else
                {
                    this._carInfoDataTable.Clear();
                    this._originalCarInfoDataTable.Clear();
                    this._csvCarInfoDataTable.Clear();
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region ■ 保存処理
        /// <summary>
        /// 車両管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="msg">message</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementList に格納されている車両管理マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Write(out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = string.Empty;

            try
            {
                CustomSerializeArrayList carManagementList = new CustomSerializeArrayList();
                CustomSerializeArrayList updateDataList = new CustomSerializeArrayList();
                CustomSerializeArrayList logicDeleteDataList = new CustomSerializeArrayList();

                // 車両管理マスタ情報の更新データの取込処理
                status = this.GetDataListFromGoodsStockDataTable(out updateDataList, out logicDeleteDataList);

                // 取込正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    carManagementList.Add(updateDataList);
                    carManagementList.Add(logicDeleteDataList);

                    object carManagementListObj = (object)carManagementList;
                    // 書込と論理削除処理。
                    status = this._iCarManagementDB.WriteAndLogicDelete(ref carManagementListObj);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 車両管理マスタ情報の更新データの取込処理。
        /// </summary>
        /// <param name="logicDeleteDataList">更新データ</param>
        /// <param name="updateDataList">削除データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車両管理マスタ情報の更新データを取込します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private int GetDataListFromGoodsStockDataTable(out CustomSerializeArrayList updateDataList, out CustomSerializeArrayList logicDeleteDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            updateDataList = new CustomSerializeArrayList();
            logicDeleteDataList = new CustomSerializeArrayList();

            try
            {
                // 新規行
                CarMngInputDataSet.CarInfoRow[] newRows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowNoColumn.ColumnName + " = '" + ROWNO_NEW + "'");
                
                if ((newRows != null) && (newRows.Length > 0))
                {
                    foreach (CarMngInputDataSet.CarInfoRow row in newRows)
                    {
                        updateDataList.Add(this.CopyToCarManagementWorkFromRow(row));
                    }
                }

                // 修正行
                foreach (DataRow row in this._originalCarInfoDataTable.Rows)
                {
                    Guid key = (Guid)row[this._carInfoDataTable.CarRelationGuidColumn.ColumnName];
                    CarMngInputDataSet.CarInfoRow ultraRow = this._carInfoDataTable.FindByCarRelationGuid(key);

                    if (ultraRow == null)
                    {
                        continue;
                    }
                    for (int j = 8; j < this._carInfoDataTable.Columns.Count; j++)
                    {
                        if (ultraRow[j].ToString() != row[j].ToString())
                        {
                            updateDataList.Add(this.CopyToCarManagementWorkFromRow(ultraRow));
                            break;
                        }
                    }
                }

                // 論理削除行
                CarMngInputDataSet.CarInfoRow[] logicRows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.DeleteFlagColumn.ColumnName + " = " + DELETE_FLAG1.ToString());
                if ((logicRows != null) && (logicRows.Length > 0))
                {
                    foreach (CarMngInputDataSet.CarInfoRow row in logicRows)
                    {
                        logicDeleteDataList.Add(this.CopyToCarManagementWorkFromRow(row));
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region ■ その他処理
        /// <summary>
        /// 明細データテーブルCarInfoRow列初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細データテーブルCarInfoRow列初期化処理します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InitializeCarInfoRowNoColumn()
        {
            this._carInfoDataTable.BeginLoadData();
            for (int i = 0; i < this._carInfoDataTable.Rows.Count; i++)
            {
                this._carInfoDataTable[i].RowNo = Convert.ToString(i + 1);
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細データテーブルRowStatus列初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細データテーブルRowStatus列初期化処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InitializeCarInfoRowStatusColumn()
        {
            CarMngInputDataSet.CarInfoRow[] rows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowStatusColumn.ColumnName + " <> " + ROWSTATUS_NORMAL.ToString());

            this._carInfoDataTable.BeginLoadData();
            foreach (CarMngInputDataSet.CarInfoRow row in rows)
            {
                row.RowStatus = ROWSTATUS_NORMAL;
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細データテーブルRowStatus列値設定処理
        /// </summary>
        /// <param name="rowIndexList">明細行番号リスト</param>
        /// <param name="rowStatus">RowStatus値</param>
        /// <remarks>
        /// <br>Note       : 明細データテーブルRowStatus列値設定処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SetCarInfoRowStatusColumn(List<Guid> rowIndexList, int rowStatus)
        {
            this._carInfoDataTable.BeginLoadData();
            foreach (Guid key in rowIndexList)
            {
                CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(key);

                //if (row.RowStatus == ROWSTATUS_LOGICDELETE)
                //{
                //    continue;
                //}

                row.RowStatus = rowStatus;
            }
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// コピー明細行番号取得処理
        /// </summary>
        /// <returns>行番号リスト</returns>
        /// <remarks>
        /// <br>Note       : コピー明細行番号取得処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public List<Guid> GetCopyCarInfoRowNo()
        {
            CarMngInputDataSet.CarInfoRow[] rows = (CarMngInputDataSet.CarInfoRow[])this._carInfoDataTable.Select(this._carInfoDataTable.RowStatusColumn.ColumnName + " = " + ROWSTATUS_COPY.ToString());

            if ((rows != null) && (rows.Length > 0))
            {
                List<Guid> carInfoRowNoList = new List<Guid>();
                foreach (CarMngInputDataSet.CarInfoRow row in rows)
                {
                    carInfoRowNoList.Add(row.CarRelationGuid);
                }

                return carInfoRowNoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 明細行貼り付け処理
        /// </summary>
        /// <param name="copyCarInfoRowNoList">コピー元行番号リスト</param>
        /// <remarks>
        /// <br>Note       : 明細行貼り付け処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void PasteInsertCarInfoRow(List<Guid> copyCarInfoRowNoList)
        {
            foreach (Guid key in copyCarInfoRowNoList)
            {
                CarMngInputDataSet.CarInfoRow sourceRow = this._carInfoDataTable.FindByCarRelationGuid(key);
                CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.NewCarInfoRow();
                
                this.CopyCarInfoRow(sourceRow, targetRow);

                // 「得意先コード」は「空白」とする。
                targetRow.SaveCanFlag = SAVECAN_FLAG1;  // 2009/10/26 ADD
                targetRow.CarRelationGuid = Guid.NewGuid();
                targetRow.UpdateDateTime = DateTime.MinValue;
                targetRow.LogicalDeleteCode = 0;
                targetRow.CustomerCode = string.Empty;
                targetRow.CarMngNo = "0";

                this._carInfoDataTable.AddCarInfoRow(targetRow);
            }
        }

        /// <summary>
        /// 行ADD処理
        /// </summary>
        /// <param name="sourceRow">コピー元行</param>
        /// <remarks>
        /// <br>Note       : 明細行貼り付け処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void InsertCarInfoRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._carInfoDataTable.BeginLoadData(); 
            this._originalCarInfoDataTable.BeginLoadData();

            CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.NewCarInfoRow();

            this.CopyCarInfoRow(sourceRow, targetRow);

            targetRow.CarRelationGuid = Guid.NewGuid();
            // No
            // --- ADD 2009/10/16 ------>>>>>
            if (this._carInfoDataTable.Count == 0)
            {
                this._index = 1;
            }
            // --- ADD 2009/10/16 ------<<<<<
            targetRow.RowNo = Convert.ToString(this._index++);

            this._carInfoDataTable.AddCarInfoRow(targetRow);

            this._originalCarInfoDataTable.ImportRow(targetRow);

            this._carInfoDataTable.EndLoadData();
            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 行UPDATE処理
        /// </summary>
        /// <param name="sourceRow">CarInfoRow行</param>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタ（データ入力）の保存場合、この処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void UpdateOriginalRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._originalCarInfoDataTable.BeginLoadData();

            DataRow row = this._originalCarInfoDataTable.Rows.Find(sourceRow.CarRelationGuid);

            if (row == null) return;

            for (int j = 0; j < this._originalCarInfoDataTable.Columns.Count; j++)
            {
                row[j] = sourceRow[j];
            }

            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 行DELETE処理
        /// </summary>
        /// <param name="sourceRow">CarInfoRow行</param>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタ（データ入力）の完全削除場合、この処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void DeleteOriginalTableRow(CarMngInputDataSet.CarInfoRow sourceRow)
        {
            this._originalCarInfoDataTable.BeginLoadData();

            DataRow row = this._originalCarInfoDataTable.Rows.Find(sourceRow.CarRelationGuid);

            if (row == null) return;
            this._originalCarInfoDataTable.Rows.Remove(row);

            this._originalCarInfoDataTable.AcceptChanges();
            this._originalCarInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細行削除処理
        /// </summary>
        /// <param name="carInfoRowNoList">削除行StockRowNoリスト</param>
        /// <remarks>
        /// <br>Note       : 明細行削除処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void DeleteCarInfoRow(List<Guid> carInfoRowNoList)
        {
            this._carInfoDataTable.BeginLoadData();
            foreach (Guid key in carInfoRowNoList)
            {
                CarMngInputDataSet.CarInfoRow targetRow = this._carInfoDataTable.FindByCarRelationGuid(key);
                if (targetRow == null) continue;

                if (targetRow[this._carInfoDataTable.RowNoColumn.ColumnName].ToString() == ROWNO_NEW)
                {
                    // 追加行の場合、削除する
                    this._carInfoDataTable.RemoveCarInfoRow(targetRow);
                    continue;
                }
                else
                {
                    targetRow.DeleteFlag = DELETE_FLAG1;
                }
            }

            // 明細データテーブルRowNo列初期化処理
            //this.InitializeCarInfoRowNoColumn();
            this._carInfoDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細コピー行処理
        /// </summary>
        /// <param name="sourceRow">コピー行From</param>
        /// <param name="targetRow">コピー行To</param>
        /// <remarks>
        /// <br>Note       : 明細コピー行処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>update Note  : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正</br>
        /// <br>             　施ヘイ中</br>
        /// <br>Date       　: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        public void CopyCarInfoRow(CarMngInputDataSet.CarInfoRow sourceRow, CarMngInputDataSet.CarInfoRow targetRow)
        {
            //targetRow.CarRelationGuid = sourceRow.CarRelationGuid;
            targetRow.FileHeaderGuid = sourceRow.FileHeaderGuid;
            targetRow.CreateDateTime = sourceRow.CreateDateTime;
            targetRow.UpdateDateTime = sourceRow.UpdateDateTime;

            targetRow.RowStatus = ROWSTATUS_NORMAL;
            targetRow.DeleteFlag = DELETE_FLAG0;
            targetRow.SaveCanFlag = sourceRow.SaveCanFlag; // 2009/10/26 ADD

            targetRow.LogicalDeleteCode = sourceRow.LogicalDeleteCode;
            targetRow.CustomerCode = this.StrPadLeft0(sourceRow.CustomerCode, 8);
            targetRow.CarMngNo = sourceRow.CarMngNo;
            targetRow.CarMngCode = sourceRow.CarMngCode;
            targetRow.NumberPlate1Code = this.StrPadLeft0(sourceRow.NumberPlate1Code, 4);
            // ----ADD 2009/10/10 ------>>>>>
            if (sourceRow.NumberPlate1Name.Length > 4)
            {
                targetRow.NumberPlate1Name = sourceRow.NumberPlate1Name.Substring(0, 4);
            }
            else
            {
                targetRow.NumberPlate1Name = sourceRow.NumberPlate1Name;
            }
            // ----ADD 2009/10/10 ------<<<<<
            targetRow.NumberPlate2 = sourceRow.NumberPlate2;
            targetRow.NumberPlate3 = sourceRow.NumberPlate3;
            targetRow.NumberPlate4 = sourceRow.NumberPlate4;

            if (sourceRow[this._carInfoDataTable.EntryDateColumn.ColumnName] != DBNull.Value
                && sourceRow.EntryDate != string.Empty)
            {
                targetRow.EntryDate = sourceRow.EntryDate;
            }

            if (sourceRow[this._carInfoDataTable.FirstEntryDateColumn.ColumnName] != DBNull.Value
                //&& sourceRow.FirstEntryDate != DateTime.MinValue)
                && sourceRow.FirstEntryDate != string.Empty)  // ADD 2009/10/10
            {
                targetRow.FirstEntryDate = sourceRow.FirstEntryDate;
            }
            targetRow.MakerCode = sourceRow.MakerCode;
            targetRow.MakerFullName = sourceRow.MakerFullName;
            targetRow.MakerHalfName = sourceRow.MakerHalfName;
            targetRow.ModelCode = sourceRow.ModelCode;
            targetRow.ModelSubCode = sourceRow.ModelSubCode;
            targetRow.ModelFullName = sourceRow.ModelFullName;
            targetRow.ModelHalfName = sourceRow.ModelHalfName;
            targetRow.SystematicCode = sourceRow.SystematicCode;
            targetRow.SystematicName = sourceRow.SystematicName;
            targetRow.ProduceTypeOfYearCd = sourceRow.ProduceTypeOfYearCd;
            targetRow.ProduceTypeOfYearNm = sourceRow.ProduceTypeOfYearNm;
            targetRow.StProduceTypeOfYear = sourceRow.StProduceTypeOfYear;
            targetRow.EdProduceTypeOfYear = sourceRow.EdProduceTypeOfYear;
            targetRow.DoorCount = sourceRow.DoorCount;
            targetRow.BodyNameCode = sourceRow.BodyNameCode;
            targetRow.BodyName = sourceRow.BodyName;
            targetRow.ExhaustGasSign = sourceRow.ExhaustGasSign;
            targetRow.SeriesModel = sourceRow.SeriesModel;
            targetRow.CategorySignModel = sourceRow.CategorySignModel;
            targetRow.FullModel = sourceRow.FullModel;
            targetRow.ModelDesignationNo = this.StrPadLeft0(sourceRow.ModelDesignationNo, 5);
            targetRow.CategoryNo = this.StrPadLeft0(sourceRow.CategoryNo, 4);
            targetRow.FrameModel = sourceRow.FrameModel;
            targetRow.FrameNo = sourceRow.FrameNo;
            targetRow.SearchFrameNo = sourceRow.SearchFrameNo;
            targetRow.StProduceFrameNo = sourceRow.StProduceFrameNo;
            targetRow.EdProduceFrameNo = sourceRow.EdProduceFrameNo;
            targetRow.EngineModel = sourceRow.EngineModel;
            targetRow.ModelGradeNm = sourceRow.ModelGradeNm;
            targetRow.EngineModelNm = sourceRow.EngineModelNm;
            targetRow.EngineDisplaceNm = sourceRow.EngineDisplaceNm;
            targetRow.EDivNm = sourceRow.EDivNm;
            targetRow.TransmissionNm = sourceRow.TransmissionNm;
            targetRow.ShiftNm = sourceRow.ShiftNm;
            targetRow.WheelDriveMethodNm = sourceRow.WheelDriveMethodNm;
            targetRow.AddiCarSpec1 = sourceRow.AddiCarSpec1;
            targetRow.AddiCarSpec2 = sourceRow.AddiCarSpec2;
            targetRow.AddiCarSpec3 = sourceRow.AddiCarSpec3;
            targetRow.AddiCarSpec4 = sourceRow.AddiCarSpec4;
            targetRow.AddiCarSpec5 = sourceRow.AddiCarSpec5;
            targetRow.AddiCarSpec6 = sourceRow.AddiCarSpec6;
            targetRow.AddiCarSpecTitle1 = sourceRow.AddiCarSpecTitle1;
            targetRow.AddiCarSpecTitle2 = sourceRow.AddiCarSpecTitle2;
            targetRow.AddiCarSpecTitle3 = sourceRow.AddiCarSpecTitle3;
            targetRow.AddiCarSpecTitle4 = sourceRow.AddiCarSpecTitle4;
            targetRow.AddiCarSpecTitle5 = sourceRow.AddiCarSpecTitle5;
            targetRow.AddiCarSpecTitle6 = sourceRow.AddiCarSpecTitle6;
            targetRow.RelevanceModel = sourceRow.RelevanceModel;
            targetRow.SubCarNmCd = sourceRow.SubCarNmCd;
            targetRow.ModelGradeSname = sourceRow.ModelGradeSname;
            targetRow.BlockIllustrationCd = sourceRow.BlockIllustrationCd;
            targetRow.ThreeDIllustNo = sourceRow.ThreeDIllustNo;
            targetRow.PartsDataOfferFlag = sourceRow.PartsDataOfferFlag;
            if (sourceRow[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName] != DBNull.Value
                && sourceRow.InspectMaturityDate != string.Empty)
            {
                targetRow.InspectMaturityDate = sourceRow.InspectMaturityDate;
            }
            if (sourceRow[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName] != DBNull.Value
                && sourceRow.LTimeCiMatDate != string.Empty)
            {
                targetRow.LTimeCiMatDate = sourceRow.LTimeCiMatDate;
            }
            targetRow.CarInspectYear = sourceRow.CarInspectYear;
            targetRow.Mileage = sourceRow.Mileage;
            targetRow.CarNo = sourceRow.CarNo;
            targetRow.ColorCode = sourceRow.ColorCode;
            targetRow.ColorName1 = sourceRow.ColorName1;
            targetRow.TrimCode = sourceRow.TrimCode;
            targetRow.TrimName = sourceRow.TrimName;
            targetRow.FullModelFixedNoAry = sourceRow.FullModelFixedNoAry;
            targetRow.CategoryObjAry = sourceRow.CategoryObjAry;
            targetRow.CarAddInfo1 = sourceRow.CarAddInfo1;
            targetRow.CarAddInfo2 = sourceRow.CarAddInfo2;
            targetRow.CarNote = sourceRow.CarNote;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == sourceRow.FreeSrchMdlFxdNoAry || sourceRow.FreeSrchMdlFxdNoAry.Length == 0)
            {
                targetRow.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                targetRow.FreeSrchMdlFxdNoAry = sourceRow.FreeSrchMdlFxdNoAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            // ADD 2013/03/22 -------------------->>>>>
            targetRow.DomesticForeignCode = sourceRow.DomesticForeignCode;  // 国産/外車区分
            targetRow.HandleInfoCode = sourceRow.HandleInfoCode;  // ハンドル位置情報
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        /// ﾃｷｽﾄ出力のデータ処理
        /// </summary>
        /// <param name="table">出力のデータ</param>
        /// <remarks>
        /// <br>Note       : ﾃｷｽﾄ出力のデータ処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void GetTextOutData(out DataTable table)
        {
            table = this.CreateColumn();
            DataTable table2 = new DataTable();

            // 車輌管理マスタ.論理削除区分＝0のデータを出力対象とする。
            string filer = this._carInfoDataTable.LogicalDeleteCodeColumn.ColumnName + " = 0";

            // 車輌管理マスタ.論理削除区分＝0のデータを出力対象とする。
            DataView dv = this._csvCarInfoDataTable.DefaultView;
            dv.RowFilter = filer;
            // ソート順序
            dv.Sort = "CustomerCode, CarMngCode, CarMngNo";

            table2 = dv.ToTable();

            foreach (DataRow row2 in table2.Rows)
            {
                DataRow row = table.NewRow();

                // 得意先コード
                row["CustomerCode"] = this.StrPadLeft0(row2["CustomerCode"].ToString(), 8);
                row["CarMngCode"] = row2["CarMngCode"];                         // 管理番号
                // 型式指定番号  
                row["ModelDesignationNo"] = this.StrPadLeft0(row2["ModelDesignationNo"].ToString(), 5);
                // 類別番号
                row["CategoryNo"] = this.StrPadLeft0(row2["CategoryNo"].ToString(), 4);
                row["EngineModelNm"] = row2["EngineModelNm"];                   // エンジン型式
                // メーカーコード
                row["MakerCode"] = this.StrPadLeft0(row2["MakerCode"].ToString(), 3);
                // 車種コード
                row["ModelCode"] = this.StrPadLeft0(row2["ModelCode"].ToString(), 3);
                // 呼称コード         
                row["ModelSubCode"] = this.StrPadLeft0(row2["ModelSubCode"].ToString(), 3);
                row["ModelFullName"] = row2["ModelFullName"];                   // 車種名称
                row["FullModel"] = row2["FullModel"];                           // 型式
                // 年度
                if (row2["FirstEntryDate"] != DBNull.Value && !string.Empty.Equals(row2["FirstEntryDate"].ToString()))  // UPD 2009/10/10
                {
                    // ---UPD 2009/10/10 ----->>>>>
                    try
                    {
                        DateTime time = DateTime.Parse(row2["FirstEntryDate"].ToString());
                        // --- UPD 2013/05/08 Y.Wakita ---------->>>>>
                        //row["FirstEntryDate"] = time.ToString("yyyyMM");
                        string firstEntryDateEStr = row2["FirstEntryDate"].ToString().Substring(row2["FirstEntryDate"].ToString().Length - 1, 1);
                        if (firstEntryDateEStr == "年")
                            row["FirstEntryDate"] = time.ToString("yyyy");
                        else
                            row["FirstEntryDate"] = time.ToString("yyyyMM");
                        // --- UPD 2013/05/08 Y.Wakita ----------<<<<<
                    }
                    catch
                    {
                        row["FirstEntryDate"] = row2["FirstEntryDate"].ToString().Substring(0,4);
                    }
                    // ---UPD 2009/10/10 -----<<<<<
                }
                row["FrameNo"] = row2["FrameNo"];                               // 車台番号
                row["ColorCode"] = row2["ColorCode"];                           // カラーコード
                row["ColorName1"] = row2["ColorName1"];                         // カラー名称1
                row["TrimCode"] = row2["TrimCode"];                             // トリムコード
                row["TrimName"] = row2["TrimName"];                             // トリム名称
                row["EngineModel"] = row2["EngineModel"];                       // 原動機型式
                row["CarAddInfo1"] = row2["CarAddInfo1"];                       // 追加情報１
                row["CarAddInfo2"] = row2["CarAddInfo2"];                       // 追加情報２
                // 陸運事務所番号
                row["NumberPlate1Code"] = this.StrPadLeft0(row2["NumberPlate1Code"].ToString(), 4);
                row["NumberPlate1Name"] = row2["NumberPlate1Name"];             // 陸運事務所名称
                row["NumberPlate2"] = row2["NumberPlate2"];                     // 車両登録番号（種別）
                row["NumberPlate3"] = row2["NumberPlate3"];                     // 車両登録番号（カナ）
                row["NumberPlate4"] = row2["NumberPlate4"];                     // 車両登録番号（プレート番号）
                //row["Mileage"] = row2["Mileage"];
                row["Mileage"] = string.Format("{0:##,##0}",row2["Mileage"]);    // 走行距離 // ADD 2009/10/10
                

                
                // 登録年月日
                if (row2["EntryDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["EntryDate"].ToString());
                    row["EntryDate"] = time.ToString("yyyyMMdd");
                }

                // 前回車検日
                if (row2["LTimeCiMatDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["LTimeCiMatDate"].ToString());
                    row["LTimeCiMatDate"] = time.ToString("yyyyMMdd");
                }

                // 次回車検日
                if (row2["InspectMaturityDate"] != DBNull.Value)
                {
                    DateTime time = DateTime.Parse(row2["InspectMaturityDate"].ToString());
                    row["InspectMaturityDate"] = time.ToString("yyyyMMdd");
                }
                // 車検期間
                row["CarInspectYear"] = this.StrPadLeft0(row2["CarInspectYear"].ToString(), 2);
                row["CarNote"] = row2["CarNote"];                               // 備考
                row["CarMngDivName"] = row2["CarMngDivName"];                   // 車輌管理区分

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// グリッド列作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列を作成します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public DataTable CreateColumn()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CustomerCode", typeof(string));
            dataTable.Columns.Add("CarMngCode", typeof(string));
            dataTable.Columns.Add("ModelDesignationNo", typeof(string));
            dataTable.Columns.Add("CategoryNo", typeof(string));
            dataTable.Columns.Add("EngineModelNm", typeof(string));
            dataTable.Columns.Add("MakerCode", typeof(string));
            dataTable.Columns.Add("ModelCode", typeof(string));
            dataTable.Columns.Add("ModelSubCode", typeof(string));
            dataTable.Columns.Add("ModelFullName", typeof(string));
            dataTable.Columns.Add("FullModel", typeof(string));
            dataTable.Columns.Add("FirstEntryDate", typeof(string));
            dataTable.Columns.Add("FrameNo", typeof(string));
            dataTable.Columns.Add("ColorCode", typeof(string));
            dataTable.Columns.Add("ColorName1", typeof(string));
            dataTable.Columns.Add("TrimCode", typeof(string));
            dataTable.Columns.Add("TrimName", typeof(string));
            dataTable.Columns.Add("EngineModel", typeof(string));
            dataTable.Columns.Add("CarAddInfo1", typeof(string));
            dataTable.Columns.Add("CarAddInfo2", typeof(string));
            dataTable.Columns.Add("NumberPlate1Code", typeof(string));
            dataTable.Columns.Add("NumberPlate1Name", typeof(string));
            dataTable.Columns.Add("NumberPlate2", typeof(string));
            dataTable.Columns.Add("NumberPlate3", typeof(string));
            dataTable.Columns.Add("NumberPlate4", typeof(string));
            dataTable.Columns.Add("Mileage", typeof(string));
            dataTable.Columns.Add("EntryDate", typeof(string));
            dataTable.Columns.Add("LTimeCiMatDate", typeof(string));
            dataTable.Columns.Add("InspectMaturityDate", typeof(string));
            dataTable.Columns.Add("CarInspectYear", typeof(string));
            dataTable.Columns.Add("CarNote", typeof(string));
            dataTable.Columns.Add("CarMngDivName", typeof(string));

            return dataTable;
        }

        /// <summary>
        /// 得意先コードより、得意先マスタのデータの取込
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerInfo">結果</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタのデータの取込を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int GetCustomerInfo(int customerCode, string enterpriseCode, out CustomerInfo customerInfo)
        {
            int status = 0;
            status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, false, out customerInfo);
            return status;
        }
        #endregion

        #region ■ セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
                {
                    return 0;
                }

                return int.Parse((string)cellValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public string IntObjToStr(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || ((int)cellValue == 0))
                {
                    return string.Empty;
                }

                return cellValue.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// stringセル値変換処理(フォント)
        /// </summary>
        /// <param name="s">string値</param>
        /// <param name="number">number</param>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/09/10</br>
        /// </remarks>
        public string StrPadLeft0(string s, int number)
        {
            if (s == string.Empty || s == "0")
            {
                return string.Empty;
            }

            return s.Trim().PadLeft(number, '0');
        }
        #endregion
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■privateメソッド
        /// <summary>
        /// 得意先検索マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先検索マスタ読込処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// 陸運事務所番号読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 陸運事務所番号一覧を読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void LoadNumberPlate1Code()
        {
            this._numberPlate1CodeDic = new Dictionary<int, UserGdBd>();

            ArrayList retList = new ArrayList();

            try
            {
                // ユーザーガイドデータ取得(陸運事務所番号)
                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                 80, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._numberPlate1CodeDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            catch
            {
                this._numberPlate1CodeDic = new Dictionary<int, UserGdBd>();
            }

            return;
        }

        /// <summary>
        /// クラスメンバーコピー処理（車輌管理マスタRow⇒車輌管理マスタワーククラス）
        /// </summary>
        /// <param name="extractInfo">車輌管理マスタRow</param>
        /// <returns>車輌管理マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタRowから車輌管理マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.09.07</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromExtractInfo(CarManagementExtractInfo extractInfo)
        {
            CarManagementWork work = new CarManagementWork();

            work.CustomerCode = extractInfo.CustomerCode;
            work.CustomerCodeSt = extractInfo.CustomerCodeSt;
            work.CustomerCodeEd = extractInfo.CustomerCodeEd;
            work.CarMngCode = extractInfo.CarMngCode;
            work.CarMngCodeSearchDiv = extractInfo.SearchDiv;

            return work;
        }

        /// <summary>
        /// クラスメンバーコピー処理（車輌管理マスタワーククラス⇒車輌管理マスタRow）
        /// </summary>
        /// <param name="carManagementWork">車輌管理マスタワーククラス</param>
        /// <returns>車輌管理マスタRow</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタワーククラスから車輌管理マスタRowへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.09.07</br>
        /// <br>update Note  : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正</br>
        /// <br>             施ヘイ中</br>
        /// <br>Date       　: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private CarMngInputDataSet.CarInfoRow CopyToRowFromCarManagementWork(CarManagementWork carManagementWork)
        {
            CarMngInputDataSet.CarInfoRow row = this._carInfoDataTable.NewCarInfoRow();

            row.CarRelationGuid = Guid.NewGuid();

            row.UpdateDateTime = carManagementWork.UpdateDateTime;
            row.CreateDateTime = carManagementWork.CreateDateTime;
            row.FileHeaderGuid = carManagementWork.FileHeaderGuid;
            row.LogicalDeleteCode = carManagementWork.LogicalDeleteCode;

            // 論理削除
            if (carManagementWork.LogicalDeleteCode == 1)
            {
                row.DeleteDate = carManagementWork.UpdateDateTime;
            }
            row.DeleteFlag = DELETE_FLAG0;

            row.SaveCanFlag = SAVECAN_FLAG0;  // 2009/10/26 ADD

            row.RowStatus = ROWSTATUS_NORMAL;

            row.CustomerCode = this.StrPadLeft0(IntObjToStr(carManagementWork.CustomerCode), 8);
            row.CarMngNo = carManagementWork.CarMngNo.ToString();
            row.CarMngCode = carManagementWork.CarMngCode;
            if (carManagementWork.NumberPlate1Code == 0)
            {
                row.NumberPlate1Code = string.Empty;
            }
            else
            {
                row.NumberPlate1Code = this.StrPadLeft0(IntObjToStr(carManagementWork.NumberPlate1Code), 4);
            }
            // ----ADD 2009/10/10 ------>>>>>
            if (carManagementWork.NumberPlate1Name.Length > 4)
            {
                row.NumberPlate1Name = carManagementWork.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                row.NumberPlate1Name = carManagementWork.NumberPlate1Name;
            }
            // ----ADD 2009/10/10 ------<<<<<
            row.NumberPlate2 = carManagementWork.NumberPlate2;
            row.NumberPlate3 = carManagementWork.NumberPlate3;
            row.NumberPlate4 = IntObjToStr(carManagementWork.NumberPlate4);
            if (carManagementWork.EntryDate != DateTime.MinValue)
            {
                row.EntryDate = carManagementWork.EntryDate.ToString();
            }

            // --- DEL 2013/05/08 Y.Wakita ---------->>>>>
            //// ----ADD 2009/10/10 ----->>>>>
            ////// 年式
            ////if (carManagementWork.FirstEntryDate != 0)
            ////{
            ////    row.FirstEntryDate = DateTime.ParseExact(carManagementWork.FirstEntryDate.ToString(), "yyyyMM", null);
            ////}

            //DateTime tempFirstEntryDate = DateTime.MinValue;
            //try
            //{
            //    if (carManagementWork.FirstEntryDate != 0)
            //    {
            //        tempFirstEntryDate = DateTime.ParseExact(carManagementWork.FirstEntryDate.ToString(), "yyyyMM", null); // 初年度
            //    }
            //}
            //catch
            //{
            //    tempFirstEntryDate = DateTime.MinValue;
            //}

            //// 年式
            //if (carManagementWork.FirstEntryDate != 0 )
            //{
            //    if (tempFirstEntryDate != DateTime.MinValue)
            //    {
            //        row.FirstEntryDate = tempFirstEntryDate.ToString("yyyy年MM月");
            //    }
            //    else
            //    {
            //        row.FirstEntryDate = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "年";
            //    }
                
            //}
            //else
            //{
            //    row.FirstEntryDate = string.Empty;
            //}
            //// ----ADD 2009/10/10 -----<<<<<
            // --- DEL 2013/05/08 Y.Wakita ----------<<<<<

            // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
            // 年式[NULLのときは空白]
            if (carManagementWork.FirstEntryDate == 0)
            {
                row.FirstEntryDate = string.Empty;
            }
            else
            {
                string firstEntryDate = "";

                if (carManagementWork.FirstEntryDate.ToString().Length < 6)
                {
                    firstEntryDate = "0000" + "/" + carManagementWork.FirstEntryDate.ToString("D2");
                }
                else
                {
                    firstEntryDate = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "/" +
                                     carManagementWork.FirstEntryDate.ToString().Substring(4, 2);
                }

                firstEntryDate = firstEntryDate.Replace(@"/00", "");

                if (this.carMngInputAcs.GetAllDefSet().EraNameDispCd1 == 1)
                {
                    string date, stTarget;
                    int StartTotalUnitYm;

                    if (carManagementWork.FirstEntryDate.ToString().Substring(4, 2) == "00")
                    {
                        date = carManagementWork.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);
                    }
                    else
                    {
                        date = carManagementWork.FirstEntryDate.ToString() + "01";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                    }

                    row.FirstEntryDate = stTarget;
                }
                else
                {
                    row.FirstEntryDate = firstEntryDate;
                }
            }
            // --- ADD 2013/05/08 Y.Wakita ----------<<<<<

            row.MakerCode = carManagementWork.MakerCode;
            row.MakerFullName = carManagementWork.MakerFullName;
            row.MakerHalfName = carManagementWork.MakerHalfName;
            row.ModelCode = carManagementWork.ModelCode.ToString();
            row.ModelSubCode = carManagementWork.ModelSubCode.ToString();
            row.ModelFullName = carManagementWork.ModelFullName;
            row.ModelHalfName = carManagementWork.ModelHalfName;
            row.SystematicCode = carManagementWork.SystematicCode;
            row.SystematicName = carManagementWork.SystematicName;
            row.ProduceTypeOfYearCd = carManagementWork.ProduceTypeOfYearCd;
            row.ProduceTypeOfYearNm = carManagementWork.ProduceTypeOfYearNm;
            row.StProduceTypeOfYear = carManagementWork.StProduceTypeOfYear;
            row.EdProduceTypeOfYear = carManagementWork.EdProduceTypeOfYear;
            row.DoorCount = carManagementWork.DoorCount;
            row.BodyNameCode = carManagementWork.BodyNameCode;
            row.BodyName = carManagementWork.BodyName;
            row.ExhaustGasSign = carManagementWork.ExhaustGasSign;
            row.SeriesModel = carManagementWork.SeriesModel;
            row.CategorySignModel = carManagementWork.CategorySignModel;
            row.FullModel = carManagementWork.FullModel;
            row.ModelDesignationNo = this.StrPadLeft0(IntObjToStr(carManagementWork.ModelDesignationNo), 5);
            row.CategoryNo = this.StrPadLeft0(IntObjToStr(carManagementWork.CategoryNo), 4);
            row.FrameModel = carManagementWork.FrameModel;
            row.FrameNo = carManagementWork.FrameNo;
            row.SearchFrameNo = carManagementWork.SearchFrameNo;
            row.StProduceFrameNo = carManagementWork.StProduceFrameNo;
            row.EdProduceFrameNo = carManagementWork.EdProduceFrameNo;
            row.EngineModel = carManagementWork.EngineModel;
            row.ModelGradeNm = carManagementWork.ModelGradeNm;
            row.EngineModelNm = carManagementWork.EngineModelNm;
            row.EngineDisplaceNm = carManagementWork.EngineDisplaceNm;
            row.EDivNm = carManagementWork.EDivNm;
            row.TransmissionNm = carManagementWork.TransmissionNm;
            row.ShiftNm = carManagementWork.ShiftNm;
            row.WheelDriveMethodNm = carManagementWork.WheelDriveMethodNm;
            row.AddiCarSpec1 = carManagementWork.AddiCarSpec1;
            row.AddiCarSpec2 = carManagementWork.AddiCarSpec2;
            row.AddiCarSpec3 = carManagementWork.AddiCarSpec3;
            row.AddiCarSpec4 = carManagementWork.AddiCarSpec4;
            row.AddiCarSpec5 = carManagementWork.AddiCarSpec5;
            row.AddiCarSpec6 = carManagementWork.AddiCarSpec6;
            row.AddiCarSpecTitle1 = carManagementWork.AddiCarSpecTitle1;
            row.AddiCarSpecTitle2 = carManagementWork.AddiCarSpecTitle2;
            row.AddiCarSpecTitle3 = carManagementWork.AddiCarSpecTitle3;
            row.AddiCarSpecTitle4 = carManagementWork.AddiCarSpecTitle4;
            row.AddiCarSpecTitle5 = carManagementWork.AddiCarSpecTitle5;
            row.AddiCarSpecTitle6 = carManagementWork.AddiCarSpecTitle6;
            row.RelevanceModel = carManagementWork.RelevanceModel;
            row.SubCarNmCd = carManagementWork.SubCarNmCd;
            row.ModelGradeSname = carManagementWork.ModelGradeSname;
            row.BlockIllustrationCd = carManagementWork.BlockIllustrationCd;
            row.ThreeDIllustNo = carManagementWork.ThreeDIllustNo;
            row.PartsDataOfferFlag = carManagementWork.PartsDataOfferFlag;
            if (carManagementWork.InspectMaturityDate != DateTime.MinValue)
            {
                row.InspectMaturityDate = carManagementWork.InspectMaturityDate.ToString();
            }
            if (carManagementWork.LTimeCiMatDate != DateTime.MinValue)
            {
                row.LTimeCiMatDate = carManagementWork.LTimeCiMatDate.ToString();
            }
            row.CarInspectYear = carManagementWork.CarInspectYear;
            row.Mileage = carManagementWork.Mileage;
            row.CarNo = carManagementWork.CarNo;
            row.ColorCode = carManagementWork.ColorCode;
            row.ColorName1 = carManagementWork.ColorName1;
            row.TrimCode = carManagementWork.TrimCode;
            row.TrimName = carManagementWork.TrimName;
            row.FullModelFixedNoAry = carManagementWork.FullModelFixedNoAry;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == carManagementWork.FreeSrchMdlFxdNoAry || carManagementWork.FreeSrchMdlFxdNoAry.Length == 0)
            {
                row.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                byte[] bfrom = carManagementWork.FreeSrchMdlFxdNoAry;
                string[] freeAry = new string[bfrom.Length];
                for (int i = 0; i < bfrom.Length; i++)
                {
                    freeAry[i] = bfrom[i].ToString();  
                }
                row.FreeSrchMdlFxdNoAry = freeAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            //row.CategoryObjAry = Encoding.Default.GetString(carManagementWork.CategoryObjAry);
            row.CategoryObjAry = carManagementWork.CategoryObjAry;
            row.CarAddInfo1 = carManagementWork.CarAddInfo1;
            row.CarAddInfo2 = carManagementWork.CarAddInfo2;
            row.CarNote = carManagementWork.CarNote;

            // ADD 2013/03/22 -------------------->>>>>		           
            row.DomesticForeignCode = carManagementWork.DomesticForeignCode; // 国産/外車区分
            row.HandleInfoCode = carManagementWork.HandleInfoCode;  // ハンドル位置情報
            // ADD 2013/03/22 --------------------<<<<<

            // --- UPD 2009/10/26 ----->>>>>
            //CustomerInfo customerInfo;
            //this.GetCustomerInfo(carManagementWork.CustomerCode, this._enterpriseCode, out customerInfo);
            //if (customerInfo != null)
            //{
            //    if (customerInfo.CarMngDivCd == 0)
            //    {
            //        row.CarMngDivName = "しない";
            //    }
            //    else if (customerInfo.CarMngDivCd == 1 || customerInfo.CarMngDivCd == 2)
            //    {
            //        row.CarMngDivName = "登録有";
            //    }
            //    else if (customerInfo.CarMngDivCd == 3)
            //    {
            //        row.CarMngDivName = "登録無";
            //    }
            //    else
            //    {
            //        row.CarMngDivName = "しない";
            //    }
            //}
            //else
            //{
            //    row.CarMngDivName = "しない";
            //}
            int carMngDivCd = 0;
            if (!carMngDivHt.Contains(carManagementWork.CustomerCode))
            {
                // 車輌管理区分
                CustomerInfo customerInfo;
                this.GetCustomerInfo(carManagementWork.CustomerCode, this._enterpriseCode, out customerInfo);
                if (customerInfo != null)
                {
                    carMngDivCd = customerInfo.CarMngDivCd;
                    carMngDivHt.Add(carManagementWork.CustomerCode, carMngDivCd);
                }
            }
            else
            {
                carMngDivCd =(int) carMngDivHt[carManagementWork.CustomerCode];
            }

            if (carMngDivCd == 0)
            {
                row.CarMngDivName = "しない";
            }
            else if (carMngDivCd == 1 || carMngDivCd == 2)
            {
                row.CarMngDivName = "登録有";
            }
            else if (carMngDivCd == 3)
            {
                row.CarMngDivName = "登録無";
            }
            else
            {
                row.CarMngDivName = "しない";
            }
            // --- UPD 2009/10/26 -----<<<<<

            // ADD 2013/03/22 -------------------->>>>>	           
            row.DomesticForeignCode = carManagementWork.DomesticForeignCode;    // 国産/外車区分
            row.HandleInfoCode = carManagementWork.HandleInfoCode;  // ハンドル位置情報
            // ADD 2013/03/22 --------------------<<<<<
            return row;
        }

        /// <summary>
        /// クラスメンバーコピー処理（車輌管理マスタRow⇒車輌管理マスタワーククラス）
        /// </summary>
        /// <param name="row">車輌管理マスタRow</param>
        /// <returns>車輌管理マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタRowから車輌管理マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.09.07</br>
        /// <br>update Note  : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正</br>
        /// <br>             　施ヘイ中</br>
        /// <br>Date       　: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromRow(CarMngInputDataSet.CarInfoRow row)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.LogicalDeleteCode = row.LogicalDeleteCode;
            carManagementWork.CreateDateTime = row.CreateDateTime;
            carManagementWork.UpdateDateTime = row.UpdateDateTime;
            carManagementWork.FileHeaderGuid = row.FileHeaderGuid;

            carManagementWork.LogicalDeleteCode = row.LogicalDeleteCode;
            carManagementWork.EnterpriseCode = this._enterpriseCode;
            carManagementWork.CustomerCode = StrObjToInt(row.CustomerCode);
            carManagementWork.CarMngNo = StrObjToInt(row.CarMngNo);
            carManagementWork.CarMngCode = row.CarMngCode;
            carManagementWork.NumberPlate1Code = StrObjToInt(row.NumberPlate1Code);
            // ---- ADD 2009/10/10 ------>>>>> 
            if (row.NumberPlate1Name.Length > 4)
            {
                carManagementWork.NumberPlate1Name = row.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                carManagementWork.NumberPlate1Name = row.NumberPlate1Name;
            }
            // ---- ADD 2009/10/10 ------<<<<<
            carManagementWork.NumberPlate2 = row.NumberPlate2;
            carManagementWork.NumberPlate3 = row.NumberPlate3;
            carManagementWork.NumberPlate4 = StrObjToInt(row.NumberPlate4);

            if (!string.Empty.Equals(row[this._carInfoDataTable.EntryDateColumn.ColumnName])
                && !row[this._carInfoDataTable.EntryDateColumn.ColumnName].ToString().Equals("　")
                &&row[this._carInfoDataTable.EntryDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.EntryDate = Convert.ToDateTime(row.EntryDate);
            }
            if (row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName] != DBNull.Value
                && !row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName].ToString().Equals("　")
                && !string.Empty.Equals(row[this._carInfoDataTable.FirstEntryDateColumn.ColumnName]))
            {
                // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
                double d;
                if (!(Double.TryParse(row.FirstEntryDate.Substring(0, 1), out d)))
                {
                    int firstEntryDt_i;
                    string firstEntryDt_s = row.FirstEntryDate.Replace(" ", "");
                    int firstEntryDtLength = firstEntryDt_s.Length;

                    if (firstEntryDt_s.Substring(firstEntryDtLength - 1, 1) == "月")
                    {
                        firstEntryDt_s = firstEntryDt_s + "1日";
                        firstEntryDtLength = 6;
                    }
                    else
                    {
                        firstEntryDt_s = firstEntryDt_s + "1月1日";
                        firstEntryDtLength = 4;
                    }
                    firstEntryDt_i = TDateTime.JapaneseDateStringToLongDate(firstEntryDt_s);
                    if (firstEntryDtLength == 6)
                    {
                        firstEntryDt_s = firstEntryDt_i.ToString().Substring(0, firstEntryDtLength);
                        firstEntryDt_s = firstEntryDt_s.Substring(0, 4) + "/" + firstEntryDt_s.Substring(4, 2);
                    }
                    else
                    {
                        firstEntryDt_s = firstEntryDt_i.ToString().Substring(0, firstEntryDtLength);
                    }
                    row.FirstEntryDate = firstEntryDt_s;
                }
                // --- ADD 2013/05/08 Y.Wakita ----------<<<<<

                // ---UPD 2009/10/16 ----->>>>>
                // carManagementWork.FirstEntryDate = StrObjToInt(row.FirstEntryDate.ToString("yyyyMM"));
                string mon = "00";
                if (row.FirstEntryDate.Length > 5
                    && !row.FirstEntryDate.Substring(5, 1).Equals(" "))
                {
                    mon = row.FirstEntryDate.Substring(5, 2);
                }
                string firstEntryDt = row.FirstEntryDate.Substring(0, 4) + mon;
                carManagementWork.FirstEntryDate = StrObjToInt(firstEntryDt);
                // ---UPD 2009/10/16 -----<<<<<
            }

            carManagementWork.MakerCode = row.MakerCode;
            carManagementWork.MakerFullName = row.MakerFullName;
            carManagementWork.MakerHalfName = row.MakerHalfName;
            carManagementWork.ModelCode = StrObjToInt(row.ModelCode);
            carManagementWork.ModelSubCode = StrObjToInt(row.ModelSubCode);
            carManagementWork.ModelFullName = row.ModelFullName;
            carManagementWork.ModelHalfName = row.ModelHalfName;
            carManagementWork.SystematicCode = row.SystematicCode;
            carManagementWork.SystematicName = row.SystematicName;
            carManagementWork.ProduceTypeOfYearCd = row.ProduceTypeOfYearCd;
            carManagementWork.ProduceTypeOfYearNm = row.ProduceTypeOfYearNm;
            carManagementWork.StProduceTypeOfYear = row.StProduceTypeOfYear;
            carManagementWork.EdProduceTypeOfYear = row.EdProduceTypeOfYear;
            carManagementWork.DoorCount = row.DoorCount;
            carManagementWork.BodyNameCode = row.BodyNameCode;
            carManagementWork.BodyName = row.BodyName;
            carManagementWork.ExhaustGasSign = row.ExhaustGasSign;
            carManagementWork.SeriesModel = row.SeriesModel;
            carManagementWork.CategorySignModel = row.CategorySignModel;
            carManagementWork.FullModel = row.FullModel;
            carManagementWork.ModelDesignationNo = StrObjToInt(row.ModelDesignationNo);
            carManagementWork.CategoryNo = StrObjToInt(row.CategoryNo);
            carManagementWork.FrameModel = row.FrameModel;
            carManagementWork.FrameNo = row.FrameNo;
            carManagementWork.SearchFrameNo = row.SearchFrameNo;
            carManagementWork.StProduceFrameNo = row.StProduceFrameNo;
            carManagementWork.EdProduceFrameNo = row.EdProduceFrameNo;
            carManagementWork.EngineModel = row.EngineModel;
            carManagementWork.ModelGradeNm = row.ModelGradeNm;
            carManagementWork.EngineModelNm = row.EngineModelNm;
            carManagementWork.EngineDisplaceNm = row.EngineDisplaceNm;
            carManagementWork.EDivNm = row.EDivNm;
            carManagementWork.TransmissionNm = row.TransmissionNm;
            carManagementWork.ShiftNm = row.ShiftNm;
            carManagementWork.WheelDriveMethodNm = row.WheelDriveMethodNm;
            carManagementWork.AddiCarSpec1 = row.AddiCarSpec1;
            carManagementWork.AddiCarSpec2 = row.AddiCarSpec2;
            carManagementWork.AddiCarSpec3 = row.AddiCarSpec3;
            carManagementWork.AddiCarSpec4 = row.AddiCarSpec4;
            carManagementWork.AddiCarSpec5 = row.AddiCarSpec5;
            carManagementWork.AddiCarSpec6 = row.AddiCarSpec6;
            carManagementWork.AddiCarSpecTitle1 = row.AddiCarSpecTitle1;
            carManagementWork.AddiCarSpecTitle2 = row.AddiCarSpecTitle2;
            carManagementWork.AddiCarSpecTitle3 = row.AddiCarSpecTitle3;
            carManagementWork.AddiCarSpecTitle4 = row.AddiCarSpecTitle4;
            carManagementWork.AddiCarSpecTitle5 = row.AddiCarSpecTitle5;
            carManagementWork.AddiCarSpecTitle6 = row.AddiCarSpecTitle6;
            carManagementWork.RelevanceModel = row.RelevanceModel;
            carManagementWork.SubCarNmCd = row.SubCarNmCd;
            carManagementWork.ModelGradeSname = row.ModelGradeSname;
            carManagementWork.BlockIllustrationCd = row.BlockIllustrationCd;
            carManagementWork.ThreeDIllustNo = row.ThreeDIllustNo;
            carManagementWork.PartsDataOfferFlag = row.PartsDataOfferFlag;
            // ----ADD 2010/12/22 ------>>>>>
            if (null == row.FreeSrchMdlFxdNoAry || row.FreeSrchMdlFxdNoAry.Length == 0)
            {
                carManagementWork.FreeSrchMdlFxdNoAry =  new byte[0] ;
            }
            else
            {
                string[] bfrom = row.FreeSrchMdlFxdNoAry;
                byte[] freeAry = new byte[bfrom.Length];
                for (int i = 0; i < bfrom.Length; i++)
                {
                    freeAry[i] = Convert.ToByte(bfrom[i]);
                }
                carManagementWork.FreeSrchMdlFxdNoAry = freeAry;
            }
            // ----ADD 2010/12/22 ------<<<<<
            if (!string.Empty.Equals(row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName])
                &&!row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName].ToString().Equals("　")
                &&row[this._carInfoDataTable.InspectMaturityDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.InspectMaturityDate = Convert.ToDateTime(row.InspectMaturityDate);
            }
            if (!string.Empty.Equals(row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName])
                && !row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName].ToString().Equals("　")
                &&row[this._carInfoDataTable.LTimeCiMatDateColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.LTimeCiMatDate = Convert.ToDateTime(row.LTimeCiMatDate);
            }

            if (!string.Empty.Equals(row[this._carInfoDataTable.CarInspectYearColumn.ColumnName])
                && !row[this._carInfoDataTable.CarInspectYearColumn.ColumnName].ToString().Equals("　")
                &&row[this._carInfoDataTable.CarInspectYearColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.CarInspectYear = row.CarInspectYear;
            }

            if (row[this._carInfoDataTable.MileageColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.Mileage = row.Mileage;
            }
            carManagementWork.CarNo = row.CarNo;
            carManagementWork.ColorCode = row.ColorCode;
            carManagementWork.ColorName1 = row.ColorName1;
            carManagementWork.TrimCode = row.TrimCode;
            carManagementWork.TrimName = row.TrimName;
            carManagementWork.FullModelFixedNoAry = row.FullModelFixedNoAry;
            //carManagementWork.CategoryObjAry = Encoding.Default.GetBytes(row.CategoryObjAry);
            carManagementWork.CategoryObjAry = row.CategoryObjAry;
            carManagementWork.CarAddInfo1 = row.CarAddInfo1;
            carManagementWork.CarAddInfo2 = row.CarAddInfo2;
            if (row[this._carInfoDataTable.CarNoteColumn.ColumnName] != DBNull.Value)
            {
                carManagementWork.CarNote = row.CarNote;
            }
            else
            {
                carManagementWork.CarNote = string.Empty;
            }
            // ADD 2013/03/22 -------------------->>>>>	           
            carManagementWork.DomesticForeignCode = row.DomesticForeignCode;    // 国産/外車区分
            carManagementWork.HandleInfoCode = row.HandleInfoCode;  // ハンドル位置情報
            // ADD 2013/03/22 --------------------<<<<<

            return carManagementWork;
        }
        # endregion
    }
}