//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/06/13  修正内容 : 大陽案件、Redmine#30391 在庫マスタインボートチェックの追加//
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/03  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加//
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/05  修正内容 : 大陽案件、Redmine#30387障害一覧の指摘NO.19の対応//
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応//
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using System.Text.RegularExpressions;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Update Note: 2012/07/20 zhangy3 </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
    /// </remarks>
    public class StockImportAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 在庫マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public StockImportAcs()
        {
            /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
            this._iStockDB = (IStockDB)MediationStockDB.GetStockDB();
            this._iStockAdjustDB = MediationStockAdjustDB.GetStockAdjustDB();
             * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
            //インポートDBリモート
            this._iStockImportDB = MediationStockImportDB.GetStockImportDB();
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
            this._secInfoAcs = new SecInfoAcs();

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //ログイン拠点名称
            //this._loginSectionGuideNm = LoginInfoAcquisition.Employee.BelongSectionName;
            this._loginSectionGuideNm = this.LoadSecInfoSet();

            //ログイン従業員コード
            this._employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            //ログイン従業員名称
            this._employeeName = LoginInfoAcquisition.Employee.Name;

            this._goodsAcs = new GoodsAcs();

            _warehouseAcs = new WarehouseAcs();

            //倉庫マスタのローカルキャッシュ
            CacheWarehouseData();

            //拠点マスタのローカルキャッシュ
            CacheSecInfoSetData();
        }

        /// <summary>
        /// 在庫マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static StockImportAcs()
        {

        }
        #endregion ■ Constructor

        #region ■ Static Member

        #endregion ■ Static Member

        #region ■ Private Member
        /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        // 在庫データ
        private IStockDB _iStockDB;

        // 在庫調整データ
        private IStockAdjustDB _iStockAdjustDB;
        * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/

        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        //在庫マスタインポートデータ
        private IStockImportDB _iStockImportDB;//
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        private string _enterpriseCode;
        private string _loginSectionCode;
        private string _loginSectionGuideNm;
        private string _employeeCode;
        private string _employeeName;

        // 拠点アクセスクラス
        private SecInfoAcs _secInfoAcs = null;


        // 商品マスタアクセス
        private GoodsAcs _goodsAcs;

        /// <summary>価格情報マスタキャッシュ</summary>
        private static List<List<GoodsUnitData>> _goodsUnitDataListList;

        //倉庫マスタアクセス
        private WarehouseAcs _warehouseAcs;
        Dictionary<string, Warehouse> _warehouseDic;

        Dictionary<string, SecInfoSet> _secInfoSetDic;

        #endregion ■ Private Member

        #region ■ Const Member

        #endregion ■ Const Member

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
        /// <param name="logPath">エラーログのファイル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        //public int Import(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, string logPath, out string errMsg)//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
        public int Import(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, string logPath, out string errMsg)//ADD ZHANGY3 2012/06/13 FOR REDMINE#30391
        {
            //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt,logPath, out errMsg);//ADD ZHANGY3 2012/06/13 FOR REDMINE#30391
        }
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        /// <summary>
        /// 在庫マスタ（インポート）処理を行う。
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="logPath">エラーログのファイル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012.06.13</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt,string logPath, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //DataTable errTable=new DataTable();//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            object errStockCheckWorks = null; //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            errMsg = string.Empty;
            try
            {
                ArrayList importWorkList = null;
                ArrayList importWorkCheckList = null;
                // インポートワークの変換処理
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList,out importWorkCheckList, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    object objImportWork = (object)importWorkList;
                    object objImportWorkCheck = (object)importWorkCheckList;
                    //インポートの実行
                    //status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errTable, out errMsg);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    //status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                    status = _iStockImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.DataCheckKbn, ref objImportWork, ref objImportWorkCheck, this._enterpriseCode, this._loginSectionCode, this._loginSectionGuideNm, this._employeeCode, this._employeeName, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                }
                //csv出力処理
                //if (null != errTable && errTable.Rows.Count != 0)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                if (null != errStockCheckWorks)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                {
                    //DoOutPut(logPath, errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    DoOutPut(logPath, errStockCheckWorks);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="errorLogFileName">エラーファイル名</param>
        /// <param name="errStockCheckWorks">エラー在庫マスタチェックリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        //private int DoOutPut(string errorLogFileName, DataTable table)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        private int DoOutPut(string errorLogFileName, object errStockCheckWorks)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
        {
            int status = 0;

            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
            DataTable table = new DataTable();
            CreateDataTable(ref table);
            ArrayList arrList =(ArrayList) errStockCheckWorks;
            InsertDataIntoTable(arrList, ref table);
            if (table.Rows.Count == 0)
                return status;
            //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<
            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = "PMKHN07600U_ERRORLOG.xml";
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
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387   --------------->>>>>>     
        # region OutPut Table
        /// <summary>
        /// テーブルに値を追加
        /// </summary>
        /// <param name="workList">エラーリスト</param>
        /// <param name="errTable">エラーテーブル</param>
        /// <remarks>
        /// <br>Note       : テーブルに値を追加</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void InsertDataIntoTable(ArrayList workList, ref DataTable errTable)
        {
            foreach (StockCheckWork stockCheckWork in workList)
            {
                DataRow dr = errTable.NewRow();
                //----- 在庫マスタの内容をテーブルに追加する -----
                //拠点コード
                dr["SectionCode"] = stockCheckWork.SectionCode;
                
                //倉庫コード
                dr["WarehouseCode"] = stockCheckWork.WarehouseCode;

                //商品メーカーコード
                dr["GoodsMakerCd"] = stockCheckWork.GoodsMakerCd;

                //商品番号
                dr["GoodsNo"] = stockCheckWork.GoodsNo;

                //仕入単価（税抜,浮動）
                dr["StockUnitPriceFl"] = stockCheckWork.StockUnitPriceFl;

                //仕入在庫数
                dr["SupplierStock"] = stockCheckWork.SupplierStock;

                //入荷数（未計上）
                dr["ArrivalCnt"] = stockCheckWork.ArrivalCnt;

                //出荷数（未計上）
                dr["ShipmentCnt"] = stockCheckWork.ShipmentCnt;

                //受注数
                dr["AcpOdrCount"] = stockCheckWork.AcpOdrCount;

                //移動中仕入在庫数
                dr["MovingSupliStock"] = stockCheckWork.MovingSupliStock;

                //出荷可能数
                dr["ShipmentPosCnt"] = stockCheckWork.ShipmentPosCnt;

                //発注数
                dr["SalesOrderCount"] = stockCheckWork.SalesOrderCount;

                //在庫区分
                dr["StockDiv"] = stockCheckWork.StockDiv;

                //最低在庫数
                dr["MinimumStockCnt"] = stockCheckWork.MinimumStockCnt;

                //最高在庫数
                dr["MaximumStockCnt"] = stockCheckWork.MaximumStockCnt;

                //発注単位
                dr["SalesOrderUnit"] = stockCheckWork.SalesOrderUnit;

                //在庫発注先コード
                dr["StockSupplierCode"] = stockCheckWork.StockSupplierCode;

                //倉庫棚番
                dr["WarehouseShelfNo"] = stockCheckWork.WarehouseShelfNo;

                //重複棚番１
                dr["DuplicationShelfNo1"] = stockCheckWork.DuplicationShelfNo1;

                //重複棚番２
                dr["DuplicationShelfNo2"] = stockCheckWork.DuplicationShelfNo2;

                //部品管理区分１
                dr["PartsManagementDivide1"] = stockCheckWork.PartsManagementDivide1;

                //部品管理区分２
                dr["PartsManagementDivide2"] = stockCheckWork.PartsManagementDivide2;

                //在庫備考１
                dr["StockNote1"] = stockCheckWork.StockNote1;

                //在庫備考２
                dr["StockNote2"] = stockCheckWork.StockNote2;

                //----- エラーメッセージを追加する -----
                //メッセージ
                dr["ErrMsg"] = stockCheckWork.ERRMESSAGE;

                errTable.Rows.Add(dr);
            }
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            //拠点コード
            dataTable.Columns.Add("SectionCode", typeof(string));

            //倉庫コード
            dataTable.Columns.Add("WarehouseCode", typeof(string));

            //商品メーカーコード
            dataTable.Columns.Add("GoodsMakerCd", typeof(string));

            //商品番号
            dataTable.Columns.Add("GoodsNo", typeof(string));

            //仕入単価（税抜,浮動）
            dataTable.Columns.Add("StockUnitPriceFl", typeof(string));

            //仕入在庫数
            dataTable.Columns.Add("SupplierStock", typeof(string));

            //入荷数（未計上）
            dataTable.Columns.Add("ArrivalCnt", typeof(string));

            //出荷数（未計上）
            dataTable.Columns.Add("ShipmentCnt", typeof(string));

            //受注数
            dataTable.Columns.Add("AcpOdrCount", typeof(string));

            //移動中仕入在庫数
            dataTable.Columns.Add("MovingSupliStock", typeof(string));

            //出荷可能数
            dataTable.Columns.Add("ShipmentPosCnt", typeof(string));

            //発注数
            dataTable.Columns.Add("SalesOrderCount", typeof(string));

            //在庫区分
            dataTable.Columns.Add("StockDiv", typeof(string));

            //最低在庫数
            dataTable.Columns.Add("MinimumStockCnt", typeof(string));

            //最高在庫数
            dataTable.Columns.Add("MaximumStockCnt", typeof(string));

            //発注単位
            dataTable.Columns.Add("SalesOrderUnit", typeof(string));

            //在庫発注先コード
            dataTable.Columns.Add("StockSupplierCode", typeof(string));

            //倉庫棚番
            dataTable.Columns.Add("WarehouseShelfNo", typeof(string));

            //重複棚番１
            dataTable.Columns.Add("DuplicationShelfNo1", typeof(string));

            //重複棚番２
            dataTable.Columns.Add("DuplicationShelfNo2", typeof(string));

            //部品管理区分１
            dataTable.Columns.Add("PartsManagementDivide1", typeof(string));

            //部品管理区分２
            dataTable.Columns.Add("PartsManagementDivide2", typeof(string));

            //在庫備考１
            dataTable.Columns.Add("StockNote1", typeof(string));

            //在庫備考２
            dataTable.Columns.Add("StockNote2", typeof(string));

            //メッセージ
            dataTable.Columns.Add("ErrMsg", typeof(string));

        }
        # endregion
        //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387   ---------------<<<<<<
        /* DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        #region ◎ 在庫マスタ（インポート）のインポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_StockImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            try
            {
                ArrayList importWorkList = null;

                // 在庫マスタ追加リスト
                ArrayList addList = new ArrayList();
                // 在庫マスタ更新リスト
                ArrayList updList = new ArrayList();

                // インポートワークの変換処理
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    // 在庫情報全てデータの検索処理

                    ArrayList stockWorkList = new ArrayList();

                    object objectstockWork = stockWorkList as object;

                    StockWork stockWork = new StockWork();

                    stockWork.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    object objectparastockWork = stockWork as object;

                    status = this._iStockDB.Search(out objectstockWork, objectparastockWork, 0, ConstantManagement.LogicalMode.GetData01);

                    stockWorkList = objectstockWork as ArrayList;

                    // Dictionaryの作成
                    Dictionary<StockSearchUImportWorkWrap, StockWork> dict = new Dictionary<StockSearchUImportWorkWrap, StockWork>();

                    foreach (StockWork work in stockWorkList)
                    {
                        work.WarehouseCode = work.WarehouseCode.Trim();
                        StockSearchUImportWorkWrap warp = new StockSearchUImportWorkWrap(work);
                        dict.Add(warp, work);
                    }

                    foreach (StockWork importWork in importWorkList)
                    {
                        StockSearchUImportWorkWrap importWarp = new StockSearchUImportWorkWrap(importWork);

                        if (!dict.ContainsKey(importWarp))
                        {
                            // レコードが存在しなければ、追加リストへ追加する。
                            addList.Add(ConvertToImportWork(importWork, null, false));
                        }
                        else
                        {
                            // レコードが存在すれば、更新リストへ追加する。
                            updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                        }
                    }

                    // 読込件数
                    readCnt = importWorkList.Count;

                    CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

                    // 処理区分が「追加」の場合
                    if (importWorkTbl.ProcessKbn == 1)
                    {
                        if (addList.Count > 0)
                        {
                            saveDataList = this.CreateSaveData(addList, new ArrayList(), dict);

                            object objSaveData = (object)saveDataList;

                            status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                        }
                    }
                    else if (importWorkTbl.ProcessKbn == 2)
                    {
                        // 処理区分が「更新」の場合
                        if (updList.Count > 0)
                        {
                            saveDataList = this.CreateSaveData(new ArrayList(), updList, dict);

                            object objSaveData = (object)saveDataList;

                            status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = updList.Count;
                        }
                    }
                    else
                    {
                        // 処理区分が「追加更新」の場合

                        saveDataList = this.CreateSaveData(addList, updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = _iStockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }

                }
                else
                {
                    //
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
        * DEL ZHANGY3  2012/06/13 FOR REDMINE#30391 ---------------<<<<<<*/

        #region ◆ データ変換処理
        #region ◎ インポートワークの変換処理
        /// <summary>
        /// インポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="importWorkCheckList">リモート用のインポートチェックワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : インポートワークの変換処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        //private int ConvertToImportWorkList(ExtrInfo_StockImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)//DEL ZHANGY3  2012/06/13 FOR REDMINE#30391
        private int ConvertToImportWorkList(ExtrInfo_StockImportWorkTbl importWorkTbl, out ArrayList importWorkList,out ArrayList importWorkCheckList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            importWorkCheckList = new ArrayList();//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391
            StockWork work = null;
            StockCheckWork workCheck = null;//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new StockWork();
                    workCheck = new StockCheckWork();//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391
                    int index = 0;
                    work.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    //拠点コード
                    //workCheck.SectionCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SectionCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SectionCode = ConvertToStrCode(csvDataArr, index++, 2);
                    //倉庫コード
                    //workCheck.WarehouseCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.WarehouseCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.WarehouseCode = ConvertToStrCode(csvDataArr, index++, 4);
                    //商品メーカーコード
                    //workCheck.GoodsMakerCd = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.GoodsMakerCd = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.GoodsMakerCd = ConvertToInt32(csvDataArr, index++);
                    //商品番号
                    //workCheck.GoodsNo = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.GoodsNo = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);
                    //仕入単価（税抜,浮動）
                    //workCheck.StockUnitPriceFl = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockUnitPriceFl = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockUnitPriceFl = ConvertToDouble(csvDataArr, index++);
                    //仕入在庫数
                    //workCheck.SupplierStock = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SupplierStock = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SupplierStock = ConvertToDouble(csvDataArr, index++);
                    //入荷数（未計上）
                    //workCheck.ArrivalCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ArrivalCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ArrivalCnt = ConvertToDouble(csvDataArr, index++);
                    //出荷数（未計上）
                    //workCheck.ShipmentCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ShipmentCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ShipmentCnt = ConvertToDouble(csvDataArr, index++);
                    //受注数
                    //workCheck.AcpOdrCount = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.AcpOdrCount = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.AcpOdrCount = ConvertToDouble(csvDataArr, index++);
                    //移動中仕入在庫数
                    //workCheck.MovingSupliStock = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MovingSupliStock = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MovingSupliStock = ConvertToDouble(csvDataArr, index++);
                    //出荷可能数
                    //workCheck.ShipmentPosCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.ShipmentPosCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.ShipmentPosCnt = ConvertToDouble(csvDataArr, index++);
                    //発注数
                    //workCheck.SalesOrderCount = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SalesOrderCount = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SalesOrderCount = ConvertToDouble(csvDataArr, index++);
                    //在庫区分
                    //workCheck.StockDiv = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockDiv = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockDiv = ConvertToInt32(csvDataArr, index++);
                    //最低在庫数
                    //workCheck.MinimumStockCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MinimumStockCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MinimumStockCnt = ConvertToDouble(csvDataArr, index++);
                    //最高在庫数
                    //workCheck.MaximumStockCnt = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.MaximumStockCnt = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.MaximumStockCnt = ConvertToDouble(csvDataArr, index++);
                    //発注単位
                    //workCheck.SalesOrderUnit = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.SalesOrderUnit = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.SalesOrderUnit = ConvertToInt32(csvDataArr, index++);
                    //在庫発注先コード
                    //workCheck.StockSupplierCode = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockSupplierCode = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockSupplierCode = ConvertToInt32(csvDataArr, index++);
                    //倉庫棚番
                    //workCheck.WarehouseShelfNo = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.WarehouseShelfNo = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.WarehouseShelfNo = ConvertToEmpty(csvDataArr, index++);
                    //重複棚番１
                    //workCheck.DuplicationShelfNo1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.DuplicationShelfNo1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.DuplicationShelfNo1 = ConvertToEmpty(csvDataArr, index++);
                    //重複棚番２
                    //workCheck.DuplicationShelfNo2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.DuplicationShelfNo2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.DuplicationShelfNo2 = ConvertToEmpty(csvDataArr, index++);
                    //部品管理区分１
                    //workCheck.PartsManagementDivide1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.PartsManagementDivide1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.PartsManagementDivide1 = ConvertToEmpty(csvDataArr, index++);
                    //部品管理区分２
                    //workCheck.PartsManagementDivide2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.PartsManagementDivide2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.PartsManagementDivide2 = ConvertToEmpty(csvDataArr, index++);
                    //在庫備考１
                    //workCheck.StockNote1 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockNote1 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockNote1 = ConvertToEmpty(csvDataArr, index++);
                    //在庫備考２
                    //workCheck.StockNote2 = csvDataArr[index];//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
                    workCheck.StockNote2 = ConvertToEmpty(csvDataArr, index);//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
                    work.StockNote2 = ConvertToEmpty(csvDataArr, index++);
                    importWorkCheckList.Add(workCheck);//ADD ZHANGY3  2012/06/13 FOR REDMINE#30391

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

        #region ◎ 数値項目へ変換処理
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 張凱</br>
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
        /// <param name="csvDataArr">数値項目の文字</param>
        /// <param name="index">数値項目の文字</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 数値項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int64 ConvertToInt64(string[] csvDataArr, Int32 index)
        {
            Int64 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt64(csvDataArr[index]);
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

        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 張凱</br>
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

        /// <summary>
        /// コード文字列項目の変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <param name="maxLength">MAX桁数</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : コード文字列項目の変換処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToStrCode(string[] csvDataArr, Int32 index, Int32 maxLength)
        {
            return ConvertToEmpty(csvDataArr, index).PadLeft(maxLength, '0');
        }
        #endregion

        #region ◎ DB登録用のオブジェクトの作成
        /// <summary>
        /// DB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private StockWork ConvertToImportWork(StockWork csvWork, StockWork searchWork, bool isUpdFlg)
        {
            StockWork importWork = new StockWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = System.DateTime.Now;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 有効
                importWork.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                importWork.UpdAssemblyId1 = searchWork.UpdAssemblyId1;
                importWork.UpdAssemblyId2 = searchWork.UpdAssemblyId2;

                //M/O発注数
                importWork.MonthOrderCount = searchWork.MonthOrderCount;
                //在庫保有総額
                importWork.StockTotalPrice = searchWork.StockTotalPrice;
                //最終仕入年月日
                importWork.LastStockDate = searchWork.LastStockDate;
                //最終売上日
                importWork.LastSalesDate = searchWork.LastSalesDate;
                //最終棚卸更新日
                importWork.LastInventoryUpdate = searchWork.LastInventoryUpdate;
                //基準発注数
                importWork.NmlSalOdrCount = searchWork.NmlSalOdrCount;
                //ハイフン無商品番号
                importWork.GoodsNoNoneHyphen = searchWork.GoodsNoNoneHyphen;
                //在庫登録日
                importWork.StockCreateDate = searchWork.StockCreateDate;

            }
            else
            {

                //M/O発注数
                importWork.MonthOrderCount = 0;
                //在庫保有総額
                importWork.StockTotalPrice = 0;
                //最終仕入年月日
                //importWork.LastStockDate = 0;
                //最終売上日
                //importWork.LastSalesDate = 0;
                //最終棚卸更新日
                //importWork.LastInventoryUpdate = 0;
                //基準発注数
                importWork.NmlSalOdrCount = 0;
                //ハイフン無商品番号
                importWork.GoodsNoNoneHyphen = string.Empty;
                //在庫登録日
                importWork.StockCreateDate = System.DateTime.Now;
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                  // 企業コード

            //拠点コード
            importWork.SectionCode = csvWork.SectionCode;
            //倉庫コード
            importWork.WarehouseCode = csvWork.WarehouseCode;
            //商品メーカーコード
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;
            //商品番号
            importWork.GoodsNo = csvWork.GoodsNo;
            //仕入単価（税抜,浮動）
            importWork.StockUnitPriceFl = csvWork.StockUnitPriceFl;
            //仕入在庫数
            importWork.SupplierStock = csvWork.SupplierStock;
            //受注数
            importWork.AcpOdrCount = csvWork.AcpOdrCount;
            //発注数
            importWork.SalesOrderCount = csvWork.SalesOrderCount;
            //在庫区分
            importWork.StockDiv = csvWork.StockDiv;
            //移動中仕入在庫数
            importWork.MovingSupliStock = csvWork.MovingSupliStock;
            //出荷可能数
            importWork.ShipmentPosCnt = csvWork.ShipmentPosCnt;
            //最低在庫数
            importWork.MinimumStockCnt = csvWork.MinimumStockCnt;
            //最高在庫数
            importWork.MaximumStockCnt = csvWork.MaximumStockCnt;
            //発注単位
            importWork.SalesOrderUnit = csvWork.SalesOrderUnit;
            //在庫発注先コード
            importWork.StockSupplierCode = csvWork.StockSupplierCode;
            //倉庫棚番
            importWork.WarehouseShelfNo = csvWork.WarehouseShelfNo;
            //重複棚番１
            importWork.DuplicationShelfNo1 = csvWork.DuplicationShelfNo1;
            //重複棚番２
            importWork.DuplicationShelfNo2 = csvWork.DuplicationShelfNo2;
            //部品管理区分１
            importWork.PartsManagementDivide1 = csvWork.PartsManagementDivide1;
            //部品管理区分２
            importWork.PartsManagementDivide2 = csvWork.PartsManagementDivide2;
            //在庫備考１
            importWork.StockNote1 = csvWork.StockNote1;
            //在庫備考２
            importWork.StockNote2 = csvWork.StockNote2;
            //出荷数（未計上）
            importWork.ShipmentCnt = csvWork.ShipmentCnt;
            //入荷数（未計上）
            importWork.ArrivalCnt = csvWork.ArrivalCnt;
            //更新年月日
            importWork.UpdateDate = System.DateTime.Now;

            return importWork;
        }

        #endregion

        #region ◎ 保存用データの作成

        /// <summary>
        /// 保存用データ生成処理
        /// </summary>
        /// <returns>保存用データ(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : 保存用データを作成します。</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(ArrayList addList, ArrayList updList, Dictionary<StockSearchUImportWorkWrap, StockWork> dict)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

            //商品検索条件
            ArrayList searchList = new ArrayList();
            if (null != updList && updList.Count > 0)
            {
                searchList.AddRange(updList.GetRange(0, updList.Count));
            }
            if (null != addList && addList.Count > 0)
            {
                searchList.AddRange(addList.GetRange(0, addList.Count));
            }
            SetCacheGoodsUnitDataList(searchList);

            //更新の処理
            foreach (StockWork updWork in updList)
            {
                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();
                ArrayList dataList = new ArrayList();
                CustomSerializeArrayList tempList = new CustomSerializeArrayList();

                StockSearchUImportWorkWrap updWarp = new StockSearchUImportWorkWrap(updWork);

                updWork.SupplierStock = updWork.SupplierStock - dict[updWarp].SupplierStock;
                double adjustCount = updWork.SupplierStock;
                updWork.AcpOdrCount = updWork.AcpOdrCount - dict[updWarp].AcpOdrCount;
                updWork.SalesOrderCount = updWork.SalesOrderCount - dict[updWarp].SalesOrderCount;
                updWork.MovingSupliStock = updWork.MovingSupliStock - dict[updWarp].MovingSupliStock;
                updWork.ShipmentCnt = updWork.ShipmentCnt - dict[updWarp].ShipmentCnt;
                updWork.ArrivalCnt = updWork.ArrivalCnt - dict[updWarp].ArrivalCnt;

                if (Math.Abs(updWork.SupplierStock) != 0)
                {
                    GoodsPrice goodsPriceUp;
                    GoodsUnitData goodsUnitDataUp;

                    // 価格情報の取得
                    GetListPrice(updWork, out goodsPriceUp, out goodsUnitDataUp);
                    //在庫調整
                    StockAdjustWork targetStockAdjustWorkUp = CreateStockAdjust(updWork);
                    //在庫調整明細
                    Int64 wkStockSubttlPriceUp = CreateStockAdjustDtl(ref stockAdjustDtlWorkList, updWork, adjustCount, goodsPriceUp, goodsUnitDataUp);

                    // 仕入金額小計算出
                    targetStockAdjustWorkUp.StockSubttlPrice = wkStockSubttlPriceUp;
                    stockAdjustWorkList.Add(targetStockAdjustWorkUp);
                }

                if (stockAdjustWorkList.Count > 0)
                {
                    // 在庫調整データ追加
                    tempList.Add(stockAdjustWorkList);
                }

                if (stockAdjustDtlWorkList.Count > 0)
                {
                    // 在庫調整明細データ追加
                    tempList.Add(stockAdjustDtlWorkList);
                }

                if (updList.Count > 0)
                {
                    dataList.Add(updWork);
                }

                if (dataList.Count > 0)
                {
                    // 在庫マスタ追加
                    tempList.Add(dataList);
                }

                saveDataList.Add(tempList);
            }

            //新規の処理
            foreach (StockWork addwork in addList)
            {
                ArrayList stockAdjustWorkListIt = new ArrayList();
                ArrayList stockAdjustDtlWorkListIt = new ArrayList();
                ArrayList dataListIt = new ArrayList();
                CustomSerializeArrayList tempListIt = new CustomSerializeArrayList();

                if (!string.IsNullOrEmpty(addwork.SupplierStock.ToString()) && addwork.SupplierStock > 0)
                {
                    GoodsPrice goodsPriceIt;
                    GoodsUnitData goodsUnitDataIt;

                    // 価格情報の取得
                    GetListPrice(addwork, out goodsPriceIt, out goodsUnitDataIt);
                    //在庫調整
                    StockAdjustWork targetStockAdjustWorkIt = CreateStockAdjust(addwork);
                    //在庫調整明細
                    Int64 wkStockSubttlPriceIt = CreateStockAdjustDtl(ref stockAdjustDtlWorkListIt, addwork, addwork.SupplierStock, goodsPriceIt, goodsUnitDataIt);
                    // 仕入金額小計算出
                    targetStockAdjustWorkIt.StockSubttlPrice = wkStockSubttlPriceIt;
                    stockAdjustWorkListIt.Add(targetStockAdjustWorkIt);
                }

                if (stockAdjustWorkListIt.Count > 0)
                {
                    // 在庫調整データ追加
                    tempListIt.Add(stockAdjustWorkListIt);
                }

                if (stockAdjustDtlWorkListIt.Count > 0)
                {
                    // 在庫調整明細データ追加
                    tempListIt.Add(stockAdjustDtlWorkListIt);
                }

                if (addList.Count > 0)
                {
                    dataListIt.Add(addwork);
                }

                if (dataListIt.Count > 0)
                {
                    // 在庫マスタ追加
                    tempListIt.Add(dataListIt);
                }

                saveDataList.Add(tempListIt);
            }

            return saveDataList;
        }

        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="stockWork">処理区分</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(StockWork stockWork)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode;
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 受払元伝票区分(42：マスタメンテ)
            workData.AcPaySlipCd = 42;
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = DateTime.Today;
            // 入力日付
            workData.InputDay = DateTime.Today;
            // 仕入拠点コード
            workData.StockSectionCd = stockWork.SectionCode;
            // 仕入拠点名称
            workData.StockSectionGuideNm = GetSectionName(stockWork.SectionCode);
            // 仕入入力者コード
            workData.StockInputCode = this._employeeCode;
            // 仕入担当者コード
            workData.StockAgentCode = this._employeeCode;
            if (this._employeeName.Length > 16)
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName.Substring(0, 16);
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName.Substring(0, 16);
            }
            else
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName;
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName;
            }

            return workData;
        }

        /// <summary>
        /// 在庫調整明細データワーククラス生成処理
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">処理区分</param>
        /// <param name="work">処理日付</param>
        /// <param name="adjustCount">在庫調整明細データパラメター</param>
        /// <param name="goodsPrice">在庫調整明細データパラメター</param>
        /// <param name="goodsUnitData">在庫調整明細データパラメター</param>
        /// <returns>在庫調整明細データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラスを生成します。</br>
        /// </remarks>
        private Int64 CreateStockAdjustDtl(ref ArrayList stockAdjustDtlWorkList, StockWork work, double adjustCount,
            GoodsPrice goodsPrice, GoodsUnitData goodsUnitData)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();
            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode; ;
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            workData.StockAdjustRowNo = stockAdjustDtlWorkList.Count + 1;
            // 受払元伝票区分(42：マスタメンテ)
            workData.AcPaySlipCd = 42;
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = DateTime.Today;
            // 入力日付
            workData.InputDay = DateTime.Today;
            // メーカーコード
            workData.GoodsMakerCd = work.GoodsMakerCd;
            // 商品番号
            workData.GoodsNo = work.GoodsNo;
            //調整数
            workData.AdjustCount = adjustCount;
            // 倉庫コード
            workData.WarehouseCode = work.WarehouseCode;
            // メーカー名称
            workData.MakerName = goodsUnitData.MakerName;
            //商品名称
            workData.GoodsName = goodsUnitData.GoodsName;
            //仕入単価（税抜,浮動）
            workData.StockUnitPriceFl = goodsPrice.SalesUnitCost;
            //変更前仕入単価（浮動）
            workData.BfStockUnitPriceFl = goodsPrice.SalesUnitCost;
            //定価（浮動）
            workData.ListPriceFl = goodsPrice.ListPrice;
            //BL商品コード
            workData.BLGoodsCode = goodsUnitData.BLGoodsCode;
            //BL商品コード名称（全角）
            workData.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
            // 倉庫名称
            workData.WarehouseName = GetWarehouseName(work.WarehouseCode);
            // 倉庫棚番
            workData.WarehouseShelfNo = work.WarehouseShelfNo;
            //オープン価格区分
            workData.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            // 仕入金額（税抜き）
            Int64 wkStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
            if ((wkStockPrice % 100) >= 50) wkStockPrice = (wkStockPrice / 100) + 1;
            else if ((wkStockPrice % 100) <= -50) wkStockPrice = (wkStockPrice / 100) - 1;
            else wkStockPrice = wkStockPrice / 100;
            workData.StockPriceTaxExc = wkStockPrice;
            stockAdjustDtlWorkList.Add(workData);

            return wkStockPrice;
        }

        #endregion

        #endregion

        #endregion ■ Private Method

        #region 拠点情報マスタ読込処理
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        private string LoadSecInfoSet()
        {
            SecInfoSet secInfoSet;

            int status = this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            string sectionName = string.Empty;
            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }

            return sectionName;
        }
        #endregion

        #region 在庫検索情報オブジェクト
        /// <summary>
        /// 在庫検索情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫検索情報オブジェクトです。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        class StockSearchUImportWorkWrap
        {
            #region Public Field
            public StockWork stockWork;
            #endregion

            #region クラスコンストラクタ
            /// <summary>
            /// 在庫検索情報オブジェクト
            /// </summary>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクトを取得します。</br>
            /// <br>Programmer : 張凱</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public StockSearchUImportWorkWrap(StockWork stockWork)
            {
                this.stockWork = stockWork;
            }
            #endregion

            #region 結合検索情報オブジェクトのイコールの比較
            /// <summary>
            /// 在庫検索情報オブジェクトのイコールの比較
            /// </summary>
            /// <param name="obj">在庫検索情報オブジェクト</param>
            /// <returns>比較結果</returns>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクトのイコールかどうかを比較する。</br>
            /// <br>Programmer : 張凱</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override bool Equals(object obj)
            {
                StockSearchUImportWorkWrap target = obj as StockSearchUImportWorkWrap;
                if (target == null) return false;
                // 倉庫コード、商品番号、商品メーカーコード
                // が同じ場合、在庫情報オブジェクトはイコールにする。
                return target.stockWork.EnterpriseCode == stockWork.EnterpriseCode
                         && target.stockWork.WarehouseCode == stockWork.WarehouseCode
                         && target.stockWork.GoodsNo == stockWork.GoodsNo
                         && target.stockWork.GoodsMakerCd == stockWork.GoodsMakerCd;
            }
            #endregion

            #region 在庫検索情報オブジェクトのハシコード
            /// <summary>
            /// 在庫検索情報オブジェクトのハシコード
            /// </summary>
            /// <returns>ハシコード</returns>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクトのハシコードを設定する。</br>
            /// <br>Programmer : 張凱</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override int GetHashCode()
            {
                return stockWork.EnterpriseCode.GetHashCode()
                         + stockWork.WarehouseCode.GetHashCode()
                         + stockWork.GoodsNo.GetHashCode()
                         + stockWork.GoodsMakerCd.GetHashCode();
            }
            #endregion
        }
        #endregion

        #region 商品検索（セット情報取得）オブジェクト
        private void SetCacheGoodsUnitDataList(ArrayList printList)
        {
            GoodsAcs goodsAcs = new GoodsAcs();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            string message = "";
            goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            foreach (StockWork stockWork in printList)
            {
                // 商品アクセスクラスの抽出条件を設定
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                workGoodsCndtn.SectionCode = stockWork.SectionCode.Trim();
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = stockWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = stockWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                goodsCndtnList.Add(workGoodsCndtn);
            }

            // ローカルキャッシュ初期化
            _goodsUnitDataListList = new List<List<GoodsUnitData>>();

            // 結合検索無し完全一致で商品情報を取得
            int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _goodsUnitDataListList = null;
            }
        }

        #endregion

        #region 価格情報の取得
        /// <summary>
        /// 価格情報の取得
        /// </summary>
        /// <param name="stockWork">抽出結果</param>
        /// <param name="goodsPrice">抽出結果</param>
        /// <param name="goodsUnitData">抽出結果</param>
        /// <remarks>
        /// <br>Note       : 価格情報マスタを取得します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void GetListPrice(StockWork stockWork, out GoodsPrice goodsPrice, out GoodsUnitData goodsUnitData)
        {
            goodsPrice = new GoodsPrice();
            goodsUnitData = new GoodsUnitData();

            if (_goodsUnitDataListList == null)
            {
                return;
            }

            string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);

            foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
            {
                foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
                {
                    List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

                    foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
                    {
                        if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
                            (wkGoodsPrice.GoodsMakerCd == stockWork.GoodsMakerCd) &&
                            (wkGoodsPrice.GoodsNo == stockWork.GoodsNo))
                        {
                            goodsPrice = wkGoodsPrice.Clone();
                            goodsUnitData = wkGoodsUnitData.Clone();
                            return;
                        }
                    }
                }
            }
            return;
        }
        #endregion

        #region 価格情報の取得
        /// <summary>
        /// 倉庫マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void CacheWarehouseData()
        {
            int status;
            ArrayList retList;

            // 倉庫マスタのローカルキャッシュをクリア
            _warehouseDic = new Dictionary<string, Warehouse>();

            // 仕入先マスタの取得
            status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Warehouse wkWarehouse in retList)
                {
                    if (wkWarehouse.LogicalDeleteCode == 0)
                    {
                        string key = wkWarehouse.WarehouseCode.TrimEnd().PadLeft(4, '0');
                        if (_warehouseDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _warehouseDic.Remove(key);
                        }
                        _warehouseDic.Add(key, wkWarehouse);
                    }
                }
            }
        }

        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string name = string.Empty;

            string key = warehouseCode.TrimEnd().PadLeft(4, '0');
            if (_warehouseDic.ContainsKey(key))
            {
                name = _warehouseDic[key].WarehouseName;
            }

            return name;
        }

        /// <summary>
        /// 拠点マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private void CacheSecInfoSetData()
        {
            _secInfoSetDic = new Dictionary<string, SecInfoSet>();
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    _secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string name = string.Empty;

            if (string.IsNullOrEmpty(sectionCode))
            {
                name = string.Empty;
            }
            else
            {
                if (_secInfoSetDic.ContainsKey(sectionCode.Trim()))
                {
                    name = _secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
                }
            }

            return name;
        }
        #endregion
    }
}
