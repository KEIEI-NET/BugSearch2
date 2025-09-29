//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : セットマスタ（エクスポート）
// プログラム概要   : セットマスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/23  修正内容 : PVCS250 取得のデータ不正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// セットマスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : セットマスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class GoodsSetExportAcs
    {
        #region ■ Private Member
        private IGoodsSetDB _iGoodsSetDB ;
        private const string PRINTSET_TABLE = "GoodsSetExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// セットマスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public GoodsSetExportAcs()
        {
            this._iGoodsSetDB = (IGoodsSetDB)MediationGoodsSetDB.GetGoodsSetDB();
        }
        #endregion

        #region ■ セットマスタ情報検索
        /// <summary>
        /// セットマスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : セットマスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(GoodsSetExportWork condition, out DataTable dataTable)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.EnterpriseCode = condition.EnterpriseCode;

            int status = 0;
            int checkstatus = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);

            ArrayList paraList = new ArrayList();
            paraList.Clear();
            object paraobj = goodsSetWork;
            object retobj = paraList;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // 検索
            status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, logicalMode);

            paraList = (ArrayList)retobj;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (GoodsSetWork goodsSetWorkdata in paraList)
                {
                    // 抽出処理
                    checkstatus = DataCheck(goodsSetWorkdata, condition);
                    if (checkstatus == 0)
                    {
                        //セット情報クラスへメンバコピー
                        ConverToDataSetCustomerInf(goodsSetWorkdata, ref dataTable);
                    }
                }
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
            dataTable.Columns.Add("ParentGoodsNoRF", typeof(string));               //  親商品番号
            dataTable.Columns.Add("ParentGoodsMakerCdRF", typeof(string));           //  親メーカーコード
            dataTable.Columns.Add("DisplayOrderRF", typeof(string));                 //  表示順位
            dataTable.Columns.Add("SubGoodsNoRF", typeof(string));                  //  子商品番号			
            dataTable.Columns.Add("SubGoodsMakerCdRF", typeof(string));              //  子商品メーカーコード
            dataTable.Columns.Add("CntFlRF", typeof(string));                       //  数量（浮動）
            dataTable.Columns.Add("SetSpecialNoteRF", typeof(string));              //  セット規格・特記事項	
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="goodsSetWorkdata">商品データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(GoodsSetWork goodsSetWorkdata,GoodsSetExportWork condition)
        {
            int status = 0;
            if (!String.IsNullOrEmpty(condition.GoodsNoSt.Trim()) && !String.IsNullOrEmpty(goodsSetWorkdata.ParentGoodsNo.Trim())
                && condition.GoodsNoSt.Trim().CompareTo(goodsSetWorkdata.ParentGoodsNo.Trim()) == 1)
            {
                status = -1;
                return status;
            }

            if (!String.IsNullOrEmpty(condition.GoodsNoEd.Trim()) && !String.IsNullOrEmpty(goodsSetWorkdata.ParentGoodsNo.Trim())
                && condition.GoodsNoEd.Trim().CompareTo(goodsSetWorkdata.ParentGoodsNo.Trim()) == -1)
            {
                status = -1;
                return status;
            }
            // MODIFY 2009/06/23 --->>>
            // 取得のデータ不正
            //if (condition.GoodsMakerCdSt != 0 && goodsSetWorkdata.SubGoodsMakerCd < condition.GoodsMakerCdSt)
            if (condition.GoodsMakerCdSt != 0 && goodsSetWorkdata.ParentGoodsMakerCd < condition.GoodsMakerCdSt)
            // MODIFY 2009/06/23 ---<<<
            {
                status = -1;
                return status;
            }
            // MODIFY 2009/06/23 --->>>
            // 取得のデータ不正
            //if (condition.GoodsMakerCdEd != 0 && goodsSetWorkdata.SubGoodsMakerCd > condition.GoodsMakerCdEd)
            if (condition.GoodsMakerCdEd != 0 && goodsSetWorkdata.ParentGoodsMakerCd > condition.GoodsMakerCdEd)
            // MODIFY 2009/06/23 ---<<<
            {
                status = -1;
                return status;
            }

            return status;

        }


        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsSetWorkdata">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsSetWork goodsSetWorkdata, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["ParentGoodsNoRF"] = GetSubString(goodsSetWorkdata.ParentGoodsNo,24);
            dataRow["ParentGoodsMakerCdRF"] = AppendZero(goodsSetWorkdata.ParentGoodsMakerCd.ToString(),4);
            dataRow["DisplayOrderRF"] = GetSubString(goodsSetWorkdata.DisplayOrder.ToString(),4);
            dataRow["SubGoodsNoRF"] = GetSubString(goodsSetWorkdata.SubGoodsNo,24);
            dataRow["SubGoodsMakerCdRF"] = AppendZero(goodsSetWorkdata.SubGoodsMakerCd.ToString(),4);
            dataRow["CntFlRF"] = goodsSetWorkdata.CntFl.ToString("##0.00");
            dataRow["SetSpecialNoteRF"] = GetSubString(goodsSetWorkdata.SetSpecialNote,40);
            
            dataTable.Rows.Add(dataRow);
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
        #endregion
    }
}
