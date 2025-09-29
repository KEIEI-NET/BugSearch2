//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/06/24  修正内容 : 使用ファイルの追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/03/31  修正内容 : Mantis.15256 商品マスタインポートの対象項目設定対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text; // ADD wangf 2012/06/12 FOR Redmine#30387
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class GoodsUImportAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 商品マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 商品マスタ（インポート）アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 劉学智</br>
	    /// <br>Date       : 2009.05.13</br>
		/// </remarks>
		public GoodsUImportAcs()
		{
            this._iGoodsUImportDB = (IGoodsUImportDB)MediationGoodsUImportDB.GetGoodsUImportDB();
        }

		/// <summary>
        /// 商品マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 商品マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static GoodsUImportAcs()
		{
		}
		#endregion ■ Constructor

        #region ■ Private Member
        // 商品マスタ（インポート）のリモートインタフェース
        private IGoodsUImportDB _iGoodsUImportDB;
        private const string ERROR_LOG_FILENAME = "PMKHN07630U_ERRORLOG.xml"; // ADD wangf 2012/06/12 FOR Redmine#30387
        #endregion ■ Private Member

        #region ■ Public Method
        #region ◎ インポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        //public int Import(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg) // DEL wangf 2012/06/12 FOR Redmine#30387
        public int Import(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg) // ADD wangf 2012/06/12 FOR Redmine#30387
        {
            //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg); // DEL wangf 2012/06/12 FOR Redmine#30387
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt, out errMsg); // ADD wangf 2012/06/12 FOR Redmine#30387
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ 商品マスタ（インポート）のインポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        /// </remarks>
        //private int ImportProc(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg) // DEL wangf 2012/06/12 FOR Redmine#30387
        private int ImportProc(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg) // ADD wangf 2012/06/12 FOR Redmine#30387
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0; // ADD wangf 2012/06/12 FOR Redmine#30387
            errMsg = string.Empty;

            try
            {
                ArrayList importGoodsUWorkList = null;
                ArrayList importGoodsPriceUWorkList = null;
                ArrayList importGoodsUGoodsPriceUWorkList = null; // ADD wangf 2012/06/12 FOR Redmine#30387
                Object importSetUpInfoList = (object)importWorkTbl.SetUpInfoList;   // 2010/03/31 Add
                //DataTable table = null; // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                DataTable table = new DataTable();
                CreateDataTable(ref table);
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                // 商品マスタのインポートワークの変換処理
                status = ConvertToGoodsUImportWorkList(importWorkTbl, out importGoodsUWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 価格マスタのインポートワークの変換処理
                    status = ConvertToGoodsPriceUImportWorkList(importWorkTbl, out importGoodsPriceUWorkList, out errMsg);
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    ConvertToGoodsUGoodsPriceUImportWorkList(importWorkTbl, out importGoodsUGoodsPriceUWorkList, out errMsg);
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        Object objGoodsUImportWorkList = (object)importGoodsUWorkList;
                        Object objGoodsPriceUImportWorkList = (object)importGoodsPriceUWorkList;
                        Object objGoodsUGoodsPriceUImportWorkList = (object)importGoodsUGoodsPriceUWorkList; // ADD wangf 2012/06/12 FOR Redmine#30387
                        // リモートクラスを呼び出す。
                        // 2010/03/31 >>>
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList); // DEL wangf 2012/06/12 FOR Redmine#30387
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, ref table, importWorkTbl.PriceStartDate); // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                        //status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, importWorkTbl.PriceStartDate); // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
                        status = this._iGoodsUImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.DataCheckKbn, ref objGoodsUImportWorkList, ref objGoodsPriceUImportWorkList, ref objGoodsUGoodsPriceUImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg, importSetUpInfoList, importWorkTbl.PriceStartDate); // ADD wangf 2012/07/20 FOR Redmine#30387
                        // 2010/03/31 <<<
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        //if (table.Rows.Count > 0) // DEL wangf 2012/07/03 FOR Redmine#30387
                        // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                        if (objGoodsUGoodsPriceUImportWorkList != null && ((ArrayList)objGoodsUGoodsPriceUImportWorkList).Count > 0)
                        {
                            ArrayList exportGoodsUGoodsPriceUImportWorkArray = objGoodsUGoodsPriceUImportWorkList as ArrayList;
                            foreach (GoodsUGoodsPriceUWork goodsUGoodsPriceUWork in exportGoodsUGoodsPriceUImportWorkArray)
                            {
                                if (!string.IsNullOrEmpty(goodsUGoodsPriceUWork.ErrorMsg))
                                {
                                    ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, ref table);
                                }
                            }
                            if (table.Rows.Count > 0){
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            errCnt = table.Rows.Count;
                            this.DoOutPut(importWorkTbl.ErrorLogFileName, table);
                            } // ADD wangf 2012/07/03 FOR Redmine#30387
                        }
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    }
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◆ データ変換処理
        #region ◎ 商品マスタのインポートワークの変換処理
        /// <summary>
        /// 商品マスタのインポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタのインポートワークの変換処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToGoodsUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    work.GoodsName = ConvertToEmpty(csvDataArr, index++);               // 品名
                    work.GoodsNameKana = ConvertToEmpty(csvDataArr, index++);           // 品名カナ
                    work.Jan = ConvertToEmpty(csvDataArr, index++);                     // JANコード
                    work.BLGoodsCode = ConvertToInt32(csvDataArr, index++);             // BLコード
                    work.EnterpriseGanreCode = ConvertToInt32(csvDataArr, index++);     // 商品区分
                    work.GoodsRateRank = ConvertToEmpty(csvDataArr, index++);           // 層別
                    work.GoodsKindCode = ConvertToInt32(csvDataArr, index++);           // 純優区分
                    work.TaxationDivCd = ConvertToInt32(csvDataArr, index++);           // 課税区分
                    work.GoodsNote1 = ConvertToEmpty(csvDataArr, index++);              // 商品備考１
                    work.GoodsNote2 = ConvertToEmpty(csvDataArr, index++);              // 商品備考２
                    work.GoodsSpecialNote = ConvertToEmpty(csvDataArr, index++);        // 商品規格・特記事項

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region ◎ 価格マスタのインポートワークの変換処理
        /// <summary>
        /// 価格マスタのインポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 価格マスタのインポートワークの変換処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        private int ConvertToGoodsPriceUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsPriceUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsPriceUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    index = 13;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // 価格開始年月日
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // 価格
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // オープン価格区分
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // 仕入率
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // 原単価
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // 処理はサーバー側移動する
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387

                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    index = 18;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // 価格開始年月日
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // 価格
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // オープン価格区分
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // 仕入率
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // 原単価
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // 処理はサーバー側移動する
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387

                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    index = 23;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // 価格開始年月日
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // 価格
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // オープン価格区分
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // 仕入率
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // 原単価
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // 処理はサーバー側移動する
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    // ADD 2009/06/24 --->>>
                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    index = 28;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // 価格開始年月日
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // 価格
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // オープン価格区分
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // 仕入率
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // 原単価
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // 処理はサーバー側移動する
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    work = new GoodsPriceUWork();
                    index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);            // メーカー
                    index = 33;
                    work.PriceStartDate = ConvertToDateTime(csvDataArr, index++);       // 価格開始年月日
                    work.ListPrice = ConvertToDouble(csvDataArr, index++);              // 価格
                    work.OpenPriceDiv = ConvertToInt32(csvDataArr, index++);            // オープン価格区分
                    work.StockRate = ConvertToDouble(csvDataArr, index++);              // 仕入率
                    work.SalesUnitCost = ConvertToDouble(csvDataArr, index++);          // 原単価
                    /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    // 処理はサーバー側移動する
                    if (work.PriceStartDate != DateTime.MinValue)
                    {
                    // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        importWorkList.Add(work);
                    //} // DEL wangf 2012/06/12 FOR Redmine#30387
                    // ADD 2009/06/24 ---<<<
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        // ------------ADD START wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region ◎ 商品マスタ・価格マスタのインポートワークの変換処理
        /// <summary>
        /// 商品マスタ・価格マスタのインポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ・価格マスタのインポートワークの変換処理を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int ConvertToGoodsUGoodsPriceUImportWorkList(ExtrInfo_GoodsUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsUGoodsPriceUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsUGoodsPriceUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 // 品番
                    work.GoodsMakerCd = ConvertToEmpty(csvDataArr, index++);            // メーカー
                    work.GoodsName = ConvertToEmpty(csvDataArr, index++);               // 品名
                    work.GoodsNameKana = ConvertToEmpty(csvDataArr, index++);           // 品名カナ
                    work.Jan = ConvertToEmpty(csvDataArr, index++);                     // JANコード
                    work.BLGoodsCode = ConvertToEmpty(csvDataArr, index++);             // BLコード
                    work.EnterpriseGanreCode = ConvertToEmpty(csvDataArr, index++);     // 商品区分
                    work.GoodsRateRank = ConvertToEmpty(csvDataArr, index++);           // 層別
                    work.GoodsKindCode = ConvertToEmpty(csvDataArr, index++);           // 純優区分
                    work.TaxationDivCd = ConvertToEmpty(csvDataArr, index++);           // 課税区分
                    work.GoodsNote1 = ConvertToEmpty(csvDataArr, index++);              // 商品備考１
                    work.GoodsNote2 = ConvertToEmpty(csvDataArr, index++);              // 商品備考２
                    work.GoodsSpecialNote = ConvertToEmpty(csvDataArr, index++);        // 商品規格・特記事項

                    work.PriceStartDate1 = ConvertToEmpty(csvDataArr, index++);       // 価格開始年月日１
                    work.ListPrice1 = ConvertToEmpty(csvDataArr, index++);              // 価格１
                    work.OpenPriceDiv1 = ConvertToEmpty(csvDataArr, index++);            // オープン価格区分１
                    work.StockRate1 = ConvertToEmpty(csvDataArr, index++);              // 仕入率１
                    work.SalesUnitCost1 = ConvertToEmpty(csvDataArr, index++);          // 原単価１

                    work.PriceStartDate2 = ConvertToEmpty(csvDataArr, index++);       // 価格開始年月日２
                    work.ListPrice2 = ConvertToEmpty(csvDataArr, index++);              // 価格２
                    work.OpenPriceDiv2 = ConvertToEmpty(csvDataArr, index++);            // オープン価格区分２
                    work.StockRate2 = ConvertToEmpty(csvDataArr, index++);              // 仕入率２
                    work.SalesUnitCost2 = ConvertToEmpty(csvDataArr, index++);          // 原単価２

                    work.PriceStartDate3 = ConvertToEmpty(csvDataArr, index++);       // 価格開始年月日３
                    work.ListPrice3 = ConvertToEmpty(csvDataArr, index++);              // 価格３
                    work.OpenPriceDiv3 = ConvertToEmpty(csvDataArr, index++);            // オープン価格区分３
                    work.StockRate3 = ConvertToEmpty(csvDataArr, index++);              // 仕入率３
                    work.SalesUnitCost3 = ConvertToEmpty(csvDataArr, index++);          // 原単価３

                    work.PriceStartDate4 = ConvertToEmpty(csvDataArr, index++);       // 価格開始年月日４
                    work.ListPrice4 = ConvertToEmpty(csvDataArr, index++);              // 価格４
                    work.OpenPriceDiv4 = ConvertToEmpty(csvDataArr, index++);            // オープン価格区分４
                    work.StockRate4 = ConvertToEmpty(csvDataArr, index++);              // 仕入率４
                    work.SalesUnitCost4 = ConvertToEmpty(csvDataArr, index++);          // 原単価４

                    work.PriceStartDate5 = ConvertToEmpty(csvDataArr, index++);       // 価格開始年月日５
                    work.ListPrice5 = ConvertToEmpty(csvDataArr, index++);              // 価格５
                    work.OpenPriceDiv5 = ConvertToEmpty(csvDataArr, index++);            // オープン価格区分５
                    work.StockRate5 = ConvertToEmpty(csvDataArr, index++);              // 仕入率５
                    work.SalesUnitCost5 = ConvertToEmpty(csvDataArr, index++);          // 原単価５

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        // ------------ADD END wangf 2012/06/12 FOR Redmine#30387---------<<<<

        #region ◎ 数値項目へ変換処理
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int32 ConvertToInt32(string[] csvDataArr, Int32 index)
        {
            Int32 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt32(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }

            return retNum;
        }

        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private double ConvertToDouble(string[] csvDataArr, Int32 index)
        {
            double reDouble = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    reDouble = Convert.ToDouble(csvDataArr[index]);
                }
                catch
                {
                    reDouble = 0;
                }
            }

            return reDouble;
        }
        #endregion

        #region ◎ 日時項目へ変換処理
        /// <summary>
        /// 日時項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した日時</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は最小日時へ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private DateTime ConvertToDateTime(string[] csvDataArr, Int32 index)
        {
            DateTime retDt = DateTime.MinValue;

            if (index < csvDataArr.Length)
            {
                Int32 tmpNumber = ConvertToInt32(csvDataArr, index);
                if (tmpNumber != 0)
                {
                    retDt = TDateTime.LongDateToDateTime(tmpNumber);
                }
            }

            return retDt;
        }
        #endregion

        #region ◎ 空白項目へ変換処理
        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        #endregion
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="errorLogFileName">エラーログ出力ファイルバス</param>
        /// <param name="table">データテーブル</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName, DataTable table)
        {
            int status = 0;

            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = ERROR_LOG_FILENAME;
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            // 出力パスと名前
            customTextProviderInfo.OutPutFileName = errorLogFileName;

            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = false;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            // データソースを設定
            DataSet dsOutData = new DataSet();
            DataView dv = table.DefaultView;
            dsOutData.Tables.Add(dv.ToTable());

            try
            {
                status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = -1;
            }
            dsOutData.Tables.Clear();

            return status;
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
        #region エラーデータテーブル関する
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  商品番号
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  商品メーカーコード
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  商品名称
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  商品名称カナ
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JANコード

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL商品コード
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // 自社分類コード
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  商品掛率ランク
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(string));            //  商品属性
            dataTable.Columns.Add("TaxationDivCdRF", typeof(string));            //  課税区分
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  商品備考１
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  商品備考２
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  商品規格・特記事項

            dataTable.Columns.Add("PriceStartDateRF1", typeof(string));           //  価格開始日１
            dataTable.Columns.Add("ListPriceRF1", typeof(string));                //  定価（浮動）１
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(string));             //  オープン価格区分１
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  仕入率１
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  原価単価１

            dataTable.Columns.Add("PriceStartDateRF2", typeof(string));           //  価格開始日２
            dataTable.Columns.Add("ListPriceRF2", typeof(string));                //  定価（浮動）２
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(string));             //  オープン価格区分２
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  仕入率２
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  原価単価２

            dataTable.Columns.Add("PriceStartDateRF3", typeof(string));           //  価格開始日３
            dataTable.Columns.Add("ListPriceRF3", typeof(string));                //  定価（浮動）３
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(string));             //  オープン価格区分３
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  仕入率３
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  原価単価３

            dataTable.Columns.Add("PriceStartDateRF4", typeof(string));           //  価格開始日４
            dataTable.Columns.Add("ListPriceRF4", typeof(string));                //  定価（浮動）４
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(string));             //  オープン価格区分４
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  仕入率４
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  原価単価４

            dataTable.Columns.Add("PriceStartDateRF5", typeof(string));           //  価格開始日５
            dataTable.Columns.Add("ListPriceRF5", typeof(string));                //  定価（浮動）５
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(string));             //  オープン価格区分５
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  仕入率５
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  原価単価５

            dataTable.Columns.Add("ErrorMessage", typeof(string));            //  エラー内容
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsUWork">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsUGoodsPriceUWork goodsUWork, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["GoodsNoRF"] = goodsUWork.GoodsNo;
            dataRow["GoodsMakerCdRF"] = goodsUWork.GoodsMakerCd;
            dataRow["GoodsNameRF"] = goodsUWork.GoodsName;
            dataRow["GoodsNameKanaRF"] = goodsUWork.GoodsNameKana;
            dataRow["JanRF"] = goodsUWork.Jan;
            dataRow["BLGoodsCodeRF"] = goodsUWork.BLGoodsCode;
            dataRow["EnterpriseGanreCodeRF"] = goodsUWork.EnterpriseGanreCode;
            dataRow["GoodsRateRankRF"] = goodsUWork.GoodsRateRank;
            dataRow["GoodsKindCodeRF"] = goodsUWork.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUWork.TaxationDivCd;
            dataRow["GoodsNote1RF"] = goodsUWork.GoodsNote1;
            dataRow["GoodsNote2RF"] = goodsUWork.GoodsNote2;
            dataRow["GoodsSpecialNoteRF"] = goodsUWork.GoodsSpecialNote;
            Type type = goodsUWork.GetType();
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                dataRow["PriceStartDateRF" + index] = type.GetProperty("PriceStartDate" + index).GetValue(goodsUWork, null);
                dataRow["ListPriceRF" + index] = type.GetProperty("ListPrice" + index).GetValue(goodsUWork, null);
                dataRow["OpenPriceDivRF" + index] = type.GetProperty("OpenPriceDiv" + index).GetValue(goodsUWork, null);
                dataRow["StockRateRF" + index] = type.GetProperty("StockRate" + index).GetValue(goodsUWork, null);
                dataRow["SalesUnitCostRF" + index] = type.GetProperty("SalesUnitCost" + index).GetValue(goodsUWork, null);
            }
            dataRow["ErrorMessage"] = goodsUWork.ErrorMsg;
            dataTable.Rows.Add(dataRow);
        }
        #endregion
        // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<

        #endregion ■ Private Method
    }
}
