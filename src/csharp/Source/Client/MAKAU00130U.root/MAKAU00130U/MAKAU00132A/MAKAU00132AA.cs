//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上／仕入月次更新
// プログラム概要   ：売上／仕入月次更新を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/08/21     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/08     修正内容：Mantis【11603】全拠点指定対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/12     修正内容：Mantis【13247】買掛オプション無の期末更新設定を修正
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：zhouyu
// 修正日    2011/07/15     修正内容：連番 42 月次更新で、古いデータを削除sの対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：FSI佐々木 貴英
// 修正日    2012/09/13     修正内容：仕入総括対応
// ---------------------------------------------------------------------//

# region ※using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先請求金額マスタアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先請求金額マスタのアクセス制御を行います。</br>
	/// <br>Programmer	: 渡邉貴裕</br>
	/// <br>Date		: 2007.04.03</br>
    /// <br></br>
    /// <br>Update Note: 仕入総括処理対応 オプションコード判定で仕入締次更新集計方法を設定</br>
    /// <br>Programmer : FSI佐々木 貴英</br>
    /// <br>Date       : 2012/09/13</br>
    /// </remarks>
	public class CustDmdPrcAcs
	{
		# region ■Private Member
		/// <summary>リモートオブジェクト格納バッファ</summary>
		//private ICustDmdPrcDB _iCustDmdPrcDB = null;
        private IMonthlyAddUpDB _iMonthlyAddUpDB = null;
		/// <summary>ユーザーガイドオブジェクト格納バッファ(HashTable)</summary>
//*		private Hashtable _CustDmdPrcGdBdTable;
		/// <summary>ユーザーガイドオブジェクト格納バッファ(ArrayList)</summary>
//*		private ArrayList _CustDmdPrcGdBdList;
		/// <summary>キャリアマスタクラスStatic</summary>
//*		private static Hashtable _carrierTable = null;

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>自社設定マスタアクセスクラス</summary>
        private CompanyInfAcs _companyInfAcs;
        /// <summary>自社設定マスタ</summary>
        private CompanyInf _companyInf;
        /// <summary>在庫管理全体設定マスタアクセスクラス</summary>
        private StockMngTtlStAcs _stockMngTtlStAcs;
        /// <summary>在庫管理全体設定マスタ</summary>
        private StockMngTtlSt _stockMngTtlSt;
        /// <summary>拠点情報マスタアクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>日付取得アクセスクラス</summary>
        private DateGetAcs _dateGetAcs;
        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<
        # endregion				    
		  
		# region ■Constracter
		/// <summary>
		/// 得意先請求金額マスタアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先請求金額マスタアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcAcs()
		{
    		try
			{
				// リモートオブジェクト取得
				this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iMonthlyAddUpDB = null;
			}

            // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
            this._companyInfAcs = new CompanyInfAcs();
            this._companyInf = new CompanyInf();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            // 自社設定マスタ読込
            LoadCompanyInf();

            // 在庫管理全体設定マスタ読込
            LoadStockMngTtlSt();
            // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<
		}
		# endregion

		#region ■Public Method

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addupYearMonth">計上年月</param>
        /// <param name="prevTotalDay">前回月次処理日</param>
        /// <param name="currentTotalDay">今回月次処理日</param>
        /// <param name="monAddUpUpdDiv">売上・仕入区分(0:売上　1:仕入)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: オプションコード判定で呼び出す月次更新処理を振り分けるよう変更</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/13</br>
        /// </remarks>
        public int RegistDmdData(string enterpriseCode, 
                                 string sectionCode, 
                                 DateTime addupYearMonth,
                                 DateTime prevTotalDay,
                                 DateTime currentTotalDay,
                                 int monAddUpUpdDiv,
                                 out string msg)
        {
            MonthlyAddUpWork monthlyAddupWork = new MonthlyAddUpWork();
            monthlyAddupWork = GetMonthlyAddUpWork(enterpriseCode,
                                                   sectionCode,
                                                   2,
                                                   addupYearMonth,
                                                   prevTotalDay,
                                                   currentTotalDay,
                                                   monAddUpUpdDiv);

            object paraObj = monthlyAddupWork;
            object retObj;
            bool dbTimeOut;

            int status = 0;
            msg = "";

            try
            {
                // --- DEL 2012/09/13 ----------->>>>>
                //status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                // --- DEL 2012/09/13 -----------<<<<<
                // --- ADD 2012/09/13 ----------->>>>>
                #region 仕入総括機能（個別）
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                if (PurchaseStatus.Contract == ps)
                {
                    // 仕入総括オプションが有効の場合、
                    // 仕入総括形式の支払締更新処理を実行する
                    status = this._iMonthlyAddUpDB.WriteByAddUpSecCode(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                }
                else
                {
                    // 既存形式の支払締更新処理を実行する
                    status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg, monAddUpUpdDiv);
                }
                #endregion 仕入総括機能（個別）
                // --- ADD 2012/09/13 -----------<<<<<
                
                //ADD START zhouyu 2011/07/15 FOR 連番 42
                //在庫更新区分
                if (monthlyAddupWork.StockUpdDiv == 1)
                {
                    bool msgDiv = false;
                    status = this._iMonthlyAddUpDB.Delete(ref paraObj, out msgDiv, out msg, monAddUpUpdDiv);
                }
                else
                {
                    //なし
                }
                //ADD END zhouyu 2011/07/15 FOR 連番 42
                if (status == 0)
                {
                    // キャッシュをクリア
                    this._totalDayCalculator.ClearCache();
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addUpYearMonth">計上年月</param>
        /// <param name="prevTotalDay">前回月次処理日</param>
        /// <param name="currentTotalDay">今回月次処理日</param>
        /// <param name="monAddUpUpdDiv">売上・仕入区分(0:売上　1:仕入)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int BanishDmdData(string enterpriseCode, 
                                 string sectionCode, 
                                 DateTime addUpYearMonth,
                                 DateTime prevTotalDay,
                                 DateTime currentTotalDay,
                                 int monAddUpUpdDiv,
                                 out string msg)
        {
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
            monthlyAddUpWork = GetMonthlyAddUpWork(enterpriseCode,
                                                   sectionCode,
                                                   1,
                                                   addUpYearMonth,
                                                   prevTotalDay,
                                                   currentTotalDay,
                                                   monAddUpUpdDiv);

            object paraObj = monthlyAddUpWork;
            object retObj;
            bool dbtimeOut;

            int status;
            msg = "";

            try
            {
                status = this._iMonthlyAddUpDB.Delete(ref paraObj, out retObj, out dbtimeOut, out msg, monAddUpUpdDiv);
                if (status == 0)
                {
                    // キャッシュをクリア
                    this._totalDayCalculator.ClearCache();
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 売上仕入月次更新履歴取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="recPayDiv">売上仕入区分(0:売上　1:仕入)</param>
        /// <param name="prevTotalDay">前回月次処理日</param>
        /// <param name="currentTotalDay">今回月次処理日</param>
        /// <param name="prevTotalMonth">前回月次処理年月</param>
        /// <param name="currentTotalMonth">今回月次処理年月</param>
        /// <param name="convertProcessDivCd">コンバート処理区分</param>
        /// <returns>ステータス</returns>
        public int GetHisTotalDayMonthlyAccRecPay(string sectionCode,
                                                  int recPayDiv,
                                                  out DateTime prevTotalDay,
                                                  out DateTime currentTotalDay,
                                                  out DateTime prevTotalMonth,
                                                  out DateTime currentTotalMonth,
                                                  out int convertProcessDivCd)
        {
            int status = 0;

            prevTotalDay = new DateTime();
            currentTotalDay = new DateTime();
            prevTotalMonth = new DateTime();
            currentTotalMonth = new DateTime();
            convertProcessDivCd = 0;

            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                // 全社の場合
                sectionCode = "";
            }
            else
            {
                // 各拠点の場合
                sectionCode = sectionCode.PadLeft(2, '0');
            }

            try
            {
                if (recPayDiv == 0)
                {
                    this._totalDayCalculator.ClearCache();
                    this._totalDayCalculator.InitializeHisMonthlyAccRec();

                    // 売上月次更新履歴取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
                else
                {
                    this._totalDayCalculator.ClearCache();
                    this._totalDayCalculator.InitializeHisMonthlyAccPay();

                    // 仕入月次更新履歴取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
                currentTotalDay = new DateTime();
                prevTotalMonth = new DateTime();
                currentTotalMonth = new DateTime();

                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/21 Partsman用に変更
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>        
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        public int RegistDmdData(out int retTotalCnt,string enterpriseCode,string sectionCode,DateTime addUpdate,DateTime addUpYM,int totalDay,int mode,out string msg)
        {

            MonthlyAddUpWork monthlyAddupWork = new MonthlyAddUpWork();
            monthlyAddupWork.AddUpSecCode = sectionCode;
            monthlyAddupWork.EnterpriseCode = enterpriseCode;
            monthlyAddupWork.CompanyTotalDay = totalDay;
            monthlyAddupWork.AddUpDate = addUpdate; 
            monthlyAddupWork.AddUpYearMonth = addUpYM;

            monthlyAddupWork.ProcCntntsFlag = mode; // 1 仕入月次更新　2 売上月次更新
                        
            object paraObj = monthlyAddupWork;
            object retObj = (object)monthlyAddupWork;
            bool dbTimeOut;

            int status = this._iMonthlyAddUpDB.Write(ref paraObj, out retObj, out dbTimeOut, out msg);

            retTotalCnt = 0;            
            
            return status;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <param name="target"></param>
        /// <param name="mode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int BanishDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, int totalDay,DateTime addUpDate,DateTime addUpDateYM,int mode,out string msg)
        {
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
            
            monthlyAddUpWork.EnterpriseCode = enterpriseCode;
            monthlyAddUpWork.AddUpSecCode = sectionCode;
            monthlyAddUpWork.CompanyTotalDay = totalDay; //締日            
            monthlyAddUpWork.ProcCntntsFlag = mode; // 1 月次更新 2 売上月次更新
            monthlyAddUpWork.AddUpYearMonth = addUpDateYM;
            monthlyAddUpWork.AddUpDate = addUpDate;

            object paraObj = monthlyAddUpWork;
            MonthlyAddUpStatusWork monthlyAddUpStatusWork = new MonthlyAddUpStatusWork();
            object retObj = (object)monthlyAddUpWork;
            bool dbtimeOut;

            int status = this._iMonthlyAddUpDB.Delete(ref paraObj,out retObj,out dbtimeOut,out msg);

            retTotalCnt = 0;

            return status;

        }
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 Partsman用に変更

        #endregion

        #region ■Private Method

        #region DEL 2008/08/21 使用していないのでコメントアウト
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ローカルファイル読込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
        /// <br>Programer  : 渡邉貴裕</br>
        /// <br>Date       : 2006.12.19</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // オフラインシリアライズデータ作成部品I/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search用 --- //
            // KeyList設定
            string[] carrierKeys = new string[1];
            carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ローカルファイル読込み処理
            object wkObj = offlineDataSerializer.DeSerialize("CustDmdPrcAcs", carrierKeys);
            // ArrayListにセット
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                // キャリアクラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
                //				CopyToStaticFromWorker(wkList);
            }
        }
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 使用していないのでコメントアウト

        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 自社設定マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int LoadCompanyInf()
        {
            int status = 0;

            try
            {
                status = this._companyInfAcs.Read(out this._companyInf, LoginInfoAcquisition.EnterpriseCode);
                if (status != 0)
                {
                    this._companyInf = new CompanyInf();
                }
            }
            catch
            {
                this._companyInf = new CompanyInf();
            }

            return (status);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ読込
        /// </summary>
        /// <returns>ステータス</returns>
        private int LoadStockMngTtlSt()
        {
            int status = 0;
            this._stockMngTtlSt = new StockMngTtlSt();

            try
            {
                ArrayList retList;
                status = this._stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.SectionCode.Trim() == "00")
                        {
                            this._stockMngTtlSt = stockMngTtlSt;
                            break;
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }

            return (status);
        }

        /// <summary>
        /// 在庫更新区分取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="targetYearMonth">対象年月</param>
        /// <param name="monAddUpUpdDiv">売上仕入区分(0:売上　1:仕入)</param>
        /// <returns>在庫更新区分</returns>
        private int GetStockUpdDiv(string sectionCode, DateTime targetYearMonth, int monAddUpUpdDiv)
        {
            int stockUpdDiv = 0;

            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;

            int status;

            if (monAddUpUpdDiv == 0)
            {
                // 売上月次更新の場合、仕入月次更新履歴取得
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        1,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }
            else
            {
                // 仕入月次更新の場合、売上月次更新履歴取得
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        0,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }

            if (currentTotalMonth > targetYearMonth)
            {
                // 更新
                stockUpdDiv = 1;
            }
            else
            {
                // 更新なし
                stockUpdDiv = 2;
            }

            return stockUpdDiv;
        }

        // DEL 2009/04/08 ------>>>
        #region 仕様変更のため削除
        ///// <summary>
        ///// 期末更新区分取得処理
        ///// </summary>
        ///// <param name="targetYearMonth">対象年月</param>
        ///// <returns>ステータス</returns>
        //private int GetTermLastDiv(DateTime targetYearMonth)
        //{
        //    int termLastDiv = 0;

        //    DateTime startMonthDate;
        //    DateTime endMonthDate;
        //    DateTime yearMonth;

        //    try
        //    {
        //        this._dateGetAcs.GetLastMonth(out startMonthDate, out endMonthDate, out yearMonth);
                
        //        if ((targetYearMonth.Year == yearMonth.Year) &&
        //            (targetYearMonth.Month == yearMonth.Month))
        //        {
        //            // 期末
        //            termLastDiv = 1;
        //        }
        //        else
        //        {
        //            // 期末以外
        //            termLastDiv = 0;
        //        }
        //    }
        //    catch
        //    {
        //        startMonthDate = new DateTime();
        //        endMonthDate = new DateTime();
        //        yearMonth = new DateTime();
        //    }

        //    return termLastDiv;
        //}
        #endregion
        // DEL 2009/04/08 ------<<<

        // ADD 2009/04/08 ------>>>
        /// <summary>
        /// 期末更新区分取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="targetYearMonth">対象年月</param>
        /// <param name="procCntntsFlag">処理内容フラグ(1:締取消　2:月次更新)</param>
        /// <param name="monAddUpUpdDiv">売上仕入区分(0:売上　1:仕入)</param>
        /// <param name="ps">買掛オプション</param>
        /// <returns>ステータス</returns>
        //private int GetTermLastDiv(string sectionCode, DateTime targetYearMonth, int procCntntsFlag, int monAddUpUpdDiv)      // DEL 2009/05/12
        private int GetTermLastDiv(string sectionCode, DateTime targetYearMonth, int procCntntsFlag, int monAddUpUpdDiv, PurchaseStatus ps)     // ADD 2009/05/12
        {
            int termLastDiv = 0;

            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;

            int status;

            List<DateTime> startMonthDateList;
            List<DateTime> endMonthDateList;
            List<DateTime> yearMonthList;

            if (monAddUpUpdDiv == 0)
            {
                // 売上月次更新の場合、仕入月次更新履歴取得
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        1,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }
            else
            {
                // 仕入月次更新の場合、売上月次更新履歴取得
                status = GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                        0,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth,
                                                        out convertProcessDivCd);
            }

            // 会計年度テーブル取得
            this._dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList, out yearMonthList);
            
            if (procCntntsFlag == 2)
            {
                // 更新時
                //if ((currentTotalMonth > targetYearMonth) &&      // DEL 2009/05/12
                if ((ps == PurchaseStatus.Contract) &&              // ADD 2009/05/12
                    (currentTotalMonth > targetYearMonth) &&
                    ((targetYearMonth.Year == yearMonthList[yearMonthList.Count - 1].Year) &&
                     (targetYearMonth.Month == yearMonthList[yearMonthList.Count - 1].Month)))
                {
                    // 期末
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------>>>
                else if ((ps != PurchaseStatus.Contract) &&
                         ((targetYearMonth.Year == yearMonthList[yearMonthList.Count - 1].Year) &&
                          (targetYearMonth.Month == yearMonthList[yearMonthList.Count - 1].Month)))
                {
                    // 買掛オプションを導入していない場合は、対象年月と会計年度テーブルで期末判定
                    // 期末
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------<<<
            }
            else
            {
                // 取消時
                //if (((currentTotalMonth.Year >= yearMonthList[0].Year) &&     // DEL 2009/05/12
                if ((ps == PurchaseStatus.Contract) &&                          // ADD 2009/05/12
                    ((currentTotalMonth.Year >= yearMonthList[0].Year) &&
                     (currentTotalMonth.Month >= yearMonthList[0].Month)) &&
                    ((targetYearMonth.Year == yearMonthList[0].Year) &&
                     (targetYearMonth.Month == yearMonthList[0].Month)))
                {
                    // 期末
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------>>>
                else if ((ps != PurchaseStatus.Contract) &&
                         ((targetYearMonth.Year == yearMonthList[0].Year) &&
                          (targetYearMonth.Month == yearMonthList[0].Month)))
                {
                    // 買掛オプションを導入していない場合は、対象年月と会計年度テーブルで期末判定
                    // 期末
                    termLastDiv = 1;
                }
                // ADD 2009/05/12 ------<<<
            }
            
            return termLastDiv;
        }
        // ADD 2009/04/08 ------<<<
        
        /// <summary>
        /// 今回月次処理日取得処理
        /// </summary>
        /// <param name="targetYearMonth">対象年月</param>
        /// <returns>ステータス</returns>
        private DateTime GetThisMonAddUpProcDay(DateTime targetMonth)
        {
            DateTime startDate;
            DateTime endDate;

            try
            {
                this._dateGetAcs.GetDaysFromMonth(targetMonth, out startDate, out endDate);
            }
            catch
            {
                startDate = new DateTime();
                endDate = new DateTime();
            }

            return endDate;
        }

        /// <summary>
        /// 前回月次処理日取得処理
        /// </summary>
        /// <param name="targetYearMonth">対象年月</param>
        /// <returns>ステータス</returns>
        private DateTime GetLastMonAddUpProcDay(DateTime targetMonth)
        {
            DateTime startDate;
            DateTime endDate;

            try
            {
                this._dateGetAcs.GetDaysFromMonth(targetMonth, out startDate, out endDate);
            }
            catch
            {
                startDate = new DateTime();
                endDate = new DateTime();
            }

            if (startDate == DateTime.MinValue)
            {
                return startDate;
            }
            else
            {
                return startDate.AddDays(-1);
            }
        }

        /// <summary>
        /// 月次更新パラメータワーククラス取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="procCntntsFlag">処理内容フラグ(1:締取消　2:月次更新)</param>
        /// <param name="addUpYearMonth">計上年月</param>
        /// <param name="prevTotalDay">前回月次処理日</param>
        /// <param name="currentTotalDay">今回月次処理日</param>
        /// <param name="monAddUpUpdDiv">売上仕入区分(0:売上　1:仕入)</param>
        /// <returns></returns>
        private MonthlyAddUpWork GetMonthlyAddUpWork(string enterpriseCode,
                                                     string sectionCode,
                                                     int procCntntsFlag,
                                                     DateTime addUpYearMonth,
                                                     DateTime prevTotalDay,
                                                     DateTime currentTotalDay,
                                                     int monAddUpUpdDiv)
        {
            // ADD 2009/04/08 ------>>>
            // 日付取得モジュールと自社情報の最新化
            this._dateGetAcs.ReloadCompanyInf();
            LoadCompanyInf();
            // ADD 2009/04/08 ------<<<
            
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

            monthlyAddUpWork.EnterpriseCode = enterpriseCode;                                   // 企業コード
            monthlyAddUpWork.AddUpSecCode = sectionCode;                                        // 拠点コード
            monthlyAddUpWork.CompanyTotalDay = this._companyInf.CompanyTotalDay;                // 自社締日            
            monthlyAddUpWork.ProcCntntsFlag = procCntntsFlag;                                   // 処理内容フラグ
            monthlyAddUpWork.AddUpDate = GetThisMonAddUpProcDay(currentTotalDay);               // 計上年月日
            monthlyAddUpWork.AddUpYearMonth = addUpYearMonth;                                   // 計上年月
            monthlyAddUpWork.StockPointWay = this._stockMngTtlSt.StockPointWay;                 // 在庫評価方法
            monthlyAddUpWork.FractionProcCd = this._stockMngTtlSt.FractionProcCd;               // 端数処理区分
            monthlyAddUpWork.ThisMonAddUpProcDay = GetThisMonAddUpProcDay(currentTotalDay);     // 今回月次処理日
            monthlyAddUpWork.LstMonAddUpProcDay = GetLastMonAddUpProcDay(currentTotalDay);      // 前回月次処理日
            monthlyAddUpWork.AddUpDateSt = GetLastMonAddUpProcDay(currentTotalDay);
            monthlyAddUpWork.AddUpDateEd = GetThisMonAddUpProcDay(currentTotalDay);
            //ADD START zhouyu 2011/07/15 FOR 連番 42
            monthlyAddUpWork.DataSaveMonths = this._companyInf.DataSaveMonths;                  //データ保存月数
            monthlyAddUpWork.ResultDtSaveMonths = this._companyInf.ResultDtSaveMonths;          //実績データ保存月数
            monthlyAddUpWork.CaPrtsDtSaveMonths = this._companyInf.CaPrtsDtSaveMonths;          //車輌部品データ保存月数
            monthlyAddUpWork.MasterSaveMonths = this._companyInf.MasterSaveMonths;              //マスタ保存月数
            //ADD END zhouyu 2011/07/15 FOR 連番 42

            // ADD 2009/05/12 ------>>>
            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            // ADD 2009/05/12 ------<<<
                
            // 更新処理時のみ在庫更新区分セット
            if (procCntntsFlag == 2)
            {
                // ADD 2009/05/12 ------>>>
                //// 買掛オプション判定
                //PurchaseStatus ps;
                //ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
                // ADD 2009/05/12 ------<<<
                if (ps == PurchaseStatus.Contract)
                {
                    // 在庫更新区分取得(1:更新　2:更新なし)
                    monthlyAddUpWork.StockUpdDiv = GetStockUpdDiv(sectionCode, addUpYearMonth, monAddUpUpdDiv);
                }
                else
                {
                    // 在庫更新区分取得(1:更新　2:更新なし)
                    // 買掛オプションを導入していない場合は、無条件に更新
                    monthlyAddUpWork.StockUpdDiv = 1;
                }
            }

            // 期末更新区分取得(0:期末以外　1:期末)
            //monthlyAddUpWork.TermLastDiv = GetTermLastDiv(addUpYearMonth);    // DEL 2009/04/08
            //monthlyAddUpWork.TermLastDiv = GetTermLastDiv(sectionCode, addUpYearMonth, procCntntsFlag, monAddUpUpdDiv);     // ADD 2009/04/08
            monthlyAddUpWork.TermLastDiv = GetTermLastDiv(sectionCode, addUpYearMonth, procCntntsFlag, monAddUpUpdDiv, ps);     // ADD 2009/05/12

            return monthlyAddUpWork;
        }
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        #endregion
    }
}
