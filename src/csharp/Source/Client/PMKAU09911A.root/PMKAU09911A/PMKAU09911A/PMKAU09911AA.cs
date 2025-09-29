using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 請求売掛残高出力アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求売掛残高出力アクセスクラスです。</br>
    /// <br>Programmer : 30521 本山 貴将</br>
    /// <br>Date       : 2014/08/25</br>        
    public class PMKAU09911AA
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKAU09911AA()
        {
            // アクセスクラスを作成
            this._customerAcs = new CustomerSearchAcs();
                        
            // リモートインスタンス取得
            this._iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
                    
        }
        #endregion 

        #region Private Members

        // リモートDB検索クラス インタフェースオブジェクト
        private ICustPrtPprWorkDB _iCustPrtPprWorkDB;
                
        // 得意先取得用アクセスクラス
        private CustomerSearchAcs _customerAcs;

        #endregion

        #region Public Member
        
        // 出力データ
        public DataTable _outputTable;

        #endregion

        #region 出力列定義
        /// <summary>請求残抽出結果テーブル</summary>
        private const string TBL_DEMANDBLCEXTRARST = "請求残抽出結果テーブル"; 
        /// <summary>行No</summary>
        private const string COL_ROWNO = "行No";        
        /// <summary>計上日</summary>
        private string COL_ADDUPDATE = "請求日";        
        /// <summary>前回残高</summary>
        private const string COL_LASTTIMEBLC = "前回残高";
        /// <summary>今回入金額</summary>
        private const string COL_THISTIMEDMDNRML = "今回入金額";
        /// <summary>繰越残高</summary>
        private const string COL_THISTIMETTLBLC = "繰越残高";
        /// <summary>今回売上額</summary>
        private const string COL_THISTIMESALES = "今回売上額";
        /// <summary>返品値引額</summary>
        private const string COL_SALESPRICERGDSDIS = "返品・値引額";
        /// <summary>純売上額</summary>
        private const string COL_OFSTHISTIMESALES = "純売上額";
        /// <summary>消費税額</summary>
        private const string COL_OFSTHISSALESTAX = "消費税額";
        /// <summary>今回合計</summary>
        private const string COL_THISSALESPRICTOTAL = "税込売上額";
        /// <summary>今回残高</summary>
        private const string COL_AFCALBLC = "今回残高";
        /// <summary>伝票枚数</summary>
        private const string COL_SALESSLIPCOUNT = "伝票枚数";
        /// <summary>請求先名</summary>
        private const string COL_CUSTOMERNAME = "請求先名";
        /// <summary>請求先コード</summary>
        private const string COL_CUSTOMERCODE = "請求先";
        /// <summary>拠点コード</summary>
        private const string COL_SECTIONCODE = "拠点";
        /// <summary>請求拠点</summary>
        private const string COL_CLAIMSECTIONCODE = "請求拠点";
        /// <summary>与信区分</summary>
        private const string COL_CREDITMNGCODE = "与信区分";
        /// <summary>与信額</summary>
        private const string COL_CREDITMONEY = "与信額";
        /// <summary>警告与信額</summary>
        private const string COL_WARNINGCREDITMONEY = "警告与信額";
        /// <summary>与信売掛残高</summary>
        private const string COL_PRSNTACCRECBALANCE = "与信売掛残高";
        /// <summary>請求締日</summary>
        private const string COL_TOTALDAY = "請求締日";
        /// <summary>月次締日</summary>
        private const string COL_COMPANYTOTALDAY = "月次締日";
        /// <summary>請求・月次差異額</summary>
        private const string COL_DIFFERENCE = "請求・月次差異額";
        /// <summary>与信額差異</summary>
        private const string COL_CREDITDIFFERENCE = "与信額差異";
        /// <summary>売掛区分</summary>
        private const string COL_ACCRECDIVCD = "売掛区分";
        #endregion

        /// <summary>
        /// 請求残高取得処理
        /// </summary>
        /// <param name="custPrtPprBlnce">検索条件</param>
        /// <param name="remainType">残高種別</param>
        /// <param name="customerList">得意先リスト</param>
        /// <returns>status</returns></br>
        /// <remarks>
        /// <br>Note       : 請求残高を取得します。</br>
        /// <br>Programmer : 30521 本山 貴将</br>
        /// <br>Date       : 2014.08.25</br>
        /// </remarks>
        public int SearchBalanceAll(ref CustPrtPprBlnce custPrtPprBlnce, int remainType, List<CustomerInfo> customerList)
        {
            CustPrtPprBlnce custPrtPprBlnceBackup = custPrtPprBlnce.Clone();
            
            // 0:請求、1:売掛
            if (remainType == 0)
                COL_ADDUPDATE = "請求日";
            else if (remainType == 1)
                COL_ADDUPDATE = "年月";

            try
            {                
                string sectionCodeSt;
                string sectionCodeEd;

                //---------------------------------
                // 入力チェック
                //---------------------------------
                // 拠点コード
                if (custPrtPprBlnce.SectionCode == null || custPrtPprBlnce.SectionCode.Length == 0)
                {
                    custPrtPprBlnce.SectionCode = new string[] { "00" };
                    sectionCodeSt = "00";
                    sectionCodeEd = "00";
                }
                else
                {
                    sectionCodeSt = custPrtPprBlnce.SectionCode[0].Trim();
                    sectionCodeEd = custPrtPprBlnce.SectionCode[custPrtPprBlnce.SectionCode.Length - 1].Trim();
                }
                string sectionCode = custPrtPprBlnce.SectionCode[0].Trim();

                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                int rowNo = 0;

                // テーブルを作る
                _outputTable = new DataTable(TBL_DEMANDBLCEXTRARST);

                #region データテーブルに項目を追加
                // _outputTable.Columns.Add(COL_ROWNO, typeof(int));
                _outputTable.Columns.Add(COL_SECTIONCODE, typeof(string));
                _outputTable.Columns.Add(COL_CUSTOMERCODE, typeof(string));
                _outputTable.Columns.Add(COL_CUSTOMERNAME, typeof(string));
                _outputTable.Columns.Add(COL_ADDUPDATE, typeof(string));
                _outputTable.Columns.Add(COL_LASTTIMEBLC, typeof(long));
                _outputTable.Columns.Add(COL_THISTIMEDMDNRML, typeof(long));
                _outputTable.Columns.Add(COL_THISTIMETTLBLC, typeof(long));
                _outputTable.Columns.Add(COL_THISTIMESALES, typeof(long));
                _outputTable.Columns.Add(COL_SALESPRICERGDSDIS, typeof(long));
                _outputTable.Columns.Add(COL_OFSTHISTIMESALES, typeof(long));
                _outputTable.Columns.Add(COL_OFSTHISSALESTAX, typeof(long));
                _outputTable.Columns.Add(COL_THISSALESPRICTOTAL, typeof(long));
                _outputTable.Columns.Add(COL_AFCALBLC, typeof(long));
                _outputTable.Columns.Add(COL_SALESSLIPCOUNT, typeof(int));

                //_outputTable.Columns.Add(COL_CLAIMSECTIONCODE, typeof(int));
                //_outputTable.Columns.Add(COL_CREDITMNGCODE, typeof(int));
                //_outputTable.Columns.Add(COL_CREDITMONEY, typeof(int));
                //_outputTable.Columns.Add(COL_WARNINGCREDITMONEY, typeof(int));
                //_outputTable.Columns.Add(COL_PRSNTACCRECBALANCE, typeof(int));
                //_outputTable.Columns.Add(COL_TOTALDAY, typeof(int));
                //_outputTable.Columns.Add(COL_COMPANYTOTALDAY, typeof(int));
                //_outputTable.Columns.Add(COL_DIFFERENCE, typeof(int));
                //_outputTable.Columns.Add(COL_CREDITDIFFERENCE, typeof(int));
                //_outputTable.Columns.Add(COL_ACCRECDIVCD, typeof(int));
                #endregion

                foreach (CustomerInfo customer in customerList)
                {
                    int customerCode = customer.CustomerCode;
                    if (customerCode != 0)
                    {
                        // 抽出拠点の種別によって拠点コードを選択する
                        if (custPrtPprBlnce.RemainSectionType == 0)
                        {
                            sectionCode = customer.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = customer.ClaimSectionCode.Trim();
                        }
                        
                        //----------------------------------------------
                        // ツールでは得意先CDと請求先が異なる場合(親子関係の子)でも、残額が存在すれば出力します。
                        // 上記の動きは帳票と同じ。
                        //----------------------------------------------
                        if (customer.CustomerCode == customer.ClaimCode)
                        {
                            if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                                Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                                Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode) ||
                                sectionCodeEd == "00" && Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode))
                            {
                                custPrtPprBlnce.CustomerCode = 0;
                                custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                                custPrtPprBlnce.SectionCode[0] = sectionCode;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        // 得意先≠請求先
                        else
                        {
                            //if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                            //    Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                            //    Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode) ||
                            //    sectionCodeEd == "00" && Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode))
                            //{
                            //    custPrtPprBlnce.CustomerCode = customer.ClaimCode;
                            //    custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                            //    custPrtPprBlnce.SectionCode[0] = sectionCode;
                            //}
                            //else
                            //{
                            //    continue;
                            //}
                            continue;
                        }
                        //---------------------------------
                        // パラメータクラスを作成
                        //---------------------------------
                        CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();
                        CustPrtPprBlnce2CustPrtPprBlnceWork(ref custPrtPprBlnce, ref custPrtPprBlnceWork);

                        //---------------------------------
                        // 返り値で使用するクラスを作成
                        //---------------------------------
                        CustPrtPprBlTblRsltWork custPrtPprBlTblRsltWork = new CustPrtPprBlTblRsltWork();
                        object custPrtPprBlTblRsltWorkObj = (object)custPrtPprBlTblRsltWork;

                        // ツールでは与信残高出力しないけど、将来使うかもしれないので、一応記述
                        if (custPrtPprBlnce.CreditMoneyOutputDiv)
                        {
                            // 残高一覧表示検索（与信残高出力用）
                            status = this._iCustPrtPprWorkDB.SearchBlTblOutput(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.CreditMoneyOutputDiv);
                        }
                        else
                        {
                            // 残高一覧表示検索
                            status = this._iCustPrtPprWorkDB.SearchBlTbl(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                        }
                        
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            ExtrInfo_DemandTotal extrInfoDemandTotal = new ExtrInfo_DemandTotal();
                            DemandPrintAcs demandPrintAcs = new DemandPrintAcs();
                            
                            // 取得したデータをデータテーブルに入れる 
                            foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                            {
                                // 売掛0円レコードを弾く
                                if (remainType == 1)
                                {
                                    if (data.LastTimeBlc == 0 &&
                                       data.ThisTimeDmdNrml == 0 &&
                                       data.ThisTimeTtlBlc == 0 &&
                                       data.ThisTimeSales == 0 &&
                                        data.SalesPricRgdsDis == 0 &&
                                         data.OfsThisSalesTax == 0 &&
                                          data.OfsThisTimeSales == 0 &&
                                          data.AfCalBlc == 0)
                                    {
                                        continue;
                                    }
                                }

                                DataRow dr = _outputTable.NewRow();

                                // dr[COL_ROWNO] = rowNo;
                                dr[COL_SECTIONCODE] = sectionCode;
                                dr[COL_CUSTOMERCODE] = String.Format("{0:D8}", customer.ClaimCode);
                                dr[COL_CUSTOMERNAME] = customer.ClaimName;

                                // 0:請求、1:売掛
                                if (remainType == 0)
                                    dr[COL_ADDUPDATE] = data.AddUpDate.ToString("yyyyMMdd");
                                else if (remainType == 1)
                                    dr[COL_ADDUPDATE] = data.AddUpDate.ToString("yyyyMM");

                                dr[COL_LASTTIMEBLC] = data.LastTimeBlc;
                                dr[COL_THISTIMEDMDNRML] = data.ThisTimeDmdNrml;
                                dr[COL_THISTIMETTLBLC] = data.ThisTimeTtlBlc;
                                dr[COL_THISTIMESALES] = data.ThisTimeSales;
                                dr[COL_SALESPRICERGDSDIS] = data.SalesPricRgdsDis;
                                dr[COL_OFSTHISSALESTAX] = data.OfsThisSalesTax;
                                dr[COL_THISSALESPRICTOTAL] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                                dr[COL_OFSTHISTIMESALES] = data.OfsThisTimeSales;
                                dr[COL_AFCALBLC] = data.AfCalBlc;
                                dr[COL_SALESSLIPCOUNT] = data.SalesSlipCount;

                                rowNo++;

                                _outputTable.Rows.Add(dr);
                            
                            }                            
                            
                            // ソート
                            // dtのスキーマや制約をコピーしたDataTableを作成します。
                            DataTable clonetable = _outputTable.Clone();

                            DataRow[] rows = _outputTable.Select(null, COL_SECTIONCODE + "," + COL_CUSTOMERCODE + "," + COL_ADDUPDATE);

                            foreach (DataRow row in rows)
                            {
                                DataRow addRow = clonetable.NewRow();

                                // カラム情報をコピーします。
                                addRow.ItemArray = row.ItemArray;

                                // DataTableに格納します。
                                clonetable.Rows.Add(addRow);
                            }

                            _outputTable = clonetable;
                        }
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                custPrtPprBlnce = custPrtPprBlnceBackup;
            }
        }



        /// <summary>
        /// パラメータクラス(PMKAU04002E.CustPrtPprBlnce)からリモートパラメータクラス(PMKAU04016D.CustPrtPprBlnceWork)クラスへ変換
        /// </summary>
        /// <param name="custPrtPpr"></param>
        /// <param name="custPrtPprWork"></param>
        private void CustPrtPprBlnce2CustPrtPprBlnceWork(ref CustPrtPprBlnce custPrtPprBlnce, ref CustPrtPprBlnceWork custPrtPprBlnceWork)
        {
            custPrtPprBlnceWork.EnterpriseCode = custPrtPprBlnce.EnterpriseCode;
            custPrtPprBlnceWork.SectionCode = custPrtPprBlnce.SectionCode;
            custPrtPprBlnceWork.CustomerCode = custPrtPprBlnce.CustomerCode;
            custPrtPprBlnceWork.ClaimCode = custPrtPprBlnce.ClaimCode;
            custPrtPprBlnceWork.St_AddUpYearMonth = custPrtPprBlnce.St_AddUpYearMonth;
            custPrtPprBlnceWork.Ed_AddUpYearMonth = custPrtPprBlnce.Ed_AddUpYearMonth;
        }

    }
}
