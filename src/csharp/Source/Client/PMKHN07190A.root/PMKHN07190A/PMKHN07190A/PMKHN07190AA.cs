//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部位マスタ（エクスポート）
// プログラム概要   : 部位マスタ（エクスポート）を行う
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
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部位マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class PartsPosCodeExportAcs
    {
        #region ■ Private Member
        private IPartsPosCodeUDB _iPartsPosCodeUDB;
        private const string PRINTSET_TABLE = "PartsPosExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// 部位マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部位マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PartsPosCodeExportAcs()
        {
            _iPartsPosCodeUDB = (IPartsPosCodeUDB)MediationPartsPosCodeUDB.GetPartsPosCodeUDB();
        }
        # endregion

        #region ■ 部位マスタ情報検索
        /// <summary>
        /// 部位マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 部位マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(PartsPosCodeExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            Object retobj = new ArrayList();
            //retobj = (ArrayList)retobj;
            
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
            partsPosCodeUWork.EnterpriseCode = condition.EnterpriseCode;
            partsPosCodeUWork.LogicalDeleteCode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // 検索
            status = this._iPartsPosCodeUDB.Search(ref retobj, partsPosCodeUWork, 0, logicalMode);

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
        # endregion

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
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));                 //  得意先コード
            dataTable.Columns.Add("SearchPartsPosCodeRF", typeof(string));	        //  検索部位コード
            dataTable.Columns.Add("SearchPartsPosNameRF", typeof(string));	        //  検索部位コード名称
            dataTable.Columns.Add("PosDispOrderRF", typeof(Int32));	                //  検索部位表示順位
            dataTable.Columns.Add("TbsPartsCodeRF", typeof(string));	                //  BL商品コード
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(ArrayList retList, PartsPosCodeExportWork condition, ref DataTable dataTable)
        {
            foreach (PartsPosCodeUWork partsPosCodeU in retList)
            {
                if (DataCheck(partsPosCodeU, condition) == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["CustomerCodeRF"] = AppendZero(partsPosCodeU.CustomerCode.ToString(), 8);
                    dataRow["SearchPartsPosCodeRF"] = AppendZero(partsPosCodeU.SearchPartsPosCode.ToString(), 2);
                    dataRow["SearchPartsPosNameRF"] = GetSubString(partsPosCodeU.SearchPartsPosName, 20);
                    dataRow["PosDispOrderRF"] = partsPosCodeU.PosDispOrder;
                    dataRow["TbsPartsCodeRF"] = AppendZero(partsPosCodeU.TbsPartsCode.ToString(), 5);
                    dataTable.Rows.Add(dataRow);
                }

            }
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="partsPosCodeU">部位データ</param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(PartsPosCodeUWork partsPosCodeU, PartsPosCodeExportWork condition)
        {
            int status = 0;
            if (partsPosCodeU.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }
            if (partsPosCodeU.OfferDataDiv != 0)
            {
                status = -1;
                return status;
            }
            int customerCd = partsPosCodeU.CustomerCode;
            if (condition.CustomerCodeSt != 0 && customerCd < condition.CustomerCodeSt)
            {
                status = -1;
                return status;

            }
            if (condition.CustomerCodeEd != 0 && customerCd > condition.CustomerCodeEd)
            {
                status = -1;
                return status;
            }
            int partsPosCode = partsPosCodeU.SearchPartsPosCode;
            if (condition.SearchPartsPosCodeSt != 0 && partsPosCode < condition.SearchPartsPosCodeSt)
            {
                status = -1;
                return status;

            }
            if (condition.SearchPartsPosCodeEd != 0 && partsPosCode > condition.SearchPartsPosCodeEd)
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
            StringBuilder tempBuild = new StringBuilder();
            bfString = bfString.Trim();
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
            bfString = bfString.Trim();
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
        # endregion
    }
}
