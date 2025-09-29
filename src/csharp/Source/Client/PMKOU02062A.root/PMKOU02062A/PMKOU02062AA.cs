//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/10  修正内容 : 新規作成
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入売上実績表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表アクセスクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class SalesStockResultInfoMainAcs
    {

        #region ■ Constructor
        /// <summary>
        /// 仕入売上実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :仕入売上実績表一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public SalesStockResultInfoMainAcs()
        {
            this._iStockSalesResultInfoTableDB = (IStockSalesResultInfoTableDB)Broadleaf.Application.Remoting.Adapter.MediationStockSalesInfoTableDB.GetStockSalesResultInfoTableDB();
        }

        /// <summary>
        /// 仕入売上実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static SalesStockResultInfoMainAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;// 帳票出力設定データクラス
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
        const string normalFlgConst = "0";
        const string sign = "、";
        const int zeroFlgConst = -1;
        const string existMsg = "仕入が作成されていません";
        const string masterMsg = "左記コードが登録されていません";
        const string countMsg = "売上と仕入で数量が相違しています";
        const string priceMsg = "売上と仕入で原価が相違しています";
        const string ct_DateFormat = "YYYY/MM/DD";
        const string ct_DateFormatForDataField = "yyyy/MM/dd";
        #endregion

        #region ■ Private Member
        IStockSalesResultInfoTableDB _iStockSalesResultInfoTableDB;  //仕入売上実績表アクセス
        private DataSet _custAccRecDs;				    // 仕入売上実績表データセット
        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>カウント済みの伝票キーリスト</summary>
        private readonly IList<string> _countedSlipKeyList = new List<string>();
        /// <summary>
        /// カウント済みの伝票キーリストを取得します。
        /// </summary>
        /// <value>カウント済みの伝票キーリスト</value>
        private IList<string> CountedSlipKeyList
        {
            get { return _countedSlipKeyList; }
        }
        /// <summary> 仕入売上実績表データセット(読み取り専用)</summary>
        /// <value>CustAccRecDs</value>               
        /// <remarks>仕入売上実績表データセット(読み取り専用)取得プロパティ </remarks> 
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
        /// <param name="_stockSalesResultInfoMainCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する帳票出力データを取得する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int SearchCustAccRecMainForPdf(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out string errMsg)
        {
            return this.SearchCustAccRecMainProcForPdf(_stockSalesResultInfoMainCndtn, out errMsg);
        }
        #endregion



        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 仕入売上実績表データ取得
        /// <summary>
        /// 帳票出力設定データ取得
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SearchCustAccRecMainProcForPdf(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02065EA.CreateDataTableStockSalesResultInfoAccRecMain(ref this._custAccRecDs);
                SalesStockInfoResultMainCndtnWork _salesStockInfoResultMainCndtnWork = new SalesStockInfoResultMainCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(_stockSalesResultInfoMainCndtn, out _salesStockInfoResultMainCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                status = this._iStockSalesResultInfoTableDB.Search(out retCustAccRecMainList, _salesStockInfoResultMainCndtnWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevSalesStockMainData(_stockSalesResultInfoMainCndtn, this._custAccRecDs.Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain], (ArrayList)retCustAccRecMainList);
                        if (this._custAccRecDs.Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain].Rows.Count < 1)
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
                        errMsg = "仕入売上実績表の帳票出力データの取得に失敗しました。";
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



        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn">UI抽出条件クラス</param>
        /// <param name="_salesStockInfoResultMainCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行います。</br>		
        /// <br>Programmer : 汪千来</br>		
        /// <br>Date       : 2009.05.13</br>		
        /// </remarks>		
        private int DevCustAccRecMainCndtn(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out SalesStockInfoResultMainCndtnWork _salesStockInfoResultMainCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            _salesStockInfoResultMainCndtnWork = new SalesStockInfoResultMainCndtnWork();

            try
            {
                // 企業コード
                _salesStockInfoResultMainCndtnWork.EnterpriseCode = _stockSalesResultInfoMainCndtn.EnterpriseCode;

                // 抽出条件パラメータセット
                if ((null != _stockSalesResultInfoMainCndtn.CollectAddupSecCodeList)
                    && (_stockSalesResultInfoMainCndtn.CollectAddupSecCodeList.Length != 0))
                {
                    if (_stockSalesResultInfoMainCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = null;
                    }
                    else
                    {
                        _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = _stockSalesResultInfoMainCndtn.CollectAddupSecCodeList;
                    }
                }
                else
                {
                    _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = null;
                }

                //仕入日(開始)
                _salesStockInfoResultMainCndtnWork.StStockDate = _stockSalesResultInfoMainCndtn.StStockDate;
                //仕入日(終了)
                _salesStockInfoResultMainCndtnWork.EdStockDate = _stockSalesResultInfoMainCndtn.EdStockDate;
                //入力日(開始)
                _salesStockInfoResultMainCndtnWork.StInputDay = _stockSalesResultInfoMainCndtn.StInputDay;
                //入力日(終了)
                _salesStockInfoResultMainCndtnWork.EdInputDay = _stockSalesResultInfoMainCndtn.EdInputDay;
                //改頁
                _salesStockInfoResultMainCndtnWork.NewPageType = _stockSalesResultInfoMainCndtn.NewPageType;
                //仕入先(開始)
                _salesStockInfoResultMainCndtnWork.StSupplierCd = _stockSalesResultInfoMainCndtn.StSupplierCd;
                //仕入先(開始)
                _salesStockInfoResultMainCndtnWork.EdSupplierCd = _stockSalesResultInfoMainCndtn.EdSupplierCd;
                //出力指定
                _salesStockInfoResultMainCndtnWork.WayToOrderType = _stockSalesResultInfoMainCndtn.WayToOrderType;
                //在庫取寄指定
                _salesStockInfoResultMainCndtnWork.StockOrderDivCdType = _stockSalesResultInfoMainCndtn.StockOrderDivCdType;
                //売上伝票指定
                _salesStockInfoResultMainCndtnWork.SalesType = _stockSalesResultInfoMainCndtn.SalesType;
                //原価指定
                _salesStockInfoResultMainCndtnWork.StockUnitChngDivType = _stockSalesResultInfoMainCndtn.StockUnitChngDivType;
                //粗利チェック下限
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckLower = _stockSalesResultInfoMainCndtn.GrsProfitCheckLower;

                //粗利チェック2
                _salesStockInfoResultMainCndtnWork.GrossMarginSt = _stockSalesResultInfoMainCndtn.GrossMarginSt;

                //粗利チェック3
                _salesStockInfoResultMainCndtnWork.GrossMargin2Ed = _stockSalesResultInfoMainCndtn.GrossMargin2Ed;

                //粗利チェック4
                _salesStockInfoResultMainCndtnWork.GrossMargin3Ed = _stockSalesResultInfoMainCndtn.GrossMargin3Ed;

                //粗利チェック適正
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckBest = _stockSalesResultInfoMainCndtn.GrsProfitCheckBest;

                //粗利チェック上限
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckUpper = _stockSalesResultInfoMainCndtn.GrsProfitCheckUpper;

                //粗利チェック1(マーク)
                _salesStockInfoResultMainCndtnWork.GrossMargin1Mark = _stockSalesResultInfoMainCndtn.GrossMargin1Mark;

                //粗利チェック2(マーク)
                _salesStockInfoResultMainCndtnWork.GrossMargin2Mark = _stockSalesResultInfoMainCndtn.GrossMargin2Mark;

                //粗利チェック3(マーク)
                _salesStockInfoResultMainCndtnWork.GrossMargin3Mark = _stockSalesResultInfoMainCndtn.GrossMargin3Mark;

                //粗利チェック4(マーク)
                _salesStockInfoResultMainCndtnWork.GrossMargin4Mark = _stockSalesResultInfoMainCndtn.GrossMargin4Mark;

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
        /// 仕入売上実績表帳票テーブルデータ展開処理
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn">UI抽出条件クラス</param>
        /// <param name="custAccRecMainDt">展開対象DataTable</param>
        /// <param name="custAccRecMainWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表帳票テーブルデータを展開する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void DevSalesStockMainData(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
        {
            DataRow dr;
            bool existSalesFlg = false;
            StockSalesResultInfoWork disAccRecmainResWork = null;
            int count = custAccRecMainWork.Count;
            for (int i = 0; i < count; i++)
            {
                disAccRecmainResWork = (StockSalesResultInfoWork)custAccRecMainWork[i];

                existSalesFlg = !(string.IsNullOrEmpty(disAccRecmainResWork.SalesSlipNum));

                dr = custAccRecMainDt.NewRow();


                //仕入伝票番号
                dr[PMKOU02065EA.Col_SupplierSlipNo] = disAccRecmainResWork.SupplierSlipNo;
                //仕入行番号
                dr[PMKOU02065EA.Col_StockRowNo] = disAccRecmainResWork.StockRowNo;

                //拠点コード
                dr[PMKOU02065EA.Col_SectionCode] = disAccRecmainResWork.SectionCode;

                // 拠点名
                dr[PMKOU02065EA.Col_SectionGuideNm] = GetStringToByte(disAccRecmainResWork.SectionGuideNm, 20);

                if (existSalesFlg)
                {
                    // 得意先コード
                    dr[PMKOU02065EA.Col_CustomerCode] = disAccRecmainResWork.CustomerCode;

                    // 得意先名
                    dr[PMKOU02065EA.Col_CustomerName] = GetStringToByte(disAccRecmainResWork.CustomerName, 20);

                    // 売上日付
                    dr[PMKOU02065EA.Col_SalesDate] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.SalesDate);

                    // 伝票番号
                    dr[PMKOU02065EA.Col_SalesSlipNum] = disAccRecmainResWork.SalesSlipNum;
                }

                // 区分
                //仕入のみの伝票：仕入、売上が関連されている伝票：売上
                if (existSalesFlg)
                {
                    if (disAccRecmainResWork.SupplierSlipCd == 10)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "売上";
                    }
                    else if (disAccRecmainResWork.SupplierSlipCd == 20)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "返品";
                    }
                }
                else
                {
                    //dr[PMKOU02065EA.Col_KuBec] = "仕入";
                    if (disAccRecmainResWork.SupplierSlipCd == 10)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "仕入";
                    }
                    else if (disAccRecmainResWork.SupplierSlipCd == 20)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "返品";
                    }
                }

                // 担当者
                dr[PMKOU02065EA.Col_StockAgentName] = GetStringToByte(disAccRecmainResWork.StockAgentName, 8);

                if (existSalesFlg)
                {
                    // 受注者
                    dr[PMKOU02065EA.Col_FrontEmployeeNm] = GetStringToByte(disAccRecmainResWork.FrontEmployeeNm, 8);

                    // 発行者
                    dr[PMKOU02065EA.Col_SalesInputName] = GetStringToByte(disAccRecmainResWork.SalesInputName, 8);

                    // リマーク１
                    dr[PMKOU02065EA.Col_UoeRemark1] = GetStringToByte(disAccRecmainResWork.UoeRemark1,40);

                    // リマーク２
                    dr[PMKOU02065EA.Col_UoeRemark2] = GetStringToByte(disAccRecmainResWork.UoeRemark2, 20);

                    // 備考１
                    dr[PMKOU02065EA.Col_SlipNote] = GetStringToByte(disAccRecmainResWork.SlipNote, 40);

                    // 備考２
                    dr[PMKOU02065EA.Col_SlipNote2] = GetStringToByte(disAccRecmainResWork.SlipNote2, 40);

                    // 備考３
                    dr[PMKOU02065EA.Col_SlipNote3] = GetStringToByte(disAccRecmainResWork.SlipNote3, 40);
                }

                // 仕入備考
                dr[PMKOU02065EA.Col_SupplierSlipNote1] = GetStringToByte(disAccRecmainResWork.SupplierSlipNote1, 40);

                // 品番
                dr[PMKOU02065EA.Col_GoodsNo] = disAccRecmainResWork.GoodsNo;

                // 在取
                //0：取寄せ、1：在庫
                if (0 == disAccRecmainResWork.StockOrderDivCd)
                {
                    dr[PMKOU02065EA.Col_StockOrderDivCd] = "取寄";
                }
                else if (1 == disAccRecmainResWork.StockOrderDivCd)
                {
                    dr[PMKOU02065EA.Col_StockOrderDivCd] = "在庫";
                }

                // 品名
                dr[PMKOU02065EA.Col_GoodsName] = disAccRecmainResWork.GoodsName;

                // 標準価格
                //dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = disAccRecmainResWork.ListPriceTaxExcFl;
                if (disAccRecmainResWork.ListPriceTaxExcFl == 0)
                {
                    dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = DBNull.Value; 
                }
                else 
                {
                    //if (disAccRecmainResWork.StockGoodsCd == 0)
                    //{
                        dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = disAccRecmainResWork.ListPriceTaxExcFl;
                    //}
                    //else
                    //{
                    //    dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = DBNull.Value; 
                    //}
                }

                // 数量
                //dr[PMKOU02065EA.Col_StockCount] = disAccRecmainResWork.StockCount;
                if (disAccRecmainResWork.StockCount == 0)
                {
                    dr[PMKOU02065EA.Col_StockCount] = DBNull.Value; 
                }
                else 
                {
                    if (disAccRecmainResWork.StockGoodsCd == 0)
                    {
                        dr[PMKOU02065EA.Col_StockCount] = disAccRecmainResWork.StockCount;
                    }
                    else
                    {
                        dr[PMKOU02065EA.Col_StockCount] = DBNull.Value; 
                    }
                }

                long grpMoney = disAccRecmainResWork.SalesMoneyTaxExc - disAccRecmainResWork.StockPriceTaxExc;
                if (existSalesFlg)
                {
                    // 売単価
                    dr[PMKOU02065EA.Col_SalesUnPrcTaxExcFl] = disAccRecmainResWork.SalesUnPrcTaxExcFl;

                    // 売上金額
                    dr[PMKOU02065EA.Col_SalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;

                    // 粗利金額
                    dr[PMKOU02065EA.Col_GrpMoney] = grpMoney;

                    // 粗利率
                    decimal tmpPct = new decimal(0.0);

                    if (disAccRecmainResWork.SalesMoneyTaxExc != 0)
                    {
                        tmpPct = decimal.Round(((Convert.ToDecimal(grpMoney) / Convert.ToDecimal(disAccRecmainResWork.SalesMoneyTaxExc)) * 100), 2, MidpointRounding.AwayFromZero);
                        dr[PMKOU02065EA.Col_GrpPct] = tmpPct;
                    }
                    double pct = Convert.ToDouble(tmpPct);
                    // マーク
                    if (pct < _stockSalesResultInfoMainCndtn.GrsProfitCheckLower)
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin1Mark;
                    }
                    else if ((pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckLower)
                           && (pct < _stockSalesResultInfoMainCndtn.GrossMargin2Ed))
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin2Mark;
                    }
                    else if ((pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckBest)
                            && (pct < _stockSalesResultInfoMainCndtn.GrossMargin3Ed))
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin3Mark;
                    }
                    else if (pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckUpper)
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin4Mark;
                    }
                }



                // 原単価
                //dr[PMKOU02065EA.Col_StockUnitPriceFl] = disAccRecmainResWork.StockUnitPriceFl;
                if (disAccRecmainResWork.StockUnitPriceFl == 0) 
                {
                    dr[PMKOU02065EA.Col_StockUnitPriceFl] = DBNull.Value; 
                } else 
                {
                    dr[PMKOU02065EA.Col_StockUnitPriceFl] = disAccRecmainResWork.StockUnitPriceFl;
                }

                // 仕入金額
                dr[PMKOU02065EA.Col_StockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                // 仕入先
                dr[PMKOU02065EA.Col_SupplierCd] = disAccRecmainResWork.SupplierCd;

                // 伝票番号
                dr[PMKOU02065EA.Col_PartySaleSlipNum] = disAccRecmainResWork.PartySaleSlipNum;

                // 仕入日付
                dr[PMKOU02065EA.Col_StockDate] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.StockDate);

                // 仕入先 for sort
                dr[PMKOU02065EA.Col_SupplierCdForSort] = disAccRecmainResWork.SupplierCd;

                // 伝票番号 for sort
                dr[PMKOU02065EA.Col_PartySaleSlipNumForSort] = disAccRecmainResWork.PartySaleSlipNum;

                // 仕入日付 for sort
                dr[PMKOU02065EA.Col_StockDateForSort] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.StockDate);

                dr[PMKOU02065EA.CT_StockConf_DailyHeaderDataField] = disAccRecmainResWork.SectionCode
                                + disAccRecmainResWork.SupplierCd.ToString("d6")
                                + GetDateTimeString(TDateTime.LongDateToDateTime(disAccRecmainResWork.StockDate), ct_DateFormatForDataField)
                                + disAccRecmainResWork.SupplierSlipNo.ToString("d9");

                // 伝票キー
                string slipKey = (string)dr[PMKOU02065EA.CT_StockConf_DailyHeaderDataField];

                if (disAccRecmainResWork.StockSlipCdDtl == 0)
                {
                    //仕入
                    dr[PMKOU02065EA.Col_SalesSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                    dr[PMKOU02065EA.Col_SalesGrpMoney] = grpMoney;
                    dr[PMKOU02065EA.Col_SalesStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                    // 既に数えた伝票は数えない
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // 伝票枚数(仕入)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 0;
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        // 伝票枚数(仕入)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 1;
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;

                    }

                }
                else if (disAccRecmainResWork.StockSlipCdDtl == 1)
                {
                    //返品
                    dr[PMKOU02065EA.Col_RetGdsSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                    dr[PMKOU02065EA.Col_RetGdsGrpMoney] = grpMoney;
                    dr[PMKOU02065EA.Col_RetGdsStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                    // 既に数えた伝票は数えない
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // 伝票枚数(返品)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 0;
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        // 伝票枚数(返品)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 1;
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;
                    }
                }
                else if (disAccRecmainResWork.StockSlipCdDtl == 2)
                {
                    //値引
                    if (disAccRecmainResWork.StockCount != 0.00)
                    {
                        dr[PMKOU02065EA.Col_DistSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;

                        dr[PMKOU02065EA.Col_DistGrpMoney] = grpMoney;
                        dr[PMKOU02065EA.Col_DistStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                    }
                    else
                    {
                        dr[PMKOU02065EA.Col_DistSalesMoneyTaxExc] = 0.00;

                        if (disAccRecmainResWork.SupplierSlipCd == 10)
                        {
                            dr[PMKOU02065EA.Col_SalesSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                            dr[PMKOU02065EA.Col_SalesStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                        }
                        else if (disAccRecmainResWork.SupplierSlipCd == 20)
                        {
                            dr[PMKOU02065EA.Col_RetGdsSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                            dr[PMKOU02065EA.Col_RetGdsStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                        }
                    }
                    // 既に数えた伝票は数えない
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // 伝票枚数(仕入)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 0;
                        // 伝票枚数(返品)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 0;
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        if (disAccRecmainResWork.SupplierSlipCd == 10)
                        {
                            // 伝票枚数(仕入)
                            dr[PMKOU02065EA.Col_SalesCountNumber] = 1;
                        }
                        else if (disAccRecmainResWork.SupplierSlipCd == 20)
                        {
                            // 伝票枚数(返品)
                            dr[PMKOU02065EA.Col_ReturnCountNumber] = 1;
                        }
                        // 伝票枚数(合計)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;
                    }
                }



                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                else
                {
                    // 仕入先
                    dr[PMKOU02065EA.Col_SupplierCd] = string.Empty;

                    // 伝票番号
                    dr[PMKOU02065EA.Col_PartySaleSlipNum] = string.Empty;

                    // 仕入日付
                    dr[PMKOU02065EA.Col_StockDate] = string.Empty;
                }

                custAccRecMainDt.Rows.Add(dr);
            }
        }


        /// <summary>
        /// 日付文字列を取得します。
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="format">フォーマット文字列</param>
        /// <returns>日付文字列</returns>
        public static string GetDateTimeString(DateTime date, string format)
        {
            if (date == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return date.ToString(format);
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
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Date       : 2009.05.13</br>
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
                            errMsg = "帳票出力設定の読込に失敗しました。";
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
