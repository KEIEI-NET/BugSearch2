//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 修 正 日  2010/07/20  修正内容 : テキスト出力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/17  修正内容 : 障害ID:13038 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/02/16  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization; // ADD 2010/07/20


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 担当者別実績照会アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会制御全般を行います。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2010/08/17、 2010/08/20　chenyd</br>
    /// <br>            ・障害ID:13038 テキスト出力対応</br>
    /// </remarks>
    public class EmployeeResultsAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        /// <remarks></remarks> 
        private IEmployeeResultsListDB _iEmployeeResultsListWorkDB = null;

        /// <summary>担当者別実績照会一覧データセット</summary>
        /// <remarks></remarks> 
        private EmployeeResultsDataSet _dataSet;

        /// <summary>検索条件クラスキャッシュ</summary>
        /// <remarks></remarks> 
        private static EmployeeResultsCtdtn _employeeResultsCtdtnSlipCache;

        /// <summary>担当者別実績照会アクセスクラス</summary>
        /// <remarks></remarks> 
        private static EmployeeResultsAcs _employeeResultsAcs;

        private bool _excOrtxtDiv = false;                      // テキスト出力orExcel出力区分  // ADD 2011/02/16

        ///// <summary>ステタスバアセットイベント処理</summary>
        ///// <remarks></remarks> 
        //public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;

        /// <summary>セットステタスイベント処理</summary>
        /// <remarks></remarks> 
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        #endregion

        # region ■Private Member
        private const string MESSAGE_NoResult = "担当者別実績照会に一致するデータは存在しません。";
        private const string MESSAGE_ErrResult = "担当者別実績照会の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
        private const string NOINPUT = "未登録";
        private const string ALLTOTAL = "総合計";
        private const int TANNSI = 4;

        #endregion

        # region ■Constracter
        // ---------------ADD 2011/02/16 ------------------->>>>>
        // テキスト出力orExcel出力区分
        public bool ExcOrtxtDiv
        {
            get { return this._excOrtxtDiv; }
            set { _excOrtxtDiv = value; }
        }
        // ---------------ADD 2011/02/16 -------------------<<<<<

        /// <summary>
        /// 担当者別実績照会検索 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会検索 テーブルアクセスクラスコンストラクタを初期化します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsAcs()
        {
            this._dataSet = new EmployeeResultsDataSet();
            // ログイン部品で通信状態を確認
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iEmployeeResultsListWorkDB = (IEmployeeResultsListDB)MediationEmployeeResultsListDB.GetEmployeeResultsListDB();
                }
                catch (Exception)
                {
                    //オフライン時はnullをセット
                    this._iEmployeeResultsListWorkDB = null;
                }
            }
            else
            {
                // オフライン時のデータ読み込み
                //this.SearchOfflineData();
                MessageBox.Show("オフライン状態のため検索が実行できません。");
            }
        }

        /// <summary>
        /// 検索条件クラスキャッシュ取得処理
        /// </summary>
        /// <returns>検索条件クラスキャッシュ</returns>
        /// <remarks>
        /// <br>Note       : 検索条件クラスキャッシュ取得処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public EmployeeResultsCtdtn GetParaEmployeeResultsSlipCache()
        {
            return _employeeResultsCtdtnSlipCache;
        }

        #endregion

        # region ■インスタンス取得処理
        /// <summary>
        /// 担当者別実績照会検索アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>担当者別実績照会検索アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会検索アクセスクラス インスタンス取得処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public static EmployeeResultsAcs GetInstance()
        {
            if (_employeeResultsAcs == null)
            {
                _employeeResultsAcs = new EmployeeResultsAcs();
            }

            return _employeeResultsAcs;
        }
        #endregion

        #region ■ データセット取得処理
        /// <summary>
        /// 担当者別実績照会データセット取得処理
        /// </summary>
        /// <returns>担当者別実績照会データセット</returns>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会データセット取得処理を行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Note       : 担当者別実績照会情報を読み込みます。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public EmployeeResultsDataSet DataSet
        {
            get { return this._dataSet; }
            set { _dataSet = value; } // ADD 2010/07/20
        }

        #endregion

        #region ■Public Method

        /// <summary>
        /// 担当者別実績照会情報 読込・データセット格納実行処理
        /// </summary>
        /// <param name="employeeResultsCtdtn">担当者別実績照会検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会情報を読み込みます。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public int SetSearchData(EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            try
            {
                // ダイアログ表示
                form.Show();

                List<EmployeeResultsListResultWork> retData;

                // リモート呼び出し
                int status = this.Search(out retData, employeeResultsCtdtn);
                this.ClearEmployeeResultsDataTable();

                this._dataSet.EmployeeResults.Rows.Clear();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (retData.Count != 0)
                    {
                        long retGoodSales;
                        long PureSales;
                        ToSumSet(retData, out retGoodSales, out PureSales);

                        for (int i = 0; i < retData.Count; i++)
                        {
                            // 1明細取得
                            EmployeeResultsListResultWork employeeResultsListResultWork = retData[i];

                            // データテーブルに格納
                            CopyToTable(employeeResultsListResultWork, employeeResultsCtdtn, retGoodSales, PureSales);
                        }

                        CopyAllToTable(employeeResultsCtdtn, retGoodSales, PureSales);

                    }

                }
                return status;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// 担当者別実績照会情報 読込・データセット格納実行処理(出力用)
        /// </summary>
        /// <param name="employeeResultsCtdtn">担当者別実績照会検索パラメータクラス</param>
        /// <param name="SectionCodeSt">拠点</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会情報を読み込みます。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        //public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn)  // DEL 2010/08/20
        //public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn, string SectionCodeSt) // ADD 2010/08/20 // DEL 2010/09/21
        public int SearchForOutput(EmployeeResultsCtdtn employeeResultsCtdtn, string SectionCodeSt, string SectionCodeEd) // ADD 2010/09/21
        {
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            try
            {
                // ダイアログ表示
                form.Show();

                List<EmployeeResultsListResultWork> retData;
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                long retGoodSales = 0;
                long PureSales = 0;
                this.ClearEmployeeResultsDataTable();

                this._dataSet.EmployeeResults.Rows.Clear();
                // --- UPD 2010/09/21 ---------->>>>>
                //if (SectionCodeSt != string.Empty)
                //{
                //    employeeResultsCtdtn.SectionCode = SectionCodeSt;
                //}

                if (SectionCodeSt != string.Empty)
                {
                    if ("00".Equals(SectionCodeSt) && !"00".Equals(SectionCodeEd))
                    {
                        employeeResultsCtdtn.SectionCode = SectionCodeEd;
                    }
                    else
                    {
                        employeeResultsCtdtn.SectionCode = SectionCodeSt;
                    }
                }

                // --- UPD 2010/09/21 ----------<<<<<
                status = this.Search(out retData, employeeResultsCtdtn);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (retData.Count != 0)
                    {
                        ToSumSet(retData, out retGoodSales, out PureSales);

                        for (int i = 0; i < retData.Count; i++)
                        {
                            // 1明細取得
                            EmployeeResultsListResultWork employeeResultsListResultWork = retData[i];

                            // データテーブルに格納
                            CopyToTable(employeeResultsListResultWork, employeeResultsCtdtn, retGoodSales, PureSales);
                        }
                        //CopyAllToTable(employeeResultsCtdtn, retGoodSales, PureSales); // DEL 2010/09/09
                        _excOrtxtDiv = false;// ADD 2011/02/16
                    }

                }

                return status;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        /// <summary>
        /// 担当者別実績照会セットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会セットクリア処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void ClearEmployeeResultsDataTable()
        {
            this._dataSet.EmployeeResults.Rows.Clear();

            // キャッシュデータの取り直し(クリア状態にする)
            this.CacheParaEmployeeResultsSlip(null);
        }

        /// <summary>
        /// 検索条件クラス(再表示用) キャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索条件クラス(再表示用) キャッシュ処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void CacheParaEmployeeResultsSlip(EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            // 検索条件値
            if (_employeeResultsCtdtnSlipCache == null)
            {
                _employeeResultsCtdtnSlipCache = new EmployeeResultsCtdtn();
            }
            _employeeResultsCtdtnSlipCache = employeeResultsCtdtn;

        }

        /// <summary>
        /// 担当者別実績照会セット総合計処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会セット総合計処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void ToSumSet(List<EmployeeResultsListResultWork> retData, out long retGoodSales, out long pureSales)
        {
            long retGood = 0;
            long pureSa = 0;
            foreach (EmployeeResultsListResultWork detailWork in retData)
            {
                retGood += detailWork.RetGoodSalesTotalTaxExc;

                pureSa += (Convert.ToInt64(Convert.ToDecimal(detailWork.BackSalesTotalTaxExc) + Convert.ToDecimal(detailWork.BackSalesDisTtlTaxExc) + Convert.ToDecimal(detailWork.RetGoodSalesTotalTaxExc)));
            }

            retGoodSales = retGood * (-1);
            pureSales = pureSa;
        }


        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="retWork">担当者別実績照会データワーク</param>
        /// <param name="employeeResultsCtdtn">担当者別実績照会 データクラス</param>
        /// <param name="retGoodSales">返品額</param>
        /// <param name="PureSales">純売上</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            テキスト出力対応</br>
        /// </remarks>
        private void CopyToTable(EmployeeResultsListResultWork retWork, EmployeeResultsCtdtn employeeResultsCtdtn, long retGoodSales, long PureSales)
        {
            // 新規行取得
            EmployeeResultsDataSet.EmployeeResultsRow row = _dataSet.EmployeeResults.NewEmployeeResultsRow();

            # region [copy]
            row.Header = _dataSet.EmployeeResults.Rows.Count + 1;    // 行№

            //ｺｰﾄﾞ
            //if (!string.IsNullOrEmpty(retWork.EmployeeCode)) // DEL 2010/09/14
            if (retWork.EmployeeCode != null && !string.IsNullOrEmpty(retWork.EmployeeCode.Trim())) // ADD 2010/09/14
            {
                row.EmployeeCode = retWork.EmployeeCode.Trim();
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            else
            {
                //row.EmployeeCode = ""; // DEL 2010/09/14
                row.EmployeeCode = "0000"; // ADD 2010/09/14
            }
            // --- ADD 2010/07/20--------------------------------<<<<<
            //売上金額
            row.BackSalesTotalTaxExc = retWork.BackSalesTotalTaxExc;

            //返品額
            row.RetGoodSalesTotalTaxExc = (-1) * retWork.RetGoodSalesTotalTaxExc;

            //値引額
            row.BackSalesDisTtlTaxExc = (-1) * retWork.BackSalesDisTtlTaxExc;

            //純売上
            row.PureSales = Convert.ToInt64(Convert.ToDecimal(row.BackSalesTotalTaxExc) - Convert.ToDecimal(row.BackSalesDisTtlTaxExc) - Convert.ToDecimal(row.RetGoodSalesTotalTaxExc));

            //伝票枚数
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.SlipNumCount = retWork.SlipNumCount;
            }

            //売上目標額
            row.SalesTargetMoney = retWork.SalesTargetMoney;

            if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //返品構成
                if (retGoodSales != 0)
                {
                    row.RetGoodsStructure = decimal.Round((Convert.ToDecimal(row.RetGoodSalesTotalTaxExc) / Convert.ToDecimal(retGoodSales)), TANNSI, MidpointRounding.AwayFromZero);
                    // --------------------ADD 2011/02/16 ------------->>>>>
                    if (_excOrtxtDiv)
                    {
                        row.RetGoodsStructure = row.RetGoodsStructure * 100;
                    }
                    // --------------------ADD 2011/02/16 -------------<<<<<
                }

                //売上構成
                if (PureSales != 0)
                {
                    row.SalesStructure = decimal.Round((Convert.ToDecimal(row.PureSales) / Convert.ToDecimal(PureSales)), TANNSI, MidpointRounding.AwayFromZero);
                    // --------------------ADD 2011/02/16 ------------->>>>>
                    if (_excOrtxtDiv)
                    {
                        row.SalesStructure = row.SalesStructure * 100;
                    }
                    // --------------------ADD 2011/02/16 -------------<<<<<
                }
            }

            //名称
            if (!string.IsNullOrEmpty(retWork.EmployeeName))
            {
                row.EmployeeName = retWork.EmployeeName;
            }
            else
            {
                row.EmployeeName = NOINPUT;
            }

            //原価
            row.TotalCost = retWork.TotalCost;

            //返品率
            if (row.BackSalesTotalTaxExc != 0)
            {
                row.RetGoodsPct = decimal.Round((Convert.ToDecimal(row.RetGoodSalesTotalTaxExc) / Convert.ToDecimal(row.BackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.RetGoodsPct = row.RetGoodsPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //値引率
            if (row.BackSalesTotalTaxExc != 0)
            {
                row.DisTtlPct = decimal.Round((Convert.ToDecimal(row.BackSalesDisTtlTaxExc) / Convert.ToDecimal(row.BackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.DisTtlPct = row.DisTtlPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //粗利額
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.GrossProfit = row.BackSalesTotalTaxExc - row.RetGoodSalesTotalTaxExc - row.BackSalesDisTtlTaxExc - row.TotalCost;
            }
            else
            {
                row.GrossProfit = retWork.GrossProfit;
            }

            //粗利率
            if (row.PureSales != 0)
            {
                row.GrossProfitPct = decimal.Round((Convert.ToDecimal(row.GrossProfit) / Convert.ToDecimal(row.PureSales)), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.GrossProfitPct = row.GrossProfitPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }

            //目標達成率
            if (row.SalesTargetMoney != 0)
            {
                row.TargetPct = decimal.Round(((Convert.ToDecimal(row.PureSales) / Convert.ToDecimal(row.SalesTargetMoney))), TANNSI, MidpointRounding.AwayFromZero);
                // --------------------ADD 2011/02/16 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    row.TargetPct = row.TargetPct * 100;
                }
                // --------------------ADD 2011/02/16 -------------<<<<<
            }
            // --- ADD 2010/08/17-------------------------------->>>>>
            if (string.IsNullOrEmpty(retWork.SectionCode))
            {
                row.SectionCode = "00";
                row.SectionName = "";
            }
            else
            {
                // --- ADD 2010/08/17--------------------------------<<<<<
                // --- ADD 2010/07/20-------------------------------->>>>>
                // 拠点
                //row.SectionCode = retWork.SectionCode; // DEL 2010/09/09
                row.SectionCode = retWork.SectionCode.Trim(); // ADD 2010/09/09
                row.SectionName = GetSectionName(retWork.SectionCode, employeeResultsCtdtn.SectionCodeList);
            }
            
            // 期間
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);

            }
            else
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // ---------------ADD 2011/02/16 ------------------->>>>>
            if (_excOrtxtDiv)
            {
                if (employeeResultsCtdtn.DuringType == 1)
                {
                    row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                    row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);
                    if (!string.IsNullOrEmpty(row.DuringSt))
                    {
                        row.DuringSt = row.DuringSt.Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(row.DuringEd))
                    {
                        row.DuringEd = row.DuringEd.Replace("/", "");
                    }
                }
                else
                {
                    row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                    row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
                    if (!string.IsNullOrEmpty(row.DuringSt))
                    {
                        row.DuringSt = row.DuringSt.Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(row.DuringEd))
                    {
                        row.DuringEd = row.DuringEd.Replace("/", "");
                    }
                }
            }
            // ---------------ADD 2011/02/16 -------------------<<<<<

            # endregion

            // 追加
            _dataSet.EmployeeResults.AddEmployeeResultsRow(row);
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="employeeRsectionListesultsCtdtn">拠点リスト</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称取得処理を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, List<string[]> sectionList)
        {
            foreach (string[] sectionArray in sectionList)
            {
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    if (sectionArray[0].Trim().Equals(sectionCode.Trim()))
                    {
                        return sectionArray[1];
                    }
                }
            }
            return string.Empty;
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="retGoodSales">値引額</param>
        /// <param name="employeeResultsCtdtn">担当者別実績照会 データクラス</param>
        /// <param name="pureSales">純売上</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void CopyAllToTable(EmployeeResultsCtdtn employeeResultsCtdtn, long retGoodSales, long pureSales)
        {
            //売上金額（総合計）
            long allBackSalesTotalTaxExc = 0;

            //値引額（総合計）
            long allBackSalesDisTtlTaxExc = 0;

            //伝票枚数（総合計）
            int allSlipNumCount = 0;

            //売上目標額（総合計）
            long allSalesTargetMoney = 0;

            //原価（総合計）
            long allTotalCost = 0;

            //粗利額（総合計）
            long allGrossProfit = 0;

            foreach (EmployeeResultsDataSet.EmployeeResultsRow dataRow in _dataSet.EmployeeResults.Rows)
            {
                allBackSalesTotalTaxExc += dataRow.BackSalesTotalTaxExc;

                allBackSalesDisTtlTaxExc += dataRow.BackSalesDisTtlTaxExc;

                allSlipNumCount += dataRow.SlipNumCount;

                allSalesTargetMoney += dataRow.SalesTargetMoney;

                allTotalCost += dataRow.TotalCost;

                allGrossProfit += dataRow.GrossProfit;
            }

            // 新規行取得
            EmployeeResultsDataSet.EmployeeResultsRow row = _dataSet.EmployeeResults.NewEmployeeResultsRow();

            row.Header = _dataSet.EmployeeResults.Rows.Count + 1;    // 行№

            //ｺｰﾄﾞ
            //row.EmployeeCode = ALLTOTAL; // DEL 2010/07/20
            // --- ADD 2010/07/20-------------------------------->>>>>
            if (!"OUTPUT".Equals(employeeResultsCtdtn.ViewFlg))
                row.EmployeeCode = ALLTOTAL;
            else
                row.EmployeeCode = "";
            // --- ADD 2010/07/20--------------------------------<<<<<

            //売上金額
            row.BackSalesTotalTaxExc = allBackSalesTotalTaxExc;

            //返品額
            row.RetGoodSalesTotalTaxExc = retGoodSales;

            //値引額
            row.BackSalesDisTtlTaxExc = allBackSalesDisTtlTaxExc;

            //純売上
            row.PureSales = pureSales;

            //伝票枚数
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.SlipNumCount = allSlipNumCount;
            }

            //売上目標額
            row.SalesTargetMoney = allSalesTargetMoney;

            if (employeeResultsCtdtn.DuringType == 2 || employeeResultsCtdtn.DuringType == 3)
            {
                //返品構成
                row.RetGoodsStructure = decimal.Round((Convert.ToDecimal(1)), TANNSI, MidpointRounding.AwayFromZero);

                //売上構成
                row.SalesStructure = decimal.Round((Convert.ToDecimal(1)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //原価
            row.TotalCost = allTotalCost;

            //返品率
            if (allBackSalesTotalTaxExc != 0)
            {
                row.RetGoodsPct = decimal.Round((Convert.ToDecimal(retGoodSales) / Convert.ToDecimal(allBackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //値引率
            if (allBackSalesTotalTaxExc != 0)
            {
                row.DisTtlPct = decimal.Round((Convert.ToDecimal(allBackSalesDisTtlTaxExc) / Convert.ToDecimal(allBackSalesTotalTaxExc)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //粗利額
            row.GrossProfit = allGrossProfit;

            //粗利率
            if (row.PureSales != 0)
            {
                row.GrossProfitPct = decimal.Round((Convert.ToDecimal(allGrossProfit) / Convert.ToDecimal(pureSales)), TANNSI, MidpointRounding.AwayFromZero);
            }

            //目標達成率
            if (allSalesTargetMoney != 0)
            {
                row.TargetPct = decimal.Round(((Convert.ToDecimal(pureSales) / Convert.ToDecimal(allSalesTargetMoney))), TANNSI, MidpointRounding.AwayFromZero);
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            // 拠点
            row.SectionCode = "00";
            if ("OUTPUT".Equals(employeeResultsCtdtn.ViewFlg))
                // 拠点名称
                row.SectionName = ALLTOTAL;
            // 期間
            if (employeeResultsCtdtn.DuringType == 1)
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.St_DuringTime);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM/DD", employeeResultsCtdtn.Ed_DuringTime);

            }
            else
            {
                row.DuringSt = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.St_YearMonth);
                row.DuringEd = TDateTime.DateTimeToString("YYYY/MM", employeeResultsCtdtn.Ed_YearMonth);
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // 追加
            _dataSet.EmployeeResults.AddEmployeeResultsRow(row);
        }

        /// <summary>
        /// 担当者別実績照会情報 読み込み処理
        /// </summary>
        /// <param name="employeeResultsListResultWorks">担当者別実績照会 オブジェクト配列</param>
        /// <param name="employeeResultsCtdtn">担当者別実績照会検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会情報を読み込みます。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public int Search(out List<EmployeeResultsListResultWork> employeeResultsListResultWorks, EmployeeResultsCtdtn employeeResultsCtdtn)
        {
            string errMsg = "";

            int status;
            employeeResultsListResultWorks = new List<EmployeeResultsListResultWork>();

            EmployeeResultsListCndtnWork employeeResultsListCndtnWork = new EmployeeResultsListCndtnWork();
            // 抽出条件展開  --------------------------------------------------------------
            status = this.DevEmployeeResultsMainCndtn(employeeResultsCtdtn, out employeeResultsListCndtnWork, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            object retObj = null;

            try
            {
                // オンラインの場合リモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    // リモートオブジェクト取得
                    if (this._iEmployeeResultsListWorkDB == null)
                    {
                        this._iEmployeeResultsListWorkDB = (IEmployeeResultsListDB)MediationEmployeeResultsListDB.GetEmployeeResultsListDB();
                    }

                    status = this._iEmployeeResultsListWorkDB.Search(out retObj, employeeResultsListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList retList = retObj as ArrayList;
                        int len = retList.Count;
                        for (int i = 0; i < len; i++)
                        {
                            employeeResultsListResultWorks.Add((EmployeeResultsListResultWork)retList[i]);
                        }
                    }
                }
                else	// オフラインの場合
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                employeeResultsListResultWorks = null;
                //オフライン時はnullをセット
                this._iEmployeeResultsListWorkDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }


        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="employeeResultsCtdtn">UI抽出条件クラス</param>
        /// <param name="employeeResultsListCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行います。</br>		
        /// <br>Programmer : 汪千来</br>		
        /// <br>Date       : 2009.04.01</br>		
        /// </remarks>		
        private int DevEmployeeResultsMainCndtn(EmployeeResultsCtdtn employeeResultsCtdtn, out EmployeeResultsListCndtnWork employeeResultsListCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            employeeResultsListCndtnWork = new EmployeeResultsListCndtnWork();

            try
            {
                // 企業コード
                employeeResultsListCndtnWork.EnterpriseCode = employeeResultsCtdtn.EnterpriseCode;

                // 拠点コード
                employeeResultsListCndtnWork.SectionCode = employeeResultsCtdtn.SectionCode;
                // --- ADD 2010/07/20-------------------------------->>>>>
                // 拠点コードリスト
                employeeResultsListCndtnWork.SectionCodeList = employeeResultsCtdtn.SectionCodeList;
                // 画面ビュー・出力ビューフラグ
                employeeResultsListCndtnWork.ViewFlg = employeeResultsCtdtn.ViewFlg;
                // --- ADD 2010/07/20 --------------------------------<<<<<

                //参照区分
                employeeResultsListCndtnWork.ReferType = employeeResultsCtdtn.ReferType;

                //担当者(開始)
                employeeResultsListCndtnWork.St_EmployeeCode = employeeResultsCtdtn.St_EmployeeCode;

                //担当者(終了)
                employeeResultsListCndtnWork.Ed_EmployeeCode = employeeResultsCtdtn.Ed_EmployeeCode;

                //期間区分
                employeeResultsListCndtnWork.DuringType = employeeResultsCtdtn.DuringType;

                if (employeeResultsListCndtnWork.DuringType == 1)
                {
                    //期間(開始)YYYYMMDD
                    employeeResultsListCndtnWork.St_DuringTime = employeeResultsCtdtn.St_DuringTime;

                    //期間(終了)YYYYMMDD
                    employeeResultsListCndtnWork.Ed_DuringTime = employeeResultsCtdtn.Ed_DuringTime;
                }
                else if (employeeResultsListCndtnWork.DuringType == 2 || employeeResultsListCndtnWork.DuringType == 3)
                {

                    //期間(開始)YYYYMM
                    employeeResultsListCndtnWork.St_YearMonth = employeeResultsCtdtn.St_YearMonth;

                    //期間(終了)YYYYMM
                    employeeResultsListCndtnWork.Ed_YearMonth = employeeResultsCtdtn.Ed_YearMonth;
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

        #endregion
    }
}