//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/07/17  修正内容 : 整合性チェック処理の仕様を追記
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/08/07  修正内容 :①整合性チェック処理の仕様を追記（基本仕様書の改訂No14） 
//                                 ②重複データチェックの場合、印刷順の仕様修正（基本仕様書の改訂No15）
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : wujun
// 修 正 日  2015/08/17  修正内容 : Redmine47047 【№845】UOE仕入チェックの障害対応                                
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : mamd
// 修 正 日  2015/09/21  修正内容 : Redmine47047 【№845】UOE仕入チェックの障害対応
//                                : 伝票番号項目にスペースがセットされている場合の不具合対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Windows.Forms;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入チェックリスト アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入チェックリストで使用するデータを取得する。</br>
    /// <br>Programmer	: 張莉莉</br>
    /// <br>Date		: 2009.05.10</br>
    /// <br>Update Note : 2015/08/17 wujun</br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>            : Redmine47047 【№845】UOE仕入チェックの障害対応</br> 
    /// </remarks>
    public class StockSlipAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 仕入チェックリストアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入チェックリストアクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
		/// </remarks>
		public StockSlipAcs()
		{
            this._iStockSlipWorkDB = (IStockSlipResultDB)MediationStockSlipResultDB.GetStockSlipWorkDB();
		}

		/// <summary>
		/// 仕入チェックリストアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入チェックリストアクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
		/// </remarks>
        static StockSlipAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス	
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // 帳票出力設定アクセスクラス

        #endregion ■ Static Member

        #region ■ Private Member
        IStockSlipResultDB _iStockSlipWorkDB;

        private SectionCdInputConstructionAcs _sectionCdInputConstructionAcs = null;
        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _stockSlipDt;			// 印刷DataTable
        private DataView _stockSlipView;	        // 印刷DataView

        private ArrayList codeListCSV = new ArrayList();
        private ArrayList codeListPM = new ArrayList();

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView StockSlipView
        {
            get { return this._stockSlipView; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 入金データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="stockSlip">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public int SearchStockSlipProcMain(StockSlipCndtn stockSlip, out string errMsg)
        {
            return this.SearchStockSlipProc(stockSlip, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private int SearchStockSlipProc(StockSlipCndtn stockSlip, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02055EA.CreateDataTable(ref this._stockSlipDt);

                // 抽出条件展開  --------------------------------------------------------------
                StockSlipCndtnWork stockSlipCndtnWork = new StockSlipCndtnWork();
                status = this.DevStockSlip(stockSlip, out stockSlipCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object stockSlipResultWork = null;
                status = _iStockSlipWorkDB.Search(out stockSlipResultWork, (object)stockSlipCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                      
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        // データcheck処理
                        if (stockSlip.CheckSectionDiv.ToString().Equals("PMSupplier"))
                        {
                            
                            ArrayList csvDataList = stockSlip.CsvData;
                            ArrayList stockSlipResultList = stockSlipResultWork as ArrayList;
                            // PMデータ集計処理
                            PMDataGroup(stockSlip, ref stockSlipResultList, csvDataList);
                            // CSVデータ集計処理
                            CSVDataGroup(stockSlip, ref csvDataList);

                            // CSVデータ ArrayList ==> List
                            List<StockSlipTextData> csvList = new List<StockSlipTextData>();
                            foreach (StockSlipTextData tmp in csvDataList) 
                            {
                                csvList.Add(tmp);
                            }
                            ArrayList newCsvDate = new ArrayList();
                            if (csvDataList != null && csvDataList.Count>0)
                            {
                                // ソート順
                                CsvDatatoComparer csvData = new CsvDatatoComparer();
                                csvList.Sort(csvData);
                                // List ==> ArrayList
                                foreach (StockSlipTextData tmp in csvList) 
                                {
                                    newCsvDate.Add(tmp);
                                }
                            }

                            // PMデータ ArrayList ==> List
                            List<StockSlipResultWork> pmList = new List<StockSlipResultWork>();
                            foreach (StockSlipResultWork tmp in stockSlipResultList)
                            {
                                pmList.Add(tmp);
                            }
                            ArrayList newPmDate = new ArrayList();
                            if (stockSlipResultList != null && stockSlipResultList.Count > 0)
                            {
                                // ソート順
                                PMDatatoComparer pmData = new PMDatatoComparer();
                                pmList.Sort(pmData);
                                // List ==> ArrayList
                                foreach (StockSlipResultWork tmp in pmList)
                                {
                                    newPmDate.Add(tmp);
                                }
                            }

                            // PM/仕入先の場合のチェック
                            CheckStockSlipPMData(stockSlip, newPmDate, newCsvDate);

                        }
                        else
                        {
                            // 仕入データ重複の場合のチェック
                            CheckStockSlipRepData(stockSlip, (ArrayList)stockSlipResultWork);
                            if (this._stockSlipView.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "仕入データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理
        #region ◎ 取得データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="stockSlipCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得PMデータ</param>
        /// <param name="csvDataList">csvDataList</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void PMDataGroup(StockSlipCndtn stockSlipCndtn, ref ArrayList resultWork, ArrayList csvDataList)
        {
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check"))
            {
                // 拠点変換設定画面の拠点コードを変換する
                this._sectionCdInputConstructionAcs = new SectionCdInputConstructionAcs();
                codeList = _sectionCdInputConstructionAcs.InputSecCdCSV;
                dataList = _sectionCdInputConstructionAcs.InputSecCdPM;

                //---ADD 20090717 仕様変更 整合性チェック処理の仕様を追記----->>>>>
                bool cdSameFlg = false;
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    string sectionCsvCode = stockSlipTextData.StockSectionCd;
                    cdSameFlg = false;
                    for (int codeCount = 0; codeCount < codeList.Count; codeCount++ )
                    {
                        if (sectionCsvCode.Equals(codeList[codeCount]))
                        {
                            cdSameFlg = true;
                            break;
                        }
                    }
                    if (cdSameFlg)
                    {
                        continue;
                    }
                    else
                    {
                        ArrayList newList = new ArrayList();
                        codeList.Add(sectionCsvCode);
                        newList.Add(sectionCsvCode.Substring(8, 2));
                        dataList.Add(newList);
                    }
                }
                //---ADD 20090717 仕様変更 整合性チェック処理の仕様を追記-----<<<<<


                //　ADD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>
                for (int ii = 0; ii < codeList.Count; ii++)
                {
                    ArrayList listA = new ArrayList();
                    listA = (ArrayList)dataList[ii];
                    for (int jj = 0; jj < listA.Count; jj++)
                    {
                        codeListCSV.Add(codeList[ii]);
                        codeListPM.Add(listA[jj]);
                    }
                }
                //　ADD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<

                /*　DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                bool sameFlg = false;
                //　拠点変換設定したの場合
                if (codeList != null && codeList.Count > 0)
                {
                    for (int i = 0; i < codeList.Count; i++)
                    {
                        _sectionCdTable.Add(codeList[i].ToString().PadLeft(10,'0'), dataList[i]);
                    }

                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        string secCd = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            ArrayList secList = (ArrayList)dataList[i];
                            for (int j = 0; j < secList.Count; j++)
                            {
                                // 同じの場合、変換する
                                if (secCd.Equals(secList[j]))
                                {
                                    stockSlipResultWork.StockAddUpSectionCd = codeList[i].ToString();
                                    sameFlg = true;
                                    break;
                                }
                            }
                            if (sameFlg)
                            {
                                sameFlg = false;
                                break;
                            }
                        }
                    }
                }
                */
            }
            
            Hashtable pmDataTable = new Hashtable();

            // 仕入日チェックは「なし」、拠点チェックは「なし」の場合,「伝票番号」「仕入先コード」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    stockSlipResultWork.PartySaleSlipNum = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    string slipNoSupplierCd = stockSlipResultWork.PartySaleSlipNum + "_" + stockSlipResultWork.PayeeCode.ToString();
                    //　伝票番号」「仕入先コード」同じの場合、集計する
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];

                        //　仕入日は違いの場合、最新の日を設定する
                        if (stockSlipResultInTable.StockDate > stockSlipResultWork.StockDate)
                        {
                            stockSlipResultWork.StockDate = stockSlipResultInTable.StockDate;
                        }
                        //　拠点は違いの場合、最大の拠点コードを設定する
                        if (Convert.ToInt32( stockSlipResultInTable.StockAddUpSectionCd )> Convert.ToInt32( stockSlipResultWork.StockAddUpSectionCd))
                        {
                            stockSlipResultWork.StockAddUpSectionCd = stockSlipResultInTable.StockAddUpSectionCd;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //　金額を集計する
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }

            }

            // 仕入日チェックは「あり」、拠点チェックは「なし」の場合,「伝票番号」「仕入先コード」「仕入日」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_" 
                                            + stockSlipResultWork.StockDate.ToString() +"_" 
                                               + stockSlipResultWork.PayeeCode.ToString();
                    //　「伝票番号」「仕入先コード」「仕入日」同じの場合、集計する
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        //　拠点は違いの場合、最大の拠点コードを設定する
                        if (Convert.ToInt32( stockSlipResultInTable.StockAddUpSectionCd) > Convert.ToInt32( stockSlipResultWork.StockAddUpSectionCd))
                        {
                            stockSlipResultWork.StockAddUpSectionCd = stockSlipResultInTable.StockAddUpSectionCd;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }

                        //　金額を集計する
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }
            }

            // 仕入日チェックは「なし」、拠点チェックは「あり」の場合,「伝票番号」「仕入先コード」「拠点コード」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd =  SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_"
                                          + stockSlipResultWork .StockAddUpSectionCd + "_" 
                                              + stockSlipResultWork.PayeeCode.ToString();
                    //　伝票番号」「仕入先コード」「拠点コード」同じの場合、集計する
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        //　仕入日は違いの場合、最新の日を設定する
                        if (stockSlipResultInTable.StockDate > stockSlipResultWork.StockDate)
                        {
                            stockSlipResultWork.StockDate = stockSlipResultInTable.StockDate;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //　金額を集計する
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }

            }

            // 仕入日チェックは「あり」、拠点チェックは「あり」の場合,「伝票番号」「仕入先コード」「拠点コード」「仕入日」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_"
                                            + stockSlipResultWork.StockAddUpSectionCd + "_"
                                               + stockSlipResultWork.StockDate.ToString() + "_" 
                                                 + stockSlipResultWork.PayeeCode.ToString();
                    // 「伝票番号」「仕入先コード」「拠点コード」「仕入日」同じの場合
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //　金額を集計する
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }
            }

            resultWork = new ArrayList(pmDataTable.Values);
        }


        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="stockSlipCndtn">UI抽出条件クラス</param>
        /// <param name="csvDataList">取得CSVデータ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CSVDataGroup(StockSlipCndtn stockSlipCndtn, ref ArrayList csvDataList)
        {
            Hashtable csvDataTable = new Hashtable();

            // 仕入日チェックは「なし」、拠点チェックは「なし」の場合,「伝票番号」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    string slipNo = stockSlipTextData.SupplierSlipNo;
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    // 「伝票番号」同じの場合
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        DateTime tableDate = DateTime.ParseExact(stockSlipInTable.StockDate, "yyyyMMdd", null);
                        //　仕入日は違いの場合、最新の日を設定する
                        if (tableDate > textDate)
                        {
                            stockSlipTextData.StockDate = stockSlipInTable.StockDate;
                        }
                        //　金額を集計する
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // 仕入日チェックは「あり」、拠点チェックは「なし」の場合,「伝票番号」「仕入日」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + textDate;
                    int sectionCd = Convert.ToInt32(stockSlipTextData.StockSectionCd);
                    // 「伝票番号」「仕入日」同じの場合
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        int sectionCdIn = Convert.ToInt32(stockSlipInTable.StockSectionCd);

                        //　拠点は違いの場合、最大拠点を設定する
                        if (sectionCdIn > sectionCd)
                        {
                            stockSlipTextData.StockSectionCd = stockSlipInTable.StockSectionCd;
                        }
                        //　金額を集計する
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // 仕入日チェックは「なし」、拠点チェックは「あり」の場合,「伝票番号」「拠点コード」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + stockSlipTextData.StockSectionCd;
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    // 「伝票番号」同じの場合
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        DateTime tableDate = DateTime.ParseExact(stockSlipInTable.StockDate, "yyyyMMdd", null);
                        //　仕入日は違いの場合、最新の日を設定する
                        if (tableDate > textDate)
                        {
                            stockSlipTextData.StockDate = stockSlipInTable.StockDate;
                        }
                        //　金額を集計する
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // 仕入日チェックは「あり」、拠点チェックは「あり」の場合,「伝票番号」「拠点コード」「仕入日」毎に集計
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + stockSlipTextData.StockSectionCd + "_" + textDate;

                    // 「伝票番号」「拠点コード」「仕入日」同じの場合
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];

                        //　金額を集計する
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }
        }
        #endregion

        #region ◎ 抽出条件展開処理
        /// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="stockSlip">UI抽出条件クラス</param>
        /// <param name="stockSlipCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockSlip(StockSlipCndtn stockSlip, out StockSlipCndtnWork stockSlipCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSlipCndtnWork = new StockSlipCndtnWork();
            try
            {
                // 企業コード 
                stockSlipCndtnWork.EnterpriseCode = stockSlip.EnterpriseCode;
                // 拠点コードリスト
                stockSlipCndtnWork.SectionCodeList = stockSlip.SectionCodeList;
                // 支払締日の開始日
                stockSlipCndtnWork.St_csvDate = stockSlip.St_addUpDate;
                // 支払締日の終了日
                stockSlipCndtnWork.Ed_csvDate = stockSlip.Ed_addUpDate;
                // 仕入先コード
                stockSlipCndtnWork.SupplierCd = stockSlip.SupplierCd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }


        #endregion ◎ 抽出条件展開処理
        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得
        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
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
        #endregion ◆ 帳票設定データ取得

        /// <summary>
        /// 取得データCheck処理
        /// </summary>
        /// <param name="stockSlipCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CheckStockSlipRepData(StockSlipCndtn stockSlipCndtn, ArrayList resultWork)
        {
            string strSlipNoA = null;
            string strSlipNoB = null;
            // 仕入日チェックは「なし」、拠点チェックは「なし」の場合,
            // ｢伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.PartySaleSlipNum;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.PartySaleSlipNum;

                        // DEL 20090807 張莉莉　
                        // バグ修正：仕入データ重複チェック処理で、仕入データ内に同一伝票番号のレコードが3レコード以上あった場合に重複チェック処理が不正
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        // このデータはチェックされた
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            //　｢伝票番号｣同じの場合
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoA;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoB;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }

                //　ＰＭ伝票№重複なしのデータの処理
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                   if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "　";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 仕入日チェックは「あり」、拠点チェックは「なし」の場合,
            // ｢日付+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.StockDate.ToString() + stockSlipResultWorkA.PartySaleSlipNum;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.StockDate.ToString() + stockSlipResultWorkB.PartySaleSlipNum;
                        // DEL 20090807 張莉莉　
                        // バグ修正：仕入データ重複チェック処理で、仕入データ内に同一伝票番号のレコードが3レコード以上あった場合に重複チェック処理が不正
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ｢日付+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }

                //　ＰＭ伝票№重複なしのデータの処理
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 仕入日チェックは「なし」、拠点チェックは「あり」の場合,
            // ｢拠点ｺｰﾄﾞ+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.PartySaleSlipNum + stockSlipResultWorkA.StockAddUpSectionCd;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB =stockSlipResultWorkB.PartySaleSlipNum + stockSlipResultWorkB.StockAddUpSectionCd;
                        // DEL 20090807 張莉莉　
                        // バグ修正：仕入データ重複チェック処理で、仕入データ内に同一伝票番号のレコードが3レコード以上あった場合に重複チェック処理が不正
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        //　データチェックされたの場合、処理なし
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ｢拠点ｺｰﾄﾞ+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] =stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] =  stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }
                //　ＰＭ伝票№重複なしのデータの処理
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 仕入日チェックは「あり」、拠点チェックは「あり」の場合,
            // ｢拠点ｺｰﾄﾞ+仕入日+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {

                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.StockDate.ToString() + stockSlipResultWorkA.PartySaleSlipNum
                                      + stockSlipResultWorkA.StockAddUpSectionCd;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.StockDate.ToString() + stockSlipResultWorkB.PartySaleSlipNum
                                          + stockSlipResultWorkB.StockAddUpSectionCd;

                        // DEL 20090807 張莉莉　
                        // バグ修正：仕入データ重複チェック処理で、仕入データ内に同一伝票番号のレコードが3レコード以上あった場合に重複チェック処理が不正
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        //　データチェックされたの場合、処理なし
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ｢拠点ｺｰﾄﾞ+仕入日+伝票番号｣でPMのﾃﾞｰﾀ内に同一の伝票が存在した場合
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票№重複";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }
                //　ＰＭ伝票№重複なしのデータの処理
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 不一致のPMデータの金額合計
            long diffPricePM = 0;
            // PMデータの金額総合計
            long totalPricePM = 0;

            // 不一致のCSVデータの金額合計
            long diffPriceCSV = 0;
            // CSVデータの金額総合計
            long totalPriceCSV = 0;
            for (int i = 0; i < _stockSlipDt.Rows.Count; i++)
            {
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Different"))
                {
                    diffPricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    diffPriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
            }
            totalPricePM = diffPricePM;
            totalPriceCSV = diffPriceCSV;
            stockSlipCndtn.DiffPmPrice = diffPricePM;
            stockSlipCndtn.DiffCsvPrice = diffPriceCSV;
            stockSlipCndtn.TotalPmPrice = totalPricePM;
            stockSlipCndtn.TotalCsvPrice = totalPriceCSV;

            // フィルタ条件
            string myFilter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Different");

            DataView myView = new DataView(this._stockSlipDt, myFilter, "", DataViewRowState.CurrentRows);

            // DataView作成
            this._stockSlipView = new DataView(this._stockSlipDt, myFilter, GetSortOrder(stockSlipCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 取得データCheck処理
        /// </summary>
        /// <param name="stockSlipCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得PMデータ</param>
        /// <param name="csvDataWork">取得CSVデータ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2015/08/17 wujun</br>
        /// <br>管理番号   : 11170129-00</br>
        /// <br>           : Redmine47047 【№845】UOE仕入チェックの障害対応</br> 
        /// </remarks>
        private void CheckStockSlipPMData(StockSlipCndtn stockSlipCndtn, ArrayList resultWork, ArrayList csvDataWork)
        {
            string strSlipNoA = null;
            string strSlipNoB = null;
            string strSceCdA = null;
            string strSceCdB = null;
            long strPriceA;
            long strPriceB;
            string strDateA = null;
            string strDateB = null;

            bool sameFlg;
            // 仕入日チェックは「なし」、拠点チェックは「なし」の場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                // PMの｢伝票番号｣で仕入先のﾃﾞｰﾀに存在しない場合
                
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        // PMの｢伝票番号｣で仕入先のﾃﾞｰﾀに存在するの場合
                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }
                    // PMの｢伝票番号｣で仕入先のﾃﾞｰﾀに存在しない場合
                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        //dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoA; //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // 仕入先の｢伝票番号｣でPMのﾃﾞｰﾀに存在しない場合
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }
                    // 仕入先の｢伝票番号｣でPMのﾃﾞｰﾀに存在しない場合
                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
               
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");

                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // PMと仕入先の｢伝票番号｣は一致しているが伝票金額が一致の場合
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }

                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）------->>>>>>>>>
                                //if (!strPriceA.Equals(strPriceB))
                                //{
                                //    stockSlipTextData.IsChecked = true;
                                //    stockSlipResultWork.UoeRemark2 = "checked";
                                //    DataRow dr;
                                //    dr = _stockSlipDt.NewRow();
                                //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //    if (stockSlipResultWork.WayToOrder == 2)
                                //    {
                                //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //    }

                                //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //    dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //    this._stockSlipDt.Rows.Add(dr);

                                //}
                                //else
                                //{
                                    // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<<<<
                                    stockSlipTextData.IsChecked = true;
                                    stockSlipResultWork.UoeRemark2 = "checked";
                                    DataRow dr;
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    if (stockSlipResultWork.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }

                                    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票とＰＭ伝票があり、一致する";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                // PMと仕入先の｢伝票番号｣は一致しているが伝票金額が不一致の場合
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }

                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    stockSlipTextData.IsChecked = true;
                                    stockSlipResultWork.UoeRemark2 = "checked";
                                    DataRow dr;
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    if (stockSlipResultWork.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }

                                    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    this._stockSlipDt.Rows.Add(dr);

                                }
                              
                            }
                        }
                    }
                }
                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<<<<

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                
            }

            // 仕入日チェックは「あり」、拠点チェックは「なし」の場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    //  PMと仕入先の｢伝票番号+日付+伝票金額｣は一致
                                    if (strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票とＰＭ伝票があり、一致する";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                                    // PMと仕入先の｢伝票番号+伝票金額｣は一致しているが日付が不一致の場合
                                    //else
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "日付不一致";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);
                                    //}
                                }
                                //else
                                //{
                                //    // PMと仕入先の｢日付+伝票番号｣は一致しているが伝票金額が不一致の場合
                                //    if (strDateA.Equals(strDateB))
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //    // PMと仕入先の｢伝票番号｣は一致しているが伝票金額と日付が不一致の場合
                                //    else
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "金額･日付不一致";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //}
                                // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<
                            }
                        }
                    }
                }

                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    // PMと仕入先の｢伝票番号｣は一致しているが伝票金額と日付が不一致の場合
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "金額･日付不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // PMと仕入先の｢伝票番号+伝票金額｣は一致しているが日付が不一致の場合
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "日付不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);  //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strDateA.Equals(strDateB))
                                {
                                    // PMと仕入先の｢日付+伝票番号｣は一致しているが伝票金額が不一致の場合
                                    if (!strPriceA.Equals(strPriceB)) 
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    } 
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<<

                // PMの｢日付+伝票番号｣で仕入先のﾃﾞｰﾀに存在しない場合
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd")
                            //+ SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                                 + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応

                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // 仕入先の｢日付+伝票番号｣でPMのﾃﾞｰﾀに存在しない場合
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd")
                        //+ SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応

                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 仕入日チェックは「なし」、拠点チェックは「あり」の場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                // PMの｢拠点ｺｰﾄﾞ+伝票番号｣で仕入先のﾃﾞｰﾀに存在しない場合
                
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                        //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                        
                        if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // 仕入先の｢拠点ｺｰﾄﾞ+伝票番号｣でPMのﾃﾞｰﾀに存在しない場合
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipTextData.StockSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            //strSlipNoB = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipResultWork.StockAddUpSectionCd.Trim();

                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdA, strSceCdB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // PMと仕入先の｢拠点ｺｰﾄﾞ+伝票番号｣は一致しているが伝票金額が一致の場合
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                        //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);  //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }
                            else
                            {
                                //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                                //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                                //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                                strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                                strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                                strPriceB = stockSlipTextData.StockPrice;
                                if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                                {
                                    if (strPriceA.Equals(strPriceB))
                                    {
                                        // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                                    //if (!strPriceA.Equals(strPriceB))
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);

                                    //}
                                    //else
                                    //{
                                        // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<<<
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票とＰＭ伝票があり、一致する";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                        //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }
                            else
                            {
                                //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                                //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                                //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                                strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                                strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                                strPriceB = stockSlipTextData.StockPrice;
                                if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                                {
                                    if (!strPriceA.Equals(strPriceB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);

                                    }
                                   
                                }
                            }
                        }
                    }
                }
                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<


                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

            }

            // 仕入日チェックは「あり」、拠点チェックは「あり」の場合
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    //  PMと仕入先の｢伝票番号+拠点ｺｰﾄﾞ+日付+伝票金額｣は一致
                                    if (strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票とＰＭ伝票があり、一致する";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    // DEL 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                                    // PMと仕入先の｢伝票番号+拠点ｺｰﾄﾞ+伝票金額｣は一致しているが日付が不一致の場合
                                    //else
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "日付不一致";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);
                                    //}
                                }
                                //else
                                //{
                                //    // PMと仕入先の｢日付+拠点ｺｰﾄﾞ+伝票番号｣は一致しているが伝票金額が不一致の場合
                                //    if (strDateA.Equals(strDateB))
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //    // PMと仕入先の｢伝票番号+拠点ｺｰﾄﾞ｣は一致しているが伝票金額と日付が不一致の場合
                                //    else
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "金額･日付不一致";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //}
                                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<
                            }
                        }
                    }
                }


                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    //  PMと仕入先の｢伝票番号+拠点ｺｰﾄﾞ+日付+伝票金額｣は一致
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "金額･日付不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // // PMと仕入先の｢伝票番号+拠点ｺｰﾄﾞ+伝票金額｣は一致しているが日付が不一致の場合
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "日付不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strDateA.Equals(strDateB))
                                {
                                    // PMと仕入先の｢日付+拠点ｺｰﾄﾞ+伝票番号｣は一致しているが伝票金額が不一致の場合
                                    if (!strPriceA.Equals(strPriceB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "伝票金額不一致";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }
                // ADD 20090807 張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）-----<<<<<<<<<<

                // PMの｢日付+拠点ｺｰﾄﾞ+伝票番号｣で仕入先のﾃﾞｰﾀに存在しない場合
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") +stockSlipResultWork.StockAddUpSectionCd 
                    //              + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                        //strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") +SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                        strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                        if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // 仕入先の｢日付+拠点ｺｰﾄﾞ+伝票番号｣でPMのﾃﾞｰﾀに存在しない場合
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                    //strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") +stockSlipTextData.StockSectionCd 
                    //    + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    //strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                    strSceCdA = stockSlipTextData.StockSectionCd.Trim();
                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //　UPD　20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") +stockSlipResultWork.StockAddUpSectionCd 
                            //      + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応
                            strSceCdB = stockSlipResultWork.StockAddUpSectionCd.Trim();
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdA, strSceCdB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "仕入先伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "ＰＭ伝票無し";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // 一致のPMデータの金額合計
            long samePricePM = 0;
            // 不一致のPMデータの金額合計
            long diffPricePM = 0;
            // PMデータの金額総合計
            long totalPricePM = 0;
            // 一致のCSVデータの金額総合計
            long samePriceCSV = 0;
            // 不一致のCSVデータの金額合計
            long diffPriceCSV = 0;
            // CSVデータの金額総合計
            long totalPriceCSV = 0;
            for (int i = 0; i < _stockSlipDt.Rows.Count;i++ )
            {
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Same"))
                {
                    samePricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    samePriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Different"))
                {
                    diffPricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    diffPriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
            }
            totalPricePM = samePricePM + diffPricePM;
            totalPriceCSV = samePriceCSV + diffPriceCSV;
            stockSlipCndtn.SamePmPrice = samePricePM;
            stockSlipCndtn.SameCsvPrice = samePriceCSV;
            stockSlipCndtn.DiffPmPrice = diffPricePM;
            stockSlipCndtn.DiffCsvPrice = diffPriceCSV;
            stockSlipCndtn.TotalPmPrice = totalPricePM;
            stockSlipCndtn.TotalCsvPrice = totalPriceCSV;


            // フィルタ条件
            string filter = "";
            if (stockSlipCndtn.PrintDiv.ToString().Equals("Different"))
            {
                filter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Different");
            }
            else if (stockSlipCndtn.PrintDiv.ToString().Equals("Same"))
            {
                filter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Same");
            }
            string myFilter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Same");


            DataView myView = new DataView(this._stockSlipDt, myFilter, "", DataViewRowState.CurrentRows);

            if(myView.Count == 0)
            {
                stockSlipCndtn.SameFlg = true;
            }
            if(myView.Count == _stockSlipDt.Rows.Count)
            {
                stockSlipCndtn.DiffFlg = true;
            }
            
            // DataView作成
            this._stockSlipView = new DataView(this._stockSlipDt, filter, GetSortOrder(stockSlipCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 伝票番号の取得処理
        /// </summary>
        /// <param name="stockSlipCndtn">抽出条件</param>
        /// <param name="suppSlipNo">伝票番号</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号の取得処理を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string SuppSlipNoSubStr(StockSlipCndtn stockSlipCndtn,string suppSlipNo)
        {
            string slipNum = suppSlipNo;
            // 上６桁のみ：相手先伝票番号の上から６桁のみを取得
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("First6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring(0,6);
                }
            }
            // 下６桁のみ　：相手先伝票番号の下から６桁のみを取得
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("Last6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring((suppSlipNo.Length-6), 6);
                }
            }

            return slipNum;
        }

        // ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応 ---->>>>
        /// <summary>
        /// チェック専用の伝票番号取得処理
        /// </summary>
        /// <param name="stockSlipCndtn">抽出条件</param>
        /// <param name="suppSlipNo">伝票番号</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : チェック用伝票番号の取得処理を行います。</br>
        /// <br>Programmer : wujun</br>
        /// <br>Date       : 2015/08/17</br>
        /// <br>Update Note: 2015/09/21 mamd</br>
        /// <br>管理番号   : 11170129-00</br>
        /// <br>           : Redmine47047 【№845】UOE仕入チェックの障害対応</br>
        /// <br>           : 伝票番号項目にスペースがセットされている場合の不具合対応</br>
        /// </remarks>
        private string SuppSlipNoSubStrForCheck(StockSlipCndtn stockSlipCndtn, string suppSlipNo)
        {
            string slipNum = suppSlipNo;
            // 上６桁のみ：相手先伝票番号の上から６桁のみを取得
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("First6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring(0, 6);
                }
            }
            // 下６桁のみ　：相手先伝票番号の下から６桁のみを取得
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("Last6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring((suppSlipNo.Length - 6), 6);
                }
            }
            //DEL BY mamd 2015/09/21 FOR Redmine47047 【№845】UOE仕入チェックの障害対応----->>>>
            //if (IsDigitAddZero(slipNum))
            //{
            //    slipNum = Convert.ToInt32(slipNum).ToString();
            //}
            //DEL BY mamd 2015/09/21 FOR Redmine47047 【№845】UOE仕入チェックの障害対応----->>>>
            //ADD BY mamd 2015/09/21 FOR Redmine47047 【№845】UOE仕入チェックの障害対応----->>>>
            if (IsDigitAddZero(slipNum.Trim()))
            {
                slipNum = Convert.ToInt64(slipNum.Trim()).ToString();
            }
            else if (string.IsNullOrEmpty(slipNum.Trim()))
            {
                slipNum = "0";
            }
            //ADD BY mamd 2015/09/21 FOR Redmine47047 【№845】UOE仕入チェックの障害対応----->>>>
            return slipNum;
        }

        /// <summary>
        /// 正整数+0判断
        /// </summary>
        /// <param name="val">値</param>
        /// <returns>True:数字; False:非数字</returns>
        /// <remarks>
        /// <br>Note       : 正整数+0判断処理を行います。</br>
        /// <br>Programmer : wujun </br>
        /// <br>Date       : 2015/08/17</br>
        /// </remarks>
        private bool IsDigitAddZero(string val)
        {
            string regex1 = "^\\d+$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                return false;
            }
            return true;
        }
        // ADD BY wujun 2015/08/17 FOR Redmine47047 【№845】UOE仕入チェックの障害対応 ----<<<<



        /// <summary>
        /// 拠点データのチェック処理
        /// </summary>
        /// <param name="sectionCdCSV">テキストの拠点コード</param>
        /// <param name="SectionCdPM">PMの拠点コード</param>
        /// <remarks>
        /// <br>Note       : 拠点データのチェック</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.08.07</br>
        /// </remarks>
        private bool CheckSectionCd(string sectionCdCSV , string SectionCdPM)
        {
            //ADD 20090807　張莉莉　整合性チェック処理の仕様を追記（基本仕様書の改訂No14）
            bool status = false;
            for (int i = 0; i < codeListPM.Count;i++ )
            {
                if (SectionCdPM.Equals(codeListPM[i].ToString().Trim()))
                {
                    if (sectionCdCSV.Equals(codeListCSV[i].ToString().Trim()))
                    {
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

         #region ◎ ソート順作成
        /// <summary>
        /// ソート順作成
        /// </summary>
        /// <param name="stockSlipCndtn">抽出条件</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号の取得処理を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string GetSortOrder(StockSlipCndtn stockSlipCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();
            if (stockSlipCndtn.CheckSectionDiv.ToString().Equals("PMSupplier"))
            {
                // 拠点チェック「あり」：PM仕入日、エラー区分、PM伝票番号、拠点順
                if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check"))
                {
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_errDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_SectionCode));
                    strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
                }
                // 拠点チェック「なし」：PM仕入日、エラー区分、PM伝票番号順
                else if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None"))
                {
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_errDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                    strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
                }
            }
            else
            {
                // ADD 20090807 張莉莉　重複データチェックの場合、印刷順の修正（基本仕様書の改訂No15）
                // PM伝票番号、PM仕入日、拠点順
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_SectionCode));
                strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
            }
            

            return strSortOrder.ToString();
        }

        /// <summary>
        /// PMデータソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSVデータソート順処理を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class PMDatatoComparer : IComparer<StockSlipResultWork>
        {
            public int Compare(StockSlipResultWork x, StockSlipResultWork y)
            {
                int ret = ComparerHelper.CompareObject(x.StockDate, y.StockDate);
                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.PartySaleSlipNum, y.PartySaleSlipNum);

                    if (ret == 0)
                    {
                        ret = ComparerHelper.CompareObject(x.StockAddUpSectionCdPm, y.StockAddUpSectionCdPm);

                        if (ret == 0)
                        {
                            ret = ComparerHelper.CompareObject(x.SupplierSlipNo, y.SupplierSlipNo);
                        }
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// CSVデータソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSVデータソート順処理を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class CsvDatatoComparer : IComparer<StockSlipTextData>
        {
            public int Compare(StockSlipTextData x, StockSlipTextData y)
            {
                int ret = ComparerHelper.CompareObject(x.StockDate, y.StockDate);
                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.SupplierSlipNo, y.SupplierSlipNo);

                    if (ret == 0)
                    {
                        ret = ComparerHelper.CompareObject(x.StockSectionCd, y.StockSectionCd);
                    }
                }
                return ret;
            }
        }
        /// <summary>
        /// Comparer処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : Comparer処理を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class ComparerHelper
        {
            public static int CompareObject(object val1, object val2)
            {
                if (val1 == null && val2 == null)
                {
                    return 0;
                }
                else if (val1 != null && val2 != null)
                {
                    return val1.ToString().CompareTo(val2.ToString());
                }
                else if (val1 != null && val2 == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        #endregion

        #endregion ■ Private Method


    }
}
