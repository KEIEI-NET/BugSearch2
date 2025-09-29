//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 倉庫マスタ（エクスポート）
// プログラム概要   : 倉庫マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 倉庫マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class WarehouseExportAcs
    {
        #region ■ Private Member
        private IWarehouseDB _iwarehouseDB = null;
        private const string PRINTSET_TABLE = "WarehouseExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// 倉庫マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public WarehouseExportAcs()
        {
            // リモートオブジェクト取得
            this._iwarehouseDB = (IWarehouseDB)MediationWarehouseDB.GetWarehouseDB();
        }
        #endregion

        #region ■ 倉庫マスタ情報検索
        /// <summary>
        /// 倉庫マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 倉庫マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(WarehouseExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            object retobj = null;
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = condition.EnterpriseCode;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // 検索
            status = this._iwarehouseDB.Search(out retobj, warehouseWork, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ConverToDataSetWarehouseInf((ArrayList)retobj, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region ■ Private Methods
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("WarehouseCodeRF", typeof(string));           //  倉庫コード
            dataTable.Columns.Add("WarehouseNameRF", typeof(string));	        //  倉庫名称
            dataTable.Columns.Add("SectionCodeRF", typeof(string));	            //  拠点コード
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));	            //  得意先コード
            dataTable.Columns.Add("MainMngWarehouseCdRF", typeof(string));	    //  主管倉庫コード
            dataTable.Columns.Add("StockBlnktRemark1RF", typeof(string));	    //  在庫一括リマーク（３）
            dataTable.Columns.Add("StockBlnktRemark2RF", typeof(string));	    //  在庫一括リマーク（５）
            dataTable.Columns.Add("WarehouseNote1RF", typeof(string));	        //  倉庫備考1
        }



        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">戻る結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(ArrayList retList, WarehouseExportWork condition, ref DataTable dataTable)
        {
            foreach (WarehouseWork warehouseWork in retList)
            {
                if (DataCheck(warehouseWork, condition) == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    // 倉庫コード
                    dataRow["WarehouseCodeRF"] = AppendStrZero(warehouseWork.WarehouseCode.Trim(), 4);
                    // 倉庫名称
                    dataRow["WarehouseNameRF"] = GetSubString(warehouseWork.WarehouseName.Trim(), 20);
                    // 拠点コード
                    dataRow["SectionCodeRF"] = AppendStrZero(warehouseWork.SectionCode.Trim(), 2);
                    // 得意先コード
                    dataRow["CustomerCodeRF"] = AppendZero(warehouseWork.CustomerCode.ToString(),8);
                    // 主管倉庫コード
                    dataRow["MainMngWarehouseCdRF"] = AppendStrZero(warehouseWork.MainMngWarehouseCd.Trim(), 4);

                    if (!String.IsNullOrEmpty(warehouseWork.StockBlnktRemark.Trim()) && warehouseWork.StockBlnktRemark.Trim().Length >= 3)
                    {
                        // 在庫一括リマーク（３）
                        dataRow["StockBlnktRemark1RF"] = warehouseWork.StockBlnktRemark.Substring(0, 3).Trim();
                    }
                    else
                    {
                        dataRow["StockBlnktRemark1RF"] = warehouseWork.StockBlnktRemark.Trim();
                    }
                    if (!String.IsNullOrEmpty(warehouseWork.StockBlnktRemark.Trim()) && warehouseWork.StockBlnktRemark.Trim().Length >= 4)
                    {
                        // 在庫一括リマーク（５）
                        if (warehouseWork.StockBlnktRemark.Length > 8)
                        {
                            dataRow["StockBlnktRemark2RF"] = warehouseWork.StockBlnktRemark.Substring(3, 5).Trim();
                        }
                        else
                        {
                            dataRow["StockBlnktRemark2RF"] = warehouseWork.StockBlnktRemark.Substring(3, warehouseWork.StockBlnktRemark.Length - 3).Trim();
                        }

                    }
                    else
                    {
                        dataRow["StockBlnktRemark2RF"] = "";
                    }

                    // 倉庫備考1
                    dataRow["WarehouseNote1RF"] = GetSubString(warehouseWork.WarehouseNote1.Trim(), 40);

                    dataTable.Rows.Add(dataRow);
                }

            }
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="warehouseWork">倉庫データ</param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataCheck(WarehouseWork warehouseWork, WarehouseExportWork condition)
        {
            int status = 0;
            int warehouseCd = Int32.Parse(warehouseWork.WarehouseCode.Trim());
            if (!String.IsNullOrEmpty(condition.WarehouseCdSt.Trim()) && warehouseCd < Int32.Parse(condition.WarehouseCdSt.Trim()))
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(condition.WarehouseCdEd.Trim()) && warehouseCd > Int32.Parse(condition.WarehouseCdEd.Trim()))
            {
                status = -1;
                return status;
            }
            return status;
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString();
        }
        #endregion
    }
}
