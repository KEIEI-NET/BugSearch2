//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入不整合確認表
// プログラム概要   : 仕入不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入不整合確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入不整合確認表アクセスクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.13</br>
    /// </remarks>
    public class StockSalesInfoMainAcs
    {

        #region ■ Constructor
        /// <summary>
        /// 仕入不整合確認表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :仕入不整合確認表一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public StockSalesInfoMainAcs()
        {
            this._iStockSalesInfoTableDB = (IStockSalesInfoTableDB)Broadleaf.Application.Remoting.Adapter.MediationStockSalesInfoTableDB.GetStockSalesInfoTableDB();
        }

        /// <summary>
        /// 仕入不整合確認表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入不整合確認表一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static StockSalesInfoMainAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
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
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        #endregion ■ Static Member

        #region ■ Const
        const string errFlgConst = "1";
        const string stockOnleFlgConst = "2";
        const int zeroFlgConst = -1;
        const string normalFlgConst = "0";
        const string existMsg = "売上が作成されていません";
        const string masterMsg = "左記コードが登録されていません";
        const string countMsg = "仕入と売上で数量が相違しています";
        const string priceMsg = "仕入と売上で原価が相違しています";
        #endregion

        #region ■ Private Member

        IStockSalesInfoTableDB _iStockSalesInfoTableDB;//仕入不整合確認表アクセス

        private DataSet _custAccRecDs;				    // 仕入不整合確認表データセット

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary> 仕入不整合確認表データセット(読み取り専用)</summary>
        /// <value>CustAccRecDs</value>               
        /// <remarks>仕入不整合確認表データセット(読み取り専用)取得プロパティ </remarks> 
        public DataSet CustAccRecDs
        {
            get { return this._custAccRecDs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 帳票出力データ取得
        /// <summary>
        /// 帳票出力データ取得
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する帳票出力データを取得する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int SearchCustAccRecMainForPdf(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out string errMsg)
        {
            return this.SearchCustAccRecMainProcForPdf(StockSalesInfoMainCndtn, out errMsg);
        }
        #endregion



        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 仕入不整合確認表データ取得
        /// <summary>
        /// 帳票出力設定データ取得
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int SearchCustAccRecMainProcForPdf(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02045EA.CreateDataTableStockSalesInfoAccRecMain(ref this._custAccRecDs);
                StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork = new StockSalesInfoMainCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(StockSalesInfoMainCndtn, out stockSalesInfoMainCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                status = this._iStockSalesInfoTableDB.Search(out retCustAccRecMainList, stockSalesInfoMainCndtnWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevStockSalesMainData(StockSalesInfoMainCndtn, this._custAccRecDs.Tables[PMKOU02045EA.Tbl_StockSalesInfoAccRecMain], (ArrayList)retCustAccRecMainList);
                        if (this._custAccRecDs.Tables[PMKOU02045EA.Tbl_StockSalesInfoAccRecMain].Rows.Count < 1)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "仕入不整合確認表の帳票出力データの取得に失敗しました。";
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



        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn">UI抽出条件クラス</param>
        /// <param name="stockSalesInfoMainCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行います。</br>		
        /// <br>Programmer : 汪千来</br>		
        /// <br>Date       : 2009.04.13</br>		
        /// </remarks>		
        private int DevCustAccRecMainCndtn(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSalesInfoMainCndtnWork = new StockSalesInfoMainCndtnWork();

            try
            {
                // 企業コード
                stockSalesInfoMainCndtnWork.EnterpriseCode = StockSalesInfoMainCndtn.EnterpriseCode;

                // 抽出条件パラメータセット
                if ((null != StockSalesInfoMainCndtn.CollectAddupSecCodeList)
                    && (StockSalesInfoMainCndtn.CollectAddupSecCodeList.Length != 0))
                {
                    if (StockSalesInfoMainCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                    }
                    else
                    {
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = StockSalesInfoMainCndtn.CollectAddupSecCodeList;
                    }
                }
                else
                {
                    stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                }


                //対象年月
                stockSalesInfoMainCndtnWork.YearMonth = StockSalesInfoMainCndtn.YearMonth;

                //前回締処理日
                stockSalesInfoMainCndtnWork.PrevTotalDay = StockSalesInfoMainCndtn.PrevTotalDay;

                //今回締処理日
                stockSalesInfoMainCndtnWork.CurrentTotalDay = StockSalesInfoMainCndtn.CurrentTotalDay;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion



        #region ◎ 帳票テーブルデータ展開処理
        /// <summary>
        /// 仕入不整合確認表帳票テーブルデータ展開処理
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn">UI抽出条件クラス</param>
        /// <param name="custAccRecMainDt">展開対象DataTable</param>
        /// <param name="custAccRecMainWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 仕入不整合確認表帳票テーブルデータを展開する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private void DevStockSalesMainData(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
        {
            DataRow dr;
            StockSalesInfoWork disAccRecmainResWork = null;
            int count = custAccRecMainWork.Count;
            StringBuilder checkMsg = null;
            bool saveFlg = false;
            for (int i = 0; i < count; i++)
            {
                checkMsg = new StringBuilder(string.Empty);

                disAccRecmainResWork = (StockSalesInfoWork)custAccRecMainWork[i];

                dr = custAccRecMainDt.NewRow();

                saveFlg = false;

                //拠点コード
                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                //拠点名称
                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;

                //仕入先コード
                dr[PMKOU02045EA.Col_SupplierCdHeader] = disAccRecmainResWork.SupplierCdHeader;

                //仕入先略称
                dr[PMKOU02045EA.Col_SupplierSnm] = GetStringToByte(disAccRecmainResWork.SupplierSnm, 20);

                //日付
                dr[PMKOU02045EA.Col_StockDate] = disAccRecmainResWork.StockDate;

                //入力日付
                dr[PMKOU02045EA.Col_InputDay] = DateTime.ParseExact(disAccRecmainResWork.InputDay.ToString(), StockSalesInfoMainCndtn.ct_DateFomat, null).ToString(StockSalesInfoMainCndtn.ct_DateFomatWithLine);

                //伝票番号
                dr[PMKOU02045EA.Col_PartySlipNumDtl] = disAccRecmainResWork.PartySlipNumDtl;

                //仕入SEQ番号-行
                dr[PMKOU02045EA.Col_SeqNo] = disAccRecmainResWork.SupplierSlipNo + "-" + disAccRecmainResWork.StockRowNo;

                //拠点コード
                dr[PMKOU02045EA.Col_SectionCode] = disAccRecmainResWork.SectionCode;

                //担当者
                dr[PMKOU02045EA.Col_StockAgentCode] = disAccRecmainResWork.StockAgentCode;

                //仕入先コード
                if (zeroFlgConst == disAccRecmainResWork.SupplierCd)
                {
                    dr[PMKOU02045EA.Col_SupplierCd] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_SupplierCd] = disAccRecmainResWork.SupplierCd;
                }

                //BLコード
                if (zeroFlgConst == disAccRecmainResWork.BLGoodsCode)
                {
                    dr[PMKOU02045EA.Col_BLGoodsCode] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_BLGoodsCode] = disAccRecmainResWork.BLGoodsCode;
                }

                //グループ
                if (zeroFlgConst == disAccRecmainResWork.BLGroupCode)
                {
                    dr[PMKOU02045EA.Col_BLGroupCode] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_BLGroupCode] = disAccRecmainResWork.BLGroupCode;
                }

                //倉庫
                dr[PMKOU02045EA.Col_WarehouseCode] = disAccRecmainResWork.WarehouseCode;

                if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    //得意先
                    if (zeroFlgConst == disAccRecmainResWork.CustomerCode)
                    {
                        dr[PMKOU02045EA.Col_CustomerCode] = string.Empty;
                    }
                    else
                    {
                        dr[PMKOU02045EA.Col_CustomerCode] = disAccRecmainResWork.CustomerCode;
                    }

                    //売上伝票番号
                    dr[PMKOU02045EA.Col_SalesSlipNum] = disAccRecmainResWork.SalesSlipNum;
                }

                //不整合内容を作成
                //マスタチェック
                if ((!string.IsNullOrEmpty(disAccRecmainResWork.SectionCode))
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.StockAgentCode))
                    || (disAccRecmainResWork.BLGoodsCode >= 0)
                    || (disAccRecmainResWork.BLGroupCode >= 0)
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.WarehouseCode))
                    || (disAccRecmainResWork.SupplierCd >= 0))
                {
                    dr[PMKOU02045EA.Col_NayiYou] = masterMsg;
                    if ((stockOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;
                    }
                    else if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                            && (normalFlgConst.Equals(disAccRecmainResWork.CountFlg))
                            && (normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;
                    }
                    else
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = false;
                    }

                    // TableにAdd
                    custAccRecMainDt.Rows.Add(dr);

                    saveFlg = true;
                }

                if (!(stockOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    //売上伝票チェック
                    if (errFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                    {
                        if (saveFlg)
                        {
                            dr = custAccRecMainDt.NewRow();

                            //拠点コードHeader
                            dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                            //拠点名称
                            dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;

                        }

                        //不整合内容
                        dr[PMKOU02045EA.Col_NayiYou] = existMsg;

                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;

                        // TableにAdd
                        custAccRecMainDt.Rows.Add(dr);

                        saveFlg = true;

                    }
                    else
                    {
                        //数量チェック
                        if (errFlgConst.Equals(disAccRecmainResWork.CountFlg))
                        {
                            if (saveFlg)
                            {
                                dr = custAccRecMainDt.NewRow();

                                //拠点コードHeader
                                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //拠点名称
                                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //不整合内容
                            dr[PMKOU02045EA.Col_NayiYou] = countMsg;

                            if ((normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                            {
                                //lineflag
                                dr[PMKOU02045EA.Col_LineFlag] = true;
                            }
                            else
                            {
                                //lineflag
                                dr[PMKOU02045EA.Col_LineFlag] = false;
                            }

                            // TableにAdd
                            custAccRecMainDt.Rows.Add(dr);

                            saveFlg = true;
                        }

                        //原価チェック
                        if (errFlgConst.Equals(disAccRecmainResWork.PriceFlg))
                        {
                            if (saveFlg)
                            {
                                dr = custAccRecMainDt.NewRow();

                                //拠点コードHeader
                                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //拠点名称
                                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //不整合内容
                            dr[PMKOU02045EA.Col_NayiYou] = priceMsg;

                            //lineflag
                            dr[PMKOU02045EA.Col_LineFlag] = true;

                            // TableにAdd
                            custAccRecMainDt.Rows.Add(dr);

                            saveFlg = true;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// データ位数を制限処理
        /// </summary>
        /// <param name="useName"></param>
        /// <param name="byteLength"></param>
        /// <returns>制限後文字</returns>
        /// <remarks>
        /// <br>Note       : データ位数を制限処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private string GetStringToByte(string useName, int byteLength)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(useName);
            int n = 0;  //  当該の漢字
            int i;  //  表示の漢字
            if (bytes.GetLength(0) < byteLength)
            {
                return useName;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                if (i % 2 == 0)
                {
                    n++;
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            if (i % 2 == 1)
            {
                if (bytes[i] > 0)
                    i = i - 1;
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
        #endregion

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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.13</br>
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
                            break;
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
        #endregion ◆ 帳票データ取得
        #endregion ■ Private Method

    }
}
