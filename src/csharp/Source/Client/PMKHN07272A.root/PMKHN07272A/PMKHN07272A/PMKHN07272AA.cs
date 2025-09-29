//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理マスタ（エクスポート）
// プログラム概要   : 商品管理マスタ（エクスポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 更 新 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/13  修正内容 : 2012/10/17配信分、Redmine#32367
//                                  商品マスタエクスポートで不具合現象の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品管理マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Update Note: 2012/11/13 李亜博</br>
    ///	<br>			 Redmine#32367 商品マスタエクスポートで不具合現象の対応</br>
    /// </remarks>
    public class GoodsMngExportAcs
    {
        #region ■ Private Member
        // テーブル名称
        private const string PRINTSET_TABLE = "GoodsMngExp";
        // 拠点コード
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // 商品メーカーコード
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        // 商品番号
        private const string GOODSNO_COLUMN = "GoodsNoRF";
        // 仕入先コード
        private const string SUPPLIERCD_COLUMN = "SupplierCdRF";
        // 発注ロット
        private const string SUPPLIERLOT_COLUMN = "SupplierLotRF";

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        // BLコード
        private const string BLGOODSCODE_COLUMN = "BLGoodsCodeRF";
        // 中分類
        private const string GOODSMGROUP_COLUMN = "GoodsMGroupRF";
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

        // 商品管理マスタデータ(エクスポート)DBRemoteObject仲介クラス
        private IGoodsMngExportDB _iGoodsMngExportDB = null;
        #endregion

        # region ■Constracter
        /// <summary>
        /// 商品管理マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品管理マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public GoodsMngExportAcs()
        {
            try
            {
                _iGoodsMngExportDB = (IGoodsMngExportDB)MediationGoodsMngExportDB.GetGoodsMngExportDB();
            }
            catch (Exception)
            {
                _iGoodsMngExportDB = null;
            }
        }
        #endregion

        #region ■ 商品管理マスタ情報検索
        /// <summary>
        /// 商品管理マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品管理マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public int Search(GoodsMngExport condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加
            CreateDataTable(ref dataTable);
            // 出力仕様の修正
            object retObj = null;
            
            GoodsMngExportParamWork goodsMngExportParamWork;
            ConvertConditionToGoodsMngExportParamWork(out goodsMngExportParamWork, condition);
            object paraObj = (object)goodsMngExportParamWork;
            // 商品管理マスト取得
            status = _iGoodsMngExportDB.SearchGoodsMng(out retObj, paraObj, ConstantManagement.LogicalMode.GetData0); 
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList retList = (ArrayList)retObj;
                foreach (GoodsMngWork goodsMng in retList)
                {
                    // 出力
                    ConverToDataSetCustomerInf(goodsMng, ref dataTable);
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
        /// 検索条件⇒検索条件ワーク処理
        /// </summary>
        /// <param name="goodsMngExportParamWork">検索条件ワーク</param>
        /// <param name="condition">検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索条件⇒検索条件ワーク処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>Update Note: 2012/11/13 李亜博</br>
        ///	<br>			 Redmine#32367 商品マスタエクスポートで不具合現象の対応</br>
        /// </remarks>
        private void ConvertConditionToGoodsMngExportParamWork(out GoodsMngExportParamWork goodsMngExportParamWork, GoodsMngExport condition)
        {
            goodsMngExportParamWork = new GoodsMngExportParamWork();
            goodsMngExportParamWork.EnterpriseCode = condition.EnterpriseCode;
            goodsMngExportParamWork.GoodsMakerCdEd = condition.GoodsMakerCdEd;
            goodsMngExportParamWork.GoodsMakerCdSt = condition.GoodsMakerCdSt;
            goodsMngExportParamWork.GoodsNoEd = condition.GoodsNoEd;
            goodsMngExportParamWork.GoodsNoSt = condition.GoodsNoSt;
            goodsMngExportParamWork.SectionCdEd = condition.SectionCdEd;
            goodsMngExportParamWork.SectionCdSt = condition.SectionCdSt;
            //----- DEL liusy 2012/09/24 for Redmine#32367---------->>>>>
            //goodsMngExportParamWork.BLGoodsCode = 0;
            //goodsMngExportParamWork.GoodsMGroup = 0;
            // --- DEL liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            goodsMngExportParamWork.BLGoodsCodeSt = condition.BLGoodsCodeSt;
            goodsMngExportParamWork.BLGoodsCodeEd = condition.BLGoodsCodeEd;
            goodsMngExportParamWork.GoodsMGroupSt = condition.GoodsMGroupSt;
            goodsMngExportParamWork.GoodsMGroupEd = condition.GoodsMGroupEd;
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            goodsMngExportParamWork.SetKind = condition.SetKind;//ADD 2012/11/13 李亜博 for Redmine#32367
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsMng">商品管理データ</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsMngWork goodsMng, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            // 拠点コード
            dataRow[SECTIONCODE_COLUMN] = goodsMng.SectionCode.Trim().PadLeft(2, '0');
            // 商品メーカーコード
            if (goodsMng.GoodsMakerCd == 0)
                dataRow[GOODSMAKERCD_COLUMN] = "0";
            else
                dataRow[GOODSMAKERCD_COLUMN] = goodsMng.GoodsMakerCd.ToString().PadLeft(4, '0');
            // 品番
            if (goodsMng.GoodsNo.Length > 24)
                dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Substring(0, 24);
            else
                dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Trim();
            // 仕入先コード
            if (goodsMng.SupplierCd == 0)
                dataRow[SUPPLIERCD_COLUMN] = "0";
            else
                dataRow[SUPPLIERCD_COLUMN] = goodsMng.SupplierCd.ToString().PadLeft(6, '0');
            // 発注ロット
            dataRow[SUPPLIERLOT_COLUMN] = goodsMng.SupplierLot.ToString();

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            //BLコード
            if (goodsMng.BLGoodsCode == 0)
                dataRow[BLGOODSCODE_COLUMN] = "0";
            else
                dataRow[BLGOODSCODE_COLUMN] = goodsMng.BLGoodsCode.ToString().PadLeft(5, '0');

            //中分類
            if (goodsMng.GoodsMGroup == 0)
                dataRow[GOODSMGROUP_COLUMN] = "0";
            else
                dataRow[GOODSMGROUP_COLUMN] = goodsMng.GoodsMGroup.ToString().PadLeft(4, '0');
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                  //  拠点コード
            dataTable.Columns.Add(GOODSNO_COLUMN, typeof(string));                      //  商品番号
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  商品メーカーコード
            dataTable.Columns.Add(SUPPLIERCD_COLUMN, typeof(string));                   //  仕入先コード
            dataTable.Columns.Add(SUPPLIERLOT_COLUMN, typeof(string));                  //  発注ロット
            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            dataTable.Columns.Add(BLGOODSCODE_COLUMN, typeof(string));                  //  BLコード
            dataTable.Columns.Add(GOODSMGROUP_COLUMN, typeof(string));                  //  中分類
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        }

        #endregion
    }
}
